Public Class FrmMessageBox

    Dim Secs As Integer = 4
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmMessageBox_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
            If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
                btnCancel.Focus()
                btnCancel.PerformClick()
            ElseIf e.KeyCode = Keys.F12 Then
                .BtnReport_Click(sender, e)
            End If
        End With
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblSeconds.Text = String.Format("Note : This form can be close in {0} second(s).", Secs)
        If Secs = 0 Then
            lblSeconds.Visible = False
            Timer1.Stop()
            btnCancel.Enabled = True
        End If
        Secs -= 1
    End Sub

    Private Sub FrmMessageBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        Timer1.Start()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX1})

            GetLabelFontSettingsDefault({lblNote, lblSeconds})

            GetButtonFontSettings({btnCancel})
        Catch ex As Exception
            TriggerBugReport("MessageBox - FixUI", ex.Message.ToString)
        End Try
    End Sub

End Class