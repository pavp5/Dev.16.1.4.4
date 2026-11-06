''' <summary>
''' Таблица запретов и ограничений
''' </summary>
Friend Class EmbargoDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("EmbargoTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("caption", GetType(String))
            .Add("caption2", GetType(String))
            '.Add("pdfData", GetType(Byte()))
            .Add("modeId", GetType(Integer))
            .Add("isLimited", GetType(Boolean))
            .Add("isACT", GetType(Boolean))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("caption").AllowDBNull = False
        Me.Columns("modeId").AllowDBNull = False
        Me.Columns("isLimited").AllowDBNull = False
        Me.Columns("isACT").AllowDBNull = False
        Me.Columns("caption").MaxLength = 500
        Me.Columns("caption2").MaxLength = 500
        Me.Columns("modeId").DefaultValue = 3
        Me.Columns("isLimited").DefaultValue = False
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
