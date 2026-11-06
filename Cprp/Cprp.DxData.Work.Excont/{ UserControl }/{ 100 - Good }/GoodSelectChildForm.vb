Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма выбора объектов, входящих в состав объекта экспертизы
''' </summary>
Public Class GoodSelectChildForm

    ' Главный элемент управления
    Private P As WorkUserControl = Nothing

    ' Строка из таблицы объектов экспертизы, для которой выбираются дочерние объекты
    Private _GoodRow As DataRow = Nothing

    ' Таблица объектов экспертизы, из которых выбираются дочерние объекты
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
        ' в части ничего не может входить
        If Not bChild Then
            For Each Row As DataRow In P.Work.GoodTable.Rows
                If CInt(Row("id")) = id Then Continue For
                If CInt(Row("id")) = parentId Then Continue For
                TRow = P.Work.GoodTypeHandbookTable.Rows.Find(C2.ToInt(Row("typeId")))
                If TRow Is Nothing Then Continue For
                ' система не может входить в состав других объектов
                If CBool(TRow("isParent")) Then Continue For
                ' оборудование не может входить в состав другого оборудования
                If Not (bParent OrElse CBool(TRow("isChild"))) Then Continue For
                ' добавление строки в таблицу
                _GoodTable.Rows.Add(New Object() {
                                    Row("id"), _
                                    (C2.ToInt(Row("parentId")) = id), _
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
        Me.Text = String.Format("Выбор объектов, входящих в состав объекта № {0} ({1})", C2.ToInt(_GoodRow("rowNum")), C2.DelPoint(_GoodRow("nameCon")))
        Me.Width = Screen.GetWorkingArea(Me).Height
        Me.Height = Screen.GetWorkingArea(Me).Height - 100
        Me.CenterToScreen()

    End Sub


    Private Sub GoodSelectChildForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _GoodRow Is Nothing Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        Dim GRow As DataRow = Nothing
        For Each Row As DataRow In _GoodTable.Rows
            GRow = P.Work.GoodTable.Rows.Find(Row("id"))
            If CBool(Row("isCheck")) Then
                GRow("parentId") = _GoodRow("id")
            Else
                GRow("parentId") = DBNull.Value
            End If
        Next
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class