Imports Cprp.DxData.Common
''' <summary>
''' Отчет со сравнительными стоимостями работ по товарам и объектам экспертизы
''' </summary>
Public Class ReportUserControl

    ''' <summary>
    ''' ИСточник данных отчета
    ''' </summary>
    Private DS As ReportDataSet = Nothing

    ''' <summary>
    ''' Представление таблицы заказчиков
    ''' </summary>
    Private ClientView As DataView = Nothing

    ''' <summary>
    ''' Объект Connection для выполнения запросов
    ''' </summary>
    ''' <remarks></remarks>
    Private Connection As SqlConnection = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных EXDB8</param>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        Me.Connection = Connection
        '
        ' DS
        '
        DS = New ReportDataSet
        '
        ' ClientView
        '
        ClientView = New DataView(DS.ClientTable)
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ClientView        
        ReportGridView.SortInfo.Insert(0, NameLongGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' DateBeginBarEditItem, DateEndBarEditItem
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddMonths(-1)
        DateEndBarEditItem.EditValue = Date.Today

    End Sub


    Private Sub ReportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportBarButtonItem.ItemClick
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ReportGridView.BeginDataUpdate()
        DS.DataReload(Connection, CDate(DateBeginBarEditItem.EditValue), CDate(DateEndBarEditItem.EditValue))
        ReportGridView.EndDataUpdate()
        ReportGridView.MoveFirst()
        Cprp.DxCommon.WaitForm.Close()
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

    Private Sub ExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Отчет по заказчикам за период"
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

    Private Sub IsNewBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles IsNewBarCheckItem.CheckedChanged
        ReportGridView.BeginDataUpdate()
        ClientView.RowFilter = If(IsNewBarCheckItem.Checked, "isNew = True", "id > 0")
        ReportGridView.EndDataUpdate()
    End Sub

End Class
