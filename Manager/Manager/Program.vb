Imports DevExpress.XtraRichEdit.API.Native
Imports Cprp.DxData.Common
Friend Class Program

    ''' <summary>
    ''' Пользователь системы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared DbClient As Cprp.DxData.User.DatabaseUser = Nothing

    ''' <summary>
    ''' Путь к папке работ
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared WorkFolderPath As String = Nothing

    ''' <summary>
    ''' Общий таймер для всех компонентов приложения
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared Timer As Timer = Nothing

    ''' <summary>
    ''' Главная форма приложения
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared MainForm As MainForm = Nothing


    Private Sub New()
    End Sub


    <STAThread()> _
    Friend Shared Sub Main()
        '
        ' Application
        '
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Cprp.DxCommon.Application.EnableAppSkins()
        Cprp.DxCommon.Application.AppName = "ЭксКонт"
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        Cprp.DxCommon.Application.AppSkinColor = Color.Aquamarine
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(False)
        If Not DbClient.IsACT Then Exit Sub
        If Not DbClient.IsManager Then
            Cprp.DxCommon.Messages.ShowError("У Вас отсутствуют права для запуска данной программы.")
            Exit Sub
        End If
        '
        ' WorkFolderPath
        '
        Using Cmd As New SqlCommand With {.Connection = DbClient.Connection}
            Cmd.CommandText = "SELECT strData FROM tResource WHERE name LIKE 'WORKFOLDERPATH'"
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then WorkFolderPath = Cprp.DxData.Common.ToText(Dr(0))
            End Using
        End Using
        If Cprp.DxData.Common.IsText(WorkFolderPath) AndAlso Not My.Computer.FileSystem.DirectoryExists(WorkFolderPath) Then
            WorkFolderPath = Nothing
        End If
        '
        ' Timer
        '
        Timer = New Timer
        Timer.Interval = 60000
        Timer.Start()
        '
        ' MainForm
        '
        MainForm = New MainForm
        '
        ' Run
        '
        Application.Run(MainForm)
        'Application.Run(New Form1)

    End Sub

    ' ''' <summary>
    ' ''' Пересчитать стоимость работы для АСЭ (старая версия)
    ' ''' </summary>
    ' ''' <param name="Row">Строка таблицы данных с данными работы</param>
    'Friend Shared Sub Arecalc0(Row As DataRow)
    '    If Row Is Nothing Then Exit Sub
    '    Dim workId As Integer = -1                  ' ID работы
    '    Dim orderNum As String = Nothing            ' Номер заказа
    '    Dim orderDate As Date = Nothing             ' Дата заказа
    '    Dim docNum As String = "-"                  ' Номера и даты заключений
    '    Dim matCount As Integer = 0                 ' Количество кодов ТН ВЭД материальных объектов экспертизы
    '    Dim infCount As Integer = 0                 ' Количество информационных объектов экспертизы
    '    Dim changeSourceId As Integer = 0           ' Причина внесения изменений (1 - заказчик / 2 - эксперт / 3 - продление срока действия заключения)
    '    Dim isUrgency As Boolean = False            ' Срочность
    '    Dim isPrice50 As Boolean = False            ' Вторая работа по заказу
    '    'Dim userFio As String = Nothing             ' И.О. Фамилия пользователя
    '    'Dim attorNum As String = Nothing            ' Номер и дата доверенности менеджера
    '    'Dim signature As Drawing.Image = Nothing    ' Факсимиле менеджера
    '    Dim price As Single = 0                     ' Стоимость без НДС
    '    Dim comment As String = Nothing             ' Комментарий к расчету
    '    Dim filePath As String = Nothing            ' Путь к файлу сохранения документа расчета

    '    Dim sTmp As String = Nothing
    '    '
    '    ' workId
    '    '
    '    If Row.Table.Columns.IndexOf("id") >= 0 Then
    '        workId = CInt(Row("id"))
    '    Else
    '        Cprp.DxCommon.Messages.ShowError("Отсутствует номер работы.")
    '        Exit Sub
    '    End If
    '    '
    '    ' orderNum, orderDate
    '    '
    '    If Row.Table.Columns.IndexOf("orderNum") >= 0 AndAlso Not IsDBNull(Row("orderNum")) Then
    '        orderNum = Row("orderNum").ToString
    '    End If
    '    If Row.Table.Columns.IndexOf("orderDate") >= 0 AndAlso Not IsDBNull(Row("orderDate")) Then
    '        orderDate = CDate(Row("orderDate"))
    '    End If
    '    If String.IsNullOrWhiteSpace(orderNum) OrElse Not orderNum Like "05/1134*" Then
    '        Cprp.DxCommon.Messages.ShowError(String.Format("Работа № {0} не является работой по договору № 05/1134.", workId))
    '        Exit Sub
    '    End If
    '    '
    '    ' Путь к файлу данных работы
    '    '
    '    sTmp = String.Format("{0}\{1}.work", WorkFolderPath, workId.ToString)
    '    If Not My.Computer.FileSystem.FileExists(sTmp) Then
    '        Cprp.DxCommon.Messages.ShowError("Не найден файл данных работы.")
    '        Exit Sub
    '    End If
    '    '
    '    ' Путь к файлу сохранения данных расчета
    '    '
    '    Using Dlg As New SaveFileDialog
    '        Dlg.Title = "Укажите место сохранения файла расчета"
    '        Dlg.DefaultExt = "docx"
    '        Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
    '        Dlg.FileName = String.Format("Расчет стоимости работы {0} (АСЭ)", workId.ToString)
    '        If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
    '        filePath = Dlg.FileName
    '    End Using

    '    Cprp.DxCommon.WaitForm.Show(MainForm)
    '    Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
    '    '
    '    ' matCount, infCount, docNum, isUrgency, changeSourceId
    '    '
    '    Using Ds As New DataSet("WorkData")
    '        Ds.ReadXml(sTmp, XmlReadMode.ReadSchema)
    '        '
    '        ' matCount, infCount
    '        '
    '        Using V As New DataView(Ds.Tables("GoodTable"))
    '            V.RowFilter = "isUnreal = False"
    '            V.Sort = "tnved"
    '            For i As Integer = 0 To V.Count - 1
    '                sTmp = ToText(V(i)("tnved"))
    '                If String.IsNullOrWhiteSpace(sTmp) Then Continue For
    '                If sTmp Like "8523*" Then Continue For ' CD-диск для документации
    '                If sTmp Like "49*" Then
    '                    infCount += 1
    '                Else
    '                    If i = 0 OrElse sTmp <> ToText(V(i - 1)("tnved")) Then matCount += 1
    '                End If
    '            Next
    '        End Using
    '        '
    '        ' docNum, isUrgency
    '        '
    '        With Ds.Tables("ARow")
    '            If .Rows.Count > 0 Then
    '                '
    '                ' docNum
    '                '
    '                If Not IsDBNull(.Rows(0)("doc1RegNum")) Then
    '                    docNum = ToText(.Rows(0)("doc1RegNum"))
    '                    If Not IsDBNull(.Rows(0)("doc1RegDate")) Then
    '                        docNum = String.Format("{0} от {1:dd.MM.yyyy}", docNum, CDate(.Rows(0)("doc1RegDate")))
    '                    End If
    '                End If
    '                If Not IsDBNull(.Rows(0)("doc2RegNum")) Then
    '                    docNum = String.Format("{0}, {1}", docNum, ToText(.Rows(0)("doc2RegNum")))
    '                    If Not IsDBNull(.Rows(0)("doc2RegDate")) Then
    '                        docNum = String.Format("{0} от {1:dd.MM.yyyy}", docNum, CDate(.Rows(0)("doc2RegDate")))
    '                    End If
    '                End If
    '                '
    '                ' isUrgency
    '                '
    '                If IsDBNull(.Rows(0)("isUrgency")) Then isUrgency = CBool(.Rows(0)("isUrgency"))
    '                '
    '                ' changeSourceId
    '                '
    '                changeSourceId = ToInt(.Rows(0)("changeSourceId"))
    '            End If
    '        End With
    '    End Using
    '    '
    '    ' isPrice50
    '    '
    '    Using Cmd As SqlClient.SqlCommand = DbClient.Connection.CreateCommand
    '        Cmd.CommandText = String.Format( _
    '            "SELECT COUNT(*) FROM tWork WHERE typeId IN(1, 2, 3) AND id < {0} AND orderNum = '{1}'", workId, orderNum)
    '        isPrice50 = (CInt(Cmd.ExecuteScalar) > 0)
    '    End Using
    '    ''
    '    '' userFio
    '    ''
    '    'userFio = DbClient.NameShort
    '    'Dim arr() As String = userFio.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
    '    'If arr.Length > 1 Then userFio = String.Format("{0}{1}{2}", arr(1), Chr(160), arr(0))
    '    ''
    '    '' attorNum
    '    ''
    '    'Using Cmd As SqlCommand = DbClient.Connection.CreateCommand
    '    '    Cmd.CommandText = String.Format("SELECT attorNum, attorDate FROM tUserManager WHERE userId = {0}", DbClient.Id.ToString)
    '    '    Using Dr As SqlDataReader = Cmd.ExecuteReader
    '    '        If Dr.Read Then
    '    '            attorNum = ToText(Dr(0))
    '    '            'If IsText(sTmp) Then attorNum = String.Format("№ {0}", sTmp)
    '    '            sTmp = ToText(Dr(1))
    '    '            If IsText(sTmp) Then attorNum = String.Format("{0} от {1:dd.MM.yyyy}", attorNum, CDate(sTmp))
    '    '        End If
    '    '    End Using
    '    'End Using
    '    ''
    '    '' signature
    '    ''
    '    'signature = DbClient.Signature

    '    '
    '    ' Расчет стоимости работы
    '    '
    '    Select Case changeSourceId
    '        Case 2
    '            price = 0
    '            comment = "Ошибка эксперта"
    '        Case 1, 3
    '            price = 6000
    '            comment = "Фиксированная стоимость услуги"

    '        Case Else
    '            price = 15100
    '            comment = "15100"
    '            If matCount > 1 Then
    '                price += 900 * (matCount - 1)
    '                comment = String.Format("{0} + 900 * {1}", comment, matCount - 1)
    '            End If
    '            If infCount > 1 Then
    '                If infCount < 26 Then   ' со 2-го по 25-ый += 600
    '                    price += 600 * (infCount - 1)
    '                    comment = String.Format("{0} + 600 * {1}", comment, infCount - 1)
    '                Else
    '                    price += (600 * 24 + 250 * (infCount - 25)) ' с 26 += 250
    '                    comment = String.Format("{0} + 600 * 24 + 250 * {1}", comment, infCount - 25)
    '                End If
    '            End If
    '            If isUrgency Then
    '                price *= 2
    '                comment = String.Format("({0}) * 2", comment)
    '            End If
    '            If isPrice50 Then
    '                price /= 2
    '                comment = String.Format("({0}) / 2", comment)
    '            End If
    '            comment = String.Format("{0} = {1}", comment, price.ToString)
    '    End Select
    '    '
    '    ' Создание документа с расчетом
    '    '
    '    R.Unit = DevExpress.Office.DocumentUnit.Document
    '    R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
    '    'R.OpenXmlBytes = My.Resources.asecalc
    '    R.OpenXmlBytes = My.Resources.calcase
    '    R.Document.BeginUpdate()
    '    PutRange(R.Document.Bookmarks("workId").Range, ToText(workId))
    '    PutRange(R.Document.Bookmarks("orderNum").Range, String.Format("{0} от {1:dd.MM.yyyy}", orderNum, orderDate))
    '    PutRange(R.Document.Bookmarks("docNum").Range, ToText(docNum))
    '    PutRange(R.Document.Bookmarks("matCount").Range, If(matCount > 0, ToText(matCount), "-"))
    '    PutRange(R.Document.Bookmarks("infCount").Range, If(infCount > 0, ToText(infCount), "-"))
    '    PutRange(R.Document.Bookmarks("isAlteration").Range, If(changeSourceId = 1 OrElse changeSourceId = 2, "Да", "Нет"))
    '    PutRange(R.Document.Bookmarks("isLess").Range, If(changeSourceId = 3, "Да", "Нет"))
    '    PutRange(R.Document.Bookmarks("isUrgency").Range, If(CBool(isUrgency), "Да", "Нет"))
    '    PutRange(R.Document.Bookmarks("isPrice50").Range, If(CBool(isPrice50), "Да", "Нет"))
    '    PutRange(R.Document.Bookmarks("price").Range, ToText(price))
    '    PutRange(R.Document.Bookmarks("comment").Range, ToText(comment))
    '    'PutRange(R.Document.Bookmarks("attorNum").Range, attorNum)
    '    'If Not signature Is Nothing Then
    '    '    R.Document.Images.Insert(R.Document.Tables(1).Cell(0, 1).Range.Start, signature)
    '    'End If
    '    'PutRange(R.Document.Bookmarks("userFio").Range, userFio)
    '    R.Document.EndUpdate()
    '    R.Document.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
    '    R.Dispose()
    '    Cprp.DxCommon.WaitForm.Close()
    '    '
    '    ' Открытие файла документа
    '    '
    '    Using P As New Process
    '        P.StartInfo.FileName = filePath
    '        P.StartInfo.Verb = "Open"
    '        P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
    '        P.Start()
    '    End Using

    'End Sub

    ''' <summary>
    ''' Пересчитать стоимость работы для АСЭ
    ''' </summary>
    ''' <param name="Row">Строка таблицы данных с данными работы</param>
    Friend Shared Sub CalcAse(Row As DataRow)
        If Row Is Nothing Then Exit Sub
        '
        ' Проверка, что работа является идентификационной экспертизой по договору № 05/1134
        '
        If Row.Table.Columns.IndexOf("id") < 0 Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует номер работы.")
            Exit Sub
        ElseIf Row.Table.Columns.IndexOf("orderNum") < 0 Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует номер договора.")
            Exit Sub
        ElseIf Row.Table.Columns.IndexOf("typeId") < 0 Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует вид услуги.")
            Exit Sub
        ElseIf Not (ToText(Row("orderNum")) Like "05/1134*" AndAlso ToInt(Row("typeId")) = 1) Then
            Cprp.DxCommon.Messages.ShowError("Работа не является идентификационной экспертизой по договору № 05/1134.")
            Exit Sub
        End If

        Dim workId As Integer = -1                  ' ID работы
        Dim orderNum As String = Nothing            ' Номер заказа
        Dim orderDate As Date = Nothing             ' Дата заказа
        Dim docNum As String = "-"                  ' Номера и даты заключений
        Dim matCount As Integer = 0                 ' Количество кодов ТН ВЭД материальных объектов экспертизы
        Dim infCount As Integer = 0                 ' Количество информационных объектов экспертизы
        Dim changeSourceId As Integer = 0           ' Причина внесения изменений (1 - заказчик / 2 - эксперт / 3 - продление срока действия заключения)
        Dim isUrgency As Boolean = False            ' Срочность
        Dim isPrice50 As Boolean = False            ' Вторая работа по заказу
        Dim price As Single = 0                     ' Стоимость без НДС
        Dim priceNds As Single = 0                  ' Стоимость с НДС
        Dim comment As String = Nothing             ' Комментарий к расчету
        Dim filePath As String = Nothing            ' Путь к файлу сохранения документа расчета

        Dim sTmp As String = Nothing
        '
        ' workId, orderNum, orderDate
        '
        workId = CInt(Row("id"))
        orderNum = Row("orderNum").ToString
        orderDate = CDate(Row("orderDate"))
        '
        ' Путь к файлу сохранения данных расчета
        '
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Укажите место сохранения файла расчета"
            Dlg.DefaultExt = "docx"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
            Dlg.FileName = String.Format("Расчет стоимости работы {0} (АСЭ)", workId.ToString)
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using

        Cprp.DxCommon.WaitForm.Show(MainForm)

        Using Work As New Cprp.DxData.Work.Excont.WorkConnectionRow(workId, DbClient.Connection)
            If Work.IsEmpty Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowError("Работа не найдена.")
                Exit Sub
            End If
            '
            ' matCount, infCount
            '
            Using V As New DataView(Work.DS.Tables("GoodTable"))
                V.RowFilter = "isUnreal = False"
                V.Sort = "tnved"
                For i As Integer = 0 To V.Count - 1
                    sTmp = ToText(V(i)("tnved"))
                    If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                    If sTmp Like "8523*" Then Continue For ' CD-диск для документации
                    If sTmp Like "49*" Then
                        infCount += 1
                    Else
                        If i = 0 OrElse sTmp <> ToText(V(i - 1)("tnved")) Then matCount += 1
                    End If
                Next
            End Using
            '
            ' docNum, isUrgency
            '
            With Work.ARow
                If .Rows.Count > 0 Then
                    '
                    ' docNum
                    '
                    If Not IsDBNull(.Item("doc1RegNum")) Then
                        docNum = ToText(.Item("doc1RegNum"))
                        If Not IsDBNull(.Item("doc1RegDate")) Then
                            docNum = String.Format("{0} от {1:dd.MM.yyyy}", docNum, CDate(.Item("doc1RegDate")))
                        End If
                    End If
                    If Not IsDBNull(.Item("doc2RegNum")) Then
                        docNum = String.Format("{0}, {1}", docNum, ToText(.Item("doc2RegNum")))
                        If Not IsDBNull(.Item("doc2RegDate")) Then
                            docNum = String.Format("{0} от {1:dd.MM.yyyy}", docNum, CDate(.Item("doc2RegDate")))
                        End If
                    End If
                    '
                    ' isUrgency
                    '
                    If Not IsDBNull(.Item("isUrgency")) Then isUrgency = CBool(.Item("isUrgency"))
                    '
                    ' changeSourceId
                    '
                    changeSourceId = ToInt(.Item("changeSourceId"))
                End If
            End With
        End Using
        '
        ' isPrice50
        '
        Using Cmd As SqlClient.SqlCommand = DbClient.Connection.CreateCommand
            Cmd.CommandText = String.Format( _
                "SELECT COUNT(*) FROM tWork WHERE typeId IN(1, 2, 3) AND id < {0} AND orderNum = '{1}'", workId, orderNum)
            isPrice50 = (CInt(Cmd.ExecuteScalar) > 0)
        End Using
        '
        ' Расчет стоимости работы
        '
        Select Case changeSourceId
            Case 2
                price = 0
                comment = "Ошибка эксперта"
            Case 1, 3
                price = 6000
                comment = "Фиксированная стоимость услуги"
            Case 4
                price = 0
                comment = "Бесплатная (техническая) работа"

            Case Else
                price = 15100
                comment = "15100"
                If matCount > 1 Then
                    price += 900 * (matCount - 1)
                    comment = String.Format("{0} + 900 * {1}", comment, matCount - 1)
                End If
                If infCount > 1 Then
                    If infCount < 26 Then   ' со 2-го по 25-ый += 600
                        price += 600 * (infCount - 1)
                        comment = String.Format("{0} + 600 * {1}", comment, infCount - 1)
                    Else
                        price += (600 * 24 + 250 * (infCount - 25)) ' с 26 += 250
                        comment = String.Format("{0} + 600 * 24 + 250 * {1}", comment, infCount - 25)
                    End If
                End If
                If isUrgency Then
                    price *= 1.5
                    comment = String.Format("({0}) * 1.5", comment)
                End If
                If isPrice50 Then
                    price /= 2
                    comment = String.Format("({0}) / 2", comment)
                End If
                comment = String.Format("{0} = {1}", comment, price.ToString)
        End Select

        priceNds = price * 1.05
        '
        ' Создание документа с расчетом
        '
        Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Document
            R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
            'R.OpenXmlBytes = My.Resources.asecalc
            R.OpenXmlBytes = My.Resources.calcase
            R.Document.BeginUpdate()
            PutRange(R.Document.Bookmarks("workId").Range, ToText(workId))
            PutRange(R.Document.Bookmarks("orderNum").Range, String.Format("{0} от {1:dd.MM.yyyy}", orderNum, orderDate))
            PutRange(R.Document.Bookmarks("docNum").Range, ToText(docNum))
            PutRange(R.Document.Bookmarks("matCount").Range, If(matCount > 0, ToText(matCount), "-"))
            PutRange(R.Document.Bookmarks("infCount").Range, If(infCount > 0, ToText(infCount), "-"))
            PutRange(R.Document.Bookmarks("isAlteration").Range, If(changeSourceId = 1 OrElse changeSourceId = 2, "Да", "Нет"))
            PutRange(R.Document.Bookmarks("isLess").Range, If(changeSourceId = 3, "Да", "Нет"))
            PutRange(R.Document.Bookmarks("isUrgency").Range, If(CBool(isUrgency), "Да", "Нет"))
            PutRange(R.Document.Bookmarks("isPrice50").Range, If(CBool(isPrice50), "Да", "Нет"))
            PutRange(R.Document.Bookmarks("price").Range, ToText(price))
            PutRange(R.Document.Bookmarks("priceNds").Range, ToText(priceNds))
            PutRange(R.Document.Bookmarks("comment").Range, ToText(comment))
            R.Document.EndUpdate()
            R.Document.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        End Using
        Cprp.DxCommon.WaitForm.Close()
        '
        ' Открытие файла документа
        '
        Using P As New Process
            P.StartInfo.FileName = filePath
            P.StartInfo.Verb = "Open"
            P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            P.Start()
        End Using

    End Sub


    ''' <summary>
    ''' Пересчитать стоимость работы для ГСПИ
    ''' </summary>
    ''' <param name="Row">Строка таблицы данных с данными работы</param>
    Friend Shared Sub CalcGspiOld(Row As DataRow)
        If Row Is Nothing Then Exit Sub
        '
        ' Проверка, что работа является идентификационной экспертизой по договору № 01/22/128
        '
        If Row.Table.Columns.IndexOf("id") < 0 Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует номер работы.")
            Exit Sub
        ElseIf Row.Table.Columns.IndexOf("orderNum") < 0 Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует номер договора.")
            Exit Sub
        ElseIf Row.Table.Columns.IndexOf("typeId") < 0 Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует вид услуги.")
            Exit Sub
        ElseIf Not (ToText(Row("orderNum")) Like "01/22/128*" AndAlso ToInt(Row("typeId")) = 1) Then
            Cprp.DxCommon.Messages.ShowError("Работа не является идентификационной экспертизой по договору № 01/22/128.")
            Exit Sub
        End If

        Dim workId As Integer = -1                  ' ID работы
        Dim orderNum As String = Nothing            ' Номер заказа
        Dim orderDate As Date = Nothing             ' Дата заказа
        Dim docNum As String = "-"                  ' Номера и даты заключений
        Dim matCount As Integer = 0                 ' Количество материальных объектов экспертизы
        Dim infCount As Integer = 0                 ' Количество информационных объектов экспертизы
        Dim matCount2 As Integer = 0                ' Количество уникальных описаний материальных объектов экспертизы
        Dim infCount2 As Integer = 0                ' Количество уникальных описаний информационных объектов экспертизы
        Dim changeSourceId As Integer = 0           ' Причина внесения изменений (1 - заказчик / 2 - эксперт / 3 - продление срока действия заключения)
        Dim isUrgency As Boolean = False            ' Срочность
        Dim isPrice50 As Boolean = False            ' Вторая работа по заказу
        Dim price As Single = 0                     ' Стоимость без НДС
        Dim comment As String = Nothing             ' Комментарий к расчету
        Dim filePath As String = Nothing            ' Путь к файлу сохранения документа расчета

        Dim sTmp As String = Nothing
        '
        ' workId, orderNum, orderDate
        '
        workId = CInt(Row("id"))
        orderNum = Row("orderNum").ToString
        orderDate = CDate(Row("orderDate"))
        '
        ' Путь к файлу сохранения данных расчета
        '
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Укажите место сохранения файла расчета"
            Dlg.DefaultExt = "docx"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
            Dlg.FileName = String.Format("Расчет стоимости работы {0} (ГСПИ", workId.ToString)
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using

        Cprp.DxCommon.WaitForm.Show(MainForm)

        ' Товары - объекты
        Dim GroupTable As New DataTable
        With GroupTable
            .Columns.Add("groupNum", GetType(Integer))
            .Columns.Add("goodNums", GetType(String))
            .Columns.Add("description", GetType(String))
            .PrimaryKey = New DataColumn() {.Columns("groupNum")}
        End With

        Using Work As New Cprp.DxData.Work.Excont.WorkConnectionRow(workId, DbClient.Connection)
            If Work.IsEmpty Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowError("Работа не найдена.")
                Exit Sub
            End If
            '
            ' matCount, infCount, matCount2, infCount2
            '
            Using V As New DataView(Work.DS.Tables("GoodTable"))
                V.RowFilter = "isUnreal = False"
                V.Sort = "description"
                For i As Integer = 0 To V.Count - 1
                    sTmp = ToText(V(i)("tnved"))
                    If String.IsNullOrWhiteSpace(sTmp) OrElse sTmp Like "*-*" OrElse sTmp Like "49*" Or sTmp Like "8523*" Then
                        infCount += 1
                        sTmp = ToText(V(i)("description"))
                        If i = 0 OrElse sTmp <> ToText(V(i - 1)("description")) Then infCount2 += 1
                    Else
                        matCount += 1
                        sTmp = ToText(V(i)("description"))
                        If i = 0 OrElse sTmp <> ToText(V(i - 1)("description")) Then matCount2 += 1
                    End If
                Next
                '
                ' Товары - объекты
                '
                Dim groupNum As Integer = 0
                Dim goodNums As String = Nothing
                Dim description As String = Nothing
                For i As Integer = 0 To V.Count - 1
                    If i = 0 Then
                        groupNum = 1
                        goodNums = ToText(V(i)("rowNum")) + ", "
                        description = ToText(V(i)("description"))
                        Continue For
                    End If
                    sTmp = ToText(V(i)("description"))
                    If sTmp = ToText(V(i - 1)("description")) Then
                        goodNums = String.Format("{0}{1}, ", goodNums, ToText(V(i)("rowNum")))
                    Else
                        GroupTable.Rows.Add(New Object() {groupNum, goodNums.Substring(0, goodNums.Length - 2), description})
                        groupNum += 1
                        goodNums = ToText(V(i)("rowNum")) + ", "
                        description = ToText(V(i)("description"))
                    End If
                    If i = (V.Count - 1) Then
                        GroupTable.Rows.Add(New Object() {groupNum, goodNums.Substring(0, goodNums.Length - 2), description})
                    End If
                Next

            End Using
            '
            ' docNum, isUrgency
            '
            With Work.ARow
                If .Rows.Count > 0 Then
                    '
                    ' docNum
                    '
                    If Not IsDBNull(.Item("doc1RegNum")) Then
                        docNum = ToText(.Item("doc1RegNum"))
                        If Not IsDBNull(.Item("doc1RegDate")) Then
                            docNum = String.Format("{0} от {1:dd.MM.yyyy}", docNum, CDate(.Item("doc1RegDate")))
                        End If
                    End If
                    If Not IsDBNull(.Item("doc2RegNum")) Then
                        docNum = String.Format("{0}, {1}", docNum, ToText(.Item("doc2RegNum")))
                        If Not IsDBNull(.Item("doc2RegDate")) Then
                            docNum = String.Format("{0} от {1:dd.MM.yyyy}", docNum, CDate(.Item("doc2RegDate")))
                        End If
                    End If
                    '
                    ' isUrgency
                    '
                    If Not IsDBNull(.Item("isUrgency")) Then isUrgency = CBool(.Item("isUrgency"))
                    '
                    ' changeSourceId
                    '
                    changeSourceId = ToInt(.Item("changeSourceId"))
                End If
            End With
        End Using
        '
        ' isPrice50
        '
        Using Cmd As SqlClient.SqlCommand = DbClient.Connection.CreateCommand
            Cmd.CommandText = String.Format( _
                "SELECT COUNT(*) FROM tWork WHERE typeId IN(1, 2, 3) AND id < {0} AND orderNum = '{1}'", workId, orderNum)
            isPrice50 = (CInt(Cmd.ExecuteScalar) > 0)
        End Using
        '
        ' Расчет стоимости работы
        '
        Select Case changeSourceId
            Case 2
                price = 0
                comment = "Ошибка эксперта"
            Case 1, 3
                Using Cmd As SqlClient.SqlCommand = DbClient.Connection.CreateCommand
                    Cmd.CommandText = String.Format( _
                        "SELECT price FROM tWork WHERE id = '{0}'", workId)
                    price = ToSng(Cmd.ExecuteScalar)
                End Using
                comment = "Расчет по общему тарифному плану"
            Case 4
                price = 0
                comment = "Бесплатная (техническая) работа"

            Case Else
                price = 2800 * (matCount2 + infCount2)
                comment = String.Format("2800 * ({0} + {1}) = {2}", matCount2, infCount2, price.ToString)
        End Select
        '
        ' Создание документа с расчетом
        '
        Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Document
            R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
            'R.OpenXmlBytes = My.Resources.asecalc
            R.OpenXmlBytes = My.Resources.calcgspi
            R.Document.BeginUpdate()
            PutRange(R.Document.Bookmarks("workId").Range, ToText(workId))
            PutRange(R.Document.Bookmarks("orderNum").Range, String.Format("{0} от {1:dd.MM.yyyy}", orderNum, orderDate))
            PutRange(R.Document.Bookmarks("docNum").Range, ToText(docNum))
            PutRange(R.Document.Bookmarks("matCount").Range, ToText(matCount))
            PutRange(R.Document.Bookmarks("infCount").Range, ToText(infCount))
            PutRange(R.Document.Bookmarks("matCount2").Range, ToText(matCount2))
            PutRange(R.Document.Bookmarks("infCount2").Range, ToText(infCount2))
            PutRange(R.Document.Bookmarks("isAlteration").Range, If(changeSourceId = 1 OrElse changeSourceId = 2, "Да", "Нет"))
            PutRange(R.Document.Bookmarks("isLess").Range, If(changeSourceId = 3, "Да", "Нет"))
            PutRange(R.Document.Bookmarks("isUrgency").Range, If(CBool(isUrgency), "Да", "Нет"))
            PutRange(R.Document.Bookmarks("isPrice50").Range, If(CBool(isPrice50), "Да", "Нет"))
            PutRange(R.Document.Bookmarks("price").Range, ToText(price))
            PutRange(R.Document.Bookmarks("comment").Range, ToText(comment))
            '
            ' Перечень объектов
            '       
            With R.Document.Tables(1)
                Using V As New DataView(GroupTable) With {.Sort = "groupNum"}
                    For i As Integer = 0 To V.Count - 1
                        If (i + 1) = .Rows.Count Then .Rows.Append()
                        R.Document.InsertText(.Rows(i + 1).Cells(0).ContentRange.Start, ToText(V(i)("groupNum")))
                        R.Document.InsertText(.Rows(i + 1).Cells(1).ContentRange.Start, ToText(V(i)("goodNums")))
                        R.Document.InsertText(.Rows(i + 1).Cells(2).ContentRange.Start, ToText(V(i)("description")))
                    Next
                End Using
            End With
            GroupTable.Dispose()
            R.Document.EndUpdate()
            R.Document.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        End Using
        Cprp.DxCommon.WaitForm.Close()
        '
        ' Открытие файла документа
        '
        Using P As New Process
            P.StartInfo.FileName = filePath
            P.StartInfo.Verb = "Open"
            P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            P.Start()
        End Using

    End Sub

    ''' <summary>
    ''' Пересчитать стоимость работы для ГСПИ
    ''' </summary>
    ''' <param name="Row">Строка таблицы данных с данными работы</param>
    Friend Shared Sub CalcGspi(Row As DataRow)
        If Row Is Nothing Then Exit Sub
        '
        ' Проверка, что работа является идентификационной экспертизой по договору № 049/17721-Д
        '
        If Row.Table.Columns.IndexOf("id") < 0 Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует номер работы.")
            Exit Sub
        ElseIf Row.Table.Columns.IndexOf("orderNum") < 0 Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует номер договора.")
            Exit Sub
        ElseIf Row.Table.Columns.IndexOf("typeId") < 0 Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует вид услуги.")
            Exit Sub
        ElseIf Not (ToText(Row("orderNum")) Like "049/17721-Д*" AndAlso ToInt(Row("typeId")) = 1) Then
            Cprp.DxCommon.Messages.ShowError("Работа не является идентификационной экспертизой по договору № 049/17721-Д.")
            Exit Sub
        End If

        Dim workId As Integer = -1                  ' ID работы
        Dim orderNum As String = Nothing            ' Номер заказа
        Dim orderDate As Date = Nothing             ' Дата заказа
        Dim docNum As String = "-"                  ' Номера и даты заключений
        Dim matCount As Integer = 0                 ' Количество материальных объектов экспертизы
        Dim infCount As Integer = 0                 ' Количество информационных объектов экспертизы
        Dim matCount2 As Integer = 0                ' Количество уникальных описаний материальных объектов экспертизы
        Dim infCount2 As Integer = 0                ' Количество уникальных описаний информационных объектов экспертизы
        Dim changeSourceId As Integer = 0           ' Причина внесения изменений (1 - заказчик / 2 - эксперт / 3 - продление срока действия заключения)
        Dim isUrgency As Boolean = False            ' Срочность
        Dim isPrice50 As Boolean = False            ' Вторая работа по заказу
        Dim price As Single = 0                     ' Стоимость без НДС
        Dim comment As String = Nothing             ' Комментарий к расчету
        Dim filePath As String = Nothing            ' Путь к файлу сохранения документа расчета

        Dim sTmp As String = Nothing
        '
        ' workId, orderNum, orderDate
        '
        workId = CInt(Row("id"))
        orderNum = Row("orderNum").ToString
        orderDate = CDate(Row("orderDate"))
        '
        ' Путь к файлу сохранения данных расчета
        '
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Укажите место сохранения файла расчета"
            Dlg.DefaultExt = "docx"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
            Dlg.FileName = String.Format("Расчет стоимости работы {0} (ГСПИ", workId.ToString)
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using

        Cprp.DxCommon.WaitForm.Show(MainForm)

        ' Товары - объекты
        Dim GroupTable As New DataTable
        With GroupTable
            .Columns.Add("groupNum", GetType(Integer))
            .Columns.Add("goodNums", GetType(String))
            .Columns.Add("description", GetType(String))
            .PrimaryKey = New DataColumn() {.Columns("groupNum")}
        End With

        Using Work As New Cprp.DxData.Work.Excont.WorkConnectionRow(workId, DbClient.Connection)
            If Work.IsEmpty Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowError("Работа не найдена.")
                Exit Sub
            End If
            '
            ' matCount, infCount, matCount2, infCount2
            '
            Using V As New DataView(Work.DS.Tables("GoodTable"))
                V.RowFilter = "isUnreal = False"
                V.Sort = "description"
                For i As Integer = 0 To V.Count - 1
                    sTmp = ToText(V(i)("tnved"))
                    If String.IsNullOrWhiteSpace(sTmp) OrElse sTmp Like "*-*" OrElse sTmp Like "49*" Or sTmp Like "8523*" Then
                        infCount += 1
                        infCount2 += 1
                        'sTmp = ToText(V(i)("description"))
                        'If i = 0 OrElse sTmp <> ToText(V(i - 1)("description")) Then infCount2 += 1
                    Else
                        matCount += 1
                        matCount2 += 1
                        'sTmp = ToText(V(i)("description"))
                        'If i = 0 OrElse sTmp <> ToText(V(i - 1)("description")) Then matCount2 += 1
                    End If
                Next
                '
                ' Товары - объекты
                '
                Dim groupNum As Integer = 0
                Dim goodNums As String = Nothing
                Dim description As String = Nothing
                For i As Integer = 0 To V.Count - 1
                    If i = 0 Then
                        groupNum = 1
                        goodNums = ToText(V(i)("rowNum")) + ", "
                        description = ToText(V(i)("description"))
                        Continue For
                    End If
                    sTmp = ToText(V(i)("description"))
                    If sTmp = ToText(V(i - 1)("description")) Then
                        goodNums = String.Format("{0}{1}, ", goodNums, ToText(V(i)("rowNum")))
                    Else
                        GroupTable.Rows.Add(New Object() {groupNum, goodNums.Substring(0, goodNums.Length - 2), description})
                        groupNum += 1
                        goodNums = ToText(V(i)("rowNum")) + ", "
                        description = ToText(V(i)("description"))
                    End If
                    If i = (V.Count - 1) Then
                        GroupTable.Rows.Add(New Object() {groupNum, goodNums.Substring(0, goodNums.Length - 2), description})
                    End If
                Next

            End Using
            '
            ' docNum, isUrgency
            '
            With Work.ARow
                If .Rows.Count > 0 Then
                    '
                    ' docNum
                    '
                    If Not IsDBNull(.Item("doc1RegNum")) Then
                        docNum = ToText(.Item("doc1RegNum"))
                        If Not IsDBNull(.Item("doc1RegDate")) Then
                            docNum = String.Format("{0} от {1:dd.MM.yyyy}", docNum, CDate(.Item("doc1RegDate")))
                        End If
                    End If
                    If Not IsDBNull(.Item("doc2RegNum")) Then
                        docNum = String.Format("{0}, {1}", docNum, ToText(.Item("doc2RegNum")))
                        If Not IsDBNull(.Item("doc2RegDate")) Then
                            docNum = String.Format("{0} от {1:dd.MM.yyyy}", docNum, CDate(.Item("doc2RegDate")))
                        End If
                    End If
                    '
                    ' isUrgency
                    '
                    If Not IsDBNull(.Item("isUrgency")) Then isUrgency = CBool(.Item("isUrgency"))
                    '
                    ' changeSourceId
                    '
                    changeSourceId = ToInt(.Item("changeSourceId"))
                End If
            End With
        End Using
        ''
        '' isPrice50
        ''
        'Using Cmd As SqlClient.SqlCommand = DbClient.Connection.CreateCommand
        '    Cmd.CommandText = String.Format( _
        '        "SELECT COUNT(*) FROM tWork WHERE typeId IN(1, 2, 3) AND id < {0} AND orderNum = '{1}'", workId, orderNum)
        '    isPrice50 = (CInt(Cmd.ExecuteScalar) > 0)
        'End Using
        '
        ' Расчет стоимости работы
        '
        Select Case changeSourceId
            Case 2
                price = 0
                comment = "Ошибка эксперта"
            Case 1, 3
                Using Cmd As SqlClient.SqlCommand = DbClient.Connection.CreateCommand
                    Cmd.CommandText = String.Format( _
                        "SELECT price FROM tWork WHERE id = '{0}'", workId)
                    price = ToSng(Cmd.ExecuteScalar)
                End Using
                comment = "Расчет по общему тарифному плану"
            Case 4
                price = 0
                comment = "Бесплатная (техническая) работа"

            Case Else
                Dim iTmp As Integer = 0                
                price = 8980
                comment = price.ToString
                For i As Integer = 2 To (matCount2 + infCount2) ' от 2, т.к. первый объект входит в базовую стоимость
                    If i < 5 Then : iTmp = 2290
                    ElseIf i < 8 Then : iTmp = 1850
                    ElseIf i < 11 Then : iTmp = 1520
                    ElseIf i < 26 Then : iTmp = 1300
                    ElseIf i < 51 Then : iTmp = 695
                    Else : iTmp = 585
                    End If
                    price += iTmp
                    comment = String.Format("{0} + {1}", comment, iTmp.ToString)
                Next
                comment = String.Format("{0} = {1}", comment, price.ToString)
        End Select
        '
        ' Создание документа с расчетом
        '
        Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.Unit = DevExpress.Office.DocumentUnit.Document
            R.LayoutUnit = DevExpress.XtraRichEdit.DocumentLayoutUnit.Document
            'R.OpenXmlBytes = My.Resources.asecalc
            R.OpenXmlBytes = My.Resources.calcgspi
            R.Document.BeginUpdate()
            PutRange(R.Document.Bookmarks("workId").Range, ToText(workId))
            PutRange(R.Document.Bookmarks("orderNum").Range, String.Format("{0} от {1:dd.MM.yyyy}", orderNum, orderDate))
            PutRange(R.Document.Bookmarks("docNum").Range, ToText(docNum))
            PutRange(R.Document.Bookmarks("matCount").Range, ToText(matCount))
            PutRange(R.Document.Bookmarks("infCount").Range, ToText(infCount))
            PutRange(R.Document.Bookmarks("matCount2").Range, ToText(matCount2))
            PutRange(R.Document.Bookmarks("infCount2").Range, ToText(infCount2))
            PutRange(R.Document.Bookmarks("isAlteration").Range, If(changeSourceId = 1 OrElse changeSourceId = 2, "Да", "Нет"))
            PutRange(R.Document.Bookmarks("isLess").Range, If(changeSourceId = 3, "Да", "Нет"))
            PutRange(R.Document.Bookmarks("isUrgency").Range, If(CBool(isUrgency), "Да", "Нет"))
            PutRange(R.Document.Bookmarks("isPrice50").Range, If(CBool(isPrice50), "Да", "Нет"))
            PutRange(R.Document.Bookmarks("price").Range, ToText(price))
            PutRange(R.Document.Bookmarks("comment").Range, ToText(comment))
            '
            ' Перечень объектов
            '
            With R.Document.Tables(1)
                Using V As New DataView(GroupTable) With {.Sort = "groupNum"}
                    For i As Integer = 0 To V.Count - 1
                        If (i + 1) = .Rows.Count Then .Rows.Append()
                        R.Document.InsertText(.Rows(i + 1).Cells(0).ContentRange.Start, ToText(V(i)("groupNum")))
                        R.Document.InsertText(.Rows(i + 1).Cells(1).ContentRange.Start, ToText(V(i)("goodNums")))
                        R.Document.InsertText(.Rows(i + 1).Cells(2).ContentRange.Start, ToText(V(i)("description")))
                    Next
                End Using
            End With
            GroupTable.Dispose()
            R.Document.EndUpdate()
            R.Document.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        End Using
        Cprp.DxCommon.WaitForm.Close()
        '
        ' Открытие файла документа
        '
        Using P As New Process
            P.StartInfo.FileName = filePath
            P.StartInfo.Verb = "Open"
            P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            P.Start()
        End Using

    End Sub

    ''' <summary>
    ''' Создать документ консультации по определению кода ТН ВЭД
    ''' </summary>
    ''' <param name="workId">Id работы</param>
    ''' <remarks></remarks>
    Friend Shared Sub CreateConsTnved(workId)
        '
        ' Выбор места для сохранения файла
        '
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Укажите место для сохранения файла документа"
            Dlg.DefaultExt = "docx"
            Dlg.Filter = "Файл Microsoft Word (*.docx)|*.docx"
            Dlg.FileName = String.Format("Консультация по определению кода ТН ВЭД ({0})", workId.ToString)
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        Dim Work As Cprp.DxData.Work.Tnved.WorkConnectionRow = Nothing
        Cprp.DxCommon.WaitForm.Show()
        Try
            Work = New Cprp.DxData.Work.Tnved.WorkConnectionRow(workId, Program.DbClient.Connection)
            Work.ProjectCreateExcont(filePath)
            Work.Dispose()
            Cprp.DxCommon.WaitForm.Close()
            If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Файл документа сохранен в папке ""{0}"". Открыть документ?", filePath)) = DialogResult.Yes Then
                Using P As New Process
                    P.StartInfo.FileName = filePath
                    P.StartInfo.Verb = "Open"
                    P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    P.Start()
                End Using
            End If
        Catch ex As Exception
            If Not Work Is Nothing Then Work.Dispose()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try

    End Sub

    Private Shared Sub PutRange(ByVal R As DocumentRange, ByVal rangeText As String, Optional ByVal errorText As String = Nothing)
        With R.BeginUpdateDocument
            .Replace(R, Nothing)
            If Not String.IsNullOrWhiteSpace(rangeText) Then
                .InsertText(R.Start, rangeText)
            ElseIf Not String.IsNullOrWhiteSpace(errorText) Then
                .InsertHtmlText(R.Start, String.Format("<span style='font-weight:bold;color:#ff0000'>{0}</style>", errorText))
            End If
        End With        
    End Sub

End Class

