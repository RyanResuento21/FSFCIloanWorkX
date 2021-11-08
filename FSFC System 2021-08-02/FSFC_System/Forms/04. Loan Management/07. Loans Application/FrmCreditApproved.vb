Public Class FrmCreditApproved

    Public BorrowerID As String
    Public CreditNumber As String
    Public For_CI As String = "Yes"
    Public AssignedCI As Integer
    Public Mortgage_ID As Integer
    Dim iCompN As Integer
    Dim iIncN As Integer

    Dim iPendingN As Integer
    Dim iApprovedN As Integer
    Dim iDisapprovedN As Integer

    Dim iVehicleN As Integer
    Dim iRealEstateN As Integer
    Dim iCarN As Integer
    Dim iSalaryN As Integer
    Dim iSalarySisterN As Integer
    Dim iPaydayN As Integer
    Dim iShowmoneyN As Integer
    Dim iCheckN As Integer

    ReadOnly iAdvanceN As Integer
    ReadOnly iPassN As Integer

    ReadOnly iAverageN As Integer
    ReadOnly iMinimum As Integer
    ReadOnly iMaximum As Integer
    Public TotalImage As Integer
    Dim DT_Thresholding As DataTable
    Public TransDate As Date
    Public ProductID As Integer
    Public Corporate As Boolean
    Public ApproveStatus As String
    Public OldApproveStatus As String
    Dim FirstLoad As Boolean
    Private Sub FrmCreditApproved_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FirstLoad = True
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FixPictureEdit(pb_B, 255, 256, 6, 7, False)
        dtpApproved.Value = Date.Now
        dtpApproved.CustomFormat = ""
        If btnUpdate.Visible Then
            LabelX68.Visible = True
            dtpApproved.Visible = True
        Else
            LabelX68.Visible = False
            dtpApproved.Visible = False

            dPrincipalA.Enabled = False
            iTermsA.Enabled = False
            dInterestRateA.Enabled = False
            dServiceChargeA.Enabled = False
        End If
        If Corporate Then
            LabelX43.Text = "Trade Name :"
            TxtFirstN_B.Size = New Point(739, 23)
            TxtFirstN_B.Location = New Point(406, 7)

            CbxPrefix_B.Visible = False
            TxtMiddleN_B.Visible = False
            TxtLastN_B.Visible = False
            cbxSuffix_B.Visible = False
        End If

        If For_CI = "Yes" Then
            With cbxOutsourceBranch
                .ValueMember = "branchID"
                .DisplayMember = "branch"
                .DataSource = DataSource(String.Format("SELECT branchID, branch FROM branch WHERE `status` = 'ACTIVE' AND ID != '{0}' ORDER BY Microfinance, branchID * 1;", Branch_ID))
                .SelectedIndex = -1
            End With

            lblCI.Visible = True
            With cbxCI
                .Visible = True
                .ValueMember = "ID"
                .DisplayMember = "CI"
                .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `CI`;", Branch_ID))
                If AssignedCI > 0 Then
                    .SelectedValue = AssignedCI
                    If ApproveStatus = "Pending" Then
                        Dim CI_ID As Integer
                        CI_ID = DataObject(String.Format("SELECT ID FROM credit_investigation WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber))
                        If CI_ID > 0 Then
                            .Enabled = False
                        End If
                    End If
                Else
                    .SelectedIndex = -1
                End If
            End With
        Else
            lblCI.Visible = False
            cbxCI.Visible = False
            cbxOutsource.Visible = False
            cbxOutsourceBranch.Visible = False

            'LabelX68.Location = lblCI.Location
            'dtpApproved.Location = cbxCI.Location
        End If

        Dim SQL As String = "SELECT "
        SQL &= "    FORMAT(IFNULL(SUM(AmountApplied),0),2) AS 'Total Booking',"
        SQL &= String.Format("    FORMAT(IFNULL((SELECT `M{0}T` FROM target_booking WHERE ProductID = {1} AND BranchID = '{2}' AND `status` = 'ACTIVE' AND FP_Status = 'APPROVED' AND YEAR('{3}') = `Year` AND Half = IF(MONTH('{3}') BETWEEN 1 AND 6,1,2)),0),2) AS 'Threshold'", If(Format(TransDate, "MM") > 6, Format(TransDate.AddMonths(-6), "MM"), Format(TransDate, "MM")), ProductID, Branch_ID, Format(TransDate, "yyyy-MM-dd"))
        SQL &= " FROM credit_application"
        SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED','REQUESTED','CHECKED REQUEST','APPROVED REQUEST','CLOSED') AND Product_ID = '{1}' AND MONTH(IFNULL(Released,Trans_Date)) = MONTH('{0}') AND YEAR(IFNULL(Released,Trans_Date)) = YEAR('{0}')", Format(TransDate, "yyyy-MM-dd"), ProductID)
        DT_Thresholding = DataSource(SQL)
        If DT_Thresholding.Rows.Count > 0 Then
            If CDbl(DT_Thresholding(0)("Total Booking")) + dFA_C.Value > CDbl(DT_Thresholding(0)("Threshold")) Then
                lblWarning.Visible = True
                lblThresholdMessage.Visible = True
                LabelX4.Visible = True
                lblTotalBooking.Visible = True
                LabelX8.Visible = True
                lblThreshold.Visible = True
                LabelX23.Visible = True
                lblPrincipal.Visible = True
                LabelX26.Visible = True
                lblExcess.Visible = True
                LabelX7.Visible = True
                lblExcessP.Visible = True

                lblThresholdMessage.Text = "Approved principal amount has reached or exceeded to its threshold amount for Product " & cbxProduct.Text & "."
                lblTotalBooking.Text = DT_Thresholding(0)("Total Booking")
                lblThreshold.Text = DT_Thresholding(0)("Threshold")
                lblPrincipal.Text = dPrincipal.Text
                lblExcess.Text = FormatNumber((CDbl(DT_Thresholding(0)("Total Booking")) + dPrincipal.Value) - CDbl(DT_Thresholding(0)("Threshold")), 2)
                lblExcessP.Text = FormatNumber((CDbl(lblExcess.Text) / CDbl(DT_Thresholding(0)("Threshold"))) * 100, 2) & "%"
            End If
        End If

        If ApproveStatus = "For ReApprove" Or ApproveStatus = "For Special" Then
            btnBOLA.Enabled = True
        Else
            btnBOLA.Enabled = False
        End If

        LoadHistory()
        FirstLoad = False
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

            GetLabelFontSettings({LabelX2, lblInterest, LabelX22, LabelX5, LabelX3})

            GetLabelFontSettings({LabelX43, LabelX32, LabelX31, LabelX29, LabelX28, LabelX82, lblFA_C, LabelX68, lblCI})

            GetLabelFontSettingsRedDefault({lblCreditNumber, lblWarning})

            GetLabelFontSettingsRed({LabelX100, LabelX4, LabelX8, LabelX23, LabelX26, LabelX7, lblThresholdMessage, lblTotalBooking, lblThreshold, lblPrincipal, lblExcess, lblExcessP})

            GetLabelWithBackgroundFontSettings({LabelX34, LabelX25})

            GetTextBoxFontSettings({TxtFirstN_B, TxtMiddleN_B, TxtLastN_B})

            GetButtonFontSettings({btnUpdate, btnApproved, btnDisapproved, btnBOLA, btnAttach, btnCancel, btnRequirements})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B, cbxTerms, cbxTermsA, cbxProduct, cbxOutsourceBranch, cbxCI})

            GetCheckBoxFontSettings({cbxOutsource})

            GetDoubleInputFontSettings({dPrincipal, dPrincipalA, dInterestRate, dInterestRateA, dServiceCharge, dServiceChargeA, dFA_C, dNetProceeds_C})

            GetIntegerInputFontSettings({iTerms, iTermsA})

            GetLabelFontSettings({LabelX11, LabelX10, LabelX19, LabelX18, LabelX46, LabelX45, LabelX14, LabelX13, LabelX54})

            GetLabelFontSettings({LabelX17, LabelX12, lblCompN, lblCompP, lblIncN, lblIncP, LabelX16, LabelX15, LabelX6, lblPendingN, lblApprovedN, lblDisapprovedN, lblPendingP, lblApprovedP, lblDisapprovedP, LabelX21, LabelX20, LabelX9, LabelX24, LabelX27, LabelX36, LabelX33, LabelX30, lblVehicleN, lblRealEstateN, lblCarN, lblSalaryN, lblSalarySisterN, lblPaydayN, lblShowmoneyN, lblCheckN, lblVehicleP, lblRealEstateP, lblCarP, lblSalaryP, lblSalarySisterP, lblPaydayP, lblShowmoneyP, lblCheckP, LabelX48, LabelX47, lblAdvanceN, lblPassN, lblAdvanceP, lblPassP, LabelX56, LabelX55, LabelX39, lblAverageN, lblMinimum, lblMaximum, LabelX50, LabelX49, LabelX37})

            GetGroupControlFontSettings({gRequirements, gLoans, gApplication, gPayments, gPassDue})
        Catch ex As Exception
            TriggerBugReport("Credit Approved - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Credit Approve", lblTitle.Text)
    End Sub

    Private Sub LoadHistory()
        Dim SQL As String = "SELECT"
        SQL &= String.Format("    (SELECT COUNT(ID) FROM submit_documents WHERE is_complete = 'YES' AND `status` = 'ACTIVE' AND CreditNumber = '{0}') AS 'Complete',", CreditNumber)
        SQL &= String.Format("    (SELECT COUNT(ID) FROM submit_documents WHERE is_complete = 'NO' AND `status` = 'ACTIVE' AND CreditNumber = '{0}') AS 'Incomplete',", CreditNumber)
        SQL &= "    COUNT(CASE WHEN C.application_status = 'PENDING' THEN C.ID END) AS 'Pending',"
        SQL &= "    COUNT(CASE WHEN C.application_status = 'APPROVED' THEN C.ID END) AS 'Approved',"
        SQL &= "    COUNT(CASE WHEN C.application_status = 'DISAPPROVED' THEN C.ID END) AS 'Disapproved',"
        SQL &= "    COUNT(CASE WHEN C.product = 'VEHICLE LOAN' THEN C.ID END) AS 'Vehicle',"
        SQL &= "    COUNT(CASE WHEN C.product = 'REAL ESTATE LOAN' THEN C.ID END) AS 'Real Estate',"
        SQL &= "    COUNT(CASE WHEN C.product = 'CAR DEALERSHIP LOAN' THEN C.ID END) AS 'Car',"
        SQL &= "    COUNT(CASE WHEN C.product = 'SALARY LOAN-FSFC' THEN C.ID END) AS 'Salary',"
        SQL &= "    COUNT(CASE WHEN C.product = 'SALARY LOAN-SISTER COMPANY' THEN C.ID END) AS 'Salary Sister',"
        SQL &= "    COUNT(CASE WHEN C.product = 'PAYDAY LOAN' THEN C.ID END) AS 'Pay Day',"
        SQL &= "    COUNT(CASE WHEN C.product = 'SHOWMONEY LOAN' THEN C.ID END) AS 'Show Money',"
        SQL &= "    COUNT(CASE WHEN C.product = 'CHECK REDISCOUNTING LOAN' THEN C.ID END) AS 'Check'"
        SQL &= " FROM credit_application C"
        SQL &= String.Format("    WHERE C.`status` = 'ACTIVE' AND C.BorrowerID = '{0}';", BorrowerID)
        Dim History As DataTable = DataSource(SQL)
        If History.Rows.Count > 0 Then
            '***Submitted Requirements
            iCompN = History(0)("Complete")
            iIncN = History(0)("Incomplete")

            lblCompN.Text = FormatNumber(iCompN, 0)
            lblIncN.Text = FormatNumber(iIncN, 0)

            lblCompP.Text = FormatNumber((iCompN / (iCompN + iIncN)) * 100, 2) & " %"
            lblIncP.Text = FormatNumber((iIncN / (iCompN + iIncN)) * 100, 2) & " %"

            '***Total Number of Application
            iPendingN = History(0)("Pending")
            iApprovedN = History(0)("Approved")
            iDisapprovedN = History(0)("Disapproved")

            lblPendingN.Text = FormatNumber(iPendingN, 0)
            lblApprovedN.Text = FormatNumber(iApprovedN, 0)
            lblDisapprovedN.Text = FormatNumber(iDisapprovedN, 0)

            lblPendingP.Text = FormatNumber((iPendingN / (iPendingN + iApprovedN + iDisapprovedN)) * 100, 2) & " %"
            lblApprovedP.Text = FormatNumber((iApprovedN / (iPendingN + iApprovedN + iDisapprovedN)) * 100, 2) & " %"
            lblDisapprovedP.Text = FormatNumber((iDisapprovedN / (iPendingN + iApprovedN + iDisapprovedN)) * 100, 2) & " %"

            '***Total Number of Loans
            iVehicleN = History(0)("Vehicle")
            iRealEstateN = History(0)("Real Estate")
            iCarN = History(0)("Car")
            iSalaryN = History(0)("Salary")
            iSalarySisterN = History(0)("Salary Sister")
            iPaydayN = History(0)("Pay Day")
            iShowmoneyN = History(0)("Show Money")
            iCheckN = History(0)("Check")

            lblVehicleN.Text = FormatNumber(iVehicleN, 0)
            lblRealEstateN.Text = FormatNumber(iRealEstateN, 0)
            lblCarN.Text = FormatNumber(iCarN, 0)
            lblSalaryN.Text = FormatNumber(iSalaryN, 0)
            lblSalarySisterN.Text = FormatNumber(iSalarySisterN, 0)
            lblPaydayN.Text = FormatNumber(iPaydayN, 0)
            lblShowmoneyN.Text = FormatNumber(iShowmoneyN, 0)
            lblCheckN.Text = FormatNumber(iCheckN, 0)

            lblVehicleP.Text = FormatNumber((iVehicleN / (iVehicleN + iRealEstateN + iCarN + iSalaryN + iSalarySisterN + iPaydayN + iShowmoneyN + iCheckN)) * 100, 2) & " %"
            lblRealEstateP.Text = FormatNumber((iRealEstateN / (iVehicleN + iRealEstateN + iCarN + iSalaryN + iSalarySisterN + iPaydayN + iShowmoneyN + iCheckN)) * 100, 2) & " %"
            lblCarP.Text = FormatNumber((iCarN / (iVehicleN + iRealEstateN + iCarN + iSalaryN + iSalarySisterN + iPaydayN + iShowmoneyN + iCheckN)) * 100, 2) & " %"
            lblSalaryP.Text = FormatNumber((iSalaryN / (iVehicleN + iRealEstateN + iCarN + iSalaryN + iSalarySisterN + iPaydayN + iShowmoneyN + iCheckN)) * 100, 2) & " %"
            lblSalarySisterP.Text = FormatNumber((iSalarySisterN / (iVehicleN + iRealEstateN + iCarN + iSalaryN + iSalarySisterN + iPaydayN + iShowmoneyN + iCheckN)) * 100, 2) & " %"
            lblPaydayP.Text = FormatNumber((iPaydayN / (iVehicleN + iRealEstateN + iCarN + iSalaryN + iSalarySisterN + iPaydayN + iShowmoneyN + iCheckN)) * 100, 2) & " %"
            lblShowmoneyP.Text = FormatNumber((iShowmoneyN / (iVehicleN + iRealEstateN + iCarN + iSalaryN + iSalarySisterN + iPaydayN + iShowmoneyN + iCheckN)) * 100, 2) & " %"
            lblCheckP.Text = FormatNumber((iCheckN / (iVehicleN + iRealEstateN + iCarN + iSalaryN + iSalarySisterN + iPaydayN + iShowmoneyN + iCheckN)) * 100, 2) & " %"
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmCreditApproved_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.A Then
            btnApproved.Focus()
            btnApproved.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDisapproved.Focus()
            btnDisapproved.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnApproved_Click(sender As Object, e As EventArgs) Handles btnApproved.Click
        If btnApproved.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If dtpApproved.CustomFormat = "" And btnUpdate.Visible Then
            MsgBox("Please fill the approved date.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If MsgBoxYes("Are you sure you want to approve this credit application?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If For_CI = "Yes" And btnUpdate.Visible = False Then
                If cbxOutsource.Checked And (cbxOutsourceBranch.SelectedIndex = -1 Or cbxOutsourceBranch.Text = "") Then
                    MsgBox("Please select Branch who will CI.", MsgBoxStyle.Information, "Info")
                    cbxOutsourceBranch.DroppedDown = True
                    Exit Sub
                End If
                If (cbxCI.SelectedIndex = -1 Or cbxCI.Text = "") And cbxOutsource.Checked = False Then
                    MsgBox("Please select assigned Credit Investigator.", MsgBoxStyle.Information, "Info")
                    cbxCI.DroppedDown = True
                    Exit Sub
                End If

                Dim Note As New FrmReason
                With Note
                    .lblReason.Text = "Note :"
                    .Text = "N O T E   F O R   C I"
                    .LabelX3.Visible = False
                    .LabelX2.Visible = False
                    .txtNo.Visible = False
                    .LabelX4.Visible = False
                    If .ShowDialog = DialogResult.OK Then
                        Reason = .txtReason.Text
                    Else
                        Exit Sub
                    End If
                    .Dispose()
                End With
            Else
                Dim Note As New FrmReason
                With Note
                    .lblReason.Text = "Note :"
                    .Text = "N O T E   F O R   A P P R O V E"
                    .LabelX3.Visible = False
                    .LabelX2.Visible = False
                    .txtNo.Visible = False
                    .LabelX4.Visible = False
                    If .ShowDialog = DialogResult.OK Then
                        Reason = .txtReason.Text
                    Else
                        Exit Sub
                    End If
                End With
            End If

            If btnUpdate.Visible Then
                If ApproveStatus = "Pending" Or ApproveStatus = "For ReApprove" Then
                    DataObject(String.Format("UPDATE credit_application SET CI_status = 'APPROVED', CI_ApprovedDate = '{1}', ForLP_Note = '{2}', ApprovedAmount_Crecomm = {3}, ApprovedTerm_Crecomm = {4}, ApprovedInterest_Crecomm = {5}, ApprovedSC_Crecomm = {6}, ApproveStatus = 'APPROVED', OldApproveStatus = 'APPROVED', CrecommTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}';", CreditNumber, Format(dtpApproved.Value, "yyyy-MM-dd"), Reason.Trim, dPrincipalA.Value, iTermsA.Value, dInterestRateA.Value, dServiceChargeA.Value, If(cbxOutsource.Checked, cbxOutsourceBranch.SelectedValue, "")))
                Else
                    DataObject(String.Format("UPDATE credit_application SET CI_status = 'APPROVED', CI_ApprovedDate = '{1}', ForLP_Note = '{2}', ApprovedAmount_President = {3}, ApprovedTerm_President = {4}, ApprovedInterest_President = {5}, ApprovedSC_President = {6}, ApproveStatus = 'APPROVED', OldApproveStatus = 'APPROVED', PresidentTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}';", CreditNumber, Format(dtpApproved.Value, "yyyy-MM-dd"), Reason.Trim, dPrincipalA.Value, iTermsA.Value, dInterestRateA.Value, dServiceChargeA.Value, If(cbxOutsource.Checked, cbxOutsourceBranch.SelectedValue, "")))
                End If
                Logs("Credit Approve", "Approve", "Crecomm Approved Credit Application", String.Format("Crecomm Approved credit application {0} of {1} with a principal of {2}.", lblCreditNumber.Text, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & cbxSuffix_B.Text, dPrincipal.Text), "", "", CreditNumber)
            Else
                DataObject(String.Format("UPDATE credit_application SET application_status = 'APPROVED', Assigned_CI = '{2}', RejectReason = '{1}', CI_ApprovedDate = '{3}', OutsourceCI = '{4}' WHERE CreditNumber = '{0}'", lblCreditNumber.Text, Reason.Trim, ValidateComboBox(cbxCI), Format(Date.Now, "yyyy-MM-dd"), If(cbxOutsource.Checked, cbxOutsourceBranch.SelectedValue, "")))
                Logs("Credit Approve", "Approve", "Approved Credit Application", String.Format("Approved credit application {0} of {1} with a principal of {2}.", lblCreditNumber.Text, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & cbxSuffix_B.Text, dPrincipal.Text), "", "", CreditNumber)
                If cbxOutsource.Checked Then
                    Dim Msg As String = ""
                    Dim Subject As String = String.Format("Request to Credit Investigate {0} [{1}].", If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & cbxSuffix_B.Text, Branch)
                    Dim EmailTo As String = ""
                    Dim BM As DataTable = GetBM(cbxOutsourceBranch.SelectedValue)
                    For x As Integer = 0 To BM.Rows.Count - 1
                        Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee"))
                        Msg &= String.Format("{0} Branch is requesting your Branch to Credit Investigate the application of {1}" & vbCrLf, Branch, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & cbxSuffix_B.Text)
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
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If
            End If
            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
            btnApproved.DialogResult = DialogResult.OK
            btnApproved.PerformClick()
        End If
    End Sub

    Private Sub BtnDisapproved_Click(sender As Object, e As EventArgs) Handles btnDisapproved.Click
        If btnDisapproved.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to disapprove this credit application?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Dim SQL As String = ""
            If FrmLoanApplication.cbxOptions.SelectedIndex = 2 And FrmLoanApplication.cbxAccountNo.SelectedIndex > -1 Then
                SQL &= String.Format("UPDATE credit_application SET ForRestructuring = 0 WHERE ForRestructuring = 1 AND CreditNumber = '{0}';", FrmLoanApplication.cbxAccountNo.SelectedValue)
            End If
            If btnUpdate.Visible Then
                If ApproveStatus = "Pending" Or ApproveStatus = "For ReApprove" Then
                    SQL &= String.Format("UPDATE credit_application SET CI_status = 'DISAPPROVED', OldApproveStatus = 'DISAPPROVED', RejectReason = CONCAT(RejectReason, ' {1}'), ApproveStatus = 'DISAPPROVED', CrecommTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}'", lblCreditNumber.Text, Reason.Trim)
                Else
                    SQL &= String.Format("UPDATE credit_application SET CI_status = 'DISAPPROVED', OldApproveStatus = 'DISAPPROVED', RejectReason = CONCAT(RejectReason, ' {1}'), ApproveStatus = 'DISAPPROVED', PresidentTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}'", lblCreditNumber.Text, Reason.Trim)
                End If
                Logs("Credit Approve", "Disapprove", Reason, String.Format("Crecomm Disapproved credit application {0} of {1} with a principal of {2}.", lblCreditNumber.Text, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & cbxSuffix_B.Text, dPrincipal.Text), "", "", CreditNumber)
            Else
                SQL &= String.Format("UPDATE credit_application SET application_status = 'DISAPPROVED', RejectReason = '{1}' WHERE CreditNumber = '{0}'", lblCreditNumber.Text, Reason.Trim)
                Logs("Credit Approve", "Disapprove", Reason, String.Format("Disapproved credit application {0} of {1} with a principal of {2}.", lblCreditNumber.Text, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & cbxSuffix_B.Text, dPrincipal.Text), "", "", CreditNumber)

                If FrmLoanApplication.cbxOptions.SelectedIndex = 3 And FrmLoanApplication.cbxAccountNo.SelectedIndex > -1 Then
                    SQL &= String.Format("UPDATE credit_application SET AssumptionCredit = '' WHERE CreditNumber = '{1}';", FrmLoanApplication.txtCreditNumber.Text, FrmLoanApplication.cbxAccountNo.SelectedValue)
                End If
            End If
            DataObject(SQL)

            MsgBox("Successfully Disapproved!", MsgBoxStyle.Information, "Info")
            btnDisapproved.DialogResult = DialogResult.OK
            btnDisapproved.PerformClick()
        End If
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If FrmMain.lblDate.Text.Contains("Disconnected") Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim Calculator As New FrmLoanApplication
        With Calculator
            .Tag = 26
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Logs("Credit Approval", "Open", "Amortization Calculators", "", "", "", CreditNumber)
            .lblTitle.Text = "AMORTIZATION CALCULATOR"
            .ControlBox = False
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .WindowState = FormWindowState.Normal
            .From_CI = True
            .CreditNumber = CreditNumber

            .ShowDialog()
            .Dispose()
        End With

        Dim DT As DataTable = DataSource(String.Format("SELECT AmountApplied, Terms, TermType, Product, Purpose, face_amount, gma, net_proceeds FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber))
        If DT.Rows.Count > 0 Then
            dPrincipal.Value = DT(0)("AmountApplied")
            iTerms.Value = DT(0)("Terms")
            cbxTerms.Text = DT(0)("TermType")
            cbxProduct.Text = DT(0)("Product")
            dNetProceeds_C.Value = DT(0)("net_proceeds")
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            If btnUpdate.Visible Then
                .FolderName = "CA Crecomm Approval"
                .Type = "CA Crecomm Approval"
                .TotalImage = TotalImage
                .CreditNumber = CreditNumber
                .ID = CreditNumber
                Dim Result = .ShowDialog
                If Result = DialogResult.OK Then
                    TotalImage = .TotalImage
                    FrmLoanApplication.TotalImage_Crecomm = TotalImage
                    FrmLoanApplication.GridView5.SetFocusedRowCellValue("Attach_Crecomm", TotalImage)
                ElseIf Result = DialogResult.Yes Then
                    TotalImage = .TotalImage
                    FrmLoanApplication.TotalImage_Crecomm = TotalImage
                    FrmLoanApplication.GridView5.SetFocusedRowCellValue("Attach_Crecomm", TotalImage)
                End If
            Else
                .FolderName = "CA Approval"
                .Type = "CA Approval"
                .TotalImage = TotalImage
                .CreditNumber = CreditNumber
                .ID = CreditNumber
                Dim Result = .ShowDialog
                If Result = DialogResult.OK Then
                    TotalImage = .TotalImage
                    FrmLoanApplication.TotalImage_Approval = TotalImage
                    FrmLoanApplication.GridView5.SetFocusedRowCellValue("Attach_Approval", TotalImage)
                ElseIf Result = DialogResult.Yes Then
                    TotalImage = .TotalImage
                    FrmLoanApplication.TotalImage_Approval = TotalImage
                    FrmLoanApplication.GridView5.SetFocusedRowCellValue("Attach_Approval", TotalImage)
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnRequirements_Click(sender As Object, e As EventArgs) Handles btnRequirements.Click
        Dim Requirements As New FrmRequirementsMonitoring
        With Requirements
            .vSave = FrmLoanApplication.vSave
            .vUpdate = FrmLoanApplication.vUpdate
            .vDelete = FrmLoanApplication.vDelete
            .vPrint = FrmLoanApplication.vPrint
            .For_Viewing = True
            .CreditNumber = CreditNumber
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub DtpApproved_Click(sender As Object, e As EventArgs) Handles dtpApproved.Click
        dtpApproved.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub BtnBOLA_Click(sender As Object, e As EventArgs) Handles btnBOLA.Click
        If btnBOLA.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want set the approval Base On Last Approval?") = MsgBoxResult.Yes Then
            Dim SQL As String = ""
            If ApproveStatus = "For ReApprove" Then
                SQL = String.Format("UPDATE credit_application SET ApproveStatus = OldApproveStatus, CrecommTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}'", lblCreditNumber.Text)
            ElseIf ApproveStatus = "For Special" Then
                SQL = String.Format("UPDATE credit_application SET ApproveStatus = OldApproveStatus, PresidentTimestamp = CURRENT_TIMESTAMP WHERE CreditNumber = '{0}'", lblCreditNumber.Text)
            End If
            Logs("Credit Approve", "BOLA", "", String.Format("Base on last approval credit application {0} of {1} with a principal of {2}.", lblCreditNumber.Text, If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & cbxSuffix_B.Text, dPrincipal.Text), "", "", CreditNumber)

            DataObject(SQL)

            MsgBox("Successfully BOLA!", MsgBoxStyle.Information, "Info")
            btnBOLA.DialogResult = DialogResult.OK
            btnBOLA.PerformClick()
        End If
    End Sub

    Private Sub CbxOutsource_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOutsource.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If
        If cbxOutsource.Checked Then
            cbxOutsourceBranch.Enabled = True
            cbxOutsourceBranch.SelectedIndex = -1

            cbxCI.Enabled = False
        Else
            cbxOutsourceBranch.Enabled = False
            cbxOutsourceBranch.SelectedIndex = -1

            With cbxCI
                .Enabled = True
                .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `CI`;", Branch_ID))
                .Text = ""
                If AssignedCI > 0 Then
                    .SelectedValue = AssignedCI
                End If
            End With
        End If
    End Sub

    Private Sub CbxOutsourceBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxOutsourceBranch.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        With cbxCI
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), Last_Name) AS 'CI' FROM employee_setup WHERE (position LIKE '%CREDIT INVESTIGATOR%' OR can_appraise = 1) AND `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `CI`;", cbxOutsourceBranch.SelectedValue))
            .Text = ""
            If AssignedCI > 0 Then
                .SelectedValue = AssignedCI
            End If
        End With
    End Sub
End Class