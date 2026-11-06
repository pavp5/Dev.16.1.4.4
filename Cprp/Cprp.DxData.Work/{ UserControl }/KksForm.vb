Imports Cprp.DxData.Common
''' <summary>
''' Форма проверки кодов KKS
''' </summary>
Public Class KksForm

    ' Массив кодов KKS из красной зоны
    Private arrRed() As String = {"CNR", "CNS", "CQA", "CQB", "CWA", "CWH", "FBA", "FBB", "FCA", "FCB", "FJA", "FJB", "FJC", _
                                  "JAA", "JAB", "JAC", "JAH", "JBA", "JDA", "JDH", "JDJ", "JDK", "JDT", "JDY", "JEA", "JEB", _
                                  "JEC", "JEF", "JEG", "JKA", "JKS", "JKT", "JKU", "JND", "JYL", "KBA", "KBC", "KBD", "KBE"}

    Private connection As SqlClient.SqlConnection = Nothing

    Public Sub New(filePath As String, Optional connection As SqlClient.SqlConnection = Nothing)
        InitializeComponent()
        '
        ' connection
        '
        Me.connection = connection
        '
        ' SP
        '
        SP.Document.LoadDocument(filePath, DevExpress.Spreadsheet.DocumentFormat.Xlsx)
        '
        ' Me
        '
        Me.Icon = My.Resources.pin_blue_ico
        Me.Text = "Проверка кодов KKS"
        Me.Width = Screen.GetWorkingArea(Me).Width - 100
        Me.Height = Screen.GetWorkingArea(Me).Height - 100
        Me.CenterToScreen()

    End Sub

    Private Sub FindWork()
        If connection Is Nothing Then Exit Sub
        Dim i As Integer = 1
        Dim sTmp As String = Nothing
        Using cmd As SqlClient.SqlCommand = connection.CreateCommand
            With SP.Document.Worksheets(0)
                Do
                    sTmp = ToText(.Cells(i, 1).Value)
                    If Not IsText(sTmp) Then Exit Do
                    cmd.CommandText = String.Format("SELECT COUNT(*) FROM tGood WHERE nameCon LIKE '%{0}%'", sTmp)
                    If (CInt(cmd.ExecuteScalar)) > 0 Then
                        .Cells(i, 5).Value = "Был"
                        .Cells(i, 5).Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center
                        .Cells(i, 5).Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Top
                        '.Rows(i).Font.Bold = True
                    End If
                    i += 1
                Loop
                .ScrollTo(0, 0)
            End With
        End Using
    End Sub

    Private Sub CheckKKS()        
        Dim i As Integer = 1
        Dim sTmp As String = Nothing
        With SP.Document.Worksheets(0)
            Do
                sTmp = (ToTextLat(.Cells(i, 1).Value) & ToTextLat(.Cells(i, 2).Value)).ToUpper
                If Not IsText(sTmp) Then Exit Do
                For Each kks As String In arrRed
                    If sTmp Like "*" & kks & "*" Then
                        .Cells(i, 4).Value = kks
                        .Cells(i, 4).Alignment.Horizontal = DevExpress.Spreadsheet.SpreadsheetHorizontalAlignment.Center
                        .Cells(i, 4).Alignment.Vertical = DevExpress.Spreadsheet.SpreadsheetVerticalAlignment.Top
                        .Rows(i).Font.Color = Drawing.Color.Red
                        Exit Do
                    End If
                Next
                i += 1
            Loop
            .ScrollTo(0, 0)
        End With
    End Sub

    Private Sub KksForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        Cprp.DxCommon.WaitForm.Show(Me)
        'FindWork()
        CheckKKS()
        Cprp.DxCommon.WaitForm.Close()
    End Sub

    Private Sub SP_KeyDown(sender As Object, e As KeyEventArgs) Handles SP.KeyDown
        If e.Alt And e.KeyCode = Keys.C Then CheckKKS()
    End Sub

End Class