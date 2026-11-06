Friend Class MainForm

    ' Controls
    Private ResourceControl As ResourceUserControl = Nothing            ' Ресурсы
    Private UsersControl As UsersUserControl = Nothing                  ' Пользователи
    Private EndDocumentControl As EndDocumentUserControl = Nothing      ' Заключения
    Private TnvedControl As TnvedUserControl = Nothing                  ' Товарная номенклатура
    Private ControlControl As ControlUserControl = Nothing              ' Нормативные документы
    Private EmbargoControl As Embargo.EmbargoUserControl = Nothing      ' Запреты и ограничения
    Private FInfoControl As FInfo.FInfoUserControl = Nothing            ' Информация ФСТЭК по заключениям жкспертизы
    Private CountryControl As CountryUserControl = Nothing              ' Страны мира


    Friend Sub New()
        InitializeComponent()
        '
        ' MainPanelControl
        '
        MainPanelControl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        ' Me
        '
        Me.Icon = My.Resources.tools_ico
        Me.Text = String.Format("Администрирование [{0}]", Program.DbClient.Connection.ConnectionString)
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
    End Sub

    Private Sub ResourceBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ResourceBarButtonItem.ItemClick
        If ResourceControl Is Nothing Then
            ResourceControl = New ResourceUserControl With {.Dock = DockStyle.Fill}
            MainPanelControl.Controls.Add(ResourceControl)
        End If
        MainMenuBarButtonItem.DropDownControl = ResourceControl.MainPopupMenu
        ResourceControl.BringToFront()
    End Sub

    Private Sub UsersBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles UsersBarButtonItem.ItemClick
        If UsersControl Is Nothing Then
            UsersControl = New UsersUserControl With {.Dock = DockStyle.Fill}
            MainPanelControl.Controls.Add(UsersControl)
        End If
        MainMenuBarButtonItem.DropDownControl = Nothing
        UsersControl.BringToFront()
    End Sub

    Private Sub EndDocumentBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles EndDocumentBarButtonItem.ItemClick
        If EndDocumentControl Is Nothing Then
            EndDocumentControl = New EndDocumentUserControl With {.Dock = DockStyle.Fill}
            MainPanelControl.Controls.Add(EndDocumentControl)
        End If
        MainMenuBarButtonItem.DropDownControl = Nothing
        EndDocumentControl.BringToFront()
    End Sub

    Private Sub TnvedBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles TnvedBarButtonItem.ItemClick
        If TnvedControl Is Nothing Then
            TnvedControl = New TnvedUserControl With {.Dock = DockStyle.Fill}
            MainPanelControl.Controls.Add(TnvedControl)
        End If
        MainMenuBarButtonItem.DropDownControl = TnvedControl.MainPopupMenu
        TnvedControl.BringToFront()
    End Sub

    Private Sub ControlBarButtonItem_ItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs) Handles ControlBarButtonItem.ItemClick
        If ControlControl Is Nothing Then
            ControlControl = New ControlUserControl With {.Dock = DockStyle.Fill}
            MainPanelControl.Controls.Add(ControlControl)
        End If
        MainMenuBarButtonItem.DropDownControl = ControlControl.MainPopupMenu
        ControlControl.BringToFront()
    End Sub

    Private Sub EmbargoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EmbargoBarButtonItem.ItemClick
        If EmbargoControl Is Nothing Then
            EmbargoControl = New Embargo.EmbargoUserControl(Program.DbClient.Connection) With {.Dock = DockStyle.Fill}
            MainPanelControl.Controls.Add(EmbargoControl)
        End If
        MainMenuBarButtonItem.DropDownControl = EmbargoControl.MainPopupMenu
        EmbargoControl.BringToFront()
    End Sub

    Private Sub FInfoBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FInfoBarButtonItem.ItemClick
        If FInfoControl Is Nothing Then
            FInfoControl = New FInfo.FInfoUserControl(Program.DbClient.Connection) With {.Dock = DockStyle.Fill}
            MainPanelControl.Controls.Add(FInfoControl)
        End If
        MainMenuBarButtonItem.DropDownControl = FInfoControl.MainPopupMenu
        FInfoControl.BringToFront()
    End Sub

    Private Sub CountryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CountryBarButtonItem.ItemClick
        If CountryControl Is Nothing Then
            CountryControl = New CountryUserControl With {.Dock = DockStyle.Fill}
            MainPanelControl.Controls.Add(CountryControl)
        End If
        MainMenuBarButtonItem.DropDownControl = CountryControl.MainPopupMenu
        CountryControl.BringToFront()
    End Sub

End Class