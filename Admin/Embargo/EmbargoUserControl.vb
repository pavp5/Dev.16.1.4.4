Imports Cprp.DxData.Common
''' <summary>
''' Элемент управления Запреты и ограничения
''' </summary>
Public Class EmbargoUserControl

    ''' <summary>
    ''' Источник данных запретов и ограничений
    ''' </summary>
    Private Ds As EmbargoDataSet = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        Ds = New EmbargoDataSet(Connection)
        Ds.DataLoadBase()
        EmbargoGridControl.DataSource = Ds.EmbargoTable
    End Sub


    Private Sub EmbargoGridView_InitNewRow(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles EmbargoGridView.InitNewRow
        EmbargoGridView.SetRowCellValue(e.RowHandle, "id", Ds.EmbargoTable.NewId)
        EmbargoGridView.SetRowCellValue(e.RowHandle, "caption", "[новый документ]")
        EmbargoGridView.SetRowCellValue(e.RowHandle, "caption2", "[новый документ]")
    End Sub

    ' Выровнять высоту ячеек по содержимому
    Private Sub ViewHeightBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ViewHeightBarButtonItem.ItemClick
        EmbargoGridView.OptionsView.RowAutoHeight = ViewHeightBarButtonItem.Down
    End Sub

    ' Сохранить данные в базу
    Private Sub DataSaveBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveBaseBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить данные в базу?") <> DialogResult.Yes Then Exit Sub
        EmbargoGridView.CloseEditor()
        EmbargoGridView.UpdateCurrentRow()
        Try
            Ds.DataSaveBase()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.")
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ' Перечитать данные из базы
    Private Sub DataReloadBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataReloadBaseBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Перечитать данные из базы?") <> DialogResult.Yes Then Exit Sub
        EmbargoGridView.BeginDataUpdate()
        Try
            Ds.DataLoadBase()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            EmbargoGridView.EndDataUpdate()
        End Try
    End Sub

    ' Связи со странами
    Private Sub CountryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CountryBarButtonItem.ItemClick
        If EmbargoGridView.FocusedRowHandle < 0 Then Exit Sub
        Using F As New CountryForm(Me.Ds, CInt(EmbargoGridView.GetFocusedDataRow("id")))
            F.ShowDialog()
        End Using
    End Sub

    ' Фирмы
    Private Sub MemberBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles MemberBarButtonItem.ItemClick
        If EmbargoGridView.FocusedRowHandle < 0 Then Exit Sub
        Using F As New MemberForm(Me.Ds, CInt(EmbargoGridView.GetFocusedDataRow("id")))
            F.ShowDialog()
        End Using
    End Sub

    ' Товары
    Private Sub GoodBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles GoodBarButtonItem.ItemClick
        If EmbargoGridView.FocusedRowHandle < 0 Then Exit Sub
        Using F As New GoodForm(Me.Ds, CInt(EmbargoGridView.GetFocusedDataRow("id")))
            F.ShowDialog()
        End Using
    End Sub

    ' Загрузить в базу данных файл документа
    Private Sub FileToBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileToBaseBarButtonItem.ItemClick
        If EmbargoGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim fPath As String = Nothing
        Using dlg As New OpenFileDialog
            dlg.Title = "Выбор файла для загрузки"
            dlg.Multiselect = False
            dlg.Filter = "Файл PDF (*.pdf)|*.pdf"
            If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            fPath = dlg.FileName
        End Using
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format( _
            "Файл будет загружен в документ ""{0}"". Продолжить?", _
            EmbargoGridView.GetFocusedDataRow("caption").ToString)) <> DialogResult.Yes Then Exit Sub
        Using T As New DataTable
            T.Columns.Add("id", GetType(Integer))
            T.Columns.Add("pdfData", GetType(Byte()))
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            T.Load(Ds.ExecuteReader(String.Format("SELECT id, pdfData FROM tEmbargo WHERE id = {0}", CInt(EmbargoGridView.GetFocusedDataRow("id")))))
            T(0)("pdfData") = My.Computer.FileSystem.ReadAllBytes(fPath)
            Using A As New SqlDataAdapter(String.Format( _
                "SELECT id, pdfData FROM tEmbargo WHERE id = {0}", CInt(EmbargoGridView.GetFocusedDataRow("id"))), Ds.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(T)
            End Using
        End Using
        Cprp.DxCommon.Messages.ShowInformation("Файл документа загружен в базу данных.")
    End Sub

    ' Выгрузить из базы данных файл документа
    Private Sub FileFromBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileFromBaseBarButtonItem.ItemClick
        If EmbargoGridView.FocusedRowHandle < 0 Then Exit Sub
        If CInt(Ds.ExecuteScalar(String.Format("SELECT COUNT(*) FROM tEmbargo WHERE id = {0} AND NOT pdfData IS NULL", CInt(EmbargoGridView.GetFocusedDataRow("id"))))) = 0 Then
            Cprp.DxCommon.Messages.ShowWarning("Файл документа в базе данных отсутствует.")
            Exit Sub
        End If
        Dim fPath As String = Nothing
        Using dlg As New SaveFileDialog
            dlg.Title = "Выбор файла для сохранения данных"
            dlg.Filter = "Файл PDF (*.pdf)|*.pdf"
            If dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            fPath = dlg.FileName
        End Using
        Using T As New DataTable
            T.Columns.Add("id", GetType(Integer))
            T.Columns.Add("pdfData", GetType(Byte()))
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            T.Load(Ds.ExecuteReader(String.Format("SELECT id, pdfData FROM tEmbargo WHERE id = {0}", CInt(EmbargoGridView.GetFocusedDataRow("id")))))
            My.Computer.FileSystem.WriteAllBytes(fPath, T(0)("pdfData"), False)
        End Using
        Cprp.DxCommon.Messages.ShowInformation("Файл документа выгружен из базы данных.")
    End Sub

    ' Удалить в базе данных файл документа
    Private Sub FileDelBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileDelBaseBarButtonItem.ItemClick
        If EmbargoGridView.FocusedRowHandle < 0 Then Exit Sub
        If CInt(Ds.ExecuteScalar(String.Format("SELECT COUNT(*) FROM tEmbargo WHERE id = {0} AND NOT pdfData IS NULL", CInt(EmbargoGridView.GetFocusedDataRow("id"))))) = 0 Then
            Cprp.DxCommon.Messages.ShowWarning("Файл документа в базе данных отсутствует.")
            Exit Sub
        End If
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format( _
           "В базе данных будет удален файл документа ""{0}"". Продолжить?", _
           EmbargoGridView.GetFocusedDataRow("caption").ToString)) <> DialogResult.Yes Then Exit Sub
        Ds.ExecuteNonQuery(String.Format("UPDATE tEmbargo SET pdfData = NULL WHERE id = {0}", CInt(EmbargoGridView.GetFocusedDataRow("id"))))
        Cprp.DxCommon.Messages.ShowInformation("Файл документа удален в базе данных.")
    End Sub

    ' Переписать в базе данных таблицу кодов ТН ВЭД товаров
    Private Sub TnvedBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TnvedBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Переписать в базе данных таблицу кодов ТН ВЭД товаров?") <> DialogResult.Yes Then Exit Sub
        Dim lastCaption = Me.ParentForm.Text
        Dim arrT() As String = Nothing
        Dim sTmp As String = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            Ds.ExecuteNonQuery("DELETE FROM tEmbargoGoodTnved")
            For i As Integer = 0 To Ds.GoodTable.Rows.Count - 1
                Me.ParentForm.Text = String.Format("Загрузка кодов [{0} из {1}]", i + 1, Ds.GoodTable.Rows.Count)
                Application.DoEvents()
                sTmp = GetTnvedString(ToText(Ds.GoodTable(i)("tnved")))
                If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                arrT = sTmp.Split(New Char() {"A"}, StringSplitOptions.RemoveEmptyEntries)
                For Each sTmp In arrT
                    Ds.ExecuteNonQuery(String.Format("INSERT tEmbargoGoodTnved (goodId, tnved) VALUES ({0}, '{1}')", CInt(Ds.GoodTable(i)("id")), sTmp))
                Next
            Next
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.", "Загрузка кодов")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), "Загрузка кодов")
        Finally
            Me.ParentForm.Text = lastCaption
        End Try
    End Sub

    ''' <summary>
    ''' Преобразует строку алфавитно-цифровых символов в строку кодов ТН ВЭД, разделенных символом "A"
    ''' </summary>
    ''' <param name="sourceString">Исходная строка алфавитно-цифровых символов</param>
    Private Function GetTnvedString(sourceString As String) As String
        sourceString = ToText(sourceString)
        If String.IsNullOrWhiteSpace(sourceString) Then Return Nothing
        For Each c As Char In sourceString
            If c Like "[A0123456789]" Then Continue For
            sourceString = sourceString.Replace(c, "A")
        Next
        While sourceString Like "*AA*"
            sourceString = sourceString.Replace("AA", "A")
        End While
        Return sourceString
    End Function

End Class
