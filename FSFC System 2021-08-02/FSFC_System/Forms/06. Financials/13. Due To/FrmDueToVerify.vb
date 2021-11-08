Public Class FrmDueToVerify

    Private Sub FrmDueToVerify_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpReceived.Value = Date.Now

        With cbxReceiver
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee' FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Employee`;", Branch_ID))
            .SelectedValue = Empl_ID
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettings({LabelX3, LabelX2, LabelX4})

            GetButtonFontSettings({btnVerify, btnCancel})

            GetComboBoxFontSettings({cbxReceiver})

            GetDateTimeInputFontSettings({dtpReceived})

            GetTextBoxFontSettings({txtRemarks})
        Catch ex As Exception
            TriggerBugReport("Due To Verify - FixUI", ex.Message.ToString)
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
        If e.Control And e.KeyCode = Keys.V Then
            btnVerify.Focus()
            btnVerify.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub CbxReceiver_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxReceiver.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnVerify.Focus()
            btnVerify.PerformClick()
        End If
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
        If btnVerify.DialogResult = DialogResult.OK Then
        Else
            If cbxReceiver.Text = "" Or cbxReceiver.SelectedIndex = -1 Then
                MsgBox("Please fill a verifier.", MsgBoxStyle.Information, "Info")
                cbxReceiver.DroppedDown = True
                Exit Sub
            End If
            If MsgBoxYes(String.Format("Are you sure {0} verified the due to?", cbxReceiver.Text)) = MsgBoxResult.Yes Then
                btnVerify.DialogResult = DialogResult.OK
                btnVerify.PerformClick()
            End If
        End If
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub
End Class