Imports word = Microsoft.Office.Interop.Word
Imports DevExpress.XtraReports.UI
Public Class FrmSOA

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public Penalty_Percent As Double = 0.05 'Penalty charge
    Public FirstLoad As Boolean = True
    Dim ID As String
    Dim Trigger_D As Boolean = True

    Dim RebateDate As String
    Dim RebateAmount As Double
    Public UDI_Amount As Double
    Public DT_Others As New DataTable
    Public From_Payment As Boolean
    Public Availed As Boolean
    Public From_OR As Boolean = False
    Dim From_dBalance_Arrears As Boolean
    '**** FOR RPPD AND PENALTY WAIVE AND EARLY SETTLEMENT
    Dim RPPD_Application As Double
    Dim TotalRPPD As Double
    Dim TotalRPPD_Payable As Double
    Dim dRPPD_P As Double
    Dim RPPD_P As Double
    Dim dUDI_P As Double
    Dim UDI_Amount_Early As Double
    Dim UDI_Percent_Early As Double
    Dim RPPD_Amount_Early As Double
    Dim dPrincipal_P As Double
    Public EarlySettlement As Boolean
    Dim TotalInterest As Double
    Dim TotalPayment As Double
    Dim Payable_Interest As Double
    Public From_JV_DTS As Boolean
    Public CreditNumber As String
    Public Availed_RPPD As Double
    Public dUDI_DTS As Double
    Public dPrincipal_DTS As Double
    Dim CurrentlyOnComputePenalty As Boolean
    '*****************************************************************SOA NOTES OF CHANGES
    '1. Change ang condition sa mga dTotal_Penalty.Value = gi tanggal ang condition nga Availed Or cbxAvailed.Checked para ma tanggal ang force availed
    '2. Change ang gipasa nga Availed from Official Receipt kay gi tanggal, wala lang usa gipasahan kay ma force og availed ang SOA bisan humana nag compute if availed ba or dli na availed
    '3. Add Daily and Weekly Computation sa SOA
    '4. Gi Dynamic na ang computation wala na nagbase sa months nag base na sa schedule
    '5. Change Weekly FROM Math.Floor(DateDiff(DateInterval.Day, dtpLastP.Value, dtpAsOf.Value) / 7) TO Math.Ceiling(DateDiff(DateInterval.Day, dtpLastP.Value, dtpAsOf.Value) / 7)
    '6. (May 04, 2020) Pang Fix ni sya if First Due Date then na timing sa Holiday or Weekend so dapat ma availed pa gihapon sya.
    '7. (May 18, 2020) Fix Bimonthly Compute Penalty
    '8. (May 26, 2020) Comment kay makacause og error 
    'If dMonthlyAmort.Value - (dTotalPayment.Value - (dMonthlyAmort.Value * PaidMonths)) > 0 And (dMonthlyAmort.Value - (dTotalPayment.Value - (dMonthlyAmort.Value * (PaidMonths - 1)))) > 0 Then
    '    PaidMonths = PaidMonths - 1
    'End If
    Private Sub FrmSOA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True
        If From_OR Then
            GoTo Here
        End If
        LoadCompanyMode()

        With CbxPrefix_B
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_B
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With cbxCreditApplication
            .DisplayMember = "Borrower"
            .ValueMember = "CreditNumber"
        End With
        LoadApplication()

        With cbxOthers
            .DisplayMember = "Others"
            .ValueMember = "ID"
            .DataSource = DataSource(String.Format("SELECT ID, Others FROM soa_others WHERE `status` = 'ACTIVE' ORDER BY Others;"))
            .SelectedIndex = -1
        End With

        With DT_Others
            .Columns.Add("Others")
            .Columns.Add("Type")
            .Columns.Add("Amount")
        End With
        Timer_Date.Start()
Here:
        With txtAccount
            .ValueMember = "ID"
            .DisplayMember = "Code"
            .DataSource = Products.Copy
        End With

        dtpAvailed.Value = Date.Now
        dtpLastP.Value = Date.Now
        dtpMaturity.Value = Date.Now
        If From_JV_DTS Then
        Else
            dtpAsOf.Value = Date.Now
        End If
        dtpRebate.Value = Date.Now

        Penalty_Percent = DefaultPenalty / 100
        dtpPenaltyRate.Value = DefaultPenalty
        dtpPenaltyRate.MinValue = DefaultPenalty

        FirstLoad = False

        If From_Payment Then
            iAccount_2.Enabled = False
            btnList.Enabled = False
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            btnCalculator.Enabled = False
        End If
        If From_JV_DTS Then
            cbxCreditApplication.SelectedIndex = 0
            RPPDCompute()
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetGroupControlExpandableFontSettings({GroupControl1})

            GetLabelWithBackgroundFontSettings({LabelX20, LabelX21, LabelX22, LabelX23, lblFDD})

            GetLabelFontSettings({LabelX2, LabelX29, LabelX18, LabelX17, LabelX7, LabelX30, LabelX32, LabelX3, LabelX5, LabelX82, LabelX6, lblTotalPayment, LabelX4, LabelX8, LabelX15, LabelX9, LabelX10, LabelX11, lblMonthsMD, LabelX14, LabelX13, LabelX86, LabelX24, LabelX19, lblBalance_Penalty, lblUpdated_Arrears, lblTotalArrears, LabelX28, LabelX31, LabelX16, LabelX27})

            GetLabelFontSettingsRed({lblProduct, LabelX12})

            GetLabelFontSettingsDefaultSize({lblOverdue, lblTotalAmountDue})

            GetTextBoxFontSettings({TxtFirstN_B, TxtMiddleN_B, TxtLastN_B, txtCompleteAdd, txtPlus63, txtMobile, txtEmail, iAccount_2, txtCollateral, txtName})

            GetCheckBoxFontSettings({cbxIncludePrint, cbxRE, cbxSL, cbxPDL, cbxSML, cbxCRD, cbxCDL, cbxUpdated, cbxAvailed, cbxAdd, cbxDeduct, cbxRebate})

            GetComboBoxFontSettings({cbxCreditApplication, CbxPrefix_B, cbxSuffix_B, txtAccount, cbxOthers})

            GetDateTimeInputFontSettings({dtpAvailed, dtpFDD, dtpLastP, dtpMaturity, dtpAsOf, dtpRebate})

            GetDoubleInputFontSettings({dDiscountP, dPrincipal, dFaceAmount, dTotalPayment, dMonthlyAmort, dRPPD, dtpPenaltyRate, dBalance_Arrears, dBalance_Penalty, dUpdated_Arrears, dUpdated_Penalty, dTotal_Arrears, dTotal_Penalty, dTotalArrears, dTotalPenalties, dDiscountRPPD, dDiscount, dDiscountedRPPD, dNetDiscount, dUnpaidPenalties, dOthers, dRebate})

            GetDoubleInputFontSettingsDefault({dOverdue, dTotalAmountDue})

            GetIntegerInputFontSettings({iDaysD, iDue, iMonthsMD})

            GetButtonFontSettings({btnDeductions, btnList, btnWaive, btnEarly, btnDeductBalanceList, btnDeductBalance, btnOthers, btnAddOthers, btnSave, btnRefresh, btnCancel, btnPrint, btnPrintD, btnDemandL, btnSMS, btnEmail, btnCalculator, btnLedger})
        Catch ex As Exception
            TriggerBugReport("SOA - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Statement of Account", lblTitle.Text)
    End Sub

    Private Sub LoadApplication()
        Dim SQL As String = "SELECT "
        SQL &= "    C.CreditNumber, C.BorrowerID, "
        SQL &= "    CONCAT(IF(AssumptionCredit = '',CONCAT(IF(C.FirstN_B = '','',CONCAT(C.FirstN_B, ' ')), IF(C.MiddleN_B = '','',CONCAT(C.MiddleN_B, ' ')), IF(C.LastN_B = '','',CONCAT(C.LastN_B, ' ')), C.Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)),' [',AccountNumber,']') AS 'Borrower',"
        SQL &= "    AmountApplied,"
        SQL &= "    Terms,"
        SQL &= "    Product_ID, Product,"
        SQL &= "    RPPD,"
        SQL &= "    Face_Amount, GMA, GMA - Rebate AS 'NMA',"
        SQL &= "    B.Prefix_B,"
        SQL &= "    IFNULL(B.FirstN_B,C.FirstN_B) AS 'FirstN_B',"
        SQL &= "    B.MiddleN_B,"
        SQL &= "    B.LastN_B,"
        SQL &= "    B.Suffix_B,"
        SQL &= "    IFNULL(B.`Complete Address`,CONCAT(IF(C.NoC_B = '', '', CONCAT(C.NoC_B, ', ')),IF(C.StreetC_B = '','',CONCAT(C.StreetC_B, ', ')),IF(C.BarangayC_B = '','',CONCAT(C.BarangayC_B, ', ')),C.AddressC_B)) AS 'Complete Address',"
        SQL &= "    IFNULL(B.Mobile_B,C.Mobile_B) AS 'Mobile_B',"
        SQL &= "    IFNULL(B.Email_B,C.Email_B) AS 'Email_B',"
        SQL &= "    Released, Interest,"
        SQL &= "    AccountNumber, FDD, LDD, DAY(FDD) AS 'Due', BillDeductions, BankID, "
        SQL &= "    IFNULL((SELECT GROUP_CONCAT(Collateral) FROM credit_investigation WHERE `Status` = 'ACTIVE' AND CI_Status = 'APPROVED' AND CreditNumber = C.CreditNumber),'') AS 'Collateral', branch_code "
        SQL &= " FROM credit_application C"
        SQL &= " LEFT JOIN  (SELECT BorrowerID, Prefix_B, FirstN_B, MiddleN_B, LastN_B, Suffix_B, CONCAT(IF(NoC_B = '', '', CONCAT(NoC_B, ', ')),IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')),IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')),AddressC_B) AS 'Complete Address', Mobile_B, Email_B FROM profile_borrower) B ON IF(C.AssumptionCredit = '',C.BorrowerID,(SELECT BorrowerID FROM credit_application WHERE credit_application.CreditNumber = C.AssumptionCredit)) = B.BorrowerID"
        SQL &= " WHERE C.`status` = 'ACTIVE' "
        If From_JV_DTS Then
            SQL &= String.Format("   AND CreditNumber = '{0}'", CreditNumber)
        End If
        SQL &= String.Format("   AND PaymentRequest IN ('RELEASED','{1}') AND Branch_ID IN ({0}) ORDER BY `Borrower`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), If(From_JV_DTS, "CLOSED", ""))
        cbxCreditApplication.DataSource = DataSource(SQL)
        cbxCreditApplication.SelectedIndex = -1
    End Sub

    Private Sub CbxVL_CheckedChanged(sender As Object, e As EventArgs) Handles cbxVL.CheckedChanged
        If cbxVL.Checked Then
            txtAccount.Text = "VL"
            cbxRE.Checked = False
            cbxSL.Checked = False
            cbxPDL.Checked = False
            cbxSML.Checked = False
            cbxCRD.Checked = False
            cbxCDL.Checked = False
        End If
    End Sub

    Private Sub CbxRE_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRE.CheckedChanged
        If cbxRE.Checked Then
            txtAccount.Text = "RE"
            cbxVL.Checked = False
            cbxSL.Checked = False
            cbxPDL.Checked = False
            cbxSML.Checked = False
            cbxCRD.Checked = False
            cbxCDL.Checked = False
        End If
    End Sub

    Private Sub CbxSL_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSL.CheckedChanged
        If cbxSL.Checked Then
            txtAccount.Text = "SL"
            cbxVL.Checked = False
            cbxRE.Checked = False
            cbxPDL.Checked = False
            cbxSML.Checked = False
            cbxCRD.Checked = False
            cbxCDL.Checked = False
        End If
    End Sub

    Private Sub CbxPDL_CheckedChanged(sender As Object, e As EventArgs) Handles cbxPDL.CheckedChanged
        If cbxPDL.Checked Then
            txtAccount.Text = "PDL"
            cbxVL.Checked = False
            cbxRE.Checked = False
            cbxSL.Checked = False
            cbxSML.Checked = False
            cbxCRD.Checked = False
            cbxCDL.Checked = False
        End If
    End Sub

    Private Sub CbxSML_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSML.CheckedChanged
        If cbxSML.Checked Then
            txtAccount.Text = "SML"
            cbxVL.Checked = False
            cbxRE.Checked = False
            cbxSL.Checked = False
            cbxPDL.Checked = False
            cbxCRD.Checked = False
            cbxCDL.Checked = False
        End If
    End Sub

    Private Sub CbxCRD_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCRD.CheckedChanged
        If cbxCRD.Checked Then
            txtAccount.Text = "CRD"
            cbxVL.Checked = False
            cbxRE.Checked = False
            cbxSL.Checked = False
            cbxPDL.Checked = False
            cbxSML.Checked = False
            cbxCDL.Checked = False
        End If
    End Sub

    Private Sub CbxCDL_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCDL.CheckedChanged
        If cbxCDL.Checked Then
            txtAccount.Text = "CDL"
            cbxVL.Checked = False
            cbxRE.Checked = False
            cbxSL.Checked = False
            cbxPDL.Checked = False
            cbxSML.Checked = False
            cbxCRD.Checked = False
        End If
    End Sub

#Region "Keydown"
    Private Sub CbxPrefix_B_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_B.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_B.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_B.Focus()
        End If
    End Sub

    Private Sub TxtLastN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_B.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCompleteAdd.Focus()
        End If
    End Sub

    Private Sub TxtCompleteAdd_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCompleteAdd.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMobile.Focus()
        End If
    End Sub

    Private Sub TxtMobile_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail.Focus()
            iAccount_2.Focus()
        End If
    End Sub

    Private Sub TxtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            iAccount_2.Focus()
        End If
    End Sub

    Private Sub IAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles iAccount_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCollateral.Focus()
        End If
    End Sub

    Private Sub TxtCollateral_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCollateral.KeyDown
        If e.KeyCode = Keys.Enter Then
            dPrincipal.Focus()
        End If
    End Sub

    Private Sub DPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles dPrincipal.KeyDown
        If e.KeyCode = Keys.Enter Then
            dFaceAmount.Focus()
        End If
    End Sub

    Private Sub DFaceAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dFaceAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTotalPayment.Focus()
        End If
    End Sub

    Private Sub DTotalPayment_KeyDown(sender As Object, e As KeyEventArgs) Handles dTotalPayment.KeyDown
        If e.KeyCode = Keys.Enter Then
            iDue.Focus()
        End If
    End Sub

    Private Sub IDue_KeyDown(sender As Object, e As KeyEventArgs) Handles iDue.KeyDown
        If e.KeyCode = Keys.Enter Then
            dMonthlyAmort.Focus()
        End If
    End Sub

    Private Sub DMonthlyAmort_KeyDown(sender As Object, e As KeyEventArgs) Handles dMonthlyAmort.KeyDown
        If e.KeyCode = Keys.Enter Then
            dRPPD.Focus()
        End If
    End Sub

    Private Sub DRRPD_KeyDown(sender As Object, e As KeyEventArgs) Handles dRPPD.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpAvailed.Focus()
        End If
    End Sub

    Private Sub DtpAvailed_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpAvailed.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpLastP.Focus()
        End If
    End Sub

    Private Sub DtpLastP_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpLastP.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpMaturity.Focus()
        End If
    End Sub

    Private Sub DtpMaturity_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpMaturity.KeyDown
        If e.KeyCode = Keys.Enter Then
            iMonthsMD.Focus()
        End If
    End Sub

    Private Sub IMonthsMD_KeyDown(sender As Object, e As KeyEventArgs) Handles iMonthsMD.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpAsOf.Focus()
        End If
    End Sub

    Private Sub DtpAsOf_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpAsOf.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBalance_Arrears.Focus()
        End If
    End Sub

    Private Sub DBalance_Arrears_KeyDown(sender As Object, e As KeyEventArgs) Handles dBalance_Arrears.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBalance_Penalty.Focus()
        End If
    End Sub

    Private Sub DBalance_Penalty_KeyDown(sender As Object, e As KeyEventArgs) Handles dBalance_Penalty.KeyDown
        If e.KeyCode = Keys.Enter Then
            dUpdated_Arrears.Focus()
        End If
    End Sub

    Private Sub DUpdated_Arrears_KeyDown(sender As Object, e As KeyEventArgs) Handles dUpdated_Arrears.KeyDown
        If e.KeyCode = Keys.Enter Then
            dUpdated_Penalty.Focus()
        End If
    End Sub

    Private Sub DUpdated_Penalty_KeyDown(sender As Object, e As KeyEventArgs) Handles dUpdated_Penalty.KeyDown
        If e.KeyCode = Keys.Enter Then
            iDaysD.Focus()
        End If
    End Sub

    Private Sub IDaysD_KeyDown(sender As Object, e As KeyEventArgs) Handles iDaysD.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTotal_Arrears.Focus()
        End If
    End Sub

    Private Sub DTotal_Arrears_KeyDown(sender As Object, e As KeyEventArgs) Handles dTotal_Arrears.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTotal_Penalty.Focus()
        End If
    End Sub

    Private Sub DTotal_Penalty_KeyDown(sender As Object, e As KeyEventArgs) Handles dTotal_Penalty.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTotalArrears.Focus()
        End If
    End Sub

    Private Sub DTotalArrears_KeyDown(sender As Object, e As KeyEventArgs) Handles dTotalArrears.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTotalPenalties.Focus()
        End If
    End Sub

    Private Sub DTotalPenalties_KeyDown(sender As Object, e As KeyEventArgs) Handles dTotalPenalties.KeyDown
        If e.KeyCode = Keys.Enter Then
            dUnpaidPenalties.Focus()
        End If
    End Sub

    Private Sub DUnpaidPenalties_KeyDown(sender As Object, e As KeyEventArgs) Handles dUnpaidPenalties.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxOthers.Focus()
        End If
    End Sub

    Private Sub TxtOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            dOthers.Focus()
        End If
    End Sub

    Private Sub DOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles dOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxRebate.Focus()
        End If
    End Sub

    Private Sub DtpRebate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpRebate.KeyDown
        If e.KeyCode = Keys.Enter Then
            dRebate.Focus()
        End If
    End Sub

    Private Sub DRebate_KeyDown(sender As Object, e As KeyEventArgs) Handles dRebate.KeyDown
        If e.KeyCode = Keys.Enter Then
            dOverdue.Focus()
        End If
    End Sub

    Private Sub DTotalAmountDue_KeyDown(sender As Object, e As KeyEventArgs) Handles dTotalAmountDue.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub DOverdue_KeyDown(sender As Object, e As KeyEventArgs) Handles dOverdue.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTotalAmountDue.Focus()
        End If
    End Sub
#End Region

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            FirstLoad = True
            LoadApplication()
            txtAccount.DataSource = Products.Copy
            FirstLoad = False

            Clear()
        End If
    End Sub

    Private Sub Clear()
        btnDeductions.Visible = False
        dtpAsOf.Enabled = True
        CurrentlyOnComputePenalty = False
        cbxCreditApplication.SelectedIndex = -1
        btnLedger.Enabled = False
        txtName.Text = ""
        txtMobile.Text = ""
        txtEmail.Text = ""
        cbxVL.Checked = True
        iAccount_2.Text = 0
        txtCollateral.Text = ""
        dPrincipal.Value = 0
        dFaceAmount.Value = 0
        dTotalPayment.Value = 0
        iDue.Value = 1
        dMonthlyAmort.Value = 0
        dRPPD.Value = 0
        dDiscountRPPD.Value = 0

        RebateDate = Date.Now
        RebateAmount = 0
        UDI_Amount = 0

        dtpAvailed.Value = Date.Now
        dtpLastP.Value = Date.Now
        dtpMaturity.Value = Date.Now
        dtpAsOf.Value = Date.Now

        dBalance_Arrears.Value = 0
        dTotalPenalties.Value = 0

        GridControl1.DataSource = Nothing
        dTotalArrears.Value = 0
        lblTotalAmountDue.Text = "Total Amount Due :"
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub GenerateSOA(Show As Boolean, FName As String)
        Dim Report As New RptSOA
        With Report
            If CompanyMode = 0 Then
                .lblRebate.Visible = False
                .lblRebateA.Visible = False
                .lblRebate_2.Visible = False
                .lblRebateA_2.Visible = False
            End If
            .Name = "Statement of Account of " & txtName.Text
            Dim Unpaid_Penalties As String = "Unpaid Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(dtpAsOf.Value, "MM.dd.yy") & ") :"
            Dim Penalties As String = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(dtpAsOf.Value, "MM.dd.yy") & ") :"
            If GridView1.RowCount > 1 Then
                Penalties = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(DateValue(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Monthly Due Date")), "MM.dd.yy") & ") :"
            ElseIf GridView1.RowCount = 1 Then
                Penalties = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(DateValue(GridView1.GetRowCellValue(0, "Monthly Due Date")), "MM.dd.yy") & ") :"
            ElseIf GridView1.RowCount = 0 Then
                Penalties = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & ") :"
            End If
            '***PAGE I
            .lblAddress.Text = Branch_Address
            .lblContact.Text = Branch_Contact
            .lblAsOf.Text = Format(dtpAsOf.Value, "MMMM dd, yyyy")
            .lblName.Text = txtName.Text
            .lblAccountNumber.Text = txtAccount.Text & "-" & iAccount_2.Text
            .lblCollateral.Text = txtCollateral.Text
            .lblPrincipal.Text = dFaceAmount.Text
            .lblMonthlyA.Text = dMonthlyAmort.Text
            .lblDateAvailed.Text = Format(dtpAvailed.Value, "MMMM dd, yyyy")
            .lblLastP.Text = Format(dtpLastP.Value, "MMMM dd, yyyy")
            .lblBalance.Text = dBalance_Arrears.Text
            If cbxIncludePrint.Checked Then
                .lblDiscount.Text = " [" & dDiscountP.Text & "%] " & dDiscount.Text
            Else
                .lblDiscount.Visible = False
                .lblDiscount_3.Visible = False
            End If
            .lblUnpaidDate.Text = Unpaid_Penalties
            .lblUnpaidPenalties.Text = dUnpaidPenalties.Text
            .lblPenaltyDates.Text = Penalties
            .lblPenalties.Text = dTotalPenalties.Text
            If DT_Others.Rows.Count <= 1 Then
                .lblOthers.Text = "Others" & If(cbxOthers.Text = "", " :", " [" & cbxOthers.Text & "] :")
                .lblOthersAmount.Text = dOthers.Text

                .lblOthers_2.Text = "Others" & If(cbxOthers.Text = "", " :", " [" & cbxOthers.Text & "] :")
                .lblOthersAmount_2.Text = dOthers.Text
            Else
                .lblOthers.Text = "Others" & If(DT_Others(0)("Others") = "", " :", " [" & DT_Others(0)("Others") & "] :")
                .lblOthersAmount.Text = FormatNumber(DT_Others(0)("Amount"), 2)

                .lblOthers_2.Text = "Others" & If(DT_Others(0)("Others") = "", " :", " [" & DT_Others(0)("Others") & "] :")
                .lblOthersAmount_2.Text = FormatNumber(DT_Others(0)("Amount"), 2)
                For x As Integer = 0 To DT_Others.Rows.Count - 1
                    If x > 0 Then
                        Dim lbl As New XRLabel
                        With lbl
                            .Text = "Others" & If(DT_Others(x)("Others") = "", " :", " [" & DT_Others(x)("Others") & "] :")
                            .LocationF = New Point(2, 425 + (25 * x))
                            .Font = New Font("Century Gothic", 11.25)
                            .ForeColor = Report.lblOthers_2.ForeColor
                            .SizeF = New Size(350, 25)
                        End With
                        .Detail.Controls.Add(lbl)
                        Dim lblAmount As New XRLabel
                        With lblAmount
                            .Text = FormatNumber(DT_Others(x)("Amount"), 2)
                            .LocationF = New Point(350, 425 + (25 * x))
                            .Font = New Font("Century Gothic", 11.25)
                            .ForeColor = Report.lblOthers_2.ForeColor
                            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                            .Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                            .BorderColor = Report.lblOthers_2.BorderColor
                            .SizeF = New Size(170, 25)
                        End With
                        .Detail.Controls.Add(lblAmount)

                        Dim lbl_2 As New XRLabel
                        With lbl_2
                            .Text = "Others" & If(DT_Others(x)("Others") = "", " :", " [" & DT_Others(x)("Others") & "] :")
                            .LocationF = New Point(532, 425 + (25 * x))
                            .Font = New Font("Century Gothic", 11.25)
                            .ForeColor = Report.lblOthers_2.ForeColor
                            .SizeF = New Size(348, 25)
                        End With
                        .Detail.Controls.Add(lbl_2)
                        Dim lblAmount_2 As New XRLabel
                        With lblAmount_2
                            .Text = FormatNumber(DT_Others(x)("Amount"), 2)
                            .LocationF = New Point(880, 425 + (25 * x))
                            .Font = New Font("Century Gothic", 11.25)
                            .ForeColor = Report.lblOthers_2.ForeColor
                            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                            .Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                            .BorderColor = Report.lblOthers_2.BorderColor
                            .SizeF = New Size(170, 25)
                        End With
                        .Detail.Controls.Add(lblAmount_2)
                    End If
                Next
                'First 3 rows
                .lblRebate.LocationF = New Point(0, 450 + (25 * (DT_Others.Rows.Count - 1)))
                .lblRebateA.LocationF = New Point(350, 450 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel1.LocationF = New Point(0, 475 + (25 * (DT_Others.Rows.Count - 1)))
                .lblOverdue.LocationF = New Point(350, 475 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel25.LocationF = New Point(0, 500 + (25 * (DT_Others.Rows.Count - 1)))
                .lblTotal.LocationF = New Point(350, 500 + (25 * (DT_Others.Rows.Count - 1)))

                .lblRebate_2.LocationF = New Point(530, 450 + (25 * (DT_Others.Rows.Count - 1)))
                .lblRebateA_2.LocationF = New Point(880, 450 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel3.LocationF = New Point(530, 475 + (25 * (DT_Others.Rows.Count - 1)))
                .lblOverdue_2.LocationF = New Point(880, 475 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel42.LocationF = New Point(530, 500 + (25 * (DT_Others.Rows.Count - 1)))
                .lblTotal_2.LocationF = New Point(880, 500 + (25 * (DT_Others.Rows.Count - 1)))
                'Signatories
                .XrLabel27.LocationF = New Point(0, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel18.LocationF = New Point(130, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel29.LocationF = New Point(260, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel31.LocationF = New Point(390, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .lblPrepared.LocationF = New Point(0, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .lblChecked.LocationF = New Point(130, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .lblNoted.LocationF = New Point(260, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .lblReceived.LocationF = New Point(390, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel33.LocationF = New Point(0, 635 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel34.LocationF = New Point(0, 660 + (25 * (DT_Others.Rows.Count - 1)))
                If (DT_Others.Rows.Count - 1) = 5 Then
                    .XrLabel33.Font = New Font("Century Gothic", 8, FontStyle.Italic)
                    .XrLabel33.SizeF = New Size(170, 15)
                    .XrLabel33.SizeF = New Size(520, 15)
                    .XrLabel34.Font = New Font("Century Gothic", 8, FontStyle.Italic)
                    .XrLabel34.SizeF = New Size(170, 15)
                    .XrLabel34.SizeF = New Size(520, 15)
                    .XrLabel34.LocationF = New Point(0, 650 + (25 * (DT_Others.Rows.Count - 1)))
                End If

                .XrLabel44.LocationF = New Point(530, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel14.LocationF = New Point(660, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel45.LocationF = New Point(790, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel46.LocationF = New Point(920, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .lblPrepared_2.LocationF = New Point(530, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .lblChecked_2.LocationF = New Point(660, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .lblNoted_2.LocationF = New Point(790, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .lblReceived_2.LocationF = New Point(920, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel50.LocationF = New Point(530, 635 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel51.LocationF = New Point(530, 660 + (25 * (DT_Others.Rows.Count - 1)))
                If (DT_Others.Rows.Count - 1) = 5 Then
                    .XrLabel50.Font = New Font("Century Gothic", 8, FontStyle.Italic)
                    .XrLabel50.SizeF = New Size(170, 15)
                    .XrLabel50.SizeF = New Size(520, 15)
                    .XrLabel51.Font = New Font("Century Gothic", 8, FontStyle.Italic)
                    .XrLabel51.SizeF = New Size(170, 15)
                    .XrLabel51.SizeF = New Size(520, 15)
                    .XrLabel51.LocationF = New Point(530, 650 + (25 * (DT_Others.Rows.Count - 1)))
                End If
            End If

            If cbxRebate.Checked Then
                .lblRebate.Visible = True
                .lblRebateA.Visible = True

                .lblRebate.Text = "Rebate as of " & Format(dtpRebate.Value, "MM.dd.yy")
                .lblRebateA.Text = If(UDI_Amount > 0, dRebate.Text & " [" & UDI_Amount & "%]", dRebate.Text)
            End If
            .lblOverdue.Text = dOverdue.Text
            .lblTotal.Text = dTotalAmountDue.Text
            .lblPrepared.Text = Empl_Name
            .lblNoted.Text = Branch_BM.ToUpper
            .lblReceived.Text = txtName.Text.ToUpper

            '***PAGE 2
            .lblAddress_2.Text = Branch_Address
            .lblContact_2.Text = Branch_Contact
            .lblAsOf_2.Text = Format(dtpAsOf.Value, "MMMM dd, yyyy")
            .lblName_2.Text = txtName.Text
            .lblAccountNumber_2.Text = txtAccount.Text & "-" & iAccount_2.Text
            .lblCollateral_2.Text = txtCollateral.Text
            .lblPrincipal_2.Text = dFaceAmount.Text
            .lblMonthlyA_2.Text = dMonthlyAmort.Text
            .lblDateAvailed_2.Text = Format(dtpAvailed.Value, "MMMM dd, yyyy")
            .lblLastP_2.Text = Format(dtpLastP.Value, "MMMM dd, yyyy")
            .lblBalance_2.Text = dBalance_Arrears.Text
            If cbxIncludePrint.Checked Then
                .lblDiscount_2.Text = " [" & dDiscountP.Text & "%] " & dDiscount.Text
            Else
                .lblDiscount_2.Visible = False
                .lblDiscount_4.Visible = False
            End If
            .lblUnpaidDate_2.Text = Unpaid_Penalties
            .lblUnpaidPenalties_2.Text = dUnpaidPenalties.Text
            .lblPenaltyDates_2.Text = Penalties
            .lblPenalties_2.Text = dTotalPenalties.Text
            If cbxRebate.Checked Then
                .lblRebate_2.Visible = True
                .lblRebateA_2.Visible = True

                .lblRebate_2.Text = "Rebate as of " & Format(dtpRebate.Value, "MM.dd.yy")
                .lblRebateA_2.Text = If(UDI_Amount > 0, dRebate.Text & " [" & UDI_Amount & "%]", dRebate.Text)
            End If
            .lblOverdue_2.Text = dOverdue.Text
            .lblTotal_2.Text = dTotalAmountDue.Text
            .lblPrepared_2.Text = Empl_Name
            .lblNoted_2.Text = Branch_BM.ToUpper
            .lblReceived_2.Text = txtName.Text.ToUpper
            Logs("Statement of Account", "Print", String.Format("Print SOA Name: {0}, Account Number: {1}, Total Loan Amount: {3}, Monthly Amortization: {4}, Date Availed: {5}, Last Payment Date: {6}, Balance Per Ledger: {7}", txtName.Text, txtAccount.Text & "-" & iAccount_2.Text, txtCollateral.Text, dPrincipal.Text, dMonthlyAmort.Text, Format(dtpAvailed.Value, "MMMM dd, yyyy"), Format(dtpLastP.Value, "MMMM dd, yyyy"), dBalance_Arrears.Text, dUnpaidPenalties.Text, dTotalPenalties.Text, If(cbxOthers.Text = "", " :", " [" & cbxOthers.Text & "] :"), dOthers.Text, dTotalAmountDue.Text, Empl_Name, Branch_BM, txtName.Text), "", "", "", "")
            If Show Then
                .ShowPreview()
            Else
                Try
                    .ExportToPdf(FName)
                Catch ex As Exception
                End Try
            End If
        End With
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GenerateSOA(True, "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtName.Text = "" Then
            MsgBox("Please fill name of borrower.", MsgBoxStyle.Information, "Info")
            txtName.Focus()
            Exit Sub
        End If
        If txtCompleteAdd.Text = "" Then
            MsgBox("Please fill complete address.", MsgBoxStyle.Information, "Info")
            txtCompleteAdd.Focus()
            Exit Sub
        End If
        If txtAccount.Text = "" Then
            MsgBox("Please select account type.", MsgBoxStyle.Information, "Info")
            txtAccount.Focus()
            Exit Sub
        End If
        If iAccount_2.Text = "0" Or iAccount_2.Text = "" Then
            MsgBox("Please fill account number.", MsgBoxStyle.Information, "Info")
            iAccount_2.Focus()
            Exit Sub
        End If
        If txtCollateral.Text = "" Then
            MsgBox("Please fill collateral.", MsgBoxStyle.Information, "Info")
            txtCollateral.Focus()
            Exit Sub
        End If
        If dPrincipal.Value = 0 Then
            MsgBox("Please fill principal amount.", MsgBoxStyle.Information, "Info")
            dPrincipal.Focus()
            Exit Sub
        End If
        If dFaceAmount.Value = 0 Then
            MsgBox("Please fill face amount.", MsgBoxStyle.Information, "Info")
            dFaceAmount.Focus()
            Exit Sub
        End If
        If iDue.Value = 0 Then
            MsgBox("Please fill due date day.", MsgBoxStyle.Information, "Info")
            iDue.Focus()
            Exit Sub
        End If
        If dMonthlyAmort.Value = 0 Then
            MsgBox("Please fill monthly amotization.", MsgBoxStyle.Information, "Info")
            dMonthlyAmort.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO soa_setup SET"
                SQL &= String.Format(" Prefix = '{0}', ", CbxPrefix_B.Text)
                SQL &= String.Format(" FirstN = '{0}', ", TxtFirstN_B.Text)
                SQL &= String.Format(" MiddleN = '{0}', ", TxtMiddleN_B.Text)
                SQL &= String.Format(" LastN = '{0}', ", TxtLastN_B.Text)
                SQL &= String.Format(" Suffix = '{0}', ", cbxSuffix_B.Text)
                SQL &= String.Format(" `Name` = '{0}', ", txtName.Text)
                SQL &= String.Format(" Address = '{0}', ", txtCompleteAdd.Text)
                SQL &= String.Format(" `MobileN` = '{0}', ", txtMobile.Text)
                SQL &= String.Format(" `EmailAdd` = '{0}', ", txtEmail.Text)
                SQL &= String.Format(" Account = '{0}', ", txtAccount.Text)
                SQL &= String.Format(" AccountNumber = '{0}', ", iAccount_2.Text)
                SQL &= String.Format(" Collateral = '{0}', ", txtCollateral.Text)
                SQL &= String.Format(" Principal = '{0}', ", dPrincipal.Value)
                SQL &= String.Format(" FaceAmount = '{0}', ", dFaceAmount.Value)
                SQL &= String.Format(" Due = '{0}', ", iDue.Value)
                SQL &= String.Format(" MonthlyAmort = '{0}', ", dMonthlyAmort.Value)
                SQL &= String.Format(" RPPD = '{0}', ", dRPPD.Value)
                SQL &= String.Format(" Availed = '{0}', ", Format(dtpAvailed.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" LastP = '{0}', ", Format(dtpLastP.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" Maturity = '{0}', ", Format(dtpMaturity.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" AsOf = '{0}', ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" Balance_Arrears = '{0}', ", dBalance_Arrears.Value)
                SQL &= String.Format(" DiscountPenalty = '{0}', ", dDiscount.Value)
                SQL &= String.Format(" UnpaidPenalty = '{0}', ", dUnpaidPenalties.Value)
                SQL &= String.Format(" Others = '{0}', ", cbxOthers.Text)
                SQL &= String.Format(" OthersAmount = '{0}', ", dOthers.Value)
                SQL &= String.Format(" OthersType = '{0}', ", If(cbxAdd.Checked, "A", "D"))
                SQL &= String.Format(" Rebate = '{0}', ", If(cbxRebate.Checked, 1, 0))
                SQL &= String.Format(" RebateDate = '{0}', ", Format(dtpRebate.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" RebateAmount = '{0}', ", dRebate.Value)
                SQL &= String.Format(" UDI_Percent = '{0}', ", UDI_Amount)
                SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                SQL &= String.Format(" User_Code = '{0}';", User_Code)

                DataObject(SQL)
                Dim MainID As Integer = DataObject(String.Format("SELECT ID FROM soa_setup WHERE AccountNumber = '{0}';", iAccount_2.Text))
                Dim SQL_II As String = ""
                For x As Integer = 0 To DT_Others.Rows.Count - 1
                    SQL_II &= "INSERT INTO soa_details SET"
                    SQL_II &= String.Format(" MainID = '{0}', ", MainID)
                    SQL_II &= String.Format(" Others = '{0}', ", DT_Others(x)("Others"))
                    SQL_II &= String.Format(" `Type` = '{0}', ", DT_Others(x)("Type"))
                    SQL_II &= String.Format(" Amount = '{0}';", DT_Others(x)("Amount"))
                Next
                DataObject(SQL_II)

                Logs("SOA", "Save", String.Format("Save new Statement of Account with Account Number {0}", txtAccount.Text & "-" & iAccount_2.Text), "", "", "", "")
                Clear()
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE soa_setup SET"
                SQL &= String.Format(" Prefix = '{0}', ", CbxPrefix_B.Text)
                SQL &= String.Format(" FirstN = '{0}', ", TxtFirstN_B.Text)
                SQL &= String.Format(" MiddleN = '{0}', ", TxtMiddleN_B.Text)
                SQL &= String.Format(" LastN = '{0}', ", TxtLastN_B.Text)
                SQL &= String.Format(" Suffix = '{0}', ", cbxSuffix_B.Text)
                SQL &= String.Format(" `Name` = '{0}', ", txtName.Text)
                SQL &= String.Format(" Address = '{0}', ", txtCompleteAdd.Text)
                SQL &= String.Format(" `MobileN` = '{0}', ", txtMobile.Text)
                SQL &= String.Format(" `EmailAdd` = '{0}', ", txtEmail.Text)
                SQL &= String.Format(" Account = '{0}', ", txtAccount.Text)
                SQL &= String.Format(" Collateral = '{0}', ", txtCollateral.Text)
                SQL &= String.Format(" Principal = '{0}', ", dPrincipal.Value)
                SQL &= String.Format(" FaceAmount = '{0}', ", dFaceAmount.Value)
                SQL &= String.Format(" Due = '{0}', ", iDue.Value)
                SQL &= String.Format(" MonthlyAmort = '{0}', ", dMonthlyAmort.Value)
                SQL &= String.Format(" RPPD = '{0}', ", dRPPD.Value)
                SQL &= String.Format(" Availed = '{0}', ", Format(dtpAvailed.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" LastP = '{0}', ", Format(dtpLastP.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" Maturity = '{0}', ", Format(dtpMaturity.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" AsOf = '{0}', ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" Balance_Arrears = '{0}', ", dBalance_Arrears.Value)
                SQL &= String.Format(" DiscountPenalty = '{0}', ", dDiscount.Value)
                SQL &= String.Format(" UnpaidPenalty = '{0}', ", dUnpaidPenalties.Value)
                SQL &= String.Format(" Others = '{0}', ", cbxOthers.Text)
                SQL &= String.Format(" OthersAmount = '{0}', ", dOthers.Value)
                SQL &= String.Format(" OthersType = '{0}', ", If(cbxAdd.Checked, "A", "D"))
                SQL &= String.Format(" Rebate = '{0}', ", If(cbxRebate.Checked, 1, 0))
                SQL &= String.Format(" RebateDate = '{0}', ", Format(dtpRebate.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" UDI_Percent = '{0}', ", UDI_Amount)
                SQL &= String.Format(" RebateAmount = '{0}'", dRebate.Value)
                SQL &= String.Format(" WHERE ID = '{0}' AND AccountNumber = '{1}';", ID, iAccount_2.Text)

                DataObject(SQL)
                Dim SQL_II As String = String.Format("UPDATE soa_details SET `status` = 'CANCELLED' WHERE MainID = '{0}' AND `status` = 'ACTIVE';", ID)
                For x As Integer = 0 To DT_Others.Rows.Count - 1
                    SQL_II &= "INSERT INTO soa_details SET"
                    SQL_II &= String.Format(" MainID = '{0}', ", ID)
                    SQL_II &= String.Format(" Others = '{0}', ", DT_Others(x)("Others"))
                    SQL_II &= String.Format(" `Type` = '{0}', ", DT_Others(x)("Type"))
                    SQL_II &= String.Format(" Amount = '{0}';", DT_Others(x)("Amount"))
                Next
                DataObject(SQL_II)

                Logs("SOA", "Update", String.Format("Update Statement of Account with Account Number {0}", txtAccount.Text & "-" & iAccount_2.Text), Changes(), "", "", "")
                Clear()
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtName.Text = txtName.Tag Then
            Else
                Change &= String.Format("Change Name from {0} to {1}. ", txtName.Tag, txtName.Text)
            End If
            If txtCompleteAdd.Text = txtCompleteAdd.Tag Then
            Else
                Change &= String.Format("Change Complete Address from {0} to {1}. ", txtCompleteAdd.Tag, txtCompleteAdd.Text)
            End If
            If txtMobile.Text = txtMobile.Tag Then
            Else
                Change &= String.Format("Change Mobile Number from {0} to {1}. ", txtMobile.Tag, txtMobile.Text)
            End If
            If txtEmail.Text = txtEmail.Tag Then
            Else
                Change &= String.Format("Change Email Address from {0} to {1}. ", txtEmail.Tag, txtEmail.Text)
            End If
            If txtAccount.Text = txtAccount.Tag Then
            Else
                Change &= String.Format("Change Account from {0} to {1}. ", txtAccount.Tag, txtAccount.Text)
            End If
            If txtCollateral.Text = txtCollateral.Tag Then
            Else
                Change &= String.Format("Change Collateral from {0} to {1}. ", txtCollateral.Tag, txtCollateral.Text)
            End If
            If dPrincipal.Value = dPrincipal.Tag Then
            Else
                Change &= String.Format("Change Principal Amount from {0} to {1}. ", dPrincipal.Tag, dPrincipal.Value)
            End If
            If dFaceAmount.Value = dFaceAmount.Tag Then
            Else
                Change &= String.Format("Change Face Amount from {0} to {1}. ", dFaceAmount.Tag, dFaceAmount.Value)
            End If
            If iDue.Value = iDue.Tag Then
            Else
                Change &= String.Format("Change Due Date Day from {0} to {1}. ", iDue.Tag, iDue.Value)
            End If
            If dMonthlyAmort.Value = dMonthlyAmort.Tag Then
            Else
                Change &= String.Format("Change Monthly Amortization from {0} to {1}. ", dMonthlyAmort.Tag, dMonthlyAmort.Value)
            End If
            If dRPPD.Value = dRPPD.Tag Then
            Else
                Change &= String.Format("Change RPPD from {0} to {1}. ", dRPPD.Tag, dRPPD.Value)
            End If
            If Format(dtpAvailed.Value, "yyyy-MM-dd") = dtpAvailed.Tag Then
            Else
                Change &= String.Format("Change Date Availed from {0} to {1}. ", Format(dtpAvailed.Tag, "MM/dd/yyyy"), Format(dtpAvailed.Value, "MM/dd/yyyy"))
            End If
            If Format(dtpLastP.Value, "yyyy-MM-dd") = dtpLastP.Tag Then
            Else
                Change &= String.Format("Change Last Payment from {0} to {1}. ", Format(dtpLastP.Tag, "MM/dd/yyyy"), Format(dtpLastP.Value, "MM/dd/yyyy"))
            End If
            If Format(dtpMaturity.Value, "yyyy-MM-dd") = dtpMaturity.Tag Then
            Else
                Change &= String.Format("Change Maturity from {0} to {1}. ", Format(dtpMaturity.Tag, "MM/dd/yyyy"), Format(dtpMaturity.Value, "MM/dd/yyyy"))
            End If
            If Format(dtpAsOf.Value, "yyyy-MM-dd") = dtpAsOf.Tag Then
            Else
                Change &= String.Format("Change As Of from {0} to {1}. ", Format(dtpAsOf.Tag, "MM/dd/yyyy"), Format(dtpAsOf.Value, "MM/dd/yyyy"))
            End If
            If dBalance_Arrears.Value = dBalance_Arrears.Tag Then
            Else
                Change &= String.Format("Change Balance Arrears from {0} to {1}. ", dBalance_Arrears.Tag, dBalance_Arrears.Value)
            End If
            If dDiscount.Value = dDiscount.Tag Then
            Else
                Change &= String.Format("Change Discount Penalties from {0} to {1}. ", dDiscount.Tag, dDiscount.Value)
            End If
            If dUnpaidPenalties.Value = dUnpaidPenalties.Tag Then
            Else
                Change &= String.Format("Change Unpaid Penalties from {0} to {1}. ", dUnpaidPenalties.Tag, dUnpaidPenalties.Value)
            End If
            If cbxOthers.Text = cbxOthers.Tag Then
            Else
                Change &= String.Format("Change Other Payment from {0} to {1}. ", cbxOthers.Tag, cbxOthers.Text)
            End If
            If dOthers.Value = dOthers.Tag Then
            Else
                Change &= String.Format("Change Other Payment Amount from {0} to {1}. ", dOthers.Tag, dOthers.Value)
            End If
            If dOthers.Value = dOthers.Tag Then
            Else
                Change &= String.Format("Change Other Payment Amount from {0} to {1}. ", dOthers.Tag, dOthers.Value)
            End If
            If cbxRebate.Tag.ToString <> "0" And cbxRebate.Checked Then
                Change &= "Change Rebate from Without Rebate to With Rebate. "
                If Format(dtpRebate.Value, "yyyy-MM-dd") = dtpRebate.Tag Then
                Else
                    Change &= String.Format("Change Rebate Date from {0} to {1}. ", Format(dtpRebate.Tag, "MM/dd/yyyy"), Format(dtpRebate.Value, "MM/dd/yyyy"))
                End If
                If dRebate.Value = dRebate.Tag Then
                Else
                    Change &= String.Format("Change Rebate Amount from {0} to {1}. ", dRebate.Tag, dRebate.Value)
                End If
            ElseIf cbxRebate.Tag.ToString <> "1" And cbxRebate.Checked = False Then
                Change &= "Change Rebate from With Rebate to Without Rebate. "
            End If
        Catch ex As Exception
            TriggerBugReport("SOA - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If From_Payment Or From_JV_DTS Then
            If e.KeyCode = Keys.Escape Then
                btnCancel.Focus()
                btnCancel.PerformClick()
            End If
        End If
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.X Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.U Then
            If dTotalPayment.Enabled Then
                txtAccount.Enabled = False
                dTotalPayment.Enabled = False
                iMonthsMD.Enabled = False
                dUpdated_Arrears.Enabled = False
                iDaysD.Enabled = False
                dTotal_Arrears.Enabled = False
                dBalance_Penalty.Enabled = False
                dUpdated_Penalty.Enabled = False
                dTotal_Penalty.Enabled = False
                dTotalArrears.Enabled = False
                dTotalPenalties.Enabled = False
                dTotalPenalties.Enabled = False
                dOverdue.Enabled = False
                dTotalAmountDue.Enabled = False
                dtpPenaltyRate.Enabled = False
            Else
                txtAccount.Enabled = True
                dTotalPayment.Enabled = True
                iMonthsMD.Enabled = True
                dUpdated_Arrears.Enabled = True
                iDaysD.Enabled = True
                dTotal_Arrears.Enabled = True
                dBalance_Penalty.Enabled = True
                dUpdated_Penalty.Enabled = True
                dTotal_Penalty.Enabled = True
                dTotalArrears.Enabled = True
                dTotalPenalties.Enabled = True
                dTotalPenalties.Enabled = True
                dOverdue.Enabled = True
                dTotalAmountDue.Enabled = True
                dtpPenaltyRate.Enabled = True

                dtpLastP.Enabled = True
            End If
        ElseIf e.KeyCode = Keys.Right Then
            GroupControl1.Location = New Point(482, 327)
            GroupControl1.Size = New Point(665, 255)
            GridControl3.Visible = True
            GroupControl1.Text = "Amortization Schedule"
        ElseIf e.KeyCode = Keys.Left Then
            GroupControl1.Size = New Point(45, 255)
            GroupControl1.Location = New Point(482, 327)
            GridControl3.Visible = False
            GroupControl1.Text = ""
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    '*******************Formula
    Private Sub DFaceAmount_ValueChanged(sender As Object, e As EventArgs) Handles dFaceAmount.ValueChanged
        dTotalPayment.Value = dFaceAmount.Value - dBalance_Arrears.Value
        dUpdated_Arrears.MaxValue = dFaceAmount.Value
    End Sub

    Private Sub DBalance_Arrears_ValueChanged(sender As Object, e As EventArgs) Handles dBalance_Arrears.ValueChanged
        If GridView3.RowCount = 0 Then
            Exit Sub
        End If

        ComputeMD()
        From_dBalance_Arrears = True
        dTotalPayment.Value = dFaceAmount.Value - (dBalance_Arrears.Value + If(DateValue(dtpLastP.Value) = DateValue(dtpAsOf.Value) And DateValue(dtpLastP.Value) = DateValue(GridView3.GetFocusedRowCellValue("Due Date")), CDbl(GridView3.GetFocusedRowCellValue("RPPD")), 0))

        If (cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "") And From_OR = False Or dTotalPayment.Value = 0 Or txtAccount.SelectedIndex = -1 Or txtAccount.Text = "" Then
            iDaysD.Value = DateDiff(DateInterval.Day, dtpLastP.Value, dtpAsOf.Value)
            dTotal_Arrears.Value = dBalance_Arrears.Value - dUpdated_Arrears.Value
        Else
            Dim drvP As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
            iDaysD.Value = DateDiff(DateInterval.Day, If(GridView3.RowCount > 0 And dTotal_Arrears.Value = 0 And If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value > 0, If(dUpdated_Arrears.Value <= GridView3.GetRowCellValue(If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), GridView3.GetRowCellValue(If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Due Date"), dtpLastP.Value), dtpLastP.Value), dtpAsOf.Value)
            dTotal_Arrears.Value = dBalance_Arrears.Value - If(GridView3.RowCount > 0, If(dUpdated_Arrears.Value <= GridView3.GetRowCellValue(If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), GridView3.GetRowCellValue(If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), dUpdated_Arrears.Value), dUpdated_Arrears.Value) - If(iDaysD.Value < If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 1, 0), dtpAsOf.Value), 0) And ((dBalance_Arrears.Value - dUpdated_Arrears.Value) < (dMonthlyAmort.Value - dRPPD.Value)) And DateValue(dtpMaturity.Value) >= DateValue(dtpAsOf.Value), dRPPD.Value, 0)
        End If
        dTotalAmountDue.Value = Decimal50((dBalance_Arrears.Value + NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)
        DTotalPayment_ValueChanged(sender, e)
    End Sub

    Private Sub IMonthsMD_ValueChanged(sender As Object, e As EventArgs) Handles iMonthsMD.ValueChanged
        If txtAccount.SelectedIndex = -1 Then
            Exit Sub
        End If

        If cbxCreditApplication.SelectedIndex = -1 And From_OR = False Then
            Dim drv As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
            If drv("Product").ToString.ToUpper.Contains("DEALER") Then
                dUpdated_Arrears.Value = iMonthsMD.Value * dMonthlyAmort.Value + dPrincipal.Value
            Else
                If drv("Payment").ToString.Contains("Bimonthly") Then
                    dUpdated_Arrears.Value = (iMonthsMD.Value * 2) * dMonthlyAmort.Value
                ElseIf drv("Payment").ToString.Contains("Weekly") Or drv("Payment").ToString.Contains("Daily") Then
                    dUpdated_Arrears.Value = GridView3.GetRowCellValue((GridView3.RowCount - 2) - iMonthsMD.Value, "Loans Receivable")
                Else
                    dUpdated_Arrears.Value = iMonthsMD.Value * dMonthlyAmort.Value
                End If
            End If
        Else
            Dim UpdatedSinceLastPayment As Double = dFaceAmount.Value
            For x As Integer = 1 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
                Else
                    If dtpLastP.Value >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                        UpdatedSinceLastPayment = CDbl(GridView3.GetRowCellValue(x, "Loans Receivable"))
                    End If
                End If
            Next
            dUpdated_Arrears.Value = UpdatedSinceLastPayment
        End If
    End Sub

    Private Sub DMonthlyAmort_ValueChanged(sender As Object, e As EventArgs) Handles dMonthlyAmort.ValueChanged
        If FirstLoad Or txtAccount.SelectedIndex = -1 Then
            Exit Sub
        End If

        If cbxCreditApplication.SelectedIndex = -1 And From_OR = False Then
            Dim drv As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
            If drv("Product").ToString.ToUpper.Contains("DEALER") Then
                dUpdated_Arrears.Value = iMonthsMD.Value * dMonthlyAmort.Value + dPrincipal.Value
            Else
                If drv("Payment").ToString.Contains("Bimonthly") Then
                    dUpdated_Arrears.Value = (iMonthsMD.Value * 2) * dMonthlyAmort.Value
                ElseIf drv("Payment").ToString.Contains("Weekly") Or drv("Payment").ToString.Contains("Daily") Then
                    dUpdated_Arrears.Value = GridView3.GetRowCellValue((GridView3.RowCount - 2) - iMonthsMD.Value, "Loans Receivable")
                Else
                    dUpdated_Arrears.Value = iMonthsMD.Value * dMonthlyAmort.Value
                End If
            End If
        Else
            Dim UpdatedSinceLastPayment As Double = dFaceAmount.Value
            For x As Integer = 1 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
                Else
                    If dtpLastP.Value >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                        UpdatedSinceLastPayment = CDbl(GridView3.GetRowCellValue(x, "Loans Receivable"))
                    End If
                End If
            Next
            dUpdated_Arrears.Value = UpdatedSinceLastPayment

            ComputePenalties()
        End If
    End Sub

    Private Sub DUpdated_Arrears_ValueChanged(sender As Object, e As EventArgs) Handles dUpdated_Arrears.ValueChanged
        If (cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "") And From_OR = False Then
            dTotal_Arrears.Value = dBalance_Arrears.Value - dUpdated_Arrears.Value
        Else
            If txtAccount.SelectedIndex = -1 Then
                Exit Sub
            End If
            Dim drvP As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
            dTotal_Arrears.Value = dBalance_Arrears.Value - If(GridView3.RowCount > 0, If(dUpdated_Arrears.Value <= GridView3.GetRowCellValue(If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), GridView3.GetRowCellValue(If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), dUpdated_Arrears.Value), dUpdated_Arrears.Value) - If(iDaysD.Value < If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 1, 0), dtpAsOf.Value), 0) And ((dBalance_Arrears.Value - dUpdated_Arrears.Value) < (dMonthlyAmort.Value - dRPPD.Value)) And DateValue(dtpMaturity.Value) >= DateValue(dtpAsOf.Value), dRPPD.Value, 0)
        End If
    End Sub

    Private Sub DtpLastP_ValueChanged(sender As Object, e As EventArgs) Handles dtpLastP.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If
        ComputeMD()

        Dim drv As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
        If (cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "") And From_OR = False Or dTotalPayment.Value = 0 Or txtAccount.SelectedIndex = -1 Or txtAccount.Text = "" Then
            iDaysD.Value = DateDiff(DateInterval.Day, dtpLastP.Value, dtpAsOf.Value)
        Else
            iDaysD.Value = DateDiff(DateInterval.Day, If(GridView3.RowCount > 0 And dTotal_Arrears.Value = 0 And If(drv("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value > 0, If(dUpdated_Arrears.Value <= GridView3.GetRowCellValue(If(drv("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), GridView3.GetRowCellValue(If(drv("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Due Date"), dtpLastP.Value), dtpLastP.Value), dtpAsOf.Value)
        End If
        ComputePenalties()
    End Sub

    Private Sub DtpAsOf_ValueChanged(sender As Object, e As EventArgs) Handles dtpAsOf.ValueChanged
        If FirstLoad Or GridView3.RowCount = 0 Then
            Exit Sub
        End If

        dtpRebate.Value = dtpAsOf.Value
        ComputeRPPD()
        dBalance_Arrears.Value = NegativeNotAllowed(dFaceAmount.Value - (dTotalPayment.Value + If(DateValue(dtpLastP.Value) = DateValue(dtpAsOf.Value) And DateValue(dtpLastP.Value) = DateValue(GridView3.GetFocusedRowCellValue("Due Date")), CDbl(GridView3.GetFocusedRowCellValue("RPPD")), 0)))
        If (cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "") And From_OR = False Or dTotalPayment.Value = 0 Or txtAccount.SelectedIndex = -1 Or txtAccount.Text = "" Then
            iDaysD.Value = DateDiff(DateInterval.Day, dtpLastP.Value, dtpAsOf.Value)
            dTotal_Arrears.Value = dBalance_Arrears.Value - dUpdated_Arrears.Value
        Else
            Dim drv As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
            iDaysD.Value = DateDiff(DateInterval.Day, If(GridView3.RowCount > 0 And dTotal_Arrears.Value = 0 And If(drv("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value > 0, If(dUpdated_Arrears.Value <= GridView3.GetRowCellValue(If(drv("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), GridView3.GetRowCellValue(If(drv("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Due Date"), dtpLastP.Value), dtpLastP.Value), dtpAsOf.Value)
            dTotal_Arrears.Value = dBalance_Arrears.Value - If(GridView3.RowCount > 0, If(dUpdated_Arrears.Value <= GridView3.GetRowCellValue(If(drv("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), GridView3.GetRowCellValue(If(drv("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), dUpdated_Arrears.Value), dUpdated_Arrears.Value) - If(iDaysD.Value < If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 1, 0), dtpAsOf.Value), 0) And ((dBalance_Arrears.Value - dUpdated_Arrears.Value) < (dMonthlyAmort.Value - dRPPD.Value)) And DateValue(dtpMaturity.Value) >= DateValue(dtpAsOf.Value), dRPPD.Value, 0)
        End If
        ComputePenalties()

        'EARLY SETTLEMENT
        Dim DT_Early As DataTable = DataSource(String.Format("SELECT LR, UDI_Discount, AvailedRPPD, AR, Penalty FROM credit_earlysettlement WHERE CreditNumber = '{0}' AND AsOf >= '{1}' AND `status` = 'ACTIVE' AND early_status = 'PENDING';", If(cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "", CreditNumber, cbxCreditApplication.SelectedValue), Format(dtpAsOf.Value, "yyyy-MM-dd")))
        If DT_Early.Rows.Count > 0 Then
            Dim PayablePrincipal As Double = GridView3.GetRowCellValue(0, "Outstanding Principal")
            Dim PayableInterest As Double = GridView3.GetRowCellValue(0, "Unearn Income")
            Dim PayableRPPD As Double = GridView3.GetRowCellValue(0, "Total_RPPD")
            dRPPD_P = NegativeNotAllowed(((PayableRPPD - TotalRPPD) - DT_Early(0)("AvailedRPPD")) + If(TotalRPPD_Payable > TotalRPPD And dtpAsOf.Value.Day > CDate(GridView3.GetFocusedRowCellValue("Due Date")).Day, CDbl(GridView3.GetFocusedRowCellValue("RPPD")), 0))
            dUDI_P = NegativeNotAllowed((PayableInterest - TotalInterest) - DT_Early(0)("UDI_Discount"))
            dPrincipal_P = PayablePrincipal - TotalPayment
            UDI_Amount_Early = DT_Early(0)("UDI_Discount")
            RPPD_Amount_Early = DT_Early(0)("AvailedRPPD")
            dRebate.Value = DT_Early(0)("UDI_Discount") + DT_Early(0)("AvailedRPPD")

            RPPD_P = dRPPD_P
            EarlySettlement = True
            lblTotalAmountDue.Text = "Liquidating Value :"
        Else
            dRebate.Value = 0
            EarlySettlement = False
            lblTotalAmountDue.Text = "Total Amount Due :"
        End If

        Dim DT_Waive As DataTable = DataSource(String.Format("SELECT IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('RPPD-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{2}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived RPPD', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('Penalty-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{2}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived Penalty' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", If(cbxCreditApplication.SelectedIndex = -1, CreditNumber, ValidateComboBox(cbxCreditApplication)), From_JV_DTS, Format(dtpAsOf.Value, "yyyy-MM-dd")))
        If DT_Waive.Rows.Count > 0 Then
            dDiscount.Value = DT_Waive(0)("Total Waived Penalty")
            dDiscountRPPD.Value = DT_Waive(0)("Total Waived RPPD")
        Else
            dDiscount.Value = 0
            dDiscountRPPD.Value = 0
        End If
        'EARLY SETTLEMENT
    End Sub

    Private Sub Compute()
        Cursor = Cursors.WaitCursor
        Dim drv As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
        TotalRPPD_Payable = 0
        dRPPD_P = 0
        dUDI_P = 0
        dPrincipal_P = 0
        Payable_Interest = 0
        EarlySettlement = False
        RPPD_Application = 0
        Dim AdvanceLastPay As Date
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                RPPD_Application += GridView3.GetRowCellValue(x, "RPPD")
                If DateValue(dtpAsOf.Value) >= CDate(GridView3.GetRowCellValue(x, "Due Date")).AddDays(BankingDays(If(cbxAvailed.Checked And NegativeNotAllowed(TotalRPPD_Payable - TotalRPPD) < CDbl(GridView3.GetRowCellValue(x, "RPPD")), AvailedRPPD + 0, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))) Then
                    TotalRPPD_Payable += GridView3.GetRowCellValue(x, "RPPD")
                End If
                If dBalance_Arrears.Value <= CDbl(GridView3.GetRowCellValue(x, "Loans Receivable")) Then
                    AdvanceLastPay = GridView3.GetRowCellValue(x, "Due Date")
                End If
            End If
        Next
        If dtpLastP.Value <= AdvanceLastPay Then
            dtpLastP.Value = AdvanceLastPay
        End If
        Dim AsOf As Date = dtpAsOf.Value
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                If dtpAsOf.Value >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                    GridView3.FocusedRowHandle = x
                    AsOf = dtpAsOf.Value
                    dUDI_P += GridView3.GetRowCellValue(x, "Interest Income")
                    dPrincipal_P += GridView3.GetRowCellValue(x, "Principal Allocation")
                ElseIf x = GridView3.RowCount - 2 And dtpAsOf.Value < CDate(GridView3.GetRowCellValue(1, "Due Date")) Then
                    GridView3.FocusedRowHandle = 1
                    AsOf = dtpAsOf.Value
                    dUDI_P += GridView3.GetRowCellValue(1, "Interest Income")
                    dPrincipal_P += GridView3.GetRowCellValue(1, "Principal Allocation")
                ElseIf x <= GridView3.FocusedRowHandle And Format(dtpAsOf.Value, "yyyy-MM") = Format(CDate(GridView3.GetRowCellValue(x, "Due Date")), "yyyy-MM") Then
                    dUDI_P += GridView3.GetRowCellValue(1, "Interest Income")
                    dPrincipal_P += GridView3.GetRowCellValue(1, "Principal Allocation")
                End If
            End If
            If x > GridView3.FocusedRowHandle Then
                Exit For
            End If
        Next
        If GridColumn5.Visible Then 'FOR NAAY PENALTY SA AMORTIZATION
            dMonthlyAmort.Value = GridView3.GetFocusedRowCellValue("Monthly")
        End If

        If (DateValue(dtpAsOf.Value) > CDate(GridView3.GetFocusedRowCellValue("Due Date")).AddDays(If(dFaceAmount.Value - (TotalPayment + TotalRPPD + TotalInterest) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle - 1, "Loans Receivable")), If(GridView3.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))), 0))) Or (TotalRPPD = 0 And dRPPD_P > 0) Then
        Else
            TotalRPPD_Payable = NegativeNotAllowed(TotalRPPD_Payable - GridView3.GetRowCellValue(1, "RPPD"))
        End If
        If CompanyMode = 0 Then
            dRPPD_P = 0
        Else
            dRPPD_P = NegativeNotAllowed(TotalRPPD_Payable - TotalRPPD)
        End If
        dUDI_P = NegativeNotAllowed(dUDI_P - TotalInterest)
        If dUDI_P > 0 Then
            Payable_Interest = dUDI_P
            If dBalance_Arrears.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")) And TotalPayment > dPrincipal_P Then
                dUDI_P -= Math.Abs(dPrincipal_P - TotalPayment)
            ElseIf dBalance_Arrears.Value < CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle - 1, "Loans Receivable")) And GridView3.FocusedRowHandle > 1 And TotalPayment > dPrincipal_P Then
                dUDI_P -= Math.Abs(dPrincipal_P - TotalPayment)
            End If
        End If
        If btnCalculator.Enabled = False And If(txtAccount.Items.Count > 0 And txtAccount.SelectedIndex <> -1, drv("PRODUCT").ToString.Contains("SHOWMONEY"), "False") = False Then
            dUDI_P = 0
        End If
        dPrincipal_P = NegativeNotAllowed(dPrincipal_P - TotalPayment)
        Cursor = Cursors.Default
    End Sub

    Private Sub ComputeRPPD()
        RPPD_Application = 0
        TotalRPPD_Payable = 0
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                RPPD_Application += GridView3.GetRowCellValue(x, "RPPD")
                If DateValue(dtpAsOf.Value) >= CDate(GridView3.GetRowCellValue(x, "Due Date")).AddDays(BankingDays(If(cbxAvailed.Checked And NegativeNotAllowed(TotalRPPD_Payable - TotalRPPD) < CDbl(GridView3.GetRowCellValue(x, "RPPD")), AvailedRPPD + 0, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))) Then
                    TotalRPPD_Payable += GridView3.GetRowCellValue(x, "RPPD")
                End If
            End If
        Next
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                If DateValue(dtpAsOf.Value) >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                    GridView3.FocusedRowHandle = x
                ElseIf x = GridView3.RowCount - 2 And DateValue(dtpAsOf.Value) < CDate(GridView3.GetRowCellValue(1, "Due Date")) Then
                    GridView3.FocusedRowHandle = 1
                End If
            End If
            If x > GridView3.FocusedRowHandle Then
                Exit For
            End If
        Next

        If GridView3.RowCount > 0 Then
            If (DateValue(dtpAsOf.Value) > CDate(GridView3.GetFocusedRowCellValue("Due Date")).AddDays(If(dFaceAmount.Value - (TotalPayment + TotalRPPD + TotalInterest) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle - 1, "Loans Receivable")), If(GridView3.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))), 0))) Or (TotalRPPD = 0 And dRPPD_P > 0) Then
                'TotalRPPD_Payable = 0
            Else
                TotalRPPD_Payable = NegativeNotAllowed(TotalRPPD_Payable - GridView3.GetRowCellValue(1, "RPPD"))
            End If
        End If
        If CompanyMode = 0 Then
            dRPPD_P = 0
        Else
            dRPPD_P = NegativeNotAllowed(TotalRPPD_Payable - TotalRPPD)
        End If
    End Sub

    Private Sub ComputeMD()
        If DateValue(dtpMaturity.Value) > DateValue(dtpLastP.Value) Then
            iMonthsMD.Value = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) + If(dtpLastP.Value < dtpMaturity.Value And dtpLastP.Value.Day < dtpMaturity.Value.Day And If(dtpLastP.Value.Day < dtpMaturity.Value.Day And dtpLastP.Value.Day = DateAndTime.Day(dtpLastP.Value.Date) And dtpMaturity.Value.Day = DateAndTime.Day(dtpMaturity.Value.Date), 0, 1), 1, 0)
        ElseIf DateValue(dtpAsOf.Value) > DateValue(dtpMaturity.Value) Then
            iMonthsMD.Value = 0
        ElseIf DateValue(dtpLastP.Value) <= DateValue(dtpFDD.Value) Then
            iMonthsMD.Value = CompleteMonthsBetweenA(dtpAvailed.Value, dtpMaturity.Value) - CompleteMonthsBetweenA(dtpAvailed.Value, dtpLastP.Value)
        ElseIf dMonthlyAmort.Value * CompleteMonthsBetweenA(dtpAvailed.Value, dtpLastP.Value) = dTotalPayment.Value Then
            'If Updated
            iMonthsMD.Value = CompleteMonthsBetweenA(dtpAvailed.Value, dtpMaturity.Value) - CompleteMonthsBetweenA(dtpAvailed.Value, dtpLastP.Value)
        ElseIf dMonthlyAmort.Value * CompleteMonthsBetweenA(dtpAvailed.Value, dtpLastP.Value) > dTotalPayment.Value - dMonthlyAmort.Value Then
            If dtpLastP.Value.Day = iDue.Value Then
                iMonthsMD.Value = CompleteMonthsBetweenA(dtpLastP.Value, dtpMaturity.Value)
            ElseIf dtpLastP.Value.Day < iDue.Value Then
                iMonthsMD.Value = CompleteMonthsBetweenA(dtpLastP.Value, dtpMaturity.Value) + 1
            Else
                iMonthsMD.Value = CompleteMonthsBetweenA(dtpLastP.Value, dtpMaturity.Value) + If(dtpLastP.Value < dtpMaturity.Value And dtpLastP.Value.Day < dtpMaturity.Value.Day And (dtpLastP.Value.Day >= dtpMaturity.Value.Day Or dtpLastP.Value.Day <> DateAndTime.Day(dtpLastP.Value.Date) Or dtpMaturity.Value.Day <> DateAndTime.Day(dtpMaturity.Value.Date)), 1, 0)
            End If
        Else
            iMonthsMD.Value = CompleteMonthsBetweenA(dtpLastP.Value, dtpMaturity.Value)
        End If
        If txtAccount.SelectedIndex = -1 Or txtAccount.Text = "" Then
            Exit Sub
        End If
        Dim drv As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
        If drv("payment").ToString.Contains("Daily") Or drv("payment").ToString.Contains("Weekly") Then
            Dim TermsRemaining As Integer
            For x As Integer = 1 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
                Else
                    If If(dtpLastP.Value > dtpMaturity.Value, dtpMaturity.Value, dtpLastP.Value) <= GridView3.GetRowCellValue(x, "Due Date") And dtpLastP.Value < dtpMaturity.Value Then
                        TermsRemaining += 1
                    End If
                End If
            Next
            iMonthsMD.Value = TermsRemaining
        End If
        If dBalance_Arrears.Value < dUpdated_Arrears.Value And dBalance_Arrears.Value + dRPPD.Value < dUpdated_Arrears.Value And dMonthlyAmort.Value > 0 And If(txtAccount.SelectedIndex = -1, 0, drv("Product").ToString.ToUpper.Contains("DEALER") = False) Then
            Dim Advance As Double = dUpdated_Arrears.Value - dBalance_Arrears.Value
            Dim xTerms As Integer = Math.Ceiling(Advance / dMonthlyAmort.Value)
            iMonthsMD.Value = iMonthsMD.Value - xTerms
            If xTerms > 0 Then
                ComputePenalties()
            End If
        End If
    End Sub

    Private Sub DtpMaturity_ValueChanged(sender As Object, e As EventArgs) Handles dtpMaturity.ValueChanged
        ComputeMD()
    End Sub

    Private Sub DTotal_Arrears_ValueChanged(sender As Object, e As EventArgs) Handles dTotal_Arrears.ValueChanged
        If (cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "") And From_OR = False Then
            If dBalance_Arrears.Value <= dUpdated_Arrears.Value And dTotalPayment.Value > 0 Then 'Or dBalance_Arrears.Value <= 0 Then
                Availed = True
            Else
                Availed = False
            End If
        Else
            If dBalance_Arrears.Value <= If(GridView3.RowCount > 0, If(dUpdated_Arrears.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")), CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")), dUpdated_Arrears.Value), dUpdated_Arrears.Value) And dUpdated_Arrears.Value - If(GridView3.RowCount > 0, CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")), 0) >= dMonthlyAmort.Value Then
                Availed = True
            Else
                Availed = False
            End If
        End If

        If dTotal_Arrears.Value < dMonthlyAmort.Value And GridView1.RowCount = 0 And False Then 'PARA DLI MUAGI DRI KAY MAKASAYOP NOON KUNG NA PAST DUE
            dTotal_Penalty.Value = 0
        ElseIf CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) > 0 And dtpLastP.Value >= dtpMaturity.Value Then
            dTotal_Penalty.Value = (dBalance_Arrears.Value * Penalty_Percent * iDaysD.Value) / 30
        Else
            'If iDaysD.Value < If(Availed Or cbxAvailed.Checked, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), dtpAsOf.Value), 0) Then
            If iDaysD.Value < If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), dtpAsOf.Value), 0) Then
                dTotal_Penalty.Value = 0
            Else
                dTotal_Penalty.Value = (dTotal_Arrears.Value * Penalty_Percent * iDaysD.Value) / 30
            End If
        End If

        Dim TotalArrears As Double
        For x As Integer = 0 To GridView1.RowCount - 1
            TotalArrears += CDbl(GridView1.GetRowCellValue(x, "Arrears"))
        Next
        dTotalArrears.Value = TotalArrears + dTotal_Arrears.Value
    End Sub

    Private Sub IDaysD_ValueChanged(sender As Object, e As EventArgs) Handles iDaysD.ValueChanged
        If (cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "") And From_OR = False Then
            If dBalance_Arrears.Value <= dUpdated_Arrears.Value And dTotalPayment.Value > 0 Then 'Or dBalance_Arrears.Value <= 0 Then
                Availed = True
            Else
                Availed = False
            End If
        Else
            If dBalance_Arrears.Value <= If(GridView3.RowCount > 0, If(dUpdated_Arrears.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")), CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")), dUpdated_Arrears.Value), dUpdated_Arrears.Value) And dUpdated_Arrears.Value - If(GridView3.RowCount > 0, CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")), 0) >= dMonthlyAmort.Value Then
                Availed = True
            Else
                Availed = False
            End If
        End If

        If dTotal_Arrears.Value < dMonthlyAmort.Value And GridView1.RowCount = 0 And False Then 'PARA DLI MUAGI DRI KAY MAKASAYOP NOON KUNG NA PAST DUE
            dTotal_Penalty.Value = 0
        ElseIf CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) > 0 And dtpLastP.Value >= dtpMaturity.Value Then
            dTotal_Penalty.Value = (dBalance_Arrears.Value * Penalty_Percent * iDaysD.Value) / 30
        Else
            'If iDaysD.Value < If(Availed Or cbxAvailed.Checked, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), dtpAsOf.Value), 0) Then
            If iDaysD.Value < If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), dtpAsOf.Value), 0) Then
                dTotal_Penalty.Value = 0
            Else
                dTotal_Penalty.Value = (dTotal_Arrears.Value * Penalty_Percent * iDaysD.Value) / 30
            End If
        End If
    End Sub

    Private Sub DTotalPenalties_ValueChanged(sender As Object, e As EventArgs) Handles dTotalPenalties.ValueChanged
        dTotalAmountDue.Value = Decimal50((dBalance_Arrears.Value + NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)

        dOverdue.Value = Decimal50((NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + (dTotalArrears.Value - dDiscountRPPD.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)

        Trigger_D = False
        dDiscountP.Value = (dDiscount.Value / dTotalPenalties.Value) * 100
        Trigger_D = True
        dNetDiscount.Value = dTotalPenalties.Value - dDiscount.Value
        If dTotalPenalties.Value + dUnpaidPenalties.Value > 0 Then
            btnWaive.Visible = True
        Else
            btnWaive.Visible = False
        End If
    End Sub

    Private Sub DUnpaidPenalties_ValueChanged(sender As Object, e As EventArgs) Handles dUnpaidPenalties.ValueChanged
        dTotalAmountDue.Value = Decimal50((dBalance_Arrears.Value + NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)

        dOverdue.Value = Decimal50((NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + (dTotalArrears.Value - dDiscountRPPD.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)
        If dTotalPenalties.Value + dUnpaidPenalties.Value > 0 Then
            btnWaive.Visible = True
        Else
            btnWaive.Visible = False
        End If
    End Sub

    Private Sub DTotalArrears_ValueChanged(sender As Object, e As EventArgs) Handles dTotalArrears.ValueChanged
        dDiscountedRPPD.Value = dTotalArrears.Value - dDiscountRPPD.Value
        dOverdue.Value = Decimal50((NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + (dTotalArrears.Value - dDiscountRPPD.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)
    End Sub

    Private Sub DTotalPayment_ValueChanged(sender As Object, e As EventArgs) Handles dTotalPayment.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        If From_dBalance_Arrears Then
            From_dBalance_Arrears = False
        Else
            ComputeMD()
            ComputePenalties()
        End If
    End Sub

    Private Sub DtpAvailed_ValueChanged(sender As Object, e As EventArgs) Handles dtpAvailed.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        ComputePenalties()
    End Sub

    Private Sub ComputePenalties()
        If FirstLoad Or dMonthlyAmort.Value = 0 Or CurrentlyOnComputePenalty Then
            Exit Sub
        End If
        CurrentlyOnComputePenalty = True
        Dim drv As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
        Cursor = Cursors.WaitCursor
        If cbxAvailed.Checked Then
            Availed = True
        ElseIf cbxUpdated.Checked Then
            If dTotalPayment.Value = 0 Then
                Availed = False
            Else
                Availed = True
            End If
        Else
            If (cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "") And From_OR = False Then
                If dBalance_Arrears.Value <= dUpdated_Arrears.Value And dTotalPayment.Value > 0 Then 'Or dBalance_Arrears.Value <= 0 Then
                    Availed = True
                Else
                    Availed = False
                End If
            Else
                If dBalance_Arrears.Value <= If(GridView3.RowCount > 0, If(dUpdated_Arrears.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")), CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")), dUpdated_Arrears.Value), dUpdated_Arrears.Value) And dUpdated_Arrears.Value - If(GridView3.RowCount > 0, CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")), 0) >= dMonthlyAmort.Value Then
                    Availed = True
                Else
                    Availed = False
                End If
            End If
        End If
        If dTotalPayment.Value = 0 Then
            Availed = False
        End If
        Try
            Dim PaidMonths As Integer = 0
            Dim TermsPassed As Integer = 0
            Dim From_AsOf As Integer = 0
            Dim NotUpdated As Integer = 0
            Dim DT As New DataTable
            With DT
                .Columns.Add("Monthly Due Date")
                .Columns.Add("Days Delayed")
                .Columns.Add("Arrears")
                .Columns.Add("Penalty")
            End With
            If drv("payment") = "Bimonthly" Then
                '*** B I M O N T H L Y   P A Y M E N T ***************************************************************************************
                PaidMonths = Math.Ceiling(dTotalPayment.Value / dMonthlyAmort.Value)
                From_AsOf = CompleteMonthsBetweenBimonthly(dtpLastP.Value, dtpAsOf.Value)
                If CompleteMonthsBetweenBimonthly(dtpMaturity.Value, dtpAsOf.Value) > 0 Then
                    From_AsOf = CompleteMonthsBetweenBimonthly(dtpLastP.Value, dtpMaturity.Value)
                End If
                NotUpdated = If(dTotal_Arrears.Value > 0, Math.Ceiling(dTotal_Arrears.Value / dMonthlyAmort.Value), 0) + DateDiff(DateInterval.Month, dtpLastP.Value, dtpAsOf.Value)
                'OK RA ANG FROM_ASOF MAG SOBRA KAY MA FILTER NAMAN SA PAG ROWS.ADD
                From_AsOf = DateDiff(DateInterval.Month, dtpFDD.Value, dtpMaturity.Value) + 1

                For x As Integer = 0 To From_AsOf - 1
                    If (DT.Rows.Count > 1 Or dTotal_Penalty.Value > 0) And Availed Then
                        Availed = False
                    End If
                    If dtpLastP.Value < BiMonthlyDate(dtpFDD.Value, x) And DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value) >= 0 And DateValue(BiMonthlyDate(dtpFDD.Value, x)) <= dtpAsOf.Value And DateValue(BiMonthlyDate(dtpFDD.Value, x)) <= dtpMaturity.Value Then
                        DT.Rows.Add(BiMonthlyDate(dtpFDD.Value, x), DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value), If(DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((dMonthlyAmort.Value - dRPPD.Value) / 2, 2), FormatNumber(dMonthlyAmort.Value / 2, 2)), FormatNumber((((dMonthlyAmort.Value / 2) * Penalty_Percent * If(DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0, DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value)) / 30)), 2))
                        If x > 0 Then
                            If BiMonthlyDate(dtpFDD.Value, x) < BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x) And DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), dtpAsOf.Value) >= 0 And DateValue(BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x)) <= dtpAsOf.Value And BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x) > dtpFDD.Value And BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x) <= dtpMaturity.Value Then
                                DT.Rows.Add(BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), dtpAsOf.Value), If(DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), dtpAsOf.Value) = 0, FormatNumber((dMonthlyAmort.Value - dRPPD.Value) / 2, 2), FormatNumber(dMonthlyAmort.Value / 2, 2)), FormatNumber((((dMonthlyAmort.Value / 2) * Penalty_Percent * DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), dtpAsOf.Value)) / 30), 2))
                            End If
                        End If
                    End If
                Next
                'If PaidMonths <= NotUpdated Then
                '    For x As Integer = 0 To From_AsOf - 1
                '        If dtpLastP.Value < BiMonthlyDate(dtpFDD.Value, x) And DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value) >= 0 And DateValue(BiMonthlyDate(dtpFDD.Value, x)) <= dtpAsOf.Value And DateValue(BiMonthlyDate(dtpFDD.Value, x)) <= dtpMaturity.Value Then
                '            DT.Rows.Add(BiMonthlyDate(dtpFDD.Value, x), DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value), If(DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((dMonthlyAmort.Value - dRPPD.Value) / 2, 2), FormatNumber(dMonthlyAmort.Value / 2, 2)), FormatNumber((((dMonthlyAmort.Value / 2) * Penalty_Percent * If(DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0, DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x), dtpAsOf.Value)) / 30)), 2))
                '            If x > 0 Then
                '                If BiMonthlyDate(dtpFDD.Value, x) < BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x) And DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), dtpAsOf.Value) >= 0 And DateValue(BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x)) <= dtpAsOf.Value And BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x) > dtpFDD.Value And BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x) <= dtpMaturity.Value Then
                '                    DT.Rows.Add(BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), dtpAsOf.Value), If(DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), dtpAsOf.Value) = 0, FormatNumber((dMonthlyAmort.Value - dRPPD.Value) / 2, 2), FormatNumber(dMonthlyAmort.Value / 2, 2)), FormatNumber((((dMonthlyAmort.Value / 2) * Penalty_Percent * DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x), dtpAsOf.Value)) / 30), 2))
                '                End If
                '            End If
                '        End If
                '    Next
                'Else
                '    For x As Integer = 0 To From_AsOf - 1
                '        If DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x + PaidMonths), dtpAsOf.Value) >= 0 And DateValue(BiMonthlyDate(dtpFDD.Value, x + PaidMonths)) <= dtpAsOf.Value And DateValue(BiMonthlyDate(dtpFDD.Value, x)) <= dtpMaturity.Value Then
                '            DT.Rows.Add(BiMonthlyDate(dtpFDD.Value, x + PaidMonths), DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x + PaidMonths), dtpAsOf.Value), If(DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x + PaidMonths), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((dMonthlyAmort.Value - dRPPD.Value) / 2, 2), FormatNumber(dMonthlyAmort.Value / 2, 2)), FormatNumber((((dMonthlyAmort.Value / 2) * Penalty_Percent * If(DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x + PaidMonths), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0, DateDiff(DateInterval.Day, BiMonthlyDate(dtpFDD.Value, x + PaidMonths), dtpAsOf.Value))) / 30), 2))
                '            If DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x + PaidMonths), dtpAsOf.Value) >= 0 And DateValue(BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x + PaidMonths)) <= dtpAsOf.Value And BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x + PaidMonths) > dtpFDD.Value And DateValue(BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x + PaidMonths)) <= dtpAsOf.Value And BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x + PaidMonths) <= dtpMaturity.Value Then
                '                DT.Rows.Add(BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x + PaidMonths), DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x + PaidMonths), dtpAsOf.Value), If(DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x + PaidMonths), dtpAsOf.Value) = 0, FormatNumber((dMonthlyAmort.Value - dRPPD.Value) / 2, 2), FormatNumber(dMonthlyAmort.Value / 2, 2)), FormatNumber((((dMonthlyAmort.Value / 2) * Penalty_Percent * DateDiff(DateInterval.Day, BiMonthlyDateV2(DateValue(DT(DT.Rows.Count - 1)("Monthly Due Date")), dtpFDD.Value, x + PaidMonths), dtpAsOf.Value)) / 30), 2))
                '            End If
                '        End If
                '    Next
                'End If
            Else
                '*** M O N T H L Y   P A Y M E N T ***************************************************************************************
                'PaidMonths = Math.Ceiling(dTotalPayment.Value / dMonthlyAmort.Value)
                If drv("payment") = "Monthly" Then
                    From_AsOf = CompleteMonthsBetweenA(dtpLastP.Value, dtpAsOf.Value)
                    If CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) > 0 Then
                        From_AsOf = CompleteMonthsBetweenA(dtpLastP.Value, dtpMaturity.Value) + If(dtpLastP.Value.Day > dtpMaturity.Value.Day, 1, 0)
                    End If
                ElseIf drv("payment") = "Daily" Then
                    From_AsOf = DateDiff(DateInterval.Day, dtpLastP.Value, dtpAsOf.Value)
                ElseIf drv("payment") = "Weekly" Then
                    From_AsOf = Math.Ceiling(DateDiff(DateInterval.Day, dtpLastP.Value, dtpAsOf.Value) / 7)
                End If
                'NotUpdated = If(dTotal_Arrears.Value > 0, Math.Ceiling(dTotal_Arrears.Value / dMonthlyAmort.Value), 0) + DateDiff(DateInterval.Month, dtpLastP.Value, dtpAsOf.Value)
                'TermsPassed = CompleteMonthsBetweenA(dtpAvailed.Value, If(dtpLastP.Value > dtpMaturity.Value, dtpMaturity.Value, dtpLastP.Value))
                For x As Integer = 1 To GridView3.RowCount - 1
                    If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
                    Else
                        If dFaceAmount.Value - dTotalPayment.Value < GridView3.GetRowCellValue(x - 1, "Loans Receivable") Then
                            PaidMonths += 1
                        ElseIf dFaceAmount.Value - dTotalPayment.Value >= GridView3.GetFocusedRowCellValue("Loans Receivable") And x <= GridView3.FocusedRowHandle Then
                            NotUpdated += 1
                        End If
                        If If(dtpLastP.Value > dtpMaturity.Value, dtpMaturity.Value, dtpLastP.Value) >= GridView3.GetRowCellValue(x, "Due Date") Then
                            TermsPassed += 1
                        End If
                    End If
                Next
                If From_AsOf = 0 And NotUpdated > 0 Then
                    From_AsOf = NotUpdated
                End If
                If drv("payment") = "Monthly" Then
                    If (dtpAsOf.Value.Day = iDue.Value And From_AsOf = 0) Or (dtpAsOf.Value.Day < iDue.Value And dtpAsOf.Value.Day = Date.DaysInMonth(dtpAsOf.Value.Year, dtpAsOf.Value.Month)) Then
                        From_AsOf += 1
                    End If
                End If
                'IF LAST PAYMENT KAY NAKA ADVANCE GAMAY NYA NA PENALTY MAG MINUS LANG SA NEXT PAYABLE
                If TermsPassed > 0 And PaidMonths > 0 And dBalance_Arrears.Value < dUpdated_Arrears.Value And dBalance_Arrears.Value - dUpdated_Arrears.Value < dMonthlyAmort.Value - dRPPD.Value Then
                    'If not Updated since last computation of penalty
                    If drv("payment") = "Monthly" Then
                        From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpAsOf.Value)
                        If CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) > 0 Then
                            'IF DUE DATE NA TAPOS ANG ANG LAST PAYMENT KAY WALA PA KAABOT SA DUE DATE MAG PENALTY GIHAPON.
                            If DateDiff(DateInterval.Day, dtpLastP.Value, dtpMaturity.Value) > 0 And DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) = 0 Then
                                From_AsOf = 1
                            ElseIf CompleteMonthsBetweenA(dtpLastP.Value, dtpMaturity.Value) = 1 And DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) = 1 Then
                                From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) + 1
                            Else
                                If dtpLastP.Value.Day >= iDue.Value Then
                                    From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value)
                                Else
                                    From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) + 1
                                End If
                            End If
                        End If
                        If dtpAsOf.Value.Day >= iDue.Value And CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) <= 0 Then
                            From_AsOf += 1
                        End If
                    End If
                    Dim Advanced As Double
                    If dBalance_Arrears.Value = 0 Then
                        dBalance_Arrears.Value = NegativeNotAllowed(dFaceAmount.Value - (dTotalPayment.Value + If(DateValue(dtpLastP.Value) = DateValue(dtpAsOf.Value) And DateValue(dtpLastP.Value) = DateValue(GridView3.GetFocusedRowCellValue("Due Date")), CDbl(GridView3.GetFocusedRowCellValue("RPPD")), 0)))
                    End If
                    If dUpdated_Arrears.Value > dBalance_Arrears.Value And dBalance_Arrears.Value > 0 Then
                        Advanced = dUpdated_Arrears.Value - dBalance_Arrears.Value
                    End If
                    For x As Integer = 1 To From_AsOf
                        If (DT.Rows.Count > 1 Or dTotal_Penalty.Value > 0) And Availed Then
                            Availed = False
                        End If
                        If DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) >= 0 And DateValue(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))) <= dtpAsOf.Value Then
                            If DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))) >= dtpMaturity.Value And drv("Last_Principal") = "Yes" And dtpAsOf.Value >= dtpMaturity.Value Then 'CAR DEALER
                                If If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber(NegativeNotAllowed(((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True) - Advanced))), 2), FormatNumber(NegativeNotAllowed((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - Advanced)), 2)) = 0 Then
                                Else
                                    DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"), DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value), If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber(NegativeNotAllowed(((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True) - Advanced))), 2), FormatNumber(NegativeNotAllowed((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - Advanced)), 2)), FormatNumber(NegativeNotAllowed(((((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - Advanced)) * Penalty_Percent * NegativeNotAllowed(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) - If((dUpdated_Arrears.Value >= dBalance_Arrears.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))))), If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0))) / 30)), 2))
                                    Advanced = If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber(NegativeNotAllowed(((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True) - Advanced))), 2), FormatNumber(NegativeNotAllowed((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - Advanced)), 2))
                                End If
                            Else
                                If If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber(NegativeNotAllowed((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True) - Advanced)), 2), FormatNumber(NegativeNotAllowed((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - Advanced)), 2)) = 0 Then
                                Else
                                    DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"), DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value), If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber(NegativeNotAllowed((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True) - Advanced)), 2), FormatNumber(NegativeNotAllowed((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - Advanced)), 2)), FormatNumber(NegativeNotAllowed((((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - Advanced) * Penalty_Percent * NegativeNotAllowed(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) - If(dUpdated_Arrears.Value >= dBalance_Arrears.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))), If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0))) / 30)), 2)) 'AvailedPenalty - AvailedPenalty para i zero ra naku ang Availed Penalty kay dli diay dapat sya availed penalty nya gi tapol naku mag adjust basig naa matandog.
                                    Advanced = NegativeNotAllowed(Advanced - If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber(NegativeNotAllowed((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True) - Advanced)), 2), FormatNumber(NegativeNotAllowed((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - Advanced)), 2)))
                                End If
                            End If
                        End If
                    Next
                ElseIf PaidMonths < TermsPassed Then
                    If drv("payment") = "Monthly" Then
                        'If not Updated since last computation of penalty
                        From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpAsOf.Value)
                        If CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) > 0 Then
                            'IF DUE DATE NA TAPOS ANG ANG LAST PAYMENT KAY WALA PA KAABOT SA DUE DATE MAG PENALTY GIHAPON.
                            If DateDiff(DateInterval.Day, dtpLastP.Value, dtpMaturity.Value) > 0 And DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) = 0 Then
                                From_AsOf = 1
                            ElseIf CompleteMonthsBetweenA(dtpLastP.Value, dtpMaturity.Value) = 1 And DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) = 1 Then
                                From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) + 1
                            Else
                                If dtpLastP.Value.Day >= iDue.Value Then
                                    From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value)
                                Else
                                    From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) + 1
                                End If
                            End If
                        End If
                        If dtpAsOf.Value.Day >= iDue.Value And CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) <= 0 Then
                            From_AsOf += 1
                        End If
                        From_AsOf += 1
                    End If
                    For x As Integer = 1 To From_AsOf
                        If (DT.Rows.Count > 1 Or dTotal_Penalty.Value > 0) And Availed Then
                            Availed = False
                        End If
                        If iDaysD.Value > 0 And iDaysD.Value <= DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) Then
                            GoTo here
                        End If
                        If DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) >= 0 And DateValue(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1)))) <= dtpAsOf.Value Then
                            If DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))) >= dtpMaturity.Value And drv("Last_Principal") = "Yes" And dtpAsOf.Value >= dtpMaturity.Value Then 'CAR DEALER
                                If If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True)), 2), FormatNumber(GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False), 2)) = 0 Then
                                Else
                                    'DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"), DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value), If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True)), 2), FormatNumber(GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False), 2)), FormatNumber((((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) * Penalty_Percent * DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value)) / 30), 2))
                                    DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"),
                                    DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value),
                                    If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True)), 2), FormatNumber(GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False), 2)),
                                    If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0, FormatNumber((((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) * Penalty_Percent * DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value)) / 30), 2)))
                                End If
                            Else
                                If If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber(GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True), 2), GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) = 0 Then
                                Else
                                    'DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"), DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value), If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True)), 2), FormatNumber(GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False), 2)), FormatNumber((((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) * Penalty_Percent * DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value)) / 30), 2))
                                    DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"),
                                    DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value),
                                    If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), True)), 2), FormatNumber(GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False), 2)),
                                    If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0, FormatNumber((((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) * Penalty_Percent * DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value)) / 30), 2)))
                                End If
                            End If
                        End If
here:
                    Next
                Else
                    If drv("payment") = "Monthly" Then
                        'IF Updated since last payment pero dugay na wala nakabayad pag usab.
                        If dtpAsOf.Value.Day >= iDue.Value And (NotUpdated * dMonthlyAmort.Value <= dTotalPayment.Value Or cbxUpdated.Checked) And CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) <= 0 Then
                            From_AsOf += 1
                        ElseIf dtpAsOf.Value.Day < dtpLastP.Value.Day Then
                            From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpAsOf.Value)
                            If CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) > 0 Then

                                'IF DUE DATE NA TAPOS ANG ANG LAST PAYMENT KAY WALA PA KAABOT SA DUE DATE MAG PENALTY GIHAPON.
                                If DateDiff(DateInterval.Day, dtpLastP.Value, dtpMaturity.Value) > 0 And DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) = 0 Then
                                    From_AsOf = 1
                                ElseIf CompleteMonthsBetweenA(dtpLastP.Value, dtpMaturity.Value) = 1 And DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) = 1 Then
                                    From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) + 1
                                Else
                                    If dtpLastP.Value.Day >= iDue.Value Then
                                        From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value)
                                    Else
                                        From_AsOf = DateDiff(DateInterval.Month, dtpLastP.Value, dtpMaturity.Value) + 1
                                    End If
                                End If
                            End If
                        End If
                        'ADD LANG OG From_AsOF + 1 kay para ma fix ang problem kay gi condition man sad pwede ra jud manobra ang From_AsOf (July 15, 2019)
                        From_AsOf += 1
                        'FOR CAR DEALER BAND AID SOLUTION PARA DLI MA LAPAS ANG FROM_ASOF SA TERMS
                        If drv("Last_Principal") = "Yes" And From_AsOf > CompleteMonthsBetweenA(dtpFDD.Value, dtpMaturity.Value) Then
                            From_AsOf = CompleteMonthsBetweenA(dtpFDD.Value, dtpMaturity.Value)
                        End If
                    End If
                    For x As Integer = 1 To From_AsOf
                        If x = 1 And dTotalPayment.Value >= dMonthlyAmort.Value * NotUpdated Then
                            '**** FOR CHECKING PURPOSES ONLY ***********************************************************************
                            If (cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "") And From_OR = False Or dTotalPayment.Value = 0 Or txtAccount.SelectedIndex = -1 Or txtAccount.Text = "" Then
                                iDaysD.Value = DateDiff(DateInterval.Day, dtpLastP.Value, dtpAsOf.Value)
                            Else
                                Dim drvP As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
                                iDaysD.Value = DateDiff(DateInterval.Day, If(GridView3.RowCount > 0 And dTotal_Arrears.Value = 0 And If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value > 0, If(dUpdated_Arrears.Value <= GridView3.GetRowCellValue(If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Loans Receivable"), GridView3.GetRowCellValue(If(drvP("Payment").ToString.Contains("Bimonthly"), (GridView3.RowCount - 2) / 2, (GridView3.RowCount - 2)) - iMonthsMD.Value, "Due Date"), dtpLastP.Value), dtpLastP.Value), dtpAsOf.Value)
                            End If
                            '**** FOR CHECKING PURPOSES ONLY ***********************************************************************
                            'If dMonthlyAmort.Value - (dTotalPayment.Value - (dMonthlyAmort.Value * PaidMonths)) > 0 And (dMonthlyAmort.Value - (dTotalPayment.Value - (dMonthlyAmort.Value * (PaidMonths - 1)))) > 0 Then
                            '    PaidMonths = PaidMonths - 1
                            'End If
                            If DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) > BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))) Or dTotal_Penalty.Value > 0 Then
                                Availed = False
                            End If
                            If DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))) > dtpLastP.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) >= 0 And DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))) <= CDate(dtpAsOf.Value) And DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))) > CDate(dtpLastP.Value) And iDaysD.Value > DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) Then
                                If DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))) >= dtpMaturity.Value And drv("Last_Principal") = "Yes" And dtpAsOf.Value >= dtpMaturity.Value Then 'CAR DEALER
                                    DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"), DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value), If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) < If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), True)), 2), FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) - (dTotalPayment.Value - ((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) * PaidMonths)), 2)), FormatNumber(((((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) - (dTotalPayment.Value - ((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) * PaidMonths))) * Penalty_Percent * NegativeNotAllowed(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) - If((dUpdated_Arrears.Value >= dBalance_Arrears.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) < BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))))) Or Availed, If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0))) / 30), 2))
                                Else
                                    DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"), DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value), If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0) And dBalance_Arrears.Value >= dUpdated_Arrears.Value, FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - If(dUpdated_Arrears.Value >= dBalance_Arrears.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), dRPPD.Value, 0)) - NegativeNotAllowed(dTotalPayment.Value - (GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False) * PaidMonths)), 2), FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - If(dUpdated_Arrears.Value >= dBalance_Arrears.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) < BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), dRPPD.Value, 0)) - NegativeNotAllowed(dTotalPayment.Value - (GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False) * PaidMonths)), 2)), FormatNumber((((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False) - NegativeNotAllowed(dTotalPayment.Value - (GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False) * PaidMonths))) * Penalty_Percent * NegativeNotAllowed(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) - If((dUpdated_Arrears.Value >= dBalance_Arrears.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) < BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))))) Or Availed, If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0))) / 30), 2))
                                End If
                            End If
                        Else
                            If DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) > BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))) Or dTotal_Penalty.Value > 0 Then
                                Availed = False
                            End If
                            'Pang Fix ni sya if First Due Date then na timing sa Holiday or Weekend so dapat ma availed pa gihapon sya.
                            ' If Availed = False And dTotalPayment.Value >= 0 And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= BankingDays(If(cbxAvailed.Checked, 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))) Then
                            If Availed = False And dTotalPayment.Value = 0 And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= BankingDays(If(cbxAvailed.Checked, 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))) Then
                                Availed = True
                            End If
                            If DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))) > dtpLastP.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) >= 0 And DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))) <= CDate(dtpAsOf.Value) And DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))) <= dtpMaturity.Value Then
                                If DateValue(If(IsDate(GridView3.GetRowCellValue(x + TermsPassed, "Due Date")), GridView3.GetRowCellValue(x + TermsPassed, "Due Date"), dtpAsOf.Value.AddDays(1))) >= dtpMaturity.Value And drv("Last_Principal") = "Yes" And dtpAsOf.Value >= dtpMaturity.Value Then 'CAR DEALER
                                    DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"), DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value), If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) < If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), FormatNumber((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), True)), 2), FormatNumber(GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False), 2)), FormatNumber((((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False)) * Penalty_Percent * NegativeNotAllowed(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) - If((dUpdated_Arrears.Value >= dBalance_Arrears.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) < BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))))) Or Availed, If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0))) / 30), 2)) 'AvailedPenalty - AvailedPenalty para i zero ra naku ang Availed Penalty kay dli diay dapat sya availed penalty nya gi tapol naku mag adjust basig naa matandog.
                                Else
                                    DT.Rows.Add(Format(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), "MM/dd/yyyy"), DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value), If(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0) And dBalance_Arrears.Value >= dUpdated_Arrears.Value, FormatNumber(GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), True), 2), FormatNumber(GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False), 2)), FormatNumber(((GetMonthlyBaseOnDate(DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), False) * Penalty_Percent * NegativeNotAllowed(DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) - If((dUpdated_Arrears.Value >= dBalance_Arrears.Value And DateDiff(DateInterval.Day, DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))), dtpAsOf.Value) <= BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1))))) Or Availed, If(Availed, BankingDays(If(cbxAvailed.Checked, AvailedPenalty + 0, 0), DateValue(If(IsDate(GridView3.GetRowCellValue(PaidMonths + x, "Due Date")), GridView3.GetRowCellValue(PaidMonths + x, "Due Date"), dtpAsOf.Value.AddDays(1)))), 0), 0))) / 30), 2)) 'AvailedPenalty - AvailedPenalty para i zero ra naku ang Availed Penalty kay dli diay dapat sya availed penalty nya gi tapol naku mag adjust basig naa matandog.
                                End If
                            End If
                        End If
                    Next
                End If
            End If
            GridControl1.DataSource = DT
            If GridView1.RowCount > 6 Then
                GridColumn4.Width = 159 - 18
            Else
                GridColumn4.Width = 159
            End If
            Dim TotalArrears As Double
            Dim TotalPenalty As Double
            For x As Integer = 0 To GridView1.RowCount - 1
                TotalArrears += CDbl(GridView1.GetRowCellValue(x, "Arrears"))
                TotalPenalty += CDbl(GridView1.GetRowCellValue(x, "Penalty"))
            Next
            dTotalArrears.Value = Math.Round(TotalArrears, 2, MidpointRounding.AwayFromZero) + dTotal_Arrears.Value
            dTotalPenalties.Value = Math.Round(TotalPenalty, 2, MidpointRounding.AwayFromZero) + dTotal_Penalty.Value
            CurrentlyOnComputePenalty = False
        Catch ex As Exception
            Cursor = Cursors.Default
            CurrentlyOnComputePenalty = False
        End Try
        Cursor = Cursors.Default
    End Sub
    '******************Formula

    Private Function GetMonthlyBaseOnDate(xDate As Date, Availed As Boolean)
        Dim Monthly As Double
        For x As Integer = 1 To GridView3.RowCount - 2
            If CDate(If(IsDate(GridView3.GetRowCellValue(x, "Due Date")), GridView3.GetRowCellValue(x, "Due Date"), Date.Now)) = xDate Then
                If Availed Then
                    Monthly = NegativeNotAllowed(CDbl(GridView3.GetRowCellValue(x, "Monthly")) - CDbl(GridView3.GetRowCellValue(x, "RPPD")))
                Else
                    Monthly = CDbl(GridView3.GetRowCellValue(x, "Monthly"))
                End If
                Exit For
            End If
        Next
        Return Monthly
    End Function

    Private Sub DTotal_Penalty_ValueChanged(sender As Object, e As EventArgs) Handles dTotal_Penalty.ValueChanged
        Dim TotalPenalty As Double
        For x As Integer = 0 To GridView1.RowCount - 1
            TotalPenalty += CDbl(GridView1.GetRowCellValue(x, "Penalty"))
        Next
        dTotalPenalties.Value = TotalPenalty + dTotal_Penalty.Value
    End Sub

    Private Sub CbxPrefix_B_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_B.Leave
        CbxPrefix_B.Text = ReplaceText(CbxPrefix_B.Text)
    End Sub

    Private Sub TxtFirstN_B_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_B.Leave
        TxtFirstN_B.Text = ReplaceText(TxtFirstN_B.Text)
    End Sub

    Private Sub TxtMiddleN_B_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_B.Leave
        TxtMiddleN_B.Text = ReplaceText(TxtMiddleN_B.Text)
    End Sub

    Private Sub TxtLastN_B_Leave(sender As Object, e As EventArgs) Handles TxtLastN_B.Leave
        TxtLastN_B.Text = ReplaceText(TxtLastN_B.Text)
    End Sub

    Private Sub CbxSuffix_B_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_B.Leave
        cbxSuffix_B.Text = ReplaceText(cbxSuffix_B.Text)
    End Sub

    Private Sub TxtBarangayC_B_Leave(sender As Object, e As EventArgs) Handles txtCompleteAdd.Leave
        txtCompleteAdd.Text = ReplaceText(txtCompleteAdd.Text)
    End Sub

    Private Sub TxtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        txtName.Text = ReplaceText(txtName.Text)
    End Sub

    Private Sub TxtMobile_Leave(sender As Object, e As EventArgs) Handles txtMobile.Leave
        txtMobile.Text = ReplaceText(txtMobile.Text)
    End Sub

    Private Sub TxtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        txtEmail.Text = ReplaceText(txtEmail.Text)
    End Sub

    Private Sub IAccount_2_Leave(sender As Object, e As EventArgs) Handles iAccount_2.Leave
        iAccount_2.Text = ReplaceText(iAccount_2.Text)
    End Sub

    Private Sub TxtCollateral_Leave(sender As Object, e As EventArgs) Handles txtCollateral.Leave
        txtCollateral.Text = ReplaceText(txtCollateral.Text)
    End Sub

    Private Sub TxtOthers_Leave(sender As Object, e As EventArgs) Handles cbxOthers.Leave
        cbxOthers.Text = ReplaceText(cbxOthers.Text)
    End Sub

    Private Sub DOthers_ValueChanged(sender As Object, e As EventArgs) Handles dOthers.ValueChanged
        dTotalAmountDue.Value = Decimal50((dBalance_Arrears.Value + NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)

        dOverdue.Value = Decimal50((NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + (dTotalArrears.Value - dDiscountRPPD.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)
    End Sub

    Private Sub CbxRebate_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRebate.CheckedChanged
        If cbxRebate.Checked Then
            dtpRebate.Enabled = True
            dRebate.Enabled = True

            If RebateDate = Nothing Then
            Else
                dtpRebate.Value = RebateDate
                dRebate.Value = RebateAmount
            End If
        Else
            RebateDate = dtpRebate.Value
            RebateAmount = dRebate.Value

            dtpRebate.Enabled = False
            dRebate.Enabled = False
            dRebate.Value = 0
        End If
    End Sub

    Private Sub DRebate_ValueChanged(sender As Object, e As EventArgs) Handles dRebate.ValueChanged
        dTotalAmountDue.Value = Decimal50((dBalance_Arrears.Value + NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)

        dOverdue.Value = Decimal50((NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + (dTotalArrears.Value - dDiscountRPPD.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)
    End Sub

    Private Sub CbxUpdated_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUpdated.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        ComputePenalties()
    End Sub

    Private Sub BtnPrintD_Click(sender As Object, e As EventArgs) Handles btnPrintD.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptSOADetailed
        With Report
            If CompanyMode = 0 Then
                .lblRebate.Visible = False
                .lblRebateA.Visible = False
                .lblRebate_2.Visible = False
                .lblRebateA_2.Visible = False
            End If
            .Name = "Statement of Account of " & txtName.Text
            Dim Unpaid_Penalties As String = "Unpaid Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(dtpAsOf.Value, "MM.dd.yy") & ") :"
            Dim Penalties As String = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(dtpAsOf.Value, "MM.dd.yy") & ") :"
            If GridView1.RowCount > 1 Then
                Penalties = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(DateValue(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Monthly Due Date")), "MM.dd.yy") & ") :"
            ElseIf GridView1.RowCount = 1 Then
                Penalties = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(DateValue(GridView1.GetRowCellValue(0, "Monthly Due Date")), "MM.dd.yy") & ") :"
            ElseIf GridView1.RowCount = 0 Then
                Penalties = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & ") :"
            End If
            '***PAGE I
            .lblAddress.Text = Branch_Address
            .lblContact.Text = Branch_Contact
            .lblName.Text = txtName.Text
            .lblAccountNumber.Text = txtAccount.Text & "-" & iAccount_2.Text
            .lblCollateral.Text = txtCollateral.Text
            .lblPrincipal.Text = dPrincipal.Text
            .lblFaceAmount.Text = dFaceAmount.Text
            .lblTotalPayments.Text = dTotalPayment.Text
            .lblDueDate.Text = iDue.Text
            .lblMonthlyA.Text = dMonthlyAmort.Text
            .lblDateAvailed.Text = Format(dtpAvailed.Value, "MMMM dd, yyyy")
            .lblLastP.Text = Format(dtpLastP.Value, "MMMM dd, yyyy")
            .lblMaturityD.Text = Format(dtpMaturity.Value, "MMMM dd, yyyy")
            .lblMonthsMD.Text = iMonthsMD.Text
            .lblAsOf.Text = Format(dtpAsOf.Value, "MMMM dd, yyyy")
            .lblBalance.Text = dBalance_Arrears.Text
            .lblBalanceP.Text = dBalance_Penalty.Text
            .lblUpdatedA.Text = dUpdated_Arrears.Text
            .lblUpdatedP.Text = dUpdated_Penalty.Text
            .lblDaysDelayed.Text = iDaysD.Text
            .lblHangingA.Text = dTotal_Arrears.Text
            .lblHangingP.Text = dTotal_Penalty.Text

            Dim SubRpt As New SubRptSOA With {
                .DataSource = GridControl1.DataSource
            }
            .subRpt_SOA.ReportSource = SubRpt
            With SubRpt
                .lblMonths.DataBindings.Add("Text", GridControl1.DataSource, "Monthly Due Date")
                .lblDays.DataBindings.Add("Text", GridControl1.DataSource, "Days Delayed")
                .lblArrears.DataBindings.Add("Text", GridControl1.DataSource, "Arrears")
                .lblPenalty.DataBindings.Add("Text", GridControl1.DataSource, "Penalty")
            End With
            .lblArrears.Text = dTotalArrears.Text
            .lblPenalties.Text = dTotal_Penalty.Text
            If cbxIncludePrint.Checked Then
                .lblDiscount.Text = " [" & dDiscountP.Text & "%] " & dDiscount.Text
            Else
                .lblDiscount.Visible = False
                .lblDiscount_3.Visible = False
            End If
            .lblUnpaidPenalties.Text = dUnpaidPenalties.Text
            .lblPenalties.Text = dTotalPenalties.Text
            .lblOthers.Text = If(cbxOthers.Text = "", "", "[" & cbxOthers.Text & "]")
            .lblOthersAmount.Text = dOthers.Text
            If cbxRebate.Checked Then
                .lblRebate.Visible = True
                .lblRebateD.Visible = True
                .lblRebateA.Visible = True

                .lblRebateD.Text = "[" & Format(dtpRebate.Value, "MM.dd.yy") & "]"
                .lblRebateA.Text = If(UDI_Amount > 0, dRebate.Text & " [" & UDI_Amount & "%]", dRebate.Text)
            End If
            .lblOverdue.Text = dOverdue.Text
            .lblTotal.Text = dTotalAmountDue.Text
            .lblPrepared.Text = Empl_Name
            .lblNoted.Text = Branch_BM.ToUpper
            .lblReceived.Text = txtName.Text.ToUpper

            '***PAGE 2
            .lblAddress_2.Text = Branch_Address
            .lblContact_2.Text = Branch_Contact
            .lblAsOf_2.Text = Format(dtpAsOf.Value, "MMMM dd, yyyy")
            .lblName_2.Text = txtName.Text
            .lblAccountNumber_2.Text = txtAccount.Text & "-" & iAccount_2.Text
            .lblCollateral_2.Text = txtCollateral.Text
            .lblPrincipal_2.Text = dFaceAmount.Text
            .lblMonthlyA_2.Text = dMonthlyAmort.Text
            .lblDateAvailed_2.Text = Format(dtpAvailed.Value, "MMMM dd, yyyy")
            .lblLastP_2.Text = Format(dtpLastP.Value, "MMMM dd, yyyy")
            .lblBalance_2.Text = dBalance_Arrears.Text
            If cbxIncludePrint.Checked Then
                .lblDiscount_2.Text = " [" & dDiscountP.Text & "%] " & dDiscount.Text
            Else
                .lblDiscount_2.Visible = False
                .lblDiscount_4.Visible = False
            End If
            .lblUnpaidDate_2.Text = Unpaid_Penalties
            .lblUnpaidPenalties_2.Text = dUnpaidPenalties.Text
            .lblPenaltyDates_2.Text = Penalties
            .lblPenalties_2.Text = dTotalPenalties.Text
            If DT_Others.Rows.Count <= 1 Then
                .lblOthers_2.Text = "Others" & If(cbxOthers.Text = "", " :", " [" & cbxOthers.Text & "] :")
                .lblOthersAmount_2.Text = dOthers.Text
            Else
                .lblOthers_2.Text = "Others" & If(DT_Others(0)("Others") = "", " :", " [" & DT_Others(0)("Others") & "] :")
                .lblOthersAmount_2.Text = FormatNumber(DT_Others(0)("Amount"), 2)
                For x As Integer = 0 To DT_Others.Rows.Count - 1
                    If x > 0 Then
                        Dim lbl_2 As New XRLabel
                        With lbl_2
                            .Text = "Others" & If(DT_Others(x)("Others") = "", " :", " [" & DT_Others(x)("Others") & "] :")
                            .LocationF = New Point(532, 425 + (25 * x))
                            .Font = New Font(OfficialFont, 11.25)
                            .ForeColor = Report.lblOthers_2.ForeColor
                            .SizeF = New Size(348, 25)
                        End With
                        .Detail.Controls.Add(lbl_2)
                        Dim lblAmount_2 As New XRLabel
                        With lblAmount_2
                            .Text = FormatNumber(DT_Others(x)("Amount"), 2)
                            .LocationF = New Point(880, 425 + (25 * x))
                            .Font = New Font(OfficialFont, 11.25)
                            .ForeColor = Report.lblOthers_2.ForeColor
                            .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                            .Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                            .BorderColor = Report.lblOthers_2.BorderColor
                            .SizeF = New Size(170, 25)
                        End With
                        .Detail.Controls.Add(lblAmount_2)
                    End If
                Next
                'First 3 rows
                .lblRebate_2.LocationF = New Point(530, 450 + (25 * (DT_Others.Rows.Count - 1)))
                .lblRebateA_2.LocationF = New Point(880, 450 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel3.LocationF = New Point(530, 475 + (25 * (DT_Others.Rows.Count - 1)))
                .lblOverdue_2.LocationF = New Point(880, 475 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel42.LocationF = New Point(530, 500 + (25 * (DT_Others.Rows.Count - 1)))
                .lblTotal_2.LocationF = New Point(880, 500 + (25 * (DT_Others.Rows.Count - 1)))
                'Signatories
                .XrLabel44.LocationF = New Point(530, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel11.LocationF = New Point(660, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel45.LocationF = New Point(790, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel46.LocationF = New Point(920, 530 + (25 * (DT_Others.Rows.Count - 1)))
                .lblPrepared_2.LocationF = New Point(530, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .lblChecked_2.LocationF = New Point(660, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .lblNoted_2.LocationF = New Point(790, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .lblReceived_2.LocationF = New Point(920, 555 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel50.LocationF = New Point(530, 635 + (25 * (DT_Others.Rows.Count - 1)))
                .XrLabel51.LocationF = New Point(530, 660 + (25 * (DT_Others.Rows.Count - 1)))
                If (DT_Others.Rows.Count - 1) = 5 Then
                    .XrLabel50.Font = New Font(OfficialFont, 8, FontStyle.Italic)
                    .XrLabel50.SizeF = New Size(170, 15)
                    .XrLabel50.SizeF = New Size(520, 15)
                    .XrLabel51.Font = New Font(OfficialFont, 8, FontStyle.Italic)
                    .XrLabel51.SizeF = New Size(170, 15)
                    .XrLabel51.SizeF = New Size(520, 15)
                    .XrLabel51.LocationF = New Point(530, 650 + (25 * (DT_Others.Rows.Count - 1)))
                End If
            End If
            If cbxRebate.Checked Then
                .lblRebate_2.Visible = True
                .lblRebateA_2.Visible = True

                .lblRebate_2.Text = "Rebate as of " & Format(dtpRebate.Value, "MM.dd.yy")
                .lblRebateA_2.Text = If(UDI_Amount > 0, dRebate.Text & " [" & UDI_Amount & "%]", dRebate.Text)
            End If
            .lblOverdue_2.Text = dOverdue.Text
            .lblTotal_2.Text = dTotalAmountDue.Text
            .lblPrepared_2.Text = Empl_Name
            .lblNoted_2.Text = Branch_BM.ToUpper
            .lblReceived_2.Text = txtName.Text.ToUpper
            Logs("Statement of Account", "Print Detailed", String.Format("Print SOA Name: {0}, Account Number: {1}, Total Loan Amount: {3}, Monthly Amortization: {4}, Date Availed: {5}, Last Payment Date: {6}, Balance Per Ledger: {7}", txtName.Text, txtAccount.Text & "-" & iAccount_2.Text, txtCollateral.Text, dPrincipal.Text, dMonthlyAmort.Text, Format(dtpAvailed.Value, "MMMM dd, yyyy"), Format(dtpLastP.Value, "MMMM dd, yyyy"), dBalance_Arrears.Text, dUnpaidPenalties.Text, dTotalPenalties.Text, If(cbxOthers.Text = "", " :", " [" & cbxOthers.Text & "] :"), dOthers.Text, dTotalAmountDue.Text, Empl_Name, Branch_BM, txtName.Text), "", "", "", "")
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub IAccount_TextChanged(sender As Object, e As EventArgs) Handles iAccount_2.TextChanged
        If FirstLoad Then
            Exit Sub
        End If
        If From_Payment Then
            Exit Sub
        End If

        Dim SQL As String = " SELECT"
        SQL &= "  ID, `Name`, MobileN, EmailAdd, "
        SQL &= "  Prefix, FirstN, MiddleN, LastN, Suffix, Address, "
        SQL &= "  Account,"
        SQL &= "  Collateral,"
        SQL &= "  Principal,"
        SQL &= "  FaceAmount,"
        SQL &= "  Due,"
        SQL &= "  MonthlyAmort,"
        SQL &= "  RPPD,"
        SQL &= "  Availed,"
        SQL &= "  LastP,"
        SQL &= "  Maturity,"
        SQL &= "  AsOf,"
        SQL &= "  Balance_Arrears,"
        SQL &= "  DiscountPenalty,"
        SQL &= "  UnpaidPenalty,"
        SQL &= "  Others,"
        SQL &= "  OthersType,"
        SQL &= "  OthersAmount,"
        SQL &= "  Rebate,"
        SQL &= "  RebateDate,"
        SQL &= "  UDI_Percent,"
        SQL &= "  RebateAmount"
        SQL &= String.Format("  FROM soa_setup WHERE branch_id = '{0}' AND AccountNumber = '{1}' AND `status` = 'ACTIVE';", Branch_ID, ReplaceText(iAccount_2.Text))
        Dim DT As DataTable = DataSource(SQL)

        If DT.Rows.Count > 0 Then
            ID = DT(0)("ID")
            CbxPrefix_B.Text = DT(0)("Prefix")
            TxtFirstN_B.Text = DT(0)("FirstN")
            TxtMiddleN_B.Text = DT(0)("MiddleN")
            TxtLastN_B.Text = DT(0)("LastN")
            cbxSuffix_B.Text = DT(0)("Suffix")
            txtCompleteAdd.Text = DT(0)("Address")
            txtCompleteAdd.Tag = DT(0)("Address")
            txtName.Text = DT(0)("Name")
            txtName.Tag = DT(0)("Name")
            txtMobile.Text = DT(0)("MobileN")
            txtMobile.Tag = DT(0)("MobileN")
            txtEmail.Text = DT(0)("EmailAdd")
            txtEmail.Tag = DT(0)("EmailAdd")
            txtAccount.Text = DT(0)("Account")
            txtAccount.Tag = DT(0)("Account")
            If DT(0)("Account") = "VL" Then
                cbxVL.Checked = True
            ElseIf DT(0)("Account") = "RE" Then
                cbxRE.Checked = True
            ElseIf DT(0)("Account") = "SL" Then
                cbxSL.Checked = True
            ElseIf DT(0)("Account") = "PDL" Then
                cbxPDL.Checked = True
            ElseIf DT(0)("Account") = "SML" Then
                cbxSML.Checked = True
            ElseIf DT(0)("Account") = "CRD" Then
                cbxCRD.Checked = True
            End If
            txtCollateral.Text = DT(0)("Collateral")
            txtCollateral.Tag = DT(0)("Collateral")
            dPrincipal.Value = DT(0)("Principal")
            dPrincipal.Tag = DT(0)("Principal")
            dFaceAmount.Value = DT(0)("FaceAmount")
            dFaceAmount.Tag = DT(0)("FaceAmount")
            iDue.Value = DT(0)("Due")
            iDue.Tag = DT(0)("Due")
            dMonthlyAmort.Value = DT(0)("MonthlyAmort")
            dMonthlyAmort.Tag = DT(0)("MonthlyAmort")
            dRPPD.Value = DT(0)("RPPD")
            dRPPD.Tag = DT(0)("RPPD")
            dtpAvailed.Value = DT(0)("Availed")
            dtpAvailed.Tag = DT(0)("Availed")
            dtpLastP.Value = DT(0)("LastP")
            dtpLastP.Tag = DT(0)("LastP")
            dtpMaturity.Value = DT(0)("Maturity")
            dtpMaturity.Tag = DT(0)("Maturity")
            dBalance_Arrears.Value = DT(0)("Balance_Arrears")
            dBalance_Arrears.Tag = DT(0)("Balance_Arrears")
            If DT(0)("AsOf") = "" Then
                dtpAsOf.Value = CDate(Format(Date.Now, "yyyy-MM-dd 00:00:00"))
                dtpAsOf.Tag = CDate(Format(Date.Now, "yyyy-MM-dd 00:00:00"))
            Else
                dtpAsOf.Value = DT(0)("AsOf")
                dtpAsOf.Tag = DT(0)("AsOf")
            End If
            dDiscount.Value = DT(0)("DiscountPenalty")
            dDiscount.Tag = DT(0)("DiscountPenalty")
            DDiscount_Leave(sender, e)
            dUnpaidPenalties.Value = DT(0)("UnpaidPenalty")
            dUnpaidPenalties.Tag = DT(0)("UnpaidPenalty")
            If DT(0)("OthersType") = "A" Then
                cbxAdd.Checked = True
            Else
                cbxDeduct.Checked = True
            End If
            cbxOthers.Text = DT(0)("Others")
            cbxOthers.Tag = DT(0)("Others")
            dOthers.Value = DT(0)("OthersAmount")
            dOthers.Tag = DT(0)("OthersAmount")
            cbxRebate.Tag = DT(0)("Rebate")
            If DT(0)("Rebate") = True Then
                cbxRebate.Checked = True
                dtpRebate.Value = DT(0)("RebateDate")
                dtpRebate.Tag = DT(0)("RebateDate")
                dRebate.Value = DT(0)("RebateAmount")
                dRebate.Tag = DT(0)("RebateAmount")
                UDI_Amount = DT(0)("UDI_Percent")
            Else
                cbxRebate.Checked = False
                dtpRebate.Value = Date.Now
                dtpRebate.Tag = ""
                dRebate.Value = 0
                dRebate.Tag = 0
                UDI_Amount = 0
            End If
            DT_Others = DataSource(String.Format("SELECT Others, `Type`, Amount FROM soa_details WHERE MainID = '{0}' AND `status` = 'ACTIVE';", ID))

            btnSave.Text = "Update"
        ElseIf btnSave.Text <> "&Save" Then
            ID = ""
            CbxPrefix_B.Text = ""
            TxtFirstN_B.Text = ""
            TxtMiddleN_B.Text = ""
            TxtLastN_B.Text = ""
            cbxSuffix_B.Text = ""
            txtCompleteAdd.Text = ""
            txtCompleteAdd.Tag = ""
            txtName.Text = ""
            txtName.Tag = ""
            txtMobile.Text = ""
            txtMobile.Tag = ""
            txtEmail.Text = ""
            txtEmail.Tag = ""
            txtAccount.Tag = ""
            txtCollateral.Text = ""
            txtCollateral.Tag = ""
            dPrincipal.Value = 0
            dPrincipal.Tag = 0
            dFaceAmount.Value = 0
            dFaceAmount.Tag = 0
            iDue.Value = 0
            iDue.Tag = 0
            dMonthlyAmort.Value = 0
            dMonthlyAmort.Tag = 0
            dRPPD.Value = 0
            dRPPD.Tag = 0
            dBalance_Arrears.Value = 0
            dBalance_Arrears.Tag = 0
            dtpAvailed.Value = Date.Now
            dtpAvailed.Tag = ""
            dtpLastP.Value = Date.Now
            dtpLastP.Tag = ""
            dtpMaturity.Value = Date.Now
            dtpMaturity.Tag = ""
            dtpAsOf.Value = Date.Now
            GridControl1.DataSource = Nothing
            dDiscountRPPD.Value = 0
            dDiscount.Value = 0
            dDiscount.Tag = 0
            dUnpaidPenalties.Value = 0
            dUnpaidPenalties.Tag = 0
            cbxOthers.Text = ""
            cbxOthers.Tag = ""
            dOthers.Value = 0
            dOthers.Tag = 0
            cbxRebate.Checked = False
            dtpRebate.Value = Date.Now
            dtpRebate.Tag = ""
            dRebate.Value = 0
            dRebate.Tag = 0
            dTotalArrears.Value = 0
            dTotalPenalties.Value = 0
            UDI_Amount = 0
            DT_Others = DataSource(String.Format("SELECT '' AS 'Others', 0 AS 'Type', 0 AS 'Amount' LIMIT 0;", ID))

            btnSave.Text = "&Save"
        End If
    End Sub

    Private Sub DDiscount_ValueChanged(sender As Object, e As EventArgs) Handles dDiscount.ValueChanged
        dOverdue.Value = Decimal50((NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + (dTotalArrears.Value - dDiscountRPPD.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)

        dNetDiscount.Value = dTotalPenalties.Value - dDiscount.Value
    End Sub

    Private Sub DDiscountP_ValueChanged(sender As Object, e As EventArgs) Handles dDiscountP.ValueChanged
        If Trigger_D Then
            dDiscount.Value = dTotalPenalties.Value * (dDiscountP.Value / 100)
        End If
    End Sub

    Private Sub DDiscount_Leave(sender As Object, e As EventArgs) Handles dDiscount.Leave
        Trigger_D = False
        dDiscountP.Value = (dDiscount.Value / dTotalPenalties.Value) * 100
        Trigger_D = True
    End Sub

    Private Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        If txtEmail.Text = "" Or txtEmail.Text.Contains("@") = False Then
            MsgBox("Please fill a correct email address to proceed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to send an email?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim Subject As String = String.Format("Statement of Account of {0} for {1}", txtName.Text, dtpAsOf.Text)
            'Statement of Account
            Dim Report As New RptSOA
            With Report
                If CompanyMode = 0 Then
                    .lblRebate.Visible = False
                    .lblRebateA.Visible = False
                    .lblRebate_2.Visible = False
                    .lblRebateA_2.Visible = False
                End If
                .Name = "Statement of Account of " & txtName.Text
                Dim Unpaid_Penalties As String = "Unpaid Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(dtpAsOf.Value, "MM.dd.yy") & ") :"
                Dim Penalties As String = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(dtpAsOf.Value, "MM.dd.yy") & ") :"
                If GridView1.RowCount > 1 Then
                    Penalties = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(DateValue(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Monthly Due Date")), "MM.dd.yy") & ") :"
                ElseIf GridView1.RowCount = 1 Then
                    Penalties = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & "-" & Format(DateValue(GridView1.GetRowCellValue(0, "Monthly Due Date")), "MM.dd.yy") & ") :"
                ElseIf GridView1.RowCount = 0 Then
                    Penalties = "Penalties (" & Penalty_Percent * 100 & "% " & Format(dtpLastP.Value, "MM.dd.yy") & ") :"
                End If
                '***PAGE I
                .lblAddress.Text = Branch_Address
                .lblContact.Text = Branch_Contact
                .lblAsOf.Text = Format(dtpAsOf.Value, "MMMM dd, yyyy")
                .lblName.Text = txtName.Text
                .lblAccountNumber.Text = txtAccount.Text & "-" & iAccount_2.Text
                .lblCollateral.Text = txtCollateral.Text
                .lblPrincipal.Text = dFaceAmount.Text
                .lblMonthlyA.Text = dMonthlyAmort.Text
                .lblDateAvailed.Text = Format(dtpAvailed.Value, "MMMM dd, yyyy")
                .lblLastP.Text = Format(dtpLastP.Value, "MMMM dd, yyyy")
                .lblBalance.Text = dBalance_Arrears.Text
                If cbxIncludePrint.Checked Then
                    .lblDiscount.Text = " [" & dDiscountP.Text & "%] " & dDiscount.Text
                Else
                    .lblDiscount.Visible = False
                    .lblDiscount_3.Visible = False
                End If
                .lblUnpaidDate.Text = Unpaid_Penalties
                .lblUnpaidPenalties.Text = dUnpaidPenalties.Text
                .lblPenaltyDates.Text = Penalties
                .lblPenalties.Text = dTotalPenalties.Text
                If DT_Others.Rows.Count <= 1 Then
                    .lblOthers.Text = "Others" & If(cbxOthers.Text = "", " :", " [" & cbxOthers.Text & "] :")
                    .lblOthersAmount.Text = dOthers.Text

                    .lblOthers_2.Text = "Others" & If(cbxOthers.Text = "", " :", " [" & cbxOthers.Text & "] :")
                    .lblOthersAmount_2.Text = dOthers.Text
                Else
                    .lblOthers.Text = "Others" & If(DT_Others(0)("Others") = "", " :", " [" & DT_Others(0)("Others") & "] :")
                    .lblOthersAmount.Text = FormatNumber(DT_Others(0)("Amount"), 2)

                    .lblOthers_2.Text = "Others" & If(DT_Others(0)("Others") = "", " :", " [" & DT_Others(0)("Others") & "] :")
                    .lblOthersAmount_2.Text = FormatNumber(DT_Others(0)("Amount"), 2)
                    For x As Integer = 0 To DT_Others.Rows.Count - 1
                        If x > 0 Then
                            Dim lbl As New XRLabel
                            With lbl
                                .Text = "Others" & If(DT_Others(x)("Others") = "", " :", " [" & DT_Others(x)("Others") & "] :")
                                .LocationF = New Point(2, 425 + (25 * x))
                                .Font = New Font("Century Gothic", 11.25)
                                .ForeColor = Report.lblOthers_2.ForeColor
                                .SizeF = New Size(350, 25)
                            End With
                            .Detail.Controls.Add(lbl)
                            Dim lblAmount As New XRLabel
                            With lblAmount
                                .Text = FormatNumber(DT_Others(x)("Amount"), 2)
                                .LocationF = New Point(350, 425 + (25 * x))
                                .Font = New Font("Century Gothic", 11.25)
                                .ForeColor = Report.lblOthers_2.ForeColor
                                .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                                .Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                                .BorderColor = Report.lblOthers_2.BorderColor
                                .SizeF = New Size(170, 25)
                            End With
                            .Detail.Controls.Add(lblAmount)

                            Dim lbl_2 As New XRLabel
                            With lbl_2
                                .Text = "Others" & If(DT_Others(x)("Others") = "", " :", " [" & DT_Others(x)("Others") & "] :")
                                .LocationF = New Point(532, 425 + (25 * x))
                                .Font = New Font("Century Gothic", 11.25)
                                .ForeColor = Report.lblOthers_2.ForeColor
                                .SizeF = New Size(348, 25)
                            End With
                            .Detail.Controls.Add(lbl_2)
                            Dim lblAmount_2 As New XRLabel
                            With lblAmount_2
                                .Text = FormatNumber(DT_Others(x)("Amount"), 2)
                                .LocationF = New Point(880, 425 + (25 * x))
                                .Font = New Font("Century Gothic", 11.25)
                                .ForeColor = Report.lblOthers_2.ForeColor
                                .TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight
                                .Borders = DevExpress.XtraPrinting.BorderSide.Bottom
                                .BorderColor = Report.lblOthers_2.BorderColor
                                .SizeF = New Size(170, 25)
                            End With
                            .Detail.Controls.Add(lblAmount_2)
                        End If
                    Next
                    'First 3 rows
                    .lblRebate.LocationF = New Point(0, 450 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblRebateA.LocationF = New Point(350, 450 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel1.LocationF = New Point(0, 475 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblOverdue.LocationF = New Point(350, 475 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel25.LocationF = New Point(0, 500 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblTotal.LocationF = New Point(350, 500 + (25 * (DT_Others.Rows.Count - 1)))

                    .lblRebate_2.LocationF = New Point(530, 450 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblRebateA_2.LocationF = New Point(880, 450 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel3.LocationF = New Point(530, 475 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblOverdue_2.LocationF = New Point(880, 475 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel42.LocationF = New Point(530, 500 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblTotal_2.LocationF = New Point(880, 500 + (25 * (DT_Others.Rows.Count - 1)))
                    'Signatories
                    .XrLabel27.LocationF = New Point(0, 530 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel18.LocationF = New Point(130, 530 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel29.LocationF = New Point(260, 530 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel31.LocationF = New Point(390, 530 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblPrepared.LocationF = New Point(0, 555 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblChecked.LocationF = New Point(130, 555 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblNoted.LocationF = New Point(260, 555 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblReceived.LocationF = New Point(390, 555 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel33.LocationF = New Point(0, 635 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel34.LocationF = New Point(0, 660 + (25 * (DT_Others.Rows.Count - 1)))
                    If (DT_Others.Rows.Count - 1) = 5 Then
                        .XrLabel33.Font = New Font("Century Gothic", 8, FontStyle.Italic)
                        .XrLabel33.SizeF = New Size(170, 15)
                        .XrLabel33.SizeF = New Size(520, 15)
                        .XrLabel34.Font = New Font("Century Gothic", 8, FontStyle.Italic)
                        .XrLabel34.SizeF = New Size(170, 15)
                        .XrLabel34.SizeF = New Size(520, 15)
                        .XrLabel34.LocationF = New Point(0, 650 + (25 * (DT_Others.Rows.Count - 1)))
                    End If

                    .XrLabel44.LocationF = New Point(530, 530 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel14.LocationF = New Point(660, 530 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel45.LocationF = New Point(790, 530 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel46.LocationF = New Point(920, 530 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblPrepared_2.LocationF = New Point(530, 555 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblChecked_2.LocationF = New Point(660, 555 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblNoted_2.LocationF = New Point(790, 555 + (25 * (DT_Others.Rows.Count - 1)))
                    .lblReceived_2.LocationF = New Point(920, 555 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel50.LocationF = New Point(530, 635 + (25 * (DT_Others.Rows.Count - 1)))
                    .XrLabel51.LocationF = New Point(530, 660 + (25 * (DT_Others.Rows.Count - 1)))
                    If (DT_Others.Rows.Count - 1) = 5 Then
                        .XrLabel50.Font = New Font("Century Gothic", 8, FontStyle.Italic)
                        .XrLabel50.SizeF = New Size(170, 15)
                        .XrLabel50.SizeF = New Size(520, 15)
                        .XrLabel51.Font = New Font("Century Gothic", 8, FontStyle.Italic)
                        .XrLabel51.SizeF = New Size(170, 15)
                        .XrLabel51.SizeF = New Size(520, 15)
                        .XrLabel51.LocationF = New Point(530, 650 + (25 * (DT_Others.Rows.Count - 1)))
                    End If
                End If

                If cbxRebate.Checked Then
                    .lblRebate.Visible = True
                    .lblRebateA.Visible = True

                    .lblRebate.Text = "Rebate as of " & Format(dtpRebate.Value, "MM.dd.yy")
                    .lblRebateA.Text = If(UDI_Amount > 0, dRebate.Text & " [" & UDI_Amount & "%]", dRebate.Text)
                End If
                .lblOverdue.Text = dOverdue.Text
                .lblTotal.Text = dTotalAmountDue.Text
                .lblPrepared.Text = Empl_Name
                .lblNoted.Text = Branch_BM.ToUpper
                .lblReceived.Text = txtName.Text.ToUpper

                '***PAGE 2
                .lblAddress_2.Text = Branch_Address
                .lblContact_2.Text = Branch_Contact
                .lblAsOf_2.Text = Format(dtpAsOf.Value, "MMMM dd, yyyy")
                .lblName_2.Text = txtName.Text
                .lblAccountNumber_2.Text = txtAccount.Text & "-" & iAccount_2.Text
                .lblCollateral_2.Text = txtCollateral.Text
                .lblPrincipal_2.Text = dFaceAmount.Text
                .lblMonthlyA_2.Text = dMonthlyAmort.Text
                .lblDateAvailed_2.Text = Format(dtpAvailed.Value, "MMMM dd, yyyy")
                .lblLastP_2.Text = Format(dtpLastP.Value, "MMMM dd, yyyy")
                .lblBalance_2.Text = dBalance_Arrears.Text
                If cbxIncludePrint.Checked Then
                    .lblDiscount_2.Text = " [" & dDiscountP.Text & "%] " & dDiscount.Text
                Else
                    .lblDiscount_2.Visible = False
                    .lblDiscount_4.Visible = False
                End If
                .lblUnpaidDate_2.Text = Unpaid_Penalties
                .lblUnpaidPenalties_2.Text = dUnpaidPenalties.Text
                .lblPenaltyDates_2.Text = Penalties
                .lblPenalties_2.Text = dTotalPenalties.Text
                If cbxRebate.Checked Then
                    .lblRebate_2.Visible = True
                    .lblRebateA_2.Visible = True

                    .lblRebate_2.Text = "Rebate as of " & Format(dtpRebate.Value, "MM.dd.yy")
                    .lblRebateA_2.Text = If(UDI_Amount > 0, dRebate.Text & " [" & UDI_Amount & "%]", dRebate.Text)
                End If
                .lblOverdue_2.Text = dOverdue.Text
                .lblTotal_2.Text = dTotalAmountDue.Text
                .lblPrepared_2.Text = Empl_Name
                .lblNoted_2.Text = Branch_BM.ToUpper
                .lblReceived_2.Text = txtName.Text.ToUpper
                Logs("Statement of Account", "Send Email", String.Format("Send Email SOA Name: {0}, Account Number: {1}, Total Loan Amount: {3}, Monthly Amortization: {4}, Date Availed: {5}, Last Payment Date: {6}, Balance Per Ledger: {7}", txtName.Text, txtAccount.Text & "-" & iAccount_2.Text, txtCollateral.Text, dPrincipal.Text, dMonthlyAmort.Text, Format(dtpAvailed.Value, "MMMM dd, yyyy"), Format(dtpLastP.Value, "MMMM dd, yyyy"), dBalance_Arrears.Text, dUnpaidPenalties.Text, dTotalPenalties.Text, If(cbxOthers.Text = "", " :", " [" & cbxOthers.Text & "] :"), dOthers.Text, dTotalAmountDue.Text, Empl_Name, Branch_BM, txtName.Text), "", "", "", "")
            End With
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\SoA-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
            Try
                Report.ExportToPdf(FName)
            Catch ex As Exception
            End Try

            Dim Body As String = String.Format("Mr/Mrs {0}," & vbCrLf, txtName.Text)
            Body &= String.Format("As of {0} your overdue at FIRST STANDARD is P{1}. Kindly settle this on or before the stated date." & vbCrLf, Format(dtpAsOf.Value, "MMMM dd, yyyy"), dOverdue.Text)
            Body &= "Thank you!"
            Dim arrayList As New ArrayList()
            AttachmentFiles = arrayList
            AttachmentFiles.Add(FName)
            SendEmail(txtEmail.Text, Subject, Body, False, True, False, 0, "", "")
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CbxAdd_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdd.CheckedChanged
        If cbxAdd.Checked Then
            cbxDeduct.Checked = False
            DOthers_ValueChanged(sender, e)
        End If

        If cbxAdd.Checked = False And cbxDeduct.Checked = False Then
            cbxAdd.Checked = True
        End If
    End Sub

    Private Sub CbxDeduct_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeduct.CheckedChanged
        If cbxDeduct.Checked Then
            cbxAdd.Checked = False
            DOthers_ValueChanged(sender, e)
        End If

        If cbxAdd.Checked = False And cbxDeduct.Checked = False Then
            cbxAdd.Checked = True
        End If
    End Sub

    Private Sub BtnSMS_Click(sender As Object, e As EventArgs) Handles btnSMS.Click
        If txtMobile.Text.Trim = "" Or txtMobile.Text.Trim.Length <> 10 Or IsNumeric(txtMobile.Text.Trim) = False Or If(txtMobile.Text.Length > 1, txtMobile.Text.Substring(0, 1) = 0, 0) Then
            MsgBox("Please fill a correct mobile number to proceed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to send this message?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim Msg As String = String.Format("Mr/Mrs {0}," & vbCrLf, txtName.Text)
            Msg &= String.Format("As of {0} your overdue at FIRST STANDARD is P{1}. Kindly settle this on or before the stated date." & vbCrLf, Format(dtpAsOf.Value, "MMMM dd, yyyy"), dOverdue.Text)
            Msg &= "Thank you!"

            SendSMS(txtMobile.Text, Msg, False)
            Cursor = Cursors.Default
            MsgBox("Your message will be send ASAP.", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub CbxPrefix_B_TextChanged(sender As Object, e As EventArgs) Handles CbxPrefix_B.TextChanged
        txtName.Text = If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & If(TxtMiddleN_B.Text.Trim.Contains("."), " ", ". ")) & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & cbxSuffix_B.Text.Trim
    End Sub

    Private Sub TxtFirstN_B_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_B.TextChanged
        txtName.Text = If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & If(TxtMiddleN_B.Text.Trim.Contains("."), " ", ". ")) & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & cbxSuffix_B.Text.Trim
    End Sub

    Private Sub TxtMiddleN_B_TextChanged(sender As Object, e As EventArgs) Handles TxtMiddleN_B.TextChanged
        txtName.Text = If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & If(TxtMiddleN_B.Text.Trim.Contains("."), " ", ". ")) & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & cbxSuffix_B.Text.Trim
    End Sub

    Private Sub TxtLastN_B_TextChanged(sender As Object, e As EventArgs) Handles TxtLastN_B.TextChanged
        txtName.Text = If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & If(TxtMiddleN_B.Text.Trim.Contains("."), " ", ". ")) & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & cbxSuffix_B.Text.Trim
    End Sub

    Private Sub CbxSuffix_B_TextChanged(sender As Object, e As EventArgs) Handles cbxSuffix_B.TextChanged
        txtName.Text = If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & If(TxtMiddleN_B.Text.Trim.Contains("."), " ", ". ")) & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & cbxSuffix_B.Text.Trim
    End Sub

    Private Sub BtnDemandL_Click(sender As Object, e As EventArgs) Handles btnDemandL.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim xPath As String = Application.StartupPath & "\Documents\First Demand Letter.doc"
        Dim PathName As String = IO.Path.GetFileName(xPath)
        Dim File_Directory As String = String.Format("{0}\{1}\{2}\Documents\{3}", RootFolder, MainFolder, Branch_Code, "Demand Letter")
        If Not IO.Directory.Exists(File_Directory) Then
            IO.Directory.CreateDirectory(File_Directory)
        End If
        Dim FileName As String = String.Format("{0}\{1}", File_Directory, PathName)
        Dim DL As New FrmDemandLetter
        If IO.File.Exists(FileName) Then
            DL.cbx2nd.Checked = True
        Else
            DL.cbx1st.Checked = True
        End If
        If DL.ShowDialog = DialogResult.OK Then
            If DL.cbx1st.Checked Then
                xPath = Application.StartupPath & "\Documents\First Demand Letter.doc"
            Else
                xPath = Application.StartupPath & "\Documents\Second Demand Letter.doc"
            End If

            FileName = (String.Format("{0}\{1}", File_Directory, PathName))
            For x As Integer = 2 To 1000
                If IO.File.Exists(FileName) Then
                    If DL.cbx1st.Checked Then
                        FileName = String.Format("{0}\First Demand Letter of {1} ({2}).doc", File_Directory, txtName.Text, x)
                    Else
                        FileName = String.Format("{0}\Second Demand Letter of {1} ({2}).doc", File_Directory, txtName.Text, x)
                    End If
                End If
            Next
            IO.File.Copy(xPath, FileName)

            Dim WordApp As New word.Application With {
                .Visible = False
            }
            Dim Doc As word.Document = WordApp.Documents.Open(FileName)
            Doc = WordApp.ActiveDocument
            With Doc
                'REPLACE
                .Content.Find.Execute(FindText:="@Date", ReplaceWith:=Format(Date.Now, "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Name", ReplaceWith:=UpperCaseFirst(txtName.Text), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Address", ReplaceWith:=txtCompleteAdd.Text, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@LName", ReplaceWith:=UpperCaseFirst(If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & TxtLastN_B.Text), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Product", ReplaceWith:=If(cbxVL.Checked, "Vehicle Loan", If(cbxRE.Checked, "Real Estate Loan", If(cbxSL.Checked, "Salary Loan", If(cbxPDL.Checked, "Pay Day Loan", If(cbxSML.Checked, "Show Money Loan", If(cbxCRD.Checked, "Check Rediscounting Loan", "")))))), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Collateral", ReplaceWith:=txtCollateral.Text, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@AccountNum", ReplaceWith:=txtAccount.Text & "-" & iAccount_2.Text, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Amount", ReplaceWith:=dOverdue.Text, Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@AsOf", ReplaceWith:=Format(dtpAsOf.Value, "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@User", ReplaceWith:=UpperCaseFirst(Empl_Name), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Position", ReplaceWith:=UpperCaseFirst(Empl_Position), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                .Content.Find.Execute(FindText:="@Branch", ReplaceWith:=UpperCaseFirst(Branch), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                If DL.cbx1st.Checked Then
                    .Content.Find.Execute(FindText:="@MaturedDate", ReplaceWith:=Format(dtpMaturity.Value, "MMMM dd, yyyy"), Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                Else
                    .Content.Find.Execute(FindText:="@NumPassDue", ReplaceWith:=ConvertNumberToWords(CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value), True, False).Replace("** ", "").Replace("ONLY **", "") & " (" & CompleteMonthsBetweenA(dtpMaturity.Value, dtpAsOf.Value) & ")", Replace:=word.WdReplace.wdReplaceAll, Wrap:=word.WdFindWrap.wdFindContinue)
                End If

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
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnOthers_Click(sender As Object, e As EventArgs) Handles btnOthers.Click
        Dim Others As New FrmSOAOthers
        With Others
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint

            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnCalculator_Click(sender As Object, e As EventArgs) Handles btnCalculator.Click
        If MsgBoxYes("Are you sure you want to view computation?") = MsgBoxResult.Yes Then
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

                Logs("SOA", "View Computation", "Amortization Calculators", "", "", "", cbxCreditApplication.SelectedValue)
                .lblTitle.Text = "AMORTIZATION CALCULATOR"
                .ControlBox = False
                .FormBorderStyle = FormBorderStyle.FixedDialog
                .WindowState = FormWindowState.Normal
                .From_CI = True
                .From_Request = True
                .From_SOA = True
                .CreditNumber = cbxCreditApplication.SelectedValue
                .btnOpen.Visible = True

                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnAddOthers_Click(sender As Object, e As EventArgs) Handles btnAddOthers.Click
        Dim Details As New FrmAddOthersSOA
        With Details
            If DT_Others.Rows.Count > 0 Then
                .O1 = DT_Others(0)("Others")
                If DT_Others(0)("Type") = True Then
                    .cbxAdd.Checked = True
                Else
                    .cbxDeduct.Checked = True
                End If
                .dOthers.Value = DT_Others(0)("Amount")

                If DT_Others.Rows.Count > 1 Then
                    .O2 = DT_Others(1)("Others")
                    If DT_Others(1)("Type") = True Then
                        .cbxAdd_2.Checked = True
                    Else
                        .cbxDeduct_2.Checked = True
                    End If
                    .dOthers_2.Value = DT_Others(1)("Amount")

                    If DT_Others.Rows.Count > 2 Then
                        .O3 = DT_Others(2)("Others")
                        If DT_Others(2)("Type") = True Then
                            .cbxAdd_3.Checked = True
                        Else
                            .cbxDeduct_3.Checked = True
                        End If
                        .dOthers_3.Value = DT_Others(2)("Amount")

                        If DT_Others.Rows.Count > 3 Then
                            .O4 = DT_Others(3)("Others")
                            If DT_Others(3)("Type") = True Then
                                .cbxAdd_4.Checked = True
                            Else
                                .cbxDeduct_4.Checked = True
                            End If
                            .dOthers_4.Value = DT_Others(3)("Amount")

                            If DT_Others.Rows.Count > 4 Then
                                .O5 = DT_Others(4)("Others")
                                If DT_Others(4)("Type") = True Then
                                    .cbxAdd_5.Checked = True
                                Else
                                    .cbxDeduct_5.Checked = True
                                End If
                                .dOthers_5.Value = DT_Others(4)("Amount")

                                If DT_Others.Rows.Count > 5 Then
                                    .O6 = DT_Others(5)("Others")
                                    If DT_Others(5)("Type") = True Then
                                        .cbxAdd_6.Checked = True
                                    Else
                                        .cbxDeduct_6.Checked = True
                                    End If
                                    .dOthers_6.Value = DT_Others(5)("Amount")
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If .ShowDialog = DialogResult.OK Then
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnList_Click(sender As Object, e As EventArgs) Handles btnList.Click
        Dim List As New FrmSOAList
        With List
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub TxtAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtAccount.SelectedIndexChanged
        If txtAccount.SelectedIndex = -1 Then
            Exit Sub
        End If

        If cbxCreditApplication.SelectedIndex = -1 And From_OR = False Then
            Dim drv As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
            lblProduct.Text = drv("Product").ToString
            If drv("Product").ToString.ToUpper.Contains("DEALER") Then
                dUpdated_Arrears.Value = iMonthsMD.Value * dMonthlyAmort.Value + dPrincipal.Value
            Else
                If drv("Payment").ToString.Contains("Bimonthly") Then
                    dUpdated_Arrears.Value = (iMonthsMD.Value * 2) * dMonthlyAmort.Value
                ElseIf drv("Payment").ToString.Contains("Weekly") Or drv("Payment").ToString.Contains("Daily") Then
                    dUpdated_Arrears.Value = GridView3.GetRowCellValue((GridView3.RowCount - 2) - iMonthsMD.Value, "Loans Receivable")
                Else
                    dUpdated_Arrears.Value = iMonthsMD.Value * dMonthlyAmort.Value
                End If
            End If
        Else
            Dim UpdatedSinceLastPayment As Double = dFaceAmount.Value
            For x As Integer = 1 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
                Else
                    If dtpLastP.Value >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                        UpdatedSinceLastPayment = CDbl(GridView3.GetRowCellValue(x, "Loans Receivable"))
                    End If
                End If
            Next
            dUpdated_Arrears.Value = UpdatedSinceLastPayment
            Dim drv As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
            lblProduct.Text = drv("Product").ToString
            If drv("Product").ToString.ToUpper.Contains("DEALER") Then
                LabelX8.Text = "<span align='right'><font color='red'>*</font>Monthly Interest :</span>"
            Else
                LabelX8.Text = "<span align='right'><font color='red'>*</font>Monthly Amort. :</span>"
                If drv("Payment").ToString.Contains("Bimonthly") Then
                    lblFDD.Visible = True
                    dtpFDD.Visible = True
                Else
                    lblFDD.Visible = False
                    dtpFDD.Visible = False
                End If
            End If
        End If
    End Sub

    Private Sub Timer_Date_Tick(sender As Object, e As EventArgs) Handles Timer_Date.Tick
        LoadCompanyMode()
    End Sub

    Private Sub LoadCompanyMode()
        If Prev_CompanyMode = CompanyMode Then
            Exit Sub
        Else
            Prev_CompanyMode = CompanyMode
        End If
        If CompanyMode = 0 Then
            LabelX15.Visible = False
            dRPPD.Visible = False

            cbxRebate.Visible = False
            dtpRebate.Visible = False
            dRebate.Visible = False

            dRPPD.Value = 0
            cbxRebate.Checked = False
        Else
            LabelX15.Visible = True
            dRPPD.Visible = True

            cbxRebate.Visible = True
            dtpRebate.Visible = True
            dRebate.Visible = True
        End If
    End Sub

    Private Sub CbxCreditApplication_TextChanged(sender As Object, e As EventArgs) Handles cbxCreditApplication.TextChanged
        If cbxCreditApplication.Text = "" Then
            ClearFields()
        End If
    End Sub

    Private Sub ClearFields()
        TxtFirstN_B.Size = New Point(105, 23)
        TxtFirstN_B.Location = New Point(203, 44)
        CbxPrefix_B.Visible = True
        TxtMiddleN_B.Visible = True
        TxtLastN_B.Visible = True
        cbxSuffix_B.Visible = True
        btnSave.Enabled = True

        CbxPrefix_B.Enabled = True
        TxtFirstN_B.Enabled = True
        TxtMiddleN_B.Enabled = True
        TxtLastN_B.Enabled = True
        cbxSuffix_B.Enabled = True
        txtCompleteAdd.Enabled = True
        txtMobile.Enabled = True
        txtEmail.Enabled = True
        txtAccount.Enabled = True
        iAccount_2.Enabled = True
        txtCollateral.Enabled = True
        dPrincipal.Enabled = True
        dFaceAmount.Enabled = True
        iDue.Enabled = True
        dMonthlyAmort.Enabled = True
        dRPPD.Enabled = True
        dtpAvailed.Enabled = True
        dtpFDD.Enabled = True
        dtpLastP.Enabled = True
        dtpMaturity.Enabled = True
        btnEarly.Visible = False
        btnDeductBalance.Visible = False
        dDiscountP.Enabled = True
        dDiscount.Enabled = True
        btnDeductions.Visible = False
    End Sub

    Public Sub CbxCreditApplication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCreditApplication.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        btnLedger.Enabled = False
        If cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "" Then
            btnDeductions.Visible = False
            TxtFirstN_B.Size = New Point(105, 23)
            TxtFirstN_B.Location = New Point(203, 44)
            CbxPrefix_B.Visible = True
            TxtMiddleN_B.Visible = True
            TxtLastN_B.Visible = True
            cbxSuffix_B.Visible = True

            CbxPrefix_B.Text = ""
            TxtFirstN_B.Text = ""
            TxtMiddleN_B.Text = ""
            TxtLastN_B.Text = ""
            cbxSuffix_B.Text = ""
            txtCompleteAdd.Text = ""
            txtMobile.Text = ""
            txtEmail.Text = ""
            iAccount_2.Text = ""
            txtCollateral.Text = ""
            dPrincipal.Value = 0
            dFaceAmount.Value = 0
            dTotalPayment.Value = 0
            dtpLastP.Value = Date.Now
            iDue.Value = 0
            dMonthlyAmort.Value = 0
            dRPPD.Value = 0
            dtpAvailed.Value = Date.Now
            dtpFDD.Value = Date.Now
            txtAccount.SelectedIndex = -1
            dtpMaturity.Value = Date.Now
            dBalance_Arrears.Value = 0
            btnSave.Enabled = True
            btnCalculator.Enabled = False

            Dim Temp_DT As New DataTable
            GridControl3.DataSource = Temp_DT
            GridView3.BestFitColumns()

            ClearFields()
        Else
            Dim drv As DataRowView = DirectCast(cbxCreditApplication.SelectedItem, DataRowView)
            If drv("BorrowerID").ToString.Contains("C") Then
                TxtFirstN_B.Size = New Point(329, 23)
                TxtFirstN_B.Location = New Point(147, 44)

                CbxPrefix_B.Visible = False
                TxtMiddleN_B.Visible = False
                TxtLastN_B.Visible = False
                cbxSuffix_B.Visible = False
            Else
                TxtFirstN_B.Size = New Point(105, 23)
                TxtFirstN_B.Location = New Point(203, 44)

                CbxPrefix_B.Visible = True
                TxtMiddleN_B.Visible = True
                TxtLastN_B.Visible = True
                cbxSuffix_B.Visible = True
            End If
            If drv("BillDeductions") Then
                btnDeductions.Visible = True
            Else
                btnDeductions.Visible = False
            End If
            btnSave.Enabled = False
            btnCalculator.Enabled = True
            CbxPrefix_B.Text = drv("Prefix_B").ToString
            TxtFirstN_B.Text = drv("FirstN_B")
            TxtMiddleN_B.Text = If(drv("MiddleN_B").ToString = "", "", drv("MiddleN_B").ToString.Substring(0, 1))
            TxtLastN_B.Text = drv("LastN_B").ToString
            cbxSuffix_B.Text = drv("Suffix_B").ToString
            txtCompleteAdd.Text = drv("Complete Address")
            txtMobile.Text = drv("Mobile_B")
            txtEmail.Text = drv("Email_B")
            iAccount_2.Text = drv("AccountNumber")
            txtCollateral.Text = drv("Collateral")
            txtAccount.SelectedValue = drv("product_ID")
            dPrincipal.Value = drv("AmountApplied")
            dFaceAmount.Value = drv("Face_Amount")
            Dim PaymentDT As DataTable
            PaymentDT = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total RPPD', IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Penalty Payment', IFNULL((SELECT PenaltyPayable FROM accounting_entry A WHERE A.PaidFor IN ('Penalty','Penalty-W') AND A.`status` = 'ACTIVE' AND A.ReferenceN = '{0}' AND A.JVNumber = '' ORDER BY ID DESC LIMIT 1),0) AS 'Total Unpaid Penalty', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('RPPD-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{2}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived RPPD', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('Penalty-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{2}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived Penalty', IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Principal', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Interest', IFNULL((SELECT MAX(IF(ARDate = '',IF(RemittanceDate = '',ORDate,RemittanceDate),ARDate)) FROM official_receipt WHERE Payee_ID = '{0}' AND IF({1} = 1,DTS = 0,TRUE) AND `status` = 'ACTIVE' AND JVNumber = ''),IFNULL(MAX((CASE WHEN JVNum = '' AND JVNumber = '' THEN ORDate END)),ReleasedDate('{0}'))) AS 'Last Payment' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", ValidateComboBox(cbxCreditApplication), From_JV_DTS, Format(dtpAsOf.Value, "yyyy-MM-dd")))
            If PaymentDT.Rows.Count > 0 Then
                TotalRPPD = PaymentDT(0)("Total RPPD")
                TotalInterest = PaymentDT(0)("Total Interest")
                TotalPayment = PaymentDT(0)("Total Principal")
                dUnpaidPenalties.Value = PaymentDT(0)("Total Unpaid Penalty")
                dDiscount.Value = PaymentDT(0)("Total Waived Penalty")
                dDiscountRPPD.Value = PaymentDT(0)("Total Waived RPPD")
                Trigger_D = False
                dDiscountP.Value = (dDiscount.Value / dTotalPenalties.Value) * 100
                Trigger_D = True
                dTotalPayment.Value = PaymentDT(0)("Total RPPD") + PaymentDT(0)("Total Interest") + PaymentDT(0)("Total Principal")
                If PaymentDT(0)("Last Payment") = "" Then
                Else
                    dtpLastP.Value = PaymentDT(0)("Last Payment")
                End If
            End If

            Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', IF(`No` = '','',FORMAT(InterestIncome,2)) AS 'Interest Income', IF(`No` = '','',FORMAT(RPPD,2)) AS 'RPPD', IF(`No` = '','',FORMAT(PrincipalAllocation,2)) AS 'Principal Allocation', FORMAT(OutstandingPrincipal,2) AS 'Outstanding Principal', FORMAT(Total_RPPD,2) AS 'Total_RPPD', FORMAT(UnearnIncome,2) AS 'Unearn Income', FORMAT(LoansReceivable,2) AS 'Loans Receivable', IF(`No` = '','',FORMAT(Penalty,2)) AS 'Penalty', FORMAT(PenaltyBalance,2) AS 'Penalty Balance' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", cbxCreditApplication.SelectedValue))
            Dim T_Monthly As Double
            Dim T_Interest As Double
            Dim T_RPPD As Double
            Dim T_Principal As Double
            Dim T_Penalty As Double
            For x As Integer = 1 To Temp_DT.Rows.Count - 1
                T_Monthly += CDbl(Temp_DT(x)("Monthly"))
                T_Interest += CDbl(Temp_DT(x)("Interest Income"))
                T_RPPD += CDbl(Temp_DT(x)("RPPD"))
                T_Principal += CDbl(Temp_DT(x)("Principal Allocation"))
                T_Penalty += CDbl(Temp_DT(x)("Penalty"))
            Next
            If T_Penalty > 0 Then
                cbxAvailed.Enabled = False
                cbxAvailed.Checked = False
                GridColumn16.VisibleIndex = 0
                GridColumn17.VisibleIndex = 1
                GridColumn18.VisibleIndex = 2
                GridColumn5.VisibleIndex = 3
                GridColumn19.VisibleIndex = 4
                GridColumn20.VisibleIndex = 5
                GridColumn21.VisibleIndex = 6
                GridColumn22.VisibleIndex = 7
                GridColumn23.VisibleIndex = 8
                GridColumn24.VisibleIndex = 9
                GridColumn6.VisibleIndex = 10
                GridColumn34.VisibleIndex = 11

                GridColumn16.Width = 25
                GridColumn17.Width = 58
                GridColumn18.Width = 54
                GridColumn5.Width = 52
                GridColumn19.Width = 54
                GridColumn20.Width = 52
                GridColumn21.Width = 57
                GridColumn22.Width = 57
                GridColumn23.Width = 54
                GridColumn24.Width = 52
                GridColumn6.Width = 52
                GridColumn34.Width = 62
            Else
                cbxAvailed.Enabled = True
                GridColumn5.Visible = False
                GridColumn6.Visible = False

                GridColumn16.VisibleIndex = 0
                GridColumn17.VisibleIndex = 1
                GridColumn18.VisibleIndex = 2
                GridColumn19.VisibleIndex = 3
                GridColumn20.VisibleIndex = 4
                GridColumn21.VisibleIndex = 5
                GridColumn22.VisibleIndex = 6
                GridColumn23.VisibleIndex = 7
                GridColumn24.VisibleIndex = 8
                GridColumn34.VisibleIndex = 9

                GridColumn16.Width = 25
                GridColumn17.Width = 55
                GridColumn18.Width = 68
                GridColumn19.Width = 68
                GridColumn20.Width = 65
                GridColumn21.Width = 68
                GridColumn22.Width = 68
                GridColumn23.Width = 68
                GridColumn24.Width = 65
                GridColumn34.Width = 68
            End If
            GridView3.BestFitColumns()
            If cbxAvailed.Enabled Then
                If TotalRPPD + TotalInterest + TotalPayment = 0 Then
                    cbxAvailed.Enabled = False
                    cbxAvailed.Checked = False
                Else
                    cbxAvailed.Enabled = True
                End If
            End If
            Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, 2), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), "", "", "", "", FormatNumber(T_Penalty, 2), "")
            GridControl3.DataSource = Temp_DT

            iDue.Value = If(drv("Due").ToString = "", 0, drv("Due"))
            dRPPD.Value = drv("RPPD") / drv("Terms")
            dtpAvailed.Value = If(drv("Released") = "", Date.Now, drv("Released"))
            dtpFDD.Value = drv("FDD")
            dtpMaturity.Value = drv("LDD")
            dMonthlyAmort.Value = If(drv("Product").ToString.ToUpper.Contains("DEALER"), drv("Interest") / drv("Terms"), drv("GMA"))
            dBalance_Arrears.Value = NegativeNotAllowed(dFaceAmount.Value - (dTotalPayment.Value + If(DateValue(dtpLastP.Value) = DateValue(dtpAsOf.Value) And DateValue(dtpLastP.Value) = DateValue(GridView3.GetFocusedRowCellValue("Due Date")), CDbl(GridView3.GetFocusedRowCellValue("RPPD")), 0)))
            btnLedger.Enabled = True
            Compute()
            ComputeRPPD()

            DtpAsOf_ValueChanged(sender, e)
            DT_Others = DataSource(String.Format("SELECT CONCAT((SELECT GROUP_CONCAT(CONCAT(AccountTitle(ar_details.AccountCode), ' (', FORMAT(Credit,2),')')) FROM ar_details WHERE ar_details.DocumentNumber = M.DocumentNumber AND ar_details.`status` = 'ACTIVE' AND ar_details.Credit > 0)) AS 'Others', 1 AS 'Type', Debit - D.Paid AS 'Amount' FROM accounts_receivable M INNER JOIN ar_details D ON M.DocumentNumber = D.DocumentNumber AND D.Status = 'ACTIVE' AND M.Status = 'ACTIVE' AND AR_Status NOT IN ('FULLY PAID','PENDING','CHECKED') AND PayorID = '{0}' AND Debit - D.Paid > 0 AND M.PostingDate <= '{1}';", ValidateComboBox(cbxCreditApplication), FormatDatePicker(dtpAsOf)))
            If DT_Others.Rows.Count > 0 Then
                Dim OtherX As String = ""
                Dim TotalAdd As Double
                Dim TotalDeduct As Double 
                For x As Integer = 0 To DT_Others.Rows.Count - 1
                    If DT_Others(x)("Type") = 1 Then
                        TotalAdd += DT_Others(x)("Amount")
                    Else
                        TotalDeduct += DT_Others(x)("Amount")
                    End If
                    OtherX = OtherX & ", " & DT_Others(x)("Others")
                Next
                cbxOthers.Text = OtherX.Substring(2)
                If TotalAdd > TotalDeduct Then
                    cbxAdd.Checked = True
                    dOthers.Value = TotalAdd - TotalDeduct
                ElseIf TotalDeduct > TotalAdd Then
                    cbxDeduct.Checked = True
                    dOthers.Value = TotalDeduct - TotalAdd
                Else
                    cbxAdd.Checked = True
                    dOthers.Value = 0
                End If
            Else
                cbxOthers.Text = ""
                dOthers.Value = 0
            End If

            CbxPrefix_B.Enabled = False
            TxtFirstN_B.Enabled = False
            TxtMiddleN_B.Enabled = False
            TxtLastN_B.Enabled = False
            cbxSuffix_B.Enabled = False
            txtCompleteAdd.Enabled = False
            txtMobile.Enabled = False
            txtEmail.Enabled = False
            txtAccount.Enabled = False
            iAccount_2.Enabled = False
            txtCollateral.Enabled = False
            dPrincipal.Enabled = False
            dFaceAmount.Enabled = False
            iDue.Enabled = False
            dMonthlyAmort.Enabled = False
            dRPPD.Enabled = False
            dtpAvailed.Enabled = False
            dtpFDD.Enabled = False
            dtpLastP.Enabled = False
            dtpMaturity.Enabled = False
            btnEarly.Visible = True
            btnDeductBalance.Visible = True
            dDiscountP.Enabled = False
            dDiscount.Enabled = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        Try
            If cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = cbxCreditApplication.SelectedValue
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub GroupControl1_Click(sender As Object, e As EventArgs) Handles GroupControl1.Click
        If GroupControl1.Text = "" Then
            GroupControl1.Location = New Point(482, 327)
            GroupControl1.Size = New Point(665, 255)
            GridControl3.Visible = True
            GroupControl1.Text = "Amortization Schedule"
        Else
            GroupControl1.Size = New Point(45, 255)
            GroupControl1.Location = New Point(482, 327)
            GridControl3.Visible = False
            GroupControl1.Text = ""
        End If
    End Sub

    Private Sub GroupControl1_MouseLeave(sender As Object, e As EventArgs) Handles GroupControl1.MouseLeave
        GroupControl1.BackColor = Color.White
    End Sub

    Private Sub GroupControl1_MouseEnter(sender As Object, e As EventArgs) Handles GroupControl1.MouseEnter
        GroupControl1.BackColor = Color.LightSkyBlue
    End Sub

    Private Sub BtnWaive_Click(sender As Object, e As EventArgs) Handles btnWaive.Click
        If dTotalPenalties.Value + dUnpaidPenalties.Value = 0 Then
            MsgBox("No Penalty or RPPD Payables, nothing to waive.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If CreditNumber = "" And cbxCreditApplication.SelectedIndex = -1 Then
            MsgBox("Please select Account.", MsgBoxStyle.Information, "Info")
            cbxCreditApplication.DroppedDown = True
            Exit Sub
        End If

        ComputeRPPD()
        Dim drv As DataRowView = DirectCast(cbxCreditApplication.SelectedItem, DataRowView)
        If MsgBox("Are you sure about this penalty to be waived?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Dim Waive As New FrmWaivePayables
            With Waive
                .dPenalty_P.Value = dTotalPenalties.Value + dUnpaidPenalties.Value
                .dRPPD_P.Value = dRPPD_P
                .BorrowerName = If(cbxCreditApplication.SelectedIndex = -1, TxtFirstN_B.Text & " " & TxtLastN_B.Text, cbxCreditApplication.Text)
                .CreditNumber = If(cbxCreditApplication.SelectedIndex = -1, CreditNumber, cbxCreditApplication.SelectedValue)
                .ORNumber = "Waive_" & Format(Date.Now, "yyyyMMddHHmmss")
                .ORDate = dtpAsOf.Value

                'Generate SOA
                GenerateSOA(False, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & .ORNumber & ".pdf")
                If .ShowDialog() = DialogResult.OK Then
                    MsgBox("Successfully Waived!", MsgBoxStyle.Information, "Info")
                    If cbxCreditApplication.SelectedIndex = -1 Then
                        dDiscount.Value = .dPenalty_P.Value - .dPenalty.Value
                        dDiscountRPPD.Value = .dRPPD_P.Value - .dRPPD.Value
                    Else
                        CbxCreditApplication_SelectedIndexChanged(sender, e)
                    End If
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub GridView3_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        If GridView3.RowCount = 0 Then
            Exit Sub
        End If

        Dim RightRow As Integer = 0
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                If DateValue(dtpAsOf.Value) >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                    RightRow = x
                ElseIf x = GridView3.RowCount - 2 And DateValue(dtpAsOf.Value) < CDate(GridView3.GetRowCellValue(1, "Due Date")) Then
                    RightRow = 1
                End If
            End If
        Next
        If GridView3.FocusedRowHandle = RightRow Then
        Else
            GridView3.FocusedRowHandle = RightRow
        End If
    End Sub

    Private Sub BtnEarly_Click(sender As Object, e As EventArgs) Handles btnEarly.Click
        Dim drv As DataRowView = DirectCast(cbxCreditApplication.SelectedItem, DataRowView)
        If GridView3.FocusedRowHandle + 1 = GridView3.RowCount - 1 Then
            MsgBox("Account is already passed due or at the last month of schedule, early settlement is not allowed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim Early As New FrmEarlySettlement
        Dim CurrentTerms As Integer = 0
        With Early
            .From_Payment = True
            .btnEarly.Enabled = True
            .CreditNumber = If(cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "", CreditNumber, cbxCreditApplication.SelectedValue)
            .AsOf = dtpAsOf.Value
            .LR = dBalance_Arrears.Value
            .Updated = dBalance_Arrears.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable"))
            .Terms = drv("Terms")
            .UDI = drv("Interest")
            If drv("branch_code").ToString.Contains("-MF") Then
                .MF = True
                .UDI = drv("Interest") - TotalInterest
            End If
            .BalanceRPPD = RPPD_Application - TotalRPPD
            .GridControl3.DataSource = GridControl3.DataSource
            CurrentTerms = GridView3.FocusedRowHandle
            If DateDiff(DateInterval.Day, DateValue(dtpAsOf.Value), GridView3.GetFocusedRowCellValue("Due Date")) >= 15 Then
            Else
                CurrentTerms += 1
            End If
            If DateDiff(DateInterval.Day, DateValue(dtpAsOf.Value), GridView3.GetRowCellValue(GridView3.FocusedRowHandle + 1, "Due Date")) >= 15 Then
            Else
                CurrentTerms += 1
            End If
            If CurrentTerms > .Terms Then
                MsgBox("Account is less than a month from maturity, Early Settlement is not allowed", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim Temp_Terms As Integer = 0
            For y As Integer = 1 To GridView3.RowCount - 2
                If .LR <= CDbl(GridView3.GetRowCellValue(y, "Loans Receivable")) Then
                    Temp_Terms += 1
                End If
            Next
            For y As Integer = 1 To GridView3.RowCount - 2
                If .LR <= CDbl(GridView3.GetRowCellValue(y, "Loans Receivable")) And CurrentTerms <= Temp_Terms Then
                    CurrentTerms += 1
                End If
            Next
            .Availed = cbxAvailed.Checked
            .iTerm.Value = CurrentTerms
            If .dLR.Value = 0 Then
                .dLR.Value = dBalance_Arrears.Value
            End If
            Dim drv_P As DataRowView = DirectCast(txtAccount.SelectedItem, DataRowView)
            If drv_P("payment").ToString.Contains("Bimonthly") Then
                .iTerm.MaxValue = (drv("Terms") * 2) - 1
            Else
                .iTerm.MaxValue = drv("Terms") - 1
            End If
            .iTerm.MinValue = CurrentTerms - 1
            If .ShowDialog = DialogResult.OK Then
                Dim PayablePrincipal As Double = GridView3.GetRowCellValue(0, "Outstanding Principal")
                Dim PayableInterest As Double = GridView3.GetRowCellValue(0, "Unearn Income")
                Dim PayableRPPD As Double = GridView3.GetRowCellValue(0, "Total_RPPD")
                dRPPD_P = NegativeNotAllowed(((PayableRPPD - TotalRPPD) - .dRPPD.Value) + If(TotalRPPD_Payable > TotalRPPD And dtpAsOf.Value.Day > CDate(GridView3.GetFocusedRowCellValue("Due Date")).Day, CDbl(GridView3.GetFocusedRowCellValue("RPPD")), 0))
                dUDI_P = NegativeNotAllowed((PayableInterest - TotalInterest) - .dUDI.Value)
                dPrincipal_P = PayablePrincipal - TotalPayment
                UDI_Amount_Early = .dUDI.Value
                UDI_Percent_Early = .UDI_Percent
                RPPD_Amount_Early = .dRPPD.Value
                dRebate.Value = .dUDI.Value + .dRPPD.Value

                RPPD_P = dRPPD_P
                EarlySettlement = True
                dtpAsOf.Enabled = False
                lblTotalAmountDue.Text = "Liquidating Value :"

                If MsgBoxYes("Do you want to save this early settlement so that this will be visible on the Official Receipt?") = MsgBoxResult.Yes Then
                    Dim SQL As String = String.Format("UPDATE credit_earlysettlement SET `status` = 'CANCELLED' WHERE `status` = 'ACTIVE' AND early_status = 'PENDING' AND CreditNumber = '{0}';", cbxCreditApplication.SelectedValue)
                    SQL &= "INSERT INTO credit_earlysettlement SET"
                    SQL &= String.Format("  CreditNumber = '{0}', ", cbxCreditApplication.SelectedValue)
                    SQL &= String.Format("  LR = '{0}', ", dBalance_Arrears.Value)
                    SQL &= String.Format("  UDI_Discount = '{0}', ", UDI_Amount_Early)
                    SQL &= String.Format("  AvailedRPPD = '{0}', ", RPPD_Amount_Early)
                    SQL &= String.Format("  BranchID = '{0}', ", Branch_ID)
                    SQL &= String.Format("  AR = '{0}', ", DataObject(String.Format("SELECT IFNULL(SUM(Debit - D.Paid),0) AS 'Debit' FROM accounts_receivable M INNER JOIN ar_details D ON M.DocumentNumber = D.DocumentNumber AND D.Status = 'ACTIVE' AND M.Status = 'ACTIVE' AND AR_Status NOT IN ('FULLY PAID','PENDING','CHECKED') AND PayorID = '{0}' AND Debit - D.Paid > 0;", ValidateComboBox(cbxCreditApplication))))
                    SQL &= String.Format("  Penalty = '{0}', ", Decimal50(NegativeNotAllowed((dTotalPenalties.Value - dDiscount.Value) + dUnpaidPenalties.Value)))
                    SQL &= String.Format("  AsOf = '{0}';", Format(dtpAsOf.Value, "yyyy-MM-dd"))
                    DataObject(SQL)
                    MsgBox("Successfully Computed!", MsgBoxStyle.Information, "Info")
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDeductBalance_Click(sender As Object, e As EventArgs) Handles btnDeductBalance.Click
        If MsgBoxYes("Are you sure about this computation for deduct balance?") = MsgBoxResult.Yes Then
            Dim Unposted As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DISTINCT CVNumber),'') AS 'Reference' FROM accounting_entry WHERE ReferenceN = '{0}' AND `status` = 'ACTIVE' AND PostStatus = 'PENDING'", If(cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "", CreditNumber, cbxCreditApplication.SelectedValue)))
            If Unposted <> "" Then
                If MsgBox(String.Format("This account have unposted transactions with reference number(s) {0}. Please post the transaction first before creating the deduct balance because it might affect the computation. Would you like to proceed?", Unposted), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            Dim DeductCredit As String = DataObject(String.Format("SELECT CreditNumber_F FROM credit_deductbalance WHERE CreditNumber = '{0}' AND CreditNumber_F != '' AND `status` = 'ACTIVE' AND deduct_status = 'PENDING';", If(cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "", CreditNumber, cbxCreditApplication.SelectedValue)))
            If DeductCredit <> "" Then
                MsgBox(String.Format("This account already have an application with Credit Number {0}, please cancel the application if you need to create a new deduct balance computation for this account.", DeductCredit), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim SQL As String = String.Format("UPDATE credit_deductbalance SET `status` = 'CANCELLED' WHERE `status` = 'ACTIVE' AND deduct_status = 'PENDING' AND CreditNumber = '{0}' AND AccountNumber = '{1}';", If(cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "", CreditNumber, cbxCreditApplication.SelectedValue), iAccount_2.Text)
            SQL &= "INSERT INTO credit_deductbalance SET"
            SQL &= "  CreditNumber_F = '',"
            SQL &= String.Format("  AccountNumber = '{0}', ", iAccount_2.Text)
            SQL &= String.Format("  CreditNumber = '{0}', ", If(cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "", CreditNumber, cbxCreditApplication.SelectedValue))
            SQL &= String.Format("  LR = '{0}', ", dBalance_Arrears.Value)
            SQL &= String.Format("  UDI_Discount = '{0}', ", UDI_Amount_Early)
            SQL &= String.Format("  UDI_DiscountP = '{0}', ", UDI_Percent_Early)
            SQL &= String.Format("  AvailedRPPD = '{0}', ", RPPD_Amount_Early)
            SQL &= String.Format("  AR = '{0}', ", DataObject(String.Format("SELECT IFNULL(SUM(Debit - D.Paid),0) AS 'Debit' FROM accounts_receivable M INNER JOIN ar_details D ON M.DocumentNumber = D.DocumentNumber AND D.Status = 'ACTIVE' AND M.Status = 'ACTIVE' AND AR_Status NOT IN ('FULLY PAID','PENDING','CHECKED') AND PayorID = '{0}' AND Debit - D.Paid > 0;", If(cbxCreditApplication.SelectedIndex = -1 Or cbxCreditApplication.Text = "", CreditNumber, cbxCreditApplication.SelectedValue))))
            SQL &= String.Format("  Penalty = '{0}', ", dTotalPenalties.Value)
            SQL &= String.Format("  Amount = '{0}', ", 0)
            SQL &= String.Format("  BranchID = '{0}', ", Branch_ID)
            SQL &= String.Format("  AsOf = '{0}';", Format(dtpAsOf.Value, "yyyy-MM-dd"))
            DataObject(SQL)
            MsgBox("Successfully Deduct Balance!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub DDiscountRPPD_ValueChanged(sender As Object, e As EventArgs) Handles dDiscountRPPD.ValueChanged
        dDiscountedRPPD.Value = dTotalArrears.Value - dDiscountRPPD.Value
    End Sub

    Private Sub DDiscountedRPPD_ValueChanged(sender As Object, e As EventArgs) Handles dDiscountedRPPD.ValueChanged
        dOverdue.Value = Decimal50((NegativeNotAllowed((dUnpaidPenalties.Value + dTotalPenalties.Value) - dDiscount.Value) + (dTotalArrears.Value - dDiscountRPPD.Value) + If(cbxAdd.Checked, dOthers.Value, dOthers.Value - (dOthers.Value * 2))) - dRebate.Value)
    End Sub

    Private Sub CbxAvailed_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAvailed.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        IDaysD_ValueChanged(sender, e)
        ComputePenalties()
    End Sub

    Private Sub DtpPenaltyRate_ValueChanged(sender As Object, e As EventArgs) Handles dtpPenaltyRate.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        Penalty_Percent = dtpPenaltyRate.Value / 100
        ComputePenalties()
    End Sub

    Private Sub BtnDeductBalanceList_Click(sender As Object, e As EventArgs) Handles btnDeductBalanceList.Click
        Dim List As New FrmDeductBalanceList
        With List
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub RPPDCompute()
        Availed_RPPD = 0

        Dim TotalPaidNMA As Double = TotalPayment + TotalInterest + dPrincipal_DTS + dUDI_DTS
        'Dim NonthlyNMA As Double = CDbl(GridView3.GetRowCellValue(1, "Interest Income")) + CDbl(GridView3.GetRowCellValue(1, "Principal Allocation"))
        'Dim NumberOfRPPD As Integer = Math.Floor(TotalPaidNMA / NonthlyNMA)
        'For x As Integer = 0 To NumberOfRPPD - 1
        '    Availed_RPPD = Availed_RPPD + CDbl(GridView3.GetRowCellValue(1, "RPPD"))
        'Next
        Dim MustPaidPrincipalUDI As Double
        For x As Integer = 1 To GridView3.RowCount - 1
            MustPaidPrincipalUDI += CDbl(GridView3.GetRowCellValue(x, "Interest Income")) + CDbl(GridView3.GetRowCellValue(x, "Principal Allocation"))
            If TotalPaidNMA >= MustPaidPrincipalUDI Then
                Availed_RPPD += CDbl(GridView3.GetRowCellValue(x, "RPPD"))
            End If
        Next
        If (DateValue(dtpAsOf.Value) <= CDate(GridView3.GetFocusedRowCellValue("Due Date")).AddDays(If(GridView3.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 1, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))))) And dBalance_Arrears.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")) And dRPPD_P > 0 Then
            Availed_RPPD -= CDbl(GridView3.GetRowCellValue(1, "RPPD"))
        End If
        Availed_RPPD = NegativeNotAllowed(Availed_RPPD - (TotalRPPD + dRPPD_P))
    End Sub

    Private Sub BtnDeductions_Click(sender As Object, e As EventArgs) Handles btnDeductions.Click
        Dim WithACR As Boolean
        Dim drv As DataRowView = DirectCast(cbxCreditApplication.SelectedItem, DataRowView)
        WithACR = DataObject(String.Format("SELECT Count(ID) FROM acknowledgement_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'LA' AND `status` = 'ACTIVE';", cbxCreditApplication.SelectedValue))
        If WithACR > 0 Then
            If MsgBoxYes("Account already have {0} of acknowledgement receipt(s), would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim AR As New FrmAccountsReceivable
        With AR
            .vSave = True
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .From_JV_Restructure = True
            .Clear(False)
            .tabList.Visible = False
            .btnNext.Enabled = False
            .btnRefresh.Enabled = False
            .GL_DocumentNumber = cbxCreditApplication.SelectedValue
            .cbxBank.Tag = drv("BankID")
            If .ShowDialog = DialogResult.OK Then
            End If
            .Dispose()
        End With
    End Sub
End Class