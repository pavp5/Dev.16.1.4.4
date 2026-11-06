Imports Cprp.DxData.Common
''' <summary>
''' Таблица контрольных списков
''' </summary>
Friend Class LawDataTable : Inherits DataTable

    ''' <summary>
    ''' Представление документов, отсортированное по порядку строк
    ''' </summary>
    Private SortedView As DataView = Nothing


    Friend Sub New()
        MyBase.New("LawTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("parentId", GetType(Integer))
            .Add("sortId", GetType(Integer))
            .Add("pos", GetType(String))
            .Add("posDescription", GetType(String))
            .Add("tnved", GetType(String))
            .Add("cas", GetType(String))
            .Add("doc", GetType(String))
            .Add("typeId", GetType(String))
            .Add("apu", GetType(String))
            .Add("isSel", GetType(Boolean))
        End With
        With Me.Columns("isSel")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        SortedView = New DataView(Me) With {.Sort = "sortId"}
    End Sub


    ''' <summary>
    ''' Снять отметки со всех записей
    ''' </summary>
    Friend Sub CheckClear()
        Using V As New DataView(Me)
            V.RowFilter = "isSel = True"
            While V.Count > 0
                V(0)("isSel") = False
            End While
        End Using
    End Sub

    ''' <summary>
    ''' Возвращает id предыдущего пункта в дереве документов, содержащий указанный текст
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
               "id <> {0} AND sortId <= {1} AND (posDescription LIKE '%{2}%' OR apu LIKE '%{2}%')", _
               startId, CInt(Row("sortId")), text)
            If SortedView.Count > 0 Then Return CInt(SortedView(SortedView.Count - 1)("id"))
            Return EMPTY_ID
        End Get
    End Property

    ''' <summary>
    ''' Возвращает id следующего пункта в дереве документов, содержащий указанный текст
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
                "id <> {0} AND sortId >= {1} AND (posDescription LIKE '%{2}%' OR apu LIKE '%{2}%')", _
                startId, CInt(Row("sortId")), text)
            If SortedView.Count > 0 Then Return CInt(SortedView(0)("id"))
            Return EMPTY_ID
        End Get
    End Property

    ''' <summary>
    ''' Возвращает id предыдущего отмеченного пункта в дереве документов
    ''' </summary>
    ''' <param name="startId">id стартового пункта</param>
    ''' <remarks>Если пункт не найден, возвращает Cprp.DxData.Convert.EMPTY_VALUE</remarks> 
    Friend ReadOnly Property GetPrevSelId(startId As Integer) As Integer
        Get
            Dim Row As DataRow = Me.Rows.Find(startId)
            If Row Is Nothing Then Return EMPTY_ID
            SortedView.RowFilter = String.Format( _
               "id <> {0} AND sortId <= {1} AND isSel = True", startId, CInt(Row("sortId")))
            If SortedView.Count > 0 Then Return CInt(SortedView(SortedView.Count - 1)("id"))
            Return EMPTY_ID
        End Get
    End Property

    ''' <summary>
    ''' Возвращает id следующего отмеченного пункта в дереве документов
    ''' </summary>
    ''' <param name="startId">id стартового пункта</param>
    ''' <remarks>Если пункт не найден, возвращает Cprp.DxData.Convert.EMPTY_VALUE</remarks> 
    Friend ReadOnly Property GetNextSelId(startId As Integer) As Integer
        Get
            Dim Row As DataRow = Me.Rows.Find(startId)
            If Row Is Nothing Then Return EMPTY_ID
            SortedView.RowFilter = String.Format( _
               "id <> {0} AND sortId >= {1} AND isSel = True", startId, CInt(Row("sortId")))
            If SortedView.Count > 0 Then Return CInt(SortedView(0)("id"))
            Return EMPTY_ID
        End Get
    End Property

End Class