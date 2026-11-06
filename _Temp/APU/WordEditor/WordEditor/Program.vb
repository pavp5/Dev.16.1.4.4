''' <summary>
''' Редактор ключевых слов из документов
''' </summary>
Friend Class Program

    ''' <summary>
    ''' Объект для работы с базой данных
    ''' </summary>
    Friend Shared DbClient As Cprp.DxData.User.DatabaseUser = Nothing


    <STAThread()> _
    Friend Shared Sub Main()
        '
        ' Application
        '
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Cprp.DxCommon.Application.EnableAppSkins()
        Cprp.DxCommon.Application.AppName = "Редактор"
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        Cprp.DxCommon.Application.AppSkinColor = Color.Aquamarine
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(True)
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        '
        ' Run
        '
        Application.Run(New MainForm)

    End Sub

End Class
