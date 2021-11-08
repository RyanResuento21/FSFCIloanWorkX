Public Class FrmOneTimePassword

    Public OTP As String
    Private Sub FrmOneTimePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 6, 1, True)
        txtOTP.Focus()

        'AttachmentFiles = New ArrayList()
        If AttachmentFiles.Count > 0 Then
            btnView.Visible = True
        Else
            btnView.Visible = False
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetLabelFontSettingsRed({lblBilling})

            'GetTextBoxFontSettingsDefault({txtOTP})

            GetCheckBoxFontSettings({cbxShow})

            GetButtonFontSettings({btnOpen, btnCancel, btnResend, btnAttachments, btnView})
        Catch ex As Exception
            TriggerBugReport("OTAC - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmOneTimePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.O Then
            btnOpen.Focus()
            btnOpen.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtOTP_TextChanged(sender As Object, e As EventArgs) Handles txtOTP.TextChanged
        'If txtOTP.Text.Length = 4 Then
        '    btnOpen.Enabled = True
        'Else
        '    btnOpen.Enabled = False
        'End If
    End Sub

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        If btnOpen.DialogResult = DialogResult.OK Then
        Else
            If txtOTP.Text = OTP Then
                MsgBox("Code Matched!", MsgBoxStyle.Information, "Info")
                btnOpen.DialogResult = DialogResult.OK
                btnOpen.PerformClick()
            Else
                MsgBox("Incorrect OTAC! Please check your OTAC.", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub TxtOTP_KeyDown(sender As Object, e As KeyEventArgs) Handles txtOTP.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnOpen.Focus()
            btnOpen.PerformClick()
        End If
    End Sub

    Private Sub CbxShow_CheckedChanged(sender As Object, e As EventArgs) Handles cbxShow.CheckedChanged
        If cbxShow.Checked Then
            txtOTP.PasswordChar = ""
        Else
            txtOTP.PasswordChar = "*"
        End If
    End Sub

    Private Sub BtnResend_Click(sender As Object, e As EventArgs) Handles btnResend.Click
        If btnResend.DialogResult = DialogResult.Yes Then
        Else
            If MsgBox("Are you sure you want to send the OTAC?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                btnResend.DialogResult = DialogResult.Yes
                btnResend.PerformClick()
            End If
        End If
    End Sub

    Private Sub BtnAttachments_Click(sender As Object, e As EventArgs) Handles btnAttachments.Click
        Dim OpenFileDialog As New OpenFileDialog
        With OpenFileDialog
            .Multiselect = True
            If (.ShowDialog(Me) = DialogResult.OK) Then
                For Each sFile As String In .FileNames
                    AttachmentFiles.Add(sFile)
                Next
                MsgBox("Attachment Added!", MsgBoxStyle.Information, "Info")
                If AttachmentFiles.Count > 0 Then
                    btnView.Visible = True
                Else
                    btnView.Visible = False
                End If
            End If
        End With
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Dim View As New FrmAttachmentList
        With View
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub TxtOTP_Leave(sender As Object, e As EventArgs) Handles txtOTP.Leave
        txtOTP.Text = txtOTP.Text.Trim
    End Sub
End Class