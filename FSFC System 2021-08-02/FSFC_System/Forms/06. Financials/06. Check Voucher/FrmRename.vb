Public Class FrmRename

    Public Payee As String
    Private Sub FrmRenamePayee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxPayee.Text = Payee
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({lblDeposit})

            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnSave, btnCancel})

            GetComboBoxFontSettings({cbxPayee})
        Catch ex As Exception
            TriggerBugReport("Rename - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure you want to rename the payee?") = MsgBoxResult.Yes Then
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

    Private Sub CbxPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
            btnSave.PerformClick()
        End If
    End Sub
End Class