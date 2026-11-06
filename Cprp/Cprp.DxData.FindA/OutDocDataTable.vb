''' <summary>
''' Таблица заключений (результаты поиска)
''' </summary>
Friend Class OutDocDataTable : Inherits DataTable

    ''' <summary>
    ''' Шаблон запроса на выборку данных
    ''' </summary>
    Friend Const SELECT_QUERY_STRING As String = _
        "SELECT id, workId, description, typeName, kindName, expertName, leaderName, managerName, " & _
        "clientName, clientAddress, clientInn, clientKpp, clientPhone, clientFax, " & _
        "orderNum, orderDate, orderUrl, countryName, rusName, rusAddress, rusInn, rusKpp, " & _
        "nusName, nusCountry, nusAddress, endName, endCountry, endAddress, " & _
        "contractName, contractNum, contractDate, docId, docNum, docDate, docSummaryId, docSummaryName " & _
        "FROM vWorkData"


    Friend Sub New()
        MyBase.New("OutDocTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("workId", GetType(Integer))
            .Add("description", GetType(String))
            .Add("typeName", GetType(String))
            .Add("kindName", GetType(String))
            .Add("expertName", GetType(String))
            .Add("leaderName", GetType(String))
            .Add("managerName", GetType(String))
            .Add("clientName", GetType(String))
            .Add("clientAddress", GetType(String))
            .Add("clientInn", GetType(String))
            .Add("clientKpp", GetType(String))
            .Add("clientPhone", GetType(String))
            .Add("clientFax", GetType(String))
            .Add("orderNum", GetType(String))
            .Add("orderDate", GetType(Date))
            .Add("orderUrl", GetType(String))
            .Add("countryName", GetType(String))
            .Add("rusName", GetType(String))
            .Add("rusAddress", GetType(String))
            .Add("rusInn", GetType(String))
            .Add("rusKpp", GetType(String))
            .Add("nusName", GetType(String))
            .Add("nusCountry", GetType(String))
            .Add("nusAddress", GetType(String))
            .Add("endName", GetType(String))
            .Add("endCountry", GetType(String))
            .Add("endAddress", GetType(String))
            .Add("contractName", GetType(String))
            .Add("contractNum", GetType(String))
            .Add("contractDate", GetType(Date))
            .Add("docId", GetType(Integer))
            .Add("docNum", GetType(String))
            .Add("docDate", GetType(Date))
            .Add("docSummaryId", GetType(Integer))
            .Add("docSummaryName", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("docId")}
    End Sub

End Class
