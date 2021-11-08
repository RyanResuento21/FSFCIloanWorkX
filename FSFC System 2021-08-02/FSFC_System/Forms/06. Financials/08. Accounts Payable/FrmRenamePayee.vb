Public Class FrmRenamePayee

    Private Sub FrmRenamePayee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({lblDeposit})

            GetTextBoxFontSettings({txtPayee})

            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Rename Payee - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If txtPayee.Text = "" Then
                MsgBox(String.Format("Please fill the {0}.", lblTitle.Text.ToLower), MsgBoxStyle.Information, "Info")
                txtPayee.Focus()
                Exit Sub
            End If

            If MsgBoxYes(String.Format("Are you sure you want to rename the {0}?", lblTitle.Text.ToLower)) = MsgBoxResult.Yes Then
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
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
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub TxtPayee_Leave(sender As Object, e As EventArgs) Handles txtPayee.Leave
        txtPayee.Text = ReplaceText(txtPayee.Text)
    End Sub
End Class