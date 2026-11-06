''' <summary>
''' Главная форма приложения
''' </summary>
Friend Class MainForm

    ''' <summary>
    ''' Элемент управления "Редактор новых данных"
    ''' </summary>
    Private NewDataControl As NewDataUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "Редактор данных из базы"
    ''' </summary>
    Private BaseDataControl As BaseDataUserControl = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' Me
        '
        Me.Icon = My.Resources.fontedit_ico
        Me.Text = "Редактор ключевых слов"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()

        NewDataBarCheckItem.Checked = True

    End Sub


    Private Sub NewDataBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles NewDataBarCheckItem.CheckedChanged
        If NewDataControl Is Nothing Then
            Cprp.DxCommon.WaitForm.Show(Me)
            NewDataControl = New NewDataUserControl(Program.DbClient.Connection) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            Cprp.DxCommon.WaitForm.Close()
        End If
        MainPanelControl.Controls.SetChildIndex(NewDataControl, 0)
    End Sub

    Private Sub BaseDataBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles BaseDataBarCheckItem.CheckedChanged
        If BaseDataControl Is Nothing Then
            Cprp.DxCommon.WaitForm.Show(Me)
            BaseDataControl = New BaseDataUserControl(Program.DbClient.Connection) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
            Cprp.DxCommon.WaitForm.Close()
        End If
        MainPanelControl.Controls.SetChildIndex(BaseDataControl, 0)
    End Sub

End Class