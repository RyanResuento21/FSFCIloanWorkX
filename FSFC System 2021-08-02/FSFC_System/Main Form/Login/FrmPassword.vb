Public Class FrmPassword

    Public ShowMessage As Boolean
    Private Sub FrmPassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX3})

            GetLabelFontSettingsRed({lblNote})

            GetTextBoxFontSettings({txtPassword})

            GetButtonFontSettings({btnOK, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Password - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOK.PerformClick()
        End If
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If btnOK.DialogResult = DialogResult.OK Then
        Else
            If ShowMessage Then
                If txtPassword.Text.Length < PWLength Then
                    MsgBox(String.Format("Password must have at least {0} characters.", PWLength), MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf PWCase And (txtPassword.Text Like "*[A-Z]*" = False Or txtPassword.Text Like "*[a-z]*" = False) Then
                    MsgBox("Password must have Upper and Lower Case Letters.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf PWSpecial And ContainsSpecial(txtPassword.Text) = False Then
                    MsgBox("Password must have special characters.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf PWNumeric And ContainsNumeric(txtPassword.Text) = False Then
                    MsgBox("Password must have numeric characters.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If MsgBoxYes("Are you sure you want to reset the password?") = MsgBoxResult.Yes Then
                    btnOK.DialogResult = DialogResult.OK
                    btnOK.PerformClick()
                End If
            Else
                btnOK.DialogResult = DialogResult.OK
                btnOK.PerformClick()
            End If
        End If
    End Sub

    Private Sub FrmPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.KeyCode = Keys.Escape Or (e.Control And e.KeyCode = Keys.X) Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.O Then
            btnOK.Focus()
            btnOK.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class