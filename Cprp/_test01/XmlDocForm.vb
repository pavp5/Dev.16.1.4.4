Imports Cprp.DxData.Common
Imports Cprp.DxData.Work
''' <summary>
''' Форма для создания исходных данных для распознавания
''' </summary>
Public Class XmlDocForm

#Region "Data"

    ''' <summary>
    ''' Таблица документов
    ''' </summary>
    Private DocTable As DataTable = Nothing

    ''' <summary>
    ''' Таблица параграфов документов
    ''' </summary>
    Private ParTable As DataTable = Nothing

    ''' <summary>
    ''' Источник данных
    ''' </summary>
    Private Ds As DataSet = Nothing

    ''' <summary>
    ''' Создать источник данных
    ''' </summary>
    Private Sub DataCreate()
        '
        ' DocTable
        '
        DocTable = New DataTable("Doc")
        With DocTable
            With .Columns.Add("id", GetType(Integer))
                .AllowDBNull = False
            End With
            With .Columns.Add("type_id", GetType(Integer))
                .AllowDBNull = False
                .DefaultValue = 1
            End With
            With .Columns.Add("doc_name", GetType(String))
                .AllowDBNull = False
            End With
            With .Columns.Add("doc_num", GetType(String))
                .AllowDBNull = False
            End With
            .Columns.Add("doc_date", GetType(Date))
            .PrimaryKey = New DataColumn() {.Columns("id")}
        End With
        '
        ' ParTable
        '
        ParTable = New DataTable("Paragraph")
        With ParTable
            With .Columns.Add("id", GetType(Integer))
                .AllowDBNull = False                
            End With
            With .Columns.Add("doc_id", GetType(Integer))
                .AllowDBNull = False
                .DefaultValue = 1
            End With
            With .Columns.Add("description", GetType(String))
                .AllowDBNull = False
            End With
            .PrimaryKey = New DataColumn() {.Columns("id")}
        End With
        '
        ' Ds
        '
        Ds = New DataSet("Data")
        Ds.Tables.AddRange(New DataTable() {DocTable, ParTable})
        Dim Relation As New DataRelation("DocParagraphRelation", DocTable.Columns("id"), ParTable.Columns("doc_id"))
        Ds.Relations.Add(Relation)
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade

    End Sub


#End Region

    Public Sub New()
        InitializeComponent()
        '
        ' Data
        '
        DataCreate()
        '
        ' DocGridControl, DocGridView
        '
        DocGridControl.DataSource = DocTable
        DocGridView.SortInfo.Insert(0, IdDocGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        '
        ' Me
        '
        Me.Text = "Данные для распознавания документов"
        Me.Width = Screen.GetWorkingArea(Me).Width
        Me.Height = Screen.GetWorkingArea(Me).Height
        Me.CenterToScreen()
    End Sub


    Private Sub LoadBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles LoadBarButtonItem.ItemClick
        Dim folder_path As String = Nothing     ' папка для сохранения файлов данных
        Dim file_path As String = Nothing       ' путь к последнему файлу данныж
        Using Dlg As New FolderBrowserDialog
            Dlg.Description = "Выберите папку для сохранения файлов данных"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            folder_path = Dlg.SelectedPath
        End Using
        Cprp.DxCommon.WaitForm.Show(Me)
        DocGridView.BeginDataUpdate()
        ParTable.Rows.Clear()
        DocTable.Rows.Clear()
        Ds.AcceptChanges()
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Dim doc_count As Integer = 0    ' количество загруженных документов
        Dim par_id As Integer = 1       ' id текущей строки в таблице содержимого документов
        Dim sTmp As String = Nothing
        Using Work As New Excont.WorkConnectionRow(0, Program.DbClient.Connection)
            ' Цикл по работам
            For i As Integer = 60001 To 70001
                Work.Id = i
                If CInt(Work("typeId")) <> 1 Then Continue For
                If IsNothing(Work.ARow("doc1RegNum")) OrElse IsDBNull(Work.ARow("doc1RegNum")) Then Continue For
                If IsNothing(Work.ARow("doc1Data")) OrElse IsDBNull(Work.ARow("doc1Data")) Then Continue For
                DocTable.Rows.Add(New Object() {i, 1, "Идентификационное заключение", Work.ARow("doc1RegNum"), Work.ARow("doc1RegDate")})
                R.OpenXmlBytes = Work.ARow("doc1Data")
                ' Цикл по абзацам итогового документа
                For j = 0 To R.Document.Paragraphs.Count - 1
                    sTmp = ToText(R.Document.GetText(R.Document.Paragraphs(j).Range))
                    If Not IsText(sTmp) Then Continue For                    
                    If sTmp Like "2.3. Российский участник внешнеэкономической операции:*" Then
                        sTmp = "2.3. Российский участник внешнеэкономической операции: "
                    ElseIf sTmp Like "2.4.1. Покупатель:*" Then
                        sTmp = "2.4.1. Покупатель: "
                    ElseIf sTmp Like "2.4.1. Продавец:*" Then
                        sTmp = "2.4.1. Продавец:"
                    ElseIf sTmp Like "2.4.2. Потребитель (конечный пользователь):*" Then
                        sTmp = "2.4.2. Потребитель (конечный пользователь): "
                    ElseIf sTmp Like "5.2. Наличие признаков, дающих основания полагать*" Then
                        sTmp = "5.2. Наличие признаков, дающих основания полагать, что идентифицируемые товары и идентифицируемые продукты научно - технической деятельности могут быть использованы в целях создания оружия массового поражения и средств его доставки, иных видов вооружения и военной техники либо приобретаются в интересах организаций или физических лиц, причастных к террористической деятельности: "
                    End If
                    ParTable.Rows.Add(par_id, i, ToXML(sTmp))
                    If sTmp Like "2.1. Документ, на основании которого*" Then
                        par_id += 1
                        ParTable.Rows.Add(par_id, i, "Контракт ")
                        j += 1
                    ElseIf sTmp Like "7. Дополнительная информация*" Then
                        Do
                            j += 1
                            If j >= R.Document.Paragraphs.Count Then
                                par_id += 1
                                Exit For
                            End If
                            sTmp = ToText(R.Document.GetText(R.Document.Paragraphs(j).Range))
                            If sTmp Like "7.1. Срок действия заключения*" Then
                                par_id += 1
                                ParTable.Rows.Add(par_id, i, sTmp)
                                Exit Do
                            End If
                        Loop
                    End If
                    par_id += 1
                Next
                doc_count += 1
                
                ' создание файла данных
                If DocTable.Rows.Count = 100 Then
                    file_path = String.Format("{0}\{1}.xml", folder_path, i)
                    Ds.AcceptChanges()
                    Ds.WriteXml(file_path, XmlWriteMode.IgnoreSchema)
                    ParTable.Rows.Clear()
                    DocTable.Rows.Clear()
                End If

                Me.Text = doc_count
                Application.DoEvents()

                If doc_count >= 2000 Then Exit For
            Next
        End Using
        R.Dispose()
        ' Загрузка последнего файла данных
        If Not String.IsNullOrWhiteSpace(file_path) AndAlso My.Computer.FileSystem.FileExists(file_path) Then
            ParTable.Rows.Clear()
            DocTable.Rows.Clear()
            Ds.ReadXml(file_path, XmlReadMode.IgnoreSchema)
            Ds.AcceptChanges()
        End If
        DocGridView.EndDataUpdate()
        DocGridView.MoveFirst()
        Me.Text = String.Format("Загружено документов: {0}", doc_count)
        Cprp.DxCommon.WaitForm.Close()
        Cprp.DxCommon.Messages.ShowInformation("OK")

    End Sub

    Private Sub OpenBarButtonItem_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles OpenBarButtonItem.ItemClick
        Dim file_path As String = Nothing
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор файла данных"
            Dlg.DefaultExt = "xml"
            Dlg.Filter = "Файл XML (*.xml)|*.xml"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            file_path = Dlg.FileName
        End Using
        DocGridView.BeginDataUpdate()
        ParTable.Rows.Clear()
        DocTable.Rows.Clear()
        Ds.ReadXml(file_path, XmlReadMode.IgnoreSchema)
        Ds.AcceptChanges()
        DocGridView.EndDataUpdate()
        DocGridView.MoveFirst()
    End Sub

End Class