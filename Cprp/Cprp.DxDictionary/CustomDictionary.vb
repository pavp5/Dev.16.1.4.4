''' <summary>
''' Личный орфографический словарь
''' </summary>
''' <remarks></remarks>
Public Class CustomDictionary : Inherits DevExpress.XtraSpellChecker.SpellCheckerCustomDictionary

    ''' <summary>
    ''' Инициализирует новый экземпляр класса Cprp.Dictionary.CustomDictionary
    ''' </summary>
    ''' <param name="dictionaryFolderPath">Путь к папке с файлом словаря</param>
    ''' <remarks>Если в указанной папке нет файла словаря, то он создается в этой папке из файла ресурсов</remarks>
    Public Sub New(ByVal dictionaryFolderPath As String)
        MyBase.New()
        With My.Computer.FileSystem
            '
            ' Проверка существания папки со словарем
            '
            dictionaryFolderPath = Trim(dictionaryFolderPath)
            If String.IsNullOrEmpty(dictionaryFolderPath) Then Exit Sub
            If Not .DirectoryExists(dictionaryFolderPath) Then Exit Sub
            '
            ' Файл со словарем "ru_сustom"
            '
            If Not IO.File.Exists(dictionaryFolderPath & "\ru_custom") Then
                .WriteAllBytes(dictionaryFolderPath & "\ru_custom", My.Resources.ru_custom, False)
            End If
            '
            ' Настройка словаря
            '
            Me.Culture = New System.Globalization.CultureInfo("ru-RU")
            Me.DictionaryPath = dictionaryFolderPath & "\ru_custom"
            Me.Load()
        End With
    End Sub

End Class