Imports DevExpress.XtraReports.UI
Public Class FrmAccountLedger

    Public CreditNumber As String
    Dim SQL As String
    Dim SQL_II As String
    ReadOnly DT_Ledger As New DataTable
    Dim CreditDT As DataTable
    Dim DT As DataTable
    Dim TotalBilling As Double
    ReadOnly TotalPenalty As Double
    Dim ID As Integer
    Dim Mortgage_ID As Integer
    Dim BankID As Integer
    Dim Trigger_Send As Integer
    Dim Code As String
    Public From_GetBalanceLedgerFunction As Boolean
    Public FromWaivePayables As Boolean

    Private Sub FrmAccountLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        If From_GetBalanceLedgerFunction Then
            SQL = "SELECT C.ID, CreditNumber, "
            SQL &= "    AmountApplied, Terms, Interest, RPPD, Face_Amount, Interest_Rate, RPPD_Rate, GMA, Rebate"
            SQL &= " FROM credit_application C"
            SQL &= String.Format("  WHERE CreditNumber = '{0}';", CreditNumber)
            CreditDT = DataSource(SQL)
            If CreditDT.Rows.Count > 0 Then
                lblPrincipal.Text = FormatNumber(CreditDT(0)("AmountApplied"), 2)
                lblUDI.Text = FormatNumber(CreditDT(0)("Interest"), 2)
                lblRPPD.Text = FormatNumber(CreditDT(0)("RPPD"), 2)
                lblRPPD.Tag = FormatNumber(CreditDT(0)("RPPD_Rate"), 2)
                lblFaceAmount.Text = FormatNumber(CreditDT(0)("Face_Amount"), 2)
                lblRate.Text = FormatNumber(CreditDT(0)("Interest_Rate"), 2)
                lblGMA.Text = FormatNumber(CreditDT(0)("GMA"), 2)
                lblMR.Text = FormatNumber(CreditDT(0)("Rebate"), 2)
                lblNMA.Text = FormatNumber(CreditDT(0)("GMA") - CreditDT(0)("Rebate"), 2)
                lblTerms.Text = CreditDT(0)("Terms")
            End If
            GoTo Here
        End If
        Icon = My.Resources.iLoanWorkX_ico
        Cursor = Cursors.WaitCursor
        Code = GenerateOTAC()

        If User_Type = "ADMIN" Then
            iPenalty.Visible = True
            iAvailed.Visible = True
            iRemoveAvailed.Visible = True
            iRemovePenaltyAddRPPD.Visible = True
            btnAddReverseRPPD.Visible = True
        Else
            iPenalty.Visible = False
            iAvailed.Visible = False
            iRemoveAvailed.Visible = False
            iRemovePenaltyAddRPPD.Visible = False
            btnAddReverseRPPD.Visible = False
        End If

        SQL = "SELECT C.ID, CreditNumber, Product, IF(AssumptionCredit = '',BorrowerID,(SELECT BorrowerID FROM credit_application WHERE credit_application.CreditNumber = C.AssumptionCredit)) AS 'BorrowerID', "
        SQL &= "   Borrower_Credit_Assumption(IF(CreditNumber_Old_Assumption = '',CreditNumber, CreditNumber_Old_Assumption)) AS 'FullN',"
        SQL &= "   CONCAT(IF(FirstN_S = '','',CONCAT(FirstN_S, ' ')), IF(MiddleN_S = '','',CONCAT(MiddleN_S, ' ')), IF(LastN_S = '','',CONCAT(LastN_S, ' ')), Suffix_S) AS 'Spouse',"
        SQL &= "   CONCAT(IF(FirstN_C1 = '','',CONCAT(FirstN_C1, ' ')), IF(MiddleN_C1 = '','',CONCAT(MiddleN_C1, ' ')), IF(LastN_C1 = '','',CONCAT(LastN_C1, ' ')), Suffix_C1) AS 'Comaker1',"
        SQL &= "   CONCAT(IF(FirstN_C2 = '','',CONCAT(FirstN_C2, ' ')), IF(MiddleN_C2 = '','',CONCAT(MiddleN_C2, ' ')), IF(LastN_C2 = '','',CONCAT(LastN_C2, ' ')), Suffix_C2) AS 'Comaker2',"
        SQL &= "   CONCAT(IF(FirstN_C3 = '','',CONCAT(FirstN_C3, ' ')), IF(MiddleN_C3 = '','',CONCAT(MiddleN_C3, ' ')), IF(LastN_C3 = '','',CONCAT(LastN_C3, ' ')), Suffix_C3) AS 'Comaker3',"
        SQL &= "   CONCAT(IF(FirstN_C4 = '','',CONCAT(FirstN_C4, ' ')), IF(MiddleN_C4 = '','',CONCAT(MiddleN_C4, ' ')), IF(LastN_C4 = '','',CONCAT(LastN_C4, ' ')), Suffix_C4) AS 'Comaker4',"
        SQL &= "   CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) AS 'Address',"
        SQL &= "   ForCI, P.Code AS 'Product_Code', MigratedValidation, branch_id,"
        SQL &= "   loan_type, Employer_B, Position_B, product_id, DATE_FORMAT(Birth_B,'%M %d, %Y') AS 'Birth_B', Email_B, Mobile_B, AmountApplied, Terms, Interest, RPPD, Face_Amount, Interest_Rate, RPPD_Rate, GMA, Rebate, LastN_B, P.Last_Principal AS 'Last Principal', "
        SQL &= "    AccountNumber, mortgage_ID, PaymentRequest, PaymentArrangement, BankID, IFNULL((SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ') FROM branch_bank WHERE ID = C.BankID),'') AS 'Bank', InsuranceComp, Coverage, IFNULL(DATE_FORMAT(Expiry,'%M %d, %Y'),'') AS 'Expiry', IFNULL(DATE_FORMAT(Insurance,'%M %d, %Y'),'') AS 'Insurance', Premium, IF(CVforJV,(SELECT DocumentNumber FROM journal_voucher WHERE ReferenceID = C.CreditNumber AND CVforJV = 1 AND `status` = 'ACTIVE' AND Voucher_Status IN ('CHECKED','APPROVED') LIMIT 1),CVNumber) AS 'CVNum', DATE_FORMAT(Released,'%M %d, %Y') AS 'Released', DATE_FORMAT(PN,'%M %d, %Y') AS 'PN', DATE_FORMAT(FDD,'%M %d, %Y') AS 'FDD', DATE_FORMAT(LDD,'%M %d, %Y') AS 'LDD', CI, Referred, Notes, Remarks, P.Payment AS 'Product_Payment', Interest_N, RPPD_N, Principal_N, Remarks AS 'Remarks_Final', branch_code, ForRestructuring, Borrower_S, Borrower_C1, Borrower_C2, Borrower_C3, Borrower_C4, PartiallyRecovered"
        SQL &= " FROM credit_application C"
        SQL &= String.Format(" LEFT JOIN (SELECT ID, Payment, `code`, Last_Principal FROM product_setup) P ON P.ID = C.product_id", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        SQL &= String.Format("  WHERE CreditNumber = '{0}';", CreditNumber)
        CreditDT = DataSource(SQL)

        If CreditDT.Rows.Count > 0 Then
            ID = CreditDT(0)("ID")
            Mortgage_ID = CreditDT(0)("mortgage_ID")
            If Mortgage_ID = 2 Then
                cbxOptions.Items.RemoveAt(5)
                cbxOptions.Items.Add("Extrajudicial Foreclosure")
            End If
            BankID = CreditDT(0)("BankID")
            If CreditDT(0)("BorrowerID").ToString.Contains("C") Then
                If CreditDT(0)("Spouse").ToString.Trim = "" Then
                    lblBorrower.Text = "***" & CreditDT(0)("FullN").ToString.ToUpper.Trim & "***"
                Else
                    lblBorrower.Text = "***" & CreditDT(0)("FullN").ToString.ToUpper & " Represented By: " & CreditDT(0)("Spouse").ToString.ToUpper.Trim & "***"
                End If
            Else
                lblBorrower.Text = "***" & CreditDT(0)("FullN").ToString.ToUpper.Trim & If(CreditDT(0)("Borrower_S") = True, " AND " & CreditDT(0)("Spouse").ToString.ToUpper.Trim, "") & If(CreditDT(0)("Borrower_C1") = True, " AND " & CreditDT(0)("Comaker1").ToString.ToUpper.Trim, "") & If(CreditDT(0)("Borrower_C2") = True, " AND " & CreditDT(0)("Comaker2").ToString.ToUpper.Trim, "") & If(CreditDT(0)("Borrower_C3") = True, " AND " & CreditDT(0)("Comaker3").ToString.ToUpper.Trim, "") & If(CreditDT(0)("Borrower_C4") = True, " AND " & CreditDT(0)("Comaker4").ToString.ToUpper.Trim, "") & "***"
            End If
            lblAccountNumber.Text = CreditDT(0)("AccountNumber")
            If If(lblAccountNumber.Text = "", "", lblAccountNumber.Text.Substring(0, 2)) = "PA" Then
                lblAccountNumber.ForeColor = Color.SeaGreen
            End If
            If CreditDT(0)("Loan_Type") = "NEW" Then
                cbxNew.Checked = True
            ElseIf CreditDT(0)("Loan_Type") = "RELOAN" Then
                cbxRenew.Checked = True
            ElseIf CreditDT(0)("Loan_Type") = "RESTRUCTURE" Then
                cbxRestructured.Checked = True
            End If
            If CreditDT(0)("Product").ToString.Contains("SHOWMONEY") Then
                GridControl2.Size = New Point(396, 261)
                btnTermExtention.Visible = True
            Else
                GridControl2.Size = New Point(396, 298)
                btnTermExtention.Visible = False
            End If
            If CreditDT(0)("BorrowerID").ToString.Contains("C") Then
                LabelX17.Text = "Representative 1 :"
                LabelX2.Text = "Representative 2 :"
                LabelX6.Text = "Representative 3 :"
                LabelX9.Text = "Representative 4 :"
                LabelX12.Text = "Representative 5 :"

                LabelX17.Location = New Point(3, 53)
                lblSpouse.Location = New Point(104, 53)
                LabelX7.Location = New Point(3, 34)
                lblAddress.Location = New Point(104, 34)
                lblSpouse.Size = New Point(345, 13)
                LabelX1.Visible = False
                lblBirthdate.Visible = False
            End If
            If CreditDT(0)("PaymentRequest").ToString = "CLOSED" Then
                lblClosed.BringToFront()
                lblClosed.Visible = True
            End If
            lblSpouse.Text = CreditDT(0)("Spouse")
            lblAddress.Text = CreditDT(0)("Address")
            lblEmailAdd.Text = CreditDT(0)("Email_B")
            lblBirthdate.Text = CreditDT(0)("Birth_B").ToString
            lblMobile.Text = CreditDT(0)("Mobile_B")
            lblCM_1.Text = CreditDT(0)("Comaker1")
            lblCM_2.Text = CreditDT(0)("Comaker2")
            lblCM_3.Text = CreditDT(0)("Comaker3")
            lblCM_4.Text = CreditDT(0)("Comaker4")
            Dim DT_CoMaker As DataTable
            If CreditDT(0)("BorrowerID").ToString.Contains("I") Then
                DT_CoMaker = DataSource(String.Format("SELECT Mobile_C FROM credit_application_comaker WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}' ORDER BY `Rank`;", CreditDT(0)("CreditNumber")))
                If DT_CoMaker.Rows.Count > 0 Then
                    lblMobileCM_1.Text = DT_CoMaker(0)("Mobile_C")
                End If
                If DT_CoMaker.Rows.Count > 1 Then
                    lblMobileCM_2.Text = DT_CoMaker(1)("Mobile_C")
                End If
                If DT_CoMaker.Rows.Count > 2 Then
                    lblMobileCM_3.Text = DT_CoMaker(2)("Mobile_C")
                End If
                If DT_CoMaker.Rows.Count > 3 Then
                    lblMobileCM_4.Text = DT_CoMaker(3)("Mobile_C")
                End If
            Else
                DT_CoMaker = DataSource(String.Format("SELECT Contact_R2, Contact_R3, Contact_R4, Contact_R5 FROM profile_corporation WHERE BorrowerID = '{0}';", CreditDT(0)("BorrowerID")))
                If DT_CoMaker.Rows.Count > 0 Then
                    lblMobileCM_1.Text = DT_CoMaker(0)("Contact_R2")
                    lblMobileCM_2.Text = DT_CoMaker(0)("Contact_R3")
                    lblMobileCM_3.Text = DT_CoMaker(0)("Contact_R4")
                    lblMobileCM_4.Text = DT_CoMaker(0)("Contact_R5")
                End If
            End If
            If CreditDT(0)("ForCI") = "Yes" Or CreditDT(0)("mortgage_ID") = 1 Or CreditDT(0)("mortgage_ID") = 2 Then
                Dim DT_Collateral As DataTable = DataSource(String.Format("SELECT user_code, Collateral, PlateNum, MotorNum, ChassisNum, ORNum, BodyColor, TCT, Location, `Area` FROM credit_investigation CI LEFT JOIN (SELECT GROUP_CONCAT(PlateNum) AS 'PlateNum', GROUP_CONCAT(EngineNum) AS 'MotorNum', GROUP_CONCAT(ChassisNum) AS 'ChassisNum', GROUP_CONCAT(ORNum) AS 'ORNum', GROUP_CONCAT(BodyColor) AS 'BodyColor', CINumber FROM collateral_ve WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}' GROUP BY CreditNumber) VE ON CI.CINumber = VE.CINumber LEFT JOIN (SELECT GROUP_CONCAT(TCT) AS 'TCT', GROUP_CONCAT(Location) AS 'Location', CONCAT(GROUP_CONCAT(AREA),' SQM') AS 'Area', CINumber FROM collateral_re WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}' GROUP BY CreditNumber) RE ON CI.CINumber = RE.CINumber WHERE CI.`status` = 'ACTIVE' AND CI.CreditNumber = '{0}';", CreditDT(0)("CreditNumber")))
                If DT_Collateral.Rows.Count > 0 Then
                    lblCollateral.Text = NA(DT_Collateral(0)("Collateral").ToString)
                    lblPlateNumber.Text = NA(DT_Collateral(0)("PlateNum").ToString)
                    lblMotorNum.Text = NA(DT_Collateral(0)("MotorNum").ToString)
                    lblChassisNumber.Text = NA(DT_Collateral(0)("ChassisNum").ToString)
                    lblORNum.Text = NA(DT_Collateral(0)("ORNum").ToString)
                    lblColor.Text = NA(DT_Collateral(0)("BodyColor").ToString)
                    lblTCTNum.Text = NA(DT_Collateral(0)("TCT").ToString)
                    lblLocation.Text = NA(DT_Collateral(0)("Location").ToString)
                    lblArea.Text = NA(DT_Collateral(0)("Area").ToString)
                End If

                lblInsurance.Text = CreditDT(0)("InsuranceComp")
                lblCoverage.Text = CreditDT(0)("Coverage")
                lblExpiry.Text = CreditDT(0)("Expiry")
                lblPremium.Text = CreditDT(0)("Premium")
                lblDate.Text = CreditDT(0)("Insurance")
            Else
                lblCollateral.Text = CreditDT(0)("Employer_B")
                lblPlateNumber.Text = CreditDT(0)("Position_B")
                LabelX13.Text = "Employer :"
                lblPlateNum.Text = "Position :"
                LabelX16.Text = ""
                LabelX15.Text = ""
                LabelX19.Text = ""
                LabelX18.Text = ""
                LabelX21.Text = ""
                LabelX22.Text = ""
                LabelX20.Text = ""
                LabelX25.Text = ""
                LabelX23.Text = ""
                LabelX26.Text = ""
                LabelX28.Text = ""
                LabelX24.Text = ""
            End If
            lblCVNum.Text = CreditDT(0)("CVNum")
            btnCVNumber.Text = CreditDT(0)("CVNum")

            lblPrincipal.Text = FormatNumber(CreditDT(0)("AmountApplied"), 2)
            lblUDI.Text = FormatNumber(CreditDT(0)("Interest"), 2)
            lblRPPD.Text = FormatNumber(CreditDT(0)("RPPD"), 2)
            lblRPPD.Tag = FormatNumber(CreditDT(0)("RPPD_Rate"), 2)
            lblFaceAmount.Text = FormatNumber(CreditDT(0)("Face_Amount"), 2)
            lblRate.Text = FormatNumber(CreditDT(0)("Interest_Rate"), 2)
            lblGMA.Text = FormatNumber(CreditDT(0)("GMA"), 2)
            lblMR.Text = FormatNumber(CreditDT(0)("Rebate"), 2)
            lblNMA.Text = FormatNumber(CreditDT(0)("GMA") - CreditDT(0)("Rebate"), 2)
            lblTerms.Text = CreditDT(0)("Terms")
            lblPNDate.Text = CreditDT(0)("PN").ToString
            lblFDD.Text = CreditDT(0)("FDD").ToString
            If CreditDT(0)("FDD").ToString = "" Then
                lblMD.Text = ""
            Else
                lblMD.Text = CreditDT(0)("LDD")
            End If
            If CreditDT(0)("Last Principal") = "Yes" Then
                LabelX33.Visible = False
                lblGMA.Visible = False
                LabelX40.Text = "MI :"
                LabelX44.Text = "Last :"
                lblNMA.Text = FormatNumber(CreditDT(0)("AmountApplied") + CreditDT(0)("Rebate"), 2)
            Else
                LabelX33.Visible = True
                lblGMA.Visible = True
                LabelX40.Text = "MR :"
                LabelX44.Text = "NMA :"
                lblNMA.Text = FormatNumber(CreditDT(0)("GMA") - CreditDT(0)("Rebate"), 2)
            End If
            lblReleased.Text = CreditDT(0)("Released").ToString
            lblCI.Text = CreditDT(0)("CI")
            lblReferred.Text = CreditDT(0)("Referred")
            lblNotes.Text = CreditDT(0)("Notes")
            lblRemarks.Text = CreditDT(0)("Remarks_Final")
            lblBank.Text = CreditDT(0)("Bank")
            If (CreditDT(0)("Mortgage_ID") = 1 Or CreditDT(0)("Mortgage_ID") = 2) Then
            End If
Here:
            LoadAmortization()

            If GridColumn27.Visible Then
                If GridView2.RowCount > 9 Then
                    GridColumn6.Width = 22
                    GridColumn10.Width = 54
                    GridColumn11.Width = 54
                    GridColumn12.Width = 54
                    GridColumn7.Width = 62
                    GridColumn27.Width = 52
                    GridColumn8.Width = 62
                Else
                    GridColumn6.Width = 22
                    GridColumn10.Width = 54 + 2
                    GridColumn11.Width = 54 + 2
                    GridColumn12.Width = 54 + 2
                    GridColumn7.Width = 62 + 2
                    GridColumn27.Width = 52 + 2
                    GridColumn8.Width = 62 + 2
                End If
            Else
                If GridView2.RowCount > 9 Then
                    GridColumn6.Width = 27
                    GridColumn10.Width = 57
                    GridColumn11.Width = 69
                    GridColumn12.Width = 69
                    GridColumn7.Width = 69
                    GridColumn8.Width = 69
                Else
                    GridColumn6.Width = 30
                    GridColumn10.Width = 60
                    GridColumn11.Width = 72
                    GridColumn12.Width = 72
                    GridColumn7.Width = 72
                    GridColumn8.Width = 72
                End If
            End If

            With DT_Ledger
                .Columns.Clear()
                .Columns.Add("ID")
                .Columns.Add("Date")
                .Columns.Add("Remarks")
                .Columns.Add("O.R. No.")
                .Columns.Add("Amount Paid")
                .Columns.Add("A.R. P")
                .Columns.Add("Penalties P")
                .Columns.Add("Penalties W")
                .Columns.Add("RPPD P")
                .Columns.Add("RPPD A")
                .Columns.Add("Interest P")
                .Columns.Add("Principal P")
                .Columns.Add("A.R. B")
                .Columns.Add("Penalties B")
                .Columns.Add("RPPD B")
                .Columns.Add("UDI B")
                .Columns.Add("Principal B")
                .Columns.Add("Total")
                .Columns.Add("Status")
                .Columns.Add("BankID")
                .Columns.Add("DocumentDate")
                .Columns.Add("ReferenceN")
                .Columns.Add("Explanation")
                .Columns.Add("Attach")
                .Columns.Add("CVNum")
                .Columns.Add("JVNum")
                .Columns.Add("ORNum")
            End With

            LoadLedger()
            If From_GetBalanceLedgerFunction Then
                GoTo Here2
            End If
            If CreditDT(0)("branch_id") = Branch_ID Then
            Else
                lblBorrower.Enabled = False
                btnCVNumber.Enabled = False
                iPenalty.Enabled = False
                iAvailed.Enabled = False
                iRemoveAvailed.Enabled = False
                iRemovePenaltyAddRPPD.Enabled = False
                btnAddReverseRPPD.Enabled = False
                cbxOptions.Enabled = False
            End If
        End If

        LoadCompanyMode()
        Timer_Date.Start()
Here2:
        Cursor = Cursors.Default
        BringToFront()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettingsDefaultSize({LabelX17, lblSpouse, LabelX1, lblBirthdate, LabelX32, lblEmailAdd, lblAccountNumber, LabelX7, lblAddress, LabelX30, lblMobile, LabelX2, lblCM_1, LabelX4, lblMobileCM_1, LabelX6, lblCM_2, LabelX5, lblMobileCM_2, LabelX9, lblCM_3, LabelX8, lblMobileCM_3, LabelX12, lblCM_4, LabelX10, lblMobileCM_4, lblPlateNum, lblPlateNumber, LabelX16, lblMotorNum, LabelX15, lblChassisNumber, LabelX19, lblORNum, LabelX18, lblColor, LabelX21, lblTCTNum, LabelX22, lblLocation, LabelX20, lblArea, LabelX23, lblCoverage, LabelX26, lblExpiry, LabelX28, lblPremium, LabelX27, LabelX24, lblDate, LabelX35, lblRate, lblMonthsMD, lblTerms, LabelX34, lblReleased, LabelX37, lblUDI, LabelX33, lblGMA, LabelX29, lblPNDate, LabelX31, lblCI, LabelX41, lblRPPD, LabelX40, lblMR, LabelX38, lblFDD, LabelX39, lblReferred, LabelX45, lblFaceAmount, LabelX44, lblNMA, LabelX42, lblMD, LabelX43, lblNotes, LabelX46, lblRemarks, LabelX47})

            GetLabelFontSettingsRedDefault({lblBorrower, LabelX13, lblCollateral, LabelX25, lblInsurance, LabelX36, lblPrincipal, lblClosed, LabelX11, lblBank})

            GetLabelWithBackgroundFontSettings({LabelX93, LabelX94})

            GetCheckBoxFontSettings({cbxNew, cbxRenew, cbxRestructured})

            GetButtonFontSettings({btnSchedule, btnMonatorium, btnValidate, btnSurrender, btnTermExtention, btnCVNumber})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetComboBoxWinFormFontSettings({cbxOptions})
        Catch ex As Exception
            TriggerBugReport("Account Ledger - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadLedger()
        Cursor = Cursors.WaitCursor
        DT_Ledger.Rows.Clear()
        TotalBilling = DataObject(String.Format("SELECT IFNULL(SUM(Amount),0) FROM billing_entry WHERE CreditNumber = '{0}' AND `Status` = 'ACTIVE' AND IF(EffectivityD = '',TRUE,EffectivityD <= '{1}');", CreditNumber, Format(CDate(If(lblPNDate.Text = "", Date.Now, lblPNDate.Text)), "MM-dd-yyyy")))
        DT_Ledger.Rows.Add(0, Format(CDate(If(lblPNDate.Text = "", Date.Now, lblPNDate.Text)), "MM-dd-yy"), DataObject(String.Format("SELECT CONCAT('CV #: ',CVNumber) FROM check_received WHERE AssetNumber = '{0}' AND `status` NOT IN ('CANCELLED','DELETED','RETURNED') AND check_type = 'P' LIMIT 1;", CreditNumber)), "", "", "", "", "", "", "", "", "", FormatNumber(TotalBilling, 2), FormatNumber(TotalPenalty, 2), lblRPPD.Text, lblUDI.Text, lblPrincipal.Text, lblFaceAmount.Text, "POSTED")

        SQL_II = "SELECT "
        SQL_II &= "   MIN(ID) AS 'ID',"
        SQL_II &= "   DATE_FORMAT(IF(ORDate = '',`timestamp`,IF(SUBSTRING(ORNum,1,2) = 'OR' AND JVNum = '' AND CVNum = '',(SELECT ORDate FROM official_receipt WHERE DocumentNumber = REPLACE(ORNum,' [Discount]','')),ORDate)), '%m.%d.%y') AS 'Date',"
        SQL_II &= "   CONCAT(IF(IFNULL(P.DTS,0) = 1,'[DTS] ',''), IF(ORNum LIKE '%[Discount]%','Unearned Income',IF(JVNum != '' AND ORNum = '',IF((CVNum = '' AND ORNum = '') OR SUBSTRING(ORNum,1,2) != 'OR','',CONCAT('Reversal for ',IF(ORNum = '',CVNum,ORNum))),IF(JVNum != '' AND SUBSTRING(ORNum,1,2) = 'OR',CONCAT('Reversal for ',IF(ORNum = '',CVNum,ORNum)),IF(GROUP_CONCAT(Remarks) LIKE '%Advance%' AND COUNT(ORNum) = 1 AND PaidFor = 'UDI' AND MIN(EntryType) = 'CREDIT','Advance Interest',IF(GROUP_CONCAT(Remarks) LIKE '%Advance%' AND MIN(EntryType) = 'CREDIT','Advance Amortization',IF(P.PaidType = 'CHECK',IF(P.CheckBank = '',P.CheckN,CONCAT('[',P.CheckBank,'] ',P.CheckN)),CONCAT(P.PaidType, ' ', IF(DepositDate = '',IF(RemittanceDate = '','',DATE_FORMAT(RemittanceDate,'%m.%d.%y')),DATE_FORMAT(DepositDate,'%m.%d.%y')))))))))) AS 'Remarks',"
        SQL_II &= "   IF(JVNum != '',JVNum,IF(ORNum = '',CVNumber,ORNum)) AS 'O.R. No.',"
        'SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor IN ('Principal','Penalty','Billing','RPPD','UDI','Other Income') AND IF(PaidFor = 'Billing',EntryType = 'CREDIT',TRUE) THEN Amount END),0),2) AS 'Amount Paid',"
        '2020-05-22 REMOVE CONDITION OF  AND IF(PaidFor = 'Billing',EntryType = 'CREDIT',TRUE) KAY KUNG I REVERSE NIMO ANG OR NGA NAAY BILLING DLI MA INCLUDE SA AMOUNT PAID ANG BILL AMOUNT
        SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor IN ('Principal','Penalty','Billing','RPPD','UDI','Other Income') THEN Amount END),0) + IF(IFNULL(P.DTS,0) = 1,P.Paid,0),2) AS 'Amount Paid',"
        SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor IN ('Billing','Other Income') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),2) AS 'A.R. P',"
        SQL_II &= "   CONCAT('(',FORMAT(IFNULL(SUM(CASE WHEN PaidFor = 'Penalty-W' THEN Payable - PenaltyPayable END),0),2),')') AS 'Penalties W',"
        SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty') THEN PenaltyPayable END),0),2) AS 'Penalty Balance',"
        SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),2) AS 'Penalties P',"
        SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor = 'RPPD' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),2) AS 'RPPD P',"
        SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%',Amount,0 - Amount) END),0),2)  AS 'RPPD A',"
        SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),2) AS 'Interest P',"
        SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor = 'Accounts Receivable' AND EntryType = 'DEBIT' THEN Amount END),0),2) AS 'Accounts R',"
        If CompanyMode = 0 Then
            SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor IN ('Principal','RPPD') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),2) AS 'Principal P',"
        Else
            SQL_II &= "   FORMAT(IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),2) AS 'Principal P',"
        End If
        SQL_II &= "   MIN(PostStatus) AS 'Status',"
        SQL_II &= "   IFNULL(P.BankID,0) AS 'BankID', P.DocumentDate, P.ORNum2, P.Remarksx AS 'Explanation', P.Attach, CVNum, JVNum, ORNum"
        'SQL_II &= String.Format(" FROM accounting_entry LEFT JOIN (SELECT BankID, Payee_ID AS 'ReferenceN2', DocumentNumber AS 'ORNum2', DocumentNumber, IF(DocumentDate = '',NOW(),DocumentDate) AS 'DocumentDate', Explanation AS 'Remarksx', Type_Payment AS 'PaidType', CheckNumber AS 'CheckN', Attach, IFNULL((SELECT Bank FROM check_received WHERE ID = CheckID),'') AS 'CheckBank', DTS, DepositDate, RemittanceDate FROM official_receipt WHERE `status` = 'ACTIVE') P ON P.ReferenceN2 = accounting_entry.ReferenceN AND P.DocumentNumber = accounting_entry.ORNum  WHERE accounting_entry.`status` IN ('ACTIVE','PENDING') AND IF(`status` = 'PENDING' AND CVNum != '' AND JVNum = '' AND ORNum = '',FALSE,TRUE) AND ReferenceN = '{0}' GROUP BY CVNumber, JVNum ORDER BY DATE(IF(ORDate = '',`timestamp`,IF(SUBSTRING(ORNum,1,2) = 'OR' AND JVNum = '' AND CVNum = '',(SELECT ORDate FROM official_receipt WHERE DocumentNumber = REPLACE(ORNum,' [Discount]','')),ORDate))),`ID`;", CreditNumber)
        SQL_II &= String.Format(" FROM accounting_entry LEFT JOIN (SELECT BankID, Payee_ID AS 'ReferenceN2', DocumentNumber AS 'ORNum2', Paid, DocumentNumber, IF(DocumentDate = '',NOW(),DocumentDate) AS 'DocumentDate', Explanation AS 'Remarksx', Type_Payment AS 'PaidType', CheckNumber AS 'CheckN', Attach, IFNULL((SELECT Bank FROM check_received WHERE ID = CheckID),'') AS 'CheckBank', DTS, DepositDate, RemittanceDate FROM official_receipt WHERE `status` = 'ACTIVE') P ON P.ReferenceN2 = accounting_entry.ReferenceN AND P.DocumentNumber = accounting_entry.ORNum  WHERE accounting_entry.`status` IN ('ACTIVE','PENDING') AND IF(`status` = 'PENDING' AND CVNum = '' AND JVNum = '' AND ORNum = '',FALSE,TRUE) AND ReferenceN = '{0}' GROUP BY CVNumber, JVNum ORDER BY DATE(IF(ORDate = '',`timestamp`,IF(SUBSTRING(ORNum,1,2) = 'OR' AND JVNum = '' AND CVNum = '',(SELECT ORDate FROM official_receipt WHERE DocumentNumber = REPLACE(ORNum,' [Discount]','')),ORDate))),`ID`;", CreditNumber)
        DT = DataSource(SQL_II)
        For x As Integer = 0 To DT.Rows.Count - 1
            DT_Ledger.Rows.Add(DT(x)("ID"), DT(x)("Date"), DT(x)("Remarks"), DT(x)("O.R. No."), NegativeParenthesisV2(DT(x)("Amount Paid")), NegativeParenthesisV2(DT(x)("A.R. P")), NegativeParenthesisV2(DT(x)("Penalties P")), If(DT(x)("Penalties W").ToString.Contains("-"), DT(x)("Penalties W").ToString.Replace("-", ""), DT(x)("Penalties W")), NegativeParenthesisV2(DT(x)("RPPD P")), NegativeParenthesisV2(DT(x)("RPPD A")), NegativeParenthesisV2(DT(x)("Interest P")), NegativeParenthesisV2(DT(x)("Principal P")), DT(x)("Accounts R").ToString.Replace("-", ""), DT(x)("Penalty Balance").ToString.Replace("-", ""), 0, 0, 0, 0, DT(x)("Status"), DT(x)("BankID"), DT(x)("DocumentDate"), DT(x)("ORNum2"), DT(x)("Explanation"), DT(x)("Attach"), DT(x)("CVNum"), DT(x)("JVNum"), DT(x)("ORNum"))
        Next
        For x As Integer = 1 To DT_Ledger.Rows.Count - 1
            DT_Ledger(x)("A.R. B") = FormatNumber(NegativeNotAllowed((CDbl(DT_Ledger(x - 1)("A.R. B")) + CDbl(DT_Ledger(x)("A.R. B"))) - CDbl(DT_Ledger(x)("A.R. P"))), 2)
            Dim TotalRPPD As Double = If(DT_Ledger(x)("RPPD A").ToString.Contains("("), CDbl(DT_Ledger(x)("RPPD A").ToString.Replace("(", "").Replace(")", "") * -1), CDbl(DT_Ledger(x)("RPPD A"))) + CDbl(DT_Ledger(x)("RPPD P") * -1)
            DT_Ledger(x)("RPPD B") = FormatNumber(NegativeNotAllowed(CDbl(DT_Ledger(x - 1)("RPPD B")) + TotalRPPD), 2)
            DT_Ledger(x)("UDI B") = FormatNumber(NegativeNotAllowed(CDbl(DT_Ledger(x - 1)("UDI B")) - CDbl(DT_Ledger(x)("Interest P"))), 2)
            DT_Ledger(x)("Principal B") = FormatNumber(NegativeNotAllowed(CDbl(DT_Ledger(x - 1)("Principal B")) - CDbl(DT_Ledger(x)("Principal P"))), 2)
            DT_Ledger(x)("Total") = FormatNumber(NegativeNotAllowed(CDbl(DT_Ledger(x)("RPPD B")) + CDbl(DT_Ledger(x)("UDI B")) + CDbl(DT_Ledger(x)("Principal B"))), 2)
        Next
        GridControl1.DataSource = DT_Ledger
        If CDbl(DT_Ledger(DT_Ledger.Rows.Count - 1)("Principal B")) = 0 And CDbl(DT_Ledger(DT_Ledger.Rows.Count - 1)("Total")) > 0 Then
            DT_Ledger.Rows.Add(0, "", "Unearned Income", "", FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(CDbl(DT_Ledger(DT_Ledger.Rows.Count - 1)("RPPD B")), 2), FormatNumber(CDbl(DT_Ledger(DT_Ledger.Rows.Count - 1)("UDI B")), 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), "", 0, "", "", "", 0, "", "", "")
            DT_Ledger.Rows.Add(0, "", "CLOSED", "", FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), "", 0, "", "", "", 0, "", "", "")
        End If
        If lblClosed.Visible = False And CDbl(DT_Ledger(DT_Ledger.Rows.Count - 1)("Total")) = 0 Then
            DataObject(String.Format("UPDATE credit_application SET PaymentRequest = 'CLOSED', ClosedDate = '{1}' WHERE CreditNumber = '{0}';", CreditNumber, Format(CDate(DT(DT.Rows.Count - 1)("Date")), "yyyy-MM-dd")))
            lblClosed.BringToFront()
            lblClosed.Visible = True
        ElseIf lblClosed.Visible And CDbl(DT_Ledger(DT_Ledger.Rows.Count - 1)("Total")) > 0 Then
            DataObject(String.Format("UPDATE credit_application SET PaymentRequest = 'RELEASED', ClosedDate = '' WHERE CreditNumber = '{0}';", CreditNumber))
            lblClosed.SendToBack()
            lblClosed.Visible = False
        End If
        If GridView1.RowCount > 12 Then
            GridColumn3.Width = 80 - 12
            GridColumn4.Width = 78 - 5
            cbxOptions.Size = New Point(191 - 17, 25)
            LabelX93.Location = New Point(301 - 17, 357)
            LabelX94.Location = New Point(748 - 17, 357)
        Else
            GridColumn3.Width = 80
            GridColumn4.Width = 78
            cbxOptions.Size = New Point(191, 25)
            LabelX93.Location = New Point(301, 357)
            LabelX94.Location = New Point(748, 357)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Post_Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            Dim Reversal As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Remarks"))
            Try
                If Post_Status = "POSTED" Then
                    If Reversal.Contains("Reversal") Then
                        e.Appearance.ForeColor = Color.DarkBlue
                    Else
                        e.Appearance.ForeColor = Color.Black
                    End If
                ElseIf Post_Status = "PENDING" Then
                    e.Appearance.ForeColor = OfficialColor2 'Color.Red
                End If
            Catch ex As Exception
                TriggerBugReport("Account Ledger - GridView1RowCellStyle", ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Function NA(xTring As String)
        Return If(xTring = "", "N/A", xTring)
    End Function

    Private Sub FrmAccountLedger_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            Close()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            PrintLedger(True, "")
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Public Sub PrintLedger(Show As Boolean, FName As String)
        Dim Report As New RptSubsidiaryLedgervb
        With Report
            .Name = "Subsidiary Ledger of " & lblBorrower.Text.Replace("*", "")
            .lblAccountN.Text = lblAccountNumber.Text
            If cbxNew.Checked Then
                .cbxNewAccount.Checked = True
            ElseIf cbxRenew.Checked Then
                .cbxRenewal.Checked = True
            ElseIf cbxRestructured.Checked Then
                .cbxRestructured.Checked = True
            End If
            .lblBorrwer.Text = lblBorrower.Text
            .lblEmailAddress.Text = lblEmailAdd.Text
            .lblBirthdate.Text = lblBirthdate.Text
            .lblMobile.Text = lblMobile.Text
            .lblSpouse.Text = lblSpouse.Text
            .lblAddress.Text = lblAddress.Text
            .lblCoMaker1.Text = lblCM_1.Text
            .lblMobile_1.Text = lblMobileCM_1.Text
            .lblCoMaker2.Text = lblCM_2.Text
            .lblMobile_2.Text = lblMobileCM_2.Text
            .lblCoMaker3.Text = lblCM_3.Text
            .lblMobile_3.Text = lblMobileCM_3.Text
            .lblCoMaker4.Text = lblCM_4.Text
            .lblMobile_4.Text = lblMobileCM_4.Text
            .lblCollateral.Text = lblCollateral.Text
            .lblPlateNumber.Text = lblPlateNumber.Text
            .lblMotorNumber.Text = lblMotorNum.Text
            .lblChassisNumber.Text = lblChassisNumber.Text
            .lblORNumber.Text = lblORNum.Text
            .lblColor.Text = lblColor.Text
            .lblTCTNumber.Text = lblTCTNum.Text
            .lblLocation.Text = lblLocation.Text
            .lblArea.Text = lblArea.Text
            .lblInsurance.Text = lblInsurance.Text
            .lblCoverage.Text = lblCoverage.Text
            .lblExpiry.Text = lblExpiry.Text
            .lblPremium.Text = lblPremium.Text
            .lblCVNum.Text = lblCVNum.Text
            .lblInsuranceDate.Text = lblDate.Text
            .lblPrincipal.Text = lblPrincipal.Text
            .lblRate.Text = lblRate.Text
            .lblTerms.Text = lblTerms.Text
            .lblDateReleased.Text = lblReleased.Text
            .lblUDI.Text = lblUDI.Text
            .lblGMA.Text = lblGMA.Text
            .lblPNDate.Text = lblPNDate.Text
            .lblInvestigator.Text = lblCI.Text
            .lblRPPD.Text = lblRPPD.Text
            .lblMR.Text = lblMR.Text
            .lblFDD.Text = lblFDD.Text
            .lblReferred.Text = lblReferred.Text
            .lblFaceAmount.Text = lblFaceAmount.Text
            .lblNMA.Text = lblNMA.Text
            .lblMD.Text = lblMD.Text
            .lblNotes.Text = lblNotes.Text

            Dim SubRpt_Sched As New SubRptSchedule With {
                .DataSource = GridControl2.DataSource
            }
            .subRpt_Schedule.ReportSource = SubRpt_Sched
            With SubRpt_Sched
                .lblNo.DataBindings.Add("Text", GridControl2.DataSource, "No")
                .lblDate.DataBindings.Add("Text", GridControl2.DataSource, "Due Date")
                .lblRPPD.DataBindings.Add("Text", GridControl2.DataSource, "Total_RPPD")
                .lblUDI.DataBindings.Add("Text", GridControl2.DataSource, "Unearn Income")
                .lblPrincipal.DataBindings.Add("Text", GridControl2.DataSource, "Outstanding Principal")
                .lblLoansReceivable.DataBindings.Add("Text", GridControl2.DataSource, "Loans Receivable")

                If GridView2.RowCount >= 24 Then
                    .lblNo.SizeF = New Size(28, 11)
                    .lblDate.SizeF = New Size(70, 11)
                    .lblRPPD.SizeF = New Size(70, 11)
                    .lblUDI.SizeF = New Size(70, 11)
                    .lblPrincipal.SizeF = New Size(70, 11)
                    .lblLoansReceivable.SizeF = New Size(70, 11)
                    .Detail.HeightF = 11
                ElseIf GridView2.RowCount >= 22 Then
                    .lblNo.SizeF = New Size(28, 12)
                    .lblDate.SizeF = New Size(70, 12)
                    .lblRPPD.SizeF = New Size(70, 12)
                    .lblUDI.SizeF = New Size(70, 12)
                    .lblPrincipal.SizeF = New Size(70, 12)
                    .lblLoansReceivable.SizeF = New Size(70, 12)
                    .Detail.HeightF = 12
                ElseIf GridView2.RowCount >= 20 Then
                    .lblNo.SizeF = New Size(28, 13)
                    .lblDate.SizeF = New Size(70, 13)
                    .lblRPPD.SizeF = New Size(70, 13)
                    .lblUDI.SizeF = New Size(70, 13)
                    .lblPrincipal.SizeF = New Size(70, 13)
                    .lblLoansReceivable.SizeF = New Size(70, 13)
                    .Detail.HeightF = 12
                ElseIf GridView2.RowCount >= 18 Then
                    .lblNo.SizeF = New Size(28, 14)
                    .lblDate.SizeF = New Size(70, 14)
                    .lblRPPD.SizeF = New Size(70, 14)
                    .lblUDI.SizeF = New Size(70, 14)
                    .lblPrincipal.SizeF = New Size(70, 14)
                    .lblLoansReceivable.SizeF = New Size(70, 14)
                    .Detail.HeightF = 14
                ElseIf GridView2.RowCount <= 16 Then
                    .lblNo.SizeF = New Size(28, 15)
                    .lblDate.SizeF = New Size(70, 15)
                    .lblRPPD.SizeF = New Size(70, 15)
                    .lblUDI.SizeF = New Size(70, 15)
                    .lblPrincipal.SizeF = New Size(70, 15)
                    .lblLoansReceivable.SizeF = New Size(70, 15)
                    .Detail.HeightF = 15
                End If
            End With

            Dim SubRpt_Ledger As New SubRptLedger With {
                .DataSource = GridControl1.DataSource
            }
            .subRpt_Ledger.ReportSource = SubRpt_Ledger
            With SubRpt_Ledger
                .lblDate.DataBindings.Add("Text", GridControl1.DataSource, "Date")
                .lblRemarks.DataBindings.Add("Text", GridControl1.DataSource, "Remarks")
                .lblOR.DataBindings.Add("Text", GridControl1.DataSource, "O.R. No.")
                .lblAmountPaid.DataBindings.Add("Text", GridControl1.DataSource, "Amount Paid")
                .lblAR_P.DataBindings.Add("Text", GridControl1.DataSource, "A.R. P")
                .lblPenalties_P.DataBindings.Add("Text", GridControl1.DataSource, "Penalties P")
                .lblPenalties_W.DataBindings.Add("Text", GridControl1.DataSource, "Penalties W")
                .lblRPPD_P.DataBindings.Add("Text", GridControl1.DataSource, "RPPD P")
                .lblRPPD_F.DataBindings.Add("Text", GridControl1.DataSource, "RPPD A")
                .lblInterest_P.DataBindings.Add("Text", GridControl1.DataSource, "Interest P")
                .lblPrincipal_P.DataBindings.Add("Text", GridControl1.DataSource, "Principal P")
                .lblAR_B.DataBindings.Add("Text", GridControl1.DataSource, "A.R. B")
                .lblPenalties_B.DataBindings.Add("Text", GridControl1.DataSource, "Penalties B")
                .lblRPPD_B.DataBindings.Add("Text", GridControl1.DataSource, "RPPD B")
                .lblInterest_B.DataBindings.Add("Text", GridControl1.DataSource, "UDI B")
                .lblPrincipal_B.DataBindings.Add("Text", GridControl1.DataSource, "Principal B")
                .lblTotal_B.DataBindings.Add("Text", GridControl1.DataSource, "Total")
            End With

            If CompanyMode = 0 Then
                .XrLabel26.Visible = False
                .lblRPPD.Visible = False

                .XrLabel73.Visible = False
                .lblMR.Visible = False

                .XrLabel2.Visible = False
                .XrLabel1.SizeF = New SizeF(70 + 10, 20)
                .XrLabel48.SizeF = New SizeF(70 + 20, 20)
                .XrLabel4.SizeF = New SizeF(70 + 20, 20)
                .XrLabel6.SizeF = New SizeF(70 + 20, 20)

                .XrLabel48.LocationF = New PointF(840 - 60, 50)
                .XrLabel4.LocationF = New PointF(910 - 40, 50)
                .XrLabel6.LocationF = New PointF(980 - 20, 50)
                With SubRpt_Sched
                    .lblRPPD.Visible = False
                    If GridView2.RowCount >= 24 Then
                        .lblNo.SizeF = New Size(28, 11)
                        .lblDate.SizeF = New Size(70 + 10, 11)
                        .lblUDI.SizeF = New Size(70 + 20, 11)
                        .lblPrincipal.SizeF = New Size(70 + 20, 11)
                        .lblLoansReceivable.SizeF = New Size(70 + 20, 11)
                        .Detail.HeightF = 11
                    ElseIf GridView2.RowCount >= 22 Then
                        .lblNo.SizeF = New Size(28, 12)
                        .lblDate.SizeF = New Size(70 + 10, 12)
                        .lblUDI.SizeF = New Size(70 + 20, 12)
                        .lblPrincipal.SizeF = New Size(70 + 20, 12)
                        .lblLoansReceivable.SizeF = New Size(70 + 20, 12)
                        .Detail.HeightF = 12
                    ElseIf GridView2.RowCount >= 20 Then
                        .lblNo.SizeF = New Size(28, 13)
                        .lblDate.SizeF = New Size(70 + 10, 13)
                        .lblUDI.SizeF = New Size(70 + 20, 13)
                        .lblPrincipal.SizeF = New Size(70 + 20, 13)
                        .lblLoansReceivable.SizeF = New Size(70 + 20, 13)
                        .Detail.HeightF = 12
                    ElseIf GridView2.RowCount >= 18 Then
                        .lblNo.SizeF = New Size(28, 14)
                        .lblDate.SizeF = New Size(70 + 10, 14)
                        .lblUDI.SizeF = New Size(70 + 20, 14)
                        .lblPrincipal.SizeF = New Size(70 + 20, 14)
                        .lblLoansReceivable.SizeF = New Size(70 + 20, 14)
                        .Detail.HeightF = 14
                    ElseIf GridView2.RowCount <= 16 Then
                        .lblNo.SizeF = New Size(28, 15)
                        .lblDate.SizeF = New Size(70 + 10, 15)
                        .lblUDI.SizeF = New Size(70 + 20, 15)
                        .lblPrincipal.SizeF = New Size(70 + 20, 15)
                        .lblLoansReceivable.SizeF = New Size(70 + 20, 15)
                        .Detail.HeightF = 15
                    End If
                End With
                With SubRpt_Sched
                    .lblUDI.LocationF = New PointF(168 - 60, 0)
                    .lblPrincipal.LocationF = New PointF(238 - 40, 0)
                    .lblLoansReceivable.LocationF = New PointF(308 - 20, 0)
                End With

                .XrLabel23.Visible = False
                .XrLabel44.Visible = False
                .XrLabel33.Visible = False
                .XrLabel8.SizeF = New SizeF(80, 40)
                .XrLabel18.SizeF = New SizeF(75, 40)
                .XrLabel21.SizeF = New SizeF(65, 20)
                .XrLabel12.SizeF = New SizeF(70, 20)
                .XrLabel42.SizeF = New SizeF(70, 20)
                .XrLabel24.SizeF = New SizeF(75, 20)
                .XrLabel27.SizeF = New SizeF(80, 20)
                .XrLabel28.SizeF = New SizeF(65, 20)
                .XrLabel31.SizeF = New SizeF(70, 20)
                .XrLabel35.SizeF = New SizeF(80, 20)
                .XrLabel37.SizeF = New SizeF(80, 20)
                .XrLabel38.SizeF = New SizeF(85, 40)

                .XrLabel14.SizeF = New SizeF(360, 20)
                .XrLabel16.SizeF = New SizeF(295, 20)

                .XrLabel18.LocationF = New PointF(235, 327)
                .XrLabel21.LocationF = New PointF(310, 347)
                .XrLabel12.LocationF = New PointF(375, 347)
                .XrLabel42.LocationF = New PointF(445, 347)
                .XrLabel24.LocationF = New PointF(445 + 70, 347)
                .XrLabel27.LocationF = New PointF(445 + 145, 347)
                .XrLabel28.LocationF = New PointF(445 + 225, 347)
                .XrLabel31.LocationF = New PointF(445 + 290, 347)
                .XrLabel35.LocationF = New PointF(445 + 360, 347)
                .XrLabel37.LocationF = New PointF(445 + 440, 347)
                .XrLabel38.LocationF = New PointF(445 + 520, 327)

                .XrLabel14.LocationF = New PointF(310, 327)
                .XrLabel16.LocationF = New PointF(445 + 225, 327)

                With SubRpt_Ledger
                    .lblRPPD_P.Visible = False
                    .lblRPPD_F.Visible = False
                    .lblRPPD_B.Visible = False

                    .lblOR.SizeF = New SizeF(80, 15)
                    .lblAmountPaid.SizeF = New SizeF(75, 15)
                    .lblAR_P.SizeF = New SizeF(75, 15)
                    .lblPenalties_P.SizeF = New SizeF(70, 15)
                    .lblPenalties_W.SizeF = New SizeF(70, 15)
                    .lblInterest_P.SizeF = New SizeF(75, 15)
                    .lblPrincipal_P.SizeF = New SizeF(80, 15)
                    .lblAR_B.SizeF = New SizeF(65, 15)
                    .lblPenalties_B.SizeF = New SizeF(70, 15)
                    .lblInterest_B.SizeF = New SizeF(80, 15)
                    .lblPrincipal_B.SizeF = New SizeF(80, 15)
                    .lblTotal_B.SizeF = New SizeF(85, 15)

                    .lblAmountPaid.LocationF = New PointF(235, 0)
                    .lblAR_P.LocationF = New PointF(310, 0)
                    .lblPenalties_P.LocationF = New PointF(375, 0)
                    .lblPenalties_W.LocationF = New PointF(445, 0)
                    .lblInterest_P.LocationF = New PointF(445 + 70, 0)
                    .lblPrincipal_P.LocationF = New PointF(445 + 145, 0)
                    .lblAR_B.LocationF = New PointF(445 + 225, 0)
                    .lblPenalties_B.LocationF = New PointF(445 + 290, 0)
                    .lblInterest_B.LocationF = New PointF(445 + 360, 0)
                    .lblPrincipal_B.LocationF = New PointF(445 + 440, 0)
                    .lblTotal_B.LocationF = New PointF(445 + 520, 0)
                End With
            End If

            If Show Then
                .ShowPreview()
            Else
                Try
                    .ExportToPdf(FName)
                Catch ex As Exception
                End Try
            End If
        End With
        Logs("Subsidiary Ledger", "Print", String.Format("[SENSITIVE] Print Subsidiary Ledger of {0} with Account Number {1}", lblBorrower.Text.Replace("*", ""), lblAccountNumber.TextAlignment), "", "", "", "")
    End Sub

    Private Sub LoadAmortization()
        Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', IF(`No` = '','',FORMAT(InterestIncome,2)) AS 'Interest Income', IF(`No` = '','',FORMAT(RPPD,2)) AS 'RPPD', IF(`No` = '','',FORMAT(PrincipalAllocation,2)) AS 'Principal Allocation', FORMAT(OutstandingPrincipal,2) AS 'Outstanding Principal', FORMAT(Total_RPPD,2) AS 'Total_RPPD', FORMAT(UnearnIncome,2) AS 'Unearn Income', FORMAT(LoansReceivable,2) AS 'Loans Receivable', FORMAT(Penalty,2) AS 'Penalty', FORMAT(PenaltyBalance,2) AS 'Penalty Balance' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber))
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
            GridColumn6.VisibleIndex = 0
            GridColumn10.VisibleIndex = 1
            GridColumn27.VisibleIndex = 2
            GridColumn11.VisibleIndex = 3
            GridColumn12.VisibleIndex = 4
            GridColumn7.VisibleIndex = 5
            GridColumn8.VisibleIndex = 6

            GridColumn6.Width = 22
            GridColumn10.Width = 54
            GridColumn11.Width = 54
            GridColumn12.Width = 54
            GridColumn7.Width = 62
            GridColumn27.Width = 52
            GridColumn8.Width = 62
        End If
        Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, 2), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), "", "", "", "", FormatNumber(T_Penalty, 2), "")
        GridControl2.DataSource = Temp_DT
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

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Amount Paid").ToString = "" Or GridView1.GetFocusedRowCellValue("O.R. No.") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("O.R. No.").ToString.Contains("ACR-") Then
            'A C K N O W L E D G E M E N T   R E C E I P T ***************************************************************************************
            Dim Official As New FrmAcknowledgement
            With Official
                .Tag = 84
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

                Logs("Subsidiary Ledger", "Double Click", "Acknowledgement Receipt", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("O.R. No.")
                .Skip_FilterLoadData = True
                For x As Integer = 1 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Status") = "PENDING" And x < GridView1.FocusedRowHandle Then
                        .btnCheck.Enabled = False
                        .btnApprove.Enabled = False
                        .btnModify.Enabled = False
                        .btnDelete.Enabled = False
                        .btnDisapprove.Enabled = False
                    End If
                Next
                If .ShowDialog = DialogResult.OK Then
                    LoadLedger()
                End If
                .Dispose()
            End With
            'A C K N O W L E D G E M E N T   R E C E I P T ***************************************************************************************
        ElseIf GridView1.GetFocusedRowCellValue("O.R. No.").ToString.Contains("OR-") Then
            'O F F I C I A L   R E C E I P T ***************************************************************************************
            Dim Official As New FrmOfficialReceipt
            With Official
                .Tag = 99
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

                Logs("Subsidiary Ledger", "Double Click", "Official Receipt", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("O.R. No.").ToString.Replace(" [Discount]", "")
                .Skip_FilterLoadData = True
                For x As Integer = 1 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Status") = "PENDING" And x < GridView1.FocusedRowHandle Then
                        .btnCheck.Enabled = False
                        .btnApprove.Enabled = False
                        .btnModify.Enabled = False
                        .btnDelete.Enabled = False
                        .btnDisapprove.Enabled = False
                    End If
                Next
                If .ShowDialog = DialogResult.OK Then
                    LoadLedger()
                End If
                .Dispose()
            End With
            'O F F I C I A L   R E C E I P T ***************************************************************************************
        ElseIf GridView1.GetFocusedRowCellValue("O.R. No.").ToString.Contains("JV-") Then
            'J O U R N A L   V O U C H E R ***************************************************************************************
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

                Logs("Subsidiary Ledger", "Double Click", "Journal Voucher", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("O.R. No.")
                .Skip_FilterLoadData = True
                For x As Integer = 1 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Status") = "PENDING" And x < GridView1.FocusedRowHandle Then
                        .btnCheck.Enabled = False
                        .btnApprove.Enabled = False
                        .btnModify.Enabled = False
                        .btnDelete.Enabled = False
                        .btnDisapprove.Enabled = False
                    End If
                Next
                If .ShowDialog = DialogResult.OK Then
                    LoadLedger()
                End If
                .Dispose()
            End With
            'J O U R N A L   V O U C H E R ***************************************************************************************
        ElseIf GridView1.GetFocusedRowCellValue("O.R. No.").ToString.Contains("CV-") Then
            'C H E C K   V O U C H E R ***************************************************************************************
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

                Logs("Subsidiary Ledger", "Double Click", "Check Voucher", "", "", "", "")
                .From_GeneralLedger = True
                .AccountNumber = GridView1.GetFocusedRowCellValue("O.R. No.")
                .Skip_FilterLoadData = True
                For x As Integer = 1 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Status") = "PENDING" And x < GridView1.FocusedRowHandle Then
                        .btnCheck.Enabled = False
                        .btnApprove.Enabled = False
                        .btnModify.Enabled = False
                        .btnDelete.Enabled = False
                        .btnDisapprove.Enabled = False
                    End If
                Next
                If .ShowDialog = DialogResult.OK Then
                    LoadLedger()
                End If
                .Dispose()
            End With
            'C H E C K   V O U C H E R ***************************************************************************************
        ElseIf GridView1.GetFocusedRowCellValue("O.R. No.").ToString.Contains("AR-") Then
            'A C C O U N T S   R E C E I V A B L E ***************************************************************************************
            Dim AR As New FrmAccountsReceivable
            With AR
                .Tag = 90
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

                Logs("Subsidiary Ledger", "Check", "Accounts Receivable", "", "", "", "")
                .From_GL = True
                .Skip_FilterLoadData = True
                .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("O.R. No.")
                .Skip_FilterLoadData = True
                For x As Integer = 1 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Status") = "PENDING" And x < GridView1.FocusedRowHandle Then
                        .btnCheck.Enabled = False
                        .btnApprove.Enabled = False
                        .btnModify.Enabled = False
                        .btnDelete.Enabled = False
                        .btnDisapprove.Enabled = False
                    End If
                Next
                If .ShowDialog = DialogResult.OK Then
                    LoadLedger()
                End If
                .Dispose()
            End With
            'A C C O U N T S   R E C E I V A B L E ***************************************************************************************
        ElseIf GridView1.GetFocusedRowCellValue("O.R. No.").ToString.Contains("Waive") Then
            If MsgBoxYes("Do you want to cancel this waived penalty/rppd?") = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE ORNum = '{0}' AND ReferenceN = '{1}';", GridView1.GetFocusedRowCellValue("O.R. No."), CreditNumber))
                FrmSOA.CbxCreditApplication_SelectedIndexChanged(sender, e)
                Logs("Subsidiary Ledger", "Double Click", "Cancel Waived Penalty/RPPD", "", "", "", "")
                MsgBox("Successfully Cancelled!", MsgBoxStyle.Information, "Info")
                LoadLedger()
            End If
        End If
    End Sub

    Private Sub LoadCompanyMode()
        If Prev_CompanyMode = CompanyMode Then
            Exit Sub
        Else
            Prev_CompanyMode = CompanyMode
        End If
        If CompanyMode = 0 Then
            LabelX37.Text = "Interest :"
            GridColumn12.Caption = "Interest"
            LabelX41.Visible = False
            lblRPPD.Visible = False
            LabelX40.Visible = False
            lblMR.Visible = False

            GridColumn14.Visible = False
            GridColumn25.Visible = False
            GridColumn19.Visible = False

            GridColumn11.Visible = False
            If GridColumn27.Visible Then
                If GridView2.RowCount > 9 Then
                    GridColumn6.Width = 22 + 4
                    GridColumn10.Width = 54 + 10
                    GridColumn12.Width = 54 + 10
                    GridColumn7.Width = 62 + 10
                    GridColumn27.Width = 52 + 10
                    GridColumn8.Width = 62 + 10
                Else
                    GridColumn6.Width = 22 + 8
                    GridColumn10.Width = 54 + 12
                    GridColumn12.Width = 54 + 12
                    GridColumn7.Width = 62 + 12
                    GridColumn27.Width = 52 + 12
                    GridColumn8.Width = 62 + 12
                End If
            Else
                If GridView2.RowCount > 9 Then
                    GridColumn6.Width = 27 + 8
                    GridColumn10.Width = 57 + 10
                    GridColumn12.Width = 69 + 17
                    GridColumn7.Width = 69 + 17
                    GridColumn8.Width = 69 + 17
                Else
                    GridColumn6.Width = 30 + 8
                    GridColumn10.Width = 60 + 10
                    GridColumn12.Width = 72 + 18
                    GridColumn7.Width = 72 + 18
                    GridColumn8.Width = 72 + 18
                End If
            End If

            GridColumn9.Width = 65 + 24
            GridColumn13.Width = 65 + 24
            GridColumn24.Width = 65 + 24
            GridColumn15.Width = 65 + 24
            GridColumn16.Width = 65 + 24

            GridColumn17.Width = 65 + 13
            GridColumn18.Width = 65 + 13
            GridColumn20.Width = 65 + 13
            GridColumn21.Width = 70 + 13
            GridColumn22.Width = 70 + 13
            lblFaceAmount.Text = FormatNumber(CDbl(CreditDT(0)("AmountApplied")) + CDbl(CreditDT(0)("Interest")), 2)
            lblGMA.Text = FormatNumber(CreditDT(0)("GMA") - CreditDT(0)("Rebate"), 2)
        Else
            LabelX37.Text = "UDI :"
            GridColumn12.Caption = "UDI"
            LabelX41.Visible = True
            lblRPPD.Visible = True
            LabelX40.Visible = True
            lblMR.Visible = True

            GridColumn14.Visible = True
            GridColumn25.Visible = True
            GridColumn19.Visible = True
            GridColumn14.VisibleIndex = 7
            GridColumn25.VisibleIndex = 8
            GridColumn19.VisibleIndex = 13

            GridColumn11.Visible = True
            If GridColumn27.Visible Then
                If GridView2.RowCount > 9 Then
                    GridColumn6.Width = 22
                    GridColumn10.Width = 54
                    GridColumn11.Width = 54
                    GridColumn12.Width = 54
                    GridColumn7.Width = 62
                    GridColumn27.Width = 52
                    GridColumn8.Width = 62
                Else
                    GridColumn6.Width = 22
                    GridColumn10.Width = 54 + 2
                    GridColumn11.Width = 54 + 2
                    GridColumn12.Width = 54 + 2
                    GridColumn7.Width = 62 + 2
                    GridColumn27.Width = 52 + 2
                    GridColumn8.Width = 62 + 2
                End If
            Else
                If GridView2.RowCount > 9 Then
                    GridColumn6.Width = 27
                    GridColumn10.Width = 57
                    GridColumn11.Width = 69
                    GridColumn12.Width = 69
                    GridColumn7.Width = 69
                    GridColumn8.Width = 69
                Else
                    GridColumn6.Width = 30
                    GridColumn10.Width = 60
                    GridColumn11.Width = 72
                    GridColumn12.Width = 72
                    GridColumn7.Width = 72
                    GridColumn8.Width = 72
                End If
            End If

            GridColumn9.Width = 65
            GridColumn13.Width = 65
            GridColumn24.Width = 65
            GridColumn15.Width = 65
            GridColumn16.Width = 65

            GridColumn17.Width = 65
            GridColumn18.Width = 65
            GridColumn20.Width = 65
            GridColumn21.Width = 70
            GridColumn22.Width = 70
            If CreditDT.Rows.Count > 0 Then
                lblFaceAmount.Text = FormatNumber(CreditDT(0)("Face_Amount"), 2)
                lblGMA.Text = FormatNumber(CreditDT(0)("GMA"), 2)
            Else
                lblFaceAmount.Text = FormatNumber(0, 2)
                lblGMA.Text = FormatNumber(0, 2)
            End If
        End If
    End Sub

    Private Sub Timer_Date_Tick(sender As Object, e As EventArgs) Handles Timer_Date.Tick
        LoadCompanyMode()
    End Sub

    Private Sub BtnCVNumber_Click(sender As Object, e As EventArgs) Handles btnCVNumber.Click
        If btnCVNumber.Text = "" Then
            MsgBox("Can't find this CV Number.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

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

                Logs("Subsidiary Ledger", "Check Voucher", "Check Voucher", "", "", "", "")
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

                Logs("Subsidiary Ledger", "Journal Voucher", "Journal Voucher", "", "", "", "")
                .From_GL = True
                .GL_DocumentNumber = btnCVNumber.Text
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnSurrender_Click(sender As Object, e As EventArgs) Handles btnSurrender.Click
        Dim DateResult As String = ""
        Dim DateResult_DT As DataTable
        If Mortgage_ID = 1 Then
            DateResult_DT = DataSource(String.Format("SELECT ID FROM collateral_ve WHERE CreditNumber = '{0}' AND Surrendered = 0 AND `status` = 'ACTIVE';", CreditNumber))
        Else
            DateResult_DT = DataSource(String.Format("SELECT ID FROM collateral_ve WHERE CreditNumber = '{0}' AND Surrendered = 0 AND `status` = 'ACTIVE';", CreditNumber))
        End If
        If DateResult_DT.Rows.Count > 0 Then
            If Mortgage_ID = 1 Then
                DateResult = DataObject(String.Format("SELECT appraise_date FROM appraise_ve WHERE appraise = 'Credit Investigation' AND credit_number = '{0}' AND `status` = 'ACTIVE' ORDER BY appraise_date DESC LIMIT 1;", CreditNumber))
            Else
                DateResult = DataObject(String.Format("SELECT appraise_date FROM appraise_re WHERE appraise = 'Credit Investigation' AND credit_number = '{0}' AND `status` = 'ACTIVE' ORDER BY appraise_date DESC LIMIT 1;", CreditNumber))
            End If
            If DateResult = "" Then
                MsgBox("Account does not have a record in appraisal, please appraise the collateral first so that it can be transferred to ROPOA.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        ElseIf CreditDT(0)("Loan_Type") = "MIGRATED" Then
            MsgBox("Account is MIGRATED and does not have a record in appraisal, please appraise the collateral first so that it can be transferred to ROPOA.", MsgBoxStyle.Information, "Info")
            Exit Sub
        Else
            MsgBox("No ROPA to surrender!", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If DateDiff(DateInterval.Day, CDate(DateResult), Date.Now) > 30 Then
            If MsgBox(String.Format("{0} Day(s) ago since last appraise for this Collateral, would you like to proceed?", DateDiff(DateInterval.Day, CDate(DateResult), Date.Now)), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Else
                Exit Sub
            End If
        End If
        Dim Msg As String = "Are you sure you want to surrender the collateral?"
        If Mortgage_ID = 2 Then
            Msg = "Are you sure you want to Extrajudicial Foreclose the collateral?"
        End If
        If MsgBoxYes(Msg) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Dim JV As New FrmJournalVoucher
            With JV
                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
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
                Logs("Subsidiary Ledger", "Surrender", Reason, "", "", "", "")

                .From_Ledger = True
                .MortgageID = Mortgage_ID
                .CheckAmount = GridView1.GetRowCellValue(GridView1.RowCount - 1, "Principal B")
                .BankID = BankID
                .cbxPayee.Tag = ID
                .txtReferenceNumber.Text = CreditNumber
                .txtReferenceNumber.Tag = CreditNumber
                .rExplanation.Tag = Reason
                If .ShowDialog = DialogResult.OK Then
                    'UPDATE CREDIT APPLICATION
                    'SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'CLOSED' WHERE CreditNumber = '{0}';", CreditNumber)
                    'DataSource(SQL)
                    LoadLedger()
                    MsgBox("Please wait for the approval of the Journal Voucher.", MsgBoxStyle.Information, "Info")
                End If
            End With
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblBorrower.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT remarks FROM accounting_entry WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID")))
            If GridView1.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks for this ledger from '{1}' to '{0}'?", GridView1.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE accounting_entry SET remarks = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Remarks")))
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Sub BtnValidate_Click(sender As Object, e As EventArgs) Handles btnValidate.Click
        If ComparePosition(SpecialAccess(2), True) Or CompareDepartment(SpecialAccessDepartment(2), True) Then
            MsgBox(mBox_SpecialAccess, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim Schedule As New FrmMigratedApplication
        With Schedule
            .btnManual.Visible = True
            .From_OfficialReceipt = True
            .ProductID = CreditDT(0)("product_id")
            .dtpAvailedV2.Value = CreditDT(0)("Released")
            .v_dAmountApplied = CreditDT(0)("AmountApplied")
            .v_iTerms_C = CreditDT(0)("Terms")
            .v_dInterest_T = CreditDT(0)("Interest_Rate")
            .v_dRPPDRate_T = CreditDT(0)("RPPD_Rate")
            .v_dtpAvailed = CreditDT(0)("Released")
            .v_dtpFDD = CreditDT(0)("FDD")
            .v_dMR_C = CreditDT(0)("Rebate")

            .v_dPA_C = CreditDT(0)("AmountApplied")
            .v_dUDI_C = CreditDT(0)("Interest")
            .v_dRPPD_C = CreditDT(0)("RPPD")
            .txtCreditNumber.Text = CreditDT(0)("CreditNumber")
            .iAccount_2.Text = lblAccountNumber.Text
            .cbxBorrower.Tag = lblBorrower.Text.Replace("***", "")
            .lblTitle.Text = "AMORTIZATION SCHEDULE"
            .vSave = True
            If .ShowDialog() = DialogResult.OK Then
                Call FrmAccountLedger_Load(sender, e)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnMonatorium_Click(sender As Object, e As EventArgs) Handles btnMonatorium.Click
        If MsgBoxYes("Are you sure you want to set this account for moratorium?") = MsgBoxResult.Yes Then
            Dim Monatorium As New FrmMonatorium
            With Monatorium
                .Original_Amortization = GridControl2.DataSource
                .CreditNumber = CreditNumber
                .Borrower = CreditDT(0)("FullN").ToUpper
                If CreditDT(0)("Product_Payment").ToString = "Daily" Or CreditDT(0)("Product_Payment").ToString = "Day" Then
                    .Daily = True
                    .Weekly = False
                    .Bimonthly = False
                ElseIf CreditDT(0)("Product_Payment").ToString = "Weekly" Or CreditDT(0)("Product_Payment").ToString = "Week" Then
                    .Daily = False
                    .Weekly = True
                    .Bimonthly = False
                ElseIf CreditDT(0)("Product_Payment").ToString = "Bimonthly" Or CreditDT(0)("Product_Payment").ToString = "Bimonth" Then
                    .Daily = False
                    .Weekly = False
                    .Bimonthly = True
                ElseIf CreditDT(0)("Product_Payment").ToString = "Monthly" Or CreditDT(0)("Product_Payment").ToString = "Month" Then
                    .Daily = False
                    .Weekly = False
                    .Bimonthly = False
                End If
                If .ShowDialog() = DialogResult.OK Then
                    Call FrmAccountLedger_Load(sender, e)
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub LblBorrower_Click(sender As Object, e As EventArgs) Handles lblBorrower.Click
        If MsgBoxYes("Are you sure you want to open the profile of this borrower?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            If CreditDT(0)("BorrowerID").ToString.Contains("I") Then
                Dim Profile As New FrmBorrower
                With Profile
                    Dim BorrowerP As DataTable = DataSource(String.Format("SELECT *, IF(BusinessID = 0,(SELECT CONCAT(Branch,' [Main]') FROM branch WHERE ID = profile_borrower.Branch_ID),(SELECT BusinessCenter FROM business_center WHERE ID = profile_borrower.BusinessID)) AS 'BusinessCenter' FROM profile_borrower WHERE BorrowerID = '{0}'", CreditDT(0)("BorrowerID")))
                    If BorrowerP.Rows.Count > 0 Then
                        .PanelEx2.Enabled = False
                        .PanelEx4.Enabled = False
                        .PanelEx11.Enabled = False
                        .PanelEx12.Enabled = False
                        .PanelEx13.Enabled = False
                        .PanelEx14.Enabled = False
                        .PanelEx5.Enabled = False
                        .PanelEx8.Enabled = False
                        .cbxMale_S.Tag = ""
                        .cbxFemale_S.Tag = ""
                        .cbxOwned_S.Tag = ""
                        .cbxFree_S.Tag = ""
                        .cbxRented_S.Tag = ""
                        .cbxCasual_S.Tag = ""
                        .cbxTemporary_S.Tag = ""
                        .cbxPermanent_S.Tag = ""
                        .btnExisting_B.Enabled = False
                        .ID = BorrowerP(0)("ID")
                        .TotalImage = BorrowerP(0)("Attach")
                        .btnAttach.Enabled = True
                        .txtBorrowerID.Text = CreditDT(0)("BorrowerID")
                        .txtBorrowerID.Tag = CreditDT(0)("BorrowerID")
                        .CbxPrefix_B.Text = BorrowerP(0)("Prefix_B")
                        .CbxPrefix_B.Tag = BorrowerP(0)("Prefix_B")
                        .TxtFirstN_B.Text = BorrowerP(0)("FirstN_B")
                        .TxtFirstN_B.Tag = BorrowerP(0)("FirstN_B")
                        .TxtMiddleN_B.Text = BorrowerP(0)("MiddleN_B")
                        .TxtMiddleN_B.Tag = BorrowerP(0)("MiddleN_B")
                        .TxtLastN_B.Text = BorrowerP(0)("LastN_B")
                        .TxtLastN_B.Tag = BorrowerP(0)("LastN_B")
                        .cbxSuffix_B.Text = BorrowerP(0)("Suffix_B")
                        .cbxSuffix_B.Tag = BorrowerP(0)("Suffix_B")
                        .txtNoC_B.Text = BorrowerP(0)("NoC_B")
                        .txtNoC_B.Tag = BorrowerP(0)("NoC_B")
                        .txtStreetC_B.Text = BorrowerP(0)("StreetC_B")
                        .txtStreetC_B.Tag = BorrowerP(0)("StreetC_B")
                        .txtBarangayC_B.Text = BorrowerP(0)("BarangayC_B")
                        .txtBarangayC_B.Tag = BorrowerP(0)("BarangayC_B")
                        .cbxAddressC_B.Text = BorrowerP(0)("AddressC_B")
                        .cbxAddressC_B.Tag = BorrowerP(0)("AddressC_B")
                        .txtNoP_B.Text = BorrowerP(0)("NoP_B")
                        .txtNoP_B.Tag = BorrowerP(0)("NoP_B")
                        .txtStreetP_B.Text = BorrowerP(0)("StreetP_B")
                        .txtStreetP_B.Tag = BorrowerP(0)("StreetP_B")
                        .txtBarangayP_B.Text = BorrowerP(0)("BarangayP_B")
                        .txtBarangayP_B.Tag = BorrowerP(0)("BarangayP_B")
                        .cbxAddressP_B.Text = BorrowerP(0)("AddressP_B")
                        .cbxAddressP_B.Tag = BorrowerP(0)("AddressP_B")
                        If BorrowerP(0)("Birth_B") = "0001-01-01" Or BorrowerP(0)("Birth_B") = "" Then
                            .DtpBirth_B.CustomFormat = ""
                            .DtpBirth_B.Tag = ""
                        Else
                            .DtpBirth_B.CustomFormat = "MMMM dd, yyyy"
                            .DtpBirth_B.Text = BorrowerP(0)("Birth_B")
                            .DtpBirth_B.Tag = BorrowerP(0)("Birth_B")
                        End If
                        .cbxPlaceBirth_B.Text = BorrowerP(0)("PlaceBirth_B")
                        .cbxPlaceBirth_B.Tag = BorrowerP(0)("PlaceBirth_B")
                        If BorrowerP(0)("Gender_B") = "Male" Then
                            .cbxMale_B.Checked = True
                        ElseIf BorrowerP(0)("Gender_B") = "Female" Then
                            .cbxFemale_B.Checked = True
                        End If
                        .cbxMale_B.Tag = BorrowerP(0)("Gender_B")
                        .cbxFemale_B.Tag = BorrowerP(0)("Gender_B")
                        If BorrowerP(0)("Civil_B") = "Single" Then
                            .cbxSingle_B.Checked = True
                        ElseIf BorrowerP(0)("Civil_B") = "Married" Then
                            .cbxMarried_B.Checked = True
                        ElseIf BorrowerP(0)("Civil_B") = "Separated" Then
                            .cbxSeparated_B.Checked = True
                        ElseIf BorrowerP(0)("Civil_B") = "Widowed" Then
                            .cbxWidowed_B.Checked = True
                        End If
                        .cbxSingle_B.Tag = BorrowerP(0)("Civil_B")
                        .cbxMarried_B.Tag = BorrowerP(0)("Civil_B")
                        .cbxSeparated_B.Tag = BorrowerP(0)("Civil_B")
                        .cbxWidowed_B.Tag = BorrowerP(0)("Civil_B")
                        .cbxCitizenship_B.Text = BorrowerP(0)("Citizenship_B")
                        .cbxCitizenship_B.Tag = BorrowerP(0)("Citizenship_B")
                        .txtTIN_B.Text = BorrowerP(0)("TIN_B")
                        .txtTIN_B.Tag = BorrowerP(0)("TIN_B")
                        .txtTelephone_B.Text = BorrowerP(0)("Telephone_B")
                        .txtTelephone_B.Tag = BorrowerP(0)("Telephone_B")
                        .txtSSS_B.Text = BorrowerP(0)("SSS_B")
                        .txtSSS_B.Tag = BorrowerP(0)("SSS_B")
                        .txtMobile_B.Text = BorrowerP(0)("Mobile_B")
                        .txtMobile_B.Tag = BorrowerP(0)("Mobile_B")
                        .txtEmail_B.Text = BorrowerP(0)("Email_B")
                        .txtEmail_B.Tag = BorrowerP(0)("Email_B")
                        If BorrowerP(0)("House_B") = "Owned" Then
                            .cbxOwned_B.Checked = True
                        ElseIf BorrowerP(0)("House_B") = "Free" Then
                            .cbxFree_B.Checked = True
                        ElseIf BorrowerP(0)("House_B") = "Rented" Then
                            .cbxRented_B.Checked = True
                            .dRent_B.Value = BorrowerP(0)("Rent_B")
                        End If
                        .cbxOwned_B.Tag = BorrowerP(0)("House_B")
                        .cbxFree_B.Tag = BorrowerP(0)("House_B")
                        .cbxRented_B.Tag = BorrowerP(0)("House_B")
                        .dRent_B.Tag = BorrowerP(0)("Rent_B")
                        Try
                            Using TempPB As New DevExpress.XtraEditors.PictureEdit
                                TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, BorrowerP(0)("branch_code"), CreditDT(0)("BorrowerID"), "Borrower.jpg"))
                                ResizeImages(TempPB.Image.Clone, .pb_B, 650, 500)
                            End Using
                        Catch ex As Exception
                        End Try
                        .cbxEmployer_B.Text = BorrowerP(0)("Employer_B")
                        .cbxEmployer_B.Tag = BorrowerP(0)("Employer_B")
                        .txtEmployerAddress_B.Text = BorrowerP(0)("EmployerAddress_B")
                        .txtEmployerAddress_B.Tag = BorrowerP(0)("EmployerAddress_B")
                        .txtEmployerTelephone_B.Text = BorrowerP(0)("EmployerTelephone_B")
                        .txtEmployerTelephone_B.Tag = BorrowerP(0)("EmployerTelephone_B")
                        .cbxPosition_B.Text = BorrowerP(0)("Position_B")
                        .cbxPosition_B.Tag = BorrowerP(0)("Position_B")
                        If BorrowerP(0)("EmploymentStat_B") = "Casual" Then
                            .cbxCasual_B.Checked = True
                        ElseIf BorrowerP(0)("EmploymentStat_B") = "Temporary" Then
                            .cbxTemporary_B.Checked = True
                        ElseIf BorrowerP(0)("EmploymentStat_B") = "Permanent" Then
                            .cbxPermanent_B.Checked = True
                        End If
                        .cbxCasual_B.Tag = BorrowerP(0)("EmploymentStat_B")
                        .cbxTemporary_B.Tag = BorrowerP(0)("EmploymentStat_B")
                        .cbxPermanent_B.Tag = BorrowerP(0)("EmploymentStat_B")
                        .dtpHired_B.Text = BorrowerP(0)("Hired_B")
                        .dtpHired_B.Tag = BorrowerP(0)("Hired_B")
                        .txtSupervisor_B.Text = BorrowerP(0)("Supervisor_B")
                        .txtSupervisor_B.Tag = BorrowerP(0)("Supervisor_B")
                        .dMonthly_B.Value = BorrowerP(0)("Monthly_B")
                        .dMonthly_B.Tag = BorrowerP(0)("Monthly_B")
                        .txtBusinessName_B.Text = BorrowerP(0)("BusinessName_B")
                        .txtBusinessName_B.Tag = BorrowerP(0)("BusinessName_B")
                        .txtBusinessAddress_B.Text = BorrowerP(0)("BusinessAddress_B")
                        .txtBusinessAddress_B.Tag = BorrowerP(0)("BusinessAddress_B")
                        .txtBusinessTelephone_B.Text = BorrowerP(0)("BusinessTelephone_B")
                        .txtBusinessTelephone_B.Tag = BorrowerP(0)("BusinessTelephone_B")
                        .cbxNatureBusiness_B.Text = BorrowerP(0)("NatureBusiness_B")
                        .cbxNatureBusiness_B.Tag = BorrowerP(0)("NatureBusiness_B")

                        .cbxNatureBusiness_B2.SetEditValue(DataObject(String.Format("SELECT GROUP_CONCAT(Industry_ID SEPARATOR ';') FROM profile_borrower_industry WHERE `status` = 'ACTIVE' AND BorrowerID = '{0}' AND `Type` = 'Borrower'", CreditDT(0)("BorrowerID"))))

                        .iYrsOperation_B.Value = BorrowerP(0)("YrsOperation_B")
                        .iYrsOperation_B.Tag = BorrowerP(0)("YrsOperation_B")
                        .dBusinessIncome_B.Value = BorrowerP(0)("BusinessIncome_B")
                        .dBusinessIncome_B.Tag = BorrowerP(0)("BusinessIncome_B")
                        .iNoEmployees_B.Value = BorrowerP(0)("NoEmployees_B")
                        .iNoEmployees_B.Tag = BorrowerP(0)("NoEmployees_B")
                        .dCapital_B.Value = BorrowerP(0)("Capital_B")
                        .dCapital_B.Tag = BorrowerP(0)("Capital_B")
                        .txtArea_B.Text = BorrowerP(0)("Area_B")
                        .txtArea_B.Tag = BorrowerP(0)("Area_B")
                        .dtpExpiry_B.Text = BorrowerP(0)("Expiry_B")
                        .dtpExpiry_B.Tag = BorrowerP(0)("Expiry_B")
                        .iOutlet_B.Value = BorrowerP(0)("Outlet_B")
                        .iOutlet_B.Tag = BorrowerP(0)("Outlet_B")
                        .txtOtherIncome_B.Text = BorrowerP(0)("OtherIncome_B")
                        .txtOtherIncome_B.Tag = BorrowerP(0)("OtherIncome_B")
                        .dOtherIncome_B.Value = BorrowerP(0)("OtherIncome_B-Amount")
                        .dOtherIncome_B.Tag = BorrowerP(0)("OtherIncome_B-Amount")

                        .txtCreditor_1.Text = BorrowerP(0)("Creditor_1")
                        .txtCreditor_1.Tag = BorrowerP(0)("Creditor_1")
                        .txtNatureLoan_1.Text = BorrowerP(0)("NatureLoan_1")
                        .txtNatureLoan_1.Tag = BorrowerP(0)("NatureLoan_1")
                        .dAmountGranted_1.Value = BorrowerP(0)("AmountGranted_1")
                        .dAmountGranted_1.Tag = BorrowerP(0)("AmountGranted_1")
                        .dTerm_1.Value = BorrowerP(0)("Term_1")
                        .dTerm_1.Tag = BorrowerP(0)("Term_1")
                        .dBalance_1.Value = BorrowerP(0)("Balance_1")
                        .dBalance_1.Tag = BorrowerP(0)("Balance_1")
                        .txtCreditRemarks_1.Text = BorrowerP(0)("CreditRemarks_1")
                        .txtCreditRemarks_1.Tag = BorrowerP(0)("CreditRemarks_1")
                        .txtCreditor_2.Text = BorrowerP(0)("Creditor_2")
                        .txtCreditor_2.Tag = BorrowerP(0)("Creditor_2")
                        .txtNatureLoan_2.Text = BorrowerP(0)("NatureLoan_2")
                        .txtNatureLoan_2.Tag = BorrowerP(0)("NatureLoan_2")
                        .dAmountGranted_2.Value = BorrowerP(0)("AmountGranted_2")
                        .dAmountGranted_2.Tag = BorrowerP(0)("AmountGranted_2")
                        .dTerm_2.Value = BorrowerP(0)("Term_2")
                        .dTerm_2.Tag = BorrowerP(0)("Term_2")
                        .dBalance_2.Value = BorrowerP(0)("Balance_2")
                        .dBalance_2.Tag = BorrowerP(0)("Balance_2")
                        .txtCreditRemarks_2.Text = BorrowerP(0)("CreditRemarks_2")
                        .txtCreditRemarks_2.Tag = BorrowerP(0)("CreditRemarks_2")
                        .txtCreditor_3.Text = BorrowerP(0)("Creditor_3")
                        .txtCreditor_3.Tag = BorrowerP(0)("Creditor_3")
                        .txtNatureLoan_3.Text = BorrowerP(0)("NatureLoan_3")
                        .txtNatureLoan_3.Tag = BorrowerP(0)("NatureLoan_3")
                        .dAmountGranted_3.Value = BorrowerP(0)("AmountGranted_3")
                        .dAmountGranted_3.Tag = BorrowerP(0)("AmountGranted_3")
                        .dTerm_3.Value = BorrowerP(0)("Term_3")
                        .dTerm_3.Tag = BorrowerP(0)("Term_3")
                        .dBalance_3.Value = BorrowerP(0)("Balance_3")
                        .dBalance_3.Tag = BorrowerP(0)("Balance_3")
                        .txtCreditRemarks_3.Text = BorrowerP(0)("CreditRemarks_3")
                        .txtCreditRemarks_3.Tag = BorrowerP(0)("CreditRemarks_3")
                        .txtBank_1.Text = BorrowerP(0)("Bank_1")
                        .txtBank_1.Tag = BorrowerP(0)("Bank_1")
                        .txtBranch_1.Text = BorrowerP(0)("Branch_1")
                        .txtBranch_1.Tag = BorrowerP(0)("Branch_1")
                        If BorrowerP(0)("AccountT_1") = "SA" Then
                            .cbxSA_1.Checked = True
                        ElseIf BorrowerP(0)("AccountT_1") = "CA" Then
                            .cbxCA_1.Checked = True
                        End If
                        .cbxSA_1.Tag = BorrowerP(0)("AccountT_1")
                        .cbxCA_1.Tag = BorrowerP(0)("AccountT_1")
                        .txtSA_1.Text = BorrowerP(0)("SA_1")
                        .txtSA_1.Tag = BorrowerP(0)("SA_1")
                        .dAverageBalance_1.Value = BorrowerP(0)("AverageBalance_1")
                        .dAverageBalance_1.Tag = BorrowerP(0)("AverageBalance_1")
                        .dPresentBalance_1.Value = BorrowerP(0)("PresentBalance_1")
                        .dPresentBalance_1.Tag = BorrowerP(0)("PresentBalance_1")
                        .txtOpened_1.Text = BorrowerP(0)("Opened_1")
                        .txtOpened_1.Tag = BorrowerP(0)("Opened_1")
                        .txtBankRemarks_1.Text = BorrowerP(0)("BankRemarks_1")
                        .txtBankRemarks_1.Tag = BorrowerP(0)("BankRemarks_1")
                        .txtBank_2.Text = BorrowerP(0)("Bank_2")
                        .txtBank_2.Tag = BorrowerP(0)("Bank_2")
                        .txtBranch_2.Text = BorrowerP(0)("Branch_2")
                        .txtBranch_2.Tag = BorrowerP(0)("Branch_2")
                        If BorrowerP(0)("AccountT_2") = "SA" Then
                            .cbxSA_2.Checked = True
                        ElseIf BorrowerP(0)("AccountT_2") = "CA" Then
                            .cbxCA_2.Checked = True
                        End If
                        .cbxSA_2.Tag = BorrowerP(0)("AccountT_2")
                        .cbxCA_2.Tag = BorrowerP(0)("AccountT_2")
                        .txtSA_2.Text = BorrowerP(0)("SA_2")
                        .txtSA_2.Tag = BorrowerP(0)("SA_2")
                        .dAverageBalance_2.Value = BorrowerP(0)("AverageBalance_2")
                        .dAverageBalance_2.Tag = BorrowerP(0)("AverageBalance_2")
                        .dPresentBalance_2.Value = BorrowerP(0)("PresentBalance_2")
                        .dPresentBalance_2.Tag = BorrowerP(0)("PresentBalance_2")
                        .txtOpened_2.Text = BorrowerP(0)("Opened_2")
                        .txtOpened_2.Tag = BorrowerP(0)("Opened_2")
                        .txtBankRemarks_2.Text = BorrowerP(0)("BankRemarks_2")
                        .txtBankRemarks_2.Tag = BorrowerP(0)("BankRemarks_2")
                        .txtBank_3.Text = BorrowerP(0)("Bank_3")
                        .txtBank_3.Tag = BorrowerP(0)("Bank_3")
                        .txtBranch_3.Text = BorrowerP(0)("Branch_3")
                        .txtBranch_3.Tag = BorrowerP(0)("Branch_3")
                        If BorrowerP(0)("AccountT_3") = "SA" Then
                            .cbxSA_3.Checked = True
                        ElseIf BorrowerP(0)("AccountT_3") = "CA" Then
                            .cbxCA_3.Checked = True
                        End If
                        .cbxSA_3.Tag = BorrowerP(0)("AccountT_3")
                        .cbxCA_3.Tag = BorrowerP(0)("AccountT_3")
                        .txtSA_3.Text = BorrowerP(0)("SA_3")
                        .txtSA_3.Tag = BorrowerP(0)("SA_3")
                        .dAverageBalance_3.Value = BorrowerP(0)("AverageBalance_3")
                        .dAverageBalance_3.Tag = BorrowerP(0)("AverageBalance_3")
                        .dPresentBalance_3.Value = BorrowerP(0)("PresentBalance_3")
                        .dPresentBalance_3.Tag = BorrowerP(0)("PresentBalance_3")
                        .txtOpened_3.Text = BorrowerP(0)("Opened_3")
                        .txtOpened_3.Tag = BorrowerP(0)("Opened_3")
                        .txtBankRemarks_3.Text = BorrowerP(0)("BankRemarks_3")
                        .txtBankRemarks_3.Tag = BorrowerP(0)("BankRemarks_3")
                        .txtLocation_1.Text = BorrowerP(0)("Location_1")
                        .txtLocation_1.Tag = BorrowerP(0)("Location_1")
                        .txtTCT_1.Text = BorrowerP(0)("TCT_1")
                        .txtTCT_1.Tag = BorrowerP(0)("TCT_1")
                        .dArea_1.Value = BorrowerP(0)("Area_1")
                        .dArea_1.Tag = BorrowerP(0)("Area_1")
                        .txtAcquired_1.Text = BorrowerP(0)("Acquired_1")
                        .txtAcquired_1.Tag = BorrowerP(0)("Acquired_1")
                        .txtPropertiesRemarks_1.Text = BorrowerP(0)("PropertiesRemarks_1")
                        .txtPropertiesRemarks_1.Tag = BorrowerP(0)("PropertiesRemarks_1")
                        .txtLocation_2.Text = BorrowerP(0)("Location_2")
                        .txtLocation_2.Tag = BorrowerP(0)("Location_2")
                        .txtTCT_2.Text = BorrowerP(0)("TCT_2")
                        .txtTCT_2.Tag = BorrowerP(0)("TCT_2")
                        .dArea_2.Value = BorrowerP(0)("Area_2")
                        .dArea_2.Tag = BorrowerP(0)("Area_2")
                        .txtAcquired_2.Text = BorrowerP(0)("Acquired_2")
                        .txtAcquired_2.Tag = BorrowerP(0)("Acquired_2")
                        .txtPropertiesRemarks_2.Text = BorrowerP(0)("PropertiesRemarks_2")
                        .txtPropertiesRemarks_2.Tag = BorrowerP(0)("PropertiesRemarks_2")
                        .txtLocation_3.Text = BorrowerP(0)("Location_3")
                        .txtLocation_3.Tag = BorrowerP(0)("Location_3")
                        .txtTCT_3.Text = BorrowerP(0)("TCT_3")
                        .txtTCT_3.Tag = BorrowerP(0)("TCT_3")
                        .dArea_3.Value = BorrowerP(0)("Area_3")
                        .dArea_3.Tag = BorrowerP(0)("Area_3")
                        .txtAcquired_3.Text = BorrowerP(0)("Acquired_3")
                        .txtAcquired_3.Tag = BorrowerP(0)("Acquired_3")
                        .txtPropertiesRemarks_3.Text = BorrowerP(0)("PropertiesRemarks_3")
                        .txtPropertiesRemarks_3.Tag = BorrowerP(0)("PropertiesRemarks_3")
                        .txtVehicle_1.Text = BorrowerP(0)("Vehicle_1")
                        .txtVehicle_1.Tag = BorrowerP(0)("Vehicle_1")
                        .dtpYear_1.Text = BorrowerP(0)("Year_1")
                        .dtpYear_1.Tag = BorrowerP(0)("Year_1")
                        .txtWhomAcquired_1.Text = BorrowerP(0)("WhomAcquired_1")
                        .txtWhomAcquired_1.Tag = BorrowerP(0)("WhomAcquired_1")
                        .txtWhenAcquired_1.Text = BorrowerP(0)("WhenAcquired_1")
                        .txtWhenAcquired_1.Tag = BorrowerP(0)("WhenAcquired_1")
                        .txtVehicleRemarks_1.Text = BorrowerP(0)("VehicleRemarks_1")
                        .txtVehicleRemarks_1.Tag = BorrowerP(0)("VehicleRemarks_1")
                        .txtVehicle_2.Text = BorrowerP(0)("Vehicle_2")
                        .txtVehicle_2.Tag = BorrowerP(0)("Vehicle_2")
                        .dtpYear_2.Text = BorrowerP(0)("Year_2")
                        .dtpYear_2.Tag = BorrowerP(0)("Year_2")
                        .txtWhomAcquired_2.Text = BorrowerP(0)("WhomAcquired_2")
                        .txtWhomAcquired_2.Tag = BorrowerP(0)("WhomAcquired_2")
                        .txtWhenAcquired_2.Text = BorrowerP(0)("WhenAcquired_2")
                        .txtWhenAcquired_2.Tag = BorrowerP(0)("WhenAcquired_2")
                        .txtVehicleRemarks_2.Text = BorrowerP(0)("VehicleRemarks_2")
                        .txtVehicleRemarks_2.Tag = BorrowerP(0)("VehicleRemarks_2")
                        .txtVehicle_3.Text = BorrowerP(0)("Vehicle_3")
                        .txtVehicle_3.Tag = BorrowerP(0)("Vehicle_3")
                        .dtpYear_3.Text = BorrowerP(0)("Year_3")
                        .dtpYear_3.Tag = BorrowerP(0)("Year_3")
                        .txtWhomAcquired_3.Text = BorrowerP(0)("WhomAcquired_3")
                        .txtWhomAcquired_3.Tag = BorrowerP(0)("WhomAcquired_3")
                        .txtWhenAcquired_3.Text = BorrowerP(0)("WhenAcquired_3")
                        .txtWhenAcquired_3.Tag = BorrowerP(0)("WhenAcquired_3")
                        .txtVehicleRemarks_3.Text = BorrowerP(0)("VehicleRemarks_3")
                        .txtVehicleRemarks_3.Tag = BorrowerP(0)("VehicleRemarks_3")
                        .txtHomeAppliances_1.Text = BorrowerP(0)("HomeAppliances_1")
                        .txtHomeAppliances_1.Tag = BorrowerP(0)("HomeAppliances_1")
                        .txtHomeAppliances_2.Text = BorrowerP(0)("HomeAppliances_2")
                        .txtHomeAppliances_2.Tag = BorrowerP(0)("HomeAppliances_2")
                        .txtReference_1.Text = BorrowerP(0)("Reference_1")
                        .txtReference_1.Tag = BorrowerP(0)("Reference_1")
                        .txtReferenceAddress_1.Text = BorrowerP(0)("ReferenceAddress_1")
                        .txtReferenceAddress_1.Tag = BorrowerP(0)("ReferenceAddress_1")
                        .txtReferenceContact_1.Text = BorrowerP(0)("ReferenceContact_1")
                        .txtReferenceContact_1.Tag = BorrowerP(0)("ReferenceContact_1")
                        .txtReference_2.Text = BorrowerP(0)("Reference_2")
                        .txtReference_2.Tag = BorrowerP(0)("Reference_2")
                        .txtReferenceAddress_2.Text = BorrowerP(0)("ReferenceAddress_2")
                        .txtReferenceAddress_2.Tag = BorrowerP(0)("ReferenceAddress_2")
                        .txtReferenceContact_2.Text = BorrowerP(0)("ReferenceContact_2")
                        .txtReferenceContact_2.Tag = BorrowerP(0)("ReferenceContact_2")
                        .txtReference_3.Text = BorrowerP(0)("Reference_3")
                        .txtReference_3.Tag = BorrowerP(0)("Reference_3")
                        .txtReferenceAddress_3.Text = BorrowerP(0)("ReferenceAddress_3")
                        .txtReferenceAddress_3.Tag = BorrowerP(0)("ReferenceAddress_3")
                        .txtReferenceContact_3.Text = BorrowerP(0)("ReferenceContact_3")
                        .txtReferenceContact_3.Tag = BorrowerP(0)("ReferenceContact_3")
                        .txtCertificateNo.Text = BorrowerP(0)("CertificateNo")
                        .txtCertificateNo.Tag = BorrowerP(0)("CertificateNo")
                        .txtPlaceIssue.Text = BorrowerP(0)("PlaceIssue")
                        .txtPlaceIssue.Tag = BorrowerP(0)("PlaceIssue")
                        .dtpIssue.Text = BorrowerP(0)("Issue")
                        .dtpIssue.Tag = BorrowerP(0)("Issue")
                        .cbxAgent.Tag = If(BorrowerP(0)("Agent") = "", "No", "Yes")
                        .cbxAgent.Checked = If(BorrowerP(0)("Agent") = "", False, True)
                        .cbxAgentName.Text = BorrowerP(0)("Agent")
                        .cbxAgentName.Tag = BorrowerP(0)("Agent")
                        .txtAgentContact.Text = BorrowerP(0)("AgentNo")
                        .txtAgentContact.Tag = BorrowerP(0)("AgentNo")
                        .cbxMarketing.Checked = If(BorrowerP(0)("Marketing") = "", False, True)
                        .cbxMarketing.Tag = If(BorrowerP(0)("Marketing") = "", "No", "Yes")
                        .cbxMarketingName.Text = BorrowerP(0)("Marketing")
                        .cbxMarketingName.Tag = BorrowerP(0)("Marketing")
                        .txtMarketingContact.Text = BorrowerP(0)("MarketingNo")
                        .txtMarketingContact.Tag = BorrowerP(0)("MarketingNo")
                        .cbxWalkIn.Checked = If(BorrowerP(0)("WalkIn") = "", False, True)
                        .cbxWalkIn.Tag = If(BorrowerP(0)("WalkIn") = "", "No", "Yes")
                        .cbxWalkInType.Text = BorrowerP(0)("WalkIn")
                        .cbxWalkInType.Tag = BorrowerP(0)("WalkIn")
                        .txtWalkInOthers.Text = BorrowerP(0)("WalkIn_Specify")
                        .txtWalkInOthers.Tag = BorrowerP(0)("WalkIn_Specify")
                        .cbxDealer.Checked = If(BorrowerP(0)("Dealer") = "", False, True)
                        .cbxDealer.Tag = If(BorrowerP(0)("Dealer") = "", "No", "Yes")
                        .cbxDealerName.Text = BorrowerP(0)("Dealer")
                        .cbxDealerName.Tag = BorrowerP(0)("Dealer")
                        .txtDealersContact.Text = BorrowerP(0)("DealerNo")
                        .txtDealersContact.Tag = BorrowerP(0)("DealerNo")
                        .cbxBusinessCenter.Text = BorrowerP(0)("BusinessCenter")
                        .cbxBusinessCenter.Tag = BorrowerP(0)("BusinessCenter")

                        '*** I D E N T I F I C A T I O N ***
                        Dim BorrowerID As DataTable = DataSource(String.Format("SELECT * FROM profile_borrowerid WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND ID_Type = 'B'", CreditDT(0)("BorrowerID")))
                        If BorrowerID.Rows.Count > 0 Then
                            .GSIS = BorrowerID(0)("GSIS")
                            .PhilHealth = BorrowerID(0)("PhilHealth")
                            .Senior = BorrowerID(0)("Senior")
                            .UMID = BorrowerID(0)("UMID")
                            .SEC = BorrowerID(0)("SEC")
                            .DTI = BorrowerID(0)("DTI")
                            .CDA = BorrowerID(0)("CDA")
                            .Cooperative = BorrowerID(0)("Cooperative")
                            .Drivers = BorrowerID(0)("Drivers")
                            .dDrivers = BorrowerID(0)("dDrivers")
                            .VIN = BorrowerID(0)("VIN")
                            .dVIN = BorrowerID(0)("dVIN")
                            .Passport = BorrowerID(0)("Passport")
                            .dPassport = BorrowerID(0)("dPassport")
                            .PRC = BorrowerID(0)("PRC")
                            .dPRC = BorrowerID(0)("dPRC")
                            .NBI = BorrowerID(0)("NBI")
                            .dNBI = BorrowerID(0)("dNBI")
                            .Police = BorrowerID(0)("Police")
                            .dPolice = BorrowerID(0)("dPolice")
                            .Postal = BorrowerID(0)("Postal")
                            .dPostal = BorrowerID(0)("dPostal")
                            .Barangay = BorrowerID(0)("Barangay")
                            .dBarangay = BorrowerID(0)("dBarangay")
                            .OWWA = BorrowerID(0)("OWWA")
                            .dOWWA = BorrowerID(0)("dOWWA")
                            .OFW = BorrowerID(0)("OFW")
                            .dOFW = BorrowerID(0)("dOFW")
                            .Seaman = BorrowerID(0)("Seaman")
                            .dSeaman = BorrowerID(0)("dSeaman")
                            .PNP = BorrowerID(0)("PNP")
                            .dPNP = BorrowerID(0)("dPNP")
                            .AFP = BorrowerID(0)("AFP")
                            .dAFP = BorrowerID(0)("dAFP")
                            .HDMF = BorrowerID(0)("HDMF")
                            .dHDMF = BorrowerID(0)("dHDMF")
                            .PWD = BorrowerID(0)("PWD")
                            .dPWD = BorrowerID(0)("dPWD")
                            .DSWD = BorrowerID(0)("DSWD")
                            .dDSWD = BorrowerID(0)("dDSWD")
                            .ACR = BorrowerID(0)("ACR")
                            .dACR = BorrowerID(0)("dACR")
                            .DTI_Business = BorrowerID(0)("DTI_Business")
                            .dDTI_Business = BorrowerID(0)("dDTI_Business")
                            .IBP = BorrowerID(0)("IBP")
                            .dIBP = BorrowerID(0)("dIBP")
                            .FireArms = BorrowerID(0)("FireArms")
                            .dFireArms = BorrowerID(0)("dFireArms")
                            .Government = BorrowerID(0)("Government")
                            .dGovernment = BorrowerID(0)("dGovernment")
                            .Diplomat = BorrowerID(0)("Diplomat")
                            .dDiplomat = BorrowerID(0)("dDiplomat")
                            .National = BorrowerID(0)("National")
                            .dNational = BorrowerID(0)("dNational")
                            .Work = BorrowerID(0)("Work")
                            .dWork = BorrowerID(0)("dWork")
                            .GOCC = BorrowerID(0)("GOCC")
                            .dGOCC = BorrowerID(0)("dGOCC")
                            .PLRA = BorrowerID(0)("PLRA")
                            .dPLRA = BorrowerID(0)("dPLRA")
                            .Major = BorrowerID(0)("Major")
                            .dMajor = BorrowerID(0)("dMajor")
                            .Media = BorrowerID(0)("Media")
                            .dMedia = BorrowerID(0)("dMedia")
                            .Student = BorrowerID(0)("Student")
                            .dStudent = BorrowerID(0)("dStudent")
                            .SIRV = BorrowerID(0)("SIRV")
                            .dSIRV = BorrowerID(0)("dSIRV")

                            .TotalImage_TIN = BorrowerID(0)("Attach_TIN")
                            .TotalImage_SSS = BorrowerID(0)("Attach_SSS")
                            .TotalImage_GSIS = BorrowerID(0)("Attach_GSIS")
                            .TotalImage_PhilHealth = BorrowerID(0)("Attach_PhilHealth")
                            .TotalImage_Senior = BorrowerID(0)("Attach_Senior")
                            .TotalImage_UMID = BorrowerID(0)("Attach_UMID")
                            .TotalImage_SEC = BorrowerID(0)("Attach_SEC")
                            .TotalImage_DTI = BorrowerID(0)("Attach_DTI")
                            .TotalImage_CDA = BorrowerID(0)("Attach_CDA")
                            .TotalImage_Cooperative = BorrowerID(0)("Attach_Cooperative")
                            .TotalImage_Drivers = BorrowerID(0)("Attach_Drivers")
                            .TotalImage_VIN = BorrowerID(0)("Attach_VIN")
                            .TotalImage_Passport = BorrowerID(0)("Attach_Passport")
                            .TotalImage_PRC = BorrowerID(0)("Attach_PRC")
                            .TotalImage_NBI = BorrowerID(0)("Attach_NBI")
                            .TotalImage_Police = BorrowerID(0)("Attach_Police")
                            .TotalImage_Postal = BorrowerID(0)("Attach_Postal")
                            .TotalImage_Barangay = BorrowerID(0)("Attach_Barangay")
                            .TotalImage_OWWA = BorrowerID(0)("Attach_OWWA")
                            .TotalImage_OFW = BorrowerID(0)("Attach_OFW")
                            .TotalImage_Seaman = BorrowerID(0)("Attach_Seaman")
                            .TotalImage_PNP = BorrowerID(0)("Attach_PNP")
                            .TotalImage_AFP = BorrowerID(0)("Attach_AFP")
                            .TotalImage_HDMF = BorrowerID(0)("Attach_HDMF")
                            .TotalImage_PWD = BorrowerID(0)("Attach_PWD")
                            .TotalImage_DSWD = BorrowerID(0)("Attach_DSWD")
                            .TotalImage_ACR = BorrowerID(0)("Attach_ACR")
                            .TotalImage_DTI_Business = BorrowerID(0)("Attach_DTI_Business")
                            .TotalImage_IBP = BorrowerID(0)("Attach_IBP")
                            .TotalImage_FireArms = BorrowerID(0)("Attach_FireArms")
                            .TotalImage_Government = BorrowerID(0)("Attach_Government")
                            .TotalImage_Diplomat = BorrowerID(0)("Attach_Diplomat")
                            .TotalImage_National = BorrowerID(0)("Attach_National")
                            .TotalImage_Work = BorrowerID(0)("Attach_Work")
                            .TotalImage_GOCC = BorrowerID(0)("Attach_GOCC")
                            .TotalImage_PLRA = BorrowerID(0)("Attach_PLRA")
                            .TotalImage_Major = BorrowerID(0)("Attach_Major")
                            .TotalImage_Media = BorrowerID(0)("Attach_Media")
                            .TotalImage_Student = BorrowerID(0)("Attach_Student")
                            .TotalImage_SIRV = BorrowerID(0)("Attach_SIRV")
                        End If
                        '*** I D E N T I F I C A T I O N ***

                        '*** D E P E N D E N T S ***
                        Dim BorrowerD As DataTable = DataSource(String.Format("SELECT * FROM profile_dependent WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE'", CreditDT(0)("BorrowerID")))
                        If BorrowerD.Rows.Count > 0 Then
                            .DependentID_1 = BorrowerD(0)("ID")
                            .Prefix_1 = BorrowerD(0)("Prefix_D")
                            .FirstN_1 = BorrowerD(0)("FirstN_D")
                            .MiddleN_1 = BorrowerD(0)("MiddleN_D")
                            .LastN_1 = BorrowerD(0)("LastN_D")
                            .Suffix_1 = BorrowerD(0)("Suffix_D")
                            .Birth_1 = BorrowerD(0)("Birth_D")
                            .Grade_1 = BorrowerD(0)("Grade_D")
                            .School_1 = BorrowerD(0)("School_D")
                            .SchoolAddress_1 = BorrowerD(0)("SchoolAddress_D")
                            If BorrowerD.Rows.Count > 1 Then
                                .DependentID_2 = BorrowerD(1)("ID")
                                .Prefix_2 = BorrowerD(1)("Prefix_D")
                                .FirstN_2 = BorrowerD(1)("FirstN_D")
                                .MiddleN_2 = BorrowerD(1)("MiddleN_D")
                                .LastN_2 = BorrowerD(1)("LastN_D")
                                .Suffix_2 = BorrowerD(1)("Suffix_D")
                                .Birth_2 = BorrowerD(1)("Birth_D")
                                .Grade_2 = BorrowerD(1)("Grade_D")
                                .School_2 = BorrowerD(1)("School_D")
                                .SchoolAddress_2 = BorrowerD(1)("SchoolAddress_D")
                                If BorrowerD.Rows.Count > 2 Then
                                    .DependentID_3 = BorrowerD(2)("ID")
                                    .Prefix_3 = BorrowerD(2)("Prefix_D")
                                    .FirstN_3 = BorrowerD(2)("FirstN_D")
                                    .MiddleN_3 = BorrowerD(2)("MiddleN_D")
                                    .LastN_3 = BorrowerD(2)("LastN_D")
                                    .Suffix_3 = BorrowerD(2)("Suffix_D")
                                    .Birth_3 = BorrowerD(2)("Birth_D")
                                    .Grade_3 = BorrowerD(2)("Grade_D")
                                    .School_3 = BorrowerD(2)("School_D")
                                    .SchoolAddress_3 = BorrowerD(2)("SchoolAddress_D")
                                    If BorrowerD.Rows.Count > 3 Then
                                        .DependentID_4 = BorrowerD(3)("ID")
                                        .Prefix_4 = BorrowerD(3)("Prefix_D")
                                        .FirstN_4 = BorrowerD(3)("FirstN_D")
                                        .MiddleN_4 = BorrowerD(3)("MiddleN_D")
                                        .LastN_4 = BorrowerD(3)("LastN_D")
                                        .Suffix_4 = BorrowerD(3)("Suffix_D")
                                        .Birth_4 = BorrowerD(3)("Birth_D")
                                        .Grade_4 = BorrowerD(3)("Grade_D")
                                        .School_4 = BorrowerD(3)("School_D")
                                        .SchoolAddress_4 = BorrowerD(3)("SchoolAddress_D")
                                    End If
                                End If
                            End If
                        End If
                        '*** D E P E N D E N T S ***

                        If BorrowerP(0)("FirstN_S").Trim <> "" And BorrowerP(0)("LastN_S").Trim <> "" And (BorrowerP(0)("Civil_B") = "Married" Or BorrowerP(0)("Civil_B") = "Separated") Then
                            Dim SpouseP As DataTable = DataSource(String.Format("SELECT * FROM profile_spouse WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE'", CreditDT(0)("BorrowerID")))
                            If SpouseP.Rows.Count > 0 Then
                                .SpouseID = SpouseP(0)("SpouseID")
                                .CbxPrefix_S.Text = SpouseP(0)("Prefix_S")
                                .CbxPrefix_S.Tag = SpouseP(0)("Prefix_S")
                                .TxtFirstN_S.Text = SpouseP(0)("FirstN_S")
                                .TxtFirstN_S.Tag = SpouseP(0)("FirstN_S")
                                .TxtMiddleN_S.Text = SpouseP(0)("MiddleN_S")
                                .TxtMiddleN_S.Tag = SpouseP(0)("MiddleN_S")
                                .TxtLastN_S.Text = SpouseP(0)("LastN_S")
                                .TxtLastN_S.Tag = SpouseP(0)("LastN_S")
                                .cbxSuffix_S.Text = SpouseP(0)("Suffix_S")
                                .cbxSuffix_S.Tag = SpouseP(0)("Suffix_S")
                                .CbxPrefix_M.Text = SpouseP(0)("Prefix_M")
                                .CbxPrefix_M.Tag = SpouseP(0)("Prefix_M")
                                .TxtFirstN_M.Text = SpouseP(0)("FirstN_M")
                                .TxtFirstN_M.Tag = SpouseP(0)("FirstN_M")
                                .TxtMiddleN_M.Text = SpouseP(0)("MiddleN_M")
                                .TxtMiddleN_M.Tag = SpouseP(0)("MiddleN_M")
                                .TxtLastN_M.Text = SpouseP(0)("LastN_M")
                                .TxtLastN_M.Tag = SpouseP(0)("LastN_M")
                                .cbxSuffix_M.Text = SpouseP(0)("Suffix_M")
                                .cbxSuffix_M.Tag = SpouseP(0)("Suffix_M")
                                .txtNoC_S.Text = SpouseP(0)("NoC_S")
                                .txtNoC_S.Tag = SpouseP(0)("NoC_S")
                                .txtStreetC_S.Text = SpouseP(0)("StreetC_S")
                                .txtStreetC_S.Tag = SpouseP(0)("StreetC_S")
                                .txtBarangayC_S.Text = SpouseP(0)("BarangayC_S")
                                .txtBarangayC_S.Tag = SpouseP(0)("BarangayC_S")
                                .cbxAddressC_S.Text = SpouseP(0)("AddressC_S")
                                .cbxAddressC_S.Tag = SpouseP(0)("AddressC_S")
                                .txtNoP_S.Text = SpouseP(0)("NoP_S")
                                .txtNoP_S.Tag = SpouseP(0)("NoP_S")
                                .txtStreetP_S.Text = SpouseP(0)("StreetP_S")
                                .txtStreetP_S.Tag = SpouseP(0)("StreetP_S")
                                .txtBarangayP_S.Text = SpouseP(0)("BarangayP_S")
                                .txtBarangayP_S.Tag = SpouseP(0)("BarangayP_S")
                                .cbxAddressP_S.Text = SpouseP(0)("AddressP_S")
                                .cbxAddressP_S.Tag = SpouseP(0)("AddressP_S")
                                If SpouseP(0)("Birth_S") = "0001-01-01" Or SpouseP(0)("Birth_S") = "" Then
                                    .DtpBirth_S.CustomFormat = ""
                                    .DtpBirth_S.Tag = ""
                                Else
                                    .DtpBirth_S.CustomFormat = "MMMM dd, yyyy"
                                    .DtpBirth_S.Text = SpouseP(0)("Birth_S")
                                    .DtpBirth_S.Tag = SpouseP(0)("Birth_S")
                                End If
                                .cbxPlaceBirth_S.Text = SpouseP(0)("PlaceBirth_S")
                                .cbxPlaceBirth_S.Tag = SpouseP(0)("PlaceBirth_S")
                                If SpouseP(0)("Gender_S") = "Male" Then
                                    .cbxMale_S.Checked = True
                                ElseIf SpouseP(0)("Gender_S") = "Female" Then
                                    .cbxFemale_S.Checked = True
                                End If
                                .cbxMale_S.Tag = SpouseP(0)("Gender_S")
                                .cbxFemale_S.Tag = SpouseP(0)("Gender_S")
                                .txtCitizenship_S.Text = SpouseP(0)("Citizenship_S")
                                .txtCitizenship_S.Tag = SpouseP(0)("Citizenship_S")
                                .txtTIN_S.Text = SpouseP(0)("TIN_S")
                                .txtTIN_S.Tag = SpouseP(0)("TIN_S")
                                .txtTelephone_S.Text = SpouseP(0)("Telephone_S")
                                .txtTelephone_S.Tag = SpouseP(0)("Telephone_S")
                                .txtSSS_S.Text = SpouseP(0)("SSS_S")
                                .txtSSS_S.Tag = SpouseP(0)("SSS_S")
                                .txtMobile_S.Text = SpouseP(0)("Mobile_S")
                                .txtMobile_S.Tag = SpouseP(0)("Mobile_S")
                                .txtEmail_S.Text = SpouseP(0)("Email_S")
                                .txtEmail_S.Tag = SpouseP(0)("Email_S")
                                If SpouseP(0)("House_S") = "Owned" Then
                                    .cbxOwned_S.Checked = True
                                ElseIf SpouseP(0)("House_S") = "Free" Then
                                    .cbxFree_S.Checked = True
                                ElseIf SpouseP(0)("House_S") = "Rented" Then
                                    .cbxRented_S.Checked = True
                                    .dRent_S.Value = SpouseP(0)("Rent_S")
                                End If
                                .cbxOwned_S.Tag = SpouseP(0)("House_S")
                                .cbxFree_S.Tag = SpouseP(0)("House_S")
                                .cbxRented_S.Tag = SpouseP(0)("House_S")
                                .dRent_S.Tag = SpouseP(0)("Rent_S")
                                Try
                                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                                        TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, BorrowerP(0)("branch_code"), CreditDT(0)("BorrowerID"), "Spouse.jpg"))
                                        ResizeImages(TempPB.Image.Clone, .pb_S, 650, 500)
                                    End Using
                                Catch ex As Exception
                                End Try
                                .cbxEmployer_S.Text = SpouseP(0)("Employer_S")
                                .cbxEmployer_S.Tag = SpouseP(0)("Employer_S")
                                .txtEmployerAddress_S.Text = SpouseP(0)("EmployerAddress_S")
                                .txtEmployerAddress_S.Tag = SpouseP(0)("EmployerAddress_S")
                                .txtEmployerTelephone_S.Text = SpouseP(0)("EmployerTelephone_S")
                                .txtEmployerTelephone_S.Tag = SpouseP(0)("EmployerTelephone_S")
                                .cbxPosition_S.Text = SpouseP(0)("Position_S")
                                .cbxPosition_S.Tag = SpouseP(0)("Position_S")
                                If SpouseP(0)("EmploymentStat_S") = "Casual" Then
                                    .cbxCasual_S.Checked = True
                                ElseIf SpouseP(0)("EmploymentStat_S") = "Temporary" Then
                                    .cbxTemporary_S.Checked = True
                                ElseIf SpouseP(0)("EmploymentStat_S") = "Permanent" Then
                                    .cbxPermanent_S.Checked = True
                                End If
                                .cbxCasual_S.Tag = SpouseP(0)("EmploymentStat_S")
                                .cbxTemporary_S.Tag = SpouseP(0)("EmploymentStat_S")
                                .cbxPermanent_S.Tag = SpouseP(0)("EmploymentStat_S")
                                .dtpHired_S.Text = SpouseP(0)("Hired_S")
                                .dtpHired_S.Tag = SpouseP(0)("Hired_S")
                                .txtSupervisor_S.Text = SpouseP(0)("Supervisor_S")
                                .txtSupervisor_S.Tag = SpouseP(0)("Supervisor_S")
                                .dMonthly_S.Value = SpouseP(0)("Monthly_S")
                                .dMonthly_S.Tag = SpouseP(0)("Monthly_S")
                                .txtBusinessName_S.Text = SpouseP(0)("BusinessName_S")
                                .txtBusinessName_S.Tag = SpouseP(0)("BusinessName_S")
                                .txtBusinessAddress_S.Text = SpouseP(0)("BusinessAddress_S")
                                .txtBusinessAddress_S.Tag = SpouseP(0)("BusinessAddress_S")
                                .txtBusinessTelephone_S.Text = SpouseP(0)("BusinessTelephone_S")
                                .txtBusinessTelephone_S.Tag = SpouseP(0)("BusinessTelephone_S")
                                .cbxNatureBusiness_S.Text = SpouseP(0)("NatureBusiness_S")
                                .cbxNatureBusiness_S.Tag = SpouseP(0)("NatureBusiness_S")

                                .cbxNatureBusiness_S2.SetEditValue(DataObject(String.Format("SELECT GROUP_CONCAT(Industry_ID SEPARATOR ';') FROM profile_borrower_industry WHERE `status` = 'ACTIVE' AND BorrowerID = '{0}' AND `Type` = 'Spouse'", CreditDT(0)("BorrowerID"))))

                                .iYrsOperation_S.Value = SpouseP(0)("YrsOperation_S")
                                .iYrsOperation_S.Tag = SpouseP(0)("YrsOperation_S")
                                .dBusinessIncome_S.Value = SpouseP(0)("BusinessIncome_S")
                                .dBusinessIncome_S.Tag = SpouseP(0)("BusinessIncome_S")
                                .iNoEmployees_S.Value = SpouseP(0)("NoEmployees_S")
                                .iNoEmployees_S.Tag = SpouseP(0)("NoEmployees_S")
                                .dCapital_S.Value = SpouseP(0)("Capital_S")
                                .dCapital_S.Tag = SpouseP(0)("Capital_S")
                                .txtArea_S.Text = SpouseP(0)("Area_S")
                                .txtArea_S.Tag = SpouseP(0)("Area_S")
                                .dtpExpiry_S.Text = SpouseP(0)("Expiry_S")
                                .dtpExpiry_S.Tag = SpouseP(0)("Expiry_S")
                                .iOutlet_S.Value = SpouseP(0)("Outlet_S")
                                .iOutlet_S.Tag = SpouseP(0)("Outlet_S")
                                .txtOtherIncome_S.Text = SpouseP(0)("OtherIncome_S")
                                .txtOtherIncome_S.Tag = SpouseP(0)("OtherIncome_S")
                                .dOtherIncome_S.Value = SpouseP(0)("OtherIncome_S-Amount")
                                .dOtherIncome_S.Tag = SpouseP(0)("OtherIncome_S-Amount")

                                '*** I D E N T I F I C A T I O N ***
                                Dim BorrowerID_S As DataTable = DataSource(String.Format("SELECT * FROM profile_borrowerid WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE' AND ID_Type = 'S'", CreditDT(0)("BorrowerID")))
                                If BorrowerID_S.Rows.Count > 0 Then
                                    .GSIS_S = BorrowerID_S(0)("GSIS")
                                    .PhilHealth_S = BorrowerID_S(0)("PhilHealth")
                                    .Senior_S = BorrowerID_S(0)("Senior")
                                    .UMID_S = BorrowerID_S(0)("UMID")
                                    .SEC_S = BorrowerID_S(0)("SEC")
                                    .DTI_S = BorrowerID_S(0)("DTI")
                                    .CDA_S = BorrowerID_S(0)("CDA")
                                    .Cooperative_S = BorrowerID_S(0)("Cooperative")
                                    .Drivers_S = BorrowerID_S(0)("Drivers")
                                    .dDrivers_S = BorrowerID_S(0)("dDrivers")
                                    .VIN_S = BorrowerID_S(0)("VIN")
                                    .dVIN_S = BorrowerID_S(0)("dVIN")
                                    .Passport_S = BorrowerID_S(0)("Passport")
                                    .dPassport_S = BorrowerID_S(0)("dPassport")
                                    .PRC_S = BorrowerID_S(0)("PRC")
                                    .dPRC_S = BorrowerID_S(0)("dPRC")
                                    .NBI_S = BorrowerID_S(0)("NBI")
                                    .dNBI_S = BorrowerID_S(0)("dNBI")
                                    .Police_S = BorrowerID_S(0)("Police")
                                    .dPolice_S = BorrowerID_S(0)("dPolice")
                                    .Postal_S = BorrowerID_S(0)("Postal")
                                    .dPostal_S = BorrowerID_S(0)("dPostal")
                                    .Barangay_S = BorrowerID_S(0)("Barangay")
                                    .dBarangay_S = BorrowerID_S(0)("dBarangay")
                                    .OWWA_S = BorrowerID_S(0)("OWWA")
                                    .dOWWA_S = BorrowerID_S(0)("dOWWA")
                                    .OFW_S = BorrowerID_S(0)("OFW")
                                    .dOFW_S = BorrowerID_S(0)("dOFW")
                                    .Seaman_S = BorrowerID_S(0)("Seaman")
                                    .dSeaman_S = BorrowerID_S(0)("dSeaman")
                                    .PNP_S = BorrowerID_S(0)("PNP")
                                    .dPNP_S = BorrowerID_S(0)("dPNP")
                                    .AFP_S = BorrowerID_S(0)("AFP")
                                    .dAFP_S = BorrowerID_S(0)("dAFP")
                                    .HDMF_S = BorrowerID_S(0)("HDMF")
                                    .dHDMF_S = BorrowerID_S(0)("dHDMF")
                                    .PWD_S = BorrowerID_S(0)("PWD")
                                    .dPWD_S = BorrowerID_S(0)("dPWD")
                                    .DSWD_S = BorrowerID_S(0)("DSWD")
                                    .dDSWD_S = BorrowerID_S(0)("dDSWD")
                                    .ACR_S = BorrowerID_S(0)("ACR")
                                    .dACR_S = BorrowerID_S(0)("dACR")
                                    .DTI_Business_S = BorrowerID_S(0)("DTI_Business")
                                    .dDTI_Business_S = BorrowerID_S(0)("dDTI_Business")
                                    .IBP_S = BorrowerID_S(0)("IBP")
                                    .dIBP_S = BorrowerID_S(0)("dIBP")
                                    .FireArms_S = BorrowerID_S(0)("FireArms")
                                    .dFireArms_S = BorrowerID_S(0)("dFireArms")
                                    .Government_S = BorrowerID_S(0)("Government")
                                    .dGovernment_S = BorrowerID_S(0)("dGovernment")
                                    .Diplomat_S = BorrowerID_S(0)("Diplomat")
                                    .dDiplomat_S = BorrowerID_S(0)("dDiplomat")
                                    .National_S = BorrowerID_S(0)("National")
                                    .dNational_S = BorrowerID_S(0)("dNational")
                                    .Work_S = BorrowerID_S(0)("Work")
                                    .dWork_S = BorrowerID_S(0)("dWork")
                                    .GOCC_S = BorrowerID_S(0)("GOCC")
                                    .dGOCC_S = BorrowerID_S(0)("dGOCC")
                                    .PLRA_S = BorrowerID_S(0)("PLRA")
                                    .dPLRA_S = BorrowerID_S(0)("dPLRA")
                                    .Major_S = BorrowerID_S(0)("Major")
                                    .dMajor_S = BorrowerID_S(0)("dMajor")
                                    .Media_S = BorrowerID_S(0)("Media")
                                    .dMedia_S = BorrowerID_S(0)("dMedia")
                                    .Student_S = BorrowerID_S(0)("Student")
                                    .dStudent_S = BorrowerID_S(0)("dStudent")
                                    .SIRV_S = BorrowerID_S(0)("SIRV")
                                    .dSIRV_S = BorrowerID_S(0)("dSIRV")

                                    .TotalImage_TIN_S = BorrowerID_S(0)("Attach_TIN")
                                    .TotalImage_SSS_S = BorrowerID_S(0)("Attach_SSS")
                                    .TotalImage_GSIS_S = BorrowerID_S(0)("Attach_GSIS")
                                    .TotalImage_PhilHealth_S = BorrowerID_S(0)("Attach_PhilHealth")
                                    .TotalImage_Senior_S = BorrowerID_S(0)("Attach_Senior")
                                    .TotalImage_UMID_S = BorrowerID_S(0)("Attach_UMID")
                                    .TotalImage_SEC_S = BorrowerID_S(0)("Attach_SEC")
                                    .TotalImage_DTI_S = BorrowerID_S(0)("Attach_DTI")
                                    .TotalImage_CDA_S = BorrowerID_S(0)("Attach_CDA")
                                    .TotalImage_Cooperative_S = BorrowerID_S(0)("Attach_Cooperative")
                                    .TotalImage_Drivers_S = BorrowerID_S(0)("Attach_Drivers")
                                    .TotalImage_VIN_S = BorrowerID_S(0)("Attach_VIN")
                                    .TotalImage_Passport_S = BorrowerID_S(0)("Attach_Passport")
                                    .TotalImage_PRC_S = BorrowerID_S(0)("Attach_PRC")
                                    .TotalImage_NBI_S = BorrowerID_S(0)("Attach_NBI")
                                    .TotalImage_Police_S = BorrowerID_S(0)("Attach_Police")
                                    .TotalImage_Postal_S = BorrowerID_S(0)("Attach_Postal")
                                    .TotalImage_Barangay_S = BorrowerID_S(0)("Attach_Barangay")
                                    .TotalImage_OWWA_S = BorrowerID_S(0)("Attach_OWWA")
                                    .TotalImage_OFW_S = BorrowerID_S(0)("Attach_OFW")
                                    .TotalImage_Seaman_S = BorrowerID_S(0)("Attach_Seaman")
                                    .TotalImage_PNP_S = BorrowerID_S(0)("Attach_PNP")
                                    .TotalImage_AFP_S = BorrowerID_S(0)("Attach_AFP")
                                    .TotalImage_HDMF_S = BorrowerID_S(0)("Attach_HDMF")
                                    .TotalImage_PWD_S = BorrowerID_S(0)("Attach_PWD")
                                    .TotalImage_DSWD_S = BorrowerID_S(0)("Attach_DSWD")
                                    .TotalImage_ACR_S = BorrowerID_S(0)("Attach_ACR")
                                    .TotalImage_DTI_Business_S = BorrowerID_S(0)("Attach_DTI_Business")
                                    .TotalImage_IBP_S = BorrowerID_S(0)("Attach_IBP")
                                    .TotalImage_FireArms_S = BorrowerID_S(0)("Attach_FireArms")
                                    .TotalImage_Government_S = BorrowerID_S(0)("Attach_Government")
                                    .TotalImage_Diplomat_S = BorrowerID_S(0)("Attach_Diplomat")
                                    .TotalImage_National_S = BorrowerID_S(0)("Attach_National")
                                    .TotalImage_Work_S = BorrowerID_S(0)("Attach_Work")
                                    .TotalImage_GOCC_S = BorrowerID_S(0)("Attach_GOCC")
                                    .TotalImage_PLRA_S = BorrowerID_S(0)("Attach_PLRA")
                                    .TotalImage_Major_S = BorrowerID_S(0)("Attach_Major")
                                    .TotalImage_Media_S = BorrowerID_S(0)("Attach_Media")
                                    .TotalImage_Student_S = BorrowerID_S(0)("Attach_Student")
                                    .TotalImage_SIRV_S = BorrowerID_S(0)("Attach_SIRV")
                                End If
                                '*** I D E N T I F I C A T I O N ***
                            End If
                        End If

                        .btnSave.Enabled = False
                        .btnSave_F.Enabled = False
                        If Branch_Code = CreditDT(0)("branch_code") Then
                            .btnModify.Enabled = True
                        Else
                            .btnModify.Enabled = False
                        End If
                        .WindowState = FormWindowState.Normal
                        .FormBorderStyle = FormBorderStyle.FixedDialog
                        .ShowDialog()
                    End If
                End With
            Else
                Dim Corporation As New FrmBorrowerCorp
                With Corporation
                    Dim BorrowerP As DataTable = DataSource(String.Format("SELECT *, IF(BusinessID = 0,(SELECT CONCAT(Branch,' [Main]') FROM branch WHERE ID = profile_corporation.Branch_ID),(SELECT BusinessCenter FROM business_center WHERE ID = profile_corporation.BusinessID)) AS 'BusinessCenter' FROM profile_corporation WHERE BorrowerID = '{0}'", CreditDT(0)("BorrowerID")))
                    If BorrowerP.Rows.Count > 0 Then
                        .PanelEx2.Enabled = False
                        .btnSave.Enabled = False
                        .btnSaveDraft.Enabled = False
                        If Branch_Code = CreditDT(0)("BrancH_Code") Then
                            .btnModify.Enabled = True
                        Else
                            .btnModify.Enabled = False
                        End If
                        .cbxMicro.Tag = ""
                        .cbxSmall.Tag = ""
                        .cbxMedium.Tag = ""
                        .cbxLarge.Tag = ""
                        .ID = BorrowerP(0)("ID")
                        .TotalImage = BorrowerP(0)("Attach")
                        .btnAttach.Enabled = True
                        .txtBorrowerID.Text = CreditDT(0)("BorrowerID")
                        .txtBorrowerID.Tag = CreditDT(0)("BorrowerID")
                        .txtTradeName.Text = BorrowerP(0)("TradeName")
                        .txtTradeName.Tag = BorrowerP(0)("TradeName")
                        .txtNo.Text = BorrowerP(0)("No")
                        .txtNo.Tag = BorrowerP(0)("No")
                        .txtStreet.Text = BorrowerP(0)("Street")
                        .txtStreet.Tag = BorrowerP(0)("Street")
                        .txtBarangay.Text = BorrowerP(0)("Barangay")
                        .txtBarangay.Tag = BorrowerP(0)("Barangay")
                        .cbxAddress.Text = BorrowerP(0)("Address")
                        .cbxAddress.Tag = BorrowerP(0)("Address")
                        .txtTIN.Text = BorrowerP(0)("TIN")
                        .txtTIN.Tag = BorrowerP(0)("TIN")
                        .txtSSS.Text = BorrowerP(0)("SSS")
                        .txtSSS.Tag = BorrowerP(0)("SSS")
                        .txtTelephone.Text = BorrowerP(0)("Telephone")
                        .txtTelephone.Tag = BorrowerP(0)("Telephone")
                        .txtEmail.Text = BorrowerP(0)("Email")
                        .txtEmail.Tag = BorrowerP(0)("Email")
                        .txtFax.Text = BorrowerP(0)("Fax")
                        .txtFax.Tag = BorrowerP(0)("Fax")
                        .txtWebsite.Text = BorrowerP(0)("Website")
                        .txtWebsite.Tag = BorrowerP(0)("Website")
                        .dtpIncorporation.Text = BorrowerP(0)("Incorporation")
                        .dtpIncorporation.Tag = BorrowerP(0)("Incorporation")
                        .iYears.Value = BorrowerP(0)("YearsOperation")
                        .iYears.Tag = BorrowerP(0)("YearsOperation")
                        .iEmployees.Value = BorrowerP(0)("Employees")
                        .iEmployees.Tag = BorrowerP(0)("Employees")
                        If BorrowerP(0)("FirmSize") = "Micro" Then
                            .cbxMicro.Checked = True
                        ElseIf BorrowerP(0)("FirmSize") = "Small" Then
                            .cbxSmall.Checked = True
                        ElseIf BorrowerP(0)("FirmSize") = "Medium" Then
                            .cbxMedium.Checked = True
                        ElseIf BorrowerP(0)("FirmSize") = "Large" Then
                            .cbxLarge.Checked = True
                        End If
                        .cbxMicro.Tag = BorrowerP(0)("FirmSize")
                        .cbxSmall.Tag = BorrowerP(0)("FirmSize")
                        .cbxMedium.Tag = BorrowerP(0)("FirmSize")
                        .cbxLarge.Tag = BorrowerP(0)("FirmSize")
                        .dGross.Value = BorrowerP(0)("Gross")
                        .dGross.Tag = BorrowerP(0)("Gross")
                        .dNet.Value = BorrowerP(0)("Net")
                        .dNet.Tag = BorrowerP(0)("Net")

                        .vPrefix_S1 = BorrowerP(0)("Prefix_S1")
                        .vFirstN_S1 = BorrowerP(0)("FirstN_S1")
                        .vMiddleN_S1 = BorrowerP(0)("MiddleN_S1")
                        .vLastN_S1 = BorrowerP(0)("LastN_S1")
                        .vSuffix_S1 = BorrowerP(0)("Suffix_S1")

                        .vPrefix_S2 = BorrowerP(0)("Prefix_S2")
                        .vFirstN_S2 = BorrowerP(0)("FirstN_S2")
                        .vMiddleN_S2 = BorrowerP(0)("MiddleN_S2")
                        .vLastN_S2 = BorrowerP(0)("LastN_S2")
                        .vSuffix_S2 = BorrowerP(0)("Suffix_S2")

                        .vPrefix_S3 = BorrowerP(0)("Prefix_S3")
                        .vFirstN_S3 = BorrowerP(0)("FirstN_S3")
                        .vMiddleN_S3 = BorrowerP(0)("MiddleN_S3")
                        .vLastN_S3 = BorrowerP(0)("LastN_S3")
                        .vSuffix_S3 = BorrowerP(0)("Suffix_S3")

                        .vPrefix_S4 = BorrowerP(0)("Prefix_S4")
                        .vFirstN_S4 = BorrowerP(0)("FirstN_S4")
                        .vMiddleN_S4 = BorrowerP(0)("MiddleN_S4")
                        .vLastN_S4 = BorrowerP(0)("LastN_S4")
                        .vSuffix_S4 = BorrowerP(0)("Suffix_S4")

                        .CbxPrefix_R1.Text = BorrowerP(0)("Prefix_R1")
                        .CbxPrefix_R1.Tag = BorrowerP(0)("Prefix_R1")
                        If BorrowerP(0)("FirstN_R1") = "" Then
                        Else
                            .btnAttach_R1B.Visible = True
                        End If
                        .TxtFirstN_R1.Text = BorrowerP(0)("FirstN_R1")
                        .TxtFirstN_R1.Tag = BorrowerP(0)("FirstN_R1")
                        .TxtMiddleN_R1.Text = BorrowerP(0)("MiddleN_R1")
                        .TxtMiddleN_R1.Tag = BorrowerP(0)("MiddleN_R1")
                        .TxtLastN_R1.Text = BorrowerP(0)("LastN_R1")
                        .TxtLastN_R1.Tag = BorrowerP(0)("LastN_R1")
                        .cbxSuffix_R1.Text = BorrowerP(0)("Suffix_R1")
                        .cbxSuffix_R1.Tag = BorrowerP(0)("Suffix_R1")
                        .DtpBirth_R1.Text = BorrowerP(0)("Birthdate_R1")
                        .DtpBirth_R1.Tag = BorrowerP(0)("Birthdate_R1")
                        .txtTIN_R1.Text = BorrowerP(0)("TIN_R1")
                        .txtTIN_R1.Tag = BorrowerP(0)("TIN_R1")
                        .txtSSS_R1.Text = BorrowerP(0)("SSS_R1")
                        .txtSSS_R1.Tag = BorrowerP(0)("SSS_R1")
                        .dGMI_R1.Value = BorrowerP(0)("GMI_R1")
                        .dGMI_R1.Tag = BorrowerP(0)("GMI_R1")
                        .dYears_R1.Value = BorrowerP(0)("Years_R1")
                        .dYears_R1.Tag = BorrowerP(0)("Years_R1")
                        .TotalImage_R1 = BorrowerP(0)("Attach_R1")
                        .txtNo_R1.Text = BorrowerP(0)("No_R1")
                        .txtNo_R1.Tag = BorrowerP(0)("No_R1")
                        .txtStreet_R1.Text = BorrowerP(0)("Street_R1")
                        .txtStreet_R1.Tag = BorrowerP(0)("Street_R1")
                        .txtBarangay_R1.Text = BorrowerP(0)("Barangay_R1")
                        .txtBarangay_R1.Tag = BorrowerP(0)("Barangay_R1")
                        .cbxAddress_R1.Text = BorrowerP(0)("Address_R1")
                        .cbxAddress_R1.Tag = BorrowerP(0)("Address_R1")
                        .txtPosition_R1.Text = BorrowerP(0)("Position_R1")
                        .txtPosition_R1.Tag = BorrowerP(0)("Position_R1")
                        .txtContact_R1.Text = BorrowerP(0)("Contact_R1")
                        .txtContact_R1.Tag = BorrowerP(0)("Contact_R1")

                        .CbxPrefix_R2.Text = BorrowerP(0)("Prefix_R2")
                        .CbxPrefix_R2.Tag = BorrowerP(0)("Prefix_R2")
                        If BorrowerP(0)("FirstN_R2") = "" Then
                        Else
                            .btnAttach_R2B.Visible = True
                        End If
                        .TxtFirstN_R2.Text = BorrowerP(0)("FirstN_R2")
                        .TxtFirstN_R2.Tag = BorrowerP(0)("FirstN_R2")
                        .TxtMiddleN_R2.Text = BorrowerP(0)("MiddleN_R2")
                        .TxtMiddleN_R2.Tag = BorrowerP(0)("MiddleN_R2")
                        .TxtLastN_R2.Text = BorrowerP(0)("LastN_R2")
                        .TxtLastN_R2.Tag = BorrowerP(0)("LastN_R2")
                        .cbxSuffix_R2.Text = BorrowerP(0)("Suffix_R2")
                        .cbxSuffix_R2.Tag = BorrowerP(0)("Suffix_R2")
                        .DtpBirth_R2.Text = BorrowerP(0)("Birthdate_R2")
                        .DtpBirth_R2.Tag = BorrowerP(0)("Birthdate_R2")
                        .txtTIN_R2.Text = BorrowerP(0)("TIN_R2")
                        .txtTIN_R2.Tag = BorrowerP(0)("TIN_R2")
                        .txtSSS_R2.Text = BorrowerP(0)("SSS_R2")
                        .txtSSS_R2.Tag = BorrowerP(0)("SSS_R2")
                        .dGMI_R2.Value = BorrowerP(0)("GMI_R2")
                        .dGMI_R2.Tag = BorrowerP(0)("GMI_R2")
                        .dYears_R2.Value = BorrowerP(0)("Years_R2")
                        .dYears_R2.Tag = BorrowerP(0)("Years_R2")
                        .TotalImage_R2 = BorrowerP(0)("Attach_R2")
                        .txtNo_R2.Text = BorrowerP(0)("No_R2")
                        .txtNo_R2.Tag = BorrowerP(0)("No_R2")
                        .txtStreet_R2.Text = BorrowerP(0)("Street_R2")
                        .txtStreet_R2.Tag = BorrowerP(0)("Street_R2")
                        .txtBarangay_R2.Text = BorrowerP(0)("Barangay_R2")
                        .txtBarangay_R2.Tag = BorrowerP(0)("Barangay_R2")
                        .cbxAddress_R2.Text = BorrowerP(0)("Address_R2")
                        .cbxAddress_R2.Tag = BorrowerP(0)("Address_R2")
                        .txtPosition_R2.Text = BorrowerP(0)("Position_R2")
                        .txtPosition_R2.Tag = BorrowerP(0)("Position_R2")
                        .txtContact_R2.Text = BorrowerP(0)("Contact_R2")
                        .txtContact_R2.Tag = BorrowerP(0)("Contact_R2")

                        .CbxPrefix_R3.Text = BorrowerP(0)("Prefix_R3")
                        .CbxPrefix_R3.Tag = BorrowerP(0)("Prefix_R3")
                        If BorrowerP(0)("FirstN_R3") = "" Then
                        Else
                            .btnAttach_R3B.Visible = True
                        End If
                        .TxtFirstN_R3.Text = BorrowerP(0)("FirstN_R3")
                        .TxtFirstN_R3.Tag = BorrowerP(0)("FirstN_R3")
                        .TxtMiddleN_R3.Text = BorrowerP(0)("MiddleN_R3")
                        .TxtMiddleN_R3.Tag = BorrowerP(0)("MiddleN_R3")
                        .TxtLastN_R3.Text = BorrowerP(0)("LastN_R3")
                        .TxtLastN_R3.Tag = BorrowerP(0)("LastN_R3")
                        .cbxSuffix_R3.Text = BorrowerP(0)("Suffix_R3")
                        .cbxSuffix_R3.Tag = BorrowerP(0)("Suffix_R3")
                        .DtpBirth_R3.Text = BorrowerP(0)("Birthdate_R3")
                        .DtpBirth_R3.Tag = BorrowerP(0)("Birthdate_R3")
                        .txtTIN_R3.Text = BorrowerP(0)("TIN_R3")
                        .txtTIN_R3.Tag = BorrowerP(0)("TIN_R3")
                        .txtSSS_R3.Text = BorrowerP(0)("SSS_R3")
                        .txtSSS_R3.Tag = BorrowerP(0)("SSS_R3")
                        .dGMI_R3.Value = BorrowerP(0)("GMI_R3")
                        .dGMI_R3.Tag = BorrowerP(0)("GMI_R3")
                        .dYears_R3.Value = BorrowerP(0)("Years_R3")
                        .dYears_R3.Tag = BorrowerP(0)("Years_R3")
                        .TotalImage_R3 = BorrowerP(0)("Attach_R3")
                        .txtNo_R3.Text = BorrowerP(0)("No_R3")
                        .txtNo_R3.Tag = BorrowerP(0)("No_R3")
                        .txtStreet_R3.Text = BorrowerP(0)("Street_R3")
                        .txtStreet_R3.Tag = BorrowerP(0)("Street_R3")
                        .txtBarangay_R3.Text = BorrowerP(0)("Barangay_R3")
                        .txtBarangay_R3.Tag = BorrowerP(0)("Barangay_R3")
                        .cbxAddress_R3.Text = BorrowerP(0)("Address_R3")
                        .cbxAddress_R3.Tag = BorrowerP(0)("Address_R3")
                        .txtPosition_R3.Text = BorrowerP(0)("Position_R3")
                        .txtPosition_R3.Tag = BorrowerP(0)("Position_R3")
                        .txtContact_R3.Text = BorrowerP(0)("Contact_R3")
                        .txtContact_R3.Tag = BorrowerP(0)("Contact_R3")

                        .CbxPrefix_R4.Text = BorrowerP(0)("Prefix_R4")
                        .CbxPrefix_R4.Tag = BorrowerP(0)("Prefix_R4")
                        If BorrowerP(0)("FirstN_R4") = "" Then
                        Else
                            .btnAttach_R4B.Visible = True
                        End If
                        .TxtFirstN_R4.Text = BorrowerP(0)("FirstN_R4")
                        .TxtFirstN_R4.Tag = BorrowerP(0)("FirstN_R4")
                        .TxtMiddleN_R4.Text = BorrowerP(0)("MiddleN_R4")
                        .TxtMiddleN_R4.Tag = BorrowerP(0)("MiddleN_R4")
                        .TxtLastN_R4.Text = BorrowerP(0)("LastN_R4")
                        .TxtLastN_R4.Tag = BorrowerP(0)("LastN_R4")
                        .cbxSuffix_R4.Text = BorrowerP(0)("Suffix_R4")
                        .cbxSuffix_R4.Tag = BorrowerP(0)("Suffix_R4")
                        .DtpBirth_R4.Text = BorrowerP(0)("Birthdate_R4")
                        .DtpBirth_R4.Tag = BorrowerP(0)("Birthdate_R4")
                        .txtTIN_R4.Text = BorrowerP(0)("TIN_R4")
                        .txtTIN_R4.Tag = BorrowerP(0)("TIN_R4")
                        .txtSSS_R4.Text = BorrowerP(0)("SSS_R4")
                        .txtSSS_R4.Tag = BorrowerP(0)("SSS_R4")
                        .dGMI_R4.Value = BorrowerP(0)("GMI_R4")
                        .dGMI_R4.Tag = BorrowerP(0)("GMI_R4")
                        .dYears_R4.Value = BorrowerP(0)("Years_R4")
                        .dYears_R4.Tag = BorrowerP(0)("Years_R4")
                        .TotalImage_R4 = BorrowerP(0)("Attach_R4")
                        .txtNo_R4.Text = BorrowerP(0)("No_R4")
                        .txtNo_R4.Tag = BorrowerP(0)("No_R4")
                        .txtStreet_R4.Text = BorrowerP(0)("Street_R4")
                        .txtStreet_R4.Tag = BorrowerP(0)("Street_R4")
                        .txtBarangay_R4.Text = BorrowerP(0)("Barangay_R4")
                        .txtBarangay_R4.Tag = BorrowerP(0)("Barangay_R4")
                        .cbxAddress_R4.Text = BorrowerP(0)("Address_R4")
                        .cbxAddress_R4.Tag = BorrowerP(0)("Address_R4")
                        .txtPosition_R4.Text = BorrowerP(0)("Position_R4")
                        .txtPosition_R4.Tag = BorrowerP(0)("Position_R4")
                        .txtContact_R4.Text = BorrowerP(0)("Contact_R4")
                        .txtContact_R4.Tag = BorrowerP(0)("Contact_R4")

                        .CbxPrefix_R5.Text = BorrowerP(0)("Prefix_R5")
                        .CbxPrefix_R5.Tag = BorrowerP(0)("Prefix_R5")
                        If BorrowerP(0)("FirstN_R5") = "" Then
                        Else
                            .btnAttach_R5B.Visible = True
                        End If
                        .TxtFirstN_R5.Text = BorrowerP(0)("FirstN_R5")
                        .TxtFirstN_R5.Tag = BorrowerP(0)("FirstN_R5")
                        .TxtMiddleN_R5.Text = BorrowerP(0)("MiddleN_R5")
                        .TxtMiddleN_R5.Tag = BorrowerP(0)("MiddleN_R5")
                        .TxtLastN_R5.Text = BorrowerP(0)("LastN_R5")
                        .TxtLastN_R5.Tag = BorrowerP(0)("LastN_R5")
                        .cbxSuffix_R5.Text = BorrowerP(0)("Suffix_R5")
                        .cbxSuffix_R5.Tag = BorrowerP(0)("Suffix_R5")
                        .DtpBirth_R5.Text = BorrowerP(0)("Birthdate_R5")
                        .DtpBirth_R5.Tag = BorrowerP(0)("Birthdate_R5")
                        .txtTIN_R5.Text = BorrowerP(0)("TIN_R5")
                        .txtTIN_R5.Tag = BorrowerP(0)("TIN_R5")
                        .txtSSS_R5.Text = BorrowerP(0)("SSS_R5")
                        .txtSSS_R5.Tag = BorrowerP(0)("SSS_R5")
                        .dGMI_R5.Value = BorrowerP(0)("GMI_R5")
                        .dGMI_R5.Tag = BorrowerP(0)("GMI_R5")
                        .dYears_R5.Value = BorrowerP(0)("Years_R5")
                        .dYears_R5.Tag = BorrowerP(0)("Years_R5")
                        .TotalImage_R5 = BorrowerP(0)("Attach_R5")
                        .txtNo_R5.Text = BorrowerP(0)("No_R5")
                        .txtNo_R5.Tag = BorrowerP(0)("No_R5")
                        .txtStreet_R5.Text = BorrowerP(0)("Street_R5")
                        .txtStreet_R5.Tag = BorrowerP(0)("Street_R5")
                        .txtBarangay_R5.Text = BorrowerP(0)("Barangay_R5")
                        .txtBarangay_R5.Tag = BorrowerP(0)("Barangay_R5")
                        .cbxAddress_R5.Text = BorrowerP(0)("Address_R5")
                        .cbxAddress_R5.Tag = BorrowerP(0)("Address_R5")
                        .txtPosition_R5.Text = BorrowerP(0)("Position_R5")
                        .txtPosition_R5.Tag = BorrowerP(0)("Position_R5")
                        .txtContact_R5.Text = BorrowerP(0)("Contact_R5")
                        .txtContact_R5.Tag = BorrowerP(0)("Contact_R5")

                        .txtBank_1.Text = BorrowerP(0)("Bank_1")
                        .txtBank_1.Tag = BorrowerP(0)("Bank_1")
                        .txtBranch_1.Text = BorrowerP(0)("Branch_1")
                        .txtBranch_1.Tag = BorrowerP(0)("Branch_1")
                        If BorrowerP(0)("AccountT_1") = "SA" Then
                            .cbxSA_1.Checked = True
                        ElseIf BorrowerP(0)("AccountT_1") = "CA" Then
                            .cbxCA_1.Checked = True
                        End If
                        .cbxSA_1.Tag = BorrowerP(0)("AccountT_1")
                        .cbxCA_1.Tag = BorrowerP(0)("AccountT_1")
                        .txtSA_1.Text = BorrowerP(0)("SA_1")
                        .txtSA_1.Tag = BorrowerP(0)("SA_1")
                        .dAverageBalance_1.Value = BorrowerP(0)("AverageBalance_1")
                        .dAverageBalance_1.Tag = BorrowerP(0)("AverageBalance_1")
                        .dPresentBalance_1.Value = BorrowerP(0)("PresentBalance_1")
                        .dPresentBalance_1.Tag = BorrowerP(0)("PresentBalance_1")
                        .dtpOpened_1.Text = BorrowerP(0)("Opened_1")
                        .dtpOpened_1.Tag = BorrowerP(0)("Opened_1")
                        .txtBankRemarks_1.Text = BorrowerP(0)("BankRemarks_1")
                        .txtBankRemarks_1.Tag = BorrowerP(0)("BankRemarks_1")

                        .txtBank_2.Text = BorrowerP(0)("Bank_2")
                        .txtBank_2.Tag = BorrowerP(0)("Bank_2")
                        .txtBranch_2.Text = BorrowerP(0)("Branch_2")
                        .txtBranch_2.Tag = BorrowerP(0)("Branch_2")
                        If BorrowerP(0)("AccountT_2") = "SA" Then
                            .cbxSA_2.Checked = True
                        ElseIf BorrowerP(0)("AccountT_2") = "CA" Then
                            .cbxCA_2.Checked = True
                        End If
                        .cbxSA_2.Tag = BorrowerP(0)("AccountT_1")
                        .cbxCA_2.Tag = BorrowerP(0)("AccountT_1")
                        .txtSA_2.Text = BorrowerP(0)("SA_2")
                        .txtSA_2.Tag = BorrowerP(0)("SA_2")
                        .dAverageBalance_2.Value = BorrowerP(0)("AverageBalance_2")
                        .dAverageBalance_2.Tag = BorrowerP(0)("AverageBalance_2")
                        .dPresentBalance_2.Value = BorrowerP(0)("PresentBalance_2")
                        .dPresentBalance_2.Tag = BorrowerP(0)("PresentBalance_2")
                        .dtpOpened_2.Text = BorrowerP(0)("Opened_2")
                        .dtpOpened_2.Tag = BorrowerP(0)("Opened_2")
                        .txtBankRemarks_2.Text = BorrowerP(0)("BankRemarks_2")
                        .txtBankRemarks_2.Tag = BorrowerP(0)("BankRemarks_2")
                        .cbxAgent.Tag = If(BorrowerP(0)("Agent") = "", "No", "Yes")
                        .cbxAgent.Checked = If(BorrowerP(0)("Agent") = "", False, True)
                        .cbxAgentName.Text = BorrowerP(0)("Agent")
                        .cbxAgentName.Tag = BorrowerP(0)("Agent")
                        .txtAgentContact.Text = BorrowerP(0)("AgentNo")
                        .txtAgentContact.Tag = BorrowerP(0)("AgentNo")
                        .cbxMarketing.Checked = If(BorrowerP(0)("Marketing") = "", False, True)
                        .cbxMarketing.Tag = If(BorrowerP(0)("Marketing") = "", "No", "Yes")
                        .cbxMarketingName.Text = BorrowerP(0)("Marketing")
                        .cbxMarketingName.Tag = BorrowerP(0)("Marketing")
                        .txtMarketingContact.Text = BorrowerP(0)("MarketingNo")
                        .txtMarketingContact.Tag = BorrowerP(0)("MarketingNo")
                        .cbxWalkIn.Checked = If(BorrowerP(0)("WalkIn") = "", False, True)
                        .cbxWalkIn.Tag = If(BorrowerP(0)("WalkIn") = "", "No", "Yes")
                        .cbxWalkInType.Text = BorrowerP(0)("WalkIn")
                        .cbxWalkInType.Tag = BorrowerP(0)("WalkIn")
                        .txtWalkInOthers.Text = BorrowerP(0)("WalkIn_Specify")
                        .txtWalkInOthers.Tag = BorrowerP(0)("WalkIn_Specify")
                        .cbxDealer.Checked = If(BorrowerP(0)("Dealer") = "", False, True)
                        .cbxDealer.Tag = If(BorrowerP(0)("Dealer") = "", "No", "Yes")
                        .cbxDealerName.Text = BorrowerP(0)("Dealer")
                        .cbxDealerName.Tag = BorrowerP(0)("Dealer")
                        .txtDealersContact.Text = BorrowerP(0)("DealerNo")
                        .txtDealersContact.Tag = BorrowerP(0)("DealerNo")
                        .cbxBusinessCenter.Text = BorrowerP(0)("BusinessCenter")
                        .cbxBusinessCenter.Tag = BorrowerP(0)("BusinessCenter")
                        Try
                            Using TempPB As New DevExpress.XtraEditors.PictureEdit
                                TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, BorrowerP(0)("branch_code"), CreditDT(0)("BorrowerID"), "Corporation.jpg"))
                                ResizeImages(TempPB.Image.Clone, .pb_Logo, 650, 500)
                            End Using
                        Catch ex As Exception
                        End Try

                        .WindowState = FormWindowState.Normal
                        .FormBorderStyle = FormBorderStyle.FixedDialog
                        .ShowDialog()
                    End If
                End With
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LblBorrower_MouseEnter(sender As Object, e As EventArgs) Handles lblBorrower.MouseEnter
        lblBorrower.ForeColor = Color.Black
    End Sub

    Private Sub LblBorrower_MouseLeave(sender As Object, e As EventArgs) Handles lblBorrower.MouseLeave
        lblBorrower.ForeColor = OfficialColor2 'Color.Red
    End Sub

    Private Sub LblBank_MouseEnter(sender As Object, e As EventArgs) Handles lblBank.MouseEnter
        lblBank.ForeColor = Color.Black
    End Sub

    Private Sub LblBank_MouseLeave(sender As Object, e As EventArgs) Handles lblBank.MouseLeave
        lblBank.ForeColor = OfficialColor2 'Color.Red
    End Sub

    Private Sub CbxOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxOptions.SelectedIndexChanged
        If CreditDT(0)("PaymentRequest") = "CLOSED" Then
            MsgBox("Account is already CLOSED, Payment Arrangement is not applicable.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxOptions.SelectedIndex > 0 Then
            If (CreditDT(0)("Loan_Type") = "MIGRATED" Or CreditDT(0)("Loan_Type") = "RESTRUCTURE") And CreditDT(0)("MigratedValidation") = False Then
                MsgBox("Account should be validated first.", MsgBoxStyle.Information, "Info")
            End If
        End If
        If cbxOptions.SelectedIndex = 0 Then 'VALIDATION
            If (CreditDT(0)("Loan_Type") = "MIGRATED" Or CreditDT(0)("Loan_Type") = "RESTRUCTURE") And CreditDT(0)("MigratedValidation") = False Then
                btnValidate.PerformClick()
            Else
                If MsgBox("Account is already validated. Would you like to revalidate the account?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                    Dim Msg As String = ""
                    Dim Subject As String = ""
                    Dim FName As String = ""
                    Dim EmailTo As String = ""
                    Code = GenerateOTAC()
                    Subject = "One Time Authorization Code " & Code & " [" & lblAccountNumber.Text & "]"
                    Dim BM As DataTable = GetBM(Branch_ID)
                    For x As Integer = 0 To BM.Rows.Count - 1
                        Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Re-Validation of the Account of {1} [{2}]." & vbCrLf, Code, lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text)
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
                    If EmailTo = "" Then
                    Else
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If

                    Dim OTP As New FrmOneTimePassword
                    With OTP
                        .OTP = Code
                        If .ShowDialog = DialogResult.OK Then
                            btnValidate.PerformClick()
                        End If
                    End With
                End If
            End If
        ElseIf cbxOptions.SelectedIndex = 1 Then 'MORATORIUM
            btnMonatorium.PerformClick()
        ElseIf cbxOptions.SelectedIndex = 2 Then 'PAYMENT ARRANGEMENT
            PaymentArrangement()
        ElseIf cbxOptions.SelectedIndex = 3 Then 'TERM EXTENSION
            TermExtension()
        ElseIf cbxOptions.SelectedIndex = 4 Then 'COMPROMISE AGREEMENT
            CompromiseAgreement()
        ElseIf cbxOptions.SelectedIndex = 5 Then 'VOLUNTARY SURRENDER
            If (Mortgage_ID = 0 Or Mortgage_ID = 1 Or Mortgage_ID = 2) And (If(CreditDT(0)("loan_type") = "MIGRATED", CreditDT(0)("MigratedValidation"), True)) Then
                btnSurrender.PerformClick()
            Else
                If (If(CreditDT(0)("loan_type") = "MIGRATED", CreditDT(0)("MigratedValidation"), True)) Then
                    MsgBox("Voluntary Surrender is for Real Estate Mortgage and Chattel Mortgage ONLY.", MsgBoxStyle.Information, "Info")
                Else
                    MsgBox("Account should be validated first before voluntary surrender.", MsgBoxStyle.Information, "Info")
                End If
            End If
        ElseIf cbxOptions.SelectedIndex = 6 Then 'PARTIALLY RECOVERED
            If CreditDT(0)("Loan_Type") <> "MIGRATED" Then
                MsgBox("This tagging is only for MIGRATED Accounts", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If CreditDT(0)("PartiallyRecovered") = 0 Then
                If MsgBoxYes("Are you sure you want to set this account as Partially Recovered Account?") = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE credit_application SET PartiallyRecovered = 1 WHERE CreditNumber = '{0}';", CreditNumber))
                    Call FrmAccountLedger_Load(sender, e)
                    MsgBox("Successfully tagged as Partially Recovered Account!", MsgBoxStyle.Information, "Info")
                End If
            Else
                If MsgBoxYes("Are you sure you want to set this account as NOT Partially Recovered Account?") = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE credit_application SET PartiallyRecovered = 0 WHERE CreditNumber = '{0}';", CreditNumber))
                    Call FrmAccountLedger_Load(sender, e)
                    MsgBox("Successfully untagged as Partially Recovered Account!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Sub SendOTAC(Type As String)
        Dim Msg As String = ""
        Dim Subject As String = "One Time Authorization Code " & Code & " [" & CreditNumber & "]"
        Dim EmailTo As String = ""
        Code = GenerateOTAC()
        Dim BM As DataTable = GetBM(Branch_ID)
        For x As Integer = 0 To BM.Rows.Count - 1
            Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the {2} of the Account of {1} [{3}]." & vbCrLf, Code, lblBorrower.Text.Replace("***", ""), Type, lblAccountNumber.Text)
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
        If EmailTo = "" Then
        Else
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
        End If
    End Sub

    Private Sub PaymentArrangement()
        Dim i As Integer = 0
        For x As Integer = 1 To GridView2.RowCount - 2
            If CDbl(GridView2.GetRowCellValue(x, "Loans Receivable")) >= CDbl(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Total")) Then
                i += 1
            End If
        Next

        If i >= 2 Or i <= 4 Then
        Else
            If MsgBoxYes("Account is not between 2 to 4 months overdue, would you like to proceed?") = MsgBoxResult.Yes Then
            Else
                Exit Sub
            End If
        End If

        If MsgBoxYes("Are you sure you want to set this account for payment arrangement?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            If Trigger_Send = 0 Then
                SendOTAC("Payment Arrangement")
                Trigger_Send = 1
            End If
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                Else
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End With

            DataObject(String.Format("UPDATE credit_application SET PaymentArrangement = PaymentArrangement + 1, LastAccountStatus = 'Payment Arrangement' WHERE CreditNumber = '{0}';", CreditNumber))
            Logs("Ledger", "Payment Arrangement", String.Format("Set to Payment Arrangement for Credit Number {0}.", CreditNumber), "", "", "", "")
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            AddHandler Load, AddressOf FrmAccountLedger_Load
        End If
    End Sub

    Private Sub TermExtension()
        Dim i As Integer = 0
        For x As Integer = 1 To GridView2.RowCount - 2
            If CDbl(GridView2.GetRowCellValue(x, "Loans Receivable")) >= CDbl(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Total")) Then
                i += 1
            End If
        Next

        If i >= 2 Or i <= 4 Then
        Else
            If MsgBoxYes("Account is not between 2 to 4 months overdue, would you like to proceed?") = MsgBoxResult.Yes Then
            Else
                Exit Sub
            End If
        End If

        If MsgBoxYes("Are you sure you want to set this account for term extension?") = MsgBoxResult.Yes Then
            Dim Monatorium As New FrmMonatorium
            With Monatorium
                .lblTitle.Text = "TERM EXTENSION"
                .Original_Amortization = GridControl2.DataSource
                .CreditNumber = CreditNumber
                .Borrower = CreditDT(0)("FullN").ToString.ToUpper
                If CreditDT(0)("Product_Payment").ToString = "Daily" Or CreditDT(0)("Product_Payment").ToString = "Day" Then
                    .Daily = True
                    .Weekly = False
                    .Bimonthly = False
                ElseIf CreditDT(0)("Product_Payment").ToString = "Weekly" Or CreditDT(0)("Product_Payment").ToString = "Week" Then
                    .Daily = False
                    .Weekly = True
                    .Bimonthly = False
                ElseIf CreditDT(0)("Product_Payment").ToString = "Bimonthly" Or CreditDT(0)("Product_Payment").ToString = "Bimonth" Then
                    .Daily = False
                    .Weekly = False
                    .Bimonthly = True
                ElseIf CreditDT(0)("Product_Payment").ToString = "Monthly" Or CreditDT(0)("Product_Payment").ToString = "Month" Then
                    .Daily = False
                    .Weekly = False
                    .Bimonthly = False
                End If
                If .ShowDialog() = DialogResult.OK Then
                    DataObject(String.Format("UPDATE credit_application SET TermExtension = TermExtension + 1, LastAccountStatus = 'Term Extension' WHERE CreditNumber = '{0}';", CreditNumber))
                    Logs("Ledger", "Payment Arrangement", String.Format("Set to Term Extension for Credit Number {0}.", CreditNumber), "", "", "", "")
                    Dim senderT As New Object
                    Dim eT As New EventArgs
                    Call FrmAccountLedger_Load(senderT, eT)
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub CompromiseAgreement()
        Dim i As Integer = 0
        For x As Integer = 1 To GridView2.RowCount - 2
            If CDbl(GridView2.GetRowCellValue(x, "Loans Receivable")) >= CDbl(GridView1.GetRowCellValue(GridView1.RowCount - 1, "Total")) Then
                i += 1
            End If
        Next

        If i >= 2 Or i <= 4 Then
        Else
            If MsgBoxYes("Account is not between 2 to 4 months overdue, would you like to proceed?") = MsgBoxResult.Yes Then
            Else
                Exit Sub
            End If
        End If

        If MsgBoxYes("Are you sure you want to set this account for compromise agreement?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            If Trigger_Send = 0 Then
                SendOTAC("Compromise Agreement")
                Trigger_Send = 1
            End If
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                Else
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End With

            DataObject(String.Format("UPDATE credit_application SET CompromiseAgreement = CompromiseAgreement + 1, LastAccountStatus = 'Compromise Agreement' WHERE CreditNumber = '{0}';", CreditNumber))
            Logs("Ledger", "Payment Arrangement", String.Format("Set to Compromise Agreement for Credit Number {0}.", CreditNumber), "", "", "", "")
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            Dim senderT As New Object
            Dim eT As New EventArgs
            Call FrmAccountLedger_Load(senderT, eT)
        End If
    End Sub

    Private Sub BtnTermExtention_Click(sender As Object, e As EventArgs) Handles btnTermExtention.Click
        If MsgBoxYes("Are you sure you to add term for this account?") = MsgBoxResult.Yes Then
            Dim Monatorium As New FrmMonatorium
            With Monatorium
                .lblTitle.Text = "TERM EXTENSION"
                .iTerms_C.MinValue = 1
                .iTerms_C.MaxValue = 1
                .LabelX81.Text = "Term :"
                .LabelX9.Visible = False
                .dtpStart.Visible = False
                .LabelX47.Visible = True
                .cbxType.Visible = True
                .cbxType.SelectedIndex = 0
                .InterestRate = CDbl(CreditDT(0)("Interest_Rate")) / 12
                .Original_Amortization = GridControl2.DataSource
                .CreditNumber = CreditNumber
                .Borrower = CreditDT(0)("FullN").ToString.ToUpper
                If .ShowDialog() = DialogResult.OK Then
                    Call FrmAccountLedger_Load(sender, e)
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub IPenalty_Click(sender As Object, e As EventArgs) Handles iPenalty.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf CDbl(GridView1.GetFocusedRowCellValue("Penalties B")) = 0 Then
                MsgBox("No hanging penalty to remove.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBox("Are you sure you want to remove the hanging penalty for this transaction?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            If User_Type = "ADMIN" Then
                GoTo Here
            End If
            Dim Msg As String = ""
            Dim FName As String = ""
            Dim EmailTo As String = ""
            Code = GenerateOTAC()
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & lblAccountNumber.Text & "]"
            Dim BM As DataTable
            If User_Type = "ADMIN" Then
                BM = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE ID = '{0}';", Empl_ID))
            Else
                BM = GetBM(Branch_ID)
            End If
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for removing of hanging penalty of {1} for {2} - {3} ({4})." & vbCrLf, Code, GridView1.GetFocusedRowCellValue("Penalties B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No."))
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
            If EmailTo = "" Then
            Else
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
            End If

Here:
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If User_Type = "ADMIN" Then
                    .txtOTP.Text = Code
                End If
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If .ShowDialog = DialogResult.OK Then
                    DataObject(String.Format("UPDATE accounting_entry SET PenaltyPayable = 0 WHERE PaidFor LIKE '%Penalty%' AND IF(ORNum = '',JVNum,ORNum) = '{1}' AND ReferenceN = '{2}';", CDbl(GridView1.GetFocusedRowCellValue("Penalties B")), GridView1.GetFocusedRowCellValue("O.R. No."), CreditNumber))
                    Logs("Subsidiary Ledger", "Remove Penalty", Reason, String.Format("Removed hanging penalty of {0} for {1} - {2} ({3})", GridView1.GetFocusedRowCellValue("Penalties B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No.")), "", "", "")

                    MsgBox("Successfully Removed!", MsgBoxStyle.Information, "Info")
                    LoadLedger()
                End If
            End With
        End If
    End Sub

    Private Sub IAvailed_Click(sender As Object, e As EventArgs) Handles iAvailed.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf CDbl(GridView1.GetFocusedRowCellValue("RPPD A")) <> 0 Then
                MsgBox("RPPD Availed is not zero.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf lblClosed.Visible Then
                If MsgBoxYes("Account is already closed! are you sure you want to continue?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBox("Are you sure you want to add Availed RPPD in this transaction?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            If User_Type = "ADMIN" Then
                GoTo Here
            End If
            Dim Msg As String = ""
            Dim FName As String = ""
            Dim EmailTo As String = ""
            Code = GenerateOTAC()
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & lblAccountNumber.Text & "]"
            Dim BM As DataTable
            If User_Type = "ADMIN" Then
                BM = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE ID = '{0}';", Empl_ID))
            Else
                BM = GetBM(Branch_ID)
            End If
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for adding availed RPPD with amount of {1} for {2} - {3} ({4})" & vbCrLf, Code, lblMR.Text, lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No."))
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
            If EmailTo = "" Then
            Else
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
            End If

Here:
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If User_Type = "ADMIN" Then
                    .txtOTP.Text = Code
                End If
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If .ShowDialog = DialogResult.OK Then
                    Dim SQL As String = "INSERT INTO accounting_entry SET"
                    SQL &= String.Format(" CVNum = '{0}', ", GridView1.GetFocusedRowCellValue("CVNum"))
                    SQL &= String.Format(" JVNum = '{0}', ", GridView1.GetFocusedRowCellValue("JVNum"))
                    SQL &= String.Format(" ORNum = '{0}', ", GridView1.GetFocusedRowCellValue("ORNum"))
                    SQL &= String.Format(" CVNumber = '{0}', ", GridView1.GetFocusedRowCellValue("O.R. No."))
                    SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(GridView1.GetFocusedRowCellValue("Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                    SQL &= " EntryType = 'CREDIT',"
                    SQL &= " AccountCode = '', " 'Availed
                    SQL &= " MotherCode = '', " 'Availed
                    SQL &= String.Format(" Payable = '{0}', ", 0)
                    SQL &= String.Format(" Amount = '{0}', ", If(CreditDT(0)("Product_Payment") = "Bimonthly", CDbl(lblMR.Text) / 2, CDbl(lblMR.Text)))
                    SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                    SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD")
                    If GridView1.GetFocusedRowCellValue("Status") = "POSTED" Then
                        SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                    End If
                    SQL &= String.Format(" BankID = '{0}', ", 0)
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    DataObject(SQL)
                    Logs("Subsidiary Ledger", "Add RPPD Availed", Reason, String.Format("Add availed RPPD of {0} for {1} - {2} ({3})", lblMR.Text, lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No.")), "", "", "")

                    MsgBox("Successfully RPPD Availed!", MsgBoxStyle.Information, "Info")
                    LoadLedger()
                End If
            End With
        End If
    End Sub

    Private Sub IRemoveAvailed_Click(sender As Object, e As EventArgs) Handles iRemoveAvailed.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf CDbl(GridView1.GetFocusedRowCellValue("RPPD A")) = 0 Then
                MsgBox("RPPD Availed is already zero.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf lblClosed.Visible Then
                If MsgBoxYes("Account is already closed! are you sure you want to continue?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBox("Are you sure you want to remove the Availed RPPD for this transaction?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            If User_Type = "ADMIN" Then
                GoTo Here
            End If
            Dim Msg As String = ""
            Dim FName As String = ""
            Dim EmailTo As String = ""
            Code = GenerateOTAC()
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & lblAccountNumber.Text & "]"
            Dim BM As DataTable
            If User_Type = "ADMIN" Then
                BM = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE ID = '{0}';", Empl_ID))
            Else
                BM = GetBM(Branch_ID)
            End If
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for removing of availed RPPD of {1} for {2} - {3} ({4})." & vbCrLf, Code, lblMR.Text, lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No."))
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
            If EmailTo = "" Then
            Else
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
            End If

Here:
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If User_Type = "ADMIN" Then
                    .txtOTP.Text = Code
                End If
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If .ShowDialog = DialogResult.OK Then
                    DataObject(String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE PaidFor = 'RPPD-A' AND ORNum = '{0}';", GridView1.GetFocusedRowCellValue("O.R. No.")))
                    Logs("Subsidiary Ledger", "Remove RPPD Availed", Reason, String.Format("Removed availed RPPD of {0} for {1} - {2} ({3})", lblMR.Text, lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No.")), "", "", "")

                    MsgBox("Successfully Removed RPPD Availed!", MsgBoxStyle.Information, "Info")
                    LoadLedger()
                End If
            End With
        End If
    End Sub

    Private Sub IRemovePenaltyAddRPPD_Click(sender As Object, e As EventArgs) Handles iRemovePenaltyAddRPPD.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf CDbl(GridView1.GetFocusedRowCellValue("Penalties B")) > 0 And GridView1.FocusedRowHandle <> GridView1.RowCount - 1 Then
                MsgBox("Only hanging unpaid penalties can be remove.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf CDbl(GridView1.GetFocusedRowCellValue("RPPD A")) <> 0 Then
                MsgBox("RPPD Availed is not zero.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf lblClosed.Visible Then
                If MsgBoxYes("Account is already closed! are you sure you want to continue?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBox("Are you sure you want to remove the hanging penalty and add availed rppd for this transaction?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            If User_Type = "ADMIN" Then
                GoTo Here
            End If
            Dim Msg As String = ""
            Dim FName As String = ""
            Dim EmailTo As String = ""
            Code = GenerateOTAC()
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & lblAccountNumber.Text & "]"
            Dim BM As DataTable
            If User_Type = "ADMIN" Then
                BM = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE ID = '{0}';", Empl_ID))
            Else
                BM = GetBM(Branch_ID)
            End If
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for removing of hanging penalty of {1} and adding availed rppd of {5} for {2} - {3} ({4})." & vbCrLf, Code, GridView1.GetFocusedRowCellValue("Penalties B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No."), lblMR.Text)
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
            If EmailTo = "" Then
            Else
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
            End If

Here:
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If User_Type = "ADMIN" Then
                    .txtOTP.Text = Code
                End If
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If .ShowDialog = DialogResult.OK Then
                    Dim SQL As String = "INSERT INTO accounting_entry SET"
                    SQL &= String.Format(" CVNum = '{0}', ", GridView1.GetFocusedRowCellValue("CVNum"))
                    SQL &= String.Format(" JVNum = '{0}', ", GridView1.GetFocusedRowCellValue("JVNum"))
                    SQL &= String.Format(" ORNum = '{0}', ", GridView1.GetFocusedRowCellValue("ORNum"))
                    SQL &= String.Format(" CVNumber = '{0}', ", GridView1.GetFocusedRowCellValue("O.R. No."))
                    SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(GridView1.GetFocusedRowCellValue("Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                    SQL &= " EntryType = 'CREDIT',"
                    SQL &= " AccountCode = '', " 'Availed
                    SQL &= " MotherCode = '', " 'Availed
                    SQL &= String.Format(" Payable = '{0}', ", 0)
                    SQL &= String.Format(" Amount = '{0}', ", If(CreditDT(0)("Product_Payment") = "Bimonthly", CDbl(lblMR.Text) / 2, CDbl(lblMR.Text)))
                    SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                    SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD")
                    If GridView1.GetFocusedRowCellValue("Status") = "POSTED" Then
                        SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                    End If
                    SQL &= String.Format(" BankID = '{0}', ", 0)
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    DataObject(SQL & String.Format("UPDATE accounting_entry SET PenaltyPayable = 0 WHERE PenaltyPayable = '{0}' AND IF(ORNum = '',JVNum,ORNum) = '{1}' AND ReferenceN = '{2}';", CDbl(GridView1.GetFocusedRowCellValue("Penalties B")), GridView1.GetFocusedRowCellValue("O.R. No."), CreditNumber))
                    Logs("Subsidiary Ledger", "Remove Penalty", Reason, String.Format("Removed hanging penalty of {0} for {1} - {2} ({3})", GridView1.GetFocusedRowCellValue("Penalties B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No.")), "", "", "")

                    MsgBox("Successfully Removed Hanging Penalty and Add Availed RPPD!", MsgBoxStyle.Information, "Info")
                    LoadLedger()
                End If
            End With
        End If
    End Sub

    Private Sub BtnSchedule_Click(sender As Object, e As EventArgs) Handles btnSchedule.Click
        If MsgBoxYes("Are you sure you want to open the full schedule?") = MsgBoxResult.Yes Then
            Dim Monatorium As New FrmMonatorium
            With Monatorium
                .lblTitle.Text = "AMORTIZATION SCHEDULE"
                .PanelEx5.Visible = False
                .iTerms_C.MinValue = 0
                .iTerms_C.MaxValue = 0
                .LabelX81.Text = "Term :"
                .LabelX9.Visible = False
                .dtpStart.Visible = False
                .LabelX47.Visible = True
                .cbxType.Visible = True
                .cbxType.SelectedIndex = 0
                .InterestRate = CDbl(CreditDT(0)("Interest_Rate")) / 12
                .Original_Amortization = GridControl2.DataSource
                .CreditNumber = CreditNumber
                .Borrower = CreditDT(0)("FullN").ToString.ToUpper
                .btnSave.Visible = False
                .btnResend.Visible = False
                .btnSave.Enabled = False
                .btnResend.Enabled = False
                .btnCancel.Location = New Point(6, 3)
                .btnPrint.Location = New Point(119, 3)
                If .ShowDialog() = DialogResult.OK Then
                    Call FrmAccountLedger_Load(sender, e)
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnAddReverseRPPD_Click(sender As Object, e As EventArgs) Handles btnAddReverseRPPD.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf CDbl(GridView1.GetFocusedRowCellValue("RPPD A")) <> 0 Then
                MsgBox("RPPD Availed is not zero.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf lblClosed.Visible Then
                If MsgBoxYes("Account is already closed! are you sure you want to continue?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBox("Are you sure you want to add Reversed Availed RPPD in this transaction?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            If User_Type = "ADMIN" Then
                GoTo Here
            End If
            Dim Msg As String = ""
            Dim FName As String = ""
            Dim EmailTo As String = ""
            Code = GenerateOTAC()
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & lblAccountNumber.Text & "]"
            Dim BM As DataTable
            If User_Type = "ADMIN" Then
                BM = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE ID = '{0}';", Empl_ID))
            Else
                BM = GetBM(Branch_ID)
            End If
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for adding reversed availed RPPD with amount of {1} for {2} - {3} ({4})" & vbCrLf, Code, lblMR.Text, lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No."))
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
            If EmailTo = "" Then
            Else
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
            End If

Here:
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If User_Type = "ADMIN" Then
                    .txtOTP.Text = Code
                End If
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If .ShowDialog = DialogResult.OK Then
                    Dim SQL As String = "INSERT INTO accounting_entry SET"
                    SQL &= String.Format(" CVNum = '{0}', ", GridView1.GetFocusedRowCellValue("CVNum"))
                    SQL &= String.Format(" JVNum = '{0}', ", GridView1.GetFocusedRowCellValue("JVNum"))
                    SQL &= String.Format(" ORNum = '{0}', ", GridView1.GetFocusedRowCellValue("ORNum"))
                    SQL &= String.Format(" CVNumber = '{0}', ", GridView1.GetFocusedRowCellValue("O.R. No."))
                    SQL &= String.Format(" JVNumber = '{0}', ", GridView1.GetFocusedRowCellValue("O.R. No."))
                    SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(GridView1.GetFocusedRowCellValue("Date")), "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                    SQL &= " EntryType = 'DEBIT',"
                    SQL &= " AccountCode = '', " 'Availed
                    SQL &= " MotherCode = '', " 'Availed
                    SQL &= String.Format(" Payable = '{0}', ", 0)
                    SQL &= String.Format(" Amount = '{0}', ", If(CreditDT(0)("Product_Payment") = "Bimonthly", CDbl(lblMR.Text) / 2, CDbl(lblMR.Text)))
                    SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                    SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD [Reversal]")
                    If GridView1.GetFocusedRowCellValue("Status") = "POSTED" Then
                        SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                    End If
                    SQL &= String.Format(" BankID = '{0}', ", 0)
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    DataObject(SQL)
                    Logs("Subsidiary Ledger", "Add Reversed Availed", Reason, String.Format("Add Reversed availed RPPD of {0} for {1} - {2} ({3})", lblMR.Text, lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No.")), "", "", "")

                    MsgBox("Successfully Add Reversed RPPD Availed!", MsgBoxStyle.Information, "Info")
                    LoadLedger()
                End If
            End With
        End If
    End Sub

    Private Sub LblBank_Click(sender As Object, e As EventArgs) Handles lblBank.Click
        Dim Bank As New FrmBankTagged
        With Bank
            .Bank = BankID
            If .ShowDialog() = DialogResult.OK Then
                If BankID = .cbxBank.SelectedValue Then
                Else
                    DataObject(String.Format("UPDATE credit_application SET BankID = '{0}' WHERE CreditNumber = '{1}';", .cbxBank.SelectedValue, CreditNumber))
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                    Logs("Subsidiary Ledger", "Change Bank", String.Format("Change Bank From {0} to {1}", lblBank.Text, .cbxBank.Text), "", "", "", CreditNumber)
                    BankID = .cbxBank.SelectedValue
                    lblBank.Text = .cbxBank.Text
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub LblAccountNumber_Click(sender As Object, e As EventArgs) Handles lblAccountNumber.Click
        If lblAccountNumber.BackgroundStyle.BorderBottomWidth = 0 Then
            lblAccountNumber.BackgroundStyle.BorderBottomWidth = 1
            lblBorrower.BackgroundStyle.BorderBottomWidth = 1
            lblSpouse.BackgroundStyle.BorderBottomWidth = 1
            lblBirthdate.BackgroundStyle.BorderBottomWidth = 1
            lblEmailAdd.BackgroundStyle.BorderBottomWidth = 1
            lblAddress.BackgroundStyle.BorderBottomWidth = 1
            lblCM_1.BackgroundStyle.BorderBottomWidth = 1
            lblCM_2.BackgroundStyle.BorderBottomWidth = 1
            lblCM_3.BackgroundStyle.BorderBottomWidth = 1
            lblCM_4.BackgroundStyle.BorderBottomWidth = 1
            lblMobile.BackgroundStyle.BorderBottomWidth = 1
            lblMobileCM_1.BackgroundStyle.BorderBottomWidth = 1
            lblMobileCM_2.BackgroundStyle.BorderBottomWidth = 1
            lblMobileCM_3.BackgroundStyle.BorderBottomWidth = 1
            lblMobileCM_4.BackgroundStyle.BorderBottomWidth = 1
            lblCollateral.BackgroundStyle.BorderBottomWidth = 1
            lblPlateNumber.BackgroundStyle.BorderBottomWidth = 1
            lblMotorNum.BackgroundStyle.BorderBottomWidth = 1
            lblChassisNumber.BackgroundStyle.BorderBottomWidth = 1
            lblORNum.BackgroundStyle.BorderBottomWidth = 1
            lblColor.BackgroundStyle.BorderBottomWidth = 1
            lblTCTNum.BackgroundStyle.BorderBottomWidth = 1
            lblLocation.BackgroundStyle.BorderBottomWidth = 1
            lblArea.BackgroundStyle.BorderBottomWidth = 1
            lblInsurance.BackgroundStyle.BorderBottomWidth = 1
            lblCoverage.BackgroundStyle.BorderBottomWidth = 1
            lblExpiry.BackgroundStyle.BorderBottomWidth = 1
            lblPremium.BackgroundStyle.BorderBottomWidth = 1
            lblCVNum.BackgroundStyle.BorderBottomWidth = 1
            lblDate.BackgroundStyle.BorderBottomWidth = 1
            lblPrincipal.BackgroundStyle.BorderBottomWidth = 1
            lblUDI.BackgroundStyle.BorderBottomWidth = 1
            lblRPPD.BackgroundStyle.BorderBottomWidth = 1
            lblFaceAmount.BackgroundStyle.BorderBottomWidth = 1
            lblRemarks.BackgroundStyle.BorderBottomWidth = 1
            lblRate.BackgroundStyle.BorderBottomWidth = 1
            lblGMA.BackgroundStyle.BorderBottomWidth = 1
            lblMR.BackgroundStyle.BorderBottomWidth = 1
            lblNMA.BackgroundStyle.BorderBottomWidth = 1
            lblTerms.BackgroundStyle.BorderBottomWidth = 1
            lblPNDate.BackgroundStyle.BorderBottomWidth = 1
            lblFDD.BackgroundStyle.BorderBottomWidth = 1
            lblMD.BackgroundStyle.BorderBottomWidth = 1
            lblReleased.BackgroundStyle.BorderBottomWidth = 1
            lblCI.BackgroundStyle.BorderBottomWidth = 1
            lblReferred.BackgroundStyle.BorderBottomWidth = 1
            lblNotes.BackgroundStyle.BorderBottomWidth = 1
            lblBank.BackgroundStyle.BorderBottomWidth = 1
        Else
            lblAccountNumber.BackgroundStyle.BorderBottomWidth = 0
            lblBorrower.BackgroundStyle.BorderBottomWidth = 0
            lblSpouse.BackgroundStyle.BorderBottomWidth = 0
            lblBirthdate.BackgroundStyle.BorderBottomWidth = 0
            lblEmailAdd.BackgroundStyle.BorderBottomWidth = 0
            lblAddress.BackgroundStyle.BorderBottomWidth = 0
            lblCM_1.BackgroundStyle.BorderBottomWidth = 0
            lblCM_2.BackgroundStyle.BorderBottomWidth = 0
            lblCM_3.BackgroundStyle.BorderBottomWidth = 0
            lblCM_4.BackgroundStyle.BorderBottomWidth = 0
            lblMobile.BackgroundStyle.BorderBottomWidth = 0
            lblMobileCM_1.BackgroundStyle.BorderBottomWidth = 0
            lblMobileCM_2.BackgroundStyle.BorderBottomWidth = 0
            lblMobileCM_3.BackgroundStyle.BorderBottomWidth = 0
            lblMobileCM_4.BackgroundStyle.BorderBottomWidth = 0
            lblCollateral.BackgroundStyle.BorderBottomWidth = 0
            lblPlateNumber.BackgroundStyle.BorderBottomWidth = 0
            lblMotorNum.BackgroundStyle.BorderBottomWidth = 0
            lblChassisNumber.BackgroundStyle.BorderBottomWidth = 0
            lblORNum.BackgroundStyle.BorderBottomWidth = 0
            lblColor.BackgroundStyle.BorderBottomWidth = 0
            lblTCTNum.BackgroundStyle.BorderBottomWidth = 0
            lblLocation.BackgroundStyle.BorderBottomWidth = 0
            lblArea.BackgroundStyle.BorderBottomWidth = 0
            lblInsurance.BackgroundStyle.BorderBottomWidth = 0
            lblCoverage.BackgroundStyle.BorderBottomWidth = 0
            lblExpiry.BackgroundStyle.BorderBottomWidth = 0
            lblPremium.BackgroundStyle.BorderBottomWidth = 0
            lblCVNum.BackgroundStyle.BorderBottomWidth = 0
            lblDate.BackgroundStyle.BorderBottomWidth = 0
            lblPrincipal.BackgroundStyle.BorderBottomWidth = 0
            lblUDI.BackgroundStyle.BorderBottomWidth = 0
            lblRPPD.BackgroundStyle.BorderBottomWidth = 0
            lblFaceAmount.BackgroundStyle.BorderBottomWidth = 0
            lblRemarks.BackgroundStyle.BorderBottomWidth = 0
            lblRate.BackgroundStyle.BorderBottomWidth = 0
            lblGMA.BackgroundStyle.BorderBottomWidth = 0
            lblMR.BackgroundStyle.BorderBottomWidth = 0
            lblNMA.BackgroundStyle.BorderBottomWidth = 0
            lblTerms.BackgroundStyle.BorderBottomWidth = 0
            lblPNDate.BackgroundStyle.BorderBottomWidth = 0
            lblFDD.BackgroundStyle.BorderBottomWidth = 0
            lblMD.BackgroundStyle.BorderBottomWidth = 0
            lblReleased.BackgroundStyle.BorderBottomWidth = 0
            lblCI.BackgroundStyle.BorderBottomWidth = 0
            lblReferred.BackgroundStyle.BorderBottomWidth = 0
            lblNotes.BackgroundStyle.BorderBottomWidth = 0
            lblBank.BackgroundStyle.BorderBottomWidth = 0
        End If
    End Sub

    Private Sub IRemoveAR_Click(sender As Object, e As EventArgs) Handles iRemoveAR.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf CDbl(GridView1.GetFocusedRowCellValue("A.R. B")) = 0 Then
                MsgBox("No hanging AR to remove.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim ARStatus As String = DataObject(String.Format("SELECT `status` FROM accounts_receivable WHERE DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("O.R. No.")))
        If ARStatus = "ACTIVE" Then
            MsgBox("Accounts Receivable is still ACTIVE, removing AR is not allowed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        ElseIf ARStatus = "" Then
            MsgBox("No Accounts Receivable found with this Document Number " & GridView1.GetFocusedRowCellValue("O.R. No."), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If MsgBox("Are you sure you want to remove the hanging AR for this transaction?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            If User_Type = "ADMIN" Then
                GoTo Here
            End If
            Dim Msg As String = ""
            Dim FName As String = ""
            Dim EmailTo As String = ""
            Code = GenerateOTAC()
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & lblAccountNumber.Text & "]"
            Dim BM As DataTable
            If User_Type = "ADMIN" Then
                BM = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE ID = '{0}';", Empl_ID))
            Else
                BM = GetBM(Branch_ID)
            End If
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for removing of hanging AR of {1} for {2} - {3} ({4})." & vbCrLf, Code, GridView1.GetFocusedRowCellValue("Penalties B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No."))
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
            If EmailTo = "" Then
            Else
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
            End If

Here:
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If User_Type = "ADMIN" Then
                    .txtOTP.Text = Code
                End If
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If .ShowDialog = DialogResult.OK Then
                    DataObject(String.Format("UPDATE accounting_entry SET `status` = '{2}' WHERE ReferenceN = '{0}' AND CVNumber = '{1}';", CreditNumber, GridView1.GetFocusedRowCellValue("O.R. No."), ARStatus))
                    Logs("Subsidiary Ledger", "Remove AR", Reason, String.Format("Removed AR of {0} for {1} - {2} ({3})", GridView1.GetFocusedRowCellValue("A.R. B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No.")), "", "", "")

                    MsgBox("Successfully Removed!", MsgBoxStyle.Information, "Info")
                    LoadLedger()
                End If
            End With
        End If
    End Sub

    Private Sub BtnOtherIncome_Click(sender As Object, e As EventArgs) Handles btnOtherIncome.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf CDbl(GridView1.GetFocusedRowCellValue("Amount Paid")) > 0 Then
                MsgBox(String.Format("Transaction {0} have a paid for set already.", GridView1.GetFocusedRowCellValue("O.R. No.")), MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf CDbl(GridView1.GetFocusedRowCellValue("Total")) > 0 Then
                If MsgBox(String.Format("Account it not yet close during this transaction {0}. Would you like to proceed?", GridView1.GetFocusedRowCellValue("O.R. No.")), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBox("Are you sure you want to set the BLANK Paid For to Other Income?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            If User_Type = "ADMIN" Then
                GoTo Here
            End If
            Dim Msg As String = ""
            Dim FName As String = ""
            Dim EmailTo As String = ""
            Code = GenerateOTAC()
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & lblAccountNumber.Text & "]"
            Dim BM As DataTable
            If User_Type = "ADMIN" Then
                BM = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE ID = '{0}';", Empl_ID))
            Else
                BM = GetBM(Branch_ID)
            End If
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for setting the BLANK Paid For to Other Income of {1} for {2} - {3} ({4})." & vbCrLf, Code, GridView1.GetFocusedRowCellValue("Penalties B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No."))
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
            If EmailTo = "" Then
            Else
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
            End If

Here:
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If User_Type = "ADMIN" Then
                    .txtOTP.Text = Code
                End If
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If
                If .ShowDialog = DialogResult.OK Then
                    DataObject(String.Format("UPDATE accounting_entry SET PaidFor = 'Other Income' WHERE PaidFor = '' AND ReferenceN = '{0}' AND CVNumber = '{1}';", CreditNumber, GridView1.GetFocusedRowCellValue("O.R. No.")))
                    Logs("Subsidiary Ledger", "Other Income", Reason, String.Format("Set BLANK Paid For to Other Income of {0} for {1} - {2} ({3})", GridView1.GetFocusedRowCellValue("A.R. B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No.")), "", "", "")

                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                    LoadLedger()
                End If
            End With
        End If
    End Sub

    Private Sub IAddPenalty_Click(sender As Object, e As EventArgs) Handles iAddPenalty.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim AddAmount As New FrmAddAmount
        With AddAmount
            .DefaultAmount = CDbl(GridView1.GetFocusedRowCellValue("Penalties B"))
            If .ShowDialog = DialogResult.OK Then
                If MsgBox("Are you sure you want to add hanging penalty for this transaction?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                    If User_Type = "ADMIN" Then
                        GoTo Here
                    End If
                    Dim Msg As String = ""
                    Dim FName As String = ""
                    Dim EmailTo As String = ""
                    Code = GenerateOTAC()
                    Dim Subject As String = "One Time Authorization Code " & Code & " [" & lblAccountNumber.Text & "]"
                    Dim BM As DataTable
                    If User_Type = "ADMIN" Then
                        BM = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE ID = '{0}';", Empl_ID))
                    Else
                        BM = GetBM(Branch_ID)
                    End If
                    For x As Integer = 0 To BM.Rows.Count - 1
                        Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for removing of hanging penalty of {1} for {2} - {3} ({4})." & vbCrLf, Code, GridView1.GetFocusedRowCellValue("Penalties B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No."))
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
                    If EmailTo = "" Then
                    Else
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If

Here:
                    Dim OTP As New FrmOneTimePassword
                    With OTP
                        .OTP = Code
                        If User_Type = "ADMIN" Then
                            .txtOTP.Text = Code
                        End If
                        Dim Reason As String 'Reason for change
                        If FrmReason.ShowDialog = DialogResult.OK Then
                            Reason = FrmReason.txtReason.Text
                        Else
                            Exit Sub
                        End If
                        If .ShowDialog = DialogResult.OK Then
                            Dim SQL As String = "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" CVNum = '{0}', ", GridView1.GetFocusedRowCellValue("CVNum"))
                            SQL &= String.Format(" JVNum = '{0}', ", GridView1.GetFocusedRowCellValue("JVNum"))
                            SQL &= String.Format(" ORNum = '{0}', ", GridView1.GetFocusedRowCellValue("ORNum"))
                            SQL &= String.Format(" CVNumber = '{0}', ", GridView1.GetFocusedRowCellValue("O.R. No."))
                            SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(GridView1.GetFocusedRowCellValue("Date")), "yyyy-MM-dd"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", CreditNumber)
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= " AccountCode = '', " 'Availed
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= String.Format(" Payable = '{0}', ", 0)
                            SQL &= String.Format(" Amount = '{0}', ", 0)
                            SQL &= String.Format(" PenaltyPayable = '{0}', ", AddAmount.dAmount.Value)
                            SQL &= String.Format(" PaidFor = '{0}', ", "Penalty")
                            SQL &= String.Format(" Remarks = '{0}', ", "Add Penalty")
                            If GridView1.GetFocusedRowCellValue("Status") = "POSTED" Then
                                SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                            End If
                            SQL &= String.Format(" BankID = '{0}', ", 0)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                            DataObject(SQL)
                            'DataSource(String.Format("UPDATE accounting_entry SET PenaltyPayable = {3} WHERE PenaltyPayable = {0} AND IF(JVNum = '', ORNum, JVNum) = '{1}' AND ReferenceN = '{2}';", CDbl(GridView1.GetFocusedRowCellValue("Penalties B")), GridView1.GetFocusedRowCellValue("O.R. No."), CreditNumber, AddAmount.dAmount.Value))
                            Logs("Subsidiary Ledger", "Add Penalty", Reason, String.Format("Removed hanging penalty of {0} for {1} - {2} ({3})", GridView1.GetFocusedRowCellValue("Penalties B"), lblBorrower.Text.Replace("***", ""), lblAccountNumber.Text, GridView1.GetFocusedRowCellValue("O.R. No.")), "", "", "")

                            MsgBox("Successfully Added!", MsgBoxStyle.Information, "Info")
                            LoadLedger()
                        End If
                    End With
                End If
            End If
            .Dispose()
        End With
    End Sub
End Class