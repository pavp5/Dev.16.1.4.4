Imports Cprp.DxData.Common
Imports Cprp.DxData.Work
Imports Cprp.DxData.Work.Excont
''' <summary>
''' Форма для тестирования различных функций системы
''' </summary>
Public Class TestForm

    Private Work As Cprp.DxData.Work.Excont.WorkConnectionRow = Nothing

    Private CountryTable As Cprp.DxData.Handbook.CountryDataTable = Nothing


    Public Sub New()
        InitializeComponent()
        CountryTable = New Cprp.DxData.Handbook.CountryDataTable(Program.DbClient.Connection)
        '
        ' Me
        '
        Me.CenterToScreen()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim price As Single = 9718.976
        Dim sprice As Single = 1943.785
        MessageBox.Show(String.Format("Полная стоимость - {0}. Надбавка за срочность - {1}", _
                                      Math.Round(1 * price, 2, MidpointRounding.AwayFromZero), _
                                      Math.Round(1 * sprice, 2, MidpointRounding.AwayFromZero)))


        'NewWorkCount()


        'If Work Is Nothing Then Work = New Cprp.DxData.Work.Excont.WorkConnectionRow(0, Program.DbClient.Connection)
        'Work.Id = 97329
        'WorkToXml(Work, "d:\data_expert")

        'WorkDocCancel(81130, CDate("16.07.2025"), CDate("16.07.2025"))
        'WorkDocCancel(91547, CDate("14.07.2025"), CDate("14.07.2025"))
        'EXDB8ToEXDB8Test()

        'InsertWorkParentIdEXDBA()
        'MyDocLoad()

        'Dim dTmp As Date = Date.Now
        'MsgBox(dTmp)
        'While dTmp.Minute Mod 10 <> 0
        '    dTmp = dTmp.AddMinutes(1)
        'End While
        'MsgBox(dTmp)
        'PlaneAcceptCount()
        'CloseAcceptWork()
        'LoadUserSignature()
        'InsertGuidFromEo()
        'EXDB8_Referance()
        'EmbargoMemberToBase()
        'EmbargoGoodToBase()
        'EmbargoGoodTnvedToBase()
        'UpdateOrgCountryId()
        'UpdateTWorkMember()
        'MemberBlackToBase()
        'DbMemberDublicateUpdate()
        'InsertWorkPid()
        'BlackT()
        'Dim T As New Cprp.DxData.Member.MemberDataTable
        'Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
        '    Cmd.CommandText = "SELECT * FROM tMember WHERE id = 72049"
        '    T.Load(Cmd.ExecuteReader)
        'End Using
        'My.Computer.FileSystem.WriteAllText("d:\72049.htm", T.GetRusProfileHtml(T.Rows(0), Program.DbClient.Connection), False)
        'Cprp.DxData.Member.Common.PersonUpdate("7825056737", Program.DbClient.Connection)
        'Tnved_311()
        'ExpertOrgFInfo()
        'CurrencyToBase()
        'UpdateTFInfoGoodFind()

        'MsgBox("OK")

    End Sub


    ''' <summary>
    ''' Количество новых работ за период
    ''' </summary>
    Private Sub NewWorkCount()
        Dim OldInnTable As New DataTable
        With OldInnTable
            .Columns.Add("clientInn", GetType(String))
            .PrimaryKey = New DataColumn() {.Columns("clientInn")}
        End With

        Dim WorkTable As New DataTable
        With WorkTable
            .Columns.Add("id", GetType(Integer))
            .Columns.Add("clientInn", GetType(String))
            .PrimaryKey = New DataColumn() {.Columns("id")}
        End With

        Using cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            cmd.CommandText = "SELECT DISTINCT clientInn FROM tWork WHERE typeId <> 99 AND typeId <> 117 AND orderDate > '2022-01-01' AND orderDate < '2025-01-01'"
            OldInnTable.Load(cmd.ExecuteReader)
            cmd.CommandText = "SELECT id, clientInn FROM tWork WHERE typeId <> 99 AND typeId <> 117 AND orderDate > '2025-01-01' AND orderDate < '2026-01-01'"
            WorkTable.Load(cmd.ExecuteReader)
        End Using

        Dim iCount As Integer = 0
        For Each Row As DataRow In WorkTable.Rows
            If IsNothing(OldInnTable.Rows.Find(Row("clientInn"))) Then iCount += 1
        Next

        WorkTable.Dispose()
        OldInnTable.Dispose()

        MsgBox(iCount.ToString)

    End Sub

    ''' <summary>
    ''' Аннулировать заключение по работе для включения в новый отчет
    ''' </summary>
    ''' <param name="workId">Номер работы</param>
    ''' <param name="docCancelDate">Дата прекращения срока действия заключения</param>
    ''' <param name="workCloseDate">Дата закрытия работы для включения в отчет за эту дату</param>
    Private Sub WorkDocCancel(workId As Integer, docCancelDate As Date, workCloseDate As Date)
        If MsgBox(String.Format("Аннулировать заключения по работе № {0}?", workId), MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        Work = New Excont.WorkConnectionRow(workId, Program.DbClient.Connection)
        If IsDBNull(Work.ARow("docTerm")) OrElse CDate(Work.ARow("docTerm")) > docCancelDate Then
            Work.ARow("docTerm") = docCancelDate
            Work("closeDate") = workCloseDate
            Work.DataSave()
        End If
        MsgBox("OK")
    End Sub

    ''' <summary>
    ''' Загрузить parentId работ из tWork EXDB8 в tWork EXDBA
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub InsertWorkParentIdEXDBA()
        Dim T As New DataTable
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = "SELECT id, parentId FROM tWork WHERE NOT parentId IS NULL"
            T.Load(Cmd.ExecuteReader)
        End Using
        Using CnA As New SqlClient.SqlConnection("Server=192.168.22.80;Database=EXDBA;Trusted_connection=Yes")
            CnA.Open()
            Using Cmd As SqlClient.SqlCommand = CnA.CreateCommand
                For i As Integer = 0 To T.Rows.Count - 1
                    Me.Text = String.Format("{0} из {1}", i + 1, T.Rows.Count)
                    Application.DoEvents()
                    Cmd.CommandText = String.Format("UPDATE tWork SET workParentId = {1} WHERE workId = {0}", CInt(T(i)("id")), CInt(T(i)("parentId")))
                    Cmd.ExecuteNonQuery()
                Next
            End Using
        End Using

        T.Dispose()
        MsgBox("OK")

    End Sub

    ''' <summary>
    ''' Выгрузить в папку мои заключения
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MyDocLoad()
        Dim startId As String = InputBox("Номер работы после которого начинать загрузку:", "Введите номер работы")
        If String.IsNullOrWhiteSpace(startId) OrElse Not IsNumeric(startId) Then Exit Sub

        If Work Is Nothing Then
            Work = New Cprp.DxData.Work.Excont.WorkConnectionRow(0, Program.DbClient.Connection)
        End If
        Dim sTmp As String = Nothing
        Using Dr As SqlClient.SqlDataReader = Work.ExecuteReader(String.Format("SELECT id FROM tWork WHERE expertId = 21 AND typeId = 1 AND conditionId in (6, 7) AND id > {0}", CInt(startId)))
            While Dr.Read
                sTmp = String.Format("{0} {1}", Dr(0).ToString, sTmp)
            End While
        End Using
        Dim arr() As String = sTmp.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
        Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
            For i As Integer = 0 To arr.GetUpperBound(0)
                Me.Text = String.Format("{0} из {1}", i + 1, arr.Length)
                Application.DoEvents()
                Work.Id = CInt(arr(i))
                If Not IsDBNull(Work.ARow("doc1Data")) Then
                    R.OpenXmlBytes = Work.ARow("doc1Data")
                    R.SaveDocument(String.Format("D:\{0}.docx", arr(i)), DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
                End If
                If Not IsDBNull(Work.ARow("doc2Data")) Then
                    R.OpenXmlBytes = Work.ARow("doc2Data")
                    R.SaveDocument(String.Format("D:\{0}(2).docx", arr(i)), DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
                End If
            Next
        End Using
        MsgBox("OK")
    End Sub

    ''' <summary>
    ''' Возвращает дополнительную информацию из заключения экспертизы
    ''' </summary>
    Private Sub GetDopInfo()
        Dim sTmp As String = InputBox("Введите номер заключения")
        If Not IsText(sTmp) Then Exit Sub
        If Work Is Nothing Then
            Work = New Cprp.DxData.Work.Excont.WorkConnectionRow(0, Program.DbClient.Connection)
        End If
        Work.Id = ToInt(Work.ExecuteScalar(String.Format("SELECT workId FROM tWorkDoc WHERE regNum LIKE '{0}%'", sTmp)))
        If Work.IsEmpty Then
            MsgBox("Работа не найдена")
        Else
            sTmp = ToText(Work.ARow("comment"))
            If IsText(sTmp) Then
                sTmp = sTmp.Replace(vbCrLf, " ")
            Else
                sTmp = ""
            End If
            Clipboard.Clear()
            Clipboard.SetText(sTmp)
            MsgBox(sTmp)
        End If
    End Sub


    ''' <summary>
    ''' Отчет по количеству утверждений планов работ в определенные часы в 2023 г.
    ''' </summary>
    Private Sub PlaneAcceptCount()
        Dim cnt0 As Integer = 0
        Dim cnt1 As Integer = 0
        Dim cnt2 As Integer = 0
        Dim cnt3 As Integer = 0
        Dim cnt4 As Integer = 0
        Dim cnt5 As Integer = 0
        Dim cnt6 As Integer = 0
        Dim cnt7 As Integer = 0
        Dim cnt8 As Integer = 0
        Dim cnt9 As Integer = 0
        Dim cnt10 As Integer = 0
        Dim cnt11 As Integer = 0
        Dim cnt12 As Integer = 0
        Dim cnt13 As Integer = 0
        Dim cnt14 As Integer = 0
        Dim cnt15 As Integer = 0
        Dim cnt16 As Integer = 0
        Dim cnt17 As Integer = 0
        Dim cnt18 As Integer = 0
        Dim cnt19 As Integer = 0
        Dim cnt20 As Integer = 0
        Dim cnt21 As Integer = 0
        Dim cnt22 As Integer = 0
        Dim cnt23 As Integer = 0
        Dim iTmp As Integer = 0
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = "SELECT workId, eventDate FROM tWorkHistory WHERE eventId = 23 AND workId > 59799"
            Using Dr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                While Dr.Read
                    iTmp = CDate(Dr("eventDate")).Hour
                    Select Case iTmp
                        Case 0 : cnt0 += 1
                        Case 1 : cnt1 += 1
                        Case 2 : cnt2 += 1
                        Case 3 : cnt3 += 1
                        Case 4 : cnt4 += 1
                        Case 5 : cnt5 += 1
                        Case 6 : cnt6 += 1
                        Case 7 : cnt7 += 1
                        Case 8 : cnt8 += 1
                        Case 9 : cnt9 += 1
                        Case 10 : cnt10 += 1
                        Case 11 : cnt11 += 1
                        Case 12 : cnt12 += 1
                        Case 13 : cnt13 += 1
                        Case 14 : cnt14 += 1
                        Case 15 : cnt15 += 1
                        Case 16 : cnt16 += 1
                        Case 17 : cnt17 += 1
                        Case 18 : cnt18 += 1
                        Case 19 : cnt19 += 1
                        Case 20 : cnt20 += 1
                        Case 21 : cnt21 += 1
                        Case 22 : cnt22 += 1
                        Case 23 : cnt23 += 1
                    End Select
                End While
            End Using
        End Using

        Dim sTmp As String = ""
        sTmp = String.Format("{0}От 0 до 1 час.{1}- {2};{3}", sTmp, vbTab, cnt0, vbCrLf)
        sTmp = String.Format("{0}От 1 до 2 час.{1}- {2};{3}", sTmp, vbTab, cnt1, vbCrLf)
        sTmp = String.Format("{0}От 2 до 3 час.{1}- {2};{3}", sTmp, vbTab, cnt2, vbCrLf)
        sTmp = String.Format("{0}От 3 до 4 час.{1}- {2};{3}", sTmp, vbTab, cnt3, vbCrLf)
        sTmp = String.Format("{0}От 4 до 5 час.{1}- {2};{3}", sTmp, vbTab, cnt4, vbCrLf)
        sTmp = String.Format("{0}От 5 до 6 час.{1}- {2};{3}", sTmp, vbTab, cnt5, vbCrLf)
        sTmp = String.Format("{0}От 6 до 7 час.{1}- {2};{3}", sTmp, vbTab, cnt6, vbCrLf)
        sTmp = String.Format("{0}От 7 до 8 час.{1}- {2};{3}", sTmp, vbTab, cnt7, vbCrLf)
        sTmp = String.Format("{0}От 8 до 9 час.{1}- {2};{3}", sTmp, vbTab, cnt8, vbCrLf)
        sTmp = String.Format("{0}От 9 до 10 час.{1}- {2};{3}", sTmp, vbTab, cnt9, vbCrLf)
        sTmp = String.Format("{0}От 10 до 11 час.{1}- {2};{3}", sTmp, vbTab, cnt10, vbCrLf)
        sTmp = String.Format("{0}От 11 до 12 час.{1}- {2};{3}", sTmp, vbTab, cnt11, vbCrLf)
        sTmp = String.Format("{0}От 12 до 13 час.{1}- {2};{3}", sTmp, vbTab, cnt12, vbCrLf)
        sTmp = String.Format("{0}От 13 до 14 час.{1}- {2};{3}", sTmp, vbTab, cnt13, vbCrLf)
        sTmp = String.Format("{0}От 14 до 15 час.{1}- {2};{3}", sTmp, vbTab, cnt14, vbCrLf)
        sTmp = String.Format("{0}От 15 до 16 час.{1}- {2};{3}", sTmp, vbTab, cnt15, vbCrLf)
        sTmp = String.Format("{0}От 16 до 17 час.{1}- {2};{3}", sTmp, vbTab, cnt16, vbCrLf)
        sTmp = String.Format("{0}От 17 до 18 час.{1}- {2};{3}", sTmp, vbTab, cnt17, vbCrLf)
        sTmp = String.Format("{0}От 18 до 19 час.{1}- {2};{3}", sTmp, vbTab, cnt18, vbCrLf)
        sTmp = String.Format("{0}От 19 до 20 час.{1}- {2};{3}", sTmp, vbTab, cnt19, vbCrLf)
        sTmp = String.Format("{0}От 20 до 21 час.{1}- {2};{3}", sTmp, vbTab, cnt20, vbCrLf)
        sTmp = String.Format("{0}От 21 до 22 час.{1}- {2};{3}", sTmp, vbTab, cnt21, vbCrLf)
        sTmp = String.Format("{0}От 22 до 23 час.{1}- {2};{3}", sTmp, vbTab, cnt22, vbCrLf)
        sTmp = String.Format("{0}От 23 до 24 час.{1}- {2};{3}", sTmp, vbTab, cnt23, vbCrLf)

        Clipboard.Clear()
        Clipboard.SetText(sTmp)

        MsgBox("OK")



    End Sub



    ''' <summary>
    ''' Закрыть готовые работы в ЭС отправить сообщения в ЭО
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CloseAcceptWork()
        Dim Work As New Cprp.DxData.Work.Excont.WorkConnectionRow(EMPTY_ID, Program.DbClient.Connection)
        Using T As New DataTable
            T.Columns.Add("id", GetType(Integer))
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
                Cmd.CommandText = "SELECT id FROM tWork WHERE typeId = 1 AND conditionId = 6"
                T.Load(Cmd.ExecuteReader)
            End Using
            For Each Row As DataRow In T.Rows
                Me.Text = Row("id").ToString
                Application.DoEvents()
                Work.Id = Row("id")
                Work.Condition = WorkCondition.IsClose
                Work("closeDate") = Date.Now
                Work.DataSave()
                Work.MessageWorkChangeEo()
            Next
        End Using

        MsgBox("OK")

    End Sub


    ''' <summary>
    ''' Обновить содержания работ в архивной базе данных
    ''' </summary>
    Private Sub FindAContentUpdate()
        If MsgBox("Обновить в EXDBA содержания работ с 01.01.2019?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Вопросец...") <> MsgBoxResult.Yes Then Exit Sub
        Dim WorkExcont As Cprp.DxData.Work.Excont.WorkConnectionRow = Nothing
        Dim WorkCustoms As Cprp.DxData.Work.Customs.WorkConnectionRow = Nothing
        Dim WorkLiconfirm As Cprp.DxData.Work.Liconfirm.WorkConnectionRow = Nothing
        Dim WorkTnved As Cprp.DxData.Work.Tnved.WorkConnectionRow = Nothing
        Dim WorkTable As DataTable = Nothing
        Try
            WorkExcont = New Cprp.DxData.Work.Excont.WorkConnectionRow(0, Program.DbClient.Connection)
            WorkCustoms = New Cprp.DxData.Work.Customs.WorkConnectionRow(0, Program.DbClient.Connection)
            WorkLiconfirm = New Cprp.DxData.Work.Liconfirm.WorkConnectionRow(0, Program.DbClient.Connection)
            WorkTnved = New Cprp.DxData.Work.Tnved.WorkConnectionRow(0, Program.DbClient.Connection)
            WorkTable = New DataTable("WorkTable")
            With WorkTable.Columns
                .Add("id", GetType(Integer))
                .Add("workId", GetType(Integer))
                .Add("typeId", GetType(Integer))
                .Add("refDataS", GetType(String))
            End With
            WorkTable.PrimaryKey = New DataColumn() {WorkTable.Columns("id")}
            Using CnA As New SqlClient.SqlConnection("Server=192.168.22.80;Database=EXDBA;Trusted_connection=Yes")
                CnA.Open()
                Using Cmd As SqlClient.SqlCommand = CnA.CreateCommand
                    Cmd.CommandText = "SELECT id, workId, typeId, refDataS FROM tWork WHERE id IN (SELECT workId FROM tOutDoc WHERE regDate >= {ts '2019-01-01 00:00:00'})"
                    WorkTable.Load(Cmd.ExecuteReader)
                End Using
                WorkTable.AcceptChanges()
                WorkTable.WriteXml(String.Format("{0}\{1:yyyyMMddHHmmss}-WorkTable.xml", Application.StartupPath, Date.Now))
                Using A As New SqlClient.SqlDataAdapter("SELECT id, workId, typeId, refDataS FROM tWork", CnA)
                    Dim B As New SqlClient.SqlCommandBuilder(A)
                    Dim iTmp As Integer = 1
                    For Each Row As DataRow In WorkTable.Rows
                        Me.Text = String.Format("{0} из {1}", iTmp, WorkTable.Rows.Count)
                        Application.DoEvents()
                        Select Case CInt(Row("typeId"))
                            Case 1
                                WorkExcont.Id = Row("workId")
                                If WorkExcont.IsEmpty Then Continue For
                                Row("refDataS") = WorkExcont.GetHtmlContent
                            Case 3
                                WorkCustoms.Id = Row("workId")
                                If WorkCustoms.IsEmpty Then Continue For
                                Row("refDataS") = WorkCustoms.GetHtmlContent
                            Case 4
                                WorkLiconfirm.Id = Row("workId")
                                If WorkLiconfirm.IsEmpty Then Continue For
                                Row("refDataS") = WorkLiconfirm.GetHtmlContent
                            Case 6
                                WorkTnved.Id = Row("workId")
                                If WorkTnved.IsEmpty Then Continue For
                                Row("refDataS") = WorkTnved.GetHtmlContent
                            Case Else
                                Continue For
                        End Select
                        A.Update(WorkTable)
                        iTmp += 1
                    Next
                End Using
            End Using
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        Finally
            If Not WorkExcont Is Nothing Then WorkExcont.Dispose()
            If Not WorkCustoms Is Nothing Then WorkCustoms.Dispose()
            If Not WorkLiconfirm Is Nothing Then WorkLiconfirm.Dispose()
            If Not WorkTnved Is Nothing Then WorkTnved.Dispose()
            If Not WorkTable Is Nothing Then WorkTable.Dispose()
        End Try
        MsgBox("OK")
    End Sub

    ''' <summary>
    ''' Создание html-файла содержания работы
    ''' </summary>
    Private Sub TestWorkContent()
        Using W As New Cprp.DxData.Work.Excont.WorkConnectionRow(0, Program.DbClient.Connection)
            W.Id = 6582
            With My.Computer.FileSystem
                Dim sTmp As String = .GetTempFileName
                .WriteAllText(sTmp, W.GetHtmlContent, False)
                .MoveFile(sTmp, "d:\cnt.htm", True)
            End With
        End Using
        MsgBox("OK")
    End Sub

    ''' <summary>
    ''' Обновить виды товаров по их категориям в базе данных
    ''' </summary>
    Private Sub UpdateGoodTypeByCategory()
        If Cprp.DxCommon.Messages.ShowQuestion("Обновить в базе данных виды товаров по их категориям?") <> Windows.Forms.DialogResult.Yes Then Exit Sub
        Me.Text = "Обновление видов товаров"
        Dim CnA As New SqlClient.SqlConnection("Server=192.168.22.80;Database=EXDBA;Trusted_connection=Yes")
        CnA.Open()
        Using T As New DataTable
            Using Cmd As New SqlClient.SqlCommand With {.Connection = Program.DbClient.Connection} '{.Connection = CnA} 
                Cmd.CommandText = "SELECT id, categoryId FROM tGood WHERE typeId IS NULL AND NOT categoryId IS NULL"
                T.Load(Cmd.ExecuteReader)
                Dim typeId As Integer = 0
                Dim iCount As Integer = 0
                For Each Row As DataRow In T.Rows
                    Select Case CInt(Row("categoryId"))
                        Case 1 : typeId = 1
                        Case 2 : typeId = 2
                        Case 3 : typeId = 3
                        Case 4 : typeId = 4
                        Case 5 : typeId = 6
                        Case 6 : typeId = 6
                        Case 7 : typeId = 8
                        Case 8 : typeId = 8
                        Case 9 : typeId = 8
                        Case 10 : typeId = 9
                        Case Else
                            Continue For
                    End Select
                    Cmd.CommandText = String.Format("UPDATE tGood SET typeId = {0} WHERE id = {1}", typeId, CInt(Row("id")))
                    Cmd.ExecuteNonQuery()
                    iCount += 1
                    Me.Text = String.Format("{0} из {1}", iCount, T.Rows.Count)
                    Application.DoEvents()
                Next
            End Using
        End Using
        MsgBox("OK")
    End Sub


    ''' <summary>
    ''' Обновить таблицу кодов ТН ВЭД в контрольных списках по кодам товаров в исследованиях
    ''' </summary>
    Private Sub UpdateLawTnved()
        If Cprp.DxCommon.Messages.ShowQuestion("Обновить таблицу tLawTnved по результатам исследований?") <> Windows.Forms.DialogResult.Yes Then Exit Sub
        Dim Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
        Dim lawId As Integer = 0
        Dim tnved As String = Nothing
        Dim iTmp As Integer = 0
        Dim T As New DataTable
        Cmd.CommandText = "SELECT DISTINCT lawId, tnved FROM vGoodTnvedLaw WHERE summaryId > 0 AND LEN(tnved) > 3"
        T.Load(Cmd.ExecuteReader)
        For Each Row As DataRow In T.Rows
            lawId = CInt(Row("lawId"))
            tnved = Trim(Row("tnved").ToString)
            iTmp += 1
            If tnved.Length < 4 OrElse tnved Like "49*" OrElse tnved Like "8523*" Then Continue For
            Me.Text = String.Format("{0} из {1}", iTmp, T.Rows.Count)
            Application.DoEvents()
            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tLawTnved WHERE lawId = {0} AND tnved = '{1}'", lawId, tnved)
            If CInt(Cmd.ExecuteScalar) > 0 Then Continue For
            Cmd.CommandText = String.Format("INSERT tLawTnved (lawId, tnved, is2) VALUES ({0}, '{1}', 1)", lawId, tnved)
            Cmd.ExecuteNonQuery()
        Next
        MsgBox("OK")
    End Sub


    ''' <summary>
    ''' Загрузить перечень лиц по запретам и ограничениям из файла MS Word в базу данных
    ''' </summary>
    Private Sub EmbargoMemberToBase()
        If MsgBox("Загрузить данные в tEmbargoMember?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Вопрос") <> MsgBoxResult.Yes Then Exit Sub
        Dim T As New DataTable
        With T.Columns
            .Add("id", GetType(Integer))
            .Add("embargoId", GetType(Integer))
            .Add("caption", GetType(String))
            .Add("description", GetType(String))
            .Add("countryId", GetType(Integer))
            .Add("modeId", GetType(Integer))
            .Add("isACT", GetType(Boolean))
        End With
        T.Columns("countryId").AllowDBNull = False
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        Dim Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
        Dim Row As DataRow = Nothing
        Dim startId As Integer = 0
        Cmd.CommandText = "SELECT MAX(id) FROM tEmbargoMember"
        startId = CInt(Cmd.ExecuteScalar) + 1
        'Dim CountryTable As New Cprp.DxData.Handbook.CountryDataTable(Program.DbClient.Connection)
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.LoadDocument("d:\Таблица2.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        'With R.Document.Tables(0)
        '    For i As Integer = 0 To .Rows.Count - 1
        '        R.Document.InsertText(.Cell(i, 3).ContentRange.Start, _
        '                              Cprp.DxData.Common.ToText(CountryTable.GetIdByNameShort(Cprp.DxData.Common.DbText(R.Document.GetText(.Cell(i, 1).ContentRange)))))
        '    Next
        'End With
        'R.Document.SaveDocument("d:\Таблица2.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)

        With R.Document.Tables(0)
            For i As Integer = 0 To .Rows.Count - 1
                Row = T.NewRow
                Row("id") = startId + i
                Row("embargoId") = 35
                Row("modeId") = 3
                Row("isACT") = True
                Row("caption") = Cprp.DxData.Common.DbText(R.Document.GetText(.Cell(i, 0).ContentRange))
                Row("description") = Cprp.DxData.Common.DbText(R.Document.GetText(.Cell(i, 2).ContentRange))
                Row("countryId") = Cprp.DxData.Common.DbInt(R.Document.GetText(.Cell(i, 3).ContentRange))
                T.Rows.Add(Row)
            Next
        End With
        Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tEmbargoMember", Program.DbClient.Connection)
            Dim B As New SqlClient.SqlCommandBuilder(A)
            A.Update(T)
        End Using
        R.Dispose()
        T.Dispose()
        Cmd.Dispose()

        MsgBox("OK")

    End Sub


    ''' <summary>
    ''' Загрузить перечень товаров с запретами и ограничениями из tLaw в tEmbargoGood
    ''' </summary>
    Private Sub EmbargoGoodToBase()
        If MsgBox("Загрузить данные в tEmbargoGood?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Вопрос") <> MsgBoxResult.Yes Then Exit Sub

        Dim embargoId As Integer = 38                           ' id документа в tEmbargo
        Dim lawIdBegin As Integer = 45842                       ' id первой строки документа (раздела документа) в tLaw
        Dim lawIdEnd As Integer = 45854                         ' id последней строки документа (раздела документа) в tLaw
        Dim appendName As String = vbCrLf & "(Приложение 6)"    ' краткое наименование раздела документа

        ' Таблица товаров из tLaw
        Dim LawGoodTable As New DataTable
        With LawGoodTable
            With .Columns
                .Add("id", GetType(Integer))
                .Add("parentId", GetType(Integer))
                .Add("description", GetType(String))
                .Add("tnved", GetType(String))
                .Add("modeId", GetType(Integer))
            End With
            .PrimaryKey = New DataColumn() {.Columns("id")}
        End With

        ' Таблица кодов ТН ВЭД товаров из tLaw
        Dim LawGoodTnvedTable As New DataTable
        With LawGoodTnvedTable
            With .Columns
                .Add("lawId", GetType(Integer))
                .Add("tnved", GetType(String))
            End With
            .PrimaryKey = New DataColumn() {.Columns("id"), .Columns("tnved")}
        End With

        ' Таблица товаров из tEmbargoGood
        Dim EmbargoGoodTable As New DataTable
        With EmbargoGoodTable
            With .Columns
                .Add("id", GetType(Integer))
                .Add("embargoId", GetType(Integer))
                .Add("caption", GetType(String))
                .Add("tnved", GetType(String))
                .Add("modeId", GetType(Integer))
                .Add("isACT", GetType(Boolean))
                .Add("lawId", GetType(Integer))     ' id товара из tLaw
            End With
            .PrimaryKey = New DataColumn() {.Columns("id")}
        End With

        Dim Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand

        ' Загрузка товаров из tLaw
        Cmd.CommandText = String.Format("SELECT id, parentId, posDescription AS description, tnved, modeId FROM vLaw WHERE typeId = 1 AND id >= {0} AND id <= {1}", lawIdBegin, lawIdEnd)
        LawGoodTable.Load(Cmd.ExecuteReader)

        ' Загрузка кодов ТН ВЭД товаров из tLawTnved
        Dim Row As DataRow = Nothing
        For Each Row In LawGoodTable.Rows
            Cmd.CommandText = String.Format("SELECT LawId, tnved FROM tLawTnved WHERE lawId = {0}", CInt(Row("id")))
            LawGoodTnvedTable.Load(Cmd.ExecuteReader)
        Next

        ' Удаление старых данных
        If Cprp.DxCommon.Messages.ShowQuestion("Удалить старые данные из документа?") = Windows.Forms.DialogResult.Yes Then
            Cmd.CommandText = String.Format("DELETE FROM tEmbargoGood WHERE embargoId = {0}", embargoId)
            Cmd.ExecuteNonQuery()
        End If

        ' Заполнение данными EmbargoGoodTable
        Dim id As Integer = 0
        Cmd.CommandText = "SELECT ISNULL(MAX(id), 0) FROM tEmbargoGood"
        id = CInt(Cmd.ExecuteScalar) + 1
        Dim caption As String = Nothing
        Dim ParentRow As DataRow = Nothing
        Dim parentId As Integer = EMPTY_ID
        For Each Row In LawGoodTable.Rows
            ' товары без кодов пропускаются
            If Not IsText(Row("tnved")) Then Continue For
            ' формирование полного описания товара
            caption = Row("description")
            ParentRow = Row
            Do
                ParentRow = LawGoodTable.Rows.Find(ToInt(ParentRow("parentId")))
                If ParentRow Is Nothing Then Exit Do
                caption = String.Format("{0}{1}{2}", ToText(ParentRow("description")), vbCrLf, caption)
            Loop
            caption &= appendName
            ' добавление строки в EmbargoGoodTable
            EmbargoGoodTable.Rows.Add(New Object() {id, embargoId, caption, Row("tnved"), Row("modeId"), True, Row("id")})
            id += 1
        Next

        ' Запись данных в tEmbargoGood
        Cmd.ExecuteNonQuery()
        Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tEmbargoGood", Program.DbClient.Connection)
            Dim B As New SqlClient.SqlCommandBuilder(A)
            A.Update(EmbargoGoodTable)
        End Using

        ' Запись данных в tEmbargoGoodTnved
        Using V As New DataView(LawGoodTnvedTable)
            For Each Row In EmbargoGoodTable.Rows
                V.RowFilter = String.Format("lawId = {0}", CInt(Row("lawId")))
                For Each VRow As DataRowView In V
                    Cmd.CommandText = String.Format("INSERT tEmbargoGoodTnved(goodId, tnved) VALUES({0}, '{1}')", CInt(Row("id")), ToText(VRow("tnved")))
                    Cmd.ExecuteNonQuery()
                Next
            Next
        End Using

        Cmd.Dispose()
        LawGoodTnvedTable.Dispose()
        LawGoodTable.Dispose()
        EmbargoGoodTable.Dispose()

        MsgBox("OK")

    End Sub

    ''' <summary>
    ''' Загрузить перечень кодов ТН ВЭД товаров с запретами и ограничениями из файла MS Word в базу данных
    ''' </summary>
    Private Sub EmbargoGoodTnvedToBase()
        If MsgBox("Загрузить данные в tEmbargoGoodTnved?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Вопрос") <> MsgBoxResult.Yes Then Exit Sub
        Dim goodId As Integer = EMPTY_ID
        Dim arr() As String = Nothing
        Dim sTmp As String = Nothing
        Dim Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.LoadDocument("d:\3130.0002.0002.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)

        With R.Document.Tables(0)
            For i As Integer = 0 To .Rows.Count - 1
                goodId = ToInt(R.Document.GetText(.Cell(i, 0).ContentRange))
                '
                ' tEmbargoGoodTnved, tEmbargoGood
                '
                sTmp = ToText(R.Document.GetText(.Cell(i, 2).ContentRange))
                If Not String.IsNullOrWhiteSpace(sTmp) Then
                    arr = sTmp.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                    For Each sTmp In arr
                        Cmd.CommandText = String.Format("DELETE FROM tEmbargoGoodTnved WHERE goodId = {0} AND tnved = '{1}'", goodId, sTmp)
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = String.Format("INSERT tEmbargoGoodTnved (goodId, tnved) VALUES ({0}, '{1}')", goodId, sTmp)
                        Cmd.ExecuteNonQuery()
                    Next
                End If
                '
                ' tEmbargoGoodTnvedNot
                '
                sTmp = ToText(R.Document.GetText(.Cell(i, 3).ContentRange))
                If Not String.IsNullOrWhiteSpace(sTmp) Then
                    arr = sTmp.Split(New Char() {" "}, StringSplitOptions.RemoveEmptyEntries)
                    For Each sTmp In arr
                        Cmd.CommandText = String.Format("DELETE FROM tEmbargoGoodTnvedNot WHERE goodId = {0} AND tnved = '{1}'", goodId, sTmp)
                        Cmd.ExecuteNonQuery()
                        Cmd.CommandText = String.Format("INSERT tEmbargoGoodTnvedNot (goodId, tnved) VALUES ({0}, '{1}')", goodId, sTmp)
                        Cmd.ExecuteNonQuery()
                    Next
                End If
            Next
        End With
        R.Dispose()
        Cmd.Dispose()

        MsgBox("OK")

    End Sub

    ''' <summary>
    ''' Убрать дубликаты российских лиц в таблице tMember базы данных
    ''' </summary>
    ''' <remarks>
    ''' Поиск дубликатов осуществляется по ИНН.
    ''' Последняя запись считается актуальной, остальные записи помечаются как неактуальные.
    ''' </remarks>
    Private Sub DbMemberDublicateUpdate()
        If MsgBox("Убрать дубликаты российских лиц в базе?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Вопросец") <> MsgBoxResult.Yes Then Exit Sub
        Dim Cmd As New SqlClient.SqlCommand With {.Connection = Program.DbClient.Connection}
        Dim T As New DataTable
        With T.Columns
            .Add("id", GetType(Integer))
            .Add("dbId", GetType(Integer))
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        Cmd.CommandText = "SELECT * from tMember WHERE inn >= '0' AND isACT = 1"
        T.Load(Cmd.ExecuteReader)
        Dim V As New DataView(T) With {.Sort = "id"}
        For i As Integer = 0 To T.Rows.Count - 1
            Me.Text = String.Format("Update tMember ({0} from {1})", i + 1, T.Rows.Count)
            Application.DoEvents()
            If Not IsDBNull(T(i)("dbId")) Then Continue For
            V.RowFilter = String.Format("inn = '{0}'", ToText(T(i)("inn")))
            For j = 0 To V.Count - 2    'до предпоследней строки, последняя строка актуальная
                V(j)("dbId") = V(V.Count - 1)("id")
                V(j)("actDate") = Date.Today
                V(j)("isACT") = False
            Next
        Next
        Me.Text = "Save tMember ..."
        Application.DoEvents()
        Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tMember", Cmd.Connection)
            Dim B As New SqlClient.SqlCommandBuilder(A)
            A.Update(T)
        End Using
        Dim T1 As New DataTable
        With T1.Columns
            .Add("contractId", GetType(Integer))
            .Add("memberId", GetType(Integer))
        End With
        T1.PrimaryKey = New DataColumn() {T1.Columns("contractId"), T1.Columns("memberId")}
        V.RowFilter = "dbId > 0"
        For i As Integer = 0 To V.Count - 1
            Me.Text = String.Format("Update tContractMember ({0} from {1})", i + 1, V.Count)
            Application.DoEvents()
            T1.Rows.Clear()
            Cmd.CommandText = String.Format("SELECT contractId, memberId FROM tContractMember WHERE memberId = {0}", CInt(V(i)("id")))
            T1.Load(Cmd.ExecuteReader)
            For j As Integer = 0 To T1.Rows.Count - 1
                Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tContractMember WHERE contractId = {0} AND memberId = {1}", CInt(T1(j)("contractId")), CInt(V(i)("dbId")))
                If CInt(Cmd.ExecuteScalar) = 0 Then
                    Cmd.CommandText = String.Format("UPDATE tContractMember SET memberId = {0} WHERE contractId = {1} AND memberId = {2}", CInt(V(i)("dbId")), CInt(T1(j)("contractId")), CInt(V(i)("id")))
                End If
                Cmd.CommandText = String.Format("DELETE FROM tContractMember WHERE contractId = {0} AND memberId = {1}", CInt(T1(j)("contractId")), CInt(V(i)("id")))
            Next
        Next

        MsgBox("OK")

    End Sub


    ''' <summary>
    ''' Переписать в EXDB8 таблицу связей лиц и работ из файлов работ
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub UpdateTWorkMember()
        Dim Cn As New SqlClient.SqlConnection("Server=192.168.22.80;Database=EXDB8;Trusted_connection=Yes")
        Cn.Open()
        Dim Cmd As SqlClient.SqlCommand = Cn.CreateCommand
        Dim T As New DataTable
        With T.Columns.Add("id")
            .AllowDBNull = False
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        Dim W As New Cprp.DxData.Work.Excont.WorkConnectionRow(EMPTY_ID, Cn)
        Cmd.CommandText = String.Format( _
            "SELECT id FROM tWork WHERE (typeId = {0} OR typeId = {1}) AND (conditionId = {2} OR conditionId = {3})", _
            CInt(WorkType.IsExCont), CInt(WorkType.IsCustomUnion), _
            CInt(WorkCondition.IsAccept), CInt(WorkCondition.IsClose))
        T.Load(Cmd.ExecuteReader)
        For i As Integer = 0 To T.Rows.Count - 1
            Me.Text = String.Format("UpdateTWorkMember ({0} from {1})", i + 1, T.Rows.Count)
            Application.DoEvents()
            W.Id = T(i)("id")
            For Each Row As DataRow In W.MemberTable.Rows
                Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tMember WHERE id = {0}", ToInt(Row("dbId")))
                If CInt(Cmd.ExecuteScalar) = 0 Then Continue For
                If CInt(Row("conRusNum")) > 0 Then
                    Cmd.CommandText = String.Format( _
                        "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                        CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsContractRus))
                    If CInt(Cmd.ExecuteScalar) = 0 Then
                        Cmd.CommandText = String.Format( _
                            "INSERT tWorkMember (workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                            CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsContractRus))
                        Cmd.ExecuteNonQuery()
                    End If
                End If
                If CInt(Row("conNusNum")) > 0 Then
                    Cmd.CommandText = String.Format( _
                        "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                        CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsContractNus))
                    If CInt(Cmd.ExecuteScalar) = 0 Then
                        Cmd.CommandText = String.Format( _
                            "INSERT tWorkMember (workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                            CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsContractNus))
                        Cmd.ExecuteNonQuery()
                    End If
                End If
                If CInt(Row("supRusNum")) > 0 Then
                    Cmd.CommandText = String.Format( _
                        "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                        CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsSupplyRus))
                    If CInt(Cmd.ExecuteScalar) = 0 Then
                        Cmd.CommandText = String.Format( _
                            "INSERT tWorkMember (workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                            CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsSupplyRus))
                        Cmd.ExecuteNonQuery()
                    End If
                End If
                If CInt(Row("supNusNum")) > 0 Then
                    Cmd.CommandText = String.Format( _
                        "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                        CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsSupplyNus))
                    If CInt(Cmd.ExecuteScalar) = 0 Then
                        Cmd.CommandText = String.Format( _
                            "INSERT tWorkMember (workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                            CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsSupplyNus))
                        Cmd.ExecuteNonQuery()
                    End If
                End If
                If CInt(Row("supEndNum")) > 0 Then
                    Cmd.CommandText = String.Format( _
                        "SELECT COUNT(*) FROM tWorkMember WHERE workId = {0} AND memberId = {1} AND memberKindId = {2}", _
                        CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsSupplyEnd))
                    If CInt(Cmd.ExecuteScalar) = 0 Then
                        Cmd.CommandText = String.Format( _
                            "INSERT tWorkMember (workId, memberId, memberKindId) VALUES({0}, {1}, {2})", _
                            CInt(T(i)("id")), CInt(Row("dbId")), CInt(Cprp.DxData.Member.MemberKind.IsSupplyEnd))
                        Cmd.ExecuteNonQuery()
                    End If
                End If
            Next
        Next
        T.Dispose()
        Cmd.Dispose()
        Cn.Dispose()
        W.Dispose()
        MsgBox("Операция завершена.")
    End Sub


    ''' <summary>
    ''' Заполнить поле заявки в работах
    ''' </summary>
    Private Sub InsertWorkPid()
        If MsgBox("Переписать tWork.pId?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        Dim Cn As New SqlClient.SqlConnection("Server=192.168.22.80;Database=EXDB8;Trusted_connection=Yes")
        Cn.Open()
        Dim Cmd As SqlClient.SqlCommand = Cn.CreateCommand
        Dim T As New DataTable
        T.Columns.Add("id", GetType(Integer)).AllowDBNull = False
        T.Columns.Add("orderId", GetType(Integer)).AllowDBNull = False
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        Cmd.CommandText = "SELECT id, orderId FROM tWork WHERE NOT orderId IS NULL AND (typeId = 99 OR typeId = 117)"
        T.Load(Cmd.ExecuteReader)
        For Each Row As DataRow In T.Rows
            Cmd.CommandText = String.Format("UPDATE tWork SET pId = {0} WHERE orderId = {1} AND NOT (typeId = 99 OR typeId = 117)", CInt(Row("id")), CInt(Row("orderId")))
            Cmd.ExecuteNonQuery()
        Next
        MsgBox("OK")
    End Sub


    Private Sub BlackT()
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.LoadDocument("d:\01.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        'R.Document.BeginUpdate()
        'Dim sTmp As String = Nothing
        'With R.Document.Tables(0)
        '    For i As Integer = 0 To .Rows.Count - 1
        '        Me.Text = String.Format("{0} из {1}", i + 1, .Rows.Count)
        '        Application.DoEvents()
        '        sTmp = Cprp.DxData.Common.ToText(R.Document.GetText(.Cell(i, 4).Range))
        '        If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = String.Format("[{0}]", sTmp)
        '        R.Document.Delete(.Cell(i, 4).ContentRange)
        '        R.Document.InsertText(.Cell(i, 4).ContentRange.Start, sTmp)
        '        .MergeCells(.Cell(i, 1), .Cell(i, 4))
        '    Next
        'End With
        'R.Document.EndUpdate()
        'R.Document.SaveDocument("d:\2.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        Using T As New DataTable("MemberBlack")
            With T.Columns
                .Add("id", GetType(Integer)).AllowDBNull = False
                With .Add("caption", GetType(String))
                    .AllowDBNull = False
                    .MaxLength = 500
                End With
                .Add("description", GetType(String))
                .Add("embargoName", GetType(String))
                .Add("countryId", GetType(Integer)).AllowDBNull = False
            End With
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
                Cmd.CommandText = "SELECT * FROM tMemberBlack"
                T.Load(Cmd.ExecuteReader)
            End Using
            T.WriteXml("d:\11.xml")
            T.Rows.Clear()
            Dim Row As DataRow = Nothing
            Dim iTmp As Integer = 2020
            For n As Integer = 0 To R.Document.Tables.Count - 1
                With R.Document.Tables(n)
                    For i As Integer = 0 To .Rows.Count - 1
                        Row = T.NewRow
                        Row("id") = iTmp
                        Row("caption") = Cprp.DxData.Common.DbText(R.Document.GetText(.Cell(i, 0).ContentRange))
                        Row("description") = Cprp.DxData.Common.DbText(R.Document.GetText(.Cell(i, 1).ContentRange))
                        Row("embargoName") = Cprp.DxData.Common.DbText(R.Document.GetText(.Cell(i, 2).ContentRange))
                        Row("countryId") = Cprp.DxData.Common.DbInt(R.Document.GetText(.Cell(i, 3).ContentRange))
                        Me.Text = String.Format("{0} ({1} - {2})", Row("caption").ToString, n + 1, iTmp - 2019)
                        Application.DoEvents()
                        T.Rows.Add(Row)
                        iTmp += 1
                    Next
                End With
            Next
            Me.Text = "Save ..."
            Application.DoEvents()
            Me.Cursor = Cursors.WaitCursor
            Using A As New SqlClient.SqlDataAdapter("SELECT id, caption, description, embargoName, countryId FROM tMemberBlack", Program.DbClient.Connection)
                Dim B As New SqlClient.SqlCommandBuilder(A)
                A.Update(T)
            End Using
            Me.Cursor = Cursors.Default
        End Using

        MsgBox("OK")

    End Sub

    Private Sub TestMq()
        Try
            Dim Mq As New Cprp.Mq.QueueManager("172.28.1.10", 1418, "CHANNEL.CLIENT", "EX_EXPERT_OLD", "INBOX", "EX_EXPERT.TO", Nothing)
            Dim Xm As New Cprp.Mq.XmlMessage(Program.DbClient.Connection)
            Mq.Write(Cprp.Mq.QueueManager.OutQueue.Queue1, Xm.GetNewWork(11564, Guid.NewGuid))
            MsgBox("OK", MsgBoxStyle.Information, "MQ")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "MQ")
        End Try
    End Sub

    Private Sub GoodTypeTableToXml()
        Using T As New DataTable("GoodType")
            With T.Columns
                .Add("id", GetType(Integer))
                .Add("name", GetType(String))
                .Add("isChild", GetType(Boolean))
                .Add("isParent", GetType(Boolean))
            End With
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            Using Cn As New SqlClient.SqlConnection("Server=192.168.22.80;Database=EXDB8;Trusted_connection=Yes")
                Cn.Open()
                Using Cm As SqlClient.SqlCommand = Cn.CreateCommand
                    Cm.CommandText = "SELECT id, name, isChild, isParent FROM tGoodType"
                    T.Load(Cm.ExecuteReader)
                End Using
            End Using
            T.AcceptChanges()
            T.WriteXml("d:\goodType.xml")
        End Using
        MsgBox("OK")
    End Sub


    Private Sub Tnved_311()
        Dim GoodTnvedTable As New DataTable("GoodTnvedTable")
        GoodTnvedTable.Columns.Add("tnved", GetType(String))
        GoodTnvedTable.PrimaryKey = New DataColumn() {GoodTnvedTable.Columns("tnved")}
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = _
                "SELECT DISTINCT tnved FROM tGood WHERE id IN (SELECT goodId FROM tWorkDocGood WHERE workId IN (SELECT id FROM tWork WHERE orderDate > '2021-02-01')) AND NOT tnved IS NULL"
            GoodTnvedTable.Load(Cmd.ExecuteReader)
        End Using
        Dim Tnved311Table As New DataTable("Tnved311Table")
        Tnved311Table.Columns.Add("tnved", GetType(String))
        Tnved311Table.PrimaryKey = New DataColumn() {Tnved311Table.Columns("tnved")}
        Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.LoadDocument("d:\311.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            With R.Document.Tables(0)
                For i As Integer = 0 To .Rows.Count - 1
                    Tnved311Table.Rows.Add(New Object() {Cprp.DxData.Common.DbText(R.Document.GetText(.Cell(i, 0).ContentRange))})
                Next
            End With
        End Using
        Dim iTmp As Integer = 0
        Dim sTmp As String = Nothing
        Using V As New DataView(GoodTnvedTable)
            For i As Integer = 0 To Tnved311Table.Rows.Count - 1
                Me.Text = String.Format("{0} из {1}", i + 1, Tnved311Table.Rows.Count)
                Application.DoEvents()
                sTmp = Cprp.DxData.Common.ToText(Tnved311Table.Rows(i)(0))
                If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                V.RowFilter = String.Format("tnved LIKE '{0}%'", sTmp)
                iTmp += V.Count
            Next
        End Using

        Me.Text = String.Format("Найдено {0} из {1}", iTmp, GoodTnvedTable.Rows.Count)

        GoodTnvedTable.Dispose()
        Tnved311Table.Dispose()

    End Sub

    ''' <summary>
    ''' Загрузить в таблицу экспертных огранизаций сведения из файлов MS Word
    ''' </summary>
    Private Sub ExpertOrgFInfo()
        Dim T As New DataTable
        With T.Columns
            .Add("id", GetType(Integer))
            .Add("inn", GetType(String))
            .Add("fInfo", GetType(String))
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = "SELECT id, inn, fInfo FROM tExpertOrg WHERE NOT inn IS NULL"
            T.Load(Cmd.ExecuteReader)
        End Using
        Dim sTmp As String = Nothing
        'For Each Row As DataRow In T.Rows
        '    sTmp = Cprp.DxData.Common.ToText(Row("fInfo"))
        '    If Not String.IsNullOrWhiteSpace(sTmp) Then
        '        Row("fInfo") = sTmp.Replace("<th>", "<tr><th>").Replace("</td>", "</td></tr>")
        '    End If

        'Next

        Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
            For Each Row As DataRow In T.Rows
                sTmp = String.Format("d:\{0}.docx", Cprp.DxData.Common.ToText(Row("inn")))
                If Not My.Computer.FileSystem.FileExists(sTmp) Then Continue For
                R.LoadDocument(sTmp, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
                sTmp = Nothing
                With R.Document.Tables(0)
                    For i As Integer = 0 To .Rows.Count - 1
                        sTmp &= String.Format("<tr><th>{0}</th><td>{1}</td></tr>", _
                                               Cprp.DxData.Common.ToText(R.Document.GetText(.Cell(i, 0).ContentRange)), _
                                               Cprp.DxData.Common.ToText(R.Document.GetText(.Cell(i, 1).ContentRange)))
                    Next
                End With
                Row("fInfo") = sTmp.Replace(vbCrLf, "<br>")
            Next
        End Using
        Using A As New SqlClient.SqlDataAdapter("SELECT id, inn, fInfo FROM tExpertOrg", Program.DbClient.Connection)
            Dim B As New SqlClient.SqlCommandBuilder(A)
            A.Update(T)
        End Using
    End Sub

    ''' <summary>
    ''' Загрузить данные из таблицы базы EXDB8 в аналогичную таблицу тестовой базы данных
    ''' </summary>
    Private Sub EXDB8ToEXDB8Test()

        ' Имя таблицы данных
        Dim tableName As String = InputBox("Имя таблицы:", "Загрузка данных")
        tableName = Cprp.DxData.Common.ToText(tableName)
        If String.IsNullOrWhiteSpace(tableName) Then Exit Sub

        Dim TmpTable As New DataTable

        ' Подключение к исходной базе данных, загрузка данных в TmpTable
        Using Connection As New SqlClient.SqlConnection("Server=192.168.22.80;Database=EXDB8;Trusted_connection=Yes")
            Connection.Open()
            Using Command As SqlClient.SqlCommand = Connection.CreateCommand
                Command.CommandText = String.Format("SELECT * FROM {0}", tableName)
                TmpTable.Load(Command.ExecuteReader)
                For Each Row As DataRow In TmpTable.Rows
                    Row.SetAdded()
                Next
            End Using
            Connection.Close()
        End Using

        ' Подключение к тестовой базе данных, загрузка данных из TmpTable
        Using Connection As New SqlClient.SqlConnection("Server=PUGANOV\SQLEXPRESS;Database=EXDB8;Trusted_connection=Yes")
            Connection.Open()
            Using Command As SqlClient.SqlCommand = Connection.CreateCommand
                Command.CommandText = String.Format("DELETE FROM {0}", tableName)
                Command.ExecuteNonQuery()
            End Using
            Using A As New SqlClient.SqlDataAdapter(String.Format("SELECT * FROM {0}", tableName), Connection)
                Dim B As New SqlClient.SqlCommandBuilder(A)
                A.Update(TmpTable)
            End Using
            Connection.Close()
        End Using

        TmpTable.Dispose()

        MsgBox(String.Format("Данные загружены в таблицу {0} тестовой базы данных", tableName))


    End Sub


    Private Sub InsertGuidFromEo()
        Using Cn As New SqlClient.SqlConnection("Server=192.168.22.80;Database=EXDB8;Trusted_connection=Yes")
            Cn.Open()
            Using Cmd As New SqlClient.SqlCommand With {.Connection = Cn}
                Dim taskId As Integer = 0
                Dim wrkGuid As String = Nothing
                Dim iCount As Integer = 0
                Using MyReader As New Microsoft.VisualBasic.
                      FileIO.TextFieldParser(
                        "d:\doc109.txt")
                    MyReader.TextFieldType = FileIO.FieldType.Delimited
                    MyReader.SetDelimiters("#")
                    Dim currentRow As String()
                    While Not MyReader.EndOfData
                        Try
                            currentRow = MyReader.ReadFields()
                            taskId = CInt(currentRow(0))
                            wrkGuid = currentRow(1)
                            'Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tWork WHERE taskId = {0}", taskId)
                            Cmd.CommandText = String.Format("SELECT COUNT(*) FROM t2Doc2 WHERE eoId = {0} AND isChanged = 0", taskId)
                            If CInt(Cmd.ExecuteScalar) > 0 Then
                                'Cmd.CommandText = String.Format("UPDATE tWork SET guid = '{1}' WHERE taskId = {0}", taskId, wrkGuid)
                                Cmd.CommandText = String.Format("UPDATE t2Doc2 SET description = '{1}' WHERE eoId = {0}", taskId, wrkGuid)
                                Cmd.ExecuteNonQuery()
                                iCount += 1
                            End If
                            Me.Text = iCount.ToString
                            Application.DoEvents()
                        Catch ex As Microsoft.VisualBasic.
                                    FileIO.MalformedLineException
                            MsgBox("Line " & ex.Message &
                            "is not valid and will be skipped.")
                        End Try
                    End While
                End Using
            End Using
        End Using

        MsgBox("OK")

    End Sub


    Private Sub EXDB8_Referance()

        Dim Cn8 As New SqlClient.SqlConnection("Server=192.168.22.80;Database=EXDB8;Trusted_connection=Yes")
        Cn8.Open()

        Dim CnR As New SqlClient.SqlConnection("Server=192.168.22.80;Database=Reference;Trusted_connection=Yes")
        CnR.Open()

        Dim Cmd As SqlClient.SqlCommand = Cn8.CreateCommand

        Dim T As New DataTable
        Dim Row As DataRow = Nothing

        'Cmd.CommandText = "SELECT * FROM tCountry"
        'T.Load(Cmd.ExecuteReader)
        'T.PrimaryKey = New DataColumn() {T.Columns("id")}
        'For Each Row As DataRow In T.Rows
        '    Row.SetAdded()
        'Next
        'Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tCountry", CnR)
        '    Dim B As New SqlClient.SqlCommandBuilder(A)
        '    A.Update(T)
        'End Using

        'T.Dispose()
        'T = New DataTable
        'Cmd.CommandText = "SELECT code, description, 1 As isACT FROM tTnved WHERE dateB <= {ts '2020-11-01 00:00:00'} AND dateE > {ts '2020-11-01 00:00:00'}"
        'T.Load(Cmd.ExecuteReader)
        'T.PrimaryKey = New DataColumn() {T.Columns("code")}
        'For Each Row As DataRow In T.Rows
        '    Row.SetAdded()
        'Next
        'Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tTnved", CnR)
        '    Dim B As New SqlClient.SqlCommandBuilder(A)
        '    A.Update(T)
        'End Using

        'Cmd.CommandText = "SELECT embargoId As docId, countryId, modeId FROM tEmbargoCountry WHERE NOT embargoId IN (21, 27, 28, 30)"
        'T.Load(Cmd.ExecuteReader)
        'T.PrimaryKey = New DataColumn() {T.Columns("docId"), T.Columns("countryId")}
        'For Each Row As DataRow In T.Rows
        '    Row.SetAdded()
        'Next
        'Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tDocCountry", CnR)
        '    Dim B As New SqlClient.SqlCommandBuilder(A)
        '    A.Update(T)
        'End Using

        'With T.Columns
        '    .Add("docId", GetType(Integer))
        '    .Add("tnved", GetType(String))
        '    .Add("modeId", GetType(Integer))
        'End With
        'T.PrimaryKey = New DataColumn() {T.Columns("docId"), T.Columns("tnved"), T.Columns("modeId")}
        'Cmd.CommandText = "SELECT DISTINCT tnved, modeId FROM vLawTnved WHERE doc LIKE '1130%' AND is2 = 0"
        'Using Dr As SqlClient.SqlDataReader = Cmd.ExecuteReader
        '    While Dr.Read
        '        T.Rows.Add(New Object() {13, Dr("tnved"), Dr("modeId")})
        '    End While
        'End Using
        'Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tDocTnved", CnR)
        '    Dim B As New SqlClient.SqlCommandBuilder(A)
        '    A.Update(T)
        'End Using

        With T.Columns
            .Add("id", GetType(Integer))
            .Add("caption", GetType(String))
            .Add("description", GetType(String))
            .Add("themeId", GetType(Integer))
            .Add("docId", GetType(Integer))
            .Add("countryId", GetType(Integer))
            .Add("tnved", GetType(String))
            .Add("modeId", GetType(Integer))
        End With
        With T.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        Cmd.CommandText = "SELECT id, caption, description, 4 as themeId, embargoId As docId, countryId, modeId FROM tEmbargoMember WHERE NOT embargoId IN (21, 27, 28, 30)"
        T.Load(Cmd.ExecuteReader)
        For Each Row In T.Rows
            Row.SetAdded()
        Next
        Using A As New SqlClient.SqlDataAdapter("SELECT * From tInfoTnvedCountry", CnR)
            Dim B As New SqlClient.SqlCommandBuilder(A)
            A.Update(T)
        End Using


        T.Dispose()
        Cmd.Dispose()
        CnR.Close()
        CnR.Dispose()
        Cn8.Close()
        Cn8.Dispose()


        MsgBox("OK")


    End Sub


    Private Sub UpdateOrgCountryId()
        Dim CountryTable As New Cprp.DxData.Handbook.CountryDataTable(Program.DbClient.Connection)
        Dim iTmp As Integer = 0
        Using T As New DataTable("OrgTable")
            With T.Columns
                .Add("id", GetType(Integer))
                .Add("embargoId", GetType(Integer))
                .Add("embargoName", GetType(String))
                .Add("countryId", GetType(Integer))
                .Add("countryName", GetType(String))
                .Add("caption", GetType(String))
                .Add("description", GetType(String))
            End With
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            T.ReadXml("d:\orgData.xml")
            For Each Row As DataRow In T.Rows
                Row("countryId") = DbInt(CountryTable.GetIdByNameShort(Row("countryName")))
                If IsDBNull(Row("countryId")) Then iTmp = iTmp + 1
            Next
            T.WriteXml("d:\210.xml")
            MsgBox(String.Format("{0} <> {1}", T.Rows.Count, iTmp))
        End Using
    End Sub

    Private Sub MemberBlackToBase()
        If Cprp.DxCommon.Messages.ShowQuestion("Загрузить данные в таблицу лиц из файла MS Word?") <> Windows.Forms.DialogResult.Yes Then Exit Sub
        Using T As New DataTable("MemberTable")
            With T.Columns
                .Add("id", GetType(Integer))
                .Add("caption", GetType(String)).AllowDBNull = False
                .Add("description", GetType(String))
                .Add("embargoName", GetType(String))
                .Add("countryId", GetType(Integer)).AllowDBNull = False
            End With
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            Dim countryId As Integer = EMPTY_ID
            Dim Row As DataRow = Nothing
            Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
                R.LoadDocument("d:\123.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
                For n As Integer = 0 To R.Document.Tables.Count - 1
                    With R.Document.Tables(n)
                        countryId = ToInt(R.Document.GetText(.Cell(1, 1).ContentRange))
                        If countryId < 1 Then
                            Cprp.DxCommon.Messages.ShowError(String.Format( _
                                    "Некорректный id страны (таблица № {0} - {1})", _
                                    n + 1, _
                                    ToText(R.Document.GetText(.Cell(0, 0).ContentRange))))
                            Exit Sub
                        End If
                        For i As Integer = 2 To .Rows.Count - 1
                            Row = T.NewRow
                            Row("id") = 4348 + T.Rows.Count + 1
                            Row("caption") = DbText(R.Document.GetText(.Cell(i, 0).ContentRange), 500)
                            Row("description") = DbText(R.Document.GetText(.Cell(i, 1).ContentRange))
                            Row("countryId") = countryId
                            If IsDBNull(Row("caption")) Then
                                Cprp.DxCommon.Messages.ShowError(String.Format( _
                                   "Некорректный caption (таблица № {0} - {1})", _
                                   n + 1, _
                                   ToText(R.Document.GetText(.Cell(0, 0).ContentRange))))
                                Exit Sub
                            End If
                            T.Rows.Add(Row)
                        Next
                    End With
                Next
            End Using
            Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
                Cmd.CommandText = "DELETE FROM tMemberBlack WHERE id > 4348"
                Cmd.ExecuteNonQuery()
            End Using
            Using A As New SqlClient.SqlDataAdapter("SELECT id, caption, description, embargoName, countryId FROM tMemberBlack", Program.DbClient.Connection)
                Dim B As New SqlClient.SqlCommandBuilder(A)
                A.Update(T)
            End Using
            MsgBox("OK")
        End Using

    End Sub


    ''' <summary>
    ''' Загрузить в таблицу-справочник валют сведения из файла MS Word
    ''' </summary>
    Private Sub CurrencyToBase()
        If MsgBox("Загрузить новый справочник валют в базу данных?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        Dim T As New DataTable
        With T.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
            .Add("codeLetter", GetType(String))
            .Add("codeDec", GetType(String))
            .Add("country", GetType(String))
            .Add("isACT", GetType(Boolean))
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        Dim Row As DataRow = Nothing
        Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.LoadDocument("d:\3.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            With R.Document.Tables(0)
                For i As Integer = 0 To .Rows.Count - 1
                    Row = T.NewRow
                    Row("id") = i + 1
                    Row("name") = DbText(R.Document.GetText(.Cell(i, 2).ContentRange))
                    Row("codeLetter") = DbText(R.Document.GetText(.Cell(i, 1).ContentRange))
                    Row("codeDec") = DbText(R.Document.GetText(.Cell(i, 0).ContentRange))
                    Row("country") = DbText(R.Document.GetText(.Cell(i, 3).ContentRange))
                    Row("isACT") = True
                    T.Rows.Add(Row)
                Next
            End With
        End Using
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = "DELETE FROM tCurrency"
            Cmd.ExecuteNonQuery()
        End Using
        Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tCurrency", Program.DbClient.Connection)
            Dim B As New SqlClient.SqlCommandBuilder(A)
            A.Update(T)
        End Using
    End Sub

    ''' <summary>
    ''' Обновить в таблице tFInfo содержимое поля goodNameFind
    ''' </summary>
    Private Sub UpdateTFInfoGoodFind()
        Using T As New DataTable
            With T.Columns.Add("id", GetType(Integer))
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            Me.Cursor = Cursors.WaitCursor
            Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
                Cmd.CommandText = "SELECT id, goodName, goodNameFind FROM tFInfo"
                T.Load(Cmd.ExecuteReader)
            End Using
            For i As Integer = 0 To T.Rows.Count - 1
                Me.Text = String.Format("{0} from {1}", i + 1, T.Rows.Count)
                Application.DoEvents()
                T(i)("goodNameFind") = DbText(ToABC(ToText(T(i)("goodName")).ToUpper))
            Next
            Me.Text = "Сохранение данных..."
            Application.DoEvents()
            Using A As New SqlClient.SqlDataAdapter("SELECT id, goodName, goodNameFind FROM tFInfo", Program.DbClient.Connection)
                Dim B As New SqlClient.SqlCommandBuilder(A)
                A.Update(T)
            End Using
        End Using
        Me.Cursor = Cursors.Default
        MsgBox("OK")
    End Sub

    ''' <summary>
    ''' Загрузить факсимиле пользователя в таблицу базы данных
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadUserSignature()
        Dim userId As Integer = 51
        Dim filePath As String = "d:\AnfinogenovaSignature.png"
        Dim img As Drawing.Image = Drawing.Image.FromFile(filePath)

        Using T As New DataTable
            T.Columns.Add("id", GetType(Integer))
            T.PrimaryKey = New DataColumn() {T.Columns("id")}
            Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT * FROM tUser WHERE id = {0}", userId)
                T.Load(Cmd.ExecuteReader)
            End Using
            Using M As New IO.MemoryStream()
                img.Save(M, img.RawFormat)
                T(0)("signature") = M.ToArray
            End Using
            Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tUser", Program.DbClient.Connection)
                Dim B As New SqlClient.SqlCommandBuilder(A)
                A.Update(T)
            End Using
        End Using

        MsgBox("OK")
    End Sub

    ''' <summary>
    ''' Создать файл xml по одной работе (экспертизе)
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <param name="folderPath">Путь к папке для сохранения файла</param>
    ''' <remarks></remarks>
    Private Sub WorkToXml(ByRef Work As Cprp.DxData.Work.Excont.WorkConnectionRow, folderPath As String)
        Dim TRow As DataRow = Nothing
        Dim sTmp As String = Nothing
        '
        ' Направление перемещения
        '
        Dim modeId As Integer = 1
        If ToInt(Work.ARow("modeId")) = 2 Then modeId = 2

        Dim filePath As String = String.Format("{0}\{1}.xml", folderPath, CInt(Work.Id))
        With New Xml.XmlTextWriter(filePath, System.Text.Encoding.UTF8)
            .Formatting = Xml.Formatting.Indented
            .IndentChar = " "
            .WriteStartDocument()
            .WriteStartElement("WorkData")
            .WriteAttributeString("id", Work.Id.ToString)
            '
            ' Members
            '
            .WriteStartElement("Members")
            For Each Row As DataRow In Work.MemberTable.Rows
                .WriteStartElement("Member")
                .WriteElementString("id", CInt(Row("id")))

                .WriteStartElement("Roles")
                If ToInt(Row("conRusNum")) > 0 Then
                    sTmp = If(modeId = 1, "Seller", "Buyer")
                    .WriteElementString("Role", sTmp)
                End If
                If ToInt(Row("conNusNum")) > 0 Then
                    sTmp = If(modeId = 1, "Buyer", "Seller")
                    .WriteElementString("Role", sTmp)
                End If
                If ToInt(Row("supRusNum")) > 0 Then
                    sTmp = If(modeId = 1, "Sender", "Recipient")
                    .WriteElementString("Role", sTmp)
                End If
                If ToInt(Row("supNusNum")) > 0 Then
                    sTmp = If(modeId = 1, "Recipient", "Sender")
                    .WriteElementString("Role", sTmp)
                End If
                If ToInt(Row("supEndNum")) > 0 Then
                    .WriteElementString("Role", "Consumer")
                End If
                .WriteEndElement()  '/Member.Roles

                .WriteElementString("NameLong", ToText(Row("nameLong")))
                .WriteElementString("NameShort", ToText(Row("nameShort")))
                .WriteElementString("Inn", ToText(Row("inn")))
                .WriteElementString("Kpp", ToText(Row("kpp")))
                .WriteElementString("Ogrn", ToText(Row("ogrn")))

                .WriteStartElement("Address")
                .WriteElementString("Full", ToText(Row("addressLegalFull")))

                .WriteStartElement("Country")
                TRow = CountryTable.Rows.Find(Row("addressLegalCountryId"))
                If Not TRow Is Nothing Then
                    .WriteElementString("nameShort", ToText(TRow("nameShort")))
                    .WriteElementString("code_alpha2", ToText(TRow("codAlpha2")))
                End If
                .WriteEndElement()  '/Member.Address.Country

                .WriteEndElement()  '/Member.Address

                .WriteStartElement("Passport")
                .WriteElementString("Ser", ToText(Row("passportSer")))
                .WriteElementString("Num", ToText(Row("passportNum")))
                .WriteElementString("Give", ToText(Row("passportGive")))
                .WriteEndElement()  '/Member.Passport

                .WriteElementString("Phone", ToText(Row("phone")))
                .WriteElementString("Email", ToText(Row("email")))

                .WriteEndElement()  '/Members.Member
            Next

            .WriteEndElement()      '/Members
            '
            ' Contract
            '
            .WriteStartElement("Contract")
            .WriteElementString("DocName", ToText(Work.ARow("contractName")))
            .WriteElementString("DocNum", ToText(Work.ARow("contractNum")))
            sTmp = ToText(Work.ARow("contractDate"))
            If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = CDate(sTmp).ToString("o")
            .WriteElementString("DocDate", sTmp)
            sTmp = ToText(Work.ARow("contractTerm"))
            If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = CDate(sTmp).ToString("o")
            .WriteElementString("Term", sTmp)
            .WriteElementString("Description", ToText(Work.ARow("contractDescription")))
            .WriteEndElement()      '/Contract
            '
            ' Supply
            '
            .WriteStartElement("Supply")
            .WriteElementString("Name", ToText(Work.ARow("invoiceCaption")))
            .WriteElementString("Direction", If(modeId = 1, "export", "import"))

            TRow = CountryTable.Rows.Find(Work.ARow("countryId"))

            .WriteStartElement("DestCountry")
            If modeId = 1 Then
                If Not TRow Is Nothing Then
                    .WriteElementString("NameShort", ToText(TRow("nameShort")))
                    .WriteElementString("CodeAlpha2", ToText(TRow("codAlpha2")))
                End If
            Else
                .WriteElementString("NameShort", "РОССИЯ")
                .WriteElementString("CodeAlpha2", "RU")
            End If
            .WriteEndElement()      '/DestCountry

            .WriteStartElement("SendCountry")
            If modeId = 1 Then
                .WriteElementString("NameShort", "РОССИЯ")
                .WriteElementString("CodeAlpha2", "RU")
            Else
                If Not TRow Is Nothing Then
                    .WriteElementString("NameShort", ToText(TRow("nameShort")))
                    .WriteElementString("CodeAlpha2", ToText(TRow("codAlpha2")))
                End If
            End If
            .WriteEndElement()      '/SendCountry

            TRow = CountryTable.Rows.Find(Work.ARow("bankCountryId"))
            .WriteStartElement("BankCountry")
            If Not TRow Is Nothing Then
                .WriteElementString("NameShort", ToText(TRow("nameShort")))
                .WriteElementString("CodeAlpha2", ToText(TRow("codAlpha2")))
            End If
            .WriteEndElement()      '/BankCountry

            .WriteElementString("Description", DelPoint(Work.ARow("supplyDescription")))

            .WriteEndElement()      '/Supply
            '
            ' Goods
            '
            .WriteStartElement("Goods")
            For Each Row As DataRow In Work.GoodTable.Rows
                .WriteStartElement("Good")
                .WriteElementString("id", CInt(Row("id")))
                .WriteElementString("NameCon", ToText(Row("nameCon")))
                .WriteElementString("NameDec", ToText(Row("nameDec")))
                'sTmp = String.Format("{0} Назначение: {1} Область применения: {2}", AddPoint(Row("description")), AddPoint(Row("used")), DelPoint(Row("area")))
                '.WriteElementString("Description", sTmp)
                .WriteElementString("Description", DelPoint(Row("description")))
                .WriteElementString("Tnved", ToText(Row("tnved")))
                .WriteEndElement()      '/Good
            Next
            .WriteEndElement()      '/Goods
            '
            ' MemberEmbargo
            '
            .WriteStartElement("MemberEmbargo")
            For Each Row As DataRow In Work.MemberEmbargoTable.Rows
                .WriteStartElement("Record")
                .WriteElementString("MemberId", ToText(Row("memberId")))
                .WriteElementString("EmbargoId", ToText(Row("embargoMemberId")))
                .WriteEndElement()
            Next
            .WriteEndElement()      '/MemberEmbargo
            '
            ' GoodEmbargo
            '
            .WriteStartElement("GoodEmbargo")
            For Each Row As DataRow In Work.GoodEmbargoTable.Rows
                .WriteStartElement("Record")
                .WriteElementString("GoodId", ToText(Row("goodId")))
                .WriteElementString("EmbargoId", ToText(Row("embargoGoodId")))
                .WriteEndElement()
            Next
            .WriteEndElement()      '/GoodEmbargo
            '
            ' GoodLaw
            '
            .WriteStartElement("GoodLaw")
            For Each Row As DataRow In Work.GoodLawTable.Rows
                If CInt(Row("summaryId")) < 1 Then Continue For
                .WriteStartElement("Record")
                .WriteElementString("GoodId", ToText(Row("goodId")))
                .WriteElementString("LawId", ToText(Row("lawId")))
                .WriteElementString("LawDescription", ToText(Row("LawDescription")))
                .WriteElementString("GoodDescription", ToText(Row("GoodDescription")))
                .WriteElementString("SummaryId", ToText(Row("SummaryId")))
                .WriteEndElement()
            Next
            .WriteEndElement()      '/GoodEmbargo
            ''
            '' Summary
            ''
            '.WriteStartElement("Summary")
            '.WriteElementString("id", ToText(Work.ARow("summaryId")))
            '.WriteElementString("Description", ToText(Work.ARow("summaryText")))
            '.WriteEndElement()      '/Summary

            .WriteEndElement()      '/WorkData

            .WriteEndDocument()

            .Close()
        End With

        With My.Computer.FileSystem.OpenTextFileReader(filePath)
            sTmp = .ReadToEnd
            .Close()
        End With
        sTmp = sTmp.Replace("&#x1;", Nothing)
        With My.Computer.FileSystem.OpenTextFileWriter(filePath, False)
            .Write(sTmp)
            .Close()
        End With

    End Sub

End Class