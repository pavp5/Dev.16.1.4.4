Imports C2 = Cprp.DxData.Common
' +++++++++++
' План работы
' +++++++++++
Partial Public MustInherit Class WorkConnectionRow

    ''' <summary>
    ''' Создать документ плана работы (html)
    ''' </summary>
    Public Overridable Sub PlaneDocumentCreate()
        Dim nullText As String = "[нет данных]"     ' Стандартное сообщение об отсутствии данных

        Dim sTmp As String = Nothing
        Dim Row As DataRow = Nothing

        Dim Html As String = "<!DOCTYPE HTML><html>"
        '
        ' Head
        '
        Html &= "<head>" & vbCrLf
        Html &= String.Format("<title>План работы № {0}</title>", CInt(Me.Id)) & vbCrLf
        Html &= "<style>" & vbCrLf
        Html &= "* {font-family: Calibri,Arial; font-size: 13pt; border-color:black}" & vbCrLf
        Html &= "h1 {font-size:14pt; font-weight:bold; margin-top:0pt; margin-bottom:18pt; text-align:center}" & vbCrLf
        Html &= "h2 {font-size:13pt; font-weight:bold; margin-top:12pt; margin-bottom:3pt; text-align:left}" & vbCrLf
        Html &= "ul, ol {margin-left: 18pt; margin-top: 0pt; margin-bottom: 0pt;}" & vbCrLf
        Html &= "p {margin: 0pt;}" & vbCrLf
        Html &= "table {border-collapse: collapse; margin-top: 3pt;}" & vbCrLf
        Html &= "td {vertical-align: top; padding:4pt;}" & vbCrLf
        Html &= "th {font-weight: bold; text-align:center; vertical-align:top; padding:4pt;}" & vbCrLf
        Html &= "li {margin-top: 3pt;}" & vbCrLf
        Html &= "td li {margin-top: 0pt;}" & vbCrLf
        Html &= "</style>" & vbCrLf
        Html &= "</head>" & vbCrLf
        '
        ' Body
        '
        Html &= "<body>" & vbCrLf
        '
        ' Заголовок документа
        '
        Html &= String.Format("<h1>План работы № {0}</h1>", CInt(Me.Id)) & vbCrLf
        '
        ' Характеристики работы
        '
        Html &= "<h2>Характеристики работы:</h2>"
        Html &= "<table border='0'>"
        Html &= "<col><col>"
        Html &= "<tr>"
        Html &= "<td>Количество объектов исследования:</td>"
        sTmp = (CInt(Me.ARow("matCount")) + CInt(Me.ARow("infCount"))).ToString
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<td>Количество товаров:</td>"
        sTmp = C2.ToText(Me.ARow("goodCount"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        If Me.Type = WorkType.IsExCont Then
            Html &= "<tr>"
            Html &= "<td>Количество дополнительных работ:</td>"
            sTmp = C2.ToText(Me.ARow("addWorkCount"))
            Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
            Html &= "</tr>"
        End If
        Html &= "<tr>"
        Html &= "<td>Количество документов на ин. языке:</td>"
        sTmp = C2.ToText(Me.ARow("langCount"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<td>Срочная работа:</td>"
        Html &= String.Format("<td>{0}</td>", If(CBool(Me.ARow("isUrgency")), "Да", "Нет"))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<td>Коэффициент сложности:</td>"
        Html &= String.Format("<td>{0}</td>", Me.ARow("complexity").ToString)
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<td>Общая трудоемкость (мин.):</td>"
        sTmp = C2.ToText(Me.ARow("totalWork"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<td>Срок исполнения:</td>"
        sTmp = Nothing
        If Not IsDBNull(Me.ARow("expertTerm")) Then sTmp = Format("dd.MM.yyyy HH:mm", CDate(Me.ARow("expertTerm")))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "</table>"
        '
        ' Мероприятия по работе
        '
        Html &= "<h2>Мероприятия по работе:</h2>"
        Html &= "<table border='0'>"
        Html &= "<col><col>"
        Html &= "<tr>"
        Html &= "<td>Запрос дополнительной информации:</td>"
        Html &= String.Format("<td>{0}</td>", If(CBool(Me.ARow("isSendQuery")), "Да", "Нет"))
        Html &= "</tr>"
        Html &= "<td>Составление профилей иностранных участников:</td>"
        Html &= String.Format("<td>{0}</td>", If(CBool(Me.ARow("isMakeProfile")), "Да", "Нет"))
        Html &= "</tr>"
        Html &= "</table>"
        '
        ' Комментарий эксперта
        '
        Html &= "<h2>Комментарий эксперта:</h2>"
        sTmp = C2.ToText(Me.ARow("planeComment"))
        Html &= String.Format("<p>{0}</p>", If(C2.IsText(sTmp), sTmp, "-"))
        '
        ' Расчет стоимости работы
        '
        Html &= "<h2>Расчет стоимости работы:</h2>"
        Html &= "<table border='1'>"
        Html &= "<col><col>"
        Html &= "<tr>"
        Html &= "<th>Описание услуги</th>"
        Html &= "<th>Стоимость</th>"
        Html &= "</tr>"
        Using V As New DataView(Me.CalcTable) With {.Sort = "id"}
            For i As Integer = 0 To V.Count - 1
                sTmp = C2.ToText(V(i)("price"))
                If C2.IsText(sTmp) AndAlso Not IsDBNull(V(i)("priceG")) Then
                    sTmp = String.Format("{0} / {1}", sTmp, C2.ToText(V(i)("priceG")))
                End If
                Html &= "<tr>"
                Html &= String.Format("<td>{0}</td><td align='right'>{1}</td>", C2.ToText(V(i)("description")), sTmp)
                Html &= "</tr>"
            Next
        End Using
        Html &= "<tr>"
        Html &= "<td>ИТОГО:</td>"
        sTmp = C2.ToText(Me("price"))
        If C2.IsText(sTmp) AndAlso Not IsDBNull(Me.ARow("priceG")) Then
            sTmp = String.Format("{0}&nbsp;/&nbsp;{1}", sTmp, C2.ToText(Me.ARow("priceG")))
        Else
            sTmp = "-"
        End If
        Html &= String.Format("<td align='right'><b>{0}</b></td>", sTmp)
        Html &= "</tr>"
        Html &= "</table>"
        '
        ' Перечень документов
        '
        Html &= String.Format("<h2>Перечень документов ({0}):</h2>", If(CBool(Me.ARow("isDocRule")), "легитимность подтверждена", "легитимность не подтверждена"))
        Html &= "<ul id='el0'>"
        Using V As New DataView(Me.InDocTable)
            V.RowFilter = "isUsed = True"
            If V.Count > 0 Then
                V.Sort = "rowNum"
                Html &= "<ul>"
                For i As Integer = 0 To V.Count - 1
                    Html &= String.Format("<li>{0};</li>", GetHtmlInDocCaption(V(i).Row))
                Next
                Html &= "</ul>"
            Else
                Html &= "<p style='margin-left: 18pt;'>[документы отсутствуют]</p>"
            End If
        End Using
        '
        ' План составил, план утвердил
        '
        Html &= "<br>"
        Html &= "<table border='0'>"
        Html &= "<col><col>"
        Html &= "<tr>"
        Html &= "<td>План составил:</td>"
        sTmp = GetHtmlUserNameShort(Me("expertId"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "<tr>"
        Html &= "<td>План утвердил:</td>"
        sTmp = GetHtmlUserNameShort(Me("leaderId"))
        Html &= String.Format("<td>{0}</td>", If(C2.IsText(sTmp), sTmp, nullText))
        Html &= "</tr>"
        Html &= "</table>"
        '
        ' /body, /html
        '
        Html &= "</body>"
        Html &= "</html>"
        '
        ' Запись документа плана в данные работы
        '
        Me.ARow("planeData") = Html

    End Sub

    ''' <summary>
    ''' Создать подписанный файл плана документа (pdf) и передать сведения о нем в ЭО
    ''' </summary>
    Public Sub PlaneDocumentToEO()
        '
        ' Переменные
        '
        Dim docNum As String = Nothing              ' Номер документа
        Dim docDate As Date = Nothing               ' Дата документа
        Dim docPath As String = Nothing             ' Полный путь к файлу документа
        Dim leaderLogin As String = Nothing         ' Логин руководителя экспертизы
        Dim leaderEmail As String = Nothing         ' E-mail руководителя экспертизы
        Dim leaderPin As String = Nothing           ' Pin-код доступа к сертификату руководителя экспертизы
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Dim sTmp As String, iTmp As Integer

        Try
            ' Номер документа
            ' ===============
            '
            docNum = C2.ToText(Me.Id)

            ' Полный путь к файлу документа
            ' =============================
            '
            sTmp = Cprp.DxData.Resource.Resource.GetStrData("EOFOLDERPATH", Me.Connection)
            If Not (C2.IsText(sTmp) AndAlso My.Computer.FileSystem.DirectoryExists(sTmp)) Then
                Throw New Exception("Недоступна папка для сохранения файлов заключений.")
            End If
            If Not sTmp Like "*\" Then sTmp = String.Format("{0}\", sTmp)
            docPath = String.Format("{0}p{1}.pdf", sTmp, docNum)

            ' Логин руководителя экспертизы
            ' =============================
            '
            leaderLogin = "NULL"
            sTmp = C2.ToText(Me.ExecuteScalar(String.Format("SELECT login FROM tUser WHERE id = {0}", C2.ToInt(Me("leaderId")))))
            If C2.IsText(sTmp) Then leaderLogin = String.Format("'EXCONT\{0}'", sTmp)

            ' E-mail руководителя экспертизы
            ' ==============================
            '
            leaderEmail = C2.ToText(Me.ExecuteScalar(String.Format("SELECT email FROM tUser WHERE id = {0}", C2.ToInt(Me("leaderId")))))

            ' Pin-код доступа к сертификату руководителя экспертизы
            ' =====================================================
            '
            leaderPin = C2.ToText(Me.ExecuteScalar(String.Format("SELECT pin FROM tUser WHERE id = {0}", C2.ToInt(Me("leaderId")))))

            ' Создание файла с ЭП руководителя в формате pdf
            ' ==============================================
            '
            'Dim Cert As New Cprp.Signature.Certificate(sTmp)
            'Cert.Reason = "Верификация документа"
            'Cert.Location = String.Format("Заключение № {0} от {1:dd.MM.yyyy}", docNum, docDate)
            'Cert.Contact = leaderEmail
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Millimeter
            R.Document.BeginUpdate()
            R.Document.HtmlText = Me.ARow("planeData")
            R.Document.EndUpdate()
            Using Fs As New System.IO.FileStream(docPath, IO.FileMode.Create)
                R.ExportToPdf(Fs)
                Fs.Close()
            End Using
            'Cert.SignPdf(docPath, leaderPin, docDate)
            'Exit Sub

            ' Запись сведений о файле документа в таблицу взаимодействия с ЭО
            ' ===============================================================
            '
            ' Проверка наличия в таблице взаимодействия записи о документе
            iTmp = C2.ToInt(Me.ExecuteScalar(String.Format("SELECT id FROM tTaskDocument WHERE docUrl LIKE '%p{0}.pdf'", docNum)))
            ' Если запись существует - стереть номер версии и обновить поля
            If iTmp > 0 Then
                Me.ExecuteNonQuery(String.Format( _
                    "UPDATE tTaskDocument SET docUrl = '{0}', docVersion = NULL WHERE id = {1}", _
                    docPath, iTmp))
                MyClass.MessageOutputDocumentChangeEo(Nothing, Nothing, leaderLogin.Replace("'", Nothing), docPath, 2)
            Else
                Me.ExecuteNonQuery(String.Format( _
                    "INSERT tTaskDocument(docUrl, workId, orderId, headLogin) " & _
                    "VALUES('{0}', {1}, {2}, '{3}')", _
                    docPath, CInt(Me.Id), C2.ToInt(Me("orderId")), leaderLogin.Replace("'", Nothing)))
                MyClass.MessageOutputDocumentNewEo(Nothing, Nothing, leaderLogin.Replace("'", Nothing), docPath, 2)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            If Not R Is Nothing Then R.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' Возвращает ФИО лица
    ''' </summary>
    ''' <param name="userId">ID лица в таблице лиц</param> 
    Protected Function GetHtmlUserNameShort(userId As Object) As String
        Dim sTmp As String = Nothing
        Using Dr As SqlDataReader = _
            Me.ExecuteReader(String.Format("SELECT nameShort FROM tUser WHERE id = {0}", C2.ToInt(userId)))
            If Dr.Read Then sTmp = C2.ToText(Dr(0))
        End Using
        Return sTmp
    End Function

    ' ''' <summary>
    ' ''' Возвращает наименование представленного документа в формате html
    ' ''' </summary>
    ' ''' <param name="Row">Строка таблицы представленных документов</param>
    ' ''' <remarks></remarks>
    'Private Function GetHtmlInDocCaption(Row As DataRow) As String
    '    If Row Is Nothing OrElse Not Row.Table Is Me.InDocTable Then Return Nothing
    '    Dim sTmp As String = C2.DelPoint(Row("caption"))
    '    If Not C2.IsText(sTmp) Then sTmp = "[нет наименования документа]"
    '    Dim sTmp1 As String = C2.ToText(Row("regNum"))
    '    If C2.IsText(sTmp1) Then sTmp = String.Format("{0} № {1}", sTmp, sTmp1)
    '    sTmp1 = C2.ToText(Row("regDate"))
    '    If C2.IsText(sTmp1) Then sTmp = String.Format("{0} от {1:dd.MM.yyyy}", sTmp, CDate(sTmp1))
    '    Return sTmp
    'End Function

End Class
