Imports DevExpress.XtraRichEdit.API.Native
Imports DevExpress.XtraRichEdit.API.Layout
Imports C2 = Cprp.DxData.Common
' ==================================================
' Свойства и методы для работы с итоговым документом
' ==================================================
Partial Public Class WorkConnectionRow


    ''' <summary>
    ''' Создать итоговые документы
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub DocumentCreate()
        If Me.IsEmpty Then Exit Sub
        Try
            Dim sTmp As String = Cprp.DxData.Resource.Resource.GetStrData("EOFOLDERPATH", Me.Connection)
            If Not (C2.IsText(sTmp) AndAlso My.Computer.FileSystem.DirectoryExists(sTmp)) Then
                Throw New Exception("Недоступна папка для сохранения файлов документов.")
            End If
            ' Итоговый документ
            OneDocumentCreate()
            ' Создание файлов документов, передача сведений о файлах в ЭО
            OneDocumentToEO()
            ' Сохранение изменившихся данных в Me.ARow
            Me.DataSave()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


    ''' <summary>
    ''' Создать один итоговый документ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OneDocumentCreate()
        '
        ' Оценка необходимости создавать документ
        '
        If IsDBNull(Me.ARow("doc1Data")) Then
            Me.ARow("doc1Id") = DBNull.Value
            Me.ARow("doc1RegNum") = DBNull.Value
            Me.ARow("doc1RegDate") = DBNull.Value
            Exit Sub
        End If
        '
        ' Переменные
        '
        Dim docId As Integer = 0                            ' Порядковый номер запроса в таблице запросов
        Dim regNum As String = Nothing                      ' Номер документа
        Dim regDate As Date = Date.Now                      ' Дата документа
        Dim userId As Integer = 0                           ' ID регистратора документа
        Dim typeId As Integer = 4                           ' Вид исходящего документа
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
            R.Document.OpenXmlBytes = Me.ARow("doc1Data")
            R.Document.BeginUpdate()
            PutBookmark(R.Document, "DocNum", regNum)
            PutBookmark(R.Document, "DocDate", String.Format("{0:dd.MM.yyyy}", Date.Today))
            '
            ' Удаление красного цвета
            '
            Dim charProp As CharacterProperties = R.Document.BeginUpdateCharacters(R.Document.Range)
            charProp.ForeColor = Drawing.SystemColors.WindowText
            R.Document.EndUpdateCharacters(charProp)

            R.EndUpdate()
            '
            ' Сохранение данных в работу
            '
            Me.ARow("doc1Data") = R.OpenXmlBytes
            Me.ARow("doc1Id") = docId
            Me.ARow("doc1RegNum") = regNum
            Me.ARow("doc1RegDate") = regDate
            Me.ARow.AcceptChanges()

        Catch ex As Exception
            Throw ex
        Finally
            If Not R Is Nothing Then R.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' Сохранить один итоговый документ в папку обмена с ЭО
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub OneDocumentToEO()
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
            Cert.Location = String.Format("Исх. № {0} от {1:dd.MM.yyyy}", C2.ToText(Me.ARow("doc1RegNum")), CDate(Me.ARow("doc1RegDate")))
            Cert.Contact = userEmail
            '
            ' Создание документа и заполнение его данными
            ' ===========================================
            '
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Millimeter
            R.Document.OpenXmlBytes = Me.ARow("doc1Data")
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
            ' Сохранение документа в работу
            ' =============================
            '
            Me.ARow("doc1Data") = R.OpenXmlBytes
            Me.ARow.AcceptChanges()
            '
            ' Запись в базу данных id подписанта документа
            ' ============================================
            '
            Me.ExecuteNonQuery(String.Format( _
                               "UPDATE tWorkRequest SET userId = {0} WHERE docId = {1}", userId, C2.ToInt(Me.ARow("doc1Id"))))
            '
            ' Полный путь к файлу документа
            ' =============================
            '
            sTmp = Cprp.DxData.Resource.Resource.GetStrData("EOFOLDERPATH", Me.Connection)
            If Not (C2.IsText(sTmp) AndAlso My.Computer.FileSystem.DirectoryExists(sTmp)) Then
                Throw New Exception("Недоступна папка для сохранения файлов документов.")
            End If
            If Not sTmp Like "*\" Then sTmp = String.Format("{0}\", sTmp)
            docPath = String.Format("{0}{1}.pdf", sTmp, C2.ToText(Me.ARow("doc1RegNum")).Replace("/", "-"))
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
            ' Отправка в ЭО сообщения о новом документе
            ' =========================================
            '
            MyClass.MessageOutputDocumentNewEo(Me.ARow("doc1RegNum").ToString, CDate(Me.ARow("doc1RegDate")), "EXCONT\" & userLogin, _
                                               docPath, 4, Nothing, Nothing)

        Catch ex As Exception
            Throw ex
        Finally
            If Not R Is Nothing Then R.Dispose()
        End Try

    End Sub

End Class
