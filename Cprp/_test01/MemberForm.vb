Imports System.Data.SqlClient
''' <summary>
''' Форма редактирования данных из таблицы tMember
''' </summary>
Public Class MemberForm

    Private T As DataTable = Nothing

    Public Sub New()
        InitializeComponent()

        T = New DataTable
        Using Cmd As SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = "SELECT * FROM tMember WHERE id IN (51414, 65862, 66641, 64870)"
            T.Load(Cmd.ExecuteReader)
        End Using
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        GridControl1.DataSource = T
        MemoEdit1.DataBindings.Add("EditValue", T, "proDescription")
        MemoEdit2.DataBindings.Add("EditValue", T, "proSource")
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        If MsgBox("Обновить данные в tMember?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        GridView1.UpdateCurrentRow()
        Using A As New SqlDataAdapter("SELECT * FROM tMember", Program.DbClient.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(T)
        End Using
        MsgBox("OK.")
    End Sub
End Class