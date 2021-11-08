Imports DevExpress.XtraReports.UI
Public Class FrmAccountsReceivable

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Public DefaultBank As Integer
    Dim DT_Account As DataTable
    Dim Code As String

    Dim Code_Check As String
    Dim Code_Approve As String
    Dim User_EmplID As Integer
    Dim CopyMode As Boolean
    Public From_GL As Boolean
    Public GL_DocumentNumber As String
    Public From_JV_Restructure As Boolean
    Dim Flag As Boolean = False
    Public Skip_FilterLoadData As Boolean
    Private Sub FrmAccountsReceivable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If From_GL Then
            cbxAll.Checked = True
        End If
        SuperTabControl1.SelectedTab = tabList
        LoadData()
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

        LoadPayor()
        cbxPayor.SelectedIndex = -1

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

        Dim DT_Status As DataTable = DataSource("SELECT 'For Checking' AS 'Status' UNION SELECT 'For Approval' UNION SELECT 'For CV / ACR' UNION SELECT 'Partially Paid' UNION SELECT 'Fully Paid' UNION SELECT 'Non Receivable' UNION SELECT 'Cancelled'")
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
        ElseIf From_JV_Restructure Then
            Dim SQL As String = "SELECT"
            SQL &= "    CreditNumber AS 'ID',"
            SQL &= "    CONCAT('[ ', CreditNumber,' ] - ',IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Payor',"
            SQL &= "    'RS' AS 'Type', BankID"
            SQL &= " FROM credit_application"
            SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND CreditNumber = '{1}' AND branch_id = '{0}' ", Branch_ID, GL_DocumentNumber)
            cbxPayor.DataSource = DataSource(SQL)
            cbxPayor.Enabled = False

            cbxBank.SelectedValue = cbxBank.Tag
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX2, LabelX1, LabelX18, LabelX10, LabelX6, LabelX9, LabelX5, LabelX12, LabelX34, LabelX40, LabelX42, LabelX41, LabelX39})

            GetLabelWithBackgroundFontSettings({LabelX7, LabelX21, LabelX3, LabelX19, LabelX4, LabelX8, LabelX35})

            GetCheckBoxFontSettings({cbxAll})

            GetButtonFontSettings({btnAdd_Account, btnRemove_Account, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDisapprove, btnDelete, btnPrint, btnApprove, btnAttach, btnCheck, btnSearch})

            GetComboBoxFontSettings({cbxPayor, cbxBank, cbxAccount, cbxDepartment, cbxBusinessCenter, cbxPreparedBy, cbxDisplay})

            GetDateTimeInputFontSettings({dtpDocument, dtpPostingDate, dtpFrom, dtpTo})

            GetTextBoxFontSettings({txtDocumentNumber, txtReferenceNumber, txtChecked, txtApproved})

            GetDoubleInputFontSettings({dDebitT, dCreditT})

            GetDoubleInputFontSettingsDefault({dAmount})

            GetSearchRepositoryFontSettings({RepositoryItemSearchLookUpEdit1})

            GetRepositoryFontSettings({RepositoryItemLookUpEdit3, RepositoryItemLookUpEdit2})

            GetRickTextBoxFontSettings({rExplanation})

            GetTabControlFontSettings({SuperTabControl1})

            GetLabelHeaderFontSettings({lblTitle})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Accounts Receivable - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Accounts Receivable", lblTitle.Text)
    End Sub

    Public Sub LoadPayor()
        cbxPayor.ValueMember = "ID"
        cbxPayor.DisplayMember = "Payor"
        If From_JV_Restructure Then
            Exit Sub
        End If
        Dim SQL As String = "SELECT"
        SQL &= "    CreditNumber AS 'ID',"
        SQL &= "    CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)), ' [',CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)),']') AS 'Payor',"
        SQL &= "    'LA' AS 'Type', BankID"
        SQL &= " FROM credit_application"
        SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ", Branch_ID)
        SQL &= " UNION ALL"
        SQL &= " SELECT "
        SQL &= "    BranchID,"
        SQL &= "    Branch,"
        SQL &= "    'B' AS 'Type', 0 AS 'BankID'"
        SQL &= " FROM branch WHERE `status` = 'ACTIVE'"
        SQL &= " UNION ALL"
        SQL &= " SELECT "
        SQL &= "    ID,"
        SQL &= "    Supplier,"
        SQL &= "    'S' AS 'Type', 0 AS 'BankID'"
        SQL &= String.Format(" FROM supplier_setup WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}'", Branch_ID)
        SQL &= " UNION ALL"
        SQL &= " SELECT "
        SQL &= "    ID,"
        SQL &= "    CONCAT((SELECT company FROM company WHERE ID = SisterID), ' ', Branch),"
        SQL &= "    'SC' AS 'Type', 0 AS 'BankID'"
        SQL &= String.Format(" FROM sister_company WHERE `status` = 'ACTIVE'", Branch_ID)
        SQL &= " UNION ALL"
        SQL &= " SELECT "
        SQL &= "    ID,"
        SQL &= "    Employee(ID),"
        SQL &= "    'E' AS 'Type', 0 AS 'BankID'"
        SQL &= String.Format(" FROM employee_setup WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' ORDER BY `Payor`", Branch_ID)

        cbxPayor.DataSource = DataSource(SQL)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    PayorID,"
        SQL &= "    Payor AS 'Payor',"
        SQL &= "    (SELECT CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank' FROM branch_bank WHERE ID = accounts_receivable.BankID) AS 'Bank', BankID, "
        SQL &= "    DATE_FORMAT(DocumentDate,'%M %d, %Y') AS 'Document Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    DATE_FORMAT(PostingDate,'%M %d, %Y') AS 'Posting Date',"
        SQL &= "    ReferenceNumber AS 'Reference Number',"
        SQL &= "    Explanation,"
        SQL &= "    Amount AS 'Total Receivable',"
        SQL &= "    Paid AS 'Total Payment',"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID, CheckedID, "
        SQL &= "    BRANCH(branch_id) AS 'Branch', User_EmplID, Branch_ID, IF(NotAR = 1,'NON RECEIVABLE',IF(`Status` IN ('DELETED','CANCELLED','DISAPPROVED'),`status`,IF(JVNumber != '','REVERSED',IF(AR_Status='PENDING','FOR CHECKING',IF(AR_Status='CHECKED','FOR APPROVAL',IF(AR_Status='APPROVED','FOR CV / ACR',AR_Status)))))) AS 'AR_Status', Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', OTAC_Check, OTAC_Approve, Attach, JVNumberV2, JVNumber, NotAR, Payor_Type"
        SQL &= " FROM accounts_receivable WHERE"
        Dim ForChecking As Boolean
        Dim ForApproval As Boolean
        Dim ForCV As Boolean
        Dim PartiallyPaid As Boolean
        Dim FullyPaid As Boolean
        Dim NonReceivable As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Checking" Then
                    ForChecking = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    ForApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For CV / ACR" Then
                    ForCV = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Partially Paid" Then
                    PartiallyPaid = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Fully Paid" Then
                    FullyPaid = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Non Receivable" Then
                    NonReceivable = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForChecking = False And ForApproval = False And ForCV = False And PartiallyPaid = False And FullyPaid = False And NonReceivable = False Then
                SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED') OR IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'DISAPPROVED')"
            Else
                SQL &= " `status` IN ('ACTIVE','CANCELLED','DELETED','DISAPPROVED') AND (IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'DISAPPROVED' "
                If ForChecking Or ForApproval Or ForCV Or PartiallyPaid Or FullyPaid Or NonReceivable Then
                    SQL &= " OR "
                End If
                If ForChecking Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'PENDING',TRUE)"
                    If ForApproval Or ForCV Or PartiallyPaid Or FullyPaid Or NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'CHECKED',TRUE)"
                    If ForCV Or PartiallyPaid Or FullyPaid Or NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If ForCV Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'APPROVED',TRUE)"
                    If PartiallyPaid Or FullyPaid Or NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If PartiallyPaid Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'PARTIALLY PAID',TRUE)"
                    If FullyPaid Or NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If FullyPaid Then
                    SQL &= " IF(`status` = 'ACTIVE',IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'FULLY PAID',TRUE)"
                    If NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If NonReceivable Then
                    SQL &= "IF(`status` = 'ACTIVE', IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'NOT RECEIVABLE',TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForChecking = False And ForApproval = False And ForCV = False And PartiallyPaid = False And FullyPaid = False And NonReceivable = False Then
            Else
                SQL &= " AND ("
                If ForChecking Then
                    SQL &= " IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'PENDING'"
                    If ForApproval Or ForCV Or PartiallyPaid Or FullyPaid Or NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'CHECKED'"
                    If ForCV Or PartiallyPaid Or FullyPaid Or NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If ForCV Then
                    SQL &= " IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'APPROVED'"
                    If PartiallyPaid Or FullyPaid Or NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If PartiallyPaid Then
                    SQL &= " IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'PARTIALLY PAID'"
                    If FullyPaid Or NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If FullyPaid Then
                    SQL &= " IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'FULLY PAID'"
                    If NonReceivable Then
                        SQL &= " OR "
                    End If
                End If
                If NonReceivable Then
                    SQL &= " IF(NotAR = 1,'NOT RECEIVABLE',AR_Status) = 'NOT RECEIVABLE'"
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
            GridColumn30.VisibleIndex = 11
        End If
        With GridView1
            .Columns("Payor").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Payor").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .Columns("Total Receivable").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Total Receivable").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Total Payment").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Total Payment").SummaryItem.DisplayFormat = "{0:n2}"
        End With

        If GridView1.RowCount > 19 Then
            GridColumn3.Width = 265 - 17
        Else
            GridColumn3.Width = 265
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub DtpDocument_ValueChanged(sender As Object, e As EventArgs) Handles dtpDocument.ValueChanged
        GetDocumentNumber()
    End Sub

    Private Sub GetDocumentNumber()
        If btnSave.Text = "&Save" Then
            txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('AR-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_receivable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))
        End If
    End Sub

#Region "Keydown"
    Private Sub CbxPayor_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayor.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxBank.Focus()
        End If
    End Sub

    Private Sub CbxBank_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBank.KeyDown
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
            Dim Total_CIB As Double
            For x As Integer = 0 To DT_Account.Rows.Count - 1
                TotalDebit += CDbl(DT_Account(x)("Debit"))
                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Then
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
                If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Then
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

    Private Sub BtnAdd_Account_Click(sender As Object, e As EventArgs) Handles btnAdd_Account.Click
        btnRemove_Account.Enabled = True
        Dim drv As DataRowView = DirectCast(cbxAccount.SelectedItem, DataRowView)
        Dim Row As DataRow = DT_Account.NewRow
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

        Dim TotalDebit As Double
        Dim TotalCredit As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
        Next
        If GridView2.RowCount > 11 Then
            GridColumn45.Width = 342 - 17
        Else
            GridColumn45.Width = 342
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
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Then
                Total_CIB += CDbl(DT_Account(x)("Debit"))
            End If
        Next
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB
        If GridView2.RowCount > 11 Then
            GridColumn45.Width = 342 - 17
        Else
            GridColumn45.Width = 342
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
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Public Sub Clear(TriggerLoadData As Boolean)
        CopyMode = False
        btnSave.Text = "&Save"
        PanelEx10.Enabled = True
        PanelEx2.Enabled = True
        GridView2.OptionsBehavior.Editable = True
        dtpDocument.Value = Date.Now
        dtpPostingDate.Value = Date.Now
        rExplanation.Text = ""
        cbxPayor.Text = ""
        txtReferenceNumber.Text = ""
        dAmount.Value = 0
        If cbxBank.Enabled Then
            cbxBank.SelectedIndex = -1
        End If
        LoadPayor()
        cbxPreparedBy.SelectedValue = Empl_ID

        Dim SQL As String = " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode' UNION ALL"
        SQL &= " SELECT '' AS 'Account Code', '' AS 'Department Code', '' AS 'Account', '' AS 'Business Center', '' AS 'Department', 0.00 AS 'Debit', 0.00 AS 'Credit', '' AS 'Remarks', 'False' AS 'RequiredRemarks', '' AS 'BusinessCode', 0 AS 'Type_ID', '' AS 'MotherCode'"
        DT_Account = DataSource(SQL)
        GridControl2.DataSource = DT_Account
        dDebitT.Value = 0
        dCreditT.Value = 0
        If GridView2.RowCount > 11 Then
            GridColumn45.Width = 342 - 17
        Else
            GridColumn45.Width = 342
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
            Exit Sub
        End If
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim drv_B As DataRowView = DirectCast(cbxBank.SelectedItem, DataRowView)
        If cbxPayor.Text = "" Then
            MsgBox("Please select/fill Payor.", MsgBoxStyle.Information, "Info")
            cbxPayor.DroppedDown = True
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

        Dim Open As String = DataObject(String.Format("SELECT IF('{2}' = 'Jan',Jan,IF('{2}' = 'Feb',Feb,IF('{2}' = 'Mar',Mar,IF('{2}' = 'Apr',Apr,IF('{2}' = 'May',May,IF('{2}' = 'Jun',Jun,IF('{2}' = 'Jul',Jul,IF('{2}' = 'Aug',Aug,IF('{2}' = 'Sep',Sep,IF('{2}' = 'Oct',`Oct`,IF('{2}' = 'Nov',Nov,IF('{2}' = 'Dec',`Dec`,'X')))))))))))) FROM accounting_period WHERE Branch = '{0}' AND `status` = 'ACTIVE' AND `Year` = '{1}';", Branch_Code, Format(dtpPostingDate.Value, "yyyy"), Format(dtpPostingDate.Value, "MMM")))
        If If(Open = "", "Open", Open) = "Open" Then
        Else
            MsgBox(String.Format("Accounting Period for your branch is already {0}. Transaction with this date is not allowed.", If(Open = "Lock", "Locked", If(Open = "Close", "Closed", Open))), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim drv As DataRowView = DirectCast(cbxPayor.SelectedItem, DataRowView)
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
                If DocumentNumberExist("accounts_receivable", txtDocumentNumber.Text) Then
                    Exit Sub
                End If
                Dim SQL As String = "INSERT INTO accounts_receivable SET"
                SQL &= String.Format(" PayorID = '{0}', ", ValidateComboBox(cbxPayor))
                SQL &= String.Format(" Payor = '{0}', ", cbxPayor.Text.InsertQuote)
                SQL &= String.Format(" Payor_Type = '{0}', ", If(cbxPayor.SelectedIndex = -1, "", drv("Type")))
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
                SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "Account").ToString = "" Then
                    Else
                        SQL &= "INSERT INTO ar_details SET"
                        SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                        SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                        SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                        SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                        SQL &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                        SQL &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                        SQL &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)

                        'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                        Dim SQLv2 As String = ""
                        If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable")) Then
                            Dim APNumber As String
                            Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                APNumber = DataObject(String.Format("SELECT CONCAT('DT-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_to WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                SQLv2 &= "INSERT INTO due_to SET"
                            Else
                                APNumber = DataObject(String.Format("SELECT CONCAT('AP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                SQLv2 &= "INSERT INTO accounts_payable SET"
                            End If
                            If cbxPayor.Text = "" Then
                                SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                            Else
                                SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, ValidateComboBox(cbxPayor), BranchTagged))
                                SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, cbxPayor.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
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
                        ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                            Dim ARNumber As String
                            Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                            ARNumber = DataObject(String.Format("SELECT CONCAT('DF-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_from WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                            SQLv2 &= " INSERT INTO due_from SET"
                            If cbxPayor.Text = "" Then
                                SQLv2 &= String.Format(" PayorID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                SQLv2 &= String.Format(" Payor = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                SQLv2 &= String.Format(" Payor_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                            Else
                                SQLv2 &= String.Format(" PayorID = '{0}', ", If(BranchTagged = 999, ValidateComboBox(cbxPayor), BranchTagged))
                                SQLv2 &= String.Format(" Payor = '{0}', ", If(BranchTagged = 999, cbxPayor.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
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

                            SQLv2 &= "INSERT INTO df_details SET"
                            SQLv2 &= String.Format(" DocumentNumber = '{0}', ", ARNumber)
                            SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                        ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Payable") Then
                            Dim ARNumber As String
                            Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                            ARNumber = DataObject(String.Format("SELECT CONCAT('LP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM loans_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                            SQLv2 &= " INSERT INTO loans_payable SET"
                            If cbxPayor.Text = "" Then
                                SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                            Else
                                SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, ValidateComboBox(cbxPayor), BranchTagged))
                                SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, cbxPayor.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
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

                            SQLv2 &= "INSERT INTO lp_details SET"
                            SQLv2 &= String.Format(" DocumentNumber = '{0}', ", ARNumber)
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
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    If GridView2.GetRowCellValue(x, "Account").ToString = "" Then
                    Else
                        SQL &= "INSERT INTO accounting_entry SET"
                        If If(cbxPayor.SelectedIndex = -1, "", drv("Type")) = "LA" Then
                            SQL &= String.Format(" ReferenceN = '{0}', ", cbxPayor.SelectedValue)
                        Else
                            SQL &= String.Format(" ReferenceN = '{0}', ", txtDocumentNumber.Text)
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
                        SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                        SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                        SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                        SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                        SQL &= String.Format(" PaidFor = '{0}', ", "Accounts Receivable")
                        SQL &= " `Status` = 'PENDING',"
                        SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                        SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                        SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                        SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    End If
                Next
                'ACCOUNTING ENTRY ***********************************************************************************************************
                DataObject(SQL)

                Logs("Accounts Receivable", "Save", String.Format("Add new Accounts Receivable for {0} with Amount {1}.", cbxPayor.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                If From_JV_Restructure Then
                    btnSave.DialogResult = DialogResult.OK
                    btnSave.DialogResult = DialogResult.OK
                    btnSave.PerformClick()
                End If
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM accounts_receivable WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
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

                Dim SQL As String = "UPDATE accounts_receivable SET"
                SQL &= String.Format(" PayorID = '{0}', ", ValidateComboBox(cbxPayor))
                SQL &= String.Format(" Payor = '{0}', ", cbxPayor.Text.InsertQuote)
                SQL &= String.Format(" Payor_Type = '{0}', ", If(cbxPayor.SelectedIndex = -1, "", drv("Type")))
                SQL &= String.Format(" PostingDate = '{0}', ", Format(dtpPostingDate.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" Amount = '{0}', ", dAmount.Value)
                SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                SQL &= String.Format(" Explanation = '{0}', ", rExplanation.Text.InsertQuote)
                If txtChecked.Text = "" Then
                    SQL &= String.Format(" OTAC_Check = '{0}', ", Code)
                ElseIf txtApproved.Text = "" Then
                    SQL &= String.Format(" OTAC_Approve = '{0}', ", Code)
                End If
                SQL &= String.Format(" ReferenceNumber = '{0}' ", txtReferenceNumber.Text)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                SQL &= String.Format("UPDATE ar_details SET `status` = 'CANCELLED' WHERE DocumentNumber = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                Dim SQLv3 As String = ""
                SQLv3 &= String.Format(" UPDATE due_to SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQLv3 &= String.Format(" UPDATE due_from SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQLv3 &= String.Format(" UPDATE accounts_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                SQLv3 &= String.Format(" UPDATE loans_payable SET `status` = 'MODIFIED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
                DataObject(SQLv3)
                For x As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(x, "Account").ToString = "" Then
                    Else
                        SQL &= "INSERT INTO ar_details SET"
                        SQL &= String.Format(" DocumentNumber = '{0}', ", txtDocumentNumber.Text)
                        SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                        SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                        SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                        SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                        SQL &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                        SQL &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                        SQL &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)

                        'AUTO ENTRY FOR ACCOUNTS PAYABLE OR ACCOUNTS RECEIVABLE FROM JOURNAL VOUCHER PER ACCOUNT****************************
                        Dim SQLv2 As String = ""
                        If (GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Or GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Payable")) Then
                            Dim APNumber As String
                            Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due to") Then
                                APNumber = DataObject(String.Format("SELECT CONCAT('DT-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_to WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                SQLv2 &= "INSERT INTO due_to SET"
                            Else
                                APNumber = DataObject(String.Format("SELECT CONCAT('AP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM accounts_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                                SQLv2 &= "INSERT INTO accounts_payable SET"
                            End If
                            If cbxPayor.Text = "" Then
                                SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                            Else
                                SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, ValidateComboBox(cbxPayor), BranchTagged))
                                SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, cbxPayor.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
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
                        ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Due from") Then
                            Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                            Dim ARNumber As String = DataObject(String.Format("SELECT CONCAT('DF-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM due_from WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                            SQLv2 &= " INSERT INTO due_from SET"
                            If cbxPayor.Text = "" Then
                                SQLv2 &= String.Format(" PayorID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                SQLv2 &= String.Format(" Payor = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                SQLv2 &= String.Format(" Payor_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                            Else
                                SQLv2 &= String.Format(" PayorID = '{0}', ", If(BranchTagged = 999, ValidateComboBox(cbxPayor), BranchTagged))
                                SQLv2 &= String.Format(" Payor = '{0}', ", If(BranchTagged = 999, cbxPayor.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
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

                            SQLv2 &= "INSERT INTO df_details SET"
                            SQLv2 &= String.Format(" DocumentNumber = '{0}', ", ARNumber)
                            SQLv2 &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                            SQLv2 &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                            SQLv2 &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                            SQLv2 &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                            SQLv2 &= String.Format(" Debit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Debit")))
                            SQLv2 &= String.Format(" Credit = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Credit")))
                            SQLv2 &= String.Format(" Remarks = '{0}';", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                        ElseIf GridView2.GetRowCellValue(x, "Account").ToString.Contains("Loans Payable") Then
                            Dim BranchTagged As Integer = DataObject(String.Format("SELECT BranchTagged FROM account_chart WHERE `Code` = '{0}' AND `status` = 'ACTIVE';", GridView2.GetRowCellValue(x, "Account Code")))
                            Dim ARNumber As String = DataObject(String.Format("SELECT CONCAT('LP-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM loans_payable WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDocument.Value, "yy"), Format(dtpDocument.Value, "yyyy-MM-dd")))

                            SQLv2 &= " INSERT INTO loans_payable SET"
                            If cbxPayor.Text = "" Then
                                SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, 0, BranchTagged))
                                SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, "", DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
                            Else
                                SQLv2 &= String.Format(" PayeeID = '{0}', ", If(BranchTagged = 999, ValidateComboBox(cbxPayor), BranchTagged))
                                SQLv2 &= String.Format(" Payee = '{0}', ", If(BranchTagged = 999, cbxPayor.Text.InsertQuote, DataObject(String.Format("SELECT Branch('{0}');", BranchTagged))))
                                SQLv2 &= String.Format(" Payee_Type = '{0}', ", If(BranchTagged = 999, "", "B"))
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
                                SQLv2 &= " AP_Status = 'CHECKED', "
                            End If
                            SQLv2 &= " ApprovedID = '0', "
                            SQLv2 &= " OTAC_Approve = '', "
                            SQLv2 &= String.Format(" OTAC_Check = '{0}', ", Code)
                            SQLv2 &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                            SQLv2 &= String.Format(" JVNumberV2 = '{0}', ", txtDocumentNumber.Text)
                            SQLv2 &= String.Format(" Branch_ID = '{0}';", Branch_ID)

                            SQLv2 &= "INSERT INTO lp_details SET"
                            SQLv2 &= String.Format(" DocumentNumber = '{0}', ", ARNumber)
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
                SQL &= String.Format("UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE CVNumber = '{0}';", txtDocumentNumber.Text)
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    SQL &= "INSERT INTO accounting_entry SET"
                    If drv("Type") = "LA" Then
                        SQL &= String.Format(" ReferenceN = '{0}', ", cbxPayor.SelectedValue)
                    Else
                        SQL &= String.Format(" ReferenceN = '{0}', ", txtDocumentNumber.Text)
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
                    SQL &= String.Format(" AccountCode = '{0}', ", GridView2.GetRowCellValue(x, "Account Code"))
                    SQL &= String.Format(" MotherCode = '{0}', ", GridView2.GetRowCellValue(x, "MotherCode"))
                    SQL &= String.Format(" BusinessCode = '{0}', ", GridView2.GetRowCellValue(x, "BusinessCode"))
                    SQL &= String.Format(" DepartmentCode = '{0}', ", GridView2.GetRowCellValue(x, "Department Code"))
                    SQL &= String.Format(" PaidFor = '{0}', ", "Accounts Receivable")
                    SQL &= " `Status` = 'PENDING',"
                    SQL &= String.Format(" ORDate = '{0}', ", FormatDatePicker(dtpPostingDate))
                    SQL &= String.Format(" CVNumber = '{0}', ", txtDocumentNumber.Text)
                    SQL &= String.Format(" Remarks = '{0}', ", GridView2.GetRowCellValue(x, "Remarks").ToString.InsertQuote)
                    SQL &= String.Format(" BankID = '{0}', ", cbxBank.SelectedValue)
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                Next
                'ACCOUNTING ENTRY ***********************************************************************************************************
                DataObject(SQL)

                Logs("Accounts Receivable", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
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
            TriggerBugReport("Accounts Receivable - Changes", ex.Message.ToString)
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
            Dim SQL As String = String.Format("UPDATE accounts_receivable SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID)
            SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'CANCELLED' WHERE CVNumber = '{0}' AND (ReferenceN = '{0}' OR ReferenceN = '{1}');", txtDocumentNumber.Text, cbxPayor.SelectedValue)
            SQL &= String.Format(" UPDATE due_to SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_from SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE loans_payable SET `status` = 'CANCELLED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            DataObject(SQL)
            Logs("Accounts Receivable", "Cancel", Reason, String.Format("Cancel Accounts Receivable of {0} with Amount {1}.", cbxPayor.Text.InsertQuote & " - " & txtDocumentNumber.Text, dAmount.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Generate_AR(Show As Boolean, FName As String, CheckedBy As String, ApprovedBy As String)
        Dim Report As New RptAccountsReceivable
        With Report
            .Name = String.Format("Accounts Receivable of {0} - {1}", cbxPayor.Text, txtDocumentNumber.Text)

            .lblSupplier.Text = cbxPayor.Text
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
            Generate_AR(True, "", txtChecked.Text, txtApproved.Text)
            Logs("Accounts Receivable", "Print", "[SENSITIVE] Print Accounts Receivable " & txtDocumentNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ACCOUNTS RECEIVABLE LIST", GridControl1)
            Logs("Accounts Receivable", "Print", "[SENSITIVE] Print Accounts Receivable List", "", "", "", "")
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or If(From_GL Or From_JV_Restructure, e.KeyCode = Keys.Escape, 0) Then
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
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        PanelEx2.Enabled = False
        GridView2.OptionsBehavior.Editable = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            dtpDocument.Value = .GetFocusedRowCellValue("Document Date")
            txtDocumentNumber.Text = .GetFocusedRowCellValue("Document Number")
            FirstLoad = True
            cbxPayor.Text = .GetFocusedRowCellValue("Payor")
            cbxPayor.Tag = .GetFocusedRowCellValue("Payor")
            FirstLoad = False
            cbxBank.SelectedValue = .GetFocusedRowCellValue("BankID")
            cbxBank.Tag = .GetFocusedRowCellValue("Bank")
            dtpPostingDate.Value = .GetFocusedRowCellValue("Posting Date")
            dtpPostingDate.Tag = .GetFocusedRowCellValue("Posting Date")
            txtReferenceNumber.Text = .GetFocusedRowCellValue("Reference Number")
            txtReferenceNumber.Tag = .GetFocusedRowCellValue("Reference Number")
            rExplanation.Text = .GetFocusedRowCellValue("Explanation")
            rExplanation.Tag = .GetFocusedRowCellValue("Explanation")
        End With

        If CompanyMode = 0 Then
            DT_Account = DataSource(String.Format("SELECT MotherCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = MotherCode(ar_details.AccountCode)) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode FROM ar_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
        Else
            DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = ar_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode FROM ar_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
        End If
        GridControl2.DataSource = DT_Account
        Dim TotalDebit As Double
        Dim TotalCredit As Double
        Dim Total_CIB As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Then
                Total_CIB += CDbl(DT_Account(x)("Debit"))
            End If
        Next
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB
        If GridView2.RowCount > 11 Then
            GridColumn45.Width = 342 - 17
        Else
            GridColumn45.Width = 342
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
        End With

        SuperTabControl1.SelectedTab = tabSetup
        If GridView1.GetFocusedRowCellValue("AR_Status") = "PENDING" Or GridView1.GetFocusedRowCellValue("AR_Status") = "FOR CHECKING" Then
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
        ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "CHECKED" Or GridView1.GetFocusedRowCellValue("AR_Status") = "FOR APPROVAL" Then
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
        ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "APPROVED" Then
            btnCheck.Visible = False
            btnApprove.Visible = False
            btnModify.Enabled = False
        End If

        If GridView1.GetFocusedRowCellValue("JVNumberV2") <> "" Then
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

    Private Sub CbxPayor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayor.SelectedIndexChanged
        If FirstLoad Or CopyMode Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            If dtpPostingDate.Value > Date.Now Then
                dtpPostingDate.Value = Date.Now
            End If
            dtpPostingDate.MaxDate = Date.Now
            If cbxPayor.SelectedIndex = -1 Or cbxPayor.Text = "" Then
                Clear(False)
            Else
                Dim drv As DataRowView = DirectCast(cbxPayor.SelectedItem, DataRowView)
                cbxBank.SelectedValue = drv("BankID")

                If drv("Type") = "RS" Then
                    Dim Credit_Info As DataTable = DataSource(String.Format("SELECT IFNULL((SELECT SUM(Amount) AS 'Amount' FROM credit_processing_fee WHERE credit_processing_fee.CreditNumber = credit_application.CreditNumber AND `status` = 'ACTIVE'),0) AS 'Processing Fee', service_charge AS 'Service Charge', appraisal_fee AS 'Deficient Income', Miscellaneous_Income AS 'Restructuring Fee', BusinessCenterCode(BusinessID) AS 'BusinessCode', Mortgage_ID FROM credit_application WHERE CreditNumber = '{0}';", cbxPayor.SelectedValue))
                    DT_Account.Rows.Clear() '*CLEAR*******************************************************************************************
                    'DEBIT
                    AccountCodeDetails("112101")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", Credit_Info(0)("BusinessCode"))), "", CDbl(Credit_Info(0)("Processing Fee")) + CDbl(Credit_Info(0)("Service Charge")) + CDbl(Credit_Info(0)("Deficient Income")) + CDbl(Credit_Info(0)("Restructuring Fee")), 0, "", DT_Temp_Account(0)("RequiredRemarks"), Credit_Info(0)("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"))
                    'CREDIT
                    AccountCodeDetails(If(Credit_Info(0)("Mortgage_ID") = 1, "420201", If(Credit_Info(0)("Mortgage_ID") = 2, "420202", "420203")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", Credit_Info(0)("BusinessCode"))), "", 0, CDbl(Credit_Info(0)("Processing Fee")), "Processing Fee", DT_Temp_Account(0)("RequiredRemarks"), Credit_Info(0)("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"))
                    AccountCodeDetails(If(Credit_Info(0)("Mortgage_ID") = 1, "420101", If(Credit_Info(0)("Mortgage_ID") = 2, "420102", "420103")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", Credit_Info(0)("BusinessCode"))), "", 0, CDbl(Credit_Info(0)("Service Charge")), "Service Charge", DT_Temp_Account(0)("RequiredRemarks"), Credit_Info(0)("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"))
                    AccountCodeDetails("229104")
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", Credit_Info(0)("BusinessCode"))), "", 0, CDbl(Credit_Info(0)("Deficient Income")), "Deficient Amount", DT_Temp_Account(0)("RequiredRemarks"), Credit_Info(0)("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"))
                    AccountCodeDetails(If(Credit_Info(0)("Mortgage_ID") = 1, "420201", If(Credit_Info(0)("Mortgage_ID") = 2, "420202", "420203")))
                    DT_Account.Rows.Add(DT_Temp_Account(0)("Code"), "", DT_Temp_Account(0)("Account"), DataObject(String.Format("SELECT BusinessCenter('{0}')", Credit_Info(0)("BusinessCode"))), "", 0, CDbl(Credit_Info(0)("Restructuring Fee")), "Restructuring Fee", DT_Temp_Account(0)("RequiredRemarks"), Credit_Info(0)("BusinessCode"), 0, DT_Temp_Account(0)("MotherCode"))

                    Dim TotalDebit As Double
                    Dim TotalCredit As Double
                    Dim Total_CIB As Double
                    For x As Integer = 0 To DT_Account.Rows.Count - 1
                        TotalDebit += CDbl(DT_Account(x)("Debit"))
                        TotalCredit += CDbl(DT_Account(x)("Credit"))
                        If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Then
                            Total_CIB += CDbl(DT_Account(x)("Debit"))
                        End If
                    Next
                    dDebitT.Value = TotalDebit
                    dCreditT.Value = TotalCredit
                    dAmount.Value = Total_CIB
                ElseIf drv("Type") = "LA" Then
                    dtpPostingDate.MaxDate = "12/31/9998"
                End If
            End If

            If GridView2.RowCount > 11 Then
                GridColumn45.Width = 342 - 17
            Else
                GridColumn45.Width = 342
            End If
        Catch ex As Exception
        End Try
        Cursor = Cursors.Default
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
            .FolderName = "Accounts Receivable-" & GridView1.GetFocusedRowCellValue("Document Number")
            .ARNumberv2 = GridView1.GetFocusedRowCellValue("Document Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Document Number")
            .Type = "Accounts Receivable"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("AR_Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Or Status = "REVERSED" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            End If
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

                            DataObject(String.Format("UPDATE accounts_receivable SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, .cbxProvider.SelectedValue, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Accounts Receivable", "Check", String.Format("Checked Accounts Receivable of {0} with the total amount of {1}. [Via OTAC]", cbxPayor.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

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
            If MsgBoxYes("Are you sure you check this Accounts Receivable?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    ApproveNotification(Code, False)
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                DataObject(String.Format("UPDATE accounts_receivable SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_receivable SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'CHECKED', CheckedID = '{1}', OTAC_Approve = '{2}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Accounts Receivable", "Check", String.Format("Checked Accounts Receivable of {0} with the total amount of {1}.", cbxPayor.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

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

        Dim drv As DataRowView = DirectCast(cbxPayor.SelectedItem, DataRowView)
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

                            DataObject(String.Format(SQL & "UPDATE accounts_receivable SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{3}' WHERE JVNumberV2 = '{2}';", ID, .cbxProvider.SelectedValue, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                            Logs("Accounts Receivable", "Approve", String.Format("Approved Accounts Receivable of {0} with the total amount of {1}. [Via OTAC]", cbxPayor.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

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
            If MsgBoxYes("Are you sure you want to approve this Accounts Receivable?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = String.Format("UPDATE accounting_entry SET ORDate = '{1}', `Status` = 'ACTIVE', PostStatus = 'POSTED' WHERE CVNumber = '{0}' AND `status` = 'PENDING';", txtDocumentNumber.Text, Format(dtpPostingDate.Value, "yyyy-MM-dd"))

                DataObject(String.Format(SQL & "UPDATE accounts_receivable SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE ID = '{0}'; UPDATE accounts_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_from SET `AR_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE due_to SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}'; UPDATE loans_payable SET `AP_Status` = 'APPROVED', ApprovedID = '{1}', PostingDate = '{4}' WHERE JVNumberV2 = '{3}';", ID, Empl_ID, Code, txtDocumentNumber.Text, FormatDatePicker(dtpPostingDate)))
                Logs("Accounts Receivable", "Approve", String.Format("Approved Accounts Receivable of {0} with the total amount of {1}.", cbxPayor.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "", "")

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
        If MsgBoxYes("Are you sure you want to disapprove this Accounts Receivable?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim SQL As String = String.Format("UPDATE accounts_receivable SET `status` = 'DISAPPROVED' WHERE ID = '{0}';", ID)
            SQL &= String.Format(" UPDATE accounting_entry SET `status` = 'DISAPPROVED' WHERE CVNumber = '{0}' AND (ReferenceN = '{0}' OR ReferenceN = '{1}');", txtDocumentNumber.Text, cbxPayor.SelectedValue)
            SQL &= String.Format(" UPDATE due_to SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE due_from SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE accounts_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            SQL &= String.Format(" UPDATE loans_payable SET `status` = 'DISAPPROVED' WHERE JVNumberV2 = '{0}' AND `status` = 'ACTIVE';", txtDocumentNumber.Text)
            DataObject(SQL)
            Logs("Accounts Receivable", "Disapprove", Reason, String.Format("Disapprove Accounts Receivable of {0} with Amount {1}.", cbxPayor.Text.InsertQuote & " - " & txtDocumentNumber.Text, dDebitT.Text), "", "", "")
            Clear(True)
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
        FirstLoad = True
        cbxPayor.Text = GridView1.GetFocusedRowCellValue("Payor")
        FirstLoad = False
        cbxBank.SelectedValue = GridView1.GetFocusedRowCellValue("BankID")
        dtpPostingDate.Value = Date.Now
        txtReferenceNumber.Text = GridView1.GetFocusedRowCellValue("Reference Number")
        rExplanation.Text = GridView1.GetFocusedRowCellValue("Explanation")

        DT_Account = DataSource(String.Format("SELECT AccountCode AS 'Account Code', DepartmentCode AS 'Department Code', (SELECT CONCAT(Title, ' ', `Code`) FROM account_chart WHERE `Code` = ar_details.AccountCode) AS 'Account', BusinessCenter(BusinessCode) AS 'Business Center', CONCAT(DepartmentCode, ' - ', Department(DepartmentCode)) AS 'Department', Debit, Credit, Remarks, Required AS 'RequiredRemarks', BusinessCode, TypeID(AccountCode) AS 'Type_ID', MotherCode FROM ar_details WHERE `status` = 'ACTIVE' AND DocumentNumber = '{0}';", GridView1.GetFocusedRowCellValue("Document Number")))
        GridControl2.DataSource = DT_Account
        Dim TotalDebit As Double
        Dim TotalCredit As Double
        Dim Total_CIB As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            TotalDebit += CDbl(DT_Account(x)("Debit"))
            TotalCredit += CDbl(DT_Account(x)("Credit"))
            If GridView2.GetRowCellValue(x, "Account").ToString.Contains("Accounts Receivable") Then
                Total_CIB += CDbl(DT_Account(x)("Debit"))
            End If
        Next
        dDebitT.Value = TotalDebit
        dCreditT.Value = TotalCredit
        dAmount.Value = Total_CIB
        If GridView2.RowCount > 11 Then
            GridColumn45.Width = 342 - 17
        Else
            GridColumn45.Width = 342
        End If
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub IAcknowledge_Click(sender As Object, e As EventArgs) Handles iAcknowledge.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("AR_Status") = "FOR APPROVAL" Then
                MsgBox("Accounts Receivable is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "FULLY PAID" Then
                MsgBox("Accounts Receivable is already FULLY PAID.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("NotAR") = 1 Then
                MsgBox("Accounts Receivable is not for Acknowledgement.", MsgBoxStyle.Information, "Info")
                Exit Sub
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
            Logs("Accounts Receivable", "Acknowledgement", "Acknowledgement Receipt", "", "", "", "")

            .FromAccountsReceivable = True
            .Clear(False)
            .tabList.Visible = False
            .btnNext.Enabled = False
            .btnRefresh.Enabled = False
            .cbxAR.Checked = True
            .cbxAP.Checked = False
            .cbxDF.Checked = False
            .cbxLOE.Checked = False
            .cbxITL.Checked = False
            .cbxRO.Checked = False
            .cbxLOE.Enabled = False
            .cbxAR.Enabled = False
            .cbxAP.Enabled = False
            .cbxDF.Enabled = False
            .cbxITL.Enabled = False
            .cbxRO.Enabled = False
            .cbxLA.Enabled = False
            .cbxLA.Checked = False
            .cbxCAS.Enabled = False
            .cbxCAS.Checked = False
            .cbxPayee.Enabled = False
            .AccountsReceivableID = GridView1.GetFocusedRowCellValue("ID")
            .AR_Account = DataObject(String.Format("SELECT AccountCode FROM ar_details WHERE DocumentNumber = '{0}' AND Debit > 0 AND `status` = 'ACTIVE' LIMIT 1;", GridView1.GetFocusedRowCellValue("Document Number")))
            .BankID = GridView1.GetFocusedRowCellValue("BankID")

            Dim Rows As New ArrayList()
            Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            If selectedRowHandles.Length > 1 Then
                Dim I As Integer
                Dim Docs As String = ""
                For I = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Integer = selectedRowHandles(I)
                    If (selectedRowHandle >= 0) Then
                        Rows.Add(GridView1.GetDataRow(selectedRowHandle))
                    End If
                Next
                For x As Integer = 0 To selectedRowHandles.Length - 1
                    If GridView1.GetFocusedRowCellValue("Payor") = Rows(x)("Payor") Then
                    Else
                        MsgBox("Selected Payors are not the same.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    If Rows(x)("AR_Status") = "APPROVED" Or Rows(x)("AR_Status") = "PARTIALLY PAID" Then
                    Else
                        MsgBox(String.Format("Selected Accounts Receivable have a {0} status.", Rows(x)("AR_Status")), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Docs &= "'" & Rows(x)("Document Number") & "'"
                    If x < selectedRowHandles.Length - 1 Then
                        Docs &= ", "
                    End If
                Next
                .AccountsReceivableID_M = Docs
                .MultipleAR = True
                .btnAdd_Account.Enabled = False
                .btnRemove_Account.Enabled = False
            End If

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub INotAR_Click(sender As Object, e As EventArgs) Handles iNotAR.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("AR_Status") = "FOR APPROVAL" Then
                MsgBox("Accounts Receivable is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "FULLY PAID" Or GridView1.GetFocusedRowCellValue("AR_Status") = "PARTIALLY PAID" Then
                MsgBox("Accounts Receivable already have a transaction.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("AR_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("AR_Status") = "DISAPPROVED" Then
                MsgBox(String.Format("Amount Receivable is already {0}.", GridView1.GetFocusedRowCellValue("AR_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes(String.Format("Are you sure you want to set this as {0}Accounts Receivable?", If(GridView1.GetFocusedRowCellValue("NotAR") = 0, "Not ", ""))) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Dim SQL As String = String.Format("UPDATE accounts_receivable SET NotAR = {1} WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), If(GridView1.GetFocusedRowCellValue("NotAR") = 0, 1, 0))
            DataObject(SQL)
            Logs("Accounts Receivable", "Not AR", Reason, "", "", "", "")
            LoadData()
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnRename_Click(sender As Object, e As EventArgs) Handles btnRename.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "FULLY PAID" Or GridView1.GetFocusedRowCellValue("AR_Status") = "PARTIALLY PAID" Then
                MsgBox("Accounts Receivable already have a transaction.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumberV2") = "" Then
                If GridView1.GetFocusedRowCellValue("Payor_Type") = "B" Then
                Else
                    MsgBox("Accounts Receivable is not auto generated.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Rename As New FrmRenamePayee
        With Rename
            .txtPayee.Text = GridView1.GetFocusedRowCellValue("Payor")
            .lblTitle.Text = "PAYOR"
            .lblDeposit.Text = "Rename Payor :"
            If .ShowDialog = DialogResult.OK Then
                Dim SQL As String = String.Format("UPDATE accounts_receivable SET Payor = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), .txtPayee.Text.InsertQuote)
                DataObject(SQL)
                Logs("Accounts Receivable", "Change Payor", String.Format("Changed Payor for {0} from {1} to {2}", GridView1.GetFocusedRowCellValue("Payor").ToString.InsertQuote & " - " & GridView1.GetFocusedRowCellValue("Document Number"), GridView1.GetFocusedRowCellValue("Payor").ToString.InsertQuote, .txtPayee.Text.InsertQuote), "", "", "", "")
                LoadData()
                MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
            End If
        End With
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
            Dim TotalP As Double
            For x As Integer = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Integer = selectedRowHandles(x)
                TotalR += GridView1.GetRowCellValue(selectedRowHandle, "Total Receivable")
                TotalP += GridView1.GetRowCellValue(selectedRowHandle, "Total Payment")
            Next
            GridView1.Columns("Total Receivable").SummaryItem.DisplayFormat = FormatNumber(TotalR, 2)
            GridView1.Columns("Total Payment").SummaryItem.DisplayFormat = FormatNumber(TotalP, 2)
        Else
            GridView1.Columns("Total Receivable").SummaryItem.DisplayFormat = "{0:n2}"
            GridView1.Columns("Total Payment").SummaryItem.DisplayFormat = "{0:n2}"
        End If
    End Sub

    Private Sub IJV_Click(sender As Object, e As EventArgs) Handles iJV.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("JVNumber") <> "" Then
                MsgBox("Accounts Receivable is already reversed. Please check your data.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("AR_Status") = "FOR APPROVAL" Then
                MsgBox("Accounts Receivable is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "APPROVED" Or GridView1.GetFocusedRowCellValue("AR_Status") = "NON RECEIVABLE" Then
            Else
                MsgBox(String.Format("Accounts Receivable is already {0}.", GridView1.GetFocusedRowCellValue("AR_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
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
            Logs("Accounts Receivable", "Journal Voucher", "Journal Voucher", "", "", "", "")
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
            .cbxAR.Checked = True
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
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Updated Accounts Receivable of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayor.Text, dDebitT.Text, cbxPreparedBy.Text)
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
                Generate_AR(False, FName, txtChecked.Text, txtApproved.Text)
                AttachmentFiles.Add(FName)
                SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
            End If
            'F O R   C H E C K I N G************************************************************************************************************************
        ElseIf txtApproved.Text = "" Then
            'F O R   A P P R O V A L ***********************************************************************************************************************
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee").ToString.Trim)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Updated Accounts Receivable of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayor.Text, dDebitT.Text, cbxPreparedBy.Text)
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
                Generate_AR(False, FName, txtChecked.Text, txtApproved.Text)
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
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for CHECKING of Accounts Receivable of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayor.Text, dDebitT.Text, cbxPreparedBy.Text)
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
            Generate_AR(False, FName, txtChecked.Text, txtApproved.Text)
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
                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for APPROVAL of Accounts Receivable of {1} with the amount of {2} prepared by {3}." & vbCrLf, Code, cbxPayor.Text, dDebitT.Text, cbxPreparedBy.Text)
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
            Generate_AR(False, FName, txtChecked.Text, txtApproved.Text)
            AttachmentFiles.Add(FName)
            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, SendMail, False, 0, "", "")
        End If
    End Sub

    Private Sub ICheckVoucher_Click(sender As Object, e As EventArgs) Handles iCheckVoucher.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "FOR CHECKING" Or GridView1.GetFocusedRowCellValue("AR_Status") = "FOR APPROVAL" Then
                MsgBox("Accounts Receivable is not yet APPROVED.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("AR_Status") = "FULLY PAID" Then
                MsgBox("Accounts Receivable is already FULLY PAID.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("NotAR") = 1 Then
                MsgBox("Accounts Receivable is not for Check Voucher.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim CV As New FrmCheckVoucher
        With CV
            If FrmMain.lblDate.Text.Contains("Disconnected") Then
                MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
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
            Logs("Accounts Receivable", "Check Voucher", "Check Voucher", "", "", "", "")

            .From_AccountsPayable = True
            .Clear(False)
            .tabList.Visible = False
            .btnNext.Enabled = False
            .btnRefresh.Enabled = False
            .cbxAP.Checked = False
            .cbxAR.Checked = True
            .cbxDT.Checked = False
            .cbxLA.Checked = False
            .cbxCAS.Checked = False
            .cbxSUP.Checked = False
            .cbxEMP.Checked = False
            .cbxLA.Enabled = False
            .cbxCAS.Enabled = False
            .cbxSUP.Enabled = False
            .cbxEMP.Enabled = False
            .cbxAP.Enabled = False
            .cbxAR.Enabled = False
            .cbxDT.Enabled = False
            .cbxRC.Enabled = False
            .cbxPayee.Enabled = False
            .AccountNumber = GridView1.GetFocusedRowCellValue("Document Number")
            .AP_Account = DataObject(String.Format("SELECT AccountCode FROM ar_details WHERE DocumentNumber = '{0}' AND Debit > 0 AND `status` = 'ACTIVE' LIMIT 1;", GridView1.GetFocusedRowCellValue("Document Number")))
            .DefaultBank = GridView1.GetFocusedRowCellValue("BankID")

            Dim Rows As New ArrayList()
            Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
            If selectedRowHandles.Length > 1 Then
                Dim I As Integer
                Dim Docs As String = ""
                For I = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Integer = selectedRowHandles(I)
                    If (selectedRowHandle >= 0) Then
                        Rows.Add(GridView1.GetDataRow(selectedRowHandle))
                    End If
                Next
                For x As Integer = 0 To selectedRowHandles.Length - 1
                    If GridView1.GetFocusedRowCellValue("Payor") = Rows(x)("Payor") Then
                    Else
                        MsgBox("Selected Payors are not the same.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                    If Rows(x)("AR_Status") = "APPROVED" Or Rows(x)("AR_Status") = "PARTIALLY PAID" Then
                    Else
                        MsgBox(String.Format("Selected Accounts Receivable have a {0} status.", Rows(x)("AR_Status")), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Docs &= "'" & Rows(x)("Document Number") & "'"
                    If x < selectedRowHandles.Length - 1 Then
                        Docs &= ", "
                    End If
                Next
                .AccountsPayableID_M = Docs
                .MultipleAP = True
            End If

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub BtnReference_Click(sender As Object, e As EventArgs) Handles btnReference.Click
        GridView1.SetFocusedRowCellValue("Reference Number", UpdateReferenceNumber("Accounts Receivable", "accounts_receivable", GridView1.GetFocusedRowCellValue("Reference Number"), GridView1.GetFocusedRowCellValue("ID"), GridView1.GetFocusedRowCellValue("Document Number")))
    End Sub
End Class