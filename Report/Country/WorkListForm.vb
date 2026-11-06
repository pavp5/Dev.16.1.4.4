Imports Cprp.DxData.Common
''' <summary>
''' Список работ по стране
''' </summary>
Friend Class WorkListForm

    Private _countryId As Integer = 0
    ''' <summary>
    ''' ID страны
    ''' </summary>
    Public ReadOnly Property CountryId As Integer
        Get
            Return _countryId
        End Get
    End Property

    ''' <summary>
    ''' Представление работ по стране
    ''' </summary>
    Private WorkView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="WorkTable">Таблица работ</param>
    ''' <param name="countryId">ID страны</param>
    Friend Sub New(ByRef WorkTable As DataTable, ByVal countryId As Integer)
        InitializeComponent()
        _countryId = countryId
        WorkView = New DataView(WorkTable) With {.RowFilter = String.Format("countryId = {0}", _countryId)}
        ReportGridControl.DataSource = WorkView
        ReportGridView.SortInfo.Insert(0, OrderDateGridColumn, DevExpress.Data.ColumnSortOrder.Descending)
        ReportGridView.MoveFirst()
        Me.Icon = My.Resources.list_internet_ico
        Me.Width = 0.7 * Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height - 2
        Me.Left = Screen.GetWorkingArea(Me).Width - Me.Width - 1
        Me.Top = 1
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

    Private Sub OrderBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OrderBarButtonItem.ItemClick
        If ReportGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim url As String = ToText(ReportGridView.GetFocusedDataRow("orderUrl"))
        Try
            Using P As New Process
                P.StartInfo.FileName = url
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    Private Sub ExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = Me.Text
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
        OrderBarButtonItem.PerformClick()
    End Sub

End Class