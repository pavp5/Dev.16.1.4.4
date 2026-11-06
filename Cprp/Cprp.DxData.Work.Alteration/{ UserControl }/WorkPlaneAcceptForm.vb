Imports Cprp.DxData.Common
''' <summary>
''' Форма утверждения плана работы
''' </summary>
Friend Class WorkPlaneAcceptForm

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
        If Not IsDBNull(Me.Work.ARow("expertTerm")) Then
            ExpertTermDateEdit.EditValue = CDate(Me.Work.ARow("expertTerm"))
        End If
        If Not IsDBNull(Me.Work.ARow("totalWork")) Then
            TotalWorkSpinEdit.EditValue = CInt(Me.Work.ARow("totalWork"))
        End If
        ' Скрыть элемент "Разблокировать первичную работу"
        UnlockLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        Me.Text = "Утверждение плана работы"
        Me.CenterToScreen()

    End Sub


    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If IsDBNull(DbInt(ExpertLookUpEdit.EditValue)) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите эксперта!")
            Exit Sub
        End If
        If IsDBNull(DbDate(ExpertTermDateEdit.EditValue)) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите срок исполнения!")
            Exit Sub
        End If
        If IsDBNull(DbInt(TotalWorkSpinEdit.EditValue)) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите трудоемкость!")
            Exit Sub
        End If
        If Not (UnlockSummaryCheckEdit.Checked OrElse NewSummaryCheckEdit.Checked OrElse NewWorkSummaryCheckEdit.Checked OrElse LetterSummaryCheckEdit.Checked OrElse TalkSummaryCheckEdit.Checked) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите решение по результатам рассмотрения!")
            Exit Sub
        End If
        If (ClientSourceCheckEdit.Enabled OrElse ExpertSourceCheckEdit.Enabled OrElse LessSourceCheckEdit.Enabled) AndAlso Not (ClientSourceCheckEdit.Checked OrElse ExpertSourceCheckEdit.Checked OrElse LessSourceCheckEdit.Checked) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите причину изменений!")
            Exit Sub
        End If
        '
        ' Данные работы
        '
        Work("expertId") = DbInt(ExpertLookUpEdit.EditValue)
        Work("expertTerm") = DbDate(ExpertTermDateEdit.EditValue)
        Work("totalWork") = DbInt(TotalWorkSpinEdit.EditValue)
        Work.ARow("expertTerm") = Work("expertTerm")
        Work.ARow("totalWork") = Work("totalWork")
        ' Причина изменений
        Dim sourceId As Cprp.DxData.Work.ChangeSource = ChangeSource.IsEmpty
        If ClientSourceCheckEdit.Checked Then
            sourceId = ChangeSource.IsClient
        ElseIf ExpertSourceCheckEdit.Checked Then
            sourceId = ChangeSource.IsExpert
        ElseIf LessSourceCheckEdit.Checked Then
            sourceId = ChangeSource.IsLess
        End If
        Work.ARow("changeSourceId") = CInt(sourceId)
        ' Решение по результатам рассмотрения
        Dim summaryId As Cprp.DxData.Work.ChangeSummary = ChangeSummary.IsEmpty
        Dim summaryText As String = Nothing
        If UnlockSummaryCheckEdit.Checked Then
            summaryId = ChangeSummary.IsUnlock
            summaryText = "Разблокировать первичную работу"
        ElseIf NewSummaryCheckEdit.Checked Then
            summaryId = ChangeSummary.IsNew
            summaryText = "Создать новую работу по цене внесения изменений"
        ElseIf NewWorkSummaryCheckEdit.Checked Then
            summaryId = ChangeSummary.IsNewWork
            summaryText = "Создать новую работу по цене новой работы"
        ElseIf LetterSummaryCheckEdit.Checked Then
            summaryId = ChangeSummary.IsLetter
            summaryText = "Подготовить письмо заказчику"
        ElseIf TalkSummaryCheckEdit.Checked Then
            summaryId = ChangeSummary.IsTalk
            summaryText = "Даны устные пояснения заказчику"
        End If
        Work.ARow("changeSummaryId") = CInt(summaryId)
        ' Указания эксперту
        Dim comment As String = ToText(CommentMemoEdit.Text)

        Dim User As New Cprp.DxData.User.DatabaseUser(Work.Connection)
        Dim caption As String = Nothing
        Dim body As String = Nothing

        ' Очистить результаты расчета стоимости работы
        Work.CalcTable.Rows.Clear()
        '
        ' В зависимости от решения по результатам рассмотрения
        '
        Select Case summaryId

            Case ChangeSummary.IsUnlock
                '
                ' Разблокировать первичную работу
                ' -------------------------------
                '
                Work.ReCalc()
                If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Стоимость внесения изменений: {0:c2}. Утвердить план работы?", CSng(Me.Work("price")))) <> DialogResult.Yes Then Exit Sub

                Dim parentId As Integer = ToInt(Work("parentId"))

                ' Разблокировка первичной работы
                Using ParentWork As New Cprp.DxData.Work.AnyWorkConnectionRow(parentId, Work.Connection)
                    ParentWork("expertId") = Work("expertId")
                    ParentWork.ARow("changeSourceId") = Work.ARow("changeSourceId")
                    ParentWork("expertTerm") = Work.ARow("expertTerm")
                    ParentWork.ARow("expertTerm") = Work.ARow("expertTerm")
                    ParentWork("totalWork") = Work.ARow("totalWork")
                    ParentWork.ARow("totalWork") = Work.ARow("totalWork")
                    ParentWork("agreementNum") = Work("agreementNum")
                    ParentWork.Condition = WorkCondition.IsWork
                    ParentWork.UpdateOrderTerm()
                    ParentWork.DataSave()
                    ParentWork.MessageWorkChangeEo()
                    ParentWork.WriteHistory(WorkEvent.BackAccept, ToText(Work.ARow("expertComment")))
                End Using

                ' Закрытие заявки на внесение изменений
                Work.Condition = WorkCondition.IsClose
                Work("acceptDate") = Date.Now
                Work("closeDate") = Work("acceptDate")
                Work.DataSave()
                Work.WriteHistory(WorkEvent.PlaneAccept, summaryText)
                Work.WriteHistory(WorkEvent.WorkClose, Nothing)

                caption = String.Format("РАЗБЛОКИРОВКА РАБОТЫ (Работа № {0})", CInt(Work("parentId")))
                body = String.Format("{0} разблокировал Вашу работу № {1} для внесения изменений.", User.NameShort, CInt(Work("parentId")).ToString)
                If IsText(comment) Then body = String.Format("{0}{1}Указания руководителя:{1}{2}", body, vbCrLf, comment)
                Cprp.DxData.Mail.Send(Work.Connection, User.Id, Work("expertId"), caption, body)

            Case ChangeSummary.IsNew
                '
                ' Создать новую работу по цене внесения изменений
                ' -----------------------------------------------
                '
                Work.ReCalc()
                If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Стоимость внесения изменений: {0:c2}. Утвердить план работы?", CSng(Me.Work("price")))) <> DialogResult.Yes Then Exit Sub
                Work.CalcTable.Rows.Clear() ' чтобы в плане заявки на внесение изменений не было расчета стоимости новой работы

                ' ID новой работы
                Dim workId As Integer = EMPTY_ID
                ' Тип новой работы (соответствует типу первичной)
                Dim typeId = CInt(Work.ExecuteScalar(String.Format("SELECT typeId FROM tWork WHERE id = {0}", CInt(Work("parentId")))))

                ' Создание новой работы
                Using NewWork As New Cprp.DxData.Work.AnyWorkConnectionRow(Work.Connection)
                    NewWork("createDate") = Date.Now
                    NewWork("pId") = Work.Id
                    NewWork("parentId") = Work("parentId")
                    NewWork("typeId") = typeId
                    NewWork("expertId") = Work("expertId")
                    NewWork("expertTerm") = Work.ARow("expertTerm")
                    NewWork("managerId") = Work("managerId")
                    NewWork("leaderId") = Work("leaderId")
                    NewWork("orderId") = Work("orderId")
                    NewWork("CrmOrderId") = Work("CrmOrderId")
                    NewWork("orderNum") = Work("orderNum")
                    NewWork("orderDate") = Work("orderDate")
                    NewWork("orderUrl") = Work("orderUrl")
                    NewWork("taskId") = Work("taskId")
                    NewWork("taskUrl") = Work("taskUrl")
                    NewWork("clientName") = Work("clientName")
                    NewWork("clientAddress") = Work("clientAddress")
                    NewWork("clientInn") = Work("clientInn")
                    NewWork("clientKpp") = Work("clientKpp")
                    NewWork("clientPhone") = Work("clientPhone")
                    NewWork("clientFax") = Work("clientFax")
                    NewWork("totalWork") = Work.ARow("totalWork")
                    NewWork("agreementNum") = Work("agreementNum")
                    NewWork("comment") = String.Format("Внесение изменений в работу № {0}.", Work("parentId").ToString)
                    If IsText(comment) Then
                        NewWork("comment") = _
                            String.Format("Внесение изменений в работу № {0}.{1}Указания руководителя:{1}{2}", _
                                          Work("parentId").ToString, vbCrLf, comment)
                    End If

                    NewWork.ARow("changeSourceId") = Work.ARow("changeSourceId")
                    NewWork.ARow("expertTerm") = Work.ARow("expertTerm")
                    NewWork.ARow("totalWork") = Work.ARow("totalWork")
                    Using ParentWork As New Cprp.DxData.Work.AnyWorkConnectionRow(Work("parentId"), Work.Connection)
                        NewWork.ARow("typeId") = NewWork("typeId")
                        NewWork.ARow("goodCount") = ParentWork.ARow("goodCount")
                        NewWork.ARow("matCount") = ParentWork.ARow("matCount")
                        NewWork.ARow("infCount") = ParentWork.ARow("infCount")
                        NewWork.ARow("addWorkCount") = ParentWork.ARow("addWorkCount")
                        NewWork.ARow("langCount") = ParentWork.ARow("langCount")
                        NewWork.ARow("findCount") = ParentWork.ARow("findCount")
                        NewWork.ARow("totalWork") = NewWork("totalWork")
                    End Using
                    NewWork.ReCalc()
                    NewWork.UpdateOrderTerm()
                    NewWork.Condition = WorkCondition.IsWork
                    NewWork.DataSave()
                    NewWork.DataSaveFile()
                    workId = CInt(NewWork.Id)   ' ID новой работы
                    NewWork.MessageWorkNewEo()
                    NewWork.PlaneDocumentCreate()
                    NewWork.PlaneDocumentToEO()
                End Using

                '' Изменение срока действия и даты закрытия первичной работы (для включения в отчет)
                'Using ParentWork As New Cprp.DxData.Work.Excont.WorkConnectionRow(Work("parentId"), Work.Connection)
                '    If IsDBNull(ParentWork.ARow("docTerm")) OrElse CDate(ParentWork.ARow("docTerm")) > Date.Now Then
                '        ParentWork.ARow("docTerm") = Date.Now
                '        ParentWork("closeDate") = Date.Now
                '        ParentWork.DataSave()
                '    End If
                'End Using

                ' Закрытие заявки на внесение изменений
                Work.Condition = WorkCondition.IsClose
                Work("acceptDate") = Date.Now
                Work("closeDate") = Work("acceptDate")
                Work.DataSave()
                Work.WriteHistory(WorkEvent.PlaneAccept, summaryText)
                Work.WriteHistory(WorkEvent.WorkClose, Nothing)

                caption = String.Format("НОВАЯ РАБОТА (Работа № {0})", workId.ToString)
                body = String.Format("{0} назначил Вам новую работу № {1} (внесение изменений в работу № {2}).", User.NameShort, workId.ToString, CInt(Work("parentId")).ToString)
                If IsText(comment) Then body = String.Format("{0}{1}Указания руководителя:{1}{2}", body, vbCrLf, comment)
                Cprp.DxData.Mail.Send(Work.Connection, User.Id, Work("expertId"), caption, body)

            Case ChangeSummary.IsNewWork
                '
                ' Создать новую работу по цене новой работы
                ' -----------------------------------------
                '
                Cprp.DxCommon.Messages.ShowInformation("Стоимость работы будет определена при утверждении плана новой работы.")

                ' ID новой работы
                Dim workId As Integer = EMPTY_ID
                ' Тип новой работы (соответствует типу первичной)
                Dim typeId = CInt(Work.ExecuteScalar(String.Format("SELECT typeId FROM tWork WHERE id = {0}", CInt(Work("parentId")))))

                ' Создание новой работы
                Using NewWork As New Cprp.DxData.Work.AnyWorkConnectionRow(Work.Connection)
                    NewWork("createDate") = Date.Now
                    NewWork("pId") = Work.Id
                    NewWork("parentId") = Work("parentId")
                    NewWork("typeId") = typeId
                    NewWork("expertId") = Work("expertId")
                    NewWork("expertTerm") = Work.ARow("expertTerm")
                    NewWork("managerId") = Work("managerId")
                    NewWork("leaderId") = Work("leaderId")
                    NewWork("orderId") = Work("orderId")
                    NewWork("CrmOrderId") = Work("CrmOrderId")
                    NewWork("orderNum") = Work("orderNum")
                    NewWork("orderDate") = Work("orderDate")
                    NewWork("orderUrl") = Work("orderUrl")
                    NewWork("taskId") = Work("taskId")
                    NewWork("taskUrl") = Work("taskUrl")
                    NewWork("clientName") = Work("clientName")
                    NewWork("clientAddress") = Work("clientAddress")
                    NewWork("clientInn") = Work("clientInn")
                    NewWork("clientKpp") = Work("clientKpp")
                    NewWork("clientPhone") = Work("clientPhone")
                    NewWork("clientFax") = Work("clientFax")
                    NewWork("agreementNum") = Work("agreementNum")
                    NewWork("comment") = String.Format("Внесение изменений в работу № {0}.", Work("parentId").ToString)
                    If IsText(comment) Then
                        NewWork("comment") = _
                            String.Format("Внесение изменений в работу № {0}.{1}Указания руководителя:{1}{2}", _
                                          Work("parentId").ToString, vbCrLf, comment)
                    End If

                    NewWork.ARow("typeId") = NewWork("typeId")
                    NewWork.ARow("totalWork") = 120
                    NewWork.Condition = WorkCondition.IsPlaneWork
                    NewWork.DataSave()
                    NewWork.DataSaveFile()
                    NewWork.MessageWorkNewEo()
                    workId = CInt(NewWork.Id)   ' ID новой работы
                End Using

                '' Изменение срока действия и даты закрытия первичной работы (для включения в отчет)
                'Using ParentWork As New Cprp.DxData.Work.Excont.WorkConnectionRow(Work("parentId"), Work.Connection)
                '    If IsDBNull(ParentWork.ARow("docTerm")) OrElse CDate(ParentWork.ARow("docTerm")) > Date.Now Then
                '        ParentWork.ARow("docTerm") = Date.Now
                '        ParentWork("closeDate") = Date.Now
                '        ParentWork.DataSave()
                '    End If
                'End Using

                ' Закрытие заявки на внесение изменений
                Work.Condition = WorkCondition.IsClose
                Work("acceptDate") = Date.Now
                Work("closeDate") = Work("acceptDate")
                Work.DataSave()
                Work.WriteHistory(WorkEvent.PlaneAccept, summaryText)
                Work.WriteHistory(WorkEvent.WorkClose, Nothing)

                caption = String.Format("НОВАЯ РАБОТА (Работа № {0})", workId.ToString)
                body = String.Format("{0} назначил Вам новую работу № {1}.", User.NameShort, workId.ToString)
                If IsText(comment) Then body = String.Format("{0}{1}Указания руководителя:{1}{2}", body, vbCrLf, comment)
                Cprp.DxData.Mail.Send(Work.Connection, User.Id, Work("expertId"), caption, body)

            Case ChangeSummary.IsLetter
                '
                ' Подготовить письмо
                ' ------------------
                '
                Work.Condition = WorkCondition.IsWork
                Work("paymentDate") = Date.Now
                Work.UpdateOrderTerm()
                Work.DataSave()
                Work.WriteHistory(WorkEvent.PlaneAccept, summaryText)

            Case ChangeSummary.IsTalk
                '
                ' Даны устные пояснения заказчику
                ' -------------------------------
                '
                Work.Condition = WorkCondition.IsClose
                Work("acceptDate") = Date.Now
                Work("closeDate") = Work("acceptDate")
                Work.DataSave()
                Work.WriteHistory(WorkEvent.PlaneAccept, summaryText)
                Work.WriteHistory(WorkEvent.WorkClose, Nothing)

        End Select
        '
        ' Создание и отправка в ЭО плана заявки
        '
        Work.PlaneDocumentCreate()
        Work.PlaneDocumentToEO()
        '
        ' Отправка в ЭО сообщения об изменении заявки
        '
        Work.MessageWorkChangeEo()
        '
        ' Отправка сообщения эксперту об утверждении плана заявки
        '
        caption = String.Format("УТВЕРЖДЕНИЕ ПЛАНА РАБОТЫ (Работа № {0})", CInt(Work.Id))
        body = String.Format("{0} утвердил план Вашей работы № {1} - заявка на внесение изменений.{2}Решение руководителя:{2}{3}.", _
                             User.NameShort, CInt(Work.Id), vbCrLf, summaryText)
        Cprp.DxData.Mail.Send(Work.Connection, User.Id, Work("expertId"), caption, body)

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub UnlockSummaryCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles UnlockSummaryCheckEdit.CheckedChanged
        If Not UnlockSummaryCheckEdit.Checked Then Exit Sub
        LessSourceCheckEdit.Checked = False
        ClientSourceCheckEdit.Enabled = True
        ExpertSourceCheckEdit.Enabled = True
        LessSourceCheckEdit.Enabled = False
    End Sub

    Private Sub NewSummaryCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles NewSummaryCheckEdit.CheckedChanged
        If Not NewSummaryCheckEdit.Checked Then Exit Sub
        ClientSourceCheckEdit.Enabled = True
        ExpertSourceCheckEdit.Enabled = True
        LessSourceCheckEdit.Enabled = True
    End Sub

    Private Sub NewWorkSummaryCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles NewWorkSummaryCheckEdit.CheckedChanged
        If Not NewWorkSummaryCheckEdit.Checked Then Exit Sub
        ClientSourceCheckEdit.Enabled = True
        ExpertSourceCheckEdit.Enabled = False
        LessSourceCheckEdit.Enabled = False
        ExpertSourceCheckEdit.Checked = False
        LessSourceCheckEdit.Checked = False
    End Sub

    Private Sub LetterSummaryCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles LetterSummaryCheckEdit.CheckedChanged
        If Not LetterSummaryCheckEdit.Checked Then Exit Sub
        ClientSourceCheckEdit.Enabled = False
        ExpertSourceCheckEdit.Enabled = False
        LessSourceCheckEdit.Enabled = False
        ClientSourceCheckEdit.Checked = False
        ExpertSourceCheckEdit.Checked = False
        LessSourceCheckEdit.Checked = False
    End Sub

    Private Sub TalkSummaryCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles TalkSummaryCheckEdit.CheckedChanged
        If Not TalkSummaryCheckEdit.Checked Then Exit Sub
        ClientSourceCheckEdit.Enabled = False
        ExpertSourceCheckEdit.Enabled = False
        LessSourceCheckEdit.Enabled = False
        ClientSourceCheckEdit.Checked = False
        ExpertSourceCheckEdit.Checked = False
        LessSourceCheckEdit.Checked = False
    End Sub

End Class