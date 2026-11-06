Imports Cprp.DxData.Common
''' <summary>
''' Создание сообщений для MQ
''' </summary>
Public Class Message

    ''' <summary>
    ''' Таблица сообщений
    ''' </summary>
    Private Class MessageDataTable : Inherits Cprp.DxData.Base.ConnectionDataTable

        ''' <summary>
        ''' New
        ''' </summary>
        ''' <param name="Connection">Открытое соединение с базой данных</param>
        Public Sub New(Connection As SqlConnection)
            MyBase.New(Connection)
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("envelopeId", GetType(String))
                .Add("messageType", GetType(String))
                .Add("senderInformation", GetType(String))
                .Add("recipientInformation", GetType(String))
                .Add("preparationDateTime", GetType(Date))
                .Add("message", GetType(String))
                .Add("comment", GetType(String))
                .Add("workId", GetType(Integer))
                .Add("sendDate", GetType(Date))
                .Add("isExecuted", GetType(Boolean))
            End With
            With Me.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Me.Columns("envelopeId").MaxLength = 50
            Me.Columns("messageType").MaxLength = 50
            Me.Columns("senderInformation").MaxLength = 50
            Me.Columns("recipientInformation").MaxLength = 50
            Me.Columns("comment").MaxLength = 250
            With Me.Columns("isExecuted")
                .AllowDBNull = False
                .DefaultValue = False
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub


        ''' <summary>
        ''' Сохранить данные в базу
        ''' </summary>
        Public Sub SaveToBase()
            Using A As New SqlDataAdapter("SELECT id, envelopeId, messageType, senderInformation, recipientInformation, preparationDateTime, message, comment, workId, sendDate, isExecuted FROM tMessage", Me.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(Me)
            End Using
        End Sub

    End Class


    ''' <summary>
    ''' Имя очереди входящих сообщений ЭС
    ''' </summary>
    Private Const EX_EXPERT As String = "EX_EXPERT"

    ''' <summary>
    ''' Имя очереди входящих сообщений ЭО
    ''' </summary>
    Private Const EX_EOCPRP As String = "EX_EOCPRP"
    'Private Const EX_EOCPRP As String = "EX_EOCPRP-ES-TEST"

    ''' <summary>
    ''' Имя очереди входящих сообщений сайта
    ''' </summary>
    Private Const EX_SITE As String = "EX_SITE"

    Private Sub New()
        Exit Sub
    End Sub


    ''' <summary>
    ''' Создать сообщение об изменении работы и сохранить в таблицу tMessage
    ''' </summary>
    ''' <param name="id">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Shared Sub WorkChange(id As Object, Connection As SqlConnection)
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Sub
        Dim workId As Integer = ToInt(id)
        If workId < 1 Then Exit Sub
        Dim workGuid As String = Nothing
        Dim typeId As Integer = EMPTY_ID
        Dim conditionId As Integer = EMPTY_ID
        Dim createDate As Date = Nothing
        Dim taskUrl As String = Nothing
        Dim orderId As Integer = EMPTY_ID
        Dim crmOrderId As String = Nothing
        Dim orderNum As String = Nothing
        Dim orderDate As Date = Nothing
        Dim orderUrl As String = Nothing
        Dim clientName As String = Nothing
        Dim clientInn As String = Nothing
        Dim clientKpp As String = Nothing
        Dim clientAddress As String = Nothing
        Dim clientPhone As String = Nothing
        Dim clientFax As String = Nothing
        Dim expertId As Integer = EMPTY_ID
        Dim expertLogin As String = Nothing
        Dim managerId As Integer = EMPTY_ID
        Dim managerLogin As String = Nothing
        Dim urgency As UrgencyType = UrgencyType.IsNone
        Dim expertTerm As Date = Nothing
        Dim orderTerm As Date = Nothing
        Dim totalWork As Integer = EMPTY_ID
        Dim isPayment As Boolean = False
        Dim isPrice As Boolean = False
        Dim isPostal As Boolean = False
        Dim isManualDocument As Boolean = False
        Dim comment As String = Nothing

        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT * FROM tWork WHERE id = {0}", workId.ToString)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    workGuid = ToText(Dr("guid"))
                    typeId = ToInt(Dr("typeId"))
                    conditionId = ToInt(Dr("conditionId"))
                    createDate = ToDate(Dr("createDate"))
                    taskUrl = ToText(Dr("taskUrl"))
                    orderId = ToInt(Dr("orderId"))
                    crmOrderId = ToText(Dr("CrmOrderId"))
                    orderNum = ToText(Dr("orderNum"))
                    orderDate = ToDate(Dr("orderDate"))
                    orderUrl = ToText(Dr("orderUrl"))
                    clientName = ToText(Dr("clientName"))
                    clientInn = ToText(Dr("clientInn"))
                    clientKpp = ToText(Dr("clientKpp"))
                    clientAddress = ToText(Dr("clientAddress"))
                    clientPhone = ToText(Dr("clientPhone"))
                    clientFax = ToText(Dr("clientFax"))
                    expertId = ToInt(Dr("expertId"))
                    managerId = ToInt(Dr("managerId"))
                    urgency = CType(Dr("urgencyId"), UrgencyType)
                    expertTerm = ToDate(Dr("expertTerm"))
                    orderTerm = ToDate(Dr("orderTerm"))
                    totalWork = ToInt(Dr("totalWork"))
                    If Not IsDBNull(Dr("isPayment")) Then isPayment = CBool(Dr("isPayment"))
                    If Not IsDBNull(Dr("isPrice")) Then isPrice = CBool(Dr("isPrice"))
                    If Not IsDBNull(Dr("isPostal")) Then isPostal = CBool(Dr("isPostal"))
                    If Not IsDBNull(Dr("isManualDocument")) Then isManualDocument = CBool(Dr("isManualDocument"))
                    comment = ToText(Dr("comment"))
                Else
                    Dr.Close()
                    Exit Sub
                End If
            End Using
            If expertId > 0 Then
                Cmd.CommandText = String.Format("SELECT login FROM tUser WHERE id = {0}", expertId.ToString)
                expertLogin = String.Format("EXCONT\{0}", ToText(Cmd.ExecuteScalar))
            End If
            If managerId > 0 Then
                Cmd.CommandText = String.Format("SELECT login FROM tUser WHERE id = {0}", managerId.ToString)
                managerLogin = String.Format("EXCONT\{0}", ToText(Cmd.ExecuteScalar))
            End If
        End Using
        If typeId = 117 Then typeId = 17

        Dim envelopeId As String = System.Guid.NewGuid.ToString
        Dim preparationDateTime As Date = Date.Now

        Dim mes As String = Nothing

        Using M As New IO.MemoryStream
            With New Xml.XmlTextWriter(M, System.Text.Encoding.UTF8)
                .Formatting = Xml.Formatting.Indented
                .IndentChar = " "

                .WriteStartDocument()
                '
                ' Envelope
                '
                .WriteStartElement("Envelope")
                .WriteAttributeString("xmlns", "http://www.w3.org/2001/06/soap-envelope")
                '
                ' Header
                '
                .WriteStartElement("Header")
                .WriteElementString("EnvelopeId", envelopeId)
                .WriteElementString("MessageType", "WorkChange")
                .WriteElementString("SenderInformation", EX_EXPERT)
                .WriteElementString("PreparationDateTime", preparationDateTime.ToString("o"))
                .WriteEndElement()
                '
                ' Body
                '
                .WriteStartElement("Body")
                '
                ' Work
                '
                .WriteStartElement("Work")
                .WriteAttributeString("xmlns", "urn:excont.ru:Information:ExcontEvent:WorkInf:1.0.0")
                .WriteElementString("UniversalWorkId", workGuid)
                .WriteElementString("EsWorkId", workId.ToString)
                If createDate > Nothing Then .WriteElementString("WorkDate", createDate.ToString("o"))
                If Not String.IsNullOrWhiteSpace(taskUrl) Then .WriteElementString("EoWorkUrl", ToXML(taskUrl))
                If orderId > 0 Then .WriteElementString("EoOrderId", orderId.ToString)
                If Not String.IsNullOrWhiteSpace(crmOrderId) Then .WriteElementString("CrmOrderId", ToXML(crmOrderId))
                If Not String.IsNullOrWhiteSpace(orderNum) Then .WriteElementString("EoOrderTitle", ToXML(orderNum))
                If orderDate > Nothing Then .WriteElementString("EoOrderDate", orderDate.ToString("o"))
                If Not String.IsNullOrWhiteSpace(orderUrl) Then .WriteElementString("EoOrderUrl", ToXML(orderUrl))
                .WriteElementString("ServiceId", typeId.ToString)
                .WriteElementString("ConditionId", conditionId.ToString)
                If Not String.IsNullOrWhiteSpace(clientName) Then .WriteElementString("ContragentName", ToXML(clientName))
                If Not String.IsNullOrWhiteSpace(clientInn) Then .WriteElementString("ContragentInn", ToXML(clientInn))
                If Not String.IsNullOrWhiteSpace(clientKpp) Then .WriteElementString("ContragentKpp", ToXML(clientKpp))
                If Not String.IsNullOrWhiteSpace(clientAddress) Then .WriteElementString("ContragentAddress", ToXML(clientAddress))
                If Not String.IsNullOrWhiteSpace(clientPhone) Then .WriteElementString("ContragentPhone", ToXML(clientPhone))
                If Not String.IsNullOrWhiteSpace(clientFax) Then .WriteElementString("ContragentFax", ToXML(clientFax))
                If Not String.IsNullOrWhiteSpace(expertLogin) Then .WriteElementString("Expert", ToXML(expertLogin))
                If Not String.IsNullOrWhiteSpace(managerLogin) Then .WriteElementString("Manager", ToXML(managerLogin))
                If expertTerm > Nothing Then .WriteElementString("WorkDueDate", expertTerm.ToString("o"))
                If orderTerm > Nothing Then .WriteElementString("WorkIssueDate", orderTerm.ToString("o"))
                If totalWork > 0 Then .WriteElementString("WorkMinutes", totalWork.ToString)
                .WriteElementString("IsPaid", If(isPayment, "1", "0"))
                .WriteElementString("IsSigned", If(isPrice, "1", "0"))
                If Not String.IsNullOrWhiteSpace(comment) Then .WriteElementString("Comment", ToXML(comment))
                Select Case urgency
                    Case UrgencyType.IsElevated : .WriteElementString("Urgency", "Ускоренная")
                    Case UrgencyType.IsHigh : .WriteElementString("Urgency", "Срочная")
                    Case Else : .WriteElementString("Urgency", "Стандартная")
                End Select
                .WriteElementString("PostalDelivery", If(isPostal, "1", "0"))
                .WriteElementString("ManualDocumentReview", If(isManualDocument, "1", "0"))

                .WriteEndElement()  ' /Work
                .WriteEndElement()  ' /Body
                .WriteEndElement()  ' /Envelope
                .WriteEndDocument()
                .Close()
            End With

            mes = System.Text.Encoding.UTF8.GetString(M.ToArray)
            If mes Like "?*" Then mes = mes.Substring(1)
        End Using

        Using T As New MessageDataTable(Connection)
            Dim Row As DataRow = T.NewRow
            Row("envelopeId") = envelopeId
            Row("messageType") = "WorkChange"
            Row("senderInformation") = EX_EXPERT
            Row("recipientInformation") = EX_EOCPRP
            Row("preparationDateTime") = preparationDateTime
            Row("message") = mes
            Row("isExecuted") = False
            T.Rows.Add(Row)
            T.SaveToBase()
        End Using

    End Sub

End Class
