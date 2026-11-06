''' <summary>
''' Дочерний элемент управления для редактирования данных работы
''' </summary>
Friend Class ChildUserControl : Inherits DevExpress.XtraEditors.XtraUserControl

    ''' <summary>
    ''' Родительский элемент управления
    ''' </summary>
    Protected Property P As WorkUserControl = Nothing

    ''' <summary>
    ''' Тип элемента управления
    ''' </summary>
    Friend Property Content As ContentEnum = ContentEnum.Content

    ''' <summary>
    ''' Загрузить данные в элемент управления
    ''' </summary>
    Friend Overridable Sub DataRead()
        Exit Sub
    End Sub

    ''' <summary>
    ''' Записать данные в источник данных
    ''' </summary>
    Friend Overridable Sub DataWrite()
        Exit Sub
    End Sub


    ''' <summary>
    ''' Данные загружены в элемент управления
    ''' </summary>
    Protected Property IsDataLoaded As Boolean = False

    ''' <summary>
    ''' Установить дату изменения данных равной текущим дате и времени
    ''' </summary>
    Protected Sub SetChangeDateNow()
        If IsDataLoaded Then P.Work.ARow("changeDate") = Date.Now
    End Sub


    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Consultation.ChildUserControl
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub New()
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.Consultation.ChildUserCobtrol
    ''' </summary>
    ''' <param name="ParentControl">Родительский элемент управления</param>
    ''' <remarks></remarks>
    Friend Sub New(ParentControl As WorkUserControl)
        MyClass.P = ParentControl
    End Sub

End Class
