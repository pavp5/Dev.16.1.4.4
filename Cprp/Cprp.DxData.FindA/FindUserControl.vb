''' <summary>
''' Элемент управления "Поиск работ"
''' </summary>
Public Class FindUserControl

    ''' <summary>
    ''' Открытое подключение к архивной базе данных
    ''' </summary>
    Friend Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Элемент управления "Условия поиска"
    ''' </summary>
    Private WithEvents ConditionControl As ConditionUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "Результаты поиска"
    ''' </summary>
    Private WithEvents ResultControl As ResultUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "Работа"
    ''' </summary>
    Private WorkControl As WorkUserControl = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к архивной базе данных</param>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        Me.Connection = Connection
    End Sub

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="connectionString">Строка подключения к архивной базе данных</param>
    Public Sub New(connectionString As String)
        InitializeComponent()
        Connection = New SqlConnection(connectionString)
        Try
            Connection.Open()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка подключения к базе данных:{0}{1}", vbCrLf, ex.Message), "Поиск работ")
        End Try
    End Sub


    Private Sub FindUserControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        ConditionControl = New ConditionUserControl(Connection) With {.Dock = DockStyle.Fill}
        MainPanelControl.Controls.Add(ConditionControl)
        ResultControl = New ResultUserControl(Connection) With {.Dock = DockStyle.Fill}
        MainPanelControl.Controls.Add(ResultControl)
        WorkControl = New WorkUserControl(Connection) With {.Dock = DockStyle.Fill}
        MainPanelControl.Controls.Add(WorkControl)
        MainWindowsUIButtonPanel.Buttons("УСЛОВИЯ").Properties.Checked = True
    End Sub

    Private Sub MainWindowsUIButtonPanel_ButtonChecked(sender As Object, e As DevExpress.XtraBars.Docking2010.ButtonEventArgs) Handles MainWindowsUIButtonPanel.ButtonChecked
        If e.Button.Properties.Caption.ToUpper Like "УСЛОВИЯ" Then
            MainWindowsUIButtonPanel.Buttons("РЕЗУЛЬТАТЫ").Properties.Checked = False
            MainPanelControl.Controls.SetChildIndex(ConditionControl, 0)
        Else
            MainWindowsUIButtonPanel.Buttons("УСЛОВИЯ").Properties.Checked = False
            MainPanelControl.Controls.SetChildIndex(ResultControl, 0)
        End If
    End Sub

    ' Начать поиск
    Private Sub ConditionControl_FindStart(queryString As String) Handles ConditionControl.FindStart
        ResultControl.SetFind(queryString)
        MainWindowsUIButtonPanel.Buttons("РЕЗУЛЬТАТЫ").Properties.Checked = True
    End Sub

    ' Открыть работу
    Private Sub ResultControl_WorkOpen(id As Integer, workId As Integer) Handles ResultControl.WorkOpen
        If TypeOf Me.ParentForm Is Cprp.DxData.Work.IParentForm Then
            If CType(Me.ParentForm, Cprp.DxData.Work.IParentForm).ChildOpen(workId) Then Exit Sub
        End If

        WorkControl.WorkId = id
        MainPanelControl.Controls.SetChildIndex(WorkControl, 0)
        With MainWindowsUIButtonPanel
            .Buttons("УСЛОВИЯ").Properties.Checked = False
            .Buttons("РЕЗУЛЬТАТЫ").Properties.Checked = False
        End With
    End Sub

End Class
