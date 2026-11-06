''' <summary>
''' Связи пунктов нормативных документов
''' </summary>
''' <remarks></remarks>
Friend Class ControlLinkConnectionTable : Inherits Cprp.DxData.Base.ConnectionDataTable

    Friend Sub New()
        MyBase.New(Program.DbClient.Connection, "ControlLinkTable")
        With Me.Columns
            .Add("lawId", GetType(Integer))
            .Add("linkId", GetType(Integer))
            .Add("linkDescription", GetType(String))
        End With
        Me.Columns("lawId").AllowDBNull = False
        Me.Columns("linkId").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("lawId"), Me.Columns("linkId")}
        MyClass.LoadFromBase()
    End Sub

    ''' <summary>
    ''' Загрузить данные из базы
    ''' </summary>
    Friend Sub LoadFromBase()
        Me.Rows.Clear()
        Me.Load("SELECT lawId, linkId, linkDescription FROM vLawLink")
    End Sub

    ''' <summary>
    ''' Сохранить данные в базу
    ''' </summary>
    Friend Sub SaveToBase()
        Using A As New SqlDataAdapter("SELECT * FROM tLawLink WHERE lawId IS NULL", MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

End Class
