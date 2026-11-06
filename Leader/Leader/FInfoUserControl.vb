''' <summary>
''' Элемент управления "Контролируемые заключения"
''' </summary>
Friend Class FInfoUserControl

    ''' <summary>
    ''' Таблица заключений
    ''' </summary>
    Friend DocTable As DataTable = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' DocTable
        '
        DocTable = New DataTable
        With DocTable.Columns
            .Add("id", GetType(Integer))
            .Add("docNum", GetType(String))
            .Add("docDate", GetType(Date))
            .Add("docNumDate", GetType(String))
            .Add("orgNameLong", GetType(String))
            .Add("conNumDate", GetType(String))
            .Add("rusCaptionInn", GetType(String))
            .Add("nusCaption", GetType(String))
            .Add("endCaption", GetType(String))
            .Add("goodName", GetType(String))
            .Add("goodTnved", GetType(String))
            .Add("goodListPos", GetType(String))
            .Add("summary", GetType(String))
        End With
        DocTable.PrimaryKey = New DataColumn() {DocTable.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = "SELECT * FROM vFInfo"
            DocTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' ListGridControl, ListGridView
        '
        ListGridControl.DataSource = DocTable
        ListGridView.SortInfo.Insert(0, DocNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
    End Sub

    Private Sub ListGridView_MouseDown(sender As Object, e As MouseEventArgs) Handles ListGridView.MouseDown
        If e.Button <> Windows.Forms.MouseButtons.Right Then Exit Sub
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Отчет"
            Dlg.DefaultExt = "xlsx"
            Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        Try
            ListGridView.ExportToXlsx(filePath)
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
End Class
