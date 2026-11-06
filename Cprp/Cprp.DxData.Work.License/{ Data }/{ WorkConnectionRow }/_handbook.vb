' ++++++++++++++++++++++++++++++++++
' Справочники, используемые в работе
' ++++++++++++++++++++++++++++++++++
Partial Public Class WorkConnectionRow

    Private _LicenseTypeTable As Cprp.DxData.Handbook.LicenseTypeDataTable = Nothing
    ''' <summary>
    ''' Справочник видов лицензий
    ''' </summary>
    Public ReadOnly Property LicenseTypeHandbookTable As Cprp.DxData.Handbook.LicenseTypeDataTable
        Get
            If _LicenseTypeTable Is Nothing Then
                _LicenseTypeTable = New Cprp.DxData.Handbook.LicenseTypeDataTable(MyClass.Connection)
            End If
            Return _LicenseTypeTable
        End Get
    End Property

    Private _LicenseConditionTable As Cprp.DxData.Handbook.LicenseConditionDataTable = Nothing
    ''' <summary>
    ''' Справочник состояний лицензии
    ''' </summary>
    Public ReadOnly Property LicenseConditionHandbookTable As Cprp.DxData.Handbook.LicenseConditionDataTable
        Get
            If _LicenseConditionTable Is Nothing Then
                _LicenseConditionTable = New Cprp.DxData.Handbook.LicenseConditionDataTable(MyClass.Connection)
            End If
            Return _LicenseConditionTable
        End Get
    End Property


    Private _PaymentTable As Cprp.DxData.Handbook.PaymentDataTable = Nothing
    ''' <summary>
    ''' Справочник условий платежа
    ''' </summary>
    Public ReadOnly Property PaymentHandbookTable As Cprp.DxData.Handbook.PaymentDataTable
        Get
            If _PaymentTable Is Nothing Then
                _PaymentTable = New Cprp.DxData.Handbook.PaymentDataTable(MyClass.Connection)
            End If
            Return _PaymentTable
        End Get
    End Property

    Private _CurrencyTable As Cprp.DxData.Handbook.CurrencyDataTable = Nothing
    ''' <summary>
    ''' Справочник валют
    ''' </summary>
    Public ReadOnly Property CurrencyHandbookTable As Cprp.DxData.Handbook.CurrencyDataTable
        Get
            If _CurrencyTable Is Nothing Then
                _CurrencyTable = New Cprp.DxData.Handbook.CurrencyDataTable(MyClass.Connection)
            End If
            Return _CurrencyTable
        End Get
    End Property

End Class
