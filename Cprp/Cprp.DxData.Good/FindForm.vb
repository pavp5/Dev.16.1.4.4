Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма поиска объекта экспертизы в базе данных
''' </summary>
''' <remarks></remarks>
Friend Class FindForm

    ''' <summary>
    ''' Таблица-строка, выбранная в результатах поиска
    ''' </summary>
    ''' <remarks></remarks>
    Friend GoodRow As GoodDataTable = Nothing

    ''' <summary>
    ''' Открытое соединение с базой данных
    ''' </summary>
    ''' <remarks></remarks>
    Private _Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Таблица результатов поиска
    ''' </summary>
    ''' <remarks></remarks>
    Private _GoodTable As DataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="Row">Строка таблицы объектов экспертизы с предварительными данными для поиска</param> 
    ''' <remarks></remarks>
    Friend Sub New(Connection As SqlConnection, Optional Row As DataRow = Nothing)
        InitializeComponent()
        '
        ' _Connection
        '
        _Connection = Connection
        '
        ' _GoodTable
        '
        _GoodTable = New GoodDataTable
        '
        ' Row
        '
        If Row Is Nothing OrElse Not TypeOf Row.Table Is GoodDataTable Then GoTo EndRow
        Dim sTmp As String = GetQueryByRow(Row)
        If Not C2.IsText(sTmp) Then GoTo EndRow
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format( _
                "SELECT * FROM tGood WHERE {0}", sTmp)
            _GoodTable.Load(Cmd.ExecuteReader)
        End Using
EndRow:
        '
        ' DataSource, DataBindings
        '
        GoodGridControl.DataSource = _GoodTable
        GoodGridView.SortInfo.Insert(0, NameConGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        GoodGridView.MoveFirst()
        NameConLabelControl.Text = Nothing
        NameConLabelControl.DataBindings.Add("Text", _GoodTable, "nameCon")
        NameDecLabelControl.Text = Nothing
        NameDecLabelControl.DataBindings.Add("Text", _GoodTable, "nameDec")
        TnvedLabelControl.Text = Nothing
        TnvedLabelControl.DataBindings.Add("Text", _GoodTable, "tnved")
        DescriptionLabelControl.Text = Nothing
        DescriptionLabelControl.DataBindings.Add("Text", _GoodTable, "description")
        '
        ' AcceptSimpleButton
        '
        AcceptSimpleButton.Enabled = (_GoodTable.Rows.Count > 0)
        '
        ' Me
        '
        Me.Text = "Поиск: Объект экспертизы"
        Me.CenterToScreen()

    End Sub


    ''' <summary>
    ''' Возвращает условия запроса на выборку данных по содержимому строки таблицы объектов экспертизы
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
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
                Case "NAMECON" : sTmp = String.Format("nameCon LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "NAMEDEC" : sTmp = String.Format("nameDec LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "CATEGORIYD" : sTmp = String.Format("categoryId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                Case "TYPEYD" : sTmp = String.Format("typeId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                Case "TNVED" : sTmp = String.Format("tnved LIKE '{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "TNVEDCOMMENT" : sTmp = String.Format("tnvedComment LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "ISUNREAL" : sTmp = String.Format("isUnreal = {0} AND {1}", If(CBool(sTmp1), 1, 0), sTmp) : Exit Select
                Case "CAS" : sTmp = String.Format("cas LIKE '{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "AREA" : sTmp = String.Format("area LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "USED" : sTmp = String.Format("used LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "DESCRIPTION" : sTmp = String.Format("description LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
            End Select
        Next
        If C2.IsText(sTmp) Then Return String.Format("{0} isACT = 1", sTmp)
        Return Nothing
    End Function

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        Dim sTmp As String = C2.ToText(FindButtonEdit.Text)
        If Not C2.IsText(sTmp) Then Exit Sub
        _GoodTable.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format( _
                "SELECT * FROM tGood WHERE nameCon LIKE '%{0}%' OR nameDec LIKE '%{0}%' OR tnved LIKE '{0}%'", _
                sTmp.Replace("'", "''").Replace("*", "%").Replace(" ", "%"))
            _GoodTable.Load(Cmd.ExecuteReader)
        End Using
        If _GoodTable.Rows.Count = 0 Then
            Cprp.DxCommon.Messages.ShowInformation("По указанным условиям поиска ничего не найдено.", "Поиск")
        End If
        AcceptSimpleButton.Enabled = (_GoodTable.Rows.Count > 0)
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If GoodGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim iTmp As Integer = C2.ToInt(GoodGridView.GetFocusedDataRow("id"))
        GoodRow = New GoodDataTable
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format("SELECT * FROM tGood WHERE id = {0}", iTmp)
            GoodRow.Load(Cmd.ExecuteReader)
            GoodRow.Rows(0).Item("dbId") = iTmp
        End Using
        GoodRow.AcceptChanges()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub MemberGridControl_DoubleClick(sender As Object, e As EventArgs) Handles GoodGridControl.DoubleClick
        AcceptSimpleButton.PerformClick()
    End Sub

End Class