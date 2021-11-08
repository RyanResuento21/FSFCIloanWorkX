Imports DevExpress.XtraReports.UI
Public Class FrmCaseSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean

    Private Sub FrmCaseSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        LoadData()
        cbxDisplay.SelectedIndex = 0
        dtpDate.Value = Date.Now
        dtpLastPayment.Value = Date.Now
        dtpDateFilled.Value = Date.Now
        dtpMovement.Value = Date.Now
        dtpActionDate.Value = Date.Now
        dtpRP.Value = Date.Now

        With txtProduct
            .ValueMember = "ID"
            .DisplayMember = "Product"
            .DataSource = Products.Copy
            .SelectedIndex = -1
        End With

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) ORDER BY `Code`;", Branch_ID, DefaultBankID))
            If DefaultBankID > 0 Then
                .Enabled = False
            Else
                .SelectedIndex = -1
            End If
        End With

        cbxBorrower.DisplayMember = "Borrower"
        cbxBorrower.ValueMember = "BorrowerID"
        LoadBorrower("", cbxOldAccount.Checked)
        cbxBorrower.SelectedIndex = -1

        With cbxCategory
            .DisplayMember = "Category"
            .ValueMember = "ID"
            .DataSource = DataSource(String.Format("SELECT ID, Category FROM case_category WHERE `status` = 'ACTIVE' ORDER BY `Rank`;"))
        End With

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd, `Position`, (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) AS 'Head', department_ID FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Employee`;", Branch_ID))
            .SelectedValue = Empl_ID
        End With

        With cbxLegalCounsel
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND position = 'LEGAL COUNSEL' AND branch_id = '{0}' ORDER BY `Employee`;", Branch_ID))
            .SelectedIndex = -1
        End With

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

            GetLabelFontSettings({LabelX2, LabelX10, LabelX6, LabelX16, LabelX3, LabelX1, LabelX5, LabelX4, LabelX12, LabelX21, LabelX24, LabelX13, LabelX14, lblMovementDate, LabelX18, LabelX19, lblActionDate, LabelX23, LabelX15, LabelX26, lblDecision, lblRP, LabelX8, LabelX17, LabelX22, LabelX9, LabelX20, LabelX40, LabelX42, LabelX41, LabelX39})

            GetLabelFontSettingsDefault({lblNote})

            GetLabelFontSettingsRed({LabelX25})

            GetTextBoxFontSettings({txtAccountNumber, txtAccountN, txtCollateral, txtCaseNumber})

            GetCheckBoxFontSettings({cbxAll, cbxITLDate, cbxMovementDate})

            GetCheckBoxFontSettingsDefault({cbxActive, cbxDismissed, cbxArchieved, cbxWrittenOff, cbxOldAccount})

            GetComboBoxFontSettings({cbxBorrower, txtProduct, cbxBank, cbxCategory, cbxSubCategory, cbxCaseType, cbxPreparedBy, cbxLegalCounsel, cbxDisplay})

            GetDateTimeInputFontSettings({dtpDate, dtpLastPayment, dtpDateFilled, dtpRP, dtpMovement, dtpActionDate, dtpFrom, dtpTo})

            GetDoubleInputFontSettings({dFaceAmount, dOutstanding, dBookValue, dDecisionValue})

            GetRickTextBoxFontSettings({txtActionPlan, txtRemarks, txtReasons})

            GetGroupControlFontSettings({GroupControl1, GroupControl2})

            GetContextMenuBarFontSettings({ContextMenuBar1})

            GetButtonFontSettings({btnAccountLedger, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAttach, btnSearch})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Case Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Case Setup", lblTitle.Text)
    End Sub

    Private Sub CbxOldAccount_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOldAccount.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxOldAccount.Checked Then
            txtAccountN.Enabled = True
            txtProduct.Enabled = True
            txtCollateral.Enabled = True
            dFaceAmount.Enabled = True
            dOutstanding.Enabled = True
            dtpLastPayment.Enabled = True
            cbxBank.Enabled = True

            txtAccountN.Text = ""
            txtProduct.Text = ""
            txtCollateral.Text = ""
            dFaceAmount.Value = 0
            dOutstanding.Value = 0
            dtpLastPayment.Value = Date.Now
            btnAccountLedger.Enabled = False
        Else
            txtAccountN.Enabled = False
            txtProduct.Enabled = False
            txtCollateral.Enabled = False
            dFaceAmount.Enabled = False
            dOutstanding.Enabled = False
            dtpLastPayment.Enabled = False
            dtpRP.Visible = False
            cbxBank.Enabled = False
            btnAccountLedger.Enabled = True
        End If

        LoadBorrower("", cbxOldAccount.Checked)

        If cbxOldAccount.Checked Then
            If cbxCategory.Text = "ON GOING CASE" Or cbxCategory.Text = "" Then
                lblRP.Visible = False
                dtpRP.Visible = False
            Else
                lblRP.Visible = True
                dtpRP.Visible = True
            End If
            dtpRP.CustomFormat = ""
        Else
            Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
            Dim drv_P As DataRowView = DirectCast(txtProduct.SelectedItem, DataRowView)
            Try
                If drv_P("mortgage_id") = 2 Then
                    If cbxCategory.Text = "ON GOING CASE" Or cbxCategory.Text = "" Then
                        lblRP.Visible = False
                        dtpRP.Visible = False
                    Else
                        lblRP.Visible = True
                        dtpRP.Visible = True
                    End If
                    dtpRP.CustomFormat = "MMMM dd, yyyy"
                Else
                    lblRP.Visible = False
                    dtpRP.Visible = False
                    dtpRP.CustomFormat = ""
                End If
            Catch ex As Exception
                lblRP.Visible = False
                dtpRP.Visible = False
                dtpRP.CustomFormat = ""
            End Try
        End If
    End Sub

    Private Sub LoadBorrower(CreditNumber As String, Old As Boolean)
        Dim SQL As String
        If Old Then
            SQL = "SELECT "
            SQL &= "   BorrowerID, '' AS 'CreditNumber',"
            SQL &= "   CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Borrower',"
            SQL &= "   '' AS 'Product',"
            SQL &= "   0 AS 'Face_Amount',"
            SQL &= "   '' AS 'Account Number',"
            SQL &= "   '' AS 'Collateral',"
            SQL &= "   0 AS 'Outstanding',"
            SQL &= "   0 AS 'RPPD',"
            SQL &= "   0 AS 'Book Value',"
            SQL &= "   '' AS 'Last Payment'"
            SQL &= " FROM profile_borrower "
            SQL &= "   WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("   AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= " UNION ALL SELECT "
            SQL &= "   BorrowerID, '' AS 'CreditNumber',"
            SQL &= "   TradeName AS 'Borrower',"
            SQL &= "   '' AS 'Product',"
            SQL &= "   0 AS 'Face_Amount',"
            SQL &= "   '' AS 'Account Number',"
            SQL &= "   '' AS 'Collateral',"
            SQL &= "   0 AS 'Outstanding',"
            SQL &= "   0 AS 'RPPD',"
            SQL &= "   0 AS 'Book Value',"
            SQL &= "   '' AS 'Last Payment'"
            SQL &= " FROM profile_corporation "
            SQL &= "   WHERE `status` = 'ACTIVE' "
            SQL &= String.Format("   AND Branch_ID IN ({0}) ORDER BY `Borrower`;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Else
            SQL = "SELECT "
            SQL &= "   BorrowerID, CreditNumber,"
            SQL &= "   CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)), ' [', CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)),']') AS 'Borrower',"
            SQL &= "   Product,"
            SQL &= "   Face_Amount,"
            SQL &= "   CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)) AS 'Account Number',"
            SQL &= "   IFNULL((SELECT GROUP_CONCAT(Collateral) FROM credit_investigation WHERE `status` = 'ACTIVE' AND credit_investigation.CreditNumber = C.CreditNumber),'') AS 'Collateral',"
            SQL &= "   (C.interest + AmountApplied - IFNULL(A.LR, 0)) AS 'Outstanding',"
            SQL &= "   (C.interest - IFNULL(A.Interest, 0)) AS 'Interest',"
            SQL &= "   (C.AmountApplied - IFNULL(A.PrincipalB, 0)) AS 'Principal',"
            SQL &= "   (C.RPPD - IFNULL(A.RPPD, 0)) AS 'RPPD',"
            SQL &= "   (C.Face_Amount - IFNULL(A.LR, 0)) AS 'Book Value',"
            SQL &= "   IFNULL(ORDate,'') AS 'Last Payment', mortgage_id, BankID, (SELECT BusinessCenter FROM business_center WHERE ID = BusinessID) AS 'BusinessCenter'"
            SQL &= " FROM credit_application C"
            SQL &= "   LEFT JOIN (SELECT ID, SUM(Amount) AS `Amount`, ReferenceN, MAX(ORDate) AS 'ORDate', SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END)  AS 'PrincipalB', SUM(CASE WHEN PaidFor IN ('Principal','UDI','RPPD','RPPD-A','RPPD-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END)  AS 'LR', SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END)  AS 'RPPD', SUM(CASE WHEN PaidFor IN ('UDI') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END)  AS 'Interest' FROM accounting_entry WHERE `status` = 'ACTIVE' AND PaidFor IN ('RPPD','RPPD-A','RPPD-W','Principal','UDI') GROUP BY ReferenceN) A ON A.ReferenceN = C.CreditNumber"
            SQL &= "   WHERE C.`status` = 'ACTIVE' "
            SQL &= String.Format("   AND C.`PaymentRequest` IN ('RELEASED','{1}') AND Branch_ID IN ({0}) AND IF('{1}' = '',TRUE,CreditNumber = '{2}') ORDER BY `Borrower`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), If(CreditNumber = "", "", "CLOSED"), CreditNumber)
        End If
        cbxBorrower.DataSource = DataSource(SQL)

        If GridView1.RowCount > 19 Then
            GridColumn3.Width = 244 - 17
        Else
            GridColumn3.Width = 244
        End If
    End Sub

    Private Sub CbxCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCategory.SelectedIndexChanged
        Try
            If cbxCategory.SelectedIndex = -1 Or cbxCategory.Text = "" Then
                cbxSubCategory.DataSource = Nothing
                cbxSubCategory.Text = ""
            Else
                With cbxSubCategory
                    .DisplayMember = "SubCategory"
                    .ValueMember = "ID"
                    .DataSource = DataSource(String.Format("SELECT ID, SubCategory, IFNULL(Date_Label,'') AS 'Date Label' FROM case_subcategory WHERE `status` = 'ACTIVE' AND CategoryID = '{0}' ORDER BY `Rank`;", cbxCategory.SelectedValue))
                    If .Items.Count = 0 Then
                        .DataSource = Nothing
                        .Text = ""
                    End If
                End With

                If cbxCategory.Text = "ON GOING CASE" Or cbxCategory.Text = "" Then
                    lblDecision.Visible = False
                    dDecisionValue.Visible = False

                    lblRP.Visible = False
                    dtpRP.Visible = False
                Else
                    lblDecision.Visible = True
                    dDecisionValue.Visible = True

                    Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
                    Dim drv_P As DataRowView = DirectCast(txtProduct.SelectedItem, DataRowView)
                    Try
                        If drv_P("mortgage_id") = 2 Then
                            If cbxCategory.Text = "ON GOING CASE" Or cbxCategory.Text = "" Then
                                lblRP.Visible = False
                                dtpRP.Visible = False
                            Else
                                lblRP.Visible = True
                                dtpRP.Visible = True
                            End If
                            dtpRP.CustomFormat = "MMMM dd, yyyy"
                        Else
                            lblRP.Visible = False
                            dtpRP.Visible = False
                            dtpRP.CustomFormat = ""
                        End If
                    Catch ex As Exception
                        lblRP.Visible = True
                        dtpRP.Visible = True
                        dtpRP.CustomFormat = ""
                    End Try
                End If
            End If

            'MOVEMENT OF CATEGORY AND SUBCATEGORY
            If cbxBorrower.Enabled = False Then
                LoadCategory()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadCategory()
        Dim DT As DataTable = DataSource(String.Format("SELECT ID, ActionPlan, DATE_FORMAT(ActionDate,'%M %d, %Y') AS 'ActionDate', MovementDate, Remarks, Reason FROM case_details WHERE `status` = 'ACTIVE' AND CaseID = '{0}' AND CategoryID = '{1}' AND SubCategoryID = '{2}' LIMIT 1;", ID, ValidateComboBox(cbxCategory), ValidateComboBox(cbxSubCategory)))
        If DT.Rows.Count > 0 Then
            lblNote.Visible = False
            cbxCategory.Tag = cbxCategory.Text
            dtpMovement.Value = DT(0)("MovementDate")
            dtpMovement.Tag = DT(0)("MovementDate")
            txtActionPlan.Text = DT(0)("ActionPlan")
            txtActionPlan.Tag = DT(0)("ActionPlan")
            dtpActionDate.Value = DT(0)("ActionDate")
            dtpActionDate.Tag = DT(0)("ActionDate")
            txtRemarks.Text = DT(0)("Remarks")
            txtRemarks.Tag = DT(0)("Remarks")
            txtReasons.Text = DT(0)("Reason")
            txtReasons.Tag = DT(0)("Reason")
        Else
            lblNote.Visible = True
            txtActionPlan.Text = ""
            dtpMovement.Value = Date.Now
            dtpActionDate.Value = Date.Now
            txtRemarks.Text = ""
            txtReasons.Text = ""
        End If
    End Sub

    Private Sub CbxCategory_TextChanged(sender As Object, e As EventArgs) Handles cbxCategory.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If cbxCategory.Text = "" Then
                cbxSubCategory.DataSource = Nothing
                cbxSubCategory.Text = ""
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub CbxBorrower_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBorrower.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            If cbxBorrower.SelectedIndex = -1 Or cbxBorrower.Text = "" Then
                txtAccountN.Text = ""
                txtProduct.Text = ""
                txtCollateral.Text = ""
                dFaceAmount.Value = 0
                dOutstanding.Value = 0
                dBookValue.Value = 0
                If cbxCategory.Text = "ON GOING CASE" Or cbxCategory.Text = "" Then
                    lblRP.Visible = False
                    dtpRP.Visible = False
                Else
                    lblRP.Visible = True
                    dtpRP.Visible = True
                End If
                dtpRP.CustomFormat = ""
                dBookValue.Value = 0
                dDecisionValue.Value = 0
                dtpLastPayment.Value = Date.Now
                btnAccountLedger.Enabled = False
            Else
                Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
                If cbxBorrower.Enabled Then
                    txtAccountN.Text = drv("Account Number")
                    txtProduct.Text = drv("Product")
                    Dim drv_P As DataRowView = DirectCast(txtProduct.SelectedItem, DataRowView)
                    dFaceAmount.Value = drv("Book Value")
                    dOutstanding.Value = drv("Principal")
                    dBookValue.Value = drv("Principal")
                    txtCollateral.Text = drv("Collateral")
                    cbxBank.SelectedValue = drv("BankID")
                    If drv("Last Payment") = "" Then
                    Else
                        dtpLastPayment.Value = drv("Last Payment")
                    End If
                    If drv_P("mortgage_id") = 2 Then
                        If cbxCategory.Text = "ON GOING CASE" Or cbxCategory.Text = "" Then
                            lblRP.Visible = False
                            dtpRP.Visible = False
                        Else
                            lblRP.Visible = True
                            dtpRP.Visible = True
                        End If
                        dtpRP.CustomFormat = "MMMM dd, yyyy"
                    Else
                        lblRP.Visible = False
                        dtpRP.Visible = False
                        dtpRP.CustomFormat = ""
                    End If
                    btnAccountLedger.Enabled = True
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT M.ID,"
        SQL &= "    M.CreditNumber, BorrowerID,"
        SQL &= "    IF(Old_Account = 1,Borrower(M.BorrowerID),CONCAT(Borrower_Credit (M.CreditNumber), ' [', AccountNumber(M.CreditNumber),']')) AS 'Borrower',"
        SQL &= "    DATE_FORMAT(M.TransDate, '%M %d, %Y') AS 'Date',"
        SQL &= "    M.AccountNumber AS 'Account Number',"
        SQL &= "    M.CaseNumber AS 'Case Number',"
        SQL &= "    DATE_FORMAT(M.DateFilled, '%M %d, %Y') AS 'Date Filled',"
        If cbxAll.Checked Then
            SQL &= "    Ledger_Balance(M.AccountNumber,M.MortgageID) AS 'Book Value',"
        Else
            SQL &= String.Format("    Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID) AS 'Book Value',", Format(dtpTo.Value, "yyyy-MM-dd"))
        End If
        SQL &= "    M.DecisionValue AS 'Decision Value',"
        SQL &= "    Category(M.CategoryID) AS 'Category',"
        SQL &= "    Subcategory(M.SubCategoryID) AS 'SubCategory',"
        SQL &= "    DATE_FORMAT(D.MovementDate, '%M %d, %Y') AS 'Movement Date',"
        SQL &= "    M.CaseType AS 'Case Type',"
        SQL &= "    D.ID AS 'Details ID',"
        SQL &= "    D.ActionPlan AS 'Action Plan',"
        SQL &= "    DATE_FORMAT(D.ActionDate, '%M %d, %Y') AS 'Action Date',"
        SQL &= "    Employee(M.PreparedID) AS 'Prepared By',"
        SQL &= "    Employee(M.CounselID) AS 'Legal Counsel',"
        SQL &= "    M.PreparedID, M.CounselID, M.Counsel, AccountN, Product, Collateral, FaceAmount, Outstanding, LastPayment, M.BookValue, M.BankID, "
        SQL &= "    D.Remarks,"
        SQL &= "    D.Reason, Attach, Case_Status, Old_Account, M.CategoryID, LastModified, DueRP, IFNULL((SELECT Collateral FROM credit_investigation WHERE `status` = 'ACTIVE' AND credit_investigation.CreditNumber = M.CreditNumber),'') AS 'Collateral', AccountNumber(M.CreditNumber) AS 'AccountNum', IF(M.BorrowerID LIKE '%C%',(SELECT Telephone FROM profile_corporation WHERE profile_corporation.BorrowerID = M.BorrowerID),(SELECT Mobile_B FROM profile_borrower WHERE profile_borrower.BorrowerID = M.BorrowerID)) AS 'Mobile', Branch(BranchID) AS 'Branch'"
        SQL &= "  FROM case_main M LEFT JOIN (SELECT ID, CaseID, CategoryID, SubCategoryID, MovementDate, Remarks, ActionPlan, Reason, ActionDate FROM case_details WHERE `status` = 'ACTIVE') D ON M.ID = D.CaseID AND M.CategoryID = D.CategoryID AND M.SubCategoryID = D.SubCategoryID WHERE M.`status` = 'ACTIVE' "
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE({2}) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo), If(cbxITLDate.Checked, "TransDate", "D.MovementDate"))
        End If
        If cbxActive.Checked = False And cbxDismissed.Checked = False And cbxArchieved.Checked = False And cbxWrittenOff.Checked = False Then
        Else
            SQL &= " AND (case_status = 'FULLY PAID' OR"
            If cbxActive.Checked Then
                SQL &= " case_status = 'ACTIVE'"
                If cbxDismissed.Checked Or cbxArchieved.Checked Or cbxWrittenOff.Checked Then
                    SQL &= " OR "
                End If
            End If
            If cbxDismissed.Checked Then
                SQL &= " case_status = 'DISMISSED'"
                If cbxArchieved.Checked Or cbxWrittenOff.Checked Then
                    SQL &= " OR "
                End If
            End If
            If cbxArchieved.Checked Then
                SQL &= " case_status = 'ARCHIVED'"
                If cbxWrittenOff.Checked Then
                    SQL &= " OR "
                End If
            End If
            If cbxWrittenOff.Checked Then
                SQL &= " case_status = 'WRITTEN OFF'"
            End If
            SQL &= ")"
        End If
        SQL &= String.Format("  AND BranchID IN ({0}) ORDER BY M.AccountNumber DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If Branch_ID = 0 Or (MultipleBranch And Multiple_ID <> "") Then
            GridColumn22.Visible = True
        Else
            GridColumn22.Visible = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Case_Status"))
            If Status = "ACTIVE" Then
                e.Appearance.ForeColor = Color.SeaGreen
            ElseIf Status = "DISMISSED" Then
                e.Appearance.ForeColor = Color.IndianRed
            ElseIf Status = "ARCHIVED" Then
                e.Appearance.ForeColor = Color.Orange
            ElseIf Status = "WRITTEN OFF" Then
                e.Appearance.ForeColor = Color.RoyalBlue
            ElseIf Status = "FULLY PAID" Then
                e.Appearance.ForeColor = Color.SeaGreen
                e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
            End If
        End If
    End Sub

    Private Sub GetAccountNumber()
        If btnSave.Text = "&Save" Then
            txtAccountNumber.Text = DataObject(String.Format("SELECT CONCAT('CASE-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,5,'0')) FROM case_main WHERE BranchID = '{0}' AND YEAR(TransDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDate.Value, "yy"), Format(dtpDate.Value, "yyyy-MM-dd")))
        End If
    End Sub

#Region "Keydown"
    Private Sub CbxBorrower_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBorrower.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDate.Focus()
        End If
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtAccountN.Enabled Then
                txtAccountN.Focus()
            Else
                txtCaseNumber.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            dtpDate.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtAccountN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAccountN.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtProduct.Focus()
        End If
    End Sub

    Private Sub TxtProduct_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProduct.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCollateral.Focus()
        End If
    End Sub

    Private Sub TxtCollateral_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCollateral.KeyDown
        If e.KeyCode = Keys.Enter Then
            dFaceAmount.Focus()
        End If
    End Sub

    Private Sub DFaceAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dFaceAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            dOutstanding.Focus()
        End If
    End Sub

    Private Sub DOutstanding_KeyDown(sender As Object, e As KeyEventArgs) Handles dOutstanding.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpLastPayment.Focus()
        End If
    End Sub

    Private Sub DtpLastPayment_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpLastPayment.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCaseNumber.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            dtpLastPayment.CustomFormat = ""
        End If
    End Sub

    Private Sub CbxCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSubCategory.Focus()
        End If
    End Sub

    Private Sub CbxSubCategory_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSubCategory.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpMovement.Focus()
        End If
    End Sub

    Private Sub DtpMovement_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpMovement.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCaseType.Focus()
        ElseIf e.KeyCode = Keys.Escape Then
            dtpMovement.CustomFormat = ""
        End If
    End Sub

    Private Sub CbxCaseType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCaseType.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBookValue.Focus()
        End If
    End Sub

    Private Sub TxtCaseNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCaseNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDateFilled.Focus()
        End If
    End Sub

    Private Sub DtpDateFilled_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDateFilled.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpRP.Visible Then
                dtpRP.Focus()
            Else
                cbxCategory.Focus()
            End If
        ElseIf e.KeyCode = Keys.Escape Then
            dtpDateFilled.CustomFormat = ""
        End If
    End Sub

    Private Sub DtpRP_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpRP.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCategory.Focus()
        ElseIf e.KeyCode = Keys.Escape Or e.KeyCode = Keys.Delete Then
            dtpRP.CustomFormat = ""
        End If
    End Sub

    Private Sub DBookValue_KeyDown(sender As Object, e As KeyEventArgs) Handles dBookValue.KeyDown
        If e.KeyCode = Keys.Enter Then
            dDecisionValue.Focus()
        End If
    End Sub

    Private Sub DDecisionValue_KeyDown(sender As Object, e As KeyEventArgs) Handles dDecisionValue.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtActionPlan.Focus()
        End If
    End Sub

    Private Sub TxtActionPlan_KeyDown(sender As Object, e As KeyEventArgs) Handles txtActionPlan.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpActionDate.Focus()
        End If
    End Sub

    Private Sub DtpActionDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpActionDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReasons.Focus()
        End If
    End Sub

    Private Sub TxtReasons_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReasons.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPreparedBy.Focus()
        End If
    End Sub

    Private Sub CbxPreparedBy_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPreparedBy.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxLegalCounsel.Focus()
        End If
    End Sub

    Private Sub CbxLegalCounsel_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxLegalCounsel.KeyDown
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
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnAttach.Visible = True
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)

                LoadBorrower("", cbxOldAccount.Checked)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        ID = 0
        btnSave.Text = "&Save"
        dtpDate.CustomFormat = ""
        dBookValue.Enabled = True
        PanelEx10.Enabled = True
        cbxBorrower.Enabled = True
        dtpDate.Enabled = True
        cbxBorrower.SelectedIndex = -1
        cbxCaseType.SelectedIndex = -1
        dtpDate.Value = Date.Now
        cbxCategory.SelectedIndex = -1
        txtCaseNumber.Text = ""
        dtpDateFilled.Value = Date.Now
        dBookValue.Value = 0
        dDecisionValue.Value = 0
        txtActionPlan.Text = ""
        dtpActionDate.Value = Date.Now
        txtRemarks.Text = ""
        txtReasons.Text = ""
        cbxPreparedBy.SelectedValue = Empl_ID
        cbxLegalCounsel.Text = ""

        cbxOldAccount.Enabled = True
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxBorrower.Text = "" Or cbxBorrower.SelectedIndex = -1 Then
            MsgBox("Please select Defendant.", MsgBoxStyle.Information, "Info")
            cbxBorrower.DroppedDown = True
            Exit Sub
        End If
        If FormatDatePicker(dtpDate) = "" Then
            MsgBox("Please fill the ITL Date.", MsgBoxStyle.Information, "Info")
            dtpDate.Focus()
            Exit Sub
        End If
        If txtProduct.Text = "" Or txtProduct.SelectedIndex = -1 Then
            MsgBox("Please select Product.", MsgBoxStyle.Information, "Info")
            txtProduct.DroppedDown = True
            Exit Sub
        End If
        If cbxBank.SelectedIndex = -1 Or cbxBank.Text = "" Then
            MsgBox("Please select Bank.", MsgBoxStyle.Information, "Info")
            cbxBank.DroppedDown = True
            Exit Sub
        End If
        If txtCaseNumber.Text.Trim = "" Then
            MsgBox("Please fill Case Number.", MsgBoxStyle.Information, "Info")
            txtCaseNumber.Focus()
            Exit Sub
        End If
        If cbxCategory.Text = "" Or cbxCategory.SelectedIndex = -1 Then
            MsgBox("Please select Category.", MsgBoxStyle.Information, "Info")
            cbxCategory.DroppedDown = True
            Exit Sub
        End If
        If cbxCaseType.Text = "" Or cbxCaseType.SelectedIndex = -1 Then
            MsgBox("Please select Case Type.", MsgBoxStyle.Information, "Info")
            cbxCaseType.DroppedDown = True
            Exit Sub
        End If
        If dBookValue.Value = 0 Then
            If MsgBoxYes("Book Value is set to zero, would you like to proceed?.") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If dDecisionValue.Value > 0 And dDecisionValue.Value < dBookValue.Value Then
            If MsgBoxYes("Decision Value is less than the Book Value, would you like to proceed?") = MsgBoxResult.No Then
                dDecisionValue.Focus()
                Exit Sub
            End If
        End If
        If cbxPreparedBy.SelectedIndex = -1 Or cbxPreparedBy.Text = "" Then
            MsgBox("Please select Prepared By.", MsgBoxStyle.Information, "Info")
            cbxPreparedBy.DroppedDown = True
            Exit Sub
        End If
        If cbxLegalCounsel.Text = "" Then
            If MsgBox("No Legal Counsel selected, would you like to proceed?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If

        Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
        Dim drv_P As DataRowView = DirectCast(txtProduct.SelectedItem, DataRowView)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim JournalVoucher As String = ""
                If cbxOldAccount.Checked Then
                Else
                    Dim JV As New FrmJournalVoucher
                    With JV
                        If FrmMain.lblDate.Text.Contains("Disconnected") Then
                            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                            Cursor = Cursors.Default
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
                            Cursor = Cursors.Default
                            Exit Sub
                        End If

                        .From_Case = True
                        .BankID = cbxBank.SelectedValue
                        .cbxPayee.Tag = cbxBorrower.Text
                        .txtReferenceNumber.Text = txtAccountNumber.Text
                        .txtReferenceNumber.Tag = txtAccountNumber.Text
                        .txtORNumber.Tag = drv("CreditNumber")
                        .rExplanation.Tag = txtActionPlan.Text
                        .Case_BV = dBookValue.Value

                        If cbxOldAccount.Checked = False Then
                            .Case_Principal = CDbl(drv("Principal"))
                            .Case_Interest = CDbl(drv("Interest"))
                            .Case_RPPD = CDbl(drv("RPPD"))
                        End If
                        .Case_OldAccount = cbxOldAccount.Checked
                        If drv_P("Mortgage_ID") = 1 Then
                            .Case_Debit = "112301"
                            .Case_Credit_LR = "112001"
                            .Case_Credit_Interest = "420001"
                            .Case_Credit_RPPD = "420003"
                        ElseIf drv_P("Mortgage_ID") = 2 Then
                            .Case_Debit = "112302"
                            .Case_Credit_LR = "112002"
                            .Case_Credit_Interest = "420002"
                            .Case_Credit_RPPD = "420004"
                        Else
                            .Case_Debit = "112303"
                            .Case_Credit_LR = "112003"
                            .Case_Credit_Interest = "420006"
                            .Case_Credit_RPPD = "420007"
                        End If
                        If .ShowDialog = DialogResult.OK Then
                            JournalVoucher = .txtDocumentNumber.Text
                            DataObject(String.Format("UPDATE accounting_entry SET ReferenceN = '{0}' WHERE JVNum = '{1}' AND CVNumber = '{1}' AND `status` = 'ACTIVE';", txtAccountNumber.Text, JournalVoucher))
                        Else
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    End With
                End If

                Dim BM As DataTable = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE `Position` IN ('OFFICER-IN-CHARGE','BRANCH MANAGER','CORPORATE LAWYER') AND `status` = 'ACTIVE' AND IF(`Position` = 'CORPORATE LAWYER',TRUE, Branch_ID = '{0}');", Branch_ID))
                For x As Integer = 0 To BM.Rows.Count - 1
                    Dim Msg As String = String.Format("Good day {0},<br><br>" & vbCrLf, BM(x)("Employee"))
                    Msg &= String.Format("  New Case Added with Case Number {0} for {1} with Book Value {2}.<br><br>" & vbCrLf, txtCaseNumber.Text, cbxBorrower.Text, dBookValue.Text)
                    Msg &= String.Format("Category: {0}<br>" & vbCrLf, cbxCategory.Text)
                    Msg &= String.Format("SubCategory: {0}<br>" & vbCrLf, cbxSubCategory.Text)
                    Msg &= String.Format("Action Plan: {0}<br>" & vbCrLf, txtActionPlan.Text)
                    Msg &= String.Format("{1}: {0}<br>" & vbCrLf, dtpActionDate.Text, lblActionDate.Text.Replace(":", ""))
                    Msg &= String.Format("Remarks: {0}<br>" & vbCrLf, txtRemarks.Text)
                    Msg &= String.Format("Reason: {0}<br>" & vbCrLf, txtReasons.Text)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If BM(x)("Phone") = "" Then
                    Else
                        SendSMS(BM(x)("Phone"), Msg, False)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If BM(x)("EmailAdd") = "" Then
                    Else
                        Dim Subject As String = "New Case Added [" & txtCaseNumber.Text & "] - " & txtAccountNumber.Text
                        SendEmail(BM(x)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                    End If
                Next

                GetAccountNumber()
                'INSERT MAIN
                Dim SQL As String = "INSERT INTO case_main SET"
                SQL &= String.Format(" BorrowerID = '{0}', ", cbxBorrower.SelectedValue)
                SQL &= String.Format(" CreditNumber = '{0}', ", drv("CreditNumber"))
                SQL &= String.Format(" Old_Account = '{0}', ", If(cbxOldAccount.Checked, 1, 0))
                SQL &= String.Format(" TransDate = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" AccountNumber = '{0}', ", txtAccountNumber.Text)
                SQL &= String.Format(" BranchID = '{0}', ", Branch_ID)
                SQL &= String.Format(" CaseNumber = '{0}', ", txtCaseNumber.Text)
                SQL &= String.Format(" DateFilled = '{0}', ", FormatDatePicker(dtpDateFilled))
                SQL &= String.Format(" BookValue = '{0}', ", dBookValue.Value)
                SQL &= String.Format(" DecisionValue = '{0}', ", dDecisionValue.Value)
                SQL &= String.Format(" DueRP = '{0}', ", FormatDatePicker(dtpRP))
                If cbxCategory.Text = "ON GOING CASE" Or cbxCategory.Text = "DECIDED CASE" Or cbxCategory.Text = "EXECUTED CASE" Then
                    SQL &= " case_status = 'ACTIVE', "
                ElseIf cbxCategory.Text = "DISMISSED CASE" Then
                    SQL &= " case_status = 'DISMISSED', "
                ElseIf cbxCategory.Text = "ARCHIVED CASE" Then
                    SQL &= " case_status = 'ARCHIVED', "
                ElseIf cbxCategory.Text = "WRITE OFF" Then
                    SQL &= " case_status = 'WRITTEN OFF', "
                End If
                SQL &= String.Format(" CategoryID = '{0}', ", cbxCategory.SelectedValue)
                SQL &= String.Format(" SubCategoryID = '{0}', ", ValidateComboBox(cbxSubCategory))
                SQL &= String.Format(" CaseType = '{0}', ", cbxCaseType.Text)
                SQL &= String.Format(" LastModified = '{0}', ", Format(Date.Now, "yyyy-MM-dd"))
                SQL &= String.Format(" AccountN = '{0}', ", txtAccountN.Text)
                SQL &= String.Format(" Product = '{0}', ", txtProduct.Text)
                SQL &= String.Format(" MortgageID = '{0}', ", drv_P("mortgage_id"))
                SQL &= String.Format(" Collateral = '{0}', ", txtCollateral.Text)
                SQL &= String.Format(" FaceAmount = '{0}', ", dFaceAmount.Value)
                SQL &= String.Format(" Outstanding = '{0}', ", dOutstanding.Value)
                SQL &= String.Format(" PreparedID = '{0}', ", ValidateComboBox(cbxPreparedBy))
                SQL &= String.Format(" CounselID = '{0}', ", ValidateComboBox(cbxLegalCounsel))
                SQL &= String.Format(" Counsel = '{0}', ", cbxLegalCounsel.Text.InsertQuote)
                SQL &= String.Format(" LastPayment = '{0}', ", FormatDatePicker(dtpLastPayment))
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" JournalVoucher = '{0}', ", JournalVoucher)
                SQL &= String.Format(" User_Code = '{0}';", User_Code)
                'UPDATE CREDIT APPLICATION
                SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'CLOSED', ClosedDate = '{1}' WHERE CreditNumber = '{0}';", drv("CreditNumber"), Format(dtpDate.Value, "yyyy-MM-dd"))
                DataObject(SQL)

                'INSERT DETAILS
                ID = DataObject(String.Format("SELECT MAX(ID) FROM case_main WHERE AccountNumber = '{0}';", txtAccountNumber.Text))
                SQL = "INSERT INTO case_details SET"
                SQL &= String.Format(" CaseID = '{0}', ", ID)
                SQL &= String.Format(" CategoryID = '{0}', ", cbxCategory.SelectedValue)
                SQL &= String.Format(" Category = '{0}', ", cbxCategory.Text)
                SQL &= String.Format(" SubCategoryID = '{0}', ", ValidateComboBox(cbxSubCategory))
                SQL &= String.Format(" SubCategory = '{0}', ", cbxSubCategory.Text)
                SQL &= String.Format(" MovementDate = '{0}', ", FormatDatePicker(dtpMovement))
                SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" ActionPlan = '{0}', ", txtActionPlan.Text)
                SQL &= String.Format(" Reason = '{0}', ", txtReasons.Text)
                If DateValue(dtpActionDate.Value) > Date.Now Then
                    SQL &= " Notify = 1, "
                End If
                SQL &= String.Format(" ActionDate = '{0}';", FormatDatePicker(dtpActionDate))

                If cbxOldAccount.Checked Then
                    'ACCOUNTING ENTRY *******************************************************************************************************
                    SQL &= " INSERT INTO accounting_entry SET"
                    SQL &= String.Format(" ORNum = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                    SQL &= " EntryType = 'DEBIT',"
                    SQL &= String.Format(" Payable = '{0}', ", dBookValue.Value)
                    SQL &= String.Format(" Amount = '{0}', ", dBookValue.Value)
                    If drv_P("Mortgage_ID") = 1 Then
                        SQL &= " AccountCode = '112301X', "
                    ElseIf drv_P("Mortgage_ID") = 2 Then
                        SQL &= " AccountCode = '112302X', "
                    Else
                        SQL &= " AccountCode = '112303X', "
                    End If
                    SQL &= String.Format(" MotherCode = '{0}X', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(drv_P("Mortgage_ID") = 1, "112301", If(drv_P("Mortgage_ID") = 2, "112302", "112303")))))
                    SQL &= " PostStatus = 'POSTED', "
                    SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                    SQL &= String.Format(" PaidFor = '{0}', ", "Balance Transferred")
                    SQL &= String.Format(" ReferenceN = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    SQL &= String.Format(" CVNumber = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                    'If cbxOldAccount.Checked Then
                    '    SQL &= " INSERT INTO accounting_entry SET"
                    '    SQL &= String.Format(" ORNum = '{0}', ", txtAccountNumber.Text)
                    '    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                    '    SQL &= " EntryType = 'CREDIT',"
                    '    SQL &= String.Format(" Payable = '{0}', ", dBookValue.Value)
                    '    SQL &= String.Format(" Amount = '{0}', ", dBookValue.Value)
                    '    If drv_P("Mortgage_ID") = 1 Then
                    '        SQL &= " AccountCode = '112001', "
                    '    ElseIf drv_P("Mortgage_ID") = 2 Then
                    '        SQL &= " AccountCode = '112002', "
                    '    Else
                    '        SQL &= " AccountCode = '112003', "
                    '    End If
                    '    SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(drv_P("Mortgage_ID") = 1, "112001", If(drv_P("Mortgage_ID") = 2, "112002", "112003")))))
                    '    SQL &= " PostStatus = 'POSTED', "
                    '    SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                    '    SQL &= String.Format(" PaidFor = '{0}', ", "Principal")
                    '    SQL &= String.Format(" ReferenceN = '{0}', ", txtAccountNumber.Text)
                    '    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    '    SQL &= String.Format(" CVNumber = '{0}', ", txtAccountNumber.Text)
                    '    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    '    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    'Else
                    '    SQL &= " INSERT INTO accounting_entry SET"
                    '    SQL &= String.Format(" ORNum = '{0}', ", txtAccountNumber.Text)
                    '    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                    '    SQL &= " EntryType = 'CREDIT',"
                    '    SQL &= String.Format(" Payable = '{0}', ", CDbl(drv("Principal")))
                    '    SQL &= String.Format(" Amount = '{0}', ", CDbl(drv("Principal")))
                    '    If drv_P("Mortgage_ID") = 1 Then
                    '        SQL &= " AccountCode = '112001', "
                    '    ElseIf drv_P("Mortgage_ID") = 2 Then
                    '        SQL &= " AccountCode = '112002', "
                    '    Else
                    '        SQL &= " AccountCode = '112003', "
                    '    End If
                    '    SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(drv_P("Mortgage_ID") = 1, "112001", If(drv_P("Mortgage_ID") = 2, "112002", "112003")))))
                    '    SQL &= " PostStatus = 'POSTED', "
                    '    SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                    '    SQL &= String.Format(" PaidFor = '{0}', ", "Principal")
                    '    SQL &= String.Format(" ReferenceN = '{0}', ", drv("CreditNumber"))
                    '    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    '    SQL &= String.Format(" CVNumber = '{0}', ", txtAccountNumber.Text)
                    '    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    '    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                    '    'INTEREST
                    '    SQL &= " INSERT INTO accounting_entry SET"
                    '    SQL &= String.Format(" ORNum = '{0}', ", txtAccountNumber.Text)
                    '    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                    '    SQL &= " EntryType = 'CREDIT',"
                    '    SQL &= String.Format(" Payable = '{0}', ", CDbl(drv("Interest")))
                    '    SQL &= String.Format(" Amount = '{0}', ", CDbl(drv("Interest")))
                    '    If drv_P("Mortgage_ID") = 1 Then
                    '        SQL &= " AccountCode = '420001', "
                    '    ElseIf drv_P("Mortgage_ID") = 2 Then
                    '        SQL &= " AccountCode = '420002', "
                    '    Else
                    '        SQL &= " AccountCode = '420006', "
                    '    End If
                    '    SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(drv_P("Mortgage_ID") = 1, "420001", If(drv_P("Mortgage_ID") = 2, "420002", "420006")))))
                    '    SQL &= " PostStatus = 'POSTED', "
                    '    SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                    '    SQL &= String.Format(" PaidFor = '{0}', ", "UDI")
                    '    SQL &= String.Format(" ReferenceN = '{0}', ", drv("CreditNumber"))
                    '    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    '    SQL &= String.Format(" CVNumber = '{0}', ", txtAccountNumber.Text)
                    '    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    '    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                    '    'RPPD
                    '    SQL &= " INSERT INTO accounting_entry SET"
                    '    SQL &= String.Format(" ORNum = '{0}', ", txtAccountNumber.Text)
                    '    SQL &= String.Format(" ORDate = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                    '    SQL &= " EntryType = 'CREDIT',"
                    '    SQL &= String.Format(" Payable = '{0}', ", CDbl(drv("RPPD")))
                    '    SQL &= String.Format(" Amount = '{0}', ", CDbl(drv("RPPD")))
                    '    If drv_P("Mortgage_ID") = 1 Then
                    '        SQL &= " AccountCode = '420003', "
                    '    ElseIf drv_P("Mortgage_ID") = 2 Then
                    '        SQL &= " AccountCode = '420004', "
                    '    Else
                    '        SQL &= " AccountCode = '420007', "
                    '    End If
                    '    SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode('{0}');", If(drv_P("Mortgage_ID") = 1, "420003", If(drv_P("Mortgage_ID") = 2, "420004", "420007")))))
                    '    SQL &= " PostStatus = 'POSTED', "
                    '    SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                    '    SQL &= String.Format(" PaidFor = '{0}', ", "RPPD")
                    '    SQL &= String.Format(" ReferenceN = '{0}', ", drv("CreditNumber"))
                    '    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    '    SQL &= String.Format(" CVNumber = '{0}', ", txtAccountNumber.Text)
                    '    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    '    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    'End If
                    'ACCOUNTING ENTRY *******************************************************************************************************
                End If

                DataObject(SQL)
                Logs("Case Setup", "Save", String.Format("Add new Case for {0} with Book Value {1}.", cbxBorrower.Text, dBookValue.Text), "", "", "", txtAccountNumber.Text)
                Clear(True)
                LoadBorrower("", cbxOldAccount.Checked)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                If lblNote.Visible Then
                    Dim BM As DataTable = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE `Position` IN ('OFFICER-IN-CHARGE','BRANCH MANAGER','CORPORATE LAWYER') AND `status` = 'ACTIVE' AND IF(`Position` = 'CORPORATE LAWYER',TRUE, Branch_ID = '{0}');", Branch_ID))
                    For x As Integer = 0 To BM.Rows.Count - 1
                        Dim Msg As String = String.Format("Good day {0}, <br><br>" & vbCrLf, BM(x)("Employee"))
                        Msg &= String.Format("  Update Case Number {0} for {1} with Book Value {2}. <br><br>" & vbCrLf, txtCaseNumber.Text, cbxBorrower.Text, dBookValue.Text)
                        Msg &= String.Format("Category from {1} to {0} <br>" & vbCrLf, cbxCategory.Text, cbxCategory.Tag)
                        Msg &= String.Format("SubCategory from {1} to {0} <br>" & vbCrLf, cbxSubCategory.Text, cbxSubCategory.Tag)
                        Msg &= String.Format("Action Plan from {1} to {0} <br>" & vbCrLf, txtActionPlan.Text, txtActionPlan.Tag)
                        Msg &= String.Format("Remarks from {1} to {0} <br>" & vbCrLf, txtRemarks.Text, txtRemarks.Tag)
                        Msg &= String.Format("Reason from {1} to {0} <br>" & vbCrLf, txtReasons.Text, txtReasons.Tag)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If BM(x)("Phone") = "" Then
                        Else
                            SendSMS(BM(x)("Phone"), Msg.Replace("<br>", ""), False)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If BM(x)("EmailAdd") = "" Then
                        Else
                            Dim Subject As String = "Update Case [" & txtCaseNumber.Text & "] - " & txtAccountNumber.Text
                            SendEmail(BM(x)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                        End If
                    Next
                End If

                'UPDATE MAIN
                Dim SQL As String = "UPDATE case_main SET"
                SQL &= String.Format(" CaseNumber = '{0}', ", txtCaseNumber.Text)
                SQL &= String.Format(" DateFilled = '{0}', ", FormatDatePicker(dtpDateFilled))
                SQL &= String.Format(" BookValue = '{0}', ", dBookValue.Value)
                SQL &= String.Format(" DecisionValue = '{0}', ", dDecisionValue.Value)
                SQL &= String.Format(" DueRP = '{0}', ", FormatDatePicker(dtpRP))
                If cbxCategory.Text = "ON GOING CASE" Or cbxCategory.Text = "DECIDED CASE" Or cbxCategory.Text = "EXECUTED CASE" Then
                    SQL &= " case_status = 'ACTIVE', "
                ElseIf cbxCategory.Text = "DISMISSED CASE" Then
                    SQL &= " case_status = 'DISMISSED', "
                ElseIf cbxCategory.Text = "ARCHIVED CASE" Then
                    SQL &= " case_status = 'ARCHIVED', "
                ElseIf cbxCategory.Text = "WRITE OFF" Then
                    SQL &= " case_status = 'WRITTEN OFF', "
                End If
                If lblNote.Visible Then
                    SQL &= String.Format(" CategoryID = '{0}', ", cbxCategory.SelectedValue)
                    SQL &= String.Format(" SubCategoryID = '{0}', ", ValidateComboBox(cbxSubCategory))
                End If
                SQL &= String.Format(" CaseType = '{0}', ", cbxCaseType.Text)
                SQL &= String.Format(" AccountN = '{0}', ", txtAccountN.Text)
                SQL &= String.Format(" Product = '{0}', ", txtProduct.Text)
                SQL &= String.Format(" MortgageID = '{0}', ", drv_P("mortgage_id"))
                SQL &= String.Format(" Collateral = '{0}', ", txtCollateral.Text)
                SQL &= String.Format(" FaceAmount = '{0}', ", dFaceAmount.Value)
                SQL &= String.Format(" Outstanding = '{0}', ", dOutstanding.Value)
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" PreparedID = '{0}', ", ValidateComboBox(cbxPreparedBy))
                SQL &= String.Format(" CounselID = '{0}', ", ValidateComboBox(cbxLegalCounsel))
                SQL &= String.Format(" Counsel = '{0}', ", cbxLegalCounsel.Text.InsertQuote)
                SQL &= String.Format(" LastPayment = '{0}', ", FormatDatePicker(dtpLastPayment))
                SQL &= String.Format(" LastModified = '{0}' ", Format(Date.Now, "yyyy-MM-dd"))
                SQL &= String.Format(" WHERE ID = {0};", ID)

                If lblNote.Visible Then
                    'INSERT DETAILS
                    SQL &= "INSERT INTO case_details SET"
                    SQL &= String.Format(" CaseID = '{0}', ", ID)
                    SQL &= String.Format(" CategoryID = '{0}', ", cbxCategory.SelectedValue)
                    SQL &= String.Format(" Category = '{0}', ", cbxCategory.Text)
                    SQL &= String.Format(" SubCategoryID = '{0}', ", ValidateComboBox(cbxSubCategory))
                    SQL &= String.Format(" SubCategory = '{0}', ", cbxSubCategory.Text)
                    SQL &= String.Format(" MovementDate = '{0}', ", FormatDatePicker(dtpMovement))
                    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    SQL &= String.Format(" ActionPlan = '{0}', ", txtActionPlan.Text)
                    SQL &= String.Format(" Reason = '{0}', ", txtReasons.Text)
                    If DateValue(dtpActionDate.Value) > Date.Now Then
                        SQL &= " Notify = 1, "
                    End If
                    SQL &= String.Format(" ActionDate = '{0}';", FormatDatePicker(dtpActionDate))
                Else
                    'UPDATE DETAILS
                    SQL &= "UPDATE case_details SET"
                    SQL &= String.Format(" MovementDate = '{0}', ", FormatDatePicker(dtpMovement))
                    SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                    SQL &= String.Format(" ActionPlan = '{0}', ", txtActionPlan.Text)
                    SQL &= String.Format(" Reason = '{0}', ", txtReasons.Text)
                    If DateValue(dtpActionDate.Value) > Date.Now Then
                        SQL &= " Notify = 1, "
                    End If
                    SQL &= String.Format(" ActionDate = '{0}'", FormatDatePicker(dtpActionDate))
                    SQL &= String.Format(" WHERE CaseID = '{2}' AND CategoryID = '{0}' AND SubCategoryID = '{1}';", cbxCategory.SelectedValue, ValidateComboBox(cbxSubCategory), ID)
                End If
                DataObject(SQL)
                Logs("Case Setup", "Update", txtReasons.Text, Changes(), "", "", txtAccountNumber.Text)
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxCategory.Text = cbxCategory.Tag Then
            Else
                Change &= String.Format("Change Category from {0} to {1}. ", cbxCategory.Tag, cbxCategory.Text)
            End If
            If cbxSubCategory.Text = cbxSubCategory.Tag Then
            Else
                Change &= String.Format("Change SubCategory from {0} to {1}. ", cbxSubCategory.Tag, cbxSubCategory.Text)
            End If
            If txtAccountN.Text = txtAccountN.Tag Then
            Else
                Change &= String.Format("Change Account Number for Credit Application from {0} to {1}. ", txtAccountN.Tag, txtAccountN.Text)
            End If
            If txtProduct.Text = txtProduct.Tag Then
            Else
                Change &= String.Format("Change Product from {0} to {1}. ", txtProduct.Tag, txtProduct.Text)
            End If
            If txtCollateral.Text = txtCollateral.Tag Then
            Else
                Change &= String.Format("Change Collateral from {0} to {1}. ", txtCollateral.Tag, txtCollateral.Text)
            End If
            If dFaceAmount.Text = dFaceAmount.Tag Then
            Else
                Change &= String.Format("Change Face Amount from {0} to {1}. ", dFaceAmount.Tag, dFaceAmount.Text)
            End If
            If dOutstanding.Text = dOutstanding.Tag Then
            Else
                Change &= String.Format("Change Outstanding from {0} to {1}. ", dOutstanding.Tag, dOutstanding.Text)
            End If
            If dtpLastPayment.Text = dtpLastPayment.Tag Then
            Else
                Change &= String.Format("Change Last Payment from {0} to {1}. ", dtpLastPayment.Tag, dtpLastPayment.Text)
            End If
            If cbxBank.Text = cbxBank.Tag Then
            Else
                Change &= String.Format("Change Bank from {0} to {1}. ", cbxBank.Tag, cbxBank.Text)
            End If
            If txtCaseNumber.Text = txtCaseNumber.Tag Then
            Else
                Change &= String.Format("Change Case Number from {0} to {1}. ", txtCaseNumber.Tag, txtCaseNumber.Text)
            End If
            If dtpDateFilled.Text = dtpDateFilled.Tag Then
            Else
                Change &= String.Format("Change Date Filled from {0} to {1}. ", dtpDateFilled.Tag, dtpDateFilled.Text)
            End If
            If dtpRP.Text = dtpRP.Tag Then
            Else
                Change &= String.Format("Change Due of RP from {0} to {1}. ", dtpRP.Tag, dtpRP.Text)
            End If
            If dtpMovement.Text = dtpMovement.Tag Then
            Else
                Change &= String.Format("Change Movement Date from {0} to {1}. ", dtpMovement.Tag, dtpMovement.Text)
            End If
            If dBookValue.Text = dBookValue.Tag Then
            Else
                Change &= String.Format("Change Book Value from {0} to {1}. ", dBookValue.Tag, dBookValue.Text)
            End If
            If dDecisionValue.Text = dDecisionValue.Tag Then
            Else
                Change &= String.Format("Change Decision Value from {0} to {1}. ", dDecisionValue.Tag, dDecisionValue.Text)
            End If
            If txtActionPlan.Text = txtActionPlan.Tag Then
            Else
                Change &= String.Format("Change Action Plan from {0} to {1}. ", txtActionPlan.Tag, txtActionPlan.Text)
            End If
            If dtpActionDate.Text = dtpActionDate.Tag Then
            Else
                Change &= String.Format("Change Action Date from {0} to {1}. ", dtpActionDate.Tag, dtpActionDate.Text)
            End If
            If txtRemarks.Text = txtRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", txtRemarks.Tag, txtRemarks.Text)
            End If
            If txtReasons.Text = txtReasons.Tag Then
            Else
                Change &= String.Format("Change Reasons from {0} to {1}. ", txtReasons.Tag, txtReasons.Text)
            End If
            If cbxLegalCounsel.Text = cbxLegalCounsel.Tag Then
            Else
                Change &= String.Format("Change Legal Counsel from {0} to {1}. ", cbxLegalCounsel.Tag.ToString.InsertQuote, cbxLegalCounsel.Text.InsertQuote)
            End If
        Catch ex As Exception
            TriggerBugReport("Case Setup - Changes", ex.Message.ToString)
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
            cbxOldAccount.Enabled = False
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
            Dim drv_P As DataRowView = DirectCast(txtProduct.SelectedItem, DataRowView)
            If cbxOldAccount.Checked Then
                Dim SQL As String = String.Format("UPDATE case_main SET `status` = 'DELETED' WHERE ID = '{0}';", ID)
                DataObject(SQL)
                Logs("Case Setup", "Cancel", "", String.Format("Cancel Case of {0} with Book Value {1}.", cbxBorrower.Text, dBookValue.Text), "", "", txtAccountNumber.Text)
                Clear(True)
                MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
            Else
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
                    Logs("Case Setup", "Cancel", "Journal Voucher", "", "", "", "")

                    .From_ITL = True
                    .From_ITL_Reverse = True
                    .MortgageID = drv_P("Mortgage_ID")
                    .CheckAmount = DataObject(String.Format("SELECT Ledger_Balance('{0}','{1}')", txtAccountNumber.Text, drv_P("Mortgage_ID")))
                    .BankID = cbxBank.SelectedValue
                    .cbxPayee.Tag = cbxBorrower.Text
                    .txtReferenceNumber.Text = txtAccountNumber.Text
                    .txtReferenceNumber.Tag = txtAccountNumber.Text
                    .txtORNumber.Tag = drv("CreditNumber")
                    If .ShowDialog = DialogResult.OK Then
                        Dim SQL As String = String.Format("UPDATE case_main SET `status` = 'DELETED' WHERE ID = '{0}';", ID)
                        'UPDATE CREDIT APPLICATION
                        SQL &= String.Format(" UPDATE credit_application SET PaymentRequest = 'RELEASED' WHERE CreditNumber = '{0}';", drv("CreditNumber"))
                        DataObject(SQL)
                        Logs("Case Setup", "Cancel", "", String.Format("Cancel Case of {0} with Book Value {1}.", cbxBorrower.Text, dBookValue.Text), "", "", txtAccountNumber.Text)
                        Clear(True)
                        LoadBorrower("", cbxOldAccount.Checked)
                        MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
                    End If
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
            Generate_ITL()
            Logs("Case Setup", "Print", "[SENSITIVE] Print Case " & txtCaseNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("CASE LIST", GridControl1)
            Logs("Case Setup", "Print", "[SENSITIVE] Print Case List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Generate_ITL()
        Dim Report As New RptCaseSetup
        With Report
            .Name = String.Format("Case of {0} - {1}", cbxBorrower.Text, txtCaseNumber.Text)

            .lblDefendant.Text = cbxBorrower.Text
            .lblITLDate.Text = dtpDate.Text
            .lblReference.Text = txtAccountNumber.Text
            .lblAccountNo.Text = txtAccountN.Text
            .lblFaceAmount.Text = dFaceAmount.Text
            .lblProduct.Text = txtProduct.Text
            .lblOutstanding.Text = dOutstanding.Text
            .lblCollateral.Text = txtCollateral.Text
            .lblLastPayment.Text = dtpLastPayment.Text
            .lblBank.Text = cbxBank.Text
            .lblCaseNumber.Text = txtCaseNumber.Text
            .lblDateFilled.Text = dtpDateFilled.Text
            If dtpRP.Visible = False Then
                .lblDueDate.Visible = False
                .XrLabel26.Visible = False
            End If
            .lblDueDate.Text = dtpRP.Text
            .lblCategory.Text = cbxCategory.Text
            .lblSubcategory.Text = cbxSubCategory.Text
            .lblMovementDate.Text = dtpMovement.Text
            .lblBookValue.Text = dBookValue.Text
            .lblCaseType.Text = cbxCaseType.Text
            .lblDecisionValue.Text = dDecisionValue.Text
            .lblActionPlan.Text = txtActionPlan.Text
            .lblActionDate.Text = dtpActionDate.Text
            .lblRemarks.Text = txtRemarks.Text
            .lblReasons.Text = txtReasons.Text
            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblCounsel.Text = cbxLegalCounsel.Text
            .ShowPreview()
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Then
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
        cbxBorrower.Enabled = False
        dtpDate.Enabled = False
        dBookValue.Enabled = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            dtpDate.CustomFormat = "MMMM dd, yyyy"
            dtpDate.Value = .GetFocusedRowCellValue("Date")
            dtpDate.Tag = .GetFocusedRowCellValue("Date")
            FirstLoad = True
            If .GetFocusedRowCellValue("Old_Account") = True Then
                cbxOldAccount.Checked = True
            Else
                cbxOldAccount.Checked = False
            End If
            FirstLoad = False
            LoadBorrower(.GetFocusedRowCellValue("CreditNumber"), cbxOldAccount.Checked)
            If .GetFocusedRowCellValue("Old_Account") = True Then
                cbxBorrower.SelectedValue = .GetFocusedRowCellValue("BorrowerID")
            End If
            txtAccountN.Text = .GetFocusedRowCellValue("AccountN")
            txtAccountN.Tag = .GetFocusedRowCellValue("AccountN")
            txtProduct.Text = .GetFocusedRowCellValue("Product")
            txtProduct.Tag = .GetFocusedRowCellValue("Product")
            txtCollateral.Text = .GetFocusedRowCellValue("Collateral")
            txtCollateral.Tag = .GetFocusedRowCellValue("Collateral")
            dFaceAmount.Value = .GetFocusedRowCellValue("FaceAmount")
            dFaceAmount.Tag = .GetFocusedRowCellValue("FaceAmount")
            dOutstanding.Value = .GetFocusedRowCellValue("Outstanding")
            dOutstanding.Tag = .GetFocusedRowCellValue("Outstanding")
            If .GetFocusedRowCellValue("LastPayment") = "" Then
            Else
                dtpLastPayment.Value = .GetFocusedRowCellValue("LastPayment")
                dtpLastPayment.Tag = .GetFocusedRowCellValue("LastPayment")
            End If

            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            txtAccountNumber.Text = .GetFocusedRowCellValue("Account Number")
            cbxCategory.Text = .GetFocusedRowCellValue("Category")
            cbxCategory.Tag = .GetFocusedRowCellValue("Category")
            cbxSubCategory.Text = .GetFocusedRowCellValue("SubCategory")
            cbxSubCategory.Tag = .GetFocusedRowCellValue("SubCategory")
            cbxCaseType.Text = .GetFocusedRowCellValue("Case Type")
            cbxCaseType.Tag = .GetFocusedRowCellValue("Case Type")
            If IsDate(.GetFocusedRowCellValue("Movement Date")) Then
                dtpMovement.CustomFormat = "MMMM dd, yyyy"
                dtpMovement.Value = .GetFocusedRowCellValue("Movement Date")
            Else
                dtpMovement.CustomFormat = ""
            End If
            dtpMovement.Tag = .GetFocusedRowCellValue("Movement Date")
            txtCaseNumber.Text = .GetFocusedRowCellValue("Case Number")
            txtCaseNumber.Tag = .GetFocusedRowCellValue("Case Number")
            If IsDate(.GetFocusedRowCellValue("Date Filled")) Then
                dtpDateFilled.CustomFormat = "MMMM dd, yyyy"
                dtpDateFilled.Value = .GetFocusedRowCellValue("Date Filled")
            Else
                dtpDateFilled.CustomFormat = ""
            End If
            dtpDateFilled.Tag = .GetFocusedRowCellValue("Date Filled")
            If .GetFocusedRowCellValue("DueRP") = "" Then
                lblRP.Visible = False
                dtpRP.Visible = False
                dtpRP.CustomFormat = ""
            Else
                lblRP.Visible = True
                dtpRP.Visible = True
                dtpRP.CustomFormat = "MMMM dd, yyyy"
                dtpRP.Value = .GetFocusedRowCellValue("DueRP")
            End If
            dtpRP.Tag = .GetFocusedRowCellValue("DueRP")
            dBookValue.Value = .GetFocusedRowCellValue("Book Value")
            dBookValue.Tag = .GetFocusedRowCellValue("Book Value")
            If dBookValue.Value <= 1 Then
                dBookValue.Enabled = True
            End If
            dDecisionValue.Value = .GetFocusedRowCellValue("Decision Value")
            dDecisionValue.Tag = .GetFocusedRowCellValue("Decision Value")
            txtActionPlan.Text = .GetFocusedRowCellValue("Action Plan")
            txtActionPlan.Tag = .GetFocusedRowCellValue("Action Plan")
            If .GetFocusedRowCellValue("Action Date") = "" Then
            Else
                dtpActionDate.Value = .GetFocusedRowCellValue("Action Date")
                dtpActionDate.Tag = .GetFocusedRowCellValue("Action Date")
            End If
            txtRemarks.Text = .GetFocusedRowCellValue("Remarks")
            txtRemarks.Tag = .GetFocusedRowCellValue("Remarks")
            txtReasons.Text = .GetFocusedRowCellValue("Reason")
            txtReasons.Tag = .GetFocusedRowCellValue("Reason")

            cbxPreparedBy.SelectedValue = .GetFocusedRowCellValue("PreparedID")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")
            cbxLegalCounsel.Text = .GetFocusedRowCellValue("Counsel")
            cbxLegalCounsel.SelectedValue = .GetFocusedRowCellValue("CounselID")
            cbxLegalCounsel.Tag = .GetFocusedRowCellValue("Legal Counsel")

            SuperTabControl1.SelectedTab = tabSetup
            If .GetFocusedRowCellValue("Case_Status") = "FULLY PAID" Then
                btnModify.Enabled = False
            Else
                btnModify.Enabled = True
            End If
        End With
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        GetAccountNumber()
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
            .FolderName = GridView1.GetFocusedRowCellValue("Account Number")
            .CaseNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Account Number")
            .Type = "Case"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub
    '**** L E A V E

    Private Sub CbxSubCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSubCategory.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            'MOVEMENT OF CATEGORY AND SUBCATEGORY
            If cbxBorrower.Enabled = False Then
                LoadCategory()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmCaseLedger
        With Ledger
            .txtCaseNumber.Text = GridView1.GetFocusedRowCellValue("Case Number")
            .dtpDateFilled.Value = GridView1.GetFocusedRowCellValue("Date Filled")
            .txtDefendant.Text = GridView1.GetFocusedRowCellValue("Borrower")
            .dBookValue.Value = GridView1.GetFocusedRowCellValue("Book Value")
            .dDecisionValue.Value = GridView1.GetFocusedRowCellValue("Decision Value")
            .txtCollateral.Text = GridView1.GetFocusedRowCellValue("Collateral")
            .txtAccountNumber.Text = GridView1.GetFocusedRowCellValue("AccountNum")
            .txtMobileNumber.Text = GridView1.GetFocusedRowCellValue("Mobile")
            If GridView1.GetFocusedRowCellValue("BorrowerID").ToString.Contains("C") Then
                .LabelX9.Text = "Telephone :"
            End If
            If GridView1.GetFocusedRowCellValue("DueRP") = "" Then
                .dtpDueRP.CustomFormat = ""
            Else
                .dtpDueRP.CustomFormat = "MMMM dd, yyyy"
                .dtpDueRP.Value = GridView1.GetFocusedRowCellValue("DueRP")
            End If
            .CaseNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .CaseID = GridView1.GetFocusedRowCellValue("ID")
            .CategoryID = GridView1.GetFocusedRowCellValue("CategoryID")

            If GridView1.GetFocusedRowCellValue("Decision Value") = 0 Then
                .cbxTransaction.Items.Clear()
                .cbxTransaction.Items.Add("Charges")
                .cbxTransaction.Items.Add("Others")
            End If
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnDetailed_Click(sender As Object, e As EventArgs) Handles btnDetailed.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Detailed As New FrmCaseDetailed
        With Detailed
            .CaseNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .txtCaseNumber.Text = GridView1.GetFocusedRowCellValue("Case Number")
            .dtpDateFilled.Value = GridView1.GetFocusedRowCellValue("Date Filled")
            .txtDefendant.Text = GridView1.GetFocusedRowCellValue("Borrower")
            .dBookValue.Value = GridView1.GetFocusedRowCellValue("Book Value")
            .dDecisionValue.Value = GridView1.GetFocusedRowCellValue("Decision Value")
            .txtPrepared.Text = GridView1.GetFocusedRowCellValue("Prepared By")
            .txtLegal.Text = GridView1.GetFocusedRowCellValue("Legal Counsel")
            .dtpLastModified.Value = GridView1.GetFocusedRowCellValue("LastModified")
            .txtCaseType.Text = GridView1.GetFocusedRowCellValue("Case Type")
            .lblStatus.Text = GridView1.GetFocusedRowCellValue("Case_Status")
            .vDelete = vDelete
            .vPrint = vPrint

            If GridView1.GetFocusedRowCellValue("Case_Status") = "ACTIVE" Then
                .lblStatus.ForeColor = Color.SeaGreen
            ElseIf GridView1.GetFocusedRowCellValue("Case_Status") = "DISMISSED" Then
                .lblStatus.ForeColor = Color.IndianRed
            ElseIf GridView1.GetFocusedRowCellValue("Case_Status") = "ARCHIVED" Then
                .lblStatus.ForeColor = Color.Orange
            ElseIf GridView1.GetFocusedRowCellValue("Case_Status") = "WRITTEN OFF" Then
                .lblStatus.ForeColor = Color.RoyalBlue
            End If

            .CaseID = GridView1.GetFocusedRowCellValue("ID")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnPayment_Click(sender As Object, e As EventArgs) Handles btnPayment.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Decision Value") = 0 Then
                If MsgBox("Decision Value is still Zero P0.00, please fill the decision value for payment and ledger. Would you like to proceed?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim ACR As New FrmAcknowledgement
        With ACR
            If FrmMain.lblDate.Text.Contains("Disconnected") Then
                MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
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
            Logs("Case Setup", "Acknowledgement", "Acknowledgement Receipt", "", "", "", "")

            .From_ITL = True
            .Clear(False)
            .tabList.Visible = False
            .btnNext.Enabled = False
            .btnRefresh.Enabled = False
            .cbxAR.Checked = False
            .cbxAP.Checked = False
            .cbxDF.Checked = False
            .cbxLOE.Checked = False
            .cbxITL.Checked = True
            .cbxRO.Checked = False
            .cbxLOE.Enabled = False
            .cbxAR.Enabled = False
            .cbxAP.Enabled = False
            .cbxDF.Enabled = False
            .cbxITL.Enabled = False
            .cbxRO.Enabled = False
            .cbxPayee.Enabled = False
            .cbxLA.Enabled = False
            .cbxLA.Checked = False
            .cbxCAS.Enabled = False
            .cbxCAS.Checked = False
            .BankID = GridView1.GetFocusedRowCellValue("BankID")
            .AccountsReceivableID = GridView1.GetFocusedRowCellValue("Account Number")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub DtpRP_Click(sender As Object, e As EventArgs) Handles dtpRP.Click
        dtpRP.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub TxtAccountN_Leave(sender As Object, e As EventArgs) Handles txtAccountN.Leave
        txtAccountN.Text = ReplaceText(txtAccountN.Text)
    End Sub

    Private Sub TxtProduct_Leave(sender As Object, e As EventArgs) Handles txtProduct.Leave
        txtProduct.Text = ReplaceText(txtProduct.Text)
    End Sub

    Private Sub TxtCollateral_Leave(sender As Object, e As EventArgs) Handles txtCollateral.Leave
        txtCollateral.Text = ReplaceText(txtCollateral.Text)
    End Sub

    Private Sub TxtCaseNumber_Leave(sender As Object, e As EventArgs) Handles txtCaseNumber.Leave
        txtCaseNumber.Text = ReplaceText(txtCaseNumber.Text)
    End Sub

    Private Sub TxtActionPlan_Leave(sender As Object, e As EventArgs) Handles txtActionPlan.Leave
        txtActionPlan.Text = ReplaceText(txtActionPlan.Text)
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub

    Private Sub TxtReasons_Leave(sender As Object, e As EventArgs) Handles txtReasons.Leave
        txtReasons.Text = ReplaceText(txtReasons.Text)
    End Sub

    Private Sub CbxITLDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbxITLDate.CheckedChanged
        If cbxITLDate.Checked Then
            cbxMovementDate.Checked = False
        End If

        If cbxITLDate.Checked = False And cbxMovementDate.Checked = False Then
            cbxITLDate.Checked = False
        End If
    End Sub

    Private Sub CbxActionDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMovementDate.CheckedChanged
        If cbxMovementDate.Checked Then
            cbxITLDate.Checked = False
        End If

        If cbxITLDate.Checked = False And cbxMovementDate.Checked = False Then
            cbxITLDate.Checked = False
        End If
    End Sub

    Private Sub BtnAccountLedger_Click(sender As Object, e As EventArgs) Handles btnAccountLedger.Click
        Dim Ledger As New FrmAccountLedger
        With Ledger
            Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
            .CreditNumber = drv("CreditNumber")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub CbxBorrower_TextChanged(sender As Object, e As EventArgs) Handles cbxBorrower.TextChanged
        If cbxBorrower.Text = "" Then
            btnAccountLedger.Enabled = False
        End If
    End Sub

    Private Sub DtpDate_Click(sender As Object, e As EventArgs) Handles dtpDate.Click
        dtpDate.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpDateFilled_Click(sender As Object, e As EventArgs) Handles dtpDateFilled.Click
        dtpDateFilled.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpMovement_Click(sender As Object, e As EventArgs) Handles dtpMovement.Click
        dtpMovement.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpLastPayment_Click(sender As Object, e As EventArgs) Handles dtpLastPayment.Click
        dtpLastPayment.CustomFormat = "MMMM dd, yyyy"
    End Sub
End Class