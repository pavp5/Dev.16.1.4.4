Imports Cprp.DxData.Common
''' <summary>
''' Виды лицензий
''' </summary>
Public Enum LicenseType
    ''' <summary>Пустое значение</summary>
    IsEmpty = EMPTY_ID
    ''' <summary>Разовая/экспорт</summary>
    IsOneExport = 1
    ''' <summary>Разовая/импорт</summary>
    IsOneImport = 2
    ''' <summary>Генеральная/экспорт</summary>
    IsGeneralExport = 3
End Enum