Imports C2 = Cprp.DxData.Common
''' <summary>
''' Отчет по превышениями сроков исполнения отдельных операций при выполнении работ
''' </summary>
Friend Class ReportWorkTermForm

    Private Class ReportDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New("ReportTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("eventName", GetType(String))
                .Add("userName", GetType(String))
                .Add("workId", GetType(Integer))
                .Add("planeDate", GetType(Date))
                .Add("eventDate", GetType(Date))
                .Add("dif", GetType(Integer))
                .Add("clientName", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub
    End Class


    Private ReportTable As ReportDataTable = Nothing

    Private Const APP_NAME As String = "Сроки исполнения"


    Friend Sub New()
        InitializeComponent()
        '
        ' Data
        '
        ReportTable = New ReportDataTable()
        '
        ' DateBeginBarEditItem, DateEndBarEditItem
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddDays(-1 * Date.Today.Day + 1)
        DateEndBarEditItem.EditValue = Date.Today
        '
        ' ReportGridControl, ReportGridView 
        '
        ReportGridControl.DataSource = ReportTable
        ReportGridView.SortInfo.Insert(0, WorkIdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Me
        '
        Me.Icon = My.Resources.report_ico
        Me.Text = "Отчет - Превышение сроков исполнения операций"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
    End Sub


    Private Sub ReportRunBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportRunBarButtonItem.ItemClick
        If DateBeginBarEditItem.EditValue Is Nothing Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите дату начала отчетного периода.", APP_NAME)
            Exit Sub
        End If
        If DateEndBarEditItem.EditValue Is Nothing Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите дату конца отчетного периода.", APP_NAME)
            Exit Sub
        End If
        Cprp.DxCommon.WaitForm.Show(Me)
        Try
            ReportGridView.BeginDataUpdate()
            ReportTable.Rows.Clear()
            Using Cmd As SqlCommand = Program.DbClient.Connection.CreateCommand
                Cmd.CommandText = String.Format( _
                "SELECT id, userName, eventName, workId, planeDate, eventDate, clientName FROM vWorkHistory " & _
                "WHERE eventDate > planeDate AND eventDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND eventDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                CDate(DateBeginBarEditItem.EditValue), CDate(DateEndBarEditItem.EditValue).AddDays(1))
                ReportTable.Load(Cmd.ExecuteReader)
            End Using
            If ReportTable.Rows.Count = 0 Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowInformation("За указанный период данные по превышениям сроков отсутствуют.", APP_NAME)
            Else
                For Each Row As DataRow In ReportTable.Rows
                    Row("dif") = Cprp.DxData.Work.Common.GetPlaneDateInterval(CDate(Row("planeDate")), CDate(Row("eventDate")))
                Next
                Cprp.DxCommon.WaitForm.Close()
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        Finally
            ReportGridView.EndDataUpdate()
            ReportGridView.ExpandAllGroups()
            ReportGridView.MoveFirst()
        End Try
    End Sub

    Private Sub ExportExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportExcelBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Отчет по превышениям сроков"
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
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

End Class