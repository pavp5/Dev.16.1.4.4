Imports C2 = Cprp.DxData.Common
Friend Class Program

    ''' <summary>
    ''' Пользователь системы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared DbClient As Cprp.DxData.User.DatabaseUser = Nothing


    Private Sub New()
    End Sub

    <STAThread()> _
    Friend Shared Sub Main()
        '
        ' Application
        '
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Cprp.DxCommon.Application.EnableAppSkins()
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        Cprp.DxCommon.Application.AppName = "HS ТНВЭД"
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(False)
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        '
        ' Run
        '
        Application.Run(New MainForm)
    End Sub

End Class
