''' <summary>
''' Отчет по экспертным огранизациям
''' </summary>
Friend Class ReportOrgUserControl

    ''' <summary>
    ''' Открытое подключение к базе данных
    ''' </summary>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Объект Command для выполнения запросов
    ''' </summary>
    ''' <remarks></remarks>
    Private Command As SqlCommand = Nothing

    ''' <summary>
    ''' Таблица сводного отчета
    ''' </summary>
    Private ReportTable As DataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных</param>
    ''' <remarks></remarks>
    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection, Command
        '
        Me.Connection = Connection
        If Connection Is Nothing OrElse Me.Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        Command = New SqlCommand With {.Connection = Me.Connection}
        '
        ' DateBBarEditItem, DateEBarEditItem 
        '
        DateStartBarEditItem.EditValue = Date.Today
        DateEndBarEditItem.EditValue = Date.Today
        Command.CommandText = "SELECT COUNT(*) FROM tDoc"
        If CInt(Command.ExecuteScalar) > 0 Then
            Command.CommandText = "SELECT MIN(docDate) FROM tDoc"
            DateStartBarEditItem.EditValue = CDate(Command.ExecuteScalar)
            Command.CommandText = "SELECT MAX(docDate) FROM tDoc"
            DateEndBarEditItem.EditValue = CDate(Command.ExecuteScalar)
        End If
        '
        ' ReportTable
        '
        ReportTable = New DataTable
        With ReportTable.Columns
            .Add("orgId", GetType(Integer))
            .Add("nameShort", GetType(String))
            .Add("nameAll", GetType(String))
            .Add("docCount", GetType(Integer))
            .Add("percentCount", GetType(Single))
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("orgId")}
        Command.CommandText = "SELECT id AS orgId, nameShort,  nameLong + ', ' + address AS nameAddress FROM tOrg"
        ReportTable.Load(Command.ExecuteReader)
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportTable
        ReportGridView.SortInfo.Insert(0, NameShortGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.MoveFirst()

    End Sub


    Private Sub ReportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportBarButtonItem.ItemClick
        Dim iTmp As Integer = 0
        Dim iTmp1 As Integer = 0
        Dim dateB As Date = CDate(DateStartBarEditItem.EditValue)
        Dim dateE As Date = CDate(DateEndBarEditItem.EditValue)
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        '
        ' Количество по каждой организации
        '
        For Each Row As DataRow In ReportTable.Rows
            Command.CommandText = String.Format("SELECT COUNT(*) FROM tDoc WHERE orgId = {0} AND docDate >={{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND docDate <={{ts '{2:yyyy-MM-dd HH:mm:ss}'}}", CInt(Row("orgId")), dateB, dateE)
            iTmp1 = CInt(Command.ExecuteScalar)
            Row("docCount") = iTmp1
            iTmp += iTmp1
        Next
        '
        ' Процент по каждой организации
        '
        For Each Row As DataRow In ReportTable.Rows
            If iTmp = 0 Then
                Row("percentCount") = 0
            Else
                Row("percentCount") = CInt(Row("docCount")) * 100 / iTmp
            End If
        Next
        Cprp.DxCommon.WaitForm.Close()
    End Sub


    Private Sub ExportExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportExcelBarButtonItem.ItemClick
        Try
            Dim filePath As String = Nothing
            Using Dlg As New SaveFileDialog
                Dlg.Title = "Выбор файла для сохранения данных"
                Dlg.FileName = "Отчет по экспертным организациям"
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
