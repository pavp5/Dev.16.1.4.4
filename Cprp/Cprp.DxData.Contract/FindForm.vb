Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма поиск сделки в таблице сделок
''' </summary>
''' <remarks></remarks>
Friend Class FindForm

    ''' <summary>
    ''' Таблица-строка, выбранная в результатах поиска
    ''' </summary>
    ''' <remarks></remarks>
    Friend ContractRow As ContractDataTable = Nothing

    ''' <summary>
    ''' Открытое соединение с базой данных
    ''' </summary>
    ''' <remarks></remarks>
    Private _Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Таблица сделок
    ''' </summary>
    ''' <remarks></remarks>
    Private _ContractTable As DataTable = Nothing

    ''' <summary>
    ''' Таблица участников сделок
    ''' </summary>
    ''' <remarks></remarks>
    Private _MemberTable As DataTable = Nothing

    ''' <summary>
    ''' Представление участников выделенной сделки
    ''' </summary>
    ''' <remarks></remarks>
    Private _MemberView As DataView = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="Row">Строка таблицы сделок с предварительными данными для поиска</param> 
    ''' <remarks></remarks>
    Friend Sub New(Connection As SqlConnection, Optional Row As DataRow = Nothing)
        InitializeComponent()
        '
        ' _Connection
        '
        _Connection = Connection
        '
        ' _ContractTable
        '
        _ContractTable = New DataTable
        With _ContractTable.Columns
            .Add("id", GetType(Integer))
            .Add("contractCaptionNum", GetType(String))
        End With
        _ContractTable.PrimaryKey = New DataColumn() {_ContractTable.Columns("id")}
        '
        ' _MemberTable
        '
        _MemberTable = New DataTable
        With _MemberTable.Columns
            .Add("contractId", GetType(Integer))
            .Add("memberId", GetType(Integer))
            .Add("kindId", GetType(Integer))
            .Add("memberCaption", GetType(String))
        End With
        With _MemberTable
            .PrimaryKey = New DataColumn() {.Columns("contractId"), .Columns("memberId"), .Columns("kindId")}
        End With
        '
        ' _MemberView
        '
        _MemberView = New DataView(_MemberTable)
        '
        ' Row
        '
        If Row Is Nothing OrElse Not TypeOf Row.Table Is ContractDataTable Then GoTo EndRow
        Dim sTmp As String = GetQueryByRow(Row)
        If Not C2.IsText(sTmp) Then GoTo EndRow
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format("SELECT id, contractCaptionNum FROM vContract WHERE {0}", sTmp)
            _ContractTable.Load(Cmd.ExecuteReader)
            sTmp = "0"
            For Each Row In _ContractTable.Rows
                sTmp = String.Format("{0}, {1}", sTmp, CInt(Row("id")))
            Next
            Cmd.CommandText = String.Format("SELECT contractId, memberId, kindId, memberCaption FROM vContractMember WHERE contractId In ({0})", sTmp)
            _MemberTable.Load(Cmd.ExecuteReader)
        End Using
EndRow:
        '
        ' DataSource, DataBindings
        '
        ContractGridControl.DataSource = _ContractTable
        ContractGridView.SortInfo.Insert(0, ContractCaptionNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        ContractGridView.MoveFirst()
        MemberGridControl.DataSource = _MemberView
        MemberGridView.SortInfo.Insert(0, KindIdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        MemberGridView.SortInfo.Insert(1, MemberCaptionGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        MemberGridView.MoveFirst()
        '
        ' AcceptSimpleButton
        '
        AcceptSimpleButton.Enabled = (_ContractTable.Rows.Count > 0)
        '
        ' Me
        '
        Me.Text = "Поиск: Сделка"
        Me.CenterToScreen()

    End Sub

    ''' <summary>
    ''' Возвращает условия запроса на выборку данных по содержимому строки таблицы сделок
    ''' </summary>
    ''' <param name="Row">Строка таблицы сделок</param>
    ''' <remarks></remarks>
    Private Function GetQueryByRow(Row As DataRow) As String
        If Row Is Nothing OrElse Row.Table Is Nothing Then Return Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        For Each Col As DataColumn In Row.Table.Columns
            sTmp1 = C2.ToText(Row(Col))
            If C2.IsText(sTmp1) Then sTmp1 = sTmp1.Replace("'", "''").Replace("*", "%")
            If Not C2.IsText(sTmp1) Then Continue For
            Select Case Col.ColumnName.ToUpper
                Case "DOCNAME" : sTmp = String.Format("docName LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "DOCNUM" : sTmp = String.Format("docNum LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "DOCDATE" : sTmp = String.Format("docDate >= {{ts '{0:yyyy-MM-dd 00:00:00}'}} AND docDate < {{ts '{1:yyyy-MM-dd 00:00:00}'}} AND {2}", CDate(sTmp1), CDate(sTmp1).AddDays(1), sTmp) : Exit Select
                Case "DOCTERM" : sTmp = String.Format("docTerm >= {{ts '{0:yyyy-MM-dd 00:00:00}'}} AND docTerm < {{ts '{1:yyyy-MM-dd 00:00:00}'}} AND {2}", CDate(sTmp1), CDate(sTmp1).AddDays(1), sTmp) : Exit Select
            End Select
        Next
        If C2.IsText(sTmp) Then Return String.Format("{0} isACT = 1", sTmp)
        Return Nothing
    End Function

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        Dim sTmp As String = C2.ToText(FindButtonEdit.Text)
        If Not C2.IsText(sTmp) Then Exit Sub
        _ContractTable.Rows.Clear()
        _MemberTable.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format( _
                "SELECT id, contractCaptionNum FROM vContract WHERE contractCaptionName LIKE '%{0}%'", _
                sTmp.Replace("'", "''").Replace("*", "%"))
            _ContractTable.Load(Cmd.ExecuteReader)
            sTmp = "0"
            For Each Row As DataRow In _ContractTable.Rows
                sTmp = String.Format("{0}, {1}", sTmp, CInt(Row("id")))
            Next
            Cmd.CommandText = String.Format("SELECT contractId, memberId, kindId, memberCaption FROM vContractMember WHERE contractId In ({0})", sTmp)
            _MemberTable.Load(Cmd.ExecuteReader)
        End Using
        AcceptSimpleButton.Enabled = (_ContractTable.Rows.Count > 0)
        If _ContractTable.Rows.Count = 0 Then
            Cprp.DxCommon.Messages.ShowInformation("По указанным условиям поиска ничего не найдено.", "Поиск")
        Else
            ContractGridView.MoveFirst()
            _MemberView.RowFilter = String.Format("contractId = {0}", CInt(ContractGridView.GetFocusedDataRow("id")))
            MemberGridView.MoveFirst()
        End If
    End Sub

    Private Sub ContractGridView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles ContractGridView.FocusedRowChanged
        Dim iTmp As Integer = C2.EMPTY_ID
        If ContractGridView.FocusedRowHandle >= 0 Then iTmp = CInt(ContractGridView.GetFocusedDataRow("id"))
        _MemberView.RowFilter = String.Format("contractId = {0}", iTmp)
        MemberGridView.MoveFirst()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If ContractGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim iTmp As Integer = C2.ToInt(ContractGridView.GetFocusedDataRow("id"))
        ContractRow = New ContractDataTable
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format("SELECT * FROM tContract WHERE id = {0}", iTmp)
            ContractRow.Load(Cmd.ExecuteReader)
            ContractRow.Rows(0).Item("dbId") = iTmp
            Cmd.CommandText = String.Format("SELECT * FROM tContractMember WHERE contractId = {0}", iTmp)
            ContractRow.MemberTable.Load(Cmd.ExecuteReader)
        End Using
        ContractRow.AcceptChanges()
        ContractRow.MemberTable.AcceptChanges()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub ContractGridControl_DoubleClick(sender As Object, e As EventArgs) Handles ContractGridControl.DoubleClick
        AcceptSimpleButton.PerformClick()
    End Sub

End Class