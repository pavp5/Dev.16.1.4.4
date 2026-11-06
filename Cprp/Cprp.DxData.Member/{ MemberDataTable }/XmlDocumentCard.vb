Imports System.Xml
Imports Cprp.DxData.XmlCommon
Imports Cprp.DxData.Common
''' <summary>
''' Карточка российского лица
''' </summary>
Public Class XmlDocumentCard : Inherits System.Xml.XmlDocument

#Region "Таблица руководителей компании"

    ''' <summary>
    ''' Таблица руководителей компании
    ''' </summary>
    Public Class LeaderDataTable : Inherits DataTable


        Friend Sub New()
            MyBase.New("LeaderTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("nameLong", GetType(String))           ' Фамилия Имя Отчество
                .Add("inn", GetType(String))                ' ИНН
                .Add("post", GetType(String))               ' Должность
                .Add("regDate", GetType(Date))              ' Дата вступления в должность
            End With
            With Me.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub


        ''' <summary>
        ''' Загрузить данные из xml-документа
        ''' </summary>
        ''' <param name="Doc">Документ с карточкой компании</param>
        Public Sub LoadXmlData(Doc As XmlDocument)
            Me.Rows.Clear()
            Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/Руководители")
            If N Is Nothing Then Exit Sub
            Dim Row As DataRow = Nothing
            For Each N1 As XmlNode In N.ChildNodes
                If N1.Name.ToUpper <> "ITEM" Then Continue For
                Row = Me.NewRow
                For Each N2 As XmlNode In N1.ChildNodes
                    Select Case N2.Name.ToUpper
                        Case "FL" : Row("nameLong") = DbText(N2.InnerText) : Exit Select
                        Case "INN" : Row("inn") = DbText(N2.InnerText) : Exit Select
                        Case "POST" : Row("post") = DbText(N2.InnerText) : Exit Select
                        Case "DATE" : Row("regDate") = DbDate(N2.InnerText) : Exit Select
                    End Select
                Next
                Me.Rows.Add(Row)
            Next
        End Sub

    End Class

#End Region
#Region "Таблица учредителей компании"

    ''' <summary>
    ''' Таблица учредителей компании
    ''' </summary>
    Public Class FounderDataTable : Inherits DataTable


        Friend Sub New()
            MyBase.New("FounderTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("name", GetType(String))               ' Наименование (ФИО)
                .Add("inn", GetType(String))                ' ИНН
                .Add("regDate", GetType(Date))              ' Дата регистрации
                .Add("sum", GetType(Single))                ' Доля в уставном капитале (руб.)
                .Add("percent", GetType(Single))            ' Доля в уставном капитале (%)
            End With
            With Me.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            With Me.Columns("sum")
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With Me.Columns("percent")
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub

        ''' <summary>
        ''' Загрузить данные из xml-документа
        ''' </summary>
        ''' <param name="Doc">Документ с карточкой компании</param>
        Public Sub LoadXmlData(Doc As XmlDocument)
            Me.Rows.Clear()
            Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/СвУчредит/all")
            If N Is Nothing Then Exit Sub
            Dim Row As DataRow = Nothing
            Dim sumAll As Single = 0
            Dim sum As Single = 0
            For Each N1 As XmlNode In N.ChildNodes
                If N1.Name.ToUpper <> "ITEM" Then Continue For
                Row = Me.NewRow
                For Each N2 As XmlNode In N1.ChildNodes
                    Select Case N2.Name.ToUpper
                        Case "NAME" : Row("name") = DbText(N2.InnerText) : Exit Select
                        Case "INN" : Row("inn") = DbText(N2.InnerText) : Exit Select
                        Case "DATE" : Row("regDate") = DbDate(N2.InnerText) : Exit Select
                        Case "DOL_ABS"
                            If IsNumeric(N2.InnerText) Then
                                sum = CSng(N2.InnerText)
                                Row("sum") = sum
                                sumAll += sum
                            End If
                            Exit Select
                    End Select
                Next
                Me.Rows.Add(Row)
            Next
            If sumAll > 0 Then
                For Each Row In Me.Rows
                    Row("percent") = 100 * CSng(Row("sum")) / sumAll
                Next
            End If
        End Sub

    End Class

#End Region
#Region "Таблица дополнительных видов деятельности компании"

    ''' <summary>
    ''' Таблица дополнительных видов деятельности компании
    ''' </summary>
    Public Class OkvedDataTable : Inherits DataTable


        Friend Sub New()
            MyBase.New("OkvedTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("code", GetType(String))               ' Код
                .Add("name", GetType(String))               ' Наименование
            End With
            With Me.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub


        ''' <summary>
        ''' Загрузить данные из xml-документа
        ''' </summary>
        ''' <param name="Doc">Документ с карточкой компании</param>
        Public Sub LoadXmlData(Doc As XmlDocument)
            Me.Rows.Clear()
            Dim N As XmlNode = GetDocumentNode(Doc, "response/body/docs/item/СвОКВЭДДоп")
            If N Is Nothing Then Exit Sub
            Dim Row As DataRow = Nothing
            For Each N1 As XmlNode In N.ChildNodes
                If N1.Name.ToUpper <> "ITEM" Then Continue For
                Row = Me.NewRow
                For Each N2 As XmlNode In N1.ChildNodes
                    Select Case N2.Name.ToUpper
                        Case "КОДОКВЭД" : Row("code") = DbText(N2.InnerText) : Exit Select
                        Case "НАИМОКВЭД" : Row("name") = DbText(N2.InnerText) : Exit Select
                    End Select
                Next
                Me.Rows.Add(Row)
            Next
        End Sub

    End Class

#End Region

    ''' <summary>
    ''' Таблица руководителей компании
    ''' </summary>
    Public LeaderTable As LeaderDataTable = Nothing

    ''' <summary>
    ''' Таблица учредителей компании
    ''' </summary>
    Public FounderTable As FounderDataTable = Nothing

    ''' <summary>
    ''' Таблица дополнительных видов деятельности компании
    ''' </summary>
    Public OkvedTable As OkvedDataTable = Nothing

    ''' <summary>
    ''' Клиент для выполнения http-запросов
    ''' </summary>
    Private WebClient As System.Net.WebClient = Nothing

    ''' <summary>
    ''' Шаблон запроса поиска данных по ИНН фирмы
    ''' </summary>
    Private Const INN_FIND_TEMPATE As String = "https://zachestnyibiznesapi.ru/paid/data/card?id={0}&api_key=GIP0mH_QzZUa60zCIOO90sX95ggTCHh-&_format=xml"


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="WebClient">Клиент для выполнения http-запросов</param>
    Public Sub New(WebClient As System.Net.WebClient)
        MyBase.New()
        Me.WebClient = WebClient
        If Me.WebClient Is Nothing Then Me.WebClient = New System.Net.WebClient
        LeaderTable = New LeaderDataTable
        FounderTable = New FounderDataTable
        OkvedTable = New OkvedDataTable
    End Sub


    ''' <summary>
    ''' Загрузить данные по ИНН компании
    ''' </summary>
    ''' <param name="inn">ИНН компании</param>
    Public Sub LoadByInn(inn As String)
        inn = ToText(inn)
        If String.IsNullOrWhiteSpace(inn) Then Exit Sub
        With My.Computer.FileSystem
            'If .FileExists(String.Format("d:\{0}_card.xml", inn)) Then
            '    Me.Load(String.Format("d:\{0}_card.xml", inn))
            'Else
            Dim tmpPath As String = .GetTempFileName
            .WriteAllBytes(tmpPath, WebClient.DownloadData(INN_FIND_TEMPATE.Replace("{0}", inn)), False)
            Me.Load(tmpPath)
            '.CopyFile(tmpPath, String.Format("d:\{0}_card.xml", inn), True)
            '.DeleteFile(tmpPath)
            'End If
        End With
        LeaderTable.LoadXmlData(Me)
        FounderTable.LoadXmlData(Me)
        OkvedTable.LoadXmlData(Me)
    End Sub


    Public Overrides Sub LoadXml(xml As String)
        MyBase.LoadXml(xml)
        LeaderTable.LoadXmlData(Me)
        FounderTable.LoadXmlData(Me)
        OkvedTable.LoadXmlData(Me)
    End Sub


    ''' <summary>
    ''' Полное наименование компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property NameLong As String
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/НаимЮЛПолн")
            If N Is Nothing OrElse Not IsText(N.InnerText) Then Return Nothing
            Return ToText(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' Краткое наименование компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property NameShort As String
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/НаимЮЛСокр")
            If N Is Nothing OrElse Not IsText(N.InnerText) Then Return Nothing
            Return ToText(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' ИНН компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property INN As String
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/ИНН")
            If N Is Nothing OrElse Not IsText(N.InnerText) Then Return Nothing
            Return ToText(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' КПП компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property Kpp As String
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/КПП")
            If N Is Nothing OrElse Not IsText(N.InnerText) Then Return Nothing
            Return ToText(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' ОГРН компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property Ogrn As String
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/ОГРН")
            If N Is Nothing OrElse Not IsText(N.InnerText) Then Return Nothing
            Return ToText(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' Дата регистрации ОГРН компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property OgrnDate() As Date
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/ДатаОГРН")
            If N Is Nothing OrElse Not IsDate(N.InnerText) Then Return Nothing
            Return CDate(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' Юридический адрес компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property AddressLegal As String
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/Адрес")
            If N Is Nothing OrElse Not IsText(N.InnerText) Then Return Nothing
            Return ToText(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' Город юридического адреса компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property AddressLegalTown As String
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/НаимНаселПункт")
            If Not N Is Nothing AndAlso IsText(N.InnerText) Then Return ToText(N.InnerText)
            N = GetDocumentNode(Me, "response/body/docs/item/НаимГород")
            If Not N Is Nothing AndAlso IsText(N.InnerText) Then Return ToText(N.InnerText)
            N = GetDocumentNode(Me, "response/body/docs/item/НаимРегион")
            If Not N Is Nothing AndAlso IsText(N.InnerText) Then Return ToText(N.InnerText)
            Return Nothing
        End Get
    End Property

    ''' <summary>
    ''' Дата получения юридического адреса компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property AddressLegalDate() As Date
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/ДатаАдресРФ")
            If N Is Nothing OrElse Not IsDate(N.InnerText) Then Return Nothing
            Return CDate(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' Численность работников компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property WorkerCount As Integer
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/ЧислСотруд")
            If N Is Nothing OrElse Not IsNumeric(N.InnerText) Then Return Nothing
            Return CInt(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' Код основного вида деятельности компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property OkvedCode As String
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/КодОКВЭД")
            If N Is Nothing OrElse Not IsText(N.InnerText) Then Return Nothing
            Return ToText(N.InnerText)
        End Get
    End Property

    ''' <summary>
    ''' Наименование основного вида деятельности компании
    ''' </summary>
    ''' <remarks>Если ничего не найдено возвращает Nothing</remarks>
    Public ReadOnly Property OkvedName As String
        Get
            Dim N As XmlNode = GetDocumentNode(Me, "response/body/docs/item/НаимОКВЭД")
            If N Is Nothing OrElse Not IsText(N.InnerText) Then Return Nothing
            Return ToText(N.InnerText)
        End Get
    End Property

End Class
