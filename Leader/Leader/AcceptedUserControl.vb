Imports C2 = Cprp.DxData.Common
''' <summary>
''' Утвержденные работы
''' </summary>
Friend Class AcceptedUserControl

    ' Список работ (заключений)
    Private ListTable As DataTable = Nothing

    Private WithEvents TMR As Timer = Nothing

    Private Connection As SqlConnection = Nothing

    Friend Sub New()
        InitializeComponent()
        '
        ' ListTable 
        '
        ListTable = New DataTable
        With ListTable.Columns
            .Add("workId", GetType(Integer))
            .Add("typeId", GetType(Integer))
            .Add("typeName", GetType(String))
            .Add("closeDate", GetType(Date))
            .Add("regNum", GetType(String))
            .Add("regDate", GetType(Date))
            .Add("orderNum", GetType(String))
            .Add("orderDate", GetType(Date))
            .Add("orderUrl", GetType(String))
            .Add("clientName", GetType(String))
            .Add("description", GetType(String))
            .Add("expertName", GetType(String))
            .Add("managerName", GetType(String))
            .Add("leaderName", GetType(String))
            .Add("conditionId", GetType(Integer))
        End With
        '
        ' ListGridControl, ListGridView 
        '
        ListGridControl.DataSource = ListTable
        ListGridView.SortInfo.Insert(0, RegDateGridColumn, DevExpress.Data.ColumnSortOrder.Descending)
        Dim sTmp As String = String.Format("{0}\acceptworklayout.xml", My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments))
        If My.Computer.FileSystem.FileExists(sTmp) Then ListGridView.RestoreLayoutFromXml(sTmp)
        ListGridView.FindFilterText = Nothing
        '
        ' Начало периода
        '
        StartDateBarEditItem.EditValue = Date.Now.AddMonths(-1)
        '
        ' Отображать внесение изменений
        '
        AlterationBarCheckItem.Checked = True
        '
        ' Data
        '
        DataReload()
        '
        ' TMR
        '
        TMR = Program.Timer
    End Sub

    ''' <summary>
    ''' Перечитать список работ
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Friend Sub DataReload()
        If StartDateBarEditItem.EditValue Is Nothing Then Exit Sub
        Try
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
                    "SELECT * FROM vWorkDoc2 WHERE acceptDate >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND conditionId <> {1}", _
                    CDate(StartDateBarEditItem.EditValue), CInt(Cprp.DxData.Work.WorkCondition.IsSignature))
                If Not OrderBarCheckItem.Checked Then Cmd.CommandText &= " AND typeId <> 99"
                If Not AlterationBarCheckItem.Checked Then Cmd.CommandText &= " AND typeId <> 117"
                ListTable.Load(Cmd.ExecuteReader)
            End Using
            '
            ' Переход к последней выделенной строке
            '
            Dim iTmp As Integer = 0
            If ListTable.Rows.Count > 0 Then
                ListGridView.MoveFirst()
                iTmp = 0
                While ListGridView.IsValidRowHandle(iTmp)
                    If iTmp = iHandler Then
                        ListGridView.FocusedRowHandle = iTmp
                        Exit While
                    End If
                    iTmp += 1
                End While
            End If
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Перечитывание списка утвержденных работ", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
    End Sub

    ''' <summary>
    ''' Сохранение настроек списка работ
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub LayoutSave()
        Try
            ListGridView.SaveLayoutToXml(String.Format("{0}\acceptworklayout.xml", My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments)))
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                Program.AppErrorTable.WriteError("Сохранение настроек списка утвержденных работ в файл", mes)
            End If
        End Try
    End Sub

    Private Sub TMR_Tick(sender As Object, e As EventArgs) Handles TMR.Tick
        DataReload()
    End Sub

    ' Перечитать список работ
    Private Sub ListReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListReloadBarButtonItem.ItemClick
        DataReload()
    End Sub

    ' Вернуть работу на доработку
    Private Sub WorkBackBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkBackBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim workId As Integer = C2.ToInt(ListGridView.GetFocusedDataRow("workId"))
        Dim conditionId As Integer = C2.ToInt(ListGridView.GetFocusedDataRow("conditionId"))
        If conditionId < 7 Then
            Using Cmd As SqlCommand = Program.DbClient.Connection.CreateCommand
                Cmd.CommandText = String.Format("SELECT conditionId FROM tWork WHERE id = {0}", workId)
                conditionId = CInt(Cmd.ExecuteScalar)
            End Using
        End If
        '
        ' Проверка возврата выданных работы
        '
        If CInt(ListGridView.GetFocusedDataRow("conditionId")) = 7 Then
            If Cprp.DxCommon.Messages.ShowQuestion( _
                "Вы точно хотите вернуть на доработку выданную работу?") <> DialogResult.Yes Then Exit Sub
        End If
        '
        ' Срок исполнения и комментарий к возврату работы
        '
        Dim expertTerm As Date = Cprp.DxData.Work.Common.GetPlaneDate(Date.Now, 2 * 60)
        Dim comment As String = Nothing
        Using F As New WorkBackForm()
            F.Text = String.Format("Работа № {0} - Возврат на доработку", workId)
            F.TermDateEdit.EditValue = expertTerm
            If F.ShowDialog <> DialogResult.OK Then Exit Sub
            expertTerm = CDate(F.TermDateEdit.EditValue)
            comment = C2.ToText(F.CommentMemoEdit.Text)
            If C2.IsText(comment) Then comment = "; " & comment
            If F.ClientCheckEdit.Checked Then comment = "; " & F.ClientCheckEdit.Text & comment
            If F.LiteralCheckEdit.Checked Then comment = "; " & F.LiteralCheckEdit.Text & comment
        End Using
        If C2.IsText(comment) Then comment = comment.Substring(2)
        Try
            '
            ' Рабочая база
            '
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                '
                ' Перевод работы в рабочей базе в состояние "В работе"
                '
                Cmd.CommandText = String.Format("UPDATE tWork SET conditionId = {0}, expertTerm = {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}, acceptDate = NULL, closeDate = NULL WHERE id = {2}", CInt(Cprp.DxData.Work.WorkCondition.IsWork), expertTerm, workId)
                Cmd.ExecuteNonQuery()
                '
                ' Удаление записей из таблицы сообщений
                '
                Cmd.CommandText = String.Format("DELETE FROM tMessage WHERE workId = {0} AND isExecuted = 0", workId)
                Cmd.ExecuteNonQuery()
                '
                ' Удаление записей из таблицы документов
                '
                Cmd.CommandText = String.Format("DELETE FROM tTaskDocument WHERE workId = {0}", workId)
                Cmd.ExecuteNonQuery()
                '
                ' Запись в историю работы
                '
                Cprp.DxData.Work.Common.WriteHistory(workId, Cprp.DxData.Work.WorkEvent.BackAccept, Program.DbClient.Id, comment, Program.DbClient.Connection)
                '
                ' Отправка эксперту и менеджеру email-уведомления о возврате на доработку
                '
                Dim fromId As Integer = Program.DbClient.Id
                Dim fromName As String = Nothing
                Dim fromEmail As String = Nothing
                Cmd.CommandText = String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", fromId)
                Using Dr As SqlDataReader = Cmd.ExecuteReader()
                    If Dr.Read Then
                        fromName = C2.ToText(Dr("nameShort"))
                        fromEmail = C2.ToText(Dr("email"))
                    End If
                End Using
                If Not C2.IsText(fromEmail) Then fromEmail = "system@excont.ru"
                Dim toEmail As String = Nothing
                '
                ' Эксперт
                '
                Cmd.CommandText = String.Format("SELECT nameShort, email FROM tUser WHERE id = (SELECT expertId FROM tWork WHERE id = {0})", workId)
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    If Dr.Read Then
                        toEmail = C2.ToText(Dr("email"))
                    End If
                End Using
                If C2.IsText(toEmail) Then
                    Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", Program.DbClient.Connection)
                    Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", Program.DbClient.Connection)
                    Dim sCaption As String = String.Format("ВОЗВРАТ НА ДОРАБОТКУ (Работа № {0})", workId)
                    Dim sBody As String = String.Format("{0} вернул Вашу утвержденную работу № {1} на доработку с комментарием:{2}{3}", fromName, workId, vbCr, comment)
                    Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                        S.Send(fromEmail, toEmail, sCaption, sBody)
                    End Using
                End If
                '
                ' Менеджер
                '
                toEmail = Nothing
                Cmd.CommandText = String.Format("SELECT nameShort, email FROM tUser WHERE id = (SELECT managerId FROM tWork WHERE id = {0})", workId)
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    If Dr.Read Then
                        toEmail = C2.ToText(Dr("email"))
                    End If
                End Using
                If C2.IsText(toEmail) Then
                    Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", Program.DbClient.Connection)
                    Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", Program.DbClient.Connection)
                    Dim sCaption As String = String.Format("ВОЗВРАТ НА ДОРАБОТКУ (Работа № {0})", workId)
                    Dim sBody As String = String.Format("{0} вернул Вашу утвержденную работу № {1} на доработку эксперту с комментарием:{2}{3}", fromName, workId, vbCr, comment)
                    Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                        S.Send(fromEmail, toEmail, sCaption, sBody)
                    End Using
                End If

            End Using
            '
            ' Обновление данных
            '
            DataReload()

        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Возврат утвержденной работы в работу эксперту", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
    End Sub

    ' Открыть работу
    Private Sub WorkOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Program.MainForm.WorkOpen(ListGridView.GetFocusedDataRow("workId"))
    End Sub

    Private Sub ListGridControl_DoubleClick(sender As Object, e As EventArgs) Handles ListGridControl.DoubleClick
        WorkOpenBarButtonItem.PerformClick()
    End Sub

    ' Открыть историю работы
    Private Sub WorkHistoryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkHistoryBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        With New WorkHistoryForm(ListGridView.GetFocusedDataRow("workId"))
            .ShowDialog()
        End With
    End Sub

    Private Sub StartDateBarEditItem_EditValueChanged(sender As Object, e As EventArgs) Handles StartDateBarEditItem.EditValueChanged
        DataReload()
    End Sub

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        FindButtonEdit.Text = Nothing
    End Sub

    Private Sub FindButtonEdit_TextChanged(sender As Object, e As EventArgs) Handles FindButtonEdit.TextChanged
        ListGridView.FindFilterText = FindButtonEdit.Text
    End Sub

    Private Sub OrderBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OrderBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    Private Sub AlterationBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles AlterationBarCheckItem.CheckedChanged
        DataReload()
    End Sub

    ' Открыть карточку заказа к работе
    Private Sub OrderOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OrderOpenBarButtonItem.ItemClick
        If ListGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = ListGridView.GetFocusedDataRow("orderUrl").ToString
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Отсутствует ссылка на карточку заказа.", String.Format("Работа № {0}", ListGridView.GetFocusedDataRow("workId")))
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
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Открытие карточки заказа к работе", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
    End Sub
End Class
