Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.API.Layout
Imports C2 = Cprp.DxData.Common
' ===========================================================
' Свойства и методы для работы с проектом итогового документа
' ===========================================================
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Создать проект итогового документа
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ProjectCreate()

        ' ПЕРЕМЕННЫЕ
        ' ++++++++++
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing       ' Документ
        Dim nullText As String = "{нет данных}"
        '
        ' Временная таблица для хранения выводимых данных
        '
        Dim TmpTable As New DataTable("TmpTable")
        With TmpTable.Columns
            .Add("i1", GetType(Integer))
            .Add("i2", GetType(Integer))
            .Add("i3", GetType(Integer))
            .Add("i4", GetType(Integer))
            .Add("i5", GetType(Integer))
            .Add("s1", GetType(String))
            .Add("s2", GetType(String))
            .Add("s3", GetType(String))
            .Add("s4", GetType(String))
            .Add("s5", GetType(String))
        End With

        Dim Row As DataRow, Row1 As DataRow, sTmp As String, sTmp1 As String, sTmp2 As String, iTmp As Integer, bTmp As Boolean

        ' ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        ' ++++++++++++++++++++++++
        '
        R = New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.Unit = DevExpress.Office.DocumentUnit.Document
        R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document


        ' ЗАГРУЗКА ШАБЛОНА ЗАКЛЮЧЕНИЯ И ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Загрузка шаблона заключения
        'R.Document.LoadDocument("d:\2.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ЗАПРЕТЫЗАКЛЮЧЕНИЕ2", Me.Connection)
        R.Document.BeginUpdate()

        ' Номер и дата заключения - тело документа
        PutBookmark(R.Document, "DocNum", Nothing, "{Проект}")
        PutBookmark(R.Document, "DocDate", String.Format("{0:d MMMM yyyy} г.", Date.Today), nullText)

        ' Номер и дата заключения - колонтитул
        Dim Hd As SubDocument = R.Document.Sections(0).BeginUpdateHeader
        PutBookmark(Hd, "DocNum2", Nothing, "{Проект}")
        PutBookmark(Hd, "DocDate2", String.Format("{0:dd.MM.yyyy}", Date.Today), "{00.00.0000}")
        R.Document.Sections(0).EndUpdateHeader(Hd)

        ' 2. Российский участник внешнеэкономической операции
        PutRange(R.Document.Bookmarks("RusCaption").Range, RtfSupplyRusCaption, nullText)

        ' 3. Сведения о внешнеэкономической операции
        'PutRange(R.Document.Bookmarks("SupplyDescription").Range, RtfSupplyDescription, nullText)
        PutRange(R.Document.Bookmarks("SupplyDescription").Range, C2.AddPoint(Me.ARow("supplyDescription")), nullText)

        ' 4. Вопросы, поставленные на разрешение эксперту
        PutRange(R.Document.Bookmarks("ListCaption").Range, RtfLawSection, nullText)

        ' 5. Сведения об идентифицируемых товарах и идентифицируемых продуктах научно-технической деятельности
        ' ----------------------------------------------------------------------------------------------------
        '
        ' Временная таблица с объектами экспертизы
        '
        TmpTable.Rows.Clear()
        With Me.GoodTable
            For i As Integer = 0 To .Rows.Count - 1
                Row = TmpTable.NewRow
                Row("i1") = .Rows(i)("rowNum")
                Row("s1") = .Rows(i)("nameCon")
                Row("s2") = .Rows(i)("tnved")
                Row("s3") = RtfGoodFullDescription(.Rows(i))
                TmpTable.Rows.Add(Row)
            Next
        End With
        '
        ' Объединение строк временной таблицы по одинаковым кодам ТН ВЭД и одинаковым полным описаниям
        '
        With TmpTable
            If .Rows.Count > 0 Then
                iTmp = 1
                For i As Integer = 0 To .Rows.Count - 1
                    If Not IsDBNull(.Rows(i)("i2")) Then Continue For
                    .Rows(i)("i2") = iTmp
                    sTmp = C2.ToText(.Rows(i)("s2"))
                    sTmp1 = C2.ToText(.Rows(i)("s3"))
                    For j As Integer = i + 1 To .Rows.Count - 1
                        If Not IsDBNull(.Rows(j)("i2")) Then Continue For
                        If C2.ToText(.Rows(j)("s2")) <> sTmp Then Continue For
                        If C2.ToText(.Rows(j)("s3")) <> sTmp1 Then Continue For
                        .Rows(j)("i2") = iTmp
                    Next
                    iTmp += 1
                Next
            End If
        End With
        '
        ' Вставка данных в документ
        '
        With R.Document.Tables(1)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).ContentRange.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 2).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 3).ContentRange.Start).Alignment = ParagraphAlignment.Left
            '
            ' Вставка данных
            '
            Using V As New DataView(TmpTable)
                V.Sort = "i1"
                For i As Integer = 0 To V.Count - 1
                    .Rows.Append()
                    PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(V(i)("i1")), nullText)
                    PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(V(i)("s1")), nullText)
                    If i = 0 OrElse CInt(V(i)("i2")) <> CInt(V(i - 1)("i2")) Then
                        PutRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(V(i)("s2")), nullText)
                        PutRange(.Cell(.Rows.Count - 2, 3).ContentRange, C2.ToText(V(i)("s3")), nullText)
                    End If
                Next
            End Using
            If .Rows.Count > 2 Then
                .Rows.LastOrDefault.Delete()
                ' Объединение ячеек с одинаковым техническими описаниями и кодами
                iTmp = 1
                For i As Integer = 1 To .Rows.Count - 1
                    If String.IsNullOrWhiteSpace(R.Document.GetText(.Cell(i, 2).Range)) Then
                        .MergeCells(.Cell(iTmp, 2), .Cell(i, 2))
                        .MergeCells(.Cell(iTmp, 3), .Cell(i, 3))
                    Else
                        iTmp = i
                    End If
                Next
            Else
                ' Нет данных
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 2).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 3).ContentRange, Nothing, nullText)
            End If
        End With

        ' 6. Результаты сравнительного анализа
        ' ------------------------------------
        '
        ' Если нет объектов экспертизы, или нет разделов Единого перечня, выбранных для проведения экспертизы,
        ' добавить в документ фразу об ошибке и перейти к выводам экспертизы
        '
        If Me.GoodTable.Rows.Count = 0 OrElse Me.LawCaptionTable.Rows.Count = 0 Then
            With R.Document.Tables(2)
                '
                ' Выравнивание первой строки таблицы
                '
                R.Document.Paragraphs.Get(.Cell(1, 0).Range.Start).Alignment = ParagraphAlignment.Center
                R.Document.Paragraphs.Get(.Cell(1, 1).Range.Start).Alignment = ParagraphAlignment.Left
                R.Document.Paragraphs.Get(.Cell(1, 2).Range.Start).Alignment = ParagraphAlignment.Left
                '
                ' Вывод фразы об ошибке
                '
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 2).ContentRange, Nothing, nullText)
            End With
            '
            ' Переход к выводам экспертизы
            '
            GoTo Summary
        End If
        '
        ' Временная таблица с описаниями пунктов Единого перечня и сравнительными анализами по ним
        '
        ' s1 - порядковый номер товара в списке объектов экспертизы
        ' s2 - шифр пункта, выбранного для сравнительного анализа
        ' s3 - описание пункта, выбранного для сравнительного анализа
        ' s4 - сравнительный анализ объекта экспертизы с пунктом единого перечня
        ' s5 - строка номеров объектов экспертизы с одинаковым анализом по данному пункту (для группировки)
        '
        TmpTable.Rows.Clear()
        '
        ' Представление заголовков разделов Единого перечня, выбранных для сравнительного анализа
        '
        Using V As New DataView(Me.LawDataSet.LawTable)
            sTmp = Me.LawCaptionTable.StrId
            If String.IsNullOrWhiteSpace(sTmp) Then sTmp = "0"
            V.RowFilter = String.Format("id IN ({0})", sTmp)
            '
            ' Представление исследований объектов экспертизы
            '
            Using V1 As New DataView(Me.GoodLawTable)
                '
                ' Цикл по таблице объектов экспертизы
                '
                For i As Integer = 0 To Me.GoodTable.Rows.Count - 1
                    '
                    ' Если исследование текущего объекта экспертизы не проводилось, добавить во временную таблицу сообщение об ошибке
                    '
                    If IsDBNull(Me.GoodTable(i)("studyDate")) Then
                        Row = TmpTable.NewRow
                        Row("s1") = GoodTable(i)("rowNum").ToString
                        Row("s2") = DBNull.Value
                        Row("s3") = DBNull.Value
                        Row("s4") = DBNull.Value
                        TmpTable.Rows.Add(Row)
                        Continue For
                    End If
                    '
                    ' Цикл по исследованиям текущего объекта экспертизы по разделам Единого перечня, выбранным для сравнительного анализа
                    '
                    For j As Integer = 0 To V.Count - 1
                        '
                        ' Цикл по исследованиям текущего объекта экспертизы по текущему разделу Единого перечня
                        '
                        V1.RowFilter = String.Format("goodId = {0} AND summaryId > {1}", _
                                                     CInt(Me.GoodTable(i)("id")), _
                                                     CInt(Cprp.DxData.Law.StudyIndexEnum.IsNothing))
                        bTmp = False    ' Нет пунктов, выбранных для сравнительного анализа в текущем разделе
                        For n As Integer = 0 To V1.Count - 1
                            Row1 = Me.LawDataSet.LawTable.Rows.Find(V1(n)("lawId"))
                            If Row1 Is Nothing Then Continue For
                            'If C2.ToText(Row1("doc")) <> C2.ToText(V(j)("doc")) Then Continue For
                            If Not LawDataSet.IsChildParent(CInt(Row1("id")), CInt(V(j)("id"))) Then Continue For
                            '
                            ' Добавление во временную таблицу строки с исследованием текущего объекта по текущему разделу
                            '
                            bTmp = True
                            Row = TmpTable.NewRow
                            Row("s1") = Me.GoodTable(i)("rowNum").ToString
                            Row("s2") = Row1("doc")
                            'Row("s3") = C2.ToText(Me.LawDataSet.GetRowTreeById(V1(n)("lawId"), False))
                            'Row("s3") = V1(n)("lawDescription")
                            Row("s3") = C2.ToText(Me.LawDataSet.GetRowTreeById(V1(n)("lawId"), False)).Replace(C2.ToText(Row1("posDescription")), C2.ToText(V1(n)("lawDescription")))
                            Row("s4") = V1(n)("goodDescription")
                            TmpTable.Rows.Add(Row)
                        Next
                        '
                        ' Если текущий объект в текущем разделе отсутствует, добавить запись об этом во временную таблицу
                        '
                        If Not bTmp Then
                            Row = TmpTable.NewRow
                            Row("s1") = Me.GoodTable(i)("rowNum").ToString
                            Row("s2") = V(j)("doc")
                            Row("s3") = C2.ToText(V(j)("posDescription"))
                            Row("s4") = "Описания объектов, требующих проведения сравнительного анализа, в указанном разделе Единого перечня отсутствуют"
                            TmpTable.Rows.Add(Row)
                            Continue For
                        End If
                    Next
                Next
            End Using
        End Using
        '
        ' Группировка временной таблицы по одинаковым пунктам Единого перечня и одинаковым сравнительным анализам по ним
        '
        sTmp = Nothing
        sTmp1 = Nothing
        sTmp2 = Nothing
        For i As Integer = 0 To TmpTable.Rows.Count - 1
            If Not IsDBNull(TmpTable(i)("i1")) Then Continue For
            '
            ' Формирование строки номеров объектов экспертизы с одинаковыми сравнительными анализами по текущему пункту
            '
            sTmp = C2.ToText(TmpTable(i)("s1"))
            sTmp1 = C2.ToText(TmpTable(i)("s3"))
            sTmp2 = C2.ToText(TmpTable(i)("s4"))
            For j As Integer = i + 1 To TmpTable.Rows.Count - 1
                If Not IsDBNull(TmpTable(j)("s5")) Then Continue For
                If sTmp1 <> C2.ToText(TmpTable(j)("s3")) Then Continue For
                If sTmp2 <> C2.ToText(TmpTable(j)("s4")) Then Continue For
                sTmp = String.Format("{0}{1}{2}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(TmpTable(j)("s1")))
                TmpTable(j)("i1") = 1 ' признак исключения данной строки из вывода в проект документа
            Next
            TmpTable(i)("s5") = C2.ToStrNum(sTmp, True)
            TmpTable(i)("i1") = 0
        Next
        '
        ' Вывод данных в документ
        '
        With R.Document.Tables(2)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).Range.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).Range.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 2).Range.Start).Alignment = ParagraphAlignment.Left
            '
            ' Вывод данных
            '
            Using V As New DataView(TmpTable)
                V.RowFilter = "i1 <> 1"
                V.Sort = "s5, s2, s3"
                For i As Integer = 0 To V.Count - 1
                    .Rows.Append()
                    PutRange(.Cell(i + 1, 0).ContentRange, C2.ToText(V(i)("s5")), "{!}")
                    If IsDBNull(V(i)("s2")) Then
                        PutRange(.Cell(i + 1, 1).ContentRange, Nothing, "{исследование не проводилось}")
                        PutRange(.Cell(i + 1, 2).ContentRange, Nothing, "{исследование не проводилось}")
                    Else
                        PutRange(.Cell(i + 1, 1).ContentRange, C2.ToText(V(i)("s3")), nullText)
                        PutRange(.Cell(i + 1, 2).ContentRange, C2.ToText(V(i)("s4")), nullText)
                    End If
                Next
                .Rows.LastOrDefault.Delete()
            End Using
        End With

Summary:

        ' 7. Выводы
        PutBookmark(R.Document, "Summary1", C2.AddPoint(Me.ARow("summaryText")), nullText)

        ' 8. Штам ЭП (предварительно)
        PutBookmark(R.Document, "SertNum", "-")
        PutBookmark(R.Document, "SertName", "-")
        PutBookmark(R.Document, "SertTerm", "-")

        ' Пояснения эксперта к пунктам документа
        '
        sTmp = Nothing
        For Each Row In Me.CommentTable.Rows
            sTmp = C2.ToText(Row("comment"))
            If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
            Select Case CInt(Row("id"))
                Case 10 : PutHtmlRange(R.Document.Bookmarks("P2Comment").Range, sTmp)
                Case 20 : PutHtmlRange(R.Document.Bookmarks("P3Comment").Range, sTmp)
                Case 30 : PutHtmlRange(R.Document.Bookmarks("P4Comment").Range, sTmp)
                Case 40 : PutHtmlRange(R.Document.Bookmarks("P5Comment").Range, sTmp)
                Case 50 : PutHtmlRange(R.Document.Bookmarks("P6Comment").Range, sTmp)
            End Select
        Next

        '' Приложение 1. Пункты Единого перечня, рассмотренные экспертом
        ''
        '' Инициализация источника данных нормативных документов результатами исследований товаров
        'Dim LRow As DataRow = Nothing
        'Me.LawDataSet.FindSelectionClear()
        'Using V As New DataView(Me.LawDataSet.LawTable)
        '    sTmp = Me.LawCaptionTable.StrId
        '    If String.IsNullOrWhiteSpace(sTmp) Then sTmp = "0"
        '    V.RowFilter = String.Format("id IN ({0})", sTmp)
        '    For Each VRow As DataRowView In V
        '        For Each Row In Me.GoodLawTable.Rows
        '            LRow = Me.LawDataSet.LawTable.Rows.Find(Row("lawId"))
        '            If LRow Is Nothing Then Continue For
        '            If C2.ToText(LRow("doc")) <> C2.ToText(VRow("doc")) Then Continue For
        '            If CBool(Row("isFindTnved")) Then LRow("isFindTnved") = True
        '            If CBool(Row("isFindWord")) Then LRow("isFindWord") = True
        '            If CBool(Row("isFindCas")) Then LRow("isFindCas") = True
        '            If C2.ToInt(Row("summaryId")) > 0 Then LRow("isSel") = True
        '        Next
        '    Next
        'End Using
        '' Вывод найденных и выбранных пунктов в документ
        'Using V As DataView = Me.LawDataSet.GetFindSelectionTreeDataView(True, False, False, False)
        '    V.Sort = "doc, id"
        '    With R.Document.Tables(R.Document.Tables.Count - 1)
        '        If V.Count = 0 Then
        '            .MergeCells(.Cell(0, 0), .Cell(0, 1))
        '            R.Document.InsertText(.Cell(0, 0).Range.Start, "Описания объектов, имеющих признаки сходства с объектами экспертизы, в Едином перечне не выявлены")
        '        Else
        '            For i As Integer = 0 To V.Count - 1
        '                .Rows.Append()
        '                Select Case CType(V(i)("typeId"), Cprp.DxData.Law.TypeEnum)
        '                    Case Cprp.DxData.Law.TypeEnum.IsLevel2
        '                        ' Заголовок нормативного документа
        '                        .MergeCells(.Cell(i, 0), .Cell(i, 1))
        '                        R.Document.InsertText(.Cell(i, 0).Range.Start, V(i)("posDescription").ToString)
        '                        R.Document.Paragraphs.Get(.Cell(i, 0).Range.Start).SpacingBefore = 25
        '                    Case Else
        '                        If CBool(V(i)("isSel")) Then
        '                            ' Выбранный пункт
        '                            'R.Document.InsertHtmlText(.Cell(i, 0).Range.Start, String.Format("<b>{0}</b>", V(i)("pos").ToString))
        '                            R.Document.InsertHtmlText(.Cell(i, 1).Range.Start, String.Format("<b>{0}</b>", V(i)("posDescription").ToString.Replace(vbCrLf, "1234567890")))
        '                            R.Document.ReplaceAll("1234567890", vbCrLf, DevExpress.XtraRichEdit.API.Native.SearchOptions.None, .Cell(i, 1).Range)
        '                        Else
        '                            R.Document.InsertText(.Cell(i, 0).Range.Start, V(i)("pos").ToString)
        '                            R.Document.InsertText(.Cell(i, 1).Range.Start, V(i)("description").ToString)
        '                        End If
        '                End Select
        '            Next
        '            .Rows.LastOrDefault.Delete()
        '        End If
        '    End With

        'End Using


        ' Удаление пустых параграфов во всем документе
        iTmp = 1
        While iTmp < R.Document.Sections(0).Paragraphs.Count - 1
            If R.Document.Tables.GetTableCell(R.Document.Paragraphs(iTmp).Range.Start) Is Nothing AndAlso _
                Not C2.IsText(R.Document.GetText(R.Document.Paragraphs(iTmp).Range)) Then
                R.Document.Delete(R.Document.Paragraphs(iTmp).Range)
            Else
                iTmp += 1
            End If
        End While


        ' Завершение редактирования документа
        R.Document.EndUpdate()

        ' СОХРАНЕНИЕ ДОКУМЕНТА И СВЕДЕНИЙ О НЕМ В ИСТОЧНИК ДАННЫХ РАБОТЫ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        Me.ARow("doc1Data") = R.Document.OpenXmlBytes
        Me.ARow("doc1SummaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsFreedom)

    End Sub


    ''' <summary>
    ''' Наименование и реквизиты российских участников внешнеэкономической операции
    ''' </summary>
    Private Function RtfSupplyRusCaption() As String
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Using V As New DataView(Me.MemberTable)
            V.RowFilter = "supRusNum > 0"
            V.Sort = "supRusNum"
            If V.Count = 0 Then Return Nothing
            For i As Integer = 0 To V.Count - 1
                '
                ' Наименование
                '
                sTmp1 = C2.ToText(V(i)("nameLong"))
                If Not C2.IsText(sTmp1) Then Return Nothing
                sTmp = String.Format("{0}{1}", sTmp, sTmp1)
                '
                ' Наименование + юридический адрес
                '
                sTmp1 = C2.ToText(V(i)("addressLegalFull"))
                If Not C2.IsText(sTmp1) Then Return Nothing
                sTmp = String.Format("{0}, {1}", sTmp, sTmp1)
                '
                ' Наименование + юридический адрес + телефон
                '
                sTmp1 = C2.ToText(V(i)("phone"))
                If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, тел: {1}", sTmp, sTmp1)
                '
                ' Наименование + юридический адрес + телефон + ИНН
                '
                sTmp1 = C2.ToText(V(i)("inn"))
                If Not C2.IsText(sTmp1) Then Return Nothing
                sTmp = String.Format("{0}, ИНН: {1};{2}", sTmp, sTmp1, vbCrLf)
            Next
        End Using
        Return C2.AddPoint(sTmp.Substring(0, sTmp.Length - 3))
    End Function


    ''' <summary>
    ''' Сведения о внешнеэкономической операции
    ''' </summary>
    Private Function RtfSupplyDescription() As String
        '
        ' Описание внешнеэкономической операции
        '
        Dim sTmp As String = C2.AddPoint(Me.ARow("supplyDescription"))
        If Not C2.IsText(sTmp) Then Return Nothing
        '
        ' Характер внешнеэкономической операции
        '
        Dim Row As DataRow = Me.SupplyTypeHandbookTable.Rows.Find(C2.ToInt(Me.ARow("supplyTypeId")))
        If Row Is Nothing Then Return Nothing
        '
        ' Характер + описание
        '
        Return String.Format("{0}{1}{2}", C2.AddPoint(Row("nameLong")), vbCrLf, sTmp)
    End Function


    ''' <summary>
    ''' Номера разделов Единого перечня, выбранные для проведения идентификационной экспертизы
    ''' </summary>
    Private Function RtfLawSection() As String
        Dim sTmp As String = Nothing
        Using V As New DataView(Me.LawDataSet.LawTable)
            V.RowFilter = String.Format("id IN (0, {0})", Me.LawCaptionTable.StrId)
            V.Sort = "doc, id"
            For i As Integer = 0 To V.Count - 1
                If C2.ToText(V(i)("doc")) Like "3100.*" Then
                    sTmp = String.Format("{0};{1}- Раздел {2}", sTmp, vbCrLf, C2.ToText(V(i)("posDescription")))
                Else
                    sTmp = String.Format("{0};{1}- {2}", sTmp, vbCrLf, C2.ToText(V(i)("description")))
                End If
            Next
        End Using
        If String.IsNullOrWhiteSpace(sTmp) Then Return Nothing
        sTmp = sTmp.Substring(3)
        'If sTmp Like "*, *" Then Return String.Format("разделы {0}", sTmp)
        'Return String.Format("раздел {0}", sTmp)
        Return C2.AddPoint(sTmp)
    End Function


    ''' <summary>
    ''' Полное описание объекта экспертизы (техническое описание + назначение + область применения)
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    Private Function RtfGoodFullDescription(Row As DataRow) As String
        If Row Is Nothing OrElse Row.Table Is Nothing OrElse Not Row.Table Is Me.GoodTable Then Return Nothing
        Dim description As String = Nothing
        Dim area As String = Nothing
        Dim used As String = Nothing
        description = C2.ToText(Row("description"))
        area = C2.ToText(Row("area"))
        If Not C2.IsText(area) Then area = C2.ToText(Me.ARow("goodArea"))
        used = C2.ToText(Row("used"))
        If Not C2.IsText(used) Then used = C2.ToText(Me.ARow("goodUsed"))
        If C2.IsText(description) AndAlso C2.IsText(area) AndAlso C2.IsText(used) Then
            Return String.Format( _
                "{1}{0}Назначение: {2}{0}Область применения: {3}", _
                vbCrLf, C2.AddPoint(description), C2.AddPoint(used), C2.DelPoint(area))
        End If
        Return Nothing
    End Function


    ''' <summary>
    ''' ФИО исполнителя
    ''' </summary>
    Private ReadOnly Property RtfExpertName As String
        Get
            Return C2.ToText(Me.ExecuteScalar(String.Format("SELECT nameShort FROM tUser WHERE id = {0}", C2.ToInt(Me("expertId")))))
        End Get
    End Property


End Class