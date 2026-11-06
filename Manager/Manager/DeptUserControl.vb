Imports C2 = Cprp.DxData.Common
''' <summary>
''' Согласования
''' </summary>
Friend Class DeptUserControl

    ' Список работ
    Private ListTable As DataTable = Nothing

    Private WithEvents TMR As Timer = Nothing

    Friend Sub New()
        InitializeComponent()
        '
        ' ListTable
        '
        ListTable = New DataTable
        With ListTable.Columns
            .Add("id", GetType(Integer))                ' ID работы
            .Add("orderNum", GetType(String))           ' Номер заказа
            .Add("priceCalc", GetType(Single))          ' Расчетная стоимость
            .Add("priceEnd", GetType(Single))           ' Окончательная стоимость
            .Add("priceEndNds", GetType(Single))        ' Окончательная стоимость с НДС
            .Add("priceDept", GetType(Single))          ' Стоимость представительства
            .Add("isAdd", GetType(Boolean))             ' Дополнительный счет
            .Add("isAgreement", GetType(Boolean))       ' Доп. соглашение
            .Add("isUrgency", GetType(Boolean))         ' Срочности
            .Add("typeName", GetType(String))           ' Вид расчета
            .Add("typeId", GetType(Integer))            ' ID вида расчета
            .Add("goodCount", GetType(Integer))         ' Количество товаров
            .Add("countryCount", GetType(Integer))      ' Количество стран
            .Add("translitCount", GetType(Integer))     ' Документов на ин. языке
            .Add("inspectionCount", GetType(Single))    ' Осмотр товара (часов)     
            .Add("isFind", GetType(Boolean))            ' Поиск доп. информации
            .Add("deptName", GetType(String))           ' Представительство
            .Add("deptId", GetType(Integer))            ' ID представительства
            .Add("userName", GetType(String))           ' Автор расчета
            .Add("userId", GetType(Integer))            ' ID автора расчета
            .Add("comment", GetType(String))            ' Примечание
            .Add("isActExist", GetType(Boolean))        ' Акт выписан
        End With
        ListTable.PrimaryKey = New DataColumn() {ListTable.Columns("id")}
        '
        ' ListGridControl, ListGridView 
        '
        ListGridControl.DataSource = ListTable
        ListGridView.SortInfo.Insert(0, IdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        Dim sTmp As String = String.Format("{0}\layoutdept.xml", Application.StartupPath)
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
        ' Мои согласования
        '
        ListMyBarCheckItem.PerformClick()
    End Sub

    ''' <summary>
    ''' Перечитать список согласований
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Public Sub DataReload()
        '
        ' Хандлер текущей выделенной в плане строки
        '
        Dim iHandler As Integer = ListGridView.FocusedRowHandle

        Dim sTmp As String = Nothing
        '
        ' Данные из базы
        '
        ListTable.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = _
                "SELECT * FROM v2Calc WHERE isActExist = 0 AND deptId IN (SELECT id FROM t2Department WHERE isCons = 1)"
            If ListMyBarCheckItem.Checked Then
                Cmd.CommandText = String.Format("{0} AND userId = {1}", Cmd.CommandText, Program.DbClient.Id)
            End If
            ListTable.Load(Cmd.ExecuteReader)
        End Using
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
            ListGridView.SaveLayoutToXml(String.Format("{0}\layoutdept.xml", Application.StartupPath))
        Catch ex As Exception
            Exit Try
        End Try
    End Sub

    ' Перечитать список согласований
    Private Sub TMR_Tick(sender As Object, e As EventArgs) Handles TMR.Tick
        DataReload()
    End Sub

    ' Мои согласования
    Private Sub ListMyBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListMyBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    ' Все согласования
    Private Sub ListAllBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListAllBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    ' Перечитать список согласований
    Private Sub ListReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListReloadBarButtonItem.ItemClick
        DataReload()
    End Sub

    ' Сохранить данные
    Private Sub DataSaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveBarButtonItem.ItemClick
        Try
            ListGridView.CloseEditor()
            ListGridView.UpdateCurrentRow()
            ListGridView.BeginDataUpdate()
            For Each Row As DataRow In ListTable.Rows
                If IsDBNull(Row("priceDept")) Then Row("isActExist") = False
            Next
            ListGridView.EndDataUpdate()
            Using A As New SqlDataAdapter("SELECT * FROM t2Calc WHERE id IS NULL", Program.DbClient.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(ListTable)
            End Using
            DataReload()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.", "Согласования")
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
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

End Class
