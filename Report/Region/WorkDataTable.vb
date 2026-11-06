''' <summary>
''' Таблица отчета по работам за период
''' </summary>
Friend Class WorkDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("WorkTable")
        With Me.Columns
            .Add("workId", GetType(Integer))
            .Add("orderDate", GetType(Date))
            .Add("regionId", GetType(Integer))
            .Add("districtId", GetType(Integer))
        End With
        Me.Columns("workId").AllowDBNull = False
        Me.Columns("orderDate").AllowDBNull = False
        Me.Columns("regionId").AllowDBNull = False
        'Me.Columns("districtId").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("workId")}
    End Sub


End Class
