Imports System
Imports System.Data
Imports System.Windows.Forms
Imports DevExpress.XtraCharts
Friend Class MainForm

    ''' <summary>
    ''' Таблица отчета по количеству заключений выданых организациями
    ''' </summary>
    Private OrgReportTable As OrgReportDataTable = Nothing

    ''' <summary>
    ''' Таблица-справочник лет
    ''' </summary>
    Private YearTable As YearDataTable = Nothing

    ''' <summary>
    ''' Таблица-спраовочник месяцев
    ''' </summary>
    Private MonthTable As MonthDataTable = Nothing

    ''' <summary>
    ''' Таблица-справочник регионов
    ''' </summary>
    Private RegionTable As RegionDataTable = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' YearTable, YearLookUpEdit
        '
        YearTable = New YearDataTable
        YearLookUpEdit.Properties.DataSource = YearTable.DefaultView
        YearLookUpEdit.Properties.DropDownRows = YearTable.DefaultView.Count
        YearLookUpEdit.EditValue = Date.Today.Year
        '
        ' MonthTable, MonthLookUpEdit
        '
        MonthTable = New MonthDataTable
        MonthLookUpEdit.Properties.DataSource = MonthTable.DefaultView
        MonthLookUpEdit.Properties.DropDownRows = MonthTable.DefaultView.Count
        MonthLookUpEdit.EditValue = Date.Today.Month
        '
        ' RegionTable, RegionLookUpEdit
        '
        RegionTable = New RegionDataTable
        RegionLookUpEdit.Properties.DataSource = RegionTable.DefaultView
        RegionLookUpEdit.EditValue = "0"    ' Все регионы
        RegionLayoutControlItem.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never
        '
        ' OrgReportTable, OrgChartControl
        '
        OrgReportTable = New OrgReportDataTable
        OrgChartControl.DataSource = OrgReportTable
        PercentCheckEdit.Checked = True
        '
        ' Me
        '
        Me.Icon = My.Resources.insert_chart_ico
        Me.Text = "Отчет по экспертным организациям"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

    End Sub


    ''' <summary>
    ''' Загрузить данные отчета из базы данных
    ''' </summary>
    Private Sub DataReload()
        If OrgReportTable Is Nothing Then Exit Sub
        If YearLookUpEdit.EditValue Is Nothing Then Exit Sub
        If MonthLookUpEdit.EditValue Is Nothing Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me)
        Dim dateB As Date = CDate(String.Format("01.01.{0}", CInt(YearLookUpEdit.EditValue)))
        Dim dateE As Date = dateB.AddMonths(CInt(MonthLookUpEdit.EditValue))
        Dim sTmp As String = Cprp.DxData.Common.ToText(RegionLookUpEdit.EditValue)
        Dim Row As DataRow = Nothing
        Dim iTmp As Integer = 0
        OrgChartControl.BeginInit()
        OrgReportTable.Rows.Clear()
        Using Cmd As SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT orgId, orgNameShort, MAX(docNum) AS maxDocNum, 0 AS docCount FROM vFInfo WHERE docDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND docDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} GROUP BY orgId, orgNameShort", dateB, dateE)
            'If Not String.IsNullOrWhiteSpace(sTmp) AndAlso sTmp <> "0" Then
            '    Cmd.CommandText = Cmd.CommandText.Replace("GROUP BY", String.Format("AND rusInn LIKE '{0}%' GROUP BY", sTmp))
            'End If
            OrgReportTable.Load(Cmd.ExecuteReader)
            ' Кол-во заключений ФСТЭК из tResource
            Cmd.CommandText = "SELECT strData FROM tResource WHERE name LIKE 'FCOUNT'"
            sTmp = Cmd.ExecuteScalar.ToString
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso IsNumeric(sTmp) Then iTmp = CInt(sTmp)
        End Using
        For Each Row In OrgReportTable.Rows
            sTmp = Cprp.DxData.Common.ToText(Row("maxDocNum"))
            If String.IsNullOrWhiteSpace(sTmp) OrElse Not sTmp Like "*-*" Then Continue For
            Row("docCount") = CInt(sTmp.Substring(0, sTmp.IndexOf("-")))
        Next
        ' Заключения ФСТЭК с 2022 года, если нет в отчетах
        If dateB.Year > 2021 Then
            Using V As New DataView(OrgReportTable) With {.RowFilter = "orgId = 1"}
                If V.Count = 0 Then
                    Row = OrgReportTable.NewRow
                    Row("orgId") = 1
                    Row("orgNameShort") = "ФСТЭК России"
                    Row("maxDocNum") = String.Format("{0}-{1:yy}/7701350013", iTmp, Date.Today.Year)
                    Row("docCount") = iTmp
                    OrgReportTable.Rows.Add(Row)
                End If
            End Using
        End If
        OrgChartControl.EndInit()
        Cprp.DxCommon.WaitForm.Close()
    End Sub


    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        DataReload()
    End Sub

    Private Sub YearLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles YearLookUpEdit.EditValueChanged
        DataReload()
    End Sub

    Private Sub MonthLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles MonthLookUpEdit.EditValueChanged
        DataReload()
    End Sub

    Private Sub RegionLookUpEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RegionLookUpEdit.ButtonClick
        If e.Button.Index = 1 Then
            RegionLookUpEdit.ClosePopup()
            RegionLookUpEdit.EditValue = "0"
        End If
    End Sub

    Private Sub RegionLookUpEdit_EditValueChanged(sender As Object, e As EventArgs) Handles RegionLookUpEdit.EditValueChanged
        DataReload()
    End Sub

    Private Sub PercentCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles PercentCheckEdit.CheckedChanged
        If PercentCheckEdit.Checked Then
            OrgChartControl.Series("Count").Visible = False
            OrgChartControl.Series("Percent").Visible = True
        End If
    End Sub

    Private Sub CountCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles CountCheckEdit.CheckedChanged
        If CountCheckEdit.Checked Then
            OrgChartControl.Series("Percent").Visible = False
            OrgChartControl.Series("Count").Visible = True
        End If
    End Sub

    Private Sub OrgChartControl_SelectedItemsChanged(sender As Object, e As SelectedItemsChangedEventArgs) Handles OrgChartControl.SelectedItemsChanged
        If e.NewItems.Count = 0 Then Exit Sub
        If Not TypeOf e.NewItems(0) Is DataRowView Then Exit Sub
        MsgBox(CType(e.NewItems(0), DataRowView)("orgId").ToString)

    End Sub
End Class