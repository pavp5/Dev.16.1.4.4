Imports Excel = Microsoft.Office.Interop.Excel
Imports Cprp.DxData.Common
''' <summary>
''' Таблица контактных лиц
''' </summary>
Friend Class ContactDataTable : Inherits DataTable

    ''' <summary>
    ''' New
    ''' </summary>
    Friend Sub New()
        MyBase.New("ContactTable")
        With Me.Columns
            .Add("id", GetType(Integer))
            .Add("phone", GetType(String))
            .Add("userName", GetType(String))
            .Add("firstName", GetType(String))
            .Add("lastName", GetType(String))
            .Add("createDate", GetType(Date))
            .Add("isAdded", GetType(Boolean))
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Me.Columns("phone").AllowDBNull = False
        With Me.Columns("isAdded")
            .AllowDBNull = False
            .DefaultValue = False
        End With
    End Sub


    Friend Sub LoadFromExcel()
        Dim filePath As String
        Using Dlg As New OpenFileDialog
            Dlg.Title = "Выбор загрузочного файла"
            Dlg.DefaultExt = "xls"
            Dlg.Filter = "Файл Excel (*.xlsx)|*.xlsx"
            If Dlg.ShowDialog <> Windows.Forms.DialogResult.OK Then Exit Sub
            filePath = Dlg.FileName
        End Using
        Dim Row As DataRow
        Dim phone As String
        Dim firstName As String
        Dim lastName As String
        Dim createDate As String
        Dim iTmp As Integer = 2

        Me.Rows.Clear()

        Dim EApp As New Excel.Application
        EApp.Visible = False
        EApp.Workbooks.Open(filePath)
        With EApp.Workbooks(1).Worksheets(1)
            Do
                phone = ToText(.Cells(iTmp, 1).Value)
                If String.IsNullOrWhiteSpace(phone) Then Exit Do
                firstName = ToText(.Cells(iTmp, 3).Value)
                If String.IsNullOrWhiteSpace(firstName) Then Continue Do
                lastName = ToText(.Cells(iTmp, 4).Value)
                createDate = ToText(.Cells(iTmp, 5).Value)
                If Not phone Like "+*" Then phone = "+" & phone
                Row = Me.NewRow
                Row("phone") = DbText(phone)
                Row("firstName") = DbText(firstName)
                Row("lastName") = DbText(lastName)
                Row("createDate") = DbDate(createDate)
                Me.Rows.Add(Row)
                iTmp += 1
            Loop
        End With
        EApp.Quit()
    End Sub




End Class
