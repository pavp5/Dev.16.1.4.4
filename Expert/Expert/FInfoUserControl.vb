''' <summary>
''' Элемент управления "Контролируемые заключения"
''' </summary>
Friend Class FInfoUserControl

    ''' <summary>
    ''' Таблица заключений
    ''' </summary>
    Friend DocTable As DataTable = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' DocTable
        '
        DocTable = New DataTable
        With DocTable.Columns
            .Add("id", GetType(Integer))
            .Add("docNumDate", GetType(String))
            .Add("orgNameLong", GetType(String))
            .Add("conNumDate", GetType(String))
            .Add("rusCaptionInn", GetType(String))
            .Add("nusCaption", GetType(String))
            .Add("endCaption", GetType(String))
            .Add("goodName", GetType(String))
            .Add("goodTnved", GetType(String))
            .Add("goodListPos", GetType(String))
            .Add("summary", GetType(String))
        End With
        DocTable.PrimaryKey = New DataColumn() {DocTable.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = "SELECT * FROM VFInfo"
            DocTable.Load(Cmd.ExecuteReader)
        End Using
        '
        ' ListGridControl, ListGridView
        '
        ListGridControl.DataSource = DocTable
        ListGridView.SortInfo.Insert(0, DocNumDateGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
    End Sub

End Class
