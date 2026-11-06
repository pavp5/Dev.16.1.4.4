Imports C2 = Cprp.DxData.Common
Friend Class Program

    ''' <summary>
    ''' Пользователь системы
    ''' </summary>
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
        DevExpress.UserSkins.BonusSkins.Register()
        Cprp.DxCommon.Application.AppSkinName = "Metropolis Dark"
        Cprp.DxCommon.Application.AppName = "Экспертные организации"
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(False)
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then End
        'If Not DbClient.IsLeader Then
        '    Cprp.DxCommon.Messages.ShowError("У Вас отсутствуют права для запуска данной программы.")
        '    End
        'End If
        '
        ' MainForm
        '
        Application.Run(New MainForm)


    End Sub

End Class
