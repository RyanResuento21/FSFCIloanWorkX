Public Class FrmEmployee

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Public From_Department As Boolean
    Public From_Position As Boolean
    Public DeptID_PosID As Integer

    Private Sub FrmEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        dtpBirth.Value = Date.Now
        dtpHired.Value = Date.Now

        With cbxPrefix
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With cbxPosition
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DataSource("SELECT ID, position_code AS 'Position Code', `Position`, Head FROM position_setup WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
            .SelectedIndex = -1
        End With

        With cbxSecondaryPosition
            .ValueMember = "ID"
            .DisplayMember = "Position"
            .DataSource = DataSource("SELECT ID, position_code AS 'Position Code', `Position`, Head FROM position_setup WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
            .SelectedIndex = -1
        End With

        With cbxDepartment
            .ValueMember = "ID"
            .DisplayMember = "Department"
            .DataSource = DataSource("SELECT ID, department_code AS 'Department Code', Department FROM department_setup WHERE `status` = 'ACTIVE' ORDER BY `Department`;")
            .SelectedIndex = -1
        End With

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource("SELECT ID, branch_code, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY Microfinance, branchID * 1;")
            .SelectedIndex = -1
        End With

        If From_Department Or From_Position Then
            tabSetup.Visible = False
            btnBack.Enabled = False
            btnAdd.Enabled = False
        End If

        LoadData()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX2, LabelX6, LabelX10, LabelX3, LabelX155, LabelX4, LabelX1, LabelX5, LabelX30, LabelX32, lblHeadv2, lblHead, LabelX7})

            GetTextBoxFontSettings({txtFirstN, txtMiddleN, txtLastN, txtEmployeeID, txtPlus63, txtMobile, txtEmail, TxtExtension})

            GetCheckBoxFontSettings({CbxNA_Birth, CbxNA_Hired})

            GetComboBoxFontSettings({cbxPrefix, cbxSuffix, cbxPosition, cbxSecondaryPosition, cbxBranch, cbxDepartment})

            GetDateTimeInputFontSettings({dtpBirth, dtpHired})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Employee - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Employee", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    emp_code,"
        SQL &= "    prefix,"
        SQL &= "    first_name,"
        SQL &= "    middle_name,"
        SQL &= "    last_name,"
        SQL &= "    suffix,"
        SQL &= "    CONCAT(IF(prefix = '','',CONCAT(prefix, ' ')), IF(first_name = '','',CONCAT(first_name, ' ')), IF(middle_name = '','',CONCAT(middle_name, ' ')), IF(last_name = '','',CONCAT(last_name, ' ')), suffix) AS 'Name',"
        SQL &= "    id_number   AS 'ID Number',"
        SQL &= "    DATE_FORMAT(birthdate,'%M %d, %Y') AS 'Birthdate',"
        SQL &= "    DATE_FORMAT(hireddate,'%M %d, %Y') AS 'Date Hired',"
        SQL &= "    position_id,"
        SQL &= "    `Position`,"
        SQL &= "    secondary_position_id,"
        SQL &= "    secondary_position AS 'Secondary Position',"
        SQL &= "    department_id,"
        SQL &= "    Department,"
        SQL &= "    Phone AS 'Mobile Number',"
        SQL &= "    EmailAdd AS 'Email Address', Extension, "
        SQL &= "    branch_id AS 'branch_id',"
        SQL &= "    Branch, can_appraise"
        If From_Department Or From_Position Then
            If From_Department Then
                SQL &= String.Format("  FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = {0} ORDER BY `Name`;", DeptID_PosID)
            ElseIf From_Position Then
                SQL &= String.Format("  FROM employee_setup WHERE `status` = 'ACTIVE' AND (position_id = {0} OR secondary_position_id = {0}) ORDER BY `Name`;", DeptID_PosID)
            End If
        Else
            SQL &= "  FROM employee_setup WHERE `status` = 'ACTIVE' ORDER BY `Name`;"
        End If
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub CbxPrefix_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPrefix.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtFirstN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFirstN.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtMiddleN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMiddleN.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtLastN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtLastN.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxSuffix_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtEmployeeID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmployeeID.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpBirth_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpBirth.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxNA_Birth_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxNA_Birth.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpHired_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpHired.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxNA_Hired_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxNA_Hired.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxPosition_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxSecondaryPosition_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSecondaryPosition.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxDepartment_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDepartment.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtMobile_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtExtension_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtExtension.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub CbxPrefix_Leave(sender As Object, e As EventArgs) Handles cbxPrefix.Leave
        cbxPrefix.Text = ReplaceText(cbxPrefix.Text.Trim)
    End Sub

    Private Sub TxtFirstN_Leave(sender As Object, e As EventArgs) Handles txtFirstN.Leave
        txtFirstN.Text = ReplaceText(txtFirstN.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_Leave(sender As Object, e As EventArgs) Handles txtMiddleN.Leave
        txtMiddleN.Text = ReplaceText(txtMiddleN.Text.Trim)
    End Sub

    Private Sub TxtLastN_Leave(sender As Object, e As EventArgs) Handles txtLastN.Leave
        txtLastN.Text = ReplaceText(txtLastN.Text.Trim)
    End Sub

    Private Sub CbxSuffix_Leave(sender As Object, e As EventArgs) Handles cbxSuffix.Leave
        cbxSuffix.Text = ReplaceText(cbxSuffix.Text.Trim)
    End Sub

    Private Sub TxtEmployeeID_Leave(sender As Object, e As EventArgs) Handles txtEmployeeID.Leave
        txtEmployeeID.Text = ReplaceText(txtEmployeeID.Text.Trim)
    End Sub

    Private Sub CbxPosition_Leave(sender As Object, e As EventArgs) Handles cbxPosition.Leave
        cbxPosition.Text = ReplaceText(cbxPosition.Text.Trim)
    End Sub

    Private Sub CbxSecondaryPosition_Leave(sender As Object, e As EventArgs) Handles cbxSecondaryPosition.Leave
        cbxSecondaryPosition.Text = ReplaceText(cbxSecondaryPosition.Text.Trim)
    End Sub

    Private Sub CbxBranch_Leave(sender As Object, e As EventArgs) Handles cbxBranch.Leave
        cbxBranch.Text = ReplaceText(cbxBranch.Text.Trim)
    End Sub

    Private Sub CbxDepartment_Leave(sender As Object, e As EventArgs) Handles cbxDepartment.Leave
        cbxDepartment.Text = ReplaceText(cbxDepartment.Text.Trim)
    End Sub

    Private Sub TxtMobile_Leave(sender As Object, e As EventArgs) Handles txtMobile.Leave
        txtMobile.Text = ReplaceText(txtMobile.Text.Trim)
    End Sub

    Private Sub TxtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        txtEmail.Text = ReplaceText(txtEmail.Text.Trim)
    End Sub

    Private Sub TxtExtension_Leave(sender As Object, e As EventArgs) Handles TxtExtension.Leave
        TxtExtension.Text = ReplaceText(TxtExtension.Text.Trim)
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
            btnPrint.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)

                With cbxPrefix
                    .ValueMember = "ID"
                    .DisplayMember = "Prefix"
                    .DataSource = Prefix.Copy
                    .SelectedIndex = -1
                End With

                With cbxSuffix
                    .DisplayMember = "Suffix"
                    .DataSource = Suffix.Copy
                    .SelectedIndex = -1
                End With

                With cbxPosition
                    .ValueMember = "ID"
                    .DisplayMember = "Position"
                    .DataSource = DataSource("SELECT ID, position_code AS 'Position Code', `Position`, Head FROM position_setup WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
                    .SelectedIndex = -1
                End With

                With cbxSecondaryPosition
                    .ValueMember = "ID"
                    .DisplayMember = "Position"
                    .DataSource = DataSource("SELECT ID, position_code AS 'Position Code', `Position`, Head FROM position_setup WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
                    .SelectedIndex = -1
                End With

                With cbxDepartment
                    .ValueMember = "ID"
                    .DisplayMember = "Department"
                    .DataSource = DataSource("SELECT ID, department_code AS 'Department Code', Department FROM department_setup WHERE `status` = 'ACTIVE' ORDER BY `Department`;")
                    .SelectedIndex = -1
                End With

                With cbxBranch
                    .ValueMember = "ID"
                    .DisplayMember = "Branch"
                    .DataSource = DataSource("SELECT ID, branch_code, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY Microfinance, branchID * 1;")
                    .SelectedIndex = -1
                End With
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        cbxPrefix.Text = ""
        txtFirstN.Text = ""
        txtMiddleN.Text = ""
        txtLastN.Text = ""
        cbxSuffix.Text = ""
        txtEmployeeID.Text = ""
        dtpBirth.Value = Date.Now
        CbxNA_Birth.Checked = False
        dtpHired.Value = Date.Now
        CbxNA_Hired.Checked = False
        cbxPosition.SelectedIndex = -1
        cbxSecondaryPosition.SelectedIndex = -1
        cbxBranch.SelectedIndex = -1
        cbxDepartment.SelectedIndex = -1
        txtMobile.Text = ""
        txtEmail.Text = ""
        btnSave.Text = "&Save"
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

        If txtFirstN.Text = "" Then
            MsgBox("Please fill First name field.", MsgBoxStyle.Information, "Info")
            txtFirstN.Focus()
            Exit Sub
        End If
        If txtLastN.Text = "" Then
            MsgBox("Please fill Last name field.", MsgBoxStyle.Information, "Info")
            txtLastN.Focus()
            Exit Sub
        End If
        If txtEmployeeID.Text = "" Then
            MsgBox("Please fill Employee ID Number field.", MsgBoxStyle.Information, "Info")
            txtEmployeeID.Focus()
            Exit Sub
        End If
        If cbxPosition.Text = "" Or cbxPosition.SelectedIndex = -1 Then
            MsgBox("Please select Position.", MsgBoxStyle.Information, "Info")
            cbxPosition.DroppedDown = True
            Exit Sub
        End If
        If cbxBranch.Text = "" Or cbxBranch.SelectedIndex = -1 Then
            MsgBox("Please select Branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
            Exit Sub
        End If
        If cbxDepartment.Text <> "" And cbxDepartment.SelectedIndex = -1 Then
            MsgBox("Please select Department.", MsgBoxStyle.Information, "Info")
            cbxDepartment.DroppedDown = True
            Exit Sub
        End If
        If (txtMobile.Text.Trim.Length > 0 And txtMobile.Text.Trim.Length <> 10) Or (txtMobile.Text.Trim.Length > 0 And IsNumeric(txtMobile.Text.Trim) = False) Then
            MsgBox("Please fill a correct mobile number to proceed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxBranch.SelectedItem, DataRowView)
        Dim drvD As DataRowView = DirectCast(cbxDepartment.SelectedItem, DataRowView)
        Dim ECode As String = If(cbxBranch.Text.Trim = "" Or cbxBranch.SelectedIndex = -1, "CORP", drv("branch_code")) & "-" & txtEmployeeID.Text
        Dim EName As String = If(cbxPrefix.Text = "", "", cbxPrefix.Text & " ") & If(txtFirstN.Text = "", "", txtFirstN.Text & " ") & If(txtMiddleN.Text = "", "", txtMiddleN.Text & " ") & If(txtLastN.Text = "", "", txtLastN.Text & " ") & If(cbxSuffix.Text = "", "", cbxSuffix.Text)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM employee_setup WHERE (first_name = '{0}' AND last_name = '{1}' AND suffix = '{2}') AND Branch_ID = '{3}' AND `status` = 'ACTIVE'", txtFirstN.Text, txtLastN.Text, cbxSuffix.Text, ValidateComboBox(cbxBranch)))
                If Exist > 0 Then
                    MsgBox(String.Format("Employee {0} already exist, Please check your data.", EName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO employee_setup SET"
                SQL &= String.Format(" emp_code = '{0}', ", ECode)
                SQL &= String.Format(" prefix = '{0}', ", cbxPrefix.Text)
                SQL &= String.Format(" first_name = '{0}', ", txtFirstN.Text)
                SQL &= String.Format(" middle_name = '{0}', ", txtMiddleN.Text)
                SQL &= String.Format(" last_name = '{0}', ", txtLastN.Text)
                SQL &= String.Format(" suffix = '{0}', ", cbxSuffix.Text)
                SQL &= String.Format(" id_number = '{0}', ", txtEmployeeID.Text)
                SQL &= String.Format(" birthdate = '{0}', ", If(CbxNA_Birth.Checked, "", FormatDatePicker(dtpBirth)))
                SQL &= String.Format(" hireddate = '{0}', ", If(CbxNA_Hired.Checked, "", FormatDatePicker(dtpHired)))
                SQL &= String.Format(" position_id = '{0}', ", ValidateComboBox(cbxPosition))
                SQL &= String.Format(" `position` = '{0}', ", cbxPosition.Text)
                SQL &= String.Format(" secondary_position_id = '{0}', ", ValidateComboBox(cbxSecondaryPosition))
                SQL &= String.Format(" `secondary_position` = '{0}', ", cbxSecondaryPosition.Text)
                SQL &= String.Format(" department_id = '{0}', ", ValidateComboBox(cbxDepartment))
                SQL &= String.Format(" department = '{0}', ", cbxDepartment.Text)
                SQL &= String.Format(" Phone = '{0}', ", txtMobile.Text)
                SQL &= String.Format(" EmailAdd = '{0}', ", txtEmail.Text)
                SQL &= String.Format(" Extension = '{0}', ", TxtExtension.Text)
                SQL &= String.Format(" company_id = '{0}', ", Company_ID)
                SQL &= String.Format(" branch_id = '{0}', ", ValidateComboBox(cbxBranch))
                SQL &= String.Format(" branch = '{0}', ", cbxBranch.Text)
                SQL &= String.Format(" branch_code = '{0}';", If(cbxBranch.Text = "" Or cbxBranch.SelectedIndex = -1, "CORP", drv("branch_code")))
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Employee", "Save", String.Format("Add new employee {0}", EName), "", "", "", "")
                DT_Employees = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd, `Position`, IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) AS 'Head', department_ID FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Employee`;", Branch_ID))
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM employee_setup WHERE (first_name = '{0}' AND last_name = '{1}' AND suffix = '{2}') AND `status` = 'ACTIVE' AND ID != '{3}' AND Branch_ID = '{4}'", txtFirstN.Text, txtLastN.Text, cbxSuffix.Text, ID, ValidateComboBox(cbxBranch)))
                If Exist > 0 Then
                    MsgBox(String.Format("Employee {0} already exist, Please check your data.", EName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE employee_setup SET"
                SQL &= String.Format(" emp_code = '{0}', ", ECode)
                SQL &= String.Format(" prefix = '{0}', ", cbxPrefix.Text)
                SQL &= String.Format(" first_name = '{0}', ", txtFirstN.Text)
                SQL &= String.Format(" middle_name = '{0}', ", txtMiddleN.Text)
                SQL &= String.Format(" last_name = '{0}', ", txtLastN.Text)
                SQL &= String.Format(" suffix = '{0}', ", cbxSuffix.Text)
                SQL &= String.Format(" id_number = '{0}', ", txtEmployeeID.Text)
                SQL &= String.Format(" birthdate = '{0}', ", If(CbxNA_Birth.Checked, "", FormatDatePicker(dtpBirth)))
                SQL &= String.Format(" hireddate = '{0}', ", If(CbxNA_Hired.Checked, "", FormatDatePicker(dtpHired)))
                SQL &= String.Format(" position_id = '{0}', ", ValidateComboBox(cbxPosition))
                SQL &= String.Format(" `position` = '{0}', ", cbxPosition.Text)
                SQL &= String.Format(" secondary_position_id = '{0}', ", ValidateComboBox(cbxSecondaryPosition))
                SQL &= String.Format(" `secondary_position` = '{0}', ", cbxSecondaryPosition.Text)
                SQL &= String.Format(" department_id = '{0}', ", ValidateComboBox(cbxDepartment))
                SQL &= String.Format(" department = '{0}', ", cbxDepartment.Text)
                SQL &= String.Format(" branch_id = '{0}', ", ValidateComboBox(cbxBranch))
                SQL &= String.Format(" branch = '{0}', ", cbxBranch.Text)
                SQL &= String.Format(" Phone = '{0}', ", txtMobile.Text)
                SQL &= String.Format(" EmailAdd = '{0}', ", txtEmail.Text)
                SQL &= String.Format(" Extension = '{0}', ", TxtExtension.Text)
                SQL &= String.Format(" branch_code = '{0}' ", If(cbxBranch.Text = "" Or cbxBranch.SelectedIndex = -1, "CORP", drv("branch_code")))
                SQL &= String.Format(" WHERE ID = '{0}';", ID)

                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Employee", "Update", Reason, Changes(), "", "", "")
                DT_Employees = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd, `Position`, IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) AS 'Head', department_ID FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Employee`;", Branch_ID))
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxPrefix.Text = cbxPrefix.Tag Then
            Else
                Change &= String.Format("Change Prefix from {0} to {1}. ", cbxPrefix.Tag, cbxPrefix.Text)
            End If
            If txtFirstN.Text = txtFirstN.Tag Then
            Else
                Change &= String.Format("Change First Name from {0} to {1}. ", txtFirstN.Tag, txtFirstN.Text)
            End If
            If txtMiddleN.Text = txtMiddleN.Tag Then
            Else
                Change &= String.Format("Change Middle Name from {0} to {1}. ", txtMiddleN.Tag, txtMiddleN.Text)
            End If
            If txtLastN.Text = txtLastN.Tag Then
            Else
                Change &= String.Format("Change Last Name from {0} to {1}. ", txtLastN.Tag, txtLastN.Text)
            End If
            If cbxSuffix.Text = cbxSuffix.Tag Then
            Else
                Change &= String.Format("Change Suffix from {0} to {1}. ", cbxSuffix.Tag, cbxSuffix.Text)
            End If
            If txtEmployeeID.Text = txtEmployeeID.Tag Then
            Else
                Change &= String.Format("Change ID Number from {0} to {1}. ", txtEmployeeID.Tag, txtEmployeeID.Text)
            End If
            If dtpBirth.Text = dtpBirth.Tag Then
            Else
                Change &= String.Format("Change Birthdate from {0} to {1}. ", dtpBirth.Tag, dtpBirth.Text)
            End If
            If dtpHired.Text = dtpHired.Tag Then
            Else
                Change &= String.Format("Change Date Hired from {0} to {1}. ", dtpHired.Tag, dtpHired.Text)
            End If
            If cbxPosition.Text = cbxPosition.Tag Then
            Else
                Change &= String.Format("Change Position from {0} to {1}. ", cbxPosition.Tag, cbxPosition.Text)
            End If
            If cbxSecondaryPosition.Text = cbxSecondaryPosition.Tag Then
            Else
                Change &= String.Format("Change Secondary Position from {0} to {1}. ", cbxSecondaryPosition.Tag, cbxSecondaryPosition.Text)
            End If
            If cbxBranch.Text = cbxBranch.Tag Then
            Else
                Change &= String.Format("Change Branch from {0} to {1}. ", cbxBranch.Tag, If(cbxBranch.Text = "", "CORPORATE OFFICE", cbxBranch.Text))
            End If
            If cbxDepartment.Text = cbxDepartment.Tag Then
            Else
                Change &= String.Format("Change Department from {0} to {1}. ", cbxDepartment.Tag, cbxDepartment.Text)
            End If
            If txtMobile.Text = txtMobile.Tag Then
            Else
                Change &= String.Format("Change Mobile Number from {0} to {1}. ", txtMobile.Tag, txtMobile.Text)
            End If
            If txtEmail.Text = txtEmail.Tag Then
            Else
                Change &= String.Format("Change Email Address from {0} to {1}. ", txtEmail.Tag, txtEmail.Text)
            End If
            If TxtExtension.Text = TxtExtension.Tag Then
            Else
                Change &= String.Format("Change Extension from {0} to {1}. ", TxtExtension.Tag, TxtExtension.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Employee - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE employee_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Dim UserID As Integer = DataObject(String.Format("SELECT ID FROM users WHERE empl_id = '{0}' and `status` = 'ACTIVE' ORDER BY ID DESC LIMIT 1;", ID))
            If UserID > 0 Then
                If MsgBoxYes("Employee does have an ACTIVE user account, would you like to delete this automatically?") = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE users SET `status` = 'DELETED' WHERE empl_id = '{0}';", ID))
                    Logs("Employee", "Delete", Reason, String.Format("Delete user account of {0}", txtFirstN.Text & " " & txtLastN.Text), "", "", "")
                End If
            End If
            Logs("Employee", "Cancel", Reason, String.Format("Cancel employee {0}", If(cbxPrefix.Text = "", "", cbxPrefix.Text & " ") & If(txtFirstN.Text = "", "", txtFirstN.Text & " ") & If(txtMiddleN.Text = "", "", txtMiddleN.Text & " ") & If(txtLastN.Text = "", "", txtLastN.Text & " ") & If(cbxSuffix.Text = "", "", cbxSuffix.Text)), "", "", "")
            DT_Employees = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd, `Position`, IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) AS 'Head', department_ID FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Employee`;", Branch_ID))
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("EMPLOYEE LIST", GridControl1)
        Logs("Employee", "Print", "[SENSITIVE] Print Employee List", "", "", "", "")
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
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

    Private Sub CbxNA_Birth_CheckedChanged(sender As Object, e As EventArgs) Handles CbxNA_Birth.CheckedChanged
        If CbxNA_Birth.Checked Then
            dtpBirth.Enabled = False
            dtpBirth.CustomFormat = ""
        Else
            dtpBirth.Enabled = True
            dtpBirth.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub CbxNA_Hired_CheckedChanged(sender As Object, e As EventArgs) Handles CbxNA_Hired.CheckedChanged
        If CbxNA_Hired.Checked Then
            dtpHired.Enabled = False
            dtpHired.CustomFormat = ""
        Else
            dtpHired.Enabled = True
            dtpHired.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
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
            cbxPrefix.Text = .GetFocusedRowCellValue("prefix")
            cbxPrefix.Tag = .GetFocusedRowCellValue("prefix")
            txtFirstN.Text = .GetFocusedRowCellValue("first_name")
            txtFirstN.Tag = .GetFocusedRowCellValue("first_name")
            txtMiddleN.Text = .GetFocusedRowCellValue("middle_name")
            txtMiddleN.Tag = .GetFocusedRowCellValue("middle_name")
            txtLastN.Text = .GetFocusedRowCellValue("last_name")
            txtLastN.Tag = .GetFocusedRowCellValue("last_name")
            cbxSuffix.Text = .GetFocusedRowCellValue("suffix")
            cbxSuffix.Tag = .GetFocusedRowCellValue("suffix")
            txtEmployeeID.Text = .GetFocusedRowCellValue("ID Number")
            txtEmployeeID.Tag = .GetFocusedRowCellValue("ID Number")
            If .GetFocusedRowCellValue("Birthdate").ToString = "" Then
                CbxNA_Birth.Checked = True
            Else
                dtpBirth.Value = .GetFocusedRowCellValue("Birthdate").ToString
            End If
            dtpBirth.Tag = .GetFocusedRowCellValue("Birthdate").ToString
            If .GetFocusedRowCellValue("Date Hired").ToString = "" Then
                CbxNA_Hired.Checked = True
            Else
                dtpHired.Value = .GetFocusedRowCellValue("Date Hired").ToString
            End If
            dtpHired.Tag = .GetFocusedRowCellValue("Date Hired").ToString
            cbxPosition.Text = .GetFocusedRowCellValue("Position")
            cbxPosition.Tag = .GetFocusedRowCellValue("Position")
            cbxSecondaryPosition.Text = .GetFocusedRowCellValue("Secondary Position")
            cbxSecondaryPosition.Tag = .GetFocusedRowCellValue("Secondary Position")
            'cbxBranch.SelectedValue = .GetFocusedRowCellValue("branch_id")
            cbxBranch.Text = .GetFocusedRowCellValue("Branch")
            cbxBranch.Tag = .GetFocusedRowCellValue("Branch")
            cbxDepartment.Text = .GetFocusedRowCellValue("Department")
            cbxDepartment.Tag = .GetFocusedRowCellValue("Department")
            txtMobile.Text = .GetFocusedRowCellValue("Mobile Number")
            txtMobile.Tag = .GetFocusedRowCellValue("Mobile Number")
            txtEmail.Text = .GetFocusedRowCellValue("Email Address")
            txtEmail.Tag = .GetFocusedRowCellValue("Email Address")
            TxtExtension.Text = .GetFocusedRowCellValue("Extension")
            TxtExtension.Tag = .GetFocusedRowCellValue("Extension")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub IAppraise_Click(sender As Object, e As EventArgs) Handles iAppraise.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If MsgBoxYes(String.Format("Are you sure you want to set {1} {0}?", iAppraise.Text.ToLower, GridView1.GetFocusedRowCellValue("Name"))) = MsgBoxResult.Yes Then
            Dim SQL As String = String.Format("UPDATE employee_setup SET can_appraise = '{1}' WHERE ID = '{0}';", GridView1.GetFocusedRowCellValue("ID"), If(iAppraise.Text = "Can Appraise", 1, 0))
            DataObject(SQL)
            Logs("Chart of Accounts", iAppraise.Text, String.Format("Employee {0} {1}d.", GridView1.GetFocusedRowCellValue("Name"), iAppraise.Text.ToLower), "", "", "", "")
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            LoadData()
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GridView1.RowCount = 0 Then
            Exit Sub
        End If

        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If CBool(GridView1.GetFocusedRowCellValue("can_appraise")) = 0 Then
            iAppraise.Text = "Can Appraise"
        Else
            iAppraise.Text = "Cannot Appraise"
        End If
    End Sub

    Private Sub CbxPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPosition.SelectedIndexChanged
        If cbxPosition.Text = "" Or cbxPosition.SelectedIndex = -1 Then
            lblHead.Visible = False
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPosition.SelectedItem, DataRowView)
        If drv("head") Then
            lblHead.Visible = True
        Else
            lblHead.Visible = False
        End If
    End Sub

    Private Sub CbxSecondaryPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSecondaryPosition.SelectedIndexChanged
        If cbxSecondaryPosition.Text = "" Or cbxSecondaryPosition.SelectedIndex = -1 Then
            lblHeadv2.Visible = False
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxSecondaryPosition.SelectedItem, DataRowView)
        If drv("head") Then
            lblHeadv2.Visible = True
        Else
            lblHeadv2.Visible = False
        End If
    End Sub

    Private Sub CbxPosition_TextChanged(sender As Object, e As EventArgs) Handles cbxPosition.TextChanged
        If cbxPosition.Text = "" Or cbxPosition.SelectedIndex = -1 Then
            lblHead.Visible = False
        End If
    End Sub

    Private Sub CbxSecondaryPosition_TextChanged(sender As Object, e As EventArgs) Handles cbxSecondaryPosition.TextChanged
        If cbxSecondaryPosition.Text = "" Or cbxSecondaryPosition.SelectedIndex = -1 Then
            lblHeadv2.Visible = False
        End If
    End Sub
End Class