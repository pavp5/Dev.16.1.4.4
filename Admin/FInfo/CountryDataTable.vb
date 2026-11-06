''' <summary>
''' Справочник стран мира
''' </summary>
Friend Class CountryDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("CountryTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("nameShort", GetType(String))
            .Add("name", GetType(String))           ' nameShort (nameLong)
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


    ''' <summary>
    ''' Перечитать данные из базы данных
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Friend Sub DataReload(Connection As SqlConnection)
        Me.Rows.Clear()
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = "SELECT id, nameShort, nameShort + ISNULL(' (' + nameLong + ')', '') AS name FROM tCountry WHERE isACT = 1"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub

End Class
