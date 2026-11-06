Imports Cprp.DxData.Common
''' <summary>
''' Отчет со сравнительными стоимостями работ по товарам и объектам экспертизы
''' </summary>
Public Class ReportUserControl

    ''' <summary>
    ''' Таблица отчета
    ''' </summary>
    Private ReportTable As DataTable = Nothing

    ''' <summary>
    ''' Представление отчета
    ''' </summary>
    Private ReportView As DataView = Nothing

    ''' <summary>
    ''' Объект Connection для выполнения запросов
    ''' </summary>
    ''' <remarks></remarks>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Базовая стоимость услуги
    ''' </summary>
    Private sPrice As Single = 14000


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
        ' ReportTable, ReportView
        '
        ReportTable = New DataTable("ReportTable")
        With ReportTable.Columns
            .Add("id", GetType(Integer))
            .Add("orderNum", GetType(String))
            .Add("orderDate", GetType(Date))
            .Add("clientCaption", GetType(String))
            .Add("objectCount", GetType(Integer))
            .Add("goodCount", GetType(Integer))
            .Add("objectPrice", GetType(Single))
            .Add("goodPrice", GetType(Single))
            .Add("priceDif", GetType(Single))
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id")}
        ReportView = New DataView(ReportTable)
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportView
        ReportGridView.SortInfo.Insert(0, OrderNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' DateBeginBarEditItem, DateEndBarEditItem
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddMonths(-1)
        DateEndBarEditItem.EditValue = Date.Today

        AllRowBarCheckItem.Checked = True

    End Sub


    Private Sub ReportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportBarButtonItem.ItemClick
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ReportGridView.BeginDataUpdate()
        '
        ' Загрузка данных из vWorkData
        '
        ReportTable.Rows.Clear()
        Using Cmd As SqlCommand = Me.Connection.CreateCommand
            Cmd.CommandText = _
                "SELECT id, orderNum, orderDate, clientCaption, goodCount AS objectCount, goodAllCount AS goodCount " & _
                "FROM vWorkData WHERE typeId = 1 AND goodCount > 0 AND goodAllCount > 0"
            If Not IsNothing(DateBeginBarEditItem.EditValue) Then
                Cmd.CommandText = String.Format(" {0} AND orderDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                                                Cmd.CommandText, CDate(DateBeginBarEditItem.EditValue))
            End If
            If Not IsNothing(DateEndBarEditItem.EditValue) Then
                Cmd.CommandText = String.Format(" {0} AND orderDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                                                Cmd.CommandText, CDate(DateEndBarEditItem.EditValue).AddDays(1))
            End If
            If IsText(ClientOrderBarEditItem.EditValue) Then
                Cmd.CommandText = String.Format(" {0} AND (orderNum LIKE '{1}%' OR clientCaption LIKE '%{1}%')", _
                                                Cmd.CommandText, ToText(ClientOrderBarEditItem.EditValue))
            End If
            ReportTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' Расчеты стоимостей работ
        '
        For Each Row As DataRow In ReportTable.Rows
            Row("objectPrice") = GetPrice(CInt(Row("objectCount")))
            Row("goodPrice") = GetPrice(CInt(Row("goodCount")))
            Row("priceDif") = CSng(Row("goodPrice")) - CSng(Row("objectPrice"))
        Next

        ReportGridView.EndDataUpdate()
        ReportGridView.MoveFirst()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ''' <summary>
    ''' Расчет стоимости работы
    ''' </summary>
    ''' <param name="objCount">Количество объектов</param>
    Private Function GetPrice(objCount As Integer) As Single
        Dim price As Single = sPrice
        For i As Integer = 1 To objCount
            price += If(i > 10, 850, 900)
        Next
        Return price
    End Function

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
            Dlg.FileName = "Сравнительные стоимости работ"
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


    Private Const AGREEMENT_NUM_ROW_FILTER As String = _
        "orderNum LIKE '01/17/73%' OR " & _
        "orderNum LIKE '01/18/77%' OR " & _
        "orderNum LIKE '01/17/273%' OR " & _
        "orderNum LIKE '01/18/93%' OR " & _
        "orderNum LIKE '05/1134%' OR " & _
        "orderNum LIKE '02/17/37%' OR " & _
        "orderNum LIKE '02/18/2834%' OR " & _
        "orderNum LIKE '01/19/68%' OR " & _
        "orderNum LIKE '02/18/1300%' OR " & _
        "orderNum LIKE '02/19/1936%' OR " & _
        "orderNum LIKE '01/19/225%' OR " & _
        "orderNum LIKE '01/22/128%' OR " & _
        "orderNum LIKE '01/15/65%' OR " & _
        "orderNum LIKE '01/18/164%' OR " & _
        "orderNum LIKE '01/19/135%' OR " & _
        "orderNum LIKE '02/19/1768%' OR " & _
        "orderNum LIKE '01/20/9%' OR " & _
        "orderNum LIKE '02/15/838%' OR " & _
        "orderNum LIKE '01/20/309%' OR " & _
        "orderNum LIKE '01/21/222%' OR " & _
        "orderNum LIKE '04/21/1475%' OR " & _
        "orderNum LIKE '02/15/9%' OR " & _
        "orderNum LIKE '02/15/523%' OR " & _
        "orderNum LIKE '01/22/89%' OR " & _
        "orderNum LIKE '04/22/1715%' OR " & _
        "orderNum LIKE '01/23/70%' OR " & _
        "orderNum LIKE '01/22/721%' OR " & _
        "orderNum LIKE '04/23/1047%' OR " & _
        "orderNum LIKE '04/23/2627%' OR " & _
        "orderNum LIKE '01/23/505%' OR " & _
        "orderNum LIKE '01/23/542%'"

    Private Sub AllRowBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AllRowBarCheckItem.CheckedChanged
        With ReportGridView
            .BeginDataUpdate()
            ReportView.RowFilter = "id > 0"
            .EndDataUpdate()
            .MoveFirst()
        End With
    End Sub

    Private Sub NotAgreeBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NotAgreeBarCheckItem.CheckedChanged
        With ReportGridView
            .BeginDataUpdate()
            ReportView.RowFilter = String.Format("NOT ({0})", AGREEMENT_NUM_ROW_FILTER)
            .EndDataUpdate()
            .MoveFirst()
        End With
    End Sub

    Private Sub WithAgreeBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WithAgreeBarCheckItem.CheckedChanged
        With ReportGridView
            .BeginDataUpdate()
            ReportView.RowFilter = AGREEMENT_NUM_ROW_FILTER
            .EndDataUpdate()
            .MoveFirst()
        End With
    End Sub


End Class
