''' <summary>
''' Таблица связей запретов со странами
''' </summary>
Friend Class EmbargoCountryDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("EmbargoCountryTable")
        With Me.Columns
            .Add("countryId", GetType(Integer))
            .Add("embargoId", GetType(Integer))
            .Add("modeId", GetType(Integer))
        End With
        Me.Columns("countryId").AllowDBNull = False
        Me.Columns("embargoId").AllowDBNull = False
        Me.Columns("modeId").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("countryId"), Me.Columns("embargoId")}
    End Sub

End Class
