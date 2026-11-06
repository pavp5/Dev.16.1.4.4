Imports C2 = Cprp.DxData.Common
''' <summary>
''' Справочник запретов и ограничений в отношении стран
''' </summary>
''' <remarks></remarks>
Public Class CountryDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
        With Me.Columns
            .Add("countryId", GetType(Integer))         ' ID страны
            .Add("embargoId", GetType(Integer))         ' ID эмбарго
            .Add("embargoCaption", GetType(String))     ' Наименование и реквизиты документа, устанавливающего эмбарго
            .Add("embargoCaption2", GetType(String))    ' Реквизиты и наименование документа, устанавливающего эмбарго
            .Add("modeId", GetType(Integer))            ' Направление перемещения (ModeEnum)
            .Add("isLimited", GetType(Boolean))         ' ДСП (да/нет)
            .Add("isCheck", GetType(Boolean))           ' Отмечена (да/нет)
        End With
        Me.Columns("countryId").AllowDBNull = False
        Me.Columns("embargoId").AllowDBNull = False
        Me.Columns("embargoCaption").AllowDBNull = False
        Me.Columns("embargoCaption2").AllowDBNull = False
        Me.Columns("modeId").AllowDBNull = False
        Me.Columns("isLimited").AllowDBNull = False
        With Me.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("countryId"), Me.Columns("embargoId")}
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
            Cmd.CommandText = "SELECT countryId, embargoId, embargoCaption, embargoCaption2, modeId, isLimited, isACT FROM vEmbargoCountryData WHERE isACT = 1"
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
    ''' Представление запретов и ограничений по опеределенной стране
    ''' </summary>
    ''' <param name="countryId">ID страны</param>
    ''' <remarks></remarks>
    Public Function CountryView(countryId As Object) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("countryId = {0}", C2.ToInt(countryId))}
    End Function

End Class

