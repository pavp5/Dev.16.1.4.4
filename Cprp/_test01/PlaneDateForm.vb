''' <summary>
''' Форма для тестирования функции расчета срока исполнения
''' </summary>
Public Class PlaneDateForm

    Public Sub New()
        InitializeComponent()
        '
        ' StartDateDateEdit
        '
        StartDateDateEdit.EditValue = Date.Now
        '
        ' MinuteCountSpinEdit
        '
        MinuteCountSpinEdit.EditValue = 120
        '
        ' Me
        '
        Me.CenterToScreen()

    End Sub

    Private Sub CalcSimpleButton_Click(sender As Object, e As EventArgs) Handles CalcSimpleButton.Click
        CalcResultLabelControl.Text = String.Format("Плановый срок: {0:dd.MM.yyyy HH:mm:ss}", _
                                                     GetPlaneDate(CDate(StartDateDateEdit.EditValue), _
                                                                  CInt(MinuteCountSpinEdit.EditValue)))
    End Sub

    ''' <summary>
    ''' Возвращает расчетный срок исполнения
    ''' </summary>
    ''' <param name="startDate">Дата начала отсчета</param>
    ''' <param name="minuteCount">Время исполнения в минутах</param>
    ''' <param name="isRoundMinute">Округлять минуты до 10</param>
    Public Function GetPlaneDate(startDate As Date, minuteCount As Integer, Optional isRoundMinute As Boolean = True) As Date

        Dim hStart As Integer = 9   ' Час начала рабочего дня
        Dim hEnd As Integer = 18    ' Час конца рабочего дня
        '
        ' Продолжительность рабочего дня в минутах
        ' 60 x (час конца - час начала - час на перерыв)
        '
        Dim mCount As Integer = 60 * (hEnd - hStart - 1)
        '
        ' Приведение даты начала отсчета
        '
        If startDate.Hour < hStart Then
            '
            ' Если время начала меньше времени начала рабочего дня, то дата равна началу текущего рабочего дня
            '
            startDate = New Date(startDate.Year, startDate.Month, startDate.Day, hStart, 0, 0)

        ElseIf startDate.Hour > hEnd OrElse (startDate.Hour = hEnd AndAlso startDate.Minute > 0) Then
            '
            ' Если время начала больше времени конца рабочего дня, то дата равна началу следующего рабочего дня
            '
            startDate = startDate.AddDays(1)
            startDate = New Date(startDate.Year, startDate.Month, startDate.Day, hStart, 0, 0)

        End If
        '
        ' Увеличение даты начала на количество рабочих дней, входящих во время исполнения
        '
        Do
            ' Перенос даты с выходных дней на понедельник
            If startDate.DayOfWeek = DayOfWeek.Saturday Then startDate = startDate.AddDays(2)
            If startDate.DayOfWeek = DayOfWeek.Sunday Then startDate = startDate.AddDays(1)
            ' Если время исполнения меньше продолжительности рабочего дня, то выход из цикла
            If minuteCount - mCount < 0 Then Exit Do
            ' Добавление одного дня
            startDate = startDate.AddDays(1)
            ' Уменьшение времени исполнения на продолжительность рабочего дня
            minuteCount -= mCount
        Loop
        '
        ' Увеличение даты до конца рабочего дня, если позволяет остаток времени исполнения
        '
        Dim endDate As Date = New Date(startDate.Year, startDate.Month, startDate.Day, hEnd, 0, 0)
        While startDate < endDate
            If minuteCount = 0 Then Exit While
            startDate = startDate.AddMinutes(1)
            minuteCount -= 1
        End While
        '
        ' Если остаток времени исполнения больше 0, то перенести дату на начало следющего рабочего дня 
        ' и прибавить к ней остаток времени
        '
        If minuteCount > 0 Then
            startDate = startDate.AddDays(1)
            startDate = New Date(startDate.Year, startDate.Month, startDate.Day, hStart, 0, 0)
            startDate = startDate.AddMinutes(minuteCount)
            If startDate.DayOfWeek = DayOfWeek.Saturday Then startDate = startDate.AddDays(2)
            If startDate.DayOfWeek = DayOfWeek.Sunday Then startDate = startDate.AddDays(1)
        End If
        '
        ' Округление минут до 10
        '
        If isRoundMinute Then
            While startDate.Minute Mod 10 <> 0
                startDate = startDate.AddMinutes(1)
            End While
        End If

        Return startDate

    End Function

End Class