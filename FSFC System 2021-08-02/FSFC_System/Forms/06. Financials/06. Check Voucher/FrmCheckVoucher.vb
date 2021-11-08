Imports DevExpress.XtraReports.UI
Public Class FrmCheckVoucher

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public FirstLoad As Boolean = True
    Dim User_EmplID As Integer
    Dim DT_Account As New DataTable
    Dim Code As String
    Public From_CA As Boolean
    Public From_Replenishment As Boolean
    Dim Payee_Type As String

    Dim Code_Check As String
    Dim Code_Approve As String
    'For Payment Request **********************
    Public From_PaymentRequest As Boolean
    Public CreditNumber As String
    Public LastRow As Boolean
    Public CIB_Amount As Double
    Public CheckCount As Integer
    Public DefaultBank As Integer
    Public CheckID As Integer
    Public TotalPartial As Double
    'For Payment Release **********************
    Public From_PaymentRelease As Boolean
    Public AccountNumber As String
    'For General Ledger **********************
    Public From_GeneralLedger As Boolean
    'For Accounts Payable
    Public From_AccountsPayable As Boolean
    Public FromDueTo As Boolean
    Public AP_Account As String
    Dim CopyMode As Boolean
    Public AccountsPayableID_M As String
    Public MultipleAP As Boolean
    Dim ROPOA_Status As String

    Public From_Check As Boolean
    Public DueToDocumentNumber As String
    Public CheckAmount As Double
    Public From_PaymentReleasePrint As Boolean
    Public PrintName As String
    Dim Flag As Boolean
    Public Skip_FilterLoadData As Boolean
    ReadOnly Trigger_Send As Integer
    Dim DTS_FromAccount As Boolean
    Private Sub FrmCheckVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView4})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If From_PaymentRequest Or From_AccountsPayable Or From_PaymentRelease Or FromDueTo Or From_Check Or From_CA Or From_Replenishment Then
        Else
            SuperTabControl1.SelectedTab = tabList
            LoadData()
        End If
        cbxDisplay.SelectedIndex = 0
        dtpDocument.Value = Date.Now
        dtpPostingDate.Value = Date.Now
        dtpPostingDate.MaxDate = Date.Now
        dtpCheck.Value = Date.Now

        If From_Check Or (From_PaymentRequest And AccountNumber <> "") Then
            If (From_PaymentRequest And AccountNumber <> "") Then
                cbxPayee.Enabled = False
            End If
        Else
            LoadPayee()
        End If

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

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

        With RepositoryItemSearchLookUpEdit1
            .DisplayMember = "Account"
            .ValueMember = "Account"
        End With

        With RepositoryItemLookUpEdit4
            .DisplayMember = "Department"
            .ValueMember = "Department"
            .DataSource = DT_Department.Copy
        End With

        With cbxAccount
            .DisplayMember = "Account"
            .ValueMember = "Account Code"
        End With

        LoadCompanyMode()

        With cbxDepartment
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
        End With

        With cbxBusinessCenter
            .ValueMember = "BusinessCode"
            .DisplayMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter.Copy
            .SelectedIndex = -1
        End With

        With RepositoryItemLookUpEdit5
            .DisplayMember = "BusinessCenter"
            .ValueMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter_V2.Copy
        End With

        With RepositoryItemLookUpEdit6
            .DisplayMember = "Paid For"
            .ValueMember = "Paid For"
            .DataSource = DataSource("SELECT 'CIB' AS 'Paid For' UNION SELECT 'Billing' UNION SELECT 'Penalty' UNION SELECT 'RPPD' UNION SELECT 'UDI' UNION SELECT 'Principal' UNION SELECT 'Other Income' UNION SELECT ''")
        End With

        Dim DT_Status As DataTable = DataSource("SELECT 'For Checking' AS 'Status' UNION SELECT 'For Approval' UNION SELECT 'For Disbursement' UNION SELECT 'For Clearing' UNION SELECT 'Cleared Check' UNION SELECT 'Cancelled'")
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

        GetDocumentNumber()
        If From_CA Or From_Replenishment Then
            btnNext.Enabled = False
            btnRefresh.Enabled = False
            cbxAP.Checked = False
            cbxAR.Checked = False
            cbxDT.Checked = False
            cbxLA.Checked = False
            If From_Replenishment Then
                cbxRC.Checked = True
            ElseIf From_CA Then
                cbxCAS.Checked = True
            End If
            cbxSUP.Checked = False
            cbxEMP.Checked = False
            cbxLA.Enabled = False
            cbxCAS.Enabled = False
            cbxSUP.Enabled = False
            cbxEMP.Enabled = False
            cbxAP.Enabled = False
            cbxAR.Enabled = False
            cbxDT.Enabled = False
            cbxRC.Enabled = False
            cbxPayee.Enabled = False
            FirstLoad = False
            Dim SQL As String = "SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber'"
            DT_Account = DataSource(SQL)
            cbxPayee.SelectedValue = cbxPayee.Tag
            Exit Sub
        ElseIf From_PaymentRelease Or From_GeneralLedger Or From_PaymentRequest Then
            cbxAll.Checked = True
            LoadData()
            Dim Found As Boolean
            Dim i As Integer = 0
            If From_GeneralLedger Then
                For x As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Document Number") = AccountNumber Then
                        i = x
                        Found = True
                        Exit For
                    End If
                Next
                If Found = False Then
                    MsgBox("No Check Voucher Found!", MsgBoxStyle.Information, "Info")
                    Close()
                End If
                GridView1.OptionsSelection.MultiSelect = False
                GridView1.FocusedRowHandle = i
                GridView1_DoubleClick(sender, e)
                btnRefresh.Enabled = False
                btnNext.Enabled = False
                tabList.Visible = False
            ElseIf From_PaymentRelease Then
                btnRefresh.Enabled = False
                For x As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Document Number") = AccountNumber Then
                        i = x
                        Exit For
                    End If
                Next
                GridView1.OptionsSelection.MultiSelect = False
                GridView1.FocusedRowHandle = i
                GridView1_DoubleClick(sender, e)
            ElseIf From_PaymentRequest And AccountNumber <> "" Then
                btnRefresh.Enabled = False
                For x As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Document Number") = AccountNumber Then
                        i = x
                        Exit For
                    End If
                Next
                GridView1.OptionsSelection.MultiSelect = False
                GridView1.FocusedRowHandle = i
                GridView1_DoubleClick(sender, e)
            ElseIf From_PaymentRequest Then
                cbxPayee.SelectedValue = CreditNumber
                FirstLoad = False
                CbxPayee_SelectedIndexChanged(sender, e)
            End If
            tabList.Visible = False
            FirstLoad = False
            Exit Sub
        ElseIf From_Check Then
            cbxLA.Enabled = False
            cbxCAS.Enabled = False
            cbxSUP.Enabled = False
            cbxEMP.Enabled = False
            cbxAP.Enabled = False
            cbxAR.Enabled = False
            cbxDT.Enabled = False
            cbxRC.Enabled = False
            cbxBank.SelectedValue = DefaultBank
            Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
            cbxPayee.Enabled = False
            tabList.Visible = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False

            Dim AR_Account As String '= DataObject(String.Format("SELECT AccountCode FROM dt_details WHERE DocumentNumber = '{0}' AND Credit > 0 AND `status` = 'ACTIVE' LIMIT 1;", DueToDocumentNumber))
            If DataObject(String.Format("SELECT Payee_Type FROM due_to WHERE DocumentNumber = '{0}';", DueToDocumentNumber)) = "B" Then
                AR_Account = "520001"
            Else
                AR_Account = "520002"
            End If

            Dim SQL As String = "SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber'"
            DT_Account = DataSource(SQL)
            GridControl2.DataSource = DT_Account
            DT_Account.Rows.Clear()
            'DEBIT
            AccountCodeDetails(AR_Account)
            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CheckAmount, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
            'CREDIT
            AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CheckAmount, "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")

            Dim TotalDebit As Double
            Dim TotalCredit As Double
            Dim Total_CIB As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebit += CDbl(DT_Account(x)("Debit"))
                TotalCredit += CDbl(DT_Account(x)("Credit"))
                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                    Total_CIB += CDbl(DT_Account(x)("Credit"))
                End If
            Next
            dDebitT.Value = TotalDebit
            dDebitT.Tag = TotalDebit
            dCreditT.Value = TotalCredit
            dAmount.Value = Total_CIB
            tabList.Visible = False
            FirstLoad = True
            cbxPayee.Text = cbxPayee.Tag
            FirstLoad = False
            Exit Sub
        End If

        LoadData()
        FirstLoad = False
        If From_PaymentRequest Then
            cbxPayee.SelectedValue = CreditNumber
        ElseIf From_AccountsPayable Or FromDueTo Then
            cbxPayee.SelectedValue = AccountNumber
            cbxBank.SelectedValue = DefaultBank
        Else
            cbxPayee.SelectedValue = Empl_ID
            If cbxPayee.Enabled And cbxLA.Checked = False And cbxCAS.Checked = False And cbxSUP.Checked = False And cbxEMP.Checked = False And cbxAP.Checked = False And cbxAR.Checked = False And cbxDT.Checked = False And cbxRC.Checked = False Then
                cbxPayee.SelectedIndex = -1
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
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX2, LabelX13, lblROPOA, LabelX18, LabelIssued, lblROPOAValue, lblSoldPrice, LabelX6, LabelX1, LabelX9, LabelX12, LabelX5, LabelX8, LabelX34, LabelX37, LabelX40, LabelX42, LabelX41, LabelX39})

            GetLabelFontSettingsRed({lblNote})

            GetLabelWithBackgroundFontSettings({LabelX3, LabelX21, LabelX16, LabelX15, LabelX14, LabelX4, LabelX7, LabelX35, LabelX36})

            GetTextBoxFontSettings({txtDocumentNumber, txtReferenceNumber, txtCheckNumber, txtCheck, txtApproved, txtReceived})

            GetCheckBoxFontSettings({cbxLA, cbxCAS, cbxSUP, cbxEMP, cbxAP, cbxAR, cbxDT, cbxRC, cbxDTS, cbxFinancing, cbxAll})

            GetComboBoxFontSettings({cbxPayee, cbxBank, cbxROPOA, cbxPreparedBy, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo, dtpDocument, dtpPostingDate, dtpCheck})

            GetRickTextBoxFontSettings({rExplanation})

            GetDoubleInputFontSettings({dROPOAValue, dROPOAPayable, dDebitT, dCreditT})

            GetDoubleInputFontSettingsDefault({dAmount})

            GetSearchRepositoryFontSettings({RepositoryItemSearchLookUpEdit1})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit5, RepositoryItemLookUpEdit6, RepositoryItemLookUpEdit4})

            GetContextMenuBarFontSettings({ContextMenuBar1, ContextMenuBar3})

            GetButtonFontSettings({btnAdd_Account, btnRemove_Account, btnDownload, btnExport, btnView, btnLedger, btnVerify, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnDisapprove, btnPrint, btnAttach, btnApprove, btnCheck, btnReceive, btnSearch})

            GetTabControlFontSettings({SuperTabControl1})

            GetToolTipFontSettings({ToolTipController1})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Check Voucher - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Check Voucher", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID,"
        SQL &= "    Payee_ID,"
        SQL &= "    Payee,"
        SQL &= "    (SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE ID = check_voucher.BankID) AS 'Bank', BankID, "
        SQL &= "    DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date',"
        SQL &= "    ReferenceNumber AS 'Reference Number',"
        SQL &= "    CheckNumber AS 'Check Number',"
        SQL &= "    DATE_FORMAT(CheckDate,'%M %d, %Y') AS 'Check Date',"
        SQL &= "    Explanation,"
        SQL &= "    Amount,"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID, CheckedID, Payee_Type, MultipleAP, JVNumber, DTS,"
        SQL &= "    BRANCH(branch_id) AS 'Branch', User_EmplID, Branch_ID, IF(ClearedDate = '',IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(JVNumber != '','REVERSED',IF(Voucher_Status = 'APPROVED','FOR DISBURSEMENT',IF(Voucher_Status='PENDING','FOR CHECKING',IF(Voucher_Status='CHECKED','FOR APPROVAL',IF(Voucher_Status='RECEIVED','FOR CLEARING',Voucher_Status)))))),'CLEARED') AS 'Voucher_Status', Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', ReceivedBy, DATE_FORMAT(ReceivedDate,'%M %d, %Y') AS 'ReceivedDate', DATE_FORMAT(ClearedDate,'%M %d, %Y') AS 'Cleared Date', OTAC_Check, OTAC_Approve, Attach, AssetNumber, ROPOA_Value, ROPOA_Payable, DTS_JVNumber"
        SQL &= "  FROM check_voucher WHERE"
        Dim ForChecking As Boolean
        Dim ForApproval As Boolean
        Dim ForDisbursement As Boolean
        Dim ForClearing As Boolean
        Dim ClearedCheck As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Checking" Then
                    ForChecking = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    ForApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Disbursement" Then
                    ForDisbursement = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Clearing" Then
                    ForClearing = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cleared Check" Then
                    ClearedCheck = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForChecking = False And ForApproval = False And ForDisbursement = False And ForClearing = False And ClearedCheck = False Then
                If Cancelled Then
                    SQL &= String.Format(" (`status` IN ({0}) OR voucher_status = 'DISAPPROVED')", If(Cancelled, "'CANCELLED','DELETED','DISAPPROVED'", "''"))
                End If
            Else
                SQL &= String.Format(" `status` IN ('ACTIVE',{0}) AND (voucher_status = 'DISAPPROVED' ", If(Cancelled, "'CANCELLED','DELETED','DISAPPROVED'", "''"))
                If ForChecking Or ForApproval Or ForDisbursement Or ForClearing Or ClearedCheck Then
                    SQL &= " OR "
                End If
                If ForChecking Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'PENDING',TRUE)"
                    If ForApproval Or ForDisbursement Or ForClearing Or ClearedCheck Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'CHECKED',TRUE)"
                    If ForDisbursement Or ForClearing Or ClearedCheck Then
                        SQL &= " OR "
                    End If
                End If
                If ForDisbursement Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'APPROVED',TRUE)"
                    If ForClearing Or ClearedCheck Then
                        SQL &= " OR "
                    End If
                End If
                If ForClearing Then
                    SQL &= " IF(`status` = 'ACTIVE',(voucher_status = 'RECEIVED' AND ClearedDate = ''),TRUE)"
                    If ClearedCheck Then
                        SQL &= " OR "
                    End If
                End If
                If ClearedCheck Then
                    SQL &= " IF(`status` = 'ACTIVE',(voucher_status = 'RECEIVED' AND ClearedDate != ''),TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForChecking = False And ForApproval = False And ForDisbursement = False And ForClearing = False And ClearedCheck = False Then
            Else
                SQL &= " AND ("
                If ForChecking Then
                    SQL &= " voucher_status = 'PENDING'"
                    If ForApproval Or ForDisbursement Or ForClearing Or ClearedCheck Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " voucher_status = 'CHECKED'"
                    If ForDisbursement Or ForClearing Or ClearedCheck Then
                        SQL &= " OR "
                    End If
                End If
                If ForDisbursement Then
                    SQL &= " voucher_status = 'APPROVED'"
                    If ForClearing Or ClearedCheck Then
                        SQL &= " OR "
                    End If
                End If
                If ForClearing Then
                    SQL &= " (voucher_status = 'RECEIVED' AND ClearedDate = '')"
                    If ClearedCheck Then
                        SQL &= " OR "
                    End If
                End If
                If ClearedCheck Then
                    SQL &= " (voucher_status = 'RECEIVED' AND ClearedDate != '')"
                End If
                SQL &= ")"
            End If
        End If
        If Skip_FilterLoadData Then
            SQL &= String.Format("    AND DocumentNumber = '{0}'", AccountNumber)
        End If
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(DocumentDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        If From_PaymentReleasePrint Then
            SQL &= String.Format("  AND DocumentNumber = '{0}'", CreditNumber)
        End If
        If Skip_FilterLoadData = False Then
            SQL &= String.Format("  AND Branch_ID IN ({0}) ORDER BY DocumentNumber DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn16.Visible = True
            GridColumn16.VisibleIndex = 13
        End If
        With GridView1
            .Columns("Payee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Payee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .Columns("Amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Amount").SummaryItem.DisplayFormat = "{0:n2}"
        End With

        If GridView1.RowCount > 19 Then
            GridColumn3.Width = 274 - 17
        Else
            GridColumn3.Width = 274
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GetDocumentNumber()
        If btnSave.Text = "&Save" And From_PaymentRequest = False And From_PaymentRelease = False And From_GeneralLedger = False Then
            txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('CV-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,5,'0')) FROM check_voucher WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))
        End If
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
            txtCheckNumber.Focus()
        End If
    End Sub

    Private Sub TxtCheckNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCheckNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbxROPOA.Visible And cbxROPOA.Enabled Then
                cbxROPOA.Focus()
                cbxROPOA.DroppedDown = True
            Else
                dtpCheck.Focus()
            End If
        End If
    End Sub

    Private Sub CbxROPOA_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxROPOA.KeyDown
        If e.KeyCode = Keys.Enter Then
            dROPOAPayable.Focus()
        End If
    End Sub

    Private Sub DSoldPrice_KeyDown(sender As Object, e As KeyEventArgs) Handles dROPOAPayable.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpCheck.Focus()
        End If
    End Sub

    Private Sub DtpCheck_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpCheck.KeyDown
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
        iTag.Enabled = False
        iViewLedger.Visible = False
        DTS_FromAccount = False
        CopyMode = False
        btnSave.Text = "&Save"
        ROPOA_Status = ""
        MultipleAP = False
        PanelEx10.Enabled = True
        PanelEx2.Enabled = True
        GridView2.OptionsBehavior.Editable = True
        cbxPayee.Enabled = True
        cbxLA.Enabled = True
        cbxCAS.Enabled = True
        cbxSUP.Enabled = True
        cbxEMP.Enabled = True
        cbxAP.Enabled = True
        cbxAR.Enabled = True
        cbxDT.Enabled = True
        cbxRC.Enabled = True
        cbxDTS.Enabled = True

        FirstLoad = True
        cbxLA.Checked = False
        cbxCAS.Checked = False
        cbxSUP.Checked = False
        cbxEMP.Checked = False
        cbxAP.Checked = False
        cbxAR.Checked = False
        cbxDT.Checked = False
        cbxRC.Checked = False
        FirstLoad = False
        cbxDTS.Visible = False
        cbxDTS.Checked = False

        btnAdd_Account.Enabled = True
        btnRemove_Account.Enabled = True
        dtpDocument.Value = Date.Now
        dtpPostingDate.Value = Date.Now
        dtpCheck.Value = Date.Now
        txtReferenceNumber.Text = ""
        txtCheckNumber.Text = ""
        If cbxBank.Enabled Then
            cbxBank.SelectedIndex = -1
        End If
        cbxPayee.Text = ""
        rExplanation.Text = ""
        dAmount.Value = 0
        TotalPartial = 0

        Dim SQL As String = "SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'Paid For', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode', '' AS 'CreditNumber'"
        DT_Account = DataSource(SQL)
        GridControl2.DataSource = DT_Account
        dDebitT.Value = 0
        dCreditT.Value = 0
        If GridView2.RowCount > 7 Then
            If GridColumn30.Visible = False Then
                GridColumn22.Width = 342 - 17
            Else
                GridColumn22.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn30.Visible = False Then
                GridColumn22.Width = 342
            Else
                GridColumn22.Width = 342 - 80
            End If
        End If

        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnCheck.Visible = False
        btnApprove.Visible = False
        btnReceive.Visible = False
        btnVerify.Visible = False

        cbxPreparedBy.SelectedValue = Empl_ID
        txtCheck.Text = ""
        txtApproved.Text = ""
        txtReceived.Text = ""
        txtReceived.Tag = ""
        btnDisapprove.Visible = False
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

            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
            If cbxPayee.Text = "" Then
                MsgBox("Please select/fill Payee.", MsgBoxStyle.Information, "Info")
                cbxPayee.DroppedDown = True
                Exit Sub
            ElseIf cbxPayee.SelectedIndex = -1 And cbxSUP.Checked Then
                MsgBox("Please register your supplier.", MsgBoxStyle.Information, "Info")
                Exit Sub
                'If MsgBoxYes(String.Format("{0} is not yet register, would you like to automatically register {0} as supplier?", cbxPayee.Text)) = MsgBoxResult.Yes Then
                '    Dim SQL_II As String = "INSERT INTO supplier_setup SET"
                '    SQL_II &= String.Format(" Supplier = '{0}', ", cbxPayee.Text.Trim.InsertQuote)
                '    SQL_II &= " Address = '', "
                '    SQL_II &= " TIN = '', "
                '    SQL_II &= " ContactNumber = '', "
                '    SQL_II &= " ContactPerson = '', "
                '    SQL_II &= " EmailAddress = '', "
                '    SQL_II &= String.Format(" User_Code = '{0}', ", User_Code)
                '    SQL_II &= String.Format(" branch_id = '{0}';", Branch_ID)
                '    DataObject(SQL_II)
                '    Dim OldPayee As String = cbxPayee.Text
                '    MsgBox(String.Format("{0} is now registered as supplier.", cbxPayee.Text), MsgBoxStyle.Information, "Info")
                '    FirstLoad = True
                '    LoadPayee()
                '    drv = DirectCast(cbxPayee.SelectedItem, DataRowView)
                '    'cbxPayee.DataSource = DataSource(String.Format("SELECT ID, Supplier, 'S' AS 'Type', TIN, '' AS 'Phone', EmailAddress AS 'EmailAdd', 0 AS 'Amount', VAT, Supplier AS 'Name', '' AS 'PONumber', '' AS 'Explanation', DATE(NOW()) AS 'Due' FROM supplier_setup WHERE `status` = 'ACTIVE' AND branch_id = '{0}';", Branch_ID))
                '    cbxPayee.Text = OldPayee
                '    FirstLoad = False
                'End If
            ElseIf cbxPayee.SelectedIndex = -1 And From_Check = False Then
                MsgBox("Please select/fill Payee.", MsgBoxStyle.Information, "Info")
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
            If cbxFinancing.Checked And cbxFinancing.Visible And cbxROPOA.SelectedIndex = -1 Then
                MsgBox("Please select a ROPOA for financing.", MsgBoxStyle.Information, "Info")
                cbxROPOA.DroppedDown = True
                Exit Sub
            End If
            If cbxFinancing.Checked And cbxFinancing.Visible And dROPOAPayable.Value = 0 Then
                MsgBox("Please fill sold amount for ROPOA.", MsgBoxStyle.Information, "Info")
                dROPOAPayable.Focus()
                Exit Sub
            End If
            If txtCheckNumber.Text = "" Then
                MsgBox("Please fill Check Number.", MsgBoxStyle.Information, "Info")
                txtCheckNumber.Focus()
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
            Dim UntagCreditNumber As Boolean = False
            Dim TheSameCashInBank As Boolean
            Dim CashInBankExist As Boolean
            Dim FoundDTS As Boolean = False
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
                If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "C" And iTag.Enabled Then
                    If (DT_Account(x)("Paid For").ToString = "Principal" Or DT_Account(x)("Paid For").ToString = "UDI") And DT_Account(x)("CreditNumber") = "" Then
                        UntagCreditNumber = True
                    End If
                End If
                If drv_B("AccountCode") = "" Or drv_B("AccountCode") = DT_Account(x)("Account Code") Then
                    TheSameCashInBank = True
                End If
                If DT_Account(x)("MotherCode") = "111000" Then
                    CashInBankExist = True
                End If
                If DT_Account(x)("Account Code") = "217201" Then
                    FoundDTS = True
                End If
            Next
            If TheSameCashInBank = False Then
                If MsgBoxYes(String.Format("Selected Bank is not the same with {0}, would you like to proceed?", If(CashInBankExist, "Selected Cash In Bank", "Entries"))) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            If UntagCreditNumber Then
                If MsgBoxYes("Old account might not properly tagged, please check using right click per accounting entry. Would you like to proceed?") = MsgBoxResult.No Then
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
                MsgBox("No Cash In Bank for Credit, please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If If(cbxPayee.SelectedIndex = -1, False, dAmount.Value <> drv("Amount") And drv("Type") = "A") Then
                MsgBox(String.Format("Cash Advance Amount P{0} is not equal with the CV Amount P{1}", FormatNumber(CDbl(drv("Amount"))), dAmount.Text), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If If(cbxPayee.SelectedIndex = -1, False, dAmount.Value <> drv("Amount") And drv("Type") = "L") Then
                MsgBox(String.Format("For Refund Amount P{0} is not equal with the CV Amount P{1}", FormatNumber(CDbl(drv("Amount"))), dAmount.Text), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim Open As String = DataObject(String.Format("SELECT IF('{2}' = 'Jan',Jan,IF('{2}' = 'Feb',Feb,IF('{2}' = 'Mar',Mar,IF('{2}' = 'Apr',Apr,IF('{2}' = 'May',May,IF('{2}' = 'Jun',Jun,IF('{2}' = 'Jul',Jul,IF('{2}' = 'Aug',Aug,IF('{2}' = 'Sep',Sep,IF('{2}' = 'Oct',`Oct`,IF('{2}' = 'Nov',Nov,IF('{2}' = 'Dec',`Dec`,'X')))))))))))) FROM accounting_period WHERE Branch = '{0}' AND `status` = 'ACTIVE' AND `Year` = '{1}';", Branch_Code, Format(dtpPostingDate.Value, "yyyy"), Format(dtpPostingDate.Value, "MMM")))
            If If(Open = "", "Open", Open) = "Open" Then
            Else
                MsgBox(String.Format("Accounting Period for your branch is already {0}. Transaction with this date is not allowed.", If(Open = "Lock", "Locked", If(Open = "Close", "Closed", Open))), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            Dim drv_R As DataRowView = DirectCast(cbxROPOA.SelectedItem, DataRowView)
            If CDbl(If(cbxPayee.SelectedIndex = -1, 0, drv("Amount"))) > dAmount.Value And If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "RC" Then
                MsgBox(String.Format("Total Expense for Replenishment is {0}, Amount entered is only {1}, please check your data.", FormatNumber(CDbl(drv("Amount")), 2), dAmount.Text), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "AP" And btnSave.Text = "&Save" Then 'FROM ACCOUNTS PAYABLE FOR CHECKING IF WALA GI SOBRA ANG BAYAD 
                If dCreditT.Value > dCreditT.Tag Then
                    MsgBox("Total Credit Cash in Bank is higher than expected payable, please check your data.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
            Dim drv_2 As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
            If If(cbxPayee.SelectedIndex = -1, False, drv("ManualAmortization") = 1 And drv("VerifiedManualAmort") = 0) Then
                MsgBox("Please verify the Amortization Schedule of this Credit Application since it is manually filled up.", MsgBoxStyle.Information, "Info")
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
                    If DocumentNumberExist("check_voucher", txtDocumentNumber.Text) Then
                        Exit Sub
                    End If
                    Dim SQL As String = "INSERT INTO check_voucher SET"
                    SQL &= String.Format(" Payee_ID = '{0}', ", cbxPayee.SelectedValue)
                    SQL &= String.Format(" Payee_Type = '{0}', ", If(cbxPayee.SelectedIndex = -1, "", drv("Type")) & If(MultipleAP, "M", ""))
                    SQL &= String.Format(" Payee = '{0}', ", cbxPayee.Text.InsertQuote)
                    SQL &= String.Format(" DocumentDate = '{0}', ", Format(dtpDocument.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" CheckNumber = '{0}', ", txtCheckNumber.Text)
                    SQL &= String.Format(" CheckDate = '{0}', ", Format(dtpCheck.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote)
                    SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                    SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                    SQL &= " CheckedID = '0', "
                    SQL &= " ApprovedID = '0', "
                    SQL &= " OTAC_Approve = '', "
                    SQL &= " ReceivedBy = '', "
                    If MultipleAP Then
                        SQL &= String.Format(" MultipleAP = '{0}', ", AccountsPayableID_M.ToString.InsertQuote)
                    End If
                    If cbxDTS.Checked Or DTS_FromAccount Or FoundDTS Then
                        SQL &= " DTS = 1, "
                    End If
                    SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                    SQL &= String.Format(" User_Code = '{0}', ", User_Code)
                    SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                    If cbxFinancing.Checked Then
                        SQL &= String.Format(" AssetNumber = '{0}', ", cbxROPOA.SelectedValue)
                        SQL &= String.Format(" ROPOA_Value = '{0}', ", dROPOAValue.Value)
                        SQL &= String.Format(" ROPOA_Payable = '{0}', ", dROPOAPayable.Value)
                        SQL &= String.Format(" ROPOA_Status = '{0}', ", drv_R("Sell_Status"))
                    End If
                    SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)
                    If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                        If From_Check Then
                            SQL &= String.Format("UPDATE dc_details SET `check_status` = 'CLEARED', Remarks = CONCAT(Remarks, ' [', 'CLEARED CHECK',']') WHERE ID = '{0}';", CheckID)
                        End If
                    End If
                    For x As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SQL &= "INSERT INTO cv_details SET"
                            SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" CreditNumber = '{0}', ", GridView2.GetRowCellValue(x, "CreditNumber"))
                            SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "Paid For"))
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            If MultipleAP Then
                                SQL &= String.Format(" ReferenceN = '{0}', ", GridView2.GetRowCellValue(x, "ReferenceN"))
                            End If
                            If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQL &= " Type = 'D';"
                            Else
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQL &= " Type = 'C';"
                            End If

                            If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "AP" Or If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "DT" Then 'FROM ACCOUNTS PAYABLE
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                                Dim SQLv2 As String = ""
                                If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from")) Then
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
                                ElseIf (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to")) Then
                                    Dim APNumber As String = ""
                                    Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))

                                    If drv("Type") = "AP" Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('DT-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_to WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= "INSERT INTO due_to SET"
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

                                        SQLv2 &= "INSERT INTO dt_details SET"
                                        SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                        SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                        SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                        SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                        SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                        SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                        SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                    ElseIf drv("Type") = "DT" Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('AP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= "INSERT INTO accounts_payable SET"
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

                                        SQLv2 &= "INSERT INTO ap_details SET"
                                        SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                        SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                        SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                        SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                        SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                        SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                        SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                    End If
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
                                    SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                    SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                End If
                                If SQLv2 = "" Then
                                Else
                                    DataObject(SQLv2)
                                End If
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                            Else
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                                Dim SQLv2 As String = ""
                                If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from")) Then
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
                                ElseIf (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to")) Then
                                    Dim APNumber As String = ""
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
                                    SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
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
                    Dim TotalAdvance As Double
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        If GridView2.GetRowCellValue(x, "Account").ToString = "" Then
                        Else
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" CVNum = '{0}', ", txtDocumentNumber.Text)
                            If GridView2.GetRowCellValue(x, "CreditNumber").ToString.Trim = "" Then
                                SQL &= String.Format(" ReferenceN = '{0}', ", cbxPayee.SelectedValue)
                            Else
                                SQL &= String.Format(" ReferenceN = '{0}', ", GridView2.GetRowCellValue(x, "CreditNumber"))
                            End If
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                SQL &= " EntryType = 'DEBIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            Else
                                SQL &= " EntryType = 'CREDIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            End If
                            If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "A" Then
                                SQL &= String.Format(" PaidFor = '{0}', ", "Cash Advance")
                            ElseIf If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "C" Then
                                If GridView2.GetRowCellValue(x, "Paid For") = "UDI" And GridView2.GetRowCellValue(x, "CreditNumber") = "" Then
                                    TotalAdvance += CDbl(GridView2.GetRowCellValue(x, "Credit"))
                                ElseIf GridView2.GetRowCellValue(x, "Paid For") = "Principal" And GridView2.GetRowCellValue(x, "CreditNumber") = "" Then
                                    TotalAdvance += CDbl(GridView2.GetRowCellValue(x, "Credit"))
                                End If
                                If GridView2.GetRowCellValue(x, "Paid For").ToString.Trim = "" Then
                                    SQL &= String.Format(" PaidFor = '{0}', ", "Credit Application")
                                Else
                                    SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "Paid For"))
                                End If
                            ElseIf If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "S" Then
                                SQL &= String.Format(" PaidFor = '{0}', ", "Supplier")
                            ElseIf If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "E" Then
                                SQL &= String.Format(" PaidFor = '{0}', ", "Employee")
                            ElseIf If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "RC" Then
                                SQL &= String.Format(" PaidFor = '{0}', ", "Replenishment")
                            Else
                                SQL &= String.Format(" PaidFor = '{0}', ", "Check Voucher")
                            End If
                            SQL &= " `Status` = 'PENDING',"
                            SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                    Next
                    'RPPD
                    If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                    Else
                        If drv("Type") = "C" And TotalAdvance > 0 Then
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
                            SQL &= String.Format(" CVNum = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" ReferenceN = '{0}', ", cbxPayee.SelectedValue)
                            SQL &= " AccountCode = '', " 'Availed
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= String.Format(" Payable = '{0}', ", RPPD)
                            SQL &= String.Format(" Amount = '{0}', ", RPPD)
                            SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                            SQL &= " `Status` = 'PENDING',"
                            SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" Remarks = '{0}', ", "")
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                    End If
                    'RPPD
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "C" Then 'FROM CREDIT APPLICATION
                        Dim drv_3 As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                        SQL &= " UPDATE check_received SET"
                        SQL &= String.Format(" Bank = '{0}', ", drv_3("Bank_1"))
                        SQL &= String.Format(" Branch = '{0}', ", drv_3("Branch"))
                        SQL &= String.Format(" `Check` = '{0}', ", txtCheckNumber.Text)
                        SQL &= String.Format(" `Date` = '{0}', ", Format(dtpCheck.Value, "yyyy-MM-dd"))
                        SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                        SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                        SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" CVDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                        SQL &= String.Format(" CVNumber_2 = '{0}' ", txtDocumentNumber.Text)
                        SQL &= String.Format(" WHERE `status` IN ('PENDING','ACTIVE') AND AssetNumber = '{0}' AND check_type = 'P' AND ID = '{1}';", cbxPayee.SelectedValue, CheckID)
                        SQL &= String.Format(" UPDATE credit_application SET `PaymentRequest` = 'REQUESTED', BankID = {1} WHERE CreditNumber = '{0}' AND `PaymentRequest` != 'RELEASED';", cbxPayee.SelectedValue, ValidateComboBox(cbxBank))
                    End If
                    If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "A" Then 'FROM CASH ADVANCE
                        SQL &= String.Format(" UPDATE cash_advance SET CVNumber = '{1}' WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue, txtDocumentNumber.Text)
                    End If
                    If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "L" Then 'FROM LIQUIDATION
                        SQL &= String.Format(" UPDATE liquidation_main SET Refund = 1 WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue)
                    End If
                    If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "RC" Then 'FROM REPLENISHMENT
                        SQL &= String.Format(" UPDATE replenishment_cash SET CVNumber = '{1}', ReplenishStatus = 'REPLENISHED' WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, txtDocumentNumber.Text)
                    End If
                    If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "AP" Then 'FROM ACCOUNTS PAYABLE
                        If MultipleAP Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount - Paid AS 'Payable' FROM accounts_payable WHERE DocumentNumber IN ({0});", AccountsPayableID_M))
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
                            SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, dDebitT.Value)
                        End If
                    End If
                    If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "AR" Then 'FROM ACCOUNTS RECEIVABLE
                        If MultipleAP Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount - Paid AS 'Payable' FROM accounts_receivable WHERE DocumentNumber IN ({0});", AccountsPayableID_M))
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
                            SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", drv("ID"), dDebitT.Value)
                        End If
                    End If
                    If If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "DT" Then 'FROM DUE TO
                        If MultipleAP Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount - Paid AS 'Payable' FROM due_to WHERE DocumentNumber IN ({0});", AccountsPayableID_M))
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
                        Else
                            SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Amount <= (Paid + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = Paid + {1} WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, dDebitT.Value)
                        End If
                    End If
                    If cbxFinancing.Checked Then
                        If drv_R("Sell_Status") = "SELL" Then
                            'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************
                            SQL &= String.Format("UPDATE tbl_impairment SET impairment_status = 'CANCELLED' WHERE impairment_status = 'PENDING' AND `status` = 'ACTIVE' AND ReferenceN = '{0}';", drv("Reference"))
                            'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************
                            Dim DT_Borrower As DataTable = DataSource(String.Format("SELECT Prefix_B, FirstN_B, MiddleN_B, LastN_B, Suffix_B, NoC_B, StreetC_B, BarangayC_B, AddressC_B, Mobile_B FROM credit_application WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", cbxPayee.SelectedValue))
                            SQL &= "INSERT INTO sold_ropoa SET"
                            SQL &= String.Format(" AssetNumber = '{0}', ", cbxROPOA.SelectedValue)
                            SQL &= String.Format(" Prefix_B = '{0}', ", DT_Borrower(0)("Prefix_B"))
                            SQL &= String.Format(" FirstN_B = '{0}', ", DT_Borrower(0)("FirstN_B"))
                            SQL &= String.Format(" MiddleN_B = '{0}', ", DT_Borrower(0)("MiddleN_B"))
                            SQL &= String.Format(" LastN_B = '{0}', ", DT_Borrower(0)("LastN_B"))
                            SQL &= String.Format(" Suffix_B = '{0}', ", DT_Borrower(0)("Suffix_B"))
                            SQL &= String.Format(" NoC_B = '{0}', ", DT_Borrower(0)("NoC_B"))
                            SQL &= String.Format(" StreetC_B = '{0}', ", DT_Borrower(0)("StreetC_B"))
                            SQL &= String.Format(" BarangayC_B = '{0}', ", DT_Borrower(0)("BarangayC_B"))
                            SQL &= String.Format(" AddressC_B = '{0}', ", DT_Borrower(0)("AddressC_B"))
                            SQL &= String.Format(" Contact_N = '{0}', ", DT_Borrower(0)("Mobile_B"))
                            SQL &= String.Format(" Amount = '{0}', ", dROPOAPayable.Value)
                            SQL &= String.Format(" user_id = '{0}', ", User_ID)
                            SQL &= String.Format(" reserved_days = '{0}', ", 0)
                            SQL &= String.Format(" Remarks = '{0}', ", rExplanation.Text.Substring(1, 149))
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If

                        If cbxROPOA.SelectedValue.ToString.Contains("ANV") Then
                            SQL &= String.Format(" UPDATE ropoa_vehicle SET sell_status = '{1}' WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", drv("Reference"), If(dAmount.Value >= dROPOAPayable.Value, "SOLD", "RESERVED"))
                        Else
                            SQL &= String.Format(" UPDATE ropoa_realestate SET sell_status = '{1}' WHERE TCT = '{0}' AND `status` = 'ACTIVE';", drv("Reference"), If(dAmount.Value >= dROPOAPayable.Value, "SOLD", "RESERVED"))
                        End If
                    End If
                    DataObject(SQL)

                    Cursor = Cursors.Default
                    Logs("Check Voucher", "Save", String.Format("Add new Check Voucher for {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "", "")
                    MsgBox("Successfully Saved!" & mEmail, MsgBoxStyle.Information, "Info")

                    If From_PaymentRequest Or From_AccountsPayable Or FromDueTo Or From_Check Or From_CA Or From_Replenishment Then
                        With btnSave
                            .DialogResult = DialogResult.OK
                            .DialogResult = DialogResult.OK
                            .PerformClick()
                        End With
                    Else
                        Clear(True)
                    End If
                    LoadPayee()
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM check_voucher WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
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

                    Dim SQL As String = "UPDATE check_voucher SET"
                    SQL &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" ReferenceNumber = '{0}', ", txtReferenceNumber.Text)
                    SQL &= String.Format(" CheckNumber = '{0}', ", txtCheckNumber.Text)
                    SQL &= String.Format(" CheckDate = '{0}', ", Format(dtpCheck.Value, "yyyy-MM-dd"))
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote)
                    If cbxFinancing.Checked Then
                        SQL &= String.Format(" AssetNumber = '{0}', ", cbxROPOA.SelectedValue)
                        SQL &= String.Format(" ROPOA_Value = '{0}', ", dROPOAValue.Value)
                        SQL &= String.Format(" ROPOA_Payable = '{0}', ", dROPOAPayable.Value)
                        SQL &= String.Format(" ROPOA_Status = '{0}', ", drv_R("Sell_Status"))
                    End If
                    If txtCheck.Text = "" Then
                        SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                    ElseIf txtApproved.Text = "" Then
                        SQL &= String.Format(" OTAC_Approve = '{0}', ", Code)
                    End If
                    SQL &= String.Format(" Amount = '{0}' ", dAmount.Value)
                    SQL &= String.Format(" WHERE ID = '{0}';", ID)

                    SQL &= String.Format(" UPDATE cv_details SET `status` = 'CANCELLED' WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    Dim SQLv3 As String = String.Format(" UPDATE accounts_receivable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE accounts_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE due_from SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE due_to SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    SQLv3 &= String.Format(" UPDATE loans_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                    DataObject(SQLv3)
                    For x As Integer = 0 To GridView2.RowCount - 1
                        If GridView2.GetRowCellValue(x, "Account").ToString = "" Then
                        Else
                            SQL &= "INSERT INTO cv_details SET"
                            SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" CreditNumber = '{0}', ", GridView2.GetRowCellValue(x, "CreditNumber"))
                            SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "Paid For"))
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            If MultipleAP Then
                                SQL &= String.Format(" ReferenceN = '{0}', ", GridView2.GetRowCellValue(x, "ReferenceN"))
                            End If
                            If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQL &= " Type = 'D';"
                            Else
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQL &= " Type = 'C';"
                            End If

                            If drv("Type") = "AP" Or drv("Type") = "DT" Then 'FROM ACCOUNTS PAYABLE
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                                Dim SQLv2 As String = ""
                                If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from")) Then
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
                                    SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                    SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                ElseIf (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to")) Then
                                    Dim APNumber As String = ""
                                    Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))

                                    If drv("Type") = "AP" Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('DT-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_to WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= "INSERT INTO due_to SET"
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

                                        SQLv2 &= "INSERT INTO dt_details SET"
                                        SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                        SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                        SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                        SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                        SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                        SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                        SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                    ElseIf drv("Type") = "DT" Then
                                        APNumber = DataObject(String.Format("SELECT CONCAT('AP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                        SQLv2 &= "INSERT INTO accounts_payable SET"
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

                                        SQLv2 &= "INSERT INTO ap_details SET"
                                        SQLv2 &= String.Format(" DocumentNumber = '{0}', ", APNumber)
                                        SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                                        SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                                        SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                                        SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                                        SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                        SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                        SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                    End If
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
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                    SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                End If
                                If SQLv2 = "" Then
                                Else
                                    DataObject(SQLv2)
                                End If
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                            Else
                                'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                                Dim SQLv2 As String = ""
                                If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from")) Then
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
                                    SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                    SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                                ElseIf (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to")) Then
                                    Dim APNumber As String = ""
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
                                    SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
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
                    SQL &= String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE CVNumber = '{0}';", txtDocumentNumber.Text, cbxPayee.SelectedValue, If(drv("Type") = "C", "", Format(dtpPostingDate.Value, "yyyy-MM-dd")))
                    Dim TotalAdvance As Double
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        If GridView2.GetRowCellValue(x, "Account") = "" Then
                        Else
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" CVNum = '{0}', ", txtDocumentNumber.Text)
                            If GridView2.GetRowCellValue(x, "CreditNumber").ToString.Trim = "" Then
                                SQL &= String.Format(" ReferenceN = '{0}', ", cbxPayee.SelectedValue)
                            Else
                                SQL &= String.Format(" ReferenceN = '{0}', ", GridView2.GetRowCellValue(x, "CreditNumber"))
                            End If
                            SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            If CDbl(GridView2.GetRowCellValue(x, "Debit")) <> 0 Then
                                SQL &= " EntryType = 'DEBIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            Else
                                SQL &= " EntryType = 'CREDIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            End If
                            If drv("Type") = "A" Then
                                SQL &= String.Format(" PaidFor = '{0}', ", "Cash Advance")
                            ElseIf If(cbxPayee.SelectedIndex = -1, "", drv("Type")) = "C" Then
                                If GridView2.GetRowCellValue(x, "Paid For") = "UDI" And GridView2.GetRowCellValue(x, "CreditNumber") = "" Then
                                    TotalAdvance += CDbl(GridView2.GetRowCellValue(x, "Credit"))
                                ElseIf GridView2.GetRowCellValue(x, "Paid For") = "Principal" And GridView2.GetRowCellValue(x, "CreditNumber") = "" Then
                                    TotalAdvance += CDbl(GridView2.GetRowCellValue(x, "Credit"))
                                End If
                                If GridView2.GetRowCellValue(x, "Paid For").ToString.Trim = "" Then
                                    SQL &= String.Format(" PaidFor = '{0}', ", "Credit Application")
                                Else
                                    SQL &= String.Format(" PaidFor = '{0}', ", GridView2.GetRowCellValue(x, "Paid For"))
                                End If
                            ElseIf drv("Type") = "S" Then
                                SQL &= String.Format(" PaidFor = '{0}', ", "Supplier")
                            ElseIf drv("Type") = "E" Then
                                SQL &= String.Format(" PaidFor = '{0}', ", "Employee")
                            ElseIf drv("Type") = "RC" Then
                                SQL &= String.Format(" PaidFor = '{0}', ", "Replenishment")
                            Else
                                SQL &= String.Format(" PaidFor = '{0}', ", "Check Voucher")
                            End If
                            SQL &= " `Status` = 'PENDING',"
                            SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                    Next
                    'RPPD
                    If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                    Else
                        If drv("Type") = "C" And TotalAdvance > 0 Then
                            Dim RPPD As Double
                            'RPPD = DataObject(String.Format("SELECT IF(RPPD = 0,0,Rebate * FLOOR({1} / (GMA - Rebate))) FROM credit_application WHERE CreditNumber = '{0}';", cbxPayee.SelectedValue, TotalAdvance))
                            Dim DistributeTotalAdvance As Double = TotalAdvance
                            For y As Integer = 1 To GridView4.RowCount - 1
                                If DistributeTotalAdvance > 0 Then
                                    If DistributeTotalAdvance >= CDbl(GridView4.GetRowCellValue(y, "Monthly")) Then
                                        RPPD += CDbl(GridView4.GetRowCellValue(y, "RPPD"))
                                        DistributeTotalAdvance -= CDbl(GridView4.GetRowCellValue(y, "Monthly"))
                                    End If
                                End If
                            Next
                            SQL &= "INSERT INTO accounting_entry SET"
                            SQL &= String.Format(" CVNum = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" ReferenceN = '{0}', ", cbxPayee.SelectedValue)
                            SQL &= " AccountCode = '', " 'Availed
                            SQL &= " MotherCode = '', " 'Availed
                            SQL &= " EntryType = 'CREDIT',"
                            SQL &= String.Format(" Payable = '{0}', ", RPPD)
                            SQL &= String.Format(" Amount = '{0}', ", RPPD)
                            SQL &= String.Format(" PaidFor = '{0}', ", "RPPD-A")
                            SQL &= " `Status` = 'PENDING',"
                            SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                            SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                            SQL &= String.Format(" Remarks = '{0}', ", "")
                            SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If
                    End If
                    'RPPD
                    'ACCOUNTING ENTRY ***********************************************************************************************************
                    If drv("Type") = "C" Then 'FROM CREDIT APPLICATION
                        Dim drv_3 As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                        SQL &= " UPDATE check_received SET"
                        SQL &= String.Format(" Bank = '{0}', ", drv_3("Bank_1"))
                        SQL &= String.Format(" Branch = '{0}', ", drv_3("Branch"))
                        SQL &= String.Format(" `Check` = '{0}', ", txtCheckNumber.Text)
                        SQL &= String.Format(" `Date` = '{0}', ", Format(dtpCheck.Value, "yyyy-MM-dd"))
                        SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                        SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                        SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" CVDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                        SQL &= String.Format(" CVNumber_2 = '{0}' ", txtDocumentNumber.Text)
                        SQL &= String.Format(" WHERE `status` IN ('PENDING','ACTIVE') AND AssetNumber = '{0}' AND check_type = 'P' AND ID = '{1}';", cbxPayee.SelectedValue, CheckID)
                    End If
                    If drv("Type") = "AP" Then 'FROM ACCOUNTS PAYABLE
                        If MultipleAP Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim AcknowledgedAmount As Double
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount, Paid, IFNULL((SELECT SUM(Amount) FROM check_voucher WHERE Payee_ID = accounts_payable.DocumentNumber AND DocumentNumber != '{1}' AND Payee_Type = 'AP' AND `status` = 'ACTIVE'),0) AS 'Other Payment', (SELECT SUM(Amount) FROM cv_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_payable.DocumentNumber AND `status` = 'ACTIVE' AND Type = 'C') AS 'Acknowledged' FROM accounts_payable WHERE DocumentNumber IN ({0});", AccountsPayableID_M, txtDocumentNumber.Text))
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
                            SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, dDebitT.Value, dDebitT.Tag)
                        End If
                    End If
                    If drv("Type") = "AR" Then 'FROM ACCOUNTS PAYABLE
                        If MultipleAP Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim AcknowledgedAmount As Double
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount, Paid, IFNULL((SELECT SUM(Amount) FROM acknowledgement_receipt WHERE Payee_ID = accounts_receivable.ID AND DocumentNumber != '{1}' AND Payee_Type = 'AR' AND `status` = 'ACTIVE'),0) AS 'Other Payment', (SELECT SUM(Debit) FROM acr_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_receivable.DocumentNumber AND `status` = 'ACTIVE') AS 'Acknowledged' FROM accounts_receivable WHERE DocumentNumber IN ({0});", AccountsPayableID_M, txtDocumentNumber.Text))
                            For x As Integer = 0 To vDT.Rows.Count - 1
                                AcknowledgedAmount = CDbl(vDT(x)("Acknowledged"))
                                If (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = CDbl(vDT(x)("Paid")) And CDbl(vDT(x)("Paid")) >= CDbl(vDT(x)("Acknowledged")) Then
                                    AcknowledgedAmount = CDbl(vDT(x)("Paid"))
                                End If
                                If TotalPayment - (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = 0 Then
                                    SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))), AcknowledgedAmount)
                                    TotalPayment -= TotalPayment
                                ElseIf TotalPayment - CDbl(CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) > 0 Then
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
                            SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", drv("ID"), dDebitT.Value, dDebitT.Tag)
                        End If
                    End If
                    If drv("Type") = "DT" Then 'FROM DUE TO
                        If MultipleAP Then
                            Dim TotalPayment As Double = dDebitT.Value
                            Dim AcknowledgedAmount As Double
                            Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, Amount, Paid, IFNULL((SELECT SUM(Amount) FROM check_voucher WHERE Payee_ID = due_to.DocumentNumber AND DocumentNumber != '{1}' AND Payee_Type = 'DT' AND `status` = 'ACTIVE'),0) AS 'Other Payment', (SELECT SUM(Amount) FROM cv_details WHERE DocumentNumber = '{1}' AND ReferenceN = due_to.DocumentNumber AND `status` = 'ACTIVE' AND Type = 'C') AS 'Acknowledged' FROM due_to WHERE DocumentNumber IN ({0});", AccountsPayableID_M, txtDocumentNumber.Text))
                            For x As Integer = 0 To vDT.Rows.Count - 1
                                AcknowledgedAmount = CDbl(vDT(x)("Acknowledged"))
                                If (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = CDbl(vDT(x)("Paid")) And CDbl(vDT(x)("Paid")) >= CDbl(vDT(x)("Acknowledged")) Then
                                    AcknowledgedAmount = CDbl(vDT(x)("Paid"))
                                End If
                                If TotalPayment - (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))) = 0 Then
                                    SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))), AcknowledgedAmount)
                                    TotalPayment -= TotalPayment
                                ElseIf TotalPayment - CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment")) > 0 Then
                                    SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment"))), AcknowledgedAmount)
                                    TotalPayment -= (CDbl(vDT(x)("Amount")) - CDbl(vDT(x)("Other Payment")))
                                Else
                                    If TotalPayment <= 0 Then
                                        SQL &= String.Format(" UPDATE due_to SET AP_Status = 'APPROVED', Paid = 0 WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"))
                                    Else
                                        SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), TotalPayment, AcknowledgedAmount)
                                        TotalPayment -= TotalPayment
                                    End If
                                End If
                            Next
                        Else
                            SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Amount <= (IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1}),'FULLY PAID','PARTIALLY PAID'), Paid = IF((Paid - {2}) <= 0,0,(Paid - {2})) + {1} WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, dDebitT.Value, dDebitT.Tag)
                        End If
                    End If
                    If cbxFinancing.Checked Then
                        If drv_R("Sell_Status") = "SELL" And ROPOA_Status = "" Then
                            'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************
                            SQL &= String.Format("UPDATE tbl_impairment SET impairment_status = 'CANCELLED' WHERE impairment_status = 'PENDING' AND `status` = 'ACTIVE' AND ReferenceN = '{0}';", drv("Reference"))
                            'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************
                            Dim DT_Borrower As DataTable = DataSource(String.Format("SELECT Prefix_B, FirstN_B, MiddleN_B, LastN_B, Suffix_B, NoC_B, StreetC_B, BarangayC_B, AddressC_B, Mobile_B FROM credit_application WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", cbxPayee.SelectedValue))
                            SQL &= "INSERT INTO sold_ropoa SET"
                            SQL &= String.Format(" AssetNumber = '{0}', ", cbxROPOA.SelectedValue)
                            SQL &= String.Format(" Prefix_B = '{0}', ", DT_Borrower(0)("Prefix_B"))
                            SQL &= String.Format(" FirstN_B = '{0}', ", DT_Borrower(0)("FirstN_B"))
                            SQL &= String.Format(" MiddleN_B = '{0}', ", DT_Borrower(0)("MiddleN_B"))
                            SQL &= String.Format(" LastN_B = '{0}', ", DT_Borrower(0)("LastN_B"))
                            SQL &= String.Format(" Suffix_B = '{0}', ", DT_Borrower(0)("Suffix_B"))
                            SQL &= String.Format(" NoC_B = '{0}', ", DT_Borrower(0)("NoC_B"))
                            SQL &= String.Format(" StreetC_B = '{0}', ", DT_Borrower(0)("StreetC_B"))
                            SQL &= String.Format(" BarangayC_B = '{0}', ", DT_Borrower(0)("BarangayC_B"))
                            SQL &= String.Format(" AddressC_B = '{0}', ", DT_Borrower(0)("AddressC_B"))
                            SQL &= String.Format(" Contact_N = '{0}', ", DT_Borrower(0)("Mobile_B"))
                            SQL &= String.Format(" Amount = '{0}', ", dROPOAPayable.Value)
                            SQL &= String.Format(" user_id = '{0}', ", User_ID)
                            SQL &= String.Format(" reserved_days = '{0}', ", 0)
                            SQL &= String.Format(" Remarks = '{0}', ", rExplanation.Text.Substring(1, 149))
                            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        End If

                        If cbxROPOA.SelectedValue.ToString.Contains("ANV") Then
                            SQL &= String.Format(" UPDATE ropoa_vehicle SET sell_status = '{1}' WHERE PlateNum = '{0}' AND `status` = 'ACTIVE';", drv("Reference"), If(dAmount.Value >= dROPOAPayable.Value, "SOLD", "RESERVED"))
                        Else
                            SQL &= String.Format(" UPDATE ropoa_realestate SET sell_status = '{1}' WHERE TCT = '{0}' AND `status` = 'ACTIVE';", drv("Reference"), If(dAmount.Value >= dROPOAPayable.Value, "SOLD", "RESERVED"))
                        End If
                    End If
                    DataObject(SQL)

                    Logs("Check Voucher", "Update", Reason, Changes(), "", "", "")
                    If From_PaymentRequest Then
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.DialogResult = DialogResult.OK
                        btnSave.PerformClick()
                    Else
                        Clear(True)
                    End If
                    LoadPayee()
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
                Change &= String.Format("Change Posting Date from {0} to {1}. ", dtpPostingDate.Tag, dtpPostingDate.Text)
            End If
            If txtReferenceNumber.Text = txtReferenceNumber.Tag Then
            Else
                Change &= String.Format("Change Reference Number from {0} to {1}. ", txtReferenceNumber.Tag, txtReferenceNumber.Text)
            End If
            If txtCheckNumber.Text = txtCheckNumber.Tag Then
            Else
                Change &= String.Format("Change Check Number from {0} to {1}. ", txtCheckNumber.Tag, txtCheckNumber.Text)
            End If
            If dtpCheck.Text = dtpCheck.Tag Then
            Else
                Change &= String.Format("Change Check Date from {0} to {1}. ", dtpCheck.Tag, dtpCheck.Text)
            End If
            If cbxBank.Text = cbxBank.Tag Then
            Else
                Change &= String.Format("Change Bank from {0} to {1}. ", cbxBank.Tag, cbxBank.Text)
            End If
            If rExplanation.Text = rExplanation.Tag Then
            Else
                Change &= String.Format("Change Explanation from {0} to {1}. ", rExplanation.Tag, rExplanation.Text)
            End If
            If dAmount.Text = dAmount.Tag Then
            Else
                Change &= String.Format("Change Total Cash on Bank from {0} to {1}. ", dAmount.Tag, dAmount.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Check Voucher - Changes", ex.Message.ToString)
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
            btnPrint.Enabled = False

            PanelEx10.Enabled = True
            PanelEx2.Enabled = True
            GridView2.OptionsBehavior.Editable = True
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If btnDelete.DialogResult = DialogResult.Yes Then
        Else
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
                Dim SQL As String = String.Format("UPDATE check_voucher SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID)
                SQL &= String.Format(" UPDATE accounts_receivable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQL &= String.Format(" UPDATE due_from SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQL &= String.Format(" UPDATE due_to SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQL &= String.Format(" UPDATE loans_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)

                If Payee_Type = "C" Then 'FROM CREDIT APPLICATION
                    If CheckID = 0 Then
                        CheckID = DataObject(String.Format("SELECT ID FROM check_received WHERE `status` IN ('PENDING','ACTIVE') AND AssetNumber = '{0}' AND check_type = 'P' AND CVNumber_2 = '{1}';", cbxPayee.SelectedValue, txtDocumentNumber.Text))
                    End If
                    SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE CVNumber = '{0}';", txtDocumentNumber.Text, cbxPayee.SelectedValue)
                    SQL &= String.Format(" UPDATE check_received SET Bank = '', Branch = '', `Check` = '', Amount = 0, CVNumber = '', CVDate = '', CVNumber_2 = ''  WHERE `status` IN ('PENDING','ACTIVE') AND AssetNumber = '{0}' AND check_type = 'P' AND ID = '{1}';", cbxPayee.SelectedValue, CheckID)
                    SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'REQUEST' WHERE CreditNumber = '{0}';", cbxPayee.SelectedValue)
                    SQL &= String.Format(" UPDATE credit_deductbalance SET `deduct_status` = 'PENDING'  WHERE `status` = 'ACTIVE' AND CreditNumber_F = '{0}';", cbxPayee.SelectedValue)
                Else
                    SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE CVNumber = '{0}' AND ReferenceN = '{1}';", txtDocumentNumber.Text, cbxPayee.SelectedValue)
                End If
                If Payee_Type = "A" Then 'FROM CASH ADVANCE
                    SQL &= String.Format(" UPDATE cash_advance SET slip_status = 'APPROVED', ReceivedID = 0, ReceivedDate = '', CVNumber = '' WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue)
                End If
                If Payee_Type = "L" Then 'FROM LIQUIDATION
                    SQL &= String.Format(" UPDATE liquidation_main SET Refund = 0 WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue)
                End If
                If Payee_Type = "RC" Then 'FROM REPLENISHMENT
                    SQL &= String.Format(" UPDATE replenishment_cash SET CVNumber = '', ReplenishStatus = 'PENDING' WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, txtDocumentNumber.Text)
                End If
                If Payee_Type = "AP" Then 'FROM ACCOUNTS PAYABLE
                    If MultipleAP Then
                        Dim vDT As New DataTable
                        vDT = DataSource(String.Format("SELECT DocumentNumber, (SELECT SUM(Amount) FROM cv_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_payable.DocumentNumber AND `status` = 'ACTIVE' AND Type = 'C') AS 'Paid' FROM accounts_payable WHERE DocumentNumber IN ({0});", AccountsPayableID_M, txtDocumentNumber.Text))
                        For x As Integer = 0 To vDT.Rows.Count - 1
                            SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                        Next
                    Else
                        SQL &= String.Format(" UPDATE accounts_payable SET Paid = IF(Paid - {1} <= 0, 0,Paid - {1}), AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, dDebitT.Value)
                    End If
                End If
                If Payee_Type = "AR" Or Payee_Type = "ARM" Then 'FROM ACCOUNTS PAYABLE
                    If MultipleAP Then
                        Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, (SELECT SUM(Debit) FROM acr_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_receivable.DocumentNumber AND `status` = 'ACTIVE') AS 'Paid' FROM accounts_receivable WHERE DocumentNumber IN ({0});", AccountsPayableID_M, txtDocumentNumber.Text))
                        For x As Integer = 0 To vDT.Rows.Count - 1
                            SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                        Next
                    Else
                        SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", drv("ID"), dDebitT.Value)
                    End If
                End If
                If Payee_Type = "DT" Or Payee_Type = "DTM" Then 'FROM Due To
                    If MultipleAP Then
                        Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, IFNULL((SELECT SUM(Amount) FROM cv_details WHERE DocumentNumber = '{1}' AND ReferenceN = due_to.DocumentNumber AND `status` = 'ACTIVE' AND Type = 'C'),Paid) AS 'Paid' FROM due_to WHERE DocumentNumber IN ({0});", AccountsPayableID_M, txtDocumentNumber.Text))
                        For x As Integer = 0 To vDT.Rows.Count - 1
                            SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                        Next
                    Else
                        SQL &= String.Format(" UPDATE due_to SET Paid = IF(Paid - {1} <= 0, 0,Paid - {1}), AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, dDebitT.Value)
                    End If
                End If
                DataObject(SQL)
                Logs("Check Voucher", "Cancel", Reason, String.Format("Cancel Check Voucher of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "")
                If From_PaymentRequest Then
                    With btnDelete
                        .DialogResult = DialogResult.Yes
                        .DialogResult = DialogResult.Yes
                        .PerformClick()
                    End With
                End If
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Public Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            GenerateCV(True, "", txtCheck.Text, txtApproved.Text)
            Logs("Check Voucher", "Print", "[SENSITIVE] Print Check Voucher " & txtDocumentNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("CHECK VOUCHER LIST", GridControl1)
            Logs("Check Voucher", "Print", "[SENSITIVE] Print Check Voucher List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Public Sub GenerateCV(Show As Boolean, FName As String, CheckedBy As String, ApprovedBy As String)
        Dim Report As New RptCheckV
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_Bank As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        With Report
            .Name = String.Format("Check Voucher of {0} - {1}", cbxPayee.Text, txtDocumentNumber.Text)
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Or From_PaymentReleasePrint Then
                .lblPayee.Text = cbxPayee.Text
            Else
                If drv("Type") = "C" Then
                    .lblPayee.Text = cbxPayee.Text
                Else
                    .lblPayee.Text = drv("Name")
                End If
            End If
            .lblReferenceNumber.Text = txtReferenceNumber.Text
            If cbxBank.SelectedIndex = -1 Or cbxBank.Text = "" Or From_PaymentReleasePrint Then
                .lblBank.Text = cbxBank.Text
            Else
                .lblBank.Text = drv_Bank("Bank_1")
            End If
            .lblDocumentDate.Text = dtpDocument.Text
            .lblDocumentNumber.Text = txtDocumentNumber.Text
            .lblCheckNumber.Text = txtCheckNumber.Text
            .lblPostingDate.Text = dtpPostingDate.Text
            .lblCheckDate.Text = dtpCheck.Text
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

            .lblWords.Text = ConvertNumberToWords(dAmount.Value, True, False).ToString.ToUpper
            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblCheckedBy.Text = CheckedBy
            .lblApprovedBy.Text = ApprovedBy
            .lblReceivedBy.Text = txtReceived.Text
            .lblDateReceived.Text = If(txtReceived.Text = "", "", txtReceived.Tag.ToString)

            If Show Then
                If From_PaymentReleasePrint Then
                    Try
                        .ExportToPdf(FName)
                    Catch ex As Exception
                    End Try
                Else
                    .ShowPreview()
                End If
            Else
                Try
                    .ExportToPdf(FName)
                Catch ex As Exception
                End Try
            End If
        End With
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or If(From_Check Or From_PaymentRequest Or From_PaymentRelease Or From_GeneralLedger Or From_AccountsPayable Or FromDueTo Or From_CA Or From_Replenishment, e.KeyCode = Keys.Escape, 0) Then
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
        PanelEx10.Enabled = False
        PanelEx2.Enabled = False
        GridView2.OptionsBehavior.Editable = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            dtpDocument.Value = .GetFocusedRowCellValue("Document Date")
            txtDocumentNumber.Text = .GetFocusedRowCellValue("Document Number")
            Payee_Type = .GetFocusedRowCellValue("Payee_Type")
            If .GetFocusedRowCellValue("Payee_Type") = "APM" Or .GetFocusedRowCellValue("Payee_Type") = "ARM" Or .GetFocusedRowCellValue("Payee_Type") = "DTM" Then
                MultipleAP = True
                AccountsPayableID_M = .GetFocusedRowCellValue("MultipleAP")
                btnAdd_Account.Enabled = False
                btnRemove_Account.Enabled = False
            End If
            cbxPayee.Enabled = False
            FirstLoad = True
            If .GetFocusedRowCellValue("Payee_Type") = "APM" Or .GetFocusedRowCellValue("Payee_Type") = "AP" Then
                cbxAP.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "ARM" Or .GetFocusedRowCellValue("Payee_Type") = "AR" Then
                cbxAR.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "A" Or .GetFocusedRowCellValue("Payee_Type") = "L" Then
                cbxCAS.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "C" Then
                cbxLA.Checked = True
                btnView.Visible = True
                btnLedger.Visible = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "S" Then
                cbxSUP.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "RC" Then
                cbxRC.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "DT" Or .GetFocusedRowCellValue("Payee_Type") = "DTM" Then
                cbxDT.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "E" Then
                cbxEMP.Checked = True
            End If
        End With
        LoadPayee()
        cbxLA.Enabled = False
        cbxCAS.Enabled = False
        cbxSUP.Enabled = False
        cbxEMP.Enabled = False
        cbxAP.Enabled = False
        cbxAR.Enabled = False
        cbxDT.Enabled = False
        cbxRC.Enabled = False
        cbxDTS.Enabled = False
        With GridView1
            cbxPayee.Text = .GetFocusedRowCellValue("Payee")
            cbxPayee.Tag = .GetFocusedRowCellValue("Payee")
            FirstLoad = False
            cbxDTS.Checked = .GetFocusedRowCellValue("DTS")
            cbxDTS.Tag = .GetFocusedRowCellValue("DTS_JVNumber")
            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            cbxBank.Tag = .GetFocusedRowCellValue("Bank")
            dtpPostingDate.Value = .GetFocusedRowCellValue("Posting Date")
            dtpPostingDate.Tag = .GetFocusedRowCellValue("Posting Date")
            txtReferenceNumber.Text = .GetFocusedRowCellValue("Reference Number")
            txtReferenceNumber.Tag = .GetFocusedRowCellValue("Reference Number")
            txtCheckNumber.Text = .GetFocusedRowCellValue("Check Number")
            txtCheckNumber.Tag = .GetFocusedRowCellValue("Check Number")
            dtpCheck.Value = .GetFocusedRowCellValue("Check Date").ToString
            dtpCheck.Tag = .GetFocusedRowCellValue("Check Date")
            rExplanation.Text = .GetFocusedRowCellValue("Explanation")
            rExplanation.Tag = .GetFocusedRowCellValue("Explanation")
        End With

        If CompanyMode = 0 Then
            If GridView1.GetFocusedRowCellValue("Payee_Type") = "APM" Then
                DT_Account = DataSource(String.Format("SELECT MotherCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = MotherCode(cv_details.AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'D',Amount,0) AS 'Debit', IF(`Type` = 'C',Amount,0) AS 'Credit', Remarks, Required AS 'RequiredRemarks', PaidFor AS 'Paid For', ReferenceN, BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, CreditNumber FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
            Else
                DT_Account = DataSource(String.Format("SELECT MotherCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = MotherCode(cv_details.AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'D',Amount,0) AS 'Debit', IF(`Type` = 'C',Amount,0) AS 'Credit', Remarks, Required AS 'RequiredRemarks', PaidFor AS 'Paid For', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, CreditNumber FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
            End If
        Else
            If GridView1.GetFocusedRowCellValue("Payee_Type") = "APM" Then
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = cv_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'D',Amount,0) AS 'Debit', IF(`Type` = 'C',Amount,0) AS 'Credit', Remarks, Required AS 'RequiredRemarks', PaidFor AS 'Paid For', ReferenceN, BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, CreditNumber FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
            Else
                DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = cv_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'D',Amount,0) AS 'Debit', IF(`Type` = 'C',Amount,0) AS 'Credit', Remarks, Required AS 'RequiredRemarks', PaidFor AS 'Paid For', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, CreditNumber FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
            End If
        End If
        GridControl2.DataSource = DT_Account
        Dim TotalDebit As Double
        Dim TotalCredit As Double
        Dim Total_CIB As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                Total_CIB += CDbl(DT_Account(x)("Credit"))
            End If
        Next
        If GridView1.GetFocusedRowCellValue("Payee_Type") = "C" Then
            GridColumn30.Visible = True
            GridColumn30.VisibleIndex = 5

            GridColumn22.Width = 342 - 80
        End If

        dDebitT.Value = TotalDebit
        dDebitT.Tag = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB

        With GridView1
            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")
            txtCheck.Text = .GetFocusedRowCellValue("Checked By")
            txtCheck.Tag = .GetFocusedRowCellValue("CheckedID")
            txtApproved.Text = .GetFocusedRowCellValue("Approved By")
            txtReceived.Text = .GetFocusedRowCellValue("ReceivedBy")
            txtReceived.Tag = .GetFocusedRowCellValue("ReceivedDate").ToString
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
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR DISBURSEMENT" Then
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnReceive.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    btnReceive.Visible = True
                    If GridView1.GetFocusedRowCellValue("Payee_Type") = "C" Then
                        btnDelete.Enabled = True
                    End If
                    Exit For
                End If
            Next
            If (User_Type = "ADMIN" Or Empl_ID = User_EmplID Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID")) And GridView1.GetFocusedRowCellValue("JVNumber") = "" Then
                btnReceive.Visible = True
                If GridView1.GetFocusedRowCellValue("Payee_Type") = "C" Then
                    btnDelete.Enabled = True
                End If
            End If
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "RECEIVED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CLEARING" Then
            btnCheck.Visible = False
            btnApprove.Visible = False
            btnReceive.Visible = False
            btnModify.Enabled = False
        End If
        btnPrint.Enabled = True
        btnSave.Enabled = False
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub DtpDocument_ValueChanged(sender As Object, e As EventArgs) Handles dtpDocument.ValueChanged
        GetDocumentNumber()
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

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
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
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT * FROM (SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E LEFT JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE' UNION ALL SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E WHERE E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE' AND `Position` IN ('BRANCH MANAGER','OFFICER-IN-CHARGE','OFFICE SUPERVISOR','ASSISTANT BRANCH MANAGER')) A GROUP BY A.EmplID ;", btnCheck.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            Code = GenerateOTAC()
                            '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                            If Auto_Notification Then
                                ApproveNotification(Code, False)
                            End If
                            '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                            Dim SQL As String = ""
                            If Payee_Type = "C" Then
                                SQL &= String.Format(" UPDATE credit_application SET `PaymentRequest` = 'CHECKED REQUEST' WHERE CreditNumber = '{0}' AND `PaymentRequest` != 'RELEASED';", cbxPayee.SelectedValue)
                            End If

                            DataObject(SQL & String.Format("UPDATE check_voucher SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE accounts_receivable SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, .cbxProvider.SelectedValue, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Check Voucher", "Check", String.Format("Checked Check Voucher of {0} with the total amount of {1}. [Via OTAC]", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                            If From_GeneralLedger Or From_PaymentRequest Then
                            Else
                                Clear(True)
                            End If
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
            If MsgBoxYes("Are you sure you check this Checked Voucher?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    ApproveNotification(Code, False)
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                Dim SQL As String = ""
                If Payee_Type = "C" Then
                    SQL &= String.Format(" UPDATE credit_application SET `PaymentRequest` = 'CHECKED REQUEST' WHERE CreditNumber = '{0}' AND `PaymentRequest` != 'RELEASED';", cbxPayee.SelectedValue)
                End If

                DataObject(SQL & String.Format("UPDATE check_voucher SET `Voucher_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_receivable SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE accounts_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Check Voucher", "Check", String.Format("Checked Check Voucher of {0} with the total amount of {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                If From_GeneralLedger Or From_PaymentRequest Then
                Else
                    Clear(True)
                End If
            End If
        End If

        If From_GeneralLedger Or From_PaymentRequest Then
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
                        .cbxProvider.DataSource = DataSource(String.Format("SELECT * FROM (SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE' UNION ALL SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E WHERE E.Branch_ID = '{2}' AND E.`status` = 'ACTIVE' AND `Position` IN ('BRANCH MANAGER','OFFICER-IN-CHARGE','OFFICE SUPERVISOR','ASSISTANT BRANCH MANAGER')) A GROUP BY A.EmplID ;", btnApprove.Tag, Tag, Branch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Dim Msg As String = ""
                            Dim Subject As String
                            Dim FName As String
                            Dim SQL As String
                            If Payee_Type = "C" Then
                                '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************
                                Code = GenerateOTAC()
                                Code_Approve = Code
                                Dim EmailTo As String = ""
                                Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
                                Dim Requirements As String = ""
                                Dim DT_Requirements As DataTable = DataSource(String.Format("SELECT Requirement(Doc_ID) AS 'Document' FROM submit_documents WHERE is_complete = 'NO' AND `status` = 'ACTIVE' AND CreditNumber = '{0}';", cbxPayee.SelectedValue))
                                For x As Integer = 0 To DT_Requirements.Rows.Count - 1
                                    Requirements &= x + 1 & ".) " & DT_Requirements(x)("Document") & "<br>" & vbCrLf
                                Next
                                Dim BM As DataTable = GetBM(Branch_ID)
                                For x As Integer = 0 To BM.Rows.Count - 1
                                    Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Releasing of the Account of {1}." & vbCrLf, Code, cbxPayee.Text, dAmount.Text, cbxPreparedBy.Text)

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
                                    GenerateCV(False, FName, txtCheck.Text, txtApproved.Text)
                                    AttachmentFiles.Add(FName)
                                    SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, True, False, 0, "", "")
                                End If
                                '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************

                                SQL = String.Format(" UPDATE credit_application SET `PaymentRequest` = 'APPROVED REQUEST', Release_OTAC = '{1}' WHERE CreditNumber = '{0}' AND `PaymentRequest` != 'RELEASED';", cbxPayee.SelectedValue, Code_Approve, FormatDatePicker(dtpDocument))
                            Else
                                SQL = String.Format("UPDATE accounting_entry SET ORDate = '{2}', `Status` = 'ACTIVE', PostStatus = 'POSTED' WHERE CVNumber = '{0}' AND `status` = 'PENDING';", txtDocumentNumber.Text, If(cbxPayee.SelectedIndex = -1, CreditNumber, cbxPayee.SelectedValue), Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                            End If

                            Msg = String.Format("Good day {0}," & vbCrLf, cbxPayee.Text.Trim)
                            Msg &= String.Format("Your Check Voucher with the Net Amount of {0} is already approve." & vbCrLf, dAmount.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If drv("Phone") = "" Then
                            Else
                                SendSMS(drv("Phone"), Msg, False)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If drv("EmailAdd") = "" Then
                            Else
                                Subject = "Approved Check Voucher [" & txtDocumentNumber.Text & "] "
                                SendEmail(drv("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                            End If

                            DataObject(String.Format(SQL & " UPDATE check_voucher SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE accounts_receivable SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}';", ID, Provider.cbxProvider.SelectedValue, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Check Voucher", "Approve", String.Format("Approved Check Voucher of {0} with the total amount of {1}. [Via OTAC]", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "", "")
                            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                            If From_GeneralLedger Or From_PaymentRequest Then
                            Else
                                Clear(True)
                            End If
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
            If MsgBoxYes("Are you sure you want to approve this Checked Voucher?") = MsgBoxResult.Yes Then
                Dim Msg As String = ""
                Dim Subject As String = ""
                Dim FName As String = ""
                Dim SQL As String
                If Payee_Type = "C" Then
                    '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************
                    Code = GenerateOTAC()
                    Code_Approve = Code
                    Dim EmailTo As String = ""
                    Subject = "One Time Authorization Code " & Code & " [" & txtDocumentNumber.Text & "]"
                    Dim Requirements As String = ""
                    Dim DT_Requirements As DataTable = DataSource(String.Format("SELECT Requirement(Doc_ID) AS 'Document' FROM submit_documents WHERE is_complete = 'NO' AND `status` = 'ACTIVE' AND CreditNumber = '{0}';", cbxPayee.SelectedValue))
                    For x As Integer = 0 To DT_Requirements.Rows.Count - 1
                        Requirements &= x + 1 & ".) " & DT_Requirements(x)("Document") & "<br>" & vbCrLf
                    Next
                    Dim BM As DataTable = GetBM(Branch_ID)
                    For x As Integer = 0 To BM.Rows.Count - 1
                        Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Releasing of the Account of {1}." & vbCrLf, Code, cbxPayee.Text, dAmount.Text, cbxPreparedBy.Text)

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
                        GenerateCV(False, FName, txtCheck.Text, txtApproved.Text)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                    '********* SEND OTAC TO APPROVER PARA SA REALEASING ************************************************************

                    SQL = String.Format(" UPDATE credit_application SET `PaymentRequest` = 'APPROVED REQUEST', Release_OTAC = '{1}' WHERE CreditNumber = '{0}' AND `PaymentRequest` != 'RELEASED';", cbxPayee.SelectedValue, Code_Approve, FormatDatePicker(dtpDocument))
                Else
                    SQL = String.Format("UPDATE accounting_entry SET ORDate = '{2}', `Status` = 'ACTIVE', PostStatus = 'POSTED' WHERE CVNumber = '{0}' AND `status` = 'PENDING';", txtDocumentNumber.Text, If(cbxPayee.SelectedIndex = -1, CreditNumber, cbxPayee.SelectedValue), Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                End If

                Msg = String.Format("Good day {0}," & vbCrLf, cbxPayee.Text.Trim)
                Msg &= String.Format("Your Check Voucher with the Net Amount of {0} is already approve." & vbCrLf, dAmount.Text)
                Msg &= "Thank you!"
                '******* SEND SMS *********************************************************************************
                If drv("Phone") = "" Then
                Else
                    SendSMS(drv("Phone"), Msg, False)
                End If
                '******* SEND EMAIL *********************************************************************************
                If drv("EmailAdd") = "" Then
                Else
                    Subject = "Approved Check Voucher [" & txtDocumentNumber.Text & "] "
                    SendEmail(drv("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                End If

                DataObject(String.Format(SQL & " UPDATE check_voucher SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_receivable SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Check Voucher", "Approve", String.Format("Approved Check Voucher of {0} with the total amount of {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "", "")
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                If From_GeneralLedger Or From_PaymentRequest Then
                Else
                    Clear(True)
                End If
            End If
        End If

        If From_GeneralLedger Or From_PaymentRequest Then
            With btnApprove
                .DialogResult = DialogResult.OK
                .DialogResult = DialogResult.OK
                .PerformClick()
            End With
        End If
    End Sub

    Private Sub BtnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        If btnReceive.DialogResult = DialogResult.OK Then
        Else
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            If cbxLA.Checked And cbxDTS.Checked And cbxDTS.Tag = "" Then
                MsgBox("Credit Application is to DTS and the Check Voucher is not yet reversed thru Journal Voucher.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If From_PaymentRelease = False And Payee_Type = "C" Then
                If MsgBoxYes("Credit Application is not yet released, would you like to proceed?") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            Dim R As New FrmReceivedBy
            With R
                .LabelX1.Text = "CHECK VOUCHER RECEIVER"
                .dtpReceived.MinDate = dtpPostingDate.Value
                .From_CheckVoucher = True
                .From_PaymentRelease = From_PaymentRelease
                If From_GeneralLedger Then
                    If (If(cbxPayee.Text.Length >= 5 And drv("Name").ToString.Count >= 5, cbxPayee.Text.Substring(0, 5) = drv("Name").ToString.Substring(0, 5), cbxPayee.Text = drv("Name"))) Then
                        .cbxReceiver.Text = drv("Name")
                    Else
                        .cbxReceiver.Text = cbxPayee.Text
                    End If
                Else
                    If (If(cbxPayee.Text.Length >= 5 And drv("Name").ToString.Count >= 5, cbxPayee.Text.Substring(0, 5) = drv("Name").ToString.Substring(0, 5), cbxPayee.Text = drv("Name"))) Then
                        .cbxReceiver.Text = drv("Name")
                    Else
                        .cbxReceiver.Text = cbxPayee.Text
                    End If
                End If
                .cbxReceiver.Enabled = True
                If .ShowDialog = DialogResult.OK Then
                    Dim SQL As String = String.Format("UPDATE accounting_entry SET ORDate = '{2}', `Status` = 'ACTIVE', PostStatus = 'POSTED' WHERE CVNumber = '{0}' AND `status` = 'PENDING';", txtDocumentNumber.Text, If(cbxPayee.SelectedIndex = -1, CreditNumber, cbxPayee.SelectedValue), Format(.dtpReceived.Value, "yyyy-MM-dd"))
                    SQL &= String.Format("UPDATE check_voucher SET `Voucher_Status` = 'RECEIVED', ReceivedBy = '{1}', ReceivedDate = '{2}', PostingDate = IF(Payee_Type = 'C','{2}',PostingDate)  WHERE ID = '{0}';", ID, .cbxReceiver.Text.InsertQuote, Format(.dtpReceived.Value, "yyyy-MM-dd"))
                    If Payee_Type = "A" Then 'FROM CASH ADVANCE 
                        SQL &= String.Format(" UPDATE cash_advance SET slip_status = 'RECEIVED', ReceivedID = Payee_ID, ReceivedDate = '{2}' WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue, ValidateComboBox(.cbxReceiver), Format(.dtpReceived.Value, "yyyy-MM-dd"))
                    End If
                    DataObject(SQL)
                    Logs("Check Voucher", "Receive", String.Format("Received Check Voucher of {0} with the total amount of {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "", "")
                    MsgBox("Successfully Received!", MsgBoxStyle.Information, "Info")

                    If From_PaymentRelease Or From_GeneralLedger Or From_PaymentRequest Then
                        With btnReceive
                            .DialogResult = DialogResult.OK
                            .DialogResult = DialogResult.OK
                            .PerformClick()
                        End With
                    Else
                        Clear(True)
                    End If
                End If
            End With
        End If
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

    Private Sub TxtCVNumber_Leave(sender As Object, e As EventArgs) Handles txtReferenceNumber.Leave
        txtReferenceNumber.Text = ReplaceText(txtReferenceNumber.Text)
    End Sub

    Private Sub TxtCheckNumber_Leave(sender As Object, e As EventArgs) Handles txtCheckNumber.Leave
        txtCheckNumber.Text = ReplaceText(txtCheckNumber.Text)
    End Sub

    Public Sub CbxPayee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayee.SelectedIndexChanged
        If FirstLoad Or CopyMode Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                Clear(False)
            Else
                GridColumn22.Width = 342
                GridColumn30.Visible = False

                iTag.Enabled = False
                iViewLedger.Visible = False
                GridColumn12.OptionsColumn.AllowEdit = True
                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                btnView.Visible = False
                cbxDTS.Visible = False
                btnLedger.Visible = False
                btnVerify.Visible = False
                If drv("Type") = "A" Then 'FROM CASH ADVANCES
                    rExplanation.Text = ""
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    'DEBIT
                    AccountCodeDetails(If(drv("TIN") = 1, "112401", "112402"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(drv("Amount")), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(drv("Amount")), "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    rExplanation.Text = drv("Explanation")
                    If From_CA Then
                        GridControl2.DataSource = DT_Account
                    End If
                ElseIf drv("Type") = "L" Then 'FROM LIQUIDATION
                    rExplanation.Text = ""
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    'DEBIT
                    AccountCodeDetails(If(drv("TIN") = 1, "112401", "112402"))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(drv("Amount")), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    'DT_Account.Rows.Add("", "", "", "", "", CDbl(drv("Amount")), 0, "", "", "", "", 0, "", "")
                    'CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(drv("Amount")), "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    rExplanation.Text = drv("Explanation")
                    If From_CA Then
                        GridControl2.DataSource = DT_Account
                    End If
                ElseIf drv("Type") = "RC" Then 'Replenishment
                    rExplanation.Text = ""
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    'CREDITDEBIT
                    Dim SQL As String = String.Format("SELECT Caption1Tag AS 'Caption', IFNULL((SELECT SUM(Amount1) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount1 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption2Tag AS 'Caption', IFNULL((SELECT SUM(Amount2) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount2 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption3Tag AS 'Caption', IFNULL((SELECT SUM(Amount3) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount3 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption4Tag AS 'Caption', IFNULL((SELECT SUM(Amount4) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount4 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption5Tag AS 'Caption', IFNULL((SELECT SUM(Amount5) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount5 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption6Tag AS 'Caption', IFNULL((SELECT SUM(Amount6) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount6 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption7Tag AS 'Caption', IFNULL((SELECT SUM(Amount7) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount7 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption8Tag AS 'Caption', IFNULL((SELECT SUM(Amount8) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount8 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption9Tag AS 'Caption', IFNULL((SELECT SUM(Amount9) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount9 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption10Tag AS 'Caption', IFNULL((SELECT SUM(Amount10) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount10 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption11Tag AS 'Caption', IFNULL((SELECT SUM(Amount11) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount11 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption12Tag AS 'Caption', IFNULL((SELECT SUM(Amount12) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount12 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption13Tag AS 'Caption', IFNULL((SELECT SUM(Amount13) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount13 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption14Tag AS 'Caption', IFNULL((SELECT SUM(Amount14) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount14 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption15Tag AS 'Caption', IFNULL((SELECT SUM(Amount15) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount15 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption16Tag AS 'Caption', IFNULL((SELECT SUM(Amount16) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount16 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption17Tag AS 'Caption', IFNULL((SELECT SUM(Amount17) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount17 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption18Tag AS 'Caption', IFNULL((SELECT SUM(Amount18) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount18 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption19Tag AS 'Caption', IFNULL((SELECT SUM(Amount19) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount19 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption20Tag AS 'Caption', IFNULL((SELECT SUM(Amount20) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount20 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption21Tag AS 'Caption', IFNULL((SELECT SUM(Amount21) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount21 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption22Tag AS 'Caption', IFNULL((SELECT SUM(Amount22) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount22 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption23Tag AS 'Caption', IFNULL((SELECT SUM(Amount23) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount23 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption24Tag AS 'Caption', IFNULL((SELECT SUM(Amount24) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount24 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption25Tag AS 'Caption', IFNULL((SELECT SUM(Amount25) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount25 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption26Tag AS 'Caption', IFNULL((SELECT SUM(Amount26) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount26 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption27Tag AS 'Caption', IFNULL((SELECT SUM(Amount27) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount27 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption28Tag AS 'Caption', IFNULL((SELECT SUM(Amount28) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount28 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption29Tag AS 'Caption', IFNULL((SELECT SUM(Amount29) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount29 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption30Tag AS 'Caption', IFNULL((SELECT SUM(Amount30) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount30 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption31Tag AS 'Caption', IFNULL((SELECT SUM(Amount31) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount31 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption32Tag AS 'Caption', IFNULL((SELECT SUM(Amount32) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount32 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption33Tag AS 'Caption', IFNULL((SELECT SUM(Amount33) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount33 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption34Tag AS 'Caption', IFNULL((SELECT SUM(Amount34) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount34 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption35Tag AS 'Caption', IFNULL((SELECT SUM(Amount35) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount35 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption36Tag AS 'Caption', IFNULL((SELECT SUM(Amount36) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount36 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption37Tag AS 'Caption', IFNULL((SELECT SUM(Amount37) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount37 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption38Tag AS 'Caption', IFNULL((SELECT SUM(Amount38) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount38 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption39Tag AS 'Caption', IFNULL((SELECT SUM(Amount39) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount39 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption40Tag AS 'Caption', IFNULL((SELECT SUM(Amount40) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount40 >= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING';", cbxPayee.SelectedValue)
                    Dim RC_Details As DataTable = DataSource(SQL)
                    For x As Integer = 0 To RC_Details.Rows.Count - 1
                        If CDbl(RC_Details(x)("Amount")) > 0 Then
                            AccountCodeDetails(RC_Details(x)("Caption"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(RC_Details(x)("Amount")), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                    Next
                    '**** F O R   N E G A T I V E *****
                    SQL = String.Format("SELECT Caption1Tag AS 'Caption', IFNULL((SELECT SUM(Amount1) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount1 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption2Tag AS 'Caption', IFNULL((SELECT SUM(Amount2) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount2 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption3Tag AS 'Caption', IFNULL((SELECT SUM(Amount3) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount3 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption4Tag AS 'Caption', IFNULL((SELECT SUM(Amount4) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount4 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption5Tag AS 'Caption', IFNULL((SELECT SUM(Amount5) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount5 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption6Tag AS 'Caption', IFNULL((SELECT SUM(Amount6) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount6 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption7Tag AS 'Caption', IFNULL((SELECT SUM(Amount7) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount7 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption8Tag AS 'Caption', IFNULL((SELECT SUM(Amount8) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount8 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption9Tag AS 'Caption', IFNULL((SELECT SUM(Amount9) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount9 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption10Tag AS 'Caption', IFNULL((SELECT SUM(Amount10) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount10 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption11Tag AS 'Caption', IFNULL((SELECT SUM(Amount11) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount11 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption12Tag AS 'Caption', IFNULL((SELECT SUM(Amount12) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount12 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption13Tag AS 'Caption', IFNULL((SELECT SUM(Amount13) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount13 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption14Tag AS 'Caption', IFNULL((SELECT SUM(Amount14) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount14 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption15Tag AS 'Caption', IFNULL((SELECT SUM(Amount15) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount15 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption16Tag AS 'Caption', IFNULL((SELECT SUM(Amount16) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount16 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption17Tag AS 'Caption', IFNULL((SELECT SUM(Amount17) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount17 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption18Tag AS 'Caption', IFNULL((SELECT SUM(Amount18) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount18 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption19Tag AS 'Caption', IFNULL((SELECT SUM(Amount19) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount19 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption20Tag AS 'Caption', IFNULL((SELECT SUM(Amount20) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount20 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption21Tag AS 'Caption', IFNULL((SELECT SUM(Amount21) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount21 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption22Tag AS 'Caption', IFNULL((SELECT SUM(Amount22) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount22 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption23Tag AS 'Caption', IFNULL((SELECT SUM(Amount23) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount23 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption24Tag AS 'Caption', IFNULL((SELECT SUM(Amount24) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount24 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption25Tag AS 'Caption', IFNULL((SELECT SUM(Amount25) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount25 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption26Tag AS 'Caption', IFNULL((SELECT SUM(Amount26) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount26 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption27Tag AS 'Caption', IFNULL((SELECT SUM(Amount27) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount27 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption28Tag AS 'Caption', IFNULL((SELECT SUM(Amount28) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount28 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption29Tag AS 'Caption', IFNULL((SELECT SUM(Amount29) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount29 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption30Tag AS 'Caption', IFNULL((SELECT SUM(Amount30) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount30 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption31Tag AS 'Caption', IFNULL((SELECT SUM(Amount31) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount31 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption32Tag AS 'Caption', IFNULL((SELECT SUM(Amount32) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount32 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption33Tag AS 'Caption', IFNULL((SELECT SUM(Amount33) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount33 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption34Tag AS 'Caption', IFNULL((SELECT SUM(Amount34) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount34 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption35Tag AS 'Caption', IFNULL((SELECT SUM(Amount35) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount35 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption36Tag AS 'Caption', IFNULL((SELECT SUM(Amount36) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount36 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption37Tag AS 'Caption', IFNULL((SELECT SUM(Amount37) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount37 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption38Tag AS 'Caption', IFNULL((SELECT SUM(Amount38) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount38 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption39Tag AS 'Caption', IFNULL((SELECT SUM(Amount39) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount39 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING' UNION ALL ", cbxPayee.SelectedValue)
                    SQL &= String.Format("SELECT Caption40Tag AS 'Caption', IFNULL((SELECT SUM(Amount40) FROM replenishment_details WHERE RepNumber = M.DocumentNumber AND `status` = 'ACTIVE' AND Amount40 <= 0),0) AS 'Amount' FROM replenishment_cash M WHERE DocumentNumber = '{0}' AND ReplenishStatus = 'PENDING';", cbxPayee.SelectedValue)
                    RC_Details = DataSource(SQL)
                    For x As Integer = 0 To RC_Details.Rows.Count - 1
                        If CDbl(RC_Details(x)("Amount")) < 0 Then
                            AccountCodeDetails(RC_Details(x)("Caption"))
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, Math.Abs(CDbl(RC_Details(x)("Amount"))), "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        End If
                    Next

                    If From_Replenishment Then
                        GridControl2.DataSource = DT_Account
                    End If
                    '**** F O R   N E G A T I V E *****

                    'CREDIT
                    AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(drv("Amount")), "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                ElseIf drv("Type") = "C" Then 'FROM CREDIT APPLICATION
                    GridColumn12.OptionsColumn.AllowEdit = False
                    btnLedger.Visible = True

                    GridColumn22.Width = 342 - 80
                    GridColumn30.Visible = True
                    GridColumn30.OptionsColumn.AllowEdit = False
                    GridColumn30.VisibleIndex = 5

                    rExplanation.Text = ""
                    cbxDTS.Visible = True
                    If DefaultBank = 0 And drv("BankID") = 0 Then
                    Else
                        cbxBank.SelectedValue = If(DefaultBank = 0, drv("BankID"), DefaultBank)
                    End If
                    If drv("ManualAmortization") = 1 And drv("VerifiedManualAmort") = 0 Then
                        MsgBox("Please verify the Amortization Schedule of this Credit Application since it is manually filled up.", MsgBoxStyle.Information, "Info")
                        btnVerify.Visible = True
                    End If
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    btnView.Visible = True
                    If From_PaymentRequest = False Then
                        Dim DT_Checks As DataTable = DataSource(String.Format("SELECT ID, Amount, CVNumber_2 FROM check_received WHERE AssetNumber = '{0}' AND `status` NOT IN ('DELETED','CANCELLED') AND check_type = 'P';", cbxPayee.SelectedValue))
                        TotalPartial = 0
                        If DT_Checks.Rows.Count > 0 Then
                            CheckCount = DT_Checks.Rows.Count
                            For x As Integer = 0 To DT_Checks.Rows.Count - 1
                                If DT_Checks(x)("CVNumber_2") = txtDocumentNumber.Text Then
                                    LastRow = x >= DT_Checks.Rows.Count - 1
                                    If LastRow Then
                                        TotalPartial = 0
                                        For y As Integer = 0 To DT_Checks.Rows.Count - 2
                                            TotalPartial += CDbl(DT_Checks(y)("Amount"))
                                        Next
                                        CIB_Amount = CDbl(drv("Amount")) - TotalPartial
                                    Else
                                        CIB_Amount = CDbl(DT_Checks(x)("Amount"))
                                    End If
                                    CheckID = DT_Checks(x)("ID")
                                    Exit For
                                ElseIf DT_Checks(x)("CVNumber_2").ToString = "" Then
                                    LastRow = x >= DT_Checks.Rows.Count - 1
                                    If LastRow Then
                                        TotalPartial = 0
                                        For y As Integer = 0 To DT_Checks.Rows.Count - 2
                                            TotalPartial += CDbl(DT_Checks(y)("Amount"))
                                        Next
                                        CIB_Amount = CDbl(drv("Amount")) - TotalPartial
                                    Else
                                        CIB_Amount = CDbl(DT_Checks(x)("Amount"))
                                    End If
                                    CheckID = DT_Checks(x)("ID")
                                    Exit For
                                Else
                                    CheckID = DT_Checks(x)("ID")
                                    CIB_Amount = If(CheckCount > 1, CIB_Amount, CDbl(drv("Amount")))
                                End If
                            Next
                        Else
                            LastRow = True
                            CIB_Amount = If(CheckCount > 1, CIB_Amount, CDbl(drv("Amount")))
                        End If
                    End If

                    'DEBIT
                    AccountCodeDetails(If(cbxDTS.Checked, "217201", If(drv("PONumber") = 1, "112001", If(drv("PONumber") = 2, "112002", "112003"))))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", If(CheckCount > 1, CIB_Amount, CDbl(drv("Amount"))), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), "")
                    'CREDIT
                    Dim SQL As String = "SELECT * FROM ("
                    SQL &= String.Format("    SELECT IF({1} = 1,0,Advance_Payment) AS 'Amount', 'Advance Payment' AS 'Type', '229104' AS 'Account', '' AS 'AccountNumber', GMA - Rebate AS 'Monthly', ROUND(Interest / Terms) AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND IncludeAdvancePaymentInBill = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue, cbxDTS.Checked)
                    SQL &= String.Format("    SELECT Net_Proceeds - {1} AS 'Amount', 'Principal' AS 'Type', '111001' AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' UNION ALL", cbxPayee.SelectedValue, TotalPartial)
                    SQL &= String.Format("    SELECT IF({1} = 1,0,Service_Charge) AS 'Amount', 'Service Charge' AS 'Type', IF(Mortgage_ID = 1,'420101',IF(Mortgage_ID = 2,'420102','420103')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue, cbxDTS.Checked)
                    SQL &= String.Format("    SELECT IF({1} = 1,0,SUM(Amount)) AS 'Amount', 'Processing Fee' AS 'Type', IF(MortgageID('{0}') = 1,'420201',IF(MortgageID('{0}') = 2,'420202','420203')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_processing_fee WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND (SELECT Product FROM credit_application WHERE CreditNumber = credit_processing_fee.CreditNumber AND BillDeductions = 0) NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue, cbxDTS.Checked)
                    SQL &= String.Format("    SELECT `Amount`, 'Deduct Balance' AS 'Type', IF(MortgageID('{0}') = 1,'112001',IF(MortgageID('{0}') = 2,'112002','112003')) AS 'Account', AccountNumber, 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_deductbalance WHERE `status` = 'ACTIVE' AND deduct_status = 'PENDING' AND CreditNumber_F = '{0}' AND (SELECT Product FROM credit_application WHERE CreditNumber = credit_deductbalance.CreditNumber_F) NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue)
                    SQL &= String.Format("    SELECT IF({1} = 1,0,Miscellaneous_Income + CI_Fee + Appraisal_Fee) AS 'Amount', 'Mischellaneous Income' AS 'Type', IF(Mortgage_ID = 1,'420301',IF(Mortgage_ID = 2,'420302','420303')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue, cbxDTS.Checked)
                    'SQL &= String.Format("    SELECT IF({1} = 1,0,Appraisal_Fee) AS 'Amount', 'Other Income' AS 'Type', '' AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' UNION ALL", cbxPayee.SelectedValue, cbxDTS.Checked)
                    SQL &= String.Format("    SELECT IF({1} = 1,0,Insurance) AS 'Amount', 'Insurance' AS 'Type', IF(Mortgage_ID = 1,'218301',IF(Mortgage_ID = 2,'218302','218303')) AS 'Account', '' AS 'AccountNumber', 0 AS 'Monthly', 0 AS 'Monthly Interest' FROM credit_application WHERE CreditNumber = '{0}' AND BillDeductions = 0 AND Product NOT LIKE '%SHOWMONEY%' ) A WHERE A.Amount > 0", cbxPayee.SelectedValue, cbxDTS.Checked)
                    Dim Credits As DataTable = DataSource(SQL)
                    Dim z As Integer = 0
                    For x As Integer = 0 To Credits.Rows.Count - 1
                        If LastRow Then
                            If Credits(x)("Type") = "Deduct Balance" Then
                                If CDbl(Credits(x)("Amount")) > 0 Then
                                    Dim Deduct As DataTable = DataSource(String.Format("SELECT LR, UDI_Discount, AvailedRPPD, AR, Penalty, Amount, CreditNumber, AccountNumber FROM credit_deductbalance WHERE CreditNumber_F = '{0}' AND `status` = 'ACTIVE' AND deduct_status = 'PENDING';", cbxPayee.SelectedValue))
                                    If Deduct.Rows.Count > 0 Then
                                        iTag.Enabled = True
                                        iViewLedger.Visible = True
                                        Dim Balance As DataTable = DataSource(String.Format("SELECT IFNULL(RPPD - IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),0) AS 'Total RPPD', IFNULL(AmountApplied - IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),0) AS 'Total Principal', IFNULL(Interest - IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0),0) AS 'Total Interest', IFNULL(C.BankID,0) AS 'BankID' FROM credit_application C LEFT JOIN (SELECT PaidFor, Amount, ReferenceN, EntryType, Remarks FROM accounting_entry WHERE ReferenceN = '{0}' AND `status` IN ('ACTIVE', 'PENDING') AND PaidFor != 'Accounts Receivable' ) A ON C.CreditNumber = A.ReferenceN WHERE C.CreditNumber = '{0}';", Deduct(z)("CreditNumber")))
                                        If Balance.Rows.Count > 0 And (cbxBank.SelectedValue = Balance(0)("BankID") Or cbxDTS.Checked = False) Then 'Add this condition kay wala nay deduct balance basta dli same og Selected Bank sa Bank nga naka Deduct Balance || Add Condition dapat naka dli DTS ingon ms Cha 10-07-2020
                                            If cbxBank.SelectedValue <> Balance(0)("BankID") Then
                                                DTS_FromAccount = True
                                            End If

                                            If CDbl(Credits(x)("Amount")) >= (CDbl(Balance(0)("Total Principal")) + Math.Ceiling(CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount"))) + Math.Ceiling(CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")))) Then
                                                'Principal
                                                If CDbl(Balance(0)("Total Principal")) > 0 Then
                                                    AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "112001", If(drv("PONumber") = 2, "112002", "112003"))))
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total Principal"))), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Principal"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                End If
                                                'Interest
                                                If CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")) > 0 Then
                                                    AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "420001", If(drv("PONumber") = 2, "420002", "420006"))))
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount"))), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "UDI"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                End If
                                                'RPPD
                                                If CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")) > 0 Then
                                                    AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "420003", If(drv("PONumber") = 2, "420004", "420007"))))
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD"))), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "RPPD"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                End If
                                                'Penalty
                                                If CDbl(Deduct(z)("Penalty")) > 0 Then
                                                    AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "420003", If(drv("PONumber") = 2, "420004", "420007"))))
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Deduct(z)("Penalty"))), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Penalty"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                End If
                                                'AR
                                                If CDbl(Deduct(z)("AR")) > 0 Then
                                                    AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Deduct(z)("AR"))), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Billing"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                End If
                                                'Other Income
                                                'MsgBox(Math.Floor(CDbl(Deduct(z)("Amount")) - ((CDbl(Deduct(z)("LR")) + CDbl(Deduct(z)("Penalty"))) - (CDbl(Deduct(z)("UDI_Discount")) + CDbl(Deduct(z)("AvailedRPPD")) + CDbl(Deduct(z)("AR"))))))
                                                'Change 11-11-2020 from  If CDbl(Deduct(z)("Amount")) - ((CDbl(Deduct(z)("LR")) + CDbl(Deduct(z)("Penalty"))) - (CDbl(Deduct(z)("UDI_Discount")) + CDbl(Deduct(z)("AvailedRPPD")) + CDbl(Deduct(z)("AR")))) > 0 Then
                                                If CDbl(Deduct(z)("Amount")) - ((CDbl(Deduct(z)("LR")) + CDbl(Deduct(z)("Penalty"))) - (CDbl(Deduct(z)("UDI_Discount")) + CDbl(Deduct(z)("AvailedRPPD")) - CDbl(Deduct(z)("AR")))) > 0 Then
                                                    AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Floor(CDbl(Deduct(z)("Amount")) - ((CDbl(Deduct(z)("LR")) + CDbl(Deduct(z)("Penalty"))) - (CDbl(Deduct(z)("UDI_Discount")) + CDbl(Deduct(z)("AvailedRPPD")) + CDbl(Deduct(z)("AR"))))), Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), "", drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                End If
                                            Else
                                                Dim PartialPayment As Double = Credits(x)("Amount")
                                                If PartialPayment >= CDbl(Deduct(z)("AR")) Then
                                                    'AR
                                                    If CDbl(Deduct(z)("AR")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Deduct(z)("AR"))), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Billing"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment -= CDbl(Deduct(z)("AR"))
                                                Else
                                                    'AR
                                                    If CDbl(Deduct(z)("AR")) > 0 Then
                                                        AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, PartialPayment, Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Billing"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                    End If
                                                    PartialPayment = 0
                                                End If
                                                If PartialPayment > 0 Then
                                                    If PartialPayment >= CDbl(Deduct(z)("Penalty")) Then
                                                        'Penalty
                                                        If CDbl(Deduct(z)("Penalty")) > 0 Then
                                                            AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "420003", If(drv("PONumber") = 2, "420004", "420007"))))
                                                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Deduct(z)("Penalty"))), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Penalty"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                        End If
                                                        PartialPayment -= Math.Ceiling(CDbl(Deduct(z)("Penalty")))
                                                    Else
                                                        'Penalty
                                                        If CDbl(Deduct(z)("Penalty")) > 0 Then
                                                            AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "420003", If(drv("PONumber") = 2, "420004", "420007"))))
                                                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, PartialPayment, Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Penalty"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                        End If
                                                        PartialPayment = 0
                                                    End If
                                                End If
                                                If PartialPayment > 0 Then
                                                    If PartialPayment >= CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")) Then
                                                        'RPPD
                                                        If CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")) > 0 Then
                                                            AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "420003", If(drv("PONumber") = 2, "420004", "420007"))))
                                                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD"))), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "RPPD"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                        End If
                                                        PartialPayment -= (CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")))
                                                    Else
                                                        'RPPD
                                                        If CDbl(Balance(0)("Total RPPD")) - CDbl(Deduct(z)("AvailedRPPD")) > 0 Then
                                                            AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "420003", If(drv("PONumber") = 2, "420004", "420007"))))
                                                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, PartialPayment, Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "RPPD"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                        End If
                                                        PartialPayment = 0
                                                    End If
                                                End If
                                                If PartialPayment > 0 Then
                                                    If PartialPayment >= CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")) Then
                                                        'Interest
                                                        If CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")) > 0 Then
                                                            AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "420001", If(drv("PONumber") = 2, "420002", "420006"))))
                                                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount"))), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "UDI"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                        End If
                                                        PartialPayment -= (CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")))
                                                    Else
                                                        'Interest
                                                        If CDbl(Balance(0)("Total Interest")) - CDbl(Deduct(z)("UDI_Discount")) > 0 Then
                                                            AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "420001", If(drv("PONumber") = 2, "420002", "420006"))))
                                                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, PartialPayment, Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "UDI"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                        End If
                                                        PartialPayment = 0
                                                    End If
                                                End If
                                                If PartialPayment > 0 Then
                                                    If PartialPayment >= CDbl(Balance(0)("Total Principal")) Then
                                                        'Principal
                                                        If CDbl(Balance(0)("Total Principal")) > 0 Then
                                                            AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "112001", If(drv("PONumber") = 2, "112002", "112003"))))
                                                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(CDbl(Balance(0)("Total Principal"))), Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Principal"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                        End If
                                                        PartialPayment -= CDbl(Balance(0)("Total Principal"))
                                                    Else
                                                        'Principal
                                                        If CDbl(Balance(0)("Total Principal")) > 0 Then
                                                            AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", If(drv("PONumber") = 1, "112001", If(drv("PONumber") = 2, "112002", "112003"))))
                                                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, PartialPayment, Deduct(z)("AccountNumber"), DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Principal"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                        End If
                                                        PartialPayment = 0
                                                    End If
                                                End If
                                                If PartialPayment > 0 Then
                                                    AccountCodeDetails(If(cbxBank.SelectedValue <> Balance(0)("BankID"), "217201", "620061"))
                                                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, PartialPayment, Deduct(z)("AccountNumber") & " [Note: This is for tagging the old account for deduct balance. You can tag again the old account by right clicking on the selected accounting entries.]", DT_Temp_Account(0)("RequiredRemarks"), If(cbxBank.SelectedValue <> Balance(0)("BankID"), "", "Billing"), drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), Deduct(z)("CreditNumber"))
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                z += 1
                            ElseIf Credits(x)("Type") = "Advance Payment" Then
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
                                    'For y As Integer = 0 To Covered - 1
                                    '    If ForDistribute > 0 Then
                                    '        If ForDistribute >= CDbl(Credits(x)("Monthly Interest")) Then
                                    '            UDIAdvance = UDIAdvance + CDbl(Credits(x)("Monthly Interest"))
                                    '            ForDistribute = ForDistribute - CDbl(Credits(x)("Monthly Interest"))
                                    '        Else
                                    '            UDIAdvance = UDIAdvance + ForDistribute
                                    '            ForDistribute = 0
                                    '        End If

                                    '        If ForDistribute >= (CDbl(Credits(x)("Monthly")) - CDbl(Credits(x)("Monthly Interest"))) Then
                                    '            ForDistribute = ForDistribute - (CDbl(Credits(x)("Monthly")) - CDbl(Credits(x)("Monthly Interest")))
                                    '        Else
                                    '            ForDistribute = 0
                                    '        End If
                                    '    End If
                                    'Next
                                    'PrincipalAvance = CDbl(Credits(x)("Amount")) - UDIAdvance
                                    If UDIAdvance > 0 Then
                                        AccountCodeDetails(If(drv("PONumber") = 1, "420001", If(drv("PONumber") = 2, "420002", "420006")))
                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Ceiling(UDIAdvance), "", DT_Temp_Account(0)("RequiredRemarks"), "UDI", drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                    End If
                                    If PrincipalAvance > 0 Then
                                        AccountCodeDetails(If(drv("PONumber") = 1, "112001", If(drv("PONumber") = 2, "112002", "112003")))
                                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, Math.Floor(PrincipalAvance), "", DT_Temp_Account(0)("RequiredRemarks"), "Principal", drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), "")
                                    End If
                                End If
                            ElseIf Credits(x)("Type") = "Other Income" Then
                                DT_Account.Rows.Add("", "", "", DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, CDbl(Credits(x)("Amount")), "Other Income", False, "", drv("VAT"), 0, "", "")
                            Else
                                AccountCodeDetails(Credits(x)("Account"))
                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, CDbl(Credits(x)("Amount")), "", DT_Temp_Account(0)("RequiredRemarks"), "", drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), "")
                            End If
                            'End If
                        Else
                            If Credits(x)("Account") = "111001" Then
                                AccountCodeDetails(Credits(x)("Account"))
                                DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT"))), "", 0, CIB_Amount, "", DT_Temp_Account(0)("RequiredRemarks"), "", drv("VAT"), 0, DT_Temp_Account(0)("MotherCode"), "")
                            End If
                        End If
                    Next

                    If drv("ManualAmortization") = 1 And drv("VerifiedManualAmort") = 0 Then
                        btnVerify.PerformClick()
                    End If
                ElseIf drv("Type") = "AP" Then 'FROM ACCOUNTS PAYABLE
                    rExplanation.Text = ""
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    If AP_Account = "" Then
                        AP_Account = DataObject(String.Format("SELECT AccountCode FROM ap_details WHERE DocumentNumber = '{0}' AND Credit > 0 AND `status` = 'ACTIVE' LIMIT 1;", drv("ID")))
                    End If
                    If MultipleAP Then
                        rExplanation.Text = "[Accounts Payable : " & AccountsPayableID_M & "]"
                        DT_Account = DataSource(String.Format("SELECT IF(Debit > 0,'111001',AccountCode) AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = IF(Debit > 0,'111001',AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(Credit > 0,Credit - (SELECT AP.Paid FROM accounts_payable AP WHERE AP.DocumentNumber = ap_details.DocumentNumber),Credit) AS 'Debit', IF(Debit > 0,Debit - (SELECT AP.Paid FROM accounts_payable AP WHERE AP.DocumentNumber = ap_details.DocumentNumber),Debit) AS 'Credit', CONCAT('[', DocumentNumber,'] ',Remarks) AS 'Remarks', Required AS 'RequiredRemarks', '' AS 'Paid For', DocumentNumber AS 'ReferenceN', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'CreditNumber' FROM ap_details WHERE `status` = 'ACTIVE' AND DocumentNumber IN ({0});", AccountsPayableID_M))
                        Dim AutoGenerated As DataTable = DataSource(String.Format("SELECT Amount, DocumentNumber FROM accounts_payable WHERE JVNumberV2 != '' AND DocumentNumber IN ({0});", AccountsPayableID_M))
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        For x As Integer = 0 To AutoGenerated.Rows.Count - 1
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(AutoGenerated(x)("Amount")), AutoGenerated(x)("DocumentNumber"), DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
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
                        If CDate(drv("Due")) > dtpPostingDate.Value And cbxPayee.Enabled Then
                            If MsgBox(String.Format("This Accounts Payable will due on {0}. Are you sure you want to proceed on create a CV under this voucher?", Format(CDate(drv("Due")), "MMMM dd, yyyy")), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                            Else
                                cbxPayee.SelectedIndex = -1
                                Exit Sub
                            End If
                        End If
                        rExplanation.Text = drv("Explanation") & " [Reference Number: " & drv("PONumber") & "]"
                        'DEBIT
                        AccountCodeDetails(AP_Account)
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(drv("Amount")), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(drv("Amount")), "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")

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
                    If AP_Account = "" Then
                        AP_Account = DataObject(String.Format("SELECT AccountCode FROM ar_details WHERE DocumentNumber = '{0}' AND Debit > 0 AND `status` = 'ACTIVE' LIMIT 1;", drv("ID")))
                    End If
                    If MultipleAP Then
                        rExplanation.Text = "[Accounts Receivable : " & AccountsPayableID_M & "]"
                        DT_Account = DataSource(String.Format("SELECT IF(Credit > 0,'111001',AccountCode) AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = IF(Credit > 0,'111001',AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(Credit > 0,Credit - (SELECT AR.Paid FROM accounts_receivable AR WHERE AR.DocumentNumber = ar_details.DocumentNumber),Credit) AS 'Debit', IF(Debit > 0,Debit - (SELECT AR.Paid FROM accounts_receivable AR WHERE AR.DocumentNumber = ar_details.DocumentNumber),Debit) AS 'Credit', CONCAT('[', DocumentNumber,'] ',Remarks) AS 'Remarks', Required AS 'RequiredRemarks', '' AS 'Paid For', DocumentNumber AS 'ReferenceN', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'CreditNumber' FROM ar_details WHERE `status` = 'ACTIVE' AND DocumentNumber IN ({0});", AccountsPayableID_M))
                        Dim AutoGenerated As DataTable = DataSource(String.Format("SELECT Amount, DocumentNumber FROM accounts_receivable WHERE JVNumberV2 != '' AND DocumentNumber IN ({0});", AccountsPayableID_M))
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        For x As Integer = 0 To AutoGenerated.Rows.Count - 1
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(AutoGenerated(x)("Amount")) - CDbl(AutoGenerated(x)("Amount")), 0, AutoGenerated(x)("DocumentNumber"), DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
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
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", drv("Amount") - drv("Amount"), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'CREDIT
                        AccountCodeDetails(AP_Account)
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, drv("Amount"), "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                ElseIf drv("Type") = "DT" Then 'FROM DUE TO
                    rExplanation.Text = ""
                    cbxBank.SelectedValue = drv("BankID")
                    Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    If AP_Account = "" Then
                        AP_Account = DataObject(String.Format("SELECT AccountCode FROM dt_details WHERE DocumentNumber = '{0}' AND Credit > 0 AND `status` = 'ACTIVE' LIMIT 1;", drv("ID")))
                    End If
                    If MultipleAP Then
                        rExplanation.Text = "[Due To: " & AccountsPayableID_M & "]"
                        DT_Account = DataSource(String.Format("SELECT IF(Debit > 0,'111001',AccountCode) AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = IF(Debit > 0,'111001',AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(Credit > 0,Credit - (SELECT AP.Paid FROM due_to AP WHERE AP.DocumentNumber = dt_details.DocumentNumber),Credit) AS 'Debit', IF(Debit > 0,Debit - (SELECT AP.Paid FROM due_to AP WHERE AP.DocumentNumber = dt_details.DocumentNumber),Debit) AS 'Credit', CONCAT('[', DocumentNumber,'] ',Remarks) AS 'Remarks', Required AS 'RequiredRemarks', '' AS 'Paid For', DocumentNumber AS 'ReferenceN', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, '' AS 'CreditNumber' FROM dt_details WHERE `status` = 'ACTIVE' AND DocumentNumber IN ({0});", AccountsPayableID_M))
                        Dim AutoGenerated As DataTable = DataSource(String.Format("SELECT Amount, DocumentNumber FROM due_to WHERE JVNumberV2 != '' AND DocumentNumber IN ({0});", AccountsPayableID_M))
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        For x As Integer = 0 To AutoGenerated.Rows.Count - 1
                            DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(AutoGenerated(x)("Amount")), AutoGenerated(x)("DocumentNumber"), DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
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
                        If CDate(drv("Due")) > dtpPostingDate.Value And cbxPayee.Enabled Then
                            If MsgBox(String.Format("This Due To will due on {0}. Are you sure you want to proceed on create a CV under this voucher?", Format(CDate(drv("Due")), "MMMM dd, yyyy")), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                            Else
                                cbxPayee.SelectedIndex = -1
                                Exit Sub
                            End If
                        End If
                        rExplanation.Text = drv("Explanation") & " [Reference Number: " & drv("PONumber") & "]"
                        'DEBIT
                        AccountCodeDetails(AP_Account)
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", CDbl(drv("Amount")), 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                        'CREDIT
                        AccountCodeDetails(If(cbxBank.SelectedIndex = -1 Or cbxBank.Text = "", CIB_BDO, If(drv_B("AccountCode") = "", CIB_BDO, drv_B("AccountCode"))))
                        DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, CDbl(drv("Amount")), "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                    End If
                End If

                Dim TotalDebit As Double
                Dim TotalCredit As Double
                Dim Total_CIB As Double
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    TotalDebit += CDbl(DT_Account(x)("Debit"))
                    TotalCredit += CDbl(DT_Account(x)("Credit"))
                    If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                        Total_CIB += CDbl(DT_Account(x)("Credit"))
                    End If
                Next
                If GridView2.RowCount > 7 Then
                    If GridColumn30.Visible = False Then
                        GridColumn22.Width = 342 - 17
                    Else
                        GridColumn22.Width = (342 - 80) - 17
                    End If
                Else
                    If GridColumn30.Visible = False Then
                        GridColumn22.Width = 342
                    Else
                        GridColumn22.Width = 342 - 80
                    End If
                End If
                dDebitT.Value = TotalDebit
                dCreditT.Value = TotalCredit
                dAmount.Value = Total_CIB
                If drv("Type") = "C" And cbxDTS.Checked And TotalDebit <> TotalCredit And DT_Account.Rows.Count > 0 Then
                    DT_Account(0)("Debit") = TotalCredit
                    dDebitT.Value = TotalCredit
                End If
            End If
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadAmortization(CreditNumber As String, Grid As DevExpress.XtraGrid.GridControl)
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

    Private Sub CbxABCD_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLA.CheckedChanged, cbxCAS.CheckedChanged, cbxSUP.CheckedChanged, cbxEMP.CheckedChanged, cbxAP.CheckedChanged, cbxRC.CheckedChanged, cbxDT.CheckedChanged, cbxAR.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadPayee()
    End Sub

    Private Sub LoadPayee()
        cbxPayee.DisplayMember = "Supplier"
        cbxPayee.ValueMember = "ID"
        Dim SQL As String = ""
        If From_CA Then
            GoTo here
        End If
        If From_Replenishment Then
            GoTo Here_Replenishment
        End If
        SQL = " SELECT "
        SQL &= "    ID,"
        SQL &= "    Branch AS 'Supplier',"
        SQL &= "    'B' AS 'Type',"
        SQL &= "    TIN,"
        SQL &= "    '' AS 'Phone',"
        SQL &= "    Email_Address AS 'EmailAdd',"
        SQL &= "    0 AS 'Amount',"
        SQL &= "    1 AS 'VAT',"
        SQL &= "    Branch AS 'Name',"
        SQL &= "    '' AS 'PONumber',"
        SQL &= "    '' AS 'Explanation',"
        SQL &= "    0 AS 'BankID',"
        SQL &= "    DATE(NOW()) AS 'Due',"
        SQL &= "    '' AS 'CreditNumber_Old', 0 AS 'ManualAmortization', 0 AS 'VerifiedManualAmort'"
        SQL &= " FROM branch WHERE `status` = 'ACTIVE'"
        If cbxEMP.Checked Then
            SQL &= " UNION ALL"
            SQL &= " SELECT  ID,"
            SQL &= "    Employee (ID) AS 'Supplier',"
            SQL &= "    'E' AS 'Type',"
            SQL &= "    '' AS 'TIN',"
            SQL &= "    Phone,"
            SQL &= "    EmailAdd,"
            SQL &= "    0 AS 'Amount',"
            SQL &= "    1 AS 'VAT',"
            SQL &= "    Employee (ID) AS 'Name',"
            SQL &= "    '' AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    0 AS 'BankID',"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old', 0 AS 'ManualAmortization', 0 AS 'VerifiedManualAmort'"
            SQL &= " FROM employee_setup"
            SQL &= "    WHERE `status` = 'ACTIVE'"
            'SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ", Branch_ID)
        End If
        If cbxSUP.Checked Then
            SQL &= " UNION ALL"
            SQL &= " SELECT ID,"
            SQL &= "    Supplier,"
            SQL &= "    'S' AS 'Type',"
            SQL &= "    TIN,"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    EmailAddress AS 'EmailAdd',"
            SQL &= "    0 AS 'Amount',"
            SQL &= "    VAT,"
            SQL &= "    Supplier AS 'Name',"
            SQL &= "    '' AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    0 AS 'BankID',"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old', 0 AS 'ManualAmortization', 0 AS 'VerifiedManualAmort'"
            SQL &= " FROM supplier_setup"
            SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ", Branch_ID)
        End If
        If cbxLA.Checked Then
            SQL &= " UNION ALL"
            SQL &= " SELECT CreditNumber AS 'ID',"
            If From_PaymentRequest And CheckID > 0 Then
                SQL &= String.Format("    CONCAT(IFNULL((SELECT Buyer FROM check_received WHERE ID = '{0}'),IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))),' [',CreditNumber,']') AS 'Supplier',", CheckID)
            Else
                SQL &= "    CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)), IF(Borrower_S = 1,CONCAT(' AND ', CONCAT(IF(FirstN_S = '','',CONCAT(FirstN_S, ' ')), IF(MiddleN_S = '','',CONCAT(MiddleN_S, ' ')), IF(LastN_S = '','',CONCAT(LastN_S, ' ')), Suffix_S)),''), IF(Borrower_C1 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C1 = '','',CONCAT(FirstN_C1, ' ')), IF(MiddleN_C1 = '','',CONCAT(MiddleN_C1, ' ')), IF(LastN_C1 = '','',CONCAT(LastN_C1, ' ')), Suffix_C1)),''), IF(Borrower_C2 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C2 = '','',CONCAT(FirstN_C2, ' ')), IF(MiddleN_C2 = '','',CONCAT(MiddleN_C2, ' ')), IF(LastN_C2 = '','',CONCAT(LastN_C2, ' ')), Suffix_C2)),''), IF(Borrower_C3 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C3 = '','',CONCAT(FirstN_C3, ' ')), IF(MiddleN_C3 = '','',CONCAT(MiddleN_C3, ' ')), IF(LastN_C3 = '','',CONCAT(LastN_C3, ' ')), Suffix_C3)),''), IF(Borrower_C4 = 1,CONCAT(' AND ', CONCAT(IF(FirstN_C4 = '','',CONCAT(FirstN_C4, ' ')), IF(MiddleN_C4 = '','',CONCAT(MiddleN_C4, ' ')), IF(LastN_C4 = '','',CONCAT(LastN_C4, ' ')), Suffix_C4)),''),' [',CreditNumber,']') AS 'Supplier',"
            End If
            SQL &= "    'C' AS 'Type',"
            SQL &= "    TIN_B AS 'TIN',"
            SQL &= "    Mobile_B AS 'Phone',"
            SQL &= "    Email_B AS 'EmailAdd',"
            SQL &= "    AmountApplied AS 'Amount',"
            SQL &= "    BusinessCenterCode(BusinessID) AS 'VAT',"
            SQL &= "    IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'Name',"
            SQL &= "    Mortgage_ID AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    BankID,"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    CreditNumber_Old, ManualAmortization, VerifiedManualAmort"
            SQL &= " FROM credit_application"
            SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND IF({1} = False,PaymentRequest IN ('REQUEST','REQUESTED','CHECKED REQUEST','APPROVED REQUEST','RELEASED'),PaymentRequest IN ('REQUEST')) AND branch_id = '{0}' AND CVforJV = 0", Branch_ID, cbxPayee.Enabled)
            If From_PaymentRequest And CheckID > 0 Then
                SQL &= String.Format("    AND CreditNumber = '{0}' ", CreditNumber)
            End If
        End If
        If cbxCAS.Checked Then
            SQL &= " UNION ALL"
here:
            SQL &= " SELECT AccountNumber AS 'ID',"
            SQL &= "    CONCAT(Employee (Payee_ID),' [',AccountNumber,']') AS 'Supplier',"
            SQL &= "    'A' AS 'Type',"
            SQL &= "    IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = (SELECT position_ID FROM employee_setup WHERE ID = cash_advance.Payee_ID)),0) AS 'TIN'," 'GIGAMIT LANG PARA MA IDENTIFY AS HEAD
            SQL &= "    (SELECT Phone FROM employee_setup WHERE ID = Payee_ID) AS 'Phone',"
            SQL &= "    (SELECT EmailAdd FROM employee_setup WHERE ID = Payee_ID) AS 'EmailAdd',"
            SQL &= "    (Meals + Transportation + BIR + RD + LTO + Notarization + Others) AS 'Amount',"
            SQL &= "    1 AS 'VAT',"
            SQL &= "    Employee (Payee_ID) AS 'Name',"
            SQL &= "    '' AS 'PONumber',"
            SQL &= "    Purpose AS 'Explanation',"
            SQL &= "    0 AS 'BankID',"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old', 0 AS 'ManualAmortization', 0 AS 'VerifiedManualAmort'"
            SQL &= " FROM cash_advance"
            SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) > 1000 AND slip_status IN ('APPROVED','{1}') AND IF(Slip_Status = 'APPROVED' AND {2},CVNumber = '',TRUE) AND Branch_ID = '{0}' ", Branch_ID, If(cbxPayee.Enabled, "", "RECEIVED"), cbxPayee.Enabled)

            SQL &= " UNION ALL"

            SQL &= " SELECT AccountNumber AS 'ID',"
            SQL &= "    CONCAT(Payee,' [',AccountNumber,']') AS 'Supplier',"
            SQL &= "    'L' AS 'Type',"
            SQL &= "    IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = (SELECT position_ID FROM employee_setup WHERE ID = liquidation_main.Payee_ID)),0) AS 'TIN',"
            SQL &= "    (SELECT Phone FROM employee_setup WHERE ID = Payee_ID) AS 'Phone',"
            SQL &= "    (SELECT EmailAdd FROM employee_setup WHERE ID = Payee_ID) AS 'EmailAdd',"
            SQL &= "    AmountDue AS 'Amount',"
            SQL &= "    1 AS 'VAT',"
            SQL &= "    Payee AS 'Name',"
            SQL &= "    '' AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    IFNULL((SELECT BankID FROM check_voucher WHERE Payee_ID = Liquidation_Main.CANumber AND `status` = 'ACTIVE' LIMIT 1),0) AS 'BankID',"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old', 0 AS 'ManualAmortization', 0 AS 'VerifiedManualAmort'"
            SQL &= " FROM liquidation_main"
            SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND AmountDue > 1000 AND Liq_Status IN ('APPROVED') AND Branch_ID = '{0}' AND IF('{1}' = 'TRUE',Refund = 0,TRUE)", Branch_ID, cbxPayee.Enabled)
        End If
        If cbxAP.Checked Then
            SQL &= " UNION ALL"
            SQL &= " SELECT DocumentNumber AS 'ID',"
            SQL &= "    CONCAT(Payee, ' [',DocumentNumber,']') AS 'Supplier',"
            SQL &= "    'AP' AS 'Type',"
            SQL &= "    IF(Payee_Type = 'S',(SELECT TIN FROM supplier_setup WHERE ID = PayeeID),'') AS 'TIN',"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    IF(Payee_Type = 'S',(SELECT EmailAddress FROM supplier_setup WHERE ID = PayeeID),'') AS 'EmailAdd',"
            SQL &= "    Amount - Paid AS 'Amount',"
            SQL &= "    IF(Payee_Type = 'S',(SELECT VAT FROM supplier_setup WHERE ID = PayeeID),1) AS 'VAT',"
            SQL &= "    Payee AS 'Name',"
            SQL &= "    ReferenceNumber AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    BankID,"
            SQL &= "    ADDDATE(Delivery_Date,Terms) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old', 0 AS 'ManualAmortization', 0 AS 'VerifiedManualAmort'"
            SQL &= " FROM accounts_payable"
            If cbxPayee.Enabled Then
                SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND NotAP = 0 AND branch_id = '{0}' AND AP_Status IN ('APPROVED','PARTIALLY PAID')", Branch_ID)
            Else
                SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND NotAP = 0 AND branch_id = '{0}'", Branch_ID)
            End If
        End If
        If cbxAR.Checked Then
            SQL &= " UNION ALL"
            SQL &= " SELECT DocumentNumber AS 'ID',"
            SQL &= "    CONCAT(Payor, ' [',DocumentNumber,']') AS 'Supplier',"
            SQL &= "    'AR' AS 'Type',"
            SQL &= "    '' AS 'TIN',"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    '' AS 'EmailAdd',"
            SQL &= "    Amount - Paid AS 'Amount',"
            SQL &= "    0 AS 'VAT',"
            SQL &= "    Payor AS 'Name',"
            SQL &= "    ReferenceNumber AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    BankID,"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old', 0 AS 'ManualAmortization', 0 AS 'VerifiedManualAmort'"
            SQL &= " FROM accounts_receivable"
            If cbxPayee.Enabled Then
                SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND NotAR = 0 AND branch_id = '{0}' AND AR_Status IN ('APPROVED','PARTIALLY PAID')", Branch_ID)
            Else
                SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND NotAR = 0 AND branch_id = '{0}'", Branch_ID)
            End If
        End If
        If cbxDT.Checked Then
            SQL &= " UNION ALL"
            SQL &= " SELECT DocumentNumber AS 'ID',"
            SQL &= "    CONCAT(Payee, ' [',DocumentNumber,']') AS 'Supplier',"
            SQL &= "    'DT' AS 'Type',"
            SQL &= "    IF(Payee_Type = 'S',(SELECT TIN FROM supplier_setup WHERE ID = PayeeID),'') AS 'TIN',"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    IF(Payee_Type = 'S',(SELECT EmailAddress FROM supplier_setup WHERE ID = PayeeID),'') AS 'EmailAdd',"
            SQL &= "    Amount - Paid AS 'Amount',"
            SQL &= "    IF(Payee_Type = 'S',(SELECT VAT FROM supplier_setup WHERE ID = PayeeID),1) AS 'VAT',"
            SQL &= "    Payee AS 'Name',"
            SQL &= "    ReferenceNumber AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    BankID,"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old', 0 AS 'ManualAmortization', 0 AS 'VerifiedManualAmort'"
            SQL &= " FROM due_to"
            If cbxPayee.Enabled Then
                SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND NotAP = 0 AND branch_id = '{0}' AND AP_Status IN ('APPROVED','PARTIALLY PAID')", Branch_ID)
            Else
                SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND NotAP = 0 AND branch_id = '{0}'", Branch_ID)
            End If
        End If
        If cbxRC.Checked Then
            SQL &= " UNION ALL"
Here_Replenishment:
            SQL &= " SELECT DocumentNumber AS 'ID',"
            SQL &= "    CONCAT(Employee(PreparedID), ' [',DocumentNumber,']') AS 'Supplier',"
            SQL &= "    'RC' AS 'Type',"
            SQL &= "    '' AS 'TIN',"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    '' AS 'EmailAdd',"
            SQL &= "    TotalExpenses AS 'Amount',"
            SQL &= "    1 AS 'VAT',"
            SQL &= "    Employee(PreparedID) AS 'Name',"
            SQL &= "    '' AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    0 AS 'BankID',"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old', 0 AS 'ManualAmortization', 0 AS 'VerifiedManualAmort'"
            SQL &= " FROM replenishment_cash"
            If cbxPayee.Enabled Then
                SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}' AND ReplenishStatus = 'PENDING' AND CVNumber = ''", Branch_ID)
            Else
                SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}'", Branch_ID)
            End If
        End If
        SQL &= "    ORDER BY `Supplier` ;"
        If SQL = "" Then
        Else
            cbxPayee.DataSource = DataSource(SQL)
            If cbxPayee.Enabled And cbxLA.Checked = False And cbxCAS.Checked = False And cbxSUP.Checked = False And cbxEMP.Checked = False And cbxAP.Checked = False And cbxAR.Checked = False And cbxDT.Checked = False And cbxRC.Checked = False Then
                cbxPayee.SelectedIndex = -1
            End If
        End If

        If From_PaymentRequest Then
            cbxPayee.SelectedValue = CreditNumber
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
            .FolderName = "Check Voucher-" & GridView1.GetFocusedRowCellValue("Document Number")
            .CVNumber = GridView1.GetFocusedRowCellValue("Document Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Document Number")
            .Type = "Check Voucher"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If btnDisapprove.DialogResult = DialogResult.Yes Then
        Else
            If MsgBoxYes("Are you sure you want to disapprove this Check Voucher?") = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                Dim SQL As String = String.Format("UPDATE check_voucher SET `voucher_status` = 'DISAPPROVED' WHERE ID = '{0}';", ID)
                SQL &= String.Format(" UPDATE accounts_receivable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQL &= String.Format(" UPDATE due_from SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQL &= String.Format(" UPDATE due_to SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQL &= String.Format(" UPDATE loans_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)

                If Payee_Type = "C" Then 'FROM CREDIT APPLICATION
                    If CheckID = 0 Then
                        CheckID = DataObject(String.Format("SELECT ID FROM check_received WHERE `status` IN ('PENDING','ACTIVE') AND AssetNumber = '{0}' AND check_type = 'P' AND CVNumber_2 = '{1}';", cbxPayee.SelectedValue, txtDocumentNumber.Text))
                    End If
                    SQL &= String.Format(" UPDATE credit_application SET `PaymentRequest` = 'REQUEST' WHERE CreditNumber = '{0}';", cbxPayee.SelectedValue)
                    SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'DISAPPROVED' WHERE CVNumber = '{0}';", txtDocumentNumber.Text, cbxPayee.SelectedValue)
                    SQL &= String.Format(" UPDATE check_received SET Bank = '', Branch = '', `Check` = '', `Date` = '', BankID = 0, Amount = 0, CVNumber = '', CVDate = '', CVNumber_2 = ''  WHERE `status` IN ('PENDING','ACTIVE') AND AssetNumber = '{0}' AND check_type = 'P' AND ID = '{1}';", cbxPayee.SelectedValue, CheckID)
                    SQL &= String.Format(" UPDATE credit_deductbalance SET `deduct_status` = 'PENDING'  WHERE `status` = 'ACTIVE' AND CreditNumber_F = '{0}';", cbxPayee.SelectedValue)
                Else
                    SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'DISAPPROVED' WHERE CVNumber = '{0}' AND ReferenceN = '{1}';", txtDocumentNumber.Text, cbxPayee.SelectedValue)
                End If
                If Payee_Type = "RO" Then 'FROM ROPOA

                End If
                If Payee_Type = "A" Then 'FROM CASH ADVANCE
                    SQL &= String.Format(" UPDATE cash_advance SET slip_status = 'APPROVED', ReceivedID = 0, ReceivedDate = '', CVNumber = '' WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue)
                End If
                If Payee_Type = "L" Then 'FROM LIQUIDATION
                    SQL &= String.Format(" UPDATE liquidation_main SET Refund = 0 WHERE AccountNumber = '{0}';", cbxPayee.SelectedValue)
                End If
                If Payee_Type = "RC" Then 'FROM REPLENISHMENT
                    SQL &= String.Format(" UPDATE replenishment_cash SET CVNumber = '', ReplenishStatus = 'PENDING' WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, txtDocumentNumber.Text)
                End If
                If Payee_Type = "AP" Then 'FROM ACCOUNTS PAYABLE
                    If MultipleAP Then
                        Dim vDT As New DataTable
                        vDT = DataSource(String.Format("SELECT DocumentNumber, (SELECT SUM(Amount) FROM cv_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_payable.DocumentNumber AND `status` = 'ACTIVE' AND Type = 'C') AS 'Paid' FROM accounts_payable WHERE DocumentNumber IN ({0});", AccountsPayableID_M, txtDocumentNumber.Text))
                        For x As Integer = 0 To vDT.Rows.Count - 1
                            SQL &= String.Format(" UPDATE accounts_payable SET AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                        Next
                    Else
                        SQL &= String.Format(" UPDATE accounts_payable SET Paid = IF(Paid - {1} <= 0, 0,Paid - {1}), AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, dDebitT.Value)
                    End If
                End If
                If Payee_Type = "AR" Or Payee_Type = "ARM" Then 'FROM ACCOUNTS RECEIVABLE
                    If MultipleAP Then
                        Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, (SELECT SUM(Debit) FROM acr_details WHERE DocumentNumber = '{1}' AND ReferenceN = accounts_receivable.DocumentNumber AND `status` = 'ACTIVE') AS 'Paid' FROM accounts_receivable WHERE DocumentNumber IN ({0});", AccountsPayableID_M, txtDocumentNumber.Text))
                        For x As Integer = 0 To vDT.Rows.Count - 1
                            SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                        Next
                    Else
                        SQL &= String.Format(" UPDATE accounts_receivable SET AR_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", drv("ID"), dDebitT.Value)
                    End If
                End If
                If Payee_Type = "DT" Then 'FROM DUE TO
                    If MultipleAP Then
                        Dim vDT As DataTable = DataSource(String.Format("SELECT DocumentNumber, IFNULL((SELECT SUM(Amount) FROM cv_details WHERE DocumentNumber = '{1}' AND ReferenceN = due_to.DocumentNumber AND `status` = 'ACTIVE' AND Type = 'C'),Paid) AS 'Paid' FROM due_to WHERE DocumentNumber IN ({0});", AccountsPayableID_M, txtDocumentNumber.Text))
                        For x As Integer = 0 To vDT.Rows.Count - 1
                            SQL &= String.Format(" UPDATE due_to SET AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID'), Paid = IF(Paid - {1} <= 0, 0,Paid - {1}) WHERE DocumentNumber = '{0}';", vDT(x)("DocumentNumber"), CDbl(vDT(x)("Paid")))
                        Next
                    Else
                        SQL &= String.Format(" UPDATE due_to SET Paid = IF(Paid - {1} <= 0, 0,Paid - {1}), AP_Status = IF(Paid - {1} <= 0,'APPROVED','PARTIALLY PAID') WHERE DocumentNumber = '{0}';", cbxPayee.SelectedValue, dDebitT.Value)
                    End If
                End If
                DataObject(SQL)
                Logs("Check Voucher", "Disapprove", Reason, String.Format("Disapprove Check Voucher of {0} with Amount {1}.", cbxPayee.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "")
                If From_PaymentRequest Then
                    With btnDisapprove
                        .DialogResult = DialogResult.Yes
                        .DialogResult = DialogResult.Yes
                        .PerformClick()
                    End With
                End If
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Disapproved", MsgBoxStyle.Information, "Info")
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
                    e.Appearance.ForeColor = OfficialColor2 'Color.Red
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
            Row("Remarks") = ""
            Row("RequiredRemarks") = ""
            Row("Paid For") = ""
            Row("BusinessCode") = ""
            Row("Type_ID") = 0
            Row("MotherCode") = ""
            Row("CreditNumber") = ""
            DT_Account.Rows.InsertAt(Row, If(GridView2.FocusedRowHandle >= 0, GridView2.FocusedRowHandle, 0))
        Else
            If drv("Type") = "C" Then
                Row("Account Code") = ""
                Row("Department Code") = ""
                Row("Account") = ""
                Row("Business Center") = DataObject(String.Format("SELECT BusinessCenter('{0}')", drv("VAT")))
                Row("Department") = ""
                Row("Debit") = 0
                Row("Credit") = 0
                Row("Remarks") = ""
                Row("RequiredRemarks") = ""
                Row("Paid For") = ""
                Row("BusinessCode") = drv("VAT")
                Row("Type_ID") = 0
                Row("MotherCode") = ""
                Row("CreditNumber") = ""
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
                Row("Paid For") = ""
                Row("BusinessCode") = ""
                Row("Type_ID") = 0
                Row("MotherCode") = ""
                Row("CreditNumber") = ""
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
            If GridColumn30.Visible = False Then
                GridColumn22.Width = 342 - 17
            Else
                GridColumn22.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn30.Visible = False Then
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
        Dim Total_CIB As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                Total_CIB += CDbl(DT_Account(x)("Credit"))
            End If
        Next
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB

        If GridView2.RowCount > 7 Then
            If GridColumn30.Visible = False Then
                GridColumn22.Width = 342 - 17
            Else
                GridColumn22.Width = (342 - 80) - 17
            End If
        Else
            If GridColumn30.Visible = False Then
                GridColumn22.Width = 342
            Else
                GridColumn22.Width = 342 - 80
            End If
        End If

        If GridView2.RowCount = 0 Then
            btnRemove_Account.Enabled = False
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
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Account").ToString = "" Then
                dAmount.Value = 0
            End If
        ElseIf e.Column.FieldName = "Credit" Then
            If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Credit").ToString = "" Then
                GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Credit", 0)
            ElseIf IsNumeric(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Credit")) = False Then
                MsgBox(String.Format("Incorrect {1} value for Credit under row {0}.", GridView2.FocusedRowHandle + 1, GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Credit")), MsgBoxStyle.Information, "Info")
                dCreditT.Value = 0
                Exit Sub
            End If
            Dim TotalCredit As Double
            Dim Total_CIB As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalCredit += CDbl(DT_Account(x)("Credit"))
                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                    Total_CIB += CDbl(DT_Account(x)("Credit"))
                End If
            Next
            dCreditT.Value = TotalCredit
            dAmount.Value = Total_CIB
        ElseIf e.Column.FieldName = "Account" Then
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
            Else
                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                If (drv("Vat") = "2" Or drv("Vat") = "3") And GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Account").ToString.Contains("Tax") Then
                    MsgBox("This Supplier is setup with Tax Exempt or Others, Please check your data.", MsgBoxStyle.Information, "Info")
                End If
            End If
            Dim Total_CIB As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                    Total_CIB += CDbl(DT_Account(x)("Credit"))
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

    Private Sub ICopy_Click(sender As Object, e As EventArgs) Handles iCopy.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        CopyMode = True
        If GridView1.GetFocusedRowCellValue("Payee_Type") = "APM" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "ARM" Then
            MultipleAP = True
            AccountsPayableID_M = GridView1.GetFocusedRowCellValue("MultipleAP")
            btnAdd_Account.Enabled = False
            btnRemove_Account.Enabled = False
        End If
        cbxPayee.Enabled = False
        FirstLoad = True
        cbxLA.Checked = False
        cbxCAS.Checked = False
        cbxSUP.Checked = False
        cbxEMP.Checked = False
        cbxAP.Checked = False
        cbxAR.Checked = False
        cbxDT.Checked = False
        cbxRC.Checked = False
        With GridView1
            If .GetFocusedRowCellValue("Payee_Type") = "APM" Or .GetFocusedRowCellValue("Payee_Type") = "AP" Then
                cbxAP.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "ARM" Or .GetFocusedRowCellValue("Payee_Type") = "AR" Then
                cbxAR.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "A" Then
                cbxCAS.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "C" Then
                cbxLA.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "S" Then
                cbxSUP.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "RC" Then
                cbxRC.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "DT" Then
                cbxDT.Checked = True
            ElseIf .GetFocusedRowCellValue("Payee_Type") = "E" Then
                cbxEMP.Checked = True
            End If
        End With
        LoadPayee()
        cbxLA.Enabled = False
        cbxCAS.Enabled = False
        cbxSUP.Enabled = False
        cbxEMP.Enabled = False
        cbxAP.Enabled = False
        cbxAR.Enabled = False
        cbxDT.Enabled = False
        cbxRC.Enabled = False
        cbxPayee.Enabled = True
        With GridView1
            cbxPayee.Text = .GetFocusedRowCellValue("Payee")
            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            dtpPostingDate.Value = Date.Now
            txtReferenceNumber.Text = .GetFocusedRowCellValue("Reference Number")
            txtCheckNumber.Text = .GetFocusedRowCellValue("Check Number")
            dtpCheck.Value = .GetFocusedRowCellValue("Check Date")
            rExplanation.Text = .GetFocusedRowCellValue("Explanation")
        End With

        DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = cv_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', IF(`Type` = 'D',Amount,0) AS 'Debit', IF(`Type` = 'C',Amount,0) AS 'Credit', Remarks, Required AS 'RequiredRemarks', PaidFor AS 'Paid For', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode, CreditNumber FROM cv_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
        GridControl2.DataSource = DT_Account
        Dim TotalDebit As Double
        Dim TotalCredit As Double
        Dim Total_CIB As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                Total_CIB += CDbl(DT_Account(x)("Credit"))
            End If
        Next
        dDebitT.Value = TotalDebit
        dDebitT.Tag = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub IClear_Click(sender As Object, e As EventArgs) Handles iClear.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED" Then
                If MsgBoxYes("Check Voucher is already CLEARED, would you like to proceed?") = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") <> "FOR CLEARING" Then
                MsgBox("Check Voucher is not yet FOR CLEARING.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim D As New FrmDate
        With D
            If GridView1.GetFocusedRowCellValue("Cleared Date").ToString = "" Then
                .dtpClear.Value = Date.Now
            Else
                .dtpClear.Value = GridView1.GetFocusedRowCellValue("Cleared Date")
            End If
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
                    SQL = String.Format("UPDATE check_voucher SET ClearedDate = '{1}' WHERE DocumentNumber IN ({0}) AND Voucher_Status = 'RECEIVED';", Docs, FormatDatePicker(.dtpClear))
                Else
                    SQL = String.Format("UPDATE check_voucher SET ClearedDate = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), FormatDatePicker(.dtpClear))
                End If
                DataObject(SQL)
                Logs("Check Voucher", "Clear Check", String.Format("Clear Check Voucher of {0} with the total amount of {1}.", GridView1.GetFocusedRowCellValue("Payee") & " - " & GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Amount")), "", "", "", "")
                MsgBox("Successfully Cleared!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxFinancing_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFinancing.CheckedChanged
        If cbxFinancing.Checked Then
            cbxROPOA.Enabled = True

            lblROPOAValue.Visible = True
            dROPOAValue.Visible = True
            lblSoldPrice.Visible = True
            dROPOAPayable.Visible = True
        Else
            cbxROPOA.SelectedIndex = -1
            cbxROPOA.Enabled = False

            lblROPOAValue.Visible = False
            dROPOAValue.Visible = False
            lblSoldPrice.Visible = False
            dROPOAPayable.Visible = False
        End If
    End Sub

    Private Sub CbxROPOA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxROPOA.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxROPOA.SelectedIndex = -1 Then
            dROPOAValue.Value = 0
            dROPOAPayable.Value = 0
        Else
            Dim drv As DataRowView = DirectCast(cbxROPOA.SelectedItem, DataRowView)
            dROPOAValue.Value = CDbl(drv("ROPOA Value"))
            dROPOAPayable.Value = CDbl(drv("ROPOA Payable"))
        End If
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

            Logs("Check Voucher", "View Computation", "Amortization Calculators", "", "", "", CreditNumber)
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

    Public Sub LoadCompanyMode()
        If CompanyMode = 0 Then
            cbxAccount.DataSource = DT_AccountsM.Copy
            RepositoryItemSearchLookUpEdit1.DataSource = DT_AccountsM_V2.Copy
        Else
            cbxAccount.DataSource = DT_Accounts.Copy
            RepositoryItemSearchLookUpEdit1.DataSource = DT_Accounts_V2.Copy
        End If
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
                    Dim DT_Excel As New DataTable
                    DT_Excel = DT_Account.Copy
                    con.ConnectionString = String.Format("Provider={0};Data Source={1};Extended Properties=""Excel 12.0 XML;HDR=Yes;""", "Microsoft.ACE.OLEDB.12.0", OFD.FileName)
                    Using cmd As New OleDb.OleDbCommand("SELECT * FROM [Sheet$]", con)
                        Using da As New OleDb.OleDbDataAdapter(cmd)
                            con.Open()
                            da.Fill(DT_Excel)
                            con.Close()
                        End Using
                    End Using

                    For x As Integer = 0 To DT_Excel.Rows.Count - 1
                        If DT_Excel(x)("Account Code").ToString = "" Then
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
                        DT_Account.Rows.Add(DT_Excel(x)("Account Code"), DT_Excel(x)("Department Code"), DT_Excel(x)("Account"), DT_Excel(x)("Business Center"), DT_Excel(x)("Department"), If(DT_Excel(x)("Debit") = "", 0, CDbl(DT_Excel(x)("Debit"))), If(DT_Excel(x)("Credit") = "", 0, CDbl(DT_Excel(x)("Credit"))), DT_Excel(x)("Remarks"), DT_Excel(x)("RequiredRemarks"), "", DT_Excel(x)("Business Code"), DT_Excel(x)("Type_ID"), DT_Excel(x)("MotherCode"), "")
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
                    Dim Total_CIB As Double
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        TotalDebit += CDbl(DT_Account(x)("Debit"))
                        TotalCredit += CDbl(DT_Account(x)("Credit"))
                        If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Cash in Bank") Then
                            Total_CIB += CDbl(DT_Account(x)("Credit"))
                        End If
                    Next
                    If GridView2.RowCount > 7 Then
                        If GridColumn30.Visible = False Then
                            GridColumn22.Width = 342 - 17
                        Else
                            GridColumn22.Width = (342 - 80) - 17
                        End If
                    Else
                        If GridColumn30.Visible = False Then
                            GridColumn22.Width = 342
                        Else
                            GridColumn22.Width = 342 - 80
                        End If
                    End If
                    dDebitT.Value = TotalDebit
                    dCreditT.Value = TotalCredit
                    dAmount.Value = Total_CIB
                    If GridView2.RowCount > 0 Then
                        btnRemove_Account.Enabled = True
                    Else
                        btnRemove_Account.Enabled = False
                    End If
                    Cursor = Cursors.Default
                Catch ex As Exception
                    Cursor = Cursors.Default
                    TriggerBugReport("Check Voucher - Download", ex.Message.ToString)
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
    End Sub

    Private Sub IJV_Click(sender As Object, e As EventArgs) Handles iJV.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Check Voucher is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS_JVNumber") <> "" Then
                MsgBox("Check Voucher is already DTS Journal Voucher. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Check Voucher is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Check Voucher is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Check Voucher is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf ((GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CLEARING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "APPROVED") Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED") And GridView1.GetFocusedRowCellValue("Payee_Type") = "A" Then
                MsgBox(String.Format("Check Voucher is already {0} and this Check Voucher is from CASH ADVANCE.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf (GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED") Then
                MsgBox(String.Format("Check Voucher is already {0}.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR DISBURSEMENT" And GridView1.GetFocusedRowCellValue("Payee_Type") = "C" Then
                MsgBox(String.Format("Check Voucher is still {0} and from Loans Application, Journal Voucher is allowed when Check Voucher is already Received.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS") = True Then
                If MsgBoxYes("This is a DTS Check Voucher, are you sure you want to Journal Voucher this? This will reverse the entry") = MsgBoxResult.No Then
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
            Logs("Check Voucher", "Journal Voucher", "Journal Voucher", "", "", "", "")
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
            .cbxCV.Checked = True
            .From_ACR = True
            .BankID = GridView1.GetFocusedRowCellValue("BankID")
            .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("ID")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub IJournalVoucherDTS_Click(sender As Object, e As EventArgs) Handles iJV_DTS.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Check Voucher is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS_JVNumber") <> "" Then
                MsgBox("Check Voucher is already DTS Journal Voucher. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Check Voucher is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Check Voucher is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
                MsgBox("Check Voucher is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf ((GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CLEARING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "APPROVED") Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED") And GridView1.GetFocusedRowCellValue("Payee_Type") = "A" Then
                MsgBox(String.Format("Check Voucher is already {0} and this Check Voucher is from CASH ADVANCE.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf (GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED") Then
                MsgBox(String.Format("Check Voucher is already {0}.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS") = False Then
                MsgBox("Check Voucher is not DTS.", MsgBoxStyle.Information, "Info")
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
            Logs("Check Voucher", "Journal Voucher [DTS]", "Journal Voucher", "", "", "", "")
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
            .DTS_From_CV = True
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
        If txtCheck.Text = "" Then
            'F O R   C H E C K I N G************************************************************************************************************************
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Updated Check Voucher of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
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
                GenerateCV(False, FName, txtCheck.Text, txtApproved.Text)
                AttachmentFiles.Add(FName)
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
            End If
            'F O R   C H E C K I N G************************************************************************************************************************
        ElseIf txtApproved.Text = "" Then
            'F O R   A P P R O V A L ***********************************************************************************************************************
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Updated Check Voucher of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
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
                GenerateCV(False, FName, txtCheck.Text, txtApproved.Text)
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
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Check Voucher of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
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
            GenerateCV(False, FName, txtCheck.Text, txtApproved.Text)
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
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Check Voucher of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayee.Text, dDebitT.Text, cbxPreparedBy.Text)
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
            GenerateCV(False, FName, txtCheck.Text, txtApproved.Text)
            AttachmentFiles.Add(FName)
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
        End If
    End Sub

    Private Sub CbxDTS_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDTS.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        CbxPayee_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub IRename_Click(sender As Object, e As EventArgs) Handles iRename.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "APM" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "AP" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "ARM" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "AR" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "A" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "C" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "RC" Or GridView1.GetFocusedRowCellValue("Payee_Type") = "DT" Then
                MsgBox("Change payee is not applicable on this transaction", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "APPROVED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR CLEARING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CLEARED" Then
                MsgBox(String.Format("Check Voucher is already {0}, please check your data.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Rename As New FrmRename
        With Rename
            Dim SQL As String = " SELECT "
            SQL &= "    ID,"
            SQL &= "    Branch AS 'Supplier',"
            SQL &= "    'B' AS 'Type',"
            SQL &= "    TIN,"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    Email_Address AS 'EmailAdd',"
            SQL &= "    0 AS 'Amount',"
            SQL &= "    1 AS 'VAT',"
            SQL &= "    Branch AS 'Name',"
            SQL &= "    '' AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    0 AS 'BankID',"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old'"
            SQL &= " FROM branch WHERE `status` = 'ACTIVE'"

            SQL &= " UNION ALL"
            SQL &= " SELECT  ID,"
            SQL &= "    Employee (ID) AS 'Supplier',"
            SQL &= "    'E' AS 'Type',"
            SQL &= "    '' AS 'TIN',"
            SQL &= "    Phone,"
            SQL &= "    EmailAdd,"
            SQL &= "    0 AS 'Amount',"
            SQL &= "    1 AS 'VAT',"
            SQL &= "    Employee (ID) AS 'Name',"
            SQL &= "    '' AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    0 AS 'BankID',"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old'"
            SQL &= " FROM employee_setup"
            SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ", Branch_ID)

            SQL &= " UNION ALL"
            SQL &= " SELECT ID,"
            SQL &= "    Supplier,"
            SQL &= "    'S' AS 'Type',"
            SQL &= "    TIN,"
            SQL &= "    '' AS 'Phone',"
            SQL &= "    EmailAddress AS 'EmailAdd',"
            SQL &= "    0 AS 'Amount',"
            SQL &= "    VAT,"
            SQL &= "    Supplier AS 'Name',"
            SQL &= "    '' AS 'PONumber',"
            SQL &= "    '' AS 'Explanation',"
            SQL &= "    0 AS 'BankID',"
            SQL &= "    DATE(NOW()) AS 'Due',"
            SQL &= "    '' AS 'CreditNumber_Old'"
            SQL &= " FROM supplier_setup"
            SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ", Branch_ID)
            SQL &= "    ORDER BY `Type`, `Supplier`"
            .cbxPayee.DisplayMember = "Supplier"
            .cbxPayee.ValueMember = "ID"
            .cbxPayee.DataSource = DataSource(SQL)
            .cbxPayee.Text = GridView1.GetFocusedRowCellValue("Payee")
            If .ShowDialog = DialogResult.OK Then
                Dim drv As DataRowView = DirectCast(.cbxPayee.SelectedItem, DataRowView)
                SQL = "UPDATE check_voucher SET"
                SQL &= String.Format(" Payee_ID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payee_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("Type")))
                SQL &= String.Format(" Payee = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number"))

                SQL &= "UPDATE due_from SET"
                SQL &= String.Format(" PayorID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payor_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("Type")))
                SQL &= String.Format(" Payor = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payor = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee"))

                SQL &= "UPDATE accounts_receivable SET"
                SQL &= String.Format(" PayorID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payor_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("Type")))
                SQL &= String.Format(" Payor = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payor = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee"))

                SQL &= "UPDATE due_to SET"
                SQL &= String.Format(" PayeeID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payee_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("Type")))
                SQL &= String.Format(" Payee = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payee = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee"))

                SQL &= "UPDATE accounts_payable SET"
                SQL &= String.Format(" PayeeID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payee_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("Type")))
                SQL &= String.Format(" Payee = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payee = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee"))

                SQL &= "UPDATE loans_payable SET"
                SQL &= String.Format(" PayeeID = '{0}', ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" Payee_Type = '{0}', ", If(.cbxPayee.SelectedIndex = -1, "", drv("Type")))
                SQL &= String.Format(" Payee = '{0}'", .cbxPayee.Text.InsertQuote)
                SQL &= String.Format(" WHERE JVNumberV2 = '{0}' AND Payee = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee"))

                SQL &= "UPDATE accounting_entry SET"
                SQL &= String.Format(" ReferenceN = '{0}' ", ValidateComboBox(.cbxPayee))
                SQL &= String.Format(" WHERE CVNum = '{0}' AND ReferenceN = '{1}';", GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payee_ID"))
                DataObject(SQL)
                LoadData()
                Logs("Check Voucher", "Change Payee", String.Format("Changed Payee Check Voucher from {0} to {1}.", GridView1.GetFocusedRowCellValue("Payee"), .cbxPayee.Text), "", "", "", "")
                MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
            Exit Sub
        End If

        Dim Ledger As New FrmAccountLedger
        With Ledger
            If GridView2.RowCount > 0 Then
                If GridView2.GetFocusedRowCellValue("CreditNumber") <> "" Then
                    .CreditNumber = GridView2.GetFocusedRowCellValue("CreditNumber")
                Else
                    .CreditNumber = cbxPayee.SelectedValue
                End If
            Else
                .CreditNumber = cbxPayee.SelectedValue
            End If
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") <> "C" Then
                MsgBox("Selected Check Voucher is not from Credit Application.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            If GridView1.GetFocusedRowCellValue("Payee_Type") = "C" Then
                .CreditNumber = GridView1.GetFocusedRowCellValue("Payee_ID")
            End If
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub ITag_Click(sender As Object, e As EventArgs) Handles iTag.Click
        Try
            If GridView2.GetFocusedRowCellValue("Account").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Tag As New FrmTagOldAccount
        With Tag
            .CreditNumber = GridView2.GetFocusedRowCellValue("CreditNumber")
            .OrigCreditNumber = cbxPayee.SelectedValue
            .AccountingEntry = GridView2.GetFocusedRowCellValue("Account")
            .Payee = cbxPayee.Text
            If .ShowDialog = DialogResult.OK Then
                DT_Account(GridView2.FocusedRowHandle)("CreditNumber") = .cbxAccount.SelectedValue
                GridView2.SetFocusedRowCellValue("Remarks", GridView2.GetFocusedRowCellValue("Remarks") & " [" & .cbxAccount.Text & "]")
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IDTS_Click(sender As Object, e As EventArgs) Handles iDTS.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Check Voucher is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS_JVNumber") <> "" Then
                MsgBox("Check Voucher is already DTS Journal Voucher. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Then
                MsgBox("Check Voucher is already CANCELLED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Then
                MsgBox("Check Voucher is already DISAPPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") <> "C" Then
                MsgBox("Check Voucher is not from Credit Application.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("DTS") = True Then
                MsgBox("Check Voucher is already set as DTS.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBox("Are you sure you want to Set this as DTS?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim Msg As String = ""
            Dim Subject As String = "One Time Authorization Code " & Code & " [" & GridView1.GetFocusedRowCellValue("Document Number") & "][DTS]"
            Dim FName As String = ""
            Dim EmailTo As String = ""
            Code = GenerateOTAC()
            Dim BM As DataTable = GetBM(Branch_ID)
            For x As Integer = 0 To BM.Rows.Count - 1
                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee").ToString.Trim)
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> setting Check Voucher {1} to DTS." & vbCrLf, Code, GridView1.GetFocusedRowCellValue("Document Number"))
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
                .lblBilling.Visible = False
                If .ShowDialog = DialogResult.OK Then
                Else
                    Cursor = Cursors.Default
                    Exit Sub
                End If
            End With

            DataObject(String.Format("UPDATE check_voucher SET DTS = 1 WHERE DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
            Logs("Check Voucher", "Set as DTS", String.Format("Set as DTS check voucher {0}.", GridView1.GetFocusedRowCellValue("Document Number")), "", "", "", "")
            LoadData()
            MsgBox("Successfully Set as DTS!", MsgBoxStyle.Information, "Info")
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CbxDeductBalanceDTS_CheckedChanged(sender As Object, e As EventArgs)
        CbxPayee_SelectedIndexChanged(sender, e)
    End Sub

    Private Sub CbxBank_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBank.SelectedIndexChanged
        If FirstLoad Or DT_Account.Columns.Count = 0 Then
            Exit Sub
        End If

        Dim drvP As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If cbxBank.Text = "" Or cbxBank.SelectedIndex = -1 Then
        Else
            Dim WithAccount As Boolean
            Dim NumberOfAccount As Integer
            Dim drv As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
            For x As Integer = 0 To GridView2.RowCount - 1
                If GridView2.GetRowCellValue(x, "Account Code") <> "" Then
                    NumberOfAccount += 1
                End If
                If GridView2.GetRowCellValue(x, "MotherCode") = "111000" Then
                    WithAccount = True
                End If

                If GridView2.GetRowCellValue(x, "MotherCode") = "111000" And GridView2.GetRowCellValue(x, "Credit") > 0 And GridView2.GetRowCellValue(x, "Debit") = 0 And GridView2.GetRowCellValue(x, "Account Code") <> drv("AccountCode") Then
                    AccountCodeDetails(drv("AccountCode"))
                    If DT_Temp_Account.Rows.Count > 0 Then
                        DT_Account(x)("Account Code") = DT_Temp_Account(0)("Code")
                        DT_Account(x)("Account") = DT_Temp_Account(0)("Account")
                        DT_Account(x)("RequiredRemarks") = DT_Temp_Account(0)("RequiredRemarks")
                        DT_Account(x)("MotherCode") = DT_Temp_Account(0)("MotherCode")
                    End If
                End If
            Next
            If NumberOfAccount <= 1 And If(NumberOfAccount = 1, WithAccount, WithAccount = False) And drv("AccountCode") <> "" Then
                DT_Account.Rows.Clear()
                AccountCodeDetails(drv("AccountCode"))
                If DT_Temp_Account.Rows.Count > 0 Then
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), "", "", 0, 0, "", DT_Temp_Account(0)("RequiredRemarks"), "", "", 0, DT_Temp_Account(0)("MotherCode"), "")
                End If
                DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", "", 0, "", "")
                DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", "", 0, "", "")
                DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", "", 0, "", "")
                DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", "", 0, "", "")
                DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", "", 0, "", "")
                DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", "", 0, "", "")
                DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", "", 0, "", "")
                DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", "", 0, "", "")
                DT_Account.Rows.Add("", "", "", "", "", 0, 0, "", "", "", "", 0, "", "")

                If GridView2.RowCount > 7 Then
                    If GridColumn30.Visible = False Then
                        GridColumn22.Width = 342 - 17
                    Else
                        GridColumn22.Width = (342 - 80) - 17
                    End If
                Else
                    If GridColumn30.Visible = False Then
                        GridColumn22.Width = 342
                    Else
                        GridColumn22.Width = 342 - 80
                    End If
                End If
            ElseIf drvP("Type") = "C" And AccountNumber = "" And cbxBank.SelectedValue <> If(DefaultBank = 0, drvP("BankID"), DefaultBank) And cbxBank.Text <> "" Then 'FROM CREDIT APPLICATION
                'MsgBox(cbxBank.SelectedValue & " <> " & If(DefaultBank = 0, drvP("BankID"), DefaultBank))
                CbxPayee_SelectedIndexChanged(sender, e)
            End If
        End If
    End Sub

    Private Sub BtnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click
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

            Logs("Check Voucher", "Verify Schedule", "Amortization Calculators", "", "", "", CreditNumber)
            .lblTitle.Text = "AMORTIZATION CALCULATOR"
            .ControlBox = True
            .MinimizeBox = False
            .MaximizeBox = False
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .FormBorderStyle = FormBorderStyle.FixedDialog
            .WindowState = FormWindowState.Normal
            .From_CV_VerifySchedule = True
            .PanelEx3.Enabled = False
            .PanelEx3.Visible = False
            .CreditNumber = cbxPayee.SelectedValue
            If .ShowDialog = DialogResult.OK Then
                LoadPayee()
                cbxPayee.SelectedValue = .CreditNumber
            End If
            .Dispose()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub IViewLedger_Click(sender As Object, e As EventArgs) Handles iViewLedger.Click
        Try
            If GridView2.GetFocusedRowCellValue("Account").ToString = "" Then
                Exit Sub
            ElseIf GridView2.GetFocusedRowCellValue("CreditNumber") = "" Then
                MsgBox("No tagged credit application.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = GridView2.GetFocusedRowCellValue("CreditNumber")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnReference_Click(sender As Object, e As EventArgs) Handles btnReference.Click
        GridView1.SetFocusedRowCellValue("Reference Number", UpdateReferenceNumber("Check Voucher", "check_voucher", GridView1.GetFocusedRowCellValue("Reference Number"), GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Document Number")))
    End Sub
End Class