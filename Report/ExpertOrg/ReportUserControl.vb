''' <summary>
''' Отчет по экспертным организациям
''' </summary>
Public Class ReportUserControl

    ''' <summary>
    ''' Открытое подключение к базе данных EXDB8
    ''' </summary>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Таблица отчета
    ''' </summary>
    Private ReportTable As ReportDataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных EXDB8</param>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        Me.Connection = Connection
        '
        ' ReportTable
        '
        ReportTable = New ReportDataTable
        '
        ' PercentChartControl
        '
        PercentChartControl.DataSource = ReportTable
        '
        ' CountChartControl
        '
        CountChartControl.DataSource = ReportTable
        '
        ' DateEndBarEditItem
        '
        DateEndBarEditItem.EditValue = Date.Today

        DataReload()

    End Sub


    ''' <summary>
    ''' Перечитать данные из базы
    ''' </summary>
    Private Sub DataReload()
        If DateEndBarEditItem.EditValue Is Nothing Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim dateE As Date = CDate(DateEndBarEditItem.EditValue)
        Dim dateB As Date = CDate(String.Format("01.01.{0}", dateE.Year))
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        PercentChartControl.BeginInit()
        CountChartControl.BeginInit()
        ReportTable.Rows.Clear()
        Using Cmd As SqlCommand = Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT orgId, orgNameShort, MAX(docNum) AS maxDocNum, 0 AS docCount FROM vFInfo WHERE docDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND docDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} GROUP BY orgId, orgNameShort", dateB, dateE.AddDays(1))
            ReportTable.Load(Cmd.ExecuteReader)
        End Using
        For Each Row In ReportTable.Rows
            sTmp = Cprp.DxData.Common.ToText(Row("maxDocNum"))
            If String.IsNullOrWhiteSpace(sTmp) OrElse Not sTmp Like "*-*" Then Continue For
            Row("docCount") = CInt(sTmp.Substring(0, sTmp.IndexOf("-")))
        Next
        PercentChartControl.EndInit()
        CountChartControl.EndInit()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    Private Sub EndRepositoryItemDateEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles EndRepositoryItemDateEdit.EditValueChanging
        DateEndBarEditItem.EditValue = e.NewValue
        DataReload()
    End Sub

    Private Sub PercentChartControl_SelectedItemsChanged(sender As Object, e As DevExpress.XtraCharts.SelectedItemsChangedEventArgs) Handles PercentChartControl.SelectedItemsChanged
        If e.NewItems.Count = 0 Then Exit Sub
        If Not TypeOf e.NewItems(0) Is DataRowView Then Exit Sub
        Dim orgId As Integer = CInt(CType(e.NewItems(0), DataRowView)("orgId"))
        For Each F As Form In Application.OpenForms
            If Not TypeOf F Is ExpertOrgForm Then Continue For
            If CType(F, ExpertOrgForm).OrgId = orgId Then
                F.WindowState = FormWindowState.Normal
                F.TopMost = False
                F.TopMost = True
                Exit Sub
            End If
        Next
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        With New ExpertOrgForm(orgId, Connection)
            .Show()
        End With
        Cprp.DxCommon.WaitForm.Close()
    End Sub

End Class
