Imports System.Data.SqlClient
Imports Cprp.DxData.Common
Imports Cprp.DxCommon
''' <summary>
''' Форма создания профиля российского лица по ИНН
''' </summary>
Friend Class MainForm

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
    ''' Карточка российского лица
    ''' </summary>
    Private XmlCard As XmlDocumentCard = Nothing

    ''' <summary>
    ''' Судебные дела росийского лица
    ''' </summary>
    Private XmlCourt As XmlDocumentCourt = Nothing

    ''' <summary>
    ''' Нет данных
    ''' </summary>
    Private Const NULL_TEXT As String = "[нет данных]"

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

    Private ReportTable As DataTable = Nothing


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
        WebClient = New Net.WebClient
        '
        ' XmlCard
        '
        XmlCard = New XmlDocumentCard(WebClient)
        '
        ' XmlCourt
        '
        XmlCourt = New XmlDocumentCourt(WebClient)
        '
        'InnBarEditItem.EditValue = "7825056737"
        'InnBarEditItem.EditValue = "7802327420"
        '
        ' ReportTable
        '
        ReportTable = New DataTable("ReportTable")
        With ReportTable.Columns
            .Add("id", GetType(Integer))
            .Add("nameLong", GetType(String))
            .Add("inn", GetType(String))
            .Add("address", GetType(String))
            .Add("okved", GetType(String))
        End With
        With ReportTable.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id")}
        '
        ' Me
        '
        Me.Icon = My.Resources.company
        Me.Text = "Профиль российского лица"
        Me.Width = Screen.GetWorkingArea(Me).Height
        Me.Height = Screen.GetWorkingArea(Me).Height - 5
        Me.CenterToScreen()

    End Sub

    ' Создать профиль
    Private Sub MakeBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles MakeBarButtonItem.ItemClick
        Dim arr() As String = _
            {"0269001177", "0277140784", "1001304282", "1645019164", "1657007195", "2304070606", "2308272804", "2312065504", _
             "2312279753", "2634806500", "3652000930", "3811445849", "3812526681", "3906362439", "4011003730", "4714000363", _
             "4716046451", "5003071129", "5010002623", "5017000216", "5024139272", "5029150262", "5032030550", "5032998454", _
             "5038154545", "5044052189", "5045002261", "5047218957", "5262084303", "5401362952", "5402035130", "5403022870", _
             "5403102702", "5404034004", "5404040512", "5404082738", "5405046394", "5405470388", "5406808327", "5407471637", _
             "5407958244", "5408022627", "6102069806", "6114011663", "6145002901", "6150100809", "6154073761", "6154141549", _
             "6164109625", "6168073560", "6168079210", "6325000660", "6612005052", "6612027306", "6623059765", "6652028306", _
             "6658467910", "6659099112", "6660007557", "6660086904", "6666003414", "6670065565", "6670215323", "6671049830", _
             "6673100680", "6673178528", "6679051905", "6686084203", "7415055384", "7447288688", "7448105810", "7450069414", _
             "7451252028", "7456038691", "7701100091", "7701350084", "7701894662", "7703204071", "7703461618", "7704252960", _
             "7704445168", "7704707582", "7705653562", "7705879048", "7706123550", "7706230432", "7706446985", "7706763085", _
             "7707762020", "7707769361", "7708016385", "7708329821", "7709222373", "7709413265", "7709476071", "7710665605", _
             "7712032661", "7713226814", "7714892408", "7715090284", "7715265054", "7716539131", "7717630746", "7717773575", _
             "7718297706", "7718852163", "7718936720", "7719188717", "7719416530", "7720081285", "7720365216", "7721761220", _
             "7721809915", "7722233409", "7723763825", "7723820978", "7724152603", "7726052058", "7726697899", "7726722288", _
             "7726724172", "7726747941", "7727180430", "7727381880", "7727427430", "7727635782", "7728631614", "7729556695", _
             "7729698410", "7730682743", "7731412203", "7731414560", "7731559044", "7733638460", "7735040690", "7735080647", _
             "7735092057", "7735144315", "7735506935", "7736630460", "7743282750", "7743683871", "7743899944", "7801271848", _
             "7801273370", "7802658911", "7802830256", "7802839530", "7804323773", "7804490654", "7805725281", "7805754451", _
             "7809008119", "7809022120", "7811220994", "7814645346", "7816401296", "7817005898", "9909012867"}
        ReportTable.Rows.Clear()
        For Each inn As String In arr
            MakeProfile(inn)
            'If Cprp.DxCommon.Messages.ShowQuestion(inn) <> Windows.Forms.DialogResult.Yes Then Exit Sub
        Next
        ReportTable.AcceptChanges()
        ReportTable.WriteXml("d:\_report.xml")
        Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.LoadDocument("d:\report.docx")
            R.Document.BeginUpdate()
            With R.Document.Tables(0)
                Using V As New DataView(ReportTable)
                    V.Sort = "nameLong"
                    For i As Integer = 0 To V.Count - 1
                        If i > 0 Then .Rows.Append()
                        R.Document.InsertText(.Cell(i + 1, 0).ContentRange.Start, ToText(V(i)("nameLong")))
                        R.Document.InsertText(.Cell(i + 1, 1).ContentRange.Start, ToText(V(i)("inn")))
                        R.Document.InsertText(.Cell(i + 1, 2).ContentRange.Start, ToText(V(i)("address")))
                        R.Document.InsertText(.Cell(i + 1, 3).ContentRange.Start, ToText(V(i)("okved")))
                    Next
                End Using
            End With
            R.Document.EndUpdate()
            R.Document.SaveDocument("d:\report.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        End Using
        Cprp.DxCommon.Messages.ShowInformation("Операция завершена.")
    End Sub

    ''' <summary>
    ''' Создать профиль
    ''' </summary>
    ''' <param name="inn">ИНН</param>
    Private Sub MakeProfile(inn As String)
        Dim Body As String = Nothing
        Try
            Dim orderCount As Integer = 0               ' Количество заказов компании в EXDBA.tWork
            Dim orderDateEnd As Date = Nothing          ' Дата последнего заказа компании в EXDBA.tWork
            Dim workCount As Single = 0                 ' Количество работ компании в EXDB8.tWork
            Dim askCount As Single = 0                  ' Количество запросов компании в EXDB8.tWorkHistory
            Dim askPercent As Single = 0                ' Процент работ без запросов в EXDB8 (0...1)
            Dim docCount As Integer = 0                 ' Количество заключений компании в EXDBA.tOutDoc
            Dim doc2Count As Integer = 0                ' Количество заключений компании с выводами "Требуется лицензия" в EXDBA.tOutDoc
            Dim doc3Count As Integer = 0                ' Количество заключений компании с выводами "Требуется разрешение" в EXDBA.tOutDoc
            Dim docf2Count As Integer = 0               ' Количество заключений компании с выводами "Требуется лицензия" в EXDB8.tFInfo
            Dim docf3Count As Integer = 0               ' Количество заключений компании с выводами "Требуется разрешение" в EXDB8.tFInfo

            If String.IsNullOrWhiteSpace(inn) Then Throw New Exception("Укажите ИНН!")
            For Each c As Char In inn
                If Not c Like "[0123456789]" Then Throw New Exception("Некорректный ИНН!")
            Next
            If inn.Length <> 10 Then Throw New Exception("Некорректный ИНН!")

            CmdA.CommandText = String.Format("SELECT COUNT(DISTINCT orderNum) FROM tWork WHERE clientInn = '{0}'", inn)
            orderCount = CInt(CmdA.ExecuteScalar)
            If orderCount > 0 Then
                CmdA.CommandText = String.Format("SELECT MAX(orderDate) FROM tWork WHERE clientInn = '{0}'", inn)
                orderDateEnd = CDate(CmdA.ExecuteScalar)
            End If
            Cmd8.CommandText = String.Format("SELECT COUNT(*) FROM tWork WHERE clientInn = '{0}'", inn)
            workCount = CSng(Cmd8.ExecuteScalar)
            If workCount > 0 Then
                Cmd8.CommandText = String.Format("SELECT COUNT(*) FROM tWorkHistory WHERE eventId = 10 AND workId IN (SELECT id FROM tWork WHERE clientInn = '{0}')", inn)
                askCount = CSng(Cmd8.ExecuteScalar)
                If askCount < workCount Then
                    askPercent = (workCount - askCount) / workCount
                End If
            End If
            CmdA.CommandText = String.Format("SELECT COUNT(*) FROM tOutDoc WHERE workId IN (SELECT workId FROM tMember WHERE inn = '{0}')", inn)
            docCount = CInt(CmdA.ExecuteScalar)
            If docCount > 0 Then
                CmdA.CommandText &= " AND summaryId = 2"
                doc2Count = CInt(CmdA.ExecuteScalar)
                CmdA.CommandText = CmdA.CommandText.Replace("= 2", "= 3")
                doc3Count = CInt(CmdA.ExecuteScalar)
            End If
            Cmd8.CommandText = String.Format("SELECT COUNT(DISTINCT docNum) FROM tFInfo WHERE rusInn = '{0}' AND summaryId = 2", inn)
            docf2Count = CInt(Cmd8.ExecuteScalar)
            Cmd8.CommandText = Cmd8.CommandText.Replace("= 2", "= 3")
            docf3Count = CInt(Cmd8.ExecuteScalar)

            XmlCard.LoadByInn(inn)
            XmlCourt.LoadByInn(inn)

            Dim Row As DataRow = ReportTable.NewRow
            Row("nameLong") = TN(XmlCard.NameLong)
            Row("inn") = TN(XmlCard.INN)
            Row("address") = TN(XmlCard.AddressLegal)
            Row("okved") = String.Format("{0} - {1}", TN(XmlCard.OkvedCode), TN(XmlCard.OkvedName))
            ReportTable.Rows.Add(Row)


            Body &= String.Format("<p><b>{0}</b><br>{1}<br>ИНН {2}; КПП {3}; ОГРН {4}, дата регистрации: {5}<br>Юридический адрес: {6}, получен {7}.</p>", _
                                  TN(XmlCard.NameLong), TN(XmlCard.NameShort), _
                                  TN(XmlCard.INN), TN(XmlCard.Kpp), TN(XmlCard.Ogrn), DN(XmlCard.OgrnDate), _
                                  TN(XmlCard.AddressLegal), DN(XmlCard.AddressLegalDate))

            Body &= "<br>"
            Body &= "<p><b>Сведения о компании</b></p>"
            Body &= String.Format("<p>Численность работников: {0}.</p>", TN(XmlCard.WorkerCount))
            Body &= String.Format("<p>Основной вид деятельности: {0} - {1}.</p>", TN(XmlCard.OkvedCode), TN(XmlCard.OkvedName))
            Body &= String.Format("<p>Дополнительные виды деятельности ({0}):</p>", XmlCard.OkvedTable.Rows.Count)
            Body &= "<ul>"
            If XmlCard.OkvedTable.Rows.Count = 0 Then
                Body &= String.Format("<li>{0}</li>", NULL_TEXT)
            Else
                Using V As New DataView(XmlCard.OkvedTable) With {.Sort = "code"}
                    For i As Integer = 0 To V.Count - 1
                        Body &= String.Format("<li>{0} - {1}{2}</li>", _
                                              TN(V(i)("code")), TN(V(i)("name")), _
                                              If(i = V.Count - 1, ".", ";"))
                    Next
                End Using
            End If
            Body &= "</ul>"
            Body &= String.Format("<p>Руководители ({0}):</p>", XmlCard.LeaderTable.Rows.Count)
            Body &= "<ul>"
            If XmlCard.LeaderTable.Rows.Count = 0 Then
                Body &= String.Format("<li>{0}</li>", NULL_TEXT)
            Else
                Using V As New DataView(XmlCard.LeaderTable) With {.Sort = "nameLong"}
                    For i As Integer = 0 To V.Count - 1
                        Body &= String.Format("<li>{0}, должность: {1}, действует с {2}{3}</li>", _
                                              TN(V(i)("nameLong")), TN(V(i)("post")), DN(V(i)("regDate")), _
                                              If(i = V.Count - 1, ".", ";"))
                    Next
                End Using
            End If
            Body &= "</ul>"
            Body &= String.Format("<p>Учредители ({0}):</p>", XmlCard.FounderTable.Rows.Count)
            Body &= "<ul>"
            If XmlCard.FounderTable.Rows.Count = 0 Then
                Body &= String.Format("<li>{0}</li>", NULL_TEXT)
            Else
                Using V As New DataView(XmlCard.FounderTable) With {.Sort = "percent DESC, name ASC"}
                    For i As Integer = 0 To V.Count - 1
                        Body &= String.Format("<li>{0}% {1} {2} руб., {3}, ИНН: {4}{5}</li>", _
                                              SN(V(i)("percent")), TN(V(i)("name")), _
                                              SN(V(i)("sum")), DN(V(i)("regDate")), TN(V(i)("inn")), _
                                              If(i = V.Count - 1, ".", ";"))
                    Next
                End Using
            End If
            Body &= "</ul>"
            Body &= String.Format("<p>Судебные дела ({0}):</p>", XmlCourt.CourtTable.Rows.Count)
            Body &= "<ul>"
            If XmlCourt.CourtTable.Rows.Count = 0 Then
                Body &= "<li>отсутствуют.</li>"
            Else
                Using V As New DataView(XmlCourt.CourtTable) With {.Sort = "regDate DESC"}
                    For i As Integer = 0 To V.Count - 1
                        Body &= String.Format("<li>№ {0} от {1}, {2} руб., {3}: {4}, ИНН {5}, ОГРН {6}{7}</li>", _
                                              TN(V(i)("regNum")), DN(V(i)("regDate")), SN(V(i)("sum")), _
                                              If(CBool(V(i)("isPlf")), "истец", "ответчик"), _
                                              TN(V(i)("name")), TN(V(i)("inn")), TN(V(i)("ogrn")), _
                                              If(i = V.Count - 1, ".", ";"))
                    Next
                End Using
            End If
            Body &= "</ul>"

            Body &= "<br>"
            Body &= "<p><b>Сведения из базы ""ЭксКонт""</b></p>"
            If orderCount = 0 Then
                Body &= "<p>Количество заказов: 0.</p>"
            Else
                Body &= String.Format("<p>Количество заказов: {0}.</p>", orderCount)
                Body &= String.Format("<p>Дата последнего заказа: {0}.</p>", DN(orderDateEnd))
                Body &= String.Format("<p>Оценка полноты и достоверности представляемой информации: {0} (работ: {1}, запросов: {2}).</p>", SN(askPercent), workCount, askCount)
            End If
            If docCount = 0 Then
                Body &= "<p>Количество работ (российский участник ВЭД): 0.</p>"
            Else
                Body &= String.Format("<p>Количество работ (российский участник ВЭД): {0}.</p>", docCount)
                Body &= String.Format("<p>Количество работ с выводами ""Требуется лицензия"": {0}.</p>", doc2Count)
                Body &= String.Format("<p>Количество работ с выводами ""Требуется разрешение"": {0}.</p>", doc3Count)
            End If

            Body &= "<br>"
            Body &= "<p><b>Сведения из базы заключений (лицензии и разрешения)</b></p>"
            Body &= String.Format("<p>Количество заключений с выводами ""Требуется лицензия"": {0}.</p>", docf2Count)
            Body &= String.Format("<p>Количество заключений с выводами ""Требуется разрешение"": {0}.</p>", docf3Count)

            My.Computer.FileSystem.WriteAllText(String.Format("d:\htm\{0}.htm", inn), String.Format("<html>{0}<body>{1}</body></html>", HTML_CSS_JS, Body), False)

        Catch ex As Exception
            Body = String.Format("<p class='red'>{0}</p>", ex.Message)
            Throw ex
        Finally
            W.DocumentText = String.Format("<html>{0}<body>{1}</body></html>", HTML_CSS_JS, Body)
            Me.Text = inn
            System.Windows.Forms.Application.DoEvents()
        End Try

    End Sub


    ' Сохранить профиль в файл
    Private Sub SaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SaveBarButtonItem.ItemClick
        W.ShowSaveAsDialog()
    End Sub

    ''' <summary>
    ''' Возвращает текстовое представление текстовых данных
    ''' </summary>
    ''' <param name="DT">Текстовые данные</param>
    ''' <remarks>Если данные не содержат текст, возвращает NULL_TEXT</remarks>
    Private Function TN(DT As Object) As String
        Dim sTmp As String = ToText(DT)
        If Not IsText(sTmp) Then Return NULL_TEXT
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает текстовое представление даты в формате "dd.MM.yyyy"
    ''' </summary>
    ''' <param name="DT">Данные с датой</param>
    ''' <remarks>Если данные не содержат дату, возвращает NULL_TEXT</remarks>
    Private Function DN(DT As Object) As String
        Dim sTmp As String = ToText(DT)
        If Not (IsText(sTmp) AndAlso IsDate(sTmp)) Then Return NULL_TEXT
        Return Format(CDate(sTmp), "dd.MM.yyyy")
    End Function

    ''' <summary>
    ''' Возвращает текстовое представление дробного числа в формате "#.00"
    ''' </summary>
    ''' <param name="DT">Данные с числом</param>
    ''' <remarks>Если данные не содержат дату, возвращает NULL_TEXT</remarks>
    Private Function SN(DT As Object) As String
        Dim sTmp As String = ToText(DT)
        If Not (IsText(sTmp) AndAlso IsNumeric(sTmp)) Then Return NULL_TEXT
        Return Format(CSng(sTmp), "0.00")
    End Function

End Class