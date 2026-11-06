''' <summary>
''' Категории товаров по ФСТЭК
''' </summary>
''' <remarks></remarks>
Public Class GoodCategoryDataTable : Inherits DataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.GoodCategoryDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, code, name, isACT, (code + ' - ' + name) AS codeName FROM tGoodCategory WHERE isACT = 1 ORDER BY id"
            Me.Load(Cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

    ''' <summary>
    ''' Возвращает ID категории товара по ее коду
    ''' </summary>
    ''' <param name="code">Код категории</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetIdByCode(ByVal code As Object) As Object
        If code Is Nothing OrElse IsDBNull(code) Then Return DBNull.Value
        Dim sTmp As String = Trim(code.ToString)
        If String.IsNullOrEmpty(sTmp) Then Return DBNull.Value
        For Each R As DataRow In Me.Rows
            If R("code").ToString = sTmp Then Return R("id")
        Next
        Return DBNull.Value
    End Function

    ''' <summary>
    ''' Возвращает код категории товара по ее ID
    ''' </summary>
    ''' <param name="id">ID категории</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetCodeById(ByVal id As Object) As Object
        If id Is Nothing OrElse IsDBNull(id) Then Return DBNull.Value
        Dim sTmp As String = Trim(id.ToString)
        If String.IsNullOrEmpty(sTmp) OrElse Not IsNumeric(sTmp) Then Return DBNull.Value
        For Each R As DataRow In Me.Rows
            If R("id").ToString = sTmp Then Return R("code")
        Next
        Return DBNull.Value
    End Function

End Class