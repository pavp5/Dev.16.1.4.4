''' <summary>
''' Таблица-справочник регионов
''' </summary>
Friend Class RegionDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("RegionTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("code", GetType(String))
            .Add("codeName", GetType(String))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("code").AllowDBNull = False
        Me.Columns("codeName").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Me.DefaultView.Sort = "code"
        Me.Rows.Add(New Object() {0, "0", "Все регионы"})
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = "SELECT id, code, code + ' - ' + name AS codeName FROM tRegion WHERE isACT = 1"
            Me.Load(Cmd.ExecuteReader)
        End Using

    End Sub

End Class
