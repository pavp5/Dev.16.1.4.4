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
        Cprp.DxCommon.Application.AppName = "Экспертиза"
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        'Cprp.DxCommon.Application.AppSkinColor = Color.Aquamarine
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(True)
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        If Not DbClient.IsACT Then
            Cprp.DxCommon.Messages.ShowError("Ваша учетная запись отключена. Обратитесь к администратору системы.")
            Exit Sub
        End If
        If Not DbClient.IsAdmin Then
            Cprp.DxCommon.Messages.ShowError("У Вас отсутствуют права для запуска данной программы.")
            Exit Sub
        End If
        '
        ' Run
        '
        Application.Run(New EditForm)

    End Sub

End Class
