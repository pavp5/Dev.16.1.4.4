''' <summary>
''' Таблица запросов
''' </summary>
Public Class RequestDataTable : Inherits DataTable


    Public Sub New()
        MyBase.New("RequestTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("typeId", GetType(Integer))
            .Add("conditionId", GetType(Integer))
            .Add("docId", GetType(Integer))
            .Add("regNum", GetType(String))
            .Add("regDate", GetType(Date))
            .Add("docData", GetType(Byte()))
            .Add("term", GetType(Date))
            .Add("changeDate", GetType(Date))
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        With Me.Columns("conditionId")
            .AllowDBNull = False
            .DefaultValue = CInt(Cprp.DxData.Work.WorkCondition.IsWork)
        End With
        With Me.Columns("regNum")
            .AllowDBNull = False
            .DefaultValue = "проект"
        End With
        With Me.Columns("changeDate")
            .AllowDBNull = False
            .DefaultValue = Date.Now
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub

End Class
