''' <summary>
''' Отчет по экспертным огранизациям
''' </summary>
Friend Class ReportCountryUserControl

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
            .Add("country", GetType(String))
            .Add("docCount", GetType(Integer))
            .Add("percentCount", GetType(Single))
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("orgId")}
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportTable
        ReportGridView.SortInfo.Insert(0, CountryGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.MoveFirst()

    End Sub


    Private Sub ReportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportBarButtonItem.ItemClick
        Dim iTmp As Integer = 0
        Dim iTmp1 As Integer = 0
        Dim dateB As Date = CDate(DateStartBarEditItem.EditValue)
        Dim dateE As Date = CDate(DateEndBarEditItem.EditValue)
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        '
        ' Отчет
        '
        Command.CommandText = String.Format("SELECT DISTINCT country, COUNT(*) AS docCount FROM vDoc WHERE docDate >={{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND docDate <={{ts '{1:yyyy-MM-dd HH:mm:ss}'}} GROUP BY country", dateB, dateE)
        ReportTable.Load(Command.ExecuteReader)
        '
        ' Общее количество
        '
        For Each Row As DataRow In ReportTable.Rows
            iTmp1 += CInt(Row("docCount"))
        Next
        '
        ' Процент по каждой стране
        '
        For Each Row As DataRow In ReportTable.Rows
            iTmp = CInt(Row("docCount"))
            If iTmp = 0 Then
                Row("percentCount") = 0
            Else
                Row("percentCount") = iTmp * 100 / iTmp1
            End If
        Next
        Cprp.DxCommon.WaitForm.Close()
    End Sub


    Private Sub ExportExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportExcelBarButtonItem.ItemClick
        Try
            Dim filePath As String = Nothing
            Using Dlg As New SaveFileDialog
                Dlg.Title = "Выбор файла для сохранения данных"
                Dlg.FileName = "Отчет по странам"
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
