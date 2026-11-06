''' <summary>
''' Таблица объектов экспертизы (результаты поиска)
''' </summary>
Friend Class GoodDataTable : Inherits DataTable

    ''' <summary>
    ''' Представление объектов экспертизы, отсортированное по ID работы
    ''' </summary>
    Friend Property WorkView As DataView = Nothing

    ''' <summary>
    ''' Шаблон запроса на выборку данных
    ''' </summary>
    Friend Const SELECT_QUERY_STRING As String = _
        "SELECT id, workId, nameConDec, nameCon, nameDec, tnved, area, used, description, studyIndex FROM vGoodData "


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("GoodTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("workId", GetType(Integer))
            .Add("nameConDec", GetType(String))
            .Add("nameCon", GetType(String))
            .Add("nameDec", GetType(String))
            .Add("tnved", GetType(String))
            .Add("cas", GetType(String))
            .Add("area", GetType(String))
            .Add("used", GetType(String))
            .Add("description", GetType(String))
            .Add("studyIndex", GetType(Integer))
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
