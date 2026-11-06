Imports Cprp.DxData.Common
''' <summary>
''' Форма редактирования реквизитов экспертной огранизации
''' </summary>
Friend Class ExpertOrgForm

    ''' <summary>
    ''' Строка таблицы экспертных огранизаций
    ''' </summary>
    Private Row As DataRow = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Row">Строка таблицы экспертных организаций</param>
    Friend Sub New(ByRef Row As DataRow)
        InitializeComponent()
        Me.Row = Row
        NameLongMemoEdit.EditValue = ToText(Me.Row("nameLong"))
        NameShortMemoEdit.EditValue = ToText(Me.Row("nameShort"))
        InnTextEdit.EditValue = ToText(Me.Row("inn"))
        Me.Text = "Реквизиты организации"
        Me.CenterToScreen()
    End Sub


    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not IsText(NameLongMemoEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите полное наименование!")
            Exit Sub
        End If
        If Not IsText(InnTextEdit.EditValue) Then
            Cprp.DxCommon.Messages.ShowWarning("Укажите ИНН!")
            Exit Sub
        End If
        If InnTextEdit.EditValue.ToString.Length > 12 Then
            Cprp.DxCommon.Messages.ShowWarning("Длина ИНН больше 12 символов!")
            Exit Sub
        End If
        Row("nameLong") = DbText(NameLongMemoEdit.EditValue)
        Row("nameShort") = DbText(NameShortMemoEdit.EditValue)
        Row("inn") = InnTextEdit.EditValue
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class