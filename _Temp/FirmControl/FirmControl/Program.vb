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
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        Cprp.DxCommon.Application.AppSkinColor = Color.Red
        Cprp.DxCommon.Application.AppName = "Перечень организаций"
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(False)
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then End
        If Not DbClient.IsLeader Then
            Cprp.DxCommon.Messages.ShowError("У Вас отсутствуют права для запуска данной программы.")
            End
        End If
        '
        ' Run
        '
        Application.Run(New MainForm)

    End Sub

End Class
