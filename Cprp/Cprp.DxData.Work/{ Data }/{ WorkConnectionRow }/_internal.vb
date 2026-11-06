Imports C2 = Cprp.DxData.Common
' ==============================
' Внутренние документы по работе
' ==============================
Partial Public Class WorkConnectionRow

    ''' <summary>
    ''' Перечитать содержимое поля внутренних документов по содержимому таблицы внутренних документов
    ''' </summary>
    Public Sub InternalFieldsUpdate()
        Me("isInt") = False
        For Each Row As DataRow In Me.InternalTable.Rows
            Select Case CType(Row("conditionId"), WorkCondition)
                Case WorkCondition.IsAgree : Me("isInt") = True : Exit Select
            End Select
        Next
    End Sub

    ''' <summary>
    ''' Создать проект документа
    ''' </summary>
    ''' <param name="Row">Строка таблицы документов</param>
    Public Sub InternalCreateProject(ByRef Row As DataRow)
        If Row Is Nothing OrElse Row.Table Is Nothing OrElse Not TypeOf Row.Table Is InternalDataTable Then Exit Sub

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

        ' ЗАГРУЗКА ШАБЛОНА ДОКУМЕНТА И ЗАПОЛНЕНИЕ ЕГО ДАННЫМИ
        ' +++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        ' Загрузка шаблона документа
        R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ЭКСКОНТВНУТРЕННИЙДОКУМЕНТ", Me.Connection)

        R.Document.BeginUpdate()

        ' Номер и дата документа
        PutBookmark(R.Document, "DocNum", Nothing, "{Проект}")
        PutBookmark(R.Document, "DocDate", String.Format("{0:dd.MM.yyyy}", Date.Today))

        ' Должность и ФИО руководителя
        Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT nameShort, leaderDescription FROM vUser WHERE id = {0}", C2.ToInt(Me("leaderId"))))
            If Dr.Read Then
                PutBookmark(R.Document, "LeaderJob", GetLeaderJobTo(C2.ToText(Dr("leaderDescription"))), "{нет данных}")
                PutBookmark(R.Document, "LeaderName", GetLeaderNameTo(C2.ToText(Dr("nameShort"))), "{нет данных}")
            Else
                PutBookmark(R.Document, "LeaderJob", Nothing, "{нет данных}")
                PutBookmark(R.Document, "LeaderName", Nothing, "{нет данных}")
            End If
        End Using

        ' Должность и ФИО эксперта
        Using Dr As SqlDataReader = Me.ExecuteReader(String.Format("SELECT nameShort, expertDescription FROM vUser WHERE id = {0}", C2.ToInt(Me("expertId"))))
            If Dr.Read Then
                PutBookmark(R.Document, "ExpertJob", C2.ToText(Dr("expertDescription")), "{нет данных}")
                PutBookmark(R.Document, "ExpertName", C2.ToText(Dr("nameShort")), "{нет данных}")
            Else
                PutBookmark(R.Document, "ExpertJob", Nothing, "{нет данных}")
                PutBookmark(R.Document, "ExpertName", Nothing, "{нет данных}")
            End If
        End Using

        ' Заголовок или краткое содержание документа
        PutBookmark(R.Document, "Caption", C2.ToText(Row("caption")))

        ' Завершение редактирования документа
        R.Document.EndUpdate()

        ' СОХРАНЕНИЕ ДОКУМЕНТА В ЯЧЕЙКУ СТРОКИ ТАБЛИЦЫ ДОКУМЕНТОВ
        ' +++++++++++++++++++++++++++++++++++++++++++++++++++++++
        '
        Row("docData") = R.OpenXmlBytes
        Row("userId") = CInt(Cprp.DxData.User.Common.CurrentUserId(Me.Connection))
        R.Dispose()

    End Sub

    ''' <summary>
    ''' Присвоить внутреннему документу регистрационный номер
    ''' </summary>
    ''' <param name="Row">Строка таблицы внутренних документов</param>
    Public Sub InternalSetRegNum(Row As DataRow)
        If Row Is Nothing OrElse Row.Table Is Nothing OrElse Not TypeOf Row.Table Is InternalDataTable Then Exit Sub
        '
        ' Переменные
        '
        Dim docId As Integer = 0                            ' Порядковый номер документа в таблице внутренних документов
        Dim regNum As String = Nothing                      ' Номер документа
        Dim regDate As Date = Date.Now                      ' Дата документа
        Dim caption As String = Nothing                     ' Наименование или краткое содержание документа
        Dim userId As Integer = 0                           ' ID регистратора документа
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Try
            '
            ' Инициализация переменных
            '
            docId = CInt(Me.ExecuteScalar(String.Format( _
                                          "SELECT ISNULL(MAX(docId), 0) FROM tWorkInternal WHERE regDate > {{ts '{0}-01-01 00:00:00'}}", _
                                          Date.Today.Year)))
            docId += 1
            caption = C2.ToText(Row("caption"), 250)
            If String.IsNullOrWhiteSpace(caption) Then caption = "[без наименования]"
            regNum = String.Format("Вн/{0:0000}-{1:yy}", docId, regDate)
            userId = CInt(Cprp.DxData.User.Common.CurrentUserId(Me.Connection))
            '
            ' Запись в базу данных сведений о новом документе
            '
            Me.ExecuteNonQuery(String.Format( _
                                 "INSERT tWorkInternal(workId, docId, regNum, regDate, caption, userId) " & _
                                 "VALUES({0}, {1}, '{2}', {{ts '{3:yyyy-MM-dd HH:mm:ss}'}}, '{4}', {5})",
                                 CInt(Me.Id), docId, regNum, regDate, caption.Replace("'", "''"), userId))
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
            ' Сохранение данных в строку таблицы внутренних документов
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
    ''' Создать документ из проекта внутреннего документа
    ''' </summary>
    ''' <param name="Row">Строка таблицы запросов</param>
    Public Sub InternalCreateDocument(ByRef Row As DataRow)
        If Row Is Nothing OrElse Row.Table Is Nothing OrElse Not TypeOf Row.Table Is InternalDataTable Then Exit Sub
        '
        ' Переменные
        '
        Dim userId As Integer = 0                           ' ID автора дркумента
        Dim userLogin As String = Nothing                   ' Логин автора
        Dim docPath As String = Nothing                     ' Полный путь к файлу документа
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Dim sTmp As String = Nothing
        Try
            '
            ' userLogin
            '
            userId = C2.ToInt(Row("userId"))
            If userId < 0 Then
                userId = CInt(Cprp.DxData.User.Common.CurrentUserId(Me.Connection))
                Row("userId") = userId
            End If
            Using Dr As SqlDataReader = Me.ExecuteReader(String.Format( _
                   "SELECT login FROM vUser WHERE id = {0}", userId))
                If Dr.Read Then
                    userLogin = C2.ToText(Dr("login"))
                End If
            End Using
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
            ' Создание файла документа
            ' ========================
            '
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Millimeter
            R.Document.OpenXmlBytes = Row("docData")
            Using Fs As New System.IO.FileStream(docPath, IO.FileMode.Create)
                R.ExportToPdf(Fs)
                Fs.Close()
            End Using
            '
            ' Отправка в ЭО сообщения о новом документе
            ' =========================================
            '
            MyClass.MessageOutputDocumentNewEo(Row("regNum").ToString, CDate(Row("regDate")), _
                                               "EXCONT\" & userLogin, docPath, 5, Nothing, Nothing, Nothing, 3)

        Catch ex As Exception
            Throw ex
        Finally
            If Not R Is Nothing Then R.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' Возвращает должность руководителя в дательном падеже
    ''' </summary>
    ''' <param name="job">Должность руководителя</param>
    Private Function GetLeaderJobTo(job As String) As String
        If job = "Заместитель руководителя Отдела экспертиз" Then Return "Заместителю руководителя Отдела экспертиз"
        If job = "Заместитель генерального директора" Then Return "Заместителю генерального директора"
        If job = "Генеральный директор" Then Return "Генеральному директору"
        If job = "Программист" Then Return "Программисту"
        Return job
    End Function

    ''' <summary>
    ''' Возвращает ФИО руководителя в дательном падеже
    ''' </summary>
    ''' <param name="name">ФИО</param>
    Private Function GetLeaderNameTo(name As String) As String
        If name = "Абрамов П.Л." Then Return "Абрамову П.Л."
        If name = "Щербич С.В." Then Return "Щербичу С.В."
        If name = "Усанов В.В." Then Return "Усанову В.В."
        If name = "Киракозов С.Н." Then Return "Киракозову С.Н."
        If name = "Пуганов П.В." Then Return "Пуганову П.В."
        Return name

    End Function

End Class

