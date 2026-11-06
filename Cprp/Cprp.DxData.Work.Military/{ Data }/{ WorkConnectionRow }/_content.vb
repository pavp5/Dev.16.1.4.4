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
        ' РОССИЙСКИЙ УЧАСТНИК ВНЕШНЕЭКОНОМИЧЕСКОЙ ОПЕРАЦИИ
        '
        Html &= "<li style='margin-top: 12pt;'><span onclick='javascript: hs(el7);'>РОССИЙСКИЙ УЧАСТНИК ВНЕШНЕЭКОНОМИЧЕСКОЙ ОПЕРАЦИИ</span>"
        Html &= "<ul id='el7'>"
        Html &= "<table class='notree' width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Наименование и реквизиты</a></th>", CInt(ContentEnum.SupplyRusData))
        sTmp = GetHtmlMemberCaption()
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "</table>"
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /РОССИЙСКИЙ УЧАСТНИК ВНЕШНЕЭКОНОМИЧЕСКОЙ ОПЕРАЦИИ
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
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Классификатор ПВН</a></th>", _
                                      CInt(ContentEnum.GoodLaw), CInt(V(i)("id")))
                sTmp = GetHtmlGoodClassificator(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Анализ</a></th>", _
                                      CInt(ContentEnum.GoodSummary), CInt(V(i)("id")))
                sTmp = C2.ToText(V(i)("summary"))
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
        Html &= String.Format("<th><a href='CN_{0}_0'>ВЫВОДЫ ЭКСПЕРТИЗЫ</a></th>", CInt(ContentEnum.Summary))
        sTmp = C2.ToText(Me.ARow("summary"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "</table>"
        Html &= "</ul>"
        Html &= "</li>"                             ' /РЕШЕНИЕ ПО АНАЛИЗУ
LEND:
        Html &= "</ul>"                             ' /RootNode
        Html &= "</body>"
        Html &= "</html>"
        Return Html
    End Function

#Region "Российский участник внешнеэкономической операции"

    ''' <summary>
    ''' Возвращает наименование и реквизиты лица в формате Html
    ''' </summary>
    Private Function GetHtmlMemberCaption() As String
        If Me.MemberTable Is Nothing OrElse Me.MemberTable.IsEmpty Then Return Nothing
        Dim Row As DataRow = Me.MemberTable.Rows(0)
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
    ''' Возвращает сведения о Классификаторе ПВН строки таблицы объектов экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    Private Function GetHtmlGoodClassificator(Row As DataRow) As String
        If Row Is Nothing OrElse Row.Table Is Nothing OrElse Not Row.Table Is Me.GoodTable Then Return False
        Dim LRow As DataRow = Me.LawDataSet.LawTable.Rows.Find(C2.ToInt(Row("lawId")))
        If LRow Is Nothing Then Return Nothing
        Dim sTmp As String = C2.ToText(LRow("posDescription"))
        LRow = Me.LawDataSet.LawTable.Rows.Find(C2.ToInt(LRow("parentId")))
        Do
            If LRow Is Nothing OrElse CType(LRow("typeId"), Cprp.DxData.Law.TypeEnum) <> Law.TypeEnum.IsParagraph Then Exit Do
            sTmp = String.Format("{0}<br>{1}", C2.ToText(LRow("posDescription")), sTmp)
            LRow = Me.LawDataSet.LawTable.Rows.Find(C2.ToText(LRow("parentId")))
        Loop
        Return sTmp
    End Function


#End Region

End Class

