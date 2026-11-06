Imports Cprp.DxData.Common
' ========================
' ПРОФИЛЬ РОССИЙСКОГО ЛИЦА
' ========================
Partial Public Class MemberDataTable

#Region "Таблица работ российского лица"

    ''' <summary>
    ''' Таблица работ российского лица
    ''' </summary>
    Public Class RusWorkDataTable : Inherits DataTable

        ''' <summary>
        ''' Представление для сортировки и фильтрации данных
        ''' </summary>
        Private V As DataView = Nothing

        ''' <summary>
        ''' Количество запросов в работах
        ''' </summary>
        Private _askCount As Integer = 0

        ''' <summary>
        ''' Процент работ без запросов
        ''' </summary>
        Private _askPercent As Single = 0


        ''' <summary>
        ''' New
        ''' </summary>
        Public Sub New()
            MyBase.New("RusWorkTable")
            With Me.Columns
                .Add("workId", GetType(Integer))
                .Add("orderId", GetType(Integer))
                .Add("orderNum", GetType(String))
                .Add("orderDate", GetType(Date))
                .Add("orderUrl", GetType(String))
                .Add("workDescription", GetType(String))
                .Add("workCountry", GetType(String))
                .Add("workSummaryId", GetType(Integer))
                .Add("workTypeLetter", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("workId")}
            Me.DefaultView.Sort = "workSummaryId, workId DESC"
            V = New DataView(Me)
        End Sub


        ''' <summary>
        ''' Перечитать количество и процент запросов
        ''' </summary>
        ''' <param name="Connection">Открытое соединение с базой данных</param>
        Private Sub SetAskCountPercent(Connection As SqlConnection)
            _askCount = 0
            _askPercent = 0
            Dim sTmp As String = "0"
            For Each Row As DataRow In Me.Rows
                sTmp = String.Format("{0}, {1}", sTmp, ToInt(Row("workId")))
            Next
            Using Cmd As SqlCommand = Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT COUNT(DISTINCT workID) FROM tWorkHistory WHERE eventId = 10 AND workId IN({0})", sTmp)
                _askCount = CInt(Cmd.ExecuteScalar)
            End Using
            If _askCount < Me.Rows.Count Then
                _askPercent = (Me.Rows.Count - _askCount) / Me.Rows.Count
            End If
        End Sub

        ''' <summary>
        ''' Загрузить данные из базы по ID записи в таблице базы данных
        ''' </summary>
        ''' <param name="id">ID записи в таблице лиц</param>
        ''' <param name="Connection">Открытое соединение с базой данных</param>
        Public Sub LoadById(id As Integer, Connection As SqlConnection)
            Me.Rows.Clear()
            Using Cmd As SqlCommand = Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT * FROM vWorkMember WHERE memberId = {0}", id)
                Me.Load(Cmd.ExecuteReader)
            End Using
            SetAskCountPercent(Connection)
        End Sub

        ''' <summary>
        ''' Загрузить данные из базы по ИНН российского лица
        ''' </summary>
        ''' <param name="inn">ИНН российского лица</param>
        ''' <param name="Connection">Открытое соединение с базой данных</param>
        Public Sub LoadByInn(inn As String, Connection As SqlConnection)
            Me.Rows.Clear()
            inn = ToText(inn)
            If String.IsNullOrWhiteSpace(inn) Then Exit Sub
            Using Cmd As SqlCommand = Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT * FROM vWorkMember WHERE memberInn = '{0}' OR workClientInn = '{0}'", inn)
                Me.Load(Cmd.ExecuteReader)
            End Using
            SetAskCountPercent(Connection)
        End Sub

        ''' <summary>
        ''' Количество заказов
        ''' </summary>
        Public ReadOnly Property OrderCount As Integer
            Get
                If Me.Rows.Count = 0 Then Return 0
                Dim iCount As Integer = 1
                V.Sort = "orderNum"
                For i As Integer = 1 To V.Count - 1
                    If ToText(V(i)("orderNum")) <> ToText(V(i - 1)("orderNum")) Then iCount += 1
                Next
                Return iCount
            End Get
        End Property

        ''' <summary>
        ''' Дата последнего заказа
        ''' </summary>
        Public ReadOnly Property LastOrderDate As Date
            Get
                If Me.Rows.Count = 0 Then Return Nothing
                V.Sort = "orderDate DESC"
                Return CDate(V(0)("orderDate"))
            End Get
        End Property

        ''' <summary>
        ''' Количество запросов
        ''' </summary>
        Public ReadOnly Property AskCount As Integer
            Get
                Return _askCount
            End Get
        End Property

        ''' <summary>
        ''' Процент работ без запросов
        ''' </summary>
        Public ReadOnly Property AskPercent As Single
            Get
                Return _askPercent
            End Get
        End Property

        ''' <summary>
        ''' Количество работ с выводами 'Требуется лицензия'
        ''' </summary>
        Public ReadOnly Property WorkLicenseCount As Integer
            Get
                If Me.Rows.Count = 0 Then Return 0
                V.RowFilter = "workSummaryId = 2"
                Return V.Count
            End Get
        End Property

        ''' <summary>
        ''' Количество работ с выводами 'Требуется разрешение'
        ''' </summary>
        Public ReadOnly Property WorkPermitCount As Integer
            Get
                If Me.Rows.Count = 0 Then Return 0
                V.RowFilter = "workSummaryId = 3"
                Return V.Count
            End Get
        End Property


    End Class

#End Region
#Region "Таблица контролируемых заключений российского лица"

    ''' <summary>
    ''' Таблица контролируемых заключений российского лица
    ''' </summary>
    Public Class RusDocDataTable : Inherits DataTable

        ''' <summary>
        ''' Представление для сортировки и фильтрации данных
        ''' </summary>
        Private V As DataView = Nothing


        ''' <summary>
        ''' New
        ''' </summary>
        Public Sub New()
            MyBase.New("RusDocTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("docNum", GetType(String))
                .Add("docDate", GetType(Date))
                .Add("goodName", GetType(String))
                .Add("countryName", GetType(String))
                .Add("summaryId", GetType(Integer))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
            V = New DataView(Me)
        End Sub

        ''' <summary>
        ''' Загрузить данные из базы по ИНН российского лица
        ''' </summary>
        ''' <param name="inn">ИНН российского лица</param>
        ''' <param name="Connection">Открытое соединение с базой данных</param>
        Public Sub LoadByInn(inn As String, Connection As SqlConnection)
            Me.Rows.Clear()
            inn = ToText(inn)
            If String.IsNullOrWhiteSpace(inn) Then Exit Sub
            Using Cmd As SqlCommand = Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT id, docNum, docDate, goodName, countryName, summaryId FROM vFInfo WHERE rusInn = '{0}'", inn)
                Me.Load(Cmd.ExecuteReader)
            End Using
        End Sub

        ''' <summary>
        ''' Количество заключений
        ''' </summary>
        Public ReadOnly Property DocCount As Integer
            Get
                If Me.Rows.Count = 0 Then Return 0
                Dim iCount As Integer = 1
                V.Sort = "docNum"
                For i As Integer = 1 To V.Count - 1
                    If ToText(V(i)("docNum")) <> ToText(V(i - 1)("docNum")) Then iCount += 1
                Next
                Return iCount
            End Get
        End Property

    End Class

#End Region
#Region "Таблица стилей и скрипты документа"

    ''' <summary>
    ''' Таблица стилей и скрипты документа
    ''' </summary>
    Public Const HTML_CSS_JS As String = _
        "<style media='screen'>" & vbCrLf & _
        "* {font-family: Arial,Calibri; font-size: 12pt; border-color:black; line-height: 1.5em;}" & vbCrLf & _
        "ul, ol {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf & _
        "p {margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf & _
        "table {border-collapse: collapse; margin-top: 3pt;}" & vbCrLf & _
        "td {vertical-align: top; padding:2pt;}" & vbCrLf & _
        "th {text-align:center; font-weight:normal; font-style:italic; vertical-align:middle; padding:4pt;}" & vbCrLf & _
        "a {color:#000080; text-decoration:none}" & vbCrLf & _
        "a:hover {font-weight:bold;}" & vbCrLf & _
        ".tree span:hover {font-weight: bold;}" & vbCrLf & _
        ".tree span {cursor: pointer;}" & vbCrLf & _
        ".tree p {margin-top: 3pt;}" & vbCrLf & _
        "li {margin-top: 0pt;}" & vbCrLf & _
        "td li {margin-top: 0pt;}" & vbCrLf & _
        ".notree span:hover {font-weight: normal;}" & vbCrLf & _
        ".notree span {font-size:13pt; cursor: auto;}" & vbCrLf & _
        ".red {color: red;}" & vbCrLf & _
        ".byellow {background-color: lightyellow;}" & vbCrLf & _
        ".bazure {background-color: azure;}" & vbCrLf & _
        ".hidden {display: none;}" & vbCrLf & _
        "</style>" & vbCrLf & _
        "<style media='print'>" & vbCrLf & _
        "* {font-family: Calibri,Arial; font-size: 12pt; border-color:black}" & vbCrLf & _
        "ul {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf & _
        "p {margin: 0pt;}" & vbCrLf & _
        "table {border-collapse: collapse;}" & vbCrLf & _
        "td {vertical-align: top;padding:4pt;}" & vbCrLf & _
        "th {text-align:center; font-weight:normal; font-style:italic; vertical-align:middle; padding:4pt;}" & vbCrLf & _
        "a {color:black; text-decoration:none}" & vbCrLf & _
        ".hidden {display: none;}" & vbCrLf & _
        "</style>" & vbCrLf & _
        "<script language='JavaScript' type='text/javascript'>" & vbCrLf & _
        "<!-- " & vbCrLf & _
        "function hs(el) {el.className = (el.className == 'hidden') ? '' : 'hidden';}" & vbCrLf & _
        " -->" & vbCrLf & _
        "</script>" & vbCrLf

#End Region

    ''' <summary>
    ''' Таблица работ российского лица
    ''' </summary>
    Private RusWorkTable As RusWorkDataTable = Nothing

    ''' <summary>
    ''' Таблица контролируемых заключений российского лица
    ''' </summary>
    Private RusDocTable As RusDocDataTable = Nothing

    ''' <summary>
    ''' Клиент для выполнения http-запросов
    ''' </summary>
    Private WebClient As System.Net.WebClient = Nothing

    ''' <summary>
    ''' Карточка российского лица
    ''' </summary>
    Private XmlCard As XmlDocumentCard = Nothing

    ''' <summary>
    ''' Судебные дела росийского лица
    ''' </summary>
    Private XmlCourt As XmlDocumentCourt = Nothing


    ''' <summary>
    ''' Возвращает профиль российского лица в виде html-документа
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="isDataUpdate">Обновить регистрационные данные лица данными профиля</param> 
    Public Function GetRusProfileHtml(Row As DataRow, Connection As SqlConnection, Optional isDataUpdate As Boolean = False) As String
        If Row Is Nothing OrElse Not TypeOf Row.Table Is MemberDataTable Then Return Nothing

        Dim inn As String = ToText(Row("inn"))
        If String.IsNullOrWhiteSpace(inn) Then Return Nothing

        Dim Body As String = Nothing
        Dim iTmp As Integer = 0

        If RusWorkTable Is Nothing Then RusWorkTable = New RusWorkDataTable
        If RusDocTable Is Nothing Then RusDocTable = New RusDocDataTable
        If WebClient Is Nothing Then WebClient = New Net.WebClient
        If XmlCard Is Nothing Then XmlCard = New XmlDocumentCard(WebClient)
        If XmlCourt Is Nothing Then XmlCourt = New XmlDocumentCourt(WebClient)
        RusWorkTable.LoadByInn(inn, Connection)
        RusDocTable.LoadByInn(inn, Connection)
        Using Cmd As SqlCommand = Connection.CreateCommand
            ' xmlCard
            Cmd.CommandText = String.Format("SELECT ISNULL(MAX(id), -1) FROM tMember WHERE inn = '{0}' AND NOT xmlCard IS NULL AND NOT xmlActDate IS NULL AND NOT leaderName IS NULL", inn)
            iTmp = CInt(Cmd.ExecuteScalar)
            If iTmp > 0 Then
                Cmd.CommandText = String.Format("SELECT xmlCard FROM tMember WHERE id = {0}", iTmp)
                Row("xmlCard") = Cmd.ExecuteScalar.ToString
                XmlCard.LoadXml(ToText(Row("xmlCard")))
                Cmd.CommandText = String.Format("SELECT xmlActDate FROM tMember WHERE id = {0}", iTmp)
                Row("xmlActDate") = CDate(Cmd.ExecuteScalar)
            Else
                XmlCard.LoadByInn(inn)
                Row("xmlCard") = XmlCard.InnerXml
                Row("xmlActDate") = Date.Now
            End If
            ' xmlCourt
            Cmd.CommandText = String.Format("SELECT ISNULL(MAX(id), -1) FROM tMember WHERE inn = '{0}' AND NOT xmlCourt IS NULL AND NOT xmlActDate IS NULL", inn)
            iTmp = CInt(Cmd.ExecuteScalar)
            If iTmp > 0 Then
                Cmd.CommandText = String.Format("SELECT xmlCourt FROM tMember WHERE id = {0}", iTmp)
                Row("xmlCourt") = Cmd.ExecuteScalar.ToString
                XmlCourt.LoadXml(ToText(Row("xmlCourt")), inn)
                Cmd.CommandText = String.Format("SELECT xmlActDate FROM tMember WHERE id = {0}", iTmp)
                Row("xmlActDate") = CDate(Cmd.ExecuteScalar)
            Else
                XmlCourt.LoadByInn(inn)
                Row("xmlCourt") = XmlCourt.InnerXml
                Row("xmlActDate") = Date.Now
            End If
        End Using
        '
        ' Сведения из базы "ЭксКонт"
        '
        Body &= "<p><b>Сведения из базы ""ЭксКонт"":</b></p>"
        iTmp = RusWorkTable.OrderCount
        If iTmp = 0 Then
            Body &= "<p>Заказы отсутствуют.</p>"
        Else
            Body &= String.Format("<p>Количество заказов: {0}, дата последнего заказа: {1}.</p>", _
                                  iTmp, TDate(RusWorkTable.LastOrderDate))
        End If
        If RusWorkTable.Rows.Count = 0 Then
            Body &= "<p>Количество работ: 0.</p>"
        Else
            Body &= String.Format("<p>Количество работ (заказчик или российский участник): {0}, запросов: {1}).</p>", _
                                  RusWorkTable.Rows.Count, RusWorkTable.AskCount)
            Body &= "<p class='tree'><span onclick='javascript: hs(el1);'>Перечень работ:</span></p>"
            Body &= "<ul id='el1'>"
            With RusWorkTable.DefaultView
                .Sort = "workSummaryId DESC, workId DESC"
                For i As Integer = 0 To .Count - 1
                    Body &= String.Format( _
                        "<li><a class='{7}' href='OPEN_WORK_{0}'>{0} ({1})</a>, <a href='{2}' target=_blank>{3} от {4}</a>, {5}, {6}{8}</li>", _
                        TInt(.Item(i)("workId"), Nothing, 5), TStr(.Item(i)("workTypeLetter")), _
                        TStr(.Item(i)("orderUrl")), TStr(.Item(i)("orderNum")), TDate(.Item(i)("orderDate")), _
                        TStr(.Item(i)("workdescription")), TStr(.Item(i)("workCountry"), "[нет страны]"), _
                        If(CInt(.Item(i)("workSummaryId")) > 1, "red", "none"), _
                        If(i = .Count - 1, ".", ";"))
                Next
            End With
            Body &= "</ul>"
        End If
        '
        ' Сведения из базы заключений
        '
        Body &= "<br>"
        Body &= "<p><b>Сведения из базы заключений (лицензии и разрешения):</b></p>"
        If RusDocTable.Rows.Count = 0 Then
            Body &= "<p>Заключения отсутствуют.</p>"
        Else
            Body &= String.Format( _
                "<p class='tree'><span onclick='javascript: hs(el2);'>Перечень товаров из заключений (российский участник, заключений: {0}, товаров: {1}):</span></p>", _
                RusDocTable.DocCount, RusDocTable.Rows.Count)
            Body &= "<ul id='el2'>"
            With RusDocTable.DefaultView
                .Sort = "docDate DESC"
                For i As Integer = 0 To .Count - 1
                    Body &= String.Format("<li>{0} от {1} ({2}), {3}, {4}{5}</li>", _
                        TStr(.Item(i)("docNum")), TDate(.Item(i)("docDate")), _
                        If(ToInt(.Item(i)("summaryId")) = 3, "Разрешение", "Лицензия"), _
                        TStr(.Item(i)("goodName")), TStr(.Item(i)("countryName"), "[нет страны]"), _
                        If(i = .Count - 1, ".", ";"))
                Next
            End With
            Body &= "</ul>"
        End If
        '
        ' Дополнительные сведения о компании
        '
        Body &= "<br>"
        Body &= "<p><b>Дополнительные сведения о компании:</b></p>"
        Body &= String.Format("<p>Численность работников: {0}.</p>", TInt(XmlCard.WorkerCount))
        Body &= String.Format("<p>Основной вид деятельности: {0} - {1}.</p>", TStr(XmlCard.OkvedCode), TStr(XmlCard.OkvedName))
        Body &= String.Format("<p class='tree'><span onclick='javascript: hs(el3);'>Дополнительные виды деятельности ({0}):</span></p>", XmlCard.OkvedTable.Rows.Count)
        If XmlCard.OkvedTable.Rows.Count = 0 Then
            Body &= "<p>Нет данных.</p>"
        Else
            Body &= "<ul id='el3'>"
            Using V As New DataView(XmlCard.OkvedTable) With {.Sort = "code"}
                For i As Integer = 0 To V.Count - 1
                    Body &= String.Format("<li>{0} - {1}{2}</li>", _
                                          TStr(V(i)("code")), TStr(V(i)("name")), If(i = V.Count - 1, ".", ";"))
                Next
            End Using
            Body &= "</ul>"
        End If
        Body &= String.Format("<p class='tree'><span onclick='javascript: hs(el4);'>Руководители ({0}):</span></p>", XmlCard.LeaderTable.Rows.Count)
        If XmlCard.LeaderTable.Rows.Count = 0 Then
            Body &= "<p>Нет данных.</p>"
        Else
            Body &= "<ul id='el4'>"
            Using V As New DataView(XmlCard.LeaderTable) With {.Sort = "nameLong"}
                For i As Integer = 0 To V.Count - 1
                    Body &= String.Format("<li>{0}, должность: {1}, действует с {2}{3}</li>", _
                                          TStr(V(i)("nameLong")), TStr(V(i)("post")), TDate(V(i)("regDate")), _
                                          If(i = V.Count - 1, ".", ";"))
                Next
            End Using
            Body &= "</ul>"
        End If
        Body &= String.Format("<p class='tree'><span onclick='javascript: hs(el5);'>Учредители ({0}):</span></p>", XmlCard.FounderTable.Rows.Count)
        If XmlCard.FounderTable.Rows.Count = 0 Then
            Body &= "<p>Нет данных.</p>"
        Else
            Body &= "<ul id='el5'>"
            Using V As New DataView(XmlCard.FounderTable) With {.Sort = "percent DESC, name ASC"}
                For i As Integer = 0 To V.Count - 1
                    Body &= String.Format("<li>{0}% {1} {2} руб., {3}, ИНН: {4}{5}</li>", _
                                          TSng(V(i)("percent")), TStr(V(i)("name")), _
                                          TSng(V(i)("sum")), TDate(V(i)("regDate")), TStr(V(i)("inn")), _
                                          If(i = V.Count - 1, ".", ";"))
                Next
            End Using
            Body &= "</ul>"
        End If
        Body &= String.Format("<p class='tree'><span onclick='javascript: hs(el6);'>Судебные дела ({0}):</span></p>", XmlCourt.CourtTable.Rows.Count)
        If XmlCourt.CourtTable.Rows.Count = 0 Then
            Body &= "<p>Нет данных.</p>"
        Else
            Body &= "<ul id='el6'>"
            Using V As New DataView(XmlCourt.CourtTable) With {.Sort = "regDate DESC"}
                For i As Integer = 0 To V.Count - 1
                    Body &= String.Format("<li>№ {0} от {1}, {2} руб., {3}: {4}, ИНН {5}, ОГРН {6}{7}</li>", _
                                          TStr(V(i)("regNum")), TDate(V(i)("regDate")), TSng(V(i)("sum")), _
                                          If(CBool(V(i)("isPlf")), "истец", "ответчик"), _
                                          TStr(V(i)("name")), TStr(V(i)("inn")), TStr(V(i)("ogrn")), _
                                          If(i = V.Count - 1, ".", ";"))
                Next
            End Using
            Body &= "</ul>"
        End If
        '
        ' Профиль
        '
        Body = String.Format("<html>{0}<body>{1}</body></html>", HTML_CSS_JS, Body)
        '
        ' Обновление регистрационных данных лица
        '
        If isDataUpdate Then
            Row("proDescription") = Body
            With XmlCard
                Row("nameLong") = DbText(.NameLong)
                Row("nameShort") = DbText(.NameShort)
                Row("inn") = DbText(.INN)
                Row("kpp") = DbText(.Kpp)
                Row("ogrn") = DbText(.Ogrn)
                Row("ogrnDate") = DbDate(.OgrnDate)
                Row("addressLegalFull") = DbText(.AddressLegal)
                Row("addressLegalTown") = DbText(.AddressLegalTown)
                Row("addressLegalDate") = DbText(.AddressLegalDate)
            End With
        End If

        Return Body
    End Function


End Class
