''' <summary>
''' Элемент управления "Условия поиска"
''' </summary>
Friend Class ConditionUserControl

    ''' <summary>
    ''' Начать поиск
    ''' </summary>
    ''' <param name="queryString">Строка запроса на выборку данных</param>
    Friend Event FindStart(queryString As String)

    ''' <summary>
    ''' Таблица-строка условий поиска
    ''' </summary>
    Private ConditionRow As ConditionDataRow = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных</param>
    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Таблица-строка условий поиска
        '
        ConditionRow = New ConditionDataRow
        '
        ' Справочники
        '
        UnionRepositoryItemLookUpEdit.DataSource = New UnionDataTable
        WorkTypeRepositoryItemLookUpEdit.DataSource = New WorkTypeDataTable(Connection)
        WorkKindRepositoryItemLookUpEdit.DataSource = New WorkKindDataTable(Connection)
        WorkExpertRepositoryItemLookUpEdit.DataSource = New WorkExpertDataTable(Connection)
        WorkManagerRepositoryItemLookUpEdit.DataSource = New WorkManagerDataTable(Connection)
        WorkLeaderRepositoryItemLookUpEdit.DataSource = New WorkLeaderDataTable(Connection)
        WorkSummaryRepositoryItemLookUpEdit.DataSource = New WorkSummaryDataTable(Connection)
        ModeRepositoryItemLookUpEdit.DataSource = New ModeDataTable
        CountryRepositoryItemLookUpEdit.DataSource = New CountryDataTable(Connection)
        NusCountryRepositoryItemLookUpEdit.DataSource = New CountryDataTable(Connection)
        GoodCategoryRepositoryItemLookUpEdit.DataSource = New GoodCategoryDataTable(Connection)
        GoodStudySummaryRepositoryItemLookUpEdit.DataSource = New GoodStudySummaryDataTable(Connection)
        '
        ' ConditionGridControl
        '
        ConditionGridControl.DataSource = ConditionRow
    End Sub


    ' Поиск
    Private Sub FindStartBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        ConditionGridControl.CloseEditor()
        ConditionGridControl.UpdateFocusedRecord()
        Dim sTmp As String = ConditionRow.GetQuery
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите критерии поиска!", "Поиск работ")
            Exit Sub
        End If
        RaiseEvent FindStart(sTmp)
    End Sub

    ' Очистить критерии поиска
    Private Sub FindClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ClearBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Очистить критерии поиска?", "Поиск работ") <> DialogResult.Yes Then Exit Sub
        ConditionGridControl.BeginUpdate()
        ConditionRow.DataClear()
        ConditionGridControl.EndDataUpdate()
    End Sub

End Class
