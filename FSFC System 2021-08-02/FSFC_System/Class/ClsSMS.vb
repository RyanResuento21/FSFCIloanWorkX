Imports System.IO.Ports
Imports System.Threading
Imports System.Text
Imports System.Text.RegularExpressions

Public Class ClsSMS
    Private Declare Sub Sleep Lib "kernel32" (milsec As Long)
    Public receiveNow As New AutoResetEvent(False)
    Shared ReadOnly readNow As New AutoResetEvent(False)

    Public Function OpenPort(comport As String) As SerialPort
        Dim SerialPort As New SerialPort

        Try
            If comport <> Nothing Then
                With SerialPort
                    .PortName = comport
                    .BaudRate = 96000
                    .Parity = Parity.None
                    .DataBits = 8
                    .StopBits = StopBits.One
                    .Handshake = Handshake.RequestToSend
                    .ReadTimeout = 300
                    .WriteTimeout = 300
                    .Encoding = Encoding.GetEncoding("ISO-8859-1")
                    .DtrEnable = True
                    .RtsEnable = True
                    .NewLine = vbCrLf
                End With
                SerialPort.Open()
                FrmMain.cbxPort.Enabled = False
                Return SerialPort
            Else
                FrmMain.cbxPort.Enabled = False
                Return SerialPort
            End If
        Catch ex As Exception
            FrmMain.cbxPort.Enabled = True
            Return Nothing
            TriggerBugReport("Class SMS - Open Port", ex.Message.ToString)
        End Try
    End Function

    Public Sub ClosePort(SerialPort As SerialPort)
        Try
            SerialPort.Close()
        Catch ex As Exception
            TriggerBugReport("Class SMS - Close Port", ex.Message.ToString)
        End Try
    End Sub

    Public Sub Port_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        If e.EventType = SerialData.Chars Then
            receiveNow.Set()
        End If
    End Sub

    Private Shared Sub DataReceived(sender As Object, e As SerialDataReceivedEventArgs)
        If e.EventType = SerialData.Chars Then
            readNow.Set()
        End If
    End Sub

    Public Function ExecCommand(Port As SerialPort, strcommand As String, errmess As String)
        Try
            Port.WriteLine(strcommand)
            'ConnSMS.SendMsg.Text = ConnSMS.SendMsg.Text & strcommand
            Dim Input As String = ReadResponse(Port)
            'FrmSendSMS.txtStatus.Text = FrmSendSMS.txtStatus.Text & Input
            Return Input
        Catch ex As Exception
            Return errmess
            TriggerBugReport("Class SMS - Exec Command", ex.Message.ToString)
        End Try
    End Function

    Public Function ReadResponse(Port As SerialPort)
        Dim buff As String = ""
        Try
            Do
                Dim t As String = Port.ReadExisting()
                buff &= t
            Loop Until buff.EndsWith(vbCrLf & "OK" & vbCrLf) Or buff.EndsWith(vbCrLf & "> ") Or buff.EndsWith(vbCrLf & "ERROR" & vbCrLf)
        Catch ex As Exception
            TriggerBugReport("Class SMS - ReadResponse", ex.Message.ToString)
        End Try
        Return buff
    End Function

    Public Function SendSMS(Port As SerialPort, PhoneNo As String, Message As String) As Boolean
        Dim isSent As Boolean

        Dim receivedData As String = ExecCommand(Port, "AT" & vbCr, "Unable to connect.")
        Thread.Sleep(200)
        receivedData = ExecCommand(Port, "AT+CMGF=1" & vbCr, "Failed to set message format.")
        Thread.Sleep(200)
        receivedData = ExecCommand(Port, "AT+CMGS=" & Chr(34) & PhoneNo & Chr(34) & vbCr, "Failed to accept phoneNo")
        Thread.Sleep(200)
        receivedData = ExecCommand(Port, vbBack & vbBack & Message & Chr(26), "Failed to send message")
        Thread.Sleep(200)

        If receivedData.EndsWith(vbCrLf & "OK" & vbCrLf) Then
            isSent = True
        ElseIf receivedData.Contains("ERROR") Then
            isSent = False
        End If
        Return isSent
    End Function

    Public Function ReadSMS(Port As SerialPort)
        Dim messages As ClsSMS_ShortMessageCollection
        Dim receivedData As String

        receivedData = ExecCommand(Port, "AT" & vbCr, "Unable to connect.")
        Thread.Sleep(200)
        receivedData = ExecCommand(Port, "AT+CMGF=1" & vbCr, "Failed to set message format.")
        Thread.Sleep(200)
        receivedData = ExecCommand(Port, "AT+CSCS=" & Chr(34) & "GSM" & Chr(34), "Failed to set character set.")
        Thread.Sleep(200)
        receivedData = ExecCommand(Port, "AT+CPMS=" & Chr(34) & "ME" & Chr(34), "Failed to select message storage.")
        Thread.Sleep(200)
        receivedData = ExecCommand(Port, "AT+CMGL=" & Chr(34) & "ALL" & Chr(34), "Failed to read all message.")
        Thread.Sleep(200)
        messages = ParseMessages(receivedData)

        If messages IsNot Nothing Then
            Return messages
        Else
            Return Nothing
        End If
    End Function

    Public Function ParseMessages(input As String) As clsSMS_ShortMessageCollection
        Dim messages As New clsSMS_ShortMessageCollection()
        Try
            Dim r As New Regex("\+CMGL: (\d+),""(.+)"",""(.+)"",(.*),""(.+)""\r\n(.+)\r\n")
            Dim m As Match = r.Match(input)
            While m.Success
                Dim msg As New ClsSMSShortMessage With {
                    .Index = m.Groups(1).Value,
                    .Status = m.Groups(2).Value,
                    .Sender = m.Groups(3).Value,
                    .Alphabet = m.Groups(4).Value,
                    .Sent = m.Groups(5).Value,
                    .Message = m.Groups(6).Value
                }
                messages.Add(msg)

                m = m.NextMatch()
            End While
        Catch ex As Exception
            TriggerBugReport("Class SMS - ParseMessage", ex.Message.ToString)
        End Try
        Return messages
    End Function
End Class
