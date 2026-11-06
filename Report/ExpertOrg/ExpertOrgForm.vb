Imports Cprp.DxData.Common
''' <summary>
''' Справка об экспертной организации
''' </summary>
Friend Class ExpertOrgForm

    ''' <summary>
    ''' ID организации
    ''' </summary>
    Friend Property OrgId As Integer = Cprp.DxData.Common.EMPTY_ID

#Region "Таблица заключений"

    ''' <summary>
    ''' Таблица заключений организации
    ''' </summary>
    Private Class DocDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New("DocTable")
            With Me.Columns
                .Add("docDate", GetType(Date))
                .Add("maxNum", GetType(Integer))
            End With
            Me.Columns("docDate").AllowDBNull = False
            Me.Columns("maxNum").AllowDBNull = False
            Me.PrimaryKey = New DataColumn() {Me.Columns("docDate")}
        End Sub
    End Class


#End Region
#Region "Шаблон справки"

    ''' <summary>
    ''' Шаблон справки об организации
    ''' </summary>
    Private Const REF_TEMPLATE As String = _
        "<html>" & vbCrLf & _
        "<title>Справка об организации</title>" & vbCrLf & _
        "<style media='screen'>" & vbCrLf & _
        "* {font-family: Calibri,Arial; font-size: 13pt; border-color:black}" & vbCrLf & _
        "ul, ol {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf & _
        "p {margin: 0pt;}" & vbCrLf & _
        "table {border-collapse: collapse; margin-top: 3pt;}" & vbCrLf & _
        "td {vertical-align: top; padding:4pt;}" & vbCrLf & _
        "th {font-weight:normal; font-style:italic; background-color:#e0e0e0; vertical-align:middle; padding:4pt;}" & vbCrLf & _
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
        "</script>" & vbCrLf & _
        "<body>" & vbCrLf & _
        "<p><b>{NAMELONG}</b></p>" & _
        "<table width=100% border='1'><tr><td>{FINFO}</td></tr></table>" & vbCrLf & _
        "</body>" & vbCrLf & _
        "</html>"

#End Region

    ''' <summary>
    ''' Таблица заключений организации
    ''' </summary>
    Private DocTable As DocDataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="orgId">ID организации</param>
    ''' <param name="Connection">Открытое подключение к базе данных EXDB8</param>
    Friend Sub New(orgId As Integer, Connection As SqlConnection)
        InitializeComponent()
        Me.OrgId = orgId
        Using Cmd As SqlCommand = Connection.CreateCommand
            '
            ' Справка об организации
            '
            Dim docText As String = REF_TEMPLATE
            Dim nameShort As String = Nothing
            Dim nameLong As String = Nothing
            Dim fInfo As String = Nothing
            Cmd.CommandText = String.Format("SELECT nameShort, nameLong, fInfo FROM tExpertOrg WHERE id = {0}", Me.OrgId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    nameShort = ToText(Dr("nameShort"))
                    nameLong = ToText(Dr("nameLong"))
                    fInfo = ToText(Dr("fInfo"))
                End If
            End Using
            If Not IsText(nameShort) Then nameShort = "Нет данных"
            If Not IsText(nameLong) Then nameLong = "Нет данных"
            If Not IsText(fInfo) Then fInfo = "Нет данных"
            docText = docText.Replace("{NAMELONG}", nameLong).Replace("{FINFO}", fInfo)
            Me.Text = nameShort
            InfoWebBrowser.DocumentText = docText
            '
            ' Заключения организации
            '
            DocTable = New DocDataTable
            Dim dateE As Date = Date.Today.AddDays(-1 * Date.Today.Day + 1).AddMonths(1)    ' 1 число следующего месяца
            Dim dateB As Date = Date.Today
            Dim docNum As String = Nothing
            Dim maxNum As Integer = 0
            For i As Integer = 0 To 24
                dateB = CDate(String.Format("01.01.{0}", dateE.AddMonths(-1).Year))
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '0') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND docDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}", Me.OrgId, dateB, dateE)
                docNum = Cmd.ExecuteScalar.ToString
                If Not docNum Like "*-*" Then
                    maxNum = 0
                Else
                    maxNum = CInt(docNum.Substring(0, docNum.IndexOf("-")))
                End If
                If dateE > Date.Today Then
                    DocTable.Rows.Add(New Object() {Date.Today, maxNum})
                Else
                    DocTable.Rows.Add(New Object() {dateE, maxNum})
                End If
                dateE = dateE.AddMonths(-1)
            Next
            DocChartControl.DataSource = DocTable
        End Using

        Me.Icon = My.Resources.company_ico
        Me.Width = 0.7 * Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height - 2
        Me.Left = Screen.GetWorkingArea(Me).Width - Me.Width - 1
        Me.Top = 1

    End Sub

End Class