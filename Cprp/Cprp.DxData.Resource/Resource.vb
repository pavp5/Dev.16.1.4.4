''' <summary>
''' Свойства и методы для работы с ресурсами системы
''' </summary>
''' <remarks></remarks>
Public Class Resource

    Private _Connection As SqlConnection

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Resource
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        _Connection = Connection
    End Sub

    ''' <summary>
    ''' Возвращает строковое содержимое ресурса по его имени
    ''' </summary>
    ''' <param name="sourceName">Имя ресурса</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <returns></returns>
    ''' <remarks>Если ресурс не найден или его содержимое равно DBNull.Value возвращает Nothing</remarks>
    Public Shared Function GetStrData(ByVal sourceName As String, ByVal Connection As SqlConnection) As String
        If String.IsNullOrWhiteSpace(sourceName) Then Return Nothing
        Dim sTmp As String = Nothing
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = String.Format("SELECT strData FROM tResource WHERE name LIKE '{0}'", Trim(sourceName))
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then sTmp = Dr(0).ToString
                Dr.Close()
            End Using
        End Using
        If String.IsNullOrWhiteSpace(sTmp) Then sTmp = Nothing
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает строковое содержимое ресурса по его имени
    ''' </summary>
    ''' <param name="sourceName">Имя ресурса</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function GetStrData(ByVal sourceName As String) As String
        Return Resource.GetStrData(sourceName, _Connection)
    End Function

    ''' <summary>
    ''' Возвращает байтовое содержимое ресурса по его имени
    ''' </summary>
    ''' <param name="sourceName">Имя ресурса</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <returns></returns>
    ''' <remarks>Если ресурс не найден или его содержимое равно DBNull.Value возвращает Nothing</remarks>
    Public Shared Function GetBinData(ByVal sourceName As String, ByVal Connection As SqlConnection) As Object
        If String.IsNullOrEmpty(Trim(sourceName)) Then Return Nothing
        Dim oTmp As Object = Nothing
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = String.Format("SELECT binData FROM tResource WHERE name LIKE '{0}'", Trim(sourceName))
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                If Dr.Read Then oTmp = Dr(0)
                Dr.Close()
            End Using
        End Using
        If oTmp Is Nothing OrElse IsDBNull(oTmp) Then Return Nothing
        Return oTmp
    End Function

    ''' <summary>
    ''' Возвращает байтовое содержимое ресурса по его имени
    ''' </summary>
    ''' <param name="sourceName">Имя ресурса</param>
    ''' <returns></returns>
    ''' <remarks>Если ресурс не найден или его содержимое равно DBNull.Value возвращает Nothing</remarks>
    Public Function GetBinData(ByVal sourceName As String) As Object
        Return Resource.GetBinData(sourceName, _Connection)
    End Function

End Class
