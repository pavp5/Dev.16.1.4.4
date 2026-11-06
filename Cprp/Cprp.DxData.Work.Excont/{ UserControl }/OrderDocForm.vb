Friend Class OrderDocForm

    Public Work As Cprp.DxData.Work.Excont.WorkConnectionRow = Nothing

    Friend Sub New(work As Cprp.DxData.Work.Excont.WorkConnectionRow)
        InitializeComponent()
        Me.Work = work
        Me.Text = String.Format("Работа № {0} - входящие документы", work.Id.ToString)
        Me.Icon = My.Resources.document_red_ico
        Me.Width = Screen.GetWorkingArea(Me).Width - 15
        Me.Height = Screen.GetWorkingArea(Me).Height - 15
        Me.CenterToScreen()
    End Sub

    Private Sub OrderDocForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Work Is Nothing Then Exit Sub
        If IsDBNull(Work("siteOrderId")) Then Exit Sub
        Try
            Cprp.DxCommon.WaitForm.Show(Me)
            Work.LoadOrderDocFromWeb()
            If Not Work.jsonOrderDoc Is Nothing Then
                ListGridControl.DataSource = Work.jsonOrderDoc.Documents
                WebBrowser1.DataBindings.Add("DocumentText", Work.jsonOrderDoc.Documents, "Markdown")
            End If            
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

End Class