''' <summary>
''' Таблица экспертных организаций с количеством заключений
''' </summary>
Friend Class OrgReportDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("OrgReportTable")
        With Me.Columns
            .Add("orgId", GetType(Integer))
            .Add("orgNameShort", GetType(String))
            .Add("orgNameLong", GetType(String))
            .Add("orgProfile", GetType(String))
            .Add("maxDocNum", GetType(String))
            .Add("docCount", GetType(Integer))
        End With
        Me.Columns("orgId").AllowDBNull = False
        Me.Columns("orgNameShort").AllowDBNull = False
        Me.Columns("maxDocNum").AllowDBNull = False
        With Me.Columns("docCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("orgId")}
    End Sub

End Class
