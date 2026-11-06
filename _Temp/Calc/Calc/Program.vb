Friend Class Program

    ''' <summary>
    ''' Пользователь
    ''' </summary>
    Friend Shared DbClient As Cprp.DxData.User.DatabaseUser = Nothing

    ''' <summary>
    ''' Калькулятор
    ''' </summary>
    Friend Shared Calc As Cprp.DxData.Calc.Calc = Nothing


    <STAThread()> _
    Friend Shared Sub Main()
        '
        ' Application
        '
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Cprp.DxCommon.Application.EnableAppSkins()
        Cprp.DxCommon.Application.AppName = "Калькулятор"
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        Cprp.DxCommon.Application.AppSkinColor = Color.Aquamarine
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(False)
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        '
        ' Calc
        '
        Calc = New Cprp.DxData.Calc.Calc(Program.DbClient.Connection)
        '
        ' Run
        '
        Application.Run(New CalcForm)

    End Sub

End Class
