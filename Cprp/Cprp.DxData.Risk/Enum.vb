Imports C2 = Cprp.DxData.Common
''' <summary>
''' Тип риска
''' </summary>
''' <remarks></remarks>
Public Enum TypeEnum
    ''' <summary>Пустое значение</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Страна</summary>
    IsCountry = 1
    ''' <summary>Сделка</summary>
    IsContract = 2
    ''' <summary>Российский участник сделки</summary>
    IsContractRus = 3
    ''' <summary>Иностранный участник сделки</summary>
    IsContractNus = 4
    ''' <summary>Операция</summary>
    IsSupply = 5
    ''' <summary>Российский участник операции</summary>
    IsSupplyRus = 6
    ''' <summary>Иностранный участник операции</summary>
    IsSupplyNus = 7
    ''' <summary>Конечный пользователь операции</summary>
    IsSupplyEnd = 8
    ''' <summary>Продукция</summary>
    IsGood = 9
End Enum
