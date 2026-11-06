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
        '
        ' Сведения о работе > Перечень представленных документов
        '
        Html &= "<li style='margin-top: 6pt;'><span onclick='javascript: hs(el6);'>Перечень вновь представленных документов</span>"
        Html &= "<ul id='el6'>"
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
        Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el7);'>ПЛАН МЕРОПРИЯТИЙ ПО РАБОТЕ</span>"
        Html &= "<ul id='el7'>"
        Html &= MyBase.HtmlPlaneTABLE(ContentEnum.Plane)
        Html &= "</ul>"
        Html &= "</li>"                             ' /ПЛАН РАБОТЫ
LEND:
        '
        Html &= "</ul>"                             ' /RootNode
        Html &= "</body>"
        Html &= "</html>"
        Return Html
    End Function

End Class
