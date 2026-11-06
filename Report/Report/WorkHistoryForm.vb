Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма истории работы
''' </summary>
''' <remarks></remarks>
Friend Class WorkHistoryForm

    Private HistoryTable As DataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    ''' <remarks></remarks>
    Friend Sub New(Connection As SqlConnection, workId As Object)
        InitializeComponent()
        '
        ' HistoryTable
        '
        HistoryTable = New DataTable
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = String.Format("SELECT eventDate, eventName, userName, comment FROM vWorkHistory WHERE workId = {0}", C2.ToInt(workId))
            HistoryTable.Load(Cmd.ExecuteReader)
            '
            ' Дата создания работы
            '
            Cmd.CommandText = String.Format("SELECT createDate FROM tWork WHERE id = {0} AND NOT createDate IS NULL", workId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then
                    Dim Row As DataRow = HistoryTable.NewRow
                    Row("eventDate") = Dr(0)
                    Row("eventName") = "Создание работы"
                    Row("userName") = "<Система>"
                    HistoryTable.Rows.Add(Row)
                End If
            End Using
        End Using
        '
        ' HistoryGridControl, HistoryGridView  
        '
        HistoryGridControl.DataSource = HistoryTable
        HistoryGridView.SortInfo.Insert(0, EventDateGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' CommentMemoEdit 
        '
        CommentMemoEdit.DataBindings.Add("EditValue", HistoryTable, "comment")
        '
        ' Me
        '
        Me.Text = String.Format("Работа #{0} - История работы", C2.ToInt(workId))
        Me.CenterToScreen()

    End Sub

    Private Sub WorkHistoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        HistoryGridView.MoveFirst()
        CommentLayoutControlGroup.Expanded = True
    End Sub

End Class