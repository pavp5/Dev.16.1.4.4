Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления "Данные из базы"
''' </summary>
Friend Class BaseDataUserControl

    ''' <summary>
    ''' Объект SqlCommand для выполнения запросов к базе данных
    ''' </summary>
    Private Command As SqlCommand = Nothing

    ''' <summary>
    ''' Таблица ключевых слов
    ''' </summary>
    Private WordTable As DataTable = Nothing


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
            .Add("id", GetType(Integer))                ' ID
            .Add("root", GetType(String))               ' корень слова
            .Add("ending", GetType(String))             ' окончания слова
            .Add("excontListCount", GetType(Integer))   ' количество связанных пунктов контрольных списков
            .Add("customsListCount", GetType(Integer))  ' количество связанных пунктов единого перечня
            .Add("tnvedCount", GetType(Integer))        ' количество связанных кодов ТН ВЭД
            .Add("isDel", GetType(Boolean))             ' слово удалено
            .Add("isUpdate", GetType(Boolean))          ' служебное поле для различных операций с данными
        End With
        WordTable.Columns("id").AllowDBNull = False
        WordTable.Columns("root").AllowDBNull = False
        With WordTable.Columns("tnvedCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With WordTable.Columns("excontListCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With WordTable.Columns("customsListCount")
            .AllowDBNull = False
            .DefaultValue = 0
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
        ' WordGridControl, WordGridView
        '
        WordGridControl.DataSource = WordTable
        WordGridView.SortInfo.Insert(0, RootGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)

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
        Try
            WordTable.Rows.Clear()
            WordTable.ReadXml(filePath)
            Me.ParentForm.Text = "Данные загружены"
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            WordGridView.EndDataUpdate()
            WordGridView.MoveFirst()
        End Try
    End Sub

    ' Сохранить данные в базу
    Private Sub DataSaveBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveBaseBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить данные в базу?") <> DialogResult.Yes Then Exit Sub
        WordGridView.CloseEditor()
        WordGridView.UpdateCurrentRow()
        '
        ' Удаление строк, помеченных как удаленные
        '
        Using V As New DataView(WordTable) With {.RowFilter = "isDel = True"}
            If V.Count > 0 Then
                If Cprp.DxCommon.Messages.ShowQuestion("В таблице есть строки помеченые как удаленные. Эти строки будут окончательно удалены в базе данных. Продолжить?") <> DialogResult.Yes Then Exit Sub
            End If
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        '
        ' Сохранение данных
        '
        Try
            Using A As New SqlDataAdapter("SELECT id, root, ending, excontListCount, customsListCount, tnvedCount FROM tWord", Command.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(WordTable)
            End Using
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.")
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(ex.Message)
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
        WordTable.AcceptChanges()
        WordTable.WriteXml(filePath)
        Me.ParentForm.Text = "Данные сохранены"
        Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.")
    End Sub

    ' Выполнить запрос и загрузить данные из базы
    Private Sub SelectRepositoryItemButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles SelectRepositoryItemButtonEdit.ButtonClick
        Dim sTmp As String = C2.ToText(SelectBarEditItem.EditValue)
        If Not C2.IsText(sTmp) Then Exit Sub
        If Cprp.DxCommon.Messages.ShowQuestion("Загрузить данные из базы?") <> DialogResult.Yes Then Exit Sub
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        WordGridView.BeginDataUpdate()
        Try
            WordTable.Rows.Clear()
            Command.CommandText = "SELECT * FROM tWord WHERE " & sTmp
            WordTable.Load(Command.ExecuteReader)
            Me.ParentForm.Text = "Данные загружены"
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные загружены.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            WordGridView.EndDataUpdate()
            WordGridView.MoveFirst()
        End Try
    End Sub

    ' Преобразовать данные
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
        Using V As New DataView(WordTable)
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
                root = C2.ToText(Row("root"))
                iTmp = root.IndexOf(" ")
                If iTmp > 0 Then root = root.Substring(0, iTmp)
                V.RowFilter = String.Format("isDel = False AND (root LIKE '{0}' OR root LIKE '{0} %')", root)
                ending = Nothing
                For Each VRow As DataRowView In V
                    sTmp = C2.ToText(VRow("root"))
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
                    V(i)("root") = root
                    V(i)("ending") = ending
                    V(i)("isUpdate") = True
                    V(i)("isDel") = (i > 0)
                Next
            Next
        End Using
        WordGridView.EndDataUpdate()
        WordGridView.MoveFirst()
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation("Операция завершена.")
    End Sub

    ' Перечитать связи ключевых слов с нормативными документами
    Private Sub LinkLawBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LinkLawBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Перечитать в базе данных связи ключевых слов с нормативными документами?") <> DialogResult.Yes Then Exit Sub
        Dim root As String = Nothing
        Dim wordId As Integer = 0
        Dim iCount As Integer = 0
        Dim sTmp As String = Nothing
        Dim arr() As String = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            For Each Row As DataRow In WordTable.Rows
                iCount += 1
                Me.ParentForm.Text = String.Format("Обновление связей ({0} из {1})", iCount, WordTable.Rows.Count)
                Application.DoEvents()
                root = C2.ToText(Row("root"))
                wordId = CInt(Row("id"))
                Command.CommandText = String.Format("DELETE FROM tWordLaw WHERE wordId = {0}", wordId)
                Command.ExecuteNonQuery()
                Command.CommandText = String.Format("SELECT id FROM tLaw WHERE description LIKE '{0}%' OR description LIKE '% {0}%'", root)
                Using Dr As SqlDataReader = Command.ExecuteReader
                    sTmp = Nothing
                    While Dr.Read
                        sTmp = String.Format("INSERT tWordLaw(wordId, lawId) VALUES({0}, {1}){2}{3}", wordId, CInt(Dr(0)), C2.FIELD_SEPARATOR, sTmp)
                    End While
                End Using
                If Not String.IsNullOrWhiteSpace(sTmp) Then
                    arr = sTmp.Split(New Char() {C2.FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
                    For Each sTmp In arr
                        Command.CommandText = sTmp
                        Command.ExecuteNonQuery()
                    Next
                End If
                Command.CommandText = String.Format("SELECT COUNT(*) FROM tWordLaw WHERE wordId = {0} AND lawId IN (SELECT id FROM tLaw WHERE areaId = 1 AND isList = 1 AND typeId IN (1, 2))", wordId)
                Row("excontListCount") = CInt(Command.ExecuteScalar)
                Command.CommandText = String.Format("SELECT COUNT(*) FROM tWordLaw WHERE wordId = {0} AND lawId IN (SELECT id FROM tLaw WHERE areaId = 3 AND isList = 1 AND typeId IN (1, 2))", wordId)
                Row("customsListCount") = CInt(Command.ExecuteScalar)
            Next
            Me.ParentForm.Text = "Сохранение в tWord количества связанных пунктов ..."
            Using A As New SqlDataAdapter("SELECT id, excontListCount, customsListCount FROM tWord", Command.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(WordTable)
            End Using
            Me.ParentForm.Text = "Операция завершена"
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

    ' Перечитать связи ключевых слов с кодами ТН ВЭД
    Private Sub LinkTnvedBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LinkTnvedBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Перечитать в базе данных связи ключевых слов с кодами ТН ВЭД?") <> DialogResult.Yes Then Exit Sub
        Dim root As String = Nothing
        Dim wordId As Integer = 0
        Dim iCount As Integer = 0
        Dim sTmp As String = Nothing
        Dim arr() As String = Nothing
        Cprp.DxCommon.WaitForm.Show(Me.ParentForm)
        Try
            For Each Row As DataRow In WordTable.Rows
                iCount += 1
                Me.ParentForm.Text = String.Format("Обновление связей ({0} из {1})", iCount, WordTable.Rows.Count)
                Application.DoEvents()
                root = C2.ToText(Row("root"))
                wordId = CInt(Row("id"))
                Command.CommandText = String.Format("DELETE FROM tWordTnved WHERE wordId = {0}", wordId)
                Command.ExecuteNonQuery()
                Command.CommandText = String.Format("SELECT DISTINCT code FROM tTnved WHERE description LIKE '{0}%' OR description LIKE '% {0}%'", root)
                Using Dr As SqlDataReader = Command.ExecuteReader
                    While Dr.Read
                        sTmp = String.Format("INSERT tWordTnved(wordId, tnved) VALUES({0}, '{1}'){2}{3}", wordId, C2.ToText(Dr(0)), C2.FIELD_SEPARATOR, sTmp)
                    End While
                End Using
                If Not String.IsNullOrWhiteSpace(sTmp) Then
                    arr = sTmp.Split(New Char() {C2.FIELD_SEPARATOR}, StringSplitOptions.RemoveEmptyEntries)
                    For Each sTmp In arr
                        Command.CommandText = sTmp
                        Command.ExecuteNonQuery()
                    Next
                End If
                Command.CommandText = String.Format("SELECT COUNT(*) FROM tWordTnved WHERE wordId = {0}", wordId)
                Row("tnvedCount") = CInt(Command.ExecuteScalar)
            Next
            Me.ParentForm.Text = "Сохранение в tWord количества связанных пунктов ..."
            Using A As New SqlDataAdapter("SELECT id, tnvedCount FROM tWord", Command.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(WordTable)
            End Using
            Me.ParentForm.Text = "Операция завершена"
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        End Try
    End Sub

End Class
