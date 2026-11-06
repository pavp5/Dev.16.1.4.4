Imports C2 = Cprp.DxData.Common
''' <summary>
''' Участники сделки и операции
''' </summary>
''' <remarks></remarks>
Public Class MemberDataTable : Inherits Cprp.DxData.Member.MemberDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Military.MemberDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
        MyBase.New("MemberTable")
        With Me.Columns
            .Add("supRusNum", GetType(Integer))             ' Порядковый номер в списке российских участников операции
        End With
        With Me.Columns("supRusNum")
            .AllowDBNull = False
            .DefaultValue = 1
        End With
    End Sub

End Class
