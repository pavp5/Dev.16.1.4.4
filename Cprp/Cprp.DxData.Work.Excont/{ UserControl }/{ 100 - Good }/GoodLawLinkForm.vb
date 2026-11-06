Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма для связей пунктов контрольных списков в исследовании объекта экспертизы
''' </summary>
''' <remarks></remarks>
Friend Class GoodLawLinkForm

    ''' <summary>
    ''' Представление с пунктами, выбранными для сравнительного анализа
    ''' </summary>
    ''' <remarks></remarks>
    Private _SelectView As DataView = Nothing

    ''' <summary>
    ''' Таблица связанных пунктов одного выбранного пункта
    ''' </summary>
    ''' <remarks></remarks>
    Private _PosTable As DataTable = Nothing


    ''' <summary>
    ''' Описание пункта, выделенного для привязки к пункту, выбранному для сравнительного анализа
    ''' </summary>
    ''' <remarks></remarks>
    Private childDescription As String = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="MainControl">Главный элемент управления</param> 
    ''' <param name="childId">ID пункта, выделенного для привязки к пункту, выбранному для сравнительного анализа</param>
    ''' <remarks></remarks>
    Friend Sub New(ByRef MainControl As WorkUserControl, childId As Object)
        InitializeComponent()
        '
        ' Представление с пунктами, выбранными для сравнительного анализа
        '
        _SelectView = New DataView(MainControl.Work.LawDataSet.LawTable)
        _SelectView.RowFilter = "summaryId > 0"
        _SelectView.Sort = "doc, id"
        '
        ' Таблица связанных пунктов одного выбранного пункта
        '
        _PosTable = New DataTable
        With _PosTable.Columns
            .Add("id", GetType(Integer))            ' ID
            .Add("sortId", GetType(Integer))        ' сортировка
            .Add("posDescription", GetType(String)) ' описание пункта
            .Add("isMain", GetType(Boolean))        ' основной пункт, вокруг которого создаются привязки
        End With
        _PosTable.PrimaryKey = New DataColumn() {_PosTable.Columns("id")}
        '
        ' Описание пункта, выделенного для привязки к пункту, выбранному для сравнительного анализа
        '
        Dim Row As DataRow = MainControl.Work.LawDataSet.LawTable.Rows.Find(childId)
        If Not Row Is Nothing Then childDescription = C2.ToText(Row("posDescription"))
        '
        ' SummaryGridControl
        '
        SummaryGridControl.DataSource = _SelectView
        '
        ' PosGridControl, PosGridView
        '
        PosGridControl.DataSource = _PosTable
        PosGridView.SortInfo.Insert(0, PosSortIdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Me
        '
        Me.Text = "Связи пунктов контрольных списков"
        Me.Width = Screen.GetWorkingArea(Me).Height
        Me.Height = Screen.GetWorkingArea(Me).Height - 40
        Me.CenterToScreen()

    End Sub

    Private Sub GoodLawLinkForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        SummaryLayoutControlGroup.GroupBordersVisible = False
        PosLayoutControlGroup.GroupBordersVisible = False
        NextSimpleButton.Enabled = (SummaryGridView.RowCount > 0)
        BackSimpleButton.PerformClick()
    End Sub

    ' Далее
    Private Sub NextSimpleButton_Click(sender As Object, e As EventArgs) Handles NextSimpleButton.Click
        If SummaryGridView.FocusedRowHandle < 0 Then Exit Sub
        PosGridView.BeginUpdate()
        _PosTable.Rows.Clear()
        Dim Arr() As String = SummaryGridView.GetFocusedDataRow("lawDescription").ToString.Split(New Char() {Chr(1)}, StringSplitOptions.RemoveEmptyEntries)
        Dim sTmp As String = C2.ToText(SummaryGridView.GetFocusedDataRow("posDescription")).ToUpper
        Dim bTmp As Boolean = False
        For i As Integer = Arr.GetLowerBound(0) To Arr.GetUpperBound(0)
            bTmp = (C2.ToText(Arr(i)).ToUpper = sTmp)
            _PosTable.Rows.Add(New Object() {i + 1, i + 1, C2.ToText(Arr(i)), bTmp})
        Next
        _PosTable.Rows.Add(New Object() {_PosTable.Rows.Count + 1, _PosTable.Rows.Count + 1, childDescription, False})
        PosGridView.EndUpdate()
        SummaryLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        PosLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    End Sub

    ' Вверх
    Private Sub MoveUpBarButtonItem_ItemClick(sender As Object, e As EventArgs) Handles MoveUpBarButtonItem.ItemClick
        If PosGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim rowId As Integer = C2.ToInt(PosGridView.GetFocusedDataRow("id"))
        Dim iTmp As Integer = 0
        Using V As New DataView(_PosTable)
            V.Sort = "sortId"
            For i As Integer = 0 To V.Count - 1
                If C2.ToInt(V(i)("id")) = rowId Then
                    If i = 0 Then Exit Sub
                    PosGridView.BeginUpdate()
                    iTmp = V(i)("sortId")
                    V(i)("sortId") = V(i - 1)("sortId")
                    V(i - 1)("sortId") = iTmp
                    _PosTable.AcceptChanges()
                    PosGridView.RefreshData()
                    PosGridView.EndUpdate()
                    Exit Sub
                End If
            Next
        End Using
        iTmp = 0
        Do
            If PosGridView.GetRow(iTmp) Is Nothing Then Exit Do
            If C2.ToInt(PosGridView.GetRow(iTmp)) = rowId Then
                PosGridView.FocusedRowHandle = iTmp
                Exit Do
            End If
            iTmp += 1
        Loop
        PosGridView.Focus()
    End Sub

    ' Вниз
    Private Sub MoveDownBarButtonItem_ItemClick(sender As Object, e As EventArgs) Handles MoveDownBarButtonItem.ItemClick
        If PosGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim rowId As Integer = C2.ToInt(PosGridView.GetFocusedDataRow("id"))
        Dim iTmp As Integer = 0
        Using V As New DataView(_PosTable)
            V.Sort = "sortId"
            For i As Integer = 0 To V.Count - 1
                If C2.ToInt(V(i)("id")) = rowId Then
                    If i = (V.Count - 1) Then Exit Sub
                    PosGridView.BeginUpdate()
                    iTmp = V(i)("sortId")
                    V(i)("sortId") = V(i + 1)("sortId")
                    V(i + 1)("sortId") = iTmp
                    _PosTable.AcceptChanges()
                    PosGridView.RefreshData()
                    PosGridView.EndUpdate()
                    Exit Sub
                End If
            Next
        End Using
        iTmp = 0
        Do
            If PosGridView.GetRow(iTmp) Is Nothing Then Exit Do
            If C2.ToInt(PosGridView.GetRow(iTmp)) = rowId Then
                PosGridView.FocusedRowHandle = iTmp
                Exit Do
            End If
            iTmp += 1
        Loop
        PosGridView.Focus()
    End Sub

    ' Удалить
    Private Sub DeleteBarButtonItem_ItemClick(sender As Object, e As EventArgs) Handles DeleteBarButtonItem.ItemClick
        If PosGridView.FocusedRowHandle < 0 Then Exit Sub
        If CBool(PosGridView.GetFocusedDataRow("isMain")) Then Exit Sub
        PosGridView.GetFocusedDataRow.Delete()
        _PosTable.AcceptChanges()
        PosGridView.RefreshData()
        PosGridView.Focus()
    End Sub

    ' Назад
    Private Sub BackSimpleButton_Click(sender As Object, e As EventArgs) Handles BackSimpleButton.Click
        PosLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        SummaryLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    End Sub

    ' Применить
    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If SummaryGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = Nothing
        Using V As New DataView(_PosTable)
            V.Sort = "sortId"
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0}{1}{2}{3}", sTmp, Chr(1), vbCrLf, V(i)("posDescription").ToString)
            Next
        End Using
        SummaryGridView.GetFocusedDataRow("lawDescription") = sTmp.Substring(3)
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class