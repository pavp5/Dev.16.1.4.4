Imports Cprp.DxData.Common
''' <summary>
''' Нормативные документы
''' </summary>
Friend Class ControlUserControl

    Private ControlTable As ControlConnectionTable = Nothing                ' Нормативные документы
    Private ControlTnvedTable As ControlTnvedConnectionTable = Nothing      ' Коды ТН ВЭД в нормативных документах
    Private ControlTnvedView As DataView = Nothing
    Private ControlCasTable As ControlCasConnectionTable = Nothing          ' Номера CAS в нормативных документах
    Private ControlCasView As DataView = Nothing
    Private ControlLinkTable As ControlLinkConnectionTable = Nothing        ' Связи пунктов нормативных документов
    Private ControlLinkView As DataView = Nothing

    Private Const APP_NAME As String = "Нормативные документы"

    Friend Sub New()
        InitializeComponent()
        '
        ' Data
        '
        ControlTable = New ControlConnectionTable
        ControlTnvedTable = New ControlTnvedConnectionTable
        ControlTnvedView = New DataView(ControlTnvedTable)
        ControlTnvedView.RowFilter = "lawId IS NULL"
        ControlCasTable = New ControlCasConnectionTable
        ControlCasView = New DataView(ControlCasTable)
        ControlCasView.RowFilter = "lawId IS NULL"
        ControlLinkTable = New ControlLinkConnectionTable
        ControlLinkView = New DataView(ControlLinkTable)
        ControlLinkView.RowFilter = "lawId IS NULL"
        '
        ' QueryComboBoxEdit 
        '
        QueryComboBoxEdit.Text = "SELECT * FROM tLaw WHERE id > 0"
        '
        ' TableGridControl, TableGridView 
        '
        TableGridControl.DataSource = ControlTable
        TableGridView.SortInfo.Insert(0, SortIdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' TreeTreeList 
        '
        TreeTreeList.DataSource = ControlTable
        SortIdTreeListColumn.SortIndex = 0
        '
        ' TnvedGridControl, TnvedGridView
        '
        TnvedGridControl.DataSource = ControlTnvedView
        TnvedGridView.SortInfo.Insert(0, TnvedTnvedGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' CasGridControl, CasGridView
        '
        CasGridControl.DataSource = ControlCasView
        CasGridView.SortInfo.Insert(0, CasCasGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' LinkGridControl, LinkGridView, LinkDescriptionMemoEdit
        '
        LinkGridControl.DataSource = ControlLinkView
        LinkGridView.SortInfo.Insert(0, LinkIdLinkGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        LinkDescriptionMemoEdit.DataBindings.Add("Text", ControlLinkView, "linkDescription")
        '
        ' Представление данных в виде таблицы
        '
        ViewTableBarButtonItem.PerformClick()

    End Sub

    ' Закрыть все открытые редакторы
    Private Sub CloseEditor()
        Try
            TableGridView.UpdateCurrentRow()
            TableGridView.CloseEditor()
            TreeTreeList.CloseEditor()
            TnvedGridView.UpdateCurrentRow()
            TnvedGridView.CloseEditor()
            CasGridView.UpdateCurrentRow()
            CasGridView.CloseEditor()
            LinkGridView.UpdateCurrentRow()
            LinkGridView.CloseEditor()
            Me.BindingContext(ControlTable).EndCurrentEdit()
            Me.BindingContext(ControlTnvedView).EndCurrentEdit()
            Me.BindingContext(ControlTnvedTable).EndCurrentEdit()
            Me.BindingContext(ControlCasView).EndCurrentEdit()
            Me.BindingContext(ControlCasTable).EndCurrentEdit()
            Me.BindingContext(ControlLinkView).EndCurrentEdit()
            Me.BindingContext(ControlLinkTable).EndCurrentEdit()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub QueryComboBoxEdit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles QueryComboBoxEdit.GotFocus
        QueryComboBoxEdit.DeselectAll()
    End Sub

    Private Sub TableGridView_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles TableGridView.FocusedRowChanged
        Dim iTmp As Integer = -1
        If e.FocusedRowHandle >= 0 Then iTmp = CInt(TableGridView.GetFocusedDataRow("id"))
        ControlTnvedView.RowFilter = String.Format("lawId = {0}", iTmp)
        ControlCasView.RowFilter = String.Format("lawId = {0}", iTmp)
        ControlLinkView.RowFilter = String.Format("lawId = {0}", iTmp)
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
                ControlTable.Rows.Clear()
                ControlTable.Load(sTmp)
            Else
                ControlTable.ExecuteNonQuery(sTmp)
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

    ' Представление данных в виде таблицы
    Private Sub ViewTableBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ViewTableBarButtonItem.ItemClick
        TableLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
        TreeLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
    End Sub

    ' Представление данных в виде дерева
    Private Sub ViewTreeBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ViewTreeBarButtonItem.ItemClick
        TableLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        TreeLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
    End Sub

    ' Выровнять высоту ячеек списков документов по содержимому
    Private Sub ViewHeightBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ViewHeightBarButtonItem.ItemClick
        TableGridView.OptionsView.RowAutoHeight = ViewHeightBarButtonItem.Down
        TreeTreeList.OptionsBehavior.AutoNodeHeight = ViewHeightBarButtonItem.Down
    End Sub

    ' Сортировать таблицу документов по содержимому
    Private Sub ViewSortBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ViewSortBarButtonItem.ItemClick
        With TableGridView.SortInfo
            .Clear()
            .Insert(0, DocGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
            .Insert(1, SortIdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
            .Insert(2, IdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        End With
        DocTreeListColumn.SortIndex = 0
        SortIdTreeListColumn.SortIndex = 1
        IdTreeListColumn.SortIndex = 2
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
            ControlTable.Rows.Clear()
            ControlTable.DataLoadWord(sTmp)
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
            ControlTable.Rows.Clear()
            ControlTable.ReadXml(sTmp)
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
            ControlTable.SaveToBase()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Сохранить данные в файл XML
    Private Sub DataSaveXmlBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveXmlBarButtonItem.ItemClick
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
            ControlTable.WriteXml(sTmp)
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Сохранить данные в файл MS Word с двумя таблицами
    Private Sub DataSaveWordBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveWordBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            CloseEditor()
            ControlTable.DataSaveWord(sTmp)
            Cprp.DxCommon.WaitForm.Close()
            If Cprp.DxCommon.Messages.ShowQuestion("Данные выгружены в файл. Открыть файл?", APP_NAME) = DialogResult.Yes Then
                Using P As New Process
                    P.StartInfo.FileName = sTmp
                    P.StartInfo.Verb = "Open"
                    P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    P.Start()
                End Using
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Сохранить данные в файл Excel
    Private Sub DataSaveExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveExcelBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Try
            CloseEditor()
            If TableLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never Then
                TreeTreeList.ExportToXlsx(sTmp)
            Else
                TableGridView.ExportToXlsx(sTmp)
            End If
            If Cprp.DxCommon.Messages.ShowQuestion("Данные выгружены в файл. Открыть файл?", APP_NAME) = DialogResult.Yes Then
                Using P As New Process
                    P.StartInfo.FileName = sTmp
                    P.StartInfo.Verb = "Open"
                    P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    P.Start()
                End Using
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Очистить списки нормативных документов от всех данных
    Private Sub DataClearBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataClearBarButtonItem.ItemClick
        ControlTable.Rows.Clear()
    End Sub

    ' Перенумеровать поле sortId пунктов нормативных документов
    Private Sub DataReplaceIdBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataReplaceIdBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Перенумеровать поле sortId всех пунктов нормативных документов?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim fCaption As String = Me.ParentForm.Text
        CloseEditor()
        TableGridView.BeginDataUpdate()
        TreeTreeList.LockReloadNodes()
        Try
            ControlTable.Rows.Clear()
            ControlTable.Load("SELECT * FROM tLaw")
            Dim sortId As Integer = 0
            Using V As New DataView(ControlTable) With {.Sort = "doc, sortId, id", .RowFilter = "parentId IS NULL"}
                For i As Integer = 0 To V.Count - 1
                    sortId += 1
                    V(i)("iTmp") = sortId
                    Me.ParentForm.Text = sortId
                    Application.DoEvents()
                    sortId = SetChildSortId(CInt(V(i)("id")), sortId)
                Next
            End Using
            sortId = 0
            For Each Row As DataRow In ControlTable.Rows
                sortId += 1
                Row("sortId") = Row("iTmp")
                Me.ParentForm.Text = sortId
            Next
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        Finally
            TableGridView.EndDataUpdate()
            TreeTreeList.UnlockReloadNodes()
            Me.ParentForm.Text = fCaption
        End Try
    End Sub
    Private Function SetChildSortId(parentId As Integer, parentSortId As Integer) As Integer
        Dim sortId As Integer = parentSortId
        Using V As New DataView(ControlTable) With {.Sort = "doc, sortId, id", .RowFilter = String.Format("parentId = {0}", parentId)}
            For i As Integer = 0 To V.Count - 1
                sortId += 1
                V(i)("iTmp") = sortId
                Me.ParentForm.Text = sortId
                Application.DoEvents()
                sortId = SetChildSortId(CInt(V(i)("id")), sortId)
            Next
        End Using
        Return sortId
    End Function

    ' Переписать в базе данных иерархические уровни пунктов нормативных документов
    Private Sub DataReplaceLevelBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataReplaceLevelBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Переписать в базе данных уровни пунктов нормативных документов?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim fCaption As String = Me.ParentForm.Text
        ViewTreeBarButtonItem.PerformClick()
        CloseEditor()
        TableGridView.BeginDataUpdate()
        TreeTreeList.LockReloadNodes()
        Try
            ControlTable.Rows.Clear()
            ControlTable.Load("SELECT * FROM tLaw")
            Application.DoEvents()
            For Each N As DevExpress.XtraTreeList.Nodes.TreeListNode In TreeTreeList.Nodes
                RefreshNodeLevel(N)
            Next
            ControlTable.SaveToBase()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        Finally
            TableGridView.EndDataUpdate()
            TreeTreeList.UnlockReloadNodes()
            Me.ParentForm.Text = fCaption
        End Try
    End Sub
    Private Sub RefreshNodeLevel(ByRef N As DevExpress.XtraTreeList.Nodes.TreeListNode)
        N.SetValue("lev", N.Level)
        For Each N1 As DevExpress.XtraTreeList.Nodes.TreeListNode In N.Nodes
            RefreshNodeLevel(N1)
            Me.ParentForm.Text = N.GetValue("sortId").ToString
            Application.DoEvents()
        Next
    End Sub

    ' Переписать таблицу кодов ТН ВЭД в нормативных документах
    Private Sub DataReplaceTnvedBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataReplaceTnvedBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Переписать в базе данных таблицу кодов ТН ВЭД в нормативных документах?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Dim Arr() As String = Nothing
        Dim sTmp As String = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim fCaption As String = Me.ParentForm.Text
        TableGridView.BeginDataUpdate()
        TreeTreeList.LockReloadNodes()
        Try
            ControlTable.Rows.Clear()
            ControlTable.Load("SELECT * FROM tLaw")
            ControlTnvedTable.Rows.Clear()
            For Each R As DataRow In ControlTable.Rows
                sTmp = Nothing
                Arr = R("tnved").ToString.Split(New Char() {" ", vbCrLf}, StringSplitOptions.RemoveEmptyEntries)
                Array.Sort(Arr)
                For i As Integer = Arr.GetLowerBound(0) To Arr.GetUpperBound(0)
                    If i > Arr.GetLowerBound(0) AndAlso Arr(i) = Arr(i - 1) Then Continue For
                    If Arr(i).Length > 14 Then
                        MsgBox(R("id").ToString)
                        MsgBox(Arr(i))
                    End If
                    ControlTnvedTable.Rows.Add(New Object() {R("id"), Arr(i), False})
                    sTmp &= (Arr(i) & " ")
                Next
                R("tnved") = Trim(sTmp) ' удаление в таблице нормативных документов повторящихся кодов ТН ВЭД
                Me.ParentForm.Text = R("sortId").ToString
                Application.DoEvents()
            Next
            ControlTable.SaveToBase()
            ControlTnvedTable.ExecuteNonQuery("DELETE FROM tLawTnved WHERE is2 = 0")
            ControlTnvedTable.SaveToBase()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        Finally
            TableGridView.EndDataUpdate()
            TreeTreeList.UnlockReloadNodes()
            Me.ParentForm.Text = fCaption
        End Try
    End Sub

    ' Переписать в базе данных таблицу номеров CAS в нормативных документах
    Private Sub DataReplaceCasBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataReplaceCasBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Переписать в базе данных таблицу номеров CAS в нормативных документах?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Dim Arr() As String = Nothing
        Dim sTmp As String = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim fCaption As String = Me.ParentForm.Text
        TableGridView.BeginDataUpdate()
        TreeTreeList.LockReloadNodes()
        Try
            ControlTable.Rows.Clear()
            ControlTable.Load("SELECT * FROM tLaw")
            ControlCasTable.Rows.Clear()
            For Each R As DataRow In ControlTable.Rows
                sTmp = Nothing
                Arr = R("cas").ToString.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                Array.Sort(Arr)
                For i As Integer = Arr.GetLowerBound(0) To Arr.GetUpperBound(0)
                    If i > Arr.GetLowerBound(0) AndAlso Arr(i) = Arr(i - 1) Then Continue For
                    If Arr(i).Length > 20 Then MsgBox(R("id").ToString)
                    ControlCasTable.Rows.Add(New Object() {R("id"), Arr(i)})
                    sTmp &= (Arr(i) & " ")
                Next
                R("cas") = Trim(sTmp) ' удаление в таблице нормативных документов повторящихся номеров CAS
                Me.ParentForm.Text = R("sortId").ToString
                Application.DoEvents()
            Next
            ControlTable.SaveToBase()
            ControlCasTable.ExecuteNonQuery("DELETE FROM tLawCas")
            ControlCasTable.SaveToBase()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        Finally
            TableGridView.EndDataUpdate()
            TreeTreeList.UnlockReloadNodes()
            Me.ParentForm.Text = fCaption
        End Try
    End Sub

    ' Переписать в базе данных таблицу связей пунктов нормативных документов
    Private Sub DataReplaceLinkBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataReplaceLinkBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Переписать в базе данных таблицу связанных пунктов нормативных документов?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Dim description As String = Nothing
        Dim parentId As Integer = 0
        Dim childId As Integer = 0
        Dim doc As String = Nothing
        Dim linkDescription As String = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim fCaption As String = Me.ParentForm.Text
        Try
            ControlTable.Rows.Clear()
            ControlTable.Load("SELECT * FROM tLaw")
            ControlLinkTable.Rows.Clear()
            Using V As New DataView(ControlTable)
                For Each R As DataRow In ControlTable.Rows
                    doc = R("doc").ToString
                    If Not (doc Like "1030.0001%" OrElse doc Like "1030.0002%" OrElse doc Like "1030.0003%") Then
                        doc = doc.Substring(0, 4)
                    End If
                    description = R("description").ToString & ";"
                    linkDescription = Nothing
                    For i As Integer = 0 To description.Length - 1
                        If description(i).ToString Like "[0123456789.]" Then
                            linkDescription &= description(i).ToString
                            Continue For
                        End If
                        If Not String.IsNullOrWhiteSpace(linkDescription) AndAlso linkDescription Like "*.*" Then
                            V.RowFilter = String.Format("doc LIKE '{1}%' AND (pos = '{0}' OR pos = '{0}.') AND id <> {2}", _
                                                        linkDescription, doc, CInt(R("id")))
                            If V.Count > 0 Then
                                parentId = CInt(R("id"))
                                childId = CInt(V(0)("id"))
                                linkDescription = V(0)("pos").ToString
                                ' Проверка что таблица ссылок еще не содержит найденную ссылку
                                If ControlLinkTable.Rows.Find(New Object() {parentId, childId}) Is Nothing Then
                                    ' Добавление строки в таблицу ссылок
                                    ControlLinkTable.Rows.Add(New Object() {parentId, childId})
                                End If
                            End If
                        End If
                        linkDescription = Nothing
                    Next
                    Me.ParentForm.Text = R("sortId").ToString
                    Application.DoEvents()
                Next
            End Using
            ControlLinkTable.ExecuteNonQuery("DELETE FROM tLawLink")
            ControlLinkTable.SaveToBase()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        Finally
            Me.ParentForm.Text = fCaption
        End Try
    End Sub

#Region "Коды ТН ВЭД в нормативных документах"

    ' Добавить новый код ТН ВЭД
    Private Sub DataTnvedAddBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataTnvedAddBarButtonItem.ItemClick
        TnvedGridView.AddNewRow()
    End Sub

    ' Удалить код ТН ВЭД
    Private Sub DataTnvedDelBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataTnvedDelBarButtonItem.ItemClick
        If TnvedGridView.FocusedRowHandle >= 0 Then TnvedGridView.DeleteRow(TnvedGridView.FocusedRowHandle)
    End Sub

    ' Сохранить коды ТН ВЭД в базу
    Private Sub DataTnvedSaveBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataTnvedSaveBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить в базу данных таблицу кодов ТН ВЭД?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Try
            CloseEditor()
            ControlTnvedTable.SaveToBase()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Перечитать коды ТН ВЭД из базы
    Private Sub DataTnvedReloadBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataTnvedReloadBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Перечитать из базы данных таблицу кодов ТН ВЭД?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Try
            CloseEditor()
            ControlTnvedTable.LoadFromBase()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

#End Region
#Region "Номера CAS в нормативных документах"

    ' Добавить номер CAS
    Private Sub DataCasAddBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataCasAddBarButtonItem.ItemClick
        CasGridView.AddNewRow()
    End Sub

    ' Удалить номер CAS
    Private Sub DataCasDelBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataCasDelBarButtonItem.ItemClick
        If CasGridView.FocusedRowHandle >= 0 Then CasGridView.DeleteRow(CasGridView.FocusedRowHandle)
    End Sub

    ' Сохранить номера CAS в базу
    Private Sub DataCasSaveBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataCasSaveBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить в базу данных таблицу номеров CAS?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Try
            CloseEditor()
            ControlCasTable.SaveToBase()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Перечитать номера CAS из базы
    Private Sub DataCasReloadBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataCasReloadBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Перечитать из базы данных таблицу номеров CAS?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Try
            CloseEditor()
            ControlCasTable.LoadFromBase()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

#End Region
#Region "Связи пунктов нормативных документов"

    ' Добавить связь
    Private Sub DataLinkAddBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLinkAddBarButtonItem.ItemClick
        LinkGridView.AddNewRow()
    End Sub

    ' Удалить связь
    Private Sub DataLinkDelBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLinkDelBarButtonItem.ItemClick
        If LinkGridView.FocusedRowHandle >= 0 Then LinkGridView.DeleteRow(LinkGridView.FocusedRowHandle)
    End Sub

    ' Сохранить связи в базу
    Private Sub DataLinkSaveBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLinkSaveBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить в базу данных таблицу связей пунктов нормативных документов?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Try
            CloseEditor()
            ControlLinkTable.SaveToBase()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

    ' Перечитать связи из базы
    Private Sub DataLinkReloadBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLinkReloadBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Перечитать из базы данных таблицу связей пунктов нормативных документов?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        Try
            CloseEditor()
            ControlLinkTable.LoadFromBase()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.", APP_NAME)
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
    End Sub

#End Region

    ' Добавить новый пункт
    Private Sub RowAddBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RowAddBarButtonItem.ItemClick
        ViewTableBarButtonItem.PerformClick()
        Application.DoEvents()
        '
        ' id новой строки
        '
        Dim newId As Integer = 1
        Using V As New DataView(ControlTable) With {.Sort = "id DESC"}
            If V.Count > 0 Then newId = CInt(V(0)("id")) + 1
        End Using
        '
        ' Новая строка
        '
        Dim Row As DataRow = ControlTable.NewRow
        If TableGridView.FocusedRowHandle >= 0 Then
            Dim Row1 As DataRow = TableGridView.GetFocusedDataRow
            For Each C As DataColumn In ControlTable.Columns
                Row(C.ColumnName) = Row1(C.ColumnName)
            Next
        End If
        Row("id") = newId
        '
        ' Добавление строки в таблицу
        '
        TableGridView.BeginDataUpdate()
        Try
            ControlTable.Rows.Add(Row)
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
            Exit Sub
        Finally
            TableGridView.EndDataUpdate()
        End Try
        '
        ' Переход к новой строке
        '
        'TableGridView.MoveFirst()
        Dim iTmp As Integer = 0
        While TableGridView.IsValidRowHandle(iTmp)
            Row = TableGridView.GetDataRow(iTmp)
            If CInt(Row("id")) = newId Then
                TableGridView.FocusedRowHandle = iTmp
                Exit While
            End If
            iTmp += 1
        End While
    End Sub

    ' Сделать копию актуальной версии документа
    Private Sub DataDocCopyBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataDocCopyBarButtonItem.ItemClick
        Dim doc As String = Nothing
        Dim dateB As Date = Nothing
        Dim dateE As Date = Nothing
        Dim sortId As Integer = 0
        Dim startId As Integer = 0
        Using F As New DocCopyForm
            If F.ShowDialog <> DialogResult.OK Then Exit Sub
            doc = ToText(F.DocTextEdit.Text)
            dateB = CDate(F.DateBDateEdit.EditValue)
            dateE = CDate(F.DateEDateEdit.EditValue)
        End Using
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Using TmpTable As New DataTable
            '
            ' Загрузка данных из таблицы tLaw базы данных во временную таблицу
            '
            TmpTable.Load(ControlTable.ExecuteReader( _
                          String.Format("SELECT * FROM tLaw WHERE doc LIKE '{0}%' AND dateB <= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND dateE > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", doc, Date.Today)))
            If TmpTable.Rows.Count = 0 Then
                Cprp.DxCommon.Messages.ShowWarning("Данные в таблице tLaw базы данных не найдены.")
                Cprp.DxCommon.WaitForm.Close()
                Exit Sub
            End If
            ViewTableBarButtonItem.PerformClick()
            TableGridView.BeginDataUpdate()
            '
            ' Определение sortId и startId
            '
            Using V As New DataView(TmpTable) With {.Sort = "sortId"}
                sortId = CInt(V(V.Count - 1)("sortId")) ' последний sortId в исходном документе
            End Using
            startId = CInt(ControlTable.ExecuteScalar("SELECT ISNULL(MAX(id), 0) FROM tLaw")) + 1
            '
            ' Добавление новых строк в ControlTable
            '
            ControlTable.Rows.Clear()
            For Each Row As DataRow In TmpTable.Rows
                ControlTable.Rows.Add(New Object() { _
                                      CInt(Row("id")) + startId, _
                                      If(IsDBNull(Row("parentId")), DBNull.Value, CInt(Row("parentId")) + startId), _
                                      sortId, _
                                      Row("pos"), _
                                      Row("description"), _
                                      Row("tnved"), _
                                      Row("tnved2"), _
                                      Row("cas"), _
                                      Row("doc"), _
                                      Row("letter"), _
                                      Row("areaId"), _
                                      Row("modeId"), _
                                      Row("typeId"), _
                                      Row("lev"), _
                                      Row("isList"), _
                                      dateB, _
                                      dateE})
            Next
        End Using
        TableGridView.EndDataUpdate()
        TableGridView.MoveFirst()
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation("Операция завершена.")
    End Sub

End Class
