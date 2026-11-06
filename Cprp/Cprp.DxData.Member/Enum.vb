Imports C2 = Cprp.DxData.Common
''' <summary>
''' Типы лиц
''' </summary>
''' <remarks></remarks>
Public Enum MemberType
    ''' <summary>Пустой (нет в базе)</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Юридическое лицо</summary>
    IsLegal = 1
    ''' <summary>Физическое лицо</summary>
    IsPhysical = 2
    ''' <summary>Индивидуальный предприниматель</summary>
    IsBusinessman = 3
End Enum

''' <summary>
''' Виды лиц
''' </summary>
''' <remarks></remarks>
Public Enum MemberKind
    ''' <summary>Пустой (нет в базе)</summary>
    IsEmpty = C2.EMPTY_ID
    ''' <summary>Заказчик</summary>
    IsClient = 1
    ''' <summary>Российский участник сделки</summary>
    IsContractRus = 2
    ''' <summary>Иностранный участник сделки</summary>
    IsContractNus = 3
    ''' <summary>Грузополучатель</summary>
    IsCargo = 4
    ''' <summary>Конечный пользователь в операции</summary>
    IsSupplyEnd = 5
    ''' <summary>Российский участник операции</summary>
    IsSupplyRus = 6
    ''' <summary>Иностранные участник операции</summary>
    IsSupplyNus = 7
    ''' <summary>Представитель заказчика</summary>
    IsPerson = 9
    ''' <summary>Изготовитель (разработчик)</summary>
    IsDeveloper = 10

End Enum
