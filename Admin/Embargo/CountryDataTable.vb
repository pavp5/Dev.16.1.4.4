''' <summary>
''' Справочник стран мира
''' </summary>
Friend Class CountryDataTable : Inherits DataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("CountryTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("nameShort", GetType(String))
            .Add("modeId", GetType(Integer))
            .Add("isCheck", GetType(Boolean))
            .Add("isACT", GetType(Boolean))
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("nameShort").AllowDBNull = False
        Me.Columns("isCheck").AllowDBNull = False
        Me.Columns("isACT").AllowDBNull = False
        Me.Columns("isCheck").DefaultValue = False
        Me.Columns("isACT").DefaultValue = True
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


    ''' <summary>
    ''' Снять выделение со всех строк
    ''' </summary>
    Public Sub CheckClear()
        Using V As New DataView(Me) With {.RowFilter = "isCheck = True"}
            While V.Count > 0
                V(0)("modeId") = DBNull.Value
                V(0)("isCheck") = False
            End While
        End Using
    End Sub

    ''' <summary>
    ''' Возвращает ID страны по ее краткому наименованию
    ''' </summary>
    ''' <param name="nameShort">Краткое наименование страны</param>
    Public Function GetIdByNameShort(nameShort As String) As Object
        nameShort = Cprp.DxData.Common.ToText(nameShort)
        If Cprp.DxData.Common.IsText(nameShort) Then
            Using V As New DataView(Me)
                V.RowFilter = String.Format("nameShort LIKE '{0}'", nameShort.ToUpper)
                If V.Count > 0 Then Return V(0)("id")
            End Using
        End If
        Return DBNull.Value
    End Function

End Class
