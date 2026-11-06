Imports C2 = Cprp.DxData.Common
''' <summary>
''' Связи продукции (объектов экспертизы) с продукцией на контроле
''' </summary>
''' <remarks></remarks>
Friend Class GoodControlDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Customs.GoodControlDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        MyBase.New("GoodControlTable")
        With Me.Columns
            .Add("goodId", GetType(Integer))                ' ID объекта из GoodTable
            .Add("controlGoodId", GetType(Integer))         ' ID объекта на контроле из tGood
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("goodId"), Me.Columns("controlGoodId")}
    End Sub

    ''' <summary>
    ''' Возвращает перечень продукции на контроле объекта
    ''' </summary>
    ''' <param name="goodId">ID объекта</param>
    ''' <remarks></remarks>
    Friend Function GoodView(goodId As Object) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("goodId = {0}", C2.ToInt(goodId))}
    End Function

    ''' <summary>
    ''' Удалить все записи об объекте
    ''' </summary>
    ''' <param name="goodId">ID объекта</param>
    ''' <remarks></remarks>
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

