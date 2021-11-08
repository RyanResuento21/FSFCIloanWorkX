Imports DevExpress.XtraReports.UI
Public Class FrmLiquidation

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT_Particular As DataTable
    Dim Persons As Integer = 1
    Dim Code As String

    Dim Dept_Head As Boolean
    Dim User_EmplID As Integer
    Dim CA_Approver As Integer
    Dim Code_Check As String
    Dim Code_Approve As String
    Public From_CAS As Boolean
    Public AccountNumber As String
    Private Sub FrmLiquidation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        cbxDisplay.SelectedIndex = 0

        dtpDate.Value = Date.Now
        DT_Particular = DataSource(String.Format("SELECT 0 AS 'ID', '' AS 'Particulars', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount' LIMIT 1"))
        GridControl2.DataSource = DT_Particular
        GridColumn9.Width = 985
        GridColumn10.Width = 125
        GridColumn33.Visible = False
        GridColumn32.Visible = False
        GridColumn31.Visible = False
        GridColumn29.Visible = False
        GridColumn28.Visible = False
        GridColumn27.Visible = False
        GridColumn26.Visible = False
        GridColumn25.Visible = False
        GridColumn35.Visible = False
        GridColumn34.Visible = False

        Dim DT_Status As DataTable = DataSource("SELECT 'For Checking' AS 'Status' UNION SELECT 'For Approval' UNION SELECT 'For Check Voucher' UNION SELECT 'For Petty Cash' UNION SELECT 'For Acknowledgement Receipt' UNION SELECT 'Partially Acknowledged' UNION SELECT 'For Journal Voucher' UNION SELECT 'Unposted JV' UNION SELECT 'Posted JV' UNION SELECT 'Cancelled'")
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

        With cbxPayee
            .DisplayMember = "Employee"
            .ValueMember = "ID"
        End With
        LoadPayee("")
        If From_CAS = False Then
            cbxPayee.SelectedIndex = -1
        End If

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With
        GetAccountNumber()
        LoadData()
        FirstLoad = False
        If From_CAS Then
            CbxPayee_SelectedIndexChanged(sender, e)
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

            GetLabelFontSettings({LabelX2, LabelX4, LabelX10, LabelX6, LabelX5, LabelX34, LabelX8, LabelX3, LabelX9, LabelX12, LabelX13, LabelX14, LabelX40, LabelX42, LabelX41, LabelX39})

            GetTextBoxFontSettings({txtAccountNumber, txtPurpose, txtApprovedBy, txtCheckedBy, txtCheckNumber, txtCVNumber})

            GetCheckBoxFontSettings({cbxAll})

            GetComboBoxFontSettings({cbxPayee, cbxPreparedBy, cbxDisplay})

            GetDateTimeInputFontSettings({dtpDate, dtpFrom, dtpTo})

            GetDoubleInputFontSettings({dTotalExpense, dAmountReceived, dRefundable})

            GetContextMenuBarFontSettings({ContextMenuBar3, ContextMenuBar1})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnDisapprove, btnCheck, btnApprove, btnAttach, btnSearch})

            GetTabControlFontSettings({SuperTabControl1})

            GetLabelFontSettingsWithTopBorder({LabelX1, LabelX35, LabelX7})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Liquidation - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Liquidation of Expenses", lblTitle.Text)
    End Sub

    Private Sub LoadPayee(ReferenceN As String)
        cbxPayee.DataSource = DataSource(String.Format("SELECT CA.Payee_ID AS 'ID', CA.AccountNumber, CONCAT(Employee(CA.Payee_ID), ' [', CA.AccountNumber, ']') AS 'Employee', CA.Purpose, CV.DocumentNumber, CV.CheckNumber, CV.Amount, IFNULL((SELECT head FROM position_setup WHERE ID = (SELECT Position_ID FROM employee_setup WHERE ID = CA.Payee_ID)),0) AS 'Head', (SELECT Department_ID FROM employee_setup WHERE ID = CA.Payee_ID) AS 'department_id', ApprovedID FROM cash_advance CA LEFT JOIN (SELECT ID, Payee_ID, DocumentNumber, CheckNumber, Amount, voucher_status, ClearedDate FROM check_voucher WHERE `status` = 'ACTIVE' AND Payee_Type = 'A') CV ON CV.Payee_ID = CA.AccountNumber WHERE CA.`status` = 'ACTIVE' AND ACRNumber = '' AND CA.slip_status = 'RECEIVED' AND IF('{1}' = '',CA.Liquidated = 'N',CA.AccountNumber = '{1}') AND CV.voucher_status = 'RECEIVED' AND CA.Branch_ID = '{0}' AND IF('{2}' = '',TRUE,AccountNumber = '{2}') AND IF('{1}' = '',ClearedDate != '',TRUE);", Branch_ID, ReferenceN, AccountNumber))
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    Liq.ID,"
        SQL &= "    Liq.Payee_ID,"
        SQL &= "    Payee,"
        SQL &= "    DATE_FORMAT(Trans_Date,'%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Account Number',"
        SQL &= "    (SELECT Purpose FROM cash_advance WHERE AccountNumber = CANumber LIMIT 1) AS 'Purpose',"
        SQL &= "    TotalExpenses AS 'Total Expenses',"
        SQL &= "    CV.Amount AS 'Amount Received',"
        SQL &= "    CV.CheckNumber AS 'Check Number',"
        SQL &= "    CV.DocumentNumber AS 'CV Number',"
        SQL &= "    AmountDue AS 'Amount Due',"
        SQL &= "    AmountAcknowledged AS 'Acknowledged',"
        SQL &= "    CANumber AS 'CA Number',"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID, Employee(CheckedID) AS 'Checked By', Employee(ApprovedID) AS 'Approved By', ApprovedID, "
        SQL &= "    BRANCH(branch_id) AS 'Branch', Branch_ID, Persons, Caption1, Caption2, Caption3, Caption4, Caption5, Caption6, Caption7, Caption8, Caption9, Caption10, Check_OTAC, Approve_OTAC, IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(Liq_Status='DISAPPROVED',Liq_Status,IF(((Refund = 1 OR Liq_Status = 'ACKNOWLEDGED') OR (Liq_Status = 'APPROVED' AND AmountDue = 0)) AND JVNumber = '','FOR JOURNAL VOUCHER', IF(JVNumber != '' AND Voucher_Status = 'APPROVED','POSTED JV', IF(JVNumber != '' AND Voucher_Status != 'APPROVED','UNPOSTED JV',IF(Liq_Status = 'PENDING','FOR CHECKING',IF(Liq_Status = 'CHECKED','FOR APPROVAL',IF(AmountDue > 1000,'FOR CHECK VOUCHER',IF(AmountDue > 0 AND AmountDue <= 1000,'FOR PETTY CASH RELEASE',IF(AmountDue < 0 AND Liq_Status = 'APPROVED','FOR ACKNOWLEDGEMENT RECEIPT',Liq_Status)))))))))) AS 'Liq_Status', User_EmplID, Attach, Refund"
        SQL &= "  FROM liquidation_main Liq LEFT JOIN (SELECT ID, Payee_ID, DocumentNumber, CheckNumber, Amount FROM check_voucher WHERE `status` = 'ACTIVE' AND voucher_status = 'RECEIVED') CV ON CV.Payee_ID = Liq.CANumber"
        SQL &= "                            LEFT JOIN (SELECT DocumentNumber AS 'JV', Voucher_Status FROM journal_voucher WHERE `status` = 'ACTIVE' AND JVNumber = '' AND JVFrom = 'Liquidation') J ON JV = JVNumber WHERE"
        Dim ForChecking As Boolean
        Dim ForApproval As Boolean
        Dim ForCheckVoucher As Boolean
        Dim ForPettyCash As Boolean
        Dim ForAcknowledgement As Boolean
        Dim PartiallyAcknowledged As Boolean
        Dim ForJournalVoucher As Boolean
        Dim UnpostedJV As Boolean
        Dim PostedJV As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Checking" Then
                    ForChecking = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    ForApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Check Voucher" Then
                    ForCheckVoucher = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Petty Cash" Then
                    ForPettyCash = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Acknowledgement Receipt" Then
                    ForAcknowledgement = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Partially Acknowledged" Then
                    PartiallyAcknowledged = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Journal Voucher" Then
                    ForJournalVoucher = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Unposted JV" Then
                    UnpostedJV = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Posted JV" Then
                    PostedJV = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForChecking = False And ForApproval = False And ForCheckVoucher = False And ForPettyCash = False And ForAcknowledgement = False And PartiallyAcknowledged = False And ForJournalVoucher = False And UnpostedJV = False And PostedJV = False Then
                SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED') OR Liq_Status = 'DISAPPROVED')"
            Else
                SQL &= " `status` IN ('ACTIVE','CANCELLED','DELETED','DISAPPROVED') AND (Liq_Status = 'DISAPPROVED' "
                If ForChecking Or ForApproval Or ForCheckVoucher Or ForPettyCash Or ForAcknowledgement Or PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                    SQL &= " OR "
                End If
                If ForChecking Then
                    SQL &= " IF(`status` = 'ACTIVE',Liq_Status = 'PENDING',TRUE)"
                    If ForApproval Or ForCheckVoucher Or ForPettyCash Or ForAcknowledgement Or PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',Liq_Status = 'CHECKED',TRUE)"
                    If ForCheckVoucher Or ForPettyCash Or ForAcknowledgement Or PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForCheckVoucher Then
                    SQL &= " IF(`status` = 'ACTIVE',Refund = 0 AND Liq_Status = 'APPROVED' AND AmountDue > 1000,TRUE)"
                    If ForPettyCash Or ForAcknowledgement Or PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForPettyCash Then
                    SQL &= " IF(`status` = 'ACTIVE',Refund = 0 AND Liq_Status = 'APPROVED' AND AmountDue > 0 AND AmountDue <= 1000,TRUE)"
                    If ForAcknowledgement Or PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForAcknowledgement Then
                    SQL &= " IF(`status` = 'ACTIVE',Refund = 0 AND AmountDue < 0 AND Liq_Status = 'APPROVED' AND Refund = 0,TRUE)"
                    If PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If PartiallyAcknowledged Then
                    SQL &= " IF(`status` = 'ACTIVE',Liq_Status = 'PARTIALLY ACKNOWLEDGED',TRUE)"
                    If ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForJournalVoucher Then
                    SQL &= " IF(`status` = 'ACTIVE',((Refund = 1 OR Liq_Status = 'ACKNOWLEDGED') OR (Liq_Status = 'APPROVED' AND AmountDue = 0)) AND JVNumber = '',TRUE)"
                    If UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If UnpostedJV Then
                    SQL &= " IF(`status` = 'ACTIVE',JVNumber != '' AND Voucher_Status != 'APPROVED',TRUE)"
                    If PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If PostedJV Then
                    SQL &= " IF(`status` = 'ACTIVE',JVNumber != '' AND Voucher_Status = 'APPROVED',TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForChecking = False And ForApproval = False And ForCheckVoucher = False And ForPettyCash = False And ForAcknowledgement = False And PartiallyAcknowledged = False And ForJournalVoucher = False And UnpostedJV = False And PostedJV = False Then
            Else
                SQL &= " AND ("
                If ForChecking Then
                    SQL &= " Liq_Status = 'PENDING'"
                    If ForApproval Or ForCheckVoucher Or ForPettyCash Or ForAcknowledgement Or PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',Liq_Status = 'CHECKED',TRUE)"
                    If ForCheckVoucher Or ForPettyCash Or ForAcknowledgement Or PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForCheckVoucher Then
                    SQL &= " IF(`status` = 'ACTIVE',Refund = 0 AND Liq_Status = 'APPROVED' AND AmountDue > 1000,TRUE)"
                    If ForPettyCash Or ForAcknowledgement Or PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForPettyCash Then
                    SQL &= " IF(`status` = 'ACTIVE',Refund = 0 AND Liq_Status = 'APPROVED' AND AmountDue > 0 AND AmountDue <= 1000,TRUE)"
                    If ForAcknowledgement Or PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForAcknowledgement Then
                    SQL &= " IF(`status` = 'ACTIVE',Refund = 0 AND AmountDue < 0 AND Liq_Status = 'APPROVED',TRUE)"
                    If PartiallyAcknowledged Or ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If PartiallyAcknowledged Then
                    SQL &= " IF(`status` = 'ACTIVE',Liq_Status = 'PARTIALLY ACKNOWLEDGED',TRUE)"
                    If ForJournalVoucher Or UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If ForJournalVoucher Then
                    SQL &= " IF(`status` = 'ACTIVE',((Refund = 1 OR Liq_Status = 'ACKNOWLEDGED') OR (Liq_Status = 'APPROVED' AND AmountDue = 0)) AND JVNumber = '',TRUE)"
                    If UnpostedJV Or PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If UnpostedJV Then
                    SQL &= " IF(`status` = 'ACTIVE',JVNumber != '' AND Voucher_Status != 'APPROVED',TRUE)"
                    If PostedJV Then
                        SQL &= " OR "
                    End If
                End If
                If PostedJV Then
                    SQL &= " IF(`status` = 'ACTIVE',JVNumber != '' AND Voucher_Status = 'APPROVED',TRUE)"
                End If
                SQL &= ")"
            End If
        End If
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(Trans_Date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= String.Format("  AND Branch_ID IN ({0}) ORDER BY AccountNumber DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn30.Visible = True
            GridColumn30.VisibleIndex = 12
        End If
        GridView1.Columns("Payee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Payee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn3.Width = 254 - 17
        Else
            GridColumn3.Width = 254
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GetAccountNumber()
        If btnSave.Text = "&Save" Then
            txtAccountNumber.Text = DataObject(String.Format("SELECT CONCAT('LOE-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM liquidation_main WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDate.Value, "yy"), Format(dtpDate.Value, "yyyy-MM-dd")))
        End If
    End Sub

#Region "Keydown"
    Private Sub CbxPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDate.Focus()
        End If
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAddPerson.Focus()
        End If
    End Sub

    Private Sub CbxPreparedBy_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPreparedBy.KeyDown
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
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        LoadPayee("")
        btnSave.Text = "&Save"
        PanelEx10.Enabled = True
        cbxPayee.Enabled = True
        dtpDate.Value = Date.Now
        dtpDate.Enabled = True
        cbxPayee.Text = ""
        txtPurpose.Text = ""
        cbxPreparedBy.SelectedValue = Empl_ID
        txtApprovedBy.Text = ""
        txtCheckedBy.Text = ""
        dTotalExpense.Value = 0
        dAmountReceived.Value = 0
        txtCheckNumber.Text = ""
        txtCVNumber.Text = ""
        dRefundable.Value = 0
        btnRemovePerson.Enabled = False
        DT_Particular = DataSource(String.Format("SELECT 0 AS 'ID', '' AS 'Particulars', 0.00 AS 'Amount 1', 0.00 AS 'Amount 2', 0.00 AS 'Amount 3', 0.00 AS 'Amount 4', 0.00 AS 'Amount 5', 0.00 AS 'Amount 6', 0.00 AS 'Amount 7', 0.00 AS 'Amount 8', 0.00 AS 'Amount 9', 0.00 AS 'Amount 10', 0.00 AS 'Amount' LIMIT 1"))
        GridControl2.DataSource = DT_Particular
        GridColumn9.Width = 985
        GridColumn34.Visible = False
        GridColumn35.Visible = False
        GridColumn25.Visible = False
        GridColumn26.Visible = False
        GridColumn27.Visible = False
        GridColumn28.Visible = False
        GridColumn29.Visible = False
        GridColumn31.Visible = False
        GridColumn32.Visible = False
        For x As Integer = 0 To GridView2.RowCount - 1
            GridView2.SetRowCellValue(x, "Amount 2", 0)
            GridView2.SetRowCellValue(x, "Amount", 0)
        Next
        GridColumn33.Visible = False
        For x As Integer = 0 To GridView2.RowCount - 1
            GridView2.SetRowCellValue(x, "Amount 1", 0)
            GridView2.SetRowCellValue(x, "Amount", 0)
        Next
        GridColumn10.Caption = "Amount"
        GridColumn10.OptionsColumn.AllowEdit = True

        Persons = 1
        User_EmplID = 0

        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnCheck.Visible = False
        btnApprove.Visible = False
        btnDisapprove.Visible = False
        btnPrint.Location = New Point(909, 4)
        btnEmailCrecom.Visible = False
        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxPayee.Text = "" Then
            MsgBox("Please select/fill Payee.", MsgBoxStyle.Information, "Info")
            cbxPayee.DroppedDown = True
            Exit Sub
        End If
        If dtpDate.CustomFormat = "" Or Format(dtpDate.Value, "yyyy-MM-dd") = "0001-01-01" Then
            MsgBox("Please fill Document Date.", MsgBoxStyle.Information, "Info")
            dtpDate.Focus()
            Exit Sub
        End If
        If GridView2.RowCount = 0 Or dTotalExpense.Value = 0 Then
            MsgBox("Please add some liquidation.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxPreparedBy.Text = "" Or cbxPreparedBy.SelectedIndex = -1 Then
            MsgBox("Please select Prepared By.", MsgBoxStyle.Information, "Info")
            cbxPreparedBy.DroppedDown = True
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                GetAccountNumber()
                Code = GenerateOTAC()
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    If drv("Head") = 1 Then
                    Else
                        'SEND EMAIL AND SMS APPROVAL TO DEPARTMENT HEAD  *******************************************************************
                        If drv("Head") = 0 Then
                            If Branch_ID = 0 Then
                                Dim DT_Head As DataTable = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = '{0}' AND Branch_ID = '{1}' AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", drv("department_id"), Branch_ID))
                                For x As Integer = 0 To DT_Head.Rows.Count - 1
                                    Dim Msg As String = String.Format("Good day," & vbCrLf, DT_Head(x)("Employee"))
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head checking of Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If DT_Head(x)("Phone") = "" Then
                                    Else
                                        SendSMS(DT_Head(x)("Phone"), Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If DT_Head(x)("EmailAdd") = "" Then
                                    Else
                                        Dim Subject As String = "One Time Authorization Code " & Code
                                        AttachmentFiles = New ArrayList()
                                        Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                        Generate_Receipt(False, FName)
                                        AttachmentFiles.Add(FName)
                                        SendEmail(DT_Head(x)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                                    End If
                                Next
                            Else
                                Dim BM As DataTable = GetBM(Branch_ID)
                                For x As Integer = 0 To BM.Rows.Count - 1
                                    Dim Msg As String = String.Format("Good day," & vbCrLf, BM(x)("Employee"))
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head checking of Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If BM(x)("Phone") = "" Then
                                    Else
                                        SendSMS(BM(x)("Phone"), Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If BM(x)("EmailAdd") = "" Then
                                    Else
                                        Dim Subject As String = "One Time Authorization Code " & Code
                                        AttachmentFiles = New ArrayList()
                                        Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                        Generate_Receipt(False, FName)
                                        AttachmentFiles.Add(FName)
                                        SendEmail(BM(x)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                                    End If
                                Next
                            End If
                        Else
                            Dim Msg As String
                            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                                If DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                                    Msg = String.Format("Good day," & vbCrLf, DT_Signatory(x)("Employee"))
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Approval of Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If DT_Signatory(x)("Phone") = "" Then
                                    Else
                                        SendSMS(DT_Signatory(x)("Phone"), Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If DT_Signatory(x)("EmailAdd") = "" Then
                                    Else
                                        Dim Subject As String = "One Time Authorization Code " & Code
                                        AttachmentFiles = New ArrayList()
                                        Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                        Generate_Receipt(False, FName)
                                        AttachmentFiles.Add(FName)
                                        SendEmail(DT_Signatory(x)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                                    End If
                                End If
                            Next
                        End If
                    End If
                    Dim DT_CashAdvanceApprover As DataTable = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE ID = '{0}' AND `status` = 'ACTIVE';", drv("ApprovedID")))
                    If DT_CashAdvanceApprover.Rows.Count > 0 Then
                        Dim Msg As String = String.Format("Good day {0}," & vbCrLf, DT_CashAdvanceApprover(0)("Employee"))
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Checking of Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If DT_CashAdvanceApprover(0)("Phone") = "" Then
                        Else
                            SendSMS(DT_CashAdvanceApprover(0)("Phone"), Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If DT_CashAdvanceApprover(0)("EmailAdd") = "" Then
                        Else
                            Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                            AttachmentFiles = New ArrayList()
                            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            Generate_Receipt(False, FName)
                            AttachmentFiles.Add(FName)
                            SendEmail(DT_CashAdvanceApprover(0)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                        End If
                    End If
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                'INSERT MAIN
                Dim SQL As String = "INSERT INTO liquidation_main SET"
                SQL &= String.Format(" Payee_ID = '{0}', ", cbxPayee.SelectedValue)
                SQL &= String.Format(" Payee = '{0}', ", cbxPayee.Text)
                SQL &= String.Format(" Trans_Date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" AccountNumber = '{0}', ", txtAccountNumber.Text)
                SQL &= String.Format(" CANumber = '{0}', ", drv("AccountNumber"))
                SQL &= String.Format(" TotalExpenses = '{0}', ", dTotalExpense.Value)
                SQL &= String.Format(" AmountDue = '{0}', ", dRefundable.Value)
                SQL &= String.Format(" Persons = '{0}', ", Persons)
                SQL &= String.Format(" Caption1 = '{0}', ", GridColumn33.Caption.ToString)
                SQL &= String.Format(" Caption2 = '{0}', ", GridColumn32.Caption.ToString)
                SQL &= String.Format(" Caption3 = '{0}', ", GridColumn31.Caption.ToString)
                SQL &= String.Format(" Caption4 = '{0}', ", GridColumn29.Caption.ToString)
                SQL &= String.Format(" Caption5 = '{0}', ", GridColumn28.Caption.ToString)
                SQL &= String.Format(" Caption6 = '{0}', ", GridColumn27.Caption.ToString)
                SQL &= String.Format(" Caption7 = '{0}', ", GridColumn26.Caption.ToString)
                SQL &= String.Format(" Caption8 = '{0}', ", GridColumn25.Caption.ToString)
                SQL &= String.Format(" Caption9 = '{0}', ", GridColumn35.Caption.ToString)
                SQL &= String.Format(" Caption10 = '{0}', ", GridColumn34.Caption.ToString)
                SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                If drv("Head") = 1 Then
                    SQL &= String.Format(" CheckedID = '{0}', ", Empl_ID)
                    SQL &= String.Format(" Check_OTAC = '{0}', ", Code)
                    SQL &= String.Format(" Approve_OTAC = '{0}', ", Code)
                Else
                    SQL &= String.Format(" Check_OTAC = '{0}', ", Code)
                End If
                SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                SQL &= String.Format(" Branch_ID = '{0}';", Branch_ID)
                DataObject(SQL)
                SQL = ""
                ID = DataObject(String.Format("SELECT MAX(ID) FROM liquidation_main WHERE AccountNumber = '{0}';", txtAccountNumber.Text))
                'INSERT DETAILS
                For x As Integer = 0 To GridView2.RowCount - 1
                    SQL &= "INSERT INTO liquidation_details SET"
                    SQL &= String.Format(" LiqMain = '{0}', ", ID)
                    SQL &= String.Format(" LiqNumber = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" Particulars = '{0}', ", GridView2.GetRowCellValue(x, "Particulars").ToString.InsertQuote)
                    SQL &= String.Format(" Amount1 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 1")))
                    SQL &= String.Format(" Amount2 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 2")))
                    SQL &= String.Format(" Amount3 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 3")))
                    SQL &= String.Format(" Amount4 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 4")))
                    SQL &= String.Format(" Amount5 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 5")))
                    SQL &= String.Format(" Amount6 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 6")))
                    SQL &= String.Format(" Amount7 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 7")))
                    SQL &= String.Format(" Amount8 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 8")))
                    SQL &= String.Format(" Amount9 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 9")))
                    SQL &= String.Format(" Amount10 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 10")))
                    SQL &= String.Format(" Total = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                Next

                'UPDATE CASH ADVANCE
                SQL &= String.Format("UPDATE cash_advance SET Liquidated = 'Y' WHERE AccountNumber = '{0}';", drv("AccountNumber"))
                DataObject(SQL)

                Logs("Liquidation of Expenses", "Save", String.Format("Add new Liquidation of Expenses of {0} with total expense {1}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotalExpense.Text), "", "", "", "")
                If From_CAS Then
                    btnSave.DialogResult = DialogResult.OK
                    btnSave.PerformClick()
                End If
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!" & mEmail, MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM liquidation_main WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
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
                    If txtCheckedBy.Text = "" Then
                        Dim DT_CashAdvanceApprover As DataTable = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE ID = '{0}' AND `status` = 'ACTIVE';", drv("ApprovedID")))
                        If DT_CashAdvanceApprover.Rows.Count > 0 Then
                            Dim Msg As String = String.Format("Good day {0}," & vbCrLf, DT_CashAdvanceApprover(0)("Employee"))
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Checking of Updated Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_CashAdvanceApprover(0)("Phone") = "" Then
                            Else
                                SendSMS(DT_CashAdvanceApprover(0)("Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_CashAdvanceApprover(0)("EmailAdd") = "" Then
                            Else
                                Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "] [UPDATE]"
                                AttachmentFiles = New ArrayList()
                                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                Generate_Receipt(False, FName)
                                AttachmentFiles.Add(FName)
                                SendEmail(DT_CashAdvanceApprover(0)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                            End If
                        End If
                    ElseIf txtApprovedBy.Text = "" Then
                        Dim DT_CashAdvanceApprover As DataTable = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE ID = '{0}' AND `status` = 'ACTIVE';", drv("ApprovedID")))
                        If DT_CashAdvanceApprover.Rows.Count > 0 Then
                            Dim Msg As String = String.Format("Good day {0}," & vbCrLf, DT_CashAdvanceApprover(0)("Employee"))
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Approval of Updated Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_CashAdvanceApprover(0)("Phone") = "" Then
                            Else
                                SendSMS(DT_CashAdvanceApprover(0)("Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_CashAdvanceApprover(0)("EmailAdd") = "" Then
                            Else
                                Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "] [UPDATE]"
                                AttachmentFiles = New ArrayList()
                                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                Generate_Receipt(False, FName)
                                AttachmentFiles.Add(FName)
                                SendEmail(DT_CashAdvanceApprover(0)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                            End If
                        End If
                    End If
                End If

                'INSERT MAIN
                Dim SQL As String = "UPDATE liquidation_main SET"
                SQL &= String.Format(" TotalExpenses = '{0}', ", dTotalExpense.Value)
                SQL &= String.Format(" AmountDue = '{0}', ", dRefundable.Value)
                SQL &= String.Format(" Persons = '{0}', ", Persons)
                SQL &= String.Format(" Caption1 = '{0}', ", GridColumn33.Caption.ToString)
                SQL &= String.Format(" Caption2 = '{0}', ", GridColumn32.Caption.ToString)
                SQL &= String.Format(" Caption3 = '{0}', ", GridColumn31.Caption.ToString)
                SQL &= String.Format(" Caption4 = '{0}', ", GridColumn29.Caption.ToString)
                SQL &= String.Format(" Caption5 = '{0}', ", GridColumn28.Caption.ToString)
                SQL &= String.Format(" Caption6 = '{0}', ", GridColumn27.Caption.ToString)
                SQL &= String.Format(" Caption7 = '{0}', ", GridColumn26.Caption.ToString)
                SQL &= String.Format(" Caption8 = '{0}', ", GridColumn25.Caption.ToString)
                SQL &= String.Format(" Caption9 = '{0}', ", GridColumn35.Caption.ToString)
                If txtCheckedBy.Text = "" Then
                    SQL &= String.Format(" Check_OTAC = '{0}', ", Code)
                ElseIf txtApprovedBy.Text = "" Then
                    SQL &= String.Format(" Approve_OTAC = '{0}', ", Code)
                End If
                SQL &= String.Format(" Caption10 = '{0}'", GridColumn34.Caption.ToString)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)

                'UPDATE DETAILS
                SQL &= String.Format("UPDATE liquidation_details SET `status` = 'CANCELLED' WHERE LiqMain = '{0}';", ID)
                'INSERT DETAILS
                For x As Integer = 0 To GridView2.RowCount - 1
                    SQL &= "INSERT INTO liquidation_details SET"
                    SQL &= String.Format(" LiqMain = '{0}', ", ID)
                    SQL &= String.Format(" LiqNumber = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" Particulars = '{0}', ", GridView2.GetRowCellValue(x, "Particulars").ToString.InsertQuote)
                    SQL &= String.Format(" Amount1 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 1")))
                    SQL &= String.Format(" Amount2 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 2")))
                    SQL &= String.Format(" Amount3 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 3")))
                    SQL &= String.Format(" Amount4 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 4")))
                    SQL &= String.Format(" Amount5 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 5")))
                    SQL &= String.Format(" Amount6 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 6")))
                    SQL &= String.Format(" Amount7 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 7")))
                    SQL &= String.Format(" Amount8 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 8")))
                    SQL &= String.Format(" Amount9 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 9")))
                    SQL &= String.Format(" Amount10 = '{0}', ", CDbl(GridView2.GetRowCellValue(x, "Amount 10")))
                    SQL &= String.Format(" Total = '{0}';", CDbl(GridView2.GetRowCellValue(x, "Amount")))
                Next
                DataObject(SQL)
                Logs("Liquidation of Expenses", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If dTotalExpense.Text = dTotalExpense.Tag Then
            Else
                Change &= String.Format("Change Total Expense from {0} to {1}. ", dTotalExpense.Tag, dTotalExpense.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Liquidation - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE liquidation_main SET `status` = 'CANCELLED' WHERE ID = '{0}';UPDATE cash_advance SET Liquidated = 'N' WHERE AccountNumber = '{1}';", ID, drv("AccountNumber")))
            If txtApprovedBy.Text <> "" Then
                If dRefundable.Value > 0 And dRefundable.Value < 1000 Then
                    DataObject(String.Format("UPDATE petty_cash SET `status` = 'CANCELLED' WHERE CANumber = '{0}' AND Particular_1 LIKE '%{1}%';", drv("AccountNumber"), txtAccountNumber.Text))
                End If
            End If
            Logs("Liquidation of Expenses", "Cancel", Reason, String.Format("Cancel Liquidation of Expenses of {0} with total expense of {1}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotalExpense.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Generate_Receipt(Show As Boolean, FName As String)
        Dim Report As New RptLiquidation
        With Report
            .Name = String.Format("Liquidation of Expenses of {0} - {1}", cbxPayee.Text, txtAccountNumber.Text)

            .lblPayee.Text = cbxPayee.Text
            .lblDate.Text = dtpDate.Text
            .lblAccountNumber.Text = txtAccountNumber.Text
            .lblPurpose.Text = txtPurpose.Text
            .lblCaption1.Text = GridColumn33.Caption.ToString
            .lblCaption2.Text = GridColumn32.Caption.ToString
            .lblCaption3.Text = GridColumn31.Caption.ToString
            .lblCaption4.Text = GridColumn29.Caption.ToString
            .lblCaption5.Text = GridColumn28.Caption.ToString
            .lblCaption6.Text = GridColumn27.Caption.ToString
            .lblCaption7.Text = GridColumn26.Caption.ToString
            .lblCaption8.Text = GridColumn25.Caption.ToString
            .lblCaption9.Text = GridColumn35.Caption.ToString
            .lblCaption10.Text = GridColumn34.Caption.ToString
            .lblCaptionT.Text = GridColumn10.Caption.ToString

            .DataSource = GridControl2.DataSource
            .lblParticulars.DataBindings.Add("Text", GridControl2.DataSource, "Particulars")
            .lblAmount1.DataBindings.Add("Text", GridControl2.DataSource, "Amount 1")
            .lblAmount2.DataBindings.Add("Text", GridControl2.DataSource, "Amount 2")
            .lblAmount3.DataBindings.Add("Text", GridControl2.DataSource, "Amount 3")
            .lblAmount4.DataBindings.Add("Text", GridControl2.DataSource, "Amount 4")
            .lblAmount5.DataBindings.Add("Text", GridControl2.DataSource, "Amount 5")
            .lblAmount6.DataBindings.Add("Text", GridControl2.DataSource, "Amount 6")
            .lblAmount7.DataBindings.Add("Text", GridControl2.DataSource, "Amount 7")
            .lblAmount8.DataBindings.Add("Text", GridControl2.DataSource, "Amount 8")
            .lblAmount9.DataBindings.Add("Text", GridControl2.DataSource, "Amount 9")
            .lblAmount10.DataBindings.Add("Text", GridControl2.DataSource, "Amount 10")
            .lblAmountT.DataBindings.Add("Text", GridControl2.DataSource, "Amount")

            .lblCaption_Particular.SizeF = New Size(140 + (60 * (10 - Persons)), 25)
            .lblParticulars.SizeF = New Size(140 + (60 * (10 - Persons)), 20)
            If Persons = 1 Then
                .lblCaptionT.SizeF = New Size(120, 25)
                .lblAmountT.SizeF = New Size(120, 20)

                .lblCaptionT.LocationF = New Point(680, 75)
                .lblAmountT.LocationF = New Point(680, 0)
            Else
                .lblCaptionT.SizeF = New Size(60, 25)
                .lblAmountT.SizeF = New Size(60, 20)

                .lblCaptionT.LocationF = New Point(740, 75)
                .lblAmountT.LocationF = New Point(740, 0)
                If Persons = 2 Then
                    .lblCaption1.Visible = True
                    .lblAmount1.Visible = True
                    .lblCaption1.LocationF = New Point(140 + 480, 75)
                    .lblAmount1.LocationF = New Point(140 + 480, 0)

                    .lblCaption2.Visible = True
                    .lblAmount2.Visible = True
                    .lblCaption2.LocationF = New Point(140 + 540, 75)
                    .lblAmount2.LocationF = New Point(140 + 540, 0)
                ElseIf Persons = 3 Then
                    .lblCaption1.Visible = True
                    .lblAmount1.Visible = True
                    .lblCaption1.LocationF = New Point(140 + 420, 75)
                    .lblAmount1.LocationF = New Point(140 + 420, 0)

                    .lblCaption2.Visible = True
                    .lblAmount2.Visible = True
                    .lblCaption2.LocationF = New Point(140 + 480, 75)
                    .lblAmount2.LocationF = New Point(140 + 480, 0)

                    .lblCaption3.Visible = True
                    .lblAmount3.Visible = True
                    .lblCaption3.LocationF = New Point(140 + 540, 75)
                    .lblAmount3.LocationF = New Point(140 + 540, 0)
                ElseIf Persons = 4 Then
                    .lblCaption1.Visible = True
                    .lblAmount1.Visible = True
                    .lblCaption1.LocationF = New Point(140 + 360, 75)
                    .lblAmount1.LocationF = New Point(140 + 360, 0)

                    .lblCaption2.Visible = True
                    .lblAmount2.Visible = True
                    .lblCaption2.LocationF = New Point(140 + 420, 75)
                    .lblAmount2.LocationF = New Point(140 + 420, 0)

                    .lblCaption3.Visible = True
                    .lblAmount3.Visible = True
                    .lblCaption3.LocationF = New Point(140 + 480, 75)
                    .lblAmount3.LocationF = New Point(140 + 480, 0)

                    .lblCaption4.Visible = True
                    .lblAmount4.Visible = True
                    .lblCaption4.LocationF = New Point(140 + 540, 75)
                    .lblAmount4.LocationF = New Point(140 + 540, 0)
                ElseIf Persons = 5 Then
                    .lblCaption1.Visible = True
                    .lblAmount1.Visible = True
                    .lblCaption1.LocationF = New Point(140 + 300, 75)
                    .lblAmount1.LocationF = New Point(140 + 300, 0)

                    .lblCaption2.Visible = True
                    .lblAmount2.Visible = True
                    .lblCaption2.LocationF = New Point(140 + 360, 75)
                    .lblAmount2.LocationF = New Point(140 + 360, 0)

                    .lblCaption3.Visible = True
                    .lblAmount3.Visible = True
                    .lblCaption3.LocationF = New Point(140 + 420, 75)
                    .lblAmount3.LocationF = New Point(140 + 420, 0)

                    .lblCaption4.Visible = True
                    .lblAmount4.Visible = True
                    .lblCaption4.LocationF = New Point(140 + 480, 75)
                    .lblAmount4.LocationF = New Point(140 + 480, 0)

                    .lblCaption5.Visible = True
                    .lblAmount5.Visible = True
                    .lblCaption5.LocationF = New Point(140 + 540, 75)
                    .lblAmount5.LocationF = New Point(140 + 540, 0)
                ElseIf Persons = 6 Then
                    .lblCaption1.Visible = True
                    .lblAmount1.Visible = True
                    .lblCaption1.LocationF = New Point(140 + 240, 75)
                    .lblAmount1.LocationF = New Point(140 + 240, 0)

                    .lblCaption2.Visible = True
                    .lblAmount2.Visible = True
                    .lblCaption2.LocationF = New Point(140 + 300, 75)
                    .lblAmount2.LocationF = New Point(140 + 300, 0)

                    .lblCaption3.Visible = True
                    .lblAmount3.Visible = True
                    .lblCaption3.LocationF = New Point(140 + 360, 75)
                    .lblAmount3.LocationF = New Point(140 + 360, 0)

                    .lblCaption4.Visible = True
                    .lblAmount4.Visible = True
                    .lblCaption4.LocationF = New Point(140 + 420, 75)
                    .lblAmount4.LocationF = New Point(140 + 420, 0)

                    .lblCaption5.Visible = True
                    .lblAmount5.Visible = True
                    .lblCaption5.LocationF = New Point(140 + 480, 75)
                    .lblAmount5.LocationF = New Point(140 + 480, 0)

                    .lblCaption6.Visible = True
                    .lblAmount6.Visible = True
                    .lblCaption6.LocationF = New Point(140 + 540, 75)
                    .lblAmount6.LocationF = New Point(140 + 540, 0)
                ElseIf Persons = 7 Then
                    .lblCaption1.Visible = True
                    .lblAmount1.Visible = True
                    .lblCaption1.LocationF = New Point(140 + 180, 75)
                    .lblAmount1.LocationF = New Point(140 + 180, 0)

                    .lblCaption2.Visible = True
                    .lblAmount2.Visible = True
                    .lblCaption2.LocationF = New Point(140 + 240, 75)
                    .lblAmount2.LocationF = New Point(140 + 240, 0)

                    .lblCaption3.Visible = True
                    .lblAmount3.Visible = True
                    .lblCaption3.LocationF = New Point(140 + 300, 75)
                    .lblAmount3.LocationF = New Point(140 + 300, 0)

                    .lblCaption4.Visible = True
                    .lblAmount4.Visible = True
                    .lblCaption4.LocationF = New Point(140 + 360, 75)
                    .lblAmount4.LocationF = New Point(140 + 360, 0)

                    .lblCaption5.Visible = True
                    .lblAmount5.Visible = True
                    .lblCaption5.LocationF = New Point(140 + 420, 75)
                    .lblAmount5.LocationF = New Point(140 + 420, 0)

                    .lblCaption6.Visible = True
                    .lblAmount6.Visible = True
                    .lblCaption6.LocationF = New Point(140 + 480, 75)
                    .lblAmount6.LocationF = New Point(140 + 480, 0)

                    .lblCaption7.Visible = True
                    .lblAmount7.Visible = True
                    .lblCaption7.LocationF = New Point(140 + 540, 75)
                    .lblAmount7.LocationF = New Point(140 + 540, 0)
                ElseIf Persons = 8 Then
                    .lblCaption1.Visible = True
                    .lblAmount1.Visible = True
                    .lblCaption1.LocationF = New Point(140 + 120, 75)
                    .lblAmount1.LocationF = New Point(140 + 120, 0)

                    .lblCaption2.Visible = True
                    .lblAmount2.Visible = True
                    .lblCaption2.LocationF = New Point(140 + 180, 75)
                    .lblAmount2.LocationF = New Point(140 + 180, 0)

                    .lblCaption3.Visible = True
                    .lblAmount3.Visible = True
                    .lblCaption3.LocationF = New Point(140 + 240, 75)
                    .lblAmount3.LocationF = New Point(140 + 240, 0)

                    .lblCaption4.Visible = True
                    .lblAmount4.Visible = True
                    .lblCaption4.LocationF = New Point(140 + 300, 75)
                    .lblAmount4.LocationF = New Point(140 + 300, 0)

                    .lblCaption5.Visible = True
                    .lblAmount5.Visible = True
                    .lblCaption5.LocationF = New Point(140 + 360, 75)
                    .lblAmount5.LocationF = New Point(140 + 360, 0)

                    .lblCaption6.Visible = True
                    .lblAmount6.Visible = True
                    .lblCaption6.LocationF = New Point(140 + 420, 75)
                    .lblAmount6.LocationF = New Point(140 + 420, 0)

                    .lblCaption7.Visible = True
                    .lblAmount7.Visible = True
                    .lblCaption7.LocationF = New Point(140 + 480, 75)
                    .lblAmount7.LocationF = New Point(140 + 480, 0)

                    .lblCaption8.Visible = True
                    .lblAmount8.Visible = True
                    .lblCaption8.LocationF = New Point(140 + 540, 75)
                    .lblAmount8.LocationF = New Point(140 + 540, 0)
                ElseIf Persons = 9 Then
                    .lblCaption1.Visible = True
                    .lblAmount1.Visible = True
                    .lblCaption1.LocationF = New Point(140 + 60, 75)
                    .lblAmount1.LocationF = New Point(140 + 60, 0)

                    .lblCaption2.Visible = True
                    .lblAmount2.Visible = True
                    .lblCaption2.LocationF = New Point(140 + 120, 75)
                    .lblAmount2.LocationF = New Point(140 + 120, 0)

                    .lblCaption3.Visible = True
                    .lblAmount3.Visible = True
                    .lblCaption3.LocationF = New Point(140 + 180, 75)
                    .lblAmount3.LocationF = New Point(140 + 180, 0)

                    .lblCaption4.Visible = True
                    .lblAmount4.Visible = True
                    .lblCaption4.LocationF = New Point(140 + 240, 75)
                    .lblAmount4.LocationF = New Point(140 + 240, 0)

                    .lblCaption5.Visible = True
                    .lblAmount5.Visible = True
                    .lblCaption5.LocationF = New Point(140 + 300, 75)
                    .lblAmount5.LocationF = New Point(140 + 300, 0)

                    .lblCaption6.Visible = True
                    .lblAmount6.Visible = True
                    .lblCaption6.LocationF = New Point(140 + 360, 75)
                    .lblAmount6.LocationF = New Point(140 + 360, 0)

                    .lblCaption7.Visible = True
                    .lblAmount7.Visible = True
                    .lblCaption7.LocationF = New Point(140 + 420, 75)
                    .lblAmount7.LocationF = New Point(140 + 420, 0)

                    .lblCaption8.Visible = True
                    .lblAmount8.Visible = True
                    .lblCaption8.LocationF = New Point(140 + 480, 75)
                    .lblAmount8.LocationF = New Point(140 + 480, 0)

                    .lblCaption9.Visible = True
                    .lblAmount9.Visible = True
                    .lblCaption9.LocationF = New Point(140 + 540, 75)
                    .lblAmount9.LocationF = New Point(140 + 540, 0)
                ElseIf Persons = 10 Then
                    .lblCaption1.Visible = True
                    .lblAmount1.Visible = True
                    .lblCaption1.LocationF = New Point(140, 75)
                    .lblAmount1.LocationF = New Point(140, 0)

                    .lblCaption2.Visible = True
                    .lblAmount2.Visible = True
                    .lblCaption2.LocationF = New Point(140 + 60, 75)
                    .lblAmount2.LocationF = New Point(140 + 60, 0)

                    .lblCaption3.Visible = True
                    .lblAmount3.Visible = True
                    .lblCaption3.LocationF = New Point(140 + 120, 75)
                    .lblAmount3.LocationF = New Point(140 + 120, 0)

                    .lblCaption4.Visible = True
                    .lblAmount4.Visible = True
                    .lblCaption4.LocationF = New Point(140 + 180, 75)
                    .lblAmount4.LocationF = New Point(140 + 180, 0)

                    .lblCaption5.Visible = True
                    .lblAmount5.Visible = True
                    .lblCaption5.LocationF = New Point(140 + 240, 75)
                    .lblAmount5.LocationF = New Point(140 + 240, 0)

                    .lblCaption6.Visible = True
                    .lblAmount6.Visible = True
                    .lblCaption6.LocationF = New Point(140 + 300, 75)
                    .lblAmount6.LocationF = New Point(140 + 300, 0)

                    .lblCaption7.Visible = True
                    .lblAmount7.Visible = True
                    .lblCaption7.LocationF = New Point(140 + 360, 75)
                    .lblAmount7.LocationF = New Point(140 + 360, 0)

                    .lblCaption8.Visible = True
                    .lblAmount8.Visible = True
                    .lblCaption8.LocationF = New Point(140 + 420, 75)
                    .lblAmount8.LocationF = New Point(140 + 420, 0)

                    .lblCaption9.Visible = True
                    .lblAmount9.Visible = True
                    .lblCaption9.LocationF = New Point(140 + 480, 75)
                    .lblAmount9.LocationF = New Point(140 + 480, 0)

                    .lblCaption10.Visible = True
                    .lblAmount10.Visible = True
                    .lblCaption10.LocationF = New Point(140 + 540, 75)
                    .lblAmount10.LocationF = New Point(140 + 540, 0)
                End If
            End If

            .lblTotalExpense.Text = dTotalExpense.Text
            .lblAmountReceived.Text = dAmountReceived.Text
            .lblCheckNumber.Text = txtCheckNumber.Text
            .lblCVNumber.Text = txtCVNumber.Text
            .lblAmountDue.Text = dRefundable.Text

            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblCheckedBy.Text = txtCheckedBy.Text
            .lblApprovedBy.Text = txtApprovedBy.Text

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
            Generate_Receipt(True, "")
            Logs("Liquidation", "Print", "[SENSITIVE] Print Liquidation " & txtAccountNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("LIQUIDATION OF EXPENSES LIST", GridControl1)
            Logs("Liquidation", "Print", "[SENSITIVE] Print Liquidation List", "", "", "", "")
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or If(From_CAS, e.KeyCode = Keys.Escape, 0) Then
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
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            cbxPayee.Enabled = False
            dtpDate.Enabled = False
            LoadPayee(.GetFocusedRowCellValue("CA Number"))
            cbxPayee.Text = .GetFocusedRowCellValue("Payee")
            cbxPayee.Tag = .GetFocusedRowCellValue("Payee")
            dtpDate.Value = .GetFocusedRowCellValue("Date")
            dtpDate.Tag = .GetFocusedRowCellValue("Date")
            txtAccountNumber.Text = .GetFocusedRowCellValue("Account Number")
            dTotalExpense.Value = .GetFocusedRowCellValue("Total Expenses")
            dAmountReceived.Value = .GetFocusedRowCellValue("Amount Received")
            txtCheckNumber.Text = .GetFocusedRowCellValue("Check Number")
            txtCVNumber.Text = .GetFocusedRowCellValue("CV Number")
            dRefundable.Value = .GetFocusedRowCellValue("Amount Due")
            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            txtCheckedBy.Text = .GetFocusedRowCellValue("Checked By")
            txtApprovedBy.Text = .GetFocusedRowCellValue("Approved By")
            User_EmplID = .GetFocusedRowCellValue("User_EmplID")
            txtPurpose.Text = .GetFocusedRowCellValue("Purpose")
            GridColumn33.Caption = .GetFocusedRowCellValue("Caption1")
            GridColumn32.Caption = .GetFocusedRowCellValue("Caption2")
            GridColumn31.Caption = .GetFocusedRowCellValue("Caption3")
            GridColumn29.Caption = .GetFocusedRowCellValue("Caption4")
            GridColumn28.Caption = .GetFocusedRowCellValue("Caption5")
            GridColumn27.Caption = .GetFocusedRowCellValue("Caption6")
            GridColumn26.Caption = .GetFocusedRowCellValue("Caption7")
            GridColumn25.Caption = .GetFocusedRowCellValue("Caption8")
            GridColumn35.Caption = .GetFocusedRowCellValue("Caption9")
            GridColumn34.Caption = .GetFocusedRowCellValue("Caption10")
            Persons = .GetFocusedRowCellValue("Persons")
        End With
        If Persons > 1 Then
            GridColumn10.Caption = "Total"
            GridColumn10.OptionsColumn.AllowEdit = False
            btnRemovePerson.Enabled = True

            For x As Integer = 1 To Persons - If(Persons = 1, 1, 0)
                GridColumn9.Width = GridColumn9.Width - 80
            Next
        End If
        If Persons = 2 Then
            GridColumn33.Visible = True
            GridColumn32.Visible = True
            GridColumn33.VisibleIndex = 1
            GridColumn32.VisibleIndex = 2
        ElseIf Persons = 3 Then
            GridColumn33.Visible = True
            GridColumn32.Visible = True
            GridColumn31.Visible = True
            GridColumn33.VisibleIndex = 1
            GridColumn32.VisibleIndex = 2
            GridColumn31.VisibleIndex = 3
        ElseIf Persons = 4 Then
            GridColumn33.Visible = True
            GridColumn32.Visible = True
            GridColumn31.Visible = True
            GridColumn29.Visible = True
            GridColumn33.VisibleIndex = 1
            GridColumn32.VisibleIndex = 2
            GridColumn31.VisibleIndex = 3
            GridColumn29.VisibleIndex = 4
        ElseIf Persons = 5 Then
            GridColumn33.Visible = True
            GridColumn32.Visible = True
            GridColumn31.Visible = True
            GridColumn29.Visible = True
            GridColumn28.Visible = True
            GridColumn33.VisibleIndex = 1
            GridColumn32.VisibleIndex = 2
            GridColumn31.VisibleIndex = 3
            GridColumn29.VisibleIndex = 4
            GridColumn28.VisibleIndex = 5
        ElseIf Persons = 6 Then
            GridColumn33.Visible = True
            GridColumn32.Visible = True
            GridColumn31.Visible = True
            GridColumn29.Visible = True
            GridColumn28.Visible = True
            GridColumn27.Visible = True
            GridColumn33.VisibleIndex = 1
            GridColumn32.VisibleIndex = 2
            GridColumn31.VisibleIndex = 3
            GridColumn29.VisibleIndex = 4
            GridColumn28.VisibleIndex = 5
            GridColumn27.VisibleIndex = 6
        ElseIf Persons = 7 Then
            GridColumn33.Visible = True
            GridColumn32.Visible = True
            GridColumn31.Visible = True
            GridColumn29.Visible = True
            GridColumn28.Visible = True
            GridColumn27.Visible = True
            GridColumn26.Visible = True
            GridColumn33.VisibleIndex = 1
            GridColumn32.VisibleIndex = 2
            GridColumn31.VisibleIndex = 3
            GridColumn29.VisibleIndex = 4
            GridColumn28.VisibleIndex = 5
            GridColumn27.VisibleIndex = 6
            GridColumn26.VisibleIndex = 7
        ElseIf Persons = 8 Then
            GridColumn33.Visible = True
            GridColumn32.Visible = True
            GridColumn31.Visible = True
            GridColumn29.Visible = True
            GridColumn28.Visible = True
            GridColumn27.Visible = True
            GridColumn26.Visible = True
            GridColumn25.Visible = True
            GridColumn33.VisibleIndex = 1
            GridColumn32.VisibleIndex = 2
            GridColumn31.VisibleIndex = 3
            GridColumn29.VisibleIndex = 4
            GridColumn28.VisibleIndex = 5
            GridColumn27.VisibleIndex = 6
            GridColumn26.VisibleIndex = 7
            GridColumn25.VisibleIndex = 8
        ElseIf Persons = 9 Then
            GridColumn33.Visible = True
            GridColumn32.Visible = True
            GridColumn31.Visible = True
            GridColumn29.Visible = True
            GridColumn28.Visible = True
            GridColumn27.Visible = True
            GridColumn26.Visible = True
            GridColumn25.Visible = True
            GridColumn35.Visible = True
            GridColumn33.VisibleIndex = 1
            GridColumn32.VisibleIndex = 2
            GridColumn31.VisibleIndex = 3
            GridColumn29.VisibleIndex = 4
            GridColumn28.VisibleIndex = 5
            GridColumn27.VisibleIndex = 6
            GridColumn26.VisibleIndex = 7
            GridColumn25.VisibleIndex = 8
            GridColumn35.VisibleIndex = 9
        ElseIf Persons = 10 Then
            GridColumn33.Visible = True
            GridColumn32.Visible = True
            GridColumn31.Visible = True
            GridColumn29.Visible = True
            GridColumn28.Visible = True
            GridColumn27.Visible = True
            GridColumn26.Visible = True
            GridColumn25.Visible = True
            GridColumn35.Visible = True
            GridColumn34.Visible = True
            GridColumn34.Visible = True
            GridColumn33.VisibleIndex = 1
            GridColumn32.VisibleIndex = 2
            GridColumn31.VisibleIndex = 3
            GridColumn29.VisibleIndex = 4
            GridColumn28.VisibleIndex = 5
            GridColumn27.VisibleIndex = 6
            GridColumn26.VisibleIndex = 7
            GridColumn25.VisibleIndex = 8
            GridColumn35.VisibleIndex = 9
            GridColumn34.VisibleIndex = 10
            btnAddPerson.Enabled = False
        End If
        DT_Particular = DataSource(String.Format("SELECT ID, Particulars, Amount1 AS 'Amount 1', Amount2 AS 'Amount 2', Amount3 AS 'Amount 3', Amount4 AS 'Amount 4', Amount5 AS 'Amount 5', Amount6 AS 'Amount 6', Amount7 AS 'Amount 7', Amount8 AS 'Amount 8', Amount9 AS 'Amount 9', Amount10 AS 'Amount 10', Total AS 'Amount' FROM liquidation_details WHERE LiqMain = '{0}' AND `status` = 'ACTIVE';", ID))
        GridControl2.DataSource = DT_Particular
        Code_Check = GridView1.GetFocusedRowCellValue("Check_OTAC")
        Code_Approve = GridView1.GetFocusedRowCellValue("Approve_OTAC")

        SuperTabControl1.SelectedTab = tabSetup
        Dept_Head = DataObject(String.Format("SELECT (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) FROM employee_setup WHERE ID = '{0}' AND Branch_ID = '{1}' AND IF(Department_ID = 0,TRUE,Department_ID = '{2}');", Empl_ID, GridView1.GetFocusedRowCellValue("Branch_ID"), Dept_ID))
        CA_Approver = DataObject(String.Format("SELECT ApprovedID FROM cash_advance WHERE AccountNumber = '{0}';", GridView1.GetFocusedRowCellValue("CA Number")))

        If GridView1.GetFocusedRowCellValue("Liq_Status") = "PENDING" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "FOR CHECKING" Then
            If User_Type = "ADMIN" Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Or Empl_ID = CA_Approver Then
                btnCheck.Visible = True
                btnDisapprove.Visible = True
                If Empl_ID = CA_Approver Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Or Empl_ID = GridView1.GetFocusedRowCellValue("Payee_ID") Then
                    btnModify.Enabled = True
                End If
            End If
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnCheck.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    btnCheck.Visible = True
                    btnModify.Enabled = True
                    Exit For
                End If
            Next
            Code = GridView1.GetFocusedRowCellValue("Check_OTAC")
        ElseIf GridView1.GetFocusedRowCellValue("Liq_Status") = "CHECKED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "FOR APPROVAL" Then
            If User_Type = "ADMIN" Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = GridView1.GetFocusedRowCellValue("PreparedID") Or Empl_ID = CA_Approver Then
                btnApprove.Visible = True
                btnDisapprove.Visible = True
                If Empl_ID = CA_Approver Then
                    btnModify.Enabled = True
                End If
                btnPrint.Location = New Point(231, 4)
                btnPrint.BringToFront()
                btnEmailCrecom.Visible = True
            End If
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnApprove.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    btnApprove.Visible = True
                    btnModify.Enabled = True
                    Exit For
                End If
            Next
            Code = GridView1.GetFocusedRowCellValue("Approve_OTAC")
        ElseIf GridView1.GetFocusedRowCellValue("Liq_Status") = "APPROVED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "FOR PETTY CASH RELEASE" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "FOR CHECK VOUCHER" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "FOR ACKNOWLEDGEMENT RECEIPT" Then
            btnCheck.Visible = False
            btnApprove.Visible = False
            btnModify.Enabled = False
            If (GridView1.GetFocusedRowCellValue("Refund") = 0 And (GridView1.GetFocusedRowCellValue("ApprovedID") = Empl_ID Or User_Type = "ADMIN")) Then
                btnDelete.Enabled = True
            End If
        End If
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Liq_Status"))
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Then
                e.Appearance.ForeColor = Color.Red
            End If
        End If
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

    Private Sub BtnAddPerson_Click(sender As Object, e As EventArgs) Handles btnAddPerson.Click
        Dim Caption As New FrmLiquidationCaption
        GridColumn9.Width = 985
        For x As Integer = 1 To Persons - If(Persons = 1, 1, 0)
            GridColumn9.Width = GridColumn9.Width - 80
        Next

        If Persons = 1 Then
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Visible = True
                GridColumn9.Width = GridColumn9.Width - 80
                GridColumn33.Caption = Caption.txtCaption.Text
                GridColumn33.VisibleIndex = 1

                Caption.txtCaption.Text = ""
                If Caption.ShowDialog = DialogResult.OK Then
                    GridColumn32.Visible = True
                    GridColumn9.Width = GridColumn9.Width - 80
                    GridColumn32.Caption = Caption.txtCaption.Text
                    GridColumn33.VisibleIndex = 1
                    GridColumn32.VisibleIndex = 2
                Else
                    GridColumn33.Visible = False
                    GridColumn9.Width = 985
                    GridColumn33.Caption = "Amount 1"
                    Exit Sub
                End If
                Persons += 1
                GridColumn10.Caption = "Total"
                GridColumn10.OptionsColumn.AllowEdit = False
                btnRemovePerson.Enabled = True
            Else
                Exit Sub
            End If
        ElseIf Persons = 2 Then
            Caption.txtCaption.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Visible = True
                GridColumn32.Visible = True
                GridColumn31.Visible = True
                GridColumn9.Width = GridColumn9.Width - 80
                GridColumn31.Caption = Caption.txtCaption.Text
                GridColumn33.VisibleIndex = 1
                GridColumn32.VisibleIndex = 2
                GridColumn31.VisibleIndex = 3
                Persons += 1
            Else
                Exit Sub
            End If
        ElseIf Persons = 3 Then
            Caption.txtCaption.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Visible = True
                GridColumn32.Visible = True
                GridColumn31.Visible = True
                GridColumn29.Visible = True
                GridColumn9.Width = GridColumn9.Width - 80
                GridColumn29.Caption = Caption.txtCaption.Text
                GridColumn33.VisibleIndex = 1
                GridColumn32.VisibleIndex = 2
                GridColumn31.VisibleIndex = 3
                GridColumn29.VisibleIndex = 4
                Persons += 1
            Else
                Exit Sub
            End If
        ElseIf Persons = 4 Then
            Caption.txtCaption.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Visible = True
                GridColumn32.Visible = True
                GridColumn31.Visible = True
                GridColumn29.Visible = True
                GridColumn28.Visible = True
                GridColumn9.Width = GridColumn9.Width - 80
                GridColumn28.Caption = Caption.txtCaption.Text
                GridColumn33.VisibleIndex = 1
                GridColumn32.VisibleIndex = 2
                GridColumn31.VisibleIndex = 3
                GridColumn29.VisibleIndex = 4
                GridColumn28.VisibleIndex = 5
                Persons += 1
            Else
                Exit Sub
            End If
        ElseIf Persons = 5 Then
            Caption.txtCaption.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Visible = True
                GridColumn32.Visible = True
                GridColumn31.Visible = True
                GridColumn29.Visible = True
                GridColumn28.Visible = True
                GridColumn27.Visible = True
                GridColumn9.Width = GridColumn9.Width - 80
                GridColumn27.Caption = Caption.txtCaption.Text
                GridColumn33.VisibleIndex = 1
                GridColumn32.VisibleIndex = 2
                GridColumn31.VisibleIndex = 3
                GridColumn29.VisibleIndex = 4
                GridColumn28.VisibleIndex = 5
                GridColumn27.VisibleIndex = 6
                Persons += 1
            Else
                Exit Sub
            End If
        ElseIf Persons = 6 Then
            Caption.txtCaption.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Visible = True
                GridColumn32.Visible = True
                GridColumn31.Visible = True
                GridColumn29.Visible = True
                GridColumn28.Visible = True
                GridColumn27.Visible = True
                GridColumn26.Visible = True
                GridColumn9.Width = GridColumn9.Width - 80
                GridColumn26.Caption = Caption.txtCaption.Text
                GridColumn33.VisibleIndex = 1
                GridColumn32.VisibleIndex = 2
                GridColumn31.VisibleIndex = 3
                GridColumn29.VisibleIndex = 4
                GridColumn28.VisibleIndex = 5
                GridColumn27.VisibleIndex = 6
                GridColumn26.VisibleIndex = 7
                Persons += 1
            Else
                Exit Sub
            End If
        ElseIf Persons = 7 Then
            Caption.txtCaption.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Visible = True
                GridColumn32.Visible = True
                GridColumn31.Visible = True
                GridColumn29.Visible = True
                GridColumn28.Visible = True
                GridColumn27.Visible = True
                GridColumn26.Visible = True
                GridColumn25.Visible = True
                GridColumn9.Width = GridColumn9.Width - 80
                GridColumn25.Caption = Caption.txtCaption.Text
                GridColumn33.VisibleIndex = 1
                GridColumn32.VisibleIndex = 2
                GridColumn31.VisibleIndex = 3
                GridColumn29.VisibleIndex = 4
                GridColumn28.VisibleIndex = 5
                GridColumn27.VisibleIndex = 6
                GridColumn26.VisibleIndex = 7
                GridColumn25.VisibleIndex = 8
                Persons += 1
            Else
                Exit Sub
            End If
        ElseIf Persons = 8 Then
            Caption.txtCaption.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Visible = True
                GridColumn32.Visible = True
                GridColumn31.Visible = True
                GridColumn29.Visible = True
                GridColumn28.Visible = True
                GridColumn27.Visible = True
                GridColumn26.Visible = True
                GridColumn25.Visible = True
                GridColumn35.Visible = True
                GridColumn9.Width = GridColumn9.Width - 80
                GridColumn35.Caption = Caption.txtCaption.Text
                GridColumn33.VisibleIndex = 1
                GridColumn32.VisibleIndex = 2
                GridColumn31.VisibleIndex = 3
                GridColumn29.VisibleIndex = 4
                GridColumn28.VisibleIndex = 5
                GridColumn27.VisibleIndex = 6
                GridColumn26.VisibleIndex = 7
                GridColumn25.VisibleIndex = 8
                GridColumn35.VisibleIndex = 9
                Persons += 1
            Else
                Exit Sub
            End If
        ElseIf Persons = 9 Then
            Caption.txtCaption.Text = ""
            If Caption.ShowDialog = DialogResult.OK Then
                GridColumn33.Visible = True
                GridColumn32.Visible = True
                GridColumn31.Visible = True
                GridColumn29.Visible = True
                GridColumn28.Visible = True
                GridColumn27.Visible = True
                GridColumn26.Visible = True
                GridColumn25.Visible = True
                GridColumn35.Visible = True
                GridColumn34.Visible = True
                GridColumn34.Visible = True
                GridColumn9.Width = GridColumn9.Width - 80
                GridColumn34.Caption = Caption.txtCaption.Text
                GridColumn33.VisibleIndex = 1
                GridColumn32.VisibleIndex = 2
                GridColumn31.VisibleIndex = 3
                GridColumn29.VisibleIndex = 4
                GridColumn28.VisibleIndex = 5
                GridColumn27.VisibleIndex = 6
                GridColumn26.VisibleIndex = 7
                GridColumn25.VisibleIndex = 8
                GridColumn35.VisibleIndex = 9
                GridColumn34.VisibleIndex = 10
            Else
                Exit Sub
            End If
            Persons += 1
            btnAddPerson.Enabled = False
        End If
    End Sub

    Private Sub BtnRemovePerson_Click(sender As Object, e As EventArgs) Handles btnRemovePerson.Click
        btnAddPerson.Enabled = True
        GridColumn9.Width = 985
        If Persons = 10 Then
            GridColumn34.Visible = False
            With GridView2
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 10", 0)
                    .SetRowCellValue(x, "Amount", .GetRowCellValue(x, "Amount 1") + .GetRowCellValue(x, "Amount 2") + .GetRowCellValue(x, "Amount 3") + .GetRowCellValue(x, "Amount 4") + .GetRowCellValue(x, "Amount 5") + .GetRowCellValue(x, "Amount 6") + .GetRowCellValue(x, "Amount 7") + .GetRowCellValue(x, "Amount 8") + .GetRowCellValue(x, "Amount 9"))
                Next
            End With
            Persons -= 1
        ElseIf Persons = 9 Then
            GridColumn34.Visible = False
            GridColumn35.Visible = False
            With GridView2
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 9", 0)
                    .SetRowCellValue(x, "Amount", .GetRowCellValue(x, "Amount 1") + .GetRowCellValue(x, "Amount 2") + .GetRowCellValue(x, "Amount 3") + .GetRowCellValue(x, "Amount 4") + GridView2.GetRowCellValue(x, "Amount 5") + .GetRowCellValue(x, "Amount 6") + .GetRowCellValue(x, "Amount 7") + .GetRowCellValue(x, "Amount 8"))
                Next
            End With
            Persons -= 1
        ElseIf Persons = 8 Then
            GridColumn34.Visible = False
            GridColumn35.Visible = False
            GridColumn25.Visible = False
            With GridView2
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 8", 0)
                    .SetRowCellValue(x, "Amount", .GetRowCellValue(x, "Amount 1") + .GetRowCellValue(x, "Amount 2") + .GetRowCellValue(x, "Amount 3") + .GetRowCellValue(x, "Amount 4") + .GetRowCellValue(x, "Amount 5") + .GetRowCellValue(x, "Amount 6") + .GetRowCellValue(x, "Amount 7"))
                Next
            End With
            Persons -= 1
        ElseIf Persons = 7 Then
            GridColumn34.Visible = False
            GridColumn35.Visible = False
            GridColumn25.Visible = False
            GridColumn26.Visible = False
            With GridView2
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 7", 0)
                    .SetRowCellValue(x, "Amount", .GetRowCellValue(x, "Amount 1") + .GetRowCellValue(x, "Amount 2") + .GetRowCellValue(x, "Amount 3") + .GetRowCellValue(x, "Amount 4") + .GetRowCellValue(x, "Amount 5") + .GetRowCellValue(x, "Amount 6"))
                Next
            End With
            Persons -= 1
        ElseIf Persons = 6 Then
            GridColumn34.Visible = False
            GridColumn35.Visible = False
            GridColumn25.Visible = False
            GridColumn26.Visible = False
            GridColumn27.Visible = False
            With GridView2
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 6", 0)
                    .SetRowCellValue(x, "Amount", .GetRowCellValue(x, "Amount 1") + .GetRowCellValue(x, "Amount 2") + .GetRowCellValue(x, "Amount 3") + .GetRowCellValue(x, "Amount 4") + .GetRowCellValue(x, "Amount 5"))
                Next
            End With
            Persons -= 1
        ElseIf Persons = 5 Then
            GridColumn34.Visible = False
            GridColumn35.Visible = False
            GridColumn25.Visible = False
            GridColumn26.Visible = False
            GridColumn27.Visible = False
            GridColumn28.Visible = False
            With GridView2
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 5", 0)
                    .SetRowCellValue(x, "Amount", .GetRowCellValue(x, "Amount 1") + .GetRowCellValue(x, "Amount 2") + .GetRowCellValue(x, "Amount 3") + .GetRowCellValue(x, "Amount 4"))
                Next
            End With
            Persons -= 1
        ElseIf Persons = 4 Then
            GridColumn34.Visible = False
            GridColumn35.Visible = False
            GridColumn25.Visible = False
            GridColumn26.Visible = False
            GridColumn27.Visible = False
            GridColumn28.Visible = False
            GridColumn29.Visible = False
            With GridView2
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 4", 0)
                    .SetRowCellValue(x, "Amount", .GetRowCellValue(x, "Amount 1") + .GetRowCellValue(x, "Amount 2") + .GetRowCellValue(x, "Amount 3"))
                Next
            End With
            Persons -= 1
        ElseIf Persons = 3 Then
            GridColumn34.Visible = False
            GridColumn35.Visible = False
            GridColumn25.Visible = False
            GridColumn26.Visible = False
            GridColumn27.Visible = False
            GridColumn28.Visible = False
            GridColumn29.Visible = False
            GridColumn31.Visible = False
            With GridView2
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 3", 0)
                    .SetRowCellValue(x, "Amount", .GetRowCellValue(x, "Amount 1") + .GetRowCellValue(x, "Amount 2"))
                Next
            End With
            Persons -= 1
        ElseIf Persons = 2 Then
            GridColumn34.Visible = False
            GridColumn35.Visible = False
            GridColumn25.Visible = False
            GridColumn26.Visible = False
            GridColumn27.Visible = False
            GridColumn28.Visible = False
            GridColumn29.Visible = False
            GridColumn31.Visible = False
            GridColumn32.Visible = False
            With GridView2
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 2", 0)
                    .SetRowCellValue(x, "Amount", 0)
                Next
                GridColumn33.Visible = False
                For x As Integer = 0 To .RowCount - 1
                    .SetRowCellValue(x, "Amount 1", 0)
                    .SetRowCellValue(x, "Amount", 0)
                Next
            End With
            Persons -= 1
            btnRemovePerson.Enabled = False
        End If
        If Persons = 1 Then
            GridColumn10.Caption = "Amount"
            GridColumn10.OptionsColumn.AllowEdit = True
        End If
        For x As Integer = 1 To Persons - If(Persons = 1, 1, 0)
            GridColumn9.Width = GridColumn9.Width - 80
        Next
    End Sub

    Private Sub IAddRow_Click(sender As Object, e As EventArgs) Handles iAddRow.Click
        iRemoveRow.Enabled = True
        DT_Particular.Rows.Add(0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
    End Sub

    Private Sub IRemoveRow_Click(sender As Object, e As EventArgs) Handles iRemoveRow.Click
        iAddRow.Enabled = True
        DT_Particular.Rows.RemoveAt(GridView2.FocusedRowHandle)
        If GridView2.RowCount = 1 Then
            iRemoveRow.Enabled = False
        End If
    End Sub

    Private Sub CbxPayee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayee.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Try
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                Clear(False)
            Else
                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                txtPurpose.Text = drv("Purpose")
                dAmountReceived.Value = drv("Amount")
                txtCheckNumber.Text = drv("CheckNumber")
                txtCVNumber.Text = drv("DocumentNumber")
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Refundable(sender As Object, e As EventArgs) Handles dTotalExpense.ValueChanged, dAmountReceived.ValueChanged
        dRefundable.Value = dTotalExpense.Value - dAmountReceived.Value
    End Sub

    Private Sub GridView2_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        With GridView2
            If e.Column.FieldName = "Amount 1" Or e.Column.FieldName = "Amount 2" Or e.Column.FieldName = "Amount 3" Or e.Column.FieldName = "Amount 4" Or e.Column.FieldName = "Amount 5" Or e.Column.FieldName = "Amount 6" Or e.Column.FieldName = "Amount 7" Or e.Column.FieldName = "Amount 8" Or e.Column.FieldName = "Amount 9" Or e.Column.FieldName = "Amount 10" Then
                If .GetRowCellValue(.FocusedRowHandle, "Amount 1").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 1", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 2").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 2", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 3").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 3", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 4").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 4", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 5").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 5", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 6").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 6", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 7").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 7", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 8").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 8", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 9").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 9", 0)
                ElseIf .GetRowCellValue(.FocusedRowHandle, "Amount 10").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount 10", 0)
                End If
                .SetFocusedRowCellValue("Amount", CDbl(.GetFocusedRowCellValue("Amount 1")) + CDbl(.GetFocusedRowCellValue("Amount 2")) + CDbl(.GetFocusedRowCellValue("Amount 3")) + CDbl(.GetFocusedRowCellValue("Amount 4")) + CDbl(.GetFocusedRowCellValue("Amount 5")) + CDbl(.GetFocusedRowCellValue("Amount 6")) + CDbl(.GetFocusedRowCellValue("Amount 7")) + CDbl(.GetFocusedRowCellValue("Amount 8")) + CDbl(.GetFocusedRowCellValue("Amount 9")) + CDbl(.GetFocusedRowCellValue("Amount 10")))
            ElseIf e.Column.FieldName = "Amount" Then
                Dim TotalEx As Double
                If .GetRowCellValue(.FocusedRowHandle, "Amount").ToString = "" Then
                    .SetRowCellValue(.FocusedRowHandle, "Amount", 0)
                End If
                For x As Integer = 0 To .RowCount - 1
                    TotalEx += .GetRowCellValue(x, "Amount")
                Next
                dTotalExpense.Value = TotalEx
            End If
        End With
    End Sub

    Private Sub BtnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        Dim Signatory As Boolean
        If Empl_ID = CA_Approver Then
            Signatory = True
            GoTo Here
        End If
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnCheck.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next
Here:

        Dim drv As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
        Dim drvX As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) And Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .btnResend.Visible = True
                .btnAttachments.Visible = True
                .OTP = Code_Check
                .lblBilling.Visible = False
                Dim Result = .ShowDialog
                If Result = DialogResult.OK Then
                    Code = GenerateOTAC()
                    '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                    If Auto_Notification Then
                        Dim DT_CashAdvanceApprover As DataTable = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE ID = '{0}' AND `status` = 'ACTIVE';", drvX("ApprovedID")))
                        If DT_CashAdvanceApprover.Rows.Count > 0 Then
                            Dim Msg As String = String.Format("Good day {0}," & vbCrLf, DT_CashAdvanceApprover(0)("Employee"))
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Approval of Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_CashAdvanceApprover(0)("Phone") = "" Then
                            Else
                                SendSMS(DT_CashAdvanceApprover(0)("Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_CashAdvanceApprover(0)("EmailAdd") = "" Then
                            Else
                                Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                                AttachmentFiles = New ArrayList()
                                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                Generate_Receipt(False, FName)
                                AttachmentFiles.Add(FName)
                                SendEmail(DT_CashAdvanceApprover(0)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                            End If
                        End If
                    End If
                    '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                    DataObject(String.Format("UPDATE liquidation_main SET `Liq_Status` = 'CHECKED', CheckedID = '{1}', Approve_OTAC = '{2}' WHERE ID = '{0}';", ID, CA_Approver, Code))
                    Logs("Liquidation of Expenses", "Check", String.Format("Checked Liquidation of Expenses of {0} with the total expense of {1} for {2}. [Via OTAC]", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotalExpense.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                    MsgBox("Successfully Checked!" & mEmail, MsgBoxStyle.Information, "Info")
                    Clear(True)
                ElseIf Result = DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    CheckNotification(Code_Check)
                    Cursor = Cursors.Default
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you want to check this Liquidation of Expenses?") = MsgBoxResult.Yes Then
                Code = GenerateOTAC()

                If Auto_Notification Then
                    Dim DT_CashAdvanceApprover As DataTable = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE ID = '{0}' AND `status` = 'ACTIVE';", drvX("ApprovedID")))
                    If DT_CashAdvanceApprover.Rows.Count > 0 Then
                        Dim Msg As String = String.Format("Good day {0}," & vbCrLf, DT_CashAdvanceApprover(0)("Employee"))
                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Approval of Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If DT_CashAdvanceApprover(0)("Phone") = "" Then
                        Else
                            SendSMS(DT_CashAdvanceApprover(0)("Phone"), Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If DT_CashAdvanceApprover(0)("EmailAdd") = "" Then
                        Else
                            Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                            AttachmentFiles = New ArrayList()
                            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            Generate_Receipt(False, FName)
                            AttachmentFiles.Add(FName)
                            SendEmail(DT_CashAdvanceApprover(0)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                        End If
                    End If
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************

                DataObject(String.Format("UPDATE liquidation_main SET `Liq_Status` = 'CHECKED', CheckedID = '{1}', Approve_OTAC = '{2}' WHERE ID = '{0}';", ID, Empl_ID, Code))
                Logs("Liquidation of Expenses", "Check", String.Format("Checked Liquidation of Expenses of {0} with the total expense of {1} for {2}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotalExpense.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                MsgBox("Successfully Checked!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim Signatory As Boolean
        If Empl_ID = CA_Approver Then
            Signatory = True
            GoTo Here
        End If
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next
Here:

        Dim drv As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
        Dim drvX As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) And Signatory = False Then
            Dim OTP As New FrmOneTimePassword
            With OTP
                .btnAttachments.Visible = True
                .btnResend.Visible = True
                .OTP = Code_Approve
                .lblBilling.Visible = False
                Dim Result = .ShowDialog
                If Result = DialogResult.OK Then
                    Dim SQL As String
                    DataObject(String.Format("UPDATE liquidation_main SET `Liq_Status` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, CA_Approver))
                    If dRefundable.Value > 0 And dRefundable.Value <= 1000 Then
                        'AUTOMATIC PETTY CASH VOUCHER ***************************************************************
                        SQL = "INSERT INTO petty_cash SET"
                        SQL &= String.Format(" Payee_ID = '{0}', ", ValidateComboBox(cbxPayee))
                        SQL &= String.Format(" Payee_Type = '{0}', ", "C")
                        SQL &= String.Format(" Payee = '{0}', ", cbxPayee.Text)
                        SQL &= String.Format(" Trans_Date = '{0}', ", FormatDatePicker(dtpDate))
                        SQL &= String.Format(" CANumber = '{0}', ", drvX("AccountNumber"))
                        SQL &= String.Format(" LOE_Number = '{0}', ", txtAccountNumber.Text)
                        SQL &= String.Format(" AccountNumber = '{0}', ", DataObject(String.Format("SELECT CONCAT('PCV-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM petty_cash WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDate.Value, "yy"), Format(dtpDate.Value, "yyyy-MM-dd"))))
                        SQL &= String.Format(" TIN = '{0}', ", "")
                        SQL &= String.Format(" Purpose = '{0}', ", txtPurpose.Text.Trim.InsertQuote)
                        SQL &= String.Format(" Particular_1 = '{0}', ", "Refund Amount. [" & txtAccountNumber.Text & "]")
                        SQL &= String.Format(" DepartmentCode_1 = '{0}', ", "")
                        SQL &= String.Format(" Amount_1 = '{0}', ", dRefundable.Value)
                        SQL &= String.Format(" Particular_2 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_2 = '{0}', ", "")
                        SQL &= String.Format(" Amount_2 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_3 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_3 = '{0}', ", "")
                        SQL &= String.Format(" Amount_3 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_4 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_4 = '{0}', ", "")
                        SQL &= String.Format(" Amount_4 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_5 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_5 = '{0}', ", "")
                        SQL &= String.Format(" Amount_5 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_6 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_6 = '{0}', ", "")
                        SQL &= String.Format(" Amount_6 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_7 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_7 = '{0}', ", "")
                        SQL &= String.Format(" Amount_7 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_8 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_8 = '{0}', ", "")
                        SQL &= String.Format(" Amount_8 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_9 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_9 = '{0}', ", "")
                        SQL &= String.Format(" Amount_9 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_10 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_10 = '{0}', ", "")
                        SQL &= String.Format(" Amount_10 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_11 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_11 = '{0}', ", "")
                        SQL &= String.Format(" Amount_11 = '{0}', ", 0)
                        SQL &= String.Format(" Particular_12 = '{0}', ", "")
                        SQL &= String.Format(" DepartmentCode_12 = '{0}', ", "")
                        SQL &= String.Format(" Amount_12 = '{0}', ", 0)
                        SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                        SQL &= String.Format(" User_Code = '{0}', ", User_Code)
                        SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                        SQL &= String.Format(" Head_OTAC = '{0}', ", Code)
                        SQL &= " ReceivedID = '0', "
                        SQL &= " ReceivedDate = '', "
                        SQL &= " voucher_status = 'APPROVED', "
                        SQL &= String.Format(" ApprovedID = '{0}', ", CA_Approver)
                        SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                        DataObject(SQL)
                    ElseIf dRefundable.Value > 0 And dRefundable.Value > 1000 Then
                        'AUTOMATIC CHECK VOUCHER ***************************************************************
                        MsgBox("Refundable is greater than P1,000.00 please ask the accounting for your CV for refund.", MsgBoxStyle.Information, "Info")
                    End If
                    Logs("Liquidation of Expenses", "Approve", String.Format("Approved Liquidation of Expenses of {0} with the total expense of {1} for {2}. [Via OTAC]", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotalExpense.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                    MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                    Clear(True)
                ElseIf Result = DialogResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    ApproveNotification(Code_Approve)
                    Cursor = Cursors.Default
                End If
            End With
        Else
            If MsgBoxYes("Are you sure you want to approve this Liquidation of Expenses?") = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE liquidation_main SET `Liq_Status` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, Empl_ID))
                Dim SQL As String
                If dRefundable.Value > 0 And dRefundable.Value <= 1000 Then
                    'AUTOMATIC PETTY CASH VOUCHER ***************************************************************
                    SQL = "INSERT INTO petty_cash SET"
                    SQL &= String.Format(" Payee_ID = '{0}', ", ValidateComboBox(cbxPayee))
                    SQL &= String.Format(" Payee_Type = '{0}', ", "C")
                    SQL &= String.Format(" Payee = '{0}', ", cbxPayee.Text)
                    SQL &= String.Format(" Trans_Date = '{0}', ", FormatDatePicker(dtpDate))
                    SQL &= String.Format(" CANumber = '{0}', ", drvX("AccountNumber"))
                    SQL &= String.Format(" LOE_Number = '{0}', ", txtAccountNumber.Text)
                    SQL &= String.Format(" AccountNumber = '{0}', ", DataObject(String.Format("SELECT CONCAT('PCV-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM petty_cash WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDate.Value, "yy"), Format(dtpDate.Value, "yyyy-MM-dd"))))
                    SQL &= String.Format(" TIN = '{0}', ", "")
                    SQL &= String.Format(" Purpose = '{0}', ", txtPurpose.Text.Trim.InsertQuote)
                    SQL &= String.Format(" Particular_1 = '{0}', ", "Refund Amount. [" & txtAccountNumber.Text & "]")
                    SQL &= String.Format(" DepartmentCode_1 = '{0}', ", "")
                    SQL &= String.Format(" Amount_1 = '{0}', ", dRefundable.Value)
                    SQL &= String.Format(" Particular_2 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_2 = '{0}', ", "")
                    SQL &= String.Format(" Amount_2 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_3 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_3 = '{0}', ", "")
                    SQL &= String.Format(" Amount_3 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_4 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_4 = '{0}', ", "")
                    SQL &= String.Format(" Amount_4 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_5 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_5 = '{0}', ", "")
                    SQL &= String.Format(" Amount_5 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_6 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_6 = '{0}', ", "")
                    SQL &= String.Format(" Amount_6 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_7 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_7 = '{0}', ", "")
                    SQL &= String.Format(" Amount_7 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_8 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_8 = '{0}', ", "")
                    SQL &= String.Format(" Amount_8 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_9 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_9 = '{0}', ", "")
                    SQL &= String.Format(" Amount_9 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_10 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_10 = '{0}', ", "")
                    SQL &= String.Format(" Amount_10 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_11 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_11 = '{0}', ", "")
                    SQL &= String.Format(" Amount_11 = '{0}', ", 0)
                    SQL &= String.Format(" Particular_12 = '{0}', ", "")
                    SQL &= String.Format(" DepartmentCode_12 = '{0}', ", "")
                    SQL &= String.Format(" Amount_12 = '{0}', ", 0)
                    SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                    SQL &= String.Format(" User_Code = '{0}', ", User_Code)
                    SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                    SQL &= String.Format(" Head_OTAC = '{0}', ", Code)
                    SQL &= " ReceivedID = '0', "
                    SQL &= " ReceivedDate = '', "
                    SQL &= " voucher_status = 'APPROVED', "
                    SQL &= String.Format(" ApprovedID = '{0}', ", Empl_ID)
                    SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                    DataObject(SQL)
                ElseIf dRefundable.Value > 0 And dRefundable.Value > 1000 Then
                    'AUTOMATIC CHECK VOUCHER ***************************************************************
                    MsgBox("Refundable is greater than P1,000.00 please ask the accounting for your CV for refund.", MsgBoxStyle.Information, "Info")
                End If
                Logs("Liquidation of Expenses", "Approve", String.Format("Approved Liquidation of Expenses of {0} with the total expense of {1} for {2}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotalExpense.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
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
            .FolderName = "Liquidation-" & GridView1.GetFocusedRowCellValue("Account Number")
            .LiqNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Account Number")
            .Type = "Liquidation"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", .TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If MsgBoxYes("Are you sure you want to disapprove this Liquidation of Expenses?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            DataObject(String.Format("UPDATE liquidation_main SET `Liq_Status` = 'DISAPPROVED', DisapprovedID = '{2}' WHERE ID = '{0}';UPDATE cash_advance SET Liquidated = 'N' WHERE AccountNumber = '{1}';", ID, drv("AccountNumber"), Empl_ID))
            Logs("Liquidation of Expenses", "Disapprove", Reason, String.Format("Disapproved Liquidation of Expenses of {0} with total expense of {1}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotalExpense.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Disapproved", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub CheckNotification(xCode As String)
        Code = xCode
        Code_Check = Code
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim DT_CashAdvanceApprover As DataTable = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE ID = '{0}' AND `status` = 'ACTIVE';", drv("ApprovedID")))
        If DT_CashAdvanceApprover.Rows.Count > 0 Then
            Dim Msg As String = String.Format("Good day {0}," & vbCrLf, DT_CashAdvanceApprover(0)("Employee"))
            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Checking of Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
            Msg &= "Thank you!"
            '******* SEND SMS *********************************************************************************
            If DT_CashAdvanceApprover(0)("Phone") = "" Then
            Else
                SendSMS(DT_CashAdvanceApprover(0)("Phone"), Msg, True)
            End If
            '******* SEND EMAIL *********************************************************************************
            If DT_CashAdvanceApprover(0)("EmailAdd") = "" Then
            Else
                Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                AttachmentFiles = New ArrayList()
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                Generate_Receipt(False, FName)
                AttachmentFiles.Add(FName)
                SendEmail(DT_CashAdvanceApprover(0)("EmailAdd"), Subject, Msg, False, True, False, 0, "", "")
            End If
        End If
    End Sub

    Private Sub ApproveNotification(xCode As String)
        Code = xCode
        Code_Approve = Code
        Dim drvX As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim DT_CashAdvanceApprover As DataTable = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE ID = '{0}' AND `status` = 'ACTIVE';", drvX("ApprovedID")))
        If DT_CashAdvanceApprover.Rows.Count > 0 Then
            Dim Msg As String = String.Format("Good day {0}," & vbCrLf, DT_CashAdvanceApprover(0)("Employee"))
            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for the Approval of Liquidation of Expenses of {1} with the total expense of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotalExpense.Text, txtPurpose.Text)
            Msg &= "Thank you!"
            '******* SEND SMS *********************************************************************************
            If DT_CashAdvanceApprover(0)("Phone") = "" Then
            Else
                SendSMS(DT_CashAdvanceApprover(0)("Phone"), Msg, True)
            End If
            '******* SEND EMAIL *********************************************************************************
            If DT_CashAdvanceApprover(0)("EmailAdd") = "" Then
            Else
                Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                AttachmentFiles = New ArrayList()
                Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                Generate_Receipt(False, FName)
                AttachmentFiles.Add(FName)
                SendEmail(DT_CashAdvanceApprover(0)("EmailAdd"), Subject, Msg, False, True, False, 0, "", "")
            End If
        End If
    End Sub

    Private Sub BtnEmailCrecom_Click(sender As Object, e As EventArgs) Handles btnEmailCrecom.Click
        If MsgBoxYes("Are you sure you want to send this Liquidation of Expenses to Credit Committee?") = MsgBoxResult.Yes Then
            Dim CreComm As New FrmCrecomList
            With CreComm
                .IncludeDM = True
                .IncludeRM = True
                If .ShowDialog = DialogResult.OK Then
                    Dim Email As String = ""
                    For x As Integer = 0 To .GridView1.RowCount - 1
                        If CBool(.GridView1.GetRowCellValue(x, "Include")) = True Then
                            Email &= .GridView1.GetRowCellValue(x, "Email Address") & ", "
                        End If
                    Next
                    Email = Email.Substring(0, Email.Length - 2)

                    Dim Subject As String = "Liquidation of Expenses Approval [" & txtAccountNumber.Text & "]"
                    Dim Body As String = "Dear Sir/Madam,<br><br>"
                    Body &= "Sending to you Liquidation of Expenses with the following information<br><br>"
                    Body &= "Payee : <b>" & cbxPayee.Text & "</b><br>"
                    Body &= "Total Actual Expenses : <b>" & dTotalExpense.Text & "</b><br>"
                    Body &= "Amount Received : <b>" & dAmountReceived.Text & "</b><br>"
                    Body &= "Check Number : <b>" & txtCheckNumber.Text & "</b><br>"
                    Body &= "CV Number : <b>" & txtCVNumber.Text & "</b><br>"
                    Body &= "Purpose : <b>" & txtPurpose.Text & "</b><br>"
                    Body &= "Thank you<br>"

                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    Generate_Receipt(False, FName)
                    AttachmentFiles.Add(FName)
                    SendEmail(Email, Subject, Body, False, True, False, 0, "", "")
                    Logs("Liquidation", "Email", "Email", String.Format("Email Liquidation of Expenses with Account Number {0}", txtAccountNumber.Text), "", "", "")
                    LoadData()
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnCheckVoucher_Click(sender As Object, e As EventArgs) Handles btnCheckVoucher.Click
        Try
            If GridView1.GetFocusedRowCellValue("Liq_Status").ToString = "FOR CHECK VOUCHER" Then
            Else
                If GridView1.GetFocusedRowCellValue("Liq_Status") = "FOR JOURNAL VOUCHER" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "UNPOSTED JV" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "POSTED JV" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "DISAPPROVED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "DELETED" Then
                    MsgBox(String.Format("Liquidation of Expenses is already {0}.", GridView1.GetFocusedRowCellValue("Liq_Status")), MsgBoxStyle.Information, "Info")
                    Exit Sub
                Else
                    MsgBox("Liquidation of Expenses not For Check Voucher.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
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
            Logs("Liquidation of Expenses", "Check Voucher", "Check Voucher", "", "", "", "")

            .From_CA = True
            .cbxPayee.Tag = GridView1.GetFocusedRowCellValue("Account Number")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub BtnPettyCash_Click(sender As Object, e As EventArgs) Handles btnPettyCash.Click
        Try
            If GridView1.GetFocusedRowCellValue("Liq_Status").ToString = "FOR PETTY CASH RELEASE" Then
            Else
                If GridView1.GetFocusedRowCellValue("Liq_Status") = "FOR JOURNAL VOUCHER" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "UNPOSTED JV" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "POSTED JV" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "DISAPPROVED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "DELETED" Then
                    MsgBox(String.Format("Liquidation of Expenses is already {0}.", GridView1.GetFocusedRowCellValue("Liq_Status")), MsgBoxStyle.Information, "Info")
                    Exit Sub
                Else
                    MsgBox("Liquidation of Expenses not For Petty Cash Release.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim PCV As New FrmPettyCashVoucher
        With PCV
            .Tag = 79
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            Else
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                .Dispose()
                Exit Sub
            End If

            .FormBorderStyle = FormBorderStyle.FixedDialog
            .tabList.Visible = False
            .From_LOE = True
            .AccountNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .cbxPayee.Enabled = False
            .cbxLiquidate.Checked = False
            .cbxLiquidate.Enabled = False
            .cbxOther.Enabled = False
            .btnRefresh.Enabled = False
            .btnNext.Enabled = False
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAcknowledgement_Click(sender As Object, e As EventArgs) Handles btnAcknowledgement.Click
        Try
            If GridView1.GetFocusedRowCellValue("Liq_Status").ToString = "FOR ACKNOWLEDGEMENT RECEIPT" Then
            Else
                If GridView1.GetFocusedRowCellValue("Liq_Status") = "FOR JOURNAL VOUCHER" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "UNPOSTED JV" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "POSTED JV" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "DISAPPROVED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "DELETED" Then
                    MsgBox(String.Format("Liquidation of Expenses is already {0}.", GridView1.GetFocusedRowCellValue("Liq_Status")), MsgBoxStyle.Information, "Info")
                    Exit Sub
                Else
                    MsgBox("Liquidation of Expenses not For Acknowledgement Receipt.", MsgBoxStyle.Information, "Info")
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
            .From_CashAdvance = True
            .AccountsReceivableID = GridView1.GetFocusedRowCellValue("Account Number")
            .cbxCash.Checked = True
            .cbxCheck.Enabled = False
            .cbxOnline.Enabled = False
            .tabList.Visible = False
            .btnNext.Enabled = False
            .btnRefresh.Enabled = False
            .cbxPayee.Enabled = False
            .cbxCheckNumber.Enabled = False
            .dtpDeposit.Enabled = False
            .cbxLOE.Enabled = False
            .cbxAR.Enabled = False
            .cbxAP.Enabled = False
            .cbxITL.Enabled = False
            .cbxRO.Enabled = False
            .cbxLOE.Checked = False
            .cbxAR.Checked = False
            .cbxAP.Checked = False
            .cbxITL.Checked = False
            .cbxRO.Checked = False
            .cbxLA.Enabled = False
            .cbxLA.Checked = False
            .cbxCAS.Enabled = False
            .cbxLOE.Checked = True

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub BtnJournalVoucher_Click(sender As Object, e As EventArgs) Handles btnJournalVoucher.Click
        Try
            If GridView1.GetFocusedRowCellValue("Liq_Status").ToString = "FOR JOURNAL VOUCHER" Then
            Else
                If GridView1.GetFocusedRowCellValue("Liq_Status") = "UNPOSTED JV" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "POSTED JV" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "DISAPPROVED" Or GridView1.GetFocusedRowCellValue("Liq_Status") = "DELETED" Then
                    MsgBox(String.Format("Liquidation of Expenses is already {0}.", GridView1.GetFocusedRowCellValue("Liq_Status")), MsgBoxStyle.Information, "Info")
                    Exit Sub
                Else
                    MsgBox("Liquidation of Expenses not For Journal Voucher.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

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
            .cbxLOE.Checked = True
            .From_LOE = True
            .BankID = GridView1.GetFocusedRowCellValue("BankID")
            .GL_DocumentNumber = GridView1.GetFocusedRowCellValue("ID")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub BtnViewCashAdvance_Click(sender As Object, e As EventArgs) Handles BtnViewCashAdvance.Click
        Try
            If GridView1.GetFocusedRowCellValue("CA Number").ToString = "" Then
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        OpenCashAdvance(GridView1.GetFocusedRowCellValue("CA Number").ToString)
    End Sub

    Private Sub OpenCashAdvance(DocumentNumber As String)
        Dim CAS As New FrmCashAdvanceSlip
        With CAS
            .Tag = 78
            FormRestriction(.Tag)
            If allow_Access = False Then
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                .Dispose()
                Exit Sub
            End If

            .FromLOE = True
            .lblTitle.Tag = DocumentNumber
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class