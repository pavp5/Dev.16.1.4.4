Friend Class Program

    Friend Shared DbClient As Cprp.DxData.User.DatabaseUser = Nothing

    Friend Shared AppErrorTable As Cprp.DxData.ErrorDataTable = Nothing

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
        'Cprp.DxCommon.Application.AppSkinColor = Color.Aquamarine
        ''
        '' SmtpClient
        ''
        'Dim ffrom As String = "system@excont.ru"
        'Dim tto As String = "puganov_p@excont.ru, pavp5@yandex.ru"
        'Using M As New System.Net.Mail.SmtpClient("192.168.22.165", 27)
        '    M.Send(ffrom, tto, "Тест", "Проверка связи")
        'End Using
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(True)
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        ''
        '' AppErrorTable 
        ''
        'AppErrorTable = New Cprp.DxData.ErrorDataTable(DbClient.Connection, "d:\error.xml", DbClient.Id, "Test")
        'AppErrorTable.DataSave()
        'AppErrorTable.DataLoad()
        '
        ' Dictionary
        '
        'Cprp.DxCommon.WaitForm.Show()
        'Cprp.DxDictionary.Common.LoadDictionary(Application.StartupPath)
        'Cprp.DxCommon.WaitForm.Close()
        'Application.Run(New DictionaryForm())
        '
        ' WorkForm
        ' 
        Application.Run(New WorkForm)
        '
        ' TestForm
        '
        'Application.Run(New TestForm)
        '
        ' ReportForm
        '
        'Application.Run(New ReportForm)

    End Sub

End Class
