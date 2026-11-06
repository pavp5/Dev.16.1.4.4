''' <summary>
''' Справочник признаков рисков
''' </summary>
''' <remarks></remarks>
Public Class RiskDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))            ' ID
            .Add("caption", GetType(String))        ' Наименование признака риска
            .Add("typeId", GetType(Integer))        ' Тип риска (TypeEnum)
            .Add("isCheck", GetType(Boolean))       ' Отмечена (да/нет)
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("caption").AllowDBNull = False
        Me.Columns("typeId").AllowDBNull = False
        With Me.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Me.DefaultView.Sort = "id"
    End Sub

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param> 
    ''' <remarks></remarks>
    Public Sub New(Connection As SqlConnection)
        MyClass.New()
        DataLoad(Connection)
    End Sub

    ''' <summary>
    ''' Загрузить данные из базы данных
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub DataLoad(Connection As SqlConnection)
        Me.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, caption, typeId FROM tRisk WHERE isACT = 1"
            Me.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ''' <summary>
    ''' Снять все отметки
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CheckClear()
        Using V As New DataView(Me)
            V.RowFilter = "isCheck = True"
            While V.Count > 0
                V(0)("isCheck") = False
            End While
        End Using
    End Sub

    ''' <summary>
    ''' Возвращает строку id рисков определенного типа разделенных запятыми
    ''' </summary>
    ''' <param name="typeId">Тип риска</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function StrTypeId(typeId As TypeEnum) As String
        Dim sTmp As String = Nothing
        Using V As New DataView(Me)
            V.RowFilter = String.Format("typeId = {0}", CInt(typeId))
            For Each VRow As DataRowView In V
                sTmp = String.Format("{0}, {1}", sTmp, CInt(VRow("id")))
            Next
        End Using
        If String.IsNullOrWhiteSpace(sTmp) Then Return Nothing
        Return sTmp.Substring(2)
    End Function

#Region "View"

    Private _CountryView As DataView = Nothing
    ''' <summary>
    ''' Представление рисков по стране
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property CountryView As DataView
        Get
            If _CountryView Is Nothing Then
                _CountryView = New DataView(Me)
                _CountryView.RowFilter = String.Format("typeId = {0}", CInt(TypeEnum.IsCountry))
            End If
            Return _CountryView
        End Get
    End Property

    Private _ContractView As DataView = Nothing
    ''' <summary>
    ''' Представление рисков по сделке
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ContractView As DataView
        Get
            If _ContractView Is Nothing Then
                _ContractView = New DataView(Me)
                _ContractView.RowFilter = String.Format("typeId = {0}", CInt(TypeEnum.IsContract))
            End If
            Return _ContractView
        End Get
    End Property

    Private _ContractRusView As DataView = Nothing
    ''' <summary>
    ''' Представление рисков по российскому участнику сделки
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ContractRusView As DataView
        Get
            If _ContractRusView Is Nothing Then
                _ContractRusView = New DataView(Me)
                _ContractRusView.RowFilter = String.Format("typeId = {0}", CInt(TypeEnum.IsContractRus))
            End If
            Return _ContractRusView
        End Get
    End Property

    Private _ContractNusView As DataView = Nothing
    ''' <summary>
    ''' Представление рисков по иностранному участнику сделки
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property ContractNusView As DataView
        Get
            If _ContractNusView Is Nothing Then
                _ContractNusView = New DataView(Me)
                _ContractNusView.RowFilter = String.Format("typeId = {0}", CInt(TypeEnum.IsContractNus))
            End If
            Return _ContractNusView
        End Get
    End Property

    Private _SupplyView As DataView = Nothing
    ''' <summary>
    ''' Представление рисков по операции
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property SupplyView As DataView
        Get
            If _SupplyView Is Nothing Then
                _SupplyView = New DataView(Me)
                _SupplyView.RowFilter = String.Format("typeId = {0}", CInt(TypeEnum.IsSupply))
            End If
            Return _SupplyView
        End Get
    End Property

    Private _SupplyRusView As DataView = Nothing
    ''' <summary>
    ''' Представление рисков по российскому участнику операции
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property SupplyRusView As DataView
        Get
            If _SupplyRusView Is Nothing Then
                _SupplyRusView = New DataView(Me)
                _SupplyRusView.RowFilter = String.Format("typeId = {0}", CInt(TypeEnum.IsSupplyRus))
            End If
            Return _SupplyRusView
        End Get
    End Property

    Private _SupplyNusView As DataView = Nothing
    ''' <summary>
    ''' Представление рисков по иностранному покупателю (продавцу)
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property SupplyNusView As DataView
        Get
            If _SupplyNusView Is Nothing Then
                _SupplyNusView = New DataView(Me)
                _SupplyNusView.RowFilter = String.Format("typeId = {0}", CInt(TypeEnum.IsSupplyNus))
            End If
            Return _SupplyNusView
        End Get
    End Property

    Private _SupplyEndView As DataView = Nothing
    ''' <summary>
    ''' Представление рисков по потребителю (конечному пользователю)
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property SupplyEndView As DataView
        Get
            If _SupplyEndView Is Nothing Then
                _SupplyEndView = New DataView(Me)
                _SupplyEndView.RowFilter = String.Format("typeId = {0}", CInt(TypeEnum.IsSupplyEnd))
            End If
            Return _SupplyEndView
        End Get
    End Property

    Private _GoodView As DataView = Nothing
    ''' <summary>
    ''' Представление рисков по продукции
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property GoodView As DataView
        Get
            If _GoodView Is Nothing Then
                _GoodView = New DataView(Me)
                _GoodView.RowFilter = String.Format("typeId = {0}", CInt(TypeEnum.IsGood))
            End If
            Return _GoodView
        End Get
    End Property

#End Region

End Class
