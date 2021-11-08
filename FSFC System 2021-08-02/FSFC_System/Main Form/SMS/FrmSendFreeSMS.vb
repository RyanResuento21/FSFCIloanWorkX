Public Class FrmSendFreeSMS

    Private Sub FrmSendFreeSMS_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX3, LabelX16})

            GetTextBoxFontSettings({txtPlus63, txtMobileN})

            GetRickTextBoxFontSettings({txtMessage})

            GetButtonFontSettings({btnSend, btnRefresh, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Send Free SMS - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Free SMS", lblTitle.Text)
    End Sub

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If txtMobileN.Text.Trim = "" Or txtMobileN.Text.Trim.Length <> 10 Or IsNumeric(txtMobileN.Text.Trim) = False Then
            MsgBox("Please fill a correct mobile number to proceed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to send this message?") = MsgBoxResult.Yes Then
            SendSMS(txtMobileN.Text, txtMessage.Text, False)
            Logs("Free SMS", "Send", String.Format("Send SMS to {0} with {1} message.", "+63" & txtMobileN.Text, txtMessage.Text), "", "", "", "")
            MsgBox("Your message will be send ASAP.", MsgBoxStyle.Information, "Info")
            Clear()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Public Sub Clear()
        txtMobileN.Text = ""
        txtMessage.Text = ""
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
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtMobileN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobileN.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMessage.Focus()
        End If
    End Sub

    Private Sub TxtMessage_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMessage.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSend.Focus()
            btnSend.PerformClick()
        End If
    End Sub

    Private Sub TxtMessage_Leave(sender As Object, e As EventArgs) Handles txtMessage.Leave
        txtMessage.Text = ReplaceText(txtMessage.Text)
    End Sub
End Class