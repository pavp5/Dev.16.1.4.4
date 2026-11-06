Imports C2 = Cprp.DxData.Common
''' <summary>
''' Таблица вопросов и ответов
''' </summary>
''' <remarks></remarks>
Public Class QueryDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New("QueryTable")
        With Me.Columns
            .Add("id", GetType(Integer))                        ' ID
            .Add("rowNum", GetType(Integer))                    ' Порядковый номер
            .Add("ask", GetType(String))                        ' Вопрос
            .Add("ans", GetType(String))                        ' Ответ
            .Add("isCheck", GetType(Boolean))                   ' Поле проверки данных
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = True
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
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

