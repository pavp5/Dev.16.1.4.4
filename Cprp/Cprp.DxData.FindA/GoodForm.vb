''' <summary>
''' Форма сведений об объекте экспертизы
''' </summary>
''' <remarks></remarks>
Friend Class GoodForm

    Private _goodId As Integer = -1
    Friend ReadOnly Property GoodId As Integer
        Get
            Return _goodId
        End Get
    End Property

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="GoodRow">Строка таблицы объектов экспертизы</param>
    ''' <remarks></remarks>
    Friend Sub New(ByVal GoodRow As DataRow)
        InitializeComponent()
        '
        ' Данные
        '
        If GoodRow Is Nothing Then Exit Sub
        _goodId = CInt(GoodRow("id"))
        NameConTextEdit.Text = GoodRow("nameCon").ToString
        NameDecTextEdit.Text = GoodRow("nameDec").ToString
        TnvedTextEdit.Text = GoodRow("tnved").ToString
        AreaMemoEdit.Text = GoodRow("area").ToString
        UsedMemoEdit.Text = GoodRow("used").ToString
        DescriptionMemoEdit.Text = GoodRow("description").ToString

        NameConTextEdit.ReadOnly = True
        NameDecTextEdit.ReadOnly = True
        TnvedTextEdit.ReadOnly = True
        AreaMemoEdit.ReadOnly = True
        UsedMemoEdit.ReadOnly = True
        DescriptionMemoEdit.ReadOnly = True
        '
        ' Me
        '
        Me.Icon = My.Resources.shipment_ico
        Me.Text = "Объект экспертизы"
        Me.CenterToScreen()

    End Sub

    Private Sub GoodForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If _goodId < 0 Then Exit Sub
    End Sub

    Private Sub NameConTextEdit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles NameConTextEdit.GotFocus
        NameConTextEdit.DeselectAll()
    End Sub

End Class