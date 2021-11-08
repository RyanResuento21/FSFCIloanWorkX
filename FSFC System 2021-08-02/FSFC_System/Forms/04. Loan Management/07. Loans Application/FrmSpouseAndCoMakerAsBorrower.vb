Public Class FrmSpouseAndCoMakerAsBorrower

    Public CreditNumber As String
    Private Sub FrmSpouseAndCoMakerAsBorrower_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX21, LabelX77, LabelX78, LabelX109, LabelX93})

            GetTextBoxFontSettings({TxtFirstN_S, TxtMiddleN_S, TxtLastN_S, TxtFirstN_C1, TxtMiddleN_C1, TxtLastN_C1, TxtFirstN_C2, TxtMiddleN_C2, TxtLastN_C2, TxtFirstN_C3, TxtMiddleN_C3, TxtLastN_C3, TxtFirstN_C4, TxtMiddleN_C4, TxtLastN_C4})

            GetComboBoxFontSettings({CbxPrefix_S, cbxSuffix_S, CbxPrefix_C1, cbxSuffix_C1, CbxPrefix_C2, cbxSuffix_C2, CbxPrefix_C3, cbxSuffix_C3, CbxPrefix_C4, cbxSuffix_C4})

            GetCheckBoxFontSettings({cbxSpouse_B, cbxCoMaker1_B, cbxCoMaker2_B, cbxCoMaker3_B, cbxCoMaker4_B})

            GetButtonFontSettings({btnUpdate, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Spouse and CoMaker Borrower - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Spouse and CoMaker Borrower", lblTitle.Text)
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If btnUpdate.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to update this credit application?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            DataObject(String.Format("UPDATE credit_application SET Borrower_S = {1}, Borrower_C1 = {2}, Borrower_C2 = {3}, Borrower_C3 = {4}, Borrower_C4 = {5} WHERE CreditNumber = '{0}'", CreditNumber, If(cbxSpouse_B.Checked, 1, 0), If(cbxCoMaker1_B.Checked, 1, 0), If(cbxCoMaker2_B.Checked, 1, 0), If(cbxCoMaker3_B.Checked, 1, 0), If(cbxCoMaker4_B.Checked, 1, 0)))
            Logs("Spouse and CoMaker Borrower", "Update", Reason, String.Format("Update Credit Number {0} Spouse and CoMaker as Borrower.", CreditNumber), "", "", CreditNumber)
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            btnUpdate.DialogResult = DialogResult.OK
            btnUpdate.PerformClick()
        End If
    End Sub
End Class