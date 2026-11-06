Imports System.Xml
Imports System.Data.SqlClient
Imports Cprp.DxData.Common
Imports Cprp.DxCommon
''' <summary>
''' Поиск сведений о компании по ее ИНН
''' </summary>
Friend Class MainForm0

    ''' <summary>
    ''' Объект Command для выполнения запросов к EXDBA
    ''' </summary>
    Private CmdA As SqlCommand = Nothing

    ''' <summary>
    ''' Объект Command для выполнения запросов к EXDB8
    ''' </summary>
    Private Cmd8 As SqlCommand = Nothing

    ''' <summary>
    ''' Клиент для выполнения http-запросов
    ''' </summary>
    Private WebClient As System.Net.WebClient = Nothing

    ''' <summary>
    ''' Путь к временному файлу для сохранения результатов запросов
    ''' </summary>
    Private tmpFilePath As String = Nothing

    ''' <summary>
    ''' Шаблон запроса поиска данных по ИНН фирмы
    ''' </summary>
    Private Const INN_FIND_TEMPATE As String = "https://zachestnyibiznesapi.ru/paid/data/card?id={0}&api_key=GIP0mH_QzZUa60zCIOO90sX95ggTCHh-&_format=xml"

    ''' <summary>
    ''' Нет данных
    ''' </summary>
    Private Const NULL_TEXT As String = "[нет данных]"

#Region "Таблица учредителей"

    Private Class OwnerDataTable : Inherits DataTable

        ''' <summary>
        ''' Таблица учредителей компании
        ''' </summary>
        Public Sub New()
            MyBase.New("OwnerTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("name", GetType(String))
                .Add("regDate", GetType(String))
                .Add("inn", GetType(String))
                .Add("sum", GetType(String))
                .Add("percent", GetType(String))
            End With
            With Me.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            With Me.Columns("name")
                .AllowDBNull = False
                .DefaultValue = NULL_TEXT
            End With
            With Me.Columns("regDate")
                .AllowDBNull = False
                .DefaultValue = NULL_TEXT
            End With
            With Me.Columns("inn")
                .AllowDBNull = False
                .DefaultValue = NULL_TEXT
            End With
            With Me.Columns("sum")
                .AllowDBNull = False
                .DefaultValue = "0"
            End With
            With Me.Columns("percent")
                .AllowDBNull = False
                .DefaultValue = "0"
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub

    End Class

#End Region
#Region "Таблица заказов"

    Private Class OrderDataTable : Inherits DataTable

        ''' <summary>
        ''' Таблица заказов компании
        ''' </summary>
        Public Sub New()
            MyBase.New("OrderTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("docNum", GetType(String))
                .Add("docDate", GetType(Date))
                .Add("rusInn", GetType(String))
                .Add("summaryId", GetType(Integer))
                .Add("summaryName", GetType(String))
                .Add("expertName", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub

    End Class

#End Region
#Region "Таблица контролируемых заключений"

    Private Class ControlDataTable : Inherits DataTable

        ''' <summary>
        ''' Таблица контролируемых заключений российского участника ВЭД
        ''' </summary>
        Public Sub New()
            MyBase.New("OrderTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("docNum", GetType(String))
                .Add("docDate", GetType(Date))
                .Add("orgName", GetType(String))
                .Add("countryName", GetType(String))
                .Add("goodName", GetType(String))
                .Add("summary", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub

    End Class

#End Region
#Region "Таблица стилей и скрипты документа"

    ''' <summary>
    ''' Таблица стилей и скрипты документа
    ''' </summary>
    Protected Const HTML_CSS_JS As String = _
        "<style media='screen'>" & vbCrLf & _
        "* {font-family: Arial,Calibri; font-size: 13pt; border-color:black; line-height: 1.5em;}" & vbCrLf & _
        "ul, ol {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf & _
        "p {margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf & _
        "table {border-collapse: collapse; margin-top: 3pt;}" & vbCrLf & _
        "td {text-align:center; vertical-align: top; padding:4pt;}" & vbCrLf & _
        "th {font-weight:bold; vertical-align:middle;}" & vbCrLf & _
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
        "</style>" & vbCrLf & _
        "<style media='print'>" & vbCrLf & _
        "* {font-family: Calibri,Arial; font-size: 13pt; border-color:black}" & vbCrLf & _
        "ul {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf & _
        "p {margin: 0pt;}" & vbCrLf & _
        "table {border-collapse: collapse;}" & vbCrLf & _
        "td {vertical-align: top;padding:4pt;}" & vbCrLf & _
        "th {font-weight:normal; font-style:italic; vertical-align:middle; padding:4pt;}" & vbCrLf & _
        "a {color:black; text-decoration:none}" & vbCrLf & _
        "</style>" & vbCrLf & _
        "<script language='JavaScript' type='text/javascript'>" & vbCrLf & _
        "<!-- " & vbCrLf & _
        "function hs(el) {el.className = (el.className == 'hidden') ? '' : 'hidden';}" & vbCrLf & _
        " -->" & vbCrLf & _
        "</script>" & vbCrLf

#End Region


    Friend Sub New()
        InitializeComponent()
        '
        ' CmdA
        '
        Dim CnA As New SqlConnection("Server=192.168.22.80;Database=EXDBA;Trusted_connection=Yes")
        CnA.Open()
        CmdA = CnA.CreateCommand
        '
        ' Cmd8
        '
        Dim Cn8 As New SqlConnection("Server=192.168.22.80;Database=EXDB8;Trusted_connection=Yes")
        Cn8.Open()
        Cmd8 = Cn8.CreateCommand
        '
        ' WebClient
        '
        WebClient = New System.Net.WebClient
        '
        ' tmpFilePath
        '
        tmpFilePath = My.Computer.FileSystem.GetTempFileName
        '
        ' InnButtonEdit 
        '
        InnButtonEdit.EditValue = "7814485692"
        '
        ' Me
        '
        Me.Icon = My.Resources.company
        Me.Text = "Профиль российского лица"
        Me.Width = 0.8 * Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

    End Sub


    Private Sub InnButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles InnButtonEdit.ButtonClick
        Dim htmlDocText As String = Nothing                     ' html-текст профиля компании
        Dim inn As String = Nothing                             ' ИНН фирмы
        Dim orderCount As Integer = 0                           ' количество поданых заказов
        Dim workCount As Integer = 0                            ' количество работ, где выступал в качестве российского участника

        Dim OrderTable As New OrderDataTable                    ' Таблица заказов компании
        Dim ControlTable As New ControlDataTable                ' Таблица контролируемых заключений российского участника ВЭД

        Dim sTmp As String = Nothing

        WaitForm.Show(Me)
        Try
            '
            ' inn
            '
            inn = ToText(InnButtonEdit.EditValue)
            If String.IsNullOrWhiteSpace(inn) Then Throw New Exception("Укажите ИНН!")
            For Each c As Char In inn
                If Not c Like "[0123456789]" Then Throw New Exception("Некорректный ИНН!")
            Next
            If inn.Length <> 10 Then Throw New Exception("Некорректный ИНН организации!")
            '
            ' ЗАГРУЗКА ДАННЫХ ИЗ АРХИВНОЙ БАЗЫ
            ' ================================
            '
            ' orderCount, workCount
            '
            CmdA.CommandText = String.Format("SELECT COUNT(DISTINCT orderNum) FROM tWork WHERE clientInn = '{0}'", inn)
            orderCount = CInt(CmdA.ExecuteScalar)
            CmdA.CommandText = String.Format("SELECT COUNT(DISTINCT workId) FROM tMember WHERE inn = '{0}'", inn)
            workCount = CInt(CmdA.ExecuteScalar)
            '
            ' OrderTable
            '
            CmdA.CommandText = String.Format("SELECT id, docNum, docDate, rusInn, summaryId, summaryName, expertName FROM vOutDocWorkData WHERE clientInn = '{0}'", inn)
            OrderTable.Load(CmdA.ExecuteReader)
            workCount = CInt(CmdA.ExecuteScalar)
            '
            ' ControlTable
            '
            Cmd8.CommandText = String.Format("SELECT id, docNum, docDate, orgNameShort AS orgName, countryName, goodName, summary FROM vFInfo WHERE rusInn = '{0}'", inn)
            ControlTable.Load(Cmd8.ExecuteReader)


            '
            ' HTTP-ЗАПРОС
            '
            Dim X As New XmlDocument
            With My.Computer.FileSystem
                'sTmp = "d:\16.xml"
                .WriteAllBytes(tmpFilePath, WebClient.DownloadData(INN_FIND_TEMPATE.Replace("{0}", inn)), False)
                X.Load(tmpFilePath)
                '.DeleteFile(sTmp)
            End With
            '
            ' СОЗДАНИЕ ДОКУМЕНТА
            ' ==================
            '
            htmlDocText = "<p><b>ПРОФИЛЬ РОССИЙСКОГО ЛИЦА:</b></p><br>"
            If (orderCount + workCount) = 0 Then
                htmlDocText &= "<p><b>Статус:</b> Новый</p><br>"
                htmlDocText &= "<p><b>Категория:</b> -</p><br>"
            Else
                htmlDocText &= "<p><b>Статус:</b> Многократно</p><br>"
                If workCount = 0 Then
                    htmlDocText &= "<p><b>Категория:</b> Заказчик</p><br>"
                ElseIf orderCount = 0 Then
                    htmlDocText &= "<p><b>Категория:</b> Участник ВЭД</p><br>"
                Else
                    htmlDocText &= "<p><b>Категория:</b> Заказчик / Участник ВЭД</p><br>"
                End If
            End If
            htmlDocText &= String.Format("<p><b>Дата регистрации:</b> {0}</p><br>", GetOgrnDate(X))
            htmlDocText &= String.Format("<p><b>{0}</b>, ИНН {1}; Юридический адрес: {2}, получен {3}.</p>", _
                                         GetNameLong(X), inn, GetAddressLegal(X), GetAddressLegalDate(X))
            htmlDocText &= String.Format("<p>Численность работников: {0}</p>", GetNowWorkerCount(X))
            htmlDocText &= String.Format("<p><b>{0}</b> {1} ИНН {2} действует с {3}</p>", _
                                         GetLeaderPost(X), GetLeaderName(X), GetLeaderInn(X), GetLeaderDate(X))
            Using T As OwnerDataTable = GetOwnerTable(X)
                htmlDocText &= String.Format("<p><b>Учредители ({0})</b></p>", T.Rows.Count)
                For Each Row As DataRow In T.Rows
                    htmlDocText &= String.Format("<p>{0}% {1} {2} руб., {3}, ИНН {4}</p>", _
                                                 ToText(Row("percent")), _
                                                 ToText(Row("name")), _
                                                 ToText(Row("sum")), _
                                                 ToText(Row("regDate")), _
                                                 ToText(Row("inn")))
                Next
            End Using
            htmlDocText &= String.Format("<p>Основной вид деятельности: {0} {1}</p>", GetOkvedCode(X), GetOkvedCaption(X))
            htmlDocText &= String.Format("<p>Дополнительные виды деятельности: {0}</p>", GetOkvedCount(X))
            htmlDocText &= String.Format("<br><p><b>ИСТОРИЯ ЗАКАЗОВ [{0}]:</b></p>", OrderTable.Rows.Count)
            If OrderTable.Rows.Count = 0 Then
                htmlDocText &= "<p>Заказы отсутствуют</p>"
            Else
                htmlDocText &= "<table width='100%' border='1'>"
                htmlDocText &= "<tr><th>Дата</th><th>Номер заключения</th><th>ИНН рос.уч.ВЭД</th><th>Вывод</th><th>ФИО эксперта</th></tr>"
                Using V As New DataView(OrderTable) With {.Sort = "docDate DESC"}
                    For i As Integer = 0 To V.Count - 1
                        sTmp = ToText(V(i)("summaryName"))
                        If Not ToText(V(i)("docNum")) Like "*7825056737*" Then sTmp = "(консультация)"
                        htmlDocText &= If(CInt(V(i)("summaryId")) > 1, "<tr class='red'>", "<tr>")
                        htmlDocText &= String.Format("<td>{0:dd.MM.yyyy}</td>", CDate(V(i)("docDate")))
                        htmlDocText &= String.Format("<td>{0}</td>", ToText(V(i)("docNum")))
                        htmlDocText &= String.Format("<td>{0}</td>", ToText(V(i)("rusInn")))
                        htmlDocText &= String.Format("<td>{0}</td>", sTmp)
                        htmlDocText &= String.Format("<td>{0}</td>", ToText(V(i)("expertName")))
                        htmlDocText &= "</tr>"
                    Next
                End Using
                htmlDocText &= "</table>"
            End If
            htmlDocText &= String.Format("<br><p><b>СВЕДЕНИЯ ИЗ БАЗЫ ДАННЫХ ЗАКЛЮЧЕНИЙ (лицензии и разрешения) [{0}]:</b></p>", ControlTable.Rows.Count)
            If ControlTable.Rows.Count = 0 Then
                htmlDocText &= "<p>Сведения отсутствуют</p>"
            Else
                htmlDocText &= "<table width='100%' border='1'>"
                htmlDocText &= "<tr><th>Дата</th><th>Номер заключения</th><th>Экспертная организация</th><th>Страна назначения</th><th>Продукция</th><th>Вывод</th></tr>"
                Using V As New DataView(ControlTable) With {.Sort = "docDate DESC"}
                    For i As Integer = 0 To V.Count - 1
                        htmlDocText &= String.Format("<td>{0:dd.MM.yyyy}</td>", CDate(V(i)("docDate")))
                        htmlDocText &= String.Format("<td>{0}</td>", ToText(V(i)("docNum")))
                        htmlDocText &= String.Format("<td>{0}</td>", ToText(V(i)("orgName")))
                        htmlDocText &= String.Format("<td>{0}</td>", ToText(V(i)("countryName")))
                        htmlDocText &= String.Format("<td>{0}</td>", ToText(V(i)("goodName")))
                        htmlDocText &= String.Format("<td>{0}</td>", ToText(V(i)("summary")))
                        htmlDocText &= "</tr>"
                    Next
                End Using
                htmlDocText &= "</table>"
            End If

            WaitForm.Close()
        Catch ex As Exception
            WaitForm.Close()
            htmlDocText = String.Format("<p class='red'>{0}</p>", ex.Message)
        Finally
            If Not OrderTable Is Nothing Then OrderTable.Dispose()
            If Not ControlTable Is Nothing Then ControlTable.Dispose()
        End Try

        W.DocumentText = String.Format("<HTML><TITLE>Профиль российского лица</TITLE>{0}<BODY>{1}</BODY></HTML>", _
                                       HTML_CSS_JS, htmlDocText)


    End Sub


    ''' <summary>
    ''' Возвращает дочерний узел родительского узла
    ''' </summary>
    ''' <param name="ParentNode">Родительский узел</param>
    ''' <param name="childName">Наименование дочернего узла</param>
    ''' <remarks>Если узел не найден, возвращает Nothing</remarks>
    Private Function GetChildNode(ParentNode As XmlNode, childName As String) As XmlNode
        If ParentNode Is Nothing Then Return Nothing
        If Not IsText(childName) Then Return Nothing
        childName = childName.ToUpper
        For Each ChildNode As XmlNode In ParentNode.ChildNodes
            If ChildNode.Name.ToUpper = childName Then Return ChildNode
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Возвращает узел документа
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <param name="nodeNameString">Цепочка наименований узлов документа</param>
    ''' <remarks>Если узел не найден, возвращает Nothing</remarks>
    Private Function GetDocumentNode(Doc As XmlDocument, nodeNameString As String) As XmlNode
        If Doc Is Nothing Then Return Nothing
        If Not IsText(nodeNameString) Then Return Nothing
        Dim arr() As String = nodeNameString.ToUpper.Split(New Char() {"/"}, StringSplitOptions.RemoveEmptyEntries)
        For Each N As XmlNode In Doc.ChildNodes
            If N.Name.ToUpper <> arr(0) Then Continue For
            For i As Integer = 1 To arr.GetUpperBound(0)
                N = GetChildNode(N, arr(i))
            Next
            Return N
        Next
        Return Nothing
    End Function


    ''' <summary>
    ''' Возвращает полное наименование компании
    ''' </summary>
    ''' <param name="Doc">Xml-документ с данными компании</param>
    ''' <remarks>Если ничего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetNameLong(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/НаимЮЛПолн")
        If N Is Nothing OrElse Not IsText(N.InnerText) Then Return NULL_TEXT
        Return ToText(N.InnerText)
    End Function

    ''' <summary>
    ''' Возвращает юридический адрес компании
    ''' </summary>
    ''' <param name="Doc">Xml-документ с данными компании</param>
    ''' <remarks>Если ничего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetAddressLegal(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/Адрес")
        If N Is Nothing OrElse Not IsText(N.InnerText) Then Return NULL_TEXT
        Return ToText(N.InnerText)
    End Function

    ''' <summary>
    ''' Возвращает строковое представление даты получения ОГРН компании
    ''' </summary>
    ''' <param name="Doc">Xml-документ с данными компании</param>
    ''' <remarks>Если ничего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetOgrnDate(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/ДатаОГРН")
        If N Is Nothing OrElse Not (IsText(N.InnerText) AndAlso IsDate(N.InnerText)) Then Return NULL_TEXT
        Return Format(CDate(N.InnerText), "dd.MM.yyyy")
    End Function

    ''' <summary>
    ''' Возвращает строковое представление даты получения юридического адреса компании
    ''' </summary>
    ''' <param name="Doc">Xml-документ с данными компании</param>
    ''' <remarks>Если ничего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetAddressLegalDate(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/ДатаАдресРФ")
        If N Is Nothing OrElse Not (IsText(N.InnerText) AndAlso IsDate(N.InnerText)) Then Return NULL_TEXT
        Return Format(CDate(N.InnerText), "dd.MM.yyyy")
    End Function

    ''' <summary>
    ''' Возвращает текущую численность сотрудников компании
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <remarks>Если ничего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetNowWorkerCount(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/ЧислСотруд")
        If N Is Nothing OrElse Not IsText(N.InnerText) Then Return NULL_TEXT
        Return ToText(N.InnerText)
    End Function

    ''' <summary>
    ''' Возвращает ФИО руководителя компании
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <remarks>Если нечего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetLeaderName(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/Руководители/item/fl")
        If N Is Nothing OrElse Not IsText(N.InnerText) Then Return NULL_TEXT
        Return ToText(N.InnerText)
    End Function

    ''' <summary>
    ''' Возвращает должность руководителя компании
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <remarks>Если нечего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetLeaderPost(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/Руководители/item/post")
        If N Is Nothing OrElse Not IsText(N.InnerText) Then Return NULL_TEXT
        Return ToText(N.InnerText)
    End Function

    ''' <summary>
    ''' Возвращает ИНН руководителя компании
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <remarks>Если нечего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetLeaderInn(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/Руководители/item/inn")
        If N Is Nothing OrElse Not IsText(N.InnerText) Then Return NULL_TEXT
        Return ToText(N.InnerText)
    End Function

    ''' <summary>
    ''' Возвращает дату начала действия руководителя компании
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <remarks>Если нечего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetLeaderDate(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/Руководители/item/date")
        If N Is Nothing OrElse Not (IsText(N.InnerText) AndAlso IsDate(N.InnerText)) Then Return NULL_TEXT
        Return Format(CDate(N.InnerText), "dd.MM.yyyy")
    End Function

    ''' <summary>
    ''' Возвращает заполненную таблицу учредителей компании
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <remarks>Если ничего не найдено возвращет пустую таблицу</remarks>
    Private Function GetOwnerTable(Doc As XmlDocument) As DataTable
        Dim T As New OwnerDataTable
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/СвУчредит/all")
        If N Is Nothing Then Return T
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Dim sum As Single = 0
        Dim sum1 As Single = 0
        For Each N1 As XmlNode In N.ChildNodes
            If N1.Name.ToUpper <> "ITEM" Then Continue For
            Row = T.NewRow
            For Each N2 As XmlNode In N1.ChildNodes
                sTmp = ToText(N2.InnerText)
                If Not IsText(sTmp) Then sTmp = NULL_TEXT
                Select Case N2.Name.ToUpper
                    Case "NAME"
                        Row("name") = sTmp
                    Case "DATE"
                        If IsDate(sTmp) Then
                            Row("regDate") = Format(CDate(sTmp), "dd.MM.yyyy")
                        End If
                    Case "INN"
                        Row("inn") = sTmp
                    Case "DOL_ABS"
                        If IsNumeric(sTmp) Then
                            sum1 = CSng(sTmp)
                            Row("sum") = Format(sum1, "#.00")
                            sum += sum1
                        End If
                End Select
            Next
            T.Rows.Add(Row)
        Next
        If sum > 0 Then
            For Each Row In T.Rows
                Row("percent") = Format(100 * Val(Row("sum")) / sum, "#.00")
            Next
        End If
        Return T
    End Function

    ''' <summary>
    ''' Возвращает код ОКВЭД основного вида деятельности компании
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <remarks>Если нечего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetOkvedCode(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/КодОКВЭД")
        If N Is Nothing OrElse Not IsText(N.InnerText) Then Return NULL_TEXT
        Return ToText(N.InnerText)
    End Function

    ''' <summary>
    ''' Возвращает описание кода ОКВЭД основного вида деятельности компании
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <remarks>Если нечего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetOkvedCaption(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/НаимОКВЭД")
        If N Is Nothing OrElse Not IsText(N.InnerText) Then Return NULL_TEXT
        Return ToText(N.InnerText)
    End Function

    ''' <summary>
    ''' Возвращает количество дополнительных видов деятельности компании
    ''' </summary>
    ''' <param name="Doc">Документ</param>
    ''' <remarks>Если нечего не найдено возвращает NULL_TEXT</remarks>
    Private Function GetOkvedCount(Doc As XmlDocument) As String
        Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/СвОКВЭДДоп")
        If N Is Nothing OrElse Not IsText(N.InnerText) Then Return NULL_TEXT
        Dim iTmp As Integer = 0
        For Each N1 As XmlNode In N.ChildNodes
            If N1.Name.ToUpper = "ITEM" Then iTmp += 1
        Next
        Return iTmp.ToString
    End Function

End Class