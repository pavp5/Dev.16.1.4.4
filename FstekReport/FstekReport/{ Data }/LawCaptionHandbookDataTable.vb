''' <summary>
''' Справочник заголовков контрольных списков
''' </summary>
Public Class LawCaptionHandbookDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New()
        MyBase.New("LawCaptionTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("guid", GetType(String))
            .Add("doc", GetType(String))
            .Add("caption", GetType(String))
            .Add("isACT", GetType(Boolean))
        End With
        With Me.Columns("id")
            .AllowDBNull = False
        End With
        With Me.Columns("guid")
            .MaxLength = 32
        End With
        With Me.Columns("doc")
            .AllowDBNull = False
            .MaxLength = 14
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
            Cmd.CommandText = "SELECT id, guid, doc, caption, isACT FROM tLawCaption"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ''' <summary>
    ''' Сохранить данные в базу
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub DataSave(Connection As SqlConnection)
        Using A As New SqlDataAdapter("SELECT id, guid, doc, caption, isACT FROM tLawCaption", Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

End Class
