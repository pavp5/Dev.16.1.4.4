''' <summary>
''' Элемент управления для поиска в архивной базе данных
''' </summary>
''' <remarks></remarks>
Public Class FindUserControl0

    ' Открытое соединение с архивной базой данных
    Private _Connection As SqlConnection

    ' Критерии поиска
    Private WithEvents _FindConditionControl As FindConditionUserControl0 = Nothing

    ' Результаты поиска
    Private WithEvents _FindResultControl As FindResultUserControl0 = Nothing

    ' Сведения о работе
    Private _WorkControl As WorkUserControl0 = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с архивной базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(Connection As SqlConnection)
        InitializeComponent()
        _Connection = Connection
        _FindConditionControl = New FindConditionUserControl0(_Connection) With {.Dock = DockStyle.Fill}
        _FindResultControl = New FindResultUserControl0(_Connection) With {.Dock = DockStyle.Fill}
        _WorkControl = New WorkUserControl0(_Connection) With {.Dock = DockStyle.Fill}
        Me.Controls.AddRange(New Control() {_FindConditionControl, _FindResultControl, _WorkControl})
    End Sub

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="ConnectionString">Строка подключения к архивной базе данных</param>
    ''' <remarks></remarks>
    Public Sub New(ConnectionString As String)
        InitializeComponent()
        _Connection = New SqlConnection(ConnectionString)
        Try
            _Connection.Open()
        Catch ex As Exception
            Throw ex
        End Try
        _FindConditionControl = New FindConditionUserControl0(_Connection) With {.Dock = DockStyle.Fill}
        _FindResultControl = New FindResultUserControl0(_Connection) With {.Dock = DockStyle.Fill}
        _WorkControl = New WorkUserControl0(_Connection) With {.Dock = DockStyle.Fill}
        Me.Controls.AddRange(New Control() {_FindConditionControl, _FindResultControl, _WorkControl})
    End Sub

    Private Sub FindUserControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        FindConditionBarCheckItem.Checked = True
        FindResultBarCheckItem.Enabled = False
        WorkBarCheckItem.Enabled = False
    End Sub

    ' Открыть критерии поиска
    Private Sub FindConditionBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindConditionBarCheckItem.CheckedChanged
        If FindConditionBarCheckItem.Checked Then _FindConditionControl.BringToFront()
    End Sub

    ' Открыть результаты поиска
    Private Sub FindResultBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles FindResultBarCheckItem.CheckedChanged
        If FindResultBarCheckItem.Checked Then _FindResultControl.BringToFront()
    End Sub

    ' Открыть сведения о работе
    Private Sub WorkBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WorkBarCheckItem.CheckedChanged
        If Not WorkBarCheckItem.Checked Then Exit Sub
        _WorkControl.WorkId = _FindResultControl.WorkId
        _WorkControl.BringToFront()
    End Sub

    ' Начать поиск в базе данных
    Private Sub _FindConditionControl_FindStart(QueryString As String) Handles _FindConditionControl.FindStart
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            _FindResultControl.SetFind(QueryString)
            FindResultBarCheckItem.Enabled = (_FindResultControl.FindCount > 0)
            WorkBarCheckItem.Enabled = FindResultBarCheckItem.Enabled
            If FindResultBarCheckItem.Enabled Then FindResultBarCheckItem.Checked = True
            Cprp.DxCommon.WaitForm.Close()
            If Not FindResultBarCheckItem.Enabled Then
                Cprp.DxCommon.Messages.ShowInformation("По указанным критериям поиска ничего не найдено", "Поиск")
            End If
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выборки данных:{0}{1}", vbCrLf, ex.Message), "Поиск")
        Finally
            FindResultBarCheckItem.Caption = String.Format("РЕЗУЛЬТАТЫ ПОИСКА ({0})", _FindResultControl.FindCount)
        End Try
    End Sub

    ' Открыть сведения о работе
    Private Sub _FindResultControl_OpenWork() Handles _FindResultControl.OpenWork
        WorkBarCheckItem.Checked = True
    End Sub

End Class
