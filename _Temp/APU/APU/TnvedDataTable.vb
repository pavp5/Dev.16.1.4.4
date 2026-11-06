''' <summary>
''' Таблица кодов ТН ВЭД из контрольных списков
''' </summary>
Friend Class TnvedDataTable : Inherits DataTable


    Friend Sub New()
        MyBase.New("TnvedTable")
        With Me.Columns
            .Add("code", GetType(String))
            .Add("description", GetType(String))
            .Add("codeDescription", GetType(String))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("code")}
    End Sub

End Class
