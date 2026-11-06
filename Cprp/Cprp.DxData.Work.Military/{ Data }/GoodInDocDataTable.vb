Imports C2 = Cprp.DxData.Common
''' <summary>
''' Связи объектов экспертизы с документами, подтверждающими гражданское назначение
''' </summary>
Friend Class GoodInDocDataTable : Inherits Cprp.DxData.Base.BaseDataTable


    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("GoodInDocTable")
        With Me.Columns
            .Add("goodId", GetType(Integer))                ' ID объекта экспертизы из GoodTable
            .Add("docId", GetType(Integer))                 ' ID документа из InDocTable
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("goodId"), Me.Columns("docId")}
    End Sub


    ''' <summary>
    ''' Возвращает документы объекта
    ''' </summary>
    ''' <param name="goodId">ID объекта</param>
    Friend Function GoodView(goodId As Object) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("goodId = {0}", C2.ToInt(goodId))}
    End Function

    ''' <summary>
    ''' Удалить все записи об объекте
    ''' </summary>
    ''' <param name="goodId">ID объекта</param>
    Friend Sub DeleteGood(goodId As Object)
        Me.AcceptChanges()
        Using V As New DataView(Me)
            V.RowFilter = String.Format("goodId = {0}", C2.ToInt(goodId))
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        Me.AcceptChanges()
    End Sub

End Class
