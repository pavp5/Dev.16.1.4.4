Imports Cprp.DxData.Common
''' <summary>
''' Главная форма приложения
''' </summary>
Friend Class MainForm : Implements Cprp.DxData.Work.IParentForm



    ''' <summary>
    ''' Вкладка "План работ"
    ''' </summary>
    Private PlanePage As DevExpress.XtraBars.TabFormPage = Nothing

    ''' <summary>
    ''' Вкладка "Утвержденные работы"
    ''' </summary>
    Private AcceptPage As DevExpress.XtraBars.TabFormPage = Nothing

    ' ''' <summary>
    ' ''' Менеджер очередей MQ
    ' ''' </summary>
    'Private Mq As Cprp.Mq.QueueManager = Nothing

    ' ''' <summary>
    ' ''' Объект для формирования xml-сообщений для Mq
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Xm As Cprp.Mq.XmlMessage = Nothing

    ''' <summary>
    ''' Таймер для проверки времени открытия вкладок с работами
    ''' </summary>
    Private WithEvents TMR As Timer = Nothing

    ''' <summary>
    ''' Таймер закончил цикл обработки
    ''' </summary>
    Private isTmrFree As Boolean = True


    Friend Sub New()
        InitializeComponent()
        ''
        '' Mq, Xm
        ''
        'Try
        '    Mq = New Cprp.Mq.QueueManager("172.28.1.10", 1418, "CHANNEL.CLIENT", "EX_EXPERT_OLD", "INBOX", "EX_EXPERT.TO", Nothing)
        '    Xm = New Cprp.Mq.XmlMessage(Program.DbClient.Connection)
        'Catch ex As Exception
        '    Cprp.DxCommon.Messages.ShowError(ex.Message, "Подключение к MQ")
        'End Try
        '
        ' Удалить записи об открытых работах
        '
        Cprp.DxData.Work.Common.WorkAccessDelete(EMPTY_ID, Program.DbClient.Id, Program.DbClient.Connection)
        '
        ' TMR
        '
        TMR = New Timer
        TMR.Interval = 10000
        TMR.Start()
        '
        ' Me
        '
        Me.Icon = My.Resources.plane_ico
        Me.Text = "Рабочее место руководителя"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
        '
        ' Стоимость У.Е.
        '
        'Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
        '    Cmd.CommandText = "SELECT price FROM tCalcTarif WHERE name LIKE 'УЕСТОИМОСТЬ'"
        '    UEPriceBarButtonItem.Caption = String.Format("СТОИМОСТЬ У.Е. =  {0:###.0} р.", Cmd.ExecuteScalar)
        'End Using
        'UEPriceBarButtonItem.Enabled = Program.DbClient.IsChief
        UEPriceBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never        
        '
        ' План работ
        '
        PlaneOpen()        
        '
        ' Утвержденные работы
        '
        AcceptedOpen()
        '
        ' Перейти на вкладку с планом работ
        '
        PlaneOpen()

    End Sub


    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not PlanePage Is Nothing Then CType(PlanePage.ContentContainer, PlaneUserControl).LayoutSave()
        If Not AcceptPage Is Nothing Then CType(AcceptPage.ContentContainer, AcceptedUserControl).LayoutSave()
        If Cprp.DxCommon.Messages.ShowQuestion("Закрыть программу ""Рабочее место руководителя""?", "Вопрос") = Windows.Forms.DialogResult.No Then
            e.Cancel = True
        Else
            For Each P As DevExpress.XtraBars.TabFormPage In TabFormControl1.Pages
                If TypeOf P.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then
                    CType(P.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.DeleteTmpFolder()
                End If
            Next
        End If
        Cprp.DxData.Work.Common.WorkAccessDelete(EMPTY_ID, Program.DbClient.Id, Program.DbClient.Connection)
    End Sub

    ''' <summary>
    ''' Открыть план работ
    ''' </summary>
    Friend Sub PlaneOpen()
        If Not PlanePage Is Nothing Then
            TabFormControl.SelectedPage = PlanePage
            Exit Sub
        End If
        Cprp.DxCommon.WaitForm.Show(Me)
        PlanePage = New DevExpress.XtraBars.TabFormPage
        PlanePage.ContentContainer = New PlaneUserControl With {.Dock = DockStyle.Fill}
        PlanePage.Text = "ПЛАН РАБОТ"
        PlanePage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False
        TabFormControl.Pages.Add(PlanePage)
        TabFormControl.SelectedPage = PlanePage
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ''' <summary>
    ''' Открыть список утвержденных работ
    ''' </summary>
    Friend Sub AcceptedOpen()
        If Not AcceptPage Is Nothing Then
            TabFormControl.SelectedPage = AcceptPage
            Exit Sub
        End If
        Cprp.DxCommon.WaitForm.Show(Me)
        AcceptPage = New DevExpress.XtraBars.TabFormPage
        AcceptPage.ContentContainer = New AcceptedUserControl With {.Dock = DockStyle.Fill}
        AcceptPage.Text = "ЗАВЕРШЕННЫЕ РАБОТЫ"
        AcceptPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False
        TabFormControl.Pages.Add(AcceptPage)
        TabFormControl.SelectedPage = AcceptPage
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ''' <summary>
    ''' Открыть работу
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Friend Function WorkOpen(workId As Object) As Boolean
        If Not Cprp.DxData.Work.Common.WorkExist(workId, Program.DbClient.Connection) Then Return False
        Dim wId As Integer = ToInt(workId)
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then Continue For
            If CInt(CType(P.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.Id) <> wId Then Continue For
            TabFormControl.SelectedPage = P
            Return True
        Next
        '
        ' Проверка работы на ограниченный доступ
        '
        If Cprp.DxData.Work.Common.IsWorkAccessLimited(wId, Program.DbClient.Connection) Then
            Dim sTmp As String = Cprp.DxData.Work.Common.WorkAccessUserName(wId, Program.DbClient.Connection)
            If IsText(sTmp) Then
                Cprp.DxCommon.Messages.ShowWarning(String.Format("Работа рассматривается пользователем {0}.", sTmp), String.Format("Работа № {0}", wId))
                Return False
            End If
            Cprp.DxData.Work.Common.WorkAccessAdd(workId, Program.DbClient.Id, Program.DbClient.Connection)
        End If
        '
        ' Создание элемента управления с работой
        '
        Cprp.DxCommon.WaitForm.Show(Me)
        Dim WorkControl As Cprp.DxData.Work.WorkUserControl = Nothing
        Select Case Cprp.DxData.Work.Common.GetWorkTypeById(wId, Program.DbClient.Connection)
            Case Cprp.DxData.Work.WorkType.IsExCont
                WorkControl = New Cprp.DxData.Work.Excont.WorkUserControl(wId, Program.DbClient.Connection, Program.DbClient, Program.AppErrorTable) With {.Dock = DockStyle.Fill}
            Case Cprp.DxData.Work.WorkType.IsCustomUnion
                WorkControl = New Cprp.DxData.Work.Customs.WorkUserControl(wId, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill}
            Case Cprp.DxData.Work.WorkType.IsTnved
                WorkControl = New Cprp.DxData.Work.Tnved.WorkUserControl(wId, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill}
            Case Cprp.DxData.Work.WorkType.IsLiconfirm
                WorkControl = New Cprp.DxData.Work.Liconfirm.WorkUserControl(wId, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill}
            Case Cprp.DxData.Work.WorkType.IsConsultation
                WorkControl = New Cprp.DxData.Work.Consultation.WorkUserControl(wId, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill}
            Case Cprp.DxData.Work.WorkType.IsMilitary
                WorkControl = New Cprp.DxData.Work.Military.WorkUserControl(wId, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill}
            Case Cprp.DxData.Work.WorkType.IsOrder
                WorkControl = New Cprp.DxData.Work.Order.WorkUserControl(wId, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill}
            Case Cprp.DxData.Work.WorkType.IsAlteration
                WorkControl = New Cprp.DxData.Work.Alteration.WorkUserControl(wId, Program.DbClient.Connection, Program.DbClient) With {.Dock = DockStyle.Fill}

        End Select
        If Not WorkControl Is Nothing Then
            P = New DevExpress.XtraBars.TabFormPage
            P.ContentContainer = WorkControl
            P.Text = String.Format("Работа #{0}", wId)
            TabFormControl.Pages.Add(P)
            TabFormControl.SelectedPage = P
            Cprp.DxCommon.WaitForm.Close()
            Return True
        End If
        Cprp.DxCommon.WaitForm.Close()
        Return False
    End Function

    ''' <summary>
    ''' Открыть работу
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Public Function ChildOpen(workId As Object) As Boolean Implements Cprp.DxData.Work.IParentForm.ChildOpen
        Return WorkOpen(workId)
    End Function

    ''' <summary>
    ''' Закрыть работу
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Friend Sub WorkClose(workId As Object)
        Dim wId As Integer = ToInt(workId)
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then Continue For
            If CInt(CType(P.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.Id) <> wId Then Continue For
            CType(P.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.DeleteTmpFolder()
            Cprp.DxData.Work.Common.WorkAccessDelete(wId, Program.DbClient.Id, Program.DbClient.Connection)
            P.Dispose()
            PlaneOpen()
            Exit For
        Next
    End Sub

    ''' <summary>
    ''' Закрыть работу
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Public Sub ChildClose(workId As Object) Implements Cprp.DxData.Work.IParentForm.ChildClose
        WorkClose(workId)
    End Sub

    ' ''' <summary>
    ' ''' Отправка работы в ИСЭК
    ' ''' </summary>
    ' ''' <param name="workId">ID работы</param>
    ' ''' <remarks>Вызывается из карточки работы при утверждении плана работы</remarks> 
    'Public Sub WorkPlaneAccept(workId As Object) Implements Cprp.DxData.Work.IParentForm.WorkPlaneAccept
    '    Dim sTmp As String = Xm.GetNewWork(workId, Guid.NewGuid)
    '    Mq.Write(Cprp.Mq.QueueManager.OutQueue.Queue1, sTmp)
    'End Sub

    ' Потеряло актуальность
    Public Sub WorkPlaneAccept(workId As Object) Implements Cprp.DxData.Work.IParentForm.WorkPlaneAccept
        Exit Sub
    End Sub

    ''' <summary>
    ''' Запустить процедуру перевода работы в состояние запроса
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <remarks>Вызывается из плана работ и из карточки работы</remarks>
    Public Sub WorkQueryRun(workId As Object) Implements Cprp.DxData.Work.IParentForm.WorkQueryRun
        If Not Cprp.DxData.Work.Common.WorkExist(workId, Program.DbClient.Connection) Then Exit Sub
        ' признак снятия запроса
        Dim bTmp As Boolean = False
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = String.Format("SELECT isAskSend FROM tWork WHERE id = {0}", CInt(workId))
            bTmp = CBool(Cmd.ExecuteScalar)
        End Using
        If bTmp Then
            Using F As New QueryCloseForm(workId)
                If F.ShowDialog <> DialogResult.OK Then Exit Sub
            End Using
            ' Определение срока выдачи работы
            Using Work As New Cprp.DxData.Work.AnyWorkConnectionRow(workId, Program.DbClient.Connection)
                Work.UpdateOrderTerm()
                Work.DataSave()
            End Using
        Else
            Using F As New QueryRunForm(workId)
                If F.ShowDialog <> DialogResult.OK Then Exit Sub
            End Using
        End If
    End Sub

    ''' <summary>
    ''' Остановить или возобновить выполнение работы
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <remarks>Вызывается из плана работ и из карточки работы</remarks>
    Public Function WorkStopStart(workId As Object) As Boolean
        ' признак остановки работы
        Dim bStop As Boolean = False
        ' признак наличия запроса
        Dim bQuery As Boolean = False
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = String.Format("SELECT ISNULL(isStop, 0) FROM tWork WHERE id = {0}", CInt(workId))
            bStop = CBool(Cmd.ExecuteScalar)
            Cmd.CommandText = String.Format("SELECT isAskSend FROM tWork WHERE id = {0}", CInt(workId))
            bQuery = CBool(Cmd.ExecuteScalar)
        End Using
        If Not (bStop OrElse bQuery) Then
            ' остановка работы
            Return Cprp.DxData.Work.Common.WorkStop(workId, Program.DbClient.Connection)
        ElseIf bStop Then
            ' возобновление работы
            Return Cprp.DxData.Work.Common.WorkStart(workId, Program.DbClient.Connection)
        ElseIf bQuery Then
            ' снятие запроса
            Using F As New QueryCloseForm(workId)
                If F.ShowDialog <> DialogResult.OK Then Return False
            End Using
        End If
        Return True
    End Function

    ''' <summary>
    ''' Поиск работ
    ''' </summary>
    Private Sub FindBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Cprp.DxData.FindA.FindUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        Dim ExdbaConnectionString As String = Cprp.DxData.Resource.Resource.GetStrData("EXDBACONNECTION", Program.DbClient.Connection)
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New Cprp.DxData.FindA.FindUserControl(ExdbaConnectionString) With {.Dock = DockStyle.Fill}
        P.Text = "Поиск работ"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ''' <summary>
    ''' Поиск в БД №5
    ''' </summary>
    Private Sub FindFBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindFBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Cprp.DxData.FindF.FindUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        Dim FdbConnectionString As String = Cprp.DxData.Resource.Resource.GetStrData("FDBCONNECTION", Program.DbClient.Connection)
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New Cprp.DxData.FindF.FindUserControl(FdbConnectionString) With {.Dock = DockStyle.Fill}
        P.Text = "Поиск работ"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ''' <summary>
    ''' Нормативные документы
    ''' </summary>
    Private Sub LawBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LawBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Cprp.DxData.Law.LawUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        Cprp.DxCommon.WaitForm.Show(Me)
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New Cprp.DxData.Law.LawUserControl(Program.DbClient.Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Нормативные документы"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ''' <summary>
    ''' Контролируемые заключения
    ''' </summary>
    Private Sub FInfoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FInfoBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is FInfoUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        Cprp.DxCommon.WaitForm.Show(Me)
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New FInfoUserControl With {.Dock = DockStyle.Fill}
        P.Text = "Контролируемые заключения"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ''' <summary>
    ''' КТУ экспертов за период
    ''' </summary>
    Private Sub ReportKtuBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportKtuBarButtonItem.ItemClick
        For Each F As Form In Application.OpenForms
            If TypeOf F Is ReportExpertKtuForm Then
                F.WindowState = FormWindowState.Normal
                F.TopMost = True
                F.TopMost = False
                Exit Sub
            End If
        Next
        With New ReportExpertKtuForm
            .Show()
        End With
    End Sub

    ''' <summary>
    ''' Превышения сроков исполнения операций по работам
    ''' </summary>
    Private Sub ReprtWorkTermBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReprtWorkTermBarButtonItem.ItemClick
        For Each F As Form In Application.OpenForms
            If TypeOf F Is ReportWorkTermForm Then
                F.WindowState = FormWindowState.Normal
                F.TopMost = True
                F.TopMost = False
                Exit Sub
            End If
        Next
        With New ReportWorkTermForm
            .Show()
        End With
    End Sub

    ''' <summary>
    ''' Работы по внесению изменений за период
    ''' </summary>
    Private Sub ReportExpertReworkBarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportExpertReworkBarButtonItem1.ItemClick
        For Each F As Form In Application.OpenForms
            If TypeOf F Is ReportExpertBackForm Then
                F.WindowState = FormWindowState.Normal
                F.TopMost = True
                F.TopMost = False
                Exit Sub
            End If
        Next
        With New ReportExpertBackForm
            .Show()
        End With
    End Sub

    ''' <summary>
    ''' Количество заявок по регионам за период
    ''' </summary>
    Private Sub ReportRegionBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportRegionBarButtonItem.ItemClick
        For Each F As Form In Application.OpenForms
            If TypeOf F Is ReportRegionForm Then
                F.WindowState = FormWindowState.Normal
                F.TopMost = True
                F.TopMost = False
                Exit Sub
            End If
        Next
        With New ReportRegionForm
            .Show()
        End With
    End Sub

    ''' <summary>
    ''' Стоиомсть у.е.
    ''' </summary>
    Private Sub UEPriceBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles UEPriceBarButtonItem.ItemClick
        With New UEPriceForm
            If .ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
        End With
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = "SELECT price FROM tCalcTarif WHERE name LIKE 'УЕСТОИМОСТЬ'"
            UEPriceBarButtonItem.Caption = String.Format("СТОИМОСТЬ У.Е. =  {0:###.0} р.", Cmd.ExecuteScalar)
        End Using
    End Sub

    ' Закрыть работу
    Private Sub TabFormControl1_PageClosing(sender As Object, e As DevExpress.XtraBars.PageClosingEventArgs) Handles TabFormControl1.PageClosing
        If TypeOf e.Page.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then
            e.Cancel = True
            WorkClose(CType(e.Page.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.Id)
        End If
    End Sub

    ' Перейти на вкладку с планом работ после закрытия любой вкладки
    Private Sub TabFormControl1_PageClosed(sender As Object, e As DevExpress.XtraBars.PageClosedEventArgs) Handles TabFormControl1.PageClosed
        If TabFormControl1.SelectedPage Is e.Page Then PlaneOpen()
    End Sub

    ' Перечитать план работ при переходе на вкладку с планом работ
    Private Sub TabFormControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraBars.TabFormSelectedPageChangedEventArgs) Handles TabFormControl1.SelectedPageChanged
        If TypeOf e.Page.ContentContainer Is PlaneUserControl Then
            CType(e.Page.ContentContainer, PlaneUserControl).DataReload()
        End If
    End Sub

    ' Проверка времени открытия вкладок с работами
    Private Sub TMR_Tick(sender As Object, e As EventArgs) Handles TMR.Tick
        If Not isTmrFree Then Exit Sub

        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        Dim workId As Integer = EMPTY_ID
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then Continue For
            With CType(P.ContentContainer, Cprp.DxData.Work.WorkUserControl)
                If Not Cprp.DxData.Work.Common.IsWorkAccessLimited(.Work.Id, Program.DbClient.Connection) Then Continue For
                If .OpenDate.AddMinutes(10) < Date.Now Then
                    ' интевал утверждения работы - 30 мин
                    If .Work.Condition = Cprp.DxData.Work.WorkCondition.IsAgree AndAlso .OpenDate.AddMinutes(30) > Date.Now Then Continue For
                    ' попытка закрыть открытые модальные формы
                    For Each F As Form In Application.OpenForms
                        If TypeOf F Is DevExpress.XtraWaitForm.WaitForm Then Continue For
                        If F.Modal Then
                            F.Activate()
                            If String.IsNullOrWhiteSpace(F.Name) Then
                                SendKeys.SendWait("{ENTER}")
                            Else
                                SendKeys.SendWait("{ESC}")
                            End If
                            Exit For
                        End If
                    Next
                    ' закрытие вкладки с работой
                    workId = CInt(.Work.Id)
                    WorkClose(workId)
                    AlertControl1.Show(Me, String.Format("Работа № {0} закрыта", workId), "Превышено время рассмотрения работы", Nothing, System.Drawing.SystemIcons.Warning.ToBitmap, workId, True)
                End If
            End With
            Exit For
        Next

        isTmrFree = True
    End Sub

    ' Открыть работу из сообщения о закрытии работы
    Private Sub AlertControl1_AlertClick(sender As Object, e As DevExpress.XtraBars.Alerter.AlertClickEventArgs) Handles AlertControl1.AlertClick
        WorkOpen(e.Info.Tag)
        If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
        e.AlertForm.Close()
    End Sub

End Class