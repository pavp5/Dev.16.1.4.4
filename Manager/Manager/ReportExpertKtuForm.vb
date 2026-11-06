''' <summary>
''' Отчет по КТУ экспертов за период
''' </summary>
''' <remarks></remarks>
Friend Class ReportExpertKtuForm

    ''' <summary>
    ''' Класс - Таблица со сводным отчетом
    ''' </summary>
    ''' <remarks></remarks>
    Private Class MasterDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New("MasterTable")
            With Me.Columns
                .Add("expertId", GetType(Integer))
                .Add("expertName", GetType(String))
                .Add("workCount", GetType(Integer))
                .Add("ballCalc", GetType(Single))
                .Add("ballFact", GetType(Single))
                .Add("ktuCalc", GetType(Single))
                .Add("ktuFact", GetType(Single))
                .Add("backCount", GetType(Integer))
                .Add("backPercent", GetType(Single))
                .Add("returnCount", GetType(Integer))
                .Add("returnPercent", GetType(Single))
                .Add("totalWork", GetType(Single))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("expertId")}
        End Sub
    End Class

    ''' <summary>
    ''' Клас - Таблица с полным отчетом
    ''' </summary>
    ''' <remarks></remarks>
    Private Class DetailDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New("DetailTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("expertId", GetType(Integer))
                .Add("description", GetType(String))
                .Add("ballCalc", GetType(Single))
                .Add("ballFact", GetType(Single))
                .Add("backCount", GetType(Integer))
                .Add("returnCount", GetType(Integer))
                .Add("totalWork", GetType(Integer))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub
    End Class

    Private MasterTable As MasterDataTable = Nothing        ' Таблица со сводным отчетом
    Private DetailTable As DetailDataTable = Nothing        ' Таблица с полным отчетом

    Private Const APP_NAME As String = "КТУ экспертов"

    Private isMaster As Boolean = True                      ' Экспортировать в Excel сводный отчет


    Friend Sub New()
        InitializeComponent()
        '
        ' Data
        '
        MasterTable = New MasterDataTable()
        DetailTable = New DetailDataTable
        '
        ' DateBeginBarEditItem, DateEndBarEditItem
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddDays(-1 * Date.Today.Day + 1).AddMonths(-1)
        DateEndBarEditItem.EditValue = Date.Today.AddDays(-1 * Date.Today.Day)
        '
        ' MasterGridControl, MasterGridView
        '
        MasterGridControl.DataSource = MasterTable
        MasterGridControl.Dock = DockStyle.Fill
        MasterGridView.SortInfo.Insert(0, ExpertNameMasterGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' DetailGridControl, DetailGridView 
        '
        DetailGridControl.DataSource = DetailTable
        DetailGridControl.Dock = DockStyle.Fill
        DetailGridView.SortInfo.Insert(0, IdDetailGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Me
        '
        Me.Icon = My.Resources.report_ico
        Me.Text = "Отчет - КТУ экспертов за период"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
    End Sub


    Private Sub ReportRunBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportRunBarButtonItem.ItemClick
        If DateBeginBarEditItem.EditValue Is Nothing Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите дату начала отчетного периода.", APP_NAME)
            Exit Sub
        End If
        If DateEndBarEditItem.EditValue Is Nothing Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите дату конца отчетного периода.", APP_NAME)
            Exit Sub
        End If

        Dim Cmd As SqlCommand = Nothing
        Dim workCount As Integer = 0
        Dim ballCalc As Single = 0
        Dim ballFact As Single = 0
        Dim backCount As Integer = 0
        Dim returnCount As Integer = 0
        Dim totalWork As Integer = 0

        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        'Try
        DetailTable.Rows.Clear()
        MasterTable.Rows.Clear()
        Cmd = New SqlCommand With {.Connection = Program.DbClient.Connection}
        '
        ' DetailTable
        '
        Cmd.CommandText = String.Format( _
            "SELECT id, expertId, expertName, description, ballCalc, ballFact, totalWork " & _
            "FROM vWorkData WHERE conditionId <> 8 AND typeId <> 99 AND typeId <> 117 AND closeDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND closeDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
            CDate(DateBeginBarEditItem.EditValue), CDate(DateEndBarEditItem.EditValue).AddDays(1))
        DetailTable.Load(Cmd.ExecuteReader)
        If DetailTable.Rows.Count = 0 Then
            Cprp.DxCommon.WaitForm.Close()
            Exit Sub
        End If
        '
        ' Цикл по DetailTable
        '
        For Each R As DataRow In DetailTable.Rows
            '
            ' Замена пустых значений на 0
            '
            If IsDBNull(R("ballCalc")) Then R("ballCalc") = 0
            If IsDBNull(R("ballFact")) Then R("ballFact") = 0
            If IsDBNull(R("totalWork")) Then R("totalWork") = 0
            '
            ' Количество возвратов и разблокировок по каждой работе
            '
            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tWorkHistory WHERE eventId = 8 AND workId = {0}", CInt(R("id")))
            R("backCount") = Cmd.ExecuteScalar
            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tWorkHistory WHERE eventId = 9 AND workId = {0}", CInt(R("id")))
            R("returnCount") = Cmd.ExecuteScalar
        Next
        '
        ' MasterTable (цикл по DetailTable)
        '
        Using V As New DataView(DetailTable) With {.RowFilter = "expertId > 0"}
            V.Sort = "expertId"
            For i As Integer = 0 To V.Count - 1
                '
                ' Добавление новой строки в MasterTable
                '
                If i > 0 AndAlso CInt(V(i)("expertId")) <> CInt(V(i - 1)("expertId")) Then
                    MasterTable.Rows.Add(New Object() {V(i - 1)("expertId"), V(i - 1)("expertName"), workCount, ballCalc, ballFact, 0, 0, backCount, 0, returnCount, 0, totalWork / 60})
                    workCount = 0
                    ballCalc = 0
                    ballFact = 0
                    backCount = 0
                    returnCount = 0
                    totalWork = 0
                End If
                workCount += 1
                ballCalc += CSng(V(i)("ballCalc"))
                ballFact += CSng(V(i)("ballFact"))
                backCount += CInt(V(i)("backCount"))
                returnCount += CInt(V(i)("returnCount"))
                totalWork += CInt(V(i)("totalWork"))
            Next
            '
            ' Добавление последней строки в MasterTable
            '
            MasterTable.Rows.Add(New Object() {V(V.Count - 1)("expertId"), V(V.Count - 1)("expertName"), workCount, ballCalc, ballFact, 0, 0, backCount, 0, returnCount, 0, totalWork / 60})
        End Using
        '
        ' Суммарные расчетные и фактические баллы
        '
        Dim sumCalc As Single = 0
        Dim sumFact As Single = 0
        For Each R As DataRow In MasterTable.Rows
            sumCalc += CSng(R("ballCalc"))
            sumFact += CSng(R("ballFact"))
        Next
        '
        ' КТУ каждого эксперта
        '
        For Each R As DataRow In MasterTable.Rows
            If sumCalc > 0 Then R("ktuCalc") = 100 * CSng(R("ballCalc")) / sumCalc
            If sumFact > 0 Then R("ktuFact") = 100 * CSng(R("ballFact")) / sumFact
        Next
        '
        ' Процент возвратов и разблокировок каждого эксперта от количества его работ
        '
        For Each R As DataRow In MasterTable.Rows
            If CInt(R("workCount")) > 0 Then
                R("backPercent") = 100 * CSng(R("backCount")) / CSng(R("workCount"))
                R("returnPercent") = 100 * CSng(R("returnCount")) / CSng(R("workCount"))
            End If
        Next

        Cprp.DxCommon.WaitForm.Close()
        'Catch ex As Exception
        '    Cprp.DxCommon.WaitForm.Close()
        '    Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        'Finally
        If Not Cmd Is Nothing Then Cmd.Dispose()
        'End Try
    End Sub

    Private Sub ExportExcelBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportExcelBarButtonItem.ItemClick
        Try
            Dim filePath As String = Nothing
            Using Dlg As New SaveFileDialog
                Dlg.Title = "Выбор файла для сохранения данных"
                Dlg.FileName = If(isMaster, MasterGridView.ViewCaption, DetailGridView.ViewCaption)
                Dlg.DefaultExt = "xlsx"
                Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
                If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                filePath = Dlg.FileName
            End Using
            If isMaster Then
                MasterGridView.ExportToXlsx(filePath)
            Else
                DetailGridView.ExportToXlsx(filePath)
            End If
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

    Private Sub MasterGridView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles MasterGridView.FocusedRowChanged
        Dim expertId As Integer = 0
        If MasterGridView.FocusedRowHandle >= 0 Then
            expertId = CInt(MasterGridView.GetFocusedDataRow("expertId"))
            DetailGridView.ViewCaption = String.Format("Перечнь работ ({0})", MasterGridView.GetFocusedDataRow("expertName").ToString)
        Else
            DetailGridView.ViewCaption = "Перечнь работ (0)"
        End If
        DetailTable.DefaultView.RowFilter = String.Format("expertId = {0}", expertId)
    End Sub

    Private Sub MasterGridView_GotFocus(sender As Object, e As EventArgs) Handles MasterGridView.GotFocus
        isMaster = True
    End Sub

    Private Sub DetailGridView_GotFocus(sender As Object, e As EventArgs) Handles DetailGridView.GotFocus
        isMaster = False
    End Sub

End Class