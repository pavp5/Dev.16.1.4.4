Imports Cprp.DxData.Common
''' <summary>
''' Справочник стран мира
''' </summary>
Public Class CountryHandbookDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("guid", GetType(String))
            .Add("nameShort", GetType(String))
            .Add("nameLong", GetType(String))
            .Add("codAlpha2", GetType(String))
            .Add("codAlpha3", GetType(String))
            .Add("codDec", GetType(String))
            .Add("isControl", GetType(Boolean))
            .Add("isACT", GetType(Boolean))
        End With
        With Me.Columns("id")
            .AllowDBNull = False
        End With
        With Me.Columns("guid")
            .MaxLength = 32
        End With
        With Me.Columns("nameShort")
            .AllowDBNull = False
            .MaxLength = 60
        End With
        With Me.Columns("nameLong")
            .MaxLength = 100
        End With
        With Me.Columns("codAlpha2")
            .AllowDBNull = False
            .MaxLength = 2
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
            .DefaultValue = True
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


    ''' <summary>
    ''' Загрузить данные из базы
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub DataLoad(Connection As SqlConnection)
        Me.Rows.Clear()
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = "SELECT id, guid, nameShort, nameLong, codAlpha2, codAlpha3, codDec, isControl, isACT FROM tCountry"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ''' <summary>
    ''' Сохранить данные в базу
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub DataSave(Connection As SqlConnection)
        Using A As New SqlDataAdapter("SELECT id, guid, nameShort, nameLong, codAlpha2, codAlpha3, codDec, isControl, isACT FROM tCountry", Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

    ''' <summary>
    ''' Возвращает строку по десятичному коду страны
    ''' </summary>
    ''' <param name="codDec">Десятичный код страны</param>
    ''' <remarks>Если строка не найдена, возвращает Nothing</remarks>
    Public Function GetRowByCodDec(codDec As String) As DataRow
        If Not IsText(codDec) Then Return Nothing
        Using V As New DataView(Me)
            V.RowFilter = String.Format("codDec LIKE '{0}'", ToText(codDec))
            If V.Count > 0 Then Return V(0).Row
        End Using
        Return Nothing
    End Function

End Class
