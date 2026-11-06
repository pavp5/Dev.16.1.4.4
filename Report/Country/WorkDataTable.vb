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
            .Add("id", GetType(Integer))
            .Add("countryId", GetType(Integer))
            .Add("countryName", GetType(String))
            .Add("orderNum", GetType(String))
            .Add("orderDate", GetType(Date))
            .Add("orderUrl", GetType(String))
            .Add("clientName", GetType(String))
            .Add("description", GetType(String))
            .Add("isTemp", GetType(Boolean))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("countryId").AllowDBNull = False
        Me.Columns("countryName").AllowDBNull = False
        Me.Columns("orderDate").AllowDBNull = False
        Me.Columns("isTemp").AllowDBNull = False
        Me.Columns("isTemp").DefaultValue = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


End Class
