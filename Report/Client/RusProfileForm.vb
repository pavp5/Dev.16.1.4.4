Imports Cprp.DxData
Imports Cprp.DxData.Common
Imports Cprp.DxData.Member.MemberDataTable
''' <summary>
''' Форма с профилем российского лица
''' </summary>
Public Class RusProfileForm

    ''' <summary>
    ''' ИНН лица
    ''' </summary>
    Public Property Inn As String = Nothing

    ''' <summary>
    ''' Главная форма приложения
    ''' </summary>
    Private PForm As Form = Nothing

    ''' <summary>
    ''' Нет данных
    ''' </summary>
    Private Const NULL_TEXT As String = "[нет данных]"


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="inn">ИНН</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="PForm">Главная форма приложения</param>
    ''' <remarks></remarks>
    Public Sub New(inn As String, Connection As SqlConnection, Optional ByRef PForm As Form = Nothing)
        InitializeComponent()

        Me.Inn = ToText(inn)
        If String.IsNullOrWhiteSpace(Me.Inn) Then Exit Sub

        Me.PForm = PForm
        ' Таблица работ российского лица
        Dim RusWorkTable As RusWorkDataTable = Nothing
        ' Таблица контролируемых заключений российского лица
        Dim RusDocTable As RusDocDataTable = Nothing
        ' Клиент для выполнения http-запросов
        Dim WebClient As System.Net.WebClient = Nothing
        ' Карточка российского лица
        Dim XmlCard As Member.XmlDocumentCard = Nothing
        ' Судебные дела росийского лица
        Dim XmlCourt As Member.XmlDocumentCourt = Nothing

        Dim Body As String = Nothing
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Cprp.DxCommon.WaitForm.Show()
        Try

            RusWorkTable = New RusWorkDataTable
            RusDocTable = New RusDocDataTable
            If WebClient Is Nothing Then WebClient = New Net.WebClient
            If XmlCard Is Nothing Then XmlCard = New Member.XmlDocumentCard(WebClient)
            If XmlCourt Is Nothing Then XmlCourt = New Member.XmlDocumentCourt(WebClient)
            RusWorkTable.LoadByInn(Me.Inn, Connection)
            RusDocTable.LoadByInn(Me.Inn, Connection)
            Using Cmd As SqlCommand = Connection.CreateCommand
                ' xmlCard
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(id), -1) FROM tMember WHERE inn = '{0}' AND NOT xmlCard IS NULL", Me.Inn)
                iTmp = CInt(Cmd.ExecuteScalar)
                If iTmp > 0 Then
                    Cmd.CommandText = String.Format("SELECT xmlCard FROM tMember WHERE id = {0}", iTmp)
                    sTmp = Cmd.ExecuteScalar.ToString
                    XmlCard.LoadXml(sTmp)
                Else
                    XmlCard.LoadByInn(inn)
                    SaveXmlCard(XmlCard.InnerXml, Connection)
                End If
                ' xmlCourt
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(id), -1) FROM tMember WHERE inn = '{0}' AND NOT xmlCourt IS NULL", Me.Inn)
                iTmp = CInt(Cmd.ExecuteScalar)
                If iTmp > 0 Then
                    Cmd.CommandText = String.Format("SELECT xmlCourt FROM tMember WHERE id = {0}", iTmp)
                    sTmp = Cmd.ExecuteScalar.ToString
                    XmlCourt.LoadXml(sTmp, Me.Inn)
                Else
                    XmlCourt.LoadByInn(inn)
                    SaveXmlCourt(XmlCourt.InnerXml, Connection)
                End If
            End Using
            '
            ' Реквизиты компании
            '
            Body &= String.Format("<p><b>{0}</b><br>{1}<br>ИНН {2}; КПП {3}; ОГРН {4}, дата регистрации: {5}<br>Юридический адрес: {6}, получен {7}.</p>", _
                                  TN(XmlCard.NameLong), TN(XmlCard.NameShort), _
                                  TN(XmlCard.INN), TN(XmlCard.Kpp), TN(XmlCard.Ogrn), DN(XmlCard.OgrnDate), _
                                  TN(XmlCard.AddressLegal), DN(XmlCard.AddressLegalDate))
            '
            ' Сведения из базы "ЭксКонт"
            '
            Body &= "<br>"
            Body &= "<p class='tree'><a href='javascript: hs(el01);'>Сведения из базы ""ЭксКонт"":</a></p>"
            Body &= "<span id='el01'>"
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
                Body &= "<p class='tree'><span onclick='javascript: hs(el1);'>Перечень заказов и работ:</span></p>"
                Body &= "<ul id='el1'>"
                With RusWorkTable.DefaultView
                    .Sort = "workId DESC"
                    For i As Integer = 0 To .Count - 1
                        Body &= String.Format( _
                            "<li><a href='{2}' target=_blank>Заказ № {3} от {4}</a>, <span class='{7}'>Работа № {0} ({1})</span>, {5}, {6}{8}</li>", _
                            TInt(.Item(i)("workId"), Nothing, 5), TStr(.Item(i)("workTypeLetter")), _
                            TStr(.Item(i)("orderUrl")), TStr(.Item(i)("orderNum")), TDate(.Item(i)("orderDate")), _
                            TStr(.Item(i)("workdescription")), TStr(.Item(i)("workCountry"), "[нет страны]"), _
                            If(ToInt(.Item(i)("workSummaryId")) > 1, "red", "none"), _
                            If(i = .Count - 1, ".", ";"))
                    Next
                End With
                Body &= "</ul>"
            End If
            Body &= "</span>"
            '
            ' Сведения из базы заключений
            '
            Body &= "<br>"
            Body &= "<p class='tree'><a href='javascript: hs(el02);'>Сведения из базы заключений (лицензии и разрешения):</a></p>"
            Body &= "<span id='el02'>"
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
            Body &= "</span>"
            '
            ' Дополнительные сведения о компании
            '
            Body &= "<br>"
            Body &= "<p class='tree'><a href='javascript: hs(el03);'>Дополнительные сведения о компании:</a></p>"
            Body &= "<span id='el03'>"
            iTmp = ToInt(XmlCard.WorkerCount)
            Body &= String.Format("<p>Численность работников: {0}.</p>", If(iTmp > 0, iTmp.ToString, "[нет данных]"))
            Body &= String.Format("<p>Основной вид деятельности: {0} - {1}.</p>", TStr(XmlCard.OkvedCode), TStr(XmlCard.OkvedName))
            Body &= String.Format("<p class='tree'><span onclick='javascript: hs(el3);'>Дополнительные виды деятельности ({0}):</span></p>", XmlCard.OkvedTable.Rows.Count)
            Body &= "<ul id='el3'>"
            If XmlCard.OkvedTable.Rows.Count = 0 Then
                Body &= "<li>[нет данных]</li>"
            Else
                Using V As New DataView(XmlCard.OkvedTable) With {.Sort = "code"}
                    For i As Integer = 0 To V.Count - 1
                        Body &= String.Format("<li>{0} - {1}{2}</li>", _
                                              TStr(V(i)("code")), TStr(V(i)("name")), If(i = V.Count - 1, ".", ";"))
                    Next
                End Using
            End If
            Body &= "</ul>"
            Body &= String.Format("<p class='tree'><span onclick='javascript: hs(el4);'>Руководители ({0}):</span></p>", XmlCard.LeaderTable.Rows.Count)
            Body &= "<ul id='el4'>"
            If XmlCard.LeaderTable.Rows.Count = 0 Then
                Body &= "<li>[нет данных]</li>"
            Else
                Using V As New DataView(XmlCard.LeaderTable) With {.Sort = "nameLong"}
                    For i As Integer = 0 To V.Count - 1
                        Body &= String.Format("<li>{0}, должность: {1}, действует с {2}{3}</li>", _
                                              TStr(V(i)("nameLong")), TStr(V(i)("post")), TDate(V(i)("regDate")), _
                                              If(i = V.Count - 1, ".", ";"))
                    Next
                End Using
            End If
            Body &= "</ul>"
            Body &= String.Format("<p class='tree'><span onclick='javascript: hs(el5);'>Учредители ({0}):</span></p>", XmlCard.FounderTable.Rows.Count)
            Body &= "<ul id='el5'>"
            If XmlCard.FounderTable.Rows.Count = 0 Then
                Body &= "<li>[нет данных]</li>"
            Else
                Using V As New DataView(XmlCard.FounderTable) With {.Sort = "percent DESC, name ASC"}
                    For i As Integer = 0 To V.Count - 1
                        Body &= String.Format("<li>{0}% {1} {2} руб., {3}, ИНН: {4}{5}</li>", _
                                              TSng(V(i)("percent")), TStr(V(i)("name")), _
                                              TSng(V(i)("sum")), TDate(V(i)("regDate")), TStr(V(i)("inn")), _
                                              If(i = V.Count - 1, ".", ";"))
                    Next
                End Using
            End If
            Body &= "</ul>"
            Body &= "</span>"
            '
            ' Судебные дела
            '
            Body &= "<br>"
            Body &= String.Format("<p class='tree'><a href='javascript: hs(el6);'>Судебные дела ({0}):</a></p>", XmlCourt.CourtTable.Rows.Count)
            Body &= "<ul id='el6' class='hidden'>"
            If XmlCourt.CourtTable.Rows.Count = 0 Then
                Body &= "<li>[нет данных]</li>"
            Else
                Using V As New DataView(XmlCourt.CourtTable) With {.Sort = "regDate DESC"}
                    For i As Integer = 0 To V.Count - 1
                        Body &= String.Format("<li>№ {0} от {1}, {2} руб., {3}: {4}, ИНН {5}, ОГРН {6}{7}</li>", _
                                              TStr(V(i)("regNum")), TDate(V(i)("regDate")), TSng(V(i)("sum")), _
                                              If(CBool(V(i)("isPlf")), "истец", "ответчик"), _
                                              TStr(V(i)("name")), TStr(V(i)("inn")), TStr(V(i)("ogrn")), _
                                              If(i = V.Count - 1, ".", ";"))
                    Next
                End Using
            End If
            Body &= "</ul>"

            Me.Text = XmlCard.NameShort
        Catch ex As Exception
            Body = String.Format("<span class = 'red'>{0}</span>", ex.Message)
            Me.Text = "Ошибка"
        Finally
            If Not RusWorkTable Is Nothing Then RusWorkTable.Dispose()
            If Not RusDocTable Is Nothing Then RusDocTable.Dispose()
            If Not WebClient Is Nothing Then WebClient.Dispose()
            W.DocumentText = String.Format("<html><title>{2}</title>{0}<body>{1}</body></html>", Member.MemberDataTable.HTML_CSS_JS, Body, Me.Text)
            Me.Icon = My.Resources.company_ico
            Me.Width = 0.7 * Screen.GetWorkingArea(Me).Width
            Me.Height = Screen.GetWorkingArea(Me).Height
            Me.Left = Screen.GetWorkingArea(Me).Width - Me.Width
            Me.Top = 0
            Cprp.DxCommon.WaitForm.Close()
        End Try

    End Sub

    ''' <summary>
    ''' Сохранить xml-карточку в таблицу лиц базы данных
    ''' </summary>
    ''' <param name="xmlData">xml-карточка</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Private Sub SaveXmlCard(xmlData As String, Connection As SqlConnection)
        If Not (IsText(Me.Inn) AndAlso IsText(xmlData)) Then Exit Sub
        Using M As New Cprp.DxData.Member.MemberDataTable
            Using Cmd As SqlCommand = Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT id, xmlCard FROM tMember WHERE inn = '{0}' AND isACT = 1", Me.Inn)
                M.Load(Cmd.ExecuteReader)
                For Each Row As DataRow In M.Rows
                    Row("xmlCard") = xmlData
                Next
            End Using
            Using A As New SqlDataAdapter("SELECT id, xmlCard FROM tMember", Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(M)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Сохранить xml-судебные дела в таблицу лиц базы данных
    ''' </summary>
    ''' <param name="xmlData">xml-судебные дела</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Private Sub SaveXmlCourt(xmlData As String, Connection As SqlConnection)
        If Not (IsText(Me.Inn) AndAlso IsText(xmlData)) Then Exit Sub
        Using M As New Cprp.DxData.Member.MemberDataTable
            Using Cmd As SqlCommand = Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT id, xmlCourt FROM tMember WHERE inn = '{0}' AND isACT = 1", Me.Inn)
                M.Load(Cmd.ExecuteReader)
                For Each Row As DataRow In M.Rows
                    Row("xmlCourt") = xmlData
                Next
            End Using
            Using A As New SqlDataAdapter("SELECT id, xmlCourt FROM tMember", Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(M)
            End Using
        End Using
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


    Private Sub RusProfileForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If String.IsNullOrWhiteSpace(Inn) Then
            Me.Close()
            Exit Sub
        End If
    End Sub

    Private Sub PrintBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintBarButtonItem.ItemClick
        W.ShowPrintDialog()
    End Sub

    Private Sub SaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SaveBarButtonItem.ItemClick
        W.ShowSaveAsDialog()
    End Sub
End Class