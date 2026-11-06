Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица объектов экспертизы для одного заключения экспертизы
''' </summary>
''' <remarks></remarks>
Friend Class DocumentGoodDataTable : Inherits DataTable

    ' Работа
    Private W As WorkConnectionRow = Nothing

    ''' <summary>
    ''' Инициализация нового экземпляра класса DocumentGoodDataTable
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <param name="isEqual">Заключение на объекты, соответствующие контрольным спискам</param>
    Friend Sub New(Work As WorkConnectionRow, isEqual As Boolean)
        '
        ' Структура таблицы
        '
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))                ' id
            .Add("parentId", GetType(Integer))          ' parentId
            .Add("rowNum", GetType(Integer))            ' порядковый номер в документе
            .Add("nameCon", GetType(String))            ' коммерческое наименование
            .Add("tnved", GetType(String))              ' код ТН ВЭД
            .Add("description", GetType(String))        ' техническое описание
            .Add("isUnreal", GetType(Boolean))          ' виртуальный объект (да/нет)
            .Add("groupText", GetType(String))          ' группировка строк по какому-нибудь признаку
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        '
        ' Работа
        '
        W = Work
        '
        ' Данные (реальные объекты)
        '
        Dim description As String = Nothing
        Dim area As String = Nothing
        Dim used As String = Nothing
        Dim rowNum As Integer = 0
        Using V As New DataView(Work.GoodTable)
            V.RowFilter = String.Format("isUnreal = False AND studySummaryId {0} {1}", _
                                        If(isEqual, "=", "<>"), _
                                        CInt(Cprp.DxData.Law.StudyIndexEnum.IsEqual))
            V.Sort = "parentId, rowNum, nameCon"
            For i As Integer = 0 To V.Count - 1
                rowNum += 1
                '
                ' Техническое описание + назначение + область применения текущего объекта экспертизы
                '
                description = C2.ToText(V(i)("description"))
                area = C2.ToText(V(i)("area"))
                If Not C2.IsText(area) Then area = C2.ToText(Work.ARow("goodArea"))
                used = C2.ToText(V(i)("used"))
                If Not C2.IsText(used) Then used = C2.ToText(Work.ARow("goodUsed"))
                If C2.IsText(description) AndAlso C2.IsText(area) AndAlso C2.IsText(used) Then
                    description = String.Format("{1}{0}Назначение: {2}{0} Область применения: {3}", _
                                                vbCrLf, _
                                                C2.AddPoint(description), _
                                                C2.AddPoint(used), _
                                                C2.DelPoint(area))
                    'Else
                    '    description = Nothing
                End If
                '
                ' Добавление в таблицу данных текущего объекта экспертизы
                '
                Me.Rows.Add(New Object() { _
                             V(i)("id"), _
                             DBNull.Value, _
                             rowNum, _
                             V(i)("nameCon"), _
                             V(i)("tnved"), _
                             If(C2.IsText(description), description, DBNull.Value), _
                             False, _
                             DBNull.Value})
            Next
        End Using
        '
        ' Данные (виртуальные объекты)
        '
        Using V As New DataView(Me) With {.RowFilter = "isUnreal = False", .Sort = "rowNum"}
            For i As Integer = 0 To V.Count - 1
                rowNum = AddChildRow(CInt(V(i)("id")), rowNum)
            Next
        End Using

        Me.AcceptChanges()
    End Sub

    ''' <summary>
    ''' Добавить в таблицу объектов экспертизы дочерние виртуальные объекты родительского объекта экспертизы
    ''' </summary>
    ''' <param name="parentId">ID родительского объекта экспертизы</param>
    ''' <param name="lastRowNum">Последний порядковый номер в таблице объектов экспертизы</param>
    ''' <returns>Последний порядковый номер после добавления дочерних объектов</returns>
    ''' <remarks>Рекурсивная функция</remarks>
    Private Function AddChildRow(parentId As Integer, lastRowNum As Integer) As Integer
        Dim description As String = Nothing
        Dim area As String = Nothing
        Dim used As String = Nothing
        Using V As New DataView(W.GoodTable)
            V.RowFilter = String.Format("isUnreal = True AND parentId = {0} AND studySummaryId <> {1}", _
                                        parentId, CInt(Cprp.DxData.Law.StudyIndexEnum.IsNothing))
            V.Sort = "parentId, rowNum, nameCon"
            For i As Integer = 0 To V.Count - 1
                lastRowNum += 1
                '
                ' Техническое описание + назначение + область применения текущего объекта экспертизы
                '
                description = C2.ToText(V(i)("description"))
                area = C2.ToText(V(i)("area"))
                If Not C2.IsText(area) Then area = C2.ToText(W.ARow("goodArea"))
                used = C2.ToText(V(i)("used"))
                If Not C2.IsText(used) Then used = C2.ToText(W.ARow("goodUsed"))
                If C2.IsText(description) AndAlso C2.IsText(area) AndAlso C2.IsText(used) Then
                    description = String.Format("{1}{0}Назначение: {2}{0} Область применения: {3}", _
                                                vbCrLf, _
                                                C2.AddPoint(description), _
                                                C2.AddPoint(used), _
                                                C2.DelPoint(area))
                Else
                    description = Nothing
                End If
                '
                ' Добавление в таблицу данных текущего объекта экспертизы
                '
                Me.Rows.Add(New Object() { _
                             V(i)("id"), _
                             parentId, _
                             lastRowNum, _
                             V(i)("nameCon"), _
                             V(i)("tnved"), _
                             If(C2.IsText(description), description, DBNull.Value), _
                             True, _
                             DBNull.Value})
                '
                ' Рекурсивное добавление дочерних виртуальных объектов
                '
                lastRowNum = AddChildRow(CInt(V(i)("id")), lastRowNum)
            Next
        End Using
        Return lastRowNum
    End Function


    ''' <summary>
    ''' Группировка строк по одинаковым кодам ТН ВЭД и техническим описаниям
    ''' </summary>
    Friend Sub GroupByTnvedDescription()
        For Each Row As DataRow In Me.Rows
            Row("groupText") = DBNull.Value
        Next
        Dim tnved As String = Nothing
        Dim description As String = Nothing
        Using V As New DataView(Me) With {.RowFilter = "parentId IS NULL", .Sort = "rowNum"}
            For i As Integer = 0 To V.Count - 1
                GroupChildByTnvedDescription(CInt(V(i)("id")))
                If Not IsDBNull(V(i)("groupText")) Then Continue For
                V(i)("groupText") = V(i)("rowNum").ToString
                tnved = C2.ToText(V(i)("tnved"))
                description = C2.ToText(V(i)("description"))
                For j As Integer = i + 1 To V.Count - 1
                    If Not IsDBNull(V(j)("groupText")) Then Continue For
                    If C2.ToText(V(j)("tnved")) <> tnved Then Continue For
                    If C2.ToText(V(j)("description")) <> description Then Continue For
                    V(j)("groupText") = V(i)("rowNum").ToString
                Next
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Группировка дочерних строк объекта экспертизы по одинаковым кодам ТН ВЭД и техническим описаниям
    ''' </summary>
    ''' <param name="parentId">ID родительского объекта экспертизы</param>
    ''' <remarks>Рекурсивная процедура</remarks>
    Private Sub GroupChildByTnvedDescription(parentId As Integer)
        Dim tnved As String = Nothing
        Dim description As String = Nothing
        Using V As New DataView(Me) With {.RowFilter = String.Format("parentId = {0}", parentId), .Sort = "rowNum"}
            For i As Integer = 0 To V.Count - 1
                GroupChildByTnvedDescription(CInt(V(i)("id")))
                If Not IsDBNull(V(i)("groupText")) Then Continue For
                V(i)("groupText") = V(i)("rowNum").ToString
                tnved = C2.ToText(V(i)("tnved"))
                description = C2.ToText(V(i)("description"))
                For j As Integer = i + 1 To V.Count - 1
                    If Not IsDBNull(V(j)("groupText")) Then Continue For
                    If C2.ToText(V(j)("tnved")) <> tnved Then Continue For
                    If C2.ToText(V(j)("description")) <> description Then Continue For
                    V(j)("groupText") = V(i)("rowNum").ToString
                Next
            Next
        End Using
    End Sub


    ''' <summary>
    ''' Возвращает таблицу специальных экономических мер, применяемых в отношении объектов экспертизы
    ''' </summary>
    ''' <remarks></remarks> 
    Friend Function GetGoodEmbargoTable() As DataTable
        '
        ' Структура таблицы
        '
        Dim T As New DataTable
        With T.Columns
            .Add("goodNumS", GetType(String))           ' строка порядковых номеров объектов экспертизы
            .Add("embargoName", GetType(String))        ' наименование документа, устанавливающего специальную экономическую меру
            .Add("isBool", GetType(Boolean))            ' техническое поле для проведения операций по групировке данных
        End With
        Dim Row As DataRow = Nothing
        Dim sTmp As String = Nothing
        '
        ' Если нет запретов и ограничений в отношении продукции - вернуть таблицу со строкой о неприменении специальных экономических мер
        ''
        'Using V As New DataView(W.EmbargoGoodHandbookTable)
        '    V.RowFilter = String.Format("countryId = {0} OR countryId = 999", C2.ToInt(W.ARow("countryId")))
        'If V.Count = 0 Then
        If W.GoodEmbargoTable.Rows.Count = 0 Then
            For Each Row In Me.Rows
                sTmp = String.Format("{0}{1}{2}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(Row("rowNum")))
            Next
            T.Rows.Add(New Object() {C2.ToStrNum(sTmp, True), "Специальные экономические и принудительные меры не применяются", True})
            Return T
        End If
        'End Using
        '
        ' Заполнение таблицы данными из справочника запретов и ограничений (номер товара - реквизиты документа)
        '
        Using VE As New DataView(W.EmbargoGoodHandbookTable)
            VE.RowFilter = "isLimited = False"  ' не выводим данные из закрытых документов
            Using V As New DataView(W.GoodEmbargoTable)
                For i As Integer = 0 To Me.Rows.Count - 1
                    '
                    ' Строка таблицы объектов экспертизы из работы
                    '
                    Row = W.GoodTable.Rows.Find(Me(i)("id"))
                    '
                    ' Запреты и ограничения отсутствуют
                    '
                    If CBool(Row("isNotEmbargo")) Then
                        T.Rows.Add(New Object() {C2.ToText(Me(i)("rowNum")), "Специальные экономические и принудительные меры не применяются", True})
                        Continue For
                    End If
                    '
                    ' Цикл по запретам и ограничения текущего объекта
                    '
                    V.RowFilter = String.Format("goodId = {0}", CInt(Me(i)("id")))
                    If V.Count = 0 Then
                        T.Rows.Add(New Object() {C2.ToText(Me(i)("rowNum")), DBNull.Value, True})
                        Continue For
                    End If
                    For j As Integer = 0 To V.Count - 1
                        VE.RowFilter = String.Format("id = {0}", CInt(V(j)("embargoGoodId")))
                        If VE.Count = 0 Then Continue For
                        If C2.ToText(VE(0)("embargoCaption2")) Like "* ООН *" Then
                            sTmp = String.Format("Применяются принудительные меры установленные {0}", C2.DelPoint(VE(0)("embargoCaption2")))
                        Else
                            sTmp = String.Format("Применяются специальные экономические меры установленные {0}", C2.DelPoint(VE(0)("embargoCaption2")))
                        End If
                        If CBool(VE(0)("isLimited")) Then sTmp = "Применяются специальные экономические меры, установленные Правительством Российской Федерации"
                        T.Rows.Add(New Object() {C2.ToText(Me(i)("rowNum")), sTmp, True})
                    Next
                Next
            End Using
        End Using
        '
        ' Обработка данных
        '
        Using V As New DataView(T)
            '
            ' Пометка одинаковых строк как неактуальных
            '
            V.Sort = "goodNums, embargoName"
            For i As Integer = 1 To V.Count - 1
                If C2.ToText(V(i)("goodNums")) <> C2.ToText(V(i - 1)("goodNums")) Then Continue For
                If C2.ToText(V(i)("embargoName")) <> C2.ToText(V(i - 1)("embargoName")) Then Continue For
                V(i)("isBool") = False
            Next
            '
            ' Группировка номеров товаров по реквизитам документов, пометка строк, включенных в группировку, как неактуальных
            '
            For i As Integer = 0 To T.Rows.Count - 1
                If Not CBool(T(i)("isBool")) Then Continue For
                sTmp = C2.ToText(T(i)("goodNums"))
                For j As Integer = i + 1 To T.Rows.Count - 1
                    If Not CBool(T(j)("isBool")) Then Continue For
                    If C2.ToText(T(j)("embargoName")) <> C2.ToText(T(i)("embargoName")) Then Continue For
                    sTmp = String.Format("{0}, {1}", sTmp, C2.ToText(T(j)("goodNums")))
                    T(j)("isBool") = False
                Next
                T(i)("goodNums") = C2.ToStrNum(sTmp, True)
            Next
            '
            ' Проверка актуальности строк с Постановлением 313
            ' Постановление выводится при поставке в недружественную страну, или недружественную страну конечного пользователя, или отсутствии конечного пользователя
            '
            Using V1 As New DataView(T) With {.RowFilter = "embargoName LIKE '% 313 %'"}
                If V1.Count > 0 Then
                    ' Проверка поставки в недружественную страну
                    Dim bTmp As Boolean = False
                    sTmp = C2.ToText(W.ARow("countryIdString")).Replace("/", ",")                                        
                    If Not String.IsNullOrWhiteSpace(sTmp) Then
                        Using V2 As New DataView(W.CountryHandbookTable) With _
                            {.RowFilter = String.Format("isControl = True AND id IN ({0})", sTmp)}
                            bTmp = (V2.Count > 0)
                        End Using
                    End If
                    ' Проверка страны банка
                    Using V2 As New DataView(W.CountryHandbookTable) With _
                        {.RowFilter = String.Format("isControl = True AND id = ({0})", C2.ToInt(W.ARow("bankCountryId")))}
                        bTmp = (V2.Count > 0)
                    End Using
                    ' Проверка отсутствия конечного пользователя, или недружественной страны конечного пользователя
                    If Not bTmp Then
                        Using V2 As New DataView(W.MemberTable) With {.RowFilter = "supEndNum > 0"}
                            ' Конечный пользователь отсутствует
                            bTmp = (V2.Count = 0)
                            ' Конечный пользователь из недружественной страны
                            If Not bTmp Then
                                ' Формирование списка id стран конечных пользователей
                                sTmp = "0"
                                For Each VRow As DataRowView In V2
                                    sTmp = String.Format("{0}, {1}", sTmp, C2.ToInt(VRow("addressLegalCountryId")))
                                Next
                                ' Одна или более стран конечных пользователей относятся к недружественным
                                Using V3 As New DataView(W.CountryHandbookTable) With _
                                    {.RowFilter = String.Format("isControl = True AND id IN ({0})", sTmp)}
                                    bTmp = (V3.Count > 0)
                                End Using
                            End If
                        End Using
                    End If
                    ' Пометка актуальности строк с Постановлением 313
                    For Each VRow As DataRowView In V1
                        VRow("isBool") = bTmp
                    Next
                End If
            End Using
            '
            ' Удаление неактуальных строк
            '
            V.RowFilter = "isBool = False"
            While V.Count > 0
                V(0).Delete()
            End While
        End Using

        ' Если нет актуальных запретов и ограничений
        If T.Rows.Count = 0 Then
            sTmp = Nothing
            For Each Row In Me.Rows
                sTmp = String.Format("{0}{1}{2}", sTmp, C2.FIELD_SEPARATOR, C2.ToText(Row("rowNum")))
            Next
            T.Rows.Add(New Object() {C2.ToStrNum(sTmp, True), "Специальные экономические и принудительные меры не применяются", True})
            Return T
        End If

        Return T

    End Function

End Class
