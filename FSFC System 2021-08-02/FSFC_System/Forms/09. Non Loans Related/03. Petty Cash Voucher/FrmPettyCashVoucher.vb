Imports DevExpress.XtraReports.UI
Public Class FrmPettyCashVoucher

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim Code As String
    Dim User_EmplID As Integer
    Dim Dept_Head As Boolean
    Dim FirstLoad As Boolean = True
    Dim LOE_Number As String

    Public From_CAS As Boolean
    Public From_LOE As Boolean
    Public AccountNumber As String
    Dim DepartmentalView As Boolean
    ReadOnly NotifyPayeeApprover As Boolean

    Private Sub FrmPettyCashVoucher_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        cbxDisplay.SelectedIndex = 0
        If AllowFromOtherBranch = False Then
            cbxOther.Visible = False
            cbxPayee.Size = New Point(475, 25)
        End If

        dtpDate.Value = Date.Now

        cbxPayee.DisplayMember = "Supplier"
        cbxPayee.ValueMember = "ID"
        LoadPayee("")

        With cbxDepartment_1
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_2
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_3
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_4
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_5
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_6
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_7
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_8
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_9
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_10
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_11
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxDepartment_12
            .DisplayMember = "Department"
            .ValueMember = "Code"
            .DataSource = DT_Department.Copy
            .SelectedIndex = -1
        End With

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        Dim DT_Status As DataTable = DataSource("SELECT 'For Approval' AS 'Status' UNION SELECT 'For Releasing' UNION SELECT 'Received' UNION SELECT 'Cancelled'")
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

        GetAccountNumber()
        LoadData()
        FirstLoad = False
        If From_CAS Then
            CbxPayee_SelectedIndexChanged(sender, e)
        Else
            cbxPayee.SelectedValue = Empl_ID
        End If
        If From_LOE Then
            cbxAll.Checked = True
            LoadData()
            GridView1_DoubleClick(sender, e)
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

            GetLabelFontSettings({LabelX2, LabelX1, LabelX10, LabelX6, LabelX5, LabelX34, LabelX37, LabelX4, LabelX35, LabelX36, LabelX38, LabelX40, LabelX42, LabelX41, LabelX39})

            GetTextBoxFontSettings({txtAccountNumber, txtPurpose, txtParticular_1, txtParticular_2, txtParticular_3, txtParticular_4, txtParticular_5, txtParticular_6, txtParticular_7, txtParticular_8, txtParticular_9, txtParticular_10, txtParticular_11, txtParticular_12, txtApproved, txtReceived, txtReceivedDate})

            GetLabelWithBackgroundFontSettings({LabelX3, LabelX7, LabelX21, LabelX19})

            GetCheckBoxFontSettings({cbxOther, cbxLiquidate, cbxAll})

            GetComboBoxFontSettings({cbxPayee, cbxPreparedBy, cbxDisplay, cbxDepartment_1, cbxDepartment_2, cbxDepartment_3, cbxDepartment_4, cbxDepartment_5, cbxDepartment_6, cbxDepartment_7, cbxDepartment_8, cbxDepartment_9, cbxDepartment_10, cbxDepartment_11, cbxDepartment_12})

            GetDateTimeInputFontSettings({dtpDate, dtpFrom, dtpTo})

            GetDoubleInputFontSettings({dAmount_1, dAmount_2, dAmount_3, dAmount_4, dAmount_5, dAmount_6, dAmount_7, dAmount_8, dAmount_9, dAmount_10, dAmount_11, dAmount_12})

            GetDoubleInputFontSettingsDefault({dTotal})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDisapprove, btnPrint, btnAttach, btnDelete, btnReceive, btnApprove, btnSearch})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Petty Cash Voucher - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Petty Cash", lblTitle.Text)
    End Sub

    Private Sub LoadPayee(ReferenceN As String)
        Dim SQL As String
        If cbxLiquidate.Checked Then
            SQL = " SELECT Payee_ID AS 'ID', CONCAT(Employee(Payee_ID), ' [', AccountNumber, ']') AS 'Supplier', "
            SQL &= "     'C' AS 'Type', "
            SQL &= "     '' AS 'TIN',"
            SQL &= "     AccountNumber,"
            SQL &= "     Purpose,"
            SQL &= "     IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = (SELECT Position_ID FROM employee_setup WHERE ID = cash_advance.Payee_ID)),0) AS 'Head',"
            SQL &= "     (SELECT department_id FROM employee_setup WHERE ID = Payee_ID) AS 'department_id', True AS 'Cash Advance', (Meals + Transportation + BIR + RD + LTO + Notarization + Others) AS 'Amount', ReceivedDate, '' AS 'Phone', '' AS 'EmailAdd'"
            SQL &= String.Format("     FROM cash_advance WHERE `status` = 'ACTIVE' AND slip_status = 'RECEIVED' AND Liquidated = IF('{1}' = '','N','Y') AND Branch_ID IN ('{0}','{3}') AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000 AND IF('{2}' = '',TRUE,AccountNumber = '{2}') ORDER BY `Type`, `Supplier`;", Branch_ID, ReferenceN, AccountNumber, MFBranch_ID)
        Else
            If cbxOther.Checked Then
                SQL = " SELECT ID, Employee(ID) AS 'Supplier',"
                SQL &= "     'E' AS 'Type',"
                SQL &= "     '' AS 'TIN',"
                SQL &= "     '' AS 'AccountNumber',"
                SQL &= "     '' AS 'Purpose',"
                SQL &= "     IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) AS 'Head',"
                SQL &= "     department_id, IFNULL((SELECT COUNT(ID) FROM cash_advance WHERE Payee_ID = employee_setup.ID AND `status` = 'ACTIVE' AND Liquidated = 'N' AND slip_status = 'RECEIVED' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000),0) AS 'Cash Advance', '' AS 'ReceivedDate', Phone, EmailAdd"
                SQL &= String.Format(" FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id != '{0}' ", Branch_ID)
            Else
                SQL = " SELECT ID, Employee(ID) AS 'Supplier',"
                SQL &= "     'E' AS 'Type',"
                SQL &= "     '' AS 'TIN',"
                SQL &= "     '' AS 'AccountNumber',"
                SQL &= "     '' AS 'Purpose',"
                SQL &= "     IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) AS 'Head',"
                SQL &= "     department_id, IFNULL((SELECT COUNT(ID) FROM cash_advance WHERE Payee_ID = employee_setup.ID AND `status` = 'ACTIVE' AND Liquidated = 'N' AND slip_status = 'RECEIVED' AND (Meals + Transportation + BIR + RD + LTO + Notarization + Others) <= 1000),0) AS 'Cash Advance', '' AS 'ReceivedDate', Phone, EmailAdd"
                SQL &= String.Format(" FROM employee_setup WHERE `status` = 'ACTIVE' AND IF({0} = 0,IF({1},Department_ID = {2},TRUE),TRUE) AND branch_id IN ('{0}','{3}') ", Branch_ID, DepartmentalView, Dept_ID, MFBranch_ID)
                SQL &= " UNION ALL"
                SQL &= " SELECT ID, CONCAT('[', CodeS ,'] ',Supplier) AS 'Supplier',"
                SQL &= "     'S' AS 'Type',"
                SQL &= "     TIN,"
                SQL &= "     '' AS 'AccountNumber',"
                SQL &= "     '' AS 'Purpose',"
                SQL &= "     0 AS 'Head',"
                SQL &= "     0 AS 'department_id', 0 AS 'Cash Advance', '' AS 'ReceivedDate', '' AS 'Phone', '' AS 'EmailAdd'"
                SQL &= String.Format(" FROM supplier_setup WHERE `status` = 'ACTIVE' AND branch_id IN ('{0}','{1}')", Branch_ID, MFBranch_ID)
            End If
        End If
        cbxPayee.DataSource = DataSource(SQL)
    End Sub

    Public Sub LoadData()
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ROW_NUMBER() OVER () AS 'No', ID,"
        SQL &= "    Payee_ID, Payee_Type, "
        SQL &= "    Payee,"
        SQL &= "    DATE_FORMAT(Trans_Date,'%M %d, %Y') AS 'Date',"
        SQL &= "    AccountNumber AS 'Account Number',"
        SQL &= "    TIN,"
        SQL &= "    Purpose, ReplenishedID,"
        SQL &= "    Particular_1 AS 'Particular 1', CONCAT(DepartmentCode_1, ' - ', Department(DepartmentCode_1)) AS 'Department 1',"
        SQL &= "    Amount_1 AS 'Amount 1',"
        SQL &= "    Particular_2 AS 'Particular 2', CONCAT(DepartmentCode_2, ' - ', Department(DepartmentCode_2)) AS 'Department 2',"
        SQL &= "    Amount_2 AS 'Amount 2',"
        SQL &= "    Particular_3 AS 'Particular 3', CONCAT(DepartmentCode_3, ' - ', Department(DepartmentCode_3)) AS 'Department 3',"
        SQL &= "    Amount_3 AS 'Amount 3',"
        SQL &= "    Particular_4 AS 'Particular 4', CONCAT(DepartmentCode_4, ' - ', Department(DepartmentCode_4)) AS 'Department 4',"
        SQL &= "    Amount_4 AS 'Amount 4',"
        SQL &= "    Particular_5 AS 'Particular 5', CONCAT(DepartmentCode_5, ' - ', Department(DepartmentCode_5)) AS 'Department 5',"
        SQL &= "    Amount_5 AS 'Amount 5',"
        SQL &= "    Particular_6 AS 'Particular 6', CONCAT(DepartmentCode_6, ' - ', Department(DepartmentCode_6)) AS 'Department 6',"
        SQL &= "    Amount_6 AS 'Amount 6',"
        SQL &= "    Particular_7 AS 'Particular 7', CONCAT(DepartmentCode_7, ' - ', Department(DepartmentCode_7)) AS 'Department 7',"
        SQL &= "    Amount_7 AS 'Amount 7',"
        SQL &= "    Particular_8 AS 'Particular 8', CONCAT(DepartmentCode_8, ' - ', Department(DepartmentCode_8)) AS 'Department 8',"
        SQL &= "    Amount_8 AS 'Amount 8',"
        SQL &= "    Particular_9 AS 'Particular 9', CONCAT(DepartmentCode_9, ' - ', Department(DepartmentCode_9)) AS 'Department 9',"
        SQL &= "    Amount_9 AS 'Amount 9',"
        SQL &= "    Particular_10 AS 'Particular 10', CONCAT(DepartmentCode_10, ' - ', Department(DepartmentCode_10)) AS 'Department 10',"
        SQL &= "    Amount_10 AS 'Amount 10',"
        SQL &= "    Particular_11 AS 'Particular 11', CONCAT(DepartmentCode_11, ' - ', Department(DepartmentCode_11)) AS 'Department 11',"
        SQL &= "    Amount_11 AS 'Amount 11',"
        SQL &= "    Particular_12 AS 'Particular 12', CONCAT(DepartmentCode_12, ' - ', Department(DepartmentCode_12)) AS 'Department 12',"
        SQL &= "    Amount_12 AS 'Amount 12',"
        SQL &= "    Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6 + Amount_7 + Amount_8 + Amount_9 + Amount_10 + Amount_11 + Amount_12 AS 'Total',"
        SQL &= "    Employee(PreparedID) AS 'Prepared By', PreparedID, LOE_Number, "
        SQL &= "    BRANCH(branch_id) AS 'Branch', User_EmplID, Branch_ID, IF(`Status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(Voucher_Status = 'PENDING','FOR APPROVAL',IF(Voucher_Status = 'APPROVED','FOR RELEASING',Voucher_Status))) AS 'Voucher_Status', Employee(ApprovedID) AS 'Approved By', ReceivedBy AS 'Received By', IF(ReceivedDate = '','',DATE_FORMAT(ReceivedDate,'%M %d, %Y')) AS 'Received Date', Head_OTAC, Attach, FromOtherBranch"
        SQL &= "  FROM petty_cash WHERE"
        Dim ForApproval As Boolean
        Dim ForReleasing As Boolean
        Dim Received As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    ForApproval = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Releasing" Then
                    ForReleasing = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Received" Then
                    Received = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If ForApproval = False And ForReleasing = False And Received = False Then
                SQL &= " (`status` IN ('CANCELLED','DELETED','DISAPPROVED') OR voucher_status = 'DISAPPROVED')"
            Else
                SQL &= " `status` IN ('ACTIVE','CANCELLED','DELETED','DISAPPROVED') AND (voucher_status = 'DISAPPROVED' "
                If ForApproval Or ForReleasing Or Received Then
                    SQL &= " OR "
                End If
                If ForApproval Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'PENDING',TRUE)"
                    If ForReleasing Or Received Then
                        SQL &= " OR "
                    End If
                End If
                If ForReleasing Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'APPROVED',TRUE)"
                    If Received Then
                        SQL &= " OR "
                    End If
                End If
                If Received Then
                    SQL &= " IF(`status` = 'ACTIVE',voucher_status = 'RECEIVED',TRUE)"
                End If
                SQL &= ")"
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If ForApproval = False And ForReleasing = False And Received = False Then
            Else
                SQL &= " AND ("
                If ForApproval Then
                    SQL &= " voucher_status = 'PENDING'"
                    If ForReleasing Or Received Then
                        SQL &= " OR "
                    End If
                End If
                If ForReleasing Then
                    SQL &= " voucher_status = 'APPROVED'"
                    If Received Then
                        SQL &= " OR "
                    End If
                End If
                If Received Then
                    SQL &= " voucher_status = 'RECEIVED'"
                End If
                SQL &= ")"
            End If
        End If
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(Trans_Date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        If From_LOE Then
            SQL &= String.Format("    AND LOE_Number = '{0}'", AccountNumber)
        End If
        SQL &= String.Format("  AND Branch_ID IN ({0}) ORDER BY AccountNumber DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn30.Visible = True
            GridColumn30.VisibleIndex = 32
        End If
        GridView1.Columns("Payee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Payee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView1.RowCount > 19 Then
            GridColumn6.Width = 400 - 17
        Else
            GridColumn6.Width = 400
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GetAccountNumber()
        If btnSave.Text = "&Save" Then
            txtAccountNumber.Text = DataObject(String.Format("SELECT CONCAT('PCV-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM petty_cash WHERE branch_id = '{0}' AND YEAR(trans_date) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDate.Value, "yy"), Format(dtpDate.Value, "yyyy-MM-dd")))
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
            txtPurpose.Focus()
        End If
    End Sub

    Private Sub TxtPurpose_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPurpose.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_1.Focus()
        End If
    End Sub

    Private Sub TxtParticular_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_1.Focus()
            cbxDepartment_1.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_1.Focus()
        End If
    End Sub

    Private Sub DAmount_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_2.Focus()
        End If
    End Sub

    Private Sub TxtParticular_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_2.Focus()
            cbxDepartment_2.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_2.Focus()
        End If
    End Sub

    Private Sub DAmount_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_3.Focus()
        End If
    End Sub

    Private Sub TxtParticular_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_3.Focus()
            cbxDepartment_3.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_3_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_3.Focus()
        End If
    End Sub

    Private Sub DAmount_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_4.Focus()
        End If
    End Sub

    Private Sub TxtParticular_4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_4.Focus()
            cbxDepartment_4.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_4_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_4.Focus()
        End If
    End Sub

    Private Sub DAmount_4_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_5.Focus()
        End If
    End Sub

    Private Sub TxtParticular_5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_5.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_5.Focus()
            cbxDepartment_5.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_5_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_5.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_5.Focus()
        End If
    End Sub

    Private Sub DAmount_5_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_5.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_6.Focus()
        End If
    End Sub

    Private Sub TxtParticular_6_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_6.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_6.Focus()
            cbxDepartment_6.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_6_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_6.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_6.Focus()
        End If
    End Sub

    Private Sub DAmount_6_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_6.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_7.Focus()
        End If
    End Sub

    Private Sub TxtParticular_7_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_7.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_7.Focus()
            cbxDepartment_7.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_7_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_7.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_7.Focus()
        End If
    End Sub

    Private Sub DAmount_7_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_7.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_8.Focus()
        End If
    End Sub

    Private Sub TxtParticular_8_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_8.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_8.Focus()
            cbxDepartment_8.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_8_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_8.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_8.Focus()
        End If
    End Sub

    Private Sub DAmount_8_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_8.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_9.Focus()
        End If
    End Sub

    Private Sub TxtParticular_9_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_9.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_9.Focus()
            cbxDepartment_9.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_9_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_9.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_9.Focus()
        End If
    End Sub

    Private Sub DAmount_9_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_9.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_10.Focus()
        End If
    End Sub

    Private Sub TxtParticular_10_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_10.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_10.Focus()
            cbxDepartment_10.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_10_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_10.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_10.Focus()
        End If
    End Sub

    Private Sub DAmount_10_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_10.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_11.Focus()
        End If
    End Sub

    Private Sub TxtParticular_11_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_11.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_11.Focus()
            cbxDepartment_11.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_11_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_11.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_11.Focus()
        End If
    End Sub

    Private Sub DAmount_11_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_11.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtParticular_12.Focus()
        End If
    End Sub

    Private Sub TxtParticular_12_KeyDown(sender As Object, e As KeyEventArgs) Handles txtParticular_12.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDepartment_8.Focus()
            cbxDepartment_8.DroppedDown = True
        End If
    End Sub

    Private Sub CbxDepartment_12_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment_12.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAmount_12.Focus()
        End If
    End Sub

    Private Sub DAmount_12_KeyDown(sender As Object, e As KeyEventArgs) Handles dAmount_12.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPreparedBy.Focus()
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
        LoadPayee("")
        dtpDate.Value = Date.Now
        dtpDate.Enabled = True
        txtPurpose.Text = ""
        txtParticular_1.Text = ""
        cbxPayee.Text = ""
        User_EmplID = 0
        Dept_Head = False
        cbxLiquidate.Enabled = True
        cbxPreparedBy.SelectedValue = Empl_ID
        dAmount_2.Enabled = False
        dAmount_2.Value = 0
        dAmount_3.Enabled = False
        dAmount_3.Value = 0
        dAmount_4.Enabled = False
        dAmount_4.Value = 0
        dAmount_5.Enabled = False
        dAmount_5.Value = 0
        dAmount_6.Enabled = False
        dAmount_6.Value = 0
        dAmount_7.Enabled = False
        dAmount_7.Value = 0
        dAmount_8.Enabled = False
        dAmount_8.Value = 0
        dAmount_9.Enabled = False
        dAmount_9.Value = 0
        dAmount_10.Enabled = False
        dAmount_10.Value = 0
        dAmount_11.Enabled = False
        dAmount_11.Value = 0
        dAmount_12.Enabled = False
        dAmount_12.Value = 0

        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnApprove.Visible = False
        btnReceive.Visible = False
        btnApprove.Enabled = False
        btnReceive.Enabled = False

        cbxPreparedBy.SelectedValue = Empl_ID
        txtApproved.Text = ""
        txtReceived.Text = ""
        txtReceivedDate.Text = ""
        LOE_Number = ""
        btnDisapprove.Visible = False

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
        If dTotal.Value = 0 Then
            MsgBox("Please fill Amount for Petty Cash.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxPreparedBy.Text = "" Or cbxPreparedBy.SelectedIndex = -1 Then
            MsgBox("Please select Prepared By.", MsgBoxStyle.Information, "Info")
            cbxPreparedBy.DroppedDown = True
            Exit Sub
        End If
        If dTotal.Value > 1000 Then
            MsgBox("Maximum amount for Petty Cash is up to P1,000.00 ONLY please check your data.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_Prep As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
        If btnSave.Text = "&Save" Then
            If cbxLiquidate.Checked = False Then
                If If(cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "", 0, CInt(drv("Cash Advance"))) > 0 Then
                    If MsgBoxYes(String.Format("{0} have a {1} unliquidated cash advances, are you sure that this petty cash is not for liquidation of cash advance?", cbxPayee.Text, CInt(drv("Cash Advance")))) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                'SEND EMAIL AND SMS TO SELECTED PAYEE *******************************************************************
                Dim Msg As String = ""
                Dim Subject As String = String.Format("Petty Cash Voucher {0}.", txtAccountNumber.Text)
                If cbxPayee.SelectedIndex <> -1 Then
                    If cbxPayee.SelectedValue <> cbxPreparedBy.SelectedValue And drv("Type") = "E" Then
                        If MsgBoxYes(String.Format("You are creating a Petty Cash Voucher for {0}, This will notify him/her through Email and SMS, would you like to proceed?", cbxPayee.Text)) = MsgBoxResult.Yes Then
                            Msg = String.Format("Good day {0}," & vbCrLf, cbxPayee.Text)
                            Msg &= String.Format("{0} create a new Petty Cash Voucher under your name with a Total Amount of P{1}." & vbCrLf, Empl_Name, dTotal.Text)
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
                End If
                Code = GenerateOTAC()
                GetAccountNumber()
                '*********** A U T O   N O T I F I C A T I O N *************************************************************************
                If Auto_Notification Then
                    'Dim Msg As String = ""
                    'Dim Subject As String = String.Format("Petty Cash Voucher {0}.", txtAccountNumber.Text)
                    Dim DT_Head As DataTable
                    Dim EmailTo As String = ""
                    Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    If If(cbxPayee.SelectedIndex = -1, False, If(drv("Type") = "S", False, drv("Head") = 0)) Or Branch_ID > 0 Or drv("department_id") <> drv_Prep("department_id") Then
                        If Branch_ID = 0 Then
                            If cbxOther.Checked Then
                                DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = '{0}' AND Branch_ID IN ('{1}','{2}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", drv_Prep("department_id"), Branch_ID, MFBranch_ID))
                            Else
                                DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id IN ('{0}','{1}') AND Branch_ID IN ('{2}','{3}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", If(NotifyPayeeApprover, drv("department_id"), False), drv_Prep("department_id"), Branch_ID, MFBranch_ID))
                            End If
                            For x As Integer = 0 To DT_Head.Rows.Count - 1
                                Msg = String.Format("Good day," & vbCrLf, DT_Head(x)("Employee"))
                                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head approval of Petty Cash of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
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
                                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for department head approval of Petty Cash of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
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
                        If If(cbxPayee.SelectedIndex = -1, 0, If(drv("Type") = "S", 0, DT_PCV_Approver.Rows.Count > 0)) Then
                            Msg = String.Format("Good day," & vbCrLf)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Petty Cash of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_PCV_Approver(0)("A1Phone") = "" Then
                            Else
                                SendSMS(DT_PCV_Approver(0)("A1Phone"), Msg, True)
                            End If
                            If DT_PCV_Approver(0)("A2Phone") = "" Then
                            Else
                                SendSMS(DT_PCV_Approver(0)("A2Phone"), Msg, True)
                            End If
                            If DT_PCV_Approver(0)("A3Phone") = "" Then
                            Else
                                SendSMS(DT_PCV_Approver(0)("A3Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_PCV_Approver(0)("A1Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_PCV_Approver(0)("A1Email") & ", "
                            End If
                            If DT_PCV_Approver(0)("A2Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_PCV_Approver(0)("A2Email") & ", "
                            End If
                            If DT_PCV_Approver(0)("A3Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_PCV_Approver(0)("A3Email") & ", "
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
                                    Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Petty Cash of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
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
                                        Generate_PCV(False, FName)
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
                        Generate_PCV(False, FName)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
                End If
Here:

                Dim SQL As String = "INSERT INTO petty_cash SET"
                SQL &= String.Format(" Payee_ID = '{0}', ", ValidateComboBox(cbxPayee))
                SQL &= String.Format(" Payee_Type = '{0}', ", If(cbxPayee.SelectedIndex = -1, "", drv("Type")))
                SQL &= String.Format(" Payee = '{0}', ", cbxPayee.Text)
                SQL &= String.Format(" Trans_Date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" AccountNumber = '{0}', ", txtAccountNumber.Text)
                SQL &= String.Format(" CANumber = '{0}', ", If(cbxLiquidate.Checked, If(cbxPayee.SelectedIndex = -1, "", drv("AccountNumber")), ""))
                SQL &= String.Format(" Purpose = '{0}', ", txtPurpose.Text.Trim.InsertQuote)
                SQL &= String.Format(" Particular_1 = '{0}', ", txtParticular_1.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_1 = '{0}', ", ValidateComboBox(cbxDepartment_1))
                SQL &= String.Format(" Amount_1 = '{0}', ", dAmount_1.Value)
                SQL &= String.Format(" Particular_2 = '{0}', ", txtParticular_2.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_2 = '{0}', ", ValidateComboBox(cbxDepartment_2))
                SQL &= String.Format(" Amount_2 = '{0}', ", dAmount_2.Value)
                SQL &= String.Format(" Particular_3 = '{0}', ", txtParticular_3.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_3 = '{0}', ", ValidateComboBox(cbxDepartment_3))
                SQL &= String.Format(" Amount_3 = '{0}', ", dAmount_3.Value)
                SQL &= String.Format(" Particular_4 = '{0}', ", txtParticular_4.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_4 = '{0}', ", ValidateComboBox(cbxDepartment_4))
                SQL &= String.Format(" Amount_4 = '{0}', ", dAmount_4.Value)
                SQL &= String.Format(" Particular_5 = '{0}', ", txtParticular_5.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_5 = '{0}', ", ValidateComboBox(cbxDepartment_5))
                SQL &= String.Format(" Amount_5 = '{0}', ", dAmount_5.Value)
                SQL &= String.Format(" Particular_6 = '{0}', ", txtParticular_6.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_6 = '{0}', ", ValidateComboBox(cbxDepartment_6))
                SQL &= String.Format(" Amount_6 = '{0}', ", dAmount_6.Value)
                SQL &= String.Format(" Particular_7 = '{0}', ", txtParticular_7.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_7 = '{0}', ", ValidateComboBox(cbxDepartment_7))
                SQL &= String.Format(" Amount_7 = '{0}', ", dAmount_7.Value)
                SQL &= String.Format(" Particular_8 = '{0}', ", txtParticular_8.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_8 = '{0}', ", ValidateComboBox(cbxDepartment_8))
                SQL &= String.Format(" Amount_8 = '{0}', ", dAmount_8.Value)
                SQL &= String.Format(" Particular_9 = '{0}', ", txtParticular_9.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_9 = '{0}', ", ValidateComboBox(cbxDepartment_9))
                SQL &= String.Format(" Amount_9 = '{0}', ", dAmount_9.Value)
                SQL &= String.Format(" Particular_10 = '{0}', ", txtParticular_10.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_10 = '{0}', ", ValidateComboBox(cbxDepartment_10))
                SQL &= String.Format(" Amount_10 = '{0}', ", dAmount_10.Value)
                SQL &= String.Format(" Particular_11 = '{0}', ", txtParticular_11.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_11 = '{0}', ", ValidateComboBox(cbxDepartment_11))
                SQL &= String.Format(" Amount_11 = '{0}', ", dAmount_11.Value)
                SQL &= String.Format(" Particular_12 = '{0}', ", txtParticular_12.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_12 = '{0}', ", ValidateComboBox(cbxDepartment_12))
                SQL &= String.Format(" Amount_12 = '{0}', ", dAmount_12.Value)
                SQL &= String.Format(" PreparedID = '{0}', ", cbxPreparedBy.SelectedValue)
                SQL &= String.Format(" User_Code = '{0}', ", User_Code)
                SQL &= String.Format(" User_EmplID = '{0}', ", Empl_ID)
                SQL &= String.Format(" Head_OTAC = '{0}', ", Code)
                SQL &= " ReceivedID = '0', "
                SQL &= " ReceivedDate = '', "
                SQL &= " ApprovedID = '0', "
                SQL &= String.Format(" FromOtherBranch = {0}, ", If(cbxOther.Checked, 1, 0))
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                If cbxPayee.SelectedIndex = -1 Then
                Else
                    If drv("Type") = "C" Then 'FROM CASH ADVANCE ********************************************
                        SQL &= String.Format("UPDATE cash_advance SET Liquidated = 'Y' WHERE AccountNumber = '{0}';", drv("AccountNumber"))
                    End If
                End If
                DataObject(SQL)

                Logs("Petty Cash", "Save", String.Format("Add new Petty Cash Voucher for {0} with Amount {1}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text), "", "", "", "")
                If From_CAS Or From_LOE Then
                    btnSave.DialogResult = DialogResult.OK
                    btnSave.PerformClick()
                End If
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!" & mEmail, MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim CancelledID As Integer = DataObject(String.Format("SELECT IFNULL(ID,0) FROM petty_cash WHERE ID = {0} AND `status` IN ('CANCELLED','DISAPPROVED')", ID))
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
                    If txtApproved.Text = "" Then
                        Dim Msg As String = ""
                        Dim DT_Head As DataTable
                        Code = GenerateOTAC()
                        Dim EmailTo As String = ""
                        Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                        Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                        If If(cbxPayee.SelectedIndex = -1, False, drv("Head") = 0) Or Branch_ID > 0 Then
                            If Branch_ID = 0 Then
                                If cbxOther.Checked Then
                                    DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department LIKE '%ADMIN%' AND Branch_ID IN ('{1}','{2}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", drv("department_id"), Branch_ID, MFBranch_ID))
                                Else
                                    DT_Head = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = '{0}' AND Branch_ID IN ('{1}','{2}') AND (SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) = 1;", drv("department_id"), Branch_ID, MFBranch_ID))
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
                            If If(cbxPayee.SelectedIndex = -1, 0, DT_PCV_Approver.Rows.Count > 0) Then
                                Msg = String.Format("Good day," & vbCrLf)
                                Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                                Msg &= "Thank you!"
                                '******* SEND SMS *********************************************************************************
                                If DT_PCV_Approver(0)("A1Phone") = "" Then
                                Else
                                    SendSMS(DT_PCV_Approver(0)("A1Phone"), Msg, True)
                                End If
                                If DT_PCV_Approver(0)("A2Phone") = "" Then
                                Else
                                    SendSMS(DT_PCV_Approver(0)("A2Phone"), Msg, True)
                                End If
                                If DT_PCV_Approver(0)("A3Phone") = "" Then
                                Else
                                    SendSMS(DT_PCV_Approver(0)("A3Phone"), Msg, True)
                                End If
                                '******* SEND EMAIL *********************************************************************************
                                If DT_PCV_Approver(0)("A1Email") = "" Then
                                Else
                                    EmailTo = EmailTo & DT_PCV_Approver(0)("A1Email") & ", "
                                End If
                                If DT_PCV_Approver(0)("A2Email") = "" Then
                                Else
                                    EmailTo = EmailTo & DT_PCV_Approver(0)("A2Email") & ", "
                                End If
                                If DT_PCV_Approver(0)("A3Email") = "" Then
                                Else
                                    EmailTo = EmailTo & DT_PCV_Approver(0)("A3Email") & ", "
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
                                            Subject = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "] [UPDATED]"
                                            AttachmentFiles = New ArrayList()
                                            FName = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                                            Generate_PCV(False, FName)
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
                            Generate_PCV(False, FName)
                            AttachmentFiles.Add(FName)
                            SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                        End If
                    End If
                End If
HereV2:

                Dim SQL As String = "UPDATE petty_cash SET"
                SQL &= String.Format(" Trans_Date = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" Purpose = '{0}', ", txtPurpose.Text.Trim.InsertQuote)
                SQL &= String.Format(" Particular_1 = '{0}', ", txtParticular_1.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_1 = '{0}', ", ValidateComboBox(cbxDepartment_1))
                SQL &= String.Format(" Amount_1 = '{0}', ", dAmount_1.Value)
                SQL &= String.Format(" Particular_2 = '{0}', ", txtParticular_2.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_2 = '{0}', ", ValidateComboBox(cbxDepartment_2))
                SQL &= String.Format(" Amount_2 = '{0}', ", dAmount_2.Value)
                SQL &= String.Format(" Particular_3 = '{0}', ", txtParticular_3.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_3 = '{0}', ", ValidateComboBox(cbxDepartment_3))
                SQL &= String.Format(" Amount_3 = '{0}', ", dAmount_3.Value)
                SQL &= String.Format(" Particular_4 = '{0}', ", txtParticular_4.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_4 = '{0}', ", ValidateComboBox(cbxDepartment_4))
                SQL &= String.Format(" Amount_4 = '{0}', ", dAmount_4.Value)
                SQL &= String.Format(" Particular_5 = '{0}', ", txtParticular_5.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_5 = '{0}', ", ValidateComboBox(cbxDepartment_5))
                SQL &= String.Format(" Amount_5 = '{0}', ", dAmount_5.Value)
                SQL &= String.Format(" Particular_6 = '{0}', ", txtParticular_6.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_6 = '{0}', ", ValidateComboBox(cbxDepartment_6))
                SQL &= String.Format(" Amount_6 = '{0}', ", dAmount_6.Value)
                SQL &= String.Format(" Particular_7 = '{0}', ", txtParticular_7.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_7 = '{0}', ", ValidateComboBox(cbxDepartment_7))
                SQL &= String.Format(" Amount_7 = '{0}', ", dAmount_7.Value)
                SQL &= String.Format(" Particular_8 = '{0}', ", txtParticular_8.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_8 = '{0}', ", ValidateComboBox(cbxDepartment_8))
                SQL &= String.Format(" Particular_9 = '{0}', ", txtParticular_9.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_9 = '{0}', ", ValidateComboBox(cbxDepartment_9))
                SQL &= String.Format(" Amount_9 = '{0}', ", dAmount_9.Value)
                SQL &= String.Format(" Particular_10 = '{0}', ", txtParticular_10.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_10 = '{0}', ", ValidateComboBox(cbxDepartment_10))
                SQL &= String.Format(" Amount_10 = '{0}', ", dAmount_10.Value)
                SQL &= String.Format(" Particular_11 = '{0}', ", txtParticular_11.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_11 = '{0}', ", ValidateComboBox(cbxDepartment_11))
                SQL &= String.Format(" Amount_11 = '{0}', ", dAmount_11.Value)
                SQL &= String.Format(" Particular_12 = '{0}', ", txtParticular_12.Text.Trim.InsertQuote)
                SQL &= String.Format(" DepartmentCode_12 = '{0}', ", ValidateComboBox(cbxDepartment_12))
                SQL &= String.Format(" Amount_12 = '{0}', ", dAmount_12.Value)
                If txtApproved.Text = "" Then
                    SQL &= String.Format(" Head_OTAC = '{0}', ", Code)
                End If
                SQL &= String.Format(" Amount_8 = '{0}' ", dAmount_8.Value)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)

                Logs("Petty Cash", "Update", Reason, Changes(), "", "", "")
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
            If txtParticular_1.Text = txtParticular_1.Tag Then
            Else
                Change &= String.Format("Change Particular 1 from {0} to {1}. ", txtParticular_1.Tag.ToString.Trim.InsertQuote, txtParticular_1.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_1.Text = cbxDepartment_1.Tag Then
            Else
                Change &= String.Format("Change Department 1 from {0} to {1}. ", cbxDepartment_1.Tag, cbxDepartment_1.Text)
            End If
            If dAmount_1.Text = dAmount_1.Tag Then
            Else
                Change &= String.Format("Change Amount 1 from {0} to {1}. ", dAmount_1.Tag, dAmount_1.Text)
            End If
            If txtParticular_2.Text = txtParticular_2.Tag Then
            Else
                Change &= String.Format("Change Particular 2 from {0} to {1}. ", txtParticular_2.Tag.ToString.Trim.InsertQuote, txtParticular_2.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_2.Text = cbxDepartment_2.Tag Then
            Else
                Change &= String.Format("Change Department 2 from {0} to {1}. ", cbxDepartment_2.Tag, cbxDepartment_2.Text)
            End If
            If dAmount_2.Text = dAmount_2.Tag Then
            Else
                Change &= String.Format("Change Amount 2 from {0} to {1}. ", dAmount_2.Tag, dAmount_2.Text)
            End If
            If txtParticular_3.Text = txtParticular_3.Tag Then
            Else
                Change &= String.Format("Change Particular 3 from {0} to {1}. ", txtParticular_3.Tag.ToString.Trim.InsertQuote, txtParticular_3.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_3.Text = cbxDepartment_3.Tag Then
            Else
                Change &= String.Format("Change Department 3 from {0} to {1}. ", cbxDepartment_3.Tag, cbxDepartment_3.Text)
            End If
            If dAmount_3.Text = dAmount_3.Tag Then
            Else
                Change &= String.Format("Change Amount 3 from {0} to {1}. ", dAmount_3.Tag, dAmount_3.Text)
            End If
            If txtParticular_4.Text = txtParticular_4.Tag Then
            Else
                Change &= String.Format("Change Particular 4 from {0} to {1}. ", txtParticular_4.Tag.ToString.Trim.InsertQuote, txtParticular_4.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_4.Text = cbxDepartment_4.Tag Then
            Else
                Change &= String.Format("Change Department 4 from {0} to {1}. ", cbxDepartment_4.Tag, cbxDepartment_4.Text)
            End If
            If dAmount_4.Text = dAmount_4.Tag Then
            Else
                Change &= String.Format("Change Amount 4 from {0} to {1}. ", dAmount_4.Tag, dAmount_4.Text)
            End If
            If txtParticular_5.Text = txtParticular_5.Tag Then
            Else
                Change &= String.Format("Change Particular 5 from {0} to {1}. ", txtParticular_5.Tag.ToString.Trim.InsertQuote, txtParticular_5.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_5.Text = cbxDepartment_5.Tag Then
            Else
                Change &= String.Format("Change Department 5 from {0} to {1}. ", cbxDepartment_5.Tag, cbxDepartment_5.Text)
            End If
            If dAmount_5.Text = dAmount_5.Tag Then
            Else
                Change &= String.Format("Change Amount 5 from {0} to {1}. ", dAmount_5.Tag, dAmount_5.Text)
            End If
            If txtParticular_6.Text = txtParticular_6.Tag Then
            Else
                Change &= String.Format("Change Particular 6 from {0} to {1}. ", txtParticular_6.Tag.ToString.Trim.InsertQuote, txtParticular_6.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_6.Text = cbxDepartment_6.Tag Then
            Else
                Change &= String.Format("Change Department 6 from {0} to {1}. ", cbxDepartment_6.Tag, cbxDepartment_6.Text)
            End If
            If dAmount_6.Text = dAmount_6.Tag Then
            Else
                Change &= String.Format("Change Amount 6 from {0} to {1}. ", dAmount_6.Tag, dAmount_6.Text)
            End If
            If txtParticular_7.Text = txtParticular_7.Tag Then
            Else
                Change &= String.Format("Change Particular 7 from {0} to {1}. ", txtParticular_7.Tag.ToString.Trim.InsertQuote, txtParticular_7.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_7.Text = cbxDepartment_7.Tag Then
            Else
                Change &= String.Format("Change Department 7 from {0} to {1}. ", cbxDepartment_7.Tag, cbxDepartment_7.Text)
            End If
            If dAmount_7.Text = dAmount_7.Tag Then
            Else
                Change &= String.Format("Change Amount 7 from {0} to {1}. ", dAmount_7.Tag, dAmount_7.Text)
            End If
            If txtParticular_8.Text = txtParticular_8.Tag Then
            Else
                Change &= String.Format("Change Particular 8 from {0} to {1}. ", txtParticular_8.Tag.ToString.Trim.InsertQuote, txtParticular_8.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_8.Text = cbxDepartment_8.Tag Then
            Else
                Change &= String.Format("Change Department 8 from {0} to {1}. ", cbxDepartment_8.Tag, cbxDepartment_8.Text)
            End If
            If dAmount_8.Text = dAmount_8.Tag Then
            Else
                Change &= String.Format("Change Amount 8 from {0} to {1}. ", dAmount_8.Tag, dAmount_8.Text)
            End If
            If txtParticular_9.Text = txtParticular_9.Tag Then
            Else
                Change &= String.Format("Change Particular 9 from {0} to {1}. ", txtParticular_9.Tag.ToString.Trim.InsertQuote, txtParticular_9.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_9.Text = cbxDepartment_9.Tag Then
            Else
                Change &= String.Format("Change Department 9 from {0} to {1}. ", cbxDepartment_9.Tag, cbxDepartment_9.Text)
            End If
            If dAmount_9.Text = dAmount_9.Tag Then
            Else
                Change &= String.Format("Change Amount 9 from {0} to {1}. ", dAmount_9.Tag, dAmount_9.Text)
            End If
            If txtParticular_10.Text = txtParticular_10.Tag Then
            Else
                Change &= String.Format("Change Particular 10 from {0} to {1}. ", txtParticular_10.Tag.ToString.Trim.InsertQuote, txtParticular_10.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_10.Text = cbxDepartment_10.Tag Then
            Else
                Change &= String.Format("Change Department 10 from {0} to {1}. ", cbxDepartment_10.Tag, cbxDepartment_10.Text)
            End If
            If dAmount_10.Text = dAmount_10.Tag Then
            Else
                Change &= String.Format("Change Amount 10 from {0} to {1}. ", dAmount_10.Tag, dAmount_10.Text)
            End If
            If txtParticular_11.Text = txtParticular_11.Tag Then
            Else
                Change &= String.Format("Change Particular 11 from {0} to {1}. ", txtParticular_11.Tag.ToString.Trim.InsertQuote, txtParticular_11.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_11.Text = cbxDepartment_11.Tag Then
            Else
                Change &= String.Format("Change Department 11 from {0} to {1}. ", cbxDepartment_11.Tag, cbxDepartment_11.Text)
            End If
            If dAmount_11.Text = dAmount_11.Tag Then
            Else
                Change &= String.Format("Change Amount 11 from {0} to {1}. ", dAmount_11.Tag, dAmount_11.Text)
            End If
            If txtParticular_12.Text = txtParticular_12.Tag Then
            Else
                Change &= String.Format("Change Particular 12 from {0} to {1}. ", txtParticular_12.Tag.ToString.Trim.InsertQuote, txtParticular_12.Text.Trim.InsertQuote)
            End If
            If cbxDepartment_12.Text = cbxDepartment_12.Tag Then
            Else
                Change &= String.Format("Change Department 12 from {0} to {1}. ", cbxDepartment_12.Tag, cbxDepartment_12.Text)
            End If
            If dAmount_12.Text = dAmount_12.Tag Then
            Else
                Change &= String.Format("Change Amount 12 from {0} to {1}. ", dAmount_12.Tag, dAmount_12.Text)
            End If
            If cbxPreparedBy.Text = cbxPreparedBy.Tag Then
            Else
                Change &= String.Format("Change Prepared By from {0} to {1}. ", cbxPreparedBy.Tag, cbxPreparedBy.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Petty Cash Voucher - Changes", ex.Message.ToString)
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
            Dim SQL As String = ""
            If drv("Type") = "C" Then 'FROM CASH ADVANCE ********************************************
                SQL = String.Format("UPDATE cash_advance SET Liquidated = 'N' WHERE AccountNumber = '{0}';", drv("AccountNumber"))
                If LOE_Number <> "" Then
                    DataObject(String.Format("UPDATE liquidation_main SET Refund = 0  WHERE AccountNumber = '{0}';", LOE_Number))
                End If
            ElseIf drv("Type") = "E" Then 'CHECK IF FROM PETTY CASH THEN GI TAG FOR LIQUIDATION FROM CASH ADVANCE ********************************************
                Dim CANumber As String = DataObject(String.Format("SELECT CANumber FROM petty_cash WHERE ID = {0};", ID))
                If CANumber <> "" Then
                    SQL = String.Format("UPDATE cash_advance SET Liquidated = 'N' WHERE AccountNumber = '{0}';", CANumber)
                End If
            End If
            SQL &= String.Format("UPDATE petty_cash SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID)
            DataObject(SQL)
            Logs("Petty Cash Voucher", "Cancel", Reason, String.Format("Cancel Petty Cash Voucher of {0} with Amount {1}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub Generate_PCV(Show As Boolean, FName As String)
        Dim Report As New RptPettyCashVoucher
        With Report
            .Name = String.Format("Petty Cash Voucher of {0} - {1}", cbxPayee.Text, txtAccountNumber.Text)

            .lblPayee.Text = cbxPayee.Text
            .lblDate.Text = dtpDate.Text
            .lblAccountNumber.Text = txtAccountNumber.Text
            '.lblTIN_Payee.Text = txtTIN.Text
            .lblPurpose.Text = txtPurpose.Text
            .lblParticular_1.Text = txtParticular_1.Text
            .lblDepartment_1.Text = cbxDepartment_1.Text
            .lblAmount_1.Text = dAmount_1.Text
            .lblParticular_2.Text = txtParticular_2.Text
            .lblDepartment_2.Text = cbxDepartment_2.Text
            .lblAmount_2.Text = dAmount_2.Text
            .lblParticular_3.Text = txtParticular_3.Text
            .lblDepartment_3.Text = cbxDepartment_3.Text
            .lblAmount_3.Text = dAmount_3.Text
            .lblParticular_4.Text = txtParticular_4.Text
            .lblDepartment_4.Text = cbxDepartment_4.Text
            .lblAmount_4.Text = dAmount_4.Text
            .lblParticular_5.Text = txtParticular_5.Text
            .lblDepartment_5.Text = cbxDepartment_5.Text
            .lblAmount_5.Text = dAmount_5.Text
            .lblParticular_6.Text = txtParticular_6.Text
            .lblDepartment_6.Text = cbxDepartment_6.Text
            .lblAmount_6.Text = dAmount_6.Text
            .lblParticular_7.Text = txtParticular_7.Text
            .lblDepartment_7.Text = cbxDepartment_7.Text
            .lblAmount_7.Text = dAmount_7.Text
            .lblParticular_8.Text = txtParticular_8.Text
            .lblDepartment_8.Text = cbxDepartment_8.Text
            .lblAmount_8.Text = dAmount_8.Text
            .lblParticular_9.Text = txtParticular_9.Text
            .lblDepartment_9.Text = cbxDepartment_9.Text
            .lblAmount_9.Text = dAmount_9.Text
            .lblParticular_10.Text = txtParticular_10.Text
            .lblDepartment_10.Text = cbxDepartment_10.Text
            .lblAmount_10.Text = dAmount_10.Text
            .lblParticular_11.Text = txtParticular_11.Text
            .lblDepartment_11.Text = cbxDepartment_11.Text
            .lblAmount_11.Text = dAmount_11.Text
            .lblParticular_12.Text = txtParticular_12.Text
            .lblDepartment_12.Text = cbxDepartment_12.Text
            .lblAmount_12.Text = dAmount_12.Text
            .lblTotal.Text = dTotal.Text

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
            Generate_PCV(True, "")
            Logs("Petty Cash", "Print", "[SENSITIVE] Print Petty Cash " & txtAccountNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("PETTY CASH LIST", GridControl1)

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
            Logs("Petty Cash", "Print", "[SENSITIVE] Print Petty Cash List", "", "", "", "")
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or If(From_CAS Or From_LOE, e.KeyCode = Keys.Escape, 0) Then
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
                LoadPayee("")
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
        cbxLiquidate.Enabled = False
        ID = GridView1.GetFocusedRowCellValue("ID")
        If GridView1.GetFocusedRowCellValue("Payee_Type") = "C" Then
            cbxLiquidate.Checked = True
        Else
            cbxLiquidate.Checked = False
        End If
        cbxPayee.Enabled = False
        dtpDate.Enabled = False
        With GridView1
            cbxOther.Enabled = False
            If .GetFocusedRowCellValue("FromOtherBranch") = True Then
                cbxOther.Checked = True
            Else
                cbxOther.Checked = False
            End If
            LoadPayee(.GetFocusedRowCellValue("Account Number"))
            If .GetFocusedRowCellValue("Payee_Type") = "" Then
                cbxPayee.SelectedIndex = -1
            End If
            cbxPayee.Text = .GetFocusedRowCellValue("Payee")
            cbxPayee.Tag = .GetFocusedRowCellValue("Payee")
            dtpDate.Value = .GetFocusedRowCellValue("Date")
            dtpDate.Tag = .GetFocusedRowCellValue("Date")
            txtAccountNumber.Text = .GetFocusedRowCellValue("Account Number")
            txtPurpose.Text = .GetFocusedRowCellValue("Purpose")
            txtPurpose.Tag = .GetFocusedRowCellValue("Purpose")
            txtParticular_1.Text = .GetFocusedRowCellValue("Particular 1")
            txtParticular_1.Tag = .GetFocusedRowCellValue("Particular 1")
            cbxDepartment_1.Text = .GetFocusedRowCellValue("Department 1").ToString
            cbxDepartment_1.Tag = .GetFocusedRowCellValue("Department 1").ToString
            dAmount_1.Value = .GetFocusedRowCellValue("Amount 1")
            dAmount_1.Tag = .GetFocusedRowCellValue("Amount 1")
            txtParticular_2.Text = .GetFocusedRowCellValue("Particular 2")
            txtParticular_2.Tag = .GetFocusedRowCellValue("Particular 2")
            cbxDepartment_2.Text = .GetFocusedRowCellValue("Department 2").ToString
            cbxDepartment_2.Tag = .GetFocusedRowCellValue("Department 2").ToString
            dAmount_2.Value = .GetFocusedRowCellValue("Amount 2")
            dAmount_2.Tag = .GetFocusedRowCellValue("Amount 2")
            txtParticular_3.Text = .GetFocusedRowCellValue("Particular 3")
            txtParticular_3.Tag = .GetFocusedRowCellValue("Particular 3")
            cbxDepartment_3.Text = .GetFocusedRowCellValue("Department 3").ToString
            cbxDepartment_3.Tag = .GetFocusedRowCellValue("Department 3").ToString
            dAmount_3.Value = .GetFocusedRowCellValue("Amount 3")
            dAmount_3.Tag = .GetFocusedRowCellValue("Amount 3")
            txtParticular_4.Text = .GetFocusedRowCellValue("Particular 4")
            txtParticular_4.Tag = .GetFocusedRowCellValue("Particular 4")
            cbxDepartment_4.Text = .GetFocusedRowCellValue("Department 4").ToString
            cbxDepartment_4.Tag = .GetFocusedRowCellValue("Department 4").ToString
            dAmount_4.Value = .GetFocusedRowCellValue("Amount 4")
            dAmount_4.Tag = .GetFocusedRowCellValue("Amount 4")
            txtParticular_5.Text = .GetFocusedRowCellValue("Particular 5")
            txtParticular_5.Tag = .GetFocusedRowCellValue("Particular 5")
            cbxDepartment_5.Text = .GetFocusedRowCellValue("Department 5").ToString
            cbxDepartment_5.Tag = .GetFocusedRowCellValue("Department 5").ToString
            dAmount_5.Value = .GetFocusedRowCellValue("Amount 5")
            dAmount_5.Tag = .GetFocusedRowCellValue("Amount 5")
            txtParticular_6.Text = .GetFocusedRowCellValue("Particular 6")
            txtParticular_6.Tag = .GetFocusedRowCellValue("Particular 6")
            cbxDepartment_6.Text = .GetFocusedRowCellValue("Department 6").ToString
            cbxDepartment_6.Tag = .GetFocusedRowCellValue("Department 6").ToString
            dAmount_6.Value = .GetFocusedRowCellValue("Amount 6")
            dAmount_6.Tag = .GetFocusedRowCellValue("Amount 6")
            txtParticular_7.Text = .GetFocusedRowCellValue("Particular 7")
            txtParticular_7.Tag = .GetFocusedRowCellValue("Particular 7")
            cbxDepartment_7.Text = .GetFocusedRowCellValue("Department 7").ToString
            cbxDepartment_7.Tag = .GetFocusedRowCellValue("Department 7").ToString
            dAmount_7.Value = .GetFocusedRowCellValue("Amount 7")
            dAmount_7.Tag = .GetFocusedRowCellValue("Amount 7")
            txtParticular_8.Text = .GetFocusedRowCellValue("Particular 8")
            txtParticular_8.Tag = .GetFocusedRowCellValue("Particular 8")
            cbxDepartment_8.Text = .GetFocusedRowCellValue("Department 8").ToString
            cbxDepartment_8.Tag = .GetFocusedRowCellValue("Department 8").ToString
            dAmount_8.Value = .GetFocusedRowCellValue("Amount 8")
            dAmount_8.Tag = .GetFocusedRowCellValue("Amount 8")
            txtParticular_9.Text = .GetFocusedRowCellValue("Particular 9")
            txtParticular_9.Tag = .GetFocusedRowCellValue("Particular 9")
            cbxDepartment_9.Text = .GetFocusedRowCellValue("Department 9").ToString
            cbxDepartment_9.Tag = .GetFocusedRowCellValue("Department 9").ToString
            dAmount_9.Value = .GetFocusedRowCellValue("Amount 9")
            dAmount_9.Tag = .GetFocusedRowCellValue("Amount 9")
            txtParticular_10.Text = .GetFocusedRowCellValue("Particular 10")
            txtParticular_10.Tag = .GetFocusedRowCellValue("Particular 10")
            cbxDepartment_10.Text = .GetFocusedRowCellValue("Department 10").ToString
            cbxDepartment_10.Tag = .GetFocusedRowCellValue("Department 10").ToString
            dAmount_10.Value = .GetFocusedRowCellValue("Amount 10")
            dAmount_10.Tag = .GetFocusedRowCellValue("Amount 10")
            txtParticular_11.Text = .GetFocusedRowCellValue("Particular 11")
            txtParticular_11.Tag = .GetFocusedRowCellValue("Particular 11")
            cbxDepartment_11.Text = .GetFocusedRowCellValue("Department 11").ToString
            cbxDepartment_11.Tag = .GetFocusedRowCellValue("Department 11").ToString
            dAmount_11.Value = .GetFocusedRowCellValue("Amount 11")
            dAmount_11.Tag = .GetFocusedRowCellValue("Amount 11")
            txtParticular_12.Text = .GetFocusedRowCellValue("Particular 12")
            txtParticular_12.Tag = .GetFocusedRowCellValue("Particular 12")
            cbxDepartment_12.Text = .GetFocusedRowCellValue("Department 12").ToString
            cbxDepartment_12.Tag = .GetFocusedRowCellValue("Department 12").ToString
            dAmount_12.Value = .GetFocusedRowCellValue("Amount 12")
            dAmount_12.Tag = .GetFocusedRowCellValue("Amount 12")
            cbxPreparedBy.Text = .GetFocusedRowCellValue("Prepared By")
            cbxPreparedBy.Tag = .GetFocusedRowCellValue("Prepared By")

            txtApproved.Text = .GetFocusedRowCellValue("Approved By")
            txtReceived.Text = .GetFocusedRowCellValue("Received By")
            txtReceivedDate.Text = .GetFocusedRowCellValue("Received Date")

            User_EmplID = .GetFocusedRowCellValue("User_EmplID")
            Code = .GetFocusedRowCellValue("Head_OTAC")
            LOE_Number = .GetFocusedRowCellValue("LOE_Number")
        End With
        SuperTabControl1.SelectedTab = tabSetup
        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_P As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
        If cbxPayee.SelectedIndex = -1 Then
        Else
            Dept_Head = DataObject(String.Format("SELECT IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) FROM employee_setup WHERE ID = '{0}' AND Branch_ID IN ('{1}','{4}') AND IF(Department_ID = 0,TRUE,Department_ID IN ('{2}','{3}'));", Empl_ID, GridView1.GetFocusedRowCellValue("Branch_ID"), If(NotifyPayeeApprover, drv("department_ID"), False), drv_P("department_ID"), MFBranch_ID))
        End If
        If GridView1.GetFocusedRowCellValue("Voucher_Status") = "PENDING" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR APPROVAL" Then
            btnApprove.Visible = True
            If User_Type = "ADMIN" Or Department.ToUpper.Contains("ADMINISTRATIVE") Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Or Dept_Head Or ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A3ID"), 0) = Empl_ID Then
                If Department.ToUpper.Contains("ADMINISTRATIVE") Then
                    Dim Signatory As Boolean
                    For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                        If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                            Signatory = True
                            Exit For
                        End If
                    Next
                    If Signatory = False And Dept_Head = False And Empl_ID <> GridView1.GetFocusedRowCellValue("User_EmplID") And Empl_ID <> cbxPayee.SelectedValue Then
                        GoTo Here
                    End If
                End If
                btnModify.Enabled = True
                If GridView1.GetFocusedRowCellValue("Payee_ID") > 0 And Branch_ID = 0 Then
                    Dim Head As Boolean = DataObject(String.Format("SELECT Head FROM position_setup WHERE ID = (SELECT position_id FROM employee_setup WHERE ID = {0});", GridView1.GetFocusedRowCellValue("Payee_ID")))
                    If Head = False And drv("department_ID") <> Dept_ID Then
                        If Department.ToUpper.Contains("ADMINISTRATIVE") Or Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Or (If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A3ID"), 0) = Empl_ID) Then
                            btnApprove.Enabled = True
                        Else
                            btnApprove.Enabled = False
                        End If
                    Else
                        If Head = True And Dept_Head = False And Empl_ID <> GridView1.GetFocusedRowCellValue("User_EmplID") Then
                            btnApprove.Enabled = False
                        Else
                            btnApprove.Enabled = True
                        End If
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
            btnApprove.BringToFront()
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "APPROVED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "FOR RELEASING" Then
            If User_Type = "ADMIN" Or ComparePosition({"CASHIER", "CLIENT SOLUTIONS SPECIALIST"}, False) Or Department.ToUpper.Contains("CREDIT AND COLLECTION") Or Department.ToUpper.Contains("ADMINISTRATIVE") Then
                btnReceive.Enabled = True
                btnReceive.Visible = True
            End If
            If Dept_Head And cbxPreparedBy.SelectedValue = Empl_ID Then
                btnModify.Enabled = True
            Else
                btnModify.Enabled = False
            End If
            If (Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Or User_Type = "ADMIN" Or ComparePosition({"CASHIER", "CLIENT SOLUTIONS SPECIALIST", "ACCOUNTS MONITORING"}, False) Or Department.ToUpper.Contains("CREDIT AND COLLECTION") Or Department.ToUpper.Contains("ADMINISTRATIVE")) And GridView1.GetFocusedRowCellValue("ReplenishedID") = 0 Then
                If LOE_Number = "" Then
                    btnDelete.BringToFront()
                    btnDelete.Enabled = True
                    btnDelete.Visible = True
                End If
            End If
            For x As Integer = 0 To DT_Signatory.Rows.Count - 1
                If ComparePosition({DT_Signatory(x)("PositionID")}, True) And btnReceive.Tag = DT_Signatory(x)("ButtonID") And DT_Signatory(x)("FormID") = Tag Then
                    btnReceive.Enabled = True
                    btnReceive.Visible = True
                    Exit For
                End If
            Next
            btnReceive.BringToFront()
            If cbxPayee.SelectedValue = Empl_ID Then
                btnReceive.Text = "Receive"
            Else
                btnReceive.Text = "Release"
            End If
        ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "RECEIVED" Then
            If (Empl_ID = GridView1.GetFocusedRowCellValue("User_EmplID") Or Empl_ID = cbxPayee.SelectedValue Or User_Type = "ADMIN" Or ComparePosition({"CASHIER", "CLIENT SOLUTIONS SPECIALIST", "ACCOUNTS MONITORING"}, False) Or Department.ToUpper.Contains("CREDIT AND COLLECTION") Or Department.ToUpper.Contains("ADMINISTRATIVE")) And GridView1.GetFocusedRowCellValue("ReplenishedID") = 0 Then
                If LOE_Number = "" Then
                    btnDelete.BringToFront()
                    btnDelete.Enabled = True
                    btnDelete.Visible = True
                End If
            End If
            btnApprove.Visible = False
            btnReceive.Visible = False
            btnModify.Enabled = False
        End If
Here:
        btnPrint.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub CbxPayee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPayee.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Try
            If cbxPayee.SelectedIndex = -1 Or cbxPayee.Text = "" Then
                txtPurpose.Text = ""
            Else
                Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
                txtPurpose.Text = drv("Purpose")
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        GetAccountNumber()
    End Sub

    Private Sub BtnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        Dim Signatory As Boolean
        For x As Integer = 0 To DT_Signatory.Rows.Count - 1
            If ComparePosition({DT_Signatory(x)("PositionID")}, True) And DT_Signatory(x)("ButtonID") = btnApprove.Tag And DT_Signatory(x)("FormID") = Tag Then
                Signatory = True
                Exit For
            End If
        Next

        Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
        Dim drv_Prep As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
        If User_Type = "ADMIN" Or Signatory Or Dept_Head Or ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A3ID"), 0) = Empl_ID Then
            ' If Dept_Head And (User_EmplID = Empl_ID Or cbxPayee.SelectedValue = Empl_ID) Then
            If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) Then
                GoTo HereV4
            ElseIf Department.ToUpper.Contains("ADMINISTRATIVE") And If(cbxPayee.SelectedIndex = -1, True, drv("Type") = "S") And Signatory Then
                GoTo HereV2
            ElseIf Dept_Head = False And Department.ToUpper.Contains("ADMINISTRATIVE") Then
                GoTo HereV4
                'ElseIf Dept_Head Or Signatory Then
                'Else
                '    GoTo HereV2
            End If
        End If
        If (User_EmplID = Empl_ID Or cbxPreparedBy.SelectedValue = Empl_ID) And Signatory = False Then
HereV4:
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
                        .ProviderDept = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Position FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = '{0}' AND Branch_ID IN ('{1}','{2}') AND ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) ORDER BY `Employee` ASC;", If(cbxPayee.SelectedIndex = -1, 0, drv("department_id")), Branch_ID, MFBranch_ID))
                        .Provider = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Position FROM employee_setup WHERE `status` = 'ACTIVE' AND Branch_ID IN ('{1}','{2}') AND ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) ORDER BY `Employee` ASC;", If(cbxPayee.SelectedIndex = -1, 0, drv("department_id")), Branch_ID, MFBranch_ID))
                        If .ShowDialog = DialogResult.OK Then
                            Cursor = Cursors.WaitCursor
                            If cbxLiquidate.Checked And dTotal.Value <= If(cbxLiquidate.Checked, CDbl(drv("Amount")), 0) Then
                                DataObject(String.Format("UPDATE petty_cash SET `Voucher_Status` = 'RECEIVED', ApprovedID = '{1}', ReceivedID = '{2}', ReceivedBy = '{3}', ReceivedDate = '{4}' WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue, cbxPayee.SelectedValue, cbxPayee.Text, drv("ReceivedDate")))
                                Logs("Petty Cash Voucher", "Approve", String.Format("Approved Petty Cash Voucher of {0} with the total amount of {1} for {2}. [Via OTAC] [Auto Received Petty Cash since this is a liquidation]", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                            Else
                                DataObject(String.Format("UPDATE petty_cash SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, .cbxProvider.SelectedValue))
                                Logs("Petty Cash Voucher", "Approve", String.Format("Approved Petty Cash Voucher of {0} with the total amount of {1} for {2}. [Via OTAC]", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                            End If

                            Cursor = Cursors.Default
                            MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                            Clear(True)
                        End If
                        .Dispose()
                    End With
                ElseIf Result = DialogResult.Yes Then
                    Dim Msg As String = ""
                    Dim Subject As String = "One Time Authorization Code " & Code & " [" & txtAccountNumber.Text & "]"
                    Dim DT_Head As DataTable
                    Dim EmailTo As String = ""
                    Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & txtAccountNumber.Text & "-" & Format(Date.Now, "yyyy-MM-dd_hhmmss") & ".pdf"
                    If If(cbxPayee.SelectedIndex = -1, False, If(drv("Type") = "S", False, drv("Head") = 0)) Or Branch_ID > 0 Or drv("department_id") <> drv_Prep("department_id") Then
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
                        If If(cbxPayee.SelectedIndex = -1, 0, If(drv("Type") = "S", 0, DT_PCV_Approver.Rows.Count > 0)) Then
                            Msg = String.Format("Good day," & vbCrLf)
                            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for approval of Cash Advance of {1} with the total amount of {2} for {3}." & vbCrLf, Code, cbxPayee.Text, dTotal.Text, txtPurpose.Text)
                            Msg &= "Thank you!"
                            '******* SEND SMS *********************************************************************************
                            If DT_PCV_Approver(0)("A1Phone") = "" Then
                            Else
                                SendSMS(DT_PCV_Approver(0)("A1Phone"), Msg, True)
                            End If
                            If DT_PCV_Approver(0)("A2Phone") = "" Then
                            Else
                                SendSMS(DT_PCV_Approver(0)("A2Phone"), Msg, True)
                            End If
                            If DT_PCV_Approver(0)("A3Phone") = "" Then
                            Else
                                SendSMS(DT_PCV_Approver(0)("A3Phone"), Msg, True)
                            End If
                            '******* SEND EMAIL *********************************************************************************
                            If DT_PCV_Approver(0)("A1Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_PCV_Approver(0)("A1Email") & ", "
                            End If
                            If DT_PCV_Approver(0)("A2Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_PCV_Approver(0)("A2Email") & ", "
                            End If
                            If DT_PCV_Approver(0)("A3Email") = "" Then
                            Else
                                EmailTo = EmailTo & DT_PCV_Approver(0)("A3Email") & ", "
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
                                        Generate_PCV(False, FName)
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
                        Generate_PCV(False, FName)
                        AttachmentFiles.Add(FName)
                        SendEmail(EmailTo.Substring(0, EmailTo.Length - 2), Subject, Msg, False, False, False, 0, "", "")
                    End If
Here:
                End If
            End With
        ElseIf User_Type = "ADMIN" Or Signatory Or Dept_Head Or ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A3ID"), 0) = Empl_ID Then
HereV2:
            Dim ProviderID As Integer = 0
            If Dept_Head = False And (If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A1ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A2ID"), 0) = Empl_ID Or If(DT_PCV_Approver.Rows.Count > 0, DT_PCV_Approver(0)("A3ID"), 0) = Empl_ID) Then
                Dim Provider As New FrmOTACProvider
                With Provider
                    .cbxAll.Visible = True
                    .cbxProvider.DisplayMember = "Employee"
                    .cbxProvider.ValueMember = "ID"
                    .ProviderDept = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Position FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = '{0}' AND Branch_ID IN ('{1}','{2}') AND ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) ORDER BY `Employee` ASC;", If(cbxPayee.SelectedIndex = -1, 0, drv("department_id")), Branch_ID, MFBranch_ID))
                    .Provider = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Position FROM employee_setup WHERE `status` = 'ACTIVE' AND Branch_ID IN ('{1}','{2}') AND ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) ORDER BY `Employee` ASC;", If(cbxPayee.SelectedIndex = -1, 0, drv("department_id")), Branch_ID, MFBranch_ID))
                    If .ShowDialog = DialogResult.OK Then
                        ProviderID = .cbxProvider.SelectedValue
                    End If
                    .Dispose()
                End With
            End If
            If MsgBoxYes("Are you sure you want to approve this Petty Cash Voucher?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                If cbxLiquidate.Checked And dTotal.Value <= If(cbxLiquidate.Checked, CDbl(drv("Amount")), 0) Then
                    DataObject(String.Format("UPDATE petty_cash SET `Voucher_Status` = 'RECEIVED', ApprovedID = '{1}', ReceivedID = '{2}', ReceivedBy = '{3}', ReceivedDate = '{4}' WHERE ID = '{0}';", ID, If(ProviderID > 0, ProviderID, Empl_ID), cbxPayee.SelectedValue, cbxPayee.Text, drv("ReceivedDate")))
                    Logs("Petty Cash Voucher", "Approve", String.Format("Approved Petty Cash Voucher of {0} with the total amount of {1} for {2}. [Auto Received Petty Cash since this is a liquidation]", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                Else
                    DataObject(String.Format("UPDATE petty_cash SET `Voucher_Status` = 'APPROVED', ApprovedID = '{1}' WHERE ID = '{0}';", ID, If(ProviderID > 0, ProviderID, Empl_ID)))
                    Logs("Petty Cash Voucher", "Approve", String.Format("Approved Petty Cash Voucher of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                End If

                Cursor = Cursors.Default
                MsgBox("Successfully Approved!", MsgBoxStyle.Information, "Info")
                Clear(True)
            End If
        End If
    End Sub

    Private Sub BtnReceive_Click(sender As Object, e As EventArgs) Handles btnReceive.Click
        If btnReceive.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        Dim R As New FrmReceivedBy
        With R
            .LabelX1.Text = "PETTY CASH RECEIVER"
            .dtpReceived.MinDate = dtpDate.Value
            .From_PettyCash = True
            With .cbxReceiver
                .DisplayMember = "Employee"
                .ValueMember = "EmplID"
                .DataSource = DataSource(String.Format("SELECT E.ID AS 'EmplID', Employee(E.ID) AS 'Employee' FROM employee_setup E INNER JOIN (SELECT * FROM signatory_setup WHERE `status` = 'ACTIVE' AND BranchID = '{2}') S ON S.PositionID = E.position_id WHERE S.ButtonID = '{0}' AND S.FormID = '{1}' AND E.Branch_ID IN ('{2}','{3}') AND E.`status` = 'ACTIVE';", btnReceive.Tag, Tag, Branch_ID, MFBranch_ID))
                .SelectedIndex = -1
                .Text = cbxPayee.Text
                .Enabled = True
            End With
            .btnReceived.Text = btnReceive.Text
            If .ShowDialog = DialogResult.OK Then
                DataObject(String.Format("UPDATE petty_cash SET `voucher_status` = 'RECEIVED', ReceivedID = '{1}', ReceivedBy = '{3}', ReceivedDate = '{2}'  WHERE ID = '{0}';", ID, ValidateComboBox(.cbxReceiver), Format(.dtpReceived.Value, "yyyy-MM-dd"), .cbxReceiver.Text))
                If LOE_Number <> "" Then
                    DataObject(String.Format("UPDATE liquidation_main SET Refund = 1  WHERE AccountNumber = '{0}';", LOE_Number))
                End If
                Logs("Petty Cash Voucher", "Receive", String.Format("Received Petty Cash Voucher of {0} with the total amount of {1} for {2}. ", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text, txtPurpose.Text.InsertQuote), "", "", "", "")
                MsgBox("Successfully Received!", MsgBoxStyle.Information, "Info")

                If From_LOE Then
                    With btnReceive
                        .DialogResult = DialogResult.OK
                        .DialogResult = DialogResult.OK
                        .PerformClick()
                    End With
                End If
                Clear(True)
            End If
            .Dispose()
        End With
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
            'If Status = "PENDING" Or Status = "FOR APPROVAL" Then
            '    e.Appearance.ForeColor = Color.IndianRed
            'ElseIf Status = "APPROVED" Or Status = "FOR RELEASING" Then
            '    e.Appearance.ForeColor = Color.RoyalBlue
            'ElseIf Status = "RECEIVED" Then
            '    e.Appearance.ForeColor = Color.SeaGreen
            '    e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
            'ElseIf Status = "DISAPPROVED" Then
            '    e.Appearance.ForeColor = Color.IndianRed
            '    e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
            If Status = "DELETED" Or Status = "CANCELLED" Or Status = "DISAPPROVED" Then
                e.Appearance.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub TxtParticular_1_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_1.TextChanged
        If txtParticular_1.Text = "" Then
            cbxDepartment_1.SelectedIndex = -1
            cbxDepartment_1.Enabled = False
            dAmount_1.Value = 0
            dAmount_1.Enabled = False
            txtParticular_2.Text = ""
            txtParticular_2.Enabled = False
        Else
            cbxDepartment_1.Enabled = True
            dAmount_1.Enabled = True
            txtParticular_2.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_2_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_2.TextChanged
        If txtParticular_2.Text = "" Then
            cbxDepartment_2.SelectedIndex = -1
            cbxDepartment_2.Enabled = False
            dAmount_2.Value = 0
            dAmount_2.Enabled = False
            txtParticular_3.Text = ""
            txtParticular_3.Enabled = False
        Else
            cbxDepartment_2.Enabled = True
            dAmount_2.Enabled = True
            txtParticular_3.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_3_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_3.TextChanged
        If txtParticular_3.Text = "" Then
            cbxDepartment_3.SelectedIndex = -1
            cbxDepartment_3.Enabled = False
            dAmount_3.Value = 0
            dAmount_3.Enabled = False
            txtParticular_4.Text = ""
            txtParticular_4.Enabled = False
        Else
            cbxDepartment_3.Enabled = True
            dAmount_3.Enabled = True
            txtParticular_4.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_4_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_4.TextChanged
        If txtParticular_4.Text = "" Then
            cbxDepartment_4.SelectedIndex = -1
            cbxDepartment_4.Enabled = False
            dAmount_4.Value = 0
            dAmount_4.Enabled = False
            txtParticular_5.Text = ""
            txtParticular_5.Enabled = False
        Else
            cbxDepartment_4.Enabled = True
            dAmount_4.Enabled = True
            txtParticular_5.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_5_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_5.TextChanged
        If txtParticular_5.Text = "" Then
            cbxDepartment_5.SelectedIndex = -1
            cbxDepartment_5.Enabled = False
            dAmount_5.Value = 0
            dAmount_5.Enabled = False
            txtParticular_6.Text = ""
            txtParticular_6.Enabled = False
        Else
            cbxDepartment_5.Enabled = True
            dAmount_5.Enabled = True
            txtParticular_6.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_6_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_6.TextChanged
        If txtParticular_6.Text = "" Then
            cbxDepartment_6.SelectedIndex = -1
            cbxDepartment_6.Enabled = False
            dAmount_6.Value = 0
            dAmount_6.Enabled = False
            txtParticular_7.Text = ""
            txtParticular_7.Enabled = False
        Else
            cbxDepartment_6.Enabled = True
            dAmount_6.Enabled = True
            txtParticular_7.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_7_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_7.TextChanged
        If txtParticular_7.Text = "" Then
            cbxDepartment_7.SelectedIndex = -1
            cbxDepartment_7.Enabled = False
            dAmount_7.Value = 0
            dAmount_7.Enabled = False
            txtParticular_8.Text = ""
            txtParticular_8.Enabled = False
        Else
            cbxDepartment_7.Enabled = True
            dAmount_7.Enabled = True
            txtParticular_8.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_8_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_8.TextChanged
        If txtParticular_8.Text = "" Then
            cbxDepartment_8.SelectedIndex = -1
            cbxDepartment_8.Enabled = False
            dAmount_8.Value = 0
            dAmount_8.Enabled = False
            txtParticular_9.Text = ""
            txtParticular_9.Enabled = False
        Else
            cbxDepartment_8.Enabled = True
            dAmount_8.Enabled = True
            txtParticular_9.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_9_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_9.TextChanged
        If txtParticular_9.Text = "" Then
            cbxDepartment_9.SelectedIndex = -1
            cbxDepartment_9.Enabled = False
            dAmount_9.Value = 0
            dAmount_9.Enabled = False
            txtParticular_10.Text = ""
            txtParticular_10.Enabled = False
        Else
            cbxDepartment_9.Enabled = True
            dAmount_9.Enabled = True
            txtParticular_10.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_10_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_10.TextChanged
        If txtParticular_10.Text = "" Then
            cbxDepartment_10.SelectedIndex = -1
            cbxDepartment_10.Enabled = False
            dAmount_10.Value = 0
            dAmount_10.Enabled = False
            txtParticular_11.Text = ""
            txtParticular_11.Enabled = False
        Else
            cbxDepartment_10.Enabled = True
            dAmount_10.Enabled = True
            txtParticular_11.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_11_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_11.TextChanged
        If txtParticular_11.Text = "" Then
            cbxDepartment_11.SelectedIndex = -1
            cbxDepartment_11.Enabled = False
            dAmount_11.Value = 0
            dAmount_11.Enabled = False
            txtParticular_12.Text = ""
            txtParticular_12.Enabled = False
        Else
            cbxDepartment_11.Enabled = True
            dAmount_11.Enabled = True
            txtParticular_12.Enabled = True
        End If
    End Sub

    Private Sub TxtParticular_12_TextChanged(sender As Object, e As EventArgs) Handles txtParticular_12.TextChanged
        If txtParticular_12.Text = "" Then
            cbxDepartment_12.SelectedIndex = -1
            cbxDepartment_12.Enabled = False
            dAmount_12.Value = 0
            dAmount_12.Enabled = False
        Else
            cbxDepartment_12.Enabled = True
            dAmount_12.Enabled = True
        End If
    End Sub

    Private Sub DAmount_ValueChanged(sender As Object, e As EventArgs) Handles dAmount_1.ValueChanged, dAmount_2.ValueChanged, dAmount_3.ValueChanged, dAmount_4.ValueChanged, dAmount_5.ValueChanged, dAmount_6.ValueChanged, dAmount_7.ValueChanged, dAmount_8.ValueChanged, dAmount_9.ValueChanged, dAmount_10.ValueChanged, dAmount_11.ValueChanged, dAmount_12.ValueChanged
        dTotal.Value = dAmount_1.Value + dAmount_2.Value + dAmount_3.Value + dAmount_4.Value + dAmount_5.Value + dAmount_6.Value + dAmount_7.Value + dAmount_8.Value + dAmount_9.Value + dAmount_10.Value + dAmount_11.Value + dAmount_12.Value
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
            .FolderName = "Petty Cash-" & GridView1.GetFocusedRowCellValue("Account Number")
            .PCVNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .TotalImage = GridView1.GetFocusedRowCellValue("Attach")
            .ID = GridView1.GetFocusedRowCellValue("Account Number")
            .Type = "Petty Cash"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                GridView1.SetFocusedRowCellValue("Attach", Attach.TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDisapprove_Click(sender As Object, e As EventArgs) Handles btnDisapprove.Click
        If MsgBoxYes("Are you sure you want to disapprove this Petty Cash Voucher?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim drv As DataRowView = DirectCast(cbxPayee.SelectedItem, DataRowView)
            Dim SQL As String = ""
            If drv("Type") = "C" Then 'FROM CASH ADVANCE ********************************************
                SQL = String.Format("UPDATE cash_advance SET Liquidated = 'N' WHERE AccountNumber = '{0}';", drv("AccountNumber"))
            ElseIf drv("Type") = "E" Then 'CHECK IF FROM PETTY CASH THEN GI TAG FOR LIQUIDATION FROM CASH ADVANCE ********************************************
                Dim CANumber As String = DataObject(String.Format("SELECT CANumber FROM petty_cash WHERE ID = {0};", ID))
                If CANumber <> "" Then
                    SQL = String.Format("UPDATE cash_advance SET Liquidated = 'N' WHERE AccountNumber = '{0}';", CANumber)
                End If
            End If
            SQL &= String.Format("UPDATE petty_cash SET `voucher_status` = 'DISAPPROVED', DisapprovedID = '{1}' WHERE ID = '{0}';", ID, Empl_ID)
            DataObject(SQL)
            Logs("Petty Cash Voucher", "Disapprove", Reason, String.Format("Disapproved Petty Cash Voucher of {0} with Amount {1}.", cbxPayee.Text & " - " & txtAccountNumber.Text, dTotal.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Disapproved!", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub CbxLiquidate_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLiquidate.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxLiquidate.Checked Then
            cbxOther.Checked = False
            cbxOther.Enabled = False
        Else
            cbxOther.Enabled = True
        End If

        LoadPayee("")
    End Sub

    Private Sub CbxOther_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOther.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadPayee("")
    End Sub

    Private Sub ITagEmployee_Click(sender As Object, e As EventArgs) Handles iTagEmployee.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "E" Then
                MsgBox("Petty Cash is already tagged in Employee.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "S" Then
                MsgBox("Petty Cash is already tagged in Supplier.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "RECEIVED" Then
                MsgBox(String.Format("Petty Cash is already {0}.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Payee As New FrmPettyCashTagPayee
        With Payee
            .DocumentNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .Payee = GridView1.GetFocusedRowCellValue("Payee")

            .cbxPayee.DisplayMember = "Employee"
            .cbxPayee.ValueMember = "ID"
            .cbxPayee.DataSource = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id IN ('{0}','{1}')", Branch_ID, MFBranch_ID))
            .cbxPayee.Text = GridView1.GetFocusedRowCellValue("Payee")
            If .ShowDialog = DialogResult.OK Then
                Dim Msg As String = ""
                Dim Subject As String = String.Format("Petty Cash Voucher {0}.", GridView1.GetFocusedRowCellValue("Account Number"))
                If .cbxPayee.SelectedValue <> Empl_ID Then
                    If MsgBoxYes(String.Format("You are tagging a Petty Cash Voucher for {0}, This will notify him/her through Email and SMS, would you like to proceed?", .cbxPayee.Text)) = MsgBoxResult.Yes Then
                        Dim drv As DataRowView = DirectCast(.cbxPayee.SelectedItem, DataRowView)
                        Msg = String.Format("Good day {0}," & vbCrLf, .cbxPayee.Text)
                        Msg &= String.Format("{0} tagged Petty Cash Voucher under your name with a Total Amount of P{1}." & vbCrLf, Empl_Name, GridView1.GetFocusedRowCellValue("Total"))
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

                DataObject(String.Format("UPDATE petty_cash SET `Payee_ID` = {0}, Payee = '{1}', Payee_Type = 'E'  WHERE ID = '{2}';", .cbxPayee.SelectedValue, .cbxPayee.Text, GridView1.GetFocusedRowCellValue("ID")))
                Logs("Petty Cash", "Tag Employee", String.Format("Tag Employee for Petty Cash {0} from {1} to {2}", .DocumentNumber, .Payee, .cbxPayee.Text), "", "", "", "")
                LoadData()
                MsgBox("Successfully Tagged!", MsgBoxStyle.Information, "Info")
            End If
            .Dispose()
        End With
    End Sub

    Private Sub ITagSupplier_Click(sender As Object, e As EventArgs) Handles iTagSupplier.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "E" Then
                MsgBox("Petty Cash is already tagged in Employee.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Payee_Type") = "S" Then
                MsgBox("Petty Cash is already tagged in Supplier.", MsgBoxStyle.Information, "Info")
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("Voucher_Status") = "CANCELLED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "DISAPPROVED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "DELETED" Or GridView1.GetFocusedRowCellValue("Voucher_Status") = "RECEIVED" Then
                MsgBox(String.Format("Petty Cash is already {0}.", GridView1.GetFocusedRowCellValue("Voucher_Status")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Payee As New FrmPettyCashTagPayee
        With Payee
            .DocumentNumber = GridView1.GetFocusedRowCellValue("Account Number")
            .Payee = GridView1.GetFocusedRowCellValue("Payee")

            .cbxPayee.DisplayMember = "Supplier"
            .cbxPayee.ValueMember = "ID"
            .cbxPayee.DataSource = DataSource(String.Format("SELECT ID, CONCAT('[', CodeS ,'] ',Supplier) AS 'Supplier' FROM supplier_setup WHERE `status` = 'ACTIVE' AND branch_id IN ('{0}','{1}')", Branch_ID, MFBranch_ID))
            .cbxPayee.Text = GridView1.GetFocusedRowCellValue("Payee")
            If .ShowDialog = DialogResult.OK Then
                DataObject(String.Format("UPDATE petty_cash SET `Payee_ID` = {0}, Payee = '{1}', Payee_Type = 'S'  WHERE ID = '{2}';", .cbxPayee.SelectedValue, .cbxPayee.Text, GridView1.GetFocusedRowCellValue("ID")))
                Logs("Petty Cash", "Tag Supplier", String.Format("Tag Supplier for Petty Cash {0} from {1} to {2}", .DocumentNumber, .Payee, .cbxPayee.Text), "", "", "", "")
                LoadData()
                MsgBox("Successfully Tagged!", MsgBoxStyle.Information, "Info")
            End If
            .Dispose()
        End With
    End Sub
End Class