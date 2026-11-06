Imports C2 = Cprp.DxData.Common
''' <summary>
''' Общие свойства и методы
''' </summary>
''' <remarks></remarks>
Public Class Common

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Поиск лица в базе данных
    ''' </summary>
    ''' <param name="kind">Вид лица</param> 
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="Row">Строка таблицы лиц с предварительными данными для поиска</param>
    ''' <returns>Возвращает таблицу лиц на одну строку</returns>  
    ''' <remarks>Если ничего не найдено, возвращает Nothing</remarks>
    Public Shared Function Find(kind As MemberKind, Connection As SqlConnection, Optional Row As DataRow = Nothing) As MemberDataTable
        With New FindForm(kind, Connection, Row)
            If .ShowDialog = DialogResult.OK Then Return .MemberRow
        End With
        Return Nothing
    End Function

    ''' <summary>
    ''' Обновить сведения в базе данных о руководителе компании
    ''' </summary>
    ''' <param name="inn">ИНН компании</param>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Shared Sub PersonUpdate(inn As String, Connection As SqlConnection)
        inn = C2.ToText(inn, 12)
        If String.IsNullOrWhiteSpace(inn) Then Exit Sub
        If Connection Is Nothing OrElse Connection.State <> ConnectionState.Open Then Exit Sub
        ' Клиент для выполнения http-запросов
        Dim WebClient As System.Net.WebClient = Nothing
        ' Карточка российского лица
        Dim XmlCard As Member.XmlDocumentCard = Nothing
        ' Реквизиты руководителя компании
        Dim post As String = Nothing
        Dim nameLong As String = Nothing
        Try
            Using Cmd As SqlCommand = Connection.CreateCommand
                ' Если в таблице tMemberPerson есть данные о компании не старее полугода, то они не обновляются
                Cmd.CommandText = String.Format("SELECT COUNT(*) FROM tMemberPerson WHERE inn = '{0}' AND actDate > {{ts '{1:yyyy-MM-dd HH:mm:ss}'}}", inn, Date.Today.AddMonths(-6))
                If CInt(Cmd.ExecuteScalar) > 0 Then Exit Sub
                ' Загрузка данных из http-запроса
                WebClient = New System.Net.WebClient
                XmlCard = New Member.XmlDocumentCard(WebClient)
                XmlCard.LoadByInn(inn)
                If XmlCard.LeaderTable.Rows.Count = 0 Then Exit Sub
                Using V As New DataView(XmlCard.LeaderTable)
                    V.RowFilter = "post LIKE '%иректор%'"
                    If V.Count = 0 Then V.RowFilter = "id > 0"
                    If V.Count = 0 Then Exit Sub
                    post = C2.ToText(V(0)("post"))
                    nameLong = C2.ToText(V(0)("nameLong"))
                    If String.IsNullOrWhiteSpace(post) OrElse String.IsNullOrWhiteSpace(nameLong) Then Exit Sub
                End Using
                ' Запись данных в базу
                Cmd.CommandText = String.Format("DELETE FROM tMemberPerson WHERE inn = '{0}'", inn)
                Cmd.ExecuteNonQuery()
                Cmd.CommandText = String.Format("INSERT tMemberPerson(inn, post, nameLong) VALUES ('{0}', '{1}', '{2}')", inn, post, nameLong)
                Cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            Throw ex
        Finally
            If Not WebClient Is Nothing Then WebClient.Dispose()
        End Try

    End Sub

End Class
