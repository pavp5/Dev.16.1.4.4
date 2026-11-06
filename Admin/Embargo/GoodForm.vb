''' <summary>
''' Форма редактирования товаров из запретов и ограничений
''' </summary>
Friend Class GoodForm

    ''' <summary>
    ''' Источник данных запретов и ограничений
    ''' </summary>
    Private Ds As EmbargoDataSet = Nothing

    ''' <summary>
    ''' ID записи из таблицы запретов и ограничений
    ''' </summary>
    Private embargoId As Integer = 0

    ''' <summary>
    ''' Представление товаров для редактирования
    ''' </summary>
    Private GoodView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Ds">Источник данных запретов и ограничений</param>
    ''' <param name="embargoId">ID записи из таблицы запретов и ограничений</param>
    Friend Sub New(Ds As EmbargoDataSet, embargoId As Integer)
        InitializeComponent()
        Me.Ds = Ds
        Me.embargoId = embargoId
        GoodView = New DataView(Me.Ds.GoodTable)
        GoodView.RowFilter = String.Format("embargoId = {0}", Me.embargoId)
        GoodGridControl.DataSource = GoodView
        GoodGridView.SortInfo.Insert(0, IdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        Me.Text = String.Format("Товары (embargoId = {0})", Me.embargoId)
        Me.Width = Screen.GetWorkingArea(Me).Width - 20
        Me.Height = Screen.GetWorkingArea(Me).Height - 20
        Me.CenterToScreen()
    End Sub


    Private Sub MemberGridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles GoodGridView.InitNewRow
        GoodGridView.SetRowCellValue(e.RowHandle, "id", Ds.MemberTable.NewId)
        GoodGridView.SetRowCellValue(e.RowHandle, "embargoId", Me.embargoId)
        GoodGridView.SetRowCellValue(e.RowHandle, "caption", "[новый товар]")
    End Sub

    Private Sub GoodForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        GoodGridView.CloseEditor()
        GoodGridView.UpdateCurrentRow()
    End Sub

End Class