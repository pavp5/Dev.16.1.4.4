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

        '
        ' ОБНОВИТЬ СОДЕРЖИМОЕ ПОЛЕЙ ТАБЛИЦЫ ОБЪЕКТОВ ЭКСПЕРТИЗЫ
        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        GoodTableFieldUpdate()

        ' ПЕРЕМЕННЫЕ
        ' ++++++++++
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing       ' Документ
        Dim nullText As String = "{нет данных}"
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0

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
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ГРАЖДАНСКОЕНАЗНАЧЕНИЕЗАКЛЮЧЕНИЕ", Me.Connection)

        ' Номер и дата заключения - тело документа
        PutBookmark(R.Document, "DocNum", Nothing, "{Проект}")
        PutBookmark(R.Document, "DocDate", String.Format("{0:dd.MM.yyyy}", Date.Today), nullText)

        ' Номер и дата заключения - колонтитул
        Dim Hd As SubDocument = R.Document.Sections(0).BeginUpdateHeader
        PutBookmark(Hd, "DocNum2", Nothing, "{Проект}")
        PutBookmark(Hd, "DocDate2", String.Format("{0:dd.MM.yyyy}", Date.Today), "{00.00.0000}")
        R.Document.Sections(0).EndUpdateHeader(Hd)

        ' 1. Заказчик экспертизы
        PutBookmark(R.Document, "ClientCaption", GetClientCaption, nullText)

        ' 2.1. Документ, на основании которого осуществляется внешнеэкономическая операция
        sTmp = C2.ToText(Me.ARow("contractCaption"))
        If Not C2.IsText(sTmp) Then sTmp = "сведения отсутствуют."
        PutBookmark(R.Document, "ContractCaption", sTmp)

        ' 2.2. Российский участник внешнеэкономической операции
        sTmp = GetHtmlMemberCaption()
        If Not C2.IsText(sTmp) Then sTmp = "сведения отсутствуют."
        PutBookmark(R.Document, "RusCaption", sTmp)

        ' 3. Перечень объектов экспертизы
        '
        With R.Document.Tables(1)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).ContentRange.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 2).ContentRange.Start).Alignment = ParagraphAlignment.Center
            '
            ' Вставка данных
            '
            Me.GoodTable.DefaultView.Sort = "rowNum, nameCon"
            For i As Integer = 0 To Me.GoodTable.DefaultView.Count - 1
                .Rows.Append()
                PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(Me.GoodTable.DefaultView(i)("rowNum")), nullText)
                PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(Me.GoodTable.DefaultView(i)("nameCon")), nullText)
                PutRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(Me.GoodTable.DefaultView(i)("tnved")), nullText)
            Next
            If .Rows.Count > 2 Then
                .Rows.LastOrDefault.Delete()
            Else
                ' Нет данных
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 2).ContentRange, Nothing, nullText)
            End If
        End With

        ' 4. Перечень регламентирующих технических документов, использованных для определения назначения и области применения объектов экспертизы
        '
        With R.Document.Tables(2)
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
            Using V As New DataView(Me.InDocTable)
                V.RowFilter = "isUsed = True"
                V.Sort = "rowNum, docType, caption"
                For i As Integer = 0 To V.Count - 1
                    .Rows.Append()
                    PutRange(.Cell(i + 1, 0).ContentRange, i + 1)
                    PutRange(.Cell(i + 1, 1).ContentRange, C2.ToText(V(i)("docType")), nullText)
                    PutRange(.Cell(i + 1, 2).ContentRange, C2.ToText(V(i)("caption")), nullText)
                    PutRange(.Cell(i + 1, 3).ContentRange, C2.ToText(V(i)("author")), nullText)
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

        ' 5. Техническое описание объектов экспертизы
        '
        With R.Document.Tables(3)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).ContentRange.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 2).ContentRange.Start).Alignment = ParagraphAlignment.Left
            '
            ' Вставка данных
            '
            Me.GoodTable.DefaultView.Sort = "rowNum, nameCon"
            For i As Integer = 0 To Me.GoodTable.DefaultView.Count - 1
                .Rows.Append()
                PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(Me.GoodTable.DefaultView(i)("rowNum")), nullText)
                PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(Me.GoodTable.DefaultView(i)("nameCon")), nullText)
                If i = 0 OrElse C2.ToText(Me.GoodTable.DefaultView(i)("description")) <> C2.ToText(Me.GoodTable.DefaultView(i - 1)("description")) Then
                    ' если текущее техническое описание не совпадает с предыдущим - вставка технического описания
                    PutRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(Me.GoodTable.DefaultView(i)("description")), nullText)
                End If
            Next
            If .Rows.Count > 2 Then
                .Rows.LastOrDefault.Delete()
                ' Объединение ячеек с одинаковым техническими описаниями
                iTmp = 1
                For i As Integer = 1 To .Rows.Count - 1
                    If String.IsNullOrWhiteSpace(R.Document.GetText(.Cell(i, 2).ContentRange)) Then
                        .MergeCells(.Cell(iTmp, 2), .Cell(i, 2))
                    Else
                        iTmp = i
                    End If
                Next
            Else
                ' Нет данных
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 2).ContentRange, Nothing, nullText)
            End If
        End With
        With R.Document.Tables(4)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).ContentRange.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 2).ContentRange.Start).Alignment = ParagraphAlignment.Left
            '
            ' Вставка данных
            '
            Me.GoodTable.DefaultView.Sort = "rowNum, nameCon"
            For i As Integer = 0 To Me.GoodTable.DefaultView.Count - 1
                .Rows.Append()
                PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(Me.GoodTable.DefaultView(i)("rowNum")), nullText)
                If i = 0 OrElse C2.ToText(Me.GoodTable.DefaultView(i)("areaUsed")) <> C2.ToText(Me.GoodTable.DefaultView(i - 1)("areaUsed")) Then
                    ' если текущее назначение и область применения не совпадает с предыдущим - вставка назначения и области применения
                    PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(Me.GoodTable.DefaultView(i)("area")), nullText)
                    PutRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(Me.GoodTable.DefaultView(i)("used")), nullText)
                End If
            Next
            If .Rows.Count > 2 Then
                .Rows.LastOrDefault.Delete()
                ' Объединение ячеек с одинаковым назначение и областью применения
                iTmp = 1
                For i As Integer = 1 To .Rows.Count - 1
                    If String.IsNullOrWhiteSpace(R.Document.GetText(.Cell(i, 1).ContentRange)) Then
                        .MergeCells(.Cell(iTmp, 1), .Cell(i, 1))
                        .MergeCells(.Cell(iTmp, 2), .Cell(i, 2))
                    Else
                        iTmp = i
                    End If
                Next
            Else
                ' Нет данных
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 2).ContentRange, Nothing, nullText)
            End If
        End With

        ' 6. Пояснения эксперта
        PutBookmark(R.Document, "Comment", C2.ToText(Me.ARow("comment")), nullText)

        ' 7. Общие выводы по результатам идентификации
        PutBookmark(R.Document, "Summary", C2.ToText(Me.ARow("summary")), nullText)

        ' Штам ЭП (предварительно)
        PutBookmark(R.Document, "SertNum", "-")
        PutBookmark(R.Document, "SertName", "-")
        PutBookmark(R.Document, "SertTerm", "-")

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
        ' Сохранение содержимого проекта документа
        '
        Me.ARow("doc1Data") = R.Document.OpenXmlBytes
        Me.ARow("doc1SummaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsFreedom)

        R.Dispose()

    End Sub

#Region "Заказчик экспертизы"

    ''' <summary>
    ''' Наименование и реквизиты заказчика экспертизы
    ''' </summary>
    Private Function GetClientCaption() As String
        Dim sTmp As String = String.Format("{0}, {1}, ИНН: {2}", C2.ToText(Me("clientName")), C2.ToText(Me("clientAddress")), C2.ToText(Me("clientInn")))
        If C2.IsText(Me("clientPhone")) Then sTmp = String.Format("{0}, тел: {1}", sTmp, C2.ToText(Me("clientPhone")))
        If C2.IsText(Me("clientFax")) Then sTmp = String.Format("{0}, факс: {1}", sTmp, C2.ToText(Me("clientFax")))
        Return sTmp
    End Function

#End Region
#Region "Обработка полей таблицы объектов экспертизы"

    ''' <summary>
    ''' Обновить содержимое полей таблицы объектов экспертизы
    ''' </summary>
    Private Sub GoodTableFieldUpdate()
        For Each Row As DataRow In Me.GoodTable.Rows
            GoodRowUpdateClassificator(Row)
            GoodRowUpdateAreaUsed(Row)
            GoodRowUpdateDocList(Row)
        Next
    End Sub

    ''' <summary>
    ''' Обновить сведения о Классификаторе ПВН строки таблицы объектов экспертизы
    ''' </summary>
    ''' <param name="GoodRow">Строка таблицы объектов экспертизы</param>
    Private Sub GoodRowUpdateClassificator(GoodRow As DataRow)
        If GoodRow Is Nothing OrElse GoodRow.Table Is Nothing OrElse Not GoodRow.Table Is Me.GoodTable Then Exit Sub
        GoodRow("catNum") = "-"
        GoodRow("catDescription") = "Категорий Классификатора, имеющих признаки сходства с объектом экспертизы не имеется"
        Dim LRow As DataRow = Me.LawDataSet.LawTable.Rows.Find(C2.ToInt(GoodRow("lawId")))
        If LRow Is Nothing Then Exit Sub
        GoodRow("catNum") = C2.ToText(LRow("pos"))
        Dim sTmp As String = C2.ToText(LRow("description"))
        LRow = Me.LawDataSet.LawTable.Rows.Find(C2.ToInt(LRow("parentId")))
        Do
            If LRow Is Nothing OrElse CType(LRow("typeId"), Cprp.DxData.Law.TypeEnum) <> Law.TypeEnum.IsParagraph Then Exit Do
            sTmp = String.Format("{0}{1}{2}", C2.ToText(LRow("description")), vbCrLf, sTmp)
            LRow = Me.LawDataSet.LawTable.Rows.Find(C2.ToText(LRow("parentId")))
        Loop
        GoodRow("catDescription") = sTmp
    End Sub

    ''' <summary>
    ''' Обновить назначение и область применения строки таблицы объектов экспертизы
    ''' </summary>
    ''' <param name="GoodRow">Строка таблицы объектов экспертизы</param>
    Private Sub GoodRowUpdateAreaUsed(GoodRow As DataRow)
        If GoodRow Is Nothing OrElse GoodRow.Table Is Nothing OrElse Not GoodRow.Table Is Me.GoodTable Then Exit Sub
        GoodRow("areaUsed") = DBNull.Value
        Dim area As String = C2.DelPoint(GoodRow("area"))
        If Not C2.IsText(area) Then area = C2.DelPoint(Me.ARow("goodArea"))
        If C2.IsText(area) Then area = String.Format("Область применения: {0}. ", area)
        Dim used = C2.DelPoint(GoodRow("used"))
        If Not C2.IsText(used) Then used = C2.DelPoint(Me.ARow("goodUsed"))
        If C2.IsText(used) Then used = String.Format("Назначение: {0}", used)
        If C2.IsText(area) OrElse C2.IsText("used") Then GoodRow("areaUsed") = C2.DelPoint(area & used)
    End Sub

    ''' <summary>
    ''' Обновить список документов, подтверждающих гражданское назначение строки таблицы объектов экспертизы
    ''' </summary>
    ''' <param name="GoodRow">Строка таблицы объектов экспертизы</param>
    Private Sub GoodRowUpdateDocList(GoodRow As DataRow)
        If GoodRow Is Nothing OrElse GoodRow.Table Is Nothing OrElse Not GoodRow.Table Is Me.GoodTable Then Exit Sub
        GoodRow("docList") = DBNull.Value
        Dim sTmp As String = "0"
        Using V As DataView = Me.GoodInDocTable.GoodView(GoodRow("id"))
            For Each VRow As DataRowView In V
                sTmp = String.Format("{0}, {1}", sTmp, CInt(VRow("docId")))
            Next
        End Using
        Using V As New DataView(Me.InDocTable) With {.RowFilter = String.Format("id IN ({0})", sTmp), .Sort = "rowNum"}
            sTmp = Nothing
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0};{1}{2}", sTmp, vbCrLf, Me.InDocTable.GetCaptionNumDate(V(i).Row))
            Next
        End Using
        If Not String.IsNullOrWhiteSpace(sTmp) Then GoodRow("docList") = C2.DbText(sTmp.Substring(3))
    End Sub

    ''' <summary>
    ''' Очистить столбец группировки таблицы объектов экспертизы от всех данных
    ''' </summary>
    Private Sub GoodTableGroupClear()
        For Each Row As DataRow In Me.GoodTable.Rows
            Row("groupText") = Nothing
        Next
    End Sub

    ''' <summary>
    ''' Группировка строк таблицы объектов экспертизы по одинаковым кодам ТН ВЭД и техническим описаниям
    ''' </summary>
    ''' <remarks> В поле groupText подставляется строка номеров объектов экспертизы с одинаковыми данными</remarks>
    Friend Sub GoodTableGroupByTnvedDescription()
        GoodTableGroupClear()
        Dim groupText As String = Nothing
        Dim sTmp As String = Nothing
        With Me.GoodTable
            For i As Integer = 0 To .Rows.Count - 1
                '
                ' Формирование строки порядковых номеров строк с одинаковыми данными
                '
                If Not IsDBNull(.Rows(i)("groupText")) Then Continue For
                .Rows(i)("groupText") = "N"
                groupText = C2.ToText(.Rows(i)("rowNum")) & C2.FIELD_SEPARATOR
                sTmp = C2.ToText(.Rows(i)("tnved")) & C2.ToText(.Rows(i)("description"))
                For j As Integer = i + 1 To .Rows.Count - 1
                    If Not IsDBNull(.Rows(j)("groupText")) Then Continue For
                    If sTmp <> (C2.ToText(.Rows(j)("tnved")) & C2.ToText(.Rows(j)("description"))) Then Continue For
                    .Rows(j)("groupText") = "N"
                    groupText &= C2.ToText(.Rows(j)("rowNum")) & C2.FIELD_SEPARATOR
                Next
                '
                ' Запись строки в поле группировки строк с одинаковыми данными
                '
                groupText = C2.ToStrNum(groupText, True)
                For k As Integer = 0 To .Rows.Count - 1
                    If C2.ToText(.Rows(k)("groupText")) = "N" Then
                        .Rows(k)("groupText") = groupText
                    End If
                Next
            Next
        End With
    End Sub

    ''' <summary>
    ''' Группировка строк таблицы объектов экспертизы по одинаковым пунктам классификатора ПВН
    ''' </summary>
    ''' <remarks> В поле groupText подставляется строка номеров объектов экспертизы с одинаковыми данными</remarks>
    Friend Sub GoodTableGroupByClassificator()
        GoodTableGroupClear()
        Dim groupText As String = Nothing
        Dim sTmp As String = Nothing
        With Me.GoodTable
            For i As Integer = 0 To .Rows.Count - 1
                '
                ' Формирование строки порядковых номеров строк с одинаковыми данными
                '
                If Not IsDBNull(.Rows(i)("groupText")) Then Continue For
                .Rows(i)("groupText") = "N"
                groupText = C2.ToText(.Rows(i)("rowNum")) & C2.FIELD_SEPARATOR
                sTmp = C2.ToText(.Rows(i)("catNum"))
                For j As Integer = i + 1 To .Rows.Count - 1
                    If Not IsDBNull(.Rows(j)("groupText")) Then Continue For
                    If sTmp <> C2.ToText(.Rows(j)("catNum")) Then Continue For
                    .Rows(j)("groupText") = "N"
                    groupText &= C2.ToText(.Rows(j)("rowNum")) & C2.FIELD_SEPARATOR
                Next
                '
                ' Запись строки в поле группировки строк с одинаковыми данными
                '
                groupText = C2.ToStrNum(groupText, True)
                For k As Integer = 0 To .Rows.Count - 1
                    If C2.ToText(.Rows(k)("groupText")) = "N" Then
                        .Rows(k)("groupText") = groupText
                    End If
                Next
            Next
        End With
    End Sub

    ''' <summary>
    ''' Группировка строк таблицы объектов экспертизы по одинаковым областям применения и назначениям
    ''' </summary>
    ''' <remarks> В поле groupText подставляется строка номеров объектов экспертизы с одинаковыми данными</remarks>
    Friend Sub GoodTableGroupByAreaUsed()
        GoodTableGroupClear()
        Dim groupText As String = Nothing
        Dim sTmp As String = Nothing
        With Me.GoodTable
            For i As Integer = 0 To .Rows.Count - 1
                '
                ' Формирование строки порядковых номеров строк с одинаковыми данными
                '
                If Not IsDBNull(.Rows(i)("groupText")) Then Continue For
                .Rows(i)("groupText") = "N"
                groupText = C2.ToText(.Rows(i)("rowNum")) & C2.FIELD_SEPARATOR
                sTmp = C2.ToText(.Rows(i)("areaUsed"))
                For j As Integer = i + 1 To .Rows.Count - 1
                    If Not IsDBNull(.Rows(j)("groupText")) Then Continue For
                    If sTmp <> C2.ToText(.Rows(j)("areaUsed")) Then Continue For
                    .Rows(j)("groupText") = "N"
                    groupText &= C2.ToText(.Rows(j)("rowNum")) & C2.FIELD_SEPARATOR
                Next
                '
                ' Запись строки в поле группировки строк с одинаковыми данными
                '
                groupText = C2.ToStrNum(groupText, True)
                For k As Integer = 0 To .Rows.Count - 1
                    If C2.ToText(.Rows(k)("groupText")) = "N" Then
                        .Rows(k)("groupText") = groupText
                    End If
                Next
            Next
        End With
    End Sub

    ''' <summary>
    ''' Группировка строк таблицы объектов экспертизы по одинаковым областям применения, назначениям и подтверждающим документам
    ''' </summary>
    ''' <remarks> В поле groupText подставляется строка номеров объектов экспертизы с одинаковыми данными</remarks>
    Friend Sub GoodTableGroupByAreaUsedDocList()
        GoodTableGroupClear()
        Dim groupText As String = Nothing
        Dim sTmp As String = Nothing
        With Me.GoodTable
            For i As Integer = 0 To .Rows.Count - 1
                '
                ' Формирование строки порядковых номеров строк с одинаковыми данными
                '
                If Not IsDBNull(.Rows(i)("groupText")) Then Continue For
                .Rows(i)("groupText") = "N"
                groupText = C2.ToText(.Rows(i)("rowNum")) & C2.FIELD_SEPARATOR
                sTmp = C2.ToText(.Rows(i)("areaUsed")) & C2.ToText(.Rows(i)("docList"))
                For j As Integer = i + 1 To .Rows.Count - 1
                    If Not IsDBNull(.Rows(j)("groupText")) Then Continue For
                    If sTmp <> (C2.ToText(.Rows(j)("areaUsed")) & C2.ToText(.Rows(j)("docList"))) Then Continue For
                    .Rows(j)("groupText") = "N"
                    groupText &= C2.ToText(.Rows(j)("rowNum")) & C2.FIELD_SEPARATOR
                Next
                '
                ' Запись строки в поле группировки строк с одинаковыми данными
                '
                groupText = C2.ToStrNum(groupText, True)
                For k As Integer = 0 To .Rows.Count - 1
                    If C2.ToText(.Rows(k)("groupText")) = "N" Then
                        .Rows(k)("groupText") = groupText
                    End If
                Next
            Next
        End With
    End Sub

#End Region

End Class
