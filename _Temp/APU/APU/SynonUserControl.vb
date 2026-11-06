Imports Cprp.DxData.Common
''' <summary>
''' Элемент управления "Синонимы"
''' </summary>
Friend Class SynonUserControl : Implements IChildControl

#Region "IChildControl"

    Friend Sub CloseEditor() Implements IChildControl.CloseEDitor
        SynonGridView.CloseEditor()
        SynonGridView.UpdateCurrentRow()
    End Sub

    Friend Sub BeginDataUpdate() Implements IChildControl.BeginDataUpdate
        SynonGridView.CloseEditor()
        SynonGridView.BeginDataUpdate()
    End Sub

    Friend Sub EndDataUpdate() Implements IChildControl.EndDataUpdate
        SynonGridView.EndDataUpdate()
        SynonGridView.MoveFirst()
    End Sub

#End Region

    ''' <summary>
    ''' Источник данных АПУ
    ''' </summary>
    Private Ds As ApuDataSet = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Ds">Источник данных АПУ</param>
    Friend Sub New(ByRef Ds As ApuDataSet)
        InitializeComponent()
        Me.Ds = Ds
        SynonGridControl.DataSource = Me.Ds.SynonTable
        SynonGridView.SortInfo.Insert(0, Word1GridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        AutoHeightBarCheckItem.Checked = True
    End Sub


    ' Выровнять высоту строк
    Private Sub AutoheightBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AutoHeightBarCheckItem.CheckedChanged
        SynonGridView.OptionsView.RowAutoHeight = AutoHeightBarCheckItem.Checked
    End Sub

    Private Sub FindRepositoryItemTextEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemTextEdit.EditValueChanging
        SynonGridView.ApplyFindFilter(ToText(e.NewValue))
    End Sub

End Class
