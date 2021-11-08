
Public Class FrmChangePassword
    Public OldP As String

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Change Password", lblTitle.Text)
    End Sub

    '******************************************** K E Y D O W N **************************************************
    Private Sub TxtUserName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtUserType.Focus()
        End If
    End Sub

    Private Sub TxtUserType_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtOldP.Focus()
        End If
    End Sub

    Private Sub TxtOldP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOldP.KeyDown
        If e.KeyCode = Keys.Enter Then
            If OldP <> txtOldP.Text Then
                MsgBox("Incorrect old password, please verify password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            txtNewP.Focus()
        End If
    End Sub

    Private Sub TxtNewP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNewP.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtConfirmP.Focus()
        End If
    End Sub

    Private Sub TxtConfirmP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtConfirmP.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtNewP.Text.Trim <> txtConfirmP.Text.Trim Then
                MsgBox("Password does not match, please verify password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            btnUpdate.Focus()
        End If
    End Sub
    '******************************************** K E Y D O W N **************************************************

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    '******************************************* L E A V E *******************************************************
    Private Sub TxtUserName_Leave(sender As Object, e As EventArgs) Handles txtUserName.Leave
        txtUserName.Text = ReplaceText(txtUserName.Text)
    End Sub

    Private Sub TxtUserType_Leave(sender As Object, e As EventArgs) Handles txtUserType.Leave
        txtUserType.Text = ReplaceText(txtUserType.Text)
    End Sub

    Private Sub TxtOldP_Leave(sender As Object, e As EventArgs) Handles txtOldP.Leave
        If btnClose.Focused Then
        Else
            If OldP <> txtOldP.Text And Not btnWaive.Visible Then
                MsgBox("Incorrect old password, please verify password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            txtOldP.Text = ReplaceText(txtOldP.Text)
        End If
    End Sub

    Private Sub TxtNewP_Leave(sender As Object, e As EventArgs) Handles txtNewP.Leave
        txtNewP.Text = ReplaceText(txtNewP.Text)
    End Sub

    Private Sub TxtConfirmP_Leave(sender As Object, e As EventArgs) Handles txtConfirmP.Leave
        If btnClose.Focused Then
        Else
            If txtNewP.Text.Trim <> txtConfirmP.Text.Trim Then
                MsgBox("Password does not match, please verify password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            txtConfirmP.Text = ReplaceText(txtConfirmP.Text)
        End If
    End Sub

    '******************************************* L E A V E *******************************************************

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If btnUpdate.DialogResult = DialogResult.OK Then
        Else
            If txtOldP.Text.Trim = "" And txtOldP.Enabled = True Then
                MsgBox("Please fill Old Password", MsgBoxStyle.Information, "Info")
                txtOldP.Focus()
                Exit Sub
            End If
            If txtNewP.Text.Trim = "" Then
                MsgBox("Please fill New Password", MsgBoxStyle.Information, "Info")
                txtNewP.Focus()
                Exit Sub
            End If
            If txtConfirmP.Text.Trim = "" Then
                MsgBox("Please fill Confirmation Password", MsgBoxStyle.Information, "Info")
                txtConfirmP.Focus()
                Exit Sub
            End If
            If txtNewP.Text.Length < PWLength Then
                MsgBox(String.Format("Password must have at least {0} characters.", PWLength), MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf PWCase And (txtNewP.Text Like "*[A-Z]*" = False Or txtNewP.Text Like "*[a-z]*" = False) Then
                MsgBox("Password must have Upper and Lower Case Letters.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf PWSpecial And ContainsSpecial(txtNewP.Text) = False Then
                MsgBox("Password must have special characters.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf PWNumeric And ContainsNumeric(txtNewP.Text) = False Then
                MsgBox("Password must have numeric characters.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If txtNewP.Text.Trim <> txtConfirmP.Text.Trim Then
                MsgBox("Password does not match, please verify password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If OldP <> txtOldP.Text Then
                MsgBox("Incorrect old password, please verify password", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If Salt = "" Then
                Salt = GenerateRandomStrings(10)
            End If
            DataObject(String.Format("UPDATE users SET password = MD5(SHA1(CONCAT('{0}','{2}'))), Salt = '{2}', LastPWChange = CURRENT_TIMESTAMP(), ChangePW = 0, LogStatus = 'OPEN' WHERE user_code = '{1}'", ReplaceText(txtNewP.Text.Trim), User_Code, Salt))
            Logs("Change Password", "Update", "Change Password", "Password", "", "", "")
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            FrmLogin.txtPassword.Text = txtNewP.Text
            btnUpdate.DialogResult = DialogResult.OK
            btnUpdate.PerformClick()
        End If
    End Sub

    Private Sub TxtNewP_TextChanged(sender As Object, e As EventArgs) Handles txtNewP.TextChanged
        If txtNewP.Text.Contains("'") Or txtNewP.Text.Contains("\") Then
            MsgBox("Invalid key found, please don't use the single quote (') or slash (\) keys.", MsgBoxStyle.Exclamation, "Info")
            txtNewP.Text = ""
            txtNewP.Focus()
        End If
    End Sub

    Private Sub TxtConfirmP_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmP.TextChanged
        If txtConfirmP.Text.Contains("'") Or txtConfirmP.Text.Contains("\") Then
            MsgBox("Invalid key found, please don't use the single quote (') or slash (\) keys.", MsgBoxStyle.Exclamation, "Info")
            txtConfirmP.Text = ""
            txtConfirmP.Focus()
        End If
    End Sub

    Private Sub FrmChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        If btnWaive.Visible Then
            btnClose.Enabled = False
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettingsDefault({LabelX4, LabelX1, LabelX7, LabelX2, LabelX3})

            GetTextBoxFontSettings({txtUserName, txtUserType, txtOldP, txtNewP, txtConfirmP})

            GetButtonFontSettings({btnUpdate, btnClose})
        Catch ex As Exception
            TriggerBugReport("Change Password - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnWaive_Click(sender As Object, e As EventArgs) Handles btnWaive.Click
        If MsgBoxYes("Are you sure you want to waive the password change?") = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE users SET LastPWChange = CURRENT_TIMESTAMP() WHERE user_code = '{0}'", User_Code))
            Logs("Change Password", "Waive", "Waive Change Password", "Password", "", "", "")
            MsgBox("Successfully Waive!", MsgBoxStyle.Information, "Info")
            Close()
        End If
    End Sub

    Private Sub FrmChangePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Delete Then
            btnClose.PerformClick()
        End If
    End Sub
End Class