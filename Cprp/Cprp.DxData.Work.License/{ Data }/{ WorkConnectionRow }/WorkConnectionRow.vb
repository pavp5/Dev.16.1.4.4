Imports C2 = Cprp.DxData.Common
''' <summary>
''' Работа
''' </summary>
Public Class WorkConnectionRow : Inherits Cprp.DxData.Work.WorkConnectionRow

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Liconfirm.WorkConnectionRow
    ''' </summary>
    ''' <param name="id">ID работы</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(id As Object, Connection As SqlConnection)
        MyBase.New(Connection)
        '
        ' Arow
        '
        With MyBase.ARow.Columns
            ' Заявление
            .Add("statNum", GetType(String))                ' номер заявления (1)
            .Add("statDate", GetType(Date))                 ' дата заявления (1)
            .Add("licTypeId", GetType(Integer))             ' вид запрашиваемой лицензии (2)
            .Add("clientName", GetType(String))             ' заявитель - наименование (3)
            .Add("clientAddress", GetType(String))          ' заявитель - адрес (3)
            .Add("licTerm", GetType(Date))                  ' заявляемый срок действия лицензии (4)
            .Add("conNum", GetType(String))                 ' номер контракта (5)
            .Add("conDate", GetType(Date))                  ' дата контракта (5)
            .Add("incotermsId", GetType(Integer))           ' условия поставки - инкотермс (6)
            .Add("incotermsPlace", GetType(String))         ' условия поставки - место (6)
            .Add("bayerName", GetType(String))              ' покупатель / продавец - наименование (7)
            .Add("bayerAddress", GetType(String))           ' покупатель /продавец - адрес (7)
            .Add("devName", GetType(String))                ' изготовитель / разработчик - наименование (8)
            .Add("devAddress", GetType(String))             ' изготовитель / разработчик - адрес (8)
            .Add("endName", GetType(String))                ' конечный пользователь - наименование (9)
            .Add("endAddress", GetType(String))             ' конечный пользователь - адрес (9)
            .Add("devCountryId", GetType(Integer))          ' страна происхождения (10)
            .Add("bayerCountryId", GetType(Integer))        ' страна покупателия / продавца (11)
            .Add("transitCountryIdString", GetType(String)) ' страна (страны) транзита (12)
            .Add("endCountryId", GetType(Integer))          ' страна конечного использования (13)
            .Add("goodCaption", GetType(String))            ' наименование и характеристики (описание) продукции (14)
            .Add("goodTnved", GetType(String))              ' код ТН ВЭД (15)
            .Add("currencyId", GetType(Integer))            ' валюта контракта (16)
            .Add("unitId", GetType(Integer))                ' единица измерения (17)
            .Add("paymentId", GetType(Integer))             ' условие платежа (18)
            .Add("unitCount", GetType(String))              ' количество (19)
            .Add("usdPrice", GetType(Integer))              ' статистическая стоимость в USD, округляется до целого (20)
            .Add("goodUsed", GetType(String))               ' конечное использование (21)
            .Add("bankName", GetType(String))               ' банк заявителя (22)
            .Add("bankAddress", GetType(String))            ' адрес банка заявителя (22)
            .Add("bankAccount", GetType(String))            ' номер счета заявителя (22)
            .Add("licBasis", GetType(String))               ' основание для запроса лицензии (23)
            .Add("lawId", GetType(Integer))                 ' код списка (24)
            .Add("lawPos", GetType(String))                 ' позиция списка (25)
            .Add("customName", GetType(String))             ' таможенный орган (26)
            .Add("extraInfo", GetType(String))              ' дополнительная информация (27)
            .Add("personName", GetType(String))             ' ФИО уполномоченного лица (28)
            .Add("personJob", GetType(String))              ' должность уполномоченного лица (28)
            .Add("personPhone", GetType(String))            ' телефон / факс контактного лица (28)
            ' Документ-заявление
            .Add("statData", GetType(Byte()))               ' содержимое заявления (openXml)
        End With
        ''
        '' Другие таблицы
        ''
        'GoodTable = New GoodDataTable
        'GoodAppendTable = New GoodAppendDataTable
        ''
        '' Источник данных работы
        ''
        'MyBase.DS.Tables.AddRange(New DataTable() {GoodTable, GoodAppendTable})
        'Dim Relation As New DataRelation("GoodAppendRelation", GoodTable.Columns("id"), GoodAppendTable.Columns("goodId"))
        'MyBase.Ds.Relations.Add(Relation)
        'Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
        '
        ' ID
        '
        MyClass.Id = id

    End Sub

    ''' <summary>
    ''' ID работы
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Property Id As Object
        Get
            Return MyBase.Id
        End Get
        Set(value As Object)
            MyBase.Id = value
            If MyBase.IsEmpty Then Exit Property
        End Set
    End Property

    ''' <summary>
    ''' Сохранить данные в базу данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Overrides Sub DataSave()
        Me("countryName") = GetToCountryName()
        Me("percentCount") = GetPercentCount()
        MyBase.DataSave()
    End Sub


    ''' <summary>
    ''' Возвращает наименование страны назначения
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetToCountryName() As String
        Return Nothing
    End Function

    ''' <summary>
    ''' Возвращает процент выполнения работы
    ''' </summary>
    ''' <remarks></remarks>
    Private Function GetPercentCount() As Integer
        Dim Row As DataRow = Me.LicenseConditionHandbookTable.Rows.Find(C2.ToInt(Me("licConditionId")))
        If Row Is Nothing Then Return 0
        Return C2.ToInt(Row("percentCount"))
    End Function


    ' ''' <summary>
    ' ''' Сохранить новые и измененные данные в таблицу базы данных как новые записи
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Public Sub DataInsert()
    '    '
    '    ' tGood
    '    '
    '    Me.GoodTable.UpdateCategoryByType(MyBase.GoodTypeHandbookTable)
    '    Me.GoodTable.DataInsert(Me.Connection)

    'End Sub

End Class
