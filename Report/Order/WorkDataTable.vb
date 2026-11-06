''' <summary>
''' Таблица работ за период
''' </summary>
Friend Class WorkDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("WorkTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("clientId", GetType(Integer))
            .Add("orderNum", GetType(String))
            .Add("orderDate", GetType(Date))
            .Add("name", GetType(String))
        End With
        Me.Columns("clientId").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class
