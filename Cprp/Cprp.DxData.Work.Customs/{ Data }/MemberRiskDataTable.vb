Imports C2 = Cprp.DxData.Common
''' <summary>
''' Признаки риска участников сделки и операции
''' </summary>
''' <remarks></remarks>
Public Class MemberRiskDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Customs.MemberRiskDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New("MemberRiskTable")
        With Me.Columns
            .Add("memberId", GetType(Integer))  ' ID объекта из MemberTable
            .Add("riskId", GetType(Integer))    ' ID риска из RiskHandbookTable
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("memberId"), Me.Columns("riskId")}
    End Sub

    ''' <summary>
    ''' Возвращает перечень рисков объекта
    ''' </summary>
    ''' <param name="memberId">ID объекта</param>
    ''' <remarks></remarks>
    Friend Function MemberView(memberId As Object) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("memberId = {0}", C2.ToInt(memberId))}
    End Function

    ''' <summary>
    ''' Возвращает перечень рисков объекта по определенным видам рисков
    ''' </summary>
    ''' <param name="memberId">ID объекта</param>
    ''' <param name="strRiskId">Строка ID рисков</param> 
    ''' <remarks></remarks>
    Friend Function MemberView(memberId As Object, strRiskId As String) As DataView
        strRiskId = C2.ToStrNum(strRiskId, False)
        If Not C2.IsText(strRiskId) Then Return MyClass.MemberView(memberId)
        Return New DataView(Me) With {.RowFilter = String.Format("memberId = {0} AND riskId IN ({1})", C2.ToInt(memberId), strRiskId)}
    End Function

    ''' <summary>
    ''' Удалить все записи об объекте
    ''' </summary>
    ''' <param name="memberId">ID объекта</param>
    ''' <remarks></remarks>
    Friend Sub DeleteMember(memberId As Object)
        Me.AcceptChanges()
        Using V As DataView = MyClass.MemberView(memberId)
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        Me.AcceptChanges()
    End Sub

    ''' <summary>
    ''' Удалить все записи об объекте по определенным видам рисков
    ''' </summary>
    ''' <param name="memberId">ID объекта</param>
    ''' <param name="strRiskId">Строка ID рисков</param> 
    ''' <remarks></remarks>
    Friend Sub DeleteMember(memberId As Object, strRiskId As String)
        Me.AcceptChanges()
        Using V As DataView = MyClass.MemberView(memberId, strRiskId)
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        Me.AcceptChanges()
    End Sub

End Class
