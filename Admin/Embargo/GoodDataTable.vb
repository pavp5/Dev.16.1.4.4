''' <summary>
''' Таблица товаров из запретов и ограничений
''' </summary>
Friend Class GoodDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("GoodTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("embargoId", GetType(Integer))
            .Add("caption", GetType(String))
            .Add("tnved", GetType(String))
            .Add("modeId", GetType(Integer))
            .Add("isACT", GetType(Boolean))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("embargoId").AllowDBNull = False
        Me.Columns("caption").AllowDBNull = False
        Me.Columns("isACT").AllowDBNull = False
        Me.Columns("caption").MaxLength = 1500
        Me.Columns("isACT").DefaultValue = True
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ''' <summary>
    ''' ID для новой строки
    ''' </summary>
    Public ReadOnly Property NewId As Integer
        Get
            If Me.Rows.Count = 0 Then Return 1
            Using V As New DataView(Me) With {.Sort = "id DESC"}
                Return CInt(V(0)("id")) + 1
            End Using
        End Get
    End Property

End Class
