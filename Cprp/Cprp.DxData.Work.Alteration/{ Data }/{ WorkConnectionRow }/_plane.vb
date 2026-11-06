Imports C2 = Cprp.DxData.Common
' +++++++++++
' План работы
' +++++++++++
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Создать документ плана работы (html)
    ''' </summary>
    Public Overrides Sub PlaneDocumentCreate()
        Dim nullText As String = "[нет данных]"     ' Стандартное сообщение об отсутствии данных

        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Dim Row As DataRow = Nothing

        Dim Html As String = "<!DOCTYPE HTML><html>"
        '
        ' Head
        '
        Html &= "<head>" & vbCrLf
        Html &= String.Format("<title>План работы № {0}</title>", CInt(Me.Id)) & vbCrLf
        Html &= "<style>" & vbCrLf
        Html &= "* {font-family: Calibri,Arial; font-size: 13pt; border-color:black}" & vbCrLf
        Html &= "h1 {font-size:14pt; font-weight:bold; margin-top:0pt; margin-bottom:18pt; text-align:center}" & vbCrLf
        Html &= "h2 {font-size:13pt; font-weight:bold; margin-top:12pt; margin-bottom:3pt; text-align:left}" & vbCrLf
        Html &= "ul, ol {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf
        Html &= "p {margin: 0pt;}" & vbCrLf
        Html &= "table {border-collapse: collapse; margin-top: 3pt;}" & vbCrLf
        Html &= "td {vertical-align: top; padding:4pt;}" & vbCrLf
        Html &= "th {font-weight: bold; text-align:center; vertical-align:top; padding:4pt;}" & vbCrLf
        Html &= "li {margin-top: 3pt;}" & vbCrLf
        Html &= "td li {margin-top: 0pt;}" & vbCrLf
        Html &= "</style>" & vbCrLf
        Html &= "</head>" & vbCrLf
        '
        ' Body
        '
        Html &= "<body>" & vbCrLf
        '
        ' Заголовок документа
        '
        Html &= String.Format("<h1>План работы № {0}</h1>", CInt(Me.Id)) & vbCrLf
        '
        ' Характеристики работы
        '
        Html &= "<h2>Характеристики работы:</h2>"
        Html &= "<table border='0'>"
        Html &= "<col><col>"
        Html &= "<tr>"
        Html &= "<td>Тип работы:</td>"
        Html &= "<td>Внесение изменений</td>"
        Html &= "</tr>"
        sTmp = C2.ToText(Me("parentId"))
        Html &= "<tr>"
        Html &= "<td>Первичная работа:</td>"
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        sTmp = Nothing
        iTmp = C2.ToInt(Me.ARow("changeSummaryId"))
        If iTmp > 0 Then
            Select Case CType(iTmp, Cprp.DxData.Work.ChangeSummary)
                Case ChangeSummary.IsUnlock : sTmp = "Разблокировать первичную работу"
                Case ChangeSummary.IsNew : sTmp = "Создать новую работу по стоимости внесения изменений"
                Case ChangeSummary.IsNewWork : sTmp = "Создать новую работу по стоимости новой работы (стоимость будет определена при утверждении плана новой работы)"
                Case ChangeSummary.IsLetter : sTmp = "Подготовить письмо заказчику"
                Case ChangeSummary.IsTalk : sTmp = "Дать устные пояснения заказчику"
            End Select
        End If
        Html &= "<tr>"
        Html &= "<td>Решение руководителя:</td>"
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        iTmp = C2.ToInt(Me.ARow("changeSourceId"))
        If iTmp > 0 Then
            sTmp = "-"
            Select Case CType(iTmp, Cprp.DxData.Work.ChangeSource)
                Case ChangeSource.IsClient : sTmp = "Изменения в представленной документации"
                Case ChangeSource.IsExpert : sTmp = "Ошибка эксперта"
                Case ChangeSource.IsLess : sTmp = "Продление срока действия заключения"
            End Select
            Html &= "<tr>"
            Html &= "<td>Причина изменений:</td>"
            Html &= String.Format("<td>{0}</td>", sTmp)
            Html &= "</tr>"
        End If
        Html &= "<tr>"
        Html &= "<td>Общая трудоемкость (мин.):</td>"
        sTmp = C2.ToText(Me.ARow("totalWork"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<td>Срок исполнения:</td>"
        sTmp = Nothing
        If Not IsDBNull(Me.ARow("expertTerm")) Then sTmp = Format("dd.MM.yyyy HH:mm", CDate(Me.ARow("expertTerm")))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "</table>"
        '
        ' Расчет стоимости работы
        '
        If Me.CalcTable.Rows.Count > 0 Then
            Html &= "<h2>Расчет стоимости работы:</h2>"
            Html &= "<table border='1'>"
            Html &= "<col><col>"
            Html &= "<tr>"
            Html &= "<th>Описание услуги</th>"
            Html &= "<th>Стоимость</th>"
            Html &= "</tr>"
            Using V As New DataView(Me.CalcTable) With {.Sort = "id"}
                For i As Integer = 0 To V.Count - 1
                    Html &= "<tr>"
                    Html &= String.Format("<td>{0}</td><td align='right'>{1}</td>", C2.ToText(V(i)("description")), C2.ToText(V(i)("price")))
                    Html &= "</tr>"
                Next
            End Using
            Html &= "<tr>"
            Html &= "<td>ИТОГО:</td>"
            sTmp = C2.ToText(Me("price"))
            Html &= String.Format("<td align='right'><b>{0}</b></td>", If(C2.IsText(sTmp), sTmp, "-"))
            Html &= "</tr>"
            Html &= "</table>"
        End If
        '
        ' Перечень документов
        '
        Html &= "<h2>Перечень документов</h2>"
        Html &= "<ul id='el0'>"
        Using V As New DataView(Me.InDocTable)
            V.RowFilter = "isUsed = True"
            If V.Count > 0 Then
                V.Sort = "rowNum"
                Html &= "<ul>"
                For i As Integer = 0 To V.Count - 1
                    Html &= String.Format("<li>{0};</li>", GetHtmlInDocCaption(V(i).Row))
                Next
                Html &= "</ul>"
            Else
                Html &= "<p style='margin-left: 18pt;'>[документы отсутствуют]</p>"
            End If
        End Using
        '
        ' План составил, план утвердил
        '
        Html &= "<br>"
        Html &= "<table border='0'>"
        Html &= "<col><col>"
        Html &= "<tr>"
        Html &= "<td>План составил:</td>"
        sTmp = GetHtmlUserNameShort(Me("expertId"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<td>План утвердил:</td>"
        sTmp = GetHtmlUserNameShort(Me("leaderId"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "</table>"
        '
        ' /body, /html
        '
        Html &= "</body>"
        Html &= "</html>"
        '
        ' Запись документа плана в данные работы
        '
        Me.ARow("planeData") = Html

    End Sub

End Class
