''' <summary>
''' Таблица отчета по федеральным округам
''' </summary>
Friend Class DistrictDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("DistrictTable")
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
