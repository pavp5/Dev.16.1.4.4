Imports C2 = Cprp.DxData.Common
''' <summary>
''' Исследования объектов экспертизы
''' </summary>
''' <remarks></remarks>
Public Class GoodLawDataTable : Inherits Cprp.DxData.Base.BaseDataTable

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Customs.GoodLawDataTable
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        MyBase.New("GoodLawTable")
        With Me.Columns
            .Add("goodId", GetType(Integer))                ' ID объекта экспертизы        
            .Add("lawId", GetType(Integer))                 ' ID пункта контрольного списка
            .Add("lawDescription", GetType(String))         ' переработанное описание пункта контрольного списка
            .Add("goodDescription", GetType(String))        ' технические характеристики объекта экспертизы для сравнения с пунктом
            .Add("isFindTnved", GetType(Boolean))           ' найдена по коду ТН ВЭД
            .Add("isFindCAS", GetType(Boolean))             ' найдена по номеру CAS
            .Add("isFindWord", GetType(Boolean))            ' найдена по ключевым словам
            .Add("summaryId", GetType(Integer))             ' идентификатор контрольного статуса пункта (0 - не выбран для сравнения, 1 - выбран для сравнения, 2 - соответствует)
        End With
        With Me.Columns("isFindTnved")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isFindCas")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("isFindWord")
            .AllowDBNull = False
            .DefaultValue = False
        End With
        With Me.Columns("summaryId")
            .AllowDBNull = False
            .DefaultValue = Cprp.DxData.Law.StudyIndexEnum.IsNothing        ' отсутствует в контрольных списках
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("goodId"), Me.Columns("lawId")}
    End Sub

    ''' <summary>
    ''' Возвращает перечень пунктов контрольных списков объекта
    ''' </summary>
    ''' <param name="goodId">ID объекта</param>
    ''' <remarks></remarks>
    Friend Function GoodView(goodId As Object) As DataView
        Return New DataView(Me) With {.RowFilter = String.Format("goodId = {0}", C2.ToInt(goodId))}
    End Function

    ''' <summary>
    ''' Удалить все записи об объекте
    ''' </summary>
    ''' <param name="goodId">ID объекта</param>
    ''' <remarks></remarks>
    Friend Sub DeleteGood(goodId As Object)
        Me.AcceptChanges()
        Using V As New DataView(Me)
            V.RowFilter = String.Format("goodId = {0}", C2.ToInt(goodId))
            While V.Count > 0
                V(0).Delete()
            End While
        End Using
        Me.AcceptChanges()
    End Sub

    ''' <summary>
    ''' Возвращает максимальный индекс сравнительного анализа объекта
    ''' </summary>
    ''' <param name="goodId">ID объекта</param>
    ''' <remarks></remarks>
    Friend Function MaxSummary(goodId As Object) As Cprp.DxData.Law.StudyIndexEnum
        Using V As New DataView(Me)
            V.RowFilter = String.Format("goodId = {0} AND summaryId = {1}", C2.ToInt(goodId), CInt(Cprp.DxData.Law.StudyIndexEnum.IsEqual))
            If V.Count > 0 Then Return Cprp.DxData.Law.StudyIndexEnum.IsEqual
            V.RowFilter = String.Format("goodId = {0} AND summaryId = {1}", C2.ToInt(goodId), CInt(Cprp.DxData.Law.StudyIndexEnum.IsOther))
            If V.Count > 0 Then Return Cprp.DxData.Law.StudyIndexEnum.IsOther
        End Using
        Return Cprp.DxData.Law.StudyIndexEnum.IsNothing
    End Function

End Class
