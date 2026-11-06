Imports Cprp.DxData.Common

Friend Class MainForm

    ''' <summary>
    ''' Таблица товаров из файла спецификации
    ''' </summary>
    Private GoodTable As GoodDataTable = Nothing

    ''' <summary>
    ''' Данные файла спецификации
    ''' </summary>
    Private SP As DevExpress.XtraSpreadsheet.SpreadsheetControl = Nothing

    ''' <summary>
    ''' Таблица - справочник кодов ТН ВЭД
    ''' </summary>
    Private TnvedTable As DataTable = Nothing


    Private fileName As String = Nothing    ' имя файла спецификации

    Private fileExt As String = Nothing     ' расширение файла спецификации


    Private hs_colnum As Integer = 1        ' номер столбца спецификации с кодами HS

    Private name_colnum As Integer = 0      ' номер столбца спецификации с наименованиями товаров


    Friend Sub New()
        InitializeComponent()
        '
        ' GoodTable
        '
        GoodTable = New GoodDataTable
        '
        ' SP
        '
        SP = New DevExpress.XtraSpreadsheet.SpreadsheetControl
        '
        ' GoodGridControl, GoodGridView
        '
        GoodGridControl.DataSource = GoodTable
        GoodGridControl.Dock = DockStyle.Fill
        GoodGridView.SortInfo.Insert(0, IdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' TnvedTable
        '
        TnvedTable = New DataTable
        TnvedTable.Columns.Add("code", GetType(String))
        TnvedTable.PrimaryKey = New DataColumn() {TnvedTable.Columns("code")}
        Using Cmd As New SqlClient.SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = String.Format("SELECT DISTINCT code AS code, unit FROM tTnved WHERE LEN(code) = 10 AND dateB <= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND dateE > {{ts '{0:yyyy-MM-dd HH:mm:ss}'}}", Date.Now)
            TnvedTable.Load(Cmd.ExecuteReader)
        End Using

        '
        ' Me
        '
        Me.Text = Cprp.DxCommon.Application.AppName
        Me.Icon = My.Resources.view_details_ico
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

    End Sub


    ' Загрузить данные из файла спецификации
    Private Sub FileLoadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileLoadBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор файла спецификации"
            Dlg.Filter = "Файл Microsoft Excel (*.xls;*.xlsx)|*.xls;*.xlsx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me)
        With My.Computer.FileSystem.GetFileInfo(sTmp)
            fileName = .Name.Substring(0, .Name.Length - (.Extension.Length))
            fileExt = .Extension
        End With
        SP.LoadDocument(sTmp)
        GoodGridView.BeginDataUpdate()
        GoodTable.Rows.Clear()
        With SP.Document.Worksheets(0)
            Do
                iTmp += 1
                Me.Text = String.Format("Загрузка данных ({0})", iTmp)
                Application.DoEvents()
                sTmp = ToText(.Cells(iTmp, name_colnum).Value)
                If String.IsNullOrWhiteSpace(sTmp) Then Exit Do
                GoodTable.Rows.Add(New Object() {iTmp, sTmp, DbText(.Cells(iTmp, hs_colnum).Value), DBNull.Value})
            Loop
            .Columns.Insert(hs_colnum + 6)
            .Cells(0, hs_colnum + 6).Value = "ТН ВЭД код"
            .Columns.Insert(hs_colnum + 7)
            .Cells(0, hs_colnum + 7).Value = "Доп. ед. изм"
        End With
        GoodGridView.EndDataUpdate()
        InfoBarStaticItem.Caption = String.Format("Всего: {0}", GoodTable.Rows.Count)
        Me.Text = Cprp.DxCommon.Application.AppName
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation(String.Format("Загружено записей: {0}.", GoodTable.Rows.Count))
    End Sub

    ' Сохранить данные в файл спецификации
    Private Sub FileSaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FileSaveBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла спецификации"
            If Not String.IsNullOrWhiteSpace(fileName) Then
                Dlg.FileName = String.Format("{0}_тнвэд", fileName)
                Dlg.DefaultExt = fileExt
            End If
            Dlg.Filter = "Файл Microsoft Excel 2007 (*.xlsx)|*.xlsx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me)
        With GoodGridView
            .CloseEditor()
            .UpdateCurrentRow()
        End With
        With SP.Document.Worksheets(0)
            For i As Integer = 0 To GoodTable.Rows.Count - 1
                Me.Text = String.Format("Подготовка данных ({0})", i + 1)
                Application.DoEvents()
                '.Cells(CInt(GoodTable(i)("id")), 0).Value = ToText(.Cells(CInt(GoodTable(i)("id")), 0).Value)
                '.Cells(CInt(GoodTable(i)("id")), 1).Value = ToText(.Cells(CInt(GoodTable(i)("id")), 1).Value)
                '.Cells(CInt(GoodTable(i)("id")), 2).Value = ToText(.Cells(CInt(GoodTable(i)("id")), 2).Value)
                '.Cells(CInt(GoodTable(i)("id")), 3).Value = ToText(.Cells(CInt(GoodTable(i)("id")), 3).Value)
                '.Cells(CInt(GoodTable(i)("id")), 4).Value = ToText(.Cells(CInt(GoodTable(i)("id")), 4).Value)
                '.Cells(CInt(GoodTable(i)("id")), 5).Value = ToText(.Cells(CInt(GoodTable(i)("id")), 5).Value)
                '.Cells(CInt(GoodTable(i)("id")), 6).Value = ToText(.Cells(CInt(GoodTable(i)("id")), 6).Value)
                .Cells(CInt(GoodTable(i)("id")), hs_colnum + 6).Value = ToText(GoodTable(i)("tnved_code"))
                .Cells(CInt(GoodTable(i)("id")), hs_colnum + 7).Value = ToText(GoodTable(i)("unit"))
            Next
        End With
        SP.Document.SaveDocument(sTmp, DevExpress.Spreadsheet.DocumentFormat.Xlsx)
        Me.Text = Cprp.DxCommon.Application.AppName
        Cprp.DxCommon.WaitForm.Close()
        If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Данные сохранены в файл {0}.{1}Открыть файл?", sTmp, vbCrLf)) = Windows.Forms.DialogResult.Yes Then
            Using P As New Process
                P.StartInfo.FileName = sTmp
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        End If
    End Sub

    ' Определить коды ТН ВЭД по кодам HS
    Private Sub TnvedBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TnvedBarButtonItem.ItemClick
        Dim hasCount As Integer = 0     ' количество совпадающих кодов ТН ВЭД
        Dim noCount As Integer = 0      ' количество отсутствующих кодов ТН ВЭД
        Dim s_count As Integer = 0      ' количество совпадающих символов текущего кода HS и кода ТН ВЭД
        Dim sTmp As String = Nothing

        Cprp.DxCommon.WaitForm.Show(Me)

        Using V As New DataView(TnvedTable) With {.Sort = "code"}

            For i As Integer = 0 To GoodTable.Rows.Count - 1
                Me.Text = String.Format("Обработка данных ({0})", i - 1)
                Application.DoEvents()
                '
                ' Код HS
                '
                sTmp = ToText(GoodTable(i)("hs_code"))
                If String.IsNullOrWhiteSpace(sTmp) Then
                    GoodTable(i)("s_count") = 0
                    noCount += 1
                    Continue For
                End If
                If sTmp.Length > 10 Then sTmp = sTmp.Substring(0, 10)
                '
                ' Полное совпадение
                '
                V.RowFilter = String.Format("code = '{0}'", sTmp)
                If V.Count > 0 Then
                    GoodTable(i)("tnved_code") = sTmp
                    GoodTable(i)("s_count") = 10
                    GoodTable(i)("unit") = V(0)("unit")
                    hasCount += 1
                    Continue For
                End If
                '
                ' Частичное совпадение
                '
                s_count = 9
                Do
                    If s_count < 4 OrElse sTmp.Length <= s_count Then
                        GoodTable(i)("s_count") = 0
                        noCount += 1
                        Continue For
                    End If
                    sTmp = sTmp.Substring(0, s_count)
                    V.RowFilter = String.Format("code LIKE '{0}%'", sTmp)
                    If V.Count > 0 Then
                        GoodTable(i)("tnved_code") = V(V.Count - 1)("code")
                        GoodTable(i)("s_count") = s_count
                        GoodTable(i)("unit") = V(V.Count - 1)("unit")
                        Continue For
                    End If
                    s_count -= 1
                Loop

            Next

        End Using

        InfoBarStaticItem.Caption = String.Format("Всего: {0}, полное совпадение: {1}, отсутствуют: {2}.", GoodTable.Rows.Count, hasCount, noCount)
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation(String.Format("Обработка завершена.{0}{1}", vbCrLf, InfoBarStaticItem.Caption))
        Me.Text = Cprp.DxCommon.Application.AppName

    End Sub

End Class