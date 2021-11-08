Public Class FrmReceivedBy

    Public From_CheckVoucher As Boolean
    Public From_PettyCash As Boolean
    Public From_PaymentRelease As Boolean
    Private Sub FrmReceivedBy_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpReceived.Value = Date.Now
        If From_PaymentRelease Then
            dtpReceived.Value = FrmPaymentRelease.dtpReleased.Value
        End If

        If From_CheckVoucher = False And From_PettyCash = False Then
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettings({LabelX3, LabelX2})

            GetComboBoxFontSettings({cbxReceiver})

            GetDateTimeInputFontSettings({dtpReceived})

            GetButtonFontSettings({btnReceived, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Received By - FixUI", ex.Message.ToString)
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
        If e.Control And e.KeyCode = Keys.R Then
            btnReceived.Focus()
            btnReceived.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub CbxReceiver_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxReceiver.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnReceived.Focus()
            btnReceived.PerformClick()
        End If
    End Sub

    Private Sub BtnReceived_Click(sender As Object, e As EventArgs) Handles btnReceived.Click
        If btnReceived.DialogResult = DialogResult.OK Then
        Else
            If From_CheckVoucher Or From_PettyCash Then
                If cbxReceiver.Text = "" Then
                    MsgBox("Please fill a receiver.", MsgBoxStyle.Information, "Info")
                    cbxReceiver.DroppedDown = True
                    Exit Sub
                End If
            Else
                If cbxReceiver.Text = "" Or cbxReceiver.SelectedIndex = -1 Then
                    MsgBox("Please select a receiver.", MsgBoxStyle.Information, "Info")
                    cbxReceiver.DroppedDown = True
                    Exit Sub
                End If
            End If
            If From_PaymentRelease Then
                If dtpReceived.Value <> FrmPaymentRelease.dtpReleased.Value Then
                    If MsgBox("Date Received and Date Released from Payment Release is not the same, would you like to proceed?.", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            If MsgBoxYes(String.Format("Are you sure {0} received the {1}?", cbxReceiver.Text, If(From_CheckVoucher, "Check Voucher", "Cash Advance Slip/Petty Cash Voucher"))) = MsgBoxResult.Yes Then
                btnReceived.DialogResult = DialogResult.OK
                btnReceived.PerformClick()
            End If
        End If
    End Sub
End Class