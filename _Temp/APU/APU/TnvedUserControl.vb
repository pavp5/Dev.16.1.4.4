Imports Cprp.DxData.Common
''' <summary>
''' Элемент управления "ТН ВЭД"
''' </summary>
Friend Class TnvedUserControl : Implements IChildControl

#Region "IChildControl"

    Friend Sub CloseEditor() Implements IChildControl.CloseEDitor
        LawGridView.CloseEditor()
        LawGridView.UpdateCurrentRow()
    End Sub

    Friend Sub BeginDataUpdate() Implements IChildControl.BeginDataUpdate
        LawGridView.CloseEditor()
        LawGridView.UpdateCurrentRow()
        LawGridView.BeginDataUpdate()
    End Sub

    Friend Sub EndDataUpdate() Implements IChildControl.EndDataUpdate
        LawGridView.EndDataUpdate()
        LawGridView.MoveFirst()
    End Sub

#End Region

    ''' <summary>
    ''' Источник данных АПУ
    ''' </summary>
    Private Ds As ApuDataSet = Nothing

    ''' <summary>
    ''' Представление пунктов контрольных списков, отфильтрованное по коду ТН ВЭД
    ''' </summary>
    Private LawView As DataView = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Ds">Источник данных АПУ</param>
    Friend Sub New(ByRef Ds As ApuDataSet)
        InitializeComponent()
        Me.Ds = Ds
        LawView = New DataView(Me.Ds.LawTable) With {.Sort = "sortId", .RowFilter = "id < 0"}
        TnvedRepositoryItemLookUpEdit.DataSource = Me.Ds.TnvedTable
        TnvedRepositoryItemLookUpEdit.SortColumnIndex = 0
        LawGridControl.DataSource = LawView
        LawGridView.SortInfo.Insert(0, SortIdGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
    End Sub

    ' Показать выделенный пункт в дереве контрольных списков
    Private Sub LawShowBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LawShowBarButtonItem.ItemClick
        If LawGridView.FocusedRowHandle < 0 Then Exit Sub
        If Not TypeOf Me.ParentForm Is MainForm Then Exit Sub
        CType(Me.ParentForm, MainForm).LawPosShow(CInt(LawGridView.GetFocusedDataRow("id")))
    End Sub

    ' Изменение текущего кода ТН ВЭД
    Private Sub TnvedRepositoryItemLookUpEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles TnvedRepositoryItemLookUpEdit.EditValueChanging
        Dim sTmp As String = ToText(e.NewValue)
        TnvedDescriptionMemoEdit.Text = Nothing
        Dim Row As DataRow = Ds.TnvedTable.Rows.Find(sTmp)
        If Not Row Is Nothing Then TnvedDescriptionMemoEdit.Text = Row("description").ToString
        Using V As New DataView(Ds.LawTnvedTable) With {.RowFilter = String.Format("code = '{0}'", sTmp)}
            sTmp = "0"
            For Each VRow As DataRowView In V
                sTmp = String.Format("{0}, {1}", sTmp, CInt(VRow("lawId")))
            Next
        End Using
        MyClass.BeginDataUpdate()
        LawView.RowFilter = String.Format("id IN ({0})", sTmp)
        MyClass.EndDataUpdate()
    End Sub

    ' Найти и заменить текст в АПУ
    Private Sub ReplaceBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ReplaceBarButtonItem.ItemClick
        If Ds.LawTable.Rows.Count = 0 Then Exit Sub
        Dim findText As String = Nothing
        Dim replaceText As String = Nothing
        Using F As New FindReplaceForm
            If LawGridView.FocusedRowHandle >= 0 Then
                F.FindText = LawGridView.GetFocusedDataRow("apu").ToString
            End If
            If F.ShowDialog <> DialogResult.OK Then Exit Sub
            findText = F.FindText
            replaceText = F.ReplaceText
        End Using
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        CloseEditor()
        For i As Integer = 0 To Ds.LawTable.Rows.Count - 1
            sTmp = ToText(Ds.LawTable(i)("apu"))
            If Not IsText(sTmp) Then Continue For
            If Not sTmp Like String.Format("*{0}*", findText) Then Continue For
            Ds.LawTable(i)("apu") = sTmp.Replace(findText, replaceText)
            iTmp += 1
        Next
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation(String.Format("Произведено замен: {0}.", iTmp))
    End Sub

End Class
