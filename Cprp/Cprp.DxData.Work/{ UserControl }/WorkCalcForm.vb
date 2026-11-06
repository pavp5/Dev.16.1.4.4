''' <summary>
''' Форма стоимости работы
''' </summary>
Friend Class WorkCalcForm


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Work">Работа</param>
    Friend Sub New(Work As WorkConnectionRow)
        InitializeComponent()
        '
        ' CalcGridControl, CalcGridView
        '
        CalcGridControl.DataSource = Work.CalcTable
        CalcGridView.SortInfo.Insert(0, IdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Me
        '
        Me.Text = "Стоимость работы"
        Me.CenterToScreen()
    End Sub

End Class