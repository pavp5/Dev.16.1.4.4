Imports C2 = Cprp.DxData.Common
''' <summary>
''' Результаты поиска
''' </summary>
''' <remarks></remarks>
Friend Class FindResultUserControl0

    ''' <summary>
    ''' Открыть сведения о работе
    ''' </summary>
    ''' <remarks></remarks>
    Friend Event OpenWork()

    ''' <summary>
    ''' ID работы, выделеной в списке результатов поиска
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property WorkId As Integer
        Get
            If WorkGridView.FocusedRowHandle >= 0 Then Return (CInt(WorkGridView.GetFocusedDataRow("id")))
            Return C2.EMPTY_ID
        End Get
    End Property

    ''' <summary>
    ''' Количество найденных работ
    ''' </summary>
    ''' <remarks></remarks>
    Friend ReadOnly Property FindCount As Integer
        Get
            Return _WorkTable.Rows.Count
        End Get
    End Property

    ' Открытое соединение с архивной базой данных
    Private _Connection As SqlConnection = Nothing

    ' Таблица работ
    Private _WorkTable As DataTable = Nothing

    ' Таблица объектов экспертизы
    Private _GoodTable As DataTable = Nothing

    ' Таблица участников внешнеэкономических операций
    Private _MemberTable As DataTable = Nothing

    ' Таблица представленных документов
    Private _InDocTable As DataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с архивной базой данных</param>
    ''' <remarks></remarks>
    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' _Connection
        '
        _Connection = Connection
        '
        ' Таблица работ
        '
        _WorkTable = New DataTable
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = "SELECT * FROM vWorkData WHERE id IS NULL"
            _WorkTable.Load(Cmd.ExecuteReader)
        End Using
        _WorkTable.DefaultView.Sort = "workId"
        '
        ' Таблица объектов экспертизы
        '
        _GoodTable = New DataTable
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = "SELECT id, workId, nameConDec, nameCon, nameDec, tnved, area, used, description FROM vGoodData WHERE id IS NULL"
            _GoodTable.Load(Cmd.ExecuteReader)
        End Using
        _GoodTable.DefaultView.Sort = "nameConDec"
        '
        ' Таблица участников операций
        '
        _MemberTable = New DataTable
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = "SELECT DISTINCT workId, caption FROM vMemberData WHERE id IS NULL"
            _MemberTable.Load(Cmd.ExecuteReader)
        End Using
        _MemberTable.DefaultView.Sort = "caption"
        '
        ' Таблица представленных документов
        '
        _InDocTable = New DataTable
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = "SELECT id, workId, captionNumDate, docUrl FROM vInDoc WHERE id IS NULL"
            _InDocTable.Load(Cmd.ExecuteReader)
        End Using
        _InDocTable.DefaultView.Sort = "captionNumDate"
        '
        ' Список работ
        '
        WorkGridControl.DataSource = _WorkTable.DefaultView
        WorkGridView.SortInfo.Insert(0, WorkIdWorkGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Список объектов экспертизы
        '
        GoodGridControl.DataSource = _GoodTable.DefaultView
        GoodGridView.SortInfo.Insert(0, NameConDecGoodGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Список участников операции
        '
        MemberGridControl.DataSource = _MemberTable.DefaultView
        MemberGridView.SortInfo.Insert(0, CaptionMemberGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Список представленных документов
        '
        InDocGridControl.DataSource = _InDocTable.DefaultView
        InDocGridView.SortInfo.Insert(0, CaptionRegDateInDocGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

    End Sub

    ''' <summary>
    ''' Начать поиск в базе данных
    ''' </summary>
    ''' <param name="QueryString">Строка запроса на выборку данных</param>
    ''' <remarks></remarks>
    Friend Sub SetFind(QueryString As String)
        WorkGridControl.BeginUpdate()
        GoodGridControl.BeginUpdate()
        MemberGridView.BeginUpdate()
        InDocGridView.BeginUpdate()
        Try
            _InDocTable.Rows.Clear()
            _MemberTable.Rows.Clear()
            _GoodTable.Rows.Clear()
            _WorkTable.Rows.Clear()
            Using Cmd As New SqlCommand With {.Connection = _Connection, .CommandText = QueryString}
                _WorkTable.Load(Cmd.ExecuteReader)
                Dim sTmp As String = "0"
                For i As Integer = 0 To _WorkTable.Rows.Count - 1
                    sTmp = String.Format("{0}, {1}", sTmp, CInt(_WorkTable(i)("id")))
                Next
                Cmd.CommandText = String.Format("SELECT id, workId, nameConDec, nameCon, nameDec, tnved, area, used, description FROM vGoodData WHERE workId IN ({0})", sTmp)
                _GoodTable.Load(Cmd.ExecuteReader)
                Cmd.CommandText = String.Format("SELECT DISTINCT workId, caption FROM vMemberData WHERE workId IN ({0})", sTmp)
                _MemberTable.Load(Cmd.ExecuteReader)
                Cmd.CommandText = String.Format("SELECT id, workId, captionNumDate, docUrl FROM vInDoc WHERE workId IN ({0})", sTmp)
                _InDocTable.Load(Cmd.ExecuteReader)
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            WorkGridControl.EndUpdate()
            GoodGridControl.EndUpdate()
            MemberGridView.EndUpdate()
            InDocGridView.EndUpdate()
            WorkGridView_FocusedRowChanged(Nothing, Nothing)
        End Try
    End Sub

    Private Sub WorkGridView_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles WorkGridView.FocusedRowChanged
        Dim iTmp As Integer = C2.EMPTY_ID
        If WorkGridView.FocusedRowHandle >= 0 Then iTmp = C2.ToInt(WorkGridView.GetFocusedDataRow("id"))
        _GoodTable.DefaultView.RowFilter = String.Format("workId = {0}", iTmp)
        GoodDockPanel.Text = String.Format("Объекты экспертизы ({0})", _GoodTable.DefaultView.Count)
        _MemberTable.DefaultView.RowFilter = String.Format("workId = {0}", iTmp)
        MemberDockPanel.Text = String.Format("Участники операции ({0})", _MemberTable.DefaultView.Count)
        _InDocTable.DefaultView.RowFilter = String.Format("workId = {0}", iTmp)
        InDocDockPanel.Text = String.Format("Представленные документы ({0})", _InDocTable.DefaultView.Count)
    End Sub

    Private Sub WorkGridControl_DoubleClick(sender As Object, e As EventArgs) Handles WorkGridControl.DoubleClick
        If WorkGridView.FocusedRowHandle >= 0 Then RaiseEvent OpenWork()
    End Sub

    ' Открыть форму сведений об объекте экспертизы
    Private Sub GoodRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles GoodRepositoryItemButtonEdit.ButtonClick
        If GoodGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim iTmp As Integer = CInt(GoodGridView.GetFocusedDataRow("id"))
        For Each F As Form In Application.OpenForms
            If Not TypeOf F Is GoodForm Then Continue For
            If CType(F, GoodForm).GoodId = iTmp Then
                F.WindowState = FormWindowState.Normal
                F.TopMost = True
                F.TopMost = False
                Exit Sub
            End If
        Next
        With New GoodForm(GoodGridView.GetFocusedDataRow)
            .Show(Me.ParentForm)
        End With
    End Sub

    Private Sub GoodGridControl_DoubleClick(sender As Object, e As EventArgs) Handles GoodGridControl.DoubleClick
        GoodRepositoryItemButtonEdit_ButtonClick(Nothing, Nothing)
    End Sub

    Private Sub GoodRepositoryItemButtonEdit_DoubleClick(sender As Object, e As EventArgs) Handles GoodRepositoryItemButtonEdit.DoubleClick
        GoodRepositoryItemButtonEdit_ButtonClick(Nothing, Nothing)
    End Sub

    ' Открыть карточку представленного документа
    Private Sub InDocRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles InDocRepositoryItemButtonEdit.ButtonClick
        If InDocGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = C2.ToText(InDocGridView.GetFocusedDataRow("docUrl"))
        If Not C2.IsText(sTmp) Then
            Cprp.DxCommon.Messages.ShowWarning("Ссылка на карточку документа отсутствует.", "Поиск")
            Exit Sub
        End If
        Try
            Using P As New Process
                P.StartInfo.FileName = sTmp
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    Private Sub InDocGridControl_DoubleClick(sender As Object, e As EventArgs) Handles InDocGridControl.DoubleClick
        InDocRepositoryItemButtonEdit_ButtonClick(Nothing, Nothing)
    End Sub

    Private Sub InDocRepositoryItemButtonEdit_DoubleClick(sender As Object, e As EventArgs) Handles InDocRepositoryItemButtonEdit.DoubleClick
        InDocRepositoryItemButtonEdit_ButtonClick(Nothing, Nothing)
    End Sub

    ' Экспорт списка в Excel
    Private Sub ExportToXlsBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExportToXlsBarButtonItem.ItemClick
        If WorkGridView.RowCount = 0 Then Exit Sub
        Try
            Dim filePath As String = Nothing
            Using Dlg As New SaveFileDialog
                Dlg.Title = "Выбор файла для сохранения данных"
                Dlg.FileName = "Результаты поиска"
                Dlg.DefaultExt = "xlsx"
                Dlg.Filter = "Файл Microsoft Excel (*.xlsx)|*.xlsx"
                If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
                filePath = Dlg.FileName
            End Using
            WorkGridView.ExportToXlsx(filePath)
            Using P As New Process
                P.StartInfo.FileName = filePath
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Открыть карточку заказа к работе
    Private Sub OpenOrderBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenOrderBarButtonItem.ItemClick
        If WorkGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim sTmp As String = C2.ToText(WorkGridView.GetFocusedDataRow("orderUrl"))
        If Not C2.IsText(sTmp) Then
            Cprp.DxCommon.Messages.ShowError("Отсутствует ссылка на карточку заказа.", "Поиск")
        Else
            Try
                Using P As New Process
                    P.StartInfo.FileName = sTmp
                    P.StartInfo.Verb = "Open"
                    P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                    P.Start()
                End Using
            Catch ex As Exception
                Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
            End Try
        End If
    End Sub

End Class
