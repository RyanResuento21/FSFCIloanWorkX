Imports DevExpress.XtraReports.UI
Public Class FrmAcknowledgement

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public FirstLoad As Boolean = True
    Public DefaultBank As Integer
    Dim DT_Account As DataTable
    Dim Code As String
    
    Dim Code_Check As String
    Dim Code_Approve As String
    Dim User_EmplID As Integer = 0
    Dim CopyMode As Boolean
    Public FromAccountsReceivable As Boolean
    Public FromAccountsReceivable_AP As Boolean
    Public FromDueFrom As Boolean
    Public AccountsReceivableID As String
    Public AccountsReceivableID_M As String
    Public BankID As Integer
    Public AR_Account As String
    Public MultipleAR As Boolean
    Public From_GL As Boolean
    Public GL_DocumentNumber As String
    Public From_Check As Boolean
    Public CheckID As Integer
    Public AssetNumber As String
    Public CheckDate As Date
    Public DFPayPrincipal As Boolean
    'FROM ITL
    Public From_ITL As Boolean
    Public From_PDC_Others As Boolean
    'FROM ROPOA WITHOUT BUYER
    Public From_ROPOA As Boolean
    Dim Flag As Boolean = False
    Public Skip_FilterLoadData As Boolean
    Public From_CashAdvance As Boolean
    Dim TotalDeductions As Double

    Private Sub FrmAcknowledgement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView4})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If From_GL Then
            cbxAll.Checked = True
        End If
        If From_Check Or FromAccountsReceivable Or FromDueFrom Or From_ITL Or From_PDC_Others Or From_ROPOA Or From_CashAdvance Then
        Else
            SuperTabControl1.SelectedTab = tabList
            LoadData()
        End If
        cbxDisplay.SelectedIndex = 0
        dtpDocument.Value = Date.Now
        dtpPostingDate.Value = Date.Now
        dtpPostingDate.MaxDate = Date.Now

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

        RepositoryItemLookUpEdit4.DisplayMember = "Paid For"
        RepositoryItemLookUpEdit4.ValueMember = "Paid For"

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

        With RepositoryItemSearchLookUpEdit1
            .DisplayMember = "Account"
            .ValueMember = "Account"
        End With

        LoadCompanyMode()

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

        With cbxBusinessCenter
            .ValueMember = "BusinessCode"
            .DisplayMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter.Copy
            .SelectedIndex = -1
        End With

        With RepositoryItemLookUpEdit3
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

        GetDocumentNumber()
        FirstLoad = False
        If FromAccountsReceivable Or FromDueFrom Or From_ITL Or From_PDC_Others Or From_CashAdvance Then
            If From_Check Or From_CashAdvance Then
                Dim SQL As String = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' LIMIT 1"
                DT_Account = DataSource(SQL)
            End If
            cbxPayee.SelectedValue = AccountsReceivableID
            cbxBank.SelectedValue = BankID
        End If

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

        Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        If From_Check Then
            If FromDueFrom Or From_PDC_Others Then
                If From_PDC_Others Or DefaultBank Or FromDueFrom Then
                    DT_Account.Rows.Clear()
                    AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'CREDIT
                    Dim AR_Account As String
                    If DataObject(String.Format("SELECT Payor_Type FROM due_from WHERE ID = '{0}';", AccountsReceivableID)) = "B" Then
                        AR_Account = "620021"
                    Else
                        AR_Account = "620020"
                    End If
                    AccountCodeDetails(AR_Account)
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    GridControl2.DataSource = DT_Account

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
                    If GridView2.RowCount > 5 Then
                        If GridColumn20.Visible = False Then
                            GridColumn32.Width = 342 - 17
                        Else
                            GridColumn32.Width = (342 - 80) - 17
                        End If
                    Else
                        If GridColumn20.Visible = False Then
                            GridColumn32.Width = 342
                        Else
                            GridColumn32.Width = (342 - 80)
                        End If
                    End If
                End If
            ElseIf AssetNumber <> "" Then
                Dim SQL As String = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' LIMIT 0"
                DT_Account = DataSource(SQL)
                GridControl2.DataSource = DT_Account
                cbxPayee.SelectedValue = AssetNumber
                cbxCheckNumber.SelectedValue = CheckID
            End If
        End If

        If From_ROPOA Then
            Dim SQL As String = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' LIMIT 0"
            DT_Account = DataSource(SQL)
            GridControl2.DataSource = DT_Account
            'DEBIT
            AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            'CREDIT
            AccountCodeDetails("620061")
            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            cbxPayee.SelectedValue = AssetNumber

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
            If GridView2.RowCount > 5 Then
                If GridColumn20.Visible = False Then
                    GridColumn32.Width = 342 - 17
                Else
                    GridColumn32.Width = (342 - 80) - 17
                End If
            Else
                If GridColumn20.Visible = False Then
                    GridColumn32.Width = 342
                Else
                    GridColumn32.Width = (342 - 80)
                End If
            End If
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
            GetToolTipFontSettings({ToolTipController1})

            GetLabelFontSettings({LabelX2, LabelX10, LabelX18, LabelIssued, lblAmount, lblRunningBalance, LabelX9, LabelX6, lblPayable, LabelX7, LabelX12, LabelX16, LabelX13, LabelX8, LabelX5, LabelX15, LabelX34, LabelX40, LabelX42, LabelX39, LabelX41})

            GetLabelWithBackgroundFontSettings({LabelX3, LabelX21, LabelX1, LabelX19, LabelX4, LabelX14, LabelX35})

            GetCheckBoxFontSettings({cbxLOE, cbxAP, cbxAR, cbxDF, cbxITL, cbxRO, cbxLA, cbxCAS, cbxCash, cbxCheck, cbxOnline, cbxAll})

            GetButtonFontSettings({btnAdd_Account, btnRemove_Account, btnLedger, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnDisapprove, btnPrint, btnAttach, btnApprove, btnCheck, btnSearch})

            GetComboBoxFontSettings({cbxPayee, cbxBank, cbxAccount, cbxDepartment, cbxBusinessCenter, cbxCheckNumber, cbxPreparedBy, cbxDisplay})

            GetDateTimeInputFontSettings({dtpDocument, dtpPostingDate, dtpCheck, dtpDeposit, dtpFrom, dtpTo})

            GetTextBoxFontSettings({txtDocumentNumber, txtReferenceNumber, txtDeposit, txtChecked, txtApproved})

            GetDoubleInputFontSettings({dPaidAmount, dRunningBalance, dPayable})

            GetDoubleInputFontSettingsDefault({dAmount})

            GetSearchRepositoryFontSettings({RepositoryItemSearchLookUpEdit1})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit3, RepositoryItemLookUpEdit2, RepositoryItemLookUpEdit4})

            GetRickTextBoxFontSettings({rExplanation})

            GetTabControlFontSettings({SuperTabControl1})

            GetLabelHeaderFontSettings({lblTitle})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Acknowledgement - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Acknowledgement Receipt", lblTitle.Text)
    End Sub

    Private Sub Payee_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLOE.CheckedChanged, cbxAR.CheckedChanged, cbxITL.CheckedChanged, cbxRO.CheckedChanged, cbxDF.CheckedChanged, cbxLA.CheckedChanged, cbxAP.CheckedChanged, cbxCAS.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadPayee()
    End Sub

    Public Sub LoadPayee()
        cbxPayee.DisplayMember = "Employee"
        cbxPayee.ValueMember = "ID"
        Dim SQL As String = ""
        If FromAccountsReceivable Then
            If FromAccountsReceivable_AP Then
                GoTo HereAP
            Else
                GoTo Here
            End If
        End If
        If FromDueFrom Then
            GoTo HereV2
        End If
        If From_ITL Then
            GoTo HereV3
        End If
        If From_PDC_Others Then
            GoTo HereV4
        End If
        If From_ROPOA Then
            GoTo HereV5
        End If
        If From_Check And cbxRO.Checked = False Then
            GoTo HereV6
        End If
        SQL = "SELECT "
        SQL &= "    ID,"
        SQL &= "    Employee (ID) AS 'Employee',"
        SQL &= "    'E' AS 'Type',"
        SQL &= "    Phone,"
        SQL &= "    EmailAdd,"
        SQL &= "    0 AS 'BankID',"
        SQL &= "    '' AS 'AccountNumber', 0 AS 'Amount', '' AS 'Explanation', 0 AS 'PayorID', 0 AS 'Mortgage'"
        SQL &= " FROM employee_setup"
        SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}'", Branch_ID)
        SQL &= " UNION ALL"
HereV4:
        SQL &= " SELECT "
        SQL &= "    ID,"
        SQL &= "    Branch AS 'Employee',"
        SQL &= "    'BRA' AS 'Type',"
        SQL &= "    '' AS 'Phone',"
        SQL &= "    Email_Address AS 'EmailAdd',"
        SQL &= "    0 AS 'BankID',"
        SQL &= "    '' AS 'AccountNumber', 0 AS 'Amount', '' AS 'Explanation', 0 AS 'PayorID', 0 AS 'Mortgage'"
        SQL &= " FROM branch WHERE `status` = 'ACTIVE'"
        If From_PDC_Others Then
            GoTo HereV5
        End If
        SQL &= " UNION ALL"
        SQL &= " SELECT "
        SQL &= "    ID,"
        SQL &= "    Payee,"
        SQL &= "    'B' AS 'Type',"
        SQL &= "    '' AS 'Phone',"
        SQL &= "    '' AS 'EmailAdd',"
        SQL &= "    0 AS 'BankID',"
        SQL &= "    '' AS 'AccountNumber', 0 AS 'Amount', '' AS 'Explanation', 0 AS 'PayorID', 0 AS 'Mortgage'"
        SQL &= " FROM acknowledgement_payee"
        SQL &= "    WHERE `status` = 'ACTIVE' "
        If cbxLOE.Checked Then
            SQL &= " UNION ALL"
            SQL &= " SELECT "
            SQL &= "    AccountNumber AS 'ID',"
            SQL &= "    CONCAT(Employee (Payee_ID), '[',AccountNumber,']') AS 'Employee',"
            SQL &= "    'L' AS 'Type',"
            SQL &= "    (SELECT Phone FROM employee_Setup WHERE ID = Payee_ID) AS 'Phone',"
            SQL &= "    (SELECT EmailAdd FROM employee_Setup WHERE ID = Payee_ID) AS 'EmailAdd',"
            SQL &= "    IFNULL((SELECT BankID FROM check_voucher WHERE Payee_ID = Liquidation_Main.CANumber AND `status` = 'ACTIVE' LIMIT 1),0) AS 'BankID',"
            SQL &= "    AccountNumber, ABS(AmountDue) - AmountAcknowledged AS 'Amount', CONCAT('[Cash Advance: ', CANumber,'][Check Voucher: ', (SELECT DocumentNumber FROM check_voucher WHERE Payee_ID = CANumber AND `status` = 'ACTIVE'), '][Liquidation: ', AccountNumber,']') AS 'Explanation', Payee_ID AS 'PayorID', IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = (SELECT position_ID FROM employee_setup WHERE ID = liquidation_main.Payee_ID)),0) AS 'Mortgage'"
            SQL &= " FROM liquidation_main"
            SQL &= String.Format("    WHERE AmountDue < 0 AND IF('{1}' = 'False',Liq_Status IN ('APPROVED','PARTIALLY ACKNOWLEDGED','ACKNOWLEDGED'),Liq_Status IN ('APPROVED','PARTIALLY ACKNOWLEDGED')) AND `status` = 'ACTIVE' AND Branch_ID = '{0}'", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxAR.Checked Then
            SQL &= " UNION ALL"
Here:
            If MultipleAR Then
                SQL = " SELECT "
            Else
                SQL &= " SELECT "
            End If
            SQL &= "    ID,"
            SQL &= "    CONCAT(Payor,' [', DocumentNumber,']') AS 'Employee',"
            SQL &= "    'AR' AS 'Type',"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    '' AS 'EmailAdd',"
            SQL &= "    BankID,"
            SQL &= "    DocumentNumber AS 'AccountNumber', Amount - Paid AS 'Amount', CONCAT('[Accounts Receivable: ', DocumentNumber,']') AS 'Explanation', PayorID, 0 AS 'Mortgage'"
            SQL &= " FROM accounts_receivable"
            SQL &= String.Format("    WHERE IF('{1}' = 'False',AR_Status IN ('APPROVED','PARTIALLY PAID','FULLY PAID'),AR_Status IN ('APPROVED','PARTIALLY PAID')) AND `status` = 'ACTIVE' AND NotAR = 0 AND Branch_ID = '{0}'", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxAP.Checked Then
            SQL &= " UNION ALL"
HereAP:
            If MultipleAR Then
                SQL = " SELECT "
            Else
                SQL &= " SELECT "
            End If
            SQL &= "    ID,"
            SQL &= "    CONCAT(Payee,' [', DocumentNumber,']') AS 'Employee',"
            SQL &= "    'AP' AS 'Type',"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    '' AS 'EmailAdd',"
            SQL &= "    BankID,"
            SQL &= "    DocumentNumber AS 'AccountNumber', Amount - Paid AS 'Amount', CONCAT('[Accounts Payable: ', DocumentNumber,']') AS 'Explanation', PayeeID, 0 AS 'Mortgage'"
            SQL &= " FROM accounts_payable"
            SQL &= String.Format("    WHERE IF('{1}' = 'False',AP_Status IN ('APPROVED','PARTIALLY PAID','FULLY PAID'),AP_Status IN ('APPROVED','PARTIALLY PAID')) AND `status` = 'ACTIVE' AND NotAP = 0 AND Branch_ID = '{0}'", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxDF.Checked Then
            SQL &= " UNION ALL"
HereV2:
            If MultipleAR Then
                SQL = " SELECT "
            Else
                SQL &= " SELECT "
            End If
            SQL &= "    ID,"
            SQL &= "    CONCAT(Payor,' [', DocumentNumber,']') AS 'Employee',"
            SQL &= "    'DF' AS 'Type',"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    '' AS 'EmailAdd',"
            SQL &= "    BankID,"
            SQL &= "    DocumentNumber AS 'AccountNumber', Amount - Paid AS 'Amount', CONCAT('[Due To: ', DocumentNumber,']') AS 'Explanation', PayorID, 0 AS 'Mortgage'"
            SQL &= " FROM due_from"
            SQL &= String.Format("    WHERE IF('{1}' = 'False',AR_Status IN ('APPROVED','PARTIALLY PAID','FULLY PAID'),AR_Status IN ('APPROVED','PARTIALLY PAID')) AND `status` = 'ACTIVE' AND NotAR = 0 AND Branch_ID = '{0}'", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxRO.Checked Then
            SQL &= " UNION ALL"
            SQL &= " SELECT "
            SQL &= "    S.AssetNumber AS 'ID',"
            SQL &= "    CONCAT(S.AssetNumber, ' - ', ROPOA_Buyer(S.AssetNumber)) AS 'Payee',"
            SQL &= "    'RO' AS 'Type',"
            SQL &= "    S.ReferenceN AS 'Phone',"
            SQL &= "    S.BankID AS 'EmailAdd'," 'Bank
            SQL &= "    BankID,"
            SQL &= "    Running_Balance(AssetNumber) AS 'ORNum'," 'ROPOA VALUE
            SQL &= "    S.Amount - IFNULL(A.Amount,0) AS 'Amount',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    S.ID AS 'Payee_ID',"
            SQL &= "    IF(SUBSTRING(S.AssetNumber,1,3) = 'ANV',1,2) AS 'Mortgage'"
            If cbxPayee.Enabled Then
                SQL &= String.Format(" FROM sold_ropoa S LEFT JOIN (SELECT SUM(Amount) AS 'Amount', SoldID, ReferenceN FROM accounting_entry WHERE MotherCode = '111000' AND EntryType = 'DEBIT' AND `status` IN ('ACTIVE','PENDING') AND JVNumber = '' GROUP BY SoldID) A ON  A.ReferenceN = S.AssetNumber AND A.SoldID = S.ID WHERE S.`status` = 'ACTIVE' AND S.Branch_ID = '{0}' AND S.Amount - IFNULL(A.Amount,0) > 0", Branch_ID)
            Else
                SQL &= String.Format(" FROM sold_ropoa S LEFT JOIN (SELECT SUM(Amount) AS 'Amount', SoldID, ReferenceN FROM accounting_entry WHERE MotherCode = '111000' AND EntryType = 'DEBIT' AND `status` IN ('ACTIVE','PENDING') AND JVNumber = '' GROUP BY SoldID) A ON  A.ReferenceN = S.AssetNumber AND A.SoldID = S.ID WHERE S.`status` = 'ACTIVE' AND S.Branch_ID = '{0}'", Branch_ID)
            End If
        End If
        If cbxITL.Checked Then
            SQL &= " UNION ALL"
HereV3:
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
        If cbxLA.Checked Then
            SQL &= " UNION ALL"
HereV6:
            SQL &= " SELECT "
            SQL &= "    CreditNumber AS 'ID' ,"
            SQL &= "    CONCAT('[ ', CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)), ' ] - ', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Employee',"
            SQL &= "    'LA' AS 'Type',"
            SQL &= "    Mobile_B AS 'Phone',"
            SQL &= "    Email_B AS 'EmailAdd',"
            SQL &= "    BankID,"
            If From_Check Then
                SQL &= "    BillDeductionsStatus AS 'AccountNumber',"
            Else
                SQL &= "    BillDeductionsStatus AS 'ORNum',"
            End If
            SQL &= "    BillDeductions AS 'Amount',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    ID AS 'Payee_ID',"
            SQL &= "    BusinessCenterCode(BusinessID) AS 'Mortgage'"
            SQL &= String.Format("    FROM credit_application WHERE `status` = 'ACTIVE' AND IF('{1}' != '' AND {2},CreditNumber = '{1}',TRUE) AND Branch_ID = '{0}'", Branch_ID, AssetNumber, From_Check)
        End If
        If cbxCAS.Checked Then
            SQL &= " UNION ALL"
            SQL &= " SELECT "
            SQL &= "    AccountNumber AS 'ID' ,"
            SQL &= "    CONCAT(Employee(Payee_ID), ' [', AccountNumber,']') AS 'Employee',"
            SQL &= "    'CAS' AS 'Type',"
            SQL &= "    (SELECT Phone FROM employee_setup WHERE ID = Payee_ID) AS 'Phone',"
            SQL &= "    (SELECT EmailAdd FROM employee_setup WHERE ID = Payee_ID) AS 'EmailAdd',"
            SQL &= "    0 AS 'BankID',"
            SQL &= "    '' AS 'ORNum',"
            SQL &= "    Meals + Transportation + BIR + RD + LTO + Notarization + Others AS 'Amount',"
            SQL &= "    CONCAT('[Return as Cash] for Cash Advance ', AccountNumber) AS 'Explanation',"
            SQL &= "    Payee_ID,"
            SQL &= "    IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = (SELECT position_ID FROM employee_setup WHERE ID = cash_advance.Payee_ID)),0) AS 'Mortgage'" 'GIGAMIT LANG PARA MA IDENTIFY AS HEAD
            SQL &= String.Format("    FROM cash_advance WHERE `status` = 'ACTIVE' AND slip_status = 'RECEIVED' AND Liquidated = 'N' AND Meals + Transportation + BIR + RD + LTO + Notarization + Others > 1000 AND IF({1} = TRUE, ACRNumber = '', TRUE) AND Branch_ID = '{0}'", Branch_ID, cbxPayee.Enabled)
        End If
HereV5:
        If From_ROPOA Then
            SQL = " SELECT "
            SQL &= "    AssetNumber AS 'ID',"
            SQL &= "    Borrower(AccountID) AS 'Employee',"
            SQL &= "    'VE' AS 'Type',"
            SQL &= "    (SELECT Mobile_B FROM profile_borrower WHERE profile_borrower.BorrowerID = AccountID) AS 'Phone',"
            SQL &= "    (SELECT Email_B FROM profile_borrower WHERE profile_borrower.BorrowerID = AccountID) AS 'EmailAdd',"
            SQL &= "    BankID,"
            SQL &= "    Running_Balance(AssetNumber) AS 'ORNum'," 'ROPOA VALUE
            SQL &= "    0 AS 'Amount',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    ID AS 'Payee_ID',"
            SQL &= "    1 AS 'Mortgage'"
            SQL &= String.Format(" FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND Sell_Status = 'SELL'", Branch_ID)

            SQL &= " UNION ALL"

            SQL &= " SELECT "
            SQL &= "    AssetNumber AS 'ID',"
            SQL &= "    Borrower(AccountID) AS 'Employee',"
            SQL &= "    (SELECT Mobile_B FROM profile_borrower WHERE profile_borrower.BorrowerID = AccountID) AS 'Phone',"
            SQL &= "    (SELECT Email_B FROM profile_borrower WHERE profile_borrower.BorrowerID = AccountID) AS 'EmailAdd',"
            SQL &= "    BankID AS 'EmailAdd'," 'Bank
            SQL &= "    BankID,"
            SQL &= "    Running_Balance(AssetNumber) AS 'ORNum'," 'ROPOA VALUE
            SQL &= "    0 AS 'Amount',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    ID AS 'Payee_ID',"
            SQL &= "    2 AS 'Mortgage'"
            SQL &= String.Format(" FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND Sell_Status = 'SELL'", Branch_ID)
        End If
        SQL &= " ORDER BY `Employee` ;"
        cbxPayee.DataSource = DataSource(SQL)
        If cbxPayee.Enabled And cbxLOE.Checked = False And cbxAP.Checked = False And cbxAR.Checked = False And cbxDF.Checked = False And cbxITL.Checked = False And cbxRO.Checked = False And cbxLA.Checked = False And cbxCAS.Checked = False Then
            cbxPayee.SelectedIndex = -1
        End If
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID,"
        SQL &= "    Payee_ID,"
        SQL &= "    Payee,"
        SQL &= "    (SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE ID = acknowledgement_receipt.BankID) AS 'Bank', BankID, "
        SQL &= "    DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date',"
        SQL &= "    ReferenceNumber AS 'Reference Number',"
        SQL &= "    Explanation,"
        SQL &= "    Amount,"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID, CheckedID, Type_Payment AS 'Type', CheckNumber, IFNULL(DATE_FORMAT(CheckDate,'%M %d, %Y'),'') AS 'CheckDate', DepositNumber, IFNULL(DATE_FORMAT(DepositDate,'%M %d, %Y'),'') AS 'DepositDate', IFNULL(DATE_FORMAT(ClearDate,'%M %d, %Y'),'') AS 'ClearDate', Payee_Type, MultipleAR, "
        SQL &= "    BRANCH(branch_id) AS 'Branch', User_EmplID, Branch_ID, IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(Voucher_Status = 'APPROVED' AND ClearDate != '','CLEARED',IF(Voucher_Status = 'APPROVED' AND DepositDate != '' AND Type_Payment = 'CHECK','FOR CLEARING',IF(Voucher_Status = 'APPROVED' AND DepositDate != '' AND Type_Payment = 'CASH','DEPOSITED',IF(JVNumber != '','REVERSED',IF(Voucher_Status='PENDING','FOR CHECKING',IF(Voucher_Status='CHECKED','FOR APPROVAL',IF(Voucher_Status='APPROVED','FOR DEPOSIT',Voucher_Status)))))))) AS 'Voucher_Status', Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', OTAC_Check, OTAC_Approve, Attach, JVNumber, PaidAmount, RunningBalance, Payable"
        SQL &= "  FROM acknowledgement_receipt WHERE"
        Dim ForChecking As Boolean
        Dim ForApproval As Boolean
        Dim ForDeposit As Boolean
        Dim Deposited As Boolean
        Dim ForClearing As Boolean
        Dim Cleared As Boolean
        Dim Cancelled As Boolean
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
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForChecking = False And ForApproval = False And ForDeposit = False And Deposited = False And ForClearing = False And Cleared = False Then
                If Cancelled Then
                    SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED') OR voucher_status = 'DISAPPROVED')"
                End If
            Else
                SQL &= " `status` IN ('ACTIVE','CANCELLED','DELETED','DISAPPROVED') AND (voucher_status = 'DISAPPROVED' "
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
                If ForChecking Or ForApproval Or ForDeposit Or ForClearing Or Cleared Then
                    SQL &= ")"
                End If
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
            GridColumn30.VisibleIndex = 12
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
            txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('ACR-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM acknowledgement_receipt WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))
        End If
    End Sub

#Region "Keydown"
    Private Sub CbxPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpPostingDate.Focus()
        ElseIf e.KeyCode = Keys.Delete Then
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            If drv("Type") = "B" Then
                If MsgBoxYes("Are you sure you want to remove this Payee from the list?") = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE acknowledgement_payee SET `status` = 'CANCELLED' WHERE ID = '{0}';", cbxPayee.SelectedValue))
                    MsgBox("Successfully Removed!", MsgBoxStyle.Information, "Info")
                    LoadPayee()
                End If
            End If
        End If
    End Sub

    Private Sub DtpPostingDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPostingDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReferenceNumber.Focus()
        End If
    End Sub

    Private Sub TxtReferenceNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxBank.Focus()
        End If
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
        If e.KeyCode = Keys.Enter Then
            dPaidAmount.Focus()
        End If
    End Sub

    Private Sub DPaidAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dPaidAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            rExplanation.Focus()
        End If
    End Sub

    Private Sub RExplanation_KeyDown(sender As Object, e As KeyEventArgs) Handles rExplanation.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCash.Focus()
        End If
    End Sub

    Private Sub CbxCash_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCash.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub CbxCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCheck.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCheckNumber.Focus()
        End If
    End Sub

    Private Sub TxtCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCheckNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpCheck.Focus()
        End If
    End Sub

    Private Sub DtpCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpCheck.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub CbxOnline_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOnline.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDeposit.Focus()
        End If
    End Sub

    Private Sub TxtDeposit_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDeposit.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDeposit.Focus()
        End If
    End Sub

    Private Sub DtpDeposit_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDeposit.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
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
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalCredit += CDbl(DT_Account(x)("Credit"))
            Next
            dCreditT.Value = TotalCredit
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
            .SetRowCellValue(.FocusedRowHandle, "Account Code", cbxAccount.SelectedValue)
            .SetRowCellValue(.FocusedRowHandle, "RequiredRemarks", drv("Remarks"))
            .SetRowCellValue(.FocusedRowHandle, "Type_ID", drv("Type_ID"))
            .SetRowCellValue(.FocusedRowHandle, "MotherCode", drv("MotherCode"))
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
                    e.Appearance.ForeColor = Color.Red
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Voucher_Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Or Status = "REVERSED" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            End If
        End If
    End Sub

    Private Sub BtnAdd_Account_Click(sender As Object, e As EventArgs) Handles btnAdd_Account.Click
        btnRemove_Account.Enabled = True
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
            Row("Remarks") = ""
            Row("RequiredRemarks") = ""
            Row("BusinessCode") = ""
            Row("Type_ID") = 0
            Row("MotherCode") = ""
            DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
        Else
            If drv("Type") = "LA" Then
                Row("Account Code") = ""
                Row("Department Code") = ""
                Row("Account") = ""
                Row("Business Center") = DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("Mortgage")))
                Row("Department") = ""
                Row("Debit") = 0
                Row("Credit") = 0
                Row("Remarks") = ""
                Row("RequiredRemarks") = ""
                Row("BusinessCode") = drv("Mortgage")
                Row("Type_ID") = 0
                Row("MotherCode") = ""
                DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
            ElseIf (drv("Type") = "AP" Or drv("Type") = "APM") And MultipleAR Then
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
                Row("BusinessCode") = ""
                Row("Type_ID") = 0
                Row("MotherCode") = ""
                DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
            Else
                Row("Account Code") = ""
                Row("Department Code") = ""
                Row("Account") = ""
                Row("Business Center") = ""
                Row("Department") = ""
                Row("Debit") = 0
                Row("Credit") = 0
                Row("Remarks") = ""
                Row("RequiredRemarks") = ""
                Row("BusinessCode") = ""
                Row("Type_ID") = 0
                Row("MotherCode") = ""
                DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
            End If
        End If

        Dim TotalDebit As Double
        Dim TotalCredit As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
        Next
        If GridView2.RowCount > 5 Then
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342 - 17
            Else
                GridColumn32.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342
            Else
                GridColumn32.Width = (342 - 80)
            End If
        End If
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
    End Sub

    Private Sub BtnRemove_Account_Click(sender As Object, e As EventArgs) Handles btnRemove_Account.Click
        If DT_Account.Rows.Count = 0 Or GridView2.RowCount = 0 Then
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
        If GridView2.RowCount > 5 Then
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342 - 17
            Else
                GridColumn32.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342
            Else
                GridColumn32.Width = (342 - 80)
            End If
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
            If btnSave.Enabled And If(GridView2.RowCount > 0, GridView2.GetRowCellValue(0, "Account").ToString.Length > 0 Or GridView2.GetRowCellValue(0, "Remarks").ToString.Length > 0, 0) Then
            Else
                Clear(False)
                LoadPayee()
            End If
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnAttach.Visible = True
            btnPrint.Enabled = True
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
                Clear(False)

                LoadPayee()
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Public Sub Clear(TriggerLoadData As Boolean)
        TotalDeductions = 0
        dPaidAmount.Value = 0
        dRunningBalance.Value = 0
        dPayable.Value = 0
        dPaidAmount.Enabled = True
        CopyMode = False
        btnSave.Text = "&Save"
        MultipleAR = False
        PanelEx10.Enabled = True
        PanelEx2.Enabled = True
        GridView2.OptionsBehavior.Editable = True
        cbxPayee.Enabled = True
        cbxLOE.Enabled = True
        cbxAR.Enabled = True
        cbxAP.Enabled = True
        cbxDF.Enabled = True
        cbxITL.Enabled = True
        cbxRO.Enabled = True
        cbxLA.Enabled = True
        cbxCAS.Enabled = True
        btnLedger.Visible = False

        FirstLoad = True
        cbxLOE.Checked = False
        cbxAR.Checked = False
        cbxAP.Checked = False
        cbxDF.Checked = False
        cbxITL.Checked = False
        cbxRO.Checked = False
        cbxLA.Checked = False
        cbxCAS.Checked = False
        FirstLoad = False

        btnAdd_Account.Enabled = True
        btnRemove_Account.Enabled = True
        cbxCash.Checked = True
        dtpPostingDate.Value = Date.Now
        dtpDocument.Value = Date.Now
        rExplanation.Text = ""
        txtReferenceNumber.Text = ""
        dAmount.Value = 0
        If cbxBank.Enabled Then
            cbxBank.SelectedIndex = -1
        End If
        cbxPayee.SelectedIndex = -1
        cbxPreparedBy.SelectedValue = Empl_ID
        Dim SQL As String = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'PaidFor'"
        DT_Account = DataSource(SQL)
        GridControl2.DataSource = DT_Account
        dDebitT.Value = 0
        dCreditT.Value = 0
        If GridView2.RowCount > 5 Then
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342 - 17
            Else
                GridColumn32.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342
            Else
                GridColumn32.Width = (342 - 80)
            End If
        End If

        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnCheck.Visible = False
        btnApprove.Visible = False

        cbxPreparedBy.SelectedValue = Empl_ID
        txtChecked.Text = ""
        txtApproved.Text = ""
        btnDisapprove.Visible = False
        GetDocumentNumber()
        If TriggerLoadData Then
            LoadData()
        End If
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

            Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
            If cbxPayee.Text.Trim = "" Then
                MsgBox("Please select/fill Payor.", MsgBoxStyle.Information, "Info")
                cbxPayee.DroppedDown = True
                Exit Sub
            ElseIf cbxPayee.SelectedIndex = -1 Then
                If MsgBoxYes(String.Format("{0} is not yet register, would you like to automatically register {0} for Acknowledgement?", cbxPayee.Text)) = MsgBoxResult.Yes Then
                    Dim SQL_II As String = "INSERT INTO acknowledgement_payee SET"
                    SQL_II &= String.Format(" Payee = '{0}', ", cbxPayee.Text.Trim.InsertQuote)
                    SQL_II &= String.Format(" Empl_ID = '{0}';", Empl_ID)
                    DataObject(SQL_II)
                    Dim OldPayee As String = cbxPayee.Text
                    MsgBox(String.Format("{0} is now registered for Acknowledgement.", cbxPayee.Text), MsgBoxStyle.Information, "Info")
                    FirstLoad = True
                    LoadPayee()
                    cbxPayee.Text = OldPayee
                    FirstLoad = False
                Else
                    Exit Sub
                End If
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
            If rExplanation.Text.Trim = "" Then
                MsgBox("Please fill explanation.", MsgBoxStyle.Information, "Info")
                rExplanation.Focus()
                Exit Sub
            End If
            If GridView2.RowCount = 0 Then
                MsgBox("Please add Debit and Credit.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            If cbxCheck.Checked And cbxCheckNumber.Text.Trim = "" Then
                MsgBox("Please select or fill check number.", MsgBoxStyle.Information, "Info")
                cbxCheckNumber.Focus()
                Exit Sub
            End If
            Dim TheSameCashInBank As Boolean
            Dim CashInBankExist As Boolean
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                If (CDbl(DT_Account(x)("Debit")) > 0 And CDbl(DT_Account(x)("Credit")) > 0) Or (DT_Account(x)("Account") = "" And (CDbl(DT_Account(x)("Debit")) > 0 Or CDbl(DT_Account(x)("Credit")) > 0)) Or (DT_Account(x)("RequiredRemarks").ToString = "True" And DT_Account(x)("Remarks") = "") Or (DT_Account(x)("Account") <> "" And DT_Account(x)("Department") = "") Then
                    MsgBox("Please check your data under row " & x + 1, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If DT_Account(x)("Type_ID") = 5 Then
                    Dim Budget As Double = DataObject(String.Format("SELECT IF('{0}' = '01' OR '{0}' = '07',M01,IF('{0}' = '02' OR '{0}' = '08',M02,IF('{0}' = '03' OR '{0}' = '09',M03,IF('{0}' = '04' OR '{0}' = '10',M04,IF('{0}' = '05' OR '{0}' = '11',M05,IF('{0}' = '06' OR '{0}' = '12',M06,0)))))) FROM financial_plan WHERE AccountCode = '{1}' AND `Year` = YEAR('{2}') AND BranchID = '{3}' AND IF('{0}' > '06',Half = 2,Half=1);", Format(dtpPostingDate.Value, "MM"), DT_Account(x)("Account Code"), FormatDatePicker(dtpPostingDate), Branch_ID))
                    If Budget > 0 Then
                        Dim Used As Double = DataObject(String.Format("SELECT IFNULL(SUM(Amount),0) FROM accounting_entry WHERE AccountCode = '{0}' AND MONTH(ORDate) = MONTH('{1}') AND YEAR(ORDate) = YEAR('{1}') AND `status` = 'ACTIVE' AND EntryType = 'DEBIT' AND Branch_ID = '{2}';", DT_Account(x)("Account Code"), FormatDatePicker(dtpPostingDate), Branch_ID))
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
            If dAmount.Value = 0 Then
                MsgBox("No Cash In Bank for Debit, please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If drv("Type") = "L" And btnSave.Text = "&Save" Then
                If dDebitT.Value <> DataObject(String.Format("SELECT ABS(AmountDue) - AmountAcknowledged FROM liquidation_main WHERE AccountNumber = '{0}';", drv("AccountNumber"))) Then
                    If MsgBoxYes("Due Amount is not equal to Total Amount. Are you sure that you correctly filled the right amount?") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
            If drv("Type") = "CAS" Then ' FROM CASH ADVANCE
                If CDec(drv("Amount")) <> dDebitT.Value Then
                    MsgBox("Cash Advance amount is not equal with total Debit, please check your data.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
            If drv("Type") = "LA" And drv("Amount") = 1 And (drv("AccountNumber") = "PENDING" Or drv("AccountNumber") = "PARTIAL") Then ' FROM CREDIT APPLICATION WITH DEDUCTIBLE
                If TotalDeductions > dDebitT.Value Then
                    If MsgBox("Total Deductable is greater than the paid amount, would you like to proceed?.", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
            If From_Check Then
                If dPaidAmount.Value <> dAmount.Value Then
                    MsgBox("Check Amount is not equal with total debit.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If

            Dim Open As String
            Open = DataObject(String.Format("SELECT IF('{2}' = 'Jan',Jan,IF('{2}' = 'Feb',Feb,IF('{2}' = 'Mar',Mar,IF('{2}' = 'Apr',Apr,IF('{2}' = 'May',May,IF('{2}' = 'Jun',Jun,IF('{2}' = 'Jul',Jul,IF('{2}' = 'Aug',Aug,IF('{2}' = 'Sep',Sep,IF('{2}' = 'Oct',`Oct`,IF('{2}' = 'Nov',Nov,IF('{2}' = 'Dec',`Dec`,'X')))))))))))) FROM accounting_period WHERE Branch = '{0}' AND `status` = 'ACTIVE' AND `Year` = '{1}';", Branch_Code, Format(dtpPostingDate.Value, "yyyy"), Format(dtpPostingDate.Value, "MMM")))
            If If(Open = "", "Open", Open) = "Open" Then
            Else
                MsgBox(String.Format("Accounting Period for your branch is already {0}. Transaction with this date is not allowed.", If(Open = "Lock", "Locked", If(Open = "Close", "Closed", Open))), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If btnSave.Text = "&Save" Then
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Code = GenerateOTAC()
                    '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                    If Auto_Notification Then
                        CheckNotification(Code, False)
                    End If
                    '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                    GetDocumentNumber()
                    If DocumentNumberExist("acknowledgement_receipt", txtDocumentNumber.Text) Then
                        Exit Sub
                    End If
                    Dim SQL As String = "INSERT INTO acknowledgement_receipt SET"
                    SQL &= String.Format(" Payee_ID = '{0}', ", cbxPayee.SelectedValue)
                    SQL &= String.Format(" Payee_Type = '{0}', ", If(cbxPayee.SelectedIndex = -1, "", drv("Type")) & If(MultipleAR, "M", ""))
                    SQL &= String.Format(" Payee = '{0}', ", cbxPayee.Text.InsertQuote)
                    SQL &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                    SQL &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote)
                    SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                    SQL &= " CheckedID = '0', "
                    SQL &= " ApprovedID = '0', "
                    SQL &= " OTAC_Approve = '', "
                    If MultipleAR Then
                        SQL &= String.Format(" MultipleAR = '{0}', ", AccountsReceivableID_M.ToString.InsertQuote)
                    End If
                    SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                    SQL &= String.Format(" Type_Payment = '{0}', ", If(cbxCash.Checked, "CASH", If(cbxCheck.Checked, "CHECK", If(cbxOnline.Checked, "ONLINE", "NA"))))
                    SQL &= String.Format(" CheckNumber = '{0}', ", cbxCheckNumber.Text)
                    SQL &= String.Format(" CheckDate = '{0}', ", FormatDatePicker(dtpCheck))
                    SQL &= String.Format(" DepositNumber = '{0}', ", txtDeposit.Text)
                    SQL &= String.Format(" DepositDate = '{0}', ", FormatDatePicker(dtpDeposit))
                    SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                    SQL &= String.Format(" PaidAmount = '{0}', ", dPaidAmount.Value)
                    SQL &= String.Format(" RunningBalance = '{0}', ", dRunningBalance.Value)
                    SQL &= String.Format(" Payable = '{0}', ", dPayable.Value)
                    SQL &= String.Format(" CheckID = '{0}', ", CheckID)
                    If drv("Type") = "RO" Then ' FROM ROPOA
                        SQL &= String.Format(" PlateNum = '{0}', ", drv("Phone"))
                    ElseIf drv("Type") = "LA" And drv("Amount") = 1 And (drv("AccountNumber") = "PENDING" Or drv("AccountNumber") = "PARTIAL") Then ' FROM CREDIT APPLICATION WITH BILL DEDUCTABLES
                        SQL &= "PlateNum = 'BILL DEDUCT',"
                    End If
                    SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                    If drv("Type") = "L" Then ' FROM LIQUIDATION
                        SQL &= String.Format("UPDATE liquidation_main SET Liq_Status = IF(ABS(AmountDue) <= (AmountAcknowledged + {1}),'ACKNOWLEDGED','PARTIALLY ACKNOWLEDGED'), AmountAcknowledged = AmountAcknowledged + {1} WHERE  AccountNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                    End If
                    If drv("Type") = "CAS" Then ' FROM CASH ADVANCE
                        SQL &= String.Format("UPDATE cash_advance SET ACRNumber = '{1}' WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue, txtDocumentNumber.Text)
                    End If
                    If drv("Type") = "LA" And drv("Amount") = 1 And (drv("AccountNumber") = "PENDING" Or drv("AccountNumber") = "PARTIAL") Then ' FROM CREDIT APPLICATION WITH BILL DEDUCTABLES
                        SQL &= String.Format("UPDATE credit_application SET BillDeductionsStatus = 'PAID' WHERE CreditNumber = '{0}';", cbxPayee.SelectedValue)
                    End If
                    If drv("Type") = "AR" Then 'FROM ACCOUNTS RECEIVABLE
                        If MultipleAR Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount - Paid AS 'Payable' FROM accounts_receivable WHERE DocumentNumber IN ({0});", AccountsReceivableID_M))
                            For x As Integer = 0 To vDT.Rows.Count - 1
                                If TotalPayment - CDbl(vDT(x)("Payable")) = 0 Then
                                    SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment)
                                    Exit For
                                ElseIf TotalPayment - CDbl(vDT(x)("Payable")) > 0 Then
                                    SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Payable")))
                                    TotalPayment -= CDbl(vDT(x)("Payable"))
                                Else
                                    SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment)
                                    Exit For
                                End If
                            Next
                        Else
                            SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                        End If
                    End If
                    If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "AP" Then 'FROM ACCOUNTS PAYABLE
                        If MultipleAR Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount - Paid AS 'Payable' FROM accounts_payable WHERE DocumentNumber IN ({0});", AccountsReceivableID_M))
                            For x As Integer = 0 To vDT.Rows.Count - 1
                                If TotalPayment - CDbl(vDT(x)("Payable")) = 0 Then
                                    SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment)
                                    Exit For
                                ElseIf TotalPayment - CDbl(vDT(x)("Payable")) > 0 Then
                                    SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Payable")))
                                    TotalPayment -= CDbl(vDT(x)("Payable"))
                                Else
                                    SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment)
                                    Exit For
                                End If
                            Next
                        Else
                            SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                        End If
                    End If
                    If drv("Type") = "DF" And If(From_Check, DFPayPrincipal, 1) Then 'FROM DUE FROM
                        If MultipleAR Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount - Paid AS 'Payable' FROM due_from WHERE DocumentNumber IN ({0});", AccountsReceivableID_M))
                            For x As Integer = 0 To vDT.Rows.Count - 1
                                If TotalPayment - CDbl(vDT(x)("Payable")) = 0 Then
                                    SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment)
                                    Exit For
                                ElseIf TotalPayment - CDbl(vDT(x)("Payable")) > 0 Then
                                    SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Payable")))
                                    TotalPayment -= CDbl(vDT(x)("Payable"))
                                Else
                                    SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment)
                                    Exit For
                                End If
                            Next
                        Else
                            SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                        End If
                    End If
                    If drv("Type") = "RO" Then 'FROM ROPOA
                        Dim TotalPayments As Double = DataObject(String.Format("SELECT ROPOA_Payment('{0}','{1}');", cbxPayee.SelectedValue, drv("PayorID"))) + dPaidAmount.Value
                        Dim SoldAmount As Double = DataObject(String.Format("SELECT Amount FROM sold_ropoa WHERE ID = '{0}';", drv("PayorID")))
                        If cbxPayee.SelectedValue.ToString.Contains("ANV") Then
                            SQL &= String.Format(" UPDATE ropoa_vehicle SET sell_status = '{1}' WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", drv("Phone"), If(dPaidAmount.Value >= dPayable.Value, "SOLD", If(SoldAmount * 0.8 <= TotalPayments, "SOLD", "RESERVED")))
                        Else
                            SQL &= String.Format(" UPDATE ropoa_realestate SET sell_status = '{1}' WHERE TCT = '{0}' AND `status` = 'ACTIVE';", drv("Phone"), If(dPaidAmount.Value >= dPayable.Value, "SOLD", If(SoldAmount * 0.8 <= TotalPayments, "SOLD", "RESERVED")))
                        End If
                    End If
                    For x As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SQL &= "INSERT INTO acr_details SET"
                            SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQL &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            If MultipleAR Then
                                SQL &= String.Format(" ReferenceN = '{0}', ", GridView2.GetRowCellValue(x, "ReferenceN"))
                            End If
                            SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                            SQL &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)

                            If drv("Type") = "AR" Or drv("Type") = "DF" Then 'FROM ACCOUNTS RECEIVABLE
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                                Dim SQLv2 As String = ""
                                If If(GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") And drv("Type") = "RO" And CDbl(GridView2.GetRowCellValue(x, "Debit")) > 0, False, GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable")) Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                    Dim APNumber As String
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
                                ElseIf If(GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") And drv("Type") = "RO" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0, False, GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable")) Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                    Dim APNumber As String
                                    Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                    If drv("Type") = "DF" Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('AR-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_receivable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= " INSERT INTO accounts_receivable SET"
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
                                        SQLv2 &= " CheckedID = '0', "
                                        SQLv2 &= " ApprovedID = '0', "
                                        SQLv2 &= " OTAC_Approve = '', "
                                        SQLv2 &= String.Format(" OTAC_Check = '{0}', ", Code)
                                        SQLv2 &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                                        SQLv2 &= String.Format(" JVNumberV2 = '{0}', ", txtDocumentNumber.Text)
                                        SQLv2 &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                                        SQLv2 &= "INSERT INTO ar_details SET"
                                        SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                        SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                        SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                        SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                        SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                        SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                        SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                    ElseIf drv("Type") = "AR" Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('DF-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_from WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

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
                                End If
                                If SQLv2 = "" Then
                                Else
                                    DataObject(SQLv2)
                                End If
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                            Else
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                                Dim SQLv2 As String = ""
                                If If(GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") And drv("Type") = "RO" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0, False, GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable")) Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                    Dim ARNumber As String
                                    Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))

                                    If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                        ARNumber = DataObject(String.Format("SELECT CONCAT('DF-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_from WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= " INSERT INTO due_from SET"
                                    Else
                                        ARNumber = DataObject(String.Format("SELECT CONCAT('AR-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_receivable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= " INSERT INTO accounts_receivable SET"
                                    End If
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
                                    SQLv2 &= String.Format(" DocumentNumber = '{0}', ", ARNumber)
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

                                    If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                        SQLv2 &= "INSERT INTO df_details SET"
                                    Else
                                        SQLv2 &= "INSERT INTO ar_details SET"
                                    End If
                                    SQLv2 &= String.Format(" DocumentNumber = '{0}', ", ARNumber)
                                    SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                    SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                    SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                    SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                    SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                    SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                ElseIf If(GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") And drv("Type") = "RO" And CDbl(GridView2.GetRowCellValue(x, "Debit")) > 0, False, GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable")) Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                    Dim APNumber As String
                                    Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))

                                    If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('DT-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_to WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= "INSERT INTO due_to SET"
                                    Else
                                        APNumber = DataObject(String.Format("SELECT CONCAT('AP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= "INSERT INTO accounts_payable SET"
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

                                    SQLv2 &= "INSERT INTO loans_payable SET"
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
                                End If
                                If SQLv2 = "" Then
                                Else
                                    DataObject(SQLv2)
                                End If
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                            End If
                        End If
                    Next
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        If GridView2.GetRowCellValue(x, "Account").ToString = "" Then
                        Else
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
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
                            If drv("Type") = "AR" Then 'FROM ACCOUNTS RECEIVABLE
                                If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                    SQL &= String.Format(" PaidFor = '{0}', ", "Acknowledgement")
                                Else
                                    SQL &= String.Format(" PaidFor = '{0}', ", "Billing")
                                End If
                                SQL &= String.Format(" ReferenceN = '{0}', ", drv("PayorID"))
                                SQL &= String.Format(" Remarks = '{0}', ", rExplanation.Text.InsertQuote)
                            Else
                                If drv("Type") = "LA" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 Then 'FROM LOANS APPLICATION
                                    If GridView2.GetRowCellValue(x, "PaidFor").ToString = "" Then
                                        SQL &= " PaidFor = 'Billing', "
                                    Else
                                        SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                                    End If
                                Else
                                    If GridView2.GetRowCellValue(x, "PaidFor").ToString = "" Then
                                        SQL &= String.Format(" PaidFor = '{0}', ", "Acknowledgement")
                                    Else
                                        SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                                    End If
                                End If
                                SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                                If drv("Type") = "RO" Then
                                    SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks") & " [" & If(cbxCash.Checked, "Cash Payment", If(cbxCheck.Checked, "Check Payment " & cbxCheckNumber.Text, "Online Payment " & txtDeposit.Text)) & "] [" & If(dPaidAmount.Value < dPayable.Value, "Partial", "Full") & "]")
                                Else
                                    SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                End If
                            End If
                            SQL &= " `Status` = 'PENDING',"
                            SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            If drv("Type") = "RO" Then ' FROM ROPOA
                                SQL &= String.Format(" PlateNum = '{0}', ", drv("Phone"))
                                SQL &= String.Format(" SoldID = '{0}', ", drv("PayorID"))
                            End If
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                    Next
                    'ACCOUNTING ENTRY ***********************************************************************************************************

                    If From_Check And CheckID > 0 Then
                        If FromDueFrom Or From_PDC_Others Then
                            SQL &= String.Format("UPDATE dc_details SET `check_status` = 'CLEARED', Remarks = CONCAT(Remarks, ' [', 'CLEARED CHECK',']') WHERE ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID)
                        Else
                            If cbxCheck.Checked Then
                                SQL &= String.Format("UPDATE check_received SET `status` = 'CLEARED', remarks = CONCAT(remarks, ' [', 'Cleared Check',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID)
                            ElseIf cbxCash.Checked Then
                                If dAmount.Value >= 0 Then
                                    SQL &= String.Format("UPDATE check_received SET `status` = 'PAID', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dAmount.Text & " Cash", "Paid " & dAmount.Text & " Cash"))
                                Else
                                    SQL &= String.Format("UPDATE check_received SET `status` = 'PARTIAL', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dAmount.Text & " Cash", "Paid " & dAmount.Text & " Cash"))
                                End If
                            ElseIf cbxOnline.Checked Then
                                If dAmount.Value >= 0 Then
                                    SQL &= String.Format("UPDATE check_received SET `status` = 'PAID', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dAmount.Text & " Online", "Paid " & dAmount.Text & " Online"))
                                Else
                                    SQL &= String.Format("UPDATE check_received SET `status` = 'PARTIAL', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dAmount.Text & " Online", "Paid " & dAmount.Text & " Online"))
                                End If
                            End If
                        End If
                    ElseIf cbxCheck.Checked Then
                        SQL &= String.Format("UPDATE check_received SET `status` = 'CLEARED', remarks = CONCAT(remarks, ' [', 'Cleared Check',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND `Date` = '{2}' AND `status` NOT IN ('PENDING','CANCELLED','DELETED');", cbxPayee.SelectedValue, cbxCheckNumber.Text.Trim, Format(dtpCheck.Value, "yyyy-MM-dd"))
                    End If
                    DataObject(SQL)

                    Cursor = Cursors.Default
                    Logs("Acknowledgement Receipt", "Save", String.Format("Add new Acknowledgement Receipt for {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")
                    If FromAccountsReceivable Or From_Check Or FromDueFrom Or From_ITL Or From_PDC_Others Or From_ROPOA Or From_CashAdvance Then
                        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.PerformClick()
                    Else
                        LoadPayee()
                        Clear(True)
                        MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                    End If
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM acknowledgement_receipt WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
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

                    Dim SQL As String = "UPDATE acknowledgement_receipt SET"
                    SQL &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote)
                    SQL &= String.Format(" Type_Payment = '{0}', ", If(cbxCash.Checked, "CASH", If(cbxCheck.Checked, "CHECK", If(cbxOnline.Checked, "ONLINE", "NA"))))
                    SQL &= String.Format(" CheckNumber = '{0}', ", cbxCheckNumber.Text)
                    SQL &= String.Format(" CheckDate = '{0}', ", FormatDatePicker(dtpCheck))
                    SQL &= String.Format(" DepositNumber = '{0}', ", txtDeposit.Text)
                    If drv("Type") = "RO" Then ' FROM ROPOA
                        SQL &= String.Format(" PlateNum = '{0}', ", drv("Phone"))
                    End If
                    If txtChecked.Text = "" Then
                        SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                    ElseIf txtApproved.Text = "" Then
                        SQL &= String.Format(" OTAC_Approve = '{0}', ", Code)
                    End If
                    SQL &= String.Format(" DepositDate = '{0}' ", FormatDatePicker(dtpDeposit))
                    SQL &= String.Format(" WHERE ID = '{0}';", ID)
                    Dim SQLv3 As String = String.Format(" UPDATE accounts_receivable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE accounts_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE due_from SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE due_to SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE loans_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    DataObject(SQLv3)
                    SQL &= String.Format("UPDATE acr_details SET `status` = 'CANCELLED' WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    For x As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(x, "Account").ToString = "" Then
                        Else
                            SQL &= "INSERT INTO acr_details SET"
                            SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQL &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            If MultipleAR Then
                                SQL &= String.Format(" ReferenceN = '{0}', ", GridView2.GetRowCellValue(x, "ReferenceN"))
                            End If
                            SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                            SQL &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)

                            If drv("Type") = "AR" Or drv("Type") = "DF" Then 'FROM ACCOUNTS RECEIVABLE
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                                Dim SQLv2 As String = ""
                                If If(GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") And drv("Type") = "RO" And CDbl(GridView2.GetRowCellValue(x, "Debit")) > 0, False, GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable")) Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                    Dim APNumber As String
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

                                    SQLv2 &= "INSERT INTO lp_details SET"
                                    SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                    SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                    SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                    SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                    SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                    SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                    SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                ElseIf If(GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") And drv("Type") = "RO" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0, False, GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable")) Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                    Dim APNumber As String
                                    Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                    If drv("Type") = "DF" Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('AR-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_receivable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= " INSERT INTO accounts_receivable SET"

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

                                        SQLv2 &= "INSERT INTO ar_details SET"
                                        SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                        SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                        SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                        SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                        SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                        SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                        SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                    ElseIf drv("Type") = "AR" Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('DF-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_from WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

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
                                End If
                                If SQLv2 = "" Then
                                Else
                                    DataObject(SQLv2)
                                End If
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                            Else
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                                Dim SQLv2 As String = ""
                                If If(GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") And drv("Type") = "RO" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0, False, GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable")) Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                    Dim ARNumber As String
                                    Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))

                                    If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                        ARNumber = DataObject(String.Format("SELECT CONCAT('DF-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_from WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= " INSERT INTO due_from SET"
                                    Else
                                        ARNumber = DataObject(String.Format("SELECT CONCAT('AR-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_receivable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= " INSERT INTO accounts_receivable SET"
                                    End If
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
                                    SQLv2 &= String.Format(" DocumentNumber = '{0}', ", ARNumber)
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

                                    If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                                        SQLv2 &= "INSERT INTO df_details SET"
                                    Else
                                        SQLv2 &= "INSERT INTO ar_details SET"
                                    End If
                                    SQLv2 &= String.Format(" DocumentNumber = '{0}', ", ARNumber)
                                    SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                    SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                    SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                    SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                    SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                    SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                ElseIf If(GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") And drv("Type") = "RO" And CDbl(GridView2.GetRowCellValue(x, "Debit")) > 0, False, GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable")) Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                    Dim APNumber As String
                                    Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))

                                    If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('DT-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_to WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= "INSERT INTO due_to SET"
                                    Else
                                        APNumber = DataObject(String.Format("SELECT CONCAT('AP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= "INSERT INTO accounts_payable SET"
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

                                    SQLv2 &= "INSERT INTO loans_payable SET"
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

                                    SQLv2 &= "INSERT INTO lp_details SET"
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
                        End If
                    Next
                    If drv("Type") = "L" Then 'FROM LIQUIDATION
                        SQL &= String.Format(" UPDATE liquidation_main SET Liq_Status = IF(ABS(AmountDue) <= (IF((AmountAcknowledged - {2}) <= 0,0,(AmountAcknowledged - {2})) + {1}),'ACKNOWLEDGED','PARTIALLY ACKNOWLEDGED'), AmountAcknowledged = IF((AmountAcknowledged - {2}) <= 0,0,(AmountAcknowledged - {2})) + {1} WHERE AccountNumber = '{0}';", drv("AccountNumber"), dDebitT.Value, dDebitT.Tag)
                    End If
                    If drv("Type") = "AR" Then 'FROM ACCOUNTS PAYABLE
                        If MultipleAR Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim AcknowledgedAmount As Double
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount, Paid, IFNULL((SELECT SUM(Amount) FROM acknowledgement_receipt WHERE Payee_ID = accounts_receivable.ID AND DocumentNumber != '{1}' AND Payee_Type = 'AR' AND `status` = 'ACTIVE'),0) AS 'Other Payment', (SELECT SUM(Debit) FROM acr_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_receivable.DocumentNumber AND `status` = 'ACTIVE') AS 'Acknowledged' FROM accounts_receivable WHERE DocumentNumber IN ({0});", AccountsReceivableID_M, txtDocumentNumber.Text))
                            For x As Integer = 0 To vDT.Rows.Count - 1
                                AcknowledgedAmount = CDbl(vDT(x)("Acknowledged"))
                                If (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = CDbl(vDT(x)("Paid")) And CDbl(vDT(x)("Paid")) >= CDbl(vDT(x)("Acknowledged")) Then
                                    AcknowledgedAmount = CDbl(vDT(x)("Paid"))
                                End If
                                If TotalPayment - (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = 0 Then
                                    SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))), AcknowledgedAmount)
                                    TotalPayment -= TotalPayment
                                ElseIf TotalPayment - CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment")) > 0 Then
                                    SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))), AcknowledgedAmount)
                                    TotalPayment -= (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment")))
                                Else
                                    If TotalPayment <= 0 Then
                                        SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = 'APPROVED', Paid = 0 WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"))
                                    Else
                                        SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment, AcknowledgedAmount)
                                        TotalPayment -= TotalPayment
                                    End If
                                End If
                            Next
                        Else
                            SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value, dDebitT.Tag)
                        End If
                    End If
                    If drv("Type") = "AP" Then 'FROM ACCOUNTS PAYABLE
                        If MultipleAR Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim AcknowledgedAmount As Double
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount, Paid, IFNULL((SELECT SUM(Amount) FROM check_voucher WHERE Payee_ID = accounts_payable.DocumentNumber AND DocumentNumber != '{1}' AND Payee_Type = 'AP' AND `status` = 'ACTIVE'),0) AS 'Other Payment', (SELECT SUM(Amount) FROM cv_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_payable.DocumentNumber AND `status` = 'ACTIVE' AND Type = 'C') AS 'Acknowledged' FROM accounts_payable WHERE DocumentNumber IN ({0});", AccountsReceivableID_M, txtDocumentNumber.Text))
                            For x As Integer = 0 To vDT.Rows.Count - 1
                                AcknowledgedAmount = CDbl(vDT(x)("Acknowledged"))
                                If (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = CDbl(vDT(x)("Paid")) And CDbl(vDT(x)("Paid")) >= CDbl(vDT(x)("Acknowledged")) Then
                                    AcknowledgedAmount = CDbl(vDT(x)("Paid"))
                                End If
                                If TotalPayment - (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = 0 Then
                                    SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))), AcknowledgedAmount)
                                    TotalPayment -= TotalPayment
                                ElseIf TotalPayment - CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment")) > 0 Then
                                    SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))), AcknowledgedAmount)
                                    TotalPayment -= (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment")))
                                Else
                                    If TotalPayment <= 0 Then
                                        SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = 'APPROVED', Paid = 0 WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"))
                                    Else
                                        SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment, AcknowledgedAmount)
                                        TotalPayment -= TotalPayment
                                    End If
                                End If
                            Next
                        Else
                            SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value, dDebitT.Tag)
                        End If
                    End If
                    If drv("Type") = "DF" And If(From_Check, DFPayPrincipal, 1) Then 'FROM DUE FROM
                        If MultipleAR Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim AcknowledgedAmount As Double
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount, Paid, IFNULL((SELECT SUM(Amount) FROM acknowledgement_receipt WHERE Payee_ID = due_from.ID AND DocumentNumber != '{1}' AND Payee_Type = 'DF' AND `status` = 'ACTIVE'),0) AS 'Other Payment', (SELECT SUM(Debit) FROM acr_details WHERE DocumentNumber = '{1}' AND ReferenceN = due_from.DocumentNumber AND `status` = 'ACTIVE') AS 'Acknowledged' FROM due_from WHERE DocumentNumber IN ({0});", AccountsReceivableID_M, txtDocumentNumber.Text))
                            For x As Integer = 0 To vDT.Rows.Count - 1
                                AcknowledgedAmount = CDbl(vDT(x)("Acknowledged"))
                                If (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = CDbl(vDT(x)("Paid")) And CDbl(vDT(x)("Paid")) >= CDbl(vDT(x)("Acknowledged")) Then
                                    AcknowledgedAmount = CDbl(vDT(x)("Paid"))
                                End If
                                If TotalPayment - (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = 0 Then
                                    SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))), AcknowledgedAmount)
                                    TotalPayment -= TotalPayment
                                ElseIf TotalPayment - CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment")) > 0 Then
                                    SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))), AcknowledgedAmount)
                                    TotalPayment -= (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment")))
                                Else
                                    If TotalPayment <= 0 Then
                                        SQL &= String.Format(" UPDATE due_from SET AR_Status = 'APPROVED', Paid = 0 WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"))
                                    Else
                                        SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment, AcknowledgedAmount)
                                        TotalPayment -= TotalPayment
                                    End If
                                End If
                            Next
                        Else
                            SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value, dDebitT.Tag)
                        End If
                    End If
                    If drv("Type") = "RO" Then 'FROM ROPOA
                        Dim TotalPayments As Double = DataObject(String.Format("SELECT ROPOA_Payment('{0}','{1}');", cbxPayee.SelectedValue, drv("PayorID"))) + dPaidAmount.Value
                        Dim SoldAmount As Double = DataObject(String.Format("SELECT Amount FROM sold_ropoa WHERE ID = '{0}';", drv("PayorID")))
                        If cbxPayee.SelectedValue.ToString.Contains("ANV") Then
                            SQL &= String.Format(" UPDATE ropoa_vehicle SET sell_status = '{1}' WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", drv("Phone"), If(dPaidAmount.Value >= dPayable.Value, "SOLD", If(SoldAmount * 0.8 <= TotalPayments, "SOLD", "RESERVED")))
                        Else
                            SQL &= String.Format(" UPDATE ropoa_realestate SET sell_status = '{1}' WHERE TCT = '{0}' AND `status` = 'ACTIVE';", drv("Phone"), If(dPaidAmount.Value >= dPayable.Value, "SOLD", If(SoldAmount * 0.8 <= TotalPayments, "SOLD", "RESERVED")))
                        End If
                    End If
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    SQL &= String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE CVNumber = '{0}';", txtDocumentNumber.Text, ValidateComboBox(cbxPayee))
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        SQL &= "INSERT INTO accounting_entry SET"
                        SQL &= String.Format(" ORNum = '{0}', ", txtDocumentNumber.Text)
                        If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                            SQL &= " EntryType = 'DEBIT',"
                            SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                        Else
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                        End If
                        If drv("Type") = "AR" Then 'FROM ACCOUNTS RECEIVABLE
                            If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                SQL &= String.Format(" PaidFor = '{0}', ", "Acknowledgement")
                            Else
                                SQL &= String.Format(" PaidFor = '{0}', ", "Billing")
                            End If
                            SQL &= String.Format(" ReferenceN = '{0}', ", drv("PayorID"))
                            SQL &= String.Format(" Remarks = '{0}', ", rExplanation.Text.InsertQuote)
                        Else
                            If drv("Type") = "LA" Then 'FROM LOANS APPLICATION
                                SQL &= " PaidFor = 'Billing', "
                            Else
                                If GridView2.GetRowCellValue(x, "PaidFor").ToString = "" Then
                                    SQL &= String.Format(" PaidFor = '{0}', ", "Acknowledgement")
                                Else
                                    SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                                End If
                            End If
                            SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                            If drv("Type") = "RO" Then
                                SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks") & " [" & If(cbxCash.Checked, "Cash Payment", If(cbxCheck.Checked, "Check Payment " & cbxCheckNumber.Text, "Online Payment " & txtDeposit.Text)) & "] [" & If(dPaidAmount.Value < dPayable.Value, "Partial", "Full") & "]")
                            Else
                                SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            End If
                        End If
                        SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                        SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                        SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                        SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                        SQL &= " `Status` = 'PENDING',"
                        SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                        SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                        If drv("Type") = "RO" Then ' FROM ROPOA
                            SQL &= String.Format(" PlateNum = '{0}', ", drv("Phone"))
                            SQL &= String.Format(" SoldID = '{0}', ", drv("PayorID"))
                        End If
                        SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                        SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    Next
                    'ACCOUNTING ENTRY ***********************************************************************************************************

                    If cbxCheckNumber.Tag <> cbxCheckNumber.Text And cbxCheckNumber.Tag <> "" Then
                        SQL &= String.Format(" UPDATE check_received SET `status` = 'ACTIVE', Remarks = CONCAT(Remarks, ' [CANCELLED]') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND `status` = 'CLEARED';", cbxPayee.SelectedValue, cbxCheckNumber.Tag)

                        If From_Check And CheckID > 0 Then
                            If FromDueFrom Or From_PDC_Others Then
                                SQL &= String.Format("UPDATE dc_details SET `check_status` = 'CLEARED', Remarks = CONCAT(Remarks, ' [', 'CLEARED CHECK',']') WHERE ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID)
                            Else
                                If cbxCheck.Checked Then
                                    SQL &= String.Format("UPDATE check_received SET `status` = 'CLEARED', remarks = CONCAT(remarks, ' [', 'Cleared Check',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID)
                                ElseIf cbxCash.Checked Then
                                    If dAmount.Value >= 0 Then
                                        SQL &= String.Format("UPDATE check_received SET `status` = 'PAID', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dAmount.Text & " Cash", "Paid " & dAmount.Text & " Cash"))
                                    Else
                                        SQL &= String.Format("UPDATE check_received SET `status` = 'PARTIAL', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dAmount.Text & " Cash", "Paid " & dAmount.Text & " Cash"))
                                    End If
                                ElseIf cbxOnline.Checked Then
                                    If dAmount.Value >= 0 Then
                                        SQL &= String.Format("UPDATE check_received SET `status` = 'PAID', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dAmount.Text & " Online", "Paid " & dAmount.Text & " Online"))
                                    Else
                                        SQL &= String.Format("UPDATE check_received SET `status` = 'PARTIAL', remarks = CONCAT(remarks, ' [', '{3}',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND ID = '{2}';", cbxPayee.SelectedValue, cbxCheckNumber.Text, CheckID, If(FrmPDCManagement.GridView3.GetFocusedRowCellValue("ReDeposit") > 1, "Paid " & dAmount.Text & " Online", "Paid " & dAmount.Text & " Online"))
                                    End If
                                End If
                            End If
                        ElseIf cbxCheck.Checked Then
                            SQL &= String.Format("UPDATE check_received SET `status` = 'CLEARED', remarks = CONCAT(remarks, ' [', 'Cleared Check',']') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND `Date` = '{2}' AND `status` NOT IN ('PENDING','CANCELLED','DELETED');", cbxPayee.SelectedValue, cbxCheckNumber.Text.Trim, Format(dtpCheck.Value, "yyyy-MM-dd"))
                        End If
                    End If
                    DataObject(SQL)

                    Logs("Acknowledgement Receipt", "Update", Reason, Changes(), "", "", "")
                    Clear(True)
                    Cursor = Cursors.Default
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If dtpPostingDate.Text = dtpPostingDate.Tag Then
            Else
                Change &= String.Format("Change Date from {0} to {1}. ", dtpPostingDate.Tag, dtpPostingDate.Text)
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
            If cbxCheckNumber.Text = cbxCheckNumber.Tag Then
            Else
                Change &= String.Format("Change Check Number from {0} to {1}. ", cbxCheckNumber.Tag, cbxCheckNumber.Text)
            End If
            If dtpCheck.Text = dtpCheck.Tag Then
            Else
                Change &= String.Format("Change Check Date from {0} to {1}. ", dtpCheck.Tag, dtpCheck.Text)
            End If
            If txtDeposit.Text = txtDeposit.Tag Then
            Else
                Change &= String.Format("Change Deposit Number from {0} to {1}. ", txtDeposit.Tag, txtDeposit.Text)
            End If
            If dtpDeposit.Text = dtpDeposit.Tag Then
            Else
                Change &= String.Format("Change Deposit Date from {0} to {1}. ", dtpDeposit.Tag, dtpDeposit.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Acknowledgement - Changes", ex.Message.ToString)
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
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            Dim SQL As String = String.Format("UPDATE acknowledgement_receipt SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID)
            If cbxCheckNumber.Tag <> "" Then
                SQL &= String.Format(" UPDATE check_received SET `status` = 'ACTIVE', Remarks = CONCAT(Remarks, ' [CANCELLED]') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND `status` = 'CLEARED';", cbxPayee.SelectedValue, cbxCheckNumber.Tag)
            End If
            SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE CVNumber = '{0}' AND ReferenceN = '{1}';", txtDocumentNumber.Text, If(drv("Type") = "AR", drv("PayorID"), ValidateComboBox(cbxPayee)))
            SQL &= String.Format(" UPDATE accounts_receivable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_from SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_to SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE loans_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)

            If drv("Type") = "L" Then 'FROM LIQUIDATION
                SQL &= String.Format(" UPDATE liquidation_main SET AmountAcknowledged = IF(AmountAcknowledged - {1} <= 0, 0,AmountAcknowledged - {1}), Liq_Status = IF(AmountAcknowledged - {1} <= 0,'APPROVED','PARTIALLY ACKNOWLEDGED') WHERE AccountNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
            End If
            If drv("Type") = "CAS" Then 'FROM CASH ADVANCE
                SQL &= String.Format(" UPDATE cash_advance SET ACRNumber = '' WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue)
            End If
            If drv("Type") = "AR" Then 'FROM ACCOUNTS PAYABLE
                If MultipleAR Then
                    Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, (SELECT SUM(Debit) FROM acr_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_receivable.DocumentNumber AND `status` = 'ACTIVE') AS 'Paid' FROM accounts_receivable WHERE DocumentNumber IN ({0});", AccountsReceivableID_M, txtDocumentNumber.Text))
                    For x As Integer = 0 To vDT.Rows.Count - 1
                        SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                    Next
                Else
                    SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                End If
            End If
            If drv("Type") = "AP" Then 'FROM ACCOUNTS PAYABLE
                If MultipleAR Then
                    Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, (SELECT SUM(Amount) FROM cv_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_payable.DocumentNumber AND `status` = 'ACTIVE' AND Type = 'C') AS 'Paid' FROM accounts_payable WHERE DocumentNumber IN ({0});", AccountsReceivableID_M, txtDocumentNumber.Text))
                    For x As Integer = 0 To vDT.Rows.Count - 1
                        SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                    Next
                Else
                    SQL &= String.Format(" UPDATE accounts_payable SET Paid = IF(Paid - {1} <= 0, 0,Paid - {1}), AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                End If
            End If
            If drv("Type") = "DF" And If(From_Check, DFPayPrincipal, 1) Then 'FROM Due From
                If MultipleAR Then
                    Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, (SELECT SUM(Debit) FROM acr_details WHERE DocumentNumber = '{1}' AND ReferenceN = due_from.DocumentNumber AND `status` = 'ACTIVE') AS 'Paid' FROM due_from WHERE DocumentNumber IN ({0});", AccountsReceivableID_M, txtDocumentNumber.Text))
                    For x As Integer = 0 To vDT.Rows.Count - 1
                        SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                    Next
                Else
                    SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                End If
                If cbxCheckNumber.Tag <> "" Then
                    SQL &= String.Format(" UPDATE dc_details SET `check_status` = 'ACTIVE', Remarks = CONCAT(Remarks, ' [DISAPPROVED]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND `check_status` = 'CLEARED';", drv("AccountNumber"), cbxCheckNumber.Tag)
                End If
            End If
            If drv("Type") = "RO" Then 'FROM ROPOA
                If cbxPayee.SelectedValue.ToString.Contains("ANV") Then
                    SQL &= String.Format(" UPDATE ropoa_vehicle SET sell_status = 'RESERVED' WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", drv("Phone"))
                Else
                    SQL &= String.Format(" UPDATE ropoa_realestate SET sell_status = 'RESERVED' WHERE TCT = '{0}' AND `status` = 'ACTIVE';", drv("Phone"))
                End If
            End If
            If drv("Type") = "LA" And drv("Amount") = 1 And (drv("AccountNumber") = "PAID" Or drv("AccountNumber") = "PARTIAL") Then ' FROM CREDIT APPLICATION WITH BILL DEDUCTABLES
                SQL &= String.Format("UPDATE credit_application SET BillDeductionsStatus = 'PENDING' WHERE CreditNumber = '{0}';", cbxPayee.SelectedValue)
            End If
            DataObject(SQL)
            Logs("Acknowledgement Receipt", "Cancel", Reason, String.Format("Cancel Acknowledgement Receipt of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "")
            Clear(True)
            LoadPayee()
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Generate_Receipt(Show As Boolean, FName As String, CheckedBy As String, ApprovedBy As String)
Here:
        Dim Report As New RptAcknowledgementReceipt
        With Report
            .Name = String.Format("Acknowledgement Receipt of {0} - {1}", cbxPayee.Text, txtDocumentNumber.Text)
            .lblAddress.Text = Branch_Address
            .lblContact.Text = Branch_Contact
            .lblTIN.Text = Branch_TIN
            .lblFSFC.Text = "First Standard Finance Corporation - " & UpperCaseFirst(Branch)

            .lblPayee.Text = cbxPayee.Text
            .lblDocumentDate.Text = dtpDocument.Text
            .lblDocumentNumber.Text = txtDocumentNumber.Text
            .lblPostingDate.Text = dtpPostingDate.Text
            .lblReferenceNumber.Text = txtReferenceNumber.Text
            .lblBank.Text = cbxBank.Text
            .lblExplanation.Text = rExplanation.Text
            .lblNet.Text = dAmount.Text

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
                    GoTo Here
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
            Generate_Receipt(True, "", txtChecked.Text, txtApproved.Text)
            Logs("Acknowledgement Receipt", "Print", "[SENSITIVE] Print Acknowledgement Receipt " & txtDocumentNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ACKNOWLEDGEMENT RECEIPT LIST", GridControl1)
            Logs("Acknowledgement Receipt", "Print", "[SENSITIVE] Print Acknowledgement Receipt List", "", "", "", "")
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or If(From_CashAdvance Or FromAccountsReceivable Or FromDueFrom Or From_PDC_Others Or From_GL Or From_Check Or From_ITL Or From_ROPOA, e.KeyCode = Keys.Escape, 0) Then
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
        ElseIf e.Shift And e.KeyCode = Keys.Oemplus Then
            btnAdd_Account.Focus()
            btnAdd_Account.PerformClick()
        ElseIf e.Shift And e.KeyCode = Keys.OemMinus Then
            btnRemove_Account.Focus()
            btnRemove_Account.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
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
        PanelEx2.Enabled = False
        GridView2.OptionsBehavior.Editable = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            dtpDocument.Value = .GetFocusedRowCellValue("Document Date")
            txtDocumentNumber.Text = .GetFocusedRowCellValue("Document Number")
            If .GetFocusedRowCellValue("Payee_Type") = "ARM" Or .GetFocusedRowCellValue("Payee_Type") = "DFM" Then
                MultipleAR = True
                AccountsReceivableID_M = .GetFocusedRowCellValue("MultipleAR")
                btnAdd_Account.Enabled = False
                btnRemove_Account.Enabled = False
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "RO" Then
                lblAmount.Visible = True
                dPaidAmount.Visible = True
                lblRunningBalance.Visible = True
                dRunningBalance.Visible = True
                lblPayable.Visible = True
                dPayable.Visible = True
                dPaidAmount.Enabled = False
                dPaidAmount.Value = .GetFocusedRowCellValue("PaidAmount")
                dRunningBalance.Value = .GetFocusedRowCellValue("RunningBalance")
                dPayable.Value = .GetFocusedRowCellValue("Payable")
            End If
            cbxPayee.Enabled = False
            FirstLoad = True
            If .GetFocusedRowCellValue("Payee_Type") = "ARM" Or .GetFocusedRowCellValue("Payee_Type") = "AR" Then
                cbxAR.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "APM" Or .GetFocusedRowCellValue("Payee_Type") = "AP" Then
                cbxAP.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "L" Then
                cbxLOE.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "ITL" Then
                cbxITL.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "RO" Then
                cbxRO.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "DFM" Or .GetFocusedRowCellValue("Payee_Type") = "DF" Then
                cbxDF.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "LA" Then
                cbxLA.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "CAS" Then
                cbxCAS.Checked = True
            End If
            LoadPayee()
            cbxLOE.Enabled = False
            cbxAR.Enabled = False
            cbxAP.Enabled = False
            cbxDF.Enabled = False
            cbxITL.Enabled = False
            cbxRO.Enabled = False
            cbxLA.Enabled = False
            cbxCAS.Enabled = False

            cbxPayee.Text = .GetFocusedRowCellValue("Payee")
            cbxPayee.Tag = .GetFocusedRowCellValue("Payee")

            FirstLoad = False
            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            cbxBank.Tag = .GetFocusedRowCellValue("Bank")
            dtpPostingDate.Value = .GetFocusedRowCellValue("Posting Date")
            dtpPostingDate.Tag = .GetFocusedRowCellValue("Posting Date")
            txtReferenceNumber.Text = .GetFocusedRowCellValue("Reference Number")
            txtReferenceNumber.Tag = .GetFocusedRowCellValue("Reference Number")
            rExplanation.Text = .GetFocusedRowCellValue("Explanation")
            rExplanation.Tag = .GetFocusedRowCellValue("Explanation")

            If CompanyMode = 0 Then
                If .GetFocusedRowCellValue("Payee_Type") = "ARM" Then
                    DT_Account = DataSource(String.Format("SELECT MotherCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = MotherCode(acr_details.AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, Remarks, Required AS 'RequiredRemarks', ReferenceN, BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, PaidFor FROM acr_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
                Else
                    DT_Account = DataSource(String.Format("SELECT MotherCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = MotherCode(acr_details.AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, PaidFor FROM acr_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
                End If
            Else
                If .GetFocusedRowCellValue("Payee_Type") = "ARM" Then
                    DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = acr_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, Remarks, Required AS 'RequiredRemarks', ReferenceN, BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, PaidFor FROM acr_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
                Else
                    DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = acr_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, PaidFor FROM acr_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
                End If
            End If
        End With
        GridControl2.DataSource = DT_Account
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
        If GridView2.RowCount > 5 Then
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342 - 17
            Else
                GridColumn32.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342
            Else
                GridColumn32.Width = (342 - 80)
            End If
        End If

        With GridView1
            If .GetFocusedRowCellValue("Type") = "CASH" Then
                cbxCash.Checked = True
            ElseIf .GetFocusedRowCellValue("Type") = "CHECK" Then
                cbxCheck.Checked = True
            ElseIf .GetFocusedRowCellValue("Type") = "ONLINE" Then
                cbxOnline.Checked = True
            End If
            cbxCheckNumber.Text = .GetFocusedRowCellValue("CheckNumber")
            cbxCheckNumber.Tag = .GetFocusedRowCellValue("CheckNumber")
            dtpCheck.Text = .GetFocusedRowCellValue("CheckDate").ToString
            dtpCheck.Tag = .GetFocusedRowCellValue("CheckDate").ToString
            txtDeposit.Text = .GetFocusedRowCellValue("DepositNumber")
            txtDeposit.Tag = .GetFocusedRowCellValue("DepositNumber")
            dtpDeposit.Text = .GetFocusedRowCellValue("DepositDate").ToString
            dtpDeposit.Tag = .GetFocusedRowCellValue("DepositDate").ToString

            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")
            txtChecked.Text = .GetFocusedRowCellValue("Checked By")
            txtChecked.Tag = .GetFocusedRowCellValue("CheckedID")
            txtApproved.Text = .GetFocusedRowCellValue("Approved By")
            User_EmplID = .GetFocusedRowCellValue("User_EmplID")
            Code_Check = .GetFocusedRowCellValue("OTAC_Check")
            Code_Approve = .GetFocusedRowCellValue("OTAC_Approve")
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
            cbxCheck.Checked = False
            cbxOnline.Checked = False
        End If

        If cbxCash.Checked = False And cbxCheck.Checked = False And cbxOnline.Checked = False Then
            cbxCash.Checked = True
        End If
    End Sub

    Private Sub CbxCheck_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCheck.CheckedChanged
        With cbxCheckNumber
            If cbxCheck.Checked Then
                cbxCash.Checked = False
                cbxOnline.Checked = False

                .Enabled = True
                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                    .DataSource = Nothing
                Else
                    If drv("Type") = "LA" Or drv("Type") = "RO" Then
                        FirstLoad = True
                        .DisplayMember = "Check"
                        .ValueMember = "ID"
                        '.DataSource = DataSource(String.Format("SELECT ID, `Check`, `Date`, Amount FROM check_received WHERE `Status` NOT IN ('PENDING','DELETED','CANCELLED','PARTIAL','RETURNED','PAID','CLEARED','REMOVED') AND check_type = 'R' AND AssetNumber = '{0}';", ValidateComboBox(cbxPayee)))
                        .DataSource = DataSource(String.Format("SELECT ID, `Check`, `Date`, Amount FROM check_received WHERE `Status` NOT IN ('PENDING','DELETED','CANCELLED','PARTIAL','RETURNED','PAID','BOUNCED','CLEARED','REMOVED') AND check_type = 'R' AND AssetNumber = '{0}';", ValidateComboBox(cbxPayee)))
                        FirstLoad = False
                        .SelectedIndex = -1
                    Else
                        .DataSource = Nothing
                    End If
                End If
                dtpCheck.Enabled = True
                dtpCheck.CustomFormat = "MMMM dd, yyyy"
                dtpCheck.Value = Date.Now
            Else
                .Enabled = False
                dtpCheck.Enabled = False
                .Text = ""
                .DataSource = Nothing
                dtpCheck.CustomFormat = ""
            End If
        End With

        If cbxCash.Checked = False And cbxCheck.Checked = False And cbxOnline.Checked = False Then
            cbxCash.Checked = True
        End If
    End Sub

    Private Sub CbxOnline_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOnline.CheckedChanged
        If cbxOnline.Checked Then
            cbxCash.Checked = False
            cbxCheck.Checked = False

            txtDeposit.Enabled = True
            With dtpDeposit
                .Enabled = True
                .CustomFormat = "MMMM dd, yyyy"
                .Value = Date.Now
            End With
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
        If FirstLoad Or CopyMode Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                Clear(False)
            Else
                GridColumn32.Width = 342
                GridColumn20.Visible = False

                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                lblAmount.Visible = False
                dPaidAmount.Visible = False
                lblRunningBalance.Visible = False
                dRunningBalance.Visible = False
                lblPayable.Visible = False
                dPayable.Visible = False
                If (drv("Type") = "LA" Or drv("Type") = "RO") And cbxCheck.Checked Then
                    With cbxCheckNumber
                        .DisplayMember = "Check"
                        .ValueMember = "ID"
                        .DataSource = DataSource(String.Format("SELECT ID, `Check`, `Date`, Amount FROM check_received WHERE `Status` NOT IN ('PENDING','DELETED','CANCELLED','PARTIAL','RETURNED','PAID','CLEARED','REMOVED') AND check_type = 'R' AND AssetNumber = '{0}';", ValidateComboBox(cbxPayee)))
                        If From_Check Then
                        Else
                            .Text = ""
                            dtpCheck.Value = Date.Now
                        End If
                    End With
                Else
                    cbxCheckNumber.DataSource = Nothing
                End If
                If drv("Type") = "L" Then
                    rExplanation.Text = drv("Explanation")
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    'DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), DataObject(String.Format("SELECT EmplDepartmentCode('{0}');", cbxPayee.SelectedValue)), DT_Temp_Account(0)("Account"), "", DataObject(String.Format("SELECT CONCAT('{0}', ' - ', Department('{0}'));", DataObject(String.Format("SELECT EmplDepartmentCode('{0}');", cbxPayee.SelectedValue)))), drv("Amount"), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'CREDIT
                    AccountCodeDetails(If(drv("Mortgage") = 1, "112401", "112402"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), DataObject(String.Format("SELECT EmplDepartmentCode('{0}');", cbxPayee.SelectedValue)), DT_Temp_Account(0)("Account"), "", DataObject(String.Format("SELECT CONCAT('{0}', ' - ', Department('{0}'));", DataObject(String.Format("SELECT EmplDepartmentCode('{0}');", cbxPayee.SelectedValue)))), 0, drv("Amount"), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                ElseIf drv("Type") = "VE" Or drv("Type") = "RE" Then
                    rExplanation.Text = drv("Explanation")
                    cbxBank.SelectedValue = drv("BankID")
                ElseIf drv("Type") = "AP" Then 'FROM ACCOUNTS PAYABLE
                    rExplanation.Text = ""
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    If AR_Account = "" Then
                        AR_Account = DataObject(String.Format("SELECT AccountCode FROM ap_details WHERE DocumentNumber = '{0}' AND Credit > 0 AND `status` = 'ACTIVE' LIMIT 1;", drv("ID")))
                    End If
                    If MultipleAR Then
                        rExplanation.Text = "[Accounts Payable : " & AccountsReceivableID_M & "]"
                        DT_Account = DataSource(String.Format("SELECT IF(Debit > 0,'111001',AccountCode) AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = IF(Debit > 0,'111001',AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(Credit > 0,Credit - (SELECT AP.Paid FROM accounts_payable AP WHERE AP.DocumentNumber = ap_details.DocumentNumber),Credit) AS 'Debit', IF(Debit > 0,Debit - (SELECT AP.Paid FROM accounts_payable AP WHERE AP.DocumentNumber = ap_details.DocumentNumber),Debit) AS 'Credit', CONCAT('[', DocumentNumber,'] ',Remarks) AS 'Remarks', Required AS 'RequiredRemarks', DocumentNumber AS 'ReferenceN', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'Paid For' FROM ap_details WHERE `status` = 'ACTIVE' AND DocumentNumber IN ({0});", AccountsReceivableID_M))
                        Dim AutoGenerated As DataTable = DataSource(String.Format("SELECT Amount, DocumentNumber FROM accounts_payable WHERE JVNumberV2 != '' AND DocumentNumber IN ({0});", AccountsReceivableID_M))
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        For x As Integer = 0 To AutoGenerated.Rows.Count - 1
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(AutoGenerated(x)("Amount")) - CDbl(AutoGenerated(x)("Amount")), AutoGenerated(x)("DocumentNumber"), DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        Next
                        GridControl2.DataSource = DT_Account
                        Dim TotalDebitX As Double
                        Dim TotalCreditX As Double
                        For x As Integer = 0 To DT_Account.Rows.Count - 1
                            TotalDebitX += CDbl(DT_Account(x)("Debit"))
                            TotalCreditX += CDbl(DT_Account(x)("Credit"))
                        Next
                        dDebitT.Value = TotalDebitX
                        dCreditT.Value = TotalCreditX
                        dCreditT.Tag = TotalCreditX
                    Else
                        rExplanation.Text = drv("Explanation")
                        'DEBIT
                        AccountCodeDetails(AR_Account)
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(drv("Amount")), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(drv("Amount")) - CDbl(drv("Amount")), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")

                        Dim TotalDebitX As Double
                        Dim TotalCreditX As Double
                        For x As Integer = 0 To DT_Account.Rows.Count - 1
                            TotalDebitX += CDbl(DT_Account(x)("Debit"))
                            TotalCreditX += CDbl(DT_Account(x)("Credit"))
                        Next
                        dDebitT.Value = TotalDebitX
                        dCreditT.Value = TotalCreditX
                        dCreditT.Tag = TotalCreditX
                    End If
                ElseIf drv("Type") = "AR" Then
                    rExplanation.Text = drv("Explanation")
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    If AR_Account = "" Then
                        AR_Account = DataObject(String.Format("SELECT AccountCode FROM ar_details WHERE DocumentNumber = '{0}' AND Debit > 0 AND `status` = 'ACTIVE' LIMIT 1;", drv("AccountNumber")))
                    End If
                    If MultipleAR Then
                        rExplanation.Text = "[Accounts Receivable : " & AccountsReceivableID_M & "]"
                        DT_Account = DataSource(String.Format("SELECT IF(Credit > 0,'111001',AccountCode) AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = IF(Credit > 0,'111001',AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(Credit > 0,Credit - (SELECT AR.Paid FROM accounts_receivable AR WHERE AR.DocumentNumber = ar_details.DocumentNumber),Credit) AS 'Debit', IF(Debit > 0,Debit - (SELECT AR.Paid FROM accounts_receivable AR WHERE AR.DocumentNumber = ar_details.DocumentNumber),Debit) AS 'Credit', CONCAT('[', DocumentNumber,'] ',Remarks) AS 'Remarks', Required AS 'RequiredRemarks', DocumentNumber AS 'ReferenceN', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'PaidFor' FROM ar_details WHERE `status` = 'ACTIVE' AND DocumentNumber IN ({0});", AccountsReceivableID_M))
                        Dim AutoGenerated As DataTable = DataSource(String.Format("SELECT Amount, DocumentNumber FROM accounts_receivable WHERE JVNumberV2 != '' AND DocumentNumber IN ({0});", AccountsReceivableID_M))
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        For x As Integer = 0 To AutoGenerated.Rows.Count - 1
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(AutoGenerated(x)("Amount")), 0, AutoGenerated(x)("DocumentNumber"), DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        Next
                        GridControl2.DataSource = DT_Account
                        Dim TotalDebitX As Double
                        Dim TotalCreditX As Double
                        For x As Integer = 0 To DT_Account.Rows.Count - 1
                            TotalDebitX += CDbl(DT_Account(x)("Debit"))
                            TotalCreditX += CDbl(DT_Account(x)("Credit"))
                        Next
                        dDebitT.Value = TotalDebitX
                        dCreditT.Value = TotalCreditX
                    Else
                        'DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", drv("Amount"), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'CREDIT
                        AccountCodeDetails(AR_Account)
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, drv("Amount"), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                ElseIf drv("Type") = "DF" Then
                    rExplanation.Text = drv("Explanation")
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    If AR_Account = "" Then
                        AR_Account = DataObject(String.Format("SELECT AccountCode FROM df_details WHERE DocumentNumber = '{0}' AND Debit > 0 AND `status` = 'ACTIVE' LIMIT 1;", drv("AccountNumber")))
                    End If
                    If MultipleAR Then
                        rExplanation.Text = "[Due From: " & AccountsReceivableID_M & "]"
                        DT_Account = DataSource(String.Format("SELECT IF(Credit > 0,'111001',AccountCode) AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = IF(Credit > 0,'111001',AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(Credit > 0,Credit - (SELECT AR.Paid FROM due_from AR WHERE AR.DocumentNumber = df_details.DocumentNumber),Credit) AS 'Debit', IF(Debit > 0,Debit - (SELECT AR.Paid FROM due_from AR WHERE AR.DocumentNumber = df_details.DocumentNumber),Debit) AS 'Credit', CONCAT('[', DocumentNumber,'] ',Remarks) AS 'Remarks', Required AS 'RequiredRemarks', DocumentNumber AS 'ReferenceN', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'PaidFor' FROM df_details WHERE `status` = 'ACTIVE' AND DocumentNumber IN ({0});", AccountsReceivableID_M))
                        Dim AutoGenerated As DataTable = DataSource(String.Format("SELECT Amount, DocumentNumber FROM due_from WHERE JVNumberV2 != '' AND DocumentNumber IN ({0});", AccountsReceivableID_M))
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        For x As Integer = 0 To AutoGenerated.Rows.Count - 1
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(AutoGenerated(x)("Amount")), 0, AutoGenerated(x)("DocumentNumber"), DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        Next
                        GridControl2.DataSource = DT_Account
                        Dim TotalDebitX As Double
                        Dim TotalCreditX As Double
                        For x As Integer = 0 To DT_Account.Rows.Count - 1
                            TotalDebitX += CDbl(DT_Account(x)("Debit"))
                            TotalCreditX += CDbl(DT_Account(x)("Credit"))
                        Next
                        dDebitT.Value = TotalDebitX
                        dCreditT.Value = TotalCreditX
                    Else
                        If From_Check Then
                            If DFPayPrincipal Then
                            Else
                                If DataObject(String.Format("SELECT Payor_Type FROM due_from WHERE ID = '{0}';", cbxPayee.SelectedValue)) = "B" Then
                                    AR_Account = "620021"
                                Else
                                    AR_Account = "620061"
                                End If
                            End If
                            AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                            'CREDIT
                            AccountCodeDetails(AR_Account)
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        Else
                            AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", drv("Amount"), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                            'CREDIT
                            AccountCodeDetails(AR_Account)
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, drv("Amount"), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                    End If
                ElseIf drv("Type") = "RO" Then
                    rExplanation.Text = drv("Explanation")
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    lblAmount.Visible = True
                    dPaidAmount.Visible = True
                    lblRunningBalance.Visible = True
                    dRunningBalance.Visible = True
                    lblPayable.Visible = True
                    dPayable.Visible = True
                    dRunningBalance.Value = CDbl(drv("AccountNumber"))
                    dPayable.Value = CDbl(drv("Amount"))
                    BankID = drv("EmailAdd")
                    cbxBank.SelectedValue = BankID
                    FillAccounts()

                    RepositoryItemLookUpEdit4.DataSource = DataSource("SELECT 'ROPA' AS 'Paid For' UNION SELECT ''")
                ElseIf drv("Type") = "ITL" Then
                    rExplanation.Text = drv("Explanation")
                    cbxBank.SelectedValue = drv("BankID")
                    Fill_ITL()
                ElseIf drv("Type") = "LA" Then
                    btnLedger.Visible = True
                    DT_Account.Rows.Clear()
                    If drv("Amount") = 1 And (drv("AccountNumber") = "PENDING" Or drv("AccountNumber") = "PARTIAL") Then 'Bill Deductions
                        rExplanation.Text = ""
                        TotalDeductions = 0
                        cbxBank.SelectedValue = If(DefaultBank = 0, drv("BankID"), DefaultBank)
                        DT_Account.Rows.Clear()
                        Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                        Dim SQL As String = "SELECT * FROM ("
                        SQL &= String.Format("    SELECT Advance_Payment AS 'Amount', 'Advance Payment' AS 'Type', '229104' AS 'Account', AccountNumber, GMA - Rebate AS 'Monthly', ROUND(Interest / Terms) AS 'Monthly Interest', Mortgage_ID FROM credit_application WHERE CreditNumber = '{0}' AND IncludeAdvancePaymentInBill = 1 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue)
                        SQL &= String.Format("    SELECT Service_Charge AS 'Amount', 'Service Charge' AS 'Type', IF(Mortgage_ID = 1,'420101',IF(Mortgage_ID = 2,'420102','420103')) AS 'Account', AccountNumber, 0 AS 'Monthly', 0 AS 'Monthly Interest', Mortgage_ID FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 1 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue)
                        SQL &= String.Format("    SELECT SUM(Amount) AS 'Amount', 'Processing Fee' AS 'Type', IF(MortgageID('{0}') = 1,'420201',IF(MortgageID('{0}') = 2,'420202','420203')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest', 0 AS 'Mortgage_ID' FROM credit_processing_fee WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND (SELECT Product FROM credit_application WHERE CreditNumber = credit_processing_fee.CreditNumber AND BillDeductions = 1) NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue)
                        SQL &= String.Format("    SELECT `Amount`, 'Deduct Balance' AS 'Type', IF(MortgageID('{0}') = 1,'112001',IF(MortgageID('{0}') = 2,'112002','112003')) AS 'Account', AccountNumber, 0 AS 'Monthly', 0 AS 'Monthly Interest', 0 AS 'Mortgage_ID' FROM credit_deductbalance WHERE `status` = 'ACTIVE' AND deduct_status = 'PENDING' AND CreditNumber_F = '{0}' AND (SELECT Product FROM credit_application WHERE CreditNumber = credit_deductbalance.CreditNumber_F) NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue)
                        SQL &= String.Format("    SELECT Miscellaneous_Income + Appraisal_Fee + CI_Fee AS 'Amount', 'Mischellaneous Income' AS 'Type', IF(Mortgage_ID = 1,'420301',IF(Mortgage_ID = 2,'420302','420303')) AS 'Account', AccountNumber, 0 AS 'Monthly', 0 AS 'Monthly Interest', Mortgage_ID FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 1 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue)
                        SQL &= String.Format("    SELECT Insurance AS 'Amount', 'Insurance' AS 'Type', IF(Mortgage_ID = 1,'218301',IF(Mortgage_ID = 2,'218302','218303')) AS 'Account', AccountNumber, 0 AS 'Monthly', 0 AS 'Monthly Interest', Mortgage_ID FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 1 AND Product NOT LIKE '%SHOWMONEY%' ) A WHERE A.Amount > 0", cbxPayee.SelectedValue)
                        Dim Credits As DataTable = DataSource(SQL)
                        'DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        For x As Integer = 0 To Credits.Rows.Count - 1
                            'CREDIT
                            If Credits(x)("Type") = "Advance Payment" Then
                                If CDbl(Credits(x)("Amount")) > 1 Then
                                    LoadAmortization(cbxPayee.SelectedValue, GridControl4)
                                    Dim ForDistribute As Double = Credits(x)("Amount")
                                    Dim UDIAdvance As Double
                                    Dim PrincipalAvance As Double
                                    For y As Integer = 1 To GridView4.RowCount - 1
                                        If ForDistribute > 0 Then
                                            If ForDistribute >= CDbl(GridView4.GetRowCellValue(y, "Monthly")) Then
                                                UDIAdvance += CDbl(GridView4.GetRowCellValue(y, "Interest Income"))
                                                PrincipalAvance += CDbl(GridView4.GetRowCellValue(y, "Principal Allocation"))
                                                ForDistribute -= CDbl(GridView4.GetRowCellValue(y, "Interest Income")) + CDbl(GridView4.GetRowCellValue(y, "Principal Allocation"))
                                            Else
                                                If ForDistribute >= CDbl(GridView4.GetRowCellValue(y, "Interest Income")) Then
                                                    UDIAdvance += CDbl(GridView4.GetRowCellValue(y, "Interest Income"))
                                                    ForDistribute -= CDbl(GridView4.GetRowCellValue(y, "Interest Income"))
                                                Else
                                                    UDIAdvance += ForDistribute
                                                    ForDistribute = 0
                                                End If
                                                If ForDistribute >= CDbl(GridView4.GetRowCellValue(y, "Principal Allocation")) Then
                                                    PrincipalAvance += CDbl(GridView4.GetRowCellValue(y, "Principal Allocation"))
                                                    ForDistribute -= CDbl(GridView4.GetRowCellValue(y, "Principal Allocation"))
                                                Else
                                                    PrincipalAvance += ForDistribute
                                                    ForDistribute = 0
                                                End If
                                            End If
                                        End If
                                    Next
                                    If UDIAdvance > 0 Then
                                        AccountCodeDetails(If(Credits(x)("Mortgage_ID") = 1, "420001", If(Credits(x)("Mortgage_ID") = 2, "420002", "420006")))
                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Math.Ceiling(UDIAdvance), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "UDI")
                                    End If
                                    If PrincipalAvance > 0 Then
                                        AccountCodeDetails(If(Credits(x)("Mortgage_ID") = 1, "112001", If(Credits(x)("Mortgage_ID") = 2, "112002", "112003")))
                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Math.Floor(PrincipalAvance), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "Principal")
                                    End If
                                    TotalDeductions += Credits(x)("Amount")
                                End If
                            Else
                                AccountCodeDetails(Credits(x)("Account"))
                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Credits(x)("Amount"), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "Billing")
                                TotalDeductions += Credits(x)("Amount")
                            End If
                        Next
                        DT_Account(0)("Debit") = TotalDeductions
                    Else
                        cbxBank.SelectedValue = If(DefaultBank = 0, drv("BankID"), DefaultBank)
                        If From_Check Then
                            DT_Account(0)("Debit") = dPaidAmount.Value
                        Else
                            DT_Account.Rows.Add("", "", "", DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("Mortgage"))), "", 0, 0, "", "", drv("Mortgage"), 0, "")
                            DT_Account.Rows.Add("", "", "", DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("Mortgage"))), "", 0, 0, "", "", drv("Mortgage"), 0, "")
                        End If
                    End If
                ElseIf drv("Type") = "CAS" Then 'FROM CASH ADVANCES
                    rExplanation.Text = drv("Explanation")
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    'DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(drv("Amount")), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'CREDIT
                    AccountCodeDetails(If(drv("Mortgage") = 1, "112401", "112402"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(drv("Amount")), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If

                GridControl2.DataSource = DT_Account
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
                If GridView2.RowCount > 5 Then
                    If GridColumn20.Visible = False Then
                        GridColumn32.Width = 342 - 17
                    Else
                        GridColumn32.Width = (342 - 80) - 17
                    End If
                Else
                    If GridColumn20.Visible = False Then
                        GridColumn32.Width = 342
                    Else
                        GridColumn32.Width = (342 - 80)
                    End If
                End If
                dDebitT.Value = TotalDebit
                dCreditT.Value = TotalCredit
                dAmount.Value = Total_CIB
            End If
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadAmortization(CreditNumber As String, Grid As DevExpress.XtraGrid.GridControl)
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
        Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, 2), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), "", "", "", "", FormatNumber(T_Penalty, 2), "")
        Grid.DataSource = Temp_DT
    End Sub

    Private Sub Fill_ITL()
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
        'DEBIT SUGGESTION
        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", drv("Amount"), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 0 Or drv("Mortgage") = 3, "112303", If(drv("Mortgage") = 1, "112301", If(drv("Mortgage") = 2, "112301", "112301")))))
        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, drv("Amount"), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")

        RepositoryItemLookUpEdit4.DataSource = DataSource("SELECT 'ITL' AS 'Paid For' UNION SELECT ''")
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
            .FolderName = "Acknowledgement Receipt-" & GridView1.GetFocusedRowCellValue("Document Number")
            .ARNumber = GridView1.GetFocusedRowCellValue("Document Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Document Number")
            .Type = "Acknowledgement Receipt"
            Dim Result = Attach.ShowDialog
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

                            DataObject(String.Format("UPDATE acknowledgement_receipt SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE accounts_receivable SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, .cbxProvider.SelectedValue, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Acknowledgement Receipt", "Check", String.Format("Checked Acknowledgement Receipt of {0} with the total amount of {1}. [Via OTAC]", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                            Clear(True)
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
            If MsgBoxYes("Are you sure you check this Acknowledgement Receipt?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    ApproveNotification(Code, False)
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                DataObject(String.Format("UPDATE acknowledgement_receipt SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_receivable SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE accounts_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Acknowledgement Receipt", "Check", String.Format("Checked Acknowledgement Receipt of {0} with the total amount of {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        End If

        If From_GL Then
            btnCheck.DialogResult = DialogResult.OK
            btnCheck.DialogResult = DialogResult.OK
            btnCheck.PerformClick()
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        If btnApprove.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If drv("Type") = "RO" Then 'FROM ROPOA
            Dim Prev As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DocumentNumber),'') AS 'DocumentNumber' FROM acknowledgement_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'RO' AND `status` = 'ACTIVE' AND Voucher_Status IN ('PENDING','CHECKED') AND ID < '{1}';", cbxPayee.SelectedValue, ID))
            If Prev = "" Then
            Else
                MsgBox(String.Format("Please Approve the previous transactions of this ROPA with Document Number(s): {0}.", Prev), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        ElseIf drv("Type") = "ITL" Then 'FROM ITL
            Dim Prev As String = DataObject(String.Format("SELECT IFNULL(GROUP_CONCAT(DocumentNumber),'') AS 'DocumentNumber' FROM acknowledgement_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'ITL' AND `status` = 'ACTIVE' AND Voucher_Status IN ('PENDING','CHECKED') AND ID < '{1}';", cbxPayee.SelectedValue, ID))
            If Prev = "" Then
            Else
                MsgBox(String.Format("Please Approve the previous transactions of this ITL with Document Number(s): {0}.", Prev), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If

        Dim Signatory As Boolean
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

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
                            Dim SQL As String = String.Format("UPDATE accounting_entry SET ORDate = '{1}', `Status` = 'ACTIVE', PostStatus = 'POSTED' WHERE CVNumber = '{0}' AND `status` = 'PENDING';", txtDocumentNumber.Text, Format(dtpPostingDate.Value, "yyyy-MM-dd"))

                            If drv("Type") = "CAS" Then 'FROM CASH ADVANCE
                                SQL &= String.Format(" UPDATE cash_advance SET `status` = 'CANCELLED', Purpose = CONCAT(Purpose, '[Returned as Cash]') WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue)
                            End If
                            DataObject(String.Format(SQL & "UPDATE acknowledgement_receipt SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE accounts_receivable SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}';", ID, .cbxProvider.SelectedValue, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Acknowledgement Receipt", "Approve", String.Format("Approved Acknowledgement Receipt of {0} with the total amount of {1}. [Via OTAC]", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                            Clear(True)
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
            If MsgBoxYes("Are you sure you want to approve this Acknowledgement Receipt?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = String.Format("UPDATE accounting_entry SET ORDate = '{1}', `Status` = 'ACTIVE', PostStatus = 'POSTED' WHERE CVNumber = '{0}' AND `status` = 'PENDING';", txtDocumentNumber.Text, Format(dtpPostingDate.Value, "yyyy-MM-dd"))

                If drv("Type") = "CAS" Then 'FROM CASH ADVANCE
                    SQL &= String.Format(" UPDATE cash_advance SET `status` = 'CANCELLED', Purpose = CONCAT(Purpose, '[Returned as Cash]') WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue)
                End If
                DataObject(String.Format(SQL & "UPDATE acknowledgement_receipt SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_receivable SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Acknowledgement Receipt", "Approve", String.Format("Approved Acknowledgement Receipt of {0} with the total amount of {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
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
        If MsgBoxYes("Are you sure you want to disapprove this Acknowledgement Receipt?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            Dim SQL As String = String.Format("UPDATE acknowledgement_receipt SET `status` = 'DISAPPROVED' WHERE ID = '{0}';", ID)
            If cbxCheckNumber.Tag <> "" Then
                SQL &= String.Format(" UPDATE check_received SET `status` = 'ACTIVE', Remarks = CONCAT(Remarks, ' [CANCELLED]') WHERE AssetNumber = '{0}' AND `Check` = '{1}' AND `status` = 'CLEARED';", cbxPayee.SelectedValue, cbxCheckNumber.Tag)
            End If
            SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'DISAPPROVED' WHERE CVNumber = '{0}' AND ReferenceN = '{1}';", txtDocumentNumber.Text, If(drv("Type") = "AR", drv("PayorID"), ValidateComboBox(cbxPayee)))
            SQL &= String.Format(" UPDATE accounts_receivable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_from SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_to SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE loans_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)

            If drv("Type") = "L" Then 'FROM LIQUIDATION
                SQL &= String.Format(" UPDATE liquidation_main SET AmountAcknowledged = IF(AmountAcknowledged - {1} <= 0, 0,AmountAcknowledged - {1}), Liq_Status = IF(AmountAcknowledged - {1} <= 0,'APPROVED','PARTIALLY ACKNOWLEDGED') WHERE AccountNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
            End If
            If drv("Type") = "CAS" Then 'FROM CASH ADVANCE
                SQL &= String.Format(" UPDATE cash_advance SET ACRNumber = '' WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue)
            End If
            If drv("Type") = "AP" Then 'FROM ACCOUNTS PAYABLE
                If MultipleAR Then
                    Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, (SELECT SUM(Amount) FROM cv_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_payable.DocumentNumber AND `status` = 'ACTIVE' AND Type = 'C') AS 'Paid' FROM accounts_payable WHERE DocumentNumber IN ({0});", AccountsReceivableID_M, txtDocumentNumber.Text))
                    For x As Integer = 0 To vDT.Rows.Count - 1
                        SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                    Next
                Else
                    SQL &= String.Format(" UPDATE accounts_payable SET Paid = IF(Paid - {1} <= 0, 0,Paid - {1}), AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                End If
            End If
            If drv("Type") = "AR" Then 'FROM ACCOUNTS RECEIVABLE
                If MultipleAR Then
                    Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, (SELECT SUM(Debit) FROM acr_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_receivable.DocumentNumber AND `status` = 'ACTIVE') AS 'Paid' FROM accounts_receivable WHERE DocumentNumber IN ({0});", AccountsReceivableID_M, txtDocumentNumber.Text))
                    For x As Integer = 0 To vDT.Rows.Count - 1
                        SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                    Next
                Else
                    SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                End If
            End If
            If drv("Type") = "DF" And If(From_Check, DFPayPrincipal, 1) Then 'FROM Due From
                If MultipleAR Then
                    Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, IFNULL((SELECT SUM(Debit) FROM acr_details WHERE DocumentNumber = '{1}' AND ReferenceN = due_from.DocumentNumber AND `status` = 'ACTIVE'),Paid) AS 'Paid' FROM due_from WHERE DocumentNumber IN ({0});", AccountsReceivableID_M, txtDocumentNumber.Text))
                    For x As Integer = 0 To vDT.Rows.Count - 1
                        SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                    Next
                Else
                    SQL &= String.Format(" UPDATE due_from SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", drv("AccountNumber"), dDebitT.Value)
                End If
                If cbxCheckNumber.Tag <> "" Then
                    SQL &= String.Format(" UPDATE dc_details SET `check_status` = 'ACTIVE', Remarks = CONCAT(Remarks, ' [DISAPPROVED]') WHERE DocumentNumber = '{0}' AND `CheckNumber` = '{1}' AND `check_status` = 'CLEARED';", drv("AccountNumber"), cbxCheckNumber.Tag)
                End If
            End If
            If drv("Type") = "RO" Then 'FROM ROPOA
                If cbxPayee.SelectedValue.ToString.Contains("ANV") Then
                    SQL &= String.Format(" UPDATE ropoa_vehicle SET sell_status = 'RESERVED' WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", drv("Phone"))
                Else
                    SQL &= String.Format(" UPDATE ropoa_realestate SET sell_status = 'RESERVED' WHERE TCT = '{0}' AND `status` = 'ACTIVE';", drv("Phone"))
                End If
            End If
            If drv("Type") = "LA" And drv("Amount") = 1 And (drv("AccountNumber") = "PAID" Or drv("AccountNumber") = "PARTIAL") Then ' FROM CREDIT APPLICATION WITH BILL DEDUCTABLES
                SQL &= String.Format("UPDATE credit_application SET BillDeductionsStatus = 'PENDING' WHERE CreditNumber = '{0}';", cbxPayee.SelectedValue)
            End If
            DataObject(SQL)
            Logs("Acknowledgement Receipt", "Disapprove", Reason, String.Format("Disapprove Acknowledgement Receipt of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "")
            Clear(True)
            LoadPayee()
            Cursor = Cursors.Default
            MsgBox("Successfully Disapproved", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub ICopy_Click(sender As Object, e As EventArgs) Handles iCopy.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        CopyMode = True

        ID = GridView1.GetFocusedRowCellValue("ID")
        dtpDocument.Value = GridView1.GetFocusedRowCellValue("Document Date")
        txtDocumentNumber.Text = GridView1.GetFocusedRowCellValue("Document Number")
        If GridView1.GetFocusedRowCellValue("Payee_Type") = "ARM" Then
            MultipleAR = True
            AccountsReceivableID_M = GridView1.GetFocusedRowCellValue("MultipleAR")
            btnAdd_Account.Enabled = False
            btnRemove_Account.Enabled = False
        ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "RO" Then
            lblAmount.Visible = True
            dPaidAmount.Visible = True
            lblRunningBalance.Visible = True
            dRunningBalance.Visible = True
            lblPayable.Visible = True
            dPayable.Visible = True
            dPaidAmount.Enabled = False
            dPaidAmount.Value = GridView1.GetFocusedRowCellValue("PaidAmount")
            dRunningBalance.Value = GridView1.GetFocusedRowCellValue("RunningBalance")
            dPayable.Value = GridView1.GetFocusedRowCellValue("Payable")
        End If
        cbxPayee.Enabled = False
        FirstLoad = True
        cbxLOE.Checked = False
        cbxAR.Checked = False
        cbxAP.Checked = False
        cbxDF.Checked = False
        cbxITL.Checked = False
        cbxRO.Checked = False
        cbxLA.Checked = False
        cbxCAS.Checked = False
        If GridView1.GetFocusedRowCellValue("Payee_Type") = "ARM" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "AR" Then
            cbxAR.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "APM" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "AP" Then
            cbxAP.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "L" Then
            cbxLOE.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "ITL" Then
            cbxITL.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "RO" Then
            cbxRO.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "DF" Then
            cbxDF.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "LA" Then
            cbxLA.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "CAS" Then
            cbxCAS.Checked = True
        End If
        LoadPayee()
        cbxLOE.Enabled = False
        cbxAR.Enabled = False
        cbxAP.Enabled = False
        cbxDF.Enabled = False
        cbxITL.Enabled = False
        cbxRO.Enabled = False
        cbxLA.Enabled = False
        cbxCAS.Enabled = False
        cbxPayee.Text = GridView1.GetFocusedRowCellValue("Payee")
        cbxPayee.Tag = GridView1.GetFocusedRowCellValue("Payee")

        FirstLoad = False
        cbxPayee.Enabled = True
        cbxBank.SelectedValue = GridView1.GetFocusedRowCellValue("BankID")
        cbxBank.Tag = GridView1.GetFocusedRowCellValue("Bank")
        dtpPostingDate.Value = Date.Now
        dtpPostingDate.Tag = GridView1.GetFocusedRowCellValue("Posting Date")
        txtReferenceNumber.Text = GridView1.GetFocusedRowCellValue("Reference Number")
        txtReferenceNumber.Tag = GridView1.GetFocusedRowCellValue("Reference Number")
        rExplanation.Text = GridView1.GetFocusedRowCellValue("Explanation")
        rExplanation.Tag = GridView1.GetFocusedRowCellValue("Explanation")
        DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = acr_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'PaidFor' FROM acr_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
        GridControl2.DataSource = DT_Account
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
        If GridView2.RowCount > 9 Then
            GridColumn32.Width = 342 - 17
        Else
            GridColumn32.Width = 342
        End If

        If GridView1.GetFocusedRowCellValue("Type") = "CASH" Then
            cbxCash.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("Type") = "CHECK" Then
            cbxCheck.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("Type") = "ONLINE" Then
            cbxOnline.Checked = True
        End If
        cbxCheckNumber.Text = GridView1.GetFocusedRowCellValue("CheckNumber")
        dtpCheck.Text = GridView1.GetFocusedRowCellValue("CheckDate").ToString
        txtDeposit.Text = GridView1.GetFocusedRowCellValue("DepositNumber")
        dtpDeposit.Text = GridView1.GetFocusedRowCellValue("DepositDate").ToString
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub IDeposit_Click(sender As Object, e As EventArgs) Handles iDeposit.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CLEARING" Then
                If MsgBoxYes("Acknowledgement is already FOR CLEARING, would you like to proceed?") = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
            ElseIf (GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL") Then
                MsgBox("Acknowledgement is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Type") = "ONLINE" Then
                MsgBox("Official Receipt is paid thru online, no need to deposit.", MsgBoxStyle.Information, "Info")
                Exit Sub
                'ElseIf GridView1.GetFocusedRowCellValue("Type") = "CHECK" Then
                '    MsgBox("Official Receipt is paid thru check, no need to deposit.", MsgBoxStyle.Information, "Info")
                '    Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Acknowledgement is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Acknowledgement is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "REVERSED" Then
                MsgBox("Acknowledgement is already REVERSED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED" Then
                MsgBox("Acknowledgement is already CLEARED.", MsgBoxStyle.Information, "Info")
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
                    SQL = String.Format("UPDATE acknowledgement_receipt SET DepositDate = '{1}' WHERE DocumentNumber IN ({0}) AND Voucher_Status = 'APPROVED';", Docs, FormatDatePicker(.dtpClear))
                Else
                    SQL = String.Format("UPDATE acknowledgement_receipt SET DepositDate = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), FormatDatePicker(.dtpClear))
                End If
                DataObject(SQL)
                Logs("Acknowledgement Receipt", "Deposit", String.Format("Deposit Acknowledgement Receipt of {0} with the total amount of {1}.", GridView1.GetFocusedRowCellValue("Payee") & " - " & GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Amount")), "", "", "", "")
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
                If MsgBoxYes("Acknowledgement is already CLEARED, would you like to proceed?") = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
            ElseIf (GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL") Then
                MsgBox("Acknowledgement is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Type") = "ONLINE" Then
                MsgBox("Official Receipt is paid thru online, no need to deposit.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Type") = "CASH" Then
                MsgBox("Official Receipt is paid thru cash, no need to deposit.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Acknowledgement is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Acknowledgement is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "REVERSED" Then
                MsgBox("Acknowledgement is already REVERSED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") <> "FOR CLEARING" Then
                MsgBox("Acknowledgement is not yet FOR CLEARING.", MsgBoxStyle.Information, "Info")
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
                    SQL = String.Format("UPDATE acknowledgement_receipt SET ClearDate = '{1}' WHERE DocumentNumber IN ({0}) AND Voucher_Status = 'APPROVED';", Docs, FormatDatePicker(.dtpClear))
                Else
                    SQL = String.Format("UPDATE acknowledgement_receipt SET ClearDate = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), FormatDatePicker(.dtpClear))
                End If
                DataObject(SQL)
                Logs("Acknowledgement Receipt", "Clear", String.Format("Clear Acknowledgement Receipt of {0} with the total amount of {1}.", GridView1.GetFocusedRowCellValue("Payee") & " - " & GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Amount")), "", "", "", "")
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
                MsgBox("Payment Type of selected Acknowledgement Receipt is not Check.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Acknowledgement Receipt is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Acknowledgement is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Acknowledgement is not yet APPROVED.", MsgBoxStyle.Information, "Info")
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
            Logs("Acknowledgement Receipt", "Bounce Check", "Journal Voucher", "", "", "", "")
            .cbxLA.Enabled = False
            .cbxCV.Enabled = False
            .cbxOR.Enabled = False
            .cbxAP.Enabled = False
            .cbxDT.Enabled = False
            .cbxDF.Enabled = False
            .cbxAR.Enabled = False
            .cbxAP.Enabled = False
            .cbxLOE.Enabled = False
            .cbxJV.Enabled = False
            .cbxACR.Enabled = False
            .cbxUR.Enabled = False
            .cbxDI.Enabled = False
            .cbxRS.Enabled = False
            .cbxITL.Enabled = False
            .cbxROPA.Enabled = False
            .cbxDTS.Enabled = False
            .cbxACR.Checked = True
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

    Private Sub DPaidAmount_ValueChanged(sender As Object, e As EventArgs) Handles dPaidAmount.ValueChanged
        If FirstLoad Or cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If drv("Type") = "ITL" Then
            Fill_ITL()
        ElseIf drv("Type") = "RO" Then
            FillAccounts()
        End If
    End Sub

    Private Sub FillAccounts()
        If FirstLoad Or cbxPayee.SelectedIndex = -1 Or dPaidAmount.Value = 0 Then
            Exit Sub
        End If
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)

        DT_Account.Rows.Clear()
        'DEBIT SUGGESTION
        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
        Dim TotalPayments As Double = DataObject(String.Format("SELECT ROPOA_Payment('{0}','{1}');", cbxPayee.SelectedValue, drv("PayorID")))
        Dim SoldAmount As Double = DataObject(String.Format("SELECT Amount FROM sold_ropoa WHERE ID = '{0}';", drv("PayorID")))
        '****************************************************** F U L L   P A Y M E N T ****************************************
        If TotalPayments = 0 Then
            TotalPayments += dPaidAmount.Value
            If SoldAmount * 0.8 <= TotalPayments Then
                'CREDIT SUGGESTION
                If dPaidAmount.Value < dPayable.Value And dPaidAmount.Value < dRunningBalance.Value Then
                    'PAYMENT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", If(drv("Mortgage") = 2, "126001", "126003"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    Dim BalanceTransferred As Double = DataObject(If(drv("Mortgage") = 1, (String.Format("SELECT BalanceTransferred FROM ropoa_vehicle WHERE AssetNumber = '{0}'", cbxPayee.SelectedValue)), (String.Format("SELECT BalanceTransferred FROM ropoa_realestate WHERE AssetNumber = '{0}'", cbxPayee.SelectedValue))))
                    If dPaidAmount.Value - dRunningBalance.Value > 0 Then
                        'GAIN ON SALE CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620003", "620004")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, BalanceTransferred + dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPayable.Value - dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPayable.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ElseIf dRunningBalance.Value >= dPayable.Value And dRunningBalance.Value > dPaidAmount.Value Then
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPayable.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED DEBIT
                        If BalanceTransferred - SoldAmount > 0 Then
                            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", BalanceTransferred - SoldAmount, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                    End If
                    'ROPA CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", "126001")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, BalanceTransferred - dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")

                ElseIf dRunningBalance.Value = 0 Then
                    'GAIN ON SALE
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620003", "620004")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                ElseIf dRunningBalance.Value >= dPayable.Value And dPaidAmount.Value >= dPayable.Value Then
                    'PAYMENT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", "126001")))
                    If dPaidAmount.Value = dRunningBalance.Value Then
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    Else
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dRunningBalance.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                    If dRunningBalance.Value > dPayable.Value And dPaidAmount.Value >= dPayable.Value And dPaidAmount.Value - dRunningBalance.Value > 0 Then
                        'GAIN ON SALE
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620003", "620004")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value - dRunningBalance.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ElseIf dRunningBalance.Value > dPayable.Value And dPaidAmount.Value < dRunningBalance.Value And dPaidAmount.Value - dPayable.Value >= 0 Then
                        'LOSS ON SALE
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620001", "620002")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dRunningBalance.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                ElseIf dRunningBalance.Value <= dPayable.Value And dPaidAmount.Value >= dRunningBalance.Value Then
                    'PAYMENT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", "126001")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dRunningBalance.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    If dPaidAmount.Value > dRunningBalance.Value Then
                        'GAIN ON SALE
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620003", "620004")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value - dRunningBalance.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED CREDIT
                        If dPayable.Value - dPaidAmount.Value > 0 Then
                            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPayable.Value - dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                        'ACCOUNTS RECEIVABLE DEBIT
                        If dPayable.Value - dPaidAmount.Value > 0 Then
                            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPayable.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                    End If
                End If
                GoTo HERE
            End If
        End If
        '****************************************************** F U L L   P A Y M E N T ****************************************
        Dim TotalAP As Double = DataObject(String.Format("SELECT IFNULL(SUM(Amount),0) FROM accounting_entry WHERE `status` IN ('PENDING','ACTIVE') AND EntryType = 'CREDIT' AND AccountCode = '218002' AND ReferenceN = '{0}' AND JVNumber = '' AND JVNum = '';", cbxPayee.SelectedValue))
        'CREDIT SUGGESTION
        If dPaidAmount.Value < dPayable.Value And dPaidAmount.Value < dRunningBalance.Value Then
            Dim BalanceTransferred As Double = DataObject(If(drv("Mortgage") = 1, (String.Format("SELECT BalanceTransferred FROM ropoa_vehicle WHERE AssetNumber = '{0}'", cbxPayee.SelectedValue)), (String.Format("SELECT BalanceTransferred FROM ropoa_realestate WHERE AssetNumber = '{0}'", cbxPayee.SelectedValue))))
            'GAIN ON SALE
            If SoldAmount * 0.8 <= TotalPayments Then
                'ACCOUNTS RECEIVABLE
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                TotalPayments += dPaidAmount.Value
                If SoldAmount * 0.8 <= TotalPayments Then
                    ''ROPA CREDIT
                    'ACCOUNTS PAYABLE DEBIT
                    If TotalAP > 0 Then
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", TotalAP, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                    If dPaidAmount.Value - (dRunningBalance.Value - TotalAP) > 0 Then
                        'GAIN ON SALE CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620003", "620004")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, (TotalAP - BalanceTransferred) + dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPayable.Value - dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPayable.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ElseIf dRunningBalance.Value > dPayable.Value Then
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPayable.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", BalanceTransferred - SoldAmount, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                    'ROPA CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", "126001")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, BalanceTransferred, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                Else
                    'ACCOUNTS PAYABLE CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
            End If
        ElseIf dRunningBalance.Value = 0 Then
            Dim BalanceTransferred As Double = DataObject(If(drv("Mortgage") = 1, (String.Format("SELECT BalanceTransferred FROM ropoa_vehicle WHERE AssetNumber = '{0}'", cbxPayee.SelectedValue)), (String.Format("SELECT BalanceTransferred FROM ropoa_realestate WHERE AssetNumber = '{0}'", cbxPayee.SelectedValue))))
            'GAIN ON SALE
            If SoldAmount * 0.8 <= TotalPayments Then
                'ACCOUNTS RECEIVABLE
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                'ACCOUNTS PAYABLE DEBIT
                If TotalAP > 0 Then
                    '------ YOUR HERE ------
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", TotalAP, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'ROPA CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", "126001")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, BalanceTransferred, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
                If dPaidAmount.Value - (dRunningBalance.Value - TotalAP) > 0 Then
                    'GAIN ON SALE CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620003", "620004")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value - (dRunningBalance.Value - TotalAP), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    If dRunningBalance.Value > 0 Then
                        'UNREALIZED CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPayable.Value - dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPayable.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                ElseIf dRunningBalance.Value > dPayable.Value Then
                    'LOSS ON SALE DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620001", "620002")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dRunningBalance.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ''UNREALIZED DEBIT
                End If
            End If
        ElseIf dRunningBalance.Value >= dPayable.Value And dPaidAmount.Value >= dPayable.Value Then
            'PAYMENT
            If SoldAmount * 0.8 <= TotalPayments Then
                'ACCOUNTS RECEIVABLE
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                'ROPA CREDIT
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", "126001")))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dRunningBalance.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                If TotalAP > 0 Then
                    'ACCOUNTS PAYABLE DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", TotalAP, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'ROPA CREDIT
                    If SoldAmount = TotalAP + dPayable.Value Then
                    Else
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", "126001")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, TotalAP, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                End If
                If dPaidAmount.Value - (dRunningBalance.Value - TotalAP) > 0 Then
                    'GAIN ON SALE CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620003", "620004")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value - (dRunningBalance.Value - TotalAP), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    If dPaidAmount.Value >= dRunningBalance.Value Then
                    Else
                        If dPayable.Value - dPaidAmount.Value > 0 Then     'UNREALIZED CREDIT
                            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPayable.Value - dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                            'ACCOUNTS RECEIVABLE DEBIT
                            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPayable.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")

                        End If
                    End If
                ElseIf dRunningBalance.Value > dPayable.Value + TotalAP Then
                    'LOSS ON SALE DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620001", "620002")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dRunningBalance.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ''UNREALIZED DEBIT
                End If
            End If
        ElseIf dRunningBalance.Value <= dPayable.Value And dPaidAmount.Value >= dRunningBalance.Value Then
            'PAYMENT
            If SoldAmount * 0.8 <= TotalPayments Then
                'ACCOUNTS RECEIVABLE
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                'ROPA CREDIT
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", "126001")))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dRunningBalance.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                If TotalAP > 0 Then
                    'ACCOUNTS PAYABLE DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", TotalAP, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'ROPA CREDIT
                    If dPaidAmount.Value >= dRunningBalance.Value Then
                    Else
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "126002", "126001")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, TotalAP, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                End If
                If dPaidAmount.Value - (dRunningBalance.Value - TotalAP) > 0 Then
                    'GAIN ON SALE CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620003", "620004")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPaidAmount.Value - (dRunningBalance.Value - TotalAP), "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'UNREALIZED CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, dPayable.Value - dPaidAmount.Value, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'ACCOUNTS RECEIVABLE DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dPayable.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                ElseIf dRunningBalance.Value > dPayable.Value Then
                    'LOSS ON SALE DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Mortgage") = 1, "620001", "620002")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", dRunningBalance.Value - dPaidAmount.Value, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ''UNREALIZED DEBIT
                End If
            End If
        End If

HERE:
        GridControl2.DataSource = DT_Account
        Dim TotalDebitX As Double
        Dim TotalCreditX As Double
        Dim Total_CIB As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebitX += CDbl(DT_Account(x)("Debit"))
            TotalCreditX += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                Total_CIB += CDbl(DT_Account(x)("Debit"))
            End If
        Next
        If GridView2.RowCount > 5 Then
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342 - 17
            Else
                GridColumn32.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn20.Visible = False Then
                GridColumn32.Width = 342
            Else
                GridColumn32.Width = (342 - 80)
            End If
        End If
        dDebitT.Value = TotalDebitX
        dCreditT.Value = TotalCreditX
        dAmount.Value = Total_CIB
    End Sub

    Public Sub LoadCompanyMode()
        If CompanyMode = 0 Then
            cbxAccount.DataSource = DT_AccountsM.Copy
            RepositoryItemSearchLookUpEdit1.DataSource = DT_AccountsM_V2.Copy
        Else
            cbxAccount.DataSource = DT_Accounts.Copy
            RepositoryItemSearchLookUpEdit1.DataSource = DT_Accounts_V2.Copy
        End If
    End Sub

    Private Sub CbxCheckNumber_Leave(sender As Object, e As EventArgs) Handles cbxCheckNumber.Leave
        cbxCheckNumber.Text = ReplaceText(cbxCheckNumber.Text)
    End Sub

    Private Sub TxtDeposit_Leave(sender As Object, e As EventArgs) Handles txtDeposit.Leave
        txtDeposit.Text = ReplaceText(txtDeposit.Text)
    End Sub

    Private Sub TxtReferenceNumber_Leave(sender As Object, e As EventArgs) Handles txtReferenceNumber.Leave
        txtReferenceNumber.Text = ReplaceText(txtReferenceNumber.Text)
    End Sub

    Private Sub CbxBusinessCenter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBusinessCenter.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "BusinessCode", cbxBusinessCenter.SelectedValue)
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

    Private Sub CbxCheckNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCheckNumber.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxCheckNumber.SelectedIndex = -1 Or cbxCheckNumber.Text = "" Then
            dtpCheck.Value = Date.Now
            dPaidAmount.Enabled = True
            dtpCheck.Enabled = True
        Else
            Dim drv As DataRowView = DirectCast(cbxCheckNumber.SelectedItem, DataRowView)
            dtpCheck.Value = drv("Date")
            dtpCheck.Enabled = False
            If cbxCheck.Checked Then
                dPaidAmount.Value = drv("Amount")
                dPaidAmount.Enabled = False
            Else
                dPaidAmount.Enabled = True
            End If
        End If
    End Sub

    Private Sub CbxCheckNumber_TextChanged(sender As Object, e As EventArgs) Handles cbxCheckNumber.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxCheck.Checked Then
            If cbxCheckNumber.SelectedIndex = -1 Or cbxCheckNumber.Text = "" Then
                dPaidAmount.Enabled = True
            Else
                dPaidAmount.Enabled = False
            End If
        Else
            dPaidAmount.Enabled = True
        End If
    End Sub

    Private Sub IROPA_Ledger_Click(sender As Object, e As EventArgs) Handles iROPA_Ledger.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") <> "RO" Then
                MsgBox("Only ROPA Transaction can open the ROPA Ledger.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim AssetNumber As String
        Dim DT_AssetDetails As DataTable
        If GridView1.GetFocusedRowCellValue("Payee_ID").ToString.Contains("ANV") Then
            DT_AssetDetails = DataSource(String.Format("SELECT Account_Count, PlateNum AS 'Reference' FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND AssetNumber = '{0}';", GridView1.GetFocusedRowCellValue("Payee_ID")))
        Else
            DT_AssetDetails = DataSource(String.Format("SELECT Account_Count, TCT AS 'Reference' FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND AssetNumber = '{0}';", GridView1.GetFocusedRowCellValue("Payee_ID")))
        End If
        If CInt(DT_AssetDetails(0)("Account_Count")) > 1 Then
            Dim AccountList As New FrmAccountList
            With AccountList
                .DT_Account = DataSource(String.Format("SELECT AccountNo, AssetNumber FROM ropoa_vehicle WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", DT_AssetDetails(0)("Reference")))
                If .ShowDialog = DialogResult.OK Then
                    AssetNumber = .AssetNumber
                Else
                    Exit Sub
                End If
            End With
        Else
            AssetNumber = GridView1.GetFocusedRowCellValue("Payee_ID")
        End If

        Dim History As New FrmROPOALedger
        With History
            .Tag = 53
            .AssetNumber = AssetNumber
            .MultipleA = CInt(DT_AssetDetails(0)("Account_Count"))
            .ROPOA_Ref = DT_AssetDetails(0)("Reference")

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

            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub IITL_Click(sender As Object, e As EventArgs) Handles iITL.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") <> "ITL" Then
                MsgBox("Only ITL Transaction can open the ITL Ledger.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmCaseLedger
        With Ledger
            Dim SQL As String = "SELECT M.ID,"
            SQL &= "    M.CreditNumber,"
            SQL &= "    IF(Old_Account = 1,Borrower(M.BorrowerID),CONCAT(Borrower_Credit (M.CreditNumber), ' [', AccountNumber(M.CreditNumber),']')) AS 'Borrower',"
            SQL &= "    M.AccountNumber AS 'Account Number',"
            SQL &= "    M.CaseNumber AS 'Case Number',"
            SQL &= "    DATE_FORMAT(M.DateFilled, '%M %d, %Y') AS 'Date Filled',"
            SQL &= "    Ledger_Balance(M.AccountNumber,M.MortgageID) AS 'Book Value',"
            SQL &= "    M.DecisionValue AS 'Decision Value',"
            SQL &= "    Collateral, AccountNumber(M.CreditNumber) AS 'AccountNum', (SELECT Mobile_B FROM profile_borrower WHERE profile_borrower.BorrowerID = M.BorrowerID) AS 'Mobile', DueRP, M.CategoryID"
            SQL &= String.Format("  FROM case_main M WHERE M.`status` = 'ACTIVE' AND AccountNumber = '{0}';", GridView1.GetFocusedRowCellValue("Payee_ID"))
            Dim DT_ITL As DataTable = DataSource(SQL)

            .txtCaseNumber.Text = DT_ITL(0)("Case Number")
            .dtpDateFilled.Value = DT_ITL(0)("Date Filled")
            .txtDefendant.Text = DT_ITL(0)("Borrower")
            .dBookValue.Value = DT_ITL(0)("Book Value")
            .dDecisionValue.Value = DT_ITL(0)("Decision Value")
            .txtCollateral.Text = DT_ITL(0)("Collateral")
            .txtAccountNumber.Text = DT_ITL(0)("AccountNum")
            .txtMobileNumber.Text = DT_ITL(0)("Mobile")
            If DT_ITL(0)("DueRP") = "" Then
                .dtpDueRP.CustomFormat = ""
            Else
                .dtpDueRP.CustomFormat = "MMMM dd, yyyy"
                .dtpDueRP.Value = DT_ITL(0)("DueRP")
            End If
            .CaseNumber = DT_ITL(0)("Account Number")
            .CaseID = DT_ITL(0)("ID")
            .CategoryID = DT_ITL(0)("CategoryID")

            If DT_ITL(0)("Decision Value") = 0 Then
                .cbxTransaction.Items.Clear()
                .cbxTransaction.Items.Add("Charges")
                .cbxTransaction.Items.Add("Others")
            End If
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub IJV_Click(sender As Object, e As EventArgs) Handles iJV.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Acknowledgement Receipt is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Acknowledgement is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Acknowledgement is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Acknowledgement is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CLEARING" Then
                If MsgBoxYes("Official Receipt is already FOR CLEARING, would you like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
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
            Logs("Acknowledgement Receipt", "Journal Voucher", "Journal Voucher", "", "", "", "")
            .cbxLA.Enabled = False
            .cbxCV.Enabled = False
            .cbxOR.Enabled = False
            .cbxAP.Enabled = False
            .cbxDT.Enabled = False
            .cbxDF.Enabled = False
            .cbxAR.Enabled = False
            .cbxAP.Enabled = False
            .cbxLOE.Enabled = False
            .cbxJV.Enabled = False
            .cbxACR.Enabled = False
            .cbxUR.Enabled = False
            .cbxDI.Enabled = False
            .cbxRS.Enabled = False
            .cbxITL.Enabled = False
            .cbxROPA.Enabled = False
            .cbxDTS.Enabled = False
            .cbxACR.Checked = True
            .From_ACR = True
            .BankID = GridView1.GetFocusedRowCellValue("BankID")
            .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("ID")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
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
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Updated Acknowledgement Receipt of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If DT_Signatory(x)("Phone") = "" Then
                    Else
                        SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If DT_Signatory(x)("EmailAdd") = "" Then
                    Else
                        EmailTo &= DT_Signatory(x)("EmailAdd") & ", "
                    End If
                End If
            Next
            If EmailTo = "" Then
            Else
                Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "] [UPDATE]"
                AttachmentFiles = New ArrayList()
                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                Generate_Receipt(False, FName, txtChecked.Text, txtApproved.Text)
                AttachmentFiles.Add(FName)
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
            End If
            'F O R   C H E C K I N G************************************************************************************************************************
        ElseIf txtApproved.Text = "" Then
            'F O R   A P P R O V A L ***********************************************************************************************************************
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Updated Acknowledgement Receipt of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If DT_Signatory(x)("Phone") = "" Then
                    Else
                        SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If DT_Signatory(x)("EmailAdd") = "" Then
                    Else
                        EmailTo &= DT_Signatory(x)("EmailAdd") & ", "
                    End If
                End If
            Next
            If EmailTo = "" Then
            Else
                Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "] [UPDATE]"
                AttachmentFiles = New ArrayList() 'JUST ADDED UNDER OBSERVATION
                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                Generate_Receipt(False, FName, txtChecked.Text, txtApproved.Text)
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
        Dim Subject As String
        Dim FName As String
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Acknowledgement Receipt of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
                Msg &= "Thank you!"
                '******* SEND SMS *********************************************************************************
                If DT_Signatory(x)("Phone") = "" Then
                Else
                    SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                End If
                '******* SEND EMAIL *********************************************************************************
                If DT_Signatory(x)("EmailAdd") = "" Then
                Else
                    EmailTo &= DT_Signatory(x)("EmailAdd") & ", "
                End If
            End If
        Next
        If EmailTo = "" Then
        Else
            Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
            AttachmentFiles = New ArrayList() 'JUST ADDED UNDER OBSERVATION
            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
            Generate_Receipt(False, FName, txtChecked.Text, txtApproved.Text)
            AttachmentFiles.Add(FName)
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
        End If
    End Sub

    Private Sub ApproveNotification(xCode As String, SendMail As Boolean)
        Code = xCode
        Code_Approve = Code
        Dim Msg As String = ""
        Dim EmailTo As String = ""
        Dim Subject As String
        Dim FName As String
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Acknowledgement Receipt of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
                Msg &= "Thank you!"
                '******* SEND SMS *********************************************************************************
                If DT_Signatory(x)("Phone") = "" Then
                Else
                    SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                End If
                '******* SEND EMAIL *********************************************************************************
                If DT_Signatory(x)("EmailAdd") = "" Then
                Else
                    EmailTo &= DT_Signatory(x)("EmailAdd") & ", "
                End If
            End If
        Next
        If EmailTo = "" Then
        Else
            Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
            AttachmentFiles = New ArrayList() 'JUST ADDED UNDER OBSERVATION
            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
            Generate_Receipt(False, FName, txtChecked.Text, txtApproved.Text)
            AttachmentFiles.Add(FName)
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
        End If
    End Sub

    Private Sub CbxBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBank.SelectedIndexChanged
        If FirstLoad = False Then
            If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
            Else
                Dim WithAccount As Boolean
                Dim NumberOfAccount As Integer
                Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "Account Code") <> "" Then
                        NumberOfAccount += 1
                    End If
                    If GridView2.GetRowCellValue(x, "MotherCode") = "111000" Then
                        WithAccount = True
                    End If

                    If GridView2.GetRowCellValue(x, "MotherCode") = "111000" And GridView2.GetRowCellValue(x, "Credit") = 0 And GridView2.GetRowCellValue(x, "Debit") > 0 And GridView2.GetRowCellValue(x, "Account Code") <> drv_B("AccountCode") Then
                        AccountCodeDetails(drv_B("AccountCode"))
                        If DT_Temp_Account.Rows.Count > 0 Then
                            DT_Account(x)("Account Code") = DT_Temp_Account(0)("Code")
                            DT_Account(x)("Account") = DT_Temp_Account(0)("Account")
                            DT_Account(x)("RequiredRemarks") = DT_Temp_Account(0)("RequiredRemarks")
                            DT_Account(x)("MotherCode") = DT_Temp_Account(0)("MotherCode")
                        End If
                    End If
                Next
                If NumberOfAccount <= 1 And If(NumberOfAccount = 1, WithAccount, WithAccount = False) And drv_B("AccountCode") <> "" Then
                    DT_Account.Rows.Clear()
                    AccountCodeDetails(drv_B("AccountCode"))
                    If DT_Temp_Account.Rows.Count > 0 Then
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")
                    DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", 0, "", "")

                    If GridView2.RowCount > 5 Then
                        If GridColumn20.Visible = False Then
                            GridColumn32.Width = 342 - 17
                        Else
                            GridColumn32.Width = (342 - 80) - 17
                        End If
                    Else
                        If GridColumn20.Visible = False Then
                            GridColumn32.Width = 342
                        Else
                            GridColumn32.Width = (342 - 80)
                        End If
                    End If
                End If
            End If
        End If

        If FirstLoad Or cbxPayee.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If drv("Type") = "ITL" Then
            Fill_ITL()
        ElseIf drv("Type") = "RO" Then
            FillAccounts()
        End If
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
            Exit Sub
        End If

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = cbxPayee.SelectedValue
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnReference_Click(sender As Object, e As EventArgs) Handles btnReference.Click
        GridView1.SetFocusedRowCellValue("Reference Number", UpdateReferenceNumber("Acknowledgement Receipt", "acknowledgement_receipt", GridView1.GetFocusedRowCellValue("Reference Number"), GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Document Number")))
    End Sub
End Class