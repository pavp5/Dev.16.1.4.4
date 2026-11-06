Imports C2 = Cprp.DxData.Common
''' <summary>
''' Результаты поиска
''' </summary>
''' <remarks></remarks>
Friend Class ResultUserControl

#Region "Данные"

    ''' <summary>
    ''' Заключения экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Private Class DocDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New()
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("orgId", GetType(Integer))
                .Add("docNum", GetType(String))
                .Add("docDate", GetType(Date))
                .Add("conNum", GetType(String))
                .Add("conDate", GetType(Date))
                .Add("rusCaption", GetType(String))
                .Add("rusInn", GetType(String))
                .Add("nusCaption", GetType(String))
                .Add("endCaption", GetType(String))
                .Add("countryName", GetType(String))
                .Add("orgNameLong", GetType(String))
                .Add("orgNameShort", GetType(String))
                .Add("orgInn", GetType(String))
                .Add("orgAddress", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("docId")}
        End Sub
    End Class

    ''' <summary>
    ''' Объекты экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Private Class GoodDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New()
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("docId", GetType(Integer))
                .Add("goodName", GetType(String))
                .Add("goodTnved", GetType(String))
                .Add("goodDescription", GetType(String))
                .Add("isEqual", GetType(Boolean))
                .Add("goodList", GetType(String))
                .Add("goodPos", GetType(String))
                .Add("summary", GetType(String))
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub
    End Class

#End Region


    ''' <summary>
    ''' Открыть справку о заключении
    ''' </summary>
    ''' <remarks></remarks>
    Friend Event ReferenceOpen()

    ''' <summary>
    ''' Поиск в базе данных
    ''' </summary>
    ''' <param name="queryString">Строка запроса на выборку данных из vDocOrg</param>
    ''' <remarks></remarks>
    Friend Sub Find(queryString As String)
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open OrElse Not C2.IsText(queryString) Then Exit Sub
        GoodTable.Rows.Clear()
        DocTable.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            '
            ' DocTable
            '
            Cmd.CommandText = queryString
            DocTable.Load(Cmd.ExecuteReader)
            '
            ' GoodTable
            '
            Dim sTmp As String = "0"
            For Each Row As DataRow In DocTable.Rows
                sTmp = String.Format("{0}, {1}", sTmp, CInt(Row("id")))
            Next
            Cmd.CommandText = String.Format("SELECT * FROM tGood WHERE docId IN ({0})", sTmp)
            GoodTable.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ''' <summary>
    ''' Количество найденных заключений
    ''' </summary>
    ''' <remarks></remarks>
    Friend ReadOnly Property DocCount As Integer
        Get
            If DocTable Is Nothing Then Return 0
            Return DocTable.Rows.Count
        End Get
    End Property

    ''' <summary>
    ''' ID активного заключения
    ''' </summary>
    ''' <remarks></remarks>
    Friend ReadOnly Property DocId As Integer
        Get
            If DocGridView.FocusedRowHandle < 0 Then Return C2.EMPTY_ID
            Return CInt(DocGridView.GetFocusedDataRow("id"))
        End Get
    End Property


    ''' <summary>
    ''' Открытое соединение с базой данных
    ''' </summary>
    ''' <remarks></remarks>
    Private Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Таблица заключений
    ''' </summary>
    ''' <remarks></remarks>
    Private DocTable As DocDataTable = Nothing

    ''' <summary>
    ''' Таблица объектов экспертизы
    ''' </summary>
    ''' <remarks></remarks>
    Private GoodTable As DataTable = Nothing

    ''' <summary>
    ''' Источник данных для связи таблиц
    ''' </summary>
    ''' <remarks></remarks>
    Private Ds As DataSet = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Connection
        '
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then
            Me.Enabled = False
            Exit Sub
        End If
        Me.Connection = Connection
        '
        ' DocTable, GoodTable, Ds
        '
        DocTable = New DocDataTable
        GoodTable = New GoodDataTable
        Ds = New DataSet
        Ds.Tables.AddRange(New DataTable() {DocTable, GoodTable})
        Dim Relation As New DataRelation("DocGoodRelation", DocTable.Columns("id"), GoodTable.Columns("docId"))
        Ds.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        '
        ' DocGridControl, DocGridView 
        '
        DocGridControl.DataSource = DocTable
        DocGridView.SortInfo.Insert(0, DocNumDocGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
    End Sub

    Private Sub RepositoryItemFindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles RepositoryItemFindButtonEdit.ButtonClick
        DocGridView.Focus()
        FindBarEditItem.EditValue = ""
    End Sub

    Private Sub RepositoryItemFindButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles RepositoryItemFindButtonEdit.EditValueChanging
        DocGridView.FindFilterText = e.NewValue.ToString        
    End Sub

    Private Sub ExcelBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ExcelBarButtonItem.ItemClick
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
            DocGridControl.ExportToXlsx(filePath)
            Using P As New Process
                P.StartInfo.FileName = filePath
                P.StartInfo.Verb = "Open"
                P.StartInfo.WindowStyle = ProcessWindowStyle.Normal
                P.Start()
            End Using
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message), "Поиск")
        End Try
    End Sub

    Private Sub DocGridControl_DoubleClick(sender As Object, e As EventArgs) Handles DocGridControl.DoubleClick
        If DocGridView.FocusedRowHandle >= 0 Then RaiseEvent ReferenceOpen()
    End Sub

End Class
