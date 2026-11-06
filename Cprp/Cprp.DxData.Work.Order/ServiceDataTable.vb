''' <summary>
''' Виды услуг
''' </summary>
Public Class ServiceDataTable : Inherits DataTable


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Order.ServiceDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New("ServiceTable")
        With Me.Columns
            .Add("id", GetType(Integer))            ' ID
            .Add("typeId", GetType(Integer))        ' ID вида работы
            .Add("expertId", GetType(Integer))      ' ID эксперта
            .Add("managerId", GetType(Integer))     ' ID менеджера
            .Add("comment", GetType(String))        ' Указания руководителя
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}
    End Sub


End Class