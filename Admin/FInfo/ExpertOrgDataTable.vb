''' <summary>
''' Таблица экспертных огранизаций
''' </summary>
Friend Class ExpertOrgDataTable : Inherits Cprp.DxData.Base.ConnectionDataTable

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Friend Sub New(Connection As SqlConnection)
        MyBase.New(Connection, "ExpertOrgTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("nameLong", GetType(String))
            .Add("nameShort", GetType(String))
            .Add("inn", GetType(String))
        End With
        Me.Columns("id").AllowDBNull = False
        With Me.Columns("nameLong")
            .AllowDBNull = False
            .MaxLength = 300
        End With
        Me.Columns("nameShort").MaxLength = 300
        With Me.Columns("inn")
            .AllowDBNull = False
            .MaxLength = 12
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


    ''' <summary>
    ''' Загрузить данные из базы
    ''' </summary>
    Friend Sub DataReload()
        Me.Rows.Clear()
        Me.Load("SELECT * FROM tExpertOrg")
    End Sub

    ''' <summary>
    ''' Сохранить данные в базу
    ''' </summary>
    Friend Sub SaveToBase()
        Using A As New SqlDataAdapter("SELECT * FROM tExpertOrg", MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub


    ''' <summary>
    ''' Возвращает новую строку с предзаполненным полем id
    ''' </summary>
    Friend Shadows Function NewRow() As DataRow
        Dim Row As DataRow = MyBase.NewRow
        If Me.Rows.Count = 0 Then
            Row("id") = 1
        Else
            Using V As New DataView(Me) With {.Sort = "id DESC"}
                Row("id") = CInt(V(0)("id")) + 1
            End Using
        End If
        Return Row
    End Function

End Class
