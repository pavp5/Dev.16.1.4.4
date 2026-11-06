' ++++++++++++++++++++++++++++++++++
' Справочники, используемые в работе
' ++++++++++++++++++++++++++++++++++
Partial Public MustInherit Class WorkConnectionRow


    Private _LawDataSet As Cprp.DxData.Law.LawDataSet = Nothing
    ''' <summary>
    ''' Источник данных нормативных документов
    ''' </summary>
    Public ReadOnly Property LawDataSet As Cprp.DxData.Law.LawDataSet
        Get
            If _LawDataSet Is Nothing Then
                _LawDataSet = New Cprp.DxData.Law.LawDataSet
                With _LawDataSet.LawTable.Columns
                    .Add("lawDescription", GetType(String))         ' переработанное описание пункта контрольного списка
                    .Add("goodDescription", GetType(String))        ' технические характеристики объекта экспертизы для сравнения с пунктом
                    '.Add("summaryId", GetType(Integer))             ' идентификатор контрольного статуса пункта (0 - не выбран для сравнения, 1 - выбран для сравнения, 2 - соответствует)
                End With
                With _LawDataSet.LawTable.Columns("summaryId")
                    .AllowDBNull = False
                    .DefaultValue = CInt(Cprp.DxData.Law.StudyIndexEnum.IsNothing)
                End With
                _LawDataSet.DataLoad(MyClass.Connection, Date.Now, True, True, True, True, True, True)
            End If
            Return _LawDataSet
        End Get
    End Property

    Private _WorkSortTable As Cprp.DxData.Handbook.WorkSortDataTable = Nothing
    ''' <summary>
    ''' Справочник характеров внешнеэкономических операций
    ''' </summary>
    Public ReadOnly Property WorkSortHandbookTable As Cprp.DxData.Handbook.WorkSortDataTable
        Get
            If _WorkSortTable Is Nothing Then
                _WorkSortTable = New Cprp.DxData.Handbook.WorkSortDataTable(MyClass.Connection)
            End If
            Return _WorkSortTable
        End Get
    End Property

    Private _SupplyTypeTable As Cprp.DxData.Handbook.SupplyTypeDataTable = Nothing
    ''' <summary>
    ''' Справочник характеров внешнеэкономических операций
    ''' </summary>
    Public ReadOnly Property SupplyTypeHandbookTable As Cprp.DxData.Handbook.SupplyTypeDataTable
        Get
            If _SupplyTypeTable Is Nothing Then
                _SupplyTypeTable = New Cprp.DxData.Handbook.SupplyTypeDataTable(MyClass.Connection)
            End If
            Return _SupplyTypeTable
        End Get
    End Property

    Private _IncotermsTable As Cprp.DxData.Handbook.IncotermsDataTable = Nothing
    ''' <summary>
    ''' Справочник условия поставки по Инкотермс
    ''' </summary>
    Public ReadOnly Property IncotermsHandbookTable As Cprp.DxData.Handbook.IncotermsDataTable
        Get
            If _IncotermsTable Is Nothing Then
                _IncotermsTable = New Cprp.DxData.Handbook.IncotermsDataTable(MyClass.Connection)
            End If
            Return _IncotermsTable
        End Get
    End Property


    Private _CountryTable As Cprp.DxData.Handbook.CountryDataTable = Nothing
    ''' <summary>
    ''' Справочник стран мира
    ''' </summary>
    Public ReadOnly Property CountryHandbookTable As Cprp.DxData.Handbook.CountryDataTable
        Get
            If _CountryTable Is Nothing Then
                _CountryTable = New Cprp.DxData.Handbook.CountryDataTable(MyClass.Connection)
            End If
            Return _CountryTable
        End Get
    End Property

    Private _MemberTypeTable As Cprp.DxData.Handbook.MemberTypeDataTable = Nothing
    ''' <summary>
    ''' Справочник видов лиц
    ''' </summary>
    Public ReadOnly Property MemberTypeHandbookTable As Cprp.DxData.Handbook.MemberTypeDataTable
        Get
            If _MemberTypeTable Is Nothing Then
                _MemberTypeTable = New Cprp.DxData.Handbook.MemberTypeDataTable(MyClass.Connection)
            End If
            Return _MemberTypeTable
        End Get
    End Property

    Private _GoodCategoryTable As Cprp.DxData.Handbook.GoodCategoryDataTable = Nothing
    ''' <summary>
    ''' Справочник категорий объектов экспертизы
    ''' </summary>
    Public ReadOnly Property GoodCategoryHandbookTable As Cprp.DxData.Handbook.GoodCategoryDataTable
        Get
            If _GoodCategoryTable Is Nothing Then
                _GoodCategoryTable = New Cprp.DxData.Handbook.GoodCategoryDataTable(MyClass.Connection)
            End If
            Return _GoodCategoryTable
        End Get
    End Property

    Private _GoodTypeTable As Cprp.DxData.Handbook.GoodTypeDataTable = Nothing
    ''' <summary>
    ''' Справочник видов объектов экспертизы
    ''' </summary>
    Public ReadOnly Property GoodTypeHandbookTable As Cprp.DxData.Handbook.GoodTypeDataTable
        Get
            If _GoodTypeTable Is Nothing Then
                _GoodTypeTable = New Cprp.DxData.Handbook.GoodTypeDataTable(MyClass.Connection)
            End If
            Return _GoodTypeTable
        End Get
    End Property

    Private _RiskTable As Cprp.DxData.Risk.RiskDataTable = Nothing
    ''' <summary>
    ''' Справочник признаков риска
    ''' </summary>
    Public ReadOnly Property RiskHandbookTable As Cprp.DxData.Risk.RiskDataTable
        Get
            If _RiskTable Is Nothing Then
                _RiskTable = New Cprp.DxData.Risk.RiskDataTable(MyClass.Connection)
            End If
            Return _RiskTable
        End Get
    End Property

    Private _EmbargoCountryTable As Cprp.DxData.Embargo.CountryDataTable = Nothing
    ''' <summary>
    ''' Запреты и ограничения в отношении стран
    ''' </summary>
    Public ReadOnly Property EmbargoCountryHandbookTable As Cprp.DxData.Embargo.CountryDataTable
        Get
            If _EmbargoCountryTable Is Nothing Then
                _EmbargoCountryTable = New Cprp.DxData.Embargo.CountryDataTable(MyClass.Connection)
            End If
            Return _EmbargoCountryTable
        End Get
    End Property

    Private _EmbargoMemberTable As Cprp.DxData.Embargo.MemberDataTable = Nothing
    ''' <summary>
    ''' Запреты и ограничения в отношении лиц
    ''' </summary>
    Public ReadOnly Property EmbargoMemberHandbookTable As Cprp.DxData.Embargo.MemberDataTable
        Get
            If _EmbargoMemberTable Is Nothing Then
                _EmbargoMemberTable = New Cprp.DxData.Embargo.MemberDataTable(MyClass.Connection)
            End If
            Return _EmbargoMemberTable
        End Get
    End Property

    Private _EmbargoGoodTable As Cprp.DxData.Embargo.GoodDataTable = Nothing
    ''' <summary>
    ''' Запреты и ограничения в отношении продукции
    ''' </summary>
    Public ReadOnly Property EmbargoGoodHandbookTable As Cprp.DxData.Embargo.GoodDataTable
        Get
            If _EmbargoGoodTable Is Nothing Then
                _EmbargoGoodTable = New Cprp.DxData.Embargo.GoodDataTable(MyClass.Connection)
            End If
            Return _EmbargoGoodTable
        End Get
    End Property

    Private _ControlMemberTable As Cprp.DxData.Member.ControlMemberDataTable = Nothing
    ''' <summary>
    ''' Лица на контроле
    ''' </summary>
    Public ReadOnly Property ControlMemberHandbookTable As Cprp.DxData.Member.ControlMemberDataTable
        Get
            If _ControlMemberTable Is Nothing Then
                _ControlMemberTable = New Cprp.DxData.Member.ControlMemberDataTable(MyClass.Connection)
            End If
            Return _ControlMemberTable
        End Get
    End Property

    Private _ControlGoodTable As Cprp.DxData.Good.ControlGoodDataTable = Nothing
    ''' <summary>
    ''' Продукция на контроле
    ''' </summary>
    Public ReadOnly Property ControlGoodHandbookTable As Cprp.DxData.Good.ControlGoodDataTable
        Get
            If _ControlGoodTable Is Nothing Then
                _ControlGoodTable = New Cprp.DxData.Good.ControlGoodDataTable(MyClass.Connection)
            End If
            Return _ControlGoodTable
        End Get
    End Property

    Private _WorkKindTable As Cprp.DxData.Handbook.WorkKindDataTable = Nothing
    ''' <summary>
    ''' Справочник характеристик экспертизы
    ''' </summary>
    Public ReadOnly Property WorkKindHandbookTable As Cprp.DxData.Handbook.WorkKindDataTable
        Get
            If _WorkKindTable Is Nothing Then
                _WorkKindTable = New Cprp.DxData.Handbook.WorkKindDataTable(MyClass.Connection)
            End If
            Return _WorkKindTable
        End Get
    End Property

    Private _WorkTypeTable As Cprp.DxData.Handbook.WorkTypeDataTable = Nothing
    ''' <summary>
    ''' Справочник видов услуг
    ''' </summary>
    Public ReadOnly Property WorkTypeHandbookTable As Cprp.DxData.Handbook.WorkTypeDataTable
        Get
            If _WorkTypeTable Is Nothing Then
                _WorkTypeTable = New Cprp.DxData.Handbook.WorkTypeDataTable(MyClass.Connection)
            End If
            Return _WorkTypeTable
        End Get
    End Property

    Private _UnitTable As Cprp.DxData.Handbook.UnitDataTable = Nothing
    ''' <summary>
    ''' Справочник единиц измерений
    ''' </summary>
    Public ReadOnly Property UnitHandbookTable As Cprp.DxData.Handbook.UnitDataTable
        Get
            If _UnitTable Is Nothing Then
                _UnitTable = New Cprp.DxData.Handbook.UnitDataTable(MyClass.Connection)
            End If
            Return _UnitTable
        End Get
    End Property

    Private _LawCaptionTable As Cprp.DxData.Handbook.LawCaptionDataTable = Nothing
    ''' <summary>
    ''' Справочник заголовков контрольных списков
    ''' </summary>
    Public ReadOnly Property LawCaptionHandbookTable As Cprp.DxData.Handbook.LawCaptionDataTable
        Get
            If _LawCaptionTable Is Nothing Then
                _LawCaptionTable = New Cprp.DxData.Handbook.LawCaptionDataTable(MyClass.Connection)
            End If
            Return _LawCaptionTable
        End Get
    End Property

    Private _UrgencyTable As Cprp.DxData.Handbook.UrgencyDataTable = Nothing
    ''' <summary>
    ''' Справочник признаков срочности
    ''' </summary>
    Public ReadOnly Property UrgencyHandbookTable As Cprp.DxData.Handbook.UrgencyDataTable
        Get
            If _UrgencyTable Is Nothing Then
                _UrgencyTable = New Cprp.DxData.Handbook.UrgencyDataTable(MyClass.Connection)
            End If
            Return _UrgencyTable
        End Get
    End Property

End Class
