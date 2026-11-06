Imports DevExpress.XtraTreeList.Nodes
Imports Cprp.DxData.Common
''' <summary>
''' Элемент управления "Списки"
''' </summary>
Friend Class LawUserControl : Implements IChildControl

#Region "IChildControl"

    Friend Sub CloseEditor() Implements IChildControl.CloseEDitor
        LawTreeList.CloseEditor()
    End Sub

    Friend Sub BeginDataUpdate() Implements IChildControl.BeginDataUpdate
        LawTreeList.CloseEditor()
        LawTreeList.LockReloadNodes()
        TnvedGridView.BeginDataUpdate()
    End Sub

    Friend Sub EndDataUpdate() Implements IChildControl.EndDataUpdate
        LawTreeList.UnlockReloadNodes()
        LawTreeList.CollapseAll()
        LawTreeList.MoveFirst()
        TnvedGridView.EndDataUpdate()
        TnvedGridView.MoveFirst()
    End Sub

#End Region

    ''' <summary>
    ''' Источник данных АПУ
    ''' </summary>
    Private Ds As ApuDataSet = Nothing

    ''' <summary>
    ''' Представление кодов ТН ВЭД текущего пункта контрольного списка
    ''' </summary>
    Private TnvedView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Ds">Источник данных АПУ</param>
    Friend Sub New(ByRef Ds As ApuDataSet)
        InitializeComponent()
        Me.Ds = Ds
        TnvedView = New DataView(Me.Ds.TnvedTable) With {.Sort = "codeDescription", .RowFilter = "code IS NULL"}
        LawTreeList.DataSource = Me.Ds.LawTable
        SortIdTreeListColumn.SortIndex = 0
        TnvedGridControl.DataSource = TnvedView
        TnvedGridView.SortInfo.Insert(0, CodeDescriptionGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        PosDescriptionMemoEdit.DataBindings.Add("Text", Me.Ds.LawTable, "posDescription")
        AutoheightBarCheckItem.Checked = True
    End Sub


    ''' <summary>
    ''' Показать пункт списка в дереве контрольных списков
    ''' </summary>
    ''' <param name="lawId">ID пункта списка</param>
    Friend Sub LawView(lawId As Integer)
        Dim Node As TreeListNode = LawTreeList.FindNodeByKeyID(lawId)
        If Not Node Is Nothing Then LawTreeList.FocusedNode = Node
    End Sub


    ' Выровнять высоту строк
    Private Sub AutoheightBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AutoheightBarCheckItem.CheckedChanged
        LawTreeList.OptionsBehavior.AutoNodeHeight = AutoheightBarCheckItem.Checked
    End Sub

    ' Свернуть все пункты
    Private Sub CollapseBarButtonItem_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CollapseBarButtonItem.ItemClick
        LawTreeList.CollapseAll()
        LawTreeList.MoveFirst()
    End Sub

    ' Перейти на уровень выше
    Private Sub LevelUpBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LevelUpBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        If LawTreeList.FocusedNode.ParentNode Is Nothing Then Exit Sub
        LawTreeList.FocusedNode = LawTreeList.FocusedNode.ParentNode
    End Sub

    ' Перейти на уровень ниже
    Private Sub LevelDownBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LevelDownBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        If Not LawTreeList.FocusedNode.HasChildren Then Exit Sub
        LawTreeList.FocusedNode = LawTreeList.FocusedNode.Nodes(0)
    End Sub

    ' Развернуть все
    Private Sub ExpandBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpandBarButtonItem.ItemClick
        Dim N As TreeListNode = LawTreeList.FocusedNode
        If Not N Is Nothing Then N.ExpandAll()
    End Sub

    Private Sub FindRepositoryItemButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemButtonEdit.EditValueChanging
        LawTreeList.ApplyFindFilter(ToText(e.NewValue))
    End Sub

    ' Поиск вверх и вниз по тексту документов
    Private Sub FindRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindRepositoryItemButtonEdit.ButtonClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        If Not IsText(LawTreeList.FindFilterText) Then Exit Sub
        Dim iTmp As Integer = 0
        Select Case e.Button.Index
            Case 0  ' поиск вниз
                iTmp = Ds.LawTable.FindNextIdByText(CInt(CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView)("id")), LawTreeList.FindFilterText)
            Case 1  ' поиск вверх
                iTmp = Ds.LawTable.FindPrevIdByText(CInt(CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView)("id")), LawTreeList.FindFilterText)
            Case 2  ' очистить поле поиска
                FindBarEditItem.EditValue = Nothing
                Exit Sub
        End Select
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = LawTreeList.FindNodeByKeyID(iTmp)
        If N Is Nothing Then
            Cprp.DxCommon.Messages.ShowInformation("Дальше нет пунктов, содержащих указанный текст.")
        Else
            N.ExpandAll()
            LawTreeList.FocusedNode = N
            LawTreeList.Focus()
        End If
    End Sub

    ' Найти и заменить текст в АПУ
    Private Sub ReplaceBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReplaceBarButtonItem.ItemClick
        If Ds.LawTable.Rows.Count = 0 Then Exit Sub
        Dim findText As String = Nothing
        Dim replaceText As String = Nothing
        Dim N As TreeListNode = LawTreeList.FocusedNode
        If Not N Is Nothing Then findText = N.GetValue("apu").ToString
        With New FindReplaceForm(findText)
            If .ShowDialog <> DialogResult.OK Then Exit Sub
            findText = .FindText
            replaceText = .ReplaceText
        End With
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        CloseEditor()
        For i As Integer = 0 To Ds.LawTable.Rows.Count - 1
            sTmp = ToText(Ds.LawTable(i)("apu"))
            If Not IsText(sTmp) Then Continue For
            If InStr(sTmp, findText) = 0 Then Continue For
            Ds.LawTable(i)("apu") = sTmp.Replace(findText, replaceText)
            iTmp += 1
        Next
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation(String.Format("Произведено замен: {0}.", iTmp))
    End Sub

    ' Вставить описание пункта АПУ из введенных ранее
    Private Sub InsertBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles InsertBarButtonItem.ItemClick
        Dim N As TreeListNode = LawTreeList.FocusedNode
        If N Is Nothing Then Exit Sub
        LawTreeList.LockReloadNodes()
        With New InsertForm(Ds, CInt(N.GetValue("id")))
            .ShowDialog()
        End With
        LawTreeList.UnlockReloadNodes()
    End Sub

    ' Вставить коды ТН ВЭД в описания пунктов АПУ
    Private Sub TnvedBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TnvedBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Вставить коды ТН ВЭД во все описания пунктов АПУ?") <> DialogResult.Yes Then Exit Sub
        Dim formText = Me.ParentForm.Text
        Dim apuText As String = Nothing
        Dim tnved As String = Nothing
        Dim sTmp As String = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        LawTreeList.LockReloadNodes()
        Using V As New DataView(Ds.LawTnvedTable) With {.Sort = "code"}
            For i As Integer = 0 To Ds.LawTable.Rows.Count - 1
                Me.ParentForm.Text = String.Format("Вставка кодов ТН ВЭД ({0} из {1})", i + 1, Ds.LawTable.Rows.Count)
                Application.DoEvents()
                V.RowFilter = String.Format("lawId = {0}", CInt(Ds.LawTable(i)("id")))
                apuText = ToText(Ds.LawTable(i)("apu"))
                tnved = Nothing
                For j As Integer = 0 To V.Count - 1
                    sTmp = ToText(V(j)("code"))
                    If InStr(apuText, sTmp) = 0 Then
                        apuText = String.Format("{0}{1}={1}ТН ВЭД (коды){1}{2}", apuText, vbCrLf, sTmp)
                    End If
                Next
                Ds.LawTable(i)("apu") = DbText(apuText)
            Next
        End Using
        LawTreeList.UnlockReloadNodes()
        Me.ParentForm.Text = formText
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation("Операция завершена")
    End Sub

    ' Вставить номера CAS в описания пунктов АПУ
    Private Sub CasBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CasBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Вставить номера CAS во все описания пунктов АПУ?") <> DialogResult.Yes Then Exit Sub
        Dim formText = Me.ParentForm.Text
        Dim lawText As String = Nothing
        Dim apuText As String = Nothing
        Dim cas As String = Nothing
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        LawTreeList.LockReloadNodes()
        For i As Integer = 0 To Ds.LawTable.Rows.Count - 1
            Me.ParentForm.Text = String.Format("Вставка номеров CAS ({0} из {1})", i + 1, Ds.LawTable.Rows.Count)
            Application.DoEvents()
            lawText = ToText(Ds.LawTable(i)("posDescription"))
            apuText = ToText(Ds.LawTable(i)("apu"))
            cas = Nothing
            Do
                iTmp = InStr(lawText, "CAS ")
                If iTmp = 0 Then Exit Do
                lawText = lawText.Substring(iTmp + 3)
                sTmp = Nothing
                For j As Integer = 0 To lawText.Length - 1
                    If Not lawText(j) Like "[0123456789-]" Then Exit For
                    sTmp &= lawText(j)
                Next
                If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp.Length > 3 AndAlso InStr(apuText, sTmp) = 0 Then
                    apuText = String.Format("{0}{1}={1}CAS (номера){1}{2}", apuText, vbCrLf, sTmp)
                End If
            Loop
            Ds.LawTable(i)("apu") = DbText(apuText)
        Next
        LawTreeList.UnlockReloadNodes()
        Me.ParentForm.Text = formText
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation("Операция завершена")
    End Sub

    Private Sub LawTreeList_FocusedNodeChanged(sender As Object, e As DevExpress.XtraTreeList.FocusedNodeChangedEventArgs) Handles LawTreeList.FocusedNodeChanged
        If LawTreeList.FocusedNode Is Nothing Then
            TnvedView.RowFilter = "code IS NULL"
            Exit Sub
        End If
        Dim sTmp As String = "'0'"
        Using V As New DataView(Ds.LawTnvedTable)
            V.RowFilter = String.Format("lawId = {0}", CInt(LawTreeList.FocusedNode.GetValue("id")))
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0}, '{1}'", sTmp, V(i)("code").ToString)
            Next
        End Using
        TnvedView.RowFilter = String.Format("code IN ({0})", sTmp)
    End Sub

End Class
