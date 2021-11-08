Imports DevExpress.XtraReports.UI
Public Class FrmOfficialReceipt

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Public DefaultBank As Integer
    Dim DT_Account As New DataTable
    Dim ComputationLog As String
    Dim SavingLog As String
    Dim LastPaymentBefore As String

    Dim WaiveDate As String
    Dim Code As String

    Dim Code_Check As String
    Dim Code_Approve As String
    Dim User_EmplID As Integer

    Dim PaymentDT As DataTable
    Dim RPPD_Application As Double
    Dim TotalWaiveRPPD As Double
    Dim TotalWaivePenalty As Double
    Dim TotalWaive As Double
    Dim TotalRPPD As Double
    Dim TotalRPPD_Payable As Double
    Dim TotalInterest As Double
    Dim TotalPayment As Double
    Dim TotalUnpaidPenalty As Double
    Dim LastPayment As Date = Date.Now
    Dim DT_Billing As DataTable
    ReadOnly BeforeEditBilling As Double
    ReadOnly BillingChanged As Boolean
    Dim FaceAmount As Double
    Dim Terms As Integer
    Dim UDI As Double
    Dim EarlySettlement As Boolean
    ReadOnly PreviousTab As Integer
    Dim UnroundedPenalty As Double
    Dim UDI_Amount_Early As Double
    Dim UDI_Percent_Early As Double
    Dim RPPD_Amount_Early As Double
    Dim Payable_Interest As Double

    Dim dBilling_P As Double
    Dim dBilling As Double
    Dim dPenalty_P As Double
    Dim dPenalty As Double
    Dim dRPPD_P As Double
    Dim dRPPD As Double
    Dim dUDI_P As Double
    Dim dUDI_P_Month As Double
    Dim dUDI As Double
    Dim dPrincipal_P As Double
    Dim dPrincipal As Double
    Public From_Credit As Boolean
    Public BankID As Integer
    Public MortgageID As Integer
    Public CheckID As Integer
    Public From_Check As Boolean
    Dim RemoveRPPDFromBalanceLedger As Boolean
    Public CreditNumber As String
    Dim Availed As Double
    Public From_GL As Boolean
    Public GL_DocumentNumber As String
    Public From_DeductBalance As Boolean
    Public From_JournalDTS As Boolean
    Public DTS_Amount As Double
    Public DTS_Date As Date
    Dim AccountNumber As String
    Dim SalaryLoan As Boolean
    Dim ForcedAvailed As Boolean
    Dim SalaryLoan_Loading As Boolean
    Dim DT_SalaryLoan As New DataTable

    Dim SalaryPaid As Double
    Dim SalaryPayable As Double
    Dim Flag As Boolean = False
    Dim SaveIsTriggeredAlready As Boolean
    Dim Principal As Double
    Dim RPPD As Double
    Public Skip_FilterLoadData As Boolean
    Dim DTS As Boolean
    Dim DateValueChanged As Boolean
    'Change Log (May 5, 2020) from Math.Abs(dUDI_P_Month - dUDI_P)) to Math.Max(dUDI_P_Month - dUDI_P, 0))
    Private Sub FrmOfficialReceipt_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If _DatabaseName.ToLower = "fsfc_test" Or _DatabaseName.ToLower = "fsfc_migration" Then
            cbxLoans.Enabled = True
        Else
            cbxLoans.Enabled = False
        End If

        GetGridAppearance({GridView1, GridView2, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Icon = My.Resources.iLoanWorkX_ico
        If From_GL Then
            cbxAll.Checked = True
        End If
        SuperTabControl1.SelectedTab = tabList
        LoadData()
        cbxDisplay.SelectedIndex = 0
        dtpDocument.Value = Date.Now
        dtpPostingDate.Value = Date.Now
        dtpDeposit.Value = Date.Now
        dtpORDate.Value = Date.Now
        dtpRemittance.Value = Date.Now
        dtpAR.Value = Date.Now

        From_Credit = True

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch, AccountCode FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", If(Multiple_ID = "", Branch_ID, Multiple_ID) & "," & MFBranch_ID, DefaultBankID))
            If DefaultBankID > 0 Then
                .Enabled = False
            Else
                .SelectedValue = DefaultBank
            End If
        End With

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        With cbxAccount
            .DisplayMember = "Account"
            .ValueMember = "Account Code"
        End With

        With txtRemittance
            .DisplayMember = "RemittanceCenter"
            .ValueMember = "ID"
            .DataSource = DT_Remittance
            .SelectedIndex = -1
        End With

        With RepositoryItemSearchLookUpEdit1
            .DisplayMember = "Account"
            .ValueMember = "Account"

            If CompanyMode = 0 Then
                cbxAccount.DataSource = DT_AccountsM.Copy
                .DataSource = DT_AccountsM_V2.Copy
            Else
                cbxAccount.DataSource = DT_Accounts.Copy
                .DataSource = DT_Accounts_V2.Copy
            End If
        End With

        With cbxDepartment
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
        End With

        With RepositoryItemLookUpEdit2
            .DisplayMember = "Department"
            .ValueMember = "Department"
            .DataSource = DT_Department.Copy
        End With

        With RepositoryItemLookUpEdit3
            .DisplayMember = "Paid For"
            .ValueMember = "Paid For"
            .DataSource = DataSource("SELECT 'CIB' AS 'Paid For' UNION SELECT 'Billing' UNION SELECT 'Penalty' UNION SELECT 'RPPD' UNION SELECT 'UDI' UNION SELECT 'Principal' UNION SELECT 'Other Income' UNION SELECT ''")
        End With

        With cbxBusinessCenter
            .ValueMember = "BusinessCode"
            .DisplayMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter.Copy
            .SelectedIndex = -1
        End With

        With RepositoryItemLookUpEdit4
            .DisplayMember = "BusinessCenter"
            .ValueMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter_V2.Copy
        End With

        Dim DT_Status As DataTable = DataSource("SELECT 'For Checking' AS 'Status' UNION SELECT 'For Approval' UNION SELECT 'For Deposit' UNION SELECT 'Deposited' UNION SELECT 'For Clearing' UNION SELECT 'Cleared' UNION SELECT 'Cancelled'")
        With cbxStatus
            .Location = New Point(553, 6)
            .Size = New Point(183, 26)
            .Properties.LookAndFeel.SkinName = "Blue"
            .Properties.Items.Clear()
            For x As Integer = 0 To DT_Status.Rows.Count - 1
                .Properties.Items.Add(DT_Status(x)("Status"), DT_Status(x)("Status"), If(DT_Status(x)("Status") = "Cancelled", CheckState.Unchecked, CheckState.Checked), True)
            Next
            .Properties.SeparatorChar = ";"
        End With

        LoadPayee()
        cbxPayee.SelectedIndex = -1
        LoadCompanyMode()

        GetDocumentNumber()
        FirstLoad = False

        If From_GL Then
            Dim i As Integer = 0
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Document Number") = GL_DocumentNumber Then
                    i = x
                    Exit For
                End If
            Next
            GridView1.FocusedRowHandle = i
            GridView1_DoubleClick(sender, e)
            btnRefresh.Enabled = False
            btnNext.Enabled = False
            tabList.Visible = False
        End If

        If From_Check Then
            Dim SQL As String = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode'"
            DT_Account = DataSource(SQL)
            cbxPayee.SelectedValue = CreditNumber
            cbxCheckNumber.SelectedValue = CheckID
            cbxLoans.Enabled = False
            cbxClosed.Enabled = False
        End If

        If From_JournalDTS Then
            FirstLoad = False
            tabList.Visible = False
            cbxPayee.SelectedValue = CreditNumber
            dPaidAmount.Value = DTS_Amount
            dtpORDate.Value = DTS_Date
        End If
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX2, LabelX10, LabelX1, LabelX3, LabelX25, LabelX18, LabelIssued, LabelX20, LabelX9, LabelX6, LabelX14, LabelX7, LabelX12, LabelX16, LabelX5, LabelX15, LabelX17, LabelX13, LabelX8, LabelX34, lblTotalInterest, lblTotalPrincipal, LabelX40, LabelX42, LabelX41, LabelX39})

            GetLabelFontSettingsRed({lblProduct})

            GetLabelWithBackgroundFontSettings({LabelX4, LabelX19, lblAR})

            GetCheckBoxFontSettings({cbxLoans, cbxClosed, cbxAvailed, cbxCash, cbxCheck, cbxOnline, cbxAR, cbxAll, cbxRemittance})

            GetGroupControlExpandableFontSettings({GroupControl1})

            GetButtonFontSettings({btnWaiveRemove, btnEarlySettlement, btnAdd_Account, btnRemove_Account, btnBatchPayment, btnLedger, btnCalculator, btnWaive, btnEarly, btnDeductBalance, btnCalculatorV2, btnSave, btnRefresh, btnCancel, btnModify, btnDisapprove, btnDelete, btnPrint, btnValidate, btnAttach, btnApprove, btnCheck, btnSearch})

            GetComboBoxFontSettings({cbxPayee, cbxBank, cbxAccount, cbxDepartment, cbxBusinessCenter, txtRemittance, cbxCheckNumber, cbxPreparedBy, cbxDisplay})

            GetDateTimeInputFontSettings({dtpDocument, dtpPostingDate, dtpORDate, dtpRemittance, dtpCheck, dtpDeposit, dtpAR, dtpFrom, dtpTo})

            GetTextBoxFontSettings({txtDocumentNumber, txtReferenceNumber, txtDeposit, txtChecked, txtApproved, txtARNumber})

            GetDoubleInputFontSettings({dPaidAmount, dBalanceLedger, dPayable, dTotalInterest, dTotalPrincipal, dDebitT, dCreditT})

            GetSearchRepositoryFontSettings({RepositoryItemSearchLookUpEdit1})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit3, RepositoryItemLookUpEdit2, RepositoryItemLookUpEdit4})

            GetRickTextBoxFontSettings({rExplanation})

            GetTabControlFontSettings({SuperTabControl1})

            GetLabelHeaderFontSettings({lblTitle})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Official Receipt - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Official Receipt", lblTitle.Text)
    End Sub

    Public Sub LoadPayee()
        Dim SQL As String
        If cbxLoans.Checked Then
            cbxPayee.DisplayMember = "Borrower"
            cbxPayee.ValueMember = "Credit Number"
            SQL = "SELECT "
            SQL &= "  C.CreditNumber AS 'Credit Number',"
            SQL &= "  CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)), ' [',CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)),']') AS 'Borrower', CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)) AS 'AccountNumber', "
            SQL &= "  Mortgage_ID, Product, Product_ID, (SELECT IF(product_setup.UDI = 'Yes',TRUE,FALSE) FROM product_setup WHERE product_setup.ID = Product_ID) AS 'with_Interest', (SELECT Payment FROM product_setup WHERE product_setup.ID = Product_ID) AS 'Product_Payment', Prefix_B, FirstN_B, SUBSTRING(MiddleN_B,1,1) AS 'MiddleN_B', LastN_B, Suffix_B, CONCAT(IF(NoC_B='','',CONCAT(NoC_B,', ')), IF(StreetC_B='','',CONCAT(StreetC_B,', ')), IF(BarangayC_B='','',CONCAT(BarangayC_B,', ')), AddressC_B) AS 'Address', Mobile_B, Email_B, (SELECT IFNULL(GROUP_CONCAT(Email_C),'') FROM credit_application_comaker WHERE credit_application_comaker.CreditNumber = C.CreditNumber AND Email_C != '' AND `status` = 'ACTIVE') AS 'Email_C', Terms, Product, AmountApplied, GMA, Interest, Face_Amount,  Interest_Rate, RPPD_Rate, IFNULL(Released,C.Trans_Date) AS 'Released', IFNULL(FDD,C.Trans_Date) AS 'FDD', LDD, Interest_N, RPPD_N, Principal_N, RPPD, BankID, BusinessCenterCode(BusinessID) AS 'BusinessCode',"
            SQL &= String.Format("  'CA' AS 'Type', Loan_Type, Rebate, MigratedValidation, AgentID, PaymentRequest, CVforJV, IFNULL((SELECT `Code` FROM account_chart WHERE Title LIKE '%Due To%' AND BranchTagged = '{0}' AND `Status` = 'ACTIVE'),'') AS 'DueToBranch'", UseBankBranchID)
            SQL &= "  FROM credit_application C "
            If CreditNumber = "" Then
                SQL &= String.Format("  WHERE C.`status` = 'ACTIVE' AND IF('{2}' = 'TRUE',C.`PaymentRequest` IN ('CLOSED','RELEASED'),C.`PaymentRequest` IN ('RELEASED','{1}')) AND Branch_ID IN ({0}) ORDER BY `Borrower`", If(Multiple_ID = "", Branch_ID, Multiple_ID), If(cbxPayee.Enabled And From_Check = False, "", "CLOSED"), If(cbxClosed.Checked, "TRUE", "FALSE"))
            Else
                SQL &= String.Format("  WHERE C.`status` = 'ACTIVE' AND CreditNumber = '{0}';", CreditNumber)
            End If
        Else
            cbxPayee.DisplayMember = "Borrower"
            cbxPayee.ValueMember = "Credit Number"

            SQL = " SELECT "
            SQL &= "    S.AssetNumber AS 'ID',"
            SQL &= "    CONCAT(S.AssetNumber, ' - ', ROPOA_Buyer(S.AssetNumber)) AS 'Payee',"
            SQL &= "    'RO' AS 'Type',"
            SQL &= "    S.ReferenceN AS 'Phone',"
            SQL &= "    S.BankID AS 'EmailAdd'," 'Bank
            SQL &= "    BankID,"
            SQL &= "    Running_Balance(AssetNumber) AS 'ORNum'," 'ROPOA VALUE
            SQL &= "    S.Amount - ROPOA_Payment(S.AssetNumber,S.ID) AS 'Amount',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    S.ID AS 'Payee_ID',"
            SQL &= "    IF(SUBSTRING(S.AssetNumber,1,3) = 'ANV',1,2) AS 'Mortgage'"
            SQL &= String.Format(" FROM sold_ropoa S WHERE S.`status` = 'ACTIVE' AND S.Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,S.Amount - ROPOA_Payment(S.AssetNumber,S.ID) > 0)", Branch_ID, cbxPayee.Enabled)

            SQL &= " UNION ALL"

            SQL &= " SELECT "
            SQL &= "    AccountNumber AS 'ID' ,"
            SQL &= "    CONCAT(AccountNumber, ' - ', Borrower(BorrowerID), ' (', CaseNumber,')') AS 'Employee',"
            SQL &= "    'ITL' AS 'Type',"
            SQL &= "    (SELECT Mobile_B FROM profile_borrower WHERE profile_borrower.BorrowerID = case_main.BorrowerID) AS 'Phone',"
            SQL &= "    (SELECT Email_B FROM profile_borrower WHERE profile_borrower.BorrowerID = case_main.BorrowerID) AS 'EmailAdd',"
            SQL &= "    BankID,"
            SQL &= "    '' AS 'ORNum',"
            SQL &= "    Ledger_Balance_II(AccountNumber,DATE_FORMAT(NOW(),'%Y-%m-%d'),MortgageID) AS 'Amount',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    ID AS 'Payee_ID',"
            SQL &= "    MortgageID AS 'Mortgage'"
            SQL &= String.Format("    FROM case_main WHERE `status` = 'ACTIVE' AND BranchID = '{0}'  AND IF('{1}' = 'False',case_status IN ('FULLY PAID','ACTIVE','DISMISSED','ARCHIVED','WRITTEN OFF'),case_status IN ('ACTIVE','DISMISSED','ARCHIVED','WRITTEN OFF'))", Branch_ID, cbxPayee.Enabled)
        End If
        cbxPayee.DataSource = DataSource(SQL)
        cbxPayee.SelectedIndex = -1
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Voucher_Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Or Status = "REVERSED" Then
                e.Appearance.ForeColor = Color.Red
            End If
        End If
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID,"
        SQL &= "    Payee_ID,"
        SQL &= "    Payee,"
        SQL &= "    (SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE ID = official_receipt.BankID) AS 'Bank', BankID, "
        SQL &= "    DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date',"
        SQL &= "    DATE_FORMAT(ORDate,'%M %d, %Y') AS 'OR Date',"
        SQL &= "    ReferenceNumber AS 'Reference Number',"
        SQL &= "    Explanation,"
        SQL &= "    Amount, Paid, Payable, LedgerBalance, EarlySettlement,"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID, CheckedID, Type_Payment AS 'Type', Remittance, DATE_FORMAT(RemittanceDate,'%M %d, %Y') AS 'RemittanceDate', CheckNumber, DATE_FORMAT(CheckDate,'%M %d, %Y') AS 'CheckDate', ARNumber, DATE_FORMAT(ARDate,'%M %d, %Y') AS 'ARDate', DepositNumber, DATE_FORMAT(DepositDate,'%M %d, %Y') AS 'DepositDate', DATE_FORMAT(ClearDate,'%M %d, %Y') AS 'ClearDate', Payee_Type, DTS, DTS_JVNumber, "
        SQL &= "    BRANCH(branch_id) AS 'Branch', User_EmplID, Branch_ID, IF(Voucher_Status = 'APPROVED' AND ClearDate != '','CLEARED',IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(Voucher_Status = 'APPROVED' AND DepositDate != '' AND Type_Payment = 'CHECK','FOR CLEARING',IF(Voucher_Status = 'APPROVED' AND DepositDate != '' AND Type_Payment = 'CASH','DEPOSITED',IF(JVNumber != '','REVERSED',IF(Voucher_Status='PENDING','FOR CHECKING',IF(Voucher_Status='CHECKED','FOR APPROVAL',IF(Voucher_Status='APPROVED','FOR DEPOSIT',Voucher_Status)))))))) AS 'Voucher_Status', Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', OTAC_Check, OTAC_Approve, Attach, JVNumber, Banking, OldAccount, LastPaymentBefore, TotalRPPD, TotalInterest, TotalPayment, TotalWaivePenalty, TotalUnpaidPenalty, TotalWaive, TotalWaiveRPPD"
        SQL &= "  FROM official_receipt WHERE"
        Dim ForChecking As Boolean
        Dim ForApproval As Boolean
        Dim ForDeposit As Boolean
        Dim Deposited As Boolean
        Dim ForClearing As Boolean
        Dim Cleared As Boolean
        Dim Cancellled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Checking" Then
                    ForChecking = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    ForApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Deposit" Then
                    ForDeposit = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Deposited" Then
                    Deposited = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Clearing" Then
                    ForClearing = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cleared" Then
                    Cleared = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancellled = True
                End If
            End If
        Next
        If Cancellled Then
            If ForChecking = False And ForApproval = False And ForDeposit = False And Deposited = False And ForClearing = False And Cleared = False Then
                SQL &= String.Format(" (`status` IN ({0})  OR voucher_status = 'DISAPPROVED')", If(Cancellled, "'CANCELLED','DELETED','DISAPPROVED'", "''"))
            Else
                SQL &= String.Format(" `status` IN ('ACTIVE',{0}) AND (voucher_status = 'DISAPPROVED' ", If(Cancellled, "'CANCELLED','DELETED','DISAPPROVED'", "''"))
                If ForChecking Or ForApproval Or ForDeposit Or Deposited Or ForClearing Or Cleared Then
                    SQL &= " OR "
                End If
                If ForChecking Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'PENDING',TRUE)"
                    If ForApproval Or ForDeposit Or Deposited Or ForClearing Or Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'CHECKED',TRUE)"
                    If ForDeposit Or Deposited Or ForClearing Or Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If ForDeposit Then
                    SQL &= " IF(`status` = 'ACTIVE',(voucher_status = 'APPROVED' AND DepositDate = ''),TRUE)"
                    If Deposited Or ForClearing Or Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If Deposited Then
                    SQL &= " IF(`status` = 'ACTIVE',(voucher_status = 'APPROVED' AND DepositDate != '' AND Type_Payment = 'CASH'),TRUE)"
                    If ForClearing Or Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If ForClearing Then
                    SQL &= " IF(`status` = 'ACTIVE',(voucher_status = 'APPROVED' AND DepositDate != '' AND ClearDate = '' AND Type_Payment = 'CHECK'),TRUE)"
                    If Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If Cleared Then
                    SQL &= " IF(`status` = 'ACTIVE',(voucher_status = 'APPROVED' AND ClearDate != '' AND Type_Payment = 'CHECK'),TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForChecking = False And ForApproval = False And ForDeposit = False And Deposited = False And ForClearing = False And Cleared = False Then
            Else
                SQL &= " AND ("
                If ForChecking Then
                    SQL &= " voucher_status = 'PENDING'"
                    If ForApproval Or ForDeposit Or Deposited Or ForClearing Or Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " voucher_status = 'CHECKED'"
                    If ForDeposit Or Deposited Or ForClearing Or Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If ForDeposit Then
                    SQL &= " (voucher_status = 'APPROVED' AND DepositDate = '')"
                    If Deposited Or ForClearing Or Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If Deposited Then
                    SQL &= " (voucher_status = 'APPROVED' AND DepositDate != '' AND Type_Payment = 'CASH')"
                    If ForClearing Or Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If ForClearing Then
                    SQL &= " (voucher_status = 'APPROVED' AND DepositDate != '' AND ClearDate = '' AND Type_Payment = 'CHECK')"
                    If Cleared Then
                        SQL &= " OR "
                    End If
                End If
                If Cleared Then
                    SQL &= " (voucher_status = 'APPROVED' AND ClearDate != '' AND Type_Payment = 'CHECK')"
                End If
                SQL &= ")"
            End If
        End If
        If Skip_FilterLoadData Then
            SQL &= String.Format("    AND DocumentNumber = '{0}'", GL_DocumentNumber)
        End If
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(DocumentDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        If Skip_FilterLoadData = False Then
            SQL &= String.Format("  AND Branch_ID IN ({0}) ORDER BY DocumentNumber DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn30.Visible = True
            GridColumn30.VisibleIndex = 13
        End If
        With GridView1
            .Columns("Payee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Payee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .Columns("Amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Amount").SummaryItem.DisplayFormat = "{0:n2}"
        End With

        If GridView1.RowCount > 19 Then
            GridColumn3.Width = 299 - 17
        Else
            GridColumn3.Width = 299
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DtpDocument_ValueChanged(sender As Object, e As EventArgs) Handles dtpDocument.ValueChanged
        GetDocumentNumber()
    End Sub

    Private Sub GetDocumentNumber()
        If btnSave.Text = "&Save" Then
            txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('OR-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM official_receipt WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))
        End If
    End Sub

#Region "Keydown"
    Private Sub CbxPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpPostingDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPostingDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtReferenceNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DPaidAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dPaidAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpORDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpORDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtRemittance_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemittance.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpRemittance_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpRemittance.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub RExplanation_KeyDown(sender As Object, e As KeyEventArgs) Handles rExplanation.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxCash_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCash.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCheck.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCheckNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpCheck.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxAR_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAR.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtARNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtARNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpAR_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpAR.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxOnline_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOnline.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtDeposit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDeposit.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpDeposit_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDeposit.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        If e.Column.FieldName = "Debit" Then
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Debit").ToString = "" Then
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Debit", 0)
            ElseIf IsNumeric(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Debit")) = False Then
                MsgBox(String.Format("Incorrect {1} value for Debit under row {0}.", GridView2.FocusedRowHandle + 1, GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Debit")), MsgBoxStyle.Information, "Info")
                dDebitT.Value = 0
                Exit Sub
            End If
            Dim TotalDebit As Double
            Dim Total_CIB As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebit += CDbl(DT_Account(x)("Debit"))
                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                    Total_CIB += CDbl(DT_Account(x)("Debit"))
                End If
            Next
            dDebitT.Value = TotalDebit
            dAmount.Value = Total_CIB
        ElseIf e.Column.FieldName = "Credit" Then
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Credit").ToString = "" Then
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Credit", 0)
            ElseIf IsNumeric(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Credit")) = False Then
                MsgBox(String.Format("Incorrect {1} value for Credit under row {0}.", GridView2.FocusedRowHandle + 1, GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Credit")), MsgBoxStyle.Information, "Info")
                dCreditT.Value = 0
                Exit Sub
            End If
            Dim TotalCredit As Double
            Dim TotalInterest As Double
            Dim TotalPrincipal As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalCredit += CDbl(DT_Account(x)("Credit"))
                If GridView2.GetRowCellValue(x, "PaidFor") = "UDI" Then
                    TotalInterest += CDbl(DT_Account(x)("Credit"))
                End If
                If GridView2.GetRowCellValue(x, "PaidFor") = "Principal" Then
                    TotalPrincipal += CDbl(DT_Account(x)("Credit"))
                End If
            Next
            dCreditT.Value = TotalCredit
            dTotalInterest.Value = TotalInterest
            dTotalPrincipal.Value = TotalPrincipal
        ElseIf e.Column.FieldName = "Account" Then
            Dim Total_CIB As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                    Total_CIB += CDbl(DT_Account(x)("Debit"))
                End If
            Next
            dAmount.Value = Total_CIB

            cbxAccount.Text = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Account").ToString
            CbxAccount_SelectedIndexChanged(sender, e)
            If cbxAccount.Text.Contains("Fuel and Oil") Then
                MsgBox("Please fill the remarks field with Plate Number.", MsgBoxStyle.Information, "Info")
            End If
        ElseIf e.Column.FieldName = "Department" Then
            cbxDepartment.Text = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Department")
            CbxDepartment_SelectedIndexChanged(sender, e)
            If Auto_Department Then
                For x As Integer = e.RowHandle To GridView2.RowCount - 1
                    If (Not Flag) Then
                        Flag = True
                        GridView2.SetRowCellValue(x, "Department", e.Value)
                        GridView2.SetRowCellValue(x, "Department Code", cbxDepartment.SelectedValue)
                        Flag = False
                    End If
                Next
            End If
        ElseIf e.Column.FieldName = "Business Center" Then
            cbxBusinessCenter.Text = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Business Center")
            CbxBusinessCenter_SelectedIndexChanged(sender, e)
            If Auto_BusinessCenter Then
                For x As Integer = e.RowHandle To GridView2.RowCount - 1
                    If (Not Flag) Then
                        Flag = True
                        GridView2.SetRowCellValue(x, "Business Center", e.Value)
                        GridView2.SetRowCellValue(x, "BusinessCode", cbxBusinessCenter.SelectedValue)
                        Flag = False
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub CbxAccount_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAccount.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxAccount.SelectedItem, DataRowView)
        With GridView2
            .SetRowCellValue(GridView2.FocusedRowHandle, "Account Code", cbxAccount.SelectedValue)
            .SetRowCellValue(GridView2.FocusedRowHandle, "RequiredRemarks", drv("Remarks"))
            .SetRowCellValue(GridView2.FocusedRowHandle, "Type_ID", drv("Type_ID"))
            .SetRowCellValue(GridView2.FocusedRowHandle, "MotherCode", drv("MotherCode"))
        End With
    End Sub

    Private Sub CbxDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDepartment.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Department Code", cbxDepartment.SelectedValue)
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If GridView2.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim Department As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Department"))
                Dim Debit As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Debit"))
                Dim Credit As Double = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Credit"))
                Dim Account As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Account"))
                Dim Required As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("RequiredRemarks"))
                Dim Remarks As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Remarks"))
                If (Debit > 0 And Credit > 0) Or (Account = "" And (Debit > 0 Or Credit > 0)) Or (Required = "True" And Remarks = "") Or (Account <> "" And Department = "") Then
                    e.Appearance.ForeColor = OfficialColor2 'Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnAdd_Account_Click(sender As Object, e As EventArgs) Handles btnAdd_Account.Click
        If cbxPayee.Enabled = False And SalaryLoan And GridView2.RowCount > 0 Then
        Else
            btnRemove_Account.Enabled = True
        End If
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim Row As DataRow = DT_Account.NewRow
        If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
            Row("Account Code") = ""
            Row("Department Code") = ""
            Row("Account") = ""
            Row("Business Center") = ""
            Row("Department") = ""
            Row("Debit") = 0
            Row("Credit") = 0
            Row("PaidFor") = ""
            Row("Remarks") = ""
            Row("RequiredRemarks") = ""
            Row("AR_DetailsID") = 0
            Row("AR_DocumentNumber") = ""
            Row("AR_Payable") = 0
            Row("BusinessCode") = ""
            Row("Type_ID") = 0
            If cbxPayee.Enabled = False And SalaryLoan And GridView2.RowCount > 0 Then
                Row("CreditNumber") = GridView2.GetRowCellValue(GridView2.FocusedRowHandle - 1, "CreditNumber")
            Else
                Row("CreditNumber") = ""
            End If
            Row("MotherCode") = ""
            DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
        Else
            Row("Account Code") = ""
            Row("Department Code") = ""
            Row("Account") = ""
            Row("Business Center") = DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode")))
            Row("Department") = ""
            Row("Debit") = 0
            Row("Credit") = 0
            Row("PaidFor") = ""
            Row("Remarks") = ""
            Row("RequiredRemarks") = ""
            Row("AR_DetailsID") = 0
            Row("AR_DocumentNumber") = ""
            Row("AR_Payable") = 0
            Row("BusinessCode") = drv("BusinessCode")
            Row("Type_ID") = 0
            Row("CreditNumber") = ValidateComboBox(cbxPayee)
            Row("MotherCode") = ""
            DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
        End If

        Dim TotalDebit As Double
        Dim TotalCredit As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
        Next
        If GridView2.RowCount > 7 Then
            GridColumn32.Width = 226 - 17
        Else
            GridColumn32.Width = 226
        End If
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
    End Sub

    Private Sub BtnRemove_Account_Click(sender As Object, e As EventArgs) Handles btnRemove_Account.Click
        If DT_Account.Rows.Count = 0 Then
            Exit Sub
        End If
        If GridView2.GetFocusedRowCellValue("AR_DetailsID") > 0 And cbxPayee.Enabled = False Then
            MsgBox("Removing this selected row is not allowed for the reason that this is a part of accounts receivable that was process with this official receipt.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        DT_Account.Rows.RemoveAt(GridView2.FocusedRowHandle)

        Dim TotalDebit As Double
        Dim TotalCredit As Double
        Dim Total_CIB As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                Total_CIB += CDbl(DT_Account(x)("Debit"))
            End If
        Next
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB
        If GridView2.RowCount > 7 Then
            GridColumn32.Width = 226 - 17
        Else
            GridColumn32.Width = 226
        End If

        If GridView2.RowCount = 0 Then
            btnRemove_Account.Enabled = False
        End If
    End Sub

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

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnAdd.Enabled = False
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
            btnAttach.Visible = False
            If btnSave.Text = "&Save" And btnSave.Enabled Then
                btnPrint.Enabled = False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            If btnSave.Enabled And cbxPayee.SelectedIndex > -1 Then
            Else
                Clear(False)
            End If
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnAttach.Visible = True
            btnPrint.Enabled = True
            btnValidate.Visible = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If btnSave.DialogResult = DialogResult.OK Then
                If MsgBoxYes("Would you like to fix the Save Button?") = MsgBoxResult.Yes Then
                    btnSave.DialogResult = DialogResult.None
                    Exit Sub
                End If
            End If
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                PanelEx10.Enabled = True
                PanelEx2.Enabled = True
                GridView2.OptionsBehavior.Editable = True
                cbxPayee.Enabled = True
                Clear(False)
                FirstLoad = True
                LoadPayee()
                FirstLoad = False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Public Sub Clear(TriggerLoadData As Boolean)
        DTS = False
        lblTotalInterest.Visible = False
        lblTotalPrincipal.Visible = False
        dTotalInterest.Visible = False
        dTotalPrincipal.Visible = False
        GridControl3.DataSource = Nothing
        SaveIsTriggeredAlready = False
        SalaryLoan = False
        ForcedAvailed = False
        SalaryLoan_Loading = False
        RemoveRPPDFromBalanceLedger = False
        btnSave.Text = "&Save"
        PanelEx10.Enabled = True
        PanelEx2.Enabled = True
        GridView2.OptionsBehavior.Editable = True
        cbxPayee.Enabled = True
        cbxBank.Enabled = True
        dtpPostingDate.Enabled = True
        cbxAvailed.Enabled = True
        dPaidAmount.Enabled = True
        dtpORDate.Enabled = True
        btnAdd_Account.Enabled = True
        btnRemove_Account.Enabled = True
        btnValidate.Visible = False
        dPaidAmount.Enabled = True
        cbxCash.Checked = True
        dtpPostingDate.Value = Date.Now
        dtpORDate.Value = Date.Now
        dtpDocument.Value = Date.Now
        lblProduct.Text = ""
        rExplanation.Text = ""
        txtReferenceNumber.Text = ""
        dPayable.Value = 0
        dBalanceLedger.Value = 0
        dPaidAmount.Value = 0
        dAmount.Value = 0
        TotalWaive = 0
        TotalWaiveRPPD = 0
        If cbxBank.Enabled Then
            cbxBank.SelectedIndex = -1
        End If
        cbxLoans.Enabled = True
        cbxClosed.Enabled = True
        cbxCash.Enabled = True
        cbxCheck.Enabled = True
        cbxOnline.Enabled = True
        cbxRemittance.Enabled = True
        dtpRemittance.Enabled = False
        cbxCheckNumber.Enabled = False
        dtpCheck.Enabled = False
        txtDeposit.Enabled = False
        dtpDeposit.Enabled = False

        'cbxAR.Enabled = True
        'dtpAR.Enabled = True
        cbxPayee.Text = ""
        Dim SQL As String = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', 0 AS 'AR_DetailsID', '' AS 'AR_DocumentNumber', 0 AS 'AR_Payable', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'CreditNumber', '' AS 'MotherCode'"
        DT_Account = DataSource(SQL)
        GridControl2.DataSource = DT_Account
        dDebitT.Value = 0
        dCreditT.Value = 0
        If GridView2.RowCount > 7 Then
            GridColumn32.Width = 226 - 17
        Else
            GridColumn32.Width = 226
        End If
        Availed = 0
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnCheck.Visible = False
        btnApprove.Visible = False
        LastPaymentBefore = ""
        cbxRemittance.Checked = False

        btnLedger.Enabled = False
        btnCalculator.Enabled = False
        btnWaive.Enabled = False
        btnEarly.Enabled = False
        btnDeductBalance.Enabled = False
        btnEarlySettlement.Visible = False

        cbxPreparedBy.SelectedValue = Empl_ID
        txtChecked.Text = ""
        txtApproved.Text = ""
        btnDisapprove.Visible = False
        GetDocumentNumber()
        btnCalculatorV2.Visible = False
        btnCalculator.Visible = True
        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnSave.DialogResult = DialogResult.OK Or SaveIsTriggeredAlready Then
        Else
            If vSave Then
            Else
                MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If (cbxPayee.Text = "" Or cbxPayee.SelectedIndex = -1) And cbxPayee.Enabled = True Then
                MsgBox("Please select/fill Payor.", MsgBoxStyle.Information, "Info")
                cbxPayee.DroppedDown = True
                Exit Sub
            End If
            If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
                MsgBox("Please select Bank.", MsgBoxStyle.Information, "Info")
                cbxBank.DroppedDown = True
                Exit Sub
            End If
            If dtpPostingDate.CustomFormat = "" Or Format(dtpPostingDate.Value, "yyyy-MM-dd") = "0001-01-01" Then
                MsgBox("Please fill Posting Date.", MsgBoxStyle.Information, "Info")
                dtpPostingDate.Focus()
                Exit Sub
            End If
            If dtpORDate.CustomFormat = "" Or Format(dtpORDate.Value, "yyyy-MM-dd") = "0001-01-01" Then
                MsgBox("Please fill OR Date.", MsgBoxStyle.Information, "Info")
                dtpORDate.Focus()
                Exit Sub
            End If
            If Format(DateValue(dtpORDate.Value), "yyyy-MM-dd") = Format(DateValue(dtpPostingDate.Value), "yyyy-MM-dd") Then
            Else
                If MsgBox("Posting Date and OR Date are not on the same date, would you like to proceed?.", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
            End If
            If cbxCheck.Checked And cbxCheckNumber.Text.Trim = "" Then
                MsgBox("Please select or fill check number.", MsgBoxStyle.Information, "Info")
                cbxCheckNumber.Focus()
                Exit Sub
            End If
            If rExplanation.Text.Trim = "" Then
                MsgBox("Please fill explanation.", MsgBoxStyle.Information, "Info")
                rExplanation.Focus()
                Exit Sub
            End If
            If GridView2.RowCount = 0 Then
                MsgBox("Please add Debit and Credit.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If dDebitT.Value <> dPaidAmount.Value Then
                MsgBox("Total Debit is not equal with Entered Amount, Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
            Dim TheSameCashInBank As Boolean
            Dim CashInBankExist As Boolean
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                If (CDbl(DT_Account(x)("Debit")) > 0 And CDbl(DT_Account(x)("Credit")) > 0) Or (DT_Account(x)("Account") = "" And (CDbl(DT_Account(x)("Debit")) > 0 Or CDbl(DT_Account(x)("Credit")) > 0)) Or (DT_Account(x)("RequiredRemarks") = "True" And DT_Account(x)("Remarks") = "") Or (DT_Account(x)("Account") <> "" And DT_Account(x)("Department") = "") Then
                    MsgBox("Please check your data under row " & x + 1, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If DT_Account(x)("Type_ID") = 5 Then
                    Dim Budget As Double = DataObject(String.Format("SELECT IF('{0}' = '01' OR '{0}' = '07',M01,IF('{0}' = '02' OR '{0}' = '08',M02,IF('{0}' = '03' OR '{0}' = '09',M03,IF('{0}' = '04' OR '{0}' = '10',M04,IF('{0}' = '05' OR '{0}' = '11',M05,IF('{0}' = '06' OR '{0}' = '12',M06,0)))))) FROM financial_plan WHERE AccountCode = '{1}' AND `Year` = YEAR('{2}') AND BranchID = '{3}' AND IF('{0}' > '06',Half = 2,Half=1);", If(cbxRemittance.Checked, Format(dtpRemittance.Value, "MM"), If(cbxOnline.Checked, Format(dtpDeposit.Value, "MM"), If(cbxAR.Checked, Format(dtpAR.Value, "MM"), Format(dtpORDate.Value, "MM")))), DT_Account(x)("Account Code"), FormatDatePicker(If(cbxRemittance.Checked, dtpRemittance, If(cbxOnline.Checked, dtpDeposit, If(cbxAR.Checked, dtpAR, dtpORDate)))), Branch_ID))
                    If Budget > 0 Then
                        Dim Used As Double = DataObject(String.Format("SELECT IFNULL(SUM(Amount),0) FROM accounting_entry WHERE AccountCode = '{0}' AND MONTH(ORDate) = MONTH('{1}') AND YEAR(ORDate) = YEAR('{1}') AND `status` = 'ACTIVE' AND EntryType = 'DEBIT' AND Branch_ID = '{2}';", DT_Account(x)("Account Code"), FormatDatePicker(If(cbxRemittance.Checked, dtpRemittance, If(cbxOnline.Checked, dtpDeposit, If(cbxAR.Checked, dtpAR, dtpORDate)))), Branch_ID))
                        If Budget < Used + DT_Account(x)("Debit") Then
                            If MsgBoxYes(String.Format("{0} exceed the financial plan of {1}, would you like to proceed?", DT_Account(x)("Account"), FormatNumber(Budget, 2))) = MsgBoxResult.Yes Then
                            Else
                                Exit Sub
                            End If
                        End If
                    End If
                End If
                If drv_B("AccountCode") = "" Or drv_B("AccountCode") = DT_Account(x)("Account Code") Then
                    TheSameCashInBank = True
                End If
                If DT_Account(x)("MotherCode") = "111000" Then
                    CashInBankExist = True
                End If
            Next
            If TheSameCashInBank = False Then
                If MsgBoxYes(String.Format("Selected Bank is not the same with {0}, would you like to proceed?", If(CashInBankExist, "Selected Cash In Bank", "Entries"))) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            If FormatNumber(dDebitT.Value, 2) <> FormatNumber(dCreditT.Value, 2) Then
                MsgBox("Debit and Credit is not equal, please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If cbxPreparedBy.Text = "" Or cbxPreparedBy.SelectedIndex = -1 Then
                MsgBox("Please select Prepared By.", MsgBoxStyle.Information, "Info")
                cbxPreparedBy.DroppedDown = True
                Exit Sub
            End If
            If dAmount.Value = 0 And drv("CVforJV") = 0 Then
                MsgBox("No Cash In Bank for Debit, please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim Open As String = DataObject(String.Format("SELECT IF('{2}' = 'Jan',Jan,IF('{2}' = 'Feb',Feb,IF('{2}' = 'Mar',Mar,IF('{2}' = 'Apr',Apr,IF('{2}' = 'May',May,IF('{2}' = 'Jun',Jun,IF('{2}' = 'Jul',Jul,IF('{2}' = 'Aug',Aug,IF('{2}' = 'Sep',Sep,IF('{2}' = 'Oct',`Oct`,IF('{2}' = 'Nov',Nov,IF('{2}' = 'Dec',`Dec`,'X')))))))))))) FROM accounting_period WHERE Branch = '{0}' AND `status` = 'ACTIVE' AND `Year` = '{1}';", Branch_Code, Format(If(cbxRemittance.Checked, dtpRemittance.Value, If(cbxOnline.Checked, dtpDeposit.Value, If(cbxAR.Checked, dtpAR.Value, dtpORDate.Value))), "yyyy"), Format(If(cbxRemittance.Checked, dtpRemittance.Value, If(cbxOnline.Checked, dtpDeposit.Value, If(cbxAR.Checked, dtpAR.Value, dtpORDate.Value))), "MMM")))
            If If(Open = "", "Open", Open) = "Open" Then
            Else
                MsgBox(String.Format("Accounting Period for your branch is already {0}. Transaction with this date is not allowed.", If(Open = "Lock", "Locked", If(Open = "Close", "Closed", Open))), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If btnSave.Text = "&Save" Then
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Dim Exist As String = DataObject(String.Format("SELECT DocumentNumber FROM official_receipt WHERE Payee_ID = '{0}' AND ORDate = '{1}' AND Amount = '{2}' AND `status` = 'ACTIVE' AND JVNumber = '';", cbxPayee.SelectedValue, Format(dtpORDate.Value, "yyyy-MM-dd"), dPaidAmount.Value))
                    If Exist = "" Then
                    Else
                        If MsgBox(String.Format("Payee {0} already have a payment of {1} for Document Number {2} and OR Date {3}, Are you sure you want to proceed?", cbxPayee.Text, dPaidAmount.Text, Exist, dtpORDate.Text), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If

                    Cursor = Cursors.WaitCursor
                    Code = GenerateOTAC()
                    '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                    If Auto_Notification Then
                        CheckNotification(Code, False)
                    End If
                    '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                    Code_Check = Code
                    Dim Subject As String = "Official Receipt [" & txtDocumentNumber.Text & "]"
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    'A C K N O W L E D G E   R E C E I P T************************************************************************************************************************
                    Dim Msg As String = String.Format("Good day {0}," & vbCrLf, cbxPayee.Text)
                    Msg &= String.Format("The amount of {1} is acknowledged given on {2} and received by {3}." & vbCrLf, cbxPayee.Text, dDebitT.Text, If(cbxRemittance.Checked, dtpRemittance.Text, If(cbxOnline.Checked, dtpDeposit.Text, If(cbxAR.Checked, dtpAR.Text, dtpORDate.Text))), cbxPreparedBy.Text)
                    Msg &= "Thank you!"
                    If cbxPayee.SelectedIndex = -1 Then
                        GoTo Here
                    End If
                    '******* SEND SMS *********************************************************************************
                    If drv("Mobile_B") = "" Then
                    Else
                        SendSMS(drv("Mobile_B"), Msg, True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If drv("Email_B") = "" And drv("Email_C") = "" Then
                    Else
                        SendEmail(If(drv("Email_B") = "", drv("Email_C"), drv("Email_B") & If(drv("Email_C") = "", "", "," & drv("Email_C"))), Subject, Msg, False, False, False, 0, "", "")
                    End If
                    'A C K N O W L E D G E   R E C E I P T************************************************************************************************************************
Here:
                    GetDocumentNumber()
                    If DocumentNumberExist("official_receipt", txtDocumentNumber.Text) Then
                        Exit Sub
                    End If
                    Dim SQL As String = "INSERT INTO official_receipt SET"
                    SQL &= String.Format(" Payee_ID = '{0}', ", ValidateComboBox(cbxPayee))
                    SQL &= String.Format(" Payee_Type = '{0}', ", If(cbxPayee.SelectedIndex = -1, "", drv("Type")))
                    SQL &= String.Format(" Payee = '{0}', ", cbxPayee.Text.InsertQuote)
                    SQL &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpORDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" Paid = '{0}', ", dPaidAmount.Value)
                    SQL &= String.Format(" Payable = '{0}', ", dPayable.Value)
                    SQL &= String.Format(" LedgerBalance = '{0}', ", dBalanceLedger.Value)
                    SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                    SQL &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote)
                    SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                    SQL &= " CheckedID = '0', "
                    SQL &= " ApprovedID = '0', "
                    SQL &= " OTAC_Approve = '', "
                    SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                    SQL &= String.Format(" Type_Payment = '{0}', ", If(cbxCash.Checked, "CASH", If(cbxCheck.Checked, "CHECK", If(cbxOnline.Checked, "ONLINE", "NA"))))
                    SQL &= String.Format(" Remittance = '{0}', ", txtRemittance.Text)
                    SQL &= String.Format(" RemittanceDate = '{0}', ", FormatDatePicker(dtpRemittance))
                    SQL &= String.Format(" CheckNumber = '{0}', ", cbxCheckNumber.Text)
                    SQL &= String.Format(" CheckDate = '{0}', ", FormatDatePicker(dtpCheck))
                    SQL &= String.Format(" ARNumber = '{0}', ", txtARNumber.Text)
                    SQL &= String.Format(" ARDate = '{0}', ", FormatDatePicker(dtpAR))
                    SQL &= String.Format(" DepositNumber = '{0}', ", txtDeposit.Text)
                    SQL &= String.Format(" DepositDate = '{0}', ", FormatDatePicker(dtpDeposit))
                    SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                    SQL &= String.Format(" CheckID = '{0}', ", CheckID)
                    SQL &= String.Format(" OldAccount = '{0}', ", If(cbxClosed.Checked, 1, 0))
                    SQL &= String.Format(" Banking = '{0}', ", If(cbxAvailed.Checked, 1, 0))
                    SQL &= String.Format(" EarlySettlement = '{0}', ", If(btnEarlySettlement.Visible, 1, 0))
                    SQL &= String.Format(" ForcedAvailed = {0}, ", ForcedAvailed)
                    SQL &= String.Format(" LastPaymentBefore = '{0}', ", Format(LastPayment, "yyyy-MM-dd"))
                    SQL &= String.Format(" TotalRPPD = {0}, ", TotalRPPD)
                    SQL &= String.Format(" TotalInterest = {0}, ", TotalInterest)
                    SQL &= String.Format(" TotalPayment = {0}, ", TotalPayment)
                    SQL &= String.Format(" TotalWaivePenalty = {0}, ", TotalWaivePenalty)
                    SQL &= String.Format(" TotalUnpaidPenalty = {0}, ", TotalUnpaidPenalty)
                    SQL &= String.Format(" TotalWaive = {0}, ", TotalWaive)
                    SQL &= String.Format(" TotalWaiveRPPD = {0}, ", TotalWaiveRPPD)
                    If cbxBank.SelectedValue <> BankID And BankID <> 0 Then
                        SQL &= " DTS = '1', "
                    End If
                    SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)
                    If btnEarlySettlement.Visible Then
                        SQL &= String.Format("UPDATE credit_earlysettlement SET early_status = 'PAID', Paid = Paid + {3}, ORNumber = '{0}' WHERE CreditNumber = '{1}' AND `status` = 'ACTIVE' AND early_status IN ('PENDING','PAID') AND IF(early_status = 'PAID',ORNumber != '',ORNumber = '') AND AsOf <= '{2}';", txtDocumentNumber.Text, ValidateComboBox(cbxPayee), Format(If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))), "yyyy-MM-dd"), dPaidAmount.Value)
                    End If
                    SavingLog = ""
                    For x As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SavingLog = SavingLog & "[" & GridView2.GetRowCellValue(x, "Account") & " P" & If(CDbl(DT_Account(x)("Debit")) > 0, FormatNumber(DT_Account(x)("Debit"), 2) & " (DEBIT)", FormatNumber(DT_Account(x)("Credit"), 2) & " (CREDIT)") & "]"

                            SQL &= "INSERT INTO or_details SET"
                            SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQL &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                            SQL &= String.Format(" AR_DetailsID = '{0}', ", GridView2.GetRowCellValue(x, "AR_DetailsID"))
                            SQL &= String.Format(" AR_DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "AR_DocumentNumber"))
                            SQL &= String.Format(" AR_Payable = '{0}', ", GridView2.GetRowCellValue(x, "AR_Payable"))
                            SQL &= String.Format(" CreditNumber = '{0}', ", GridView2.GetRowCellValue(x, "CreditNumber"))
                            SQL &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            If GridView2.GetRowCellValue(x, "AR_DocumentNumber") = "" Then
                            Else
                                DataObject(String.Format("UPDATE accounts_receivable SET Paid = Paid + '{1}', `AR_Status` = '{2}' WHERE DocumentNumber = '{0}';", GridView2.GetRowCellValue(x, "AR_DocumentNumber"), CDbl(GridView2.GetRowCellValue(x, "Credit")), If(CDbl(GridView2.GetRowCellValue(x, "Credit")) >= CDbl(GridView2.GetRowCellValue(x, "AR_Payable")), "FULLY PAID", "PARTIALLY PAID")))
                                SQL &= String.Format("UPDATE ar_details SET Paid = Paid + '{1}' WHERE ID = '{0}'; ", GridView2.GetRowCellValue(x, "AR_DetailsID"), CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            End If

                            'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                            Dim SQLv2 As String = ""
                            If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to")) Then
                                Dim APNumber As String = ""
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))

                                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                    APNumber = DataObject(String.Format("SELECT CONCAT('DT-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_to WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                    SQLv2 &= " INSERT INTO due_to SET"
                                Else
                                    APNumber = DataObject(String.Format("SELECT CONCAT('AP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                    SQLv2 &= " INSERT INTO accounts_payable SET"
                                End If
                                If cbxPayee.Text = "" Then
                                    SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                    SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                Else
                                    SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, If(SalaryLoan, GridView2.GetRowCellValue(x, "CreditNumber"), ValidateComboBox(cbxPayee)), BranchTagged))
                                    SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, cbxPayee.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                End If
                                SQLv2 &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                                SQLv2 &= String.Format(" Terms = '{0}', ", 0)
                                SQLv2 &= String.Format(" Delivery_Date = '{0}', ", FormatDatePicker(dtpDocument))
                                SQLv2 &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                SQLv2 &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote & " - " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                SQLv2 &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                                SQLv2 &= " CheckedID = '0', "
                                SQLv2 &= " ApprovedID = '0', "
                                SQLv2 &= " OTAC_Approve = '', "
                                SQLv2 &= String.Format(" OTAC_Check = '{0}', ", Code)
                                SQLv2 &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                                SQLv2 &= String.Format(" JVNumberV2 = '{0}', ", txtDocumentNumber.Text)
                                SQLv2 &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                    SQLv2 &= "INSERT INTO dt_details SET"
                                Else
                                    SQLv2 &= "INSERT INTO ap_details SET"
                                End If
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Payable") Then
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                Dim APNumber As String = DataObject(String.Format("SELECT CONCAT('LP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM loans_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                SQLv2 &= " INSERT INTO loans_payable SET"
                                If cbxPayee.Text = "" Then
                                    SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                    SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                Else
                                    SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, If(SalaryLoan, GridView2.GetRowCellValue(x, "CreditNumber"), ValidateComboBox(cbxPayee)), BranchTagged))
                                    SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, cbxPayee.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                End If
                                SQLv2 &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                                SQLv2 &= String.Format(" Terms = '{0}', ", 0)
                                SQLv2 &= String.Format(" Delivery_Date = '{0}', ", FormatDatePicker(dtpDocument))
                                SQLv2 &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                SQLv2 &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote & " - " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                SQLv2 &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                                SQLv2 &= " CheckedID = '0', "
                                SQLv2 &= " ApprovedID = '0', "
                                SQLv2 &= " OTAC_Approve = '', "
                                SQLv2 &= String.Format(" OTAC_Check = '{0}', ", Code)
                                SQLv2 &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                                SQLv2 &= String.Format(" JVNumberV2 = '{0}', ", txtDocumentNumber.Text)
                                SQLv2 &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                                SQLv2 &= "INSERT INTO lp_details SET"
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code").ToString))
                                Dim APNumber As String = DataObject(String.Format("SELECT CONCAT('DF-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_from WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                SQLv2 &= " INSERT INTO due_from SET"
                                If cbxPayee.Text = "" Then
                                    SQLv2 &= String.Format(" PayorID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                    SQLv2 &= String.Format(" Payor = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payor_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                Else
                                    SQLv2 &= String.Format(" PayorID = '{0}', ", If(BranchTagged = 999, If(SalaryLoan, GridView2.GetRowCellValue(x, "CreditNumber"), ValidateComboBox(cbxPayee)), BranchTagged))
                                    SQLv2 &= String.Format(" Payor = '{0}', ", If(BranchTagged = 999, cbxPayee.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payor_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                End If
                                SQLv2 &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                                SQLv2 &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                SQLv2 &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote & " - " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                SQLv2 &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                                SQLv2 &= " CheckedID = '0', "
                                SQLv2 &= " ApprovedID = '0', "
                                SQLv2 &= " OTAC_Approve = '', "
                                SQLv2 &= String.Format(" OTAC_Check = '{0}', ", Code)
                                SQLv2 &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                                SQLv2 &= String.Format(" JVNumberV2 = '{0}', ", txtDocumentNumber.Text)
                                SQLv2 &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                                SQLv2 &= "INSERT INTO df_details SET"
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            End If
                            If SQLv2 = "" Then
                            Else
                                DataObject(SQLv2)
                            End If
                            'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                        End If
                    Next
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    If TotalWaive + TotalWaiveRPPD > 0 Then
                        SQL &= String.Format("UPDATE accounting_entry SET ORNum = '{0}', CVNumber = '{0}', Amount = IF(PaidFor = 'Penalty-W',0,Amount), ORDate = '{2}', `status` = 'ACTIVE' WHERE IF(PaidFor = 'Penalty-W',`status` = 'WAITING' AND PostStatus = 'PENDING',`status` = 'WAITING' AND PostStatus = 'POSTED') AND PaidFor IN ('Penalty-W','RPPD-W') AND CVNumber = '' AND ReferenceN = '{1}';", txtDocumentNumber.Text, ValidateComboBox(cbxPayee), Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    End If
                    Dim WithPenaltySaGrid As Boolean
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                            If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                SQL &= " EntryType = 'DEBIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            Else
                                SQL &= " EntryType = 'CREDIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            End If
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            If GridView2.GetRowCellValue(x, "PaidFor") = "" And GridView2.GetRowCellValue(x, "Account Code") <> "" Then
                                If cbxBank.SelectedValue <> BankID And BankID <> 0 Then
                                    SQL &= " PaidFor = '', "
                                Else
                                    SQL &= " PaidFor = 'Other Income', "
                                End If
                            Else
                                SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                            End If
                            If GridView2.GetRowCellValue(x, "PaidFor") = "Penalty" Or GridView2.GetRowCellValue(x, "PaidFor") = "DTS Penalty" Then
                                SQL &= String.Format(" PenaltyPayable = '{0}', ", NegativeNotAllowed(dPenalty_P - CDbl(GridView2.GetRowCellValue(x, "Credit"))))
                                dPenalty_P = NegativeNotAllowed(dPenalty_P - CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                WithPenaltySaGrid = True
                            End If
                            SQL &= String.Format(" ReferenceN = '{0}', ", If(SalaryLoan, GridView2.GetRowCellValue(x, "CreditNumber"), ValidateComboBox(cbxPayee)))
                            SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                            If (SalaryLoan Or If(cbxPayee.SelectedIndex > -1, drv("Product").ToString.ToUpper.Contains("SALARY"), 1)) And GridView2.GetRowCellValue(x, "PaidFor") = "Principal" Then
                                If CDbl(GridView2.GetRowCellValue(x, "Credit")) >= DataObject(String.Format("SELECT Principal_Balance('{0}');", GridView2.GetRowCellValue(x, "CreditNumber"))) Then
                                    SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'CLOSED', ClosedDate = '{1}' WHERE CreditNumber = '{0}' AND PaymentRequest = 'RELEASED';", GridView2.GetRowCellValue(x, "CreditNumber"), Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                End If
                            End If
                        End If
                    Next

                    If dPenalty_P > 0 And WithPenaltySaGrid = False Then
                        SQL &= "INSERT INTO accounting_entry SET"
                        SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                        SQL &= " EntryType = 'CREDIT',"
                        SQL &= " Payable = 0, "
                        SQL &= " Amount = 0, "
                        SQL &= " AccountCode = '', "
                        SQL &= " MotherCode = '', "
                        SQL &= " BusinessCode = '', "
                        SQL &= " DepartmentCode = '', "
                        SQL &= " PaidFor = 'Penalty', "
                        SQL &= String.Format(" PenaltyPayable = '{0}', ", dPenalty_P)
                        SQL &= String.Format(" ReferenceN = '{0}', ", If(SalaryLoan, "", ValidateComboBox(cbxPayee)))
                        SQL &= " Remarks = '', "
                        SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                        SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    End If

                    If SalaryLoan Then
                        For x As Integer = 0 To DT_SalaryLoan.Rows.Count - 1
                            If CDbl(DT_SalaryLoan(x)("Amount")) > 0 Then
                                SQL &= "INSERT INTO or_salary_details SET"
                                SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                                SQL &= String.Format(" CreditNumber = '{0}', ", DT_SalaryLoan(x)("CreditNumber"))
                                SQL &= String.Format(" Amount = '{0}', ", DT_SalaryLoan(x)("Amount"))
                                SQL &= String.Format(" Availed = '{0}', ", DT_SalaryLoan(x)("Availed"))
                                SQL &= String.Format(" dRPPD_P = '{0}', ", DT_SalaryLoan(x)("dRPPD_P"))
                                SQL &= String.Format(" TotalRPPD_Payable = '{0}', ", DT_SalaryLoan(x)("TotalRPPD_Payable"))
                                SQL &= String.Format(" TotalRPPD = '{0}';", DT_SalaryLoan(x)("TotalRPPD"))
                                'FOR DISCOUNT OR AVAILED
                                If DT_SalaryLoan(x)("Availed") > 0 Then 'For checking wala ma apil ang availed wrong condition || TotalRPPD - is the total Paid and Availed RPPD
                                    SQL &= "INSERT INTO accounting_entry SET"
                                    SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                    SQL &= String.Format(" ReferenceN = '{0}', ", DT_SalaryLoan(x)("CreditNumber"))
                                    SQL &= " EntryType = 'CREDIT',"
                                    SQL &= " AccountCode = '', " 'Availed
                                    SQL &= " MotherCode = '', " 'Availed
                                    SQL &= String.Format(" Payable = '{0}', ", DT_SalaryLoan(x)("dRPPD_P"))
                                    SQL &= String.Format(" Amount = '{0}', ", DT_SalaryLoan(x)("Availed"))
                                    SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                                    SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD")
                                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                                End If
                            End If
                        Next
                    Else
                        'FOR DISCOUNT OR AVAILED
                        RPPDCompute(True)
                        If Availed - TotalWaiveRPPD > 0 And EarlySettlement = False Then 'For checking wala ma apil ang availed wrong condition || TotalRPPD - is the total Paid and Availed RPPD
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= " AccountCode = '', " 'Availed
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= String.Format(" Payable = '{0}', ", dRPPD_P)
                            SQL &= String.Format(" Amount = '{0}', ", Availed - TotalWaiveRPPD)
                            SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                            SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD")
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                        If EarlySettlement And If(btnEarlySettlement.Visible, dPaidAmount.Value >= dPayable.Value, 1) Then
                            'RPPD
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= String.Format(" AccountCode = '{0}', ", "") 'Interest Income-Past Due
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= String.Format(" Payable = '{0}', ", RPPD_Amount_Early)
                            SQL &= String.Format(" Amount = '{0}', ", RPPD_Amount_Early)
                            SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                            SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD" & " [Discount]")
                            SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                            'UDI
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= String.Format(" AccountCode = '{0}', ", "") 'Interest Income-Current
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= String.Format(" Payable = '{0}', ", UDI_Amount_Early)
                            SQL &= String.Format(" Amount = '{0}', ", UDI_Amount_Early)
                            SQL &= String.Format(" PaidFor = '{0}', ", "UDI")
                            SQL &= String.Format(" Remarks = '{0}', ", "UDI Payment" & " [Discount]")
                            SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                    End If
                    'ACCOUNTING ENTRY ***********************************************************************************************************

                    If From_Check Then
                        If cbxCheck.Checked Then
                            SQL &= String.Format("UPDATE check_received SET `status` = 'CLEARED', remarks = CONCAT(remarks, ' [', 'Cleared Check',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", ValidateComboBox(cbxPayee), cbxCheckNumber.Text, CheckID)
                        ElseIf cbxCash.Checked Then
                            If dPaidAmount.Value >= dPayable.Value Then
                                SQL &= String.Format("UPDATE check_received SET `status` = 'PAID', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", ValidateComboBox(cbxPayee), cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dPaidAmount.Text & " Cash", "Paid " & dPaidAmount.Text & " Cash"))
                            Else
                                SQL &= String.Format("UPDATE check_received SET `status` = 'PARTIAL', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", ValidateComboBox(cbxPayee), cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dPaidAmount.Text & " Cash", "Paid " & dPaidAmount.Text & " Cash"))
                            End If
                        ElseIf cbxOnline.Checked Then
                            If dPaidAmount.Value >= dPayable.Value Then
                                SQL &= String.Format("UPDATE check_received SET `status` = 'PAID', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", ValidateComboBox(cbxPayee), cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dPaidAmount.Text & " Online", "Paid " & dPaidAmount.Text & " Online"))
                            Else
                                SQL &= String.Format("UPDATE check_received SET `status` = 'PARTIAL', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", ValidateComboBox(cbxPayee), cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dPaidAmount.Text & " Online", "Paid " & dPaidAmount.Text & " Online"))
                            End If
                        End If
                    ElseIf cbxCheck.Checked Then
                        SQL &= String.Format("UPDATE check_received SET `status` = 'CLEARED', remarks = CONCAT(remarks, ' [', 'Cleared Check',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND `Date` = '{2}' AND `status` NOT IN ('PENDING','CANCELLED','DELETED');", ValidateComboBox(cbxPayee), cbxCheckNumber.Text, Format(dtpCheck.Value, "yyyy-MM-dd"))
                    End If
                    If (EarlySettlement And (btnEarlySettlement.Visible AndAlso dPaidAmount.Value >= dPayable.Value)) Or dBalanceLedger.Value + dPenalty <= dPaidAmount.Value Then
                        SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'CLOSED', ClosedDate = '{1}' WHERE CreditNumber = '{0}' AND PaymentRequest = 'RELEASED';", ValidateComboBox(cbxPayee), Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    End If

                    DataObject(SQL)

                    Cursor = Cursors.Default
                    Logs("Official Receipt", "Save", String.Format("Add new Official Receipt for {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), ComputationLog & "                       VS                       " & SavingLog, "", "", "")
                    If From_Check Then
                        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                        SaveIsTriggeredAlready = True
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.PerformClick()
                    Else
                        PanelEx10.Enabled = True
                        PanelEx2.Enabled = True
                        GridView2.OptionsBehavior.Editable = True
                        cbxPayee.Enabled = True
                        LoadPayee()
                        Clear(True)
                        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    End If
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM official_receipt WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
                    If CancelledID > 0 Then
                        MsgBox("This transaction was recently CANCELLED/DISAPPROVED, modification is not allowed anymore.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Dim Reason As String 'Reason for change
                    If FrmReason.ShowDialog = DialogResult.OK Then
                        Reason = FrmReason.txtReason.Text
                    Else
                        Exit Sub
                    End If

                    Cursor = Cursors.WaitCursor
                    Code = GenerateOTAC()
                    '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                    If Auto_Notification Then
                        UpdateNotification(Code, False)
                    End If
                    '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                    Dim SQL As String = "UPDATE official_receipt SET"
                    SQL &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpORDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" Paid = '{0}', ", dPaidAmount.Value)
                    SQL &= String.Format(" Payable = '{0}', ", dPayable.Value)
                    SQL &= String.Format(" LedgerBalance = '{0}', ", dBalanceLedger.Value)
                    SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote)
                    SQL &= String.Format(" Type_Payment = '{0}', ", If(cbxCash.Checked, "CASH", If(cbxCheck.Checked, "CHECK", If(cbxOnline.Checked, "ONLINE", "NA"))))
                    SQL &= String.Format(" Remittance = '{0}', ", txtRemittance.Text)
                    SQL &= String.Format(" RemittanceDate = '{0}', ", FormatDatePicker(dtpRemittance))
                    SQL &= String.Format(" CheckNumber = '{0}', ", cbxCheckNumber.Text)
                    SQL &= String.Format(" CheckDate = '{0}', ", FormatDatePicker(dtpCheck))
                    SQL &= String.Format(" ARNumber = '{0}', ", txtARNumber.Text)
                    SQL &= String.Format(" ARDate = '{0}', ", FormatDatePicker(dtpAR))
                    SQL &= String.Format(" DepositNumber = '{0}', ", txtDeposit.Text)
                    If txtChecked.Text = "" Then
                        SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                    ElseIf txtApproved.Text = "" Then
                        SQL &= String.Format(" OTAC_Approve = '{0}', ", Code)
                    End If
                    SQL &= String.Format(" Banking = '{0}', ", If(cbxAvailed.Checked, 1, 0))
                    SQL &= String.Format(" ForcedAvailed = {0}, ", ForcedAvailed)
                    SQL &= String.Format(" DepositDate = '{0}' ", FormatDatePicker(dtpDeposit))
                    SQL &= String.Format(" WHERE ID = '{0}';", ID)
                    Dim SQLv3 As String = ""
                    SQLv3 &= String.Format(" UPDATE accounts_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE due_from SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE due_to SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE loans_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    DataObject(SQLv3)
                    SQL &= String.Format("UPDATE or_details SET `status` = 'CANCELLED' WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    For x As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SQL &= "INSERT INTO or_details SET"
                            SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQL &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                            SQL &= String.Format(" AR_DetailsID = '{0}', ", GridView2.GetRowCellValue(x, "AR_DetailsID"))
                            SQL &= String.Format(" AR_DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "AR_DocumentNumber"))
                            SQL &= String.Format(" AR_Payable = '{0}', ", GridView2.GetRowCellValue(x, "AR_Payable"))
                            SQL &= String.Format(" CreditNumber = '{0}', ", GridView2.GetRowCellValue(x, "CreditNumber"))
                            SQL &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            If GridView2.GetRowCellValue(x, "AR_DocumentNumber") = "" Then
                            Else
                                Dim PrevPayment As Double = DataObject(String.Format("SELECT Credit FROM or_details WHERE DocumentNumber = '{0}' AND AR_DetailsID = '{1}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text, GridView2.GetRowCellValue(x, "AR_DetailsID")))
                                If CDbl(GridView2.GetRowCellValue(x, "Credit")) <> PrevPayment Then
                                    'Gi minus usa ang previous payment para ma clear
                                    DataObject(String.Format("UPDATE accounts_receivable SET Paid = Paid - '{1}' WHERE DocumentNumber = '{0}';", GridView2.GetRowCellValue(x, "AR_DocumentNumber"), PrevPayment))
                                    SQL &= String.Format("UPDATE ar_details SET Paid = Paid - '{1}' WHERE ID = '{0}'; ", GridView2.GetRowCellValue(x, "AR_DetailsID"), PrevPayment)
                                    'Then gi add ang new payment as update
                                    DataObject(String.Format("UPDATE accounts_receivable SET Paid = Paid + '{1}', `AR_Status` = '{2}' WHERE DocumentNumber = '{0}';", GridView2.GetRowCellValue(x, "AR_DocumentNumber"), CDbl(GridView2.GetRowCellValue(x, "Credit")), If(CDbl(GridView2.GetRowCellValue(x, "Credit")) >= CDbl(GridView2.GetRowCellValue(x, "AR_Payable")), "FULLY PAID", "PARTIALLY PAID")))
                                    SQL &= String.Format("UPDATE ar_details SET Paid = Paid + '{1}' WHERE ID = '{0}'; ", GridView2.GetRowCellValue(x, "AR_DetailsID"), CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                End If
                            End If

                            'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                            Dim SQLv2 As String = ""
                            If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to")) Then
                                Dim APNumber As String = ""
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))

                                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                    APNumber = DataObject(String.Format("SELECT CONCAT('DT-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_to WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                    SQLv2 &= " INSERT INTO due_to SET"
                                Else
                                    APNumber = DataObject(String.Format("SELECT CONCAT('AP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                    SQLv2 &= " INSERT INTO accounts_payable SET"
                                End If
                                If cbxPayee.Text = "" Then
                                    SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                    SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                Else
                                    SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, ValidateComboBox(cbxPayee), BranchTagged))
                                    SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, cbxPayee.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                End If
                                SQLv2 &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                                SQLv2 &= String.Format(" Terms = '{0}', ", 0)
                                SQLv2 &= String.Format(" Delivery_Date = '{0}', ", FormatDatePicker(dtpDocument))
                                SQLv2 &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                SQLv2 &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote & " - " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                SQLv2 &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                                SQLv2 &= String.Format(" CheckedID = '{0}', ", txtChecked.Tag)
                                If txtChecked.Tag > 0 Then
                                    SQLv2 &= " AP_Status = 'CHECKED', "
                                End If
                                SQLv2 &= " ApprovedID = '0', "
                                SQLv2 &= " OTAC_Approve = '', "
                                SQLv2 &= String.Format(" OTAC_Check = '{0}', ", Code)
                                SQLv2 &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                                SQLv2 &= String.Format(" JVNumberV2 = '{0}', ", txtDocumentNumber.Text)
                                SQLv2 &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                    SQLv2 &= "INSERT INTO dt_details SET"
                                Else
                                    SQLv2 &= "INSERT INTO ap_details SET"
                                End If
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Payable") Then
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                Dim APNumber As String = DataObject(String.Format("SELECT CONCAT('LP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM loans_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                SQLv2 &= " INSERT INTO loans_payable SET"
                                If cbxPayee.Text = "" Then
                                    SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                    SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                Else
                                    SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, If(SalaryLoan, GridView2.GetRowCellValue(x, "CreditNumber"), ValidateComboBox(cbxPayee)), BranchTagged))
                                    SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, cbxPayee.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                End If
                                SQLv2 &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                                SQLv2 &= String.Format(" Terms = '{0}', ", 0)
                                SQLv2 &= String.Format(" Delivery_Date = '{0}', ", FormatDatePicker(dtpDocument))
                                SQLv2 &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                SQLv2 &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote & " - " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                SQLv2 &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                                SQLv2 &= String.Format(" CheckedID = '{0}', ", txtChecked.Tag)
                                If txtChecked.Tag > 0 Then
                                    SQLv2 &= " AP_Status = 'CHECKED', "
                                End If
                                SQLv2 &= " ApprovedID = '0', "
                                SQLv2 &= " OTAC_Approve = '', "
                                SQLv2 &= String.Format(" OTAC_Check = '{0}', ", Code)
                                SQLv2 &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                                SQLv2 &= String.Format(" JVNumberV2 = '{0}', ", txtDocumentNumber.Text)
                                SQLv2 &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                                SQLv2 &= "INSERT INTO lp_details SET"
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                Dim APNumber As String = DataObject(String.Format("SELECT CONCAT('DF-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_from WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                SQLv2 &= " INSERT INTO due_from SET"
                                If cbxPayee.Text = "" Then
                                    SQLv2 &= String.Format(" PayorID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                    SQLv2 &= String.Format(" Payor = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payor_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                Else
                                    SQLv2 &= String.Format(" PayorID = '{0}', ", If(BranchTagged = 999, ValidateComboBox(cbxPayee), BranchTagged))
                                    SQLv2 &= String.Format(" Payor = '{0}', ", If(BranchTagged = 999, cbxPayee.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                    SQLv2 &= String.Format(" Payor_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                                End If
                                SQLv2 &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                SQLv2 &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                                SQLv2 &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                SQLv2 &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote & " - " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                SQLv2 &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                                SQLv2 &= String.Format(" CheckedID = '{0}', ", txtChecked.Tag)
                                If txtChecked.Tag > 0 Then
                                    SQLv2 &= " AR_Status = 'CHECKED', "
                                End If
                                SQLv2 &= " ApprovedID = '0', "
                                SQLv2 &= " OTAC_Approve = '', "
                                SQLv2 &= String.Format(" OTAC_Check = '{0}', ", Code)
                                SQLv2 &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                                SQLv2 &= String.Format(" JVNumberV2 = '{0}', ", txtDocumentNumber.Text)
                                SQLv2 &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                                SQLv2 &= "INSERT INTO df_details SET"
                                SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            End If
                            If SQLv2 = "" Then
                            Else
                                DataObject(SQLv2)
                            End If
                            'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                        End If
                    Next
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    If SalaryLoan Then
                        For x As Integer = 0 To DT_SalaryLoan.Rows.Count - 1
                            SQL &= String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE REPLACE(CVNumber,' [Discount]','') = '{0}' AND ReferenceN = '{1}' AND PaidFor NOT IN ('Penalty-W','RPPD-W');", txtDocumentNumber.Text, DT_SalaryLoan(x)("CreditNumber"))
                        Next
                    Else
                        SQL &= String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE REPLACE(CVNumber,' [Discount]','') = '{0}' AND ReferenceN = '{1}' AND PaidFor NOT IN ('Penalty-W','RPPD-W','RPPD-A');", txtDocumentNumber.Text, ValidateComboBox(cbxPayee))
                    End If
                    Dim WithPenaltySaGrid As Boolean
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                            If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                SQL &= " EntryType = 'DEBIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            Else
                                SQL &= " EntryType = 'CREDIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            End If
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            If GridView2.GetRowCellValue(x, "PaidFor") = "" And GridView2.GetRowCellValue(x, "Account Code") <> "" Then
                                If cbxBank.SelectedValue <> BankID And BankID <> 0 Then
                                    SQL &= " PaidFor = '', "
                                Else
                                    SQL &= " PaidFor = 'Other Income', "
                                End If
                            Else
                                SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                            End If
                            If GridView2.GetRowCellValue(x, "PaidFor") = "Penalty" Or GridView2.GetRowCellValue(x, "PaidFor") = "DTS Penalty" Then
                                SQL &= String.Format(" PenaltyPayable = '{0}', ", NegativeNotAllowed(dPenalty_P - CDbl(GridView2.GetRowCellValue(x, "Credit"))))
                                dPenalty_P = NegativeNotAllowed(dPenalty_P - CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                WithPenaltySaGrid = True
                            End If
                            SQL &= String.Format(" ReferenceN = '{0}', ", If(SalaryLoan, GridView2.GetRowCellValue(x, "CreditNumber"), ValidateComboBox(cbxPayee)))
                            SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                            If (SalaryLoan Or If(cbxPayee.SelectedIndex > -1, drv("Product").ToString.ToUpper.Contains("SALARY"), 1)) And GridView2.GetRowCellValue(x, "PaidFor") = "Principal" Then
                                If CDbl(GridView2.GetRowCellValue(x, "Credit")) >= DataObject(String.Format("SELECT IFNULL(Principal_Balance('{0}'),0);", GridView2.GetRowCellValue(x, "CreditNumber"))) Then
                                    SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'CLOSED', ClosedDate = '{1}' WHERE CreditNumber = '{0}' AND PaymentRequest = 'RELEASED';", GridView2.GetRowCellValue(x, "CreditNumber"), FormatDatePicker(dtpPostingDate))
                                Else
                                    SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED', ClosedDate = '' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", GridView2.GetRowCellValue(x, "CreditNumber"))
                                End If
                            End If
                        End If
                    Next

                    If dPenalty_P > 0 And WithPenaltySaGrid = False Then
                        SQL &= "INSERT INTO accounting_entry SET"
                        SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                        SQL &= " EntryType = 'CREDIT',"
                        SQL &= " Payable = 0, "
                        SQL &= " Amount = 0, "
                        SQL &= " AccountCode = '', "
                        SQL &= " MotherCode = '', "
                        SQL &= " BusinessCode = '', "
                        SQL &= " DepartmentCode = '', "
                        SQL &= " PaidFor = 'Penalty', "
                        SQL &= String.Format(" PenaltyPayable = '{0}', ", dPenalty_P)
                        SQL &= String.Format(" ReferenceN = '{0}', ", If(SalaryLoan, "", ValidateComboBox(cbxPayee)))
                        SQL &= " Remarks = '', "
                        SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                        SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    End If

                    If SalaryLoan Then
                        SQL &= String.Format("UPDATE or_salary_details SET `status` = 'CANCELLED' WHERE DocumentNumber = '{0}';", txtDocumentNumber.Text)
                        For x As Integer = 0 To DT_SalaryLoan.Rows.Count - 1
                            If CDbl(DT_SalaryLoan(x)("Amount")) > 0 Then
                                SQL &= "INSERT INTO or_salary_details SET"
                                SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                                SQL &= String.Format(" CreditNumber = '{0}', ", DT_SalaryLoan(x)("CreditNumber"))
                                SQL &= String.Format(" Amount = '{0}', ", DT_SalaryLoan(x)("Amount"))
                                SQL &= String.Format(" Availed = '{0}', ", DT_SalaryLoan(x)("Availed"))
                                SQL &= String.Format(" dRPPD_P = '{0}', ", DT_SalaryLoan(x)("dRPPD_P"))
                                SQL &= String.Format(" TotalRPPD_Payable = '{0}', ", DT_SalaryLoan(x)("TotalRPPD_Payable"))
                                SQL &= String.Format(" TotalRPPD = '{0}';", DT_SalaryLoan(x)("TotalRPPD"))
                                'FOR DISCOUNT OR AVAILED
                                If DT_SalaryLoan(x)("Availed") > 0 Then 'For checking wala ma apil ang availed wrong condition || TotalRPPD - is the total Paid and Availed RPPD
                                    SQL &= "INSERT INTO accounting_entry SET"
                                    SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                    SQL &= String.Format(" ReferenceN = '{0}', ", DT_SalaryLoan(x)("CreditNumber"))
                                    SQL &= " EntryType = 'CREDIT',"
                                    SQL &= " AccountCode = '', " 'Availed
                                    SQL &= " MotherCode = '', " 'Availed
                                    SQL &= String.Format(" Payable = '{0}', ", DT_SalaryLoan(x)("dRPPD_P"))
                                    SQL &= String.Format(" Amount = '{0}', ", DT_SalaryLoan(x)("Availed"))
                                    SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                                    SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD")
                                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                                End If
                            End If
                        Next
                    Else
                        'FOR DISCOUNT OR AVAILED
                        If Availed - TotalWaiveRPPD > 0 And EarlySettlement = False Then 'For checking wala ma apil ang availed wrong condition || TotalRPPD - is the total Paid and Availed RPPD
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= " AccountCode = '', " 'Availed
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= String.Format(" Payable = '{0}', ", dRPPD_P)
                            SQL &= String.Format(" Amount = '{0}', ", Availed - TotalWaiveRPPD)
                            SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                            SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD")
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                        If EarlySettlement Then
                            'RPPD
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= String.Format(" AccountCode = '{0}', ", "") 'Interest Income-Past Due
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= String.Format(" Payable = '{0}', ", RPPD_Amount_Early)
                            SQL &= String.Format(" Amount = '{0}', ", RPPD_Amount_Early)
                            SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                            SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD" & " [Discount]")
                            SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                            'UDI
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= String.Format(" AccountCode = '{0}', ", "") 'Interest Income-Current
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= String.Format(" Payable = '{0}', ", UDI_Amount_Early)
                            SQL &= String.Format(" Amount = '{0}', ", UDI_Amount_Early)
                            SQL &= String.Format(" PaidFor = '{0}', ", "UDI")
                            SQL &= String.Format(" Remarks = '{0}', ", "UDI Payment" & " [Discount]")
                            SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                    End If
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    DataObject(SQL)

                    If cbxPayee.SelectedIndex = -1 Then
                    Else
                        PaymentDT = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%' OR EntryType = 'DEBIT',0 - Amount,Amount) END),0) AS 'Total RPPD', IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Penalty Payment', IFNULL((SELECT PenaltyPayable FROM accounting_entry A WHERE A.PaidFor IN ('Penalty','Penalty-W') AND A.`status` = 'ACTIVE' AND A.ReferenceN = '{0}' AND A.JVNumber = '' ORDER BY ID DESC LIMIT 1),0) AS 'Total Unpaid Penalty', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('RPPD-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived RPPD', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('Penalty-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived Penalty', IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Principal', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Interest', IFNULL((SELECT MAX(IF(ARDate = '',IF(RemittanceDate = '',ORDate,RemittanceDate),ARDate)) FROM official_receipt WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND JVNumber = ''),IFNULL(MAX((CASE WHEN JVNum = '' AND JVNumber = '' THEN ORDate END)),ReleasedDate('{0}'))) AS 'Last Payment' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", ValidateComboBox(cbxPayee), Format(dtpORDate.Value, "yyyy-MM-dd")))
                        If PaymentDT.Rows.Count > 0 Then
                            TotalRPPD = PaymentDT(0)("Total RPPD")
                            TotalInterest = PaymentDT(0)("Total Interest")
                            TotalPayment = PaymentDT(0)("Total Principal")
                            TotalWaivePenalty = PaymentDT(0)("Total Penalty Payment")
                            TotalWaive = PaymentDT(0)("Total Waived Penalty")
                            TotalWaiveRPPD = PaymentDT(0)("Total Waived RPPD")
                            TotalUnpaidPenalty = PaymentDT(0)("Total Unpaid Penalty")
                            LastPayment = PaymentDT(0)("Last Payment")
                            If TotalWaive + TotalWaiveRPPD > 0 Then
                                btnWaiveRemove.Enabled = True
                                'cbxBank.Size = New Point(313, 25)
                            Else
                                btnWaiveRemove.Enabled = False
                                'cbxBank.Size = New Point(381, 25)
                            End If
                        End If
                        dBalanceLedger.Value = GetBalanceLedger(cbxPayee.SelectedValue)
                        If dBalanceLedger.Value > 0 Then
                            SQL = String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", ValidateComboBox(cbxPayee))
                            DataObject(SQL)
                        End If
                    End If

                    Cursor = Cursors.Default
                    Logs("Official Receipt", "Update", Reason, Changes(), "", "", "")
                    cbxPayee.Enabled = True
                    LoadPayee()
                    Clear(True)
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                    If From_GL Then
                        With btnSave
                            .DialogResult = DialogResult.OK
                            .DialogResult = DialogResult.OK
                            .PerformClick()
                        End With
                    End If
                End If
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If dtpPostingDate.Text = dtpPostingDate.Tag Then
            Else
                Change &= String.Format("Change Posting Date from {0} to {1}. ", dtpPostingDate.Tag, dtpPostingDate.Text)
            End If
            If dtpORDate.Text = dtpORDate.Tag Then
            Else
                Change &= String.Format("Change OR Date from {0} to {1}. ", dtpORDate.Tag, dtpORDate.Text)
            End If
            If txtReferenceNumber.Text = txtReferenceNumber.Tag Then
            Else
                Change &= String.Format("Change Reference Number from {0} to {1}. ", txtReferenceNumber.Tag, txtReferenceNumber.Text)
            End If
            If cbxBank.Text = cbxBank.Tag Then
            Else
                Change &= String.Format("Change Bank from {0} to {1}. ", cbxBank.Tag, cbxBank.Text)
            End If
            If rExplanation.Text = rExplanation.Tag Then
            Else
                Change &= String.Format("Change Explanation from {0} to {1}. ", rExplanation.Tag.ToString.InsertQuote, rExplanation.Text.InsertQuote)
            End If
            If txtRemittance.Text = txtRemittance.Tag Then
            Else
                Change &= String.Format("Change Remittance from {0} to {1}. ", txtRemittance.Tag, txtRemittance.Text)
            End If
            If dtpRemittance.Text = dtpRemittance.Tag.ToString Then
            Else
                Change &= String.Format("Change Remittance Date from {0} to {1}. ", dtpRemittance.Tag, dtpRemittance.Text)
            End If
            If cbxCheckNumber.Text = cbxCheckNumber.Tag Then
            Else
                Change &= String.Format("Change Check Number from {0} to {1}. ", cbxCheckNumber.Tag, cbxCheckNumber.Text)
            End If
            If dtpCheck.Text = dtpCheck.Tag.ToString Then
            Else
                Change &= String.Format("Change Check Date from {0} to {1}. ", dtpCheck.Tag, dtpCheck.Text)
            End If
            If txtDeposit.Text = txtDeposit.Tag Then
            Else
                Change &= String.Format("Change Deposit Number from {0} to {1}. ", txtDeposit.Tag, txtDeposit.Text)
            End If
            If dtpDeposit.Text = dtpDeposit.Tag.ToString Then
            Else
                Change &= String.Format("Change Deposit Date from {0} to {1}. ", dtpDeposit.Tag, dtpDeposit.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Official Receipt - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            btnSave.Text = "Update"
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = True
            PanelEx10.Enabled = True
            PanelEx2.Enabled = True
            GridView2.OptionsBehavior.Editable = True
            If SalaryLoan Then
                btnLedger.Enabled = False
            Else
                btnLedger.Enabled = True
            End If
            If cbxAR.Checked Then
                txtARNumber.Enabled = True
            End If
            btnPrint.Enabled = False
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Prev As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DocumentNumber),'') AS 'DocumentNumber' FROM official_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'CA' AND `status` = 'ACTIVE' AND voucher_status IN ('PENDING', 'CHECKED', 'APPROVED') AND ID > {1};", cbxPayee.SelectedValue, ID))
            If Prev = "" Then
            Else
                MsgBox(String.Format("Disapproval/Cancellation of this transaction might affect the computation of the Document Number(s): {0}. Please disapprove/cancel the new Official Receipt first.", Prev), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            Dim SQL As String = String.Format("UPDATE official_receipt SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID)
            If cbxCheckNumber.Tag <> "" Then
                SQL &= String.Format(" UPDATE check_received SET `status` = 'ACTIVE', Remarks = CONCAT(Remarks, ' [CANCELLED]') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND `status` = 'CLEARED';", cbxPayee.SelectedValue, cbxCheckNumber.Tag)
            End If
            If btnEarlySettlement.Visible Then
                SQL &= String.Format("UPDATE credit_earlysettlement SET early_status = 'PAID', Paid = Paid - {3}, ORNumber = '{0}' WHERE CreditNumber = '{1}' AND `status` = 'ACTIVE' AND early_status IN ('PENDING','PAID') AND IF(early_status = 'PAID',ORNumber != '',ORNumber = '') AND AsOf <= '{2}';", txtDocumentNumber.Text, ValidateComboBox(cbxPayee), Format(If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))), "yyyy-MM-dd"), dPaidAmount.Value)
            End If
            SQL &= String.Format(" UPDATE accounting_entry SET ORNum = '', `status` = IF(PaidFor = 'Penalty-W','WAITING','WAITING'), CVNumber = '', Amount = IF(PaidFor = 'Penalty-W',Payable - PenaltyPayable,Amount) WHERE REPLACE(CVNumber,' [Discount]','') = '{0}' AND PaidFor IN ('Penalty-W','RPPD-W');", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE REPLACE(CVNumber,' [Discount]','') = '{0}';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_from SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_to SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE loans_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "AR_DocumentNumber") = "" Then
                Else
                    'IF IN CASE GI YAGAW ANG ACCOUNTING ENTRIES THEN GI DELETE OR DISAPPROVE
                    DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = or_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, PaidFor, Remarks, Required AS 'RequiredRemarks', AR_DetailsID, AR_DocumentNumber, AR_Payable, BusinessCode, TypeID(AccountCode) AS 'Type_ID', CreditNumber, MotherCode FROM or_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", txtDocumentNumber.Text))
                    GridControl2.DataSource = DT_Account
                    Exit For
                End If
            Next
            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "AR_DocumentNumber") = "" Then
                Else
                    DataObject(String.Format("UPDATE accounts_receivable SET Paid = Paid - {1}, `AR_Status` = IF(Paid - {1} = 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}';", GridView2.GetRowCellValue(x, "AR_DocumentNumber"), CDbl(GridView2.GetRowCellValue(x, "Credit"))))
                    SQL &= String.Format("UPDATE ar_details SET Paid = Paid - {1} WHERE ID = '{0}'; ", GridView2.GetRowCellValue(x, "AR_DetailsID"), CDbl(GridView2.GetRowCellValue(x, "Credit")))
                End If
            Next
            DataObject(SQL)
            PaymentDT = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%' OR EntryType = 'DEBIT',0 - Amount,Amount) END),0) AS 'Total RPPD', IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Penalty Payment', IFNULL((SELECT PenaltyPayable FROM accounting_entry A WHERE A.PaidFor IN ('Penalty','Penalty-W') AND A.`status` = 'ACTIVE' AND A.ReferenceN = '{0}' AND A.JVNumber = '' ORDER BY ID DESC LIMIT 1),0) AS 'Total Unpaid Penalty', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('RPPD-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived RPPD', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('Penalty-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived Penalty', IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Principal', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Interest', IFNULL((SELECT MAX(IF(ARDate = '',IF(RemittanceDate = '',ORDate,RemittanceDate),ARDate)) FROM official_receipt WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND JVNumber = ''),IFNULL(MAX((CASE WHEN JVNum = '' AND JVNumber = '' THEN ORDate END)),ReleasedDate('{0}'))) AS 'Last Payment' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", ValidateComboBox(cbxPayee), Format(dtpORDate.Value, "yyyy-MM-dd")))
            If PaymentDT.Rows.Count > 0 Then
                TotalRPPD = PaymentDT(0)("Total RPPD")
                TotalInterest = PaymentDT(0)("Total Interest")
                TotalPayment = PaymentDT(0)("Total Principal")
                TotalWaivePenalty = PaymentDT(0)("Total Penalty Payment")
                TotalWaive = PaymentDT(0)("Total Waived Penalty")
                TotalWaiveRPPD = PaymentDT(0)("Total Waived RPPD")
                TotalUnpaidPenalty = PaymentDT(0)("Total Unpaid Penalty")
                LastPayment = PaymentDT(0)("Last Payment")
                If TotalWaive + TotalWaiveRPPD > 0 Then
                    btnWaiveRemove.Enabled = True
                    'cbxBank.Size = New Point(313, 25)
                Else
                    btnWaiveRemove.Enabled = False
                    'cbxBank.Size = New Point(381, 25)
                End If
            End If
            dBalanceLedger.Value = GetBalanceLedger(cbxPayee.SelectedValue)
            If dBalanceLedger.Value > 0 Then
                SQL = String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", ValidateComboBox(cbxPayee))
                DataObject(SQL)
            End If
            Logs("Official Receipt", "Cancel", Reason, String.Format("Cancel Official Receipt of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "")
            PanelEx10.Enabled = True
            PanelEx2.Enabled = True
            GridView2.OptionsBehavior.Editable = True
            cbxPayee.Enabled = True
            LoadPayee()
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub GenerateReceipt(Show As Boolean, FName As String, CheckedBy As String, ApprovedBy As String)
        Dim Report As New RptOfficialReceipt
        With Report
            .Name = String.Format("Official Receipt of {0} - {1}", cbxPayee.Text, txtDocumentNumber.Text)
            .lblAddress.Text = Branch_Address
            .lblContact.Text = Branch_Contact
            .lblTIN.Text = Branch_TIN
            .lblFSFC.Text = "First Standard Finance Corporation - " & UpperCaseFirst(Branch)

            .lblPayee.Text = cbxPayee.Text
            .lblDocumentDate.Text = dtpDocument.Text
            .lblDocumentNumber.Text = txtDocumentNumber.Text
            .lblPostingDate.Text = dtpPostingDate.Text
            .lblORDate.Text = dtpORDate.Text
            .cbxAvailed.Checked = cbxAvailed.Checked
            .lblReferenceNumber.Text = txtReferenceNumber.Text
            .lblBank.Text = cbxBank.Text
            .lblExplanation.Text = rExplanation.Text
            .lblAmount.Text = dPaidAmount.Text
            .lblLedgerBalance.Text = dBalanceLedger.Text
            .lblPayable.Text = dPayable.Text

            .DataSource = DT_Account
            .lblAccount.DataBindings.Add("Text", DT_Account, "Account")
            .lblBusinessCenter.DataBindings.Add("Text", DT_Account, "Business Center")
            .lblDepartment.DataBindings.Add("Text", DT_Account, "Department")
            .lblDebit.DataBindings.Add("Text", DT_Account, "Debit")
            .lblCredit.DataBindings.Add("Text", DT_Account, "Credit")
            .lblRemarks.DataBindings.Add("Text", DT_Account, "Remarks")
            .lblDebitT.Text = dDebitT.Text
            .lblCreditT.Text = dCreditT.Text

            .cbxCash.Checked = cbxCash.Checked
            .cbxCheck.Checked = cbxCheck.Checked
            .cbxRemittance.Checked = cbxRemittance.Checked
            .lblRemittance.Text = txtRemittance.Text
            .lblRemittanceDate.Text = dtpRemittance.Text
            .lblCheckNumber.Text = cbxCheckNumber.Text
            .lblCheckDate.Text = dtpCheck.Text
            .cbxOnline.Checked = cbxOnline.Checked
            .lblDepositNumber.Text = txtDeposit.Text
            .lblDepositDate.Text = dtpDeposit.Text

            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblCheckedBy.Text = CheckedBy
            .lblApprovedBy.Text = ApprovedBy
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
        If SuperTabControl1.SelectedTabIndex = 0 Then
            GenerateReceipt(True, "", txtChecked.Text, txtApproved.Text)
            Logs("Official Receipt", "Print", "[SENSITIVE] Print Official Receipt " & txtDocumentNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("OFFICIAL RECEIPT LIST", GridControl1)
            Logs("Official Receipt", "Print", "[SENSITIVE] Print Official Receipt List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub
    '***BUTTON CLICK

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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or If(From_Check Or From_GL, e.KeyCode = Keys.Escape, 0) Then
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
        ElseIf e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Right Then
            GroupControl1.Size = New Point(30, PanelEx4.Size.Height - 5)
            GroupControl1.Location = New Point(1125, 3)
            GridControl3.Visible = False
            GroupControl1.Text = ""
        ElseIf e.KeyCode = Keys.Left Then
            If GridColumn41.Visible Then
                GroupControl1.Location = New Point(377, 3)
                GroupControl1.Size = New Point(775, PanelEx4.Size.Height - 5)
            Else
                GroupControl1.Location = New Point(513, 3)
                GroupControl1.Size = New Point(639, PanelEx4.Size.Height - 5)
            End If
            GridControl3.Visible = True
            GroupControl1.Text = "Amortization Schedule"
        ElseIf e.Shift And e.KeyCode = Keys.Oemplus Then
            btnAdd_Account.Focus()
            btnAdd_Account.PerformClick()
        ElseIf e.Shift And e.KeyCode = Keys.OemMinus Then
            btnRemove_Account.Focus()
            btnRemove_Account.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView1_DoubleClick(sender, e)
        End If
    End Sub

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        PanelEx2.Enabled = True
        GridView2.OptionsBehavior.Editable = False
        GridControl3.DataSource = Nothing
        cbxLoans.Enabled = False
        cbxClosed.Enabled = False
        With GridView1
            If .GetFocusedRowCellValue("OldAccount") = 1 Then
                cbxClosed.Checked = True
            Else
                cbxClosed.Checked = False
            End If
            ID = .GetFocusedRowCellValue("ID")
            dtpDocument.Value = .GetFocusedRowCellValue("Document Date")
            txtDocumentNumber.Text = .GetFocusedRowCellValue("Document Number")
            cbxPayee.Enabled = False
            cbxBank.Enabled = False
            dPaidAmount.Enabled = False
            cbxAvailed.Enabled = False
            LoadPayee()
            cbxPayee.Text = .GetFocusedRowCellValue("Payee")
            If cbxPayee.SelectedIndex = -1 Then
                cbxPayee.SelectedValue = .GetFocusedRowCellValue("Payee_ID")
            End If
            cbxPayee.Tag = .GetFocusedRowCellValue("Payee")
            If .GetFocusedRowCellValue("Payee_ID").ToString = "0" Then
            Else
                LoadAmortization(GridControl3)
            End If
            If .GetFocusedRowCellValue("Payee_Type") = "CA" Then
                SalaryLoan = False
            Else
                SalaryLoan = True
                DT_SalaryLoan = DataSource(String.Format("SELECT S.CreditNumber, S.Amount, S.Availed, S.dRPPD_P, S.TotalRPPD_Payable, S.TotalRPPD, C.Terms, C.AmountApplied, C.Interest, C.Mortgage_ID, C.`Account Number`, C.BankID, C.Face_Amount, C.BusinessCode, C.Payor, C.RPPD FROM or_salary_details S INNER JOIN (SELECT CreditNumber, Terms, AmountApplied, Interest, Mortgage_ID, RPPD, CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)) AS 'Account Number', BankID, Face_Amount, BusinessCenterCode(BusinessID) AS 'BusinessCode', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'Payor' FROM credit_application) C ON S.CreditNumber = C.CreditNumber WHERE DocumentNumber = '{0}' GROUP BY CreditNumber;", txtDocumentNumber.Text))
            End If

            '******TRANSFER BECAUSE ERROR OCCUR WHEN SWITCHING MODE OF PAYMENT FROM CHECK TO CASH MAY 05, 2021
            cbxCash.Enabled = False
            cbxCheck.Enabled = False
            cbxOnline.Enabled = False
            If .GetFocusedRowCellValue("Type") = "CASH" Then
                cbxCash.Checked = True
            ElseIf .GetFocusedRowCellValue("Type") = "CHECK" Then
                cbxCheck.Checked = True
            ElseIf .GetFocusedRowCellValue("Type") = "ONLINE" Then
                cbxOnline.Checked = True
            End If
            If .GetFocusedRowCellValue("Remittance") = "" Then
                cbxRemittance.Checked = False
            Else
                cbxRemittance.Checked = True
            End If
            txtRemittance.Text = .GetFocusedRowCellValue("Remittance")
            txtRemittance.Tag = .GetFocusedRowCellValue("Remittance")
            dtpRemittance.Text = .GetFocusedRowCellValue("RemittanceDate").ToString
            dtpRemittance.Tag = .GetFocusedRowCellValue("RemittanceDate").ToString
            cbxCheckNumber.Text = .GetFocusedRowCellValue("CheckNumber")
            cbxCheckNumber.Tag = .GetFocusedRowCellValue("CheckNumber")
            dtpCheck.Text = .GetFocusedRowCellValue("CheckDate").ToString
            dtpCheck.Tag = .GetFocusedRowCellValue("CheckDate")
            If .GetFocusedRowCellValue("ARNumber") = "" or .GetFocusedRowCellValue("ARDate").ToString = "" Then
                cbxAR.Checked = False
            Else
                cbxAR.Checked = True
            End If
            txtARNumber.Text = .GetFocusedRowCellValue("ARNumber")
            txtARNumber.Tag = .GetFocusedRowCellValue("ARNumber")
            dtpAR.Text = .GetFocusedRowCellValue("ARDate").ToString
            dtpAR.Tag = .GetFocusedRowCellValue("ARDate")
            txtDeposit.Text = .GetFocusedRowCellValue("DepositNumber")
            txtDeposit.Tag = .GetFocusedRowCellValue("DepositNumber")
            dtpDeposit.Text = .GetFocusedRowCellValue("DepositDate").ToString
            dtpDeposit.Tag = .GetFocusedRowCellValue("DepositDate")
            cbxRemittance.Enabled = False
            dtpRemittance.Enabled = False
            cbxCheckNumber.Enabled = False
            dtpCheck.Enabled = False
            txtDeposit.Enabled = False
            dtpDeposit.Enabled = False
            cbxAR.Enabled = False
            txtARNumber.Enabled = False
            dtpAR.Enabled = False
            '******TRANSFER BECAUSE ERROR OCCUR WHEN SWITCHING MODE OF PAYMENT FROM CHECK TO CASH MAY 05, 2021
            FirstLoad = False
            ForcedAvailed = .GetFocusedRowCellValue("ForcedAvailed")
            dPaidAmount.Value = .GetFocusedRowCellValue("Paid")
            dPaidAmount.Tag = .GetFocusedRowCellValue("Paid")
            dBalanceLedger.Value = .GetFocusedRowCellValue("LedgerBalance")
            dPayable.Value = .GetFocusedRowCellValue("Payable")
            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            cbxBank.Tag = .GetFocusedRowCellValue("Bank")
            dtpPostingDate.Value = .GetFocusedRowCellValue("Posting Date")
            dtpPostingDate.Tag = .GetFocusedRowCellValue("Posting Date")
            dtpORDate.Value = .GetFocusedRowCellValue("OR Date")
            dtpORDate.Tag = .GetFocusedRowCellValue("OR Date")
            txtReferenceNumber.Text = .GetFocusedRowCellValue("Reference Number")
            txtReferenceNumber.Tag = .GetFocusedRowCellValue("Reference Number")
            rExplanation.Text = .GetFocusedRowCellValue("Explanation")
            rExplanation.Tag = .GetFocusedRowCellValue("Explanation")
            cbxAvailed.Checked = .GetFocusedRowCellValue("Banking")
            DTS = .GetFocusedRowCellValue("DTS")
            If .GetFocusedRowCellValue("EarlySettlement") = True Then
                btnEarlySettlement.Visible = True
                btnEarlySettlement.Enabled = False
            End If
        End With
        If CompanyMode = 0 Then
            DT_Account = DataSource(String.Format("SELECT MotherCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = MotherCode(or_details.AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, PaidFor, Remarks, Required AS 'RequiredRemarks', AR_DetailsID, AR_DocumentNumber, AR_Payable, BusinessCode, TypeID(AccountCode) AS 'Type_ID', CreditNumber, MotherCode FROM or_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
        Else
            DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = or_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, PaidFor, Remarks, Required AS 'RequiredRemarks', AR_DetailsID, AR_DocumentNumber, AR_Payable, BusinessCode, TypeID(AccountCode) AS 'Type_ID', CreditNumber, MotherCode FROM or_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
        End If

        GridControl2.DataSource = DT_Account
        dPenalty_P = DataObject(String.Format("SELECT IFNULL(SUM(PenaltyPayable + Amount),0) FROM accounting_entry WHERE ReferenceN = '{0}' AND ORNum = '{1}' AND `status` = 'ACTIVE' AND PaidFor = 'Penalty' AND EntryType = 'CREDIT';", GridView1.GetFocusedRowCellValue("Payee_ID"), txtDocumentNumber.Text))
        Dim TotalDebit As Double
        Dim TotalCredit As Double
        Dim Total_CIB As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                Total_CIB += CDbl(DT_Account(x)("Debit"))
            End If
        Next
        dDebitT.Value = TotalDebit
        dDebitT.Tag = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB
        If GridView2.RowCount > 7 Then
            GridColumn32.Width = 226 - 17
        Else
            GridColumn32.Width = 226
        End If

        With GridView1
            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")
            txtChecked.Text = .GetFocusedRowCellValue("Checked By")
            txtChecked.Tag = .GetFocusedRowCellValue("CheckedID")
            txtApproved.Text = .GetFocusedRowCellValue("Approved By")
            User_EmplID = .GetFocusedRowCellValue("User_EmplID")
            Code_Check = .GetFocusedRowCellValue("OTAC_Check")
            Code_Approve = .GetFocusedRowCellValue("OTAC_Approve")
            LastPaymentBefore = .GetFocusedRowCellValue("LastPaymentBefore")
            TotalRPPD = .GetFocusedRowCellValue("TotalRPPD")
            TotalInterest = .GetFocusedRowCellValue("TotalInterest")
            TotalPayment = .GetFocusedRowCellValue("TotalPayment")
            TotalWaivePenalty = .GetFocusedRowCellValue("TotalWaivePenalty")
            TotalUnpaidPenalty = .GetFocusedRowCellValue("TotalUnpaidPenalty")
            TotalWaive = .GetFocusedRowCellValue("TotalWaive")
            TotalWaiveRPPD = .GetFocusedRowCellValue("TotalWaiveRPPD")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        If GridView1.GetFocusedRowCellValue("Voucher_Status") = "PENDING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Then
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnCheck.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    btnCheck.Visible = True
                    btnModify.Enabled = True
                    btnDisapprove.Visible = True
                    Exit For
                End If
            Next
            If User_Type = "ADMIN" Or Empl_ID = User_EmplID Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Then
                btnModify.Enabled = True
                btnCheck.Visible = True
            End If
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CHECKED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnApprove.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    btnApprove.Visible = True
                    btnModify.Enabled = True
                    btnDisapprove.Visible = True
                    Exit For
                End If
            Next
            If User_Type = "ADMIN" Or Empl_ID = User_EmplID Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Then
                btnApprove.Visible = True
            End If
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "APPROVED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR DEPOSIT" Then
            btnCheck.Visible = False
            btnApprove.Visible = False
            btnModify.Enabled = False
        End If
        If LastPaymentBefore <> "" And GridView1.GetFocusedRowCellValue("Payee_Type") = "CA" Then
            btnCalculatorV2.Visible = True
            btnCalculator.Visible = False
        End If
        btnPrint.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
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

    Private Sub CbxCash_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCash.CheckedChanged
        If cbxCash.Checked Then
            cbxRemittance.Enabled = True
            cbxCheck.Checked = False
            cbxOnline.Checked = False
        End If

        If cbxCash.Checked = False And cbxCheck.Checked = False And cbxOnline.Checked = False Then
            cbxCash.Checked = True
        End If
    End Sub

    Private Sub CbxCheck_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCheck.CheckedChanged
        If cbxCheck.Checked Then
            cbxCash.Checked = False
            cbxOnline.Checked = False
            cbxRemittance.Enabled = False
            cbxRemittance.Checked = False

            cbxCheckNumber.Enabled = True
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                cbxCheckNumber.DataSource = Nothing
                cbxCheckNumber.Text = ""
                dtpCheck.Value = Date.Now
                dPaidAmount.Value = 0
            Else
                FirstLoad = True
                cbxCheckNumber.DisplayMember = "Check"
                cbxCheckNumber.ValueMember = "ID"
                cbxCheckNumber.DataSource = DataSource(String.Format("SELECT ID, `Check`, `Date`, Amount FROM check_received WHERE `Status` NOT IN ('PENDING','DELETED','CANCELLED','PARTIAL','RETURNED','PAID','BOUNCED','CLEARED','REMOVED') AND check_type = 'R' AND AssetNumber = '{0}';", ValidateComboBox(cbxPayee)))
                FirstLoad = False
                cbxCheckNumber.SelectedIndex = -1
            End If
            dtpCheck.Enabled = True
            dtpCheck.CustomFormat = "MMMM dd, yyyy"
            dtpCheck.Value = Date.Now
            cbxAR.Enabled = True
        Else
            cbxCheckNumber.Enabled = False
            dtpCheck.Enabled = False
            cbxAR.Checked = False
            cbxAR.Enabled = False
            cbxCheckNumber.Text = ""
            cbxCheckNumber.DataSource = Nothing
            cbxCheckNumber.Text = ""
            dtpCheck.Value = Date.Now
            dPaidAmount.Value = 0
        End If

        If cbxCash.Checked = False And cbxCheck.Checked = False And cbxOnline.Checked = False Then
            cbxCash.Checked = True
        End If
    End Sub

    Private Sub CbxOnline_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOnline.CheckedChanged
        If cbxOnline.Checked Then
            cbxCash.Checked = False
            cbxCheck.Checked = False
            cbxRemittance.Enabled = False
            cbxRemittance.Checked = False

            txtDeposit.Enabled = True
            dtpDeposit.Enabled = True
            dtpDeposit.CustomFormat = "MMMM dd, yyyy"
            dtpDeposit.Value = Date.Now
        Else
            txtDeposit.Enabled = False
            dtpDeposit.Enabled = False
            txtDeposit.Text = ""
            dtpDeposit.CustomFormat = ""
        End If

        If cbxCash.Checked = False And cbxCheck.Checked = False And cbxOnline.Checked = False Then
            cbxCash.Checked = True
        End If
    End Sub

    Private Sub CbxPayee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayee.SelectedIndexChanged
        If FirstLoad Or SuperTabControl1.SelectedTabIndex = 1 Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                Clear(False)
            Else
                btnLedger.Enabled = True
                btnCalculator.Enabled = True
                btnWaive.Enabled = True
                btnEarly.Enabled = True

                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                lblProduct.Text = drv("Product")
                dtpPostingDate.MinDate = CDate(drv("Released"))
                dtpDeposit.MinDate = CDate(drv("Released"))
                dtpORDate.MinDate = CDate(drv("Released"))
                dtpRemittance.MinDate = CDate(drv("Released"))
                Terms = drv("Terms")
                UDI = drv("Interest")
                Principal = drv("AmountApplied")
                RPPD = drv("RPPD")
                MortgageID = drv("Mortgage_ID")
                AccountNumber = drv("AccountNumber")
                BankID = drv("BankID")
                LastPayment = drv("FDD")
                If From_Check = False Then
                    If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                        cbxCheckNumber.DataSource = Nothing
                        cbxCheckNumber.Text = ""
                        dtpCheck.Value = Date.Now
                        dPaidAmount.Value = 0
                    Else
                        With cbxCheckNumber
                            .DisplayMember = "Check"
                            .ValueMember = "ID"
                            FirstLoad = True
                            .DataSource = DataSource(String.Format("SELECT ID, `Check`, `Date`, Amount FROM check_received WHERE `Status` NOT IN ('PENDING','DELETED','CANCELLED','PARTIAL','RETURNED','PAID','CLEARED','REMOVED') AND check_type = 'R' AND AssetNumber = '{0}';", ValidateComboBox(cbxPayee)))
                            dtpCheck.Value = Date.Now
                            .Text = ""
                            dPaidAmount.Value = 0
                            FirstLoad = False
                        End With
                    End If
                End If
                LoadAmortization(GridControl3)
                If GroupControl1.Size.Width = 30 Then
                Else
                    If GridColumn41.Visible Then
                        GroupControl1.Location = New Point(377, 3)
                        GroupControl1.Size = New Point(775, PanelEx4.Size.Height - 5)
                    Else
                        GroupControl1.Location = New Point(513, 3)
                        GroupControl1.Size = New Point(639, PanelEx4.Size.Height - 5)
                    End If
                End If
                If BankID > 0 Then
                    cbxBank.SelectedValue = BankID
                Else
                    cbxBank.SelectedValue = drv("BankID")
                End If
                FaceAmount = drv("Face_Amount")
                If drv("Product").ToString.Contains("SHOWMONEY") Then
                    btnCalculator.Enabled = False
                End If
                PaymentDT = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%' OR EntryType = 'DEBIT',0 - Amount,Amount) END),0) AS 'Total RPPD', IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Penalty Payment', IFNULL((SELECT PenaltyPayable FROM accounting_entry A WHERE A.PaidFor IN ('Penalty','Penalty-W') AND A.`status` = 'ACTIVE' AND A.ReferenceN = '{0}' AND A.JVNumber = '' ORDER BY ID DESC LIMIT 1),0) AS 'Total Unpaid Penalty', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('RPPD-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived RPPD', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('Penalty-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived Penalty', IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Principal', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Interest', IFNULL((SELECT MAX(IF(ARDate = '',IF(RemittanceDate = '',ORDate,RemittanceDate),ARDate)) FROM official_receipt WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND JVNumber = ''),IFNULL(MAX((CASE WHEN JVNum = '' AND JVNumber = '' THEN ORDate END)),ReleasedDate('{0}'))) AS 'Last Payment' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", ValidateComboBox(cbxPayee), Format(dtpORDate.Value, "yyyy-MM-dd")))
                If PaymentDT.Rows.Count > 0 Then
                    TotalRPPD = PaymentDT(0)("Total RPPD")
                    TotalInterest = PaymentDT(0)("Total Interest")
                    TotalPayment = PaymentDT(0)("Total Principal")
                    If TotalRPPD + TotalInterest + TotalPayment = 0 Then
                        cbxAvailed.Enabled = False
                        cbxAvailed.Checked = False
                    Else
                        cbxAvailed.Enabled = True
                    End If
                    TotalWaivePenalty = PaymentDT(0)("Total Penalty Payment")
                    TotalWaive = PaymentDT(0)("Total Waived Penalty")
                    TotalWaiveRPPD = PaymentDT(0)("Total Waived RPPD")
                    If TotalWaive + TotalWaiveRPPD > 0 Then
                        btnWaiveRemove.Enabled = True
                        'cbxBank.Size = New Point(313, 25)
                    Else
                        btnWaiveRemove.Enabled = False
                        'cbxBank.Size = New Point(381, 25)
                    End If
                    TotalUnpaidPenalty = PaymentDT(0)("Total Unpaid Penalty")
                    LastPayment = PaymentDT(0)("Last Payment")
                    WaiveDate = DataObject(String.Format("SELECT IFNULL(MAX(ORDate),'') FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND PaidFor IN ('Penalty-W','RPPD-W') AND CVNumber = '' AND ReferenceN = '{0}';", ValidateComboBox(cbxPayee)))
                    If WaiveDate = "" Then
                    Else
                        If CDate(WaiveDate) = CDate(If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))) Then
                        Else
                            If MsgBox("This account still have an old waived penalty/rppd, please cancel the old waived penalty/rppd to generate accurate penalty/rppd.", MsgBoxStyle.Information, "Info") Then

                            End If
                        End If
                    End If
                End If
                dBalanceLedger.Value = GetBalanceLedger(cbxPayee.SelectedValue)

                dBilling_P = 0
                DT_Billing = DataSource(String.Format("SELECT D.ID, M.DocumentNumber, AccountCode, DepartmentCode, AccountTitleCode(D.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit - D.Paid AS 'Debit', Credit AS 'Credit', 'Billing' AS 'PaidFor', CONCAT(Remarks, ' ', (SELECT GROUP_CONCAT(CONCAT(AccountTitle(ar_details.AccountCode), ' (', FORMAT(Credit,2),')')) FROM ar_details WHERE ar_details.DocumentNumber = M.DocumentNumber AND ar_details.`status` = 'ACTIVE' AND ar_details.Credit > 0)) AS 'Remarks', Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode FROM accounts_receivable M INNER JOIN ar_details D ON M.DocumentNumber = D.DocumentNumber AND D.Status = 'ACTIVE' AND M.Status = 'ACTIVE' AND NotAR = 0 AND JVNumber = '' AND AR_Status NOT IN ('FULLY PAID','PENDING','CHECKED') AND PayorID = '{0}' AND Debit - D.Paid > 0 AND M.JVNumberV2 = '' AND PostingDate <= '{1}';", ValidateComboBox(cbxPayee), FormatDatePicker(If(cbxRemittance.Checked, dtpRemittance, If(cbxOnline.Checked, dtpDeposit, If(cbxAR.Checked, dtpAR, dtpORDate))))))
                For x As Integer = 0 To DT_Billing.Rows.Count - 1
                    dBilling_P += CDbl(DT_Billing(x)("Debit"))
                Next

                Compute()
                ComputeEarly()
                FillAccounts()

                If drv("Loan_Type") = "MIGRATED" And drv("MigratedValidation") = 0 Then
                    btnValidate.Visible = True
                    btnSave.Enabled = False
                Else
                    btnValidate.Visible = False
                    btnSave.Enabled = True
                End If
                Dim OR_WithDTSNoJV As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DocumentNumber),'') FROM official_receipt WHERE DTS = 1 AND DTS_JVNumber = '' AND JVNumber = '' AND Payee_ID = '{0}' AND `status` = 'ACTIVE';", cbxPayee.SelectedValue))
                If OR_WithDTSNoJV <> "" And From_JournalDTS = False Then
                    MsgBox(String.Format("Account still have DTS OR of {0} that is not yet reversed using the Journal Voucher, creating of new OR is not yet allowed.", OR_WithDTSNoJV), MsgBoxStyle.Information, "Info")
                    btnSave.Enabled = False
                End If
            End If
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub ComputeEarly()
        If FirstLoad Or SuperTabControl1.SelectedTabIndex = 1 Or cbxPayee.SelectedIndex = -1 Or GridView3.RowCount = 0 Then
            Exit Sub
        End If

        Dim DT_Early As DataTable = DataSource(String.Format("SELECT LR - Paid AS 'LR', UDI_Discount, AvailedRPPD, AR, Penalty FROM credit_earlysettlement WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND early_status IN ('PENDING','PAID') AND LR - Paid > 0 AND AsOf >= '{1}';", cbxPayee.SelectedValue, Format(If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))), "yyyy-MM-dd")))
        If DT_Early.Rows.Count > 0 Then
            dPaidAmount.Value = (CDbl(DT_Early(0)("LR")) + CDbl(DT_Early(0)("AR")) + CDbl(DT_Early(0)("Penalty"))) - (CDbl(DT_Early(0)("UDI_Discount")) + CDbl(DT_Early(0)("AvailedRPPD")))
            dPayable.Value = dPaidAmount.Value

            Dim PayablePrincipal As Double = GridView3.GetRowCellValue(0, "Outstanding Principal")
            Dim PayableInterest As Double = GridView3.GetRowCellValue(0, "Unearn Income")
            Dim PayableRPPD As Double = GridView3.GetRowCellValue(0, "Total_RPPD")
            dRPPD_P = NegativeNotAllowed(((PayableRPPD - TotalRPPD) - CDbl(DT_Early(0)("AvailedRPPD"))) + If(TotalRPPD_Payable > TotalRPPD And If(cbxRemittance.Checked, dtpRemittance.Value.Day, If(cbxOnline.Checked, dtpDeposit.Value.Day, If(cbxAR.Checked, dtpAR.Value.Day, dtpORDate.Value.Day))) > CDate(GridView3.GetFocusedRowCellValue("Due Date")).Day, CDbl(GridView3.GetFocusedRowCellValue("RPPD")), 0))
            dUDI_P = NegativeNotAllowed((PayableInterest - TotalInterest) - CDbl(DT_Early(0)("UDI_Discount")))
            dPrincipal_P = PayablePrincipal - TotalPayment
            UDI_Amount_Early = CDbl(DT_Early(0)("UDI_Discount"))
            RPPD_Amount_Early = CDbl(DT_Early(0)("AvailedRPPD"))

            dRPPD = dRPPD_P
            EarlySettlement = True
            btnEarlySettlement.Enabled = True
            btnEarlySettlement.Visible = True
        Else
            If From_Check = False Then
                If EarlySettlement Then
                    dPaidAmount.Enabled = True
                    dPaidAmount.Value = 0
                End If
            End If
            EarlySettlement = False
            btnEarlySettlement.Visible = False
        End If
    End Sub

    Private Sub RPPDCompute(Recheck As Boolean)
        Availed = 0

        If GridColumn41.Visible Then
            Exit Sub
        End If
        Dim TotalPaidNMA As Double = TotalPayment + TotalInterest + dPrincipal + dUDI
        If Recheck Then
            dPrincipal = 0
            dUDI = 0
            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "PaidFor") = "Principal" Then
                    dPrincipal += CDbl(GridView2.GetRowCellValue(x, "Credit"))
                End If
                If GridView2.GetRowCellValue(x, "PaidFor") = "UDI" Then
                    dUDI += CDbl(GridView2.GetRowCellValue(x, "Credit"))
                End If
            Next
            TotalPaidNMA = TotalPayment + TotalInterest + dPrincipal + dUDI
        End If
        'Dim NonthlyNMA As Double = CDbl(GridView3.GetRowCellValue(1, "Interest Income")) + CDbl(GridView3.GetRowCellValue(1, "Principal Allocation"))
        'Dim NumberOfRPPD As Integer = Math.Floor(TotalPaidNMA / NonthlyNMA)
        'For x As Integer = 0 To NumberOfRPPD - 1
        '    Availed = Availed + CDbl(GridView3.GetRowCellValue(1, "RPPD"))
        'Next
        Dim MustPaidPrincipalUDI As Double
        For x As Integer = 1 To GridView3.RowCount - 1
            MustPaidPrincipalUDI += CDbl(GridView3.GetRowCellValue(x, "Interest Income")) + CDbl(GridView3.GetRowCellValue(x, "Principal Allocation"))
            If TotalPaidNMA >= MustPaidPrincipalUDI Then
                Availed += CDbl(GridView3.GetRowCellValue(x, "RPPD"))
            End If
        Next
        If (If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) <= CDate(GridView3.GetFocusedRowCellValue("Due Date")).AddDays(If(GridView3.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 1, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))))) And dBalanceLedger.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")) And dRPPD_P > 0 Then
            Availed -= CDbl(GridView3.GetRowCellValue(1, "RPPD"))
        End If
        Availed = NegativeNotAllowed(Availed - (TotalRPPD + dRPPD_P))
    End Sub

    Private Sub FillAccounts()
        If dPaidAmount.Value = 0 Then
            DT_Account.Rows.Clear()
            dDebitT.Value = 0
            dCreditT.Value = 0
        End If
        If FirstLoad Or SuperTabControl1.SelectedTabIndex = 1 Or cbxPayee.SelectedIndex = -1 Or GridView3.RowCount <= 1 Or dPaidAmount.Value = 0 Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        dBilling = If(dPaidAmount.Value >= dBilling_P, dBilling_P, dPaidAmount.Value)
        dPenalty = If((dPaidAmount.Value - dBilling) >= dPenalty_P, dPenalty_P, (dPaidAmount.Value - dBilling))
        If (If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetFocusedRowCellValue("Due Date")).AddDays(If(FaceAmount - (TotalPayment + TotalRPPD + TotalInterest) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle - 1, "Loans Receivable")), If(GridView3.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 1, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))), 0))) Or dRPPD_P > 0 Then
            dRPPD = If(((dPaidAmount.Value - dBilling) - dPenalty) >= dRPPD_P, dRPPD_P, ((dPaidAmount.Value - dBilling) - dPenalty))
        Else
            dRPPD = 0
        End If

        'PAYMENT HEIRARCHY ***************************************************************************************************************
        dUDI = 0
        If dPaidAmount.Value >= dPayable.Value And (dPayable.Value = 0 Or (TotalPayment + TotalInterest) + (dPaidAmount.Value - (dBilling + dPenalty + dRPPD)) >= (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) + CDbl(GridView3.GetRowCellValue(0, "Unearn Income"))) - (CDbl(GridView3.GetFocusedRowCellValue("Outstanding Principal")) + CDbl(GridView3.GetFocusedRowCellValue("Unearn Income")))) Then
            Dim ForDistribute As Double = (((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD)
            If dUDI_P > 0 Then
                dUDI = If((((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD_P) >= dUDI_P, dUDI_P, (((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD))
                ForDistribute -= dUDI_P
            End If
            If dPrincipal_P > 0 Then
                dPrincipal = If(((((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD_P) - dUDI_P) >= dPrincipal_P, ((((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD_P) - dUDI_P), ((((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD) - dUDI))
                ForDistribute -= dPrincipal_P
            End If
            Dim NMA As Double = CDbl(GridView3.GetRowCellValue(1, "Interest Income")) + CDbl(GridView3.GetRowCellValue(1, "Principal Allocation"))
            Dim Covered As Double = If(Math.Ceiling(ForDistribute / NMA) > GridView3.RowCount - 2, GridView3.RowCount - 2, Math.Ceiling(ForDistribute / NMA))
            If Covered > 0 Then
            Else
                GoTo Here
            End If
            For x As Integer = 0 To Covered - 1
                If ForDistribute > 0 Then
                    If ForDistribute >= CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Interest Income")) Then
                        dUDI += CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Interest Income"))
                        ForDistribute -= CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Interest Income"))
                    Else
                        dUDI += ForDistribute
                        ForDistribute = 0
                    End If

                    If ForDistribute >= CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Principal Allocation")) Then
                        ForDistribute -= CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Principal Allocation"))
                    Else
                        ForDistribute = 0
                    End If
                End If
            Next
Here:
            If dUDI > NegativeNotAllowed(CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - TotalInterest) Then
                dPrincipal += (dUDI - NegativeNotAllowed(CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - TotalInterest))
                dUDI = NegativeNotAllowed(CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - TotalInterest)
            End If
            dPrincipal = (((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD) - dUDI
        Else
            Dim UnpaidPrincipal As Double
            If dPrincipal_P > CDbl(GridView3.GetFocusedRowCellValue("Principal Allocation")) Then
                If TotalPayment > 0 Then
                    UnpaidPrincipal = dPrincipal_P - CDbl(GridView3.GetFocusedRowCellValue("Principal Allocation"))
                Else
                    UnpaidPrincipal = dPrincipal_P
                End If
            End If
            dUDI = If((((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD_P) >= dUDI_P, dUDI_P, (((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD))
            dPrincipal = If(((((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD_P) - dUDI_P) >= dPrincipal_P, ((((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD_P) - dUDI_P), ((((dPaidAmount.Value - dBilling) - dPenalty) - dRPPD) - dUDI))
            If UnpaidPrincipal > 0 And dUDI > 0 And TotalPayment > 0 And TotalInterest > 0 Then
                If UnpaidPrincipal > dUDI + dPrincipal And dUDI_P = 0 Then
                    dPrincipal = dUDI
                    dUDI = 0
                ElseIf UnpaidPrincipal > 0 And dPaidAmount.Value >= (dUDI + dBilling + dPenalty + dRPPD) Then
                    dUDI = dUDI
                    dPrincipal = dPaidAmount.Value - (dUDI + dBilling + dPenalty + dRPPD)
                ElseIf dPenalty > 0 Then
                Else
                    dUDI = (dUDI + dPrincipal) - UnpaidPrincipal
                    dPrincipal = UnpaidPrincipal
                End If
            End If
        End If

        RPPDCompute(False)

        'PAYMENT HEIRARCHY ***************************************************************************************************************

        DT_Account.Rows.Clear()
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        'Cash In Bank **********************************************************************************************************************
        If drv("CVforJV") Then
            If drv("DueToBranch") = "" Then
                AccountCodeDetails(CIB_BDO)
            Else
                AccountCodeDetails(drv("DueToBranch"))
            End If
        Else
            AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
        End If
        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", dPaidAmount.Value, 0, "CIB", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
        'Billing (Accounts Receivable) **********************************************************************************************************************
        Dim Bill_Allocation As Double
        For x As Integer = 0 To DT_Billing.Rows.Count - 1
            DT_Account.Rows.Add(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", DT_Billing(x)("AccountCode")), DT_Billing(x)("DepartmentCode"), If(cbxBank.SelectedValue <> BankID And BankID <> 0, DataObject(String.Format("SELECT AccountTitleCode('{0}')", "217201")), DT_Billing(x)("Account")), DT_Billing(x)("Business Center"), DT_Billing(x)("Department"), DT_Billing(x)("Credit"), If((dPaidAmount.Value - Bill_Allocation) >= DT_Billing(x)("Debit"), DT_Billing(x)("Debit"), NegativeNotAllowed(dPaidAmount.Value - Bill_Allocation)), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", DT_Billing(x)("PaidFor")), "[Payable: " & FormatNumber(CDbl(DT_Billing(x)("Debit"))) & "] " & DT_Billing(x)("Remarks"), DT_Billing(x)("RequiredRemarks"), DT_Billing(x)("ID"), DT_Billing(x)("DocumentNumber"), DT_Billing(x)("Debit"), DT_Billing(x)("BusinessCode"), DT_Billing(x)("Type_ID"), ValidateComboBox(cbxPayee), DT_Billing(x)("MotherCode"))
            Bill_Allocation += If((dPaidAmount.Value - Bill_Allocation) >= DT_Billing(x)("Debit"), DT_Billing(x)("Debit"), NegativeNotAllowed(dPaidAmount.Value - Bill_Allocation))
        Next
        If dBalanceLedger.Value = 0 And dPayable.Value > 0 Then
            AccountCodeDetails("229105") 'UNEARNED INCOME
            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPaidAmount.Value - Bill_Allocation, "", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))

            GoTo Here2
        End If
        'Interest Income-Past Due (Penalty)**********************************************************************************************************************
        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))
        If GridView3.FocusedRowHandle = GridView3.RowCount - 2 And dPenalty >= dPenalty_P Then
            If dPenalty_P = 0 Then
            Else 'ZERO DLI NA I APIL PAG SUGGEST
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPenalty_P, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "DTS Penalty", "Penalty"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
            End If
        ElseIf dPenalty > 0 Then
            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPenalty, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "DTS Penalty", "Penalty"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
        End If
        'RPPD **********************************************************************************************************************

        If dRPPD_P > 0 And dBalanceLedger.Value > 0 Then 'Add dBalanceLedger.Value > 0  para kung 0 na ang RPPD sa Ledger bisag wala ni bayad kay na unearned income, dli na mu suggest og RPPD
            Availed = NegativeNotAllowed(Availed - dRPPD_P)
            If GridView3.FocusedRowHandle = GridView3.RowCount - 2 And dRPPD >= dRPPD_P Then
                If dRPPD_P = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dRPPD_P, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "RPPD"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            Else
                If dRPPD = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dRPPD, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "RPPD"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            End If
        ElseIf dRPPD_P = 0 And (dUDI > 0 Or dPrincipal > 0) Then 'For checking wala ma apil ang availed wrong condition || TotalRPPD - is the total Paid and Availed RPPD
            'MAG SAVE OG AVAILED RPPD 
            'DT_Account.Rows.Add(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))), "", DataObject(String.Format("SELECT AccountTitleCode('{0}');", If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, Availed, "RPPD", "AVAILED RPPD", DataObject(String.Format("SELECT GetRequiredRemarks('{0}');", If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))), 0, "", 0, drv("BusinessCode"), 0,ValidateComboBox(cbxPayee))
        End If
        'Interest **********************************************************************************************************************
        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420001", If(MortgageID = 2, "420002", "420006"))))
        If GridView3.FocusedRowHandle = GridView3.RowCount - 2 And dUDI >= dUDI_P Then
            If drv("Product").ToString.Contains("SHOWMONEY") And drv("AgentID") <> "" Then
                If dUDI_P * (((CDbl(drv("interest_rate")) / 12) - 0.5) / (CDbl(drv("interest_rate")) / 12)) = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI_P * (((CDbl(drv("interest_rate")) / 12) - 0.5) / (CDbl(drv("interest_rate")) / 12)), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "420103"))
                If dUDI_P * (0.5 / (CDbl(drv("interest_rate")) / 12)) = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI_P * (0.5 / (CDbl(drv("interest_rate")) / 12)), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            Else
                If dUDI_P = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI_P, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            End If
        ElseIf ((GridView3.FocusedRowHandle = GridView3.RowCount - 2 Or dBalanceLedger.Value <= (dPaidAmount.Value - dPenalty)) And Math.Round(dUDI, 2, MidpointRounding.AwayFromZero) >= dUDI_P) Then
            If dUDI > dUDI_P And Branch_DeferredIncome Then
                If dUDI_P = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI_P, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            Else
                If NegativeNotAllowed(CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - (TotalInterest)) = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - (TotalInterest), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            End If
        ElseIf dBalanceLedger.Value <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Loans Receivable")) And (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Outstanding Principal")) And If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Due Date")) And Payable_Interest > 0 Then
            If dPaidAmount.Value >= Payable_Interest Then
                If Payable_Interest = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, Payable_Interest, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            Else
                If dPaidAmount.Value - (dUDI + dPenalty + dBilling) <= 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPaidAmount.Value, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            End If
        Else
            If dUDI_P_Month > 0 And Branch_DeferredIncome And dUDI >= dUDI_P_Month And EarlySettlement = False Then
                If dUDI_P_Month = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI_P_Month, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            ElseIf dUDI = dUDI_P And Branch_DeferredIncome And dUDI_P > 0 Then
                If dUDI_P = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI_P, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            ElseIf dUDI >= dUDI_P And dUDI < (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0)) And Branch_DeferredIncome Then
                If dUDI > 0 Then
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                ElseIf dUDI_P_Month > 0 And dPrincipal >= dPrincipal_P And dPaidAmount.Value >= dUDI_P_Month + dPrincipal Then
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI_P_Month, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            ElseIf dUDI >= dUDI_P And Branch_DeferredIncome And dUDI_P > 0 Then
                If dUDI_P = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI_P, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            ElseIf dUDI > 0 And dUDI_P + dUDI_P_Month > 0 And dUDI >= (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0)) And If(Branch_DeferredIncome, 1, dUDI > (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))) Then
                If dUDI = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            ElseIf dUDI > 0 And Branch_DeferredIncome = False Then
                If dUDI = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            ElseIf dUDI > 0 And dUDI > dUDI_P_Month And If(Branch_DeferredIncome, (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0)) > 0, 1) Then
                If dUDI = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            ElseIf dUDI >= dUDI_P And dUDI < (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0)) Then
                If dUDI_P_Month > 0 Then
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI_P_Month, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            ElseIf dUDI > 0 And Branch_DeferredIncome And dUDI_P > 0 And dUDI <= dUDI_P Then
                If dUDI = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dUDI, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            End If
        End If
        'Principal **********************************************************************************************************************
        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "112001", If(MortgageID = 2, "112002", "112003"))))
        If GridView3.FocusedRowHandle = GridView3.RowCount - 2 And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P Then
            If dPrincipal_P = 0 Then
            Else 'ZERO DLI NA I APIL PAG SUGGEST
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPrincipal_P, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "Principal"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
            End If
        ElseIf ((GridView3.FocusedRowHandle = GridView3.RowCount - 2 Or dBalanceLedger.Value <= (dPaidAmount.Value - dPenalty)) And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P) Then
            If NegativeNotAllowed(CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - (TotalPayment)) = 0 Then
            Else 'ZERO DLI NA I APIL PAG SUGGEST
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - (TotalPayment), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "Principal"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
            End If
        ElseIf (EarlySettlement And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P) Then
            If dPrincipal_P = 0 Then
            Else 'ZERO DLI NA I APIL PAG SUGGEST
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPrincipal_P, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "Principal"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
            End If
        ElseIf dBalanceLedger.Value <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Loans Receivable")) And (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Outstanding Principal")) And If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Due Date")) And Payable_Interest > 0 Then
            If dPaidAmount.Value >= Payable_Interest Then
                If dPaidAmount.Value - Payable_Interest = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPaidAmount.Value - Payable_Interest, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "Principal"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            Else
                If 0 = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, 0, If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "Principal"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            End If
        Else
            If dPrincipal > CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment And CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment > 0 Then
                If (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment) = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "Principal"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            Else
                If AdvanceOnPrinciapl Then
                    'MsgBox(Math.Round(dPrincipal + (dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), 2, MidpointRounding.AwayFromZero))
                    If Math.Round(dPrincipal + (dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), 2, MidpointRounding.AwayFromZero) <= 0 Then
                    Else 'ZERO DLI NA I APIL PAG SUGGEST
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, If(Principal <= Math.Round((dPrincipal + TotalPayment) + (dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), 2, MidpointRounding.AwayFromZero), Math.Round(dPrincipal + (dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), 2, MidpointRounding.AwayFromZero) - (Math.Round((dPrincipal + TotalPayment) + (dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), 2, MidpointRounding.AwayFromZero) - Principal), Math.Round(dPrincipal + (dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), 2, MidpointRounding.AwayFromZero)), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "Principal"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                    End If
                ElseIf dUDI >= dUDI_P And dUDI < (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0)) And dPrincipal >= dUDI_P_Month And dPrincipal > dPrincipal_P Then 'ADD CONDITION dPrincipal > dPrincipal_P PARA SA MGA BIMONTHLY KAY MA APIL PAG COMPUTE ANG 2ND PAYMENT SA MONTH BISAG PANG 1ST PAYMENT PA
                    If Math.Round(dPrincipal - dUDI_P_Month, 2, MidpointRounding.AwayFromZero) = 0 Then
                    Else 'ZERO DLI NA I APIL PAG SUGGEST
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, Math.Round(dPrincipal - dUDI_P_Month, 2, MidpointRounding.AwayFromZero), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "Principal"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                    End If
                Else
                    If Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) = 0 Then
                    Else 'ZERO DLI NA I APIL PAG SUGGEST
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "Principal"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                    End If
                End If
            End If
        End If
        'DEFERRED INCOME **********************************************************************************************************************
        If Branch_DeferredIncome And drv("PaymentRequest") <> "CLOSED" And If(AdvanceOnPrinciapl, Principal <= TotalPayment + Math.Round(dPrincipal + (dUDI - Math.Abs(dUDI_P + (dUDI_P_Month - dUDI_P))), 2, MidpointRounding.AwayFromZero), 1) Then
            If dUDI > (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0)) And EarlySettlement = False Then
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229104"))
                If dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0)) = 0 Then
                Else 'ZERO DLI NA I APIL PAG SUGGEST
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, If(AdvanceOnPrinciapl, If(Principal <= Math.Round((dPrincipal + TotalPayment) + (dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), 2, MidpointRounding.AwayFromZero), (Math.Round((dPrincipal + TotalPayment) + (dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), 2, MidpointRounding.AwayFromZero) - Principal) - NegativeNotAllowed(dPaidAmount.Value - (dBalanceLedger.Value + dPenalty + dBilling)), Math.Round(dPrincipal + (dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), 2, MidpointRounding.AwayFromZero)), dUDI - (dUDI_P + Math.Max(dUDI_P_Month - dUDI_P, 0))), If(cbxBank.SelectedValue <> BankID And BankID <> 0, "", "UDI"), "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                End If
            End If
        End If

        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "620061"))
        If RemoveRPPDFromBalanceLedger Then
            If ((GridView3.FocusedRowHandle = GridView3.RowCount - 2 Or dPaidAmount.Value > (dBalanceLedger.Value + dPenalty)) And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P) Or EarlySettlement Then
                If dPrincipal > dPrincipal_P Then
                    If EarlySettlement Then
                        If Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P, "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                        End If
                    Else
                        If dPaidAmount.Value - (dBalanceLedger.Value + dPenalty) = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPaidAmount.Value - (dBalanceLedger.Value + dPenalty), "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                        End If
                    End If
                End If
            ElseIf ((GridView3.FocusedRowHandle = GridView3.RowCount - 2 Or dPaidAmount.Value > ((dBalanceLedger.Value - Availed) + dPenalty)) And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P) Or EarlySettlement Then
                If dPrincipal > dPrincipal_P And Availed > 0 Then
                    Dim TotalDebitX As Double
                    Dim TotalCreditX As Double
                    ComputationLog = ""
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        TotalDebitX += CDbl(DT_Account(x)("Debit"))
                        TotalCreditX += CDbl(DT_Account(x)("Credit"))
                    Next
                    If TotalCreditX <> TotalDebitX Then
                        If EarlySettlement Then
                            If Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P = 0 Then
                            Else 'ZERO DLI NA I APIL PAG SUGGEST
                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P, "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                            End If
                        Else
                            If dPaidAmount.Value - (dBalanceLedger.Value + dPenalty) = 0 Then
                            Else 'ZERO DLI NA I APIL PAG SUGGEST
                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPaidAmount.Value - (dBalanceLedger.Value - Availed + dPenalty), "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                            End If
                        End If
                    End If
                End If
            End If
        Else
            If ((GridView3.FocusedRowHandle = GridView3.RowCount - 2 Or dPaidAmount.Value > ((dBalanceLedger.Value - Availed) + dPenalty)) And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P) Or EarlySettlement Then
                If dPrincipal > dPrincipal_P Or dUDI > dUDI_P Or (dPrincipal_P = 0 And dPenalty_P = 0 And dBalanceLedger.Value = 0 And dPayable.Value = 0 And dUDI > dUDI_P) Then
                    If EarlySettlement Then
                        If (Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P) + (Math.Round(dUDI, 2, MidpointRounding.AwayFromZero) - dUDI_P) = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, (Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P) + (Math.Round(dUDI, 2, MidpointRounding.AwayFromZero) - dUDI_P), "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                        End If
                    Else
                        If NegativeNotAllowed(dPaidAmount.Value - (NegativeNotAllowed(dBalanceLedger.Value - Availed) + dPenalty)) = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", drv("BusinessCode"))), "", 0, dPaidAmount.Value - (NegativeNotAllowed(dBalanceLedger.Value - Availed) + dPenalty), "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, drv("BusinessCode"), 0, ValidateComboBox(cbxPayee), DT_Temp_Account(0)("MotherCode"))
                        End If
                    End If
                End If
            End If
        End If

Here2:
        GridControl2.DataSource = DT_Account
        btnRemove_Account.Enabled = True
        Dim TotalDebit As Double
        Dim TotalCredit As Double
        Dim Total_CIB As Double
        ComputationLog = ""
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                Total_CIB += CDbl(DT_Account(x)("Debit"))
            End If
            If GridView2.GetRowCellValue(x, "Account") <> "" Then
                ComputationLog = ComputationLog & "[" & GridView2.GetRowCellValue(x, "Account") & " P" & If(CDbl(DT_Account(x)("Debit")) > 0, FormatNumber(DT_Account(x)("Debit"), 2) & " (DEBIT)", FormatNumber(DT_Account(x)("Credit"), 2) & " (CREDIT)") & "]"
            End If
        Next
        If GridView2.RowCount > 7 Then
            GridColumn32.Width = 226 - 17
        Else
            GridColumn32.Width = 226
        End If
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB
        Cursor = Cursors.Default
    End Sub

    Private Sub Compute()
        If FirstLoad Or SuperTabControl1.SelectedTabIndex = 1 Or cbxPayee.SelectedIndex = -1 Or GridView3.RowCount = 0 Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        TotalRPPD_Payable = 0
        dRPPD_P = 0
        dUDI_P = 0
        dUDI_P_Month = 0
        dPrincipal_P = 0
        Payable_Interest = 0
        EarlySettlement = False
        RPPD_Application = 0
        If cbxAvailed.Enabled = False And (TotalRPPD + TotalInterest + TotalPayment) = 0 Then
            FirstLoad = True
            If If(IsDate(GridView3.GetRowCellValue(1, "Due Date")), CDate(GridView3.GetRowCellValue(1, "Due Date")).AddDays(BankingDays(0, CDate(GridView3.GetRowCellValue(1, "Due Date")))), Date.Now) >= DateValue(dtpORDate.Value) Then
                cbxAvailed.Checked = True
            Else
                cbxAvailed.Checked = False
            End If
            FirstLoad = False
        End If
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                RPPD_Application += GridView3.GetRowCellValue(x, "RPPD")
                If If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetRowCellValue(x, "Due Date")).AddDays(If(TotalRPPD_Payable > 0, 0, BankingDays(If(cbxAvailed.Checked And TotalRPPD_Payable < CDbl(GridView3.GetRowCellValue(x, "RPPD")), AvailedRPPD + 0, 0), GridView3.GetFocusedRowCellValue("Due Date")))) Then 'IF PAST DUE NA THEN NI TUNONG OG HOLIDAY OR WEEKEND FORFEITED GIHAPON ANG RPPD
                    'If If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetRowCellValue(x, "Due Date")).AddDays(BankingDays(If(cbxAvailed.Checked And TotalRPPD_Payable < CDbl(GridView3.GetRowCellValue(x, "RPPD")), AvailedRPPD + 0, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))) Then
                    TotalRPPD_Payable += GridView3.GetRowCellValue(x, "RPPD")
                End If
            End If
        Next
        Dim AsOf As Date = If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                If If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                    GridView3.FocusedRowHandle = x
                    AsOf = If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))
                    dUDI_P += GridView3.GetRowCellValue(x, "Interest Income")
                    dPrincipal_P += GridView3.GetRowCellValue(x, "Principal Allocation")
                ElseIf x = GridView3.RowCount - 2 And If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) < CDate(GridView3.GetRowCellValue(1, "Due Date")) Then
                    GridView3.FocusedRowHandle = 1
                    If dPrincipal_P = 0 Then
                        Exit For
                    End If
                    AsOf = If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))
                    dUDI_P += GridView3.GetRowCellValue(1, "Interest Income")
                    dPrincipal_P += GridView3.GetRowCellValue(1, "Principal Allocation")
                ElseIf x <= GridView3.FocusedRowHandle And If(cbxRemittance.Checked, Format(dtpRemittance.Value, "yyyy-MM"), If(cbxOnline.Checked, Format(dtpDeposit.Value, "yyyy-MM"), If(cbxAR.Checked, Format(dtpAR.Value, "yyyy-MM"), Format(dtpPostingDate.Value, "yyyy-MM")))) = Format(CDate(GridView3.GetRowCellValue(x, "Due Date")), "yyyy-MM") And drv("Product_Payment") <> "Daily" And drv("Product_Payment") <> "Weekly" Then
                    dUDI_P += GridView3.GetRowCellValue(1, "Interest Income")
                    dPrincipal_P += GridView3.GetRowCellValue(1, "Principal Allocation")
                ElseIf If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) < CDate(GridView3.GetRowCellValue(x, "Due Date")) And Format(If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))), "MMMM, yyyy") = Format(CDate(GridView3.GetRowCellValue(x, "Due Date")), "MMMM, yyyy") Then 'FOR DEFERRED INCOME
                    dUDI_P_Month += GridView3.GetRowCellValue(x, "Interest Income")
                End If
            End If
            If x > GridView3.FocusedRowHandle Then
                Exit For
            End If
        Next

        If btnCalculator.Enabled Then
            Dim AdvanceLastPay As Date
            For x As Integer = 1 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
                Else
                    If FaceAmount - (TotalPayment + TotalRPPD + TotalInterest) <= CDbl(GridView3.GetRowCellValue(x, "Loans Receivable")) Then
                        AdvanceLastPay = GridView3.GetRowCellValue(x, "Due Date")
                    End If
                End If
            Next
            If LastPayment <= AdvanceLastPay Then
                LastPayment = AdvanceLastPay
            End If
            If drv("PaymentRequest") = "CLOSED" Then
                dPenalty_P = 0
            Else
                dPenalty_P = ComputePenalty(drv("AmountApplied"), drv("Face_Amount"), drv("Released"), If(drv("Product").ToString.ToUpper.Contains("DEALER"), Math.Round(drv("Interest") / drv("Terms"), 2, MidpointRounding.AwayFromZero), If(drv("Product_Payment") = "Monthly" Or drv("Product_Payment") = "Daily" Or drv("Product_Payment") = "Weekly", drv("GMA"), CDbl(drv("GMA")) / 1)), TotalPayment, LastPayment, drv("Terms"), AsOf, TotalInterest, TotalRPPD, TotalUnpaidPenalty, drv("Product_ID"), DefaultPenalty, GridView3.FocusedRowHandle <> 1, drv("with_Interest"), drv("FDD"), drv("Product_Payment"), drv("Product"), TotalWaivePenalty, drv("Interest"), GridView3.GetFocusedRowCellValue("RPPD"), TotalWaive, TotalWaiveRPPD, GridControl3, cbxAvailed.Checked, drv("LDD"), ValidateComboBox(cbxPayee))
            End If
            UnroundedPenalty = dPenalty_P
            If Round_Up Then 'cbxUp.Checked = True
                dPenalty_P = Math.Ceiling(dPenalty_P)
            End If
        End If

        If (If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetFocusedRowCellValue("Due Date")).AddDays(If(FaceAmount - (TotalPayment + TotalRPPD + TotalInterest) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle - 1, "Loans Receivable")), If(GridView3.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 0, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))), 0))) Or (TotalRPPD = 0 And dRPPD_P > 0) Then
        Else
            If dPenalty_P = 0 And LastPayment < If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) Then
                TotalRPPD_Payable = NegativeNotAllowed(TotalRPPD_Payable - GridView3.GetRowCellValue(1, "RPPD"))
            End If
        End If
        If GridColumn41.Visible Then
            dRPPD_P += (RPPD - GridView3.GetRowCellValue(0, "Total_RPPD"))
            dUDI_P += (UDI - GridView3.GetRowCellValue(0, "Unearn Income"))
            dPrincipal_P += (Principal - GridView3.GetRowCellValue(0, "Outstanding Principal"))
        End If
        If CompanyMode = 0 Then
            dRPPD_P = 0
        Else
            dRPPD_P = NegativeNotAllowed((TotalRPPD_Payable - TotalRPPD) - TotalWaiveRPPD)
        End If

        Dim dUDI_A As Double
        Dim dPrincipal_A As Double
        dUDI_A = dUDI_P - TotalInterest
        dUDI_P_Month = NegativeNotAllowed((dUDI_P_Month + dUDI_P) - TotalInterest)
        dUDI_P = NegativeNotAllowed(dUDI_P - TotalInterest)
        If dUDI_P > 0 Then
            Payable_Interest = dUDI_P
            If dBalanceLedger.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")) And TotalPayment > dPrincipal_P Then
                dUDI_P = NegativeNotAllowed(dUDI_P - Math.Abs(dPrincipal_P - TotalPayment))
            ElseIf dBalanceLedger.Value < CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle - 1, "Loans Receivable")) And GridView3.FocusedRowHandle > 1 And TotalPayment > dPrincipal_P Then
                dUDI_P = NegativeNotAllowed(dUDI_P - Math.Abs(dPrincipal_P - TotalPayment))
            End If
        End If
        If btnCalculator.Enabled = False And drv("PRODUCT").ToString.Contains("SHOWMONEY") = False Then
            dUDI_P = 0
        End If
        dPrincipal_A = dPrincipal_P - TotalPayment
        dPrincipal_P = NegativeNotAllowed(dPrincipal_P - TotalPayment)
        If dBalanceLedger.Value = 0 Then
            dRPPD_P = 0
            dUDI_P = 0
            dPrincipal_P = 0
        End If

        If From_Credit Then
            If drv("PRODUCT").ToString.Contains("SHOWMONEY") And If(cbxRemittance.Checked, Format(dtpRemittance.Value, "yyyy-MM-dd"), If(cbxOnline.Checked, Format(dtpDeposit.Value, "yyyy-MM-dd"), If(cbxAR.Checked, Format(dtpAR.Value, "yyyy-MM-dd"), Format(dtpPostingDate.Value, "yyyy-MM-dd")))) < Format(CDate(GridView3.GetFocusedRowCellValue("Due Date")), "yyyy-MM-dd") Then
                dPayable.Value = (dBilling_P + dPenalty_P + dRPPD_P + dUDI_P)
            Else
                dPayable.Value = (dBilling_P + dPenalty_P + dRPPD_P + dUDI_P + dPrincipal_P)
            End If
            If dUDI_A < 0 Then
                dPayable.Value = NegativeNotAllowed(dPayable.Value + dUDI_A)
            End If
            If dPrincipal_A < 0 Then
                dPayable.Value = NegativeNotAllowed(dPayable.Value + dPrincipal_A)
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadCompanyMode()
        If Prev_CompanyMode = CompanyMode Then
            Exit Sub
        Else
            Prev_CompanyMode = CompanyMode
        End If
        If CompanyMode = 0 Then
            btnEarly.Visible = False

            GridColumn20.Visible = False
            GridColumn24.Visible = False

            cbxAccount.DataSource = DT_AccountsM.Copy
            RepositoryItemSearchLookUpEdit1.DataSource = DT_AccountsM_V2.Copy

            If GridView3.RowCount > 16 Then
                GridColumn17.Width = (55 + 10) - 5
                GridColumn18.Width = (68 + 20) - 2
                GridColumn19.Width = (68 + 20) - 2
                GridColumn21.Width = (68 + 20) - 2
                GridColumn22.Width = (68 + 20) - 2
                GridColumn23.Width = (68 + 20) - 2
                GridColumn34.Width = (68 + 20) - 2
            Else
                GridColumn17.Width = 55 + 10
                GridColumn18.Width = 68 + 20
                GridColumn19.Width = 68 + 20
                GridColumn21.Width = 68 + 20
                GridColumn22.Width = 68 + 20
                GridColumn23.Width = 68 + 20
                GridColumn34.Width = 68 + 20
            End If
        Else
            cbxAccount.DataSource = DT_Accounts.Copy
            RepositoryItemSearchLookUpEdit1.DataSource = DT_Accounts_V2.Copy

            GridColumn20.Visible = True
            GridColumn24.Visible = True
            If GridColumn41.Visible Then
                GridColumn16.VisibleIndex = 0
                GridColumn17.VisibleIndex = 1
                GridColumn18.VisibleIndex = 2
                GridColumn41.VisibleIndex = 3
                GridColumn19.VisibleIndex = 4
                GridColumn20.VisibleIndex = 5
                GridColumn21.VisibleIndex = 6
                GridColumn22.VisibleIndex = 7
                GridColumn23.VisibleIndex = 8
                GridColumn24.VisibleIndex = 9
                GridColumn42.VisibleIndex = 10
                GridColumn34.VisibleIndex = 11
            Else
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
            End If

            If GridView3.RowCount > 16 Then
                GridColumn17.Width = 58 - 1
                GridColumn18.Width = 68 - 2
                GridColumn19.Width = 68 - 2
                GridColumn20.Width = 65 - 2
                GridColumn21.Width = 68 - 2
                GridColumn22.Width = 68 - 2
                GridColumn23.Width = 68 - 2
                GridColumn24.Width = 65 - 2
                GridColumn34.Width = 68 - 2
            Else
                GridColumn17.Width = 58
                GridColumn18.Width = 68
                GridColumn19.Width = 68
                GridColumn20.Width = 65
                GridColumn21.Width = 68
                GridColumn22.Width = 68
                GridColumn23.Width = 68
                GridColumn24.Width = 65
                GridColumn34.Width = 68
            End If
        End If
    End Sub

    Private Sub LoadAmortization(Grid As DevExpress.XtraGrid.GridControl)
        Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', IF(`No` = '','',FORMAT(InterestIncome,2)) AS 'Interest Income', IF(`No` = '','',FORMAT(RPPD,2)) AS 'RPPD', IF(`No` = '','',FORMAT(PrincipalAllocation,2)) AS 'Principal Allocation', FORMAT(OutstandingPrincipal,2) AS 'Outstanding Principal', FORMAT(Total_RPPD,2) AS 'Total_RPPD', FORMAT(UnearnIncome,2) AS 'Unearn Income', FORMAT(LoansReceivable,2) AS 'Loans Receivable', IF(`No` = '','',FORMAT(Penalty,2)) AS 'Penalty', FORMAT(PenaltyBalance,2) AS 'Penalty Balance' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", cbxPayee.SelectedValue))
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
            GridColumn41.VisibleIndex = 3
            GridColumn19.VisibleIndex = 4
            GridColumn20.VisibleIndex = 5
            GridColumn21.VisibleIndex = 6
            GridColumn22.VisibleIndex = 7
            GridColumn23.VisibleIndex = 8
            GridColumn24.VisibleIndex = 9
            GridColumn42.VisibleIndex = 10
            GridColumn34.VisibleIndex = 11
        Else
            If cbxPayee.Enabled Then
                cbxAvailed.Enabled = True
            End If
            GridColumn41.Visible = False
            GridColumn42.Visible = False

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
        End If
        Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, ), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), 0, 0, 0, 0, Format(T_Penalty, 2), 0)
        Grid.DataSource = Temp_DT

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If CompanyMode = 0 Then
            If GridView3.RowCount > 16 Then
                GridColumn17.Width = (55 + 10) - 5
                GridColumn18.Width = (68 + 20) - 2
                GridColumn19.Width = (68 + 20) - 2
                GridColumn21.Width = (68 + 20) - 2
                GridColumn22.Width = (68 + 20) - 2
                GridColumn23.Width = (68 + 20) - 2
                GridColumn34.Width = (68 + 20) - 2
            Else
                GridColumn17.Width = 55 + 10
                GridColumn18.Width = 68 + 20
                GridColumn19.Width = 68 + 20
                GridColumn21.Width = 68 + 20
                GridColumn22.Width = 68 + 20
                GridColumn23.Width = 68 + 20
                GridColumn34.Width = 68 + 20
            End If
        Else
            If GridView3.RowCount > 16 Then
                GridColumn17.Width = 65 - 1
                GridColumn18.Width = 68 - 2
                GridColumn19.Width = 68 - 2
                GridColumn20.Width = 65 - 2
                GridColumn21.Width = 68 - 2
                GridColumn22.Width = 68 - 2
                GridColumn23.Width = 68 - 2
                GridColumn24.Width = 65 - 2
                GridColumn34.Width = 68 - 2
            Else
                GridColumn17.Width = 65
                GridColumn18.Width = 68
                GridColumn19.Width = 68
                GridColumn20.Width = 65
                GridColumn21.Width = 68
                GridColumn22.Width = 68
                GridColumn23.Width = 68
                GridColumn24.Width = 65
                GridColumn34.Width = 68
            End If
        End If
        GridView3.BestFitColumns()

        If CDbl(drv("Interest_N")) + CDbl(drv("RPPD_N")) + CDbl(drv("Principal_N")) > 0 Then
            Dim TotalInterest As Double
            Dim TotalRPPD As Double
            Dim TotalPrincipal As Double
            With GridView3
                For x As Integer = 1 To .RowCount - 1
                    If x = .RowCount - 2 Then 'Adjustment
                        TotalInterest += .GetRowCellValue(x, "Interest Income")
                        TotalRPPD += .GetRowCellValue(x, "RPPD")
                        TotalPrincipal += .GetRowCellValue(x, "Principal Allocation")
                    ElseIf x = .RowCount - 1 Then 'Total
                    Else
                        TotalInterest += .GetRowCellValue(x, "Interest Income")
                        TotalRPPD += .GetRowCellValue(x, "RPPD")
                        TotalPrincipal += .GetRowCellValue(x, "Principal Allocation")
                    End If
                    If x = .RowCount - 1 Then 'Total
                    Else
                    End If
                Next
            End With
        End If
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
            .FolderName = "Official Receipt-" & GridView1.GetFocusedRowCellValue("Document Number")
            .ARNumber = GridView1.GetFocusedRowCellValue("Document Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Document Number")
            .Type = "Official Receipt"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If btnCheck.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        Dim Signatory As Boolean
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

        If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) And Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .btnResend.Visible = True
                .btnAttachments.Visible = True
                .OTP = Code_Check
                .lblBilling.Visible = False
                Dim Result = .ShowDialog
                If Result = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "EmplID"
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE';", btnCheck.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            Code = GenerateOTAC()
                            '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                            If Auto_Notification Then
                                ApproveNotification(Code, False)
                            End If
                            '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                            DataObject(String.Format("UPDATE official_receipt SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, .cbxProvider.SelectedValue, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Official Receipt", "Check", String.Format("Checked Official Receipt of {0} with the total amount of {1}. [Via OTAC]", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                            Clear(True)
                            LoadPayee()
                        End If
                        .Dispose()
                    End With
                ElseIf Result = DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    CheckNotification(Code_Check, True)
                    Cursor = Cursors.Default
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you check this Official Receipt?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                Code_Approve = Code
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    Dim Msg As String = ""
                    Dim EmailTo As String = ""
                    Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Official Receipt of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_Signatory(x)("Phone") = "" Then
                            Else
                                SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_Signatory(x)("EmailAdd") = "" Then
                            Else
                                EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                            End If
                        End If
                    Next
                    If EmailTo = "" Then
                    Else
                        Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
                        AttachmentFiles = New ArrayList()
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        GenerateReceipt(False, FName, txtChecked.Text, txtApproved.Text)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                DataObject(String.Format("UPDATE official_receipt SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Official Receipt", "Check", String.Format("Checked Official Receipt of {0} with the total amount of {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                Clear(True)
                LoadPayee()
            End If
        End If

        If From_GL Then
            With btnCheck
                .DialogResult = DialogResult.OK
                .DialogResult = DialogResult.OK
                .PerformClick()
            End With
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If btnApprove.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        Dim Prev As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DocumentNumber),'') AS 'DocumentNumber' FROM official_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'CA' AND `status` = 'ACTIVE' AND Voucher_Status IN ('PENDING','CHECKED') AND ID < {1};", cbxPayee.SelectedValue, ID))
        If Prev = "" Then
        Else
            MsgBox(String.Format("Please Approve the previous transactions of this Account with Document Number(s): {0}.", Prev), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim Signatory As Boolean
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) And Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .btnResend.Visible = True
                .btnAttachments.Visible = True
                .OTP = Code_Approve
                .lblBilling.Visible = False
                Dim Result = .ShowDialog
                If Result = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "EmplID"
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE';", btnApprove.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            Dim SQL As String = String.Format("UPDATE accounting_entry SET PostStatus = 'POSTED', ORDate = '{1}' WHERE REPLACE(CVNumber,' [Discount]','') = '{0}' AND `Status` = 'ACTIVE';", txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate))

                            DataObject(String.Format(SQL & "UPDATE official_receipt SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}';", ID, .cbxProvider.SelectedValue, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Official Receipt", "Approve", String.Format("Approved Official Receipt of {0} with the total amount of {1}. [Via OTAC]", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                            If DTS Then
                                LoadDTS(ID)
                            End If
                            Clear(True)
                            LoadPayee()
                        End If
                        .Dispose()
                    End With
                ElseIf Result = DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    ApproveNotification(Code_Approve, True)
                    Cursor = Cursors.Default
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you want to approve this Official Receipt?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = String.Format("UPDATE accounting_entry SET PostStatus = 'POSTED', ORDate = '{1}' WHERE REPLACE(CVNumber,' [Discount]','') = '{0}' AND `Status` = 'ACTIVE';", txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate))

                DataObject(String.Format(SQL & "UPDATE official_receipt SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Official Receipt", "Approve", String.Format("Approved Official Receipt of {0} with the total amount of {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                If DTS Then
                    LoadDTS(ID)
                End If
                Clear(True)
                LoadPayee()
            End If
        End If

        If From_GL Then
            With btnApprove
                .DialogResult = DialogResult.OK
                .DialogResult = DialogResult.OK
                .PerformClick()
            End With
        End If
    End Sub

    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If MsgBoxYes("Are you sure you want to disapprove this Official Receipt?") = MsgBoxResult.Yes Then
            Dim Prev As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DocumentNumber),'') AS 'DocumentNumber' FROM official_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'CA' AND `status` = 'ACTIVE' AND voucher_status IN ('PENDING', 'CHECKED', 'APPROVED') AND ID > {1};", cbxPayee.SelectedValue, ID))
            If Prev = "" Then
            Else
                MsgBox(String.Format("Disapproval/Cancellation of this transaction might affect the computation of the Document Number(s): {0}. Please disapprove/cancel the new Official Receipt first.", Prev), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            Dim SQL As String = String.Format("UPDATE official_receipt SET `status` = 'DISAPPROVED' WHERE ID = '{0}';", ID)
            If cbxCheckNumber.Tag <> "" Then
                SQL &= String.Format(" UPDATE check_received SET `status` = 'ACTIVE', Remarks = CONCAT(Remarks, ' [CANCELLED]') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND `status` = 'CLEARED';", cbxPayee.SelectedValue, cbxCheckNumber.Tag)
            End If
            If btnEarlySettlement.Visible Then
                SQL &= String.Format("UPDATE credit_earlysettlement SET early_status = 'PAID', Paid = Paid - {3}, ORNumber = '{0}' WHERE CreditNumber = '{1}' AND `status` = 'ACTIVE' AND early_status IN ('PENDING','PAID') AND IF(early_status = 'PAID',ORNumber != '',ORNumber = '') AND AsOf <= '{2}';", txtDocumentNumber.Text, ValidateComboBox(cbxPayee), Format(If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))), "yyyy-MM-dd"), dPaidAmount.Value)
            End If
            SQL &= String.Format(" UPDATE accounting_entry SET ORNum = '', `status` = IF(PaidFor = 'Penalty-W','WAITING','WAITING'), CVNumber = '', Amount = IF(PaidFor = 'Penalty-W',Payable - PenaltyPayable,Amount) WHERE REPLACE(CVNumber,' [Discount]','') = '{0}' AND PaidFor IN ('Penalty-W','RPPD-W');", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'DISAPPROVED' WHERE REPLACE(CVNumber,' [Discount]','') = '{0}';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_from SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_to SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE loans_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "AR_DocumentNumber") = "" Then
                Else
                    'IF IN CASE GI YAGAW ANG ACCOUNTING ENTRIES THEN GI DELETE OR DISAPPROVE
                    DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = or_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, PaidFor, Remarks, Required AS 'RequiredRemarks', AR_DetailsID, AR_DocumentNumber, AR_Payable, BusinessCode, TypeID(AccountCode) AS 'Type_ID', CreditNumber, MotherCode FROM or_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", txtDocumentNumber.Text))
                    GridControl2.DataSource = DT_Account
                    Exit For
                End If
            Next
            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "AR_DocumentNumber") = "" Then
                Else
                    DataObject(String.Format("UPDATE accounts_receivable SET Paid = Paid - {1}, `AR_Status` = IF(Paid - {1} = 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}';", GridView2.GetRowCellValue(x, "AR_DocumentNumber"), CDbl(GridView2.GetRowCellValue(x, "Credit"))))
                    SQL &= String.Format("UPDATE ar_details SET Paid = Paid - {1} WHERE ID = '{0}'; ", GridView2.GetRowCellValue(x, "AR_DetailsID"), CDbl(GridView2.GetRowCellValue(x, "Credit")))
                End If
            Next
            If EarlySettlement Or dBalanceLedger.Value + dPenalty <= dPaidAmount.Value Then
                SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", cbxPayee.SelectedValue)
            End If
            DataObject(SQL)
            PaymentDT = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%' OR EntryType = 'DEBIT',0 - Amount,Amount) END),0) AS 'Total RPPD', IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Penalty Payment', IFNULL((SELECT PenaltyPayable FROM accounting_entry A WHERE A.PaidFor IN ('Penalty','Penalty-W') AND A.`status` = 'ACTIVE' AND A.ReferenceN = '{0}' AND A.JVNumber = '' ORDER BY ID DESC LIMIT 1),0) AS 'Total Unpaid Penalty', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('RPPD-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived RPPD', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('Penalty-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived Penalty', IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Principal', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Interest', IFNULL((SELECT MAX(IF(ARDate = '',IF(RemittanceDate = '',ORDate,RemittanceDate),ARDate)) FROM official_receipt WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND JVNumber = ''),IFNULL(MAX((CASE WHEN JVNum = '' AND JVNumber = '' THEN ORDate END)),ReleasedDate('{0}'))) AS 'Last Payment' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", ValidateComboBox(cbxPayee), Format(dtpORDate.Value, "yyyy-MM-dd")))
            If PaymentDT.Rows.Count > 0 Then
                TotalRPPD = PaymentDT(0)("Total RPPD")
                TotalInterest = PaymentDT(0)("Total Interest")
                TotalPayment = PaymentDT(0)("Total Principal")
                TotalWaivePenalty = PaymentDT(0)("Total Penalty Payment")
                TotalWaive = PaymentDT(0)("Total Waived Penalty")
                TotalWaiveRPPD = PaymentDT(0)("Total Waived RPPD")
                TotalUnpaidPenalty = PaymentDT(0)("Total Unpaid Penalty")
                LastPayment = PaymentDT(0)("Last Payment")
                If TotalWaive + TotalWaiveRPPD > 0 Then
                    btnWaiveRemove.Enabled = True
                    'cbxBank.Size = New Point(313, 25)
                Else
                    btnWaiveRemove.Enabled = False
                    'cbxBank.Size = New Point(381, 25)
                End If
            End If
            dBalanceLedger.Value = GetBalanceLedger(cbxPayee.SelectedValue)
            If dBalanceLedger.Value > 0 Then
                SQL = String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", cbxPayee.SelectedValue)
                DataObject(SQL)
            End If

            Logs("Official Receipt", "Disapprove", Reason, String.Format("Disapprove Official Receipt of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "")
            PanelEx10.Enabled = True
            PanelEx2.Enabled = True
            GridView2.OptionsBehavior.Editable = True
            cbxPayee.Enabled = True
            LoadPayee()
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Disapproved", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub IDeposit_Click(sender As Object, e As EventArgs) Handles iDeposit.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CLEARING" Then
                If MsgBoxYes("Official Receipt is already DEPOSITED, would you like to proceed?") = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Official Receipt is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Type") = "ONLINE" Then
                MsgBox("Official Receipt is paid thru online, no need to deposit.", MsgBoxStyle.Information, "Info")
                Exit Sub
                'ElseIf GridView1.GetFocusedRowCellValue("Type") = "CHECK" Then
                '    MsgBox("Official Receipt is paid thru check, no need to deposit.", MsgBoxStyle.Information, "Info")
                '    Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Official Receipt is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Official Receipt is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "REVERSED" Then
                MsgBox("Official Receipt is already REVERSED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED" Then
                MsgBox("Official Receipt is already CLEARED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim D As New FrmDate
        With D
            If GridView1.GetFocusedRowCellValue("DepositDate").ToString = "" Then
                .dtpClear.Value = Date.Now
            Else
                .dtpClear.Value = GridView1.GetFocusedRowCellValue("DepositDate")
            End If
            .lblTitle.Text = "DEPOSIT"
            .lblDeposit.Text = "Deposit Date :"
            .btnClear.Text = "Deposit"
            If .ShowDialog = DialogResult.OK Then
                Dim SQL As String
                Dim Rows As New ArrayList()
                Dim Docs As String = ""
                Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
                If selectedRowHandles.Length > 1 Then
                    Dim I As Integer
                    For I = 0 To selectedRowHandles.Length - 1
                        Dim selectedRowHandle As Integer = selectedRowHandles(I)
                        If (selectedRowHandle >= 0) Then
                            Rows.Add(GridView1.GetDataRow(selectedRowHandle))
                        End If
                    Next
                    For x As Integer = 0 To selectedRowHandles.Length - 1
                        Docs &= "'" & Rows(x)("Document Number") & "'"
                        If x < selectedRowHandles.Length - 1 Then
                            Docs &= ", "
                        End If
                    Next
                    SQL = String.Format("UPDATE official_receipt SET DepositDate = '{1}' WHERE DocumentNumber IN ({0}) AND Voucher_Status = 'APPROVED';", Docs, FormatDatePicker(.dtpClear))
                Else
                    SQL = String.Format("UPDATE official_receipt SET DepositDate = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), FormatDatePicker(.dtpClear))
                End If
                DataObject(SQL)
                Logs("Official Receipt", "Deposit", String.Format("Deposit Official Receipt of {0} with the total amount of {1}.", GridView1.GetFocusedRowCellValue("Payee") & " - " & GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Amount")), "", "", "", "")
                MsgBox("Successfully Deposited!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        End With
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED" Then
                If MsgBoxYes("Official Receipt is already CLEARED, would you like to proceed?") = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
            ElseIf (GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL") Then
                MsgBox("Official Receipt is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Type") = "ONLINE" Then
                MsgBox("Official Receipt is paid thru online, no need to clear deposit.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Type") = "CASH" Then
                MsgBox("Official Receipt is paid thru cash, no need to clear deposit.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Official Receipt is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Official Receipt is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "REVERSED" Then
                MsgBox("Official Receipt is already REVERSED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") <> "FOR CLEARING" Then
                MsgBox("Official Receipt is not yet FOR CLEARING.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim D As New FrmDate
        With D
            If GridView1.GetFocusedRowCellValue("ClearDate").ToString = "" Then
                .dtpClear.Value = Date.Now
            Else
                .dtpClear.Value = GridView1.GetFocusedRowCellValue("ClearDate")
            End If
            .lblTitle.Text = "CLEAR"
            .lblDeposit.Text = "Clear Date :"
            .btnClear.Text = "Clear"
            If .ShowDialog = DialogResult.OK Then
                Dim SQL As String
                Dim Rows As New ArrayList()
                Dim Docs As String = ""
                Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
                If selectedRowHandles.Length > 1 Then
                    Dim I As Integer
                    For I = 0 To selectedRowHandles.Length - 1
                        Dim selectedRowHandle As Integer = selectedRowHandles(I)
                        If (selectedRowHandle >= 0) Then
                            Rows.Add(GridView1.GetDataRow(selectedRowHandle))
                        End If
                    Next
                    For x As Integer = 0 To selectedRowHandles.Length - 1
                        Docs &= "'" & Rows(x)("Document Number") & "'"
                        If x < selectedRowHandles.Length - 1 Then
                            Docs &= ", "
                        End If
                    Next
                    SQL = String.Format("UPDATE official_receipt SET ClearDate = '{1}' WHERE DocumentNumber IN ({0}) AND Voucher_Status = 'APPROVED';", Docs, FormatDatePicker(.dtpClear))
                Else
                    SQL = String.Format("UPDATE official_receipt SET ClearDate = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), FormatDatePicker(.dtpClear))
                End If
                DataObject(SQL)
                Logs("Official Receipt", "Clear", String.Format("Clear Official Receipt of {0} with the total amount of {1}.", GridView1.GetFocusedRowCellValue("Payee") & " - " & GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Amount")), "", "", "", "")
                MsgBox("Successfully Cleared!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        End With
    End Sub

    Private Sub IBounce_Click(sender As Object, e As EventArgs) Handles iBounce.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Type") <> "CHECK" Then
                MsgBox("Payment Type of selected Official Receipt is not Check.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Official Receipt is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Official Receipt is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Official Receipt is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Bounce As New FrmBouncedReason
        Dim BounceID As Integer = 0
        Dim BounceRemarks As String = ""
        Dim BounceReason As String = ""
        With Bounce
            If .ShowDialog = DialogResult.OK Then
                BounceID = .BounceID
                BounceReason = .BounceReason
                BounceRemarks = .txtRemarks.Text
            Else
                Exit Sub
            End If
        End With

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
            Logs("Official Receipt", "Bounce Check", "Journal Voucher", "", "", "", "")
            .cbxLA.Enabled = False
            .cbxCV.Enabled = False
            .cbxACR.Enabled = False
            .cbxAP.Enabled = False
            .cbxDT.Enabled = False
            .cbxDF.Enabled = False
            .cbxAR.Enabled = False
            .cbxLOE.Enabled = False
            .cbxJV.Enabled = False
            .cbxOR.Enabled = False
            .cbxUR.Enabled = False
            .cbxDI.Enabled = False
            .cbxRS.Enabled = False
            .cbxITL.Enabled = False
            .cbxROPA.Enabled = False
            .cbxDTS.Enabled = False
            .cbxOR.Checked = True
            .From_ACR = True
            .BankID = GridView1.GetFocusedRowCellValue("BankID")
            .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("ID")
            .BounceID = BounceID
            .Bounce = BounceReason
            .BounceRemarks = BounceRemarks

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub GridView3_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        If GridView3.RowCount = 0 Then
            Exit Sub
        End If

        Dim RightRow As Integer = 0
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                If If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                    RightRow = x
                ElseIf x = GridView3.RowCount - 2 And If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) < CDate(GridView3.GetRowCellValue(1, "Due Date")) Then
                    RightRow = 1
                End If
            End If
        Next
        If GridView3.FocusedRowHandle = RightRow Then
        Else
            GridView3.FocusedRowHandle = RightRow
        End If
    End Sub

    Private Sub BtnCalculator_Click(sender As Object, e As EventArgs) Handles btnCalculator.Click
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim SOA As New FrmSOA
        With SOA
            FormRestriction(26)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            .From_Payment = True
            .From_OR = True
            .CreditNumber = cbxPayee.SelectedValue
            If btnEarlySettlement.Visible Then
                .EarlySettlement = True
                .dtpAsOf.Enabled = False
                .lblTotalAmountDue.Text = "Liquidating Value :"
            End If
            .Show()
            .FirstLoad = True
            .GridControl3.DataSource = GridControl3.DataSource
            'If GridColumn41.Visible Then
            '    .GridColumn16.VisibleIndex = 0
            '    .GridColumn17.VisibleIndex = 1
            '    .GridColumn18.VisibleIndex = 2
            '    .GridColumn5.VisibleIndex = 3
            '    .GridColumn19.VisibleIndex = 4
            '    .GridColumn20.VisibleIndex = 5
            '    .GridColumn21.VisibleIndex = 6
            '    .GridColumn22.VisibleIndex = 7
            '    .GridColumn23.VisibleIndex = 8
            '    .GridColumn24.VisibleIndex = 9
            '    .GridColumn6.VisibleIndex = 10
            '    .GridColumn34.VisibleIndex = 11

            '    .GridColumn16.Width = 25
            '    .GridColumn17.Width = 54
            '    .GridColumn18.Width = 54
            '    .GridColumn5.Width = 52
            '    .GridColumn19.Width = 54
            '    .GridColumn20.Width = 52
            '    .GridColumn21.Width = 57
            '    .GridColumn22.Width = 57
            '    .GridColumn23.Width = 54
            '    .GridColumn24.Width = 52
            '    .GridColumn6.Width = 52
            '    .GridColumn34.Width = 62
            'End If
            .GridView3.BestFitColumns()
            .cbxCreditApplication.Enabled = False
            '.Availed = If(GridView3.FocusedRowHandle = 1, False, True)
            .btnWaive.Enabled = False
            .CbxPrefix_B.Text = drv("Prefix_B")
            .TxtFirstN_B.Text = drv("FirstN_B")
            .TxtMiddleN_B.Text = drv("MiddleN_B")
            .TxtLastN_B.Text = drv("LastN_B")
            .cbxSuffix_B.Text = drv("Suffix_B")
            .txtCompleteAdd.Text = drv("Address")
            .txtMobile.Text = drv("Mobile_B")
            .txtEmail.Text = drv("Email_B")
            .txtAccount.SelectedValue = drv("Product_ID")
            .cbxAvailed.Checked = cbxAvailed.Checked
            .iAccount_2.Text = DataObject(String.Format("SELECT AccountNumber FROM credit_released WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}';", cbxPayee.SelectedValue))
            .txtCollateral.Text = DataObject(String.Format("SELECT Collateral FROM credit_investigation WHERE `status` = 'ACTIVE' AND ci_status = 'APPROVED' AND CreditNumber = '{0}';", cbxPayee.SelectedValue))
            .dPrincipal.Value = drv("AmountApplied")
            .dFaceAmount.Value = drv("Face_Amount")
            .iDue.Value = If(drv("with_Interest"), Format(CDate(drv("FDD")), "dd"), 15)
            .iDue.Enabled = CBool(drv("with_Interest"))
            If GridColumn41.Visible Then
                .dMonthlyAmort.Value = GridView3.GetFocusedRowCellValue("Monthly")
            Else
                .dMonthlyAmort.Value = If(drv("Product").ToString.ToUpper.Contains("DEALER"), Math.Round(drv("Interest") / drv("Terms"), 2, MidpointRounding.AwayFromZero), If(drv("Product_Payment") = "Monthly" Or drv("Product_Payment") = "Daily" Or drv("Product_Payment") = "Weekly", drv("GMA"), drv("GMA") / 1))
            End If
            .dRPPD.Value = If(drv("Product_Payment") = "Monthly" Or drv("Product_Payment") = "Daily" Or drv("Product_Payment") = "Weekly", CDbl(GridView3.GetFocusedRowCellValue("RPPD")), CDbl(GridView3.GetFocusedRowCellValue("RPPD")) * 2)
            .dtpAvailed.Value = drv("Released")
            .dtpFDD.Value = drv("FDD")
            .dtpLastP.Value = If(TotalPayment + TotalWaivePenalty + TotalRPPD + TotalInterest + TotalUnpaidPenalty = 0, drv("Released"), LastPayment)
            .dtpMaturity.Value = DateValue(drv("LDD"))
            '.dBalance_Arrears.Value = NegativeNotAllowed(CDbl(drv("Face_Amount")) - (TotalPayment + If(CBool(drv("with_Interest")), TotalInterest, 0) + TotalRPPD + If(DateValue(LastPayment) = DateValue(GridView3.GetFocusedRowCellValue("Due Date")) And DateValue(LastPayment) = DateValue(dtpORDate.Value), CDbl(GridView3.GetFocusedRowCellValue("RPPD")), 0)))
            .dBalance_Arrears.Value = NegativeNotAllowed(CDbl(drv("Face_Amount")) - (TotalPayment + If(drv("with_Interest"), TotalInterest, 0) + TotalRPPD))
            If dBalanceLedger.Value = 0 Then
                .dBalance_Arrears.Value = 0
            End If
            Dim AdvanceLastPay As Date
            For x As Integer = 1 To GridView3.RowCount - 1
                If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
                Else
                    If .dBalance_Arrears.Value <= CDbl(GridView3.GetRowCellValue(x, "Loans Receivable")) Then
                        AdvanceLastPay = GridView3.GetRowCellValue(x, "Due Date")
                    End If
                End If
            Next
            If .dtpLastP.Value <= AdvanceLastPay Then
                .dtpLastP.Value = AdvanceLastPay
            End If
            .dUnpaidPenalties.Value = TotalUnpaidPenalty
            .dDiscount.Value = TotalWaive
            .dDiscountRPPD.Value = TotalWaiveRPPD
            .btnWaive.Visible = False
            .FirstLoad = False
            .dtpAsOf.Value = If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))

            .DT_Others = DataSource(String.Format("SELECT CONCAT((SELECT GROUP_CONCAT(CONCAT(AccountTitle(ar_details.AccountCode), ' (', FORMAT(Credit,2),')')) FROM ar_details WHERE ar_details.DocumentNumber = M.DocumentNumber AND ar_details.`status` = 'ACTIVE' AND ar_details.Credit > 0)) AS 'Others', 1 AS 'Type', Debit - D.Paid AS 'Amount' FROM accounts_receivable M INNER JOIN ar_details D ON M.DocumentNumber = D.DocumentNumber AND D.Status = 'ACTIVE' AND M.Status = 'ACTIVE' AND AR_Status NOT IN ('FULLY PAID','PENDING','CHECKED') AND PayorID = '{0}' AND Debit - D.Paid > 0 AND M.PostingDate <= '{1}';", .CreditNumber, FormatDatePicker(.dtpAsOf)))
            If .DT_Others.Rows.Count > 0 Then
                Dim OtherX As String = ""
                Dim TotalAdd As Double
                Dim TotalDeduct As Double
                For x As Integer = 0 To .DT_Others.Rows.Count - 1
                    If .DT_Others(x)("Type") = 1 Then
                        TotalAdd += .DT_Others(x)("Amount")
                    Else
                        TotalDeduct += .DT_Others(x)("Amount")
                    End If
                    OtherX &= ", " & .DT_Others(x)("Others")
                Next
                .cbxOthers.Text = OtherX.Substring(2)
                If TotalAdd > TotalDeduct Then
                    .cbxAdd.Checked = True
                    .dOthers.Value = TotalAdd - TotalDeduct
                ElseIf TotalDeduct > TotalAdd Then
                    .cbxDeduct.Checked = True
                    .dOthers.Value = TotalDeduct - TotalAdd
                Else
                    .cbxAdd.Checked = True
                    .dOthers.Value = 0
                End If
            Else
                .cbxOthers.Text = ""
                .dOthers.Value = 0
            End If
        End With
    End Sub

    Private Sub GroupControl1_Click(sender As Object, e As EventArgs) Handles GroupControl1.Click
        If GroupControl1.Text = "" Then
            If GridColumn41.Visible Then
                GroupControl1.Location = New Point(377 - 55, 3)
                GroupControl1.Size = New Point(775 + 55, PanelEx4.Size.Height - 5)
            Else
                GroupControl1.Location = New Point(513 - 55, 3)
                GroupControl1.Size = New Point(639 + 55, PanelEx4.Size.Height - 5)
            End If
            GridControl3.Visible = True
            GroupControl1.Text = "Amortization Schedule"
        Else
            GroupControl1.Location = New Point(1125, 3)
            GroupControl1.Size = New Point(30, PanelEx4.Size.Height - 5)
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

    Private Sub ComputePenaltyModify()
        Dim SOA As New FrmSOA
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        With SOA
            .From_Payment = True
            .From_OR = True
            .FirstLoad = True
            .WindowState = FormWindowState.Minimized
            .Show()
            LoadAmortization(.GridControl3)
            .cbxCreditApplication.Enabled = False
            '.Availed = If(.GridView3.FocusedRowHandle = 1, False, True)
            .CbxPrefix_B.Text = drv("Prefix_B")
            .TxtFirstN_B.Text = drv("FirstN_B")
            .TxtMiddleN_B.Text = drv("MiddleN_B")
            .TxtLastN_B.Text = drv("LastN_B")
            .cbxSuffix_B.Text = drv("Suffix_B")
            .txtCompleteAdd.Text = drv("Address")
            .txtMobile.Text = drv("Mobile_B")
            .txtEmail.Text = drv("Email_B")
            .txtAccount.SelectedValue = drv("Product_ID")
            .cbxAvailed.Checked = cbxAvailed.Checked
            .iAccount_2.Text = DataObject(String.Format("SELECT AccountNumber FROM credit_released WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}';", cbxPayee.SelectedValue))
            .txtCollateral.Text = DataObject(String.Format("SELECT Collateral FROM credit_investigation WHERE `status` = 'ACTIVE' AND ci_status = 'APPROVED' AND CreditNumber = '{0}';", cbxPayee.SelectedValue))
            .dPrincipal.Value = drv("AmountApplied")
            .dFaceAmount.Value = drv("Face_Amount")
            .iDue.Value = If(drv("with_Interest"), Format(CDate(drv("FDD")), "dd"), 15)
            .iDue.Enabled = CBool(drv("with_Interest"))
            If GridColumn41.Visible Then
                .dMonthlyAmort.Value = .GridView3.GetFocusedRowCellValue("Monthly")
            Else
                .dMonthlyAmort.Value = If(drv("Product").ToString.ToUpper.Contains("DEALER"), Math.Round(drv("Interest") / drv("Terms"), 2, MidpointRounding.AwayFromZero), If(drv("Product_Payment") = "Monthly" Or drv("Product_Payment") = "Daily" Or drv("Product_Payment") = "Weekly", drv("GMA"), drv("GMA") / 1))
            End If
            .dRPPD.Value = CDbl(.GridView3.GetFocusedRowCellValue("RPPD"))
            .dtpAvailed.Value = drv("Released")
            .dtpFDD.Value = drv("FDD")
            .dtpMaturity.Value = DateValue(drv("LDD"))
            .FirstLoad = False
            .dBalance_Arrears.Value = dBalanceLedger.Value
            .dtpLastP.Value = LastPaymentBefore
            .dUnpaidPenalties.Value = TotalUnpaidPenalty
            .dDiscount.Value = TotalWaive
            .dDiscountRPPD.Value = TotalWaiveRPPD
            .btnWaive.Visible = False
            .dtpAsOf.Value = If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))
            dPenalty_P = Math.Ceiling((.dTotalPenalties.Value + .dUnpaidPenalties.Value) - .dDiscount.Value)
            .Dispose()
        End With
    End Sub

    Private Sub DPaidAmount_ValueChanged(sender As Object, e As EventArgs) Handles dPaidAmount.ValueChanged
        FillAccounts()
    End Sub

    Private Sub CbxBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBank.SelectedIndexChanged
        If FirstLoad Or GridView3.RowCount = 0 Or cbxPayee.SelectedIndex = -1 Then
            Exit Sub
        End If

        If SalaryLoan Then
            If SalaryLoan_Loading Then
            Else
                FillAccountsV2()
            End If
        Else
            FillAccounts()
        End If

        If cbxBank.SelectedValue <> BankID And BankID <> 0 Then
            RepositoryItemLookUpEdit3.DataSource = DataSource("SELECT 'CIB' AS 'Paid For' UNION SELECT 'Billing' UNION SELECT 'Penalty' UNION SELECT 'DTS Penalty' UNION SELECT 'RPPD' UNION SELECT 'UDI' UNION SELECT 'Principal' UNION SELECT 'Other Income' UNION SELECT ''")
        Else
            RepositoryItemLookUpEdit3.DataSource = DataSource("SELECT 'CIB' AS 'Paid For' UNION SELECT 'Billing' UNION SELECT 'Penalty' UNION SELECT 'RPPD' UNION SELECT 'UDI' UNION SELECT 'Principal' UNION SELECT 'Other Income' UNION SELECT ''")
        End If
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = cbxPayee.SelectedValue
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("Payee").ToString.Contains("[") Then
            Dim Ledger As New FrmAccountLedger
            With Ledger
                .CreditNumber = GridView1.GetFocusedRowCellValue("Payee_ID")
                .ShowDialog()
                .Dispose()
            End With
        Else
            MsgBox("Batch Payment does not have a shortcut for Account Ledger, Please go to Subsidiary Ledger for the specific account.", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnWaive_Click(sender As Object, e As EventArgs) Handles btnWaive.Click
        Dim Penalty As Double
        Dim RPPD As Double
        If dPaidAmount.Value <> dPayable.Value Then
            dPaidAmount.Value = dPayable.Value
        End If
        For x As Integer = 0 To GridView2.RowCount - 1
            If GridView2.GetRowCellValue(x, "PaidFor") = "Penalty" Then
                Penalty += GridView2.GetRowCellValue(x, "Credit")
            ElseIf GridView2.GetRowCellValue(x, "PaidFor") = "RPPD" Then
                RPPD += GridView2.GetRowCellValue(x, "Credit")
            End If
        Next
        If Penalty = 0 And RPPD = 0 Then
            MsgBox("No Penalty or RPPD Payables, nothing to waive.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If MsgBox("Are you sure about the Posting Date? System will lock the Posting Date after a successful waive payment.", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Dim Waive As New FrmWaivePayables
            With Waive
                .dPenalty_P.Value = Penalty
                .dRPPD_P.Value = RPPD
                .BorrowerName = cbxPayee.Text
                .CreditNumber = cbxPayee.SelectedValue
                .ORNumber = txtDocumentNumber.Text
                .ORDate = If(cbxRemittance.Checked, dtpRemittance.Value, If(cbxOnline.Checked, dtpDeposit.Value, If(cbxAR.Checked, dtpAR.Value, dtpORDate.Value)))
                If .ShowDialog() = DialogResult.OK Then
                    If cbxRemittance.Checked Then
                        dtpRemittance.Enabled = False
                    ElseIf cbxOnline.Checked Then
                        dtpDeposit.Enabled = False
                    Else
                        dtpORDate.Enabled = False
                    End If

                    CbxPayee_SelectedIndexChanged(sender, e)
                    dPaidAmount.Value = dPayable.Value
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnValidate_Click(sender As Object, e As EventArgs) Handles btnValidate.Click
        If ComparePosition(SpecialAccess(1), True) Or CompareDepartment(SpecialAccessDepartment(1), True) Then
            MsgBox(mBox_SpecialAccess, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim Schedule As New FrmMigratedApplication
        With Schedule
            .btnAddC.Visible = True
            .btnRemoveC.Visible = True
            .btnManual.Visible = True
            .From_OfficialReceipt = True
            .dtpAvailedV2.Value = drv("Released")
            .ProductID = drv("Product_ID")
            .v_dAmountApplied = drv("AmountApplied")
            .v_iTerms_C = drv("Terms")
            .v_dInterest_T = drv("Interest_Rate")
            .v_dRPPDRate_T = drv("RPPD_Rate")
            .v_dtpAvailed = drv("Released")
            .v_dtpFDD = drv("FDD")
            .v_dMR_C = drv("Rebate")

            .v_dPA_C = drv("AmountApplied")
            .v_dUDI_C = drv("Interest")
            .v_dRPPD_C = drv("RPPD")
            .txtCreditNumber.Text = cbxPayee.SelectedValue
            .lblTitle.Text = "AMORTIZATION SCHEDULE"
            .vSave = vSave
            If .ShowDialog() = DialogResult.OK Then
                Dim Ind As Integer = cbxPayee.SelectedIndex
                FirstLoad = True
                '*** TAGGING PARA MABALIK IG REFRESH ***
                cbxCash.Tag = cbxCash.Checked
                cbxRemittance.Tag = cbxRemittance.Checked
                txtRemittance.Tag = txtRemittance.Text
                dtpRemittance.Tag = dtpRemittance.Value
                cbxCheck.Tag = cbxCheck.Checked
                cbxCheckNumber.Tag = cbxCheckNumber.Text
                dtpCheck.Tag = dtpCheck.Value
                cbxAR.Tag = cbxAR.Checked
                txtARNumber.Tag = txtARNumber.Text
                dtpAR.Tag = dtpAR.Value
                cbxOnline.Tag = cbxOnline.Checked
                txtDeposit.Tag = txtDeposit.Text
                dtpDeposit.Tag = dtpDeposit.Value
                '*** TAGGING PARA MABALIK IG REFRESH ***
                LoadPayee()
                FirstLoad = False
                cbxPayee.SelectedIndex = Ind
                '*** TAGGING PARA MABALIK IG REFRESH ***
                cbxCash.Checked = cbxCash.Tag
                cbxRemittance.Checked = cbxRemittance.Tag
                txtRemittance.Text = txtRemittance.Tag
                dtpRemittance.Value = dtpRemittance.Tag
                cbxCheck.Checked = cbxCheck.Tag
                cbxCheckNumber.Text = cbxCheckNumber.Tag
                dtpCheck.Value = dtpCheck.Tag
                cbxAR.Checked = cbxAR.Tag
                txtARNumber.Text = txtARNumber.Tag
                dtpAR.Value = dtpAR.Tag
                cbxOnline.Checked = cbxOnline.Tag
                txtDeposit.Text = txtDeposit.Tag
                dtpDeposit.Value = dtpDeposit.Tag
                '*** TAGGING PARA MABALIK IG REFRESH ***
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxCheckNumber_Leave(sender As Object, e As EventArgs) Handles cbxCheckNumber.Leave
        cbxCheckNumber.Text = ReplaceText(cbxCheckNumber.Text)
    End Sub

    Private Sub TxtARNumber_Leave(sender As Object, e As EventArgs) Handles txtARNumber.Leave
        txtARNumber.Text = ReplaceText(txtARNumber.Text)
    End Sub

    Private Sub TxtDeposit_Leave(sender As Object, e As EventArgs) Handles txtDeposit.Leave
        txtDeposit.Text = ReplaceText(txtDeposit.Text)
    End Sub

    Private Sub TxtRemittance_Leave(sender As Object, e As EventArgs) Handles txtRemittance.Leave
        txtRemittance.Text = ReplaceText(txtRemittance.Text)
    End Sub

    Private Sub TxtReferenceNumber_Leave(sender As Object, e As EventArgs) Handles txtReferenceNumber.Leave
        txtReferenceNumber.Text = ReplaceText(txtReferenceNumber.Text)
    End Sub

    Private Sub BtnEarly_Click(sender As Object, e As EventArgs) Handles btnEarly.Click
        If GridView3.FocusedRowHandle + 1 = GridView3.RowCount - 1 Then
            MsgBox("Account is already passed due or at the last month of schedule, early settlement is not allowed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim Early As New FrmEarlySettlement
        Dim CurrentTerms As Integer = 0
        With Early
            .From_Payment = True
            .btnEarly.Enabled = True
            .AsOf = dtpORDate.Value
            .LR = dBalanceLedger.Value
            .Updated = dBalanceLedger.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable"))
            .Terms = Terms
            .UDI = UDI
            .GridControl3.DataSource = GridControl3.DataSource
            CurrentTerms = GridView3.FocusedRowHandle
            If DateDiff(DateInterval.Day, If(cbxRemittance.Checked, dtpRemittance.Value, If(cbxOnline.Checked, dtpDeposit.Value, If(cbxAR.Checked, dtpAR.Value, dtpORDate.Value))), CDate(GridView3.GetFocusedRowCellValue("Due Date"))) >= 15 Then
            Else
                CurrentTerms += 1
            End If
            If DateDiff(DateInterval.Day, If(cbxRemittance.Checked, dtpRemittance.Value, If(cbxOnline.Checked, dtpDeposit.Value, If(cbxAR.Checked, dtpAR.Value, dtpORDate.Value))), CDate(GridView3.GetRowCellValue(GridView3.FocusedRowHandle + 1, "Due Date"))) >= 15 Then
            Else
                CurrentTerms += 1
            End If
            Dim Temp_Terms As Integer
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
            .iTerm.Value = CurrentTerms
            If .dLR.Value = 0 Then
                .dLR.Value = dBalanceLedger.Value
            End If
            If From_DeductBalance Then
                .From_DeductBalance = From_DeductBalance
                .SendToBack()
                .WindowState = FormWindowState.Minimized
            Else
                .iTerm.MaxValue = Terms - 1
                .iTerm.MinValue = CurrentTerms
            End If
            If .ShowDialog = DialogResult.OK Then
                Dim PayablePrincipal As Double = GridView3.GetRowCellValue(0, "Outstanding Principal")
                Dim PayableInterest As Double = GridView3.GetRowCellValue(0, "Unearn Income")
                Dim PayableRPPD As Double = GridView3.GetRowCellValue(0, "Total_RPPD")
                dRPPD_P = ((PayableRPPD - TotalRPPD) - .dRPPD.Value) + If(TotalRPPD_Payable > TotalRPPD And If(cbxRemittance.Checked, dtpRemittance.Value.Day, If(cbxOnline.Checked, dtpDeposit.Value.Day, If(cbxAR.Checked, dtpAR.Value.Day, dtpORDate.Value.Day))) > CDate(GridView3.GetFocusedRowCellValue("Due Date")).Day, CDbl(GridView3.GetFocusedRowCellValue("RPPD")), 0)
                dUDI_P = (PayableInterest - TotalInterest) - .dUDI.Value
                dPrincipal_P = PayablePrincipal - TotalPayment
                UDI_Amount_Early = .dUDI.Value
                UDI_Percent_Early = .UDI_Percent
                RPPD_Amount_Early = .dRPPD.Value

                dRPPD = dRPPD_P
                EarlySettlement = True
                If cbxRemittance.Checked Then
                    dtpRemittance.Enabled = False
                ElseIf cbxOnline.Checked Then
                    dtpDeposit.Enabled = False
                Else
                    dtpORDate.Enabled = False
                End If
                btnDeductBalance.Enabled = True

                FillAccounts()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDeductBalance_Click(sender As Object, e As EventArgs) Handles btnDeductBalance.Click
        If MsgBoxYes("Are you sure about this computation for deduct balance?") = MsgBoxResult.Yes Then
            Dim Unposted As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DISTINCT CVNumber),'') AS 'Reference' FROM accounting_entry WHERE ReferenceN = '{0}' AND `status` = 'ACTIVE' AND PostStatus = 'PENDING'", CreditNumber))
            If Unposted <> "" Then
                If MsgBox(String.Format("This account have unposted transactions with reference number(s) {0}. Please post the transaction first before creating the deduct balance because it might affect the computation. Would you like to proceed?", Unposted), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            Dim DeductCredit As String = DataObject(String.Format("SELECT CreditNumber_F FROM credit_deductbalance WHERE CreditNumber = '{0}' AND CreditNumber_F != '' AND `status` = 'ACTIVE' AND deduct_status = 'PENDING';", CreditNumber))
            If DeductCredit <> "" Then
                MsgBox(String.Format("This application already have an application with Credit Number {0}, please cancel the application if you need to create a new deduct balance computation for this account.", DeductCredit), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim SQL As String = String.Format("UPDATE credit_deductbalance SET `status` = 'CANCELLED' WHERE `status` = 'ACTIVE' AND deduct_status = 'PENDING' AND CreditNumber = '{0}' AND AccountNumber = '{1}';", CreditNumber, AccountNumber)
            SQL &= "INSERT INTO credit_deductbalance SET"
            SQL &= "  CreditNumber_F = '',"
            SQL &= String.Format("  AccountNumber = '{0}', ", AccountNumber)
            SQL &= String.Format("  CreditNumber = '{0}', ", CreditNumber)
            SQL &= String.Format("  LR = '{0}', ", dBalanceLedger.Value)
            SQL &= String.Format("  UDI_Discount = '{0}', ", UDI_Amount_Early)
            SQL &= String.Format("  UDI_DiscountP = '{0}', ", UDI_Percent_Early)
            SQL &= String.Format("  AvailedRPPD = '{0}', ", RPPD_Amount_Early)
            SQL &= String.Format("  AR = '{0}', ", dBilling_P)
            SQL &= String.Format("  Penalty = '{0}', ", dPenalty_P)
            SQL &= String.Format("  Amount = '{0}', ", 0)
            SQL &= String.Format("  BranchID = '{0}', ", Branch_ID)
            SQL &= String.Format("  AsOf = '{0}';", Format(If(cbxRemittance.Checked, dtpRemittance.Value, If(cbxOnline.Checked, dtpDeposit.Value, If(cbxAR.Checked, dtpAR.Value, dtpORDate.Value))), "yyyy-MM-dd"))
            DataObject(SQL)
            MsgBox("Successfully Computed!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub CbxBusinessCenter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBusinessCenter.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "BusinessCode", cbxBusinessCenter.SelectedValue)
    End Sub

    Private Sub BtnBatchPayment_Click(sender As Object, e As EventArgs) Handles btnBatchPayment.Click
        Dim Salary As New FrmSalaryLoanPayment
        With Salary
            If .ShowDialog = DialogResult.OK Then
                cbxPayee.SelectedIndex = -1
                cbxPayee.Enabled = False
                cbxPayee.Text = .cbxPayor.Text

                dPaidAmount.Enabled = False
                dPaidAmount.Value = .dAmount.Value

                SalaryLoan = True
                ForcedAvailed = .cbxForceAvailed.Checked

                DT_Account.Rows.Clear()
                DT_SalaryLoan = .GridControl1.DataSource
                SalaryPaid = .dAmount.Value
                SalaryPayable = .dTotal.Value

                FillAccountsV2()

                Dim TotalInterest As Double
                Dim TotalPrincipal As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    If GridView2.GetRowCellValue(x, "PaidFor") = "UDI" Then
                        TotalInterest += CDbl(DT_Account(x)("Credit"))
                    End If
                    If GridView2.GetRowCellValue(x, "PaidFor") = "Principal" Then
                        TotalPrincipal += CDbl(DT_Account(x)("Credit"))
                    End If
                Next
                dTotalInterest.Value = TotalInterest
                dTotalPrincipal.Value = TotalPrincipal

                btnRemove_Account.Enabled = False
                cbxClosed.Enabled = False
            End If
            .Dispose()
        End With
    End Sub

    Private Sub FillAccountsV2()
        SalaryLoan_Loading = True
        lblTotalInterest.Visible = True
        lblTotalPrincipal.Visible = True
        dTotalInterest.Visible = True
        dTotalPrincipal.Visible = True
        For z As Integer = 0 To DT_SalaryLoan.Rows.Count - 1
            If CDbl(DT_SalaryLoan(z)("Amount")) > 0 And (dPaidAmount.Enabled Or btnSave.Text = "&Save") Then
                '**** SELECTED INDEX CHANGE
                Terms = DT_SalaryLoan(z)("Terms")
                UDI = DT_SalaryLoan(z)("Interest")
                Principal = DT_SalaryLoan(z)("AmountApplied")
                RPPD = DT_SalaryLoan(z)("RPPD")
                MortgageID = DT_SalaryLoan(z)("Mortgage_ID")
                AccountNumber = DT_SalaryLoan(z)("Account Number")
                BankID = DT_SalaryLoan(z)("BankID")

                Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', IF(`No` = '','',FORMAT(InterestIncome,2)) AS 'Interest Income', IF(`No` = '','',FORMAT(RPPD,2)) AS 'RPPD', IF(`No` = '','',FORMAT(PrincipalAllocation,2)) AS 'Principal Allocation', FORMAT(OutstandingPrincipal,2) AS 'Outstanding Principal', FORMAT(Total_RPPD,2) AS 'Total_RPPD', FORMAT(UnearnIncome,2) AS 'Unearn Income', FORMAT(LoansReceivable,2) AS 'Loans Receivable', IF(`No` = '','',FORMAT(Penalty,2)) AS 'Penalty', FORMAT(PenaltyBalance,2) AS 'Penalty Balance' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", DT_SalaryLoan(z)("CreditNumber")))
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
                    GridColumn16.VisibleIndex = 0
                    GridColumn17.VisibleIndex = 1
                    GridColumn18.VisibleIndex = 2
                    GridColumn41.VisibleIndex = 3
                    GridColumn19.VisibleIndex = 4
                    GridColumn20.VisibleIndex = 5
                    GridColumn21.VisibleIndex = 6
                    GridColumn22.VisibleIndex = 7
                    GridColumn23.VisibleIndex = 8
                    GridColumn24.VisibleIndex = 9
                    GridColumn42.VisibleIndex = 10
                    GridColumn34.VisibleIndex = 11
                Else
                    GridColumn41.Visible = False
                    GridColumn42.Visible = False

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
                End If
                Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, 2), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), "", "", "", "", FormatNumber(T_Penalty, 2), "")
                GridControl3.DataSource = Temp_DT

                If BankID > 0 Then
                    cbxBank.SelectedValue = BankID
                Else
                    cbxBank.SelectedValue = DT_SalaryLoan(z)("BankID")
                End If
                FaceAmount = DT_SalaryLoan(z)("Face_Amount")

                PaymentDT = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%' OR EntryType = 'DEBIT',0 - Amount,Amount) END),0) AS 'Total RPPD', IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Penalty Payment', IFNULL((SELECT PenaltyPayable FROM accounting_entry A WHERE A.PaidFor IN ('Penalty','Penalty-W') AND A.`status` = 'ACTIVE' AND A.ReferenceN = '{0}' AND A.JVNumber = '' ORDER BY ID DESC LIMIT 1),0) AS 'Total Unpaid Penalty', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('RPPD-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived RPPD', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('Penalty-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived Penalty', IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Principal', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Interest', IFNULL((SELECT MAX(IF(ARDate = '',IF(RemittanceDate = '',ORDate,RemittanceDate),ARDate)) FROM official_receipt WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND JVNumber = ''),IFNULL(MAX((CASE WHEN JVNum = '' AND JVNumber = '' THEN ORDate END)),ReleasedDate('{0}'))) AS 'Last Payment' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", DT_SalaryLoan(z)("CreditNumber"), Format(dtpPostingDate.Value, "yyyy-MM-dd")))
                If PaymentDT.Rows.Count > 0 Then
                    TotalRPPD = PaymentDT(0)("Total RPPD")
                    TotalInterest = PaymentDT(0)("Total Interest")
                    TotalPayment = PaymentDT(0)("Total Principal")
                    TotalWaivePenalty = PaymentDT(0)("Total Penalty Payment")
                    TotalWaive = PaymentDT(0)("Total Waived Penalty")
                    TotalWaiveRPPD = PaymentDT(0)("Total Waived RPPD")
                    TotalUnpaidPenalty = PaymentDT(0)("Total Unpaid Penalty")
                    LastPayment = PaymentDT(0)("Last Payment")
                    If TotalWaive + TotalWaiveRPPD > 0 Then
                        btnWaiveRemove.Enabled = True
                        'cbxBank.Size = New Point(313, 25)
                    Else
                        btnWaiveRemove.Enabled = False
                        'cbxBank.Size = New Point(381, 25)
                    End If
                End If
                If dBalanceLedger.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")) Then
                    If CompanyMode = 0 Then
                    Else
                        RemoveRPPDFromBalanceLedger = True
                    End If
                End If
                dBalanceLedger.Value = GetBalanceLedger(DT_SalaryLoan(z)("CreditNumber"))

                dBilling_P = 0
                DT_Billing = DataSource(String.Format("SELECT D.ID, M.DocumentNumber, AccountCode, DepartmentCode, (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = D.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit - D.Paid AS 'Debit', Credit AS 'Credit', 'Billing' AS 'PaidFor', CONCAT(Remarks, ' ', (SELECT GROUP_CONCAT(CONCAT(AccountTitle(ar_details.AccountCode), ' (', FORMAT(Credit,2),')')) FROM ar_details WHERE ar_details.DocumentNumber = M.DocumentNumber AND ar_details.`status` = 'ACTIVE' AND ar_details.Credit > 0)) AS 'Remarks', Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', D.MotherCode FROM accounts_receivable M INNER JOIN ar_details D ON M.DocumentNumber = D.DocumentNumber AND D.Status = 'ACTIVE' AND M.Status = 'ACTIVE' AND NotAR = 0 AND JVNumber = '' AND AR_Status NOT IN ('FULLY PAID','PENDING','CHECKED') AND PayorID = '{0}' AND Debit - D.Paid > 0 AND M.JVNumberV2 = '' AND PostingDate <= '{1}';;", DT_SalaryLoan(z)("CreditNumber"), FormatDatePicker(If(cbxRemittance.Checked, dtpRemittance, If(cbxOnline.Checked, dtpDeposit, If(cbxAR.Checked, dtpAR, dtpORDate))))))
                For x As Integer = 0 To DT_Billing.Rows.Count - 1
                    dBilling_P += CDbl(DT_Billing(x)("Debit"))
                Next

                '**** SELECTED INDEX CHANGE

                '**** COMPUTE

                TotalRPPD_Payable = 0
                dRPPD_P = 0
                dUDI_P = 0
                dPrincipal_P = 0
                Payable_Interest = 0
                EarlySettlement = False
                RPPD_Application = 0
                For x As Integer = 1 To GridView3.RowCount - 1
                    If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
                    Else
                        RPPD_Application += GridView3.GetRowCellValue(x, "RPPD")
                        If If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                            TotalRPPD_Payable += GridView3.GetRowCellValue(x, "RPPD")
                        End If
                    End If
                Next
                Dim AsOf As Date = If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))
                For x As Integer = 1 To GridView3.RowCount - 1
                    If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
                    Else
                        If If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                            GridView3.FocusedRowHandle = x
                            AsOf = If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))
                            dUDI_P += GridView3.GetRowCellValue(x, "Interest Income")
                            dPrincipal_P += GridView3.GetRowCellValue(x, "Principal Allocation")
                        ElseIf x = GridView3.RowCount - 2 And If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) < CDate(GridView3.GetRowCellValue(1, "Due Date")) Then
                            GridView3.FocusedRowHandle = 1
                            AsOf = If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))
                            dUDI_P += GridView3.GetRowCellValue(1, "Interest Income")
                            dPrincipal_P += GridView3.GetRowCellValue(1, "Principal Allocation")
                        ElseIf x <= GridView3.FocusedRowHandle And If(cbxRemittance.Checked, Format(dtpRemittance.Value, "yyyy-MM"), If(cbxOnline.Checked, Format(dtpDeposit.Value, "yyyy-MM"), If(cbxAR.Checked, Format(dtpAR.Value, "yyyy-MM"), Format(dtpPostingDate.Value, "yyyy-MM")))) = Format(CDate(GridView3.GetRowCellValue(x, "Due Date")), "yyyy-MM") Then
                            dUDI_P += GridView3.GetRowCellValue(1, "Interest Income")
                            dPrincipal_P += GridView3.GetRowCellValue(1, "Principal Allocation")
                        End If
                    End If
                    If x > GridView3.FocusedRowHandle Then
                        Exit For
                    End If
                Next
                '********** GI COMMENT KAY DLI MAGBAYAD OG PENALTY OG RPPD AND SALARY LOAN******
                'If btnCalculator.Enabled Then
                '    dPenalty_P = ComputePenalty(DT_SalaryLoan(z)("AmountApplied"), DT_SalaryLoan(z)("Face_Amount"), DT_SalaryLoan(z)("Released"), If(DT_SalaryLoan(z)("Product").ToString.ToUpper.Contains("DEALER"), Math.Round(DT_SalaryLoan(z)("Interest") / DT_SalaryLoan(z)("Terms"), 2, MidpointRounding.AwayFromZero), If(DT_SalaryLoan(z)("Product_Payment").ToString.ToUpper = "MONTHLY", DT_SalaryLoan(z)("GMA"), CDbl(DT_SalaryLoan(z)("GMA")) / 2)), TotalPayment, LastPayment, DT_SalaryLoan(z)("Terms"), AsOf, TotalInterest, TotalRPPD, TotalUnpaidPenalty, DT_SalaryLoan(z)("Product_ID"), DefaultPenalty, If(GridView3.FocusedRowHandle = 1, False, True), DT_SalaryLoan(z)("with_Interest"), DT_SalaryLoan(z)("FDD"), DT_SalaryLoan(z)("Product_Payment"), DT_SalaryLoan(z)("Product"), TotalWaivePenalty, DT_SalaryLoan(z)("Interest"), CDbl(GridView3.GetFocusedRowCellValue("RPPD")), TotalWaive, TotalWaiveRPPD, GridControl3, cbxAvailed.Checked)
                '    UnroundedPenalty = dPenalty_P
                '    If 1 Then 'cbxUp.Checked = True
                '        dPenalty_P = Math.Ceiling(dPenalty_P)
                '    End If
                'End If
                '********** GI COMMENT KAY DLI MAGBAYAD OG PENALTY OG RPPD AND SALARY LOAN******

                If (If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) >= CDate(GridView3.GetFocusedRowCellValue("Due Date")).AddDays(If(FaceAmount - (TotalPayment + TotalRPPD + TotalInterest) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle - 1, "Loans Receivable")), If(GridView3.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 1, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))), 0))) Or (TotalRPPD = 0 And dRPPD_P > 0) Then
                    'TotalRPPD_Payable = 0
                Else
                    TotalRPPD_Payable = NegativeNotAllowed(TotalRPPD_Payable - GridView3.GetRowCellValue(1, "RPPD"))
                End If
                '********** GI COMMENT KAY DLI MAGBAYAD OG PENALTY OG RPPD AND SALARY LOAN******
                'If CompanyMode = 0 Then
                '    dRPPD_P = 0
                'Else
                '    dRPPD_P = NegativeNotAllowed(TotalRPPD_Payable - TotalRPPD)
                'End If
                '********** GI COMMENT KAY DLI MAGBAYAD OG PENALTY OG RPPD AND SALARY LOAN******
                dUDI_P = NegativeNotAllowed(dUDI_P - TotalInterest)
                If dUDI_P > 0 Then
                    Payable_Interest = dUDI_P
                    If dBalanceLedger.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")) And TotalPayment > dPrincipal_P Then
                        dUDI_P -= Math.Abs(dPrincipal_P - TotalPayment)
                    ElseIf dBalanceLedger.Value < CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle - 1, "Loans Receivable")) And GridView3.FocusedRowHandle > 1 And TotalPayment > dPrincipal_P Then
                        dUDI_P -= Math.Abs(dPrincipal_P - TotalPayment)
                    End If
                End If
                dPrincipal_P = NegativeNotAllowed(dPrincipal_P - TotalPayment)

                '**** COMPUTE

                '**** FILL ACCOUNT
                dBilling = If(CDbl(DT_SalaryLoan(z)("Amount")) >= dBilling_P, dBilling_P, CDbl(DT_SalaryLoan(z)("Amount")))
                dPenalty = If((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) >= dPenalty_P, dPenalty_P, (CDbl(DT_SalaryLoan(z)("Amount")) - dBilling))
                If (If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetFocusedRowCellValue("Due Date")).AddDays(If(FaceAmount - (TotalPayment + TotalRPPD + TotalInterest) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle - 1, "Loans Receivable")), If(GridView3.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 1, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))), 0))) Or dRPPD_P > 0 Then
                    dRPPD = If(((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) >= dRPPD_P, dRPPD_P, ((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty))
                Else
                    dRPPD = 0
                End If

                'PAYMENT HEIRARCHY ***************************************************************************************************************
                dUDI = 0
                If CDbl(DT_SalaryLoan(z)("Amount")) > dPayable.Value And (dPayable.Value = 0 Or (TotalPayment + TotalInterest) + (CDbl(DT_SalaryLoan(z)("Amount")) - (dBilling + dPenalty + dRPPD)) >= (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) + CDbl(GridView3.GetRowCellValue(0, "Unearn Income"))) - (CDbl(GridView3.GetFocusedRowCellValue("Outstanding Principal")) + CDbl(GridView3.GetFocusedRowCellValue("Unearn Income")))) Then
                    Dim ForDistribute As Double = (((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD)
                    If dUDI_P > 0 Then
                        dUDI = If((((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD_P) >= dUDI_P, dUDI_P, (((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD))
                        ForDistribute -= dUDI_P
                    End If
                    If dPrincipal_P > 0 Then
                        dPrincipal = If(((((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD_P) - dUDI_P) >= dPrincipal_P, ((((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD_P) - dUDI_P), ((((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD) - dUDI))
                        ForDistribute -= dPrincipal_P
                    End If
                    Dim NMA As Double = CDbl(GridView3.GetRowCellValue(1, "Interest Income")) + CDbl(GridView3.GetRowCellValue(1, "Principal Allocation"))
                    Dim Covered As Double = If(Math.Ceiling(ForDistribute / NMA) > GridView3.RowCount - 2, GridView3.RowCount - 2, Math.Ceiling(ForDistribute / NMA))
                    For x As Integer = 0 To Covered - 1
                        If ForDistribute > 0 Then
                            If ForDistribute >= CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Interest Income")) Then
                                dUDI += CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Interest Income"))
                                ForDistribute -= CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Interest Income"))
                            Else
                                dUDI += ForDistribute
                                ForDistribute = 0
                            End If

                            If ForDistribute >= CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Principal Allocation")) Then
                                ForDistribute -= CDbl(GridView3.GetRowCellValue(If(GridView3.FocusedRowHandle + Covered >= GridView3.RowCount - 2, x + 1, GridView3.FocusedRowHandle + x), "Principal Allocation"))
                            Else
                                ForDistribute = 0
                            End If
                        End If
                    Next
                    If dUDI > NegativeNotAllowed(CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - TotalInterest) Then
                        dPrincipal += (dUDI - NegativeNotAllowed(CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - TotalInterest))
                        dUDI = NegativeNotAllowed(CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - TotalInterest)
                    End If
                    dPrincipal = (((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD) - dUDI
                Else
                    Dim UnpaidPrincipal As Double
                    If dPrincipal_P > CDbl(GridView3.GetFocusedRowCellValue("Principal Allocation")) Then
                        If TotalPayment > 0 Then
                            UnpaidPrincipal = dPrincipal_P - CDbl(GridView3.GetFocusedRowCellValue("Principal Allocation"))
                        Else
                            UnpaidPrincipal = dPrincipal_P
                        End If
                    End If
                    dUDI = If((((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD_P) >= dUDI_P, dUDI_P, (((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD))
                    dPrincipal = If(((((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD_P) - dUDI_P) >= dPrincipal_P, ((((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD_P) - dUDI_P), ((((CDbl(DT_SalaryLoan(z)("Amount")) - dBilling) - dPenalty) - dRPPD) - dUDI))
                    If UnpaidPrincipal > 0 And dUDI > 0 And TotalPayment > 0 And TotalInterest > 0 Then
                        If UnpaidPrincipal > dUDI + dPrincipal And dUDI_P = 0 Then
                            dPrincipal = dUDI
                            dUDI = 0
                        ElseIf UnpaidPrincipal > 0 And dPaidAmount.Value >= (dUDI + dBilling + dPenalty + dRPPD) Then
                            dUDI = dUDI
                            dPrincipal = (dUDI + dBilling + dPenalty + dRPPD)
                        ElseIf dPenalty > 0 Then
                        Else
                            dUDI = (dUDI + dPrincipal) - UnpaidPrincipal
                            dPrincipal = UnpaidPrincipal
                        End If
                    End If
                End If

                '**** RPPD COMPUTE
                Availed = 0
                Dim TotalPaidNMA As Double = TotalPayment + TotalInterest + dPrincipal + dUDI
                Dim NonthlyNMA As Double = CDbl(GridView3.GetRowCellValue(1, "Interest Income")) + CDbl(GridView3.GetRowCellValue(1, "Principal Allocation"))
                Dim NumberOfRPPD As Integer = Math.Floor(TotalPaidNMA / NonthlyNMA)
                For x As Integer = 0 To NumberOfRPPD - 1
                    Availed += CDbl(GridView3.GetRowCellValue(1, "RPPD"))
                Next
                If (If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) >= CDate(GridView3.GetFocusedRowCellValue("Due Date")).AddDays(If(GridView3.FocusedRowHandle = 1 And (dPrincipal_P + dUDI_P + dRPPD_P) > 0, 0, BankingDays(If(cbxAvailed.Checked, AvailedRPPD + 1, 0), CDate(GridView3.GetFocusedRowCellValue("Due Date")))))) And dBalanceLedger.Value <= CDbl(GridView3.GetFocusedRowCellValue("Loans Receivable")) Then
                    Availed -= CDbl(GridView3.GetRowCellValue(1, "RPPD"))
                End If
                Availed = NegativeNotAllowed(Availed - TotalRPPD)
                '**** RPPD COMPUTE

                'PAYMENT HEIRARCHY ***************************************************************************************************************

                'Cash In Bank **********************************************************************************************************************
                Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", CDbl(DT_SalaryLoan(z)("Amount")), 0, "CIB", "Payment of " & DT_SalaryLoan(z)("Payor"), DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                If ForcedAvailed Then
                    'Interest **********************************************************************************************************************
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420001", If(MortgageID = 2, "420002", "420006"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dUDI, "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                    'Principal **********************************************************************************************************************
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "112001", If(MortgageID = 2, "112002", "112003"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dPrincipal, "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                    GoTo Here_Filled
                End If
                'Billing (Accounts Receivable) **********************************************************************************************************************
                Dim Bill_Allocation As Double
                For x As Integer = 0 To DT_Billing.Rows.Count - 1
                    DT_Account.Rows.Add(DT_Billing(x)("AccountCode"), DT_Billing(x)("DepartmentCode"), DT_Billing(x)("Account"), DT_Billing(x)("Business Center"), DT_Billing(x)("Department"), DT_Billing(x)("Credit"), If((CDbl(DT_SalaryLoan(z)("Amount")) - Bill_Allocation) >= DT_Billing(x)("Debit"), DT_Billing(x)("Debit"), NegativeNotAllowed(CDbl(DT_SalaryLoan(z)("Amount")) - Bill_Allocation)), DT_Billing(x)("PaidFor"), "[Payable: " & FormatNumber(CDbl(DT_Billing(x)("Debit"))) & "] " & DT_Billing(x)("Remarks"), DT_Billing(x)("RequiredRemarks"), DT_Billing(x)("ID"), DT_Billing(x)("DocumentNumber"), DT_Billing(x)("Debit"), DT_Billing(x)("BusinessCode"), DT_Billing(x)("Type_ID"), DT_SalaryLoan(z)("CreditNumber"), DT_Billing(x)("MotherCode"))
                    Bill_Allocation += If((CDbl(DT_SalaryLoan(z)("Amount")) - Bill_Allocation) >= DT_Billing(x)("Debit"), DT_Billing(x)("Debit"), NegativeNotAllowed(CDbl(DT_SalaryLoan(z)("Amount")) - Bill_Allocation))
                Next
                'Interest Income-Past Due (Penalty)**********************************************************************************************************************
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))
                If GridView3.FocusedRowHandle = GridView3.RowCount - 2 And dPenalty >= dPenalty_P Then
                    If dPenalty_P = 0 Then
                    Else 'ZERO DLI NA I APIL PAG SUGGEST
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dPenalty_P, "Penalty", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                    End If
                ElseIf dPenalty > 0 Then
                    If dPenalty = 0 Then
                    Else 'ZERO DLI NA I APIL PAG SUGGEST
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dPenalty, "Penalty", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                    End If
                End If
                'RPPD **********************************************************************************************************************
                If dRPPD_P > 0 Then
                    If GridView3.FocusedRowHandle = GridView3.RowCount - 2 And dRPPD >= dRPPD_P Then
                        If dRPPD_P = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dRPPD_P, "RPPD", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    Else
                        If dRPPD = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dRPPD, "RPPD", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    End If
                ElseIf dRPPD_P = 0 And (dUDI > 0 Or dPrincipal > 0) Then 'For checking wala ma apil ang availed wrong condition || TotalRPPD - is the total Paid and Availed RPPD
                    'MAG SAVE OG AVAILED RPPD 
                    'DT_Account.Rows.Add(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))), "", DataObject(String.Format("SELECT AccountTitleCode('{0}');", If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, Availed, "RPPD", "AVAILED RPPD", DataObject(String.Format("SELECT GetRequiredRemarks('{0}');", If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"))
                End If
                'Interest **********************************************************************************************************************
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "420001", If(MortgageID = 2, "420002", "420006"))))
                If GridView3.FocusedRowHandle = GridView3.RowCount - 2 And dUDI >= dUDI_P Then
                    If dUDI_P = 0 Then
                    Else 'ZERO DLI NA I APIL PAG SUGGEST
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dUDI_P, "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                    End If
                ElseIf ((GridView3.FocusedRowHandle = GridView3.RowCount - 2 Or dBalanceLedger.Value <= (CDbl(DT_SalaryLoan(z)("Amount")) - dPenalty)) And Math.Round(dUDI, 2, MidpointRounding.AwayFromZero) >= dUDI_P) Then
                    If dUDI > dUDI_P And Branch_DeferredIncome Then
                        If dUDI_P = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dUDI_P, "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    Else
                        If CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - (TotalInterest) = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, CDbl(GridView3.GetRowCellValue(0, "Unearn Income")) - (TotalInterest), "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    End If
                ElseIf dBalanceLedger.Value <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Loans Receivable")) And (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Outstanding Principal")) And If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Due Date")) And Payable_Interest > 0 Then
                    If CDbl(DT_SalaryLoan(z)("Amount")) >= Payable_Interest Then
                        If Payable_Interest = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, Payable_Interest, "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    Else
                        If CDbl(DT_SalaryLoan(z)("Amount")) = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, CDbl(DT_SalaryLoan(z)("Amount")), "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    End If
                Else
                    If dUDI > dUDI_P And Branch_DeferredIncome Then
                        If dUDI_P = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dUDI_P, "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    Else
                        If dUDI = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dUDI, "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    End If
                End If
                'Principal **********************************************************************************************************************
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(MortgageID = 1, "112001", If(MortgageID = 2, "112002", "112003"))))
                If GridView3.FocusedRowHandle = GridView3.RowCount - 2 And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P Then
                    If dPrincipal_P = 0 Then
                    Else 'ZERO DLI NA I APIL PAG SUGGEST
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dPrincipal_P, "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                    End If
                ElseIf ((GridView3.FocusedRowHandle = GridView3.RowCount - 2 Or dBalanceLedger.Value <= (CDbl(DT_SalaryLoan(z)("Amount")) - dPenalty)) And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P) Then
                    If CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - (TotalPayment) = 0 Then
                    Else 'ZERO DLI NA I APIL PAG SUGGEST
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - (TotalPayment), "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                    End If
                ElseIf (EarlySettlement And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P) Then
                    If dPrincipal_P = 0 Then
                    Else 'ZERO DLI NA I APIL PAG SUGGEST
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dPrincipal_P, "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                    End If
                ElseIf dBalanceLedger.Value <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Loans Receivable")) And (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment) <= CDbl(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Outstanding Principal")) And If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))) > CDate(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Due Date")) And Payable_Interest > 0 Then
                    If CDbl(DT_SalaryLoan(z)("Amount")) >= Payable_Interest Then
                        If CDbl(DT_SalaryLoan(z)("Amount")) - Payable_Interest = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, CDbl(DT_SalaryLoan(z)("Amount")) - Payable_Interest, "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    Else
                        If 0 = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, 0, "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    End If
                Else
                    If dPrincipal > (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment) Then
                        If (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment) = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, (CDbl(GridView3.GetRowCellValue(0, "Outstanding Principal")) - TotalPayment), "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    Else
                        If Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero), "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    End If
                End If
                'DEFERRED INCOME **********************************************************************************************************************
                If Branch_DeferredIncome Then
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229104"))
                    If dUDI > dUDI_P Then
                        If dUDI - dUDI_P = 0 Then
                        Else 'ZERO DLI NA I APIL PAG SUGGEST
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, dUDI - dUDI_P, "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                        End If
                    End If
                End If

                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "620061"))
                If RemoveRPPDFromBalanceLedger Then
                    If ((GridView3.FocusedRowHandle = GridView3.RowCount - 2 Or CDbl(DT_SalaryLoan(z)("Amount")) > (dBalanceLedger.Value + dPenalty)) And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P) Or EarlySettlement Then
                        If dPrincipal > dPrincipal_P Then
                            If EarlySettlement Then
                                If Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P = 0 Then
                                Else 'ZERO DLI NA I APIL PAG SUGGEST
                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P, "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                                End If
                            Else
                                If CDbl(DT_SalaryLoan(z)("Amount")) - (dBalanceLedger.Value + dPenalty) = 0 Then
                                Else 'ZERO DLI NA I APIL PAG SUGGEST
                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, CDbl(DT_SalaryLoan(z)("Amount")) - (dBalanceLedger.Value + dPenalty), "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                                End If
                            End If
                        End If
                    End If
                Else
                    If ((GridView3.FocusedRowHandle = GridView3.RowCount - 2 Or CDbl(DT_SalaryLoan(z)("Amount")) > ((dBalanceLedger.Value - ((CDbl(GridView3.GetRowCellValue(0, "Total_RPPD")) - TotalRPPD) - TotalRPPD_Payable)) + dPenalty)) And Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) >= dPrincipal_P) Or EarlySettlement Then
                        If dPrincipal > dPrincipal_P Then
                            If EarlySettlement Then
                                If Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P = 0 Then
                                Else 'ZERO DLI NA I APIL PAG SUGGEST
                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, Math.Round(dPrincipal, 2, MidpointRounding.AwayFromZero) - dPrincipal_P, "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                                End If
                            Else
                                If CDbl(DT_SalaryLoan(z)("Amount")) - ((dBalanceLedger.Value - ((CDbl(GridView3.GetRowCellValue(0, "Total_RPPD")) - TotalRPPD) - TotalRPPD_Payable)) + dPenalty) = 0 Then
                                Else 'ZERO DLI NA I APIL PAG SUGGEST
                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}');", DT_SalaryLoan(z)("BusinessCode"))), "", 0, CDbl(DT_SalaryLoan(z)("Amount")) - ((dBalanceLedger.Value - ((CDbl(GridView3.GetRowCellValue(0, "Total_RPPD")) - TotalRPPD) - TotalRPPD_Payable)) + dPenalty), "", "Other Income - Exceed payment of Principal", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, DT_SalaryLoan(z)("BusinessCode"), 0, DT_SalaryLoan(z)("CreditNumber"), DT_Temp_Account(0)("MotherCode"))
                                End If
                            End If
                        End If
                    End If
                End If

                '**** FILL ACCOUNT
            End If
Here_Filled:
            DT_SalaryLoan(z)("Availed") = Availed
            DT_SalaryLoan(z)("dRPPD_P") = dRPPD_P
            DT_SalaryLoan(z)("TotalRPPD_Payable") = TotalRPPD_Payable
            DT_SalaryLoan(z)("TotalRPPD") = TotalRPPD
        Next
        If SalaryPaid > SalaryPayable Then
            Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
            AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
            If SalaryPaid - SalaryPayable = 0 Then
            Else 'ZERO DLI NA I APIL PAG SUGGEST
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", SalaryPaid - SalaryPayable, 0, "CIB", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, "", 0, "", DT_Temp_Account(0)("MotherCode"))
            End If
            AccountCodeDetails("218001")
            If SalaryPaid - SalaryPayable = 0 Then
            Else 'ZERO DLI NA I APIL PAG SUGGEST
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, SalaryPaid - SalaryPayable, "", "", DT_Temp_Account(0)("RequiredRemarks"), 0, "", 0, "", 0, "", DT_Temp_Account(0)("MotherCode"))
            End If
        End If

        dBalanceLedger.Value = 0
        dPayable.Value = 0
        Dim TotalDebit As Double
        Dim TotalCredit As Double
        Dim Total_CIB As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                Total_CIB += CDbl(DT_Account(x)("Debit"))
            End If
        Next
        If GridView2.RowCount > 7 Then
            GridColumn32.Width = 226 - 17
        Else
            GridColumn32.Width = 226
        End If
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB
        SalaryLoan_Loading = False
    End Sub

    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim Rows As New ArrayList()
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim TotalR As Double
            For x As Integer = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Integer = selectedRowHandles(x)
                TotalR += GridView1.GetRowCellValue(selectedRowHandle, "Amount")
            Next
            GridView1.Columns("Amount").SummaryItem.DisplayFormat = FormatNumber(TotalR, 2)
        Else
            GridView1.Columns("Amount").SummaryItem.DisplayFormat = "{0:n2}"
        End If
        Try
            If GridView1.GetFocusedRowCellValue("Type") = "CHECK" Then
                iBounce.Enabled = True
            Else
                iBounce.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CbxLoans_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLoans.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadPayee()
    End Sub

    Private Sub CbxPayee_TextChanged(sender As Object, e As EventArgs) Handles cbxPayee.TextChanged
        If cbxPayee.Text = "" And cbxPayee.Enabled Then
            Clear(False)
        End If
    End Sub

    Private Sub IJV_Click(sender As Object, e As EventArgs) Handles iJV.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Official Receipt is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS_JVNumber") <> "" Then
                MsgBox("Official Receipt already have a DTS Journal Voucher. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Official Receipt is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Official Receipt is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Official Receipt is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CLEARING" Then
                If MsgBoxYes("Official Receipt is already FOR CLEARING, would you like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED" Then
                If MsgBoxYes("Official Receipt is already CLEARED, would you like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            ElseIf GridView1.GetFocusedRowCellValue("DTS") = True Then
                If MsgBoxYes("This is a DTS Official Receipt, are you sure you want to Journal Voucher this? This will reverse the entry") = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                Dim Prev As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DocumentNumber),'') AS 'DocumentNumber' FROM official_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'CA' AND `status` = 'ACTIVE' AND voucher_status IN ('PENDING', 'CHECKED', 'APPROVED') AND ID > {1};", GridView1.GetFocusedRowCellValue("Payee_ID"), GridView1.GetFocusedRowCellValue("ID")))
                If Prev = "" Then
                Else
                    If MsgBox(String.Format("Reserving this transaction might affect the computation of the Document Number(s): {0}. Would you like to proceed?", Prev), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes(String.Format("Are you sure you want to open the Journal Voucher for this transaction, saving this Journal Voucher will result for the cancellation of document number {0}", GridView1.GetFocusedRowCellValue("Document Number"))) = MsgBoxResult.No Then
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
            Logs("Official Receipt", "Journal Voucher", "Journal Voucher", "", "", "", "")
            .cbxLA.Enabled = False
            .cbxCV.Enabled = False
            .cbxACR.Enabled = False
            .cbxAP.Enabled = False
            .cbxDT.Enabled = False
            .cbxDF.Enabled = False
            .cbxAR.Enabled = False
            .cbxLOE.Enabled = False
            .cbxJV.Enabled = False
            .cbxOR.Enabled = False
            .cbxUR.Enabled = False
            .cbxDI.Enabled = False
            .cbxRS.Enabled = False
            .cbxITL.Enabled = False
            .cbxROPA.Enabled = False
            .cbxDTS.Enabled = False
            .cbxOR.Checked = True
            .From_ACR = True
            .BankID = GridView1.GetFocusedRowCellValue("BankID")
            .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("ID")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub CbxCheckNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCheckNumber.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxCheckNumber.SelectedIndex = -1 Or cbxCheckNumber.Text = "" Then
            dtpCheck.Value = Date.Now
            dPaidAmount.Enabled = cbxPayee.Enabled
            dtpCheck.Enabled = True
        Else
            Dim drv As DataRowView = DirectCast(cbxCheckNumber.SelectedItem, DataRowView)
            dtpCheck.Value = drv("Date")
            dtpCheck.Enabled = False
            If cbxCheck.Checked Then
                dPaidAmount.Value = drv("Amount")
                dPaidAmount.Enabled = False
            Else
                dPaidAmount.Enabled = cbxPayee.Enabled
            End If
        End If
    End Sub

    Private Sub CbxCheckNumber_TextChanged(sender As Object, e As EventArgs) Handles cbxCheckNumber.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxCheck.Checked Then
            If cbxCheckNumber.SelectedIndex = -1 Or cbxCheckNumber.Text = "" Then
                dPaidAmount.Enabled = cbxPayee.Enabled
            Else
                dPaidAmount.Enabled = False
            End If
        Else
            dPaidAmount.Enabled = cbxPayee.Enabled
        End If
    End Sub

    Private Sub UpdateNotification(xCode As String, SendMail As Boolean)
        Code = xCode
        Dim Msg As String = ""
        Dim EmailTo As String = ""
        Dim Subject As String
        Dim FName As String
        If txtChecked.Text = "" Then
            'F O R   C H E C K I N G************************************************************************************************************************
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Updated Official Receipt of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If DT_Signatory(x)("Phone") = "" Then
                    Else
                        SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If DT_Signatory(x)("EmailAdd") = "" Then
                    Else
                        EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                    End If
                End If
            Next
            If EmailTo = "" Then
            Else
                Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "] [UPDATE]"
                AttachmentFiles = New ArrayList()
                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                GenerateReceipt(False, FName, txtChecked.Text, txtApproved.Text)
                AttachmentFiles.Add(FName)
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
            End If
            'F O R   C H E C K I N G************************************************************************************************************************
        ElseIf txtApproved.Text = "" Then
            'F O R   A P P R O V A L ***********************************************************************************************************************
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Updated Official Receipt of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If DT_Signatory(x)("Phone") = "" Then
                    Else
                        SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If DT_Signatory(x)("EmailAdd") = "" Then
                    Else
                        EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                    End If
                End If
            Next
            If EmailTo = "" Then
            Else
                Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "] [UPDATE]"
                AttachmentFiles = New ArrayList() 'JUST ADDED UNDER OBSERVATION
                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                GenerateReceipt(False, FName, txtChecked.Text, txtApproved.Text)
                AttachmentFiles.Add(FName)
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
            End If
            'F O R   A P P R O V A L ***********************************************************************************************************************
        End If
    End Sub

    Private Sub CheckNotification(xCode As String, SendMail As Boolean)
        Code = xCode
        Code_Check = Code
        Dim Msg As String = ""
        Dim EmailTo As String = ""
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Official Receipt of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
                Msg &= "Thank you!"
                '******* SEND SMS *********************************************************************************
                If DT_Signatory(x)("Phone") = "" Then
                Else
                    SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                End If
                '******* SEND EMAIL *********************************************************************************
                If DT_Signatory(x)("EmailAdd") = "" Then
                Else
                    EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                End If
            End If
        Next
        If EmailTo = "" Then
        Else
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
            AttachmentFiles = New ArrayList() 'JUST ADDED UNDER OBSERVATION
            GenerateReceipt(False, FName, txtChecked.Text, txtApproved.Text)
            AttachmentFiles.Add(FName)
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
        End If
    End Sub

    Private Sub ApproveNotification(xCode As String, SendMail As Boolean)
        Code = xCode
        Code_Approve = Code
        Dim Msg As String = ""
        Dim EmailTo As String = ""
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Official Receipt of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
                Msg &= "Thank you!"
                '******* SEND SMS *********************************************************************************
                If DT_Signatory(x)("Phone") = "" Then
                Else
                    SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                End If
                '******* SEND EMAIL *********************************************************************************
                If DT_Signatory(x)("EmailAdd") = "" Then
                Else
                    EmailTo = EmailTo & DT_Signatory(x)("EmailAdd") & ", "
                End If
            End If
        Next
        If EmailTo = "" Then
        Else
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
            AttachmentFiles = New ArrayList() 'JUST ADDED UNDER OBSERVATION
            GenerateReceipt(False, FName, txtChecked.Text, txtApproved.Text)
            AttachmentFiles.Add(FName)
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
        End If
    End Sub

    Private Sub CbxAvailed_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAvailed.CheckedChanged
        If FirstLoad Or GridView3.RowCount = 0 Or If(cbxCheck.Checked And cbxCheck.Enabled = False, 0, cbxPayee.Enabled = False) Or cbxPayee.SelectedIndex = -1 Then
            Exit Sub
        End If

        Compute()

        If SalaryLoan Then
            If SalaryLoan_Loading Then
            Else
                FillAccountsV2()
            End If
        Else
            FillAccounts()
        End If
    End Sub

    Private Sub CbxRemittance_CheckedChanged(sender As Object, e As EventArgs) Handles cbxRemittance.CheckedChanged
        If cbxRemittance.Checked Then
            txtRemittance.Enabled = True
            dtpRemittance.Enabled = True
            dtpRemittance.CustomFormat = "MMMM dd, yyyy"
            dtpRemittance.Value = Date.Now

            DateValueChanged = True
            DateLeave(sender, e)
        Else
            txtRemittance.Enabled = False
            dtpRemittance.Enabled = False
            txtRemittance.Text = ""
            dtpRemittance.CustomFormat = ""

            DateValueChanged = True
            DateLeave(sender, e)
        End If
    End Sub

    Private Sub BtnEarlySettlement_Click(sender As Object, e As EventArgs) Handles btnEarlySettlement.Click
        If MsgBox("Do you want to cancel this early settlement?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Dim SQL As String = String.Format("UPDATE credit_earlysettlement SET `status` = 'CANCELLED' WHERE CreditNumber = '{1}' AND `status` = 'ACTIVE' AND early_status = 'PENDING' AND ORNumber = '' AND AsOf <= '{2}';", txtDocumentNumber.Text, ValidateComboBox(cbxPayee), Format(If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))), "yyyy-MM-dd"))
            DataObject(SQL)
            Logs("Official Receipt", "Cancel Early", "", String.Format("Cancel Early Settlement of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dPaidAmount.Text), "", "", "")
            ComputeEarly()
            CbxPayee_SelectedIndexChanged(sender, e)
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub CbxClosed_CheckedChanged(sender As Object, e As EventArgs) Handles cbxClosed.CheckedChanged
        LoadPayee()
    End Sub

    Private Sub BtnCalculatorV2_Click(sender As Object, e As EventArgs) Handles btnCalculatorV2.Click
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim SOA As New FrmSOA
        With SOA
            FormRestriction(26)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            .From_Payment = True
            .From_OR = True
            .Show()
            .FirstLoad = True
            LoadAmortization(.GridControl3)
            If GridColumn41.Visible Then
                .GridColumn16.VisibleIndex = 0
                .GridColumn17.VisibleIndex = 1
                .GridColumn18.VisibleIndex = 2
                .GridColumn5.VisibleIndex = 3
                .GridColumn19.VisibleIndex = 4
                .GridColumn20.VisibleIndex = 5
                .GridColumn21.VisibleIndex = 6
                .GridColumn22.VisibleIndex = 7
                .GridColumn23.VisibleIndex = 8
                .GridColumn24.VisibleIndex = 9
                .GridColumn6.VisibleIndex = 10
                .GridColumn34.VisibleIndex = 11

                .GridColumn16.Width = 25
                .GridColumn17.Width = 58
                .GridColumn18.Width = 54
                .GridColumn5.Width = 52
                .GridColumn19.Width = 54
                .GridColumn20.Width = 52
                .GridColumn21.Width = 57
                .GridColumn22.Width = 57
                .GridColumn23.Width = 54
                .GridColumn24.Width = 52
                .GridColumn6.Width = 52
                .GridColumn34.Width = 62
            End If
            .cbxCreditApplication.Enabled = False
            .Availed = .GridView3.FocusedRowHandle <> 1
            .CbxPrefix_B.Text = drv("Prefix_B")
            .TxtFirstN_B.Text = drv("FirstN_B")
            .TxtMiddleN_B.Text = drv("MiddleN_B")
            .TxtLastN_B.Text = drv("LastN_B")
            .cbxSuffix_B.Text = drv("Suffix_B")
            .txtCompleteAdd.Text = drv("Address")
            .txtMobile.Text = drv("Mobile_B")
            .txtEmail.Text = drv("Email_B")
            .txtAccount.SelectedValue = drv("Product_ID")
            .cbxAvailed.Checked = cbxAvailed.Checked
            .iAccount_2.Text = DataObject(String.Format("SELECT AccountNumber FROM credit_released WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}';", cbxPayee.SelectedValue))
            .txtCollateral.Text = DataObject(String.Format("SELECT Collateral FROM credit_investigation WHERE `status` = 'ACTIVE' AND ci_status = 'APPROVED' AND CreditNumber = '{0}';", cbxPayee.SelectedValue))
            .dPrincipal.Value = drv("AmountApplied")
            .dFaceAmount.Value = drv("Face_Amount")
            .iDue.Value = If(drv("with_Interest"), Format(CDate(drv("FDD")), "dd"), 15)
            .iDue.Enabled = CBool(drv("with_Interest"))
            If GridColumn41.Visible Then
                .dMonthlyAmort.Value = .GridView3.GetFocusedRowCellValue("Monthly")
            Else
                .dMonthlyAmort.Value = If(drv("Product").ToString.ToUpper.Contains("DEALER"), Math.Round(drv("Interest") / drv("Terms"), 2, MidpointRounding.AwayFromZero), If(drv("Product_Payment") = "Monthly" Or drv("Product_Payment") = "Daily" Or drv("Product_Payment") = "Weekly", drv("GMA"), drv("GMA") / 1))
            End If
            .dRPPD.Value = CDbl(.GridView3.GetFocusedRowCellValue("RPPD"))
            .dtpAvailed.Value = drv("Released")
            .dtpFDD.Value = drv("FDD")
            .dtpMaturity.Value = DateValue(drv("LDD"))
            .FirstLoad = False
            .dBalance_Arrears.Value = dBalanceLedger.Value
            .dtpLastP.Value = LastPaymentBefore
            .dUnpaidPenalties.Value = TotalUnpaidPenalty
            .dDiscount.Value = TotalWaive
            .dDiscountRPPD.Value = TotalWaiveRPPD
            .btnWaive.Visible = False
            .dtpAsOf.Value = If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value))))
        End With
    End Sub

    Private Sub CbxAR_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAR.CheckedChanged
        If cbxAR.Checked Then
            lblAR.Visible = True
            txtARNumber.Visible = True
            dtpAR.Visible = True
            txtARNumber.Text = ""
            dtpAR.CustomFormat = "MMMM dd, yyyy"
            dtpAR.Value = Date.Now
        Else
            lblAR.Visible = False
            txtARNumber.Visible = False
            dtpAR.Visible = False
            dtpAR.CustomFormat = ""
            If DateValue(dtpAR.Value) = DateValue(dtpORDate.Value) Then
            Else
                DateValueChanged = True
                DateLeave(sender, e)
            End If
        End If
    End Sub

    Private Sub BtnDTS_Click(sender As Object, e As EventArgs) Handles btnDTS.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS") = 0 Then
                MsgBox("Official Receipt is not set on DTS.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Official Receipt is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS_JVNumber") <> "" Then
                MsgBox("DTS Official Receipt already have a Journal Voucher. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Official Receipt is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Official Receipt is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Official Receipt is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

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
            Logs("Official Receipt", "Due To Stockholders", "Open Due To Stockholders Journal Voucher", "", "", "", "")
            .cbxLA.Enabled = False
            .cbxCV.Enabled = False
            .cbxACR.Enabled = False
            .cbxAP.Enabled = False
            .cbxDT.Enabled = False
            .cbxDF.Enabled = False
            .cbxAR.Enabled = False
            .cbxLOE.Enabled = False
            .cbxJV.Enabled = False
            .cbxOR.Enabled = False
            .cbxUR.Enabled = False
            .cbxDI.Enabled = False
            .cbxRS.Enabled = False
            .cbxITL.Enabled = False
            .cbxROPA.Enabled = False
            .cbxDTS.Enabled = False
            .cbxDTS.Checked = True
            .From_ACR = True
            .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("ID")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub LoadDTS(vOR_ID As Integer)
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
            Logs("Official Receipt", "Due To Stockholders", "Open Due To Stockholders Journal Voucher", "", "", "", "")
            .cbxLA.Enabled = False
            .cbxCV.Enabled = False
            .cbxACR.Enabled = False
            .cbxAP.Enabled = False
            .cbxDT.Enabled = False
            .cbxDF.Enabled = False
            .cbxAR.Enabled = False
            .cbxLOE.Enabled = False
            .cbxJV.Enabled = False
            .cbxOR.Enabled = False
            .cbxUR.Enabled = False
            .cbxDI.Enabled = False
            .cbxRS.Enabled = False
            .cbxITL.Enabled = False
            .cbxROPA.Enabled = False
            .cbxDTS.Enabled = False
            .cbxDTS.Checked = True
            .From_ACR = True
            .GL_DocumentNumber = vOR_ID
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnChangeBank_Click(sender As Object, e As EventArgs) Handles btnChangeBank.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Bank As New FrmBankTagged
        With Bank
            .Bank = GridView1.GetFocusedRowCellValue("BankID")
            If .ShowDialog() = DialogResult.OK Then
                If BankID = .cbxBank.SelectedValue Then
                Else
                    Dim Msg As String = ""
                    Dim Subject As String = ""
                    Dim FName As String = ""
                    Dim EmailTo As String = ""
                    Code = GenerateOTAC()
                    Subject = "One Time Authorization Code " & Code & GridView1.GetFocusedRowCellValue("Payee")
                    Dim BM As DataTable = GetBM(Branch_ID)
                    For x As Integer = 0 To BM.Rows.Count - 1
                        Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Change Bank of Official Receipt of the Account of {1}." & vbCrLf, Code, GridView1.GetFocusedRowCellValue("Payee"))
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
                            DataObject(String.Format("UPDATE official_receipt SET BankID = '{0}' WHERE DocumentNumber = '{1}'; UPDATE accounting_entry SET BankID = '{0}' WHERE ORNum = '{1}';", Bank.cbxBank.SelectedValue, GridView1.GetFocusedRowCellValue("Document Number")))
                            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                            Logs("Official Receipt", "Change Bank", String.Format("Change Bank From {0} to {1} for Document Number {2}.", GridView1.GetFocusedRowCellValue("Bank"), Bank.cbxBank.Text, GridView1.GetFocusedRowCellValue("Document Number")), "", "", "", "")
                            LoadData()
                        End If
                    End With
                End If
            End If
            .Dispose()
        End With
    End Sub

    Private Sub DateLeave(sender As Object, e As EventArgs) Handles dtpORDate.Leave, dtpDeposit.Leave, dtpRemittance.Leave, dtpAR.Leave
        If dPaidAmount.Enabled = False And btnSave.Text = "Update" And cbxPayee.SelectedIndex > -1 Then
            ComputePenaltyModify()
        End If

        If dtpORDate.Value.DayOfWeek = 6 Or dtpORDate.Value.DayOfWeek = 0 Then
            LabelX20.ForeColor = OfficialColor2
            dtpORDate.ForeColor = OfficialColor2
        Else
            LabelX20.ForeColor = Color.Black
            dtpORDate.ForeColor = Color.Black
        End If
        If dtpDeposit.Value.DayOfWeek = 6 Or dtpDeposit.Value.DayOfWeek = 0 Then
            LabelX8.ForeColor = OfficialColor2
            dtpDeposit.ForeColor = OfficialColor2
        Else
            LabelX8.ForeColor = Color.Black
            dtpDeposit.ForeColor = Color.Black
        End If
        If dtpRemittance.Value.DayOfWeek = 6 Or dtpRemittance.Value.DayOfWeek = 0 Then
            LabelX17.ForeColor = OfficialColor2
            dtpRemittance.ForeColor = OfficialColor2
        Else
            LabelX17.ForeColor = Color.Black
            dtpRemittance.ForeColor = Color.Black
        End If
        If dtpAR.Value.DayOfWeek = 6 Or dtpAR.Value.DayOfWeek = 0 Then
            dtpAR.ForeColor = OfficialColor2
        Else
            dtpAR.ForeColor = Color.Black
        End If

        If FirstLoad Or GridView3.RowCount = 0 Or cbxPayee.SelectedIndex = -1 Or DateValueChanged = False Then
            Exit Sub
        End If

        Dim DT_Waive As DataTable = DataSource(String.Format("SELECT IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('RPPD-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived RPPD', IFNULL((SELECT Amount FROM accounting_entry A WHERE A.PaidFor IN ('Penalty-W') AND A.`status` = 'WAITING' AND A.ReferenceN = '{0}' AND ORDate = '{1}' ORDER BY ID DESC LIMIT 1),0) AS 'Total Waived Penalty' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", ValidateComboBox(cbxPayee), Format(dtpORDate.Value, "yyyy-MM-dd")))
        If DT_Waive.Rows.Count > 0 Then
            TotalWaive = DT_Waive(0)("Total Waived Penalty")
            TotalWaiveRPPD = DT_Waive(0)("Total Waived RPPD")
        Else
            TotalWaive = 0
            TotalWaiveRPPD = 0
        End If
        If TotalWaive + TotalWaiveRPPD > 0 Then
            btnWaiveRemove.Enabled = True
            'cbxBank.Size = New Point(313, 25)
        Else
            btnWaiveRemove.Enabled = False
            'cbxBank.Size = New Point(381, 25)
        End If

        dBilling_P = 0
        DT_Billing = DataSource(String.Format("SELECT D.ID, M.DocumentNumber, AccountCode, DepartmentCode, AccountTitleCode(D.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit - D.Paid AS 'Debit', Credit AS 'Credit', 'Billing' AS 'PaidFor', CONCAT(Remarks, ' ', (SELECT GROUP_CONCAT(CONCAT(AccountTitle(ar_details.AccountCode), ' (', FORMAT(Credit,2),')')) FROM ar_details WHERE ar_details.DocumentNumber = M.DocumentNumber AND ar_details.`status` = 'ACTIVE' AND ar_details.Credit > 0)) AS 'Remarks', Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode FROM accounts_receivable M INNER JOIN ar_details D ON M.DocumentNumber = D.DocumentNumber AND D.Status = 'ACTIVE' AND M.Status = 'ACTIVE' AND NotAR = 0 AND JVNumber = '' AND AR_Status NOT IN ('FULLY PAID','PENDING','CHECKED') AND PayorID = '{0}' AND Debit - D.Paid > 0 AND M.JVNumberV2 = '' AND PostingDate <= '{1}';", ValidateComboBox(cbxPayee), FormatDatePicker(If(cbxRemittance.Checked, dtpRemittance, If(cbxOnline.Checked, dtpDeposit, If(cbxAR.Checked, dtpAR, dtpORDate))))))
        For x As Integer = 0 To DT_Billing.Rows.Count - 1
            dBilling_P += CDbl(DT_Billing(x)("Debit"))
        Next

        Compute()
        ComputeEarly()
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If dPaidAmount.Enabled Then
            dBalanceLedger.Value = GetBalanceLedger(cbxPayee.SelectedValue)
        End If
        If SalaryLoan Then
            If SalaryLoan_Loading Then
            Else
                FillAccountsV2()
            End If
        Else
            FillAccounts()
        End If
        DateValueChanged = False
    End Sub

    Private Sub Date_ValueChanged(sender As Object, e As EventArgs) Handles dtpORDate.ValueChanged, dtpDeposit.ValueChanged, dtpRemittance.ValueChanged, dtpAR.ValueChanged
        DateValueChanged = True
    End Sub

    Private Sub INotDTS_Click(sender As Object, e As EventArgs) Handles iNotDTS.Click
        Try 'NOT NECESSARY ANYMORE!! WILL BE REMOVE IN THE FUTURE
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS") = 0 Then
                MsgBox("Official Receipt is not set on DTS.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Official Receipt is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS_JVNumber") <> "" Then
                MsgBox("DTS Official Receipt already have a Journal Voucher. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Official Receipt is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Official Receipt is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("BankID") <> DataObject(String.Format("SELECT BankID FROM credit_application WHERE CreditNumber = '{0}';", GridView1.GetFocusedRowCellValue("Payee_ID"))) Then
                MsgBox(String.Format("Official Receipt bank tagged is not the same with the Bank for account of {0}.", GridView1.GetFocusedRowCellValue("Payee")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes("Are you sure that this OR is not DTS?") = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE official_receipt SET DTS = 0 WHERE DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            Logs("Official Receipt", "Not DTS", String.Format("Change OR From DTS to Not DTS for Document Number {0}.", GridView1.GetFocusedRowCellValue("Document Number")), "", "", "", "")
            LoadData()
        End If
    End Sub

    Private Sub BtnWaiveRemove_Click(sender As Object, e As EventArgs) Handles btnWaiveRemove.Click
        If MsgBox("Do you want to cancel this waive of Penalty/RPPD?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Dim SQL As String = String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE ReferenceN = '{1}' AND `status` = 'WAITING' AND ORDate = '{2}';", txtDocumentNumber.Text, ValidateComboBox(cbxPayee), Format(If(cbxRemittance.Checked, DateValue(dtpRemittance.Value), If(cbxOnline.Checked, DateValue(dtpDeposit.Value), If(cbxAR.Checked, DateValue(dtpAR.Value), DateValue(dtpORDate.Value)))), "yyyy-MM-dd"))
            DataObject(SQL)
            Logs("Official Receipt", "Cancel Waive", "", String.Format("Cancel Waive of Penalty/RPPD of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, TotalWaive + TotalWaiveRPPD), "", "", "")
            CbxPayee_SelectedIndexChanged(sender, e)
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnReference_Click(sender As Object, e As EventArgs) Handles btnReference.Click
        GridView1.SetFocusedRowCellValue("Reference Number", UpdateReferenceNumber("Official Receipt", "official_receipt", GridView1.GetFocusedRowCellValue("Reference Number"), GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Document Number")))
    End Sub

    Private Sub IJournalVoucherDTS_Click(sender As Object, e As EventArgs) Handles iJV_DTS.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Official Receipt is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS_JVNumber") <> "" Then
                MsgBox("Official Receipt already have a DTS Journal Voucher. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Official Receipt is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Official Receipt is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Official Receipt is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS") = False Then
                MsgBox("Official Receipt is not Due to Stockholders.", MsgBoxStyle.Information, "Info")
                Exit Sub
            Else
                Dim Prev As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DocumentNumber),'') AS 'DocumentNumber' FROM official_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'CA' AND `status` = 'ACTIVE' AND voucher_status IN ('PENDING', 'CHECKED', 'APPROVED') AND ID > {1};", GridView1.GetFocusedRowCellValue("Payee_ID"), GridView1.GetFocusedRowCellValue("ID")))
                If Prev = "" Then
                Else
                    If MsgBox(String.Format("Reserving this transaction might affect the computation of the Document Number(s): {0}. Would you like to proceed?", Prev), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

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
            Logs("Official Receipt", "Journal Voucher [DTS]", "Journal Voucher", "", "", "", "")
            .cbxLA.Enabled = False
            .cbxCV.Enabled = False
            .cbxACR.Enabled = False
            .cbxAP.Enabled = False
            .cbxDT.Enabled = False
            .cbxDF.Enabled = False
            .cbxAR.Enabled = False
            .cbxLOE.Enabled = False
            .cbxJV.Enabled = False
            .cbxOR.Enabled = False
            .cbxUR.Enabled = False
            .cbxDI.Enabled = False
            .cbxRS.Enabled = False
            .cbxITL.Enabled = False
            .cbxROPA.Enabled = False
            .cbxDTS.Enabled = False
            .cbxDTS.Checked = True
            .From_ACR = True
            .BankID = GridView1.GetFocusedRowCellValue("BankID")
            .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("ID")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub
End Class
