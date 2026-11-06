Imports C2 = Cprp.DxData.Common
''' <summary>
''' Справочник фирм на контроле
''' </summary>
''' <remarks></remarks>
Public Class ControlMemberDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))            ' ID лица
            .Add("caption", GetType(String))        ' Наименование
            .Add("description", GetType(String))    ' Дополнительная информация
            .Add("countryId", GetType(Integer))     ' Страна (ID)
            .Add("isCheck", GetType(Boolean))       ' Отмечена (да/нет)
        End With
        With Me.Columns("isCheck")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
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
            Cmd.CommandText = "SELECT id, caption, (description + ' ' + ISNULL(embargoName, '')) AS description, countryId FROM tMemberBlack"
            Me.Load(Cmd.ExecuteReader)
            Cmd.CommandText = "SELECT id, memberCaption AS caption, (ISNULL(memberDescription + CHAR(13) + CHAR(10), '') + ISNULL(embargoCaption2, '')) AS description, countryId FROM vEmbargoMemberData WHERE isLimited = 1 AND isACT = 1"
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
    ''' Представление фирм на контроле по опеределенной стране
    ''' </summary>
    ''' <param name="countryId">ID страны</param>
    ''' <remarks></remarks>
    Public Function CountryView(countryId As Object) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("countryId = {0}", C2.ToInt(countryId))}
    End Function

End Class