Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма расчета суммы баллов за работу
''' </summary>
''' <remarks></remarks>
Friend Class WorkAcceptForm

    Friend ballStart As Single = 0      ' стартовая сумма баллов за работу, с которой начинается ее корректировка руководителем
    Friend ballFact As Single = 0       ' фактическая сумма баллов за работу, установленная руководителем

    Private otherDif As Integer = 0     ' разница между стартовой и расчетной суммами баллов

    Private _Work As WorkConnectionRow = Nothing

    ' Таблица событий работы
    Private WorkEventTable As DataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Work">Работа</param> 
    ''' <remarks></remarks>
    Friend Sub New(ByVal Work As WorkConnectionRow)
        InitializeComponent()
        '
        ' _Work
        '
        _Work = Work
        '
        ' WorkEventTable
        '
        WorkEventTable = New DataTable
        With WorkEventTable.Columns
            .Add("id", GetType(Integer))
            .Add("isCheck", GetType(Boolean))   ' отмечено руководителем
            .Add("percent", GetType(Integer))   ' процент снижения
            .Add("eventDate", GetType(Date))    '
            .Add("eventId", GetType(Integer))   '
            .Add("eventName", GetType(String))  '
            .Add("comment", GetType(String))    '
        End With
        With WorkEventTable.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With WorkEventTable.Columns("percent")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        WorkEventTable.PrimaryKey = New DataColumn() {WorkEventTable.Columns("id")}
        WorkEventTable.Load(_Work.ExecuteReader(String.Format _
            ("SELECT id, eventDate, eventId, eventName, comment FROM vWorkHistory WHERE workId = {0} AND eventId IN ({1}, {2}, {3}, {4})", _
             CInt(_Work.Id), CInt(Cprp.DxData.Work.WorkEvent.DataCopy), CInt(Cprp.DxData.Work.WorkEvent.GoodFind), _
             CInt(Cprp.DxData.Work.WorkEvent.BackCheck), CInt(Cprp.DxData.Work.WorkEvent.BackAccept))))
        Dim iTmp As Integer = 0
        Dim comment As String = Nothing
        For Each Row As DataRow In WorkEventTable.Rows
            Select Case CType(Row("eventId"), Cprp.DxData.Work.WorkEvent)
                Case WorkEvent.BackCheck
                    Row("percent") = -10
                    Row("eventName") = "[-10] Возврат на доработку после проверки"
                Case WorkEvent.BackAccept
                    Row("percent") = -10
                    Row("eventName") = "[-10] Возврат на доработку после утверждения"
                Case WorkEvent.DataCopy
                    iTmp = -10
                    comment = C2.ToText(Row("comment"))
                    If C2.IsText(comment) Then
                        comment = comment.ToUpper
                        If comment Like "*ОПЕРАЦИЯ*" Then iTmp -= 20
                        If comment Like "*ОБЪЕКТЫ*" Then iTmp -= 50
                    End If
                    Row("percent") = iTmp
                    Row("eventName") = String.Format("[{0}] Копирование данных из другой работы", iTmp)
                Case WorkEvent.GoodFind
                    Row("percent") = -50
                    Row("eventName") = "[-50] Поиск товаров в базе данных"
            End Select
        Next
        '
        ' WorkEventTreeList
        '
        WorkEventTreeList.DataSource = WorkEventTable
        EventDateTreeListColumn.SortIndex = 0
        '
        ' Cтартовая сумма баллов за работу
        '
        ballStart = CSng(_Work("ballFact"))                 ' фактическая сумма баллов последнего утверждения
        If ballStart = 0 Then
            ballStart = 2 + Work.QueryTable.Rows.Count      ' расчетная сумма баллов за работу
        End If
        '
        ' Фактическая сумма баллов (сначала равна стартовой)
        '
        ballFact = ballStart
        '
        ' OtherButtonEdit
        '
        OtherButtonEdit.Text = "0 %"
        '
        ' ExpertSignCheckEdit
        '
        If CInt(_Work.ExecuteScalar(String.Format("SELECT COUNT(*) FROM tUser WHERE id = {0} AND NOT pin IS NULL", C2.ToInt(_Work("expertId"))))) = 0 Then
            ExpertSignCheckEdit.Checked = False
            ExpertSignCheckEdit.Enabled = False
        Else
            ExpertSignCheckEdit.Checked = CBool(_Work.ARow("isExpertSign"))
            ExpertSignCheckEdit.Enabled = True
        End If
        '
        ' Me
        '
        Dim sTmp As String = Nothing
        Select Case _Work.Type
            Case WorkType.IsExCont : sTmp = "ДН"
            Case WorkType.IsCustomUnion : sTmp = "ЗиО"
            Case WorkType.IsLiconfirm : sTmp = "Контр"
            Case WorkType.IsTnved : sTmp = "Код"
            Case Else : sTmp = "ХЗ"
        End Select
        Me.Text = String.Format("Работа № {0} [{1}] - Утверждение", C2.ToInt(_Work.Id), sTmp)
        Me.CenterToScreen()

        ChangeSum()

    End Sub

    ''' <summary>
    ''' Пересчитать суммы баллов
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ChangeSum()
        If otherDif < -100 Then otherDif = -100
        If otherDif > 100 Then otherDif = 100
        ballFact = ballStart * (100 + otherDif) / 100
        OtherButtonEdit.Text = String.Format("{0}{1} %", If(otherDif > 0, "+ ", If(otherDif = 0, Nothing, "- ")), Math.Abs(otherDif))
        CaptionLabelControl.Text = String.Format("Разница: {2}{3} %. Базовая сумма баллов: {1:N2}. Окончательная сумма баллов: <b>{0:N2}</b>.", _
            ballFact, ballStart, If(otherDif > 0, "+ ", If(otherDif = 0, Nothing, "- ")), Math.Abs(otherDif))
    End Sub

    Private Sub OtherButtonEdit_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles OtherButtonEdit.ButtonClick
        Select Case e.Button.Index
            Case 0 : otherDif -= 10
            Case 1 : otherDif += 10
        End Select
        ChangeSum()
    End Sub

    Private Sub AcceptSimpleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcceptSimpleButton.Click
        If Not C2.IsText(CommentMemoEdit.Text) AndAlso otherDif <> 0 AndAlso WorkEventTreeList.GetAllCheckedNodes.Count = 0 Then
            Cprp.DxCommon.Messages.ShowWarning("Окончательная сумма баллов отличается от базовой. Укажите комментарий.", "Укажите комментарий")
            Exit Sub
        End If
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub WorkEventTreeList_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles WorkEventTreeList.AfterCheckNode
        otherDif = 0
        For Each Node As DevExpress.XtraTreeList.Nodes.TreeListNode In WorkEventTreeList.GetAllCheckedNodes
            otherDif += CInt(Node.GetValue("percent"))
        Next
        ChangeSum()
    End Sub

End Class