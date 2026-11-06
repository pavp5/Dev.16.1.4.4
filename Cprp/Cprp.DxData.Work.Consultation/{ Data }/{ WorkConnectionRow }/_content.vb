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
        ' ПОСТАВЛЕННЫЕ ВОПРОСЫ
        '
        Html &= String.Format("<li style='margin-top: 18pt;'><span onclick='javascript: hs(el14);'>ПОСТАВЛЕННЫЕ ВОПРОСЫ</span> <a href='CN_{0}_0'>[список]</a>", CInt(ContentEnum.QueryList))
        Html &= "<ul id='el14'>"
        Using V As New DataView(Me.QueryTable)
            If V.Count = 0 Then
                Html &= "<p>[нет данных]</p>"
                GoTo LEND
            End If
            For i As Integer = 0 To V.Count - 1
                '
                ' ПОСТАВЛЕННЫЕ ВОПРОСЫ > ВОПРОС №
                '
                elId += 1
                Html &= String.Format("<li><span onclick='javascript: hs(el{0});'>Вопрос № {1}.</span>", elId, CInt(V(i)("rowNum")))
                Html &= String.Format("<ul id='el{0}'>", elId)
                Html &= "<table class='notree' width='100%' border='1'>"
                Html &= "<col width='312pt'><col>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Вопрос</a></th>", CInt(ContentEnum.QueryData), CInt(V(i)("id")))
                sTmp = C2.ToText(V(i)("ask"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp.Replace(vbCrLf, "<br>"), NULL_TEXT))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_{1}'>Ответ</a></th>", CInt(ContentEnum.QueryData), CInt(V(i)("id")))
                sTmp = C2.ToText(V(i)("ans"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp.Replace(vbCrLf, "<br>"), NULL_TEXT))
                Html &= "</tr>"
                Html &= "</table>"
                Html &= "</ul>"
                Html &= "</li>"                     ' /ПОСТАВЛЕННЫЕ ВОПРОСЫ > ВОПРОС №
            Next
        End Using
        '
        Html &= "</ul>"
        Html &= "</li>"                             ' /ПОСТАВЛЕННЫЕ ВОПРОСЫ
LEND:
        '
        Html &= "</ul>"                             ' /RootNode
        Html &= "</body>"
        Html &= "</html>"
        Return Html
    End Function

End Class