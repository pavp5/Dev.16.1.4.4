Imports Cprp.DxData.Common
Imports DevExpress.XtraTreeList.Nodes
''' <summary>
''' Форма для вставки описаний пунктов АПУ в другой пункт
''' </summary>
Friend Class InsertForm

    ''' <summary>
    ''' Источник данных АПУ
    ''' </summary>
    Private Ds As ApuDataSet = Nothing

    ''' <summary>
    ''' Строка таблицы контрольных списков, в которую вставляются описания пунктов АПУ
    ''' </summary>
    Private LawRow As DataRow = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Ds">Источник данных АПУ</param>
    ''' <param name="lawId">ID строки таблицы контрольных списков, в которую вставляются описания пунктов АПУ</param>
    Friend Sub New(ByRef Ds As ApuDataSet, lawId As Integer)
        InitializeComponent()
        Me.Ds = Ds
        LawRow = Me.Ds.LawTable.Rows.Find(lawId)
        If LawRow Is Nothing Then Exit Sub
        LawTreeList.DataSource = Me.Ds.LawTable
        SortIdTreeListColumn.SortIndex = 0
        PosDescriptionMemoEdit.DataBindings.Add("Text", Me.Ds.LawTable, "posDescription")
        Me.Text = "Вставка описаний пунктов АПУ в другой пункт"
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
    End Sub


    Private Sub InsertForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If LawRow Is Nothing Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub InsertForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim N As TreeListNode = LawTreeList.FindNodeByKeyID(LawRow("id"))
        If Not N Is Nothing Then LawTreeList.FocusedNode = N
        FindButtonEdit.Focus()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If LawTreeList.GetAllCheckedNodes.Count = 0 Then Exit Sub
        Dim sTmp As String = Nothing
        Dim arr() As String = Nothing
        For Each N As TreeListNode In LawTreeList.GetAllCheckedNodes
            sTmp = String.Format("{0}={1}", sTmp, ToText(N.GetValue("apu")))
        Next
        arr = sTmp.Split(New Char() {"="}, StringSplitOptions.RemoveEmptyEntries)
        sTmp = ToText(ApuComboBoxEdit.EditValue)
        If String.IsNullOrWhiteSpace(sTmp) Then
            sTmp = String.Empty
        Else
            sTmp = vbCrLf & sTmp
        End If
        For i As Integer = arr.GetLowerBound(0) To arr.GetUpperBound(0)
            arr(i) = ToText(arr(i))
        Next
        Array.Sort(arr)
        Dim sTmp1 As String = Nothing
        For i As Integer = arr.GetLowerBound(0) To arr.GetUpperBound(0)
            If String.IsNullOrWhiteSpace(arr(i)) Then Continue For
            If i > 0 AndAlso arr(i) = arr(i - 1) Then Continue For
            sTmp1 = String.Format("{0}{1}={1}{2}", sTmp1, vbCrLf, arr(i) & sTmp)
        Next
        If sTmp1.Length > 5 Then
            sTmp = ToText(LawRow("apu"))
            If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = sTmp & vbCrLf
            LawRow("apu") = sTmp & sTmp1.Substring(5)
        End If
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub InsertForm_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.Enter Then AcceptSimpleButton.PerformClick()
    End Sub

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        If Not IsText(LawTreeList.FindFilterText) Then Exit Sub
        Dim iTmp As Integer = 0
        Select Case e.Button.Index
            Case 0  ' поиск вниз
                iTmp = Ds.LawTable.FindNextIdByText(CInt(CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView)("id")), LawTreeList.FindFilterText)
            Case 1  ' поиск вверх
                iTmp = Ds.LawTable.FindPrevIdByText(CInt(CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView)("id")), LawTreeList.FindFilterText)
            Case 2  ' очистить поле поиска
                FindButtonEdit.EditValue = Nothing
                LawTreeList.FindFilterText = Nothing
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

    Private Sub FindButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindButtonEdit.EditValueChanging
        If Not e.NewValue Is Nothing Then LawTreeList.FindFilterText = e.NewValue.ToString
    End Sub

End Class