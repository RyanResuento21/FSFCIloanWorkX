Public Class FrmDate

    Private Sub FrmDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpClear.Value = Date.Now
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({lblDeposit})

            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnClear, btnCancel})

            GetDateTimeInputFontSettings({dtpClear})
        Catch ex As Exception
            TriggerBugReport("Date - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        With btnClear
            If .DialogResult = DialogResult.OK Then
            Else

                If MsgBoxYes(String.Format("Are you sure about this {0} Date?", .Text)) = MsgBoxResult.Yes Then
                    .DialogResult = DialogResult.OK
                    .PerformClick()
                End If
            End If
        End With
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnClear_KeyDown(sender As Object, e As KeyEventArgs) Handles btnClear.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnClear.Focus()
            btnClear.PerformClick()
        End If
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpClear.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnClear.Focus()
            btnClear.PerformClick()
        ElseIf e.KeyCode = Keys.Delete Then
            dtpClear.CustomFormat = ""
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub DtpClear_Click(sender As Object, e As EventArgs) Handles dtpClear.Click
        dtpClear.CustomFormat = "MMMM dd, yyyy"
    End Sub
End Class