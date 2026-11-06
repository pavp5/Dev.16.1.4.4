Imports Cprp.DxData.Common
Imports Newtonsoft.Json
Imports System.IO
Imports System.Net
Imports System.Threading
Imports MarkdownSharp
' ===========================================================
' Свойства и методы для работы с входящими документами из VLM
' ===========================================================
Partial Public Class WorkConnectionRow

    Public jsonOrderDoc As Json.IncomingDocList = Nothing

    ' Загрузить входящие документы из VLM
    Public Sub LoadOrderDocFromWeb()
        Dim orderId As Integer = Cprp.DxData.Common.ToInt(Me("siteOrderId"))
        If orderId < 0 Then Exit Sub

        Dim url As String = String.Format("http://172.28.1.237/api/v1/orders/{0}/documents", orderId.ToString)

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
                request.BeginGetResponse(New AsyncCallback(AddressOf RespCallback2), state)

                ' 3. Ждем 10 секунд
                Dim isDataReceived As Boolean = dataReadyEvent.WaitOne(10000)

                If isDataReceived AndAlso jsonOrderDoc IsNot Nothing Then
                    For Each doc As Json.IncomingDocument In jsonOrderDoc.Documents
                        doc.Markdown = ConvertMarkdownToHtml(doc.Markdown)
                    Next
                Else
                    If request IsNot Nothing Then request.Abort()
                End If

            Catch ex As Exception
                If request IsNot Nothing Then request.Abort()
            End Try
        End Using ' 4. Блок Using автоматически вызовет .Close() / .Dispose() для замка

    End Sub

    ''' <summary>
    ''' Преобразует строку в формате Markdown в строку HTML
    ''' </summary>
    Public Function ConvertMarkdownToHtml(ByVal markdownText As String) As String
        If String.IsNullOrEmpty(markdownText) Then
            Return String.Empty
        End If

        ' Инициализируем настройки со свойствами, которые точно есть в MarkdownSharp
        Dim options As New MarkdownOptions()
        options.AutoHyperlink = True ' Эта опция поддерживается по умолчанию

        ' По желанию можно включить или выключить другие доступные свойства:
        ' options.LinkEmails = True
        options.StrictBoldItalic = True

        ' Создаем конвертер и выполняем трансформацию
        Dim transformer As New Markdown(options)
        Dim htmlResult As String = transformer.Transform(markdownText)

        Return htmlResult
    End Function


    Private Sub RespCallback2(ByVal asynchronousResult As IAsyncResult)
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
                        jsonOrderDoc = JsonConvert.DeserializeObject(Of Json.IncomingDocList)(jsonString)
                    End Using
                End Using
            End Using
        Catch ex As Exception
            ' Если произошла ошибка сети, таймаут или сбой парсинга JSON
            jsonOrderDoc = Nothing
        Finally
            ' 4. Открываем замок для главного потока
            If state IsNot Nothing AndAlso state.ResetEvent IsNot Nothing Then
                Try
                    state.ResetEvent.Set()
                Catch ex As ObjectDisposedException
                    ' Игнорируем, если 10 секунд уже прошло и главный поток успел удалить замок
                End Try
            End If
        End Try
    End Sub

End Class
