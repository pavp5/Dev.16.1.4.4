Imports C2 = Cprp.DxData.Common
Friend Class WorkForm

    Private WorkTable As DataTable = Nothing

    Friend Sub New(workId As Object)
        InitializeComponent()
        TypeLookUpEdit.Properties.DataSource = New Cprp.DxData.Handbook.WorkTypeDataTable(Program.DbClient.Connection)
        WorkTable = New DataTable
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = String.Format("SELECT * FROM tWork WHERE id = {0}", C2.ToInt(workId))
            WorkTable.Load(Cmd.ExecuteReader)
        End Using
        If WorkTable.Rows.Count = 0 Then
            Dim Row As DataRow = WorkTable.NewRow
            Row("typeId") = CInt(Cprp.DxData.Work.WorkType.IsExCont)
            Row("kindId") = CInt(Cprp.DxData.Work.WorkKind.IsPrimary)
            Row("conditionId") = CInt(Cprp.DxData.Work.WorkCondition.IsNew)
            Row("managerId") = Program.DbClient.Id
            Row("leaderId") = 28
            Row("isPayment") = False
            Row("isPrice") = False
            Row("percentCount") = 0
            Row("ballCalc") = 0
            Row("ballFact") = 0
            WorkTable.Rows.Add(Row)
        End If
        With WorkTable.Rows(0)
            TypeLookUpEdit.EditValue = .Item("typeId")
            ClientNameTextEdit.Text = C2.ToText(.Item("clientName"))
            OrderNumTextEdit.Text = C2.ToText(.Item("orderNum"))
            If Not IsDBNull(.Item("orderTerm")) Then OrderTermDateEdit.EditValue = .Item("orderTerm")
            DescriptionMemoEdit.Text = C2.ToText(.Item("description"))
        End With
        If WorkTable.Rows(0).RowState = DataRowState.Added Then
            Me.Text = "Новая работа"
        Else
            Me.Text = String.Format("Работа № {0}", CInt(WorkTable.Rows(0)("id")))
        End If
        Me.CenterToScreen()

    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        DxErrorProvider1.ClearErrors()
        If TypeLookUpEdit.EditValue Is Nothing Then
            DxErrorProvider1.SetError(TypeLookUpEdit, "Укажите вид услуги")
            Exit Sub
        End If
        If Not C2.IsText(ClientNameTextEdit.EditValue) Then
            DxErrorProvider1.SetError(ClientNameTextEdit, "Укажите вид заказчика")
            Exit Sub
        End If
        If Not C2.IsText(OrderNumTextEdit.EditValue) Then
            DxErrorProvider1.SetError(OrderNumTextEdit, "Укажите номер заказа")
            Exit Sub
        End If
        If OrderTermDateEdit.EditValue Is Nothing Then
            DxErrorProvider1.SetError(OrderTermDateEdit, "Укажите срок заказа")
            Exit Sub
        End If
        With WorkTable.Rows(0)
            .Item("typeId") = TypeLookUpEdit.EditValue
            .Item("clientName") = ClientNameTextEdit.Text
            .Item("orderNum") = OrderNumTextEdit.Text
            .Item("orderTerm") = OrderTermDateEdit.EditValue
            .Item("description") = DescriptionMemoEdit.Text
            .Item("expertTerm") = Date.Now.AddHours(2)
        End With
        Using A As New SqlDataAdapter("SELECT * FROM tWork", Program.DbClient.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(WorkTable)
        End Using
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class