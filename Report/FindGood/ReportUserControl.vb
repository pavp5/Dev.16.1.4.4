Imports Cprp.DxData.Common
''' <summary>
''' Поиск товаров в базе ЭС
''' </summary>
Public Class ReportUserControl

    ''' <summary>
    ''' Таблица товаров
    ''' </summary>
    Private GoodTable As DataTable = Nothing

    ''' <summary>
    ''' Объект Connection для выполнения запросов
    ''' </summary>
    ''' <remarks></remarks>
    Private Connection As SqlConnection = Nothing

    ' Текст для поиска
    Private findText As String = Nothing


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
        ' GoodTable
        '
        GoodTable = New DataTable("GoodTable")
        With GoodTable
            .Columns.Add("id", GetType(Integer))
            .Columns.Add("nameCon", GetType(String))
            '.Columns.Add("nameDec", GetType(String))
            .Columns.Add("tnved", GetType(String))
            '.Columns.Add("cas", GetType(String))
            '.Columns.Add("area", GetType(String))
            '.Columns.Add("used", GetType(String))
            .Columns.Add("description", GetType(String))
            .PrimaryKey = New DataColumn() {.Columns("id")}
        End With
        '
        ' ReportGridControl, ReportGridView
        '
        GoodGridControl.DataSource = GoodTable
        GoodGridView.SortInfo.Insert(0, NameConGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

    End Sub

    ' Поиск товаров
    Private Sub FindGood()
        findText = ToText(findText)
        GoodGridView.FindFilterText = findText
        If String.IsNullOrWhiteSpace(findText) Then Exit Sub

        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        GoodGridView.CloseEditor()
        GoodGridView.BeginDataUpdate()

        Dim arrWord() As String = findText.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
        Dim strName As String = Nothing
        Dim strTnved As String = Nothing
        Dim strDescription As String = Nothing
        For Each word As String In arrWord
            strName = String.Format("{0} AND nameCon LIKE '%{1}%'", strName, word)
            strTnved = String.Format("{0} OR tnved LIKE '{1}%'", strTnved, word)
            strDescription = String.Format("{0} AND description LIKE '%{1}%'", strDescription, word)
        Next
        Try
            Using Cmd As SqlCommand = Connection.CreateCommand
                Cmd.CommandText = String.Format( _
                    "SELECT id, nameCon, tnved, description FROM tGood WHERE ({0}) OR ({1}) OR ({2})", _
                    strName.Substring(4), strTnved.Substring(4), strDescription.Substring(4))
                GoodTable.Rows.Clear()
                GoodTable.Load(Cmd.ExecuteReader)
            End Using
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            GoodGridView.EndDataUpdate()
            GoodGridView.MoveFirst()
        End Try
    End Sub

    Private Sub FindRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindRepositoryItemButtonEdit.ButtonClick
        If e.Button.Index = 0 Then
            FindRepositoryItemButtonEdit.BeginUpdate()
            FindBarEditItem.EditValue = Nothing
            FindRepositoryItemButtonEdit.EndUpdate()
            GoodGridView.FindFilterText = Nothing
        Else
            FindGood()
        End If
    End Sub



    Private Sub FindRepositoryItemButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemButtonEdit.EditValueChanging
        'If e.NewValue Is Nothing Then
        '    GoodGridView.FindFilterText = Nothing
        'Else
        '    GoodGridView.FindFilterText = e.NewValue.ToString
        'End If
        findText = e.NewValue
    End Sub

    Private Sub ExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Результаты поиска"
            Dlg.DefaultExt = "xlsx"
            Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        Try
            GoodGridView.ExportToXlsx(filePath)
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

    Private Sub FindRepositoryItemButtonEdit_KeyDown(sender As Object, e As KeyEventArgs) Handles FindRepositoryItemButtonEdit.KeyDown
        If e.KeyCode = Keys.Enter Then FindGood()
    End Sub


End Class
