Public Class FrmPromiseToPay

    Public CreditNumber As String
    Public BorrowerName As String
    Public DatePromise As String
    Private Sub FrmPromiseToPay_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If DatePromise = "" Then
            dtpPromise.Value = Date.Now
        Else
            dtpPromise.Value = DatePromise
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX10, LabelX66, LabelX32})

            GetDateTimeInputFontSettings({dtpPromise})

            GetDoubleInputFontSettings({dAmount})

            GetRickTextBoxFontSettings({rPromise})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Promise To Pay - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Promise to Pay", lblTitle.Text)
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

    Private Sub RPromise_Leave(sender As Object, e As EventArgs) Handles rPromise.Leave
        rPromise.Text = ReplaceText(rPromise.Text)
    End Sub

    Private Sub DAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpPromise_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPromise.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub RPromise_KeyDown(sender As Object, e As KeyEventArgs) Handles rPromise.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If rPromise.Text = "" Then
            MsgBox("Please select fill the remarks.", MsgBoxStyle.Information, "Info")
            rPromise.Focus()
            Exit Sub
        End If
        If MsgBoxYes(String.Format("Are you sure you want to save this promise to pay?", If(btnSave.Text = "&Save", "Save", "Update"))) = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE credit_application SET `PromiseDate` = '{1}', `PromiseAmount` = '{2}', `PromiseRemarks` = '{3}', PromiseStatus = 'PENDING' WHERE CreditNumber = '{0}'", CreditNumber, Format(dtpPromise.Value, "yyyy-MM-dd"), dAmount.Value, rPromise.Text.Trim))
            Logs("Promise to Pay", "Save", rPromise.Text, String.Format("Promise to Pay for Credit Number {0} of {1} on {2} with amount of P{3}.", CreditNumber, BorrowerName, dtpPromise.Text, dAmount.Text), "", "", CreditNumber)
            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            btnSave.DialogResult = DialogResult.OK
            btnSave.PerformClick()
        End If
    End Sub
End Class