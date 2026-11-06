Imports Cprp.DxData.Common
''' <summary>
''' Справочник стран мира
''' </summary>
Friend Class CountryConnectionTable : Inherits Cprp.DxData.Base.ConnectionDataTable


    Friend Sub New()
        MyBase.New(Program.DbClient.Connection, "CountryTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("guid", GetType(String))
            .Add("nameShort", GetType(String))
            .Add("nameLong", GetType(String))
            .Add("codAlpha2", GetType(String))
            .Add("codAlpha3", GetType(String))
            .Add("codDec", GetType(String))
            .Add("fid", GetType(Integer))
            .Add("riskDescription", GetType(String))
            .Add("isControl", GetType(Boolean))
            .Add("isACT", GetType(Boolean))
            With Me.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Me.Columns("guid").MaxLength = 32
            With Me.Columns("nameShort")
                .AllowDBNull = False
                .MaxLength = 60
            End With
            Me.Columns("nameLong").MaxLength = 100
            With Me.Columns("codAlpha2")
                .AllowDBNull = False
                .MaxLength = 3
            End With
            With Me.Columns("codAlpha3")
                .AllowDBNull = False
                .MaxLength = 3
            End With
            With Me.Columns("codDec")
                .AllowDBNull = False
                .MaxLength = 3
            End With
            With Me.Columns("isControl")
                .AllowDBNull = False
                .DefaultValue = False
            End With
            With Me.Columns("isACT")
                .AllowDBNull = False
                .DefaultValue = False
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End With
    End Sub


    ' Сохранить данные в базу
    Friend Sub SaveToBase()
        Using A As New SqlDataAdapter("SELECT * FROM tCountry WHERE id < 0", MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

End Class
