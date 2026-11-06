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
        '
        ' Сведения о работе > Перечень представленных документов
        '
        Html &= String.Format("<li style='margin-top: 6pt;'><span onclick='javascript: hs(el13);'>Перечень представленных документов</span> <a href='CN_{0}_0'>[список]</a>", CInt(ContentEnum.ExtraDoc))
        Html &= "<ul id='el13'>"
        Html &= MyBase.HtmlInDocLI(False)
        Html &= "</ul>"
        Html &= "</li>"                             ' /Перечень представленных документов
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /Сведения о работе
        '
        ' Переход к концу содержания, если работа новая или не распределена на эксперта
        If Me.Condition = WorkCondition.IsNew OrElse IsDBNull(Me("expertId")) Then GoTo LEND
        '
        ' ПЛАН РАБОТЫ
        '
        Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el15);'>ПЛАН МЕРОПРИЯТИЙ ПО РАБОТЕ</span>"
        Html &= "<ul id='el15'>"
        Html &= MyBase.HtmlPlaneTABLE(ContentEnum.Plane)
        '
        ' ПЛАН РАБОТЫ > Перечень использованных документов
        '
        sTmp = If(CBool(Me.ARow("isDocRule")), "легитимность подтверждена", "легитимность не подтверждена")
        Html &= String.Format("<li style='margin-top: 6pt;'><span onclick='javascript: hs(el0);'>Перечень использованных документов ({0})</span> <a href='CN_{1}_0'>[список]</a>", sTmp, CInt(ContentEnum.ExtraDoc))
        Html &= "<ul id='el0'>"
        Html &= MyBase.HtmlInDocLI(True)
        Html &= "</ul>"
        Html &= "</li>"                             ' /Перечень использованных документов
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ПЛАН РАБОТЫ
        '
        ' Переход к концу содержания если работа в состоянии подготовки или утверждения плана
        If Me.Condition = WorkCondition.IsPlaneWork OrElse Me.Condition = WorkCondition.IsPlaneAgree Then GoTo LEND
        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА
        '
        Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el2);'>ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА</span>"
        Html &= "<ul id='el2'>"
        Html &= "<table class='notree' width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Документ-основание сделки</a></th>", CInt(ContentEnum.ContractData))
        sTmp = GetHtmlContractCaption()
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        '
        ' "Без договора" или "Любой договор"
        ' ----------------------------------
        '
        If CBool(Me.ARow("isNotContract")) OrElse CBool(Me.ARow("isDefContract")) Then
            Html &= "</table>"
            Html &= "</ul>"
            Html &= "</li>"                         ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА
            GoTo LSUPPLY                            ' -> ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ
        End If
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Описание предмета сделки</a></th>", CInt(ContentEnum.ContractData))
        sTmp = C2.ToText(Me.ARow("contractDescription"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Выявленные риски</a></th>", CInt(ContentEnum.ContractRisk))
        sTmp = GetHtmlContractRisk()
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "</table>"
        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА > РОССИЙСКИЕ УЧАСТНИКИ СДЕЛКИ
        '
        Html &= String.Format("<li style='margin-top: 12pt;'><span onclick='javascript: hs(el7);'>РОССИЙСКИЕ УЧАСТНИКИ СДЕЛКИ</span> <a href='CN_{0}_0'>[список]</a>", CInt(ContentEnum.ContractRusList))
        Html &= "<ul id='el7'>"
        Using V As New DataView(Me.MemberTable)
            V.RowFilter = "conRusNum > 0"
            V.Sort = "conRusNum"
            If V.Count = 0 Then Html &= "<p>[нет данных]</p>"
            elId += 10000
            For i As Integer = 0 To V.Count - 1
                '
                ' ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА > РОССИЙСКИЕ УЧАСТНИКИ СДЕЛКИ > ОБЪЕКТ №
                '
                elId += 1
                Html &= String.Format("<li><span onclick='javascript: hs(el{0});'>Объект № {1}.</span>", elId, CInt(V(i)("conRusNum")))
                Html &= String.Format("<ul id='el{0}'>", elId)
                Html &= "<table class='notree' width='100%' border='1'>"
                Html &= "<col width='288pt'><col>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Наименование и реквизиты</a></th>", _
                                      CInt(ContentEnum.ContractRusData), CInt(V(i)("id")))
                sTmp = GetHtmlMemberCaption(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                'Html &= "<tr>"
                'sTmp = GetHtmlMemberControlDoc(V(i)("inn").ToString, 2)
                'If String.IsNullOrWhiteSpace(sTmp) Then
                '    Html &= "<th>Заключения ""Требуется лицензия ФСТЭК""</th>"
                '    Html &= "<td>Не выявлены</td>"
                'Else
                '    Html &= String.Format("<th><a href='FINFO_RUS_2INN{0}'>Заключения ""Требуется лицензия ФСТЭК""</a></th>", V(i)("inn").ToString)
                '    Html &= String.Format("<td class='red'>{0}</td>", sTmp)
                'End If
                'Html &= "</tr>"
                'Html &= "<tr>"
                'sTmp = GetHtmlMemberControlDoc(V(i)("inn").ToString, 3)
                'If String.IsNullOrWhiteSpace(sTmp) Then
                '    Html &= "<th>Заключения ""Требуется разрешение КЭК""</th>"
                '    Html &= "<td>Не выявлены</td>"
                'Else
                '    Html &= String.Format("<th><a href='FINFO_RUS_3INN{0}'>Заключения ""Требуется разрешение КЭК""</a></th>", V(i)("inn").ToString)
                '    Html &= String.Format("<td class='red'>{0}</td>", sTmp)
                'End If
                'Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Профиль</a></th>", _
                                      CInt(ContentEnum.ContractRusProfile), CInt(V(i)("id")))
                sTmp = GetHtmlMemberProfile(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Выявленные риски</a></th>", _
                                      CInt(ContentEnum.ContractRusRisk), CInt(V(i)("id")))
                sTmp = GetHtmlMemberRisk(V(i).Row, Member.MemberKind.IsContractRus)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "</table>"
                Html &= "</ul>"
                Html &= "</li>"                     ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА > РОССИЙСКИЕ УЧАСТНИКИ СДЕЛКИ > ОБЪЕКТ №
            Next
        End Using
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА > РОССИЙСКИЕ УЧАСТНИКИ СДЕЛКИ
        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА > ИНОСТРАННЫЕ УЧАСТНИКИ СДЕЛКИ
        '
        Html &= String.Format("<li style='margin-top: 12pt;'><span onclick='javascript: hs(el8);'>ИНОСТРАННЫЕ УЧАСТНИКИ СДЕЛКИ</span> <a href='CN_{0}_0'>[список]</a>", CInt(ContentEnum.ContractNusList))
        Html &= "<ul id='el8'>"
        Using V As New DataView(Me.MemberTable)
            V.RowFilter = "conNusNum > 0"
            V.Sort = "conNusNum"
            If V.Count = 0 Then Html &= "<p>[нет данных]</p>"
            elId += 10000
            For i As Integer = 0 To V.Count - 1
                '
                ' ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА > ИНОСТРАННЫЕ УЧАСТНИКИ СДЕЛКИ > ОБЪЕКТ №
                '
                elId += 1
                Html &= String.Format("<li><span onclick='javascript: hs(el{0});'>Объект № {1}.</span>", elId, CInt(V(i)("conNusNum")))
                Html &= String.Format("<ul id='el{0}'>", elId)
                Html &= "<table class='notree' width='100%' border='1'>"
                Html &= "<col width='288pt'><col>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Наименование и реквизиты</a></th>", _
                                      CInt(ContentEnum.ContractNusData), CInt(V(i)("id")))
                sTmp = GetHtmlMemberCaption(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Запреты и ограничения</a></th>", _
                                      CInt(ContentEnum.ContractNusEmbargo), CInt(V(i)("id")))
                sTmp = GetHtmlMemberEmbargo(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Фирмы на контроле</a></th>", _
                                      CInt(ContentEnum.ContractNusControl), CInt(V(i)("id")))
                sTmp = GetHtmlMemberControl(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Профиль</a></th>", _
                                      CInt(ContentEnum.ContractNusProfile), CInt(V(i)("id")))
                sTmp = GetHtmlMemberProfile(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Выявленные риски</a></th>", _
                                      CInt(ContentEnum.ContractNusRisk), CInt(V(i)("id")))
                sTmp = GetHtmlMemberRisk(V(i).Row, Member.MemberKind.IsContractNus)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "</table>"
                Html &= "</ul>"
                Html &= "</li>"                     ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА > ИНОСТРАННЫЕ УЧАСТНИКИ СДЕЛКИ > ОБЪЕКТ №
            Next
        End Using
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА > ИНОСТРАННЫЕ УЧАСТНИКИ СДЕЛКИ
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ СДЕЛКА
LSUPPLY:
        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ
        '
        Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el3);'>ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ</span>"
        Html &= "<ul id='el3'>"
        Html &= "<table class='notree' width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Документ-основание операции</a></th>", CInt(ContentEnum.SupplyData))
        sTmp = C2.ToText(Me.ARow("invoiceCaption"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Характер внешнеэкономической операции</a></th>", CInt(ContentEnum.SupplyData))
        sTmp = Nothing
        Row = Me.SupplyTypeHandbookTable.Rows.Find(C2.ToInt(Me.ARow("supplyTypeId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("nameShort"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Страна банка</a></th>", CInt(ContentEnum.SupplyData))
        sTmp = Nothing
        Row = Me.CountryHandbookTable.Rows.Find(C2.ToInt(Me.ARow("bankCountryId")))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("nameShort"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Условие поставки (инкотермс)</a></th>", CInt(ContentEnum.SupplyData))
        Html &= String.Format("<td>{0}</td>", GetHtmlIncoterms)
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Описание предмета операции</a></th>", CInt(ContentEnum.SupplyData))
        sTmp = C2.ToText(Me.ARow("supplyDescription"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Выявленные риски</a></th>", CInt(ContentEnum.SupplyRisk))
        sTmp = GetHtmlSupplyRisk()
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "</table>"
        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > СТРАНЫ НАЗНАЧЕНИЯ (ОТПРАВЛЕНИЯ)
        '
        Html &= "<li style='margin-top: 12pt;'><span onclick='javascript: hs(el9);'>СТРАНЫ НАЗНАЧЕНИЯ (ОТПРАВЛЕНИЯ)</span>"
        Html &= "<ul id='el9'>"
        sTmp = C2.ToText(Me.ARow("countryIdString"))
        If Not C2.IsText(sTmp) Then sTmp = "0"
        Using V As New DataView(Me.CountryHandbookTable) With {.Sort = "nameShort"}
            V.RowFilter = String.Format("id IN ({0})", sTmp.Replace("/", ","))
            If V.Count = 0 Then Html &= "<p>[нет данных]</p>"
            elId += 10000
            For i As Integer = 0 To V.Count - 1
                '
                ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > СТРАНЫ НАЗНАЧЕНИЯ (ОТПРАВЛЕНИЯ) > ОБЪЕКТ №
                '
                elId += 1
                Html &= String.Format("<li><span onclick='javascript: hs(el{0});'>Объект № {1}.</span>", elId, i + 1)
                Html &= String.Format("<ul id='el{0}'>", elId)
                Html &= "<table class='notree' width='100%' border='1'>"
                Html &= "<col width='288pt'><col>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_0'>Наименование</a></th>", CInt(ContentEnum.SupplyData))
                sTmp = C2.ToText(V(i)("nameShort"))
                Html &= String.Format("<td>{0}</td>", sTmp)
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= "<th>Профиль</th>"
                sTmp = GetHtmlCountryProfile(V(i)("id"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= "<th>Запреты и ограничения</th>"
                sTmp = GetHtmlCountryEmbargo(V(i)("id"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "</table>"
                Html &= "</ul>"
                Html &= "</li>"                     ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > СТРАНЫ НАЗНАЧЕНИЯ (ОТПРАВЛЕНИЯ) > ОБЪЕКТ №
            Next
        End Using
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > СТРАНЫ НАЗНАЧЕНИЯ (ОТПРАВЛЕНИЯ)
        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > СТРАНА БАНКА
        '
        Html &= "<li style='margin-top: 12pt;'><span onclick='javascript: hs(el09);'>СТРАНА БАНКА</span>"
        Html &= "<ul id='el09'>"
        Row = Me.CountryHandbookTable.Rows.Find(C2.ToInt(Me.ARow("bankCountryId")))
        If Row Is Nothing Then
            Html &= "<p>[нет данных]</p>"
        Else
            Html &= "<table class='notree' width='100%' border='1'>"
            Html &= "<col width='312pt'><col>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Наименование</a></th>", CInt(ContentEnum.SupplyData))
            sTmp = C2.ToText(Row("nameShort"))
            Html &= String.Format("<td>{0}</td>", sTmp)
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= "<th>Профиль</th>"
            sTmp = GetHtmlCountryProfile(Row("id"))
            Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= "<th>Запреты и ограничения</th>"
            sTmp = GetHtmlCountryEmbargo(Row("id"))
            Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
            Html &= "</tr>"
            Html &= "</table>"
        End If
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > СТРАНА БАНКА

        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > РОССИЙСКИЕ УЧАСТНИКИ ОПЕРАЦИИ
        '
        Html &= String.Format("<li style='margin-top: 12pt;'><span onclick='javascript: hs(el10);'>РОССИЙСКИЕ УЧАСТНИКИ ОПЕРАЦИИ</span> <a href='CN_{0}_0'>[список]</a>", CInt(ContentEnum.SupplyRusList))
        Html &= "<ul id='el10'>"
        Using V As New DataView(Me.MemberTable)
            V.RowFilter = "supRusNum > 0"
            V.Sort = "supRusNum"
            If V.Count = 0 Then Html &= "<p>[нет данных]</p>"
            elId += 10000
            For i As Integer = 0 To V.Count - 1
                '
                ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > РОССИЙСКИЕ УЧАСТНИКИ ОПЕРАЦИИ > ОБЪЕКТ №
                '
                elId += 1
                Html &= String.Format("<li><span onclick='javascript: hs(el{0});'>Объект № {1}.</span>", elId, CInt(V(i)("supRusNum")))
                Html &= String.Format("<ul id='el{0}'>", elId)
                Html &= "<table class='notree' width='100%' border='1'>"
                Html &= "<col width='288pt'><col>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Наименование и реквизиты</a></th>", _
                                      CInt(ContentEnum.SupplyRusData), CInt(V(i)("id")))
                sTmp = GetHtmlMemberCaption(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                'Html &= "<tr>"
                'sTmp = GetHtmlMemberControlDoc(V(i)("inn").ToString, 2)
                'If String.IsNullOrWhiteSpace(sTmp) Then
                '    Html &= "<th>Заключения ""Требуется лицензия ФСТЭК""</th>"
                '    Html &= "<td>Не выявлены</td>"
                'Else
                '    Html &= String.Format("<th><a href='FINFO_RUS_2INN{0}'>Заключения ""Требуется лицензия ФСТЭК""</a></th>", V(i)("inn").ToString)
                '    Html &= String.Format("<td class='red'>{0}</td>", sTmp)
                'End If
                'Html &= "</tr>"
                'Html &= "<tr>"
                'sTmp = GetHtmlMemberControlDoc(V(i)("inn").ToString, 3)
                'If String.IsNullOrWhiteSpace(sTmp) Then
                '    Html &= "<th>Заключения ""Требуется разрешение КЭК""</th>"
                '    Html &= "<td>Не выявлены</td>"
                'Else
                '    Html &= String.Format("<th><a href='FINFO_RUS_3INN{0}'>Заключения ""Требуется разрешение КЭК""</a></th>", V(i)("inn").ToString)
                '    Html &= String.Format("<td class='red'>{0}</td>", sTmp)
                'End If
                'Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Профиль</a></th>", _
                                      CInt(ContentEnum.SupplyRusProfile), CInt(V(i)("id")))
                sTmp = GetHtmlMemberProfile(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Выявленные риски</a></th>", _
                                      CInt(ContentEnum.SupplyRusRisk), CInt(V(i)("id")))
                sTmp = GetHtmlMemberRisk(V(i).Row, Member.MemberKind.IsSupplyRus)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "</table>"
                Html &= "</ul>"
                Html &= "</li>"                     ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > РОССИЙСКИЕ УЧАСТНИКИ ОПЕРАЦИИ > ОБЪЕКТ №
            Next
        End Using
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > РОССИЙСКИЕ УЧАСТНИКИ ОПЕРАЦИИ
        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > ИНОСТРАННЫЕ ПОКУПАТЕЛИ (ПРОДАВЦЫ)
        '
        Html &= String.Format("<li style='margin-top: 12pt;'><span onclick='javascript: hs(el11);'>ИНОСТРАННЫЕ ПОКУПАТЕЛИ (ПРОДАВЦЫ)</span> <a href='CN_{0}_0'>[список]</a>", CInt(ContentEnum.SupplyNusList))
        Html &= "<ul id='el11'>"
        Using V As New DataView(Me.MemberTable)
            V.RowFilter = "supNusNum > 0"
            V.Sort = "supNusNum"
            If V.Count = 0 Then Html &= "<p>[нет данных]</p>"
            elId += 10000
            For i As Integer = 0 To V.Count - 1
                '
                ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > ИНОСТРАННЫЕ ПОКУПАТЕЛИ (ПРОДАВЦЫ) > ОБЪЕКТ №
                '
                elId += 1
                Html &= String.Format("<li><span onclick='javascript: hs(el{0});'>Объект № {1}.</span>", elId, CInt(V(i)("supNusNum")))
                Html &= String.Format("<ul id='el{0}'>", elId)
                Html &= "<table class='notree' width='100%' border='1'>"
                Html &= "<col width='288pt'><col>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Наименование и реквизиты</a></th>", _
                                      CInt(ContentEnum.SupplyNusData), CInt(V(i)("id")))
                sTmp = GetHtmlMemberCaption(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Запреты и ограничения</a></th>", _
                                      CInt(ContentEnum.SupplyNusEmbargo), CInt(V(i)("id")))
                sTmp = GetHtmlMemberEmbargo(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Фирмы на контроле</a></th>", _
                                      CInt(ContentEnum.SupplyNusControl), CInt(V(i)("id")))
                sTmp = GetHtmlMemberControl(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Профиль</a></th>", _
                                      CInt(ContentEnum.SupplyNusProfile), CInt(V(i)("id")))
                sTmp = GetHtmlMemberProfile(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Выявленные риски</a></th>", _
                                      CInt(ContentEnum.SupplyNusRisk), CInt(V(i)("id")))
                sTmp = GetHtmlMemberRisk(V(i).Row, Member.MemberKind.IsSupplyNus)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "</table>"
                Html &= "</ul>"
                Html &= "</li>"                     ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > ИНОСТРАННЫЕ ПОКУПАТЕЛИ (ПРОДАВЦЫ) > ОБЪЕКТ №
            Next
        End Using
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > ИНОСТРАННЫЕ ПОКУПАТЕЛИ (ПРОДАВЦЫ)
        '
        ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > ПОТРЕБИТЕЛИ (КОНЕЧНЫЕ ПОЛЬЗОВАТЕЛИ)
        '
        Html &= String.Format("<li style='margin-top: 12pt;'><span onclick='javascript: hs(el12);'>ПОТРЕБИТЕЛИ (КОНЕЧНЫЕ ПОЛЬЗОВАТЕЛИ)</span> <a href='CN_{0}_0'>[список]</a>", CInt(ContentEnum.SupplyEndList))
        Html &= "<ul id='el12'>"
        Using V As New DataView(Me.MemberTable)
            V.RowFilter = "supEndNum > 0"
            V.Sort = "supEndNum"
            If V.Count = 0 Then Html &= "<p>[нет данных]</p>"
            elId += 10000
            For i As Integer = 0 To V.Count - 1
                '
                ' ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > ПОТРЕБИТЕЛИ (КОНЕЧНЫЕ ПОЛЬЗОВАТЕЛИ) > ОБЪЕКТ №
                '
                elId += 1
                Html &= String.Format("<li><span onclick='javascript: hs(el{0});'>Объект № {1}.</span>", elId, CInt(V(i)("supEndNum")))
                Html &= String.Format("<ul id='el{0}'>", elId)
                Html &= "<table class='notree' width='100%' border='1'>"
                Html &= "<col width='288pt'><col>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Наименование и реквизиты</a></th>", _
                                      CInt(ContentEnum.SupplyEndData), CInt(V(i)("id")))
                sTmp = GetHtmlMemberCaption(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Запреты и ограничения</a></th>", _
                                      CInt(ContentEnum.SupplyEndEmbargo), CInt(V(i)("id")))
                sTmp = GetHtmlMemberEmbargo(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Фирмы на контроле</a></th>", _
                                      CInt(ContentEnum.SupplyEndControl), CInt(V(i)("id")))
                sTmp = GetHtmlMemberControl(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Профиль</a></th>", _
                                      CInt(ContentEnum.SupplyEndProfile), CInt(V(i)("id")))
                sTmp = GetHtmlMemberProfile(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Выявленные риски</a></th>", _
                                      CInt(ContentEnum.SupplyEndRisk), CInt(V(i)("id")))
                sTmp = GetHtmlMemberRisk(V(i).Row, Member.MemberKind.IsSupplyEnd)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "</table>"
                Html &= "</ul>"
                Html &= "</li>"                     ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > ПОТРЕБИТЕЛИ (КОНЕЧНЫЕ ПОЛЬЗОВАТЕЛИ) > ОБЪЕКТ №
            Next
        End Using
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ > ПОТРЕБИТЕЛИ (КОНЕЧНЫЕ ПОЛЬЗОВАТЕЛИ)
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ВНЕШНЕЭКОНОМИЧЕСКАЯ ОПЕРАЦИЯ
        '
        ' ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ)
        '
        Html &= String.Format("<li style='margin-top: 18pt;'><span onclick='javascript: hs(el14);'>ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ)</span> <a href='CN_{0}_0'>[список]</a>", CInt(ContentEnum.GoodList))
        Html &= "<ul id='el14'>"
        Using V As New DataView(Me.GoodTable)
            V.Sort = "rowNum"
            If V.Count = 0 Then Html &= "<p>[нет данных]</p>"
            elId += 10000
            For i As Integer = 0 To V.Count - 1
                '
                ' ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ) > ОБЪЕКТ №
                '
                elId += 1
                Html &= String.Format("<li><span onclick='javascript: hs(el{0});'>Объект № {1}.</span>", elId, CInt(V(i)("rowNum")))
                Html &= String.Format("<ul id='el{0}'>", elId)
                Html &= "<table class='notree' width='100%' border='1'>"
                Html &= "<col width='312pt'><col>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Коммерческое наименование</a></th>", _
                                      CInt(ContentEnum.GoodData), CInt(V(i)("id")))
                sTmp = C2.ToText(V(i)("nameCon"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Обозначение</a></th>", _
                                      CInt(ContentEnum.GoodData), CInt(V(i)("id")))
                sTmp = "Объект не имеет обозначения"
                If Not CBool(V(i)("isNotDec")) Then sTmp = C2.ToText(V(i)("nameDec"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Область применения</a></th>", _
                                      CInt(ContentEnum.GoodData), CInt(V(i)("id")))
                sTmp = C2.ToText(V(i)("area"))
                If Not C2.IsText(sTmp) Then sTmp = C2.ToText(Me.ARow("goodArea"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Назначение</a></th>", _
                                      CInt(ContentEnum.GoodData), CInt(V(i)("id")))
                sTmp = C2.ToText(V(i)("used"))
                If Not C2.IsText(sTmp) Then sTmp = C2.ToText(Me.ARow("goodUsed"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Техническое описание</a></th>", _
                                      CInt(ContentEnum.GoodData), CInt(V(i)("id")))
                sTmp = C2.ToText(V(i)("description"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Код ТН ВЭД</a></th>", _
                                      CInt(ContentEnum.GoodData), CInt(V(i)("id")))
                sTmp = GetHtmlGoodTnved(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Обоснование кода ТН ВЭД</a></th>", _
                                      CInt(ContentEnum.GoodData), CInt(V(i)("id")))
                sTmp = C2.ToText(V(i)("tnvedComment"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Запреты и ограничения</a></th>", _
                                      CInt(ContentEnum.GoodEmbargo), CInt(V(i)("id")))
                sTmp = GetHtmlGoodEmbargo(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Контролируемые товары</a></th>", _
                                      CInt(ContentEnum.GoodControl), CInt(V(i)("id")))
                sTmp = GetHtmlGoodControl(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Анализ по контрольным спискам</a></th>", _
                                      CInt(ContentEnum.GoodLaw), CInt(V(i)("id")))
                sTmp = Nothing
                If Not IsDBNull(V(i)("studyDate")) Then
                    If CType(V(i)("studySummaryId"), Cprp.DxData.Law.StudyIndexEnum) = Law.StudyIndexEnum.IsEqual Then
                        sTmp = "<span class='red'>Соответствует контролируемым товарам (технологиям)</span>"
                    Else
                        sTmp = "Не соответствует контролируемым товарам (технологиям)"
                    End If
                End If
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Выявленные риски</a></th>", _
                                      CInt(ContentEnum.GoodRisk), CInt(V(i)("id")))
                sTmp = GetHtmlGoodRisk(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "</table>"
                Html &= "</ul>"
                Html &= "</li>"                     ' /ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ) > ОБЪЕКТ №
            Next
        End Using
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ)
        '
        ' РЕШЕНИЕ ПО АНАЛИЗУ
        '
        Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el5);'>РЕШЕНИЕ ПО АНАЛИЗУ</span>"
        Html &= "<ul id='el5'>"
        Html &= "<table class='notree' width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Анализ выявленных рисков</a></th>", CInt(ContentEnum.Summary))
        sTmp = C2.ToText(Me.ARow("summaryRisk"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>ВЫВОДЫ ЭКСПЕРТИЗЫ</a></th>", CInt(ContentEnum.Summary))
        sTmp = C2.ToText(Me.ARow("summaryText"))
        If C2.IsText(sTmp) AndAlso CType(Me.ARow("summaryId"), Cprp.DxData.Work.WorkSummary) <> WorkSummary.IsFreedom Then
            sTmp = String.Format("<span class='red'>{0}</span>", sTmp)
        End If
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "</table>"
        Html &= "</ul>"
        Html &= "</li>"                             ' /РЕШЕНИЕ ПО АНАЛИЗУ
        '
        ' ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ
        '
        Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el6);'>ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ</span>"
        Html &= "<ul id='el6'>"
        Html &= "<table width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Характеристика экспертизы</a></th>", CInt(ContentEnum.ExtraInfo))
        sTmp = Nothing
        Row = Me.WorkKindHandbookTable.Rows.Find(Me("kindId"))
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("name"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Комментарий к характеристике экспертизы</a></th>", CInt(ContentEnum.ExtraInfo))
        sTmp = C2.ToText(Me.ARow("kindComment"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Дополнительная информация</a></th>", CInt(ContentEnum.ExtraInfo))
        sTmp = C2.ToText(Me.ARow("comment"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Срок действия заключения экспертизы</a></th>", CInt(ContentEnum.ExtraInfo))
        sTmp = "В течение срока выполнения обязательств по внешнеэкономической операции"
        If Not IsDBNull(Me.ARow("docTerm")) Then sTmp = String.Format("до {0:dd.MM.yyyy} г.", CDate(Me.ARow("docTerm")))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "</table>"
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ
LEND:
        Html &= "</ul>"                             ' /RootNode
        Html &= "</body>"
        Html &= "</html>"
        Return Html
    End Function


#Region "Участники сделки и операции"

    ''' <summary>
    ''' Возвращает наименование и реквизиты лица в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    Private Function GetHtmlMemberCaption(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.MemberTable Then Return Nothing
        '
        ' Полное наименование
        '
        Dim sTmp As String = C2.ToText(Row("nameLong"))
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = "[нет наименования]"
        '
        ' Страна юридического адреса
        '
        Dim Row1 As DataRow = Me.CountryHandbookTable.Rows.Find(C2.ToInt(Row("addressLegalCountryId")))
        If Row1 Is Nothing Then
            sTmp = String.Format("{0}, [не указана страна юридического адреса]", sTmp)
        Else
            sTmp = String.Format("{0}, {1}", sTmp, C2.ToText(Row1("nameShort")))
        End If
        '
        ' Юридический адрес 
        '
        If C2.IsText(Row("addresslegalFull")) Then
            sTmp = String.Format("{0}, {1}", sTmp, C2.ToText(Row("addressLegalFull")))
        Else
            sTmp = String.Format("{0}, [не указан юридический адрес]", sTmp)
        End If
        '
        ' ИНН
        '
        If C2.IsText(Row("inn")) Then sTmp = String.Format("{0}, ИНН: {1}", sTmp, C2.ToText(Row("inn")))
        '
        ' КПП
        '
        If C2.IsText(Row("kpp")) Then sTmp = String.Format("{0}, КПП: {1}", sTmp, C2.ToText(Row("kpp")))
        '
        ' Телефон
        '
        If C2.IsText(Row("phone")) Then sTmp = String.Format("{0}, тел: {1}", sTmp, C2.ToText(Row("phone")))
        '
        ' Факс
        '
        If C2.IsText(Row("fax")) Then sTmp = String.Format("{0}, факс: {1}", sTmp, C2.ToText(Row("fax")))
        '
        ' Фирма на контроле
        '
        If CBool(Row("isControl")) Then sTmp = String.Format("<span class='red'>{0}</span>", sTmp)

        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает профиль лица в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    Private Function GetHtmlMemberProfile(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.MemberTable Then Return Nothing
        If Not IsDBNull(Row("xmlActDate")) Then Return "см. ""ПРОФИЛЬ"" в карточке компании"
        Dim sDescription As String = C2.ToText(Row("proDescription"))
        If sDescription Like "*<html>*" OrElse sDescription Like "*<HTML>*" Then
            Return "см. ""ПРОФИЛЬ"" в карточке компании"
        End If
        Dim sSource As String = C2.ToText(Row("proSource"))
        If Not (C2.IsText(sDescription) OrElse C2.IsText(sSource)) Then Return Nothing
        '
        ' Профиль фирмы
        '
        If Not C2.IsText(sDescription) Then sDescription = "<p>[нет данных]</p>"
        '
        ' Источник данных для заполнения профиля
        '
        If C2.IsText(sSource) Then
            '
            ' Формирование гиперссылок
            '
            sSource = sSource.Replace(vbCrLf, C2.FIELD_SEPARATOR)
            Dim Arr() As String = sSource.Split(New Char() {C2.FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
            sSource = Nothing
            For i As Integer = Arr.GetLowerBound(0) To Arr.GetUpperBound(0)
                Arr(i) = C2.ToText(Arr(i))
                If Not C2.IsText(Arr(i)) Then Continue For
                If Not Arr(i) Like "* *" Then
                    If Arr(i).ToUpper Like "HTTP*" Then
                        Arr(i) = String.Format("<a href='{0}' target=_blank>{0}</a>", Arr(i))
                    ElseIf Arr(i).ToUpper Like "WWW.*" Then
                        Arr(i) = String.Format("<a href='{0}' target=_blank>{1}</a>", "https://" & Arr(i).Substring(4), Arr(i))
                    End If
                End If
                sSource = String.Format("{0}<p>{1}</p>", sSource, Arr(i))
            Next
        End If
        If Not C2.IsText(sSource) Then sSource = "<p>[нет данных]</p>"
        '
        ' Возвращаемое значение
        '
        Return String.Format( _
            "<ul><li>Профиль фирмы:<ul>{0}</ul></li><li>Источник данных для заполнения профиля:<ul>{1}</ul></li></ul>", _
            sDescription, sSource)
    End Function

    ''' <summary>
    ''' Возвращает перечень запретов и ограничений лица в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param> 
    Private Function GetHtmlMemberEmbargo(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.MemberTable OrElse IsDBNull(Row("addressLegalCountryId")) Then Return Nothing
        If CBool(Row("isNotEmbargo")) Then Return "Запреты и ограничения отсутствуют"
        Using V As New DataView(Me.EmbargoMemberHandbookTable)
            V.RowFilter = String.Format("countryId = {0}", CInt(Row("addressLegalCountryId")))
            If V.Count = 0 Then Return "Запреты и ограничения отсутствуют"
        End Using
        Dim sTmp As String = Nothing
        Dim Row1 As DataRow = Nothing
        Dim countryId As Integer = C2.ToInt(Row("addressLegalCountryId"))
        Using V As New DataView(Me.MemberEmbargoTable)
            V.RowFilter = String.Format("memberId = {0}", C2.ToInt(Row("id")))
            V.Sort = "embargoMemberId"
            For i As Integer = 0 To V.Count - 1
                Row1 = Me.EmbargoMemberHandbookTable.Rows.Find(New Object() {V(i)("embargoMemberId"), countryId})
                If Row1 Is Nothing Then Continue For
                sTmp = String.Format("{0};</li><li>{1} ({2})", sTmp, C2.ToText(Row1("memberCaption")), C2.ToText(Row1("embargoCaption2")))
            Next
        End Using
        If C2.IsText(sTmp) Then sTmp = String.Format("<ul class='red'>{0}</li></ul>", sTmp.Substring(6))
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает перечень фирм на контроле лица в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param> 
    Private Function GetHtmlMemberControl(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.MemberTable OrElse IsDBNull(Row("addressLegalCountryId")) Then Return Nothing
        If CBool(Row("isNotControl")) Then Return "Связи с фирмами на контроле отсутствуют"
        Using V As New DataView(Me.ControlMemberHandbookTable)
            V.RowFilter = String.Format("countryId = {0}", CInt(Row("addressLegalCountryId")))
            If V.Count = 0 Then Return "Связи с фирмами на контроле отсутствуют"
        End Using
        Dim sTmp As String = Nothing
        Dim Row1 As DataRow = Nothing
        Using V As New DataView(Me.MemberControlTable)
            V.RowFilter = String.Format("memberId = {0}", C2.ToInt(Row("id")))
            V.Sort = "controlMemberId"
            For i As Integer = 0 To V.Count - 1
                Row1 = Me.ControlMemberHandbookTable.Rows.Find(V(i)("controlMemberId"))
                If Row1 Is Nothing Then Continue For
                sTmp = String.Format("{0};</li><li>{1}, {2}", sTmp, C2.ToText(Row1("caption")), C2.ToText(Row1("description")))
            Next
        End Using
        If C2.IsText(sTmp) Then sTmp = String.Format("<ul class='red'>{0}</li></ul>", sTmp.Substring(6))
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает перечень рисков лица в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param> 
    ''' <param name="kind">Вид лица</param> 
    Private Function GetHtmlMemberRisk(Row As DataRow, kind As Cprp.DxData.Member.MemberKind) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.MemberTable Then Return Nothing
        Dim sTmp As String = "Риски отсутствуют"
        Dim riskType As Cprp.DxData.Risk.TypeEnum = Risk.TypeEnum.IsEmpty
        Select Case kind
            Case DxData.Member.MemberKind.IsContractRus
                If CBool(Row("isNotConRusRisk")) Then Return sTmp
                riskType = Risk.TypeEnum.IsContractRus
            Case DxData.Member.MemberKind.IsContractNus
                If CBool(Row("isNotConNusRisk")) Then Return sTmp
                riskType = Risk.TypeEnum.IsContractNus
            Case DxData.Member.MemberKind.IsSupplyRus
                If CBool(Row("isNotSupRusRisk")) Then Return sTmp
                riskType = Risk.TypeEnum.IsSupplyRus
            Case DxData.Member.MemberKind.IsSupplyNus
                If CBool(Row("isNotSupNusRisk")) Then Return sTmp
                riskType = Risk.TypeEnum.IsSupplyNus
            Case DxData.Member.MemberKind.IsSupplyEnd
                If CBool(Row("isNotSupEndRisk")) Then Return sTmp
                riskType = Risk.TypeEnum.IsSupplyEnd
        End Select
        sTmp = Nothing
        Dim Row1 As DataRow = Nothing
        Using V As New DataView(Me.MemberRiskTable)
            V.RowFilter = String.Format("memberId = {0}", C2.ToInt(Row("id")))
            V.Sort = "riskId"
            For i As Integer = 0 To V.Count - 1
                Row1 = Me.RiskHandbookTable.Rows.Find(V(i)("riskId"))
                If Row1 Is Nothing Then Continue For
                If CInt(Row1("typeId")) <> CInt(riskType) Then Continue For
                sTmp = String.Format("{0};</li><li>{1}", sTmp, C2.ToText(Row1("caption")))
            Next
        End Using
        If C2.IsText(sTmp) Then sTmp = String.Format("<ul class='red'>{0}</li></ul>", sTmp.Substring(6))
        Return sTmp
    End Function

#End Region
#Region "Внешнеэкономическая сделка"

    ''' <summary>
    ''' Возвращает реквизиты документа-основания сделки
    ''' </summary>
    Private Function GetHtmlContractCaption() As String
        With Me.ARow
            If CBool(.Item("isNotContract")) Then Return "Без договора"
            If CBool(.Item("isDefContract")) Then Return "Любой договор"
            If Not (C2.IsText(.Item("contractName")) OrElse C2.IsText(.Item("contractNum")) OrElse _
                    C2.IsText(.Item("contractDate")) OrElse C2.IsText(.Item("contractTerm"))) Then Return Nothing
            Dim sTmp As String = C2.ToText(.Item("contractName"))
            If Not C2.IsText(sTmp) Then sTmp = "[не указано наименование документа]"
            If C2.IsText(.Item("contractNum")) Then sTmp = String.Format("{0} № {1}", sTmp, C2.ToText(.Item("contractNum")))
            If Not IsDBNull(.Item("contractDate")) Then sTmp = String.Format("{0} от {1:d MMMM yyyy} г.", sTmp, CDate(.Item("contractDate")))
            If CBool(.Item("isNotContractTerm")) Then
                sTmp = String.Format("{0} (бессрочный)", sTmp)
            ElseIf IsDBNull(.Item("contractTerm")) Then
                sTmp = String.Format("{0} (срок действия: [нет данных])", sTmp)
            Else
                sTmp = String.Format("{0} (срок действия: {1:dd.MM.yyyy})", sTmp, CDate(.Item("contractTerm")))
            End If
            Return sTmp
        End With
    End Function

    ''' <summary>
    ''' Возвращает перечень рисков по внешнеэкономической сделке
    ''' </summary>
    Private Function GetHtmlContractRisk() As String
        If CBool(Me.ARow("isNotContractRisk")) Then Return "Риски отсутствуют"
        Dim sTmp As String = Nothing
        Dim Row As DataRow = Nothing
        With Me.ContractRiskTable.DefaultView
            .Sort = "riskId"
            For i As Integer = 0 To .Count - 1
                Row = Me.RiskHandbookTable.Rows.Find(.Item(i)("riskId"))
                If Not Row Is Nothing Then sTmp = String.Format("{0};</li><li>{1}", sTmp, C2.ToText(Row("caption")))
            Next
        End With
        If C2.IsText(Me.ARow("otherContractRisk")) Then
            sTmp = String.Format("{0};</li><li>{1}", sTmp, C2.DelPoint(Me.ARow("otherContractRisk")))
        End If
        If C2.IsText(sTmp) Then sTmp = String.Format("<ul class='red'>{0}</li></ul>", sTmp.Substring(6))
        Return sTmp
    End Function

#End Region
#Region "Внешнеэкономическая операция"

    ''' <summary>
    ''' Возвращает условие поставки по Инкотермс и место доставки
    ''' </summary>
    Private Function GetHtmlIncoterms() As String
        Dim sTmp As String = "Условие поставки: "
        Dim Row As DataRow = Me.IncotermsHandbookTable.Rows.Find(C2.ToInt(Me.ARow("incotermsId")))
        If Row Is Nothing Then
            sTmp &= "[нет данных]"
        Else
            sTmp &= Row("name").ToString
        End If
        sTmp &= ". Место доставки: "
        If C2.IsText(Me.ARow("incotermsPlace")) Then
            sTmp &= C2.DelPoint(Me.ARow("incotermsPlace"))
        Else
            sTmp &= "[нет данных]"
        End If
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает перечень рисков по внешнеэкономической операции в формате Html
    ''' </summary>
    Private Function GetHtmlSupplyRisk() As String
        If CBool(Me.ARow("isNotSupplyRisk")) Then Return "Риски отсутствуют"
        Dim sTmp As String = Nothing
        Dim Row As DataRow = Nothing
        With Me.SupplyRiskTable.DefaultView
            .Sort = "riskId"
            For i As Integer = 0 To .Count - 1
                Row = Me.RiskHandbookTable.Rows.Find(.Item(i)("riskId"))
                If Not Row Is Nothing Then sTmp = String.Format("{0};</li><li>{1}", sTmp, C2.ToText(Row("caption")))
            Next
        End With
        If C2.IsText(Me.ARow("otherSupplyRisk")) Then
            sTmp = String.Format("{0};</li><li>{1}", sTmp, C2.DelPoint(Me.ARow("otherSupplyRisk")))
        End If
        If C2.IsText(sTmp) Then sTmp = String.Format("<ul class='red'>{0}</li></ul>", sTmp.Substring(6))
        Return sTmp
    End Function

#End Region
#Region "Страна назначения (отправления)"

    ''' <summary>
    ''' Возвращает профиль страны в формате Html
    ''' </summary>
    ''' <param name="countryId">ID страны</param> 
    Private Function GetHtmlCountryProfile(countryId As Object) As String
        Dim Row As DataRow = Me.CountryHandbookTable.Rows.Find(C2.ToInt(countryId))
        If Row Is Nothing Then Return Nothing
        If C2.IsText(Row("riskDescription")) Then
            Return String.Format("<ul class='red'><li>{0}</li></ul>", C2.ToText(Row("riskDescription")).Replace(vbCrLf, "</li><li>"))
        End If
        Return "Риски экспортного контроля в отношении страны отсутствуют"
    End Function

    ''' <summary>
    ''' Возвращает перечень запретов и ограничений по стране в формате Html
    ''' </summary>
    ''' <param name="countryId">ID страны</param> 
    Private Function GetHtmlCountryEmbargo(countryId As Object) As String
        Dim Row As DataRow = Me.CountryHandbookTable.Rows.Find(C2.ToInt(countryId))
        If Row Is Nothing Then Return Nothing
        Dim sTmp As String = Nothing
        Using V As New DataView(Me.EmbargoCountryHandbookTable)
            V.RowFilter = String.Format("countryId = {0}", C2.ToInt(countryId))
            If V.Count = 0 Then Return "Запреты и ограничения отсутствуют"
            V.Sort = "embargoCaption2"
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0};</li><li>{1}", sTmp, C2.ToText(V(i)("embargoCaption2")))
            Next
        End Using
        Return String.Format("<ul class='red'>{0}</li></ul>", sTmp.Substring(6))
    End Function

#End Region
#Region "Продукция (объекты экспертизы)"

    ''' <summary>
    ''' Возвращает код ТН ВЭД объекта экспертизы с описанием кода в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    Private Function GetHtmlGoodTnved(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.GoodTable Then Return Nothing
        Dim sTmp As String = C2.ToText(Row("tnved"))
        If Not C2.IsText(sTmp) Then Return Nothing
        Using Dr As SqlDataReader = Me.ExecuteReader(String.Format( _
            "SELECT description FROM tTnved WHERE code LIKE '{0}' AND dateB <= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND dateE > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
            sTmp.Replace("'", "''"), Date.Now))
            If Dr.Read Then
                sTmp = String.Format("{0} - {1}", sTmp, C2.ToText(Dr(0)))
            Else
                sTmp = String.Format("{0} - <span class='red'>[код ТН ВЭД отсутствует в актуальной редакции товарной номенклатуры]</span>", sTmp)
            End If
        End Using
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает перечень запретов и ограничений объекта экспертизы в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param> 
    Private Function GetHtmlGoodEmbargo(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.GoodTable OrElse IsDBNull(Me.ARow("countryId")) Then Return Nothing
        If CBool(Row("isNotEmbargo")) Then Return "Запреты и ограничения отсутствуют"
        Using V As New DataView(Me.EmbargoGoodHandbookTable)
            V.RowFilter = String.Format("countryId = {0}", CInt(Me.ARow("countryId")))
            If V.Count = 0 Then Return "Запреты и ограничения отсутствуют"
        End Using
        Dim sTmp As String = Nothing
        Dim Row1 As DataRow = Nothing
        Dim countryId As Integer = C2.ToInt(Me.ARow("countryId"))
        Using V As New DataView(Me.GoodEmbargoTable)
            V.RowFilter = String.Format("goodId = {0}", C2.ToInt(Row("id")))
            V.Sort = "embargoGoodId"
            For i As Integer = 0 To V.Count - 1
                Row1 = Me.EmbargoGoodHandbookTable.Rows.Find(New Object() {V(i)("embargoGoodId"), countryId})
                If Row1 Is Nothing Then Continue For
                sTmp = String.Format("{0};</li><li>{1} ({2})", sTmp, C2.ToText(Row1("goodCaption")), C2.ToText(Row1("embargoCaption2")))
            Next
        End Using
        If C2.IsText(sTmp) Then sTmp = String.Format("<ul class='red'>{0}</li></ul>", sTmp.Substring(6))
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает перечень продукции на контроле объекта экспертизы в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param> 
    Private Function GetHtmlGoodControl(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.GoodTable OrElse Not C2.IsText(Row("tnved")) Then Return Nothing
        If CBool(Row("isNotControl")) Then Return "Контролируемая продукция отсутствует"
        Using V As New DataView(Me.ControlGoodHandbookTable)
            V.RowFilter = String.Format("(goodTnved LIKE '{0}%') OR ('{0}' LIKE (goodTnved + '%'))", C2.ToText(Row("tnved")))
            If V.Count = 0 Then Return "Контролируемая продукция отсутствует"
        End Using
        Dim sTmp As String = Nothing
        Dim Row1 As DataRow = Nothing
        Using V As New DataView(Me.GoodControlTable)
            V.RowFilter = String.Format("goodId = {0}", C2.ToInt(Row("id")))
            V.Sort = "controlGoodId"
            For i As Integer = 0 To V.Count - 1
                Row1 = Me.ControlGoodHandbookTable.Rows.Find(V(i)("controlGoodId"))
                If Row1 Is Nothing Then Continue For
                sTmp = String.Format("{0};</li><li>{1}", sTmp, C2.ToText(Row1("goodName")))
            Next
        End Using
        If C2.IsText(sTmp) Then sTmp = String.Format("<ul class='red'>{0}</li></ul>", sTmp.Substring(6))
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает перечень рисков объекта экспертизы в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param> 
    Private Function GetHtmlGoodRisk(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.GoodTable Then Return Nothing
        If CBool(Row("isNotRisk")) Then Return "Риски отсутствуют"
        Dim riskType As Cprp.DxData.Risk.TypeEnum = Risk.TypeEnum.IsGood
        Dim sTmp As String = Nothing
        Dim Row1 As DataRow = Nothing
        Using V As New DataView(Me.GoodRiskTable)
            V.RowFilter = String.Format("goodId = {0}", C2.ToInt(Row("id")))
            V.Sort = "riskId"
            For i As Integer = 0 To V.Count - 1
                Row1 = Me.RiskHandbookTable.Rows.Find(V(i)("riskId"))
                If Row1 Is Nothing Then Continue For
                If CInt(Row1("typeId")) <> CInt(riskType) Then Continue For
                sTmp = String.Format("{0};</li><li>{1}", sTmp, C2.ToText(Row1("caption")))
            Next
        End Using
        If C2.IsText(Row("otherRisk")) Then
            sTmp = String.Format("{0};</li><li>{1}", sTmp, C2.DelPoint(Row("otherRisk")))
        End If
        If C2.IsText(sTmp) Then sTmp = String.Format("<ul class='red'>{0}</li></ul>", sTmp.Substring(6))
        Return sTmp
    End Function

#End Region

End Class
