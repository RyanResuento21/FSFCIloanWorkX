Imports word = Microsoft.Office.Interop.Word
Public Class FrmPaymentRelease

    Dim ID As String
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim ProductCode As String
    Dim DT_Account As DataTable
    Dim CVNumber As String

    Dim PD_BankID As Integer
    Dim PD_AccountNumber As String
    Dim PD_CardNumber As String
    Dim PD_ATM As Boolean
    Public From_JV As Boolean
    Public CreditNumber_Old As String
    Public CreditNumber_New As String

    Private Sub FrmPaymentRelease_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        LoadCompanyMode()

        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        cbxDisplay.SelectedIndex = 0
        GetAccountNumber()

        dtpBirthdate_B.Value = Date.Now
        dtpExpiry.Value = Date.Now
        dtpExpiry.CustomFormat = ""
        dtpInsurance.Value = Date.Now
        dtpInsurance.CustomFormat = ""
        dtpReleased.Value = Date.Now
        dtpPN.Value = Date.Now
        dtpFDD.Value = Date.Now
        dtpMD.Value = Date.Now

        dtpReleased.MaxDate = Date.Now.AddDays(7)
        dtpPN.MaxDate = Date.Now.AddDays(7)

        cbxApplication.ValueMember = "CreditNumber"
        cbxApplication.DisplayMember = "Name"
        LoadApplication()

        LoadData()
        Timer_Date.Start()
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

            GetLabelFontSettings({LabelX17, LabelX7, LabelX2, LabelX6, LabelX9, LabelX12, LabelX16, LabelX19, LabelX21, LabelX28, LabelX37, LabelX41, LabelX45, LabelX46, LabelX32, LabelX1, LabelX30, LabelX4, LabelX5, LabelX8, LabelX10, lblPlateNum, LabelX15, LabelX18, LabelX22, LabelX23, LabelX27, LabelX20, LabelX26, LabelX24, LabelX35, LabelX33, LabelX40, LabelX44, lblMonthsMD, LabelX29, LabelX38, LabelX42, LabelX34, LabelX31, LabelX39, LabelX43, LabelX47, LabelX49, LabelX48})

            GetLabelFontSettingsRed({LabelX155, LabelX13, LabelX25, LabelX36})

            GetLabelFontSettingsRedDefault({LabelX3})

            GetTextBoxFontSettingsRedDefault({txtAccountNumber})

            GetTextBoxFontSettings({txtSpouse, txtAddress, txtComaker1, txtComaker2, txtComaker3, txtComaker4, txtCollateral, txtMotorNum, txtORNumber, txtTCT, txtInsuranceCom, txtEmail, txtPlus63, txtMobile, TextBoxX3, txtMobileC1, TextBoxX5, txtMobileC2, TextBoxX8, txtMobileC3, TextBoxX11, txtMobileC4, txtPlateNum, txtChassisNum, txtColor, txtLocation, txtArea, txtCI, txtReferred, txtNotes})

            GetCheckBoxFontSettings({cbxNew, cbxRenew, cbxRestructured, cbxAll, cbxIncludeMigrated})

            GetComboBoxFontSettings({cbxApplication, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo, dtpBirthdate_B, dtpExpiry, dtpInsurance, dtpPN, dtpFDD, dtpMD, dtpReleased})

            GetDoubleInputFontSettings({dCoverage, dPremium, dPrincipal, dUDI, dRPPD, dFaceAmount, dRate, dGMA, dMR, dNMA})

            GetIntegerInputFontSettings({iTerms})

            GetButtonFontSettings({btnATM, btnCVNumber, btnAdd, btnSave, btnRefresh, btnCancel, btnPrint, btnResend, btnPromissoryNote, btnRequirements, btnSearch})

            GetContextMenuBarFontSettings({ContextMenuBar1})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Payment Release - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Payment Release", lblTitle.Text)
    End Sub

    Private Sub LoadApplication()
        Dim SQL As String = "SELECT C.CreditNumber, C.Product, BorrowerID, "
        SQL &= "   CONCAT('[ ', C.CreditNumber, ' ] - ', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Name',"
        SQL &= "   CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'FullN',"
        SQL &= "   CONCAT(IF(FirstN_S = '','',CONCAT(FirstN_S, ' ')), IF(MiddleN_S = '','',CONCAT(MiddleN_S, ' ')), IF(LastN_S = '','',CONCAT(LastN_S, ' ')), Suffix_S) AS 'Spouse',"
        SQL &= "   CONCAT(IF(FirstN_C1 = '','',CONCAT(FirstN_C1, ' ')), IF(MiddleN_C1 = '','',CONCAT(MiddleN_C1, ' ')), IF(LastN_C1 = '','',CONCAT(LastN_C1, ' ')), Suffix_C1) AS 'Comaker1',"
        SQL &= "   CONCAT(IF(FirstN_C2 = '','',CONCAT(FirstN_C2, ' ')), IF(MiddleN_C2 = '','',CONCAT(MiddleN_C2, ' ')), IF(LastN_C2 = '','',CONCAT(LastN_C2, ' ')), Suffix_C2) AS 'Comaker2',"
        SQL &= "   CONCAT(IF(FirstN_C3 = '','',CONCAT(FirstN_C3, ' ')), IF(MiddleN_C3 = '','',CONCAT(MiddleN_C3, ' ')), IF(LastN_C3 = '','',CONCAT(LastN_C3, ' ')), Suffix_C3) AS 'Comaker3',"
        SQL &= "   CONCAT(IF(FirstN_C4 = '','',CONCAT(FirstN_C4, ' ')), IF(MiddleN_C4 = '','',CONCAT(MiddleN_C4, ' ')), IF(LastN_C4 = '','',CONCAT(LastN_C4, ' ')), Suffix_C4) AS 'Comaker4',"
        SQL &= "   CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) AS 'Address',"
        SQL &= "   IF(FirstN_C1 = '','', IFNULL((SELECT CONCAT(IF(NoC_C = '','',CONCAT(NoC_C, ', ')), IF(StreetC_C = '','',CONCAT(StreetC_C, ', ')), IF(BarangayC_C = '','',CONCAT(BarangayC_C, ', ')), AddressC_C) FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 1 ORDER BY ID DESC LIMIT 1),'')) AS 'Address_C1',"
        SQL &= "   IF(FirstN_C2 = '','', IFNULL((SELECT CONCAT(IF(NoC_C = '','',CONCAT(NoC_C, ', ')), IF(StreetC_C = '','',CONCAT(StreetC_C, ', ')), IF(BarangayC_C = '','',CONCAT(BarangayC_C, ', ')), AddressC_C) FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 2 ORDER BY ID DESC LIMIT 1),'')) AS 'Address_C2',"
        SQL &= "   IF(FirstN_C1 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 1 ORDER BY ID DESC LIMIT 1),'')) AS 'Mobile_C1',"
        SQL &= "   IF(FirstN_C2 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 2 ORDER BY ID DESC LIMIT 1),'')) AS 'Mobile_C2',"
        SQL &= "   IF(FirstN_C3 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 3 ORDER BY ID DESC LIMIT 1),'')) AS 'Mobile_C3',"
        SQL &= "   IF(FirstN_C4 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 4 ORDER BY ID DESC LIMIT 1),'')) AS 'Mobile_C4',"
        SQL &= "   CI.Collateral AS 'Collateral',VE.PlateNum, VE.MotorNum, VE.ChassisNum, VE.ORNum, VE.BodyColor ,RE.TCT, RE.Location, RE.Area, (SELECT `code` FROM product_setup WHERE ID = C.product_id) AS 'Product_Code', TIN_B,"
        SQL &= "   (SELECT LEFT(Employee(empl_id),LOCATE(' ',Employee(empl_id)) - 1) FROM users U WHERE U.user_code = CI.user_code) AS 'CI', (SELECT payment FROM product_setup WHERE product_setup.ID = C.product_id) AS 'Payment Type',"
        SQL &= "   loan_type, Birth_B, Email_B, Mobile_B, AmountApplied, Terms, Interest, RPPD, Face_Amount, Interest_Rate, RPPD_Rate, GMA, Rebate, LastN_B, Insurance, IFNULL((SELECT IF(CVDate = '',DATE(NOW()),CVDate) FROM check_received WHERE AssetNumber = C.CreditNumber AND check_type = 'P' AND `status`  IN ('PENDING','ACTIVE') ORDER BY ID DESC LIMIT 1),DATE(NOW())) AS 'CVDate', IF(CVforJV,(SELECT DocumentNumber FROM journal_voucher WHERE ReferenceID = C.CreditNumber AND CVforJV = 1 AND `status` = 'ACTIVE' AND Voucher_Status IN ('CHECKED','APPROVED') LIMIT 1),IFNULL((SELECT CVNumber FROM check_received WHERE AssetNumber = C.CreditNumber AND check_type = 'P' AND `status` IN ('PENDING','ACTIVE') ORDER BY ID DESC LIMIT 1),IFNULL(CV.DocumentNumber,''))) AS 'CVNumber', IFNULL(CV.DTS,0) AS 'DTS', IFNULL(CV.DTS_JVNumber,'') AS 'CV DTS', (SELECT COUNT(ID) FROM check_voucher WHERE `status` = 'ACTIVE' AND voucher_status NOT IN ('CANCELLED','DISAPPROVED') AND ApprovedID = 0 AND Payee_ID = C.CreditNumber) AS 'CV Count', PD_CardNumber, PD_AccountNumber, PD_BankID, PD_ATM, branch_code,"
        SQL &= "   CONCAT(IF(Agent = '','', CONCAT(Agent, IF(Marketing = '' AND Dealer = '','',' / '))), IF(Marketing = '','', CONCAT(Marketing, IF(Dealer = '','',' / '))), Dealer) AS 'Referred', Interest_N, RPPD_N, Principal_N, trans_date, (SELECT Last_Principal FROM product_setup WHERE product_setup.ID = C.Product_ID ) AS 'Last Principal', Release_OTAC, FDD, ManualAmortization, VerifiedManualAmort, IncludeAdvancePaymentInBill, BillDeductionsStatus"
        SQL &= " FROM credit_application C"
        SQL &= String.Format("    LEFT JOIN (SELECT CreditNumber, CINumber, user_code, Collateral FROM credit_investigation WHERE `status` = 'ACTIVE' AND ci_status = 'APPROVED') CI ON CI.CreditNumber = C.CreditNumber", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        SQL &= "    LEFT JOIN (SELECT GROUP_CONCAT(PlateNum) AS 'PlateNum', GROUP_CONCAT(EngineNum) AS 'MotorNum', GROUP_CONCAT(ChassisNum) AS 'ChassisNum', GROUP_CONCAT(ORNum) AS 'ORNum', GROUP_CONCAT(BodyColor) AS 'BodyColor', CINumber FROM collateral_ve WHERE `status` = 'ACTIVE' GROUP BY CINumber) VE ON CI.CINumber = VE.CINumber"
        SQL &= "    LEFT JOIN (SELECT GROUP_CONCAT(TCT) AS 'TCT', GROUP_CONCAT(Location) AS 'Location', GROUP_CONCAT(CONCAT(AREA,' SQM')) AS 'Area', CINumber FROM collateral_re WHERE `status` = 'ACTIVE' GROUP BY CINumber) RE ON CI.CINumber = RE.CINumber"
        SQL &= "    LEFT JOIN (SELECT DocumentNumber, DTS, DTS_JVNumber, Payee_ID FROM check_voucher WHERE `status` = 'ACTIVE' AND voucher_status = 'APPROVED') CV ON CV.Payee_ID = C.CreditNumber"
        If From_JV Then
            SQL &= String.Format("  WHERE `status` = 'ACTIVE' AND PaymentRequest IN ('PENDING','REQUESTED','APPROVED REQUEST') AND CI_Status = 'APPROVED' AND (Loan_Type = 'RESTRUCTURE' OR (From_ROPOA = 1 OR CVforJV = 1)) AND C.CreditNumber = '{0}';", CreditNumber_New)
        Else
            SQL &= String.Format("  WHERE FIND_IN_SET(C.Branch_ID,'{0}') AND C.`status` = 'ACTIVE' AND C.application_status = 'APPROVED' AND C.CI_Status = 'APPROVED' AND PaymentRequest = 'APPROVED REQUEST' ORDER BY C.CreditNumber;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        If From_JV Then
            FirstLoad = False
            cbxApplication.DataSource = DataSource(SQL)
        Else
            FirstLoad = True
            cbxApplication.DataSource = DataSource(SQL)
            cbxApplication.SelectedIndex = -1
            FirstLoad = False
        End If
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "  ID,"
        SQL &= "  CreditNumber AS 'Credit Number',"
        SQL &= "  AccountNumber AS 'Account Number',"
        SQL &= "  DATE_FORMAT(PN,'%b %d, %Y') AS 'PN Date',"
        SQL &= "  CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Borrower',"
        SQL &= "  Product AS 'Product',"
        SQL &= "  AmountApplied AS 'Principal',"
        SQL &= "  Terms AS 'Terms',"
        SQL &= "  Face_Amount AS 'Face Amount',"
        SQL &= "  Loan_Type AS 'Loan Type',"
        SQL &= "  InsuranceComp,"
        SQL &= "  Coverage AS 'Coverage',"
        SQL &= "  IF(Expiry = '','',DATE_FORMAT(Expiry,'%b %d, %Y')) AS 'Expiry',"
        SQL &= "  Premium AS 'Premium',"
        SQL &= "  IF(CVforJV,(SELECT DocumentNumber FROM journal_voucher WHERE ReferenceID = A.CreditNumber AND CVforJV = 1 AND `status` = 'ACTIVE' AND Voucher_Status IN ('CHECKED','APPROVED') LIMIT 1),CVNum) AS 'CVNum',"
        SQL &= "  IF(Release_Insurance = '','',DATE_FORMAT(Release_Insurance,'%b %d, %Y')) AS 'Insurance',"
        SQL &= "  DATE_FORMAT(Released,'%b %d, %Y') AS 'Released',"
        SQL &= "  DATE_FORMAT(FDD,'%b %d, %Y') AS 'FDD',"
        SQL &= "  CI,"
        SQL &= "  Referred,"
        SQL &= "  Notes,"
        SQL &= "  Remarks, CVNumber, "
        SQL &= "  branch_id, (SELECT COUNT(ID) FROM accounting_entry WHERE ORNum != '' AND ReferenceN = CreditNumber AND `status` = 'ACTIVE') AS 'Payment', Attach_Releasing, Branch(Branch_ID) AS 'Branch'"
        SQL &= "  FROM credit_application A WHERE `status` = 'ACTIVE' AND (PaymentRequest = 'RELEASED' OR PaymentRequest = 'CLOSED')"
        SQL &= String.Format("  AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(Released) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        If cbxIncludeMigrated.Checked = False Then
            SQL &= " AND loan_type != 'MIGRATED'"
        End If
        SQL &= "  ORDER BY AccountNumber DESC;"

        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn19.Visible = True
            GridColumn19.VisibleIndex = 11
        End If
        GridView1.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn5.Width = 254 - 17
        Else
            GridColumn5.Width = 254
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxNew_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNew.CheckedChanged
        If cbxNew.Checked Then
            cbxRenew.Checked = False
            cbxRestructured.Checked = False
        End If

        If cbxNew.Checked = False And cbxRenew.Checked = False And cbxRestructured.Checked = False Then
            cbxNew.Checked = True
        End If
    End Sub

    Private Sub CbxRenew_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRenew.CheckedChanged
        If cbxRenew.Checked Then
            cbxNew.Checked = False
            cbxRestructured.Checked = False
        End If

        If cbxNew.Checked = False And cbxRenew.Checked = False And cbxRestructured.Checked = False Then
            cbxNew.Checked = True
        End If
    End Sub

    Private Sub CbxRestructured_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRestructured.CheckedChanged
        If cbxRestructured.Checked Then
            cbxRenew.Checked = False
            cbxNew.Checked = False
        End If

        If cbxNew.Checked = False And cbxRenew.Checked = False And cbxRestructured.Checked = False Then
            cbxNew.Checked = True
        End If
    End Sub

    '**** LEAVE *****
    Private Sub TxtCollateral_Leave(sender As Object, e As EventArgs) Handles txtCollateral.Leave
        txtCollateral.Text = ReplaceText(txtCollateral.Text)
    End Sub

    Private Sub TxtCVNum_Leave(sender As Object, e As EventArgs) Handles txtCVNum.Leave
        txtCVNum.Text = ReplaceText(txtCVNum.Text)
    End Sub

    Private Sub TxtCI_Leave(sender As Object, e As EventArgs) Handles txtCI.Leave
        txtCI.Text = ReplaceText(txtCI.Text)
    End Sub

    Private Sub TxtReferred_Leave(sender As Object, e As EventArgs) Handles txtReferred.Leave
        txtReferred.Text = ReplaceText(txtReferred.Text)
    End Sub

    Private Sub TxtNotes_Leave(sender As Object, e As EventArgs) Handles txtNotes.Leave
        txtNotes.Text = ReplaceText(txtNotes.Text)
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub
    '**** LEAVE *****

    Private Sub DtpExpiry_Enter(sender As Object, e As EventArgs) Handles dtpExpiry.Enter
        dtpExpiry.CustomFormat = "MMM dd, yyyy"
    End Sub

    Private Sub DtpInsurance_Enter(sender As Object, e As EventArgs) Handles dtpInsurance.Enter
        dtpInsurance.CustomFormat = "MMM dd, yyyy"
    End Sub

    '***** KEYDOWN *****
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.B Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnModify.Focus()
            btnModify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Left) Or (e.Control And e.KeyCode = Keys.Down) Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Right) Or (e.Control And e.KeyCode = Keys.Up) Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView1_DoubleClick(sender, e)
        End If
    End Sub

    '***** KEYDOWN *****
    Private Sub CbxApplication_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxApplication.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAccountNumber.Focus()
        End If
    End Sub

    Private Sub TxtAccountNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccountNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxNew.Focus()
        End If
    End Sub

    Private Sub CbxNew_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNew.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtInsuranceCom.Focus()
        End If
    End Sub

    Private Sub CbxRenew_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRenew.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtInsuranceCom.Focus()
        End If
    End Sub

    Private Sub CbxRestructured_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRestructured.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtInsuranceCom.Focus()
        End If
    End Sub

    Private Sub TxtInsuranceCom_KeyDown(sender As Object, e As KeyEventArgs) Handles txtInsuranceCom.KeyDown
        If e.KeyCode = Keys.Enter Then
            dCoverage.Focus()
        End If
    End Sub

    Private Sub DCoverage_KeyDown(sender As Object, e As KeyEventArgs) Handles dCoverage.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpExpiry.Focus()
        End If
    End Sub

    Private Sub DtpExpiry_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpExpiry.KeyDown
        If e.KeyCode = Keys.Enter Then
            dPremium.Focus()
        ElseIf e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Delete Then
            dtpExpiry.CustomFormat = ""
        End If
    End Sub

    Private Sub DPremium_KeyDown(sender As Object, e As KeyEventArgs) Handles dPremium.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCVNum.Focus()
        End If
    End Sub

    Private Sub TxtCVNum_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCVNum.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpInsurance.Focus()
        End If
    End Sub

    Private Sub DtpInsurance_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpInsurance.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpReleased.Focus()
        ElseIf e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Delete Then
            dtpInsurance.CustomFormat = ""
        End If
    End Sub

    Private Sub DtpReleased_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpReleased.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpPN.Focus()
        End If
    End Sub

    Private Sub DtpPN_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPN.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpFDD.Focus()
        End If
    End Sub

    Private Sub DtpFDD_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFDD.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCI.Focus()
        End If
    End Sub

    Private Sub TxtCI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCI.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReferred.Focus()
        End If
    End Sub

    Private Sub TxtReferred_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferred.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNotes.Focus()
        End If
    End Sub

    Private Sub TxtNotes_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNotes.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***** KEYDOWN *****

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
        End If
    End Sub

    Private Function NA(xTring As String)
        Return If(xTring = "", "N/A", xTring)
    End Function

    Private Sub CbxApplication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApplication.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            Clear()
        Else
            Cursor = Cursors.WaitCursor

            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            If drv("Product").ToString.Contains("PAYDAY") Or drv("Product").ToString.Contains("SHOWMONEY") Then
                btnATM.Visible = True
                cbxApplication.Size = New Point(313, 25)
            Else
                btnATM.Visible = False
                cbxApplication.Size = New Point(346, 25)
            End If
            PD_BankID = drv("PD_BankID")
            PD_AccountNumber = drv("PD_AccountNumber")
            PD_CardNumber = drv("PD_CardNumber")
            PD_ATM = drv("PD_ATM")
            txtEmail.Text = drv("Email_B")
            txtSpouse.Text = drv("Spouse")
            If drv("BorrowerID").ToString.Contains("C") Then
                LabelX17.Text = "Representative 1 :"
                LabelX2.Text = "Representative 2 :"
                LabelX6.Text = "Representative 3 :"
                LabelX9.Text = "Representative 4 :"
                LabelX12.Text = "Representative 5 :"

                LabelX17.Location = New Point(3, 63)
                txtSpouse.Location = New Point(146, 64)
                LabelX7.Location = New Point(3, 34)
                txtAddress.Location = New Point(146, 35)
            Else
                LabelX17.Text = "Spouse Name :"
                LabelX2.Text = "Co-Maker I :"
                LabelX6.Text = "Co-Maker II :"
                LabelX9.Text = "Co-Maker III :"
                LabelX12.Text = "Co-Maker IV :"

                LabelX17.Location = New Point(3, 34)
                txtSpouse.Location = New Point(146, 35)
                LabelX7.Location = New Point(3, 63)
                txtAddress.Location = New Point(146, 64)
            End If
            dtpBirthdate_B.Value = If(drv("Birth_B") = "", Date.Now, drv("Birth_B"))
            If drv("Loan_Type") = "NEW" Then
                cbxNew.Checked = True
            Else
                cbxRenew.Checked = True
            End If
            txtAddress.Text = drv("Address")
            txtMobile.Text = drv("Mobile_B")
            txtComaker1.Text = drv("CoMaker1")
            txtMobileC1.Text = drv("Mobile_C1")
            txtComaker2.Text = drv("CoMaker2")
            txtMobileC2.Text = drv("Mobile_C2")
            txtComaker3.Text = drv("CoMaker3")
            txtMobileC3.Text = drv("Mobile_C3")
            txtComaker4.Text = drv("CoMaker4")
            txtMobileC4.Text = drv("Mobile_C4")
            txtCollateral.Text = drv("Collateral").ToString
            txtPlateNum.Text = NA(drv("PlateNum").ToString)
            txtMotorNum.Text = NA(drv("MotorNum").ToString)
            txtChassisNum.Text = NA(drv("ChassisNum").ToString)
            txtORNumber.Text = NA(drv("ORNum").ToString)
            txtColor.Text = NA(drv("BodyColor").ToString)
            txtTCT.Text = NA(drv("TCT").ToString)
            txtLocation.Text = NA(drv("Location").ToString)
            txtArea.Text = NA(drv("Area").ToString)
            dPremium.Value = drv("Insurance")
            txtCVNum.Text = drv("CVNumber")
            btnCVNumber.Text = drv("CVNumber")
            dtpInsurance.Value = drv("CVDate")
            dtpInsurance.CustomFormat = "MMM dd, yyyy"

            dPrincipal.Value = drv("AmountApplied")
            dUDI.Value = drv("Interest")
            dRPPD.Value = drv("RPPD")
            dRPPD.Tag = drv("RPPD_Rate")
            dRate.Value = drv("Interest_Rate")
            dMR.Value = drv("Rebate")
            iTerms.Value = drv("Terms")
            txtCI.Text = drv("CI").ToString
            txtReferred.Text = drv("Referred")
            ProductCode = drv("Product_Code")
            If CompanyMode = 0 Then
                dFaceAmount.Value = dPrincipal.Value + dUDI.Value
                dGMA.Value = CDbl(drv("GMA")) - dMR.Value
            Else
                dFaceAmount.Value = drv("Face_Amount")
                dGMA.Value = drv("GMA")
            End If
            If drv("Last Principal") = "Yes" Then
                LabelX33.Visible = False
                dGMA.Visible = False
                LabelX40.Text = "MI :"
                LabelX44.Text = "Last :"
                dNMA.Value = dPrincipal.Value + dMR.Value
            Else
                LabelX33.Visible = True
                dGMA.Visible = True
                LabelX40.Text = "MR :"
                LabelX44.Text = "NMA :"
                dNMA.Value = CDbl(drv("GMA")) - dMR.Value
            End If
            GetAccountNumber()
            If drv("FDD") = "" Then
            Else
                dtpFDD.Value = drv("FDD")
            End If

            DtpReleased_ValueChanged(sender, e)
            DT_Account = DataSource(String.Format("SELECT ID, AccountNumber, CreditNumber, Amount, IF(Amount >= (LR - (UDI_Discount + AvailedRPPD)) + (AR + Penalty),'Early','Not') AS 'Early Settlement' FROM credit_deductbalance WHERE `status` = 'ACTIVE' AND deduct_status = 'PENDING' AND CreditNumber_F = '{0}';", cbxApplication.SelectedValue))
            btnResend.Enabled = True
            Dim Requirements As Integer = DataObject(String.Format("SELECT COUNT(S.ID) FROM submit_documents S WHERE S.BorrowerID = '{0}' AND S.CreditNumber = '{1}' AND S.`status` = 'ACTIVE' AND S.is_complete = 'NO';", drv("BorrowerID"), cbxApplication.SelectedValue))
            Dim Mandatory As Integer = DataObject(String.Format("SELECT COUNT(S.ID) FROM submit_documents S WHERE S.BorrowerID = '{0}' AND S.CreditNumber = '{1}' AND S.`status` = 'ACTIVE' AND S.is_complete = 'NO' AND (SELECT Mandatory FROM document_setup WHERE ID = Doc_ID) = 'YES';", drv("BorrowerID"), cbxApplication.SelectedValue))
            If Requirements > 0 Then
                With FrmLogin
                    If .InvokeRequired Then
                        .th.Abort()
                        .th.Join()
                        .Splash.Close()
                        .Splash.Dispose()
                    Else
                        .Invoke(New FrmLogin._SubName(AddressOf .StopThread))
                    End If
                End With
                MsgBox(String.Format("Application still have {0} requirements to complete.", Requirements), MsgBoxStyle.Information, "Info")
                If Mandatory > 0 Then
                    MsgBox(String.Format("{0} Mandatory requirements are needed to complete. Releasing is not allowed if requirements are not complete.", Mandatory), MsgBoxStyle.Information, "Info")
                    btnSave.Enabled = False
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If drv("IncludeAdvancePaymentInBill") = True And drv("BillDeductionsStatus") = "PENDING" Then
                MsgBox("Account haven't paid the advance payment yet.", MsgBoxStyle.Information, "Info")
            End If

            If drv("TIN_B") = "" And drv("branch_code").ToString.Contains("-MF") = False Then
                Dim TIN As New FrmBorrowerTIN
                With TIN
                    .lblBorrower.Text = drv("FullN")
                    If .ShowDialog = DialogResult.OK Then
                        DataObject(String.Format("UPDATE credit_application SET TIN_B = '{1}' WHERE CreditNumber = '{0}';UPDATE profile_borrower SET TIN_B = '{1}' WHERE BorrowerID = '{2}';", cbxApplication.SelectedValue, .txtTIN.Text, drv("BorrowerID")))
                    Else
                        MsgBox("Please update the borrower's TIN once available.", MsgBoxStyle.Information, "Info")
                        'MsgBox("TIN is still not available, please fill the TIN to proceed on releasing.", MsgBoxStyle.Information, "Info")
                        'btnSave.Enabled = False
                        'Cursor = Cursors.Default
                        '.Dispose()
                        'Exit Sub
                    End If
                    .Dispose()
                End With
            Else
                btnSave.Enabled = True
            End If
            If From_JV Then
                Cursor = Cursors.Default
                Exit Sub
            End If
            Dim Reinstatement As String = DataObject(String.Format("SELECT CA.CreditNumber FROM credit_application CA INNER JOIN credit_investigation CI ON CA.`CreditNumber` = CI.`CreditNumber` WHERE CA.CI_Status = 'APPROVED' AND (CA.PaymentRequest = 'PENDING' OR CA.PaymentRequest = 'REQUEST') AND CI.`status` = 'ACTIVE' AND CI.ci_status = 'APPROVED' AND DATEDIFF(DATE(NOW()), CA.CI_ApprovedDate) >= 30 AND CA.branch_id = '{0}' AND CA.CreditNumber = '{1}';", Branch_ID, cbxApplication.SelectedValue))
            If Reinstatement = "" Then
                If drv("CV Count") > 0 Then
                    MsgBox("Please Approve the Check Voucher First before releasing.", MsgBoxStyle.Information, "Info")
                    btnSave.Enabled = False
                Else
                    btnSave.Enabled = True
                End If

                With FrmLogin
                    If .InvokeRequired Then
                        .th.Abort()
                        .th.Join()
                        .Splash.Close()
                        .Splash.Dispose()
                    Else
                        .Invoke(New FrmLogin._SubName(AddressOf .StopThread))
                    End If
                End With
                Cursor = Cursors.Default
                Exit Sub
            Else
                If Requirements > 0 Then
                    With FrmLogin
                        If .InvokeRequired Then
                            .th.Abort()
                            .th.Join()
                            .Splash.Close()
                            .Splash.Dispose()
                        Else
                            .Invoke(New FrmLogin._SubName(AddressOf .StopThread))
                        End If
                    End With
                End If
                MsgBox(String.Format("Application was not released for 30 days or more and is required to reinstatement."), MsgBoxStyle.Information, "Info")
                btnSave.Enabled = False
                Cursor = Cursors.Default
                Exit Sub
            End If
        End If
    End Sub

    Private Sub LoadAmortization()
        Cursor = Cursors.WaitCursor
        Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%y'),'') AS 'Due Date', IF(`No` = '','',Monthly) AS 'Monthly', IF(`No` = '','',InterestIncome) AS 'Interest Income', IF(`No` = '','',RPPD) AS 'RPPD', IF(`No` = '','',PrincipalAllocation) AS 'Principal Allocation', OutstandingPrincipal AS 'Outstanding Principal', Total_RPPD AS 'Total_RPPD', UnearnIncome AS 'Unearn Income', LoansReceivable AS 'Loans Receivable' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", cbxApplication.SelectedValue))
        Dim T_Monthly As Double
        Dim T_Interest As Double
        Dim T_RPPD As Double
        Dim T_Principal As Double
        LoadAmortFromCredit(GridControl3)
        For x As Integer = 1 To Temp_DT.Rows.Count - 1
            T_Monthly += CDbl(Temp_DT(x)("Monthly"))
            T_Interest += CDbl(Temp_DT(x)("Interest Income"))
            T_RPPD += CDbl(Temp_DT(x)("RPPD"))
            T_Principal += CDbl(Temp_DT(x)("Principal Allocation"))
        Next
        'If DateValue(dtpFDD.Value) <> DateValue(CDate(Temp_DT(1)("Due Date"))) Then
        '    If Temp_DT.Rows.Count = GridView3.RowCount - 1 Then
        '        For x As Integer = 1 To Temp_DT.Rows.Count - 1
        '            Temp_DT(x)("Due Date") = Format(CDate(GridView3.GetRowCellValue(x, "Due Date")), "MM.dd.yyyy")
        '        Next
        '    End If
        'End If
        ''Temp_DT.Rows.Add("", "TOTAL", T_Monthly, T_Interest, T_RPPD, T_Principal, 0, 0, 0, 0)
        GridControl2.DataSource = Temp_DT

        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        If CDbl(drv("Interest_N")) + CDbl(drv("RPPD_N")) + CDbl(drv("Principal_N")) > 0 Then
            Dim TotalInterest As Double
            Dim TotalRPPD As Double
            Dim TotalPrincipal As Double

            Dim Adjustment_Interest As Double
            Dim Adjustment_RPPD As Double
            Dim Adjustment_Principal As Double
            With GridView2
                For x As Integer = 1 To .RowCount
                    If x = .RowCount - 1 Then 'Adjustment
                        Adjustment_Interest = CDbl(.GetRowCellValue(0, "Unearn Income")) - TotalInterest
                        Adjustment_RPPD = CDbl(.GetRowCellValue(0, "Total_RPPD")) - TotalRPPD
                        Adjustment_Principal = CDbl(.GetRowCellValue(0, "Outstanding Principal")) - TotalPrincipal

                        .SetRowCellValue(x, "Outstanding Principal", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Outstanding Principal")) - Adjustment_Principal, 2))
                        .SetRowCellValue(x, "Unearn Income", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Unearn Income")) - Adjustment_Interest, 2))
                        .SetRowCellValue(x, "Total_RPPD", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Total_RPPD")) - Adjustment_RPPD, 2))
                        .SetRowCellValue(x, "Loans Receivable", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Loans Receivable")) - (Adjustment_Principal + Adjustment_Interest + Adjustment_RPPD), 2))
                    Else
                        TotalInterest += CDbl(drv("Interest_N"))
                        TotalRPPD += CDbl(drv("RPPD_N"))
                        TotalPrincipal += CDbl(drv("Principal_N"))

                        .SetRowCellValue(x, "Outstanding Principal", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Outstanding Principal")) - CDbl(drv("Principal_N")), 2))
                        .SetRowCellValue(x, "Unearn Income", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Unearn Income")) - CDbl(drv("Interest_N")), 2))
                        .SetRowCellValue(x, "Total_RPPD", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Total_RPPD")) - CDbl(drv("RPPD_N")), 2))
                        .SetRowCellValue(x, "Loans Receivable", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Loans Receivable")) - (CDbl(drv("Principal_N")) + CDbl(drv("Interest_N")) + CDbl(drv("RPPD_N"))), 2))
                    End If
                Next
            End With
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DtpFDD_ValueChanged(sender As Object, e As EventArgs) Handles dtpFDD.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            If drv("Payment Type") = "Monthly" Then
                dtpMD.Value = dtpFDD.Value.AddMonths(iTerms.Value - 1)
            ElseIf drv("Payment Type") = "Bimonthly" Then
                dtpMD.Value = BiMonthlyDate(dtpFDD.Value, iTerms.Value)
            End If

            Cursor = Cursors.WaitCursor
            If CBool(drv("ManualAmortization")) = True And CBool(drv("VerifiedManualAmort")) = True Then
                LoadAmortization()
            Else
                LoadAmortFromCredit(GridControl2)
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ITerms_ValueChanged(sender As Object, e As EventArgs) Handles iTerms.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            If drv("Payment Type") = "Monthly" Then
                dtpMD.Value = dtpFDD.Value.AddMonths(iTerms.Value - 1)
            ElseIf drv("Payment Type") = "Bimonthly" Then
                dtpMD.Value = BiMonthlyDate(dtpFDD.Value, iTerms.Value)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ForNMA(sender As Object, e As EventArgs) Handles dMR.ValueChanged, dGMA.ValueChanged, dPrincipal.ValueChanged
        If FirstLoad Or cbxApplication.SelectedIndex = -1 Then
            dNMA.Value = 0
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        If drv("Last Principal") = "Yes" Then
            dNMA.Value = dPrincipal.Value + dMR.Value
        Else
            dNMA.Value = CDbl(drv("GMA")) - dMR.Value
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnAdd.Enabled = False
            If cbxApplication.Enabled = False Then
                btnResend.Enabled = False
                If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
                    btnSave.Enabled = False
                End If
            Else
                btnSave.Enabled = True
                btnResend.Enabled = True
                btnModify.Enabled = False
            End If
            If btnModify.Enabled Then
                btnDelete.Enabled = False
            End If
            btnNext.Enabled = True
            btnAttach.Enabled = False
            btnPromissoryNote.Visible = True
            btnPrint.Enabled = False
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            btnBack.Enabled = True
            btnAdd.Enabled = True
            If cbxApplication.Enabled = False Then
            Else
                btnSave.Enabled = False
                btnModify.Enabled = False
            End If
            btnNext.Enabled = False
            btnResend.Enabled = False
            btnAttach.Enabled = True
            btnPromissoryNote.Visible = False
            btnPrint.Enabled = True
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Clear()

                LoadApplication()
            Else
                LoadData()
            End If
        End If
    End Sub

    Private Sub Clear()
        GetAccountNumber()
        cbxApplication.Enabled = True
        PanelEx10.Enabled = True
        btnSave.Text = "Relea&se"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnResend.Enabled = False
        dtpPN.CustomFormat = ""
        dtpFDD.CustomFormat = ""
        dtpReleased.CustomFormat = ""

        cbxApplication.Text = ""
        txtEmail.Text = ""
        ProductCode = ""
        txtSpouse.Text = ""
        cbxNew.Checked = True
        txtAddress.Text = ""
        txtMobile.Text = ""
        txtComaker1.Text = ""
        txtMobileC1.Text = ""
        txtComaker2.Text = ""
        txtMobileC2.Text = ""
        txtComaker3.Text = ""
        txtMobileC3.Text = ""
        txtComaker4.Text = ""
        txtMobileC4.Text = ""
        txtCollateral.Text = ""
        txtPlateNum.Text = ""
        txtMotorNum.Text = ""
        txtChassisNum.Text = ""
        txtORNumber.Text = ""
        txtColor.Text = ""
        txtTCT.Text = ""
        txtLocation.Text = ""
        txtArea.Text = ""
        txtInsuranceCom.Text = ""
        dCoverage.Value = 0
        dPremium.Value = 0
        txtCVNum.Text = ""
        btnCVNumber.Text = ""
        dPrincipal.Value = 0
        dUDI.Value = 0
        dRPPD.Value = 0
        dFaceAmount.Value = 0
        dRate.Value = 0
        dGMA.Value = 0
        dMR.Value = 0
        iTerms.Value = 0
        txtCI.Text = ""
        txtReferred.Text = ""
        txtRemarks.Text = ""
        CVNumber = ""
        dtpBirthdate_B.Value = Date.Now
        dtpExpiry.Value = Date.Now
        dtpExpiry.CustomFormat = ""
        dtpInsurance.Value = Date.Now
        dtpInsurance.CustomFormat = ""
        dtpReleased.Value = Date.Now
        dtpPN.Value = Date.Now
        dtpFDD.Value = Date.Now
        dtpMD.Value = Date.Now
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            btnSave.Text = "Update Relea&se"
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = True
            PanelEx10.Enabled = True
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim SQL As String = String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE `ReferenceN` = '{0}' AND PaidFor = 'Credit Application' AND `ORDate` = '';", cbxApplication.SelectedValue)
            SQL &= String.Format("UPDATE credit_deductbalance SET `deduct_status` = 'PENDING' WHERE `deduct_status` = 'DEDUCTED' AND CreditNumber_F = '{0}' AND `status` = 'ACTIVE';", cbxApplication.SelectedValue)
            SQL &= String.Format("UPDATE credit_released SET `status` = 'DELETED' WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", cbxApplication.SelectedValue)
            SQL &= String.Format("UPDATE check_received SET `status` = 'PENDING' WHERE AssetNumber = '{0}' AND `status` = 'ACTIVE' AND CVNumber_2 = '{1}';", cbxApplication.SelectedValue, CVNumber)
            SQL &= String.Format("UPDATE credit_application SET `PaymentRequest` = 'APPROVED REQUEST', AccountNumber = '', InsuranceComp = '', Coverage = 0, Expiry = '', Premium = 0, CVNum = '' WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue)
            SQL &= String.Format("UPDATE accounting_entry SET `Status` = 'PENDING' WHERE ReferenceN = '{0}' AND CVNumber = '{1}';", cbxApplication.SelectedValue, CVNumber)
            SQL &= String.Format("UPDATE check_voucher SET `ReceivedBy` = '', ReceivedDate = '', Voucher_Status = 'APPROVED' WHERE Payee_ID = '{0}' AND Voucher_Status = 'RECEIVED' AND DocumentNumber = '{1}';", cbxApplication.SelectedValue, CVNumber)
            DataObject(SQL)
            Logs("Payment Release", "Cancel", Reason, String.Format("Cancel Payment Release {0}", cbxApplication.SelectedValue), "", "", cbxApplication.SelectedValue)
            Clear()
            LoadData()
            LoadApplication()
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear()
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub CbxApplication_TextChanged(sender As Object, e As EventArgs) Handles cbxApplication.TextChanged
        If cbxApplication.Text = "" Then
            GridControl2.DataSource = Nothing
            Clear()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("PAYMENT RELEASE LIST", GridControl1)
            Logs("Payment Release", "Print", "[SENSITIVE] Print Payment Release List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If vSave Then
            Else
                MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If cbxApplication.Text = "" Or cbxApplication.SelectedIndex = -1 Then
                MsgBox("Please select an application to release.", MsgBoxStyle.Information, "Info")
                cbxApplication.DroppedDown = True
                Exit Sub
            End If
            If txtAccountNumber.Text = "" Then
                MsgBox("Please fill a new account number.", MsgBoxStyle.Information, "Info")
                txtAccountNumber.Focus()
                Exit Sub
            End If
            If dtpPN.CustomFormat = "" Then
                MsgBox("Please fill the PN Date.", MsgBoxStyle.Information, "Info")
                dtpPN.Focus()
                Exit Sub
            End If
            If dtpFDD.CustomFormat = "" Then
                MsgBox("Please fill the First Due Date.", MsgBoxStyle.Information, "Info")
                dtpFDD.Focus()
                Exit Sub
            End If
            If dtpReleased.CustomFormat = "" Then
                MsgBox("Please fill the Released Date.", MsgBoxStyle.Information, "Info")
                dtpReleased.Focus()
                Exit Sub
            End If

            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            If drv("DTS") = 1 And drv("CV DTS") = "" Then
                If MsgBoxYes("DTS is not yet reversed, would you like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = drv("Release_OTAC")
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                Else
                    Exit Sub
                End If
            End With

            If btnSave.Text = "Relea&se" Then
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM credit_application WHERE AccountNumber = '{0}' AND branch_id = '{1}' AND `status` = 'ACTIVE'", txtAccountNumber.Text, Branch_ID))
                    If Exist > 0 Then
                        If MsgBoxYes(String.Format("Account Number {0} is already taken, are you sure you want to proceed?.", txtAccountNumber.Text)) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If

                    Cursor = Cursors.WaitCursor
                    GetAccountNumber()
                    Dim SQL_II As String = ""
                    Dim SQL As String = "INSERT INTO credit_released SET"
                    SQL &= String.Format(" AccountNumber = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" Branch_ID = '{0}', ", Branch_ID)
                    SQL &= String.Format(" CreditNumber = '{0}';", cbxApplication.SelectedValue)
                    SQL &= "UPDATE credit_application SET"
                    SQL &= String.Format(" AccountNumber = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" InsuranceComp = '{0}', ", txtInsuranceCom.Text)
                    SQL &= String.Format(" Coverage = '{0}', ", dCoverage.Value)
                    SQL &= String.Format(" Expiry = '{0}', ", FormatDatePicker(dtpExpiry))
                    SQL &= String.Format(" Premium = '{0}', ", dPremium.Value)
                    SQL &= String.Format(" CVNum = '{0}', ", txtCVNum.Text)
                    SQL &= String.Format(" Release_Insurance = '{0}', ", FormatDatePicker(dtpInsurance))
                    SQL &= String.Format(" Released = '{0}', ", FormatDatePicker(dtpReleased))
                    SQL &= String.Format(" PN = '{0}', ", FormatDatePicker(dtpPN))
                    SQL &= String.Format(" FDD = '{0}', ", FormatDatePicker(dtpFDD))
                    SQL &= String.Format(" LDD = '{0}', ", Format(CDate(GridView2.GetRowCellValue(GridView2.RowCount - 2, "Due Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" CI = '{0}', ", txtCI.Text)
                    SQL &= String.Format(" Referred = '{0}', ", txtReferred.Text)
                    SQL &= String.Format(" Notes = '{0}', ", txtNotes.Text)
                    SQL &= String.Format(" Release_Remarks = '{0}', ", txtRemarks.Text)

                    '*************AMORTIZATION SCHEDULE 
                    SQL_II &= String.Format("UPDATE credit_schedule SET `status` = 'DELETED' WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}';", cbxApplication.SelectedValue)
                    For x As Integer = 0 To GridView2.RowCount - 2
                        If GridView2.GetRowCellValue(x, "No") = "" Then
                            SQL_II &= " INSERT INTO credit_schedule SET"
                            SQL_II &= String.Format(" CreditNumber = '{0}', ", cbxApplication.SelectedValue)
                            SQL_II &= String.Format(" `No` = '{0}', ", GridView2.GetRowCellValue(x, "No"))
                            SQL_II &= String.Format(" DueDate = '{0}', ", "")
                            SQL_II &= String.Format(" Monthly = '{0}', ", 0)
                            SQL_II &= String.Format(" InterestIncome = '{0}', ", 0)
                            SQL_II &= String.Format(" RPPD = '{0}', ", 0)
                            SQL_II &= String.Format(" PrincipalAllocation = '{0}', ", 0)
                            SQL_II &= String.Format(" OutstandingPrincipal = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Outstanding Principal")))
                            SQL_II &= String.Format(" Total_RPPD = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Total_RPPD")))
                            SQL_II &= String.Format(" UnearnIncome = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Unearn Income")))
                            SQL_II &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Loans Receivable")))
                        Else
                            SQL_II &= " INSERT INTO credit_schedule SET"
                            SQL_II &= String.Format(" CreditNumber = '{0}', ", cbxApplication.SelectedValue)
                            SQL_II &= String.Format(" `No` = '{0}', ", GridView2.GetRowCellValue(x, "No"))
                            SQL_II &= String.Format(" DueDate = '{0}', ", Format(DateValue(GridView2.GetRowCellValue(x, "Due Date")), "yyyy-MM-dd"))
                            SQL_II &= String.Format(" Monthly = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Monthly")))
                            SQL_II &= String.Format(" InterestIncome = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Interest Income")))
                            SQL_II &= String.Format(" RPPD = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "RPPD")))
                            SQL_II &= String.Format(" PrincipalAllocation = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Principal Allocation")))
                            SQL_II &= String.Format(" OutstandingPrincipal = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Outstanding Principal")))
                            SQL_II &= String.Format(" Total_RPPD = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Total_RPPD")))
                            SQL_II &= String.Format(" UnearnIncome = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Unearn Income")))
                            SQL_II &= String.Format(" LoansReceivable = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Loans Receivable")))
                        End If
                    Next
                    '*************AMORTIZATION SCHEDULE 

                    SQL_II &= String.Format("UPDATE credit_application SET `PaymentRequest` = 'RELEASED', PD_ATM = '{1}', PD_CardNumber = '{2}', PD_AccountNumber = '{3}', PD_BankID = '{4}' WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue, If(PD_ATM, 1, 0), PD_CardNumber, PD_AccountNumber, PD_BankID)
                    If From_JV Then
                        GoTo here
                    End If
                    SQL_II &= String.Format("UPDATE check_received SET `status` = 'ACTIVE' WHERE AssetNumber = '{0}' AND `status` = 'PENDING';", cbxApplication.SelectedValue)
                    SQL_II &= String.Format("UPDATE credit_deductbalance SET `deduct_status` = 'DEDUCTED' WHERE CreditNumber_F = '{0}' AND `status` = 'ACTIVE' AND deduct_status = 'PENDING';", cbxApplication.SelectedValue)
                    Dim DT_Deduct As DataTable = DataSource(String.Format("SELECT CreditNumber, UDI_Discount, AvailedRPPD, LR, AR, Penalty, Amount FROM credit_deductbalance WHERE `status` = 'ACTIVE' AND deduct_status = 'PENDING' AND CreditNumber_F = '{0}' AND Amount > 0;", cbxApplication.SelectedValue))
                    Dim SQL_Deduct As String = ""
                    If DT_Deduct.Rows.Count > 0 Then
                        For x As Integer = 0 To DT_Deduct.Rows.Count - 1
                            If ((CDbl(DT_Deduct(x)("LR")) - CDbl(DT_Deduct(x)("UDI_DIscount"))) - CDbl(DT_Deduct(x)("AvailedRPPD"))) + (CDbl(DT_Deduct(x)("Penalty")) + CDbl(DT_Deduct(x)("AR"))) <= CDbl(DT_Deduct(x)("Amount")) Then
                                SQL_Deduct = String.Format("UPDATE credit_application SET PaymentRequest = 'CLOSED', ClosedDate = '{1}' WHERE CreditNumber = '{0}';", DT_Deduct(x)("CreditNumber"), FormatDatePicker(dtpReleased))
                            End If
                        Next
                    End If

                    Dim DT_CV As DataTable = DataSource(String.Format("SELECT ID, DocumentNumber FROM check_voucher WHERE `status` = 'ACTIVE' AND voucher_status = 'APPROVED' AND Payee_ID = '{0}' AND JVNumber = '';", cbxApplication.SelectedValue))
                    For x As Integer = 0 To DT_CV.Rows.Count - 1
                        Dim CV As New FrmCheckVoucher
                        With CV
                            .Tag = 80
                            .vSave = True
                            .vUpdate = True
                            .vDelete = True
                            .vPrint = True
                            .CreditNumber = cbxApplication.SelectedValue
                            .From_PaymentRelease = True
                            .tabList.Visible = False
                            .btnNext.Enabled = False
                            .AccountNumber = DT_CV(x)("DocumentNumber")
                            If .ShowDialog = DialogResult.OK Then
                                CVNumber = .txtDocumentNumber.Text
                            Else
                                Cursor = Cursors.Default
                                Exit Sub
                            End If
                            .Dispose()
                        End With
                    Next
here:
                    SQL &= String.Format(" CVNumber = '{0}' ", DataObject(String.Format("SELECT DocumentNumber FROM check_voucher WHERE `status` = 'ACTIVE' AND voucher_status IN ('APPROVED','RECEIVED') AND Payee_ID = '{0}' ORDER BY DocumentNumber DESC LIMIT 1;", cbxApplication.SelectedValue)))
                    SQL &= String.Format(" WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue)

                    DataObject(SQL & SQL_II)
                    Logs("Payment Release", "Save", String.Format("Add new payment release {0}", txtAccountNumber.Text), "", "", "", cbxApplication.SelectedValue)

                    If txtMobile.Text.Trim = "" Or txtMobile.Text.Trim.Length <> 10 Or IsNumeric(txtMobile.Text.Trim) = False Then
                    Else
                        Dim Msg As String = String.Format("Thank you Mr/Mrs {0} for the trust you`ve placed in us. Your acct. {1} first due date will be on {2}", UpperCaseFirst(drv("LastN_B")), txtAccountNumber.Text, Format(dtpFDD.Value, "MMMM dd, yyyy"))
                        SendSMS(txtMobile.Text, Msg, False)
                    End If
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    If From_JV Then
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.PerformClick()
                    Else
                        Clear()
                        LoadData()
                        LoadApplication()
                    End If
                    Cursor = Cursors.Default
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM credit_application WHERE AccountNumber = '{0}' AND branch_id = '{1}' AND `status` = 'ACTIVE' AND ID != '{2}'", txtAccountNumber.Text, Branch_ID, ID))
                    If Exist > 0 Then
                        If MsgBoxYes(String.Format("Account Number {0} is already taken, please check your data.", txtAccountNumber.Text)) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If

                    Dim Reason As String 'Reason for change
                    If FrmReason.ShowDialog = DialogResult.OK Then
                        Reason = FrmReason.txtReason.Text
                    Else
                        Exit Sub
                    End If

                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = "UPDATE credit_application SET"
                    SQL &= String.Format(" InsuranceComp = '{0}', ", txtInsuranceCom.Text)
                    SQL &= String.Format(" Coverage = '{0}', ", dCoverage.Value)
                    SQL &= String.Format(" Expiry = '{0}', ", FormatDatePicker(dtpExpiry))
                    SQL &= String.Format(" Premium = '{0}', ", dPremium.Value)
                    SQL &= String.Format(" CVNum = '{0}', ", txtCVNum.Text)
                    SQL &= String.Format(" Release_Insurance = '{0}', ", FormatDatePicker(dtpInsurance))
                    SQL &= String.Format(" Released = '{0}', ", FormatDatePicker(dtpReleased))
                    SQL &= String.Format(" PN = '{0}', ", FormatDatePicker(dtpPN))
                    SQL &= String.Format(" FDD = '{0}', ", FormatDatePicker(dtpFDD))
                    SQL &= String.Format(" LDD = '{0}', ", Format(CDate(GridView2.GetRowCellValue(GridView2.RowCount - 2, "Due Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" CI = '{0}', ", txtCI.Text)
                    SQL &= String.Format(" Referred = '{0}', ", txtReferred.Text)
                    SQL &= String.Format(" Notes = '{0}', ", txtNotes.Text)
                    SQL &= String.Format(" Release_Remarks = '{0}' ", txtRemarks.Text)
                    SQL &= String.Format(" WHERE CreditNumber = '{0}';", cbxApplication.SelectedValue)
                    DataObject(SQL)

                    Logs("Payment Release", "Update", Reason, Changes(), "", "", cbxApplication.SelectedValue)
                    Clear()
                    LoadData()
                    LoadApplication()
                    Cursor = Cursors.Default
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtAccountNumber.Text = txtAccountNumber.Tag Then
            Else
                Change &= String.Format("Change Account Number from {0} to {1}. ", txtAccountNumber.Tag, txtAccountNumber.Text)
            End If
            If cbxNew.Tag <> "NEW" And cbxNew.Checked Then
                Change &= String.Format("Change Loan Type from {0} to {1}. ", cbxNew.Tag, cbxNew.Text.ToUpper)
            ElseIf cbxRenew.Tag <> "RENEW" And cbxRenew.Checked Then
                Change &= String.Format("Change Loan Type from {0} to {1}. ", cbxRenew.Tag, cbxRenew.Text.ToUpper)
            ElseIf cbxRestructured.Tag <> "RESTRUCTURE" And cbxRestructured.Checked Then
                Change &= String.Format("Change Loan Type from {0} to {1}. ", cbxRestructured.Tag, cbxRestructured.Text.ToUpper)
            End If
            If txtInsuranceCom.Text = txtInsuranceCom.Tag Then
            Else
                Change &= String.Format("Change Insurance Company from {0} to {1}. ", txtInsuranceCom.Tag, txtInsuranceCom.Text)
            End If
            If dCoverage.Text = dCoverage.Tag Then
            Else
                Change &= String.Format("Change Coverage from {0} to {1}. ", dCoverage.Tag, dCoverage.Text)
            End If
            If dtpExpiry.Text = dtpExpiry.Tag Then
            Else
                Change &= String.Format("Change Expiry from {0} to {1}. ", dtpExpiry.Tag, dtpExpiry.Text)
            End If
            If dPremium.Text = dPremium.Tag Then
            Else
                Change &= String.Format("Change Premium from {0} to {1}. ", dPremium.Tag, dPremium.Text)
            End If
            If txtCVNum.Text = txtCVNum.Tag Then
            Else
                Change &= String.Format("Change CV Number from {0} to {1}. ", txtCVNum.Tag, txtCVNum.Text)
            End If
            If dtpInsurance.Text = dtpInsurance.Tag Then
            Else
                Change &= String.Format("Change Insurance Date from {0} to {1}. ", dtpInsurance.Tag, dtpInsurance.Text)
            End If
            If dtpReleased.Text = dtpReleased.Tag Then
            Else
                Change &= String.Format("Change Released Date from {0} to {1}. ", dtpReleased.Tag, dtpReleased.Text)
            End If
            If dtpPN.Text = dtpPN.Tag Then
            Else
                Change &= String.Format("Change PN Date from {0} to {1}. ", dtpPN.Tag, dtpPN.Text)
            End If
            If dtpFDD.Text = dtpFDD.Tag Then
            Else
                Change &= String.Format("Change FDD Date from {0} to {1}. ", dtpFDD.Tag, dtpFDD.Text)
            End If
            If txtCI.Text = txtCI.Tag Then
            Else
                Change &= String.Format("Change CI from {0} to {1}. ", txtCI.Tag, txtCI.Text)
            End If
            If txtReferred.Text = txtReferred.Tag Then
            Else
                Change &= String.Format("Change Referred from {0} to {1}. ", txtReferred.Tag, txtReferred.Text)
            End If
            If txtNotes.Text = txtNotes.Tag Then
            Else
                Change &= String.Format("Change Notes from {0} to {1}. ", txtNotes.Tag, txtNotes.Text)
            End If
            If txtRemarks.Text = txtRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", txtRemarks.Tag, txtRemarks.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Payment Release - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        FirstLoad = True

        cbxApplication.Enabled = False
        PanelEx10.Enabled = False
        ID = GridView1.GetFocusedRowCellValue("ID")
        txtAccountNumber.Text = GridView1.GetFocusedRowCellValue("Account Number")
        txtAccountNumber.Tag = GridView1.GetFocusedRowCellValue("Account Number")

        Dim SQL As String = "SELECT C.CreditNumber, C.Product, BorrowerID, "
        SQL &= "   CONCAT('[ ', C.CreditNumber, ' ] - ', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Name',"
        SQL &= "   CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'FullN',"
        SQL &= "   CONCAT(IF(FirstN_S = '','',CONCAT(FirstN_S, ' ')), IF(MiddleN_S = '','',CONCAT(MiddleN_S, ' ')), IF(LastN_S = '','',CONCAT(LastN_S, ' ')), Suffix_S) AS 'Spouse',"
        SQL &= "   CONCAT(IF(FirstN_C1 = '','',CONCAT(FirstN_C1, ' ')), IF(MiddleN_C1 = '','',CONCAT(MiddleN_C1, ' ')), IF(LastN_C1 = '','',CONCAT(LastN_C1, ' ')), Suffix_C1) AS 'Comaker1',"
        SQL &= "   CONCAT(IF(FirstN_C2 = '','',CONCAT(FirstN_C2, ' ')), IF(MiddleN_C2 = '','',CONCAT(MiddleN_C2, ' ')), IF(LastN_C2 = '','',CONCAT(LastN_C2, ' ')), Suffix_C2) AS 'Comaker2',"
        SQL &= "   CONCAT(IF(FirstN_C3 = '','',CONCAT(FirstN_C3, ' ')), IF(MiddleN_C3 = '','',CONCAT(MiddleN_C3, ' ')), IF(LastN_C3 = '','',CONCAT(LastN_C3, ' ')), Suffix_C3) AS 'Comaker3',"
        SQL &= "   CONCAT(IF(FirstN_C4 = '','',CONCAT(FirstN_C4, ' ')), IF(MiddleN_C4 = '','',CONCAT(MiddleN_C4, ' ')), IF(LastN_C4 = '','',CONCAT(LastN_C4, ' ')), Suffix_C4) AS 'Comaker4',"
        SQL &= "   CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) AS 'Address',"
        SQL &= "   IF(FirstN_C1 = '','', IFNULL((SELECT CONCAT(IF(NoC_C = '','',CONCAT(NoC_C, ', ')), IF(StreetC_C = '','',CONCAT(StreetC_C, ', ')), IF(BarangayC_C = '','',CONCAT(BarangayC_C, ', ')), AddressC_C) FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 1 ORDER BY ID DESC LIMIT 1),'')) AS 'Address_C1',"
        SQL &= "   IF(FirstN_C2 = '','', IFNULL((SELECT CONCAT(IF(NoC_C = '','',CONCAT(NoC_C, ', ')), IF(StreetC_C = '','',CONCAT(StreetC_C, ', ')), IF(BarangayC_C = '','',CONCAT(BarangayC_C, ', ')), AddressC_C) FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 2 ORDER BY ID DESC LIMIT 1),'')) AS 'Address_C2',"
        SQL &= "   IF(FirstN_C1 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 1),'')) AS 'Mobile_C1',"
        SQL &= "   IF(FirstN_C2 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 2),'')) AS 'Mobile_C2',"
        SQL &= "   IF(FirstN_C3 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 3),'')) AS 'Mobile_C3',"
        SQL &= "   IF(FirstN_C4 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 4),'')) AS 'Mobile_C4',"
        SQL &= "   CI.Collateral AS 'Collateral',VE.PlateNum, VE.MotorNum, VE.ChassisNum, VE.ORNum, VE.BodyColor ,RE.TCT, RE.Location, RE.Area, (SELECT `code` FROM product_setup WHERE ID = C.product_id) AS 'Product_Code',TIN_B,"
        SQL &= "   (SELECT LEFT(Employee(empl_id),LOCATE(' ',Employee(empl_id)) - 1) FROM users U WHERE U.user_code = CI.user_code) AS 'CI', (SELECT payment FROM product_setup WHERE product_setup.ID = C.product_id) AS 'Payment Type',"
        SQL &= "   loan_type, Birth_B, Email_B, Mobile_B, AmountApplied, Terms, Interest, RPPD, RPPD_Rate, Face_Amount, Interest_Rate, GMA, Rebate, LastN_B, Insurance, IFNULL((SELECT IF(CVDate = '',DATE(NOW()),CVDate) FROM check_received WHERE AssetNumber = C.CreditNumber AND check_type = 'P' AND `status`  IN ('PENDING','ACTIVE') ORDER BY ID DESC LIMIT 1),DATE(NOW())) AS 'CVDate', IFNULL((SELECT CVNumber FROM check_received WHERE AssetNumber = C.CreditNumber AND check_type = 'P' AND `status`  IN ('PENDING','ACTIVE') ORDER BY ID DESC LIMIT 1),IFNULL((SELECT DocumentNumber FROM check_voucher WHERE Payee_ID = C.CreditNumber AND `status` = 'ACTIVE' LIMIT 1),'')) AS 'CVNumber', (SELECT COUNT(ID) FROM check_voucher WHERE `status` = 'ACTIVE' AND voucher_status NOT IN ('CANCELLED','DISAPPROVED') AND ApprovedID = 0 AND Payee_ID = C.CreditNumber) AS 'CV Count', PD_CardNumber, PD_AccountNumber, PD_BankID, PD_ATM, branch_code,"
        SQL &= "   CONCAT(IF(Agent = '','', CONCAT(Agent, IF(Marketing = '' AND Dealer = '','',' / '))), IF(Marketing = '','', CONCAT(Marketing, IF(Dealer = '','',' / '))), Dealer) AS 'Referred', Interest_N, RPPD_N, Principal_N, trans_date, (SELECT Last_Principal FROM product_setup WHERE product_setup.ID = C.Product_ID ) AS 'Last Principal', Release_OTAC, FDD, ManualAmortization, VerifiedManualAmort, IncludeAdvancePaymentInBill, BillDeductionsStatus"
        SQL &= " FROM credit_application C"
        SQL &= String.Format("    LEFT JOIN (SELECT CreditNumber, CINumber, user_code, Collateral FROM credit_investigation WHERE `status` = 'ACTIVE') CI ON CI.CreditNumber = C.CreditNumber", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        SQL &= "    LEFT JOIN (SELECT GROUP_CONCAT(PlateNum) AS 'PlateNum', GROUP_CONCAT(EngineNum) AS 'MotorNum', GROUP_CONCAT(ChassisNum) AS 'ChassisNum', GROUP_CONCAT(ORNum) AS 'ORNum', GROUP_CONCAT(BodyColor) AS 'BodyColor', CINumber FROM collateral_ve WHERE `status` = 'ACTIVE' GROUP BY CINumber) VE ON CI.CINumber = VE.CINumber"
        SQL &= "    LEFT JOIN (SELECT GROUP_CONCAT(TCT) AS 'TCT', GROUP_CONCAT(Location) AS 'Location', GROUP_CONCAT(CONCAT(AREA,' SQM')) AS 'Area', CINumber FROM collateral_re WHERE `status` = 'ACTIVE' GROUP BY CINumber) RE ON CI.CINumber = RE.CINumber"
        SQL &= String.Format("  WHERE C.CreditNumber = '{0}';", GridView1.GetFocusedRowCellValue("Credit Number"))
        cbxApplication.DataSource = DataSource(SQL)
        FirstLoad = False

        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        If drv("BorrowerID").ToString.Contains("C") Then
            LabelX17.Text = "Representative 1 :"
            LabelX2.Text = "Representative 2 :"
            LabelX6.Text = "Representative 3 :"
            LabelX9.Text = "Representative 4 :"
            LabelX12.Text = "Representative 5 :"

            LabelX17.Location = New Point(3, 63)
            txtSpouse.Location = New Point(146, 64)
            LabelX7.Location = New Point(3, 34)
            txtAddress.Location = New Point(146, 35)
        Else
            LabelX17.Text = "Spouse Name :"
            LabelX2.Text = "Co-Maker I :"
            LabelX6.Text = "Co-Maker II :"
            LabelX9.Text = "Co-Maker III :"
            LabelX12.Text = "Co-Maker IV :"

            LabelX17.Location = New Point(3, 34)
            txtSpouse.Location = New Point(146, 35)
            LabelX7.Location = New Point(3, 63)
            txtAddress.Location = New Point(146, 64)
        End If
        dtpPN.CustomFormat = "MMM dd, yyyy"
        dtpFDD.CustomFormat = "MMM dd, yyyy"
        dtpReleased.CustomFormat = "MMM dd, yyyy"
        With GridView1
            If .GetFocusedRowCellValue("Released") = "" Then
                dtpReleased.CustomFormat = ""
            Else
                dtpReleased.CustomFormat = "MMM dd, yyyy"
            End If
            dtpReleased.Text = .GetFocusedRowCellValue("Released")
            dtpReleased.Tag = .GetFocusedRowCellValue("Released")

            If .GetFocusedRowCellValue("PN Date") = "" Then
                dtpPN.CustomFormat = ""
            Else
                dtpPN.CustomFormat = "MMM dd, yyyy"
            End If
            dtpPN.Text = .GetFocusedRowCellValue("PN Date")
            dtpPN.Tag = .GetFocusedRowCellValue("PN Date")

            If .GetFocusedRowCellValue("FDD") = "" Then
                dtpFDD.CustomFormat = ""
            Else
                dtpFDD.CustomFormat = "MMM dd, yyyy"
            End If
            dtpFDD.Text = .GetFocusedRowCellValue("FDD")
            dtpFDD.Tag = .GetFocusedRowCellValue("FDD")
            CbxApplication_SelectedIndexChanged(sender, e)

            If .GetFocusedRowCellValue("Loan Type") = "NEW" Then
                cbxNew.Checked = True
            ElseIf .GetFocusedRowCellValue("Loan Type") = "RENEW" Then
                cbxRenew.Checked = True
            ElseIf .GetFocusedRowCellValue("Loan Type") = "RESTRUCTURE" Then
                cbxRestructured.Checked = True
            End If
            cbxNew.Tag = .GetFocusedRowCellValue("Loan Type")
            cbxRenew.Tag = .GetFocusedRowCellValue("Loan Type")
            cbxRestructured.Tag = .GetFocusedRowCellValue("Loan Type")

            txtInsuranceCom.Text = .GetFocusedRowCellValue("InsuranceComp")
            txtInsuranceCom.Tag = .GetFocusedRowCellValue("InsuranceComp")

            dCoverage.Value = .GetFocusedRowCellValue("Coverage")
            dCoverage.Tag = .GetFocusedRowCellValue("Coverage")

            If .GetFocusedRowCellValue("Expiry") = "" Then
                dtpExpiry.CustomFormat = ""
            Else
                dtpExpiry.CustomFormat = "MMM dd, yyyy"
            End If
            dtpExpiry.Text = .GetFocusedRowCellValue("Expiry")
            dtpExpiry.Tag = .GetFocusedRowCellValue("Expiry")

            dPremium.Value = .GetFocusedRowCellValue("Premium")
            dPremium.Tag = .GetFocusedRowCellValue("Premium")

            txtCVNum.Text = .GetFocusedRowCellValue("CVNum")
            btnCVNumber.Text = .GetFocusedRowCellValue("CVNum")
            txtCVNum.Tag = .GetFocusedRowCellValue("CVNum")

            If .GetFocusedRowCellValue("Insurance") = "" Then
                dtpInsurance.CustomFormat = ""
            Else
                dtpInsurance.CustomFormat = "MMM dd, yyyy"
            End If
            dtpInsurance.Text = .GetFocusedRowCellValue("Insurance")
            dtpInsurance.Tag = .GetFocusedRowCellValue("Insurance")

            If .GetFocusedRowCellValue("Released") = "" Then
                dtpReleased.CustomFormat = ""
            Else
                dtpReleased.CustomFormat = "MMM dd, yyyy"
            End If
            dtpReleased.Text = .GetFocusedRowCellValue("Released")
            dtpReleased.Tag = .GetFocusedRowCellValue("Released")

            If .GetFocusedRowCellValue("PN Date") = "" Then
                dtpPN.CustomFormat = ""
            Else
                dtpPN.CustomFormat = "MMM dd, yyyy"
            End If
            dtpPN.Text = .GetFocusedRowCellValue("PN Date")
            dtpPN.Tag = .GetFocusedRowCellValue("PN Date")

            If .GetFocusedRowCellValue("FDD") = "" Then
                dtpFDD.CustomFormat = ""
            Else
                dtpFDD.CustomFormat = "MMM dd, yyyy"
            End If
            dtpFDD.Text = .GetFocusedRowCellValue("FDD")
            dtpFDD.Tag = .GetFocusedRowCellValue("FDD")

            txtCI.Text = .GetFocusedRowCellValue("CI")
            txtCI.Tag = .GetFocusedRowCellValue("CI")

            txtReferred.Text = .GetFocusedRowCellValue("Referred")
            txtReferred.Tag = .GetFocusedRowCellValue("Referred")

            txtNotes.Text = .GetFocusedRowCellValue("Notes")
            txtNotes.Tag = .GetFocusedRowCellValue("Notes")

            txtRemarks.Text = .GetFocusedRowCellValue("Remarks")
            txtRemarks.Tag = .GetFocusedRowCellValue("Remarks")
            CVNumber = .GetFocusedRowCellValue("CVNumber")

            SuperTabControl1.SelectedTab = tabSetup
            If .GetFocusedRowCellValue("Payment") > 0 Then
                btnModify.Enabled = False
            Else
                btnModify.Enabled = True
            End If
        End With
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)

            dtpFrom.Value = monday
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = monday.AddDays(6)
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
        Else
            cbxDisplay.SelectedIndex = 0
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub GetAccountNumber()
        If cbxApplication.Enabled Or From_JV Then
            txtAccountNumber.Text = DataObject(String.Format("SELECT CONCAT('{1}', LPAD(COUNT(ID) + 1,IF(LENGTH(COUNT(ID)) < 6,6,LENGTH(COUNT(ID))),'0')) FROM credit_released WHERE branch_id = '{0}';", Branch_ID, CInt(Branch_ID).ToString("D3") & If(ProductCode = "", "", ProductCode & "-")))
        End If
    End Sub

    Private Sub DtpReleased_ValueChanged(sender As Object, e As EventArgs) Handles dtpReleased.ValueChanged
        If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            Exit Sub
        End If

        Try
            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            If drv("Payment Type") = "Monthly" Then
                dtpFDD.Value = dtpReleased.Value.AddMonths(1)
            ElseIf drv("Payment Type") = "Bimonthly" Then
                If drv("FDD") = "" Then
                    dtpFDD.Value = IIf(Format(dtpReleased.Value, "dd") >= 6 And Format(dtpReleased.Value, "dd") <= 20, Format(dtpReleased.Value, String.Format("MM.{0}.yyyy", Date.DaysInMonth(Format(dtpReleased.Value, "yyyy"), Format(dtpReleased.Value, "MM")))), IIf(Format(dtpReleased.Value, "dd") >= 1 And Format(dtpReleased.Value, "dd") <= 5, Format(dtpReleased.Value, "MM.15.yyyy"), Format(dtpReleased.Value.AddMonths(1), "MM.15.yyyy")))
                Else
                    dtpFDD.Value = drv("FDD")
                End If
            End If

            If CBool(drv("ManualAmortization")) = True And CBool(drv("VerifiedManualAmort")) = True Then
                LoadAmortization()
            Else
                LoadAmortFromCredit(GridControl2)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadAmortFromCredit(Grid As DevExpress.XtraGrid.GridControl)
        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        Dim Loans As New FrmLoanApplication
        With Loans
            .For_Schedule = True
            .SendToBack()
            .WindowState = FormWindowState.Minimized
            .Show()
            .dAmountApplied.Value = drv("AmountApplied")
            .iTerms.Value = drv("Terms")
            .cbxProduct.Text = drv("Product")
            .dtpDate.Value = dtpReleased.Value
            .dInterest_T.Value = drv("Interest_Rate")
            If CompanyMode = 0 Then
                .dRPPDRate_T.Value = 0
                .dRPPD_C.Value = 0
            Else
                .dRPPDRate_T.Value = drv("RPPD_Rate")
                .dRPPD_C.Value = drv("RPPD")
            End If
            .dUDI_C.Value = drv("Interest")
            If drv("FDD") = "" Then
            Else
                .dtpFDD.CustomFormat = "MMMM dd, yyyy"
                .dtpFDD.Value = drv("FDD")
            End If
            .LoadAmortization(Grid, True)
            .Dispose()
        End With
    End Sub

    Private Sub LoadCompanyMode()
        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        If Prev_CompanyMode = CompanyMode Then
            Exit Sub
        Else
            Prev_CompanyMode = CompanyMode
        End If
        If CompanyMode = 0 Then
            LabelX37.Text = "Interest :"
            GridColumn12.Caption = "Interest"
            LabelX41.Visible = False
            dRPPD.Visible = False
            LabelX40.Visible = False
            dMR.Visible = False

            GridColumn11.Visible = False
            If GridView2.RowCount > 19 Then
                GridColumn6.Width = 26 + (4 - 1)
                GridColumn10.Width = 57 + (15 - 4)
                GridColumn12.Width = 66 + (15 - 4)
                GridColumn7.Width = 66 + (15 - 4)
                GridColumn8.Width = 66 + (17 - 4)
            Else
                GridColumn6.Width = 26 + 4
                GridColumn10.Width = 57 + 15
                GridColumn12.Width = 66 + 15
                GridColumn7.Width = 66 + 15
                GridColumn8.Width = 66 + 17
            End If

            If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
                dGMA.Value = dMR.Value
                dFaceAmount.Value = dPrincipal.Value + dUDI.Value
            Else
                LoadAmortization()
                dFaceAmount.Value = FormatNumber(CDbl(drv("AmountApplied")) + CDbl(drv("Interest")), 2)
                dGMA.Value = FormatNumber(drv("GMA") - drv("Rebate"), 2)
            End If
        Else
            LabelX37.Text = "UDI :"
            GridColumn12.Caption = "UDI"
            LabelX41.Visible = True
            dRPPD.Visible = True
            LabelX40.Visible = True
            dMR.Visible = True

            GridColumn11.Visible = True
            If GridView2.RowCount > 19 Then
                GridColumn6.Width = 26 - 2
                GridColumn10.Width = 57 - 3
                GridColumn11.Width = 66 - 3
                GridColumn12.Width = 66 - 3
                GridColumn7.Width = 66 - 3
                GridColumn8.Width = 66 - 3
            Else
                GridColumn6.Width = 26
                GridColumn10.Width = 57
                GridColumn11.Width = 66
                GridColumn12.Width = 66
                GridColumn7.Width = 66
                GridColumn8.Width = 66
            End If

            If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
                dGMA.Value = dMR.Value
                dFaceAmount.Value = dPrincipal.Value + dUDI.Value
            Else
                LoadAmortization()
                dFaceAmount.Value = FormatNumber(drv("Face_Amount"), 2)
                dGMA.Value = FormatNumber(drv("GMA"), 2)
            End If
        End If
    End Sub

    Private Sub Timer_Date_Tick(sender As Object, e As EventArgs) Handles Timer_Date.Tick
        LoadCompanyMode()
    End Sub

    Private Sub BtnResend_Click(sender As Object, e As EventArgs) Handles btnResend.Click
        If MsgBox("Are you sure you want to RESEND the OTAC?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************
            Dim Msg As String = ""
            Dim Subject As String = ""
            Dim FName As String = ""
            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            Dim Code As String = drv("Release_OTAC")
            Dim EmailTo As String = ""
            Subject = "One Time Authorization Code " & Code & " [" & cbxApplication.SelectedValue & "]"
            Dim Requirements As String = ""
            Dim DT_Requirements As DataTable = DataSource(String.Format("SELECT Requirement(Doc_ID) AS 'Document' FROM submit_documents WHERE is_complete = 'NO' AND `status` = 'ACTIVE' AND CreditNumber = '{0}';", cbxApplication.SelectedValue))
            For x As Integer = 0 To DT_Requirements.Rows.Count - 1
                Requirements &= x + 1 & ".) " & DT_Requirements(x)("Document") & "<br>" & vbCrLf
            Next
            Dim BM As DataTable = GetBM(Branch_ID)
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Releasing of the Account of {1}." & vbCrLf, Code, cbxApplication.Text)

                If Requirements = "" Then
                Else
                    Msg &= "<br><br> List of Lacking Requirements :"
                    Msg &= vbCrLf & "<br>" & Requirements & "<br>" & vbCrLf
                End If

                Msg &= "Thank you!"
                '******* SEND SMS *********************************************************************************
                If BM(x)("Phone") = "" Then
                Else
                    SendSMS(BM(x)("Phone"), Msg.Replace("<br>", " "), True)
                End If
                '******* SEND EMAIL *********************************************************************************
                If BM(x)("EmailAdd") = "" Then
                Else
                    EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
                End If
            Next
            If btnCVNumber.Text = "" Then
            Else
                Dim CV As New FrmCheckVoucher
                With CV
                    .From_PaymentReleasePrint = True
                    .WindowState = FormWindowState.Minimized
                    .CreditNumber = btnCVNumber.Text
                    .Show()
                    .cbxAll.Checked = True
                    .btnSearch.PerformClick()
                    .vPrint = True
                    .PrintName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & btnCVNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    .GridView1_DoubleClick(sender, e)
                    .GenerateCV(True, .PrintName, .txtCheck.Text, .txtApproved.Text)
                    AttachmentFiles.Add(.PrintName)
                    .Dispose()
                End With
            End If
            If EmailTo = "" Then
            Else
                Subject = "One Time Authorization Code " & Code & " [" & cbxApplication.SelectedValue & "]"
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
            End If
            '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************
            MsgBox("Successfully Resend!" & mEmail, MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnCVNumber_Click(sender As Object, e As EventArgs) Handles btnCVNumber.Click
        If btnCVNumber.Text = "" Then
            MsgBox("Can't find this CV Number.", MsgBoxStyle.Information, "Info")
            Exit Sub
        Else
            If btnCVNumber.Text.Substring(0, 2) = "CV" Then
                Dim CV As New FrmCheckVoucher
                With CV
                    .Tag = 80
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

                    Logs("Payment Released", "Check Voucher", "Check Voucher", "", "", "", "")
                    .From_GeneralLedger = True
                    .AccountNumber = btnCVNumber.Text
                    .ShowDialog()
                    .Dispose()
                End With
            Else
                Dim Exist As String = DataObject(String.Format("SELECT ID FROM journal_voucher WHERE DocumentNumber = '{0}';", btnCVNumber.Text))
                If Exist = "" Then
                    MsgBox("Can't find this CV Number.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Dim JV As New FrmJournalVoucher
                With JV
                    .Tag = 25
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

                    Logs("Payment Released", "Journal Voucher", "Journal Voucher", "", "", "", "")
                    .From_GL = True
                    .GL_DocumentNumber = btnCVNumber.Text
                    .ShowDialog()
                    .Dispose()
                End With
            End If
        End If
    End Sub

    Private Sub BtnATM_Click(sender As Object, e As EventArgs) Handles btnATM.Click
        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        Dim PayDay As New FrmPayDayDetails
        With PayDay
            .BankID = PD_BankID
            .txtAccountNumber.Text = PD_AccountNumber
            .txtCardNumber.Text = PD_CardNumber
            .cbxYes.Checked = PD_ATM
            If drv("Product").ToString.Contains("SHOWMONEY") Then
                .txtCardNumber.Visible = False
                .LabelX2.Visible = False
                .LabelX14.Visible = True
                .cbxYes.Visible = True
            End If
            If .ShowDialog = DialogResult.OK Then
                PD_BankID = .cbxBank.SelectedValue
                PD_AccountNumber = .txtAccountNumber.Text
                PD_CardNumber = .txtCardNumber.Text
                PD_ATM = .cbxYes.Checked
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnPDC_Click(sender As Object, e As EventArgs) Handles btnPDC.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim PDC As New FrmPDCReceipt
        With PDC
            .From_PaymentRelease = True
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub IView_Click(sender As Object, e As EventArgs) Handles iView.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Requirements As New FrmRequirementsMonitoring
        With Requirements
            .Tag = 63
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            End If
            .For_Viewing = True
            .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Payment Release-" & GridView1.GetFocusedRowCellValue("Credit Number")
            .CRNumber = GridView1.GetFocusedRowCellValue("Credit Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach_Releasing")
            .ID = GridView1.GetFocusedRowCellValue("Credit Number")
            .Type = "Payment Release"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub DtpReleased_Click(sender As Object, e As EventArgs) Handles dtpReleased.Click
        dtpReleased.CustomFormat = "MMM dd, yyyy"
    End Sub

    Private Sub DtpPN_Click(sender As Object, e As EventArgs) Handles dtpPN.Click
        dtpPN.CustomFormat = "MMM dd, yyyy"
    End Sub

    Private Sub DtpFDD_Click(sender As Object, e As EventArgs) Handles dtpFDD.Click
        dtpFDD.CustomFormat = "MMM dd, yyyy"
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("Credit Number").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.RowCount > 0 Then
            Dim Ledger As New FrmAccountLedger
            With Ledger
                .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnRequirements_Click(sender As Object, e As EventArgs) Handles btnRequirements.Click
        Try
            If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
                MsgBox("Please select credit application.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Requirements As New FrmRequirementsMonitoring
        With Requirements
            .Tag = 63
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            End If
            .For_Viewing = True
            .CreditNumber = cbxApplication.SelectedValue
            .ShowDialog()
            .Dispose()

            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            Dim Mandatory As Integer = DataObject(String.Format("SELECT COUNT(S.ID) FROM submit_documents S WHERE S.BorrowerID = '{0}' AND S.CreditNumber = '{1}' AND S.`status` = 'ACTIVE' AND S.is_complete = 'NO' AND (SELECT Mandatory FROM document_setup WHERE ID = Doc_ID) = 'YES';", drv("BorrowerID"), cbxApplication.SelectedValue))
            If Mandatory > 0 Then
                MsgBox(String.Format("{0} Mandatory requirements are needed to complete. Releasing is not allowed if requirements are not complete.", Mandatory), MsgBoxStyle.Information, "Info")
                btnSave.Enabled = False
            Else
                btnSave.Enabled = True
            End If
        End With
    End Sub

    Private Sub BtnPromissoryNote_Click(sender As Object, e As EventArgs) Handles btnPromissoryNote.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim drv_B As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        Dim xPath As String = Application.StartupPath & "\Documents\Microfinance\Promissory Note.doc"
        Dim PathName As String = IO.Path.GetFileName(xPath)
        Dim File_Directory As String = String.Format("{0}\{1}\{2}\Documents\{3}", RootFolder, MainFolder, Branch_Code, "Promissory Note")
        If Not IO.Directory.Exists(File_Directory) Then
            IO.Directory.CreateDirectory(File_Directory)
        End If
        Dim FileName As String = String.Format("{0}\{1}", File_Directory, PathName)
        For x As Integer = 2 To 1000
            If IO.File.Exists(FileName) Then
                FileName = String.Format("{0}\Promissory Note of {1} ({2}).doc", File_Directory, cbxApplication.Text, x)
            End If
        Next
        IO.File.Copy(xPath, FileName)
        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)

        Dim WordApp As New word.Application With {
            .Visible = False
         }
        Dim Doc As word.Document = WordApp.Documents.Open(FileName)
        Doc = WordApp.ActiveDocument
        With Doc
            'REPLACE
            .Content.Find.Execute(FindText:="@PNNo", ReplaceWith:=txtAccountNumber.Text & vbTab & vbTab, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@DateGranted", ReplaceWith:=Format(dtpPN.Value, "MMMM dd, yyyy") & vbTab & vbTab, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@TypeOfLoan", ReplaceWith:=drv("Product") & vbTab & vbTab, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@Term", ReplaceWith:=iTerms.Text & vbTab & vbTab, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@AmountInstallment", ReplaceWith:=dGMA.Text, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@AddressBranch", ReplaceWith:="______________________", Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@MaturityDate", ReplaceWith:=Format(CDate(GridView2.GetRowCellValue(GridView2.RowCount - 2, "Due Date")), "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@InterestRateWord", ReplaceWith:=UpperCaseFirst(ConvertNumberToWords(drv("interest_rate"), False, False)), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@IntPercent", ReplaceWith:=drv("interest_rate"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@ModeOfPayment", ReplaceWith:="Cash/Check", Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@DueDay", ReplaceWith:=dtpMD.Value.Day, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@PenaltyOf", ReplaceWith:="5%", Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@FDD", ReplaceWith:=dtpFDD.Text, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@SecuredBy", ReplaceWith:="________________________________________________________________", Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@PrincipalWord", ReplaceWith:=UpperCaseFirst(ConvertNumberToWords(dPrincipal.Value, False, False)), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@PrincipalAmount", ReplaceWith:=dPrincipal.Text, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@Borrower", ReplaceWith:=UpperCaseFirst(drv("FullN")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@AddressBorower", ReplaceWith:=UpperCaseFirst(txtAddress.Text), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@Spouse", ReplaceWith:=UpperCaseFirst(txtSpouse.Text), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@AddressSpouse", ReplaceWith:=If(txtSpouse.Text = "", "", UpperCaseFirst(txtAddress.Text)), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@CoMaker1", ReplaceWith:=UpperCaseFirst(txtComaker1.Text), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@AddressCoMaker1", ReplaceWith:=UpperCaseFirst(drv("Address_C1")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@CoMaker2", ReplaceWith:=UpperCaseFirst(txtComaker2.Text), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Content.Find.Execute(FindText:="@AddressCoMaker2", ReplaceWith:=UpperCaseFirst(drv("Address_C2")), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
            .Save()
            .Close()
        End With
        Doc = Nothing

        WordApp.Quit()
        WordApp = Nothing
        Try
            Process.Start(FileName)
        Catch ex As Exception
            Try
                Process.Start(FileName.Replace("\", "/"))
            Catch ex1 As Exception
                Process.Start(FileName.Replace("/", "\"))
            End Try
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub TxtInsuranceCom_Leave(sender As Object, e As EventArgs) Handles txtInsuranceCom.Leave
        txtInsuranceCom.Text = ReplaceText(txtInsuranceCom.Text)
    End Sub
End Class