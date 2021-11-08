Public Class FrmCheckDate

    Private Sub FrmCheckDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpCheck.Value = Date.Now
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettings({LabelX2})

            GetDateTimeInputFontSettings({dtpCheck})

            GetButtonFontSettings({btnApprove, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Check Date - FixUI", ex.Message.ToString)
        End Try
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
        If e.Control And e.KeyCode = Keys.E Then
            btnCheck.Focus()
            btnCheck.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub DtpCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpCheck.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnCheck.Focus()
            btnCheck.PerformClick()
        End If
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If btnCheck.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure about the Due Date? This will compute the interval days.") = MsgBoxResult.Yes Then
                btnCheck.DialogResult = DialogResult.OK
                btnCheck.PerformClick()
            End If
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If btnApprove.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure about the GL Date? This will be the entry date of the GL.") = MsgBoxResult.Yes Then
                btnApprove.DialogResult = DialogResult.OK
                btnApprove.PerformClick()
            End If
        End If
    End Sub
End Class