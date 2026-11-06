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
        ' СВЕДЕНИЯ О ЛИЦЕНЗИИ
        '
        Row = Me.LicenseTable.Rows.Find(C2.ToInt(Me.ARow("licId")))
        Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el2);'>СВЕДЕНИЯ О ЛИЦЕНЗИИ</span>"
        Html &= "<ul id='el2'>"
        Html &= "<table class='notree' width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Лицензия</a></th>", CInt(ContentEnum.License))
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("regNumCaption"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<th>Предмет внешнеэкономической операции</th>"
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("description"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<th>Документ-основание операции</th>"
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("contractName"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<th>Страна назначения</th>"
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("countryName"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<th>Российский участник операции</th>"
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("rusName"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<th>Иностранный покупатель</th>"
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("nusName"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<th>Потребитель (конечный пользователь)</th>"
        sTmp = Nothing
        If Not Row Is Nothing Then sTmp = C2.ToText(Row("endName"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "</table>"
        Html &= "</ul>"
        Html &= "</li>"                             ' /СВЕДЕНИЯ О ЛИЦЕНЗИИ
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
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Выбранныe пункты приложения к лицензии</a></th>", _
                                      CInt(ContentEnum.GoodLaw), CInt(V(i)("id")))
                sTmp = GetHtmlGoodAppend(V(i).Row)
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Технические характеристики для сравнения с выбранным пунктом</a></th>", _
                                      CInt(ContentEnum.GoodLaw), CInt(V(i)("id")))
                sTmp = C2.ToText(V(i)("goodDescription"))
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
        ' ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ
        '
        Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el6);'>ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ</span>"
        Html &= "<ul id='el6'>"
        Html &= "<table width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"
        Html &= "<tr>"
        Html &= String.Format("<th><a href='CN_{0}_0'>Дополнительная информация</a></th>", CInt(ContentEnum.ExtraInfo))
        sTmp = C2.ToText(Me.ARow("comment"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "</table>"
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ДОПОЛНИТЕЛЬНАЯ ИНФОРМАЦИЯ
LEND:
        '
        Html &= "</ul>"                             ' /RootNode
        Html &= "</body>"
        Html &= "</html>"
        Return Html
    End Function

#Region "Продукция (объекты экспертизы)"

    ''' <summary>
    ''' Возвращает код ТН ВЭД объекта экспертизы с описанием кода в формате Html
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
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
    ''' Возвращает описание пункта приложения к лицензии, которому соответствует объект экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Private Function GetHtmlGoodAppend(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.GoodTable Then Return Nothing
        Dim AppRow As DataRow = Nothing
        Dim sTmp As String = Nothing
        Using V As New DataView(Me.GoodAppendTable)
            V.RowFilter = String.Format("goodId = {0}", CInt(Row("id")))
            For i As Integer = 0 To V.Count - 1
                AppRow = Me.LicenseAppendTable.Rows.Find(CInt(V(i)("appendId")))
                If AppRow Is Nothing Then Continue For
                sTmp = String.Format("{0}<br>{1} {2}", sTmp, C2.AddPoint(AppRow("pos")), C2.DelPoint(AppRow("description")))
            Next
        End Using
        If C2.IsText(sTmp) Then Return sTmp.Substring(4)
        Return Nothing
    End Function

#End Region

End Class