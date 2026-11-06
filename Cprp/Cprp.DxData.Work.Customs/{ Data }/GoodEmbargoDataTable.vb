Imports C2 = Cprp.DxData.Common
''' <summary>
''' Запреты и ограничения в отношении продукции
''' </summary>
''' <remarks></remarks>
Friend Class GoodEmbargoDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Customs.GoodEmbargoDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        MyBase.New("GoodEmbargoTable")
        With Me.Columns
            .Add("goodId", GetType(Integer))                ' ID продукции из GoodTable
            .Add("embargoGoodId", GetType(Integer))         ' ID продукции из tEmbargoGood
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("goodId"), Me.Columns("embargoGoodId")}
    End Sub

    ''' <summary>
    ''' Возвращает перечень запретов и ограничений объекта
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
