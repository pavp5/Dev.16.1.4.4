Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports C2 = Cprp.DxData.Common
Module Program

    '''<summary> 
    ''' Открытое соединение с базой данных
    ''' </summary>
    Private Connection As SqlConnection = Nothing

    '''<summary> 
    ''' Объект для работы с менеджером очередей
    ''' </summary>
    Private MQ As Cprp.Mq.QueueManager = Nothing

    '''<summary> 
    ''' Объект для анализа входящих xml-сообщений
    ''' </summary>
    Private XmlDocTable As XmlDocumentDataTable = Nothing

    '''<summary> 
    ''' Таблица результатов обработки сообщений
    ''' </summary>
    Private ResultTable As ResultDataTable = Nothing

    '''<summary> 
    ''' Таймер чтения канала входящих сообщений
    ''' </summary>
    Private WithEvents TMR As Timer = Nothing

    '''<summary> 
    ''' Программа не обрабатывает в настоящий момент сообщения
    ''' </summary>
    Private isFree As Boolean = True


    Sub Main()
        '
        ' Проверка наличия файла настроек в папке приложения
        '
        If Not My.Computer.FileSystem.FileExists(String.Format("{0}\setting.xml", Application.StartupPath)) Then
            Console.WriteLine("Error: setting.xml not found")
            Console.Write("Press any key to exit:")
            Console.ReadKey()
            Exit Sub
        End If
        '
        ' Объект для анализа входящих xml-сообщений
        '
        XmlDocTable = New XmlDocumentDataTable("XmlDocTable")
        '
        ' Загрузка данных из файла настроек в объект XmlDocTable
        '
        Try
            Console.WriteLine("Load Settings:")
            XmlDocTable.XmlDocument.Load(String.Format("{0}\setting.xml", Application.StartupPath))
            XmlDocTable.LoadXml(Nothing)
            Console.WriteLine(String.Format("ConnectionString = {0}", XmlDocTable("ConnectionString")))
            Console.WriteLine(String.Format("MqHostName = {0}", XmlDocTable("MqHostName")))
            Console.WriteLine(String.Format("MqPort = {0}", XmlDocTable("MqPort")))
            Console.WriteLine(String.Format("MqChannelName = {0}", XmlDocTable("MqChannelName")))
            Console.WriteLine(String.Format("MqQueueManagerName = {0}", XmlDocTable("MqQueueManagerName")))
            Console.WriteLine(String.Format("MqInQueueName = {0}", XmlDocTable("MqInQueueName")))
            Console.WriteLine(String.Format("MqOut1QueueName = {0}", XmlDocTable("MqOut1QueueName")))
            Console.WriteLine(String.Format("MqOut2QueueName = {0}", XmlDocTable("MqOut2QueueName")))
            Console.WriteLine(String.Format("TimerInterval = {0}", XmlDocTable("TimerInterval")))
            If Not C2.IsText(XmlDocTable("ConnectionString")) Then Throw New Exception("ConnectionString is empty")
            If Not C2.IsText(XmlDocTable("MqHostName")) Then Throw New Exception("MqHostName is empty")
            If Not C2.IsText(XmlDocTable("MqPort")) Then Throw New Exception("MqPort is empty")
            If Not C2.IsText(XmlDocTable("MqChannelName")) Then Throw New Exception("MqChannelName is empty")
            If Not C2.IsText(XmlDocTable("MqQueueManagerName")) Then Throw New Exception("MqQueueManagerName is empty")
            If Not C2.IsText(XmlDocTable("MqInQueueName")) Then Throw New Exception("MqInQueueName is empty")
            'If Not C2.IsText(XmlDocTable("MqOut1QueueName")) Then Throw New Exception("MqOut1QueueName is empty")
            'If Not C2.IsText(XmlDocTable("MqOut2QueueName")) Then Throw New Exception("MqOut2QueueName is empty")
        Catch ex As Exception
            XmlDocTable.Dispose()
            Console.WriteLine(String.Format("Error read setting.xml: {0}", ex.Message))
            Console.Write("Press any key to exit:")
            Console.ReadKey()
            Exit Sub
        End Try
        Console.WriteLine()
        '
        ' Подключение к базе данных
        '
        Connection = New SqlConnection(XmlDocTable("ConnectionString"))
        Try
            Console.Write("Open SQL Connection... ")
            Connection.Open()
            Console.WriteLine("OK.")
        Catch ex As Exception
            XmlDocTable.Dispose()
            Connection.Dispose()
            Console.WriteLine(String.Format("Error open database connection: {0}", ex.Message))
            Console.Write("Press any key to exit:")
            Console.ReadKey()
            Exit Sub
        End Try
        '
        ' Объект для работы с менеджером очередей
        '
        Try
            Console.Write("Create QueueManager object... ")
            MQ = New Cprp.Mq.QueueManager( _
                XmlDocTable("MqHostName"), _
                C2.ToInt(XmlDocTable("MqPort")), _
                XmlDocTable("MqChannelName"), _
                XmlDocTable("MqQueueManagerName"), _
                XmlDocTable("MqInQueueName"), _
                XmlDocTable("MqOut1QueueName"), _
                XmlDocTable("MqOut2QueueName"))
            Console.WriteLine("OK.")
        Catch ex As Exception
            XmlDocTable.Dispose()
            Connection.Dispose()
            Console.WriteLine(String.Format("Error create QueueManager object: {0}.", ex.Message))
            Console.Write("Press any key to exit:")
            Console.ReadKey()
            Exit Sub
        End Try
        '
        ' Таблица результатов обработки сообщений
        '
        Console.Write("Create ResultDataTable object... ")
        ResultTable = New ResultDataTable
        Console.WriteLine("OK.")
        '
        ' Таймер чтения канала входящих сообщений
        '
        Console.Write("Create Timer... ")
        Dim iTmp As Integer = C2.ToInt(XmlDocTable("TimerInterval"))
        If iTmp < 1000 Then iTmp = 1000
        TMR = New Timer
        TMR.Interval = iTmp
        TMR.Start()
        Console.WriteLine("OK.")
        Console.WriteLine()
        '
        ' Run
        '
        Application.Run()

    End Sub


    Private Sub Tmr_Tick(sender As Object, e As EventArgs) Handles Tmr.Tick
        If Not isFree Then Exit Sub
        isFree = False
        ResultTable.Rows.Clear()
        '
        ' Чтение входящего сообщения
        '
        Dim sTmp As String = MQ.Read
        If Not C2.IsText(sTmp) Then
            isFree = True
            Exit Sub
        End If

        Dim inMesName As String = Nothing   ' тип входящего сообщения
        Dim iTmp As Integer = 0
        Dim bTmp As Boolean = False
        Try
            XmlDocTable.LoadXml(sTmp)

            inMesName = XmlDocTable("MessageType")
            If Not C2.IsText(inMesName) Then inMesName = "Unknown"

            Select Case inMesName.ToUpper

                Case "MES047"
                    '
                    ' Сохранить ID работы из БД ИСЭК в БД ЭС ЦПРП
                    ' -------------------------------------------
                    '
                    Using Cmd As New SqlCommand With {.Connection = Connection}
                        Cmd.CommandText = String.Format( _
                            "UPDATE tWork SET isecId = {0} WHERE id = {1}", C2.ToInt(XmlDocTable("workId")), C2.ToInt(XmlDocTable("workEsId")))
                        Cmd.ExecuteNonQuery()
                    End Using
                    Exit Select

                Case "MES014"
                    '
                    ' Сохранить данные работы из ИСЭК, создать проекты заключений
                    ' -----------------------------------------------------------
                    '
                    Using Ds As New DataSet
                        Using S As New IO.StringReader(sTmp)
                            Ds.ReadXml(S)
                        End Using
                        '
                        ' Определение ID работы
                        '
                        If Ds.Tables("Work") Is Nothing Then
                            ResultTable.AddRow(404, "Отсутствуют данные работы (Work)")
                            Exit Select
                        End If
                        If Ds.Tables("Work").Columns.IndexOf("ID") < 0 Then
                            ResultTable.AddRow(404, "Отсутствует ID работы (Work.ID)")
                            Exit Select
                        End If
                        iTmp = C2.ToInt(Ds.Tables("Work").Rows(0)("ID"))
                        Using Cmd As New SqlCommand With {.Connection = Connection}
                            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tWork WHERE isecId = {0}", iTmp)
                            If CInt(Cmd.ExecuteScalar) = 0 Then
                                ResultTable.AddRow(404, String.Format("В ЭС ЦПРП отсутствует работа с isecId = {0}", iTmp))
                                Exit Select
                            End If
                            Cmd.CommandText = String.Format("SELECT id FROM tWork WHERE isecId = {0}", iTmp)
                            iTmp = CInt(Cmd.ExecuteScalar)
                        End Using
                        '
                        ' Загрузка данных в работу
                        '
                        Using Work As New Cprp.DxData.Work.Excont.WorkConnectionRow(iTmp, Connection)
                            '
                            ' Удаление старых данных
                            '
                            Work.MemberEmbargoTable.Rows.Clear()
                            Work.MemberControlTable.Rows.Clear()
                            Work.MemberRiskTable.Rows.Clear()
                            Work.MemberTable.Rows.Clear()
                            Work.GoodLawTable.Rows.Clear()
                            Work.GoodEmbargoTable.Rows.Clear()
                            Work.GoodControlTable.Rows.Clear()
                            Work.GoodRiskTable.Rows.Clear()
                            Work.GoodTable.Rows.Clear()
                            Work.ContractRiskTable.Rows.Clear()
                            Work.SupplyRiskTable.Rows.Clear()
                            '
                            ' ARow
                            '
                            With Work.ARow
                                .Item("isDocRule") = True
                                .Item("isNotContract") = True
                                .Item("isNotContractRisk") = True
                                .Item("isNotSupplyRisk") = True
                                .Item("docTerm") = Date.Today.AddYears(1)
                            End With
                            With Ds.Tables("Work").Rows(0)
                                Work.ARow("countryId") = .Item("countryId")
                                Work.ARow("supplyTypeId") = .Item("kindId")
                                Work.ARow("modeId") = CInt(Work.SupplyTypeHandbookTable.Rows.Find(.Item("kindId"))("modeId"))
                                Work.ARow("invoiceCaption") = C2.DbText(.Item("contract"))
                                Work.ARow("supplyDescription") = C2.DbText(.Item("description"))
                                Work("comment") = String.Format("Работа выполнена в ИСЭК.{0}{1}", vbCrLf, C2.AddPoint(.Item("comment")))
                                ' Решение по анализу
                                Work.ARow("summaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsFreedom)
                                Work.ARow("summaryText") = "Для осуществления внешнеэкономической операции, указанной в настоящем заключении, лицензия или иное разрешение, предусмотренное законодательством Российской Федерации в области экспортного контроля, не требуется."
                                If Not Ds.Tables("GoodLaw") Is Nothing Then
                                    Using V As New DataView(Ds.Tables("GoodLaw")) With {.RowFilter = "summaryId = 2"}
                                        If V.Count > 0 Then
                                            Work.ARow("summaryId") = CInt(Cprp.DxData.Work.WorkSummary.IsLicense)
                                            Work.ARow("summaryText") = "Для осуществления внешнеэкономической операции, указанной в настоящем заключении, требуется лицензия Федеральной службы по техническому и экспортному контролю."
                                        End If
                                    End Using
                                End If
                            End With
                            '
                            ' MemberTable
                            '
                            Dim Row As DataRow = Nothing
                            Dim supRusNum As Integer = 0
                            Dim supNusNum As Integer = 0
                            Dim supEndNum As Integer = 0
                            For Each Row1 As DataRow In Ds.Tables("Member").Rows
                                Row = Work.MemberTable.NewRow
                                Row("dbId") = Row1("ID")
                                If C2.ToInt(Row1("rusNum")) > 0 Then
                                    supRusNum += 1
                                    Row("supRusNum") = supRusNum
                                End If
                                If C2.ToInt(Row1("nusNum")) > 0 Then
                                    supNusNum += 1
                                    Row("supNusNum") = supNusNum
                                End If
                                If C2.ToInt(Row1("endNum")) > 0 Then
                                    supEndNum += 1
                                    Row("supEndNum") = supEndNum
                                End If
                                Row("nameLong") = Row1("name")
                                Row("nameShort") = Row("nameLong")
                                Row("addressLegalCountryId") = Row1("countryId")
                                Row("addressLegalFull") = Row1("address")
                                Row("addressLegalTown") = "[нет данных]"
                                Row("phone") = Row1("phone")
                                Row("inn") = Row1("inn")
                                Row("proDescription") = "[нет данных]"
                                Row("proSource") = "[нет данных]"
                                Row("isNotEmbargo") = True          ' предварительно
                                Row("isNotControl") = True
                                Row("isNotConRusRisk") = True
                                Row("isNotConNusRisk") = True
                                Row("isNotSupRusRisk") = True
                                Row("isNotSupNusRisk") = True
                                Row("isNotSupEndRisk") = True
                                Row("isCheckData") = True
                                Row("isCheckEmbargo") = True
                                Row("isCheckControl") = True
                                Row("isCheckProfile") = True
                                Row("isCheckConRusRisk") = True
                                Row("isCheckConNusRisk") = True
                                Row("isCheckSupRusRisk") = True
                                Row("isCheckSupNusRisk") = True
                                Row("isCheckSupEndRisk") = True
                                Work.MemberTable.Rows.Add(Row)
                            Next
                            '
                            ' GoodTable
                            '
                            For Each Row1 As DataRow In Ds.Tables("Good").Rows
                                Row = Work.GoodTable.AddNew
                                Row("dbId") = Row1("ID")
                                Row("isUnreal") = CBool(Row1("isUnreal"))
                                Row("nameCon") = Row1("nameCon")
                                Row("nameDec") = Row1("nameDec")
                                Row("isNotDec") = Not C2.IsText(Row("nameDec"))
                                Row("tnved") = Row1("tnved")
                                Row("typeId") = Row1("typeId")
                                Row("area") = Row1("area")
                                Row("used") = Row1("used")
                                Row("description") = Row1("description")
                                Row("riskDescription") = Row1("risk")
                                Row("studyDate") = Date.Now
                                Row("studyTnved") = Row("tnved")
                                Row("studySummaryId") = 0           ' предварительно
                                Row("isNotEmbargo") = True          ' предварительно
                                Row("isNotControl") = True
                                Row("isNotRisk") = Not C2.IsText(Row("riskDescription"))
                                Row("isCheckData") = True
                                Row("isCheckEmbargo") = True
                                Row("isCheckControl") = True
                                Row("isCheckStudy") = True
                                Row("isCheckRisk") = True
                            Next
                            '
                            ' MemberEmbargo
                            '
                            If Not Ds.Tables("MemberEmbargo") Is Nothing Then
                                Using V As New DataView(Work.MemberTable)
                                    For Each Row1 As DataRow In Ds.Tables("MemberEmbargo").Rows
                                        V.RowFilter = String.Format("dbId = {0}", CInt(Row1("memberId")))
                                        If V.Count = 0 Then Continue For
                                        Work.MemberEmbargoTable.Rows.Add(New Object() {V(0)("id"), Row1("embargoId")})
                                        V(0)("isNotEmbargo") = False
                                    Next
                                End Using
                            End If
                            '
                            ' GoodLaw, GoodEmbargo
                            '
                            Using V As New DataView(Work.GoodTable)
                                '
                                ' GoodLaw
                                '
                                If Not Ds.Tables("GoodLaw") Is Nothing Then
                                    For Each Row1 As DataRow In Ds.Tables("GoodLaw").Rows
                                        V.RowFilter = String.Format("dbId = {0}", CInt(Row1("goodId")))
                                        If V.Count = 0 Then Continue For
                                        Row = Work.GoodLawTable.NewRow
                                        Row("goodId") = V(0)("id")
                                        Row("lawId") = Row1("lawId")
                                        Row("lawDescription") = Work.LawDataSet.LawTable.Rows.Find(Row("lawId"))("description")
                                        Row("goodDescription") = Row1("description")
                                        Row("isFindTnved") = True
                                        'Select Case C2.ToInt(Row1("summaryId"))
                                        '    Case 4 : Row("summaryId") = 1
                                        '    Case 5 : Row("summaryId") = 2
                                        '    Case Else : Row("summaryId") = 0
                                        'End Select
                                        Row("summaryId") = Row1("summaryId")
                                        Work.GoodLawTable.Rows.Add(Row)
                                        If CInt(V(0)("studySummaryId")) < CInt(Row("summaryId")) Then V(0)("studySummaryId") = Row("summaryId")
                                    Next
                                End If
                                '
                                ' GoodEmbargo
                                '
                                If Not Ds.Tables("GoodEmbargo") Is Nothing Then
                                    For Each Row1 As DataRow In Ds.Tables("GoodEmbargo").Rows
                                        V.RowFilter = String.Format("dbId = {0}", CInt(Row1("goodId")))
                                        If V.Count = 0 Then Continue For
                                        Work.GoodEmbargoTable.Rows.Add(New Object() {V(0)("id"), Row1("embargoId")})
                                        V(0)("isNotEmbargo") = False
                                    Next
                                End If
                            End Using

                            For Each Row In Work.GoodTable.Rows
                                Row("dbId") = DBNull.Value
                            Next
                            For Each Row In Work.MemberTable.Rows
                                Row("dbId") = DBNull.Value
                            Next
                            '
                            ' Проекты заключений
                            '
                            Work.ProjectCreate()
                            '
                            ' Содержание
                            '
                            Work.ARow("contentData") = Work.GetHtmlContent
                            '
                            ' Отправка на утверждение
                            '
                            Work.Condition = Cprp.DxData.Work.WorkCondition.IsAgree
                            '
                            ' Сохранение данных
                            '
                            Work.DataSave()
                        End Using
                    End Using

                Case Else
                    ResultTable.AddRow(404, String.Format("Не корректный тип входящего сообщения ({0}).", inMesName))
            End Select

        Catch ex As Exception
            ResultTable.AddRow(404, ex.Message)
        End Try
        '
        ' Если при обработке входящего сообщения возникли ошибки сохранить их в файл xml в папке программы
        '
        If ResultTable.Rows.Count > 0 Then ResultTable.WriteXml(String.Format("{0}\{1:yyyyMMdd-HHmmss}.xml", Application.StartupPath, Date.Now))
        '
        ' Вывод результатов обработки на экран
        '
        sTmp = If(ResultTable.Rows.Count = 0, "True", "False")
        Console.WriteLine(String.Format("{0:dd.MM.yyyy HH:mm:ss}{3}{1}{3}{2}", Date.Now, inMesName, sTmp, vbTab))

        isFree = True

    End Sub

End Module
