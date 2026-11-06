''' <summary>
''' Форма проверки орфографии
''' </summary>
''' <remarks></remarks>
Friend Class DictionaryForm

    Friend Sub New()
        InitializeComponent()
        '
        ' Dictionary
        '
        SpellChecker1.Dictionaries.Add(Cprp.DxDictionary.Common.OpenOfficeDictionary)
        SpellChecker1.Dictionaries.Add(Cprp.DxDictionary.Common.CustomDictionary)
        '
        ' DictionaryMemoEdit 
        '
        DictionaryMemoEdit.Text = "Текс с ошиббками"
        '
        ' Me
        '
        Me.Text = "Проверка орфографии"
        Me.CenterToScreen()

    End Sub

    Private Sub DictionaryForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        DictionaryMemoEdit.SelectionStart = DictionaryMemoEdit.Text.Length
    End Sub

End Class