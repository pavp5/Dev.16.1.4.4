Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.API.Layout
Imports C2 = Cprp.DxData.Common
' =====================================
' Создание проектов итоговых документов
' =====================================
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Создать проекты заключений экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub ProjectCreate()
        '
        ' Удаление старых данных
        '
        Me.ARow("doc1Data") = DBNull.Value
        Me.ARow("doc1SummaryId") = DBNull.Value
        Me.ARow("doc2Data") = DBNull.Value
        Me.ARow("doc2SummaryId") = DBNull.Value
        For Each Row As DataRow In Me.GoodTable.Rows
            If Row.RowState = DataRowState.Deleted Then Continue For
            Row("isDoc1") = DBNull.Value
        Next
        '
        ' Обновление контрольных статусов объектов экспертизы по контрольным статусам дочерних объектов
        '
        StudySummaryUpdateByChild()
        '
        ' Создание проектов документов
        '
        OneProjectCreate(True)
        OneProjectCreate(False)

    End Sub

    ''' <summary>
    ''' Создать один проект итогового документа
    ''' </summary>
    ''' <param name="isEqual">Заключение на объекты экспертизы, соответствующие контрольным спискам</param>
    ''' <remarks></remarks>
    Private Sub OneProjectCreate(isEqual As Boolean)

        ' ПЕРЕМЕННЫЕ
        ' ++++++++++
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing                   ' Документ
        Dim TGood As DocumentGoodDataTable = Nothing                                        ' Таблица объектов экспертизы
        Dim TLaw As DocumentLawDataTable = Nothing                                          ' Таблица исследований объектов экспертизы
        Dim mode As Cprp.DxData.ModeEnum = DxData.ModeEnum.isExport                         ' Направление перемещения
        Dim nullText As String = "[нет данных]"                                             ' Стандартное сообщение об ошибке, выводящееся в документ вместо пустых значений
        Dim summaryId As Cprp.DxData.Work.WorkSummary = DxData.Work.WorkSummary.IsFreedom   ' Идентификатор выводов экспертизы
        Dim bNotGlobalRisk As Boolean = False                                               ' Отсутствуют риски по всей работе
        Dim sTmp As String, iTmp As Integer, bTmp As Boolean

        ' ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        ' ++++++++++++++++++++++++
        '
        TGood = New DocumentGoodDataTable(Me, isEqual)
        If TGood.Rows.Count = 0 Then    ' Нет объектов экспертизы
            TGood.Dispose()
            Exit Sub
        End If
        TLaw = New DocumentLawDataTable(Me, TGood)
        R = New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.Unit = DevExpress.Office.DocumentUnit.Document
        R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
        mode = CType(Me.ARow("modeId"), Cprp.DxData.ModeEnum)
        ' Отсутствие рисков по работе
        If Not isEqual Then
            bNotGlobalRisk = Me.NotGlobalRisk
            Me.ARow("isDefContract") = bNotGlobalRisk
            Me.ARow("isDefNusMember") = bNotGlobalRisk
            If bNotGlobalRisk Then Me.ARow("docTerm") = Date.Today.AddYears(5)
        End If


        ' ЗАГРУЗКА ШАБЛОНА ЗАКЛЮЧЕНИЯ И ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Загрузка шаблона заключения
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ЭКСКОНТЗАКЛЮЧЕНИЕ", Me.Connection)
        'R.LoadDocument("d:\2.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        R.Document.BeginUpdate()

        ' Номер и дата заключения - тело документа
        PutBookmark(R.Document, "DocNum", Nothing, "[Проект]")
        PutBookmark(R.Document, "DocDate", String.Format("{0:d MMMM yyyy} г.", Date.Today), nullText)

        ' Номер и дата заключения - колонтитул
        Dim Hd As SubDocument = R.Document.Sections(0).BeginUpdateHeader
        PutBookmark(Hd, "DocNum2", Nothing, "[Проект]")
        PutBookmark(Hd, "DocDate2", String.Format("{0:dd.MM.yyyy}", Date.Today), "{00.00.0000}")
        R.Document.Sections(0).EndUpdateHeader(Hd)

        ' 2. Сведения о внешнеэкономической операции
        PutRange(R.Document.Bookmarks("SupplyDescription").Range, RtfSupplyDescription, nullText)

        ' 2.1. Документ, на основании которого осуществляется внешнеэкономическая операция
        If CBool(Me.ARow("isDefContract")) Then
            PutRange(R.Document.Bookmarks("ContractCaption").Range, Nothing)
        Else
            PutRange(R.Document.Bookmarks("ContractDef").Range, Nothing)
            PutRange(R.Document.Bookmarks("ContractCaption").Range, RtfContractCaption, nullText)
        End If

        ' 2.2. Страна назначения (отправления)
        sTmp = If(mode = Cprp.DxData.ModeEnum.isExport, "назначения", "отправления")
        PutRange(R.Document.Bookmarks("CountryMode").Range, sTmp)
        PutRange(R.Document.Bookmarks("CountryMode2").Range, sTmp)
        PutRange(R.Document.Bookmarks("CountryMode3").Range, sTmp)
        sTmp = RtfSupplyCountryName()
        If Not C2.IsText(sTmp) Then
            PutRange(R.Document.Bookmarks("CountryName").Range, Nothing, nullText)
            With R.Document.Bookmarks("CommentEmbargo").Range
                R.Document.Delete(R.Document.CreateRange(.End, R.Document.Range.End.ToInt - .End.ToInt))
            End With
        Else
            Dim arrCountry() As String = sTmp.Split(New Char() {C2.FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
            If arrCountry.Length < 3 Then
                PutRange(R.Document.Bookmarks("CountryName").Range, C2.AddPoint(sTmp.Replace(C2.FIELD_SEPARATOR, ", ")), nullText)
                With R.Document.Bookmarks("CommentEmbargo").Range
                    R.Document.Delete(R.Document.CreateRange(.End, R.Document.Range.End.ToInt - .End.ToInt))
                End With
            Else
                PutRange(R.Document.Bookmarks("CountryName").Range, "согласно приложению.", nullText)
                PutRange(R.Document.Bookmarks("CountryName2").Range, sTmp.Replace(C2.FIELD_SEPARATOR, ";" & vbCrLf) & ".", nullText)
            End If
        End If

        ' 2.3. Российские участники внешнеэкономической операции
        PutRange(R.Document.Bookmarks("RusCaption").Range, RtfSupplyRusCaption, nullText)

        ' 2.4.1. Покупатель (продавец)
        PutRange(R.Document.Bookmarks("NusMode").Range, If(mode = Cprp.DxData.ModeEnum.isExport, "Покупатель", "Продавец"))
        PutRange(R.Document.Bookmarks("NusCaption").Range, RtfSupplyNusCaption(isEqual), nullText)

        ' 2.4.2. Потребитель (конечный пользователь)
        PutRange(R.Document.Bookmarks("EndCaption").Range, RtfSupplyEndCaption(isEqual), nullText)

        ' 3. РЕАЛЬНЫЕ ТОВАРЫ - Сведения об идентифицируемых товарах и идентифицируемых продуктах научно-технической деятельности
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
            TGood.GroupByTnvedDescription()
            TGood.DefaultView.RowFilter = "isUnreal = False"
            TGood.DefaultView.Sort = "rowNum, nameCon"
            For i As Integer = 0 To TGood.DefaultView.Count - 1
                .Rows.Append()
                PutRange(.Cell(.Rows.Count - 2, 0).Range, C2.ToText(TGood.DefaultView(i)("rowNum")), nullText)
                PutRange(.Cell(.Rows.Count - 2, 1).Range, C2.ToText(TGood.DefaultView(i)("nameCon")), nullText)
                If i = 0 OrElse C2.ToText(TGood.DefaultView(i)("groupText")) <> C2.ToText(TGood.DefaultView(i - 1)("groupText")) Then
                    ' Если текущее техническое описание и код не совпадают с предыдущими - вставка технического описания и кода
                    PutRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(TGood.DefaultView(i)("tnved")), nullText)
                    PutRange(.Cell(.Rows.Count - 2, 3).ContentRange, C2.ToText(TGood.DefaultView(i)("description")), nullText)
                End If
            Next
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

            TGood.DefaultView.RowFilter = Nothing

        End With

        'GoTo LTemp


        ' 4. Перечень позиций (пунктов) контрольных списков, рассмотренных экспертом
        'With R.Document.Tables(2)
        '    '
        '    ' Выравнивание первой строки таблицы
        '    '
        '    R.Document.Paragraphs.Get(.Cell(1, 0).Range.Start).Alignment = ParagraphAlignment.Center
        '    R.Document.Paragraphs.Get(.Cell(1, 1).Range.Start).Alignment = ParagraphAlignment.Left
        '    '
        '    ' Вставка данных
        '    '
        '    Using T As DataTable = TLaw.GetParagraphTable
        '        T.DefaultView.Sort = "goodNumS"
        '        For i As Integer = 0 To T.DefaultView.Count - 1
        '            .Rows.Append()
        '            PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(T.DefaultView(i)("goodNumS")), nullText)
        '            PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(T.DefaultView(i)("paragraph")), nullText)
        '        Next
        '    End Using
        '    If .Rows.Count > 2 Then
        '        .Rows.LastOrDefault.Delete()
        '    Else
        '        ' Нет данных
        '        PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
        '        PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
        '    End If
        'End With

        ' 4.1. Позиции (пункты) контрольных списков, выбранные для сравнительного анализа
        With R.Document.Tables(3)
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
            Using T As DataTable = TLaw.GetSelectionTable
                T.DefaultView.Sort = "goodNumS, lawDoc, lawPos"
                For i As Integer = 0 To T.DefaultView.Count - 1
                    .Rows.Append()
                    PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(T.DefaultView(i)("goodNumS")), nullText)
                    PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(T.DefaultView(i)("lawList")), nullText)
                    PutRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(T.DefaultView(i)("lawSection")), nullText)
                    PutRange(.Cell(.Rows.Count - 2, 3).ContentRange, C2.ToText(T.DefaultView(i)("lawPos")), nullText)
                Next
            End Using
            If .Rows.Count > 2 Then
                .Rows.LastOrDefault.Delete()
            Else
                ' Нет данных
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 2).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 3).ContentRange, Nothing, nullText)
            End If
        End With

        ' 4.2. Результаты сравнительного анализа
        With R.Document.Tables(4)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).ContentRange.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 2).ContentRange.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 3).ContentRange.Start).Alignment = ParagraphAlignment.Left
            '
            ' Вставка данных
            '
            Using T As DataTable = TLaw.GetStudyTable
                T.DefaultView.Sort = "goodNumS, lawDoc, lawPosDescription"
                For i As Integer = 0 To T.DefaultView.Count - 1
                    .Rows.Append()
                    PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(T.DefaultView(i)("goodNumS")), nullText)
                    sTmp = C2.ToText(T.DefaultView(i)("lawPosDescription"))
                    If C2.IsText(sTmp) Then sTmp = sTmp.Replace(C2.FIELD_SEPARATOR, Nothing)
                    PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, sTmp, nullText)
                    PutRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(T.DefaultView(i)("goodDescription")), nullText)
                    PutRange(.Cell(.Rows.Count - 2, 3).ContentRange, C2.ToText(T.DefaultView(i)("summary")), nullText)
                Next
            End Using
            If .Rows.Count > 2 Then
                .Rows.LastOrDefault.Delete()
            Else
                ' Нет данных
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 2).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 3).ContentRange, Nothing, nullText)
            End If
        End With


        ' 5.1. Применение специальных экономических мер:

        ' а) в отношении страны назначения (отправления)
        sTmp = RtfSupplyCountryEmbargo(mode)
        PutRange(R.Document.Bookmarks("LimitCountry").Range, sTmp, nullText)
        ' удалить примечание в конце документа, если мер в отношении страны нет
        If sTmp Like "*специальные экономические и принудительные меры не применяются*" Then
            R.Document.Delete(R.Document.Bookmarks("CommentEmbargo").Range)
        End If

        ' б) в отношении иностранного участника внешнеэкономической операции
        PutRange(R.Document.Bookmarks("LimitNus").Range, RtfSupplyMemberEmbargo, nullText)

        ' в) в отношении идентифируемых товаров
        With R.Document.Tables(5)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).Range.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).Range.Start).Alignment = ParagraphAlignment.Left
            '
            ' Вставка данных
            '
            Using T As DataTable = TGood.GetGoodEmbargoTable
                T.DefaultView.Sort = "goodNumS, embargoName"
                For i As Integer = 0 To T.DefaultView.Count - 1
                    .Rows.Append()
                    PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(T.DefaultView(i)("goodNumS")), nullText)
                    PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(T.DefaultView(i)("embargoName")), nullText)
                Next
            End Using
            If .Rows.Count > 2 Then
                .Rows.LastOrDefault.Delete()
            Else
                ' Нет данных
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
            End If
        End With

        ' 5.2. Имеются признаки, дающие основание полагать ...
        PutBookmark(R.Document, "Is20", RtfSummaryRisk(isEqual), nullText)


        ' 6. Общие выводы по результатам идентификации
        '
        ' Определение идентификатора выводов экспертизы
        '
        summaryId = CType(Me.ARow("summaryId"), Cprp.DxData.Work.WorkSummary)
        If Not isEqual AndAlso (summaryId = DxData.Work.WorkSummary.IsLicense OrElse summaryId = DxData.Work.WorkSummary.IsOutput) Then
            summaryId = Cprp.DxData.Work.WorkSummary.IsFreedom
        End If
        '
        ' Выводы экспертизы
        '
        sTmp = C2.AddPoint(Me.ARow("summaryText"))
        If summaryId = Cprp.DxData.Work.WorkSummary.IsFreedom Then
            ' Заключение на неконтролируемые товары в работе с контролируемыми товарами
            sTmp = "Для осуществления внешнеэкономической операции, указанной в настоящем заключении, лицензия или иное разрешение, предусмотренное законодательством Российской Федерации в области экспортного контроля, не требуется."
        End If
        PutRange(R.Document.Bookmarks("Summary1").Range, sTmp, nullText)

        ' 7. Дополнительная информация
        '
        sTmp = C2.AddPoint(Me.ARow("comment"))
        If Not isEqual AndAlso CBool(Me.ARow("isDefNusMember")) Then
            If C2.IsText(sTmp) Then sTmp &= vbCrLf
            sTmp &= "Не допускается использование настоящего заключения для осуществления поставок товара, указанного в позиции 3 заключения, в случае наличия у российского участника внешнеэкономической деятельности оснований полагать, что данный товар предназначен для создания оружия массового поражения, средств его доставки, иных видов вооружения и военной техники или приобретается в интересах организаций или физических лиц, причастных к террористической деятельности."
        End If

        PutRange(R.Document.Bookmarks("Comment").Range, sTmp)

        ' 7.1. Срок действия заключения
        '
        sTmp = Nothing
        If summaryId = WorkSummary.IsLicense OrElse summaryId = WorkSummary.IsPermit OrElse summaryId = WorkSummary.IsEmbargo Then
            sTmp = "-"
        Else
            If Not IsDBNull(Me.ARow("docTerm")) Then sTmp = String.Format("до {0:dd.MM.yyyy}.", CDate(Me.ARow("docTerm")))
        End If
        PutBookmark(R.Document, "DocTerm", sTmp, NULL_TEXT)

        ' 8. Утверждающее лицо
        '
        ' Штам ЭП (предварительно)
        PutBookmark(R.Document, "SertNum", "-")
        PutBookmark(R.Document, "SertName", "-")
        PutBookmark(R.Document, "SertTerm", "-")

        '
        ' Виртуальные дочерние товары
        ' ---------------------------
        '
        bTmp = False
        Using V As New DataView(TGood) With {.RowFilter = "parentId IS NULL", .Sort = "rowNum DESC"}
            For i As Integer = 0 To V.Count - 1
                If SetChildGood(R.Document, V(i).Row) Then bTmp = True
            Next
        End Using

        ' Удаление вступительной фразы о виртуальных товарах
        '
        If Not bTmp Then PutBookmark(R.Document, "UnrealGood", Nothing)


        ' Пояснения эксперта к пунктам документа
        '
        bTmp = IsDBNull(Me.ARow("doc1Data"))    ' Проект документа #1
        sTmp = Nothing
        Dim Row As DataRow = Me.CommentTable.Rows.Find(If(bTmp, 10, 210))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P2Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 20, 220))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P21Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 30, 230))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P22Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 40, 240))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P23Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 50, 250))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P24Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 60, 260))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P241Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 70, 270))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P242Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 80, 280))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P3Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 90, 290))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P4Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 100, 300))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P41Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 110, 310))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P42Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 120, 320))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P5Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 130, 330))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P51Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 140, 340))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P51aComment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 150, 350))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P51bComment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 160, 360))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P51vComment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 170, 370))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P52Comment").Range, sTmp)
        sTmp = Nothing
        Row = Me.CommentTable.Rows.Find(If(bTmp, 180, 380))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("comment"))
        If C2.IsText(sTmp) Then sTmp = String.Format("<p style='font-style:italic;text-align:left'><u>Пояснение эксперта:</u><br>{0}</p>", sTmp.Replace(vbCrLf, "<br>"))
        PutHtmlRange(R.Document.Bookmarks("P6Comment").Range, sTmp)

        ' Удаление таблицы с перечнем пунктов, рассмотренных экспертом
        PutBookmark(R.Document, "P4Pos", Nothing)

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

        TLaw.Dispose()
        TGood.Dispose()

        ' Завершение редактирования документа
        R.Document.EndUpdate()

        ' СОХРАНЕНИЕ ДОКУМЕНТА И СВЕДЕНИЙ О НЕМ В ИСТОЧНИК ДАННЫХ РАБОТЫ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Сохранение содержимого проекта документа
        '
        If IsDBNull(Me.ARow("doc1Data")) Then
            Me.ARow("doc1Data") = R.Document.OpenXmlBytes
            Me.ARow("doc1SummaryId") = CInt(summaryId)
            bTmp = True
        Else
            Me.ARow("doc2Data") = R.Document.OpenXmlBytes
            Me.ARow("doc2SummaryId") = CInt(summaryId)
            bTmp = False
        End If
        '
        ' Сохранение привязок проекта документа к объектам экспертизы
        '
        Using V As New DataView(Me.GoodTable)
            V.RowFilter = String.Format("studySummaryId {0} {1}", _
                If(isEqual, "=", "<>"), CInt(Cprp.DxData.Law.StudyIndexEnum.IsEqual))
            For i As Integer = 0 To V.Count - 1
                V(i)("isDoc1") = bTmp
            Next
        End Using

    End Sub

    ''' <summary>
    ''' Вставка описаний дочерних виртуальных объектов в документ
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <param name="Row">Родительская строка таблицы объектов экспертизы проекта</param>
    ''' <returns>True, если дочрние объекты существуют</returns>
    ''' <remarks>Рекурсивная функция</remarks>
    Private Function SetChildGood(ByRef Doc As Document, Row As DataRow) As Boolean
        Using V As New DataView(Row.Table)
            V.Sort = "rowNum"
            V.RowFilter = String.Format("parentId = {0} AND isUnreal = True", CInt(Row("id")))
            If V.Count = 0 Then Return False
            '
            ' Вставка описаний дочерних виртуальных объектов текущих дочрних объектов
            '
            For i As Integer = V.Count - 1 To 0 Step -1
                SetChildGood(Doc, V(i).Row)
            Next
            '
            ' Вставка описаний текущих дочерних объектов
            '
            Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
                '
                ' Шаблон блока с данными вируальных объектов
                '
                R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ЭКСКОНТВИРТУАЛЬНЫЙТОВАР", Me.Connection)
                '
                ' Заголовок блока
                '
                Dim sTmp As String = String.Format("<u><b>Объект № {0}</b></u> содержит в своем составе:1234567890", C2.ToInt(Row("rowNum")))
                R.Document.InsertHtmlText(R.Document.Range.Start, sTmp)
                R.Document.ReplaceAll("1234567890", vbCrLf, SearchOptions.None)
                '
                ' Вставка сведений о дочерних виртуальных объектах
                '
                Dim nullText As String = "[нет данных]"
                With R.Document.Tables(0)
                    For i As Integer = 0 To V.Count - 1
                        .Rows.Append()
                        PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(V(i)("rowNum")), nullText)
                        PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(V(i)("nameCon")), nullText)
                        If i = 0 OrElse C2.ToText(V(i)("groupText")) <> C2.ToText(V(i - 1)("groupText")) Then
                            ' Если текущее техническое описание и код не совпадают с предыдущими - вставка технического описания и кода
                            PutRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(V(i)("tnved")), nullText)
                            PutRange(.Cell(.Rows.Count - 2, 3).ContentRange, C2.ToText(V(i)("description")), nullText)
                        End If
                    Next
                    If .Rows.Count > 2 Then
                        .Rows.LastOrDefault.Delete()
                        ' Объединение ячеек с одинаковым техническими описаниями и кодами
                        Dim iTmp As Integer = 1
                        For i As Integer = 1 To .Rows.Count - 1
                            If String.IsNullOrWhiteSpace(R.Document.GetText(.Cell(i, 2).Range)) Then
                                .MergeCells(.Cell(iTmp, 2), .Cell(i, 2))
                                .MergeCells(.Cell(iTmp, 3), .Cell(i, 3))
                            Else
                                iTmp = i
                            End If
                        Next
                    End If
                End With
                '
                ' Вставка блока в закладку "UnrealGood"
                '
                Dim pos As DocumentPosition = Doc.Bookmarks("UnrealGood").Range.End
                Doc.InsertRtfText(pos, R.Document.RtfText)

            End Using
        End Using
        Return True
    End Function


    ''' <summary>
    ''' Документ, на основании которого осуществляется внешнеэкономическая операция
    ''' </summary>
    Private Function RtfContractCaption() As String
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        '
        ' Без договора
        '
        If CBool(Me.ARow("isNotContract")) Then
            sTmp = C2.AddPoint(Me.ARow("invoiceCaption"))
            If Not C2.IsText(sTmp) Then sTmp = "Без договора."
            Return sTmp
        End If
        '
        ' Наименование документа-основания сделки
        '
        sTmp = C2.ToText(Me.ARow("contractName"))
        If Not C2.IsText(sTmp) Then Return Nothing
        '
        ' Наименование + номер документа
        '
        sTmp1 = C2.ToText(Me.ARow("contractNum"))
        If Not C2.IsText(sTmp1) Then sTmp1 = "б/н"
        sTmp = String.Format("{0} № {1}", sTmp, sTmp1)
        '
        ' Наименование + номер + дата документа
        '
        If Not IsDBNull(Me.ARow("contractDate")) Then
            sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(Me.ARow("contractDate")))
        End If
        sTmp = C2.AddPoint(sTmp)
        '
        ' Наименование + номер + дата + документ-основание операции
        '
        sTmp1 = C2.ToText(Me.ARow("invoiceCaption"))
        Return C2.AddPoint(String.Format("{0} {1}", sTmp, sTmp1))
    End Function


    ''' <summary>
    ''' Сведения о внешнеэкономической операции
    ''' </summary>
    Private Function RtfSupplyDescription() As String
        ''
        '' Описание внешнеэкономической операции
        ''
        'Dim sTmp As String = C2.AddPoint(Me.ARow("supplyDescription"))
        'If Not C2.IsText(sTmp) Then Return Nothing
        '
        ' Характер внешнеэкономической операции
        '
        Dim Row As DataRow = Me.SupplyTypeHandbookTable.Rows.Find(C2.ToInt(Me.ARow("supplyTypeId")))
        If Row Is Nothing Then Return Nothing
        ''
        '' Характер + описание
        ''
        'Return String.Format("{0}{1}{2}", C2.AddPoint(Row("nameLong")), vbCrLf, sTmp)
        Return C2.AddPoint(Row("nameLong"))
    End Function


    ''' <summary>
    ''' Краткое наименование страны назначения (отправления)
    ''' </summary>
    Private Function RtfSupplyCountryName() As String
        '
        ' Транзит в Калининград
        '
        If CType(Me.ARow("supplyTypeId"), Cprp.DxData.Work.SupplyType) = Cprp.DxData.Work.SupplyType.IsTransit Then
            Return "РОССИЯ"
        End If
        Dim sTmp As String = C2.ToText(Me.ARow("countryIdString"))
        If Not C2.IsText(sTmp) Then sTmp = "0"
        Using V As New DataView(Me.CountryHandbookTable) With {.Sort = "nameShort"}
            V.RowFilter = String.Format("id IN ({0})", sTmp.Replace("/", ","))
            If V.Count = 0 Then Return Nothing
            If V.Count = 1 Then Return C2.ToText(V(0)("nameShort"))
            sTmp = C2.ToText(V(0)("nameShort"))
            For i As Integer = 1 To V.Count - 1
                sTmp = String.Format("{0}{1}{2}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(V(i)("nameShort")))
            Next
        End Using
        Return sTmp
    End Function


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
    ''' Наименование и реквизиты иностранных покупателей (продавцов)
    ''' </summary>
    ''' <param name="isEqual">Заключение на контролируемую продукцию</param> 
    Private Function RtfSupplyNusCaption(isEqual As Boolean) As String
        If Not isEqual AndAlso CBool(Me.ARow("isDefNusMember")) Then
            Return "без ограничений, кроме случаев, указанных в пункте 7 настоящего заключения."
        End If
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Dim Row As DataRow = Nothing
        Using V As New DataView(Me.MemberTable)
            V.RowFilter = "supNusNum > 0"
            V.Sort = "supNusNum"
            If V.Count = 0 Then Return "отсутствует." ' Нет иностранных покупателей (продавцов)
            For i As Integer = 0 To V.Count - 1
                '
                ' Наименование
                '
                sTmp1 = C2.ToText(V(i)("nameLong"))
                If Not C2.IsText(sTmp1) Then Return Nothing
                sTmp = String.Format("{0}{1}", sTmp, sTmp1)
                '
                ' Наименование + cтрана
                '
                Row = Me.CountryHandbookTable.Rows.Find(C2.ToInt(V(i)("addressLegalCountryId")))
                If Row Is Nothing Then Return Nothing
                sTmp = String.Format("{0}, {1}", sTmp, C2.ToText(Row("nameShort")))
                '
                ' Наименование + страна + юридический адрес
                '
                sTmp1 = C2.ToText(V(i)("addressLegalFull"))
                If Not C2.IsText(sTmp1) Then Return Nothing
                sTmp = String.Format("{0}, {1};{2}", sTmp, sTmp1, vbCrLf)
            Next
        End Using
        Return C2.AddPoint(sTmp.Substring(0, sTmp.Length - 3))
    End Function


    ''' <summary>
    ''' Наименование и реквизиты потребителей (конечных пользователей)
    ''' </summary>
    ''' <param name="isEqual">Заключение на контролируемую продукцию</param> 
    Private Function RtfSupplyEndCaption(isEqual As Boolean) As String
        '
        ' Ввоз
        '
        If CType(Me.ARow("modeId"), Cprp.DxData.ModeEnum) = DxData.ModeEnum.isImport Then Return "-"
        '
        ' Транзит в Калининград
        '
        If CType(Me.ARow("supplyTypeId"), Cprp.DxData.Work.SupplyType) = Cprp.DxData.Work.SupplyType.IsTransit Then
            Return "-"
        End If
        '
        ' без ограничений
        '
        If Not isEqual AndAlso CBool(Me.ARow("isDefNusMember")) Then
            Return "без ограничений, кроме случаев, указанных в пункте 7 настоящего заключения."
        End If

        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Dim Row As DataRow = Nothing
        Using V As New DataView(Me.MemberTable)
            V.RowFilter = "supEndNum > 0"
            V.Sort = "supEndNum"
            If V.Count = 0 Then Return "не определен."
            For i As Integer = 0 To V.Count - 1
                '
                ' Наименование
                '
                sTmp1 = C2.ToText(V(i)("nameLong"))
                If Not C2.IsText(sTmp1) Then Return Nothing
                sTmp = String.Format("{0}{1}", sTmp, sTmp1)
                '
                ' Наименование + страна
                '
                Row = Me.CountryHandbookTable.Rows.Find(C2.ToInt(V(i)("addressLegalCountryId")))
                If Row Is Nothing Then Return Nothing
                sTmp = String.Format("{0}, {1}", sTmp, C2.ToText(Row("nameShort")))
                '
                ' Наименование + страна + юридический адрес
                '
                sTmp1 = C2.ToText(V(i)("addressLegalFull"))
                If Not C2.IsText(sTmp1) Then Return Nothing
                sTmp = String.Format("{0}, {1};{2}", sTmp, sTmp1, vbCrLf)
            Next
        End Using
        Return C2.AddPoint(sTmp.Substring(0, sTmp.Length - 3))
    End Function


    ''' <summary>
    ''' Применение специальных экономических мер в отношении страны назначения (отправления)
    ''' </summary>
    Private Function RtfSupplyCountryEmbargo0() As String
        '
        ' Транзит в Калининград
        '
        If CType(Me.ARow("supplyTypeId"), Cprp.DxData.Work.SupplyType) = Cprp.DxData.Work.SupplyType.IsTransit Then
            Return "-"
        End If
        If Not C2.IsText(Me.ARow("countryIdString")) Then Return Nothing
        Dim sTmp As String = Nothing
        Using V As New DataView(Me.EmbargoCountryHandbookTable)
            V.Sort = "embargoCaption2"
            V.RowFilter = String.Format("countryId IN ({0})", C2.ToText(Me.ARow("countryIdString")).Replace("/", ","))
            '
            ' Открытые запреты и ограничения
            '
            For i As Integer = 0 To V.Count - 1
                If Not CBool(V(i)("isLimited")) Then
                    If C2.ToText(V(i)("embargoCaption2")) Like "* ООН *" Then
                        sTmp = String.Format("{0};{1}Применяются принудительные меры установленные {2}", sTmp, vbCrLf, C2.DelPoint(V(i)("embargoCaption2")))
                    Else
                        sTmp = String.Format("{0};{1}Применяются специальные экономические меры установленные {2}", sTmp, vbCrLf, C2.DelPoint(V(i)("embargoCaption2")))
                    End If
                End If
            Next
            ''
            '' Закрытые запреты и ограничения
            ''
            'If Not C2.IsText(sTmp) Then
            '    If V.Count > 0 Then
            '        Return "Применяются специальные экономические меры, установленные Правительством Российской Федерации."
            '    Else
            '        Return "специальные экономические и принудительные меры не применяются."
            '    End If
            'End If
        End Using
        If Not C2.IsText(sTmp) Then Return "специальные экономические и принудительные меры не применяются."
        Return vbCrLf & C2.AddPoint(sTmp.Substring(3).Replace("Указ ", "Указом ").Replace("Постановление ", "Постановлением ").Replace("Резолюция", "Резолюцией"))
    End Function

    ''' <summary>
    ''' Применение специальных экономических мер в отношении страны назначения (отправления)
    ''' </summary>
    Private Function RtfSupplyCountryEmbargo(mode As ModeEnum) As String
        '
        ' Транзит в Калининград
        '
        If CType(Me.ARow("supplyTypeId"), Cprp.DxData.Work.SupplyType) = Cprp.DxData.Work.SupplyType.IsTransit Then
            Return "-"
        End If
        If Not C2.IsText(Me.ARow("countryIdString")) Then Return Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Using V As New DataView(Me.EmbargoCountryHandbookTable)
            V.RowFilter = String.Format("countryId IN ({0}, {3}) AND (modeId = {1} OR modeId = {2})", _
                                        C2.ToText(Me.ARow("countryIdString")).Replace("/", ","), _
                                        CInt(mode), _
                                        CInt(ModeEnum.isBoth), C2.ToInt(Me.ARow("bankCountryId")))
            Using T As DataTable = V.ToTable
                '
                ' Добавление и заполнение поля для сортировки строк по типу документа
                '
                T.Columns.Add("sortNum", GetType(Integer))
                For i As Integer = 0 To T.Rows.Count - 1
                    sTmp1 = C2.ToText(T(i)("embargoCaption"))
                    If sTmp1 Like "*ОНН*" Then
                        T(i)("sortNum") = 4
                    ElseIf sTmp1 Like "*Указ Президента*" Then
                        T(i)("sortNum") = 1
                    ElseIf sTmp1 Like "*Федеральный закон*" Then
                        T(i)("sortNum") = 2
                    ElseIf sTmp1 Like "*Постановление Правительства*" Then
                        T(i)("sortNum") = 3
                    Else
                        T(i)("sortNum") = 4
                    End If
                Next
                '
                ' Проверка необходимости вывода Постановления № 313 (id = 39)
                ' -----------------------------------------------------------
                '
                'Using V1 As New DataView(T) With {.RowFilter = "embargoId = 39"}
                '    If V1.Count > 0 Then
                '        Dim bTmp As Boolean = False
                '        ' Проверка отнесения страны назначения к списку недружественных стран (isControl = True)
                '        Using V2 As New DataView(Me.CountryHandbookTable) With _
                '            {.RowFilter = String.Format("isControl = True AND id IN ({0})", C2.ToText(Me.ARow("countryIdString")).Replace("/", ","))}
                '            bTmp = (V2.Count > 0)
                '        End Using
                '        ' Пометка строк с Постановлением № 313
                '        For Each VRow As DataRowView In V1
                '            VRow("isACT") = bTmp
                '        Next
                '    End If
                'End Using
                '
                ' Пометка дубликатов строк при указании нескольких стран (isACT = False)
                '
                Using V1 As New DataView(T) With {.Sort = "embargoId"}
                    For i As Integer = 1 To V.Count - 1
                        If Not CBool(V1(i)("isACT")) Then Continue For
                        V1(i)("isACT") = (CInt(V1(i)("embargoId")) <> CInt(V1(i - 1)("embargoId")))
                    Next
                End Using
                '
                ' Формирование перечня запретов и ограничений
                '
                sTmp = Nothing
                Using V1 As New DataView(T) With {.Sort = "sortNum"}
                    V1.RowFilter = "isLimited = FALSE AND isACT = True"
                    If V1.Count > 0 Then
                        sTmp = "Специальные экономические или принудительные меры, предусмотренные:" & vbCrLf
                        sTmp1 = Nothing
                        For i As Integer = 0 To V1.Count - 1
                            sTmp1 = String.Format("{0};{1}- {2}", sTmp1, vbCrLf, C2.ToText(V1(i)("embargocaption2")))
                        Next
                        sTmp &= sTmp1.Substring(3) & vbCrLf
                        sTmp &= "применяются в случае, если иностранный участник данной внешнеэкономической операции или товары, являющиеся её предметом, приведены в указанных нормативных актах."
                    End If
                    ''
                    '' Специальные экономические меры
                    ''
                    'V1.RowFilter = "isLimited = FALSE AND isACT = True AND NOT embargoCaption LIKE '%ООН%'"
                    'If V1.Count = 1 Then
                    '    sTmp = "Применяются специальные экономические меры установленные " & C2.AddPoint(V1(0)("embargoCaption2"))
                    'ElseIf V1.Count > 1 Then
                    '    sTmp = "Применяются специальные экономические меры установленные:" & vbCrLf
                    '    sTmp1 = Nothing
                    '    For i As Integer = 0 To V1.Count - 1
                    '        sTmp1 = String.Format("{0};{1}- {2}", sTmp1, vbCrLf, C2.ToText(V1(i)("embargocaption2")))
                    '    Next
                    '    sTmp &= C2.AddPoint(sTmp1.Substring(3))
                    'End If
                    ''
                    '' Специальные принудительные меры
                    ''
                    'V1.RowFilter = "isLimited = FALSE AND isACT = True AND embargoCaption LIKE '%ООН%'"
                    'If V1.Count > 0 AndAlso C2.IsText(sTmp) Then sTmp &= vbCrLf
                    'If V1.Count = 1 Then
                    '    sTmp &= "Применяются специальные принудительные меры установленные " & C2.AddPoint(V1(0)("embargoCaption2"))
                    'ElseIf V1.Count > 1 Then
                    '    sTmp &= "Применяются специальные принудительные меры установленные:" & vbCrLf
                    '    sTmp1 = Nothing
                    '    For i As Integer = 0 To V1.Count - 1
                    '        sTmp1 = String.Format("{0};{1}- {2}", sTmp1, vbCrLf, C2.ToText(V1(i)("embargocaption2")))
                    '    Next
                    '    sTmp &= C2.AddPoint(sTmp1.Substring(3))
                    'End If
                End Using
            End Using
        End Using
        If Not C2.IsText(sTmp) Then Return "специальные экономические и принудительные меры не применяются."
        Return vbCrLf & C2.AddPoint(sTmp.Replace("Указ ", "Указом ").Replace("Постановление ", "Постановлением ").Replace("Резолюция", "Резолюцией"))
    End Function

    ''' <summary>
    ''' Применение специальных экономических мер в отношении иностранного участника внешнеэкономической операции
    ''' </summary>
    Private Function RtfSupplyMemberEmbargo() As String
        '
        ' Транзит в Калининград
        '
        If CType(Me.ARow("supplyTypeId"), Cprp.DxData.Work.SupplyType) = Cprp.DxData.Work.SupplyType.IsTransit Then
            Return "-"
        End If
        Dim sTmp As String = Nothing
        '
        ' Строка id экономических мер
        '
        For Each Row As DataRow In Me.MemberEmbargoTable.Rows
            sTmp = String.Format("{0}, {1}", sTmp, C2.ToInt(Row("embargoMemberId")))
        Next
        Using V As New DataView(Me.EmbargoMemberHandbookTable)
            V.Sort = "embargoCaption2"
            V.RowFilter = String.Format("id IN (0{0})", sTmp)
            sTmp = Nothing
            '
            ' Открытые запреты и ограничения
            '
            For i As Integer = 0 To V.Count - 1
                If Not CBool(V(i)("isLimited")) Then
                    If C2.ToText(V(i)("embargoCaption2")) Like "* ООН *" Then
                        sTmp = String.Format("{0};{1}Применяются принудительные меры установленные {2}", sTmp, vbCrLf, C2.DelPoint(V(i)("embargoCaption2")))
                    Else
                        sTmp = String.Format("{0};{1}Применяются специальные экономические меры установленные {2}", sTmp, vbCrLf, C2.DelPoint(V(i)("embargoCaption2")))
                    End If
                End If
            Next
            ''
            '' Закрытые запреты и ограничения
            ''
            'If Not C2.IsText(sTmp) Then
            '    If V.Count > 0 Then
            '        Return "Применяются специальные экономические меры, установленные Правительством Российской Федерации."
            '    Else
            '        Return "специальные экономические и принудительные меры не применяются."
            '    End If
            'End If
        End Using
        If Not C2.IsText(sTmp) Then Return "специальные экономические и принудительные меры не применяются."
        Return vbCrLf & C2.AddPoint(sTmp.Substring(3).Replace("Указ ", "Указом ").Replace("Постановление ", "Постановлением ").Replace("Резолюция", "Резолюцией"))
    End Function


    ''' <summary>
    ''' Имеются признаки, дающие основание полагать ...
    ''' </summary>
    ''' <param name="isEqual">Заключение на контролируемые товары</param>
    Private Function RtfSummaryRisk(isEqual As Boolean) As String
        If isEqual OrElse CType(Me.ARow("modeId"), Cprp.DxData.ModeEnum) = Cprp.DxData.ModeEnum.isImport Then
            Return "проведение анализа не требуется."
        End If
        'If CType(Me.ARow("summaryId"), Cprp.DxData.Work.WorkSummary) <> Cprp.DxData.Work.WorkSummary.IsPermit AndAlso _
        'CType(Me.ARow("summaryId"), Cprp.DxData.Work.WorkSummary) <> Cprp.DxData.Work.WorkSummary.IsDecree Then
        '    Return "не выявлены."
        'End If
        'Return ("имеются. " & C2.AddPoint(Me.ARow("summaryRisk")))
        Dim summary As WorkSummary = CType(Me.ARow("summaryId"), WorkSummary)
        Dim summaryRisk = C2.AddPoint(Me.ARow("summaryRisk"))
        If summary = WorkSummary.IsPermit OrElse summary = WorkSummary.IsDecree Then
            If Not summaryRisk.ToUpper Like ("ИМЕЮТСЯ*") Then summaryRisk = Trim("имеются. " & summaryRisk)
        End If
        If Not C2.IsText(summaryRisk) Then summaryRisk = "не выявлены."
        Return summaryRisk
    End Function


    ''' <summary>
    ''' Дополнительная информация
    ''' </summary>
    Private Function RtfExtraInfo() As String
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        '
        ' Характеристика экспертизы
        '
        Select Case CType(Me("kindId"), Cprp.DxData.Work.WorkKind)
            Case Cprp.DxData.Work.WorkKind.IsAdditional : sTmp1 = "дополнительное"
            Case Cprp.DxData.Work.WorkKind.IsRepeat : sTmp1 = "повторное"
            Case Else : sTmp1 = "первичное"
        End Select
        sTmp = String.Format("Заключение {0}.", sTmp1)
        sTmp1 = C2.ToText(Me.ARow("kindComment"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0} {1}", sTmp, C2.AddPoint(sTmp1))
        sTmp &= vbCrLf
        '
        ' Характеристика экспертизы + дополнительная информация
        '
        sTmp1 = C2.ToText(Me.ARow("comment"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}{1}{2}", sTmp, C2.AddPoint(sTmp1), vbCrLf)
        Return sTmp
    End Function

    ' ''' <summary>
    ' ''' Срок действия заключения
    ' ''' </summary>
    ' ''' <param name="isEqual">Заключение на контролируемые товары</param>
    'Private Function RtfDocTerm(isEqual As Boolean) As String
    '    If isEqual Then Return Nothing
    '    Me.ARow("docTerm") = Date.Today.AddYears(1) ' 06.06.2020 - для всех неконтролируемых заключений срок действия составляет 1 год
    '    If IsDBNull(Me.ARow("docTerm")) Then Return _
    '        "Настоящее Заключение действительно в течение срока выполнения обязательств по внешнеэкономической операции, указанной в пункте 2 Заключения."
    '    Return _
    '        String.Format("Настоящее заключение действительно до {0:dd.MM.yyyy}.", CDate(Me.ARow("docTerm")))
    'End Function

End Class
