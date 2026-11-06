''' <summary>
''' Таблица представленных документов по работе (результаты поиска)
''' </summary>
Friend Class InDocDataTable : Inherits DataTable

    ''' <summary>
    ''' Представление объектов экспертизы, отсортированное по ID работы
    ''' </summary>
    Friend Property WorkView As DataView = Nothing

    ''' <summary>
    ''' Шаблон запроса на выборку данных
    ''' </summary>
    Friend Const SELECT_QUERY_STRING As String = _
        "SELECT id, workId, captionNumDate, docUrl FROM vInDoc"


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("InDocTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("workId", GetType(Integer))
            .Add("captionNumDate", GetType(String))
            .Add("docUrl", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        WorkView = New DataView(Me)
    End Sub


    ''' <summary>
    ''' Задать фильтр представления WorkView по ID работы
    ''' </summary>
    ''' <value>ID работы</value>
    Friend WriteOnly Property WorkId As Integer
        Set(value As Integer)
            WorkView.RowFilter = String.Format("workId = {0}", value)
        End Set
    End Property

End Class
