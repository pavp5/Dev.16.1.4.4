Namespace Base

    ''' <summary>
    ''' Базовый класс - Таблица данных на одну строку с открытым подключением к базе данных
    ''' </summary>
    ''' <remarks></remarks>
    Public MustInherit Class ConnectionDataRow : Inherits BaseDataRow

        ' Объект SqlCommand
        Private _Command As SqlCommand = Nothing

        ''' <summary>
        ''' Инициализация нового экземпляра класса Cprp.DxData.Base.ConnectionDataRow
        ''' </summary>
        ''' <param name="Connection">Соединение с базой данных</param> 
        ''' <remarks></remarks>
        Public Sub New(ByVal Connection As SqlConnection)
            MyBase.New()
            _Command = New SqlCommand With {.Connection = Connection}
        End Sub

        ''' <summary>
        ''' Инициализация нового экземпляра класса Cprp.DxData.Base.ConnectionDataRow
        ''' </summary>
        ''' <param name="con_str">Строка подключения к базе данных</param>
        ''' <remarks></remarks>
        Public Sub New(ByVal con_str As String)
            MyClass.New(New SqlConnection(con_str))
            'Dim Connection As New SqlConnection(con_str)
            'Connection.Open()
            '_Command = New SqlCommand With {.Connection = Connection}
            _Command.Connection.Open()
        End Sub

        ' ''' <summary>
        ' ''' Инициализация нового экземпляра класса Cprp.DxData.Base.ConnectionDataRow
        ' ''' </summary>
        ' ''' <param name="Connection">Соединение с базой данных</param> 
        ' ''' <param name="tableName">Имя таблицы</param>
        ' ''' <remarks></remarks>
        'Public Sub New(ByVal Connection As SqlConnection, ByVal tableName As String)
        '    MyBase.New(tableName)
        '    _Command = New SqlCommand With {.Connection = Connection}
        'End Sub

        ''' <summary>
        ''' Открытое подключение к базе данных
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Connection As SqlConnection
            Get
                If _Command.Connection Is Nothing Then Return Nothing
                With _Command.Connection
                    If .State <> ConnectionState.Open AndAlso Not String.IsNullOrWhiteSpace(.ConnectionString) Then
                        If .State <> ConnectionState.Closed Then .Close()
                        .Open()
                    End If
                End With
                Return _Command.Connection
            End Get
            Set(value As SqlConnection)
                _Command.Connection = value
            End Set
        End Property

        ''' <summary>
        ''' Загрузить данные из базы данных
        ''' </summary>
        ''' <param name="commandText">Текст запроса на выборку данных</param>
        ''' <remarks>Перед загрузкой таблица очищается от всех данных</remarks>
        Public Shadows Sub Load(ByVal commandText As String)
            MyBase.Rows.Clear()
            MyBase.Load(MyClass.ExecuteReader(commandText))
        End Sub

        ''' <summary>
        ''' Выполняет инструкцию Transact-SQL и возвращает количество задействованных строк
        ''' </summary>
        ''' <param name="commandText">Текст инструкции Transact-SQL</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecuteNonQuery(ByVal commandText As String) As Integer
            _Command.CommandText = commandText
            Return _Command.ExecuteNonQuery
        End Function

        ''' <summary>
        ''' Выполняет запрос и возвращает объект SqlDataReader построенный по результатам запроса
        ''' </summary>
        ''' <param name="commandText">Текст запроса</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecuteReader(ByVal commandText As String) As SqlDataReader
            _Command.CommandText = commandText
            Return _Command.ExecuteReader
        End Function

        ''' <summary>
        ''' Выполняет запрос и возвращает первый столбец первой строки результирующего набора данных
        ''' </summary>
        ''' <param name="commandText">Текст запроса</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Function ExecuteScalar(ByVal commandText As String) As Object
            _Command.CommandText = commandText
            Return _Command.ExecuteScalar
        End Function

    End Class


End Namespace
