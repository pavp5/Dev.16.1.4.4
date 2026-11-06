''' <summary>
''' Функции для работы с базой данных
''' </summary>
''' <remarks></remarks>
Friend Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        T2CalcToTCalc()
    End Sub

    ''' <summary>
    ''' Перенести данные из таблицы t2Calc в таблицу tCalc
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub T2CalcToTCalc()
        If MsgBox("Перенести данные из t2Calc в tCalc?", MsgBoxStyle.Question + MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then Exit Sub
        Dim TCalc As New DataTable
        Dim Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
        Cmd.CommandText = "SELECT * FROM tCalc WHERE id IS NULL"
        TCalc.Load(Cmd.ExecuteReader)
        TCalc.PrimaryKey = New DataColumn() {TCalc.Columns("id")}
        Cmd.CommandText = "SELECT id, orderNum, deptId, typeId, isAdd, isAgreement, isUrgency, goodCount AS objectDifCount, goodCount AS objectAllCount, countryCount AS workCount, translitCount AS dopMinCount, priceCalc, priceEnd, userId, actDate, comment FROM t2Calc"
        TCalc.Load(Cmd.ExecuteReader)
        For Each Row As DataRow In TCalc.Rows
            Row.SetAdded()
        Next
        Cmd.CommandText = "DELETE FROM tCalc"
        Cmd.ExecuteNonQuery()
        Using A As New SqlDataAdapter("SELECT * FROM tCalc", Program.DbClient.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(TCalc)
        End Using
        MsgBox("OK")
    End Sub

End Class