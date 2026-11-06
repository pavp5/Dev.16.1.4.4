Imports C2 = Cprp.DxData.Common
''' <summary>
''' Отчет по новым товарам "Катерпиллер"
''' </summary>
''' <remarks></remarks>
Friend Class ReportCatUserControl

    Private ReportTable As DataTable = Nothing
    Private ReportView As DataView = Nothing

    Private Const ORDER_NUM As String = "02/15/523" ' Номер договора "Катерпиллер"


    Friend Sub New()
        InitializeComponent()
        '
        ' ReportTable
        '
        ReportTable = New DataTable
        With ReportTable.Columns
            .Add("id", GetType(Integer))
            .Add("rowNum", GetType(Integer))
            .Add("nameCon", GetType(String))
            .Add("nameDec", GetType(String))
            .Add("actDate", GetType(Date))
            .Add("isNew", GetType(Boolean)) ' признак нового товара
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id")}
        '
        ' ReportView
        '
        ReportView = New DataView(ReportTable)
        ReportView.RowFilter = "isNew = True"
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportView
        ReportGridView.SortInfo.Insert(0, RowNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' DateBeginBarEditItem, DateEndBarEditItem 
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddDays(-1 * Date.Today.Day + 1).AddMonths(-1)
        DateEndBarEditItem.EditValue = Date.Today.AddDays(-1 * Date.Today.Day)

    End Sub

    Private Sub ReportStartBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportStartBarButtonItem.ItemClick
        If DateBeginBarEditItem.EditValue Is Nothing Then Exit Sub
        If DateEndBarEditItem.EditValue Is Nothing Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
        Dim sTmp As String = Nothing
        Try
            ReportTable.Rows.Clear()
            '
            ' Строка ID работ Катерпиллер за указанный период
            '
            Cmd.CommandText = String.Format( _
                "SELECT id FROM tWork WHERE orderNum LIKE '{0}%' AND closeDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND closeDate <= {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}", _
                ORDER_NUM, CDate(DateBeginBarEditItem.EditValue), CDate(DateEndBarEditItem.EditValue))
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                While Dr.Read
                    sTmp = String.Format("{0}{1}{2}", sTmp, C2.FIELD_SEPARATOR, CInt(Dr(0)))
                End While
            End Using
            If Not C2.IsText(sTmp) Then GoTo ENDD
            '
            ' Выборка всех товаров Катерпиллер за указанный период
            '
            sTmp = C2.ToStrNum(sTmp, False)
            Cmd.CommandText = String.Format( _
                "SELECT id, nameCon, nameDec, actDate, 0 AS isNew FROM tGood WHERE id IN " & _
                "(SELECT goodId FROM tWorkDocGood WHERE workId IN ({0}))", sTmp)
            ReportTable.Load(Cmd.ExecuteReader)
            '
            ' Выделение новых товаров в выборке
            '
            Dim dTmp As Date = CDate(DateBeginBarEditItem.EditValue)
            Dim iTmp As Integer = 1
            Using V As New DataView(ReportTable)
                V.Sort = "actDate, nameCon, nameDec"
                For i As Integer = 0 To V.Count - 1
                    sTmp = C2.ToText(V(i)("nameDec"))
                    If Not C2.IsText(sTmp) Then Continue For
                    sTmp = sTmp.Replace("'", "''").ToUpper
                    Cmd.CommandText = String.Format( _
                        "SELECT COUNT(*) FROM tWork WHERE closeDate < {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND " & _
                        "id IN (SELECT workId FROM tWorkDocGood WHERE goodId IN (SELECT id FROM tGood WHERE nameDec LIKE '{1}'))", _
                        dTmp, sTmp)
                    If CInt(Cmd.ExecuteScalar) = 0 Then
                        ' Проверка наличия товара в старой базе Катерпиллер
                        Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tGoodCatOld WHERE nameDec LIKE '{0}'", sTmp)
                        If CInt(Cmd.ExecuteScalar) = 0 Then
                            ' Выделение нового товара
                            V(i).Row("isNew") = True
                            V(i).Row("rowNum") = iTmp
                            iTmp += 1
                        End If
                    End If
                Next
            End Using
ENDD:
            ReportGridControl.RefreshDataSource()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Готово.", "Отчет")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            If Not Cmd Is Nothing Then Cmd.Dispose()
        End Try

    End Sub

    Private Sub ReportExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportExcelBarButtonItem.ItemClick
        If ReportGridView.FocusedRowHandle < 0 Then Exit Sub
        Try
            Dim filePath As String = Nothing
            Using Dlg As New SaveFileDialog
                Dlg.Title = "Выбор файла для сохранения данных"
                Dlg.FileName = String.Format("Отчет по новым товарам Катерпиллер ({0:dd.MM.yyyy} - {1:dd.MM.yyyy})", CDate(DateBeginBarEditItem.EditValue), CDate(DateEndBarEditItem.EditValue))
                Dlg.DefaultExt = "xlsx"
                Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
                If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                filePath = Dlg.FileName
            End Using
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

End Class
