''' <summary>
''' Форма для отображения списка контролируемых товаров из отчетов ФСТЭК
''' </summary>
Friend Class FInfoGoodForm

    Friend Sub New()
        InitializeComponent()
        '
        ' SortIdTreeListColumn 
        '
        SortIdTreeListColumn.SortIndex = 0
        '
        ' Me
        '
        Me.Icon = My.Resources.document_red_ico
        Me.Text = "Контролируемые товары"
        Me.Width = Screen.GetWorkingArea(Me).Width * 0.7
        Me.Height = Screen.GetWorkingArea(Me).Height - 10
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class