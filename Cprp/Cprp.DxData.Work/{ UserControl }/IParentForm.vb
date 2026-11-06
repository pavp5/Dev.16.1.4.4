''' <summary>
''' Свойства и методы главного элемента управления
''' </summary>
''' <remarks></remarks>
Public Interface IParentForm

    ''' <summary>
    ''' Обработать событие утверждения плана работы
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Sub WorkPlaneAccept(workId As Object)

    ''' <summary>
    ''' Запустить процедуру перевода работы в состояние запроса
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Sub WorkQueryRun(workId As Object)

    ''' <summary>
    ''' Открыть дочерний элемент с работой
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Function ChildOpen(workId As Object) As Boolean

    ''' <summary>
    ''' Закрыть дочерний элемент с работой
    ''' </summary>
    ''' <param name="workId">ID работы</param>
    Sub ChildClose(workId As Object)

End Interface
