''' <summary>
''' Ресурсы системы
''' </summary>
''' <remarks></remarks>
Public Class ResourceUserControl

    ' Таблица ресурсов
    Private ResourceTable As DataTable = Nothing

    Private Const APP_NAME As String = "Ресурсы системы"

    Friend Sub New()
        InitializeComponent()
        '
        ' ResourceTable 
        '
        ResourceTable = New DataTable
        With ResourceTable.Columns
            .Add("name", GetType(String))
            .Add("strData", GetType(String))
            .Add("binData", GetType(Byte()))
            .Add("comment", GetType(String))
        End With
        With ResourceTable
            .Columns("name").AllowDBNull = False
            .Columns("name").MaxLength = 50
            .Columns("strData").MaxLength = 500
            .Columns("comment").MaxLength = 500
        End With
        ResourceTable.PrimaryKey = New DataColumn() {ResourceTable.Columns("name")}
        '
        ' ResourceGridControl, ResourceGridView 
        '
        ResourceGridControl.DataSource = ResourceTable
        ResourceGridView.SortInfo.Insert(0, NameGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

        DataReloadBaseBarButtonItem.PerformClick()

    End Sub

    Private Sub ImageRepositoryItemButtonEdit_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles ImageRepositoryItemButtonEdit.ButtonClick
        If ResourceGridView.FocusedRowHandle < 0 Then Exit Sub
        Select Case e.Button.Index
            Case 0
                ' Загрузить из файла
                Using dlg As New OpenFileDialog
                    dlg.Title = "Выбор файла для загрузки"
                    dlg.Multiselect = False
                    dlg.Filter = "Все файлы (*.*)|*.*"
                    If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                    ResourceGridView.SetFocusedRowCellValue("binData", My.Computer.FileSystem.ReadAllBytes(dlg.FileName))
                End Using
            Case 1
                ' Выгрузить в файл
                'If IsDBNull(ResourceGridView.GetFocusedRowCellValue("binData")) Then Exit Sub
                Dim fName As String = Cprp.DxData.Common.ToText(ResourceGridView.GetFocusedRowCellValue("name"))
                Using dlg As New SaveFileDialog
                    dlg.Filter = "Файл Micorosoft Word 2007(*.docx)|*.docx|Файл Micorosoft Word 2003(*.doc)|*.doc|Все файлы (*.*)|*.*"
                    dlg.DefaultExt = "docx"
                    If Not String.IsNullOrWhiteSpace(fName) Then dlg.FileName = fName.Replace(" ", "_")
                    If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                    Dim sTmp As String = My.Computer.FileSystem.GetTempFileName
                    My.Computer.FileSystem.MoveFile(sTmp, dlg.FileName, True)
                    sTmp = dlg.FileName
                    My.Computer.FileSystem.WriteAllBytes(sTmp, ResourceGridView.GetFocusedRowCellValue("binData"), False)
                    'My.Computer.Clipboard.SetText(sTmp)
                    Cprp.DxCommon.Messages.ShowInformation(String.Format("Данные скопированы в файл:{0}{1}", vbCrLf, sTmp))
                End Using
            Case 2
                ' Очистить поле
                ResourceGridView.SetFocusedRowCellValue("binData", DBNull.Value)
        End Select
    End Sub

    Private Sub DataSaveBaseBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveBaseBarButtonItem.ItemClick
        ResourceGridView.CloseEditor()
        ResourceGridView.UpdateCurrentRow()
        Try
            Using A As New SqlDataAdapter("SELECT * FROM tResource WHERE name IS NULL", Program.DbClient.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(ResourceTable)
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbTab, ex.Message), APP_NAME)
            Exit Sub
        End Try
        Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
    End Sub

    Private Sub DataReloadBaseBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataReloadBaseBarButtonItem.ItemClick
        If ResourceTable.Rows.Count > 0 Then
            If Cprp.DxCommon.Messages.ShowQuestion("Перечитать данные?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        End If
        ResourceGridView.CloseEditor()
        ResourceGridView.BeginDataUpdate()
        Try
            ResourceTable.Rows.Clear()
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                Cmd.CommandText = "SELECT * FROM tResource ORDER BY name"
                ResourceTable.Load(Cmd.ExecuteReader)
            End Using
            ResourceGridView.MoveFirst()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbTab, ex.Message), APP_NAME)
        Finally
            ResourceGridView.EndDataUpdate()
        End Try
    End Sub

End Class
