''' <summary>
''' Таблица фирм из запретов и ограничений
''' </summary>
Public Class MemberDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New()
        MyBase.New("MemberTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("embargoId", GetType(Integer))
            .Add("caption", GetType(String))
            .Add("description", GetType(String))
            .Add("countryId", GetType(Integer))
            .Add("modeId", GetType(Integer))
            .Add("isACT", GetType(Boolean))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("embargoId").AllowDBNull = False
        Me.Columns("caption").AllowDBNull = False
        Me.Columns("isACT").AllowDBNull = False
        Me.Columns("caption").MaxLength = 1500
        Me.Columns("description").MaxLength = 1500
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
