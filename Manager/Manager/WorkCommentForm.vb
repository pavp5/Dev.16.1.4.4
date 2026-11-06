Imports Cprp.DxData.Common
''' <summary>
''' Комментарии к работе
''' </summary>
Friend Class WorkCommentForm

    Private Work As Cprp.DxData.Work.Excont.WorkConnectionRow = Nothing

    Friend newComment As String = Nothing

    Public Sub New(workId As Object)
        InitializeComponent()
        '
        ' Work 
        '
        Work = New Cprp.DxData.Work.Excont.WorkConnectionRow(workId, Program.DbClient.Connection)
        '
        ' WorkCommentGridControl
        '
        WorkCommentGridControl.DataSource = Work.WorkCommentTable
        WorkCommentGridView.SortInfo.Insert(0, CreateDateGridColumn, DevExpress.Data.ColumnSortOrder.Descending)
        WorkCommentGridView.MoveFirst()
        '
        ' Me
        '
        Me.Icon = My.Resources.comment_ico
        Me.Text = String.Format("Работа № {0} ({1})", ToInt(Work.Id), ToText(Work("clientName")))
        Me.Width = Screen.GetWorkingArea(Me).Height
        Me.Height = Me.Width - 50
        Me.CenterToScreen()
    End Sub

    Private Sub AddCommentSimpleButton_Click(sender As Object, e As EventArgs) Handles AddCommentSimpleButton.Click
        Dim comment = ToText(WorkCommentMemoEdit.Text)
        If String.IsNullOrWhiteSpace(comment) Then Exit Sub
        Work.WorkCommentTable.AddComment(Date.Now, ToInt(Program.DbClient.Id), comment)
        WorkCommentMemoEdit.Text = Nothing
        newComment = comment
        WorkCommentGridView.MoveFirst()
    End Sub

End Class