''' <summary>
''' Таблица заказчиков
''' </summary>
Friend Class ClientDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("ClientTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("nameLong", GetType(String))
            .Add("inn", GetType(String))
            .Add("address", GetType(String))
            .Add("isNew", GetType(Boolean))
        End With        
        Me.Columns("nameLong").AllowDBNull = False
        With Me.Columns("isNew")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class
