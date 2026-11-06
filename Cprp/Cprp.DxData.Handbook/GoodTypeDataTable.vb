''' <summary>
''' Виды объектов экспертизы
''' </summary>
''' <remarks></remarks>
Public Class GoodTypeDataTable : Inherits DataTable

    Private _childIdString As String = Nothing
    ''' <summary>
    ''' Строка ID дочерних видов
    ''' </summary>
    Public ReadOnly Property ChildIdString As String
        Get
            Return _childIdString
        End Get
    End Property

    Private _parentIdString As String = Nothing
    ''' <summary>
    ''' Строка ID родительских видов
    ''' </summary>
    Public ReadOnly Property ParentIdString As String
        Get
            Return _parentIdString
        End Get
    End Property


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.GoodTypeDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, code, name, isChild, isParent, categoryId, isACT, (code + ' - ' + name) AS codeName FROM tGoodType WHERE isACT = 1 ORDER BY id"
            Me.Load(Cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        _childIdString = "0"
        _parentIdString = "0"
        For Each Row As DataRow In Me.Rows
            If CBool(Row("isChild")) Then _childIdString = String.Format("{0}, {1}", _childIdString, CInt(Row("id")))
            If CBool(Row("isParent")) Then _parentIdString = String.Format("{0}, {1}", _parentIdString, CInt(Row("id")))
        Next
    End Sub

    ''' <summary>
    ''' Возвращает ID вида объекта по ее коду
    ''' </summary>
    ''' <param name="code">Код вида объекта</param>
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
    ''' Возвращает код вида объекта по ее ID
    ''' </summary>
    ''' <param name="id">ID вида объекта</param>
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