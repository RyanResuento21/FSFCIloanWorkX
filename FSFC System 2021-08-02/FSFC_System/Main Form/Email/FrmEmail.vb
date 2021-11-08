Public Class FrmEmail

    Private Sub BtnReceiver_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        If txtSubject.Text.Trim = Nothing Or txtSubject.Text.Trim = "" Then
            MsgBox("Please fill subject", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If txtBody.Text.Trim = Nothing Or txtBody.Text.Trim = "" Then
            MsgBox("Please fill body", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        SendEmail("", txtSubject.Text.Trim, txtBody.Text.Trim, False, True, False, 0, "", "")
        Close()
    End Sub

    '********************************************* K E Y D O W N ******************************************************
    Private Sub LabelX14_KeyDown(sender As Object, e As KeyEventArgs) Handles LabelX14.KeyDown
        If e.KeyCode = Keys.Escape Then
            Exit Sub
        End If
    End Sub

    Private Sub TxtSubject_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSubject.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If

        If e.KeyCode = Keys.Enter Then
            txtBody.Focus()
        End If
    End Sub

    Private Sub TxtBody_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBody.KeyDown
        If e.KeyCode = Keys.Escape Then
            Close()
        End If

        If e.KeyCode = Keys.Enter Then
            'btnSend.Focus()
        End If
    End Sub

    Private Sub FrmEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
            If e.KeyCode = Keys.Escape Then
                Close()
            ElseIf e.KeyCode = Keys.F12 Then
                .BtnReport_Click(sender, e)
            End If
        End With
    End Sub
    '********************************************* K E Y D O W N ******************************************************

    '********************************************* L E A V E **********************************************************
    Private Sub TxtSubject_Leave(sender As Object, e As EventArgs) Handles txtSubject.Leave
        txtSubject.Text = ReplaceText(txtSubject.Text)
    End Sub

    Private Sub TxtBody_Leave(sender As Object, e As EventArgs) Handles txtBody.Leave
        txtBody.Text = ReplaceText(txtBody.Text)
    End Sub

    '********************************************* L E A V E **********************************************************

    Private Sub FrmEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX14})

            GetLabelFontSettingsDefault({LabelX2, LabelX1})

            GetTextBoxFontSettings({txtSubject})

            GetButtonFontSettings({btnSend})

            GetRickTextBoxFontSettings({txtBody})
        Catch ex As Exception
            TriggerBugReport("Email - FixUI", ex.Message.ToString)
        End Try
    End Sub
End Class