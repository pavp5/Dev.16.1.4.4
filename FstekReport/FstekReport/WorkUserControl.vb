Imports C2 = Cprp.DxData.Common
Imports CW = Cprp.DxData.Work
''' <summary>
''' Работа
''' </summary>
Friend Class WorkUserControl

    ''' <summary>
    ''' Элемент управления для отображения данных работы
    ''' </summary>
    Private _WorkControl As CW.Excont.WorkUserControl = Nothing

    ''' <summary>
    ''' ID работы
    ''' </summary>
    Friend ReadOnly Property WorkId As Object
        Get
            If _WorkControl Is Nothing Then Return Nothing
            If _WorkControl.Work Is Nothing OrElse _WorkControl.Work.IsEmpty Then Return Nothing
            Return _WorkControl.Work.Id
        End Get
    End Property

    Private _MenuItem As DevExpress.XtraBars.BarItem = Nothing
    ''' <summary>
    ''' Связанный пункт главного меню
    ''' </summary>
    Friend Property MenuItem As DevExpress.XtraBars.BarItem
        Get
            Return _MenuItem
        End Get
        Set(value As DevExpress.XtraBars.BarItem)
            _MenuItem = value
            If Not _WorkControl Is Nothing Then
                _MenuItem.Description = C2.ToText(_WorkControl.Work("description"))
            End If
        End Set
    End Property

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <remarks></remarks>
    Friend Sub New(workId As Object)
        InitializeComponent()
        _WorkControl = New CW.Excont.WorkUserControl(workId, Program.DbClient.Connection, Program.DbClient) With {.MainMenuVisible = False, .Dock = DockStyle.Fill, .Parent = MainPanelControl}
    End Sub


    ' Закрыть текущее окно с работой
    Private Sub WindowCloseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles WindowCloseBarButtonItem.ItemClick
        Program.MainForm.WorkClose(MyClass.WorkId)
    End Sub

End Class
