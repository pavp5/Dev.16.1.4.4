Imports Cprp.DxData.Common
''' <summary>
''' Источник данных заказчиков и работ
''' </summary>
Friend Class ReportDataSet : Inherits DataSet

    ''' <summary>
    ''' Таблица заказчиков
    ''' </summary>
    Friend ClientTable As ClientDataTable = Nothing

    ''' <summary>
    ''' Таблица работ
    ''' </summary>
    Friend WorkTable As WorkDataTable = Nothing


    Friend Sub New()
        MyBase.New("ReportData")
        ClientTable = New ClientDataTable
        WorkTable = New WorkDataTable
        Me.Tables.AddRange(New DataTable() {WorkTable, ClientTable})
        Dim Relation As New DataRelation("ClientWorkRelation", ClientTable.Columns("id"), WorkTable.Columns("clientId"))
        Me.Relations.Add(Relation)
        Relation.ChildKeyConstraint.UpdateRule = Rule.Cascade
        Relation.ChildKeyConstraint.DeleteRule = Rule.Cascade
    End Sub

    ''' <summary>
    ''' Загрузить данные за период
    ''' </summary>
    ''' <param name="Connection">Открытое подключение к базе данных EXDB8</param>
    ''' <param name="dateB">Дата начала отчетного периода</param>
    ''' <param name="dateE">Дата конца отчетного периода</param>
    Friend Sub DataReload(Connection As SqlConnection, dateB As Date, dateE As Date)
        WorkTable.Rows.Clear()
        ClientTable.Rows.Clear()
        Using Cmd As SqlCommand = Connection.CreateCommand
            Using T As New DataTable
                '
                ' Загрузка данных по всем работа во временную таблицу
                '
                Cmd.CommandText = String.Format( _
                    "SELECT id, typeName, orderNum, orderDate, clientName, clientInn, clientAddress FROM vWorkData " & _
                    "WHERE typeId <> 99 AND typeId <> 117 AND orderDate>= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND orderDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                    dateB, dateE.AddDays(1))
                T.Load(Cmd.ExecuteReader)
                '
                ' Загрузка данных в таблицы источника данных
                '
                Dim clientInn As String = Nothing
                Dim clientId As Integer = 1
                Dim isNew As Boolean = False
                Using V As New DataView(T) With {.Sort = "clientInn"}
                    For i As Integer = 0 To V.Count - 1
                        clientInn = ToText(V(i)("clientInn"))
                        If i > 0 AndAlso clientInn = ToText(V(i - 1)("clientInn")) Then Continue For
                        Cmd.CommandText = String.Format( _
                            "SELECT COUNT(*) FROM tWork WHERE typeId <> 99 AND typeId <> 117 AND clientInn = '{0}' AND orderDate < {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", _
                            clientInn, dateB)
                        isNew = CInt(Cmd.ExecuteScalar) = 0
                        ClientTable.Rows.Add(New Object() {clientId, V(i)("clientName"), V(i)("clientInn"), V(i)("clientAddress"), isNew})
                        For j As Integer = i To V.Count - 1
                            If clientInn <> V(j)("clientInn").ToString Then Exit For
                            WorkTable.Rows.Add(New Object() {V(j)("id"), clientId, V(j)("orderNum"), V(j)("orderDate"), V(j)("typeName")})
                        Next
                        clientId += 1
                    Next
                End Using

            End Using
        End Using
    End Sub


End Class
