Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма истории работы
''' </summary>
Friend Class WorkHistoryForm

    Private HistoryTable As DataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Work">Работа</param>
    Friend Sub New(Work As WorkConnectionRow)
        InitializeComponent()
        Dim workId As Integer = C2.ToInt(Work.Id)
        '
        ' HistoryTable
        '
        HistoryTable = New DataTable
        HistoryTable.Load(Work.ExecuteReader(String.Format("SELECT eventDate, eventName, userName, comment FROM vWorkHistory WHERE workId = {0}", workId)))
        '
        ' Дата создания работы
        '
        Using Dr As SqlDataReader = Work.ExecuteReader(String.Format("SELECT createDate FROM tWork WHERE id = {0} AND NOT createDate IS NULL", workId))
            If Dr.Read Then
                Dim Row As DataRow = HistoryTable.NewRow
                Row("eventDate") = Dr(0)
                Row("eventName") = "Создание работы"
                Row("userName") = "<Система>"
                HistoryTable.Rows.Add(Row)
            End If
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
        Me.Text = String.Format("Работа #{0} - История работы", workId)
        Me.CenterToScreen()

    End Sub


    Private Sub WorkHistoryForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        HistoryGridView.MoveFirst()
        CommentLayoutControlGroup.Expanded = True
    End Sub

End Class