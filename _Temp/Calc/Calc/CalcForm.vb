''' <summary>
''' Калькулятор
''' </summary>
Friend Class CalcForm

    ''' <summary>
    ''' Последняя добавленная строка с услугой
    ''' </summary>
    Private LastRow As DataRow = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        InitializeComponent()
        '
        ' CalcGridControl
        '
        CalcGridControl.DataSource = Program.Calc.CalcTable
        '
        ' Me
        '
        Me.Icon = My.Resources.calc_ico
        Me.Text = "Калькулятор стоимости услуг"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

    End Sub


    Private Sub CalcGridView_CustomDrawCell(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles CalcGridView.CustomDrawCell
        Dim sTmp As String = Nothing
        If Not (e.CellValue Is Nothing OrElse IsDBNull(e.CellValue)) Then sTmp = e.CellValue.ToString
        If Not String.IsNullOrEmpty(sTmp) Then Exit Sub
        Select Case e.Column.FieldName
            Case "price"
                e.DisplayText = "[нет]"
                e.Appearance.ForeColor = Drawing.Color.DimGray
        End Select
    End Sub

    ' Добавить услугу
    Private Sub ServiceAddBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ServiceAddBarButtonItem.ItemClick
        Dim serviceId As Integer = Cprp.DxData.Common.EMPTY_ID
        With New ServiceForm(serviceId)
            If .ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            serviceId = .ServiceId
        End With
        CalcGridView.CloseEditor()
        CalcGridView.UpdateCurrentRow()
        With Program.Calc.CalcTable
            Dim Row As DataRow = .NewRow
            Row("serviceId") = serviceId
            Row("description") = Program.Calc.ServiceTable.FullName(serviceId)
            If Not LastRow Is Nothing Then
                Row("materialCount") = LastRow("materialCount")
                Row("informationCount") = LastRow("informationCount")
                Row("orderNum") = LastRow("orderNum")
                Row("goodCount") = LastRow("goodCount")
                Row("addCountryCount") = LastRow("addCountryCount")
                Row("languageCount") = LastRow("languageCount")
                Row("hourCount") = LastRow("hourCount")
                Row("oldPrice") = LastRow("oldPrice")
                Row("isUrgency") = LastRow("isUrgency")
            End If
            .Rows.Add(Row)
            LastRow = Row
        End With
        CalcGridView.RefreshData()
    End Sub

    ' Удалить услугу
    Private Sub ServiceDelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ServiceDelBarButtonItem.ItemClick
        CalcGridView.CloseEditor()
        CalcGridView.UpdateCurrentRow()
        If CalcGridView.FocusedRowHandle < 0 Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Удалить услугу?") <> Windows.Forms.DialogResult.Yes Then Exit Sub
        Dim Row As DataRow = CalcGridView.GetFocusedDataRow
        If Row Is LastRow Then LastRow = Nothing
        Row.Delete()
        Program.Calc.CalcTable.AcceptChanges()
        CalcGridView.RefreshData()
    End Sub

    ' Изменить вид услуги
    Private Sub ServiceEditBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ServiceEditBarButtonItem.ItemClick
        CalcGridView.CloseEditor()
        CalcGridView.UpdateCurrentRow()
        If CalcGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim Row As DataRow = CalcGridView.GetFocusedDataRow
        Dim serviceId As Integer = CInt(Row("serviceId"))
        With New ServiceForm(serviceId)
            If .ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            If serviceId = .ServiceId Then Exit Sub
            serviceId = .ServiceId
        End With
        Row("serviceId") = serviceId
        Row("description") = Program.Calc.ServiceTable.FullName(serviceId)
        Row("price") = DBNull.Value
        CalcGridView.RefreshData()
    End Sub

    ' Рассчитать стоимость услуг
    Private Sub CalcBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CalcBarButtonItem.ItemClick
        'Cprp.DxCommon.WaitForm.Show(Me)
        CalcGridView.CloseEditor()
        CalcGridView.UpdateCurrentRow()
        Program.Calc.CalcTable.AcceptChanges()
        'Try
        Program.Calc.ReCalc()
        CalcGridView.RefreshData()
        'Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation("Расчет закончен.")
        'Catch ex As Exception
        '    Cprp.DxCommon.WaitForm.Close()
        '    Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        'End Try
    End Sub

    ' Экспорт расчета в Microsoft Excel
    Private Sub ExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Расчет стоимости услуг"
            Dlg.DefaultExt = "xlsx"
            Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        CalcGridView.CloseEditor()
        CalcGridView.UpdateCurrentRow()
        Try
            CalcGridView.ExportToXlsx(filePath)
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