Imports DevExpress.XtraReports.UI
Public Class FrmJournalVoucher

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public FirstLoad As Boolean = True
    Public DefaultBank As Integer
    Dim DT_Account As New DataTable
    Dim Code As String

    Dim Code_Check As String
    Dim Code_Approve As String
    Dim User_EmplID As Integer
    Dim Liq_ID As Integer
    Dim CopyMode As Boolean
    Public From_GL As Boolean
    Public GL_DocumentNumber As String
    Public From_ACR As Boolean
    Public BankID As Integer
    Dim Temp_DT As DataTable
    Public From_Check As Boolean
    Public DTPayPrincipal As Boolean
    Public CheckID As Integer
    Public CheckAmount As Double
    Public DueToDocumentNumber As String
    Public From_ROPOA As Boolean
    Public ROPOA_ForSell As Boolean
    Public From_Case As Boolean
    Public From_LOE As Boolean
    Public Case_Debit As String
    Public Case_Credit_LR As String
    Public Case_Credit_Interest As String
    Public Case_Credit_RPPD As String
    Public Case_BV As Double
    Public Case_Principal As Double
    Public Case_Interest As Double
    Public Case_RPPD As Double
    Public Case_OldAccount As Boolean
    Public From_ITL As Boolean
    Public From_ITL_Reverse As Boolean
    Public MortgageID As Integer
    Public From_Impairment As Boolean
    Public From_Ledger As Boolean
    Dim AccountNumberRestructuring As String
    Dim Flag As Boolean = False
    Public BounceID As Integer
    Public Bounce As String
    Public BounceRemarks As String
    Public DueToID_M As String
    Public MultipleDT As Boolean
    Public Skip_FilterLoadData As Boolean
    Public DTS_From_CV As Boolean
    Dim AvailedRPPD As Double
    Dim Refinance As Boolean
    Dim CVforJV As Boolean
    Dim TotalAdvance As Double

    Private Sub FrmJournalVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView4})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If From_GL Then
            cbxAll.Checked = True
        End If
        If From_ACR Or From_Check Or From_LOE Then
        Else
            SuperTabControl1.SelectedTab = tabList
            LoadData()
        End If
        cbxDisplay.SelectedIndex = 0
        dtpDocument.Value = Date.Now
        dtpPostingDate.Value = Date.Now
        If User_Type = "ADMIN" Then
        Else
            dtpPostingDate.MaxDate = Date.Now
        End If

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

        With RepositoryItemLookUpEdit1
            .DisplayMember = "Paid For"
            .ValueMember = "Paid For"
            .DataSource = DataSource("SELECT 'CIB' AS 'Paid For' UNION SELECT 'Billing' UNION SELECT 'Penalty' UNION SELECT 'RPPD' UNION SELECT 'UDI' UNION SELECT 'Principal' UNION SELECT 'Other Income' UNION SELECT ''")
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

        With RepositoryItemLookUpEdit3
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

        With RepositoryItemLookUpEdit4
            .DisplayMember = "BusinessCenter"
            .ValueMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter_V2.Copy
        End With

        Dim DT_Status As DataTable = DataSource("SELECT 'For Checking' AS 'Status' UNION SELECT 'For Approval' UNION SELECT 'Approved' UNION SELECT 'Cancelled'")
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

        If From_Check Or From_ROPOA Or From_ITL Or From_Impairment Or From_Ledger Or From_Case Then
        Else
            LoadPayee()
        End If
        GetDocumentNumber()
        FirstLoad = False

        If From_GL Then
            Dim i As Integer = 0
            Dim Found As Boolean = False
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Document Number") = GL_DocumentNumber Then
                    i = x
                    Found = True
                    Exit For
                End If
            Next
            If Found = False Then
                MsgBox("No Journal Voucher Found!", MsgBoxStyle.Information, "Info")
                Close()
            End If
            GridView1.FocusedRowHandle = i
            GridView1_DoubleClick(sender, e)
            btnRefresh.Enabled = False
            btnNext.Enabled = False
            tabList.Visible = False
        ElseIf From_ACR Or From_LOE Then
            cbxACR.Enabled = False
            cbxLA.Enabled = False
            cbxCV.Enabled = False
            cbxOR.Enabled = False
            cbxAP.Enabled = False
            cbxDT.Enabled = False
            cbxDF.Enabled = False
            cbxAR.Enabled = False
            cbxLOE.Enabled = False
            cbxJV.Enabled = False
            cbxUR.Enabled = False
            cbxDI.Enabled = False
            cbxRS.Enabled = False
            cbxITL.Enabled = False
            cbxROPA.Enabled = False
            cbxDTS.Enabled = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False
            cbxBank.SelectedValue = BankID
            If cbxPayee.SelectedValue = GL_DocumentNumber Then
                CbxPayee_SelectedIndexChanged(sender, e)
            Else
                cbxPayee.SelectedValue = GL_DocumentNumber
            End If
            cbxPayee.Enabled = False
            tabList.Visible = False
        ElseIf From_Check Then
            cbxACR.Enabled = False
            cbxLA.Enabled = False
            cbxCV.Enabled = False
            cbxOR.Enabled = False
            cbxAP.Enabled = False
            cbxDT.Enabled = False
            cbxDF.Enabled = False
            cbxAR.Enabled = False
            cbxLOE.Enabled = False
            cbxJV.Enabled = False
            cbxUR.Enabled = False
            cbxDI.Enabled = False
            cbxRS.Enabled = False
            cbxITL.Enabled = False
            cbxROPA.Enabled = False
            cbxDTS.Enabled = False
            cbxBank.SelectedValue = BankID
            Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
            cbxPayee.Enabled = False
            tabList.Visible = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False

            If MultipleDT Then
                Dim SQL As String = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber'"
                DT_Account = DataSource(SQL)
                GridControl2.DataSource = DT_Account
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                Dim DT_Checks As DataTable = DataSource(String.Format("SELECT ID, DocumentNumber, CheckNumber, CheckDate, Amount, Remarks FROM dc_details WHERE ID IN ({0}) AND `status` = 'ACTIVE';", If(CheckID = 0, DueToID_M, CheckID)))
                Dim TotalCreditMultiple As Double
                For z As Integer = 0 To DT_Checks.Rows.Count - 1
                    'DEBIT
                    Dim AR_Account As String '= DataObject(String.Format("SELECT AccountCode FROM dt_details WHERE DocumentNumber = '{0}' AND Credit > 0 AND `status` = 'ACTIVE' LIMIT 1;", DT_Checks(z)("DocumentNumber")))
                    If DataObject(String.Format("SELECT Payee_Type FROM due_to WHERE DocumentNumber = '{0}';", DT_Checks(z)("DocumentNumber"))) = "B" Then
                        AR_Account = "520001"
                    Else
                        AR_Account = "520002"
                    End If
                    AccountCodeDetails(AR_Account)
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", DT_Checks(z)("Amount"), 0, "", DT_Checks(z)("DocumentNumber") & " [" & DT_Checks(z)("CheckNumber") & "] (" & FormatNumber(DT_Checks(z)("Amount"), 2) & ")" & DT_Checks(z)("Remarks"), DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), DT_Checks(z)("DocumentNumber"))
                    TotalCreditMultiple += CDbl(DT_Checks(z)("Amount"))
                Next
                'CREDIT
                AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, TotalCreditMultiple, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                Dim AR_Account As String = DataObject(String.Format("SELECT AccountCode FROM dt_details WHERE DocumentNumber = '{0}' AND Credit > 0 AND `status` = 'ACTIVE' LIMIT 1;", DueToDocumentNumber))
                If DTPayPrincipal Then
                Else
                    If DataObject(String.Format("SELECT Payee_Type FROM due_to WHERE DocumentNumber = '{0}';", DueToDocumentNumber)) = "B" Then
                        AR_Account = "520001"
                    Else
                        AR_Account = "520002"
                    End If
                End If
                Dim SQL As String
                SQL = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber'"
                DT_Account = DataSource(SQL)
                GridControl2.DataSource = DT_Account
                DT_Account.Rows.Clear()
                'DEBIT
                AccountCodeDetails(AR_Account)
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CheckAmount, 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                'CREDIT
                AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            End If

            Dim TotalDebitX As Double
            Dim TotalCreditX As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebitX += CDbl(DT_Account(x)("Debit"))
                TotalCreditX += CDbl(DT_Account(x)("Credit"))
            Next
            dDebitT.Value = TotalDebitX
            dCreditT.Value = TotalCreditX
            FirstLoad = True
            cbxPayee.Text = cbxPayee.Tag
            FirstLoad = False
        ElseIf From_ROPOA Then
            cbxACR.Enabled = False
            cbxLA.Enabled = False
            cbxCV.Enabled = False
            cbxOR.Enabled = False
            cbxAP.Enabled = False
            cbxDT.Enabled = False
            cbxDF.Enabled = False
            cbxAR.Enabled = False
            cbxLOE.Enabled = False
            cbxJV.Enabled = False
            cbxUR.Enabled = False
            cbxDI.Enabled = False
            cbxRS.Enabled = False
            cbxITL.Enabled = False
            cbxROPA.Enabled = False
            cbxDTS.Enabled = False
            cbxBank.SelectedValue = BankID
            cbxPayee.Enabled = False
            tabList.Visible = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False
            txtReferenceNumber.Enabled = False

            DT_Account.Rows.Clear()
            If txtReferenceNumber.Tag.ToString.Contains("ANV") Then
                If ROPOA_ForSell Then
                    'DEBIT
                    AccountCodeDetails("126002")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CheckAmount, 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'CREDIT
                    AccountCodeDetails("124006")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                Else
                    'DEBIT
                    AccountCodeDetails("124006")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CheckAmount, 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'CREDIT
                    AccountCodeDetails("126002")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
            Else
                If ROPOA_ForSell Then
                    'DEBIT
                    AccountCodeDetails("126001")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CheckAmount, 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'CREDIT
                    AccountCodeDetails("124001")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                Else
                    'DEBIT
                    AccountCodeDetails("124001")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CheckAmount, 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'CREDIT
                    AccountCodeDetails("126001")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
            End If

            Dim TotalDebitX As Double
            Dim TotalCreditX As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebitX += CDbl(DT_Account(x)("Debit"))
                TotalCreditX += CDbl(DT_Account(x)("Credit"))
            Next
            dDebitT.Value = TotalDebitX
            dCreditT.Value = TotalCreditX
            FirstLoad = True
            cbxPayee.Text = cbxPayee.Tag
            txtReferenceNumber.Text = txtReferenceNumber.Tag
            FirstLoad = False
        ElseIf From_Impairment Then
            cbxACR.Enabled = False
            cbxLA.Enabled = False
            cbxCV.Enabled = False
            cbxOR.Enabled = False
            cbxAP.Enabled = False
            cbxDT.Enabled = False
            cbxDF.Enabled = False
            cbxAR.Enabled = False
            cbxLOE.Enabled = False
            cbxJV.Enabled = False
            cbxUR.Enabled = False
            cbxDI.Enabled = False
            cbxRS.Enabled = False
            cbxITL.Enabled = False
            cbxROPA.Enabled = False
            cbxDTS.Enabled = False
            cbxBank.SelectedValue = BankID
            cbxPayee.Enabled = False
            tabList.Visible = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False
            txtReferenceNumber.Enabled = False

            DT_Account.Rows.Clear()
            If txtReferenceNumber.Tag.ToString.Contains("ANV") Then
                'DEBIT
                AccountCodeDetails("620063")
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CheckAmount, 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                'CREDIT
                AccountCodeDetails("126002")
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                'DEBIT
                AccountCodeDetails("620063")
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CheckAmount, 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                'CREDIT
                AccountCodeDetails("126001")
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            End If

            Dim TotalDebitX As Double
            Dim TotalCreditX As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebitX += CDbl(DT_Account(x)("Debit"))
                TotalCreditX += CDbl(DT_Account(x)("Credit"))
            Next
            dDebitT.Value = TotalDebitX
            dCreditT.Value = TotalCreditX
            FirstLoad = True
            cbxPayee.Text = cbxPayee.Tag
            txtReferenceNumber.Text = txtReferenceNumber.Tag
            FirstLoad = False
        ElseIf From_Ledger Then
            cbxACR.Enabled = False
            cbxLA.Enabled = False
            cbxCV.Enabled = False
            cbxOR.Enabled = False
            cbxAP.Enabled = False
            cbxDT.Enabled = False
            cbxDF.Enabled = False
            cbxAR.Enabled = False
            cbxLOE.Enabled = False
            cbxJV.Enabled = False
            cbxLA.Checked = True
            cbxUR.Enabled = False
            cbxDI.Enabled = False
            cbxRS.Enabled = False
            cbxITL.Enabled = False
            cbxROPA.Enabled = False
            cbxDTS.Enabled = False
            cbxBank.SelectedValue = BankID
            cbxPayee.Enabled = False
            tabList.Visible = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False
            txtReferenceNumber.Enabled = False

            DT_Account.Rows.Clear()
            Dim Collateral As DataTable
            If MortgageID = 1 Then
                'DEBIT
                Collateral = DataSource(String.Format("SELECT * FROM (SELECT CollateralNumber, selling_price, market_value, appraised_value, loanable_value, (SELECT CONCAT(Make, ' ', PlateNum) FROM collateral_ve WHERE CollateralNumber = appraise_ve.`CollateralNumber`) AS 'Collateral' FROM appraise_ve WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND appraise = 'Credit Investigation' AND (SELECT Surrendered FROM collateral_ve WHERE CollateralNumber = appraise_ve.`CollateralNumber`) = 0 ORDER BY ID DESC) A GROUP BY CollateralNumber", txtReferenceNumber.Tag))
                Dim TotalMarketValue As Double
                For x As Integer = 0 To Collateral.Rows.Count - 1
                    TotalMarketValue += Collateral(x)("market_value")
                Next
                If TotalMarketValue = 0 Then
                    TotalMarketValue = 1
                End If
                AccountCodeDetails("126002")
                For x As Integer = 0 To Collateral.Rows.Count - 1
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", (CDbl(Collateral(x)("market_value")) / TotalMarketValue) * CheckAmount, 0, Collateral(x)("CollateralNumber"), "Transfer to ROPA " & Collateral(x)("Collateral") & " with Market Value of P" & FormatNumber(CDbl(Collateral(x)("market_value")), 2), DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                Next
                'CREDIT
                AccountCodeDetails("112001")
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "Principal", "Transfer to ROPA ", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                'DEBIT
                Collateral = DataSource(String.Format("SELECT * FROM (SELECT CollateralNumber, prevailing_selling, market_value, appraised_value, loanable_value, (SELECT CONCAT(TCT, ' ', Location) FROM collateral_re WHERE CollateralNumber = appraise_re.`CollateralNumber` AND Surrendered = 0) AS 'Collateral' FROM appraise_re WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND (SELECT Surrendered FROM collateral_re WHERE CollateralNumber = appraise_re.`CollateralNumber`) = 0 AND appraise = 'Credit Investigation' ORDER BY ID DESC) A GROUP BY CollateralNumber", txtReferenceNumber.Tag))
                Dim TotalMarketValue As Double
                For x As Integer = 0 To Collateral.Rows.Count - 1
                    TotalMarketValue += Collateral(x)("market_value")
                Next
                If TotalMarketValue = 0 Then
                    TotalMarketValue = 1
                End If
                AccountCodeDetails("126001")
                For x As Integer = 0 To Collateral.Rows.Count - 1
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", (CDbl(Collateral(x)("market_value")) / TotalMarketValue) * CheckAmount, 0, Collateral(x)("CollateralNumber"), "Transfer to ROPA" & Collateral(x)("Collateral") & " with Market Value of P" & FormatNumber(CDbl(Collateral(x)("market_value")), 2), DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                Next
                'CREDIT
                AccountCodeDetails("112002")
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "Principal", "Transfer to ROPA ", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            End If

            Dim TotalDebitX As Double
            Dim TotalCreditX As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebitX += CDbl(DT_Account(x)("Debit"))
                TotalCreditX += CDbl(DT_Account(x)("Credit"))
            Next
            dDebitT.Value = TotalDebitX
            dCreditT.Value = TotalCreditX
            FirstLoad = True
            cbxPayee.SelectedValue = cbxPayee.Tag
            txtReferenceNumber.Text = txtReferenceNumber.Tag
            rExplanation.Text = rExplanation.Tag
            FirstLoad = False

            GridColumn22.Width = 342 - 80
            GridColumn11.Visible = True
            GridColumn11.VisibleIndex = 5
        ElseIf From_ITL Then
            cbxACR.Enabled = False
            cbxLA.Enabled = False
            cbxCV.Enabled = False
            cbxOR.Enabled = False
            cbxAP.Enabled = False
            cbxDT.Enabled = False
            cbxDF.Enabled = False
            cbxAR.Enabled = False
            cbxLOE.Enabled = False
            cbxJV.Enabled = False
            cbxUR.Enabled = False
            cbxDI.Enabled = False
            cbxRS.Enabled = False
            cbxITL.Enabled = False
            cbxROPA.Enabled = False
            cbxDTS.Enabled = False
            cbxBank.SelectedValue = BankID
            cbxPayee.Enabled = False
            tabList.Visible = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False
            txtReferenceNumber.Enabled = False

            DT_Account.Rows.Clear()
            txtReferenceNumber.Text = txtReferenceNumber.Tag
            If From_ITL_Reverse Then
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = accounting_entry.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(EntryType = 'Credit',Amount,0) AS 'Debit', IF(EntryType = 'Debit',Amount,0) AS 'Credit', PaidFor, Remarks, GetRequiredRemarks(AccountCode) AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM accounting_entry WHERE CVNumber = '{0}' AND `status` = 'ACTIVE' AND PostStatus = 'POSTED';", txtReferenceNumber.Text))
                GridControl2.DataSource = DT_Account
            End If
            Dim TotalDebitX As Double
            Dim TotalCreditX As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebitX += CDbl(DT_Account(x)("Debit"))
                TotalCreditX += CDbl(DT_Account(x)("Credit"))
            Next
            dDebitT.Value = TotalDebitX
            dCreditT.Value = TotalCreditX

            GridColumn22.Width = 342 - 80
            GridColumn11.Visible = True
            GridColumn11.VisibleIndex = 5
            FirstLoad = True
            cbxPayee.Text = cbxPayee.Tag
            FirstLoad = False
        ElseIf From_Case Then
            cbxACR.Enabled = False
            cbxLA.Enabled = False
            cbxCV.Enabled = False
            cbxOR.Enabled = False
            cbxAP.Enabled = False
            cbxDT.Enabled = False
            cbxDF.Enabled = False
            cbxAR.Enabled = False
            cbxLOE.Enabled = False
            cbxJV.Enabled = False
            cbxUR.Enabled = False
            cbxDI.Enabled = False
            cbxRS.Enabled = False
            cbxITL.Enabled = False
            cbxROPA.Enabled = False
            cbxDTS.Enabled = False
            cbxBank.SelectedValue = BankID
            cbxPayee.Enabled = False
            tabList.Visible = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False
            txtReferenceNumber.Enabled = False

            DT_Account.Rows.Clear()
            txtReferenceNumber.Text = txtReferenceNumber.Tag
            'DEBIT
            AccountCodeDetails(Case_Debit)
            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", Case_BV, 0, "Balance Transferred", "Transfer to ITL ", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            'CREDIT
            AccountCodeDetails(Case_Credit_LR)
            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, If(Case_OldAccount, Case_BV, Case_Principal), "Principal", "Transfer to ITL ", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")

            Dim TotalDebitX As Double
            Dim TotalCreditX As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebitX += CDbl(DT_Account(x)("Debit"))
                TotalCreditX += CDbl(DT_Account(x)("Credit"))
            Next
            dDebitT.Value = TotalDebitX
            dCreditT.Value = TotalCreditX

            GridColumn22.Width = 342 - 80
            GridColumn11.Visible = True
            GridColumn11.VisibleIndex = 5
            FirstLoad = True
            cbxPayee.Text = cbxPayee.Tag
            FirstLoad = False
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

            GetLabelFontSettings({LabelX2, LabelX13, LabelX18, LabelIssued, LabelX6, LabelX1, lblORNumber, lblORDate, LabelX5, LabelX8, LabelX34, LabelX40, LabelX42, LabelX41, LabelX39})

            GetLabelWithBackgroundFontSettings({LabelX3, LabelX15, LabelX4, LabelX7, LabelX35})

            GetCheckBoxFontSettings({cbxLA, cbxACR, cbxOR, cbxCV, cbxAP, cbxAR, cbxLOE, cbxDTS, cbxDT, cbxDF, cbxUR, cbxDI, cbxJV, cbxRS, cbxITL, cbxROPA, cbxDTS_RS, cbxNL, cbxRO, cbxAll})

            GetButtonFontSettings({btnAdd_Account, btnRemove_Account, btnDownload, btnExport, btnView, btnLedger, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDisapprove, btnDelete, btnPrint, btnAttach, btnApprove, btnCheck, btnReceive, btnSearch})

            GetComboBoxFontSettings({cbxPayee, cbxBank, cbxAccount, cbxDepartment, cbxBusinessCenter, cbxPreparedBy, cbxDisplay})

            GetDateTimeInputFontSettings({dtpDocument, dtpPostingDate, dtpORDate, dtpFrom, dtpTo})

            GetTextBoxFontSettings({txtDocumentNumber, txtReferenceNumber, txtORNumber, txtCheck, txtApproved})

            GetDoubleInputFontSettings({dDebitT, dCreditT})

            GetSearchRepositoryFontSettings({RepositoryItemSearchLookUpEdit1})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit3, RepositoryItemLookUpEdit2, RepositoryItemLookUpEdit1, RepositoryItemLookUpEdit4})

            GetRickTextBoxFontSettings({rExplanation})

            GetTabControlFontSettings({SuperTabControl1})

            GetLabelHeaderFontSettings({lblTitle})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Journal Voucher - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Journal Voucher", lblTitle.Text)
    End Sub

    Private Sub DtpDocument_ValueChanged(sender As Object, e As EventArgs) Handles dtpDocument.ValueChanged
        GetDocumentNumber()
    End Sub

    Private Sub Payee_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLA.CheckedChanged, cbxACR.CheckedChanged, cbxCV.CheckedChanged, cbxOR.CheckedChanged, cbxAP.CheckedChanged, cbxAR.CheckedChanged, cbxLOE.CheckedChanged, cbxJV.CheckedChanged, cbxDT.CheckedChanged, cbxDF.CheckedChanged, cbxUR.CheckedChanged, cbxDI.CheckedChanged, cbxRS.CheckedChanged, cbxITL.CheckedChanged, cbxROPA.CheckedChanged, cbxDTS.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxLA.Checked = False And cbxACR.Checked = False And cbxCV.Checked = False And cbxAP.Checked = False And cbxAR.Checked = False And cbxLOE.Checked = False And cbxJV.Checked = False And cbxOR.Checked = False And cbxDT.Checked = False And cbxDF.Checked = False And cbxUR.Checked = False And cbxDI.Checked = False And cbxRS.Checked = False And cbxITL.Checked = False And cbxROPA.Checked = False And cbxDTS.Checked = False Then
        Else
            LoadPayee()
        End If
    End Sub

    Private Sub LoadPayee()
        cbxPayee.DisplayMember = "Payee"
        cbxPayee.ValueMember = "ID"
        Dim SQL As String = ""
        If cbxLA.Checked Then ' LOANS APPLICATION
            SQL &= String.Format(" SELECT ID, CreditNumber AS 'Payee_ID', CONCAT('[ ', CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)), ' ] - ', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Payee', CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)) AS 'ORNum','' AS 'ORDate',AmountApplied AS 'Amount',BankID,'Loans' AS 'PaidFrom',CreditNumber AS 'ReferenceN',Mortgage_ID AS 'Cash Advance', 0 AS 'TotalExpenses', IF(PaymentRequest = 'RELEASED' OR PaymentRequest = 'CLOSED',0,IF(CVforJV,2,From_ROPOA)) AS 'AmountDue', CONCAT('[Credit Number: ', CreditNumber,']') AS 'Explanation', BusinessCenterCode(BusinessID) AS 'BusinessCode' FROM credit_application WHERE `status` = 'ACTIVE' AND (PaymentRequest = 'RELEASED' OR PaymentRequest = 'APPROVED REQUEST' OR PaymentRequest = 'CLOSED' OR ((CVForJV = 1 OR From_ROPOA = 1) AND CI_Status = 'APPROVED' AND IF('{1}' = 'False',PaymentRequest IN ('PENDING','REQUESTED'),PaymentRequest = 'PENDING'))) AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID), cbxPayee.Enabled)
        End If
        If cbxACR.Checked Then 'ACKNOWLEDGEMENT RECEIPT
            If cbxLA.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, Payee_ID, CONCAT(Payee, '[', DocumentNumber,']') AS 'Payee', '' AS 'ORNum', DocumentDate AS 'ORDate', Amount, BankID, CONCAT('Acknowledgement ', Payee_Type) AS 'PaidFrom', DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue',IF(Payee_Type = 'AR',CONCAT('[Accounts Receivable: ', (SELECT DocumentNumber FROM accounts_payable WHERE ID = Payee_ID),'][Acknowledgement Number: ',DocumentNumber,']'), (SELECT CONCAT('[Cash Advance: ', CANumber,'][Check Voucher: ', (SELECT DocumentNumber FROM check_voucher WHERE Payee_ID = CANumber AND `status` = 'ACTIVE'), '][Liquidation: ', AccountNumber,']') FROM liquidation_main WHERE ID = acknowledgement_receipt.Payee_ID)) AS 'Explanation', '' AS 'BusinessCode' FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' AND Voucher_Status IN ('APPROVED') AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '')", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxCV.Checked Then 'CHECK VOUCHER
            If cbxLA.Checked Or cbxACR.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, Payee_ID, CONCAT(Payee, '[', DocumentNumber,']') AS 'Payee', '' AS 'ORNum', DocumentDate AS 'ORDate', Amount, BankID, 'Check Voucher' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', DTS AS 'TotalExpenses', 0 AS 'AmountDue', IF(Payee_Type = 'A',CONCAT('[Cash Advance: ', Payee_ID,'][Check Voucher: ',DocumentNumber,']'),IF(Payee_Type = 'AP',CONCAT('[Accounts Payable: ', Payee_ID,'][Check Voucher: ',DocumentNumber,']'),IF(Payee_Type = 'C',CONCAT('[Credit Number: ', Payee_ID,'][Check Voucher: ',DocumentNumber,']'),CONCAT('[Check Voucher: ',DocumentNumber,']')))) AS 'Explanation', '' AS 'BusinessCode' FROM check_voucher WHERE `status` = 'ACTIVE' AND IF(Payee_Type = 'C',(SELECT IFNULL(SUM(Amount),0) FROM accounting_entry WHERE `status` = 'ACTIVE' AND ReferenceN = check_voucher.Payee_ID AND EntryType = 'CREDIT' AND PaidFor IN ('RPPD','Principal','UDI','Billing')) = 0,TRUE) AND Voucher_Status IN ('APPROVED','RECEIVED') AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '') AND IF(Payee_Type = 'A',(SELECT Liquidated FROM cash_advance WHERE AccountNumber = check_voucher.Payee_ID) = 'N',TRUE)", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxAP.Checked Then 'ACCOUNTS PAYABLE
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, PayeeID AS 'Payee_ID', CONCAT(Payee, '[', DocumentNumber,']') AS 'Payee', '' AS 'ORNum', DocumentDate AS 'ORDate', Amount, BankID, 'Accounts Payable' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue',CONCAT('[Accounts Payable: ', DocumentNumber,']') AS 'Explanation', '' AS 'BusinessCode' FROM accounts_payable WHERE `status` = 'ACTIVE' AND AP_Status IN ('APPROVED') AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '')", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxAR.Checked Then 'ACCOUNTS RECEIVABLE
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, IF(Payor_Type = 'LA',PayorID,ID) AS 'Payee_ID', CONCAT(Payor, '[', DocumentNumber,']') AS 'Payee', '' AS 'ORNum', DocumentDate AS 'ORDate', Amount, BankID, 'Accounts Receivable' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue',CONCAT('[Accounts Receivable: ', DocumentNumber,']') AS 'Explanation', '' AS 'BusinessCode' FROM accounts_receivable WHERE `status` = 'ACTIVE' AND AR_Status IN ('APPROVED') AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '')", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxDT.Checked Then 'DUE TO
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, PayeeID AS 'Payee_ID', CONCAT(Payee, '[', DocumentNumber,']') AS 'Payee', '' AS 'ORNum', DocumentDate AS 'ORDate', Amount, BankID, 'Due To' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue',CONCAT('[Accounts Payable: ', DocumentNumber,']') AS 'Explanation', '' AS 'BusinessCode' FROM due_to WHERE `status` = 'ACTIVE' AND AP_Status IN ('APPROVED') AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '')", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxDF.Checked Then 'DUE FROM
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, PayorID AS 'Payee_ID', CONCAT(Payor, '[', DocumentNumber,']') AS 'Payee', '' AS 'ORNum', DocumentDate AS 'ORDate', Amount, BankID, 'Due From' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue',CONCAT('[Accounts Receivable: ', DocumentNumber,']') AS 'Explanation', '' AS 'BusinessCode' FROM due_from WHERE `status` = 'ACTIVE' AND AR_Status IN ('APPROVED') AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '')", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxLOE.Checked Then 'LIQUIDATION OF EXPENSES
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, Payee_ID, CONCAT(Payee, '[', AccountNumber,']') AS 'Payee', IFNULL(CV,'') AS 'ORNum','' AS 'ORDate',AmountDue AS 'Amount',IFNULL(CV_BankID,0) AS 'BankID','Liquidation' AS 'PaidFrom',AccountNumber AS 'ReferenceN', (SELECT Meals + Transportation + BIR + RD + LTO + Notarization + Others FROM cash_advance WHERE AccountNumber = CANumber) - (IF(AmountDue < 0,ABS(AmountDue),0)) AS 'Cash Advance', TotalExpenses, AmountDue,CONCAT('[Cash Advance: ', CANumber,'][Check Voucher: ', CV, '][Liquidation: ', AccountNumber,']   \n(',  (SELECT GROUP_CONCAT(CONCAT(Particulars, ' [', FORMAT(Total,2),']')) FROM liquidation_details WHERE LiqMain = liquidation_main.ID AND `status` = 'ACTIVE'), ')') AS 'Explanation', '' AS 'BusinessCode' FROM liquidation_main LEFT JOIN (SELECT DocumentNumber AS 'CV', BankID AS 'CV_BankID', Payee_ID AS 'CPayee' FROM check_voucher WHERE `status` = 'ACTIVE' AND Payee_Type = 'A' AND JVNumber = '') C ON CPayee = CANumber WHERE `status` = 'ACTIVE' AND IF(AmountDue >= 0, Liq_Status = 'APPROVED', Liq_Status IN ('APPROVED','PARTIALLY ACKNOWLEDGED','ACKNOWLEDGED')) AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '')", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxJV.Checked Then 'JOURNAL VOUCHER ITSEFT!! 
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Or cbxLOE.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, Payee_ID, CONCAT(Payee, '[', DocumentNumber,']') AS 'Payee',ReferenceID AS 'ORNum','' AS 'ORDate',0 AS 'Amount',BankID,'Journal Voucher' AS 'PaidFrom',DocumentNumber AS 'ReferenceN', 0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue',CONCAT('[Journal Voucher: ', DocumentNumber,']') AS 'Explanation', '' AS 'BusinessCode' FROM journal_voucher WHERE `status` = 'ACTIVE' AND Voucher_Status = 'APPROVED' AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '')", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxOR.Checked Then 'OFFICIAL RECEIPT
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Or cbxLOE.Checked Or cbxJV.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, Payee_ID, CONCAT(Payee, '[', DocumentNumber,']') AS 'Payee', DocumentNumber AS 'ORNum', DocumentDate AS 'ORDate', Amount, BankID, 'Official Receipt' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',TotalWaiveRPPD AS 'Cash Advance', DTS AS 'TotalExpenses', TotalUnpaidPenalty AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM official_receipt WHERE `status` = 'ACTIVE' AND Voucher_Status IN ('APPROVED') AND Branch_ID IN ({0}) AND IF('{1}' = 'False',TRUE,JVNumber = '' AND IF({2} > 0,TRUE,DTS_JVNumber = ''))", If(Multiple_ID = "", Branch_ID, Multiple_ID), cbxPayee.Enabled, BounceID)
        End If
        If cbxUR.Checked Then 'UNREALIZE GAIN/LOSS
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Or cbxLOE.Checked Or cbxJV.Checked Or cbxOR.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT ID, Payee_ID, CONCAT(Payee, '[', DocumentNumber,']') AS 'Payee', '' AS 'ORNum', DocumentDate AS 'ORDate', IFNULL((SELECT SUM(Credit) FROM acr_details WHERE AccountCode = '229102' AND `status` = 'ACTIVE' AND DocumentNumber = acknowledgement_receipt.DocumentNumber),0) AS 'Amount', BankID, 'Unrealized' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM acknowledgement_receipt WHERE `status` = 'ACTIVE' AND Voucher_Status IN ('APPROVED') AND IFNULL((SELECT ID FROM acr_details WHERE AccountCode = '229102' AND `status` = 'ACTIVE' AND DocumentNumber = acknowledgement_receipt.DocumentNumber),0) > 0 AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '') AND GREATEST((SELECT Amount FROM sold_ropoa WHERE AssetNumber = acknowledgement_receipt.Payee_ID AND `status` = 'ACTIVE') - ROPOA_Payment(Payee_ID,(SELECT ID FROM sold_ropoa WHERE AssetNumber = acknowledgement_receipt.Payee_ID AND `status` = 'ACTIVE')),0) = 0", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxDI.Checked Then 'DIFFERRED INCOME
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Or cbxLOE.Checked Or cbxJV.Checked Or cbxOR.Checked Or cbxUR.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT M.ID, M.Payee_ID, CONCAT(M.Payee, '[', M.DocumentNumber,']') AS 'Payee', M.DocumentNumber AS 'ORNum', M.DocumentDate AS 'ORDate', IFNULL(D.`Credit` - (SELECT IFNULL(SUM(CASE WHEN EntryType = 'DEBIT' THEN Amount END),0) AS 'Deferred Income' FROM accounting_entry WHERE ReferenceN = M.DocumentNumber AND AccountCode = D.AccountCode AND `status` != 'CANCELLED'),0) AS 'Amount', M.BankID, 'Deferred Income' AS 'PaidFrom', M.DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM official_receipt M  LEFT JOIN or_details D ON M.`DocumentNumber` = D.`DocumentNumber` AND D.`status` = 'ACTIVE' AND D.`AccountCode` = '229104' WHERE M.`status` = 'ACTIVE' AND M.Voucher_Status IN ('APPROVED') AND D.Credit - (SELECT IFNULL(SUM(CASE WHEN EntryType = 'DEBIT' THEN Amount END),0) AS 'Deferred Income' FROM accounting_entry WHERE ReferenceN = M.DocumentNumber AND AccountCode = D.AccountCode AND `status` != 'CANCELLED') > 0 AND Branch_ID = '{0}' AND IF('{1}' = 'False',TRUE,JVNumber = '')", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxRS.Checked Then ' RESTRUCTURED ACCOUNT
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Or cbxLOE.Checked Or cbxJV.Checked Or cbxOR.Checked Or cbxUR.Checked Or cbxDI.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT CreditNumber AS 'ID', CreditNumber AS 'Payee_ID', CONCAT('[ ', AccountN, ' ] - ',IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Payee', AccountN AS 'ORNum',IF(SUBSTRING(AccountN,LENGTH(AccountN),1) = 'R',CONCAT(AccountN,'2'),IF(SUBSTRING(AccountN,LENGTH(AccountN) - 1,1) = 'R',CONCAT(SUBSTRING(AccountN,1,LENGTH(AccountN) - 1), SUBSTRING(AccountN,LENGTH(AccountN),1) + 1),CONCAT(AccountN,'R'))) AS 'ORDate',AmountApplied AS 'Amount',(SELECT BankID FROM check_received WHERE AssetNumber = credit_application.CreditNumber_Old AND check_type = 'P' AND `status` = 'ACTIVE' LIMIT 1) AS 'BankID','Restructuring' AS 'PaidFrom',CreditNumber AS 'ReferenceN',mortgage_id AS 'Cash Advance', GREATEST(IFNULL((SELECT A.AmountApplied FROM credit_application A WHERE A.CreditNumber = credit_application.CreditNumber_Old),0) - IFNULL((SELECT IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Principal' FROM accounting_entry WHERE `status` = 'ACTIVE' AND ReferenceN = CreditNumber_Old),0),0) AS 'TotalExpenses', IF(CreditNumber_Old_Assumption = '',CreditNumber_Old,CreditNumber_Old_Assumption) AS 'AmountDue', CONCAT(Remarks, ' [New Account Number: ', IF(SUBSTRING(AccountN,LENGTH(AccountN),1) = 'R',CONCAT(AccountN,'2'),IF(SUBSTRING(AccountN,LENGTH(AccountN) - 1,1) = 'R',CONCAT(SUBSTRING(AccountN,1,LENGTH(AccountN) - 1), SUBSTRING(AccountN,LENGTH(AccountN),1) + 1),CONCAT(AccountN,'R'))),']', ' [Old Account Number: ', AccountN,']') AS 'Explanation', BusinessCenterCode(BusinessID) AS 'BusinessCode' FROM credit_application WHERE `status` = 'ACTIVE' AND PaymentRequest = 'PENDING' AND CI_Status = 'APPROVED' AND Loan_Type = 'RESTRUCTURE' AND IF('{1}' = 'False',TRUE,JVNumber = '') AND branch_id = '{0}'", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxITL.Checked Then ' ITL
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Or cbxLOE.Checked Or cbxJV.Checked Or cbxOR.Checked Or cbxUR.Checked Or cbxDI.Checked Or cbxRS.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT AccountNumber AS 'ID', AccountNumber AS 'Payee_ID', CONCAT('[ ', AccountNumber, ' ] - ', Borrower (BorrowerID)) AS 'Payee', CaseNumber AS 'ORNum', TransDate AS 'ORDate', 0 AS 'Amount', BankID, 'ITL' AS 'PaidFrom', AccountNumber AS 'ReferenceN', MortgageID AS 'Cash Advance', 0 AS 'TotalExpenses', '' AS 'AmountDue', '' AS 'Explanation', 0 AS 'BusinessCode' FROM case_main WHERE `status` = 'ACTIVE' AND BranchID = '{0}'", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxROPA.Checked Then ' ROPA
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Or cbxLOE.Checked Or cbxJV.Checked Or cbxOR.Checked Or cbxUR.Checked Or cbxDI.Checked Or cbxRS.Checked Or cbxITL.Checked Then
                SQL &= " UNION ALL"
            End If
            SQL &= String.Format(" SELECT AssetNumber AS 'ID', AssetNumber AS 'Payee_ID',CONCAT('[ ',AssetNumber,' ] - ',IFNULL(Borrower (AccountID),'')) AS 'Payee', PlateNum AS 'ORNum', Trans_Date AS 'ORDate', Price AS 'Amount', BankID, 'ROPA' AS 'PaidFrom', AssetNumber AS 'ReferenceN', 1 AS 'Cash Advance', BalanceTransferred AS 'TotalExpenses', '' AS 'AmountDue', Remarks AS 'Explanation', 0 AS 'BusinessCode' FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND sell_status IN ('SELL','RESERVED') AND Branch_ID = '{0}'", Branch_ID, cbxPayee.Enabled)
            SQL &= " UNION ALL"
            SQL &= String.Format(" SELECT AssetNumber AS 'ID', AssetNumber AS 'Payee_ID',CONCAT('[ ',AssetNumber,' ] - ',IFNULL(Borrower (AccountID),'')) AS 'Payee', TCT AS 'ORNum', Trans_Date AS 'ORDate', Price AS 'Amount', BankID, 'ROPA' AS 'PaidFrom', AssetNumber AS 'ReferenceN', 1 AS 'Cash Advance', BalanceTransferred AS 'TotalExpenses', '' AS 'AmountDue', Remarks AS 'Explanation', 0 AS 'BusinessCode' FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND sell_status IN ('SELL','RESERVED') AND Branch_ID = '{0}'", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxDTS.Checked Then ' DTS
            If cbxLA.Checked Or cbxACR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Or cbxLOE.Checked Or cbxJV.Checked Or cbxOR.Checked Or cbxUR.Checked Or cbxDI.Checked Or cbxRS.Checked Or cbxITL.Checked Or cbxROPA.Checked Then
                SQL &= " UNION ALL"
            End If
            If DTS_From_CV Then
                GoTo DTS_CV
            End If
            SQL &= String.Format(" SELECT ID, Payee_ID, CONCAT(Payee, '[', DocumentNumber,'][DTS]') AS 'Payee', DocumentNumber AS 'ORNum', DocumentDate AS 'ORDate', Amount, BankID, 'DTS' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', 0 AS 'TotalExpenses', (SELECT IF(CreditNumber_Old_Assumption = '',CreditNumber_Old,CreditNumber_Old_Assumption) FROM credit_application WHERE CreditNumber = official_receipt.Payee_ID) AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM official_receipt WHERE `status` = 'ACTIVE' AND Voucher_Status IN ('APPROVED') AND Branch_ID = '{0}' AND DTS = 1 AND IF('{1}' = 'False',TRUE,JVNumber = '' AND DTS_JVNumber = '')", Branch_ID, cbxPayee.Enabled)
            SQL &= " UNION ALL"
            SQL &= String.Format(" SELECT ID, Payee_ID, CONCAT(Payee, '[', DocumentNumber,'][DTS]') AS 'Payee', DocumentNumber AS 'ORNum', DocumentDate AS 'ORDate', 0, BankID, 'DTS JV' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',ReferenceID AS 'Cash Advance', 0 AS 'TotalExpenses',  (SELECT IF(CreditNumber_Old_Assumption = '',CreditNumber_Old,CreditNumber_Old_Assumption) FROM credit_application WHERE CreditNumber = journal_voucher.Payee_ID) AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM journal_voucher WHERE `status` = 'ACTIVE' AND Voucher_Status IN ('APPROVED') AND Branch_ID = '{0}' AND DTS = 1 AND IF('{1}' = 'False',TRUE,DTS_JVNumber = '')", Branch_ID, cbxPayee.Enabled)
            SQL &= " UNION ALL"
DTS_CV:
            SQL &= String.Format(" SELECT ID, Payee_ID, CONCAT(Payee, '[', DocumentNumber,'][DTS]') AS 'Payee', DocumentNumber AS 'ORNum', DocumentDate AS 'ORDate', 0, BankID, 'DTS CV' AS 'PaidFrom', DocumentNumber AS 'ReferenceN',0 AS 'Cash Advance', 0 AS 'TotalExpenses',  (SELECT IF(CreditNumber_Old_Assumption = '',CreditNumber_Old,CreditNumber_Old_Assumption) FROM credit_application WHERE CreditNumber = check_voucher.Payee_ID) AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM check_voucher WHERE `status` = 'ACTIVE' AND Voucher_Status IN ('APPROVED','RECEIVED') AND Branch_ID = '{0}' AND DTS = 1 AND IF('{1}' = 'False',TRUE,DTS_JVNumber = '')", Branch_ID, cbxPayee.Enabled)
        End If
        'Employee
        If From_ACR Or From_Ledger Or From_LOE Then
            GoTo Here
        End If
        If cbxLA.Checked Or cbxACR.Checked Or cbxOR.Checked Or cbxCV.Checked Or cbxAP.Checked Or cbxAR.Checked Or cbxDT.Checked Or cbxDF.Checked Or cbxLOE.Checked Or cbxJV.Checked Or cbxUR.Checked Or cbxDI.Checked Or cbxRS.Checked Or cbxITL.Checked Or cbxROPA.Checked Or cbxDTS.Checked Then
            SQL &= " UNION ALL"
        End If
        SQL &= String.Format(" SELECT ID, ID AS 'Payee_ID', Employee(ID) AS 'Payee','' AS 'ORNum','' AS 'ORDate',0 AS 'Amount', 0 AS 'BankID','E' AS 'PaidFrom',ID AS 'ReferenceN', 0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM employee_setup WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}'", Branch_ID)
        'Supplier
        SQL &= String.Format(" UNION ALL SELECT ID, ID AS 'Payee_ID', Supplier AS 'Payee','' AS 'ORNum','' AS 'ORDate',0 AS 'Amount', 0 AS 'BankID','Employee' AS 'S',ID AS 'ReferenceN', 0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM supplier_setup WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}'", Branch_ID)
        'Branch
        SQL &= String.Format(" UNION ALL SELECT ID, ID AS 'Payee_ID', Branch AS 'Payee','' AS 'ORNum','' AS 'ORDate',0 AS 'Amount', 0 AS 'BankID','Employee' AS 'B',ID AS 'ReferenceN', 0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM branch WHERE `status` = 'ACTIVE'", Branch_ID)
        SQL &= "    ORDER BY `Payee` ;"
Here:
        If SQL = "" Then
        Else
            cbxPayee.DataSource = DataSource(SQL)
        End If
        If cbxPayee.Enabled And cbxLA.Checked = False And cbxACR.Checked = False And cbxCV.Checked = False And cbxAP.Checked = False And cbxAR.Checked = False And cbxLOE.Checked = False And cbxJV.Checked = False And cbxOR.Checked = False And cbxDT.Checked = False And cbxDF.Checked = False And cbxUR.Checked = False And cbxDI.Checked = False And cbxRS.Checked = False And cbxITL.Checked = False And cbxROPA.Checked = False And cbxDTS.Checked = False Then
            cbxPayee.SelectedIndex = -1
        End If
    End Sub

    Private Sub GetDocumentNumber()
        If btnSave.Text = "&Save" Then
            txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('JV-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,5,'0')) FROM journal_voucher WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))
        End If
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID,"
        SQL &= "    Payee_ID,"
        SQL &= "    Payee,"
        SQL &= "    (SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE ID = journal_voucher.BankID) AS 'Bank', BankID, "
        SQL &= "    DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date',"
        SQL &= "    ReferenceNumber AS 'Reference Number',"
        SQL &= "    Explanation,"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID, CheckedID, ORNum, ORDate, JVNumber, IFNULL((SELECT ID FROM liquidation_main WHERE JVNumber = journal_voucher.DocumentNumber),0) AS 'Liq_ID', "
        SQL &= "    BRANCH(branch_id) AS 'Branch', User_EmplID, Branch_ID, IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(JVNumber != '','REVERSED',IF(Voucher_Status='PENDING','FOR CHECKING',IF(Voucher_Status='CHECKED','FOR APPROVAL',Voucher_Status)))) AS 'Voucher_Status', Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', OTAC_Check, OTAC_Approve, Attach, IFNULL(JVFrom,'') AS 'JVFrom', ReferenceID, DTS, Refinance, CVforJV"
        SQL &= "  FROM journal_voucher WHERE"
        Dim ForChecking As Boolean
        Dim ForApproval As Boolean
        Dim Approved As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Checking" Then
                    ForChecking = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    ForApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Approved" Then
                    Approved = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForChecking = False And ForApproval = False And Approved = False Then
                If Cancelled Then
                    SQL &= String.Format(" (`status` IN ({0}) OR voucher_status = 'DISAPPROVED')", If(Cancelled, "'CANCELLED','DELETED','DISAPPROVED'", "''"))
                End If
            Else
                SQL &= String.Format(" `status` IN ('ACTIVE',{0}) AND (voucher_status = 'DISAPPROVED' ", If(Cancelled, "'CANCELLED','DELETED','DISAPPROVED'", "''"))
                If ForChecking Or ForApproval Or Approved Then
                    SQL &= " OR "
                End If
                If ForChecking Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'PENDING',TRUE)"
                    If ForApproval Or Approved Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'CHECKED',TRUE)"
                    If Approved Then
                        SQL &= " OR "
                    End If
                End If
                If Approved Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'APPROVED',TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForChecking = False And ForApproval = False And Approved = False Then
            Else
                SQL &= " AND ("
                If ForChecking Then
                    SQL &= " voucher_status = 'PENDING'"
                    If ForApproval Or Approved Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " voucher_status = 'CHECKED'"
                    If Approved Then
                        SQL &= " OR "
                    End If
                End If
                If Approved Then
                    SQL &= " voucher_status = 'APPROVED'"
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
            GridColumn16.Visible = True
            GridColumn16.VisibleIndex = 9
        End If
        GridView1.Columns("Payee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Payee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn3.Width = 339 - 17
        Else
            GridColumn3.Width = 339
        End If
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub CbxPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpPostingDate.Focus()
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
            rExplanation.Focus()
        End If
    End Sub

    Private Sub RExplanation_KeyDown(sender As Object, e As KeyEventArgs) Handles rExplanation.KeyDown
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
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebit += CDbl(DT_Account(x)("Debit"))
            Next
            dDebitT.Value = TotalDebit
        ElseIf e.Column.FieldName = "Credit" Then
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Credit").ToString = "" Then
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Credit", 0)
            ElseIf IsNumeric(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Credit")) = False Then
                MsgBox(String.Format("Incorrect {1} value for Credit under row {0}.", GridView2.FocusedRowHandle + 1, GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Credit")), MsgBoxStyle.Information, "Info")
                dCreditT.Value = 0
                Exit Sub
            End If
            DT_Account(GridView2.FocusedRowHandle)("Credit") = DT_Account(GridView2.FocusedRowHandle)("Credit")
            Dim TotalCredit As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalCredit += CDbl(DT_Account(x)("Credit"))
            Next
            dCreditT.Value = TotalCredit
        ElseIf e.Column.FieldName = "Account" Then
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
                    If GridControl2.Enabled = False Then
                        GridControl2.Enabled = True
                    End If
                Else
                    e.Appearance.ForeColor = Color.Black
                End If
            Catch ex As Exception
            End Try
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
            Row("PaidFor") = ""
            Row("Remarks") = ""
            Row("RequiredRemarks") = ""
            Row("BusinessCode") = ""
            Row("Type_ID") = 0
            Row("MotherCode") = ""
            Row("AR_DocumentNumber") = ""
            DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
        Else
            If drv("PaidFrom") = "Loans" Then
                Row("Account Code") = ""
                Row("Department Code") = ""
                Row("Account") = ""
                Row("Business Center") = DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode")))
                Row("Department") = ""
                Row("Debit") = 0
                Row("Credit") = 0
                If Refinance Then
                    If drv("Cash Advance") = 1 Then
                        Row("PaidFor") = DataSource(String.Format("SELECT asset_number FROM appraise_ve WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND CollateralNumber = (SELECT CollateralNumber FROM collateral_ve WHERE CINumber = (SELECT CINumber FROM credit_investigation WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE') LIMIT 1) LIMIT 1;", drv("Payee_ID")))
                    Else
                        Row("PaidFor") = DataSource(String.Format("SELECT asset_number FROM appraise_re WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND CollateralNumber = (SELECT CollateralNumber FROM collateral_ve WHERE CINumber = (SELECT CINumber FROM credit_investigation WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE') LIMIT 1) LIMIT 1;", drv("Payee_ID")))
                    End If
                Else
                    Row("PaidFor") = ""
                End If
                Row("Remarks") = ""
                Row("RequiredRemarks") = ""
                Row("BusinessCode") = drv("BusinessCode")
                Row("Type_ID") = 0
                Row("MotherCode") = ""
                Row("AR_DocumentNumber") = ""
                DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
            Else
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
                Row("AR_DocumentNumber") = ""
                DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
            End If
        End If

        Dim TotalDebit As Double
        Dim TotalCredit As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
        Next
        If GridView2.RowCount > 7 Then
            If GridColumn11.Visible = False Then
                GridColumn22.Width = 342 - 17
            Else
                GridColumn22.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn11.Visible = False Then
                GridColumn22.Width = 342
            Else
                GridColumn22.Width = 342 - 80
            End If
        End If
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
    End Sub

    Private Sub BtnRemove_Account_Click(sender As Object, e As EventArgs) Handles btnRemove_Account.Click
        If DT_Account.Rows.Count = 0 Then
            Exit Sub
        End If

        DT_Account.Rows.RemoveAt(GridView2.FocusedRowHandle)

        Dim TotalDebit As Double
        Dim TotalCredit As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
        Next
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
        If GridView2.RowCount > 7 Then
            If GridColumn11.Visible = False Then
                GridColumn22.Width = 342 - 17
            Else
                GridColumn22.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn11.Visible = False Then
                GridColumn22.Width = 342
            Else
                GridColumn22.Width = 342 - 80
            End If
        End If

        If GridView2.RowCount = 0 Then
            btnRemove_Account.Enabled = False
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
            .FolderName = "Journal Voucher-" & GridView1.GetFocusedRowCellValue("Document Number")
            .JVNumber = GridView1.GetFocusedRowCellValue("Document Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Document Number")
            .Type = "Journal Voucher"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
            End If
            .Dispose()
        End With
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

    Private Sub Clear(TriggerLoadData As Boolean)
        btnAdd_Account.Enabled = True
        btnExport.Enabled = True
        btnDownload.Enabled = True
        btnRemove_Account.Enabled = True
        GridControl2.Enabled = True

        btnUpdate.Visible = False
        TotalAdvance = 0
        Refinance = False
        CVforJV = False
        CopyMode = False
        btnSave.Text = "&Save"
        PanelEx10.Enabled = True
        PanelEx2.Enabled = True
        GridView2.OptionsBehavior.Editable = True
        cbxPayee.Enabled = True
        cbxLA.Enabled = True
        cbxNL.Enabled = True
        cbxRO.Enabled = True
        cbxACR.Enabled = True
        cbxCV.Enabled = True
        cbxAP.Enabled = True
        cbxAR.Enabled = True
        cbxDT.Enabled = True
        cbxDF.Enabled = True
        cbxOR.Enabled = True
        cbxLOE.Enabled = True
        cbxJV.Enabled = True
        cbxUR.Enabled = True
        cbxDI.Enabled = True
        cbxRS.Enabled = True
        cbxITL.Enabled = True
        cbxROPA.Enabled = True
        cbxDTS.Enabled = True

        FirstLoad = True
        cbxLA.Checked = False
        cbxACR.Checked = False
        cbxOR.Checked = False
        cbxCV.Checked = False
        cbxAP.Checked = False
        cbxDT.Checked = False
        cbxDF.Checked = False
        cbxAR.Checked = False
        cbxLOE.Checked = False
        cbxJV.Checked = False
        cbxUR.Checked = False
        cbxDI.Checked = False
        cbxRS.Checked = False
        cbxITL.Checked = False
        cbxROPA.Checked = False
        cbxDTS.Checked = False
        FirstLoad = False

        cbxDTS_RS.Visible = False
        cbxDTS_RS.Checked = False
        BounceID = 0
        Bounce = ""
        BounceRemarks = ""
        BankID = 0
        AvailedRPPD = 0

        dtpPostingDate.Value = Date.Now
        dtpDocument.Value = Date.Now
        txtReferenceNumber.Text = ""
        txtORNumber.Text = ""
        dtpORDate.Value = Date.Now
        If cbxBank.Enabled Then
            cbxBank.SelectedIndex = -1
        End If
        cbxPayee.SelectedIndex = -1
        rExplanation.Text = ""
        cbxPreparedBy.SelectedValue = Empl_ID
        Dim SQL As String = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber'"
        DT_Account = DataSource(SQL)
        GridControl2.DataSource = DT_Account
        dDebitT.Value = 0
        dCreditT.Value = 0
        If GridView2.RowCount > 7 Then
            If GridColumn11.Visible = False Then
                GridColumn22.Width = 342 - 17
            Else
                GridColumn22.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn11.Visible = False Then
                GridColumn22.Width = 342
            Else
                GridColumn22.Width = 342 - 80
            End If
        End If

        txtReferenceNumber.Enabled = True
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnCheck.Visible = False
        btnApprove.Visible = False
        btnReceive.Visible = False

        cbxPreparedBy.SelectedValue = Empl_ID
        txtCheck.Text = ""
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
            If FormatNumber(dDebitT.Value, 2) <> FormatNumber(dCreditT.Value, 2) Then
                MsgBox("Debit and Credit is not equal, please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
            Dim TheSameCashInBank As Boolean
            Dim CashInBankExist As Boolean
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                If (If(IsNumeric(DT_Account(x)("Debit")), CDbl(DT_Account(x)("Debit")), 0) > 0 And If(IsNumeric(DT_Account(x)("Credit")), CDbl(DT_Account(x)("Credit")), 0) > 0) Or (DT_Account(x)("Account") = "" And (If(IsNumeric(DT_Account(x)("Debit")), CDbl(DT_Account(x)("Debit")), 0) > 0 Or If(IsNumeric(DT_Account(x)("Credit")), CDbl(DT_Account(x)("Credit")), 0) > 0)) Or (DT_Account(x)("RequiredRemarks").ToString = "True" And DT_Account(x)("Remarks") = "") Or (DT_Account(x)("Account") <> "" And DT_Account(x)("Department") = "") Then
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
            If cbxPreparedBy.Text = "" Or cbxPreparedBy.SelectedIndex = -1 Then
                MsgBox("Please select Prepared By.", MsgBoxStyle.Information, "Info")
                cbxPreparedBy.DroppedDown = True
                Exit Sub
            End If

            Dim Open As String = DataObject(String.Format("SELECT IF('{2}' = 'Jan',Jan,IF('{2}' = 'Feb',Feb,IF('{2}' = 'Mar',Mar,IF('{2}' = 'Apr',Apr,IF('{2}' = 'May',May,IF('{2}' = 'Jun',Jun,IF('{2}' = 'Jul',Jul,IF('{2}' = 'Aug',Aug,IF('{2}' = 'Sep',Sep,IF('{2}' = 'Oct',`Oct`,IF('{2}' = 'Nov',Nov,IF('{2}' = 'Dec',`Dec`,'X')))))))))))) FROM accounting_period WHERE Branch = '{0}' AND `status` = 'ACTIVE' AND `Year` = '{1}';", Branch_Code, Format(dtpPostingDate.Value, "yyyy"), Format(dtpPostingDate.Value, "MMM")))
            If If(Open = "", "Open", Open) = "Open" Then
            Else
                MsgBox(String.Format("Accounting Period for your branch is already {0}. Transaction with this date is not allowed.", If(Open = "Lock", "Locked", If(Open = "Close", "Closed", Open))), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            Dim drv_2 As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
            If Refinance Or CVforJV Then
                Dim TotalDebitLR As Double
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "MotherCode") = "112000" Then
                        TotalDebitLR += GridView2.GetRowCellValue(x, "Debit")
                    End If
                Next
                If drv("Amount") <> TotalDebitLR Then
                    If MsgBoxYes("Approved Loan Amount is not equal with total Loans Receivable, would you like to proceed?") = MsgBoxResult.Yes Then
                    Else
                        Exit Sub
                    End If
                End If
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
                    If DocumentNumberExist("journal_voucher", txtDocumentNumber.Text) Then
                        Exit Sub
                    End If
                    Dim SQL As String = "INSERT INTO journal_voucher SET"
                    SQL &= String.Format(" Payee_ID = '{0}', ", ValidateComboBox(cbxPayee))
                    SQL &= String.Format(" Payee = '{0}', ", cbxPayee.Text.InsertQuote)
                    SQL &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" ORNum = '{0}', ", txtORNumber.Text)
                    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpORDate.Value, "yyyy-MM-dd"))
                    If From_ROPOA Then
                        SQL &= " JVFrom = 'ROPOA', "
                    ElseIf From_ITL Then
                        SQL &= " JVFrom = 'ITL', "
                    ElseIf From_Impairment Then
                        SQL &= " JVFrom = 'Impairment', "
                    ElseIf From_Ledger Then
                        SQL &= " JVFrom = 'Ledger', "
                    ElseIf From_Case Then
                        SQL &= " JVFrom = 'Case', "
                    ElseIf From_Check Then
                        SQL &= " JVFrom = 'From Check', "
                    Else
                        SQL &= String.Format(" JVFrom = '{0}', ", If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")))
                    End If
                    SQL &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote)
                    SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                    SQL &= " CheckedID = '0', "
                    SQL &= " ApprovedID = '0', "
                    SQL &= " OTAC_Approve = '', "
                    SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                    SQL &= String.Format(" User_Code = '{0}', ", User_Code)
                    SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                    SQL &= String.Format(" BounceID = '{0}', ", BounceID)
                    SQL &= String.Format(" Bounce = '{0}', ", Bounce)
                    SQL &= String.Format(" BounceRemarks = '{0}', ", BounceRemarks)
                    If From_ITL Or From_Case Then
                        SQL &= String.Format(" ReferenceID = '{0}', ", txtORNumber.Tag)
                    ElseIf From_Check Then
                        If MultipleDT Then
                            SQL &= String.Format(" ReferenceID = '{0}', ", If(CheckID = 0, DueToID_M, CheckID))
                        Else
                            SQL &= String.Format(" ReferenceID = '{0}', ", CheckID)
                        End If
                    Else
                        SQL &= String.Format(" ReferenceID = '{0}', ", If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", If(drv("PaidFrom") = "Official Receipt" Or drv("PaidFrom") = "DTS" Or drv("PaidFrom") = "DTS JV" Or drv("PaidFrom") = "DTS CV" Or drv("PaidFrom") = "Loans" Or drv("PaidFrom") = "Acknowledgement CAS" Or drv("PaidFrom") = "Acknowledgement RO" Or drv("PaidFrom") = "Acknowledgement LA", drv("Payee_ID"), drv("ORNum"))))
                    End If
                    If (cbxBank.SelectedValue <> BankID And BankID <> 0) Or cbxDTS_RS.Checked Then
                        SQL &= " DTS = 1, "
                    End If
                    If Refinance Then
                        SQL &= " Refinance = 1, "
                    End If
                    If CVforJV Then
                        SQL &= " CVforJV = 1, "
                    End If
                    SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)
                    For x As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SQL &= "INSERT INTO jv_details SET"
                            SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQL &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                            If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Official Receipt" Or (If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "DTS CV" And GridView2.GetRowCellValue(x, "AR_DocumentNumber").ToString <> "") Then
                                SQL &= String.Format(" AR_DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "AR_DocumentNumber"))
                            End If
                            SQL &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)

                            'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                            Dim SQLv2 As String = ""
                            If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from")) Then
                                Dim ARNumber As String
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                If cbxPayee.Text = "" Or cbxPayee.SelectedIndex = -1 Then
                                Else
                                    If drv("PaidFrom") = "Accounts Receivable" Then
                                        SQLv2 &= String.Format(" UPDATE accounts_receivable SET Amount = 0, NotAR = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    ElseIf drv("PaidFrom") = "Due From" Then
                                        SQLv2 &= String.Format(" UPDATE due_from SET Amount = 0, NotAR = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    End If
                                End If

                                Dim SameAccount As Boolean
                                Dim NetAmount As Double
                                For y As Integer = 0 To Temp_DT.Rows.Count - 1
                                    If Temp_DT(y)("Account Code") = GridView2.GetRowCellValue(x, "Account Code") And CDbl(Temp_DT(y)("Credit")) > 0 And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 Then
                                        SameAccount = True
                                        NetAmount = NegativeNotAllowed(CDbl(Temp_DT(y)("Credit")) - CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                        Exit For
                                    End If
                                Next

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
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Amount = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                End If
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
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Credit = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                End If
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            ElseIf (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to")) And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 Then
                                Dim APNumber As String = ""
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                If cbxPayee.Text = "" Or cbxPayee.SelectedIndex = -1 Then
                                Else
                                    If drv("PaidFrom") = "Accounts Payable" Then
                                        SQLv2 &= String.Format(" UPDATE accounts_payable SET Amount = 0, NotAP = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    ElseIf drv("PaidFrom") = "Due To" Then
                                        SQLv2 &= String.Format(" UPDATE due_to SET Amount = 0, NotAP = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    End If
                                End If

                                Dim SameAccount As Boolean
                                Dim NetAmount As Double
                                For y As Integer = 0 To Temp_DT.Rows.Count - 1
                                    If Temp_DT(y)("Account Code") = GridView2.GetRowCellValue(x, "Account Code") And CDbl(Temp_DT(y)("Debit")) > 0 And CDbl(GridView2.GetRowCellValue(x, "Debit")) > 0 Then
                                        SameAccount = True
                                        NetAmount = NegativeNotAllowed(CDbl(Temp_DT(y)("Debit")) - CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        Exit For
                                    End If
                                Next

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
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Amount = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                End If
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
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Debit = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                End If
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Payable") Then
                                Dim APNumber As String = ""
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                If cbxPayee.Text = "" Or cbxPayee.SelectedIndex = -1 Then
                                Else
                                    If drv("PaidFrom") = "Loans Payable" Then
                                        SQLv2 &= String.Format(" UPDATE loans_payable SET Amount = 0, NotAP = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    End If
                                End If

                                Dim SameAccount As Boolean
                                Dim NetAmount As Double
                                For y As Integer = 0 To Temp_DT.Rows.Count - 1
                                    If Temp_DT(y)("Account Code") = GridView2.GetRowCellValue(x, "Account Code") And CDbl(Temp_DT(y)("Debit")) > 0 And CDbl(GridView2.GetRowCellValue(x, "Debit")) > 0 Then
                                        SameAccount = True
                                        NetAmount = NegativeNotAllowed(CDbl(Temp_DT(y)("Debit")) - CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        Exit For
                                    End If
                                Next

                                APNumber = DataObject(String.Format("SELECT CONCAT('LP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM loans_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

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
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Amount = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                End If
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
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Debit = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                End If
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            End If
                            If SQLv2 = "" Then
                            Else
                                DataObject(SQLv2)
                            End If
                            'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                        End If
                    Next
                    If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                        If From_Check Then
                            If MultipleDT Then
                                SQL &= String.Format("UPDATE dc_details SET `check_status` = 'CLEARED', Remarks = CONCAT(Remarks, ' [', 'CLEARED CHECK',']') WHERE ID IN ({0}) AND `status` = 'ACTIVE';", If(CheckID = 0, DueToID_M, CheckID))
                                If DTPayPrincipal Then
                                    Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount - Paid AS 'Payable' FROM due_to WHERE DC_ID = (SELECT ID FROM due_check WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE') AND `status` = 'ACTIVE';", DueToDocumentNumber))
                                    Dim TotalPayment As Double = dDebitT.Value
                                    For x As Integer = 0 To vDT.Rows.Count - 1
                                        If TotalPayment - CDbl(vDT(x)("Payable")) = 0 Then
                                            SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment)
                                            Exit For
                                        ElseIf TotalPayment - CDbl(vDT(x)("Payable")) > 0 Then
                                            SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Payable")))
                                            TotalPayment -= CDbl(vDT(x)("Payable"))
                                        Else
                                            SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment)
                                            Exit For
                                        End If
                                    Next
                                End If
                            Else
                                If DTPayPrincipal Then
                                    SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", DueToDocumentNumber, dDebitT.Value)
                                End If
                                SQL &= String.Format("UPDATE dc_details SET `check_status` = 'CLEARED', Remarks = CONCAT(Remarks, ' [', 'CLEARED CHECK',']') WHERE ID = '{0}';", CheckID)
                            End If
                        End If
                    Else
                        If drv("PaidFrom").ToString.Contains("Acknowledgement") Or drv("PaidFrom").ToString.Contains("Unrealized") Then
                            'UPDATE ACKNOWLEDGEMENT ********************************************************************************************
                            SQL &= " UPDATE acknowledgement_receipt SET"
                            '***IF FULLY PAID
                            SQL &= String.Format(" JVNumber = '{0}'", txtDocumentNumber.Text)
                            SQL &= String.Format(" WHERE DocumentNumber = '{0}';", drv("ReferenceN"))

                            If drv("PaidFrom").ToString = "Acknowledgement RO" Then
                                Dim CountRemainingACR As Integer = DataObject(String.Format("SELECT COUNT(ID) FROM acknowledgement_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'RO' AND `status` = 'ACTIVE' AND JVNumber = '' AND DocumentNumber != '{1}';", drv("Payee_ID"), drv("ReferenceN")))
                                If CountRemainingACR = 0 Then
                                    SQL &= String.Format("UPDATE sold_ropoa SET `status` = 'CANCELLED', JVNumber = '{1}' WHERE AssetNumber = '{0}' AND `status` = 'ACTIVE';", drv("Payee_ID"), txtDocumentNumber.Text)
                                    If drv("Payee_ID").ToString.Contains("ANV") Then
                                        SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = 'SELL' WHERE AssetNumber = '{0}';", drv("Payee_ID"))
                                    Else
                                        SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = 'SELL' WHERE AssetNumber = '{0}';", drv("Payee_ID"))
                                    End If
                                Else
                                    If drv("Payee_ID").ToString.Contains("ANV") Then
                                        SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = 'RESERVED' WHERE AssetNumber = '{0}' AND sell_status = 'SOLD';", drv("Payee_ID"))
                                    Else
                                        SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = 'RESERVED' WHERE AssetNumber = '{0}' AND sell_status = 'SOLD';", drv("Payee_ID"))
                                    End If
                                End If
                            End If
                            'UPDATE ACKNOWLEDGEMENT ********************************************************************************************
                        ElseIf drv("PaidFrom") = "Official Receipt" Then
                            SQL &= " UPDATE official_receipt SET"
                            SQL &= String.Format(" JVNumber = '{0}'", txtDocumentNumber.Text)
                            SQL &= String.Format(" WHERE DocumentNumber = '{0}';", drv("ReferenceN"))

                            If CDbl(drv("Cash Advance")) > 0 Then 'TOTAL WAIVE RPPD NI SYA NAA LANG NA BELONG SA CASH ADVANCE COLUMN
                                SQL &= "INSERT INTO accounting_entry SET"
                                SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                                SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                SQL &= String.Format(" ORNum = '{0}', ", drv("ORNum"))
                                SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                SQL &= String.Format(" ReferenceN = '{0}', ", drv("Payee_ID"))
                                SQL &= " EntryType = 'DEBIT',"
                                SQL &= " AccountCode = '', " 'Waived RPPD
                                SQL &= " MotherCode = '', " 'Waived Penalty
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(drv("Cash Advance")))
                                SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-W")
                                SQL &= String.Format(" Remarks = '{0}', ", "Waive for RPPD [Reversal]")
                                SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                                SQL &= String.Format(" BankID = '{0}', ", BankID)
                                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                            End If
                        ElseIf drv("PaidFrom") = "DTS" Then
                            SQL &= " UPDATE official_receipt SET"
                            SQL &= String.Format(" DTS_JVNumber = '{0}'", txtDocumentNumber.Text)
                            SQL &= String.Format(" WHERE DocumentNumber = '{0}';", drv("ReferenceN"))

                            Dim TotalUDI As Double
                            Dim TotalPrincipal As Double
                            For x As Integer = 0 To GridView2.RowCount - 1
                                If GridView2.GetRowCellValue(x, "PaidFor") = "UDI" Then
                                    TotalUDI += CDbl(GridView2.GetRowCellValue(x, "Credit"))
                                End If
                                If GridView2.GetRowCellValue(x, "PaidFor") = "Principal" Then
                                    TotalPrincipal += CDbl(GridView2.GetRowCellValue(x, "Credit"))
                                End If
                            Next
                            Dim SOA As New FrmSOA
                            With SOA
                                .From_JV_DTS = True
                                .dUDI_DTS = TotalUDI
                                .dPrincipal_DTS = TotalPrincipal
                                .CreditNumber = drv("Payee_ID")
                                .dtpAsOf.Value = dtpPostingDate.Value
                                .WindowState = FormWindowState.Minimized
                                .Show()
                                AvailedRPPD = .Availed_RPPD
                                .Dispose()
                            End With
                            If AvailedRPPD > 0 Then
                                SQL &= "INSERT INTO accounting_entry SET"
                                SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                                SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                                SQL &= String.Format(" ReferenceN = '{0}', ", drv("Payee_ID"))
                                SQL &= " EntryType = 'CREDIT',"
                                SQL &= " AccountCode = '', " 'Availed
                                SQL &= " MotherCode = '', " 'Availed
                                SQL &= String.Format(" Payable = '{0}', ", AvailedRPPD)
                                SQL &= String.Format(" Amount = '{0}', ", AvailedRPPD)
                                SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                                SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD")
                                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                            End If
                        ElseIf drv("PaidFrom") = "DTS JV" Then
                            SQL &= " UPDATE journal_voucher SET"
                            SQL &= String.Format(" DTS_JVNumber = '{0}'", txtDocumentNumber.Text)
                            SQL &= String.Format(" WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                        ElseIf drv("PaidFrom") = "DTS CV" Then
                            SQL &= " UPDATE check_voucher SET"
                            SQL &= String.Format(" DTS_JVNumber = '{0}'", txtDocumentNumber.Text)
                            SQL &= String.Format(" WHERE DocumentNumber = '{0}';", drv("ReferenceN"))

                            SQL &= " UPDATE credit_application SET"
                            SQL &= String.Format(" BankID = '{0}'", cbxBank.SelectedValue)
                            SQL &= String.Format(" WHERE CreditNumber = '{0}';", drv("Payee_ID"))

                            Dim RPPD As Double
                            Dim DistributeTotalAdvance As Double = TotalAdvance
                            For y As Integer = 1 To GridView4.RowCount - 1
                                If DistributeTotalAdvance > 0 Then
                                    If DistributeTotalAdvance >= (CDbl(GridView4.GetRowCellValue(y, "Monthly")) - CDbl(GridView4.GetRowCellValue(y, "RPPD"))) Then
                                        RPPD += CDbl(GridView4.GetRowCellValue(y, "RPPD"))
                                        DistributeTotalAdvance -= (CDbl(GridView4.GetRowCellValue(y, "Monthly")) - CDbl(GridView4.GetRowCellValue(y, "RPPD")))
                                    End If
                                End If
                            Next
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" ReferenceN = '{0}', ", drv("Payee_ID"))
                            SQL &= " AccountCode = '', " 'Availed
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= String.Format(" Payable = '{0}', ", RPPD)
                            SQL &= String.Format(" Amount = '{0}', ", RPPD)
                            SQL &= " `Status` = 'PENDING',"
                            SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                            SQL &= String.Format(" Remarks = '{0}', ", "Availed RPPD")
                            SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        ElseIf drv("PaidFrom") = "Liquidation" Then
                            SQL &= String.Format(" UPDATE liquidation_main SET JVNumber = '{1}' WHERE ID = '{0}';", ValidateComboBox(cbxPayee), txtDocumentNumber.Text)
                        ElseIf drv("PaidFrom") = "Accounts Payable" Then
                            SQL &= String.Format(" UPDATE accounts_payable SET JVNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                        ElseIf drv("PaidFrom") = "Accounts Receivable" Then
                            SQL &= String.Format(" UPDATE accounts_receivable SET JVNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                        ElseIf drv("PaidFrom") = "Due To" Then
                            SQL &= String.Format(" UPDATE due_to SET JVNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                        ElseIf drv("PaidFrom") = "Due From" Then
                            SQL &= String.Format(" UPDATE due_from SET JVNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                        ElseIf drv("PaidFrom") = "Check Voucher" Then
                            SQL &= String.Format(" UPDATE check_voucher SET JVNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                            '*UPDATE credit_applicat i set ang PaymentRequest para dli ma release
                            SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'JV Request' WHERE CreditNumber = '{0}';", drv("Payee_ID"))
                        ElseIf drv("PaidFrom") = "Journal Voucher" Then
                            SQL &= String.Format(" UPDATE journal_voucher SET JVNumber = '{0}' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                        ElseIf drv("PaidFrom") = "Restructuring" Then
                            SQL &= String.Format("UPDATE Credit_Application SET JVNumber = '{1}' WHERE CreditNumber = '{0}';", cbxPayee.SelectedValue, txtDocumentNumber.Text)
                        ElseIf CVforJV Then
                            SQL &= String.Format("UPDATE credit_application SET `PaymentRequest` = 'REQUESTED', BankID = {1} WHERE CreditNumber = '{0}' AND `PaymentRequest` != 'RELEASED';", drv("Payee_ID"), ValidateComboBox(cbxBank))
                        End If
                    End If
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                    Else
                        If drv("PaidFrom") = "Official Receipt" Then 'UPDATE ACCOUNTING ENTRY OF OR BUTANGAN OG JV ANG JVNUMBER 
                            SQL &= String.Format("UPDATE accounting_entry SET JVNumber = '{0}' WHERE REPLACE(ORNum,' [Discount]','') = '{1}';", txtDocumentNumber.Text, drv("ORNum"))
                            SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE PaymentRequest = 'CLOSED' AND CreditNumber = '{0}';", drv("Payee_ID"))
                        End If
                        If drv("PaidFrom") = "Journal Voucher" Then 'UPDATE ACCOUNTING ENTRY OF JV BUTANGAN OG JV ANG JVNUMBER 
                            SQL &= String.Format("UPDATE accounting_entry SET JVNumber = '{0}' WHERE JVNum = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                        End If
                        If drv("PaidFrom").ToString.Contains("Acknowledgement") Then 'UPDATE ACCOUNTING ENTRY OF OR BUTANGAN OG JV ANG JVNUMBER 
                            SQL &= String.Format("UPDATE accounting_entry SET JVNumber = '{0}' WHERE ORNum = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                        End If
                    End If
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                                If From_Case And CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                    SQL &= String.Format(" ReferenceN = '{0}', ", txtReferenceNumber.Text)
                                ElseIf From_Case And CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0 Then
                                    SQL &= String.Format(" ReferenceN = '{0}', ", txtORNumber.Tag)
                                Else
                                    SQL &= String.Format(" ReferenceN = '{0}', ", txtDocumentNumber.Text)
                                End If
                            Else
                                If Refinance Then
                                    SQL &= String.Format(" ReferenceN = '{0}', ", If(GridView2.GetRowCellValue(x, "PaidFor") = "", drv("Payee_ID"), GridView2.GetRowCellValue(x, "PaidFor")))
                                ElseIf From_Case And CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                    SQL &= String.Format(" ReferenceN = '{0}', ", txtReferenceNumber.Text)
                                ElseIf From_Case And CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0 Then
                                    SQL &= String.Format(" ReferenceN = '{0}', ", txtORNumber.Tag)
                                ElseIf From_ROPOA Or From_Impairment Or From_Ledger Or From_Case Then
                                    SQL &= String.Format(" ReferenceN = '{0}', ", txtReferenceNumber.Text)
                                ElseIf From_ITL Or From_Case Then
                                    SQL &= String.Format(" ORNum = '{0}', ", txtReferenceNumber.Text)
                                    SQL &= String.Format(" ReferenceN = '{0}', ", txtORNumber.Tag)
                                ElseIf drv("PaidFrom") = "Loans" Or drv("PaidFrom") = "Official Receipt" Or drv("PaidFrom") = "DTS" Or drv("PaidFrom") = "DTS JV" Or drv("PaidFrom") = "DTS CV" Or drv("PaidFrom").ToString.Contains("Acknowledgement") Or cbxUR.Checked Then
                                    If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom").ToString.Contains("Acknowledgement")) Then
                                        SQL &= String.Format(" ReferenceN = '{0}', ", drv("Payee_ID"))
                                    ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "DTS CV" And GridView2.GetRowCellValue(x, "AR_DocumentNumber").ToString <> "" Then
                                        SQL &= String.Format(" ReferenceN = '{0}', ", GridView2.GetRowCellValue(x, "AR_DocumentNumber"))
                                    Else
                                        SQL &= String.Format(" ReferenceN = '{0}', ", drv("Payee_ID"))
                                    End If
                                ElseIf drv("PaidFrom") = "Deferred Income" Then
                                    SQL &= String.Format(" ReferenceN = '{0}', ", drv("ORNum"))
                                ElseIf drv("PaidFrom") = "Restructuring" Then
                                    SQL &= String.Format(" ReferenceN = '{0}', ", drv("AmountDue"))
                                ElseIf drv("PaidFrom") = "Journal Voucher" And drv("ORNum") <> "" Then
                                    SQL &= String.Format(" ORNum = '{0}', ", drv("ReferenceN"))
                                    SQL &= String.Format(" ReferenceN = '{0}', ", drv("ORNum"))
                                ElseIf drv("PaidFrom") = "Accounts Receivable" Then
                                    SQL &= String.Format(" ReferenceN = '{0}', ", drv("Payee_ID"))
                                Else
                                    SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                                End If
                            End If
                            If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                SQL &= " EntryType = 'DEBIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            Else
                                SQL &= " EntryType = 'CREDIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            End If
                            If If(cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")) = "Official Receipt" Then
                                SQL &= String.Format(" ORNum = '{0}', ", drv("ORNum"))
                            End If
                            If If(cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")) = "Accounts Receivable" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 And If(cbxPayee.SelectedIndex = -1, 0, drv("Payee_ID").ToString.Contains("CA")) Then
                                SQL &= " PaidFor = 'Billing', "
                            ElseIf If(cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")) = "Restructuring" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 And GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Receivable") Then
                                SQL &= " PaidFor = 'Principal', "
                            ElseIf GridView2.GetRowCellValue(x, "PaidFor") = "" And GridView2.GetRowCellValue(x, "Account Code") <> "" Then
                                SQL &= " PaidFor = 'Journal Voucher', "
                            Else
                                SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                            End If
                            If GridView2.GetRowCellValue(x, "PaidFor") = "Penalty" And If(cbxPayee.SelectedIndex = -1, False, drv("PaidFrom") = "Official Receipt") Then 'Penalty Reversal balik ang bayranan
                                If CDbl(drv("AmountDue")) > 0 Then
                                    SQL &= String.Format(" PenaltyPayable = '{0}', ", CDbl(drv("AmountDue")))
                                Else
                                    SQL &= String.Format(" PenaltyPayable = '{0}', ", NegativeNotAllowed(DataObject(String.Format("SELECT IFNULL(PenaltyPayable + Amount,0) FROM accounting_entry WHERE ReferenceN = '{0}' AND ORNum = '{1}' AND `status` = 'ACTIVE' AND PaidFor = 'Penalty';", drv("Payee_ID"), drv("ORNum"))) - CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                End If
                            End If
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= " `Status` = 'PENDING',"
                            SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", False, drv("PaidFrom") = "Journal Voucher") Then 'IF ANG OR GI JV THEN ANG JV GI JV
                                'CHECK IF NAKA CREDIT SIDE ANG ENTRY KAY PARA I REVERSER
                                Dim DT_Availed As DataTable = DataSource(String.Format("SELECT EntryType FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND PaidFor = 'RPPD-A' AND CVNumber = '{0}';", drv("ReferenceN")))
                                If DT_Availed.Rows.Count > 0 Then
                                    If DT_Availed(0)("EntryType") = "CREDIT" Then
                                        SQL &= String.Format(" JVNumber = '{0}', ", txtDocumentNumber.Text)
                                    End If
                                End If
                            End If
                            If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Restructuring" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 And GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Receivable") Then
                                SQL &= String.Format(" Remarks = '{0}', ", txtDocumentNumber.Text & " " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote & " " & If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", If(drv("PaidFrom") = "Official Receipt" Or drv("PaidFrom").ToString.Contains("Acknowledgement"), "[Reversal]", "")))
                            Else
                                SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote & " " & If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", If(drv("PaidFrom") = "Official Receipt" Or drv("PaidFrom").ToString.Contains("Acknowledgement"), "[Reversal]", "")))
                            End If
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                    Next
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                    Else
                        If drv("PaidFrom") = "Official Receipt" Then 'ACCOUNTING ENTRY FOR AVAILED RPPD
                            Dim DT_Availed As DataTable = DataSource(String.Format("SELECT * FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND PaidFor = 'RPPD-A' AND CVNumber = '{0}';", drv("ORNum")))
                            If DT_Availed.Rows.Count > 0 Then
                                For x As Integer = 0 To DT_Availed.Rows.Count - 1
                                    SQL &= "INSERT INTO accounting_entry SET"
                                    SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" ReferenceN = '{0}', ", DT_Availed(x)("ReferenceN"))
                                    If DT_Availed(x)("EntryType") = "CREDIT" Then
                                        SQL &= " EntryType = 'DEBIT',"
                                    Else
                                        SQL &= " EntryType = 'CREDIT',"
                                    End If
                                    SQL &= String.Format(" Payable = '{0}', ", CDbl(DT_Availed(x)("Payable")))
                                    SQL &= String.Format(" Amount = '{0}', ", CDbl(DT_Availed(x)("Amount")))
                                    SQL &= String.Format(" ORNum = '{0}', ", drv("ORNum"))
                                    SQL &= " PaidFor = 'RPPD-A', "
                                    SQL &= " AccountCode = '', "
                                    SQL &= " `Status` = 'ACTIVE',"
                                    SQL &= " `PostStatus` = 'POSTED',"
                                    SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                                    SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= " Remarks = '[Reversal]', "
                                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                                Next
                            End If
                            Dim DT_Discount As DataTable = DataSource(String.Format("SELECT * FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND CVNumber = '{0}';", drv("ORNum") & " [Discount]"))
                            If DT_Discount.Rows.Count > 0 Then
                                For x As Integer = 0 To DT_Discount.Rows.Count - 1
                                    SQL &= "INSERT INTO accounting_entry SET"
                                    SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                                    SQL &= String.Format(" ReferenceN = '{0}', ", DT_Discount(x)("ReferenceN"))
                                    If DT_Discount(x)("EntryType") = "CREDIT" Then
                                        SQL &= " EntryType = 'DEBIT',"
                                    Else
                                        SQL &= " EntryType = 'CREDIT',"
                                    End If
                                    SQL &= String.Format(" Payable = '{0}', ", CDbl(DT_Discount(x)("Payable")))
                                    SQL &= String.Format(" Amount = '{0}', ", CDbl(DT_Discount(x)("Amount")))
                                    SQL &= String.Format(" ORNum = '{0}', ", drv("ORNum"))
                                    SQL &= String.Format(" PaidFor = '{0}', ", DT_Discount(x)("PaidFor"))
                                    SQL &= " AccountCode = '', "
                                    SQL &= " `Status` = 'ACTIVE',"
                                    SQL &= " `PostStatus` = 'POSTED',"
                                    SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                                    SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                                    SQL &= " Remarks = '[Reversal]', "
                                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                                Next
                            End If
                        End If
                        If drv("PaidFrom") = "Journal Voucher" Then 'IF ANG OR GI JV THEN ANG JV GI JV
                            Dim DT_Availed As DataTable = DataSource(String.Format("SELECT * FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND PaidFor = 'RPPD-A' AND CVNumber = '{0}';", drv("ReferenceN")))
                            If DT_Availed.Rows.Count > 0 Then
                                For x As Integer = 0 To DT_Availed.Rows.Count - 1
                                    SQL &= "INSERT INTO accounting_entry SET"
                                    SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" ReferenceN = '{0}', ", DT_Availed(x)("ReferenceN"))
                                    If DT_Availed(x)("EntryType") = "CREDIT" Then
                                        SQL &= " EntryType = 'DEBIT',"
                                        SQL &= " Remarks = '[Reversal]', "
                                        SQL &= String.Format(" JVNumber = '{0}', ", txtDocumentNumber.Text)
                                    Else
                                        SQL &= " EntryType = 'CREDIT',"
                                        SQL &= " Remarks = '', "
                                    End If
                                    SQL &= String.Format(" Payable = '{0}', ", CDbl(DT_Availed(x)("Payable")))
                                    SQL &= String.Format(" Amount = '{0}', ", CDbl(DT_Availed(x)("Amount")))
                                    SQL &= String.Format(" ORNum = '{0}', ", drv("ReferenceN"))
                                    SQL &= " PaidFor = 'RPPD-A', "
                                    SQL &= " AccountCode = '', "
                                    SQL &= " `Status` = 'ACTIVE',"
                                    SQL &= " `PostStatus` = 'POSTED',"
                                    SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                                    SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                                Next
                            End If
                        End If
                    End If
                    If From_Ledger Then
                        For x As Integer = 0 To GridView2.RowCount - 1
                            If MortgageID = 1 Then
                                SQL &= String.Format("UPDATE collateral_ve SET Surrendered = 1 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "PaidFor"))
                            Else
                                SQL &= String.Format("UPDATE collateral_re SET Surrendered = 1 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "PaidFor"))
                            End If
                        Next
                    End If

                    DataObject(SQL)
                    Cursor = Cursors.Default

                    Logs("Journal Voucher", "Save", String.Format("Add new Journal Voucher for {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")
                    MsgBox("Successfully Saved!" & mEmail, MsgBoxStyle.Information, "Info")

                    If From_ACR Or From_LOE Or From_GL Or From_Check Or From_ROPOA Or From_ITL Or From_Impairment Or From_Ledger Or From_Case Then
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.PerformClick()
                    Else
                        Clear(True)
                        LoadPayee()
                    End If
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM journal_voucher WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
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

                    Dim SQL As String = "UPDATE journal_voucher SET"
                    SQL &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" ORNum = '{0}', ", txtORNumber.Text)
                    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpORDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    If txtCheck.Text = "" Then
                        SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                    ElseIf txtApproved.Text = "" Then
                        SQL &= String.Format(" OTAC_Approve = '{0}', ", Code)
                    End If
                    SQL &= String.Format(" Explanation = '{0}' ", rExplanation.Text.InsertQuote)
                    SQL &= String.Format(" WHERE ID = '{0}';", ID)
                    SQL &= String.Format(" UPDATE jv_details SET `status` = 'CANCELLED' WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    Dim SQLv3 As String = ""
                    SQLv3 &= String.Format(" UPDATE accounts_receivable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE accounts_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE due_from SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE due_to SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE loans_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    DataObject(SQLv3)

                    If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Accounts Receivable" Then
                        Temp_DT = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = ar_details.AccountCode) AS 'Account', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', Remarks, Required AS 'RequiredRemarks' FROM ar_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", drv("ReferenceN")))
                    ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Accounts Payable" Then
                        Temp_DT = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = ap_details.AccountCode) AS 'Account', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', Remarks, Required AS 'RequiredRemarks' FROM ap_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", drv("ReferenceN")))
                    End If

                    For x As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SQL &= "INSERT INTO jv_details SET"
                            SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQL &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                            If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Official Receipt" Or (If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "DTS CV" And GridView2.GetRowCellValue(x, "AR_DocumentNumber").ToString <> "") Then
                                SQL &= String.Format(" AR_DocumentNumber = '{0}', ", GridView2.GetRowCellValue(x, "AR_DocumentNumber"))
                            End If
                            SQL &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)

                            'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                            Dim SQLv2 As String = ""
                            If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from")) Then
                                Dim ARNumber As String
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                If cbxPayee.Text = "" Or cbxPayee.SelectedIndex = -1 Then
                                Else
                                    If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Accounts Receivable" Then
                                        SQLv2 &= String.Format(" UPDATE accounts_receivable SET Amount = 0, NotAR = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Due From" Then
                                        SQLv2 &= String.Format(" UPDATE due_from SET Amount = 0, NotAR = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    End If
                                End If

                                Dim SameAccount As Boolean
                                Dim NetAmount As Double
                                For y As Integer = 0 To Temp_DT.Rows.Count - 1
                                    If Temp_DT(y)("Account Code") = GridView2.GetRowCellValue(x, "Account Code") And CDbl(Temp_DT(y)("Credit")) > 0 And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 Then
                                        SameAccount = True
                                        NetAmount = NegativeNotAllowed(CDbl(Temp_DT(y)("Credit")) - CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                        Exit For
                                    End If
                                Next

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
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Amount = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                End If
                                SQLv2 &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote & " - " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                SQLv2 &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                                SQLv2 &= String.Format(" CheckedID = '{0}', ", txtCheck.Tag)
                                If txtCheck.Tag > 0 Then
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
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Credit = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                End If
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            ElseIf (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to")) And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 Then
                                Dim APNumber As String = ""
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                If cbxPayee.Text = "" Or cbxPayee.SelectedIndex = -1 Then
                                Else
                                    If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Accounts Payable" Then
                                        SQLv2 &= String.Format(" UPDATE accounts_payable SET Amount = 0, NotAP = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Due To" Then
                                        SQLv2 &= String.Format(" UPDATE due_to SET Amount = 0, NotAP = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    End If
                                End If

                                Dim SameAccount As Boolean
                                Dim NetAmount As Double
                                For y As Integer = 0 To Temp_DT.Rows.Count - 1
                                    If Temp_DT(y)("Account Code") = GridView2.GetRowCellValue(x, "Account Code") And CDbl(Temp_DT(y)("Debit")) > 0 And CDbl(GridView2.GetRowCellValue(x, "Debit")) > 0 Then
                                        SameAccount = True
                                        NetAmount = NegativeNotAllowed(CDbl(Temp_DT(y)("Debit")) - CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        Exit For
                                    End If
                                Next

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
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Amount = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                End If
                                SQLv2 &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote & " - " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                SQLv2 &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                                SQLv2 &= String.Format(" CheckedID = '{0}', ", txtCheck.Tag)
                                If txtCheck.Tag > 0 Then
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
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Debit = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                End If
                                SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Payable") Then
                                Dim APNumber As String = ""
                                Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                                If cbxPayee.Text = "" Or cbxPayee.SelectedIndex = -1 Then
                                Else
                                    If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Loans Payable" Then
                                        SQLv2 &= String.Format(" UPDATE loans_payable SET Amount = 0, NotAP = 1 WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                                    End If
                                End If

                                Dim SameAccount As Boolean
                                Dim NetAmount As Double
                                For y As Integer = 0 To Temp_DT.Rows.Count - 1
                                    If Temp_DT(y)("Account Code") = GridView2.GetRowCellValue(x, "Account Code") And CDbl(Temp_DT(y)("Debit")) > 0 And CDbl(GridView2.GetRowCellValue(x, "Debit")) > 0 Then
                                        SameAccount = True
                                        NetAmount = NegativeNotAllowed(CDbl(Temp_DT(y)("Debit")) - CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        Exit For
                                    End If
                                Next

                                APNumber = DataObject(String.Format("SELECT CONCAT('LP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM loans_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

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
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Amount = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Amount = '{0}', ", If(CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0, CDbl(GridView2.GetRowCellValue(x, "Credit")), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                End If
                                SQLv2 &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote & " - " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                SQLv2 &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                                SQLv2 &= String.Format(" CheckedID = '{0}', ", txtCheck.Tag)
                                If txtCheck.Tag > 0 Then
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
                                SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                If SameAccount Then
                                    SQLv2 &= String.Format(" Debit = '{0}', ", NetAmount)
                                Else
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                End If
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
                    SQL &= String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE REPLACE(CVNumber,' [Discount]','') = '{0}' AND IF(PaidFor = 'RPPD-A',TRUE,TRUE);", txtDocumentNumber.Text)
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        SQL &= "INSERT INTO accounting_entry SET"
                        SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                        If Refinance Then
                            SQL &= String.Format(" ReferenceN = '{0}', ", If(GridView2.GetRowCellValue(x, "PaidFor") = "", drv("Payee_ID"), GridView2.GetRowCellValue(x, "PaidFor")))
                        ElseIf From_Case And CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                            SQL &= String.Format(" ReferenceN = '{0}', ", txtReferenceNumber.Text)
                        ElseIf From_Case And CDbl(GridView2.GetRowCellValue(x, "Debit")) = 0 Then
                            SQL &= String.Format(" ReferenceN = '{0}', ", txtORNumber.Tag)
                        ElseIf From_ROPOA Or From_Impairment Or From_Ledger Or From_Case Then
                            SQL &= String.Format(" ReferenceN = '{0}', ", txtReferenceNumber.Text)
                        ElseIf From_ITL Or From_Case Then
                            SQL &= String.Format(" ORNum = '{0}', ", txtReferenceNumber.Text)
                            SQL &= String.Format(" ReferenceN = '{0}', ", txtORNumber.Tag)
                        ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Loans" Or drv("PaidFrom") = "Official Receipt" Or drv("PaidFrom") = "DTS" Or drv("PaidFrom") = "DTS JV" Or drv("PaidFrom") = "DTS CV" Or drv("PaidFrom").ToString.Contains("Acknowledgement") Or cbxUR.Checked Then
                            If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom").ToString.Contains("Acknowledgement")) Then
                                SQL &= String.Format(" ReferenceN = '{0}', ", drv("Payee_ID"))
                            ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "DTS CV" And GridView2.GetRowCellValue(x, "AR_DocumentNumber").ToString <> "" Then
                                SQL &= String.Format(" ReferenceN = '{0}', ", GridView2.GetRowCellValue(x, "AR_DocumentNumber"))
                            Else
                                SQL &= String.Format(" ReferenceN = '{0}', ", drv("Payee_ID"))
                            End If
                        ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Deferred Income" Then
                            SQL &= String.Format(" ReferenceN = '{0}', ", drv("ORNum"))
                        ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Restructuring" Then
                            SQL &= String.Format(" ReferenceN = '{0}', ", drv("AmountDue"))
                        ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Journal Voucher" And If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("ORNum")) <> "" Then
                            SQL &= String.Format(" ORNum = '{0}', ", drv("ReferenceN"))
                            SQL &= String.Format(" ReferenceN = '{0}', ", drv("ORNum"))
                        ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Accounts Receivable" Then
                            SQL &= String.Format(" ReferenceN = '{0}', ", drv("Payee_ID"))
                        Else
                            SQL &= String.Format(" ReferenceN = '{0}', ", ValidateComboBox(cbxPayee))
                        End If
                        If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                            SQL &= " EntryType = 'DEBIT',"
                            SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                        Else
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                        End If
                        If If(cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")) = "Official Receipt" Then
                            SQL &= String.Format(" ORNum = '{0}', ", drv("ORNum"))
                        End If
                        If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Accounts Receivable" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 And If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", 0, drv("Payee_ID").ToString.Contains("CA")) Then
                            SQL &= " PaidFor = 'Billing', "
                        ElseIf If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Restructuring" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 And GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Receivable") Then
                            SQL &= " PaidFor = 'Principal', "
                        ElseIf GridView2.GetRowCellValue(x, "PaidFor") = "" And GridView2.GetRowCellValue(x, "Account Code") <> "" Then
                            SQL &= " PaidFor = 'Journal Voucher', "
                        Else
                            SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "PaidFor"))
                        End If
                        SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                        SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                        SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                        SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                        SQL &= " `Status` = 'PENDING',"
                        SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                        SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                        If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", False, drv("PaidFrom") = "Journal Voucher") Then 'IF ANG OR GI JV THEN ANG JV GI JV
                            'CHECK IF NAKA CREDIT SIDE ANG ENTRY KAY PARA I REVERSER
                            Dim DT_Availed As DataTable = DataSource(String.Format("SELECT EntryType FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND PaidFor = 'RPPD-A' AND CVNumber = '{0}';", drv("ReferenceN")))
                            If DT_Availed.Rows.Count > 0 Then
                                If DT_Availed(0)("EntryType") = "CREDIT" Then
                                    SQL &= String.Format(" JVNumber = '{0}', ", txtDocumentNumber.Text)
                                End If
                            End If
                        End If
                        If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", drv("PaidFrom")) = "Restructuring" And CDbl(GridView2.GetRowCellValue(x, "Credit")) > 0 And GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Receivable") Then
                            SQL &= String.Format(" Remarks = '{0}', ", txtDocumentNumber.Text & " " & GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote & " " & If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", If(drv("PaidFrom") = "Official Receipt" Or drv("PaidFrom").ToString.Contains("Acknowledgement"), "[Reversal]", "")))
                        Else
                            SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote & " " & If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", "", If(drv("PaidFrom") = "Official Receipt" Or drv("PaidFrom").ToString.Contains("Acknowledgement"), "[Reversal]", "")))
                        End If
                        SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                        SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    Next
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                    Else
                        If drv("PaidFrom") = "Official Receipt" Then 'ACCOUNTING ENTRY FOR AVAILED RPPD
                            Dim DT_Availed As DataTable = DataSource(String.Format("SELECT * FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND PaidFor = 'RPPD-A' AND CVNumber = '{0}';", drv("ORNum")))
                            If DT_Availed.Rows.Count > 0 Then
                                For x As Integer = 0 To DT_Availed.Rows.Count - 1
                                    SQL &= "INSERT INTO accounting_entry SET"
                                    SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" ReferenceN = '{0}', ", DT_Availed(x)("ReferenceN"))
                                    If DT_Availed(x)("EntryType") = "CREDIT" Then
                                        SQL &= " EntryType = 'DEBIT',"
                                    Else
                                        SQL &= " EntryType = 'CREDIT',"
                                    End If
                                    SQL &= String.Format(" Payable = '{0}', ", CDbl(DT_Availed(x)("Payable")))
                                    SQL &= String.Format(" Amount = '{0}', ", CDbl(DT_Availed(x)("Amount")))
                                    SQL &= String.Format(" ORNum = '{0}', ", drv("ORNum"))
                                    SQL &= " PaidFor = 'RPPD-A', "
                                    SQL &= " AccountCode = '', "
                                    SQL &= " `Status` = 'ACTIVE',"
                                    SQL &= " `PostStatus` = 'POSTED',"
                                    SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                                    SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= " Remarks = '[Reversal]', "
                                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                                Next
                            End If
                            Dim DT_Discount As DataTable = DataSource(String.Format("SELECT * FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND CVNumber = '{0}';", drv("ORNum") & " [Discount]"))
                            If DT_Discount.Rows.Count > 0 Then
                                For x As Integer = 0 To DT_Discount.Rows.Count - 1
                                    SQL &= "INSERT INTO accounting_entry SET"
                                    SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                                    SQL &= String.Format(" ReferenceN = '{0}', ", DT_Discount(x)("ReferenceN"))
                                    If DT_Discount(x)("EntryType") = "CREDIT" Then
                                        SQL &= " EntryType = 'DEBIT',"
                                    Else
                                        SQL &= " EntryType = 'CREDIT',"
                                    End If
                                    SQL &= String.Format(" Payable = '{0}', ", CDbl(DT_Discount(x)("Payable")))
                                    SQL &= String.Format(" Amount = '{0}', ", CDbl(DT_Discount(x)("Amount")))
                                    SQL &= String.Format(" ORNum = '{0}', ", drv("ORNum"))
                                    SQL &= String.Format(" PaidFor = '{0}', ", DT_Discount(x)("PaidFor"))
                                    SQL &= " AccountCode = '', "
                                    SQL &= " `Status` = 'ACTIVE',"
                                    SQL &= " `PostStatus` = 'POSTED',"
                                    SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                                    SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text & " [Discount]")
                                    SQL &= " Remarks = '[Reversal]', "
                                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                                Next
                            End If
                        End If
                        If drv("PaidFrom") = "Journal Voucher" Then 'IF ANG OR GI JV THEN ANG JV GI JV
                            Dim DT_Availed As DataTable = DataSource(String.Format("SELECT * FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND PaidFor = 'RPPD-A' AND CVNumber = '{0}';", drv("ReferenceN")))
                            If DT_Availed.Rows.Count > 0 Then
                                For x As Integer = 0 To DT_Availed.Rows.Count - 1
                                    SQL &= "INSERT INTO accounting_entry SET"
                                    SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" ReferenceN = '{0}', ", DT_Availed(x)("ReferenceN"))
                                    If DT_Availed(x)("EntryType") = "CREDIT" Then
                                        SQL &= " EntryType = 'DEBIT',"
                                        SQL &= " Remarks = '[Reversal]', "
                                        SQL &= String.Format(" JVNumber = '{0}', ", txtDocumentNumber.Text)
                                    Else
                                        SQL &= " EntryType = 'CREDIT',"
                                        SQL &= " Remarks = '', "
                                    End If
                                    SQL &= String.Format(" Payable = '{0}', ", CDbl(DT_Availed(x)("Payable")))
                                    SQL &= String.Format(" Amount = '{0}', ", CDbl(DT_Availed(x)("Amount")))
                                    SQL &= String.Format(" ORNum = '{0}', ", drv("ReferenceN"))
                                    SQL &= " PaidFor = 'RPPD-A', "
                                    SQL &= " AccountCode = '', "
                                    SQL &= " `Status` = 'ACTIVE',"
                                    SQL &= " `PostStatus` = 'POSTED',"
                                    SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                                    SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                                Next
                            End If
                        End If
                    End If
                    DataObject(SQL)
                    Cursor = Cursors.Default

                    Logs("Journal Voucher", "Update", Reason, Changes(), "", "", "")
                    Clear(True)
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
        Catch ex As Exception
            TriggerBugReport("Journal Voucher - Changes", ex.Message.ToString)
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
        If btnDelete.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

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
            Dim SQL As String
            '*** FINDING THE RIGHT REFERENCE *********************************************************************************************
            Dim ReferenceN As String = ""
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                ReferenceN = txtDocumentNumber.Text
            Else
                If From_ROPOA Or From_Impairment Or From_Ledger Then
                    ReferenceN = txtReferenceNumber.Text
                ElseIf From_ITL Or From_Case Then
                    ReferenceN = txtORNumber.Tag
                ElseIf drv("PaidFrom") = "Loans" Or drv("PaidFrom") = "Official Receipt" Or drv("PaidFrom") = "DTS" Or drv("PaidFrom") = "DTS JV" Or drv("PaidFrom") = "DTS CV" Or drv("PaidFrom").ToString.Contains("Acknowledgement") Or cbxUR.Checked Then
                    ReferenceN = drv("Payee_ID")
                ElseIf drv("PaidFrom") = "Deferred Income" Then
                    ReferenceN = drv("ORNum")
                ElseIf drv("PaidFrom") = "Restructuring" Then
                    ReferenceN = drv("AmountDue")
                ElseIf drv("PaidFrom") = "Journal Voucher" And drv("ORNum") <> "" Then
                    ReferenceN = drv("ORNum")
                Else
                    ReferenceN = ValidateComboBox(cbxPayee)
                End If
            End If
            '*** FINDING THE RIGHT REFERENCE *********************************************************************************************

            SQL = String.Format("UPDATE journal_voucher SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID)
            If drv("PaidFrom").ToString.Contains("Unrealized") Or drv("PaidFrom").ToString.Contains("Deferred") Then
                SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE CVNumber = '{0}' AND ReferenceN = '{1}' AND IF(PaidFor = 'RPPD-A',TRUE,TRUE);", txtDocumentNumber.Text, drv("Payee_ID"))
            ElseIf drv("PaidFrom") = "Journal Voucher" Then
                SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'DISAPPROVED' WHERE CVNumber = '{0}' AND IF(PaidFor = 'RPPD-A',TRUE,TRUE);", txtDocumentNumber.Text, ValidateComboBox(cbxPayee))
            Else
                SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE REPLACE(CVNumber,' [Discount]','') = '{0}' AND IF({2} = 1,TRUE,ReferenceN = '{1}') AND IF(PaidFor = 'RPPD-A',TRUE,TRUE);", txtDocumentNumber.Text, ReferenceN, If(drv("PaidFrom").ToString.Contains("DTS CV"), 1, 0))
            End If
            SQL &= String.Format(" UPDATE accounts_receivable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_from SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_to SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE loans_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            If drv("PaidFrom").ToString.Contains("Acknowledgement") Or drv("PaidFrom").ToString.Contains("Unrealized") Then
                SQL &= String.Format(" UPDATE acknowledgement_receipt SET JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                SQL &= String.Format("UPDATE accounting_entry SET JVNumber = '' WHERE ORNum = '{1}' AND JVNumber = '{0}';", txtDocumentNumber.Text, drv("ReferenceN"))

                If drv("PaidFrom") = "Acknowledgement RO" Then
                    Dim CountRemainingACR As Integer = 0
                    CountRemainingACR = DataObject(String.Format("SELECT COUNT(ID) FROM acknowledgement_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'RO' AND `status` = 'ACTIVE' AND JVNumber = '' AND DocumentNumber != '{1}';", drv("Payee_ID"), drv("ReferenceN")))
                    If CountRemainingACR = 0 Then
                        SQL &= String.Format("UPDATE sold_ropoa SET `status` = 'ACTIVE' WHERE AssetNumber = '{0}' AND `status` = 'CANCELLED' AND JVNumber = '{1}';", drv("Payee_ID"), txtDocumentNumber.Text)
                        If drv("Payee_ID").Contains("ANV") Then
                            SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = 'SOLD' WHERE AssetNumber = '{0}';", drv("Payee_ID"))
                        Else
                            SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = 'SOLD' WHERE AssetNumber = '{0}';", drv("Payee_ID"))
                        End If
                    End If
                End If
            ElseIf drv("PaidFrom") = "Official Receipt" Then
                SQL &= String.Format(" UPDATE official_receipt SET JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                SQL &= String.Format(" UPDATE accounting_entry SET JVNumber = '' WHERE ORNum = '{1}' AND REPLACE(JVNumber,' [Discount]','') = '{0}';", txtDocumentNumber.Text, drv("ORNum"))
            ElseIf drv("PaidFrom") = "DTS" Then
                SQL &= String.Format(" UPDATE official_receipt SET DTS_JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "DTS JV" Then
                SQL &= String.Format(" UPDATE journal_voucher SET DTS_JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "DTS CV" Then
                SQL &= String.Format(" UPDATE check_voucher SET DTS_JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Liquidation" Then
                SQL &= String.Format(" UPDATE liquidation_main SET JVNumber = '' WHERE ID = '{0}';", Liq_ID)
            ElseIf drv("PaidFrom") = "Accounts Payable" Then
                SQL &= String.Format(" UPDATE accounts_payable SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Accounts Receivable" Then
                SQL &= String.Format(" UPDATE accounts_receivable SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Check Voucher" Then
                SQL &= String.Format(" UPDATE check_voucher SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                '*UPDATE credit_applicat i set ang PaymentRequest para ma release
                SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}';", drv("Payee_ID"))
            ElseIf drv("PaidFrom") = "Journal Voucher" Then
                SQL &= String.Format(" UPDATE journal_voucher SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                SQL &= String.Format(" UPDATE accounting_entry SET JVNumber = '' WHERE JVNum = '{1}' AND JVNumber = '{0}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Due To" Then
                SQL &= String.Format(" UPDATE due_to SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Due From" Then
                SQL &= String.Format(" UPDATE due_from SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom").ToString.Contains("Loans") Then
                If CVforJV Then
                    SQL &= String.Format("UPDATE credit_application SET `PaymentRequest` = 'PENDING' WHERE CreditNumber = '{0}' AND `PaymentRequest` = 'REQUESTED';", ReferenceN)
                ElseIf txtReferenceNumber.Enabled = False Then
                    SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", txtReferenceNumber.Text)
                End If
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "PaidFor").ToString.Contains("CVE") Or GridView2.GetRowCellValue(x, "PaidFor").ToString.Contains("CRE") Then
                        If GridView2.GetRowCellValue(x, "PaidFor").ToString.Contains("CVE") Then
                            SQL &= String.Format("UPDATE collateral_ve SET Surrendered = 0 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "PaidFor"))
                        Else
                            SQL &= String.Format("UPDATE collateral_re SET Surrendered = 0 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "PaidFor"))
                        End If
                    End If
                Next
            ElseIf drv("PaidFrom") = "Restructuring" Then
                SQL &= String.Format("UPDATE Credit_Application SET JVNumber = '' WHERE CreditNumber = '{0}';", cbxPayee.SelectedValue)
            ElseIf drv("PaidFrom") = "Case" Then
                SQL &= String.Format("UPDATE case_main SET `status`  = 'DISAPPROVED' WHERE JournalVoucher = '{0}';", txtDocumentNumber.Text)
                SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", txtORNumber.Tag)
            ElseIf From_Ledger Then
                Dim DT_Details As DataTable = DataSource(String.Format("SELECT PaidFor FROM jv_details WHERE DocumentNumber = '{0}' AND SUBSTRING(PaidFor,1,3) IN ('CVE','CRE') AND `status` = 'ACTIVE';", txtDocumentNumber.Text))
                For x As Integer = 0 To DT_Details.Rows.Count - 1
                    MsgBox(DT_Details(x)("PaidFor").ToString.Substring(0, 2))
                    If DT_Details(x)("PaidFor").ToString.Substring(0, 2) = "CVE" Then
                        SQL &= String.Format("UPDATE collateral_ve SET Surrendered = 0 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE' AND Surrendered = 0;", DT_Details(x)("PaidFor"))
                    Else
                        SQL &= String.Format("UPDATE collateral_re SET Surrendered = 0 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE' AND Surrendered = 0;", DT_Details(x)("PaidFor"))
                    End If
                Next
            ElseIf From_Case Then
                SQL &= String.Format("UPDATE case_main SET `status`  = 'DISAPPROVED' WHERE JournalVoucher = '{0}';", txtDocumentNumber.Text)
                SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", ReferenceN)
            ElseIf From_Check Then
                SQL &= String.Format("UPDATE dc_details SET `check_status` = 'ON HAND', Remarks = CONCAT(Remarks, ' [', 'CANCELLED',']') WHERE ID IN ({0}) AND `status` = 'ACTIVE';", DueToID_M)
                If cbxPayee.Text.Contains("[DT-") Then
                    Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Paid FROM due_to WHERE IF(DC_ID > 0,DC_ID = (SELECT ID FROM due_check WHERE DocumentNumber = (SELECT DocumentNumber FROM dc_details WHERE ID = {0}) AND `status` = 'ACTIVE'),FIND_IN_SET(DocumentNumber,(SELECT DocumentNumber FROM dc_details WHERE ID = {0})));", DueToID_M))
                    For x As Integer = 0 To vDT.Rows.Count - 1
                        SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                    Next
                End If
            ElseIf txtReferenceNumber.Enabled = False Then
                Dim Impairment As Boolean
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Impairment") Then
                        Impairment = True
                        Exit For
                    End If
                Next
                If Impairment = False Then
                    SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = IF(sell_status = 'SELL','RECLASSIFIED','SELL') WHERE AssetNumber = '{0}' AND `status` = 'ACTIVE';", txtReferenceNumber.Text)
                    SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = IF(sell_status = 'SELL','RECLASSIFIED','SELL') WHERE AssetNumber = '{0}' AND `status` = 'ACTIVE';", txtReferenceNumber.Text)
                Else
                    SQL &= String.Format("UPDATE tbl_impairment SET Impairment_Status = 'PENDING', PosteD_Date = '', Reference = '' WHERE AssetNumber = '{1}' AND Reference = '{0}';", txtDocumentNumber.Text, txtReferenceNumber.Text)
                End If
            End If

            DataObject(SQL)
            Logs("Journal Voucher", "Cancel", Reason, String.Format("Cancel Journal Voucher of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "")
            LoadPayee()
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
            If From_Ledger Then
                With btnDelete
                    .DialogResult = DialogResult.OK
                    .DialogResult = DialogResult.OK
                    .PerformClick()
                End With
            End If
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
            GenerateJV(True, "", txtCheck.Text, txtApproved.Text)
            Logs("Journal Voucher", "Print", "[SENSITIVE] Print Journal Voucher " & txtDocumentNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("JOURNAL VOUCHER LIST", GridControl1)
            Logs("Journal Voucher", "Print", "[SENSITIVE] Print Journal Voucher List", "", "", "", "")
        End If
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

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Voucher_Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Or Status = "REVERSED" Then
                e.Appearance.ForeColor = Color.Red
            End If
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
            Liq_ID = .GetFocusedRowCellValue("Liq_ID")
            dtpDocument.Value = .GetFocusedRowCellValue("Document Date")
            txtDocumentNumber.Text = .GetFocusedRowCellValue("Document Number")
        End With
        cbxPayee.Enabled = False
        FirstLoad = True
        GridColumn22.Width = 342
        GridColumn11.Visible = False
        If GridView1.GetFocusedRowCellValue("JVFrom") = "" Then
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Accounts Receivable" Then
            cbxAR.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Accounts Payable" Then
            cbxAP.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Liquidation" Then
            cbxLOE.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Journal Voucher" Then
            cbxJV.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Loans" Then
            cbxLA.Checked = True
            btnView.Visible = True
            btnLedger.Visible = True

            If GridView1.GetFocusedRowCellValue("Refinance") = 0 Then
                GridColumn22.Width = 342 - 80
                GridColumn11.Visible = True
                GridColumn11.VisibleIndex = 5
            End If
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom").Contains("Acknowledgement") Then
            cbxACR.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Check Voucher" Then
            cbxCV.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Due From" Then
            cbxDF.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Due To" Then
            cbxDT.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Official Receipt" Then
            cbxOR.Checked = True
            btnView.Visible = True
            btnLedger.Visible = True

            GridColumn22.Width = 342 - 80
            GridColumn11.Visible = True
            GridColumn11.VisibleIndex = 5
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Unrealized" Then
            cbxUR.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Restructuring" Then
            cbxRS.Checked = True
            cbxDTS_RS.Visible = True
            If GridView1.GetFocusedRowCellValue("DTS") = 1 Then
                cbxDTS_RS.Checked = True
            Else
                cbxDTS_RS.Checked = False
            End If

            GridColumn22.Width = 342 - 80
            GridColumn11.Visible = True
            GridColumn11.VisibleIndex = 5
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "ITL" Then
            cbxITL.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "ROPA" Then
            cbxROPA.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "DTS" Or GridView1.GetFocusedRowCellValue("JVFrom") = "DTS JV" Or GridView1.GetFocusedRowCellValue("JVFrom") = "DTS CV" Then
            cbxDTS.Checked = True
            If GridView1.GetFocusedRowCellValue("JVFrom") = "DTS CV" Then
                btnView.Visible = True
            End If

            GridColumn22.Width = 342 - 80
            GridColumn11.Visible = True
            GridColumn11.VisibleIndex = 5
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Deferred Income" Then
            cbxDI.Checked = True

            GridColumn22.Width = 342 - 80
            GridColumn11.Visible = True
            GridColumn11.VisibleIndex = 5
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "ROPOA" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Impairment" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Ledger" Then
            txtReferenceNumber.Enabled = False
            If GridView1.GetFocusedRowCellValue("JVFrom") = "Ledger" Then
                From_Ledger = True
                cbxLA.Checked = True
            End If
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "From Check" Then
            DueToID_M = GridView1.GetFocusedRowCellValue("ReferenceID")
            From_Check = True
        End If
        LoadPayee()
        cbxLA.Enabled = False
        cbxACR.Enabled = False
        cbxCV.Enabled = False
        cbxAP.Enabled = False
        cbxDT.Enabled = False
        cbxDF.Enabled = False
        cbxAR.Enabled = False
        cbxOR.Enabled = False
        cbxLOE.Enabled = False
        cbxJV.Enabled = False
        cbxUR.Enabled = False
        cbxDI.Enabled = False
        cbxRS.Enabled = False
        cbxITL.Enabled = False
        cbxROPA.Enabled = False
        cbxDTS.Enabled = False
        With GridView1
            CVforJV = .GetFocusedRowCellValue("CVforJV")
            Refinance = .GetFocusedRowCellValue("Refinance")
            cbxPayee.Text = .GetFocusedRowCellValue("Payee")
            FirstLoad = False
            cbxPayee.Tag = .GetFocusedRowCellValue("Payee")
            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            cbxBank.Tag = .GetFocusedRowCellValue("Bank")
            dtpPostingDate.Value = .GetFocusedRowCellValue("Posting Date")
            dtpPostingDate.Tag = .GetFocusedRowCellValue("Posting Date")
            txtReferenceNumber.Text = .GetFocusedRowCellValue("Reference Number")
            txtReferenceNumber.Tag = .GetFocusedRowCellValue("Reference Number")
            txtORNumber.Text = .GetFocusedRowCellValue("ORNum")
            txtORNumber.Tag = .GetFocusedRowCellValue("ORNum")
            If .GetFocusedRowCellValue("JVFrom") = "Case" Then
                txtORNumber.Tag = .GetFocusedRowCellValue("ReferenceID")
                From_Case = True
            End If
            If .GetFocusedRowCellValue("ORDate") = "" Then
                dtpORDate.CustomFormat = ""
            Else
                dtpORDate.CustomFormat = "MMMM dd, yyyy"
                dtpORDate.Value = .GetFocusedRowCellValue("ORDate")
            End If
            dtpORDate.Tag = .GetFocusedRowCellValue("ORDate")
            rExplanation.Text = .GetFocusedRowCellValue("Explanation")
            rExplanation.Tag = .GetFocusedRowCellValue("Explanation")

            If CompanyMode = 0 Then
                DT_Account = DataSource(String.Format("SELECT MotherCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = MotherCode(jv_details.AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, AR_DocumentNumber FROM jv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", .GetFocusedRowCellValue("Document Number")))
            Else
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = jv_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, AR_DocumentNumber FROM jv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", .GetFocusedRowCellValue("Document Number")))
            End If
            GridControl2.DataSource = DT_Account
            Dim TotalDebit As Double
            Dim TotalCredit As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebit += CDbl(DT_Account(x)("Debit"))
                TotalCredit += CDbl(DT_Account(x)("Credit"))
            Next
            dDebitT.Value = TotalDebit
            dCreditT.Value = TotalCredit
            If GridView2.RowCount > 7 Then
                If GridColumn11.Visible = False Then
                    GridColumn22.Width = 342 - 17
                Else
                    GridColumn22.Width = (342 - 80) - 17
                End If
            Else
                If GridColumn11.Visible = False Then
                    GridColumn22.Width = 342
                Else
                    GridColumn22.Width = 342 - 80
                End If
            End If

            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")
            txtCheck.Text = .GetFocusedRowCellValue("Checked By")
            txtCheck.Tag = .GetFocusedRowCellValue("CheckedID")
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
                If User_Type = "ADMIN" Then
                    btnDisapprove.Visible = True
                End If
            End If
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "APPROVED" Then
            btnCheck.Visible = False
            btnApprove.Visible = False
            btnReceive.Visible = False
            btnModify.Enabled = False
        End If
        btnSave.Enabled = False
        btnPrint.Enabled = True
        Cursor = Cursors.Default
    End Sub

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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or If(From_GL Or From_ACR Or From_LOE Or From_Check Or From_Impairment Or From_Ledger Or From_ROPOA Or From_ITL Or From_Case, e.KeyCode = Keys.Escape, 0) Then
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
        ElseIf e.Control And e.KeyCode = Keys.O Then
            If GridControl2.Enabled Then
                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            Else
                btnAdd_Account.Enabled = True
                btnExport.Enabled = True
                btnDownload.Enabled = True
                btnRemove_Account.Enabled = True
                GridControl2.Enabled = True
            End If
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView1_DoubleClick(sender, e)
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

    Private Sub CbxPayee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayee.SelectedIndexChanged
        If FirstLoad Or CopyMode Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
            Clear(False)
        Else
            btnUpdate.Visible = False
            GridColumn22.Width = 342
            GridColumn11.Visible = False

            btnAdd_Account.Enabled = True
            btnExport.Enabled = True
            btnDownload.Enabled = True
            btnRemove_Account.Enabled = True
            GridControl2.Enabled = True

            cbxDTS_RS.Visible = False
            cbxDTS_RS.Checked = False
            btnView.Visible = False
            btnLedger.Visible = False
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            BankID = drv("BankID")
            RepositoryItemLookUpEdit1.DataSource = DataSource("SELECT 'CIB' AS 'Paid For' UNION SELECT 'Billing' UNION SELECT 'Penalty' UNION SELECT 'RPPD' UNION SELECT 'UDI' UNION SELECT 'Principal' UNION SELECT 'Other Income' UNION SELECT ''")
            If drv("PaidFrom") = "ITL" Or drv("PaidFrom") = "ROPA" Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")

                If drv("PaidFrom") = "ITL" Then
                    RepositoryItemLookUpEdit1.DataSource = DataSource("SELECT 'ITL' AS 'Paid For' UNION SELECT ''")
                ElseIf drv("PaidFrom") = "ROPA" Then
                    RepositoryItemLookUpEdit1.DataSource = DataSource("SELECT 'ROPA' AS 'Paid For' UNION SELECT ''")
                End If
                Dim SQL As String
                SQL = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber'"
                DT_Account = DataSource(SQL)
                GridControl2.DataSource = DT_Account
            ElseIf drv("PaidFrom").ToString.Contains("Acknowledgement") Then
                rExplanation.Text = drv("Explanation").ToString
                cbxBank.SelectedValue = drv("BankID")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = acr_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM acr_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' ORDER BY Credit ASC;", drv("ReferenceN")))
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom").ToString.Contains("Unrealize") Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                Dim SoldAmount As Double = DataObject(String.Format("SELECT Amount FROM sold_ropoa WHERE AssetNumber = '{0}' ORDER BY ID DESC LIMIT 1;", drv("Payee_ID")))
                Dim BalanceTransferred As Double = DataObject(If(drv("Payee_ID").ToString.Contains("ANV"), (String.Format("SELECT BalanceTransferred FROM ropoa_vehicle WHERE AssetNumber = '{0}'", drv("Payee_ID"))), (String.Format("SELECT BalanceTransferred FROM ropoa_realestate WHERE AssetNumber = '{0}'", drv("Payee_ID")))))
                'DEBIT
                AccountCodeDetails(If(drv("Payee_ID").ToString.Contains("ANV"), If(SoldAmount > BalanceTransferred, "620003", "620001"), If(SoldAmount > BalanceTransferred, "620004", "620002")))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", drv("Amount"), 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                'CREDIT
                AccountCodeDetails("229102")
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, drv("Amount"), "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom").ToString.Contains("Deferred Income") Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                'DEBIT
                AccountCodeDetails("229104")
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", drv("Amount"), 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                'CREDIT
                AccountCodeDetails(If(drv("Cash Advance") = 1, "420003", If(drv("Cash Advance") = 2, "420004", "420007")))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, drv("Amount"), "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom").ToString.Contains("Official") Then
                btnView.Visible = True
                btnLedger.Visible = True
                If drv("TotalExpenses") = 1 Then
                    MsgBox("This is a DTS Official Receipt, are you sure you want to Journal Voucher this? This will reverse the entry", MsgBoxStyle.Information, "Info")
                End If
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                RepositoryItemLookUpEdit1.DataSource = DataSource("SELECT 'CIB' AS 'Paid For' UNION SELECT 'Billing' UNION SELECT 'Penalty' UNION SELECT 'RPPD' UNION SELECT 'UDI' UNION SELECT 'Principal' UNION SELECT 'Other Income' UNION SELECT ''")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', IFNULL((SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = or_details.AccountCode),'') AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, AR_DocumentNumber FROM or_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' ORDER BY Credit ASC;", drv("ReferenceN")))
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                GridColumn22.Width = 342 - 80
                GridColumn11.Visible = True
                GridColumn11.VisibleIndex = 5

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom").ToString.Contains("DTS") Then
                rExplanation.Text = drv("Explanation")
                RepositoryItemLookUpEdit1.DataSource = DataSource("SELECT 'CIB' AS 'Paid For' UNION SELECT 'Billing' UNION SELECT 'Penalty' UNION SELECT 'RPPD' UNION SELECT 'UDI' UNION SELECT 'Principal' UNION SELECT 'Other Income' UNION SELECT ''")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                If drv("PaidFrom") = "DTS" Then
                    DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', IFNULL((SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = or_details.AccountCode),'') AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM or_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' AND PaidFor != 'CIB' UNION ALL SELECT '' AS 'Account Code', DepartmentCode AS 'Department Code', '' AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM or_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' AND PaidFor != 'CIB';", drv("ReferenceN")))
                    Dim OfficialReceipt As New FrmOfficialReceipt
                    With OfficialReceipt
                        .Visible = False
                        .CreditNumber = drv("Payee_ID")
                        .DTS_Amount = DT_Account(0)("Debit")
                        .DTS_Date = dtpPostingDate.Value
                        .From_JournalDTS = True
                        .Show()
                        DT_Account = .GridControl2.DataSource
                        .Dispose()
                    End With
                ElseIf drv("PaidFrom") = "DTS JV" Then
                    DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', IFNULL((SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = jv_details.AccountCode),'') AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, AR_DocumentNumber FROM jv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' AND PaidFor != 'CIB' AND AccountCode = '217201' UNION ALL SELECT '' AS 'Account Code', DepartmentCode AS 'Department Code', '' AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM jv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' AND PaidFor != 'CIB' AND AccountCode = '217201';", drv("ReferenceN")))
                Else
                    btnView.Visible = True
                    'DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', IFNULL((SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = cv_details.AccountCode),'') AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'C',Amount,0.00) AS 'Debit', IF(`Type` = 'D',Amount,0.00) AS 'Credit', PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, CreditNumber AS 'AR_DocumentNumber' FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' AND AccountCode = '217201' UNION ALL SELECT '' AS 'Account Code', DepartmentCode AS 'Department Code', '' AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'D',Amount,0.00) AS 'Debit', IF(`Type` = 'C',Amount,0.00) AS 'Credit', PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, CreditNumber AS 'AR_DocumentNumber' FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' AND AccountCode = '217201';", drv("ReferenceN")))
                    DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', IFNULL((SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = cv_details.AccountCode),'') AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'C',Amount,0.00) AS 'Debit', IF(`Type` = 'D',Amount,0.00) AS 'Credit', PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, CreditNumber AS 'AR_DocumentNumber' FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' AND AccountCode = '217201'", drv("ReferenceN")))

                    Dim SQL As String = "SELECT * FROM ("
                    SQL &= String.Format("    SELECT Advance_Payment AS 'Amount', 'Advance Payment' AS 'Type', '229104' AS 'Account', '' AS 'AccountNumber', GMA - Rebate AS 'Monthly', ROUND(Interest / Terms) AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND IncludeAdvancePaymentInBill = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT AmountApplied AS 'Amount', 'Principal' AS 'Type', If(Mortgage_ID = 1, '112001', If(Mortgage_ID = 2, '112002', '112003')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT Service_Charge AS 'Amount', 'Service Charge' AS 'Type', IF(Mortgage_ID = 1,'420101',IF(Mortgage_ID = 2,'420102','420103')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT SUM(Amount) AS 'Amount', 'Processing Fee' AS 'Type', IF(MortgageID('{0}') = 1,'420201',IF(MortgageID('{0}') = 2,'420202','420203')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_processing_fee WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND (SELECT Product FROM credit_application WHERE CreditNumber = credit_processing_fee.CreditNumber AND BillDeductions = 0) NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT `Amount`, 'Deduct Balance' AS 'Type', IF(MortgageID('{0}') = 1,'112001',IF(MortgageID('{0}') = 2,'112002','112003')) AS 'Account', AccountNumber, 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_deductbalance WHERE `status` = 'ACTIVE' AND deduct_status = 'PENDING' AND CreditNumber_F = '{0}' AND (SELECT Product FROM credit_application WHERE CreditNumber = credit_deductbalance.CreditNumber_F) NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT Miscellaneous_Income + CI_Fee + Appraisal_Fee AS 'Amount', 'Mischellaneous Income' AS 'Type', IF(Mortgage_ID = 1,'420301',IF(Mortgage_ID = 2,'420302','420303')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    'SQL &= String.Format("    SELECT Appraisal_Fee AS 'Amount', 'Other Income' AS 'Type', '' AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT Insurance AS 'Amount', 'Insurance' AS 'Type', IF(Mortgage_ID = 1,'218301',IF(Mortgage_ID = 2,'218302','218303')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' ) A WHERE A.Amount > 0", drv("Payee_ID"))
                    Dim Credits As DataTable = DataSource(SQL)
                    Dim z As Integer = 0
                    Dim MortgageID As Integer = GetMortgageIDofApplication(drv("Payee_ID"))
                    Dim BusinessCenterCode As String = GetBusinessCenterCodeofApplication(drv("Payee_ID"))
                    For x As Integer = 0 To Credits.Rows.Count - 1
                        If Credits(x)("Type") = "Deduct Balance" Then
                            If CDbl(Credits(x)("Amount")) > 0 Then
                                Dim Deduct As DataTable = DataSource(String.Format("SELECT LR, UDI_Discount, AvailedRPPD, AR, Penalty, Amount, CreditNumber, AccountNumber FROM credit_deductbalance WHERE CreditNumber_F = '{0}' AND `status` = 'ACTIVE' AND deduct_status = 'PENDING';", drv("Payee_ID")))
                                If Deduct.Rows.Count > 0 Then
                                    'iTag.Enabled = True
                                    'iViewLedger.Visible = True
                                    Dim Balance As DataTable = DataSource(String.Format("SELECT IFNULL(RPPD - IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),0) AS 'Total RPPD', IFNULL(AmountApplied - IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),0) AS 'Total Principal', IFNULL(Interest - IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),0) AS 'Total Interest', IFNULL(C.BankID,0) AS 'BankID' FROM credit_application C LEFT JOIN (SELECT PaidFor, Amount, ReferenceN, EntryType, Remarks FROM accounting_entry WHERE ReferenceN = '{0}' AND `status` IN ('ACTIVE', 'PENDING') AND PaidFor != 'Accounts Receivable' ) A ON C.CreditNumber = A.ReferenceN WHERE C.CreditNumber = '{0}';", Deduct(z)("CreditNumber")))
                                    If Balance.Rows.Count > 0 And (cbxBank.SelectedValue = Balance(0)("BankID") Or cbxDTS.Checked = False) Then 'Add this condition kay wala nay deduct balance basta dli same og Selected Bank sa Bank nga naka Deduct Balance || Add Condition dapat naka dli DTS ingon ms Cha 10-07-2020
                                        'If cbxBank.SelectedValue <> Balance(0)("BankID") Then
                                        '    DTS_FromAccount = True
                                        'End If

                                        If CDbl(Credits(x)("Amount")) >= (CDbl(Balance(0)("Total Principal")) + Math.Ceiling(CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount"))) + Math.Ceiling(CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")))) Then
                                            'Principal
                                            If CDbl(Balance(0)("Total Principal")) > 0 Then
                                                AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "112001", If(MortgageID = 2, "112002", "112003"))))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Balance(0)("Total Principal"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Principal"), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                            End If
                                            'Interest
                                            If CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")) > 0 Then
                                                AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "420001", If(MortgageID = 2, "420002", "420006"))))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "UDI"), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                            End If
                                            'RPPD
                                            If CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")) > 0 Then
                                                AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "RPPD"), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                            End If
                                            'Penalty
                                            If CDbl(Deduct(z)("Penalty")) > 0 Then
                                                AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Deduct(z)("Penalty"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Penalty"), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                            End If
                                            'AR
                                            If CDbl(Deduct(z)("AR")) > 0 Then
                                                AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Deduct(z)("AR"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Billing"), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                            End If
                                            'Other Income
                                            If CDbl(Deduct(z)("Amount")) - ((CDbl(Deduct(z)("LR")) + CDbl(Deduct(z)("Penalty"))) - (CDbl(Deduct(z)("UDI_Discount")) + CDbl(Deduct(z)("AvailedRPPD")) + CDbl(Deduct(z)("AR")))) > 0 Then
                                                AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Floor(CDbl(Deduct(z)("Amount")) - ((CDbl(Deduct(z)("LR")) + CDbl(Deduct(z)("Penalty"))) - (CDbl(Deduct(z)("UDI_Discount")) + CDbl(Deduct(z)("AvailedRPPD")) + CDbl(Deduct(z)("AR"))))), "", Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                            End If
                                        Else
                                            Dim PartialPayment As Double = CDbl(Credits(x)("Amount"))
                                            If PartialPayment >= CDbl(Deduct(z)("AR")) Then
                                                'AR
                                                If CDbl(Deduct(z)("AR")) > 0 Then
                                                    AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Deduct(z)("AR"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Billing"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                End If
                                                PartialPayment -= CDbl(Deduct(z)("AR"))
                                            Else
                                                'AR
                                                If CDbl(Deduct(z)("AR")) > 0 Then
                                                    AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, PartialPayment, If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Billing"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                End If
                                                PartialPayment = 0
                                            End If
                                            If PartialPayment > 0 Then
                                                If PartialPayment >= CDbl(Deduct(z)("Penalty")) Then
                                                    'Penalty
                                                    If CDbl(Deduct(z)("Penalty")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Deduct(z)("Penalty"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Penalty"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment -= Math.Ceiling(CDbl(Deduct(z)("Penalty")))
                                                Else
                                                    'Penalty
                                                    If CDbl(Deduct(z)("Penalty")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, PartialPayment, If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Penalty"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment = 0
                                                End If
                                            End If
                                            If PartialPayment > 0 Then
                                                If PartialPayment >= CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")) Then
                                                    'RPPD
                                                    If CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "RPPD"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment -= (CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")))
                                                Else
                                                    'RPPD
                                                    If CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "420003", If(MortgageID = 2, "420004", "420007"))))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, PartialPayment, If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "RPPD"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment = 0
                                                End If
                                            End If
                                            If PartialPayment > 0 Then
                                                If PartialPayment >= CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")) Then
                                                    'Interest
                                                    If CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "420001", If(MortgageID = 2, "420002", "420006"))))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "UDI"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment -= (CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")))
                                                Else
                                                    'Interest
                                                    If CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "420001", If(MortgageID = 2, "420002", "420006"))))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, PartialPayment, If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "UDI"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment = 0
                                                End If
                                            End If
                                            If PartialPayment > 0 Then
                                                If PartialPayment >= CDbl(Balance(0)("Total Principal")) Then
                                                    'Principal
                                                    If CDbl(Balance(0)("Total Principal")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "112001", If(MortgageID = 2, "112002", "112003"))))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(CDbl(Balance(0)("Total Principal"))), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Principal"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment -= CDbl(Balance(0)("Total Principal"))
                                                Else
                                                    'Principal
                                                    If CDbl(Balance(0)("Total Principal")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(MortgageID = 1, "112001", If(MortgageID = 2, "112002", "112003"))))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, PartialPayment, If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Principal"), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment = 0
                                                End If
                                            End If
                                            If PartialPayment > 0 Then
                                                AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, PartialPayment, If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Billing"), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                            z += 1
                        ElseIf Credits(x)("Type") = "Advance Payment" Then
                            If CDbl(Credits(x)("Amount")) > 1 Then
                                FrmCheckVoucher.LoadAmortization(drv("Payee_ID"), GridControl4)
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
                                    AccountCodeDetails(If(MortgageID = 1, "420001", If(MortgageID = 2, "420002", "420006")))
                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Ceiling(UDIAdvance), "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), "")
                                End If
                                If PrincipalAvance > 0 Then
                                    AccountCodeDetails(If(MortgageID = 1, "112001", If(MortgageID = 2, "112002", "112003")))
                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, Math.Floor(PrincipalAvance), "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), "")
                                End If
                                TotalAdvance = UDIAdvance + PrincipalAvance
                            End If
                        ElseIf Credits(x)("Type") = "Other Income" Then
                            DT_Account.Rows.Add("", If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), "", DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), DT_Account(0)("Department"), 0, CDbl(Credits(x)("Amount")), "Other Income", False, "", BusinessCenterCode, 0, "", "")
                        Else
                            AccountCodeDetails(Credits(x)("Account"))
                            If Credits(x)("Type") = "Principal" Then
                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), CDbl(Credits(x)("Amount")), 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), "")
                            Else
                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department Code")), DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", BusinessCenterCode)), If(DT_Account.Rows.Count = 0, "", DT_Account(0)("Department")), 0, CDbl(Credits(x)("Amount")), "", "", DT_Temp_Account(0)("RequiredRemarks"), BusinessCenterCode, 0, DT_Temp_Account(0)("MotherCode"), "")
                            End If
                        End If
                    Next
                End If
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                GridColumn22.Width = 342 - 80
                GridColumn11.Visible = True
                GridColumn11.VisibleIndex = 5

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom") = "Journal Voucher" Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = jv_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, AR_DocumentNumber FROM jv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' ORDER BY Credit ASC;", drv("ReferenceN")))
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))

                    If DT_Account(x)("PaidFor") <> "" And GridColumn11.Visible = False Then
                        GridColumn22.Width = 342 - 80
                        GridColumn11.Visible = True
                        GridColumn11.VisibleIndex = 5
                    End If
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom") = "Liquidation" Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                DT_Account = DataSource(String.Format("SELECT IF(`Type` = 'C','',AccountCode) AS 'Account Code', DepartmentCode AS 'Department Code', IF(`Type` = 'C','',(SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = cv_details.AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'C',{1},0.00) AS 'Debit', IF(`Type` = 'D',{1},0.00) AS 'Credit', '' AS 'PaidFor', Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' ORDER BY Credit ASC;", drv("ORNum"), CDbl(drv("Cash Advance"))))
                If CDbl(drv("Amount")) > 0 Then
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        If CDbl(DT_Account(x)("Debit")) > 0 Then
                            DT_Account(x)("Debit") = CDbl(DT_Account(x)("Debit")) + CDbl(drv("Amount"))
                            Exit For
                        End If
                    Next
                    AccountCodeDetails("218003")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(drv("Amount")), "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom") = "Accounts Payable" Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = ap_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', '' AS 'PaidFor', Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM ap_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' ORDER BY Credit ASC;", drv("ReferenceN")))
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom") = "Accounts Receivable" Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = ar_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', '' AS 'PaidFor', Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM ar_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' ORDER BY Credit ASC;", drv("ReferenceN")))
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom") = "Due To" Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = dt_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', '' AS 'PaidFor', Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM dt_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' ORDER BY Credit ASC;", drv("ReferenceN")))
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom") = "Due From" Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = df_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Credit AS 'Debit', Debit AS 'Credit', '' AS 'PaidFor', Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM df_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' ORDER BY Credit ASC;", drv("ReferenceN")))
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom") = "Check Voucher" Then
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                If drv("TotalExpenses") = 1 Then
                    MsgBox("This is a DTS Check Voucher, are you sure you want to Journal Voucher this? This will reverse the entry", MsgBoxStyle.Information, "Info")
                End If
                DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = cv_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'C',Amount,0.00) AS 'Debit', IF(`Type` = 'D',Amount,0.00) AS 'Credit', '' AS 'PaidFor', Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'AR_DocumentNumber' FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}' ORDER BY `Type` ASC, Amount DESC;", drv("ReferenceN")))
                GridControl2.DataSource = DT_Account
                Dim TotalDebitX As Double
                Dim TotalCreditX As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebitX += CDbl(DT_Account(x)("Debit"))
                    TotalCreditX += CDbl(DT_Account(x)("Credit"))
                Next
                dDebitT.Value = TotalDebitX
                dCreditT.Value = TotalCreditX

                btnAdd_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                btnRemove_Account.Enabled = False
                GridControl2.Enabled = False
            ElseIf drv("PaidFrom") = "Loans" Then
                btnView.Visible = True
                btnLedger.Visible = True
                DT_Account.Rows.Clear()
                If drv("AmountDue") = 1 Then
                    Refinance = True
                    Dim DT_Appraise As DataTable
                    If drv("Cash Advance") = 1 Then
                        DT_Appraise = DataSource(String.Format("SELECT asset_number, AppraiseSellingPrice FROM appraise_ve WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND FIND_IN_SET(CollateralNumber, (SELECT GROUP_CONCAT(CollateralNumber) FROM collateral_ve WHERE CINumber = (SELECT CINumber FROM credit_investigation WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE')));", drv("Payee_ID")))
                    Else
                        DT_Appraise = DataSource(String.Format("SELECT asset_number, AppraiseSellingPrice FROM appraise_re WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND FIND_IN_SET(CollateralNumber, (SELECT GROUP_CONCAT(CollateralNumber) FROM collateral_re WHERE CINumber = (SELECT CINumber FROM credit_investigation WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE')));", drv("Payee_ID")))
                    End If

                    DT_Account.Rows.Clear()
                    'DEBIT SUGGESTION
                    AccountCodeDetails("112001")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", drv("Amount"), 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")

                    Dim TotalPaid As Double
                    Dim CIB_Amount As Double = drv("Amount")
                    For x As Integer = 0 To DT_Appraise.Rows.Count - 1
                        Dim DT_ROPA_Details As DataTable
                        If drv("Cash Advance") = 1 Then
                            DT_ROPA_Details = DataSource(String.Format("SELECT ID, BalanceTransferred, Running_Balance(AssetNumber) 'Running Balance' FROM ropoa_vehicle WHERE AssetNumber = '{0}';", DT_Appraise(x)("asset_number")))
                        Else
                            DT_ROPA_Details = DataSource(String.Format("SELECT ID, BalanceTransferred, Running_Balance(AssetNumber) 'Running Balance' FROM ropoa_realestate WHERE AssetNumber = '{0}';", DT_Appraise(x)("asset_number")))
                        End If
                        Dim SoldID As Integer = DataObject(String.Format("SELECT ID FROM sold_ropoa WHERE AssetNumber = '{0}' AND `status` = 'ACTIVE' ORDER BY ID LIMIT 1", DT_Appraise(x)("asset_number")))
                        TotalPaid += DT_Appraise(x)("AppraiseSellingPrice")
                        If DT_ROPA_Details.Rows.Count > 0 Then
                            For y As Integer = 0 To DT_ROPA_Details.Rows.Count - 1
                                FillAccounts(SoldID, DT_Appraise(x)("asset_number"), DT_ROPA_Details(y)("BalanceTransferred"), If(CIB_Amount > DT_Appraise(x)("AppraiseSellingPrice"), DT_Appraise(x)("AppraiseSellingPrice"), CIB_Amount), If(CIB_Amount > DT_Appraise(x)("AppraiseSellingPrice"), DT_Appraise(x)("AppraiseSellingPrice"), CIB_Amount), DT_ROPA_Details(y)("Running Balance"), drv("Cash Advance"))
                            Next
                        End If
                        If CIB_Amount > DT_Appraise(x)("AppraiseSellingPrice") Then
                            CIB_Amount -= DT_Appraise(x)("AppraiseSellingPrice")
                        End If
                    Next

                    btnAdd_Account.Enabled = False
                    btnExport.Enabled = False
                    btnDownload.Enabled = False
                    btnRemove_Account.Enabled = False
                    GridControl2.Enabled = False
                ElseIf drv("AmountDue") = 2 Then
                    'CHECK VOUCHER FOR JOURNAL VOUCHER ***********************************************************************************
                    CVforJV = True
                    btnUpdate.Visible = True
                    'DEBIT
                    AccountCodeDetails(If(cbxDTS.Checked, "217201", If(drv("Cash Advance") = 1, "112001", If(drv("Cash Advance") = 2, "112002", "112003"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", CDbl(drv("Amount")), 0, "", "", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")

                    'CREDIT
                    Dim SQL As String = "SELECT * FROM ("
                    SQL &= String.Format("    SELECT Advance_Payment AS 'Amount', 'Advance Payment' AS 'Type', '229104' AS 'Account', '' AS 'AccountNumber', GMA - Rebate AS 'Monthly', ROUND(Interest / Terms) AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND IncludeAdvancePaymentInBill = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT Net_Proceeds AS 'Amount', 'Principal' AS 'Type', IFNULL(IF('{1}' = '','111001',(SELECT `Code` FROM account_chart WHERE Title LIKE '%Due To%' AND BranchTagged = '{1}' AND `Status` = 'ACTIVE')),'111001') AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' UNION ALL", drv("Payee_ID"), UseBankBranchID)
                    SQL &= String.Format("    SELECT Service_Charge AS 'Amount', 'Service Charge' AS 'Type', IF(Mortgage_ID = 1,'420101',IF(Mortgage_ID = 2,'420102','420103')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT SUM(Amount) AS 'Amount', 'Processing Fee' AS 'Type', IF(MortgageID('{0}') = 1,'420201',IF(MortgageID('{0}') = 2,'420202','420203')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_processing_fee WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND (SELECT Product FROM credit_application WHERE CreditNumber = credit_processing_fee.CreditNumber AND BillDeductions = 0) NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT `Amount`, 'Deduct Balance' AS 'Type', IF(MortgageID('{0}') = 1,'112001',IF(MortgageID('{0}') = 2,'112002','112003')) AS 'Account', AccountNumber, 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_deductbalance WHERE `status` = 'ACTIVE' AND deduct_status = 'PENDING' AND CreditNumber_F = '{0}' AND (SELECT Product FROM credit_application WHERE CreditNumber = credit_deductbalance.CreditNumber_F) NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT Miscellaneous_Income + Appraisal_Fee + CI_Fee AS 'Amount', 'Mischellaneous Income' AS 'Type', IF(Mortgage_ID = 1,'420301',IF(Mortgage_ID = 2,'420302','420303')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", drv("Payee_ID"))
                    SQL &= String.Format("    SELECT Insurance AS 'Amount', 'Insurance' AS 'Type', IF(Mortgage_ID = 1,'218301',IF(Mortgage_ID = 2,'218302','218303')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' ) A WHERE A.Amount > 0", drv("Payee_ID"))
                    Dim Credits As DataTable = DataSource(SQL)
                    For x As Integer = 0 To Credits.Rows.Count - 1
                        If Credits(x)("Type") = "Deduct Balance" Then
                            If CDbl(Credits(x)("Amount")) > 0 Then
                                Dim Deduct As DataTable = DataSource(String.Format("SELECT LR, UDI_Discount, AvailedRPPD, AR, Penalty, CreditNumber, AccountNumber FROM credit_deductbalance WHERE CreditNumber_F = '{0}' AND `status` = 'ACTIVE' AND deduct_status = 'PENDING';", drv("Payee_ID")))
                                If Deduct.Rows.Count > 0 Then
                                    Dim Balance As DataTable = DataSource(String.Format("SELECT RPPD - IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%',0 - Amount,Amount) END),0) AS 'Total RPPD', AmountApplied - IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Principal', Interest - IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Interest' FROM accounting_entry LEFT JOIN (SELECT AmountApplied, Interest, RPPD, CreditNumber FROM credit_application WHERE `status` = 'ACTIVE') C ON C.CreditNumber = accounting_entry.ReferenceN WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", Deduct(0)("CreditNumber")))
                                    If Balance.Rows.Count > 0 Then
                                        If CDbl(Credits(x)("Amount")) >= (CDbl(Balance(0)("Total Principal")) + Math.Ceiling(CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(0)("UDI_Discount"))) + Math.Ceiling(CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(0)("AvailedRPPD")))) Then
                                            'Principal
                                            If CDbl(Balance(0)("Total Principal")) > 0 Then
                                                AccountCodeDetails(If(drv("Cash Advance") = 1, "112001", If(drv("Cash Advance") = 2, "112002", "112003")))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total Principal"))), "Principal", Deduct(0)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                            End If
                                            'Interest
                                            If CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(0)("UDI_Discount")) > 0 Then
                                                AccountCodeDetails(If(drv("Cash Advance") = 1, "420001", If(drv("Cash Advance") = 2, "420002", "420006")))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(0)("UDI_Discount"))), "UDI", Deduct(0)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                            End If
                                            'RPPD
                                            If CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(0)("AvailedRPPD")) > 0 Then
                                                AccountCodeDetails(If(drv("Cash Advance") = 1, "420003", If(drv("Cash Advance") = 2, "420004", "420007")))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(0)("AvailedRPPD"))), "RPPD", Deduct(0)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                            End If
                                            'Penalty
                                            If CDbl(Deduct(0)("Penalty")) > 0 Then
                                                AccountCodeDetails(If(drv("Cash Advance") = 1, "420003", If(drv("Cash Advance") = 2, "420004", "420007")))
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Deduct(0)("Penalty"))), "Penalty", Deduct(0)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                            End If
                                            'AR
                                            If CDbl(Deduct(0)("AR")) > 0 Then
                                                AccountCodeDetails("620061")
                                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Deduct(0)("AR"))), "Billing", Deduct(0)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                            End If
                                        Else
                                            Dim PartialPayment As Double = CDbl(Credits(x)("Amount"))
                                            If PartialPayment >= CDbl(Deduct(0)("AR")) Then
                                                'AR
                                                If CDbl(Deduct(0)("AR")) > 0 Then
                                                    AccountCodeDetails("620061")
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Deduct(0)("AR"))), "Billing", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                End If
                                                PartialPayment -= CDbl(Deduct(0)("AR"))
                                            Else
                                                'AR
                                                If CDbl(Deduct(0)("AR")) > 0 Then
                                                    AccountCodeDetails("620061")
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, PartialPayment, "Billing", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                End If
                                                PartialPayment = 0
                                            End If
                                            If PartialPayment > 0 Then
                                                If PartialPayment >= CDbl(Deduct(0)("Penalty")) Then
                                                    'Penalty
                                                    If CDbl(Deduct(0)("Penalty")) > 0 Then
                                                        AccountCodeDetails(If(drv("Cash Advance") = 1, "420003", If(drv("Cash Advance") = 2, "420004", "420007")))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Deduct(0)("Penalty"))), "Penalty", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                    End If
                                                    PartialPayment -= CDbl(Deduct(0)("Penalty"))
                                                Else
                                                    'Penalty
                                                    If CDbl(Deduct(0)("Penalty")) > 0 Then
                                                        AccountCodeDetails(If(drv("Cash Advance") = 1, "420003", If(drv("Cash Advance") = 2, "420004", "420007")))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, PartialPayment, "Penalty", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                    End If
                                                    PartialPayment = 0
                                                End If
                                            End If
                                            If PartialPayment > 0 Then
                                                If PartialPayment >= CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(0)("AvailedRPPD")) Then
                                                    'RPPD
                                                    If CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(0)("AvailedRPPD")) > 0 Then
                                                        AccountCodeDetails(If(drv("Cash Advance") = 1, "420003", If(drv("Cash Advance") = 2, "420004", "420007")))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(0)("AvailedRPPD"))), "RPPD", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                    End If
                                                    PartialPayment -= (CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(0)("AvailedRPPD")))
                                                Else
                                                    'RPPD
                                                    If CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(0)("AvailedRPPD")) > 0 Then
                                                        AccountCodeDetails(If(drv("Cash Advance") = 1, "420003", If(drv("Cash Advance") = 2, "420004", "420007")))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, PartialPayment, "RPPD", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                    End If
                                                    PartialPayment = 0
                                                End If
                                            End If
                                            If PartialPayment > 0 Then
                                                If PartialPayment >= CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(0)("UDI_Discount")) Then
                                                    'Interest
                                                    If CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(0)("UDI_Discount")) > 0 Then
                                                        AccountCodeDetails(If(drv("Cash Advance") = 1, "420001", If(drv("Cash Advance") = 2, "420002", "420006")))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(0)("UDI_Discount"))), "UDI", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                    End If
                                                    PartialPayment -= (CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(0)("UDI_Discount")))
                                                Else
                                                    'Interest
                                                    If CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(0)("UDI_Discount")) > 0 Then
                                                        AccountCodeDetails(If(drv("Cash Advance") = 1, "420001", If(drv("Cash Advance") = 2, "420002", "420006")))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, PartialPayment, "UDI", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                    End If
                                                    PartialPayment = 0
                                                End If
                                            End If
                                            If PartialPayment > 0 Then
                                                If PartialPayment >= CDbl(Balance(0)("Total Principal")) Then
                                                    'Principal
                                                    If CDbl(Balance(0)("Total Principal")) > 0 Then
                                                        AccountCodeDetails(If(drv("Cash Advance") = 1, "112001", If(drv("Cash Advance") = 2, "112002", "112003")))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total Principal"))), "Principal", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                    End If
                                                    PartialPayment -= CDbl(Balance(0)("Total Principal"))
                                                Else
                                                    'Principal
                                                    If CDbl(Balance(0)("Total Principal")) > 0 Then
                                                        AccountCodeDetails(If(drv("Cash Advance") = 1, "112001", If(drv("Cash Advance") = 2, "112002", "112003")))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, PartialPayment, "Principal", Deduct(0)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                                    End If
                                                    PartialPayment = 0
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                            End If
                        ElseIf Credits(x)("Type") = "Advance Payment" Then
                            If CDbl(Credits(x)("Amount")) > 0 Then
                                Dim ForDistribute As Double = CDbl(Credits(x)("Amount"))
                                Dim Covered As Double = Math.Ceiling(ForDistribute / CDbl(Credits(x)("Monthly")))
                                Dim UDIAdvance As Double
                                Dim PrincipalAvance As Double
                                For y As Integer = 0 To Covered - 1
                                    If ForDistribute > 0 Then
                                        If ForDistribute >= CDbl(Credits(x)("Monthly Interest")) Then
                                            UDIAdvance += CDbl(Credits(x)("Monthly Interest"))
                                            ForDistribute -= CDbl(Credits(x)("Monthly Interest"))
                                        Else
                                            UDIAdvance += ForDistribute
                                            ForDistribute = 0
                                        End If

                                        If ForDistribute >= (CDbl(Credits(x)("Monthly")) - CDbl(Credits(x)("Monthly Interest"))) Then
                                            ForDistribute -= (CDbl(Credits(x)("Monthly")) - CDbl(Credits(x)("Monthly Interest")))
                                        Else
                                            ForDistribute = 0
                                        End If
                                    End If
                                Next
                                PrincipalAvance = CDbl(Credits(x)("Amount")) - UDIAdvance
                                If UDIAdvance > 0 Then
                                    AccountCodeDetails(If(drv("Cash Advance") = 1, "420001", If(drv("Cash Advance") = 2, "420002", "420006")))
                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Ceiling(UDIAdvance), "UDI", "", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                End If
                                If PrincipalAvance > 0 Then
                                    AccountCodeDetails(If(drv("Cash Advance") = 1, "112001", If(drv("Cash Advance") = 2, "112002", "112003")))
                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, Math.Floor(PrincipalAvance), "Principal", "", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                End If
                            End If
                        ElseIf Credits(x)("Type") = "Other Income" Then
                            DT_Account.Rows.Add("", "", "", DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, CDbl(Credits(x)("Amount")), "Other Income", "", "", drv("BusinessCode"), 0, "", "")
                            'ElseIf 0 Then 'ITL
                            '    AccountCodeDetails(If(drv("Cash Advance") = 1, "112301", If(drv("Cash Advance") = 2, "112302", "112303")))
                            '    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, CDbl(Credits(x)("Amount")), "", "", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                        Else
                            AccountCodeDetails(Credits(x)("Account"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, CDbl(Credits(x)("Amount")), "", "", DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                    Next
                    'CHECK VOUCHER FOR JOURNAL VOUCHER ***********************************************************************************

                    btnAdd_Account.Enabled = False
                    btnExport.Enabled = False
                    btnDownload.Enabled = False
                    btnRemove_Account.Enabled = False
                    GridControl2.Enabled = False
                Else
                    DT_Account.Rows.Add("", "", "", DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, 0, "", "", "", drv("BusinessCode"), 0, "")
                    DT_Account.Rows.Add("", "", "", DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, 0, "", "", "", drv("BusinessCode"), 0, "")

                    GridColumn22.Width = 342 - 80
                    GridColumn11.Visible = True
                    GridColumn11.VisibleIndex = 5
                End If
            ElseIf drv("PaidFrom") = "Restructuring" Then
                cbxDTS_RS.Visible = True
                cbxDTS_RS.Checked = False
                rExplanation.Text = drv("Explanation")
                cbxBank.SelectedValue = drv("BankID")
                AccountNumberRestructuring = drv("ORDate")
                FillRestructuring()

                btnAdd_Account.Enabled = False
                btnRemove_Account.Enabled = False
                btnExport.Enabled = False
                btnDownload.Enabled = False
                GridControl2.Enabled = False
            Else
                Dim SQL As String
                SQL = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber' UNION ALL"
                SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'PaidFor', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'AR_DocumentNumber'"
                DT_Account = DataSource(SQL)
                GridControl2.DataSource = DT_Account
            End If
            Temp_DT = DT_Account.Copy

            Dim TotalDebit As Double
            Dim TotalCredit As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebit += CDbl(DT_Account(x)("Debit"))
                TotalCredit += CDbl(DT_Account(x)("Credit"))
            Next
            If GridView2.RowCount > 7 Then
                If GridColumn11.Visible = False Then
                    GridColumn22.Width = 342 - 17
                Else
                    GridColumn22.Width = (342 - 80) - 17
                End If
            Else
                If GridColumn11.Visible = False Then
                    GridColumn22.Width = 342
                Else
                    GridColumn22.Width = 342 - 80
                End If
            End If
            dDebitT.Value = TotalDebit
            dCreditT.Value = TotalCredit
            If GridView2.RowCount > 0 Then
                If btnAdd_Account.Enabled Then
                    btnRemove_Account.Enabled = True
                End If
            Else
                btnRemove_Account.Enabled = False
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub FillAccounts(AssetID As Integer, AssetNumber As String, BalanceTransferred As Double, PaidAmount As Double, Payable As Double, RunningBalance As Double, Mortgage As Integer)
        If FirstLoad Or cbxPayee.SelectedIndex = -1 Or PaidAmount = 0 Then
            Exit Sub
        End If

        Dim TotalPayments As Double = DataObject(String.Format("SELECT ROPOA_Payment('{0}','{1}');", AssetNumber, AssetID))
        Dim SoldAmount As Double = DataObject(String.Format("SELECT Amount FROM sold_ropoa WHERE ID = '{0}';", AssetID))
        '****************************************************** F U L L   P A Y M E N T ****************************************
        If TotalPayments = 0 Then
            TotalPayments += PaidAmount
            If SoldAmount * 0.8 <= TotalPayments Then
                'CREDIT SUGGESTION
                If PaidAmount < Payable And PaidAmount < RunningBalance Then
                    'PAYMENT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", If(Mortgage = 2, "126001", "126003"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    If PaidAmount - RunningBalance > 0 Then
                        'GAIN ON SALE CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620003", "620004")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, BalanceTransferred + PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Payable - PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", Payable - PaidAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ElseIf RunningBalance >= Payable And RunningBalance > PaidAmount Then
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", Payable - PaidAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED DEBIT
                        If BalanceTransferred - SoldAmount > 0 Then
                            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", BalanceTransferred - SoldAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                    End If
                    'ROPA CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", "126001")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, BalanceTransferred - PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")

                ElseIf RunningBalance = 0 Then
                    'GAIN ON SALE
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620003", "620004")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                ElseIf RunningBalance >= Payable And PaidAmount >= Payable Then
                    'PAYMENT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", "126001")))
                    If PaidAmount = RunningBalance Then
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    Else
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, RunningBalance, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                    If RunningBalance > Payable And PaidAmount >= Payable And PaidAmount - RunningBalance > 0 Then
                        'GAIN ON SALE
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620003", "620004")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount - RunningBalance, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ElseIf RunningBalance > Payable And PaidAmount < RunningBalance And PaidAmount - Payable >= 0 Then
                        'LOSS ON SALE
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620001", "620002")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", RunningBalance - PaidAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                ElseIf RunningBalance <= Payable And PaidAmount >= RunningBalance Then
                    'PAYMENT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", "126001")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, RunningBalance, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    If PaidAmount > RunningBalance Then
                        'GAIN ON SALE
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620003", "620004")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount - RunningBalance, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED CREDIT
                        If Payable - PaidAmount > 0 Then
                            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Payable - PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                        'ACCOUNTS RECEIVABLE DEBIT
                        If Payable - PaidAmount > 0 Then
                            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", Payable - PaidAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                    End If
                End If
                Exit Sub
            End If
        End If
        '****************************************************** F U L L   P A Y M E N T ****************************************
        Dim TotalAP As Double = DataObject(String.Format("SELECT IFNULL(SUM(Amount),0) FROM accounting_entry WHERE `status` IN ('PENDING','ACTIVE') AND EntryType = 'CREDIT' AND AccountCode = '218002' AND ReferenceN = '{0}';", AssetNumber))
        'CREDIT SUGGESTION
        If PaidAmount < Payable And PaidAmount < RunningBalance Then
            'GAIN ON SALE
            If SoldAmount * 0.8 <= TotalPayments Then
                'ACCOUNTS RECEIVABLE
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                If TotalPayments = 0 Then
                    TotalPayments += PaidAmount
                End If
                If SoldAmount * 0.8 <= TotalPayments Then
                    ''ROPA CREDIT
                    If TotalAP > 0 Then
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", TotalAP, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                    If PaidAmount - RunningBalance > 0 Then
                        'GAIN ON SALE CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620003", "620004")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, (TotalAP - BalanceTransferred) + PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Payable - PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", Payable - PaidAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ElseIf RunningBalance > Payable Then
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", Payable - PaidAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'UNREALIZED DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", BalanceTransferred - SoldAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                    'ROPA CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", "126001")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, BalanceTransferred, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                Else
                    'ACCOUNTS PAYABLE CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
            End If
        ElseIf RunningBalance = 0 Then
            'GAIN ON SALE
            If SoldAmount * 0.8 <= TotalPayments Then
                'ACCOUNTS RECEIVABLE
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                'ACCOUNTS PAYABLE DEBIT
                If TotalAP > 0 Then
                    '------ YOUR HERE ------
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", TotalAP, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'ROPA CREDIT
                    'AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", "126001")))
                    'DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, BalanceTransferred, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
                If PaidAmount - RunningBalance > 0 Then
                    'GAIN ON SALE CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620003", "620004")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, (TotalAP - RunningBalance) + PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    If RunningBalance > 0 Then
                        'UNREALIZED CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Payable - PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", Payable - PaidAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                ElseIf RunningBalance > Payable Then
                    If (RunningBalance - PaidAmount) - TotalAP > 0 Then
                        'LOSS ON SALE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620001", "620002")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", (RunningBalance - PaidAmount) - TotalAP, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                End If
            End If
        ElseIf RunningBalance >= Payable And PaidAmount >= Payable Then
            'PAYMENT
            If SoldAmount * 0.8 <= TotalPayments Then
                'ACCOUNTS RECEIVABLE
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                'ROPA CREDIT
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", "126001")))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, RunningBalance, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                If TotalAP > 0 Then
                    'ACCOUNTS PAYABLE DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", TotalAP, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    ''ROPA CREDIT
                    'AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", "126001")))
                    'DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, TotalAP, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
                If PaidAmount - RunningBalance > 0 Then
                    'GAIN ON SALE CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620003", "620004")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount - RunningBalance, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    If PaidAmount >= RunningBalance Then
                    Else
                        'UNREALIZED CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Payable - PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'ACCOUNTS RECEIVABLE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", Payable - PaidAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                ElseIf RunningBalance > Payable Then
                    If (RunningBalance - PaidAmount) - TotalAP > 0 Then
                        'LOSS ON SALE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620001", "620002")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", (RunningBalance - PaidAmount) - TotalAP, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                End If
            End If
        ElseIf RunningBalance <= Payable And PaidAmount >= RunningBalance Then
            'PAYMENT
            If SoldAmount * 0.8 <= TotalPayments Then
                'ACCOUNTS RECEIVABLE
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
            Else
                'ROPA CREDIT
                AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", "126001")))
                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, RunningBalance, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                If TotalAP > 0 Then
                    'ACCOUNTS PAYABLE DEBIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "218002"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", TotalAP, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'ROPA CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "126002", "126001")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, TotalAP, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
                If PaidAmount - RunningBalance > 0 Then
                    'GAIN ON SALE CREDIT
                    If PaidAmount - RunningBalance > 0 Then
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620003", "620004")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, PaidAmount - RunningBalance, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                    'UNREALIZED CREDIT
                    If Payable - PaidAmount > 0 Then
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "229102"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Payable - PaidAmount, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                    'ACCOUNTS RECEIVABLE DEBIT
                    If Payable - PaidAmount > 0 Then
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", "112103"))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", Payable - PaidAmount, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                ElseIf RunningBalance > Payable Then
                    If (RunningBalance - PaidAmount) - TotalAP > 0 Then
                        'LOSS ON SALE DEBIT
                        AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(Mortgage = 1, "620001", "620002")))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", (RunningBalance - PaidAmount) - TotalAP, 0, AssetNumber, AssetNumber, DT_Temp_Account(0)("RequiredRemarks"), "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FillRestructuring()
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
        'DEBIT
        'Principal
        If cbxDTS_RS.Checked And cbxDTS_RS.Visible Then
            AccountCodeDetails("217201")
        Else
            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Cash Advance") = 1, "112001", If(drv("Cash Advance") = 2, "112002", "112003"))))
        End If
        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", CDbl(drv("Amount")), 0, drv("Payee_ID"), "New - " & drv("Payee_ID"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
        'CREDIT   
        If cbxDTS_RS.Checked And cbxDTS_RS.Visible Then
            AccountCodeDetails(If(cbxBank.SelectedValue <> BankID And BankID <> 0, "217201", If(drv("Cash Advance") = 1, "112001", If(drv("Cash Advance") = 2, "112002", "112003"))))
        End If
        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, CDbl(drv("TotalExpenses")), "Principal", "Old - " & drv("AmountDue"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
        AccountCodeDetails(If((cbxBank.SelectedValue <> BankID And BankID <> 0), "217201", "229104"))
        Dim PaymentDetails As DataTable
        Dim DeductedUDI As Double
        Dim DeductedRPPD As Double
        Dim DeductionDetails As DataTable = DataSource(String.Format("SELECT Interest - RestructureDeductionUDI AS 'Deducted UDI', RPPD - RestructureDeductionRPPD AS 'Deducted RPPD' FROM credit_application WHERE CreditNumber = '{0}';", drv("AmountDue")))
        If DeductionDetails.Rows.Count > 0 Then
            PaymentDetails = DataSource(String.Format("SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%' OR EntryType = 'DEBIT',0 - Amount,Amount) END),0) AS 'Total RPPD', IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Total Interest' FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND PaidFor != 'Accounts Receivable' AND ReferenceN = '{0}';", drv("AmountDue")))
            DeductedUDI = NegativeNotAllowed(CDbl(DeductionDetails(0)("Deducted UDI") - PaymentDetails(0)("Total Interest")))
            DeductedRPPD = NegativeNotAllowed(CDbl(DeductionDetails(0)("Deducted RPPD") - PaymentDetails(0)("Total RPPD")))
        End If
        'UDI
        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, DeductedUDI, "UDI", "Old - " & drv("AmountDue"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")
        'RPPD
        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("BusinessCode"))), "", 0, DeductedRPPD, "RPPD", "Old - " & drv("AmountDue"), DT_Temp_Account(0)("RequiredRemarks"), drv("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"), "")

        GridColumn22.Width = 342 - 80
        GridColumn11.Visible = True
        GridColumn11.VisibleIndex = 5
    End Sub

    Private Sub UpdateNotification(xCode As String, SendMail As Boolean)
        Code = xCode
        Dim Msg As String = ""
        Dim EmailTo As String = ""
        Dim Subject As String
        Dim FName As String
        If txtCheck.Text = "" Then
            'F O R   C H E C K I N G************************************************************************************************************************
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Updated Journal Voucher of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
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
                GenerateJV(False, FName, txtCheck.Text, txtApproved.Text)
                AttachmentFiles.Add(FName)
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
            End If
            'F O R   C H E C K I N G************************************************************************************************************************
        ElseIf txtApproved.Text = "" Then
            'F O R   A P P R O V A L ***********************************************************************************************************************
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Updated Journal Voucher of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
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
                GenerateJV(False, FName, txtCheck.Text, txtApproved.Text)
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
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Journal Voucher of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
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
            AttachmentFiles = New ArrayList() 'JUST ADDED UNDER OBSERVATION
            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
            GenerateJV(False, FName, txtCheck.Text, txtApproved.Text)
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
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Journal Voucher of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
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
            AttachmentFiles = New ArrayList() 'JUST ADDED UNDER OBSERVATION
            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
            GenerateJV(False, FName, txtCheck.Text, txtApproved.Text)
            AttachmentFiles.Add(FName)
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
        End If
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

                            DataObject(String.Format("UPDATE journal_voucher SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE accounts_receivable SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, .cbxProvider.SelectedValue, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Journal Voucher", "Check", String.Format("Checked Journal Voucher of {0} with the total amount of {1}. [Via OTAC]", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

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
            If MsgBoxYes("Are you sure you check this Journal Voucher?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    ApproveNotification(Code, False)
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                DataObject(String.Format("UPDATE journal_voucher SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_receivable SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE accounts_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Journal Voucher", "Check", String.Format("Checked Journal Voucher of {0} with the total amount of {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                Clear(True)
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
                .btnAttachments.Visible = True
                .btnResend.Visible = True
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
                            Dim SQL As String
                            SQL = String.Format("UPDATE accounting_entry SET ORDate = '{1}', `Status` = 'ACTIVE', PostStatus = 'POSTED' WHERE JVNum = '{0}' AND IF(PaidFor = 'RPPD-A',TRUE,`status` = 'PENDING') AND `status` != 'CANCELLED';", txtDocumentNumber.Text, Format(dtpPostingDate.Value, "yyyy-MM-dd"))

                            If drv("PaidFrom") = "Journal Voucher" Then
                                Dim JV_Details As DataTable
                                Dim JVNumber As String = ""
Here1:
                                JV_Details = DataSource(String.Format("SELECT ReferenceID, JVFrom, DocumentNumber, Payee_ID FROM journal_voucher WHERE JVNumber = '{0}';", If(JVNumber = "", txtDocumentNumber.Text, JVNumber)))
                                If JV_Details.Rows.Count > 0 Then
                                    If JV_Details(0)("JVFrom") = "Acknowledgement CAS" Then
                                        Dim ACR_Details As DataTable = DataSource(String.Format("SELECT DocumentNumber FROM acknowledgement_receipt WHERE Payee_ID = '{0}';", JV_Details(0)("ReferenceID")))
                                        If ACR_Details.Rows.Count > 0 Then
                                            SQL &= String.Format("UPDATE cash_advance SET `status` = IF(`status` = 'ACTIVE','CANCELLED','ACTIVE'), Purpose = CONCAT(Purpose, ' [Reversed ACR]'), ACRNumber = IF(`ACRNumber` = '','{1}','') WHERE AccountNumber = '{0}';", JV_Details(0)("ReferenceID"), ACR_Details(0)("DocumentNumber"))
                                        End If
                                    ElseIf JV_Details(0)("JVFrom") = "Acknowledgement RO" Then
                                        Dim CountRemainingACR As Integer = DataObject(String.Format("SELECT COUNT(ID) FROM acknowledgement_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'RO' AND `status` = 'ACTIVE' AND JVNumber = '' AND ID != '{1}';", drv("Payee_ID"), JV_Details(0)("ReferenceID")))
                                        Dim AssetNumber As String = DataObject(String.Format("SELECT Payee_ID FROM acknowledgement_receipt WHERE ID = '{0}';", JV_Details(0)("ReferenceID")))
                                        If CountRemainingACR = 0 Then
                                            SQL &= String.Format("UPDATE sold_ropoa SET `status` = IF(`status` = 'ACTIVE','CANCELLED','ACTIVE') WHERE AssetNumber = '{0}' AND JVNumber = '{1}';", AssetNumber, JV_Details(0)("DocumentNumber"))
                                            SQL &= String.Format("UPDATE accounting_entry SET ReferenceN = '{1}' WHERE JVNum = '{0}' AND `status` != 'CANCELLED';", txtDocumentNumber.Text, AssetNumber)
                                            If AssetNumber.Contains("ANV") Then
                                                SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = IF(`sell_status` = 'SOLD','SELL','SOLD') WHERE AssetNumber = '{0}';", AssetNumber)
                                            Else
                                                SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = IF(`sell_status` = 'SOLD','SELL','SOLD') WHERE AssetNumber = '{0}';", AssetNumber)
                                            End If
                                        End If
                                    ElseIf JV_Details(0)("JVFrom") = "Check Voucher" Then
                                        Dim DT_CV As DataTable = DataSource(String.Format("SELECT DocumentNumber, Payee_ID, Payee_Type FROM check_voucher WHERE ID = '{0}';", JV_Details(0)("Payee_ID")))
                                        If DT_CV.Rows.Count > 0 Then
                                            If DT_CV(0)("Payee_Type") = "C" Then
                                                SQL &= String.Format(String.Format("UPDATE credit_application SET `status` = IF(`status` = 'ACTIVE','CANCELLED','ACTIVE'), `PaymentRequest` = IF(`status` = 'ACTIVE','APPROVED REQUEST','JV Request') WHERE CreditNumber = '{0}';", DT_CV(0)("Payee_ID")))
                                            ElseIf DT_CV(0)("Payee_Type") = "RC" Then
                                                SQL &= String.Format("UPDATE replenishment_cash SET `ReplenishStatus` = 'PENDING', CVNumber = '' WHERE DocumentNumber = '{0}';", DT_CV(0)("Payee_ID"))
                                            ElseIf DT_CV(0)("Payee_Type") = "L" Then
                                                SQL &= String.Format("UPDATE liquidation_main SET `Refund` = IF(Refund = 0,1,0) WHERE AccountNumber = '{0}';", DT_CV(0)("Payee_ID"))
                                            ElseIf DT_CV(0)("Payee_Type") = "A" Then
                                                SQL &= String.Format("UPDATE cash_advance SET `CVNumber` = IF(CVNumber = '','{1}','') WHERE AccountNumber = '{0}';", DT_CV(0)("Payee_ID"), DT_CV(0)("DocumentNumber"))
                                            End If
                                        End If
                                    ElseIf JV_Details(0)("JVFrom") = "Official Receipt" Then
                                        Dim DT_Waive As DataTable = DataSource(String.Format("SELECT Amount, ORNum FROM accounting_entry WHERE CVNumber = '{0}' AND ReferenceN = '{1}' AND PaidFor = 'RPPD-W' AND Remarks = 'Waive for RPPD [Reversal]'", JV_Details(0)("DocumentNumber"), JV_Details(0)("ReferenceID")))
                                        If DT_Waive.Rows.Count > 0 Then
                                            SQL &= "INSERT INTO accounting_entry SET"
                                            SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                            SQL &= String.Format(" ORNum = '{0}', ", DT_Waive(0)("ORNum"))
                                            SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                            SQL &= String.Format(" ReferenceN = '{0}', ", JV_Details(0)("ReferenceID"))
                                            SQL &= " EntryType = 'CREDIT',"
                                            SQL &= " AccountCode = '', " 'Waived RPPD
                                            SQL &= " MotherCode = '', " 'Waived Penalty
                                            SQL &= String.Format(" Amount = '{0}', ", DT_Waive(0)("Amount"))
                                            SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-W")
                                            SQL &= String.Format(" Remarks = '{0}', ", "Waive for RPPD")
                                            SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                                            SQL &= String.Format(" BankID = '{0}', ", BankID)
                                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                                        End If
                                    ElseIf JV_Details(0)("JVFrom") = "Acknowledgement LA" Then
                                        Dim ACR_Details As DataTable = DataSource(String.Format("SELECT PlateNum FROM acknowledgement_receipt WHERE JVNumber = '{0}' AND `status` = 'ACTIVE';", JV_Details(0)("DocumentNumber")))
                                        If ACR_Details.Rows.Count > 0 Then
                                            If ACR_Details(0)("PlateNum") = "BILL DEDUCT" Then
                                                SQL &= String.Format("UPDATE credit_application SET `BillDeductionsStatus` = IF(`BillDeductionsStatus` = 'PAID','PENDING','PAID') WHERE CreditNumber = '{0}' AND BillDeductions = 1;", JV_Details(0)("ReferenceID"))
                                            End If
                                        End If
                                    ElseIf JV_Details(0)("JVFrom") = "Journal Voucher" Then
                                        JVNumber = JV_Details(0)("DocumentNumber")
                                        GoTo Here1
                                    End If
                                End If
                            ElseIf drv("PaidFrom") = "Acknowledgement CAS" Then
                                Dim ACR_Details As DataTable = DataSource(String.Format("SELECT DocumentNumber FROM acknowledgement_receipt WHERE ID = {0};", cbxPayee.SelectedValue))
                                If ACR_Details.Rows.Count > 0 Then
                                    SQL &= String.Format("UPDATE cash_advance SET `status` = IF(`status` = 'ACTIVE','CANCELLED','ACTIVE'), Purpose = CONCAT(Purpose, ' [Reversed ACR]'), ACRNumber = IF(`ACRNumber` = '','{0}','') WHERE ACRNumber = '{0}';", ACR_Details(0)("DocumentNumber"))
                                End If
                            ElseIf drv("PaidFrom") = "Check Voucher" Then
                                Dim CV_Details As DataTable = DataSource(String.Format("SELECT Payee_ID, Payee_Type FROM check_voucher WHERE ID = {0};", cbxPayee.SelectedValue))
                                If CV_Details.Rows.Count > 0 Then
                                    If CV_Details(0)("Payee_Type") = "RC" Then
                                        SQL &= String.Format("UPDATE replenishment_cash SET `ReplenishStatus` = 'PENDING', CVNumber = '' WHERE DocumentNumber = '{0}';", CV_Details(0)("Payee_ID"))
                                    ElseIf CV_Details(0)("Payee_Type") = "L" Then
                                        SQL &= String.Format("UPDATE liquidation_main SET `Refund` = 0 WHERE AccountNumber = '{0}';", CV_Details(0)("Payee_ID"))
                                    ElseIf CV_Details(0)("Payee_Type") = "A" Then
                                        SQL &= String.Format("UPDATE cash_advance SET `CVNumber` = '' WHERE AccountNumber = '{0}';", CV_Details(0)("Payee_ID"))
                                    End If
                                End If
                            ElseIf drv("PaidFrom").Contains("Acknowledgement") Then
                                Dim Check_Details As DataTable = DataSource(String.Format("SELECT Payee_Type, CheckID FROM acknowledgement_receipt WHERE CheckID > 0 AND ID = {0};", cbxPayee.SelectedValue))
                                If Check_Details.Rows.Count > 0 Then
                                    If Check_Details(0)("Payee_Type") = "DF" Then
                                        SQL &= String.Format("UPDATE dc_details SET check_status = 'BOUNCED', Remarks = CONCAT(Remarks, ' [BOUNCED]') WHERE ID = '{0}';", Check_Details(0)("CheckID"))
                                    Else
                                        SQL &= String.Format("UPDATE check_received SET status = 'BOUNCED', Remarks = CONCAT(Remarks, ' [BOUNCED]') WHERE ID = '{0}';", Check_Details(0)("CheckID"))
                                    End If
                                End If
                            ElseIf drv("PaidFrom").Contains("Official Receipt") Then
                                Dim Check_Details As DataTable = DataSource(String.Format("SELECT CheckID FROM official_receipt WHERE CheckID > 0 AND ID = {0};", cbxPayee.SelectedValue))
                                If Check_Details.Rows.Count > 0 Then
                                    SQL &= String.Format("UPDATE check_received SET status = 'BOUNCED', Remarks = CONCAT(Remarks, ' [BOUNCED]') WHERE ID = '{0}';", Check_Details(0)("CheckID"))
                                End If
                                SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}';", DataObject(String.Format("SELECT Payee_ID FROM official_receipt WHERE ID = '{0}';", cbxPayee.SelectedValue)))

                                For x As Integer = 0 To GridView2.RowCount - 1
                                    If GridView2.GetRowCellValue(x, "AR_DocumentNumber") = "" Then
                                    Else
                                        DataObject(String.Format("UPDATE accounts_receivable SET Paid = Paid - {1}, `AR_Status` = IF(Paid - {1} = 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}'; UPDATE ar_details SET Paid = Paid - {1} WHERE DocumentNumber = '{0}' AND Paid > 0 AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "AR_DocumentNumber"), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                                    End If
                                Next
                            ElseIf drv("PaidFrom").Contains("Loans") And txtReferenceNumber.Enabled = False And txtReferenceNumber.Text <> "" And Refinance = False Then

                                TransferROPOA()
                            ElseIf drv("PaidFrom").Contains("Loans") Then
                                'REFINANCING
                                If Refinance Then
                                    Dim SQL_Refinance As String = ""
                                    Dim DT_Appraise As DataTable
                                    If drv("Cash Advance") = 1 Then
                                        DT_Appraise = DataSource(String.Format("SELECT asset_number, AppraiseSellingPrice FROM appraise_ve WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND CollateralNumber != '';", drv("Payee_ID")))
                                    Else
                                        DT_Appraise = DataSource(String.Format("SELECT asset_number, AppraiseSellingPrice FROM appraise_re WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND CollateralNumber != '';", drv("Payee_ID")))
                                    End If
                                    For x As Integer = 0 To DT_Appraise.Rows.Count - 1
                                        SQL_Refinance &= String.Format(" UPDATE accounting_entry SET SoldID = '{0}' WHERE JVNum = '{1}' AND PaidFor = '{2}';", DataObject(String.Format(" SELECT ID FROM sold_ropoa WHERE AssetNumber = '{0}' ORDER BY ID DESC LIMIT 1;", DT_Appraise(x)("asset_number"))), txtDocumentNumber.Text, DT_Appraise(x)("asset_number"))
                                    Next
                                    If RestructureNotAutomatic("", drv("Payee_ID")) = False Then
                                        Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                    DataObject(SQL_Refinance)

                                ElseIf CVforJV Then
                                    '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************
                                    Code = GenerateOTAC()
                                    Code_Approve = Code
                                    Dim Msg As String = ""
                                    Dim Subject As String = ""
                                    Dim FName As String = ""
                                    Dim EmailTo As String = ""
                                    Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
                                    Dim Requirements As String = ""
                                    Dim DT_Requirements As DataTable = DataSource(String.Format("SELECT Requirement(Doc_ID) AS 'Document' FROM submit_documents WHERE is_complete = 'NO' AND `status` = 'ACTIVE' AND CreditNumber = '{0}';", drv("Payee_ID")))
                                    For x As Integer = 0 To DT_Requirements.Rows.Count - 1
                                        Requirements &= x + 1 & ".) " & DT_Requirements(x)("Document") & "<br>" & vbCrLf
                                    Next
                                    Dim BM As DataTable = GetBM(Branch_ID)
                                    For x As Integer = 0 To BM.Rows.Count - 1
                                        Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Releasing of the Account of {1}." & vbCrLf, Code, cbxPayee.Text)

                                        If Requirements = "" Then
                                        Else
                                            Msg &= "<br><br> List of Lacking Requirements :"
                                            Msg &= vbCrLf & "<br>" & Requirements & "<br>" & vbCrLf
                                        End If

                                        Msg &= "Thank you!"
                                        '******* SEND SMS *********************************************************************************
                                        If BM(x)("Phone") = "" Then
                                        Else
                                            SendSMS(BM(x)("Phone"), Msg.Replace("<br>", ""), True)
                                        End If
                                        '******* SEND EMAIL *********************************************************************************
                                        If BM(x)("EmailAdd") = "" Then
                                        Else
                                            EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
                                        End If
                                    Next
                                    If EmailTo = "" Then
                                    Else
                                        Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
                                        AttachmentFiles = New ArrayList()
                                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                        GenerateJV(False, FName, txtCheck.Text, txtApproved.Text)
                                        AttachmentFiles.Add(FName)
                                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, True, False, 0, "", "")
                                    End If
                                    SQL &= String.Format(" UPDATE credit_application SET `PaymentRequest` = 'APPROVED REQUEST', Release_OTAC = '{1}' WHERE CreditNumber = '{0}' AND `PaymentRequest` != 'RELEASED';", drv("Payee_ID"), Code_Approve)
                                    '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************
                                End If
                            ElseIf drv("PaidFrom").ToString.Contains("Check Voucher") And drv("Payee_ID").ToString.Contains("CA") And drv("Payee_ID").ToString.Length = 16 Then
                                If MsgBoxYes("Do you want to automatically CANCEL the Credit Application? If No the application will return to payment request.") = MsgBoxResult.Yes Then
                                    Dim PW As New FrmPassword
                                    With PW
                                        .ShowMessage = False
                                        .lblNote.Text = "*Please fill your password to continue to cancel the application."
HEREV2:
                                        If .ShowDialog = DialogResult.OK Then
                                            If FrmLogin.txtPassword.Text = .txtPassword.Text Then
                                                SQL &= String.Format("UPDATE credit_application SET `status` = 'CANCELLED', PaymentRequest = 'PENDING', HoldReason = 'Cancelled Credit Application' WHERE CreditNumber = '{0}';", drv("Payee_ID"))
                                            Else
                                                MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                                                .txtPassword.Text = ""
                                                GoTo HEREV2
                                            End If
                                        Else
                                            Exit Sub
                                        End If
                                        .Dispose()
                                    End With
                                Else
                                    '*UPDATE credit_applicat i set ang PaymentRequest para dli ma release
                                    SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'PENDING' WHERE CreditNumber = '{0}';", drv("Payee_ID"))
                                    SQL &= String.Format(" UPDATE check_received SET `status` = 'CANCELLED' WHERE AssetNumber = '{0}' AND CVNumber = '{1}';", drv("Payee_ID"), drv("ReferenceN"))
                                End If
                            ElseIf drv("PaidFrom").ToString.Contains("Restructuring") Then
                                AccountNumberRestructuring = drv("ORDate")
                                If cbxBank.SelectedValue <> BankID And BankID <> 0 Then
                                Else
                                    If RestructureNotAutomatic(drv("AmountDue"), cbxPayee.SelectedValue) = False Then
                                        Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                End If
                            ElseIf drv("PaidFrom") = "DTS JV" Then
                                AccountNumberRestructuring = drv("ORDate")
                                Dim DoneRestructure As String = DataObject(String.Format("SELECT PaymentRequest FROM credit_application WHERE CreditNumber = '{0}';", drv("AmountDue")))
                                If DoneRestructure = "CLOSED" Then
                                Else
                                    If RestructureNotAutomatic(drv("AmountDue"), drv("Payee_ID")) = False Then
                                        Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                End If
                            End If
                            DataObject(String.Format(SQL & "UPDATE journal_voucher SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE accounts_receivable SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}';", ID, .cbxProvider.SelectedValue, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Journal Voucher", "Approve", String.Format("Approved Journal Voucher of {0} with the total amount of {1}. [Via OTAC]", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")
                            If CVforJV Then
                                If RestructureNotAutomatic("", drv("Payee_ID")) = False Then
                                    'Cursor = Cursors.Default
                                    'Exit Sub
                                End If
                            End If
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
            If MsgBoxYes("Are you sure you want to approve this Journal Voucher?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = String.Format("UPDATE accounting_entry SET ORDate = '{1}', `Status` = 'ACTIVE', PostStatus = 'POSTED' WHERE JVNum = '{0}' AND IF(PaidFor = 'RPPD-A',TRUE,`status` = 'PENDING') AND `status` != 'CANCELLED';", txtDocumentNumber.Text, Format(dtpPostingDate.Value, "yyyy-MM-dd"))

                If drv("PaidFrom") = "Journal Voucher" Then
                    Dim JV_Details As DataTable
                    Dim JVNumber As String = ""
                    Dim Counter As Integer = 0
Here:
                    Counter += 1 'if Odd or Even 
                    JV_Details = DataSource(String.Format("SELECT ReferenceID, JVFrom, DocumentNumber, Payee_ID FROM journal_voucher WHERE JVNumber = '{0}';", If(JVNumber = "", txtDocumentNumber.Text, JVNumber)))
                    If JV_Details.Rows.Count > 0 Then
                        If JV_Details(0)("JVFrom") = "Acknowledgement CAS" Then
                            Dim ACR_Details As DataTable = DataSource(String.Format("SELECT DocumentNumber FROM acknowledgement_receipt WHERE Payee_ID = '{0}';", JV_Details(0)("ReferenceID")))
                            If ACR_Details.Rows.Count > 0 Then
                                SQL &= String.Format("UPDATE cash_advance SET `status` = IF(`status` = 'ACTIVE','CANCELLED','ACTIVE'), Purpose = CONCAT(Purpose, ' [Reversed ACR]'), ACRNumber = IF(`ACRNumber` = '','{1}','') WHERE AccountNumber = '{0}';", JV_Details(0)("ReferenceID"), ACR_Details(0)("DocumentNumber"))
                            End If
                        ElseIf JV_Details(0)("JVFrom") = "Acknowledgement RO" Then
                            Dim CountRemainingACR As Integer = DataObject(String.Format("SELECT COUNT(ID) FROM acknowledgement_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'RO' AND `status` = 'ACTIVE' AND JVNumber = '' AND ID != '{1}';", drv("Payee_ID"), JV_Details(0)("ReferenceID")))
                            Dim AssetNumber As String = DataObject(String.Format("SELECT Payee_ID FROM acknowledgement_receipt WHERE ID = '{0}';", JV_Details(0)("ReferenceID")))
                            If CountRemainingACR = 0 Then
                                SQL &= String.Format("UPDATE sold_ropoa SET `status` = IF(`status` = 'ACTIVE','CANCELLED','ACTIVE') WHERE AssetNumber = '{0}' AND JVNumber = '{1}';", AssetNumber, JV_Details(0)("DocumentNumber"))
                                SQL &= String.Format("UPDATE accounting_entry SET ReferenceN = '{1}' WHERE JVNum = '{0}' AND `status` != 'CANCELLED';", txtDocumentNumber.Text, AssetNumber)
                                If AssetNumber.Contains("ANV") Then
                                    SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = IF(`sell_status` = 'SOLD','SELL','SOLD') WHERE AssetNumber = '{0}';", AssetNumber)
                                Else
                                    SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = IF(`sell_status` = 'SOLD','SELL','SOLD') WHERE AssetNumber = '{0}';", AssetNumber)
                                End If
                            End If
                        ElseIf JV_Details(0)("JVFrom") = "Check Voucher" Then
                            Dim DT_CV As DataTable = DataSource(String.Format("SELECT DocumentNumber, Payee_ID, Payee_Type FROM check_voucher WHERE ID = '{0}';", JV_Details(0)("Payee_ID")))
                            If DT_CV.Rows.Count > 0 Then
                                If DT_CV(0)("Payee_Type") = "C" Then
                                    SQL &= String.Format(String.Format("UPDATE credit_application SET `status` = IF(`status` = 'ACTIVE','CANCELLED','ACTIVE'), `PaymentRequest` = IF(`status` = 'ACTIVE','APPROVED REQUEST','JV Request') WHERE CreditNumber = '{0}';", DT_CV(0)("Payee_ID")))
                                ElseIf DT_CV(0)("Payee_Type") = "RC" Then
                                    SQL &= String.Format("UPDATE replenishment_cash SET `ReplenishStatus` = 'PENDING', CVNumber = '' WHERE DocumentNumber = '{0}';", DT_CV(0)("Payee_ID"))
                                ElseIf DT_CV(0)("Payee_Type") = "L" Then
                                    SQL &= String.Format("UPDATE liquidation_main SET `Refund` = IF(Refund = 0,1,0) WHERE AccountNumber = '{0}';", DT_CV(0)("Payee_ID"))
                                ElseIf DT_CV(0)("Payee_Type") = "A" Then
                                    SQL &= String.Format("UPDATE cash_advance SET `CVNumber` = IF(CVNumber = '','{1}','') WHERE AccountNumber = '{0}';", DT_CV(0)("Payee_ID"), DT_CV(0)("DocumentNumber"))
                                End If
                            End If
                        ElseIf JV_Details(0)("JVFrom") = "Official Receipt" Then
                            Dim DT_Waive As DataTable = DataSource(String.Format("SELECT Amount, ORNum FROM accounting_entry WHERE CVNumber = '{0}' AND ReferenceN = '{1}' AND PaidFor = 'RPPD-W' AND Remarks LIKE '%Waive for RPPD%'", JV_Details(0)("DocumentNumber"), JV_Details(0)("ReferenceID")))
                            If DT_Waive.Rows.Count > 0 Then
                                SQL &= "INSERT INTO accounting_entry SET"
                                SQL &= String.Format(" JVNum = '{0}', ", txtDocumentNumber.Text)
                                SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                                SQL &= String.Format(" ORNum = '{0}', ", DT_Waive(0)("ORNum"))
                                SQL &= String.Format(" ORDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                                SQL &= String.Format(" ReferenceN = '{0}', ", JV_Details(0)("ReferenceID"))
                                If Counter Mod 2 = 0 Then
                                    SQL &= " EntryType = 'DEBIT',"
                                    SQL &= " Remarks = 'Waive for RPPD [Reversal]', "
                                Else
                                    SQL &= " EntryType = 'CREDIT',"
                                    SQL &= " Remarks = 'Waive for RPPD', "
                                End If
                                SQL &= " AccountCode = '', " 'Waived RPPD
                                SQL &= " MotherCode = '', " 'Waived Penalty
                                SQL &= String.Format(" Amount = '{0}', ", DT_Waive(0)("Amount"))
                                SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-W")
                                SQL &= String.Format(" PostStatus = '{0}', ", "POSTED")
                                SQL &= String.Format(" BankID = '{0}', ", BankID)
                                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                            End If
                        ElseIf JV_Details(0)("JVFrom") = "Acknowledgement LA" Then
                            Dim ACR_Details As DataTable = DataSource(String.Format("SELECT PlateNum FROM acknowledgement_receipt WHERE JVNumber = '{0}' AND `status` = 'ACTIVE';", JV_Details(0)("DocumentNumber")))
                            If ACR_Details.Rows.Count > 0 Then
                                If ACR_Details(0)("PlateNum") = "BILL DEDUCT" Then
                                    SQL &= String.Format("UPDATE credit_application SET `BillDeductionsStatus` = IF(`BillDeductionsStatus` = 'PAID','PENDING','PAID') WHERE CreditNumber = '{0}' AND BillDeductions = 1;", JV_Details(0)("ReferenceID"))
                                End If
                            End If
                        ElseIf JV_Details(0)("JVFrom") = "Journal Voucher" Then
                            JVNumber = JV_Details(0)("DocumentNumber")
                            GoTo Here
                        End If
                    End If
                ElseIf drv("PaidFrom") = "Acknowledgement LA" Then
                    Dim ACR_Details As DataTable = DataSource(String.Format("SELECT PlateNum, Payee_ID FROM acknowledgement_receipt WHERE ID = {0};", cbxPayee.SelectedValue))
                    If ACR_Details.Rows.Count > 0 Then
                        If ACR_Details(0)("PlateNum") = "BILL DEDUCT" Then
                            SQL &= String.Format("UPDATE credit_application SET `BillDeductionsStatus` = IF(`BillDeductionsStatus` = 'PAID','PENDING','PAID') WHERE CreditNumber = '{0}' AND BillDeductions = 1;", ACR_Details(0)("Payee_ID"))
                        End If
                    End If
                ElseIf drv("PaidFrom") = "Acknowledgement CAS" Then
                    Dim ACR_Details As DataTable = DataSource(String.Format("SELECT DocumentNumber FROM acknowledgement_receipt WHERE ID = {0};", cbxPayee.SelectedValue))
                    If ACR_Details.Rows.Count > 0 Then
                        SQL &= String.Format("UPDATE cash_advance SET `status` = IF(`status` = 'ACTIVE','CANCELLED','ACTIVE'), Purpose = CONCAT(Purpose, ' [Reversed ACR]'), ACRNumber = IF(`ACRNumber` = '','{0}','') WHERE ACRNumber = '{0}';", ACR_Details(0)("DocumentNumber"))
                    End If
                ElseIf drv("PaidFrom") = "Check Voucher" Then
                    Dim CV_Details As DataTable = DataSource(String.Format("SELECT Payee_ID, Payee_Type FROM check_voucher WHERE ID = {0};", cbxPayee.SelectedValue))
                    If CV_Details.Rows.Count > 0 Then
                        If CV_Details(0)("Payee_Type") = "RC" Then
                            SQL &= String.Format("UPDATE replenishment_cash SET `ReplenishStatus` = 'PENDING', CVNumber = '' WHERE DocumentNumber = '{0}';", CV_Details(0)("Payee_ID"))
                        ElseIf CV_Details(0)("Payee_Type") = "L" Then
                            SQL &= String.Format("UPDATE liquidation_main SET `Refund` = '0' WHERE AccountNumber = '{0}';", CV_Details(0)("Payee_ID"))
                        ElseIf CV_Details(0)("Payee_Type") = "A" Then
                            SQL &= String.Format("UPDATE cash_advance SET `CVNumber` = '' WHERE AccountNumber = '{0}';", CV_Details(0)("Payee_ID"))
                        End If
                    End If
                ElseIf drv("PaidFrom").ToString.Contains("Acknowledgement") Then
                    Dim Check_Details As DataTable = DataSource(String.Format("SELECT Payee_Type, CheckID FROM acknowledgement_receipt WHERE CheckID > 0 AND ID = {0};", cbxPayee.SelectedValue))
                    If Check_Details.Rows.Count > 0 Then
                        If Check_Details(0)("Payee_Type") = "DF" Then
                            SQL &= String.Format("UPDATE dc_details SET check_status = 'BOUNCED', Remarks = CONCAT(Remarks, ' [BOUNCED]') WHERE ID = '{0}';", Check_Details(0)("CheckID"))
                        Else
                            SQL &= String.Format("UPDATE check_received SET status = 'BOUNCED', Remarks = CONCAT(Remarks, ' [BOUNCED]') WHERE ID = '{0}';", Check_Details(0)("CheckID"))
                        End If
                    End If
                ElseIf drv("PaidFrom").ToString.Contains("Official Receipt") Then
                    Dim Check_Details As DataTable = DataSource(String.Format("SELECT CheckID FROM official_receipt WHERE CheckID > 0 AND ID = {0};", cbxPayee.SelectedValue))
                    If Check_Details.Rows.Count > 0 Then
                        SQL &= String.Format("UPDATE check_received SET status = 'BOUNCED', Remarks = CONCAT(Remarks, ' [BOUNCED]') WHERE ID = '{0}';", Check_Details(0)("CheckID"))
                    End If
                    SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}';", DataObject(String.Format("SELECT Payee_ID FROM official_receipt WHERE ID = '{0}';", cbxPayee.SelectedValue)))

                    For x As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(x, "AR_DocumentNumber") = "" Then
                        Else
                            DataObject(String.Format("UPDATE accounts_receivable SET Paid = Paid - {1}, `AR_Status` = IF(Paid - {1} = 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}'; UPDATE ar_details SET Paid = Paid - {1} WHERE DocumentNumber = '{0}' AND Paid > 0 AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "AR_DocumentNumber"), CDbl(GridView2.GetRowCellValue(x, "Debit"))))
                        End If
                    Next
                ElseIf drv("PaidFrom").ToString.Contains("Loans") And txtReferenceNumber.Enabled = False And txtReferenceNumber.Text <> "" And Refinance = False Then

                    TransferROPOA()
                ElseIf drv("PaidFrom").ToString.Contains("Loans") Then
                    'REFINANCING
                    If Refinance Then
                        Dim SQL_Refinance As String = ""
                        Dim DT_Appraise As DataTable
                        If drv("Cash Advance") = 1 Then
                            DT_Appraise = DataSource(String.Format("SELECT asset_number, AppraiseSellingPrice FROM appraise_ve WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND CollateralNumber != '';", drv("Payee_ID")))
                        Else
                            DT_Appraise = DataSource(String.Format("SELECT asset_number, AppraiseSellingPrice FROM appraise_re WHERE credit_number = '{0}' AND `status` = 'ACTIVE' AND CollateralNumber != '';", drv("Payee_ID")))
                        End If
                        For x As Integer = 0 To DT_Appraise.Rows.Count - 1
                            SQL_Refinance &= String.Format(" UPDATE accounting_entry SET SoldID = '{0}' WHERE JVNum = '{1}' AND PaidFor = '{2}';", DataObject(String.Format(" SELECT ID FROM sold_ropoa WHERE AssetNumber = '{0}' ORDER BY ID DESC LIMIT 1;", DT_Appraise(x)("asset_number"))), txtDocumentNumber.Text, DT_Appraise(x)("asset_number"))
                        Next
                        If RestructureNotAutomatic("", drv("Payee_ID")) = False Then
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                        DataObject(SQL_Refinance)
                    ElseIf CVforJV Then
                        '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************
                        Code = GenerateOTAC()
                        Code_Approve = Code
                        Dim Msg As String = ""
                        Dim Subject As String = ""
                        Dim FName As String = ""
                        Dim EmailTo As String = ""
                        Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
                        Dim Requirements As String = ""
                        Dim DT_Requirements As DataTable = DataSource(String.Format("SELECT Requirement(Doc_ID) AS 'Document' FROM submit_documents WHERE is_complete = 'NO' AND `status` = 'ACTIVE' AND CreditNumber = '{0}';", drv("Payee_ID")))
                        For x As Integer = 0 To DT_Requirements.Rows.Count - 1
                            Requirements &= x + 1 & ".) " & DT_Requirements(x)("Document") & "<br>" & vbCrLf
                        Next
                        Dim BM As DataTable = GetBM(Branch_ID)
                        For x As Integer = 0 To BM.Rows.Count - 1
                            Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Releasing of the Account of {1}." & vbCrLf, Code, cbxPayee.Text)

                            If Requirements = "" Then
                            Else
                                Msg &= "<br><br> List of Lacking Requirements :"
                                Msg &= vbCrLf & "<br>" & Requirements & "<br>" & vbCrLf
                            End If

                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If BM(x)("Phone") = "" Then
                            Else
                                SendSMS(BM(x)("Phone"), Msg.Replace("<br>", ""), True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If BM(x)("EmailAdd") = "" Then
                            Else
                                EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
                            End If
                        Next
                        If EmailTo = "" Then
                        Else
                            Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
                            AttachmentFiles = New ArrayList()
                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtDocumentNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            GenerateJV(False, FName, txtCheck.Text, txtApproved.Text)
                            AttachmentFiles.Add(FName)
                            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, True, False, 0, "", "")
                        End If
                        SQL &= String.Format(" UPDATE credit_application SET `PaymentRequest` = 'APPROVED REQUEST', Release_OTAC = '{1}' WHERE CreditNumber = '{0}' AND `PaymentRequest` != 'RELEASED';", drv("Payee_ID"), Code_Approve)
                        '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************
                    End If
                ElseIf drv("PaidFrom").ToString.Contains("Check Voucher") And drv("Payee_ID").ToString.Contains("CA") And drv("Payee_ID").ToString.Length = 16 Then
                    If MsgBoxYes("Do you want to automatically CANCEL the Credit Application? If No the application will return to payment request.") = MsgBoxResult.Yes Then
                        Dim PW As New FrmPassword
                        With PW
                            .ShowMessage = False
                            .lblNote.Text = "*Please fill your password to continue to cancel the application."
HEREV3:
                            If .ShowDialog = DialogResult.OK Then
                                If FrmLogin.txtPassword.Text = .txtPassword.Text Then
                                    SQL &= String.Format("UPDATE credit_application SET `status` = 'CANCELLED', PaymentRequest = 'PENDING', HoldReason = 'Cancelled Credit Application' WHERE CreditNumber = '{0}';", drv("Payee_ID"))
                                Else
                                    MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                                    .txtPassword.Text = ""
                                    GoTo HEREV3
                                End If
                            Else
                                Exit Sub
                            End If
                            .Dispose()
                        End With
                    Else
                        '*UPDATE credit_applicat i set ang PaymentRequest para dli ma release
                        SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'PENDING' WHERE CreditNumber = '{0}';", drv("Payee_ID"))
                        SQL &= String.Format(" UPDATE check_received SET `status` = 'CANCELLED' WHERE AssetNumber = '{0}' AND CVNumber = '{1}';", drv("Payee_ID"), drv("ReferenceN"))
                    End If
                ElseIf drv("PaidFrom").ToString.Contains("Restructuring") Then
                    AccountNumberRestructuring = drv("ORDate")
                    If cbxBank.SelectedValue <> BankID And BankID <> 0 Then
                    Else
                        If RestructureNotAutomatic(drv("AmountDue"), cbxPayee.SelectedValue) = False Then
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If
                ElseIf drv("PaidFrom") = "DTS JV" Then
                    Dim DoneRestructure As String = DataObject(String.Format("SELECT PaymentRequest FROM credit_application WHERE CreditNumber = '{0}';", drv("AmountDue")))
                    If DoneRestructure = "CLOSED" Then
                    Else
                        AccountNumberRestructuring = drv("ORDate")
                        If RestructureNotAutomatic(drv("AmountDue"), drv("Payee_ID")) = False Then
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End If
                End If
                DataObject(String.Format(SQL & "UPDATE journal_voucher SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_receivable SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Journal Voucher", "Approve", String.Format("Approved Journal Voucher of {0} with the total amount of {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")
                If CVforJV Then
                    If RestructureNotAutomatic("", drv("Payee_ID")) = False Then
                        'Cursor = Cursors.Default
                        'Exit Sub
                    End If
                End If
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

    Private Function RestructureNotAutomatic(CreditNumber_Old As String, CreditNumber_New As String)
        Dim SQL As String = ""
        'CLOSE OLD ACCOUNT
        If CreditNumber_Old = "" Then
        Else
            SQL = String.Format(" UPDATE credit_application SET PaymentRequest = 'CLOSED', ClosedDate = '{1}' WHERE CreditNumber = '{0}' AND PaymentRequest = 'RELEASED';", CreditNumber_Old, FormatDatePicker(dtpPostingDate))
        End If
        'PAYMENT RELEASE ******************************************************************************************
        Dim Release As New FrmPaymentRelease
        With Release
            .vSave = True
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .From_JV = True
            .CreditNumber_Old = CreditNumber_Old
            .CreditNumber_New = CreditNumber_New
            .FormBorderStyle = FormBorderStyle.FixedSingle
            .cbxApplication.Enabled = False
            .tabList.Visible = False
            .btnNext.Enabled = False
            .btnRefresh.Enabled = False
            If .ShowDialog = DialogResult.OK Then
            Else
                Return False
                Exit Function
            End If
            .Dispose()
        End With
        'PAYMENT RELEASE ******************************************************************************************

        'ACCOUNTS RECEIVABLE / COLLECTIBLES ******************************************************************************************
        Dim BillDeductions As Boolean = DataObject(String.Format("SELECT BillDeductions FROM credit_application WHERE CreditNumber = '{0}';", CreditNumber_New))
        Dim WithACR As Boolean = DataObject(String.Format("SELECT Count(ID) FROM acknowledgement_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'LA' AND `status` = 'ACTIVE';", CreditNumber_New))
        If BillDeductions And WithACR = 0 Then
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
                .GL_DocumentNumber = CreditNumber_New
                .cbxBank.Tag = cbxBank.SelectedValue
                If .ShowDialog = DialogResult.OK Then
                End If
                .Dispose()
            End With
        End If
        'ACCOUNTS RECEIVABLE / COLLECTIBLES ******************************************************************************************
        If SQL = "" Then
        Else
            DataObject(SQL)
        End If
        Return True
    End Function

    Private Function Restructure(CreditNumber_Old As String, CreditNumber_New As String)
        Dim ProductCode As String = DataObject(String.Format("SELECT product_code FROM product_setup WHERE ID = (SELECT product_id FROM credit_application WHERE CreditNumber = '{0}')", CreditNumber_New))
        Dim AccountNumber As String = DataObject(String.Format("SELECT CONCAT('{1}', LPAD(COUNT(ID) + 1,IF(LENGTH(COUNT(ID)) < 6,6,LENGTH(COUNT(ID))),'0')) FROM credit_released WHERE branch_id = '{0}';", Branch_ID, Branch_ID.ToString("D3") & If(ProductCode = "", "", ProductCode & "-")))
        Dim ReleasedData As DataTable = DataSource(String.Format("SELECT * FROM credit_application WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber_Old))
        'CLOSE OLD ACCOUNT
        Dim SQL As String = String.Format(" UPDATE credit_application SET PaymentRequest = 'CLOSED', ClosedDate = '{1}' WHERE CreditNumber = '{0}' AND PaymentRequest = 'RELEASED';", CreditNumber_Old, FormatDatePicker(dtpPostingDate))
        'OPEN NEW ACCOUNT
        SQL &= "INSERT INTO credit_released SET"
        SQL &= String.Format(" CreditNumber = '{0}', ", CreditNumber_New)
        SQL &= String.Format(" AccountNumber = '{0}', ", AccountNumberRestructuring)
        SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)

        SQL &= "UPDATE credit_application SET `PaymentRequest` = 'RELEASED', MigratedValidation = 0, "
        SQL &= String.Format(" AccountNumber = '{0}', ", AccountNumberRestructuring)
        SQL &= String.Format(" Loan_Type = '{0}', ", "RESTRUCTURE")
        SQL &= String.Format(" InsuranceComp = '{0}', ", ReleasedData(0)("InsuranceComp"))
        SQL &= String.Format(" Coverage = '{0}', ", ReleasedData(0)("Coverage"))
        SQL &= String.Format(" Expiry = '{0}', ", ReleasedData(0)("Expiry"))
        SQL &= String.Format(" Premium = '{0}', ", ReleasedData(0)("Premium"))
        SQL &= String.Format(" CVNum = '{0}', ", txtDocumentNumber.Text)
        SQL &= String.Format(" Insurance = '{0}', ", ReleasedData(0)("Insurance"))
        SQL &= String.Format(" Released = '{0}', ", FormatDatePicker(dtpPostingDate))
        SQL &= String.Format(" PN = '{0}', ", FormatDatePicker(dtpPostingDate))
        SQL &= String.Format(" FDD = '{0}', ", DataObject(String.Format("SELECT DueDate FROM credit_schedule WHERE `No` = 1 AND CreditNumber = '{0}' AND `status` = 'ACTIVE' ORDER BY id DESC LIMIT 1;", CreditNumber_New)))
        SQL &= String.Format(" LDD = '{0}', ", DataObject(String.Format("SELECT MAX(DueDate) FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber_New)))
        SQL &= String.Format(" CI = '{0}', ", DataObject(String.Format("SELECT LEFT(Employee(empl_id),LOCATE(' ',Employee(empl_id)) - 1) FROM users U WHERE U.user_code = (SELECT user_code FROM credit_investigation WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE')", CreditNumber_New)))
        SQL &= String.Format(" Referred = '{0}', ", ReleasedData(0)("Referred"))
        SQL &= String.Format(" Notes = '{0}', ", ReleasedData(0)("Notes"))
        SQL &= String.Format(" Remarks = '{0}', ", rExplanation.Text)
        SQL &= String.Format(" User_Code = '{0}', ", User_Code)
        SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
        SQL &= String.Format(" Branch_ID = '{0}' ", Branch_ID)
        SQL &= String.Format("  WHERE CreditNumber = '{0}';", CreditNumber_New)

        'ACCOUNTS RECEIVABLE / COLLECTIBLES ******************************************************************************************
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
            .GL_DocumentNumber = CreditNumber_New
            .cbxBank.Tag = cbxBank.SelectedValue
            If .ShowDialog = DialogResult.OK Then
            Else
                Return False
                Exit Function
            End If
            .Dispose()
        End With
        'ACCOUNTS RECEIVABLE / COLLECTIBLES ******************************************************************************************
        DataObject(SQL)
        Return True
    End Function

    Private Sub TransferROPOA()
        Dim MortgageID As Integer
        Dim Credit_DT As DataTable = DataSource(String.Format("SELECT Mortgage_ID, BorrowerID FROM credit_application WHERE CreditNumber = '{0}';", txtReferenceNumber.Text))
        If Credit_DT.Rows.Count = 0 Then
            Exit Sub
        End If
        MortgageID = Credit_DT(0)("Mortgage_ID")
        Dim DT_Collateral As DataTable
        Dim SQL As String
        Dim AssetNumber As String
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim BalanceTrans As Double
        Dim GotoROPOA As Boolean
        If MortgageID = 1 Then
            DT_Collateral = DataSource(String.Format("SELECT collateral_ve.*, (SELECT market_value FROM appraise_ve WHERE CollateralNumber = collateral_ve.CollateralNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1) AS 'MarketV', (SELECT appraise_num FROM appraise_ve WHERE CollateralNumber = collateral_ve.CollateralNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1) AS 'appraise_num', (SELECT Attach FROM appraise_ve WHERE CollateralNumber = collateral_ve.CollateralNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1) AS 'Appraise_Img' FROM collateral_ve WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", txtReferenceNumber.Text))
            If DT_Collateral.Rows.Count > 0 Then
                For x As Integer = 0 To DT_Collateral.Rows.Count - 1
                    GotoROPOA = False
                    BalanceTrans = 0
                    For y As Integer = 0 To GridView2.RowCount - 1
                        If DT_Collateral(x)("CollateralNumber") = GridView2.GetRowCellValue(y, "PaidFor") Then
                            BalanceTrans = CDbl(GridView2.GetRowCellValue(y, "Debit"))
                            GotoROPOA = True
                        End If
                    Next
                    If GotoROPOA = False Then
                        GoTo Here
                    End If
                    SQL = "INSERT INTO ropoa_vehicle SET"
                    SQL &= String.Format(" Nature = '{0}', ", "Voluntary Surrender")
                    SQL &= String.Format(" AccountID = '{0}', ", Credit_DT(0)("BorrowerID"))
                    SQL &= String.Format(" AccountNo = '{0}', ", drv("ORNum"))
                    SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpPostingDate))
                    AssetNumber = DataObject(String.Format("SELECT CONCAT('ANV', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM ropoa_vehicle WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{2}') AND MONTH(trans_date) = MONTH('{2}');", Branch_ID, Format(dtpPostingDate.Value, "yyyyMM"), Format(dtpPostingDate.Value, "yyyy-MM-dd")))
                    SQL &= String.Format(" AssetNumber = '{0}', ", AssetNumber)
                    SQL &= String.Format(" `Condition` = '{0}', ", "")
                    SQL &= String.Format(" `ConditionReason` = '{0}', ", "")
                    SQL &= String.Format(" Make = '{0}', ", DT_Collateral(x)("Make"))
                    SQL &= String.Format(" `Type` = '{0}', ", DT_Collateral(x)("Type"))
                    SQL &= String.Format(" `Used` = '{0}', ", DT_Collateral(x)("Used"))
                    SQL &= String.Format(" Model = '{0}', ", DT_Collateral(x)("Model"))
                    SQL &= String.Format(" Series = '{0}', ", DT_Collateral(x)("Series"))
                    SQL &= String.Format(" PlateNum = '{0}', ", DT_Collateral(x)("PlateNum"))
                    SQL &= String.Format(" Transmission = '{0}', ", DT_Collateral(x)("Transmission"))
                    SQL &= String.Format(" Fuel = '{0}', ", DT_Collateral(x)("Fuel"))
                    SQL &= String.Format(" BodyColor = '{0}', ", DT_Collateral(x)("BodyColor"))
                    SQL &= String.Format(" `Year` = '{0}', ", DT_Collateral(x)("Year"))
                    SQL &= String.Format(" EngineNum = '{0}', ", DT_Collateral(x)("EngineNum"))
                    SQL &= String.Format(" ChassisNum = '{0}', ", DT_Collateral(x)("ChassisNum"))
                    SQL &= String.Format(" RegistryCert = '{0}', ", DT_Collateral(x)("RegistryCert"))
                    SQL &= String.Format(" ORNum = '{0}', ", DT_Collateral(x)("ORNum"))
                    SQL &= String.Format(" GrossWeight = '{0}', ", DT_Collateral(x)("GrossWeight"))
                    SQL &= String.Format(" RimHoles = '{0}', ", DT_Collateral(x)("RimHoles"))
                    SQL &= String.Format(" MileAge = '{0}', ", DT_Collateral(x)("MileAge"))
                    SQL &= String.Format(" MileAgeType = '{0}', ", DT_Collateral(x)("MileAgeType"))
                    SQL &= " Price = 1, "
                    SQL &= String.Format(" BalanceTransferred = '{0}', ", BalanceTrans)
                    SQL &= String.Format(" DateRegistered = '{0}', ", DT_Collateral(x)("DateRegistered"))
                    SQL &= String.Format(" LTO = '{0}', ", DT_Collateral(x)("LTO"))
                    SQL &= String.Format(" Remarks = '{0}', ", DT_Collateral(x)("Remarks"))
                    SQL &= String.Format(" Img = '{0}', ", DT_Collateral(x)("Appraise_Img"))
                    SQL &= String.Format(" Bank = '{0}', ", DataObject(String.Format("SELECT `Code` FROM branch_bank WHERE ID = '{0}';", cbxBank.SelectedValue)))
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                    SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                    SQL &= String.Format(" User_Code = '{0}';", User_Code)

                    For y As Integer = 1 To DT_Collateral(x)("Appraise_Img")
                        Dim Filename As String
                        Dim Description As String = ""
                        If y Mod 5 = 1 Then
                            Description = "Front" & y
                        ElseIf y Mod 5 = 2 Then
                            Description = "Back" & y
                        ElseIf y Mod 5 = 3 Then
                            Description = "Interior" & y
                        ElseIf y Mod 5 = 4 Then
                            Description = "Engine" & y
                        ElseIf y Mod 5 = 0 Then
                            Description = "Odometer" & y
                        End If
                        Filename = Description & ".jpg"
                        '********CREATE FOLDER FSFC System
                        If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
                            IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
                        End If
                        '********CREATE FOLDER Branch
                        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, Branch_Code)) Then
                            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, Branch_Code))
                        End If
                        '********CREATE FOLDER Borrowers
                        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}", RootFolder, MainFolder, Branch_Code)) Then
                            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}", RootFolder, MainFolder, Branch_Code))
                        End If
                        '********CREATE FOLDER BorrowerID
                        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, Branch_Code, AssetNumber)) Then
                            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, Branch_Code, AssetNumber))
                        End If
                        '********CREATE File
                        Try
                            Dim xPath As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, Branch_Code, AssetNumber, Filename)
                            If IO.File.Exists(xPath) Then
                                IO.File.Delete(xPath)
                            End If
                            IO.File.Copy(String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, txtReferenceNumber.Text, DT_Collateral(x)("appraise_num"), Filename), xPath)
                        Catch ex As Exception
                        End Try
                    Next
                    SQL &= String.Format("UPDATE accounting_entry SET ReferenceN = '{0}', PaidFor = 'Balance Transferred', CVNumber = '{2}' WHERE PaidFor = '{2}' AND JVNum = '{1}';", AssetNumber, txtDocumentNumber.Text, DT_Collateral(x)("CollateralNumber"))
                    'SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'CLOSED' WHERE CreditNumber = '{0}';", txtReferenceNumber.Text)
                    DataObject(SQL)
Here:
                Next
            End If
        ElseIf MortgageID = 2 Then
            DT_Collateral = DataSource(String.Format("SELECT collateral_re.*, (SELECT market_value FROM appraise_re WHERE CollateralNumber = collateral_re.CollateralNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1) AS 'MarketV', (SELECT appraise_num FROM appraise_re WHERE CollateralNumber = collateral_re.CollateralNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1) AS 'appraise_num', (SELECT Attach FROM appraise_re WHERE CollateralNumber = collateral_re.CollateralNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1) AS 'Appraise_Img' FROM collateral_re WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", txtReferenceNumber.Text))
            If DT_Collateral.Rows.Count > 0 Then
                For x As Integer = 0 To DT_Collateral.Rows.Count - 1
                    GotoROPOA = False
                    BalanceTrans = 0
                    For y As Integer = 0 To GridView2.RowCount - 1
                        If DT_Collateral(x)("CollateralNumber") = GridView2.GetRowCellValue(y, "PaidFor") Then
                            BalanceTrans = CDbl(GridView2.GetRowCellValue(y, "Debit"))
                            GotoROPOA = True
                        End If
                    Next
                    If GotoROPOA = False Then
                        GoTo Here_2
                    End If
                    SQL = " INSERT INTO ropoa_realestate SET"
                    SQL &= String.Format(" Nature = '{0}', ", "Voluntary Surrender")
                    SQL &= String.Format(" AccountID = '{0}', ", Credit_DT(0)("BorrowerID"))
                    SQL &= String.Format(" AccountNo = '{0}', ", drv("ORNum"))
                    SQL &= String.Format(" trans_date = '{0}', ", FormatDatePicker(dtpPostingDate))
                    AssetNumber = DataObject(String.Format("SELECT CONCAT('ANR', LPAD({0},3,'0'), {1}, '-', LPAD(COUNT(ID) + 1,4,'0')) FROM ropoa_realestate WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{2}') AND MONTH(trans_date) = MONTH('{2}');", Branch_ID, Format(dtpPostingDate.Value, "yyyyMM"), Format(dtpPostingDate.Value, "yyyy-MM-dd")))
                    SQL &= String.Format(" AssetNumber = '{0}', ", AssetNumber)
                    SQL &= String.Format(" TCT = '{0}', ", DT_Collateral(x)("TCT"))
                    SQL &= String.Format(" Location = '{0}', ", DT_Collateral(x)("Location"))
                    SQL &= String.Format(" Coordinates = '{0}', ", DT_Collateral(x)("Coordinates"))
                    SQL &= String.Format(" `Area` = '{0}', ", DT_Collateral(x)("Area"))
                    SQL &= String.Format(" Classification = '{0}', ", DT_Collateral(x)("Classification"))
                    SQL &= " Price = 1, "
                    SQL &= String.Format(" BalanceTransferred = '{0}', ", BalanceTrans)
                    SQL &= String.Format(" VacantLot = '{0}', ", DT_Collateral(x)("VacantLot"))
                    SQL &= String.Format(" Storey = '{0}', ", DT_Collateral(x)("Storey"))
                    SQL &= String.Format(" Roofings = '{0}', ", DT_Collateral(x)("Roofings"))
                    SQL &= String.Format(" Flooring = '{0}', ", DT_Collateral(x)("Flooring"))
                    SQL &= String.Format(" TandB = '{0}', ", DT_Collateral(x)("TandB"))
                    SQL &= String.Format(" Frame = '{0}', ", DT_Collateral(x)("Frame"))
                    SQL &= String.Format(" Beams = '{0}', ", DT_Collateral(x)("Beams"))
                    SQL &= String.Format(" Doors = '{0}', ", DT_Collateral(x)("Doors"))
                    SQL &= String.Format(" YearConstructed = '{0}', ", DT_Collateral(x)("YearConstructed"))
                    SQL &= String.Format(" Walling = '{0}', ", DT_Collateral(x)("Walling"))
                    SQL &= String.Format(" `Ceiling` = '{0}', ", DT_Collateral(x)("Ceiling"))
                    SQL &= String.Format(" Windows = '{0}', ", DT_Collateral(x)("Windows"))
                    SQL &= String.Format(" FloorArea = '{0}', ", DT_Collateral(x)("FloorArea"))
                    SQL &= String.Format(" `Partitions` = '{0}', ", DT_Collateral(x)("Partitions"))
                    SQL &= String.Format(" Remarks = '{0}', ", DT_Collateral(x)("Remarks"))
                    SQL &= String.Format(" Bank = '{0}', ", DataObject(String.Format("SELECT `Code` FROM branch_bank WHERE ID = '{0}';", cbxBank.SelectedValue)))
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" Img = '{0}', ", DT_Collateral(x)("Appraise_Img"))
                    SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                    SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                    SQL &= String.Format(" User_Code = '{0}';", User_Code)

                    Dim DT_Pictures As DataTable = DataSource(String.Format("SELECT Picture FROM re_classification WHERE Classification = '{0}' AND `status` = 'ACTIVE';", DT_Collateral(x)("Classification")))
                    For y As Integer = 1 To If(CInt(DT_Collateral(x)("Appraise_Img")) > DT_Pictures.Rows.Count, CInt(DT_Collateral(x)("Appraise_Img")), DT_Pictures.Rows.Count)
                        Dim Filename As String
                        Dim Description As String
                        If y > DT_Pictures.Rows.Count Then
                            Description = "No Image" & y
                        Else
                            Description = DT_Pictures(x - 1)("Picture")
                        End If
                        Filename = Description & ".jpg"
                        '********CREATE FOLDER FSFC System
                        If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
                            IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
                        End If
                        '********CREATE FOLDER Branch
                        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, Branch_Code)) Then
                            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset", RootFolder, MainFolder, Branch_Code))
                        End If
                        '********CREATE FOLDER Borrowers
                        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}", RootFolder, MainFolder, Branch_Code)) Then
                            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}", RootFolder, MainFolder, Branch_Code))
                        End If
                        '********CREATE FOLDER BorrowerID
                        If Not IO.Directory.Exists(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, Branch_Code, AssetNumber)) Then
                            IO.Directory.CreateDirectory(String.Format("{0}\{1}\Asset\{2}\{3}", RootFolder, MainFolder, Branch_Code, AssetNumber))
                        End If
                        '********CREATE File
                        Try
                            Dim xPath As String = String.Format("{0}\{1}\Asset\{2}\{3}\{4}", RootFolder, MainFolder, Branch_Code, AssetNumber, Filename)
                            If IO.File.Exists(xPath) Then
                                IO.File.Delete(xPath)
                            End If
                            IO.File.Copy(String.Format("{0}\{1}\{2}\Application\{3}\{4}\{5}", RootFolder, MainFolder, Branch_Code, txtReferenceNumber.Text, DT_Collateral(x)("appraise_num"), Filename), xPath)
                        Catch ex As Exception
                        End Try
                    Next
                    SQL &= String.Format("UPDATE accounting_entry SET ReferenceN = '{0}', PaidFor = 'Balance Transferred', CVNumber = '{2}' WHERE PaidFor = '{2}' AND JVNum = '{1}';", AssetNumber, txtDocumentNumber.Text, DT_Collateral(x)("CollateralNumber"))
                    'SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'CLOSED' WHERE CreditNumber = '{0}';", txtReferenceNumber.Text)
                    DataObject(SQL)
Here_2:
                Next
            End If
        End If
    End Sub

    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If btnDisapprove.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to disapprove this Journal Voucher?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            Dim SQL As String
            SQL = String.Format("UPDATE journal_voucher SET `voucher_status` = 'DISAPPROVED' WHERE ID = '{0}';", ID)
            '*** FINDING THE RIGHT REFERENCE *********************************************************************************************
            Dim ReferenceN As String = ""
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                ReferenceN = txtDocumentNumber.Text
            Else
                If From_ROPOA Or From_Impairment Or From_Ledger Then
                    ReferenceN = txtReferenceNumber.Text
                ElseIf From_ITL Or From_Case Then
                    ReferenceN = txtORNumber.Tag
                ElseIf drv("PaidFrom") = "Loans" Or drv("PaidFrom") = "Official Receipt" Or drv("PaidFrom") = "DTS" Or drv("PaidFrom") = "DTS JV" Or drv("PaidFrom") = "DTS CV" Or drv("PaidFrom").ToString.Contains("Acknowledgement") Or cbxUR.Checked Then
                    ReferenceN = drv("Payee_ID")
                ElseIf drv("PaidFrom") = "Deferred Income" Then
                    ReferenceN = drv("ORNum")
                ElseIf drv("PaidFrom") = "Restructuring" Then
                    ReferenceN = drv("AmountDue")
                ElseIf drv("PaidFrom") = "Journal Voucher" And drv("ORNum") <> "" Then
                    ReferenceN = drv("ORNum")
                ElseIf From_Check Then
                    ReferenceN = DueToID_M
                Else
                    ReferenceN = ValidateComboBox(cbxPayee)
                End If
            End If
            '*** FINDING THE RIGHT REFERENCE *********************************************************************************************

            If drv("PaidFrom").ToString.Contains("Unrealized") Or drv("PaidFrom").ToString.Contains("Deferred") Then
                SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'DISAPPROVED' WHERE CVNumber = '{0}' AND ReferenceN = '{1}' AND IF(PaidFor = 'RPPD-A',TRUE,TRUE);", txtDocumentNumber.Text, drv("Payee_ID"))
            ElseIf drv("PaidFrom") = "Journal Voucher" Then
                SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'DISAPPROVED' WHERE CVNumber = '{0}' AND IF(PaidFor = 'RPPD-A',TRUE,TRUE);", txtDocumentNumber.Text, ValidateComboBox(cbxPayee))
            Else
                SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'DISAPPROVED' WHERE REPLACE(CVNumber,' [Discount]','') = '{0}' AND IF({2} = 1,TRUE,ReferenceN = '{1}') AND IF(PaidFor = 'RPPD-A',TRUE,TRUE);", txtDocumentNumber.Text, ReferenceN, If(drv("PaidFrom").ToString.Contains("DTS CV"), 1, 0))
            End If
            SQL &= String.Format(" UPDATE accounts_receivable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_from SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_to SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE loans_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            If drv("PaidFrom").ToString.Contains("Acknowledgement") Or drv("PaidFrom").ToString.Contains("Unrealized") Then
                SQL &= String.Format(" UPDATE acknowledgement_receipt SET JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                SQL &= String.Format("UPDATE accounting_entry SET JVNumber = '' WHERE ORNum = '{1}' AND JVNumber = '{0}';", txtDocumentNumber.Text, drv("ReferenceN"))

                If drv("PaidFrom") = "Acknowledgement RO" Then
                    Dim CountRemainingACR As Integer = DataObject(String.Format("SELECT COUNT(ID) FROM acknowledgement_receipt WHERE Payee_ID = '{0}' AND Payee_Type = 'RO' AND `status` = 'ACTIVE' AND JVNumber = '' AND DocumentNumber != '{1}';", drv("Payee_ID"), drv("ReferenceN")))
                    If CountRemainingACR = 0 Then
                        SQL &= String.Format("UPDATE sold_ropoa SET `status` = 'ACTIVE' WHERE AssetNumber = '{0}' AND `status` = 'CANCELLED' AND JVNumber = '{1}';", drv("Payee_ID"), txtDocumentNumber.Text)
                        If drv("Payee_ID").ToString.Contains("ANV") Then
                            SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = 'SOLD' WHERE AssetNumber = '{0}';", drv("Payee_ID"))
                        Else
                            SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = 'SOLD' WHERE AssetNumber = '{0}';", drv("Payee_ID"))
                        End If
                    End If
                End If
            ElseIf drv("PaidFrom") = "Official Receipt" Then
                SQL &= String.Format(" UPDATE official_receipt SET JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
                SQL &= String.Format("UPDATE accounting_entry SET JVNumber = '' WHERE ORNum = '{1}' AND REPLACE(JVNumber,' [Discount]','') = '{0}';", txtDocumentNumber.Text, drv("ORNum"))
            ElseIf drv("PaidFrom") = "DTS" Then
                SQL &= String.Format(" UPDATE official_receipt SET DTS_JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "DTS JV" Then
                SQL &= String.Format(" UPDATE journal_voucher SET DTS_JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "DTS CV" Then
                SQL &= String.Format(" UPDATE check_voucher SET DTS_JVNumber = '' WHERE DocumentNumber = '{0}';", drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Liquidation" Then
                SQL &= String.Format(" UPDATE liquidation_main SET JVNumber = '' WHERE ID = '{0}';", Liq_ID)
            ElseIf drv("PaidFrom") = "Accounts Payable" Then
                SQL &= String.Format(" UPDATE accounts_payable SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Accounts Receivable" Then
                SQL &= String.Format(" UPDATE accounts_receivable SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Check Voucher" Then
                SQL &= String.Format(" UPDATE check_voucher SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                '*UPDATE credit_applicat i set ang PaymentRequest para ma release
                SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}';", drv("Payee_ID"))
            ElseIf drv("PaidFrom") = "Journal Voucher" Then
                SQL &= String.Format(" UPDATE journal_voucher SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
                SQL &= String.Format(" UPDATE accounting_entry SET JVNumber = '' WHERE JVNum = '{1}' AND JVNumber = '{0}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Due To" Then
                SQL &= String.Format(" UPDATE due_to SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom") = "Due From" Then
                SQL &= String.Format(" UPDATE due_from SET JVNumber = '' WHERE DocumentNumber = '{1}';", txtDocumentNumber.Text, drv("ReferenceN"))
            ElseIf drv("PaidFrom").ToString.Contains("Loans") Then
                If CVforJV Then
                    SQL &= String.Format("UPDATE credit_application SET `PaymentRequest` = 'PENDING' WHERE CreditNumber = '{0}' AND `PaymentRequest` = 'REQUESTED';", ReferenceN)
                ElseIf txtReferenceNumber.Enabled = False Then
                    SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", txtReferenceNumber.Text)
                End If
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "PaidFor").ToString.Contains("CVE") Or GridView2.GetRowCellValue(x, "PaidFor").ToString.Contains("CRE") Then
                        If GridView2.GetRowCellValue(x, "PaidFor").ToString.Contains("CVE") Then
                            SQL &= String.Format("UPDATE collateral_ve SET Surrendered = 0 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "PaidFor"))
                        Else
                            SQL &= String.Format("UPDATE collateral_re SET Surrendered = 0 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "PaidFor"))
                        End If
                    End If
                Next
            ElseIf drv("PaidFrom") = "Restructuring" Then
                SQL &= String.Format("UPDATE Credit_Application SET JVNumber = '' WHERE CreditNumber = '{0}';", cbxPayee.SelectedValue)
            ElseIf From_Ledger Then
                Dim DT_Details As DataTable = DataSource(String.Format("SELECT PaidFor FROM jv_details WHERE DocumentNumber = '{0}' AND SUBSTRING(PaidFor,1,3) IN ('CVE','CRE') AND `status` = 'ACTIVE';", txtDocumentNumber.Text))
                For x As Integer = 0 To DT_Details.Rows.Count - 1
                    MsgBox(DT_Details(x)("PaidFor").ToString.Substring(0, 2))
                    If DT_Details(x)("PaidFor").ToString.Substring(0, 2) = "CVE" Then
                        SQL &= String.Format("UPDATE collateral_ve SET Surrendered = 0 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE' AND Surrendered = 0;", DT_Details(x)("PaidFor"))
                    Else
                        SQL &= String.Format("UPDATE collateral_re SET Surrendered = 0 WHERE CollateralNumber = '{0}' AND `status` = 'ACTIVE' AND Surrendered = 0;", DT_Details(x)("PaidFor"))
                    End If
                Next
            ElseIf From_Case Then
                SQL &= String.Format("UPDATE case_main SET `status`  = 'DISAPPROVED' WHERE JournalVoucher = '{0}';", txtDocumentNumber.Text)
                SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}' AND PaymentRequest = 'CLOSED';", ReferenceN)
            ElseIf From_Check Then
                SQL &= String.Format("UPDATE dc_details SET `check_status` = 'ON HAND', Remarks = CONCAT(Remarks, ' [', 'DISAPPROVED',']') WHERE ID IN ({0}) AND `status` = 'ACTIVE';", DueToID_M)
                If cbxPayee.Text.Contains("[DT-") Then
                    Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Paid FROM due_to WHERE IF(DC_ID > 0,DC_ID = (SELECT ID FROM due_check WHERE DocumentNumber = (SELECT DocumentNumber FROM dc_details WHERE ID = {0}) AND `status` = 'ACTIVE'),FIND_IN_SET(DocumentNumber,(SELECT DocumentNumber FROM dc_details WHERE ID = {0})));", DueToID_M))
                    For x As Integer = 0 To vDT.Rows.Count - 1
                        SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                    Next
                End If
            ElseIf txtReferenceNumber.Enabled = False Then
                Dim Impairment As Boolean
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Impairment") Then
                        Impairment = True
                        Exit For
                    End If
                Next
                If Impairment = False Then
                    SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = IF(sell_status = 'SELL','RECLASSIFIED','SELL') WHERE AssetNumber = '{0}' AND `status` = 'ACTIVE';", txtReferenceNumber.Text)
                    SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = IF(sell_status = 'SELL','RECLASSIFIED','SELL') WHERE AssetNumber = '{0}' AND `status` = 'ACTIVE';", txtReferenceNumber.Text)
                Else
                    SQL &= String.Format("UPDATE tbl_impairment SET Impairment_Status = 'PENDING', PosteD_Date = '', Reference = '' WHERE AssetNumber = '{1}' AND Reference = '{0}';", txtDocumentNumber.Text, txtReferenceNumber.Text)
                End If
            End If

            DataObject(SQL)
            Logs("Journal Voucher", "Disapprove", Reason, String.Format("Disapprove Journal Voucher of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "")
            LoadPayee()
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Disapproved", MsgBoxStyle.Information, "Info")
            If From_Ledger Then
                With btnDisapprove
                    .DialogResult = DialogResult.OK
                    .DialogResult = DialogResult.OK
                    .PerformClick()
                End With
            End If
        End If
    End Sub

    Private Sub GenerateJV(Show As Boolean, FName As String, CheckedBy As String, ApprovedBy As String)
        Dim Report As New RptJournalVoucher
        With Report
            .Name = String.Format("Journal Voucher of {0} - {1}", cbxPayee.Text, txtDocumentNumber.Text)

            .lblPayee.Text = cbxPayee.Text
            .lblDocumentDate.Text = dtpDocument.Text
            .lblDocumentNumber.Text = txtDocumentNumber.Text
            .lblPostingDate.Text = dtpPostingDate.Text
            .lblReferenceNumber.Text = txtReferenceNumber.Text
            .lblBank.Text = cbxBank.Text
            .lblExplanation.Text = rExplanation.Text

            .DataSource = DT_Account
            .lblAccount.DataBindings.Add("Text", DT_Account, "Account")
            .lblBusinessCenter.DataBindings.Add("Text", DT_Account, "Business Center")
            .lblDepartment.DataBindings.Add("Text", DT_Account, "Department")
            .lblDebit.DataBindings.Add("Text", DT_Account, "Debit")
            .lblCredit.DataBindings.Add("Text", DT_Account, "Credit")
            .lblRemarks.DataBindings.Add("Text", DT_Account, "Remarks")
            .lblDebitT.Text = dDebitT.Text
            .lblCreditT.Text = dCreditT.Text

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

    Private Sub TxtORNumber_TextChanged(sender As Object, e As EventArgs) Handles txtORNumber.TextChanged
        If txtORNumber.Text = "" Then
            dtpORDate.CustomFormat = ""
        Else
            dtpORDate.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub CbxDepartment_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDepartment.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Department Code", cbxDepartment.SelectedValue)
    End Sub

    Private Sub CbxBusinessCenter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBusinessCenter.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "BusinessCode", cbxBusinessCenter.SelectedValue)
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
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
        btnAdd_Account.Enabled = True
        btnExport.Enabled = True
        btnDownload.Enabled = True
        btnRemove_Account.Enabled = True
        GridControl2.Enabled = True
        cbxPayee.Enabled = False
        FirstLoad = True
        cbxLA.Checked = False
        cbxNL.Checked = False
        cbxRO.Checked = False
        cbxACR.Checked = False
        cbxCV.Checked = False
        cbxAP.Checked = False
        cbxAR.Checked = False
        cbxDT.Checked = False
        cbxDF.Checked = False
        cbxOR.Checked = False
        cbxLOE.Checked = False
        cbxJV.Checked = False
        cbxUR.Checked = False
        cbxDI.Checked = False
        cbxRS.Checked = False
        cbxITL.Checked = False
        cbxROPA.Checked = False
        cbxDTS.Checked = False
        GridColumn22.Width = 342
        GridColumn11.Visible = False
        If GridView1.GetFocusedRowCellValue("JVFrom") = "" Then
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Accounts Receivable" Then
            cbxAR.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Accounts Payable" Then
            cbxAP.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Liquidation" Then
            cbxLOE.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Journal Voucher" Then
            cbxJV.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Loans" Then
            cbxLA.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom").Contains("Acknowledgement") Then
            cbxACR.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Check Voucher" Then
            cbxCV.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Due From" Then
            cbxDF.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Due To" Then
            cbxDT.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Official Receipt" Then
            cbxOR.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Unrealized" Then
            cbxUR.Checked = True
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Deferred Income" Then
            cbxDI.Checked = True

            GridColumn22.Width = 342 - 80
            GridColumn11.Visible = True
            GridColumn11.VisibleIndex = 4
        ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "ROPOA" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Impairment" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Ledger" Then
            txtReferenceNumber.Enabled = False
            If GridView1.GetFocusedRowCellValue("JVFrom") = "Ledger" Then
                cbxLA.Checked = True
            End If
        End If
        LoadPayee()
        cbxLA.Enabled = False
        cbxACR.Enabled = False
        cbxCV.Enabled = False
        cbxAP.Enabled = False
        cbxDT.Enabled = False
        cbxDF.Enabled = False
        cbxAR.Enabled = False
        cbxOR.Enabled = False
        cbxLOE.Enabled = False
        cbxJV.Enabled = False
        cbxUR.Enabled = False
        cbxDI.Enabled = False
        cbxRS.Enabled = False
        cbxITL.Enabled = False
        cbxROPA.Enabled = False
        cbxDTS.Enabled = False
        cbxPayee.Enabled = True
        cbxPayee.Text = GridView1.GetFocusedRowCellValue("Payee")
        FirstLoad = False
        cbxBank.SelectedValue = GridView1.GetFocusedRowCellValue("BankID")
        dtpPostingDate.Value = Date.Now
        txtReferenceNumber.Text = GridView1.GetFocusedRowCellValue("Reference Number")
        rExplanation.Text = GridView1.GetFocusedRowCellValue("Explanation")
        DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', BusinessCenter(BusinessCode) AS 'Business Center', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = jv_details.AccountCode) AS 'Account', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit AS 'Debit', Credit AS 'Credit', PaidFor, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, AR_DocumentNumber FROM jv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
        GridControl2.DataSource = DT_Account
        Dim TotalDebit As Double
        Dim TotalCredit As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
        Next
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        Dim OFD As New OpenFileDialog With {
            .Filter = "Excel Files (*.xlsx)|*.xlsx|All Files (*.)|*.*"
        }
        If OFD.ShowDialog = DialogResult.OK Then
            Using con As New OleDb.OleDbConnection()
                Try
                    Cursor = Cursors.WaitCursor
                    DT_Account.Rows.Clear()
                    Dim DT_Excel As DataTable = DT_Account.Copy
                    con.ConnectionString = String.Format("Provider={0};Data Source={1};Extended Properties=""Excel 12.0 XML;HDR=Yes;""", "Microsoft.ACE.OLEDB.12.0", OFD.FileName)
                    Using cmd As New OleDb.OleDbCommand("SELECT * FROM [Sheet$]", con)
                        Using da As New OleDb.OleDbDataAdapter(cmd)
                            con.Open()
                            da.Fill(DT_Excel)
                            con.Close()
                        End Using
                    End Using

                    For x As Integer = 0 To DT_Excel.Rows.Count - 1
                        If DT_Excel(x)("Account Code") = "" Then
                            DT_Excel(x)("Account") = ""
                            DT_Excel(x)("Business Center") = ""
                            DT_Excel(x)("Department") = ""
                            DT_Excel(x)("RequiredRemarks") = ""
                            DT_Excel(x)("Type_ID") = 0
                        Else
                            DT_Excel(x)("Account") = DataObject(String.Format("SELECT AccountTitleCode('{0}')", DT_Excel(x)("Account Code")))
                            If DT_Excel(x)("Business Center") = "" Then
                            Else
                                DT_Excel(x)("Business Center") = DataObject(String.Format("SELECT BusinessCenter('{0}')", If(DT_Excel(x)("Business Code") = "", Branch_Code, DT_Excel(x)("Business Code"))))
                            End If
                            DT_Excel(x)("Department") = DataObject(String.Format("SELECT CONCAT('{0}', ' - ', Department('{0}'))", DT_Excel(x)("Department Code")))
                            DT_Excel(x)("RequiredRemarks") = "False"
                            DT_Excel(x)("MotherCode") = DataObject(String.Format("SELECT MotherCode('{0}')", DT_Excel(x)("Account Code")))
                            DT_Excel(x)("Type_ID") = DataObject(String.Format("SELECT TypeID('{0}')", DT_Excel(x)("Account Code")))
                        End If
                        DT_Account.Rows.Add(DT_Excel(x)("Account Code"), DT_Excel(x)("Department Code"), DT_Excel(x)("Account"), DT_Excel(x)("Business Center"), DT_Excel(x)("Department"), If(DT_Excel(x)("Debit").ToString = "", 0, CDbl(DT_Excel(x)("Debit"))), If(DT_Excel(x)("Credit").ToString = "", 0, CDbl(DT_Excel(x)("Credit"))), DT_Excel(x)("PaidFor"), DT_Excel(x)("Remarks"), DT_Excel(x)("RequiredRemarks"), DT_Excel(x)("Business Code"), DT_Excel(x)("Type_ID"), DT_Excel(x)("MotherCode"), "")
                    Next
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        If (If(DT_Account(x)("Debit").ToString = "", 0, CDbl(DT_Account(x)("Debit"))) > 0 And If(DT_Account(x)("Credit").ToString = "", 0, CDbl(DT_Account(x)("Credit"))) > 0) Or (DT_Account(x)("Account") = "" And (If(DT_Account(x)("Debit").ToString = "", 0, CDbl(DT_Account(x)("Debit"))) > 0 And If(DT_Account(x)("Credit").ToString = "", 0, CDbl(DT_Account(x)("Credit"))) > 0)) Or (DT_Account(x)("RequiredRemarks").ToString = "True" And DT_Account(x)("Remarks") = "") Or (DT_Account(x)("Account") <> "" And DT_Account(x)("Department") = "") Then
                            If MsgBox(String.Format("Import Error Found! Please check your data under row {0}, would you like to proceed?", x + 2), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                            Else
                                DT_Account.Rows.Clear()
                                Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End If
                    Next
                    GridControl2.DataSource = DT_Account

                    Dim TotalDebit As Double
                    Dim TotalCredit As Double
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        TotalDebit += CDbl(DT_Account(x)("Debit"))
                        TotalCredit += CDbl(DT_Account(x)("Credit"))
                    Next
                    If GridView2.RowCount > 7 Then
                        If GridColumn11.Visible = False Then
                            GridColumn22.Width = 342 - 17
                        Else
                            GridColumn22.Width = (342 - 80) - 17
                        End If
                    Else
                        If GridColumn11.Visible = False Then
                            GridColumn22.Width = 342
                        Else
                            GridColumn22.Width = 342 - 80
                        End If
                    End If
                    dDebitT.Value = TotalDebit
                    dCreditT.Value = TotalCredit
                    If GridView2.RowCount > 0 Then
                        btnRemove_Account.Enabled = True
                    Else
                        btnRemove_Account.Enabled = False
                    End If
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                    TriggerBugReport("Journal Voucher - Download", ex.Message.ToString)
                Finally
                    If con IsNot Nothing AndAlso con.State = ConnectionState.Open Then
                        con.Close()
                    End If
                End Try
            End Using
        End If
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If MsgBoxYes("Are you sure you want to export this to Excel Format?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "Import Format" & "-" & Format(Date.Now, "yyyy-MM-dd_HHmmss") & ".xlsx"
            Dim Report As New RptExportToXlsx
            With Report
                Dim DT As New DataTable
                With DT
                    .Columns.Add("Account Code")
                    .Columns.Add("Business Code")
                    .Columns.Add("Department Code")
                    .Columns.Add("Debit")
                    .Columns.Add("Credit")
                    .Columns.Add("Remarks")
                    For x As Integer = 0 To 15
                        .Rows.Add("", "", "", 0, 0, "")
                    Next
                End With
                .DataSource = DT
                .lblAccountCode.DataBindings.Add("Text", DT, "Account Code")
                .lblBusinessCode.DataBindings.Add("Text", DT, "Business Code")
                .lblDepartmentCode.DataBindings.Add("Text", DT, "Department Code")
                .lblDebit.DataBindings.Add("Text", DT, "Debit")
                .lblCredit.DataBindings.Add("Text", DT, "Credit")
                .lblRemarks.DataBindings.Add("Text", DT, "Remarks")
                .ExportToXlsx(FName)
                Process.Start(FName)
            End With

            Dim COA As New RptChartOfAccountsV2
            With COA
                Dim DT As DataTable = DataSource("SELECT IF(Main_ID = 0,`Code`,'') AS 'Code', IF(Main_ID = 0,Title,'') AS 'Mother Account', IF(Main_ID = 0,'',`Code`) AS 'Sub-Account Code', IF(Main_ID = 0,'',Title) AS 'Sub-Account' FROM account_chart WHERE `status` = 'ACTIVE' ORDER BY account_chart.`Code`")
                .DataSource = DT
                .lblMotherCode.DataBindings.Add("Text", DT, "Code")
                .lblMotherAccount.DataBindings.Add("Text", DT, "Mother Account")
                .lblSubcode.DataBindings.Add("Text", DT, "Sub-Account Code")
                .lblSubaccount.DataBindings.Add("Text", DT, "Sub-Account")
                .ShowPreview()
            End With
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CbxPayee_Leave(sender As Object, e As EventArgs) Handles cbxPayee.Leave
        If cbxPayee.SelectedIndex = -1 And cbxPayee.Text = "" Then
            cbxPayee.Text = ReplaceText(cbxPayee.Text)
        End If
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

    Private Sub TxtReferenceNumber_Leave(sender As Object, e As EventArgs) Handles txtReferenceNumber.Leave
        txtReferenceNumber.Text = ReplaceText(txtReferenceNumber.Text)
    End Sub

    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim Rows As New ArrayList()
        Try
            If GridView1.GetFocusedRowCellValue("JVFrom") = "Official Receipt" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Loans" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Restructuring" Or GridView1.GetFocusedRowCellValue("JVFrom") = "DTS" Then
                iLedger.Enabled = True
                iROPA_Ledger.Enabled = False
                iITL_Ledger.Enabled = False
            ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "ROPA" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Acknowledgement RO" Then
                iLedger.Enabled = False
                iROPA_Ledger.Enabled = True
                iITL_Ledger.Enabled = False
            ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "ITL" Then
                iLedger.Enabled = False
                iROPA_Ledger.Enabled = False
                iITL_Ledger.Enabled = True
            Else
                iLedger.Enabled = False
                iROPA_Ledger.Enabled = False
                iITL_Ledger.Enabled = False
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            If GridView1.GetFocusedRowCellValue("JVFrom") = "Official Receipt" Or GridView1.GetFocusedRowCellValue("JVFrom") = "DTS" Then
                .CreditNumber = GridView1.GetFocusedRowCellValue("ReferenceID")
            Else
                If GridView1.GetFocusedRowCellValue("ReferenceID").ToString.Substring(0, 2) = "CA" Then
                    .CreditNumber = GridView1.GetFocusedRowCellValue("ReferenceID")
                Else
                    .CreditNumber = DataObject(String.Format("SELECT CreditNumber FROM credit_released WHERE AccountNumber = '{0}' AND Branch_ID = '{1}' AND `status` = 'ACTIVE';", GridView1.GetFocusedRowCellValue("ReferenceID"), GridView1.GetFocusedRowCellValue("Branch_ID")))
                End If
            End If
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub IROPA_Ledger_Click(sender As Object, e As EventArgs) Handles iROPA_Ledger.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            Else
                If GridView1.GetFocusedRowCellValue("JVFrom") = "ROPA" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Acknowledgement RO" Then
                Else
                    MsgBox("Only ROPA Transaction can open the ROPA Ledger.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim AssetNumber As String = GridView1.GetFocusedRowCellValue("Payee_ID")
        If GridView1.GetFocusedRowCellValue("JVFrom") = "Acknowledgement RO" Then
            AssetNumber = DataObject(String.Format("SELECT Payee_ID FROM acknowledgement_receipt WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("Payee_ID")))
        End If
        Dim DT_AssetDetails As DataTable
        If AssetNumber.Contains("ANV") Then
            DT_AssetDetails = DataSource(String.Format("SELECT Account_Count, PlateNum AS 'Reference' FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND AssetNumber = '{0}';", AssetNumber))
        Else
            DT_AssetDetails = DataSource(String.Format("SELECT Account_Count, TCT AS 'Reference' FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND AssetNumber = '{0}';", AssetNumber))
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
        End If

        Dim History As New FrmROPOALedger
        With History
            .Tag = 53
            .AssetNumber = AssetNumber
            .MultipleA = CInt(DT_AssetDetails(0)("Account_Count")) > 1
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

    Private Sub IITL_Ledger_Click(sender As Object, e As EventArgs) Handles iITL_Ledger.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVFrom") <> "ITL" Then
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
            SQL &= "    IF(Old_Account = 1,Borrower(M.BorrowerID),CONCAT(Borrower_Credit (M.CreditNumber), ' [', AccountNumber(CreditNumber),']')) AS 'Borrower',"
            SQL &= "    M.AccountNumber AS 'Account Number',"
            SQL &= "    M.CaseNumber AS 'Case Number',"
            SQL &= "    DATE_FORMAT(M.DateFilled, '%M %d, %Y') AS 'Date Filled',"
            SQL &= "    Ledger_Balance(M.AccountNumber,M.MortgageID) AS 'Book Value',"
            SQL &= "    M.DecisionValue AS 'Decision Value',"
            SQL &= "    Collateral, AccountNumber(CreditNumber) AS 'AccountNum', (SELECT Mobile_B FROM profile_borrower WHERE profile_borrower.BorrowerID = M.BorrowerID) AS 'Mobile', DueRP, M.CategoryID"
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

    Private Sub CbxBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBank.SelectedIndexChanged
        If FirstLoad Or cbxPayee.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If drv("PaidFrom") = "Restructuring" Then
            FillRestructuring()
        End If
    End Sub

    Private Sub CbxDTS_RS_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDTS_RS.CheckedChanged
        If FirstLoad Or cbxPayee.SelectedIndex = -1 Then
            Exit Sub
        End If

        FillRestructuring()
    End Sub

    Private Sub IRename_Click(sender As Object, e As EventArgs) Handles iRename.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVFrom") = "Accounts Receivable" Or GridView1.GetFocusedRowCellValue("JVFrom").ToString.Contains("Acknowledgement") Or GridView1.GetFocusedRowCellValue("JVFrom") = "Accounts Payable" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Liquidation" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Journal Voucher" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Loans" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Check Voucher" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Due From" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Due To" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Official Receipt" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Unrealized" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Restructuring" Or GridView1.GetFocusedRowCellValue("JVFrom") = "ITL" Or GridView1.GetFocusedRowCellValue("JVFrom") = "ROPA" Or GridView1.GetFocusedRowCellValue("JVFrom") = "DTS" Or GridView1.GetFocusedRowCellValue("JVFrom") = "DTS JV" Or GridView1.GetFocusedRowCellValue("JVFrom") = "DTS CV" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Deferred Income" Or GridView1.GetFocusedRowCellValue("JVFrom") = "ROPOA" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Impairment" Or GridView1.GetFocusedRowCellValue("JVFrom") = "Ledger" Or GridView1.GetFocusedRowCellValue("JVFrom") = "From Check" Then
                MsgBox("Change payee is not applicable on this transaction", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "APPROVED" Then
                MsgBox(String.Format("Check Voucher is already {0}, please check your data.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Rename As New FrmRename
        With Rename
            Dim SQL As String = String.Format(" SELECT ID, ID AS 'Payee_ID', Employee(ID) AS 'Payee','' AS 'ORNum','' AS 'ORDate',0 AS 'Amount', 0 AS 'BankID','E' AS 'PaidFrom',ID AS 'ReferenceN', 0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM employee_setup WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}'", Branch_ID)
            'Supplier
            SQL &= String.Format(" UNION ALL SELECT ID, ID AS 'Payee_ID', Supplier AS 'Payee','' AS 'ORNum','' AS 'ORDate',0 AS 'Amount', 0 AS 'BankID','S' AS 'PaidFrom',ID AS 'ReferenceN', 0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM supplier_setup WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}'", Branch_ID)
            'Branch
            SQL &= String.Format(" UNION ALL SELECT ID, ID AS 'Payee_ID', Branch AS 'Payee','' AS 'ORNum','' AS 'ORDate',0 AS 'Amount', 0 AS 'BankID','B' AS 'PaidFrom',ID AS 'ReferenceN', 0 AS 'Cash Advance', 0 AS 'TotalExpenses', 0 AS 'AmountDue','' AS 'Explanation', '' AS 'BusinessCode' FROM branch WHERE `status` = 'ACTIVE'", Branch_ID)
            SQL &= "    ORDER BY `Payee` ;"
            .cbxPayee.DisplayMember = "Payee"
            .cbxPayee.ValueMember = "ID"
            .cbxPayee.DataSource = DataSource(SQL)
            .Payee = GridView1.GetFocusedRowCellValue("Payee")
            If .ShowDialog = DialogResult.OK Then
                Dim drv As DataRowView = DirectCast(.cbxPayee.SelectedItem, DataRowView)
                SQL = "UPDATE journal_voucher SET"
                SQL &= String.Format(" Payee_ID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" JVFrom = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")))
                SQL &= String.Format(" Payee = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number"))

                SQL &= "UPDATE due_from SET"
                SQL &= String.Format(" PayorID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payor_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")))
                SQL &= String.Format(" Payor = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payor = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee").ToString.InsertQuote)

                SQL &= "UPDATE accounts_receivable SET"
                SQL &= String.Format(" PayorID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payor_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")))
                SQL &= String.Format(" Payor = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payor = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee").ToString.InsertQuote)

                SQL &= "UPDATE due_to SET"
                SQL &= String.Format(" PayeeID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payee_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")))
                SQL &= String.Format(" Payee = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payee = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee").ToString.InsertQuote)

                SQL &= "UPDATE accounts_payable SET"
                SQL &= String.Format(" PayeeID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payee_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")))
                SQL &= String.Format(" Payee = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payee = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee").ToString.InsertQuote)

                SQL &= "UPDATE loans_payable SET"
                SQL &= String.Format(" PayeeID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payee_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("PaidFrom")))
                SQL &= String.Format(" Payee = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payee = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee").ToString.InsertQuote)

                SQL &= "UPDATE accounting_entry SET"
                SQL &= String.Format(" ReferenceN = '{0}' ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" WHERE CVNum = '{0}' AND ReferenceN = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee_ID").ToString.InsertQuote)
                DataObject(SQL)
                LoadData()
                Logs("Check Voucher", "Change Payee", String.Format("Changed Payee Check Voucher from {0} to {1}.", GridView1.GetFocusedRowCellValue("Payee"), .cbxPayee.Text.InsertQuote), "", "", "", "")
                MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        Dim Ledger As New FrmAccountLedger
        With Ledger
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            BankID = drv("BankID")
            .CreditNumber = drv("Payee_ID")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub IJournalVoucher_Click(sender As Object, e As EventArgs) Handles iJournalVoucher.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Journal Voucher is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Journal Voucher is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Journal Voucher is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Journal Voucher is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
        cbxJV.Checked = True
        cbxPayee.SelectedValue = GridView1.GetFocusedRowCellValue("ID")
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If FrmMain.lblDate.Text.Contains("Disconnected") Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Calculator As New FrmLoanApplication
        With Calculator
            .Tag = 26
            FormRestriction(Calculator.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Logs("Journal Voucher", "View Computation", "Amortization Calculators", "", "", "", cbxPayee.SelectedValue)
            .lblTitle.Text = "AMORTIZATION CALCULATOR"
            .ControlBox = True
            .MinimizeBox = False
            .MaximizeBox = False
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .WindowState = FormWindowState.Normal
            .From_CI = True
            .CreditNumber = cbxPayee.SelectedValue
            .PanelEx3.Enabled = False
            .PanelEx3.Visible = False
            .ShowDialog()
            .Dispose()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnReference_Click(sender As Object, e As EventArgs) Handles btnReference.Click
        GridView1.SetFocusedRowCellValue("Reference Number", UpdateReferenceNumber("Journal Voucher", "journal_voucher", GridView1.GetFocusedRowCellValue("Reference Number"), GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Document Number")))
    End Sub

    Private Sub BtnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If MsgBoxYes("Are you sure you want to update the deduction?") = MsgBoxResult.Yes Then
            If FrmMain.lblDate.Text.Contains("Disconnected") Then
                MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
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

                Logs("Journal Voucher", "Open", "Amortization Calculators", "", "", "", drv("Payee_ID"))
                .ControlBox = False
                .FormBorderStyle = FormBorderStyle.FixedDialog
                .WindowState = FormWindowState.Normal
                .From_CI = True
                .From_Request = True
                .CreditNumber = drv("Payee_ID")
                .btnOpen.Visible = True

                .ShowDialog()
                FrmLoanApplication.LoadData()
                .Dispose()

                CbxPayee_SelectedIndexChanged(sender, e)
            End With
        End If
    End Sub
End Class