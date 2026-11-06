''' <summary>
''' Поиск в БД № 5
''' </summary>
''' <remarks></remarks>
Public Class FindFForm

    Friend Sub New()
        InitializeComponent()
        Cprp.DxCommon.WaitForm.Show(Me)
        '
        ' FindUserControl
        '
        Dim sTmp As String = Cprp.DxData.Resource.Resource.GetStrData("FDBCONNECTION", Program.DbClient.Connection)
        With New Cprp.DxData.FindF.FindUserControl(sTmp)
            .Dock = DockStyle.Fill
            .Parent = Me
            .Show()
        End With
        '
        ' Me
        '
        Me.Icon = My.Resources.search_ico
        Me.Text = "Поиск в БД №5"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

End Class