Public Class FrmPayDayDetails

    Public BankID As Integer = 0
    Public From_List As Boolean = False
    Public CreditNumber As String
    Private Sub FrmPayDayDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        With cbxBank
            .DisplayMember = "Bank"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, Bank FROM bank_setup WHERE `status` = 'ACTIVE' ORDER BY Bank;")
            .SelectedValue = BankID
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX155, LabelX1, LabelX14, LabelX2})

            GetTextBoxFontSettings({txtAccountNumber, txtCardNumber})

            GetComboBoxFontSettings({cbxBank})

            GetCheckBoxFontSettings({cbxYes})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Payday Details - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAccountNumber.Focus()
        End If
    End Sub

    Private Sub TxtAccountNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccountNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtCardNumber.Visible Then
                txtCardNumber.Focus()
            Else
                btnSave.Focus()
            End If
        End If
    End Sub

    Private Sub TxtCardNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCardNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
            MsgBox("Please select Bank.", MsgBoxStyle.Information, "Info")
            cbxBank.DroppedDown = True
            Exit Sub
        End If
        If txtAccountNumber.Text = "" Then
            MsgBox("Please Account Number.", MsgBoxStyle.Information, "Info")
            txtAccountNumber.Focus()
            Exit Sub
        End If
        If txtCardNumber.Text = "" And txtCardNumber.Visible Then
            MsgBox("Please Card Number.", MsgBoxStyle.Information, "Info")
            txtCardNumber.Focus()
            Exit Sub
        End If

        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure you want to save this data?") = MsgBoxResult.Yes Then
                If From_List Then
                    Dim SQL As String = "UPDATE credit_application SET"
                    SQL &= String.Format(" PD_ATM = '{0}', ", If(cbxYes.Checked, 1, 0))
                    SQL &= String.Format(" PD_CardNumber = '{0}', ", txtCardNumber.Text)
                    SQL &= String.Format(" PD_AccountNumber = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" PD_BankID = '{0}' ", cbxBank.SelectedValue)
                    SQL &= String.Format(" WHERE CreditNumber = '{0}';", CreditNumber)
                    DataObject(SQL)
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                End If
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub TxtAccountNumber_Leave(sender As Object, e As EventArgs) Handles txtAccountNumber.Leave
        txtAccountNumber.Text = ReplaceText(txtAccountNumber.Text)
    End Sub

    Private Sub TxtCardNumber_Leave(sender As Object, e As EventArgs) Handles txtCardNumber.Leave
        txtCardNumber.Text = ReplaceText(txtCardNumber.Text)
    End Sub

    Private Sub FrmPayDayDetails_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
End Class