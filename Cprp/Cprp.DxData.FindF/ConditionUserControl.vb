Imports C2 = Cprp.DxData.Common
''' <summary>
''' Критерии поиска
''' </summary>
''' <remarks></remarks>
Friend Class ConditionUserControl

#Region "Данные"

    ''' <summary>
    ''' Таблица-строка критериев поиска
    ''' </summary>
    ''' <remarks></remarks>
    Private Class ConditionDataRow : Inherits Cprp.DxData.Base.BaseDataRow

        Friend Sub New()
            MyBase.New()
            With Me.Columns
                .Add("id", GetType(Integer))                    ' Первичный ключ
                .Add("unionId", GetType(Integer))               ' Идентификатор условия объединения критериев поиска
                .Add("orgId", GetType(Integer))                 ' Экспертная организация
                .Add("docNum", GetType(String))                 ' Номер заключения
                .Add("docDateB", GetType(Date))                 ' Дата заключения (от)
                .Add("docDateE", GetType(Date))                 ' Дата заключения (до)
                .Add("countryName", GetType(String))            ' Страна назначения (отправления)
                .Add("conNum", GetType(String))                 ' Номер контракта
                .Add("conDateB", GetType(Date))                 ' Дата контракта (от)
                .Add("conDateE", GetType(Date))                 ' Дата контракта (до)
                .Add("rusCaption", GetType(String))             ' Российский участник операции
                .Add("rusInn", GetType(String))                 ' ИНН российского участника
                .Add("nusCaption", GetType(String))             ' Иностранный покупатель (продавец)
                .Add("endCaption", GetType(String))             ' Потребитель (конечный пользователь)
                .Add("goodName", GetType(String))               ' Наименование объекта экспертизы
                .Add("goodTnved", GetType(String))              ' Код ТН ВЭД объекта экспертизы
                .Add("goodDescription", GetType(String))        ' Техническое описание
                .Add("goodEqualId", GetType(Integer))           ' Соответствует КС (да = 1 / нет = 0)
                .Add("goodList", GetType(String))               ' Обозначения контрольных списков
                .Add("goodPos", GetType(String))                ' Номера пунктов контрольных списков
                .Add("goodSummary", GetType(String))            ' Дополнительная информация
            End With
            With Me.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            With Me.Columns("unionId")
                .AllowDBNull = False
                .DefaultValue = 1                               ' <И>
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
            DataClear()
        End Sub

        ''' <summary>
        ''' Очистить критерии поиска от всех данных
        ''' </summary>
        ''' <remarks></remarks>
        Public Sub DataClear()
            Me.Rows.Clear()
            Me.Rows.Add(Me.NewRow)
        End Sub

        ''' <summary>
        ''' Строка запроса на выборку данных из vDocOrg
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public ReadOnly Property GetQuery As String
            Get
                If Me.IsEmpty Then Return Nothing
                'C2.UpdateEmptyStringFields(Me)
                Dim sTmp As String, dTmp As Date, dTmp1 As Date
                '
                ' Возвращаемое значение
                '
                Dim GetStr As String = Nothing
                '
                ' Условие объединения критериев поиска
                '
                Dim UN As String = Chr(1)
                '
                ' Подзапрос на выборку данных из tDoc
                '
                sTmp = Nothing
                If Not IsDBNull(Me("orgId")) Then sTmp = String.Format("{0} orgId = {1} {2}", sTmp, CInt(Me("orgId")), UN)
                If Not IsDBNull(Me("docNum")) Then sTmp = String.Format("{0} docNum LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("docNum")).ToUpper.Replace("'", "''"), UN)
                If Not (IsDBNull(Me("docDateB")) AndAlso IsDBNull(Me("docDateE"))) Then
                    dTmp = CDate("01.01.2001")
                    dTmp1 = CDate("01.01.9999")
                    If Not IsDBNull(Me("docDateB")) Then dTmp = CDate(Me("docDateB"))
                    If Not IsDBNull(Me("docDateE")) Then dTmp1 = CDate(Me("docDateE")).AddDays(1)
                    sTmp = String.Format("{0} (docDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND docDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}) {3}", sTmp, dTmp, dTmp1, UN)
                End If
                If Not IsDBNull(Me("countryName")) Then sTmp = String.Format("{0} countryName LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("countryName")).ToUpper.Replace("'", "''"), UN)
                If Not IsDBNull(Me("conNum")) Then sTmp = String.Format("{0} conNum LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("conNum")).ToUpper.Replace("'", "''"), UN)
                If Not (IsDBNull(Me("conDateB")) AndAlso IsDBNull(Me("conDateE"))) Then
                    dTmp = CDate("01.01.2001")
                    dTmp1 = CDate("01.01.9999")
                    If Not IsDBNull(Me("conDateB")) Then dTmp = CDate(Me("conDateB"))
                    If Not IsDBNull(Me("conDateE")) Then dTmp1 = CDate(Me("conDateE")).AddDays(1)
                    sTmp = String.Format("{0} (conDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND conDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}) {3}", sTmp, dTmp, dTmp1, UN)
                End If
                If Not IsDBNull(Me("rusCaption")) Then sTmp = String.Format("{0} rusCaption LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("rusCaption")).ToUpper.Replace("'", "''"), UN)
                If Not IsDBNull(Me("rusInn")) Then sTmp = String.Format("{0} rusInn LIKE '{1}%' {2}", sTmp, C2.ToText(Me("rusInn")).ToUpper.Replace("'", "''"), UN)
                If Not IsDBNull(Me("nusCaption")) Then sTmp = String.Format("{0} nusCaption LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("nusCaption")).ToUpper.Replace("'", "''"), UN)
                If Not IsDBNull(Me("endCaption")) Then sTmp = String.Format("{0} endCaption LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("endCaption")).ToUpper.Replace("'", "''"), UN)
                ' Подзапрос на выборку данных из tDoc
                If C2.IsText(sTmp) Then
                    GetStr = String.Format("({0}) {1}", Trim(sTmp.Substring(0, sTmp.Length - 1)), UN)
                End If
                '
                ' Подзапрос на выборку id работ из tGood
                '
                sTmp = Nothing
                If Not IsDBNull(Me("goodName")) Then sTmp = String.Format("{0} goodName LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodName")).ToUpper.Replace("'", "''"), UN)
                If Not IsDBNull(Me("goodTnved")) Then sTmp = String.Format("{0} goodTnved LIKE '{1}%' {2}", sTmp, C2.ToText(Me("goodTnved")).ToUpper.Replace("'", "''"), UN)
                If Not IsDBNull(Me("goodDescription")) Then sTmp = String.Format("{0} goodDescription LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodDescription")).ToUpper.Replace("'", "''"), UN)
                If Not IsDBNull(Me("goodEqualId")) Then sTmp = String.Format("{0} isEqual = {1} {2}", sTmp, CInt(Me("goodEqualId")), UN)
                If Not IsDBNull(Me("goodSummary")) Then sTmp = String.Format("{0} goodSummary LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodSummary")).ToUpper.Replace("'", "''"), UN)
                If Not IsDBNull(Me("goodList")) Then sTmp = String.Format("{0} goodList LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodList")).ToUpper.Replace("'", "''"), UN)
                If Not IsDBNull(Me("goodPos")) Then sTmp = String.Format("{0} goodPos LIKE '%{1}%' {2}", sTmp, C2.ToText(Me("goodPos")).ToUpper.Replace("'", "''"), UN)
                ' Подзапрос на выборку id работ из tGood
                If C2.IsText(sTmp) Then
                    GetStr = String.Format("{0} id IN (SELECT docId FROM tGood WHERE {1}) {2}", GetStr, Trim(sTmp.Substring(0, sTmp.Length - 1)), UN)
                End If
                '
                ' Возвращаемое значение
                '
                If Not C2.IsText(GetStr) Then Return Nothing
                GetStr = GetStr.Substring(0, GetStr.Length - 2).Replace(UN, If(CInt(Me("unionId")) = 1, "AND", "OR"))
                Return String.Format("SELECT * FROM vDocOrg WHERE {0}", GetStr)

            End Get
        End Property

    End Class

    ''' <summary>
    ''' Условие объединения критериев поиска
    ''' </summary>
    ''' <remarks></remarks>
    Private Class UnionDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New()
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("name", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
            With Me.Rows
                .Add(New Object() {1, "<И>"})
                .Add(New Object() {2, "<ИЛИ>"})
            End With
        End Sub
    End Class

    ''' <summary>
    ''' Экспертные организации
    ''' </summary>
    ''' <remarks></remarks>
    Private Class OrgDataTable : Inherits DataTable
        Friend Sub New(Connection As SqlConnection)
            MyBase.New()
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("nameShort", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
            Me.DefaultView.Sort = "nameShort"
            Using Cmd As New SqlCommand With {.Connection = Connection}
                Cmd.CommandText = "SELECT id, nameShort FROM tOrg"
                Me.Load(Cmd.ExecuteReader)
            End Using
        End Sub
    End Class

    ''' <summary>
    ''' Соответствие контрольным спискам
    ''' </summary>
    ''' <remarks></remarks>
    Private Class EqualDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New()
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("name", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
            With Me.Rows
                .Add(New Object() {0, "Не соответствует"})
                .Add(New Object() {1, "Соответствует"})
            End With
        End Sub
    End Class

    Private Class GoodListDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New()
            Me.Columns.Add("name")
            Me.PrimaryKey = New DataColumn() {Me.Columns("name")}
            With Me.Rows
                .Add(New Object() {"ДН"})
                .Add(New Object() {"ЯО"})
                .Add(New Object() {"ХО"})
                .Add(New Object() {"РО"})
                .Add(New Object() {"БО"})
                .Add(New Object() {"ИС"})
            End With
        End Sub
    End Class

#End Region

    ''' <summary>
    ''' Начать поиск
    ''' </summary>
    ''' <param name="QueryString">Строка запроса на выборку данных</param>
    ''' <remarks></remarks>
    Friend Event FindStart(QueryString As String)

    ''' <summary>
    ''' Таблица-строка критериев поиска
    ''' </summary>
    Private ConditionRow As ConditionDataRow = Nothing

    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        '
        ' ConditionRow
        '
        ConditionRow = New ConditionDataRow
        '
        ' ConditionGridControl
        '
        UnionRepositoryItemLookUpEdit.DataSource = New UnionDataTable
        OrgRepositoryItemLookUpEdit.DataSource = New OrgDataTable(Connection)
        GoodEqualRepositoryItemLookUpEdit.DataSource = New EqualDataTable
        GoodListRepositoryItemLookUpEdit.DataSource = New GoodListDataTable
        ConditionGridControl.DataSource = ConditionRow

    End Sub

    Private Sub FindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        ConditionGridControl.CloseEditor()
        Dim sTmp As String = ConditionRow.GetQuery
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите критерии поиска!", "Поиск")
            Exit Sub
        End If
        RaiseEvent FindStart(sTmp)
    End Sub

    Private Sub ClearBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ClearBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Очистить критерии поиска?", "Поиск") <> DialogResult.Yes Then Exit Sub
        ConditionGridControl.BeginUpdate()
        ConditionRow.DataClear()
        ConditionGridControl.EndDataUpdate()
    End Sub

    Private Sub ConditionGridControl_KeyDown(sender As Object, e As KeyEventArgs) Handles ConditionGridControl.KeyDown
        If e.KeyCode = Keys.Enter Then FindBarButtonItem.PerformClick()
    End Sub

End Class
