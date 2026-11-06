Imports C2 = Cprp.DxData.Common
' =================
' Запросы по работе
' =================
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Перечитать содержимое полей запросов по содержимому таблицы запросов
    ''' </summary>
    ''' <remarks>Поле isAskSend (отправлен запрос) переводится в False руководителем вручную</remarks>
    Public Sub RequestFieldsUpdate()
        Me("isAsk") = False
        Me("isAskSign") = False
        'Me("isAskSend") = False
        For Each Row As DataRow In Me.RequestTable.Rows
            Select Case CType(Row("conditionId"), WorkCondition)
                Case WorkCondition.IsAgree : Me("isAsk") = True : Exit Select
                Case WorkCondition.IsSignature : Me("isAskSign") = True : Exit Select
                    'Case WorkCondition.IsAccept : Me("isAskSend") = True : Exit Select
            End Select
        Next
    End Sub

    ''' <summary>
    ''' Создать проект запроса
    ''' </summary>
    ''' <param name="Row">Строка таблицы запросов</param>
    Public Sub RequestCreateProject(ByRef Row As DataRow)
        If Row Is Nothing OrElse Row.Table Is Nothing OrElse Not TypeOf Row.Table Is RequestDataTable Then Exit Sub

        ' ПЕРЕМЕННЫЕ
        ' ++++++++++
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing       ' Документ
        Dim sTmp As String = Nothing

        ' ИНИЦИАЛИЗАЦИЯ ПЕРЕМЕННЫХ
        ' ++++++++++++++++++++++++
        '
        R = New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.Unit = DevExpress.Office.DocumentUnit.Document
        R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document

        ' ЗАГРУЗКА ШАБЛОНА ЗАПРОСА И ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        ' +++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Загрузка шаблона запроса
        If IsDBNull(Row("typeId")) Then
            R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ЦПРПЗАПРОС", Me.Connection)
        ElseIf CInt(Row("typeId")) = 1 Then
            R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ЦПРПЗАПРОСДОКУМЕНТАЦИЯ", Me.Connection)
        Else
            R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ЦПРПЗАПРОСДАННЫЕ", Me.Connection)
        End If

        R.Document.BeginUpdate()

        ' Номер и дата запроса
        PutBookmark(R.Document, "DocNum", Nothing, "{Проект}")
        PutBookmark(R.Document, "DocDate", String.Format("{0:dd.MM.yyyy}", Date.Today))

        ' Номер заказа
        PutBookmark(R.Document, "OrderNum", C2.ToText(Me("orderNum")))

        ' Наименование заказачика
        PutBookmark(R.Document, "ClientCaption", C2.ToText(Me("clientName")))

        ' Реквизиты руководителя (в 2-х местах)
        sTmp = C2.ToText(Me("clientInn"))
        If C2.IsText(sTmp) Then
            Dim leaderPost As String = Nothing
            Dim leaderName As String = Nothing
            Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT post, nameLong FROM tMemberPerson WHERE inn LIKE '{0}'", sTmp))
                If Dr.Read Then
                    leaderPost = C2.ToText(Dr("post"))
                    leaderName = C2.ToText(Dr("nameLong"))
                End If
                Dr.Close()
            End Using
            ' кому
            If C2.IsText(leaderPost) AndAlso C2.IsText(leaderName) Then
                sTmp = leaderName
                If sTmp Like "?* ?* ?*" Then
                    Dim arr() As String = sTmp.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                    If arr.Length > 2 Then
                        sTmp = String.Format("{0} {1}.{2}.", arr(0), arr(1).Substring(0, 1), arr(2).Substring(0, 1))
                    End If
                End If
                PutHtmlRange(R.Document.Bookmarks("LeaderPost").Range, String.Format("<span style='color:#ff0000'>{0}<br>{1}</style>", leaderPost, sTmp))
            End If
            ' уважаемый
            If C2.IsText(leaderName) Then
                sTmp = leaderName
                If sTmp Like "?* ?* ?*" Then
                    sTmp = sTmp.Substring(sTmp.IndexOf(" ") + 1)
                End If
                PutBookmark(R.Document, "LeaderName", sTmp)
            End If
        End If

        ' Срок ответа на запрос
        sTmp = C2.ToText(Row("term"))
        If C2.IsText(sTmp) Then sTmp = String.Format("{0:dd.MM.yyyy HH:mm}", CDate(sTmp))
        PutBookmark(R.Document, "Term", sTmp, "{укажите срок}")

        ' Штам ЭП (предварительно)
        PutBookmark(R.Document, "SertNum", "-")
        PutBookmark(R.Document, "SertName", "-")
        PutBookmark(R.Document, "SertTerm", "-")

        ' Завершение редактирования документа
        R.Document.EndUpdate()

        ' СОХРАНЕНИЕ ДОКУМЕНТА В ЯЧКЙКУ СТРОКИ ТАБЛИЦЫ ЗАПРОСОВ
        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        Row("docData") = R.OpenXmlBytes
        R.Dispose()

    End Sub

    ''' <summary>
    ''' Присвоить документу запроса регистрационный номер
    ''' </summary>
    ''' <param name="Row">Строка таблицы запросов</param>
    Public Sub RequestSetRegNum(Row As DataRow)
        If Row Is Nothing OrElse Row.Table Is Nothing OrElse Not TypeOf Row.Table Is RequestDataTable Then Exit Sub
        '
        ' Переменные
        '
        Dim docId As Integer = 0                            ' Порядковый номер запроса в таблице запросов
        Dim regNum As String = Nothing                      ' Номер документа
        Dim regDate As Date = Date.Now                      ' Дата документа
        Dim userId As Integer = 0                           ' ID регистратора документа
        Dim typeId As Integer = 0                           ' Вид запроса
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Try
            '
            ' Инициализация переменных
            '
            docId = CInt(Me.ExecuteScalar(String.Format( _
                                          "SELECT ISNULL(MAX(docId), 0) FROM tWorkRequest WHERE regDate > {{ts '{0}-01-01 00:00:00'}}", _
                                          Date.Today.Year)))
            docId += 1
            regNum = String.Format("Исх/01/01/{0:0000}-{1:yy}", docId, regDate)
            userId = CInt(Cprp.DxData.User.Common.CurrentUserId(Me.Connection))
            If Not IsDBNull(Row("typeId")) Then typeId = CInt(Row("typeId"))
            '
            ' Запись в базу данных сведений о новом документе
            '
            Me.ExecuteNonQuery(String.Format( _
                                 "INSERT tWorkRequest(workId, docId, typeId, regNum, regDate, userId) " & _
                                 "VALUES({0}, {1}, {2}, '{3}', {{ts '{4:yyyy-MM-dd HH:mm:ss}'}}, {5})",
                                 CInt(Me.Id), docId, typeId, regNum, regDate, userId))
            '
            ' Подстановка регистрационных данных в документ
            '
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Millimeter
            R.Document.OpenXmlBytes = Row("docData")
            R.Document.BeginUpdate()
            PutBookmark(R.Document, "DocNum", regNum)
            PutBookmark(R.Document, "DocDate", String.Format("{0:dd.MM.yyyy}", Date.Today))
            '
            ' Удаление красного цвета
            '
            Dim charProp As DevExpress.XtraRichEdit.API.Native.CharacterProperties = R.Document.BeginUpdateCharacters(R.Document.Range)
            charProp.ForeColor = Drawing.SystemColors.WindowText
            R.Document.EndUpdateCharacters(charProp)

            R.EndUpdate()
            '
            ' Сохранение данных в строку таблицы запросов
            '
            Row("docId") = docId
            Row("regNum") = regNum
            Row("regDate") = regDate
            Row("docData") = R.OpenXmlBytes
            Row.AcceptChanges()

        Catch ex As Exception
            Throw ex
        Finally
            If Not R Is Nothing Then R.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' Создать документ запроса подписанный ЭП
    ''' </summary>
    ''' <param name="Row">Строка таблицы запросов</param>
    Public Sub RequestCreateDocument(ByRef Row As DataRow)
        If Row Is Nothing OrElse Row.Table Is Nothing OrElse Not TypeOf Row.Table Is RequestDataTable Then Exit Sub
        '
        ' Переменные
        '
        Dim userId As Integer = 0                           ' ID подписанта
        Dim userJobName As String = Nothing                 ' Должность + ФИО подписанта
        Dim userLogin As String = Nothing                   ' Логин подписанта
        Dim userEmail As String = Nothing                   ' E-mail подписанта
        Dim userPin As String = Nothing                     ' Pin-код доступа к сертификату подписанта
        Dim docPath As String = Nothing                     ' Полный путь к файлу документа
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Dim sTmp As String = Nothing
        Try
            '
            ' Реквизиты подписанта
            ' ====================
            '
            userId = CInt(Cprp.DxData.User.Common.CurrentUserId(Me.Connection))
            Using Dr As SqlDataReader = Me.ExecuteReader(String.Format( _
                   "SELECT id, nameLong, leaderDescription, expertDescription, login, email, pin, isLeader FROM vUser WHERE id = {0}", userId))
                If Dr.Read Then
                    userJobName = String.Format("{0}{1}{2}", If(CBool(Dr("isLeader")), C2.ToText(Dr("leaderDescription")), C2.ToText(Dr("expertDescription"))), vbCrLf, C2.ToText(Dr("nameLong")))
                    userLogin = C2.ToText(Dr("login"))
                    userEmail = C2.ToText(Dr("email"))
                    userPin = C2.ToText(Dr("pin"))
                End If
            End Using
            '
            ' Реквизиты ЭП
            ' ============
            '
            Dim Cert As New Cprp.Signature.Certificate(userEmail)
            Cert.Reason = "Верификация документа"
            Cert.Location = String.Format("Запрос № {0} от {1:dd.MM.yyyy}", C2.ToText(Row("regNum")), CDate(Row("regDate")))
            Cert.Contact = userEmail
            '
            ' Создание документа и заполнение его данными
            ' ===========================================
            '
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Millimeter
            R.Document.OpenXmlBytes = Row("docData")
            R.Document.BeginUpdate()
            '
            ' Штамп ЭП
            '
            PutBookmark(R.Document, "SertName", userJobName)
            PutBookmark(R.Document, "SertNum", Cert.SerialNumber)
            PutBookmark(R.Document, "SertTerm", String.Format("с {0:dd.MM.yyyy} по {1:dd.MM.yyyy}", Cert.DateBegin, Cert.DateEnd))
            '
            ' Завершение редактирования документа
            '
            R.Document.EndUpdate()
            '
            ' Сохранение документа в строку таблицы запросов
            ' ==============================================
            '
            Row("docData") = R.OpenXmlBytes
            Row.AcceptChanges()
            '
            ' Запись в базу данных id подписанта документа
            ' ============================================
            '
            Me.ExecuteNonQuery(String.Format( _
                               "UPDATE tWorkRequest SET userId = {0} WHERE docId = {1}", userId, C2.ToInt(Row("docId"))))
            '
            ' Полный путь к файлу документа
            ' =============================
            '
            sTmp = Cprp.DxData.Resource.Resource.GetStrData("EOFOLDERPATH", Me.Connection)
            If Not (C2.IsText(sTmp) AndAlso My.Computer.FileSystem.DirectoryExists(sTmp)) Then
                Throw New Exception("Недоступна папка для сохранения файлов документов.")
            End If
            If Not sTmp Like "*\" Then sTmp = String.Format("{0}\", sTmp)
            docPath = String.Format("{0}{1}.pdf", sTmp, C2.ToText(Row("regNum")).Replace("/", "-"))
            '
            ' Создание файла с ЭП подписанта в формате pdf
            ' ============================================
            '
            Using Fs As New System.IO.FileStream(docPath, IO.FileMode.Create)
                R.ExportToPdf(Fs)
                Fs.Close()
            End Using
            Cert.SignPdf(docPath, userPin, Date.Now)
            '
            ' Отправка в ЭО сообщения о новом запросе
            ' =======================================
            '
            MyClass.MessageOutputDocumentNewEo(Row("regNum").ToString, CDate(Row("regDate")), "EXCONT\" & userLogin, _
                                              docPath, 3, Nothing, If(IsDBNull(Row("term")), Nothing, CDate(Row("term"))))

        Catch ex As Exception
            Throw ex
        Finally
            If Not R Is Nothing Then R.Dispose()
        End Try

    End Sub

End Class

