''' <summary>
''' Тип строки
''' </summary>
''' <remarks></remarks>
Public Enum TypeEnum
    ''' <summary>Обычная строка</summary>
    IsParagraph = 1
    ''' <summary>Примечание</summary>
    IsComment = 2
    ''' <summary>Заголовок первого уровня</summary>
    IsLevel1 = 3
    ''' <summary>Заголовок второго уровня</summary>
    IsLevel2 = 4
    ''' <summary>Заголовок третьего уровня</summary>
    IsLevel3 = 5
End Enum

''' <summary>
''' Идентификатор сравнительного анализа
''' </summary>
''' <remarks></remarks>
Public Enum StudyIndexEnum
    ''' <summary>Отсутсвует в нормативных документах</summary>
    IsNothing = 0
    ''' <summary>Не соответствует</summary>
    IsOther = 1
    ''' <summary>Соответсвует</summary>
    IsEqual = 2
End Enum
