''' <summary>
''' Форма для составления отчетов и выгрузки их в Excel
''' </summary>
Friend Class ReportForm

    Friend Sub New()
        InitializeComponent()
        '
        ' Me
        '
        Me.Text = "Отчет"
        Me.Width = Screen.GetWorkingArea(Me).Width - 1
        Me.Height = Screen.GetWorkingArea(Me).Height - 1
        Me.CenterToScreen()

    End Sub

    ' Создать отчет
    Private Sub ReportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportBarButtonItem.ItemClick
        'PlaneAcceptTermReport()
        WorkStopStartReport()
        'WorkEventLeaderTerm()
        'WorkDocTerm()
        'FinfoDocCountMonth()
        'FinfoDocCountQuarter()
        'FinfoRusMember()
        'MemberEmbargoReport()
        'ClientWorkCountMonth()

    End Sub

    ' Экспорт отчета в Excel
    Private Sub ExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Отчет"
            Dlg.DefaultExt = "xlsx"
            Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        Try
            ReportGridView.ExportToXlsx(filePath)
            Using P As New Process
                P.StartInfo.FileName = filePath
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ''' <summary>
    ''' Отчет по запретам и ограничениям в отношении фирм + 20
    ''' </summary>
    Private Sub MemberEmbargoReport()

        Dim ReportTable As New DataTable
        With ReportTable.Columns
            .Add("id", GetType(Integer))            ' id фирмы
            .Add("tId", GetType(Integer))           ' идентификатор таблицы БД (1 - заперты, 2 - ст.20)
            .Add("cId", GetType(Integer))           ' id страны
            .Add("countryName", GetType(String))    ' краткое наименование страны
            .Add("caption", GetType(String))        ' наиманование фирмы
            .Add("description", GetType(String))    ' дополнительная информация о фирме

        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id"), ReportTable.Columns("tId")}

        ' Загрузка данных 
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            ' 1
            Cmd.CommandText = _
                "SELECT id, 1 AS tId, countryId AS cId, countryNameShort As countryName, memberCaption AS caption, (ISNULL(memberDescription + CHAR(13) + CHAR(10), '') + ISNULL(embargoCaption2, '')) AS description " & _
                "FROM vEmbargoMemberData"
            ReportTable.Load(Cmd.ExecuteReader)
            ' 2
            Cmd.CommandText = _
                "SELECT tMemberBlack.id AS id, 2 AS tId, countryId AS cId, tCountry.nameShort AS countryName, caption, (description + ' ' + ISNULL(embargoName, '')) AS description  " & _
                "FROM tMemberBlack " & _
                "LEFT JOIN tCountry ON tMemberBlack.countryId = tCountry.id "
            ReportTable.Load(Cmd.ExecuteReader)

        End Using

        ReportGridView.BeginDataUpdate()
        ReportGridControl.DataSource = ReportTable
        ReportGridView.EndDataUpdate()
        ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("countryName"), DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.SortInfo.Insert(1, ReportGridView.Columns.ColumnByFieldName("сaption"), DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.MoveFirst()

        With ReportGridView
            .Columns("countryName").Caption = "Страна"
            .Columns("caption").Caption = "Фирма"
            .Columns("description").Caption = "Сведения о фирме"
        End With

        MsgBox("OK")


    End Sub

    ''' <summary>
    ''' Отчет по российским участникам экспертной организации
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FinfoRusMember()

        ' Таблица отчета
        Dim ReportTable As New DataTable
        With ReportTable.Columns
            .Add("rusCaption", GetType(String))         ' росиийский участник
            .Add("rusInn", GetType(String))             ' ИНН российского участника
            .Add("docCount", GetType(Integer))          ' количество заключений
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("rusCaption"), ReportTable.Columns("rusInn")}

        Dim startDate As Date = CDate("01.01.2025")
        Dim orgId = 3   ' 1 - ФСТЭК, 3 - УРФУ, 4 - ЦЭК, 6 - ПО Октябрь

        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            ' Загрузка таблицы перечнем российских участников
            Cmd.CommandText = String.Format( _
                "SELECT DISTINCT rusCaption, rusInn, 0 AS docCount " & _
                "FROM tFinfo " & _
                "WHERE orgId = {0} AND docDate > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} " & _
                "AND NOT rusCaption IS NULL AND NOT rusInn IS NULL", orgId, startDate)
            ReportTable.Load(Cmd.ExecuteReader)
            ' Количество заключений по каждому участнику
            Dim rusInn As String = Nothing
            For Each Row As DataRow In ReportTable.Rows
                rusInn = Row("rusInn").ToString
                Cmd.CommandText = String.Format( _
                    "SELECT COUNT(DISTINCT docNum) FROM tFInfo " & _
                    "WHERE orgId = {0} AND rusInn = '{1}' AND docDate > {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}", _
                    orgId, rusInn, startDate)
                Row("docCount") = CInt(Cmd.ExecuteScalar)
            Next
        End Using

        ReportGridView.BeginDataUpdate()
        ReportGridControl.DataSource = ReportTable
        ReportGridView.EndDataUpdate()
        'ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("docCount"), DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("rusCaption"), DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.MoveFirst()

        With ReportGridView
            .Columns("rusCaption").Caption = "Российский участник"
            .Columns("rusInn").Caption = "ИНН"
            .Columns("docCount").Caption = "Количество обращений"
        End With

        MsgBox("OK")

    End Sub

    ''' <summary>
    ''' Отчет по количеству заключений экспертных организаций по месяцам
    ''' </summary>
    Private Sub FinfoDocCountMonth()

        ' Таблица отчета
        Dim ReportTable As New DataTable
        With ReportTable.Columns
            .Add("orgId", GetType(Integer))             ' id организации
            .Add("orgNameLong", GetType(String))        ' наименование организации
            .Add("repDate", GetType(Date))              ' отчетная дата с интервалом 1 месяц
            .Add("maxDocNum", GetType(String))          ' максимальный номер заключения на отчетную дату (строка)
            .Add("maxDocNumNum", GetType(Integer))      ' максимальный номер заключения на отчетную дату (число))
            .Add("docCount", GetType(Integer))          ' количество заключений с предыдущей отчеткой даты
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("orgId"), ReportTable.Columns("repDate")}

        ' Таблица экспертных организаций
        Dim OrgTable As New DataTable
        With OrgTable.Columns
            .Add("orgId", GetType(Integer))
            .Add("orgNameLong", GetType(String))
        End With
        OrgTable.PrimaryKey = New DataColumn() {OrgTable.Columns("orgId")}

        ' Начальная дата отчета
        Dim dTmp As Date = CDate("01.01.2023")

        Using cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand

            ' Заполнение таблицы экспертных огранизаций
            cmd.CommandText = String.Format("SELECT orgId, orgNameLong FROM vFInfo WHERE docDate > {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} GROUP BY orgId, orgNameLong", dTmp)
            OrgTable.Load(cmd.ExecuteReader)

            ' Цикл по экспертным организациям
            For Each row As DataRow In OrgTable.Rows

                ' Цикл по месяцам до текущего месяца                
                dTmp = CDate("01.01.2023")
                Do
                    cmd.CommandText = String.Format("SELECT ISNULL(max(docNum), '-') AS maxDocNum FROM tFInfo WHERE orgId = {0} AND docDate > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND docDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}", CInt(row("orgId")), dTmp, dTmp.AddMonths(1))
                    Using dr As SqlClient.SqlDataReader = cmd.ExecuteReader
                        While dr.Read
                            ReportTable.Rows.Add(New Object() { _
                                                 row("orgId"), row("orgNameLong"), dTmp, dr("maxDocNum"), 0, 0})

                        End While
                    End Using
                    dTmp = dTmp.AddMonths(1)
                    If dTmp.AddMonths(1) > Date.Now Then Exit Do
                Loop
            Next

        End Using

        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Dim iMax As Integer = 0
        ' Количество работ по месяцам
        Using v As New DataView(ReportTable) With {.Sort = "orgId, repDate"}
            ' Номер максимального заключения в каждом месяце
            For i As Integer = 0 To v.Count - 1
                sTmp = Cprp.DxData.Common.ToText(v(i)("maxDocNum"))
                If String.IsNullOrWhiteSpace(sTmp) OrElse sTmp.Length < 5 Then Continue For
                sTmp = sTmp.Substring(0, 4)
                If IsNumeric(sTmp) Then v(i)("maxDocNumNum") = CInt(sTmp)
            Next
            ' Количество работ за месяц
            For i As Integer = 0 To v.Count - 1
                If CDate(v(i)("repDate")).Month = 1 Then
                    iMax = CInt(v(i)("maxDocNumNum"))
                    v(i)("docCount") = iMax
                ElseIf CInt(v(i)("maxDocNumNum")) <> 0 Then
                    For j As Integer = 0 To v.Count - 1
                        If v(i)("orgId") <> v(j)("orgId") Then Continue For
                        If CDate(v(i)("repDate")).Year <> CDate(v(j)("repDate")).Year Then Continue For
                        If v(i)("repDate") = v(j)("repDate") Then Exit For
                        iTmp = CInt(v(j)("maxDocNumNum"))
                        If iMax < iTmp Then iMax = iTmp
                    Next
                    v(i)("docCount") = CInt(v(i)("maxDocNumNum")) - iMax
                End If
            Next

        End Using

        ReportGridView.BeginDataUpdate()
        ReportGridControl.DataSource = ReportTable
        ReportGridView.EndDataUpdate()
        ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("orgNameLong"), DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.SortInfo.Insert(1, ReportGridView.Columns.ColumnByFieldName("repDate"), DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.MoveFirst()

        With ReportGridView
            .Columns("orgId").Visible = False
            .Columns("orgNameLong").Caption = "Организация"
            .Columns("repDate").Caption = "Дата (месяц года)"
            .Columns("maxDocNum").Caption = "Номер заключения (max)"
            .Columns("maxDocNumNum").Visible = False
            .Columns("docCount").Caption = "Количество за месяц"
        End With

        MsgBox("OK")

    End Sub

    ''' <summary>
    ''' Отчет по количеству заключений экспертных организаций поквартально
    ''' </summary>
    ''' <remarks>
    ''' Отчетные периоды:
    ''' 231: 01.01.2023 - 31.03.2023
    ''' 232: 01.04.2023 - 30.06.2023
    ''' 233: 01.07.2023 - 30.09.2023
    ''' 234: 01.10.2023 - 31.12.2023
    ''' 241: 01.01.2024 - 31.03.2024
    ''' 242: 01.04.2024 - 30.06.2024
    ''' 243: 01.07.2024 - 30.09.2024
    ''' 244: 01.10.2024 - 31.12.2024
    ''' 251: 01.01.2025 - 31.03.2025
    ''' 252: 01.04.2025 - 30.06.2025
    ''' 253: 01.07.2025 - 30.09.2025
    ''' 254: 01.10.2025 - 31.12.2025
    ''' </remarks>
    Private Sub FinfoDocCountQuarter()

        ' Таблица отчета
        Dim ReportTable As New DataTable
        With ReportTable.Columns
            .Add("orgId", GetType(Integer))             ' id организации
            With .Add("orgNameLong", GetType(String))   ' наименование организации
                .AllowDBNull = False
                .DefaultValue = 0
            End With

            With .Add("col231", GetType(Integer))       ' количество заключений за период 231
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col232", GetType(Integer))       ' количество заключений за период 232
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col233", GetType(Integer))       ' количество заключений за период 233
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col234", GetType(Integer))       ' количество заключений за период 234
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col241", GetType(Integer))       ' количество заключений за период 241
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col242", GetType(Integer))       ' количество заключений за период 242
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col243", GetType(Integer))       ' количество заключений за период 243
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col244", GetType(Integer))       ' количество заключений за период 244
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col251", GetType(Integer))       ' количество заключений за период 241
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col252", GetType(Integer))       ' количество заключений за период 242
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col253", GetType(Integer))       ' количество заключений за период 243
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("col254", GetType(Integer))       ' количество заключений за период 244
                .AllowDBNull = False
                .DefaultValue = 0
            End With

            With .Add("num231", GetType(String))       ' наибольший номер заключения за период 231
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num232", GetType(String))       ' наибольший номер заключения за период 232
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num233", GetType(String))       ' наибольший номер заключения за период 233
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num234", GetType(String))       ' наибольший номер заключения за период 234
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num241", GetType(String))       ' наибольший номер заключения за период 241
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num242", GetType(String))       ' наибольший номер заключения за период 242
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num243", GetType(String))       ' наибольший номер заключения за период 243
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num244", GetType(String))       ' наибольший номер заключения за период 244
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num251", GetType(String))       ' наибольший номер заключения за период 241
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num252", GetType(String))       ' наибольший номер заключения за период 242
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num253", GetType(String))       ' наибольший номер заключения за период 243
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
            With .Add("num254", GetType(String))       ' наибольший номер заключения за период 244
                .AllowDBNull = False
                .DefaultValue = "-"
            End With
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("orgId")}

        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand

            ' Заполнение таблицы строками с экспертными организациям
            Cmd.CommandText = "SELECT orgId, orgNameLong FROM vFInfo WHERE docDate > {ts '2023-01-01 00:00:00'} GROUP BY orgId, orgNameLong"
            ReportTable.Load(Cmd.ExecuteReader)

            ' Наибольшие номера заключений за отчетные периоды
            For Each Row As DataRow In ReportTable.Rows
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2023-01-01 00:00:00'}} AND docDate < {{ts '2023-04-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num231") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2023-04-01 00:00:00'}} AND docDate < {{ts '2023-07-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num232") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2023-07-01 00:00:00'}} AND docDate < {{ts '2023-10-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num233") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2023-10-01 00:00:00'}} AND docDate < {{ts '2024-01-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num234") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2024-01-01 00:00:00'}} AND docDate < {{ts '2024-04-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num241") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2024-04-01 00:00:00'}} AND docDate < {{ts '2024-07-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num242") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2024-07-01 00:00:00'}} AND docDate < {{ts '2024-10-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num243") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2024-10-01 00:00:00'}} AND docDate < {{ts '2025-01-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num244") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2025-01-01 00:00:00'}} AND docDate < {{ts '2025-04-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num251") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2025-04-01 00:00:00'}} AND docDate < {{ts '2025-07-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num252") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2025-07-01 00:00:00'}} AND docDate < {{ts '2025-10-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num253") = Cmd.ExecuteScalar.ToString
                Cmd.CommandText = String.Format("SELECT ISNULL(MAX(docNum), '-') FROM tFInfo WHERE orgId = {0} AND docDate >= {{ts '2025-10-01 00:00:00'}} AND docDate < {{ts '2026-01-01 00:00:00'}}", CInt(Row("orgId")))
                Row("num254") = Cmd.ExecuteScalar.ToString
            Next

        End Using

        ' Количество заключений за отчетные периоды
        Dim sTmp As String = Nothing
        For Each Row As DataRow In ReportTable.Rows
            sTmp = Row("num231").ToString
            If sTmp.Length > 3 Then Row("col231") = CInt(sTmp.Substring(0, 4))
            sTmp = Row("num232").ToString
            If sTmp.Length > 3 Then Row("col232") = CInt(sTmp.Substring(0, 4)) - CInt(Row("col231"))
            sTmp = Row("num233").ToString
            If sTmp.Length > 3 Then Row("col233") = CInt(sTmp.Substring(0, 4)) - CInt(Row("col232")) - CInt(Row("col231"))
            sTmp = Row("num234").ToString
            If sTmp.Length > 3 Then Row("col234") = CInt(sTmp.Substring(0, 4)) - CInt(Row("col233")) - CInt(Row("col232")) - CInt(Row("col231"))

            sTmp = Row("num241").ToString
            If sTmp.Length > 3 Then Row("col241") = CInt(sTmp.Substring(0, 4))
            sTmp = Row("num242").ToString
            If sTmp.Length > 3 Then Row("col242") = CInt(sTmp.Substring(0, 4)) - CInt(Row("col241"))
            sTmp = Row("num243").ToString
            If sTmp.Length > 3 Then Row("col243") = CInt(sTmp.Substring(0, 4)) - CInt(Row("col242")) - CInt(Row("col241"))
            sTmp = Row("num244").ToString
            If sTmp.Length > 3 Then Row("col244") = CInt(sTmp.Substring(0, 4)) - CInt(Row("col243")) - CInt(Row("col242")) - CInt(Row("col241"))

            sTmp = Row("num251").ToString
            If sTmp.Length > 3 Then Row("col251") = CInt(sTmp.Substring(0, 4))
            sTmp = Row("num252").ToString
            If sTmp.Length > 3 Then Row("col252") = CInt(sTmp.Substring(0, 4)) - CInt(Row("col251"))
            sTmp = Row("num253").ToString
            If sTmp.Length > 3 Then Row("col253") = CInt(sTmp.Substring(0, 4)) - CInt(Row("col252")) - CInt(Row("col251"))
            sTmp = Row("num254").ToString
            If sTmp.Length > 3 Then Row("col254") = CInt(sTmp.Substring(0, 4)) - CInt(Row("col253")) - CInt(Row("col252")) - CInt(Row("col251"))

        Next

        ReportGridView.BeginDataUpdate()
        ReportGridControl.DataSource = ReportTable
        ReportGridView.EndDataUpdate()
        ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("orgNameLong"), DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.MoveFirst()

        With ReportGridView
            .OptionsView.ColumnAutoWidth = False
            .Columns("orgId").Visible = False
            .Columns("orgNameLong").Caption = "Экспертная организация"
            .Columns("col231").Caption = "01.01.2023-31.03.2023"
            .Columns("col232").Caption = "01.04.2023-30.06.2023"
            .Columns("col233").Caption = "01.07.2023-30.09.2023"
            .Columns("col234").Caption = "01.10.2023-31.12.2023"
            .Columns("col241").Caption = "01.01.2024-31.03.2024"
            .Columns("col242").Caption = "01.04.2024-30.06.2024"
            .Columns("col243").Caption = "01.07.2024-30.09.2024"
            .Columns("col244").Caption = "01.10.2024-31.12.2024"
            .Columns("col251").Caption = "01.01.2025-31.03.2025"
            .Columns("col252").Caption = "01.04.2025-30.06.2025"
            .Columns("col253").Caption = "01.07.2025-30.09.2025"
            .Columns("col254").Caption = "01.10.2025-31.12.2025"
            .Columns("num231").Caption = "01.01.2023-31.03.2023"
            .Columns("num232").Caption = "01.04.2023-30.06.2023"
            .Columns("num233").Caption = "01.07.2023-30.09.2023"
            .Columns("num234").Caption = "01.10.2023-31.12.2023"
            .Columns("num241").Caption = "01.01.2024-31.03.2024"
            .Columns("num242").Caption = "01.04.2024-30.06.2024"
            .Columns("num243").Caption = "01.07.2024-30.09.2024"
            .Columns("num244").Caption = "01.10.2024-31.12.2024"
            .Columns("num251").Caption = "01.01.2025-31.03.2025"
            .Columns("num252").Caption = "01.04.2025-30.06.2025"
            .Columns("num253").Caption = "01.07.2025-30.09.2025"
            .Columns("num254").Caption = "01.10.2025-31.12.2025"
        End With

        MsgBox("OK")

    End Sub

    ''' <summary>
    ''' Отчет по приостановкам и возобновлениям работ
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WorkStopStartReport()
        '
        ' Таблица
        '
        Dim T As New DataTable
        With T.Columns
            .Add("id", GetType(Integer))
            .Add("typeName", GetType(String))
            .Add("orderNum", GetType(String))
            .Add("clientName", GetType(String))
            .Add("leaderName", GetType(String))
            .Add("expertName", GetType(String))
            .Add("stopDate", GetType(Date))         ' Дата остановки работы
            .Add("startDate", GetType(Date))        ' Дата возобновления работы
            .Add("stopComment", GetType(String))
            .Add("term", GetType(String))           ' разница дат
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}

        Dim emptyDate As Date = CDate("01.02.2025")
        Dim V As New DataView(T)
        V.RowFilter = String.Format("stopDate > '{0:dd.MM.yyyy}' AND startDate > '{0:dd.MM.yyyy}'", emptyDate)

        '
        ' Отчет
        '
        Dim dateB As Date = CDate("01.08.2026")
        Dim dateE As Date = CDate("01.09.2026")
        Dim dateStop As Date = Nothing
        Dim dateStart As Date = Nothing        
        Dim sTmp As String = String.Format( _
                "SELECT vWorkData.id, vWorkData.typeName, vWorkData.orderNum, vWorkData.clientName, vWorkData.expertName, vWorkData.leaderName " & _
                "FROM vWorkData " & _
                "WHERE vWorkData.conditionId <> 8 AND " & _
                "vWorkData.id IN (SELECT workId FROM tWorkHistory WHERE eventId = 32) AND " & _
                "vWorkData.createDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND " & _
                "vWorkData.createDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", dateB, dateE)
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = sTmp
            T.Load(Cmd.ExecuteReader)
            For i As Integer = 0 To T.Rows.Count - 1
                dateStop = emptyDate
                dateStart = emptyDate
                Cmd.CommandText = String.Format("SELECT * FROM tWorkHistory WHERE workId = {0} ORDER BY id", T(i)("id").ToString)
                Using dr As SqlClient.SqlDataReader = Cmd.ExecuteReader
                    While dr.Read
                        If CInt(dr("eventId")) = 32 And dateStop = emptyDate Then
                            T(i)("stopDate") = dr("eventDate")
                            T(i)("stopComment") = dr("comment")
                        End If
                        If CInt(dr("eventId")) = 34 And dateStart = emptyDate Then
                            T(i)("startDate") = dr("eventDate")
                        End If
                    End While
                End Using

                Me.Text = String.Format("{0} из {1}", i + 1, T.Rows.Count)
                Application.DoEvents()


            Next

        End Using
        Dim diff As TimeSpan
        'Dim totalSeconds As Long = 0
        'Dim workCount As Integer = 0
        For Each Row As DataRow In T.Rows
            If Not IsDBNull(Row("startDate")) And Not IsDBNull(Row("stopDate")) Then
                diff = Row("startDate") - Row("stopDate")
                'If workCount = 0 Then
                '    totalSeconds = diff.Ticks
                'Else
                '    totalSeconds += diff.Ticks
                'End If
                'workCount += 1
                'Row("dif") = diff.ToString("d\-hh\-mm")
                Row("term") = String.Format("{0:dd}д. {0:hh}ч. {0:mm}мин.", diff)
            End If
        Next
        'totalSeconds = totalSeconds / 10000000
        'totalSeconds = totalSeconds \ workCount
        'sTmp = String.Format("{0}д. {1}ч. {2}мин.", totalSeconds \ 86400, (totalSeconds Mod 86400) \ 3600, (totalSeconds Mod 3600) \ 60)
        'Clipboard.Clear()
        'Clipboard.SetText(sTmp)
        'MsgBox(String.Format("Среднее время: {0}", sTmp))

        ReportGridView.BeginDataUpdate()
        ReportGridControl.DataSource = V
        ReportGridView.EndDataUpdate()
        ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("term"), DevExpress.Data.ColumnSortOrder.Descending)
        ReportGridView.MoveFirst()
        MsgBox("OK")
    End Sub

    ''' <summary>
    ''' Отчет по датам создания и утверждения планов работ
    ''' </summary>
    Private Sub PlaneAcceptTermReport()
        '
        ' Таблица
        '
        Dim T As New DataTable
        With T.Columns
            .Add("id", GetType(Integer))
            .Add("orderNum", GetType(String))
            .Add("clientName", GetType(String))
            .Add("expertName", GetType(String))
            .Add("leaderName", GetType(String))
            .Add("pidDate", GetType(Date))          ' Дата создания заявки
            .Add("acceptDate", GetType(Date))       ' Дата утверждения плана работы
            .Add("dif", GetType(String))
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        '
        ' Отчет
        '
        Dim dateB As Date = CDate("01.08.2026")
        Dim dateE As Date = CDate("01.09.2026")
        Dim sTmp As String = String.Format( _
                "SELECT vWorkData.id, vWorkData.orderNum, vWorkData.clientName, vWorkData.expertName, vWorkData.leaderName, " & _
                "tWork.createDate AS pidDate, tWorkHistory.eventDate AS acceptDate " & _
                "FROM vWorkData " & _
                "LEFT JOIN tWork ON vWorkData.pId = tWork.id " & _
                "LEFT JOIN tWorkHistory ON vWorkData.id = tWorkHistory.workId AND tWorkHistory.eventId = 23 " & _
                "WHERE vWorkData.conditionId <> 8 AND NOT vWorkData.pId IS NULL AND " & _
                "vWorkData.createDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND " & _
                "vWorkData.createDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", dateB, dateE)
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = sTmp
            T.Load(Cmd.ExecuteReader)
            ' Уточнение даты плана если план утверждался несколько раз
            For Each Row As DataRow In T.Rows
                If IsDBNull(Row("acceptDate")) Then Continue For
                Cmd.CommandText = String.Format("SELECT MIN(eventDate) FROM tWorkHistory WHERE eventId = 23 AND workId = {0}", CInt(Row("id")))
                Row("acceptDate") = CDate(Cmd.ExecuteScalar)
            Next
        End Using
        Dim diff As TimeSpan
        Dim totalSeconds As Long = 0
        Dim workCount As Integer = 0
        For Each Row As DataRow In T.Rows
            If Not IsDBNull(Row("acceptDate")) Then
                diff = Row("acceptDate") - Row("pidDate")
                If workCount = 0 Then
                    totalSeconds = diff.Ticks
                Else
                    totalSeconds += diff.Ticks
                End If
                workCount += 1
                'Row("dif") = diff.ToString("d\-hh\-mm")
                Row("dif") = String.Format("{0:dd}д. {0:hh}ч. {0:mm}мин.", diff)
            End If
        Next
        totalSeconds = totalSeconds / 10000000
        totalSeconds = totalSeconds \ workCount
        sTmp = String.Format("{0}д. {1}ч. {2}мин.", totalSeconds \ 86400, (totalSeconds Mod 86400) \ 3600, (totalSeconds Mod 3600) \ 60)
        Clipboard.Clear()
        Clipboard.SetText(sTmp)
        MsgBox(String.Format("Среднее время: {0}", sTmp))

        ReportGridView.BeginDataUpdate()
        ReportGridControl.DataSource = T
        ReportGridView.EndDataUpdate()
        ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("dif"), DevExpress.Data.ColumnSortOrder.Descending)
        ReportGridView.MoveFirst()
        MsgBox("OK")
    End Sub

    ''' <summary>
    ''' Отчет о сроках выполнения этапов работ руководителями
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WorkEventLeaderTerm()

        ' Таблица отчета
        Dim ReportTable As New DataTable
        With ReportTable.Columns
            .Add("id", GetType(Integer))            ' id работы
            .Add("pid", GetType(Integer))           ' id заявки
            .Add("leaderName", GetType(String))     ' руководитель
            .Add("clientName", GetType(String))     ' заказчик
            .Add("orderNum", GetType(String))       ' номер заказа
            .Add("assignTerm", GetType(Single))     ' время распределения на эксперта, час
            .Add("planeAceptTerm", GetType(Single)) ' время утверждения плана работы
            .Add("workAcceptTerm", GetType(Single)) ' время утверждения работы
            .Add("primCreateDate", GetType(Date))   ' дата создания заявки
            .Add("workCreateDate", GetType(Date))   ' дата создания работы
            .Add("planeSendDate", GetType(Date))    ' дата первой отправки плана работы на утверждение
            .Add("planeAcceptDate", GetType(Date))  ' дата последнего утверждения плана работы
            .Add("workSendDate", GetType(Date))     ' дата первой отправки работы на утверждение
            .Add("workAcceptDate", GetType(Date))   ' дата последнего утверждения работы
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id")}

        ' Таблица событий работ
        Dim EventTable As New DataTable
        With EventTable.Columns
            .Add("id", GetType(Integer))
            .Add("eventId", GetType(Integer))
            .Add("eventDate", GetType(Date))
        End With
        EventTable.PrimaryKey = New DataColumn() {EventTable.Columns("id")}

        ' Представление таблицы событий отсортированное по дата
        Dim EventView As New DataView(EventTable) With {.Sort = "eventDate"}

        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand

            ' Выборка работ за период
            Cmd.CommandText = String.Format( _
                "SELECT id, pid, leaderName, clientName, orderNum, createDate AS workCreateDate " & _
                "FROM vWorkData WHERE NOT pid IS NULL AND typeId IN(1, 2, 3) AND conditionId = 7 AND " & _
                "createDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND createDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                CDate("01.06.2025"), CDate("01.09.2025"))
            ReportTable.Rows.Clear()
            ReportTable.Load(Cmd.ExecuteReader)

            Dim iTmp As Integer = 0

            ' Цикл по работам
            For Each Row As DataRow In ReportTable.Rows

                iTmp += 1
                Me.Text = String.Format("{0} из {1}", iTmp, ReportTable.Rows.Count)
                Application.DoEvents()

                ' Дата создания заявки
                Cmd.CommandText = String.Format("SELECT createDate FROM tWork WHERE id = {0}", CInt(Row("pid")))
                Row("primCreateDate") = CDate(Cmd.ExecuteScalar)

                ' Выборка событий работы                
                Cmd.CommandText = String.Format("SELECT id, eventId, eventDate FROM tWorkHistory WHERE workId = {0}", CInt(Row("id")))
                EventTable.Rows.Clear()
                EventTable.Load(Cmd.ExecuteReader)

                ' Цикл по событиям работы, определение дат событий
                For i As Integer = 0 To EventView.Count - 1
                    Select Case CInt(EventView(i)("eventId"))
                        Case 5  ' Отправка работы на утверждение
                            'If IsDBNull(Row("workSendDate")) Then
                            '    Row("workSendDate") = EventView(i)("eventDate")
                            '    Exit Select
                            'End If
                            Row("workSendDate") = EventView(i)("eventDate")
                            Exit Select
                        Case 7  ' Утверждение работы
                            Row("workAcceptDate") = EventView(i)("eventDate")
                            Exit Select
                        Case 22 ' Отправка плана на утверждение
                            'If IsDBNull(Row("planeSendDate")) Then
                            '    Row("planeSendDate") = EventView(i)("eventDate")
                            '    Exit Select
                            'End If
                            Row("planeSendDate") = EventView(i)("eventDate")
                            Exit Select
                        Case 23 ' Утверждение плана
                            Row("planeAcceptDate") = EventView(i)("eventDate")
                    End Select
                Next

                ' Время на рассмотрение заявки (мин)
                If Not IsDBNull(Row("primCreateDate")) AndAlso Not IsDBNull(Row("workCreateDate")) Then
                    Row("assignTerm") = Cprp.DxData.Work.Common.GetPlaneDateInterval( _
                        CDate(Row("primCreateDate")), CDate(Row("workCreateDate")))
                End If

                ' Время на утверждение плана (мин)
                If Not IsDBNull(Row("planeSendDate")) AndAlso Not IsDBNull(Row("planeAcceptDate")) Then
                    Row("planeAceptTerm") = Cprp.DxData.Work.Common.GetPlaneDateInterval( _
                        CDate(Row("planeSendDate")), CDate(Row("planeAcceptDate")))
                End If

                ' Время на утверждение работы (мин)
                If Not IsDBNull(Row("workSendDate")) AndAlso Not IsDBNull(Row("workAcceptDate")) Then
                    Row("workAcceptTerm") = Cprp.DxData.Work.Common.GetPlaneDateInterval( _
                        CDate(Row("workSendDate")), CDate(Row("workAcceptDate")))
                End If

            Next

        End Using

        ReportGridView.BeginDataUpdate()
        ReportGridControl.DataSource = ReportTable
        ReportGridView.EndDataUpdate()
        With ReportGridView
            .Columns("id").Caption = "Работа"
            .Columns("pid").Visible = False
            .Columns("leaderName").Caption = "Руководитель"
            .Columns("clientName").Caption = "Заказчик"
            .Columns("orderNum").Caption = "Заказ"
            .Columns("assignTerm").Caption = "Время на рассмотрение заявки (мин)"
            .Columns("planeAceptTerm").Caption = "Время на утверждение плана (мин)"
            .Columns("workAcceptTerm").Caption = "Время на утверждение работы (мин)"
            .Columns("primCreateDate").Caption = "Дата создания заявки"
            .Columns("workCreateDate").Caption = "Дата создания работы"
            .Columns("planeSendDate").Caption = "Дата отправки плана"
            .Columns("planeAcceptDate").Caption = "Дата утверждения плана"
            .Columns("workSendDate").Caption = "Дата отправки работы"
            .Columns("workAcceptDate").Caption = "Дата утверждения работы"
        End With
        ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("id"), DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.MoveFirst()

        MsgBox("OK")

    End Sub

    ''' <summary>
    ''' Отчет о сроках действующих заключений по работам
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WorkDocTerm()

        ' Таблица отчета
        Dim ReportTable As New DataTable
        With ReportTable.Columns
            .Add("id", GetType(Integer))            ' id работы
            .Add("docId", GetType(Integer))         ' id заключения в работе
            .Add("docNum", GetType(String))         ' номер заключения
            .Add("docDate", GetType(Date))          ' дата заключения
            .Add("docTerm", GetType(Date))          ' срок действия
            .Add("orderNum", GetType(String))       ' номер заказа
            .Add("clientName", GetType(String))     ' заказчик
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id"), ReportTable.Columns("docId")}

        ' Работа
        Dim W As New Cprp.DxData.Work.Excont.WorkConnectionRow(0, Program.DbClient.Connection)

        ' Временная таблица для номеров работ
        Dim TmpTable As New DataTable
        With TmpTable
            .Columns.Add("id", GetType(Integer))
            .PrimaryKey = New DataColumn() {.Columns("id")}
        End With

        ' Выборка номеров работ за последние два года
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = String.Format( _
                "SELECT id FROM tWork WHERE typeId IN(1, 2, 3) AND conditionId = 7 AND " & _
                "createDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}}", CDate("06.10.2023"))
            TmpTable.Rows.Clear()
            TmpTable.Load(Cmd.ExecuteReader)
        End Using

        Dim iTmp As Integer = 0
        Dim Row As DataRow = Nothing

        ' Цикл по работам
        For i As Integer = 0 To TmpTable.Rows.Count - 1

            Me.Text = String.Format("{0} из {1}", i + 1, TmpTable.Rows.Count)
            Application.DoEvents()

            W.Id = TmpTable(i)("id")

            If IsDBNull(W.ARow("docTerm")) Then Continue For
            If CDate(W.ARow("docTerm")) < Date.Now Then Continue For

            iTmp = Cprp.DxData.Common.ToInt(W.ARow("doc1SummaryId"))
            If iTmp = 1 OrElse iTmp = 5 Then
                If Not IsDBNull(W.ARow("doc1RegNum")) Then
                    Row = ReportTable.NewRow
                    Row("id") = W.Id
                    Row("docId") = 1
                    Row("docNum") = W.ARow("doc1RegNum")
                    If Not IsDBNull(W.ARow("doc1RegDate")) Then Row("docDate") = W.ARow("doc1RegDate")
                    Row("docTerm") = W.ARow("docTerm")
                    Row("orderNum") = W("orderNum")
                    Row("clientName") = W("clientName")
                    ReportTable.Rows.Add(Row)
                End If
            End If

            If Not String.IsNullOrWhiteSpace(W.ARow("doc2RegNum").ToString) Then
                Row = ReportTable.NewRow
                Row("id") = W.Id
                Row("docId") = 2
                Row("docNum") = W.ARow("doc2RegNum")
                If Not IsDBNull(W.ARow("doc2RegDate")) Then Row("docDate") = W.ARow("doc2RegDate")
                Row("docTerm") = W.ARow("docTerm")
                Row("orderNum") = W("orderNum")
                Row("clientName") = W("clientName")
                ReportTable.Rows.Add(Row)
            End If

        Next

        ReportGridView.BeginDataUpdate()
        ReportGridControl.DataSource = ReportTable
        ReportGridView.EndDataUpdate()
        With ReportGridView
            .Columns("id").Caption = "Работа"
            .Columns("docId").Visible = False
            .Columns("docNum").Caption = "Номер заключения"
            .Columns("docDate").Caption = "Дата заключения"
            .Columns("docTerm").Caption = "Срок действия"
            .Columns("orderNum").Caption = "Заказ"
            .Columns("clientName").Caption = "Заказчик"
        End With
        ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("id"), DevExpress.Data.ColumnSortOrder.Ascending)
        ReportGridView.MoveFirst()

        MsgBox("OK")

    End Sub


    ''' <summary>
    ''' Отчет по количеству выполненных по заказчикам по месяцам, начиная с 2021 г
    ''' </summary>
    Private Sub ClientWorkCountMonth()

        Dim startDate As Date = CDate("01.01.2021")
        Dim endDate As Date = New Date(Date.Today.Year, Date.Today.Month, 1)
        Dim clientSum As Integer = 0
        Dim dTmp As Date = Nothing
        Dim iTmp As Integer = 0


        ' Таблица отчета
        Dim ReportTable As New DataTable
        With ReportTable.Columns
            With .Add("id", GetType(Integer))
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            .Add("clientName", GetType(String))         ' наименование заказчика
            With .Add("clientInn", GetType(String))     ' ИНН заказчика
                .AllowDBNull = False
            End With
            .Add("wAll", GetType(Integer))
            ' количество заключений по месяцам
            dTmp = startDate
            Do
                If dTmp >= endDate Then Exit Do
                .Add(String.Format("c{0:yyyy_MM}", dTmp), GetType(Integer))
                dTmp = dTmp.AddMonths(1)
            Loop
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id")}

        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand

            ' Заполнение таблицы строками с заказчиками
            Cmd.CommandText = "SELECT DISTINCT clientName, clientInn FROM tWork WHERE typeId = 1 AND conditionId = 7 AND orderDate > {ts '2021-01-01 00:00:00'}"
            ReportTable.Load(Cmd.ExecuteReader)

            Me.Text = String.Format("Всего: {0}", ReportTable.Rows.Count)
            Application.DoEvents()


            'Цикл по строкам таблицы
            For i As Integer = 0 To ReportTable.Rows.Count - 1
                Me.Text = String.Format("{0} из {1}", i + 1, ReportTable.Rows.Count)
                Application.DoEvents()

                ' Цикл по месяцам
                dTmp = startDate
                clientSum = 0
                Do
                    If dTmp >= endDate Then
                        ReportTable.Rows(i)("wAll") = clientSum
                        Exit Do
                    End If
                    Cmd.CommandText = String.Format("SELECT count(*) FROM tWork WHERE typeId = 1 AND conditionId = 7 AND clientInn = '{0}' AND orderDate >=  {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND orderDate <  {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}", ReportTable.Rows(i)("clientInn").ToString, dTmp, dTmp.AddMonths(1))
                    iTmp = CInt(Cmd.ExecuteScalar)
                    ReportTable.Rows(i)(String.Format("c{0:yyyy_MM}", dTmp)) = iTmp
                    clientSum += iTmp
                    dTmp = dTmp.AddMonths(1)
                Loop

            Next

        End Using


        ReportGridView.BeginDataUpdate()
        ReportGridControl.DataSource = ReportTable
        ReportGridView.EndDataUpdate()
        ReportGridView.SortInfo.Insert(0, ReportGridView.Columns.ColumnByFieldName("wAll"), DevExpress.Data.ColumnSortOrder.Descending)
        ReportGridView.MoveFirst()

        With ReportGridView
            .OptionsView.ColumnAutoWidth = False
            .Columns("id").Visible = False
            .Columns("clientName").Caption = "Заказчик"
            .Columns("clientInn").Caption = "ИНН"
            .Columns("wAll").Caption = "Всего"
            For i As Integer = 0 To .Columns.Count - 1
                If .Columns(i).Name Like "*_*" Then
                    .Columns(i).Caption = .Columns(i).FieldName.Replace("_", ".").Replace("c", "")
                End If
            Next



        End With

        MsgBox("OK")

    End Sub

End Class