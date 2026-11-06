Imports Cprp.DxData.Common
''' <summary>
''' Отчет по поставкам в страны мира
''' </summary>
Public Class ReportUserControl

    ''' <summary>
    ''' Открытое подключение к базе данных EXDB8
    ''' </summary>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Таблица сводного отчета за весь период
    ''' </summary>
    Private ReportTable As ReportDataTable = Nothing

    ''' <summary>
    ''' Таблица принятых заявок на оказание услуг
    ''' </summary>
    Private OrderTable As WorkDataTable = Nothing

    ''' <summary>
    ''' Таблица рассмотренных заявок на оказание услуг
    ''' </summary>
    Private OrderCloseTable As WorkDataTable = Nothing

    ''' <summary>
    ''' Таблица утвержденных работ
    ''' </summary>
    Private WorkAcceptTable As WorkDataTable = Nothing

    ''' <summary>
    ''' Таблица закрытых работ
    ''' </summary>
    Private WorkCloseTable As WorkDataTable = Nothing

    ''' <summary>
    ''' Представление принятых заявок на оказание услуг
    ''' </summary>
    Private OrderView As DataView = Nothing

    ''' <summary>
    ''' Представление рассмотренных заявок на оказание услуг
    ''' </summary>
    Private OrderCloseView As DataView = Nothing

    ''' <summary>
    ''' Представление утвержденных работ
    ''' </summary>
    Private WorkAcceptView As DataView = Nothing

    ''' <summary>
    ''' Представление закрытых работ
    ''' </summary>
    Private WorkCloseView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных EXDB8</param>
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
        ' Data
        '
        ReportTable = New ReportDataTable
        OrderTable = New WorkDataTable With {.TableName = "OrderTable"}
        OrderCloseTable = New WorkDataTable With {.TableName = "OrderCloseTable"}
        WorkAcceptTable = New WorkDataTable With {.TableName = "WorkAcceptTable"}
        WorkCloseTable = New WorkDataTable With {.TableName = "WorkCloseTable"}
        OrderView = New DataView(OrderTable)
        OrderCloseView = New DataView(OrderCloseTable)
        WorkAcceptView = New DataView(WorkAcceptTable)
        WorkCloseView = New DataView(WorkCloseTable)
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportTable
        ReportGridView.SortInfo.Insert(0, ReportDateGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' ReportChartControl
        '
        ReportChartControl.DataSource = ReportTable
        'ReportChartControl.Series(0).LegendText = "нет данных"
        '
        ' BeginDateEdit, EndDateEdit  
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddMonths(-1)
        DateEndBarEditItem.EditValue = Date.Today
        '
        ' UnitComboBoxEdit
        '
        StepBarEditItem.EditValue = "День"

        WorkReload()

    End Sub


    ''' <summary>
    ''' Перечитать данные работ из базы
    ''' </summary>
    Private Sub WorkReload()
        If DateBeginBarEditItem.EditValue Is Nothing Then Exit Sub
        If DateEndBarEditItem.EditValue Is Nothing Then Exit Sub

        Dim dateB As Date = CDate(DateBeginBarEditItem.EditValue)
        Dim dateE As Date = CDate(DateEndBarEditItem.EditValue).AddDays(1)

        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)

        OrderTable.Rows.Clear()
        OrderCloseTable.Rows.Clear()
        WorkAcceptTable.Rows.Clear()
        WorkCloseTable.Rows.Clear()

        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT id, createDate AS workDate FROM tWork WHERE createDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND createDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND (typeId = 99 OR typeId = 117) AND conditionId <> 8", dateB, dateE)
            OrderTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = String.Format("SELECT id, closeDate AS workDate FROM tWork WHERE closeDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND closeDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND (typeId = 99 OR typeId = 117) AND conditionId <> 8", dateB, dateE)
            OrderCloseTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = String.Format("SELECT id, acceptDate AS workDate FROM tWork WHERE acceptDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND acceptDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND typeId <> 99 AND typeId <> 117 AND conditionId <> 8", dateB, dateE)
            WorkAcceptTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = String.Format("SELECT id, closeDate AS workDate FROM tWork WHERE closeDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND closeDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND typeId <> 99 AND typeId <> 117 AND conditionId <> 8", dateB, dateE)
            WorkCloseTable.Load(Cmd.ExecuteReader)
        End Using

        Cprp.DxCommon.WaitForm.Close()

        ReportReload(StepBarEditItem.EditValue.ToString)

    End Sub

    ''' <summary>
    ''' Перечитать данные отчета по таблицам работ
    ''' </summary>
    ''' <param name="stp">Временной шаг таблицы отчета</param>
    Private Sub ReportReload(stp As String)
        stp = ToText(stp)
        If String.IsNullOrWhiteSpace(stp) Then Exit Sub

        If DateBeginBarEditItem.EditValue Is Nothing Then Exit Sub
        If DateEndBarEditItem.EditValue Is Nothing Then Exit Sub

        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)

        Dim dateB As Date = CDate(DateBeginBarEditItem.EditValue)
        Dim dateE As Date = CDate(DateEndBarEditItem.EditValue).AddDays(1)
        Dim dateS As Date = dateB

        ReportGridView.CloseEditor()
        ReportGridView.UpdateCurrentRow()
        ReportGridView.BeginDataUpdate()
        ReportChartControl.BeginInit()

        ReportTable.Rows.Clear()

        Dim Row As DataRow = Nothing
        Do
            If dateB >= dateE Then Exit Do
            Select Case stp
                Case "День" : dateS = dateB.AddDays(1) : Exit Select
                Case "Неделя" : dateS = dateB.AddDays(7) : Exit Select
                Case "Месяц" : dateS = dateB.AddMonths(1) : Exit Select
                Case Else : dateS = dateB.AddDays(1)
            End Select
            If dateS > dateE Then dateS = dateE

            Row = ReportTable.NewRow
            Row("reportDate") = dateS
            OrderView.RowFilter = String.Format("workDate >= '{0:yyyy-MM-dd}' AND workDate < '{1:yyyy-MM-dd}'", dateB, dateS)
            Row("orderCount") = OrderView.Count
            OrderCloseView.RowFilter = String.Format("workDate >= '{0:yyyy-MM-dd}' AND workDate < '{1:yyyy-MM-dd}'", dateB, dateS)
            Row("orderCloseCount") = OrderCloseView.Count
            WorkAcceptView.RowFilter = String.Format("workDate >= '{0:yyyy-MM-dd}' AND workDate < '{1:yyyy-MM-dd}'", dateB, dateS)
            Row("workAcceptCount") = WorkAcceptView.Count
            WorkCloseView.RowFilter = String.Format("workDate >= '{0:yyyy-MM-dd}' AND workDate < '{1:yyyy-MM-dd}'", dateB, dateS)
            Row("workCloseCount") = WorkCloseView.Count
            ReportTable.Rows.Add(Row)

            dateB = dateS
        Loop

        ReportGridView.EndDataUpdate()
        ReportGridView.MoveFirst()
        ReportChartControl.EndInit()
        Cprp.DxCommon.WaitForm.Close()

    End Sub

    Private Sub BeginRepositoryItemDateEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles BeginRepositoryItemDateEdit.EditValueChanging
        DateBeginBarEditItem.EditValue = e.NewValue
        WorkReload()
    End Sub

    Private Sub EndRepositoryItemDateEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles EndRepositoryItemDateEdit.EditValueChanging
        DateEndBarEditItem.EditValue = e.NewValue
        WorkReload()
    End Sub

    Private Sub StepRepositoryItemComboBox_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles StepRepositoryItemComboBox.EditValueChanging
        StepBarEditItem.EditValue = e.NewValue
        ReportReload(e.NewValue.ToString)

        'ReportChartControl.BeginInit()
        'With CType(ReportChartControl.Diagram, DevExpress.XtraCharts.XYDiagram).AxisX.DateTimeScaleOptions
        '    Select Case StepBarEditItem.EditValue.ToString
        '        Case "День" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Day
        '        Case "Неделя" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Week
        '        Case "Месяц" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Month
        '        Case "Год" : .MeasureUnit = DevExpress.XtraCharts.DateTimeMeasureUnit.Year
        '    End Select
        'End With
        'ReportChartControl.EndInit()
    End Sub

    Private Sub ExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Количество работ"
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

End Class
