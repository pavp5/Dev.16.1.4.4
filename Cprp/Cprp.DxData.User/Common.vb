Imports C2 = Cprp.DxData.Common
''' <summary>
''' Общие свойства и методы
''' </summary>
''' <remarks></remarks>
Public Class Common

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Возвращает True если в БД существует пользователь с указанным ID
    ''' </summary>
    ''' <param name="userId">ID пользователя</param> 
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Shared Function UserExist(userId As Object, Connection As SqlConnection) As Boolean
        UserExist = False
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tUser WHERE id = {0}", C2.ToInt(userId))
            Return CInt(Cmd.ExecuteScalar) > 0
        End Using
    End Function

    ''' <summary>
    ''' Возращает ID текущего пользователя базы данных
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property CurrentUserId(ByVal Connection As SqlConnection) As Object
        Get
            Dim id As Object = DBNull.Value
            Using Cmd As New SqlCommand With {.Connection = Connection}
                Cmd.CommandText = "SELECT id FROM tUser WHERE ((SELECT SYSTEM_USER) LIKE ('%' + tUser.login))"
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    If Dr.Read Then id = Dr(0)
                    Dr.Close()
                End Using
            End Using
            Return id
        End Get
    End Property

    ''' <summary>
    ''' Возвращает должность chr(1) ФИО руководителя экспертизы
    ''' </summary>
    ''' <param name="userId">ID пользователя</param> 
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Shared ReadOnly Property LeaderJobName(userId As Object, Connection As SqlConnection) As String
        Get
            Dim job As String = Nothing
            Dim name As String = Nothing
            Using Cmd As New SqlCommand With {.Connection = Connection}
                Cmd.CommandText = String.Format( _
                    "SELECT tUserLeader.description AS job, tUser.nameLong AS name FROM tUserLeader " & _
                    "LEFT JOIN tUser ON tUserLeader.userId = tUser.id " & _
                    "WHERE tUserLeader.userId = {0}", C2.ToInt(userId))
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    If Dr.Read Then
                        job = C2.ToText(Dr("job"))
                        name = C2.ToText(Dr("name"))
                    End If
                    Dr.Close()
                End Using
            End Using
            If C2.IsText(job) AndAlso C2.IsText(name) Then
                Return String.Format("{0}{1}{2}", job, C2.FIELD_SEPARATOR, name)
            End If
            Return Nothing
        End Get
    End Property

End Class
