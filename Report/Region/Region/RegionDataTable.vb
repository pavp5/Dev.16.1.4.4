''' <summary>
''' Таблица отчета по регионам
''' </summary>
Friend Class RegionDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("RegionTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
            .Add("workCount", GetType(Integer))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("name").AllowDBNull = False
        With Me.Columns("workCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class
