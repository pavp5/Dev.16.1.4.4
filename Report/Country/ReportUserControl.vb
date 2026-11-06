Imports Cprp.DxData.Common
''' <summary>
''' Отчет по поставкам в страны мира
''' </summary>
Public Class ReportUserControl

    ''' <summary>
    ''' Открытое подключение к базе данных EXDBA
    ''' </summary>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Таблица сводного отчета за весь период
    ''' </summary>
    Private ReportTable As ReportDataTable = Nothing

    ''' <summary>
    ''' Таблица отчета по работам за период
    ''' </summary>
    Private WorkTable As WorkDataTable = Nothing

    ''' <summary>
    ''' Представление таблицы отчета по работам за период
    ''' </summary>
    Private WorkView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных EXDBA</param>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        Me.Connection = Connection
        '
        ' ReportTable, ReportGridControl, ReportGridView
        '
        ReportTable = New ReportDataTable
        ReportGridControl.DataSource = ReportTable
        ReportGridView.SortInfo.Insert(0, WorkCountGridColumn, DevExpress.Data.ColumnSortOrder.Descending)
        '
        ' WorkTable, WorkView, WorkChartControl
        '
        WorkTable = New WorkDataTable
        WorkView = New DataView(WorkTable) With {.RowFilter = "id < 0"}
        WorkChartControl.DataSource = WorkView
        WorkChartControl.Series(0).LegendText = "нет данных"
        '
        ' BeginDateEdit, EndDateEdit  
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddYears(-2)
        DateEndBarEditItem.EditValue = Date.Today
        '
        ' UnitComboBoxEdit
        '
        StepBarEditItem.EditValue = "Месяц"

        DataReload()

    End Sub


    ''' <summary>
    ''' Перечитать данные из базы
    ''' </summary>
    Private Sub DataReload()
        If DateBeginBarEditItem.EditValue Is Nothing Then Exit Sub
        If DateEndBarEditItem.EditValue Is Nothing Then Exit Sub

        Dim dateB As Date = CDate(DateBeginBarEditItem.EditValue)
        Dim dateE As Date = CDate(DateEndBarEditItem.EditValue)

        Dim iTmp As Integer = 0
        Dim sTmp As String = Nothing

        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ReportGridView.CloseEditor()
        ReportGridView.UpdateCurrentRow()
        ReportGridView.BeginDataUpdate()
        WorkChartControl.BeginInit()

        ReportTable.Rows.Clear()
        WorkTable.Rows.Clear()
        '
        ' Загрузка данных по работам
        '
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT id, countryId, countryName, orderNum, orderDate, orderUrl, clientName, description FROM vWorkData WHERE orderDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND orderDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND NOT countryId IS NULL", dateB, dateE)
            WorkTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' Формирование сводного отчета по странам
        '
        Using V As New DataView(WorkTable)
            For Each Row As DataRow In WorkTable.Rows
                If CBool(Row("isTemp")) Then Continue For ' пропуск обработанной строки
                iTmp = CInt(Row("countryId"))
                sTmp = Row("countryName").ToString
                V.RowFilter = String.Format("countryId = {0}", iTmp)
                ReportTable.Rows.Add(New Object() {iTmp, sTmp, V.Count})
                For Each VRow As DataRowView In V           ' пометка обработанных строк
                    VRow("isTemp") = True
                Next
            Next
        End Using
        '
        ' Определение максимальной длины прогрессбара
        '
        iTmp = 1
        For Each Row As DataRow In ReportTable.Rows
            If CInt(Row("workCount")) > iTmp Then iTmp = CInt(Row("workCount"))
        Next
        WorkCountRepositoryItemProgressBar.Maximum = iTmp

        ReportGridView.EndDataUpdate()
        ReportGridView.MoveFirst()
        WorkChartControl.EndInit()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    Private Sub ReportGridView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ReportGridView.FocusedRowChanged
        Dim countryId As Integer = 0
        Dim countryName As String = Nothing
        If ReportGridView.FocusedRowHandle >= 0 Then
            countryId = CInt(ReportGridView.GetFocusedDataRow("countryId"))
            countryName = ReportGridView.GetFocusedDataRow("countryName").ToString
        End If
        WorkChartControl.BeginInit()
        WorkView.RowFilter = String.Format("countryId = {0}", countryId)
        WorkChartControl.Series(0).LegendText = countryName
        WorkChartControl.EndInit()
    End Sub

    Private Sub FindRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindRepositoryItemButtonEdit.ButtonClick
        FindRepositoryItemButtonEdit.BeginUpdate()
        FindBarEditItem.EditValue = Nothing
        FindRepositoryItemButtonEdit.EndUpdate()
        ReportGridView.FindFilterText = Nothing
    End Sub

    Private Sub FindRepositoryItemButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemButtonEdit.EditValueChanging
        If e.NewValue Is Nothing Then
            ReportGridView.FindFilterText = Nothing
        Else
            ReportGridView.FindFilterText = e.NewValue.ToString
        End If
    End Sub

    Private Sub BeginRepositoryItemDateEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles BeginRepositoryItemDateEdit.EditValueChanging
        DateBeginBarEditItem.EditValue = e.NewValue
        DataReload()
    End Sub

    Private Sub EndRepositoryItemDateEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles EndRepositoryItemDateEdit.EditValueChanging
        DateEndBarEditItem.EditValue = e.NewValue
        DataReload()
    End Sub

    Private Sub StepRepositoryItemComboBox_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles StepRepositoryItemComboBox.EditValueChanging
        StepBarEditItem.EditValue = e.NewValue
        WorkChartControl.BeginInit()
        With CType(WorkChartControl.Diagram, DevExpress.XtraCharts.XYDiagram).AxisX.DateTimeScaleOptions
            Select Case StepBarEditItem.EditValue.ToString
                Case "День" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Day
                Case "Неделя" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Week
                Case "Месяц" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Month
                Case "Год" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Year
            End Select
        End With
        WorkChartControl.EndInit()
    End Sub

    Private Sub WorkListBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkListBarButtonItem.ItemClick
        If ReportGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim countryId As Integer = ToInt(ReportGridView.GetFocusedDataRow("countryId"))
        Dim countryName As String = ToText(ReportGridView.GetFocusedDataRow("countryName"))
        For Each F As Form In Application.OpenForms
            If Not TypeOf F Is WorkListForm Then Continue For
            If CType(F, WorkListForm).CountryId <> countryId Then Continue For
            F.WindowState = FormWindowState.Normal
            F.TopMost = True
            F.TopMost = False
            Exit Sub
        Next
        With New WorkListForm(WorkTable, countryId)
            .Text = String.Format("{0} - список заказов", countryName)
            .Show()
        End With
    End Sub

    Private Sub ExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Поставки по странам"
            Dlg.DefaultExt = "xlsx"
            Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        Try
            ReportGridView.ExportToXlsx(filePath)
            Using P As New Process
                P.StartInfo.FileName = filePath
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    Private Sub ReportGridControl_DoubleClick(sender As Object, e As EventArgs) Handles ReportGridControl.DoubleClick
        WorkListBarButtonItem.PerformClick()
    End Sub

End Class
