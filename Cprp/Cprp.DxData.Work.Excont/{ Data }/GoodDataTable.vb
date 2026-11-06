Imports C2 = Cprp.DxData.Common
''' <summary>
''' Объекты экспертизы
''' </summary>
''' <remarks></remarks>
Public Class GoodDataTable : Inherits Cprp.DxData.Good.GoodDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.GoodDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New("GoodTable")
        With Me.Columns
            ' Порядковый номер
            .Add("rowNum", GetType(Integer))                ' Порядковый номер в списке объектов экспертизы
            ' Исследование по контрольным спискам
            .Add("studyDate", GetType(Date))                ' Дата исследования
            .Add("studyTnved", GetType(String))             ' Коды ТН ВЭД использованные для поиска в контрольных списках
            .Add("studyWord", GetType(String))              ' Ключевые слова
            .Add("studyWord1Id", GetType(Integer))          ' Ключевое слово #1
            .Add("studyWord2Id", GetType(Integer))          ' Ключевое слово #2
            .Add("studySummaryId", GetType(Integer))        ' Идентификатор результатов исследования (0 - отсутствует, 1 - списочный, 2 - контролируемый)
            .Add("studySummary", GetType(String))           ' Обобщенный анализ выявленных пунктов контрольных списков
            ' Запреты и ограничения
            .Add("isNotEmbargo", GetType(Boolean))          ' Запреты и ограничения отсутствуют
            ' Продукция на контроле
            .Add("isNotControl", GetType(Boolean))          ' Продукция на контроле отсутствует
            ' Признаки риска
            .Add("isNotRisk", GetType(Boolean))             ' Риски отсуствуют
            .Add("otherRisk", GetType(String))              ' Иные признаки риска
            ' Поля проверки данных
            .Add("isCheckData", GetType(Boolean))           ' Регистрационные данные заполнены (да/нет)
            .Add("isCheckEmbargo", GetType(Boolean))        ' Запреты и ограничения отмечены (да/нет)
            .Add("isCheckControl", GetType(Boolean))        ' Фирмы на контроле отмечены (да/нет)
            .Add("isCheckStudy", GetType(Boolean))          ' Исследование по контрольным спискам завершено (да/нет)
            .Add("isCheckRisk", GetType(Boolean))           ' Риски отмечены (да/нет)
            ' Связь с проектами заключений
            .Add("isDoc1", GetType(Boolean))                ' Признак принадлежности объекта экспертизы к заключению #1 (иначе - к заключению #2)
        End With
        With Me.Columns("rowNum")
            .AllowDBNull = False
        End With
        With Me.Columns("isUnreal")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("studySummaryId")
            .AllowDBNull = False
            .DefaultValue = Cprp.DxData.Law.StudyIndexEnum.IsNothing    ' отсутствует в контрольных списках
        End With
        With Me.Columns("isNotEmbargo")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isNotControl")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isNotRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckData")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckEmbargo")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckControl")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckStudy")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckRisk")
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
