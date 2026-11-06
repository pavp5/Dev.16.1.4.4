''' <summary>
''' Справочник продукции на контроле
''' </summary>
''' <remarks></remarks>
Public Class ControlGoodDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("docNumDate", GetType(String))
            .Add("orgNameLong", GetType(String))
            .Add("conNumDate", GetType(String))
            .Add("rusCaptionInn", GetType(String))
            .Add("nusCaption", GetType(String))
            .Add("endCaption", GetType(String))
            .Add("goodName", GetType(String))
            .Add("goodNameFind", GetType(String))
            .Add("goodTnved", GetType(String))
            .Add("goodListPos", GetType(String))
            .Add("summary", GetType(String))
            .Add("isCheck", GetType(Boolean))                   ' Отмечена (да/нет)
        End With
        With Me.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param> 
    ''' <remarks></remarks>
    Public Sub New(Connection As SqlConnection)
        MyClass.New()
        DataLoad(Connection)
    End Sub

    ''' <summary>
    ''' Загрузить данные из базы данных
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub DataLoad(Connection As SqlConnection)
        Me.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT * FROM vFInfo"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ''' <summary>
    ''' Снять все отметки
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckClear()
        Using V As New DataView(Me)
            V.RowFilter = "isCheck = True"
            While V.Count > 0
                V(0)("isCheck") = False
            End While
        End Using
    End Sub

End Class