Imports C2 = Cprp.DxData.Common
''' <summary>
''' План работ
''' </summary>
Friend Class PlaneUserControl

    ' Список работ
    Private ListTable As DataTable = Nothing

    Private WithEvents TMR As Timer = Nothing

    ' Путь к папке с итоговыми документами
    Private FileFolderPath As String = Nothing

    ' Работа для внесения изменений в таблицу работ
    Private Work As Cprp.DxData.Work.Excont.WorkConnectionRow = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' ListTable
        '
        ListTable = New DataTable
        With ListTable.Columns
            .Add("id", GetType(Integer))                    ' ID работы
            .Add("sId", GetType(String))                    ' вид услуги
            .Add("conditionId", GetType(Integer))           ' ID состояния работы
            .Add("conditionName", GetType(String))          ' состояние работы
            .Add("expertId", GetType(Integer))              ' ID эксперта
            .Add("expertName", GetType(String))             ' эксперт
            .Add("expertTerm", GetType(Date))               ' срок эксперта
            .Add("managerId", GetType(Integer))             ' ID менеджера
            .Add("managerName", GetType(String))            ' менеджер
            .Add("leaderId", GetType(Integer))              ' ID руководителя
            .Add("leaderName", GetType(String))             ' руководитель
            .Add("clientName", GetType(String))             ' заказчик экспертизы
            .Add("orderNum", GetType(String))               ' номер заказа
            .Add("orderDate", GetType(Date))                ' дата заказа
            .Add("orderTerm", GetType(Date))                ' срок заказа
            .Add("orderUrl", GetType(String))               ' url заказа
            .Add("description", GetType(String))            ' объекты экспертизы
            .Add("percentComplete", GetType(Integer))       ' готовность
            .Add("isPayment", GetType(Boolean))             ' оплачена (да / нет)
            .Add("isPrice", GetType(Boolean))               ' счет подписан (+/-)
            .Add("comment", GetType(String))                ' комментарий к работе
            .Add("groupText", GetType(String))              ' текст для группировки работ
            .Add("isAsk", GetType(Boolean))                 ' есть запрос на утверждении
            .Add("isAskSign", GetType(Boolean))             ' есть запрос на подписании
            .Add("isAskSend", GetType(Boolean))             ' есть отправленный запрос
            .Add("isStop", GetType(Boolean))                ' Работа приостановлена
            .Add("isInt", GetType(Boolean))                 ' Есть внутренний документ на утверждении
            .Add("agreementNum", GetType(String))           ' Номер договора

            .Add("isOrderExpired", GetType(Boolean))        ' Заказ просрочен (+/-)
            .Add("isWorkExpired", GetType(Boolean))         ' Работа просрочена (+/-)
        End With
        ListTable.PrimaryKey = New DataColumn() {ListTable.Columns("id")}
        '
        ' Work
        '
        Work = New Cprp.DxData.Work.Excont.WorkConnectionRow(-1, Program.DbClient.Connection)
        '
        ' ListGridControl, ListGridView 
        '
        ListGridControl.DataSource = ListTable
        ListGridView.SortInfo.Insert(0, OrderTermGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        Dim sTmp As String = String.Format("{0}\layoutplane.xml", Application.StartupPath)
        If My.Computer.FileSystem.FileExists(sTmp) Then ListGridView.RestoreLayoutFromXml(sTmp)
        ListGridView.FindFilterText = Nothing
        GroupTextGridColumn.Group()
        '
        ' CommLabelControl
        '
        CommLabelControl.DataBindings.Add("Text", ListTable, "comment")
        '
        ' Data
        '
        DataReload()
        '
        ' TMR
        '
        TMR = Program.Timer
        '
        ' FileFolderPath
        '
        FileFolderPath = Cprp.DxData.Resource.Resource.GetStrData("EOFOLDERPATH", Program.DbClient.Connection)
        If Not My.Computer.FileSystem.DirectoryExists(FileFolderPath) Then WorkFilesBarButtonItem.Enabled = False
        '
        ' Мой план
        '
        ListMyBarCheckItem.PerformClick()
    End Sub

    ''' <summary>
    ''' Перечитать план работ
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Public Sub DataReload()
        '
        ' Хандлер текущей выделенной в плане строки
        '
        Dim iHandler As Integer = ListGridView.FocusedRowHandle
        '
        ' Данные из базы
        '
        ListTable.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = String.Format( _
                "SELECT * FROM vWorkData WHERE NOT conditionId IN ({0}, {1})", _
                CInt(Cprp.DxData.Work.WorkCondition.IsClose), _
                CInt(Cprp.DxData.Work.WorkCondition.IsCancel))
            If ListMyBarCheckItem.Checked Then
                Cmd.CommandText = String.Format("{0} AND (managerId = {1} OR managerId IS NULL)", Cmd.CommandText, Program.DbClient.Id)
            End If
            ListTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' Виды услуг + Группировка работ + Сводные данные
        '
        Dim iAgree As Integer = 0
        Dim iOrderExpired As Integer = 0
        Dim iWorkExpired As Integer = 0
        Dim sTmp As String = Nothing
        Dim condition As Cprp.DxData.Work.WorkCondition = Cprp.DxData.Work.WorkCondition.IsEmpty
        For Each Row As DataRow In ListTable.Rows
            '
            ' Состояние работы
            '
            condition = CType(Row("conditionId"), Cprp.DxData.Work.WorkCondition)
            '
            ' Вид услуги
            '
            Select Case CType(Row("typeId"), Cprp.DxData.Work.WorkType)
                Case Cprp.DxData.Work.WorkType.IsExCont : Row("sId") = "ДН"
                Case Cprp.DxData.Work.WorkType.IsCustomUnion : Row("sId") = "ЗиО"
                Case Cprp.DxData.Work.WorkType.IsTnved : Row("sId") = "Код"
                Case Cprp.DxData.Work.WorkType.IsLiconfirm : Row("sId") = "Контр."
                Case Cprp.DxData.Work.WorkType.IsConsultation : Row("sId") = "Кон."
                Case Cprp.DxData.Work.WorkType.IsMilitary : Row("sId") = "Граж."
                Case Cprp.DxData.Work.WorkType.IsOrder : Row("sId") = "Заявка"
                Case Cprp.DxData.Work.WorkType.IsAlteration : Row("sId") = "Измен."
                Case Cprp.DxData.Work.WorkType.IsLicense : Row("sId") = "Лиценз."
            End Select
            '
            ' Группировка работ
            '
            If condition = Cprp.DxData.Work.WorkCondition.IsAccept Then
                Row("groupText") = "1. Утвержденные"
            ElseIf condition = Cprp.DxData.Work.WorkCondition.IsReturned OrElse condition = Cprp.DxData.Work.WorkCondition.IsNew Then
                Row("groupText") = "2. Заявки"
            Else
                Row("groupText") = "3. В работе"
            End If
            '
            ' Заказ просрочен
            '
            If Not IsDBNull(Row("orderTerm")) AndAlso CDate(Row("orderTerm")) < Date.Now AndAlso Not CBool(Row("isAskSend")) AndAlso _
                (IsDBNull(Row("isStop")) OrElse Not CBool(Row("isStop"))) AndAlso _
                CType(Row("typeId"), Cprp.DxData.Work.WorkType) <> Cprp.DxData.Work.WorkType.IsLicense Then
                Row("isOrderExpired") = True
                iOrderExpired += 1
            End If
            '
            ' Работа просрочена
            '
            If Not IsDBNull(Row("expertTerm")) AndAlso CDate(Row("expertTerm")) < Date.Now AndAlso Not CBool(Row("isAskSend")) AndAlso _
                (IsDBNull(Row("isStop")) OrElse Not CBool(Row("isStop"))) AndAlso _
                CType(Row("typeId"), Cprp.DxData.Work.WorkType) <> Cprp.DxData.Work.WorkType.IsLicense Then
                If condition = Cprp.DxData.Work.WorkCondition.IsNew OrElse _
                    condition = Cprp.DxData.Work.WorkCondition.IsPlaneWork OrElse _
                    condition = Cprp.DxData.Work.WorkCondition.IsWork OrElse _
                    condition = Cprp.DxData.Work.WorkCondition.IsQuery Then
                    Row("isWorkExpired") = True
                    iWorkExpired += 1
                End If
            End If
            '
            ' Запрос
            '
            sTmp = Nothing
            If CBool(Row("isAsk")) Then
                sTmp = " (утверждение запроса)"
            ElseIf CBool(Row("isAskSign")) Then
                sTmp = " (подписание запроса)"
            ElseIf CBool(Row("isAskSend")) Then
                sTmp = " (остановлена)"
            ElseIf Not IsDBNull(Row("isStop")) AndAlso CBool(Row("isStop")) Then
                sTmp = " (остановлена)"
            End If
            '
            ' Лицензия
            '
            If String.IsNullOrWhiteSpace(sTmp) AndAlso CType(Row("typeId"), Cprp.DxData.Work.WorkType) = Cprp.DxData.Work.WorkType.IsLicense Then
                Select Case Cprp.DxData.Common.ToInt(Row("licConditionId"))
                    Case 1 : sTmp = " (подготовка документов)"
                    Case 2 : sTmp = " (подписание заказчиком)"
                    Case 3 : sTmp = " (направлено в госорган)"
                    Case 4 : sTmp = " (документ получен)"
                End Select
            End If

            If C2.IsText(sTmp) Then Row("conditionName") = C2.ToText(Row("conditionName")) & sTmp

        Next
        '
        ' Сводные данные
        '
        If ListTable.Rows.Count = 0 Then
            SummaryBarStaticItem.Caption = "Весь план: 0"
        Else
            SummaryBarStaticItem.Caption = _
                String.Format("Весь план: <b>{0}</b>. Просрочено заказов: <b>{1}</b>. Просрочено работ: <b>{2}</b>", _
                              ListTable.Rows.Count, iOrderExpired, iWorkExpired)
        End If
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
            ListGridView.SaveLayoutToXml(String.Format("{0}\layoutplane.xml", Application.StartupPath))
        Catch ex As Exception
            Exit Try
        End Try
    End Sub

    ' Перечитать план работ
    Private Sub TMR_Tick(sender As Object, e As EventArgs) Handles TMR.Tick
        DataReload()
    End Sub

    Private Sub ListGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs)
        e.Allow = False
    End Sub

    ' Мой план
    Private Sub ListMyBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListMyBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    ' Весь план
    Private Sub ListAllBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListAllBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    ' Перечитать план работ
    Private Sub ListReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListReloadBarButtonItem.ItemClick
        DataReload()
    End Sub

    ' Закрыть работу
    Private Sub WorkCloseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkCloseBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim iTmp As Integer = CInt(ListGridView.GetFocusedDataRow("conditionId"))
        If iTmp = CInt(Cprp.DxData.Work.WorkCondition.IsCancel) OrElse iTmp = CInt(Cprp.DxData.Work.WorkCondition.IsClose) Then Exit Sub
        iTmp = CInt(ListGridView.GetFocusedDataRow("id"))
        If Cprp.DxCommon.Messages.ShowQuestion("Работа будет закрыта. Продолжить?", String.Format("Работа № {0}", iTmp)) <> Windows.Forms.DialogResult.Yes Then Exit Sub
        Try
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                Cmd.CommandText = String.Format("UPDATE tWork SET conditionId = {0}, closeDate = {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} WHERE id = {2}", CInt(Cprp.DxData.Work.WorkCondition.IsClose), Date.Now, iTmp)
                Cmd.ExecuteNonQuery()
            End Using
            Cprp.DxData.Work.Common.WriteHistory(iTmp, Cprp.DxData.Work.WorkEvent.WorkClose, Program.DbClient.Id, Nothing, Program.DbClient.Connection)
            DataReload()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Перевести работу в состояние запрос / Вернуть в работу
    Private Sub WorkQueryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkQueryBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim iTmp As Integer = CInt(ListGridView.GetFocusedDataRow("conditionId"))
        Dim iTmp1 As Integer = CInt(ListGridView.GetFocusedDataRow("id"))
        Try
            Select Case CType(iTmp, Cprp.DxData.Work.WorkCondition)
                Case Cprp.DxData.Work.WorkCondition.IsCancel, Cprp.DxData.Work.WorkCondition.IsClose, Cprp.DxData.Work.WorkCondition.IsEmpty
                    Exit Sub
                Case Cprp.DxData.Work.WorkCondition.IsQuery
                    If Cprp.DxCommon.Messages.ShowQuestion("Перевести работу в состояние ""В работе""?", String.Format("Работа № {0}", iTmp1)) <> Windows.Forms.DialogResult.Yes Then Exit Sub
                    Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                        Cmd.CommandText = String.Format("UPDATE tWork SET conditionId = {0} WHERE id = {1}", CInt(Cprp.DxData.Work.WorkCondition.IsWork), iTmp1)
                        Cmd.ExecuteNonQuery()
                    End Using
                    Cprp.DxData.Work.Common.WriteHistory(iTmp1, Cprp.DxData.Work.WorkEvent.BackQuery, Program.DbClient.Id, Nothing, Program.DbClient.Connection)
                Case Else
                    If Cprp.DxCommon.Messages.ShowQuestion("Перевести работу в состояние ""Запрос""?", String.Format("Работа № {0}", iTmp1)) <> Windows.Forms.DialogResult.Yes Then Exit Sub
                    Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                        Cmd.CommandText = String.Format("UPDATE tWork SET conditionId = {0} WHERE id = {1}", CInt(Cprp.DxData.Work.WorkCondition.IsQuery), iTmp1)
                        Cmd.ExecuteNonQuery()
                    End Using
                    Cprp.DxData.Work.Common.WriteHistory(iTmp1, Cprp.DxData.Work.WorkEvent.QuerySend, Program.DbClient.Id, Nothing, Program.DbClient.Connection)
            End Select
            DataReload()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Открыть карточку заказа к работе
    Private Sub OrderOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OrderOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = ListGridView.GetFocusedDataRow("orderUrl").ToString
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

    ' Создать файлы Excel по работе
    Private Sub WorkExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkExcelBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim workId As Integer = C2.ToInt(ListGridView.GetFocusedDataRow("id"))
        '
        ' Проверка наличия файла с данными работы (для старых работ, утвержденных в предыдущей системе)
        '
        If Not My.Computer.FileSystem.FileExists(String.Format("{0}\{1}.work", Program.WorkFolderPath, C2.ToInt(workId))) Then
            Cprp.DxCommon.Messages.ShowWarning("Не найден файл с данными работы.", String.Format("Работа № {0}", workId))
            Exit Sub
        End If

        Dim folderPath As String = Nothing
        Dim filePath As String = Nothing
        '
        ' Выбор папки для сохранения файлов
        '
        Using Dlg As New FolderBrowserDialog
            Dlg.Description = "Укажите место для сохранения файлов"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            folderPath = String.Format("{0}\Работа № {1} (файлы Excel)", Dlg.SelectedPath, C2.ToText(ListGridView.GetFocusedDataRow("id")))
        End Using
        Cprp.DxCommon.WaitForm.Close()
        '
        ' Создание файлов Excel
        '
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Dim SP As New DevExpress.XtraSpreadsheet.SpreadsheetControl
        Using Ds As New DataSet("WorkData")
            Dim T As New DataTable("ARow")
            With T.Columns
                .Add("id", GetType(Integer))
                .Add("doc1RegNum", GetType(String))
                .Add("doc2RegNum", GetType(String))
            End With
            With T.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Ds.Tables.Add(T)
            T = New DataTable("GoodTable")
            With T.Columns
                .Add("id", GetType(Integer))
                .Add("rowNum", GetType(Integer))
                .Add("nameCon", GetType(String))
                .Add("tnved", GetType(String))
                .Add("description", GetType(String))
                .Add("isDoc1", GetType(Boolean))
            End With
            With T.Columns("id")
                .AllowDBNull = False
                .AutoIncrement = True
                .AutoIncrementSeed = 1
                .AutoIncrementStep = 1
            End With
            Ds.Tables.Add(T)
            Ds.ReadXml(String.Format("{0}\{1}.work", Program.WorkFolderPath, C2.ToInt(workId)), XmlReadMode.IgnoreSchema)
            '
            ' Проверка наличия заключений по работе
            '
            If Ds.Tables("ARow") Is Nothing OrElse Ds.Tables("ARow").Rows.Count = 0 Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowWarning("Работа не содержит данных для выгрузки.", String.Format("Работа № {0}", workId))
                Exit Sub
            End If
            If Ds.Tables("Arow").Columns.IndexOf("doc1RegNum") < 0 OrElse IsDBNull(Ds.Tables("Arow").Rows(0).Item("doc1RegNum")) Then
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowWarning("Работа не содержит данных для выгрузки.", String.Format("Работа № {0}", workId))
                Exit Sub
            End If
            '
            ' Заключение №1
            '
            If Ds.Tables("Arow").Columns.IndexOf("doc1RegNum") >= 0 AndAlso Not IsDBNull(Ds.Tables("Arow").Rows(0).Item("doc1RegNum")) Then
                SP.BeginUpdate()
                SP.LoadDocument(My.Resources.reportexcel, DevExpress.Spreadsheet.DocumentFormat.Xls)
                Using V As New DataView(Ds.Tables("GoodTable"))
                    V.RowFilter = "isDoc1 = True"
                    V.Sort = "rowNum"
                    For i As Integer = 0 To V.Count - 1
                        SP.Document.Worksheets(0).Cells(i + 4, 1).Value = V(i)("tnved").ToString
                        SP.Document.Worksheets(0).Cells(i + 4, 2).Value = V(i)("nameCon").ToString & " - " & V(i)("description").ToString
                        SP.Document.Worksheets(0).Cells(i + 4, 3).Value = (i + 1).ToString
                    Next
                End Using
                SP.Document.Worksheets(0).Name = C2.ToText(Ds.Tables("Arow").Rows(0).Item("doc1RegNum")).Replace("/", "_")
                SP.EndUpdate()
                filePath = My.Computer.FileSystem.GetTempFileName
                SP.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xls)
                My.Computer.FileSystem.MoveFile(filePath, String.Format("{0}\{1}.xls", folderPath, C2.ToText(Ds.Tables("Arow").Rows(0).Item("doc1RegNum")).Replace("/", "_")), True)
            End If
            '
            ' Заключение №2
            '
            If Ds.Tables("Arow").Columns.IndexOf("doc2RegNum") >= 0 AndAlso Not IsDBNull(Ds.Tables("Arow").Rows(0).Item("doc2RegNum")) Then
                SP.BeginUpdate()
                SP.LoadDocument(My.Resources.reportexcel, DevExpress.Spreadsheet.DocumentFormat.Xls)
                Using V As New DataView(Ds.Tables("GoodTable"))
                    V.RowFilter = "isDoc1 = False"
                    V.Sort = "rowNum"
                    For i As Integer = 0 To V.Count - 1
                        SP.Document.Worksheets(0).Cells(i + 4, 1).Value = V(i)("tnved").ToString
                        SP.Document.Worksheets(0).Cells(i + 4, 2).Value = V(i)("nameCon").ToString & " - " & V(i)("description").ToString
                        SP.Document.Worksheets(0).Cells(i + 4, 3).Value = (i + 1).ToString
                    Next
                End Using
                SP.Document.Worksheets(0).Name = C2.ToText(Ds.Tables("Arow").Rows(0).Item("doc2RegNum")).Replace("/", "_")
                SP.EndUpdate()
                filePath = My.Computer.FileSystem.GetTempFileName
                SP.SaveDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xls)
                My.Computer.FileSystem.MoveFile(filePath, String.Format("{0}\{1}.xls", folderPath, C2.ToText(Ds.Tables("Arow").Rows(0).Item("doc2RegNum")).Replace("/", "_")), True)
            End If
            SP.Dispose()
        End Using
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation(String.Format("Файлы Excel созданы в папке {0}", folderPath), String.Format("Работа № {0}", workId))
    End Sub

    ' Открыть историю работы
    Private Sub WorkHistoryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkHistoryBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        With New WorkHistoryForm(ListGridView.GetFocusedDataRow("id"))
            .ShowDialog()
        End With
    End Sub

    ' Создать новую работу
    Private Sub WorkNewBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkNewBarButtonItem.ItemClick
        With New WorkForm(DBNull.Value)
            If .ShowDialog = DialogResult.OK Then DataReload()
        End With
    End Sub

    ' Получить файлы по работе
    Private Sub WorkFilesBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkFilesBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim workId As Integer = CInt(ListGridView.GetFocusedDataRow("id"))
        Try
            Using T As New DataTable
                Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                    Cmd.CommandText = String.Format("SELECT * FROM tTaskDocument WHERE workId = {0}", workId)
                    T.Load(Cmd.ExecuteReader)
                End Using
                If T.Rows.Count = 0 Then
                    Cprp.DxCommon.Messages.ShowWarning("Файлов нет.")
                    Exit Sub
                End If
                With My.Computer.FileSystem
                    Dim folderPath As String = String.Format("{0}\{1}", .SpecialDirectories.Desktop, workId)
                    If Not .DirectoryExists(folderPath) Then .CreateDirectory(folderPath)
                    Dim fileName As String = Nothing
                    For Each Row As DataRow In T.Rows
                        fileName = C2.ToText(Row("docUrl"))
                        If String.IsNullOrWhiteSpace(fileName) OrElse Not .FileExists(fileName) Then Continue For
                        .CopyFile(Row("docUrl").ToString, String.Format("{0}\{1}", folderPath, .GetName(fileName)), True)
                    Next
                End With
            End Using
            Cprp.DxCommon.Messages.ShowInformation(String.Format("Файлы скопированы в папку ""{0}"" на рабочем столе.", workId))
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Создать файл консультации по определению кода ТН ВЭД
    Private Sub WorkConsBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkConsBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Program.CreateConsTnved(CInt(ListGridView.GetFocusedDataRow("id")))
    End Sub

    ' Пересчитать стоимость работы по договору 05/1134 (АСЭ)
    Private Sub CalcAseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CalcAseBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Program.CalcAse(ListGridView.GetFocusedDataRow)
    End Sub

    ' Пересчитать стоимость работы по договору 01/22/128 (ГСПИ)
    Private Sub CalcGspiBarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CalcGspiBarButtonItem1.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Program.CalcGspi(ListGridView.GetFocusedDataRow)
    End Sub

    ' Отправить работу на рассмотрение / Выдать работу заказчику услуги
    Private Sub WorkSendBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkSendBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim Row As DataRow = ListGridView.GetFocusedDataRow
        Dim workId As Integer = C2.ToInt(Row("id"))
        Dim iTmp As Integer = C2.EMPTY_ID
        Dim condition As Cprp.DxData.Work.WorkCondition = Cprp.DxData.Work.WorkCondition.IsEmpty
        '
        ' Состояние работы
        '
        Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = String.Format("SELECT conditionId FROM tWork WHERE id = {0}", workId)
            condition = CType(Cmd.ExecuteScalar, Cprp.DxData.Work.WorkCondition)
        End Using
        If condition <> Cprp.DxData.Work.WorkCondition.IsReturned AndAlso condition <> Cprp.DxData.Work.WorkCondition.IsAccept Then
            Cprp.DxCommon.Messages.ShowError("Работа не готова.", String.Format("Работа № {0}", workId))
            Exit Sub
        End If

        If condition = Cprp.DxData.Work.WorkCondition.IsReturned Then
            '
            ' Отправка заявки на рассмотрение
            '
            If Cprp.DxCommon.Messages.ShowQuestion("Отправить заявку на рассмотрение в отдел экспертизы?", String.Format("Работа № {0}", workId)) <> DialogResult.Yes Then Exit Sub
            Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
            Try
                Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
                    Cmd.CommandText = String.Format("UPDATE tWork SET conditionId = {0}, expertTerm = {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} WHERE id = {2}", _
                                                     CInt(Cprp.DxData.Work.WorkCondition.IsNew), Cprp.DxData.Work.Common.GetPlaneDate(Date.Now, 60, True), workId)
                    Cmd.ExecuteNonQuery()
                End Using
                Cprp.DxData.Work.Common.WriteHistory(workId, Cprp.DxData.Work.WorkEvent.WorkStart, Program.DbClient.Id, Nothing, Program.DbClient.Connection)
                Work.Id = workId
                Work.MessageWorkChangeEo()
                Cprp.DxCommon.WaitForm.Close()
            Catch ex As Exception
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
                Exit Sub
            End Try
            Cprp.DxCommon.Messages.ShowInformation("Заявка отправлена на рассмотрение в отдел экспертизы.", String.Format("Работа № {0}", workId))

        ElseIf condition = Cprp.DxData.Work.WorkCondition.IsAccept Then
            '
            ' Выдача работы заказчику
            '           
            ' Проверка наличия итоговых документов по работе
            '
            Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tWorkDoc WHERE workId = {0}", workId)
                iTmp = CInt(Cmd.ExecuteScalar)
            End Using
            If iTmp = 0 Then
                Cprp.DxCommon.Messages.ShowError("Итоговые документы по работе отсутствуют.", String.Format("Работа № {0}", workId))
                Exit Sub
            End If

            If Cprp.DxCommon.Messages.ShowQuestion("Выдать итоговые документы и закрыть работу?", String.Format("Работа № {0}", workId)) <> DialogResult.Yes Then Exit Sub
            '
            ' Выдача итоговых документов и закрытие работы
            '
            Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
            Try
                Using Cmd As SqlClient.SqlCommand = Program.DbClient.Connection.CreateCommand
                    Cmd.CommandText = String.Format("UPDATE tMessage SET sendDate = {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} WHERE workId = {1} AND isExecuted = 0", Date.Now, workId)
                    Cmd.ExecuteNonQuery()
                    Cmd.CommandText = String.Format("UPDATE tWork SET conditionId = {0}, closeDate = {{ts '{1:yyyy-MM-dd HH:mm:ss}'}} WHERE id = {2}", _
                                                     CInt(Cprp.DxData.Work.WorkCondition.IsClose), Date.Now, workId)
                    Cmd.ExecuteNonQuery()
                End Using
                Cprp.DxData.Work.Common.WriteHistory(workId, Cprp.DxData.Work.WorkEvent.WorkClose, Program.DbClient.Id, Nothing, Program.DbClient.Connection)
                Work.Id = workId
                Work.MessageWorkChangeEo()
                Cprp.DxCommon.WaitForm.Close()
            Catch ex As Exception
                Cprp.DxCommon.WaitForm.Close()
                Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
                Exit Sub
            End Try
            Cprp.DxCommon.Messages.ShowInformation("Итоговые документы отправлены заказчику услуги. Работа закрыта.", String.Format("Работа № {0}", workId))
        End If

        DataReload()
    End Sub

    Private Sub WorkCommentBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkCommentBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim Row As DataRow = ListGridView.GetFocusedDataRow
        With New WorkCommentForm(Row("id"))
            .ShowDialog()
            If Not String.IsNullOrWhiteSpace(.newComment) Then Row("comment") = .newComment
        End With
    End Sub
End Class
