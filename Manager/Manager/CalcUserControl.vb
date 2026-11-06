Imports C2 = Cprp.DxData.Common
''' <summary>
''' Расчеты
''' </summary>
Friend Class CalcUserControl

    ' Список расчетов
    Private ListTable As CalcDataTable = Nothing

    Private WithEvents TMR As Timer = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' ListTable
        '
        ListTable = New CalcDataTable
        '
        ' ListGridControl, ListGridView 
        '
        ListGridControl.DataSource = ListTable
        ListGridView.SortInfo.Insert(0, ActDateGridColumn, DevExpress.Data.ColumnSortOrder.Descending)
        Dim sTmp As String = String.Format("{0}\layoutcalc.xml", Application.StartupPath)
        If My.Computer.FileSystem.FileExists(sTmp) Then ListGridView.RestoreLayoutFromXml(sTmp)
        ListGridView.FindFilterText = Nothing
        '
        ' Data
        '
        DataReload()
        '
        ' TMR
        '
        TMR = Program.Timer
        '
        ' Мои работы
        '
        ListMyBarCheckItem.PerformClick()
        '
        ' Начало периода
        '
        StartDateBarEditItem.EditValue = Date.Today.AddMonths(-1)
    End Sub

    ''' <summary>
    ''' Перечитать список расчетов
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Public Sub DataReload()
        If StartDateBarEditItem.EditValue Is Nothing Then Exit Sub
        '
        ' Хандлер текущей выделенной в плане строки
        '
        Dim iHandler As Integer = ListGridView.FocusedRowHandle

        Dim sTmp As String = Nothing
        '
        ' Данные из базы
        '
        ListTable.Rows.Clear()
        ListTable.DataReload(CDate(StartDateBarEditItem.EditValue), ListAllBarCheckItem.Checked)
        '
        ' Переход к последней выделенной строке
        '
        ListGridView.MoveFirst()
        Dim iTmp As Integer = 0
        While ListGridView.IsValidRowHandle(iTmp)
            If iTmp = iHandler Then
                ListGridView.FocusedRowHandle = iTmp
                Exit While
            End If
            iTmp += 1
        End While
    End Sub

    ''' <summary>
    ''' Сохранить настройки списка в файл xml
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Public Sub LayoutSave()
        Try
            ListGridView.SaveLayoutToXml(String.Format("{0}\layoutcalc.xml", Application.StartupPath))
        Catch ex As Exception
            Exit Try
        End Try
    End Sub

    ' Перечитать список расчетов
    Private Sub TMR_Tick(sender As Object, e As EventArgs) Handles TMR.Tick
        DataReload()
    End Sub

    ' Мои расчеты
    Private Sub ListMyBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListMyBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    ' Все расчеты
    Private Sub ListAllBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListAllBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    ' Перечитать список расчетов
    Private Sub ListReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListReloadBarButtonItem.ItemClick
        DataReload()
    End Sub

    ' Создать расчет
    Private Sub CalcAddBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CalcAddBarButtonItem.ItemClick
        With New CalcForm(DBNull.Value)
            .Show(Me.ParentForm)
        End With
    End Sub

    ' Открыть расчет
    Private Sub CalcOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CalcOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim calcId As Integer = CInt(ListGridView.GetFocusedDataRow("id"))
        For Each F As Form In Application.OpenForms
            If Not TypeOf F Is CalcForm Then Continue For
            If CType(F, CalcForm).CalcId <> calcId Then Continue For
            F.WindowState = FormWindowState.Normal
            F.TopMost = True
            F.TopMost = False
            Exit Sub
        Next
        With New CalcForm(calcId)
            .Show(Me.ParentForm)
        End With
    End Sub

    ' Удалить расчет
    Private Sub CalcDelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CalcDelBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim calcId As Integer = CInt(ListGridView.GetFocusedDataRow("id"))
        If Cprp.DxCommon.Messages.ShowQuestion("Удалить расчет?", String.Format("Расчет № {0}", calcId)) <> DialogResult.Yes Then Exit Sub
        Try
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                Cmd.CommandText = String.Format("DELETE FROM tCalc WHERE id = {0}", calcId)
                Cmd.ExecuteNonQuery()
            End Using
            DataReload()
            For Each F As Form In Application.OpenForms
                If Not TypeOf F Is CalcForm Then Continue For
                If CType(F, CalcForm).CalcId <> calcId Then Continue For
                F.Dispose()
                Exit For
            Next
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Перечитать список расчетов при изменении даты начала списка
    Private Sub StartDateBarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles StartDateBarEditItem.EditValueChanged
        DataReload()
    End Sub

    ' Открыть карточку заказа
    Private Sub OrderOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OrderOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = ListGridView.GetFocusedDataRow("orderNum").ToString
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Отсутствует ссылка на карточку заказа.", String.Format("Работа № {0}", ListGridView.GetFocusedDataRow("id")))
            Exit Sub
        End If
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = String.Format("SELECT ISNULL(MAX(orderUrl), '') FROM tWork WHERE orderNum LIKE '{0}'", sTmp)
            sTmp = C2.ToText(Cmd.ExecuteScalar)
        End Using
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Отсутствует ссылка на карточку заказа.", String.Format("Работа № {0}", ListGridView.GetFocusedDataRow("id")))
            Exit Sub
        End If
        Try
            Using P As New Process
                P.StartInfo.FileName = sTmp
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        FindButtonEdit.Text = Nothing
    End Sub

    Private Sub FindButtonEdit_TextChanged(sender As Object, e As EventArgs) Handles FindButtonEdit.TextChanged
        ListGridView.FindFilterText = FindButtonEdit.Text
    End Sub

    Private Sub ListGridControl_DoubleClick(sender As Object, e As EventArgs) Handles ListGridControl.DoubleClick
        CalcOpenBarButtonItem.PerformClick()
    End Sub

End Class
