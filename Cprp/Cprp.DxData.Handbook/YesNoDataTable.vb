''' <summary>
''' Таблица выбора (Да/Нет)
''' </summary>
''' <remarks></remarks>
Public Class YesNoDataTable : Inherits DataTable
    Public Sub New()
        MyBase.New()
        Me.Columns.Add("intValue", GetType(Integer))
        Me.Columns.Add("boolValue", GetType(Boolean))
        Me.Columns.Add("name", GetType(String))
        Me.Columns.Add("goodType", GetType(String))
        Me.Rows.Add(New Object() {1, True, "Да", "Материальные"})
        Me.Rows.Add(New Object() {0, False, "Нет", "Информационные"})
    End Sub
End Class
