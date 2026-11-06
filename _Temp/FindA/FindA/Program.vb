Imports C2 = Cprp.DxData.Common
Friend Class Program

    ''' <summary>
    ''' Открытое подключение к архивной базе данных
    ''' </summary>
    Friend Shared Connection As SqlConnection = Nothing


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
        Cprp.DxCommon.Application.AppName = "Поиск работ"
        '
        ' Connection
        '
        Connection = New SqlConnection("SERVER=192.168.22.80;Database=EXDBA;Trusted_connection=No;UID=excont_user;PWD=A123@123")
        Try
            Connection.Open()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка подключения к базе данных:{0}{1}", vbCrLf, ex.Message), "Поиск работ")
            Exit Sub
        End Try
        '
        ' Run
        '
        Application.Run(New MainForm)
    End Sub

End Class
