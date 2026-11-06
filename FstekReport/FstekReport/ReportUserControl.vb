Imports System.Xml
Imports Cprp.DxData
Imports Excel = Microsoft.Office.Interop.Excel
Imports Cprp.DxData.Common
''' <summary>
''' Отчет
''' </summary>
Friend Class ReportUserControl

    ''' <summary>
    ''' Источник данных отчета
    ''' </summary>
    Private Ds As ReportDataSet = Nothing

    ''' <summary>
    ''' Таблица отчета
    ''' </summary>
    Private ReportTable As ReportDataTable = Nothing


    ' Номер свидетельства
    Private Const REG_NUM As String = "001"

    ' Имя файлов отчета (zip, xls)
    Private reportName As String = Nothing

    ' Путь к папке отчета
    Private reportFolder As String = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' Ds
        '
        'Ds = New ReportDataSet(Program.DbClient.Connection)
        Ds = Program.DS
        '
        ' ReportTable
        '
        ReportTable = New ReportDataTable
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportTable

        '
        ' Даты начала и конца отчета (вчерашний рабочий день)
        '
        Dim dTmp As Date = Date.Today.AddDays(-1)
        If dTmp.DayOfWeek = DayOfWeek.Sunday Then dTmp = dTmp.AddDays(-1)
        If dTmp.DayOfWeek = DayOfWeek.Saturday Then dTmp = dTmp.AddDays(-1)
        ReportBeginDateBarEditItem.EditValue = dTmp
        'ReportEndDateBarEditItem.EditValue = dTmp.AddDays(1)
        ReportEndDateBarEditItem.EditValue = Date.Today
    End Sub


    ''' <summary>
    ''' Проверить наличие папки отчетов
    ''' </summary>
    ''' <remarks>
    ''' Папка отчетов должна находиться по пути '{Корневая папка отчетов}\yyyy\MM\dd'.
    ''' Если папка не существует, она создается
    ''' </remarks>
    Private Function ReportFolderExsist() As Boolean
        Dim sTmp As String = ToText(My.Settings.RootReportFolder)
        Try
            With My.Computer.FileSystem
                If Not (IsText(sTmp) AndAlso .DirectoryExists(sTmp)) Then
                    Using Dlg As New FolderBrowserDialog
                        Dlg.Description = "Укажите путь к корневой папке файлов отчетов"
                        Dlg.SelectedPath = My.Settings.RootReportFolder
                        If Dlg.ShowDialog <> DialogResult.OK Then Return False
                        sTmp = Dlg.SelectedPath
                        My.Settings.RootReportFolder = sTmp
                        My.Settings.Save()
                    End Using
                End If
                reportFolder = String.Format("{0}\{1:yyyy}\{1:MM}\{1:dd}", sTmp, Date.Today)
                If Not .DirectoryExists(reportFolder) Then .CreateDirectory(reportFolder)
            End With
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка создания папки отчета:{0}{1}", vbCrLf, ex.Message))
            Return False
        End Try
        Return True
    End Function

    ' Создать отчет
    Private Sub ReportRunBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportRunBarButtonItem.ItemClick
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ReportGridView.BeginDataUpdate()
        Ds.Clear()
        Ds.LoadData(ReportBeginDateBarEditItem.EditValue, ReportEndDateBarEditItem.EditValue)
        ReportTable.LoadData(Ds)
        ReportGridView.EndDataUpdate()
        ReportGridView.MoveFirst()
        ' имя отчета
        If Ds.DocTable.Rows.Count = 0 Then
            reportName = Nothing
        Else
            Using V As New DataView(Ds.DocTable) With {.Sort = "num"}
                reportName = String.Format("001 от {0:dd.MM.yyyy HH-mm-ss} закл. № {1}-{2}", Date.Now, CInt(V(0)("num")), CInt(V(V.Count - 1)("num")))
            End Using
        End If
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ' Открыть работу
    Private Sub WorkOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkOpenBarButtonItem.ItemClick
        If ReportGridView.FocusedRowHandle < 0 Then Exit Sub
        Program.MainForm.WorkOpen(ReportGridView.GetFocusedDataRow("workId"))
    End Sub

    ' Экспорт отчета в XML
    Private Sub ExportXmlBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportXmlBarButtonItem.ItemClick
        If Ds.DocTable.Rows.Count = 0 Then Exit Sub
        If reportName Is Nothing Then Exit Sub
        If Not ReportFolderExsist() Then Exit Sub
        With New Xml.XmlTextWriter("d:\zakl.xml", System.Text.Encoding.UTF8)
            .Formatting = Xml.Formatting.Indented
            .IndentChar = " "
            .WriteStartDocument()
            '
            ' Replicator_ICEO
            '
            .WriteStartElement("Replicator_ICEO")
            .WriteAttributeString("rep_data", String.Format("{0:dd.MM.yyyy HH:mm:ss}", Date.Now))
            .WriteAttributeString("code", Guid.NewGuid.ToString.Replace("-", Nothing))
            '
            ' strukt_ICEO
            '
            .WriteStartElement("strukt_ICEO")
            '
            ' zaklindexp_ICEO (заключения экспертизы)
            '
            .WriteStartElement("zaklindexp_ICEO")
            Using V As New DataView(Ds.DocTable) With {.Sort = "num"}
                For i As Integer = 0 To V.Count - 1
                    '
                    ' zie_ICEO_rec
                    '
                    .WriteStartElement("zie_ICEO_rec")
                    .WriteAttributeString("zie_code", V(i)("guid").ToString)
                    .WriteAttributeString("zie_zaklnum", ToText(V(i)("num")))
                    .WriteAttributeString("zie_zakldat", Format(CDate(V(i)("docDate")), "dd.MM.yyyy"))
                    .WriteAttributeString("zie_zaklend", If(IsDBNull(V(i)("docTerm")), String.Empty, Format(CDate(V(i)("docTerm")), "dd.MM.yyyy")))
                    .WriteAttributeString("zie_zaklendb", ToText(V(i)("docTermId")))
                    .WriteAttributeString("zie_dogend", If(IsDBNull(V(i)("conTerm")), String.Empty, Format(CDate(V(i)("conTerm")), "dd.MM.yyyy")))
                    .WriteAttributeString("zie_dogendb", ToText(V(i)("conTermId")))
                    .WriteAttributeString("zie_rosuchinn", ToText(V(i)("rusInn")))
                    .WriteAttributeString("zie_dogdat", If(IsDBNull(V(i)("conDate")), String.Empty, Format(CDate(V(i)("conDate")), "dd.MM.yyyy")))
                    .WriteAttributeString("zie_zaklfnum", V(i)("docNum").ToString)
                    .WriteAttributeString("zie_crtdate", Format(Date.Now, "dd.MM.yyyy"))
                    .WriteAttributeString("zie_zakinn", ToText(V(i)("clientInn")))
                    .WriteAttributeString("zie_inn", "7825056737")
                    .WriteAttributeString("otp_code", String.Empty)
                    .WriteAttributeString("sir_code", ToText(V(i)("sumGuid")))
                    .WriteAttributeString("zie_slcimpexp", If(CBool(V(i)("isExport")), "0", "1"))
                    .WriteAttributeString("zie_reslc", If(CBool(V(i)("isCountryEmbargo")), "1", "0"))
                    .WriteAttributeString("zie_reslcdat", String.Empty)
                    .WriteAttributeString("zie_resinuch", "0")
                    .WriteAttributeString("zie_resinuchdat", String.Empty)
                    .WriteAttributeString("zie_prn", ToText(V(i)("pvnId")))
                    .WriteAttributeString("zie_slc", ToText(V(i)("countryExistId")))
                    '.WriteAttributeString("zie_oldzaklfnum", ToText(V(i)("pDocNum")))
                    '.WriteAttributeString("zie_oldzaklfnum_code", ToText(V(i)("pGuid")))
                    .WriteAttributeString("zie_oldzaklfnum", String.Empty)
                    .WriteAttributeString("zie_oldzaklfnum_code", String.Empty)
                    .WriteAttributeString("zie_prodend", String.Empty)
                    .WriteAttributeString("zie_price", String.Empty)
                    .WriteElementString("zie_zakname", ToText(V(i)("clientName")))
                    .WriteElementString("zie_zakadru", ToText(V(i)("clientAddress")))
                    .WriteElementString("zie_zakadrf", String.Empty)
                    .WriteElementString("zie_rosuchname", ToText(V(i)("rusName")))
                    .WriteElementString("zie_rosuchadru", ToText(V(i)("rusAddress")))
                    .WriteElementString("zie_rosuchadrf", String.Empty)
                    .WriteElementString("zie_inuchname", ToText(V(i)("nusName")))
                    .WriteElementString("zie_inuchadr", ToText(V(i)("nusAddress")))
                    .WriteElementString("zie_dognum", ToText(V(i)("conNum")))
                    .WriteElementString("zie_sum", ToText(V(i)("dopInfo")))
                    .WriteElementString("zie_otpnote", String.Empty)
                    .WriteElementString("zie_sirtext", ToText(V(i)("sum")))
                    .WriteElementString("zie_dogname", ToText(V(i)("conName")))
                    .WriteElementString("zie_dognote", String.Empty)
                    .WriteElementString("zie_reslcnum", String.Empty)
                    .WriteElementString("zie_resinuchnum", String.Empty)
                    .WriteEndElement()      ' /zie_ICEO_rec
                Next
            End Using
            .WriteEndElement()      ' /zaklindexp_ICEO
            '
            ' zaklindexp_prd_ICEO (объекты экспертизы)
            '
            .WriteStartElement("zaklindexp_prd_ICEO")
            Using V As New DataView(Ds.GoodTable) With {.Sort = "docGuid, num"}
                For i As Integer = 0 To V.Count - 1
                    '
                    ' ziep_ICEO_rec
                    '
                    .WriteStartElement("ziep_ICEO_rec")
                    .WriteAttributeString("ziep_code", ToText(V(i)("guid")))
                    .WriteAttributeString("zie_code", ToText(V(i)("docGuid")))
                    .WriteAttributeString("sled_code", String.Empty)
                    .WriteAttributeString("ziep_num", ToText(V(i)("num")))
                    .WriteAttributeString("sltp_code", ToText(V(i)("catGuid")))
                    .WriteAttributeString("ziep_cnt", String.Empty)
                    .WriteAttributeString("ziep_reschk", "0")
                    .WriteAttributeString("ziep_reschkdat", String.Empty)
                    .WriteElementString("ziep_prodname", ToText(V(i)("name")))
                    .WriteElementString("ziep_prodhar", ToText(V(i)("description")))
                    .WriteElementString("ziep_reschknum", String.Empty)
                    .WriteElementString("sltn_cods", ToText(V(i)("tnved")))
                    .WriteEndElement()      ' /ziep_ICEO_rec
                Next
            End Using
            .WriteEndElement()      ' /zaklindexp_prd_ICEO
            If Ds.GoodLawTable.Rows.Count > 0 Then
                '
                ' zaklindexp_lst_ICEO (рассмотренные пункты контрольных списков)
                '
                .WriteStartElement("zaklindexp_lst_ICEO")
                Using V As New DataView(Ds.GoodLawTable) With {.Sort = "goodGuid, num"}
                    For i As Integer = 0 To V.Count - 1
                        '
                        ' zel_ICEO_rec
                        '
                        .WriteStartElement("zel_ICEO_rec")
                        .WriteAttributeString("ziep_code", ToText(V(i)("goodGuid")))
                        .WriteAttributeString("zel_code", ToText(V(i)("guid")))
                        .WriteAttributeString("sll_code", ToText(V(i)("lawGuid")))
                        .WriteAttributeString("zel_num", ToText(V(i)("num")))
                        .WriteElementString("zel_lstposnum", ToText(V(i)("pos")))
                        .WriteElementString("zel_lstposprt", ToText(V(i)("section")))
                        .WriteEndElement()      ' /zel_ICEO_rec
                    Next
                End Using
                .WriteEndElement()      ' /zaklindexp_lst_ICEO
                '
                ' zaklindexp_ran_ICEO (результаты сравнения с пунктами контрольных списков)
                '
                .WriteStartElement("zaklindexp_ran_ICEO")
                Using V As New DataView(Ds.GoodLawTable) With {.Sort = "goodGuid, num"}
                    For i As Integer = 0 To V.Count - 1
                        '
                        ' zer_ICEO_rec
                        '
                        .WriteStartElement("zer_ICEO_rec")
                        .WriteAttributeString("ziep_code", ToText(V(i)("goodGuid")))
                        .WriteAttributeString("zer_code", Guid.NewGuid.ToString.Replace("-", Nothing))
                        .WriteAttributeString("zer_resanlsum", ToText(V(i)("sumId")))
                        .WriteAttributeString("zer_num", ToText(V(i)("num")))
                        .WriteElementString("zer_resanlhar", ToText(V(i)("goodDescription")))
                        .WriteElementString("zer_resanldsc", ToText(V(i)("lawDescription")))
                        .WriteEndElement()      ' /zer_ICEO_rec
                    Next
                End Using
                .WriteEndElement()      ' /zaklindexp_ran_ICEO
            End If
            '
            ' relc_ICEO (страны назначения / отправления)
            '
            .WriteStartElement("relc_ICEO")
            Using V As New DataView(Ds.DocTable) With {.Sort = "num"}
                For i As Integer = 0 To V.Count - 1
                    ' 999 - не определена
                    If IsDBNull(V(i)("countryGuid")) Then Continue For
                    '
                    ' relc_ICEO_rec
                    '
                    .WriteStartElement("relc_ICEO_rec")
                    .WriteAttributeString("zie_code", ToText(V(i)("guid")))
                    .WriteAttributeString("slc_code", ToText(V(i)("countryGuid")))
                    .WriteEndElement()      ' /relc_ICEO_rec
                Next
            End Using
            .WriteEndElement()      ' /relc_ICEO
            '
            ' zaklindexp_eus_ICE (конечные пользователи)
            '
            .WriteStartElement("zaklindexp_eus_ICEO")
            Using V As New DataView(Ds.EndTable) With {.Sort = "docGuid"}
                For i As Integer = 0 To V.Count - 1
                    '
                    ' zoeu_ICEO_rec
                    '
                    .WriteStartElement("zoeu_ICEO_rec")
                    .WriteAttributeString("zoeu_code", ToText(V(i)("guid")))
                    .WriteAttributeString("zie_code", ToText(V(i)("docGuid")))
                    .WriteAttributeString("slc_code", ToText(V(i)("countryGuid")))
                    .WriteElementString("zoeu_name", ToText(V(i)("name")))
                    .WriteElementString("zoeu_adr", ToText(V(i)("address")))
                    .WriteEndElement()      ' /zoeu_ICEO_rec
                Next
            End Using
            .WriteEndElement()      ' /zaklindexp_eus_ICE
            '
            ' zaklindexp_sng_ICEO (лица, подписавшие заключения)
            '
            .WriteStartElement("zaklindexp_sng_ICEO")
            Using V As New DataView(Ds.UserTable) With {.Sort = "docGuid"}
                For i As Integer = 0 To V.Count - 1
                    '
                    ' zies_ICEO_rec
                    '
                    .WriteStartElement("zies_ICEO_rec")
                    .WriteAttributeString("zies_code", ToText(V(i)("guid")))
                    .WriteAttributeString("zie_code", ToText(V(i)("docGuid")))
                    .WriteAttributeString("zies_num", "1")
                    .WriteElementString("zies_dlg", ToText(V(i)("job")))
                    .WriteElementString("zies_fam", ToText(V(i)("nameLast")))
                    .WriteElementString("zies_name", ToText(V(i)("nameFirst")))
                    .WriteElementString("zies_otch", ToText(V(i)("nameMiddle")))
                    .WriteEndElement()      ' /zies_ICEO_rec
                Next
            End Using
            .WriteEndElement()      ' /zaklindexp_sng_ICEO


            .WriteEndElement()      ' /strukt_ICEO
            .WriteEndElement()      ' /Replicator_ICEO
            .WriteEndDocument()
            .Close()
        End With
        Ds.Dispose()
        My.Computer.FileSystem.WriteAllText("d:\SvedOrg.xml", My.Resources.SvedOrg, False)
        '
        ' Архивирование данных
        '
        Using zip As Ionic.Zip.ZipFile = New Ionic.Zip.ZipFile
            zip.AddFile("d:\zakl.xml")
            zip.AddFile("d:\SvedOrg.xml")
            zip.Save(String.Format("{0}\{1}.zip", reportFolder, reportName))
        End Using
        With My.Computer.FileSystem
            .DeleteFile("d:\zakl.xml")
            .DeleteFile("d:\SvedOrg.xml")
        End With

        Cprp.DxCommon.Messages.ShowInformation(String.Format("Данные сохранены в файл ""{0}\{1}.zip""", reportFolder, reportName))
    End Sub


    ' Экспорт отчета в файл MS Excel
    Private Sub ExportExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportExcelBarButtonItem.ItemClick
        If Ds.DocTable.Rows.Count = 0 Then Exit Sub
        If reportName Is Nothing Then Exit Sub
        If Not ReportFolderExsist() Then Exit Sub
        Dim EApp As Excel.Application = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            Dim sTmp As String = My.Computer.FileSystem.GetTempFileName
            My.Computer.FileSystem.WriteAllBytes(sTmp, My.Resources.report_template, False)
            EApp = New Excel.Application
            EApp.Visible = False
            EApp.Workbooks.Open(sTmp)
            Using V As New DataView(ReportTable)
                V.Sort = "docNum, goodId"
                For i As Integer = 0 To V.Count - 1
                    With EApp.Workbooks(1).Worksheets(1)
                        .Cells(i + 6, 2) = REG_NUM
                        .Cells(i + 6, 3) = ToText(V(i)("docNum"))
                        If IsText(V(i)("docDate")) Then .Cells(i + 6, 4) = Format(CDate(V(i)("docDate")), "dd.MM.yyyy")
                        .Cells(i + 6, 5) = ToText(V(i)("clientCaption"))
                        .Cells(i + 6, 6) = ToText(V(i)("contractNum"))
                        If IsText(V(i)("contractDate")) Then .Cells(i + 6, 7) = Format(CDate(V(i)("contractDate")), "dd.MM.yyyy")
                        .Cells(i + 6, 8) = ToText(V(i)("rusCaption"))
                        .Cells(i + 6, 9) = ToText(V(i)("rusInn"))
                        .Cells(i + 6, 10) = ToText(V(i)("nusCaption"))
                        .Cells(i + 6, 11) = ToText(V(i)("endCaption"))
                        .Cells(i + 6, 12) = ToText(V(i)("countryCaption"))
                        .Cells(i + 6, 13) = ToText(V(i)("goodName"))
                        sTmp = ToText(V(i)("goodTnved"))
                        If IsText(sTmp) AndAlso sTmp.Length > 10 Then sTmp = sTmp.Substring(0, 10)
                        .Cells(i + 6, 16) = sTmp
                        .Cells(i + 6, 17) = ToText(V(i)("goodDescription"))
                        .Cells(i + 6, 18) = ToText(V(i)("goodCategory"))
                        .Cells(i + 6, 20) = ToText(V(i)("goodLawPos"))
                        .Cells(i + 6, 21) = ToText(V(i)("goodLawList"))
                        .Cells(i + 6, 22) = ToText(V(i)("docSummary"))

                        .Cells(i + 6, 25) = ToText(V(i)("goodUsed"))
                        .Cells(i + 6, 26) = CInt(V(i)("goodSummaryId"))
                        .Cells(i + 6, 27) = ToText(V(i)("goodLawDescription"))
                        .Cells(i + 6, 28) = ToText(V(i)("goodLawCharaster"))
                        sTmp = V(i)("contractTerm").ToString
                        If Not String.IsNullOrWhiteSpace(sTmp) Then
                            .Cells(i + 6, 29).Value = Format(CDate(sTmp), "dd.MM.yyyy")
                        End If
                        sTmp = ToText(V(i)("docTermId"))
                        If IsText(sTmp) Then .Cells(i + 6, 30).Value = CInt(sTmp)
                        sTmp = V(i)("docTerm").ToString
                        If Not String.IsNullOrWhiteSpace(sTmp) Then
                            .Cells(i + 6, 31).Value = Format(CDate(sTmp), "dd.MM.yyyy")
                        End If
                        .Cells(i + 6, 32).Value = CInt(V(i)("docSummaryId"))
                        .Cells(i + 6, 33).Value = CInt(V(i)("countryEmbargoId"))
                        .Cells(i + 6, 34).Value = CInt(V(i)("memberEmbargoId"))
                        .Cells(i + 6, 35).Value = CInt(V(i)("goodEmbargoId"))
                        .Cells(i + 6, 36).Value = If(CBool(V(i)("isExport")), 1, 0)
                        .Cells(i + 6, 37) = ToText(V(i)("countryCaption2"))
                        Select Case CType(V(i)("docSummaryId"), Cprp.DxData.Work.WorkSummary)
                            Case Cprp.DxData.Work.WorkSummary.IsPermit, Cprp.DxData.Work.WorkSummary.IsDecree
                                .Cells(i + 6, 19).Value = "Соответствует"
                                .Cells(i + 6, 23).Value = "требуется разрешение"
                                ' очистить поля с пунктами контрольных списков
                                .Cells(i + 6, 20) = Nothing
                                .Cells(i + 6, 21) = Nothing
                                .Cells(i + 6, 27) = Nothing
                                .Cells(i + 6, 28) = Nothing
                            Case Cprp.DxData.Work.WorkSummary.IsLicense
                                .Cells(i + 6, 19).Value = "Соответствует"
                                .Cells(i + 6, 23).Value = "требуется лицензия"
                            Case Else
                                .Cells(i + 6, 19).Value = "Не соответствует"
                                .Cells(i + 6, 23).Value = "б/л вывоз"
                        End Select
                        .Cells(i + 6, 24).Value = 1
                        .Rows(i + 6).WrapText = False
                    End With
                Next
            End Using
            EApp.Workbooks(1).SaveAs(String.Format("{0}\{1}.xls", reportFolder, reportName))
            EApp.Workbooks(1).Close(0)

            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation(String.Format("Данные сохранены в файл ""{0}\{1}.xls""", reportFolder, reportName))
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            If Not EApp Is Nothing Then
                EApp.Quit()
                EApp = Nothing
            End If
        End Try
    End Sub


    ' Указать путь к корневой папке файлов отчетов
    Private Sub ExportFolderBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportFolderBarButtonItem.ItemClick
        Using Dlg As New FolderBrowserDialog
            Dlg.Description = "Укажите путь к корневой папке файлов отчетов"
            Dlg.SelectedPath = My.Settings.RootReportFolder
            If Dlg.ShowDialog = DialogResult.OK Then My.Settings.RootReportFolder = Dlg.SelectedPath
        End Using
    End Sub

    ' Отправить отчет по электронной почте
    Private Sub SendSendBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SendSendBarButtonItem.ItemClick
        If Ds.DocTable.Rows.Count = 0 Then Exit Sub
        With My.Computer.FileSystem
            If reportFolder Is Nothing OrElse Not .DirectoryExists(reportFolder) Then
                Cprp.DxCommon.Messages.ShowError("Отсутствует папка с файлами отчета!")
                Exit Sub
            End If
            If .GetFiles(reportFolder).Count = 0 Then
                Cprp.DxCommon.Messages.ShowError("В папкие файлов отчета отсутствуют файлы!")
                Exit Sub
            End If
        End With
        With New SendForm(reportFolder, CDate(ReportBeginDateBarEditItem.EditValue))
            If .ShowDialog(Me) <> DialogResult.OK Then Exit Sub
        End With
        '
        ' Запись события отправки в истории работ
        '
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            Using V As New DataView(ReportTable) With {.Sort = "workId"}
                For i As Integer = 0 To V.Count - 1
                    If i > 0 AndAlso CInt(V(i)("workId")) = CInt(V(i - 1)("workId")) Then Continue For
                    Cprp.DxData.Work.Common.WriteHistory( _
                        V(i)("workId"), Work.WorkEvent.FstekReport, Program.DbClient.Id, Nothing, Program.DbClient.Connection)
                Next
            End Using
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Отчет отправлен.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

End Class
