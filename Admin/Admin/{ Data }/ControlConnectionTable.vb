Imports C2 = Cprp.DxData.Common
''' <summary>
''' Нормативные документы
''' </summary>
''' <remarks></remarks>
Friend Class ControlConnectionTable : Inherits Cprp.DxData.Base.ConnectionDataTable

    Friend Sub New()
        MyBase.New(Program.DbClient.Connection, "ControlTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("parentId", GetType(Integer))
            .Add("sortId", GetType(Integer))
            .Add("pos", GetType(String))
            .Add("description", GetType(String))
            .Add("tnved", GetType(String))
            .Add("tnved2", GetType(String))
            .Add("cas", GetType(String))
            .Add("doc", GetType(String))
            .Add("letter", GetType(String))
            .Add("areaId", GetType(Integer))
            .Add("modeId", GetType(Integer))
            .Add("typeId", GetType(Integer))
            .Add("lev", GetType(Integer))
            .Add("isList", GetType(Boolean))
            .Add("dateB", GetType(Date))
            .Add("dateE", GetType(Date))
            .Add("iTmp", GetType(Integer))      ' для хранения временных числовых данных
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("sortId").AllowDBNull = False
        Me.Columns("description").AllowDBNull = False
        Me.Columns("doc").AllowDBNull = False
        Me.Columns("typeId").AllowDBNull = False
        Me.Columns("lev").AllowDBNull = False
        Me.Columns("isList").AllowDBNull = False
        Me.Columns("dateB").AllowDBNull = False
        Me.Columns("dateE").AllowDBNull = False
        Me.Columns("pos").MaxLength = 20
        Me.Columns("tnved").MaxLength = 1500
        Me.Columns("cas").MaxLength = 500
        Me.Columns("doc").MaxLength = 14
        Me.Columns("letter").MaxLength = 8
        Me.Columns("lev").DefaultValue = 0
        Me.Columns("sortId").DefaultValue = 0
        Me.Columns("dateE").DefaultValue = CDate("31.12.9999")
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ' Сохранить данные в базу
    Friend Sub SaveToBase()
        Using A As New SqlDataAdapter("SELECT * FROM tLaw WHERE id IS NULL", MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

    ''' <summary>
    ''' Загрузить данные из файла Microsoft Word
    ''' </summary>
    ''' <param name="filePath">Путь к загрузочному файлу</param>
    ''' <remarks></remarks>
    Friend Sub DataLoadWord(ByVal filePath As String)
        Dim sTmp As String = Nothing
        '
        ' Загрузка данных
        '
        Dim doc As String = Nothing
        Dim areaId As Integer = -1
        Dim modeId As Integer = -1
        Dim isList As Boolean = True
        Dim rootParentId As Integer = -1
        Dim dateB As Date = Nothing
        Dim sortId As Integer = 0
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Dim Row As DataRow = Nothing
        Dim iTmp As Integer = -1
        Try
            '
            ' Начальное id
            '
            iTmp = CInt(Me.ExecuteScalar("SELECT ISNULL(MAX(id), 0) FROM tLaw")) + 1
            '
            ' Открытие документа Word
            '
            R.LoadDocument(filePath)
            '
            ' doc, areaId, modeId, rootParentId, isList, dateB, sortId
            '
            With R.Document.Tables(0)
                doc = GetText(R.Document.GetText(.Cell(0, 0).Range))
                areaId = CInt(GetText(R.Document.GetText(.Cell(0, 1).Range)))
                modeId = CInt(GetText(R.Document.GetText(.Cell(0, 2).Range)))
                isList = CBool(GetText(R.Document.GetText(.Cell(0, 3).Range)))
                sTmp = GetText(R.Document.GetText(.Cell(0, 4).Range))
                If Not String.IsNullOrWhiteSpace(sTmp) Then rootParentId = CInt(sTmp)
                dateB = CDate(GetText(R.Document.GetText(.Cell(0, 5).Range)))
                sTmp = GetText(R.Document.GetText(.Cell(0, 6).Range))
                If Not String.IsNullOrWhiteSpace(sTmp) Then sortId = CInt(sTmp)
            End With
            '
            ' id, sortId, pos, description, tnved, cas, typeId = 1, lev = 0
            '
            With R.Document.Tables(1)
                For i As Integer = 0 To .Rows.Count - 1
                    Row = Me.NewRow
                    Row("id") = iTmp + i + 1
                    Row("sortId") = sortId
                    sTmp = GetText(R.Document.GetText(.Cell(i, 0).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then Row("pos") = sTmp
                    sTmp = GetText(R.Document.GetText(.Cell(i, 1).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then Row("description") = sTmp
                    If .Rows(i).Cells.Count > 2 Then
                        sTmp = GetTnved(R.Document.GetText(.Cell(i, 2).Range))
                        If Not String.IsNullOrWhiteSpace(sTmp) Then Row("tnved") = sTmp
                    End If
                    If .Rows(i).Cells.Count > 3 Then
                        sTmp = GetCas(R.Document.GetText(.Cell(i, 3).Range))
                        If Not String.IsNullOrWhiteSpace(sTmp) Then Row("cas") = sTmp
                    End If
                    Row("doc") = doc
                    Row("areaId") = areaId
                    If modeId > 0 Then Row("modeId") = modeId
                    Row("typeId") = 1
                    Row("lev") = 0
                    Row("isList") = isList
                    Row("dateB") = dateB
                    Me.Rows.Add(Row)
                Next
            End With
            '
            ' parentId
            '
            Using V As New DataView(Me)
                V.Sort = "id DESC"
                For i As Integer = 0 To V.Count - 2
                    sTmp = V(i)("pos").ToString
                    For j = i + 1 To V.Count - 1
                        If IsDBNull(V(j)("pos")) Then Continue For
                        If String.IsNullOrWhiteSpace(sTmp) OrElse sTmp Like (V(j)("pos").ToString & "*") Then
                            V(i)("parentId") = V(j)("id")
                            Exit For
                        End If
                    Next
                Next
            End Using
            '
            ' rootParentId
            '
            If rootParentId > 0 Then
                Using V As New DataView(Me)
                    V.RowFilter = "parentId IS NULL"
                    While V.Count > 0
                        V(0)("parentId") = rootParentId
                    End While
                End Using
            End If
            '
            ' Примечания
            '
            Using V As New DataView(Me)
                V.RowFilter = "pos IS NULL"
                For i As Integer = 0 To V.Count - 1
                    sTmp = V(i)("description").ToString.ToUpper
                    If sTmp Like "*РИМЕЧАНИ*" OrElse sTmp Like "*РЕДЕЛЕНИ*" OrElse sTmp Like "*АМЕЧАНИ*" OrElse sTmp Like "*АПИСК*" Then
                        V(i)("typeId") = 2
                    End If
                Next
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            R.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Выгрузить данные в файл Microsoft Word
    ''' </summary>
    ''' <param name="filePath">Путь к файлу для выгрузки данных</param>
    ''' <remarks></remarks>
    Friend Sub DataSaveWord(ByVal filePath As String)
        If Me.Rows.Count = 0 Then Exit Sub
        If String.IsNullOrWhiteSpace(filePath) Then Exit Sub

        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Try
            '
            ' Загрузка шаблона
            '
            R.OpenXmlBytes = My.Resources.lawtemplate
            R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            R.Document.BeginUpdate()
            '
            ' Заголовок документа
            '
            With R.Document.Bookmarks("DocName")
                .Range.BeginUpdateDocument.Replace(.Range, My.Computer.FileSystem.GetName(filePath).Replace(".docx", Nothing))
            End With
            '
            ' Представление нормативных документов отсортированное по doc, id
            '
            Using V As New DataView(Me)
                V.Sort = "doc, id"
                '
                ' Таблица 1 (служебная инофрмация, берется из первой строки представления)
                '
                With R.Document.Tables(0)
                    R.Document.InsertText(.Cell(0, 0).ContentRange.Start, C2.ToText(V(0)("doc")))
                    R.Document.InsertText(.Cell(0, 1).ContentRange.Start, C2.ToText(V(0)("areaId")))
                    R.Document.InsertText(.Cell(0, 2).ContentRange.Start, C2.ToText(V(0)("modeId")))
                    R.Document.InsertText(.Cell(0, 3).ContentRange.Start, If(CBool(V(0)("isList")), "1", "0"))
                    R.Document.InsertText(.Cell(0, 4).ContentRange.Start, C2.ToText(V(0)("parentId")))
                    R.Document.InsertText(.Cell(0, 5).ContentRange.Start, Format(CDate(V(0)("dateB")), "dd.MM.yyyy"))
                    R.Document.InsertText(.Cell(0, 6).ContentRange.Start, C2.ToText(V(0)("sortId")))
                End With
                '
                ' Таблица 2 (содержимое)
                '
                With R.Document.Tables(1)
                    For i As Integer = 0 To V.Count - 1
                        If i > 0 Then .Rows.Append()
                        R.Document.InsertText(.Cell(i, 0).ContentRange.Start, C2.ToText(V(i)("pos")))
                        R.Document.InsertText(.Cell(i, 1).ContentRange.Start, C2.ToText(V(i)("description")))
                        R.Document.InsertText(.Cell(i, 2).ContentRange.Start, C2.ToText(V(i)("tnved")))
                        R.Document.InsertText(.Cell(i, 3).ContentRange.Start, C2.ToText(V(i)("cas")))
                    Next
                End With
            End Using
            '
            ' Сохранение файла
            '
            R.Document.EndUpdate()
            R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
        Catch ex As Exception
            Throw ex
        Finally
            R.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Преобразует текст объекта DocumentRange
    ''' </summary>
    ''' <param name="txt">Исходный текст объекта DocumentRange</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shadows Function GetText(ByVal txt As String) As String
        Do
            If String.IsNullOrWhiteSpace(txt) Then Exit Do
            If Asc(txt(0)) > 32 And Asc(txt(txt.Length - 1)) > 32 Then Exit Do
            If (Asc(txt(txt.Length - 1)) < 33) Then txt = txt.Substring(0, txt.Length - 1)
            If String.IsNullOrWhiteSpace(txt) Then Exit Do
            If (Asc(txt(0)) < 33) Then txt = txt.Substring(1)
        Loop
        If String.IsNullOrWhiteSpace(txt) Then Return Nothing
        Return Trim(txt)
    End Function

    ''' <summary>
    ''' Преобразует текст с кодами ТН ВЭД в строку кодов, разделенных пробелами
    ''' </summary>
    ''' <param name="txt">Исходный текст с кодами ТН ВЭД</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetTnved(ByVal txt As String) As String
        Dim sTmp As String = Trim(txt)
        For i As Integer = 0 To sTmp.Length - 1
            If Not sTmp(i) Like "[0123456789 ]" Then sTmp = sTmp.Replace(sTmp(i), " ")
        Next
        While sTmp Like "  "
            sTmp = sTmp.Replace("  ", " ")
        End While
        If String.IsNullOrWhiteSpace(sTmp) Then Return Nothing
        Return Trim(sTmp)
    End Function

    ''' <summary>
    ''' Преобразует текст с номерами CAS в строку номеров, разделенных пробелами
    ''' </summary>
    ''' <param name="txt">Исходный текст с номерами CAS</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetCas(ByVal txt As String) As String
        Dim sTmp As String = Trim(txt)
        For i As Integer = 0 To sTmp.Length - 1
            If Not sTmp(i) Like "[0123456789 ]" AndAlso sTmp(i) <> "-" Then sTmp = sTmp.Replace(sTmp(i), " ")
        Next
        While sTmp Like "  "
            sTmp = sTmp.Replace("  ", " ")
        End While
        If String.IsNullOrWhiteSpace(sTmp) Then Return Nothing
        Return Trim(sTmp)
    End Function

End Class
