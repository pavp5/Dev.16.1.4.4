Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма выбора объекта, в состав которого входит объект экспертизы
''' </summary>
Friend Class GoodSelectParentForm

    ' Главный элемент управления
    Private P As WorkUserControl = Nothing

    ' Строка из таблицы объектов экспертизы, для которой выбирается родительский объект
    Private _GoodRow As DataRow = Nothing

    ' Таблица объектов экспертизы, из которых выбирается родительский объект
    Private _GoodTable As DataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="MainControl">Главный элемент управления</param> 
    ''' <param name="GoodRow">Строка с объектом экспертизы, для которого выбирается родительский объект</param>
    ''' <remarks></remarks>
    Friend Sub New(ByRef MainControl As WorkUserControl, ByRef GoodRow As DataRow)
        InitializeComponent()
        '
        ' P
        '
        P = MainControl
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        '
        ' _GoodRow
        '
        If GoodRow Is Nothing Then Exit Sub
        If GoodRow.RowState = DataRowState.Deleted OrElse GoodRow.RowState = DataRowState.Detached Then Exit Sub
        If Not GoodRow.Table Is P.Work.GoodTable Then Exit Sub
        _GoodRow = GoodRow
        '
        ' _GoodTable (структура)
        '
        _GoodTable = New DataTable
        With _GoodTable.Columns
            .Add("id", GetType(Integer))
            .Add("isCheck", GetType(Boolean))
            .Add("rowNum", GetType(Integer))
            .Add("nameCon", GetType(String))
        End With
        _GoodTable.PrimaryKey = New DataColumn() {_GoodTable.Columns("id")}
        '
        ' _GoodTable (данные)
        '
        Dim id As Integer = CInt(_GoodRow("id"))
        Dim parentId As Integer = C2.ToInt(_GoodRow("parentId"))
        Dim bParent As Boolean = False  ' объект является системой
        Dim bChild As Boolean = False   ' объект является частью
        Dim TRow As DataRow = P.Work.GoodTypeHandbookTable.Rows.Find(C2.ToInt(_GoodRow("typeId")))
        If Not TRow Is Nothing Then
            bParent = CBool(TRow("isParent"))
            bChild = CBool(TRow("isChild"))
        End If
        ' система не может входить в другие системы
        If Not bParent Then
            For Each Row As DataRow In P.Work.GoodTable.Rows
                If CInt(Row("id")) = id Then Continue For
                TRow = P.Work.GoodTypeHandbookTable.Rows.Find(C2.ToInt(Row("typeId")))
                If TRow Is Nothing Then Continue For
                ' части не могут содержать объекты
                If CBool(TRow("isChild")) Then Continue For
                ' оборудование не может входить в состав другого оборудования
                If Not (bChild OrElse CBool(TRow("isParent"))) Then Continue For
                ' добавление строки в таблицу
                _GoodTable.Rows.Add(New Object() {
                                    Row("id"), _
                                    (C2.ToInt(Row("id")) = parentId), _
                                    Row("rowNum"), _
                                    Row("nameCon")})
            Next
        End If
        AcceptSimpleButton.Enabled = (_GoodTable.Rows.Count > 0)
        '
        ' ListGridControl, ListGridView
        '
        ListGridControl.DataSource = _GoodTable
        ListGridView.SortInfo.Insert(0, RowNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Me
        '
        Me.Text = String.Format("Выбор объекта, в состав которого входит объект № {0} ({1})", C2.ToInt(_GoodRow("rowNum")), C2.DelPoint(_GoodRow("nameCon")))
        Me.Width = Screen.GetWorkingArea(Me).Height
        Me.Height = Screen.GetWorkingArea(Me).Height - 100
        Me.CenterToScreen()

    End Sub


    Private Sub GoodSelectParentForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _GoodRow Is Nothing Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If
    End Sub

    Private Sub ListGridView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ListGridView.CellValueChanging
        If Not e.Column Is IsCheckGridColumn Then Exit Sub
        If Not CBool(e.Value) Then Exit Sub
        Using V As New DataView(_GoodTable)
            V.RowFilter = String.Format("isCheck = True AND id <> {0}", CInt(ListGridView.GetDataRow(e.RowHandle)("id")))
            While V.Count > 0
                V(0)("isCheck") = False
            End While
        End Using
        _GoodTable.AcceptChanges()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        '
        ' Представление с выбранной строкой списка объекта экспертизы
        '
        Using V As New DataView(_GoodTable)
            V.RowFilter = "isCheck = True"
            If V.Count = 0 Then
                _GoodRow("parentId") = DBNull.Value
            Else
                _GoodRow("parentId") = V(0)("id")
            End If
        End Using

        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class