Imports DevExpress.XtraRichEdit.API.Native
Imports C2 = Cprp.DxData.Common
''' <summary>
''' Расчет стоимости заказа
''' </summary>
''' <remarks></remarks>
Friend Class CalcForm

    ' Таблица расчета стоимости заказа
    Private _Calc As CalcDataTable = Nothing

    ''' <summary>
    ''' ID расчета
    ''' </summary>
    Friend CalcId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' Спарвчник видов услуг
    ''' </summary>
    Private TypeTable As Cprp.DxData.Handbook.CalcTypeDataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="calcId">ID расчета</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal calcId As Object)
        InitializeComponent()
        Dim Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
        '
        ' CalcId 
        '
        Me.CalcId = C2.ToInt(calcId)
        '
        ' _Calc
        '
        _Calc = New CalcDataTable
        Cmd.CommandText = String.Format("SELECT * FROM vCalc WHERE id = {0}", Me.CalcId)
        _Calc.Load(Cmd.ExecuteReader)
        If _Calc.Rows.Count = 0 Then
            Dim Row As DataRow = _Calc.NewRow
            Row("isAdd") = False
            Row("isAgreement") = False
            Row("isUrgency") = False
            Row("objectDifCount") = 1
            Row("objectAllCount") = 1
            Row("workCount") = 1
            Row("dopMinCount") = 0
            Row("priceCalc") = 0
            Row("priceEnd") = 0
            Row("userId") = Program.DbClient.Id
            Row("actDate") = Date.Now
            _Calc.Rows.Add(Row)
        End If
        '
        ' TypeTable
        '
        TypeTable = New Cprp.DxData.Handbook.CalcTypeDataTable(Program.DbClient.Connection)
        '
        ' DataSource
        '
        AddLookUpEdit.Properties.DataSource = New Cprp.DxData.HandBook.YesNoDataTable
        AgreementLookUpEdit.Properties.DataSource = New Cprp.DxData.HandBook.YesNoDataTable
        UrgencyLookUpEdit.Properties.DataSource = New Cprp.DxData.HandBook.YesNoDataTable
        TypeLookUpEdit.Properties.DataSource = TypeTable
        '
        ' DataBundings
        '
        AddLookUpEdit.DataBindings.Add("EditValue", _Calc, "isAdd")
        AgreementLookUpEdit.DataBindings.Add("EditValue", _Calc, "isAgreement")
        UrgencyLookUpEdit.DataBindings.Add("EditValue", _Calc, "isUrgency")
        TypeLookUpEdit.DataBindings.Add("EditValue", _Calc, "typeId")
        ObjectDifCountSpinEdit.DataBindings.Add("EditValue", _Calc, "objectDifCount")
        ObjectAllCountSpinEdit.DataBindings.Add("EditValue", _Calc, "objectAllCount")
        WorkCountSpinEdit.DataBindings.Add("EditValue", _Calc, "workCount")
        DopMinCountSpinEdit.DataBindings.Add("EditValue", _Calc, "dopMinCount")
        PriceEndSpinEdit.DataBindings.Add("EditValue", _Calc, "priceEnd")
        CommentMemoEdit.DataBindings.Add("EditValue", _Calc, "comment")

        OrderNumTextEdit.Text = _Calc(0)("orderNum").ToString
        DeptNameTextEdit.Text = _Calc(0)("deptName").ToString
        '
        ' PriceEndSpinEdit
        '
        Cmd.CommandText = String.Format("SELECT isChange FROM tCalcType WHERE id = {0}", C2.ToInt(_Calc(0)("typeId")))
        PriceEndSpinEdit.ReadOnly = Not CBool(Cmd.ExecuteScalar)
        '
        ' SaveBarButtonItem 
        '
        SaveBarButtonItem.Enabled = (_Calc(0).RowState <> DataRowState.Added)
        '
        ' Me
        '
        RefreshMe()
        Me.Icon = My.Resources.calculator_ico
        Me.CenterToScreen()

    End Sub

    Private Sub RefreshMe()
        Me.Text = String.Format("Расчет стоимости заказа {0}", If(_Calc(0).RowState = DataRowState.Added, "[новый]", String.Format("ID: {0}", C2.ToInt(_Calc(0)("id")))))
    End Sub

    Private Sub CalcBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles CalcBarButtonItem.ItemClick
        Me.BindingContext(_Calc).EndCurrentEdit()
        DxErrorProvider1.ClearErrors()
        With _Calc.Rows(0)
            If IsDBNull(.Item("typeId")) Then
                DxErrorProvider1.SetError(TypeLookUpEdit, "Выберите вид расчета")
                Exit Sub
            End If
            If IsDBNull(.Item("objectDifCount")) OrElse CInt(.Item("objectDifCount")) < 1 Then
                DxErrorProvider1.SetError(ObjectDifCountSpinEdit, "Укажите количество объектов исследования")
                Exit Sub
            End If
            If IsDBNull(.Item("objectAllCount")) OrElse CInt(.Item("objectAllCount")) < 1 Then
                DxErrorProvider1.SetError(ObjectAllCountSpinEdit, "Укажите общее количество товаров")
                Exit Sub
            End If
            If CInt(.Item("objectAllCount")) - CInt(.Item("objectDifCount")) < 0 Then
                DxErrorProvider1.SetError(ObjectAllCountSpinEdit, "Общее количество товаров меньше количества объектов исследования")
                Exit Sub
            End If
        End With
        Try
            _Calc.Calc(_Calc.Rows(0))
            SaveBarButtonItem.Enabled = True
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                Cmd.CommandText = String.Format("SELECT isChange FROM tCalcType WHERE id = {0}", CInt(_Calc(0)("typeId")))
                PriceEndSpinEdit.ReadOnly = Not (CBool(Cmd.ExecuteScalar) OrElse _Calc(0)("orderNum").ToString Like "05/1134*")
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    Private Sub SaveBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles SaveBarButtonItem.ItemClick
        Me.BindingContext(_Calc).EndCurrentEdit()
        DxErrorProvider1.ClearErrors()
        If IsDBNull(_Calc(0)("deptId")) Then
            DxErrorProvider1.SetError(OrderNumTextEdit, "Получите номер заказа и представительство из Электронного офиса")
            Exit Sub
        End If
        If Not IsDBNull(_Calc(0)("orderNum")) AndAlso _Calc(0)("orderNum").ToString = "1" Then Exit Sub
        Try
            _Calc(0)("userId") = Program.DbClient.Id
            _Calc(0)("actDate") = Date.Now
            Using A As New SqlDataAdapter("SELECT * FROM tCalc", Program.DbClient.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(_Calc)
            End Using
            Program.MainForm.CalcControl.DataReload()
            If Cprp.DxCommon.Messages.ShowQuestion("Данные сохранены. Закрыть окно?", "Расчет") = DialogResult.Yes Then Me.Close()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    Private Sub GetOrderNumSimpleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GetOrderNumSimpleButton.Click
        DeptNameTextEdit.EditValue = DBNull.Value
        ObjectDifCountSpinEdit.EditValue = 1
        ObjectAllCountSpinEdit.EditValue = 1
        WorkCountSpinEdit.EditValue = 1
        DopMinCountSpinEdit.EditValue = 0
        CommentMemoEdit.EditValue = DBNull.Value
        PriceEndSpinEdit.EditValue = 0
        _Calc(0)("deptId") = DBNull.Value
        _Calc(0)("priceCalc") = 0
        _Calc(0)("priceEnd") = 0
        Dim sTmp As String = Trim(OrderNumTextEdit.Text)
        If String.IsNullOrWhiteSpace(sTmp) Then Exit Sub
        Try
            Dim EOProject As EODataAccess.OrderProject = EODataAccess.EODataAccessUtility.GetOrderProjectByTitleNotCancelled(sTmp)
            If EOProject Is Nothing Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Заказ № {0} в Электронном офисе не найден!", sTmp))
                Exit Sub
            End If
            _Calc(0)("orderNum") = EOProject.Title
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                Cmd.CommandText = String.Format("SELECT id, name FROM tCalcDepartment WHERE eoId = {0}", EOProject.DepartmentID)
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    If Dr.Read Then
                        _Calc(0)("deptId") = CInt(Dr("id"))
                        _Calc(0)("deptName") = Dr("name").ToString
                        DeptNameTextEdit.Text = Dr("name").ToString
                    End If
                End Using
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    Private Sub DopLookUpEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AddLookUpEdit.EditValueChanged
        SaveBarButtonItem.Enabled = False
    End Sub

    Private Sub AgreementLookUpEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AgreementLookUpEdit.EditValueChanged
        SaveBarButtonItem.Enabled = False
    End Sub

    Private Sub UrgencyLookUpEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UrgencyLookUpEdit.EditValueChanged
        SaveBarButtonItem.Enabled = False
    End Sub

    Private Sub TypeLookUpEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TypeLookUpEdit.EditValueChanged
        SaveBarButtonItem.Enabled = False
    End Sub

    Private Sub GoodCountSpinEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ObjectDifCountSpinEdit.EditValueChanged
        SaveBarButtonItem.Enabled = False
    End Sub

    Private Sub CountryCountSpinEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles WorkCountSpinEdit.EditValueChanged
        SaveBarButtonItem.Enabled = False
    End Sub

    Private Sub TranslitCountSpinEdit_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DopMinCountSpinEdit.EditValueChanged
        SaveBarButtonItem.Enabled = False
    End Sub

    ' Поиск расчетных данных в таблице работ по номеру заказа и виду услуги
    Private Sub TypeLookUpEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles TypeLookUpEdit.EditValueChanging
        If _Calc.Rows(0).RowState <> DataRowState.Added Then Exit Sub
        ObjectDifCountSpinEdit.EditValue = 1
        ObjectAllCountSpinEdit.EditValue = 1
        WorkCountSpinEdit.EditValue = 1
        DopMinCountSpinEdit.EditValue = 0
        CommentMemoEdit.EditValue = DBNull.Value
        PriceEndSpinEdit.EditValue = 0
        _Calc(0)("priceCalc") = 0
        _Calc(0)("priceEnd") = 0
        Dim orderNum As String = C2.ToText(OrderNumTextEdit.Text)
        If String.IsNullOrWhiteSpace(orderNum) Then Exit Sub
        Dim typeId As Integer = C2.ToInt(e.NewValue)
        Select Case typeId
            Case 14 : typeId = 1    ' Идентификация по ЭК
            Case 15 : typeId = 3    ' Запреты и ограничения ЕАЭС
            Case 16 : typeId = 2    ' Гражданское назначение
            Case 17 : typeId = 5    ' Определение кода ТН ВЭД
            Case 18 : typeId = 6    ' Консультация
            Case 28 : typeId = 4    ' Подтверждение лицензии
            Case Else : Exit Sub
        End Select
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = String.Format("SELECT id, clientName, goodCount, goodAllCount, extraWork FROM tWork WHERE conditionId <> {0} AND orderNum LIKE '{1}' AND typeId = {2}", CInt(Cprp.DxData.Work.WorkCondition.IsCancel), orderNum.Replace("'", "''"), typeId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    Dim iTmp As Integer = C2.ToInt(Dr("goodCount"))
                    If iTmp > 0 Then ObjectDifCountSpinEdit.EditValue = iTmp
                    iTmp = C2.ToInt(Dr("goodAllCount"))
                    If iTmp > 0 Then
                        ObjectAllCountSpinEdit.EditValue = iTmp
                    Else
                        ObjectAllCountSpinEdit.EditValue = ObjectDifCountSpinEdit.EditValue
                    End If
                    iTmp = C2.ToInt(Dr("extraWork"))
                    If iTmp > 0 Then DopMinCountSpinEdit.EditValue = iTmp
                    CommentMemoEdit.EditValue = String.Format("Работа № {0}{1}{2}", C2.ToInt(Dr("id")), vbCrLf, C2.ToText(Dr("clientName")))
                End If
            End Using
        End Using
    End Sub

    ' Экспорт расчета в PDF
    Private Sub ExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportBarButtonItem.ItemClick
        Dim sTmp As String = C2.ToText(_Calc(0)("orderNum"))
        If String.IsNullOrWhiteSpace(sTmp) Then Exit Sub
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Укажите место сохранения файла расчета"
            Dlg.DefaultExt = "pdf"
            Dlg.Filter = "Файл Adobe PDF (*.pdf)|*.pdf"
            Dlg.FileName = String.Format("Расчет стоимости по заказу {0}", sTmp.Replace("/", "_"))
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Try
            R.Unit = DevExpress.Office.DocumentUnit.Document
            R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
            R.OpenXmlBytes = My.Resources.calc
            R.Document.BeginUpdate()
            PutBookmark(R.Document, "orderNum", C2.ToText(_Calc(0)("orderNum")))
            sTmp = C2.ToText(_Calc(0)("typeName"))
            Dim Row As DataRow = TypeTable.Rows.Find(_Calc(0)("typeId"))
            If Not Row Is Nothing Then sTmp = C2.ToText(Row("description"))
            PutBookmark(R.Document, "typeName", sTmp)
            PutBookmark(R.Document, "objectDifCount", C2.ToText(_Calc(0)("objectDifCount")))
            PutBookmark(R.Document, "objectAllCount", C2.ToText(_Calc(0)("objectAllCount")))
            PutBookmark(R.Document, "workCount", C2.ToText(_Calc(0)("workCount")))
            PutBookmark(R.Document, "dopMinCount", C2.ToText(_Calc(0)("dopMinCount")))
            PutBookmark(R.Document, "isUrgency", If(CBool(_Calc(0)("isUrgency")), "Да", "Нет"))
            PutBookmark(R.Document, "priceEnd", C2.ToText(_Calc(0)("priceEnd")))
            sTmp = C2.ToText(_Calc(0)("comment"))
            If String.IsNullOrWhiteSpace(sTmp) Then sTmp = "-"
            PutBookmark(R.Document, "comment", sTmp)
            R.Document.EndUpdate()
            Using Fs As New System.IO.FileStream(filePath, IO.FileMode.Create)
                R.ExportToPdf(Fs)
                Fs.Close()
            End Using
            Using P As New Process
                P.StartInfo.FileName = filePath
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            R.Dispose()
        End Try


    End Sub

    Private Sub PutRange(ByVal R As DocumentRange, ByVal rangeText As String, Optional ByVal errorText As String = Nothing)
        With R.BeginUpdateDocument
            .Replace(R, Nothing)
            If Not String.IsNullOrWhiteSpace(rangeText) Then
                .InsertText(R.Start, rangeText)
            ElseIf Not String.IsNullOrWhiteSpace(errorText) Then
                .InsertHtmlText(R.Start, String.Format("<span style='font-weight:bold;color:#ff0000'>{0}</style>", errorText))
            End If
        End With
    End Sub

    Private Sub PutBookmark(ByVal Doc As SubDocument, ByVal bookmarkName As String, ByVal bookmarkText As String, Optional ByVal errorText As String = "[нет данных]")
        If Doc.Bookmarks(bookmarkName) Is Nothing Then Exit Sub
        Dim bStart As Integer = Doc.Bookmarks(bookmarkName).Range.Start.ToInt
        Dim bEnd As Integer = (bookmarkText & vbNullString).Length
        If bEnd = 0 Then bEnd = (errorText & vbNullString).Length
        PutRange(Doc.Bookmarks(bookmarkName).Range, bookmarkText, errorText)
        If Doc.Bookmarks(bookmarkName) Is Nothing Then Doc.Bookmarks.Create(Doc.CreateRange(bStart, bEnd), bookmarkName)
    End Sub

End Class