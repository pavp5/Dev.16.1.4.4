''' <summary>
''' Форма выбора полей результатов поиска
''' </summary>
Friend Class FieldForm


    Friend Sub New()
        InitializeComponent()
        FieldTreeListColumn.Visible = False
        FieldTreeList.ExpandAll()
        Me.Text = "Выбор полей"
        Me.Height = Screen.GetWorkingArea(Me).Height - 50
        Me.CenterToScreen()
    End Sub


    Private Sub FieldTreeList_BeforeCollapse(sender As Object, e As DevExpress.XtraTreeList.BeforeCollapseEventArgs) Handles FieldTreeList.BeforeCollapse
        e.CanCollapse = False
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class