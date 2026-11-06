''' <summary>
''' Форма загрузки сведений о товарах из архивной базы данных
''' </summary>
''' <remarks></remarks>
Friend Class GoodLoadForm

    Friend Sub New()
        InitializeComponent()
        TnvedCheckEdit.Checked = True
        CasCheckEdit.Checked = True
        CategoryCheckEdit.Checked = True
        DescriptionCheckEdit.Checked = True
        UsedCheckEdit.Checked = True
        AreaCheckEdit.Checked = True
        Me.Text = "Выберите данные для загрузки"
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class