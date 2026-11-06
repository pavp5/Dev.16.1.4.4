''' <summary>
''' Отчет по незакрытым работам
''' </summary>
Friend Class WorkAcceptUserControl

    ''' <summary>
    ''' Таблица отчета
    ''' </summary>
    Private ReportTable As DataTable = Nothing

    ''' <summary>
    ''' Объект Connection для выполнения запросов
    ''' </summary>
    ''' <remarks></remarks>
    Private Connection As SqlConnection = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных EXDB8</param>
    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        Me.Connection = Connection
        '
        ' ReportTable
        '
        ReportTable = New DataTable("ReportTable")
        With ReportTable.Columns
            .Add("id", GetType(Integer))
            .Add("acceptDate", GetType(Date))
            .Add("orderNum", GetType(String))
            .Add("orderDate", GetType(Date))
            .Add("orderUrl", GetType(String))
            .Add("clientName", GetType(String))
            .Add("managerName", GetType(String))
            .Add("price", GetType(Single))
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id")}
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportTable
        ReportGridView.SortInfo.Insert(0, AcceptDateGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

        DataReloadSimpleButton.PerformClick()

    End Sub


    ' Перечитать данные из базы
    Private Sub DataReloadSimpleButton_Click(sender As Object, e As EventArgs) Handles DataReloadSimpleButton.Click
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ReportGridView.BeginDataUpdate()
        ReportTable.Rows.Clear()
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = "SELECT id, acceptDate, orderNum, orderDate, orderUrl, clientName, managerName, price FROM vWorkData WHERE conditionId = 6"
            ReportTable.Load(Cmd.ExecuteReader)
        End Using
        ReportGridView.EndDataUpdate()
        ReportGridView.MoveFirst()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ' Открыть карточку заказа
    Private Sub OrderSimpleButton_Click(sender As Object, e As EventArgs) Handles OrderSimpleButton.Click
        If ReportGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = ReportGridView.GetFocusedDataRow("orderUrl").ToString
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Отсутствует ссылка на карточку заказа.", String.Format("Работа № {0}", ReportGridView.GetFocusedDataRow("id")))
            Exit Sub
        End If
        Try
            Using P As New Process
                P.StartInfo.FileName = sTmp
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Показать историю работы
    Private Sub HistorySimpleButton_Click(sender As Object, e As EventArgs) Handles HistorySimpleButton.Click
        If ReportGridView.FocusedRowHandle < 0 Then Exit Sub
        With New WorkHistoryForm(Connection, ReportGridView.GetFocusedDataRow("id"))
            .ShowDialog()
        End With
    End Sub

    ' Экспорт списка в Microsoft Excel
    Private Sub ExportSimpleButton_Click(sender As Object, e As EventArgs) Handles ExportSimpleButton.Click
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Отчет по не закрытым работам"
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

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        FindButtonEdit.Text = Nothing
    End Sub

    Private Sub FindButtonEdit_TextChanged(sender As Object, e As EventArgs) Handles FindButtonEdit.TextChanged
        ReportGridView.FindFilterText = FindButtonEdit.Text
    End Sub

End Class
