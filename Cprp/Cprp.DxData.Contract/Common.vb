Imports C2 = Cprp.DxData.Common
''' <summary>
''' Общие свойства и методы
''' </summary>
''' <remarks></remarks>
Public Class Common

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Поиск лица в базе данных
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="Row">Строка таблицы сделок с предварительными данными для поиска</param>
    ''' <returns>Возвращает таблицу сделок на одну строку со связанной таблицей участников сделки</returns>  
    ''' <remarks>Если ничего не найдено, возвращает Nothing</remarks>
    Public Shared Function Find(Connection As SqlConnection, Optional Row As DataRow = Nothing) As ContractDataTable
        With New FindForm(Connection, Row)
            If .ShowDialog = DialogResult.OK Then Return .ContractRow
        End With
        Return Nothing
    End Function

End Class
