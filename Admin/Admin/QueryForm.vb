''' <summary>
''' Форма редактирования запроса к базе данных
''' </summary>
''' <remarks></remarks>
Friend Class QueryForm

    Friend Sub New()
        InitializeComponent()
        Me.Text = "Выполнение запроса к базе данных"
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcceptSimpleButton.Click
        If Not String.IsNullOrWhiteSpace(QueryMemoEdit.Text) Then Me.DialogResult = DialogResult.OK
    End Sub

End Class