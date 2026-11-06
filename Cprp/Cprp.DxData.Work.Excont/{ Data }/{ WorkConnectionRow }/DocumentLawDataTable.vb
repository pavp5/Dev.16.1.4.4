Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица исследований объектов экспертизы для одного заключения экспертизы
''' </summary>
Friend Class DocumentLawDataTable : Inherits DataTable

    ' Работа
    Private W As WorkConnectionRow = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Work">Работа</param> 
    ''' <param name="GoodTable">Таблица объектов экспертизы из заключения экспертизы</param>
    ''' <remarks></remarks>
    Public Sub New(Work As WorkConnectionRow, GoodTable As DocumentGoodDataTable)
        '
        ' Структура
        '
        MyBase.New()
        With Me.Columns
            .Add("goodId", GetType(Integer))            ' id строки таблицы объектов экспертизы
            .Add("lawId", GetType(Integer))             ' id строки таблицы исследований
            .Add("goodNum", GetType(Integer))           ' порядковый номер объекта экспертизы
            .Add("summaryId", GetType(Integer))         ' идентификатор контрольного статуса
            .Add("lawDescription", GetType(String))     ' переработанное описание пункта контрольного списка
            .Add("goodDescription", GetType(String))    ' технические характеристики для сравнения
            .Add("groupText", GetType(String))          ' группировка строк по какому-нибудь признаку
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("goodId"), Me.Columns("lawId")}
        '
        ' Работа
        '
        W = Work
        '
        ' Данные
        '
        Dim bTmp As Boolean = False
        Dim LRow As DataRow = Nothing
        Using V As New DataView(W.GoodLawTable)
            '
            ' Цикл по всем объектам экспертизы из заключения
            '
            For Each Row As DataRow In GoodTable.Rows
                '
                ' Исследование текущего объекта не проводилось: lawId = C2.EMPTY_ID, summaryId = C2.EMPTY_ID
                '
                If IsDBNull(W.GoodTable.Rows.Find(Row("id"))("studyDate")) Then
                    Me.Rows.Add(New Object() _
                                {Row("id"), _
                                 C2.EMPTY_ID, _
                                 Row("rowNum"), _
                                 C2.EMPTY_ID, _
                                 DBNull.Value, _
                                 DBNull.Value, _
                                 DBNull.Value})
                    Continue For
                End If
                '
                ' Записи таблицы исследований текущего объекта, 
                ' найденные по коду ТН ВЭД или выбранные для сравнительного анализа
                '
                V.RowFilter = String.Format( _
                    "goodId = {0} AND ( isFindTnved = True OR summaryId > {1})", _
                    CInt(Row("id")), CInt(Cprp.DxData.Law.StudyIndexEnum.IsNothing))
                '
                ' ПУНКТЫ КОНТРОЛЬНЫХ СПИСКОВ текущего объекта, 
                ' найденные по коду ТН ВЭД или выбранные для сравнительного анализа
                '
                bTmp = False
                For Each VRow As DataRowView In V
                    '
                    ' Строка справочника нормативных документов
                    '
                    LRow = W.LawDataSet.LawTable.Rows.Find(VRow("lawId"))
                    '
                    ' Проверка строки
                    '
                    If LRow Is Nothing Then Continue For
                    ' не та предметная область
                    If CType(LRow("areaId"), Cprp.DxData.AreaEnum) <> Cprp.DxData.AreaEnum.isExcont Then Continue For
                    ' не список (закон, положение)
                    If IsDBNull(LRow("isList")) OrElse Not CBool(LRow("isList")) Then Continue For
                    ' не пункт списка (примечание, заголовок)
                    If CType(LRow("typeId"), Cprp.DxData.Law.TypeEnum) <> Cprp.DxData.Law.TypeEnum.IsParagraph Then Continue For
                    '
                    ' Добавление данных в текущую таблицу
                    '
                    Me.Rows.Add(New Object() _
                               {Row("id"), _
                                LRow("id"), _
                                Row("rowNum"), _
                                CInt(VRow("summaryId")), _
                                VRow("lawDescription"), _
                                VRow("goodDescription"), _
                                DBNull.Value})
                    bTmp = True
                Next
                '
                ' Нет ПУНКТОВ КОНТРОЛЬНЫХ СПИСКОВ текущего объекта, 
                ' найденных по коду ТН ВЭД или выбранных для сравнительного анализа:
                ' lawId = C2.EMPTY_ID, summaryId = Cprp.DxData.Law.StudyIndexEnum.IsNothing
                '
                If Not bTmp Then
                    Me.Rows.Add(New Object() _
                                {Row("id"), _
                                 C2.EMPTY_ID, _
                                 Row("rowNum"), _
                                 CInt(Cprp.DxData.Law.StudyIndexEnum.IsNothing), _
                                 DBNull.Value, _
                                 DBNull.Value, _
                                 DBNull.Value})
                End If
            Next
        End Using
    End Sub


    ''' <summary>
    ''' Таблица блоков параграфов с пунктами контрольных списков, рассмотренных по каждому объекту экспертизы
    ''' </summary>
    ''' <remarks></remarks> 
    Public Function GetParagraphTable() As DataTable
        Dim Row As DataRow, sTmp As String
        '
        ' Структура
        '
        Dim T As New DataTable
        With T.Columns
            .Add("goodNumS", GetType(String))           ' перечень порядковых номеров объектов экспертизы
            .Add("paragraph", GetType(String))          ' блок параграфов с номерами пунктов контрольных списков
        End With
        '
        ' Очистка столбца группировки таблицы исследований
        '
        For Each Row In Me.Rows
            Row("groupText") = DBNull.Value
        Next
        '
        ' Данные
        '
        Using V As New DataView(Me)
            '
            ' Групировка строк таблицы исследований по пунктам контрольных списков,
            ' найденным по коду ТН ВЭД или выбранным для сравнительного анализа
            '
            V.RowFilter = "lawId > 0"
            Using V1 As New DataView(Me)
                For i As Integer = 0 To V.Count - 1
                    If C2.IsText(V(i)("groupText")) Then Continue For
                    sTmp = Nothing
                    V1.RowFilter = String.Format("goodId = {0}", C2.ToInt(V(i)("goodId")))
                    For Each VRow As DataRowView In V1
                        sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToInt(VRow("lawId")))
                    Next
                    sTmp = C2.ToStrNum(sTmp, False)
                    For Each VRow As DataRowView In V1
                        VRow("groupText") = sTmp
                    Next
                Next
            End Using
            '
            ' Данные по пунктам контрольных списков, найденным по коду ТН ВЭД или выбранным для сравнительного анализа
            '
            V.RowFilter = "groupText > '0'"
            V.Sort = "groupText"
            sTmp = Nothing
            For i As Integer = 0 To V.Count - 1
                If i = 0 Then
                    sTmp = C2.ToText(V(0)("goodNum"))
                ElseIf C2.ToText(V(i)("groupText")) = C2.ToText(V(i - 1)("groupText")) Then
                    sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToInt(V(i)("goodNum")))
                Else
                    T.Rows.Add(New Object() { _
                               C2.ToStrNum(sTmp, True), _
                               W.LawDataSet.GetExcontParagraphById(C2.ToText(V(i - 1)("groupText")))})
                    sTmp = C2.ToText(V(i)("goodNum"))
                End If
            Next
            If V.Count > 0 Then
                T.Rows.Add(New Object() { _
                           C2.ToStrNum(sTmp, True), _
                           W.LawDataSet.GetExcontParagraphById(C2.ToText(V(V.Count - 1)("groupText")))})
            End If
            '
            ' Данные по объектам экспертизы, по которым ничего не найдено по коду ТН ВЭД и ничего не выбрано для сравнительного анализа
            '
            sTmp = Nothing
            Using V1 As New DataView(Me)
                V.RowFilter = String.Format("summaryId <> {0}", C2.EMPTY_ID)    ' исключаются объекты, по которым не было иследований
                For i As Integer = 0 To V.Count - 1
                    V1.RowFilter = String.Format("goodId = {0} AND lawId > 0", C2.ToInt(V(i)("goodId")))
                    If V1.Count = 0 Then
                        sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(V(i)("goodNum")))
                    End If
                Next
            End Using
            If C2.IsText(sTmp) Then
                T.Rows.Add(New Object() { _
                           C2.ToStrNum(sTmp, True), _
                           "Позиции (пункты) контрольных списков не выявлены"})
            End If
            '
            ' Данные по объектам экспертизы, по которым не было исследований
            '
            sTmp = Nothing
            V.RowFilter = String.Format("lawId = {0} AND summaryId = {0}", C2.EMPTY_ID)
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(V(i)("goodNum")))
            Next
            If C2.IsText(sTmp) Then
                T.Rows.Add(New Object() { _
                           C2.ToStrNum(sTmp, True), _
                           DBNull.Value})
            End If

        End Using


        Return T
    End Function


    ''' <summary>
    ''' Таблица пунктов, выбранных для сравнительного анализа
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetSelectionTable() As DataTable
        Dim Row As DataRow, sTmp As String
        '
        ' Структура
        '
        Dim T As New DataTable
        With T.Columns
            .Add("goodNumS", GetType(String))           ' строка порядковых номеров объектов экспертизы
            .Add("lawDoc", GetType(String))             ' шифр пункта (для сортировки таблицы)
            .Add("lawList", GetType(String))            ' заголовок списка
            .Add("lawSection", GetType(String))         ' номер раздела списка
            .Add("lawPos", GetType(String))             ' номер пункта
        End With
        '
        ' Очистка столбца группировки таблицы исследований
        '
        For Each Row In Me.Rows
            Row("groupText") = DBNull.Value
        Next
        '
        ' Данные
        '
        Using V As New DataView(Me)
            '
            ' Данные по объектам экспертизы, выбранным для сравнительного анализа
            ' Группировка по одинаковым пунктам списков
            '
            V.RowFilter = "summaryId > 0"
            For i As Integer = 0 To V.Count - 1
                If Not IsDBNull(V(i)("groupText")) Then Continue For
                Row = W.LawDataSet.LawTable.Rows.Find(V(i)("lawId"))
                If Row Is Nothing Then Continue For
                sTmp = C2.ToText(V(i)("goodNum"))
                For j As Integer = i + 1 To V.Count - 1
                    If CInt(Row("id")) = C2.ToInt(V(j)("lawId")) Then
                        sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(V(j)("goodNum")))
                        ' признак, что строка уже включена в группировку
                        V(j)("groupText") = "N"
                    End If
                Next
                T.Rows.Add(New Object() { _
                           C2.ToStrNum(sTmp, True), _
                           Row("doc"), _
                           W.LawDataSet.GetLawCaptionByDoc(C2.ToText(Row("doc"))), _
                           W.LawDataSet.GetLawSectionByDoc(C2.ToText(Row("doc"))), _
                           Row("pos")})
            Next
            '
            ' Данные по объектам экспертизы, не выбранным для сравнительного анализа
            ' Формирование строки порядковых номеров объектов экспертизы, не выбранных для сравнительного анализа
            '
            sTmp = Nothing
            Using V1 As New DataView(Me)
                V.RowFilter = String.Format("summaryId <> {0}", C2.EMPTY_ID)    ' исключаются объекты, по которым не было иследований
                For i As Integer = 0 To V.Count - 1
                    V1.RowFilter = String.Format("goodId = {0} AND summaryId > 0", C2.ToInt(V(i)("goodId")))
                    If V1.Count = 0 Then
                        sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(V(i)("goodNum")))
                    End If
                Next
            End Using
            If C2.IsText(sTmp) Then
                T.Rows.Add(New Object() { _
                           C2.ToStrNum(sTmp, True), _
                           DBNull.Value, _
                           "-", _
                           "-", _
                           "Позиций (пунктов) обладающих признаками сходства с объектом экспертизы не имеется"})
            End If
            '
            ' Данные по объектам экспертизы, по которым не было исследований
            '
            sTmp = Nothing
            V.RowFilter = String.Format("lawId = {0} AND summaryId = {0}", C2.EMPTY_ID)
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(V(i)("goodNum")))
            Next
            If C2.IsText(sTmp) Then
                T.Rows.Add(New Object() { _
                           C2.ToStrNum(sTmp, True), _
                           DBNull.Value, _
                           DBNull.Value, _
                           DBNull.Value, _
                           DBNull.Value})
            End If

        End Using

        Return T
    End Function


    ''' <summary>
    ''' Таблица результатов сравнительного анализа
    ''' </summary>
    ''' <remarks></remarks>
    Public Function GetStudyTable() As DataTable
        Dim Row As DataRow, sTmp As String, sTmp1 As String, sTmp2 As String
        '
        ' Структура
        '
        Dim T As New DataTable
        With T.Columns
            .Add("goodNumS", GetType(String))           ' строка порядковых номеров объектов экспертизы
            .Add("lawDoc", GetType(String))             ' шифр пункта (для сортировки таблицы)
            .Add("lawPosDescription", GetType(String))  ' номер + описание пункта
            .Add("goodDescription", GetType(String))    ' технические характеристики для сравнения
            .Add("summary", GetType(String))            ' выводы по результатам сравнения
        End With
        '
        ' Очистка столбца группировки таблицы исследований
        '
        For Each Row In Me.Rows
            Row("groupText") = DBNull.Value
        Next
        '
        ' Данные
        '
        Using V As New DataView(Me)
            '
            ' Данные по объектам экспертизы, выбранным для сравнительного анализа
            ' Группировка по одинаковым пунктам списков, одинаковым переработанным техническим описаниям и одинаковым техническим характеристикам
            '
            V.RowFilter = "summaryId > 0"
            For i As Integer = 0 To V.Count - 1
                If Not IsDBNull(V(i)("groupText")) Then Continue For
                Row = W.LawDataSet.LawTable.Rows.Find(V(i)("lawId"))
                If Row Is Nothing Then Continue For
                sTmp = C2.ToText(V(i)("goodNum"))
                sTmp1 = C2.ToText(V(i)("lawDescription"))   ' текущие тех. описание
                sTmp2 = C2.ToText(V(i)("goodDescription"))  ' текущие тех. характеристики
                For j As Integer = i + 1 To V.Count - 1
                    If CInt(Row("id")) <> C2.ToInt(V(j)("lawId")) Then Continue For
                    If sTmp1 <> C2.ToText(V(j)("lawDescription")) Then Continue For
                    If sTmp2 <> C2.ToText(V(j)("goodDescription")) Then Continue For
                    sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(V(j)("goodNum")))
                    ' признак, что строка уже включена в группировку
                    V(j)("groupText") = "N"
                Next
                ' Выводы по результатам сравнительного анализа
                If C2.IsText(sTmp1) Then sTmp1 = If(CInt(V(i)("summaryId")) > 1, _
                    "Соответствует контролируемым товарам (технологиям)", "Не соответствует контролируемым товарам (технологиям)")
                T.Rows.Add(New Object() { _
                           C2.ToStrNum(sTmp, True), _
                           Row("doc"), _
                           V(i)("lawDescription"), _
                           V(i)("goodDescription"), _
                           If(C2.IsText(sTmp1), sTmp1, DBNull.Value)})
            Next
            '
            ' Данные по объектам экспертизы, не выбранным для сравнительного анализа
            ' Формирование строки порядковых номеров объектов экспертизы, не выбранных для сравнительного анализа
            '
            sTmp = Nothing
            Using V1 As New DataView(Me)
                V.RowFilter = String.Format("summaryId <> {0}", C2.EMPTY_ID)    ' исключаются объекты, по которым не было иследований
                For i As Integer = 0 To V.Count - 1
                    V1.RowFilter = String.Format("goodId = {0} AND summaryId > 0", C2.ToInt(V(i)("goodId")))
                    If V1.Count = 0 Then
                        sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(V(i)("goodNum")))
                    End If
                Next
            End Using
            If C2.IsText(sTmp) Then
                T.Rows.Add(New Object() { _
                           C2.ToStrNum(sTmp, True), _
                           DBNull.Value, _
                           "Позиций (пунктов) обладающих признаками сходства с объектом экспертизы не имеется", _
                           "-", _
                           "-"})
            End If

            '
            ' Данные по объектам экспертизы, по которым не было исследований
            '
            sTmp = Nothing
            V.RowFilter = String.Format("lawId = {0} AND summaryId = {0}", C2.EMPTY_ID)
            For i As Integer = 0 To V.Count - 1
                sTmp = String.Format("{0}{1}{2}{1}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(V(i)("goodNum")))
            Next
            If C2.IsText(sTmp) Then
                T.Rows.Add(New Object() { _
                           C2.ToStrNum(sTmp, True), _
                           DBNull.Value, _
                           DBNull.Value, _
                           DBNull.Value, _
                           DBNull.Value})
            End If

        End Using

        Return T
    End Function

End Class
