''' <summary>
''' Таблица отчета по принятым и рассмотренным заявкам, выполненным и закрытым работам
''' </summary>
Friend Class ReportDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("ReportTable")
        With Me.Columns
            .Add("reportDate", GetType(Date))                   ' Отчетная дата
            .Add("orderCount", GetType(Integer))                ' Количество поступившиших заявок на оказание услуг
            .Add("orderCloseCount", GetType(Integer))           ' Количество рассмотренных заявок на оказание услуг
            .Add("workAcceptCount", GetType(Integer))           ' Количество утвержденных работ
            .Add("workCloseCount", GetType(Integer))            ' Количество закрытых работ
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("reportDate")}
    End Sub



End Class
