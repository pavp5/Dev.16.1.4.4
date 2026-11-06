''' <summary>
''' Условие объединения критериев поиска
''' </summary>
''' <remarks></remarks>
Friend Class UnionDataTable : Inherits DataTable
    Friend Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        With Me.Rows
            .Add(New Object() {1, "<И>"})
            .Add(New Object() {2, "<ИЛИ>"})
        End With
    End Sub
End Class


''' <summary>
''' Виды услуг
''' </summary>
''' <remarks></remarks>
Friend Class WorkTypeDataTable : Inherits DataTable
    Friend Sub New(Connection As SqlConnection)
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name FROM tWorkType WHERE id < 99 ORDER BY 1"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub
End Class


''' <summary>
''' Характеристики экспертизы
''' </summary>
''' <remarks></remarks>
Friend Class WorkKindDataTable : Inherits DataTable
    Friend Sub New(Connection As SqlConnection)
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name FROM tWorkKind ORDER BY 1"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub
End Class


''' <summary>
''' Эксперты
''' </summary>
''' <remarks></remarks>
Friend Class WorkExpertDataTable : Inherits DataTable
    Friend Sub New(Connection As SqlConnection)
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name FROM tUser WHERE isExpert = 1 ORDER BY 2"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub
End Class


''' <summary>
''' Менеджеры
''' </summary>
''' <remarks></remarks>
Friend Class WorkManagerDataTable : Inherits DataTable
    Friend Sub New(Connection As SqlConnection)
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name FROM tUser WHERE isManager = 1 ORDER BY 2"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub
End Class


''' <summary>
''' Руководители
''' </summary>
''' <remarks></remarks>
Friend Class WorkLeaderDataTable : Inherits DataTable
    Friend Sub New(Connection As SqlConnection)
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name FROM tUser WHERE isLeader = 1 ORDER BY 2"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub
End Class


''' <summary>
''' Выводы экспертизы
''' </summary>
''' <remarks></remarks>
Friend Class WorkSummaryDataTable : Inherits DataTable
    Friend Sub New(Connection As SqlConnection)
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name FROM tWorkSummary ORDER BY 1"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub
End Class


''' <summary>
''' Направления перемещения
''' </summary>
''' <remarks></remarks>
Friend Class ModeDataTable : Inherits DataTable
    Friend Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        With Me.Rows
            .Add(New Object() {1, "ИЗ РОССИИ"})
            .Add(New Object() {2, "В РОССИЮ"})
        End With
    End Sub
End Class


''' <summary>
''' Страны
''' </summary>
''' <remarks></remarks>
Friend Class CountryDataTable : Inherits DataTable
    Friend Sub New(Connection As SqlConnection)
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name FROM tCountry ORDER BY 2"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub
End Class


''' <summary>
''' Виды объектов экспертизы
''' </summary>
''' <remarks></remarks>
Friend Class GoodCategoryDataTable : Inherits DataTable
    Friend Sub New(Connection As SqlConnection)
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, code + ' - ' + name AS name FROM tGoodType ORDER BY 1"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub
End Class


''' <summary>
''' Контрольные статусы объектов экспертизы
''' </summary>
''' <remarks></remarks>
Friend Class GoodStudySummaryDataTable : Inherits DataTable
    Friend Sub New(Connection As SqlConnection)
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("name", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, name FROM tGoodStudySummary ORDER BY 1"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub
End Class