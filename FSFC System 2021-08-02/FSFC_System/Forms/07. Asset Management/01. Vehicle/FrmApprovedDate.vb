Public Class FrmApprovedDate

    Private Sub FrmApprovedDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        dtpDate.Value = Date.Now
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettingsDefault({LabelX2})

            GetDateTimeInputFontSettingsDefault({dtpDate})

            GetButtonFontSettings({btnApprove, btnClose})
        Catch ex As Exception
            TriggerBugReport("Approved Date - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If btnApprove.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure about this approve date?") = MsgBoxResult.Yes Then
                MsgBox("Sucessfully Approved!", MsgBoxStyle.Information, "Info")
                btnApprove.DialogResult = DialogResult.OK
                btnApprove.PerformClick()
            Else
                btnApprove.DialogResult = DialogResult.None
            End If
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Close()
    End Sub

    Private Sub FrmApprovedDate_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.A Then
            btnApprove.Focus()
            btnApprove.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnClose.Focus()
            btnClose.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class