''' <summary>
''' Коды ТН ВЭД в нормативных документах
''' </summary>
''' <remarks></remarks>
Friend Class ControlTnvedConnectionTable : Inherits Cprp.DxData.Base.ConnectionDataTable

    Friend Sub New()
        MyBase.New(Program.DbClient.Connection, "ControlTnvedTable")
        With Me.Columns
            .Add("lawId", GetType(Integer))
            .Add("tnved", GetType(String))
            .Add("is2", GetType(Boolean))
        End With
        Me.Columns("lawId").AllowDBNull = False
        Me.Columns("tnved").AllowDBNull = False
        Me.Columns("tnved").MaxLength = 14
        Me.Columns("is2").AllowDBNull = False
        Me.Columns("is2").DefaultValue = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("lawId"), Me.Columns("tnved")}
        MyClass.LoadFromBase()
    End Sub

    ''' <summary>
    ''' Загрузить данные из базы
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub LoadFromBase()
        Me.Rows.Clear()
        Me.Load("SELECT * FROM tLawTnved")
    End Sub

    ' Сохранить данные в базу
    Friend Sub SaveToBase()
        Using A As New SqlDataAdapter("SELECT * FROM tLawTnved WHERE lawId IS NULL", MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

End Class
