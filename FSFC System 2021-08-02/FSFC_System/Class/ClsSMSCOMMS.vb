Imports System.Threading
Imports System.IO.Ports

Public Class ClsSMSCOMMS
    Private WithEvents SMSPort As New SerialPort

    'Private SMSThread As Thread
    ReadOnly ReadThread As Thread
    Shared _Continue As Boolean = False
    Shared _ContSMS As Boolean = False
    Private _Wait As Boolean = False
    Shared ReadOnly _ReadPort As Boolean = False
    Public Event Sending(Done As Boolean)
    Public Event DataReceived(Message As String)

    Public Sub New(ByRef COMMPORT As String)
        SMSPort = New SerialPort
        With SMSPort
            .PortName = COMMPORT
            .BaudRate = 9600
            .Parity = Parity.None
            .DataBits = 8
            .StopBits = StopBits.One
            .Handshake = Handshake.RequestToSend
            .DtrEnable = True
            .RtsEnable = True
            .NewLine = vbCrLf
            .WriteTimeout = 5000
        End With
        ReadThread = New Thread(AddressOf ReadPort)
        AddHandler SMSPort.DataReceived, AddressOf Port_DataReceived
    End Sub

    Private Sub Port_DataReceived(sender As Object, e As SerialDataReceivedEventArgs)

    End Sub

    Public Sub SendSMS(CellNumber As String, SMSMessage As String)
        Dim MyMessage As String
        If SMSMessage.Length <= 160 Then
            MyMessage = SMSMessage
        Else
            MyMessage = Mid(SMSMessage, 1, 160)
        End If
        If IsOpen = True Then
            SMSPort.WriteLine("AT" & vbCrLf)
            SMSPort.WriteLine("AT+CMGF=1" & vbCrLf)
            SMSPort.WriteLine("AT+CMGS=" & Chr(34) & CellNumber & Chr(34) & vbCrLf)
            _ContSMS = False
            SMSPort.WriteLine(MyMessage & vbCrLf & Chr(26))
            _Continue = False
            RaiseEvent Sending(False)

            MsgBox("Message Sent!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub ReadPort()
        Dim SerialIn As String = ""
        Dim RXBuffer(SMSPort.ReadBufferSize) As Byte

        While SMSPort.IsOpen = True
            If (SMSPort.BytesToRead <> 0) And (SMSPort.IsOpen = True) Then
                While SMSPort.BytesToRead <> 0
                    SMSPort.Read(RXBuffer, 0, SMSPort.ReadBufferSize)
                    SerialIn &= Text.Encoding.ASCII.GetString(RXBuffer)
                    If SerialIn.Contains(">") = True Then
                        _ContSMS = True
                    End If
                    If SerialIn.Contains("+CMGS:") = True Then
                        _Continue = True
                        RaiseEvent Sending(True)
                        _Wait = False
                        SerialIn = String.Empty
                        ReDim RXBuffer(SMSPort.ReadBufferSize)
                    End If
                End While
                RaiseEvent DataReceived(SerialIn)
                SerialIn = String.Empty
                ReDim RXBuffer(SMSPort.ReadBufferSize)
            End If
        End While
    End Sub

    Public ReadOnly Property IsOpen() As Boolean
        Get
            If SMSPort.IsOpen = True Then
                IsOpen = True
            Else
                IsOpen = False
            End If
        End Get
    End Property

    Public Sub Open()
        If IsOpen = False Then
            SMSPort.Open()
            ReadThread.Start()
        End If
    End Sub

    Public Sub Close()
        If IsOpen = True Then
            SMSPort.Close()
        End If
    End Sub
End Class
