Friend Class Program

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
        Cprp.DxCommon.Application.AppName = "Отчеты ЭС"
        '
        ' Run
        '
        Application.Run(New MainForm)

    End Sub

End Class
