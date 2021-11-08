Public Class FrmLiquidationCaption

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.DialogResult = DialogResult.OK Then
        Else
            If txtCaption.Text.Trim = "" Then
                MsgBox("Please fill the caption.", MsgBoxStyle.Information, "Info")
                txtCaption.Focus()
                Exit Sub
            End If

            txtCaption.Focus()
            btnAdd.DialogResult = DialogResult.OK
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtCaption_Leave(sender As Object, e As EventArgs) Handles txtCaption.Leave
        txtCaption.Text = ReplaceText(txtCaption.Text)
    End Sub

    Private Sub TxtCaption_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCaption.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX4})

            GetTextBoxFontSettings({txtCaption})

            GetButtonFontSettings({btnAdd, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Liquidation Caption - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub FrmLiquidationCaption_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        txtCaption.Focus()
        btnAdd.DialogResult = DialogResult.None
    End Sub
End Class