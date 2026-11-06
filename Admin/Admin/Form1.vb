Imports Cprp.DxData.Common
Friend Class Form1

    Private CountryTable As Cprp.DxData.Handbook.CountryDataTable


    Friend Sub New()
        InitializeComponent()
        CountryTable = New Cprp.DxData.Handbook.CountryDataTable(Program.DbClient.Connection)
        Me.CenterToScreen()
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If MsgBox("Загрузить данные по лицам?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Вопрос") <> MsgBoxResult.Yes Then Exit Sub
        Dim sId As Integer = 0
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = "SELECT ISNULL(MAX(id), 0) FROM tEmbargoMember"
            sId = 1 + CInt(Cmd.ExecuteScalar)
        End Using
        Dim sTmp As String = Nothing
        Dim Row As DataRow = Nothing
        Using R As New DevExpress.XtraRichEdit.RichEditDocumentServer
            R.LoadDocument("d:\21.docx", DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Using T As New Embargo.MemberDataTable
                With R.Document.Tables(0)
                    For i As Integer = 0 To .Rows.Count - 1
                        Me.Text = String.Format("Read file ({0} из {1})", i + 1, .Rows.Count)
                        Application.DoEvents()
                        sTmp = ToText(R.Document.GetText(.Cell(i, 0).ContentRange))
                        While sTmp Like "[0123456789.]*"
                            sTmp = sTmp.Substring(1)
                        End While
                        Row = T.NewRow
                        Row("id") = sId + i
                        Row("embargoId") = 24
                        Row("countryId") = 218
                        Row("modeId") = 3
                        Row("isACT") = True
                        Row("caption") = ToText(sTmp)
                        T.Rows.Add(Row)
                    Next
                End With
                Me.Text = "Save data..."
                Using A As New SqlDataAdapter("SELECT * FROM tEmbargoMember", Program.DbClient.Connection)
                    Dim B As New SqlCommandBuilder(A)
                    A.Update(T)
                End Using
            End Using
        End Using

        MsgBox("OK")

    End Sub
End Class