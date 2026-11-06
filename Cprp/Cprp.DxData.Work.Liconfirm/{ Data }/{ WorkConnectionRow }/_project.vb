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
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing                   ' Документ
        Dim TGood As ProjectGoodDataTable = Nothing                                         ' Таблица объектов экспертизы
        Dim mode As Cprp.DxData.ModeEnum = DxData.ModeEnum.isExport                         ' Направление перемещения
        Dim nullText As String = "[нет данных]"                                             ' Стандартное сообщение об ошибке, выводящееся в документ вместо пустых значений
        Dim Row As DataRow, sTmp As String, iTmp As Integer

        ' ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        ' ++++++++++++++++++++++++
        '
        R = New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.Unit = DevExpress.Office.DocumentUnit.Document
        R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
        TGood = New ProjectGoodDataTable(Me)

        ' Сведения о лицензии
        Row = Me.LicenseTable.Rows.Find(C2.ToInt(Me.ARow("licId")))

        ' ЗАГРУЗКА ШАБЛОНА ЗАКЛЮЧЕНИЯ И ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Загрузка шаблона заключения
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ПОДТВЕРЖДЕНИЕЛИЦЕНЗИИЗАКЛЮЧЕНИЕ", Me.Connection)
        'R.LoadDocument("d:\1.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        R.Document.BeginUpdate()

        ' Номер и дата заключения - тело документа
        PutBookmark(R.Document, "DocNum", Nothing, "[Проект]")
        PutBookmark(R.Document, "DocDate", String.Format("{0:d MMMM yyyy} г.", Date.Today), nullText)
        PutBookmark(R.Document, "DocNum3", Nothing, "[Проект]")
        PutBookmark(R.Document, "DocDate3", String.Format("{0:d MMMM yyyy} г.", Date.Today), nullText)

        ' Номер и дата заключения - колонтитул
        Dim Hd As SubDocument = R.Document.Sections(0).BeginUpdateHeader
        PutBookmark(Hd, "DocNum2", Nothing, "[Проект]")
        PutBookmark(Hd, "DocDate2", String.Format("{0:dd.MM.yyyy}", Date.Today), "{00.00.0000}")
        R.Document.Sections(0).EndUpdateHeader(Hd)

        ' 2. Сведения о внешнеэкономической операции
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.AddPoint(Row("description"))
        PutRange(R.Document.Bookmarks("SupplyDescription").Range, sTmp, nullText)

        ' 2.1. Документ, на основании которого осуществляется внешнеэкономическая операция
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.AddPoint(Row("contractName"))
        PutRange(R.Document.Bookmarks("ContractCaption").Range, sTmp, nullText)

        ' 2.2. Страна назначения (отправления)
        sTmp = If(mode = Cprp.DxData.ModeEnum.isExport, "назначения", "отправления")
        PutRange(R.Document.Bookmarks("CountryMode").Range, sTmp)
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.AddPoint(Row("countryName"))
        PutRange(R.Document.Bookmarks("CountryName").Range, sTmp, nullText)

        ' 2.3. Российские участники внешнеэкономической операции
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.AddPoint(Row("rusName"))
        PutRange(R.Document.Bookmarks("RusCaption").Range, sTmp, nullText)

        ' 2.4.1. Покупатель (продавец)
        PutRange(R.Document.Bookmarks("NusMode").Range, If(mode = Cprp.DxData.ModeEnum.isExport, "Покупатель", "Продавец"))
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.AddPoint(Row("nusName"))
        PutRange(R.Document.Bookmarks("NusCaption").Range, sTmp, nullText)

        ' 2.4.2. Потребитель (конечный пользователь)
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.AddPoint(Row("endName"))
        PutRange(R.Document.Bookmarks("EndCaption").Range, sTmp, nullText)

        ' 3. Сведения об идентифицируемых товарах и идентифицируемых продуктах научно-технической деятельности
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
        End With

        ' 4. Установление соответствия идентифицируемых объектов научно-технической деятельности технологиям, включенным в лицензию ФСТЭК России
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
            TGood.GroupByStudy()
            TGood.DefaultView.Sort = "groupText"
            For i As Integer = 0 To TGood.DefaultView.Count - 1
                If i > 0 AndAlso C2.ToText(TGood.DefaultView(i)("groupText")) = C2.ToText(TGood.DefaultView(i - 1)("groupText")) Then Continue For
                .Rows.Append()
                PutRange(.Cell(.Rows.Count - 2, 0).ContentRange, C2.ToText(TGood.DefaultView(i)("groupText")), nullText)
                PutRange(.Cell(.Rows.Count - 2, 1).ContentRange, C2.ToText(TGood.DefaultView(i)("licDescription")), nullText)
                PutRange(.Cell(.Rows.Count - 2, 2).ContentRange, C2.ToText(TGood.DefaultView(i)("goodDescription")), nullText)
                sTmp = "Соответствует"
                If Not C2.IsText(TGood.DefaultView(i)("licDescription")) Then sTmp = Nothing
                If Not C2.IsText(TGood.DefaultView(i)("goodDescription")) Then sTmp = Nothing
                PutRange(.Cell(.Rows.Count - 2, 3).ContentRange, sTmp, nullText)
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

        ' Номера и даты лицензий (в 2-х местах)
        '
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = String.Format("от {0:dd.MM.yyyy} № {1}", CDate(Row("regDate")), C2.ToText(Row("regNum")))
        If Not C2.IsText(sTmp) Then
            PutRange(R.Document.Bookmarks("licCaption").Range, Nothing, nullText)
            PutRange(R.Document.Bookmarks("licCaption2").Range, Nothing, nullText)
        Else
            PutRange(R.Document.Bookmarks("licCaption").Range, String.Format("лицензию ФСТЭК России {0}", sTmp), nullText)
            PutRange(R.Document.Bookmarks("licCaption2").Range, String.Format("приложении к лицензии ФСТЭК России {0}", sTmp), nullText)
        End If

        TGood.Dispose()

        ' 5. Общие выводы по результатам идентификации
        '
        Using V As New DataView(Me.GoodTable)
            V.RowFilter = "isCheckLic = False"
            If V.Count > 0 Then
                PutRange(R.Document.Bookmarks("Summary").Range, Nothing, nullText)
                Me.ARow("summaryText") = DBNull.Value
            Else
                Me.ARow("summaryText") = C2.ToText(R.Document.GetText(R.Document.Bookmarks("Summary").Range))
            End If
        End Using

        ' 6. Дополнительная информация
        '
        PutRange(R.Document.Bookmarks("Comment").Range, C2.AddPoint(Me.ARow("comment")))

        ' 7. Штам ЭП (предварительно)
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
        Me.ARow("doc1SummaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsLicense)

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
                .Add("tnved", GetType(String))              ' код ТН ВЭД
                .Add("description", GetType(String))        ' техническое описание + назначение + область применения
                .Add("licAppId", GetType(Integer))          ' id пункта приложения к лицензии
                .Add("goodDescription", GetType(String))    ' технические характеристики для сравнения с пунктом лицензии
                .Add("licDescription", GetType(String))     ' описание пункта приложения к лицензии
                .Add("groupText", GetType(String))          ' группировка строк по какому-нибудь признаку
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
            '
            ' Данные 
            '
            Dim GoodRow As DataRow = Nothing
            Dim AppRow As DataRow = Nothing
            Dim sTmp As String, sTmp1 As String
            Using VGoodAppend As New DataView(Work.GoodAppendTable)
                VGoodAppend.Sort = "appendId"
                For Each Row As DataRow In Work.GoodTable.Rows
                    GoodRow = Me.NewRow
                    GoodRow("id") = Row("id")
                    GoodRow("rowNum") = Row("rowNum")
                    GoodRow("nameCon") = Row("nameCon")
                    GoodRow("tnved") = Row("tnved")
                    GoodRow("licAppId") = Row("licAppId")
                    GoodRow("goodDescription") = Row("goodDescription")
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
                    '
                    ' Описания пунктов приложения к лицензии
                    '
                    sTmp = Nothing
                    VGoodAppend.RowFilter = String.Format("goodId = {0}", CInt(GoodRow("id")))
                    For i As Integer = 0 To VGoodAppend.Count - 1
                        AppRow = Work.LicenseAppendTable.Rows.Find(CInt(VGoodAppend(i)("appendId")))
                        If AppRow Is Nothing Then Continue For
                        sTmp = String.Format("{0}{1}{2} {3}", sTmp, vbCrLf, C2.AddPoint(AppRow("pos")), C2.DelPoint(AppRow("description")))
                    Next
                    If C2.IsText(sTmp) Then
                        GoodRow("licDescription") = sTmp.Substring(2)
                    Else
                        GoodRow("licDescription") = DBNull.Value
                    End If
                    Me.Rows.Add(GoodRow)
                Next
            End Using
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
            Dim tnved As String = Nothing
            Dim description As String = Nothing
            For i As Integer = 0 To Me.Rows.Count - 1
                '
                ' Формирование строки порядковых номеров строк с одинаковыми данными
                '
                If Not IsDBNull(Me(i)("groupText")) Then Continue For
                Me(i)("groupText") = "N"
                groupText = C2.ToText(Me(i)("rowNum")) & C2.FIELD_SEPARATOR
                tnved = C2.ToText(Me(i)("tnved"))
                description = C2.ToText(Me(i)("description"))
                For j As Integer = i + 1 To Me.Rows.Count - 1
                    If Not IsDBNull(Me(j)("groupText")) Then Continue For
                    If tnved <> C2.ToText(Me(j)("tnved")) Then Continue For
                    If description <> C2.ToText(Me(j)("description")) Then Continue For
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

        ''' <summary>
        ''' Группировка строк по одинаковым пунктам лицензий и одинаковым техническим характеристикам
        ''' </summary>
        ''' <remarks>В поле groupText подставляется строка номеров объектов экспертизы с одинаковыми данными</remarks>
        Friend Sub GroupByStudy()
            MyClass.GroupClear()
            Dim groupText As String = Nothing
            Dim licDescription As String = Nothing
            Dim goodDescription As String = Nothing
            For i As Integer = 0 To Me.Rows.Count - 1
                '
                ' Формирование строки порядковых номеров строк с одинаковыми данными
                '
                If Not IsDBNull(Me(i)("groupText")) Then Continue For
                Me(i)("groupText") = "N"
                groupText = C2.ToText(Me(i)("rowNum")) & C2.FIELD_SEPARATOR
                licDescription = C2.ToText(Me(i)("licDescription"))
                goodDescription = C2.ToText(Me(i)("goodDescription"))
                For j As Integer = i + 1 To Me.Rows.Count - 1
                    If Not IsDBNull(Me(j)("groupText")) Then Continue For
                    If licDescription <> C2.ToText(Me(j)("licDescription")) Then Continue For
                    If goodDescription <> C2.ToText(Me(j)("goodDescription")) Then Continue For
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
