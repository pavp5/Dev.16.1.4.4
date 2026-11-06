''' <summary>
''' Форма создания нового запроса
''' </summary>
Friend Class RequestTermForm

    ''' <summary>
    ''' Справочник видов запросов
    ''' </summary>
    Private TypeTable As DataTable = Nothing



    Friend Sub New()
        InitializeComponent()
        '
        ' TypeTable
        '
        TypeTable = New DataTable("TypeTable")
        With TypeTable.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        TypeTable.PrimaryKey = New DataColumn() {TypeTable.Columns("id")}
        With TypeTable.Rows
            .Add(New Object() {1, "Недостающая документация"})
            .Add(New Object() {2, "Дополнение к техническим данным"})
        End With
        '
        ' TypeLookUpEdit
        '
        TypeLookUpEdit.Properties.DataSource = TypeTable
        '
        ' Me
        '
        Me.Text = "Новый запрос"
        Me.CenterToScreen()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If Not (IsDBNull(TypeLookUpEdit.EditValue) OrElse TypeLookUpEdit.EditValue Is Nothing OrElse TermDateEdit.EditValue Is Nothing) Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
        End If
    End Sub

End Class