Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица нормативных документов
''' </summary>
Public Class LawDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("LawTable")
        With Me.Columns
            ' Поля представления vLaw
            .Add("id", GetType(Integer))                    ' id
            .Add("parentId", GetType(Integer))              ' id родительской строки
            .Add("sortId", GetType(Integer))                ' порядок сортировки
            .Add("pos", GetType(String))                    ' номер пункта (позиции)
            .Add("description", GetType(String))            ' описание пункта (позиции)
            .Add("posDescription", GetType(String))         ' номер + описание пункта (позиции)
            .Add("letterPosDescription", GetType(String))   ' обозначение списка + номер + описание пункта
            .Add("tnved", GetType(String))                  ' код(ы) ТН ВЭД
            .Add("cas", GetType(String))                    ' номер(а) CAS
            .Add("doc", GetType(String))                    ' шифр документа (XXXX.XXXX.XXXX)
            .Add("areaId", GetType(Integer))                ' предметная область (значение из AreaEnum)
            .Add("modeId", GetType(Integer))                ' направление перемещения (значение из ModeEnum)
            .Add("typeId", GetType(Integer))                ' тип строки (значение из TypeEnum)
            .Add("isList", GetType(Boolean))                ' признак принадлежности к контрольному списку (перечню запретов)
            .Add("lev", GetType(Integer))                   ' уровень строки в иерерархии дерева нормативных документов
            ' Поля для хранения результатов поиска
            .Add("isFindTnved", GetType(Boolean))           ' найдена по коду ТН ВЭД
            .Add("isFindWord", GetType(Boolean))            ' найдена по ключевым словам
            .Add("isFindCas", GetType(Boolean))             ' найдена по номеру CAS
            ' Поле для хранения выбранных пользователем строк
            .Add("isSel", GetType(Boolean))                 ' строка выбрана пользователем (да/нет)
            ' Поле для хранения результатов сравнительного анализа объекта с пунктом списка
            .Add("summaryId", GetType(Integer))             ' 0 - не относится, 1 - не соответствует, 2 - соответствует
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("sortId").AllowDBNull = False
        Me.Columns("description").AllowDBNull = False
        Me.Columns("doc").AllowDBNull = False
        Me.Columns("areaId").AllowDBNull = False
        Me.Columns("modeId").AllowDBNull = False
        Me.Columns("typeId").AllowDBNull = False
        Me.Columns("lev").AllowDBNull = False
        With Me.Columns("isFindWord")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isFindTnved")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isFindCas")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isSel")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("summaryId")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Me.DefaultView.Sort = "doc, id"
    End Sub

    ' Очистить связанные таблицы перед очисткой данной таблицы
    Private Sub LawDataTable_TableClearing(sender As Object, e As DataTableClearEventArgs) Handles Me.TableClearing
        For Each R As DataRelation In Me.ChildRelations
            R.ChildTable.Rows.Clear()
        Next
    End Sub

    ''' <summary>
    ''' Поиск в нормативных документах по ключевым словам
    ''' </summary>
    ''' <param name="findString">Строка ключевых слов</param>
    ''' <remarks></remarks>
    Friend Sub Find(findString As String)
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
        ' Цикл по таблице нормативных документов
        '
        For Each Row As DataRow In Me.Rows
            sTmp = Row("posDescription").ToString.ToUpper
            '
            ' Цикл по массиву ключевых фраз
            '
            For i As Integer = arrRow.GetLowerBound(0) To arrRow.GetUpperBound(0)
                '
                ' Массив ключевых слов в текущей ключевой фразе
                '
                arrWord = arrRow(i).Split(New Char() {Chr(2)}, StringSplitOptions.RemoveEmptyEntries)
                '
                ' Цикл по массиву ключевых слов
                '
                bTmp = True
                For j As Integer = arrWord.GetLowerBound(0) To arrWord.GetUpperBound(0)
                    If sTmp Like String.Format("*{0}*", arrWord(j)) Then Continue For
                    bTmp = False
                    Exit For
                Next
                If Not bTmp Then Continue For
                '
                ' Текущая строка таблицы нормативных документов соответствует ключевой фразе
                '
                Row("isFindWord") = True
                Exit For
            Next
        Next

    End Sub


End Class
