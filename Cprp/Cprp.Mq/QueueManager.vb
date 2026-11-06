Imports IBM.WMQ
''' <summary>
''' Работа с менеджером очередей IBM MQ
''' </summary>
Public Class QueueManager

    ''' <summary>
    ''' Очередь исходящих сообщений
    ''' </summary>
    Public Enum OutQueue
        ''' <summary>Первая очередь</summary>
        Queue1 = 1
        ''' <summary>Вторая очередь</summary>
        Queue2 = 2
    End Enum


    ''' <summary>
    ''' Менеджер очередей
    ''' </summary>
    Private QManager As MQQueueManager = Nothing

    ''' <summary>
    ''' Очередь входящих сообщений
    ''' </summary>
    Private InQueue As MQQueue = Nothing

    ''' <summary>
    ''' Первая очередь исходящих сообщений
    ''' </summary>
    Private Out1Queue As MQQueue = Nothing

    ''' <summary>
    ''' Вторая очередь исходящих сообщений
    ''' </summary>
    Private Out2Queue As MQQueue = Nothing


    ''' <summary>
    ''' New
    ''' </summary>
    ''' <param name="hostName">Имя хоста</param>
    ''' <param name="port">Порт</param>
    ''' <param name="channelName">Имя канала</param>
    ''' <param name="queueManagerName">Имя менеджера очередей</param>
    ''' <param name="inQueueName">Имя очереди входящих сообщений</param> 
    ''' <param name="out1QueueName">Имя первой очереди исходящих сообщений</param> 
    ''' <param name="out2QueueName">Имя второй очереди исходящих сообщений</param> 
    ''' <remarks></remarks>
    Public Sub New(hostName As String, port As Integer, channelName As String, queueManagerName As String, inQueueName As String, out1QueueName As String, out2QueueName As String)
        MQEnvironment.Hostname = hostName
        MQEnvironment.Port = port
        MQEnvironment.Channel = channelName
        QManager = New MQQueueManager(queueManagerName)
        If Cprp.DxData.Common.IsText(inQueueName) Then
            InQueue = QManager.AccessQueue(inQueueName, MQC.MQOO_INPUT_AS_Q_DEF + MQC.MQOO_FAIL_IF_QUIESCING)
        End If
        If Cprp.DxData.Common.IsText(out1QueueName) Then
            Out1Queue = QManager.AccessQueue(out1QueueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING)
        End If
        If Cprp.DxData.Common.IsText(out2QueueName) Then
            Out2Queue = QManager.AccessQueue(out2QueueName, MQC.MQOO_OUTPUT + MQC.MQOO_FAIL_IF_QUIESCING)
        End If
    End Sub


    ''' <summary>
    ''' Записать сообщение в очередь
    ''' </summary>
    ''' <param name="Queue">Очередь исходящих сообщений</param> 
    ''' <param name="message">Текст сообщения</param>
    Public Sub Write(queue As OutQueue, message As String)
        Try
            If String.IsNullOrWhiteSpace(message) Then Exit Sub
            Dim QMessage As New MQMessage
            QMessage.CharacterSet = 1208
            QMessage.WriteString(message)
            QMessage.Format = MQC.MQFMT_STRING
            Select Case queue
                Case OutQueue.Queue1 : Out1Queue.Put(QMessage)
                Case OutQueue.Queue2 : Out2Queue.Put(QMessage)
            End Select
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Получить первое сообщение из очереди
    ''' </summary>
    Public Function Read() As String
        Dim message As String = Nothing
        Dim QMessage As New MQMessage
        QMessage.CharacterSet = 1208
        Do
            Try
                QMessage.ClearMessage()
                InQueue.Get(QMessage)
                If QMessage.Format.CompareTo(MQC.MQFMT_STRING) = 0 Then
                    message = QMessage.ReadString(QMessage.MessageLength)
                    Exit Do
                End If
            Catch qex As MQException
                If qex.Reason = MQC.MQRC_NO_MSG_AVAILABLE Then
                    Exit Do
                Else
                    Throw qex
                End If
            Catch ex As Exception
                Throw ex
            End Try
        Loop
        Return message
    End Function

End Class
