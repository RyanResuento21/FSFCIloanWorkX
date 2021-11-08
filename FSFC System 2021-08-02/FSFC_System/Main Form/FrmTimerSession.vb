Public Class FrmTimerSession

    Private Sub FrmTimerSession_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        iSeconds.Value = FrmMain.Timer_Session.Interval / 500
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX63})

            GetLabelFontSettingsRed({LabelX1})

            GetIntegerInputFontSettings({iSeconds})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Timer Session - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If iSeconds.Value <= 4 Then
            MsgBox("Session cannot be less than 5 seconds.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If iSeconds.Value = FrmMain.Timer_Session.Interval / 500 Then
            MsgBox(iSeconds.Value & " seconds is already set.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(String.Format("Are you sure you want to set your session from {0} to {1}?", FrmMain.Timer_Session.Interval / 500, iSeconds.Value)) = MsgBoxResult.Yes Then
            FrmMain.Timer_Session.Stop()
            Logs("Change Session Time", "Set", String.Format("Change Session Timer from {0} to {1}", FrmMain.Timer_Session.Interval / 500, iSeconds.Value), "Time", "", "", "")
            FrmMain.Timer_Session.Interval = iSeconds.Value * 1000
            DataObject(String.Format("UPDATE users SET `session` = '{1}' WHERE user_code = '{0}'", User_Code, iSeconds.Value))
            MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
            FrmMain.Timer_Session.Start()
            Close()
        End If
    End Sub

    Private Sub ISeconds_KeyDown(sender As Object, e As KeyEventArgs) Handles iSeconds.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub FrmTimerSession_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
End Class