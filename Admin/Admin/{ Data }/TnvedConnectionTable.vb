Imports Cprp.DxData.Common
''' <summary>
''' Товарная номенклатура
''' </summary>
''' <remarks></remarks>
Friend Class TnvedConnectionTable : Inherits Cprp.DxData.Base.ConnectionDataTable

    Friend Sub New()
        MyBase.New(Program.DbClient.Connection, "TnvedTable")
        With Me.Columns
            .Add("code", GetType(String))
            .Add("description", GetType(String))
            .Add("unit", GetType(String))
            .Add("dateB", GetType(Date))
            .Add("dateE", GetType(Date))
        End With
        Me.Columns("code").AllowDBNull = False
        Me.Columns("description").AllowDBNull = False
        Me.Columns("dateB").AllowDBNull = False
        Me.Columns("dateE").AllowDBNull = False
        Me.Columns("code").MaxLength = 14
        Me.Columns("description").MaxLength = 4000
        Me.Columns("dateE").DefaultValue = CDate("31.12.9999")
        Me.PrimaryKey = New DataColumn() {Me.Columns("code"), Me.Columns("dateB")}
    End Sub

    ' Сохранить данные в базу
    Friend Sub SaveToBase()
        Using A As New SqlDataAdapter("SELECT code, description, unit, dateB, dateE FROM tTnved WHERE code IS NULL", MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

    ' Загрузка данных по фирмам из постановления № 1300
    Friend Sub Load1300firm()
        Dim T As New DataTable
        With T.Columns
            .Add("id", GetType(Integer))
            .Add("embargoId", GetType(Integer))
            .Add("caption", GetType(String))
            .Add("description", GetType(String))
            .Add("isACT", GetType(Boolean))
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        R.LoadDocument("d:\1.docx")
        With R.Document.Tables(0)
            For i As Integer = 0 To .Rows.Count - 1
                T.Rows.Add(New Object() {i + 2300, 24, GetText(R.Document.GetText(.Cell(i, 0).Range)), _
                                          GetText(R.Document.GetText(.Cell(i, 1).Range)), True})
            Next
        End With
        Using A As New SqlClient.SqlDataAdapter("SELECT * FROM tEmbargoMember", Me.Connection)
            Dim B As New SqlClient.SqlCommandBuilder(A)
            A.Update(T)
        End Using
        T.Dispose()
        R.Dispose()
    End Sub

    ''' <summary>
    ''' Загрузить данные из файла Microsoft Word
    ''' </summary>
    ''' <param name="filePath">Путь к загрузочному файлу</param>
    ''' <remarks></remarks>
    Friend Sub DataLoadWord(ByVal filePath As String)
        Dim dateB As Date = Nothing
        Dim dateE As Date = CDate("31.12.9999")
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Dim sTmp As String = Nothing
        Try
            '
            ' Открытие документа Word
            '
            R.LoadDocument(filePath)
            '
            ' dateB
            '
            sTmp = GetText(R.Document.GetText(R.Document.Tables(0).Cell(0, 0).Range))
            If Not String.IsNullOrWhiteSpace(sTmp) AndAlso IsDate(sTmp) Then dateB = CDate(sTmp)
            '
            ' Загрузка данных
            '
            With R.Document.Tables(1)
                For i As Integer = 0 To .Rows.Count - 1
                    Me.Rows.Add(New Object() {GetText(R.Document.GetText(.Cell(i, 0).Range)), _
                                              GetText(R.Document.GetText(.Cell(i, 1).Range)), dateB, dateE})
                Next
            End With
        Catch ex As Exception
            Throw ex
        Finally
            R.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Загрузить группу ТН ВЭД 2020 из файла Microsoft Word
    ''' </summary>
    ''' <param name="filePath">Путь к загрузочному файлу</param>
    ''' <remarks></remarks>
    Friend Sub DataLoadWord2020(ByVal filePath As String)
        Dim dateB As Date = CDate("01.01.2022")
        Dim dateE As Date = CDate("31.12.9999")
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = Nothing
        Dim Row As DataRow = Nothing
        Dim T As New DataTable
        With T.Columns
            .Add("id", GetType(Integer)).AllowDBNull = False
            .Add("code", GetType(String))
            .Add("description", GetType(String))
            .Add("caption", GetType(String)).AllowDBNull = False
            With .Add("lev", GetType(Integer))
                .AllowDBNull = False
                .DefaultValue = 0
            End With
        End With
        T.PrimaryKey = New DataColumn() {T.Columns("id")}



        Try
            '
            ' Открытие документа Word
            '
            R.LoadDocument(filePath)
            '
            ' Загрузка данных во временную таблицу
            '
            With R.Document.Tables(0)
                For i As Integer = 0 To .Rows.Count - 1
                    sTmp = ToText(R.Document.GetText(.Cell(i, 1).ContentRange))
                    If String.IsNullOrWhiteSpace(sTmp) Then Continue For ' запасные коды без описаний типа [0503] в ТН ВЭД
                    iTmp = 0
                    While sTmp Like "- *"
                        sTmp = sTmp.Substring(2)
                        iTmp += 1
                    End While
                    Row = T.NewRow
                    Row("id") = i + 1
                    Row("caption") = DbText(sTmp.Replace(vbCrLf, " "))
                    Row("lev") = iTmp
                    sTmp = ToText(R.Document.GetText(.Cell(i, 0).ContentRange))
                    If Not IsNothing(sTmp) Then Row("code") = DbText(sTmp.Replace(" ", Nothing))
                    T.Rows.Add(Row)
                Next
            End With
            R.Dispose()
            '
            ' Формирование полных описаний кодов ТН ВЭД
            '
            Using V As New DataView(T) With {.Sort = "id"}
                For i As Integer = 0 To V.Count - 1
                    sTmp = ToText(V(i)("caption"))
                    iTmp = CInt(V(i)("lev"))
                    For j As Integer = i - 1 To 0 Step -1
                        If iTmp = 0 Then Exit For
                        If CInt(V(j)("lev")) < iTmp Then
                            iTmp = CInt(V(j)("lev"))
                            sTmp = String.Format("{0} {1}", ToText(V(j)("caption")), sTmp)
                        End If
                    Next
                    V(i)("description") = DbText(sTmp)
                Next
            End Using
            '
            ' Загрузка строк временной таблицы в текущую таблицу
            '
            For Each Row In T.Rows
                If Not IsText(Row("code")) Then Continue For
                Me.Rows.Add(New Object() {Row("code"), Row("description"), dateB, dateE})
            Next

        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(T) Then T.Dispose()
            If Not IsNothing(R) Then R.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Загрузить единицы измерения из файла Microsoft Word
    ''' </summary>
    ''' <param name="filePath">Путь к загрузочному файлу</param>
    ''' <remarks>
    ''' Файл содержит несколько таблиц, в каждой таблице первый столбец - код, второй - описание, третий - единица измерения
    ''' </remarks>
    Friend Sub DataLoadWordUnit(ByVal filePath As String, Optional ByRef ParentForm As Form = Nothing)
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Dim code As String = Nothing
        Dim unit As String = Nothing
        Try
            '
            ' Открытие документа Word
            '
            R.LoadDocument(filePath)
            '
            ' Цикл по таблицам документа
            '
            For n As Integer = 0 To R.Document.Tables.Count - 1
                With R.Document.Tables(n)
                    '
                    ' Цикл по строкам текущей таблицы
                    '
                    For i As Integer = 0 To .Rows.Count - 1
                        If Not ParentForm Is Nothing Then
                            ParentForm.Text = String.Format("Таблица {0} из {1}. Строка {2} из {3}", n + 1, R.Document.Tables.Count, i + 1, .Rows.Count)
                            Application.DoEvents()
                        End If
                        code = ToText(R.Document.GetText(.Cell(i, 0).ContentRange))
                        If String.IsNullOrWhiteSpace(code) OrElse code.Length < 6 Then Continue For
                        unit = ToText(R.Document.GetText(.Cell(i, 2).ContentRange)).Replace(vbCrLf, " ")
                        If String.IsNullOrWhiteSpace(unit) OrElse unit = "-" Then Continue For
                        Me.ExecuteNonQuery(String.Format("UPDATE tTnved SET unit = '{0}' WHERE code LIKE '{1}%'", unit, code))
                    Next
                End With
            Next
        Catch ex As Exception
            Throw ex
        Finally
            If Not IsNothing(R) Then R.Dispose()
        End Try

    End Sub

    ''' <summary>
    ''' Загрузить таблицу 14-ти значных кодов ТНВЭД из файла Microsoft Word
    ''' </summary>
    ''' <param name="filePath">Путь к загрузочному файлу</param>
    ''' <param name="dateB">Дата начала действия кодов</param>
    ''' <param name="dateE">Дата завершения действия кодов</param>
    ''' <remarks>
    ''' Коды введены приказом ФТС от 21.08.2007 № 1003, приложение № 24 к приказу.
    ''' Загрузочная таблица в файле Word делается на основе таблицы из приказа, описание столбцов таблицы:
    ''' 1 - 10-ти значный код ТН ВЭД;
    ''' 2 - 1-ая цифра 14-ти значного кода;
    ''' 3 - описание 1-ой цифры;
    ''' 4 - 2-ая цифра 14-ти значного кода;
    ''' 5 - описание 2-ой цифры;
    ''' 6 - 3-я цифра 14-ти значного кода;
    ''' 7 - описание 3-ей цифры;
    ''' 8 - 4-ая цифра 14-ти значного кода;
    ''' 9 - описание 4-ой цифры;
    ''' </remarks>
    Friend Sub DataLoadWord14(ByVal filePath As String, dateB As Date, dateE As Date)
        Dim code As String = Nothing
        Dim description As String = Nothing
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Dim sTmp As String = Nothing
        Try
            '
            ' Открытие документа Word
            '
            R.LoadDocument(filePath)
            '
            ' Загрузка данных
            '
            With R.Document.Tables(0)
                For i As Integer = 0 To .Rows.Count - 1
                    code = Nothing
                    description = Nothing
                    '
                    ' 10-ти значный код
                    '
                    code = GetText(R.Document.GetText(.Cell(i, 0).Range))
                    If String.IsNullOrWhiteSpace(code) Then Continue For
                    '
                    ' описание 10-ти значного кода
                    '
                    description = Me.ExecuteScalar(String.Format("SELECT description FROM tTnved WHERE code LIKE '{0}' AND dateE > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", code, dateB))
                    If String.IsNullOrWhiteSpace(description) Then Continue For
                    '
                    ' остальные цифры кода
                    '
                    sTmp = GetText(R.Document.GetText(.Cell(i, 1).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then code &= sTmp
                    sTmp = GetText(R.Document.GetText(.Cell(i, 3).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then code &= sTmp
                    sTmp = GetText(R.Document.GetText(.Cell(i, 5).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then code &= sTmp
                    sTmp = GetText(R.Document.GetText(.Cell(i, 7).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then code &= sTmp
                    '
                    ' описания остальных цифр
                    '
                    sTmp = GetText(R.Document.GetText(.Cell(i, 2).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then description &= (": " & sTmp)
                    sTmp = GetText(R.Document.GetText(.Cell(i, 4).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then description &= (": " & sTmp)
                    sTmp = GetText(R.Document.GetText(.Cell(i, 6).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then description &= (": " & sTmp)
                    sTmp = GetText(R.Document.GetText(.Cell(i, 8).Range))
                    If Not String.IsNullOrWhiteSpace(sTmp) Then description &= (": " & sTmp)
                    '
                    ' добавление строки в таблицу
                    '
                    Me.Rows.Add(New Object() {code, description, dateB, dateE})
                Next
            End With
        Catch ex As Exception
            Throw ex
        Finally
            R.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Загрузить коды ТН ВЭД с оконченным сроком действия из файла Microsoft Word
    ''' </summary>
    ''' <param name="filePath">Путь к загрузочному файлу</param>
    ''' <remarks></remarks>
    Friend Sub DataLoadWordOld(ByVal filePath As String)
        Dim dateB As Date = Nothing
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Try
            '
            ' Открытие документа Word
            '
            R.LoadDocument(filePath)
            '
            ' Загрузка данных
            '
            With R.Document.Tables(0)
                For i As Integer = 0 To .Rows.Count - 1
                    Me.Rows.Add(New Object() {GetText(R.Document.GetText(.Cell(i, 0).Range)), "[устаревший код ТН ВЭД]", Date.Today, Date.Today})
                Next
            End With
        Catch ex As Exception
            Throw ex
        Finally
            R.Dispose()
        End Try
    End Sub

    ''' <summary>
    ''' Отметить в базе данных дату окончания сроков действия кодов ТН ВЭД
    ''' </summary>
    ''' <param name="dateE">Срок действия кодов ТН ВЭД</param>
    ''' <remarks></remarks>
    Friend Sub DataUpdateDateE(ByVal dateE As Date)
        If Me.Rows.Count = 0 Then Exit Sub
        Try
            For Each R As DataRow In Me.Rows
                Me.ExecuteNonQuery(String.Format("UPDATE tTnved SET dateE = {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} WHERE code = '{1}' AND dateE > {{ts '{0:yyyy-MM-dd HH:mm:ss}'}}", dateE, Trim(R("code").ToString)))
            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Загрузка данных из файла Word с иерархической таблицей кодов ТН ВЭД"

    ''' <summary>
    ''' Временная таблица для загрузки данных из файла Word с иерархической таблицей кодов ТН ВЭД
    ''' </summary>
    Private Class TempDataTable : Inherits DataTable

        Public Sub New()
            MyBase.New("TempTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("code", GetType(String))
                .Add("description", GetType(String))        ' Описание кода
                .Add("lev", GetType(Integer))               ' Уровень кода в дереве ТН ВЭД
                .Add("fullDescription", GetType(String))    ' Полное описание кода с учетом вышестоящих кодов
            End With
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub

        ''' <summary>
        ''' Перечитать полные описания кодов ТН ВЭД
        ''' </summary>
        Public Sub UpdateFullDescription()
            Dim sTmp As String = Nothing
            Dim iTmp As Integer = EMPTY_ID
            Dim iTmp1 As Integer = EMPTY_ID
            UpdateLev()
            Using V As New DataView(Me) With {.Sort = "id"}
                For i As Integer = 0 To V.Count - 1
                    sTmp = ToText(V(i)("description"))
                    iTmp = ToInt(V(i)("lev"))
                    If iTmp > 0 Then
                        sTmp = sTmp.Substring(iTmp * 2)
                        For j As Integer = i - 1 To 0 Step -1
                            iTmp1 = ToInt(V(j)("lev"))
                            If iTmp1 < iTmp Then
                                iTmp = iTmp1
                                sTmp = String.Format("{0} {1}", ToText(V(j)("description")).Substring(iTmp * 2), sTmp)
                            End If
                        Next
                    End If
                    If Not String.IsNullOrWhiteSpace(sTmp) Then sTmp = Trim(sTmp.Replace(vbCrLf, " "))
                    V(i)("fullDescription") = sTmp
                Next
            End Using
        End Sub

        ''' <summary>
        ''' Перечитать уровни кодов ТН ВЭД
        ''' </summary>
        Private Sub UpdateLev()
            Dim sTmp As String = Nothing
            Using V As New DataView(Me) With {.Sort = "id"}
                For i As Integer = 0 To V.Count - 1
                    V(i)("lev") = 0
                    sTmp = ToText(V(i)("description"))
                    If String.IsNullOrWhiteSpace(sTmp) Then Continue For
                    If Not sTmp Like "-*" Then Continue For
                    sTmp = sTmp.Replace(" ", Nothing)
                    If sTmp Like "----------*" Then
                        V(i)("lev") = 10
                    ElseIf sTmp Like "---------*" Then
                        V(i)("lev") = 9
                    ElseIf sTmp Like "--------*" Then
                        V(i)("lev") = 8
                    ElseIf sTmp Like "-------*" Then
                        V(i)("lev") = 7
                    ElseIf sTmp Like "------*" Then
                        V(i)("lev") = 6
                    ElseIf sTmp Like "-----*" Then
                        V(i)("lev") = 5
                    ElseIf sTmp Like "----*" Then
                        V(i)("lev") = 4
                    ElseIf sTmp Like "---*" Then
                        V(i)("lev") = 3
                    ElseIf sTmp Like "--*" Then
                        V(i)("lev") = 2
                    ElseIf sTmp Like "-*" Then
                        V(i)("lev") = 1
                    End If
                Next
            End Using
        End Sub

    End Class


    ''' <summary>
    ''' Загрузить товарные группы из файла Word с иерархической таблицей кодов ТН ВЭД в базу данных
    ''' </summary>
    ''' <param name="filePath">Путь к файлу Word</param>
    ''' <param name="dateB">Дата начала срока действия кодов</param>
    ''' <param name="dateE">Дата завершения срока действия кодов</param>
    Public Sub DataLoadWordIrGroup(filePath As String, dateB As Date, dateE As Date)
        Dim code As String = Nothing
        Dim description As String = Nothing
        Dim R As New DevExpress.XtraRichEdit.RichEditDocumentServer
        Dim TempTable As New TempDataTable
        Me.Rows.Clear()
        Try
            R.LoadDocument(filePath, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)
            For Each T As DevExpress.XtraRichEdit.API.Native.Table In R.Document.Tables
                TempTable.Rows.Clear()
                For i As Integer = 0 To T.Rows.Count - 1
                    TempTable.Rows.Add(New Object() {i + 1, _
                                                     DbText(R.Document.GetText(T.Cell(i, 0).ContentRange)), _
                                                     DbText(R.Document.GetText(T.Cell(i, 1).ContentRange)), _
                                                     DBNull.Value, DBNull.Value})
                Next
                TempTable.UpdateFullDescription()
                For Each Row As DataRow In TempTable.Rows
                    If Not IsDBNull(Row("code")) AndAlso Not IsDBNull(Row("description")) Then
                        If Me.Rows.Find(New Object() {Row("code"), dateB}) Is Nothing Then
                            Me.Rows.Add(New Object() {Row("code"), Row("fullDescription"), dateB, dateE})
                        End If
                    End If
                Next
            Next
            'Me.SaveToBase()
        Catch ex As Exception
            Throw ex
        Finally
            If Not R Is Nothing Then R.Dispose()
            If Not TempTable Is Nothing Then TempTable.Dispose()
        End Try
    End Sub



#End Region

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

End Class
