Public Class FrmSendSMS

    Dim WithEvents SerialPort As New IO.Ports.SerialPort
    Private Declare Sub Sleep Lib "kernel32" (milsec As Long)
    ReadOnly objport As New ClsSMS
    Dim DT_Outbox As New DataTable
    Public vPrint As Boolean
    Public vDelete As Boolean

    Private Sub FrmSendSMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
            cbxPort.Items.Add(My.Computer.Ports.SerialPortNames(i))
        Next
        cbxPort.SelectedIndex = cbxPort.Items.Count - 1
        btnConnect.PerformClick()

        LoadData()
        If User_Type = "ADMIN" Then
        Else
            LabelX43.Visible = False
            cbxPort.Visible = False
            btnConnect.Visible = False
            lblStatus.Visible = False
            LabelX1.Visible = False
            txtStatus.Visible = False
        End If

        Timer_Send.Start()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX43, LabelX3, LabelX16, LabelX1})

            GetTextBoxFontSettings({txtPlus63, txtMobileN})

            GetComboBoxFontSettings({cbxPort})

            GetRickTextBoxFontSettings({txtMessage, txtStatus})

            GetButtonFontSettings({btnAdd, btnSend, btnRefresh, btnCancel, btnDelete, btnPrint, btnConnect})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Send SMS - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        If btnConnect.Text = "Disconnect" Then
            Try
                Dim objShortMessageCollection = objport.ReadSMS(SerialPort)
                Dim DT As New DataTable
                DT.Columns.Add("Message")
                For Each Msg As ClsSMSShortMessage In objShortMessageCollection
                    Dim Item As New ListViewItem(New String() {Msg.Index, Msg.Sent, Msg.Sender, Msg.Message}) With {
                        .Tag = Msg
                    }
                    DT.Rows.Add(Item)
                Next
                GridControl2.DataSource = DT
            Catch ex As Exception
                TriggerBugReport("Send SMS - Load Data", ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If txtMobileN.Text.Trim = "" Then
            MsgBox("Please fill a correct mobile number to proceed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If btnConnect.Text = "Connect" Then
            MsgBox("Please select a port to proceed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to send this message?") = MsgBoxResult.Yes Then
            If objport.SendSMS(SerialPort, txtPlus63.Text & txtMobileN.Text, txtMessage.Text.Trim) Then
                MsgBox("Message Sent!", MsgBoxStyle.Information, "Info")
            Else
                MsgBox("Message Send Failed.", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub BtnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        Try
            If btnConnect.Text = "Connect" Then
                SerialPort = objport.OpenPort(cbxPort.Text)
                If SerialPort IsNot Nothing Then
                    lblStatus.Text = "Modem is connected at PORT " & cbxPort.Text & "."
                    btnConnect.Text = "Disconnect"
                    cbxPort.Enabled = False
                    LoadData()
                Else
                    lblStatus.Text = "Invalid port settings."
                End If
            Else
                objport.ClosePort(SerialPort)
                lblStatus.Text = "Not Connected"
                btnConnect.Text = "Connect"
                cbxPort.Enabled = True
            End If
        Catch ex As Exception
            TriggerBugReport("Send SMS - Connect.Click", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Public Sub Clear()
        PanelEx10.Enabled = True
        txtMessage.Text = ""
        txtStatus.Text = ""

        LoadData()
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabInbox
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnAdd.Enabled = False
            btnSend.Enabled = True
            btnRefresh.Enabled = True
            btnPrint.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSend.Enabled = False
            btnRefresh.Enabled = False
            btnPrint.Enabled = True
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSend.Focus()
            btnSend.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.B Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        GridView2.OptionsPrint.UsePrintStyles = False
        StandardPrinting("Message List", GridControl2)
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub

    Private Sub Timer_Send_Tick(sender As Object, e As EventArgs) Handles Timer_Send.Tick
        Try
            DT_Outbox = DataSource(String.Format("SELECT ID, PhoneN, Message FROM SMS_Outbox WHERE `status` = 'ACTIVE' AND send_status = 'PENDING';"))
            If DT_Outbox.Rows.Count > 0 Then
                For x As Integer = 0 To DT_Outbox.Rows.Count - 1
                    If objport.SendSMS(SerialPort, "+63" & DT_Outbox(x)("PhoneN"), DT_Outbox(x)("Message")) Then
                        DataObject(String.Format("UPDATE SMS_Outbox SET send_status = 'SENT' WHERE ID = '{0}';", DT_Outbox(x)("ID")))
                        MsgBox("Message Sent!", MsgBoxStyle.Information, "Info")
                    Else
                        MsgBox("Message Send Failed.", MsgBoxStyle.Information, "Info")
                    End If
                Next
            End If
        Catch ex As Exception
            TriggerBugReport("Send SMS - Tick", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CbxPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPort.SelectedIndexChanged

    End Sub
End Class