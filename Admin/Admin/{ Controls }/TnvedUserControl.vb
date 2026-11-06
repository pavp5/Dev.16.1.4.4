''' <summary>
''' Товарная номенклатура
''' </summary>
Friend Class TnvedUserControl

    Private TnvedTable As TnvedConnectionTable = Nothing        ' Товарная номенклатура
    Private EndTable As TnvedConnectionTable = Nothing          ' Таблица кодов ТН ВЭД с оконченным сроком действия

    Private Const APP_NAME As String = "Товарная номенклатура"

    Friend Sub New()
        InitializeComponent()
        '
        ' Data
        '
        TnvedTable = New TnvedConnectionTable
        EndTable = New TnvedConnectionTable
        '
        ' QueryComboBoxEdit 
        '
        QueryComboBoxEdit.Text = "SELECT * FROM tTnved WHERE code LIKE '%'"
        '
        ' TableGridControl, TableGridView 
        '
        TnvedGridControl.DataSource = TnvedTable
        TnvedGridView.SortInfo.Insert(0, CodeTnvedGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' EndGridControl, EndGridView 
        '
        EndGridControl.DataSource = EndTable
        EndGridView.SortInfo.Insert(0, CodeEndGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

    End Sub

    ' Закрыть все открытые редакторы
    Private Sub CloseEditor()
        Try
            TnvedGridView.CloseEditor()
            TnvedGridView.UpdateCurrentRow()
            Me.BindingContext(TnvedTable).EndCurrentEdit()
            EndGridView.CloseEditor()
            EndGridView.UpdateCurrentRow()
            Me.BindingContext(EndTable).EndCurrentEdit()
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
            If sTmp.ToUpper Like "SELECT *" AndAlso Not sTmp.ToUpper Like "SELECT*COUNT*" Then
                TnvedTable.Rows.Clear()
                TnvedTable.Load(sTmp)
            Else
                TnvedTable.ExecuteNonQuery(sTmp)
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
        TnvedGridView.OptionsView.RowAutoHeight = ViewHeightBarButtonItem.Down
    End Sub

    ' Загрузить данные из файла Word с двумя таблицами
    Private Sub DataLoadWordBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLoadWordBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.Filter = "Файл Microsoft Word (*.docx;*.doc)|*.docx;*.doc"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show()
        Try
            TnvedTable.Rows.Clear()
            TnvedTable.DataLoadWord(sTmp)
            'TnvedTable.Load1300firm()
            'TnvedTable.DataLoadWord2020(sTmp)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
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
            TnvedTable.Rows.Clear()
            TnvedTable.ReadXml(sTmp)
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
            TnvedTable.SaveToBase()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Сохранить данные в файл XML
    Private Sub DataSaveXMLBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveXMLBarButtonItem.ItemClick
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
            TnvedTable.WriteXml(sTmp)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Очистить таблицу ТН ВЭД от всех данных
    Private Sub DataClearBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataClearBarButtonItem.ItemClick
        TnvedTable.Rows.Clear()
    End Sub

#Region "Срок действия кодов ТН ВЭД"

    ' Добавить устаревший код
    Private Sub EndAddBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles EndAddBarButtonItem.ItemClick
        CloseEditor()
        Dim R As DataRow = EndTable.NewRow
        R("code") = "[укажите код]"
        R("description") = "[устаревший код ТН ВЭД]"
        R("dateB") = Date.Today
        R("dateE") = Date.Today
        EndTable.Rows.Add(R)
        CloseEditor()
    End Sub

    ' Удалить устаревший код
    Private Sub EndDelBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles EndDelBarButtonItem.ItemClick
        If EndGridView.FocusedRowHandle >= 0 Then EndGridView.DeleteRow(EndGridView.FocusedRowHandle)
    End Sub

    ' Очистить таблицу устаревших кодов от всех данных
    Private Sub EndClearBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles EndClearBarButtonItem.ItemClick
        EndTable.Rows.Clear()
    End Sub

    ' Загрузить таблицу устаревших кодов из файла Word
    Private Sub EndLoadWordBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles EndLoadWordBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.Filter = "Файл Microsoft Word (*.docx;*.doc)|*.docx;*.doc"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show()
        Try
            EndTable.Rows.Clear()
            EndTable.DataLoadWordOld(sTmp)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Сохранить срок действия кодов ТН ВЭД в базу данных
    Private Sub EndSaveBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles EndSaveBarButtonItem.ItemClick
        If EndDateEBarEditItem.EditValue Is Nothing Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить срок действия кодов ТН ВЭД в базу данных?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            CloseEditor()
            MsgBox(CDate(EndDateEBarEditItem.EditValue).Month)
            EndTable.DataUpdateDateE(CDate(EndDateEBarEditItem.EditValue))
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

#End Region

    ' Загрузить Товарную Группу из файла Word с иерархической таблицей кодов ТН ВЭД
    Private Sub DataLoadWordIrGroupBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLoadWordIrGroupBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор файла для загрузки данных"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim dateB As Date = CDate("01.01.2022")     ' дата начала срока действия кодов ТН ВЭД
        Dim dateE As Date = CDate("31.12.9999")     ' дата завершения срока действия кодов ТН ВЭД
        CloseEditor()
        TnvedGridView.BeginDataUpdate()
        Try
            TnvedTable.Rows.Clear()
            TnvedTable.DataLoadWordIrGroup(sTmp, dateB, dateE)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        Finally
            TnvedGridView.EndDataUpdate()
            TnvedGridView.MoveFirst()
        End Try
    End Sub

    ' Загрузить таблицу 14-значных кодов ТН ВЭД из файла Word
    Private Sub DataLoadWord14BarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLoadWord14BarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор файла для загрузки данных"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim dateB As Date = CDate("01.01.2022")     ' дата начала срока действия кодов ТН ВЭД
        Dim dateE As Date = CDate("31.12.9999")     ' дата завершения срока действия кодов ТН ВЭД
        CloseEditor()
        TnvedGridView.BeginDataUpdate()
        Try
            TnvedTable.Rows.Clear()
            TnvedTable.DataLoadWord14(sTmp, dateB, dateE)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        Finally
            TnvedGridView.EndDataUpdate()
            TnvedGridView.MoveFirst()
        End Try
    End Sub

    ' Загрузить единицы измерений из таблиц в файле Word
    Private Sub DataLoadUnitBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLoadUnitBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор файла для загрузки данных"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Dim parentText As String = Me.ParentForm.Text
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            TnvedTable.DataLoadWordUnit(sTmp, Me.ParentForm)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.", APP_NAME)
            Me.ParentForm.Text = parentText
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

End Class
