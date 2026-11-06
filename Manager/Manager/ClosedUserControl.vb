Imports C2 = Cprp.DxData.Common
''' <summary>
''' Закрытые работы
''' </summary>
Friend Class ClosedUserControl

    ' Список работ
    Private ListTable As DataTable = Nothing

    Private WithEvents TMR As Timer = Nothing

    Friend Sub New()
        InitializeComponent()
        '
        ' ListTable
        '
        ListTable = New DataTable
        With ListTable.Columns
            .Add("id", GetType(Integer))                    ' ID работы
            .Add("sId", GetType(String))                    ' вид услуги
            .Add("conditionId", GetType(Integer))           ' ID состояния работы
            .Add("conditionName", GetType(String))          ' состояние работы
            .Add("expertId", GetType(Integer))              ' ID эксперта
            .Add("expertName", GetType(String))             ' эксперт
            .Add("expertTerm", GetType(Date))               ' срок эксперта
            .Add("managerId", GetType(Integer))             ' ID менеджера
            .Add("managerName", GetType(String))            ' менеджер
            .Add("leaderId", GetType(Integer))              ' ID руководителя
            .Add("leaderName", GetType(String))             ' руководитель
            .Add("clientName", GetType(String))             ' заказчик экспертизы
            .Add("orderNum", GetType(String))               ' номер заказа
            .Add("orderDate", GetType(Date))                ' дата заказа
            .Add("orderTerm", GetType(Date))                ' срок заказа
            .Add("orderUrl", GetType(String))               ' url заказа
            .Add("description", GetType(String))            ' объекты экспертизы
            .Add("percentComplete", GetType(Integer))       ' готовность
            .Add("isPayment", GetType(Boolean))             ' оплачена (да / нет)
        End With
        ListTable.PrimaryKey = New DataColumn() {ListTable.Columns("id")}
        '
        ' ListGridControl, ListGridView 
        '
        ListGridControl.DataSource = ListTable
        ListGridView.SortInfo.Insert(0, CloseDateGridColumn, DevExpress.Data.ColumnSortOrder.Descending)
        Dim sTmp As String = String.Format("{0}\layoutclosed.xml", Application.StartupPath)
        If My.Computer.FileSystem.FileExists(sTmp) Then ListGridView.RestoreLayoutFromXml(sTmp)
        ListGridView.FindFilterText = Nothing
        '
        ' Data
        '
        DataReload()
        '
        ' TMR
        '
        TMR = Program.Timer
        '
        ' Мои работы
        '
        ListMyBarCheckItem.PerformClick()
        '
        ' Начало периода
        '
        StartDateBarEditItem.EditValue = Date.Today.AddMonths(-1)
    End Sub

    ''' <summary>
    ''' Перечитать список работ
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Public Sub DataReload()
        If StartDateBarEditItem.EditValue Is Nothing Then Exit Sub
        '
        ' Хандлер текущей выделенной в плане строки
        '
        Dim iHandler As Integer = ListGridView.FocusedRowHandle

        Dim sTmp As String = Nothing
        'ListGridView.CloseEditor()
        'ListGridView.BeginDataUpdate()
        '
        ' Данные из базы
        '
        ListTable.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = String.Format( _
                "SELECT * FROM vWorkData WHERE typeId <> 99 AND typeId <> 117 AND conditionId = {0} AND closeDate > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                CInt(Cprp.DxData.Work.WorkCondition.IsClose), _
                CDate(StartDateBarEditItem.EditValue))
            If ListMyBarCheckItem.Checked Then
                Cmd.CommandText = String.Format("{0} AND managerId = {1}", Cmd.CommandText, Program.DbClient.Id)
            End If
            ListTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' Вид услуги
        '
        For Each Row As DataRow In ListTable.Rows
            '
            ' Вид услуги
            '
            Select Case CType(Row("typeId"), Cprp.DxData.Work.WorkType)
                Case Cprp.DxData.Work.WorkType.IsExCont : Row("sId") = "ДН"
                Case Cprp.DxData.Work.WorkType.IsCustomUnion : Row("sId") = "ЗиО"
                Case Cprp.DxData.Work.WorkType.IsTnved : Row("sId") = "Код"
                Case Cprp.DxData.Work.WorkType.IsLiconfirm : Row("sId") = "Контр."
                Case Cprp.DxData.Work.WorkType.IsConsultation : Row("sId") = "Кон."
                Case Cprp.DxData.Work.WorkType.IsMilitary : Row("sId") = "Граж."
                Case Cprp.DxData.Work.WorkType.IsAlteration : Row("sId") = "Измен."
                Case Cprp.DxData.Work.WorkType.IsOrder : Row("sId") = "Заявка"
                Case Cprp.DxData.Work.WorkType.IsLicense : Row("sId") = "Лиценз."
            End Select
        Next
        '
        ' Переход к последней выделенной строке
        '
        'ListGridView.EndDataUpdate()
        ListGridView.MoveFirst()
        Dim iTmp As Integer = 0
        While ListGridView.IsValidRowHandle(iTmp)
            If iTmp = iHandler Then
                ListGridView.FocusedRowHandle = iTmp
                Exit While
            End If
            iTmp += 1
        End While
    End Sub

    ''' <summary>
    ''' Сохранить настройки списка в файл xml
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Public Sub LayoutSave()
        Try
            ListGridView.SaveLayoutToXml(String.Format("{0}\layoutclosed.xml", Application.StartupPath))
        Catch ex As Exception
            Exit Try
        End Try
    End Sub

    ' Перечитать список работ
    Private Sub TMR_Tick(sender As Object, e As EventArgs) Handles TMR.Tick
        DataReload()
    End Sub

    ' Мои работы
    Private Sub ListMyBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListMyBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    ' Все работы
    Private Sub ListAllBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListAllBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    ' Перечитать список работ
    Private Sub ListReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListReloadBarButtonItem.ItemClick
        DataReload()
    End Sub

    ' Перечитать список работ
    Private Sub StartDateBarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles StartDateBarEditItem.EditValueChanged
        DataReload()
    End Sub

    ' Открыть карточку заказа к работе
    Private Sub OrderOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OrderOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = ListGridView.GetFocusedDataRow("orderUrl").ToString
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Отсутствует ссылка на карточку заказа.", String.Format("Работа № {0}", ListGridView.GetFocusedDataRow("id")))
            Exit Sub
        End If
        Try
            Using P As New Process
                P.StartInfo.FileName = sTmp
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        FindButtonEdit.Text = Nothing
    End Sub

    Private Sub FindButtonEdit_TextChanged(sender As Object, e As EventArgs) Handles FindButtonEdit.TextChanged
        ListGridView.FindFilterText = FindButtonEdit.Text
    End Sub

    ' Создать файлы Excel по работе
    Private Sub WorkExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkExcelBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim workId As Integer = C2.ToInt(ListGridView.GetFocusedDataRow("id"))
        '
        ' Проверка наличия файла с данными работы (для старых работ, утвержденных в предыдущей системе)
        '
        If Not My.Computer.FileSystem.FileExists(String.Format("{0}\{1}.work", Program.WorkFolderPath, C2.ToInt(workId))) Then
            Cprp.DxCommon.Messages.ShowWarning("Не найден файл с данными работы.", String.Format("Работа № {0}", workId))
            Exit Sub
        End If

        Dim folderPath As String = Nothing
        Dim filePath As String = Nothing
        '
        ' Выбор папки для сохранения файлов
        '
        Using Dlg As New FolderBrowserDialog
            Dlg.Description = "Укажите место для сохранения файлов"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            folderPath = String.Format("{0}\Работа № {1} (файлы Excel)", Dlg.SelectedPath, C2.ToText(ListGridView.GetFocusedDataRow("id")))
        End Using
        Cprp.DxCommon.WaitForm.Close()
        '
        ' Создание файлов Excel
        '
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim SP As New DevExpress.XtraSpreadsheet.SpreadsheetControl
        Using Ds As New DataSet
            Dim T As New DataTable("ARow")
            With T.Columns
                .Add("id", GetType(Integer))
                .Add("doc1RegNum", GetType(String))
                .Add("doc2RegNum", GetType(String))
            End With
            With T.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Ds.Tables.Add(T)
            T = New DataTable("GoodTable")
            With T.Columns
                .Add("id", GetType(Integer))
                .Add("rowNum", GetType(Integer))
                .Add("nameCon", GetType(String))
                .Add("tnved", GetType(String))
                .Add("description", GetType(String))
                .Add("isDoc1", GetType(Boolean))
            End With
            With T.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Ds.Tables.Add(T)
            Ds.ReadXml(String.Format("{0}\{1}.work", Program.WorkFolderPath, C2.ToInt(workId)), XmlReadMode.IgnoreSchema)
            '
            ' Проверка наличия заключений по работе
            '
            If Ds.Tables("ARow") Is Nothing OrElse Ds.Tables("ARow").Rows.Count = 0 Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowWarning("Работа не содержит данных для выгрузки.", String.Format("Работа № {0}", workId))
                Exit Sub
            End If
            If Ds.Tables("Arow").Columns.IndexOf("doc1RegNum") < 0 OrElse IsDBNull(Ds.Tables("Arow").Rows(0).Item("doc1RegNum")) Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowWarning("Работа не содержит данных для выгрузки.", String.Format("Работа № {0}", workId))
                Exit Sub
            End If
            '
            ' Заключение №1
            '
            If Ds.Tables("Arow").Columns.IndexOf("doc1RegNum") >= 0 AndAlso Not IsDBNull(Ds.Tables("Arow").Rows(0).Item("doc1RegNum")) Then
                SP.BeginUpdate()
                SP.LoadDocument(My.Resources.reportexcel, DevExpress.Spreadsheet.DocumentFormat.Xls)
                Using V As New DataView(Ds.Tables("GoodTable"))
                    V.RowFilter = "isDoc1 = True"
                    V.Sort = "rowNum"
                    For i As Integer = 0 To V.Count - 1
                        SP.Document.Worksheets(0).Cells(i + 4, 1).Value = V(i)("tnved").ToString
                        SP.Document.Worksheets(0).Cells(i + 4, 2).Value = V(i)("nameCon").ToString & " - " & V(i)("description").ToString
                        SP.Document.Worksheets(0).Cells(i + 4, 3).Value = (i + 1).ToString
                    Next
                End Using
                SP.Document.Worksheets(0).Name = C2.ToText(Ds.Tables("Arow").Rows(0).Item("doc1RegNum")).Replace("/", "_")
                SP.EndUpdate()
                filePath = My.Computer.FileSystem.GetTempFileName
                SP.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xls)
                My.Computer.FileSystem.MoveFile(filePath, String.Format("{0}\{1}.xls", folderPath, C2.ToText(Ds.Tables("Arow").Rows(0).Item("doc1RegNum")).Replace("/", "_")), True)
            End If
            '
            ' Заключение №2
            '
            If Ds.Tables("Arow").Columns.IndexOf("doc2RegNum") >= 0 AndAlso Not IsDBNull(Ds.Tables("Arow").Rows(0).Item("doc2RegNum")) Then
                SP.BeginUpdate()
                SP.LoadDocument(My.Resources.reportexcel, DevExpress.Spreadsheet.DocumentFormat.Xls)
                Using V As New DataView(Ds.Tables("GoodTable"))
                    V.RowFilter = "isDoc1 = False"
                    V.Sort = "rowNum"
                    For i As Integer = 0 To V.Count - 1
                        SP.Document.Worksheets(0).Cells(i + 4, 1).Value = V(i)("tnved").ToString
                        SP.Document.Worksheets(0).Cells(i + 4, 2).Value = V(i)("nameCon").ToString & " - " & V(i)("description").ToString
                        SP.Document.Worksheets(0).Cells(i + 4, 3).Value = (i + 1).ToString
                    Next
                End Using
                SP.Document.Worksheets(0).Name = C2.ToText(Ds.Tables("Arow").Rows(0).Item("doc2RegNum")).Replace("/", "_")
                SP.EndUpdate()
                filePath = My.Computer.FileSystem.GetTempFileName
                SP.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xls)
                My.Computer.FileSystem.MoveFile(filePath, String.Format("{0}\{1}.xls", folderPath, C2.ToText(Ds.Tables("Arow").Rows(0).Item("doc2RegNum")).Replace("/", "_")), True)
            End If
            SP.Dispose()
        End Using
        Cprp.DxCommon.WaitForm.Close()
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Файлы Excel созданы в папке {0}. Открыть папку?", folderPath), String.Format("Работа № {0}", workId)) = DialogResult.Yes Then
            Using P As New Process
                P.StartInfo.FileName = "explorer.exe"
                P.StartInfo.Arguments = folderPath
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        End If
        'Cprp.DxCommon.Messages.ShowInformation(String.Format("Файлы Excel созданы в папке {0}", folderPath), String.Format("Работа № {0}", workId))
    End Sub

    ' Создать консультацию по определению кода ТН ВЭД
    Private Sub WorkConsTnvedBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkConsTnvedBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Program.CreateConsTnved(CInt(ListGridView.GetFocusedDataRow("id")))
    End Sub

    ' Открыть историю работы
    Private Sub WorkHistoryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkHistoryBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        With New WorkHistoryForm(ListGridView.GetFocusedDataRow("id"))
            .ShowDialog()
        End With
    End Sub

    ' Пересчитать стоимость работы по договору 05/1134 (АСЭ)
    Private Sub CalcAseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CalcAseBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Program.CalcAse(ListGridView.GetFocusedDataRow)
    End Sub

    ' Пересчитать стоимость работы по договору 01/22/128 (ГСПИ)
    Private Sub GspiBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GspiBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Program.CalcGspi(ListGridView.GetFocusedDataRow)
    End Sub

End Class
