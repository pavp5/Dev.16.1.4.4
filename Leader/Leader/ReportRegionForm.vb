''' <summary>
''' Отчет по регионам за период
''' </summary>
Friend Class ReportRegionForm

    ''' <summary>
    ''' Справочник регионов
    ''' </summary>
    Private RegionTable As DataTable = Nothing


    Private Const APP_NAME As String = "Отчет по регионам"


    Friend Sub New()
        InitializeComponent()
        '
        ' RegionTable
        '
        RegionTable = New DataTable
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = "SELECT id, code, codeName FROM vRegion"
            RegionTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' DateBeginBarEditItem, DateEndBarEditItem, PeriodBarEditItem
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddMonths(-1 * Date.Today.Month + 1).AddDays(-1 * Date.Today.Day + 1)
        DateEndBarEditItem.EditValue = Date.Today
        PeriodBarEditItem.EditValue = 15
        '
        ' Me
        '
        Me.Icon = My.Resources.report_ico
        Me.Text = "Отчет - Количество заявок по регионам за период"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

    End Sub


    Private Sub ReportRunBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportRunBarButtonItem.ItemClick
        If DateBeginBarEditItem.EditValue Is Nothing Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите дату начала отчетного периода.", APP_NAME)
            Exit Sub
        End If
        If DateEndBarEditItem.EditValue Is Nothing Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите дату конца отчетного периода.", APP_NAME)
            Exit Sub
        End If

        Cprp.DxCommon.WaitForm.Show(Me)

        SP.BeginUpdate()
        SP.LoadDocument(My.Resources.report_region, DevExpress.Spreadsheet.DocumentFormat.Xlsx)

        Dim dateStart As Date = CDate(DateBeginBarEditItem.EditValue)
        Dim dateEnd As Date = CDate(DateEndBarEditItem.EditValue)
        Dim iPeriod As Integer = CInt(PeriodBarEditItem.EditValue)
        Dim dStart As Date = dateStart
        Dim dEnd As Date = dStart
        Dim iCol As Integer = 1

        Using V As New DataView(RegionTable) With {.Sort = "code"}
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                With SP.Document.Worksheets(0)
                    For i As Integer = 0 To V.Count - 1
                        dStart = dateStart
                        dEnd = dStart
                        iCol = 1
                        .Cells(i + 1, 0).Value = V(i)("codeName").ToString
                        Do
                            If dEnd >= dateEnd Then Exit Do
                            dStart = dEnd
                            dEnd = dStart.AddDays(iPeriod)
                            If dEnd > dateEnd Then dEnd = dateEnd
                            .Cells(0, iCol).Value = String.Format("{0:dd.MM.yyyy} {1:dd.MM.yyyy}", dStart, dEnd)
                            Cmd.CommandText = String.Format( _
                                "SELECT COUNT(*) FROM tWork WHERE typeId < 10 AND clientInn LIKE '{0}%' AND createDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND createDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}", _
                                V(i)("code").ToString, dStart, dEnd)
                            .Cells(i + 1, iCol).Value = CInt(Cmd.ExecuteScalar)
                            iCol += 1
                        Loop
                    Next
                End With
            End Using
        End Using

        SP.EndUpdate()

        Cprp.DxCommon.WaitForm.Close()

        Cprp.DxCommon.Messages.ShowInformation("Отчет построен.")

    End Sub

    Private Sub ExportExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportExcelBarButtonItem.ItemClick
        '
        ' Выбор файла для сохранения данных
        '
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Сохранение данных в файл"
            Dlg.FileName = "Отчет по регионам"
            Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx|Файл Microsoft Excel 97-2003 (*.xls)|*.xls"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        '
        ' Сохранение файла
        '
        Try
            If filePath Like "*xlsx" Then
                SP.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx)
            Else
                SP.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xls)
            End If
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка сохранения данных:{0}{1}", vbCrLf, ex.Message), "Отчет")
        End Try
    End Sub

End Class