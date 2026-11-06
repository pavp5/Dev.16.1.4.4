Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraRichEdit.API.Native
Imports Cprp.DxData.Common
''' <summary>
''' Элемент управления "АПУ"
''' </summary>
Friend Class ApuUserControl : Implements IChildControl

#Region "IChildControl"

    Friend Sub CloseEditor() Implements IChildControl.CloseEDitor
        ApuTreeList.CloseEditor()
        LawTreeList.CloseEditor()
    End Sub

    Friend Sub BeginDataUpdate() Implements IChildControl.BeginDataUpdate
        ApuTreeList.CloseEditor()
        ApuTreeList.LockReloadNodes()
        LawTreeList.CloseEditor()
        LawTreeList.LockReloadNodes()
    End Sub

    Friend Sub EndDataUpdate() Implements IChildControl.EndDataUpdate
        ApuTreeList.UnlockReloadNodes()
        ApuTreeList.CollapseAll()
        ApuTreeList.MoveFirst()
        LawTreeList.UnlockReloadNodes()
        LawTreeList.CollapseAll()
        LawTreeList.MoveFirst()
    End Sub

#End Region


    ''' <summary>
    ''' Показать пункт списка в редакторе
    ''' </summary>
    ''' <param name="lawId">ID пункта списка</param>
    Friend Event LawShow(lawId As Integer)


    ''' <summary>
    ''' Источник данных АПУ
    ''' </summary>
    Private Ds As ApuDataSet = Nothing

    ''' <summary>
    ''' Представление таблицы классификатора
    ''' </summary>
    Private ApuView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Ds">Источник данных АПУ</param>
    Friend Sub New(ByRef Ds As ApuDataSet)
        InitializeComponent()
        Me.Ds = Ds
        ApuView = New DataView(Me.Ds.ApuTable)
        ApuTreeList.DataSource = ApuView
        SortIdApuTreeListColumn.SortIndex = 0
        LawTreeList.DataSource = Me.Ds.LawTable
        AlphabetBarCheckItem.Checked = True
        SortIdLawTreeListColumn.SortIndex = 0
    End Sub


    ' Показать / скрыть алфавит
    Private Sub AlphabetBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AlphabetBarCheckItem.CheckedChanged
        ApuTreeList.LockReloadNodes()
        ApuView.RowFilter = If(AlphabetBarCheckItem.Checked, "id > 0", "parentId > 0")
        ApuTreeList.UnlockReloadNodes()
    End Sub

    ' Создать новый АПУ
    Private Sub ApuCreateBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ApuCreateBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Создать новый АПУ на основе таблицы контрольных списков?") <> Windows.Forms.DialogResult.Yes Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        BeginDataUpdate()
        Try
            Me.Ds.ApuCreate(Me.ParentForm)
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            EndDataUpdate()
        End Try
    End Sub

    ' Свернуть все пункты
    Private Sub CollapseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CollapseBarButtonItem.ItemClick
        ApuTreeList.CollapseAll()
        ApuTreeList.MoveFirst()
    End Sub

    ' Перейти на уровень выше в дереве АПУ
    Private Sub LevelUpBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LevelUpBarButtonItem.ItemClick
        If ApuTreeList.FocusedNode Is Nothing Then Exit Sub
        If ApuTreeList.FocusedNode.ParentNode Is Nothing Then Exit Sub
        ApuTreeList.FocusedNode = ApuTreeList.FocusedNode.ParentNode
    End Sub

    ' Перейти на уровень ниже в дереве АПУ
    Private Sub LevelDownBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LevelDownBarButtonItem.ItemClick
        If ApuTreeList.FocusedNode Is Nothing Then Exit Sub
        If ApuTreeList.FocusedNode.Nodes.Count = 0 Then Exit Sub
        ApuTreeList.FocusedNode = ApuTreeList.FocusedNode.Nodes(0)
    End Sub

    ' Развернуть все
    Private Sub ExpandBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpandBarButtonItem.ItemClick
        'Dim N As TreeListNode = ApuTreeList.FocusedNode
        'If Not N Is Nothing Then N.ExpandAll()
        ApuTreeList.ExpandAll()
    End Sub

    Private Sub FindRepositoryItemButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemButtonEdit.EditValueChanging
        ApuTreeList.ApplyFindFilter(ToText(e.NewValue))
    End Sub

    ' Поиск вверх и вниз по тексту АПУ
    Private Sub FindRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindRepositoryItemButtonEdit.ButtonClick
        If ApuTreeList.FocusedNode Is Nothing Then Exit Sub
        If Not IsText(ApuTreeList.FindFilterText) Then Exit Sub
        Dim iTmp As Integer = 0
        Select Case e.Button.Index
            Case 0  ' поиск вниз
                iTmp = Ds.ApuTable.FindNextIdByText(CInt(CType(ApuTreeList.GetDataRecordByNode(ApuTreeList.FocusedNode), DataRowView)("id")), ApuTreeList.FindFilterText)
            Case 1  ' поиск вверх
                iTmp = Ds.ApuTable.FindPrevIdByText(CInt(CType(ApuTreeList.GetDataRecordByNode(ApuTreeList.FocusedNode), DataRowView)("id")), ApuTreeList.FindFilterText)
            Case 2  ' очистить поле поиска
                FindBarEditItem.EditValue = Nothing
                Exit Sub
        End Select
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = ApuTreeList.FindNodeByKeyID(iTmp)
        If N Is Nothing Then
            Cprp.DxCommon.Messages.ShowInformation("Дальше нет пунктов, содержащих указанный текст.")
        Else
            N.ExpandAll()
            ApuTreeList.FocusedNode = N
            ApuTreeList.Focus()
        End If
    End Sub

    ' Показать связанные пункты контрольных списков
    Private Sub LawShowBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LawShowBarButtonItem.ItemClick
        If ApuTreeList.FocusedNode Is Nothing Then Exit Sub
        LawTreeList.CloseEditor()
        LawTreeList.LockReloadNodes()
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Ds.CheckApuLaw(CInt(ApuTreeList.FocusedNode.GetValue("id")))
        LawTreeList.UnlockReloadNodes()
        LawTreeList.CollapseAll()
        LawTreeList.FocusedNode = LawTreeList.Nodes(0)
        Dim iTmp As Integer = Ds.LawTable.GetNextSelId(CInt(LawTreeList.FocusedNode.GetValue("id")))
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = LawTreeList.FindNodeByKeyID(iTmp)
        If Not N Is Nothing Then
            N.ExpandAll()
            LawTreeList.FocusedNode = N
            LawTreeList.Focus()
        End If
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ' Показать следующий связанный пункт контрольного списка
    Private Sub LawNextBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LawNextBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        Dim iTmp As Integer = Ds.LawTable.GetNextSelId(CInt(LawTreeList.FocusedNode.GetValue("id")))
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = LawTreeList.FindNodeByKeyID(iTmp)
        If Not N Is Nothing Then
            N.ExpandAll()
            LawTreeList.FocusedNode = N
            LawTreeList.Focus()
        Else
            Cprp.DxCommon.Messages.ShowInformation("Дальше нет связанных пунктов.")
        End If
    End Sub

    ' Показать предыдущий связанный пункт контрольного списка
    Private Sub LawPrevBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LawPrevBarButtonItem.ItemClick
        If LawTreeList.FocusedNode Is Nothing Then Exit Sub
        Dim iTmp As Integer = Ds.LawTable.GetPrevSelId(CInt(LawTreeList.FocusedNode.GetValue("id")))
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = LawTreeList.FindNodeByKeyID(iTmp)
        If Not N Is Nothing Then
            N.ExpandAll()
            LawTreeList.FocusedNode = N
            LawTreeList.Focus()
        Else
            Cprp.DxCommon.Messages.ShowInformation("Дальше нет связанных пунктов.")
        End If
    End Sub

    ' Показать пункт списка в редакторе
    Private Sub LawEditBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LawEditBarButtonItem.ItemClick
        If Not LawTreeList.FocusedNode Is Nothing Then
            RaiseEvent LawShow(CInt(LawTreeList.FocusedNode.GetValue("id")))
        End If
    End Sub

    ' Загрузить АПУ из файла Microsoft Word
    Private Sub ApuFromWordBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ApuFromWordBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        '
        ' Выбор загрузочного файла
        '
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.Filter = "Файл Microsoft Word 97-2003 (*.doc)|*.doc|Файл Microsoft Word (*.docx)|*.docx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName.ToLower
        End Using
        '
        ' Загрузка данных
        '
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        BeginDataUpdate()
        Dim formCaption As String = Me.ParentForm.Capture
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Try
            '
            ' Открытие документа Word
            '
            If Not (sTmp Like "*.docx" OrElse sTmp Like "*.doc") Then
                Throw New Exception("Тип загрузочного файла не определен.")
            End If
            If sTmp Like "*.docx" Then
                R.LoadDocument(sTmp, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Else
                R.LoadDocument(sTmp, DevExpress.XtraRichEdit.DocumentFormat.Doc)
            End If
            '
            ' Проверка наличия таблицы в документе
            '
            If R.Document.Tables.Count = 0 Then Throw New Exception("В документе отсутствуют таблицы.")
            '
            ' Загрузка данных из Таблицы[0] документа
            '
            Ds.ApuLawTable.Rows.Clear()
            Ds.ApuTable.Rows.Clear()
            Dim Row As DataRow = Nothing
            Dim lev0Id As Integer = 0
            Dim lev1Id As Integer = 0
            Dim lev2Id As Integer = 0
            Dim lev3Id As Integer = 0
            Dim lev4Id As Integer = 0
            Dim lev5Id As Integer = 0
            Dim lev6Id As Integer = 0
            Dim lev7Id As Integer = 0
            Dim lev8Id As Integer = 0
            Dim lev9Id As Integer = 0
            With R.Document.Tables(0)
                For i As Integer = 0 To .Rows.Count - 1
                    Me.ParentForm.Text = String.Format("АПУ - Загрузка строк ({0} из {1})", i + 1, .Rows.Count)
                    Application.DoEvents()
                    sTmp = ToText(R.Document.GetText(.Cell(i, 0).ContentRange))
                    If Not IsText(sTmp) OrElse Not IsNumeric(sTmp) Then Continue For
                    Row = Ds.ApuTable.NewRow
                    Row("id") = Ds.ApuTable.Rows.Count + 1
                    Row("sortId") = Row("id")
                    If CInt(sTmp) = 1 Then
                        Row("caption") = DbText(R.Document.GetText(.Cell(i, 1).ContentRange))
                    Else
                        Row("caption") = DbText(R.Document.GetText(.Cell(i, 2).ContentRange))
                    End If
                    If IsDBNull(Row("caption")) Then Continue For
                    Row("strPos") = DbText(R.Document.GetText(.Cell(i, .Rows(i).Cells.Count - 1).ContentRange))
                    Select Case CInt(sTmp)
                        Case 1
                            lev0Id = CInt(Row("id"))
                            Exit Select
                        Case 2
                            Row("parentId") = lev0Id
                            lev1Id = CInt(Row("id"))
                            Exit Select
                        Case 3
                            Row("parentId") = lev1Id
                            lev2Id = CInt(Row("id"))
                            Exit Select
                        Case 4
                            Row("parentId") = lev2Id
                            lev3Id = CInt(Row("id"))
                            Exit Select
                        Case 5
                            Row("parentId") = lev3Id
                            lev4Id = CInt(Row("id"))
                            Exit Select
                        Case 6
                            Row("parentId") = lev4Id
                            lev5Id = CInt(Row("id"))
                            Exit Select
                        Case 7
                            Row("parentId") = lev5Id
                            lev6Id = CInt(Row("id"))
                            Exit Select
                        Case 8
                            Row("parentId") = lev6Id
                            lev7Id = CInt(Row("id"))
                            Exit Select
                        Case 9
                            Row("parentId") = lev7Id
                            lev8Id = CInt(Row("id"))
                            Exit Select
                        Case 10
                            Row("parentId") = lev8Id
                            lev9Id = CInt(Row("id"))
                            Exit Select
                        Case Else
                            Exit For
                    End Select
                    Ds.ApuTable.Rows.Add(Row)
                Next
            End With
            R.Dispose()
            '
            ' Обработка пунктов списков
            '
            Dim sTmp1 As String = Nothing
            For i As Integer = 0 To Ds.ApuTable.Rows.Count - 1
                Me.ParentForm.Text = String.Format("Обработка пунктов списков ({0} из {1})", i + 1, Ds.ApuTable.Rows.Count)
                Application.DoEvents()
                sTmp = ToText(Ds.ApuTable(i)("strPos"))
                If Not IsText(sTmp) Then
                    Ds.ApuTable(i)("strPos") = DBNull.Value
                    Continue For
                End If
                sTmp1 = Nothing
                For Each c As Char In sTmp
                    If c Like "[0123456789.;БВДИНОРСХЧЯ-]" Then sTmp1 &= c
                Next
                If IsText(sTmp1) Then
                    sTmp1 = sTmp1.Replace("ДН", "/ДН")
                    sTmp1 = sTmp1.Replace("Ч", "/Ч")
                    sTmp1 = sTmp1.Replace("В/Ч", "/ВЧ")
                    sTmp1 = sTmp1.Replace("ДННБ", "НБ")
                    sTmp1 = sTmp1.Replace("НБ", "/НБ")
                    sTmp1 = sTmp1.Replace("ЯО", "/ЯО")
                    sTmp1 = sTmp1.Replace("ХО", "/ХО")
                    sTmp1 = sTmp1.Replace("РО", "/РО")
                    sTmp1 = sTmp1.Replace("БО", "/БО")
                    sTmp1 = sTmp1.Replace("ИС", "/ИС")
                    Ds.ApuTable(i)("strPos") = sTmp1
                Else
                    Ds.ApuTable(i)("strPos") = DBNull.Value
                End If
            Next
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            If Not R Is Nothing Then R.Dispose()
            Me.ParentForm.Text = formCaption
            EndDataUpdate()
        End Try
    End Sub

    ' Связать пункты АПУ с пунктами списков через строки с номерами пунктов
    Private Sub ApuLawPosLinkBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ApuLawPosLinkBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Связать пункты АПУ с пунктами списков через строки с номерами пунктов?") <> DialogResult.Yes Then Exit Sub
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Dim iTmp As Integer = 0
        Dim arrSection() As String = Nothing
        Dim arrPos() As String = Nothing
        Dim doc As String = Nothing
        Dim startPos As String = Nothing
        Dim endPos As String = Nothing
        Dim startId As String = Nothing
        Dim endId As String = Nothing
        Dim formCaption As String = Me.ParentForm.Text
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            Using V As New DataView(Ds.LawTable) With {.Sort = "id"}
                For i As Integer = 0 To Ds.ApuTable.Rows.Count - 1
                    Me.ParentForm.Text = String.Format("Связи АПУ со Списками ({0} из {1})", i + 1, Ds.ApuTable.Rows.Count - 1)
                    Application.DoEvents()
                    sTmp = ToText(Ds.ApuTable(i)("strPos"))
                    If Not IsText(sTmp) Then Continue For
                    '
                    ' Цикл по массиву разделов (категорий)
                    '
                    arrSection = sTmp.Split(New Char() {"/"}, StringSplitOptions.RemoveEmptyEntries)
                    For Each sTmp In arrSection
                        '
                        ' Шифр раздела (категории)
                        '
                        doc = Nothing
                        If sTmp Like "ДН*" Then
                            doc = "1030.0001."
                        ElseIf sTmp Like "ВЧ*" Then
                            doc = "1030.0003."
                        ElseIf sTmp Like "Ч*" Then
                            doc = "1030.0002."
                        ElseIf sTmp Like "НБ*" Then
                            doc = "1030.0004."
                        ElseIf sTmp Like "ЯО*" Then
                            doc = "1050."
                        ElseIf sTmp Like "ХО*" Then
                            doc = "1070."
                        ElseIf sTmp Like "РО*" Then
                            doc = "1090."
                        ElseIf sTmp Like "БО*" Then
                            doc = "1110."
                        ElseIf sTmp Like "ИС*" Then
                            doc = "1130."
                        Else
                            Continue For
                        End If
                        '
                        ' Цикл по массиву номеров пунктов текущего раздела (категории)
                        '
                        sTmp1 = If(doc = "1030.0002.", sTmp.Substring(1), sTmp.Substring(2))
                        arrPos = sTmp1.Split(New Char() {";"}, StringSplitOptions.RemoveEmptyEntries)
                        For Each sTmp1 In arrPos
                            '
                            ' Номера первого и последнего пунктов диапазона номеров
                            '
                            iTmp = InStr(sTmp1, "-")
                            If iTmp > 0 Then
                                startPos = DelPoint(sTmp1.Substring(0, iTmp - 1))
                                endPos = DelPoint(sTmp1.Substring(iTmp))
                            Else
                                startPos = DelPoint(sTmp1)
                                endPos = startPos
                            End If
                            '
                            ' Перенумерование пунктов 4-го раздела ДН
                            '
                            If doc = "1030.0004." Then
                                If startPos Like "10.*" Then startPos = "1" & startPos.Substring(2)
                                If endPos Like "10." Then endPos = "1" & endPos.Substring(2)
                                If startPos Like "11.*" Then startPos = "2" & startPos.Substring(2)
                                If endPos Like "11." Then endPos = "2" & endPos.Substring(2)
                                If startPos Like "12.*" Then startPos = "3" & startPos.Substring(2)
                                If endPos Like "12." Then endPos = "3" & endPos.Substring(2)
                                If startPos Like "13.*" Then startPos = "4" & startPos.Substring(2)
                                If endPos Like "13." Then endPos = "4" & endPos.Substring(2)
                                If startPos Like "14.*" Then startPos = "5" & startPos.Substring(2)
                                If endPos Like "14." Then endPos = "5" & endPos.Substring(2)
                                If startPos Like "15.*" Then startPos = "6" & startPos.Substring(2)
                                If endPos Like "15." Then endPos = "6" & endPos.Substring(2)
                                If startPos Like "16.*" Then startPos = "7" & startPos.Substring(2)
                                If endPos Like "16." Then endPos = "7" & endPos.Substring(2)
                                If startPos Like "17.*" Then startPos = "8" & startPos.Substring(2)
                                If endPos Like "17." Then endPos = "8" & endPos.Substring(2)
                                If startPos Like "18.*" Then startPos = "9" & startPos.Substring(2)
                                If endPos Like "18." Then endPos = "9" & endPos.Substring(2)
                            End If
                            '
                            ' ID первого и последнего пунктов диапазона номеров
                            '
                            startId = 0
                            endId = 0
                            V.RowFilter = String.Format("typeId = 1 AND doc LIKE '{0}%' AND (pos = '{1}.' OR pos = '{1}')", doc, startPos)
                            If V.Count > 0 Then startId = CInt(V(0)("id"))
                            V.RowFilter = String.Format("typeId = 1 AND doc LIKE '{0}%' AND (pos = '{1}.' OR pos = '{1}')", doc, endPos)
                            If V.Count > 0 Then endId = CInt(V(0)("id"))
                            If startId = 0 Then startId = endId
                            If endId = 0 Then endId = startId
                            If endId = 0 Then Continue For
                            '
                            ' Создание связей
                            '
                            V.RowFilter = String.Format("typeId = 1 AND id >= {0} AND id <= {1}", startId, endId)
                            For Each VRow As DataRowView In V
                                If Ds.ApuLawTable.Rows.Find(New Object() {Ds.ApuTable(i)("id"), VRow("id")}) Is Nothing Then
                                    Ds.ApuLawTable.Rows.Add(New Object() {Ds.ApuTable(i)("id"), VRow("id")})
                                End If
                            Next
                        Next
                    Next
                Next
            End Using
            '
            ' Перечитывание поля АПУ таблицы списков
            '
            Using V As New DataView(Ds.ApuLawTable)
                For i As Integer = 0 To Ds.LawTable.Rows.Count - 1
                    Me.ParentForm.Text = String.Format("Перечитывание поля АПУ таблицы Списков ({0} из {1})", i + 1, Ds.LawTable.Rows.Count)
                    Application.DoEvents()
                    sTmp = Nothing
                    V.RowFilter = String.Format("lawId = {0}", CInt(Ds.LawTable(i)("id")))
                    For Each VRow As DataRowView In V
                        sTmp = String.Format("{0}{1}={2}", sTmp, vbCrLf, Ds.ApuTable.GetFullCaption(CInt(VRow("apuId"))))
                    Next
                    If IsText(sTmp) Then Ds.LawTable(i)("apu") = sTmp.Substring(3)
                Next
            End Using
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            Me.ParentForm.Text = formCaption
        End Try
    End Sub

End Class
