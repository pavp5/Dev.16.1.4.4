''' <summary>
''' Таблица сводного отчета за весь период
''' </summary>
Friend Class ReportDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("ReportTable")
        With Me.Columns
            .Add("countryId", GetType(Integer))
            .Add("countryName", GetType(String))
            .Add("workCount", GetType(Integer))
        End With
        Me.Columns("countryId").AllowDBNull = False
        Me.Columns("countryName").AllowDBNull = False
        Me.Columns("workCount").AllowDBNull = False
        Me.Columns("workCount").DefaultValue = 0
        Me.PrimaryKey = New DataColumn() {Me.Columns("countryId")}
    End Sub


End Class
