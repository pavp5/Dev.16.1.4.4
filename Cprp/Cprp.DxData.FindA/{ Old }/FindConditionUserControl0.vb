''' <summary>
''' Критерии поиска
''' </summary>
''' <remarks></remarks>
Friend Class FindConditionUserControl0

    ''' <summary>
    ''' Начать поиск
    ''' </summary>
    ''' <param name="QueryString">Строка запроса на выборку данных</param>
    ''' <remarks></remarks>
    Friend Event FindStart(QueryString As String)

    ' Таблица-строка критериев поиска
    Private FindConditionRow As FindConditionDataRow = Nothing

    Private Const APP_NAME As String = "Поиск"


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">>Открытое соединение с архивной базой данных</param>
    ''' <remarks></remarks>
    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Таблица-строка критериев поиска
        '
        FindConditionRow = New FindConditionDataRow
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
        ' FindGridControl
        '
        FindGridControl.DataSource = FindConditionRow

    End Sub

    ' Поиск
    Private Sub FindStartBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindStartBarButtonItem.ItemClick
        FindGridControl.CloseEditor()
        Dim sTmp As String = FindConditionRow.GetQuery
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите критерии поиска!", APP_NAME)
            Exit Sub
        End If
        RaiseEvent FindStart(sTmp)
    End Sub

    ' Очистить критерии поиска
    Private Sub FindClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindClearBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Очистить критерии поиска?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        FindGridControl.BeginUpdate()
        FindConditionRow.DataClear()
        FindGridControl.EndDataUpdate()
    End Sub

End Class
