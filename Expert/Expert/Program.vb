Imports C2 = Cprp.DxData.Common
Friend Class Program

    ''' <summary>
    ''' Пользователь системы
    ''' </summary>
    Friend Shared DbClient As Cprp.DxData.User.DatabaseUser = Nothing

    ''' <summary>
    ''' Главная форма приложения
    ''' </summary>
    Friend Shared MainForm As MainForm = Nothing

    ''' <summary>
    ''' Общая таблица сведений о сбоях
    ''' </summary>
    Friend Shared AppErrorTable As Cprp.DxData.ErrorDataTable = Nothing


    Private Sub New()
    End Sub


    <STAThread()> _
    Friend Shared Sub Main()
        '
        ' Проверка наличия запущенного приложения
        '
        'Dim objMutex = New System.Threading.Mutex(False, "ExcontExpert78")
        'If objMutex.WaitOne(0, False) = False Then
        '    objMutex.Close()
        '    objMutex = Nothing
        '    MsgBox("Программа уже запущена!", MsgBoxStyle.Critical, "Экспертиза")
        '    End
        'End If
        '
        ' Application
        '
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Cprp.DxCommon.Application.EnableAppSkins()
        Cprp.DxCommon.Application.AppSkinName = "A_Office 2016 Colorful"
        Cprp.DxCommon.Application.AppName = "Экспертиза"
        '
        ' DbClient
        '
        DbClient = New Cprp.DxData.User.DatabaseUser(False)
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then End
        If Not DbClient.IsExpert Then
            Cprp.DxCommon.Messages.ShowError("У Вас отсутствуют права для запуска данной программы.")
            End
        End If
        '
        ' AppErrorTable 
        '
        AppErrorTable = New Cprp.DxData.ErrorDataTable( _
            DbClient.Connection, _
            String.Format("{0}\error.xml", Application.StartupPath), _
            DbClient.Id, _
            "Expert")
        AppErrorTable.DataSave()
        AppErrorTable.DataLoad()
        '
        ' Dictionary
        '
        Cprp.DxCommon.WaitForm.Show()
        Cprp.DxDictionary.Common.LoadDictionary(Application.StartupPath)
        Cprp.DxCommon.WaitForm.Close()
        '
        ' MainForm, Run
        '
        MainForm = New MainForm
        Application.Run(MainForm)
    End Sub

End Class
