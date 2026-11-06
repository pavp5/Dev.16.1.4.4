Imports C2 = Cprp.DxData.Common
''' <summary>
''' Связи объектов экспертизы с пунктами приложения к лицензии
''' </summary>
''' <remarks></remarks>
Friend Class GoodAppendDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("GoodAppendTable")
        With Me.Columns
            .Add("goodId", GetType(Integer))
            .Add("appendId", GetType(Integer))
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("goodId"), Me.Columns("appendId")}
    End Sub

    ''' <summary>
    ''' Удалить записи об объекте экспертизы
    ''' </summary>
    ''' <param name="goodId">ID объекта экспертизы</param>
    ''' <remarks></remarks>
    Friend Sub GoodClear(goodId As Object)
        Using V As New DataView(Me)
            V.RowFilter = String.Format("goodId = {0}", C2.ToInt(goodId))
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
    End Sub

End Class
