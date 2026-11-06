Imports C2 = Cprp.DxData.Common
''' <summary>
''' Общие свойства и методы
''' </summary>
''' <remarks></remarks>
Public Class Common

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Возвращает True если в БД существует работа с указанным ID
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Function WorkExist(ByVal workId As Object, ByVal Connection As SqlConnection) As Boolean
        WorkExist = False
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tWork WHERE id = {0}", C2.ToInt(workId))
            Return (CInt(Cmd.ExecuteScalar) > 0)
        End Using
    End Function

    ''' <summary>
    ''' Возвращает вид работы по ID работы
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param> 
    Public Shared Function GetWorkTypeById(workId As Object, Connection As SqlConnection) As WorkType
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = String.Format("SELECT ISNULL (MAX(typeId), {1}) FROM tWork WHERE id = {0}", C2.ToInt(workId), C2.EMPTY_ID)
            'Clipboard.SetText(Cmd.CommandText)
            Return CType(Cmd.ExecuteScalar, WorkType)
        End Using
    End Function

    ''' <summary>
    ''' Запись в историю работы с плановой датой события
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="eventId">Идентификатор события</param>
    ''' <param name="userId">ID автора события</param>
    ''' <param name="comment">Комментарий к событию</param>
    ''' <param name="planeDate">Плановая дата события</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Sub WriteHistory(ByVal workId As Object, ByVal eventId As WorkEvent, ByVal userId As Object, ByVal comment As String, planeDate As Date, ByVal Connection As SqlConnection)
        If Not WorkExist(workId, Connection) Then Exit Sub
        comment = C2.ToText(comment)
        If C2.IsText(comment) AndAlso comment.Length > 1000 Then comment = comment.Substring(0, 1000)
        Dim R As DataRow = Nothing
        Using A As New SqlDataAdapter("SELECT * FROM tWorkHistory WHERE id IS NULL", Connection)
            Dim B As New SqlCommandBuilder(A)
            Using T As New DataTable
                A.Fill(T)
                R = T.NewRow
                R("workId") = C2.ToInt(workId)
                R("eventId") = CInt(eventId)
                R("eventDate") = Date.Now
                R("userId") = C2.ToInt(userId)
                R("comment") = C2.DbText(comment)
                If planeDate.Year > 2000 Then
                    R("planeDate") = C2.DbDate(planeDate)
                End If
                T.Rows.Add(R)
                A.Update(T)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Запись в историю работы без плановой даты
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="eventId">Идентификатор события</param>
    ''' <param name="userId">ID автора события</param>
    ''' <param name="comment">Комментарий к событию</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Sub WriteHistory(ByVal workId As Object, ByVal eventId As WorkEvent, ByVal userId As Object, ByVal comment As String, ByVal Connection As SqlConnection)
        WriteHistory(workId, eventId, userId, comment, Nothing, Connection)
    End Sub

    ''' <summary>
    ''' Запись в историю работы с плановой датой события c текущим пользователем
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="eventId">Идентификатор события</param>
    ''' <param name="comment">Комментарий к событию</param>
    ''' <param name="planeDate">Плановая дата события</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Sub WriteHistory(ByVal workId As Object, ByVal eventId As WorkEvent, ByVal comment As String, planeDate As Date, ByVal Connection As SqlConnection)
        WriteHistory(workId, eventId, Cprp.DxData.User.Common.CurrentUserId(Connection), comment, planeDate, Connection)
    End Sub


    ''' <summary>
    ''' Запись в историю работы без плановой даты события с текущим пользователем
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="eventId">Идентификатор события</param>
    ''' <param name="comment">Комментарий к событию</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Sub WriteHistory(ByVal workId As Object, ByVal eventId As WorkEvent, ByVal comment As String, ByVal Connection As SqlConnection)
        WriteHistory(workId, eventId, Cprp.DxData.User.Common.CurrentUserId(Connection), comment, Connection)
    End Sub

    ''' <summary>
    ''' Запись в таблицу возвратов
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="sourceId">ID источника ошибки (0 - заказчик, > 0 - ID сотрудника)</param>
    ''' <param name="comment">Комментарий к событию</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Sub WriteBack(ByVal workId As Object, ByVal sourceId As Object, ByVal comment As String, ByVal Connection As SqlConnection)
        If Not WorkExist(workId, Connection) Then Exit Sub
        comment = C2.ToText(comment)
        If C2.IsText(comment) AndAlso comment.Length > 1000 Then comment = comment.Substring(0, 1000)
        Dim R As DataRow = Nothing
        Using A As New SqlDataAdapter("SELECT * FROM tWorkBack WHERE id IS NULL", Connection)
            Dim B As New SqlCommandBuilder(A)
            Using T As New DataTable
                A.Fill(T)
                R = T.NewRow
                R("workId") = C2.ToInt(workId)
                R("eventDate") = Date.Now
                R("sourceId") = C2.ToInt(sourceId)
                If C2.IsText(comment) Then R("comment") = comment
                T.Rows.Add(R)
                A.Update(T)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Назначить исполнителя в работе
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="newExpertId">ID нового исполнителя</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="showQuestion">Задавать вопрос о подтверждении операции</param> 
    ''' <param name="sendEmail">Отправлять исполнителям почтовые сообщения о назначении работы</param> 
    Public Shared Function WorkTake(workId As Object, newExpertId As Object, Connection As SqlConnection, showQuestion As Boolean, sendEmail As Boolean) As Boolean
        If Not WorkExist(workId, Connection) Then Return False
        Using Cmd As New SqlCommand With {.Connection = Connection}
            '
            ' Реквизиты нового исполнителя
            '
            Dim newId As Integer = C2.ToInt(newExpertId)
            Dim newName As String = Nothing
            Dim newEmail As String = Nothing
            Cmd.CommandText = String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", newId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    newName = C2.ToText(Dr("nameShort"))
                    newEmail = C2.ToText(Dr("email"))
                Else
                    Return False
                End If
            End Using
            '
            ' Реквизиты старого исполнителя
            '
            Dim oldId As Integer = C2.EMPTY_ID
            Dim oldName As String = Nothing
            Dim oldEmail As String = Nothing
            Cmd.CommandText = String.Format("SELECT id, nameShort, email FROM tUser WHERE id IN (SELECT expertId FROM tWork WHERE id = {0})", C2.ToInt(workId))
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    oldId = C2.ToInt(Dr("id"))
                    oldName = C2.ToText(Dr("nameShort"))
                    oldEmail = C2.ToText(Dr("email"))
                End If
            End Using
            '
            ' Новый и старый исполнитель совпадают
            '
            If newId = oldId Then Return True
            '
            ' Реквизиты текущего пользователя
            '
            Dim userId As Integer = C2.ToInt(Cprp.DxData.User.Common.CurrentUserId(Connection))
            Dim userName As String = Nothing
            Dim userEmail As String = Nothing
            Cmd.CommandText = String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", userId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    userName = C2.ToText(Dr("nameShort"))
                    userEmail = C2.ToText(Dr("email"))
                End If
            End Using
            If Not C2.IsText(userEmail) Then userEmail = "system@excont.ru"
            '
            ' Вопрос о подтверждении операции
            '
            Dim sTmp As String = Nothing
            If showQuestion Then
                sTmp = String.Format("Исполнителем в работе № {0} будет назначен {1}.{2}Продолжить?", C2.ToInt(workId), C2.DelPoint(newName), vbCrLf)
                If Cprp.DxCommon.Messages.ShowQuestion(sTmp) <> DialogResult.Yes Then Return False
            End If
            '
            ' Проверка превышения срока распределения работы
            '
            Dim dTmp As New TimeSpan(0)
            Dim condition As WorkCondition = WorkCondition.IsEmpty
            Dim expertTerm As Date = Date.Now.AddYears(1)
            Cmd.CommandText = String.Format("SELECT conditionId, expertTerm FROM tWork WHERE id = {0}", C2.ToInt(workId))
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    If Not IsDBNull(Dr("conditionId")) Then condition = CType(Dr("conditionId"), WorkCondition)
                    If Not IsDBNull(Dr("expertTerm")) Then expertTerm = CDate(Dr("expertTerm"))
                End If
            End Using
            If condition = WorkCondition.IsNew Then dTmp = Date.Now - expertTerm
            '
            ' Назначение исполнителя, запись в историю работы
            '
            If condition = WorkCondition.IsNew Then
                '
                ' Новая работа - помимо исполнителя изменить срок эксперта (2 час с текущего момента) и состояние (подготовка плана)
                '
                Cmd.CommandText = String.Format( _
                    "UPDATE tWork SET expertId = {0}, expertTerm = {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}, conditionId = {2} WHERE id = {3}", _
                    newId, GetPlaneDate(Date.Now, 120), CInt(WorkCondition.IsPlaneWork), C2.ToInt(workId))
            Else
                Cmd.CommandText = String.Format("UPDATE tWork SET expertId = {0} WHERE id = {1}", newId, C2.ToInt(workId))
            End If
            Cmd.ExecuteNonQuery()
            sTmp = String.Format("{0} назначен исполнителем работы", newName)
            WriteHistory(workId, WorkEvent.ChangeExpert, userId, sTmp, Connection)
            If dTmp.Ticks > 0 Then
                WriteHistory(workId, DxData.Work.WorkEvent.TermOver, userId, String.Format("Превышение срока: {0}", dTmp.ToString), Connection)
            End If
            '
            ' Отправка почтовых сообщений
            '
            If sendEmail Then
                Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", Connection)
                Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", Connection)
                Dim sCapt As String = String.Format("НАЗНАЧЕНИЕ РАБОТЫ (Работа № {0})", C2.ToInt(workId))
                Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                    '
                    ' Сообщение новому исполнителю
                    '
                    If newId <> userId AndAlso C2.IsText(newEmail) Then
                        sTmp = String.Format("{0} назначил Вам работу № {1}.", userName, C2.ToInt(workId))
                        S.Send(userEmail, newEmail, sCapt, sTmp)
                    End If
                    '
                    ' Сообщение старому исполнителю
                    '
                    If oldId <> userId AndAlso C2.IsText(oldEmail) Then
                        If userId = newId Then
                            sTmp = String.Format("{0} назначил себе Вашу работу № {1}.", userName, C2.ToInt(workId))
                        Else
                            sTmp = String.Format("{0} назначил Вашу работу № {1} исполнителю {2}.", userName, C2.ToInt(workId), C2.DelPoint(newName))
                        End If
                        S.Send(userEmail, newEmail, sCapt, sTmp)
                    End If
                End Using
            End If
        End Using
        Return True
    End Function

    ''' <summary>
    ''' Делегировать работу руководителю экспертизы
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="newLeaderId">ID нового руководителя экспертизы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="showQuestion">Задавать вопрос о подтверждении операции</param> 
    ''' <param name="sendEmail">Отправлять руководителям почтовые сообщения о делегировании работы</param> 
    Public Shared Function WorkDelegate(workId As Object, newLeaderId As Object, Connection As SqlConnection, showQuestion As Boolean, sendEmail As Boolean) As Boolean
        If Not WorkExist(workId, Connection) Then Return False
        Using Cmd As New SqlCommand With {.Connection = Connection}
            '
            ' Реквизиты нового руководителя
            '
            Dim newId As Integer = C2.ToInt(newLeaderId)
            Dim newName As String = Nothing
            Dim newEmail As String = Nothing
            Cmd.CommandText = String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", newId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    newName = C2.ToText(Dr("nameShort"))
                    newEmail = C2.ToText(Dr("email"))
                Else
                    Return False
                End If
            End Using
            '
            ' Реквизиты старого руководителя
            '
            Dim oldId As Integer = C2.EMPTY_ID
            Dim oldName As String = Nothing
            Dim oldEmail As String = Nothing
            Cmd.CommandText = String.Format("SELECT id, nameShort, email FROM tUser WHERE id IN (SELECT leaderId FROM tWork WHERE id = {0})", C2.ToInt(workId))
            Cmd.ExecuteNonQuery()
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    oldId = C2.ToInt(Dr("id"))
                    oldName = C2.ToText(Dr("nameShort"))
                    oldEmail = C2.ToText(Dr("email"))
                End If
            End Using
            '
            ' Новый и старый руководитель экспертизы совпадают
            '
            If newId = oldId Then Return True
            '
            ' Реквизиты текущего пользователя
            '
            Dim userId As Integer = C2.ToInt(Cprp.DxData.User.Common.CurrentUserId(Connection))
            Dim userName As String = Nothing
            Dim userEmail As String = Nothing
            Cmd.CommandText = String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", userId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    userName = C2.ToText(Dr("nameShort"))
                    userEmail = C2.ToText(Dr("email"))
                End If
            End Using
            If Not C2.IsText(userEmail) Then userEmail = "system@excont.ru"
            '
            ' Вопрос о подтверждении операции
            '
            Dim sTmp As String = Nothing
            If showQuestion Then
                If newId = userId Then
                    sTmp = String.Format("Руководителем в работе № {0} является {1}.{2}Делегировать эту работу Вам?", C2.ToInt(workId), C2.DelPoint(oldName), vbCrLf)
                ElseIf oldId = userId Then
                    sTmp = String.Format("Делегировать Вашу работу № {0} руководителю {1}?", C2.ToInt(workId), C2.DelPoint(newName))
                Else
                    sTmp = String.Format("Делегировать работу № {0} от руководителя {1} руководителю {2}?", C2.ToInt(workId), oldName, C2.DelPoint(newName))
                End If
                If Cprp.DxCommon.Messages.ShowQuestion(sTmp) <> DialogResult.Yes Then Return False
            End If
            '
            ' Делегирование работы, запись в историю работы
            '
            Cmd.CommandText = String.Format("UPDATE tWork SET leaderId = {0} WHERE id = {1}", newId, C2.ToInt(workId))
            Cmd.ExecuteNonQuery()
            sTmp = String.Format("Делегирование работы от руководителя {0} руководителю {1}", oldName, newName)
            WriteHistory(workId, WorkEvent.ChangeLeader, userId, sTmp, Connection)
            '
            ' Отправка почтовых сообщений
            '
            If sendEmail Then
                Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", Connection)
                Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", Connection)
                Dim sCapt As String = String.Format("ДЕЛЕГИРОВАНИЕ РАБОТЫ (Работа № {0})", C2.ToInt(workId))
                Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                    '
                    ' Сообщение новому руководителю
                    '
                    If newId <> userId AndAlso C2.IsText(newEmail) Then
                        sTmp = String.Format("{0} делегировал Вам работу № {1}.", userName, C2.ToInt(workId))
                        S.Send(userEmail, newEmail, sCapt, sTmp)
                    End If
                    '
                    ' Сообщение старому руководителю
                    '
                    If oldId <> userId AndAlso C2.IsText(oldEmail) Then
                        If userId = newId Then
                            sTmp = String.Format("{0} делегировал себе Вашу работу № {1}.", userName, C2.ToInt(workId))
                        Else
                            sTmp = String.Format("{0} делегировал Вашу работу № {1} руководителю {2}.", userName, C2.ToInt(workId), C2.DelPoint(newName))
                        End If
                        S.Send(userEmail, oldEmail, sCapt, sTmp)
                    End If
                End Using
            End If
        End Using
        Return True
    End Function

    ''' <summary>
    ''' Назначить работу другому менеджеру
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="newManagerId">ID нового менеджера</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="showQuestion">Задавать вопрос о подтверждении операции</param> 
    ''' <param name="sendEmail">Отправлять менеджерам почтовые сообщения о назначении работы</param>
    Public Shared Function WorkManager(workId As Object, newManagerId As Object, Connection As SqlConnection, showQuestion As Boolean, sendEmail As Boolean) As Boolean
        If Not WorkExist(workId, Connection) Then Return False
        Using Cmd As New SqlCommand With {.Connection = Connection}
            '
            ' Реквизиты нового менеджера
            '
            Dim newId As Integer = C2.ToInt(newManagerId)
            Dim newName As String = Nothing
            Dim newEmail As String = Nothing
            Cmd.CommandText = String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", newId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    newName = C2.ToText(Dr("nameShort"))
                    newEmail = C2.ToText(Dr("email"))
                Else
                    Return False
                End If
            End Using
            '
            ' Реквизиты старого менеджера
            '
            Dim oldId As Integer = C2.EMPTY_ID
            Dim oldName As String = Nothing
            Dim oldEmail As String = Nothing
            Cmd.CommandText = String.Format("SELECT id, nameShort, email FROM tUser WHERE id IN (SELECT managerId FROM tWork WHERE id = {0})", C2.ToInt(workId))
            Cmd.ExecuteNonQuery()
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    oldId = C2.ToInt(Dr("id"))
                    oldName = C2.ToText(Dr("nameShort"))
                    oldEmail = C2.ToText(Dr("email"))
                End If
            End Using
            '
            ' Новый и старый менеджер совпадают
            '
            If newId = oldId Then Return True
            '
            ' Реквизиты текущего пользователя
            '
            Dim userId As Integer = C2.ToInt(Cprp.DxData.User.Common.CurrentUserId(Connection))
            Dim userName As String = Nothing
            Dim userEmail As String = Nothing
            Cmd.CommandText = String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", userId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    userName = C2.ToText(Dr("nameShort"))
                    userEmail = C2.ToText(Dr("email"))
                End If
            End Using
            If Not C2.IsText(userEmail) Then userEmail = "system@excont.ru"
            '
            ' Вопрос о подтверждении операции
            '
            Dim sTmp As String = Nothing
            If showQuestion Then
                sTmp = String.Format("Менеджером в работе № {0} будет назначен {1}.{2}Продолжить?", C2.ToInt(workId), C2.DelPoint(newName), vbCrLf)
                If Cprp.DxCommon.Messages.ShowQuestion(sTmp) <> DialogResult.Yes Then Return False
            End If
            '
            ' Назначение менеджера в работе, запись в историю работы
            '
            Cmd.CommandText = String.Format("UPDATE tWork SET managerId = {0} WHERE id = {1}", newId, C2.ToInt(workId))
            Cmd.ExecuteNonQuery()
            sTmp = String.Format("{0} назначен менежером в работе", newName)
            WriteHistory(workId, WorkEvent.ChangeManager, userId, sTmp, Connection)
            '
            ' Отправка почтовых сообщений
            '
            If sendEmail Then
                Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", Connection)
                Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", Connection)
                Dim sCapt As String = String.Format("НАЗНАЧЕНИЕ РАБОТЫ (Работа № {0})", C2.ToInt(workId))
                Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                    '
                    ' Сообщение новому исполнителю
                    '
                    If newId <> userId AndAlso C2.IsText(newEmail) Then
                        sTmp = String.Format("{0} назначил Вас менеджером в работе № {1}.", userName, C2.ToInt(workId))
                        S.Send(userEmail, newEmail, sCapt, sTmp)
                    End If
                    '
                    ' Сообщение старому исполнителю
                    '
                    If oldId <> userId AndAlso C2.IsText(oldEmail) Then
                        If userId = newId Then
                            sTmp = String.Format("{0} назначил себе Вашу работу № {1}.", userName, C2.ToInt(workId))
                        Else
                            sTmp = String.Format("{0} назначил Вашу работу № {1} менеджеру {2}.", userName, C2.ToInt(workId), C2.DelPoint(newName))
                        End If
                        S.Send(userEmail, newEmail, sCapt, sTmp)
                    End If
                End Using
            End If
        End Using
        Return True
    End Function


#Region "Доступ пользователей к работам"

    ''' <summary>
    ''' Время доступа руководителей к работе ограничено
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks>
    ''' Возвращает True в следующих случаях:
    ''' - работая является заявкой на оказание услуг;
    ''' - работа находится в состоянии утверждения плана;
    ''' - работа находится в состоянии утверждения работы;
    ''' - в работе есть запрос в состоянии утверждения.
    ''' </remarks>
    Public Shared Function IsWorkAccessLimited(workId As Object, Connection As SqlConnection) As Boolean
        If Not WorkExist(workId, Connection) Then Return False
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format( _
                "SELECT COUNT(*) FROM tWork WHERE id = {0} AND " & _
                "(typeId = {1} OR conditionId = {2} OR conditionId = {3} OR isAsk = 1)", _
                C2.ToInt(workId), CInt(WorkType.IsOrder), CInt(WorkCondition.IsPlaneAgree), CInt(WorkCondition.IsAgree))
            Return CInt(Cmd.ExecuteScalar) > 0
        End Using
    End Function

    ''' <summary>
    ''' Возвращает ФИО пользователя, открывшего карточку с работой
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks>Если работу никто не открывал, возвращает Nothing</remarks>
    Public Shared Function WorkAccessUserName(workId As Object, Connection As SqlConnection) As String
        Dim wId As Integer = C2.ToInt(workId)
        If wId < 1 Then Return Nothing
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tWorkOpen WHERE workId = {0}", wId)
            If CInt(Cmd.ExecuteScalar) = 0 Then Return Nothing
            Cmd.CommandText = String.Format("SELECT userName FROM vWorkOpen WHERE workId = {0}", wId)
            Return Cmd.ExecuteScalar.ToString
        End Using
    End Function

    ''' <summary>
    ''' Добавить пользователя в таблицу доступа к работе
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="userId">ID пользователя</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Sub WorkAccessAdd(workId As Object, userId As Object, Connection As SqlConnection)
        If Not WorkExist(workId, Connection) Then Exit Sub
        If Not Cprp.DxData.User.Common.UserExist(userId, Connection) Then Exit Sub
        Dim wId As Integer = C2.ToInt(workId)
        Dim uId As Integer = C2.ToInt(userId)
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tWorkOpen WHERE workId = {0} AND userId = {1}", wId, uId)
            If CInt(Cmd.ExecuteScalar) > 0 Then Exit Sub
            Cmd.CommandText = String.Format("INSERT tWorkOpen (workId, userId, openDate) VALUES({0}, {1}, {{ts '{2:yyyy-MM-dd HH:mm:ss}'}})", wId, uId, Date.Now)
            Cmd.ExecuteNonQuery()
        End Using
    End Sub

    ''' <summary>
    ''' Удалить пользователя из таблицы доступа к работе
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="userId">ID пользователя</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks>
    ''' Если workId меньще 1 из таблицы удаляются все записи, связанные с указанным пользователем.
    ''' Если userId меньше 1 из таблицы удаляются все записи, связанные с указанной работой.
    ''' </remarks>
    Public Shared Sub WorkAccessDelete(workId As Object, userId As Object, Connection As SqlConnection)
        Dim wId As Integer = C2.ToInt(workId)
        Dim uId As Integer = C2.ToInt(userId)
        If wId < 1 AndAlso uId < 1 Then Exit Sub
        Using Cmd As SqlCommand = Connection.CreateCommand
            If wId < 1 Then
                Cmd.CommandText = String.Format("DELETE FROM tWorkOpen WHERE userId = {0}", uId)
            ElseIf uId < 1 Then
                Cmd.CommandText = String.Format("DELETE FROM tWorkOpen WHERE workId = {0}", wId)
            Else
                Cmd.CommandText = String.Format("DELETE FROM tWorkOpen WHERE workId = {0} AND userId = {1}", wId, uId)
            End If
            Cmd.ExecuteNonQuery()
        End Using
    End Sub

#End Region


    ' ''' <summary>
    ' ''' Возвращает плановый срок с учетом нерабочего времени и выходных
    ' ''' </summary>
    ' ''' <param name="startDate">Дата начала отчета</param> 
    ' ''' <param name="minuteCount">Количество отведенных минут на выполнение работы</param>
    ' ''' <param name="isRoundMinute">Округлять минуты</param>
    ' ''' <remarks>Рабочее время - с 9.00 до 18.00 будних дней</remarks>
    'Public Shared Function GetPlaneDate(startDate As Date, minuteCount As Integer, Optional isRoundMinute As Boolean = True) As Date
    '    '
    '    ' Предварительный плановый срок = 9.00 даты начала отчета
    '    '
    '    Dim planeDate As Date = New Date(startDate.Year, startDate.Month, startDate.Day, 9, 0, 0)
    '    '
    '    ' Если время начала отчета > 18.00, то плановый срок = 9.00 следующего дня
    '    '
    '    If startDate.Hour > 18 OrElse (startDate.Hour = 18 AndAlso startDate.Minute > 0) Then
    '        planeDate = planeDate.AddDays(1)
    '    ElseIf startDate.Hour > 8 Then
    '        '
    '        ' Если время начала отчета >= 9.00, то увеличиваем количество отведенных минут на разницу между временем начала отчета и 9.00
    '        '
    '        With (startDate - planeDate)
    '            minuteCount += (.Hours * 60)
    '            minuteCount += .Minutes
    '        End With
    '    End If
    '    '
    '    ' Добавляем к предварительному сроку количество полных рабочих дней в количестве отведенных минут с учетом выходных дней
    '    '
    '    For i As Integer = 1 To (minuteCount \ (8 * 60))
    '        planeDate = planeDate.AddDays(1)
    '        If planeDate.DayOfWeek = DayOfWeek.Saturday Then planeDate = planeDate.AddDays(2)
    '        If planeDate.DayOfWeek = DayOfWeek.Sunday Then planeDate = planeDate.AddDays(1)
    '    Next
    '    '
    '    ' Добавляем к плановому сроку количество минут за вычетом полных рабочих дней
    '    '
    '    planeDate = planeDate.AddMinutes(minuteCount Mod (8 * 60))
    '    '
    '    ' Учет перерыва на обед (с 13.00 до 14.00)
    '    '
    '    'If planeDate.Hour > 12 Then planeDate = planeDate.AddHours(1)
    '    '
    '    ' Если плановое время > 18.00, то переносим плановый срок на следующий день
    '    '
    '    If planeDate.Hour > 18 OrElse (planeDate.Hour = 18 AndAlso planeDate.Minute > 0) Then
    '        planeDate = New Date(planeDate.Year, planeDate.Month, planeDate.Day, 9 + planeDate.Hour - 18, planeDate.Minute, 0).AddDays(1)
    '    End If
    '    '
    '    ' Учет выходных дней
    '    '
    '    If planeDate.DayOfWeek = DayOfWeek.Saturday Then planeDate = planeDate.AddDays(2)
    '    If planeDate.DayOfWeek = DayOfWeek.Sunday Then planeDate = planeDate.AddDays(1)
    '    '
    '    ' Округление минут
    '    '
    '    If isRoundMinute Then
    '        While planeDate.Minute Mod 10 <> 0
    '            planeDate = planeDate.AddMinutes(1)
    '        End While
    '    End If
    '    '
    '    ' Возвращаемое значение
    '    '
    '    Return planeDate
    'End Function


    ''' <summary>
    ''' Возвращает расчетный срок исполнения
    ''' </summary>
    ''' <param name="startDate">Дата начала отсчета</param>
    ''' <param name="minuteCount">Время исполнения в минутах</param>
    ''' <param name="isRoundMinute">Округлять минуты до 10</param>
    Public Shared Function GetPlaneDate(startDate As Date, minuteCount As Integer, Optional isRoundMinute As Boolean = True) As Date

        Dim hStart As Integer = 9   ' Час начала рабочего дня
        Dim hEnd As Integer = 18    ' Час конца рабочего дня
        '
        ' Продолжительность рабочего дня в минутах
        ' 60 x (час конца - час начала - час на перерыв)
        '
        Dim mCount As Integer = 60 * (hEnd - hStart - 1)
        '
        ' Приведение даты начала отсчета
        '
        If startDate.Hour < hStart Then
            '
            ' Если время начала меньше времени начала рабочего дня, то дата равна началу текущего рабочего дня
            '
            startDate = New Date(startDate.Year, startDate.Month, startDate.Day, hStart, 0, 0)

        ElseIf startDate.Hour > hEnd OrElse (startDate.Hour = hEnd AndAlso startDate.Minute > 0) Then
            '
            ' Если время начала больше времени конца рабочего дня, то дата равна началу следующего рабочего дня
            '
            startDate = startDate.AddDays(1)
            startDate = New Date(startDate.Year, startDate.Month, startDate.Day, hStart, 0, 0)

        End If
        '
        ' Увеличение даты начала на количество рабочих дней, входящих во время исполнения
        '
        Do
            ' Перенос даты с выходных дней на понедельник
            If startDate.DayOfWeek = DayOfWeek.Saturday Then startDate = startDate.AddDays(2)
            If startDate.DayOfWeek = DayOfWeek.Sunday Then startDate = startDate.AddDays(1)
            ' Если время исполнения меньше продолжительности рабочего дня, то выход из цикла
            If minuteCount - mCount < 0 Then Exit Do
            ' Добавление одного дня
            startDate = startDate.AddDays(1)
            ' Уменьшение времени исполнения на продолжительность рабочего дня
            minuteCount -= mCount
        Loop
        '
        ' Увеличение даты до конца рабочего дня, если позволяет остаток времени исполнения
        '
        Dim endDate As Date = New Date(startDate.Year, startDate.Month, startDate.Day, hEnd, 0, 0)
        While startDate < endDate
            If minuteCount = 0 Then Exit While
            startDate = startDate.AddMinutes(1)
            minuteCount -= 1
        End While
        '
        ' Если остаток времени исполнения больше 0, то перенести дату на начало следющего рабочего дня 
        ' и прибавить к ней остаток времени
        '
        If minuteCount > 0 Then
            startDate = startDate.AddDays(1)
            startDate = New Date(startDate.Year, startDate.Month, startDate.Day, hStart, 0, 0)
            startDate = startDate.AddMinutes(minuteCount)
            If startDate.DayOfWeek = DayOfWeek.Saturday Then startDate = startDate.AddDays(2)
            If startDate.DayOfWeek = DayOfWeek.Sunday Then startDate = startDate.AddDays(1)
        End If
        '
        ' Округление минут до 10
        '
        If isRoundMinute Then
            While startDate.Minute Mod 10 <> 0
                startDate = startDate.AddMinutes(1)
            End While
        End If

        Return startDate

    End Function

    ''' <summary>
    ''' Возвращает количество рабочих минут между двумя плановыми датами
    ''' </summary>
    ''' <param name="startDate">Дата начала отчета</param> 
    ''' <param name="endDate">Дата конца отчета</param>
    ''' <remarks>Рабочее время - с 9.00 до 18.00 будних дней</remarks>
    Public Shared Function GetPlaneDateInterval(startDate As Date, endDate As Date) As Integer
        Dim iTmp As Integer = 1
        Do
            If GetPlaneDate(startDate, iTmp) > endDate Then Exit Do
            iTmp += 1
        Loop
        Return iTmp - 1
    End Function

    ''' <summary>
    ''' Возвращает направление перемещения по характеру внешнеэкономической операции
    ''' </summary>
    ''' <param name="supplyType">Характер внешнеэкономической операции</param>
    Public Shared Function GetModeBySupplyType(supplyType As SupplyType) As Cprp.DxData.ModeEnum
        Select Case supplyType
            Case Work.SupplyType.IsExport, Work.SupplyType.IsExportAfterImportTemp, Work.SupplyType.IsExportRepair, Work.SupplyType.IsExportShip, Work.SupplyType.IsExportTemp, _
                Work.SupplyType.IsExportNew, Work.SupplyType.IsDelivery, Work.SupplyType.IsAbsent
                Return ModeEnum.isExport
            Case Work.SupplyType.IsImport, Work.SupplyType.IsImportAfterExportTemp, Work.SupplyType.IsImportRepair, Work.SupplyType.IsImportTemp, _
                Work.SupplyType.IsImportNew
                Return ModeEnum.isImport
            Case Else
                Return ModeEnum.isBoth
        End Select
    End Function


    ''' <summary>
    ''' Остановить выполнение работы
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Function WorkStop(workId As Object, Connection As SqlConnection) As Boolean
        If Not WorkExist(workId, Connection) Then Return False
        Dim comment As String = Nothing
        Using F As New WorkStopForm
            F.Text = String.Format("Работа № {0} - Остановка выполнения", CInt(workId))
            If F.ShowDialog <> DialogResult.OK Then Return False
            comment = F.Comment
        End Using
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("UPDATE tWork SET isStop = 1 WHERE id = {0}", CInt(workId))
            Cmd.ExecuteNonQuery()
        End Using
        WriteHistory(workId, WorkEvent.WorkStop, comment, Connection)
        '
        ' Сообщения эксперту и менеджеру о приостановке работы
        '
        Dim caption As String = String.Format("Работа № {0} - Остановка выполнения", CInt(workId))
        Dim body As String = String.Format("Руководитель экспертизы остановил выполнение Вашей работы № {0}, заказ № NNN.{1}Причина остановки:{1}{2}.", CInt(workId), vbCrLf, comment)
        Dim userId As Integer = CInt(Cprp.DxData.User.Common.CurrentUserId(Connection))
        Dim expertId As Integer = C2.EMPTY_ID
        Dim managerId As Integer = C2.EMPTY_ID
        Dim orderNum As String = Nothing
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT expertId, managerId, orderNum FROM tWork WHERE id = {0}", CInt(workId))
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    expertId = C2.ToInt(Dr("expertId"))
                    managerId = C2.ToInt(Dr("managerId"))
                    orderNum = C2.ToText(Dr("orderNum"))
                End If
            End Using
        End Using
        body = body.Replace("NNN", orderNum)
        If expertId > 0 Then Cprp.DxData.Mail.Send(Connection, userId, expertId, caption, body)
        If managerId > 0 Then Cprp.DxData.Mail.Send(Connection, userId, managerId, caption, body)
        Return True
    End Function

    ''' <summary>
    ''' Возобновить выполнение работы
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Function WorkStart(workId As Object, Connection As SqlConnection) As Boolean
        If Not WorkExist(workId, Connection) Then Return False
        Dim comment As String = Nothing
        Dim expertTerm As Date = CDate("01.01.2001")
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT expertTerm FROM tWork WHERE id = {0} AND NOT expertTerm IS NULL", CInt(workId))
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then expertTerm = CDate(Dr(0))
            End Using
        End Using
        If expertTerm < Date.Now.AddMinutes(120) Then expertTerm = GetPlaneDate(Date.Now, 120)

        Using F As New WorkStartForm
            F.Text = String.Format("Работа № {0} - Возобновление выполнения", CInt(workId))
            F.TermDateEdit.EditValue = expertTerm
            If F.ShowDialog <> DialogResult.OK Then Return False
            comment = F.Comment
            expertTerm = F.ExpertTerm
        End Using
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("UPDATE tWork SET isStop = 0, expertTerm = {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} WHERE id = {0}", CInt(workId), expertTerm)
            Cmd.ExecuteNonQuery()
        End Using
        WriteHistory(workId, WorkEvent.WorkStart, comment, Connection)
        '
        ' Сообщения эксперту и менеджеру о возобновлении работы
        '
        Dim caption As String = String.Format("Работа № {0} - Возобновление выполнения", CInt(workId))
        Dim body As String = String.Format("Руководитель экспертизы возобновил выполнение Вашей работы № {0}, заказ № NNN.", CInt(workId))
        Dim userId As Integer = CInt(Cprp.DxData.User.Common.CurrentUserId(Connection))
        Dim expertId As Integer = C2.EMPTY_ID
        Dim managerId As Integer = C2.EMPTY_ID
        Dim orderNum As String = Nothing
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT expertId, managerId, orderNum FROM tWork WHERE id = {0}", CInt(workId))
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    expertId = C2.ToInt(Dr("expertId"))
                    managerId = C2.ToInt(Dr("managerId"))
                    orderNum = C2.ToText(Dr("orderNum"))
                End If
            End Using
        End Using
        body = body.Replace("NNN", orderNum)
        If expertId > 0 Then Cprp.DxData.Mail.Send(Connection, userId, expertId, caption, body)
        If managerId > 0 Then Cprp.DxData.Mail.Send(Connection, userId, managerId, caption, body)
        Return True
    End Function

    ' ''' <summary>
    ' ''' Пересчитать срок выдачи работы и записать в базу данных
    ' ''' </summary>
    ' ''' <param name="workId">ID работы</param>
    ' ''' <param name="Connection">Открытое соединение с базой данных</param>
    ' ''' <remarks></remarks>
    'Public Shared Sub UpdateWorkOrderTerm(workId As Object, Connection As SqlConnection)
    '    Dim expertTerm As Date = Nothing                ' срок эксперта
    '    Dim paymentDate As Date = Nothing               ' дата оплаты
    '    Dim urgency As UrgencyType = UrgencyType.IsNone ' срочность
    '    Dim orderTerm As Date = Nothing                 ' срок выдачи работы
    '    Dim iTmp As Integer = C2.EMPTY_ID
    '    Using Cmd As SqlCommand = Connection.CreateCommand
    '        Cmd.CommandText = String.Format("SELECT expertTerm, paymentDate, urgencyId, price, agreementNum, createDate FROM tWork WHERE id = {0}", workId.ToString)
    '        Using Dr As SqlDataReader = Cmd.ExecuteReader
    '            If Not Dr.Read Then
    '                Dr.Close()
    '                Exit Sub
    '            End If
    '            If Not IsDBNull(Dr("expertTerm")) Then expertTerm = CDate(Dr("expertTerm"))
    '            If Not IsDBNull(Dr("paymentDate")) Then paymentDate = CDate(Dr("paymentDate"))
    '            If Not IsDBNull(Dr("urgencyId")) Then urgency = CType(Dr("urgencyId"), UrgencyType)
    '            If Not IsDBNull(Dr("price")) Then iTmp = CInt(Dr("price"))
    '            ' Работа по договору априори считается оплаченной
    '            If paymentDate = Nothing AndAlso C2.IsText(Dr("agreementNum")) Then paymentDate = CDate(Dr("createDate"))
    '            Dr.Close()
    '        End Using
    '        If expertTerm = Nothing OrElse (paymentDate = Nothing AndAlso iTmp <> 0) Then
    '            orderTerm = Nothing
    '        Else
    '            Select Case urgency
    '                Case UrgencyType.IsHigh
    '                    iTmp = 4 * 60
    '                    Exit Select
    '                Case UrgencyType.IsElevated
    '                    iTmp = 8 * 60
    '                    Exit Select
    '                Case Else
    '                    iTmp = 16 * 60
    '            End Select
    '            orderTerm = GetPlaneDate(paymentDate, iTmp, True)
    '            expertTerm = GetPlaneDate(expertTerm, 2 * 60, True)
    '            If orderTerm < expertTerm Then orderTerm = expertTerm
    '        End If
    '        If orderTerm = Nothing Then
    '            Cmd.CommandText = String.Format("UPDATE tWork SET orderTerm = NULL WHERE id = {0}", workId.ToString)
    '        Else
    '            Cmd.CommandText = String.Format("UPDATE tWork SET orderTerm = {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} WHERE id = {1}", orderTerm, workId.ToString)
    '        End If
    '        Cmd.ExecuteNonQuery()
    '    End Using
    'End Sub

End Class
