Imports Cprp.DxData.Common
Imports Cprp.DxData.Work
''' <summary>
''' Форма снятия запроса
''' </summary>
Friend Class QueryCloseForm

    ' Работа
    Private Work As WorkConnectionRow = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Friend Sub New(workId As Object)
        InitializeComponent()
        '
        ' Work
        '
        Dim type As WorkType = Cprp.DxData.Work.Common.GetWorkTypeById(workId, Program.DbClient.Connection)
        Select Case type
            Case WorkType.IsExCont : Work = New Excont.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case WorkType.IsCustomUnion : Work = New Customs.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case WorkType.IsMilitary : Work = New Military.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case WorkType.IsTnved : Work = New Tnved.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case WorkType.IsLiconfirm : Work = New Liconfirm.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case WorkType.IsConsultation : Work = New Consultation.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case WorkType.IsOrder : Work = New Order.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case WorkType.IsAlteration : Work = New Alteration.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case Else : Exit Sub
        End Select      
        '
        ' TermDateEdit 
        '
        If Not IsDBNull(Work("expertTerm")) Then
            TermDateEdit.EditValue = CDate(Work("expertTerm"))
        Else
            TermDateEdit.EditValue = Date.Now
        End If
        '
        ' Me
        '
        Me.Text = String.Format("Снятие запроса - Работа № {0}", ToInt(Work.Id))
        Me.CenterToScreen()
    End Sub


    Private Sub QueryCloseForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Work Is Nothing OrElse Work.IsEmpty Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If TermDateEdit.EditValue Is Nothing OrElse IsDBNull(TermDateEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowError("Укажите новый срок эксперта!")
            Exit Sub
        End If
        Dim expertTerm As Date = CDate(TermDateEdit.EditValue)
        If expertTerm < Date.Now Then
            Cprp.DxCommon.Messages.ShowError("Срок эксперта меньше текущей даты/времени, укажите корректный срок!")
            Exit Sub
        End If
        Work("expertTerm") = expertTerm
        Work.UpdateOrderTerm()
        Try
            Work.DataSave()
            Work.ExecuteNonQuery(String.Format("UPDATE tWork SET isAskSend = 0 WHERE id = {0}", CInt(Work.Id)))
            Work.WriteHistory(WorkEvent.BackQuery, Nothing)
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка сохранения данных:{0}{1}", vbCrLf, ex.Message))
            Exit Sub
        End Try
        '
        ' Отправка сообщения в ЭО об изменении срока выполнения работы
        '
        Program.SendWorkChangeToEo(Work.Id)
        '
        ' Отправка email-сообщений исполнителям о снятии запроса
        '
        Dim Mail As New Cprp.DxData.Mail(Program.DbClient.Connection)
        Dim caption As String = Nothing
        Dim body As String = Nothing
        Dim managerId As Integer = ToInt(Work("managerId"))
        Dim expertId As Integer = ToInt(Work("expertId"))
        Dim orderNum As String = ToText(Work("orderNum"))
        caption = String.Format("Работа № {0} - снят запрос", CInt(Work.Id))
        body = String.Format("{0} снял запрос по Вашей работе № {1}.", Program.DbClient.NameShort, CInt(Work.Id))
        If expertId > 0 Then Mail.Send(Program.DbClient.Id, expertId, caption, body)
        If managerId > 0 Then
            caption = String.Format("{0} (заказ № {1})", caption, orderNum)
            body = String.Format("{0} (заказ № {1}).", DelPoint(body), orderNum)
            Mail.Send(Program.DbClient.Id, managerId, caption, body)
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

End Class