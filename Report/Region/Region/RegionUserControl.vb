''' <summary>
''' Отчет по заказам из регионов
''' </summary>
Public Class RegionUserControl

    ''' <summary>
    ''' Представление таблицы работ отфильтрованное по региону
    ''' </summary>
    Private WorkView As DataView = Nothing

    ''' <summary>
    ''' Предсталвение таблицы регионов
    ''' </summary>
    Private RegionView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    Public Sub New(ByRef ParentControl As ReportUserControl)
        InitializeComponent()
        '
        ' WorkView, RegionView
        '
        WorkView = New DataView(ParentControl.WorkTable) With {.RowFilter = "regionId < 0"}
        RegionView = New DataView(ParentControl.RegionTable) With {.RowFilter = "workCount > 0"}
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = RegionView ' ParentControl.RegionTable.DefaultView
        ReportGridView.SortInfo.Insert(0, WorkCountGridColumn, DevExpress.Data.ColumnSortOrder.Descending)
        '
        ' WorkChartControl
        '
        WorkChartControl.DataSource = WorkView
        WorkChartControl.Series(0).LegendText = "нет данных"
    End Sub


    ''' <summary>
    ''' Заблокировать элементы управления перед изменением источника данных
    ''' </summary>
    Friend Sub BeginDataUpdate()
        ReportGridView.CloseEditor()
        ReportGridView.UpdateCurrentRow()
        ReportGridView.BeginDataUpdate()
        WorkChartControl.BeginInit()
    End Sub

    ''' <summary>
    ''' Перечитать данные из источника данных
    ''' </summary>
    Friend Sub EndDataUpdate()
        '
        ' Определение максимальной длины прогрессбара
        '
        Dim maxLen As Integer = 1
        For Each VRow As DataRowView In RegionView
            If CInt(VRow("workCount")) > maxLen Then maxLen = CInt(VRow("workCount"))
        Next
        WorkCountRepositoryItemProgressBar.Maximum = maxLen
        '
        ' Обновление данных из источника данных
        '
        ReportGridView.EndDataUpdate()
        ReportGridView.MoveFirst()
        WorkChartControl.EndInit()
    End Sub

    ''' <summary>
    ''' Изменить временной шаг отображения по работам
    ''' </summary>
    ''' <param name="timeUnit">Шаг отображения</param>
    Friend Sub ChangeTimeUnit(timeUnit As String)
        WorkChartControl.BeginInit()
        With CType(WorkChartControl.Diagram, DevExpress.XtraCharts.XYDiagram).AxisX.DateTimeScaleOptions
            Select Case timeUnit
                Case "День" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Day
                Case "Неделя" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Week
                Case "Месяц" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Month
                Case "Год" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Year
            End Select
        End With
        WorkChartControl.EndInit()
    End Sub

    ''' <summary>
    ''' Поиск текста
    ''' </summary>
    ''' <param name="filterText">Текст для поиска</param>
    Friend Sub FindFilterText(filterText As String)
        ReportGridView.FindFilterText = filterText
    End Sub

    Private Sub ReportGridView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ReportGridView.FocusedRowChanged
        Dim id As Integer = 0
        Dim name As String = Nothing
        Dim Row As DataRow = ReportGridView.GetFocusedDataRow
        If Not Row Is Nothing Then
            id = CInt(Row("id"))
            name = Row("name").ToString
        End If
        WorkChartControl.BeginInit()
        WorkView.RowFilter = String.Format("regionId = {0}", id)
        WorkChartControl.Series(0).LegendText = name
        WorkChartControl.EndInit()
    End Sub

End Class
