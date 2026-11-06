''' <summary>
''' Таблица связей пунктов нормативных документов
''' </summary>
''' <remarks></remarks>
Public Class LinkDataTable : Inherits DataTable

    Friend Sub New()
        MyBase.New("LinkTable")
        With Me.Columns
            .Add("lawId", GetType(Integer))         ' ID пункта нормативного документа
            .Add("linkId", GetType(Integer))        ' ID связанного пункта
            .Add("linkCaption", GetType(String))    ' заголовок связи (номер связанного пункта, "б/н" для примечания)
        End With
    End Sub

End Class

