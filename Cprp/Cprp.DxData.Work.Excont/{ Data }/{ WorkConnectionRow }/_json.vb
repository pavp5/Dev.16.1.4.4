Imports Cprp.DxData.Common
Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports System.Threading
' ===================================
' Свойства и методы для работы с Json
' ===================================
Partial Public Class WorkConnectionRow

    ' Внутренний класс-контейнер для передачи объектов в фоновый поток
    Private Class RequestState
        Public Property Request As HttpWebRequest
        Public Property ResetEvent As ManualResetEvent
    End Class

    Private jsonData As Json.DataJson = Nothing

    Public Sub LoadFromWeb()
        Dim orderId As Integer = Cprp.DxData.Common.ToInt(Me("siteOrderId"))
        If orderId < 0 Then Exit Sub

        Dim url As String = String.Format("http://172.28.1.237/api/v1/orders/{0}/result", orderId.ToString)

        ' 1. Создаем замок локально внутри метода!
        Using dataReadyEvent As New ManualResetEvent(False)
            Dim request As HttpWebRequest = Nothing

            Try
                request = CType(WebRequest.Create(url), HttpWebRequest)
                request.Method = "GET"
                request.UserAgent = "Mozilla/5.0 MyVBNetApp"
                request.Accept = "application/json"

                ' Создаем состояние и упаковываем туда наш запрос и локальный замок
                Dim state As New RequestState()
                state.Request = request
                state.ResetEvent = dataReadyEvent

                ' 2. Передаем state в асинхронный метод
                request.BeginGetResponse(New AsyncCallback(AddressOf RespCallback), state)

                ' 3. Ждем 5 секунд
                Dim isDataReceived As Boolean = dataReadyEvent.WaitOne(5000)

                If isDataReceived AndAlso jsonData IsNot Nothing Then
                    Me.LoadFromJson()
                Else
                    If request IsNot Nothing Then request.Abort()
                End If

            Catch ex As Exception
                If request IsNot Nothing Then request.Abort()
            End Try
        End Using ' 4. Блок Using автоматически вызовет .Close() / .Dispose() для замка

    End Sub

    Private Sub LoadFromJson()

        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        '
        ' Входящие документы
        '
        'Me.InDocTable.Rows.Clear()
        'For Each doc As Json.Document In jsonData.Documents
        '    Row = Me.InDocTable.NewRow
        '    iTmp = Me.InDocTable.Rows.Count + 1
        '    Row("id") = iTmp
        '    Row("rowNum") = iTmp
        '    Row("kindId") = 1
        '    Row("caption") = DbText(doc.DocumentName)
        '    Row("regNum") = DbText(doc.DocumentNumber)
        '    Row("regDate") = DbDate(doc.DocumentDate)
        '    Row("docUrl") = doc.Url
        '    Me.InDocTable.Rows.Add(Row)
        'Next
        '
        ' Направление перемещения
        '
        Dim mode As Cprp.DxData.ModeEnum = ModeEnum.isExport
        Me.ARow("supplyTypeId") = 13
        If jsonData.Supply Is Nothing Then GoTo Contract
        If String.IsNullOrWhiteSpace(jsonData.Supply.Direction) Then GoTo Contract
        If jsonData.Supply.Direction.ToString.ToUpper <> "EXPORT" Then
            mode = ModeEnum.isImport
            Me.ARow("supplyTypeId") = 14
        End If

Contract:
        '
        ' Сделка
        '
        ' срок действия контракта
        Me.ARow("contractTerm") = DBNull.Value
        Me.ARow("contractName") = DBNull.Value
        Me.ARow("contractNum") = DBNull.Value
        Me.ARow("contractDate") = DBNull.Value
        If jsonData.Contract Is Nothing Then GoTo Supply
        Me.ARow("contractTerm") = DbDate(jsonData.Contract.Term)
        ' реквизиты документ-основания
        If jsonData.Contract.Documents Is Nothing OrElse jsonData.Contract.Documents.Count = 0 Then GoTo Supply
        With jsonData.Contract.Documents(0)
            Me.ARow("contractName") = DbText(.DocumentName)
            Me.ARow("contractNum") = DbText(.DocumentNumber)
            Me.ARow("contractDate") = DbDate(.DocumentDate)
        End With

Supply:
        '
        ' Операция
        '        
        Me.ARow("countryId") = DBNull.Value
        Me.ARow("countryIdString") = DBNull.Value
        Me.ARow("countryNameString") = DBNull.Value
        Me.ARow("bankCountryId") = DBNull.Value
        If jsonData.Supply Is Nothing Then GoTo Members
        With jsonData.Supply
            ' страна назначения / отправления
            Dim country As Json.Country = If(mode = ModeEnum.isExport, .DestinationCountry, .SenderCountry)
            If Not country Is Nothing Then
                Me.ARow("countryId") = Me.CountryHandbookTable.GetIdByCodAlpha2(country.CodeAlpha2)
                If Not IsDBNull(Me.ARow("countryId")) Then
                    Me.ARow("countryIdString") = Me.ARow("countryId").ToString
                    Me.ARow("countryNameString") = country.NameShort
                End If
            End If
            ' страна банка
            country = .BankCountry
            If Not country Is Nothing Then
                Me.ARow("bankCountryId") = Me.CountryHandbookTable.GetIdByCodAlpha2(country.CodeAlpha2)
            End If
        End With

Members:
        '
        ' Участники сделки и операции
        '        
        Me.MemberTable.Rows.Clear()
        If jsonData.Members Is Nothing OrElse jsonData.Members.Count = 0 Then GoTo Goods
        Dim isRus As Boolean = False
        For Each member As Json.Member In jsonData.Members
            iTmp = Me.MemberTable.Rows.Count + 1 ' id участника
            Row = Me.MemberTable.NewRow
            Row("id") = iTmp
            Row("nameLong") = DbText(member.NameLong)
            Row("nameShort") = DbText(member.NameShort)
            Row("inn") = DbText(member.Inn)
            Row("kpp") = DbText(member.Kpp)
            If Not member.Address Is Nothing Then
                Row("addressLegalFull") = DbText(member.Address.Full)
                If Not member.Address.Country Is Nothing Then
                    Row("addressLegalCountryId") = DbInt(Me.CountryHandbookTable.GetIdByCodAlpha2(member.Address.Country.CodeAlpha2))
                    isRus = (ToInt(Row("addressLegalCountryId")) = Me.CountryHandbookTable.RussiaID)
                Else
                    isRus = False
                End If
            End If
            For Each role As Json.Role In member.Roles
                Select Case role
                    Case Json.Role.buyer, Json.Role.seller
                        If isRus Then
                            Row("conRusNum") = 1
                        Else
                            Row("conNusNum") = 1
                        End If
                    Case Json.Role.recipient, Json.Role.sender
                        If isRus Then
                            Row("supRusNum") = 1
                        Else
                            Row("supNusNum") = 1
                        End If
                    Case Json.Role.consumer
                        Row("supEndNum") = 1
                End Select
            Next
            Me.MemberTable.Rows.Add(Row)
        Next

Goods:
        '
        ' Товары
        '
        Me.GoodTable.Rows.Clear()
        If jsonData.Goods Is Nothing OrElse jsonData.Goods.Count = 0 Then GoTo OK
        For Each good As Json.Good In jsonData.Goods
            iTmp = Me.GoodTable.Rows.Count + 1 ' id товара
            Row = Me.GoodTable.NewRow
            Row("id") = iTmp
            Row("rowNum") = iTmp
            Row("nameCon") = DbText(good.NameCon)
            Row("nameDec") = DbText(good.NameDec)
            Row("tnved") = DbText(good.Tnved)
            Row("description") = DbText(good.Description)
            Me.GoodTable.Rows.Add(Row)
            ' запреты и ограничения, контрольные списки
            If good.Restrictions.Count > 0 Then
                Row("studyDate") = Date.Now
                For Each restrict In good.Restrictions
                    Row = Me.LawDataSet.LawTable.Rows.Find(restrict.DbId)
                    If Row Is Nothing Then Continue For
                    If restrict.DocIsLaw Then
                        ' контрольный список
                        Me.GoodLawTable.Rows.Add(New Object() { _
                                                 iTmp, _
                                                 restrict.DbId, _
                                                 Row("doc"), _
                                                 restrict.DocDescription, _
                                                 restrict.ObjectDescription, _
                                                 False, _
                                                 False, _
                                                 False, _
                                                 If(restrict.ObjectIsEqual, 2, 1)
                                             })

                    Else
                        ' запрет, ограничение
                        Me.GoodEmbargoTable.Rows.Add(New Object() { _
                                                     iTmp, _
                                                     restrict.DbId
                                                 })
                    End If

                Next

            End If
        Next


OK:
    End Sub

    Private Sub RespCallback(ByVal asynchronousResult As IAsyncResult)
        ' 1. Приводим тип AsyncState к нашему внутреннему классу RequestState
        Dim state As RequestState = CType(asynchronousResult.AsyncState, RequestState)

        Try
            ' ИСПРАВЛЕНО: Достаем объект HttpWebRequest из переданного состояния state
            Dim request As HttpWebRequest = state.Request

            ' 2. Завершаем асинхронный запрос и получаем ответ сервера
            Using response As HttpWebResponse = CType(request.EndGetResponse(asynchronousResult), HttpWebResponse)
                Using dataStream As Stream = response.GetResponseStream()
                    Using reader As New StreamReader(dataStream)
                        Dim jsonString As String = reader.ReadToEnd()

                        ' 3. Именно здесь десериализуется и создается объект json_data
                        Dim settings As JsonSerializerSettings = New JsonSerializerSettings()
                        settings.DateFormatString = "yyyy-MM-dd"
                        jsonData = JsonConvert.DeserializeObject(Of Json.DataJson)(jsonString, settings)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Если произошла ошибка сети, таймаут или сбой парсинга JSON
            jsonData = Nothing
        Finally
            ' 4. Открываем замок для главного потока
            If state IsNot Nothing AndAlso state.ResetEvent IsNot Nothing Then
                Try
                    state.ResetEvent.Set()
                Catch ex As ObjectDisposedException
                    ' Игнорируем, если 5 секунд уже прошло и главный поток успел удалить замок
                End Try
            End If
        End Try
    End Sub


End Class