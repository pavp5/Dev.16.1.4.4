Imports C2 = Cprp.DxData.Common
''' <summary>
''' Справочник запретов и ограничений в отношении продукции
''' </summary>
''' <remarks></remarks>
Public Class GoodDataTable : Inherits DataTable

    ''' <summary>
    ''' Таблица кодов ТН ВЭД
    ''' </summary>   
    Private TnvedTable As GoodTnvedDataTable = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    Public Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))                ' ID
            .Add("embargoId", GetType(Integer))         ' ID запрета
            .Add("countryId", GetType(Integer))         ' ID страны
            .Add("goodCaption", GetType(String))        ' Наименование продукции
            .Add("goodTnved", GetType(String))          ' Коды ТН ВЭД
            .Add("embargoCaption", GetType(String))     ' Наименование и реквизиты документа, устанавливающего эмбарго
            .Add("embargoCaption2", GetType(String))    ' Реквизиты и наименование документа, устанавливающего эмбарго
            .Add("modeId", GetType(Integer))            ' Направление перемещения (ModeEnum)
            .Add("isLimited", GetType(Boolean))         ' ДСП (да/нет)
            .Add("isCheck", GetType(Boolean))           ' Отмечена (да/нет)
        End With
        Me.Columns("id").AllowDBNull = False
        Me.Columns("embargoId").AllowDBNull = False
        Me.Columns("countryId").AllowDBNull = False
        Me.Columns("goodCaption").AllowDBNull = False
        Me.Columns("embargoCaption").AllowDBNull = False
        Me.Columns("embargoCaption2").AllowDBNull = False
        Me.Columns("modeId").AllowDBNull = False
        Me.Columns("isLimited").AllowDBNull = False
        With Me.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id"), Me.Columns("countryId")}
        TnvedTable = New GoodTnvedDataTable
    End Sub

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param> 
    Public Sub New(Connection As SqlConnection)
        MyClass.New()
        DataLoad(Connection)
    End Sub

    ''' <summary>
    ''' Загрузить данные из базы данных
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Friend Sub DataLoad(Connection As SqlConnection)
        Me.Rows.Clear()
        TnvedTable.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, embargoId, countryId, goodCaption, goodTnved, embargoCaption, embargoCaption2, modeId, isLimited FROM vEmbargoGoodData WHERE isACT = 1"
            Me.Load(Cmd.ExecuteReader)
            Cmd.CommandText = "SELECT goodId, tnved FROM tEmbargoGoodTnved"
            TnvedTable.Load(Cmd.ExecuteReader)
        End Using
    End Sub

    ''' <summary>
    ''' Снять все отметки
    ''' </summary>
    Public Sub CheckClear()
        Using V As New DataView(Me)
            V.RowFilter = "isCheck = True"
            While V.Count > 0
                V(0)("isCheck") = False
            End While
        End Using
    End Sub

    ''' <summary>
    ''' Представление запретов и ограничений по опеределенной стране
    ''' </summary>
    ''' <param name="countryId">ID страны</param>
    Public Function CountryView(countryId As Object) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("countryId = {0}", C2.ToInt(countryId))}
    End Function

    ''' <summary>
    ''' Представление запретов и ограничений по опеределенной стране
    ''' </summary>
    ''' <param name="countryId">ID страны</param>
    ''' <param name="mode">Направление перемещения</param>
    Public Function CountryView(countryId As Object, mode As ModeEnum) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("countryId = {0} AND (modeId = {1} OR modeId = {2})", C2.ToInt(countryId), CInt(mode), CInt(ModeEnum.isBoth))}
    End Function

    ''' <summary>
    ''' Представление запретов и ограничений по опеределенной стране
    ''' </summary>
    ''' <param name="countryId">ID страны</param>
    ''' <param name="mode">Направление перемещения</param>
    ''' <param name="tnved">Код ТН ВЭД</param>
    Public Function CountryView(countryId As Object, mode As ModeEnum, tnved As String) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("countryId = {0} AND (modeId = {1} OR modeId = {2}) AND (id IN ({3}) OR goodTnved IS NULL)", _
                                                                 C2.ToInt(countryId), CInt(mode), CInt(ModeEnum.isBoth), GetTnvedId(tnved))}
    End Function

    ''' <summary>
    ''' Возвращает строку ID продукции, соответствующей коду ТН ВЭД
    ''' </summary>
    ''' <param name="tnved">Код ТН ВЭД</param>
    ''' <remarks>Если ничего не найдено, возвращает '0'</remarks>
    Public Function GetTnvedId(tnved As String) As String
        Dim sTmp As String = "0"
        tnved = C2.ToText(tnved)
        If String.IsNullOrWhiteSpace(tnved) Then Return sTmp
        Using V As New DataView(TnvedTable)
            V.RowFilter = String.Format("tnved LIKE '{0}%' OR ('{0}' LIKE tnved + '%')", tnved)
            For Each VRow As DataRowView In V
                sTmp = String.Format("{0}, {1}", sTmp, VRow("goodId"))
            Next
        End Using
        Return sTmp
    End Function

End Class


