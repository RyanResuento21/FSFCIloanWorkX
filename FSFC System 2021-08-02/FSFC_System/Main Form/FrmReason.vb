Public Class FrmReason

    Dim FirstLoad As Boolean
    Dim CharMax As Integer
    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If txtReason.Text.Trim = "" And txtNo.Value > 0 Then
            If lblReason.Text = "Note :" Then
            Else
                MsgBox("Please fill reason.", MsgBoxStyle.Information, "Info")
                txtReason.Focus()
                Exit Sub
            End If
        End If
        If btnSelect.DialogResult = DialogResult.OK Then
            Close()
            Exit Sub
        End If
        btnSelect.DialogResult = DialogResult.OK
        btnSelect.PerformClick()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettingsDefaultSize({LabelX3, LabelX2, LabelX4, lblReason})

            GetDoubleInputFontSettingsDefault({txtNo})

            GetRickTextBoxFontSettings({txtReason})

            GetButtonFontSettings({btnSelect})
        Catch ex As Exception
            TriggerBugReport("Reason - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub FrmReason_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True
        If UCase(User_Type) = "ADMIN" Or UCase(User_Type) = "PRESIDENT" Or UCase(User_Type) = "SUPERUSER" Or UCase(User_Type) = "SUPERADMIN" Then
            txtNo.Enabled = True
        Else
            txtNo.Enabled = False
        End If
        txtNo.Text = DataObject("SELECT reason FROM tbl_reason_text WHERE id = '1' AND `status` = 'ACTIVE'")
        CharMax = txtNo.Value
        btnSelect.DialogResult = DialogResult.None
        txtReason.Focus()
        txtReason.Text = ""
        FirstLoad = False
        txtReason.Focus()
    End Sub

    Private Sub TxtReason_Leave(sender As Object, e As EventArgs) Handles txtReason.Leave
        txtReason.Text = ReplaceText(txtReason.Text.Trim)
    End Sub

    Private Sub TxtReason_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReason.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSelect.Focus()
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub TxtNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            If MsgBoxYes("Are you sure you want to change the number of text for reason?") = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE tbl_reason_text SET reason = '{0}' WHERE id = '{1}'", txtNo.Value, 1))
                CharMax = txtNo.Value
                MsgBox("Successfully changed!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub FrmReason_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.KeyCode = Keys.Escape Then
            Close()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSelect.Focus()
            btnSelect.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtReason_TextChanged(sender As Object, e As EventArgs) Handles txtReason.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If txtNo.Value <= 0 And txtReason.Text <> "" Then
            MsgBox("Reason is too long. Please shorten reason if possible.", MsgBoxStyle.Information, "Info")
        End If
        txtNo.Value = CharMax - txtReason.Text.Length
    End Sub

    Private Sub TxtNo_ValueChanged(sender As Object, e As EventArgs) Handles txtNo.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        If txtNo.Value > CharMax Then
            txtNo.Value = CharMax
        End If
    End Sub
End Class