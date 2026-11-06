''' <summary>
''' Форма отображения списка контролируемых заключений из отчетов ФСТЭК
''' </summary>
Friend Class FInfoDocForm

    ''' <summary>
    ''' Таблица заключений
    ''' </summary>
    Friend DocTable As DataTable = Nothing

    ''' <summary>
    ''' ID активной записи в списке заключений
    ''' </summary>
    Private rowId As Integer = -1


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="rowId">ID активной записи в списке заключений</param>
    ''' <remarks></remarks>
    Friend Sub New(Optional ByVal rowId As Integer = -1)
        InitializeComponent()
        Me.rowId = rowId
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
        '
        ' ListGridControl, ListGridView
        '
        ListGridControl.DataSource = DocTable
        ListGridView.SortInfo.Insert(0, DocNumDateGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Me
        '
        Me.Icon = My.Resources.document_red_ico
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
    End Sub


    Private Sub FInfoForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If DocTable.Rows.Count > 0 Then
            ListGridView.MoveFirst()
            Dim iTmp As Integer = 0
            While ListGridView.IsValidRowHandle(iTmp)
                If CInt(ListGridView.GetRow(iTmp)("id")) = rowId Then
                    ListGridView.FocusedRowHandle = iTmp
                    Exit While
                End If
                iTmp += 1
            End While
        End If
    End Sub

End Class