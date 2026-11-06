Imports DevExpress.XtraRichEdit.API.Native
Imports C2 = Cprp.DxData.Common
' ==================================
' Свойства и методы для работы с RTF
' ==================================
Partial Public Class WorkConnectionRow

#Region "Работа с загрузочными таблицами"

    ''' <summary>
    ''' Выгрузить данные в файл с загрузочными таблицами
    ''' </summary>
    ''' <param name="filePath">Путь к файлу для выгрузки данных</param>
    Public Sub DataToRtf(filePath As String)
        If Me.IsEmpty OrElse Not C2.IsText(filePath) Then Exit Sub

        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Dim Tgood As New Cprp.DxData.Handbook.GoodTypeDataTable(Me.Connection)
        Try
            '
            ' Загрузка шаблона
            '
            R.OpenXmlBytes = Cprp.DxData.Resource.Resource.GetBinData("ЭКСКОНТЗАГРУЗОЧНАЯТАБЛИЦА", Me.Connection)
            R.Document.BeginUpdate()
            '
            ' Сведения об объектах экспертизы
            '
            With R.Document.Tables(0)
                Using V As New DataView(Me.GoodTable)
                    V.Sort = "rowNum"
                    For i As Integer = 0 To V.Count - 1
                        If i > 1 Then .Rows.Append()
                        R.Document.Delete(.Cell(i, 0).ContentRange)
                        R.Document.InsertText(.Cell(i, 0).ContentRange.Start, C2.ToText(V(i)("rowNum")))
                        R.Document.InsertText(.Cell(i, 1).ContentRange.Start, C2.ToText(V(i)("nameCon")))
                        R.Document.InsertText(.Cell(i, 2).ContentRange.Start, C2.ToText(V(i)("nameDec")))
                        R.Document.InsertText(.Cell(i, 5).ContentRange.Start, C2.ToText(Tgood.GetCodeById(V(i)("typeId"))))
                        R.Document.InsertText(.Cell(i, 6).ContentRange.Start, C2.ToText(V(i)("area")))
                        R.Document.InsertText(.Cell(i, 7).ContentRange.Start, C2.ToText(V(i)("used")))
                        R.Document.InsertText(.Cell(i, 8).ContentRange.Start, C2.ToText(V(i)("description")))
                        R.Document.InsertText(.Cell(i, 9).ContentRange.Start, C2.ToText(V(i)("tnved")))
                        R.Document.InsertText(.Cell(i, 10).ContentRange.Start, C2.ToText(V(i)("studyWord")))
                        R.Document.InsertText(.Cell(i, 11).ContentRange.Start, C2.ToText(V(i)("id")))
                    Next
                End Using
            End With
            '
            ' Сведения о документах
            '            
            With R.Document.Tables(1)
                Using V As New DataView(Me.InDocTable)
                    For i As Integer = 0 To V.Count - 1
                        If i > 1 Then .Rows.Append()
                        R.Document.Delete(.Cell(i, 0).Range)
                        R.Document.InsertText(.Cell(i, 0).Range.Start, C2.ToText(V(i)("rowNum")))
                        R.Document.InsertText(.Cell(i, 1).Range.Start, C2.ToText(V(i)("caption")))
                        R.Document.InsertText(.Cell(i, 2).Range.Start, C2.ToText(V(i)("regNum")))
                        If Not IsDBNull(V(i)("regDate")) Then
                            R.Document.InsertText(.Cell(i, 3).Range.Start, Format(CDate(V(i)("regDate")), "dd.MM.yyyy"))
                        End If
                        R.Document.InsertText(.Cell(i, 4).Range.Start, C2.ToText(V(i)("id")))
                    Next
                End Using
            End With

            R.Document.EndUpdate()
            '
            ' Сохранение файла
            '
            If filePath Like "*docx" Then
                R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Else
                R.SaveDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.Doc)
            End If
        Catch ex As Exception
            Throw ex
        Finally
            R.Dispose()
            Tgood.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Загрузить перечень объектов экспертизы из файла с загрузочными таблицами
    ''' </summary>
    ''' <param name="filePath">Путь к файлу с загрузочными таблицами</param>
    Public Sub GoodFromRtf(filePath As String)
        If Me.IsEmpty OrElse Not C2.IsText(filePath) Then Exit Sub
        '
        ' Загрузка данных
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Dim Tgood As Cprp.DxData.Handbook.GoodTypeDataTable = Nothing
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Try
            If Not My.Computer.FileSystem.FileExists(filePath) Then Throw New Exception("Не найден файл с загрузочными таблицами.")
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            '
            ' Открытие документа Word
            '
            If Not (filePath Like "*.docx" OrElse filePath Like "*.doc") Then
                Throw New Exception("Тип загрузочного файла не определен.")
            End If
            If filePath Like "*.docx" Then
                R.LoadDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Else
                R.LoadDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.Doc)
            End If
            '
            ' Проверка наличия таблицы в загрузочном файле
            '
            If R.Document.Tables.Count = 0 Then Throw New Exception("В загрузочном файле отсутствуют таблицы.")
            Tgood = New Cprp.DxData.Handbook.GoodTypeDataTable(Me.Connection)
            '
            ' Загрузка данных из Таблицы[0] документа
            '
            With R.Document.Tables(0)
                For i As Integer = 0 To .Rows.Count - 1
                    Row = Nothing
                    If .Rows(i).Cells.Count > 11 Then
                        sTmp = Trim(C2.ToText(R.Document.GetText(.Cell(i, 11).Range)))
                        Row = Me.GoodTable.Rows.Find(C2.ToInt(sTmp))
                    End If
                    If Row Is Nothing Then Row = Me.GoodTable.AddNew()
                    For j As Integer = 0 To .Rows(0).Cells.Count - 1
                        sTmp = Trim(C2.ToText(R.Document.GetText(.Cell(i, j).ContentRange)))
                        If Not C2.IsText(sTmp) Then Continue For
                        Select Case (j)
                            Case 0 : If IsNumeric(sTmp) Then Row("rowNum") = CInt(sTmp)
                            Case 1 : Row("nameCon") = sTmp
                            Case 2 : Row("nameDec") = sTmp
                            Case 5 : If IsNumeric(sTmp) Then Row("typeId") = Tgood.GetIdByCode(sTmp)
                            Case 6 : Row("area") = sTmp
                            Case 7 : Row("used") = sTmp
                            Case 8 : Row("description") = sTmp
                            Case 9 : Row("tnved") = sTmp
                            Case 10 : Row("studyWord") = sTmp
                        End Select
                    Next
                Next
            End With
        Catch ex As Exception
            Throw ex
        Finally
            R.Dispose()
            Tgood.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Загрузить перечень представленных документов из файла с загрузочными таблицами
    ''' </summary>
    ''' <param name="filePath">Путь к файлу с загрузочными таблицами</param>
    ''' <remarks></remarks>
    Public Sub InDocFromRtf(filePath As String)
        If Me.IsEmpty OrElse Not C2.IsText(filePath) Then Exit Sub
        '
        ' Загрузка данных
        '
        Dim R As DevExpress.XtraRichEdit.RichEditDocumentServer = Nothing
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        Try
            If Not My.Computer.FileSystem.FileExists(filePath) Then Throw New Exception("Не найден файл с загрузочными таблицами.")
            R = New DevExpress.XtraRichEdit.RichEditDocumentServer
            '
            ' Открытие документа Word
            '
            If Not (filePath Like "*.docx" OrElse filePath Like "*.doc") Then
                Throw New Exception("Тип загрузочного файла не определен.")
            End If
            If filePath Like "*.docx" Then
                R.LoadDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            Else
                R.LoadDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.Doc)
            End If
            '
            ' Проверка наличия таблицы в загрузочном файле
            '
            If R.Document.Tables.Count < 2 Then Throw New Exception("В загрузочном файле отсутствует вторая таблица.")
            '
            ' Загрузка данных из Таблицы[1] документа
            '
            With R.Document.Tables(1)
                For i As Integer = 0 To .Rows.Count - 1
                    Row = Nothing
                    If .Rows(i).Cells.Count > 4 Then
                        sTmp = Trim(C2.ToText(R.Document.GetText(.Cell(i, 4).Range)))
                        Row = Me.InDocTable.Rows.Find(C2.ToInt(sTmp))
                    End If
                    If Row Is Nothing Then Row = Me.InDocTable.AddNew
                    For j As Integer = 0 To .Rows(0).Cells.Count - 1
                        sTmp = Trim(C2.ToText(R.Document.GetText(.Cell(i, j).Range)))
                        If Not C2.IsText(sTmp) Then Continue For
                        Select Case (j)
                            Case 0 : If IsNumeric(sTmp) Then Row("rowNum") = CInt(sTmp)
                            Case 1 : Row("caption") = sTmp
                            Case 2 : Row("regNum") = sTmp
                            Case 3 : If IsDate(sTmp) Then Row("regDate") = CDate(sTmp)
                        End Select
                    Next
                Next
            End With
        Catch ex As Exception
            Throw ex
        Finally
            R.Dispose()
        End Try
    End Sub

#End Region

End Class

