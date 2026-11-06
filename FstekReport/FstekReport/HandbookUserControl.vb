Imports Cprp.DxData.Common
''' <summary>
''' Справочники программы
''' </summary>
Friend Class HandbookUserControl

    ''' <summary>
    ''' Источник данных отчета со всеми справочниками
    ''' </summary>
    Private Ds As ReportDataSet = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        InitializeComponent()
        '
        ' Ds
        '
        Ds = Program.DS
        '
        ' CountryGridControl, CountryGridView
        '
        CountryGridControl.DataSource = Ds.CountryHandbookTable
        CountryGridView.SortInfo.Insert(0, IdCountryGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' GoodCategoryGridControl, GoodCategoryGridView
        '
        GoodCategoryGridControl.DataSource = Ds.GoodCategoryHandbookTable
        GoodCategoryGridView.SortInfo.Insert(0, IdGoodCategoryGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' LawCaptionGridControl, LawCaptionGridView
        '
        LawCaptionGridControl.DataSource = Ds.LawCaptionHandbookTable
        LawCaptionGridView.SortInfo.Insert(0, IdLawCaptionGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' WorkSummaryGridControl, WorkSummaryGridView
        '
        WorkSummaryGridControl.DataSource = Ds.WorkSummaryHandbookTable
        WorkSummaryGridView.SortInfo.Insert(0, IdWorkSummaryGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' MainTabbedControlGroup
        '
        MainTabbedControlGroup.SelectedTabPage = CountryLayoutControlGroup
    End Sub


    ' Сохранить данные в базу данных
    Private Sub DataToBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataToBaseBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить данные в базу?") <> DialogResult.Yes Then Exit Sub
        Try
            Ds.CountryHandbookTable.DataSave(Program.DbClient.Connection)
            Ds.GoodCategoryHandbookTable.DataSave(Program.DbClient.Connection)
            Ds.LawCaptionHandbookTable.DataSave(Program.DbClient.Connection)
            Ds.WorkSummaryHandbookTable.DataSave(Program.DbClient.Connection)
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.")
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Перечитать данные из базы данных
    Private Sub DataFromBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataFromBaseBarButtonItem.ItemClick
        Try
            Ds.CountryHandbookTable.DataLoad(Program.DbClient.Connection)
            Ds.GoodCategoryHandbookTable.DataLoad(Program.DbClient.Connection)
            Ds.LawCaptionHandbookTable.DataLoad(Program.DbClient.Connection)
            Ds.WorkSummaryHandbookTable.DataLoad(Program.DbClient.Connection)
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.")
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Загрузить данные из файла xml
    Private Sub DataFromXmlBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataFromXmlBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.Filter = "Файл XML (*.xml)|*.xml"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        'Try
        Dim Row As DataRow = Nothing
        Dim X As New Xml.XmlDocument
        X.Load(sTmp)
        sTmp = Nothing
        For Each N As Xml.XmlNode In X.ChildNodes
            If N.Name.ToUpper <> "REPLICATOR_SL" Then Continue For
            For Each N1 As Xml.XmlNode In N.ChildNodes
                If N1.Name.ToUpper <> "STRUKT_SL" Then Continue For
                For Each N2 As Xml.XmlNode In N1.ChildNodes
                    Select Case N2.Name.ToUpper
                        Case "SL_COUNTRY_SL"            ' Страны мира
                            For Each Row In Ds.CountryHandbookTable.Rows
                                Row("guid") = DBNull.Value
                            Next
                            For Each N3 As Xml.XmlNode In N2.ChildNodes
                                If N3.Name.ToUpper <> "SLC_SL_REC" Then Continue For
                                Row = Ds.CountryHandbookTable.GetRowByCodDec(N3.Attributes("slc_deccode").InnerText)
                                If Not Row Is Nothing Then Row("guid") = N3.Attributes("slc_code").InnerText
                            Next
                            sTmp = String.Format("{0}Справочник стран мира обновлен.{1}", sTmp, vbCrLf)

                        Case "SL_LIST_SL"               ' Заголовки списков
                            For Each Row In Ds.LawCaptionHandbookTable.Rows
                                Row.Delete()
                            Next
                            For Each N3 As Xml.XmlNode In N2.ChildNodes
                                Row = Ds.LawCaptionHandbookTable.NewRow
                                Row("id") = Ds.LawCaptionHandbookTable.Rows.Count + 1
                                Row("guid") = N3.Attributes("sll_code").InnerText
                                Select Case N3.Attributes("sll_refchr").InnerText.ToUpper
                                    Case "ДН" : Row("doc") = "1030"
                                    Case "ЯО" : Row("doc") = "1050"
                                    Case "ХО" : Row("doc") = "1070"
                                    Case "РО" : Row("doc") = "1090"
                                    Case "БО" : Row("doc") = "1110"
                                    Case "ИС" : Row("doc") = "1130"
                                    Case Else : Continue For
                                End Select
                                For Each N4 As Xml.XmlNode In N3.ChildNodes
                                    If N4.Name.ToUpper = "SLL_NAME" Then
                                        Row("caption") = N4.InnerText
                                        Exit For
                                    End If
                                Next
                                Ds.LawCaptionHandbookTable.Rows.Add(Row)
                            Next
                            sTmp = String.Format("{0}Справочник заголовков списков обновлен.{1}", sTmp, vbCrLf)

                        Case "SL_TYPPRD_SL"             ' Категории объектов экспертизы
                            Using V As New DataView(Ds.GoodCategoryHandbookTable)
                                For Each N3 As Xml.XmlNode In N2.ChildNodes
                                    V.RowFilter = String.Format("code LIKE '{0}'", N3.Attributes("sltp_deccode").InnerText)
                                    For Each VRow As DataRowView In V
                                        VRow("guid") = N3.Attributes("sltp_code").InnerText
                                    Next
                                Next
                            End Using
                            sTmp = String.Format("{0}Справочник категорий объектов экспертизы обновлен.{1}", sTmp, vbCrLf)

                        Case "SL_SUMIDENTRES_SL"        ' Выводы экспертизы
                            Using V As New DataView(Ds.WorkSummaryHandbookTable)
                                For Each N3 As Xml.XmlNode In N2.ChildNodes
                                    V.RowFilter = String.Format("id = {0}", N3.Attributes("sir_cod").InnerText)
                                    For Each VRow As DataRowView In V
                                        VRow("guid") = N3.Attributes("sir_code").InnerText
                                    Next
                                Next
                            End Using
                            sTmp = String.Format("{0}Справочник выводов экспертизы обновлен.{1}", sTmp, vbCrLf)
                    End Select
                Next
            Next
        Next
        Cprp.DxCommon.WaitForm.Close()
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Не найдены данные для обновления.")
        Else
            Cprp.DxCommon.Messages.ShowInformation(sTmp.Substring(0, sTmp.Length - 2))
        End If

        'Catch ex As Exception
        '    Cprp.DxCommon.WaitForm.Close()
        '    Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        'End Try
    End Sub

End Class
