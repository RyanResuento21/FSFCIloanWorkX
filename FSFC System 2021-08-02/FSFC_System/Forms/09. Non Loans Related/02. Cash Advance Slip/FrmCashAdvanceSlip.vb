Imports DevExpress.XtraReports.UI
Public Class FrmCashAdvanceSlip

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim Code As String
    Dim Approver1_OTAC As String
    Dim Approver2_OTAC As String
    Dim Approver3_OTAC As String
    Dim Approver4_OTAC As String
    Dim Approver5_OTAC As String
    Dim User_EmplID As Integer
    Dim Dept_Head As Boolean
    Dim FirstLoad As Boolean = True
    Dim DepartmentalView As Boolean
    ReadOnly NotifyPayeeApprover As Boolean
    Dim SlipStatus As String
    Public FromLOE As Boolean

    Private Sub FrmCashAdvanceSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        cbxDisplay.SelectedIndex = 0
        If AllowFromOtherBranch = False Then
            cbxOther.Visible = False
            cbxPayee.Size = New Point(434, 25)
        End If

        dtpDate.Value = Date.Now
        dtp_1.Value = Date.Now
        dtp_2.Value = Date.Now
        dtp_3.Value = Date.Now
        dtp_4.Value = Date.Now
        dtp_5.Value = Date.Now
        dtp_6.Value = Date.Now
        dtp_7.Value = Date.Now
        dtpDate_2.Value = Date.Now

        dtp_1.CustomFormat = ""
        dtp_2.CustomFormat = ""
        dtp_3.CustomFormat = ""
        dtp_4.CustomFormat = ""
        dtp_5.CustomFormat = ""
        dtp_6.CustomFormat = ""
        dtp_7.CustomFormat = ""

        Dim DT_Status As DataTable = DataSource("SELECT 'For Approval' AS 'Status' UNION SELECT 'For Check Voucher' UNION SELECT 'For Disbursement' UNION SELECT 'CV for Approval' UNION SELECT 'CV for Clearing' UNION SELECT 'For Liquidation' UNION SELECT 'Liquidated' UNION SELECT 'Cancelled'")
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

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        GetAccountNumber()
        LoadData()
        FirstLoad = False

        With cbxPayee
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            LoadPayee()
            '.DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        If FromLOE Then
            cbxAll.Checked = True
            LoadData()
            Dim i As Integer = 0
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Account Number") = lblTitle.Tag Then
                    i = x
                    Exit For
                End If
            Next
            GridView1.FocusedRowHandle = i
            GridView1_DoubleClick(sender, e)
            tabList.Visible = False
            btnNext.Enabled = False
            btnRefresh.Enabled = False
            btnDelete.Enabled = False
            Exit Sub
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

            GetLabelFontSettings({LabelX2, LabelX1, LabelX10, LabelX6, LabelX100, LabelX4, LabelX7, LabelX9, LabelX13, LabelX15, LabelX17, LabelX99, LabelX3, LabelX5, LabelX8, LabelX12, LabelX14, LabelX16, LabelX22, LabelX23, LabelX24, LabelX25, LabelX26, LabelX27, LabelX33, LabelX31, LabelX32, LabelX44, LabelX34, LabelX37, LabelX43, LabelX35, LabelX36, LabelX38, LabelX40, LabelX42, LabelX41, LabelX39})

            GetLabelWithBackgroundFontSettings({LabelX20, LabelX21})

            GetLabelFontSettingsDefaultSize({LabelX19, LabelX18, LabelX28, LabelX29, LabelX30})

            GetTextBoxFontSettings({txtAccountNumber, txtPurpose, txtApproved, txtReceived, txtReceivedDate, txtName})

            GetCheckBoxFontSettings({cbxOther, cbxAll})

            GetGroupControlFontSettings({gRequest, gLiquidation})

            GetCheckBoxFontSettingsDefaultColor({cbxCancelled, cbxForApproval, cbxForCheckVoucher, cbxForLiquidation, cbxLiquidated, cbxReceived})

            GetComboBoxFontSettings({cbxPayee, cbxPreparedBy, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo, dtpDate, dtp_1, dtp_2, dtp_3, dtp_4, dtp_5, dtp_6, dtp_7, dtpDate_2})

            GetDateTimeInputFontSettingsDefault({dtpLiquidate, dtpPayroll})

            GetDoubleInputFontSettings({dMeal, dTransportation, dBIR, dRD, dLTO, dNotarizationF, dOthers, dAmount_1, dAmount_2, dAmount_3, dAmount_4, dAmount_5, dAmount_6, dAmount_7})

            GetDoubleInputFontSettingsDefault({dTotal, dTotalLiquidation})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetCheckComboBoxFontSettings({cbxStatus})

            GetButtonFontSettings({btnSearch, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDisapprove, btnDelete, btnPrint, btnAttach, btnReceive, btnApproveCrecomm, btnApprove})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Cash Advance Slip - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Cash Advance Slip", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ROW_NUMBER() OVER() AS 'No', cash_advance.ID,"
        SQL &= "    cash_advance.Payee_ID,"
        SQL &= "    Employee(cash_advance.Payee_ID) AS 'Payee',"
        SQL &= "    DATE_FORMAT(Trans_Date,'%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Account Number',"
        SQL &= "    Purpose,"
        SQL &= "    Meals,"
        SQL &= "    Transportation,"
        SQL &= "    BIR,"
        SQL &= "    RD,"
        SQL &= "    LTO,"
        SQL &= "    Notarization,"
        SQL &= "    Others,"
        SQL &= "    Meals + Transportation + BIR + RD + LTO + Notarization + Others AS 'Total',"
        SQL &= "    DATE_FORMAT(LiqDate_1,'%M %d, %Y') AS 'Date 1',"
        SQL &= "    LiqAmount_1 AS 'Amount 1',"
        SQL &= "    DATE_FORMAT(LiqDate_2,'%M %d, %Y') AS 'Date 2',"
        SQL &= "    LiqAmount_2 AS 'Amount 2',"
        SQL &= "    DATE_FORMAT(LiqDate_3,'%M %d, %Y') AS 'Date 3',"
        SQL &= "    LiqAmount_3 AS 'Amount 3',"
        SQL &= "    DATE_FORMAT(LiqDate_4,'%M %d, %Y') AS 'Date 4',"
        SQL &= "    LiqAmount_4 AS 'Amount 4',"
        SQL &= "    DATE_FORMAT(LiqDate_5,'%M %d, %Y') AS 'Date 5',"
        SQL &= "    LiqAmount_5 AS 'Amount 5',"
        SQL &= "    DATE_FORMAT(LiqDate_6,'%M %d, %Y') AS 'Date 6',"
        SQL &= "    LiqAmount_6 AS 'Amount 6',"
        SQL &= "    DATE_FORMAT(LiqDate_7,'%M %d, %Y') AS 'Date 7',"
        SQL &= "    LiqAmount_7 AS 'Amount 7',"
        If CashApprovalHierarchy Then
            SQL &= String.Format("   IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(Slip_Status IN ('DISAPPROVED','CANCELLED'), Slip_Status,IF(Slip_Status IN ('PENDING'),IF({0} > 0 AND Approver1 = 0,'FOR LEVEL I APPROVAL',IF({1} > 0 AND Approver2 = 0,'FOR LEVEL II APPROVAL',IF({2} > 0 AND Approver3 = 0,'FOR LEVEL III APPROVAL',IF({3} > 0 AND Approver4 = 0,'FOR LEVEL IV APPROVAL','FOR LEVEL V APPROVAL')))),IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000,IF(IFNULL((SELECT ApprovedID FROM petty_cash WHERE CANumber = cash_advance.AccountNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1),0) > 0,'LIQUIDATED',IF(IFNULL((SELECT PreparedID FROM petty_cash WHERE CANumber = cash_advance.AccountNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1),0) > 0,'LIQUIDATION FOR APPROVAL',IF(Slip_Status = 'APPROVED','FOR DISBURSEMENT','FOR LIQUIDATION'))),IF(Slip_Status = 'APPROVED' AND IFNULL(CV.ID,0) = 0,'FOR CHECK VOUCHER',IF(Slip_Status = 'APPROVED' AND IFNULL((CASE WHEN CV.Voucher_Status IN ('PENDING','CHECKED','APPROVED') THEN CV.ID END),0) > 0,'FOR DISBURSEMENT',IF(Slip_Status = 'RECEIVED' AND Liquidated = 'Y','LIQUIDATED',IF(ACRNumber='','FOR LIQUIDATION','ACKNOWLEDGED')))))))) AS 'Slip_Status',", Approver1_CashAdvance, Approver2_CashAdvance, Approver3_CashAdvance, Approver4_CashAdvance)
            'SQL &= String.Format("    IF(Slip_Status = 'RECEIVED' AND ReceivedDate = '','RECEIVED ACTG',IF(Slip_Status = 'RECEIVED' AND Liquidated = 'Y',IF(IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000,IFNULL((SELECT ApprovedID FROM petty_cash WHERE CANumber = cash_advance.AccountNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1),0),IFNULL((SELECT ApprovedID FROM liquidation_main WHERE CANumber = cash_advance.AccountNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1),0)) > 0,'LIQUIDATED','LIQUIDATION FOR APPROVAL'),IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(Slip_Status = 'PENDING',IF({0} > 0 AND Approver1 = 0,'FOR LEVEL I APPROVAL',IF({1} > 0 AND Approver2 = 0,'FOR LEVEL II APPROVAL',IF({2} > 0 AND Approver3 = 0,'FOR LEVEL III APPROVAL',IF({3} > 0 AND Approver4 = 0,'FOR LEVEL IV APPROVAL','FOR LEVEL V APPROVAL')))),'')))) AS 'Slip_Status',", Approver1_CashAdvance, Approver2_CashAdvance, Approver3_CashAdvance, Approver4_CashAdvance)
        Else
            'SQL &= " IF(Slip_Status='APPROVED' AND CVNumber!='','CV FOR APPROVAL',IF(Slip_Status = 'RECEIVED' AND ReceivedDate = '','RECEIVED ACTG',IF(Slip_Status = 'RECEIVED' AND Liquidated = 'Y',IF(IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000,IFNULL((SELECT ApprovedID FROM petty_cash WHERE CANumber = cash_advance.AccountNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1),0),IFNULL((SELECT ApprovedID FROM liquidation_main WHERE CANumber = cash_advance.AccountNumber AND `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1),0)) > 0,'LIQUIDATED','LIQUIDATION FOR APPROVAL'),IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,Slip_Status)))) AS 'Slip_Status',"
            SQL &= " IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(Slip_Status='DISAPPROVED',Slip_Status,IF(Slip_Status='PENDING','FOR HEAD APPROVAL',IF(((Slip_Status='APPROVED HEAD' OR Slip_Status='APPROVED') AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000) OR (Slip_Status='APPROVED' AND IFNULL((CASE WHEN CV.Voucher_Status = 'APPROVED' THEN CV.ID END),0) > 0),'FOR DISBURSEMENT',IF(Slip_Status='RECEIVED' AND Liquidated='Y','LIQUIDATED',IF(Slip_Status='APPROVED HEAD' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) > 1000,'FOR CREDIT COMMITTEE APPROVAL',IF(Slip_Status= 'APPROVED' AND CVNumber = '','FOR CHECK VOUCHER',IF(Slip_Status= 'APPROVED' AND Voucher_Status IN ('PENDING','CHECKED'),'CV FOR APPROVAL',IF(Slip_Status='RECEIVED' AND ClearedDate = '','CV FOR CLEARING',IF(ClearedDate != '' AND Liquidated='N','FOR LIQUIDATION',IF(Liquidated='Y','LIQUIDATED',Slip_Status))))))))))) AS 'Slip_Status',"
        End If
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID,"
        SQL &= "    DATE_FORMAT(LiqDate,'%M %d, %Y') AS 'Liquidation Date',"
        SQL &= "    DATE_FORMAT(SalaryDate,'%M %d, %Y') AS 'Salary Date', IFNULL(CV.ID,0) AS 'CV_ID', ClearedDate,"
        SQL &= "    BRANCH(branch_id) AS 'Branch', User_EmplID, Branch_ID, Employee(ApprovedID) AS 'Approved By', Employee(ReceivedID) AS 'Received By', IF(ReceivedDate = '','',DATE_FORMAT(ReceivedDate,'%M %d, %Y')) AS 'Received Date', Head_OTAC, Approver1_OTAC, Approver2_OTAC, Approver3_OTAC, Approver4_OTAC, Approver5_OTAC, Attach, ACRNumber, FromOtherBranch"
        SQL &= "  FROM cash_advance LEFT JOIN (SELECT ID, Payee_ID, voucher_status, ClearedDate FROM check_voucher WHERE Payee_Type = 'A' AND `status` = 'ACTIVE' AND voucher_status IN ('PENDING','CHECKED','APPROVED','RECEIVED') AND JVNumber = '') CV ON cash_advance.AccountNumber = CV.Payee_ID WHERE"
        Dim ForApproval As Boolean
        Dim ForCheckVoucher As Boolean
        Dim CVforApproval As Boolean
        Dim ForDisbursement As Boolean
        Dim CVforClearing As Boolean
        Dim ForLiquidation As Boolean
        Dim Liquidated As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    ForApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Check Voucher" Then
                    ForCheckVoucher = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "CV for Approval" Then
                    CVforApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Disbursement" Then
                    ForDisbursement = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "CV for Clearing" Then
                    CVforClearing = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Liquidation" Then
                    ForLiquidation = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Liquidated" Then
                    Liquidated = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForApproval = False And ForCheckVoucher = False And CVforApproval And ForDisbursement = False And CVforClearing = False And ForLiquidation = False And Liquidated = False Then
                SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED') OR slip_status = 'DISAPPROVED')"
            Else
                SQL &= " `status` IN ('ACTIVE','CANCELLED','DELETED','DISAPPROVED') AND (slip_status = 'DISAPPROVED' "
                If ForApproval Or ForCheckVoucher Or CVforApproval Or ForDisbursement Or CVforClearing Or ForLiquidation Or Liquidated Then
                    SQL &= " OR "
                End If
                'SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED','ACTIVE') AND (slip_status = 'DISAPPROVED' OR "
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status IN ('PENDING','APPROVED HEAD'),TRUE)"
                    If ForCheckVoucher Or CVforApproval Or ForDisbursement Or CVforClearing Or ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If ForCheckVoucher Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status IN ('APPROVED','APPROVED') AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) > 1000 and CVNumber = '',TRUE)"
                    If CVforApproval Or ForDisbursement Or CVforClearing Or ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If CVforApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status IN ('APPROVED','APPROVED') AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) > 1000 AND Voucher_Status != 'APPROVED',TRUE)"
                    If ForDisbursement Or CVforClearing Or ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If ForDisbursement Then
                    SQL &= " IF(`status` = 'ACTIVE',IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000,slip_status = 'APPROVED' OR slip_status = 'APPROVED HEAD',slip_status = 'APPROVED' AND IFNULL((CASE WHEN CV.Voucher_Status = 'APPROVED' THEN CV.ID END),0) > 0),TRUE)"
                    If CVforClearing Or ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If CVforClearing Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status = 'RECEIVED' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) > 1000 AND CV.ClearedDate = '',TRUE)"
                    If ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If ForLiquidation Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status = 'RECEIVED' AND Liquidated = 'N',TRUE)"
                    If Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If Liquidated Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status = 'RECEIVED' AND Liquidated = 'Y',TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForApproval Or ForCheckVoucher Or CVforApproval Or ForDisbursement Or CVforClearing Or ForLiquidation Or Liquidated Then
                SQL &= " AND ("
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status IN ('PENDING','APPROVED HEAD'),TRUE)"
                    If ForCheckVoucher Or CVforApproval Or ForDisbursement Or CVforClearing Or ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If ForCheckVoucher Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status = 'APPROVED' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) > 1000 AND CVNumber = '',TRUE)"
                    If CVforApproval Or ForDisbursement Or CVforClearing Or ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If CVforApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status = 'APPROVED' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) > 1000 AND Voucher_Status != 'APPROVED',TRUE)"
                    If ForDisbursement Or CVforClearing Or ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If ForDisbursement Then
                    SQL &= " IF(`status` = 'ACTIVE',IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000,slip_status = 'APPROVED' OR slip_status = 'APPROVED HEAD',slip_status = 'APPROVED' AND IFNULL((CASE WHEN CV.Voucher_Status = 'APPROVED' THEN CV.ID END),0) > 0),TRUE)"
                    If CVforClearing Or ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If CVforClearing Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status = 'RECEIVED' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) > 1000 AND CV.ClearedDate = '',TRUE)"
                    If ForLiquidation Or Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If ForLiquidation Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status = 'RECEIVED' AND Liquidated = 'N',TRUE)"
                    If Liquidated Then
                        SQL &= " OR "
                    End If
                End If
                If Liquidated Then
                    SQL &= " IF(`status` = 'ACTIVE',slip_status = 'RECEIVED' AND Liquidated = 'Y',TRUE)"
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
            GridColumn30.VisibleIndex = 31
        End If
        GridView1.Columns("Payee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Payee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView1.RowCount > 19 Then
            GridColumn6.Width = 370 - 17
        Else
            GridColumn6.Width = 370
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Dtp_1_Click(sender As Object, e As EventArgs) Handles dtp_1.Click
        dtp_1.CustomFormat = "MMMM dd, yyyy"
        dtp_2.Enabled = True
        dAmount_1.Enabled = True
    End Sub

    Private Sub Dtp_2_Click(sender As Object, e As EventArgs) Handles dtp_2.Click
        dtp_2.CustomFormat = "MMMM dd, yyyy"
        dtp_3.Enabled = True
        dAmount_2.Enabled = True
    End Sub

    Private Sub Dtp_3_Click(sender As Object, e As EventArgs) Handles dtp_3.Click
        dtp_3.CustomFormat = "MMMM dd, yyyy"
        dtp_4.Enabled = True
        dAmount_3.Enabled = True
    End Sub

    Private Sub Dtp_4_Click(sender As Object, e As EventArgs) Handles dtp_4.Click
        dtp_4.CustomFormat = "MMMM dd, yyyy"
        dtp_5.Enabled = True
        dAmount_4.Enabled = True
    End Sub

    Private Sub Dtp_5_Click(sender As Object, e As EventArgs) Handles dtp_5.Click
        dtp_5.CustomFormat = "MMMM dd, yyyy"
        dtp_6.Enabled = True
        dAmount_5.Enabled = True
    End Sub

    Private Sub Dtp_6_Click(sender As Object, e As EventArgs) Handles dtp_6.Click
        dtp_6.CustomFormat = "MMMM dd, yyyy"
        dtp_7.Enabled = True
        dAmount_6.Enabled = True
    End Sub

    Private Sub Dtp_7_Click(sender As Object, e As EventArgs) Handles dtp_7.Click
        dtp_7.CustomFormat = "MMMM dd, yyyy"
        dAmount_7.Enabled = True
    End Sub

    Private Sub DtpLiquidate_Click(sender As Object, e As EventArgs) Handles dtpLiquidate.Click
        dtpLiquidate.CustomFormat = "MMMM dd, yyyy"
        dtpPayroll.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpPayroll_Click(sender As Object, e As EventArgs) Handles dtpPayroll.Click
        dtpLiquidate.CustomFormat = "MMMM dd, yyyy"
        dtpPayroll.CustomFormat = "MMMM dd, yyyy"
    End Sub

#Region "Keydown"
    Private Sub CbxPayee_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPayee.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDate.Focus()
        End If
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPurpose.Focus()
        End If
    End Sub

    Private Sub TxtPurpose_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPurpose.KeyDown
        If e.KeyCode = Keys.Enter Then
            dMeal.Focus()
        End If
    End Sub

    Private Sub DMeal_KeyDown(sender As Object, e As KeyEventArgs) Handles dMeal.KeyDown
        If e.KeyCode = Keys.Enter Then
            dTransportation.Focus()
        End If
    End Sub

    Private Sub DTransportation_KeyDown(sender As Object, e As KeyEventArgs) Handles dTransportation.KeyDown
        If e.KeyCode = Keys.Enter Then
            dBIR.Focus()
        End If
    End Sub

    Private Sub DBIR_KeyDown(sender As Object, e As KeyEventArgs) Handles dBIR.KeyDown
        If e.KeyCode = Keys.Enter Then
            dRD.Focus()
        End If
    End Sub

    Private Sub DRD_KeyDown(sender As Object, e As KeyEventArgs) Handles dRD.KeyDown
        If e.KeyCode = Keys.Enter Then
            dLTO.Focus()
        End If
    End Sub

    Private Sub DLTO_KeyDown(sender As Object, e As KeyEventArgs) Handles dLTO.KeyDown
        If e.KeyCode = Keys.Enter Then
            dNotarizationF.Focus()
        End If
    End Sub

    Private Sub DNotarizationF_KeyDown(sender As Object, e As KeyEventArgs) Handles dNotarizationF.KeyDown
        If e.KeyCode = Keys.Enter Then
            dOthers.Focus()
        End If
    End Sub

    Private Sub DOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles dOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_1.Focus()
        End If
    End Sub

    Private Sub Dtp_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_1.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtp_1.CustomFormat = ""
            dtp_2.CustomFormat = ""
            dtp_3.CustomFormat = ""
            dtp_4.CustomFormat = ""
            dtp_5.CustomFormat = ""
            dtp_6.CustomFormat = ""
            dtp_7.CustomFormat = ""
            dtp_2.Enabled = False
            dtp_3.Enabled = False
            dtp_4.Enabled = False
            dtp_5.Enabled = False
            dtp_6.Enabled = False
            dtp_7.Enabled = False
            dAmount_1.Enabled = False
            dAmount_2.Enabled = False
            dAmount_3.Enabled = False
            dAmount_4.Enabled = False
            dAmount_5.Enabled = False
            dAmount_6.Enabled = False
            dAmount_7.Enabled = False
            dAmount_1.Value = 0
            dAmount_2.Value = 0
            dAmount_3.Value = 0
            dAmount_4.Value = 0
            dAmount_5.Value = 0
            dAmount_6.Value = 0
            dAmount_7.Value = 0
            btnSave.Focus()
        End If
    End Sub

    Private Sub DAmount_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_2.Focus()
        End If
    End Sub

    Private Sub Dtp_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_2.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtp_2.CustomFormat = ""
            dtp_3.CustomFormat = ""
            dtp_4.CustomFormat = ""
            dtp_5.CustomFormat = ""
            dtp_6.CustomFormat = ""
            dtp_7.CustomFormat = ""
            dtp_3.Enabled = False
            dtp_4.Enabled = False
            dtp_5.Enabled = False
            dtp_6.Enabled = False
            dtp_7.Enabled = False
            dAmount_2.Enabled = False
            dAmount_3.Enabled = False
            dAmount_4.Enabled = False
            dAmount_5.Enabled = False
            dAmount_6.Enabled = False
            dAmount_7.Enabled = False
            dAmount_2.Value = 0
            dAmount_3.Value = 0
            dAmount_4.Value = 0
            dAmount_5.Value = 0
            dAmount_6.Value = 0
            dAmount_7.Value = 0
            btnSave.Focus()
        End If
    End Sub

    Private Sub DAmount_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_3.Focus()
        End If
    End Sub

    Private Sub Dtp_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_3.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtp_3.CustomFormat = ""
            dtp_4.CustomFormat = ""
            dtp_5.CustomFormat = ""
            dtp_6.CustomFormat = ""
            dtp_7.CustomFormat = ""
            dtp_4.Enabled = False
            dtp_5.Enabled = False
            dtp_6.Enabled = False
            dtp_7.Enabled = False
            dAmount_3.Enabled = False
            dAmount_4.Enabled = False
            dAmount_5.Enabled = False
            dAmount_6.Enabled = False
            dAmount_7.Enabled = False
            dAmount_3.Value = 0
            dAmount_4.Value = 0
            dAmount_5.Value = 0
            dAmount_6.Value = 0
            dAmount_7.Value = 0
            btnSave.Focus()
        End If
    End Sub

    Private Sub DAmount_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_4.Focus()
        End If
    End Sub

    Private Sub Dtp_4_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_4.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtp_4.CustomFormat = ""
            dtp_5.CustomFormat = ""
            dtp_6.CustomFormat = ""
            dtp_7.CustomFormat = ""
            dtp_5.Enabled = False
            dtp_6.Enabled = False
            dtp_7.Enabled = False
            dAmount_4.Enabled = False
            dAmount_5.Enabled = False
            dAmount_6.Enabled = False
            dAmount_7.Enabled = False
            dAmount_4.Value = 0
            dAmount_5.Value = 0
            dAmount_6.Value = 0
            dAmount_7.Value = 0
            btnSave.Focus()
        End If
    End Sub

    Private Sub DAmount_4_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_5.Focus()
        End If
    End Sub

    Private Sub Dtp_5_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_5.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_5.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtp_5.CustomFormat = ""
            dtp_6.CustomFormat = ""
            dtp_7.CustomFormat = ""
            dtp_6.Enabled = False
            dtp_7.Enabled = False
            dAmount_5.Enabled = False
            dAmount_6.Enabled = False
            dAmount_7.Enabled = False
            dAmount_5.Value = 0
            dAmount_6.Value = 0
            dAmount_7.Value = 0
            btnSave.Focus()
        End If
    End Sub

    Private Sub DAmount_5_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_5.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_6.Focus()
        End If
    End Sub

    Private Sub Dtp_6_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_6.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_6.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtp_6.CustomFormat = ""
            dtp_7.CustomFormat = ""
            dtp_7.Enabled = False
            dAmount_6.Enabled = False
            dAmount_7.Enabled = False
            dAmount_6.Value = 0
            dAmount_7.Value = 0
            btnSave.Focus()
        End If
    End Sub

    Private Sub DAmount_6_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_6.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtp_7.Focus()
        End If
    End Sub

    Private Sub Dtp_7_KeyDown(sender As Object, e As KeyEventArgs) Handles dtp_7.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_7.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtp_7.CustomFormat = ""
            dAmount_7.Enabled = False
            dAmount_7.Value = 0
            btnSave.Focus()
        End If
    End Sub

    Private Sub DAmount_7_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_7.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpLiquidate.Focus()
        End If
    End Sub

    Private Sub DtpLiquidate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpLiquidate.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpPayroll.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpLiquidate.CustomFormat = ""
            dtpPayroll.CustomFormat = ""
            btnSave.Focus()
        End If
    End Sub

    Private Sub DtpPayroll_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpPayroll.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpLiquidate.CustomFormat = ""
            dtpPayroll.CustomFormat = ""
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
            Clear(False)
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
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        btnSave.Text = "&Save"
        cbxOther.Checked = False
        cbxOther.Enabled = True
        PanelEx10.Enabled = True
        cbxPayee.Enabled = True
        cbxPayee.SelectedValue = Empl_ID
        User_EmplID = 0
        Dept_Head = False
        dtpDate.Value = Date.Now
        dtpDate.Enabled = True
        dtp_1.Value = Date.Now
        dtp_1.CustomFormat = ""
        dtp_2.CustomFormat = ""
        dtp_3.CustomFormat = ""
        dtp_4.CustomFormat = ""
        dtp_5.CustomFormat = ""
        dtp_6.CustomFormat = ""
        dtp_7.CustomFormat = ""
        dtp_2.Enabled = False
        dtp_3.Enabled = False
        dtp_4.Enabled = False
        dtp_5.Enabled = False
        dtp_6.Enabled = False
        dtp_7.Enabled = False
        dAmount_1.Value = 0
        dAmount_2.Value = 0
        dAmount_3.Value = 0
        dAmount_4.Value = 0
        dAmount_5.Value = 0
        dAmount_6.Value = 0
        dAmount_7.Value = 0
        dAmount_1.Enabled = False
        dAmount_2.Enabled = False
        dAmount_3.Enabled = False
        dAmount_4.Enabled = False
        dAmount_5.Enabled = False
        dAmount_6.Enabled = False
        dAmount_7.Enabled = False
        dtpLiquidate.Value = Date.Now
        dtpPayroll.Value = Date.Now
        dtpDate_2.Value = Date.Now
        txtPurpose.Text = ""
        dMeal.Value = 0
        dTransportation.Value = 0
        dBIR.Value = 0
        dRD.Value = 0
        dLTO.Value = 0
        dNotarizationF.Value = 0
        dOthers.Value = 0
        btnPrint.Location = New Point(909, 4)
        SlipStatus = ""

        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnApprove.Visible = False
        btnApproveCrecomm.Visible = False
        btnReceive.Visible = False
        btnApprove.Enabled = False
        btnApproveCrecomm.Enabled = False
        btnReceive.Enabled = False
        btnEmailCrecom.Visible = False

        cbxPreparedBy.SelectedValue = Empl_ID
        txtApproved.Text = ""
        txtReceived.Text = ""
        txtReceivedDate.Text = ""
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

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxPayee.Text = "" Or cbxPayee.SelectedIndex = -1 Then
            MsgBox("Please select Payee.", MsgBoxStyle.Information, "Info")
            cbxPayee.DroppedDown = True
            Exit Sub
        End If
        If dtpDate.CustomFormat = "" Or Format(dtpDate.Value, "yyyy-MM-dd") = "0001-01-01" Then
            MsgBox("Please fill Document Date.", MsgBoxStyle.Information, "Info")
            dtpDate.Focus()
            Exit Sub
        End If
        If txtPurpose.Text = "" Then
            MsgBox("Please fill Purpose of Cash Advance.", MsgBoxStyle.Information, "Info")
            txtPurpose.Focus()
            Exit Sub
        End If
        If dTotal.Value = 0 Then
            MsgBox("Please fill Amount for Cash Advance.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxPreparedBy.Text = "" Or cbxPreparedBy.SelectedIndex = -1 Then
            MsgBox("Please select Prepared By.", MsgBoxStyle.Information, "Info")
            cbxPreparedBy.DroppedDown = True
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_Prep As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                'SEND EMAIL AND SMS TO SELECTED PAYEE *******************************************************************
                Dim Msg As String = ""
                Dim Subject As String = String.Format("Cash Advance Slip {0}.", txtAccountNumber.Text)
                If cbxPayee.SelectedValue <> Empl_ID Then
                    If MsgBoxYes(String.Format("You are creating a Cash Advance Slip for {0}, This will notify him/her through Email and SMS, would you like to proceed?", cbxPayee.Text)) = MsgBoxResult.Yes Then
                        Msg = String.Format("Good day {0}," & vbCrLf, cbxPayee.Text)
                        Msg &= String.Format("{0} create a new Cash Advance Slip under your name with a Total Amount of P{1}." & vbCrLf, Empl_Name, dTotal.Text)
                        Msg &= "Thank you!"
                        '******* SEND SMS *********************************************************************************
                        If drv("Phone") = "" Then
                        Else
                            SendSMS(drv("Phone"), Msg, False)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If drv("EmailAdd") = "" Then
                        Else
                            SendEmail(drv("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                        End If
                    Else
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                End If
                Code = GenerateOTAC()
                GetAccountNumber()
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    'SEND EMAIL AND SMS APPROVAL TO DEPARTMENT HEAD  *******************************************************************
                    Dim DT_Head As DataTable
                    Dim EmailTo As String = ""
                    Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    If drv("Head") = 0 Or Branch_ID > 0 Or drv("department_id") <> drv_Prep("department_id") Then
                        If Branch_ID = 0 Then
                            If cbxOther.Checked Then
                                DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = '{0}' AND Branch_ID IN ('{1}','{2}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", drv_Prep("department_id"), Branch_ID, MFBranch_ID))
                            Else
                                DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id IN ('{0}','{1}') AND Branch_ID IN ('{2}','{3}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", If(NotifyPayeeApprover, drv("department_id"), False), drv_Prep("department_id"), Branch_ID, MFBranch_ID))
                            End If
                            For x As Integer = 0 To DT_Head.Rows.Count - 1
                                Msg = String.Format("Good day," & vbCrLf, DT_Head(x)("Employee"))
                                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                Msg &= "Thank you!"
                                '******* SEND SMS *********************************************************************************
                                If DT_Head(x)("Phone") = "" Then
                                Else
                                    SendSMS(DT_Head(x)("Phone"), Msg, True)
                                End If
                                '******* SEND EMAIL *********************************************************************************
                                If DT_Head(x)("EmailAdd") = "" Then
                                Else
                                    EmailTo = EmailTo & DT_Head(x)("EmailAdd") & ", "
                                End If
                            Next
                        Else
                            If CashApprovalHierarchy Then
                                If cbxPayee.SelectedValue = Approver1ID Or cbxPreparedBy.SelectedValue = Approver1ID Then
                                    Msg = String.Format("Good day {0}," & vbCrLf, Approver2Name)
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> {4} of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text, SlipStatus)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If Approver2Phone = "" Then
                                    Else
                                        SendSMS(Approver2Phone, Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If Approver2Email = "" Then
                                    Else
                                        Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                        Generate_CA(False, FName)
                                        AttachmentFiles.Add(FName)
                                        SendEmail(Approver2Email, Subject, Msg, False, False, False, 0, "", "")
                                    End If
                                Else
                                    Msg = String.Format("Good day {0}," & vbCrLf, Approver1Name)
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> {4} of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text, SlipStatus)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If Approver1Phone = "" Then
                                    Else
                                        SendSMS(Approver1Phone, Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If Approver1Email = "" Then
                                    Else
                                        Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                        Generate_CA(False, FName)
                                        AttachmentFiles.Add(FName)
                                        SendEmail(Approver1Email, Subject, Msg, False, False, False, 0, "", "")
                                    End If
                                End If
                            Else
                                Dim BM As DataTable = GetBM(Branch_ID)
                                For x As Integer = 0 To BM.Rows.Count - 1
                                    Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee"))
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If BM(x)("Phone") = "" Then
                                    Else
                                        SendSMS(BM(x)("Phone"), Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If BM(x)("EmailAdd") = "" Then
                                    Else
                                        EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
                                    End If
                                Next
                            End If
                        End If
                    Else
                        If DT_CAS_Approver.Rows.Count > 0 Then
                            Msg = String.Format("Good day," & vbCrLf)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_CAS_Approver(0)("A1Phone") = "" Then
                            Else
                                SendSMS(DT_CAS_Approver(0)("A1Phone"), Msg, True)
                            End If
                            If DT_CAS_Approver(0)("A2Phone") = "" Then
                            Else
                                SendSMS(DT_CAS_Approver(0)("A2Phone"), Msg, True)
                            End If
                            If DT_CAS_Approver(0)("A3Phone") = "" Then
                            Else
                                SendSMS(DT_CAS_Approver(0)("A3Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_CAS_Approver(0)("A1Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_CAS_Approver(0)("A1Email") & ", "
                            End If
                            If DT_CAS_Approver(0)("A2Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_CAS_Approver(0)("A2Email") & ", "
                            End If
                            If DT_CAS_Approver(0)("A3Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_CAS_Approver(0)("A3Email") & ", "
                            End If
                        Else
                            Dim CreComm As New FrmCrecomList
                            With CreComm
                                .For_Signatory = True
                                Dim SQLV2 As String = "SELECT "
                                SQLV2 &= "      'False' AS 'Include',"
                                SQLV2 &= "      Employee(ID) AS 'Name',"
                                SQLV2 &= "      CONCAT('+63',Phone) AS 'Phone',"
                                SQLV2 &= "      EmailAdd AS 'Email Address', `Position` "
                                SQLV2 &= String.Format("  FROM employee_setup WHERE ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) AND Branch_ID IN ('{0}','{1}') AND `status` = 'ACTIVE' ORDER BY `Name` ;", Branch_ID, MFBranch_ID)
                                .GridControl1.DataSource = DataSource(SQLV2)
                                If .ShowDialog = DialogResult.OK Then
                                    Dim Email As String = ""
                                    Msg = String.Format("Good day," & vbCrLf)
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                    Msg &= "Thank you!"
                                    For x As Integer = 0 To CreComm.GridView1.RowCount - 1
                                        If CBool(CreComm.GridView1.GetRowCellValue(x, "Include")) = True Then
                                            Email &= CreComm.GridView1.GetRowCellValue(x, "Email Address") & ", "
                                        End If
                                    Next
                                    If Email = "" Then
                                    Else
                                        Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                                        AttachmentFiles = New ArrayList()
                                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                        Generate_CA(False, FName)
                                        AttachmentFiles.Add(FName)
                                        SendEmail(Email.Substring(0, Email.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                                        GoTo Here
                                    End If
                                Else
                                    Cursor = Cursors.Default
                                    Exit Sub
                                End If
                            End With
                        End If
                    End If
                    If EmailTo = "" Then
                    Else
                        Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                        AttachmentFiles = New ArrayList()
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        Generate_CA(False, FName)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
Here:
                Dim SQL As String = "INSERT INTO cash_advance SET"
                SQL &= String.Format(" Payee_ID = '{0}', ", cbxPayee.SelectedValue)
                SQL &= String.Format(" Trans_Date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" AccountNumber = '{0}', ", txtAccountNumber.Text)
                SQL &= String.Format(" Purpose = '{0}', ", txtPurpose.Text.Trim.InsertQuote)
                SQL &= String.Format(" Meals = '{0}', ", dMeal.Value)
                SQL &= String.Format(" Transportation = '{0}', ", dTransportation.Value)
                SQL &= String.Format(" BIR = '{0}', ", dBIR.Value)
                SQL &= String.Format(" RD = '{0}', ", dRD.Value)
                SQL &= String.Format(" LTO = '{0}', ", dLTO.Value)
                SQL &= String.Format(" Notarization = '{0}', ", dNotarizationF.Value)
                SQL &= String.Format(" Others = '{0}', ", dOthers.Value)
                SQL &= String.Format(" LiqDate_1 = '{0}', ", FormatDatePicker(dtp_1))
                SQL &= String.Format(" LiqAmount_1 = '{0}', ", dAmount_1.Value)
                SQL &= String.Format(" LiqDate_2 = '{0}', ", FormatDatePicker(dtp_2))
                SQL &= String.Format(" LiqAmount_2 = '{0}', ", dAmount_2.Value)
                SQL &= String.Format(" LiqDate_3 = '{0}', ", FormatDatePicker(dtp_3))
                SQL &= String.Format(" LiqAmount_3 = '{0}', ", dAmount_3.Value)
                SQL &= String.Format(" LiqDate_4 = '{0}', ", FormatDatePicker(dtp_4))
                SQL &= String.Format(" LiqAmount_4 = '{0}', ", dAmount_4.Value)
                SQL &= String.Format(" LiqDate_5 = '{0}', ", FormatDatePicker(dtp_5))
                SQL &= String.Format(" LiqAmount_5 = '{0}', ", dAmount_5.Value)
                SQL &= String.Format(" LiqDate_6 = '{0}', ", FormatDatePicker(dtp_6))
                SQL &= String.Format(" LiqAmount_6 = '{0}', ", dAmount_6.Value)
                SQL &= String.Format(" LiqDate_7 = '{0}', ", FormatDatePicker(dtp_7))
                SQL &= String.Format(" LiqAmount_7 = '{0}', ", dAmount_7.Value)
                SQL &= String.Format(" LiqDate = '{0}', ", FormatDatePicker(dtpLiquidate))
                SQL &= String.Format(" SalaryDate = '{0}', ", FormatDatePicker(dtpPayroll))
                SQL &= String.Format(" User_Code = '{0}', ", User_Code)
                SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                SQL &= String.Format(" Head_OTAC = '{0}', ", Code)
                SQL &= String.Format(" Approver1_OTAC = '{0}', ", Code)
                SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                SQL &= " ReceivedID = '0', "
                SQL &= " ReceivedDate = '', "
                SQL &= " ApprovedID = '0', "
                SQL &= String.Format(" FromOtherBranch = {0}, ", If(cbxOther.Checked, 1, 0))
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                DataObject(SQL)

                Logs("Cash Advance Slip", "Save", String.Format("Add new Cash Advance Slip for {0} with Amount {1}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text), "", "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!" & mEmail, MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM cash_advance WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
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
                    'SEND EMAIL AND SMS APPROVAL TO DEPARTMENT HEAD  *******************************************************************
                    Dim Msg As String = ""
                    Dim Subject As String = String.Format("Cash Advance Slip {0}.", txtAccountNumber.Text)
                    Dim DT_Head As DataTable
                    If txtApproved.Text = "" Then
                        Code = GenerateOTAC()
                        Dim EmailTo As String = ""
                        Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                        Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        If drv("Head") = 0 Or Branch_ID > 0 Then
                            If Branch_ID = 0 Then
                                If cbxOther.Checked Then
                                    DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department = '{0}' AND Branch_ID IN ('{1}','{2}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", drv_Prep("department_id"), Branch_ID, MFBranch_ID))
                                Else
                                    DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id IN ('{0}','{1}') AND Branch_ID IN ('{2}','{3}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", If(NotifyPayeeApprover, drv("department_id"), False), drv_Prep("department_id"), Branch_ID, MFBranch_ID))
                                End If
                                For x As Integer = 0 To DT_Head.Rows.Count - 1
                                    Msg = String.Format("Good day," & vbCrLf, DT_Head(x)("Employee"))
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head approval of Updated Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                    Msg &= "Thank you!"
                                    '******* SEND SMS *********************************************************************************
                                    If DT_Head(x)("Phone") = "" Then
                                    Else
                                        SendSMS(DT_Head(x)("Phone"), Msg, True)
                                    End If
                                    '******* SEND EMAIL *********************************************************************************
                                    If DT_Head(x)("EmailAdd") = "" Then
                                    Else
                                        EmailTo = EmailTo & DT_Head(x)("EmailAdd") & ", "
                                    End If
                                Next
                            Else
                                If CashApprovalHierarchy Then
                                    Msg = String.Format("Good day {0}," & vbCrLf, Approver1Name)
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> {4} of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text, SlipStatus)
                                    Msg &= "Thank you!"
                                    If cbxPayee.SelectedValue = Approver1ID Or cbxPreparedBy.SelectedValue = Approver1ID Then
                                        '******* SEND SMS *********************************************************************************
                                        If Approver2Phone = "" Then
                                        Else
                                            SendSMS(Approver2Phone, Msg, True)
                                        End If
                                        '******* SEND EMAIL *********************************************************************************
                                        If Approver2Email = "" Then
                                        Else
                                            Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                            Generate_CA(False, FName)
                                            AttachmentFiles.Add(FName)
                                            SendEmail(Approver2Email, Subject, Msg, False, False, False, 0, "", "")
                                        End If
                                    Else
                                        '******* SEND SMS *********************************************************************************
                                        If Approver1Phone = "" Then
                                        Else
                                            SendSMS(Approver1Phone, Msg, True)
                                        End If
                                        '******* SEND EMAIL *********************************************************************************
                                        If Approver1Email = "" Then
                                        Else
                                            Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                            Generate_CA(False, FName)
                                            AttachmentFiles.Add(FName)
                                            SendEmail(Approver1Email, Subject, Msg, False, False, False, 0, "", "")
                                        End If
                                    End If
                                Else
                                    Dim BM As DataTable = GetBM(Branch_ID)
                                    For x As Integer = 0 To BM.Rows.Count - 1
                                        Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee"))
                                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head approval of Updated Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                        Msg &= "Thank you!"
                                        '******* SEND SMS *********************************************************************************
                                        If BM(x)("Phone") = "" Then
                                        Else
                                            SendSMS(BM(x)("Phone"), Msg, True)
                                        End If
                                        '******* SEND EMAIL *********************************************************************************
                                        If BM(x)("EmailAdd") = "" Then
                                        Else
                                            EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
                                        End If
                                    Next
                                End If
                            End If
                        Else
                            If DT_CAS_Approver.Rows.Count > 0 Then
                                Msg = String.Format("Good day," & vbCrLf)
                                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                Msg &= "Thank you!"
                                '******* SEND SMS *********************************************************************************
                                If DT_CAS_Approver(0)("A1Phone") = "" Then
                                Else
                                    SendSMS(DT_CAS_Approver(0)("A1Phone"), Msg, True)
                                End If
                                If DT_CAS_Approver(0)("A2Phone") = "" Then
                                Else
                                    SendSMS(DT_CAS_Approver(0)("A2Phone"), Msg, True)
                                End If
                                If DT_CAS_Approver(0)("A3Phone") = "" Then
                                Else
                                    SendSMS(DT_CAS_Approver(0)("A3Phone"), Msg, True)
                                End If
                                '******* SEND EMAIL *********************************************************************************
                                If DT_CAS_Approver(0)("A1Email") = "" Then
                                Else
                                    EmailTo = EmailTo & DT_CAS_Approver(0)("A1Email") & ", "
                                End If
                                If DT_CAS_Approver(0)("A2Email") = "" Then
                                Else
                                    EmailTo = EmailTo & DT_CAS_Approver(0)("A2Email") & ", "
                                End If
                                If DT_CAS_Approver(0)("A3Email") = "" Then
                                Else
                                    EmailTo = EmailTo & DT_CAS_Approver(0)("A3Email") & ", "
                                End If
                            Else
                                Dim CreComm As New FrmCrecomList
                                With CreComm
                                    .For_Signatory = True
                                    Dim SQLV2 As String = "SELECT "
                                    SQLV2 &= "      'False' AS 'Include',"
                                    SQLV2 &= "      Employee(ID) AS 'Name',"
                                    SQLV2 &= "      CONCAT('+63',Phone) AS 'Phone',"
                                    SQLV2 &= "      EmailAdd AS 'Email Address', `Position` "
                                    SQLV2 &= String.Format("  FROM employee_setup WHERE ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) AND Branch_ID IN ('{0}','{1}') AND `status` = 'ACTIVE' ORDER BY `Name` ;", Branch_ID, MFBranch_ID)
                                    .GridControl1.DataSource = DataSource(SQLV2)
                                    If .ShowDialog = DialogResult.OK Then
                                        Dim Email As String = ""
                                        Msg = String.Format("Good day," & vbCrLf)
                                        Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Updated Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                        Msg &= "Thank you!"
                                        For x As Integer = 0 To CreComm.GridView1.RowCount - 1
                                            If CBool(CreComm.GridView1.GetRowCellValue(x, "Include")) = True Then
                                                Email &= CreComm.GridView1.GetRowCellValue(x, "Email Address") & ", "
                                            End If
                                        Next
                                        If Email = "" Then
                                        Else
                                            Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "] [UPDATE]"
                                            AttachmentFiles = New ArrayList()
                                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                            Generate_CA(False, FName)
                                            AttachmentFiles.Add(FName)
                                            SendEmail(Email.Substring(0, Email.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                                            GoTo HereV2
                                        End If
                                    Else
                                        Cursor = Cursors.Default
                                        Exit Sub
                                    End If
                                End With
                            End If
                        End If
                        If EmailTo = "" Then
                        Else
                            Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "] [UPDATE]"
                            AttachmentFiles = New ArrayList()
                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            Generate_CA(False, FName)
                            AttachmentFiles.Add(FName)
                            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                        End If
                    End If
                End If
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
HereV2:

                Dim SQL As String = "UPDATE cash_advance SET"
                SQL &= String.Format(" Trans_Date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" Purpose = '{0}', ", txtPurpose.Text.Trim.InsertQuote)
                SQL &= String.Format(" Meals = '{0}', ", dMeal.Value)
                SQL &= String.Format(" Transportation = '{0}', ", dTransportation.Value)
                SQL &= String.Format(" BIR = '{0}', ", dBIR.Value)
                SQL &= String.Format(" RD = '{0}', ", dRD.Value)
                SQL &= String.Format(" LTO = '{0}', ", dLTO.Value)
                SQL &= String.Format(" Notarization = '{0}', ", dNotarizationF.Value)
                SQL &= String.Format(" Others = '{0}', ", dOthers.Value)
                SQL &= String.Format(" LiqDate_1 = '{0}', ", FormatDatePicker(dtp_1))
                SQL &= String.Format(" LiqAmount_1 = '{0}', ", dAmount_1.Value)
                SQL &= String.Format(" LiqDate_2 = '{0}', ", FormatDatePicker(dtp_2))
                SQL &= String.Format(" LiqAmount_2 = '{0}', ", dAmount_2.Value)
                SQL &= String.Format(" LiqDate_3 = '{0}', ", FormatDatePicker(dtp_3))
                SQL &= String.Format(" LiqAmount_3 = '{0}', ", dAmount_3.Value)
                SQL &= String.Format(" LiqDate_4 = '{0}', ", FormatDatePicker(dtp_4))
                SQL &= String.Format(" LiqAmount_4 = '{0}', ", dAmount_4.Value)
                SQL &= String.Format(" LiqDate_5 = '{0}', ", FormatDatePicker(dtp_5))
                SQL &= String.Format(" LiqAmount_5 = '{0}', ", dAmount_5.Value)
                SQL &= String.Format(" LiqDate_6 = '{0}', ", FormatDatePicker(dtp_6))
                SQL &= String.Format(" LiqAmount_6 = '{0}', ", dAmount_6.Value)
                SQL &= String.Format(" LiqDate_7 = '{0}', ", FormatDatePicker(dtp_7))
                SQL &= String.Format(" LiqAmount_7 = '{0}', ", dAmount_7.Value)
                SQL &= String.Format(" LiqDate = '{0}', ", FormatDatePicker(dtpLiquidate))
                If txtApproved.Text = "" Then
                    SQL &= String.Format(" Head_OTAC = '{0}', ", Code)
                End If
                SQL &= String.Format(" SalaryDate = '{0}' ", FormatDatePicker(dtpPayroll))
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)

                Logs("Cash Advance Slip", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If dtpDate.Text = dtpDate.Tag Then
            Else
                Change &= String.Format("Change Date from {0} to {1}. ", dtpDate.Tag, dtpDate.Text)
            End If
            If txtPurpose.Text = txtPurpose.Tag Then
            Else
                Change &= String.Format("Change Purpose from {0} to {1}. ", txtPurpose.Tag.ToString.Trim.InsertQuote, txtPurpose.Text.Trim.InsertQuote)
            End If
            If dMeal.Value = dMeal.Tag Then
            Else
                Change &= String.Format("Change Meals from {0} to {1}. ", dMeal.Tag, dMeal.Text)
            End If
            If dTransportation.Value = dTransportation.Tag Then
            Else
                Change &= String.Format("Change Transportation from {0} to {1}. ", dTransportation.Tag, dTransportation.Text)
            End If
            If dBIR.Value = dBIR.Tag Then
            Else
                Change &= String.Format("Change BIR from {0} to {1}. ", dBIR.Tag, dBIR.Text)
            End If
            If dRD.Value = dRD.Tag Then
            Else
                Change &= String.Format("Change RD from {0} to {1}. ", dRD.Tag, dRD.Text)
            End If
            If dLTO.Value = dLTO.Tag Then
            Else
                Change &= String.Format("Change LTO from {0} to {1}. ", dLTO.Tag, dLTO.Text)
            End If
            If dNotarizationF.Value = dNotarizationF.Tag Then
            Else
                Change &= String.Format("Change Notarization Fee from {0} to {1}. ", dNotarizationF.Tag, dNotarizationF.Text)
            End If
            If dOthers.Value = dOthers.Tag Then
            Else
                Change &= String.Format("Change Others from {0} to {1}. ", dOthers.Tag, dOthers.Text)
            End If
            If dtp_1.Text = dtp_1.Tag Then
            Else
                Change &= String.Format("Change Date 1 from {0} to {1}. ", dtp_1.Tag, dtp_1.Text)
            End If
            If dAmount_1.Value = dAmount_1.Tag Then
            Else
                Change &= String.Format("Change Amount 1 from {0} to {1}. ", dAmount_1.Tag, dAmount_1.Text)
            End If
            If dtp_2.Text = dtp_2.Tag Then
            Else
                Change &= String.Format("Change Date 2 from {0} to {1}. ", dtp_2.Tag, dtp_2.Text)
            End If
            If dAmount_2.Value = dAmount_2.Tag Then
            Else
                Change &= String.Format("Change Amount 2 from {0} to {1}. ", dAmount_2.Tag, dAmount_2.Text)
            End If
            If dtp_3.Text = dtp_3.Tag Then
            Else
                Change &= String.Format("Change Date 3 from {0} to {1}. ", dtp_3.Tag, dtp_3.Text)
            End If
            If dAmount_3.Value = dAmount_3.Tag Then
            Else
                Change &= String.Format("Change Amount 3 from {0} to {1}. ", dAmount_3.Tag, dAmount_3.Text)
            End If
            If dtp_4.Text = dtp_4.Tag Then
            Else
                Change &= String.Format("Change Date 4 from {0} to {1}. ", dtp_4.Tag, dtp_4.Text)
            End If
            If dAmount_4.Value = dAmount_4.Tag Then
            Else
                Change &= String.Format("Change Amount 4 from {0} to {1}. ", dAmount_4.Tag, dAmount_4.Text)
            End If
            If dtp_5.Text = dtp_5.Tag Then
            Else
                Change &= String.Format("Change Date 5 from {0} to {1}. ", dtp_5.Tag, dtp_5.Text)
            End If
            If dAmount_5.Value = dAmount_5.Tag Then
            Else
                Change &= String.Format("Change Amount 5 from {0} to {1}. ", dAmount_5.Tag, dAmount_5.Text)
            End If
            If dtp_6.Text = dtp_6.Tag Then
            Else
                Change &= String.Format("Change Date 6 from {0} to {1}. ", dtp_6.Tag, dtp_6.Text)
            End If
            If dAmount_6.Value = dAmount_6.Tag Then
            Else
                Change &= String.Format("Change Amount 6 from {0} to {1}. ", dAmount_6.Tag, dAmount_6.Text)
            End If
            If dtp_7.Text = dtp_7.Tag Then
            Else
                Change &= String.Format("Change Date 7 from {0} to {1}. ", dtp_7.Tag, dtp_7.Text)
            End If
            If dAmount_7.Value = dAmount_7.Tag Then
            Else
                Change &= String.Format("Change Amount 7 from {0} to {1}. ", dAmount_7.Tag, dAmount_7.Text)
            End If
            If dtpLiquidate.Text = dtpLiquidate.Tag Then
            Else
                Change &= String.Format("Change Liquidate Date from {0} to {1}. ", dtpLiquidate.Tag, dtpLiquidate.Text)
            End If
            If dtpPayroll.Text = dtpPayroll.Tag Then
            Else
                Change &= String.Format("Change Salary Date from {0} to {1}. ", dtpPayroll.Tag, dtpPayroll.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Cash Advance Slip - Changes", ex.Message.ToString)
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
            Dim CV As String = DataObject(String.Format("SELECT DocumentNumber FROM check_voucher WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND Voucher_Status IN ('PENDING','CHECKED','APPROVED','RECEIVED') AND JVNumber = '' LIMIT 1;", txtAccountNumber.Text))
            If CV = "" Then
            Else
                MsgBox(String.Format("Cash Advance already have a CHECK VOUCHER with document number {0}. Please CANCEL or JOURNAL VOUCHER the existing CHECK VOUCHER first.", CV), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            DataObject(String.Format("UPDATE cash_advance SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID))
            Logs("Cash Advance Slip", "Cancel", Reason, String.Format("Cancel Cash Advance of {0} with Amount {1}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Generate_CA(Show As Boolean, FName As String)
        Dim Report As New RptCashAdvanceSlip
        With Report
            .Name = String.Format("Cash Advance Slip of {0} - {1}", txtName.Text, txtAccountNumber.Text)

            .lblPayee.Text = cbxPayee.Text
            .lblDate.Text = dtpDate.Text
            .lblAccountNumber.Text = txtAccountNumber.Text
            .lblPurpose.Text = txtPurpose.Text
            .lblMeals.Text = dMeal.Text
            .lblTransportation.Text = dTransportation.Text
            .lblBIR.Text = dBIR.Text
            .lblRD.Text = dRD.Text
            .lblLTO.Text = dLTO.Text
            .lblNotarizationF.Text = dNotarizationF.Text
            .lblOthers.Text = dOthers.Text
            .lblTotal.Text = dTotal.Text

            .lblDate_1.Text = If(dtp_1.CustomFormat = "", "", Format(dtp_1.Value, "MMMM dd, yyyy"))
            .lblAmount_1.Text = dAmount_1.Text
            .lblDate_2.Text = If(dtp_2.CustomFormat = "", "", Format(dtp_2.Value, "MMMM dd, yyyy"))
            .lblAmount_2.Text = dAmount_2.Text
            .lblDate_3.Text = If(dtp_3.CustomFormat = "", "", Format(dtp_3.Value, "MMMM dd, yyyy"))
            .lblAmount_3.Text = dAmount_3.Text
            .lblDate_4.Text = If(dtp_4.CustomFormat = "", "", Format(dtp_4.Value, "MMMM dd, yyyy"))
            .lblAmount_4.Text = dAmount_4.Text
            .lblDate_5.Text = If(dtp_5.CustomFormat = "", "", Format(dtp_5.Value, "MMMM dd, yyyy"))
            .lblAmount_5.Text = dAmount_5.Text
            .lblDate_6.Text = If(dtp_6.CustomFormat = "", "", Format(dtp_6.Value, "MMMM dd, yyyy"))
            .lblAmount_6.Text = dAmount_6.Text
            .lblDate_7.Text = If(dtp_7.CustomFormat = "", "", Format(dtp_7.Value, "MMMM dd, yyyy"))
            .lblAmount_7.Text = dAmount_7.Text
            .lblTotalLiquidate.Text = dTotalLiquidation.Text

            .lblHereby.Text = String.Format("I hereby promise to liquidate this cash advance within 7 days from receipt, specifically on {0}. If I fail to liquidate this in full on or before the said date, I am aware that the balances will be deducted by the accouting department in full from my salary on {1}.", If(dtpLiquidate.CustomFormat = "", "_____________________", dtpLiquidate.Text), If(dtpPayroll.CustomFormat = "", "_____________________", dtpPayroll.Text))
            .lblDate2.Text = Format(dtpDate_2.Value, "MMM dd, yyyy")
            .lblName.Text = txtName.Text

            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblApprovedBy.Text = txtApproved.Text
            .lblReceivedBy.Text = txtReceived.Text
            .lblReceivedDate.Text = txtReceivedDate.Text

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
            Generate_CA(True, "")
            Logs("Cash Advance", "Print", "[SENSITIVE] Print Cash Advance " & txtAccountNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("CASH ADVANCE LIST", GridControl1)

            Dim Report As New RptPettyCashList
            With Report
                If cbxDisplay.SelectedIndex = 0 Then
                    .lblAsOf.Text = "For " & Format(dtpFrom.Value, "MMMM dd, yyyy")
                ElseIf cbxDisplay.SelectedIndex = 2 Then
                    .lblAsOf.Text = "For the month of " & Format(dtpFrom.Value, "MMMM, yyyy")
                Else
                    .lblAsOf.Text = If(cbxAll.Checked, "As of " & Format(Date.Now, "MMMM dd, yyyy"), "From " & Format(dtpFrom.Value, "MMMM dd, yyyy") & " to " & Format(dtpTo.Value, "MMMM dd, yyyy"))
                End If
                .Name = String.Format("Petty Cash Voucher List of {0} - {1}", Branch, .lblAsOf.Text)
                .XrLabel1.Text = "CASH ADVANCE LIST"

                .DataSource = GridControl1.DataSource
                .lblNo.DataBindings.Add("Text", GridControl1.DataSource, "No")
                .lblPayee.DataBindings.Add("Text", GridControl1.DataSource, "Payee")
                .lblDate.DataBindings.Add("Text", GridControl1.DataSource, "Date")
                .lblDocument.DataBindings.Add("Text", GridControl1.DataSource, "Account Number")
                .lblPurpose.DataBindings.Add("Text", GridControl1.DataSource, "Purpose")
                .lblTotal.DataBindings.Add("Text", GridControl1.DataSource, "Total")
                .lblTotalT.DataBindings.Add("Text", GridControl1.DataSource, "Total")
                .lblStatus.DataBindings.Add("Text", GridControl1.DataSource, "Voucher_Status")
                .lblPrepared.DataBindings.Add("Text", GridControl1.DataSource, "Prepared By")
                .lblApproved.DataBindings.Add("Text", GridControl1.DataSource, "Approved By")
                .ShowPreview()
            End With
            Logs("Cash Advance", "Print", "[SENSITIVE] Print Cash Advance List", "", "", "", "")
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or fromLoe AndAlso e.KeyCode = Keys.Escape Then
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
        ElseIf e.Control And e.KeyCode = Keys.R Then
            If cbxPayee.Enabled Then
                If DepartmentalView Then
                    DepartmentalView = False
                Else
                    DepartmentalView = True
                End If
                LoadPayee()
                MsgBox(String.Format("Departmental View is now {0}", If(DepartmentalView, "activated", "deactivated")), MsgBoxStyle.Information, "Info")
            End If
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
            dtpDate.Enabled = False
            cbxPayee.Enabled = False
            cbxOther.Enabled = False
            If .GetFocusedRowCellValue("FromOtherBranch") = True Then
                cbxOther.Checked = True
            Else
                cbxOther.Checked = False
            End If
            cbxPayee.Text = .GetFocusedRowCellValue("Payee")
            dtpDate.Value = .GetFocusedRowCellValue("Date")
            dtpDate.Tag = .GetFocusedRowCellValue("Date")
            txtAccountNumber.Text = .GetFocusedRowCellValue("Account Number")
            txtPurpose.Text = .GetFocusedRowCellValue("Purpose")
            txtPurpose.Tag = .GetFocusedRowCellValue("Purpose")
            dMeal.Value = .GetFocusedRowCellValue("Meals")
            dMeal.Tag = .GetFocusedRowCellValue("Meals")
            dTransportation.Value = .GetFocusedRowCellValue("Transportation")
            dTransportation.Tag = .GetFocusedRowCellValue("Transportation")
            dBIR.Value = .GetFocusedRowCellValue("BIR")
            dBIR.Tag = .GetFocusedRowCellValue("BIR")
            dRD.Value = .GetFocusedRowCellValue("RD")
            dRD.Tag = .GetFocusedRowCellValue("RD")
            dLTO.Value = .GetFocusedRowCellValue("LTO")
            dLTO.Tag = .GetFocusedRowCellValue("LTO")
            dNotarizationF.Value = .GetFocusedRowCellValue("Notarization")
            dNotarizationF.Tag = .GetFocusedRowCellValue("Notarization")
            dOthers.Value = .GetFocusedRowCellValue("Others")
            dOthers.Tag = .GetFocusedRowCellValue("Others")
            If .GetFocusedRowCellValue("Date 1").ToString = "" Then
                dtp_1.CustomFormat = ""
            Else
                dtp_1.CustomFormat = "MMMM dd, yyyy"
                dtp_1.Value = .GetFocusedRowCellValue("Date 1").ToString
            End If
            dtp_1.Tag = .GetFocusedRowCellValue("Date 1").ToString
            dAmount_1.Value = .GetFocusedRowCellValue("Amount 1")
            dAmount_1.Tag = .GetFocusedRowCellValue("Amount 1")
            If .GetFocusedRowCellValue("Date 2").ToString = "" Then
                dtp_2.CustomFormat = ""
            Else
                dtp_2.CustomFormat = "MMMM dd, yyyy"
                dtp_2.Value = .GetFocusedRowCellValue("Date 2")
            End If
            dtp_2.Tag = .GetFocusedRowCellValue("Date 2").ToString
            dAmount_2.Value = .GetFocusedRowCellValue("Amount 2")
            dAmount_2.Tag = .GetFocusedRowCellValue("Amount 2")
            If .GetFocusedRowCellValue("Date 3").ToString = "" Then
                dtp_3.CustomFormat = ""
            Else
                dtp_3.CustomFormat = "MMMM dd, yyyy"
                dtp_3.Value = .GetFocusedRowCellValue("Date 3")
            End If
            dtp_3.Tag = .GetFocusedRowCellValue("Date 3").ToString
            dAmount_3.Value = .GetFocusedRowCellValue("Amount 3")
            dAmount_3.Tag = .GetFocusedRowCellValue("Amount 3")
            If .GetFocusedRowCellValue("Date 4").ToString = "" Then
                dtp_4.CustomFormat = ""
            Else
                dtp_4.CustomFormat = "MMMM dd, yyyy"
                dtp_4.Value = .GetFocusedRowCellValue("Date 4")
            End If
            dtp_4.Tag = .GetFocusedRowCellValue("Date 4").ToString
            dAmount_4.Value = .GetFocusedRowCellValue("Amount 4")
            dAmount_4.Tag = .GetFocusedRowCellValue("Amount 4")
            If .GetFocusedRowCellValue("Date 5").ToString = "" Then
                dtp_5.CustomFormat = ""
            Else
                dtp_5.CustomFormat = "MMMM dd, yyyy"
                dtp_5.Value = .GetFocusedRowCellValue("Date 5")
            End If
            dtp_5.Tag = .GetFocusedRowCellValue("Date 5").ToString
            dAmount_5.Value = .GetFocusedRowCellValue("Amount 5")
            dAmount_5.Tag = .GetFocusedRowCellValue("Amount 5")
            If .GetFocusedRowCellValue("Date 6").ToString = "" Then
                dtp_6.CustomFormat = ""
            Else
                dtp_6.CustomFormat = "MMMM dd, yyyy"
                dtp_6.Value = .GetFocusedRowCellValue("Date 6")
            End If
            dtp_6.Tag = .GetFocusedRowCellValue("Date 6").ToString
            dAmount_6.Value = .GetFocusedRowCellValue("Amount 6")
            dAmount_6.Tag = .GetFocusedRowCellValue("Amount 6")
            If .GetFocusedRowCellValue("Date 7").ToString = "" Then
                dtp_7.CustomFormat = ""
            Else
                dtp_7.CustomFormat = "MMMM dd, yyyy"
                dtp_7.Value = .GetFocusedRowCellValue("Date 7")
            End If
            dtp_7.Tag = .GetFocusedRowCellValue("Date 7").ToString
            dAmount_7.Value = .GetFocusedRowCellValue("Amount 7")
            dAmount_7.Tag = .GetFocusedRowCellValue("Amount 7")
            If .GetFocusedRowCellValue("Liquidation Date").ToString = "" Then
                dtpLiquidate.CustomFormat = ""
                dtpLiquidate.Tag = .GetFocusedRowCellValue("Liquidation Date").ToString
            Else
                dtpLiquidate.CustomFormat = "MMMM dd, yyyy"
            End If
            dtpLiquidate.Tag = .GetFocusedRowCellValue("Liquidation Date").ToString
            If .GetFocusedRowCellValue("Salary Date").ToString = "" Then
                dtpPayroll.CustomFormat = ""
            Else
                dtpPayroll.CustomFormat = "MMMM dd, yyyy"
                dtpPayroll.Value = .GetFocusedRowCellValue("Salary Date")
            End If
            dtpPayroll.Tag = .GetFocusedRowCellValue("Salary Date").ToString
            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")

            txtApproved.Text = .GetFocusedRowCellValue("Approved By")
            txtReceived.Text = .GetFocusedRowCellValue("Received By")
            txtReceivedDate.Text = .GetFocusedRowCellValue("Received Date")

            User_EmplID = .GetFocusedRowCellValue("User_EmplID")
            Code = .GetFocusedRowCellValue("Head_OTAC")
            Approver1_OTAC = .GetFocusedRowCellValue("Approver1_OTAC")
            Approver2_OTAC = .GetFocusedRowCellValue("Approver2_OTAC")
            Approver3_OTAC = .GetFocusedRowCellValue("Approver3_OTAC")
            Approver4_OTAC = .GetFocusedRowCellValue("Approver4_OTAC")
            Approver5_OTAC = .GetFocusedRowCellValue("Approver5_OTAC")
            SlipStatus = .GetFocusedRowCellValue("Slip_Status")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_P As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
        If cbxPayee.SelectedIndex = -1 Then
        Else
            Dept_Head = DataObject(String.Format("SELECT IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) FROM employee_setup WHERE ID = '{0}' AND Branch_ID IN ('{1}','{4}') AND IF(Department_ID = 0,TRUE,Department_ID IN ('{2}','{3}'));", Empl_ID, GridView1.GetFocusedRowCellValue("Branch_ID"), If(NotifyPayeeApprover, drv("department_ID"), False), drv_P("department_ID"), MFBranch_ID))
        End If
        If GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR HEAD APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status").ToString.Contains("FOR LEVEL") Then
            btnApprove.Visible = True
            If User_Type = "ADMIN" Or Department.ToUpper.Contains("ADMINISTRATIVE") Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Or Dept_Head Or ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or CheckApprover() Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A3ID"), 0) = Empl_ID Then
                btnModify.Enabled = True
                If User_Type = "ADMIN" Or Department.ToUpper.Contains("ADMINISTRATIVE") Or Dept_Head Or ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or CheckApprover() Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A3ID"), 0) = Empl_ID Then
                    If GridView1.GetFocusedRowCellValue("Payee_ID") > 0 And Branch_ID = 0 Then
                        Dim Head As Boolean = DataObject(String.Format("SELECT Head FROM position_setup WHERE ID = (SELECT position_id FROM employee_setup WHERE ID = {0});", GridView1.GetFocusedRowCellValue("Payee_ID")))
                        If Head = False And drv("department_ID") <> Dept_ID Then
                            If Department.ToUpper.Contains("ADMINISTRATIVE") Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Or CheckApprover() Or (If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A3ID"), 0) = Empl_ID) Then
                                btnApprove.Enabled = True
                            Else
                                btnApprove.Enabled = False
                            End If
                        Else
                            btnApprove.Enabled = True
                        End If
                    Else
                        btnApprove.Enabled = True
                    End If
                    If Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Then
                        btnDisapprove.Visible = False
                    Else
                        btnDisapprove.Visible = True
                        btnDisapprove.BringToFront()
                    End If
                End If
            End If
            btnApprove.BringToFront()
        ElseIf (GridView1.GetFocusedRowCellValue("Slip_Status") = "APPROVED HEAD" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR DISBURSEMENT") And (CDbl(GridView1.GetFocusedRowCellValue("Meals")) + CDbl(GridView1.GetFocusedRowCellValue("Transportation")) + CDbl(GridView1.GetFocusedRowCellValue("BIR")) + CDbl(GridView1.GetFocusedRowCellValue("RD")) + CDbl(GridView1.GetFocusedRowCellValue("LTO")) + CDbl(GridView1.GetFocusedRowCellValue("Notarization")) + CDbl(GridView1.GetFocusedRowCellValue("Others"))) <= 1000 Then
            If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Or ComparePosition({"LOANS PROCESSOR", "CASHIER", "CLIENT SOLUTIONS SPECIALIST", "ACCOUNTS MONITORING"}, False) Or Department.ToUpper.Contains("CREDIT AND COLLECTION") Or Department.ToUpper.Contains("ADMINISTRATIVE") Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Then
                btnReceive.Enabled = True
                btnReceive.Visible = True
                If Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Then
                    btnDelete.BringToFront()
                    btnDelete.Enabled = True
                    btnDelete.Visible = True
                Else
                    btnDelete.BringToFront()
                    btnDelete.Enabled = True
                    btnDelete.Visible = True
                End If
            End If
            btnModify.Enabled = False
            btnReceive.BringToFront()
        ElseIf (GridView1.GetFocusedRowCellValue("Slip_Status") = "APPROVED HEAD" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR CREDIT COMMITTEE APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR DISBURSEMENT") Then
            If (User_Type = "ADMIN" Or Dept_Head Or ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or CheckApprover()) And (CDbl(GridView1.GetFocusedRowCellValue("Meals")) + CDbl(GridView1.GetFocusedRowCellValue("Transportation")) + CDbl(GridView1.GetFocusedRowCellValue("BIR")) + CDbl(GridView1.GetFocusedRowCellValue("RD")) + CDbl(GridView1.GetFocusedRowCellValue("LTO")) + CDbl(GridView1.GetFocusedRowCellValue("Notarization")) + CDbl(GridView1.GetFocusedRowCellValue("Others"))) > 1000 Then
                btnApproveCrecomm.Enabled = True
                btnApproveCrecomm.Visible = True
                btnDisapprove.Visible = True
                btnDisapprove.BringToFront()
                btnPrint.Location = New Point(683, 4)
                btnPrint.BringToFront()
                btnEmailCrecom.Visible = True
            End If
            If (User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Or ComparePosition({"LOANS PROCESSOR", "CASHIER", "CLIENT SOLUTIONS SPECIALIST", "ACCOUNTS MONITORING"}, False) Or Department.ToUpper.Contains("CREDIT AND COLLECTION") Or Department.ToUpper.Contains("ADMINISTRATIVE")) And (CDbl(GridView1.GetFocusedRowCellValue("Meals")) + CDbl(GridView1.GetFocusedRowCellValue("Transportation")) + CDbl(GridView1.GetFocusedRowCellValue("BIR")) + CDbl(GridView1.GetFocusedRowCellValue("RD")) + CDbl(GridView1.GetFocusedRowCellValue("LTO")) + CDbl(GridView1.GetFocusedRowCellValue("Notarization")) + CDbl(GridView1.GetFocusedRowCellValue("Others"))) <= 1000 Then
                btnReceive.Enabled = True
                btnReceive.Visible = True
                btnDisapprove.Visible = True
                btnReceive.BringToFront()
            End If
            If Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Then
                btnDelete.BringToFront()
                btnDelete.Enabled = True
                btnDelete.Visible = True
            Else
                btnDelete.BringToFront()
                btnDelete.Enabled = True
                btnDelete.Visible = True
            End If
            btnModify.Enabled = False
            btnApproveCrecomm.BringToFront()
        ElseIf (GridView1.GetFocusedRowCellValue("Slip_Status") = "APPROVED") And (CDbl(GridView1.GetFocusedRowCellValue("Meals")) + CDbl(GridView1.GetFocusedRowCellValue("Transportation")) + CDbl(GridView1.GetFocusedRowCellValue("BIR")) + CDbl(GridView1.GetFocusedRowCellValue("RD")) + CDbl(GridView1.GetFocusedRowCellValue("LTO")) + CDbl(GridView1.GetFocusedRowCellValue("Notarization")) + CDbl(GridView1.GetFocusedRowCellValue("Others"))) <= 1000 Then
            If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Or ComparePosition({"LOANS PROCESSOR", "CASHIER", "CLIENT SOLUTIONS SPECIALIST", "ACCOUNTS MONITORING"}, False) Or Department.ToUpper.Contains("CREDIT AND COLLECTION") Or Department.ToUpper.Contains("ADMINISTRATIVE") Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Then
                btnReceive.Enabled = True
                btnReceive.Visible = True
                If Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Then
                    btnDelete.BringToFront()
                    btnDelete.Enabled = True
                    btnDelete.Visible = True
                Else
                    btnDelete.BringToFront()
                    btnDelete.Enabled = True
                    btnDelete.Visible = True
                End If
            End If
            btnModify.Enabled = False
            btnReceive.BringToFront()
        ElseIf ((GridView1.GetFocusedRowCellValue("Slip_Status") = "RECEIVED" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "RECEIVED ACTG" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR LIQUIDATION") And (GridView1.GetFocusedRowCellValue("CV_ID") = 0 Or (CDbl(GridView1.GetFocusedRowCellValue("Meals")) + CDbl(GridView1.GetFocusedRowCellValue("Transportation")) + CDbl(GridView1.GetFocusedRowCellValue("BIR")) + CDbl(GridView1.GetFocusedRowCellValue("RD")) + CDbl(GridView1.GetFocusedRowCellValue("LTO")) + CDbl(GridView1.GetFocusedRowCellValue("Notarization")) + CDbl(GridView1.GetFocusedRowCellValue("Others"))) <= 1000)) Or GridView1.GetFocusedRowCellValue("Slip_Status") = "APPROVED" Then
            If User_Type = "ADMIN" Or CompareDepartment({"FINANCE"}, False) Or ComparePosition({"CASHIER", "CLIENT SOLUTIONS SPECIALIST", "ACCOUNTS MONITORING"}, False) Or Department.ToUpper.Contains("CREDIT AND COLLECTION") Or Department.ToUpper.Contains("ADMINISTRATIVE") Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Then
                If Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Then
                    btnDelete.BringToFront()
                    btnDelete.Enabled = True
                    btnDelete.Visible = True
                Else
                    btnDelete.BringToFront()
                    btnDelete.Enabled = True
                    btnDelete.Visible = True
                End If
            End If
            btnApprove.Visible = False
            btnApproveCrecomm.Visible = False
            btnReceive.Visible = False
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

    Private Sub Amount_ValueChanged(sender As Object, e As EventArgs) Handles dMeal.ValueChanged, dTransportation.ValueChanged, dBIR.ValueChanged, dRD.ValueChanged, dLTO.ValueChanged, dNotarizationF.ValueChanged, dOthers.ValueChanged
        dTotal.Value = dMeal.Value + dTransportation.Value + dBIR.Value + dRD.Value + dLTO.Value + dNotarizationF.Value + dOthers.Value
    End Sub

    Private Sub Liquidation_ValueChanged(sender As Object, e As EventArgs) Handles dAmount_1.ValueChanged, dAmount_2.ValueChanged, dAmount_3.ValueChanged, dAmount_4.ValueChanged, dAmount_5.ValueChanged, dAmount_6.ValueChanged, dAmount_7.ValueChanged
        dTotalLiquidation.Value = dAmount_1.Value + dAmount_2.Value + dAmount_3.Value + dAmount_4.Value + dAmount_5.Value + dAmount_6.Value + dAmount_7.Value
    End Sub

    Private Sub Dtp_1_ValueChanged(sender As Object, e As EventArgs) Handles dtp_1.ValueChanged
        dtp_2.Value = dtp_1.Value.AddDays(1)
        dtp_3.Value = dtp_1.Value.AddDays(2)
        dtp_4.Value = dtp_1.Value.AddDays(3)
        dtp_5.Value = dtp_1.Value.AddDays(4)
        dtp_6.Value = dtp_1.Value.AddDays(5)
        dtp_7.Value = dtp_1.Value.AddDays(6)
    End Sub

    Private Sub CbxPayee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayee.SelectedIndexChanged
        txtName.Text = cbxPayee.Text
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        dtpDate_2.Value = dtpDate.Value
        dtpLiquidate.Value = dtpDate.Value.AddDays(7)
        dtpPayroll.Value = dtpDate.Value.AddDays(7)
        If dtpPayroll.Value.Day <= 15 Then
            dtpPayroll.Value = Format(dtpDate.Value.AddDays(7), "yyyy-MM-15")
        Else
            dtpPayroll.Value = Format(dtpDate.Value.AddDays(7), String.Format("yyyy-MM-{0}", Date.DaysInMonth(dtpDate.Value.AddDays(7).Year, dtpDate.Value.AddDays(7).Month)))
        End If
        GetAccountNumber()
    End Sub

    Private Sub GetAccountNumber()
        If btnSave.Text = "&Save" Then
            txtAccountNumber.Text = DataObject(String.Format("SELECT CONCAT('CAS-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM cash_advance WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDate.Value, "yy"), Format(dtpDate.Value, "yyyy-MM-dd")))
        End If
    End Sub

    Private Sub New_Approval()
        If SlipStatus = "FOR LEVEL I APPROVAL" And (Empl_ID = Approver2ID Or Empl_ID = Approver3ID Or Empl_ID = Approver4ID) Then
            MsgBox("Cash Advance is still FOR LEVEL I APPROVAL", MsgBoxStyle.Information, "Info")
            Exit Sub
        ElseIf SlipStatus = "FOR LEVEL II APPROVAL" And (Empl_ID = Approver3ID Or Empl_ID = Approver4ID) Then
            MsgBox("Cash Advance is still FOR LEVEL II APPROVAL", MsgBoxStyle.Information, "Info")
            Exit Sub
        ElseIf SlipStatus = "FOR LEVEL III APPROVAL" And (Empl_ID = Approver4ID) Then
            MsgBox("Cash Advance is still FOR LEVEL III APPROVAL", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim Msg As String = ""
        Dim Subject As String = ""
        Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_Prep As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
        If Empl_ID = Approver1ID And SlipStatus = "FOR LEVEL I APPROVAL" And (User_EmplID <> Empl_ID Or cbxPayee.SelectedValue <> Empl_ID) Then
            If MsgBoxYes("Are you sure you want to approve this Cash Advance Slip?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                If dTotal.Value > Approver1_CashAdvance Then
                    Msg = String.Format("Good day {0}," & vbCrLf, Approver2Name)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> For Level II Approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If Approver2Phone = "" Then
                    Else
                        SendSMS(Approver2Phone, Msg, True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If Approver2Email = "" Then
                    Else
                        Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        Generate_CA(False, FName)
                        AttachmentFiles.Add(FName)
                        SendEmail(Approver2Email, Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If

                DataObject(String.Format("UPDATE cash_advance SET Approver1 = {1}, ApprovedID = {1}, Approver2_OTAC = '{2}', `slip_status` = IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= {3},'APPROVED','PENDING') WHERE ID = '{0}';", ID, Empl_ID, Code, Approver1_CashAdvance))
                Logs("Cash Advance Slip", "Approve", String.Format("Level I Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        ElseIf Empl_ID = Approver2ID And SlipStatus = "FOR LEVEL II APPROVAL" And (User_EmplID <> Empl_ID Or cbxPayee.SelectedValue <> Empl_ID) Then
            If MsgBoxYes("Are you sure you want to approve this Cash Advance Slip?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                If dTotal.Value > Approver2_CashAdvance Then
                    Msg = String.Format("Good day {0}," & vbCrLf, Approver3Name)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> For Level III Approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If Approver3Phone = "" Then
                    Else
                        SendSMS(Approver3Phone, Msg, True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If Approver3Email = "" Then
                    Else
                        Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        Generate_CA(False, FName)
                        AttachmentFiles.Add(FName)
                        SendEmail(Approver3Email, Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If

                DataObject(String.Format("UPDATE cash_advance SET Approver2 = {1}, ApprovedID = {1}, Approver3_OTAC = '{2}', `slip_status` = IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= {3},'APPROVED','PENDING') WHERE ID = '{0}';", ID, Empl_ID, Code, Approver2_CashAdvance))
                Logs("Cash Advance Slip", "Approve", String.Format("Level II Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        ElseIf Empl_ID = Approver3ID And SlipStatus = "FOR LEVEL III APPROVAL" And (User_EmplID <> Empl_ID Or cbxPayee.SelectedValue <> Empl_ID) Then
            If MsgBoxYes("Are you sure you want to approve this Cash Advance Slip?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                If dTotal.Value > Approver3_CashAdvance Then
                    Msg = String.Format("Good day {0}," & vbCrLf, Approver4Name)
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> For Level IV Approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If Approver4Phone = "" Then
                    Else
                        SendSMS(Approver4Phone, Msg, True)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If Approver4Email = "" Then
                    Else
                        Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        Generate_CA(False, FName)
                        AttachmentFiles.Add(FName)
                        SendEmail(Approver4Email, Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If

                DataObject(String.Format("UPDATE cash_advance SET Approver3 = {1}, ApprovedID = {1}, Approver4_OTAC = '{2}', `slip_status` = IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= {3},'APPROVED','PENDING') WHERE ID = '{0}';", ID, Empl_ID, Code, Approver3_CashAdvance))
                Logs("Cash Advance Slip", "Approve", String.Format("Level III Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        ElseIf Empl_ID = Approver4ID And SlipStatus = "FOR LEVEL IV APPROVAL" And (User_EmplID <> Empl_ID Or cbxPayee.SelectedValue <> Empl_ID) Then
            If MsgBoxYes("Are you sure you want to approve this Cash Advance Slip?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Code = GenerateOTAC()
                If dTotal.Value > Approver4_CashAdvance Then
                    Msg = "Good day Credit Committee," & vbCrLf
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> For Level V Approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                    Msg &= "Thank you!"
                    '******* SEND EMAIL *********************************************************************************
                    If CredCommEmail = "" Then
                    Else
                        Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        Generate_CA(False, FName)
                        AttachmentFiles.Add(FName)
                        SendEmail(CredCommEmail, Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If

                DataObject(String.Format("UPDATE cash_advance SET Approver4 = {1}, ApprovedID = {1}, Approver5_OTAC = '{2}', `slip_status` = IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= {3},'APPROVED','PENDING') WHERE ID = '{0}';", ID, Empl_ID, Code, Approver4_CashAdvance))
                Logs("Cash Advance Slip", "Approve", String.Format("Level IV Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        ElseIf Department = "CREDIT COMMITTEE" And SlipStatus = "FOR LEVEL V APPROVAL" And (User_EmplID <> Empl_ID Or cbxPayee.SelectedValue <> Empl_ID) Then
            If MsgBoxYes("Are you sure you want to approve this Cash Advance Slip?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                DataObject(String.Format("UPDATE cash_advance SET `slip_status` = 'APPROVED', Approver5 = {1}, ApprovedID = {1} WHERE ID = '{0}';", ID, Empl_ID))
                Logs("Cash Advance Slip", "Approve", String.Format("Level V Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        Else
            Dim OTP As New FrmOneTimePassword
            With OTP
                .btnResend.Visible = True
                If SlipStatus = "FOR LEVEL I APPROVAL" Then
                    .OTP = Approver1_OTAC
                ElseIf SlipStatus = "FOR LEVEL II APPROVAL" Then
                    .OTP = Approver2_OTAC
                ElseIf SlipStatus = "FOR LEVEL III APPROVAL" Then
                    .OTP = Approver3_OTAC
                ElseIf SlipStatus = "FOR LEVEL IV APPROVAL" Then
                    .OTP = Approver4_OTAC
                ElseIf SlipStatus = "FOR LEVEL V APPROVAL" Then
                    .OTP = Approver5_OTAC
                End If
                .lblBilling.Visible = False
                Dim Result = .ShowDialog
                If Result = DialogResult.OK Then
                    Code = GenerateOTAC()
                    Cursor = Cursors.WaitCursor
                    If SlipStatus = "FOR LEVEL I APPROVAL" Then
                        If dTotal.Value > Approver1_CashAdvance Then
                            Msg = String.Format("Good day {0}," & vbCrLf, Approver2Name)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> For Level II Approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If Approver2Phone = "" Then
                            Else
                                SendSMS(Approver2Phone, Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If Approver2Email = "" Then
                            Else
                                Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                Generate_CA(False, FName)
                                AttachmentFiles.Add(FName)
                                SendEmail(Approver2Email, Subject, Msg, False, False, False, 0, "", "")
                            End If
                        End If

                        DataObject(String.Format("UPDATE cash_advance SET Approver1 = {1}, ApprovedID = {1}, Approver2_OTAC = '{2}', `slip_status` = IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= {3},'APPROVED','PENDING') WHERE ID = '{0}';", ID, Approver1ID, Code, Approver1_CashAdvance))
                        Logs("Cash Advance Slip", "Approve", String.Format("Level I Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                    ElseIf SlipStatus = "FOR LEVEL II APPROVAL" Then
                        If dTotal.Value > Approver2_CashAdvance Then
                            Msg = String.Format("Good day {0}," & vbCrLf, Approver3Name)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> For Level III Approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If Approver3Phone = "" Then
                            Else
                                SendSMS(Approver3Phone, Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If Approver3Email = "" Then
                            Else
                                Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                Generate_CA(False, FName)
                                AttachmentFiles.Add(FName)
                                SendEmail(Approver3Email, Subject, Msg, False, False, False, 0, "", "")
                            End If
                        End If

                        DataObject(String.Format("UPDATE cash_advance SET Approver2 = {1}, ApprovedID = {1}, Approver3_OTAC = '{2}', `slip_status` = IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= {3},'APPROVED','PENDING') WHERE ID = '{0}';", ID, Approver2ID, Code, Approver2_CashAdvance))
                        Logs("Cash Advance Slip", "Approve", String.Format("Level II Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                    ElseIf SlipStatus = "FOR LEVEL III APPROVAL" Then
                        If dTotal.Value > Approver3_CashAdvance Then
                            Msg = String.Format("Good day {0}," & vbCrLf, Approver4Name)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> For Level IV Approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If Approver4Phone = "" Then
                            Else
                                SendSMS(Approver4Phone, Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If Approver4Email = "" Then
                            Else
                                Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                Generate_CA(False, FName)
                                AttachmentFiles.Add(FName)
                                SendEmail(Approver4Email, Subject, Msg, False, False, False, 0, "", "")
                            End If
                        End If

                        DataObject(String.Format("UPDATE cash_advance SET Approver3 = {1}, ApprovedID = {1}, Approver4_OTAC = '{2}', `slip_status` = IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= {3},'APPROVED','PENDING') WHERE ID = '{0}';", ID, Approver3ID, Code, Approver3_CashAdvance))
                        Logs("Cash Advance Slip", "Approve", String.Format("Level III Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                    ElseIf SlipStatus = "FOR LEVEL IV APPROVAL" Then
                        If dTotal.Value > Approver4_CashAdvance Then
                            Msg = "Good day Credit Committee," & vbCrLf
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> For Level V Approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND EMAIL *********************************************************************************
                            If CredCommEmail = "" Then
                            Else
                                Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                Generate_CA(False, FName)
                                AttachmentFiles.Add(FName)
                                SendEmail(CredCommEmail, Subject, Msg, False, False, False, 0, "", "")
                            End If
                        End If

                        DataObject(String.Format("UPDATE cash_advance SET Approver4 = {1}, ApprovedID = {1}, Approver5_OTAC = '{2}', `slip_status` = IF((Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= {3},'APPROVED','PENDING') WHERE ID = '{0}';", ID, Approver4ID, Code, Approver4_CashAdvance))
                        Logs("Cash Advance Slip", "Approve", String.Format("Level IV Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                    ElseIf SlipStatus = "FOR LEVEL V APPROVAL" Then
                        Dim Provider As New FrmOTACProvider
                        With Provider
                            .cbxProvider.DisplayMember = "Employee"
                            .cbxProvider.ValueMember = "ID"
                            .Provider = DataSource("SELECT ID, Employee(ID) AS 'Employee', Position FROM employee_setup WHERE `status` = 'ACTIVE' AND Department = 'CREDIT COMMITTEE' ORDER BY `Employee` ASC;")
                            If .ShowDialog = DialogResult.OK Then
                                Cursor = Cursors.WaitCursor
                                DataObject(String.Format("UPDATE cash_advance SET `slip_status` = 'APPROVED', Approver5 = {1}, ApprovedID = {1} WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue))
                                Logs("Cash Advance Slip", "Approve", String.Format("Level V Cash Advance Slip Approval of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                            Else
                                Cursor = Cursors.Default
                                Exit Sub
                            End If
                        End With
                    End If

                    Cursor = Cursors.Default
                    MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                    Clear(True)
                ElseIf Result = DialogResult.Yes Then
                    If SlipStatus = "FOR LEVEL I APPROVAL" Then
                        Msg = String.Format("Good day {0}," & vbCrLf, Approver1Name)
                        Code = Approver1_OTAC
                    ElseIf SlipStatus = "FOR LEVEL II APPROVAL" Then
                        Msg = String.Format("Good day {0}," & vbCrLf, Approver2Name)
                        Code = Approver2_OTAC
                    ElseIf SlipStatus = "FOR LEVEL III APPROVAL" Then
                        Msg = String.Format("Good day {0}," & vbCrLf, Approver3Name)
                        Code = Approver3_OTAC
                    ElseIf SlipStatus = "FOR LEVEL IV APPROVAL" Then
                        Msg = String.Format("Good day {0}," & vbCrLf, Approver4Name)
                        Code = Approver4_OTAC
                    ElseIf SlipStatus = "FOR LEVEL V APPROVAL" Then
                        Msg = "Good day Credit Committee," & vbCrLf
                        Code = Approver5_OTAC
                    End If
                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> {4} of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text, SlipStatus)
                    Msg &= "Thank you!"
                    'RESEND OTAC  *******************************************************************
                    If SlipStatus = "FOR LEVEL I APPROVAL" Then
                        If cbxPayee.SelectedValue = Approver1ID Or cbxPreparedBy.SelectedValue = Approver1ID Then
                            Msg = String.Format("Good day {0}," & vbCrLf, Approver2Name)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> {4} of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text, SlipStatus)
                            Msg &= "Thank you!"
                            GoTo GotoApprover2
                        End If
                        '******* SEND SMS *********************************************************************************
                        If Approver1Phone = "" Then
                        Else
                            SendSMS(Approver1Phone, Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If Approver1Email = "" Then
                        Else
                            Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            Generate_CA(False, FName)
                            AttachmentFiles.Add(FName)
                            SendEmail(Approver1Email, Subject, Msg, False, False, False, 0, "", "")
                        End If
                    ElseIf SlipStatus = "FOR LEVEL II APPROVAL" Then
GotoApprover2:
                        If cbxPayee.SelectedValue = Approver2ID Or cbxPreparedBy.SelectedValue = Approver2ID Then
                            Msg = String.Format("Good day {0}," & vbCrLf, Approver3Name)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> {4} of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text, SlipStatus)
                            Msg &= "Thank you!"
                            GoTo GotoApprover3
                        End If
                        '******* SEND SMS *********************************************************************************
                        If Approver2Phone = "" Then
                        Else
                            SendSMS(Approver2Phone, Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If Approver2Email = "" Then
                        Else
                            Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            Generate_CA(False, FName)
                            AttachmentFiles.Add(FName)
                            SendEmail(Approver2Email, Subject, Msg, False, False, False, 0, "", "")
                        End If
                    ElseIf SlipStatus = "FOR LEVEL III APPROVAL" Then '******* SEND SMS *********************************************************************************
GotoApprover3:
                        If cbxPayee.SelectedValue = Approver2ID Or cbxPreparedBy.SelectedValue = Approver2ID Then
                            Msg = String.Format("Good day {0}," & vbCrLf, Approver4Name)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> {4} of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text, SlipStatus)
                            Msg &= "Thank you!"
                            GoTo GotoApprover4
                        End If
                        If Approver3Phone = "" Then
                        Else
                            SendSMS(Approver3Phone, Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If Approver3Email = "" Then
                        Else
                            Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            Generate_CA(False, FName)
                            AttachmentFiles.Add(FName)
                            SendEmail(Approver3Email, Subject, Msg, False, False, False, 0, "", "")
                        End If
                    ElseIf SlipStatus = "FOR LEVEL IV APPROVAL" Then
GotoApprover4:
                        If cbxPayee.SelectedValue = Approver2ID Or cbxPreparedBy.SelectedValue = Approver2ID Then
                            Msg = "Good day Credit Committee," & vbCrLf
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> {4} of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text, SlipStatus)
                            Msg &= "Thank you!"
                            GoTo GotoApprover5
                        End If
                        '******* SEND SMS *********************************************************************************
                        If Approver4Phone = "" Then
                        Else
                            SendSMS(Approver4Phone, Msg, True)
                        End If
                        '******* SEND EMAIL *********************************************************************************
                        If Approver4Email = "" Then
                        Else
                            Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            Generate_CA(False, FName)
                            AttachmentFiles.Add(FName)
                            SendEmail(Approver4Email, Subject, Msg, False, False, False, 0, "", "")
                        End If
                    ElseIf SlipStatus = "FOR LEVEL V APPROVAL" Then
GotoApprover5:
                        '******* SEND EMAIL *********************************************************************************
                        If CredCommEmail = "" Then
                        Else
                            Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                            Generate_CA(False, FName)
                            AttachmentFiles.Add(FName)
                            SendEmail(CredCommEmail, Subject, Msg, False, False, False, 0, "", "")
                        End If
                    End If
                End If
            End With
        End If
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_Prep As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
        If CashApprovalHierarchy Then
            New_Approval()

            Exit Sub
        End If

        If User_Type = "ADMIN" Or Dept_Head Or ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or CheckApprover() Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A3ID"), 0) = Empl_ID Then
            ' If Dept_Head And (User_EmplID = Empl_ID Or cbxPayee.SelectedValue = Empl_ID) Then
            If (User_EmplID = Empl_ID Or cbxPayee.SelectedValue = Empl_ID) Then
                GoTo HereV2
            ElseIf Dept_Head = False And Department.ToUpper.Contains("ADMINISTRATIVE") Then
                GoTo HereV2
                'Else
                '    GoTo Here
            End If
        End If
        If User_EmplID = Empl_ID Or cbxPayee.SelectedValue = Empl_ID Then
HereV2:
            Dim OTP As New FrmOneTimePassword
            With OTP
                .btnResend.Visible = True
                .OTP = Code
                .lblBilling.Visible = False
                Dim Result = .ShowDialog
                If Result = DialogResult.OK Then
                    Dim Provider As New FrmOTACProvider
                    With Provider
                        .cbxAll.Visible = True
                        .cbxProvider.DisplayMember = "Employee"
                        .cbxProvider.ValueMember = "ID"
                        .ProviderDept = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Position FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = '{0}' AND Branch_ID IN ('{1}','{2}') AND ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) ORDER BY `Employee` ASC;", drv("department_id"), Branch_ID, MFBranch_ID))
                        .Provider = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Position FROM employee_setup WHERE `status` = 'ACTIVE' AND Branch_ID IN ('{1}','{2}') AND ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) ORDER BY `Employee` ASC;", drv("department_id"), Branch_ID, MFBranch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            Dim drvX As DataRowView = DirectCast(.cbxProvider.SelectedItem, DataRowView)
                            Dim DT_CashAdvanceLimit As DataTable = DataSource(String.Format("SELECT OIC_CA, BM_CA, DM_CA, RM_CA FROM branch WHERE ID = '{0}' AND `status` = 'ACTIVE';", Branch_ID))
                            If If(drvX("Position") = "OFFICER-IN-CHARGE" Or drvX("Position") = "OFFICE SUPERVISOR" Or drvX("Position") = "ASSISTANT BRANCH MANAGER", dTotal.Value <= DT_CashAdvanceLimit(0)("OIC_CA"), If(drvX("Position") = "BRANCH MANAGER", dTotal.Value <= DT_CashAdvanceLimit(0)("BM_CA"), If(drvX("Position") = "DISTRICT MANAGER", dTotal.Value <= DT_CashAdvanceLimit(0)("DM_CA"), If(drvX("Position") = "REGIONAL MANAGER", dTotal.Value <= DT_CashAdvanceLimit(0)("RM_CA"), False)))) Then
                                DataObject(String.Format("UPDATE cash_advance SET `slip_status` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue))
                            Else
                                '********* E M A I L   C R E C O M    F O R   N O T I F I C A T I O N ***************************
                                If dTotal.Value > 1000 Then
                                    Dim CreComm As New FrmCrecomList
                                    With CreComm
                                        Dim Msg As String = ""
                                        Dim Subject As String = String.Format("Cash Advance Slip {0}.", txtAccountNumber.Text)
                                        Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                        If .ShowDialog = DialogResult.OK Then
                                            Dim Email As String = ""
                                            Msg = String.Format("Good day," & vbCrLf)
                                            Msg &= String.Format(" Notification of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                            Msg &= "Thank you!"
                                            For x As Integer = 0 To CreComm.GridView1.RowCount - 1
                                                If CBool(CreComm.GridView1.GetRowCellValue(x, "Include")) = True Then
                                                    SendSMS(CreComm.GridView1.GetRowCellValue(x, "Phone"), Msg, True)
                                                    Email &= CreComm.GridView1.GetRowCellValue(x, "Email Address") & ", "
                                                End If
                                            Next
                                            If Email = "" Then
                                            Else
                                                Subject = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                                Generate_CA(False, FName)
                                                AttachmentFiles.Add(FName)
                                                SendEmail(Email.Substring(0, Email.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                                            End If
                                        End If
                                    End With
                                End If
                                '********* E M A I L   C R E C O M    F O R   N O T I F I C A T I O N ***************************

                                DataObject(String.Format("UPDATE cash_advance SET `slip_status` = 'APPROVED HEAD', ApprovedID = '{1}' WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue))
                            End If
                            Logs("Cash Advance Slip", "Approve", String.Format("Approved Cash Advance Slip of {0} with the total amount of {1} for {2}. [Via OTAC]", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")

                            Cursor = Cursors.Default
                            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                            Clear(True)
                        End If
                        .Dispose()
                    End With
                ElseIf Result = DialogResult.Yes Then
                    'SEND EMAIL AND SMS APPROVAL TO DEPARTMENT HEAD  *******************************************************************
                    Dim Msg As String = ""
                    Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                    Dim DT_Head As DataTable
                    Dim EmailTo As String = ""
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    If drv("Head") = 0 Or Branch_ID > 0 Or drv("department_id") <> drv_Prep("department_id") Then
                        If Branch_ID = 0 Then
                            If cbxOther.Checked Then
                                DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department = '{0}' AND Branch_ID IN ('{1}','{2}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", drv_Prep("department_id"), Branch_ID, MFBranch_ID))
                            Else
                                DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id IN ('{0}','{1}') AND Branch_ID IN ('{2}','{3}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", If(NotifyPayeeApprover, drv("department_id"), False), drv_Prep("department_id"), Branch_ID, MFBranch_ID))
                            End If
                            For x As Integer = 0 To DT_Head.Rows.Count - 1
                                Msg = String.Format("Good day," & vbCrLf, DT_Head(x)("Employee"))
                                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                Msg &= "Thank you!"
                                '******* SEND SMS *********************************************************************************
                                If DT_Head(x)("Phone") = "" Then
                                Else
                                    SendSMS(DT_Head(x)("Phone"), Msg, True)
                                End If
                                '******* SEND EMAIL *********************************************************************************
                                If DT_Head(x)("EmailAdd") = "" Then
                                Else
                                    EmailTo = EmailTo & DT_Head(x)("EmailAdd") & ", "
                                End If
                            Next
                        Else
                            Dim BM As DataTable = GetBM(Branch_ID)
                            For x As Integer = 0 To BM.Rows.Count - 1
                                Msg = String.Format("Good day," & vbCrLf, BM(x)("Employee"))
                                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                Msg &= "Thank you!"
                                '******* SEND SMS *********************************************************************************
                                If BM(x)("Phone") = "" Then
                                Else
                                    SendSMS(BM(x)("Phone"), Msg, True)
                                End If
                                '******* SEND EMAIL *********************************************************************************
                                If BM(x)("EmailAdd") = "" Then
                                Else
                                    EmailTo = EmailTo & BM(x)("EmailAdd") & ", "
                                End If
                            Next
                        End If
                    Else
                        If DT_CAS_Approver.Rows.Count > 0 Then
                            Msg = String.Format("Good day," & vbCrLf)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_CAS_Approver(0)("A1Phone") = "" Then
                            Else
                                SendSMS(DT_CAS_Approver(0)("A1Phone"), Msg, True)
                            End If
                            If DT_CAS_Approver(0)("A2Phone") = "" Then
                            Else
                                SendSMS(DT_CAS_Approver(0)("A2Phone"), Msg, True)
                            End If
                            If DT_CAS_Approver(0)("A3Phone") = "" Then
                            Else
                                SendSMS(DT_CAS_Approver(0)("A3Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_CAS_Approver(0)("A1Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_CAS_Approver(0)("A1Email") & ", "
                            End If
                            If DT_CAS_Approver(0)("A2Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_CAS_Approver(0)("A2Email") & ", "
                            End If
                            If DT_CAS_Approver(0)("A3Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_CAS_Approver(0)("A3Email") & ", "
                            End If
                        Else
                            Dim CreComm As New FrmCrecomList
                            With CreComm
                                .For_Signatory = True
                                Dim SQLV2 As String = "SELECT "
                                SQLV2 &= "      'False' AS 'Include',"
                                SQLV2 &= "      Employee(ID) AS 'Name',"
                                SQLV2 &= "      CONCAT('+63',Phone) AS 'Phone',"
                                SQLV2 &= "      EmailAdd AS 'Email Address', `Position` "
                                SQLV2 &= String.Format("  FROM employee_setup WHERE ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) AND Branch_ID IN ('{0}','{1}') AND `status` = 'ACTIVE' ORDER BY `Name` ;", Branch_ID, MFBranch_ID)
                                .GridControl1.DataSource = DataSource(SQLV2)
                                If .ShowDialog = DialogResult.OK Then
                                    Dim Email As String = ""
                                    Msg = String.Format("Good day," & vbCrLf)
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                    Msg &= "Thank you!"
                                    For x As Integer = 0 To CreComm.GridView1.RowCount - 1
                                        If CBool(CreComm.GridView1.GetRowCellValue(x, "Include")) = True Then
                                            Email &= CreComm.GridView1.GetRowCellValue(x, "Email Address") & ", "
                                        End If
                                    Next
                                    If Email = "" Then
                                    Else
                                        Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                        Generate_CA(False, FName)
                                        AttachmentFiles.Add(FName)
                                        SendEmail(Email.Substring(0, Email.Length - 2), Subject, Msg, False, True, False, 0, "", "")
                                        Exit Sub
                                    End If
                                Else
                                    Exit Sub
                                End If
                            End With
                        End If
                    End If
                    If EmailTo = "" Then
                    Else
                        Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                        AttachmentFiles = New ArrayList()
                        FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        Generate_CA(False, FName)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, True, False, 0, "", "")
                    End If
                End If
            End With
        ElseIf User_Type = "ADMIN" Or (Approver1ID = Empl_ID And Approver1_CashAdvance >= dTotal.Value) Or (Approver2ID = Empl_ID And Approver2_CashAdvance >= dTotal.Value) Or (Approver3ID = Empl_ID And Approver3_CashAdvance >= dTotal.Value) Or Dept_Head Or ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or CheckApprover() Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A3ID"), 0) = Empl_ID Then
            'Here:
            Dim ProviderID As Integer = 0
            If Dept_Head = False And (If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_CAS_Approver.Rows.Count > 0, DT_CAS_Approver(0)("A3ID"), 0) = Empl_ID) Then
                Dim Provider As New FrmOTACProvider
                With Provider
                    .cbxAll.Visible = True
                    .cbxProvider.DisplayMember = "Employee"
                    .cbxProvider.ValueMember = "ID"
                    .ProviderDept = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Position FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = '{0}' AND Branch_ID IN ('{1}','{2}') AND ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) ORDER BY `Employee` ASC;", drv("department_id"), Branch_ID, MFBranch_ID))
                    .Provider = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Position FROM employee_setup WHERE `status` = 'ACTIVE' AND Branch_ID IN ('{1}','{2}') AND ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) ORDER BY `Employee` ASC;", drv("department_id"), Branch_ID, MFBranch_ID))
                    If .ShowDialog = DialogResult.OK Then
                        ProviderID = .cbxProvider.SelectedValue
                    End If
                    .Dispose()
                End With
            End If
            If MsgBoxYes("Are you sure you want to approve this Cash Advance Slip?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                If dTotal.Value > 1000 Then
                    Dim CreComm As New FrmCrecomList
                    With CreComm
                        Dim Msg As String = ""
                        Dim Subject As String = String.Format("Cash Advance Slip {0}.", txtAccountNumber.Text)
                        Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        If .ShowDialog = DialogResult.OK Then
                            Dim Email As String = ""
                            Msg = String.Format("Good day," & vbCrLf)
                            Msg &= String.Format(" Notification of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            For x As Integer = 0 To CreComm.GridView1.RowCount - 1
                                If CBool(CreComm.GridView1.GetRowCellValue(x, "Include")) = True Then
                                    SendSMS(CreComm.GridView1.GetRowCellValue(x, "Phone"), Msg, True)
                                    Email &= CreComm.GridView1.GetRowCellValue(x, "Email Address") & ", "
                                End If
                            Next
                            If Email = "" Then
                            Else
                                Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "] (" & Branch & ")"
                                FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                Generate_CA(False, FName)
                                AttachmentFiles.Add(FName)
                                SendEmail(Email.Substring(0, Email.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                            End If
                        End If
                    End With
                End If
                If If(ComparePosition({"OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False), dTotal.Value <= Approver1_CashAdvance, If(ComparePosition({"BRANCH MANAGER"}, False), dTotal.Value <= Approver2_CashAdvance, If(ComparePosition({"DISTRICT MANAGER"}, False), dTotal.Value <= Approver3_CashAdvance, If(ComparePosition({"REGIONAL MANAGER"}, False), dTotal.Value <= Approver4_CashAdvance, False)))) Then
                    DataObject(String.Format("UPDATE cash_advance SET `slip_status` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, If(ProviderID > 0, ProviderID, Empl_ID)))
                Else
                    DataObject(String.Format("UPDATE cash_advance SET `slip_status` = 'APPROVED HEAD', ApprovedID = '{1}' WHERE ID = '{0}';", ID, If(ProviderID > 0, ProviderID, Empl_ID)))
                End If
                Logs("Cash Advance Slip", "Approve", String.Format("Approved Cash Advance Slip of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        End If
    End Sub

    Private Sub BtnApproveCrecomm_Click(sender As Object, e As EventArgs) Handles btnApproveCrecomm.Click
        If MsgBoxYes("Are you sure that this Cash Advance Slip is approved by the CreComm?") = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE cash_advance SET `slip_status` = 'APPROVED' WHERE ID = '{0}';", ID))
            Logs("Cash Advance Slip", "Approve Crecomm", String.Format("Approved Cash Advance Slip of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
            MsgBox("Successfully Approved by Crecomm!", MsgBoxStyle.Information, "Info")
            Clear(True)
        End If
    End Sub

    Private Sub BtnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        Dim R As New FrmReceivedBy
        With R
            .dtpReceived.MinDate = dtpDate.Value
            .cbxReceiver.DisplayMember = "Employee"
            .cbxReceiver.ValueMember = "ID"
            .cbxReceiver.DataSource = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee' FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id IN ('{0}','{1}') ORDER BY `Employee`;", Branch_ID, MFBranch_ID))
            If cbxPayee.SelectedValue = Nothing Then
                .cbxReceiver.Text = cbxPayee.Text
            Else
                .cbxReceiver.SelectedValue = cbxPayee.SelectedValue
            End If
            If R.ShowDialog = DialogResult.OK Then
                DataObject(String.Format("UPDATE cash_advance SET `slip_status` = 'RECEIVED', ReceivedID = '{1}', ReceivedDate = '{2}'  WHERE ID = '{0}';", ID, .cbxReceiver.SelectedValue, Format(.dtpReceived.Value, "yyyy-MM-dd")))
                Logs("Cash Advance Slip", "Receive", String.Format("Received Cash Advance Slip of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                MsgBox("Successfully Received!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        End With
    End Sub

    Public Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
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
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Slip_Status"))
            If Status = "DISAPPROVED" Or Status = "CANCELLED" Or Status = "DELETED" Then
                e.Appearance.ForeColor = Color.Red
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
            .FolderName = "Cash Advance-" & GridView1.GetFocusedRowCellValue("Account Number")
            .CANumber = GridView1.GetFocusedRowCellValue("Account Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Account Number")
            .Type = "Cash Advance"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", Attach.TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If CashApprovalHierarchy Then
            If SlipStatus = "FOR LEVEL I APPROVAL" And (Empl_ID = Approver2ID Or Empl_ID = Approver3ID Or Empl_ID = Approver4ID) Then
                MsgBox("Cash Advance is still FOR LEVEL I APPROVAL", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf SlipStatus = "FOR LEVEL II APPROVAL" And (Empl_ID = Approver3ID Or Empl_ID = Approver4ID) Then
                MsgBox("Cash Advance is still FOR LEVEL II APPROVAL", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf SlipStatus = "FOR LEVEL III APPROVAL" And (Empl_ID = Approver4ID) Then
                MsgBox("Cash Advance is still FOR LEVEL III APPROVAL", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End If

        If MsgBoxYes("Are you sure you want to disapprove this Cash Advance?") = MsgBoxResult.Yes Then
            Dim CV As String = DataObject(String.Format("SELECT DocumentNumber FROM check_voucher WHERE Payee_ID = '{0}' AND `status` = 'ACTIVE' AND Voucher_Status IN ('PENDING','CHECKED','APPROVED','RECEIVED') AND JVNumber = '' LIMIT 1;", txtAccountNumber.Text))
            If CV = "" Then
            Else
                MsgBox(String.Format("Cash Advance already have a CHECK VOUCHER with document number {0}. Please CANCEL or JOURNAL VOUCHER the existing CHECK VOUCHER first.", CV), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE cash_advance SET `slip_status` = 'DISAPPROVED', DisapprovedID = '{1}' WHERE ID = '{0}';", ID, Empl_ID))
            Logs("Cash Advance Slip", "Disapprove", Reason, String.Format("Disapproved Cash Advance of {0} with Amount {1}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Disapproved!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnEmailCrecom_Click(sender As Object, e As EventArgs) Handles btnEmailCrecom.Click
        If MsgBoxYes("Are you sure you want to send this Cash Advance to Credit Committee?") = MsgBoxResult.Yes Then
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

                    Dim Subject As String = "Cash Advance Approval [" & txtAccountNumber.Text & "] (" & Branch & ")"
                    Dim Body As String = "Dear Sir/Madam,<br><br>"
                    Body &= "Sending to you CA with the following information<br><br>"
                    Body &= "Payee : <b>" & cbxPayee.Text & "</b><br>"
                    Body &= "Total CA : <b>" & dTotal.Text & "</b><br>"
                    Body &= "Purpose : <b>" & txtPurpose.Text & "</b><br>"
                    Body &= "Thank you<br>"

                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    Generate_CA(False, FName)
                    AttachmentFiles.Add(FName)
                    SendEmail(Email, Subject, Body, False, True, False, 0, "", "")
                    Logs("Cash Advance", "Email", "Email", String.Format("Email Cash Advance with Account Number {0}", txtAccountNumber.Text), "", "", "")
                    LoadData()
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub ILiquidate_Click(sender As Object, e As EventArgs) Handles iLiquidate.Click
        Try
            If GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR LIQUIDATION" Then
            Else
                If GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATED" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATION FOR APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "ACKNOWLEDGED" Then
                    MsgBox(String.Format("Cash Advance is already {0}", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
                Else
                    MsgBox(String.Format("Cash Advance is still {0}", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
                End If
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If CDbl(GridView1.GetFocusedRowCellValue("Total")) <= 1000 Then
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
                .cbxLiquidate.Checked = True
                .From_CAS = True
                .AccountNumber = GridView1.GetFocusedRowCellValue("Account Number")
                .cbxPayee.Enabled = False
                .cbxLiquidate.Enabled = False
                .cbxOther.Enabled = False
                .btnRefresh.Enabled = False
                .btnNext.Enabled = False
                .btnPrint.Enabled = False
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
        Else
            Dim Liquidation As New FrmLiquidation
            With Liquidation
                .Tag = 85
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

                .From_CAS = True
                .AccountNumber = GridView1.GetFocusedRowCellValue("Account Number")
                .cbxPayee.Enabled = False
                .FormBorderStyle = FormBorderStyle.FixedDialog
                .tabList.Visible = False
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub ITagLiquidate_Click(sender As Object, e As EventArgs) Handles iTagLiquidate.Click
        Try
            If GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR LIQUIDATION" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "RECEIVED" Then
                If CDbl(GridView1.GetFocusedRowCellValue("Total")) > 1000 Then
                    MsgBox("Cash Advance is more than P1,000. Liquidation is not thru petty cash.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Else
                If GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATED" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATION FOR APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "ACKNOWLEDGED" Then
                    MsgBox(String.Format("Cash Advance is already {0}", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
                Else
                    MsgBox(String.Format("Cash Advance is still {0}", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
                End If
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim PCT As New FrmPettyCashTag
        With PCT
            .AccountNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .PayeeID = GridView1.GetFocusedRowCellValue("Payee_ID")
            .Amount = GridView1.GetFocusedRowCellValue("Total")
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IReturn_Click(sender As Object, e As EventArgs) Handles iReturn.Click
        Try
            If GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR LIQUIDATION" Then
                If CDbl(GridView1.GetFocusedRowCellValue("Total")) <= 1000 Then
                    MsgBox(String.Format("Total Cash Advance is only P{0} and did not have a check voucher.", FormatNumber(GridView1.GetFocusedRowCellValue("Total"), 2)), MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView1.GetFocusedRowCellValue("CV_ID") = 0 Then
                    MsgBox("No active check voucher is tagged in this Cash Advance.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                ElseIf GridView1.GetFocusedRowCellValue("ACRNumber") <> "" Then
                    MsgBox(String.Format("Cash Advance already have an Acknowledgement Number of {0}. Please wait for the approval of the ACR.", GridView1.GetFocusedRowCellValue("ACRNumber")), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            Else
                If GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATED" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATION FOR APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "ACKNOWLEDGED" Then
                    MsgBox(String.Format("Cash Advance is already {0}", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
                Else
                    MsgBox(String.Format("Cash Advance is still {0}", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
                End If
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
            .cbxCAS.Checked = True

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub LoadPayee()
        If FirstLoad Then
            Exit Sub
        End If

        With cbxPayee
            If cbxOther.Checked Then
                .DataSource = DT_Employees_Other.Copy
                .SelectedIndex = -1
            Else
                '.DataSource = DT_Employees.Copy
                .DataSource = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd, `Position`, IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) AS 'Head', department_ID FROM employee_setup WHERE `status` = 'ACTIVE' AND IF({0} = 0,IF({1},Department_ID = {2},TRUE),TRUE) AND branch_id IN ('{0}','{3}') ORDER BY `Employee`;", Branch_ID, DepartmentalView, Dept_ID, MFBranch_ID))
                .SelectedValue = Empl_ID
            End If
        End With
    End Sub

    Private Sub CbxOther_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOther.CheckedChanged
        LoadPayee()
    End Sub

    Private Sub BtnCheckVoucher_Click(sender As Object, e As EventArgs) Handles btnCheckVoucher.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Total") <= 1000 Then
                MsgBox("Cash Advance must be more than P1,000.00.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Slip_Status").ToString.Contains("FOR LEVEL") Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR HEAD APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR CREDIT COMMITTEE APPROVAL" Then
                MsgBox(String.Format("Cash Advance is still {0}", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Slip_Status") = "CV FOR APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "CV FOR CLEARING" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR LIQUIDATION" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATION FOR APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATED" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR DISBURSEMENT" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "ACKNOWLEDGED" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "RECEIVED" Then
                MsgBox(String.Format("Cash Advance is already {0}.", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
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
            Logs("Cash Advance", "Check Voucher", "Check Voucher", "", "", "", "")

            .From_CA = True
            .cbxPayee.Tag = GridView1.GetFocusedRowCellValue("Account Number")

            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
        End With
    End Sub

    Private Sub BtnTagCheckVoucher_Click(sender As Object, e As EventArgs) Handles btnTagCheckVoucher.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Total") <= 1000 Then
                MsgBox("Cash Advance must be more than P1,000.00.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Slip_Status").ToString.Contains("FOR LEVEL") Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR HEAD APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR CREDIT COMMITTEE APPROVAL" Then
                MsgBox(String.Format("Cash Advance is still {0}", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Slip_Status") = "CV FOR APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "CV FOR CLEARING" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR LIQUIDATION" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATION FOR APPROVAL" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "LIQUIDATED" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "FOR DISBURSEMENT" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Slip_Status") = "ACKNOWLEDGED" Then
                MsgBox(String.Format("Cash Advance is already {0}.", GridView1.GetFocusedRowCellValue("Slip_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim CVT As New FrmCheckVoucherTag
        With CVT
            .AccountNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .PayeeID = GridView1.GetFocusedRowCellValue("Payee_ID")
            .Amount = GridView1.GetFocusedRowCellValue("Total")
            .vBranchID = GridView1.GetFocusedRowCellValue("branch_id")
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub
End Class