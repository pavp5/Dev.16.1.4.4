''' <summary>
''' Поиск в архивной базе и БД № 5
''' </summary>
''' <remarks></remarks>
Public Class FindFForm

    Friend Sub New()
        InitializeComponent()
        Cprp.DxCommon.WaitForm.Show(Me)
        '
        ' FindUserControl
        '
        'With New Cprp.DxData.FindF.FindUserControl("Server=192.168.22.80;Database=FDB;Trusted_connection=Yes")
        '    .Dock = DockStyle.Fill
        '    .Parent = Me
        '    .Show()
        'End With
        'With New Cprp.DxData.FindA.FindUserControl("Server=192.168.22.80;Database=EXDBA;Trusted_connection=Yes")
        '    .Dock = DockStyle.Fill
        '    .Parent = Me
        '    .Show()
        'End With
        With New Cprp.DxData.Law.LawUserControl(Program.DbClient.Connection)
            .Dock = DockStyle.Fill
            .Parent = Me
            .Show()
        End With

        '
        ' Me
        '
        'Me.Icon = My.Resources.search_ico
        Me.Text = "Поиск"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

End Class