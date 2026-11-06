Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления для поиска в БД № 5
''' </summary>
''' <remarks></remarks>
Public Class FindUserControl

    ''' <summary>
    ''' Открытое подключение к базе данных
    ''' </summary>
    ''' <remarks></remarks>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Элемент управления "Критерии поиска"
    ''' </summary>
    Private WithEvents ConditionControl As ConditionUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "Результаты поиска"
    ''' </summary>
    Private WithEvents ResultControl As ResultUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "Справка о заключении"
    ''' </summary>
    Private ReferenceControl As ReferenceUserControl = Nothing


    ''' <summary>
    ''' Элемент управления "Отчет по экспертным организациям"
    ''' </summary>
    Private ReportOrgControl As ReportOrgUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "Отчет по странам"
    ''' </summary>
    Private ReportCountryControl As ReportCountryUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "Сводный отчет по экспертным организациям, странам и товарам"
    ''' </summary>
    Private ReportSummaryControl As ReportSummaryUserControl = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных</param>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        Me.Connection = Connection
        If Me.Connection Is Nothing OrElse Me.Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        '
        ' Элементы управления
        '
        ConditionControl = New ConditionUserControl(Connection) With {.Dock = DockStyle.Fill}
        ResultControl = New ResultUserControl(Connection) With {.Dock = DockStyle.Fill}
        ReferenceControl = New ReferenceUserControl(Connection) With {.Dock = DockStyle.Fill}
        Me.MainPanelControl.Controls.AddRange(New Control() {ConditionControl, ResultControl, ReferenceControl})

        ConditionBarButtonItem.PerformClick()

    End Sub

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="connectionString">Строка подключения к базе данных</param>
    ''' <remarks></remarks>
    Public Sub New(connectionString As String)
        InitializeComponent()
        '
        ' Connection
        '
        Me.Connection = New SqlConnection(connectionString)
        Try
            Connection.Open()
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка подключения к базе данных:{0}{1}", vbCrLf, ex.Message))
            Me.Enabled = False
            Exit Sub
        End Try
        '
        ' Элементы управления поиска
        '
        ConditionControl = New ConditionUserControl(Connection) With {.Dock = DockStyle.Fill}
        ResultControl = New ResultUserControl(Connection) With {.Dock = DockStyle.Fill}
        ReferenceControl = New ReferenceUserControl(Connection) With {.Dock = DockStyle.Fill}
        Me.MainPanelControl.Controls.AddRange(New Control() {ConditionControl, ResultControl, ReferenceControl})

        ConditionBarButtonItem.PerformClick()
    End Sub

    Private Sub ConditionBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ConditionBarButtonItem.ItemClick
        MainPanelControl.Controls.SetChildIndex(ConditionControl, 0)
    End Sub

    Private Sub ResultBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ResultBarButtonItem.ItemClick
        MainPanelControl.Controls.SetChildIndex(ResultControl, 0)
    End Sub

    Private Sub ReferenceBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReferenceBarButtonItem.ItemClick
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        ReferenceControl.DocId = ResultControl.DocId
        Cprp.DxCommon.WaitForm.Close()
        MainPanelControl.Controls.SetChildIndex(ReferenceControl, 0)
    End Sub

    ''' <summary>
    ''' Начать поиск
    ''' </summary>
    ''' <param name="QueryString">Строка запроса на выборку данных</param>
    Private Sub ConditionControl_FindStart(QueryString As String) Handles ConditionControl.FindStart
        If Not C2.IsText(QueryString) Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.Parent)
        ResultControl.Find(QueryString)
        Cprp.DxCommon.WaitForm.Close()
        Dim i As Integer = ResultControl.DocCount
        ResultBarButtonItem.Caption = String.Format("РЕЗУЛЬТАТЫ ПОИСКА ({0})", i)
        If i = 0 Then
            Cprp.DxCommon.Messages.ShowWarning("По заданным критериям поиска нечего не найдено.", "Поиск")
        Else
            ResultBarButtonItem.PerformClick()
        End If
    End Sub

    ' Открыть справку о заключении
    Private Sub ResultControl_ReferenceOpen() Handles ResultControl.ReferenceOpen
        ReferenceBarButtonItem.PerformClick()
    End Sub


    ' Отчет по экспертным организациям
    Private Sub ReportOrgBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportOrgBarButtonItem.ItemClick
        If ReportOrgControl Is Nothing Then
            ReportOrgControl = New ReportOrgUserControl(Connection) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        End If
        MainPanelControl.Controls.SetChildIndex(ReportOrgControl, 0)
    End Sub

    ' Отчет по странам
    Private Sub ReportCountryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportCountryBarButtonItem.ItemClick
        If ReportCountryControl Is Nothing Then
            ReportCountryControl = New ReportCountryUserControl(Connection) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        End If
        MainPanelControl.Controls.SetChildIndex(ReportCountryControl, 0)
    End Sub

    ' Сводный отчет по экспертным организациям, странам и товарам
    Private Sub ReportSummaryBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReportSummaryBarButtonItem.ItemClick
        If ReportSummaryControl Is Nothing Then
            ReportSummaryControl = New ReportSummaryUserControl(Connection) With {.Dock = DockStyle.Fill, .Parent = MainPanelControl}
        End If
        MainPanelControl.Controls.SetChildIndex(ReportSummaryControl, 0)
    End Sub

End Class
