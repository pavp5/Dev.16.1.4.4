Imports C2 = Cprp.DxData.Common
''' <summary>
''' Отчет по внесениям изменений
''' </summary>
Public Class ReportUserControl

    Private Class ReportDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New("ReportTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("altId", GetType(Integer))             ' id заявки на внесение изменений
                .Add("parentId", GetType(Integer))          ' id первичной работы
                .Add("parentDocNum", GetType(String))       ' номер первичного заключения
                .Add("parentDocDate", GetType(Date))        ' дата первичного заключения
                .Add("newId", GetType(Integer))             ' id новой работы
                .Add("newDocNum", GetType(String))          ' номер нового заключения
                .Add("newDocDate", GetType(Date))           ' дата нового заключения
                .Add("expertName", GetType(String))         ' эксперт
                .Add("clientName", GetType(String))         ' заказчик
                .Add("orderNum", GetType(String))           ' номер заявки (заказа) на внесение изменений
                .Add("orderDate", GetType(Date))            ' дата заявки (заказа) на внесение изменений
                .Add("changeSourceName", GetType(String))   ' источник ошибки
                .Add("expertComment", GetType(String))      ' пояснения эксперта
                .Add("leaderComment", GetType(String))      ' решение руководителя
            End With
            With Me.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub
    End Class


    Private ReportTable As ReportDataTable = Nothing
    Private ReportView As DataView = Nothing

    Private PercentTable As DataTable = Nothing

    Private Const APP_NAME As String = "Внесения изменений"


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
        ' Data
        '
        ReportTable = New ReportDataTable()
        ReportView = New DataView(ReportTable) With {.RowFilter = " changeSourceName > ''"}
        PercentTable = New DataTable
        With PercentTable.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
            .Add("workCount", GetType(Integer))
        End With
        PercentTable.PrimaryKey = New DataColumn() {PercentTable.Columns("id")}
        '
        ' DateBeginBarEditItem, DateEndBarEditItem
        '
        DateBeginBarEditItem.EditValue = Date.Today.AddDays(-1 * Date.Today.Day + 1)
        DateEndBarEditItem.EditValue = Date.Today
        '
        ' ReportGridControl, ReportGridView 
        '
        ReportGridControl.DataSource = ReportView
        '
        ' PercentChartControl
        '
        PercentChartControl.DataSource = PercentTable

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
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ReportGridView.BeginDataUpdate()
        PercentChartControl.BeginInit()
        Try
            ReportTable.Rows.Clear()
            PercentTable.Rows.Clear()
            Using Cmd As SqlCommand = Connection.CreateCommand
                Cmd.CommandText = String.Format( _
                "SELECT id AS altId, parentId, expertName, clientName, orderNum, orderDate  FROM vWorkData " & _
                "WHERE typeId = {0} AND conditionId = {1} AND orderDate >= {{ts '{2:yyyy-MM-dd HH:mm:ss}'}} AND orderDate < {{ts '{3:yyyy-MM-dd HH:mm:ss}'}}", _
                CInt(Cprp.DxData.Work.WorkType.IsAlteration), CInt(Cprp.DxData.Work.WorkCondition.IsClose), _
                CDate(DateBeginBarEditItem.EditValue), CDate(DateEndBarEditItem.EditValue).AddDays(1))
                ReportTable.Load(Cmd.ExecuteReader)
            End Using
            If ReportTable.Rows.Count = 0 Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowInformation("За указанный период данные по внесению изменений отсутствуют.", APP_NAME)
            Else
                Dim Row As DataRow = Nothing
                Using Cmd As SqlCommand = Connection.CreateCommand
                    '
                    ' parentDocNum, parentDocDate
                    '
                    Using V As New DataView(ReportTable) With {.RowFilter = "parentDocNum IS NULL"}
                        While V.Count > 0
                            Row = V(0).Row
                            Cmd.CommandText = String.Format("SELECT regNum, regDate FROM tWorkDoc WHERE workId = {0}", C2.ToInt(Row("parentId")))
                            Using Dr As SqlDataReader = Cmd.ExecuteReader
                                While Dr.Read
                                    If IsDBNull(Row("parentDocNum")) Then
                                        Row("parentDocNum") = Dr("regNum")
                                        Row("parentDocDate") = Dr("regDate")
                                    Else
                                        Row = ReportTable.NewRow
                                        Row("parentDocNum") = Dr("regNum")
                                        Row("parentDocDate") = Dr("regDate")
                                        For Each Col As DataColumn In ReportTable.Columns
                                            If Col.AutoIncrement Then Continue For
                                            If V.Count > 0 Then Row(Col.ColumnName) = V(0)(Col.ColumnName)
                                        Next
                                        ReportTable.Rows.Add(Row)
                                    End If
                                End While
                            End Using
                            If IsDBNull(Row("parentDocNum")) Then Row("parentDocNum") = ""
                        End While
                    End Using
                    '
                    ' newId
                    '
                    For Each Row In ReportTable.Rows
                        If IsNumeric(Row("altId")) Then
                            Cmd.CommandText = String.Format("SELECT ISNULL(id, -1) FROM tWork WHERE pId = {0}", Row("altId"))
                            Row("newId") = CInt(Cmd.ExecuteScalar)
                        Else
                            Row("newId") = C2.EMPTY_ID
                        End If
                    Next
                    '
                    ' newDocNum, newDocDate
                    '
                    For Each Row In ReportTable.Rows
                        If CInt(Row("newId")) < 1 Then
                            Row("newId") = DBNull.Value
                            Continue For
                        End If
                        Cmd.CommandText = String.Format("SELECT regNum, regDate FROM tWorkDoc WHERE workId = {0}", C2.ToInt(Row("newId")))
                        Using Dr As SqlDataReader = Cmd.ExecuteReader
                            If Dr.Read Then
                                Row("newDocNum") = Dr("regNum")
                                Row("newDocDate") = Dr("regDate")
                            End If
                        End Using
                    Next
                End Using
                '
                ' данные заявки на внесение изменений
                '
                Using W As New Cprp.DxData.Work.Alteration.WorkConnectionRow(0, Connection)
                    Dim iTmp As Integer = 0
                    For i As Integer = 0 To ReportTable.Rows.Count - 1
                        W.Id = ReportTable(i)("altId")
                        iTmp = C2.ToInt(W.ARow("changeSourceId"))
                        Select Case iTmp
                            Case 1, 3
                                ReportTable(i)("changeSourceName") = "Заказчик"
                            Case 2
                                ReportTable(i)("changeSourceName") = "Эксперт"
                        End Select
                        ReportTable(i)("expertComment") = C2.DbText(W.ARow("expertComment"))
                        ReportTable(i)("leaderComment") = C2.DbText(W.ARow("leaderComment"))
                    Next
                End Using
                '
                ' Сводные данные
                '
                Dim workCount As Integer = 0
                Dim altClientCount As Integer = 0
                Dim altExpertCount As Integer = 0
                Using Cmd As SqlCommand = Connection.CreateCommand
                    Cmd.CommandText = String.Format( _
                    "SELECT COUNT(*)  FROM tWork " & _
                    "WHERE typeId IN (1, 2, 3) AND conditionId = {0} AND closeDate >= {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} AND closeDate < {{ts '{2:yyyy-MM-dd HH:mm:ss}'}}", _
                    CInt(Cprp.DxData.Work.WorkCondition.IsClose), _
                    CDate(DateBeginBarEditItem.EditValue), CDate(DateEndBarEditItem.EditValue).AddDays(1))
                    workCount = CInt(Cmd.ExecuteScalar)
                End Using
                For Each Row In ReportTable.Rows
                    If C2.ToText(Row("changeSourceName")) = "Эксперт" Then
                        altExpertCount += 1
                    Else
                        altClientCount += 1
                    End If
                Next
                WorkCountStaticItem.Caption = String.Format("Выдано заключений: <b>{0}</b> (100 %)", workCount)
                AlterCountBarStaticItem.Caption = String.Format("Внесено изменений: <b>{0}</b> ({1:n2} %)", _
                                                                altExpertCount + altClientCount, _
                                                                100 * (altExpertCount + altClientCount) / workCount)
                AlterExpertCountBarStaticItem.Caption = String.Format("По вине эксперта: <b>{0}</b> ({1:n2} %)", _
                                                                      altExpertCount, 100 * altExpertCount / workCount)
                AlterClientCountBarStaticItem.Caption = String.Format("По вине заказчика: <b>{0}</b> ({1:n2} %)", _
                                                                      altClientCount, 100 * altClientCount / workCount)
                With PercentTable.Rows
                    .Add(New Object() {1, "Без изменений", workCount - altClientCount - altExpertCount})
                    .Add(New Object() {2, "Ошибка эксперта", altExpertCount})
                    .Add(New Object() {3, "Инициатива заказчика", altClientCount})
                End With
                Cprp.DxCommon.WaitForm.Close()
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        Finally
            ReportGridView.EndDataUpdate()
            ReportGridView.ExpandAllGroups()
            ReportGridView.MoveFirst()
            PercentChartControl.EndInit()
        End Try
    End Sub

    Private Sub ExportExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportExcelBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.FileName = "Отчет по внесениям изменений"
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
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), APP_NAME)
        End Try
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

End Class
