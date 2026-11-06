''' <summary>
''' Заголовки контрольных списков
''' </summary>
Public Class LawCaptionDataTable : Inherits DataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Handbook.LawCaptionDataTable
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal Connection As SqlConnection)
        MyBase.New()
        Using Cmd As New SqlCommand With {.Connection = Connection}
            Cmd.CommandText = "SELECT id, guid, doc, caption, codeLetter, codeDec, isACT, codeDecLetter FROM vLawCaption WHERE isACT = 1 ORDER BY codeDec"
            Me.Load(Cmd.ExecuteReader)
        End Using
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class