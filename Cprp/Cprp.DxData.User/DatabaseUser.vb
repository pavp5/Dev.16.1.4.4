''' <summary>
''' Пользователь базы данных
''' </summary>
''' <remarks></remarks>
Public Class DatabaseUser

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.DbClient.DatabaseClient
    ''' </summary>
    ''' <param name="showLoginWindow">Отображать окно ввода данных для подключения к БД</param>
    ''' <remarks>
    ''' Если showLoginWindow = false и в процессе подключения с параметрами по умолчанию произошла ошибка, 
    ''' окно ввода данных для подключения появится автоматически
    ''' </remarks>
    Public Sub New(ByVal showLoginWindow As Boolean)
        If showLoginWindow OrElse Not CheckSetting() OrElse Not OpenConnection(False) Then
            With New ConnectForm(Me)
                .ShowDialog()
            End With
        End If
        If _Connection Is Nothing OrElse _Connection.State <> ConnectionState.Open Then Exit Sub
        If Not _Connection.Database.ToUpper Like "EXDBA" Then
            Using Cmd As New SqlCommand With {.Connection = _Connection}
                Cmd.CommandText = "SELECT id FROM tUser WHERE ((SELECT SYSTEM_USER) LIKE ('%' + tUser.login))"
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    If Dr.Read Then _id = CInt(Dr(0))
                    Dr.Close()
                End Using
            End Using
            If _id > 0 Then LoadProperty()
        End If
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.DbClient.DatabaseClient
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(Connection As SqlConnection)
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Sub
        _Connection = Connection
        If Not _Connection.Database.ToUpper Like "EXDBA" Then
            Using Cmd As New SqlCommand With {.Connection = _Connection}
                Cmd.CommandText = "SELECT ISNULL (MAX(id), -1) FROM tUser WHERE ((SELECT SYSTEM_USER) LIKE ('%' + tUser.login))"
                _id = CInt(Cmd.ExecuteScalar)
            End Using
            If _id > 0 Then LoadProperty()
        End If
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.DbClient.DatabaseClient
    ''' </summary>
    ''' <param name="userId">ID пользователя</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(userId As Object, Connection As SqlConnection)
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Sub
        _Connection = Connection
        _id = Cprp.DxData.Common.ToInt(userId)
        If Not _Connection.Database.ToUpper Like "EXDBA" Then
            Using Cmd As New SqlCommand With {.Connection = _Connection}
                Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tUser WHERE id = {0}", _id)
                If CInt(Cmd.ExecuteScalar) = 0 Then _id = -1
            End Using
            If _id > 0 Then LoadProperty()
        End If
    End Sub


#Region "Connection"

    Private _Connection As SqlConnection
    ''' <summary>
    ''' Соединение с базой данных
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property Connection As SqlConnection
        Get
            Return _Connection
        End Get
    End Property

    ''' <summary>
    ''' Открыть соединение с базой данных
    ''' </summary>
    ''' <param name="showErrorMessage">Отображать сообщения об ошибках подключения</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function OpenConnection(ByVal showErrorMessage As Boolean) As Boolean
        If _Connection Is Nothing Then _Connection = New SqlConnection
        If _Connection.State <> ConnectionState.Closed Then _Connection.Close()
        With My.Settings
            If .IsTrustedConnection Then
                _Connection.ConnectionString = String.Format("Server={0};Database={1};Trusted_connection=Yes", .ServerName, .DatabaseName)
            Else
                _Connection.ConnectionString = String.Format("Server={0};Database={1};UID={2};PWD={3};Persist Security Info=True;Trusted_connection=No", _
                                                             .ServerName, .DatabaseName, .UserLogin, .UserPassword)
            End If
        End With
        Try
            _Connection.Open()
        Catch ex As Exception
            If showErrorMessage Then
                Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка соединения с базой данных:{0}{1}", vbCrLf, ex.Message))
            End If
            Return False
        End Try
        My.Settings.Save()
        Return True
    End Function

    ''' <summary>
    ''' Проверка сохраненных параметров подключения
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function CheckSetting() As Boolean
        With My.Settings
            If String.IsNullOrWhiteSpace(Trim(.ServerName)) Then Return False
            If String.IsNullOrWhiteSpace(Trim(.DatabaseName)) Then Return False
            If Not .IsTrustedConnection AndAlso String.IsNullOrWhiteSpace(Trim(.UserLogin)) Then Return False
        End With
        Return True
    End Function

#End Region
#Region "Property"

    Private _id As Integer = -1
    ''' <summary>
    ''' ID пользователя
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property Id As Integer
        Get
            Return _id
        End Get
    End Property

    Private _nameLong As String = Nothing
    ''' <summary>
    ''' Фамилия Имя Отчество пользователя
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property NameLong As String
        Get
            Return _nameLong
        End Get
    End Property

    Private _nameShort As String = Nothing
    ''' <summary>
    ''' Фамилия И.О. пользователя
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property NameShort As String
        Get
            Return _nameShort
        End Get
    End Property

    Private _login As String = Nothing
    ''' <summary>
    ''' Логин пользователя
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property Login As String
        Get
            Return _login
        End Get
    End Property

    Private _email As String = Nothing
    ''' <summary>
    ''' E-mail
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property Email As String
        Get
            Return _email
        End Get
    End Property

    Private _isACT As Boolean = False
    ''' <summary>
    ''' Учетная запись пользователя активна
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property IsACT As Boolean
        Get
            Return _isACT
        End Get
    End Property

    Private _isAdmin As Boolean = False
    ''' <summary>
    ''' Принадлежность пользователя к роли "Администратор"
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property IsAdmin As Boolean
        Get
            Return _isAdmin
        End Get
    End Property

    Private _adminDescription As String = Nothing
    ''' <summary>
    ''' Должность администратора
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property AdminDescription As String
        Get
            Return _adminDescription
        End Get
    End Property

    Private _isChief As Boolean = False
    ''' <summary>
    ''' Принадлежность пользователя к роли "Генеральный директор"
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property IsChief As Boolean
        Get
            Return _isChief
        End Get
    End Property

    Private _chiefDescription As String = Nothing
    ''' <summary>
    ''' Должность генерального директора
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ChiefDescription As String
        Get
            Return _chiefDescription
        End Get
    End Property

    Private _isExpert As Boolean = False
    ''' <summary>
    ''' Принадлежность пользователя к роли "Эксперт"
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property IsExpert As Boolean
        Get
            Return _isExpert
        End Get
    End Property

    Private _expertDescription As String = Nothing
    ''' <summary>
    ''' Должность эксперта
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ExpertDescription As String
        Get
            Return _expertDescription
        End Get
    End Property

    Private _isLeader As Boolean = False
    ''' <summary>
    ''' Принадлежность пользователя к роли "Руководитель экспертизы"
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property IsLeader As Boolean
        Get
            Return _isLeader
        End Get
    End Property

    Private _leaderDescription As String = Nothing
    ''' <summary>
    ''' Должность руководителя экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property LeaderDescription As String
        Get
            Return _leaderDescription
        End Get
    End Property

    Private _isManager As Boolean = False
    ''' <summary>
    ''' Принадлежность пользователя к роли "Менеджер"
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property IsManager As Boolean
        Get
            Return _isManager
        End Get
    End Property

    Private _managerDescription As String = Nothing
    ''' <summary>
    ''' Должность менеджера
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ManagerDescription As String
        Get
            Return _managerDescription
        End Get
    End Property

    Private _isSubleader As Boolean = False
    ''' <summary>
    ''' Принадлежность пользователя к роли "Помощник руководителя экспертизы"
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property IsSubleader As Boolean
        Get
            Return _isSubleader
        End Get
    End Property

    Private _subleaderDescription As String = Nothing
    ''' <summary>
    ''' Должность помощника руководителя экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property SubleaderDescription As String
        Get
            Return _subleaderDescription
        End Get
    End Property

    ''' <summary>
    ''' Факсимиле
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property Signature As Drawing.Image
        Get
            If _Connection Is Nothing Then Return Nothing
            Dim Img As Drawing.Image = Nothing
            Try
                Using Cmd As New SqlCommand With {.Connection = _Connection}
                    Cmd.CommandText = String.Format("SELECT signature FROM tUser WHERE NOT signature IS NULL AND id = {0}", _id)
                    Using Dr As SqlDataReader = Cmd.ExecuteReader
                        If Dr.Read Then
                            'With My.Computer.FileSystem
                            '    Dim sTmp As String = .GetTempFileName
                            '    .WriteAllBytes(sTmp, Dr(0), False)
                            '    Img = Drawing.Image.FromFile(sTmp)
                            '    .DeleteFile(sTmp)
                            'End With
                            Dim Arr() As Byte = Dr(0)
                            Using M As New IO.MemoryStream(Arr)
                                Img = Drawing.Image.FromStream(M)
                            End Using
                        End If
                        Dr.Close()
                    End Using
                End Using
            Catch ex As Exception
                Throw ex
            End Try
            Return Img
        End Get
    End Property

    ''' <summary>
    ''' Актуализовать информацию о пользователе из базы данных
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadProperty()
        If _Connection Is Nothing OrElse _Connection.State <> ConnectionState.Open Then Exit Sub
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format("SELECT * FROM vUser WHERE id = {0}", _id)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    _nameLong = Dr("nameLong").ToString
                    _nameShort = Dr("nameShort").ToString
                    _login = Dr("login").ToString
                    _email = Dr("email").ToString
                    _isACT = CBool(Dr("isACT"))
                    _isAdmin = CBool(Dr("isAdmin"))
                    _adminDescription = Dr("adminDescription").ToString
                    _isChief = CBool(Dr("isChief"))
                    _chiefDescription = Dr("chiefDescription").ToString
                    _isExpert = CBool(Dr("isExpert"))
                    _expertDescription = Dr("expertDescription").ToString
                    _isLeader = CBool(Dr("isLeader"))
                    _leaderDescription = Dr("leaderDescription").ToString
                    _isManager = CBool(Dr("isManager"))
                    _managerDescription = Dr("managerDescription").ToString
                    _isSubleader = CBool(Dr("isSubleader"))
                    _subleaderDescription = Dr("subleaderDescription").ToString
                End If
                Dr.Close()
            End Using
        End Using
    End Sub

#End Region

End Class
