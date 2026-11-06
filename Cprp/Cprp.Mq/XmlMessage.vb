Imports System.Xml
Imports System.Data.SqlClient
Imports C2 = Cprp.DxData.Common
''' <summary>
''' Xml-сообщения для обмена данными
''' </summary>
Public Class XmlMessage

    Private Connection As SqlConnection = Nothing
    Private Command As SqlCommand = Nothing

    Private Settings As XmlWriterSettings = Nothing
    Private StrBuilder As Text.StringBuilder = Nothing

    Private Const ENVELOPE_XMLNS As String = "http://www.w3.org/2001/06/soap-envelope"

    Private Class UTF8StringWriter : Inherits IO.StringWriter
        Public Sub New()
            MyBase.New()
        End Sub
        Public Overrides ReadOnly Property Encoding As System.Text.Encoding
            Get

                Return System.Text.Encoding.UTF8
            End Get
        End Property
    End Class

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(Connection As SqlConnection)
        If Connection Is Nothing Then Exit Sub
        If Connection.State <> ConnectionState.Open Then Connection.Open()
        Me.Connection = Connection
        Command = New SqlCommand With {.Connection = Me.Connection}
        Settings = New XmlWriterSettings
        With Settings
            .Encoding = Text.Encoding.UTF8
            .Indent = True
            .CloseOutput = True
        End With
        StrBuilder = New Text.StringBuilder
    End Sub

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="connectionString">Строка подключения к базе данных</param>
    Public Sub New(connectionString As String)
        MyClass.New(New SqlConnection(connectionString))
    End Sub


    ''' <summary>
    ''' Возвращает результат обработки сообщения
    ''' </summary>
    ''' <param name="ResultTable">Таблица результатов обработки сообщения</param>
    ''' <param name="InitialEnvelopeId">Идентификатор входящего сообщения</param>
    Public Function GetResault(ResultTable As ResultDataTable, InitialEnvelopeId As Guid) As String
        Dim xmlDoc As String = Nothing
        Using S As New UTF8StringWriter
            Using W As XmlWriter = XmlWriter.Create(S, Settings)
                W.WriteStartDocument()
                '
                ' <Envelope>
                '
                W.WriteStartElement("Envelope")
                '
                ' <Header />
                '
                W.WriteStartElement("Header", ENVELOPE_XMLNS)
                W.WriteElementString("EnvelopeId", Guid.NewGuid.ToString)
                If InitialEnvelopeId <> Guid.Empty Then W.WriteElementString("InitialEnvelopeId", InitialEnvelopeId.ToString)
                W.WriteElementString("MessageType", "Result")
                W.WriteElementString("SenderInformation", "EX_ES")
                W.WriteElementString("PreparationDateTime", Date.Now.ToString("o"))
                W.WriteEndElement()
                '
                ' <Body>
                '
                W.WriteStartElement("Body")
                '
                ' <Result>
                '
                W.WriteStartElement("Result", "urn:excont.ru:Information:ExchangeDocuments:Result:1.0.0")
                '
                ' <Item />
                '
                For i As Integer = 0 To ResultTable.Rows.Count - 1
                    W.WriteStartElement("Item")
                    W.WriteElementString("Code", C2.ToInt(ResultTable(i)("code")))
                    W.WriteElementString("Message", C2.ToText(ResultTable(i)("message")))
                    W.WriteEndElement()
                Next
                '
                ' </Result>
                '
                W.WriteEndElement()
                '
                ' </Body>
                '
                W.WriteEndElement()
                '
                ' </Envelope>
                '
                W.WriteEndElement()

                W.WriteEndDocument()

                W.Flush()
                W.Close()
            End Using

            xmlDoc = S.ToString

        End Using

        Return xmlDoc
    End Function

    ''' <summary>
    ''' Возвращает сообщение о новой работе для передачи в ИСЭК
    ''' </summary>
    ''' <param name="workId">ID работы в ЭС ЦПРП</param> 
    ''' <param name="InitialEnvelopeId">Идентификатор входящего сообщения</param>
    ''' <remarks>Mes047, Doc047</remarks> 
    Public Function GetNewWork(workId As Object, InitialEnvelopeId As Guid) As String
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Return Nothing

        Dim ID As Integer = C2.ToInt(workId)
        Dim userId As Integer = C2.EMPTY_ID
        Dim userEmail As String = Nothing
        Dim caption As String = Nothing

        Command.CommandText = String.Format("SELECT expertId, description AS caption FROM tWork WHERE id = {0}", ID)
        Using Dr As SqlDataReader = Command.ExecuteReader
            If Dr.Read Then
                userId = C2.ToInt(Dr("expertId"))
                caption = C2.ToText(Dr("caption"))
            Else
                Return Nothing
            End If
        End Using
        Command.CommandText = String.Format("SELECT login FROM tUser WHERE id = {0}", userId)
        Using Dr As SqlDataReader = Command.ExecuteReader
            If Dr.Read Then
                userEmail = C2.ToText(Dr("login")) & "@excont.ru"
            Else
                Return Nothing
            End If
        End Using

        Dim xmlDoc As String = Nothing
        Using S As New UTF8StringWriter
            Using W As XmlWriter = XmlWriter.Create(S, Settings)
                W.WriteStartDocument()
                '
                ' <Envelope>
                '
                W.WriteStartElement("Envelope")
                '
                ' <Header />
                '
                W.WriteStartElement("Header", ENVELOPE_XMLNS)
                W.WriteElementString("EnvelopeId", Guid.NewGuid.ToString)
                If InitialEnvelopeId <> Guid.Empty Then W.WriteElementString("InitialEnvelopeId", InitialEnvelopeId.ToString)
                W.WriteElementString("MessageType", "Mes047")
                W.WriteElementString("SenderInformation", "EX_ES")
                W.WriteElementString("PreparationDateTime", Date.Now.ToString("o"))
                W.WriteEndElement()
                '
                ' <Body>
                '
                W.WriteStartElement("Body")
                '
                ' <Doc047 />
                '
                W.WriteStartElement("Doc047", "urn:excont.ru:Information:ExcontEvent:WorkInf:1.0.0")
                W.WriteElementString("email", userEmail)
                W.WriteElementString("userId", userId)
                W.WriteElementString("workId", ID)
                W.WriteElementString("caption", caption)
                W.WriteElementString("workEsId", ID)
                W.WriteEndElement()
                '
                ' </Body>
                '
                W.WriteEndElement()
                '
                ' </Envelope>
                '
                W.WriteEndElement()

                W.WriteEndDocument()

                W.Flush()
                W.Close()
            End Using

            xmlDoc = S.ToString

        End Using

        Return xmlDoc

    End Function

End Class
