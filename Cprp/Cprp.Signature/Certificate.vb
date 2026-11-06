Imports System
Imports System.Security.Cryptography.X509Certificates
Imports System.Collections.Generic
Imports System.Security.Cryptography
Imports System.Security
Imports iTextSharp.text.pdf
Imports System.IO
Imports Org.BouncyCastle.X509
Imports System.Security.Cryptography.Pkcs
Imports CryptoPro.Sharpei
Imports iTextSharp.text.pdf.security
''' <summary>
''' Сертификат цифровой подписи
''' </summary>
''' <remarks></remarks>
Public Class Certificate

    ''' <summary>
    ''' Первый сертификат из локального хранилища
    ''' </summary>
    ''' <remarks></remarks>
    Dim _Certificate As X509Certificate2 = Nothing

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.Signature.Certificate
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub New()
        '
        ' Сертификат
        '
        Dim store As X509Store = New X509Store("My", StoreLocation.CurrentUser)
        store.Open(OpenFlags.OpenExistingOnly And OpenFlags.ReadOnly)
        If store.Certificates.Count = 0 Then Throw New Exception("В локальном хранилище отсутствуют сертификаты.")
        _Certificate = store.Certificates(0)
    End Sub

    ''' <summary>
    ''' Инициализация нового экземпляра класса Cprp.Signature.Certificate
    ''' </summary>
    ''' <param name="userInfo">Строка, идентифицирующая сертификат пользователя в хранилище сертификатов</param>
    ''' <remarks></remarks>
    Public Sub New(userInfo As String)
        If String.IsNullOrWhiteSpace(userInfo) Then Throw New Exception("Не указан идентификатор пользователя.")
        Dim store As X509Store = New X509Store("My", StoreLocation.CurrentUser)
        store.Open(OpenFlags.OpenExistingOnly And OpenFlags.ReadOnly)
        If store.Certificates.Count = 0 Then Throw New Exception("В локальном хранилище отсутствуют сертификаты.")
        userInfo = Trim(userInfo).ToUpper
        For i As Integer = 0 To store.Certificates.Count - 1
            If store.Certificates(i).Subject.ToUpper Like ("*" & userInfo & "*") Then
                _Certificate = store.Certificates(i)
                Exit For
            End If
        Next
        If _Certificate Is Nothing Then _Certificate = store.Certificates(0)
    End Sub


    ''' <summary>
    ''' Серийный номер
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property SerialNumber As String
        Get
            Return _Certificate.SerialNumber
        End Get
    End Property

    ''' <summary>
    ''' Дата вступления сертификата в силу
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property DateBegin As Date
        Get
            Return CDate(_Certificate.GetEffectiveDateString)
        End Get
    End Property

    ''' <summary>
    ''' Срок действия сертификата
    ''' </summary>
    ''' <remarks></remarks>
    Public ReadOnly Property DateEnd As Date
        Get
            Return CDate(_Certificate.GetExpirationDateString)
        End Get
    End Property

    Private _userFio As String = Nothing
    ''' <summary>
    ''' ФИО владельца
    ''' </summary>
    Public ReadOnly Property UserFio As String
        Get
            Return _userFio
        End Get
    End Property

    Private _userEmail As String = Nothing
    ''' <summary>
    ''' Email владельца
    ''' </summary>
    Public ReadOnly Property UserEmail As String
        Get
            Return _userEmail
        End Get
    End Property

    Private _reason As String = Nothing
    ''' <summary>
    ''' Причина
    ''' </summary>
    Public Property Reason As String
        Get
            Return _reason
        End Get
        Set(value As String)
            _reason = value
        End Set
    End Property

    Private _location As String = Nothing
    ''' <summary>
    ''' Месторасположение
    ''' </summary>
    Public Property Location As String
        Get
            Return _location
        End Get
        Set(value As String)
            _location = value
        End Set
    End Property

    Private _contact As String = Nothing
    ''' <summary>
    ''' Контактная информация
    ''' </summary>
    Public Property Contact As String
        Get
            Return _contact
        End Get
        Set(value As String)
            _contact = value
        End Set
    End Property

    ''' <summary>
    ''' Подписать файл PDF
    ''' </summary>
    ''' <param name="filePath">Путь к файлу</param>
    ''' <param name="pin">ПИН-код сертификата</param> 
    ''' <param name="signDate">Дата подписания</param> 
    ''' <remarks></remarks>
    Public Sub SignPdf(filePath As String, pin As String, signDate As Date)
        If String.IsNullOrWhiteSpace(filePath) Then
            Throw New Exception("Не указан путь к файлу PDF.")
        End If
        If Not My.Computer.FileSystem.FileExists(filePath) Then
            Throw New Exception("Файл PDF не найден.")
        End If
        If String.IsNullOrWhiteSpace(pin) Then
            Throw New Exception("Не указан пин-код.")
        End If

        Dim cert_key As Gost3410_2012_256CryptoServiceProvider = CType(_Certificate.PrivateKey, Gost3410_2012_256CryptoServiceProvider)

        Dim cspParameters As New CspParameters
        ' копируем параметры csp из исходного контекста сертификата
        cspParameters.KeyContainerName = cert_key.CspKeyContainerInfo.KeyContainerName
        cspParameters.ProviderType = cert_key.CspKeyContainerInfo.ProviderType
        cspParameters.ProviderName = cert_key.CspKeyContainerInfo.ProviderName
        cspParameters.Flags = If(cert_key.CspKeyContainerInfo.MachineKeyStore, _
            (CspProviderFlags.UseExistingKey And CspProviderFlags.UseMachineKeyStore), CspProviderFlags.UseExistingKey)
        cspParameters.KeyPassword = New SecureString
        For Each c As Char In pin
            cspParameters.KeyPassword.AppendChar(c)
        Next
        ' создаем новый контекст сертификат, поскольку исходный открыт readonly
        Dim cert As New X509Certificate2(_Certificate.RawData)
        ' задаем криптопровайдер с установленным паролем
        cert.PrivateKey = New Gost3410_2012_256CryptoServiceProvider(cspParameters)
        Dim sTmp As String = Nothing
        With My.Computer.FileSystem
            sTmp = .GetTempFileName
            .CopyFile(filePath, sTmp, True)
        End With
        Dim reader = New PdfReader(sTmp)
        Dim st As PdfStamper = PdfStamper.CreateSignature(reader, New FileStream(filePath, FileMode.Open, FileAccess.Write), "1")
        Dim sap As PdfSignatureAppearance = st.SignatureAppearance

        ' Загружаем сертификат в объект iTextSharp
        sap.Certificate = New X509CertificateParser().ReadCertificate(cert.RawData)
        sap.Acro6Layers = True
        sap.SignDate = Date.Now

        ' Выбираем подходящий тип фильтра
        Dim filterName As New PdfName("CryptoPro PDF")

        ' Создаем подпись
        Dim dic As New PdfSignature(filterName, PdfName.ADBE_PKCS7_DETACHED)
        dic.Date = New PdfDate(signDate)
        dic.Reason = Me.Reason
        dic.Location = Me.Location
        dic.Contact = Me.Contact
        sap.CryptoDictionary = dic

        Dim intCSize As Integer = 40000
        Dim hashtable As New Dictionary(Of PdfName, Integer)
        hashtable(PdfName.CONTENTS) = intCSize * 2 + 4
        sap.PreClose(hashtable)
        Dim s As Stream = sap.GetRangeStream()
        Dim ss As New MemoryStream()
        Dim read As Integer = 0
        Dim buff(8192) As Byte
        Do
            read = s.Read(buff, 0, 8192)
            If read <= 0 Then Exit Do
            ss.Write(buff, 0, read)
        Loop

        ' Вычисляем подпись
        Dim contentInfo As New ContentInfo(ss.ToArray())
        Dim signedCms As New SignedCms(contentInfo, True)
        Dim cmsSigner = New CmsSigner(cert)
        signedCms.ComputeSignature(cmsSigner, False)
        Dim pk() As Byte = signedCms.Encode()

        ' Помещаем подпись в документ
        Dim outc(intCSize) As Byte
        Dim dic2 As New PdfDictionary()
        Array.Copy(pk, 0, outc, 0, pk.Length)
        dic2.Put(PdfName.CONTENTS, New PdfString(outc).SetHexWriting(True))
        sap.Close(dic2)

        'My.Computer.FileSystem.DeleteFile(filePath & ".stmp")
        My.Computer.FileSystem.DeleteFile(sTmp)

    End Sub

End Class
