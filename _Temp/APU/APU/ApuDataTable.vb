Imports Cprp.DxData.Common
''' <summary>
''' Таблица АПУ
''' </summary>
Friend Class ApuDataTable : Inherits DataTable

    ''' <summary>
    ''' Представление АПУ, отсортированное по порядку строк
    ''' </summary>
    Private SortedView As DataView = Nothing


    Friend Sub New()
        MyBase.New("ApuTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("parentId", GetType(Integer))
            .Add("caption", GetType(String))
            .Add("fullCaption", GetType(String))
            .Add("sortId", GetType(Integer))
            .Add("strPos", GetType(String))     ' Строка с переченем пунктов контрольных списков типа: ДН 1.2.3-1.2.6; РО 8.3.1.
        End With
        Me.Columns("caption").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        SortedView = New DataView(Me) With {.Sort = "sortId"}
    End Sub


    ''' <summary>
    ''' Переписать столбец сортировки строк
    ''' </summary>
    Friend Sub UpdateSortId()
        Dim sortId = 0
        For Each Row In Me.Rows
            Row("sortId") = 0
        Next
        Using V As New DataView(Me) With {.Sort = "caption", .RowFilter = "parentId IS NULL"}
            For i As Integer = 0 To V.Count - 1
                sortId += 1
                V(i)("sortId") = sortId
                sortId = GetChildSortId(CInt(V(i)("id")), sortId)
            Next
        End Using
    End Sub

    ''' <summary>
    ''' Сортирует дочерние строки родительской строки и возвращает максимальный sortId дочерних строк
    ''' </summary>
    ''' <param name="parentId">ID родительской строки</param>
    ''' <param name="parentSortId">sortId родительской строки</param>
    Private Function GetChildSortId(parentId As Integer, parentSortId As Integer) As Integer
        Dim sortId As Integer = parentSortId
        Using V As New DataView(Me) With {.Sort = "caption", .RowFilter = String.Format("parentId = {0}", parentId)}
            For i As Integer = 0 To V.Count - 1
                sortId += 1
                V(i)("sortId") = sortId
                sortId = GetChildSortId(CInt(V(i)("id")), sortId)
            Next
        End Using
        Return sortId
    End Function

    ''' <summary>
    ''' Возвращает id предыдущего пункта в дереве АПУ, содержащий указанный текст
    ''' </summary>
    ''' <param name="startId">id стартового пункта</param>
    ''' <param name="text">Текст для поиска</param>
    ''' <remarks>Если пункт не найден, возвращает Cprp.DxData.Convert.EMPTY_VALUE</remarks> 
    Friend ReadOnly Property FindPrevIdByText(startId As Integer, text As String) As Integer
        Get
            text = ToText(text)
            If String.IsNullOrWhiteSpace(text) Then Return EMPTY_ID
            Dim Row As DataRow = Me.Rows.Find(startId)
            If Row Is Nothing Then Return EMPTY_ID
            SortedView.RowFilter = String.Format( _
               "id <> {0} AND sortId <= {1} AND caption LIKE '%{2}%'", _
               startId, CInt(Row("sortId")), text)
            If SortedView.Count > 0 Then Return CInt(SortedView(SortedView.Count - 1)("id"))
            Return EMPTY_ID
        End Get
    End Property

    ''' <summary>
    ''' Возвращает id следующего пункта в дереве АПУ, содержащий указанный текст
    ''' </summary>
    ''' <param name="startId">id стартового пункта</param>
    ''' <param name="text">Текст для поиска</param>
    ''' <remarks>Если пункт не найден, возвращает Cprp.DxData.Convert.EMPTY_VALUE</remarks> 
    Friend ReadOnly Property FindNextIdByText(startId As Integer, text As String) As Integer
        Get
            text = ToText(text)
            If String.IsNullOrWhiteSpace(text) Then Return EMPTY_ID
            text = text.ToUpper
            Dim Row As DataRow = Me.Rows.Find(startId)
            If Row Is Nothing Then Return EMPTY_ID
            SortedView.RowFilter = String.Format( _
                "id <> {0} AND sortId >= {1} AND caption LIKE '%{2}%'", _
                startId, CInt(Row("sortId")), text)
            If SortedView.Count > 0 Then Return CInt(SortedView(0)("id"))
            Return EMPTY_ID
        End Get
    End Property

    ''' <summary>
    ''' Возвращает полное иерахическое описание пункта АПУ
    ''' </summary>
    ''' <param name="rowId">ID пункта</param>
    Friend Function GetFullCaption(rowId As Integer) As String
        Dim sTmp As String = Nothing
        Dim Row As DataRow = Nothing
        Do
            Row = Me.Rows.Find(rowId)
            If Row Is Nothing Then Exit Do
            sTmp = String.Format("{0}{1}{2}", ToText(Row("caption")), vbCrLf, sTmp)
            rowId = ToInt(Row("parentId"))
        Loop
        If IsText(sTmp) Then sTmp = sTmp.Substring(0, sTmp.Length - 2)
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает строку ID дочерних родительского пунктов пункта АПУ
    ''' </summary>
    ''' <param name="parentId">ID родительского пункта</param>
    Friend Function GetChildIdString(parentId As Integer) As String
        Dim sTmp As String = "0"
        Using V As New DataView(Me)
            V.RowFilter = String.Format("parentId = {0}", parentId)
            For Each VRow As DataRowView In V
                sTmp = String.Format("{0}, {1}, {2}", sTmp, CInt(VRow("id")), GetChildIdString(CInt(VRow("id"))))
            Next
        End Using
        Return sTmp
    End Function


End Class
