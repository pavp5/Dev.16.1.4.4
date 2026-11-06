''' <summary>
''' Признаки риска по внешнеэкономической операции
''' </summary>
''' <remarks></remarks>
Public Class SupplyRiskDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Excont.SupplyRiskDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        MyBase.New("SupplyRiskTable")
        Me.Columns.Add("riskId", GetType(Integer))  ' ID риска из tRisk
        Me.PrimaryKey = New DataColumn() {Me.Columns("riskId")}
    End Sub

End Class
