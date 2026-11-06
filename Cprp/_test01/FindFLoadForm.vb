Imports System.Data.SqlClient
Imports Cprp.DxData.Common
''' <summary>
''' Форма для загрузки данных из файла Excel в базу FDB
''' </summary>
Friend Class FindFLoadForm

    ''' <summary>
    ''' Таблица данных из файла Excel
    ''' </summary>
    Private ExcelTable As DataTable = Nothing

    ''' <summary>
    ''' Таблица заключений экспертизы
    ''' </summary>
    Private DocTable As DataTable = Nothing

    ''' <summary>
    ''' Таблица объектов экспертизы
    ''' </summary>
    Private GoodTable As DataTable = Nothing

    ''' <summary>
    ''' Таблица-справочник экспертных организаций
    ''' </summary>
    Private OrgTable As DataTable = Nothing
    Private OrgView As DataView = Nothing

    ''' <summary>
    ''' Подключение к базе данных FDB
    ''' </summary>
    Private Cn As SqlConnection = Nothing
    Private Cmd As SqlCommand = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' Cn, Cmd
        '
        Cn = New SqlConnection("Server=192.168.22.80;Database=FDB;Trusted_connection=Yes")
        Try
            Cn.Open()
            Cmd = New SqlCommand With {.Connection = Cn}
        Catch ex As Exception
            Button1.Enabled = False
            MsgBox(ex.Message)
            Exit Sub
        End Try
        '
        ' ExcelTable, GridControl1
        '
        ExcelTable = New DataTable("ExcelTable")
        With ExcelTable.Columns
            .Add("id", GetType(Integer))
            .Add("docNum", GetType(String))
            .Add("docDate", GetType(Date))
            .Add("conNum", GetType(String))
            .Add("conDate", GetType(Date))
            .Add("rusCaption", GetType(String))
            .Add("rusInn", GetType(String))
            .Add("nusCaption", GetType(String))
            .Add("endCaption", GetType(String))
            .Add("countryName", GetType(String))
            .Add("goodName", GetType(String))
            .Add("goodTnved", GetType(String))
            .Add("goodDescription", GetType(String))
            .Add("goodSummary", GetType(String))
            .Add("goodList", GetType(String))
            .Add("goodPos", GetType(String))
            .Add("summary", GetType(String))
            .Add("orgInn", GetType(String))
            .Add("orgId", GetType(Integer))
            .Add("docId", GetType(Integer))
        End With
        With ExcelTable.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        ExcelTable.PrimaryKey = New DataColumn() {ExcelTable.Columns("id")}
        GridControl1.DataSource = ExcelTable
        '
        ' DocTable
        '
        DocTable = New DataTable("DocTable")
        With DocTable.Columns
            .Add("id", GetType(Integer))
            .Add("orgId", GetType(Integer))
            .Add("docNum", GetType(String))
            .Add("docDate", GetType(Date))
            .Add("conNum", GetType(String))
            .Add("conDate", GetType(Date))
            .Add("rusCaption", GetType(String))
            .Add("rusInn", GetType(String))
            .Add("nusCaption", GetType(String))
            .Add("endCaption", GetType(String))
            .Add("countryName", GetType(String))
        End With
        With DocTable.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        DocTable.PrimaryKey = New DataColumn() {DocTable.Columns("id")}
        '
        ' GoodTable
        '
        GoodTable = New DataTable("GoodTable")
        With GoodTable.Columns
            .Add("id", GetType(Integer))
            .Add("docId", GetType(Integer))
            .Add("goodName", GetType(String))
            .Add("goodTnved", GetType(String))
            .Add("goodDescription", GetType(String))
            .Add("isEqual", GetType(Boolean))
            .Add("goodList", GetType(String))
            .Add("goodPos", GetType(String))
            .Add("summary", GetType(String))
        End With
        With GoodTable.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        GoodTable.PrimaryKey = New DataColumn() {GoodTable.Columns("id")}
        '
        ' OrgTable, OrgView
        '
        OrgTable = New DataTable("OrgTable")
        With OrgTable.Columns
            .Add("id", GetType(Integer))
            .Add("inn", GetType(String))
        End With
        OrgTable.PrimaryKey = New DataColumn() {OrgTable.Columns("id")}
        OrgView = New DataView(OrgTable)
        Cmd.CommandText = "SELECT id, inn FROM tOrg"
        OrgTable.Load(Cmd.ExecuteReader)

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sTmp As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор файла для загрузки данных"
            Dlg.DefaultExt = "xls"
            Dlg.Filter = "Файл Excel (*.xls)|*.xls"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            sTmp = Dlg.FileName
        End Using
        Try
            '
            ' Резервная копия
            '
            'Me.Text = "Copy FDB to xml..."
            'Using Ds As New DataSet("FDBData")
            '    Dim TGood As New DataTable("GoodTable")
            '    Cmd.CommandText = "SELECT * FROM tGood"
            '    TGood.Load(Cmd.ExecuteReader)
            '    Dim TDoc As New DataTable("DocTable")
            '    Cmd.CommandText = "SELECT * FROM tDoc"
            '    TDoc.Load(Cmd.ExecuteReader)
            '    Ds.Tables.AddRange(New DataTable() {TGood, TDoc})
            '    Ds.AcceptChanges()
            '    Ds.WriteXml("d:\fdbdata.xml", XmlWriteMode.WriteSchema)
            'End Using

            Dim Row As DataRow = Nothing
            Dim iTmp As Integer = 1
            '
            ' ExcelTable
            '
            GridView1.BeginDataUpdate()
            ExcelTable.Rows.Clear()
            Using SP As New DevExpress.XtraSpreadsheet.SpreadsheetControl
                SP.LoadDocument(sTmp, DevExpress.Spreadsheet.DocumentFormat.Xls)
                ExcelTable.Rows.Clear()
                With SP.Document.Worksheets(0)
                    Do
                        If Not IsText(.Cells(iTmp, 0).Value) Then Exit Do
                        Row = ExcelTable.NewRow
                        sTmp = ToText(.Cells(iTmp, 1).Value)
                        If IsText(sTmp) Then Row("docNum") = sTmp
                        sTmp = ToText(.Cells(iTmp, 2).Value)
                        If IsText(sTmp) AndAlso IsDate(sTmp) Then Row("docDate") = CDate(sTmp)
                        sTmp = ToText(.Cells(iTmp, 3).Value)
                        If IsText(sTmp) Then Row("conNum") = sTmp
                        sTmp = ToText(.Cells(iTmp, 4).Value)
                        If IsText(sTmp) AndAlso IsDate(sTmp) Then Row("conDate") = CDate(sTmp)
                        sTmp = ToText(.Cells(iTmp, 5).Value)
                        If IsText(sTmp) Then Row("rusCaption") = sTmp
                        sTmp = ToText(.Cells(iTmp, 6).Value)
                        If IsText(sTmp) Then Row("rusInn") = sTmp
                        sTmp = ToText(.Cells(iTmp, 7).Value)
                        If IsText(sTmp) Then Row("nusCaption") = sTmp
                        sTmp = ToText(.Cells(iTmp, 8).Value)
                        If IsText(sTmp) Then Row("endCaption") = sTmp
                        sTmp = ToText(.Cells(iTmp, 9).Value)
                        If IsText(sTmp) Then Row("countryName") = sTmp
                        sTmp = ToText(.Cells(iTmp, 10).Value)
                        If IsText(sTmp) Then Row("goodName") = sTmp
                        sTmp = ToText(.Cells(iTmp, 11).Value)
                        If IsText(sTmp) Then Row("goodTnved") = sTmp
                        sTmp = ToText(.Cells(iTmp, 12).Value)
                        If IsText(sTmp) Then Row("goodDescription") = sTmp
                        sTmp = ToText(.Cells(iTmp, 13).Value)
                        If IsText(sTmp) Then Row("goodSummary") = sTmp
                        sTmp = ToText(.Cells(iTmp, 14).Value)
                        If IsText(sTmp) Then Row("goodPos") = sTmp
                        sTmp = ToText(.Cells(iTmp, 15).Value)
                        If IsText(sTmp) Then Row("goodList") = sTmp
                        sTmp = ToText(.Cells(iTmp, 16).Value)
                        If IsText(sTmp) Then Row("summary") = sTmp
                        ExcelTable.Rows.Add(Row)
                        Me.Text = String.Format("ExcelTable ({0})", iTmp)
                        Application.DoEvents()
                        iTmp += 1
                    Loop
                End With
            End Using
            '
            ' ExcelTable.orgInn
            '
            For i As Integer = 0 To ExcelTable.Rows.Count - 1
                iTmp = -1
                sTmp = ToText(ExcelTable.Rows(i)("docNum"))
                If IsText(sTmp) Then iTmp = sTmp.IndexOf("/")
                If iTmp > 0 Then ExcelTable.Rows(i)("orgInn") = sTmp.Substring(iTmp + 1)
                Me.Text = String.Format("ExcelTable.orgInn ({0} из {1})", i + 1, ExcelTable.Rows.Count)
                Application.DoEvents()
            Next
            '
            ' ExcelTable.orgId
            '
            Using V As New DataView(OrgTable)
                For i As Integer = 0 To ExcelTable.Rows.Count - 1
                    sTmp = ToText(ExcelTable.Rows(i)("orgInn"))
                    V.RowFilter = String.Format("inn LIKE '{0}'", sTmp)
                    If V.Count > 0 Then ExcelTable.Rows(i)("orgId") = V(0)("id")
                    Me.Text = String.Format("ExcelTable.orgId ({0} из {1})", i + 1, ExcelTable.Rows.Count)
                    Application.DoEvents()
                Next
            End Using
            ExcelTable.AcceptChanges()
            '
            ' DocTable
            '
            Using A As New SqlDataAdapter("SELECT id, orgId, docNum, docDate, conNum, conDate, rusCaption, rusInn, nusCaption, endCaption, countryName FROM tDoc", Cn)
                Dim B As New SqlCommandBuilder(A)
                Using V As New DataView(ExcelTable) With {.Sort = "docNum"}
                    For i As Integer = 0 To ExcelTable.Rows.Count - 1
                        Me.Text = String.Format("DocTable ({0} из {1})", i + 1, V.Count)
                        Application.DoEvents()
                        sTmp = ToText(V(i)("docNum"))
                        If i > 0 AndAlso sTmp = ToText(V(i - 1)("docNum")) Then
                            V(i)("docId") = V(i - 1)("docId")
                            Continue For
                        End If
                        Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tDoc WHERE docNum LIKE '{0}'", sTmp)
                        If CInt(Cmd.ExecuteScalar) = 0 Then
                            Row = DocTable.NewRow
                            Row("orgId") = V(i)("orgId")
                            Row("docNum") = V(i)("docNum")
                            Row("docDate") = V(i)("docDate")
                            Row("conNum") = V(i)("conNum")
                            Row("conDate") = V(i)("conDate")
                            Row("rusCaption") = V(i)("rusCaption")
                            Row("rusInn") = V(i)("rusInn")
                            Row("nusCaption") = V(i)("nusCaption")
                            Row("endCaption") = V(i)("endCaption")
                            Row("countryName") = V(i)("countryName")
                            DocTable.Rows.Add(Row)
                            A.Update(DocTable)
                            Cmd.CommandText = "SELECT @@IDENTITY"
                            V(i)("docId") = CInt(Cmd.ExecuteScalar)
                        Else
                            Cmd.CommandText = String.Format("SELECT id FROM tDoc WHERE docNum LIKE '{0}'", sTmp)
                            iTmp = CInt(Cmd.ExecuteScalar)
                            V(i)("docId") = iTmp
                            Cmd.CommandText = String.Format("DELETE FROM tGood WHERE docId = {0}", iTmp)
                            Cmd.ExecuteNonQuery()
                        End If
                    Next
                End Using
            End Using
            ExcelTable.AcceptChanges()
            GridView1.EndDataUpdate()
            '
            ' tGood
            '
            Dim iCount As Integer = 0
            Using A As New SqlDataAdapter("SELECT id, docId, goodName, goodTnved, goodDescription, isEqual, goodPos, goodList, summary FROM tGood", Cn)
                Dim B As New SqlCommandBuilder(A)
                For Each ERow As DataRow In ExcelTable.Rows
                    iCount += 1
                    Me.Text = String.Format("GoodTable ({0} из {1})", iCount, ExcelTable.Rows.Count)
                    Application.DoEvents()
                    Row = GoodTable.NewRow
                    Row("docId") = ERow("docId")
                    Row("goodName") = ERow("goodName")
                    Row("goodTnved") = ERow("goodTnved")
                    Row("goodDescription") = ERow("goodDescription")
                    sTmp = ToText(ERow("goodSummary")).ToUpper
                    Row("isEqual") = (sTmp Like "СООТВЕТСТВУЕТ")
                    Row("goodPos") = ERow("goodPos")
                    Row("goodList") = ERow("goodList")
                    Row("summary") = ERow("summary")
                    GoodTable.Rows.Add(Row)
                    A.Update(GoodTable)
                Next
            End Using

            MsgBox("OK")

        Catch ex As Exception
            'Clipboard.Clear()
            'Clipboard.SetText(ex.Message)
            MsgBox(ex.Message)
            Exit Sub
        End Try

    End Sub

End Class