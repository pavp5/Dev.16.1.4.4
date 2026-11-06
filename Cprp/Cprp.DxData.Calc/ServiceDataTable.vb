Imports Cprp.DxData.Common
''' <summary>
''' Справочник видов услуг
''' </summary>
Public Class ServiceDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("ServiceTable")
        With Me.Columns
            With .Add("id", GetType(Integer))
                .AllowDBNull = False
            End With
            .Add("parentId", GetType(Integer))
            With .Add("name", GetType(String))
                .AllowDBNull = False
            End With
            .Add("serviceId", GetType(ServiceType))
            With .Add("price", GetType(Single))
                .AllowDBNull = False
                .DefaultValue = 0
            End With
            With .Add("isPrice50", GetType(Boolean))
                .AllowDBNull = False
                .DefaultValue = False
            End With
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        Me.DefaultView.Sort = "id"
    End Sub


    ''' <summary>
    ''' Поиск строки по виду услуги
    ''' </summary>
    ''' <param name="serviceId">ID вида услуги</param>
    Public Function FindRowByServiceId(serviceId As Integer) As DataRow
        For Each Row As DataRow In Me.Rows
            If IsDBNull(Row("serviceId")) Then Continue For
            If CInt(Row("serviceId")) = serviceId Then Return Row
        Next
        Return Nothing
    End Function

    ''' <summary>
    ''' Возвращает полное наименование услуги по виду услуги
    ''' </summary>
    ''' <param name="serviceId">ID вида услуги</param>
    Public Function FullName(serviceId As Integer) As String
        Dim Row As DataRow = FindRowByServiceId(serviceId)
        If Row Is Nothing Then Return Nothing
        Dim sTmp As String = ToText(Row("name"))
        Do
            Row = Me.Rows.Find(ToInt(Row("parentId")))
            If Row Is Nothing Then Exit Do
            sTmp = String.Format("{0} > {1}", ToText(Row("name")), sTmp)
        Loop
        Return sTmp
    End Function

    ''' <summary>
    ''' Возвращает наименование услуги по виду услуги
    ''' </summary>
    ''' <param name="serviceId">ID вида услуги</param>
    Public Function Name(serviceId As Integer) As String
        Dim Row As DataRow = FindRowByServiceId(serviceId)
        If Row Is Nothing Then Return Nothing
        Return ToText(Row("name"))
    End Function

End Class
