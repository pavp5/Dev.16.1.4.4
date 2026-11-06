''' <summary>
''' Форма для перегрузки данных из tLaw, tLawTnved в tEmbargoGood, tEmbargoGoodTnved
''' </summary>
Friend Class Form2

    ''' <summary>
    ''' tEmbargoGood
    ''' </summary>
    Private Class GoodDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New("GoodTable")
            With Me.Columns
                .Add("id", GetType(Integer))
                .Add("embargoId", GetType(Integer))
                .Add("caption", GetType(String))
                .Add("tnved", GetType(String))
                .Add("modeId", GetType(Integer))
                .Add("isACT", GetType(Boolean))
                .Add("lawId", GetType(Integer))             ' ID строки в tLaw
            End With
            Me.Columns("id").AllowDBNull = False
            Me.Columns("embargoId").AllowDBNull = False
            Me.Columns("caption").AllowDBNull = False
            Me.Columns("modeId").AllowDBNull = False
            Me.Columns("isACT").AllowDBNull = False
            Me.Columns("lawId").AllowDBNull = False
            Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
        End Sub
    End Class

    ''' <summary>
    ''' tEmbargoGoodTnved, tEmbargoGoodTnvedNot
    ''' </summary>
    Private Class GoodTnvedDataTable : Inherits DataTable
        Friend Sub New()
            MyBase.New("GoodTnvedTable")
            With Me.Columns
                .Add("goodId", GetType(Integer))
                .Add("tnved", GetType(String))
            End With
            Me.Columns("goodId").AllowDBNull = False
            Me.Columns("tnved").AllowDBNull = False
            Me.PrimaryKey = New DataColumn() {Me.Columns("goodId"), Me.Columns("tnved")}
        End Sub
    End Class



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        'UpdateEmbargoGoodTnvedNot()
        'Exit Sub

        If MsgBox("Перегрузить данные из tLaw, tLawTnved в tEmbargoGood, tEmbargoGoodTnved?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

        Dim embargoId As Integer = 39   ' embargoId
        Dim minId As Integer = 22220    ' ID первого товара в tLaw
        Dim maxId As Integer = 22273    ' ID последнего товара в tLaw

        Dim GoodTable As New GoodDataTable
        Dim GoodTnvedTable As New GoodTnvedDataTable
        Dim startId As Integer = 1

        Using Cmd As SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = String.Format("DELETE FROM tEmbargoGood WHERE embargoId = {0} and id > 7261", embargoId)
            Cmd.ExecuteNonQuery()

            Cmd.CommandText = "SELECT ISNULL(MAX(id), 0) FROM tEmbargoGood"
            startId = CInt(Cmd.ExecuteScalar) + 1

            Cmd.CommandText = String.Format("SELECT id, description, tnved, modeId FROM tLaw WHERE typeId = 1 AND id >= {0} AND id <= {1} ORDER BY sortId, doc, id", minId, maxId)
            Using Dr As SqlDataReader = Cmd.ExecuteReader
                While Dr.Read
                    If IsDBNull(Dr("tnved")) Then Continue While
                    GoodTable.Rows.Add(New Object() _
                                        {startId, embargoId, Dr("description"), Dr("tnved"), Dr("modeId"), True, Dr("id")})
                    startId += 1
                End While
            End Using

            For Each Row As DataRow In GoodTable.Rows
                Cmd.CommandText = String.Format("SELECT tnved FROM tLawTnved WHERE is2 = 0 AND lawId = {0}", CInt(Row("lawId")))
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    While Dr.Read
                        GoodTnvedTable.Rows.Add(New Object() {Row("id"), Dr("tnved")})
                    End While
                End Using
            Next
        End Using

        Using A As New SqlDataAdapter("SELECT * FROM tEmbargoGood", Program.DbClient.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(GoodTable)
        End Using
        Using A As New SqlDataAdapter("SELECT * FROM tEmbargoGoodTnved", Program.DbClient.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(GoodTnvedTable)
        End Using

        GoodTable.Dispose()
        GoodTnvedTable.Dispose()

        MsgBox("OK")

    End Sub


    ''' <summary>
    ''' Переписать таблицу tEmbargoGoodTnvedNot по данным из таблицы tEmbargoGood
    ''' </summary>
    Private Sub UpdateEmbargoGoodTnvedNot()
        If MsgBox("Переписать таблицу tEmbargoGoodTnvedNot по данным из таблицы tEmbargoGood?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub

        Dim GoodTable As New GoodDataTable
        Dim GoodTnvedTable As New GoodTnvedDataTable

        Using Cmd As SqlCommand = Program.DbClient.Connection.CreateCommand
            Cmd.CommandText = "DELETE FROM tEmbargoGoodTnvedNot"
            Cmd.ExecuteNonQuery()

            Cmd.CommandText = "SELECT id, embargoId, caption, tnved, modeId, isACT, 0 AS lawId FROM tEmbargoGood WHERE caption LIKE '%(за исключением %)%' AND isACT = 1 AND id > 5000"
            GoodTable.Load(Cmd.ExecuteReader)
        End Using

        Dim sTmp As String = Nothing
        Dim code As String = Nothing
        For Each Row As DataRow In GoodTable.Rows
            code = Nothing
            sTmp = Cprp.DxData.Common.ToText(Row("caption"))
            sTmp = sTmp.Substring(sTmp.IndexOf("(за исключением ") + 15)
            For i As Integer = 0 To sTmp.Length - 1
                If sTmp(i) Like "[0123456789]" Then
                    code &= sTmp(i)
                Else
                    If Not String.IsNullOrWhiteSpace(code) AndAlso code.Length > 4 Then GoodTnvedTable.Rows.Add(New Object() {Row("id"), code})
                    code = Nothing
                End If
                If sTmp(i) = ")" Then Exit For
            Next
        Next

        Using A As New SqlDataAdapter("SELECT * FROM tEmbargoGoodTnvedNot", Program.DbClient.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(GoodTnvedTable)
        End Using

        GoodTable.Dispose()
        GoodTnvedTable.Dispose()

        MsgBox("OK")

    End Sub

End Class