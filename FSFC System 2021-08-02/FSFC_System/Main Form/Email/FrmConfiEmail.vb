Public Class FrmConfiEmail
    Public ForAdmin As Boolean

    Private Sub FrmConfiEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX23, LabelX3, LabelX7})

            GetLabelFontSettingsRed({LabelX12, LabelX2})

            GetTextBoxFontSettings({txtEmail, txtPassword, txtPassword_2})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("ConfiEmail - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Confidential Email", lblTitle.Text)
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
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        txtEmail.Text = ReplaceText(txtEmail.Text)
    End Sub

    Private Sub TxtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword_2.Focus()
        End If
    End Sub

    Private Sub TxtPassword_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub TxtPassword_2_Leave(sender As Object, e As EventArgs) Handles txtPassword_2.Leave
        If txtPassword_2.Text.Trim <> txtPassword.Text.Trim Then
            MsgBox("Password does not match, please verify password", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtEmail.Text = "" Or txtEmail.Text.Contains("@") = False Then
            MsgBox("Please fill a correct email address.", MsgBoxStyle.Information, "Info")
            txtEmail.Focus()
            Exit Sub
        End If
        If txtPassword.Text = "" Then
            MsgBox("Please fill the password.", MsgBoxStyle.Information, "Info")
            txtPassword.Focus()
            Exit Sub
        End If
        If txtPassword_2.Text.Trim <> txtPassword.Text.Trim Then
            MsgBox("Password does not match, please verify password", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim SQL As String
                If ForAdmin Then
                    SQL = "UPDATE company SET"
                    SQL &= String.Format(" ESender = '{0}', ", txtEmail.Text)
                    SQL &= String.Format(" EPassword = HEX(AES_ENCRYPT('{0}','{1}')) ", txtPassword.Text, Company_Code & Ext)
                    SQL &= String.Format(" WHERE ID = '{0}';", Company_ID)
                    DataObject(SQL)

                    AppEmailAddress = txtEmail.Text
                    AppPassword = txtPassword.Text
                Else
                    SQL = "UPDATE branch SET"
                    SQL &= String.Format(" ConfiEmail = '{0}', ", txtEmail.Text)
                    SQL &= String.Format(" ConfiPW = HEX(AES_ENCRYPT('{0}','{1}')) ", txtPassword.Text, Branch_Code & Branch_ID)
                    SQL &= String.Format(" WHERE ID = '{0}';", Branch_ID)
                    DataObject(SQL)

                    ConfiEmail = txtEmail.Text
                    ConfiPW = txtPassword.Text
                End If
                Logs("Confidential Email", "Update", "", Changes(), "", "", "")
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                Close()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        If txtEmail.Text = txtEmail.Tag Then
        Else
            Change &= String.Format("Change Email Address from {0} to {1}. ", txtEmail.Tag, txtEmail.Text)
        End If
        Return Change
    End Function
End Class