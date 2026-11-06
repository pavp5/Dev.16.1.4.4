''' <summary>
''' Обработка ошибок
''' </summary>
Friend Class ErrorDataTable : Inherits DataTable


    Public Sub New()
        MyBase.New("ErrorTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("eventDate", GetType(Date))        ' Дата события
            .Add("userId", GetType(Integer))        ' ID пользователя
            .Add("progName", GetType(String))       ' Наименование программы
            .Add("action", GetType(String))         ' Выполняемое действие
            .Add("description", GetType(String))    ' Описание ошибки
            .Add("comment", GetType(String))        ' Комментарий администратора
            .Add("isNew", GetType(Boolean))         ' Признак новой строки
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("isNew")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


    ''' <summary>
    ''' Записать ошибку в текущую таблицу
    ''' </summary>
    ''' <param name="action">Выполняемое действие</param>
    ''' <param name="description">Описание ошибки</param>
    Public Sub WriteError(action As String, description As String)
        Dim Row As DataRow = Me.NewRow
        Row("eventDate") = Date.Now
        Row("userId") = Program.DbClient.Id
        Row("progName") = "Leader"
        Row("action") = Cprp.DxData.Common.DbText(action)
        Row("description") = Cprp.DxData.Common.DbText(description)
        Row("isNew") = True
        Me.Rows.Add(Row)
        Me.AcceptChanges()
        Me.WriteXml(String.Format("{0}\error.xml", Application.StartupPath))
    End Sub

    ''' <summary>
    ''' Сохранить записанные ошибки в базу данных
    ''' </summary>
    Public Sub DataSave()
        With Program.DbClient
            If .Connection Is Nothing OrElse .Connection.State <> ConnectionState.Open Then Exit Sub
        End With
        ' Выделение новых строк
        Me.AcceptChanges()
        For Each Row As DataRow In Me.Rows
            If CBool(Row("isNew")) Then Row.SetAdded()
        Next
        ' Сохранение новых строк в базу
        Using A As New SqlDataAdapter("SELECT id, eventDate, userId, progName, action, description FROM tError", Program.DbClient.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
        ' Пометка новых строк как сохраненных
        Me.AcceptChanges()
        Using V As New DataView(Me) With {.RowFilter = "isNew = True"}
            While V.Count > 0
                V(0)("isNew") = False
            End While
        End Using
        Me.AcceptChanges()
        Me.WriteXml(String.Format("{0}\error.xml", Application.StartupPath))
    End Sub

    ' Загрузить сохраненные ошибки с комментариями из базы данных
    Public Sub DataLoad()
        With Program.DbClient
            If .Connection Is Nothing OrElse .Connection.State <> ConnectionState.Open Then Exit Sub
        End With
        Me.Rows.Clear()
        Using Cmd As SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = "SELECT id, eventDate, userId, progName, action, description, comment FROM tError WHERE NOT comment IS NULL"
            Me.Load(Cmd.ExecuteReader)
        End Using
        Me.AcceptChanges()
    End Sub

    ''' <summary>
    ''' Возвращает комментарий к ошибке по ее содержанию
    ''' </summary>
    ''' <param name="description">Содержание ошибки</param>
    Public Function GetComment(description As String) As String
        description = Cprp.DxData.Common.ToText(description)
        If Not String.IsNullOrWhiteSpace(description) Then
            Using V As New DataView(Me)
                V.RowFilter = String.Format("description LIKE '{0}%'", description.Replace("'", "''"))
                If V.Count > 0 Then Return Cprp.DxData.Common.ToText(V(0)("comment"))
            End Using
        End If
        Return Nothing
    End Function

End Class
