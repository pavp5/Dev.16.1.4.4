Imports C2 = Cprp.DxData.Common
''' <summary>
''' Общие свойства и методы
''' </summary>
''' <remarks></remarks>
Public Class Common

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Поиск объекта экспертизы в базе данных
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="Row">Строка таблицы объектов экспертизы с предварительными данными для поиска</param>
    ''' <returns>Возвращает таблицу объектов экспертизы на одну строку</returns>  
    ''' <remarks>Если ничего не найдено, возвращает Nothing</remarks>
    Public Shared Function Find(Connection As SqlConnection, Optional Row As DataRow = Nothing) As GoodDataTable
        With New FindForm(Connection, Row)
            If .ShowDialog = DialogResult.OK Then Return .GoodRow
        End With
        Return Nothing
    End Function


    ''' <summary>
    ''' Преобразует переданное значение в код ТН ВЭД
    ''' </summary>
    ''' <param name="value">Передаваемое значение</param>
    ''' <returns>Возвращает строку цифр</returns>
    ''' <remarks>Если значение не содержит цифр, возвращает String.Empty</remarks>
    Public Shared Function ToTnved(value As Object) As String
        Dim code As String = String.Empty
        For Each c As Char In C2.ToText(value)
            If c Like "[0123456789]" Then code &= c
        Next
        Return code
    End Function

End Class
