Imports C2 = Cprp.DxData.Common
''' <summary>
''' Связи участников сделки и операции с организациями на контроле
''' </summary>
''' <remarks></remarks>
Public Class MemberControlDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.MemberControlDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        MyBase.New("MemberControlTable")
        With Me.Columns
            .Add("memberId", GetType(Integer))          ' ID лица из MemberTable
            .Add("controlMemberId", GetType(Integer))   ' ID лица на контроле из tMember
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("memberId"), Me.Columns("controlMemberId")}
    End Sub


    ''' <summary>
    ''' Возвращает фирмы на контроле объекта
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
