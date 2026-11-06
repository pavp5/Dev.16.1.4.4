''' <summary>
''' Таблица сведений о контролируемых товарах и заключениях
''' </summary>
Public Class FInfoDataTable : Inherits Cprp.DxData.Base.ConnectionDataTable


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="Connection">Открытое соединение с базой данных</param>
    Public Sub New(Connection As SqlConnection)
        MyBase.New(Connection, "FInfoTable")
        With Me.Columns
            .Add("id", GetType(Integer))            ' id
            .Add("docNum", GetType(String))         ' номер заключения
            .Add("docDate", GetType(Date))          ' дата заключения
            .Add("orgId", GetType(Integer))         ' id экспертной организации
            .Add("conNum", GetType(String))         ' номер контракта
            .Add("conDate", GetType(Date))          ' дата контракта
            .Add("rusCaption", GetType(String))     ' российский участник
            .Add("rusInn", GetType(String))         ' ИНН российского участника
            .Add("nusCaption", GetType(String))     ' иностранный участник
            .Add("nusCountryId", GetType(Integer))  ' id страны иностранного участника
            .Add("endCaption", GetType(String))     ' конечный пользователь
            .Add("endCountryId", GetType(Integer))  ' id страны конечного пользователя
            .Add("countryId", GetType(Integer))     ' id страны назначения
            .Add("goodName", GetType(String))       ' наименование товара
            .Add("goodNameFind", GetType(String))   ' буквы и цифры из наименования товара
            .Add("goodTnved", GetType(String))      ' код ТН ВЭД товара
            .Add("goodListPos", GetType(String))    ' перечень пунктов контрольных списков
            .Add("summary", GetType(String))        ' выводы экспертизы
            .Add("summaryId", GetType(Integer))     ' id выводов экспертизы
            .Add("actDate", GetType(Date))          ' дата последней актуализации записи
            ' дополнительные поля для загрузки данных из базы EXDB8
            .Add("goodId", GetType(Integer))
            .Add("studyId", GetType(Integer))
            .Add("workId", GetType(Integer))
            .Add("docId", GetType(Integer))
            .Add("countryName", GetType(String))
        End With
        With Me.Columns("id")
            .AllowDBNull = False
            .AutoIncrement = True
            .AutoIncrementSeed = 1
            .AutoIncrementStep = 1
        End With
        Me.PrimaryKey = New DataColumn() {Me.Columns("id")}

    End Sub


    ''' <summary>
    ''' Сохранить данные в базу данных
    ''' </summary>
    Public Sub SaveToBase()
        Dim actDate As Date = Date.Now
        For Each Row As DataRow In Me.Rows
            If Row.RowState = DataRowState.Added OrElse Row.RowState = DataRowState.Modified Then
                Row("actDate") = actDate
            End If
        Next
        Using A As New SqlDataAdapter("SELECT * FROM tFInfo", MyBase.Connection)
            Dim B As New SqlCommandBuilder(A)
            A.Update(Me)
        End Using
    End Sub

End Class
