Imports C2 = Cprp.DxData.Common
''' <summary>
''' Источник данных нормативных документов
''' </summary>
Public Class LawDataSet : Inherits DataSet

    ''' <summary>
    ''' Таблица нормативных документов
    ''' </summary>
    Public LawTable As LawDataTable = Nothing

    ''' <summary>
    ''' Таблица кодов ТН ВЭД в нормативных документах
    ''' </summary>
    Public TnvedTable As TnvedDataTable = Nothing

    ''' <summary>
    ''' Таблица номеров CAS в нормативных документах
    ''' </summary>
    Public CasTable As CasDataTable = Nothing

    ''' <summary>
    ''' Таблица связей пунктов нормативных документов
    ''' </summary>
    Public LinkTable As LinkDataTable = Nothing

    ''' <summary>
    ''' Таблица ключевых слов в нормативных документах
    ''' </summary>
    Public WordTable As WordDataTable = Nothing

    ''' <summary>
    ''' Таблица связей ключевых слов с нормативными документами
    ''' </summary>
    Public WordLawTable As WordLawDataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New()
        MyBase.New("LawData")
        LawTable = New LawDataTable
        TnvedTable = New TnvedDataTable
        CasTable = New CasDataTable
        LinkTable = New LinkDataTable
        WordTable = New WordDataTable
        WordLawTable = New WordLawDataTable
        Me.Tables.AddRange(New DataTable() {LawTable, TnvedTable, CasTable, LinkTable, WordTable, WordLawTable})
        Dim Relation As New DataRelation("WordLawRelation", WordTable.Columns("id"), WordLawTable.Columns("wordId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation = New DataRelation("LawWordRelation", LawTable.Columns("id"), WordLawTable.Columns("lawId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
    End Sub


#Region "Загрузка данных из базы данных"

    ''' <summary>
    ''' Загрузить данные из базы данных
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="actDate">Дата актуализации данных</param> 
    ''' <param name="isExcont">Загрузить данные по экспортному контролю</param>
    ''' <param name="isMilitary">Загрузить данные по военно-техническому сотрудничеству</param>
    ''' <param name="isCustom">Загрузить данные по запретам и ограничениям Таможенного союза</param>
    ''' <param name="isExport">Загрузить данные для режима вывоза</param>
    ''' <param name="isImport">Загрузить данные для режима ввоза</param>
    ''' <param name="isOnlyList">Загрузить только контрольные списки и перечни запретов</param>
    Public Sub DataLoad(Connection As SqlConnection, actDate As Date, _
                        isExcont As Boolean, isMilitary As Boolean, isCustom As Boolean, _
                        isExport As Boolean, isImport As Boolean, _
                        isOnlyList As Boolean)
        '
        ' Формирование запроса на выборку данных из таблицы нормативных документов
        ' ========================================================================
        '
        ' Дата актуализации документов
        '
        Dim sTmp As String = String.Format("dateB <= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND dateE > {{ts '{0:yyyy-MM-dd HH:mm:ss}'}}", actDate)
        '
        ' Предметные области
        '
        If Not isExcont Then sTmp = String.Format("{0} AND areaId <> {1}", sTmp, CInt(Cprp.DxData.AreaEnum.isExcont))
        If Not isMilitary Then sTmp = String.Format("{0} AND areaId <> {1}", sTmp, CInt(Cprp.DxData.AreaEnum.isMilitary))
        If Not isCustom Then sTmp = String.Format("{0} AND areaId <> {1}", sTmp, CInt(Cprp.DxData.AreaEnum.isCustom))
        '
        ' Направления перемещения
        '
        If Not isExport Then sTmp = String.Format("{0} AND modeId <> {1}", sTmp, CInt(Cprp.DxData.ModeEnum.isExport))
        If Not isImport Then sTmp = String.Format("{0} AND modeId <> {1}", sTmp, CInt(Cprp.DxData.ModeEnum.isImport))
        '
        ' Только контрольные списки и перечни запретов
        '
        If isOnlyList Then sTmp = String.Format("{0} AND isList = 1", sTmp)
        '
        ' Очистка источника данных от всех данных 
        ' =======================================
        '
        Me.Clear()
        '
        ' Загрузка данных
        ' ===============
        '
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = String.Format( _
                "SELECT id, parentId, sortId, pos, description, posDescription, letterPosDescription, tnved, cas, doc, areaId, modeId, typeId, isList, lev " & _
                "FROM vLaw WHERE {0}", sTmp)
            Me.LawTable.Load(Cmd.ExecuteReader)
            If Me.LawTable.Rows.Count = 0 Then Exit Sub
            If isExcont Then
                Cmd.CommandText = "SELECT lawId, tnved, is2 FROM tLawTnved"
            Else
                Cmd.CommandText = "SELECT lawId, tnved, is2 FROM tLawTnved WHERE is2 = 0"
            End If
            Me.TnvedTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = "SELECT lawId, cas FROM tLawCas"
            Me.CasTable.Load(Cmd.ExecuteReader)
            Cmd.CommandText = "SELECT lawId, linkId FROM tLawLink"
            Me.LinkTable.Load(Cmd.ExecuteReader)
            'Cmd.CommandText = "SELECT id, word, excontListCount, customsListCount FROM vWord"
            'Me.WordTable.Load(Cmd.ExecuteReader)
            'Cmd.CommandText = String.Format( _
            '    "SELECT wordId, lawId FROM tWordLaw WHERE lawId IN (SELECT id FROM tLaw WHERE {0})", sTmp)
            'Me.WordLawTable.Load(Cmd.ExecuteReader)
        End Using

    End Sub

#End Region
#Region "Поиск по ключевым словам, кодам ТН ВЭД, номерам CAS"

    ''' <summary>
    ''' Поиск в нормативных документах по ключевым словам
    ''' </summary>
    ''' <param name="findString">Строка ключевых слов</param>
    ''' <param name="rowFilter">Фильтр представления для поиска</param> 
    Public Sub FindByWord(findString As String, rowFilter As String)
        If Not C2.IsText(findString) Then Exit Sub
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Dim bTmp As Boolean = False
        '
        ' Преобразование строки ключевых слов
        '
        For i As Integer = 0 To findString.Length - 1
            iTmp = Asc(findString(i))
            If iTmp < 32 Then Continue For
            Select Case iTmp
                Case 40, 41 : sTmp &= Chr(1)        ' "(", ")"
                Case 32 : sTmp &= Chr(2)            ' " "
                Case Else : sTmp &= findString(i)
            End Select
        Next
        If Not C2.IsText(sTmp) Then Exit Sub
        sTmp = sTmp.ToUpper

        Dim arrRow() As String = Nothing    ' Массив ключевых фраз
        Dim arrWord() As String = Nothing   ' Массив ключевых слов в ключевой фразе

        arrRow = sTmp.Split(New Char() {Chr(1)}, StringSplitOptions.RemoveEmptyEntries)
        '
        ' Цикл по представлению нормативных документов
        '
        Using V As New DataView(Me.LawTable)
            If C2.IsText(rowFilter) Then V.RowFilter = rowFilter
            For i As Integer = 0 To V.Count - 1
                sTmp = V(i)("posDescription").ToString.ToUpper
                '
                ' Цикл по массиву ключевых фраз
                '
                For j As Integer = arrRow.GetLowerBound(0) To arrRow.GetUpperBound(0)
                    '
                    ' Массив ключевых слов в текущей ключевой фразе
                    '
                    arrWord = arrRow(j).Split(New Char() {Chr(2)}, StringSplitOptions.RemoveEmptyEntries)
                    If arrWord.Length = 0 Then Continue For
                    '
                    ' Цикл по массиву ключевых слов
                    '
                    bTmp = True
                    For k As Integer = arrWord.GetLowerBound(0) To arrWord.GetUpperBound(0)
                        If sTmp Like String.Format("*{0}*", arrWord(k)) Then Continue For
                        bTmp = False
                        Exit For
                    Next
                    If Not bTmp Then Continue For
                    '
                    ' Текущая строка таблицы нормативных документов соответствует ключевой фразе
                    '
                    V(i).Row("isFindWord") = True
                    Exit For
                Next
            Next
        End Using

    End Sub

    ''' <summary>
    ''' Поиск в нормативных документах по двум ключевым словам из нормативных документов
    ''' </summary>
    ''' <param name="word1Id">ID первого ключевого слова из таблицы WordTable</param>
    ''' <param name="word2Id">ID второго ключевого слова из таблицы WordTable</param>
    ''' <param name="rowFilter">Фильтр представления для поиска</param> 
    Public Sub FindByTwoWord(word1Id As Integer, word2Id As Integer, rowFilter As String)
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        Using V As New DataView(WordLawTable)
            sTmp1 = "0"
            V.RowFilter = String.Format("wordId = {0}", word1Id)
            For Each VRow As DataRowView In V
                sTmp1 = String.Format("{0}, {1}", sTmp1, CInt(VRow("lawId")))
            Next
            sTmp = String.Format("id IN ({0})", sTmp1)
            sTmp1 = "0"
            V.RowFilter = String.Format("wordId = {0}", word2Id)
            For Each VRow As DataRowView In V
                sTmp1 = String.Format("{0}, {1}", sTmp1, CInt(VRow("lawId")))
            Next
            sTmp = String.Format("({0} AND id IN ({1}))", sTmp, sTmp1)
        End Using
        If C2.IsText(rowFilter) Then sTmp = String.Format("{0} AND {1}", sTmp, rowFilter)
        Using V As New DataView(LawTable) With {.RowFilter = sTmp}
            For Each VRow As DataRowView In V
                VRow("isFindWord") = True
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Поиск в нормативных документах по кодам ТН ВЭД
    ''' </summary>
    ''' <param name="findString">Строка кодов ТН ВЭД</param>
    ''' <param name="rowFilter">Фильтр представления для поиска</param> 
    ''' <remarks></remarks>
    Public Sub FindByTnved(findString As String, rowFilter As String)
        If Not C2.IsText(findString) Then Exit Sub
        '
        ' Преобразование строки ключевых слов
        '
        For Each c As Char In findString
            If c = "A" Then Continue For
            If Not c Like "[0123456789]" Then findString = findString.Replace(c, "A")
        Next
        '
        ' Массив кодов ТН ВЭД для поиска
        '
        Dim arrTnved() As String = findString.Split(New Char() {"A"}, StringSplitOptions.RemoveEmptyEntries)
        '
        ' Поиск в массиве кодов ТН ВЭД, выделение результатов поиска
        '
        'Dim Row As DataRow = Nothing
        Dim iTmp As Integer = 0
        Using V As New DataView(Me.TnvedTable)
            Using V1 As New DataView(Me.LawTable) With {.Sort = "id", .RowFilter = rowFilter}
                For Each tnved In arrTnved
                    V.RowFilter = String.Format("tnved LIKE '{0}%' OR '{0}' LIKE (tnved + '%')", tnved)
                    For Each VRow As DataRowView In V
                        'Row = Me.LawTable.Rows.Find(VRow("lawId"))
                        'If Row Is Nothing Then Continue For
                        iTmp = V1.Find(VRow("lawId"))
                        If iTmp < 0 Then Continue For
                        If CBool(VRow("is2")) Then
                            ' поиск по коду ЦПРП считается поиском по ключевому слову
                            'Row("isFindWord") = True
                            V1(iTmp).Row("isFindWord") = True
                        Else
                            'Row("isFindTnved") = True
                            V1(iTmp).Row("isFindTnved") = True
                        End If
                    Next
                Next
            End Using
        End Using
    End Sub

    ' ''' <summary>
    ' ''' Поиск в нормативных документах по кодам ТН ВЭД
    ' ''' </summary>
    ' ''' <param name="findString">Строка кодов ТН ВЭД</param>
    ' ''' <param name="rowFilter">Фильтр представления для поиска</param> 
    'Public Sub FindByTnved(findString As String, rowFilter As String)
    '    If Not C2.IsText(findString) Then Exit Sub
    '    Dim sTmp As String = Nothing
    '    Dim iTmp As Integer = 0
    '    Dim bTmp As Boolean = False
    '    '
    '    ' Преобразование строки кодов ТН ВЭД
    '    '
    '    For i As Integer = 0 To findString.Length - 1
    '        iTmp = Asc(findString(i))
    '        If iTmp < 32 Then Continue For
    '        Select Case iTmp
    '            Case 48 To 57 : sTmp &= findString(i)       ' 0...9
    '            Case Else : sTmp &= Chr(1)
    '        End Select
    '    Next
    '    If Not C2.IsText(sTmp) Then Exit Sub
    '    '
    '    ' Массив кодов ТН ВЭД для поиска
    '    '
    '    Dim arrTnved() As String = sTmp.Split(New Char() {Chr(1)}, StringSplitOptions.RemoveEmptyEntries)
    '    If arrTnved.Length = 0 Then Exit Sub
    '    '
    '    ' Формирование фильтра для представления кодов ТН ВЭД
    '    '
    '    sTmp = Nothing
    '    For i As Integer = arrTnved.GetLowerBound(0) To arrTnved.GetUpperBound(0)
    '        sTmp = String.Format("{0} OR tnved LIKE '{1}%' OR '{1}' LIKE (tnved + '%')", sTmp, arrTnved(i))
    '    Next
    '    '
    '    ' Формирование строки id пунктов нормативных документов, соответствующих условиям поиска
    '    '
    '    Using V As New DataView(Me.TnvedTable)
    '        V.RowFilter = sTmp.Substring(4)
    '        sTmp = Nothing
    '        For i As Integer = 0 To V.Count - 1
    '            sTmp = String.Format("{0}, {1}", sTmp, CInt(V(i)("lawId")))
    '        Next
    '    End Using
    '    sTmp = C2.ToStrNum(sTmp, False)
    '    '
    '    ' Фильтр для представления пунктов нормативных документов, соответствующих условиям поиска
    '    '
    '    sTmp = String.Format("id IN (0, {0})", sTmp)
    '    If C2.IsText(rowFilter) Then sTmp = String.Format("{0} AND ({1})", sTmp, rowFilter)
    '    '
    '    ' Выделение пунктов нормативных документов, соответствующих условиям поиска
    '    '
    '    Using V As New DataView(Me.LawTable)
    '        V.RowFilter = sTmp
    '        For i As Integer = 0 To V.Count - 1
    '            V(i).Row("isFindTnved") = True
    '        Next
    '    End Using

    'End Sub

    ''' <summary>
    ''' Поиск в нормативных документах по номерам CAS
    ''' </summary>
    ''' <param name="findString">Строка номеров CAS</param>
    ''' <param name="rowFilter">Фильтр представления для поиска</param> 
    ''' <remarks></remarks>
    Public Sub FindByCas(findString As String, rowFilter As String)
        If Not C2.IsText(findString) Then Exit Sub
        Dim sTmp As String = Nothing
        Dim iTmp As Integer = 0
        Dim bTmp As Boolean = False
        '
        ' Преобразование строки номеров CAS
        '
        For i As Integer = 0 To findString.Length - 1
            iTmp = Asc(findString(i))
            If iTmp < 32 Then Continue For
            Select Case iTmp
                Case 45, 48 To 57 : sTmp &= findString(i)       ' -, 0...9
                Case Else : sTmp &= Chr(1)
            End Select
        Next
        If Not C2.IsText(sTmp) Then Exit Sub
        '
        ' Массив номеров CAS для поиска
        '
        Dim arrCAS() As String = sTmp.Split(New Char() {Chr(1)}, StringSplitOptions.RemoveEmptyEntries)
        If arrCAS.Length = 0 Then Exit Sub
        '
        ' Формирование фильтра для представления номеров CAS
        '
        sTmp = Nothing
        For i As Integer = arrCAS.GetLowerBound(0) To arrCAS.GetUpperBound(0)
            sTmp = String.Format("{0} OR cas LIKE '{1}%' OR '{1}' LIKE (cas + '%')", sTmp, arrCAS(i))
        Next
        '
        ' Формирование строки id пунктов нормативных документов, соответствующих условиям поиска
        '
        Using V As New DataView(Me.CasTable)
            V.RowFilter = sTmp.Substring(4)
            sTmp = Nothing
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0}, {1}", sTmp, CInt(V(i)("lawId")))
            Next
        End Using
        sTmp = C2.ToStrNum(sTmp, False)
        '
        ' Фильтр для представления пунктов нормативных документов, соответствующих условиям поиска
        '
        sTmp = String.Format("id IN (0, {0})", sTmp)
        If C2.IsText(rowFilter) Then sTmp = String.Format("{0} AND ({1})", sTmp, rowFilter)
        '
        ' Выделение пунктов нормативных документов, соответствующих условиям поиска
        '
        Using V As New DataView(Me.LawTable)
            V.RowFilter = sTmp
            For i As Integer = 0 To V.Count - 1
                V(i).Row("isFindCas") = True
            Next
        End Using

    End Sub

    ''' <summary>
    ''' Возвращает id предыдущего пункта в дереве документов, содержащий указанный текст
    ''' </summary>
    ''' <param name="startId">id стартового пункта</param>
    ''' <param name="text">Текст для поиска</param>
    ''' <remarks>Если пункт не найден, возвращает Cprp.DxData.Convert.EMPTY_VALUE</remarks> 
    Public ReadOnly Property FindPrevIdByText(startId As Integer, text As String) As Integer
        Get
            text = C2.ToText(text)
            If String.IsNullOrWhiteSpace(text) Then Return C2.EMPTY_ID
            text = text.ToUpper
            Dim sTmp As String = Nothing
            For i As Integer = 0 To LawTable.DefaultView.Count - 1
                If CInt(LawTable.DefaultView(i)("id")) = startId Then
                    For j As Integer = i - 1 To 0 Step -1
                        sTmp = LawTable.DefaultView(j)("posDescription").ToString
                        If sTmp.ToUpper Like String.Format("*{0}*", text) Then Return CInt(LawTable.DefaultView(j)("id"))
                    Next
                    Return C2.EMPTY_ID
                End If
            Next
            Return C2.EMPTY_ID
        End Get
    End Property

    ''' <summary>
    ''' Возвращает id следующего пункта в дереве документов, содержащий указанный текст
    ''' </summary>
    ''' <param name="startId">id стартового пункта</param>
    ''' <param name="text">Текст для поиска</param>
    ''' <remarks>Если пункт не найден, возвращает Cprp.DxData.Convert.EMPTY_VALUE</remarks> 
    Public ReadOnly Property FindNextIdByText(startId As Integer, text As String) As Integer
        Get
            text = C2.ToText(text)
            If String.IsNullOrWhiteSpace(text) Then Return C2.EMPTY_ID
            text = text.ToUpper
            Dim sTmp As String = Nothing
            For i As Integer = 0 To LawTable.DefaultView.Count - 1
                If CInt(LawTable.DefaultView(i)("id")) = startId Then
                    For j As Integer = i + 1 To LawTable.DefaultView.Count - 1
                        sTmp = LawTable.DefaultView(j)("posDescription").ToString
                        If sTmp.ToUpper Like String.Format("*{0}*", text) Then Return CInt(LawTable.DefaultView(j)("id"))
                    Next
                    Return C2.EMPTY_ID
                End If
            Next
            Return C2.EMPTY_ID
        End Get
    End Property

#End Region
#Region "Навигация по дереву найденных / отмеченных пунктов"

    ''' <summary>
    ''' Возвращает id предыдущего выделеного / отмеченного пункта
    ''' </summary>
    ''' <param name="startId">id стартового пункта</param>
    ''' <remarks>Если пункт не найден, возвращает Cprp.DxData.Convert.EMPTY_ID</remarks>
    Public ReadOnly Property SelectionPrevId(startId As Integer) As Integer
        Get
            Using V As New DataView(LawTable)
                V.Sort = "doc, Id"
                For i As Integer = 0 To V.Count - 1
                    If CInt(V(i)("id")) = startId Then
                        For j As Integer = i - 1 To 0 Step -1
                            If CBool(V(j)("isFindTnved")) Then Return CInt(V(j)("id"))
                            If CBool(V(j)("isFindCas")) Then Return CInt(V(j)("id"))
                            If CBool(V(j)("isFindWord")) Then Return CInt(V(j)("id"))
                            If CBool(V(j)("isSel")) Then Return CInt(V(j)("id"))
                        Next
                        Return C2.EMPTY_ID
                    End If
                Next
            End Using
            Return C2.EMPTY_ID
        End Get
    End Property

    ''' <summary>
    ''' Возвращает id следующего выделеного / отмеченного пункта
    ''' </summary>
    ''' <param name="startId">id стартового пункта</param>
    ''' <remarks>Если пункт не найден, возвращает Cprp.DxData.Convert.EMPTY_ID</remarks>
    Public ReadOnly Property SelectionNextId(startId As Integer) As Integer
        Get
            Using V As New DataView(LawTable)
                V.Sort = "doc, Id"
                For i As Integer = 0 To V.Count - 1
                    If CInt(V(i)("id")) = startId Then
                        For j As Integer = i + 1 To V.Count - 1
                            If CBool(V(j)("isFindTnved")) Then Return CInt(V(j)("id"))
                            If CBool(V(j)("isFindCas")) Then Return CInt(V(j)("id"))
                            If CBool(V(j)("isFindWord")) Then Return CInt(V(j)("id"))
                            If CBool(V(j)("isSel")) Then Return CInt(V(j)("id"))
                        Next
                        Return C2.EMPTY_ID
                    End If
                Next
            End Using
            Return C2.EMPTY_ID
        End Get
    End Property

#End Region
#Region "Обработка результатов поиска"

    ''' <summary>
    ''' Возвращает количество найденных строк
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property FindCount As Integer
        Get
            Using V As New DataView(LawTable)
                V.RowFilter = "isFindTnved = True OR isFindCas = True OR isFindWord = True"
                Return V.Count
            End Using
        End Get
    End Property

    ''' <summary>
    ''' Возвращает количество найденных пунктов
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property FindPosCount As Integer
        Get
            Using V As New DataView(LawTable)
                V.RowFilter = String.Format("typeId = {0} AND (isFindTnved = True OR isFindCas = True OR isFindWord = True)", CInt(TypeEnum.IsParagraph))
                Return V.Count
            End Using
        End Get
    End Property

    ''' <summary>
    ''' Очистить результаты поиска
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub FindClear()
        Using V As New DataView(Me.LawTable)
            V.RowFilter = "isFindWord = True OR isFindTnved = True OR isFindCas = True"
            While V.Count > 0
                With V(0).Row
                    .Item("isFindWord") = False
                    .Item("isFindTnved") = False
                    .Item("isFindCas") = False
                End With
            End While
        End Using
    End Sub

#End Region
#Region "Обработка выбранных строк"

    ''' <summary>
    ''' Представление с деревом отмеченных пунктов
    ''' </summary>
    Public ReadOnly Property SelectionTreeDataView As DataView
        Get
            Dim V As New DataView(LawTable)
            Dim rowFilter As String = "isSel = True"
            V.RowFilter = rowFilter
            Dim iTmp As Integer = 0
            rowFilter = Nothing
            For i As Integer = 0 To V.Count - 1
                iTmp = CInt(V(i)("id"))
                rowFilter &= String.Format("{0}, {1}{2}", iTmp, GetParentIdByChildId(iTmp, True), GetChildIdByParentId(iTmp, True))
            Next
            ' Окончательный фильтр представления
            V.RowFilter = String.Format("id IN ({0})", C2.ToStrNum(rowFilter, False))
            Return V
        End Get
    End Property

    ''' <summary>
    ''' Представление с деревом найденных и отмеченных пунктов
    ''' </summary>
    ''' <param name="isFindTnved">Включить пункты, найденные по коду ТН ВЭД</param> 
    ''' <param name="isFindWord">Включить пункты, найденные по ключевым словам</param>
    ''' <param name="isFindCas">Включить пункты, найденные по номеру CAS</param>
    ''' <param name="addComment">Включить примечания</param>
    Public Function GetFindSelectionTreeDataView(isFindTnved As Boolean, isFindWord As Boolean, isFindCas As Boolean, addComment As Boolean) As DataView
        Dim V As New DataView(LawTable)
        Dim rowFilter As String = "isSel = True"
        If isFindTnved Then rowFilter &= " OR isFindTnved = True"
        If isFindWord Then rowFilter &= "OR isFindWord = True"
        If isFindCas Then rowFilter &= "OR isFindCas = True"
        If Not addComment Then rowFilter = String.Format("({0}) AND typeId <> 2", rowFilter)
        V.RowFilter = rowFilter
        Dim iTmp As Integer = 0
        rowFilter = Nothing
        For i As Integer = 0 To V.Count - 1
            iTmp = CInt(V(i)("id"))
            rowFilter &= String.Format("{0}, {1}{2}", iTmp, GetParentIdByChildId(iTmp, addComment), GetChildIdByParentId(iTmp, addComment))
        Next
        ' Окончательный фильтр представления
        V.RowFilter = String.Format("id IN ({0})", C2.ToStrNum(rowFilter, False))
        Return V
    End Function

    ''' <summary>
    ''' Возвращает количество выбранных строк
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property SelectionCount As Integer
        Get
            Using V As New DataView(LawTable)
                V.RowFilter = "isSel = True"
                Return V.Count
            End Using
        End Get
    End Property

    ''' <summary>
    ''' Очистить выбранные строки
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub SelectionClear()
        Using V As New DataView(Me.LawTable)
            V.RowFilter = "isSel = True"
            While V.Count > 0
                V(0).Row("isSel") = False
            End While
        End Using
    End Sub

    ''' <summary>
    ''' Очистить найденные и выбранные строки
    ''' </summary>
    ''' <remarks></remarks>
    Public Overridable Sub FindSelectionClear()
        Using V As New DataView(Me.LawTable)
            V.RowFilter = "isSel = True"
            While V.Count > 0
                V(0).Row("isSel") = False
            End While
            V.RowFilter = "isFindTnved = True"
            While V.Count > 0
                V(0).Row("isFindTnved") = False
            End While
            V.RowFilter = "isFindWord = True"
            While V.Count > 0
                V(0).Row("isFindWord") = False
            End While
            V.RowFilter = "isFindCas = True"
            While V.Count > 0
                V(0).Row("isFindCas") = False
            End While
        End Using
    End Sub

#End Region

    ''' <summary>
    ''' Возвращает True если указанный дочерний пункт является потомком указанного родительского пункта
    ''' </summary>
    ''' <param name="childId">id дочернего пункта</param>
    ''' <param name="parentId">id родительского пункта</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function IsChildParent(childId As Integer, parentId As Integer) As Boolean
        Dim Row As DataRow = Nothing
        Dim currentId As Integer = childId
        Do
            Row = LawTable.Rows.Find(currentId)
            If Row Is Nothing Then Return False
            currentId = C2.ToInt(Row("parentId"))
            If currentId = C2.EMPTY_ID Then Return False
            If currentId = CInt(Row("id")) Then Return False ' если случайно в строке id = parentId
            If currentId = parentId Then Return True
        Loop
        Return False
    End Function


End Class
