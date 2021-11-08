Public Class FrmEmailPassword

    Public From_SendMail As Boolean
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    '***************************************************** K E Y D O W N *********************************************
    Private Sub TxtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtPassword.Text = "" Then
                MsgBox("Please fill password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            btnSend.Focus()
        ElseIf e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Delete Then
            Close()
        End If
    End Sub
    '***************************************************** K E Y D O W N *********************************************

    '***************************************************** L E A V E *************************************************
    Private Sub TxtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        txtPassword.Text = ReplaceText(txtPassword.Text)

        If txtPassword.Text = "" Then
            MsgBox("Please fill password", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
    End Sub
    '***************************************************** L E A V E *************************************************

    Private Sub BtnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If txtPassword.Text = "" Then
            MsgBox("Please fill password", MsgBoxStyle.Information, "Info")
            txtPassword.Focus()
            Exit Sub
        End If

        If From_SendMail Then
            If btnSend.DialogResult = DialogResult.OK Then
            Else
                btnSend.DialogResult = DialogResult.OK
                btnSend.PerformClick()
            End If
        Else
            AppPassword = txtPassword.Text
            Close()
        End If
    End Sub

    Private Sub FrmEmailPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        If From_SendMail Then
        Else
            txtEmail.Text = Empl_Email
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX14})

            GetLabelFontSettingsDefault({LabelX1, LabelX7, LabelX2})

            GetTextBoxFontSettings({txtEmail, txtPassword})

            GetButtonFontSettings({btnSend, btnClose})
        Catch ex As Exception
            TriggerBugReport("Email Password - Fix UI", ex.Message.ToString)
        End Try
    End Sub
End Class