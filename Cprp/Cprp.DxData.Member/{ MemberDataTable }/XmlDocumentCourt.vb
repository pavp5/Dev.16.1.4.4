Imports System.Xml
Imports Cprp.DxData.XmlCommon
Imports Cprp.DxData.Common
''' <summary>
''' Судебные дела российского лица
''' </summary>
Public Class XmlDocumentCourt : Inherits System.Xml.XmlDocument

#Region "Таблица судебных дел компании"

    ''' <summary>
    ''' Таблица судебных дел компании
    ''' </summary>
    Public Class CourtDataTable : Inherits DataTable


        Friend Sub New()
            MyBase.New("CourtTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("regNum", GetType(String))             ' Номер дела
                .Add("regDate", GetType(Date))              ' Дата
                .Add("sum", GetType(Single))                ' Сумма иска
                .Add("isPlf", GetType(Boolean))             ' Истец (да/нет - Ответчик)
                .Add("name", GetType(String))               ' Наименование
                .Add("inn", GetType(String))                ' ИНН
                .Add("ogrn", GetType(String))               ' ОГРН
            End With
            With Me.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            With Me.Columns("isPlf")
                .AllowDBNull = False
                .DefaultValue = True
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub


        ''' <summary>
        ''' Загрузить данные из xml-документа
        ''' </summary>
        ''' <param name="Doc">Документ с карточкой компании</param>
        ''' <param name="inn">ИНН компании</param>
        Public Sub LoadXmlData(Doc As XmlDocument, inn As String)
            Me.Rows.Clear()
            Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/точно/дела")
            If N Is Nothing Then Exit Sub
            Dim Row As DataRow = Nothing
            Dim plfName As String = Nothing
            Dim plfInn As String = Nothing
            Dim plfOgrn As String = Nothing
            Dim dfnName As String = Nothing
            Dim dfnInn As String = Nothing
            Dim dfnOgrn As String = Nothing
            For Each N1 As XmlNode In N.ChildNodes
                If N1.Name.ToUpper <> "ITEM" Then Continue For
                Row = Me.NewRow
                plfName = Nothing
                plfInn = Nothing
                plfOgrn = Nothing
                dfnName = Nothing
                dfnInn = Nothing
                dfnOgrn = Nothing
                For Each N2 As XmlNode In N1.ChildNodes
                    Select Case N2.Name.ToUpper
                        Case "ОТВЕТЧИК"
                            For Each N3 As XmlNode In N2.ChildNodes
                                If N3.Name.ToUpper <> "ITEM" Then Continue For
                                For Each N4 As XmlNode In N3.ChildNodes
                                    Select Case N4.Name.ToUpper
                                        Case "НАИМЕНОВАНИЕ" : dfnName = ToText(N4.InnerText) : Exit Select
                                        Case "ИНН" : dfnInn = ToText(N4.InnerText) : Exit Select
                                        Case "ОГРН" : dfnOgrn = ToText(N4.InnerText) : Exit Select
                                    End Select
                                Next
                                Exit For
                            Next
                            Exit Select
                        Case "ИСТЕЦ"
                            For Each N3 As XmlNode In N2.ChildNodes
                                If N3.Name.ToUpper <> "ITEM" Then Continue For
                                For Each N4 As XmlNode In N3.ChildNodes
                                    Select Case N4.Name.ToUpper
                                        Case "НАИМЕНОВАНИЕ" : plfName = ToText(N4.InnerText) : Exit Select
                                        Case "ИНН" : plfInn = ToText(N4.InnerText) : Exit Select
                                        Case "ОГРН" : plfOgrn = ToText(N4.InnerText) : Exit Select
                                    End Select
                                Next
                                Exit For
                            Next
                            Exit Select
                        Case "НОМЕРДЕЛА" : Row("regNum") = DbText(N2.InnerText) : Exit Select
                        Case "СТАРТДАТА" : Row("regDate") = DbDate(N2.InnerText) : Exit Select
                        Case "СУММАИСКА" : Row("sum") = DbSng(N2.InnerText) : Exit Select
                    End Select
                Next
                If IsText(plfInn) AndAlso plfInn <> inn Then
                    Row("isPlf") = True
                    Row("name") = plfName
                    Row("inn") = plfInn
                    Row("ogrn") = plfOgrn
                Else
                    Row("isPlf") = False
                    Row("name") = dfnName
                    Row("inn") = dfnInn
                    Row("ogrn") = dfnOgrn
                End If
                Me.Rows.Add(Row)
            Next
        End Sub

    End Class

#End Region

    ''' <summary>
    ''' Таблица судебных дел компании
    ''' </summary>
    Public CourtTable As CourtDataTable = Nothing

    ''' <summary>
    ''' Клиент для выполнения http-запросов
    ''' </summary>
    Private WebClient As System.Net.WebClient = Nothing

    ''' <summary>
    ''' Шаблон запроса поиска данных по ИНН фирмы
    ''' </summary>
    Private Const INN_FIND_TEMPATE As String = "https://zachestnyibiznesapi.ru/paid/data/court-arbitration?id={0}&api_key=GIP0mH_QzZUa60zCIOO90sX95ggTCHh-&_format=xml"


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="WebClient">Клиент для выполнения http-запросов</param>
    Public Sub New(WebClient As System.Net.WebClient)
        MyBase.New()
        Me.WebClient = WebClient
        If Me.WebClient Is Nothing Then Me.WebClient = New System.Net.WebClient
        CourtTable = New CourtDataTable
    End Sub


    Public Overloads Sub LoadXml(xml As String, inn As String)
        MyBase.LoadXml(xml)
        CourtTable.LoadXmlData(Me, inn)
    End Sub

    ''' <summary>
    ''' Загрузить данные по ИНН компании
    ''' </summary>
    ''' <param name="inn">ИНН компании</param>
    Public Sub LoadByInn(inn As String)
        inn = ToText(inn)
        If String.IsNullOrWhiteSpace(inn) Then Exit Sub
        With My.Computer.FileSystem
            'If .FileExists(String.Format("d:\{0}_court.xml", inn)) Then
            '    Me.Load(String.Format("d:\{0}_court.xml", inn))
            'Else
            Dim tmpPath As String = .GetTempFileName
            .WriteAllBytes(tmpPath, WebClient.DownloadData(INN_FIND_TEMPATE.Replace("{0}", inn)), False)
            Me.Load(tmpPath)
            '.CopyFile(tmpPath, String.Format("d:\{0}_court.xml", inn), True)
            '.DeleteFile(tmpPath)
            'End If
        End With
        CourtTable.LoadXmlData(Me, inn)
    End Sub


End Class
