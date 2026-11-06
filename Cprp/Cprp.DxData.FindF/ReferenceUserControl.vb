Imports C2 = Cprp.DxData.Common
''' <summary>
''' Справка о заключении
''' </summary>
''' <remarks></remarks>
Friend Class ReferenceUserControl

    Private _docId As Integer = C2.EMPTY_ID
    ''' <summary>
    ''' ID текущего документа
    ''' </summary>
    ''' <remarks></remarks>
    Friend WriteOnly Property DocId As Integer
        Set(value As Integer)
            If value = _docId Then Exit Property
            If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Property
            _docId = value
            '
            ' DocTable, GoodTable
            '
            DocTable.Rows.Clear()
            GoodTable.Rows.Clear()
            Using Cmd As New SqlCommand With {.Connection = Connection}
                Cmd.CommandText = String.Format("SELECT * FROM vDocOrg WHERE id = {0}", _docId)
                DocTable.Load(Cmd.ExecuteReader)
                Cmd.CommandText = String.Format("SELECT * FROM tGood WHERE docId = {0}", _docId)
                GoodTable.Load(Cmd.ExecuteReader)
            End Using
            '
            ' СОЗДАНИЕ СПРАВКИ
            '
            Dim elId As Integer = 100                   ' ID последнего динамически сформированного элемента
            Dim nullText As String = "[нет данных]"     ' Стандартное сообщение об отсутствии данных
            Dim sTmp As String = Nothing

            Dim Html As String = "<!DOCTYPE HTML><html>"
            '
            ' Head
            '
            Html &= "<head>" & vbCrLf
            Html &= "<title>Справка о заключении</title>"
            Html &= "<style media='screen'>" & vbCrLf
            Html &= "* {font-family: Calibri,Arial; font-size: 13pt; border-color:black}" & vbCrLf
            Html &= "ul, ol {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf
            Html &= "p {margin: 0pt;}" & vbCrLf
            Html &= "table {border-collapse: collapse; margin-top: 3pt;}" & vbCrLf
            Html &= "td {vertical-align: top; padding:4pt;}" & vbCrLf
            Html &= "th {font-weight:normal; font-style:italic; vertical-align:middle; padding:4pt;}" & vbCrLf
            Html &= "a {color:#000080; text-decoration:none}" & vbCrLf
            Html &= "a:hover {font-weight:bold;}" & vbCrLf
            Html &= ".tree span:hover {font-weight: bold;}" & vbCrLf
            Html &= ".tree span {font-size:14pt; cursor: pointer;}" & vbCrLf
            Html &= "li {margin-top: 3pt;}" & vbCrLf
            Html &= "td li {margin-top: 0pt;}" & vbCrLf
            Html &= ".notree span:hover {font-weight: normal;}" & vbCrLf
            Html &= ".notree span {font-size:13pt; cursor: auto;}" & vbCrLf
            Html &= ".red {color: red;}" & vbCrLf
            Html &= ".byellow {background-color: lightyellow;}" & vbCrLf
            Html &= ".bazure {background-color: azure;}" & vbCrLf
            Html &= ".hidden {display: none;}" & vbCrLf
            Html &= "</style>" & vbCrLf
            Html &= "<style media='print'>" & vbCrLf
            Html &= "* {font-family: Calibri,Arial; font-size: 13pt; border-color:black}" & vbCrLf
            Html &= "ul {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf
            Html &= "p {margin: 0pt;}" & vbCrLf
            Html &= "table {border-collapse: collapse;}" & vbCrLf
            Html &= "td {vertical-align: top;padding:4pt;}" & vbCrLf
            Html &= "th {font-weight:normal; font-style:italic; vertical-align:middle; padding:4pt;}" & vbCrLf
            Html &= "a {color:black; text-decoration:none}" & vbCrLf
            Html &= "</style>" & vbCrLf
            Html &= "<script language='JavaScript' type='text/javascript'>" & vbCrLf
            Html &= "<!-- " & vbCrLf
            Html &= "function hs(el) {el.className = (el.className == 'hidden') ? '' : 'hidden';}" & vbCrLf
            Html &= " -->" & vbCrLf
            Html &= "</script>" & vbCrLf
            Html &= "</head>" & vbCrLf
            '
            ' Body
            '
            Html &= "<body>" & vbCrLf
            If DocTable.Rows.Count = 0 Then GoTo LEND
            '
            ' RootNode
            '
            Html &= "<ul class='tree'>"
            '
            ' Сведения о заключении
            '
            Html &= "<li style='margin-top: 0pt;'><span onclick='javascript: hs(el1);'>СВЕДЕНИЯ О ЗАКЛЮЧЕНИИ</span>"
            Html &= "<ul id='el1'>"
            Html &= "<table width='100%' border='1'>"
            Html &= "<col width='336pt'><col>"
            With DocTable.Rows(0)
                Html &= "<tr>"
                Html &= "<th>Номер и дата</th>"
                sTmp = C2.ToText(.Item("docNum"))
                If C2.IsText(.Item("docDate")) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(.Item("docDate")))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= "<th>Экспертная организация</th>"
                sTmp = C2.ToText(.Item("orgNameLong"))
                If C2.IsText(.Item("orgAddress")) Then sTmp = String.Format("{0}, {1}", sTmp, C2.ToText(.Item("orgAddress")))
                If C2.IsText(.Item("orgInn")) Then sTmp = String.Format("{0}, ИНН: {1}", sTmp, C2.ToText(.Item("orgInn")))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= "<th>Страна назначения</th>"
                sTmp = C2.ToText(.Item("countryName"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= "<th>Документ-основание операции</th>"
                sTmp = C2.ToText(.Item("conNum"))
                If Not C2.IsText(sTmp) Then sTmp = "б/н"
                If C2.IsText(.Item("conDate")) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(.Item("conDate")))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= "<th>Российский участник операции</th>"
                sTmp = C2.ToText(.Item("rusCaption"))
                If C2.IsText(sTmp) AndAlso C2.IsText(.Item("rusInn")) Then sTmp = String.Format("{0}, ИНН: {1}", sTmp, C2.ToText(.Item("rusInn")))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= "<th>Иностранный покупатель (продавец)</th>"
                sTmp = C2.ToText(.Item("nusCaption"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                Html &= "</tr>"
                Html &= "<tr>"
                Html &= "<th>Потребитель (конечный пользователь)</th>"
                sTmp = C2.ToText(.Item("nusCaption"))
                Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                Html &= "</tr>"
            End With
            Html &= "</table>"
            Html &= "</ul>"
            '
            Html &= "</li>"                             ' /Сведения о заключении
            '
            ' Продукция (объекты экспертизы)
            '
            Html &= "<li style='margin-top: 18pt;'><span onclick='javascript: hs(el14);'>ПРОДУКЦИЯ (ОБЪЕКТЫ ЭКСПЕРТИЗЫ)</span>"
            Html &= "<ul id='el14'>"
            Using V As New DataView(GoodTable)
                V.Sort = "goodName"
                If V.Count = 0 Then Html &= "<p>[нет данных]</p>"
                elId += 10000
                For i As Integer = 0 To V.Count - 1
                    '
                    ' Продукция (объекты экспертизы) > Объект №
                    '
                    elId += 1
                    Html &= String.Format("<li><span onclick='javascript: hs(el{0});'>Объект № {1}.</span>", elId, i + 1)
                    Html &= String.Format("<ul id='el{0}'>", elId)
                    Html &= "<table class='notree' width='100%' border='1'>"
                    Html &= "<col width='312pt'><col>"
                    Html &= "<tr>"
                    Html &= "<th>Коммерческое наименование</th>"
                    sTmp = C2.ToText(V(i)("goodName"))
                    Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                    Html &= "</tr>"
                    Html &= "<tr>"
                    Html &= "<th>Код ТН ВЭД</th>"
                    sTmp = C2.ToText(V(i)("goodTnved"))
                    Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                    Html &= "</tr>"
                    Html &= "<tr>"
                    Html &= "<th>Техническое описание</th>"
                    sTmp = C2.ToText(V(i)("goodDescription"))
                    Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                    Html &= "</tr>"
                    Html &= "<tr>"
                    Html &= "<th>Анализ по контрольным спискам</th>"
                    If CBool(V(i)("isEqual")) Then
                        sTmp = "<span class='red'>Соответствует</span>"
                    Else
                        sTmp = "Не соответствует"
                    End If
                    Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                    Html &= "</tr>"
                    Html &= "<tr>"
                    Html &= "<th>Пункты контрольных списков</th>"
                    sTmp = C2.ToText(V(i)("goodPos"))
                    Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
                    Html &= "</tr>"
                    sTmp = C2.ToText(V(i)("summary"))
                    If C2.IsText(sTmp) Then
                        Html &= "<tr>"
                        Html &= "<th>Дополнительная информация</th>"
                        Html &= String.Format("<td>{0}</td>", sTmp)
                        Html &= "</tr>"
                    End If
                    Html &= "</table>"
                    Html &= "</ul>"
                    Html &= "</li>"                     ' /Продукция (объекты экспертизы) > Объект №
                Next
            End Using
            '
            Html &= "</ul>"
            Html &= "</li>"                             ' /Продукция (объекты экспертизы)
            '
            Html &= "</ul>"                             ' /RootNode
LEND:
            Html &= "</body>"
            Html &= "</html>"

            W.DocumentText = Html

        End Set
    End Property


    ''' <summary>
    ''' Открытое соединение с базой данных
    ''' </summary>
    ''' <remarks></remarks>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Таблица-строка с данными заключения
    ''' </summary>
    ''' <remarks></remarks>
    Private DocTable As DataTable = Nothing

    ''' <summary>
    ''' Таблица объектов экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Private GoodTable As DataTable = Nothing

    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        Me.Connection = Connection
        '
        ' DocTable, GoodTable
        '
        DocTable = New DataTable
        GoodTable = New DataTable
        Using Cmd As New SqlCommand With {.Connection = Me.Connection}
            Cmd.CommandText = "SELECT * FROM vDocOrg WHERE id IS NULL"
            DocTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = "SELECT * FROM tGood WHERE id IS NULL"
            GoodTable.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ' Сохранить документ
    Private Sub SaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SaveBarButtonItem.ItemClick
        W.ShowSaveAsDialog()
    End Sub

    ' Печать документа
    Private Sub PrintBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PrintBarButtonItem.ItemClick
        W.ShowPrintDialog()
    End Sub

    ' Поиск в тексте документа
    Private Sub FindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        W.Focus()
        SendKeys.Send("^f")
    End Sub

End Class
