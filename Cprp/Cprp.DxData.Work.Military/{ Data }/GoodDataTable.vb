Imports C2 = Cprp.DxData.Common
''' <summary>
''' Объекты экспертизы
''' </summary>
Public Class GoodDataTable : Inherits Cprp.DxData.Good.GoodDataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New()
        MyBase.New("GoodTable")
        With Me.Columns
            .Add("rowNum", GetType(Integer))                ' Порядковый номер в списке объектов экспертизы
            ' Исследование
            .Add("lawId", GetType(Integer))                 ' ID пункта классификатора ПВН
            .Add("summary", GetType(String))                ' Выводы по результатам исследования
            ' Поля проверки данных
            .Add("isCheckData", GetType(Boolean))           ' Регистрационные данные заполнены (да/нет)
            .Add("isCheckSummary", GetType(Boolean))        ' Сравнительный анализ проведен (да/нет)
            ' Дополнительные поля для создания проекта заключения
            .Add("catNum", GetType(String))                 ' Номер выбранной категории Классификатора
            .Add("catDescription", GetType(String))         ' Полное описание выбранной категории Классификатора
            .Add("areaUsed", GetType(String))               ' Область применения + Назначение
            .Add("docList", GetType(String))                ' Список документов, подтверждающих гражданское назначение
            .Add("groupText", GetType(String))              ' Поле для группировки строк по отдельным признакам
        End With
        With Me.Columns("rowNum")
            .AllowDBNull = False
        End With
        With Me.Columns("isCheckData")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckSummary")
            .AllowDBNull = False
            .DefaultValue = False
        End With
    End Sub


    ''' <summary>
    ''' Добавить новую строку с предзаполненным порядковым номером
    ''' </summary>
    ''' <remarks></remarks>
    Public Function AddNew() As DataRow
        Dim Row As DataRow = Me.NewRow
        Row("rowNum") = GetNewRowNum()
        Me.Rows.Add(Row)
        Return Row
    End Function

    ''' <summary>
    ''' Возвращает новый порядковый номер в списке объектов экспертизы
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function GetNewRowNum() As Integer
        Dim iTmp As Integer = 0
        Dim iTmp1 As Integer = 0
        For Each Row As DataRow In Me.Rows
            If Row.RowState = DataRowState.Deleted OrElse Row.RowState = DataRowState.Detached Then Continue For
            iTmp1 = CInt(Row("rowNum"))
            If iTmp1 > iTmp Then iTmp = iTmp1
        Next
        Return (iTmp + 1)
    End Function

End Class
