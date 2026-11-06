Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Отчет по организациям, странам и товарам"
''' </summary>
Friend Class ReportSummaryUserControl

    ''' <summary>
    ''' Открытое соединение с базой данных
    ''' </summary>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Таблица отчета
    ''' </summary>
    Private ReportTable As DataTable = Nothing


    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        Me.Connection = Connection
        If Me.Connection Is Nothing OrElse Me.Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        '
        ' ReportTable
        '
        ReportTable = New DataTable("ReportTable")
        With ReportTable.Columns
            .Add("id", GetType(Integer))
            .Add("orgNameShort", GetType(String))
            .Add("docCountry", GetType(String))
            .Add("goodTnved", GetType(String))
            .Add("rowCount", GetType(Integer))
            .Add("percentCount", GetType(Single))
        End With
        With ReportTable.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id")}
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportTable
        ReportGridView.SortInfo.Insert(0, OrgGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' DateStartBarEditItem, DateEndBarEditItem
        '
        DateStartBarEditItem.EditValue = Date.Today
        DateEndBarEditItem.EditValue = Date.Today
        Using Cmd As SqlCommand = Me.Connection.CreateCommand
            Cmd.CommandText = "SELECT COUNT(*) FROM tDoc"
            If CInt(Cmd.ExecuteScalar) > 0 Then
                Cmd.CommandText = "SELECT MIN(docDate) FROM tDoc"
                DateStartBarEditItem.EditValue = CDate(Cmd.ExecuteScalar)
                Cmd.CommandText = "SELECT MAX(docDate) FROM tDoc"
                DateEndBarEditItem.EditValue = CDate(Cmd.ExecuteScalar)
            End If
        End Using

    End Sub

    ' Создать отчет
    Private Sub ReportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportBarButtonItem.ItemClick
        Dim iTmp As Integer = 0
        Dim dateB As Date = CDate(DateStartBarEditItem.EditValue)
        Dim dateE As Date = CDate(DateEndBarEditItem.EditValue)
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ReportTable.Rows.Clear()
        ReportGridView.BeginDataUpdate()
        Try
            '
            ' Отчет
            '
            Using Cmd As SqlCommand = Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT DISTINCT orgNameShort, docCountry, goodTnved, COUNT(*) AS [rowCount] FROM vGoodDocOrg WHERE docDate >={{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND docDate <={{ts '{1:yyyy-MM-dd HH:mm:ss}'}} GROUP BY orgNameShort, docCountry, goodTnved", dateB, dateE)
                ReportTable.Load(Cmd.ExecuteReader)
            End Using
            '
            ' Общее количество
            '
            For Each Row As DataRow In ReportTable.Rows
                iTmp += CInt(Row("rowCount"))
            Next
            '
            ' Процент по каждой записи
            '
            For Each Row As DataRow In ReportTable.Rows
                Row("percentCount") = CInt(Row("rowCount")) * 100 / iTmp
            Next
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            ReportGridView.EndDataUpdate()
        End Try
    End Sub

    ' Выровнять высоту строк по содержимому
    Private Sub AutoHightBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AutoHightBarCheckItem.CheckedChanged
        ReportGridView.OptionsView.RowAutoHeight = AutoHightBarCheckItem.Checked
    End Sub

    ' Очистить поле автофильтра
    Private Sub FindRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindRepositoryItemButtonEdit.ButtonClick
        ReportGridView.Focus()
        FindTextBarEditItem.EditValue = Nothing
    End Sub

    ' Применить автофильтр к таблице отчета
    Private Sub FindRepositoryItemButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemButtonEdit.EditValueChanging
        Dim sTmp As String = C2.ToText(e.NewValue)
        ReportGridView.FindFilterText = sTmp
    End Sub

    ' Экспорт отчета в MS Excel
    Private Sub ExportExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportExcelBarButtonItem.ItemClick
        Try
            Dim filePath As String = Nothing
            Using Dlg As New SaveFileDialog
                Dlg.Title = "Выбор файла для сохранения данных"
                Dlg.FileName = "Сводный отчет"
                Dlg.DefaultExt = "xlsx"
                Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
                If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                filePath = Dlg.FileName
            End Using
            ReportGridView.ExportToXlsx(filePath)
            Using P As New Process
                P.StartInfo.FileName = filePath
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

End Class
