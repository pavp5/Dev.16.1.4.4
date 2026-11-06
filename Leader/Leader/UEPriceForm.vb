''' <summary>
''' Стоимость условной единицы
''' </summary>
''' <remarks></remarks>
Friend Class UEPriceForm

    Private T As DataTable = Nothing

    Friend Sub New()
        InitializeComponent()
        '
        ' T
        '
        T = New DataTable
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = "SELECT * FROM tCalcTarif WHERE name LIKE 'УЕСТОИМОСТЬ'"
            T.Load(Cmd.ExecuteReader)
        End Using
        '
        ' PriceSpinEdit 
        '
        PriceSpinEdit.DataBindings.Add("EditValue", T, "price")
        '
        ' Me
        '
        Me.Text = "Стоимость у.е."
        Me.CenterToScreen()

    End Sub

    Private Sub PriceSpinEdit_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles PriceSpinEdit.GotFocus
        PriceSpinEdit.DeselectAll()
    End Sub

    Private Sub AcceptSimpleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcceptSimpleButton.Click        
        Me.BindingContext(T).EndCurrentEdit()
        Try
            Using A As New SqlDataAdapter("SELECT * FROM tCalcTarif WHERE name IS NULL", Program.DbClient.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(T)
            End Using
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

End Class