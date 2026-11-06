''' <summary>
''' Общий орфографический словарь
''' </summary>
''' <remarks></remarks>
Public Class OpenOfficeDictionary : Inherits DevExpress.XtraSpellChecker.SpellCheckerOpenOfficeDictionary

    ''' <summary>
    ''' Инициализирует новый экземпляр класса Cprp.Dictionary.OpenOfficeDictionary
    ''' </summary>
    ''' <param name="dictionaryFolderPath">Путь к папке с файлами словарей</param>
    ''' <remarks>Если в указанной папке нет файлов словарей, то они создаются в этой папке из файлов ресурсов</remarks>
    Public Sub New(ByVal dictionaryFolderPath As String)
        MyBase.New()
        With My.Computer.FileSystem
            '
            ' Проверка существания папки со словарями
            '
            dictionaryFolderPath = Trim(dictionaryFolderPath)
            If String.IsNullOrEmpty(dictionaryFolderPath) Then Exit Sub
            If Not .DirectoryExists(dictionaryFolderPath) Then Exit Sub
            '
            ' Файл со словарем "ru_dic"
            '
            If Not IO.File.Exists(dictionaryFolderPath & "\ru_dic") Then
                .WriteAllBytes(dictionaryFolderPath & "\ru_dic", My.Resources.ru_dic, False)
            End If
            '
            ' Файл со словарем "ru_aff"
            '
            If Not IO.File.Exists(dictionaryFolderPath & "\ru_aff") Then
                .WriteAllBytes(dictionaryFolderPath & "\ru_aff", My.Resources.ru_aff, False)
            End If
            '
            ' Настройка словаря
            '
            Me.Culture = New System.Globalization.CultureInfo("ru-RU")
            Me.DictionaryPath = dictionaryFolderPath & "\ru_dic"
            Me.GrammarPath = dictionaryFolderPath & "\ru_aff"
            Me.Load()
        End With
    End Sub

End Class
