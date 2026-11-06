Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Новые данные"
''' </summary>
Friend Class NewDataUserControl

    ''' <summary>
    ''' Объект SqlCommand для выполнения запросов к базе данных
    ''' </summary>
    Private Command As SqlCommand = Nothing

    ''' <summary>
    ''' Таблица ключевых слов
    ''' </summary>
    Private WordTable As DataTable = Nothing

    ''' <summary>
    ''' Временная таблица для хранения результатов запросов на выборку данных
    ''' </summary>
    Private TempTable As DataTable = Nothing

    ''' <summary>
    ''' Источник данных
    ''' </summary>
    Private Ds As DataSet = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных</param>
    Friend Sub New(Connection As SqlConnection)
        InitializeComponent()
        '
        ' Command
        '
        Me.Command = New SqlCommand With {.Connection = Connection}
        '
        ' WordTable
        '
        WordTable = New DataTable("WordTable")
        With WordTable.Columns
            .Add("id", GetType(Integer))            ' ID
            .Add("word", GetType(String))           ' исходное слово
            .Add("root", GetType(String))           ' корень слова
            .Add("ending", GetType(String))         ' окончания слова
            .Add("isDouble", GetType(Boolean))      ' дубликат другого слова
            .Add("isDel", GetType(Boolean))         ' слово удалено
            .Add("isUpdate", GetType(Boolean))      ' служебное поле для различных операций с данными
        End With
        WordTable.Columns("id").AllowDBNull = False
        WordTable.Columns("word").AllowDBNull = False
        With WordTable.Columns("isDouble")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With WordTable.Columns("isDel")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With WordTable.Columns("isUpdate")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        WordTable.PrimaryKey = New DataColumn() {WordTable.Columns("id")}
        '
        ' TempTable
        '
        TempTable = New DataTable("TempTable")
        With TempTable.Columns
            .Add("id", GetType(Integer))        ' ID
            .Add("temp", GetType(String))       ' исходный текст
        End With
        TempTable.PrimaryKey = New DataColumn() {TempTable.Columns("id")}
        '
        ' Ds
        '
        Ds = New DataSet("WordData")
        Ds.Tables.AddRange(New DataTable() {WordTable, TempTable})
        '
        ' WordGridControl, WordGridView
        '
        WordGridControl.DataSource = WordTable
        WordGridView.SortInfo.Insert(0, WordGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' TempGridControl, TempGridView
        '
        TempGridControl.DataSource = TempTable
        TempGridView.SortInfo.Insert(0, TempGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

    End Sub


    ' Загрузить данные из файла XML
    Private Sub DataLoadFileBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLoadFileBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор файла для загрузки данных"
            Dlg.DefaultExt = "xml"
            Dlg.Filter = "Файл XML (*.xml)|*.xml"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        WordGridView.BeginDataUpdate()
        TempGridView.BeginDataUpdate()
        Try
            Ds.Clear()
            Ds.ReadXml(filePath, XmlReadMode.IgnoreSchema)
            Me.ParentForm.Text = "Данные загружены"
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            WordGridView.EndDataUpdate()
            WordGridView.MoveFirst()
            TempGridView.EndDataUpdate()
            TempGridView.MoveFirst()
        End Try
    End Sub

    ' Сохранить перечень ключевых слов в базу данных
    Private Sub DataSaveBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveBaseBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить данные в базу?") <> DialogResult.Yes Then Exit Sub
        Dim id As Integer = 0
        Dim root As String = Nothing
        Dim ending As String = Nothing
        Dim iTmp As Integer = 0
        Dim iCount As Integer = 0
        Dim arr() As String = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        '
        ' Временная таблица для загрузки данных в базу
        '
        Dim T As New DataTable
        With T.Columns
            .Add("id", GetType(Integer))
            .Add("root", GetType(String))
            .Add("ending", GetType(String))
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        Try
            '
            ' Начальное id новой строки
            '
            Command.CommandText = "SELECT ISNULL(MAX(id), 0) FROM tWord"
            id = CInt(Command.ExecuteScalar) + 1
            '
            ' Обновление данных в базе, загрузка новых данных
            '
            Using V As New DataView(WordTable) With {.RowFilter = "isDouble = False AND isDel = False"}
                For Each VRow As DataRowView In V
                    iCount += 1
                    Me.ParentForm.Text = String.Format("Обновление данных в базе, загрузка новых данных ({0} из {1})", iCount, V.Count)
                    Application.DoEvents()
                    root = C2.ToText(VRow("root"))
                    ending = C2.ToText(VRow("ending"))
                    Command.CommandText = String.Format("SELECT ISNULL(MAX(id), 0) FROM tWord WHERE root LIKE '{0}'", root.Replace("'", "''"))
                    iTmp = CInt(Command.ExecuteScalar)
                    If iTmp = 0 Then
                        T.Rows.Add(New Object() {id, root, ending})
                        id += 1
                    ElseIf C2.IsText(ending) Then
                        Command.CommandText = String.Format("SELECT ending FROM tWord WHERE id = {0}", iTmp)
                        ending &= "," & C2.ToText(Command.ExecuteScalar)
                        ending = ending.Replace(" ", Nothing)
                        arr = ending.Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)
                        Array.Sort(arr)
                        ending = Nothing
                        For i As Integer = arr.GetLowerBound(0) To arr.GetUpperBound(0)
                            If i = 0 OrElse arr(i) <> arr(i - 1) Then
                                ending = String.Format("{0}, {1}", ending, arr(i))
                            End If
                        Next
                        ending = ending.Substring(2)
                        Command.CommandText = String.Format("UPDATE tWord SET ending = '{0}' WHERE id = {1}", ending, iTmp)
                        Command.ExecuteNonQuery()
                    End If
                Next
            End Using
            '
            ' Сохранение новых данных
            '
            Me.ParentForm.Text = "Сохранение новых данных ..."
            Application.DoEvents()
            Using A As New SqlDataAdapter("SELECT id, root, ending FROM tWord", Command.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(T)
            End Using
            Me.ParentForm.Text = "Данные загружены"
            Application.DoEvents()
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            T.Dispose()
        End Try
    End Sub

    ' Сохранить данные в файл XML
    Private Sub DataSaveFileBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveFileBarButtonItem.ItemClick
        Dim filePath As String = Nothing
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Выбор файла для сохранения данных"
            Dlg.DefaultExt = "xml"
            Dlg.Filter = "Файл XML (*.xml)|*.xml"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        WordGridView.CloseEditor()
        WordGridView.UpdateCurrentRow()
        Ds.AcceptChanges()
        Ds.WriteXml(filePath, XmlWriteMode.WriteSchema)
        Me.ParentForm.Text = "Данные сохранены"
        Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.")
    End Sub

    ' Выполнить запрос и загрузить новые данные
    Private Sub SelectRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles SelectRepositoryItemButtonEdit.ButtonClick
        Dim sTmp As String = BarManager1.ActiveEditor.Text
        If Not C2.IsText(sTmp) Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Выполнить запрос и создать новый перечень ключевых слов?") <> DialogResult.Yes Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        WordGridView.BeginDataUpdate()
        TempGridView.BeginDataUpdate()
        Try
            Ds.Clear()
            '
            ' Выполнение запроса к базе, загрузка временных данных
            '
            Dim i As Integer = 0
            Using T As New DataTable
                Command.CommandText = "SELECT " & sTmp
                T.Load(Command.ExecuteReader)
                If T.Columns.Count > 0 Then
                    Dim colId As Integer = T.Columns.IndexOf("description")
                    If colId < 0 Then colId = 0
                    For i = 0 To T.Rows.Count - 1
                        TempTable.Rows.Add(New Object() {i + 1, C2.ToText(T(i)(colId)).ToLower})
                    Next
                End If
            End Using
            '
            ' Начальное id для нового перечня ключевых слов
            '
            Dim rowId As Integer = 1
            '
            ' Создание нового перечня ключевых слов по временным данным
            '
            Dim iCount As Integer = 0
            Dim arr() As String = Nothing
            Using V As New DataView(WordTable)
                For Each Row As DataRow In TempTable.Rows
                    iCount += 1
                    Me.ParentForm.Text = String.Format("Создание таблицы ключевых слов ({0} из {1})", iCount, TempTable.Rows.Count)
                    Application.DoEvents()
                    sTmp = C2.ToText(Row("temp"))
                    If Not C2.IsText(sTmp) Then Continue For
                    For Each c As Char In sTmp
                        If c = C2.FIELD_SEPARATOR Then Continue For
                        If c = "-" Then Continue For
                        i = Asc(c)
                        If i >= 65 AndAlso i <= 90 Then Continue For
                        If i >= 97 AndAlso i <= 122 Then Continue For
                        If i >= 192 AndAlso i <= 255 Then Continue For
                        sTmp = sTmp.Replace(c, C2.FIELD_SEPARATOR)
                    Next
                    arr = sTmp.Split(New Char() {C2.FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
                    For Each sTmp In arr
                        If sTmp Like "-*" Then sTmp = sTmp.Substring(1)
                        If sTmp Like "*-" Then sTmp = sTmp.Substring(0, sTmp.Length - 1)
                        If sTmp.Length < 4 Then Continue For
                        V.RowFilter = String.Format("word LIKE '{0}'", sTmp)
                        If V.Count = 0 Then
                            WordTable.Rows.Add(New Object() {rowId, sTmp, DBNull.Value, DBNull.Value, False, False})
                            rowId += 1
                        End If
                    Next
                Next
            End Using
            Me.ParentForm.Text = "Сформирован новый перечень ключевых слов"
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Сформирован новый перечень ключевых слов.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            WordGridView.EndDataUpdate()
            WordGridView.MoveFirst()
            TempGridView.EndDataUpdate()
        End Try
    End Sub

    ' Преобразовать перечень ключевых слов
    Private Sub ListUpdateBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ListUpdateBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Преобразовать данные?") <> DialogResult.Yes Then Exit Sub
        Dim root As String = Nothing
        Dim ending As String = Nothing
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Dim iCount As Integer = 0
        Dim arr() As String = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        WordGridView.BeginDataUpdate()
        Using V As New DataView(WordTable) With {.Sort = "word"}
            '
            ' Обновление поля isUpdate
            '
            Me.ParentForm.Text = "Обновление поля isUpdate ..."
            Application.DoEvents()
            V.RowFilter = "isUpdate = True"
            While V.Count > 0
                V(0)("isUpdate") = False
            End While
            '
            ' Преобразование данных
            '
            For Each Row As DataRow In WordTable.Rows
                iCount += 1
                Me.ParentForm.Text = String.Format("Преобразование данных ({0} из {1})", iCount, WordTable.Rows.Count)
                Application.DoEvents()
                If CBool(Row("isUpdate")) Then Continue For
                root = C2.ToText(Row("word"))
                iTmp = root.IndexOf(" ")
                If iTmp > 0 Then root = root.Substring(0, iTmp)
                V.RowFilter = String.Format("isDel = False AND (word LIKE '{0}' OR word LIKE '{0} %')", root)
                ending = Nothing
                For Each VRow As DataRowView In V
                    sTmp = C2.ToText(VRow("word"))
                    iTmp = sTmp.IndexOf(" ")
                    If iTmp > 0 Then ending = String.Format("{0}, {1}", ending, sTmp.Substring(iTmp + 1))
                    sTmp = C2.ToText(VRow("ending"))
                    If C2.IsText(sTmp) Then ending = String.Format("{0}, {1}", ending, sTmp)
                Next
                If C2.IsText(ending) Then
                    ending = Trim(ending.Replace(" ", Nothing))
                    arr = ending.Split(New Char() {","}, StringSplitOptions.RemoveEmptyEntries)
                    Array.Sort(arr)
                    ending = Nothing
                    For i As Integer = arr.GetLowerBound(0) To arr.GetUpperBound(0)
                        If i = 0 OrElse arr(i) <> arr(i - 1) Then
                            ending = String.Format("{0}, {1}", ending, arr(i))
                        End If
                    Next
                    ending = ending.Substring(2)
                End If
                For i As Integer = 0 To V.Count - 1
                    V(i)("root") = root.ToUpper
                    V(i)("ending") = If(ending Is Nothing, DBNull.Value, ending.ToLower)
                    V(i)("isUpdate") = True
                    V(i)("isDouble") = (i > 0)
                Next
            Next
        End Using
        WordGridView.EndDataUpdate()
        WordGridView.MoveFirst()
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation("Операция завершена.")
    End Sub

    ' Фильтрация исходного текста по текущему ключевому слову
    Private Sub TempGridView_GotFocus(sender As Object, e As EventArgs) Handles TempGridView.GotFocus
        Dim sTmp As String = Nothing
        Dim Row As DataRow = WordGridView.GetFocusedDataRow
        If Not Row Is Nothing Then
            sTmp = C2.ToText(Row("word"))
            If C2.IsText(sTmp) Then
                Dim iTmp As Integer = sTmp.IndexOf(" ")
                If iTmp > 0 Then sTmp = sTmp.Substring(0, iTmp)
            End If
        End If
        TempGridView.FindFilterText = sTmp
    End Sub

    Private Sub SelectRepositoryItemButtonEdit_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs) Handles SelectRepositoryItemButtonEdit.EditValueChanging
        'Me.ParentForm.Text = e.NewValue.ToString
    End Sub

End Class
