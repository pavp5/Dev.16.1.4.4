''' <summary>
''' Демо-версия формирования профиля компании
''' </summary>
''' <remarks>
''' Профиль заполняется путем поиска инфомации о компании с помощью api сайта "За честный бизнес"
''' </remarks>
Friend Class Program


    <STAThread()> _
    Friend Shared Sub Main()
        '
        ' Application
        '
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Cprp.DxCommon.Application.EnableAppSkins()
        Cprp.DxCommon.Application.AppName = "ЭксКонт"
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        Cprp.DxCommon.Application.AppSkinColor = Color.Aquamarine
        '
        ' MainForm
        '
        Application.Run(New MainForm)

    End Sub

End Class
