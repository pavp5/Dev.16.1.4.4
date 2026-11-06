''' <summary>
''' Форма выбора вида услуги
''' </summary>
Friend Class ServiceForm

    ''' <summary>
    ''' ID выбранного вида услуги
    ''' </summary>
    Friend Property ServiceId As Integer = Cprp.DxData.Common.EMPTY_ID


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="serviceId">ServiceId редактируемой услуги</param>
    ''' <remarks></remarks>
    Friend Sub New(serviceId As Integer)
        InitializeComponent()
        Me.ServiceId = serviceId
        '
        ' ServiceTreeList
        '
        ServiceTreeList.DataSource = Program.Calc.ServiceTable.DefaultView
        ServiceTreeList.ExpandAll()
        '
        ' Me
        '
        Me.Text = "Выбор вида услуги"
        Me.Width = Screen.GetWorkingArea(Me).Height
        Me.Height = Me.Width - 50
        Me.CenterToScreen()
    End Sub


    Private Sub ServiceForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Dim Row As DataRow = Program.Calc.ServiceTable.FindRowByServiceId(ServiceId)
        If Row Is Nothing Then Exit Sub
        Dim Node As DevExpress.XtraTreeList.Nodes.TreeListNode = ServiceTreeList.FindNodeByKeyID(Row("id"))
        If Not Node Is Nothing Then ServiceTreeList.FocusedNode = Node
    End Sub


    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        Dim Node As DevExpress.XtraTreeList.Nodes.TreeListNode = ServiceTreeList.FocusedNode
        If Node Is Nothing Then Exit Sub
        If IsDBNull(Node.GetValue("serviceId")) Then Exit Sub
        ServiceId = CInt(Node.GetValue("serviceId"))
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class