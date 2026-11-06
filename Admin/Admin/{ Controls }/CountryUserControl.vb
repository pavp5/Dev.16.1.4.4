''' <summary>
''' Страны мира
''' </summary>
Friend Class CountryUserControl

    ''' <summary>
    ''' Таблица стран мира
    ''' </summary>
    Private CountryTable As CountryConnectionTable = Nothing


    Private Const APP_NAME As String = "Страны мира"


    Friend Sub New()
        InitializeComponent()
        '
        ' CountryTable
        '
        CountryTable = New CountryConnectionTable
        '
        ' QueryComboBoxEdit 
        '
        QueryComboBoxEdit.Text = "SELECT * FROM tCountry WHERE id > 0"
        '
        ' CountryGridControl, CountryGridView 
        '
        CountryGridControl.DataSource = CountryTable
        CountryGridView.SortInfo.Insert(0, NameShortGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

    End Sub


    ' Закрыть все открытые редакторы
    Private Sub CloseEditor()
        Try
            CountryGridView.CloseEditor()
            CountryGridView.UpdateCurrentRow()
            Me.BindingContext(CountryTable).EndCurrentEdit()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub QueryComboBoxEdit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles QueryComboBoxEdit.GotFocus
        QueryComboBoxEdit.DeselectAll()
    End Sub

    ' Выполнение запроса к базе
    Private Sub QueryComboBoxEdit_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles QueryComboBoxEdit.ButtonClick
        If e.Button.Index = 0 Then Exit Sub
        Dim sTmp As String = Trim(QueryComboBoxEdit.Text)
        If e.Button.Index = 1 Then
            With New QueryForm
                .QueryMemoEdit.Text = sTmp
                If .ShowDialog <> DialogResult.OK Then Exit Sub
                sTmp = .QueryMemoEdit.Text.Replace(vbCrLf, " ")
                QueryComboBoxEdit.Text = sTmp
            End With
        End If
        If String.IsNullOrWhiteSpace(sTmp) Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            ' Выполнение запроса
            If sTmp.ToUpper Like "SELECT *" AndAlso Not sTmp.ToUpper Like "SELECT*COUNT*(*" Then
                CountryTable.Rows.Clear()
                CountryTable.Load(sTmp)
            Else
                CountryTable.ExecuteNonQuery(sTmp)
            End If
            ' Добавление строки запроса к списку запросов
            Dim bTmp As Boolean = True
            For i As Integer = 0 To QueryComboBoxEdit.Properties.Items.Count - 1
                If QueryComboBoxEdit.Properties.Items(i).ToString.ToUpper Like sTmp.ToUpper Then
                    bTmp = False
                    Exit For
                End If
            Next
            If bTmp Then QueryComboBoxEdit.Properties.Items.Add(sTmp)
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Выровнять высоту ячеек по содержимому
    Private Sub ViewHeightBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ViewHeightBarButtonItem.ItemClick
        CountryGridView.OptionsView.RowAutoHeight = ViewHeightBarButtonItem.Down
    End Sub

    ' Загрузить данные из файла XML
    Private Sub DataLoadXmlBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLoadXmlBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.Filter = "Файл XML (*.xml)|*.xml"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            CountryTable.Rows.Clear()
            CountryTable.ReadXml(sTmp)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Сохранить данные в базу
    Private Sub DataSaveBaseBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveBaseBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить данные в базу?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            CloseEditor()
            CountryTable.SaveToBase()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Сохранить данные в файл XML
    Private Sub DataSaveXMLBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveXmlBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.Filter = "Файл XML (*.xml)|*.xml"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            CloseEditor()
            CountryTable.WriteXml(sTmp)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Очистить таблицу стран мира от всех данных
    Private Sub DataClearBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataClearBarButtonItem.ItemClick
        CountryTable.Rows.Clear()
    End Sub

End Class
