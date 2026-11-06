Imports C2 = Cprp.DxData.Common
' =======================================
' Содержание работы в виде HTML-документа
' =======================================
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Возвращает содержание работы в виде HTML-документа
    ''' </summary>
    Public MustOverride Function GetHtmlContent() As String

#Region "Таблица стилей и скрипты документа"

    ''' <summary>
    ''' Таблица стилей и скрипты документа
    ''' </summary>
    Protected Const HTML_CSS_JS As String = _
        "<style media='screen'>" & vbCrLf & _
        "* {font-family: Calibri,Arial; font-size: 13pt; border-color:black}" & vbCrLf & _
        "ul, ol {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf & _
        "p {margin: 0pt;}" & vbCrLf & _
        "table {border-collapse: collapse; margin-top: 3pt;}" & vbCrLf & _
        "td {vertical-align: top; padding:4pt;}" & vbCrLf & _
        "th {font-weight:normal; font-style:italic; vertical-align:middle; padding:4pt;}" & vbCrLf & _
        "a {color:#000080; text-decoration:none}" & vbCrLf & _
        "a:hover {font-weight:bold;}" & vbCrLf & _
        ".tree span:hover {font-weight: bold;}" & vbCrLf & _
        ".tree span {font-size:14pt; cursor: pointer;}" & vbCrLf & _
        "li {margin-top: 3pt;}" & vbCrLf & _
        "td li {margin-top: 0pt;}" & vbCrLf & _
        ".notree span:hover {font-weight: normal;}" & vbCrLf & _
        ".notree span {font-size:13pt; cursor: auto;}" & vbCrLf & _
        ".red {color: red;}" & vbCrLf & _
        ".byellow {background-color: lightyellow;}" & vbCrLf & _
        ".bazure {background-color: azure;}" & vbCrLf & _
        ".hidden {display: none;}" & vbCrLf & _
        ".comment {margin: 0pt 0pt 9pt 18pt}" & vbCrLf & _
        ".comment-caption {color: #696969}" & vbCrLf & _
        "</style>" & vbCrLf & _
        "<style media='print'>" & vbCrLf & _
        "* {font-family: Calibri,Arial; font-size: 9pt; border-color:black}" & vbCrLf & _
        "ul {margin-left: 12pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf & _
        "p {margin: 0pt;}" & vbCrLf & _
        "table {border-collapse: collapse;}" & vbCrLf & _
        "td {vertical-align: top;padding:2pt;}" & vbCrLf & _
        "th {font-weight:normal; font-style:italic; vertical-align:middle; padding:2pt;}" & vbCrLf & _
        "a {color:black; text-decoration:none}" & vbCrLf & _
        "</style>" & vbCrLf & _
        "<script language='JavaScript' type='text/javascript'>" & vbCrLf & _
        "<!-- " & vbCrLf & _
        "function hs(el) {el.className = (el.className == 'hidden') ? '' : 'hidden';}" & vbCrLf & _
        " -->" & vbCrLf & _
        "</script>" & vbCrLf

#End Region

    ''' <summary>
    ''' Нет данных
    ''' </summary>
    Protected Const NULL_TEXT As String = "[нет данных]"

#Region "Сведения о работе"

    ''' <summary>
    ''' Возвращает сведения о работе в виде таблицы HTML
    ''' </summary>
    Protected Function HtmlWorkInfoTABLE() As String
        Dim Html As String = Nothing
        Dim sTmp As String = Nothing
        Html &= "<table width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"
        Html &= "<tr>"
        Html &= "<th>Работа</th>"
        sTmp = GetHtmlWorkCaption()
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        If Not IsDBNull(Me("pId")) Then
            Html &= "<tr>"
            Html &= String.Format("<th><a href='OPEN_WORK_{0}'>Заявка</a></th>", CInt(Me("pId")))
            Html &= String.Format("<td>№ {0}</td>", CInt(Me("pId")))
            Html &= "</tr>"
        End If
        If Not IsDBNull(Me("parentId")) Then
            Html &= "<tr>"
            Html &= String.Format("<th><a href='OPEN_WORK_{0}'>Первичная работа</a></th>", CInt(Me("parentId")))
            sTmp = GetHtmlFirstWorkCaption()
            Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
            Html &= "</tr>"
        End If
        If Me.Type <> WorkType.IsAlteration AndAlso Me.Type <> WorkType.IsOrder Then
            Html &= "<tr>"
            Html &= "<th><a href='WORK_DESCRIPTION'>Продукция</a></th>"
            sTmp = C2.ToText(Me("description"))
            Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
            Html &= "</tr>"
        End If
        Html &= "<tr>"
        sTmp = C2.ToText(Me("clientInn"))
        If String.IsNullOrWhiteSpace(sTmp) Then
            Html &= "<th>Заказчик</th>"
        Else
            Html &= String.Format("<th>{0}</th>", GetHtmlClientCaptionLink(sTmp))
        End If
        sTmp = GetHtmlClientCaption()
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        sTmp = C2.ToText(Me("orderUrl"))
        sTmp = If(C2.IsText(sTmp), String.Format("<a href='{0}' target=_blank>Заказ</a>", sTmp), "Заказ")
        Html &= String.Format("<th>{0}</th>", sTmp)
        sTmp = GetHtmlOrderCaption()
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        'Select Case C2.ToInt(Me("urgencyId"))
        '    Case 2
        '        sTmp = "<span class='red'>Ускоренная (8 рабочих часов)</span>"
        '    Case 3
        '        sTmp = "<span class='red'>Срочная (4 рабочих часа)</span>"
        '    Case Else
        '        sTmp = "Стандартная (16 рабочих часов)"
        'End Select
        'Html &= "<tr>"
        'Html &= "<th>Срочность</th>"
        'Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        'Html &= "</tr>"
        If Me.Type <> WorkType.IsOrder Then
            Html &= "<tr>"
            Html &= "<th>Эксперт</th>"
            sTmp = GetHtmlUserNameLong(Me("expertId"))
            Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
            Html &= "</tr>"
        End If
        If Me.Condition <> WorkCondition.IsNew Then
            Html &= "<tr>"
            Html &= "<th>Срок исполнения</th>"
            sTmp = GetHtmlExpertTerm()
            Html &= String.Format("<td class='notree'>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
            Html &= "</tr>"
        End If
        Html &= "<tr>"
        Html &= "<th>Руководитель</th>"
        sTmp = GetHtmlUserNameLong(Me("leaderId"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<th>Менеджер</th>"
        sTmp = GetHtmlUserNameLong(Me("managerId"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "<tr>"
        If Me.Type <> WorkType.IsAlteration AndAlso Me.Type <> WorkType.IsOrder Then
            Html &= "<th><a href='WORK_COMMENT'>Комментарии</a></th>"
        Else
            Html &= "<th>Комментарии</th>"
        End If
        'sTmp = C2.ToText(Me("comment"))
        'Html &= String.Format("<td class='notree'>{0}</td>", If(C2.IsText(sTmp), String.Format("<span class='red'>{0}</span>", sTmp), NULL_TEXT))
        sTmp = Nothing
        Using V As New DataView(Me.WorkCommentTable)
            V.Sort = "createDate DESC"
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0}<div class='comment-caption'>{1:dd.MM.yyyy HH:mm} {2}:</div><div class='comment'>{3}</div>", sTmp, CDate(V(i)("createDate")), C2.DelPoint(V(i)("authorName")), C2.ToText(V(i)("comment")))
            Next
        End Using
        Html &= String.Format("<td class='notree'>{0}</td>", If(C2.IsText(sTmp), sTmp, NULL_TEXT))
        Html &= "</tr>"
        Html &= "</table>"
        Return Html
    End Function

    ''' <summary>
    ''' Заголовок работы
    ''' </summary>
    Private Function GetHtmlWorkCaption() As String
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        '
        ' Номер работы
        '
        sTmp = String.Format("№ {0}", CInt(Me.Id))
        '
        ' Вид работы
        '
        sTmp1 = "[нет вида работы]"
        Select Case Me.Type
            Case WorkType.IsExCont : sTmp1 = "Идентификационная экспертиза по экспортному контролю"
            Case WorkType.IsCustomUnion : sTmp1 = "Экспертиза по запретам и ограничениям ЕАЭС"
            Case WorkType.IsLiconfirm : sTmp1 = "Подтверждение лицензии"
            Case WorkType.IsTnved : sTmp1 = "Определение кода ТН ВЭД"
            Case WorkType.IsMilitary : sTmp1 = "Экспертиза по гражданскому назначению"
            Case WorkType.IsConsultation : sTmp1 = "Консультация по ВЭД"
            Case WorkType.IsOrder : sTmp1 = "Рассмотрение заявки на оказание услуг"
            Case WorkType.IsAlteration : sTmp1 = "Рассмотрение заявки на внесение изменений"
            Case WorkType.IsLicense : sTmp1 = "Оформление лицензии ФСТЭК / разрешения КЭК"
        End Select
        If Not IsDBNull(Me.ARow("sortId")) AndAlso CType(Me.ARow("sortId"), WorkSort) = WorkSort.IsChange Then
            sTmp1 = "Внесение изменений в ранее выполненную работу"
        End If
        sTmp = String.Format("{0} / {1}", sTmp, sTmp1)
        '
        ' Состояние работы
        '
        sTmp1 = "[нет состояния]"
        Select Case Me.Condition
            Case WorkCondition.IsNew : sTmp1 = "Новая"
            Case WorkCondition.IsWork : sTmp1 = "В работе"
            Case WorkCondition.IsQuery : sTmp1 = "Запрос"
            Case WorkCondition.IsCheck : sTmp1 = "Проверка"
            Case WorkCondition.IsAgree : sTmp1 = "Утверждение"
            Case WorkCondition.IsAccept : sTmp1 = "Утверждена"
            Case WorkCondition.IsClose : sTmp1 = "Закрыта"
            Case WorkCondition.IsCancel : sTmp1 = "Аннулирована"
            Case WorkCondition.IsPlaneWork : sTmp1 = "Подготовка плана"
            Case WorkCondition.IsPlaneAgree : sTmp1 = "Утверждение плана"
            Case WorkCondition.IsPlaneQuery : sTmp1 = "Запрос"
            Case WorkCondition.IsNewQuery : sTmp1 = "Запрос"
            Case WorkCondition.IsOrderQuery : sTmp1 = "Запрос"
        End Select
        sTmp = String.Format("{0} / {1}", sTmp, sTmp1)

        If Me.Type <> WorkType.IsAlteration AndAlso Me.Type <> WorkType.IsOrder Then
            ''
            '' Счет подписан / Счет не подписан
            ''
            'sTmp1 = If(CBool(Me("isPrice")), "Счет подписан", "Счет не подписан")
            'sTmp = String.Format("{0} / {1}", sTmp, sTmp1)
            '
            ' Оплачена / Неоплачена
            '
            If CType(Me.ARow("changeSourceId"), ChangeSource) = ChangeSource.IsFreeWork Then
                sTmp1 = "Без оплаты"
            ElseIf IsDBNull(Me("paymentDate")) Then
                sTmp1 = "Не оплачена"
            Else
                sTmp1 = String.Format("Оплачена {0:dd.MM.yyyy HH:mm}", CDate(Me("paymentDate")))
            End If
            sTmp = String.Format("{0} / {1}", sTmp, sTmp1)
        End If

            Return sTmp
    End Function

    ''' <summary>
    ''' Заголовок первичной работы
    ''' </summary>
    Private Function GetHtmlFirstWorkCaption() As String
        Dim sTmp As String = Nothing
        Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT id, description, countryName, expertName FROM vWorkData WHERE id = {0}", C2.ToInt(Me("parentId"))))
            If Dr.Read Then
                sTmp = String.Format("{0}, Продукция: {1}, Страна: {2}, Эксперт: {3}", CInt(Dr("id")), C2.ToText(Dr("description")), C2.ToText(Dr("countryName")), C2.ToText(Dr("expertName")))
            End If
        End Using
        Return sTmp
    End Function

    ''' <summary>
    ''' Пояснения эксперта по внесение изменений
    ''' </summary>
    Private Function GetHtmlExpertAlteration() As String
        If Me.Type <> WorkType.IsAlteration Then Return Nothing
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = C2.ToInt(Me.ARow("changeSourceId"))
        Select Case iTmp
            Case 1 : sTmp = "Дополнительная экспертиза"
            Case 2 : sTmp = "Ошибка эксперта"
            Case 3 : sTmp = "Продление срока действия"
            Case Else
                sTmp = "[нет данных]"
        End Select
        sTmp = String.Format("Причина изменений: {0}.", sTmp)
        If Not IsDBNull(Me.ARow("expertComment")) Then
            sTmp = String.Format("{0}<br>Пояснения эксперта: {1}", sTmp, C2.AddPoint(Me.ARow("expertComment")))
        End If
        If Not IsDBNull(Me.ARow("expertTerm")) Then
            sTmp = String.Format("{0}<br>Срок исполнения: {1: dd.MM.yyyy HH:mm}", sTmp, CDate(Me.ARow("expertTerm")))
        End If
        If Not IsDBNull(Me.ARow("totalWork")) Then
            sTmp = String.Format("{0}; трудоемкость: {1} мин.", sTmp, CInt(Me.ARow("totalWork")))
        End If
        Return sTmp
    End Function

    ''' <summary>
    ''' Заголовок поля Заказчик в сведениях о работе
    ''' </summary>
    ''' <param name="inn">ИНН заказчика</param>
    Public Function GetHtmlClientCaptionLink(inn As String) As String
        Dim sTmp As String = "Заказчик"
        inn = C2.ToText(inn)
        If Not C2.IsText(inn) Then Return sTmp
        Dim iTmp As Integer = C2.ToInt(Me.ExecuteScalar(String.Format("SELECT COUNT(DISTINCT orderNum) FROM tWork WHERE clientInn = '{0}'", inn)))
        sTmp = String.Format("{0} (заказов: {1}", sTmp, iTmp)
        iTmp = C2.ToInt(Me.ExecuteScalar(String.Format("SELECT COUNT(DISTINCT docNum) FROM tFInfo WHERE rusInn = '{0}'", inn)))
        sTmp = String.Format("{0}, лицензий: {1})", sTmp, iTmp)
        If iTmp > 0 Then Return String.Format("<a class='red' href='MEMBER_PROFILE_{0}'>{1}</a>", inn, sTmp)
        Return String.Format("<a href='MEMBER_PROFILE_{0}'>{1}</a>", inn, sTmp)
    End Function


    ''' <summary>
    ''' Перечень контролируемых заключений российского лица из сведений из ФСТЭК
    ''' </summary>
    ''' <param name="inn">ИНН лица</param>
    ''' <param name="summaryId">Идентификатор выводов экспертизы (2 или 3)</param>
    Public Function GetHtmlMemberControlDoc(inn As String, summaryId As Integer) As String
        If Not Cprp.DxData.Common.IsText(inn) Then Return Nothing
        Dim sTmp As String = String.Format("SELECT DISTINCT docNumDate, docDate FROM vFInfo WHERE rusInn LIKE '{0}%' AND summaryId = {1} ORDER BY 2 DESC", inn, summaryId)
        Using Dr As SqlDataReader = Me.ExecuteReader(sTmp)
            sTmp = Nothing
            Dim iTmp As Integer = 0
            While Dr.Read
                If iTmp > 5 Then
                    sTmp &= " ..."
                    Exit While
                End If
                sTmp = String.Format("{0}; {1}", sTmp, Dr(0).ToString)
                iTmp += 1
            End While
        End Using
        If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = sTmp.Substring(2)
        Return sTmp
    End Function

    ''' <summary>
    ''' Наименование и реквизиты заказчика экспертизы
    ''' </summary>
    Private Function GetHtmlClientCaption() As String
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        '
        ' Наименование
        '
        sTmp = C2.ToText(Me("clientName"))
        If Not C2.IsText(sTmp) Then sTmp = "[нет наименования]"
        '
        ' Юридический адрес
        '
        sTmp1 = C2.ToText(Me("clientAddress"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, {1}", sTmp, sTmp1)
        '
        ' ИНН
        '
        sTmp1 = C2.ToText(Me("clientInn"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, ИНН: {1}", sTmp, sTmp1)
        '
        ' КПП
        '
        sTmp1 = C2.ToText(Me("clientKpp"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, КПП: {1}", sTmp, sTmp1)
        '
        ' Телефон
        '
        sTmp1 = C2.ToText(Me("clientPhone"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, тел: {1}", sTmp, sTmp1)
        '
        ' Факс
        '
        sTmp1 = C2.ToText(Me("clientFax"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0}, факс: {1}", sTmp, sTmp1)
        '
        ' Риски по заказчику
        '
        sTmp1 = C2.ToText(Me("clientInn"))
        If C2.IsText(sTmp1) Then
            Dim risk As String = Nothing
            Dim details As String = Nothing
            Using dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT description, details FROM tClientRisk WHERE inn LIKE '{0}'", sTmp1))
                If dr.Read Then
                    risk = C2.ToText(dr(0))
                    details = C2.ToText(dr(1))
                End If
            End Using
            If C2.IsText(risk) Then
                sTmp = String.Format("{0}<br><u>Риски по заказчику из ЭО:</u><br>{1}", sTmp, risk)
                If C2.IsText(details) Then sTmp = String.Format("{0}<br>{1}", sTmp, details)
            End If
        End If

        Return C2.DelPoint(sTmp)
    End Function

    ''' <summary>
    ''' Номер и дата заказа
    ''' </summary>
    Private Function GetHtmlOrderCaption() As String
        Dim sTmp As String = Nothing
        '
        ' Номер
        '
        sTmp = C2.ToText(Me("orderNum"))
        If Not C2.IsText(sTmp) Then sTmp = "[нет номера]"
        '
        ' Дата
        '
        If Not IsDBNull(Me("orderDate")) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(Me("orderDate")))

        Return sTmp
    End Function

    ''' <summary>
    ''' Фамилия Имя Отчество лица
    ''' </summary>
    ''' <param name="userId">ID лица в таблице лиц</param> 
    Private Function GetHtmlUserNameLong(userId As Object) As String
        Dim sTmp As String = Nothing
        Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT nameLong FROM tUser WHERE id = {0}", C2.ToInt(userId)))
            If Dr.Read Then sTmp = C2.ToText(Dr(0))
        End Using
        Return sTmp
    End Function

    ''' <summary>
    ''' Срок сдачи работы экспертом
    ''' </summary>
    Private Function GetHtmlExpertTerm() As String
        If IsDBNull(Me("expertTerm")) Then Return Nothing
        Dim dTmp As Date = CDate(Me("expertTerm"))
        If dTmp > Date.Now.AddMinutes(30) Then
            Return String.Format("{0:dd.MM.yyyy HH:mm}", dTmp)
        Else
            Select Case Me.Condition
                Case WorkCondition.IsNew, WorkCondition.IsWork, WorkCondition.IsQuery, WorkCondition.IsPlaneWork
                    Return String.Format("<span class='red'>{0:dd.MM.yyyy HH:mm}</span>", dTmp)
                Case Else
                    Return String.Format("{0:dd.MM.yyyy HH:mm}", dTmp)
            End Select
        End If
    End Function

#End Region
#Region "Перечень представленных / использованных документов"

    ''' <summary>
    ''' Возвращает перечень представленных документов в формате списка HTML
    ''' </summary>
    ''' <param name="usedOnly">Только использованные</param>
    Protected Function HtmlInDocLI(usedOnly As Boolean) As String
        Dim Html As String = Nothing
        Dim sTmp As String = Nothing
        Dim orderTemplate As String = "ЗАЯВКА *"
        Dim goodListTemplate As String = "PERECHEN-PRODUKTSII*"
        Using V As New DataView(Me.InDocTable)
            If usedOnly Then V.RowFilter = "isUsed = True"
            V.Sort = "rowNum"
            If V.Count = 0 Then
                Html &= String.Format("<li>{0}</li>", NULL_TEXT)
            Else
                '
                ' Заявка
                '
                For i As Integer = 0 To V.Count - 1
                    sTmp = C2.DelPoint(V(i)("caption"))
                    If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                    If Not sTmp.ToUpper Like orderTemplate Then Continue For
                    Html = String.Format("{0}<li>{1}</li>", Html, GetHtmlInDocCaption(V(i).Row))
                Next
                '
                ' Перечень товаров
                '
                For i As Integer = 0 To V.Count - 1
                    sTmp = C2.DelPoint(V(i)("caption"))
                    If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                    If Not sTmp.ToUpper Like goodListTemplate Then Continue For
                    Html = String.Format("{0}<li>{1}</li>", Html, GetHtmlInDocCaption(V(i).Row))
                Next
                '
                ' Следующие документы
                '
                For i As Integer = 0 To V.Count - 1
                    sTmp = C2.DelPoint(V(i)("caption"))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then
                        sTmp = sTmp.ToUpper
                        If sTmp Like orderTemplate Then Continue For
                        If sTmp Like goodListTemplate Then Continue For
                    End If
                    Html = String.Format("{0}<li>{1}</li>", Html, GetHtmlInDocCaption(V(i).Row))
                Next
            End If
        End Using
        Return Html
    End Function


    ''' <summary>
    ''' Возвращает перечень представленных документов в формате таблицы HTML
    ''' </summary>
    ''' <param name="usedOnly">Только использованные</param>
    Protected Function HtmlInDocTable(usedOnly As Boolean) As String
        Dim Html As String = Nothing
        Dim sTmp As String = Nothing
        Dim orderTemplate As String = "ЗАЯВКА *"
        Dim goodListTemplate As String = "PERECHEN-PRODUKTSII*"
        Using V As New DataView(Me.InDocTable)
            If usedOnly Then V.RowFilter = "isUsed = True"
            V.Sort = "rowNum"
            If V.Count = 0 Then
                Html &= String.Format("<li>{0}</li>", NULL_TEXT)
            Else
                Html &= "<table width='100%' border='1' rules='groups'>"
                Html &= "<col><col width='50pt' align='center'><col width='50pt' align='center'><col width='50pt' align='center'>"
                Html &= "<thead><tr>"
                Html &= "<th>Наименование или краткое содержание</th>"
                Html &= "<th>Вх.</th>"
                Html &= "<th>Исх.</th>"
                Html &= "<th>Вн.</th>"
                Html &= "</tr></thead><tbody>"
                '
                ' Заявка
                '
                For i As Integer = 0 To V.Count - 1
                    sTmp = C2.DelPoint(V(i)("caption"))
                    If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                    If Not sTmp.ToUpper Like orderTemplate Then Continue For
                    Html &= "<tr>"
                    Html &= String.Format("<td>{0}</td>", GetHtmlInDocCaption(V(i).Row))
                    Html &= String.Format("<td>{0}</td>", If(C2.ToInt(V(i)("kindId")) = 1, "+", " "))
                    Html &= String.Format("<td>{0}</td>", If(C2.ToInt(V(i)("kindId")) = 2, "+", " "))
                    Html &= String.Format("<td>{0}</td>", If(C2.ToInt(V(i)("kindId")) = 3, "+", " "))
                    Html &= "</tr>"
                Next
                '
                ' Перечень товаров
                '
                For i As Integer = 0 To V.Count - 1
                    sTmp = C2.DelPoint(V(i)("caption"))
                    If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                    If Not sTmp.ToUpper Like goodListTemplate Then Continue For
                    Html &= "<tr>"
                    Html &= String.Format("<td>{0}</td>", GetHtmlInDocCaption(V(i).Row))
                    Html &= String.Format("<td>{0}</td>", If(C2.ToInt(V(i)("kindId")) = 1, "+", " "))
                    Html &= String.Format("<td>{0}</td>", If(C2.ToInt(V(i)("kindId")) = 2, "+", " "))
                    Html &= String.Format("<td>{0}</td>", If(C2.ToInt(V(i)("kindId")) = 3, "+", " "))
                    Html &= "</tr>"
                Next
                '
                ' Следующие документы
                '
                For i As Integer = 0 To V.Count - 1
                    sTmp = C2.DelPoint(V(i)("caption"))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then
                        sTmp = sTmp.ToUpper
                        If sTmp Like orderTemplate Then Continue For
                        If sTmp Like goodListTemplate Then Continue For
                    End If
                    Html &= "<tr>"
                    Html &= String.Format("<td>{0}</td>", GetHtmlInDocCaption(V(i).Row))
                    Html &= String.Format("<td>{0}</td>", If(C2.ToInt(V(i)("kindId")) = 1, "+", " "))
                    Html &= String.Format("<td>{0}</td>", If(C2.ToInt(V(i)("kindId")) = 2, "+", " "))
                    Html &= String.Format("<td>{0}</td>", If(C2.ToInt(V(i)("kindId")) = 3, "+", " "))
                    Html &= "</tr>"
                Next
                Html &= "</table>"
            End If
        End Using
        Return Html
    End Function

    ''' <summary>
    ''' Наименование представленного документа
    ''' </summary>
    ''' <param name="Row">Строка таблицы представленных документов</param>
    ''' <remarks></remarks>
    Protected Function GetHtmlInDocCaption(Row As DataRow) As String
        If Row Is Nothing OrElse Not Row.Table Is Me.InDocTable Then Return Nothing
        Dim sTmp As String = C2.DelPoint(Row("caption"))
        If Not C2.IsText(sTmp) Then sTmp = "[нет наименования документа]"
        Dim sTmp1 As String = C2.ToText(Row("regNum"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0} № {1}", sTmp, sTmp1)
        sTmp1 = C2.ToText(Row("regDate"))
        If C2.IsText(sTmp1) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(sTmp1))
        sTmp1 = C2.ToText(Row("docUrl"))
        If C2.IsText(Row("ext")) Then
            sTmp = String.Format("<a href='{0}&EXT={1}'>{2}</a>", sTmp1, C2.ToText(Row("ext")), sTmp)
            ' проверка кодов ККС
            If sTmp.ToUpper Like "*ПЕРЕЧЕНЬ*ТОВАРОВ*XLSX*" OrElse sTmp.ToUpper Like "*ПЕРЕЧЕНЬ*ПРОДУКЦИИ*XLSX*" Then
                sTmp = String.Format("{0} <a href='{1}&KKS'>(kks)</a>", sTmp, sTmp1)
            End If
        Else
            sTmp = String.Format("<a href='{0}' target='_blank'>{1}</a>", sTmp1, sTmp)
        End If
        Return sTmp
    End Function

#End Region
#Region "План работы"

    ''' <summary>
    ''' Возвращает план работы в виде таблицы HTML
    ''' </summary>
    ''' <param name="elId">ID связанного элемента управления</param> 
    Protected Function HtmlPlaneTABLE(elId As Integer) As String
        Dim Html As String = Nothing
        Dim iTmp As Integer = 0
        Dim sTmp As String = Nothing
        Html &= "<table class='notree' width='100%' border='1'>"
        Html &= "<col width='336pt'><col>"
        If Me.Type <> WorkType.IsAlteration Then
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Вид работы</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", GetHtmlWorkTypeExpert())
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= "<th>Тип работы</th>"
            Html &= String.Format("<td>{0}</td>", GetHtmlWorkSort())
            Html &= "</tr>"
            iTmp = C2.ToInt(Me.ARow("changeSourceId"))
            If iTmp > 0 Then
                Select Case CType(iTmp, ChangeSource)
                    Case ChangeSource.IsClient : sTmp = "Изменения в представленной документации"
                    Case ChangeSource.IsExpert : sTmp = "Ошибка эксперта"
                    Case ChangeSource.IsLess : sTmp = "Продление срока действия заключения"
                    Case Else
                        sTmp = NULL_TEXT
                End Select
                Html &= "<tr>"
                Html &= "<th>Причина изменений</th>"
                Html &= String.Format("<td>{0}</td>", sTmp)
                Html &= "</tr>"
            End If
            Html &= "<tr>"
            If Me.Type = WorkType.IsConsultation Then
                Html &= String.Format("<th><a href='CN_{0}_0'>Количество поставленных вопросов</a></th>", elId)
            Else
                Html &= String.Format("<th><a href='CN_{0}_0'>Количество товаров по спецификации</a></th>", elId)
            End If
            Html &= String.Format("<td>{0}</td>", If(IsDBNull(Me.ARow("goodCount")), NULL_TEXT, CInt(Me.ARow("goodCount"))))
            Html &= "</tr>"
            If Me.Type <> WorkType.IsConsultation Then
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_0'>Количество материальных объектов исследования</a></th>", elId)
                Html &= String.Format("<td>{0}</td>", If(IsDBNull(Me.ARow("matCount")), NULL_TEXT, CInt(Me.ARow("matCount"))))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_0'>Количество информационных объектов исследования</a></th>", elId)
                Html &= String.Format("<td>{0}</td>", If(IsDBNull(Me.ARow("infCount")), NULL_TEXT, CInt(Me.ARow("infCount"))))
                Html &= "</tr>"
            End If
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Количество документов на иностранном языке</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(IsDBNull(Me.ARow("langCount")), NULL_TEXT, CInt(Me.ARow("langCount"))))
            Html &= "</tr>"
            If Me.Type <> WorkType.IsConsultation AndAlso Me.Type <> WorkType.IsTnved Then
                Html &= "<tr>"
                Html &= String.Format("<th><a href='CN_{0}_0'>Количество дополнительных работ</a></th>", elId)
                Html &= String.Format("<td>{0}</td>", If(IsDBNull(Me.ARow("addWorkCount")), NULL_TEXT, CInt(Me.ARow("addWorkCount"))))
                Html &= "</tr>"
            End If
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Общая трудоемкость (мин.)</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(IsDBNull(Me.ARow("totalWork")), NULL_TEXT, CInt(Me.ARow("totalWork"))))
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Срок исполнения</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(IsDBNull(Me.ARow("expertTerm")), NULL_TEXT, String.Format("{0:dd.MM.yyyy HH:mm}", Me.ARow("expertTerm"))))
            Html &= "</tr>"
            Html &= "<tr>"
            'Html &= String.Format("<th><a href='CN_{0}_0'>Срочная работа</a></th>", elId)
            'Html &= String.Format("<td>{0}</td>", If(CBool(Me.ARow("isUrgency")), "Да", "Нет"))
            Select Case CType(Me.ARow("urgencyId"), UrgencyType)
                Case UrgencyType.IsHigh : sTmp = "Срочная (4 рабочих часа)" : Exit Select
                Case UrgencyType.IsElevated : sTmp = "Повышенная (8 рабочих часов)" : Exit Select
                Case Else : sTmp = "Без срочности (16 рабочих часов)"
            End Select
            Html &= String.Format("<th><a href='CN_{0}_0'>Срочность</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", sTmp)
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Коэффициент за сложность</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", Me.ARow("complexity").ToString)
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Без оплаты</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(CInt(Me.ARow("changeSourceId")) = 4, "Да", "Нет"))
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Запрос дополнительной информации</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(CBool(Me.ARow("isSendQuery")), "<span class='red'>Да</span>", "Нет"))
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Заполнение профилей иностранных участников</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(CBool(Me.ARow("isMakeProfile")), "Да", "Нет"))
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Комментарий эксперта</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(C2.IsText(Me.ARow("planeComment")), C2.ToText(Me.ARow("planeComment")), NULL_TEXT))
            Html &= "</tr>"
        Else
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Резолюция руководителя</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(C2.IsText(Me.ARow("leaderComment")), C2.ToText(Me.ARow("leaderComment")), NULL_TEXT))
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Пояснения эксперта</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(C2.IsText(Me.ARow("expertComment")), C2.ToText(Me.ARow("expertComment")), NULL_TEXT))
            Html &= "</tr>"
            iTmp = C2.ToInt(Me.ARow("changeSummaryId"))
            sTmp = NULL_TEXT
            If iTmp > 0 Then
                Select Case CType(iTmp, ChangeSummary)
                    Case ChangeSummary.IsUnlock : sTmp = "Разблокировать старую работу"
                    Case ChangeSummary.IsNew : sTmp = "Создать новую работу"
                    Case ChangeSummary.IsLetter : sTmp = "Подготовить письмо"
                    Case Else
                        sTmp = NULL_TEXT
                End Select
            End If
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Решение по результатам рассмотрения</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", sTmp)
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Общая трудоемкость (мин.)</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(IsDBNull(Me.ARow("totalWork")), NULL_TEXT, CInt(Me.ARow("totalWork"))))
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Срок исполнения</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(IsDBNull(Me.ARow("expertTerm")), NULL_TEXT, String.Format("{0:dd.MM.yyyy HH:mm}", Me.ARow("expertTerm"))))
            Html &= "</tr>"
            Html &= "<tr>"
            Html &= String.Format("<th><a href='CN_{0}_0'>Запрос дополнительной информации</a></th>", elId)
            Html &= String.Format("<td>{0}</td>", If(CBool(Me.ARow("isSendQuery")), "<span class='red'>Да</span>", "Нет"))
            Html &= "</tr>"
        End If
        Html &= "</table>"
        Return Html
    End Function

    ''' <summary>
    ''' Список мероприятий плана работ
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetHtmlWorkPlaneLI() As String
        Dim Html As String = Nothing
        Using V As New DataView(Me.PlaneTable)
            V.RowFilter = "isCheck = True"
            V.Sort = "id"
            If V.Count = 0 Then
                Html &= String.Format("<li>{0}</li>", NULL_TEXT)
            Else
                For i As Integer = 0 To V.Count - 1
                    Html = String.Format("{0}<li>{1}</li>", Html, C2.ToText(V(i)("caption")))
                Next
            End If
        End Using
        Return Html
    End Function

    ''' <summary>
    ''' Возвращает вид работы указанный экспертом
    ''' </summary>
    Private Function GetHtmlWorkTypeExpert() As String
        Dim Html As String = Nothing
        Dim wType As WorkType = CType(C2.ToInt(Me.ARow("typeId")), WorkType)
        If wType = WorkType.IsEmpty Then wType = Me.Type
        Select Case wType
            Case WorkType.IsExCont : Html = "Идентификационная экспертиза по экспортному контролю"
            Case WorkType.IsCustomUnion : Html = "Экспертиза по запретам и ограничениям ЕАЭС"
            Case WorkType.IsLiconfirm : Html = "Подтверждение лицензии"
            Case WorkType.IsTnved : Html = "Определение кода ТН ВЭД"
            Case WorkType.IsMilitary : Html = "Экспертиза по гражданскому назначению"
            Case WorkType.IsConsultation : Html = "Консультация по ВЭД"
        End Select
        If String.IsNullOrWhiteSpace(Html) Then Return NULL_TEXT
        If wType <> Me.Type Then Html = String.Format("<span class='red'>{0}</span>", Html)
        Return Html
    End Function

    ''' <summary>
    ''' Возвращает тип работы
    ''' </summary>
    Private Function GetHtmlWorkSort() As String
        If Me.Type = WorkType.IsAlteration Then Return "Внесение изменений"
        Dim iTmp As String = C2.ToInt(Me.ARow("changeSourceId"))
        Select Case iTmp
            Case 1, 2, 3 : Return "Внесение изменений"
                'Case 3 : Return "Продление срока действия заключения"
            Case Else : Return "Первичная работа"
        End Select
    End Function

#End Region

End Class