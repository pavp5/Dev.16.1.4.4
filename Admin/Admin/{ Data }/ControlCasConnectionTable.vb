''' <summary>
''' Номера CAS в нормативных документах
''' </summary>
''' <remarks></remarks>
Friend Class ControlCasConnectionTable : Inherits Cprp.DxData.Base.ConnectionDataTable

    Friend Sub New()
        MyBase.New(Program.DbClient.Connection, "ControlCasTable")
        With Me.Columns
            .Add("lawId", GetType(Integer))
            .Add("cas", GetType(String))
        End With
        Me.Columns("lawId").AllowDBNull = False
        Me.Columns("cas").AllowDBNull = False
        Me.Columns("cas").MaxLength = 50
        Me.PrimaryKey = New DataColumn() {Me.Columns("lawId"), Me.Columns("cas")}
        MyClass.LoadFromBase()
    End Sub

    ''' <summary>
    ''' Загрузить данные из базы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub LoadFromBase()
        Me.Rows.Clear()
        Me.Load("SELECT * FROM tLawCas")
    End Sub

    ' Сохранить данные в базу
    Friend Sub SaveToBase()
        Using A As New SqlDataAdapter("SELECT * FROM tLawCas WHERE lawId IS NULL", MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

End Class
