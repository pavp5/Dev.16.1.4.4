''' <summary>
''' Форма редактирования фирм из запретов и ограничений
''' </summary>
Friend Class MemberForm

    ''' <summary>
    ''' Источник данных запретов и ограничений
    ''' </summary>
    Private Ds As EmbargoDataSet = Nothing

    ''' <summary>
    ''' ID записи из таблицы запретов и ограничений
    ''' </summary>
    Private embargoId As Integer = 0

    ''' <summary>
    ''' Представление фирм для редактирования
    ''' </summary>
    Private MemberView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Ds">Источник данных запретов и ограничений</param>
    ''' <param name="embargoId">ID записи из таблицы запретов и ограничений</param>
    Friend Sub New(Ds As EmbargoDataSet, embargoId As Integer)
        InitializeComponent()
        Me.Ds = Ds
        Me.embargoId = embargoId
        MemberView = New DataView(Me.Ds.MemberTable)
        MemberView.RowFilter = String.Format("embargoId = {0}", Me.embargoId)
        CountryRepositoryItemLookUpEdit.DataSource = Me.Ds.CountryTable
        MemberGridControl.DataSource = MemberView
        MemberGridView.SortInfo.Insert(0, IdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        Me.Text = String.Format("Фирмы (embargoId = {0})", Me.embargoId)
        Me.Width = Screen.GetWorkingArea(Me).Width - 20
        Me.Height = Screen.GetWorkingArea(Me).Height - 20
        Me.CenterToScreen()
    End Sub


    Private Sub MemberGridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles MemberGridView.InitNewRow
        MemberGridView.SetRowCellValue(e.RowHandle, "id", Ds.MemberTable.NewId)
        MemberGridView.SetRowCellValue(e.RowHandle, "embargoId", Me.embargoId)
        MemberGridView.SetRowCellValue(e.RowHandle, "caption", "[новая фирма]")
        MemberGridView.SetRowCellValue(e.RowHandle, "description", "[новая фирма]")
    End Sub

    Private Sub MemberForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        MemberGridView.CloseEditor()
        MemberGridView.UpdateCurrentRow()
    End Sub

End Class