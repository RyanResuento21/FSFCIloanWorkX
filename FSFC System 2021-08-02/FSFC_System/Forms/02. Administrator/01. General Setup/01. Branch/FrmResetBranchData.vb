Public Class FrmResetBranchData

    Public SelectedBranchIDForReset As Integer
    Public SelectedBranchForReset As String
    Dim Code As String

    Private Sub FrmResetBranchData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

            GetCheckBoxFontSettings({cbx1, cbx2, cbx3, cbx4})

            GetTextBoxFontSettings({txtRemarks})

            GetButtonFontSettings({btnReset, btnCancel, btnHistory})
        Catch ex As Exception
            TriggerBugReport("Reset Branch Data - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Reset Branch Data", lblTitle.Text)
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub

    Private Sub FrmBouncedReason_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.R Then
            btnReset.Focus()
            btnReset.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnReset.Focus()
        End If
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        If cbx1.Checked = False And cbx2.Checked = False And cbx3.Checked = False And cbx4.Checked = False Then
            MsgBox("Please select data to be reset.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim ToReset As String = ""
        If cbx1.Checked Then
            ToReset = If(cbx1.Checked, cbx1.Tag, "")
        End If
        If cbx2.Checked Then
            If cbx1.Checked Then
                ToReset &= " and "
            End If
            ToReset &= If(cbx2.Checked, cbx2.Tag, "")
        End If
        If cbx3.Checked Then
            If cbx1.Checked Or cbx2.Checked Then
                ToReset &= " and "
            End If
            ToReset &= If(cbx3.Checked, cbx3.Tag, "")
        End If
        If cbx4.Checked Then
            If cbx1.Checked Or cbx2.Checked Or cbx3.Checked Then
                ToReset &= " and "
            End If
            ToReset &= If(cbx4.Checked, cbx4.Tag, "")
        End If
        If MsgBoxYes(String.Format("Are you sure you want to reset the data of {0}?", ToReset)) = MsgBoxResult.Yes Then
            Dim EmailTo As String = ""
            Dim Msg As String = ""
            Code = GenerateOTAC()
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & SelectedBranchForReset & "]"
            Dim BM As DataTable = GetBM(Branch_ID)
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee"))
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for resetting the data of {1} for {2}." & vbCrLf, Code, SelectedBranchForReset, ToReset)
                Msg &= "Thank you!"
                '******* SEND SMS *********************************************************************************
                If BM(x)("Phone") = "" Then
                Else
                    SendSMS(BM(x)("Phone"), Msg, True)
                End If
                '******* SEND EMAIL *********************************************************************************
                If BM(x)("EmailAdd") = "" Then
                Else
                    EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
                End If
            Next
            If EmailTo = "" Then
            Else
                If FrmLogin.txtUserName.Text = "mgotico" Then 'FOR DATA CLEANSING ONLY SCHEDULE ON 09/29/2021 07:00PM
                Else
                    SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                End If
            End If

            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If FrmLogin.txtUserName.Text = "mgotico" Then 'FOR DATA CLEANSING ONLY SCHEDULE ON 09/29/2021 07:00PM
                    .txtOTP.Text = Code
                End If
                If .ShowDialog = DialogResult.OK Then
                    Dim ResetStatus As String = "-R" & DataObject(String.Format("SELECT COUNT(ID) + 1 FROM reset_branch_data WHERE branch_id = '{0}';", SelectedBranchIDForReset))
                    Dim SQL As String = "INSERT INTO reset_branch_data SET"
                    SQL &= String.Format(" branch_id = {0}, ", SelectedBranchIDForReset)
                    SQL &= String.Format(" reset_borrower = '{0}', ", If(cbx1.Checked, 1, 0))
                    SQL &= String.Format(" reset_accounting = '{0}', ", If(cbx2.Checked, 1, 0))
                    SQL &= String.Format(" reset_non_loans = '{0}', ", If(cbx3.Checked, 1, 0))
                    SQL &= String.Format(" reset_ropa = '{0}', ", If(cbx4.Checked, 1, 0))
                    SQL &= String.Format(" remarks = '{0}', ", txtRemarks.Text)
                    SQL &= String.Format(" user_id = '{0}', ", User_ID)
                    SQL &= String.Format(" reset_status = '{0}';", ResetStatus)
                    If cbx1.Checked Then
                        'BORROWER
                        SQL &= String.Format(" UPDATE profile_borrower SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','BLOCKED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE profile_borrowerid SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE profile_comaker SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE profile_corporation SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE profile_dependent SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE profile_spouse SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)

                        SQL &= String.Format(" UPDATE profile_agent SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE profile_dealer SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)

                        SQL &= String.Format(" UPDATE supplier_setup SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                    End If
                    If cbx2.Checked Then
                        'CREDIT APPLICATION
                        SQL &= String.Format(" UPDATE credit_application SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT','HOLD');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE check_received SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('PAID','CLEARED','BOUNCED','PARTIAL','PENDING','RETURNED','ACTIVE');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE credit_application_comaker SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE credit_deductbalance SET `status` = CONCAT(`status`,'{1}') WHERE branchid = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE credit_earlysettlement SET `status` = CONCAT(`status`,'{1}') WHERE branchid = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE credit_investigation SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE credit_referral SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE credit_released SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        'SQL &= String.Format(" UPDATE credit_deductbalance SET `status` = CONCAT(`status`,'{1}') WHERE branchid = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE insurance_monitoring SET `status` = CONCAT(`status`,'{1}') WHERE branchid = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE reinstate_application SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        'ACCOUNTING ENTRIES
                        SQL &= String.Format(" UPDATE accounting_entry SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE official_receipt SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE journal_voucher SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE due_to SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE due_from SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE due_check SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE pdc_others SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE accounts_payable SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE accounts_receivable SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE check_voucher SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE loans_payable SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE acknowledgement_receipt SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE target_booking SET `status` = CONCAT(`status`,'{1}') WHERE branchid = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE financial_plan SET `status` = CONCAT(`status`,'{1}') WHERE branchid = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                    End If
                    If cbx3.Checked Then
                        'NON LOANS
                        SQL &= String.Format(" UPDATE cash_advance SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE petty_cash SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE liquidation_main SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE cash_count SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE collection_cashcount SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE replenishment_cash SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE case_main SET `status` = CONCAT(`status`,'{1}') WHERE branchid = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE case_ledger SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT');", SelectedBranchIDForReset, ResetStatus)
                    End If
                    If cbx4.Checked Then
                        'ROPA
                        SQL &= String.Format(" UPDATE ropoa_vehicle SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT','PENDING');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE ropoa_realestate SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT','PENDING');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE sold_ropoa SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT','PENDING');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE tbl_impairment SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT','PENDING');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE tbl_repricing SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT','PENDING');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE appraise_ve SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT','PENDING');", SelectedBranchIDForReset, ResetStatus)
                        SQL &= String.Format(" UPDATE appraise_re SET `status` = CONCAT(`status`,'{1}') WHERE branch_id = {0} AND `status` IN ('ACTIVE','CANCELLED','DISAPPROVED','DELETED','DRAFT','PENDING');", SelectedBranchIDForReset, ResetStatus)
                    End If
                    If SQL = "" Then
                    Else
                        DataObject(SQL)
                    End If
                    Logs("Reset Branch Data", "Reset", String.Format("Reset Data of Branch {0} for {1}", SelectedBranchForReset, ToReset), "", "", "", "")
                    MsgBox("Successfully Reset Branch Data!", MsgBoxStyle.Information, "Info")
                    Close()
                End If
            End With
        End If
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim History As New FrmResetBranchHistory
        With History
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class