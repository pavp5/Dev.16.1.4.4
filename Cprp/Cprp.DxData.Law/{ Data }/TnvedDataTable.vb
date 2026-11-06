''' <summary>
''' Таблица кодов ТН ВЭД в нормативных документах
''' </summary>
''' <remarks></remarks>
Public Class TnvedDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("TnvedTable")
        With Me.Columns
            .Add("lawId", GetType(Integer))                 ' id пункта нормативного документа
            .Add("tnved", GetType(String))                  ' код ТН ВЭД
            .Add("is2", GetType(Boolean))                   ' добавлен ЦПРП
        End With
        Me.Columns("lawId").AllowDBNull = False
        Me.Columns("tnved").AllowDBNull = False
        Me.Columns("is2").AllowDBNull = False
        Me.Columns("is2").DefaultValue = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("lawId"), Me.Columns("tnved")}
        Me.DefaultView.Sort = "lawId, tnved"
    End Sub

End Class
