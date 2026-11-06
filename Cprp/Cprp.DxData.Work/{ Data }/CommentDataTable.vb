Imports Cprp.DxData.Common
''' <summary>
''' Таблица комментариев
''' </summary>
Public Class WorkCommentDataTable : Inherits DataTable

    ''' <summary>
    ''' Работа
    ''' </summary>
    Private Work As WorkConnectionRow = Nothing


    Public Sub New(Work As WorkConnectionRow)
        '
        ' Me
        '
        MyBase.New("WorkCommentTable")
        With Me.Columns
            With .Add("id", GetType(Integer))
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            With .Add("workId", GetType(Integer))
                .AllowDBNull = False
            End With
            With .Add("createDate", GetType(Date))
                .AllowDBNull = False
            End With
            With .Add("authorId", GetType(Integer))
                .AllowDBNull = False
            End With
            With .Add("authorName", GetType(String))
                .AllowDBNull = False
            End With
            With .Add("comment", GetType(String))
                .AllowDBNull = False
                .MaxLength = 1500
            End With
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' Work
        '
        Me.Work = Work

    End Sub

    ''' <summary>
    ''' Загрузить данные из базы
    ''' </summary>
    Public Sub DataLoad()
        Try
            Using Cn As New SqlConnection
                Cn.ConnectionString = Work.Connection.ConnectionString
                Cn.Open()
                Me.Rows.Clear()
                Using Cmd As SqlCommand = Cn.CreateCommand
                    Cmd.CommandText = String.Format("SELECT id, workId, createDate, authorId, authorName, comment FROM vWorkComment WHERE workId = {0}", ToInt(Work.Id))
                    Me.Load(Cmd.ExecuteReader)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Сохранить данные в базу
    ''' </summary>
    Public Sub DataSave()
        Try
            Using Cn As New SqlConnection
                Cn.ConnectionString = Work.Connection.ConnectionString
                Cn.Open()
                Using A As New SqlDataAdapter("SELECT id, workId, createDate, authorId, comment FROM tWorkComment", Cn)
                    Dim B As New SqlCommandBuilder(A)
                    A.Update(Me)
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Добавить новый коментарий и сохранить в базу данных
    ''' </summary>
    ''' <param name="createDate">Дата создания</param>
    ''' <param name="authorId">ID автора комментария</param> 
    ''' <param name="comment">Комментарий</param>
    ''' <param name="sendEmail">Отправить сообщение по электронной почте</param>
    Public Sub AddComment(createDate As Date, authorId As Integer, comment As String, Optional sendEmail As Boolean = True)
        comment = ToText(comment)
        If String.IsNullOrWhiteSpace(comment) Then Exit Sub
        Dim maxLenght = Me.Columns("comment").MaxLength
        If comment.Length > maxLenght Then comment = comment.Substring(0, maxLenght)
        ' authorName
        Dim authorName As String = Nothing
        Using Cn As New SqlConnection
            Cn.ConnectionString = Work.Connection.ConnectionString
            Cn.Open()
            Using Cmd As SqlCommand = Cn.CreateCommand
                Cmd.CommandText = String.Format("SELECT nameShort FROM tUser WHERE id = {0}", authorId)
                authorName = ToText(Cmd.ExecuteScalar)
            End Using
        End Using
        ' новая запись в tWorkComment
        Dim Row As DataRow = Me.NewRow
        Row("workid") = ToInt(Work.Id)
        Row("createDate") = createDate
        Row("authorId") = authorId
        Row("authorName") = authorName
        Row("comment") = comment
        Me.Rows.Add(Row)
        Me.DataSave()
        ' обновление поля "comment" в tWork
        Work("comment") = comment
        Using Cn As New SqlConnection
            Cn.ConnectionString = Work.Connection.ConnectionString
            Cn.Open()
            Using Cmd As SqlCommand = Cn.CreateCommand
                Cmd.CommandText = String.Format("UPDATE tWork SET comment = '{0}' WHERE id = {1}", comment.Replace("'", Nothing), ToInt(Work.Id))
                Cmd.ExecuteNonQuery()
            End Using
        End Using
        ' отправка почтовых сообщений
        If sendEmail AndAlso Not (String.IsNullOrWhiteSpace(authorName) OrElse authorName.ToUpper Like "*СИСТЕМА*") Then
            Dim caption As String = String.Format("Работа № {0} (Заказ № {1}, заказчик - {2})", ToText(Work.Id), ToText(Work("orderNum")), ToText(Work("clientName")))
            'Dim body As String = String.Format("{0} добавил(а) новый комментарий к работе:{1}{2}", authorName, vbCrLf, comment)
            Dim body As String = String.Format("Добавлен новый комментарий к работе:{0}{0}", vbCrLf)
            With Me.DefaultView
                .Sort = "createDate DESC"
                For i As Integer = 0 To .Count - 1
                    If i = 1 Then body = String.Format("{0}{1}", body, vbCrLf)
                    If i > 0 Then body = String.Format("{0}*****{1}", body, vbCrLf)
                    body = String.Format("{0}{1:dd.MM.yyyy HH:mm} {2}:{3}{4}{3}", _
                                         body, _
                                         CDate(.Item(i)("createDate")), _
                                         DelPoint(.Item(i)("authorName")), _
                                         vbCrLf, _
                                         ToText(.Item(i)("comment")))
                Next
            End With
            Using Cn As New SqlConnection
                Try
                    Cn.ConnectionString = Work.Connection.ConnectionString
                    Cn.Open()
                    Dim recipientId As Integer = ToInt(Work("leaderId"))
                    If recipientId > 0 AndAlso recipientId <> authorId Then
                        Cprp.DxData.Mail.Send(Cn, authorId, recipientId, caption, body)
                    End If
                    recipientId = ToInt(Work("expertId"))
                    If recipientId > 0 AndAlso recipientId <> authorId Then
                        Cprp.DxData.Mail.Send(Cn, authorId, recipientId, caption, body)
                    End If
                    recipientId = ToInt(Work("managerId"))
                    If recipientId > 0 AndAlso recipientId <> authorId Then
                        Cprp.DxData.Mail.Send(Cn, authorId, recipientId, caption, body)
                    End If
                Catch ex As Exception
                    If Cn.State = ConnectionState.Open Then Cn.Close()
                    Cn.Dispose()
                    Exit Try
                End Try
            End Using
        End If

    End Sub

End Class
