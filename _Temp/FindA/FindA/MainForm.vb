Friend Class MainForm


    Friend Sub New()
        InitializeComponent()
        Me.Controls.Add(New Cprp.DxData.FindA.FindUserControl(Program.Connection) With {.Dock = DockStyle.Fill})
        Me.Icon = My.Resources.database_find_ico
        Me.Text = "Поиск работ"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
    End Sub

End Class