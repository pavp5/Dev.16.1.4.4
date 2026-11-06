Imports C2 = Cprp.DxData.Common
''' <summary>
''' Элемент управления для редактирования данных работы
''' </summary>
''' <remarks></remarks>
Public Class WorkUserControl : Inherits DevExpress.XtraEditors.XtraUserControl

    ''' <summary>
    ''' Работа
    ''' </summary>
    Public Property Work As WorkConnectionRow = Nothing

    ''' <summary>
    ''' Клиент для выполнения http-запросов
    ''' </summary>
    Public Shared HClient As System.Net.WebClient = Nothing

    ''' <summary>
    ''' Дата открытия элемента пользователем
    ''' </summary>
    Public Property OpenDate As DateTime = Date.Now

    ''' <summary>
    ''' Элемент открывается на рабочем месте эксперта
    ''' </summary>
    Public Property IsExpertControl As Boolean = False

    ''' <summary>
    ''' Таблица сбое в работе приложения
    ''' </summary>
    Public Property AppErrorTable As Cprp.DxData.ErrorDataTable = Nothing

    ''' <summary>
    ''' Элемент управления содержит непустую работу
    ''' </summary>
    Public ReadOnly Property WorkDataExist() As Boolean
        Get
            If Me.Work Is Nothing Then Return False
            If Me.Work.IsEmpty Then Return False
            Return True
        End Get
    End Property

#Region "Текущий пользователь и его права"

    ''' <summary>
    ''' Текущий пользователь
    ''' </summary>
    Public CurrentUser As Cprp.DxData.User.DatabaseUser = Nothing


    ''' <summary>
    ''' Обновить реквизиты работы данными из базы
    ''' </summary>
    Public Sub WorkFieldUpdate()
        If Not WorkDataExist Then Exit Sub
        Using Dr As SqlDataReader = Me.Work.ExecuteReader(String.Format("SELECT conditionId, expertId, leaderId FROM tWork WHERE id = {0}", C2.ToInt(Me.Work.Id)))
            If Dr.Read Then
                Me.Work("conditionId") = Dr("conditionId")
                Me.Work("expertId") = Dr("expertId")
                Me.Work("leaderId") = Dr("leaderId")
            End If
        End Using
    End Sub


    ''' <summary>
    ''' Текущий пользователь является экспертом в работе
    ''' </summary>
    Public ReadOnly Property CurrentUserIsWorkExpert As Boolean
        Get
            If CurrentUser Is Nothing Then Return False
            If Not WorkDataExist Then Return False
            Return (C2.ToInt(Work("expertId")) = CurrentUser.Id)
        End Get
    End Property

    ''' <summary>
    ''' Текущий пользователь является руководителем в работе
    ''' </summary>
    Public ReadOnly Property CurrentUserIsWorkLeader As Boolean
        Get
            If CurrentUser Is Nothing Then Return False
            If Not WorkDataExist Then Return False
            Return (C2.ToInt(Work("leaderId")) = CurrentUser.Id)
        End Get
    End Property

    ''' <summary>
    ''' Работа доступна текущему пользователю для редактирования в режиме эксперта
    ''' </summary>
    Public ReadOnly Property WorkEditableForExpert As Boolean
        Get
            If CurrentUser Is Nothing OrElse Not CurrentUser.IsExpert Then Return False
            If Not WorkDataExist Then Return False
            WorkFieldUpdate()
            ' Новая работа
            If Work.Condition = WorkCondition.IsNew Then Return False
            ' Не новая работа
            If Not CurrentUserIsWorkExpert Then Return False
            'If CBool(Work("isAsk")) Then Return False
            Return (Work.Condition = WorkCondition.IsWork OrElse Work.Condition = WorkCondition.IsQuery)
        End Get
    End Property

    ''' <summary>
    ''' План работы доступен текущему пользователю для редактирования в режиме эксперта
    ''' </summary>
    Public ReadOnly Property PlaneEditableForExpert As Boolean
        Get
            If CurrentUser Is Nothing OrElse Not CurrentUser.IsExpert Then Return False
            If Not WorkDataExist Then Return False
            WorkFieldUpdate()
            If Not CurrentUserIsWorkExpert Then Return False
            'If CBool(Work("isAsk")) Then Return False
            Return (Work.Condition = WorkCondition.IsPlaneWork OrElse Work.Condition = WorkCondition.IsPlaneQuery)
        End Get
    End Property

    ''' <summary>
    ''' Работа доступна текущему пользователю для редактирования в режиме руководителя
    ''' </summary>
    Public ReadOnly Property WorkEditableForLeader As Boolean
        Get
            If CurrentUser Is Nothing Then Return False
            If Not WorkDataExist Then Return False
            WorkFieldUpdate()
            If Not (CurrentUser.IsLeader OrElse CurrentUser.IsChief OrElse CurrentUser.IsSubleader) Then Return False
            'If CBool(Work("isAsk")) Then Return True
            Return (Work.Condition = WorkCondition.IsCheck OrElse Work.Condition = WorkCondition.IsAgree)
        End Get
    End Property

    ''' <summary>
    ''' План работы доступен текущему пользователю для редактирования в режиме руководителя
    ''' </summary>
    Public ReadOnly Property PlaneEditableForLeader As Boolean
        Get
            If CurrentUser Is Nothing Then Return False
            If Not WorkDataExist Then Return False
            WorkFieldUpdate()
            If Not (CurrentUser.IsLeader OrElse CurrentUser.IsChief OrElse CurrentUser.IsSubleader) Then Return False
            'If CBool(Work("isAsk")) Then Return True
            Return (Work.Condition = WorkCondition.IsPlaneWork OrElse Work.Condition = WorkCondition.IsPlaneAgree)
        End Get
    End Property

#End Region

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.WorkUserControl
    ''' </summary>
    Public Sub New()
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.WorkUserControl
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <param name="isExpertControl">Элемент открывается на рабочем месте эксперта</param>
    Public Sub New(Work As WorkConnectionRow, Optional isExpertControl As Boolean = False)
        MyClass.Work = Work
        If WorkDataExist Then
            CurrentUser = New Cprp.DxData.User.DatabaseUser(MyClass.Work.Connection)
        End If
        Me.IsExpertControl = isExpertControl
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.DxData.Work.WorkUserControl
    ''' </summary>
    ''' <param name="Work">Работа</param>
    ''' <param name="isExpertControl">Элемент открывается на рабочем месте эксперта</param>
    Public Sub New(Work As WorkConnectionRow, CurrentUser As Cprp.DxData.User.DatabaseUser, Optional isExpertControl As Boolean = False)
        MyClass.Work = Work
        MyClass.CurrentUser = CurrentUser
        If MyClass.CurrentUser Is Nothing AndAlso WorkDataExist Then
            MyClass.CurrentUser = New Cprp.DxData.User.DatabaseUser(MyClass.Work.Connection)
        End If
        Me.IsExpertControl = isExpertControl
    End Sub


    ''' <summary>
    ''' Данные проверены на сохранение после изменения
    ''' </summary>
    Public Overridable ReadOnly Property IsCheckDataSaved As Boolean
        Get
            Return True
        End Get
    End Property

    ''' <summary>
    ''' Делегирование себе работы руководителем экспертизы
    ''' </summary>
    Protected Function WorkDelegate() As Boolean
        '
        ' Реквизиты текущего пользователя (нового руководителя экспертизы)
        '
        Dim newId As Integer = C2.ToInt(Cprp.DxData.User.Common.CurrentUserId(MyClass.Work.Connection))
        If newId < 0 Then Return False
        Dim newName As String = Nothing
        Dim newEmail As String = Nothing
        Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", C2.ToInt(newId)))
            If Dr.Read Then
                newName = C2.ToText(Dr("nameShort"))
                newEmail = C2.ToText(Dr("email"))
            End If
        End Using
        '
        ' Реквизиты старого руководителя экспертизы
        '
        Dim oldId As Integer = C2.ToInt(MyClass.Work.ExecuteScalar(String.Format("SELECT leaderId FROM tWork WHERE id = {0}", CInt(MyClass.Work.Id))))
        If newId = oldId Then Return True
        Dim oldName As String = Nothing
        Dim oldEmail As String = Nothing
        Using Dr As SqlDataReader = MyClass.Work.ExecuteReader(String.Format("SELECT nameShort, email FROM tUser WHERE id = {0}", C2.ToInt(oldId)))
            If Dr.Read Then
                oldName = C2.ToText(Dr("nameShort"))
                oldEmail = C2.ToText(Dr("email"))
            End If
        End Using
        '
        ' Вопрос о делегировании работы
        '
        If oldId > 0 AndAlso Cprp.DxCommon.Messages.ShowQuestion(String.Format( _
            "Руководителем работы № {0} является {1} Делегировать работу Вам?", CInt(MyClass.Work.Id), oldName), _
            "Вопрос") <> DialogResult.Yes Then Return False
        '
        ' Делегирование работы
        '
        MyClass.Work.ExecuteNonQuery(String.Format("UPDATE tWork SET leaderId = {0} WHERE id = {1}", newId, CInt(MyClass.Work.Id)))
        MyClass.Work("leaderId") = newId
        '
        ' Запись в историю работы 
        '
        Dim comment As String = Nothing
        If C2.IsText(oldName) Then
            comment = String.Format("Делегирование работы от ""{0}"" к ""{1}""", oldName, newName)
        Else
            comment = String.Format("Делегирование работы руководителю ""{0}""", newName)
        End If
        MyClass.Work.WriteHistory(WorkEvent.ChangeLeader, comment)
        '
        ' Создание уведомления старому руководителю о делегировании его работы
        '
        If C2.IsText(oldEmail) Then
            Dim sHost As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPHOST", MyClass.Work.Connection)
            Dim sPort As String = Cprp.DxData.Resource.Resource.GetStrData("SMTPPORT", MyClass.Work.Connection)
            If Not C2.IsText(newEmail) Then newEmail = "system@excont.ru"
            Dim sCaption As String = String.Format("ДЕЛЕГИРОВАНИЕ РАБОТЫ (Работа № {0})", CInt(MyClass.Work.Id))
            Dim sBody As String = String.Format("{0} делегировал себе Вашу работу № {1}.", newName, CInt(MyClass.Work.Id))
            Using S As New System.Net.Mail.SmtpClient(sHost, CInt(sPort))
                S.Send(newEmail, oldEmail, sCaption, sBody)
            End Using
        End If

        Return True

    End Function

    ''' <summary>
    ''' Показать историю работы
    ''' </summary>
    Protected Sub WorkHistoryShow()
        With New WorkHistoryForm(Work)
            .ShowDialog()
        End With
    End Sub

    ''' <summary>
    ''' Показать стоимость работы
    ''' </summary>
    Protected Sub WorkCalcShowNew()
        Dim price As Single = C2.ToSng(Work("price"))
        Cprp.DxCommon.Messages.ShowInformation(String.Format("Стоимость работы:{0:c2}.", price), String.Format("Работа № {0}", CInt(Work.Id)))
    End Sub

    ''' <summary>
    ''' Показать стоимость работы
    ''' </summary>
    Protected Sub WorkCalcShow()
        With New WorkCalcForm(Work)
            .ShowDialog()
        End With
    End Sub

    ''' <summary>
    ''' Перечитать состояние элементов
    ''' </summary>
    Public Overridable Sub LockUpdate()
        Exit Sub
    End Sub

End Class
