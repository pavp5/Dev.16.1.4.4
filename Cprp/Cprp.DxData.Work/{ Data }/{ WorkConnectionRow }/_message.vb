Imports C2 = Cprp.DxData.Common
' ====================
' XML-сообщения работы
' ====================
Partial Public Class WorkConnectionRow

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


    ''' <summary>
    ''' Создать сообщение о новой работе для ЭО
    ''' </summary>
    Public Sub MessageWorkNewEo()
        If Me.IsEmpty Then Exit Sub
        Dim envelopeId As String = System.Guid.NewGuid.ToString
        Dim preparationDateTime As Date = Date.Now
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
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
                .WriteElementString("MessageType", "WorkNew")
                .WriteElementString("SenderInformation", EX_EXPERT)
                .WriteElementString("PreparationDateTime", preparationDateTime.ToString("o"))
                .WriteEndElement()
                '
                ' Body
                '
                .WriteStartElement("Body")
                '
                ' WorkBatch
                '
                .WriteStartElement("WorkBatch")
                .WriteAttributeString("xmlns", "urn:excont.ru:Information:ExcontEvent:WorkInf:1.0.0")
                '
                ' Work
                '
                .WriteStartElement("Work")
                .WriteElementString("UniversalWorkId", Me("guid").ToString)
                .WriteElementString("EsWorkId", Me("id").ToString)
                sTmp = C2.ToText(Me("createDate"))
                If C2.IsText(sTmp) Then .WriteElementString("WorkDate", CDate(sTmp).ToString("o"))
                sTmp = C2.ToText(Me("taskUrl"))
                If C2.IsText(sTmp) Then .WriteElementString("EoWorkUrl", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("orderId"))
                If C2.IsText(sTmp) Then .WriteElementString("EoOrderId", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("CrmOrderId"))
                If C2.IsText(sTmp) Then .WriteElementString("CrmOrderId", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("orderNum"))
                If C2.IsText(sTmp) Then .WriteElementString("EoOrderTitle", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("orderDate"))
                If C2.IsText(sTmp) Then .WriteElementString("EoOrderDate", CDate(sTmp).ToString("o"))
                sTmp = C2.ToText(Me("orderUrl"))
                If C2.IsText(sTmp) Then .WriteElementString("EoOrderUrl", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("typeId"))
                If C2.IsText(sTmp) Then
                    If sTmp = "117" Then sTmp = "17"
                    .WriteElementString("ServiceId", C2.ToXML(sTmp))
                End If
                ' !!! <ServiceQuantity>, <ServicePrice>, <ExtraService>
                sTmp = C2.ToText(Me("conditionId"))
                If C2.IsText(sTmp) Then .WriteElementString("ConditionId", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientName"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentName", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientInn"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentInn", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientKpp"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentKpp", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientAddress"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentAddress", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientPhone"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentPhone", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientFax"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentFax", C2.ToXML(sTmp))
                Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT login FROM tUser WHERE id = {0}", C2.ToInt(Me("expertId"))))
                    If Dr.Read Then .WriteElementString("Expert", String.Format("EXCONT\{0}", Dr(0).ToString))
                End Using
                Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT login FROM tUser WHERE id = {0}", C2.ToInt(Me("managerId"))))
                    If Dr.Read Then .WriteElementString("Manager", String.Format("EXCONT\{0}", Dr(0).ToString))
                End Using
                sTmp = C2.ToText(Me("expertTerm"))
                If C2.IsText(sTmp) Then .WriteElementString("WorkDueDate", CDate(sTmp).ToString("o"))
                iTmp = 0
                If Not IsDBNull(Me("extraWork")) Then iTmp += CInt(Me("extraWork"))
                If Not IsDBNull(Me("totalWork")) Then iTmp += CInt(Me("totalWork"))
                If iTmp > 0 Then .WriteElementString("WorkMinutes", iTmp.ToString)
                .WriteElementString("IsPaid", If(CBool(Me("isPayment")), "1", "0"))
                .WriteElementString("IsSigned", If(CBool(Me("isPrice")), "1", "0"))
                sTmp = C2.ToText(Me("comment"))
                If C2.IsText(sTmp) Then .WriteElementString("Comment", C2.ToXML(sTmp))
                Select Case CType(Me("urgencyId"), UrgencyType)
                    Case UrgencyType.IsElevated : sTmp = "Ускоренная"
                    Case UrgencyType.IsHigh : sTmp = "Срочная"
                    Case Else : sTmp = "Стандартная"
                End Select
                .WriteElementString("Urgency", sTmp)
                .WriteElementString("PostalDelivery", If(CBool(Me("isPostal")), "1", "0"))
                .WriteElementString("ManualDocumentReview", If(CBool(Me("isManualDocument")), "1", "0"))

                .WriteEndElement()  ' /Work
                .WriteEndElement()  ' /WorkBatch
                .WriteEndElement()  ' /Body
                .WriteEndElement()  ' /Envelope
                .WriteEndDocument()
                .Close()
            End With

            sTmp = System.Text.Encoding.UTF8.GetString(M.ToArray)
            If sTmp Like "?*" Then sTmp = sTmp.Substring(1)
        End Using

        Using T As New MessageDataTable(Me.Connection)
            Dim Row As DataRow = T.NewRow
            Row("envelopeId") = envelopeId
            Row("messageType") = "WorkNew"
            Row("senderInformation") = EX_EXPERT
            Row("recipientInformation") = EX_EOCPRP
            Row("preparationDateTime") = preparationDateTime
            Row("message") = sTmp
            Row("isExecuted") = False
            T.Rows.Add(Row)
            T.SaveToBase()
        End Using

    End Sub

    ''' <summary>
    ''' Создать сообщение об изменении параметров работы для ЭО
    ''' </summary>
    Public Sub MessageWorkChangeEo()
        If Me.IsEmpty Then Exit Sub
        Dim envelopeId As String = System.Guid.NewGuid.ToString
        Dim preparationDateTime As Date = Date.Now
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
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
                .WriteElementString("UniversalWorkId", Me("guid").ToString)
                .WriteElementString("EsWorkId", Me("id").ToString)
                sTmp = C2.ToText(Me("createDate"))
                If C2.IsText(sTmp) Then .WriteElementString("WorkDate", CDate(sTmp).ToString("o"))
                sTmp = C2.ToText(Me("taskUrl"))
                If C2.IsText(sTmp) Then .WriteElementString("EoWorkUrl", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("orderId"))
                If C2.IsText(sTmp) Then .WriteElementString("EoOrderId", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("CrmOrderId"))
                If C2.IsText(sTmp) Then .WriteElementString("CrmOrderId", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("orderNum"))
                If C2.IsText(sTmp) Then .WriteElementString("EoOrderTitle", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("orderDate"))
                If C2.IsText(sTmp) Then .WriteElementString("EoOrderDate", CDate(sTmp).ToString("o"))
                sTmp = C2.ToText(Me("orderUrl"))
                If C2.IsText(sTmp) Then .WriteElementString("EoOrderUrl", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("typeId"))
                If C2.IsText(sTmp) Then
                    If sTmp = "117" Then sTmp = "17"
                    .WriteElementString("ServiceId", C2.ToXML(sTmp))
                End If
                sTmp = C2.ToText(Me("conditionId"))
                If C2.IsText(sTmp) Then .WriteElementString("ConditionId", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientName"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentName", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientInn"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentInn", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientKpp"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentKpp", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientAddress"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentAddress", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientPhone"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentPhone", C2.ToXML(sTmp))
                sTmp = C2.ToText(Me("clientFax"))
                If C2.IsText(sTmp) Then .WriteElementString("ContragentFax", C2.ToXML(sTmp))
                Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT login FROM tUser WHERE id = {0}", C2.ToInt(Me("expertId"))))
                    If Dr.Read Then .WriteElementString("Expert", String.Format("EXCONT\{0}", Dr(0).ToString))
                End Using
                Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT login FROM tUser WHERE id = {0}", C2.ToInt(Me("managerId"))))
                    If Dr.Read Then .WriteElementString("Manager", String.Format("EXCONT\{0}", Dr(0).ToString))
                End Using
                sTmp = C2.ToText(Me("expertTerm"))
                If C2.IsText(sTmp) Then .WriteElementString("WorkDueDate", CDate(sTmp).ToString("o"))
                sTmp = C2.ToText(Me("orderTerm"))
                If C2.IsText(sTmp) Then .WriteElementString("WorkIssueDate", CDate(sTmp).ToString("o"))
                iTmp = 0
                'If Not IsDBNull(Me("extraWork")) Then iTmp += CInt(Me("extraWork"))
                If Not IsDBNull(Me("totalWork")) Then iTmp += CInt(Me("totalWork"))
                If iTmp > 0 Then .WriteElementString("WorkMinutes", iTmp.ToString)
                .WriteElementString("IsPaid", If(CBool(Me("isPayment")), "1", "0"))
                .WriteElementString("IsSigned", If(CBool(Me("isPrice")), "1", "0"))
                sTmp = C2.ToText(Me("comment"))
                If C2.IsText(sTmp) Then .WriteElementString("Comment", C2.ToXML(sTmp))
                Select Case CType(Me("urgencyId"), UrgencyType)
                    Case UrgencyType.IsElevated : sTmp = "Ускоренная"
                    Case UrgencyType.IsHigh : sTmp = "Срочная"
                    Case Else : sTmp = "Стандартная"
                End Select
                .WriteElementString("Urgency", sTmp)
                .WriteElementString("PostalDelivery", If(CBool(Me("isPostal")), "1", "0"))
                .WriteElementString("ManualDocumentReview", If(CBool(Me("isManualDocument")), "1", "0"))

                .WriteEndElement()  ' /Work
                .WriteEndElement()  ' /Body
                .WriteEndElement()  ' /Envelope
                .WriteEndDocument()
                .Close()
            End With

            sTmp = System.Text.Encoding.UTF8.GetString(M.ToArray)
            If sTmp Like "?*" Then sTmp = sTmp.Substring(1)
        End Using

        Using T As New MessageDataTable(Me.Connection)
            Dim Row As DataRow = T.NewRow
            Row("envelopeId") = envelopeId
            Row("messageType") = "WorkChange"
            Row("senderInformation") = EX_EXPERT
            Row("recipientInformation") = EX_EOCPRP
            Row("preparationDateTime") = preparationDateTime
            Row("message") = sTmp
            Row("isExecuted") = False
            T.Rows.Add(Row)
            T.SaveToBase()
        End Using

    End Sub

    ' ''' <summary>
    ' ''' Создать сообщение о новом расчете стостимости работы для ЭО
    ' ''' </summary>
    'Public Sub MessageWorkBillingNew()
    '    If Me.IsEmpty Then Exit Sub
    '    Dim envelopeId As String = System.Guid.NewGuid.ToString
    '    Dim preparationDateTime As Date = Date.Now
    '    Dim sTmp As String = Nothing
    '    Dim iTmp As Integer = 0
    '    Using M As New IO.MemoryStream
    '        With New Xml.XmlTextWriter(M, System.Text.Encoding.UTF8)
    '            .Formatting = Xml.Formatting.Indented
    '            .IndentChar = " "

    '            .WriteStartDocument()
    '            '
    '            ' Envelope
    '            '
    '            .WriteStartElement("Envelope")
    '            .WriteAttributeString("xmlns", "http://www.w3.org/2001/06/soap-envelope")
    '            '
    '            ' Header
    '            '
    '            .WriteStartElement("Header")
    '            .WriteElementString("EnvelopeId", envelopeId)
    '            .WriteElementString("MessageType", "WorkBillingNew")
    '            .WriteElementString("SenderInformation", EX_EXPERT)
    '            .WriteElementString("PreparationDateTime", preparationDateTime.ToString("o"))
    '            .WriteEndElement()
    '            '
    '            ' Body
    '            '
    '            .WriteStartElement("Body")
    '            '
    '            ' WorkBillingBatch
    '            '
    '            .WriteStartElement("WorkBillingBatch")
    '            .WriteAttributeString("xmlns", "urn:excont.ru:Information:ExcontEvent:WorkInf:1.0.0")

    '            Using V As New DataView(Me.CalcTable) With {.Sort = "id"}
    '                For i As Integer = 0 To V.Count - 1
    '                    '
    '                    ' WorkBilling
    '                    '
    '                    .WriteStartElement("WorkBilling")
    '                    .WriteElementString("UniversalWorkId", Me("guid").ToString)
    '                    .WriteElementString("ServiceId", C2.ToText(V(i)("serviceId")))
    '                    .WriteElementString("ServiceQuantity", CInt(V(i)("serviceCount")))
    '                    .WriteElementString("ServicePrice", C2.ToText(V(i)("onePrice")).Replace(",", "."))
    '                    .WriteEndElement()
    '                Next
    '            End Using

    '            .WriteEndElement()  ' /WorkBillingBatch
    '            .WriteEndElement()  ' /Body
    '            .WriteEndElement()  ' /Envelope
    '            .WriteEndDocument()
    '            .Close()
    '        End With

    '        sTmp = System.Text.Encoding.UTF8.GetString(M.ToArray)
    '        If sTmp Like "?*" Then sTmp = sTmp.Substring(1)
    '    End Using

    '    'Using Cn As New SqlConnection("Server=192.168.22.80;Database=EXDB8Test;Trusted_connection=Yes")
    '    '    Cn.Open()
    '    '    Using T As New MessageDataTable(Cn)
    '    Using T As New MessageDataTable(Me.Connection)
    '        Dim Row As DataRow = T.NewRow
    '        Row("envelopeId") = envelopeId
    '        Row("messageType") = "WorkBillingNew"
    '        Row("senderInformation") = EX_EXPERT
    '        Row("recipientInformation") = EX_EOCPRP
    '        Row("preparationDateTime") = preparationDateTime
    '        Row("message") = sTmp
    '        Row("isExecuted") = False
    '        T.Rows.Add(Row)
    '        T.SaveToBase()
    '    End Using
    '    'End Using

    'End Sub

    ''' <summary>
    ''' Создать сообщение о новом исходящем документе по работе для ЭО
    ''' </summary>
    ''' <param name="regNum">Регистрационный номер документа</param>
    ''' <param name="regDate">Дата регистрации документа</param>
    ''' <param name="approver">Доменное имя автора (подписанта) документа</param>
    ''' <param name="fileUrl">URLы файлов документа, разделенные C2.FIELD_SEPARATOR</param>
    ''' <param name="typeId">Тип документа (0 - неизвестный, 1 - заключение, 2 - план, 3 - запрос, 4 - письмо, 5 - внутренний документ по работе)</param>
    ''' <param name="contractCaption">Наименование документа-основания внешнеэкономической операции</param>
    ''' <param name="summaryId">Идентификатор выводов экспертизы</param>
    ''' <param name="askDate">Срок ответа на запрос для документов-запросов</param>
    ''' <param name="kindId">Вид документа (1 - входящий, 2 - исходящий, 3 - внутренний)</param>
    Public Sub MessageOutputDocumentNewEo(regNum As String, regDate As Date, approver As String, fileUrl As String, _
                                          typeId As Integer, Optional contractCaption As String = Nothing, _
                                          Optional askDate As Date = Nothing, Optional summaryId As Integer = C2.EMPTY_ID, _
                                          Optional kindId As Integer = 1)
        If Me.IsEmpty Then Exit Sub
        Dim envelopeId As String = System.Guid.NewGuid.ToString
        Dim preparationDateTime As Date = Date.Now
        ' Уточнение вида документа в зависимости от типа
        Select Case typeId
            Case 1, 3, 4 : kindId = 2
            Case 2, 5 : kindId = 3
        End Select
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Dim arr() As String = Nothing
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
                .WriteElementString("MessageType", "WorkOutputDocumentNew")
                .WriteElementString("SenderInformation", EX_EXPERT)
                .WriteElementString("PreparationDateTime", preparationDateTime.ToString("o"))
                .WriteEndElement()
                '
                ' Body
                '
                .WriteStartElement("Body")
                '
                ' WorkOutputDocument
                '
                .WriteStartElement("WorkOutputDocument")
                .WriteAttributeString("xmlns", "urn:excont.ru:Information:ExcontEvent:WorkDocumentData:1.0.0")
                .WriteElementString("UniversalWorkId", Me("guid").ToString)
                .WriteElementString("EsWorkId", Me("id").ToString)
                .WriteElementString("DocumentKindId", kindId)
                .WriteElementString("DocumentTypeId", typeId)
                If C2.IsText(regNum) Then .WriteElementString("RegNum", C2.ToXML(regNum))
                If regDate <> Nothing Then .WriteElementString("RegDate", regDate.ToString("o"))
                If C2.IsText(approver) Then .WriteElementString("Approver", C2.ToXML(approver))
                If C2.IsText(contractCaption) Then
                    If contractCaption.Length > 255 Then contractCaption = contractCaption.Substring(0, 255)
                    .WriteElementString("VESContract", contractCaption)
                End If
                If askDate <> Nothing Then .WriteElementString("InfoRequestResponseDueDate", askDate.ToString("o"))
                If C2.IsText(fileUrl) Then
                    arr = C2.ToText(fileUrl).Split(New Char() {C2.FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
                    For Each sTmp In arr
                        .WriteElementString("FileUrl", C2.ToXML(sTmp))
                    Next
                End If
                '
                ' Мероприятия по работе для плана работы по новой схеме обмена
                '
                If typeId = 2 Then
                    For Each Row As DataRow In Me.CalcTable.Rows
                        .WriteStartElement("Service")
                        .WriteElementString("Name", C2.ToText(Row("serviceName")))
                        .WriteElementString("Price", C2.ToText(Row("price")))
                        If IsDBNull(Row("expertTerm")) Then
                            .WriteElementString("IssueDate", Nothing)
                        Else
                            .WriteElementString("IssueDate", CDate(Row("expertTerm")).ToString("o"))
                        End If
                        .WriteElementString("Comment", C2.ToText(Row("description")))
                        .WriteEndElement()
                    Next
                End If

                If summaryId > 0 Then .WriteElementString("SummaryId", summaryId)
                .WriteEndElement()  ' /WorkOutputDocument
                .WriteEndElement()  ' /Body
                .WriteEndElement()  ' /Envelope
                .WriteEndDocument()
                .Close()
            End With

            sTmp = System.Text.Encoding.UTF8.GetString(M.ToArray)
            If sTmp Like "?*" Then sTmp = sTmp.Substring(1)
        End Using

        Using T As New MessageDataTable(Me.Connection)
            Dim Row As DataRow = T.NewRow
            Row("envelopeId") = envelopeId
            Row("messageType") = "WorkOutputDocumentNew"
            Row("senderInformation") = EX_EXPERT
            Row("recipientInformation") = EX_EOCPRP
            Row("preparationDateTime") = preparationDateTime
            Row("message") = sTmp
            ' Заключение экспертизы
            If typeId = 1 Then
                Row("workId") = Me("id")
                Row("sendDate") = Me("orderTerm")
            End If
            Row("isExecuted") = False
            T.Rows.Add(Row)
            T.SaveToBase()
        End Using

    End Sub

    ''' <summary>
    ''' Создать сообщение об изменении исходящего документа по работе для ЭО
    ''' </summary>
    ''' <param name="regNum">Регистрационный номер документа</param>
    ''' <param name="regDate">Дата регистрации документа</param>
    ''' <param name="approver">Доменное имя автора (подписанта) документа</param>
    ''' <param name="fileUrl">URLы файлов документа, разделенные C2.FIELD_SEPARATOR</param>
    ''' <param name="typeId">Тип документа (0 - неизвестный, 1 - заключение, 2 - план, 3 - запрос)</param>
    ''' <param name="contractCaption">Наименование документа-основания внешнеэкономической операции</param>
    ''' <param name="askDate">Срок ответа на запрос для документов-запросов</param>
    ''' <param name="summaryId">Идентификатор выводов экспертизы</param>
    ''' <param name="kindId">Вид документа (1 - входящий, 2 - исходящий, 3 - внутренний)</param>
    Public Sub MessageOutputDocumentChangeEo(regNum As String, regDate As Date, approver As String, fileUrl As String, _
                                             typeId As Integer, Optional contractCaption As String = Nothing, _
                                             Optional askDate As Date = Nothing, Optional summaryId As Integer = C2.EMPTY_ID, _
                                             Optional kindId As Integer = 1)
        If Me.IsEmpty Then Exit Sub
        Dim envelopeId As String = System.Guid.NewGuid.ToString
        Dim preparationDateTime As Date = Date.Now
        ' Уточнение вида документа в зависимости от типа
        Select Case typeId
            Case 1, 3 : kindId = 2
            Case 2 : kindId = 3
        End Select
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Dim arr() As String = Nothing
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
                .WriteElementString("MessageType", "WorkOutputDocumentChange")
                .WriteElementString("SenderInformation", EX_EXPERT)
                .WriteElementString("PreparationDateTime", preparationDateTime.ToString("o"))
                .WriteEndElement()
                '
                ' Body
                '
                .WriteStartElement("Body")
                '
                ' WorkOutputDocument
                '
                .WriteStartElement("WorkOutputDocument")
                .WriteAttributeString("xmlns", "urn:excont.ru:Information:ExcontEvent:WorkDocumentData:1.0.0")
                .WriteElementString("UniversalWorkId", Me("guid").ToString)
                .WriteElementString("EsWorkId", Me("id").ToString)
                .WriteElementString("DocumentKindId", kindId)
                .WriteElementString("DocumentTypeId", typeId)
                If C2.IsText(regNum) Then .WriteElementString("RegNum", C2.ToXML(regNum))
                If regDate <> Nothing Then .WriteElementString("RegDate", regDate.ToString("o"))
                If C2.IsText(approver) Then .WriteElementString("Approver", C2.ToXML(approver))
                If C2.IsText(contractCaption) Then
                    If contractCaption.Length > 255 Then contractCaption = contractCaption.Substring(0, 255)
                    .WriteElementString("VESContract", contractCaption)
                End If
                If askDate <> Nothing Then .WriteElementString("InfoRequestResponseDueDate", askDate.ToString("o"))
                If C2.IsText(fileUrl) Then
                    arr = C2.ToText(fileUrl).Split(New Char() {C2.FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
                    For Each sTmp In arr
                        .WriteElementString("FileUrl", C2.ToXML(sTmp))
                    Next
                End If
                If summaryId > 0 Then .WriteElementString("SummaryId", summaryId)
                '
                ' Мероприятия по работе для плана работы по новой схеме обмена
                '
                If typeId = 2 Then
                    For Each Row As DataRow In Me.CalcTable.Rows
                        .WriteStartElement("Service")
                        .WriteElementString("Name", C2.ToText(Row("serviceName")))
                        .WriteElementString("Price", C2.ToText(Row("price")))
                        'If IsDBNull(Row("expertTerm")) Then
                        '    .WriteElementString("IssueDate", Nothing)
                        'Else
                        '    .WriteElementString("IssueDate", CDate(Row("expertTerm")).ToString("o"))
                        'End If
                        If Not IsDBNull(Row("expertTerm")) Then
                            .WriteElementString("IssueDate", CDate(Row("expertTerm")).ToString("o"))
                        End If
                        .WriteElementString("Comment", C2.ToText(Row("description")))
                        .WriteEndElement()
                    Next
                End If

                .WriteEndElement()  ' /WorkOutputDocument
                .WriteEndElement()  ' /Body
                .WriteEndElement()  ' /Envelope
                .WriteEndDocument()
                .Close()
            End With

            sTmp = System.Text.Encoding.UTF8.GetString(M.ToArray)
            If sTmp Like "?*" Then sTmp = sTmp.Substring(1)
        End Using

        Using T As New MessageDataTable(Me.Connection)
            Dim Row As DataRow = T.NewRow
            Row("envelopeId") = envelopeId
            Row("messageType") = "WorkOutputDocumentChange"
            Row("senderInformation") = EX_EXPERT
            Row("recipientInformation") = EX_EOCPRP
            Row("preparationDateTime") = preparationDateTime
            Row("message") = sTmp
            ' Заключение экспертизы
            If typeId = 1 Then
                Row("workId") = Me("id")
                Row("sendDate") = Me("orderTerm")
            End If
            Row("isExecuted") = False
            T.Rows.Add(Row)
            '
            ' Проверка наличия заявки на внесение изменений по работе
            '
            Dim id As Integer = C2.EMPTY_ID ' id заявки
            Dim guid As String = Nothing    ' guid заявки
            Using Dr As SqlDataReader = Me.ExecuteReader( _
                String.Format("SELECT id, guid FROM tWork WHERE parentId = {0} AND typeId = {1}", _
                              CInt(Me.Id), CInt(WorkType.IsAlteration)))
                If Dr.Read Then
                    id = CInt(Dr("id"))
                    guid = Dr("guid").ToString
                End If
                Dr.Close()
            End Using
            If id > 0 Then
                Dim newEnvelopeId As String = System.Guid.NewGuid.ToString
                sTmp = sTmp.Replace(envelopeId, newEnvelopeId)
                sTmp = sTmp.Replace("WorkOutputDocumentChange", "WorkOutputDocumentNew")
                sTmp = sTmp.Replace(String.Format("<EsWorkId>{0}", Me("id").ToString), String.Format("<EsWorkId>{0}", id.ToString))
                sTmp = sTmp.Replace(String.Format("<UniversalWorkId>{0}", Me("guid").ToString), String.Format("<UniversalWorkId>{0}", guid))
                Row = T.NewRow
                Row("envelopeId") = newEnvelopeId
                Row("messageType") = "WorkOutputDocumentNew"
                Row("senderInformation") = EX_EXPERT
                Row("recipientInformation") = EX_EOCPRP
                Row("preparationDateTime") = preparationDateTime
                Row("message") = sTmp
                ' Заключение экспертизы
                If typeId = 1 Then
                    Row("workId") = Me("id")
                    Row("sendDate") = Me("orderTerm")
                End If
                Row("isExecuted") = False
                T.Rows.Add(Row)
            End If
            T.SaveToBase()
        End Using

    End Sub

    ''' <summary>
    ''' Создать сообщение об изменении входящего документа для ЭО
    ''' </summary>
    ''' <param name="docEoId">ID входящего документа в ЭО</param>
    Public Sub MessageInputDocumentChangeEo(docEoId As Integer)
        If Me.IsEmpty Then Exit Sub
        Dim envelopeId As String = System.Guid.NewGuid.ToString
        Dim preparationDateTime As Date = Date.Now
        Dim sTmp As String = Nothing
        Using V As New DataView(Me.InDocTable) With {.RowFilter = String.Format("eoId = {0}", docEoId)}
            If V.Count = 0 Then Exit Sub
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
                    .WriteElementString("MessageType", "WorkInputDocumentChange")
                    .WriteElementString("SenderInformation", EX_EXPERT)
                    .WriteElementString("PreparationDateTime", preparationDateTime.ToString("o"))
                    .WriteEndElement()
                    '
                    ' Body
                    '
                    .WriteStartElement("Body")
                    '
                    ' WorkInputDocument
                    '
                    .WriteStartElement("WorkInputDocument")
                    .WriteAttributeString("xmlns", "urn:excont.ru:Information:ExcontEvent:WorkDocumentData:1.0.0")
                    .WriteElementString("EoDocumentId", V(0)("eoId").ToString)
                    If C2.IsText(V(0)("docUrl")) Then .WriteElementString("EoDocumentUrl", V(0)("docUrl").ToString)
                    If C2.IsText(V(0)("orderId")) Then .WriteElementString("EoOrderId", V(0)("orderId").ToString)
                    If C2.IsText(V(0)("caption")) Then .WriteElementString("Description", V(0)("caption").ToString)
                    If C2.IsText(V(0)("regNum")) Then .WriteElementString("ContragentRegNum", V(0)("regNum").ToString)
                    If Not IsDBNull(V(0)("regDate")) Then
                        .WriteElementString("ContragentRegDate", CDate(V(0)("regDate")).ToString("o"))
                    End If
                    .WriteEndElement()  ' /WorkInputDocument
                    .WriteEndElement()  ' /Body
                    .WriteEndElement()  ' /Envelope
                    .WriteEndDocument()
                    .Close()
                End With

                sTmp = System.Text.Encoding.UTF8.GetString(M.ToArray)
                If sTmp Like "?*" Then sTmp = sTmp.Substring(1)
            End Using
        End Using

        Using T As New MessageDataTable(Me.Connection)
            Dim Row As DataRow = T.NewRow
            Row("envelopeId") = envelopeId
            Row("messageType") = "WorkInputDocumentChange"
            Row("senderInformation") = EX_EXPERT
            Row("recipientInformation") = EX_EOCPRP
            Row("preparationDateTime") = preparationDateTime
            Row("message") = sTmp
            Row("isExecuted") = False
            T.Rows.Add(Row)
            T.SaveToBase()
        End Using

    End Sub

End Class
