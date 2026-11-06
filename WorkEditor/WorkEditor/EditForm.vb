Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма редактирования проектов заключений
''' </summary>
''' <remarks></remarks>
Friend Class EditForm


    ' Источник данных текущей работы
    Private Ds As DataSet = Nothing

    ' Путь к папке файлов работ 
    Private workFolderPath As String = Nothing

    ' Путь к файлу работы
    Private workFilePath As String = Nothing

    Friend Sub New()
        InitializeComponent()
        '
        ' workFolderPath
        '
        Using Cmd As New SqlClient.SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = "SELECT strData FROM tResource WHERE name LIKE 'WORKFOLDERPATH'"
            workFolderPath = C2.ToText(Cmd.ExecuteScalar)
        End Using
        If Not (C2.IsText(workFolderPath) AndAlso My.Computer.FileSystem.DirectoryExists(workFolderPath)) Then
            WorkLoadBarButtonItem.Enabled = False
            WorkSaveBarButtonItem.Enabled = False
            Cprp.DxCommon.Messages.ShowError("Не найдена папка файлов работ", "Редактор проектов")
        End If
        '
        ' Me
        '
        Me.Text = "Редактор проектов заключений"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

    End Sub

    Private Sub WorkLoadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkLoadBarButtonItem.ItemClick
        Dim sTmp As String = InputBox("Укажите номер работы:", "Загрузка проекта")
        If Not C2.IsText(sTmp) Then Exit Sub

        sTmp = String.Format("{0}\{1}.work", workFolderPath, sTmp)
        If Not My.Computer.FileSystem.FileExists(sTmp) Then
            Cprp.DxCommon.Messages.ShowError("Файл данных работы не найден", "Редактор проектов")
            Exit Sub
        End If

        If Not Ds Is Nothing Then Ds.Dispose()
        Ds = New DataSet("WorkData")

        workFilePath = Nothing
        Ds.ReadXml(sTmp, XmlReadMode.ReadSchema)

        If Ds.Tables("ARow") Is Nothing OrElse Ds.Tables("Arow").Rows.Count = 0 OrElse IsDBNull(Ds.Tables("Arow")(0)("doc1Data")) Then
            Cprp.DxCommon.Messages.ShowError("Проект заключения #1 в работе отсутствует.")
            Exit Sub
        End If
        R.OpenXmlBytes = Ds.Tables("Arow")(0)("doc1Data")
        workFilePath = sTmp

        Cprp.DxCommon.Messages.ShowInformation("Проект заключения #1 загружен.")
    End Sub

    Private Sub WorkSaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkSaveBarButtonItem.ItemClick
        If Ds Is Nothing OrElse workFilePath Is Nothing OrElse Not My.Computer.FileSystem.FileExists(workFilePath) Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить проект заключения #1 в файл данных работы?", "Вопросец") <> Windows.Forms.DialogResult.Yes Then Exit Sub
        Try
            Ds.Tables("Arow")(0)("doc1Data") = R.OpenXmlBytes
            Ds.AcceptChanges()
            Ds.WriteXml(workFilePath, XmlWriteMode.WriteSchema)
            Cprp.DxCommon.Messages.ShowQuestion("Данные сохранены.")
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка сохранения данных:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    'Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
    '    If R.Document.Tables.GetTableCell(R.Document.CaretPosition) Is Nothing Then Exit Sub
    '    With R.Document.Tables.GetTableCell(R.Document.CaretPosition)
    '        .Table.TableLayout = DevExpress.XtraRichEdit.API.Native.TableLayoutType.Fixed
    '        .Table.PreferredWidthType = DevExpress.XtraRichEdit.API.Native.WidthType.Fixed
    '        .PreferredWidth += 0.1 * .PreferredWidth
    '    End With
    'End Sub

    Private Sub DelBookmarksBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DelBookmarksBarButtonItem.ItemClick
        While R.Document.Bookmarks.Count > 0
            R.Document.Bookmarks.Remove(R.Document.Bookmarks(0))
        End While
        MsgBox("OK")
    End Sub
End Class