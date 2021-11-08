Public Class FrmTagOldAccount

    Public CreditNumber As String
    Public OrigCreditNumber As String
    Public AccountingEntry As String
    Public Payee As String
    Private Sub FrmTagOldAccount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxAccount
            .DisplayMember = "Account"
            .DataSource = DataSource(String.Format("SELECT CreditNumber, CONCAT(CreditNumber, ' [',AccountNumber,']') AS 'Account' FROM credit_deductbalance WHERE CreditNumber_F = '{0}' AND `status` = 'ACTIVE' AND deduct_status = 'PENDING' UNION ALL SELECT '{0}', '{0}';", OrigCreditNumber))
            .ValueMember = "CreditNumber"
            .SelectedValue = If(CreditNumber = "", OrigCreditNumber, CreditNumber)
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({lblDeposit})

            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnTag, btnCancel})

            GetComboBoxFontSettings({cbxAccount})
        Catch ex As Exception
            TriggerBugReport("Tag Old Account - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnTag_Click(sender As Object, e As EventArgs) Handles btnTag.Click
        If btnTag.DialogResult = DialogResult.OK Then
        Else
            If cbxAccount.Text = "" Or cbxAccount.SelectedIndex = -1 Then
                MsgBox("Please select account number to tag.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf cbxAccount.SelectedValue = If(CreditNumber = "", OrigCreditNumber, CreditNumber) Then
                MsgBox(String.Format("Selected Account Number is already used in {0} accounting entry.", AccountingEntry), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If MsgBoxYes(String.Format("Are you sure you want use the Account Number {0} for the accounting entry of {1} for {2}?", cbxAccount.Text, AccountingEntry, Payee)) = MsgBoxResult.Yes Then
                btnTag.DialogResult = DialogResult.OK
                MsgBox("Successfully Tagged!", MsgBoxStyle.Information, "Info")
                btnTag.PerformClick()
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
            btnTag.Focus()
            btnTag.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub CbxPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAccount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnTag.Focus()
            btnTag.PerformClick()
        End If
    End Sub
End Class