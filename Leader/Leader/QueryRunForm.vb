Imports Cprp.DxData.Common
Imports Cprp.DxData.Work
''' <summary>
''' Форма перевода работы в состояние "Запрос"
''' </summary>
Friend Class QueryRunForm

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
        ' ManagerLookUpEdit
        '
        ManagerLookUpEdit.Properties.DataSource = Program.ManagerTable
        ManagerLookUpEdit.EditValue = Work("managerId")
        '
        ' ExpertLookUpEdit
        '
        If Work.Type = WorkType.IsOrder Then
            ExpertLookUpEdit.Enabled = False
        Else
            ExpertLookUpEdit.Properties.DataSource = Program.ExpertTable
            ExpertLookUpEdit.EditValue = Work("expertId")
        End If
        '
        ' CommentMemoEdit
        '
        If Work.Condition <> WorkCondition.IsNew Then CommentMemoEdit.Text = "Направлен запрос"
        '
        ' Me
        '
        Me.Text = String.Format("Запрос - Работа № {0}", ToInt(Work.Id))
        Me.CenterToScreen()
    End Sub


    Private Sub QueryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Work Is Nothing OrElse Work.IsEmpty Then Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        Dim oldManagerId As Integer = ToInt(Work("managerId"))
        Dim oldExpertId As Integer = ToInt(Work("expertId"))
        Dim newManagerId As Integer = ToInt(ManagerLookUpEdit.EditValue)
        Dim newExpertId As Integer = ToInt(ExpertLookUpEdit.EditValue)

        If newManagerId < 0 Then
            Cprp.DxCommon.Messages.ShowWarning("Необходимо указать менеджера.")
            Exit Sub
        End If
        If Work.Condition = WorkCondition.IsNew AndAlso Not IsText(CommentMemoEdit.Text) Then
            Cprp.DxCommon.Messages.ShowWarning("Необходимо ввести указания исполнителям.")
            Exit Sub
        End If
        '
        ' Сохранение данных, запись в историю работы
        '
        Work("managerId") = newManagerId
        If newExpertId > 0 Then Work("expertId") = newExpertId

        Try
            Work.DataSave()
            Work.ExecuteNonQuery(String.Format("UPDATE tWork SET isAskSend = 1 WHERE id = {0}", CInt(Work.Id)))
            Work.WriteHistory(WorkEvent.QuerySend, ToText(CommentMemoEdit.Text))
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка сохранения данных:{0}{1}", vbCrLf, ex.Message))
            Exit Sub
        End Try
        '
        ' Отправка сообщений исполнителям
        '
        Dim caption As String = Nothing
        Dim body As String = Nothing
        Dim Mail As New Cprp.DxData.Mail(Program.DbClient.Connection)
        Try
            If CInt(Work("managerId")) <> oldManagerId Then
                caption = String.Format("{0} назначил Вас менеджером в работе № {1} (заказ № {2}).", Program.DbClient.NameShort, CInt(Work.Id), Work("orderNum").ToString)
                body = caption
                Mail.Send(Program.DbClient.Id, Work("managerId"), caption, body)
            End If
            caption = String.Format("Ваша работа № {0} переведена в состояние ""Запрос"" (заказ № {1}).", ToInt(Work.Id), Work("orderNum").ToString)
            body = String.Format("{0} перевел Вашу работу № {1} в состояние ""Запрос"" (заказ № {2}).", Program.DbClient.NameShort, CInt(Work.Id), Work("orderNum").ToString)
            If IsText(CommentMemoEdit.Text) Then
                body = String.Format("{0}{1}Указания руководителя:{1}{2}", body, vbCrLf, AddPoint(CommentMemoEdit.Text))
            End If
            Mail.Send(Program.DbClient.Id, Work("managerId"), caption, body)
            If Not IsDBNull(Work("expertId")) Then
                If CInt(Work("expertId")) <> oldExpertId Then
                    caption = String.Format("{0} назначил Вас исполнителем в работе № {1}.", Program.DbClient.NameShort, CInt(Work.Id))
                    body = caption
                    Mail.Send(Program.DbClient.Id, Work("expertId"), caption, body)
                End If
                caption = String.Format("{0} перевел Вашу работу № {1} в состояние ""Запрос"".", Program.DbClient.NameShort, CInt(Work.Id))
                body = caption
                If IsText(CommentMemoEdit.Text) Then
                    body = String.Format("{0}{1}Указания руководителя:{1}{2}", body, vbCrLf, AddPoint(CommentMemoEdit.Text))
                End If
                Mail.Send(Program.DbClient.Id, Work("expertId"), caption, body)
            End If
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка отправки уведомлений исполнителям:{0}{1}", vbCrLf, ex.Message))
        End Try
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class