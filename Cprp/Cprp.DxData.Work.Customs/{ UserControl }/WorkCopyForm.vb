''' <summary>
''' Форма загрузки данных из другой работы
''' </summary>
''' <remarks></remarks>
Friend Class WorkCopyForm

    ' Работа
    Private _Work As WorkConnectionRow = Nothing

    ' Таблица результатов поиска
    Private _ResTable As DataTable = Nothing

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <remarks></remarks>
    Friend Sub New(ByRef Work As WorkConnectionRow)
        InitializeComponent()
        '
        ' Работа
        '
        _Work = Work
        If _Work Is Nothing OrElse _Work.IsEmpty Then Exit Sub
        '
        ' _ResTable
        '
        _ResTable = New DataTable
        _ResTable.Columns.Add("id", GetType(Integer))
        _ResTable.Columns.Add("goodCaption", GetType(String))
        '
        ' ResGridControl 
        '
        ResGridControl.DataSource = _ResTable
        '
        ' AcceptSimpleButton 
        '
        AcceptSimpleButton.Enabled = False
        '
        ' Me
        '
        Me.Text = "Загрузка данных"
        Me.CenterToScreen()

    End Sub

    Private Sub FindSimpleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindSimpleButton.Click
        DxErrorProvider1.ClearErrors()
        Dim sTmp As String = Trim(NumberTextEdit.Text)
        Select Case TypeComboBoxEdit.Text
            Case "Работа"
                If String.IsNullOrWhiteSpace(sTmp) Then
                    DxErrorProvider1.SetError(NumberTextEdit, "Укажите номер работы")
                    Exit Sub
                End If
                If Not IsNumeric(sTmp) Then
                    DxErrorProvider1.SetError(NumberTextEdit, "Неправильный номер работы")
                    Exit Sub
                End If
                sTmp = String.Format("SELECT id, description FROM tWork WHERE id = {0}", CInt(sTmp))
            Case "Заказ"
                If String.IsNullOrWhiteSpace(sTmp) Then
                    DxErrorProvider1.SetError(NumberTextEdit, "Укажите номер заказа")
                    Exit Sub
                End If
                sTmp = String.Format("SELECT id, description FROM tWork WHERE orderNum LIKE '{0}'", sTmp.Replace("'", "''"))
        End Select
        _ResTable.Rows.Clear()
        _ResTable.Load(_Work.ExecuteReader(sTmp))
        If _ResTable.Rows.Count > 0 Then
            AcceptSimpleButton.Enabled = True
            ResGridView.MoveFirst()
        Else
            AcceptSimpleButton.Enabled = False
            Cprp.DxCommon.Messages.ShowWarning("Нет данных для загрузки.")
        End If
    End Sub

    Private Sub AcceptSimpleButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcceptSimpleButton.Click
        If ResGridView.FocusedRowHandle < 0 Then Exit Sub
        If Not (SupplyCheckEdit.Checked OrElse GoodCheckEdit.Checked OrElse DocCheckEdit.Checked) Then
            Cprp.DxCommon.Messages.ShowWarning("Выберите, что загружать.")
            Exit Sub
        End If
        Dim workId As Integer = CInt(ResGridView.GetFocusedDataRow("id"))
        Cprp.DxCommon.WaitForm.Show(Me)
        Try
            _Work.ReadXml(_Work.GetWorkFilePath(workId), SupplyCheckEdit.Checked, GoodCheckEdit.Checked, DocCheckEdit.Checked, False)
            Dim sTmp As String = String.Format("Скопировано из работы № {0}: ", workId)
            If SupplyCheckEdit.Checked Then sTmp &= "Внешнеэкономическая сделка / операция; "
            If GoodCheckEdit.Checked Then sTmp &= "Объекты экспертизы; "
            If DocCheckEdit.Checked Then sTmp &= "Материалы и документы, представленные на экспертизу; "
            _Work.WriteHistory(DxData.Work.WorkEvent.DataCopy, sTmp.Substring(0, sTmp.Length - 2))
            Cprp.DxCommon.WaitForm.Close()
        Catch ex As Exception
            Cprp.DxCommon.WaitForm.Close()
            Cprp.DxCommon.Messages.ShowError(String.Format("Ошибка загрузки данных:{0}{1}", vbCrLf, ex.Message))
            Exit Sub
        End Try
        Me.DialogResult = DialogResult.OK
    End Sub

End Class