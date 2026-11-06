''' <summary>
''' Форма редактирования связей запретов и ограничений со странами
''' </summary>
Friend Class CountryForm

    ''' <summary>
    ''' Источник данных запретов и ограничений
    ''' </summary>
    Private Ds As EmbargoDataSet = Nothing

    ''' <summary>
    ''' ID записи из таблицы запретов и ограничений
    ''' </summary>
    Private embargoId As Integer = 0


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Ds">Источник данных запретов и ограничений</param>
    ''' <param name="embargoId">ID записи из таблицы запретов и ограничений</param>
    Friend Sub New(Ds As EmbargoDataSet, embargoId As Integer)
        InitializeComponent()
        Me.Ds = Ds
        Me.embargoId = embargoId
        Me.Ds.CountryTable.CheckClear()
        Dim Row As DataRow = Nothing
        Using V As New DataView(Me.Ds.EmbargoCountryTable)
            V.RowFilter = String.Format("embargoId = {0}", Me.embargoId)
            For Each VRow As DataRowView In V
                Row = Me.Ds.CountryTable.Rows.Find(VRow("countryId"))
                If Not Row Is Nothing Then
                    Row("isCheck") = True
                    Row("modeId") = VRow("modeId")
                End If
            Next
        End Using
        CountryGridControl.DataSource = Me.Ds.CountryTable
        CountryGridView.SortInfo.Insert(0, NameShortGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        Me.Text = String.Format("Страны (embargoId = {0})", Me.embargoId)
        Me.Width = 550
        Me.Height = Screen.GetWorkingArea(Me).Height - 50
        Me.CenterToScreen()
    End Sub


    Private Sub CountryForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        CountryGridView.CloseEditor()
        CountryGridView.UpdateCurrentRow()
        Using V As New DataView(Me.Ds.CountryTable) With {.RowFilter = "isCheck = True"}
            For Each VRow As DataRowView In V
                If IsDBNull(VRow("modeId")) Then
                    Cprp.DxCommon.Messages.ShowError("Укажите modeId для выбранной страны!")
                    e.Cancel = True
                    Exit Sub
                End If
            Next
        End Using
        Using V As New DataView(Me.Ds.EmbargoCountryTable)
            V.RowFilter = String.Format("embargoId = {0}", Me.embargoId)
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        Using V As New DataView(Me.Ds.CountryTable) With {.RowFilter = "isCheck = True"}
            For Each VRow As DataRowView In V
                Me.Ds.EmbargoCountryTable.Rows.Add(New Object() {VRow("id"), Me.embargoId, VRow("modeId")})
            Next
        End Using
    End Sub

End Class