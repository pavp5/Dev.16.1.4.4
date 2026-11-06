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
        Dim TGood As ProjectGoodDataTable = Nothing                             ' Таблица объектов экспертизы из проекта заключения
        Dim nullText As String = "{нет данных}"
        Dim sTmp As String = Nothing

        ' ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        ' ++++++++++++++++++++++++
        '
        R = New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.Unit = DevExpress.Office.DocumentUnit.Document
        R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
        TGood = New ProjectGoodDataTable(Me)

        ' ЗАГРУЗКА ШАБЛОНА ЗАКЛЮЧЕНИЯ И ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Загрузка шаблона заключения
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ОПРЕДЕЛЕНИЕКОДАЗАКЛЮЧЕНИЕ", Me.Connection)

        ' Номер и дата заключения - тело документа
        PutBookmark(R.Document, "DocNum", Nothing, "{Проект}")
        PutBookmark(R.Document, "DocDate", String.Format("{0:dd.MM.yyyy}", Date.Today), nullText)

        ' Номер и дата заключения - колонтитул
        Dim Hd As SubDocument = R.Document.Sections(0).BeginUpdateHeader
        PutBookmark(Hd, "DocNum2", Nothing, "{Проект}")
        PutBookmark(Hd, "DocDate2", String.Format("{0:dd.MM.yyyy}", Date.Today), "{00.00.0000}")
        R.Document.Sections(0).EndUpdateHeader(Hd)

        ' Наименование, ИНН, КПП заказачика
        sTmp = C2.ToText(Me("clientName"))
        If C2.IsText(sTmp) Then
            If C2.IsText(Me("clientInn")) Then
                sTmp = String.Format("{0}<br>ИНН {2}", sTmp, vbCrLf, C2.ToText(Me("clientInn")))
                If C2.IsText(Me("clientKpp")) Then sTmp = String.Format("{0}, КПП {1}", sTmp, C2.ToText(Me("clientKpp")))
            End If
        End If
        PutHtmlRange(R.Document.Bookmarks("ClientCaption").Range, sTmp, nullText)

        ' Адрес заказчика
        PutBookmark(R.Document, "ClientAddress", C2.ToText(Me("clientAddress")), nullText)

        ' Номер заказа
        sTmp = C2.ToText(Me("orderNum"))
        PutBookmark(R.Document, "OrderNum", sTmp, nullText)

        ' Дата заказа
        sTmp = Nothing
        If Not IsDBNull(Me("orderDate")) Then sTmp = String.Format("{0:dd.MM.yyyy}", CDate(Me("orderDate")))
        PutBookmark(R.Document, "OrderDate", sTmp, nullText)

        ' Перечень объектов экспертизы
        '
        With R.Document.Tables(1)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).ContentRange.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 2).ContentRange.Start).Alignment = ParagraphAlignment.Left
            '
            ' Вставка данных
            '
            TGood.DefaultView.Sort = "rowNum, nameCon"
            For i As Integer = 0 To TGood.DefaultView.Count - 1
                .Rows.Append()
                PutHtmlRange(.Cell(i + 1, 0).ContentRange, C2.ToText(TGood.DefaultView(i)("rowNum")))
                PutHtmlRange(.Cell(i + 1, 1).ContentRange, C2.ToText(TGood.DefaultView(i)("nameCon")))
                PutHtmlRange(.Cell(i + 1, 2).ContentRange, C2.ToText(TGood.DefaultView(i)("nameDec")))
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

        ' Рекомендуемые коды ТН ВЭД ЕАЭС
        '
        With R.Document.Tables(2)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).ContentRange.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 2).ContentRange.Start).Alignment = ParagraphAlignment.Left
            '
            ' Группировка данных по кодам и пояснениям
            '
            TGood.GroupByTnvedDescription()
            '
            ' Очистка полей с повторяющимися группировками
            '
            With TGood.DefaultView
                .Sort = "rowNum"
                For i As Integer = 0 To .Count - 1
                    sTmp = C2.ToText(.Item(i)("groupText"))
                    If Not C2.IsText(sTmp) Then Continue For
                    For j = i + 1 To .Count - 1
                        If C2.ToText(.Item(j)("groupText")) = sTmp Then .Item(j)("groupText") = DBNull.Value
                    Next
                Next
            End With
            '
            ' Вставка данных
            '
            TGood.DefaultView.Sort = "rowNum"
            For i As Integer = 0 To TGood.DefaultView.Count - 1
                If Not C2.IsText(TGood.DefaultView(i)("groupText")) Then Continue For
                .Rows.Append()
                PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(TGood.DefaultView(i)("groupText")), nullText)
                PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(TGood.DefaultView(i)("description")), nullText)
                PutHtmlRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(TGood.DefaultView(i)("tnvedHtml")), nullText)
            Next
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

        ' Перечень представленных документов
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
            Using V As New DataView(Me.InDocTable)
                V.RowFilter = "isUsed = True"
                V.Sort = "rowNum, caption"
                For i As Integer = 0 To V.Count - 1
                    .Rows.Append()
                    PutRange(.Cell(i + 1, 0).ContentRange, i + 1)
                    PutRange(.Cell(i + 1, 1).ContentRange, C2.ToText(V(i)("caption")), nullText)
                    sTmp = C2.ToText(V(i)("regNum"))
                    If Not C2.IsText(sTmp) Then sTmp = "б/н"
                    If Not IsDBNull(V(i)("regDate")) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(V(i)("regDate")))
                    PutHtmlRange(.Cell(i + 1, 2).ContentRange, sTmp)
                Next
            End Using
            If .Rows.Count > 2 Then
                .Rows.LastOrDefault.Delete()
            Else
                ' Нет данных
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 2).ContentRange, Nothing, nullText)
            End If
        End With

        ' Штам ЭП (предварительно)
        PutBookmark(R.Document, "SertNum", "-")
        PutBookmark(R.Document, "SertName", "-")
        PutBookmark(R.Document, "SertTerm", "-")


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


    ''' <summary>
    ''' Создать проект итогового документа для ЭксКонт
    ''' </summary>
    ''' <param name="filePath">Путь к месту сохранения файла документа</param>
    ''' <remarks></remarks>
    Public Sub ProjectCreateExcont(filePath As String)

        ' ПЕРЕМЕННЫЕ
        ' ++++++++++
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing       ' Документ
        Dim TGood As ProjectGoodDataTable = Nothing                             ' Таблица объектов экспертизы из проекта заключения
        Dim nullText As String = "{нет данных}"
        Dim sTmp As String = Nothing

        ' ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        ' ++++++++++++++++++++++++
        '
        R = New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.Unit = DevExpress.Office.DocumentUnit.Document
        R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
        TGood = New ProjectGoodDataTable(Me)

        ' ЗАГРУЗКА ШАБЛОНА ЗАКЛЮЧЕНИЯ И ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Загрузка шаблона заключения
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ОПРЕДЕЛЕНИЕКОДАЭКСКОНТКОНСУЛЬТАЦИЯ", Me.Connection)
        'R.LoadDocument("d:\ОПРЕДЕЛЕНИЕКОДАЭКСКОНТКОНСУЛЬТАЦИЯ.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)

        ' Наименование, ИНН, КПП заказачика
        sTmp = C2.ToText(Me("clientName"))
        If C2.IsText(sTmp) Then
            If C2.IsText(Me("clientInn")) Then
                sTmp = String.Format("{0}<br>ИНН {2}", sTmp, vbCrLf, C2.ToText(Me("clientInn")))
                If C2.IsText(Me("clientKpp")) Then sTmp = String.Format("{0}, КПП {1}", sTmp, C2.ToText(Me("clientKpp")))
            End If
        End If
        PutHtmlRange(R.Document.Bookmarks("ClientCaption").Range, sTmp, nullText)

        ' Адрес заказчика
        PutBookmark(R.Document, "ClientAddress", C2.ToText(Me("clientAddress")), nullText)

        ' Номер заказа
        sTmp = C2.ToText(Me("orderNum"))
        PutBookmark(R.Document, "OrderNum", sTmp, nullText)

        ' Дата заказа
        sTmp = Nothing
        If Not IsDBNull(Me("orderDate")) Then sTmp = String.Format("{0:dd.MM.yyyy}", CDate(Me("orderDate")))
        PutBookmark(R.Document, "OrderDate", sTmp, nullText)

        ' Перечень объектов экспертизы
        '
        With R.Document.Tables(1)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).ContentRange.Start).Alignment = ParagraphAlignment.Left
            'R.Document.Paragraphs.Get(.Cell(1, 2).ContentRange.Start).Alignment = ParagraphAlignment.Left
            '
            ' Вставка данных
            '
            TGood.DefaultView.Sort = "rowNum, nameCon"
            For i As Integer = 0 To TGood.DefaultView.Count - 1
                .Rows.Append()
                PutHtmlRange(.Cell(i + 1, 0).ContentRange, C2.ToText(TGood.DefaultView(i)("rowNum")))
                PutHtmlRange(.Cell(i + 1, 1).ContentRange, C2.ToText(TGood.DefaultView(i)("nameCon")))
                'PutHtmlRange(.Cell(i + 1, 2).ContentRange, C2.ToText(TGood.DefaultView(i)("nameDec")))
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

        ' Рекомендуемые коды ТН ВЭД ЕАЭС
        '
        With R.Document.Tables(2)
            '
            ' Выравнивание первой строки таблицы
            '
            R.Document.Paragraphs.Get(.Cell(1, 0).ContentRange.Start).Alignment = ParagraphAlignment.Center
            R.Document.Paragraphs.Get(.Cell(1, 1).ContentRange.Start).Alignment = ParagraphAlignment.Left
            R.Document.Paragraphs.Get(.Cell(1, 2).ContentRange.Start).Alignment = ParagraphAlignment.Left
            '
            ' Группировка данных по кодам и пояснениям
            '
            TGood.GroupByTnvedDescription()
            '
            ' Очистка полей с повторяющимися группировками
            '
            With TGood.DefaultView
                .Sort = "rowNum"
                For i As Integer = 0 To .Count - 1
                    sTmp = C2.ToText(.Item(i)("groupText"))
                    If Not C2.IsText(sTmp) Then Continue For
                    For j = i + 1 To .Count - 1
                        If C2.ToText(.Item(j)("groupText")) = sTmp Then .Item(j)("groupText") = DBNull.Value
                    Next
                Next
            End With
            '
            ' Вставка данных
            '
            TGood.DefaultView.Sort = "rowNum"
            For i As Integer = 0 To TGood.DefaultView.Count - 1
                If Not C2.IsText(TGood.DefaultView(i)("groupText")) Then Continue For
                .Rows.Append()
                PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(TGood.DefaultView(i)("groupText")), nullText)
                PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(TGood.DefaultView(i)("description")), nullText)
                PutHtmlRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(TGood.DefaultView(i)("tnvedHtml")), nullText)
            Next
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

        ' Перечень представленных документов
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
            Using V As New DataView(Me.InDocTable)
                V.RowFilter = "isUsed = True"
                V.Sort = "rowNum, caption"
                For i As Integer = 0 To V.Count - 1
                    .Rows.Append()
                    PutRange(.Cell(i + 1, 0).ContentRange, i + 1)
                    PutRange(.Cell(i + 1, 1).ContentRange, C2.ToText(V(i)("caption")), nullText)
                    sTmp = C2.ToText(V(i)("regNum"))
                    If Not C2.IsText(sTmp) Then sTmp = "б/н"
                    If Not IsDBNull(V(i)("regDate")) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(V(i)("regDate")))
                    PutHtmlRange(.Cell(i + 1, 2).ContentRange, sTmp)
                Next
            End Using
            If .Rows.Count > 2 Then
                .Rows.LastOrDefault.Delete()
            Else
                ' Нет данных
                PutRange(.Cell(1, 0).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 1).ContentRange, Nothing, nullText)
                PutRange(.Cell(1, 2).ContentRange, Nothing, nullText)
            End If
        End With

        ' Завершение редактирования документа
        R.Document.EndUpdate()

        ' СОХРАНЕНИЕ ДОКУМЕНТА В ФАЙЛ
        ' +++++++++++++++++++++++++++
        '
        R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)

        R.Dispose()

    End Sub


    ''' <summary>
    ''' Таблица объектов экспертизы для одного проекта заключения
    ''' </summary>
    ''' <remarks></remarks>
    Private Class ProjectGoodDataTable : Inherits DataTable

        ''' <summary>
        ''' New
        ''' </summary>
        ''' <param name="Work">Работа</param> 
        ''' <remarks></remarks>
        Friend Sub New(Work As WorkConnectionRow)
            '
            ' Структура
            '
            MyBase.New()
            With Me.Columns
                .Add("id", GetType(Integer))                ' id
                .Add("rowNum", GetType(Integer))            ' порядковый номер в списке объектов экспертизы
                .Add("nameCon", GetType(String))            ' коммерческое наименование
                .Add("nameDec", GetType(String))            ' обозначение
                .Add("tnvedHtml", GetType(String))          ' код ТН ВЭД + описание кода + комментарий по определению кода в формате Html
                .Add("description", GetType(String))        ' техническое описание + назначение + область применения
                .Add("groupText", GetType(String))          ' группировка строк по какому-нибудь признаку
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
            '
            ' Данные 
            '
            Dim GoodRow As DataRow = Nothing
            Dim sTmp As String, sTmp1 As String
            For Each Row As DataRow In Work.GoodTable.Rows
                GoodRow = Me.NewRow
                GoodRow("id") = Row("id")
                GoodRow("rowNum") = Row("rowNum")
                GoodRow("nameCon") = Row("nameCon")
                GoodRow("nameDec") = Row("nameDec")
                '
                ' Код ТН ВЭД + описание кода + комментарий по определению кода
                '
                sTmp = C2.ToText(Row("tnved"))
                If C2.IsText(sTmp) Then
                    ' описание кода
                    sTmp1 = "<span style='font-weight:bold;color:#ff0000'>{описание кода осутствует в актуальной редакции товарной номенклатуры}</span>"
                    Using Dr As SqlDataReader = Work.ExecuteReader(String.Format( _
                        "SELECT description FROM tTnved WHERE code LIKE '{0}' AND dateB <= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND dateE > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                        sTmp.Replace("'", "''"), Date.Now))
                        If Dr.Read Then sTmp1 = C2.AddPoint(Dr(0))
                    End Using
                    sTmp = String.Format("{0} - {1}", sTmp, sTmp1)
                    sTmp1 = C2.ToText(Row("tnvedComment"))
                    If C2.IsText(sTmp1) Then sTmp = String.Format("{0}<br><i>Примечание:<br>{1}</i>", sTmp, sTmp1)
                    GoodRow("tnvedHtml") = sTmp
                End If
                '
                ' Техническое описание + назначение + область применения
                '
                sTmp = C2.ToText(Row("description"))
                If C2.IsText(sTmp) Then
                    ' техническое описание
                    sTmp = String.Format("{0}{1}", C2.AddPoint(sTmp), vbCrLf)
                    ' техническое описание + назначение
                    sTmp1 = C2.ToText(Row("used"))
                    If Not C2.IsText(sTmp1) Then sTmp1 = C2.ToText(Work.ARow("goodUsed"))
                    If C2.IsText(sTmp1) Then sTmp = String.Format("{0}Назначение: {1}{2}", sTmp, C2.AddPoint(sTmp1), vbCrLf)
                    ' техническое описание + назначение + область применения
                    sTmp1 = C2.ToText(Row("area"))
                    If Not C2.IsText(sTmp1) Then sTmp1 = C2.ToText(Work.ARow("goodArea"))
                    If C2.IsText(sTmp1) Then sTmp = String.Format("{0}Область применения: {1}{2}", sTmp, C2.AddPoint(sTmp1), vbCrLf)
                    GoodRow("description") = sTmp.Substring(0, sTmp.Length - 3)
                End If

                Me.Rows.Add(GoodRow)
            Next
        End Sub

        ' Очистить столбец группировки от всех данных
        Private Sub GroupClear()
            For Each Row As DataRow In Me.Rows
                Row("groupText") = Nothing
            Next
        End Sub

        ''' <summary>
        ''' Группировка строк по одинаковым кодам ТН ВЭД и техническим описаниям
        ''' </summary>
        ''' <remarks> поле groupText подставляется строка номеров объектов экспертизы с одинаковыми данными</remarks>
        Friend Sub GroupByTnvedDescription()
            MyClass.GroupClear()
            Dim groupText As String = Nothing
            Dim sTmp As String = Nothing
            For i As Integer = 0 To Me.Rows.Count - 1
                '
                ' Формирование строки порядковых номеров строк с одинаковыми данными
                '
                If Not IsDBNull(Me(i)("groupText")) Then Continue For
                Me(i)("groupText") = "N"
                groupText = C2.ToText(Me(i)("rowNum")) & C2.FIELD_SEPARATOR
                sTmp = C2.ToText(Me(i)("tnvedHtml")) & C2.ToText(Me(i)("description"))
                For j As Integer = i + 1 To Me.Rows.Count - 1
                    If Not IsDBNull(Me(j)("groupText")) Then Continue For
                    If sTmp <> (C2.ToText(Me(j)("tnvedHtml")) & C2.ToText(Me(j)("description"))) Then Continue For
                    Me(j)("groupText") = "N"
                    groupText &= C2.ToText(Me(j)("rowNum")) & C2.FIELD_SEPARATOR
                Next
                '
                ' Запись строки в поле группировки строк с одинаковыми данными
                '
                groupText = C2.ToStrNum(groupText, True)
                For k As Integer = 0 To Me.Rows.Count - 1
                    If C2.ToText(Me(k)("groupText")) = "N" Then
                        Me(k)("groupText") = groupText
                    End If
                Next
            Next
        End Sub

    End Class

End Class
