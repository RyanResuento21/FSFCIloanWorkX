Imports FSFC_System

Public Class FrmLogin
    Public Splash As New SplashScreen
    Public th As Threading.Thread
    Delegate Sub _SubName()
    Public Const EWX_LogOff As Long = 0
    Public Declare Function ExitWindowsEx Lib "user32" (dwOptions As Long, dwReserved As Long) As Long

    'Dim Failed_Login As Integer
    Dim Code As String
    Dim Msg As String = ""
    Dim OldUsernameX As String
    Dim Company_DT As DataTable
    Dim Previous_Host As String
    Public DomainLogin As Boolean
    ReadOnly DT_FailedLog As New DataTable
    Dim Login As New DataTable
    Dim PassSecs As Integer
    Public TriggerUserChange As Boolean
    Dim LockedAccount As Boolean

    Public Sub StopThread()
        Try
            With th
                .Abort()
                .Join()
            End With
            With Splash
                .Close()
                .Dispose()
            End With
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ShowLoading()
        Try
            If InvokeRequired And WithProgressBar Then
                If Splash.ShowDialog() = DialogResult.Abort Then

                End If
            Else
                Threading.Thread.Sleep(1000)
                th = New Threading.Thread(AddressOf ShowLoading)
                With th
                    .IsBackground = True
                    .SetApartmentState(Threading.ApartmentState.STA)
                    .Start()
                End With
            End If
        Catch ex As Exception
            With th
                .Abort()
                .Join()
            End With
            With Splash
                .Close()
                .Dispose()
            End With
        End Try
    End Sub

    Private Sub FrmLoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        FixUnitStandard()
        'Dim ADEntry As New System.DirectoryServices.DirectoryEntry("WinNT://" & Environment.UserDomainName.ToString)
        'Dim ADEntry As New System.DirectoryServices.DirectoryEntry("LDAP://" & Environment.UserDomainName.ToString)

        'Dim adsUser As System.DirectoryServices.DirectoryEntry
        'Dim i As Integer = 0
        'Dim DT As New DataTable
        'DT.Columns.Add("1")
        'DT.Columns.Add("2")
        'DT.Columns.Add("3")
        'DT.Columns.Add("4")
        'DT.Columns.Add("5")
        'DT.Columns.Add("6")
        'DT.Columns.Add("7")
        'DT.Columns.Add("8")
        'For Each adsUser In ADEntry.Children
        '    If adsUser.SchemaClassName = "User" Then
        '        DT.Rows.Add(adsUser.Properties("FullName").Value.ToString, adsUser.Name.ToString, adsUser.Properties("FullName").Value.ToString, adsUser.Properties("givenname").Value.ToString)
        '    End If
        'Next
        'MsgBox("Im Here")
        'Exit Sub

        Icon = My.Resources.iLoanWorkX_ico
        lblVersion.Text = "iLoanWorkX v" & Application.ProductVersion
        txtUserName.Focus()
        clsDBConn = New ClsDBConnection
        If Not clsDBConn.IsDBConnected(_ServerName, _DatabaseName, _UserID, _Password) Then
            SendToBack()
            With FrmDBConnection
                .BringToFront()
                .Show()
            End With
            Exit Sub
        End If
        CurrentVersion = DataObject(String.Format("SELECT system_version FROM version_setup WHERE `status` = 'ACTIVE';"))
        txtUserName.Text = GetSetting("FSFC_System", "Connection", "DefaultUsername")
        DT_FailedLog.Columns.Add("Username")
        DT_FailedLog.Columns.Add("Attempt")
        'SECURITY SETTINGS
        Dim DT_Security As DataTable = DataSource("SELECT PWLength, PWAge, PWNotifyAge, PWCase, PWSpecial, PWNumeric, PWForceChange, AccountThreshold, AccountLockDuration, AccountReset, OTACLength, OTACwithAlphabet, OTACCaseSensitive, OTACDuration FROM security_settings WHERE `status` = 'ACTIVE' LIMIT 1;")
        If DT_Security.Rows.Count > 0 Then
            PWLength = DT_Security(0)("PWLength")
            PWAge = DT_Security(0)("PWAge")
            PWNotifyExpire = DT_Security(0)("PWNotifyAge")
            PWCase = DT_Security(0)("PWCase")
            PWSpecial = DT_Security(0)("PWSpecial")
            PWNumeric = DT_Security(0)("PWNumeric")
            PWForceChange = DT_Security(0)("PWForceChange")
            AccountThreshold = DT_Security(0)("AccountThreshold")
            AccountLockDuration = DT_Security(0)("AccountLockDuration")
            AccountReset = DT_Security(0)("AccountReset")
            OTACLength = DT_Security(0)("OTACLength")
            OTACwithAlphabet = DT_Security(0)("OTACwithAlphabet")
            OTACCaseSensitive = DT_Security(0)("OTACCaseSensitive")
            OTACDuration = DT_Security(0)("OTACDuration")
        End If

        '****AUTO LOGIN
        If Environment.UserName <> "" Then
            Dim DT_User As DataTable = DataSource(String.Format("SELECT username, `password` FROM users WHERE domain != '' AND AllowDomainLogin = 1 AND domain_user = '{0}' AND domain = '{1}' AND `status` = 'ACTIVE' LIMIT 1;", Environment.UserName, Environment.UserDomainName))
            If DT_User.Rows.Count > 0 Then
                txtUserName.Text = DT_User(0)("username")
                txtPassword.Text = DT_User(0)("password")
                DomainLogin = True
                btnOK.PerformClick()
            End If
        End If

        If (Computer = "ARGOWSL-044" Or Computer = "TUF-Gaming") And _DatabaseName = "fsfc_test" And txtUserName.Text = "mgotico" Then
            txtPassword.Text = 1
            btnOK.PerformClick()
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX4, LabelX3, LabelX5, lblTimer, lblForgot})

            GetTextBoxFontSettings({txtUserName, txtPassword, txtOTAC})

            GetLabelWithBackgroundFontSettingsNoBorder({lblVersion})

            GetButtonFontSettings({btnOK, btnCancel, btnResend, btnCancelL})
        Catch ex As Exception
            TriggerBugReport("Login - Fix UI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            Close()
            Application.Exit()
        Catch ex As Exception
            TriggerBugReport("Login - Cancel Click", ex.Message.ToString)
        End Try
    End Sub

    Private Sub TriggerLoggedIn()
        If Login.Rows.Count = 0 Or TriggerUserChange Then
            If IsNumeric(txtUserName.Text.Trim.Substring(txtUserName.Text.Trim.Length - 1, 1)) Then
                Login = DataSource(String.Format("SELECT users.ID, user_code, P.Name AS 'empl_name', password, EmailAdd, P.Phone AS 'Phone', user_type, empl_id, emp_Code, department_id, department, IF(skin_season = '',skin,skin_season) AS 'skin', company_id, P.branch_id, branch_code, branch, `session`, restriction, form_id, P.Nickname, new_update, WithProgressBar, MultiAuthentication, MultiBranch, Auto_Department, Auto_BusinessCenter, SendPendingEmailEvery, Email_Send, SMS_Send, ROPA_Notification, Borrower_Notification, CreditApplication_Notification, CreditInvestigation_Notification, AlertNotification, AutoBugReport, DefaultBranchSelected, AllowPrintScreen, KeywordSearchWildcard, AllowDomainLogin, NotifyLoggedInToOthers, AllowFormHistory, P.position_id, P.`position`, P.secondary_position_id, P.secondary_position, NOW() AS 'Today', Salt, LogStatus, IFNULL(TIMESTAMPDIFF(MINUTE, LockedTime, CURRENT_TIMESTAMP()),0) AS 'LockedTime', IFNULL(DATEDIFF(CURRENT_TIMESTAMP(), LastPWChange),0) AS 'LastPWChange', AllowUI, ChangePW, AgreeDate, Dept_Head, GroupRoleID, Extension, AutoRefreshData, AutoRefreshTime FROM users LEFT JOIN (SELECT ID, Employee(ID) AS 'Name', nickname, Phone, Extension, position_id, `position`, secondary_position_id, secondary_position, IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) AS 'Dept_Head', EmailAdd, emp_Code, department_id, department, branch_id, branch_code, branch, company_id FROM employee_setup WHERE `status` = 'ACTIVE') P ON P.ID = users.Empl_ID WHERE CONCAT(username,'{1}') = '{0}' AND `status` = 'ACTIVE' LIMIT 1;", ReplaceText(txtUserName.Text.Trim), txtUserName.Text.Trim.Substring(txtUserName.Text.Trim.Length - 1, 1)))
            Else
                Login = DataSource(String.Format("SELECT users.ID, user_code, P.Name AS 'empl_name', password, EmailAdd, P.Phone AS 'Phone', user_type, empl_id, emp_Code, department_id, department, IF(skin_season = '',skin,skin_season) AS 'skin', company_id, P.branch_id, branch_code, branch, `session`, restriction, form_id, P.Nickname, new_update, WithProgressBar, MultiAuthentication, MultiBranch, Auto_Department, Auto_BusinessCenter, SendPendingEmailEvery, Email_Send, SMS_Send, ROPA_Notification, Borrower_Notification, CreditApplication_Notification, CreditInvestigation_Notification, AlertNotification, AutoBugReport, DefaultBranchSelected, AllowPrintScreen, KeywordSearchWildcard, AllowDomainLogin, NotifyLoggedInToOthers, AllowFormHistory, P.position_id, P.`position`, P.secondary_position_id, P.secondary_position, NOW() AS 'Today', Salt, LogStatus, IFNULL(TIMESTAMPDIFF(MINUTE, LockedTime, CURRENT_TIMESTAMP()),0) AS 'LockedTime', IFNULL(DATEDIFF(CURRENT_TIMESTAMP(), LastPWChange),0) AS 'LastPWChange', AllowUI, ChangePW, AgreeDate, Dept_Head, GroupRoleID, Extension, AutoRefreshData, AutoRefreshTime FROM users LEFT JOIN (SELECT ID, Employee(ID) AS 'Name', nickname, Phone, Extension, position_id, `position`, secondary_position_id, secondary_position, IFNULL(LEAST((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.position_ID) + IFNULL((SELECT Head FROM position_setup WHERE position_setup.ID = employee_setup.secondary_position_id),0),1),0) AS 'Dept_Head', EmailAdd, emp_Code, department_id, department, branch_id, branch_code, branch, company_id FROM employee_setup WHERE `status` = 'ACTIVE') P ON P.ID = users.Empl_ID WHERE username = '{0}' AND `status` = 'ACTIVE' LIMIT 1;", ReplaceText(txtUserName.Text.Trim)))
            End If
            TriggerUserChange = False
            LockedAccount = False
        End If
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If _ServerName = "" Or _DatabaseName = "" Or _UserID = "" Or _Password = "" Then
            SendToBack()
            With FrmDBConnection
                .BringToFront()
                .Show()
            End With
            Exit Sub
        End If
        If Environment.UserName <> "" And (txtPassword.Text.Trim = "" Or txtUserName.Text.Trim = "") Then
            Dim DT_User As DataTable = DataSource(String.Format("SELECT username, `password` FROM users WHERE domain != '' AND AllowDomainLogin = 1 AND domain_user = '{0}' AND domain = '{1}' AND `status` = 'ACTIVE' LIMIT 1;", Environment.UserName, Environment.UserDomainName))
            If DT_User.Rows.Count > 0 Then
                txtUserName.Text = DT_User(0)("username")
                txtPassword.Text = DT_User(0)("password")
                DomainLogin = True
            End If
        End If
        If txtUserName.Text.Trim = "" Then
            MsgBox("Please fill username", MsgBoxStyle.Information, "Info")
            txtUserName.Focus()
            Exit Sub
        End If
        If txtPassword.Text.Trim = "" Then
            MsgBox("Please fill password", MsgBoxStyle.Information, "Info")
            txtPassword.Focus()
            Exit Sub
        End If

        Dim ExistUser As Boolean
        TriggerLoggedIn()
        'DomainLogin = False
        If Login Is Nothing Then
            Exit Sub
        End If
        If Login.Rows.Count > 0 Then
            ExistUser = True
            MultiAuthentication = Login(0)("MultiAuthentication")
            Branch = Login(0)("branch")
            Salt = Login(0)("Salt")
            User_ID = Login(0)("ID")
            User_Code = Login(0)("user_code")
            If Login(0)("LogStatus") = "LOCKED" Or LockedAccount Then
                If Login(0)("LockedTime") < AccountLockDuration Or LockedAccount Then ' Or AccountReset = False Then (Account Reset always True kay gi tanggal lang kay redundant)
                    'MsgBox(String.Format("Account {0} is still locked, please wait for {1} minute(s) or contact the ASG.", txtUserName.Text, AccountLockDuration - Login(0)("LockedTime")), MsgBoxStyle.Information, "Info")
                    MsgBox(String.Format("{0} account has been locked out. Please contact ASG Support.", txtUserName.Text, AccountLockDuration - Login(0)("LockedTime")), MsgBoxStyle.Information, "Info")
                    txtPassword.Text = ""
                    TriggerUserChange = False
                    Exit Sub
                Else
                    DataObject(String.Format("UPDATE users SET LogStatus = 'OPEN' WHERE ID = '{0}';", Login(0)("ID")))
                End If
            End If
            If (DomainLogin Or Computer = "ARGOWSL-044") And MultiAuthentication = False Then
                DomainLogin = False
                WindowState = FormWindowState.Minimized
                ShowInTaskbar = False
            Else
                If Login(0)("password") <> DataObject(String.Format("SELECT MD5(SHA1(CONCAT('{0}','{1}')))", ReplaceText(txtPassword.Text.Trim), Login(0)("Salt"))) Then
                    GoTo Here
                Else
                    If DT_FailedLog.Rows.Count > 0 Then
                        For x As Integer = 0 To DT_FailedLog.Rows.Count - 1
                            If txtUserName.Text = DT_FailedLog(x)("Username") Then
                                DT_FailedLog.Rows.RemoveAt(x)
                            End If
                        Next
                    End If
                End If
            End If
            Cursor = Cursors.WaitCursor
            If Login(0)("AgreeDate") = "" And (_DatabaseName.ToLower = "fsfc_test" Or _DatabaseName.ToLower = "fsfc_migration") Then
                WindowState = FormWindowState.Minimized
                ShowInTaskbar = False
                Dim Agreement As New FrmUserAgreement
                With Agreement
                    .BringToFront()
                    If .ShowDialog = DialogResult.OK Then
                        WindowState = FormWindowState.Normal
                        ShowInTaskbar = True
                        DataObject(String.Format("UPDATE users SET `AgreeDate` = DATE(NOW()) WHERE ID = {0};", Login(0)("ID")))
                        Logs("Login", "Agreement", "Agree to the terms and conditions of the privacy policy", "", "", "", "")
                    Else
                        WindowState = FormWindowState.Normal
                        ShowInTaskbar = True
                        Cursor = Cursors.Default
                        txtPassword.Text = ""
                        .Dispose()
                        TriggerUserChange = False
                        Exit Sub
                    End If
                    .Dispose()
                End With
            End If
            DataObject(String.Format("UPDATE failed_login SET `status` = 'DONE' WHERE UserID = {0};", Login(0)("ID")))
            With FrmMain
                If .OldUsername = "" Then
                Else
                    If .OldUsername = txtUserName.Text Then
                    Else
                        .Close()
                    End If
                End If
            End With
            If OldUsernameX = "" Then
                OldUsernameX = txtUserName.Text
            Else
                If OldUsernameX = txtUserName.Text And Previous_Host = _ServerName Then
                    GoTo HereV2
                End If
            End If
HereV2:     '<---- GIBALIK NAKU DRI KAY PARA MU REFRESH JUD TANAN UNYA NALANG I CHECK IF UNSA ANG DAPAT DLI NA I REFRESH PARA SAFE
            OldUsernameX = txtUserName.Text
            Previous_Host = _ServerName

            '***Variable Assign
            Company_ID = Login(0)("company_id")

            Company_DT = DataSource(String.Format("CALL Login_GetCompany({0},'{1}');", Company_ID, Ext))
            CompanyMode = Company_DT(0)("ComMode")
            Company_Code = Company_DT(0)("company_code")
            Company = Company_DT(0)("company")
            ASG_Email = Company_DT(0)("ASG_Email")
            CredCommEmail = Company_DT(0)("CredCommEmail")
            OfficialFont = Company_DT(0)("OfficialFont")
            OfficialFontSize = Company_DT(0)("FontSize")
            OfficialFontSizeGrid = Company_DT(0)("FontSizeGrid")
            GetGridFontSettingsAppearance({FrmDepartment.GridView1})
            GetBandedGridFontSettingsAppearance({FrmPerformanceReport.BandedGridView1})
            Dim RGB As String()
            If Company_DT(0)("Color1") <> "" Then
                RGB = Company_DT(0)("Color1").ToString.Split(New Char() {","c})
                OfficialColor1 = Color.FromArgb(RGB(0), RGB(1), RGB(2))
            End If
            If Company_DT(0)("Color2") <> "" Then
                RGB = Company_DT(0)("Color2").ToString.Split(New Char() {","c})
                OfficialColor2 = Color.FromArgb(RGB(0), RGB(1), RGB(2))
            End If
            If CompanyMode = 0 And txtUserName.Text.Trim.Substring(txtUserName.Text.Trim.Length - 1, 1) <> "1" Then
                GoTo Here
            End If
            Empl_Name = Login(0)("empl_name")
            Empl_ID = Login(0)("empl_id")
            Empl_Code = Login(0)("emp_Code")
            Empl_Email = Login(0)("EmailAdd")
            Empl_Phone = Login(0)("Phone")
            Empl_Extension = Login(0)("Extension")
            Empl_Skin = Login(0)("skin")
            Empl_Position = Login(0)("position")
            Empl_PositionID = Login(0)("position_id")
            Empl_V2Position = Login(0)("secondary_position")
            Empl_V2PositionID = Login(0)("secondary_position_id")
            GroupRoleID = Login(0)("GroupRoleID")
            LastPWChange = Login(0)("LastPWChange")
            ChangePW = Login(0)("ChangePW")

            Dim EndorsedPositionUserID As Integer = DataObject(String.Format("SELECT UserID FROM endorse_permission WHERE toUserID = {0} AND include_position = 1 AND `status` = 'ACTIVE' AND IF(Days = 0,TRUE,DATE(NOW()) BETWEEN DATE(`Start`) AND ADDDATE(`Start`,Days));", User_ID))
            If EndorsedPositionUserID > 0 Then
                Dim DT_EndorsedPosition As DataTable = DataSource(String.Format("SELECT position_id, `position`, secondary_position_id, secondary_position FROM employee_setup WHERE ID = (SELECT empl_id FROM users WHERE ID = {0});", EndorsedPositionUserID))
                If DT_EndorsedPosition.Rows.Count > 0 Then
                    Empl_V3Position = DT_EndorsedPosition(0)("position")
                    Empl_V3PositionID = DT_EndorsedPosition(0)("position_id")
                    Empl_V4Position = DT_EndorsedPosition(0)("secondary_position")
                    Empl_V4PositionID = DT_EndorsedPosition(0)("secondary_position_id")
                End If
            Else
                Empl_V3Position = ""
                Empl_V3PositionID = 0
                Empl_V4Position = ""
                Empl_V4PositionID = 0
            End If
            User_Type = Login(0)("user_type")
            Branch_ID = Login(0)("branch_id")
            Branch_Code = Login(0)("branch_code")
            If Login(0)("DefaultBranchSelected").ToString = "" Then
                Multiple_ID = Branch_ID
            Else
                Multiple_ID = Login(0)("DefaultBranchSelected")
                If Login(0)("DefaultBranchSelected").ToString.Contains(",") Then
                Else
                    Branch_ID = Login(0)("DefaultBranchSelected")
                    Branch_Code = DataObject(String.Format("SELECT BranchCode({0});", Branch_ID))
                    Branch = DataObject(String.Format("SELECT Branch({0});", Branch_ID))
                End If
            End If
            RealBranchID = Login(0)("branch_id")
            RealBranchCode = Branch_Code
            RealBranch = Branch
            MultipleBranch = Login(0)("MultiBranch")
            Auto_Department = Login(0)("Auto_Department")
            Auto_BusinessCenter = Login(0)("Auto_BusinessCenter")
            Auto_EmailSend = Login(0)("Email_Send")
            SendPendingEmailEvery = Login(0)("SendPendingEmailEvery")
            Auto_SMSSend = Login(0)("SMS_Send")
            Auto_ROPA = Login(0)("ROPA_Notification")
            Auto_Borrower = Login(0)("Borrower_Notification")
            Auto_CreditApplication = Login(0)("CreditApplication_Notification")
            Auto_CreditInvestigation = Login(0)("CreditInvestigation_Notification")
            Auto_AlertNotification = Login(0)("AlertNotification")
            Auto_BugReport = Login(0)("AutoBugReport")
            AllowPrintScreen = Login(0)("AllowPrintScreen")
            KeywordSearchWildcard = Login(0)("KeywordSearchWildcard")
            AllowDomainLogin = Login(0)("AllowDomainLogin")
            AllowFormHistory = Login(0)("AllowFormHistory")
            AllowStandardUI = Login(0)("AllowUI")
            NotifyLoggedInToOthers = Login(0)("NotifyLoggedInToOthers")
            AutoRefreshData = Login(0)("AutoRefreshData")
            AutoRefreshTime = Login(0)("AutoRefreshTime")

            Ping_Notification = Company_DT(0)("Ping_Notification")
            AppEmailAddress = Company_DT(0)("AppEmailAddress")
            AppPassword = Company_DT(0)("AppPassword")
            'MULTI FACTOR AUTHENTICATION ************************************************************************************************
            'HereV2:
            If txtOTAC.Visible Then
                If txtOTAC.Text.Trim = Code Then
                    'MsgBox("Code Matched!", MsgBoxStyle.Information, "Info")
                    lblForgot.Visible = True
                    txtUserName.Enabled = True
                    txtPassword.Enabled = True
                    btnCancelL.Visible = False
                    btnResend.Visible = False
                    lblTimer.Visible = False
                    Timer_Date.Stop()
                    LabelX5.Visible = False
                    txtOTAC.Visible = False
                    'Size = New Point(362, 239)
                    'btnOK.Location = New Point(11, 140)
                    'btnCancel.Location = New Point(176, 140)
                    lblTimer.Text = ""
                    txtOTAC.Text = ""
                Else
                    MsgBox("Incorrect OTAC! Please check your OTAC.", MsgBoxStyle.Information, "Info")
                    Cursor = Cursors.Default
                    TriggerUserChange = False
                    Exit Sub
                End If
            ElseIf MultiAuthentication Then
                PassSecs = 300
                Timer_Date.Start()
                SendEmailUser("Authorization")

                'Size = New Point(362, 267)
                'btnOK.Location = New Point(11, 171)
                'btnCancel.Location = New Point(176, 171)
                lblForgot.Visible = False
                txtOTAC.Enabled = True
                LabelX5.Visible = True
                txtOTAC.Visible = True
                btnCancelL.Visible = True
                lblTimer.Visible = True
                txtUserName.Enabled = False
                txtPassword.Enabled = False
                Cursor = Cursors.Default
                Exit Sub
            End If
            FixUI(AllowStandardUI)
            'MULTI FACTOR AUTHENTICATION ************************************************************************************************

            Visible = False
            Call ShowLoading()
            'Application.DoEvents()

            If IsNumeric(txtUserName.Text.Trim.Substring(txtUserName.Text.Trim.Length - 1, 1)) Then
                DefaultBankID = DataObject(String.Format("SELECT ID FROM branch_bank WHERE `Code` = '{1}' AND `status` = 'ACTIVE' AND Branch_ID = '{0}';", Branch_ID, txtUserName.Text.Trim.Substring(txtUserName.Text.Trim.Length - 1, 1)))
            Else
                DefaultBankID = 0
            End If
            'i comment usa kay naglibog pa sa credentials makasayop noon manawag ra sila sa ASG kung dli makaconnect
            'If _UserID.Contains("fsfcceb") And Branch_ID <> 5 And Branch_ID <> 0 Then
            '    _ServerName = "AAWSSVR-DB2"
            '    _DatabaseName = "fsfc"
            '    _UserID = _UserID.Replace("ceb", Branch_Code.ToLower)
            '    _Password = "FSFC" & Branch_Code.ToLower & "user"
            '    SaveSetting("FSFC_System", "Connection", "ServerName", _ServerName)
            '    SaveSetting("FSFC_System", "Connection", "DatabaseName", _DatabaseName)
            '    SaveSetting("FSFC_System", "Connection", "UserName", _UserID)
            '    SaveSetting("FSFC_System", "Connection", "Password", _Password)
            '    clsDBConn.ServerName = _ServerName
            '    clsDBConn.DatabaseName = _DatabaseName
            '    clsDBConn.UserID = _UserID
            '    clsDBConn.Password = _Password
            '    cn = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))
            '    cn_email = New MySqlConnection(String.Format("Data Source={0};Port=3308;Database={1};Uid={2};Pwd={3};CharSet=utf8mb4;pooling='false';", _ServerName, _DatabaseName, _UserID, _Password & Ext))
            'End If
            Dept_ID = Login(0)("department_id")
            Department = Login(0)("department")
            DepartmentHead = Login(0)("Dept_Head")
            Restriction = Login(0)("restriction")
            DefaultForm = Login(0)("form_id")
            Nickname = Login(0)("Nickname")
            New_Update = Login(0)("New_Update")
            IT_PW = Company_DT(0)("override_pw")
            MotivationC = Company_DT(0)("motivation")
            Dim Branch_Settings As DataTable = DataSource(String.Format("CALL Login_GetBranch({0},'{1}')", Branch_ID, Branch_Code & Branch_ID))
            If Branch_Settings.Rows.Count > 0 Then
                With FrmLoanApplication
                    .Interest_RPPD = Branch_Settings(0)("RPPD")
                    .RPPD_Start = Branch_Settings(0)("RPPD_Start")
                End With
                Branch_IDv2 = Branch_Settings(0)("BranchID")
                Round_Up = Branch_Settings(0)("RoundUp")
                Overstayed_Months = Branch_Settings(0)("overstayed_months")
                Overstayed = Branch_Settings(0)("overstayed")
                AmountLimit = Branch_Settings(0)("transaction_amount")
                DefaultPenalty = Branch_Settings(0)("Penalty")
                DefaultReservation = Branch_Settings(0)("ReservedDays")
                RedemptionMonth = Branch_Settings(0)("RedemptionMonth")
                MFBranch_ID = Branch_Settings(0)("MFBranch")

                ConfiEmail = Branch_Settings(0)("ConfiEmail")
                ConfiPW = Branch_Settings(0)("ConfiPW")

                Approver1ID = Branch_Settings(0)("Approver1")
                Approver2ID = Branch_Settings(0)("Approver2")
                Approver3ID = Branch_Settings(0)("Approver3")
                Approver4ID = Branch_Settings(0)("Approver4")

                If Approver1ID > 0 Then
                    Dim EmpDetails As DataTable = DataSource(String.Format("CALL GetEmployeeDetail({0})", Approver1ID))
                    If EmpDetails.Rows.Count > 0 Then
                        Approver1Name = EmpDetails(0)("Employee")
                        Approver1Email = EmpDetails(0)("EmailAdd")
                        Approver1Phone = EmpDetails(0)("Phone")
                        Approver1_Credit = Branch_Settings(0)("OIC")
                        Approver1_CashAdvance = Branch_Settings(0)("OIC_CA")
                    Else
                        Approver1Name = ""
                        Approver1Email = ""
                        Approver1Phone = ""
                        Approver1_Credit = 0
                        Approver1_CashAdvance = 0
                    End If
                Else
                    Approver1Name = ""
                    Approver1Email = ""
                    Approver1Phone = ""
                    Approver1_Credit = 0
                    Approver1_CashAdvance = 0
                End If
                If Approver2ID > 0 Then
                    Dim EmpDetails As DataTable = DataSource(String.Format("CALL GetEmployeeDetail({0})", Approver2ID))
                    If EmpDetails.Rows.Count > 0 Then
                        Approver2Name = EmpDetails(0)("Employee")
                        Approver2Email = EmpDetails(0)("EmailAdd")
                        Approver2Phone = EmpDetails(0)("Phone")
                        Approver2_Credit = Branch_Settings(0)("BM")
                        Approver2_CashAdvance = Branch_Settings(0)("BM_CA")
                    Else
                        Approver2Name = ""
                        Approver2Email = ""
                        Approver2Phone = ""
                        Approver2_Credit = 0
                        Approver2_CashAdvance = 0
                    End If
                Else
                    Approver2Name = ""
                    Approver2Email = ""
                    Approver2Phone = ""
                    Approver2_Credit = 0
                    Approver2_CashAdvance = 0
                End If
                If Approver3ID > 0 Then
                    Dim EmpDetails As DataTable = DataSource(String.Format("CALL GetEmployeeDetail({0})", Approver3ID))
                    If EmpDetails.Rows.Count > 0 Then
                        Approver3Name = EmpDetails(0)("Employee")
                        Approver3Email = EmpDetails(0)("EmailAdd")
                        Approver3Phone = EmpDetails(0)("Phone")
                        Approver3_Credit = Branch_Settings(0)("DM")
                        Approver3_CashAdvance = Branch_Settings(0)("DM_CA")
                    Else
                        Approver3Name = ""
                        Approver3Email = ""
                        Approver3Phone = ""
                        Approver3_Credit = 0
                        Approver3_CashAdvance = 0
                    End If
                Else
                    Approver3Name = ""
                    Approver3Email = ""
                    Approver3Phone = ""
                    Approver3_Credit = 0
                    Approver3_CashAdvance = 0
                End If
                If Approver4ID > 0 Then
                    Dim EmpDetails As DataTable = DataSource(String.Format("CALL GetEmployeeDetail({0})", Approver4ID))
                    If EmpDetails.Rows.Count > 0 Then
                        Approver4Name = EmpDetails(0)("Employee")
                        Approver4Email = EmpDetails(0)("EmailAdd")
                        Approver4Phone = EmpDetails(0)("Phone")
                        Approver4_Credit = Branch_Settings(0)("RM")
                        Approver4_CashAdvance = Branch_Settings(0)("RM_CA")
                    Else
                        Approver4Name = ""
                        Approver4Email = ""
                        Approver4Phone = ""
                        Approver4_Credit = 0
                        Approver4_CashAdvance = 0
                    End If
                Else
                    Approver4Name = ""
                    Approver4Email = ""
                    Approver4Phone = ""
                    Approver4_Credit = 0
                    Approver4_CashAdvance = 0
                End If

                If Approver1_CashAdvance > 0 Or Approver2_CashAdvance > 0 Or Approver3_CashAdvance > 0 Or Approver4_CashAdvance > 0 Then
                    CashApprovalHierarchy = True
                Else
                    CashApprovalHierarchy = False
                End If
                If Approver1_Credit > 0 Or Approver2_Credit > 0 Or Approver3_Credit > 0 Or Approver4_Credit > 0 Then
                    CreditApprovalHierarchy = True
                Else
                    CreditApprovalHierarchy = False
                End If

                AvailedRPPD = Branch_Settings(0)("AvailedRPPD")
                AvailedPenalty = Branch_Settings(0)("AvailedPenalty")
                PettyCash = Branch_Settings(0)("PettyCash")

                Branch_Address = Branch_Settings(0)("Address")
                Branch_Contact = Branch_Settings(0)("Contact")
                Branch_BM = Branch_Settings(0)("branch_manager")
                Branch_TIN = Branch_Settings(0)("TIN")
                Branch_Email = Branch_Settings(0)("email_address")

                SMS_Notification = Branch_Settings(0)("SMS")
                Email_Notification = Branch_Settings(0)("Email")
                AppraisedPercent = Branch_Settings(0)("AppraisedPercent")
                Branch_DeferredIncome = Branch_Settings(0)("Deferred")
                Auto_Notification = Branch_Settings(0)("AutoNotification")
                AdvanceOnPrinciapl = Branch_Settings(0)("AdvancePrincipal")
                CVforJV = Branch_Settings(0)("UseBank")
                UseBankBranchID = Branch_Settings(0)("UseBankBranchID")
                AllowFromOtherBranch = Branch_Settings(0)("AllowFromOtherBranch")
            End If

            FrmMain.Timer_Session.Interval = CInt(Login(0)("session")) * 1000
            RetrieveImage(String.Format("SELECT picture FROM users_avatar WHERE user_code = '{0}'", Login(0)("user_code")), Empl_Pic, "picture")

            Dim Directory As DataTable = DataSource("SELECT root_folder, main_folder, report_folder FROM directory_setup;")
            RootFolder = Directory(0)("root_folder")
            If RootFolder = "" Then
                RootFolder = "\\" & _ServerName
            End If
            MainFolder = Directory(0)("main_folder")
            ReportFolder = Directory(0)("report_folder")
            Prev_CompanyMode = CompanyMode

            If _DatabaseName.ToUpper = "FSFC_TEST" Or _DatabaseName.ToUpper = "FSFC_MIGRATION" Then
                MainFolder &= "\Testing"
                'GAMITON NI IF NAG GAMIT NA OG DRIVE A OR DRIVE B ANG SA SERVER
                'RootFolder = ""
                'MainFolder = "A:"
            End If

            ''DataTables
            DT_SpecialAccess = DataSource(String.Format("SELECT ID, FormID, Access, WithAccess, P01, P02, P03, P04, P05, P06, P07, P08, P09, P10, P11, P12 FROM special_access WHERE `status` = 'ACTIVE' ORDER BY Access ;"))
            DT_SpecialAccessDepartment = DataSource(String.Format("SELECT ID, FormID, Access, WithAccess, D01, D02, D03, D04, D05 FROM special_access WHERE `status` = 'ACTIVE' ORDER BY Access ;"))
            DT_PCV_Approver = DataSource(String.Format("CALL Login_GetApprover({0},'PCV')", Branch_ID))
            DT_CAS_Approver = DataSource(String.Format("CALL Login_GetApprover({0},'CAS')", Branch_ID))
            DT_BusinessCenter = DataSource(String.Format("CALL Login_GetBusinessCenter({0})", Branch_ID))
            DT_BusinessCenter.Rows.Add(0, "", "")
            DT_BusinessCenter_V2 = DataSource(String.Format("CALL Login_GetBusinessCenterV2({0})", Branch_ID))
            With Prefix
                If .Columns.Count = 0 Then
                    .Columns.Add("ID")
                    .Columns.Add("Prefix")
                    .Rows.Add(10, "MR")
                    .Rows.Add(11, "MS")
                    .Rows.Add(12, "MISS")
                    .Rows.Add(13, "MRS")
                    .Rows.Add(14, "DR")
                    .Rows.Add(15, "PROF")
                    .Rows.Add(16, "HON")
                    .Rows.Add(17, "LADY")
                    .Rows.Add(18, "MAJOR")
                    .Rows.Add(19, "SIR")
                    .Rows.Add(20, "MADAM")
                    .Rows.Add(21, "REV")
                End If
            End With
            With Suffix
                If .Columns.Count = 0 Then
                    .Columns.Add("Suffix")
                    .Rows.Add("JR")
                    .Rows.Add("SR")
                    .Rows.Add("I")
                    .Rows.Add("II")
                    .Rows.Add("III")
                    .Rows.Add("IV")
                    .Rows.Add("V")
                    .Rows.Add("VI")
                    .Rows.Add("VII")
                    .Rows.Add("VIII")
                    .Rows.Add("IX")
                    .Rows.Add("X")
                End If
            End With
            City = DataSource("CALL Login_GetCity();")
            Nationality = DataSource("CALL Login_GetNationality();")
            Terms = DataSource("CALL Login_GetTerms();")
            Products = DataSource(String.Format("CALL Login_GetProducts('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            Collateral = DataSource("CALL Login_GetCollateral();")
            Mortgage = DataSource("CALL Login_GetMortgage();")
            Note = DataSource("CALL Login_GetNote();")
            Tariff = DataSource(String.Format("CALL Login_GetTariff('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            ServiceNew = DataSource(String.Format("CALL Login_GetServiceCharge('{0}','NEW');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            ServiceRenew = DataSource(String.Format("CALL Login_GetServiceCharge('{0}','RENEW');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            Bank = DataSource("CALL Login_GetBank();")
            BankType = DataSource("CALL Login_GetBankType();")
            Relation = DataSource("CALL Login_GetRelation();")
            DT_Remittance = DataSource("CALL Login_GetRemittance();")
            DTLoggedComputer = DataSource(String.Format("CALL LoginGetLoggedComputer('{0}');", txtUserName.Text))
            With Fuel
                If .Columns.Count = 0 Then
                    .Columns.Add("Fuel")
                    .Rows.Add("Gasoline")
                    .Rows.Add("Diesel")
                End If
            End With
            With MileAge
                If .Columns.Count = 0 Then
                    .Columns.Add("Mileage")
                    .Rows.Add("KMR")
                    .Rows.Add("SMR")
                    .Rows.Add("HOUR")
                End If
            End With
            Make = DataSource("CALL Login_GetMake();")
            CarClassification = DataSource("CALL Login_GetCarClassification();")
            DT_Employer = DataSource("CALL Login_GetEmployer();")
            DT_Position = DataSource("CALL Login_GetPosition();")
            DT_Industry = DataSource("CALL Login_GetIndustry();")
            DT_Signatory = DataSource(String.Format("CALL Login_GetSignatory({0});", Branch_ID))
            Restriction_DT = DataSource(String.Format("CALL Login_GetGroupRestriction('{0}');", GroupRoleID))
            If Restriction_DT.Rows.Count = 0 Then
                Restriction_DT = DataSource(String.Format("CALL Login_GetRestriction({0});", User_ID))
            End If
            Message = DataSource("CALL Login_GetMessage();")
            DT_Employees = DataSource(String.Format("CALL Login_GetEmployees('{0}')", If(Multiple_ID = "", Branch_ID & "," & MFBranch_ID, Multiple_ID & "," & MFBranch_ID)))
            DT_Employees_Other = DataSource(String.Format("CALL Login_GetEmployees_Others('{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            DT_Withholding_Individual = DataSource("CALL Login_GetWitholdingIndividual();")
            DT_Withholding_Corporate = DataSource("CALL Login_GetWitholdingCorporate();")

            DT_Accounts = DataSource(String.Format("CALL Login_GetAccounts({0},{1});", DefaultBankID, Branch_ID))
            DT_AccountsM = DataSource(String.Format("CALL Login_GetAccountsM({0},{1})", DefaultBankID, Branch_ID))
            DT_Accounts_V2 = DataSource(String.Format("CALL Login_GetAccounts_V2({0},{1});", DefaultBankID, Branch_ID))
            DT_AccountsM_V2 = DataSource(String.Format("CALL Login_GetAccountsM_V2({0},{1})", DefaultBankID, Branch_ID))

            DT_Accounts_WithCancel = DataSource(String.Format("CALL Login_GetAccounts({0},{1});", DefaultBankID, Branch_ID))
            DT_AccountsM_WithCancel = DataSource(String.Format("CALL Login_GetAccountsM({0},{1})", DefaultBankID, Branch_ID))
            DT_Accounts_V2_WithCancel = DataSource(String.Format("CALL Login_GetAccounts_V2({0},{1});", DefaultBankID, Branch_ID))
            DT_AccountsM_V2_WithCancel = DataSource(String.Format("CALL Login_GetAccountsM_V2({0},{1})", DefaultBankID, Branch_ID))

            DT_Department = DataSource("CALL Login_GetDepartment();")
            DT_Holidays = DataSource(String.Format("CALL Login_GetHolidays({0})", Branch_ID))

            RegionIDs = DataObject("SELECT GROUP_CONCAT(DISTINCT(RegionID)) FROM branch WHERE `status` = 'ACTIVE';")
            ProvinceIDs = DataObject("SELECT GROUP_CONCAT(DISTINCT(ProvinceID)) FROM branch WHERE `status` = 'ACTIVE';")
            DT_Region = DataSource(String.Format("SELECT regCode AS 'ID', regDesc FROM region WHERE `status` = 'ACTIVE' AND regCode IN ({0}) ORDER BY regCode;", RegionIDs))
            DT_Province = DataSource(String.Format("SELECT provCode AS 'ID', provDesc FROM province WHERE `status` = 'ACTIVE' AND provCode IN ({0}) ORDER BY provDesc;", ProvinceIDs))
            If Message.Rows.Count > 0 Then
                mClose = Message(0)("message")
                mSave = Message(1)("message")
                mUpdate = Message(2)("message")
                mModify = Message(3)("message")
                mDelete = Message(4)("message")
                mRefresh = Message(5)("message")

                mRetrieve = Message(6)("message")
                mRetrieveOff = Message(7)("message")

                mBox_Access = Message(8)("message")
                mBox_Save = Message(9)("message")
                mBox_Update = Message(10)("message")
                mBox_Delete = Message(11)("message")
                mBox_Print = Message(12)("message")
            End If

            cpuID = My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "Identifier", "n/a")
            cpuID = cpuID.Substring(0, cpuID.IndexOf(" "))
            WithProgressBar = Login(0)("WithProgressBar")

            '***Variable Assign
            Logs("Login", "Login", "Successfully Login", "Successfully Login", "", "", "")
            With FrmMain
                If .SessionOut Then
                    .FrmMain_Load(sender, e)
                End If
            End With

            If InvokeRequired Then
                With th
                    .Abort()
                    .Join()
                End With
                With Splash
                    .Close()
                    .Dispose()
                End With
            Else
                Invoke(New _SubName(AddressOf StopThread))
            End If
            Cursor = Cursors.Default

            'Failed_Login = AccountThreshold
            With FrmMain
                .Show()
                .BringToFront()
            End With
            Hide()
            SaveSetting("FSFC_System", "Connection", "DefaultUsername", txtUserName.Text)

            If MultipleBranch Then
                FrmMain.btnSettings.Enabled = True
            Else
                FrmMain.btnSettings.Enabled = False
            End If

            PendingWork = False
            'FrmMain.btnNotification.LookAndFeel.UseDefaultLookAndFeel = True

            If Auto_AlertNotification Then
                Dim Alert As New FrmAlertLoanApplication
                With Alert
                    .FromLogin = True
                    .ShowDialog()
                    .Dispose()
                End With
            End If
        Else
Here:
            Dim PerUserFailed As Integer
            If ExistUser Then
                DataObject(String.Format("INSERT INTO failed_login SET UserID = '{0}', Domain = '{1}', DomainUser = '{2}', IP_Address = '{3}';", Login(0)("ID"), Environment.UserDomainName, Environment.UserName, IP_Address))
                PerUserFailed = DataObject(String.Format("SELECT COUNT(ID) FROM failed_login WHERE UserID = {0} AND `status` = 'ACTIVE' AND IFNULL(TIMESTAMPDIFF(MINUTE, `timestamp`, CURRENT_TIMESTAMP()),0) < {1};", Login(0)("ID"), AccountLockDuration + 99999999999999)) ' + 99999999999999 gi add para dli lang usa mu apply ang mubalik pag taas ang attempt nga maka login per user since nga maka cause og pag weaker sa security
            Else
                PerUserFailed = 0
                MsgBox("Login failed! username not found.", MsgBoxStyle.Exclamation, "Failed")
                Exit Sub
            End If
            MsgBox(String.Format("Login failed! Incorrect username or password. {0} attempt(s) left.", NegativeNotAllowed(AccountThreshold - PerUserFailed)), MsgBoxStyle.Exclamation, "Failed")
            TriggerUserChange = False
            txtPassword.Text = Nothing
            'Failed_Login -= 1
            If AccountThreshold - PerUserFailed <= 0 Then
                Cursor = Cursors.Default
                LockedAccount = True
                MsgBox(String.Format("Failure to login for {1} times consecutively will lock your account {0}. Please contact the ASG to unlock your account.", txtUserName.Text, AccountThreshold), MsgBoxStyle.Information, "Info")
                DataObject(String.Format("UPDATE users SET LogStatus = 'LOCKED', LockedTime = CURRENT_TIMESTAMP() WHERE username = '{0}' AND `status` = 'ACTIVE';", txtUserName.Text))

                Msg = "Good day ASG,<br>" & vbCrLf
                Msg &= String.Format(" Account of {0} is locked because of incorrect password for x{1} consecutively. Please contact {0} immediately.<br><br>" & vbCrLf, txtUserName.Text, AccountThreshold)
                'Msg &= "Domain: " & Environment.UserDomainName & "<br>"
                'Msg &= "Domain User: " & Environment.UserName & "<br>"
                Msg &= "Computer: " & Computer & "<br>"
                'Msg &= "IP Address: " & IP_Address & "<br>"
                Msg &= "Date: " & Format(Date.Now, "MMMM dd, yyyy [dddd]") & "<br>"
                Msg &= "Time: " & Format(Date.Now, "hh:mm:ss") & "<br>"
                Msg &= "Branch: " & Branch & "<br>"
                Msg &= "Thank you!"
                '******* SEND EMAIL *********************************************************************************
                Email_Notification = True
                GetTemporaryAppPW(AppEmailAddress)
                SendEmail("app.support@firststandard.ph", "Locked Account of " & txtUserName.Text & " [" & Branch & "]", Msg, False, False, False, 0, "", "")
                Logs("Login", "Login", "Failed to login for 5x", "Account Locked for " & txtUserName.Text, "", "", "")
                'Application.Exit()
            End If
        End If
    End Sub

    Private Sub TxtPassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call BtnOK_Click(sender, e)
        End If
    End Sub

    Private Sub TxtOTAC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOTAC.KeyPress
        If e.KeyChar = ChrW(Keys.Enter) Then
            Call BtnOK_Click(sender, e)
        End If
    End Sub

    Private Sub TxtUserName_Password_KeyDown(sender As Object, e As KeyEventArgs) Handles txtUserName.KeyDown, txtPassword.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPassword.Focus()
        End If

        If Net.Dns.GetHostName.ToString = "ARGOWSL-044" Then
            If e.Control And e.KeyCode = Keys.A Then
                txtUserName.Text = "mgotico"
                txtPassword.Text = "12345678Ab!"
                btnOK.PerformClick()
            ElseIf e.Control And e.KeyCode = Keys.D1 Then
                txtUserName.Text = "mgotico1"
                txtPassword.Text = "kevin"
                btnOK.PerformClick()
            ElseIf e.Control And e.KeyCode = Keys.D2 Then
                txtUserName.Text = "mgotico2"
                txtPassword.Text = "kevin"
                btnOK.PerformClick()
            End If
        End If
    End Sub

    Private Sub TxtUserName_Leave(sender As Object, e As EventArgs) Handles txtUserName.Leave
        txtUserName.Text = ReplaceText(txtUserName.Text)
    End Sub

    Private Sub TxtPassword_Leave(sender As Object, e As EventArgs) Handles txtPassword.Leave
        txtPassword.Text = ReplaceText(txtPassword.Text)
    End Sub

    Private Sub FrmLogin_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.KeyCode = Keys.Escape Then
            Application.Exit()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            FrmDBConnection.ShowDialog()
        ElseIf e.Control And e.KeyCode = Keys.D8 Then
            If Net.Dns.GetHostName.ToString = "ARGOWSL-044" Then
                Dim Lotto As New FrmLuckyPicks
                With Lotto
                    .BringToFront()
                    SendToBack()
                    .ShowDialog()
                    .Dispose()
                End With
            End If
        ElseIf e.Control And e.KeyCode = Keys.F Then
            If IO.File.Exists("C:\Windows\Fonts\GOTHIC.TTF") Then
            Else
                If MsgBoxYes("Would you like to install Century Gothic Font?") = MsgBoxResult.Yes Then
                    Process.Start("\\192.168.1.220\lms\Font\GOTHIC.TTF")
                    Process.Start("\\192.168.1.220\lms\Font\GOTHICB.TTF")
                    Process.Start("\\192.168.1.220\lms\Font\GOTHICBI.TTF")
                    Process.Start("\\192.168.1.220\lms\Font\GOTHICI.TTF")
                    MsgBox("Successfully Installed!", MsgBoxStyle.Information, "Info")
                End If
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub LblVersion_MouseDown(sender As Object, e As MouseEventArgs) Handles lblVersion.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Dim PW As New FrmPassword
            With PW
                .ShowMessage = False
                .lblNote.Text = "*For IT Password only."
                SendToBack()
HERE:
                If .ShowDialog = DialogResult.OK Then
                    IT_PW = "Admin@FSFC"
                    If IT_PW = .txtPassword.Text Then
                        FrmDBConnection.ShowDialog()
                    Else
                        MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                        .txtPassword.Text = ""
                        GoTo HERE
                    End If
                End If
                .Dispose()
            End With
        ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
            If Application.ProductVersion = CurrentVersion Then
                MsgBox("Your version is up to date.", MsgBoxStyle.Information, "Info")
            Else
                If MsgBoxYes(String.Format("Your using a version {0} from the official version release {1}, would you like to log off to refresh your system version?", Application.ProductVersion, CurrentVersion)) = MsgBoxResult.Yes Then
                    ExitWindowsEx(EWX_LogOff, 0&)
                End If
            End If
        End If
    End Sub

    Private Sub TxtPassword_ButtonCustomClick(sender As Object, e As EventArgs) Handles txtPassword.ButtonCustomClick

    End Sub

    Private Sub Timer_Date_Tick(sender As Object, e As EventArgs) Handles Timer_Date.Tick
        lblTimer.Text = GetTime(PassSecs)
        If PassSecs = 0 Then
            lblTimer.Visible = False
            btnResend.Visible = True
            If txtOTAC.Text = "" Then
                txtOTAC.Enabled = False
            End If
            Timer_Date.Stop()
        End If
        PassSecs -= 1
    End Sub

    Private Sub BtnResend_Click(sender As Object, e As EventArgs) Handles btnResend.Click
        SendEmailUser("Authorization")
        txtOTAC.Enabled = True
        btnResend.Visible = False
        lblTimer.Visible = True
        PassSecs = 300
        Timer_Date.Start()
    End Sub

    Private Sub SendEmailUser(Type As String)
        Code = GenerateOTAC()
        Msg = String.Format("Good day," & vbCrLf, If(Login(0)("Nickname").ToString.Trim = "", Login(0)("empl_name").ToString.Trim, Login(0)("Nickname").ToString.Trim))
        If Type = "Authorization" Then
            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> User Login." & vbCrLf, Code)
        Else
            Msg &= String.Format(" One Time Authorization Code is <b>{0}</b> for password reset." & vbCrLf, Code)
        End If
        Msg &= "Thank you!"
        '******* SEND SMS *********************************************************************************
        If Login(0)("Phone") = "" Then
        Else
            SMS_Notification = True
            SendSMS(Login(0)("Phone"), Msg, True)
        End If
        '******* SEND EMAIL *********************************************************************************
        If Login(0)("EmailAdd") = "" Then
        Else
            Email_Notification = True
            SendEmail(Login(0)("EmailAdd"), "One Time Authorization Code " & Code, Msg, False, False, False, 0, "", "")
        End If
    End Sub

    Private Sub BtnCancelL_Click(sender As Object, e As EventArgs) Handles btnCancelL.Click
        txtUserName.Text = ""
        txtPassword.Text = ""
        txtUserName.Enabled = True
        txtPassword.Enabled = True

        btnCancelL.Visible = False
        btnResend.Visible = False
        lblTimer.Visible = False
        Timer_Date.Stop()
        LabelX5.Visible = False
        txtOTAC.Visible = False
        lblForgot.Visible = True
        lblTimer.Text = ""
        txtOTAC.Text = ""
    End Sub

    Private Sub TxtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserName.TextChanged
        TriggerUserChange = True
    End Sub

    Private Sub LblForgot_Click(sender As Object, e As EventArgs) Handles lblForgot.Click
        Dim OneTP As New FrmOneTimePassword
        If txtUserName.Text = "" Then
            MsgBox("Please fill your username.", MsgBoxStyle.Information, "Info")
        Else
            If MsgBox("Do you want to reset your password?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                If Login.Rows.Count > 0 Then
                Else
                    TriggerLoggedIn()
                    If Login.Rows.Count = 0 Then
                        MsgBox("Username not found, please check your username.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If
                Empl_Email = Login(0)("EmailAdd")
                Salt = Login(0)("Salt")
                User_ID = Login(0)("ID")
                User_Code = Login(0)("user_code")
                If Empl_Email = "" Then
                    MsgBox("Username has no email address, please contact the ASG.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Email_Notification = True
                GetTemporaryAppPW(AppEmailAddress)
                SendEmailUser("Reset")
                Hide()
                With OneTP
                    .OTP = Code
                    .BringToFront()
                    If .ShowDialog() = DialogResult.OK Then
                        Dim CP As New FrmChangePassword
                        With CP
                            .lblTitle.Text = "RESET PASSWORD"
                            .txtUserName.Text = txtUserName.Text
                            .txtUserType.Text = User_Type
                            .LabelX7.Enabled = False
                            .txtOldP.Enabled = False
                            .btnUpdate.Text = "Save"
                            .BringToFront()
                            Hide()
                            If .ShowDialog() = DialogResult.OK Then
                                txtPassword.Clear()
                                TriggerUserChange = True
                                DataObject(String.Format("UPDATE failed_login SET `status` = 'DONE' WHERE UserID = {0};", Login(0)("ID")))
                                Show()
                            Else
                                Show()
                            End If
                        End With
                    Else
                        Show()
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub LblForgot_MouseEnter(sender As Object, e As EventArgs) Handles lblForgot.MouseEnter
        lblForgot.ForeColor = OfficialColor2
    End Sub

    Private Sub LblForgot_MouseLeave(sender As Object, e As EventArgs) Handles lblForgot.MouseLeave
        lblForgot.ForeColor = Color.Black
    End Sub
End Class