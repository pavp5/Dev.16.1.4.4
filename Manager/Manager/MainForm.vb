''' <summary>
''' Главная форма приложения
''' </summary>
''' <remarks></remarks>
Friend Class MainForm

    ''' <summary>
    ''' План работ
    ''' </summary>
    Private PlaneControl As PlaneUserControl = Nothing

    ''' <summary>
    ''' Закрытые работы
    ''' </summary>
    Private ClosedControl As ClosedUserControl = Nothing

    ''' <summary>
    ''' Расчеты
    ''' </summary>
    Friend CalcControl As CalcUserControl = Nothing

    ''' <summary>
    ''' Согласования
    ''' </summary>
    Private DeptControl As DeptUserControl = Nothing

    ''' <summary>
    ''' Отчет по новым товарам Катерпиллер
    ''' </summary>
    Private ReportCatControl As ReportCatUserControl = Nothing

    ''' <summary>
    ''' Отчет по КТУ экспертов
    ''' </summary>
    Private ReportExpertKtuForm As ReportExpertKtuForm = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' Me
        '
        Me.Icon = My.Resources.calendar_gear_ico
        Me.Text = "Рабочее место менеджера"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
        '
        ' Скрыть раздел "Согласование"
        '
        DeptBarCheckItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        ' План работ
        '
        PlaneBarCheckItem.PerformClick()
    End Sub

    ''' <summary>
    ''' Открыть план работ
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Friend Sub PlaneOpen()
        If PlaneControl Is Nothing Then
            PlaneControl = New PlaneUserControl With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        End If
        PlaneControl.DataReload()
        MainPanelControl.Controls.SetChildIndex(PlaneControl, 0)
        Me.Text = "Рабочее место менеджера - План работ"
    End Sub

    ''' <summary>
    ''' Открыть список закрытых работ
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Friend Sub ClosedOpen()
        If ClosedControl Is Nothing Then
            ClosedControl = New ClosedUserControl With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        End If
        ClosedControl.DataReload()
        MainPanelControl.Controls.SetChildIndex(ClosedControl, 0)
        Me.Text = "Рабочее место менеджера - Закрытые работы"
    End Sub

    ''' <summary>
    ''' Открыть список расчетов стоимостей
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Friend Sub CalcOpen()
        If CalcControl Is Nothing Then
            CalcControl = New CalcUserControl With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        End If
        CalcControl.DataReload()
        MainPanelControl.Controls.SetChildIndex(CalcControl, 0)
        Me.Text = "Рабочее место менеджера - Расчеты"
    End Sub

    ''' <summary>
    ''' Открыть список согласований стоимостей
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Friend Sub DeptOpen()
        If DeptControl Is Nothing Then
            DeptControl = New DeptUserControl With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        End If
        MainPanelControl.Controls.SetChildIndex(DeptControl, 0)
        Me.Text = "Рабочее место менеджера - Согласования"
    End Sub

    ''' <summary>
    ''' Открыть отчет по товарам Катерпиллер
    ''' </summary>
    ''' <remarks>Процедура вызывается из других модулей</remarks>
    Friend Sub ReportCatOpen()
        If ReportCatControl Is Nothing Then
            ReportCatControl = New ReportCatUserControl With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        End If
        MainPanelControl.Controls.SetChildIndex(ReportCatControl, 0)
        Me.Text = "Рабочее место менеджера - Отчет по Катерпиллер"
    End Sub

    ''' <summary>
    ''' Открыть отчет по КТУ экспертов
    ''' </summary>
    Friend Sub ReportExpertKtuOpen()
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

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Not PlaneControl Is Nothing Then PlaneControl.LayoutSave()
        If Not ClosedControl Is Nothing Then ClosedControl.LayoutSave()
        If Not CalcControl Is Nothing Then CalcControl.LayoutSave()
        'DeptControl.LayoutSave()
    End Sub

    Private Sub PlaneBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles PlaneBarCheckItem.CheckedChanged
        PlaneOpen()
    End Sub

    Private Sub ClosedBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ClosedBarCheckItem.CheckedChanged
        ClosedOpen()
    End Sub

    Private Sub CalcBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CalcBarCheckItem.CheckedChanged
        CalcOpen()
    End Sub

    Private Sub DeptBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DeptBarCheckItem.CheckedChanged
        DeptOpen()
    End Sub

    Private Sub ReportExpertKtuBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportExpertKtuBarCheckItem.CheckedChanged
        ReportExpertKtuOpen()
    End Sub

    Private Sub ReportFinfoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportFinfoBarButtonItem.ItemClick
        For Each F As Form In Application.OpenForms
            If TypeOf F Is ReportFinfoForm Then
                F.WindowState = FormWindowState.Normal
                F.TopMost = True
                F.TopMost = False
                Exit Sub
            End If
        Next
        With New ReportFinfoForm
            .Show()
        End With
    End Sub
End Class