Public Class FrmUpdateLoanType

    Public CreditNumber As String
    Public LoanType As String
    Private Sub FrmUpdateLoanType_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxOptions.Text = cbxOptions.Tag
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX22})

            GetComboBoxFontSettings({cbxOptions})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Update Loan Type - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CbxOptions_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOptions.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub FrmUpdateEmployer_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If cbxOptions.Text = "" Or cbxOptions.SelectedIndex = -1 Then
                MsgBox("Please select a loan type.", MsgBoxStyle.Information, "Info")
                cbxOptions.Focus()
                cbxOptions.DroppedDown = True
                Exit Sub
            End If

            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim SQL As String = "UPDATE credit_application SET"
                SQL &= String.Format(" loan_type = '{0}' ", cbxOptions.Text)
                SQL &= String.Format(" WHERE CreditNumber = '{0}';", CreditNumber)
                DataObject(SQL)
                Logs("Update Loan Type", "Update", String.Format("Update Loan Type for Credit Number {0}", CreditNumber), Changes(), "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxOptions.Tag = cbxOptions.Text Then
            Else
                Change &= String.Format("Change Loan Type from {0} to {1}. ", cbxOptions.Tag, cbxOptions.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Update Loan Type - Changes", ex.Message.ToString)
        End Try
        Return Change
    End Function
End Class