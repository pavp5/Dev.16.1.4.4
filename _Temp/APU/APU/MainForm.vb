Imports Cprp.DxData.Common
''' <summary>
''' Главная форма приложения
''' </summary>
Friend Class MainForm

    ''' <summary>
    ''' Источник данных АПУ
    ''' </summary>
    Private Ds As ApuDataSet = Nothing

    ''' <summary>
    ''' Элемент управления "Списки"
    ''' </summary>
    Private EditLawControl As LawUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "ТН ВЭД"
    ''' </summary>
    Private EditTnvedControl As TnvedUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "АПУ"
    ''' </summary>
    Private WithEvents ApuControl As ApuUserControl = Nothing

    ''' <summary>
    ''' Элемент управления "Синонимы"
    ''' </summary>
    Private SynonControl As SynonUserControl = Nothing

    ''' <summary>
    ''' Путь к файлу с источником данных
    ''' </summary>
    Private Property FilePath As String = Nothing

    ''' <summary>
    ''' Пользователь системы
    ''' </summary>
    Private DbClient As Cprp.DxData.User.DatabaseUser = Nothing


    Friend Sub New()
        InitializeComponent()
        '
        ' Ds
        '
        Ds = New ApuDataSet
        '
        ' EditLawControl, ApuControl, SynonControl
        '
        EditLawControl = New LawUserControl(Ds) With {.Dock = DockStyle.Fill}
        EditTnvedControl = New TnvedUserControl(Ds) With {.Dock = DockStyle.Fill}
        ApuControl = New ApuUserControl(Ds) With {.Dock = DockStyle.Fill}
        SynonControl = New SynonUserControl(Ds) With {.Dock = DockStyle.Fill}
        MainPanelControl.Controls.AddRange(New Control() {EditLawControl, EditTnvedControl, ApuControl, SynonControl})
        LawBarCheckItem.Checked = True
        '
        ' Dictionary
        '
        If Cprp.DxDictionary.Common.OpenOfficeDictionary Is Nothing OrElse Cprp.DxDictionary.Common.CustomDictionary Is Nothing Then
            SpellChecker1.Dispose()
        Else
            SpellChecker1.Dictionaries.Add(Cprp.DxDictionary.Common.OpenOfficeDictionary)
            SpellChecker1.Dictionaries.Add(Cprp.DxDictionary.Common.CustomDictionary)
        End If
        '
        ' Временно
        '
        TnvedBarCheckItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        'TestBarButtonItem.Visibility = DevExpress.XtraBars.BarItemVisibility.Never
        '
        ' Me
        '
        Me.Icon = My.Resources.tree_ico
        Me.Text = "Редактор АПУ - нет данных"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
    End Sub


    ''' <summary>
    ''' Показать пункт контрольного списка в дереве контрольных списков
    ''' </summary>
    ''' <param name="lawId">ID пункта контрольного списка</param>
    Public Sub LawPosShow(lawId As Integer)
        If EditLawControl Is Nothing Then Exit Sub
        Dim N As DevExpress.XtraTreeList.Nodes.TreeListNode = EditLawControl.LawTreeList.FindNodeByKeyID(lawId)
        If N Is Nothing Then Exit Sub
        LawBarCheckItem.Checked = True
        EditLawControl.LawTreeList.FocusedNode = N
    End Sub


    ' Сохранить данные в файл
    Private Sub DataSaveBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataSaveBarButtonItem.ItemClick
        If Ds.LawTable.Rows.Count = 0 Then
            Cprp.DxCommon.Messages.ShowWarning("Источник данных пустой.")
            Exit Sub
        End If
        Using Dlg As New SaveFileDialog
            Dlg.Title = "Сохранение данных в файл"
            Dlg.Filter = "Файл XML (*.xml)|*.xml"
            If Not String.IsNullOrWhiteSpace(FilePath) AndAlso My.Computer.FileSystem.FileExists(FilePath) Then
                Dlg.FileName = FilePath
            End If
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            FilePath = Dlg.FileName
        End Using
        Try
            EditLawControl.CloseEditor()
            EditTnvedControl.CloseEditor()
            ApuControl.CloseEditor()
            SynonControl.CloseEditor()
            Ds.AcceptChanges()
            Ds.WriteXml(filePath, XmlWriteMode.WriteSchema)
            Me.Text = String.Format("Редактор АПУ - {0}", My.Computer.FileSystem.GetName(FilePath))
        Catch ex As Exception
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Загрузить данные из файла
    Private Sub DataLoadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataLoadBarButtonItem.ItemClick
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.Filter = "Файл XML (*.xml)|*.xml"
            If Not String.IsNullOrWhiteSpace(FilePath) AndAlso My.Computer.FileSystem.FileExists(FilePath) Then
                Dlg.FileName = FilePath
            End If
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            FilePath = Dlg.FileName
        End Using
        Cprp.DxCommon.WaitForm.Show(Me)
        EditLawControl.BeginDataUpdate()
        EditTnvedControl.BeginDataUpdate()
        ApuControl.BeginDataUpdate()
        SynonControl.BeginDataUpdate()
        Try
            'If Ds.LawTable.Rows.Count > 0 Then
            '    Using T As New LawDataTable
            '        T.ReadXml(FilePath)
            '        Dim Row As DataRow = Nothing
            '        Using V As New DataView(T)
            '            V.RowFilter = "apu > '0'"
            '            For Each VRow As DataRowView In V
            '                Row = Ds.LawTable.Rows.Find(VRow("id"))
            '                If Not Row Is Nothing Then Row("apu") = VRow("apu")
            '            Next
            '        End Using
            '    End Using
            'Else
            '    Ds.Clear()
            '    Ds.ReadXml(FilePath, XmlReadMode.IgnoreSchema)
            'End If
            Ds.Clear()
            Ds.ReadXml(FilePath, XmlReadMode.IgnoreSchema)
            Me.Text = String.Format("Редактор АПУ - {0}", My.Computer.FileSystem.GetName(FilePath))
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            EditLawControl.EndDataUpdate()
            EditTnvedControl.EndDataUpdate()
            ApuControl.EndDataUpdate()
            SynonControl.EndDataUpdate()
        End Try
    End Sub

    ' Создать новый источник данных
    Private Sub DataCreateBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataCreateBarButtonItem.ItemClick
        If Ds.LawTable.Rows.Count > 0 Then
            If Cprp.DxCommon.Messages.ShowQuestion("Создать новый источник данных?") <> Windows.Forms.DialogResult.Yes Then Exit Sub
        End If
        If DbClient Is Nothing OrElse DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then
            DbClient = New Cprp.DxData.User.DatabaseUser(False)
        End If
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        Dim Row As DataRow = Nothing
        Cprp.DxCommon.WaitForm.Show(Me)
        EditLawControl.BeginDataUpdate()
        EditTnvedControl.BeginDataUpdate()
        ApuControl.BeginDataUpdate()
        SynonControl.BeginDataUpdate()
        Ds.EnforceConstraints = False
        Try
            Ds.Clear()
            Using Cmd As New SqlCommand With {.Connection = DbClient.Connection}
                Me.Text = "LawTable load ..."
                Application.DoEvents()
                Cmd.CommandText = String.Format( _
                    "SELECT id, parentId, sortId, pos, posDescription, tnved, cas, doc, typeId FROM vLaw " & _
                    "WHERE isList = 1 AND areaId = 1 AND NOT parentId IS NULL AND dateE >= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}}", _
                    CDate("01.01.9999"))
                'Cmd.CommandText = String.Format( _
                '    "SELECT id, parentId, sortId, pos, posDescription, tnved, cas, doc, typeId FROM vLaw " & _
                '    "WHERE isList = 1 AND areaId = 1 AND NOT parentId IS NULL AND dateB < {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND dateE > {{ts '{0:yyyy-MM-dd HH:mm:ss}'}}", _
                '    Date.Now)
                Ds.LawTable.Load(Cmd.ExecuteReader)
                Me.Text = "LawTnvedTable load ..."
                Application.DoEvents()
                For i As Integer = 0 To Ds.LawTable.Rows.Count - 1
                    Me.Text = String.Format("LawTnvedTable load ({0} from {1})", i + 1, Ds.LawTable.Rows.Count)
                    Cmd.CommandText = String.Format("SELECT DISTINCT tnved FROM tLawTnved WHERE lawId = {0}", CInt(Ds.LawTable(i)("id")))
                    Using Dr As SqlDataReader = Cmd.ExecuteReader
                        While Dr.Read
                            Ds.LawTnvedTable.Rows.Add(New Object() {Ds.LawTable(i)("id"), Dr(0)})
                        End While
                    End Using
                Next
                Me.Text = "TnvedTable load ..."
                Application.DoEvents()
                Using V As New DataView(Ds.LawTnvedTable) With {.Sort = "code"}
                    For i As Integer = 0 To V.Count - 1
                        Me.Text = String.Format("TnvedTable load ({0} from {1})", i + 1, V.Count)
                        Application.DoEvents()
                        If Not Ds.TnvedTable.Rows.Find(V(i)("code")) Is Nothing Then Continue For
                        Row = Ds.TnvedTable.NewRow
                        Row("code") = V(i)("code")
                        Cmd.CommandText = String.Format("SELECT description FROM tTnved WHERE code LIKE '{0}%' ORDER BY 1", Row("code").ToString)
                        Using Dr As SqlDataReader = Cmd.ExecuteReader
                            If Dr.Read Then
                                Row("description") = Dr(0)
                                Row("codeDescription") = String.Format("{0}{1}{2}", Row("code").ToString, vbCrLf, Row("description").ToString)
                            Else
                                Row("codeDescription") = String.Format("{0} - [нет описания]", Row("code").ToString)
                            End If
                        End Using
                        Ds.TnvedTable.Rows.Add(Row)
                    Next
                End Using
            End Using
            Me.Text = "Редактор АПУ - новый"
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Ds.Clear()
            Me.Text = "Редактор АПУ - нет данных"
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        Finally
            Ds.EnforceConstraints = True
            EditLawControl.EndDataUpdate()
            EditTnvedControl.EndDataUpdate()
            ApuControl.EndDataUpdate()
            SynonControl.EndDataUpdate()
        End Try
    End Sub

    ' Сохранить текущий АПУ в базу данных
    Private Sub DataToBaseBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles DataToBaseBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Сохранить текущий АПУ в базу данных?") <> Windows.Forms.DialogResult.Yes Then Exit Sub
        If DbClient Is Nothing OrElse DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then
            DbClient = New Cprp.DxData.User.DatabaseUser(False)
        End If
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        Dim oldText As String = Me.Text
        Me.Text = "Сохранение данных в базу ..."
        Cprp.DxCommon.WaitForm.Show(Me)
        Try
            ApuControl.CloseEditor()
            Ds.AcceptChanges()
            For Each Row As DataRow In Ds.ApuTable.Rows
                Row("fullCaption") = Ds.ApuTable.GetFullCaption(CInt(Row("id"))).ToUpper
                Row.AcceptChanges()
                Row.SetAdded()
            Next
            For Each Row As DataRow In Ds.ApuLawTable.Rows
                Row.SetAdded()
            Next
            Using Cmd As New SqlCommand With {.Connection = DbClient.Connection}
                Cmd.CommandText = "DELETE FROM tApu"
                Cmd.ExecuteNonQuery()
            End Using
            Using A As New SqlDataAdapter("SELECT * FROM tApu", DbClient.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(Ds.ApuTable)
            End Using
            Using A As New SqlDataAdapter("SELECT * FROM tApuLaw", DbClient.Connection)
                Dim B As New SqlCommandBuilder(A)
                A.Update(Ds.ApuLawTable)
            End Using
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Данные сохранены.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка выполнения операции:{0}{1}", vbCrLf, ex.Message))
        End Try
    End Sub

    ' Показать списки
    Private Sub EditLawBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LawBarCheckItem.CheckedChanged
        MainPanelControl.Controls.SetChildIndex(EditLawControl, 0)
    End Sub

    ' Показать ТНВЭД
    Private Sub EditTnvedBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TnvedBarCheckItem.CheckedChanged
        MainPanelControl.Controls.SetChildIndex(EditTnvedControl, 0)
    End Sub

    ' Показать АПУ
    Private Sub ApuBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles ApuBarCheckItem.CheckedChanged
        MainPanelControl.Controls.SetChildIndex(ApuControl, 0)
    End Sub

    ' Показать синонимы
    Private Sub SynonBarCheckItem_CheckedChanged(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles SynonBarCheckItem.CheckedChanged
        MainPanelControl.Controls.SetChildIndex(SynonControl, 0)
    End Sub

    ' Показать пункта списка в дереве контрольных списков
    Private Sub ApuControl_LawShow(lawId As Integer) Handles ApuControl.LawShow
        EditLawControl.LawView(lawId)
        LawBarCheckItem.Checked = True
    End Sub

    ' Тест
    Private Sub TestBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TestBarButtonItem.ItemClick
        Cprp.DxCommon.WaitForm.Show(Me)
        'LoadStudyWord()
        ApuExportExcel()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    ' Экспорт АПУ в файл формата Microsoft Excel
    Private Sub ApuExportExcel()
        ApuControl.ApuTreeList.ExpandToLevel(0)
        ApuControl.ApuTreeList.ExportToXlsx("d:\apu.xlsx")
        MsgBox("OK")
    End Sub

    ' Загрузить в поле АПУ таблицы контрольных списков ключевые слова из исследований экспертов
    Private Sub LoadStudyWord()
        If DbClient Is Nothing OrElse DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then
            DbClient = New Cprp.DxData.User.DatabaseUser(False)
        End If
        If DbClient.Connection Is Nothing OrElse DbClient.Connection.State <> ConnectionState.Open Then Exit Sub
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Dim arr() As String = Nothing
        Dim Row As DataRow = Nothing
        Me.Tag = Me.Text
        ' Очистка поля АПУ
        Me.Text = "LawTable apu field clear ..."
        Application.DoEvents()
        Using V As New DataView(Ds.LawTable)
            V.RowFilter = "NOT apu IS NULL"
            While V.Count > 0
                V(0)("apu") = DBNull.Value
            End While
        End Using
        ' Таблица исследований
        Using StudyTable As New DataTable
            With StudyTable.Columns
                .Add("id", GetType(Integer))
                .Add("word", GetType(String))
            End With
            StudyTable.PrimaryKey = New DataColumn() {StudyTable.Columns("id")}
            ' Таблица пунктов контрольных списков из исследований
            Using StudyLawTable As New DataTable
                With StudyLawTable.Columns
                    .Add("studyId", GetType(Integer))
                    .Add("lawId", GetType(Integer))
                End With
                StudyLawTable.PrimaryKey = New DataColumn() {StudyLawTable.Columns("studyId"), StudyLawTable.Columns("lawId")}
                Using V As New DataView(StudyLawTable)
                    ' Загрузка данных
                    Using Cmd As New SqlCommand With {.Connection = DbClient.Connection}
                        Me.Text = "StudyTable load ..."
                        Application.DoEvents()
                        Cmd.CommandText = "SELECT id, word FROM tGoodStudy WHERE typeId = 1 AND actDate > '2019-01-01'"
                        StudyTable.Load(Cmd.ExecuteReader)
                        Me.Text = "StudyLawTable load ..."
                        Application.DoEvents()
                        Cmd.CommandText = "SELECT studyId, lawId FROM tGoodStudyLaw WHERE isFindWord = 1 AND studyId IN (SELECT id FROM tGoodStudy WHERE typeId = 1)"
                        StudyLawTable.Load(Cmd.ExecuteReader)
                    End Using
                    ' Заполнение поля АПУ таблицы контрольных списков
                    For i As Integer = 0 To StudyTable.Rows.Count - 1
                        Me.Text = String.Format("LawTable apu field write ({0} from {1})", i + 1, StudyTable.Rows.Count)
                        Application.DoEvents()
                        sTmp = ToText(StudyTable(i)("word"))
                        If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                        sTmp = sTmp.Replace("*", Nothing)
                        If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                        sTmp = sTmp.Replace("(", Nothing).Replace(")", "/") ' убрать
                        arr = sTmp.ToLower.Split(New Char() {"(", ")"}, StringSplitOptions.RemoveEmptyEntries)
                        V.RowFilter = String.Format("studyId = {0}", CInt(StudyTable(i)("id")))
                        For Each VRow As DataRowView In V
                            Row = Ds.LawTable.Rows.Find(VRow("lawId"))
                            If Row Is Nothing Then Continue For
                            sTmp1 = ToText(Row("apu"))
                            For Each sTmp In arr
                                If String.IsNullOrWhiteSpace(sTmp1) OrElse InStr(sTmp1, sTmp) = 0 Then
                                    sTmp1 = String.Format("{0}{1}={2}", sTmp1, vbCrLf, sTmp)
                                End If
                            Next
                            If Not String.IsNullOrWhiteSpace(sTmp1) And sTmp1.Length > 3 Then Row("apu") = sTmp1.Substring(3)
                        Next
                    Next
                End Using
            End Using
        End Using
        Me.Text = Me.Tag.ToString
    End Sub

    ' Переписать коды ТН ВЭД в таблице АПУ
    Private Sub TnvedReloadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles TnvedReloadBarButtonItem.ItemClick
        If Cprp.DxCommon.Messages.ShowQuestion("Переписать коды ТН ВЭД в таблице АПУ?") <> Windows.Forms.DialogResult.Yes Then Exit Sub
        Dim formText As String = Me.Text
        Dim ApuLawView As New DataView(Ds.ApuLawTable)
        Dim LawTnvedView As New DataView(Ds.LawTnvedTable) With {.Sort = "code"}
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Dim iTmp As Integer = 0
        Cprp.DxCommon.WaitForm.Show(Me)
        Try
            For i As Integer = 0 To Ds.ApuTable.Rows.Count - 1
                Me.Text = String.Format("Переписывание кодов ТН ВЭД в tApu ({0} из {1})", i + 1, Ds.ApuTable.Rows.Count)
                Application.DoEvents()
                '
                ' Строка ID текущего пункта АПУ и его дочерних пунктов
                '
                sTmp = String.Format("{0}, {1}", CInt(Ds.ApuTable(i)("id")), Ds.ApuTable.GetChildIdString(CInt(Ds.ApuTable(i)("id"))))
                If sTmp Like "*, " Then sTmp &= "0"
                '
                ' Строка ID пунктов контрольных списков текущего пункта АПУ и его дочерних пунктов
                '
                ApuLawView.RowFilter = String.Format("apuId IN ({0})", sTmp)
                sTmp = "0"
                For Each VRow As DataRowView In ApuLawView
                    sTmp = String.Format("{0}, {1}", sTmp, CInt(VRow("lawId")))
                Next
                '
                ' Строка кодов ТН ВЭД текущего пункта АПУ и его дочерних пунктов
                '
                LawTnvedView.RowFilter = String.Format("lawId IN ({0})", ToStrNum(sTmp, False))
                sTmp = "_"
                For j As Integer = 0 To LawTnvedView.Count - 1
                    sTmp1 = ToText(LawTnvedView(j)("code"))
                    If sTmp1.Length > 4 Then sTmp1 = sTmp1.Substring(0, 4)
                    If Not (sTmp1 Like "84*" OrElse sTmp1 Like "85*" OrElse sTmp1 Like "90*") Then sTmp1 = sTmp1.Substring(0, 2)
                    If Not sTmp Like String.Format("*_{0}_*", sTmp1) Then sTmp = String.Format("{0}{1}_", sTmp, sTmp1)
                Next

                Ds.ApuTable(i)("strPos") = sTmp

            Next

            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowInformation("Операция завершена.")
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(ex.Message)
        Finally
            ApuLawView.Dispose()
            LawTnvedView.Dispose()
            Me.Text = formText
        End Try


    End Sub

End Class