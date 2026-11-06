''' <summary>
''' Главная форма приложения
''' </summary>
Friend Class MainForm

#Region "EXDBA_Connection"

    ''' <summary>
    ''' Подключение к базе данных EXDBA
    ''' </summary>
    Private _EXDBA_Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Открытое подключение к базе данных EXDBA
    ''' </summary>
    Private ReadOnly Property EXDBA_Connection As SqlConnection
        Get
            If _EXDBA_Connection Is Nothing Then
                '_EXDBA_Connection = New SqlConnection("Server=192.168.22.80;Database=EXDBA;Trusted_connection=Yes")
                _EXDBA_Connection = New SqlConnection("Server=192.168.22.80;Database=EXDBA;UID=excont_user;PWD=A123@123")
            End If
            Try
                If _EXDBA_Connection.State <> ConnectionState.Open Then _EXDBA_Connection.Open()
            Catch ex As Exception
                Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка подключения к базе данных:{0}{1}", vbCrLf, ex.Message))
            End Try
            Return _EXDBA_Connection
        End Get
    End Property

#End Region
#Region "EXDB8_Connection"

    ''' <summary>
    ''' Подключение к базе данных EXDB8
    ''' </summary>
    Private _EXDB8_Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Открытое подключение к базе данных EXDB8
    ''' </summary>
    Private ReadOnly Property EXDB8_Connection As SqlConnection
        Get
            If _EXDB8_Connection Is Nothing Then
                '_EXDB8_Connection = New SqlConnection("Server=192.168.22.80;Database=EXDB8;Trusted_connection=Yes")
                _EXDB8_Connection = New SqlConnection("Server=192.168.22.80;Database=EXDB8;UID=excont_user;PWD=A123@123")
            End If
            Try
                If _EXDB8_Connection.State <> ConnectionState.Open Then _EXDB8_Connection.Open()
            Catch ex As Exception
                Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка подключения к базе данных:{0}{1}", vbCrLf, ex.Message))
            End Try
            Return _EXDB8_Connection
        End Get
    End Property

#End Region

    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        InitializeComponent()
        '
        ' Me
        '
        Me.Icon = My.Resources.stat_ico
        Me.Text = "Отчеты"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

    End Sub

    ' Экспертные организации
    Private Sub BarButtonItem1_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles EXpertOrgBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is ExpertOrg.ReportUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New ExpertOrg.ReportUserControl(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Экспертные организации"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Заказы по регионам
    Private Sub RegionBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles RegionBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Region.ReportUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New Region.ReportUserControl(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Заказы по регионам"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Поставки по странам
    Private Sub CountryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles CountryBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Country.ReportUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New Country.ReportUserControl(EXDBA_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Поставки по странам"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Не закрытые работы
    Private Sub WorkAcceptBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkAcceptBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is WorkAcceptUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New WorkAcceptUserControl(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Не закрытые работы"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Заказчики услуг
    Private Sub ClientBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ClientBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Client.ReportUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New Client.ReportUserControl(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Заказчики услуг"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Стоимости работ
    Private Sub WorkPriceBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkPriceBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is WorkPrice.ReportUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New WorkPrice.ReportUserControl(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Сравнительные стоимости"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Заказчики за период
    Private Sub OrderBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OrderBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is Order.ReportUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New Order.ReportUserControl(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Заказчики за период"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Стоимости за период
    Private Sub BarButtonItem1_ItemClick_1(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BarButtonItem1.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is WorkPrice.ReportUserControl1 Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New WorkPrice.ReportUserControl1(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Стоимости за период"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Работы за период
    Private Sub WorkCloseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkCloseBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is WorkClose.ReportUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New WorkClose.ReportUserControl(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Работы за период"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Внесения изменений за период
    Private Sub WorkBackBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkBackBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        For Each P In TabFormControl.Pages
            If P.ContentContainer.Controls.Count = 0 Then Continue For
            If Not TypeOf P.ContentContainer Is WorkBack.ReportUserControl Then Continue For
            TabFormControl.SelectedPage = P
            Exit Sub
        Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New WorkBack.ReportUserControl(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Внесения ихменений"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

    ' Поиск товаров
    Private Sub FindGoodBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindGoodBarButtonItem.ItemClick
        Dim P As DevExpress.XtraBars.TabFormPage = Nothing
        'For Each P In TabFormControl.Pages
        '    If P.ContentContainer.Controls.Count = 0 Then Continue For
        '    If Not TypeOf P.ContentContainer Is FindGood.ReportUserControl Then Continue For
        '    TabFormControl.SelectedPage = P
        '    Exit Sub
        'Next
        P = New DevExpress.XtraBars.TabFormPage
        P.ContentContainer = New FindGood.ReportUserControl(EXDB8_Connection) With {.Dock = DockStyle.Fill}
        P.Text = "Поиск товаров"
        TabFormControl.Pages.Add(P)
        TabFormControl.SelectedPage = P
    End Sub

End Class