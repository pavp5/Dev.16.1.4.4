Imports C2 = Cprp.DxData.Common
' =======================================
' Содержание работы в виде HTML-документа
' =======================================
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Возвращает содержание работы в виде HTML-документа
    ''' </summary>
    Public Overrides Function GetHtmlContent() As String
        ' ID последнего динамически сформированного элемента
        Dim elId As Integer = 100

        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Dim Row As DataRow = Nothing

        Dim Html As String = "<!DOCTYPE HTML><html>"
        '
        ' Head, css, js
        '
        Html &= "<head>" & vbCrLf
        Html &= String.Format("<title>Содержание работы № {0}</title>", CInt(Me.Id)) & vbCrLf
        Html &= HTML_CSS_JS
        Html &= "</head>" & vbCrLf
        '
        ' Body
        '
        Html &= "<body>" & vbCrLf
        '
        ' RootNode
        '
        Html &= "<ul class='tree'>"
        '
        ' Сведения о работе
        '
        Html &= "<li style='margin-top: 0pt;'><span onclick='javascript: hs(el1);'>Сведения о работе</span>"
        Html &= "<ul id='el1'>"
        Html &= MyBase.HtmlWorkInfoTABLE
        Html &= "</ul>"
        Html &= "</li>"                             ' /Сведения о работе
        '
        ' Перечень использованных документов
        '
        Html &= String.Format("<li style='margin-top: 6pt;'><span onclick='javascript: hs(el0);'>Перечень использованных документов</span> <a href='CN_{0}_0'>[список]</a>", CInt(ContentEnum.ExtraDoc))
        Html &= "<ul id='el0'>"
        Html &= MyBase.HtmlInDocTable(True)
        Html &= "</ul>"
        Html &= "</li>"                             ' /Перечень использованных документов
        '
        ' Данные для оформления лицензии ФСТЭК / разрешения КЭК
        '
        Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el2);'>Данные для оформления лицензии ФСТЭК / разрешения КЭК</span>"
        Html &= "<ul id='el2'>"
        Html &= "<table class='notree' width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>1. ЗАЯВЛЕНИЕ О ПРЕДОСТАВЛЕНИИ ЛИЦЕНЗИИ</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("statDate"))
        If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = String.Format("от {0:dd MMMM yyyy} г.", CDate(sTmp))
        sTmp1 = C2.ToText(Me.ARow("statNum"))
        If Not String.IsNullOrWhiteSpace(sTmp1) Then sTmp = String.Format("{0} N {1}", sTmp, sTmp1)
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>2. Тип запрашиваемой лицензии</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = Nothing
        Row = Me.LicenseTypeHandbookTable.Rows.Find(C2.ToInt(Me.ARow("licTypeId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("name"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>3. Заявитель (наименование и адрес)</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("clientName"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        sTmp1 = C2.ToText(Me.ARow("clientAddress"))
        If String.IsNullOrWhiteSpace(sTmp1) Then sTmp1 = NULL_TEXT
        sTmp = String.Format("{0}<br>{1}", sTmp, sTmp1)
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>4. Заявляемый срок действия лицензии</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("licTerm"))
        If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = String.Format("до {0:dd MMMM yyyy} г.", CDate(sTmp))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>5. Контракт (договор)</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("conDate"))
        sTmp1 = C2.ToText(Me.ARow("conNum"))
        If String.IsNullOrWhiteSpace(sTmp) Then
            sTmp = "Б/Д"
        Else
            sTmp = String.Format("{0:dd MMMM yyyy} г.", CDate(sTmp))
        End If
        If String.IsNullOrWhiteSpace(sTmp1) Then sTmp1 = "Б/Н"
        sTmp = String.Format("от {0} N {1}", sTmp, sTmp1)
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>6. Условия поставки</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = Nothing
        Row = Me.IncotermsHandbookTable.Rows.Find(C2.ToInt(Me.ARow("incotermsId")))
        If Row Is Nothing Then
            sTmp = NULL_TEXT
        Else
            sTmp = C2.ToText(Row("name"))
        End If
        sTmp1 = C2.ToText(Me.ARow("incotermsPlace"))
        If String.IsNullOrWhiteSpace(sTmp1) Then sTmp1 = NULL_TEXT
        sTmp = String.Format("{0}/{1}", sTmp, sTmp1)
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>7. Покупатель/продавец (наименование и адрес)</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("bayerName"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        sTmp1 = C2.ToText(Me.ARow("bayerAddress"))
        If String.IsNullOrWhiteSpace(sTmp1) Then sTmp1 = NULL_TEXT
        sTmp = String.Format("{0}<br>{1}", sTmp, sTmp1)
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>8. Изготовитель/разработчик (наименование и адрес)</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("devName"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        sTmp1 = C2.ToText(Me.ARow("devAddress"))
        If String.IsNullOrWhiteSpace(sTmp1) Then sTmp1 = NULL_TEXT
        sTmp = String.Format("{0}<br>{1}", sTmp, sTmp1)
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>9. Конечный пользователь (наименование и адрес)</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("endName"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        sTmp1 = C2.ToText(Me.ARow("endAddress"))
        If String.IsNullOrWhiteSpace(sTmp1) Then sTmp1 = NULL_TEXT
        sTmp = String.Format("{0}<br>{1}", sTmp, sTmp1)
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>10. Страна происхождения</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = NULL_TEXT
        Row = Me.CountryHandbookTable.Rows.Find(C2.ToInt(Me.ARow("devCountryId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("nameShort"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>11. Страна покупателя/продавца</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = NULL_TEXT
        Row = Me.CountryHandbookTable.Rows.Find(C2.ToInt(Me.ARow("bayerCountryId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("nameShort"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>12. Страна (страны) транзита</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = NULL_TEXT
        sTmp1 = C2.ToText(Me.ARow("transitCountryIdString"))
        If Not String.IsNullOrWhiteSpace(sTmp1) Then
            Using V As New DataView(Me.CountryHandbookTable)
                V.RowFilter = String.Format("id IN ({0})", sTmp1)
                V.Sort = "nameShort"
                sTmp = C2.ToText(V(0)("nameShort"))
                For i As Integer = 1 To V.Count - 1
                    sTmp = String.Format("{0}, {1}", sTmp, C2.ToText(V(i)("nameShort")))
                Next
            End Using
        End If
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>13. Страна конечного использования</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = NULL_TEXT
        Row = Me.CountryHandbookTable.Rows.Find(C2.ToInt(Me.ARow("endCountryId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("nameShort"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>14. Наименование и характеристика (описание) продукции</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("goodCaption"))
        If String.IsNullOrWhiteSpace(sTmp) Then
            sTmp = NULL_TEXT
        Else
            sTmp = sTmp.Replace(vbCrLf, "<br>")
        End If
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>15. Код ТН ВЭД</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("goodTnved"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>16. Валюта контракта</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = NULL_TEXT
        Row = Me.CurrencyHandbookTable.Rows.Find(C2.ToInt(Me.ARow("currencyId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("name"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>17. Единица измерения</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = NULL_TEXT
        Row = Me.UnitHandbookTable.Rows.Find(C2.ToInt(Me.ARow("unitId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("codeLetter"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>18. Условия платежа</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = NULL_TEXT
        Row = Me.PaymentHandbookTable.Rows.Find(C2.ToInt(Me.ARow("paymentId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("name"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>19. Количество</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("unitCount"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>20. Статистическая стоимость</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("usdPrice"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>21. Конечное использование</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("goodUsed"))
        If String.IsNullOrWhiteSpace(sTmp) Then
            sTmp = NULL_TEXT
        Else
            sTmp = sTmp.Replace(vbCrLf, "<br>")
        End If
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>22. Банк заявителя, его адрес, номер счета</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("bankName"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        sTmp1 = C2.ToText(Me.ARow("bankAddress"))
        If Not String.IsNullOrWhiteSpace(sTmp1) Then sTmp = String.Format("{0}<br>{1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(Me.ARow("bankAccount"))
        If Not String.IsNullOrWhiteSpace(sTmp1) Then sTmp = String.Format("{0}<br>{1}", sTmp, sTmp1)
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>23. Основание для запроса лицензии</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("licBasis"))
        If String.IsNullOrWhiteSpace(sTmp) Then
            sTmp = NULL_TEXT
        Else
            sTmp = sTmp.Replace(vbCrLf, "<br>")
        End If
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>24. Код списка</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = Nothing
        Row = Me.LawCaptionHandbookTable.Rows.Find(C2.ToInt(Me.ARow("lawId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("codeDec"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>25. Позиция списка</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("lawPos"))
        If String.IsNullOrWhiteSpace(sTmp) Then
            sTmp = NULL_TEXT
        Else
            sTmp = sTmp.Replace(vbCrLf, "<br>")
        End If
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>26. Таможенный орган Российской Федерации</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("customName"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>27. Дополнительная информация</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("extraInfo"))
        If String.IsNullOrWhiteSpace(sTmp) Then
            sTmp = NULL_TEXT
        Else
            sTmp = sTmp.Replace(vbCrLf, "<br>")
        End If
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"

        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>28. Уполномоченное лицо заявителя</a></th>", CInt(ContentEnum.LicenseData))
        sTmp = C2.ToText(Me.ARow("personName"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = NULL_TEXT
        sTmp = String.Format("Ф.И.О. {0}", sTmp)
        sTmp1 = C2.ToText(Me.ARow("personJob"))
        If String.IsNullOrWhiteSpace(sTmp1) Then sTmp1 = NULL_TEXT
        sTmp = String.Format("{0}<br>Должность {1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(Me.ARow("personPhone"))
        If String.IsNullOrWhiteSpace(sTmp1) Then sTmp1 = NULL_TEXT
        sTmp = String.Format("{0}<br>Контактный телефон/факс {1}", sTmp, sTmp1)
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"


        Html &= "</table>"
        Html &= "</ul>"
        Html &= "</li>"                             ' /Данные для оформления лицензии ФСТЭК / разрешения КЭК
        '
        Html &= "</ul>"                             ' /RootNode
        Html &= "</body>"
        Html &= "</html>"
        Return Html
    End Function

End Class