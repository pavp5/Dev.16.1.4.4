Imports C2 = Cprp.DxData.Common
''' <summary>
''' Участники сделки и операции
''' </summary>
''' <remarks></remarks>
Public Class MemberDataTable : Inherits Cprp.DxData.Member.MemberDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.MemberDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        MyBase.New("MemberTable")
        With Me.Columns
            .Add("conRusNum", GetType(Integer))             ' Порядковый номер в списке российских участников сделки
            .Add("conNusNum", GetType(Integer))             ' Порядковый номер в списке иностранных участников сделки
            .Add("supRusNum", GetType(Integer))             ' Порядковый номер в списке российских участников операции
            .Add("supNusNum", GetType(Integer))             ' Порядковый номер в списке иностранных участников операции
            .Add("supEndNum", GetType(Integer))             ' Порядковый номер в списке конечных пользователей в операции
            .Add("isNotEmbargo", GetType(Boolean))          ' Запреты и ограничения отсутствуют (да/нет)
            .Add("isNotControl", GetType(Boolean))          ' Не связан с лицами на контроле (да/нет)
            .Add("isNotConRusRisk", GetType(Boolean))       ' Риски по российскому участнику сделки отсутствуют (да/нет)
            .Add("isNotConNusRisk", GetType(Boolean))       ' Риски по иностранному участнику сделки отсутствуют (да/нет)
            .Add("isNotSupRusRisk", GetType(Boolean))       ' Риски по российскому участнику операции отсутствуют (да/нет)
            .Add("isNotSupNusRisk", GetType(Boolean))       ' Риски по иностранному участнику операции отсутствуют (да/нет)
            .Add("isNotSupEndRisk", GetType(Boolean))       ' Риски по конечному пользователю операции отсутствуют (да/нет)
            ' Поля проверки данных
            .Add("isCheckData", GetType(Boolean))           ' Регистрационные данные заполнены (да/нет)
            .Add("isCheckEmbargo", GetType(Boolean))        ' Запреты и ограничения отмечены (да/нет)
            .Add("isCheckControl", GetType(Boolean))        ' Фирмы на контроле отмечены (да/нет)
            .Add("isCheckProfile", GetType(Boolean))        ' Профиль заполнен (да/нет)
            .Add("isCheckConRusRisk", GetType(Boolean))     ' Риски по российскому участнику сделки отмечены (да/нет)
            .Add("isCheckConNusRisk", GetType(Boolean))     ' Риски по иностранному участнику сделки отмечены (да/нет)
            .Add("isCheckSupRusRisk", GetType(Boolean))     ' Риски по российскому участнику операции отмечены (да/нет)
            .Add("isCheckSupNusRisk", GetType(Boolean))     ' Риски по иностранному участнику операции отмечены (да/нет)
            .Add("isCheckSupEndRisk", GetType(Boolean))     ' Риски по конечному пользователю операции отмечены (да/нет)
        End With
        With Me.Columns("conRusNum")
            .AllowDBNull = True
            .DefaultValue = 0
        End With
        With Me.Columns("conNusNum")
            .AllowDBNull = True
            .DefaultValue = 0
        End With
        With Me.Columns("supRusNum")
            .AllowDBNull = True
            .DefaultValue = 0
        End With
        With Me.Columns("supNusNum")
            .AllowDBNull = True
            .DefaultValue = 0
        End With
        With Me.Columns("supEndNum")
            .AllowDBNull = True
            .DefaultValue = 0
        End With
        With Me.Columns("isNotEmbargo")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isNotControl")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isNotConRusRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isNotConNusRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isNotSupRusRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isNotSupNusRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isNotSupEndRisk")
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
        With Me.Columns("isCheckProfile")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckConRusRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckConNusRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckSupRusRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckSupNusRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isCheckSupEndRisk")
            .AllowDBNull = False
            .DefaultValue = False
        End With
    End Sub

    ''' <summary>
    ''' Сохранить новые и измененные данные в таблицу базы данных как новые записи
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks>
    ''' В процессе сохранения в поле dbId каждой строки записывается id соответствующей строки в таблице базы данных
    ''' </remarks>
    Public Overloads Sub DataInsert(Connection As SqlConnection)
        '
        ' Удаление строк не относящихся ни к каким участникам
        '
        Me.AcceptChanges()
        Using V As New DataView(Me)
            V.RowFilter = "conRusNum = 0 AND conNusNum = 0 AND supRusNum = 0 AND supNusNum = 0 AND supEndNum = 0"
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        Me.AcceptChanges()
        '
        ' Вызов базового метода
        '
        MyBase.DataInsert(Connection)
    End Sub

    ''' <summary>
    ''' Добавить новую строку с предзаполненным порядковым номером
    ''' </summary>
    ''' <param name="kind">Вид лиц</param>
    ''' <remarks></remarks>
    Friend Function AddNew(kind As Cprp.DxData.Member.MemberKind) As DataRow
        Dim Row As DataRow = Me.NewRow
        Dim iTmp As Integer = GetNewRowNum(kind)
        Select Case kind
            Case Member.MemberKind.IsContractRus : Row("conRusNum") = iTmp : Exit Select
            Case Member.MemberKind.IsContractNus : Row("conNusNum") = iTmp : Exit Select
            Case Member.MemberKind.IsSupplyRus : Row("supRusNum") = iTmp : Exit Select
            Case Member.MemberKind.IsSupplyNus : Row("supNusNum") = iTmp : Exit Select
            Case Member.MemberKind.IsSupplyEnd : Row("supEndNum") = iTmp : Exit Select
        End Select
        Me.Rows.Add(Row)
        Return Row
    End Function

    ''' <summary>
    ''' Установить порядковый номер вида лица
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    ''' <param name="kind">Вид лица</param>
    ''' <remarks></remarks>
    Friend Sub SetNum(Row As DataRow, kind As Cprp.DxData.Member.MemberKind)
        If Row Is Nothing OrElse Not TypeOf Row.Table Is MemberDataTable Then Exit Sub
        Dim iTmp As Integer = GetNewRowNum(kind)
        Select Case kind
            Case Member.MemberKind.IsContractRus : If C2.ToInt(Row("conRusNum")) < 1 Then Row("conRusNum") = iTmp : Exit Select
            Case Member.MemberKind.IsContractNus : If C2.ToInt(Row("conNusNum")) < 1 Then Row("conNusNum") = iTmp : Exit Select
            Case Member.MemberKind.IsSupplyRus : If C2.ToInt(Row("supRusNum")) < 1 Then Row("supRusNum") = iTmp : Exit Select
            Case Member.MemberKind.IsSupplyNus : If C2.ToInt(Row("supNusNum")) < 1 Then Row("supNusNum") = iTmp : Exit Select
            Case Member.MemberKind.IsSupplyEnd : If C2.ToInt(Row("supEndNum")) < 1 Then Row("supEndNum") = iTmp : Exit Select
        End Select
    End Sub

    ''' <summary>
    ''' Возвращает новый порядковый номер в списке лиц
    ''' </summary>
    ''' <param name="kind">Вид лица</param>
    ''' <remarks></remarks>
    Private Function GetNewRowNum(kind As Cprp.DxData.Member.MemberKind) As Integer
        Dim fieldName As String = Nothing
        Select Case kind
            Case Member.MemberKind.IsContractRus : fieldName = "conRusNum" : Exit Select
            Case Member.MemberKind.IsContractNus : fieldName = "conNusNum" : Exit Select
            Case Member.MemberKind.IsSupplyRus : fieldName = "supRusNum" : Exit Select
            Case Member.MemberKind.IsSupplyNus : fieldName = "supNusNum" : Exit Select
            Case Member.MemberKind.IsSupplyEnd : fieldName = "supEndNum" : Exit Select
            Case Else : Return 0
        End Select
        Dim iTmp As Integer = 0
        Dim iTmp1 As Integer = 0
        For Each Row As DataRow In Me.Rows
            If Row.RowState = DataRowState.Deleted OrElse Row.RowState = DataRowState.Detached Then Continue For
            iTmp1 = CInt(Row(fieldName))
            If iTmp1 > iTmp Then iTmp = iTmp1
        Next
        Return (iTmp + 1)
    End Function

#Region "View"

    Private _ConRusView As DataView = Nothing
    ''' <summary>
    ''' Представление со списком российских участников сделки
    ''' </summary>
    Public ReadOnly Property ConRusView As DataView
        Get
            If _ConRusView Is Nothing Then
                _ConRusView = New DataView(Me)
                _ConRusView.RowFilter = "conRusNum > 0"
                _ConRusView.Sort = "conRusNum"
            End If
            Return _ConRusView
        End Get
    End Property

    Private _ConNusView As DataView = Nothing
    ''' <summary>
    ''' Представление со списком иностранных участников сделки
    ''' </summary>
    Public ReadOnly Property ConNusView As DataView
        Get
            If _ConNusView Is Nothing Then
                _ConNusView = New DataView(Me)
                _ConNusView.RowFilter = "conNusNum > 0"
                _ConNusView.Sort = "conNusNum"
            End If
            Return _ConNusView
        End Get
    End Property

    Private _SupRusView As DataView = Nothing
    ''' <summary>
    ''' Представление со списком российских участников операции
    ''' </summary>
    Public ReadOnly Property SupRusView As DataView
        Get
            If _SupRusView Is Nothing Then
                _SupRusView = New DataView(Me)
                _SupRusView.RowFilter = "supRusNum > 0"
                _SupRusView.Sort = "supRusNum"
            End If
            Return _SupRusView
        End Get
    End Property

    Private _SupNusView As DataView = Nothing
    ''' <summary>
    ''' Представление со списком иностранных покупателей (продавцов)
    ''' </summary>
    Public ReadOnly Property SupNusView As DataView
        Get
            If _SupNusView Is Nothing Then
                _SupNusView = New DataView(Me)
                _SupNusView.RowFilter = "supNusNum > 0"
                _SupNusView.Sort = "supNusNum"
            End If
            Return _SupNusView
        End Get
    End Property

    Private _SupEndView As DataView = Nothing
    ''' <summary>
    ''' Представление со списком потребителей (конечных пользователей)
    ''' </summary>
    Public ReadOnly Property SupEndView As DataView
        Get
            If _SupEndView Is Nothing Then
                _SupEndView = New DataView(Me)
                _SupEndView.RowFilter = "supEndNum > 0"
                _SupEndView.Sort = "supEndNum"
            End If
            Return _SupEndView
        End Get
    End Property

    Private _EmptyView As DataView = Nothing
    ''' <summary>
    ''' Представление со списком лиц, не являющихся участниками сделки или операции
    ''' </summary>
    Public ReadOnly Property EmptyView As DataView
        Get
            If _EmptyView Is Nothing Then
                _EmptyView = New DataView(Me)
                _EmptyView.RowFilter = "conRusNum < 1 AND conNusNum < 1 AND supRusNum < 1 AND supNusNum < 1 AND supEndNum < 1"
            End If
            Return _EmptyView
        End Get
    End Property

#End Region

End Class
