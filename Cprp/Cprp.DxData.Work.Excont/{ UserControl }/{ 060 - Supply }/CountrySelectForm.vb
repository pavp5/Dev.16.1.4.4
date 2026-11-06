Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма выбора стран назначения / отправления
''' </summary>
Friend Class CountrySelectForm

    ' Работа
    Private _Work As WorkConnectionRow = Nothing

    ' Таблица-справочник стран мира
    Private CountryTable As DataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <remarks></remarks>
    Friend Sub New(Work As WorkConnectionRow)
        InitializeComponent()
        '
        ' _Work
        '
        _Work = Work
        If _Work Is Nothing OrElse _Work.IsEmpty Then Exit Sub
        '
        ' CountryTable
        '
        CountryTable = New DataTable
        With CountryTable.Columns
            .Add("id", GetType(Integer))
            .Add("nameShort", GetType(String))
            .Add("isCheck", GetType(Boolean))
        End With
        With CountryTable.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        CountryTable.PrimaryKey = New DataColumn() {CountryTable.Columns("id")}
        CountryTable.Load(_Work.ExecuteReader("SELECT id, nameShort FROM tCountry WHERE isACT = 1 AND NOT nameShort LIKE '%РОССИЯ%'"))
        Dim sTmp As String = C2.ToStrNum(_Work.ARow("countryIdString"), False)
        If Not String.IsNullOrWhiteSpace(sTmp) Then
            Using V As New DataView(CountryTable)
                V.RowFilter = String.Format("id IN ({0})", sTmp)
                For Each VRow As DataRowView In V
                    VRow("isCheck") = True
                Next
            End Using
        End If
        '
        ' CountryGridControl, CountryGridView
        '
        CountryGridControl.DataSource = CountryTable
        CountryGridView.SortInfo.Insert(0, NameShortGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        IsCheckGridColumn.SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        IsCheckGridColumn.Group()
        '
        ' Me
        '
        Me.Text = "Выбор стран"
        Me.CenterToScreen()

    End Sub


    Private Sub CountrySelectForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _Work Is Nothing OrElse _Work.IsEmpty Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If
    End Sub

    ' Отметить страну / снять отметку
    Private Sub SelectBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SelectBarButtonItem.ItemClick
        If CountryGridView.FocusedRowHandle < 0 Then Exit Sub
        With CountryGridView.GetFocusedDataRow
            .Item("isCheck") = If(CBool(.Item("isCheck")), False, True)
        End With
        CountryGridView.RefreshData()
    End Sub

    Private Sub CountryGridControl_DoubleClick(sender As Object, e As EventArgs) Handles CountryGridControl.DoubleClick
        SelectBarButtonItem_ItemClick(Nothing, Nothing)
    End Sub

    ' Поиск в списке
    Private Sub FindRepositoryItemTextEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles FindRepositoryItemTextEdit.EditValueChanging
        CountryGridView.FindFilterText = e.NewValue.ToString
    End Sub

    ' Выбрать страну (страны)
    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        Dim countryIdString As String = Nothing
        Dim countryNameString As String = Nothing
        Using V As New DataView(CountryTable) With {.RowFilter = "isCheck = True", .Sort = "nameShort"}
            If V.Count = 0 Then
                _Work.ARow("countryId") = DBNull.Value
                _Work.ARow("countryIdString") = DBNull.Value
                _Work.ARow("countryNameString") = DBNull.Value
            Else
                _Work.ARow("countryId") = V(0)("id")
                For i As Integer = 0 To V.Count - 1
                    countryIdString = String.Format("{0}, {1}", countryIdString, V(i)("id").ToString)
                    countryNameString = String.Format("{0} / {1}", countryNameString, V(i)("nameShort").ToString)
                Next
                _Work.ARow("countryIdString") = countryIdString.Substring(2)
                _Work.ARow("countryNameString") = countryNameString.Substring(3)
            End If
        End Using
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

End Class