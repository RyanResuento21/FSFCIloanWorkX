Public Class FrmPettyCashTagPayee

    Public DocumentNumber As String
    Public Payee As String
    Private Sub FrmPettyCashTagPayee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            GetLabelFontSettings({LabelX3})

            GetComboBoxFontSettings({cbxPayee})

            GetButtonFontSettings({btnTag, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Petty Cash Tag Payee - FixUI", ex.Message.ToString)
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
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub CbxPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnTag.Focus()
            btnTag.PerformClick()
        End If
    End Sub

    Private Sub BtnTag_Click(sender As Object, e As EventArgs) Handles btnTag.Click
        If btnTag.DialogResult = DialogResult.OK Then
        Else
            If cbxPayee.Text = "" Or cbxPayee.SelectedIndex = -1 Then
                MsgBox("Please select a receiver.", MsgBoxStyle.Information, "Info")
                cbxPayee.DroppedDown = True
                Exit Sub
            End If

            If MsgBoxYes(String.Format("Are you sure tag Petty Cash {0} from {1} to {2}?", DocumentNumber, Payee, cbxPayee.Text)) = MsgBoxResult.Yes Then
                btnTag.DialogResult = DialogResult.OK
                btnTag.PerformClick()
            End If
        End If
    End Sub
End Class