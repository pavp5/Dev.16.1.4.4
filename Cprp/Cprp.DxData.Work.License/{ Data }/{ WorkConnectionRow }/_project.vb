Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.API.Layout
Imports Cprp.DxData.Common
' ===========================================================
' Свойства и методы для работы с проектом итогового документа
' ===========================================================
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Создать проект итогового документа
    ''' </summary>
    Public Sub ProjectCreate()


        ' ПЕРЕМЕННЫЕ
        ' ++++++++++
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing                   ' Документ
        Dim nullText As String = "[нет данных]"                                             ' Стандартное сообщение об ошибке, выводящееся в документ вместо пустых значений
        Dim Row As DataRow, sTmp As String, sTmp1 As String

        ' ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        ' ++++++++++++++++++++++++
        '
        R = New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.Unit = DevExpress.Office.DocumentUnit.Document
        R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document


        '' ЗАГРУЗКА ШАБЛОНА ДОКУМЕНТА ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        '' ++++++++++++++++++++++++++++++++++++++++++++++++++++
        ''
        ' Загрузка шаблона документа
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ЗАЯВЛЕНИЕЛИЦЕНЗИЯ", Me.Connection)
        'R.LoadDocument("d:\1.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        R.Document.BeginUpdate()

        ' 1. ЗАЯВЛЕНИЕ О ПРЕДОСТАВЛЕНИИ ЛИЦЕНЗИ
        sTmp = Nothing
        If Not IsDBNull(Me.ARow("statDate")) Then sTmp = GetDocDate(CDate(Me.ARow("statDate")))
        PutBookmark(R.Document, "statDate", sTmp)
        PutBookmark(R.Document, "statNum", ToText(Me.ARow("statNum")))

        ' 2. Тип запрашиваемой лицензии
        sTmp = Nothing
        Row = Me.LicenseTypeHandbookTable.Rows.Find(ToInt(Me.ARow("licTypeId")))
        If Not Row Is Nothing Then sTmp = ToText(Row("name"))
        PutBookmark(R.Document, "licType", sTmp)

        ' 3. Заявитель (наименование и адрес)
        PutBookmark(R.Document, "clientName", ToText(Me.ARow("clientName")))
        PutBookmark(R.Document, "clientAddress", ToText(Me.ARow("clientAddress")))

        ' 4. Заявляемый срок действия лицензии
        sTmp = Nothing
        If Not IsDBNull(Me.ARow("licTerm")) Then sTmp = GetDocDate(CDate(Me.ARow("licTerm")))
        PutBookmark(R.Document, "licTerm", sTmp)

        ' 5. Контракт (договор)
        sTmp = Nothing
        If Not IsDBNull(Me.ARow("conDate")) Then
            sTmp = GetDocDate(CDate(Me.ARow("conDate")))
        Else
            sTmp = "Б/Д"
        End If
        PutBookmark(R.Document, "conDate", sTmp)
        sTmp = ToText(Me.ARow("conNum"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = "Б/Н"
        PutBookmark(R.Document, "conNum", sTmp)

        ' 6. Условия поставки
        sTmp = Nothing
        Row = Me.IncotermsHandbookTable.Rows.Find(ToInt(Me.ARow("incotermsId")))
        If Not Row Is Nothing Then sTmp = ToText(Row("name"))
        sTmp1 = ToText(Me.ARow("incotermsPlace"))
        sTmp = String.Format("{0}/{1}", sTmp, sTmp1)
        PutBookmark(R.Document, "incoterms", sTmp)

        ' 7. Покупатель/продавец (наименование и адрес)
        PutBookmark(R.Document, "bayerName", ToText(Me.ARow("bayerName")))
        PutBookmark(R.Document, "bayerAddress", ToText(Me.ARow("bayerAddress")))

        ' 8. Изготовитель/разработчик (наименование и адрес)
        PutBookmark(R.Document, "devName", ToText(Me.ARow("devName")))
        PutBookmark(R.Document, "devAddress", ToText(Me.ARow("devAddress")))

        ' 9. Конечный пользователь (наименование и адрес)
        PutBookmark(R.Document, "endName", ToText(Me.ARow("endName")))
        PutBookmark(R.Document, "endAddress", ToText(Me.ARow("endAddress")))

        ' 10. Страна происхождения
        sTmp = Nothing
        Row = Me.CountryHandbookTable.Rows.Find(ToInt(Me.ARow("devCountryId")))
        If Not Row Is Nothing Then sTmp = ToText(Row("nameShort"))
        PutBookmark(R.Document, "devCountry", sTmp)

        ' 11. Страна покупателя/продавца
        sTmp = Nothing
        Row = Me.CountryHandbookTable.Rows.Find(ToInt(Me.ARow("bayerCountryId")))
        If Not Row Is Nothing Then sTmp = ToText(Row("nameShort"))
        PutBookmark(R.Document, "bayerCountry", sTmp)

        ' 12. Страна (страны) транзита
        sTmp = "Маршрут доставки не опеделен"
        sTmp1 = ToText(Me.ARow("transitCountryIdString"))
        If Not String.IsNullOrWhiteSpace(sTmp1) Then
            Using V As New DataView(Me.CountryHandbookTable)
                V.RowFilter = String.Format("id IN ({0})", sTmp1)
                V.Sort = "nameShort"
                sTmp = ToText(V(0)("nameShort"))
                For i As Integer = 1 To V.Count - 1
                    sTmp = String.Format("{0}, {1}", sTmp, ToText(V(i)("nameShort")))
                Next
            End Using
        End If
        PutBookmark(R.Document, "transitCountry", sTmp)

        ' 13. Страна конечного использования
        sTmp = Nothing
        Row = Me.CountryHandbookTable.Rows.Find(ToInt(Me.ARow("endCountryId")))
        If Not Row Is Nothing Then sTmp = ToText(Row("nameShort"))
        PutBookmark(R.Document, "endCountry", sTmp)

        ' 14. Наименование и характеристика (описание) продукции
        PutBookmark(R.Document, "goodCaption", ToText(Me.ARow("goodCaption")))

        ' 15. Код ТН ВЭД
        PutBookmark(R.Document, "goodTnved", ToText(Me.ARow("goodTnved")))

        ' 16. Валюта контракта
        sTmp = Nothing
        Row = Me.CurrencyHandbookTable.Rows.Find(ToInt(Me.ARow("currencyId")))
        If Not Row Is Nothing Then sTmp = ToText(Row("name"))
        PutBookmark(R.Document, "currency", sTmp)

        ' 17. Единица измерения
        sTmp = Nothing
        Row = Me.UnitHandbookTable.Rows.Find(ToInt(Me.ARow("unitId")))
        If Not Row Is Nothing Then sTmp = ToText(Row("codeLetter"))
        PutBookmark(R.Document, "unit", sTmp)

        ' 18. Условия платежа
        sTmp = Nothing
        Row = Me.PaymentHandbookTable.Rows.Find(ToInt(Me.ARow("paymentId")))
        If Not Row Is Nothing Then sTmp = ToText(Row("name"))
        PutBookmark(R.Document, "payment", sTmp)

        ' 19. Количество
        PutBookmark(R.Document, "unitCount", ToText(Me.ARow("unitCount")))

        ' 20. Статистическая стоимость
        PutBookmark(R.Document, "usdPrice", ToText(Me.ARow("usdPrice")))

        ' 21. Конечное использование
        PutBookmark(R.Document, "goodUsed", ToText(Me.ARow("goodUsed")))

        ' 22. Банк заявителя, его адрес, номер счета
        PutBookmark(R.Document, "bankName", ToText(Me.ARow("bankName")))
        PutBookmark(R.Document, "bankAddress", ToText(Me.ARow("bankAddress")))
        PutBookmark(R.Document, "bankAccount", ToText(Me.ARow("bankAccount")))

        ' 23. Основание для запроса лицензии
        PutBookmark(R.Document, "licBasis", ToText(Me.ARow("licBasis")))

        ' 24. Код списка
        sTmp = Nothing
        Row = Me.LawCaptionHandbookTable.Rows.Find(ToInt(Me.ARow("lawId")))
        If Not Row Is Nothing Then sTmp = ToText(Row("codeDec"))
        PutBookmark(R.Document, "law", sTmp)

        ' 25. Позиция списка
        PutBookmark(R.Document, "lawPos", ToText(Me.ARow("lawPos")))

        ' 26. Таможенный орган Российской Федерации
        PutBookmark(R.Document, "customName", ToText(Me.ARow("customName")))

        ' 27. Дополнительная информация
        PutBookmark(R.Document, "extraInfo", ToText(Me.ARow("extraInfo")))

        ' 28. Уполномоченное лицо заявителя
        PutBookmark(R.Document, "personName", ToText(Me.ARow("personName")))
        PutBookmark(R.Document, "personJob", ToText(Me.ARow("personJob")))
        PutBookmark(R.Document, "personPhone", ToText(Me.ARow("personPhone")))


        ' Завершение редактирования документа
        R.Document.EndUpdate()

        ' СОХРАНЕНИЕ ДОКУМЕНТА И СВЕДЕНИЙ О НЕМ В ИСТОЧНИК ДАННЫХ РАБОТЫ
        ' ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Сохранение содержимого проекта документа
        '
        Me.ARow("statData") = R.Document.OpenXmlBytes

        R.Dispose()

    End Sub

    ''' <summary>
    ''' Возвращает отформатированную дату для подстановки в заявление
    ''' </summary>
    ''' <param name="docDate">Исходная дата</param>
    Private Function GetDocDate(docDate As Date) As String
        Dim mnf As String = Nothing
        Select Case docDate.Month
            Case 1 : mnf = "Января"
            Case 2 : mnf = "Февраля"
            Case 3 : mnf = "Марта"
            Case 4 : mnf = "Апреля"
            Case 5 : mnf = "Мая"
            Case 6 : mnf = "Июня"
            Case 7 : mnf = "Июля"
            Case 8 : mnf = "Августа"
            Case 9 : mnf = "Сентября"
            Case 10 : mnf = "Октября"
            Case 11 : mnf = "Ноября"
            Case Else : mnf = "Декабря"
        End Select
        Return String.Format("""{0:dd}"" {1} {0:yyyy} г.", docDate, mnf)
    End Function

End Class
