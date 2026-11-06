Imports System.Data.SqlClient
Imports Cprp.DxData.Common
''' <summary>
''' Класс для работы с электронной почтой
''' </summary>
Public Class Mail

    ''' <summary>
    ''' Открытое соединение с базой данных
    ''' </summary>
    Private Connection As SqlConnection = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(Connection As SqlConnection)
        Me.Connection = Connection
    End Sub


    ''' <summary>
    ''' Отправить сообщение
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="senderId">ID отправителя</param>
    ''' <param name="recipientId">ID получателя</param>
    ''' <param name="caption">Заголовок сообщения</param>
    ''' <param name="body">Содержание сообщения</param>
    Public Shared Sub Send(Connection As SqlConnection, senderId As Object, recipientId As Object, caption As String, body As String)
        Dim senderEmail As String = "system@excont.ru"
        Dim recipientEmail As String = Nothing
        Dim host As String = Nothing
        Dim port As Integer = EMPTY_ID
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT email FROM tUser WHERE id = {0}", ToInt(senderId))
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then senderEmail = ToText(Dr(0))
            End Using
            Cmd.CommandText = String.Format("SELECT email FROM tUser WHERE id = {0}", ToInt(recipientId))
            recipientEmail = ToText(Cmd.ExecuteScalar)
            Cmd.CommandText = "SELECT strData FROM tResource WHERE name LIKE 'SMTPHOST'"
            host = ToText(Cmd.ExecuteScalar)
            Cmd.CommandText = "SELECT strData FROM tResource WHERE name LIKE 'SMTPPORT'"
            port = ToInt(Cmd.ExecuteScalar)
        End Using
        Using S As New System.Net.Mail.SmtpClient(host, port)
            S.Send(senderEmail, recipientEmail, Trim(caption), Trim(body))
        End Using
    End Sub

    ''' <summary>
    ''' Отправить сообщение
    ''' </summary>
    ''' <param name="senderId">ID отправителя</param>
    ''' <param name="recipientId">ID получателя</param>
    ''' <param name="caption">Заголовок сообщения</param>
    ''' <param name="body">Содержание сообщения</param>
    Public Sub Send(senderId As Object, recipientId As Object, caption As String, body As String)
        Cprp.DxData.Mail.Send(Me.Connection, senderId, recipientId, caption, body)
    End Sub

End Class
