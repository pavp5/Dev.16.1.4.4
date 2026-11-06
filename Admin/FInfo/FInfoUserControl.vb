Imports Excel = Microsoft.Office.Interop.Excel
Imports Cprp.DxData.Common
''' <summary>
''' Элемент управления для редактирования информации из ФСТЭК по контролируемым заключениям
''' </summary>
Public Class FInfoUserControl

    ''' <summary>
    ''' Таблица информации по контролируемым заключениям
    ''' </summary>
    Private FInfoTable As FInfoDataTable = Nothing

    ''' <summary>
    ''' Таблица экспертных организаций
    ''' </summary>
    Private ExpertOrgTable As ExpertOrgDataTable = Nothing

    ''' <summary>
    ''' Справочник стран мира
    ''' </summary>
    Private CountryTable As CountryDataTable = Nothing

    ''' <summary>
    ''' Справочник выводов экспертизы
    ''' </summary>
    Private SummaryTable As SummaryDataTable = Nothing

    Private OrgView As DataView = Nothing
    Private CountryView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Data
        '
        FInfoTable = New FInfoDataTable(Connection)
        ExpertOrgTable = New ExpertOrgDataTable(Connection)
        ExpertOrgTable.DataReload()
        CountryTable = New CountryDataTable
        CountryTable.DataReload(Connection)
        SummaryTable = New SummaryDataTable
        OrgView = New DataView(ExpertOrgTable)
        CountryView = New DataView(CountryTable)
        '
        ' QueryComboBoxEdit 
        '
        QueryComboBoxEdit.Text = "SELECT * FROM tFInfo WHERE id > 0"
        '
        ' InfoGridControl, InfoGridView
        '
        ExpertOrgRepositoryItemLookUpEdit.DataSource = ExpertOrgTable
        CountryRepositoryItemLookUpEdit.DataSource = CountryTable
        SummaryRepositoryItemLookUpEdit.DataSource = SummaryTable
        InfoGridControl.DataSource = FInfoTable
        InfoGridView.SortInfo.Insert(0, DocNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        InfoGridView.SortInfo.Insert(1, IdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

    End Sub


    Private Sub QueryComboBoxEdit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles QueryComboBoxEdit.GotFocus
        QueryComboBoxEdit.DeselectAll()
    End Sub

    ' Выполнение запроса к базе
    Private Sub QueryComboBoxEdit_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles QueryComboBoxEdit.ButtonClick
        If e.Button.Index = 0 Then Exit Sub
        Dim sTmp As String = Trim(QueryComboBoxEdit.Text)
        If String.IsNullOrWhiteSpace(sTmp) Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        InfoGridView.CloseEditor()
        InfoGridView.UpdateCurrentRow()
        InfoGridView.BeginDataUpdate()
        Try
            ' Выполнение запроса
            If sTmp.ToUpper Like "SELECT *" AndAlso Not sTmp.ToUpper Like "SELECT*COUNT*" Then
                FInfoTable.Rows.Clear()
                FInfoTable.Load(sTmp)
            Else
                FInfoTable.ExecuteNonQuery(sTmp)
            End If
            ' Добавление строки запроса к списку запросов
            Dim bTmp As Boolean = True
            For i As Integer = 0 To QueryComboBoxEdit.Properties.Items.Count - 1
                If QueryComboBoxEdit.Properties.Items(i).ToString.ToUpper Like sTmp.ToUpper Then
                    bTmp = False
                    Exit For
                End If
            Next
            If bTmp Then QueryComboBoxEdit.Properties.Items.Add(sTmp)
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            InfoGridView.EndDataUpdate()
            InfoGridView.MoveFirst()
        End Try
    End Sub

    ' Выровнять высоту строк по содержимому
    Private Sub ViewHeightBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ViewHeightBarButtonItem.ItemClick
        If ViewHeightBarButtonItem.Down Then
            DocNumGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            ConNumGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            RusCaptionGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            RusInnGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            NusCaptionGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            EndCaptionGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            CountryNameGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            GoodNameGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            GoodTnvedGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            GoodListPosGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            SummaryGridColumn.ColumnEdit = RepositoryItemMemoEdit1
            InfoGridView.OptionsView.RowAutoHeight = True
        Else
            DocNumGridColumn.ColumnEdit = Nothing
            ConNumGridColumn.ColumnEdit = Nothing
            RusCaptionGridColumn.ColumnEdit = Nothing
            RusInnGridColumn.ColumnEdit = Nothing
            NusCaptionGridColumn.ColumnEdit = Nothing
            EndCaptionGridColumn.ColumnEdit = Nothing
            CountryNameGridColumn.ColumnEdit = Nothing
            GoodNameGridColumn.ColumnEdit = Nothing
            GoodTnvedGridColumn.ColumnEdit = Nothing
            GoodListPosGridColumn.ColumnEdit = Nothing
            SummaryGridColumn.ColumnEdit = Nothing
            InfoGridView.OptionsView.RowAutoHeight = False
        End If
    End Sub

    ' Загрузить данные из файла Excel
    Private Sub DataLoadExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLoadExcelBarButtonItem.ItemClick
        'Using T As New ContactDataTable
        '    T.LoadFromExcel()
        '    T.WriteXml("d:\contact.xml")
        '    MsgBox(String.Format("Загружено строк: {0}", T.Rows.Count))
        'End Using
        'Exit Sub

        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Dim Row As DataRow = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.Filter = "Файл Microsoft Excel (*.xlsx;*.xls)|*.xlsx;*.xls"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Dim EApp As Excel.Application = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        InfoGridView.CloseEditor()
        InfoGridView.UpdateCurrentRow()
        InfoGridView.BeginDataUpdate()
        Try
            '
            ' Загрузка данных
            '
            EApp = New Excel.Application
            EApp.Visible = False
            EApp.Workbooks.Open(sTmp)
            FInfoTable.Rows.Clear()
            iTmp = 6    ' первая строка с данными заключений
            With EApp.Workbooks(1).Worksheets(1)
                Do
                    sTmp = ToText(.Cells(iTmp, 2).Value)
                    If String.IsNullOrWhiteSpace(sTmp) Then Exit Do
                    Row = FInfoTable.NewRow
                    Row("docNum") = DbText(.Cells(iTmp, 2).Value)
                    Row("docDate") = DbDate(.Cells(iTmp, 3).Value)
                    Row("conNum") = DbText(.Cells(iTmp, 4).Value)
                    Row("conDate") = DbDate(.Cells(iTmp, 5).Value)
                    Row("rusCaption") = DbText(.Cells(iTmp, 6).Value)
                    Row("rusInn") = DbText(.Cells(iTmp, 7).Value)
                    Row("nusCaption") = DbText(.Cells(iTmp, 8).Value)
                    Row("endCaption") = DbText(.Cells(iTmp, 9).Value)
                    Row("countryName") = DbText(.Cells(iTmp, 10).Value)
                    Row("goodName") = DbText(.Cells(iTmp, 11).Value)
                    Row("goodNameFind") = DbText(ToABC(Row("goodName").ToString))
                    Row("goodTnved") = DbText(.Cells(iTmp, 12).Value)
                    Row("goodListPos") = DbText(.Cells(iTmp, 13).Value)
                    Row("summary") = DbText(.Cells(iTmp, 14).Value)
                    FInfoTable.Rows.Add(Row)
                    iTmp += 1
                Loop
            End With
            EApp.Quit()
            EApp = Nothing
            '
            ' Обработка данных
            '
            For Each Row In FInfoTable.Rows
                ' orgId
                sTmp = ToText(Row("docNum"))
                If Not String.IsNullOrWhiteSpace(sTmp) Then
                    iTmp = sTmp.IndexOf("/")
                    If iTmp > 0 AndAlso (iTmp + 1) < sTmp.Length Then
                        sTmp = sTmp.Substring(iTmp + 1)
                        OrgView.RowFilter = String.Format("inn = '{0}'", sTmp)
                        If OrgView.Count > 0 Then Row("orgId") = OrgView(0)("id")
                    End If
                End If
                ' countryId
                sTmp = ToText(Row("countryName"))
                If Not String.IsNullOrWhiteSpace(sTmp) Then
                    CountryView.RowFilter = String.Format("name LIKE '%{0}%'", sTmp)
                    If CountryView.Count > 0 Then Row("countryId") = CountryView(0)("id")
                End If
                ' nusCountryId
                sTmp = ToText(Row("nusCaption"))
                If Not String.IsNullOrWhiteSpace(sTmp) Then
                    sTmp = sTmp.ToUpper
                    For Each Row1 As DataRow In CountryTable.Rows
                        If sTmp Like String.Format("*{0}*", Row1("nameShort").ToString.ToUpper) Then
                            Row("nusCountryId") = Row1("id")
                            Exit For
                        End If
                    Next
                End If
                ' endCountryId
                sTmp = ToText(Row("endCaption"))
                If Not String.IsNullOrWhiteSpace(sTmp) Then
                    sTmp = sTmp.ToUpper
                    For Each Row1 As DataRow In CountryTable.Rows
                        If sTmp Like String.Format("*{0}*", Row1("nameShort").ToString.ToUpper) Then
                            Row("endCountryId") = Row1("id")
                            Exit For
                        End If
                    Next
                End If
                ' summaryId
                sTmp = ToText(Row("summary"))
                If Not String.IsNullOrWhiteSpace(sTmp) Then
                    sTmp = sTmp.ToUpper
                    If sTmp Like "*ЛИЦЕНЗИЯ*" Then
                        Row("summaryId") = 2
                    ElseIf sTmp Like "*РАЗРЕШЕНИЕ*" Then
                        Row("summaryId") = 3
                    End If
                End If
            Next
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            InfoGridView.EndDataUpdate()
            If Not EApp Is Nothing Then
                EApp.Quit()
                EApp = Nothing
            End If
        End Try
    End Sub

    ' Сохранить данные в базу
    Private Sub DataSaveBaseBarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveBaseBarButtonItem1.ItemClick
        InfoGridView.CloseEditor()
        InfoGridView.UpdateCurrentRow()
        '
        ' Проверка данных на наличие ошибок
        '
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        For Each Row As DataRow In FInfoTable.Rows
            If Row.RowState = DataRowState.Deleted Then Continue For
            iTmp = CInt(Row("id"))
            sTmp = ToText(Row("docNum"))
            If String.IsNullOrWhiteSpace(sTmp) Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Не заполнено поле docNum.", iTmp))
                Exit Sub
            End If
            If sTmp.Length > 30 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле docNum превышает 30 символов.", iTmp))
                Exit Sub
            End If
            sTmp = ToText(Row("conNum"))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 150 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле conNum превышает 150 символов.", iTmp))
                Exit Sub
            End If
            sTmp = ToText(Row("rusCaption"))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 300 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле rusCaption превышает 300 символов.", iTmp))
                Exit Sub
            End If
            sTmp = ToText(Row("rusInn"))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 12 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле rusInn превышает 12 символов.", iTmp))
                Exit Sub
            End If
            sTmp = ToText(Row("nusCaption"))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 300 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле nusCaption превышает 300 символов.", iTmp))
                Exit Sub
            End If
            sTmp = ToText(Row("endCaption"))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 300 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле endCaption превышает 300 символов.", iTmp))
                Exit Sub
            End If
            sTmp = ToText(Row("goodName"))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 500 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле goodName превышает 500 символов.", iTmp))
                Exit Sub
            End If
            sTmp = ToText(Row("goodTnved"))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 14 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле goodTnved превышает 14 символов.", iTmp))
                Exit Sub
            End If
            sTmp = ToText(Row("goodListPos"))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 300 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле goodListPos превышает 300 символов.", iTmp))
                Exit Sub
            End If
            sTmp = ToText(Row("summary"))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 300 Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Строка ID = {0}: Значение в поле summary превышает 300 символов.", iTmp))
                Exit Sub
            End If
        Next
        '
        ' Сохранение данных
        '
        Try
            FInfoTable.SaveToBase()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.")
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try

    End Sub

    ' Добавить новую строку
    Private Sub RowAddBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RowAddBarButtonItem.ItemClick
        Dim Row As DataRow = FInfoTable.NewRow
        If InfoGridView.FocusedRowHandle >= 0 Then
            Dim Row1 As DataRow = InfoGridView.GetFocusedDataRow
            For Each Col As DataColumn In FInfoTable.Columns
                If Col.ColumnName = "id" Then Continue For
                Row(Col.ColumnName) = Row1(Col.ColumnName)
            Next
        End If
        FInfoTable.Rows.Add(Row)
    End Sub

    ' Добавить новую организацию
    Private Sub ExpertOrgRepositoryItemLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ExpertOrgRepositoryItemLookUpEdit.ButtonClick
        Dim Row As DataRow = ExpertOrgTable.NewRow
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        If InfoGridView.FocusedRowHandle > 0 Then
            sTmp = ToText(InfoGridView.GetFocusedDataRow("docNum"))
            If Not String.IsNullOrWhiteSpace(sTmp) Then
                iTmp = sTmp.LastIndexOf("/")
                If iTmp > 0 AndAlso (iTmp + 1) < sTmp.Length Then
                    Row("inn") = sTmp.Substring(iTmp + 1)
                End If
            End If
        End If
        Using F As New ExpertOrgForm(Row)
            If F.ShowDialog <> DialogResult.OK Then Exit Sub
        End Using
        ExpertOrgTable.Rows.Add(Row)
        Try
            ExpertOrgTable.SaveToBase()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
            Exit Sub
        End Try
        ' обновления поля orgId в полях строк таблицы FInfoTable 
        Using V As New DataView(FInfoTable) With {.RowFilter = String.Format("docNum LIKE '%/{0}'", ToText(Row("inn")))}
            For Each VRow As DataRowView In V
                If IsDBNull(VRow("orgId")) Then VRow("orgId") = Row("id")
            Next
        End Using
    End Sub

    ' Копировать id стран из верхней строки
    Private Sub CountryRepositoryItemLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles CountryRepositoryItemLookUpEdit.ButtonClick
        If e.Button.Index <> 1 Then Exit Sub
        If InfoGridView.FocusedRowHandle < 1 Then Exit Sub
        Dim iTmp As Integer = InfoGridView.FocusedRowHandle - 1
        Dim Row As DataRow = InfoGridView.GetDataRow(iTmp)
        If Row Is Nothing Then Exit Sub
        Dim Row1 As DataRow = InfoGridView.GetFocusedDataRow
        InfoGridView.CloseEditor()
        InfoGridView.UpdateCurrentRow()
        InfoGridView.BeginDataUpdate()
        Row1("countryId") = Row("countryId")
        Row1("nusCountryId") = Row("nusCountryId")
        Row1("endCountryId") = Row("endCountryId")
        InfoGridView.EndDataUpdate()
    End Sub

End Class
