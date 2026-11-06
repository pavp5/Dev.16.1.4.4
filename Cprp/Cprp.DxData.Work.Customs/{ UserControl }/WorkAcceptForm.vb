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

    ' Представление с иностранными участниками сделки / операции
    Private NusMemberView As DataView = Nothing

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
        ' NusMemberView
        '
        NusMemberView = New DataView(_Work.MemberTable)
        NusMemberView.RowFilter = "conNusNum > 0 OR supNusNum > 0 OR supEndNum > 0"
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
        ' NusMemberGridControl, NusMemberGridView 
        '
        NusMemberGridControl.DataSource = NusMemberView
        NusMemberGridView.SortInfo.Insert(0, NameLongMemberGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' WorkEventTreeList
        '
        WorkEventTreeList.DataSource = WorkEventTable
        EventDateTreeListColumn.SortIndex = 0
        '
        ' Cтартовая сумма баллов за работу
        '
        ballStart = CSng(_Work("ballFact"))         ' фактическая сумма баллов последнего утверждения
        If ballStart = 0 Then
            Dim goodCount As Integer = 0            ' количество объектов экспертизы
            Dim tnvedCount As Integer = 1           ' количество разных кодов ТН ВЭД
            Dim descriptionCount As Integer = 1     ' количество разных технических описаний
            '
            ' Количество объектов экспертизы
            '
            goodCount = Work.GoodTable.Rows.Count
            '
            ' Количество разных кодов ТН ВЭД
            '
            Using V As New DataView(_Work.GoodTable)
                V.Sort = "tnved"
                For i As Integer = 1 To V.Count - 1
                    If (C2.ToText(V(i)("tnved")) & " ").ToUpper <> (C2.ToText(V(i - 1)("tnved")) & " ").ToUpper Then tnvedCount += 1
                Next
            End Using
            '
            ' Количество разных технических описаний
            '
            Using V As New DataView(_Work.GoodTable)
                V.Sort = "description"
                For i As Integer = 1 To V.Count - 1
                    If (C2.ToText(V(i)("description")) & " ").ToUpper <> (C2.ToText(V(i - 1)("description")) & " ").ToUpper Then descriptionCount += 1
                Next
            End Using
            '
            ' Расчетная стартовая сумма баллов
            '
            ballStart = 2 + (CSng(tnvedCount) + CSng(descriptionCount)) / 2 + _
                0.1 * (CSng(goodCount) - (CSng(tnvedCount) + CSng(descriptionCount)) / 2)
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
        NusMemberGridView.CloseEditor()
        NusMemberGridView.UpdateCurrentRow()
        Me.DialogResult = DialogResult.OK
    End Sub

    Private Sub WorkEventTreeList_AfterCheckNode(sender As Object, e As DevExpress.XtraTreeList.NodeEventArgs) Handles WorkEventTreeList.AfterCheckNode
        otherDif = 0
        For Each Node As DevExpress.XtraTreeList.Nodes.TreeListNode In WorkEventTreeList.GetAllCheckedNodes
            otherDif += CInt(Node.GetValue("percent"))
        Next
        ChangeSum()
    End Sub

    Private Sub RepositoryItemHyperLinkEdit1_Click(sender As Object, e As EventArgs) Handles RepositoryItemHyperLinkEdit1.Click
        Dim Row As DataRow = NusMemberGridView.GetFocusedDataRow
        If Row Is Nothing Then Exit Sub
        Dim sTmp As String = "Профиль:" & vbCrLf
        Dim sTmp1 As String = C2.ToText(Row("proDescription"))
        If Not C2.IsText(sTmp1) Then sTmp1 = "[нет данных]"
        sTmp &= sTmp1 & vbCrLf & "Источник:" & vbCrLf
        sTmp1 = C2.ToText(Row("proSource"))
        If Not C2.IsText(sTmp1) Then sTmp1 = "[нет данных]"
        sTmp &= sTmp1
        MsgBox(sTmp, MsgBoxStyle.Information, C2.ToText(Row("nameLong")))
    End Sub

    Private Sub NusMemberGridView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles NusMemberGridView.CellValueChanging
        If NusMemberGridView.FocusedRowHandle < 0 Then Exit Sub
        If e.Column.FieldName <> "isControl" Then Exit Sub
        NusMemberGridView.GetFocusedDataRow("isControl") = e.Value
        NusMemberGridView.CloseEditor()
        NusMemberGridView.RefreshData()
    End Sub

End Class