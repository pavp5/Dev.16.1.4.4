Imports C2 = Cprp.DxData.Common
''' <summary>
''' Форма поиск лица в таблице лиц
''' </summary>
''' <remarks></remarks>
Friend Class FindForm

    ''' <summary>
    ''' Таблица-строка, выбранная в результатах поиска
    ''' </summary>
    ''' <remarks></remarks>
    Friend MemberRow As MemberDataTable = Nothing

    ''' <summary>
    ''' Открытое соединение с базой данных
    ''' </summary>
    ''' <remarks></remarks>
    Private _Connection As SqlConnection = Nothing

    ''' <summary>
    ''' Таблица результатов поиска
    ''' </summary>
    ''' <remarks></remarks>
    Private _MemberTable As DataTable = Nothing

    ''' <summary>
    ''' ID России в справочнике стран мира
    ''' </summary>
    ''' <remarks></remarks>
    Private _russiaId As Integer = C2.EMPTY_ID

    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="kind">Вид лица</param> 
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    ''' <param name="Row">Строка таблицы лиц с предварительными данными для поиска</param> 
    ''' <remarks></remarks>
    Friend Sub New(kind As MemberKind, Connection As SqlConnection, Optional Row As DataRow = Nothing)
        InitializeComponent()
        '
        ' _Connection
        '
        _Connection = Connection
        '
        ' _MemberTable
        '
        _MemberTable = New DataTable
        With _MemberTable.Columns
            .Add("id", GetType(Integer))
            .Add("nameShort", GetType(String))
            .Add("proDescription", GetType(String))
            .Add("isControl", GetType(Boolean))
            .Add("memberCaption", GetType(String))
        End With
        _MemberTable.PrimaryKey = New DataColumn() {_MemberTable.Columns("id")}
        '
        ' _russiaId
        '
        If kind = MemberKind.IsContractRus OrElse kind = MemberKind.IsSupplyRus Then
            Using Cmd As New SqlCommand With {.Connection = _Connection}
                Cmd.CommandText = "SELECT id FROM tCountry WHERE nameShort LIKE '%РОССИЯ%'"
                Using Dr As SqlDataReader = Cmd.ExecuteReader
                    If Dr.Read Then _russiaId = CInt(Dr(0))
                End Using
            End Using
        End If
        '
        ' Row
        '
        If Row Is Nothing OrElse Not TypeOf Row.Table Is MemberDataTable Then GoTo EndRow
        Dim sTmp As String = GetQueryByRow(Row)
        If Not C2.IsText(sTmp) Then GoTo EndRow
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format( _
                "SELECT id, nameShort, proDescription, isControl, memberCaption FROM vMember WHERE {0}", sTmp)
            _MemberTable.Load(Cmd.ExecuteReader)
        End Using
EndRow:
        '
        ' DataSource, DataBindings
        '
        MemberGridControl.DataSource = _MemberTable
        MemberGridView.SortInfo.Insert(0, NameShortGridColumn, DevExpress.Data.ColumnSortOrder.Ascending)
        MemberGridView.MoveFirst()
        MemberCaptionMemoEdit.DataBindings.Add("Text", _MemberTable, "memberCaption")
        '
        ' AcceptSimpleButton
        '
        AcceptSimpleButton.Enabled = (_MemberTable.Rows.Count > 0)
        '
        ' Me
        '
        Select Case kind
            Case MemberKind.IsClient : Me.Text = "Поиск: Заказчик"
            Case MemberKind.IsContractRus : Me.Text = "Поиск: Российский участник сделки"
            Case MemberKind.IsContractNus : Me.Text = "Поиск: Иностранный участник сделки"
            Case MemberKind.IsCargo : Me.Text = "Поиск: Грузополучатель"
            Case MemberKind.IsSupplyEnd : Me.Text = "Поиск: Потребитель (конечный пользователь)"
            Case MemberKind.IsSupplyRus : Me.Text = "Поиск: Российский участник операции"
            Case MemberKind.IsSupplyNus : Me.Text = "Поиск: Иностранный покупатель (продавец)"
            Case MemberKind.IsPerson : Me.Text = "Поиск: Представитель заказчика"
            Case MemberKind.IsDeveloper : Me.Text = "Поиск: Изготовитель (разработчик)"
            Case Else : Me.Text = "Поиск"
        End Select

        Me.CenterToScreen()

    End Sub


    ''' <summary>
    ''' Возвращает условия запроса на выборку данных по содержимому строки таблицы лиц
    ''' </summary>
    ''' <param name="Row">Строка таблицы лиц</param>
    ''' <remarks></remarks>
    Private Function GetQueryByRow(Row As DataRow) As String
        If Row Is Nothing OrElse Row.Table Is Nothing Then Return Nothing
        Dim sTmp As String = Nothing
        Dim sTmp1 As String = Nothing
        For Each Col As DataColumn In Row.Table.Columns
            sTmp1 = C2.ToText(Row(Col))
            If C2.IsText(sTmp1) Then sTmp1 = sTmp1.Replace("'", "''").Replace("*", "%")
            If Not C2.IsText(sTmp1) Then Continue For
            Select Case Col.ColumnName.ToUpper
                Case "NAMELONG" : sTmp = String.Format("nameLong LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "NAMESHORT" : sTmp = String.Format("nameShort LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "TYPEID" : sTmp = String.Format("typeId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                Case "INN" : sTmp = String.Format("inn LIKE '{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "KPP" : sTmp = String.Format("kpp LIKE '{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "PASSPORTSER" : sTmp = String.Format("passportSer LIKE '{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "PASSPORTNUM" : sTmp = String.Format("passportNum LIKE '{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "PASSPORTGIVE" : sTmp = String.Format("passportGive LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "PHONE" : sTmp = String.Format("phone LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "FAX" : sTmp = String.Format("fax LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "EMAIL" : sTmp = String.Format("email LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "WEB" : sTmp = String.Format("web LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "ADDRESSLEGALFULL" : sTmp = String.Format("addressLegalFull LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "ADDRESSLEGALCOUNTRYID" : sTmp = String.Format("addressLegalCountryId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                Case "ADDRESSLEGALTOWN" : sTmp = String.Format("addressLegalTown LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "ADDRESSFACTFULL" : sTmp = String.Format("addressFactFull LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "ADDRESSFACTCOUNTRYID" : sTmp = String.Format("addressFactCountryId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                Case "ADDRESSFACTTOWN" : sTmp = String.Format("addressFactTown LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "ADDRESSPOSTFULL" : sTmp = String.Format("addressPostFull LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
                Case "ADDRESSPOSTCOUNTRYID" : sTmp = String.Format("addressPostCountryId = {0} AND {1}", sTmp1, sTmp) : Exit Select
                Case "ADDRESSPOSTTOWN" : sTmp = String.Format("addressPostTown LIKE '%{0}%' AND {1}", sTmp1, sTmp) : Exit Select
            End Select
        Next
        If C2.IsText(sTmp) Then Return String.Format("{0} isACT = 1", sTmp)
        Return Nothing
    End Function

    Private Sub FindButtonEdit_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles FindButtonEdit.ButtonClick
        Dim sTmp As String = C2.ToText(FindButtonEdit.Text)
        If Not C2.IsText(sTmp) Then Exit Sub
        _MemberTable.Rows.Clear()
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format( _
                "SELECT id, nameShort, proDescription, isControl, memberCaption FROM vMember WHERE memberCaption LIKE '%{0}%'", _
                sTmp.Replace("'", "''").Replace("*", "%"))
            ' Поиск российского лица
            If _russiaId > 0 Then
                Cmd.CommandText = String.Format("{0} AND addressLegalCountryId = {1}", Cmd.CommandText, _russiaId)
            End If
            _MemberTable.Load(Cmd.ExecuteReader)
        End Using
        AcceptSimpleButton.Enabled = (_MemberTable.Rows.Count > 0)
        If _MemberTable.Rows.Count = 0 Then
            Cprp.DxCommon.Messages.ShowInformation("По указанным условиям поиска ничего не найдено.", "Поиск")
        Else
            MemberGridView.MoveFirst()
        End If
    End Sub

    Private Sub AcceptSimpleButton_Click(sender As Object, e As EventArgs) Handles AcceptSimpleButton.Click
        If MemberGridView.FocusedRowHandle < 0 Then Exit Sub
        Dim iTmp As Integer = C2.ToInt(MemberGridView.GetFocusedDataRow("id"))
        MemberRow = New MemberDataTable
        Using Cmd As New SqlCommand With {.Connection = _Connection}
            Cmd.CommandText = String.Format("SELECT * FROM tMember WHERE id = {0}", iTmp)
            MemberRow.Load(Cmd.ExecuteReader)
            MemberRow.Rows(0).Item("dbId") = iTmp
        End Using
        MemberRow.AcceptChanges()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub

    Private Sub MemberGridControl_DoubleClick(sender As Object, e As EventArgs) Handles MemberGridControl.DoubleClick
        AcceptSimpleButton.PerformClick()
    End Sub

End Class