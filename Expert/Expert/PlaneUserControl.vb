Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "План работ"
''' </summary>
Friend Class PlaneUserControl

    ' План работ
    Private PlaneTable As DataTable = Nothing

    ' Предпоследние комментарии к работам
    Private CommentTable As DataTable = Nothing

    Private WithEvents TMR As Timer = Nothing

    Friend Sub New()
        InitializeComponent()
        '
        ' PlaneTable
        '
        PlaneTable = New DataTable
        With PlaneTable.Columns
            .Add("id", GetType(Integer))                ' ID
            .Add("sId", GetType(String))                ' ID + обозначение вида услуги
            .Add("expertId", GetType(Integer))          ' ID эксперта
            .Add("expertTerm", GetType(Date))           ' срок эксперта
            .Add("goodCount", GetType(Integer))         ' количество объектов исследования
            .Add("totalWork", GetType(Integer))         ' трудоемкость (мин)
            .Add("orderNum", GetType(String))           ' номер заказа
            .Add("clientName", GetType(String))         ' наименование заказчика
            .Add("description", GetType(String))        ' сведения о работе
            .Add("conditionName", GetType(String))      ' состояние работы (наименование)
            .Add("managerName", GetType(String))        ' менеджер (ФИО)
            .Add("leaderName", GetType(String))         ' руководитель (ФИО)
            .Add("isExpired", GetType(Boolean))         ' просрочена
            .Add("isPayment", GetType(Boolean))         ' оплачена
            .Add("conditionId", GetType(Integer))       ' состояние работы (ID)
            .Add("typeId", GetType(Integer))            ' вид услуги (ID)
            .Add("groupText", GetType(String))          ' текст для группировки работ
            .Add("comment", GetType(String))            ' комментарий к работе
            .Add("isAsk", GetType(Boolean))             ' есть запрос на утверждении
            .Add("isAskSign", GetType(Boolean))         ' есть запрос на подписании
            .Add("isAskSend", GetType(Boolean))         ' есть отправленный запрос
            .Add("isStop", GetType(Boolean))            ' работа остановлена
            .Add("isInt", GetType(Boolean))             ' есть внутренний документ на утверждении
        End With
        '
        ' CommentTable
        '
        CommentTable = New DataTable
        With CommentTable.Columns
            .Add("workId", GetType(Integer))
            .Add("comment", GetType(String))
        End With
        CommentTable.PrimaryKey = New DataColumn() {CommentTable.Columns("workId")}
        '
        ' PlaneGridControl, PlaneGridView 
        '
        PlaneGridControl.DataSource = PlaneTable
        PlaneGridView.SortInfo.Insert(0, TermGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        GroupTextGridColumn.Group()
        '
        ' Data
        '
        PlaneAcceptBarCheckItem.Checked = My.Settings.isPlaneAccept
        DataReload()
        '
        ' TMR
        '
        TMR = New Timer
        TMR.Interval = 60000
        TMR.Start()
    End Sub

    ''' <summary>
    ''' Перечитать план работ
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Friend Sub DataReload()
        Try
            '
            ' Хандлер текущей выделенной в плане строки
            '
            Dim iHandler As Integer = PlaneGridView.FocusedRowHandle

            Dim sTmp As String = Nothing
            '
            ' Данные из базы
            '
            PlaneTable.Rows.Clear()
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                Cmd.CommandText = String.Format( _
                    "SELECT * FROM vWorkData WHERE expertId = {0} AND NOT conditionId IN ({1}, {2}, {3})", _
                    CInt(Program.DbClient.Id), _
                    CInt(Cprp.DxData.Work.WorkCondition.IsAccept), _
                    CInt(Cprp.DxData.Work.WorkCondition.IsClose), _
                    CInt(Cprp.DxData.Work.WorkCondition.IsCancel))
                If Not PlaneAcceptBarCheckItem.Checked Then
                    Cmd.CommandText = String.Format("{0} AND conditionId <> {1}", Cmd.CommandText, CInt(Cprp.DxData.Work.WorkCondition.IsAgree))
                End If
                PlaneTable.Load(Cmd.ExecuteReader)
            End Using
            '
            ' Виды услуг + Просроченные работы + Группировка работ + Количество просроченных работ + Суммарная трудоемкость
            '
            Dim iExpired As Integer = 0
            Dim iTotal As Integer = 0
            Dim condition As Cprp.DxData.Work.WorkCondition = Cprp.DxData.Work.WorkCondition.IsNew
            Dim Row As DataRow = Nothing
            For Each Row In PlaneTable.Rows
                Select Case CType(Row("typeId"), Cprp.DxData.Work.WorkType)
                    Case Cprp.DxData.Work.WorkType.IsExCont : Row("sId") = "ДН"
                    Case Cprp.DxData.Work.WorkType.IsCustomUnion : Row("sId") = "ЗиО"
                    Case Cprp.DxData.Work.WorkType.IsTnved : Row("sId") = "Код"
                    Case Cprp.DxData.Work.WorkType.IsLiconfirm : Row("sId") = "Контр."
                    Case Cprp.DxData.Work.WorkType.IsConsultation : Row("sId") = "Кон."
                    Case Cprp.DxData.Work.WorkType.IsMilitary : Row("sId") = "Граж."
                    Case Cprp.DxData.Work.WorkType.IsAlteration : Row("sId") = "Измен."
                    Case Cprp.DxData.Work.WorkType.IsLicense : Row("sId") = "Лиценз."
                End Select
                condition = CType(Row("conditionId"), Cprp.DxData.Work.WorkCondition)
                Select Case condition
                    Case Cprp.DxData.Work.WorkCondition.IsSignature
                        Row("groupText") = "1. Подписание"
                    Case Cprp.DxData.Work.WorkCondition.IsAgree
                        Row("groupText") = "3. Утверждение"
                    Case Else
                        Row("groupText") = "2. В работе"
                        If Not IsDBNull(Row("totalWork")) Then iTotal += CInt(Row("totalWork"))
                End Select
                If Not (IsDBNull(Row("expertTerm")) OrElse _
                    condition = Cprp.DxData.Work.WorkCondition.IsAccept OrElse _
                    condition = Cprp.DxData.Work.WorkCondition.IsClose OrElse _
                    condition = Cprp.DxData.Work.WorkCondition.IsCancel) Then
                    If Not IsDBNull(Row("expertTerm")) AndAlso CDate(Row("expertTerm")) < Date.Now.AddMinutes(-30) AndAlso Not CBool(Row("isAskSend")) AndAlso _
                        (IsDBNull(Row("isStop")) OrElse Not CBool(Row("isStop"))) AndAlso _
                        CType(Row("typeId"), Cprp.DxData.Work.WorkType) <> Cprp.DxData.Work.WorkType.IsLicense Then
                        Row("isExpired") = True
                        iExpired += 1
                    End If
                End If
                '
                ' Запрос
                '
                sTmp = Nothing
                If CBool(Row("isAskSign")) Then
                    sTmp = " (подписание запроса)"
                    Row("groupText") = "1. Подписание"
                ElseIf CBool(Row("isAsk")) Then
                    sTmp = " (утверждение запроса)"
                ElseIf CBool(Row("isAskSend")) Then
                    sTmp = " (направлен запрос)"
                ElseIf Not IsDBNull(Row("isStop")) AndAlso CBool(Row("isStop")) Then
                    sTmp = " (остановлена)"
                End If
                '
                ' Документ
                '
                If CBool(Row("isInt")) Then sTmp = " (утверждение документа)"
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
            PlaneSummaryBarStaticItem.Caption = String.Format("Весь план: <b>{0}</b>. Просрочено: <b>{1}</b>. Суммарная трудоемкость: <b>{2}</b> ч. <b>{3}</b> мин.", _
                PlaneTable.Rows.Count, iExpired, iTotal \ 60, iTotal Mod 60)
            '
            ' Проверка изменения комментариев к работе
            '
            Dim comment As String = Nothing
            Dim workId As Integer = 0
            For i As Integer = 0 To PlaneTable.Rows.Count - 1
                comment = C2.ToText(PlaneTable(i)("comment"))
                If Not C2.IsText(comment) Then Continue For
                workId = CInt(PlaneTable(i)("id"))
                Row = CommentTable.Rows.Find(workId)
                If Row Is Nothing Then
                    CommentTable.Rows.Add(New Object() {workId, comment})
                ElseIf C2.ToText(Row("comment")) <> comment Then
                    Row("comment") = comment
                    Program.MainForm.ShowWorkAlert(String.Format("Работа № {0}", workId), "Изменился комментарий к работе", workId)
                End If
            Next
            '
            ' Переход к последней выделенной строке
            '
            If PlaneTable.Rows.Count > 0 Then
                PlaneGridView.MoveFirst()
                Dim iTmp As Integer = 0
                While PlaneGridView.IsValidRowHandle(iTmp)
                    If iTmp = iHandler Then
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

    Private Sub PlaneGridView_GroupRowCollapsing(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles PlaneGridView.GroupRowCollapsing
        e.Allow = False
    End Sub

    Private Sub TMR_Tick(sender As Object, e As EventArgs) Handles TMR.Tick
        DataReload()
    End Sub

    ' Перечитать план работ
    Private Sub PlaneReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PlaneReloadBarButtonItem.ItemClick
        DataReload()
    End Sub

    ' Отображать в плане работ утвержденные работы
    Private Sub PlaneAcceptBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PlaneAcceptBarCheckItem.CheckedChanged
        With My.Settings
            .isPlaneAccept = PlaneAcceptBarCheckItem.Checked
            .Save()
        End With
        DataReload()
    End Sub

    ' Открыть работу
    Private Sub WorkOpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkOpenBarButtonItem.ItemClick
        If PlaneGridView.FocusedRowHandle < 0 Then Exit Sub
        With PlaneGridView.GetFocusedDataRow
            'If CType(.Item("conditionId"), Cprp.DxData.Work.WorkCondition) <> Cprp.DxData.Work.WorkCondition.IsWork OrElse IsDBNull(.Item("isecId")) Then
            Program.MainForm.WorkOpen(.Item("id"))
            'Else
            '    '
            '    ' Открытие работы в ИСЭК
            '    '
            '    Using P As New Process
            '        P.StartInfo.FileName = String.Format("http://isec.excont.ru/api/?user={0}&workId={1}", _
            '                                             Program.DbClient.Email, CInt(.Item("isecId")))
            '        'MsgBox(P.StartInfo.FileName)
            '        P.StartInfo.Verb = "Open"
            '        P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            '        P.Start()
            '    End Using
            '    'Shell(String.Format("C:\Program Files\Google\Chrome\Application\chrome.exe isec.excont.ru/api/?user={0}&workId={1}", _
            '    '                    Program.DbClient.Email, CInt(.Item("isecId"))), AppWinStyle.NormalFocus)
            'End If
        End With
    End Sub

    Private Sub PlaneGridControl_DoubleClick(sender As Object, e As EventArgs) Handles PlaneGridControl.DoubleClick
        WorkOpenBarButtonItem.PerformClick()
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

End Class
