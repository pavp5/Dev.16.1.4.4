Imports Cprp.DxData.Common
''' <summary>
''' Форма отправки заявки эксперту на рассмотрение
''' </summary>
Friend Class WorkExpertForm

    ' Работа
    Private Work As WorkConnectionRow = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Work">Работа</param>
    Friend Sub New(Work As WorkConnectionRow)
        InitializeComponent()
        Me.Work = Work
        ExpertLookUpEdit.Properties.DataSource = New Cprp.DxData.Handbook.ExpertDataTable(Me.Work.Connection)
        Dim expertId As Integer = ToInt(Me.Work("expertId"))
        If expertId < 1 Then _
            expertId = CInt(Me.Work.ExecuteScalar(String.Format("SELECT ISNULL(MAX(expertId), -1) FROM tWork WHERE id = {0}", ToInt(Me.Work("parentId")))))
        If expertId > 0 Then ExpertLookUpEdit.EditValue = expertId
        ResolutionMemoEdit.EditValue = "Прошу разобраться и дать предложения"
        Me.Text = "Отправка работы эксперту"
        Me.CenterToScreen()
    End Sub


    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If IsDBNull(DbInt(ExpertLookUpEdit.EditValue)) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите эксперта!")
            Exit Sub
        End If

        Dim workId As Integer = ToInt(Work.Id)
        Dim User As New Cprp.DxData.User.DatabaseUser(Work.Connection)
        Dim caption As String = Nothing
        Dim body As String = Nothing
        Dim resolution As String = ToText(ResolutionMemoEdit.Text)
        '
        ' Перевод работы в состояние "Подготовка плана", назначение эксперта
        '
        Work.Condition = WorkCondition.IsPlaneWork
        Work("expertId") = ExpertLookUpEdit.EditValue
        Work("expertTerm") = Cprp.DxData.Work.Common.GetPlaneDate(Date.Now, 120)
        If IsText(resolution) Then Work.ARow("leaderComment") = resolution
        Work.DataSave()
        '
        ' Отправка эксперту email-уведомления о рассмотрении заявки
        '
        caption = String.Format("ВНЕСЕНИЕ ИЗМЕНЕНИЙ (Работа № {0})", workId)
        body = String.Format("{0} назначил Вам рассмотрение внесения изменений по просьбе заказчика (работа № {1}).", User.NameShort, workId)
        If IsText(resolution) Then
            body = String.Format("{0}{1}Резолюция руководителя:{1}{2}", body, vbCrLf, resolution)
        End If
        Cprp.DxData.Mail.Send(Work.Connection, User.Id, Work("expertId"), caption, body)
        '
        ' Запись в историю работы
        '
        Work.WriteHistory(WorkEvent.ChangeExpert, resolution)
        '
        ' Отправка в ЭО сообщения об изменении работы
        '
        Work.MessageWorkChangeEo()

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class