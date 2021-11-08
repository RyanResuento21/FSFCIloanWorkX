Public Class FrmAddAmount

    Public DefaultAmount As Double
    Private Sub FrmAddAmount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dAmount.Value = DefaultAmount
        dAmount.Focus()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({lblDeposit})

            GetDoubleInputFontSettings({dAmount})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Add Amount - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If dAmount.Value = 0 Then
                MsgBox("Please fill the amount.", MsgBoxStyle.Information, "Info")
                dAmount.Focus()
            End If
            If MsgBoxYes(String.Format("Are you sure about this amount {0}?", dAmount.Text)) = MsgBoxResult.Yes Then
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

    Private Sub DAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
            btnSave.PerformClick()
        End If
    End Sub
End Class