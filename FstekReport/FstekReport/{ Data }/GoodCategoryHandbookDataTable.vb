''' <summary>
''' Справочник категорий объектов экспертизы
''' </summary>
Public Class GoodCategoryHandbookDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("guid", GetType(String))
            .Add("code", GetType(String))
            .Add("name", GetType(String))
            .Add("price", GetType(Single))
            .Add("isChild", GetType(Boolean))
            .Add("isParent", GetType(Boolean))
            .Add("isACT", GetType(Boolean))
        End With
        With Me.Columns("id")
            .AllowDBNull = False
        End With
        With Me.Columns("guid")
            .MaxLength = 32
        End With
        With Me.Columns("code")
            .AllowDBNull = False
            .MaxLength = 3
        End With
        With Me.Columns("name")
            .AllowDBNull = False
            .MaxLength = 100
        End With
        With Me.Columns("isChild")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isParent")
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
            Cmd.CommandText = "SELECT id, guid, code, name, price, isChild, isParent, isACT FROM tGoodCategory"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ''' <summary>
    ''' Сохранить данные в базу
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub DataSave(Connection As SqlConnection)
        Using A As New SqlDataAdapter("SELECT id, guid, code, name, price, isChild, isParent, isACT FROM tGoodCategory", Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

End Class
