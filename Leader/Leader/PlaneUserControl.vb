Imports C2 = Cprp.DxData.Common
''' <summary>
''' План работ
''' </summary>
Friend Class PlaneUserControl

    ' План работ
    Private PlaneTable As DataTable = Nothing

    Private WithEvents TMR As Timer = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' PlaneTable
        '
        PlaneTable = New DataTable
        With PlaneTable.Columns
            .Add("id", GetType(Integer))                ' ID работы
            .Add("sId", GetType(String))                ' Вид услуги
            .Add("orderTerm", GetType(Date))            ' Срок выдачи заказа
            .Add("expertTerm", GetType(Date))           ' Срок эксперта
            .Add("managerName", GetType(String))        ' Менеджер
            .Add("expertName", GetType(String))         ' Эксперт
            .Add("leaderName", GetType(String))         ' Руководитель
            .Add("orderId", GetType(Integer))           ' ID заказа
            .Add("orderNum", GetType(String))           ' Номер заказа
            .Add("orderDate", GetType(Date))            ' Дата заказа
            .Add("clientName", GetType(String))         ' Заказчик
            .Add("countryName", GetType(String))        ' Страна назначения
            .Add("description", GetType(String))        ' Обобщенное наименование объектов экспертизы
            .Add("conditionId", GetType(Integer))       ' ID состояния работы
            .Add("conditionName", GetType(String))      ' Состояние работы
            .Add("isPayment", GetType(Boolean))         ' Работа оплачена (+/-)
            .Add("isPrice", GetType(Boolean))           ' Счет подписан (+/-)
            .Add("percentCount", GetType(Integer))      ' Процент завершения работы
            .Add("totalWork", GetType(Integer))         ' Трудоемкость (мин)
            .Add("goodCount", GetType(Integer))         ' Количество товаров
            .Add("isAsk", GetType(Boolean))             ' Есть запрос на утверждении
            .Add("isAskSign", GetType(Boolean))         ' Есть запрос на подписании
            .Add("isAskSend", GetType(Boolean))         ' Есть отправленный запрос
            .Add("isStop", GetType(Boolean))            ' Работа приостановлена
            .Add("isInt", GetType(Boolean))             ' Есть внутренний документ на утверждении
            .Add("agreementNum", GetType(String))       ' Номер договора

            .Add("isAgree", GetType(Boolean))           ' Работа (план работы) на проверке или утверждении (+/-)
            .Add("isOrderExpired", GetType(Boolean))    ' Заказ просрочен (+/-)
            .Add("isWorkExpired", GetType(Boolean))     ' Работа просрочена (+/-)
            .Add("groupText", GetType(String))          ' Текст для группировки работ           
        End With
        '
        ' PlaneGridControl, PlaneGridView 
        '
        PlaneGridControl.DataSource = PlaneTable
        PlaneGridView.SortInfo.Insert(0, ExpertTermGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        Dim sTmp As String = String.Format("{0}\planelayout.xml", My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments))
        Try
            If My.Computer.FileSystem.FileExists(sTmp) Then PlaneGridView.RestoreLayoutFromXml(sTmp)
        Catch ex As Exception
            Exit Try
        End Try
        PlaneGridView.FindFilterText = Nothing
        GroupTextGridColumn.Group()
        '
        ' Меню "Исполнители"
        '
        Dim Item As DevExpress.XtraBars.BarButtonItem
        Using V As New DataView(Program.ExpertTable) With {.Sort = "nameShort"}
            For i As Integer = 0 To V.Count - 1
                Item = New DevExpress.XtraBars.BarButtonItem
                Item.Caption = V(i)("nameShort").ToString.ToUpper
                Item.Description = String.Format("{0}{2}{1}", V(i)("nameLong").ToString, V(i)("expertDescription").ToString, vbCrLf)
                Item.Tag = CInt(V(i)("id"))
                Item.Glyph = My.Resources.user_32
                AddHandler Item.ItemClick, AddressOf ExpertItemClick
                WorkExpertBarSubItem.AddItem(Item)
            Next
        End Using
        '
        ' Меню "Руководители"
        '
        Using V As New DataView(Program.LeaderTable) With {.Sort = "nameShort"}
            For i As Integer = 0 To V.Count - 1
                Item = New DevExpress.XtraBars.BarButtonItem
                Item.Caption = V(i)("nameShort").ToString.ToUpper
                Item.Description = String.Format("{0}{2}{1}", V(i)("nameLong").ToString, V(i)("leaderDescription").ToString, vbCrLf)
                Item.Tag = CInt(V(i)("id"))
                Item.Glyph = My.Resources.user_32
                AddHandler Item.ItemClick, AddressOf LeaderItemClick
                WorkLeaderBarSubItem.AddItem(Item)
            Next
        End Using
        '
        ' Меню "Менеджеры"
        '
        Using V As New DataView(Program.ManagerTable) With {.Sort = "nameShort"}
            For i As Integer = 0 To V.Count - 1
                Item = New DevExpress.XtraBars.BarButtonItem
                Item.Caption = V(i)("nameShort").ToString.ToUpper
                Item.Description = String.Format("{0}{2}{1}", V(i)("nameLong").ToString, V(i)("managerDescription").ToString, vbCrLf)
                Item.Tag = CInt(V(i)("id"))
                Item.Glyph = My.Resources.user_32
                AddHandler Item.ItemClick, AddressOf ManagerItemClick
                WorkManagerBarSubItem.AddItem(Item)
            Next
        End Using
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
    ''' Перечитать план работ
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Friend Sub DataReload(Optional ByVal workId As Integer = C2.EMPTY_ID)
        Try
            '
            ' ID выделенной в плане строки
            '
            If workId < 0 Then
                If PlaneGridView.FocusedRowHandle >= 0 Then workId = CInt(PlaneGridView.GetFocusedDataRow("id"))
            End If
            '
            ' Данные из базы
            '
            PlaneTable.Rows.Clear()
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                Cmd.CommandText = String.Format( _
                    "SELECT * FROM vWorkData WHERE NOT conditionId IN ({0}, {1}, {2}, {3})", _
                    CInt(Cprp.DxData.Work.WorkCondition.IsAccept), _
                    CInt(Cprp.DxData.Work.WorkCondition.IsCancel), _
                    CInt(Cprp.DxData.Work.WorkCondition.IsClose), _
                    CInt(Cprp.DxData.Work.WorkCondition.IsReturned))
                If Not (Program.DbClient.IsChief OrElse Program.DbClient.IsSubleader) Then
                    Cmd.CommandText = String.Format("{0} AND typeId <> {1}", Cmd.CommandText, CInt(Cprp.DxData.Work.WorkType.IsLicense))
                End If
                PlaneTable.Load(Cmd.ExecuteReader)
            End Using
            '
            ' Виды услуг + Группировка работ + Сводные данные
            '
            Dim iAgree As Integer = 0
            Dim iOrderExpired As Integer = 0
            Dim iWorkExpired As Integer = 0
            Dim sTmp As String = Nothing
            Dim condition As Cprp.DxData.Work.WorkCondition = Cprp.DxData.Work.WorkCondition.IsEmpty
            For Each Row As DataRow In PlaneTable.Rows
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
                If condition = Cprp.DxData.Work.WorkCondition.IsAgree Then
                    Row("groupText") = "1. Работы на утверждении"
                ElseIf IsDBNull(Row("expertId")) AndAlso _
                    (condition = Cprp.DxData.Work.WorkCondition.IsNew OrElse condition = Cprp.DxData.Work.WorkCondition.IsNewQuery OrElse condition = Cprp.DxData.Work.WorkCondition.IsOrderQuery) Then
                    Row("groupText") = "3. Не распределенные"
                ElseIf condition = Cprp.DxData.Work.WorkCondition.IsPlaneWork OrElse _
                    condition = Cprp.DxData.Work.WorkCondition.IsPlaneQuery OrElse _
                    condition = Cprp.DxData.Work.WorkCondition.IsPlaneAgree Then
                    Row("groupText") = "4. Планирование"
                ElseIf condition = Cprp.DxData.Work.WorkCondition.IsSignature Then
                    Row("groupText") = "6. Подписание экспертом"
                Else
                    Row("groupText") = "5. В работе"
                End If
                If CBool(Row("isAskSign")) Then Row("groupText") = "6. Подписание экспертом"
                If CBool(Row("isAsk")) OrElse CBool(Row("isInt")) Then Row("groupText") = "2. Запросы и документы на утверждении"
                '
                ' Работы (планы работ) на проверке или утверждении
                '
                If condition = Cprp.DxData.Work.WorkCondition.IsPlaneAgree Then
                    Row("isAgree") = True
                ElseIf condition = Cprp.DxData.Work.WorkCondition.IsCheck OrElse _
                    condition = Cprp.DxData.Work.WorkCondition.IsAgree Then
                    If C2.IsText(Row("agreementNum")) Then
                        Row("isAgree") = True
                        iAgree += 1
                    ElseIf Not IsDBNull(Row("orderTerm")) Then
                        Dim acceptDate As Date = Cprp.DxData.Work.Common.GetPlaneDate(Date.Now, 2 * 60)
                        If CDate(Row("orderTerm")) < acceptDate Then
                            Row("isAgree") = True
                            iAgree += 1
                        End If
                    End If
                End If
                '
                ' Заказ просрочен
                '
                If Not IsDBNull(Row("orderTerm")) AndAlso CDate(Row("orderTerm")) < Date.Now Then
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
                ' Документ
                '
                If CBool(Row("isInt")) Then
                    sTmp = " (утверждение документа)"
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
            If PlaneTable.Rows.Count = 0 Then
                PlaneSummaryBarStaticItem.Caption = "Весь план: 0"
            Else
                PlaneSummaryBarStaticItem.Caption = _
                    String.Format("Весь план: <b>{0}</b>. Просрочено заказов: <b>{1}</b>. Просрочено работ: <b>{2}</b>. Работ на проверке (утверждении): <b>{3}</b>", _
                                  PlaneTable.Rows.Count, iOrderExpired, iWorkExpired, iAgree)
            End If
            '
            ' Переход к выделенной строке
            '
            If PlaneTable.Rows.Count > 0 Then
                PlaneGridView.MoveFirst()
                Dim iTmp As Integer = 0
                While PlaneGridView.IsValidRowHandle(iTmp)
                    If CInt(PlaneGridView.GetDataRow(iTmp)("id")) = workId Then
                        PlaneGridView.FocusedRowHandle = iTmp
                        Exit While
                    End If
                    iTmp += 1
                End While
            End If
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Перечитывание плана работ", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
    End Sub

    ''' <summary>
    ''' Назначение работы другому исполнителю
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExpertItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        If PlaneGridView.GetFocusedDataRow("sId").ToString Like "Заявка" Then
            WorkOpenBarButtonItem.PerformClick()
            Exit Sub
        End If
        Dim workId As Integer = CInt(PlaneGridView.GetFocusedDataRow("id"))
        Try
            Cprp.DxData.Work.Common.WorkTake(workId, e.Item.Tag, Program.DbClient.Connection, True, False)
            DataReload()
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Назначение работы другому исполнителю", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
        Program.SendWorkChangeToEo(workId)
    End Sub

    ''' <summary>
    ''' Делегирование работы другому руководителю
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LeaderItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim workId As Integer = CInt(PlaneGridView.GetFocusedDataRow("id"))
        Try
            Cprp.DxData.Work.Common.WorkDelegate(workId, e.Item.Tag, Program.DbClient.Connection, True, True)
            DataReload()
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Делегирование работы другому руководителю", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
        Program.SendWorkChangeToEo(workId)
    End Sub

    ''' <summary>
    ''' Назначение работы другому менеджеру
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ManagerItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim workId As Integer = CInt(PlaneGridView.GetFocusedDataRow("id"))
        Try
            Cprp.DxData.Work.Common.WorkManager(workId, e.Item.Tag, Program.DbClient.Connection, True, True)
            DataReload()
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Назначение работы другому менеджеру", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
        Program.SendWorkChangeToEo(workId)
    End Sub

    ''' <summary>
    ''' Сохранение настроек плана работ
    ''' </summary>
    Friend Sub LayoutSave()
        Try
            PlaneGridView.SaveLayoutToXml(String.Format("{0}\planelayout.xml", My.Computer.FileSystem.GetParentPath(My.Computer.FileSystem.SpecialDirectories.MyDocuments)))
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                Program.AppErrorTable.WriteError("Сохранение плана работы в файл", mes)
            End If
        End Try
    End Sub

    Private Sub TMR_Tick(sender As Object, e As EventArgs) Handles TMR.Tick
        DataReload()
    End Sub

    Private Sub PlaneGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles PlaneGridView.GroupRowCollapsing
        e.Allow = False
    End Sub

    ' Перечитать план работ
    Private Sub PlaneReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PlaneReloadBarButtonItem.ItemClick
        DataReload()
    End Sub

    ' Открыть работу
    Private Sub WorkOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkOpenBarButtonItem.ItemClick
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        Program.MainForm.WorkOpen(PlaneGridView.GetFocusedDataRow("id"))
    End Sub

    Private Sub PlaneGridControl_DoubleClick(sender As Object, e As EventArgs) Handles PlaneGridControl.DoubleClick
        WorkOpenBarButtonItem.PerformClick()
    End Sub

    ' Изменить срок выполнения работы экспертом
    Private Sub ExpertTermBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExpertTermBarButtonItem.ItemClick
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim Row As DataRow = PlaneGridView.GetFocusedDataRow
        If Row Is Nothing Then Exit Sub
        Dim rowId As Integer = CInt(Row("id"))
        Dim managerId As Integer = C2.ToInt(Row("managerId"))
        Dim orderNum = C2.ToText(Row("orderNum"))
        Dim clientName = C2.ToText(Row("clientName"))
        Dim expertTerm As Date = Nothing
        Dim comment As String = Nothing
        With New WorkTermForm
            .Text = String.Format("Работа № {0}", CInt(Row("id")))
            If Not IsDBNull(Row("expertTerm")) Then .TermDateEdit.EditValue = Row("expertTerm")
            If .ShowDialog <> DialogResult.OK Then Exit Sub
            expertTerm = .TermDateEdit.EditValue
            comment = C2.ToText(.CommentMemoEdit.Text)
            If .QueryCheckEdit.Checked Then comment = "Нет ответа на запрос. " & comment
            If .PriceCheckEdit.Checked Then comment = "Не подписан счет-заказ. " & comment
            comment = C2.DelPoint(comment)
        End With
        Try
            '
            ' Изменение срока эксперта и срока выдвчи работы, отправка xml-сообщения в ЭО
            '
            Using Work As New Cprp.DxData.Work.AnyWorkConnectionRow(rowId, Program.DbClient.Connection)
                Work("expertTerm") = expertTerm
                Work.UpdateOrderTerm()
                Work.DataSave()
                If C2.IsText(comment) Then comment = ". Причины переноса: " & comment
                comment = Trim(String.Format("Новый срок: {0:dd.MM.yyyy HH:mm}{1}", expertTerm, comment))
                Work.MessageWorkChangeEo()
                Work.WriteHistory(Cprp.DxData.Work.WorkEvent.ChangeExpertTerm, comment)
            End Using
            '
            ' Отправка сообщения по почте менеджеру об изменении срока
            '
            If managerId > 0 Then
                Dim caption As String = String.Format("ИЗМЕНЕНИЕ СРОКА ВЫПОЛНЕНИЯ РАБОТЫ (Работа № {0})", rowId)
                Dim body As String = String.Format("{0} изменил срок выполнения работы № {1} (Заказ № {2}, {3}):{4}{5}", _
                                                   Program.DbClient.NameShort, rowId, orderNum, clientName, vbCrLf, comment)
                Cprp.DxData.Mail.Send(Program.DbClient.Connection, Program.DbClient.Id, managerId, caption, body)
            End If
            DataReload()
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Изменение срока выполнения работы экспертом", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
    End Sub

    ' Перевести работу в состояние "Запрос" / Вернуть в работу
    Private Sub QueryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles StopBarButtonItem.ItemClick
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        If Program.MainForm.WorkStopStart(PlaneGridView.GetFocusedDataRow("id")) Then
            DataReload()
        End If
    End Sub

    ' Изменить состояние работы
    Private Sub ConditionBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ConditionBarButtonItem.ItemClick
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        Try
            Dim workId As Integer = CInt(PlaneGridView.GetFocusedDataRow("id"))
            Dim condition As Cprp.DxData.Work.WorkCondition = CType(PlaneGridView.GetFocusedDataRow("conditionId"), Cprp.DxData.Work.WorkCondition)
            Dim Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Select Case condition
                Case Cprp.DxData.Work.WorkCondition.IsWork, Cprp.DxData.Work.WorkCondition.IsQuery
                    If Cprp.DxCommon.Messages.ShowQuestion("Работа будет переведена в состояние ""Подготовка плана"". Продолжить?", String.Format("Работа № {0}", workId)) <> DialogResult.Yes Then
                        Cmd.Dispose()
                        Exit Sub
                    End If
                    Cmd.CommandText = String.Format("UPDATE tWork SET conditionId = {0} WHERE id = {1}", CInt(Cprp.DxData.Work.WorkCondition.IsPlaneWork), workId)
                    Cmd.ExecuteNonQuery()
                    Cprp.DxData.Work.Common.WriteHistory(workId, Cprp.DxData.Work.WorkEvent.ChangeCondition, "Изменение состояния с ""В работе"" на ""Подготовка плана""", Program.DbClient.Connection)
                Case Cprp.DxData.Work.WorkCondition.IsSignature
                    If Cprp.DxCommon.Messages.ShowQuestion("Работа будет переведена в состояние ""Утверждение руководителем"". Продолжить?", String.Format("Работа № {0}", workId)) <> DialogResult.Yes Then
                        Cmd.Dispose()
                        Exit Sub
                    End If
                    Cmd.CommandText = String.Format("UPDATE tWork SET conditionId = {0} WHERE id = {1}", CInt(Cprp.DxData.Work.WorkCondition.IsAgree), workId)
                    Cmd.ExecuteNonQuery()
                    Cprp.DxData.Work.Common.WriteHistory(workId, Cprp.DxData.Work.WorkEvent.ChangeCondition, "Изменение состояния с ""Подписание экспертом"" на ""Утверждение руководителем""", Program.DbClient.Connection)
            End Select
            Cmd.Dispose()
            '
            ' Отправка в ЭО сообщения об изменении работы
            '
            Program.SendWorkChangeToEo(workId)
            DataReload()
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Изменение состояния работы", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
    End Sub

    ' Открыть историю работы
    Private Sub WorkHistoryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkHistoryBarButtonItem.ItemClick
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        With New WorkHistoryForm(PlaneGridView.GetFocusedDataRow("id"))
            .ShowDialog()
        End With
    End Sub

    ' Открыть карточку заказа к работе
    Private Sub OrderOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OrderOpenBarButtonItem.ItemClick
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = PlaneGridView.GetFocusedDataRow("orderUrl").ToString
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Отсутствует ссылка на карточку заказа.", String.Format("Работа № {0}", PlaneGridView.GetFocusedDataRow("id")))
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

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        FindButtonEdit.Text = Nothing
    End Sub

    Private Sub FindButtonEdit_TextChanged(sender As Object, e As EventArgs) Handles FindButtonEdit.TextChanged
        PlaneGridView.FindFilterText = FindButtonEdit.Text
    End Sub


#Region "Изменение вида услуги в работе"

    ''' <summary>
    ''' Изменить вид услуги в выделенной работе
    ''' </summary>
    ''' <param name="newWorkType">Новый вид услуги</param>
    Private Sub ChangeWorkType(newWorkType As Cprp.DxData.Work.WorkType)
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        Try
            Dim workId As Integer = 0
            Dim workType As Cprp.DxData.Work.WorkType = Cprp.DxData.Work.WorkType.IsEmpty
            Dim workCondition As Cprp.DxData.Work.WorkCondition = Cprp.DxData.Work.WorkCondition.IsEmpty
            With PlaneGridView.GetFocusedDataRow
                workId = CInt(.Item("id"))
                workType = CType(.Item("typeId"), Cprp.DxData.Work.WorkType)
                workCondition = CType(.Item("conditionId"), Cprp.DxData.Work.WorkCondition)
            End With
            If workType = newWorkType Then Exit Sub
            If workType = Cprp.DxData.Work.WorkType.IsOrder Then Exit Sub
            If workCondition = Cprp.DxData.Work.WorkCondition.IsAgree Then Exit Sub
            Dim oldName As String = Nothing
            Dim newName As String = Nothing
            Select Case workType
                Case Cprp.DxData.Work.WorkType.IsExCont
                    oldName = "Идентификация по экспортному контролю"
                Case Cprp.DxData.Work.WorkType.IsCustomUnion
                    oldName = "Экспертиза по запретам и ограничения ЕАЭС"
                Case Cprp.DxData.Work.WorkType.IsMilitary
                    oldName = "Экспертиза продукции гражданского назначения"
                Case Cprp.DxData.Work.WorkType.IsTnved
                    oldName = "Консультация по определению кода ТН ВЭД"
                Case Cprp.DxData.Work.WorkType.IsConsultation
                    oldName = "Консультация по вопросам ВЭД"
                Case Cprp.DxData.Work.WorkType.IsLiconfirm
                    oldName = "Подтверждение лицензии"
            End Select
            Select Case CType(newWorkType, Cprp.DxData.Work.WorkType)
                Case Cprp.DxData.Work.WorkType.IsExCont
                    newName = "Идентификация по экспортному контролю"
                Case Cprp.DxData.Work.WorkType.IsCustomUnion
                    newName = "Экспертиза по запретам и ограничения ЕАЭС"
                Case Cprp.DxData.Work.WorkType.IsMilitary
                    newName = "Экспертиза продукции гражданского назначения"
                Case Cprp.DxData.Work.WorkType.IsTnved
                    newName = "Консультация по определению кода ТН ВЭД"
                Case Cprp.DxData.Work.WorkType.IsConsultation
                    newName = "Консультация по вопросам ВЭД"
                Case Cprp.DxData.Work.WorkType.IsLiconfirm
                    newName = "Подтверждение лицензии"
            End Select
            If Cprp.DxCommon.Messages.ShowQuestion(String.Format("Изменить вид услуги с ""{0}"" на ""{1}""?", oldName, newName), _
                                                   String.Format("Работа № {0}", workId)) <> DialogResult.Yes Then Exit Sub
            Using Cmd As SqlCommand = Program.DbClient.Connection.CreateCommand
                Cmd.CommandText = String.Format("UPDATE tWork SET typeId = {0} WHERE id = {1}", CInt(newWorkType), workId)
                Cmd.ExecuteNonQuery()
            End Using
            Cprp.DxData.Work.Common.WriteHistory(workId, Cprp.DxData.Work.WorkEvent.ChangeType, _
                                                 String.Format("Изменение вида услуги с ""{0}"" на ""{1}""", oldName, newName), _
                                                 Program.DbClient.Connection)
            '
            ' Отправка в ЭО сообщения об изменении работы
            '
            Program.SendWorkChangeToEo(workId)
            DataReload()
        Catch ex As Exception
            Dim mes As String = ex.Message
            If Not IsNothing(Program.AppErrorTable) Then
                mes = Program.AppErrorTable.WriteError("Изменение вида услуги в работе", mes)
            End If
            Cprp.DxCommon.Messages.ShowError(mes)
        End Try
    End Sub

    Private Sub WorkTypeExcontBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkTypeExcontBarButtonItem.ItemClick
        ChangeWorkType(Cprp.DxData.Work.WorkType.IsExCont)
    End Sub

    Private Sub WorkTypeCustomsBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkTypeCustomsBarButtonItem.ItemClick
        ChangeWorkType(Cprp.DxData.Work.WorkType.IsCustomUnion)
    End Sub

    Private Sub WorkTypeMilitaryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkTypeMilitaryBarButtonItem.ItemClick
        ChangeWorkType(Cprp.DxData.Work.WorkType.IsMilitary)
    End Sub

    Private Sub WorkTypeTnvedBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkTypeTnvedBarButtonItem.ItemClick
        ChangeWorkType(Cprp.DxData.Work.WorkType.IsTnved)
    End Sub

    Private Sub WorkTypeConsultantBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkTypeConsultantBarButtonItem.ItemClick
        ChangeWorkType(Cprp.DxData.Work.WorkType.IsConsultation)
    End Sub

    Private Sub WorkTypeLicenseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkTypeLicenseBarButtonItem.ItemClick
        ChangeWorkType(Cprp.DxData.Work.WorkType.IsLiconfirm)
    End Sub

#End Region

    ' Создание новой работы
    Private Sub WorkAddBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkAddBarButtonItem.ItemClick
        Dim Row As DataRow = PlaneGridView.GetFocusedDataRow
        If Row Is Nothing Then Exit Sub
        With New WorkNewForm(Row)
            If .ShowDialog(Me.ParentForm) = DialogResult.OK Then DataReload(.workId)
        End With
    End Sub

    Private Sub PlaneExportBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PlaneExportBarButtonItem.ItemClick
        Dim sTmp As String = Nothing
        With My.Computer.FileSystem
            sTmp = .GetTempFileName
            My.Computer.FileSystem.MoveFile(sTmp, sTmp & ".xlsx")
        End With
        sTmp = sTmp & ".xlsx"
        PlaneGridView.ExportToXlsx(sTmp)
        Using P As New Process
            P.StartInfo.FileName = sTmp
            P.StartInfo.Verb = "Open"
            P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            P.Start()
        End Using
    End Sub

End Class
