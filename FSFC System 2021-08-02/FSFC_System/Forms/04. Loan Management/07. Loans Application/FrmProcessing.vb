Public Class FrmProcessing

    Private Sub FrmProcessing_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettings({LabelX66, LabelX32})

            GetTextBoxFontSettings({txtProcessingFee})

            GetDoubleInputFontSettings({dAmount})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Processing - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If txtProcessingFee.Text = "" Then
            MsgBox("Please fill the Processing Fee.", MsgBoxStyle.Information, "Info")
            txtProcessingFee.Focus()
            Exit Sub
        End If
        If IsNothing(dAmount.ValueObject) Then
            dAmount.ValueObject = 0
        End If
        If MsgBoxYes(String.Format("Are you sure you want to add this processing fee {0}?", txtProcessingFee.Text)) = MsgBoxResult.Yes Then
            btnSave.DialogResult = DialogResult.OK
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub TxtProcessingFee_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProcessingFee.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount.Focus()
        End If
    End Sub

    Private Sub DAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub TxtProcessingFee_Leave(sender As Object, e As EventArgs) Handles txtProcessingFee.Leave
        txtProcessingFee.Text = ReplaceText(txtProcessingFee.Text)
    End Sub
End Class