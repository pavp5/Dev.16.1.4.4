Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма загрузки данных в объект экспертизы
''' </summary>
''' <remarks></remarks>
Friend Class GoodImportForm

    ' Главный элемент управления
    Private P As WorkUserControl = Nothing

    ' Строка из таблицы объектов экспертизы, в которую загружаются данные
    Private _GoodRow As DataRow = Nothing

    ' Таблица объектов экспертизы, из которой загружаются данные
    Private _GoodTable As DataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="MainControl">Главный элемент управления</param> 
    ''' <param name="GoodRow">Строка с объектом экспертизы для загрузки данных</param>
    ''' <remarks></remarks>
    Friend Sub New(ByRef MainControl As WorkUserControl, ByRef GoodRow As DataRow)
        InitializeComponent()
        '
        ' P
        '
        P = MainControl
        If P Is Nothing OrElse Not P.WorkDataExist Then Exit Sub
        '
        ' _GoodRow
        '
        If GoodRow Is Nothing Then Exit Sub
        If GoodRow.RowState = DataRowState.Deleted OrElse GoodRow.RowState = DataRowState.Detached Then Exit Sub
        If Not GoodRow.Table Is P.Work.GoodTable Then Exit Sub
        _GoodRow = GoodRow
        '
        ' _GoodTable (структура)
        '
        _GoodTable = New DataTable
        With _GoodTable.Columns
            .Add("id", GetType(Integer))
            .Add("isCheck", GetType(Boolean))
            .Add("rowNum", GetType(Integer))
            .Add("nameCon", GetType(String))
            .Add("tnved", GetType(String))
            .Add("isSummary", GetType(Boolean))
        End With
        _GoodTable.PrimaryKey = New DataColumn() {_GoodTable.Columns("id")}
        '
        ' _GoodTable (данные)
        '
        For Each Row As DataRow In P.Work.GoodTable.Rows
            If CInt(Row("id")) = CInt(_GoodRow("id")) Then Continue For
            If CBool(Row("isUnreal")) Then Continue For
            _GoodTable.Rows.Add(New Object() { _
                                Row("id"), _
                                False, _
                                Row("rowNum"), _
                                Row("nameCon"), _
                                Row("tnved"), _
                                Row("isCheckSummary")})
        Next
        '
        ' ListGridControl, ListGridView
        '
        ListGridControl.DataSource = _GoodTable
        ListGridView.SortInfo.Insert(0, RowNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Me
        '
        Me.Text = String.Format("Загрузка данных в объект № {0} ({1})", C2.ToInt(_GoodRow("rowNum")), C2.DelPoint(_GoodRow("nameCon")))
        Me.Width = Screen.GetWorkingArea(Me).Height
        Me.Height = Screen.GetWorkingArea(Me).Height - 100
        Me.CenterToScreen()

    End Sub

    Private Sub GoodImportForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _GoodRow Is Nothing Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If
    End Sub

    Private Sub ListGridView_CellValueChanging(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles ListGridView.CellValueChanging
        If Not e.Column Is IsCheckGridColumn Then Exit Sub
        If Not CBool(e.Value) Then Exit Sub
        Using V As New DataView(_GoodTable)
            V.RowFilter = String.Format("isCheck = True AND id <> {0}", CInt(ListGridView.GetDataRow(e.RowHandle)("id")))
            While V.Count > 0
                V(0)("isCheck") = False
            End While
        End Using
        _GoodTable.AcceptChanges()
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        Dim Row As DataRow = Nothing
        '
        ' Представление с выбранной строкой списка объекта экспертизы
        '
        Using V As New DataView(_GoodTable)
            V.RowFilter = "isCheck = True"
            '
            ' Проверка наличия выбранной строки в списке объектов экспертизы
            '
            If V.Count = 0 Then
                Cprp.DxCommon.Messages.ShowWarning("Выберите объект для загрузки данных!", "Загрузка данных")
                Exit Sub
            End If
            '
            ' Строка таблицы объектов экспертизы, из которой выгружаются данные
            '
            Row = P.Work.GoodTable.Rows.Find(V(0)("id"))
        End Using
        '
        ' Проверка, что выбрано, что загружать
        '
        If Not (NameConCheckEdit.Checked OrElse NameDecCheckEdit.Checked OrElse TypeCheckEdit.Checked OrElse _
                TnvedCheckEdit.Checked OrElse CasCheckEdit.Checked OrElse AreaCheckEdit.Checked OrElse _
                UsedCheckEdit.Checked OrElse DescriptionCheckEdit.Checked OrElse SummaryCheckEdit.Checked) Then
            Cprp.DxCommon.Messages.ShowWarning("Выберите, что загружать!", "Загрузка данных")
            Exit Sub
        End If
        '
        ' Документы, подтверждающие гражданское назначение объекта экспертизы, из которого выгружаются данные
        '
        Dim InDocView As DataView = Nothing
        If SummaryCheckEdit.Checked Then InDocView = P.Work.GoodInDocTable.GoodView(Row("id"))
        '
        ' Регистрационные данные
        '
        If NameConCheckEdit.Checked Then _GoodRow("nameCon") = Row("nameCon")
        If NameDecCheckEdit.Checked Then
            _GoodRow("nameDec") = Row("nameDec")
            _GoodRow("isNotDec") = Row("isNotDec")
        End If
        If TypeCheckEdit.Checked Then
            _GoodRow("typeId") = Row("typeId")
            _GoodRow("parentId") = Row("parentId")
        End If
        If TnvedCheckEdit.Checked Then
            _GoodRow("tnved") = Row("tnved")
            _GoodRow("tnvedComment") = Row("tnvedComment")
        End If
        If CasCheckEdit.Checked Then _GoodRow("cas") = Row("cas")
        If AreaCheckEdit.Checked Then _GoodRow("area") = Row("area")
        If UsedCheckEdit.Checked Then _GoodRow("used") = Row("used")
        If DescriptionCheckEdit.Checked Then _GoodRow("description") = Row("description")
        '
        ' Анализ продукции гражданского назначения
        '
        If SummaryCheckEdit.Checked Then
            _GoodRow("lawId") = Row("lawId")
            _GoodRow("summary") = Row("summary")
            P.Work.GoodInDocTable.DeleteGood(_GoodRow)
            For Each InRow As DataRowView In InDocView
                P.Work.GoodInDocTable.Rows.Add(New Object() {_GoodRow("id"), InRow("docId")})
            Next
        End If
        '
        ' Поля проверки данных
        '
        Using ET As New ErrorDataTable(P.Work)
            _GoodRow("isCheckData") = ET.CheckGoodData(_GoodRow)
            _GoodRow("isCheckSummary") = ET.CheckGoodSummary(_GoodRow)
        End Using

        If Not InDocView Is Nothing Then InDocView.Dispose()

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub
  
End Class