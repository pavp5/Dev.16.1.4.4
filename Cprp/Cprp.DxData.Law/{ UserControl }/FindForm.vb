''' <summary>
''' Форма расширенного поиска в нормативных документах
''' </summary>
''' <remarks></remarks>
Friend Class FindForm

    Friend Shared word As String = Nothing
    Friend Shared tnved As String = Nothing
    Friend Shared cas As String = Nothing

    Friend Shared isAreaAll As Boolean = True
    Friend Shared isAreaExCont As Boolean = False
    Friend Shared isAreaMilitary As Boolean = False
    Friend Shared isAreaCustomUnion As Boolean = False

    Friend Shared isModeAll As Boolean = True
    Friend Shared isModeExport As Boolean = False
    Friend Shared isModeImport As Boolean = False

    Friend Sub New()
        InitializeComponent()
        FindWordTextEdit.Text = word
        FindTnvedTextEdit.Text = tnved
        FindCasTextEdit.Text = cas
        AreaAllCheckEdit.Checked = isAreaAll
        AreaExContCheckEdit.Checked = isAreaExCont
        AreaMilitaryCheckEdit.Checked = isAreaMilitary
        AreaCustomUnionCheckEdit.Checked = isAreaCustomUnion
        ModeAllCheckEdit.Checked = isModeAll
        ModeExportCheckEdit.Checked = isModeExport
        ModeImportCheckEdit.Checked = isModeImport
        Me.Text = "Поиск в нормативных документах"
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        Dim sTmp As String = FindWordTextEdit.Text & FindTnvedTextEdit.Text & FindCasTextEdit.Text
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowError("Укажите критерии поиска!", "Поиск")
            Exit Sub
        End If
        word = FindWordTextEdit.Text
        tnved = FindTnvedTextEdit.Text
        cas = FindCasTextEdit.Text
        isAreaAll = AreaAllCheckEdit.Checked
        isAreaExCont = AreaExContCheckEdit.Checked
        isAreaMilitary = AreaMilitaryCheckEdit.Checked
        isAreaCustomUnion = AreaCustomUnionCheckEdit.Checked
        isModeAll = ModeAllCheckEdit.Checked
        isModeExport = ModeExportCheckEdit.Checked
        isModeImport = ModeImportCheckEdit.Checked
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class