Friend Class Program

    ''' <summary>
    ''' Пользователь системы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared DbClient As Cprp.DxData.User.DatabaseUser = Nothing

    ''' <summary>
    ''' Источник данных отчета
    ''' </summary>
    Friend Shared DS As ReportDataSet = Nothing

    ''' <summary>
    ''' Главная форма приложения
    ''' </summary>
    Friend Shared MainForm As MainForm = Nothing


    <STAThread()> _
    Friend Shared Sub Main()
        '
        ' Application
        '
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Cprp.DxCommon.Application.EnableAppSkins()
        Cprp.DxCommon.Application.AppName = "Отчет"
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        Cprp.DxCommon.Application.AppSkinColor = Color.Aquamarine
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(True)
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        '
        ' DS
        '
        DS = New ReportDataSet(DbClient.Connection)
        '
        ' MainForm
        '
        MainForm = New MainForm
        '
        ' Run
        '
        Application.Run(MainForm)
        'Application.Run(New TestForm)
    End Sub

End Class
