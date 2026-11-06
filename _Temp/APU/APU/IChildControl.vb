''' <summary>
''' Общие свойства и методы дочерних элементов управления
''' </summary>
Friend Interface IChildControl

    ''' <summary>
    ''' Закрыть все активные редакторы
    ''' </summary>
    Sub CloseEDitor()

    ''' <summary>
    ''' Заблокировать элемент управления перед загрузкой данных
    ''' </summary>
    Sub BeginDataUpdate()

    ''' <summary>
    ''' Разблокировать элемент управления после загрузки данных
    ''' </summary>
    Sub EndDataUpdate()


End Interface
