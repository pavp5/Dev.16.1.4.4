Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Результаты поиска"
''' </summary>
Friend Class ResultUserControl

    ''' <summary>
    ''' Открыть работу
    ''' </summary>
    ''' <param name="id">ID работы в архивной базе</param>
    ''' <param name="workId">ID работы в EXDB8</param>
    Friend Event WorkOpen(id As Integer, workId As Integer)

    ''' <summary>
    ''' Таблица заключений
    ''' </summary>
    Private OutDocTable As OutDocDataTable = Nothing

    ''' <summary>
    ''' Таблица объектов экспертизы
    ''' </summary>
    Private GoodTable As GoodDataTable = Nothing

    ''' <summary>
    ''' Таблица входящих документов
    ''' </summary>
    Private InDocTable As InDocDataTable = Nothing

    ''' <summary>
    ''' Открытое соединение с базой данных
    ''' </summary>
    Private Connection As SqlConnection = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        Me.Connection = Connection
        OutDocTable = New OutDocDataTable
        GoodTable = New GoodDataTable
        InDocTable = New InDocDataTable
        OutDocGridControl.DataSource = OutDocTable
        Try
            Dim sTmp As String = String.Format("{0}\findaresultlayout.xml", My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments))
            If My.Computer.FileSystem.FileExists(sTmp) Then
                OutDocGridView.RestoreLayoutFromXml(sTmp)
                OutDocGridView.ClearColumnsFilter()
            End If
        Catch ex As Exception
            Exit Try
        End Try
        GoodGridControl.DataSource = GoodTable.WorkView
        InDocGridControl.DataSource = InDocTable.WorkView
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
        N = FieldTreeList.FindNodeByKeyID("workId")
        If Not N Is Nothing Then N.Checked = WorkIdOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("description")
        If Not N Is Nothing Then N.Checked = DescriptionOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("typeName")
        If Not N Is Nothing Then N.Checked = TypeNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("kindName")
        If Not N Is Nothing Then N.Checked = KindNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("expertName")
        If Not N Is Nothing Then N.Checked = ExpertNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("leaderName")
        If Not N Is Nothing Then N.Checked = LeaderNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("managerName")
        If Not N Is Nothing Then N.Checked = ManagerNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("clientName")
        If Not N Is Nothing Then N.Checked = ClientNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("clientAddress")
        If Not N Is Nothing Then N.Checked = ClientAddressOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("clientInn")
        If Not N Is Nothing Then N.Checked = ClientInnOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("clientKpp")
        If Not N Is Nothing Then N.Checked = ClientKppOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("clientPhone")
        If Not N Is Nothing Then N.Checked = ClientPhoneOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("clientFax")
        If Not N Is Nothing Then N.Checked = ClientFaxOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("orderNum")
        If Not N Is Nothing Then N.Checked = OrderNumOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("orderDate")
        If Not N Is Nothing Then N.Checked = OrderDateOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("countryName")
        If Not N Is Nothing Then N.Checked = CountryNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("contractName")
        If Not N Is Nothing Then N.Checked = ContractNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("contractNum")
        If Not N Is Nothing Then N.Checked = ContractNumOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("contractDate")
        If Not N Is Nothing Then N.Checked = ContractDateOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("rusName")
        If Not N Is Nothing Then N.Checked = RusNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("rusAddress")
        If Not N Is Nothing Then N.Checked = RusAddressOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("rusInn")
        If Not N Is Nothing Then N.Checked = RusInnOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("rusKpp")
        If Not N Is Nothing Then N.Checked = RusKppOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("nusName")
        If Not N Is Nothing Then N.Checked = NusNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("nusCountry")
        If Not N Is Nothing Then N.Checked = NusCountryOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("nusAddress")
        If Not N Is Nothing Then N.Checked = NusAddressOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("endName")
        If Not N Is Nothing Then N.Checked = EndNameOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("endCountry")
        If Not N Is Nothing Then N.Checked = EndCountryOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("endAddress")
        If Not N Is Nothing Then N.Checked = EndAddressOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("docNum")
        If Not N Is Nothing Then N.Checked = DocNumOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("docDate")
        If Not N Is Nothing Then N.Checked = DocDateOutDocGridColumn.Visible
        N = FieldTreeList.FindNodeByKeyID("docSummaryName")
        If Not N Is Nothing Then N.Checked = DocSummaryNameOutDocGridColumn.Visible
        FieldTreeListColumn.Visible = False
        FieldTreeList.ExpandAll()
    End Sub


    ''' <summary>
    ''' Начать поиск в базе данных
    ''' </summary>
    ''' <param name="queryString">Строка запроса на выборку данных</param>
    Friend Sub SetFind(queryString As String)
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        OutDocGridControl.BeginUpdate()
        GoodGridControl.BeginUpdate()
        InDocGridView.BeginUpdate()
        Try
            InDocTable.Rows.Clear()
            GoodTable.Rows.Clear()
            OutDocTable.Rows.Clear()
            Using Cmd As New SqlCommand With {.Connection = Connection, .CommandText = queryString}
                OutDocTable.Load(Cmd.ExecuteReader)
                Dim sTmp As String = "0"
                For i As Integer = 0 To OutDocTable.Rows.Count - 1
                    sTmp = String.Format("{0}, {1}", sTmp, CInt(OutDocTable(i)("id")))
                Next
                Cmd.CommandText = String.Format("{0} WHERE workId IN ({1})", GoodDataTable.SELECT_QUERY_STRING, sTmp)
                GoodTable.Load(Cmd.ExecuteReader)
                Cmd.CommandText = String.Format("{0} WHERE workId IN ({1})", InDocDataTable.SELECT_QUERY_STRING, sTmp)
                InDocTable.Load(Cmd.ExecuteReader)
            End Using
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполения операции:{0}{1}", vbCrLf, ex.Message), "Поиск работ")
        Finally
            OutDocGridControl.EndUpdate()
            GoodGridControl.EndUpdate()
            InDocGridView.EndUpdate()
            OutDocGridView.MoveFirst()
            OutDocGridView_FocusedRowChanged(Nothing, Nothing)
            CaptionSimpleLabelItem.Text = String.Format("Поиск работ > Результаты поиска ({0})", OutDocTable.Rows.Count)
        End Try
    End Sub

    Private Sub OutDocGridView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles OutDocGridView.FocusedRowChanged
        Dim iTmp As Integer = -1
        If OutDocGridView.FocusedRowHandle >= 0 Then iTmp = CInt(OutDocGridView.GetFocusedDataRow("id"))
        GoodGridView.BeginDataUpdate()
        GoodTable.WorkId = iTmp
        GoodGridView.EndDataUpdate()
        GoodLayoutControlGroup.Text = String.Format("Объекты экспертизы ({0})", GoodTable.WorkView.Count)
        InDocGridView.BeginDataUpdate()
        InDocTable.WorkId = iTmp
        InDocGridView.EndDataUpdate()
        DocLayoutControlGroup.Text = String.Format("Представленные документы ({0})", InDocTable.WorkView.Count)
    End Sub

    ' Открыть работу / сведения о работе
    Private Sub WorkOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkOpenBarButtonItem.ItemClick
        If OutDocGridView.FocusedRowHandle >= 0 Then
            With OutDocGridView.GetFocusedDataRow
                RaiseEvent WorkOpen(CInt(.Item("id")), CInt(.Item("workId")))
            End With
        End If
    End Sub

    Private Sub OutDocGridControl_DoubleClick(sender As Object, e As EventArgs) Handles OutDocGridControl.DoubleClick
        WorkOpenBarButtonItem.PerformClick()
    End Sub

    ' Открыть карточку заказа к работе
    Private Sub OrderOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OrderOpenBarButtonItem.ItemClick
        If OutDocGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = C2.ToText(OutDocGridView.GetFocusedDataRow("orderUrl"))
        If Not C2.IsText(sTmp) Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует ссылка на карточку заказа.", "Поиск работ")
        Else
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
        End If
    End Sub

    ' Экспорт списка в Microsoft Excel
    Private Sub ExcelExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExcelExportBarButtonItem.ItemClick
        If OutDocGridView.RowCount = 0 Then Exit Sub
        Try
            Dim filePath As String = Nothing
            Using Dlg As New SaveFileDialog
                Dlg.Title = "Выбор файла для сохранения данных"
                Dlg.FileName = "Результаты поиска"
                Dlg.DefaultExt = "xlsx"
                Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
                If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                filePath = Dlg.FileName
            End Using
            OutDocGridView.ExportToXlsx(filePath)
            Using P As New Process
                P.StartInfo.FileName = filePath
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), "Поиск работ")
        End Try
    End Sub

    ' Открыть форму сведений об объекте экспертизы
    Private Sub GoodRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles GoodRepositoryItemButtonEdit.ButtonClick
        If GoodGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim iTmp As Integer = CInt(GoodGridView.GetFocusedDataRow("id"))
        For Each F As Form In Application.OpenForms
            If Not TypeOf F Is GoodForm Then Continue For
            If CType(F, GoodForm).GoodId = iTmp Then
                F.WindowState = FormWindowState.Normal
                F.TopMost = True
                F.TopMost = False
                Exit Sub
            End If
        Next
        With New GoodForm(GoodGridView.GetFocusedDataRow)
            .Show(Me.ParentForm)
        End With
    End Sub

    Private Sub GoodGridControl_DoubleClick(sender As Object, e As EventArgs) Handles GoodGridControl.DoubleClick
        GoodRepositoryItemButtonEdit_ButtonClick(Nothing, Nothing)
    End Sub

    Private Sub GoodRepositoryItemButtonEdit_DoubleClick(sender As Object, e As EventArgs) Handles GoodRepositoryItemButtonEdit.DoubleClick
        GoodRepositoryItemButtonEdit_ButtonClick(Nothing, Nothing)
    End Sub

    ' Открыть карточку представленного документа
    Private Sub InDocRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles InDocRepositoryItemButtonEdit.ButtonClick
        If InDocGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = C2.ToText(InDocGridView.GetFocusedDataRow("docUrl"))
        If Not C2.IsText(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Ссылка на карточку документа отсутствует.", "Поиск работ")
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

    Private Sub InDocGridControl_DoubleClick(sender As Object, e As EventArgs) Handles InDocGridControl.DoubleClick
        InDocRepositoryItemButtonEdit_ButtonClick(Nothing, Nothing)
    End Sub

    Private Sub InDocRepositoryItemButtonEdit_DoubleClick(sender As Object, e As EventArgs) Handles InDocRepositoryItemButtonEdit.DoubleClick
        InDocRepositoryItemButtonEdit_ButtonClick(Nothing, Nothing)
    End Sub

    Private Sub FieldTreeList_BeforeCheckNode(sender As Object, e As DevExpress.XtraTreeList.CheckNodeEventArgs) Handles FieldTreeList.BeforeCheckNode
        e.CanCheck = (e.Node.Nodes.Count = 0)
    End Sub

    Private Sub FieldTreeList_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles FieldTreeList.AfterCheckNode
        SetColumnVisible(e.Node.GetValue("field").ToString, e.Node.Checked)
    End Sub

    ''' <summary>
    ''' Показать / скрыть поле результатов поиска
    ''' </summary>
    ''' <param name="fieldName">Имя поля</param>
    Private Sub SetColumnVisible(fieldName As String, isVisble As Boolean)
        Select Case fieldName.ToUpper
            Case "WORKID" : WorkIdOutDocGridColumn.Visible = isVisble : Exit Select
            Case "DESCRIPTION" : DescriptionOutDocGridColumn.Visible = isVisble : Exit Select
            Case "TYPENAME" : TypeNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "KINDNAME" : KindNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "EXPERTNAME" : ExpertNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "LEADERNAME" : LeaderNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "MANAGERNAME" : ManagerNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "ORDERNUM" : OrderNumOutDocGridColumn.Visible = isVisble : Exit Select
            Case "ORDERDATE" : OrderDateOutDocGridColumn.Visible = isVisble : Exit Select
            Case "CLIENTNAME" : ClientNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "CLIENTADDRESS" : ClientAddressOutDocGridColumn.Visible = isVisble : Exit Select
            Case "CLIENTINN" : ClientInnOutDocGridColumn.Visible = isVisble : Exit Select
            Case "CLIENTKPP" : ClientKppOutDocGridColumn.Visible = isVisble : Exit Select
            Case "CLIENTPHONE" : ClientPhoneOutDocGridColumn.Visible = isVisble : Exit Select
            Case "CLIENTFAX" : ClientFaxOutDocGridColumn.Visible = isVisble : Exit Select
            Case "ORDERNUM" : OrderNumOutDocGridColumn.Visible = isVisble : Exit Select
            Case "ORDERDATE" : OrderDateOutDocGridColumn.Visible = isVisble : Exit Select
            Case "COUNTRYNAME" : CountryNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "CONTRACTNAME" : ContractNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "CONTRACTNUM" : ContractNumOutDocGridColumn.Visible = isVisble : Exit Select
            Case "CONTRACTDATE" : ContractDateOutDocGridColumn.Visible = isVisble : Exit Select
            Case "RUSNAME" : RusNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "RUSADDRESS" : RusAddressOutDocGridColumn.Visible = isVisble : Exit Select
            Case "RUSINN" : RusInnOutDocGridColumn.Visible = isVisble : Exit Select
            Case "RUSKPP" : RusKppOutDocGridColumn.Visible = isVisble : Exit Select
            Case "NUSNAME" : NusNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "NUSCOUNTRY" : NusCountryOutDocGridColumn.Visible = isVisble : Exit Select
            Case "NUSADDRESS" : NusAddressOutDocGridColumn.Visible = isVisble : Exit Select
            Case "ENDNAME" : EndNameOutDocGridColumn.Visible = isVisble : Exit Select
            Case "ENDCOUNTRY" : EndCountryOutDocGridColumn.Visible = isVisble : Exit Select
            Case "ENDADDRESS" : EndAddressOutDocGridColumn.Visible = isVisble : Exit Select
            Case "DOCNUM" : DocNumOutDocGridColumn.Visible = isVisble : Exit Select
            Case "DOCDATE" : DocDateOutDocGridColumn.Visible = isVisble : Exit Select
            Case "DOCSUMMARYNAME" : DocSummaryNameOutDocGridColumn.Visible = isVisble : Exit Select
        End Select
    End Sub

    Private Sub FieldTreeList_BeforeCollapse(sender As Object, e As DevExpress.XtraTreeList.BeforeCollapseEventArgs) Handles FieldTreeList.BeforeCollapse
        e.CanCollapse = False
    End Sub

    Private Sub OutDocGridView_Layout(sender As Object, e As EventArgs) Handles OutDocGridView.Layout
        Dim sTmp As String = String.Format("{0}\findaresultlayout.xml", My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments))
        Try
            OutDocGridView.SaveLayoutToXml(sTmp)
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub OutDocGridView_RowCountChanged(sender As Object, e As EventArgs) Handles OutDocGridView.RowCountChanged
        CaptionSimpleLabelItem.Text = String.Format("Поиск работ > Результаты поиска ({0})", OutDocGridView.RowCount)
    End Sub

End Class
