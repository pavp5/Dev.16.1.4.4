''' <summary>
''' Предметные области
''' </summary>
Public Enum AreaEnum
    ''' <summary>Экспортный контроль</summary>
    isExcont = 1
    ''' <summary>Военно-техническое сотрудничество</summary>
    isMilitary = 2
    ''' <summary>Запреты и ограничения Таможенного союза</summary>
    isCustom = 3
End Enum

''' <summary>
''' Направления перемещения
''' </summary>
Public Enum ModeEnum
    ''' <summary>Из России</summary>
    isExport = 1
    ''' <summary>В Россию</summary>
    isImport = 2
    ''' <summary>Из России + В Россию</summary>
    isBoth = 3
End Enum
