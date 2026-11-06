Friend Class Program

    Friend Shared DbClient As Cprp.DxData.User.DatabaseUser

    Private Sub New()
    End Sub

    <STAThread()> _
    Friend Shared Sub Main()
        '
        ' Application
        '
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(True)
        Cprp.DxCommon.Application.EnableAppSkins()
        Cprp.DxCommon.Application.AppName = "Администрирование"
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(True)
        If Not DbClient.IsACT Then Exit Sub
        If Not DbClient.IsAdmin Then
            Cprp.DxCommon.Messages.ShowError("У Вас отсутствуют права для запуска данной программы.", "Администрирование")
            Exit Sub
        End If
        '
        ' Run
        '
        Application.Run(New MainForm())
        'Application.Run(New Form2)

    End Sub

End Class
