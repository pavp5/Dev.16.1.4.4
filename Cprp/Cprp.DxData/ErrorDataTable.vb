''' <summary>
''' Обработка ошибок
''' </summary>
Public Class ErrorDataTable : Inherits Base.ConnectionDataTable


    ''' <summary>
    ''' Путь к xml-файлу чтения и записи данных
    ''' </summary>
    Private filePath As String = Nothing

    ''' <summary>
    ''' ID пользователя
    ''' </summary>
    Private userId As Integer = 0

    ''' <summary>
    ''' Наименование приложения
    ''' </summary>
    Private appName As String = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="filePath">Путь к xml-файлу чтения и записи данных</param>
    ''' <param name="userId">ID пользователя</param>
    ''' <param name="appName">Наименование приложения</param>
    Public Sub New(Connection As SqlConnection, filePath As String, userId As Integer, appName As String)
        MyBase.New(Connection, "ErrorTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("eventDate", GetType(Date))        ' Дата события
            .Add("userId", GetType(Integer))        ' ID пользователя
            .Add("appName", GetType(String))        ' Наименование приложения
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
        Me.Connection = Connection
        Me.filePath = filePath
        Me.userId = userId
        Me.appName = appName
        If My.Computer.FileSystem.FileExists(filePath) Then Me.ReadXml(filePath)
    End Sub


    ''' <summary>
    ''' Записать ошибку в текущую таблицу
    ''' </summary>
    ''' <param name="action">Выполняемое действие</param>
    ''' <param name="description">Описание ошибки</param>
    ''' <returns>Возвращает полное описание сообщения об ошибке с рекомендациями по устранению</returns>
    Public Function WriteError(action As String, description As String) As String
        If String.IsNullOrWhiteSpace(filePath) Then GoTo Mess
        Dim Row As DataRow = Me.NewRow
        Row("eventDate") = Date.Now
        Row("userId") = userId
        Row("appName") = Common.DbText(appName, 50)
        Row("action") = Common.DbText(action, 250)
        Row("description") = Common.DbText(description)
        Row("isNew") = True
        Me.Rows.Add(Row)
        Me.AcceptChanges()
        Me.WriteXml(filePath)
Mess:
        Dim comment As String = "Обратитесь к администратору системы"
        description = Common.ToText(description)
        If Not String.IsNullOrWhiteSpace(description) Then
            Using V As New DataView(Me)
                V.RowFilter = String.Format("description LIKE '{0}%' AND NOT comment IS NULL", description)
                If V.Count > 0 Then comment = Common.ToText(V(0)("comment"))
            End Using
        End If
        If Not Connection Is Nothing AndAlso Connection.State = ConnectionState.Open Then DataSave()
        Return String.Format("Ошибка выполнения операции:{1}{0}{1}{1}Рекомендации по устранению:{1}{2}", Common.AddPoint(description), vbCrLf, Common.AddPoint(comment))
    End Function

    ''' <summary>
    ''' Сохранить записанные ошибки в базу данных
    ''' </summary>
    Public Sub DataSave()
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Sub
        ' Выделение новых строк
        Me.AcceptChanges()
        For Each Row As DataRow In Me.Rows
            If CBool(Row("isNew")) Then Row.SetAdded()
        Next
        ' Сохранение новых строк в базу
        Using A As New SqlDataAdapter("SELECT id, eventDate, userId, appName, action, description FROM tError", Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
        ' Пометка всех строк в текущей таблице как старых
        Using V As New DataView(Me) With {.RowFilter = "isNew = True"}
            While V.Count > 0
                V(0)("isNew") = False
            End While
        End Using
        Me.AcceptChanges()
        If My.Computer.FileSystem.FileExists(filePath) Then
            Me.WriteXml(filePath)
        End If
    End Sub

    ''' <summary>
    ''' Загрузить сохраненные ошибки с комментариями из базы данных
    ''' </summary>
    Public Sub DataLoad()
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Sub
        Me.Rows.Clear()
        MyBase.Load("SELECT id, eventDate, userId, appName, action, description, comment FROM tError WHERE NOT comment IS NULL")
        Me.AcceptChanges()
    End Sub

End Class
