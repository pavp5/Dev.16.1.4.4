Imports C2 = Cprp.DxData.Common
''' <summary>
''' Содержание работы
''' </summary>
Friend Class ContentDataTable : Inherits DataTable

    ''' <summary>
    ''' Работа
    ''' </summary>
    Private Work As WorkConnectionRow = Nothing

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.ContentDataTable
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <remarks></remarks>
    Public Sub New(Work As WorkConnectionRow)
        '
        ' Me
        '
        MyBase.New("ContentTable")
        With Me.Columns
            .Add("id", GetType(Integer))                ' ID строки
            .Add("parentId", GetType(Integer))          ' ID родительской строки
            .Add("contentId", GetType(ContentEnum))     ' Идентификатор раздела
            .Add("objectId", GetType(Integer))          ' Идентификатор объекта в списке объектов раздела
            .Add("caption", GetType(String))            ' Наименование
        End With
        Me.Columns("contentId").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' Work
        '
        MyClass.Work = Work
    End Sub

    ''' <summary>
    ''' Перечитать содержание работы
    ''' </summary>
    Public Sub DataReload()
        Me.Rows.Clear()
        If Work Is Nothing OrElse Work.IsEmpty Then Exit Sub
        If Work.Condition = WorkCondition.IsNew Then Exit Sub
        Dim sTmp As String = Nothing
        '
        ' ПЛАН РАБОТЫ
        '
        Me.Rows.Add(New Object() {ContentEnum.Plane, DBNull.Value, ContentEnum.Plane, C2.EMPTY_ID, "ПЛАН РАБОТЫ"})
        If Work.Condition = WorkCondition.IsPlaneWork OrElse Work.Condition = WorkCondition.IsPlaneAgree Then Exit Sub
        '
        ' СВЕДЕНИЯ О ЛИЦЕНЗИИ
        '
        Me.Rows.Add(New Object() {ContentEnum.License, DBNull.Value, ContentEnum.License, C2.EMPTY_ID, "СВЕДЕНИЯ О ЛИЦЕНЗИИ"})
        '
        ' ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ)
        '
        Me.Rows.Add(New Object() {ContentEnum.GoodList, DBNull.Value, ContentEnum.GoodList, C2.EMPTY_ID, "ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ)"})
        Using V As New DataView(Work.GoodTable)
            V.Sort = "rowNum"
            For i As Integer = 0 To V.Count - 1
                sTmp = C2.DelPoint(V(i)("nameCon"))
                If Not C2.IsText(sTmp) Then sTmp = "[нет наименования]"
                Me.Rows.Add(New Object() {Me.Rows.Count + 1000, ContentEnum.GoodList, ContentEnum.GoodData, _
                                          CInt(V(i)("id")), String.Format("{0}. {1}", C2.ToInt(V(i)("rowNum")), sTmp)})
            Next
        End Using
        '
        ' ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ 
        '
        Me.Rows.Add(New Object() {ContentEnum.ExtraInfo, DBNull.Value, ContentEnum.ExtraInfo, C2.EMPTY_ID, "ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ"})

    End Sub

End Class
