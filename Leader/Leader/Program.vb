Imports C2 = Cprp.DxData.Common
Friend Class Program

    ''' <summary>
    ''' Пользователь системы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Shared DbClient As Cprp.DxData.User.DatabaseUser = Nothing

    ''' <summary>
    ''' Таблица экспертов
    ''' </summary>
    Friend Shared ExpertTable As DataTable = Nothing

    ''' <summary>
    ''' Таблица руководителей
    ''' </summary>
    Friend Shared LeaderTable As DataTable = Nothing

    ''' <summary>
    ''' Таблица менеджеров
    ''' </summary>
    Friend Shared ManagerTable As DataTable = Nothing

    ''' <summary>
    ''' Главная форма приложения
    ''' </summary>
    Friend Shared MainForm As MainForm = Nothing

    ''' <summary>
    ''' Общий таймер
    ''' </summary>
    Friend Shared Timer As Timer = Nothing

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
        Dim objMutex As New System.Threading.Mutex(False, "ExcontLeader78")
        If objMutex.WaitOne(0, False) = False Then
            objMutex.Close()
            objMutex.Dispose()
            MsgBox("Программа уже запущена!", MsgBoxStyle.Critical, "Экспертиза")
            End
        End If
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
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        If Not (DbClient.IsLeader OrElse DbClient.IsChief OrElse DbClient.IsSubleader) Then
            Cprp.DxCommon.Messages.ShowError("У Вас отсутствуют права для запуска данной программы.")
            Exit Sub
        End If
        'DbClient = New Cprp.DxData.User.DatabaseUser(28, DbClient.Connection)
        '
        ' AppErrorTable 
        '
        AppErrorTable = New Cprp.DxData.ErrorDataTable( _
            DbClient.Connection, _
            String.Format("{0}\error.xml", Application.StartupPath), _
            DbClient.Id, _
            "Leader")
        AppErrorTable.DataSave()
        AppErrorTable.DataLoad()
        '
        ' ExpertTable
        '
        ExpertTable = New DataTable
        With ExpertTable.Columns
            .Add("id", GetType(Integer))
            .Add("nameShort", GetType(String))
            .Add("nameLong", GetType(String))
            .Add("expertDescription", GetType(String))
        End With
        ExpertTable.PrimaryKey = New DataColumn() {ExpertTable.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = DbClient.Connection}
            Cmd.CommandText = _
                "SELECT id, nameShort, nameLong, expertDescription FROM vUser " & _
                "WHERE isACT = 1 AND isExpert = 1"
            ExpertTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' LeaderTable
        '
        LeaderTable = New DataTable
        With LeaderTable.Columns
            .Add("id", GetType(Integer))
            .Add("nameShort", GetType(String))
            .Add("nameLong", GetType(String))
            .Add("leaderDescription", GetType(String))
        End With
        LeaderTable.PrimaryKey = New DataColumn() {LeaderTable.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = _
                "SELECT id, nameShort, nameLong, leaderDescription FROM vUser " & _
                "WHERE isACT = 1 AND isLeader = 1"
            LeaderTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' ManagerTable
        '
        ManagerTable = New DataTable
        With ManagerTable.Columns
            .Add("id", GetType(Integer))
            .Add("nameShort", GetType(String))
            .Add("nameLong", GetType(String))
            .Add("managerDescription", GetType(String))
        End With
        ManagerTable.PrimaryKey = New DataColumn() {ManagerTable.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = _
                "SELECT id, nameShort, nameLong, managerDescription FROM vUser " & _
                "WHERE isACT = 1 AND isManager = 1"
            ManagerTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' Timer
        '
        Timer = New Timer
        Timer.Interval = 60000
        Timer.Start()
        '
        ' MainForm, Run
        '
        MainForm = New MainForm
        Application.Run(MainForm)
    End Sub


    ''' <summary>
    ''' Отправить в ЭО сообщение об изменении работы
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Friend Shared Sub SendWorkChangeToEo(workId As Object)
        Dim Work As Cprp.DxData.Work.WorkConnectionRow = Nothing
        Select Case Cprp.DxData.Work.Common.GetWorkTypeById(workId, Program.DbClient.Connection)
            Case Cprp.DxData.Work.WorkType.IsExCont
                Work = New Cprp.DxData.Work.Excont.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case Cprp.DxData.Work.WorkType.IsCustomUnion
                Work = New Cprp.DxData.Work.Customs.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case Cprp.DxData.Work.WorkType.IsTnved
                Work = New Cprp.DxData.Work.Tnved.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case Cprp.DxData.Work.WorkType.IsLiconfirm
                Work = New Cprp.DxData.Work.Liconfirm.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case Cprp.DxData.Work.WorkType.IsConsultation
                Work = New Cprp.DxData.Work.Consultation.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case Cprp.DxData.Work.WorkType.IsMilitary
                Work = New Cprp.DxData.Work.Military.WorkConnectionRow(workId, Program.DbClient.Connection)
            Case Cprp.DxData.Work.WorkType.IsOrder
                Work = New Cprp.DxData.Work.Order.WorkConnectionRow(workId, Program.DbClient.Connection)

        End Select
        If Not Work Is Nothing Then
            Work.MessageWorkChangeEo()
            Work.Dispose()
        End If
    End Sub

End Class
