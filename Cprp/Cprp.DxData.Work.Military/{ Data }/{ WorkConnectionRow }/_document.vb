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
                Throw New Exception("Недоступна папка для сохранения файлов заключений.")
            End If
            ' Удаление записи о старом итоговом документе в базе данных
            Me.ExecuteNonQuery(String.Format("DELETE FROM tWorkDoc WHERE workId = {0}", CInt(Me.Id)))
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
        Dim docId As Integer = 0                            ' Порядковый номер заключения в таблице заключений
        Dim regNum As String = Nothing                      ' Номер заключения
        Dim regDate As Date = Date.Now                      ' Дата заключения
        Dim leaderJobName As String = Nothing               ' Должность + ФИО руководителя экспертизы
        Dim imgWatermark As Drawing.Image = Nothing         ' Водяной знак
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Dim Sd As SubDocument = Nothing
        Dim sTmp As String

        Try
           '
            ' Должность + ФИО руководителя экспертизы
            ' =======================================
            '
            leaderJobName = Cprp.DxData.User.Common.LeaderJobName(Me("leaderId"), Me.Connection)
            If C2.IsText(leaderJobName) Then
                leaderJobName = leaderJobName.Replace(C2.FIELD_SEPARATOR, vbCrLf)
            Else
                Throw New Exception("Отсутствует должность / ФИО руководителя экспертизы.")
            End If
            ' 
            ' Водяной знак
            ' ============
            '
            sTmp = My.Computer.FileSystem.GetTempFileName
            My.Computer.FileSystem.WriteAllBytes(sTmp, Cprp.DxData.Resource.Resource.GetBinData("WATERMARK", Me.Connection), False)
            imgWatermark = Drawing.Image.FromFile(sTmp)
            '
            ' Удаление временного файла с изображениями
            '
            My.Computer.FileSystem.DeleteFile(sTmp)
            '
            ' Порядковый номер
            ' ================
            '
            docId = C2.ToInt(Me.ARow("doc1Id"))
            If docId < 1 Then
                '
                ' Нет порядкового номера - сформировать новый порядковый номер
                '
                docId = CInt(Me.ExecuteScalar(String.Format( _
                                              "SELECT ISNULL(MAX(docId), 0) FROM tWorkDoc WHERE workId IN" & _
                                              "(SELECT id FROM tWork WHERE typeId = {0} OR typeId = {1} OR typeId = {2} OR typeId = {3}) AND regDate > {{ts '{4}-01-01 00:00:00'}}", _
                                              CInt(Cprp.DxData.Work.WorkType.IsCustomUnion), _
                                              CInt(Cprp.DxData.Work.WorkType.IsTnved), _
                                              CInt(Cprp.DxData.Work.WorkType.IsMilitary), _
                                              CInt(Cprp.DxData.Work.WorkType.IsConsultation), Date.Today.Year)))
                docId += 1
            End If
            '
            ' Номер заключения
            ' ================
            '
            regNum = String.Format("001/{0:0000}-{1:yy}", docId, Date.Today)
            '
            ' Запись в базу данных сведений о новом документе
            ' ===============================================
            '
            Me.ExecuteNonQuery(String.Format( _
                                 "INSERT tWorkDoc(workId, docId, regNum, regDate, summaryId) " & _
                                 "VALUES({0}, {1}, '{2}', {{ts '{3:yyyy-MM-dd HH:mm:ss}'}}, 0)",
                                 CInt(Me.Id), docId, regNum, regDate))
            '
            ' Создание документа и заполнение его данными
            ' ===========================================
            '
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Millimeter
            R.Document.OpenXmlBytes = Me.ARow("doc1Data")
            R.Document.BeginUpdate()
            '
            ' Номер и дата заключения - тело документа
            '
            PutBookmark(R.Document, "DocNum", regNum)
            PutBookmark(R.Document, "DocDate", String.Format("{0:d MMMM yyyy} г.", Date.Today))
            '
            ' Номер и дата заключения - колонтитул
            '
            Sd = R.Document.Sections(0).BeginUpdateHeader
            PutBookmark(Sd, "DocNum2", regNum)
            PutBookmark(Sd, "DocDate2", String.Format("{0:dd.MM.yyyy}", Date.Today), "{00.00.0000}")
            R.Document.Sections(0).EndUpdateHeader(Sd)
            '
            ' Водяной знак (первая страница)
            '
            Sd = R.Document.Sections(0).BeginUpdateHeader(SubDocumentType.Main)
            With Sd.Shapes.InsertPicture(Sd.Range.Start, imgWatermark)
                .Offset = New Drawing.SizeF((R.Document.Sections(0).Page.Width - .Size.Width) / 2 + 5, _
                                            (R.Document.Sections(0).Page.Height - .Size.Height) / 2 + 25)
            End With
            R.Document.Sections(0).EndUpdateHeader(Sd)
            '
            ' Водяной знак (остальные страницы)
            '
            Sd = R.Document.Sections(0).BeginUpdateHeader()
            With Sd.Shapes.InsertPicture(Sd.Range.Start, imgWatermark)
                .Offset = New Drawing.SizeF((R.Document.Sections(0).Page.Width - .Size.Width) / 2 + 5, _
                                            (R.Document.Sections(0).Page.Height - .Size.Height) / 2)
            End With
            R.Document.Sections(0).EndUpdateHeader(Sd)
            '
            ' Завершение редактирования документа
            '
            R.Document.EndUpdate()
            '
            ' Сохранение документа в работу вместо проекта заключения
            ' =======================================================
            '
            Me.ARow("doc1Data") = R.OpenXmlBytes
            Me.ARow("doc1Id") = docId
            Me.ARow("doc1RegNum") = regNum
            Me.ARow("doc1RegDate") = regDate
            '
            ' Сохранение в базу данных связей товаров с заключением
            ' =====================================================
            '
            Me.ExecuteNonQuery(String.Format( _
                               "DELETE FROM tWorkDocGood WHERE workId = {0} AND docId = {1}", _
                               CInt(Me.Id), docId))
            Using V As New DataView(Me.GoodTable)
                V.RowFilter = "dbId > 0"
                For Each VRow As DataRowView In V
                    '
                    ' Проверка наличия в базе товара (если работа содержит абсолютно идентичные товары)
                    '
                    If CInt(Me.ExecuteScalar(String.Format( _
                                             "SELECT COUNT(*) FROM tWorkDocGood WHERE workId = {0} AND docId = {1} AND goodId = {2}", _
                                             CInt(Me.Id), docId, CInt(VRow("dbId"))))) > 0 Then Continue For
                    '
                    ' Запись данных сведений о товаре из заключения
                    '
                    Me.ExecuteNonQuery(String.Format( _
                                       "INSERT tWorkDocGood(workId, docId, goodId) VALUES ({0}, {1}, {2})", _
                                       CInt(Me.Id), docId, CInt(VRow("dbId"))))
                Next
            End Using

        Catch ex As Exception
            Throw ex

        Finally
            If Not R Is Nothing Then R.Dispose()
            If Not imgWatermark Is Nothing Then imgWatermark.Dispose()
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
        Dim userId As Integer = 0                   ' ID подписанта
        Dim userJobName As String = Nothing         ' Должность + ФИО подписанта
        Dim userLogin As String = Nothing           ' Логин подписанта
        Dim userEmail As String = Nothing           ' E-mail подписанта
        Dim userPin As String = Nothing             ' Pin-код доступа к сертификату подписанта
        Dim docNum As String = Nothing              ' Номер документа
        Dim docDate As Date = Nothing               ' Дата документа
        Dim docPath As String = Nothing             ' Полный путь к файлу документа
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Dim sTmp As String, iTmp As Integer

        Try
            '
            ' Реквизиты подписанта
            ' ====================
            '
            ' Сначала считаем, что подписант - эксперт
            Using Dr As SqlDataReader = Me.ExecuteReader(String.Format( _
                "SELECT id, nameLong, expertDescription, login, email, pin FROM vUser WHERE id = {0}", C2.ToInt(Me("expertId"))))
                If Dr.Read Then
                    userId = CInt(Dr("id"))
                    userJobName = String.Format("{0}{1}{2}", C2.ToText(Dr("expertDescription")), vbCrLf, C2.ToText(Dr("nameLong")))
                    userLogin = C2.ToText(Dr("login"))
                    userEmail = C2.ToText(Dr("email"))
                    userPin = C2.ToText(Dr("pin"))
                End If
            End Using
            '
            ' Если у пользователя нет пин-кода, считаем, что подписант - руководитель
            '
            If Not (C2.IsText(userPin) AndAlso CBool(Me.ARow("isExpertSign"))) Then
                Using Dr As SqlDataReader = Me.ExecuteReader(String.Format( _
                    "SELECT id, nameLong, leaderDescription, login, email, pin FROM vUser WHERE id = {0}", C2.ToInt(Me("leaderId"))))
                    If Dr.Read Then
                        userId = CInt(Dr("id"))
                        userJobName = String.Format("{0}{1}{2}", C2.ToText(Dr("leaderDescription")), vbCrLf, C2.ToText(Dr("nameLong")))
                        userLogin = C2.ToText(Dr("login"))
                        userEmail = C2.ToText(Dr("email"))
                        userPin = C2.ToText(Dr("pin"))
                    End If
                End Using
            End If
            If Not C2.IsText(userPin) Then Throw New Exception("Отсутствует пин-код подписанта.")

            ' Номер документа
            ' ===============
            '
            docNum = C2.ToText(Me.ARow("doc1RegNum"))
            If Not C2.IsText(docNum) Then Throw New Exception("Нет номера заключения.")

            ' Дата документа
            ' ==============
            '
            sTmp = C2.ToText(Me.ARow("doc1RegDate"))
            If Not C2.IsText(sTmp) Then Throw New Exception("Нет даты заключения.")
            docDate = CDate(sTmp)

            ' Полный путь к файлу документа
            ' =============================
            '
            sTmp = Cprp.DxData.Resource.Resource.GetStrData("EOFOLDERPATH", Me.Connection)
            If Not (C2.IsText(sTmp) AndAlso My.Computer.FileSystem.DirectoryExists(sTmp)) Then
                Throw New Exception("Недоступна папка для сохранения файлов заключений.")
            End If
            If Not sTmp Like "*\" Then sTmp = String.Format("{0}\", sTmp)
            docPath = String.Format("{0}{1}.pdf", sTmp, docNum.Replace("/", "-"))

            ' Создание файла с ЭП в формате pdf
            ' =================================
            '
            Dim Cert As New Cprp.Signature.Certificate(userEmail)
            Cert.Reason = "Верификация документа"
            Cert.Location = String.Format("Консультация № {0} от {1:dd.MM.yyyy}", docNum, docDate)
            Cert.Contact = userEmail
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Millimeter
            R.Document.OpenXmlBytes = Me.ARow("doc1Data")
            R.BeginUpdate()
            ' Заполнение штампа
            PutBookmark(R.Document, "SertName", userJobName)
            PutBookmark(R.Document, "SertNum", Cert.SerialNumber)
            PutBookmark(R.Document, "SertTerm", String.Format("с {0:dd.MM.yyyy} по {1:dd.MM.yyyy}", Cert.DateBegin, Cert.DateEnd))
            R.EndUpdate()
            Using Fs As New System.IO.FileStream(docPath, IO.FileMode.Create)
                R.ExportToPdf(Fs)
                Fs.Close()
            End Using
            Cert.SignPdf(docPath, userPin, docDate)

            ' Запись в таблицу заключений ID подписанта
            ' =========================================
            Me.ExecuteNonQuery(String.Format( _
                               "UPDATE tWorkDoc SET userId = {0} WHERE workId = {1} AND docId = {2}", _
                               userId, CInt(Me.Id), CInt(Me.ARow("doc1Id"))))

            ' Запись сведений о файлах заключения в таблицу взаимодействия с ЭО
            ' =================================================================
            '
            ' Проверка наличия в таблице взаимодействия записи о заключении
            iTmp = C2.ToInt(Me.ExecuteScalar(String.Format("SELECT id FROM tTaskDocument WHERE docRegNum = '{0}'", docNum)))
            ' Если запись сущесвует - стереть номер версии и обновить поля
            If iTmp > 0 Then
                Me.ExecuteNonQuery(String.Format( _
                    "UPDATE tTaskDocument SET docUrl = '{0}', docRegDate = {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}, docVersion = NULL WHERE id = {2}", _
                    docPath, docDate, iTmp))
                MyBase.MessageOutputDocumentChangeEo(docNum, docDate, "EXCONT\" & userLogin, docPath, 1)
            Else
                Me.ExecuteNonQuery(String.Format( _
                    "INSERT tTaskDocument(docUrl, workId, orderId, docRegNum, docRegDate, headLogin) " & _
                    "VALUES('{0}', {1}, {2}, '{3}', {{ts '{4:yyyy-MM-dd HH:mm:ss}'}}, 'EXCONT\{5}')", _
                    docPath, CInt(Me.Id), C2.ToInt(Me("orderId")), docNum, docDate, userLogin))
                MyBase.MessageOutputDocumentNewEo(docNum, docDate, "EXCONT\" & userLogin, docPath, 1)
            End If

        Catch ex As Exception
            Throw ex
        Finally
            If Not R Is Nothing Then R.Dispose()
        End Try

    End Sub

End Class
