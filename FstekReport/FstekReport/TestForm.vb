Imports Excel = Microsoft.Office.Interop.Excel
''' <summary>
''' Форма поиска кодов ТН ВЭД по кодам HS в файле EXcel
''' </summary>
Public Class TestForm

    ''' <summary>
    ''' Таблица - справочник кодов ТН ВЭД
    ''' </summary>
    Private TnvedTable As DataTable = Nothing

    Public Sub New()
        InitializeComponent()
        '
        ' TnvedTable
        '
        TnvedTable = New DataTable
        TnvedTable.Columns.Add("code", GetType(String))
        TnvedTable.PrimaryKey = New DataColumn() {TnvedTable.Columns("code")}
        Using Cmd As New SqlCommand With {.Connection = Program.DbClient.Connection}
            Cmd.CommandText = String.Format("SELECT DISTINCT code AS code FROM tTnved WHERE dateB <= {{ts '{0:yyyy-MM-dd HH:mm:ss}'}} AND dateE > {{ts '{0:yyyy-MM-dd HH:mm:ss}'}}", Date.Now)
            TnvedTable.Load(Cmd.ExecuteReader)
        End Using

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim allCount As Integer = 0
        Dim hasCount As Integer = 0
        Dim noCount As Integer = 0

        Dim EApp As New Excel.Application
        EApp.Workbooks.Open("d:\3.xls")

        Dim sTmp As String = Nothing
        Using V As New DataView(TnvedTable) With {.Sort = "code"}

            Dim i As Integer = 2
            With EApp.Workbooks(1).Worksheets(1)
                Do
                    Me.Text = String.Format("Запись {0}", i - 1)
                    Application.DoEvents()
                    sTmp = Cprp.DxData.Common.ToText(.Cells(i, 15).Value)
                    If String.IsNullOrWhiteSpace(sTmp) Then Exit Do

                    allCount += 1

                    V.RowFilter = String.Format("code = '{0}'", sTmp)
                    If V.Count > 0 Then
                        .Cells(i, 14).Value = sTmp
                        hasCount += 1
                        GoTo End1
                    End If

                    Do
                        sTmp = sTmp.Substring(0, sTmp.Length - 1)
                        If sTmp.Length < 7 Then
                            noCount += 1
                            Exit Do
                        End If
                        V.RowFilter = String.Format("code LIKE '{0}%'", sTmp)
                        If V.Count > 0 Then
                            .Cells(i, 14).Value = V(V.Count - 1)("code").ToString
                            Exit Do
                        End If
                    Loop


End1:
                    i += 1
                Loop

            End With

        End Using

        EApp.Workbooks(1).SaveAs("d:\3_1.xls")
        EApp.Workbooks(1).Close()
        EApp.Quit()

        Me.Cursor = Cursors.Default

        sTmp = String.Format("Всего: {0}, полное совпадение: {1}, отсутствуют: {2}.", allCount, hasCount, noCount)
        Clipboard.Clear()
        Clipboard.SetText(sTmp)

        MsgBox(sTmp)

    End Sub

End Class