''' <summary>
''' Таблица рассмотренных заявок, выполненных или закрытых работ
''' </summary>
Friend Class WorkDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New()
        With Me.Columns
            .Add("id", GetType(Integer))        ' ID работы
            .Add("workDate", GetType(Date))     ' Дата поступления или рассмотрения заявки, утверждения или закрытия работы
        End With

    End Sub

End Class
