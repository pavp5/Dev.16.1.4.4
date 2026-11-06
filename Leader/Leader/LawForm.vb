''' <summary>
''' Нормативные документы
''' </summary>
Friend Class LawForm

    Friend Sub New()
        InitializeComponent()
        Cprp.DxCommon.WaitForm.Show(Me)
        '
        ' LawUserControl
        '
        With New Cprp.DxData.Law.LawUserControl(Program.DbClient.Connection)
            .Dock = DockStyle.Fill
            .Parent = Me
            .Show()
        End With
        '
        ' Me
        '
        Me.Icon = My.Resources.book_open_ico
        Me.Text = "Нормативные документы"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

End Class