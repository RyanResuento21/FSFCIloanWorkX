Public Class FrmUser

    Dim ID As Integer
    ReadOnly DefaultImage As New DevExpress.XtraEditors.PictureEdit
    Dim FirstLoad As Boolean = True
    ReadOnly FailedLogin As Integer = 3
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim DT_BranchX As New DataTable
    Private Sub FrmUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_Avatar.Size = New Point(280, 275)
        pb_Avatar.Location = New Point(870, 16)
        DefaultImage.Image = pb_Avatar.Image.Clone
        SuperTabControl1.SelectedTab = tabList
        FirstLoad = True
        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            DT_BranchX = DataSource("SELECT ID, branch_code, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY Microfinance, branchID * 1;")
            .DataSource = DT_BranchX.Copy
            .SelectedIndex = -1
        End With

        With cbxBranchV2
            .Location = New Point(165, 497)
            .Size = New Point(484, 26)
            .Properties.LookAndFeel.SkinName = "Blue"
            .Properties.Items.Clear()
            For x As Integer = 0 To DT_BranchX.Rows.Count - 1
                .Properties.Items.Add(DT_BranchX(x)("ID"), DT_BranchX(x)("branch"), CheckState.Unchecked, True)
            Next
            .Properties.SeparatorChar = ";"
        End With

        With cbxUserType
            .ValueMember = "ID"
            .DisplayMember = "usertype"
            .DataSource = DataSource("SELECT ID, usertype FROM usertype_setup WHERE `status` = 'ACTIVE'")
            cbxUserType.Text = "USER"
        End With

        With cbxGroupRole
            .DisplayMember = "Position"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT CONCAT('P', ID) AS 'ID', `Position` FROM position_setup WHERE `status` = 'ACTIVE' UNION ALL SELECT CONCAT('G', ID) AS 'ID', GroupRole FROM group_role WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
            .SelectedIndex = -1
        End With

        If User_Type = "ADMIN" Then
            cbxUserType.Enabled = True
        End If
        LoadCode()
        LoadData()
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

            GetLabelFontSettings({LabelX15, lblDepartment, LabelX8, lblEmail, LabelX16, lblPosition, LabelX18, lblMobile, LabelX1, LabelX155, LabelX6, LabelX2, LabelX3, LabelX7, LabelX5, LabelX8, LabelX13, LabelX9, LabelX4, LabelX11, lblBranch, LabelX14})

            GetTextBoxFontSettings({txtUserCode, txtUsername, txtPassword, txtPassword_2, txtDomain, txtDomainUser, txtPath})

            GetComboBoxFontSettings({cbxBranch, cbxEmployee, cbxUserType, cbxGroupRole})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnInactive, btnResetPW, btnBrowse, btnView})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckBoxFontSettings({cbxMultiBranch, cbxAutoBugReport, cbxWebAccess, cbxEmail, cbxSMS, cbxROPA, cbxBorrower, cbxCreditApplication, cbxDomain, cbxCreditInvestigation, cbxDepartment, cbxBusinessCenter, cbxProgressBar, cbxAlertNotification, cbxKeyword, cbxAllowFormHistory})

            GetLabelFontSettingsRed({LabelX10, LabelX12})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetCheckComboBoxFontSettings({cbxBranchV2})
        Catch ex As Exception
            TriggerBugReport("User - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("User", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    users.ID,"
        SQL &= "    Branch,"
        SQL &= "    Department,"
        SQL &= "    Employee(empl_id)     AS 'Employee',"
        SQL &= "    IF(user_codeV2='',user_code,user_codeV2)     AS 'User Code',"
        SQL &= "    Username,"
        SQL &= "    user_type     AS 'User Type',"
        SQL &= "    EmailAdd AS 'Email Address', Empl_ID, Branch_ID,"
        SQL &= "    `Position`, MultiBranch, `Status`, (SELECT IFNULL(GROUP_CONCAT(DISTINCT branchid),'') FROM user_branch WHERE user_branch.user_code = users.user_code AND `status` = 'ACTIVE') AS 'MultiBranchID',"
        SQL &= "    WebAccess     AS 'Web Access', Email_Send, SMS_Send, ROPA_Notification, Borrower_Notification, CreditApplication_Notification, CreditInvestigation_Notification, Auto_Department, Auto_BusinessCenter, WithProgressBar, AlertNotification, AllowPrintScreen, KeywordSearchWildcard, AllowDomainLogin, Domain, Domain_user, AllowFormHistory, Salt, LogStatus, AgreeDate, AutoBugReport, GroupRoleID"
        SQL &= " FROM users LEFT JOIN (SELECT  ID, Branch, Department, `Position`, EmailAdd FROM employee_setup) A ON A.ID = users.empl_id"
        SQL &= " WHERE `status` IN ('ACTIVE','INACTIVE') AND Username != 'admin' ORDER BY username;"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Employee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Employee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub CbxBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxEmployee.Focus()
        End If
    End Sub

    Private Sub CbxEmployee_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxEmployee.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtUsername.Focus()
        End If
    End Sub

    Private Sub TxtUsername_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUsername.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub TxtPassword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword_2.Focus()
        End If
    End Sub

    Private Sub TxtPassword_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPassword_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxUserType.Focus()
        End If
    End Sub

    Private Sub CbxUserType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxUserType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDomain.Focus()
        End If
    End Sub

    Private Sub TxtDomain_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDomain.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDomainUser.Focus()
        End If
    End Sub

    Private Sub TxtDomainUser_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDomainUser.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxGroupRole.Focus()
        End If
    End Sub

    Private Sub CbxGroupRole_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxGroupRole.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub CbxBranch_Leave(sender As Object, e As EventArgs) Handles cbxBranch.Leave
        cbxBranch.Text = ReplaceText(cbxBranch.Text.Trim)
    End Sub

    Private Sub CbxEmployee_Leave(sender As Object, e As EventArgs) Handles cbxEmployee.Leave
        cbxEmployee.Text = ReplaceText(cbxEmployee.Text.Trim)
    End Sub

    Private Sub TxtUsername_Leave(sender As Object, e As EventArgs) Handles txtUsername.Leave
        txtUsername.Text = ReplaceText(txtUsername.Text.Trim)
    End Sub

    Private Sub TxtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        txtPassword.Text = ReplaceText(txtPassword.Text.Trim)

        If txtPassword.Text.Length < PWLength Then
            MsgBox(String.Format("Password must have at least {0} characters.", PWLength), MsgBoxStyle.Information, "Info")
            Exit Sub
        ElseIf PWCase And (txtPassword.Text Like "*[A-Z]*" = False Or txtPassword.Text Like "*[a-z]*" = False) Then
            MsgBox("Password must have Upper and Lower Case Letters.", MsgBoxStyle.Information, "Info")
            Exit Sub
        ElseIf PWSpecial And ContainsSpecial(txtPassword.Text) = False Then
            MsgBox("Password must have special characters.", MsgBoxStyle.Information, "Info")
            Exit Sub
        ElseIf PWNumeric And ContainsNumeric(txtPassword.Text) = False Then
            MsgBox("Password must have numeric characters.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
    End Sub

    Private Sub TxtPassword_2_Leave(sender As Object, e As EventArgs) Handles txtPassword_2.Leave
        txtPassword_2.Text = ReplaceText(txtPassword_2.Text.Trim)

        If txtPassword_2.Text.Trim <> txtPassword.Text.Trim Then
            MsgBox("Password does not match, please verify password", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
    End Sub

    Private Sub CbxUserType_Leave(sender As Object, e As EventArgs) Handles cbxUserType.Leave
        cbxUserType.Text = ReplaceText(cbxUserType.Text.Trim)
    End Sub

    Private Sub TxtDomain_Leave(sender As Object, e As EventArgs) Handles txtDomain.Leave
        txtDomain.Text = ReplaceText(txtDomain.Text.Trim)
    End Sub

    Private Sub TxtDomainUser_Leave(sender As Object, e As EventArgs) Handles txtDomainUser.Leave
        txtDomainUser.Text = ReplaceText(txtDomainUser.Text.Trim)
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
            btnResetPW.Enabled = False
            btnInactive.Visible = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
            If User_Type = "ADMIN" Then
                btnResetPW.Enabled = True
            Else
                btnResetPW.Enabled = False
            End If
            btnInactive.Enabled = False
            btnInactive.Visible = False
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
        LoadCode()
        btnInactive.Visible = False
        PanelEx10.Enabled = True
        cbxWebAccess.Checked = False
        cbxBranch.Text = ""
        cbxEmployee.SelectedIndex = -1
        txtUsername.Text = ""
        txtPassword.Text = ""
        txtPassword_2.Text = ""
        cbxUserType.Text = "USER"
        pb_Avatar.Image = DefaultImage.Image.Clone
        txtPath.Text = ""
        btnSave.Text = "&Save"
        txtUsername.Enabled = True
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        cbxBranch.Enabled = True
        cbxEmployee.Enabled = True
        txtPassword.Enabled = True
        txtPassword_2.Enabled = True

        cbxEmail.Checked = False
        cbxSMS.Checked = False
        cbxROPA.Checked = False
        cbxBorrower.Checked = False
        cbxCreditApplication.Checked = False
        cbxCreditInvestigation.Checked = False
        cbxDepartment.Checked = False
        cbxBusinessCenter.Checked = False
        cbxProgressBar.Checked = False
        cbxAlertNotification.Checked = False
        cbxAutoBugReport.Checked = False
        cbxKeyword.Checked = False
        cbxDomain.Checked = False
        cbxAllowFormHistory.Checked = False
        txtDomain.Text = ""
        txtDomainUser.Text = ""
        cbxGroupRole.SelectedIndex = -1

        'If cbxBranch.SelectedValue = "0" Then
        '    cbxMultiBranch.Visible = True
        '    cbxMultiBranch.Checked = False
        'Else
        '    cbxMultiBranch.Visible = False
        '    cbxMultiBranch.Checked = False
        'End If
        cbxBranchV2.Properties.Items.Clear()
        For x As Integer = 0 To DT_BranchX.Rows.Count - 1
            cbxBranchV2.Properties.Items.Add(DT_BranchX(x)("ID"), DT_BranchX(x)("branch"), CheckState.Unchecked, True)
        Next

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource("SELECT ID, branch_code, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY Microfinance, branchID * 1;")
            .SelectedIndex = -1
        End With

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub LoadCode()
        txtUserCode.Text = DataObject("SELECT CONCAT(YEAR(NOW()), '-',LPAD(COUNT(ID) + 1,4,'0')) FROM users WHERE YEAR(timestamp) = YEAR(NOW());")
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
            Exit Sub
        End If
        If txtUsername.Text = "" Then
            MsgBox("Please fill Username field.", MsgBoxStyle.Information, "Info")
            txtUsername.Focus()
            Exit Sub
        Else
            If ContainsNumeric(txtUsername.Text) Then
                MsgBox("Username contains number, please remove the number.", MsgBoxStyle.Information, "Info")
                txtUsername.Focus()
                Exit Sub
            ElseIf ContainsSpecial(txtUsername.Text) Then
                MsgBox("Username contains special character, please remove the special character.", MsgBoxStyle.Information, "Info")
                txtUsername.Focus()
                Exit Sub
            End If
        End If
        If txtUserCode.Text = "" Then
            MsgBox("User Code is empty, please contact ASG.", MsgBoxStyle.Information, "Info")
            txtUserCode.Focus()
            Exit Sub
        End If
        If btnSave.Text = "&Save" Then
            If txtPassword.Text = "" Then
                MsgBox("Please fill password field.", MsgBoxStyle.Information, "Info")
                txtPassword.Focus()
                Exit Sub
            End If
            If txtPassword.Text <> txtPassword_2.Text Then
                MsgBox("Password does not match, please write again your password.", MsgBoxStyle.Information, "Info")
                txtPassword.Text = ""
                txtPassword_2.Text = ""
                txtPassword.Focus()
                Exit Sub
            End If
        End If
        If cbxUserType.Text = "" Then
            MsgBox("Please select user type.", MsgBoxStyle.Information, "Info")
            cbxUserType.DroppedDown = True
            Exit Sub
        End If

        Dim drv_E As DataRowView = DirectCast(cbxEmployee.SelectedItem, DataRowView)
        Dim drv_B As DataRowView = DirectCast(cbxBranch.SelectedItem, DataRowView)
        Dim B_ID As String = cbxBranch.SelectedValue
        Dim B_Code As String = drv_B("branch_code")
        Dim B As String = cbxBranch.Text
        Dim Salt As String = GenerateRandomStrings(10)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM users WHERE username = '{0}';", txtUsername.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Username {0} is already taken, please use another.", txtUsername.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Exist = DataObject(String.Format("SELECT ID FROM users WHERE empl_id = '{0}';", cbxEmployee.SelectedValue))
                If Exist > 0 Then
                    If MsgBoxYes(String.Format("Employee {0} is already exist in the user's, would you like to create another user account under employee {0}?", cbxEmployee.Text)) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
                LoadCode()
                Exist = DataObject(String.Format("SELECT ID FROM users WHERE user_code = '{0}' AND `status` = 'ACTIVE'", txtUserCode.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("User code {0} already exist, please contact administration.", txtUserCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor

                Dim SQL As String = "INSERT INTO users_avatar SET"
                SQL &= String.Format(" user_code = '{0}';", txtUserCode.Text)

                SQL &= "INSERT INTO users SET"
                SQL &= String.Format(" user_code = '{0}', ", txtUserCode.Text)
                SQL &= String.Format(" user_codeV2 = '{0}', ", txtUserCode.Text)
                SQL &= String.Format(" username = '{0}', ", txtUsername.Text)
                SQL &= String.Format(" `password` = MD5(SHA1(CONCAT('{0}','{1}'))), ", txtPassword.Text, Salt)
                SQL &= String.Format(" `salt` = '{0}', ", Salt)
                SQL &= String.Format(" user_type = '{0}', ", cbxUserType.Text)
                SQL &= String.Format(" empl_id = '{0}', ", ValidateComboBox(cbxEmployee))
                SQL &= String.Format(" Branch_ID = '{0}',", B_ID)
                SQL &= String.Format(" MultiBranch = '{0}', ", If(cbxMultiBranch.Checked, 1, 0))
                SQL &= String.Format(" WebAccess = '{0}', ", If(cbxWebAccess.Checked, 1, 0))
                SQL &= String.Format(" Email_Send = {0}, ", If(cbxEmail.Checked, 1, 0))
                SQL &= String.Format(" SMS_Send = {0}, ", If(cbxSMS.Checked, 1, 0))
                SQL &= String.Format(" ROPA_Notification = {0}, ", If(cbxROPA.Checked, 1, 0))
                SQL &= String.Format(" Borrower_Notification = {0}, ", If(cbxBorrower.Checked, 1, 0))
                SQL &= String.Format(" CreditApplication_Notification = {0}, ", If(cbxCreditApplication.Checked, 1, 0))
                SQL &= String.Format(" CreditInvestigation_Notification = {0}, ", If(cbxCreditInvestigation.Checked, 1, 0))
                SQL &= String.Format(" Auto_Department = {0}, ", If(cbxDepartment.Checked, 1, 0))
                SQL &= String.Format(" Auto_BusinessCenter = {0}, ", If(cbxBusinessCenter.Checked, 1, 0))
                SQL &= String.Format(" WithProgressBar = {0}, ", If(cbxProgressBar.Checked, 1, 0))
                SQL &= String.Format(" AllowPrintScreen = {0}, ", 1)
                SQL &= String.Format(" KeywordSearchWildcard = {0}, ", If(cbxKeyword.Checked, 1, 0))
                SQL &= String.Format(" AllowDomainLogin = {0}, ", If(cbxDomain.Checked, 1, 0))
                SQL &= String.Format(" AllowFormHistory = {0}, ", If(cbxAllowFormHistory.Checked, 1, 0))
                SQL &= String.Format(" AutoBugReport = {0}, ", If(cbxAutoBugReport.Checked, 1, 0))
                SQL &= String.Format(" Domain = '{0}', ", txtDomain.Text)
                SQL &= String.Format(" Domain_user = '{0}', ", txtDomainUser.Text)
                SQL &= String.Format(" GroupRoleID = '{0}',", ValidateComboBox(cbxGroupRole))
                SQL &= String.Format(" AlertNotification = {0};", If(cbxAlertNotification.Checked, 1, 0))

                For x As Integer = 0 To cbxBranchV2.Properties.Items.Count - 1
                    If cbxBranchV2.Properties.Items.Item(x).CheckState = CheckState.Checked And cbxMultiBranch.Checked Then
                        SQL &= " INSERT INTO user_branch SET "
                        SQL &= String.Format(" user_code = '{0}',", txtUserCode.Text)
                        SQL &= String.Format(" EmplID = '{0}',", ValidateComboBox(cbxEmployee))
                        SQL &= String.Format(" Branch_ID = '{0}',", B_ID)
                        SQL &= String.Format(" BranchID = '{0}',", cbxBranchV2.Properties.Items.Item(x).Value)
                        SQL &= String.Format(" Branch = '{0}';", cbxBranchV2.Properties.Items.Item(x).Description)
                    End If
                Next
                DataObject(SQL)

                If txtPath.Text = "" Then
                Else
                    SavePhoto(String.Format("UPDATE users_avatar SET picture = ?bin_data WHERE user_code = '{0}'", txtUserCode.Text), txtPath.Text)
                End If
                Cursor = Cursors.Default

                Logs("User", "Save", String.Format("Add new user {0}", txtUsername.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM users WHERE username = '{0}' AND ID != '{1}'", txtUsername.Text, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Username {0} is already taken, please think another username", txtUsername.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE users SET"
                SQL &= String.Format(" username = '{0}', ", txtUsername.Text)
                SQL &= String.Format(" user_type = '{0}', ", cbxUserType.Text)
                SQL &= String.Format(" MultiBranch = '{0}', ", If(cbxMultiBranch.Checked, 1, 0))
                SQL &= String.Format(" WebAccess = '{0}', ", If(cbxWebAccess.Checked, 1, 0))
                SQL &= String.Format(" Email_Send = {0}, ", If(cbxEmail.Checked, 1, 0))
                SQL &= String.Format(" SMS_Send = {0}, ", If(cbxSMS.Checked, 1, 0))
                SQL &= String.Format(" ROPA_Notification = {0}, ", If(cbxROPA.Checked, 1, 0))
                SQL &= String.Format(" Borrower_Notification = {0}, ", If(cbxBorrower.Checked, 1, 0))
                SQL &= String.Format(" CreditApplication_Notification = {0}, ", If(cbxCreditApplication.Checked, 1, 0))
                SQL &= String.Format(" CreditInvestigation_Notification = {0}, ", If(cbxCreditInvestigation.Checked, 1, 0))
                SQL &= String.Format(" Auto_Department = {0}, ", If(cbxDepartment.Checked, 1, 0))
                SQL &= String.Format(" Auto_BusinessCenter = {0}, ", If(cbxBusinessCenter.Checked, 1, 0))
                SQL &= String.Format(" WithProgressBar = {0}, ", If(cbxProgressBar.Checked, 1, 0))
                SQL &= String.Format(" KeywordSearchWildcard = {0}, ", If(cbxKeyword.Checked, 1, 0))
                SQL &= String.Format(" AllowDomainLogin = {0}, ", If(cbxDomain.Checked, 1, 0))
                SQL &= String.Format(" AllowFormHistory = {0}, ", If(cbxAllowFormHistory.Checked, 1, 0))
                SQL &= String.Format(" AutoBugReport = {0}, ", If(cbxAutoBugReport.Checked, 1, 0))
                SQL &= String.Format(" Domain = '{0}', ", txtDomain.Text)
                SQL &= String.Format(" Domain_user = '{0}', ", txtDomainUser.Text)
                SQL &= String.Format(" GroupRoleID = '{0}',", ValidateComboBox(cbxGroupRole))
                SQL &= String.Format(" AlertNotification = {0}", If(cbxAlertNotification.Checked, 1, 0))
                SQL &= String.Format(" WHERE ID = '{0}';", ID)

                SQL &= String.Format(" UPDATE user_branch SET `status` = 'CANCELLED' WHERE user_code = '{0}';", txtUserCode.Text)
                For x As Integer = 0 To cbxBranchV2.Properties.Items.Count - 1
                    If cbxBranchV2.Properties.Items.Item(x).CheckState = CheckState.Checked And cbxMultiBranch.Checked Then
                        SQL &= " INSERT INTO user_branch SET "
                        SQL &= String.Format(" user_code = '{0}',", txtUserCode.Text)
                        SQL &= String.Format(" EmplID = '{0}',", ValidateComboBox(cbxEmployee))
                        SQL &= String.Format(" Branch_ID = '{0}',", B_ID)
                        SQL &= String.Format(" BranchID = '{0}',", cbxBranchV2.Properties.Items.Item(x).Value)
                        SQL &= String.Format(" Branch = '{0}';", cbxBranchV2.Properties.Items.Item(x).Description)
                    End If
                Next
                DataObject(SQL)

                If txtPath.Text = "" Then
                Else
                    Dim UID As Integer = DataObject(String.Format("SELECT ID FROM users_avatar WHERE user_code = '{0}';", txtUserCode.Text))
                    If UID Then
                        DataObject(String.Format("INSERT INTO users_avatar SET user_code = '{0}';", txtUserCode.Text))
                    End If
                    SavePhoto(String.Format("UPDATE users_avatar SET picture = ?bin_data WHERE user_code = '{0}'", txtUserCode.Text), txtPath.Text)
                End If
                Cursor = Cursors.Default

                Logs("User", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtUsername.Text = txtUsername.Tag Then
            Else
                Change &= String.Format("Change Username from {0} to {1}. ", txtUsername.Tag, txtUsername.Text)
            End If
            If cbxUserType.Text = cbxUserType.Tag Then
            Else
                Change &= String.Format("Change User Type from {0} to {1}. ", cbxUserType.Tag, cbxUserType.Text)
            End If
            If If(cbxEmail.Checked, "On", "Off") = cbxEmail.Tag Then
            Else
                Change &= String.Format("Change Email Sender from {0} to {1}. ", cbxEmail.Tag, If(cbxEmail.Checked, "On", "Off"))
            End If
            If If(cbxSMS.Checked, "On", "Off") = cbxSMS.Tag Then
            Else
                Change &= String.Format("Change SMS Sender from {0} to {1}. ", cbxSMS.Tag, If(cbxSMS.Checked, "On", "Off"))
            End If
            If If(cbxROPA.Checked, "On", "Off") = cbxROPA.Tag Then
            Else
                Change &= String.Format("Change ROPA Notification from {0} to {1}. ", cbxROPA.Tag, If(cbxROPA.Checked, "On", "Off"))
            End If
            If If(cbxBorrower.Checked, "On", "Off") = cbxBorrower.Tag Then
            Else
                Change &= String.Format("Change Borrower Notification from {0} to {1}. ", cbxBorrower.Tag, If(cbxBorrower.Checked, "On", "Off"))
            End If
            If If(cbxCreditApplication.Checked, "On", "Off") = cbxCreditApplication.Tag Then
            Else
                Change &= String.Format("Change Credit Application Notification from {0} to {1}. ", cbxCreditApplication.Tag, If(cbxCreditApplication.Checked, "On", "Off"))
            End If
            If If(cbxCreditInvestigation.Checked, "On", "Off") = cbxCreditInvestigation.Tag Then
            Else
                Change &= String.Format("Change Credit Investigation Notification from {0} to {1}. ", cbxCreditInvestigation.Tag, If(cbxCreditInvestigation.Checked, "On", "Off"))
            End If
            If If(cbxDepartment.Checked, "On", "Off") = cbxDepartment.Tag Then
            Else
                Change &= String.Format("Change Auto Department Suggestion from {0} to {1}. ", cbxDepartment.Tag, If(cbxDepartment.Checked, "On", "Off"))
            End If
            If If(cbxBusinessCenter.Checked, "On", "Off") = cbxBusinessCenter.Tag Then
            Else
                Change &= String.Format("Change Auto Business Center Suggestion from {0} to {1}. ", cbxBusinessCenter.Tag, If(cbxBusinessCenter.Checked, "On", "Off"))
            End If
            If If(cbxProgressBar.Checked, "On", "Off") = cbxProgressBar.Tag Then
            Else
                Change &= String.Format("Change Show Progress Bar from {0} to {1}. ", cbxProgressBar.Tag, If(cbxProgressBar.Checked, "On", "Off"))
            End If
            If If(cbxAlertNotification.Checked, "On", "Off") = cbxAlertNotification.Tag Then
            Else
                Change &= String.Format("Change Auto Alert Notification from {0} to {1}. ", cbxAlertNotification.Tag, If(cbxAlertNotification.Checked, "On", "Off"))
            End If
            If If(cbxKeyword.Checked, "On", "Off") = cbxKeyword.Tag Then
            Else
                Change &= String.Format("Change Keyword Wildcard from {0} to {1}. ", cbxKeyword.Tag, If(cbxKeyword.Checked, "On", "Off"))
            End If
            If txtDomain.Text = txtDomain.Tag Then
            Else
                Change &= String.Format("Change Domain from {0} to {1}. ", txtDomain.Tag, txtDomain.Text)
            End If
            If txtDomainUser.Text = txtDomainUser.Tag Then
            Else
                Change &= String.Format("Change Domain User from {0} to {1}. ", txtDomainUser.Tag, txtDomainUser.Text)
            End If
            If If(cbxDomain.Checked, "On", "Off") = cbxDomain.Tag Then
            Else
                Change &= String.Format("Change Allow Domain Login from {0} to {1}. ", cbxDomain.Tag, If(cbxDomain.Checked, "On", "Off"))
            End If
            If If(cbxAllowFormHistory.Checked, "On", "Off") = cbxAllowFormHistory.Tag Then
            Else
                Change &= String.Format("Change Allow Form History from {0} to {1}. ", cbxAllowFormHistory.Tag, If(cbxAllowFormHistory.Checked, "On", "Off"))
            End If
            If If(cbxAutoBugReport.Checked, "On", "Off") = cbxAllowFormHistory.Tag Then
            Else
                Change &= String.Format("Change Auto Bug Report from {0} to {1}. ", cbxAutoBugReport.Tag, If(cbxAutoBugReport.Checked, "On", "Off"))
            End If
            If cbxGroupRole.Text = cbxGroupRole.Tag Then
            Else
                Change &= String.Format("Change Group Role from {0} to {1}. ", cbxGroupRole.Tag, cbxGroupRole.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("User - Changes", ex.Message.ToString)
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
            btnResetPW.Enabled = True
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
            DataObject(String.Format("UPDATE users SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("User", "Cancel", Reason, String.Format("Cancel user {0}", txtUsername.Text), "", "", "")
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
        StandardPrinting("USER LIST", GridControl1)
        Logs("User", "Print", "[SENSITIVE] Print User List", "", "", "", "")
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
        ElseIf e.Control And e.KeyCode = Keys.R Then
            btnResetPW.Focus()
            btnResetPW.PerformClick()
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

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    txtPath.Text = OFD.FileName
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(txtPath.Text)
                        ResizeImages(TempPB.Image.Clone, pb_Avatar, 650, 500)
                    End Using
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
    End Sub

    Private Sub Pb_Avatar_Click(sender As Object, e As MouseEventArgs) Handles pb_Avatar.Click
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                btnBrowse.PerformClick()
            End If
        Catch ex As Exception
            TriggerBugReport("User - Avatar Click", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim SQL As String = "SELECT ID, "
        SQL &= "    emp_code, "
        SQL &= "    CONCAT(IF(prefix = '','',CONCAT(prefix, ' ')), IF(first_name = '','',CONCAT(first_name, ' ')), IF(middle_name = '','',CONCAT(middle_name, ' ')), IF(last_name = '','',CONCAT(last_name, ' ')), suffix) AS 'Name',"
        SQL &= "    department_id,"
        SQL &= "    department, "
        SQL &= "    (SELECT department_code FROM department_setup WHERE department_setup.ID = employee_setup.department_id) AS 'department_code', `Position`,"
        SQL &= "    CONCAT(LOWER(SUBSTRING(first_name,1,1)), CONCAT(LOWER(REPLACE(last_name,' ','')))) AS 'Username',"
        SQL &= "    position, EmailAdd, CONCAT('+63',Phone) AS 'Phone'"
        SQL &= " FROM employee_setup "
        SQL &= String.Format("    WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Name`;", ValidateComboBox(cbxBranch))

        With cbxEmployee
            .DisplayMember = "Name"
            .ValueMember = "ID"
            .DataSource = DataSource(SQL)
            .SelectedIndex = -1
        End With

        'If cbxBranch.SelectedValue = "0" Then
        '    cbxMultiBranch.Visible = True
        '    cbxMultiBranch.Checked = False
        'Else
        '    cbxMultiBranch.Visible = False
        '    cbxMultiBranch.Checked = False
        'End If

        Dim drv_B As DataRowView = DirectCast(cbxBranch.SelectedItem, DataRowView)
        If cbxBranch.Text = "" Or cbxEmployee.Text = "" Then
            cbxGroupRole.Text = ""
            lblDepartment.Text = ""
            lblPosition.Text = ""
            lblEmail.Text = ""
            lblMobile.Text = ""
        End If
    End Sub

    Private Sub CbxEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxEmployee.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv_E As DataRowView = DirectCast(cbxEmployee.SelectedItem, DataRowView)
        If cbxEmployee.Text = "" Then
            txtUsername.Text = ""
            cbxGroupRole.Text = ""
            lblDepartment.Text = ""
            lblPosition.Text = ""
            lblEmail.Text = ""
            lblMobile.Text = ""
        Else
            txtUsername.Text = drv_E("Username")
            cbxGroupRole.Text = drv_E("Position")
            lblDepartment.Text = drv_E("Department")
            lblPosition.Text = drv_E("Position")
            lblEmail.Text = drv_E("EmailAdd")
            lblMobile.Text = drv_E("Phone")
        End If
    End Sub

    Private Sub CbxEmployee_TextChanged(sender As Object, e As EventArgs) Handles cbxEmployee.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxEmployee.Text = "" Then
            txtUsername.Text = ""
            cbxGroupRole.Text = ""
            lblDepartment.Text = ""
            lblPosition.Text = ""
            lblEmail.Text = ""
            lblMobile.Text = ""
        End If
    End Sub

    Private Sub BtnResetPW_Click(sender As Object, e As EventArgs) Handles btnResetPW.Click
        If MsgBoxYes(String.Format("Are you sure you want to reset the password of {0}?", GridView1.GetFocusedRowCellValue("Username"))) = MsgBoxResult.Yes Then
            Dim PW As New FrmPassword
            PW.lblNote.Text = "Please enter a temporary password."
            If PW.ShowDialog = DialogResult.OK Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                DataObject(String.Format("UPDATE users SET `password` = MD5(SHA1(CONCAT('{1}','{2}'))), ChangePW = {3} WHERE ID = {0}", GridView1.GetFocusedRowCellValue("ID"), PW.txtPassword.Text, GridView1.GetFocusedRowCellValue("Salt"), If(GridView1.GetFocusedRowCellValue("ID") <> User_ID And PWForceChange, 1, 0)))
                Logs("User", "ResetPW", Reason, String.Format("Reset password of user {0}", GridView1.GetFocusedRowCellValue("Username")), "", "", "")
                If GridView1.GetFocusedRowCellValue("Email Address").ToString.Trim = "" Then
                    MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
                Else
                    If MsgBoxYes("Successfully Changed!, would you like the system to send an email about the password?") = MsgBoxResult.Yes Then
                        Try
                            Dim Subject As String = "FSFC System temporary password."
                            Dim Body As String = String.Format("Your FSFC System TEMPORARY password is {0}. Please change it immediately for security purposes.", PW.txtPassword.Text)
                            SendEmail(GridView1.GetFocusedRowCellValue("Email Address"), Subject, Body, False, True, False, 0, "", "")
                        Catch ex As Exception
                            TriggerBugReport("User - Reset PW", ex.Message.ToString)
                        End Try
                    End If
                End If
            End If
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
            cbxBranch.SelectedValue = .GetFocusedRowCellValue("Branch_ID")
            cbxBranch.Text = .GetFocusedRowCellValue("Branch")
            cbxEmployee.SelectedValue = .GetFocusedRowCellValue("Empl_ID")
            cbxEmployee.Text = .GetFocusedRowCellValue("Employee")
            txtUserCode.Text = .GetFocusedRowCellValue("User Code")

            txtUsername.Text = .GetFocusedRowCellValue("Username")
            txtUsername.Tag = .GetFocusedRowCellValue("Username")
            cbxUserType.Text = .GetFocusedRowCellValue("User Type")
            cbxUserType.Tag = .GetFocusedRowCellValue("User Type")
            txtDomain.Text = .GetFocusedRowCellValue("Domain")
            txtDomain.Tag = .GetFocusedRowCellValue("Domain")
            txtDomainUser.Text = .GetFocusedRowCellValue("Domain_user")
            txtDomainUser.Tag = .GetFocusedRowCellValue("Domain_user")

            cbxEmail.Checked = .GetFocusedRowCellValue("Email_Send")
            cbxSMS.Checked = .GetFocusedRowCellValue("SMS_Send")
            cbxROPA.Checked = .GetFocusedRowCellValue("ROPA_Notification")
            cbxBorrower.Checked = .GetFocusedRowCellValue("Borrower_Notification")
            cbxCreditApplication.Checked = .GetFocusedRowCellValue("CreditApplication_Notification")
            cbxCreditInvestigation.Checked = .GetFocusedRowCellValue("CreditInvestigation_Notification")
            cbxDepartment.Checked = .GetFocusedRowCellValue("Auto_Department")
            cbxBusinessCenter.Checked = .GetFocusedRowCellValue("Auto_BusinessCenter")
            cbxProgressBar.Checked = .GetFocusedRowCellValue("WithProgressBar")
            cbxAlertNotification.Checked = .GetFocusedRowCellValue("AlertNotification")
            cbxKeyword.Checked = .GetFocusedRowCellValue("KeywordSearchWildcard")
            cbxDomain.Checked = .GetFocusedRowCellValue("AllowDomainLogin")
            cbxAllowFormHistory.Checked = .GetFocusedRowCellValue("AllowFormHistory")
            cbxAutoBugReport.Checked = .GetFocusedRowCellValue("AutoBugReport")

            cbxEmail.Tag = If(.GetFocusedRowCellValue("Email_Send"), "On", "Off")
            cbxSMS.Tag = If(.GetFocusedRowCellValue("SMS_Send"), "On", "Off")
            cbxROPA.Tag = If(.GetFocusedRowCellValue("ROPA_Notification"), "On", "Off")
            cbxBorrower.Tag = If(.GetFocusedRowCellValue("Borrower_Notification"), "On", "Off")
            cbxCreditApplication.Tag = If(.GetFocusedRowCellValue("CreditApplication_Notification"), "On", "Off")
            cbxCreditInvestigation.Tag = If(.GetFocusedRowCellValue("CreditInvestigation_Notification"), "On", "Off")
            cbxDepartment.Tag = If(.GetFocusedRowCellValue("Auto_Department"), "On", "Off")
            cbxBusinessCenter.Tag = If(.GetFocusedRowCellValue("Auto_BusinessCenter"), "On", "Off")
            cbxProgressBar.Tag = If(.GetFocusedRowCellValue("WithProgressBar"), "On", "Off")
            cbxAlertNotification.Tag = If(.GetFocusedRowCellValue("AlertNotification"), "On", "Off")
            cbxKeyword.Tag = If(.GetFocusedRowCellValue("KeywordSearchWildcard"), "On", "Off")
            cbxDomain.Tag = If(.GetFocusedRowCellValue("AllowDomainLogin"), "On", "Off")
            cbxAllowFormHistory.Tag = If(.GetFocusedRowCellValue("AllowFormHistory"), "On", "Off")
            cbxAutoBugReport.Tag = If(.GetFocusedRowCellValue("AutoBugReport"), "On", "Off")
            cbxGroupRole.SelectedValue = .GetFocusedRowCellValue("GroupRoleID")

            cbxBranchV2.SetEditValue(.GetFocusedRowCellValue("MultiBranchID").ToString.Replace(",", "; "))

            If .GetFocusedRowCellValue("MultiBranch") = True Then
                cbxMultiBranch.Checked = True
            Else
                cbxMultiBranch.Checked = False
            End If

            If .GetFocusedRowCellValue("Web Access") = True Then
                cbxWebAccess.Checked = True
            Else
                cbxWebAccess.Checked = False
            End If

            Dim SQL As String = String.Format("SELECT picture FROM users_avatar WHERE ID = '{0}'", .GetFocusedRowCellValue("ID"))
            RetrieveImage_PicEdit(SQL, pb_Avatar, "picture")

            SuperTabControl1.SelectedTab = tabSetup
            btnModify.Enabled = True
            btnSave.Enabled = False
            cbxBranch.Enabled = False
            cbxEmployee.Enabled = False
            txtUserCode.Enabled = False
            txtUsername.Enabled = False
            txtPassword.Enabled = False
            txtPassword_2.Enabled = False

            If .GetFocusedRowCellValue("Status") = "ACTIVE" Then
                btnInactive.Enabled = True
                btnInactive.Text = "Inactive"
            ElseIf .GetFocusedRowCellValue("Status") = "INACTIVE" Then
                btnInactive.Enabled = True
                btnInactive.Text = "Active"
                btnModify.Enabled = False
            Else
                btnModify.Enabled = False
                btnInactive.Enabled = False
            End If
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            Dim LogStatus As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("LogStatus"))
            If Status = "DELETED" Or Status = "INACTIVE" Or LogStatus = "LOCKED" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            End If
        End If
    End Sub

    Private Sub BtnInactive_Click(sender As Object, e As EventArgs) Handles btnInactive.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnInactive.Text = "Inactive" Then
            If MsgBoxYes("Are you sure you want to set this User as Inactive?") = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                DataObject(String.Format("UPDATE users SET `status` = 'INACTIVE' WHERE ID = '{0}'", ID))
                Logs("Users", "Inactive", Reason, String.Format("Inactive User {0} for {1}", txtUsername.Text, cbxEmployee.Tag), "", "", "")
                Clear(True)
                MsgBox("Successfully set as Inactive", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes("Are you sure you want to set this User as Active?") = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                DataObject(String.Format("UPDATE users SET `status` = 'ACTIVE' WHERE ID = '{0}'", ID))
                Logs("Users", "Active", Reason, String.Format("Activate User {0} for {1}", txtUsername.Text, cbxEmployee.Tag), "", "", "")
                Clear(True)
                MsgBox("Successfully set as Active", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub CbxMultiBranch_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMultiBranch.CheckedChanged
        If cbxMultiBranch.Checked Then
            cbxBranchV2.Enabled = True
        Else
            cbxBranchV2.Enabled = False
        End If
    End Sub

    Private Sub IAllowPrintScreen_Click(sender As Object, e As EventArgs) Handles iAllowPrintScreen.Click
        Try
            If GridView1.GetFocusedRowCellValue("Username") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("AllowPrintScreen") = True Then
            If MsgBoxYes(String.Format("Are you sure you want to disable the print screen for {0}?", GridView1.GetFocusedRowCellValue("Employee"))) = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE users SET AllowPrintScreen = 0 WHERE ID = {0};", GridView1.GetFocusedRowCellValue("ID")))
                MsgBox("Successfully Disabled!", MsgBoxStyle.Information, "Info")
                LoadData()
                Logs("Users", "Disable PS", "", String.Format("Disable Print Screen for {0}.", GridView1.GetFocusedRowCellValue("Employee")), "", "", "")
            End If
        Else
            If MsgBoxYes(String.Format("Are you sure you want to enable the print screen for {0}?", GridView1.GetFocusedRowCellValue("Employee"))) = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE users SET AllowPrintScreen = 1 WHERE ID = {0};", GridView1.GetFocusedRowCellValue("ID")))
                MsgBox("Successfully Enabled!", MsgBoxStyle.Information, "Info")
                LoadData()
                Logs("Users", "Enable PS", "", String.Format("Enable Print Screen for {0}.", GridView1.GetFocusedRowCellValue("Employee")), "", "", "")
            End If
        End If
    End Sub

    Private Sub ILockAccount_Click(sender As Object, e As EventArgs) Handles iLockAccount.Click
        Try
            If GridView1.GetFocusedRowCellValue("Username") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("LogStatus") = "LOCKED" Then
            If MsgBoxYes(String.Format("Are you sure you want to unlock the account of {0}?", GridView1.GetFocusedRowCellValue("Employee"))) = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE failed_login SET `status` = 'DONE' WHERE UserID = '{0}'; UPDATE users SET LogStatus = 'OPEN' WHERE ID = {0};", GridView1.GetFocusedRowCellValue("ID")))
                MsgBox("Successfully Unlocked!", MsgBoxStyle.Information, "Info")
                LoadData()
                Logs("Users", "Unlock Account", "", String.Format("Unlock the account of {0}.", GridView1.GetFocusedRowCellValue("Employee")), "", "", "")
            End If
        Else
            If MsgBoxYes(String.Format("Are you sure you want to lock the account of {0}?", GridView1.GetFocusedRowCellValue("Employee"))) = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE users SET LogStatus = 'LOCKED', LockedTime = CURRENT_TIMESTAMP() WHERE ID = {0};", GridView1.GetFocusedRowCellValue("ID")))
                MsgBox("Successfully Locked!", MsgBoxStyle.Information, "Info")
                LoadData()
                Logs("Users", "Lock Account", "", String.Format("Lock the account of {0}.", GridView1.GetFocusedRowCellValue("Employee")), "", "", "")
            End If
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        If GridView1.RowCount = 0 Then
            Exit Sub
        End If

        If GridView1.GetFocusedRowCellValue("AllowPrintScreen") = True Then
            iAllowPrintScreen.Text = "Disable Print Screen"
        Else
            iAllowPrintScreen.Text = "Enable Print Screen"
        End If
        If GridView1.GetFocusedRowCellValue("LogStatus") = "LOCKED" Then
            iLockAccount.Text = "Unlock Account"
        Else
            iLockAccount.Text = "Lock Account"
        End If
    End Sub

    Private Sub IShowAgreement_Click(sender As Object, e As EventArgs) Handles iShowAgreement.Click
        Try
            If GridView1.GetFocusedRowCellValue("Username") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("AgreeDate") = "" Then
            MsgBox(String.Format("{0} haven't signed the agreement yet. The agreement will show upon his/her first sign in.", GridView1.GetFocusedRowCellValue("Employee")), MsgBoxStyle.Information, "Info")
        Else
            If MsgBoxYes(String.Format("Are you sure you want to show the agreement for {0} which he/she agreed dated on {1}?", GridView1.GetFocusedRowCellValue("Employee"), GridView1.GetFocusedRowCellValue("AgreeDate"))) = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE users SET AgreeDate = '' WHERE ID = {0};", GridView1.GetFocusedRowCellValue("ID")))
                Logs("Users", "Show Agreement", "", String.Format("Show Agreement for {0} which last agreed was {1}.", GridView1.GetFocusedRowCellValue("Employee"), GridView1.GetFocusedRowCellValue("AgreeDate")), "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If cbxGroupRole.SelectedIndex = -1 Or cbxGroupRole.Text = "" Then
            MsgBox("Please select a group role first to view the access.", MsgBoxStyle.Information, "Info")
            cbxGroupRole.DroppedDown = True
            Exit Sub
        End If

        Dim Group As New FrmGroupRole
        With Group
            .ViewMode = True
            .GroupRole = cbxGroupRole.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class