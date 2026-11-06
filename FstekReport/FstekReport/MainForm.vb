Imports C2 = Cprp.DxData.Common
''' <summary>
''' Главная форма приложения
''' </summary>
Friend Class MainForm

    ' Отчет
    Private ReportControl As ReportUserControl = Nothing

    ' Справочники
    Private HandbookControl As HandbookUserControl = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' ReportControl
        '
        ReportControl = New ReportUserControl With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        '
        ' HandbookControl
        '
        HandbookControl = New HandbookUserControl With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        '
        ' Me
        '
        Me.Icon = My.Resources.report_ico
        Me.Text = "Отчет в ФСТЭК"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
        '
        ' Отчет
        '
        ReportBarCheckItem.PerformClick()
    End Sub


    ''' <summary>
    ''' Открыть работу
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <remarks></remarks>
    Friend Sub WorkOpen(workId As Object)
        If Not Cprp.DxData.Work.Common.WorkExist(workId, Program.DbClient.Connection) Then Exit Sub
        '
        ' Проверка наличия открытой работы
        '
        For Each Item As DevExpress.XtraBars.BarCheckItemLink In WorkBarSubItem.ItemLinks
            If CInt(Item.Item.Tag) = CInt(workId) Then
                Item.Item.PerformClick()
                Exit Sub
            End If
        Next
        '
        ' Создание нового пункта меню "Работа" 
        '
        Dim NewItem = New DevExpress.XtraBars.BarCheckItem
        NewItem.Caption = C2.ToText(workId)
        NewItem.Tag = C2.ToInt(workId)
        NewItem.LargeGlyph = My.Resources.gear
        NewItem.GroupIndex = 1
        AddHandler NewItem.ItemClick, AddressOf WorkItemClick
        WorkBarSubItem.AddItem(NewItem)
        '
        ' Открытие работы
        '
        NewItem.PerformClick()
    End Sub

    ''' <summary>
    ''' Закрыть работу
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <remarks></remarks>
    Friend Sub WorkClose(workId As Object)
        Dim wId As Integer = C2.ToInt(workId)
        '
        ' Удаление пункта в меню "Работа"
        '
        For Each Item As DevExpress.XtraBars.BarCheckItemLink In WorkBarSubItem.ItemLinks
            If CInt(Item.Item.Tag) = wId Then
                Item.Item.Dispose()
                Item.Dispose()
                Exit For
            End If
        Next
        '
        ' Удаление элемента управления с данными работы
        '
        For Each C As Control In MainPanelControl.Controls
            If Not TypeOf C Is WorkUserControl Then Continue For
            If CInt(CType(C, WorkUserControl).WorkId) <> wId Then Continue For
            C.Dispose()
            Exit For
        Next
        '
        ' Переход к отчету
        '
        ReportBarCheckItem.PerformClick()
    End Sub

    ''' <summary>
    ''' Открыть работу из меню "Работа"
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub WorkItemClick(ByVal sender As System.Object, ByVal e As DevExpress.XtraBars.ItemClickEventArgs)
        Dim wId As Integer = C2.ToInt(e.Item.Tag)
        Dim WorkControl As WorkUserControl = Nothing
        '
        ' Поиск элемента управления с данными работы
        '
        For Each C As Control In MainPanelControl.Controls
            If Not TypeOf C Is WorkUserControl Then Continue For
            If C2.ToInt(CType(C, WorkUserControl).WorkId) <> wId Then Continue For
            WorkControl = C
            Exit For
        Next
        '
        ' Создание нового элемента управления с данными работы
        '
        If WorkControl Is Nothing Then
            WorkControl = New WorkUserControl(wId) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            WorkControl.MenuItem = e.Item
        End If
        '
        ' Открытие работы
        '
        MainPanelControl.Controls.SetChildIndex(WorkControl, 0)
        Me.Text = String.Format("Отчет в ФСТЭК - Работа № {0}", wId)
    End Sub

    ' Открыть отчет
    Private Sub ReportBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportBarCheckItem.CheckedChanged
        MainPanelControl.Controls.SetChildIndex(ReportControl, 0)
        Me.Text = "Отчет в ФСТЭК"
    End Sub

    ' Открыть справочники
    Private Sub HandbookBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles HandbookBarCheckItem.CheckedChanged
        MainPanelControl.Controls.SetChildIndex(HandbookControl, 0)
        Me.Text = "Отчет в ФСТЭК - Справочники"
    End Sub

    ' Указать путь к корневой папке файлов отчетов
    Private Sub MainForm_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Alt AndAlso e.Control AndAlso e.KeyCode = Keys.R Then
            Using Dlg As New FolderBrowserDialog
                Dlg.Description = "Укажите путь к корневой папке файлов отчетов"
                Dlg.SelectedPath = My.Settings.RootReportFolder
                If Dlg.ShowDialog = DialogResult.OK Then My.Settings.RootReportFolder = Dlg.SelectedPath
            End Using
        End If
    End Sub

End Class