Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления для работы с нормативными документами
''' </summary>
''' <remarks></remarks>
Public Class LawUserControl

    ' Открытое соединение с базой данных
    Private Connection As SqlConnection = Nothing

    ' Источник данных нормативных документов
    Private DS As LawDataSet = Nothing

    ' Представления выделенного пункта
    Private PosView As DataView = Nothing       ' Дерево пункта
    Private TnvedView As DataView = Nothing     ' Коды ТН ВЭД
    Private CasView As DataView = Nothing       ' Номера CAS
    Private LinkView As DataView = Nothing      ' Ссылки

    ' Заголовок приложения
    Private Const APP_NAME As String = "Нормативные документы"


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        Me.Connection = Connection
        '
        ' DS
        '
        DS = New Cprp.DxData.Law.LawDataSet
        DS.DataLoad(Connection, Date.Now, True, True, True, True, True, False)
        '
        ' Представления выделенного пункта
        '
        PosView = New DataView(DS.LawTable)
        PosView.Sort = "sortId"
        PosView.RowFilter = "id IS NULL"
        TnvedView = New DataView(DS.TnvedTable)
        TnvedView.Sort = "tnved"
        TnvedView.RowFilter = "lawId IS NULL"
        CasView = New DataView(DS.CasTable)
        CasView.Sort = "cas"
        CasView.RowFilter = "lawId IS NULL"
        LinkView = New DataView(DS.LinkTable)
        LinkView.Sort = "linkCaption"
        LinkView.RowFilter = "lawId IS NULL"
        '
        ' LawTreeList, PosTreeList, TnvedGridControl, CasGridControl, LinkGridControl 
        '
        LawTreeList.DataSource = DS.LawTable
        SortIdTreeListColumn.SortIndex = 0
        PosTreeList.DataSource = PosView
        TnvedGridControl.DataSource = TnvedView
        CasGridControl.DataSource = CasView
        LinkGridControl.DataSource = LinkView
        '
        ' FindTextLayoutControlGroup 
        '
        FindTextLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        ' ActDateBarButtonItem
        '
        ActDateBarButtonItem.Caption = String.Format("{0:dd.MM.yyyy}", Date.Now)

    End Sub

#Region "Главное меню"

    ' Свернуть дерево документов
    Private Sub CollapseAllNavBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CollapseAllNavBarButtonItem.ItemClick
        LawTreeList.CollapseAll()
    End Sub

    ' Перейти на уровень вверх в дереве документов
    Private Sub LevelUpNavBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LevelUpNavBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        If LawTreeList.FocusedNode.ParentNode Is Nothing Then Exit Sub
        LawTreeList.FocusedNode = LawTreeList.FocusedNode.ParentNode
    End Sub

    ' Перейти на уровень вниз в дереве документов
    Private Sub LevelDownNavBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LevelDownNavBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        If Not LawTreeList.FocusedNode.HasChildren Then Exit Sub
        LawTreeList.FocusedNode = LawTreeList.FocusedNode.Nodes(0)
    End Sub

    ' Расширенный поиск
    Private Sub FindFindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindFindBarButtonItem.ItemClick
        ' Определение критериев поиска
        Dim rowFilter As String = Nothing
        Dim word As String = Nothing
        Dim tnved As String = Nothing
        Dim cas As String = Nothing
        Dim iTmp As Integer = 0
        With New FindForm
            If .ShowDialog <> DialogResult.OK Then Exit Sub
            word = Trim(.FindWordTextEdit.Text)
            tnved = Trim(.FindTnvedTextEdit.Text)
            cas = Trim(.FindCasTextEdit.Text)
            If .AreaExContCheckEdit.Checked Then
                rowFilter = String.Format("{0} AND areaId = {1}", rowFilter, CInt(Cprp.DxData.AreaEnum.isExcont))
            ElseIf .AreaMilitaryCheckEdit.Checked Then
                rowFilter = String.Format("{0} AND areaId = {1}", rowFilter, CInt(Cprp.DxData.AreaEnum.isMilitary))
            ElseIf .AreaCustomUnionCheckEdit.Checked Then
                rowFilter = String.Format("{0} AND areaId = {1}", rowFilter, CInt(Cprp.DxData.AreaEnum.isCustom))
            End If
            If .ModeExportCheckEdit.Checked Then
                rowFilter = String.Format("{0} AND (modeId = {1} OR modeId = {2})", rowFilter, CInt(Cprp.DxData.ModeEnum.isExport), CInt(Cprp.DxData.ModeEnum.isBoth))
            ElseIf .ModeImportCheckEdit.Checked Then
                rowFilter = String.Format("{0} AND (modeId = {1} OR modeId = {2})", rowFilter, CInt(Cprp.DxData.ModeEnum.isImport), CInt(Cprp.DxData.ModeEnum.isBoth))
            End If
        End With
        Cprp.DxCommon.WaitForm.Show()
        If C2.IsText(rowFilter) Then rowFilter = rowFilter.Substring(5)
        LawTreeList.BeginUpdate()
        DS.FindClear()
        ' Поиск
        If Not String.IsNullOrWhiteSpace(word) Then DS.FindByWord(word, rowFilter)
        If Not String.IsNullOrWhiteSpace(tnved) Then DS.FindByTnved(tnved, rowFilter)
        If Not String.IsNullOrWhiteSpace(cas) Then DS.FindByCas(cas, rowFilter)
        LawTreeList.EndUpdate()
        ' Раскрытие найденных и отмеченных пунктов в дереве документов
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = Nothing
        Using V As New DataView(DS.LawTable)
            V.Sort = DS.LawTable.DefaultView.Sort
            V.RowFilter = "isFindTnved = True OR isFindCas = True OR isFindWord = True OR isSel = True"
            If V.Count > 0 Then LawTreeList.CollapseAll()
            For i As Integer = V.Count - 1 To 0 Step -1
                N = LawTreeList.FindNodeByKeyID(V(i)("id"))
                If Not N Is Nothing Then
                    N.ExpandAll()
                    LawTreeList.FocusedNode = N
                End If
            Next
        End Using
        ' Отображение результатов поиска
        iTmp = DS.FindCount
        FindCountBarStaticItem.Caption = String.Format("Найдено: {0}", iTmp)
        SelCountBarStaticItem.Caption = String.Format("Выбрано: {0}", DS.SelectionCount)
        Cprp.DxCommon.WaitForm.Close()
        If iTmp = 0 Then
            Cprp.DxCommon.Messages.ShowInformation("По указанным критериям поиска ничего не найдено.", "Результаты поиска")
        Else
            Cprp.DxCommon.Messages.ShowInformation(String.Format("Найдено пунктов: {0}.", iTmp), "Результаты поиска")
        End If
    End Sub

    ' Поиск в тексте документов (главное меню)
    Private Sub TextFindBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TextFindBarCheckItem.CheckedChanged
        If TextFindBarCheckItem.Checked Then
            FindTextLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always
            FindTextButtonEdit.Focus()
        Else
            FindTextLayoutControlGroup.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
            LawTreeList.ApplyFindFilter(Nothing)
            LawTreeList.Focus()
        End If
    End Sub

    ' Отметить пункт / снять отметку
    Private Sub CheckSelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CheckSelBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        With CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView)
            If CType(.Item("typeId"), Cprp.DxData.Law.TypeEnum) = Cprp.DxData.Law.TypeEnum.IsLevel1 Then Exit Sub ' заголовок предметной области
            LawTreeList.BeginUpdate()
            .BeginEdit()
            .Item("isSel") = Not CBool(.Item("isSel"))
            .EndEdit()
            LawTreeList.EndUpdate()
        End With
        SelCountBarStaticItem.Caption = String.Format("Выбрано: {0}", DS.SelectionCount)
    End Sub

    ' Перейти к предыдущему выделенному пункту
    Private Sub PrevSelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrevSelBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        Dim iTmp As Integer = DS.SelectionPrevId(CInt(CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView)("id")))
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = LawTreeList.FindNodeByKeyID(iTmp)
        If N Is Nothing Then
            Cprp.DxCommon.Messages.ShowInformation("Дальше нет отмеченных пунктов.", APP_NAME)
        Else
            N.ExpandAll()
            LawTreeList.FocusedNode = N
        End If
    End Sub

    ' Перейти к следующему выделенному пункту
    Private Sub NextSelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NextSelBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        Dim iTmp As Integer = DS.SelectionNextId(CInt(CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView)("id")))
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = LawTreeList.FindNodeByKeyID(iTmp)
        If N Is Nothing Then
            Cprp.DxCommon.Messages.ShowInformation("Дальше нет отмеченных пунктов.", APP_NAME)
        Else
            N.ExpandAll()
            LawTreeList.FocusedNode = N
        End If
    End Sub

    ' Снять отметки со всех пунктов
    Private Sub ClearSelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ClearSelBarButtonItem.ItemClick
        If DS.SelectionCount = 0 Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Снять отметки со всех пунктов?", APP_NAME) <> DialogResult.Yes Then Exit Sub
        LawTreeList.BeginUpdate()
        DS.SelectionClear()
        LawTreeList.EndUpdate()
        SelCountBarStaticItem.Caption = String.Format("Выбрано: {0}", DS.SelectionCount)
    End Sub

    ' Экспорт дерева выбранных пунктов в Microsoft Word
    Private Sub ExportSelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportSelBarButtonItem.ItemClick
        If DS.SelectionCount = 0 Then
            Cprp.DxCommon.Messages.ShowWarning("Отмеченные пункты отсутствуют.", APP_NAME)
            Exit Sub
        End If
        '
        ' Выбор файла для сохранения данных
        '
        Dim filePath As String = Nothing
        Dim iTmp As Integer = 0
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            'Dlg.FileName = String.Format("Выборка из нормативных документов ({0:dd-MM-yyyy HH-mm})", Date.Now)
            Dlg.FileName = "Выборка из нормативных документов"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx|Файл Microsoft Word 97-2003 (*.doc)|*.doc"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        '
        ' Документ
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Cprp.DxCommon.WaitForm.Show()
        Try
            '
            ' Инициализация документа шаблоном справки
            '
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.OpenXmlBytes = My.Resources.ref_template
            R.Document.BeginUpdate()
            '
            ' Заполнение шаблона данными
            '
            Using V As DataView = DS.SelectionTreeDataView
                V.Sort = "doc, id"
                With R.Document.Tables(0)
                    For i As Integer = 0 To V.Count - 1
                        .Rows.Append()
                        Select Case CType(V(i)("typeId"), Cprp.DxData.Law.TypeEnum)
                            Case Cprp.DxData.Law.TypeEnum.IsComment
                                ' Примечание
                                R.Document.InsertHtmlText(.Cell(i, 1).Range.Start, String.Format("<i>{0}</i>", V(i)("description").ToString.Replace(vbCrLf, "1234567890")))
                                R.Document.ReplaceAll("1234567890", vbCrLf, DevExpress.XtraRichEdit.API.Native.SearchOptions.None, .Cell(i, 1).Range)
                            Case Cprp.DxData.Law.TypeEnum.IsLevel1
                                ' Заголовок предметной области
                                .MergeCells(.Cell(i, 0), .Cell(i, 1))
                                R.Document.InsertHtmlText(.Cell(i, 0).Range.Start, String.Format("<span style='color:#ff0000'>{0}</span>", V(i)("description").ToString))
                                R.Document.Paragraphs.Get(.Cell(i, 0).Range.Start).Alignment = DevExpress.XtraRichEdit.API.Native.ParagraphAlignment.Center
                            Case Cprp.DxData.Law.TypeEnum.IsLevel2
                                ' Заголовок нормативного документа
                                .MergeCells(.Cell(i, 0), .Cell(i, 1))
                                R.Document.InsertText(.Cell(i, 0).Range.Start, V(i)("description").ToString)
                                R.Document.Paragraphs.Get(.Cell(i, 0).Range.Start).SpacingBefore = 25
                            Case Else
                                If CBool(V(i)("isSel")) Then
                                    ' Выбранный пункт
                                    R.Document.InsertHtmlText(.Cell(i, 0).Range.Start, String.Format("<b>{0}</b>", V(i)("pos").ToString))
                                    R.Document.InsertHtmlText(.Cell(i, 1).Range.Start, String.Format("<b>{0}</b>", V(i)("description").ToString.Replace(vbCrLf, "1234567890")))
                                    R.Document.ReplaceAll("1234567890", vbCrLf, DevExpress.XtraRichEdit.API.Native.SearchOptions.None, .Cell(i, 1).Range)
                                Else
                                    R.Document.InsertText(.Cell(i, 0).Range.Start, V(i)("pos").ToString)
                                    R.Document.InsertText(.Cell(i, 1).Range.Start, V(i)("description").ToString)
                                End If
                        End Select
                    Next
                    .Rows.LastOrDefault.Delete()
                End With
            End Using
            R.Document.EndUpdate()
            '
            ' Сохранение документа в файл
            '
            If filePath Like "*.docx" Then
                R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Else
                R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.Doc)
            End If
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
            Exit Sub
        Finally
            If Not R Is Nothing Then R.Dispose()
        End Try
        '
        ' Открытие файла внешней программой
        '
        If Cprp.DxCommon.Messages.ShowQuestion("Данные выгружены в файл. Открыть файл?") = DialogResult.Yes Then
            Try
                Using P As New Process
                    P.StartInfo.FileName = Trim(filePath)
                    P.StartInfo.Verb = "Open"
                    P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    P.Start()
                End Using
            Catch ex As Exception
                Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
            End Try
        End If
    End Sub

    ' Поиск вниз и вверх по тексту документов
    Private Sub FindTextButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindTextButtonEdit.ButtonClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        Dim text As String = C2.ToText(FindTextButtonEdit.Text)
        If String.IsNullOrWhiteSpace(text) Then Exit Sub
        LawTreeList.ApplyFindFilter(text)
        Dim iTmp As Integer = If(e.Button.Index = 0, _
            DS.FindNextIdByText(CInt(CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView)("id")), text), _
            DS.FindPrevIdByText(CInt(CType(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode), DataRowView)("id")), text))
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = LawTreeList.FindNodeByKeyID(iTmp)
        If N Is Nothing Then
            Cprp.DxCommon.Messages.ShowInformation("Дальше нет пунктов, содержащих указанный текст.", APP_NAME)
        Else
            N.ExpandAll()
            LawTreeList.FocusedNode = N
            LawTreeList.Focus()
        End If
    End Sub

    Private Sub ActDateBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ActDateBarButtonItem.ItemClick
        Dim sDate As String = InputBox("Укажите дату актуализации документов:", "Дата актуализации", ActDateBarButtonItem.Caption)
        If Not IsDate(sDate) Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        LawTreeList.LockReloadNodes()
        DS.DataLoad(Connection, CDate(sDate), True, True, True, True, True, False)
        LawTreeList.UnlockReloadNodes()
        If LawTreeList.Nodes.Count > 0 Then
            LawTreeList.CollapseAll()
            LawTreeList.Nodes(0).Expanded = True
            LawTreeList.MoveFirst()
        End If

        ActDateBarButtonItem.Caption = String.Format("{0:dd.MM.yyyy}", CDate(sDate))
        Cprp.DxCommon.WaitForm.Close()
    End Sub

#End Region

    ' Обновление представлений кодов ТН ВЭД, номеров CAS, ссылок на связанные пункты
    ' Формирование дерева выделенного пункта
    Private Sub ControlTreeList_AfterFocusNode(ByVal sender As Object, ByVal e As DevExpress.XtraTreeList.NodeEventArgs) Handles LawTreeList.AfterFocusNode
        '
        ' Id выделенного пункта
        '
        Dim lawId As Integer = -1
        If Not LawTreeList.FocusedNode Is Nothing Then
            lawId = CInt(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode)("id"))
        End If
        '
        ' Представление кодов ТН ВЭД
        '
        TnvedView.RowFilter = String.Format("lawId = {0}", lawId)
        TnvedGridView.MoveFirst()
        '
        ' Представление номеров CAS
        '
        CasView.RowFilter = String.Format("lawId = {0}", lawId)
        CasGridView.MoveFirst()
        '
        ' Представление ссылок на связанные пункты
        '
        LinkView.RowFilter = String.Format("lawId = {0}", lawId)
        LinkGridView.MoveFirst()
        '
        ' Формирование дерева выделенного пункта
        '
        Dim sTmp As String = DS.GetParentIdByChildId(lawId, False)
        If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = C2.ToStrNum(sTmp, False)
        PosView.RowFilter = String.Format("id IN ({0}, {1})", lawId, sTmp)
        PosTreeList.ExpandAll()
        PosTreeList.MoveLast()
    End Sub

    ' Запрет сворачивания дерева пункта
    Private Sub PosTreeList_BeforeCollapse(sender As Object, e As DevExpress.XtraTreeList.BeforeCollapseEventArgs) Handles PosTreeList.BeforeCollapse
        e.CanCollapse = False
    End Sub

    ' id пункта, с которого произошел переход по ссылке
    Private backId As Integer = -1

    ' Перейти по ссылке к связанному пункту
    Private Sub LinkMoveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LinkMoveBarButtonItem.ItemClick
        If LinkGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = LawTreeList.FindNodeByKeyID(LinkGridView.GetFocusedRow("linkId"))
        If Not N Is Nothing Then
            If Not LawTreeList.FocusedNode Is Nothing Then backId = CInt(LawTreeList.GetDataRecordByNode(LawTreeList.FocusedNode)("id"))
            LawTreeList.FocusedNode = N
        End If
    End Sub

    ' Вернуться к пункту, с которого произешел переход по ссылке
    Private Sub LinkBackBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LinkBackBarButtonItem.ItemClick
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = LawTreeList.FindNodeByKeyID(backId)
        If Not N Is Nothing Then
            LawTreeList.FocusedNode = N
            backId = -1
        End If
    End Sub

    ' Перейти по ссылке к связанному пункту
    Private Sub LinkGridControl_DoubleClick(sender As Object, e As EventArgs) Handles LinkGridControl.DoubleClick
        LinkMoveBarButtonItem.PerformClick()
    End Sub

    Private Sub LawTreeList_Load(sender As Object, e As EventArgs) Handles LawTreeList.Load
        If LawTreeList.Nodes.Count > 0 Then
            LawTreeList.Nodes(0).Expanded = True
            LawTreeList.MoveFirst()
        End If
    End Sub

End Class
