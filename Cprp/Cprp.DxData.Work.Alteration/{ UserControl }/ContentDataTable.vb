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
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Consultation.ContentDataTable
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

    End Sub

End Class
