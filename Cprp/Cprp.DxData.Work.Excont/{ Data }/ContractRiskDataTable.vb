''' <summary>
''' Признаки риска по внешнеэкономической сделке
''' </summary>
''' <remarks></remarks>
Public Class ContractRiskDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.ContractRiskDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        MyBase.New("ContractRiskTable")
        Me.Columns.Add("riskId", GetType(Integer))  ' ID риска из tRisk
        Me.PrimaryKey = New DataColumn() {Me.Columns("riskId")}
    End Sub

End Class
