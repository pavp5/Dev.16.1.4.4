Imports Cprp.DxData.Common
''' <summary>
''' Отчет по стоимостям выполненных работ за период
''' </summary>
Public Class ReportUserControl1

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
            .Add("typeName", GetType(String))
            .Add("orderNum", GetType(String))
            .Add("orderDate", GetType(Date))
            .Add("clientCaption", GetType(String))
            .Add("isPayment", GetType(Boolean))
            .Add("isPrice", GetType(Boolean))
            .Add("price", GetType(Single))
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id")}
        ReportView = New DataView(ReportTable)
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportView
        ReportGridView.SortInfo.Insert(0, OrderNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        TypeNameGridColumn.Group()
        '
        ' DateBeginBarEditItem, DateEndBarEditItem
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddMonths(-1)
        DateEndBarEditItem.EditValue = Date.Today
        '
        ' ExcontBarCheckItem, CprpBarCheckItem, NotPaymentBarCheckItem 
        '
        ExcontBarCheckItem.Checked = True
        CprpBarCheckItem.Checked = True
        NotPaymentBarCheckItem.Checked = True

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
                "SELECT id, typeName, orderNum, orderDate, clientCaption, isPayment, isPrice, price " & _
                "FROM vWorkData WHERE (typeId <> 99 AND typeId <> 117) AND conditionId IN(6, 7, 10)"
            If Not IsNothing(DateBeginBarEditItem.EditValue) Then
                Cmd.CommandText = String.Format(" {0} AND acceptDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                                                Cmd.CommandText, CDate(DateBeginBarEditItem.EditValue))
            End If
            If Not IsNothing(DateEndBarEditItem.EditValue) Then
                Cmd.CommandText = String.Format(" {0} AND acceptDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                                                Cmd.CommandText, CDate(DateEndBarEditItem.EditValue).AddDays(1))
            End If
            ReportTable.Load(Cmd.ExecuteReader)
        End Using

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
            Dlg.FileName = "Стоимость работ"
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

    ' Сформировать фильтр представления отчета
    Private Sub FilterViewCreate()
        Dim filter As String = "id > 0"
        If Not ExcontBarCheckItem.Checked Then filter = String.Format("{0} AND NOT (orderNum LIKE '02%' OR orderNum LIKE '03%' OR orderNum LIKE '04%')", filter)
        If Not CprpBarCheckItem.Checked Then filter = String.Format("{0} AND NOT (orderNum LIKE '01%' OR orderNum LIKE '05/1134%' OR orderNum LIKE '07/645%')", filter)
        If Not NotPaymentBarCheckItem.Checked Then filter = String.Format("{0} AND isPayment = True", filter)        
        ReportGridView.BeginDataUpdate()
        ReportView.RowFilter = filter
        ReportGridView.EndDataUpdate()
        ReportGridView.MoveFirst()
    End Sub

    Private Sub ExcontBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExcontBarCheckItem.CheckedChanged
        FilterViewCreate()
    End Sub

    Private Sub CprpBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CprpBarCheckItem.CheckedChanged
        FilterViewCreate()
    End Sub

    Private Sub NotPaymentBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NotPaymentBarCheckItem.CheckedChanged
        FilterViewCreate()
    End Sub

End Class
