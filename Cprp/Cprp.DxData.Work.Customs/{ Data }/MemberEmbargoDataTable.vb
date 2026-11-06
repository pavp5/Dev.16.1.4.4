Imports C2 = Cprp.DxData.Common
''' <summary>
''' Запреты и ограничения в отношении участников сделки и операции
''' </summary>
''' <remarks></remarks>
Friend Class MemberEmbargoDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Customs.MemberEmbargoDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        MyBase.New("MemberEmbargoTable")
        With Me.Columns
            .Add("memberId", GetType(Integer))          ' ID лица из MemberTable
            .Add("embargoMemberId", GetType(Integer))   ' ID лица из tEmbargoMember
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("memberId"), Me.Columns("embargoMemberId")}
    End Sub

    ''' <summary>
    ''' Возвращает перечень запретов и ограничений объекта
    ''' </summary>
    ''' <param name="memberId">ID объекта</param>
    ''' <remarks></remarks>
    Friend Function MemberView(memberId As Object) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("memberId = {0}", C2.ToInt(memberId))}
    End Function

    ''' <summary>
    ''' Удалить все записи об объекте
    ''' </summary>
    ''' <param name="memberId">ID объекта</param>
    ''' <remarks></remarks>
    Friend Sub DeleteMember(memberId As Object)
        Me.AcceptChanges()
        Using V As New DataView(Me)
            V.RowFilter = String.Format("memberId = {0}", C2.ToInt(memberId))
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        Me.AcceptChanges()
    End Sub

End Class