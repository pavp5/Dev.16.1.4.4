Imports C2 = Cprp.DxData.Common
''' <summary>
''' План работы
''' </summary>
''' <remarks></remarks>
Public Class PlaneDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.PlaneDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New("PlaneTable")
        With Me.Columns
            .Add("id", GetType(Integer))        ' id
            .Add("caption", GetType(String))    ' описание мероприятия
            .Add("isCheck", GetType(Boolean))   ' выбрано (да/нет)
        End With
        With Me.Columns("id")
            .AllowDBNull = False
        End With
        With Me.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ''' <summary>
    ''' Инициализация перечня мероприятий
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DataInit()
        Me.Rows.Clear()
        With Me.Rows
            .Add(New Object() {1, "Запрос дополнительной информации", False})
            .Add(New Object() {2, "Самостоятельный поиск информации", False})
            .Add(New Object() {3, "Составление профилей участников сделки / операции", False})
            .Add(New Object() {4, "Работа с текстами на иностранном языке", False})
        End With
    End Sub

End Class
