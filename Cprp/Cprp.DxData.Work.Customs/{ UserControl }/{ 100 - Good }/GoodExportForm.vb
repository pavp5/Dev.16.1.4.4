Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма выгрузки данных объекта экспертизы
''' </summary>
''' <remarks></remarks>
Friend Class GoodExportForm

    ' Главный элемент управления
    Private P As WorkUserControl = Nothing

    ' Строка из таблицы объектов экспертизы, из которой выгружаются данные
    Private _GoodRow As DataRow = Nothing

    ' Таблица со списком объектов экспертизы, в которые загружаются данные
    Private _GoodTable As DataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="MainControl">Главный элемент управления</param> 
    ''' <param name="GoodRow">Строка с объектом экспертизы для выгрузки данных</param>
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
            .Add("isStudy", GetType(Boolean))
        End With
        _GoodTable.PrimaryKey = New DataColumn() {_GoodTable.Columns("id")}
        '
        ' _GoodTable (данные)
        '
        For Each Row As DataRow In P.Work.GoodTable.Rows
            If CInt(Row("id")) = CInt(_GoodRow("id")) Then Continue For
            _GoodTable.Rows.Add(New Object() { _
                                Row("id"), _
                                False, _
                                Row("rowNum"), _
                                Row("nameCon"), _
                                Row("tnved"), _
                                Not IsDBNull(Row("studyDate"))})
        Next
        '
        ' ListGridControl, ListGridView
        '
        ListGridControl.DataSource = _GoodTable
        ListGridView.SortInfo.Insert(0, RowNumGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Me
        '
        Me.Text = String.Format("Выгрузка данных из объекта № {0} ({1})", C2.ToInt(_GoodRow("rowNum")), C2.DelPoint(_GoodRow("nameCon")))
        Me.Width = Screen.GetWorkingArea(Me).Height
        Me.Height = Screen.GetWorkingArea(Me).Height - 100
        Me.CenterToScreen()

    End Sub

    Private Sub GoodExportForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        If _GoodRow Is Nothing Then
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Exit Sub
        End If
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        ListGridView.CloseEditor()
        ListGridView.UpdateCurrentRow()
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        '
        ' Строка id объектов экспертизы, в которые выгружаются данные
        '
        Using V As New DataView(_GoodTable)
            V.RowFilter = "isCheck = True"
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0}, {1}", sTmp, CInt(V(i)("id")))
            Next
        End Using
        '
        ' Проверка наличия выбранных строк в списке объектов экспертизы
        '
        If String.IsNullOrWhiteSpace(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Выберите объекты для выгрузки данных!", "Выгрузка данных")
            Exit Sub
        End If
        '
        ' Проверка, что выбрано, что выгружать
        '
        If Not (NameConCheckEdit.Checked OrElse NameDecCheckEdit.Checked OrElse TypeCheckEdit.Checked OrElse _
                TnvedCheckEdit.Checked OrElse CasCheckEdit.Checked OrElse AreaCheckEdit.Checked OrElse _
                UsedCheckEdit.Checked OrElse DescriptionCheckEdit.Checked OrElse StudyCheckEdit.Checked OrElse _
                EmbargoCheckEdit.Checked OrElse ControlCheckEdit.Checked OrElse RiskCheckEdit.Checked) Then
            Cprp.DxCommon.Messages.ShowWarning("Выберите, что выгружать!", "Выгрузка данных")
            Exit Sub
        End If
        '
        ' Представление таблицы объектов экспертизы с объектами для выгрузки данных
        '
        Using V As New DataView(P.Work.GoodTable)
            V.RowFilter = String.Format("id IN (0{0})", sTmp)
            '
            ' Цикл по представлению (выгрузка данных)
            '
            For Each VRow As DataRowView In V
                '
                ' Регистрационные данные
                '
                If NameConCheckEdit.Checked Then VRow("nameCon") = _GoodRow("nameCon")
                If NameDecCheckEdit.Checked Then
                    VRow("nameDec") = _GoodRow("nameDec")
                    VRow("isNotDec") = _GoodRow("isNotDec")
                End If
                If TypeCheckEdit.Checked Then VRow("typeId") = _GoodRow("typeId")
                If TnvedCheckEdit.Checked Then
                    VRow("tnved") = _GoodRow("tnved")
                    VRow("tnvedComment") = _GoodRow("tnvedComment")
                End If
                If CasCheckEdit.Checked Then VRow("cas") = _GoodRow("cas")
                If AreaCheckEdit.Checked Then VRow("area") = _GoodRow("area")
                If UsedCheckEdit.Checked Then VRow("used") = _GoodRow("used")
                If DescriptionCheckEdit.Checked Then VRow("description") = _GoodRow("description")
                '
                ' Исследование по контрольным спискам
                '
                If StudyCheckEdit.Checked Then
                    P.Work.GoodLawTable.DeleteGood(VRow("id"))
                    Using V1 As DataView = P.Work.GoodLawTable.GoodView(_GoodRow("id"))
                        For Each VRow1 As DataRowView In V1
                            P.Work.GoodLawTable.Rows.Add(New Object() { _
                                                      VRow("id"), _
                                                      VRow1("lawId"), _
                                                      VRow1("lawDescription"), _
                                                      VRow1("goodDescription"), _
                                                      VRow1("isFindTnved"), _
                                                      VRow1("isFindCAS"), _
                                                      VRow1("isFindWord"), _
                                                      VRow1("summaryId")})
                        Next
                    End Using
                    '
                    ' Параметры исследования
                    '
                    VRow("studyDate") = _GoodRow("studyDate")
                    VRow("studyTnved") = _GoodRow("studyTnved")
                    VRow("studyWord") = _GoodRow("studyWord")
                    VRow("studySummaryId") = _GoodRow("studySummaryId")
                    VRow("studySummary") = _GoodRow("studySummary")
                    VRow("isCheckStudy") = _GoodRow("isCheckStudy")
                End If
                '
                ' Запреты и ограничения
                '
                If EmbargoCheckEdit.Checked Then
                    P.Work.GoodEmbargoTable.DeleteGood(VRow("id"))
                    Using V1 As DataView = P.Work.GoodEmbargoTable.GoodView(_GoodRow("id"))
                        For Each VRow1 As DataRowView In V1
                            P.Work.GoodEmbargoTable.Rows.Add(New Object() { _
                                                          VRow("id"), _
                                                          VRow1("embargoGoodId")})
                        Next
                    End Using
                    '
                    ' Параметры запретов и ограничений
                    '
                    VRow("isNotEmbargo") = _GoodRow("isNotEmbargo")
                    VRow("isCheckEmbargo") = _GoodRow("isCheckEmbargo")
                End If
                '
                ' На контроле
                '
                If ControlCheckEdit.Checked Then
                    P.Work.GoodControlTable.DeleteGood(VRow("id"))
                    Using V1 As DataView = P.Work.GoodControlTable.GoodView(_GoodRow("id"))
                        For Each VRow1 As DataRowView In V1
                            P.Work.GoodControlTable.Rows.Add(New Object() { _
                                                          VRow("id"), _
                                                          VRow1("controlGoodId")})
                        Next
                    End Using
                    '
                    ' Параметры продукции на контроле
                    '
                    VRow("isNotControl") = _GoodRow("isNotControl")
                    VRow("isCheckControl") = _GoodRow("isCheckControl")
                End If
                '
                ' Риски
                '
                If RiskCheckEdit.Checked Then
                    P.Work.GoodRiskTable.DeleteGood(VRow("id"))
                    Using V1 As DataView = P.Work.GoodRiskTable.GoodView(_GoodRow("id"))
                        For Each VRow1 As DataRowView In V1
                            P.Work.GoodRiskTable.Rows.Add(New Object() { _
                                                       VRow("id"), _
                                                       VRow1("riskId")})
                        Next
                    End Using
                    '
                    ' Параметры рисков
                    '
                    VRow("isNotRisk") = _GoodRow("isNotRisk")
                    VRow("otherRisk") = _GoodRow("otherRisk")
                    VRow("isCheckRisk") = _GoodRow("isCheckRisk")
                End If
            Next
            '
            ' Поле проверки регистрационных данных
            '
            Using ET As New ErrorDataTable(P.Work)
                For Each VRow As DataRowView In V
                    VRow("isCheckData") = ET.CheckGoodData(VRow.Row)
                Next
            End Using
        End Using

        Me.DialogResult = Windows.Forms.DialogResult.OK

    End Sub

    Private Sub SelectAllCheckEdit_CheckedChanged(sender As Object, e As EventArgs) Handles SelectAllCheckEdit.CheckedChanged
        Dim bTmp As Integer = SelectAllCheckEdit.Checked
        Dim iTmp As Integer = 0
        While ListGridView.IsValidRowHandle(iTmp)
            ListGridView.GetDataRow(iTmp)("isCheck") = bTmp
            iTmp += 1
        End While
        ListGridView.RefreshData()
    End Sub

End Class