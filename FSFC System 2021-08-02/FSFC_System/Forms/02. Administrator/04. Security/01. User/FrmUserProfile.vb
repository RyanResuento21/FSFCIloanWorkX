Public Class FrmUserProfile

    Dim DT_Permission As DataTable
    Dim Code As String
    Dim Msg As String = ""
    Dim DT_BranchX As DataTable
    Dim DT_File As DataTable
    Dim TotalSize As Double
    Dim TotalFile As Integer
    Dim AgreeDate As String

    Private Sub FrmUserProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_Avatar.Size = New Point(280, 275)
        pb_Avatar.Location = New Point(875, 17)
        dtpBirth.Value = Date.Now
        dtpFrom.Value = Date.Now
        dtpTo.Value = Date.Now
        Code = GenerateOTAC()
        If Salt = "" Then
            Salt = GenerateRandomStrings(10)
        End If

        With cbxSuffix
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        DT_BranchX = DataSource("SELECT ID, branch_code, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY Microfinance, branchID * 1;")
        With cbxBranchV2
            .Location = New Point(162, 252)
            .Size = New Point(484, 26)
            .Properties.LookAndFeel.SkinName = "Blue"
            .Properties.Items.Clear()
            For x As Integer = 0 To DT_BranchX.Rows.Count - 1
                .Properties.Items.Add(DT_BranchX(x)("ID"), DT_BranchX(x)("branch"), CheckState.Unchecked, True)
            Next
            .Properties.SeparatorChar = ";"
        End With

        With cbxGroupRole
            .DisplayMember = "Position"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT CONCAT('P', ID) AS 'ID', `Position` FROM position_setup WHERE `status` = 'ACTIVE' UNION ALL SELECT CONCAT('G', ID) AS 'ID', GroupRole FROM group_role WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
            .SelectedIndex = -1
        End With

        With cbxForm
            .DisplayMember = "Form"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, CONCAT('[', module, '] ', IF(`group` = '','',CONCAT('(',`group`,') ')), form) AS 'Form' FROM form_setup WHERE `status` = 'ACTIVE' ORDER BY order_id;")
            .SelectedValue = DefaultForm
            .Tag = .Text
        End With

        DT_File = DataSource(String.Format("SELECT Attachment_1, Attachment_2, Attachment_3, Attachment_4, Attachment_5, Attachment_6, Attachment_7, Attachment_8, Attachment_9, Attachment_10 FROM email_outbox WHERE EmplID = '{0}' AND `status` = 'SENT';", Empl_ID))

        LoadData()
        ScanCache(False)
    End Sub

    Private Sub LoadData()
        Try
            Dim DT_Employee As DataTable = DataSource(String.Format("SELECT first_name, middle_name, last_name, suffix, nickname, id_number, birthdate, hireddate, `position`, secondary_position, department, branch, Phone, EmailAdd FROM employee_setup WHERE ID = {0};", Empl_ID))
            If DT_Employee.Rows.Count > 0 Then
                txtFirstN.Text = DT_Employee(0)("first_name")
                txtFirstN.Tag = DT_Employee(0)("first_name")
                txtMiddleN.Text = DT_Employee(0)("middle_name")
                txtMiddleN.Tag = DT_Employee(0)("middle_name")
                txtLastN.Text = DT_Employee(0)("last_name")
                txtLastN.Tag = DT_Employee(0)("last_name")
                cbxSuffix.Text = DT_Employee(0)("suffix")
                cbxSuffix.Tag = DT_Employee(0)("suffix")
                Nickname = DT_Employee(0)("nickname")
                txtNickname.Text = Nickname
                txtNickname.Tag = Nickname
                txtEmployeeID.Text = DT_Employee(0)("id_number")
                txtEmployeeID.Tag = DT_Employee(0)("id_number")
                If DT_Employee(0)("Birthdate").ToString = "" Then
                    CbxNA_Birth.Checked = True
                Else
                    dtpBirth.Value = DT_Employee(0)("Birthdate").ToString
                End If
                If DT_Employee(0)("hireddate").ToString = "" Then
                    lblDateHired.Text = ""
                Else
                    lblDateHired.Text = Format(DateValue(DT_Employee(0)("hireddate")), "MMMM dd, yyyy")
                End If
                dtpBirth.Tag = DT_Employee(0)("Birthdate").ToString
                Empl_Position = DT_Employee(0)("Position").ToString
                Empl_V2Position = DT_Employee(0)("secondary_position").ToString
                Branch = DT_Employee(0)("branch").ToString
                Department = DT_Employee(0)("department").ToString
                Empl_Phone = DT_Employee(0)("Phone").ToString
                Empl_Email = DT_Employee(0)("EmailAdd").ToString
                lblPosition.Text = Empl_Position
                lblSecondaryPos.Text = Empl_V2Position
                lblBranchEmp.Text = Branch
                lblDepartment.Text = Department
                txtMobile.Text = Empl_Phone
                txtMobile.Tag = Empl_Phone
                txtEmail.Text = Empl_Email
                txtEmail.Tag = Empl_Email
            End If
            If FrmMain.PictureEdit1.Image.Size.IsEmpty = False Then
                pb_Avatar.Image = FrmMain.PictureEdit1.Image.Clone
            End If

            Dim DT_User As DataTable = DataSource(String.Format("SELECT Domain, Domain_user, user_type, user_codeV2, GroupRoleID, MultiAuthentication, `session`,  (SELECT IFNULL(GROUP_CONCAT(DISTINCT branchid),'') FROM user_branch WHERE user_branch.user_code = users.user_code AND `status` = 'ACTIVE') AS 'MultiBranchID', AgreeDate, MultiBranch, Auto_Department, Auto_BusinessCenter, Email_Send, SendPendingEmailEvery, SMS_Send, ROPA_Notification, Borrower_Notification, CreditApplication_Notification, CreditInvestigation_Notification, AlertNotification, AutoBugReport, AllowPrintScreen, KeywordSearchWildcard, AllowDomainLogin, AllowFormHistory, AllowUI, NotifyLoggedInToOthers FROM users WHERE ID = '{0}';", User_ID))
            cbxUserType.Text = User_Type
            txtUserCode.Text = User_Code
            txtUsername.Text = FrmLogin.txtUserName.Text
            cbxGroupRole.SelectedValue = GroupRoleID
            If DT_User.Rows.Count > 0 Then
                txtDomain.Text = DT_User(0)("Domain")
                txtDomainUser.Text = DT_User(0)("Domain_user")
                If txtDomain.Text = "" And txtDomainUser.Text = "" Then
                Else
                    cbxDomain.Enabled = True
                End If
                cbxBranchV2.SetEditValue(DT_User(0)("MultiBranchID").ToString.Replace(",", "; "))
            End If
            cbxMFA.Checked = MultiAuthentication
            cbxMFA.Tag = If(MultiAuthentication, "On", "Off")
            iSeconds.Value = FrmMain.Timer_Session.Interval / 500
            iSeconds.Tag = FrmMain.Timer_Session.Interval / 500
            AgreeDate = DT_User(0)("AgreeDate")

            DT_Permission = DataSource(String.Format("SELECT toUserID, Days, `Start`, include_position FROM endorse_permission WHERE `status` = 'ACTIVE' AND UserID = '{0}';", User_ID))
            If DT_Permission.Rows.Count > 0 Then
                cbxEndorse.Checked = True
                cbxTo.SelectedValue = DT_Permission(0)("toUserID")
                iDays.Value = DT_Permission(0)("Days")
                If DT_Permission(0)("Start").ToString = "" Then
                    cbxNA.Checked = True
                Else
                    cbxNA.Checked = False
                    dtpFrom.Value = DT_Permission(0)("Start")
                End If
                cbxPosition.Checked = DT_Permission(0)("include_position")
            End If

            MultipleBranch = DT_User(0)("MultiBranch")
            Auto_Department = DT_User(0)("Auto_Department")
            Auto_BusinessCenter = DT_User(0)("Auto_BusinessCenter")
            Auto_EmailSend = DT_User(0)("Email_Send")
            SendPendingEmailEvery = DT_User(0)("SendPendingEmailEvery")
            Auto_SMSSend = DT_User(0)("SMS_Send")
            Auto_ROPA = DT_User(0)("ROPA_Notification")
            Auto_Borrower = DT_User(0)("Borrower_Notification")
            Auto_CreditApplication = DT_User(0)("CreditApplication_Notification")
            Auto_CreditInvestigation = DT_User(0)("CreditInvestigation_Notification")
            Auto_AlertNotification = DT_User(0)("AlertNotification")
            Auto_BugReport = DT_User(0)("AutoBugReport")
            AllowPrintScreen = DT_User(0)("AllowPrintScreen")
            KeywordSearchWildcard = DT_User(0)("KeywordSearchWildcard")
            AllowDomainLogin = DT_User(0)("AllowDomainLogin")
            AllowFormHistory = DT_User(0)("AllowFormHistory")
            AllowStandardUI = DT_User(0)("AllowUI")
            NotifyLoggedInToOthers = DT_User(0)("NotifyLoggedInToOthers")

            cbxEmail.Checked = Auto_EmailSend
            iEmail.Value = SendPendingEmailEvery
            cbxSMS.Checked = Auto_SMSSend
            cbxROPA.Checked = Auto_ROPA
            cbxBorrower.Checked = Auto_Borrower
            cbxCreditApplication.Checked = Auto_CreditApplication
            cbxCreditInvestigation.Checked = Auto_CreditInvestigation
            cbxDepartment.Checked = Auto_Department
            cbxBusinessCenter.Checked = Auto_BusinessCenter
            cbxProgressBar.Checked = WithProgressBar
            cbxAlertNotification.Checked = Auto_AlertNotification
            cbxAutoBugReport.Checked = Auto_BugReport
            cbxKeyword.Checked = KeywordSearchWildcard
            cbxDomain.Checked = AllowDomainLogin
            cbxUI.Checked = AllowStandardUI
            cbxNotifyLoggedInToOthers.Checked = NotifyLoggedInToOthers
            If User_Type = "ADMIN" Then
                cbxUI.Enabled = True
            End If

            cbxEmail.Tag = If(Auto_EmailSend, "On", "Off")
            iEmail.Tag = SendPendingEmailEvery
            cbxSMS.Tag = If(Auto_SMSSend, "On", "Off")
            cbxROPA.Tag = If(Auto_ROPA, "On", "Off")
            cbxBorrower.Tag = If(Auto_Borrower, "On", "Off")
            cbxCreditApplication.Tag = If(Auto_CreditApplication, "On", "Off")
            cbxCreditInvestigation.Tag = If(Auto_CreditInvestigation, "On", "Off")
            cbxDepartment.Tag = If(Auto_Department, "On", "Off")
            cbxBusinessCenter.Tag = If(Auto_BusinessCenter, "On", "Off")
            cbxProgressBar.Tag = If(WithProgressBar, "On", "Off")
            cbxAlertNotification.Tag = If(Auto_AlertNotification, "On", "Off")
            cbxAutoBugReport.Tag = If(Auto_BugReport, "On", "Off")
            cbxKeyword.Tag = If(KeywordSearchWildcard, "On", "Off")
            cbxDomain.Tag = If(AllowDomainLogin, "On", "Off")
            cbxUI.Tag = If(AllowStandardUI, "On", "Off")
            cbxNotifyLoggedInToOthers.Tag = If(NotifyLoggedInToOthers, "On", "Off")
        Catch ex As Exception
            TriggerBugReport("User Profile - LoadData", ex.Message.ToString)
        End Try
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX12, LabelX36, LabelX63, lblTo, lblDays, lblEffectivity, lblDash, LabelX14, lblDepartment, LabelX19, LabelX35, LabelX8, LabelX18, LabelX17, lblDateHired, LabelX155, lblPosition, LabelX1, lblSecondaryPos, LabelX16, lblBranchEmp, LabelX15, LabelX30, LabelX32, LabelX5, LabelX6, LabelX2, LabelX34, LabelX3, LabelX7, LabelX4, LabelX11, lblBranch, LabelX40})

            GetTextBoxFontSettings({txtFirstN, txtMiddleN, txtLastN, txtNickname, txtEmployeeID, txtPlus63, txtMobile, txtEmail, txtUserCode, txtUsername, txtOldPW, txtPassword, txtPassword_2, txtDomain, txtDomainUser, txtKeyword, txtPath})

            GetLabelFontSettingsRed({LabelX20, lblCache, lblNote, LabelX25, LabelX10, LabelX26, LabelX27, LabelX28, LabelX29, LabelX31, LabelX33, LabelX24, LabelX23, LabelX13, LabelX22, LabelX9, LabelX21, LabelX37})

            GetCheckBoxFontSettings({cbxMFA, CbxNA_Birth, cbxChangePW, cbxDomain, cbxMultiBranch, cbxEmail, cbxSMS, cbxROPA, cbxBorrower, cbxCreditApplication, cbxCreditInvestigation, cbxDepartment, cbxBusinessCenter, cbxProgressBar, cbxAlertNotification, cbxAutoBugReport, cbxKeyword, cbxUI, cbxNotifyLoggedInToOthers, cbxEndorse, cbxPosition, cbxNA})

            GetComboBoxFontSettings({cbxForm, cbxSuffix, cbxUserType, cbxGroupRole, cbxTo})

            GetCheckComboBoxFontSettings({cbxBranchV2})

            GetIntegerInputFontSettings({iSeconds, iEmail})

            GetDateTimeInputFontSettings({dtpBirth, dtpFrom, dtpTo})

            GetButtonFontSettings({btnAgreement, btnClearCache, btnBack, btnNext, btnSave, btnCancel, btnPrint, btnBrowse, btnView, btnHistory})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("User PRofile - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub KeydownNext_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFirstN.KeyDown, txtMiddleN.KeyDown, txtLastN.KeyDown, cbxSuffix.KeyDown, txtNickname.KeyDown, dtpBirth.KeyDown, txtMobile.KeyDown, txtEmail.KeyDown, txtOldPW.KeyDown, txtPassword.KeyDown, txtPassword_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
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

    Private Sub TxtNickname_Leave(sender As Object, e As EventArgs) Handles txtNickname.Leave
        txtNickname.Text = ReplaceText(txtNickname.Text.Trim)
    End Sub

    Private Sub TxtMobile_Leave(sender As Object, e As EventArgs) Handles txtMobile.Leave
        txtMobile.Text = ReplaceText(txtMobile.Text.Trim)
    End Sub

    Private Sub TxtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        txtEmail.Text = ReplaceText(txtEmail.Text.Trim)
    End Sub

    Private Sub TxtPassword_TextChanged(sender As Object, e As EventArgs) Handles txtPassword.TextChanged
        If txtPassword.Text.Contains("'") Or txtPassword.Text.Contains("\") Then
            MsgBox("Invalid key found, please don't use the single quote (') or slash (\) keys.", MsgBoxStyle.Exclamation, "Info")
            txtPassword.Text = ""
            txtPassword.Focus()
        End If
    End Sub

    Private Sub TxtPassword_2_TextChanged(sender As Object, e As EventArgs) Handles txtPassword_2.TextChanged
        If txtPassword_2.Text.Contains("'") Or txtPassword_2.Text.Contains("\") Then
            MsgBox("Invalid key found, please don't use the single quote (') or slash (\) keys.", MsgBoxStyle.Exclamation, "Info")
            txtPassword_2.Text = ""
            txtPassword_2.Focus()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabSecurity
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSettings
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabHistory
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 3 Then
            SuperTabControl1.SelectedTab = tabSettings
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabSecurity
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabProfile
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Or SuperTabControl1.SelectedTabIndex = 2 Then
            btnBack.Enabled = True
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            btnBack.Enabled = True
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtFirstN.Text = "" Then
            MsgBox("Please fill First name field.", MsgBoxStyle.Information, "Info")
            SuperTabControl1.SelectedTab = tabProfile
            txtFirstN.Focus()
            Exit Sub
        End If
        If txtLastN.Text = "" Then
            MsgBox("Please fill Last name field.", MsgBoxStyle.Information, "Info")
            SuperTabControl1.SelectedTab = tabProfile
            txtLastN.Focus()
            Exit Sub
        End If
        If (txtMobile.Text.Trim.Length > 0 And txtMobile.Text.Trim.Length <> 10) Or (txtMobile.Text.Trim.Length > 0 And IsNumeric(txtMobile.Text.Trim) = False) Then
            SuperTabControl1.SelectedTab = tabProfile
            MsgBox("Please fill a correct mobile number to proceed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxChangePW.Checked Then
            If txtOldPW.Text.Trim = "" Then
                MsgBox("Please fill Old Password", MsgBoxStyle.Information, "Info")
                SuperTabControl1.SelectedTab = tabSecurity
                txtOldPW.Focus()
                Exit Sub
            End If
            If txtPassword.Text.Trim = "" Then
                MsgBox("Please fill New Password", MsgBoxStyle.Information, "Info")
                SuperTabControl1.SelectedTab = tabSecurity
                txtPassword.Focus()
                Exit Sub
            End If
            If txtPassword_2.Text.Trim = "" Then
                MsgBox("Please fill Confirmation Password", MsgBoxStyle.Information, "Info")
                SuperTabControl1.SelectedTab = tabSecurity
                txtPassword_2.Focus()
                Exit Sub
            End If

            If txtPassword.Text.Length < PWLength Then
                MsgBox(String.Format("Password must have at least {0} characters.", PWLength), MsgBoxStyle.Information, "Info")
                SuperTabControl1.SelectedTab = tabSecurity
                Exit Sub
            ElseIf PWCase And (txtPassword.Text Like "*[A-Z]*" = False Or txtPassword.Text Like "*[a-z]*" = False) Then
                MsgBox("Password must have Upper and Lower Case Letters.", MsgBoxStyle.Information, "Info")
                SuperTabControl1.SelectedTab = tabSecurity
                Exit Sub
            ElseIf PWSpecial And ContainsSpecial(txtPassword.Text) = False Then
                MsgBox("Password must have special characters.", MsgBoxStyle.Information, "Info")
                SuperTabControl1.SelectedTab = tabSecurity
                Exit Sub
            ElseIf PWNumeric And ContainsNumeric(txtPassword.Text) = False Then
                MsgBox("Password must have numeric characters.", MsgBoxStyle.Information, "Info")
                SuperTabControl1.SelectedTab = tabSecurity
                Exit Sub
            End If
            If txtPassword.Text.Trim <> txtPassword_2.Text.Trim Then
                MsgBox("Password does not match, please verify password", MsgBoxStyle.Information, "Info")
                SuperTabControl1.SelectedTab = tabSecurity
                Exit Sub
            End If
            If FrmLogin.txtPassword.Text <> txtOldPW.Text Then
                MsgBox("Incorrect old password, please verify password", MsgBoxStyle.Information, "Info")
                SuperTabControl1.SelectedTab = tabSecurity
                Exit Sub
            End If
        End If
        If iSeconds.Value <= 4 Then
            MsgBox("Session cannot be less than 5 seconds.", MsgBoxStyle.Information, "Info")
            SuperTabControl1.SelectedTab = tabSecurity
            Exit Sub
        End If

        If cbxEndorse.Checked And cbxTo.SelectedIndex = -1 Then
            MsgBox("Please select someone to endorse who will have your access.", MsgBoxStyle.Information, "Info")
            SuperTabControl1.SelectedTab = tabSecurity
            cbxTo.DroppedDown = True
            Exit Sub
        End If
        If cbxEndorse.Checked And (Empl_Phone <> "" Or Empl_Email <> "") Then
            Msg = String.Format("Good day," & vbCrLf, Empl_Name)
            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for endorsing your permission to {1}." & vbCrLf, Code, cbxTo.Text)
            Msg &= "Thank you!"
            '******* SEND SMS *********************************************************************************
            If Empl_Phone = "" Then
            Else
                SMS_Notification = True
                SendSMS(Empl_Phone, Msg, True)
            End If
            '******* SEND EMAIL *********************************************************************************
            If Empl_Email = "" Then
            Else
                Email_Notification = True
                SendEmail(Empl_Email, "One Time Authorization Code " & Code, Msg, False, False, False, 0, "", "")
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
        End If

        If cbxForm.SelectedIndex = -1 Or cbxForm.Text = "" Then
            MsgBox("Please select default form.", MsgBoxStyle.Information, "Info")
            SuperTabControl1.SelectedTab = tabSettings
            cbxForm.DroppedDown = True
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE employee_setup SET"
                SQL &= String.Format(" first_name = '{0}', ", txtFirstN.Text)
                SQL &= String.Format(" middle_name = '{0}', ", txtMiddleN.Text)
                SQL &= String.Format(" last_name = '{0}', ", txtLastN.Text)
                SQL &= String.Format(" suffix = '{0}', ", cbxSuffix.Text)
                SQL &= String.Format(" birthdate = '{0}', ", If(CbxNA_Birth.Checked, "", FormatDatePicker(dtpBirth)))
                SQL &= String.Format(" Phone = '{0}', ", txtMobile.Text)
                SQL &= String.Format(" EmailAdd = '{0}' ", txtEmail.Text)
                SQL &= String.Format(" WHERE ID = {0};", Empl_ID)

                SQL &= "UPDATE users SET"
                If cbxChangePW.Checked Then
                    SQL &= String.Format(" password = MD5(SHA1(CONCAT('{0}','{1}'))), ", ReplaceText(txtPassword.Text.Trim), Salt)
                    SQL &= String.Format(" Salt = '{0}', ", Salt)
                    SQL &= " LastPWChange = CURRENT_TIMESTAMP(), "
                    SQL &= " ChangePW = 0, "
                End If
                SQL &= String.Format(" MultiAuthentication = {0}, ", If(cbxMFA.Checked, 1, 0))
                SQL &= String.Format(" `session` = {0}, ", iSeconds.Value)
                SQL &= String.Format(" `form_id` = {0}, ", ValidateComboBox(cbxForm))
                SQL &= String.Format(" Email_Send = {0}, ", If(cbxEmail.Checked, 1, 0))
                SQL &= String.Format(" SendPendingEmailEvery = {0}, ", iEmail.Value)
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
                SQL &= String.Format(" AllowUI = {0}, ", If(cbxUI.Checked, 1, 0))
                SQL &= String.Format(" NotifyLoggedInToOthers = {0}, ", If(cbxNotifyLoggedInToOthers.Checked, 1, 0))
                SQL &= String.Format(" AutoBugReport = {0}, ", If(cbxAutoBugReport.Checked, 1, 0))
                SQL &= String.Format(" AlertNotification = {0} ", If(cbxAlertNotification.Checked, 1, 0))
                SQL &= String.Format(" WHERE ID = {0};", User_ID)

                SQL &= "UPDATE endorse_permission SET"
                SQL &= " `status` = 'DONE' "
                SQL &= String.Format(" WHERE UserID = {0} AND `status` = 'ACTIVE';", User_ID)

                If cbxEndorse.Checked Then
                    Dim drv As DataRowView = DirectCast(cbxTo.SelectedItem, DataRowView)
                    Dim Subject As String = String.Format("Endorse Permission of {0}", Empl_Name)
                    Dim Msg As String = String.Format("Good day {0}," & vbCrLf, cbxTo.Text)
                    Msg &= String.Format("{0} is endorsing his/her permission for you {1} {2}" & vbCrLf, Empl_Name, If(cbxNA.Checked, "on NO DATE LIMIT", "on " & dtpFrom.Text & " to " & dtpTo.Text), If(cbxPosition.Checked, "including the position access", ""))
                    Msg &= "Thank you!"
                    '******* SEND EMAIL *********************************************************************************
                    If drv("email_address") = "" Then
                    Else
                        SendEmail(drv("email_address"), Subject, Msg, False, False, False, 0, "", "")
                    End If

                    SQL &= "INSERT INTO endorse_permission SET"
                    SQL &= String.Format(" UserID = {0}, ", User_ID)
                    SQL &= String.Format(" toUserID = {0}, ", cbxTo.SelectedValue)
                    SQL &= String.Format(" Days = {0}, ", iDays.Value)
                    SQL &= String.Format(" include_position = {0}, ", If(cbxPosition.Checked, 1, 0))
                    SQL &= String.Format(" `Start` = '{0}';", FormatDatePicker(dtpFrom))
                    Logs("User Profile", "Endorse Permission", Empl_Name & " endorse his/her permissions to " & cbxTo.Text & If(cbxNA.Checked, " without date limit ", " from " & dtpFrom.Text & " to " & dtpTo.Text), Changes(), "", "", "")
                End If
                DataObject(SQL)

                If txtPath.Text = "" Then
                Else
                    Dim UID As Integer = DataObject(String.Format("SELECT ID FROM users_avatar WHERE user_code = '{0}';", txtUserCode.Text))
                    If UID Then
                        DataObject(String.Format("INSERT INTO users_avatar SET user_code = '{0}';", txtUserCode.Text))
                    End If
                    SavePhoto(String.Format("UPDATE users_avatar SET picture = ?bin_data WHERE user_code = '{0}'", txtUserCode.Text), txtPath.Text)
                End If

                Nickname = txtNickname.Text
                Empl_Phone = txtMobile.Text
                Empl_Email = txtEmail.Text

                FrmMain.PictureEdit1.Image = pb_Avatar.Image.Clone

                FrmLogin.txtPassword.Text = txtPassword.Text
                MultiAuthentication = cbxMFA.Checked

                FrmMain.Timer_Session.Interval = iSeconds.Value * 1000
                FrmMain.Timer_Session.Start()

                DefaultForm = cbxForm.SelectedValue
                Auto_EmailSend = cbxEmail.Checked
                SendPendingEmailEvery = iEmail.Value
                Auto_SMSSend = cbxSMS.Checked
                Auto_ROPA = cbxROPA.Checked
                Auto_Borrower = cbxBorrower.Checked
                Auto_CreditApplication = cbxCreditApplication.Checked
                Auto_CreditInvestigation = cbxCreditInvestigation.Checked
                Auto_Department = cbxDepartment.Checked
                Auto_BusinessCenter = cbxBusinessCenter.Checked
                WithProgressBar = cbxProgressBar.Checked
                Auto_AlertNotification = cbxAlertNotification.Checked
                Auto_BugReport = cbxAutoBugReport.Checked
                KeywordSearchWildcard = cbxKeyword.Checked
                AllowDomainLogin = cbxDomain.Checked
                AllowStandardUI = cbxUI.Checked
                NotifyLoggedInToOthers = cbxNotifyLoggedInToOthers.Checked
                Logs("User Profile", "Save", String.Format("Update User Profile {0}", Empl_Name), Changes(), "", "", "")
                DT_Employees = DataSource(String.Format("SELECT ID, Employee(ID) AS 'Employee', Phone, EmailAdd, `Position`, IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) AS 'Head', department_ID FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Employee`;", Branch_ID))

                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            'Profile
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
            If txtNickname.Text = txtNickname.Tag Then
            Else
                Change &= String.Format("Change Nick Name from {0} to {1}. ", txtNickname.Tag, txtNickname.Text)
            End If
            If dtpBirth.Text = dtpBirth.Tag Then
            Else
                Change &= String.Format("Change Birthdate from {0} to {1}. ", dtpBirth.Tag, dtpBirth.Text)
            End If
            If txtMobile.Text = txtMobile.Tag Then
            Else
                Change &= String.Format("Change Mobile from {0} to {1}. ", txtMobile.Tag, txtMobile.Text)
            End If
            If txtEmail.Text = txtEmail.Tag Then
            Else
                Change &= String.Format("Change Email from {0} to {1}. ", txtEmail.Tag, txtEmail.Text)
            End If

            'Settings
            If If(cbxEmail.Checked, "On", "Off") = cbxEmail.Tag Then
            Else
                Change &= String.Format("Change Email Sender from {0} to {1}. ", cbxEmail.Tag, If(cbxEmail.Checked, "On", "Off"))
            End If
            If iEmail.Value = iEmail.Tag Then
            Else
                Change &= String.Format("Change Send Pending Email from {0} to {1} seconds. ", iEmail.Tag, iEmail.Value)
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
            If If(cbxAutoBugReport.Checked, "On", "Off") = cbxAutoBugReport.Tag Then
            Else
                Change &= String.Format("Change Auto Bug Report from {0} to {1}. ", cbxAutoBugReport.Tag, If(cbxAutoBugReport.Checked, "On", "Off"))
            End If
            If If(cbxKeyword.Checked, "On", "Off") = cbxKeyword.Tag Then
            Else
                Change &= String.Format("Change Keyword Wildcard Search from {0} to {1}. ", cbxKeyword.Tag, If(cbxKeyword.Checked, "On", "Off"))
            End If
            If If(cbxDomain.Checked, "On", "Off") = cbxDomain.Tag Then
            Else
                Change &= String.Format("Change Allow Domain Login from {0} to {1}. ", cbxDomain.Tag, If(cbxDomain.Checked, "On", "Off"))
            End If
            If If(cbxUI.Checked, "On", "Off") = cbxUI.Tag Then
            Else
                Change &= String.Format("Change Use Standard UI from {0} to {1}. ", cbxUI.Tag, If(cbxUI.Checked, "On", "Off"))
            End If
            If If(cbxNotifyLoggedInToOthers.Checked, "On", "Off") = cbxNotifyLoggedInToOthers.Tag Then
            Else
                Change &= String.Format("Change Notify Logged from {0} to {1}. ", cbxNotifyLoggedInToOthers.Tag, If(cbxNotifyLoggedInToOthers.Checked, "On", "Off"))
            End If
        Catch ex As Exception
            TriggerBugReport("User Profile - Changes", ex.Message.ToString)
        End Try
        Return Change
    End Function

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        'Cursor = Cursors.WaitCursor
        'GridView1.OptionsPrint.UsePrintStyles = False
        'StandardPrinting("EMPLOYEE LIST", GridControl1)
        'Logs("Employee", "Print", "[SENSITIVE] Print Employee List", "", "", "", "")
        'Cursor = Cursors.Default
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
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

    Private Sub CbxNA_Birth_CheckedChanged(sender As Object, e As EventArgs) Handles CbxNA_Birth.CheckedChanged
        If CbxNA_Birth.Checked Then
            dtpBirth.Enabled = False
            dtpBirth.CustomFormat = ""
        Else
            dtpBirth.Enabled = True
            dtpBirth.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub CbxChangePW_CheckedChanged(sender As Object, e As EventArgs) Handles cbxChangePW.CheckedChanged
        If cbxChangePW.Checked Then
            txtOldPW.Enabled = True
            txtPassword.Enabled = True
            txtPassword_2.Enabled = True
        Else
            txtOldPW.Enabled = False
            txtPassword.Enabled = False
            txtPassword_2.Enabled = False
        End If
    End Sub

    Private Sub BtnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If cbxGroupRole.SelectedIndex = -1 Or cbxGroupRole.Text = "" Then
            MsgBox("No group role access given, please ask the Application Support Group.", MsgBoxStyle.Information, "Info")
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
            TriggerBugReport("User Profile - Avatar Click", ex.Message.ToString)
        End Try
    End Sub

    Private Sub TxtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then
            LoadHistory()
        End If
    End Sub

    Private Sub LoadHistory()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    Form,"
        SQL &= "    Button,"
        SQL &= "    Reason,"
        SQL &= "    Changes,"
        SQL &= "    borrower_no AS 'Borrower No',"
        SQL &= "    Borrower,"
        SQL &= "    application_no AS 'Application No',"
        SQL &= "    DATE_FORMAT(DATE(`Timestamp`),'%M %d, %Y') AS 'Date',"
        SQL &= "    TIME_FORMAT(TIME(`Timestamp`),'%r') AS 'Time',"
        SQL &= "    Computer,"
        SQL &= "    ip_address  AS 'IP Address',"
        SQL &= "    Username,"
        SQL &= "    Employee,"
        SQL &= "    Branch"
        SQL &= " FROM transaction_logs"
        SQL &= String.Format("    WHERE username = '{0}' ", txtUsername.Text)
        Dim Words As String() = txtKeyword.Text.Trim.Split(New Char() {" "c})
        Dim Key As String
        For Each Key In Words
            SQL &= String.Format(" AND (`Form` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Button` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Reason` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Changes` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `borrower_no` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Borrower` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `application_no` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Timestamp` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Computer` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `ip_address` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Username` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Employee` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Branch` LIKE '%{0}%')", Key)
        Next
        SQL &= " ORDER BY `timestamp` DESC"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Changes").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Changes").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn5.Width = 339 - 17
        Else
            GridColumn5.Width = 339
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim History As New FrmPermissionHistory
        With History
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub CbxEndorse_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEndorse.CheckedChanged
        If cbxEndorse.Checked Then
            lblTo.Enabled = True
            cbxTo.Enabled = True
            lblDays.Enabled = True
            cbxNA.Enabled = True
            If cbxNA.Checked Then
            Else
                dtpFrom.Enabled = True
                dtpTo.Enabled = True
                iDays.Enabled = True
            End If
            lblEffectivity.Enabled = True
            lblDash.Enabled = True
            cbxPosition.Enabled = True
        Else
            lblTo.Enabled = False
            cbxTo.Enabled = False
            lblDays.Enabled = False
            iDays.Enabled = False
            cbxNA.Enabled = False
            lblEffectivity.Enabled = False
            dtpFrom.Enabled = False
            lblDash.Enabled = False
            dtpTo.Enabled = False
            cbxPosition.Enabled = False
        End If
    End Sub

    Private Sub CbxNA_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNA.CheckedChanged
        If cbxNA.Checked Then
            iDays.MinValue = 0
            iDays.Value = 0
            iDays.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpFrom.Enabled = False
            dtpTo.CustomFormat = ""
            dtpTo.Enabled = False
        Else
            iDays.MinValue = 1
            iDays.Value = 1
            iDays.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpFrom.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
            dtpTo.Enabled = True
        End If
    End Sub

    Private Sub ScanCache(Clear As Boolean)
        TotalFile = 0
        TotalSize = 0
        If DT_File.Rows.Count > 0 Then
            For x As Integer = 0 To DT_File.Rows.Count - 1
                If DT_File(x)("Attachment_1") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_1")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_1")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_1"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If DT_File(x)("Attachment_2") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_2")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_2")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_2"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If DT_File(x)("Attachment_3") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_3")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_3")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_3"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If DT_File(x)("Attachment_4") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_4")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_4")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_4"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If DT_File(x)("Attachment_5") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_5")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_5")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_5"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If DT_File(x)("Attachment_6") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_6")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_6")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_6"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If DT_File(x)("Attachment_7") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_7")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_7")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_7"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If DT_File(x)("Attachment_8") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_8")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_8")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_8"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If DT_File(x)("Attachment_9") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_9")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_9")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_9"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
                If DT_File(x)("Attachment_10") = "" Then
                Else
                    If FileExists(DT_File(x)("Attachment_10")) Then
                        Try
                            TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_10")).Length
                            TotalFile += 1
                            If Clear Then
                                IO.File.Delete(DT_File(x)("Attachment_10"))
                            End If
                        Catch ex As Exception
                        End Try
                    End If
                End If
            Next
            If TotalSize > 0 Then
                btnClearCache.Enabled = True
            Else
                btnClearCache.Enabled = False
            End If
            lblCache.Text = String.Format("Total file of {0} and total size of {1} bytes", FormatNumber(TotalFile, 0), FormatNumber(TotalSize, 0))
        End If
    End Sub

    Private Sub BtnClearCache_Click(sender As Object, e As EventArgs) Handles btnClearCache.Click
        If MsgBoxYes("Are you sure you want to clear cache?") = MsgBoxResult.Yes Then
            ScanCache(True)
            MsgBox(String.Format("Successfully Cleared Cache with total file of {0} and total size of {1} bytes", FormatNumber(TotalFile, 0), FormatNumber(TotalSize, 0)), MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnAgreement_Click(sender As Object, e As EventArgs) Handles btnAgreement.Click
        Dim Agreement As New FrmUserAgreement
        With Agreement
            .AgreeDate = AgreeDate
            If .ShowDialog = DialogResult.OK Then
                WindowState = FormWindowState.Normal
                ShowInTaskbar = True
                DataObject(String.Format("UPDATE users SET `AgreeDate` = DATE(NOW()) WHERE ID = {0};", User_ID))
                AgreeDate = Format(Date.Now, "yyyy-MM-dd")
                Logs("User Profile", "Agreement", "Agree to the terms and conditions of the privacy policy", "", "", "", "")
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxEmail_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEmail.CheckedChanged
        If cbxEmail.Checked Then
            iEmail.Enabled = True
        Else
            iEmail.Enabled = False
        End If
    End Sub
End Class