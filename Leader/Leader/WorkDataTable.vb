''' <summary>
''' Таблица работ базы данных
''' </summary>
Friend Class WorkDataTable : Inherits Cprp.DxData.Base.ConnectionDataTable

    ''' <summary>
    ''' Строка запроса на выборку данных
    ''' </summary>
    Friend ReadOnly Property SelectQuery As String
        Get
            Return _
                "SELECT id, guid, typeId, kindId, conditionId, expertId, managerId, leaderId, " & _
                "expertTerm, orderId, orderNum, orderDate, orderTerm, orderUrl, taskId, taskUrl, " & _
                "clientName, clientAddress, clientInn, clientKpp, clientPhone, clientFax, description, " & _
                "countryName, isPayment, isPrice, goodCount, goodAllCount, percentCount, " & _
                "createDate, acceptDate, closeDate, expertStartTerm, workIssueDate, totalWork, extraWork, " & _
                "ballCalc, ballFact, xmlData, comment FROM tWork"
        End Get
    End Property


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Friend Sub New(Connection As SqlConnection)
        MyBase.New(Connection)
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("dbId", GetType(Integer))
            .Add("guid", GetType(String))
            .Add("typeId", GetType(Integer))
            .Add("kindId", GetType(Integer))
            .Add("conditionId", GetType(Integer))
            .Add("expertId", GetType(Integer))
            .Add("managerId", GetType(Integer))
            .Add("leaderId", GetType(Integer))
            .Add("expertTerm", GetType(Date))
            .Add("orderId", GetType(Integer))
            .Add("orderNum", GetType(String))
            .Add("orderDate", GetType(Date))
            .Add("orderTerm", GetType(Date))
            .Add("orderUrl", GetType(String))
            .Add("taskId", GetType(Integer))
            .Add("taskUrl", GetType(String))
            .Add("clientName", GetType(String))
            .Add("clientAddress", GetType(String))
            .Add("clientInn", GetType(String))
            .Add("clientKpp", GetType(String))
            .Add("clientPhone", GetType(String))
            .Add("clientFax", GetType(String))
            .Add("description", GetType(String))
            .Add("countryName", GetType(String))
            .Add("isPayment", GetType(Boolean))
            .Add("isPrice", GetType(Boolean))
            .Add("goodCount", GetType(Integer))
            .Add("goodAllCount", GetType(Integer))
            .Add("percentCount", GetType(Integer))
            .Add("createDate", GetType(Date))
            .Add("acceptDate", GetType(Date))
            .Add("closeDate", GetType(Date))
            .Add("expertStartTerm", GetType(Date))
            .Add("workIssueDate", GetType(Date))
            .Add("totalWork", GetType(Integer))
            .Add("extraWork", GetType(Integer))
            .Add("ballCalc", GetType(Single))
            .Add("ballFact", GetType(Single))
            .Add("xmlData", GetType(String))
            .Add("comment", GetType(String))
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("guid")
            .AllowDBNull = False
            .MaxLength = 50
        End With
        With Me.Columns("typeId")
            .AllowDBNull = False
            .DefaultValue = 1
        End With
        With Me.Columns("kindId")
            .AllowDBNull = False
            .DefaultValue = 1
        End With
        With Me.Columns("conditionId")
            .AllowDBNull = False
            .DefaultValue = 1
        End With
        With Me.Columns("leaderId")
            .AllowDBNull = False
            .DefaultValue = 28
        End With
        Me.Columns("orderNum").MaxLength = 50
        Me.Columns("orderUrl").MaxLength = 1000
        Me.Columns("taskUrl").MaxLength = 1000
        Me.Columns("clientName").MaxLength = 500
        Me.Columns("clientAddress").MaxLength = 500
        Me.Columns("clientInn").MaxLength = 20
        Me.Columns("clientKpp").MaxLength = 20
        Me.Columns("clientPhone").MaxLength = 250
        Me.Columns("clientFax").MaxLength = 250
        Me.Columns("description").MaxLength = 250
        Me.Columns("countryName").MaxLength = 150
        With Me.Columns("isPayment")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isPrice")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("percentCount")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("ballCalc")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        With Me.Columns("ballFact")
            .AllowDBNull = False
            .DefaultValue = 0
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


    ''' <summary>
    ''' Сохранить данные в базу
    ''' </summary>
    Friend Sub SaveToBase()
        Using A As New SqlDataAdapter(MyClass.SelectQuery, MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

End Class