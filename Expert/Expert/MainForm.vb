Imports C2 = Cprp.DxData.Common
''' <summary>
''' Главная форма приложения
''' </summary>
Friend Class MainForm : Implements Cprp.DxData.Work.IParentForm

    ''' <summary>
    ''' Дата последнего открытия плана работ
    ''' </summary>
    Private planeDate As Date = Nothing

    Private WithEvents TMR As Timer = Nothing

    Friend Sub New()
        InitializeComponent()
        '
        ' Me
        '
        Me.Icon = My.Resources.gear_ico
        Me.Text = "Рабочее место эксперта"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
        '
        ' План работ
        '
        PlaneOpen()
    End Sub

    ''' <summary>
    ''' Отобразить всплывающее сообщение, связанное с работой
    ''' </summary>
    ''' <param name="caption">Заголовок сообщения</param>
    ''' <param name="description">Содержание сообщения</param>
    ''' <param name="workId">ID работы</param>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Friend Sub ShowWorkAlert(caption As String, description As String, workId As Integer)
        AlertControl1.Show(Me, caption, description, description, My.Resources.gear, workId, True)
    End Sub


    ' Проверка появления новых работ после последнего просмотра плана работ
    Private Sub TMR_Tick(sender As Object, e As EventArgs) Handles TMR.Tick
        If Not TabFormControl1.SelectedPage Is Nothing AndAlso TypeOf TabFormControl1.SelectedPage.ContentContainer Is PlaneUserControl Then
            planeDate = Date.Now
            Exit Sub
        End If
        Dim rowId As Integer = 0
        Dim description As String = Nothing
        Dim caption As String = Nothing
        Using T As New DataTable
            Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
                Cmd.CommandText = String.Format("SELECT id, clientName FROM tWork WHERE typeId < 10 AND conditionId = {0} AND createDate > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                                                CInt(Cprp.DxData.Work.WorkCondition.IsNew), planeDate)
                T.Load(Cmd.ExecuteReader)
            End Using
            For Each Row As DataRow In T.Rows
                rowId = CInt(Row("id"))
                description = C2.ToText(Row("clientName"))
                caption = String.Format("Новая работа № {0}", rowId)
                ShowWorkAlert(caption, description, rowId)
            Next
        End Using
        planeDate = Date.Now
    End Sub

    ' Открыть работу из сообщения о новой работе
    Private Sub AlertControl1_AlertClick(sender As Object, e As DevExpress.XtraBars.Alerter.AlertClickEventArgs) Handles AlertControl1.AlertClick
        WorkOpen(e.Info.Tag)
        If Me.WindowState = FormWindowState.Minimized Then Me.WindowState = FormWindowState.Normal
        e.AlertForm.Close()
    End Sub

    ''' <summary>
    ''' Открыть план работ
    ''' </summary>
    Friend Sub PlaneOpen()
        planeDate = Date.Now
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is PlaneUserControl Then Continue For
            CType(P.ContentContainer, PlaneUserControl).DataReload()
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        Cprp.DxCommon.WaitForm.Show(Me)
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New PlaneUserControl With {.Dock = DockStyle.Fill}
        P.Text = "ПЛАН РАБОТ"
        P.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ''' <summary>
    ''' Открыть работу
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Friend Function WorkOpen(workId As Object) As Boolean
        If Not Cprp.DxData.Work.Common.WorkExist(workId, Program.DbClient.Connection) Then Return False
        Dim wId As Integer = C2.ToInt(workId)
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then Continue For
            If CInt(CType(P.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.Id) <> wId Then Continue For
            TabFormControl.SelectedPage = P
            Return True
        Next
        ''
        '' Проверка работы на ограниченный доступ
        ''
        'If Cprp.DxData.Work.Common.IsWorkAccessLimited(wId, Program.DbClient.Connection) Then
        '    Dim sTmp As String = Cprp.DxData.Work.Common.WorkAccessUserName(wId, Program.DbClient.Connection)
        '    If C2.IsText(sTmp) Then
        '        Cprp.DxCommon.Messages.ShowWarning(String.Format("Работа рассматривается пользователем {0}.", sTmp), String.Format("Работа № {0}", wId))
        '    End If
        'End If
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
    ''' Закрыть работу
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Friend Sub WorkClose(workId As Object)
        Dim wId As Integer = C2.ToInt(workId)
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then Continue For
            If CInt(CType(P.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.Id) <> wId Then Continue For
            '! Добавить проверку других видов работ
            If TypeOf P.ContentContainer Is Cprp.DxData.Work.Excont.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Excont.WorkUserControl).IsCheckDataSaved Then Exit Sub
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Customs.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Customs.WorkUserControl).IsCheckDataSaved Then Exit Sub
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Tnved.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Tnved.WorkUserControl).IsCheckDataSaved Then Exit Sub
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Consultation.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Consultation.WorkUserControl).IsCheckDataSaved Then Exit Sub
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Liconfirm.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Liconfirm.WorkUserControl).IsCheckDataSaved Then Exit Sub
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Military.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Military.WorkUserControl).IsCheckDataSaved Then Exit Sub
                'ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Alteration.WorkUserControl Then
                '    If Not CType(P.ContentContainer, Cprp.DxData.Work.Alteration.WorkUserControl).IsCheckDataSaved Then Exit Sub
            End If
            CType(P.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.DeleteTmpFolder()
            P.Dispose()
            Exit For
        Next
        PlaneOpen()
    End Sub

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
    Public Sub ChildClose(workId As Object) Implements Cprp.DxData.Work.IParentForm.ChildClose
        WorkClose(workId)
    End Sub

    Public Sub WorkPlaneAccept(workId As Object) Implements Cprp.DxData.Work.IParentForm.WorkPlaneAccept
        Exit Sub
    End Sub

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

    ' Закрытие окна с работой
    Private Sub TabFormControl1_PageClosing(sender As Object, e As DevExpress.XtraBars.PageClosingEventArgs) Handles TabFormControl1.PageClosing
        If e.Page.ContentContainer.Controls.Count = 0 Then Exit Sub
        If Not TypeOf e.Page.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then Exit Sub
        '! Добавить проверку других видов работ
        If TypeOf e.Page.ContentContainer Is Cprp.DxData.Work.Excont.WorkUserControl Then
            If Not CType(e.Page.ContentContainer, Cprp.DxData.Work.Excont.WorkUserControl).IsCheckDataSaved Then
                e.Cancel = True
                Exit Sub
            End If
        ElseIf TypeOf e.Page.ContentContainer Is Cprp.DxData.Work.Customs.WorkUserControl Then
            If Not CType(e.Page.ContentContainer, Cprp.DxData.Work.Customs.WorkUserControl).IsCheckDataSaved Then
                e.Cancel = True
                Exit Sub
            End If
        ElseIf TypeOf e.Page.ContentContainer Is Cprp.DxData.Work.Tnved.WorkUserControl Then
            If Not CType(e.Page.ContentContainer, Cprp.DxData.Work.Tnved.WorkUserControl).IsCheckDataSaved Then
                e.Cancel = True
                Exit Sub
            End If
        ElseIf TypeOf e.Page.ContentContainer Is Cprp.DxData.Work.Consultation.WorkUserControl Then
            If Not CType(e.Page.ContentContainer, Cprp.DxData.Work.Consultation.WorkUserControl).IsCheckDataSaved Then
                e.Cancel = True
                Exit Sub
            End If
        ElseIf TypeOf e.Page.ContentContainer Is Cprp.DxData.Work.Liconfirm.WorkUserControl Then
            If Not CType(e.Page.ContentContainer, Cprp.DxData.Work.Liconfirm.WorkUserControl).IsCheckDataSaved Then
                e.Cancel = True
                Exit Sub
            End If
        ElseIf TypeOf e.Page.ContentContainer Is Cprp.DxData.Work.Military.WorkUserControl Then
            If Not CType(e.Page.ContentContainer, Cprp.DxData.Work.Military.WorkUserControl).IsCheckDataSaved Then
                e.Cancel = True
                Exit Sub
            End If
            'ElseIf TypeOf e.Page.ContentContainer Is Cprp.DxData.Work.Alteration.WorkUserControl Then
            '    If Not CType(e.Page.ContentContainer, Cprp.DxData.Work.Alteration.WorkUserControl).IsCheckDataSaved Then
            '        e.Cancel = True
            '        Exit Sub
            '    End If
        End If
        CType(e.Page.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.DeleteTmpFolder()
    End Sub

    ' Закрытие приложения
    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Cprp.DxCommon.Messages.ShowQuestion("Закрыть программу?") <> Windows.Forms.DialogResult.Yes Then
            e.Cancel = True
            Exit Sub
        End If
        For Each P As DevExpress.XtraBars.TabFormPage In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then Continue For
            '! Добавить проверку других видов работ
            If TypeOf P.ContentContainer Is Cprp.DxData.Work.Excont.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Excont.WorkUserControl).IsCheckDataSaved Then
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Customs.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Customs.WorkUserControl).IsCheckDataSaved Then
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Tnved.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Tnved.WorkUserControl).IsCheckDataSaved Then
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Consultation.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Consultation.WorkUserControl).IsCheckDataSaved Then
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Liconfirm.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Liconfirm.WorkUserControl).IsCheckDataSaved Then
                    e.Cancel = True
                    Exit Sub
                End If
            ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Military.WorkUserControl Then
                If Not CType(P.ContentContainer, Cprp.DxData.Work.Military.WorkUserControl).IsCheckDataSaved Then
                    e.Cancel = True
                    Exit Sub
                End If
                'ElseIf TypeOf P.ContentContainer Is Cprp.DxData.Work.Alteration.WorkUserControl Then
                '    If Not CType(P.ContentContainer, Cprp.DxData.Work.Alteration.WorkUserControl).IsCheckDataSaved Then
                '        e.Cancel = True
                '        Exit Sub
                '    End If
            End If
        Next
        For Each P As DevExpress.XtraBars.TabFormPage In TabFormControl1.Pages
            If TypeOf P.ContentContainer Is Cprp.DxData.Work.WorkUserControl Then
                CType(P.ContentContainer, Cprp.DxData.Work.WorkUserControl).Work.DeleteTmpFolder()
            End If
        Next
    End Sub

    ' Перечитать план работ при переходе на вкладку с планом работ
    Private Sub TabFormControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraBars.TabFormSelectedPageChangedEventArgs) Handles TabFormControl1.SelectedPageChanged
        If TypeOf e.Page.ContentContainer Is PlaneUserControl Then
            planeDate = Date.Now
            CType(e.Page.ContentContainer, PlaneUserControl).DataReload()
        End If
    End Sub

    ' Не нужно для плана работ эксперта
    Public Sub WorkQueryRun(workId As Object) Implements Cprp.DxData.Work.IParentForm.WorkQueryRun
        Exit Sub
    End Sub

    ' Открыть руководство пользователя
    Private Sub ManualBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ManualBarButtonItem.ItemClick
        Dim filePath As String = String.Format("{0}\{1}.pdf", My.Computer.FileSystem.SpecialDirectories.Temp, Guid.NewGuid.ToString)
        My.Computer.FileSystem.WriteAllBytes(filePath, My.Resources.manual, False)
        Using P As New Process
            P.StartInfo.FileName = filePath
            P.StartInfo.Verb = "Open"
            P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
            P.Start()
        End Using
    End Sub

End Class