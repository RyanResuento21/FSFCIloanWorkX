Public Class FrmHoldApplication

    Public CreditNumber As String
    Public CreditNumber_Old As String
    Public BorrowerName As String
    Public Status As String
    Public ApplicationStatus As String
    Public CI_Status As String
    Dim Code As String
    Dim Old_Code As String
    Dim BM As DataTable
    Private Sub FrmHoldApplication_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        'Generate Code **************

        Code = GenerateOTAC()
        BM = GetBM(Branch_ID)
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX66})

            GetRickTextBoxFontSettings({rNote})

            GetButtonFontSettings({btnActivate, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Hold Application - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Hold Application", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.H Then
            btnHold.Focus()
            btnHold.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.U Then
            btnUnhold.Focus()
            btnUnhold.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub RNote_Leave(sender As Object, e As EventArgs) Handles rNote.Leave
        rNote.Text = ReplaceText(rNote.Text)
    End Sub

    Private Sub RNote_KeyDown(sender As Object, e As KeyEventArgs) Handles rNote.KeyDown
        If e.KeyCode = Keys.Enter Then
            If btnHold.Visible Then
                btnHold.Focus()
            Else
                btnUnhold.Focus()
            End If
        End If
    End Sub

    Private Sub BtnUnhold_Click(sender As Object, e As EventArgs) Handles btnUnhold.Click
        If btnUnhold.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If rNote.Text = "" Then
            MsgBox(String.Format("Please select fill the reason for {0}.", If(btnHold.Visible, "Hold", If(btnUnhold.Visible, "Unhold", "Cancel"))), MsgBoxStyle.Information, "Info")
            rNote.Focus()
            Exit Sub
        End If
        If MsgBoxYes(String.Format("Are you sure you want to {0} this credit application?", If(btnHold.Visible, "Hold", If(btnUnhold.Visible, "Unhold", "Cancel")))) = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE credit_application SET `status` = '{2}', HoldReason = CONCAT(HoldReason, ' | {1}') WHERE CreditNumber = '{0}'", CreditNumber, rNote.Text.Trim, If(btnHold.Visible, "HOLD", If(btnCancelApp.Visible, "CANCELLED", "ACTIVE"))))
            Logs("Hold Application", "Unhold", rNote.Text, String.Format("Unhold Application for Credit Number {0} of {1}.", CreditNumber, BorrowerName), "", "", CreditNumber)
            MsgBox("Successfully Unhold!", MsgBoxStyle.Information, "Info")
            btnUnhold.DialogResult = DialogResult.OK
            btnUnhold.PerformClick()
        End If
    End Sub

    Private Sub BtnHold_Click(sender As Object, e As EventArgs) Handles btnHold.Click
        If btnHold.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If rNote.Text = "" Then
            MsgBox(String.Format("Please select fill the reason for {0}.", If(btnHold.Visible, "Hold", If(btnUnhold.Visible, "Unhold", "Cancel"))), MsgBoxStyle.Information, "Info")
            rNote.Focus()
            Exit Sub
        End If
        If MsgBoxYes(String.Format("Are you sure you want to {0} this credit application?", If(btnHold.Visible, "Hold", If(btnUnhold.Visible, "Unhold", "Cancel")))) = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE credit_application SET `status` = '{2}', HoldReason = CONCAT(HoldReason, ' | {1}') WHERE CreditNumber = '{0}'", CreditNumber, rNote.Text.Trim, If(btnHold.Visible, "HOLD", If(btnCancelApp.Visible, "CANCELLED", "ACTIVE"))))
            Logs("Hold Application", "Hold", rNote.Text, String.Format("Hold Application for Credit Number {0} of {1}.", CreditNumber, BorrowerName), "", "", CreditNumber)
            MsgBox("Successfully Hold!", MsgBoxStyle.Information, "Info")
            btnHold.DialogResult = DialogResult.OK
            btnHold.PerformClick()
        End If
    End Sub

    Private Sub BtnCancelApp_Click(sender As Object, e As EventArgs) Handles btnCancelApp.Click
        If btnCancelApp.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If rNote.Text = "" Then
            MsgBox(String.Format("Please select fill the reason for {0}.", If(btnHold.Visible, "Hold", If(btnUnhold.Visible, "Unhold", "Cancel"))), MsgBoxStyle.Information, "Info")
            rNote.Focus()
            Exit Sub
        End If
        Dim Msg As String = String.Format("Are you sure you want to {0} this credit application?", If(btnHold.Visible, "Hold", If(btnUnhold.Visible, "Unhold", "Cancel")))
        If Code = Old_Code Then
            Msg = "Would you like to enter the code now?"
        ElseIf Old_Code = "" Then
            Msg = String.Format("Are you sure you want to {0} this credit application? This will send an Email or SMS to authorized personnel and please wait for their code.", If(btnHold.Visible, "Hold", If(btnUnhold.Visible, "Unhold", "Cancel")))
        Else
            Msg = String.Format("Are you sure you want to {0} this credit application? This will send a NEW Email or SMS to authorized personnel and please wait for their code.", If(btnHold.Visible, "Hold", If(btnUnhold.Visible, "Unhold", "Cancel")))
        End If
        If MsgBoxYes(Msg) = MsgBoxResult.Yes Then
            If Code = Old_Code Then
            Else
                Old_Code = Code
                Dim EmailTo As String = ""
                Dim Subject As String = "One Time Authorization Code " & Code & " [" & CreditNumber & "]"
                Msg = "Good day," & vbCrLf
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for cancellation of application of {1} with application no {2}.", Code, BorrowerName, CreditNumber)
                Msg &= "Thank you!"
                SendNotificationToBM(Branch_ID, Msg, Subject, False, False)
            End If

            Timer1.Start()
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If .ShowDialog = DialogResult.OK Then
                    Dim SQL As String
                    SQL = String.Format("UPDATE credit_application SET `status` = '{2}', CI_Status = IF('{3}' = 'APPROVED' OR '{3}' = 'ONGOING' OR '{3}' = 'CHECKED','ONGOING',CI_Status), HoldReason = CONCAT(HoldReason, ' | {1}') WHERE CreditNumber = '{0}';", CreditNumber, rNote.Text.Trim, If(btnHold.Visible, "HOLD", If(btnCancelApp.Visible, "CANCELLED", "ACTIVE")), CI_Status)
                    If CreditNumber_Old = "" Then
                    Else
                        SQL &= String.Format("UPDATE credit_application SET ForRestructuring = 0 WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber_Old)
                    End If
                    If CI_Status = "APPROVED" Or CI_Status = "ONGOING" Or CI_Status = "CHECKED" Then
                        SQL &= String.Format("UPDATE credit_investigation SET `CI_Status` = 'PENDING' WHERE CreditNumber = '{0}';", CreditNumber)
                    End If
                    DataObject(SQL)
                    Logs("Cancelled Application", "Cancelled", rNote.Text, String.Format("Cancelled Application for Credit Number {0} of {1}.", CreditNumber, BorrowerName), "", "", CreditNumber)
                    MsgBox("Successfully Cancelled!", MsgBoxStyle.Information, "Info")
                    btnCancelApp.DialogResult = DialogResult.OK
                    btnCancelApp.PerformClick()
                End If
            End With
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Generate Code **************
        Code = GenerateOTAC()
        Timer1.Stop()
    End Sub

    Private Sub BtnActivate_Click(sender As Object, e As EventArgs) Handles btnActivate.Click
        If btnActivate.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If rNote.Text = "" Then
            MsgBox("Please select fill the reason for Activation.", MsgBoxStyle.Information, "Info")
            rNote.Focus()
            Exit Sub
        End If
        Dim Msg As String = "Are you sure you want to Activate this credit application?"
        If Code = Old_Code Then
            Msg = "Would you like to enter the code now?"
        ElseIf Old_Code = "" Then
            Msg = "Are you sure you want to Activate this credit application? This will send an Email or SMS to authorized personnel and please wait for their code."
        Else
            Msg = "Are you sure you want to Activate this credit application? This will send a NEW Email or SMS to authorized personnel and please wait for their code."
        End If
        If MsgBoxYes(Msg) = MsgBoxResult.Yes Then
            If Code = Old_Code Then
            Else
                Old_Code = Code
                Dim EmailTo As String = ""
                Dim Subject As String = "One Time Authorization Code " & Code & " [" & CreditNumber & "]"
                Msg = "Good day," & vbCrLf
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for activation of application of {1} with application no {2}.", Code, BorrowerName, CreditNumber)
                Msg &= "Thank you!"
                SendNotificationToBM(Branch_ID, Msg, Subject, False, False)
            End If

            Timer1.Start()
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If .ShowDialog = DialogResult.OK Then
                    If ApplicationStatus = "DISAPPROVED" Then
                        DataObject(String.Format("UPDATE credit_application SET application_status = 'PENDING', HoldReason = CONCAT(HoldReason, ' | {1}') WHERE CreditNumber = '{0}'", CreditNumber, rNote.Text.Trim))
                    ElseIf Status = "DISAPPROVED" Or Status = "DELETED" Or Status = "CANCELLED" Then
                        DataObject(String.Format("UPDATE credit_application SET `status` = 'ACTIVE', application_status = IF('{2}' = 'APPROVED','PENDING',application_status), HoldReason = CONCAT(HoldReason, ' | {1}') WHERE CreditNumber = '{0}'", CreditNumber, rNote.Text.Trim, ApplicationStatus))
                    ElseIf CI_Status = "DISAPPROVED" Then
                        Dim SQL As String
                        SQL = String.Format("UPDATE credit_application SET CI_Status = 'ONGOING', HoldReason = CONCAT(HoldReason, ' | {1}') WHERE CreditNumber = '{0}';", CreditNumber, rNote.Text.Trim)
                        SQL &= String.Format("UPDATE credit_investigation SET CI_Status = 'PENDING' WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber)
                        DataObject(SQL)
                    End If
                    Logs("Activate Application", "Activate", rNote.Text, String.Format("Activate Application for Credit Number {0} of {1}.", CreditNumber, BorrowerName), "", "", CreditNumber)
                    MsgBox("Successfully Activated!", MsgBoxStyle.Information, "Info")
                    btnActivate.DialogResult = DialogResult.OK
                    btnActivate.PerformClick()
                End If
            End With
        End If
    End Sub
End Class