''' <summary>
''' Словари для проверки орфографии
''' </summary>
''' <remarks></remarks>
Public Class Common

    ''' <summary>
    ''' Общий словарь проверки орфографии
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared OpenOfficeDictionary As OpenOfficeDictionary
    ''' <summary>
    ''' Личный словарь проверки орфографии
    ''' </summary>
    ''' <remarks></remarks>
    Public Shared CustomDictionary As CustomDictionary

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Инициализация словарей
    ''' </summary>
    ''' <param name="dictionaryFolderPath">Путь к папке с файлами словарей</param>
    ''' <remarks>Если в папке нет файлов словарей, они будут созданы средствами классов OpenOfficeDictionary и CustomDictionary</remarks>
    Public Shared Sub LoadDictionary(ByVal dictionaryFolderPath As String)
        OpenOfficeDictionary = New OpenOfficeDictionary(dictionaryFolderPath)
        CustomDictionary = New CustomDictionary(dictionaryFolderPath)
    End Sub

End Class