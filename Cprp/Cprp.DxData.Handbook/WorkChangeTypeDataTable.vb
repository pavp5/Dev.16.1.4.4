''' <summary>
''' Источники ошибок при внесении изменений в работу
''' </summary>
Public Class WorkChangeTypeDataTable : Inherits DataTable
    Public Sub New()
        MyBase.New()
        Me.Columns.Add("id", GetType(Integer))
        Me.Columns.Add("name", GetType(String))
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Me.Rows.Add(New Object() {1, "Заказчик"})
        Me.Rows.Add(New Object() {2, "Эксперт"})
        Me.DefaultView.Sort = "name DESC"
    End Sub
End Class
