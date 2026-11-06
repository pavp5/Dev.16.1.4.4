''' <summary>
''' Общие свойства и методы работы с данными
''' </summary>
''' <remarks></remarks>
Public Class Common

    Private Sub New()
    End Sub

    ''' <summary>
    ''' Идентификатор пустого id-значения
    ''' </summary>
    ''' <remarks></remarks>
    Public Const EMPTY_ID As Integer = -1

    ''' <summary>
    ''' Разделитель полей в строке данных
    ''' </summary>
    ''' <remarks></remarks>
    Public Const FIELD_SEPARATOR As Char = Chr(1)

    ''' <summary>
    ''' Преобразует переданное значение в целое число
    ''' </summary>
    ''' <param name="value">Принимаемое значение</param>
    ''' <remarks>Если значение нельзя преобразовать, возвращает EMPTY_ID</remarks>
    Public Shared Function ToInt(value As Object) As Integer
        If Not IsNumeric(value) Then Return EMPTY_ID
        Return CInt(value)
    End Function

    ''' <summary>
    ''' Преобразует переданное значение в вещественное число
    ''' </summary>
    ''' <param name="value">Принимаемое значение</param>
    ''' <remarks>Если значение нельзя преобразовать, возвращает EMPTY_ID</remarks>
    Public Shared Function ToSng(value As Object) As Single
        If Not IsNumeric(value) Then Return EMPTY_ID
        Return CSng(value)
    End Function

    ''' <summary>
    ''' Удаляет в текстовой строке оконечные нечитаемые символы и пробелы
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <param name="lenght">Длина возвращаемой части строки (0 - возвращается вся строка)</param> 
    ''' <remarks>Если value Is Nothing, возвращается String.Empty</remarks>
    Public Shared Function ToText(ByVal value As Object, Optional lenght As Integer = 0) As String
        If value Is Nothing Then Return String.Empty
        Dim sTmp As String = value.ToString
        Do
            If sTmp.Length = 0 Then Exit Do
            If Asc(sTmp(0)) > 33 AndAlso Asc(sTmp(sTmp.Length - 1)) > 33 Then Exit Do
            If Asc(sTmp(0)) < 34 Then sTmp = sTmp.Substring(1)
            If sTmp.Length = 0 Then Exit Do
            If Asc(sTmp(sTmp.Length - 1)) < 34 Then sTmp = sTmp.Substring(0, sTmp.Length - 1)
        Loop
        If lenght > 0 AndAlso sTmp.Length > lenght Then sTmp = sTmp.Substring(0, lenght)
        Return sTmp
    End Function

    ''' <summary>
    ''' Удаляет в текстовой строке кирилические символы на соответствующие латинские
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <param name="lenght">Длина возвращаемой части строки (0 - возвращается вся строка)</param> 
    ''' <remarks>Если value Is Nothing, возвращается String.Empty</remarks>
    Public Shared Function ToTextLat(ByVal value As Object, Optional lenght As Integer = 0) As String
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) Then Return String.Empty
        sTmp = sTmp.Replace("А", "A").Replace("Е", "E").Replace("К", "K").Replace("Н", "H").Replace("Х", "X").Replace("В", "B").Replace("Р", "P").Replace("О", "O").Replace("С", "C").Replace("М", "M").Replace("Т", "T")
        sTmp = sTmp.Replace("а", "a").Replace("е", "e").Replace("к", "k").Replace("н", "h").Replace("х", "x").Replace("в", "b").Replace("р", "p").Replace("о", "o").Replace("с", "c").Replace("м", "m").Replace("т", "t")
        Return sTmp
    End Function


    ''' <summary>
    ''' Преобразует переданное значение в дату
    ''' </summary>
    ''' <param name="value">Принимаемое значение</param>
    ''' <remarks>Если значение нельзя преобразовать, возвращает Nothing (01.01.0001)</remarks>
    Public Shared Function ToDate(value As Object) As Date
        If Not IsDate(value) Then Return Nothing
        Return CDate(value)
    End Function

    ''' <summary>
    ''' Экранирует в текстовой строке символы разметки XML/HTML
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <remarks></remarks>
    Public Shared Function ToXML(ByVal value As String) As String
        Return System.Security.SecurityElement.Escape(value)
    End Function

    ''' <summary>
    ''' Экранирует в текстовой строке символы разметки XML/HTML
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <remarks></remarks>
    Public Shared Function ToXML(ByVal value As Object) As String
        Return System.Security.SecurityElement.Escape(ToText(value))
    End Function

    ''' <summary>
    ''' Строка содержит алфавитно-цифровые символы или знаки препинания
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <remarks></remarks>
    Public Shared Function IsText(ByVal value As String) As Boolean
        If String.IsNullOrWhiteSpace(value) Then Return False
        For Each c As Char In value
            If Asc(c) > 33 Then Return True
        Next
        Return False
    End Function

    ''' <summary>
    ''' Строка содержит алфавитно-цифровые символы или знаки препинания
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <remarks></remarks>
    Public Shared Function IsText(ByVal value As Object) As Boolean
        If value Is Nothing Then Return False
        Return IsText(value.ToString)
    End Function

    ''' <summary>
    ''' Выбирает из текстовой строки алфавитно-цифровые символы
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <remarks>Если value Is Nothing, возвращается String.Empty</remarks>
    Public Shared Function ToABC(ByVal value As String) As String
        If Not IsText(value) Then Return String.Empty
        Dim sTmp As String = Nothing
        For i As Integer = 0 To value.Length - 1
            If value(i) Like "[0-9]" OrElse _
                value(i) Like "[A-Z]" OrElse _
                value(i) Like "[a-z]" OrElse _
                value(i) Like "[А-Я]" OrElse _
                value(i) Like "[а-я]" Then sTmp &= value(i)
        Next
        If String.IsNullOrWhiteSpace(sTmp) Then Return String.Empty
        Return sTmp
    End Function

    ''' <summary>
    ''' Вставить точку в конце фразы
    ''' </summary>
    ''' <param name="value">Исходная фраза</param>
    ''' <remarks></remarks>
    Public Shared Function AddPoint(ByVal value As Object) As String
        Dim sTmp As String = ToText(value)
        If sTmp.Length = 0 OrElse sTmp Like "*[.:;!?]" Then Return sTmp
        Return (sTmp & ".")
    End Function

    ''' <summary>
    ''' Удалить точку в конце фразы
    ''' </summary>
    ''' <param name="value">Исходная фраза</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function DelPoint(ByVal value As Object) As String
        Dim sTmp As String = ToText(value)
        Do
            If sTmp.Length = 0 Then Exit Do
            If Not sTmp Like "*." Then Exit Do
            sTmp = sTmp.Substring(0, sTmp.Length - 1)
        Loop
        Return sTmp
    End Function

    '' ''' <summary>
    '' ''' Преобразует строку, содержащую цифры, в строку уникальных чисел, упорядоченных по возрастанию
    '' ''' </summary>
    '' ''' <param name="value">Принимаемая строка</param>
    '' ''' <param name="isUnion">Объединять последовательные значения в строку вида n-m</param> 
    '' ''' <returns></returns>
    '' ''' <remarks>
    '' ''' В результирующей строке числа разделяются запятой с пробелом.
    '' ''' Если исходная строка не содержит цифр, возвращается String.Empty.
    '' ''' </remarks>
    'Public Shared Function ToStrNum(ByVal value As Object, ByVal isUnion As Boolean) As String
    '    Dim sTmp As String = ToText(value)
    '    If sTmp.Length = 0 Then Return String.Empty
    '    '
    '    ' Замена всех нечисловых символов на символ "A"
    '    '
    '    For Each c As Char In sTmp
    '        If Not (c = "A" OrElse IsNumeric(c)) Then sTmp = sTmp.Replace(c, "A")
    '    Next
    '    '
    '    ' Массив строковых значений
    '    '
    '    Dim arrS() As String = sTmp.Split(New Char() {"A"}, StringSplitOptions.RemoveEmptyEntries)
    '    If arrS.Length = 0 Then Return String.Empty
    '    If arrS.Length = 1 Then Return arrS(0)
    '    '
    '    ' Массив числовых значений
    '    '
    '    Dim arrN(arrS.Length) As Integer
    '    '
    '    ' Инициализация числового массива, определение минимального значения -1
    '    '
    '    Dim minN As Integer = 100
    '    For i As Integer = arrS.GetLowerBound(0) To arrS.GetUpperBound(0)
    '        arrN(i) = CInt(arrS(i))
    '        If arrN(i) < minN Then minN = arrN(i) - 1
    '    Next
    '    '
    '    ' Замена в числовом массиве повторяющихся значений на минимальное -1
    '    '
    '    For i As Integer = arrN.GetLowerBound(0) To arrN.GetUpperBound(0)
    '        If arrN(i) = minN Then Continue For
    '        For j As Integer = i + 1 To arrN.GetUpperBound(0)
    '            If arrN(j) = arrN(i) Then arrN(j) = minN
    '        Next
    '    Next
    '    '
    '    ' Сортировка числового массива по возрастанию
    '    '
    '    Array.Sort(arrN)
    '    '
    '    ' Формирование возвращаемого значения
    '    '
    '    sTmp = String.Empty
    '    If isUnion Then
    '        Dim iTmp As Integer = 1
    '        For i As Integer = arrN.GetLowerBound(0) To arrN.GetUpperBound(0)
    '            ' пропускаем мусорные значения
    '            If arrN(i) = minN Then Continue For
    '            ' инициализация начальных значений
    '            If sTmp.Length = 0 Then
    '                sTmp = arrN(i).ToString
    '                iTmp = arrN(i)
    '                Continue For
    '            End If
    '            ' пропускаем цикл пока каждое следующие значение на 1 больше предыдущего и, при этом, не достигнут конец массива
    '            If i <> arrN.GetUpperBound(0) AndAlso arrN(i) - arrN(i - 1) < 2 Then Continue For
    '            ' формирование возвращаемого значения
    '            If arrN(i) - arrN(i - 1) = 1 Then
    '                sTmp &= String.Format("{0}{1}", If(arrN(i) - iTmp > 1, " - ", ", "), arrN(i))
    '            ElseIf arrN(i - 1) = iTmp Then
    '                sTmp &= String.Format(", {0}", arrN(i))
    '            Else
    '                sTmp &= String.Format("{0}{1}, {2}", If(arrN(i - 1) - iTmp > 1, " - ", ", "), arrN(i - 1), arrN(i))
    '            End If
    '            iTmp = arrN(i)
    '        Next
    '    Else
    '        For i As Integer = arrN.GetLowerBound(0) To arrN.GetUpperBound(0)
    '            If arrN(i) = minN Then Continue For
    '            If sTmp.Length = 0 Then
    '                sTmp = arrN(i).ToString
    '                Continue For
    '            End If
    '            sTmp &= String.Format(", {0}", arrN(i))
    '        Next
    '    End If
    '    Return sTmp
    'End Function

    ''' <summary>
    ''' Преобразует строку, содержащую цифры, в строку уникальных чисел, упорядоченных по возрастанию
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <param name="isUnion">Объединять последовательные значения в строку вида n-m</param> 
    ''' <returns></returns>
    ''' <remarks>
    ''' В результирующей строке числа разделяются запятой с пробелом.
    ''' Если исходная строка не содержит цифр, возвращается Nothing.
    ''' </remarks>
    Public Shared Function ToStrNum(ByVal value As Object, ByVal isUnion As Boolean) As String
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) Then Return Nothing
        ' Замена всех нечисловых символов на символ "A"
        For i As Integer = 0 To sTmp.Length - 1
            If sTmp(i) = "A" Then Continue For
            If sTmp(i) < "0" OrElse sTmp(i) > "9" Then sTmp = sTmp.Replace(sTmp(i), "A")
        Next
        ' Массив строковых значений
        Dim arrStr() As String = sTmp.Split(New Char() {"A"}, StringSplitOptions.RemoveEmptyEntries)
        If arrStr.Length = 0 Then Return Nothing
        If arrStr.Length = 1 Then Return arrStr(0)
        ' Массив числовых значений
        Dim arrNum(arrStr.Length - 1) As Integer
        For i As Integer = arrStr.GetLowerBound(0) To arrStr.GetUpperBound(0)
            arrNum(i) = CInt(arrStr(i))
        Next
        ' Сортировка числового массива по возрастанию
        Dim iTmp As Integer = 0
        For i As Integer = arrNum.GetLowerBound(0) To arrNum.GetUpperBound(0)
            For j As Integer = arrNum.GetLowerBound(0) + i + 1 To arrNum.GetUpperBound(0)
                If arrNum(i) > arrNum(j) Then
                    iTmp = arrNum(i)
                    arrNum(i) = arrNum(j)
                    arrNum(j) = iTmp
                End If
            Next
        Next
        ' Удаление повтряющихся значений в числовом массиве
        sTmp = arrNum(0).ToString
        For i As Integer = arrNum.GetLowerBound(0) + 1 To arrNum.GetUpperBound(0)
            If arrNum(i) <> arrNum(i - 1) Then sTmp &= ("A" & arrNum(i).ToString)
        Next
        arrStr = sTmp.Split(New Char() {"A"}, StringSplitOptions.RemoveEmptyEntries)
        If arrStr.Length = 1 Then Return arrStr(0)
        If arrStr.Length = 2 Then Return String.Format("{0}, {1}", arrStr(0), arrStr(1))
        ReDim arrNum(arrStr.Length - 1)
        For i As Integer = arrStr.GetLowerBound(0) To arrStr.GetUpperBound(0)
            arrNum(i) = CInt(arrStr(i))
        Next
        ' Формирование возвращаемого значения
        sTmp = arrNum(0).ToString
        If isUnion Then
            iTmp = arrNum(0)
            For i As Integer = arrNum.GetLowerBound(0) + 1 To arrNum.GetUpperBound(0)
                If Not (i = arrNum.GetUpperBound(0) OrElse arrNum(i) - arrNum(i - 1) > 1) Then Continue For
                If arrNum(i) - arrNum(i - 1) = 1 Then
                    sTmp &= String.Format("{0}{1}", If(arrNum(i) - iTmp > 1, " - ", ", "), arrNum(i))
                ElseIf arrNum(i - 1) = iTmp Then
                    sTmp &= String.Format(", {0}", arrNum(i))
                Else
                    sTmp &= String.Format("{0}{1}, {2}", If(arrNum(i - 1) - iTmp > 1, " - ", ", "), arrNum(i - 1), arrNum(i))
                End If
                iTmp = arrNum(i)
            Next
        Else
            For i As Integer = arrNum.GetLowerBound(0) + 1 To arrNum.GetUpperBound(0)
                sTmp &= String.Format(", {0}", arrNum(i))
            Next
        End If
        Return sTmp
    End Function

    ''' <summary>
    ''' Преобразует переданное значение в целое число для записи в ячейку базы данных
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <remarks>Если значение нельзя преобразовать, возвращает DBNull.Value</remarks>
    Public Shared Function DbInt(value As Object) As Object
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) OrElse Not IsNumeric(sTmp) Then Return DBNull.Value
        Return CInt(sTmp)
    End Function

    ''' <summary>
    ''' Преобразует переданное значение в вещественное число для записи в ячейку базы данных
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <remarks>Если значение нельзя преобразовать, возвращает DBNull.Value</remarks>
    Public Shared Function DbSng(value As Object) As Object
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) OrElse Not IsNumeric(sTmp) Then Return DBNull.Value
        Return CSng(sTmp)
    End Function

    ''' <summary>
    ''' Преобразует переданное значение в текст для записи в ячейку базы данных
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <param name="lenght">Длина возвращаемой части строки (0 - возвращается вся строка)</param> 
    ''' <remarks>Если строка пустая, возвращает DBNull.Value</remarks>
    Public Shared Function DbText(value As Object, Optional lenght As Integer = 0) As Object
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) Then Return DBNull.Value
        If lenght > 0 AndAlso sTmp.Length > lenght Then sTmp = sTmp.Substring(0, lenght)
        Return sTmp
    End Function

    ''' <summary>
    ''' Преобразует переданное значение в дату для записи в ячейку базы данных
    ''' </summary>
    ''' <param name="value">Принимаемая строка</param>
    ''' <remarks>Если значение нельзя преобразовать, возвращает DBNull.Value</remarks>
    Public Shared Function DbDate(value As Object) As Object
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) OrElse Not IsDate(sTmp) Then Return DBNull.Value
        Return CDate(sTmp)
    End Function


    ''' <summary>
    ''' Преобразует переданное значение в текст
    ''' </summary>
    ''' <param name="value">Принимаемое значение</param>
    ''' <param name="nullText">Текст замещающий пустое значение</param>
    ''' <remarks>Если значение пустое, возвращает nullText</remarks>
    Public Shared Function TStr(value As Object, Optional nullText As String = "[нет данных]") As String
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) Then Return nullText
        Return sTmp
    End Function

    ''' <summary>
    ''' Преобразует переданное значение в текстовое представление целого числа
    ''' </summary>
    ''' <param name="value">Принимаемое значение</param>
    ''' <param name="nullText">Текст замещающий пустое значение</param>
    ''' <param name="strLen">Длина строки, будет дополнена начальными нулями</param>
    ''' <remarks>Если значение нельзя преобразовать, возвращает nullText</remarks>
    Public Shared Function TInt(value As Object, Optional nullText As String = "[нет данных]", Optional strLen As Integer = 0) As String
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) OrElse Not IsNumeric(sTmp) Then Return nullText
        sTmp = CInt(sTmp).ToString
        While sTmp.Length < strLen
            sTmp = ("0" & sTmp)
        End While
        Return sTmp
    End Function

    ''' <summary>
    ''' Преобразует переданное значение в текстовое представление дробного числа в формате "0.00"
    ''' </summary>
    ''' <param name="value">Принимаемое значение</param>
    ''' <param name="nullText">Текст замещающий пустое значение</param>
    ''' <remarks>Если значение нельзя преобразовать, возвращает nullText</remarks>
    Public Shared Function TSng(value As Object, Optional nullText As String = "[нет данных]") As String
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) OrElse Not IsNumeric(sTmp) Then Return nullText
        Return Format(CSng(sTmp), "0.00")
    End Function

    ''' <summary>
    ''' Преобразует переданное значение в текстовое представление даты в формате "0.00"
    ''' </summary>
    ''' <param name="value">Принимаемое значение</param>
    ''' <param name="nullText">Текст замещающий пустое значение</param>
    ''' <remarks>Если значение нельзя преобразовать, возвращает nullText</remarks>
    Public Shared Function TDate(value As Object, Optional nullText As String = "[нет данных]") As String
        Dim sTmp As String = ToText(value)
        If String.IsNullOrWhiteSpace(sTmp) OrElse Not IsDate(sTmp) Then Return nullText
        Return Format(CDate(sTmp), "dd.MM.yyyy")
    End Function

End Class
