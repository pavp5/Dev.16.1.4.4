Imports Cprp.DxData.Common
''' <summary>
''' Отчет по заказчикам услуг
''' </summary>
Public Class ReportUserControl

    ''' <summary>
    ''' Таблица отчета
    ''' </summary>
    Private ReportTable As DataTable = Nothing

    ''' <summary>
    ''' Представление таблицы отчета
    ''' </summary>
    Private ReportView As DataView = Nothing


    ''' <summary>
    ''' Объект Connection для выполнения запросов
    ''' </summary>
    ''' <remarks></remarks>
    Private Connection As SqlConnection = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных EXDB8</param>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        Me.Connection = Connection
        '
        ' ReportTable, ReportView
        '
        ReportTable = New DataTable("ReportTable")
        With ReportTable.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
            .Add("address", GetType(String))
            .Add("inn", GetType(String))
            .Add("orderDate", GetType(Date))
            .Add("isACT", GetType(Boolean))
        End With
        With ReportTable.Columns("isACT")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        ReportTable.PrimaryKey = New DataColumn() {ReportTable.Columns("id")}
        ReportView = New DataView(ReportTable)
        '
        ' ReportGridControl, ReportGridView
        '
        ReportGridControl.DataSource = ReportView
        ReportGridView.SortInfo.Insert(0, NameGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

        ClientReportBarCheckItem.Checked = True

    End Sub


    ' Перечитать данные из базы
    Private Sub DataReload()
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ReportGridView.BeginDataUpdate()
        ReportTable.Rows.Clear()
        Using Cmd As SqlCommand = Connection.CreateCommand
            If ClientReportBarCheckItem.Checked Then
                ' Заказчики
                Cmd.CommandText = "SELECT id, clientName AS name, clientAddress AS address, clientInn AS inn, orderDate FROM tWork WHERE clientName > 'Y'"
            ElseIf MemberReportBarCheckItem.Checked Then
                ' Участники ВЭД
                Cmd.CommandText = "SELECT DISTINCT memberId AS id, memberName AS name, memberAddress AS address, memberInn AS inn, orderDate FROM vWorkMember WHERE memberKindId IN (2, 6)"
            Else
                ' Участники - не Заказчики
                Cmd.CommandText = "SELECT DISTINCT memberId AS id, memberName AS name, memberAddress AS address, memberInn AS inn, orderDate FROM vWorkMember WHERE memberInn <> workClientInn AND memberKindId IN (2, 6)"
            End If
            ReportTable.Load(Cmd.ExecuteReader)
        End Using
        If ReportTable.Rows.Count > 0 Then
            ReportView.RowFilter = Nothing
            ReportView.Sort = "inn, orderDate DESC"
            ReportView(0)("isACT") = True
            For i As Integer = 1 To ReportView.Count - 1
                ReportView(i)("isACT") = (ToText(ReportView(i)("inn")) <> ToText(ReportView(i - 1)("inn")))
            Next
        End If
        ReportView.RowFilter = "isACT = True"
        ReportView.Sort = "name"
        ReportGridView.EndDataUpdate()
        ReportGridView.MoveFirst()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    Private Sub FindRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindRepositoryItemButtonEdit.ButtonClick
        FindRepositoryItemButtonEdit.BeginUpdate()
        FindBarEditItem.EditValue = Nothing
        FindRepositoryItemButtonEdit.EndUpdate()
        ReportGridView.FindFilterText = Nothing
    End Sub

    Private Sub FindRepositoryItemButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemButtonEdit.EditValueChanging
        If e.NewValue Is Nothing Then
            ReportGridView.FindFilterText = Nothing
        Else
            ReportGridView.FindFilterText = e.NewValue.ToString
        End If
    End Sub

    Private Sub ClientReportBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ClientReportBarCheckItem.CheckedChanged
        ReportBarSubItem.Caption = "Заказчики услуг"
        DataReload()
    End Sub

    Private Sub MemberReportBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles MemberReportBarCheckItem.CheckedChanged
        ReportBarSubItem.Caption = "Участники ВЭД"
        DataReload()
    End Sub

    Private Sub MemberNotClientReportBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles MemberNotClientReportBarCheckItem.CheckedChanged
        ReportBarSubItem.Caption = "Участники - не Заказчики"
        DataReload()
    End Sub

    Private Sub ReferenceBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReferenceBarButtonItem.ItemClick
        If ReportGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim inn As String = ReportGridView.GetFocusedDataRow("inn").ToString
        If String.IsNullOrWhiteSpace(inn) Then Exit Sub
        For Each F As Form In Application.OpenForms
            If Not TypeOf F Is RusProfileForm Then Continue For
            If CType(F, RusProfileForm).Inn <> inn Then Continue For
            F.WindowState = FormWindowState.Normal
            F.TopMost = True
            F.TopMost = False
            Exit Sub
        Next
        With New RusProfileForm(inn, Connection)
            .Show(Me.ParentForm)
        End With
    End Sub

    Private Sub ExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = If(ClientReportBarCheckItem.Checked, "Заказчики услуг", "Участники ВЭД")
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

    Private Sub ReportGridControl_DoubleClick(sender As Object, e As EventArgs) Handles ReportGridControl.DoubleClick
        ReferenceBarButtonItem.PerformClick()
    End Sub

End Class
