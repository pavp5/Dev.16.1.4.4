''' <summary>
''' Таблица номеров CAS в нормативных документах
''' </summary>
''' <remarks></remarks>
Public Class CasDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("CasTable")
        With Me.Columns
            .Add("lawId", GetType(Integer))                 ' id пункта нормативного документа
            .Add("cas", GetType(String))                    ' номер CAS
        End With
        Me.Columns("lawId").AllowDBNull = False
        Me.Columns("cas").AllowDBNull = False
        Me.PrimaryKey = New DataColumn() {Me.Columns("lawId"), Me.Columns("cas")}
        Me.DefaultView.Sort = "lawId, cas"
    End Sub

End Class

