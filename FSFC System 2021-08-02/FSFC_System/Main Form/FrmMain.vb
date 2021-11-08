Imports System.Threading
Public Class FrmMain
    Dim T_SessionX As Integer
    Dim T_SessionY As Integer
    Delegate Sub _SubName()

    '***For Notification
    Public IndividualCount As Integer
    Public CorporateCount As Integer
    Public VehicleCount As Integer
    Public RealEstateCount As Integer
    Public VehicleCount_Sold As Integer
    Public RealEstateCount_Sold As Integer
    Public CreditApplication As Integer
    Public CreditApplication_Approved As Integer
    Public CI As Integer
    Public CI_Approved As Integer
    Public Delegate Sub ShowAlertInvoker(sCaption As String, sMessage As String)
    Public Delegate Sub ShowDateInvoker(sCaption As String, sMessage As String)

    Public OldUsername As String
    Public SessionOut As Boolean
    Dim Greetings As String
    Public VoiceOut As Boolean = True
    Dim FirstName As String()

    'Send SMS
    Dim WithEvents SerialPort As New IO.Ports.SerialPort
    Private Declare Sub Sleep Lib "kernel32" (milsec As Long)
    ReadOnly objport As New ClsSMS
    Dim DT_Outbox As New DataTable
    ReadOnly thread As New Thread(AddressOf MyBackgroundThread)
    Dim FirstLoad As Boolean
    Dim Seconds_300 As Integer
    Dim Seconds_450 As Integer
    Dim Seconds_10 As Integer
    Dim Seconds_05 As Integer
    Public Declare Function GetTickCount Lib "kernel32" () As Long
    Public Keyboard_Press As Boolean = True
    Public Keyboard_Session As Integer
    Public PrintscreenActivate As Boolean

    ReadOnly intKey As Integer
    ReadOnly intProcID As Integer
    Public Declare Function GetAsyncKeyState Lib "user32" Alias "GetAsyncKeyState" (vKey As Integer) As Integer
    Dim Greenmage As Image
    Dim OrangeImage As Image
    Dim RedImage As Image

    Public Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        Greenmage = My.Resources.Green
        OrangeImage = My.Resources.Orange
        RedImage = My.Resources.Red
        FixUI(AllowStandardUI)
        If Application.ProductVersion < CurrentVersion Then
            I_CheckVersion.Appearance.Normal.ForeColor = Color.Red
        End If
        FirstLoad = True
        Keyboard_Press = True
        Keyboard_Session = Timer_Session.Interval
        PanelControl1.Appearance.BorderColor = Color.Black
        PanelControl2.Appearance.BorderColor = Color.Black
        PanelControl3.Appearance.BorderColor = Color.Black
        PanelControl4.Appearance.BorderColor = Color.Black

        If SessionOut = False Then
            FirstName = Empl_Name.Split(" ")
            Greetings = String.Format("Good day {0}", If(Nickname = "", FirstName(0), Nickname))
            'Greetings = String.Format(String.Format("{0}", DataObject(String.Format("SELECT greetings FROM greetings_setup WHERE `Day` = '{0}' ORDER BY RAND() LIMIT 1;", Format(Date.Now, "dddd")))), FirstName(0))
            btnHistory.Text = "iLoanWorkX v" & Application.ProductVersion
            DevExpress.UserSkins.BonusSkins.Register()
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = Empl_Skin

            M_Dashboard.Expanded = False
            M_Administration.Expanded = False
            M_LoansManagement.Expanded = False
            M_Cashiering.Expanded = False
            M_Financials.Expanded = False
            M_AssetManagement.Expanded = False
            M_ITL.Expanded = False
            M_NonLoans.Expanded = False
            M_Utilities.Expanded = False
            M_Reports.Expanded = False
            M_Help.Expanded = False
            SM_GeneralSetup.Expanded = False
            SM_Accounting.Expanded = False
            SM_Loans.Expanded = False
            SM_Security.Expanded = False
            SM_Micro.Expanded = False
            SM_Profile.Expanded = False
            SM_GeneralSetupV2.Expanded = False
            SM_Utilities.Expanded = False
            SM_GeneralSetupV3.Expanded = False

            SM_Credit.Expanded = True
            SM_Transaction.Expanded = True
            SM_Financials.Expanded = True

            lblName.Text = Empl_Name
            lblPosition.Text = Empl_Position & If(Empl_V2Position = "", "", " / " & Empl_V2Position) & If(Empl_V3Position = "", "", " / " & Empl_V3Position) & If(Empl_V4Position = "", "", " / " & Empl_V4Position)
            PictureEdit1.Image = Empl_Pic.Image
            Timer_Date.Start()
            Timer_Email.Start()
            Timer_Session.Start()

            '***For Notification
            IndividualCount = DataObject(String.Format("CALL Main_IndividualCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            CorporateCount = DataObject(String.Format("CALL Main_CorporateCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            VehicleCount = DataObject(String.Format("CALL Main_VehicleCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            VehicleCount_Sold = DataObject(String.Format("CALL Main_VehicleCountSold('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            RealEstateCount = DataObject(String.Format("CALL Main_RealEstateCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            RealEstateCount_Sold = DataObject(String.Format("CALL Main_RealEstateCountSold('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            CreditApplication = DataObject(String.Format("CALL Main_CreditApplicationCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            CreditApplication_Approved = DataObject(String.Format("CALL Main_CreditApplicationApprovedCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            CI = DataObject(String.Format("CALL Main_CreditInvestigationCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            CI_Approved = DataObject(String.Format("CALL Main_CreditInvestigationApprovedCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            '***For Notification

            'LoadSelectedForm()
        End If

        'If _ServerName = "172.31.8.68" And System.Net.Dns.GetHostName.ToString = "ARGOWSL-044" Then
        'Else
        Timer_Notification.Start()
        'End If

        Dim Birthdate As Boolean = DataObject(String.Format("SELECT IF(birthdate = '',FALSE,(IF(MONTH(birthdate) = MONTH(NOW()) AND DAY(birthdate) = DAY(NOW()),TRUE,FALSE))) FROM employee_setup WHERE ID = '{0}' AND `status` = 'ACTIVE' LIMIT 1", Empl_ID))
        If Birthdate Then
            Dim B As New FrmBirthday
            With B
                .ShowDialog()
                .Dispose()
            End With
        Else
            If BackgroundWorker1.IsBusy = False Then
                BackgroundWorker1.RunWorkerAsync()
            End If
        End If

        If User_Type = "ADMIN" And FrmLogin.txtUserName.Text.ToLower = "mgotico" And My.Computer.Ports.SerialPortNames.Count > 0 And Auto_SMSSend Then
            With cbxPort
                For i As Integer = 0 To My.Computer.Ports.SerialPortNames.Count - 1
                    .Items.Add(My.Computer.Ports.SerialPortNames(i))
                Next
                '.Visible = True
                .SelectedIndex = .Items.Count - 1
            End With
        Else
            cbxPort.Visible = False
            Timer_Send.Stop()
        End If

        'If ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Or User_Type = "ADMIN" Then
        '    btnEmail.Enabled = True
        '    I_EmailCredential.Enabled = True
        '    If User_Type = "ADMIN" Then
        '        If AppEmailAddress = "" Or AppPassword = "" Then
        '            btnEmail.PerformClick()
        '        End If
        '    Else
        '        If ConfiEmail = "" Or ConfiPW = "" Then
        '            btnEmail.PerformClick()
        '        End If
        '    End If
        'Else
        '    btnEmail.Enabled = False
        '    I_EmailCredential.Enabled = False
        'End If

        If User_Type = "ADMIN" Then
            'PanelControl1.Appearance.BackColor = OfficialColor2
            'PanelControl1.Appearance.BackColor2 = OfficialColor2
            lblName.Font = New Font(OfficialFont, lblName.Font.Size, FontStyle.Bold)
            btnSystemSettings.Enabled = True
            I_SystemSettings.Enabled = True
        Else
            btnSystemSettings.Enabled = False
            I_SystemSettings.Enabled = False
            btnSkin.Enabled = False
            I_Skin.Enabled = False
        End If

        If DepartmentHead Then
            lblPosition.Font = New Font(OfficialFont, lblPosition.Font.Size, FontStyle.Bold)
            lblPosition.ToolTip = "Position of User [Department Head]"
        End If

        If MultiAuthentication Then
            btnMultiAuthentication.LookAndFeel.UseDefaultLookAndFeel = False
        Else
            btnMultiAuthentication.LookAndFeel.UseDefaultLookAndFeel = True
        End If

        If CheckLoggedComputer() And Empl_Email <> "" And NotifyLoggedInToOthers Then
            '******* SEND EMAIL *********************************************************************************
            Dim Msg As String = String.Format("Good day {0},<br>", Empl_Name) & vbCrLf
            Msg &= String.Format(" There was an attempted sign-in to your iLoanWorkX account at {0} with the correct email/mobile number and password. As a security measure, please check the following details to make sure this was you:<br><br>" & vbCrLf, Format(Date.Now, "MMMM dd, yyyy hh:mm [dddd]"))
            Msg &= "Domain: " & Environment.UserDomainName & "<br>"
            Msg &= "Domain User: " & Environment.UserName & "<br>"
            Msg &= "Computer: " & Computer & "<br>"
            Msg &= "IP Address: " & IP_Address & "<br><br>"
            Msg &= "If you initiated this sign-in attempt, you can ignore this message<br><br>"
            Msg &= "Don't recognize this activity? Please change your password immediately and alert us by emailing app.support@firststandard.ph. To help ensure the security of your account, we will notify you every time we detect a sign-in."
            SendEmail(Empl_Email, "Login Detected From An Unknown Device", Msg, False, False, False, 0, "", "")
        End If
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettingsDefaultDevEx({lblName, lblPosition})

            GetButtonFontSettingsDevExpress({btnMinimize, btnLogout, btnClose, btnHistory, lblDate})

            GetAccordionFontSettings({AccordionControl1})

            GetAlertControlFontSettings({AlertControl1})
        Catch ex As Exception
            TriggerBugReport("Main - Fix UI", ex.Message.ToString)
        End Try
    End Sub

    Public Sub Speak(Say As String)
        If BackgroundWorker1.IsBusy = False Then
            Greetings = Say
            BackgroundWorker1.RunWorkerAsync()
        End If
    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Try
            Dim SAPI = CreateObject("SAPI.spvoice")
            If VoiceOut Then
                'SAPI.Speak(Greetings)
                'SAPI.Speak(String.Format(String.Format("{0}", DataObject(String.Format("SELECT greetings FROM greetings_setup WHERE `Day` = '{0}' ORDER BY RAND() LIMIT 1;", Format(Date.Now, "dddd")))), FirstName(0)))
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        'If MsgBoxYes("Are you sure you want to close the system?") = MsgBoxResult.Yes Then
        '    If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
        '    Else
        '        Logs("Main", "Close", "Close Program", "", "", "", "")
        '    End If
        '    If cbxPort.Enabled = False And cbxPort.Visible Then
        '        objport.ClosePort(SerialPort)
        '    End If
        '    FrmAgingNew.Close()
        '    Application.Exit()
        'End If
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If MsgBoxYes("Are you sure you want to open your user profile?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            If PanelControl3.Controls.Contains(FrmUserProfile) = False Then
                Logs("Main", "Open", "User Profile", "", "", "", "")
            End If
            Forms(FrmUserProfile, PanelControl3)
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BtnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
        WindowState = FormWindowState.Minimized
    End Sub

    Private Sub BtnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
        WindowState = FormWindowState.Maximized
    End Sub

    Private Sub BtnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MsgBoxYes("Are you sure you want to logout from the system?") = MsgBoxResult.Yes Then
            If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            Else
                Logs("Main", "Logout", "Successfully Logout", "", "", "", "")
            End If
            SessionOut = False
            With cbxPort
                If .Enabled = False And .Visible Then
                    objport.ClosePort(SerialPort)
                    .Items.Clear()
                End If
            End With
Here:
            For Each F As Form In My.Application.OpenForms
                If F.Name = "FrmLogin" Then
                Else
                    F.Dispose()
                    GoTo Here
                End If
            Next
            With FrmLogin
                OldUsername = .txtUserName.Text
                .TriggerUserChange = True
                .txtPassword.Text = ""
                .ShowInTaskbar = True
                .Show()
                .WindowState = FormWindowState.Normal
            End With
            Close()
        End If
    End Sub

    Private Sub Timer_Date_Tick(sender As Object, e As EventArgs) Handles Timer_Date.Tick
        Seconds_05 += 1
        If Seconds_05 = 10 Then
            If PWAge > 0 And If(PWAge <= LastPWChange, 0, PWAge <= LastPWChange + PWNotifyExpire) Then
                MsgBox(String.Format("Your password will expire in {0} day(s), please update your password.", PWAge - LastPWChange), MsgBoxStyle.Information, "Info")
            End If
            If (PWAge > 0 And PWAge <= LastPWChange) Or ChangePW Then
                If ChangePW Then
                    MsgBox("Your temporary password must be change for your protection.", MsgBoxStyle.Information, "Info")
                Else
                    MsgBox(String.Format("Your password reached the maximum age of {0} day(s), please update your password.", PWAge), MsgBoxStyle.Information, "Info")
                End If
                Dim Change As New FrmChangePassword
                With Change
                    .txtUserName.Text = FrmLogin.txtUserName.Text
                    .OldP = FrmLogin.txtPassword.Text
                    .txtUserType.Text = User_Type
                    '.btnWaive.Visible = True
                    .btnClose.Enabled = False
                    .btnWaive.Focus()
                    .ShowDialog()
                    .Dispose()
                End With
            End If
        End If
        With btnHistory
            If _DatabaseName.ToLower = "fsfc" And Application.ProductVersion >= CurrentVersion Then
                .ToolTip = "Connected to live database and system is updated"
                If IsNothing(.Image) Then
                    .Image = Greenmage.Clone
                    .Text = "iLoanWorkX v" & Application.ProductVersion
                Else
                    .Image = Nothing
                    .Text = "      iLoanWorkX v" & Application.ProductVersion
                End If
            ElseIf _DatabaseName.ToLower <> "fsfc" And Application.ProductVersion >= CurrentVersion Then
                .ToolTip = "Connected to test database and system is updated"
                If IsNothing(.Image) Then
                    .Image = OrangeImage.Clone
                    .Text = "iLoanWorkX v" & Application.ProductVersion
                Else
                    .Image = Nothing
                    .Text = "      iLoanWorkX v" & Application.ProductVersion
                End If
            ElseIf _DatabaseName.ToLower = "fsfc" And Application.ProductVersion < CurrentVersion Then
                .ToolTip = "Connected to live database and system is outdated"
                If IsNothing(.Image) Then
                    .Image = OrangeImage.Clone
                    .Text = "iLoanWorkX v" & Application.ProductVersion
                Else
                    .Image = Nothing
                    .Text = "      iLoanWorkX v" & Application.ProductVersion
                End If
            Else
                .ToolTip = "Connected to test database and system is outdated"
                If IsNothing(.Image) Then
                    .Image = RedImage.Clone
                    .Text = "iLoanWorkX v" & Application.ProductVersion
                Else
                    .Image = Nothing
                    .Text = "      iLoanWorkX v" & Application.ProductVersion
                End If
            End If
        End With

        If Keyboard_Session > 0 Then
            Keyboard_Session -= 1000
            If Keyboard_Session <= 0 Then
                Keyboard_Press = False
                Timer_Session_Tick(sender, e)
            End If
        End If
        If PrintscreenActivate = False And AllowPrintScreen = False Then
            Try
                If Clipboard.ContainsImage Then
                    Try
                        Clipboard.GetImage.Dispose()
                    Catch ex As Exception
                        Clipboard.Clear()
                    End Try
                End If
            Catch ex As Exception
            End Try
        End If
        If FrmLogin.InvokeRequired = True Then
            Dim Login = New FrmLogin
            FrmLogin.Invoke(New ShowDateInvoker(AddressOf Login.StopThread), New Object() {"", ""})
        Else
            Try
                If _ServerName.ToUpper = "LOCALHOST" Then
                    lblDate.Text = Format(Date.Now, "ddd MMM-dd-yy hh:mm:ss") & " [" & _DatabaseName & "]"
                Else
                    If My.Computer.Network.Ping(_ServerName) Then
                        lblDate.Text = Format(Date.Now, "ddd MMM-dd-yy hh:mm:ss") & " [" & _DatabaseName & "]"
                    Else
                        If Ping_Notification Then
                            lblDate.Text = "[Disconnected from Server, please check your Internet]"
                        Else
                            lblDate.Text = Format(Date.Now, "ddd MMM-dd-yy hh:mm:ss") & "    [" & _DatabaseName & "]"
                        End If
                    End If
                End If

                If PendingWork Then
                    If btnNotification.Appearance.BackColor = Color.White Then
                        btnNotification.Appearance.BackColor = OfficialColor2
                        btnNotification.Appearance.BackColor2 = OfficialColor2
                    Else
                        btnNotification.Appearance.BackColor = Color.White
                        btnNotification.Appearance.BackColor2 = Color.White
                    End If
                End If
            Catch ex As Exception
                If Ping_Notification Then
                    lblDate.Text = "[Disconnected from Server please wait for a while or contact IT]"
                Else
                    lblDate.Text = Format(Date.Now, "ddd MMM-dd-yy hh:mm:ss") & " [" & _DatabaseName & "]"
                End If
            End Try
        End If
    End Sub

    Private Sub Timer_Session_Tick(sender As Object, e As EventArgs) Handles Timer_Session.Tick
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            Exit Sub
        End If
        Dim CurrentX As Integer = Cursor.Position.X
        Dim CurrentY As Integer = Cursor.Position.Y
        If T_SessionX = Cursor.Position.X And T_SessionY = Cursor.Position.Y And Keyboard_Press = False And FrmLogin.txtPassword.Text <> "" Then
            Try
                SessionOut = True
                OldUsername = FrmLogin.txtUserName.Text
Here:
                For Each F As Form In My.Application.OpenForms
                    If F.Name = "FrmLogin" Then
                    Else
                        F.Dispose()
                        GoTo Here
                    End If
                Next
                Logs("Main", "Session Expire", "Automatic Logout", "", "", "", "")
                With FrmLogin
                    .txtPassword.Text = ""
                    .ShowInTaskbar = True
                    .TriggerUserChange = True
                    .WindowState = FormWindowState.Normal
                    .Show()
                    .Enabled = True
                End With
            Catch ex As Exception
            End Try
        End If
        Keyboard_Press = True
        Keyboard_Session = Timer_Session.Interval
        T_SessionX = Cursor.Position.X
        T_SessionY = Cursor.Position.Y
    End Sub

    Private Sub FrmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Keyboard_Press = True
        Keyboard_Session = Timer_Session.Interval
        If e.Control And e.KeyCode = Keys.T Then
            Dim Timer As New FrmTimerSession
            With Timer
                .ShowDialog()
                .Dispose()
            End With
        ElseIf e.Alt And e.KeyCode = Keys.F4 Then
HereDispose:
            For Each F As Form In My.Application.OpenForms
                If F.Name = "FrmMain" Then
                Else
                    F.Dispose()
                    GoTo HereDispose
                End If
            Next
            Application.Exit()
        ElseIf e.Alt And e.KeyCode = Keys.Q Then
            btnLogout.Focus()
            btnLogout.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.I Then
            btnMotivation.Focus()
            btnMotivation.PerformClick()
        ElseIf e.Control And e.Shift And e.KeyCode = Keys.V Then
            I_CheckVersion_Click(sender, e)
        ElseIf e.Control And e.Shift And e.KeyCode = Keys.R Then
            'Restriction_DT = DataSource(String.Format("SELECT form_id, allow_access, allow_save, allow_update, allow_delete, allow_print FROM restriction_setup WHERE user_id = '{0}' AND user_code = '{1}' AND `status` = 'ACTIVE';", User_ID, User_Code))
            GroupRoleID = DataObject(String.Format("SELECT GroupRoleID FROM users WHERE ID = '{0}';", User_ID))
            Restriction_DT = DataSource(String.Format("CALL Login_GetGroupRestriction('{0}');", GroupRoleID))
            MsgBox("Restriction is now refresh, Please try again your acccess.", MsgBoxStyle.Information, "Info")
        ElseIf e.Control And e.Shift And e.KeyCode = Keys.S Then
            If Auto_Department Then
                If MsgBoxYes("Would you like to Deactivate the auto suggestion for Business Center and Department?") = MsgBoxResult.Yes Then
                    Auto_Department = False
                    Auto_BusinessCenter = False
                    DataObject(String.Format("UPDATE users SET Auto_Department = 0, Auto_BusinessCenter = 0 WHERE ID = '{0}';", User_ID))
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            Else
                If MsgBoxYes("Would you like to Activate the auto suggestion for Business Center and Department?") = MsgBoxResult.Yes Then
                    Auto_Department = True
                    Auto_BusinessCenter = True
                    DataObject(String.Format("UPDATE users SET Auto_Department = 1, Auto_BusinessCenter = 1 WHERE ID = '{0}';", User_ID))
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        ElseIf e.Control And e.Shift And e.KeyCode = Keys.M Then
            If VoiceOut Then
                If MsgBoxYes("Would you like to deactivate the Voice Assistant?") = MsgBoxResult.Yes Then
                    Try
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")

                        'SAPI.Speak(String.Format("Bye {0}.", If(Nickname = "", FirstName(0), Nickname)))
                        'VoiceOut = False
                    Catch ex As Exception
                    End Try
                End If
            Else
                If MsgBoxYes("Would you like to activate the Voice Assistant?") = MsgBoxResult.Yes Then
                    Try
                        'Dim SAPI
                        'SAPI = CreateObject("SAPI.spvoice")

                        'VoiceOut = True
                        'SAPI.Speak(String.Format("Hello {0}.", If(Nickname = "", FirstName(0), Nickname)))
                    Catch ex As Exception
                    End Try
                End If
            End If
        ElseIf e.Control And e.Shift And e.KeyCode = Keys.Q Then
            If User_Type = "ADMIN" Then
                If CompanyMode = 0 Then
                    If MsgBoxYes("Would you like reset the system to RELEASED UNUSED MEMORY?") = MsgBoxResult.Yes Then
                        DataObject(String.Format("UPDATE company SET ComMode = 1 WHERE ID = '{0}'", Company_ID))
                        Seconds_10 = 9
                        MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                    End If
                Else
                    If MsgBoxYes("Would you like reset the system to release unused memory?") = MsgBoxResult.Yes Then
                        DataObject(String.Format("UPDATE company SET ComMode = 0 WHERE ID = '{0}'", Company_ID))
                        Seconds_10 = 9
                        MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                    End If
                End If
            End If
        ElseIf e.Control And e.Shift And e.KeyCode = Keys.A Then
            If Restriction Then
                If MsgBoxYes("Would you like to deactivate the restriction?") = MsgBoxResult.Yes Then
                    Dim PW As New FrmPassword
                    With PW
                        .ShowMessage = False
                        .lblNote.Text = "*For IT Password only."
                        If .ShowDialog = DialogResult.OK Then
                            If IT_PW = DataObject(String.Format("SELECT MD5(SHA1('{0}'))", .txtPassword.Text)) Then
                                If MsgBoxYes("Would you like to save this restriction as your default?") = MsgBoxResult.Yes Then
                                    DataObject(String.Format("UPDATE users SET restriction = 0 WHERE user_code = '{0}'", User_Code))
                                    Logs("Main", "KeyDown", "Off Restriction", "Off Restriction", "", "", "")
                                End If
                                Restriction = False
                                MsgBox("Restriction is now off.", MsgBoxStyle.Information, "Info")
                            Else
                                MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                            End If
                        End If
                        .Dispose()
                    End With
                End If
            Else
                If MsgBoxYes("Would you like to activate the restriction?") = MsgBoxResult.Yes Then
                    Dim PW As New FrmPassword
                    With PW
                        .ShowMessage = False
                        .lblNote.Text = "*For IT Password only."
                        If .ShowDialog = DialogResult.OK Then
                            If IT_PW = DataObject(String.Format("SELECT MD5(SHA1('{0}'))", .txtPassword.Text)) Then
                                If MsgBoxYes("Would you like to save this restriction as your default?") = MsgBoxResult.Yes Then
                                    DataObject(String.Format("UPDATE users SET restriction = 1 WHERE user_code = '{0}'", User_Code))
                                    Logs("Main", "KeyDown", "Activate Restriction", "Activate Restriction", "", "", "")
                                End If
                                Restriction = True
                                MsgBox("Restriction is activated", MsgBoxStyle.Information, "Info")
                            Else
                                MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                            End If
                        End If
                        .Dispose()
                    End With
                End If
            End If
        ElseIf e.Control And e.KeyCode = Keys.R Then
            If RetrieveData = False Then
                If MsgBoxYes(mRetrieve) = MsgBoxResult.Yes Then
                    RetrieveData = True
                End If
            End If
        ElseIf e.Control And e.KeyCode = Keys.E Then
            If RetrieveData Then
                If MsgBoxYes(mRetrieveOff) = MsgBoxResult.Yes Then
                    RetrieveData = False
                End If
            End If
        ElseIf e.Control And e.Shift And e.KeyCode = Keys.Z Then
            btnReport.PerformClick()
        ElseIf e.Control And e.Shift And e.KeyCode = Keys.F Then 'FIX THE ROPOA BALANCE TRANSFERRED WITH ACCOUNTING ENTRY
            If User_Type = "ADMIN" Then
                Dim PW As New FrmPassword
                With PW
                    .ShowMessage = False
                    .lblNote.Text = "*Please fill your password."
HERE:
                    If .ShowDialog = DialogResult.OK Then
                        If FrmLogin.txtPassword.Text = .txtPassword.Text Then
                            Dim DT_Vehicle As DataTable = DataSource(String.Format("SELECT R.ID, R.AssetNumber, R.L.Trans_Date, L.Remarks, R.PlateNum, R.Branch_ID, R.BankID, L.Reference_Number, L.Amount FROM ropoa_vehicle R INNER JOIN (SELECT Trans_Date, Remarks, Reference_Number, Amount, Asset_Number FROM ledger_ropoa WHERE `Transaction` = 'Balance Transferred' AND `status` = 'ACTIVE') L ON R.AssetNumber = L.Asset_Number WHERE R.BalanceTransferred = 0 AND R.`status` = 'ACTIVE';"))
                            Dim DT_RealEstate As DataTable = DataSource(String.Format("SELECT R.ID, R.AssetNumber, R.L.Trans_Date, L.Remarks, R.TCT, R.Branch_ID, R.BankID, L.Reference_Number, L.Amount FROM ropoa_realestate R INNER JOIN (SELECT Trans_Date, Remarks, Reference_Number, Amount, Asset_Number FROM ledger_ropoa WHERE `Transaction` = 'Balance Transferred' AND `status` = 'ACTIVE') L ON R.AssetNumber = L.Asset_Number WHERE R.BalanceTransferred = 0 AND R.`status` = 'ACTIVE';"))
                            Dim SQL As String = ""
                            'ACCOUNTING ENTRY *******************************************************************************************************
                            For x As Integer = 0 To DT_Vehicle.Rows.Count - 1
                                SQL &= String.Format(" UPDATE ropoa_vehicle SET BalanceTransferred = '{0}' WHERE AssetNumber = '{1}';", CDbl(DT_Vehicle(x)("Amount")), DT_Vehicle(x)("AssetNumber"))

                                SQL &= " INSERT INTO accounting_entry SET"
                                SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(DT_Vehicle(x)("Trans_Date")), "yyyy-MM-dd"))
                                SQL &= " EntryType = 'DEBIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(DT_Vehicle(x)("Amount")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(DT_Vehicle(x)("Amount")))
                                SQL &= " AccountCode = '126002', "
                                SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode('{0}');", "126002")))
                                SQL &= " PostStatus = 'POSTED', "
                                SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                                SQL &= String.Format(" PaidFor = '{0}', ", "Balance Transferred")
                                SQL &= String.Format(" ReferenceN = '{0}', ", DT_Vehicle(x)("AssetNumber"))
                                SQL &= String.Format(" Remarks = '{0}', ", DT_Vehicle(x)("Remarks"))
                                SQL &= String.Format(" CVNumber = '{0}', ", DT_Vehicle(x)("PlateNum"))
                                SQL &= String.Format(" BankID = '{0}', ", DT_Vehicle(x)("BankID"))
                                SQL &= String.Format(" branch_id = '{0}';", DT_Vehicle(x)("Branch_ID"))
                            Next
                            For x As Integer = 0 To DT_RealEstate.Rows.Count - 1
                                SQL &= String.Format(" UPDATE ropoa_realestate SET BalanceTransferred = '{0}' WHERE AssetNumber = '{1}';", CDbl(DT_RealEstate(x)("Amount")), DT_RealEstate(x)("AssetNumber"))

                                SQL &= " INSERT INTO accounting_entry SET"
                                SQL &= String.Format(" ORDate = '{0}', ", Format(CDate(DT_RealEstate(x)("Trans_Date")), "yyyy-MM-dd"))
                                SQL &= " EntryType = 'DEBIT',"
                                SQL &= String.Format(" Payable = '{0}', ", CDbl(DT_RealEstate(x)("Amount")))
                                SQL &= String.Format(" Amount = '{0}', ", CDbl(DT_RealEstate(x)("Amount")))
                                SQL &= " AccountCode = '126001', "
                                SQL &= String.Format(" MotherCode = '{0}', ", DataObject(String.Format("SELECT MotherCode('{0}');", "126001")))
                                SQL &= " PostStatus = 'POSTED', "
                                SQL &= String.Format(" DepartmentCode = '{0}', ", "000")
                                SQL &= String.Format(" PaidFor = '{0}', ", "Balance Transferred")
                                SQL &= String.Format(" ReferenceN = '{0}', ", DT_RealEstate(x)("AssetNumber"))
                                SQL &= String.Format(" Remarks = '{0}', ", DT_RealEstate(x)("Remarks"))
                                SQL &= String.Format(" CVNumber = '{0}', ", DT_RealEstate(x)("TCT"))
                                SQL &= String.Format(" BankID = '{0}', ", DT_RealEstate(x)("BankID"))
                                SQL &= String.Format(" branch_id = '{0}';", DT_RealEstate(x)("Branch_ID"))
                            Next
                            'ACCOUNTING ENTRY *******************************************************************************************************
                            DataObject(SQL)
                            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                        Else
                            MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                            .txtPassword.Text = ""
                            GoTo HERE
                        End If
                    Else
                        Exit Sub
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim Branch As New FrmBranchSelector
        With Branch
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnNotification_Click(sender As Object, e As EventArgs) Handles btnNotification.Click
        If MsgBox("Are you sure you want to open the alert notification?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            PendingWork = False
            'btnNotification.LookAndFeel.UseDefaultLookAndFeel = True
            Dim Alert As New FrmAlertLoanApplication
            With Alert
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnTimer_Click(sender As Object, e As EventArgs) Handles btnTimer.Click
        Dim Timer As New FrmTimerSession
        With Timer
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub TriggerLoadSelectedForm()

    End Sub

    Private Sub LoadSelectedForm()
        Dim senderT As New Object
        Dim eT As New EventArgs
        If DefaultForm = 1 Then
            I_Borrower_Click(senderT, eT)
        ElseIf DefaultForm = 40 Then
            I_CreditApplication_Click(senderT, eT)
        ElseIf DefaultForm = 106 Then
            I_Investigation_Click(senderT, eT)
        ElseIf DefaultForm = 107 Then
            I_Booking_Click(senderT, eT)
        ElseIf DefaultForm = 108 Then
            I_Collection_Click(senderT, eT)
        ElseIf DefaultForm = 43 Then
            I_ROPA_Click(senderT, eT)
        ElseIf DefaultForm = 51 Then
            I_ITL_Click(senderT, eT)
        ElseIf DefaultForm = 2 Then
            I_BranchV2_Click(senderT, eT)
        ElseIf DefaultForm = 111 Then
            I_BusinessCenter_Click(senderT, eT)
        ElseIf DefaultForm = 116 Then
            I_SisterCompany_Click(senderT, eT)
        ElseIf DefaultForm = 117 Then
            I_SisterBranch_Click(senderT, eT)
        ElseIf DefaultForm = 3 Then
            I_Department_Click(senderT, eT)
        ElseIf DefaultForm = 4 Then
            I_Employee_Click(senderT, eT)
        ElseIf DefaultForm = 5 Then
            I_Position_Click(senderT, eT)
        ElseIf DefaultForm = 6 Then
            I_Country_Click(senderT, eT)
        ElseIf DefaultForm = 109 Then
            I_Region_Click(senderT, eT)
        ElseIf DefaultForm = 110 Then
            I_Province_Click(senderT, eT)
        ElseIf DefaultForm = 7 Then
            I_City_Click(senderT, eT)
        ElseIf DefaultForm = 44 Then
            I_Report_Click(senderT, eT)
        ElseIf DefaultForm = 46 Then
            I_Industry_Click(senderT, eT)
        ElseIf DefaultForm = 48 Then
            I_Make_Click(senderT, eT)
        ElseIf DefaultForm = 49 Then
            I_Type_Click(senderT, eT)
        ElseIf DefaultForm = 50 Then
            I_Model_Click(senderT, eT)
        ElseIf DefaultForm = 114 Then
            I_Classification_Click(senderT, eT)
        ElseIf DefaultForm = 72 Then
            I_Category_Click(senderT, eT)
        ElseIf DefaultForm = 73 Then
            I_Subcategory_Click(senderT, eT)
        ElseIf DefaultForm = 125 Then
            I_Walkin_Click(senderT, eT)
        ElseIf DefaultForm = 128 Then
            I_Insurance_Click(senderT, eT)
        ElseIf DefaultForm = 129 Then
            I_Remittance_Click(senderT, eT)
        ElseIf DefaultForm = 130 Then
            I_Remedial_Click(senderT, eT)
        ElseIf DefaultForm = 65 Then
            I_AccountType_Click(senderT, eT)
        ElseIf DefaultForm = 8 Then
            I_AccountClassification_Click(senderT, eT)
        ElseIf DefaultForm = 66 Then
            I_AccountGroup_Click(senderT, eT)
        ElseIf DefaultForm = 9 Then
            I_AccountChart_Click(senderT, eT)
        ElseIf DefaultForm = 10 Then
            I_Bank_Click(senderT, eT)
        ElseIf DefaultForm = 47 Then
            I_LedgerTransaction_Click(senderT, eT)
        ElseIf DefaultForm = 112 Then
            I_BatchMigration_Click(senderT, eT)
        ElseIf DefaultForm = 42 Then
            I_AdditionalCharges_Click(senderT, eT)
        ElseIf DefaultForm = 17 Then
            I_ProductSetup_Click(senderT, eT)
        ElseIf DefaultForm = 61 Then
            I_RequirementSetup_Click(senderT, eT)
        ElseIf DefaultForm = 140 Then
            I_SecuritySettings_Click(senderT, eT)
        ElseIf DefaultForm = 12 Then
            I_Users_Click(senderT, eT)
        ElseIf DefaultForm = 13 Then
            I_GroupRole_Click(senderT, eT)
        ElseIf DefaultForm = 14 Then
            I_Authorization_Click(senderT, eT)
        ElseIf DefaultForm = 81 Then
            I_Signatory_Click(senderT, eT)
        ElseIf DefaultForm = 139 Then
            I_SpecialAccess_Click(senderT, eT)
        ElseIf DefaultForm = 15 Then
            I_Individual_Click(senderT, eT)
        ElseIf DefaultForm = 15 Then
            I_Corporation_Click(senderT, eT)
        ElseIf DefaultForm = 16 Then
            I_BorrowerList_Click(senderT, eT)
        ElseIf DefaultForm = 62 Then
            I_BankV2_Click(senderT, eT)
        ElseIf DefaultForm = 45 Then
            I_AgentProfile_Click(senderT, eT)
        ElseIf DefaultForm = 57 Then
            I_DealerProfile_Click(senderT, eT)
        ElseIf DefaultForm = 100 Then
            I_HolidaySetup_Click(senderT, eT)
        ElseIf DefaultForm = 71 Then
            I_MigratedApplication_Click(senderT, eT)
        ElseIf DefaultForm = 18 Then
            I_CreditApplicationV2_Click(senderT, eT)
        ElseIf DefaultForm = 118 Then
            I_CreditReferral_Click(senderT, eT)
        ElseIf DefaultForm = 19 Then
            I_CreditInvestigation_Click(senderT, eT)
        ElseIf DefaultForm = 63 Then
            I_RequirementMonitoring_Click(senderT, eT)
        ElseIf DefaultForm = 20 Then
            I_PaymentRequest_Click(senderT, eT)
        ElseIf DefaultForm = 21 Then
            I_PaymentRelease_Click(senderT, eT)
        ElseIf DefaultForm = 67 Then
            I_Reinstatement_Click(senderT, eT)
        ElseIf DefaultForm = 115 Then
            I_WriteOff_Click(senderT, eT)
        ElseIf DefaultForm = 127 Then
            I_InsuranceV2_Click(senderT, eT)
        ElseIf DefaultForm = 99 Then
            I_OfficialReceipt_Click(senderT, eT)
        ElseIf DefaultForm = 22 Then
            I_CheckManagement_Click(senderT, eT)
        ElseIf DefaultForm = 93 Then
            I_Replenishment_Click(senderT, eT)
        ElseIf DefaultForm = 103 Then
            I_CollectionCount_Click(senderT, eT)
        ElseIf DefaultForm = 91 Then
            I_AccountingPeriod_Click(senderT, eT)
        ElseIf DefaultForm = 92 Then
            I_FinancialPlan_Click(senderT, eT)
        ElseIf DefaultForm = 113 Then
            I_TargetBookng_Click(senderT, eT)
        ElseIf DefaultForm = 23 Then
            I_AccountChartV2_Click(senderT, eT)
        ElseIf DefaultForm = 25 Then
            I_JournalVoucher_Click(senderT, eT)
        ElseIf DefaultForm = 80 Then
            I_CheckVoucher_Click(senderT, eT)
        ElseIf DefaultForm = 84 Then
            I_AcknowledgementReceipt_Click(senderT, eT)
        ElseIf DefaultForm = 89 Then
            I_AccountsPayable_Click(senderT, eT)
        ElseIf DefaultForm = 90 Then
            I_AccountsReceivable_Click(senderT, eT)
        ElseIf DefaultForm = 101 Then
            I_DueTo_Click(senderT, eT)
        ElseIf DefaultForm = 102 Then
            I_DueFrom_Click(senderT, eT)
        ElseIf DefaultForm = 105 Then
            I_LoansPayable_Click(senderT, eT)
        ElseIf DefaultForm = 98 Then
            I_PettyCashCount_Click(senderT, eT)
        ElseIf DefaultForm = 38 Then
            I_Vehicle_Click(senderT, eT)
        ElseIf DefaultForm = 39 Then
            I_RealEstate_Click(senderT, eT)
        ElseIf DefaultForm = 54 Then
            I_Appraisal_Click(senderT, eT)
        ElseIf DefaultForm = 55 Then
            I_Repricing_Click(senderT, eT)
        ElseIf DefaultForm = 58 Then
            I_ImpairmentSchedule_Click(senderT, eT)
        ElseIf DefaultForm = 74 Then
            I_CaseSetup_Click(senderT, eT)
        ElseIf DefaultForm = 75 Then
            I_CaseMonitoring_Click(senderT, eT)
        ElseIf DefaultForm = 76 Then
            I_CaseSummary_Click(senderT, eT)
        ElseIf DefaultForm = 88 Then
            I_CaseMapping_Click(senderT, eT)
        ElseIf DefaultForm = 87 Then
            I_CaseActivity_Click(senderT, eT)
        ElseIf DefaultForm = 77 Then
            I_Supplier_Click(senderT, eT)
        ElseIf DefaultForm = 78 Then
            I_CaseAdvance_Click(senderT, eT)
        ElseIf DefaultForm = 79 Then
            I_PettyCashV2_Click(senderT, eT)
        ElseIf DefaultForm = 85 Then
            I_LiquidationExp_Click(senderT, eT)
        ElseIf DefaultForm = 104 Then
            I_DocumentNumber_Click(senderT, eT)
        ElseIf DefaultForm = 26 Then
            I_AmortizationCalculator_Click(senderT, eT)
        ElseIf DefaultForm = 27 Then
            I_Logs_Click(senderT, eT)
        ElseIf DefaultForm = 29 Then
            I_GeneralLedger_Click(senderT, eT)
        ElseIf DefaultForm = 30 Then
            I_TrialBalance_Click(senderT, eT)
        ElseIf DefaultForm = 31 Then
            I_BalanceSheet_Click(senderT, eT)
        ElseIf DefaultForm = 94 Then
            I_IncomeStatement_Click(senderT, eT)
        ElseIf DefaultForm = 32 Then
            I_Aging_Click(senderT, eT)
        ElseIf DefaultForm = 95 Then
            I_CashReceipt_Click(senderT, eT)
        ElseIf DefaultForm = 96 Then
            I_CheckDisbursement_Click(senderT, eT)
        ElseIf DefaultForm = 97 Then
            I_GeneralJournal_Click(senderT, eT)
        ElseIf DefaultForm = 33 Then
            I_AccountsPayableV2_Click(senderT, eT)
        ElseIf DefaultForm = 34 Then
            I_SubsidiaryLedger_Click(senderT, eT)
        ElseIf DefaultForm = 35 Then
            I_BookingReport_Click(senderT, eT)
        ElseIf DefaultForm = 36 Then
            I_CollectionReport_Click(senderT, eT)
        ElseIf DefaultForm = 121 Then
            I_BookingCollection_Click(senderT, eT)
        ElseIf DefaultForm = 122 Then
            I_AccountsReceivableV2_Click(senderT, eT)
        ElseIf DefaultForm = 123 Then
            I_BooksAccount_Click(senderT, eT)
        ElseIf DefaultForm = 37 Then
            I_StatementOfAccount_Click(senderT, eT)
        ElseIf DefaultForm = 41 Then
            I_ReportV2_Click(senderT, eT)
        ElseIf DefaultForm = 56 Then
            I_ROPAAging_Click(senderT, eT)
        ElseIf DefaultForm = 131 Then
            I_ListingLoan_Click(senderT, eT)
        ElseIf DefaultForm = 132 Then
            I_CollectionDue_Click(senderT, eT)
        ElseIf DefaultForm = 133 Then
            I_DelinquencyReport_Click(senderT, eT)
        ElseIf DefaultForm = 134 Then
            I_PerformanceReport_Click(senderT, eT)
        ElseIf DefaultForm = 135 Then
            I_LoansReleases_Click(senderT, eT)
        ElseIf DefaultForm = 136 Then
            I_CollectionReportV2_Click(senderT, eT)
        ElseIf DefaultForm = 137 Then
            I_AgingPastdue_Click(senderT, eT)
        ElseIf DefaultForm = 138 Then
            I_PortfolioAtRisk_Click(senderT, eT)
        ElseIf DefaultForm = 59 Then
            I_Help_Click(senderT, eT)
        ElseIf DefaultForm = 141 Then
            I_CashFlow_Click(senderT, eT)
        ElseIf DefaultForm = 142 Then
            I_BankRecon_Click(senderT, eT)
        End If
    End Sub

    Private Sub BtnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        LoadSelectedForm()
    End Sub

    Private Sub BtnHomeSettings_Click(sender As Object, e As EventArgs) Handles btnHomeSettings.Click
        Dim DForm As New FrmDefaultForm
        With DForm
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnSendSMS_Click(sender As Object, e As EventArgs) Handles btnSendSMS.Click
        Dim SMS As New FrmSendFreeSMS
        With SMS
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub PictureEdit1_Click(sender As Object, e As MouseEventArgs) Handles PictureEdit1.Click
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Using OFD As New OpenFileDialog
                OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
                If (OFD.ShowDialog() = DialogResult.OK) Then
                    Try
                        PictureEdit1.Image = Image.FromFile(OFD.FileName)
                        SavePhoto(String.Format("UPDATE users_avatar SET picture = ?bin_data WHERE ID = '{0}' AND user_code = '{1}'", User_ID, User_Code), OFD.FileName)
                        Logs("Main", "PictureEdit", "Update avatar picture", "", "", "", "")
                        MsgBox("Avatar Successfully Updated!", MsgBoxStyle.Information, "Info")
                    Catch ex As Exception
                        MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                    End Try
                End If
            End Using
        End If
    End Sub

    '*** Form Clicks
    'Dashboard
    Private Sub I_Admin_Click(sender As Object, e As EventArgs) Handles I_Admin.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAdminDashboard
            .Tag = 1
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAdminDashboard) = False Then
            Logs("Main", "Open", "Admin Dashboard", "", "", "", "")
        End If
        Forms(FrmAdminDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Borrower_Click(sender As Object, e As EventArgs) Handles I_Borrower.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBorrowerDashboard
            .Tag = 145
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBorrowerDashboard) = False Then
            Logs("Main", "Open", "Borrowers Dashboard", "", "", "", "")
        End If
        Forms(FrmBorrowerDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CreditApplication_Click(sender As Object, e As EventArgs) Handles I_CreditApplication.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCreditDashboard
            .Tag = 40
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCreditDashboard) = False Then
            Logs("Main", "Open", "Credit Dashboard", "", "", "", "")
        End If
        Forms(FrmCreditDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Investigation_Click(sender As Object, e As EventArgs) Handles I_Investigation.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCreditInvestigationDashboard
            .Tag = 106
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCreditInvestigationDashboard) = False Then
            Logs("Main", "Open", "Credit Investigation Dashboard", "", "", "", "")
        End If
        Forms(FrmCreditInvestigationDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Booking_Click(sender As Object, e As EventArgs) Handles I_Booking.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBookingDashboard
            .Tag = 107
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBookingDashboard) = False Then
            Logs("Main", "Open", "Booking Dashboard", "", "", "", "")
        End If
        Forms(FrmBookingDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Collection_Click(sender As Object, e As EventArgs) Handles I_Collection.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCollectionDashboard
            .Tag = 108
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCollectionDashboard) = False Then
            Logs("Main", "Open", "Collection Dashboard", "", "", "", "")
        End If
        Forms(FrmCollectionDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Finance_Click(sender As Object, e As EventArgs) Handles I_Finance.Click

    End Sub

    Private Sub I_Branch_Click(sender As Object, e As EventArgs) Handles I_Branch.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBranchDashboard
            .Tag = 146
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBranchDashboard) = False Then
            Logs("Main", "Open", "Branch Dashboard", "", "", "", "")
        End If
        Forms(FrmBranchDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_ROPA_Click(sender As Object, e As EventArgs) Handles I_ROPA.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAssetDashboard
            .Tag = 43
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAssetDashboard) = False Then
            Logs("Main", "Open", "Asset Dashboard", "", "", "", "")
        End If
        Forms(FrmAssetDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_ITL_Click(sender As Object, e As EventArgs) Handles I_ITL.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmITLDashboard
            .Tag = 51
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmITLDashboard) = False Then
            Logs("Main", "Open", "ITL Dashboard", "", "", "", "")
        End If
        Forms(FrmITLDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_PettyCash_Click(sender As Object, e As EventArgs) Handles I_PettyCash.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmPettyCashDashboard
            .Tag = 143
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmPettyCashDashboard) = False Then
            Logs("Main", "Open", "Petty Cash Dashboard", "", "", "", "")
        End If
        Forms(FrmPettyCashDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CashAdvance_Click(sender As Object, e As EventArgs) Handles I_CashAdvance.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCashAdvanceDashboard
            .Tag = 144
            FormRestriction(.Tag)
            If allow_Access Then
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCashAdvanceDashboard) = False Then
            Logs("Main", "Open", "Cash Advance Dashboard", "", "", "", "")
        End If
        Forms(FrmCashAdvanceDashboard, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    'Administrator
    '**General
    Private Sub I_BranchV2_Click(sender As Object, e As EventArgs) Handles I_BranchV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBranch
            .Tag = 2
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBranch) = False Then
            Logs("Main", "Open", "Branch Setup", "", "", "", "")
        End If
        Forms(FrmBranch, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_BusinessCenter_Click(sender As Object, e As EventArgs) Handles I_BusinessCenter.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBusinesCenter
            .Tag = 111
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBusinesCenter) = False Then
            Logs("Main", "Open", "Business Center Setup", "", "", "", "")
        End If
        Forms(FrmBusinesCenter, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_SisterCompany_Click(sender As Object, e As EventArgs) Handles I_SisterCompany.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmSisterCompany
            .Tag = 116
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmSisterCompany) = False Then
            Logs("Main", "Open", "Sister Company Setup", "", "", "", "")
        End If
        Forms(FrmSisterCompany, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_SisterBranch_Click(sender As Object, e As EventArgs) Handles I_SisterBranch.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmSisterCompanyBranch
            .Tag = 117
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmSisterCompanyBranch) = False Then
            Logs("Main", "Open", "Sister Company Branch Setup", "", "", "", "")
        End If
        Forms(FrmSisterCompanyBranch, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Department_Click(sender As Object, e As EventArgs) Handles I_Department.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmDepartment
            .Tag = 3
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmDepartment) = False Then
            Logs("Main", "Open", "Department Setup", "", "", "", "")
        End If
        Forms(FrmDepartment, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Employee_Click(sender As Object, e As EventArgs) Handles I_Employee.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmEmployee
            .Tag = 4
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmEmployee) = False Then
            Logs("Main", "Open", "Employee Setup", "", "", "", "")
        End If
        Forms(FrmEmployee, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Position_Click(sender As Object, e As EventArgs) Handles I_Position.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmPosition
            .Tag = 5
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmPosition) = False Then
            Logs("Main", "Open", "Position Setup", "", "", "", "")
        End If
        Forms(FrmPosition, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Country_Click(sender As Object, e As EventArgs) Handles I_Country.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCountry
            .Tag = 6
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCountry) = False Then
            Logs("Main", "Open", "Country Setup", "", "", "", "")
        End If
        Forms(FrmCountry, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Region_Click(sender As Object, e As EventArgs) Handles I_Region.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmRegionSetup
            .Tag = 109
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmRegionSetup) = False Then
            Logs("Main", "Open", "Region Setup", "", "", "", "")
        End If
        Forms(FrmRegionSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Province_Click(sender As Object, e As EventArgs) Handles I_Province.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmProvinceSetup
            .Tag = 110
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmProvinceSetup) = False Then
            Logs("Main", "Open", "Province Setup", "", "", "", "")
        End If
        Forms(FrmProvinceSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_City_Click(sender As Object, e As EventArgs) Handles I_City.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCitySetup
            .Tag = 7
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCitySetup) = False Then
            Logs("Main", "Open", "City Setup", "", "", "", "")
        End If
        Forms(FrmCitySetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Report_Click(sender As Object, e As EventArgs) Handles I_Report.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmReportQuery
            .Tag = 44
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmReportQuery) = False Then
            Logs("Main", "Open", "Report Setup", "", "", "", "")
        End If
        Forms(FrmReportQuery, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Report2_Click(sender As Object, e As EventArgs) Handles I_Report2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmReportSetup
            .Tag = 44
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmReportSetup) = False Then
            Logs("Main", "Open", "Report Setup", "", "", "", "")
        End If
        Forms(FrmReportSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Industry_Click(sender As Object, e As EventArgs) Handles I_Industry.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmIndustry
            .Tag = 46
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmIndustry) = False Then
            Logs("Main", "Open", "Industry Setup", "", "", "", "")
        End If
        Forms(FrmIndustry, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Make_Click(sender As Object, e As EventArgs) Handles I_Make.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmVEMake
            .Tag = 48
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmVEMake) = False Then
            Logs("Main", "Open", "VE Make Setup", "", "", "", "")
        End If
        Forms(FrmVEMake, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Type_Click(sender As Object, e As EventArgs) Handles I_Type.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmVEType
            .Tag = 49
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmVEType) = False Then
            Logs("Main", "Open", "VE Type Setup", "", "", "", "")
        End If
        Forms(FrmVEType, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Model_Click(sender As Object, e As EventArgs) Handles I_Model.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmVEModel
            .Tag = 50
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmVEModel) = False Then
            Logs("Main", "Open", "VE Model Setup", "", "", "", "")
        End If
        Forms(FrmVEModel, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Classification_Click(sender As Object, e As EventArgs) Handles I_Classification.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmREClassification
            .Tag = 114
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmREClassification) = False Then
            Logs("Main", "Open", "RE Classification", "", "", "", "")
        End If
        Forms(FrmREClassification, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Category_Click(sender As Object, e As EventArgs) Handles I_Category.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCaseCategory
            .Tag = 72
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCaseCategory) = False Then
            Logs("Main", "Open", "Category Setup", "", "", "", "")
        End If
        Forms(FrmCaseCategory, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Subcategory_Click(sender As Object, e As EventArgs) Handles I_Subcategory.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCaseSubcategory
            .Tag = 73
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCaseSubcategory) = False Then
            Logs("Main", "Open", "Sub Category Setup", "", "", "", "")
        End If
        Forms(FrmCaseSubcategory, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Walkin_Click(sender As Object, e As EventArgs) Handles I_Walkin.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmWalkinSetup
            .Tag = 125
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmWalkinSetup) = False Then
            Logs("Main", "Open", "Walk In Setup", "", "", "", "")
        End If
        Forms(FrmWalkinSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Insurance_Click(sender As Object, e As EventArgs) Handles I_Insurance.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmInsuranceProvider
            .Tag = 128
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmInsuranceProvider) = False Then
            Logs("Main", "Open", "Insurance Provider Setup", "", "", "", "")
        End If
        Forms(FrmInsuranceProvider, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Remittance_Click(sender As Object, e As EventArgs) Handles I_Remittance.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmRemittanceCenter
            .Tag = 129
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmRemittanceCenter) = False Then
            Logs("Main", "Open", "Remittance Center Setup", "", "", "", "")
        End If
        Forms(FrmRemittanceCenter, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Remedial_Click(sender As Object, e As EventArgs) Handles I_Remedial.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmRemedialSetup
            .Tag = 130
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmRemedialSetup) = False Then
            Logs("Main", "Open", "Remedial Setup", "", "", "", "")
        End If
        Forms(FrmRemedialSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    '**Accounting
    Private Sub I_AccountType_Click(sender As Object, e As EventArgs) Handles I_AccountType.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAccountType
            .Tag = 65
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAccountType) = False Then
            Logs("Main", "Open", "Account Type", "", "", "", "")
        End If
        Forms(FrmAccountType, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AccountClassification_Click(sender As Object, e As EventArgs) Handles I_AccountClassification.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAccountClassification
            .Tag = 8
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAccountClassification) = False Then
            Logs("Main", "Open", "Account Classification", "", "", "", "")
        End If
        Forms(FrmAccountClassification, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AccountGroup_Click(sender As Object, e As EventArgs) Handles I_AccountGroup.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAccountGroup
            .Tag = 66
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAccountGroup) = False Then
            Logs("Main", "Open", "Account Group", "", "", "", "")
        End If
        Forms(FrmAccountGroup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AccountChart_Click(sender As Object, e As EventArgs) Handles I_AccountChart.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmChartOfAccounts
            .Tag = 9
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmChartOfAccounts) = False Then
            Logs("Main", "Open", "Chart of Accounts", "", "", "", "")
        End If
        Forms(FrmChartOfAccounts, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Bank_Click(sender As Object, e As EventArgs) Handles I_Bank.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBank
            .Tag = 10
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBank) = False Then
            Logs("Main", "Open", "Bank Setup", "", "", "", "")
        End If
        Forms(FrmBank, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_LedgerTransaction_Click(sender As Object, e As EventArgs) Handles I_LedgerTransaction.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmLedgerTransaction
            .Tag = 47
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmLedgerTransaction) = False Then
        Else
            Logs("Main", "Open", "Ledger Transaction Setup", "", "", "", "")
        End If
        Forms(FrmLedgerTransaction, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    '**Loans
    Private Sub I_BatchMigration_Click(sender As Object, e As EventArgs) Handles I_BatchMigration.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBulkMigrationv2
            .Tag = 112
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBulkMigrationv2) = False Then
            Logs("Main", "Open", "Bulk Migration", "", "", "", "")
        End If
        Forms(FrmBulkMigrationv2, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AdditionalCharges_Click(sender As Object, e As EventArgs) Handles I_AdditionalCharges.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmProcessingSetup
            .Tag = 42
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmProcessingSetup) = False Then
            Logs("Main", "Open", "Processing Fee", "", "", "", "")
        End If
        Forms(FrmProcessingSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_ProductSetup_Click(sender As Object, e As EventArgs) Handles I_ProductSetup.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmProductSetup
            .Tag = 17
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmProductSetup) = False Then
            Logs("Main", "Open", "Product Setup", "", "", "", "")
        End If
        Forms(FrmProductSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_RequirementSetup_Click(sender As Object, e As EventArgs) Handles I_RequirementSetup.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmRequirementSetup
            .Tag = 61
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmRequirementSetup) = False Then
            Logs("Main", "Open", "Requirement Setup", "", "", "", "")
        End If
        Forms(FrmRequirementSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    '**Security
    Private Sub I_SecuritySettings_Click(sender As Object, e As EventArgs) Handles I_SecuritySettings.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmPasswordSettings
            .Tag = 140
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmPasswordSettings) = False Then
            Logs("Main", "Open", "Password Settings", "", "", "", "")
        End If
        Forms(FrmPasswordSettings, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Users_Click(sender As Object, e As EventArgs) Handles I_Users.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmUser
            .Tag = 12
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmUser) = False Then
            Logs("Main", "Open", "User Setup", "", "", "", "")
        End If
        Forms(FrmUser, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_GroupRole_Click(sender As Object, e As EventArgs) Handles I_GroupRole.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmGroupRole
            .Tag = 13
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmGroupRole) = False Then
            Logs("Main", "Open", "Group Role Setup", "", "", "", "")
        End If
        Forms(FrmGroupRole, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Authorization_Click(sender As Object, e As EventArgs) Handles I_Authorization.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAuthorization
            .Tag = 14
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAuthorization) = False Then
            Logs("Main", "Open", "Authorization Setup", "", "", "", "")
        End If
        Forms(FrmAuthorization, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Signatory_Click(sender As Object, e As EventArgs) Handles I_Signatory.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmSignatorySetup
            .Tag = 81
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmSignatorySetup) = False Then
            Logs("Main", "Open", "Signatory Setup", "", "", "", "")
        End If
        Forms(FrmSignatorySetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_SpecialAccess_Click(sender As Object, e As EventArgs) Handles I_SpecialAccess.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmSpecialAccess
            .Tag = 139
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmSpecialAccess) = False Then
            Logs("Main", "Open", "Special Access", "", "", "", "")
        End If
        Forms(FrmSpecialAccess, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    'Borrowers
    Private Sub I_Individual_Click(sender As Object, e As EventArgs) Handles I_Individual.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBorrower
            .Tag = 15
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBorrower) = False Then
            Logs("Main", "Open", "Individual Borrower", "", "", "", "")
        End If
        Forms(FrmBorrower, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Corporation_Click(sender As Object, e As EventArgs) Handles I_Corporation.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBorrowerCorp
            .Tag = 15
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBorrower) = False Then
            Logs("Main", "Open", "Corporate Borrower", "", "", "", "")
        End If
        Forms(FrmBorrowerCorp, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_BorrowerList_Click(sender As Object, e As EventArgs) Handles I_BorrowerList.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBorrowerList
            .Tag = 16
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBorrowerList) = False Then
            Logs("Main", "Open", "Borrower List", "", "", "", "")
        End If
        Forms(FrmBorrowerList, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    'Credit Application
    Private Sub I_BankV2_Click(sender As Object, e As EventArgs) Handles I_BankV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBankSetup
            .Tag = 62
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBankSetup) = False Then
            Logs("Main", "Open", "Branch Bank", "", "", "", "")
        End If
        Forms(FrmBankSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AgentProfile_Click(sender As Object, e As EventArgs) Handles I_AgentProfile.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAgentProfile
            .Tag = 45
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAgentProfile) = False Then
            Logs("Main", "Open", "Agent Profile", "", "", "", "")
        End If
        Forms(FrmAgentProfile, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_DealerProfile_Click(sender As Object, e As EventArgs) Handles I_DealerProfile.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmDealerSetup
            .Tag = 57
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmDealerSetup) = False Then
            Logs("Main", "Open", "Dealer Profile", "", "", "", "")
        End If
        Forms(FrmDealerSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_HolidaySetup_Click(sender As Object, e As EventArgs) Handles I_HolidaySetup.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmHolidaySetup
            .Tag = 100
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmHolidaySetup) = False Then
            Logs("Main", "Open", "Holiday Setup", "", "", "", "")
        End If
        Forms(FrmHolidaySetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_MigratedApplication_Click(sender As Object, e As EventArgs) Handles I_MigratedApplication.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmMigratedApplication
            .Tag = 71
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmMigratedApplication) = False Then
            Logs("Main", "Open", "Migrated Application", "", "", "", "")
        End If
        Forms(FrmMigratedApplication, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CreditApplicationV2_Click(sender As Object, e As EventArgs) Handles I_CreditApplicationV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmLoanApplication
            .Tag = 18
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If PanelControl3.Controls.Contains(FrmLoanApplication) = False Then
                Logs("Main", "Open", "Loan Application", "", "", "", "")
            End If
            .lblTitle.Text = "CREDIT APPLICATION"
            .tabBorrower.Visible = True
            .tabFinancial_1.Visible = True
            .tabFinancial_2.Visible = True
            .tabRequirements.Visible = True
            .tabList.Visible = True
            .btnBack.Visible = True
            .btnNext.Visible = True
            .btnSave.Visible = True
            .btnRefresh.Visible = True
            .btnAttach.Visible = True
            .btnSave_F.Visible = True
            .btnModify.Visible = True
            .btnDelete.Visible = True
            .btnApprove.Visible = True
            .cbxBill.Visible = True
            .LabelX100.Location = New Point(542, 457)
            .dNetProceeds_C.Location = New Point(799, 457)
            .btnBack.Location = New Point(2, 4)
            .btnNext.Location = New Point(88, 4)
            .btnSave.Location = New Point(174, 4)
            .btnSave_F.Location = New Point(260, 4)
            .btnRefresh.Location = New Point(346, 4)
            .btnCancel.Location = New Point(432, 4)
            .btnModify.Location = New Point(518, 4)
            .btnDelete.Location = New Point(604, 4)
            .btnAttach.Location = New Point(690, 4)
            .btnPrint.Location = New Point(776, 4)
            .btnPrint_II.Location = New Point(862, 4)
            .btnEarly.Location = New Point(958, 4)
            .btnApprove.Location = New Point(1054, 4)
        End With
        Forms(FrmLoanApplication, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CreditReferral_Click(sender As Object, e As EventArgs) Handles I_CreditReferral.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCreditReferralSlip
            .Tag = 118
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCreditReferralSlip) = False Then
            Logs("Main", "Open", "Credit Referral Slip", "", "", "", "")
        End If
        Forms(FrmCreditReferralSlip, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CreditInvestigation_Click(sender As Object, e As EventArgs) Handles I_CreditInvestigation.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCreditInvestigation
            .Tag = 19
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCreditInvestigation) = False Then
            Logs("Main", "Open", "Credit Investigation", "", "", "", "")
        End If
        Forms(FrmCreditInvestigation, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_RequirementMonitoring_Click(sender As Object, e As EventArgs) Handles I_RequirementMonitoring.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmRequirementsMonitoring
            .Tag = 63
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmRequirementsMonitoring) = False Then
            Logs("Main", "Open", "Requirements Monitoring", "", "", "", "")
        End If
        Forms(FrmRequirementsMonitoring, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_PaymentRequest_Click(sender As Object, e As EventArgs) Handles I_PaymentRequest.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmPaymentRequest
            .Tag = 20
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmPaymentRequest) = False Then
            Logs("Main", "Open", "Payment Request", "", "", "", "")
        End If
        Forms(FrmPaymentRequest, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_PaymentRelease_Click(sender As Object, e As EventArgs) Handles I_PaymentRelease.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmPaymentRelease
            .Tag = 21
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmPaymentRelease) = False Then
            Logs("Main", "Open", "Payment Release", "", "", "", "")
        End If
        Forms(FrmPaymentRelease, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Encumbered_Click(sender As Object, e As EventArgs) Handles I_Encumbered.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmEncumbered
            .Tag = 146
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmEncumbered) = False Then
            Logs("Main", "Open", "Encumbered/Annotation", "", "", "", "")
        End If
        Forms(FrmEncumbered, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Reinstatement_Click(sender As Object, e As EventArgs) Handles I_Reinstatement.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmReinstatement
            .Tag = 67
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmReinstatement) = False Then
            Logs("Main", "Open", "ReInstatement", "", "", "", "")
        End If
        Forms(FrmReinstatement, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_WriteOff_Click(sender As Object, e As EventArgs) Handles I_WriteOff.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        MsgBox("Write Off is not yet available, waiting for possible changes.", MsgBoxStyle.Information, "Info")
        Exit Sub
        Cursor = Cursors.WaitCursor
        With FrmWriteOff
            .Tag = 115
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmWriteOff) = False Then
            Logs("Main", "Open", "Write Off", "", "", "", "")
        End If
        Forms(FrmWriteOff, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_InsuranceV2_Click(sender As Object, e As EventArgs) Handles I_InsuranceV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmInsuranceMonitoring
            .Tag = 127
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmInsuranceMonitoring) = False Then
            Logs("Main", "Open", "Insurance Monitoring", "", "", "", "")
        End If
        Forms(FrmInsuranceMonitoring, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    'Cashiering
    Private Sub I_OfficialReceipt_Click(sender As Object, e As EventArgs) Handles I_OfficialReceipt.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmOfficialReceipt
            .Tag = 99
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmOfficialReceipt) = False Then
            Logs("Main", "Open", "Official Receipt", "", "", "", "")
        End If
        Forms(FrmOfficialReceipt, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CheckManagement_Click(sender As Object, e As EventArgs) Handles I_CheckManagement.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmPDCManagement
            .Tag = 22
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmPDCManagement) = False Then
            Logs("Main", "Open", "PDC Management", "", "", "", "")
        End If
        Forms(FrmPDCManagement, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Replenishment_Click(sender As Object, e As EventArgs) Handles I_Replenishment.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmReplenishement
            .Tag = 93
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmReplenishement) = False Then
            Logs("Main", "Open", "Replenishment", "", "", "", "")
        End If
        Forms(FrmReplenishement, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CollectionCount_Click(sender As Object, e As EventArgs) Handles I_CollectionCount.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCollectionCashCount
            .Tag = 103
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCollectionCashCount) = False Then
            Logs("Main", "Open", "Collection Cash Count", "", "", "", "")
        End If
        Forms(FrmCollectionCashCount, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    'Financials
    Private Sub I_AccountingPeriod_Click(sender As Object, e As EventArgs) Handles I_AccountingPeriod.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAccountingPeriod
            .Tag = 91
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAccountingPeriod) = False Then
            Logs("Main", "Open", "Accounting Entry", "", "", "", "")
        End If
        Forms(FrmAccountingPeriod, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_FinancialPlan_Click(sender As Object, e As EventArgs) Handles I_FinancialPlan.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmFinancialPlan
            .Tag = 92
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmFinancialPlan) = False Then
            Logs("Main", "Open", "Financial Plan", "", "", "", "")
        End If
        Forms(FrmFinancialPlan, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_TargetBookng_Click(sender As Object, e As EventArgs) Handles I_TargetBookng.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmTargetBooking
            .Tag = 113
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmTargetBooking) = False Then
            Logs("Main", "Open", "Target Booking", "", "", "", "")
        End If
        Forms(FrmTargetBooking, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AccountChartV2_Click(sender As Object, e As EventArgs) Handles I_AccountChartV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmChartOfAccounts
            .Tag = 23
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmChartOfAccounts) = False Then
            Logs("Main", "Open", "Chart of Accounts", "", "", "", "")
        End If
        Forms(FrmChartOfAccounts, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_JournalVoucher_Click(sender As Object, e As EventArgs) Handles I_JournalVoucher.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmJournalVoucher
            .Tag = 25
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmJournalVoucher) = False Then
            Logs("Main", "Open", "Journal Voucher", "", "", "", "")
        End If
        Forms(FrmJournalVoucher, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CheckVoucher_Click(sender As Object, e As EventArgs) Handles I_CheckVoucher.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCheckVoucher
            .Tag = 80
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCheckVoucher) = False Then
            Logs("Main", "Open", "Check Voucher", "", "", "", "")
        End If
        Forms(FrmCheckVoucher, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AcknowledgementReceipt_Click(sender As Object, e As EventArgs) Handles I_AcknowledgementReceipt.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAcknowledgement
            .Tag = 84
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAcknowledgement) = False Then
            Logs("Main", "Open", "Acknowledgement Receipt", "", "", "", "")
        End If
        Forms(FrmAcknowledgement, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AccountsPayable_Click(sender As Object, e As EventArgs) Handles I_AccountsPayable.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAccountsPayable
            .Tag = 89
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAccountsPayable) = False Then
            Logs("Main", "Open", "Accounts Payable", "", "", "", "")
        End If
        Forms(FrmAccountsPayable, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AccountsReceivable_Click(sender As Object, e As EventArgs) Handles I_AccountsReceivable.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAccountsReceivable
            .Tag = 90
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAccountsReceivable) = False Then
            Logs("Main", "Open", "Accounts Receivable", "", "", "", "")
        End If
        Forms(FrmAccountsReceivable, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_DueTo_Click(sender As Object, e As EventArgs) Handles I_DueTo.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmDueTo
            .Tag = 101
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmDueTo) = False Then
            Logs("Main", "Open", "Due To", "", "", "", "")
        End If
        Forms(FrmDueTo, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_DueFrom_Click(sender As Object, e As EventArgs) Handles I_DueFrom.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmDueFrom
            .Tag = 102
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmDueFrom) = False Then
            Logs("Main", "Open", "Due From", "", "", "", "")
        End If
        Forms(FrmDueFrom, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_LoansPayable_Click(sender As Object, e As EventArgs) Handles I_LoansPayable.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmLoansPayable
            .Tag = 105
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmLoansPayable) = False Then
            Logs("Main", "Open", "Loans Payable", "", "", "", "")
        End If
        Forms(FrmLoansPayable, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_PettyCashCount_Click(sender As Object, e As EventArgs) Handles I_PettyCashCount.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCashCount
            .Tag = 98
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCashCount) = False Then
            Logs("Main", "Open", "Cash Count", "", "", "", "")
        End If
        Forms(FrmCashCount, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    'Asset Management
    Private Sub I_Vehicle_Click(sender As Object, e As EventArgs) Handles I_Vehicle.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmVehicleROPOA
            .Tag = 38
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmVehicleROPOA) = False Then
            Logs("Main", "Open", "Vehicle ROPOA", "", "", "", "")
        End If
        Forms(FrmVehicleROPOA, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_RealEstate_Click(sender As Object, e As EventArgs) Handles I_RealEstate.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmRealEstateROPOA
            .Tag = 39
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmRealEstateROPOA) = False Then
            Logs("Main", "Open", "Real Estate ROPOA", "", "", "", "")
        End If
        Forms(FrmRealEstateROPOA, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Appraisal_Click(sender As Object, e As EventArgs) Handles I_Appraisal.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAppraisalManagement
            .Tag = 54
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAppraisalManagement) = False Then
            Logs("Main", "Open", "Appraisal Management", "", "", "", "")
        End If
        Forms(FrmAppraisalManagement, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Repricing_Click(sender As Object, e As EventArgs) Handles I_Repricing.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmRepricingManagement
            .Tag = 55
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmRepricingManagement) = False Then
            Logs("Main", "Open", "Repricing Management", "", "", "", "")
        End If
        Forms(FrmRepricingManagement, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_ImpairmentSchedule_Click(sender As Object, e As EventArgs) Handles I_ImpairmentSchedule.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmImpairmentManagement
            .Tag = 58
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmImpairmentManagement) = False Then
            Logs("Main", "Open", "Impairment Schedule", "", "", "", "")
        End If
        Forms(FrmImpairmentManagement, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    'Items In Litigation
    Private Sub I_CaseSetup_Click(sender As Object, e As EventArgs) Handles I_CaseSetup.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCaseSetup
            .Tag = 74
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCaseSetup) = False Then
            Logs("Main", "Open", "Case Setup", "", "", "", "")
        End If
        Forms(FrmCaseSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CaseMonitoring_Click(sender As Object, e As EventArgs) Handles I_CaseMonitoring.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCaseMonitoring
            .Tag = 75
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCaseMonitoring) = False Then
            Logs("Main", "Open", "Case Monitoring", "", "", "", "")
        End If
        Forms(FrmCaseMonitoring, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CaseSummary_Click(sender As Object, e As EventArgs) Handles I_CaseSummary.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCaseSummaryN
            .Tag = 76
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCaseSummaryN) = False Then
            Logs("Main", "Open", "Case Setup", "", "", "", "")
        End If
        Forms(FrmCaseSummaryN, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CaseMapping_Click(sender As Object, e As EventArgs) Handles I_CaseMapping.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCaseMapping
            .Tag = 88
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCaseMapping) = False Then
            Logs("Main", "Open", "Case Mapping", "", "", "", "")
        End If
        Forms(FrmCaseMapping, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CaseActivity_Click(sender As Object, e As EventArgs) Handles I_CaseActivity.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCaseActivity
            .Tag = 87
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCaseActivity) = False Then
            Logs("Main", "Open", "Case Activity", "", "", "", "")
        End If
        Forms(FrmCaseActivity, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    'Non Loans Related
    Private Sub I_Supplier_Click(sender As Object, e As EventArgs) Handles I_Supplier.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmSupplier
            .Tag = 77
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmSupplier) = False Then
            Logs("Main", "Open", "Supplier Setup", "", "", "", "")
        End If
        Forms(FrmSupplier, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CaseAdvance_Click(sender As Object, e As EventArgs) Handles I_CaseAdvance.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCashAdvanceSlip
            .Tag = 78
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCashAdvanceSlip) = False Then
            Logs("Main", "Open", "Cash Advance Slip", "", "", "", "")
        End If
        Forms(FrmCashAdvanceSlip, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_PettyCashV2_Click(sender As Object, e As EventArgs) Handles I_PettyCashV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmPettyCashVoucher
            .Tag = 79
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmPettyCashVoucher) = False Then
            Logs("Main", "Open", "Petty Cash Setup", "", "", "", "")
        End If
        Forms(FrmPettyCashVoucher, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_LiquidationExp_Click(sender As Object, e As EventArgs) Handles I_LiquidationExp.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmLiquidation
            .Tag = 85
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmLiquidation) = False Then
            Logs("Main", "Open", "Liquidation of Expenses", "", "", "", "")
        End If
        Forms(FrmLiquidation, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_DocumentNumber_Click(sender As Object, e As EventArgs) Handles I_DocumentNumber.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmDocumentNumber
            .Tag = 104
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmDocumentNumber) = False Then
            Logs("Main", "Open", "Document Number", "", "", "", "")
        End If
        Forms(FrmDocumentNumber, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    'Utilities
    Private Sub I_AmortizationCalculator_Click(sender As Object, e As EventArgs) Handles I_AmortizationCalculator.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmLoanApplication
            .Tag = 26
            FormRestriction(.Tag)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
                .vCheck = allow_Check
                .vApprove = allow_Approve
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            If PanelControl3.Controls.Contains(FrmLoanApplication) = False Then
                Logs("Main", "Open", "Amortization Calculators", "", "", "", "")
            End If
            .lblTitle.Text = "AMORTIZATION CALCULATOR"
            .tabBorrower.Visible = False
            .tabFinancial_1.Visible = False
            .tabFinancial_2.Visible = False
            .tabRequirements.Visible = False
            .tabList.Visible = False
            .btnBack.Visible = False
            .btnNext.Visible = False
            .btnSave.Visible = False
            .btnRefresh.Visible = False
            .btnAttach.Visible = False
            .btnSave_F.Visible = False
            .btnDelete.Visible = False
            .btnModify.Visible = False
            .btnApprove.Visible = False
            .cbxBill.Visible = False
            .LabelX100.Location = New Point(542, 457 - 23)
            .dNetProceeds_C.Location = New Point(799, 457 - 23)
            .btnCancel.Location = New Point(6, 4)
            .btnPrint.Location = New Point(100, 4)
            .btnPrint_II.Location = New Point(194, 4)
            .btnEarly.Location = New Point(297, 4)
        End With
        Forms(FrmLoanApplication, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Logs_Click(sender As Object, e As EventArgs) Handles I_Logs.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmTransactionLogs
            .Tag = 27
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmTransactionLogs) = False Then
            Logs("Main", "Open", "Audit Trail Log", "", "", "", "")
        End If
        Forms(FrmTransactionLogs, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AlertNotification_Click(sender As Object, e As EventArgs) Handles I_AlertNotification.Click
        If MsgBox("Are you sure you want to open the alert notification?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Dim Alert As New FrmAlertLoanApplication
            With Alert
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub I_Rule78_Click(sender As Object, e As EventArgs) Handles I_Rule78.Click
        With FrmRule78
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub I_Calculator_Click(sender As Object, e As EventArgs) Handles I_Calculator.Click
        BtnCalculator_Click(sender, e)
    End Sub

    Private Sub I_Notepad_Click(sender As Object, e As EventArgs) Handles I_Notepad.Click
        BtnNote_Click(sender, e)
    End Sub

    Private Sub I_Ping_Click(sender As Object, e As EventArgs) Handles I_Ping.Click
        BtnPing_Click(sender, e)
    End Sub

    Private Sub I_Skin_Click(sender As Object, e As EventArgs) Handles I_Skin.Click
        If I_Skin.Enabled Then
            BtnSkin_Click(sender, e)
        End If
    End Sub

    Private Sub I_Timer_Click(sender As Object, e As EventArgs) Handles I_Timer.Click
        BtnTimer_Click(sender, e)
    End Sub

    Private Sub I_EmailCredential_Click(sender As Object, e As EventArgs) Handles I_EmailCredential.Click
        BtnEmail_Click(sender, e)
    End Sub

    Private Sub I_SystemSettings_Click(sender As Object, e As EventArgs) Handles I_SystemSettings.Click
        If I_SystemSettings.Enabled Then
            BtnSystemSettings_Click(sender, e)
        End If
    End Sub

    Private Sub I_CheckVersion_Click(sender As Object, e As EventArgs) Handles I_CheckVersion.Click
        CheckVersion()
    End Sub

    Private Sub CheckVersion()
        CurrentVersion = DataObject(String.Format("SELECT system_version FROM version_setup WHERE `status` = 'ACTIVE';"))
        If Application.ProductVersion = CurrentVersion Or Application.ProductVersion > CurrentVersion Then
            MsgBox("Your version is up to date.", MsgBoxStyle.Information, "Info")
        Else
            I_CheckVersion.Appearance.Normal.ForeColor = Color.Red
            If MsgBoxYes(String.Format("Your using a version {0} from the official version release {1}, would you like to log off to refresh your system version?", Application.ProductVersion, CurrentVersion)) = MsgBoxResult.Yes Then
                FrmLogin.ExitWindowsEx(FrmLogin.EWX_LogOff, 0&)
            End If
        End If
    End Sub

    Private Sub I_ClearCache_Click(sender As Object, e As EventArgs) Handles I_ClearCache.Click
        If MsgBoxYes("Are you sure you want to clear cache?") = MsgBoxResult.Yes Then
            Dim TotalSize As Double
            Dim TotalFile As Integer
            Dim DT_File As DataTable = DataSource(String.Format("SELECT Attachment_1, Attachment_2, Attachment_3, Attachment_4, Attachment_5, Attachment_6, Attachment_7, Attachment_8, Attachment_9, Attachment_10 FROM email_outbox WHERE EmplID = '{0}' AND `status` = 'SENT';", Empl_ID))
            If DT_File.Rows.Count > 0 Then
                For x As Integer = 0 To DT_File.Rows.Count - 1
                    If DT_File(x)("Attachment_1") = "" Then
                    Else
                        If FileExists(DT_File(x)("Attachment_1")) Then
                            Try
                                TotalSize += My.Computer.FileSystem.GetFileInfo(DT_File(x)("Attachment_1")).Length
                                TotalFile += 1
                                IO.File.Delete(DT_File(x)("Attachment_1"))
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
                                IO.File.Delete(DT_File(x)("Attachment_2"))
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
                                IO.File.Delete(DT_File(x)("Attachment_3"))
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
                                IO.File.Delete(DT_File(x)("Attachment_4"))
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
                                IO.File.Delete(DT_File(x)("Attachment_5"))
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
                                IO.File.Delete(DT_File(x)("Attachment_6"))
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
                                IO.File.Delete(DT_File(x)("Attachment_7"))
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
                                IO.File.Delete(DT_File(x)("Attachment_8"))
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
                                IO.File.Delete(DT_File(x)("Attachment_9"))
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
                                IO.File.Delete(DT_File(x)("Attachment_10"))
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                Next
            End If
            MsgBox(String.Format("Successfully Cleared Cache with total file of {0} and total size of {1} bytes", FormatNumber(TotalFile, 0), FormatNumber(TotalSize, 0)), MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub I_HomeSettings_Click(sender As Object, e As EventArgs) Handles I_HomeSettings.Click
        BtnHomeSettings_Click(sender, e)
    End Sub

    'Reports
    '**Financials
    Private Sub I_GeneralLedger_Click(sender As Object, e As EventArgs) Handles I_GeneralLedger.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmGeneralLedger
            .Tag = 29
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmGeneralLedger) = False Then
            Logs("Main", "Open", "General Ledger", "", "", "", "")
        End If
        Forms(FrmGeneralLedger, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_TrialBalance_Click(sender As Object, e As EventArgs) Handles I_TrialBalance.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmTrialBalance
            .Tag = 30
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmTrialBalance) = False Then
            Logs("Main", "Open", "Trial Balance", "", "", "", "")
        End If
        Forms(FrmTrialBalance, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_BalanceSheet_Click(sender As Object, e As EventArgs) Handles I_BalanceSheet.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBalanceSheet
            .Tag = 31
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBalanceSheet) = False Then
            Logs("Main", "Open", "Balance Sheet", "", "", "", "")
        End If
        Forms(FrmBalanceSheet, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_IncomeStatement_Click(sender As Object, e As EventArgs) Handles I_IncomeStatement.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmIncomeStatement
            .Tag = 94
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmIncomeStatement) = False Then
            Logs("Main", "Open", "Income Statement", "", "", "", "")
        End If
        Forms(FrmIncomeStatement, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Aging_Click(sender As Object, e As EventArgs) Handles I_Aging.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAgingNew
            .Tag = 32
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAgingNew) = False Then
            Logs("Main", "Open", "Aging", "", "", "", "")
        End If
        Forms(FrmAgingNew, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CashReceipt_Click(sender As Object, e As EventArgs) Handles I_CashReceipt.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCashReceipt
            .Tag = 95
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCashReceipt) = False Then
            Logs("Main", "Open", "Cash Receipt", "", "", "", "")
        End If
        Forms(FrmCashReceipt, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CheckDisbursement_Click(sender As Object, e As EventArgs) Handles I_CheckDisbursement.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCheckDisbursement
            .Tag = 96
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCheckDisbursement) = False Then
            Logs("Main", "Open", "Check Disbursement", "", "", "", "")
        End If
        Forms(FrmCheckDisbursement, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_GeneralJournal_Click(sender As Object, e As EventArgs) Handles I_GeneralJournal.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmGeneralJournal
            .Tag = 97
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmGeneralJournal) = False Then
            Logs("Main", "Open", "General Journal", "", "", "", "")
        End If
        Forms(FrmGeneralJournal, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AccountsPayableV2_Click(sender As Object, e As EventArgs) Handles I_AccountsPayableV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        MsgBox("Form is still under construction.", MsgBoxStyle.Information, "Info")
        Exit Sub

        Cursor = Cursors.WaitCursor
        With FrmDepartment
            .Tag = 33
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmDepartment) = False Then
            Logs("Main", "Open", "Accounts Payable", "", "", "", "")
        End If
        Forms(FrmDepartment, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_SubsidiaryLedger_Click(sender As Object, e As EventArgs) Handles I_SubsidiaryLedger.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmSubsidiaryLedger
            .Tag = 34
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmSubsidiaryLedger) = False Then
            Logs("Main", "Open", "Subsidiary Ledger", "", "", "", "")
        End If
        Forms(FrmSubsidiaryLedger, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_BookingReport_Click(sender As Object, e As EventArgs) Handles I_BookingReport.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBookingReport
            .Tag = 35
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBookingReport) = False Then
            Logs("Main", "Open", "Booking Report", "", "", "", "")
        End If
        Forms(FrmBookingReport, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CollectionReport_Click(sender As Object, e As EventArgs) Handles I_CollectionReport.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCollectionReport
            .Tag = 36
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCollectionReport) = False Then
            Logs("Main", "Open", "Collection Report", "", "", "", "")
        End If
        Forms(FrmCollectionReport, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_BookingCollection_Click(sender As Object, e As EventArgs) Handles I_BookingCollection.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBookingAndCollection
            .Tag = 121
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBookingAndCollection) = False Then
            Logs("Main", "Open", "Booking and Collection Report", "", "", "", "")
        End If
        Forms(FrmBookingAndCollection, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AccountsReceivableV2_Click(sender As Object, e As EventArgs) Handles I_AccountsReceivableV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAccountsReceivableReport
            .Tag = 122
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAccountsReceivableReport) = False Then
            Logs("Main", "Open", "Accounts Receivable Report", "", "", "", "")
        End If
        Forms(FrmAccountsReceivableReport, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CashFlow_Click(sender As Object, e As EventArgs) Handles I_CashFlow.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCashFlow
            .Tag = 141
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCashFlow) = False Then
            Logs("Main", "Open", "Cash Flow", "", "", "", "")
        End If
        Forms(FrmCashFlow, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_BankRecon_Click(sender As Object, e As EventArgs) Handles I_BankRecon.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBankRecon
            .Tag = 142
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBankRecon) = False Then
            Logs("Main", "Open", "Cash Flow", "", "", "", "")
        End If
        Forms(FrmBankRecon, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_BooksAccount_Click(sender As Object, e As EventArgs) Handles I_BooksAccount.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmBooksOfAccount
            .Tag = 123
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmBooksOfAccount) = False Then
            Logs("Main", "Open", "Bank Of Accounts", "", "", "", "")
        End If
        Forms(FrmBooksOfAccount, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_StatementOfAccount_Click(sender As Object, e As EventArgs) Handles I_StatementOfAccount.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmSOA
            .Tag = 37
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmSOA) = False Then
            Logs("Main", "Open", "Statement of Account", "", "", "", "")
        End If
        Forms(FrmSOA, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_ReportV2_Click(sender As Object, e As EventArgs) Handles I_ReportV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmReportQuery
            .Tag = 41
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmReportQuery) = False Then
            Logs("Main", "Open", "Report Viewer", "", "", "", "")
        End If
        Forms(FrmReportQuery, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Report2V2_Click(sender As Object, e As EventArgs) Handles I_Report2V2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmReportSetup
            .Tag = 41
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmReportSetup) = False Then
            Logs("Main", "Open", "Report Viewer", "", "", "", "")
        End If
        Forms(FrmReportSetup, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_ROPAAging_Click(sender As Object, e As EventArgs) Handles I_ROPAAging.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmROPOASchedule
            .Tag = 56
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmROPOASchedule) = False Then
            Logs("Main", "Open", "Report Viewer", "", "", "", "")
        End If
        Forms(FrmROPOASchedule, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_ListingLoan_Click(sender As Object, e As EventArgs) Handles I_ListingLoan.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmListingOfLoan
            .Tag = 131
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmListingOfLoan) = False Then
            Logs("Main", "Open", "Listing of Loan", "", "", "", "")
        End If
        Forms(FrmListingOfLoan, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CollectionDue_Click(sender As Object, e As EventArgs) Handles I_CollectionDue.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmCollectionDueReport
            .Tag = 132
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmCollectionDueReport) = False Then
            Logs("Main", "Open", "Collection Due Report", "", "", "", "")
        End If
        Forms(FrmCollectionDueReport, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_DelinquencyReport_Click(sender As Object, e As EventArgs) Handles I_DelinquencyReport.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmDeliquencyReport
            .Tag = 133
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmDeliquencyReport) = False Then
            Logs("Main", "Open", "Deliquency Report", "", "", "", "")
        End If
        Forms(FrmDeliquencyReport, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_PerformanceReport_Click(sender As Object, e As EventArgs) Handles I_PerformanceReport.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmPerformanceReport
            .Tag = 134
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmPerformanceReport) = False Then
            Logs("Main", "Open", "Performance Report", "", "", "", "")
        End If
        Forms(FrmPerformanceReport, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_LoansReleases_Click(sender As Object, e As EventArgs) Handles I_LoansReleases.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmLoansReleases
            .Tag = 135
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmLoansReleases) = False Then
            Logs("Main", "Open", "Loans Releases", "", "", "", "")
        End If
        Forms(FrmLoansReleases, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_CollectionReportV2_Click(sender As Object, e As EventArgs) Handles I_CollectionReportV2.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmMonthlyCollectionReport
            .Tag = 136
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmMonthlyCollectionReport) = False Then
            Logs("Main", "Open", "Monthly Collection", "", "", "", "")
        End If
        Forms(FrmMonthlyCollectionReport, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_AgingPastdue_Click(sender As Object, e As EventArgs) Handles I_AgingPastdue.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAgingPastDue
            .Tag = 137
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAgingPastDue) = False Then
            Logs("Main", "Open", "Aging Past Due", "", "", "", "")
        End If
        Forms(FrmAgingPastDue, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_PortfolioAtRisk_Click(sender As Object, e As EventArgs) Handles I_PortfolioAtRisk.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmAgingPortfolioAtRisk
            .Tag = 138
            FormRestriction(.Tag)
            If allow_Access Then
                .vPrint = allow_Print
            Else
                Cursor = Cursors.Default
                MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        End With

        If PanelControl3.Controls.Contains(FrmAgingPortfolioAtRisk) = False Then
            Logs("Main", "Open", "Aging Portfolio at Risk", "", "", "", "")
        End If
        Forms(FrmAgingPortfolioAtRisk, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Help_Click(sender As Object, e As EventArgs) Handles I_Help.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        With FrmHelp
            .Tag = 59
            FormRestriction(.Tag)
        End With

        If PanelControl3.Controls.Contains(FrmHelp) = False Then
            Logs("Main", "Open", "Procedure", "", "", "", "")
        End If
        Forms(FrmHelp, PanelControl3)
        Cursor = Cursors.Default
    End Sub

    Private Sub I_Note_Click(sender As Object, e As EventArgs) Handles I_Note.Click
        If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
            MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor

        If PanelControl3.Controls.Contains(FrmNotes) = False Then
            Logs("Notes", "Open", "Notes", "", "", "", "")
        End If
        Forms(FrmNotes, PanelControl3)
        Cursor = Cursors.Default
    End Sub
    '*** Form Clicks

    Private Sub BtnDB_Click(sender As Object, e As EventArgs) Handles btnDB.Click
        If MsgBoxYes("Are you sure you want to open the database connection?") = MsgBoxResult.Yes Then
            Dim PW As New FrmPassword
            With PW
                .ShowMessage = False
                .lblNote.Text = "*For IT Password only."
HERE:
                If .ShowDialog = DialogResult.OK Then
                    If IT_PW = DataObject(String.Format("SELECT MD5(SHA1('{0}'))", ReplaceText(.txtPassword.Text))) Then
                        FrmDBConnection.ShowDialog()
                    Else
                        MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                        .txtPassword.Text = ""
                        GoTo HERE
                    End If
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnMotivation_Click(sender As Object, e As EventArgs) Handles btnMotivation.Click
        Dim R As New Random()
        Dim Motivation As New FrmMotivationQuote
        With Motivation
            Try
                .PictureEdit1.Image = Image.FromFile(String.Format("{1}{2}\Motivational Quotes\{0}.jpg", R.Next(1, MotivationC), RootFolder, MainFolder))
            Catch ex As Exception
                Try
                    .PictureEdit1.Image = Image.FromFile(String.Format("{1}{2}\Motivational Quotes\{0}.jpeg", R.Next(1, MotivationC), RootFolder, MainFolder))
                Catch ex1 As Exception
                End Try
            End Try
            Logs("Main", "Motivational Quotes", "Open", "", "", "", "")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub AlertControl1_BeforeFormShow(sender As Object, e As DevExpress.XtraBars.Alerter.AlertFormEventArgs) Handles AlertControl1.BeforeFormShow
        e.AlertForm.Size = New Size(Convert.ToInt32(400), Convert.ToInt32(120))
    End Sub

    Private Sub Timer_Notification_Tick(sender As Object, e As EventArgs) Handles Timer_Notification.Tick
        Try
            CurrentVersion = DataObject(String.Format("SELECT system_version FROM version_setup WHERE `status` = 'ACTIVE';"))
            If FrmLogin.InvokeRequired = True Then
                Dim Login = New FrmLogin
                FrmLogin.Invoke(New ShowAlertInvoker(AddressOf Login.StopThread), New Object() {"", ""})
            Else
                If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
                    Exit Sub
                End If

                If Auto_Borrower Then
                    '***Borrowers
                    Dim NewIndiCount As Integer = DataObject(String.Format("CALL Main_IndividualCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                    Dim NewCorpCount As Integer = DataObject(String.Format("CALL Main_CorporateCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                    If IndividualCount < NewIndiCount Then
                        If (NewIndiCount - IndividualCount) >= 5 Then
                        Else
                            Dim BorrowerInfo As DataTable = DataSource(String.Format("SELECT CONCAT(If(Prefix_B = '','',CONCAT(Prefix_B, ' ')),IF(FirstN_B = '','',CONCAT(FirstN_B , ' ')),IF(MiddleN_B = '','',CONCAT(MiddleN_B , ' ')),IF(LastN_B = '','',CONCAT(LastN_B , ' ')),Suffix_B) AS 'Name' FROM profile_borrower WHERE `status` = 'ACTIVE' AND IF('{0}' = 0,TRUE,branch_id = '{0}') ORDER BY ID ASC LIMIT {1},{2}", Branch_ID, IndividualCount, NewIndiCount - IndividualCount))
                            For x As Integer = 0 To BorrowerInfo.Rows.Count - 1
                                AlertControl1.Show(FindForm, "Borrower", String.Format("Individual Borrower {0} is now registered.", BorrowerInfo(x)("Name")))
                            Next
                        End If

                        IndividualCount = NewIndiCount
                        With FrmBorrowerDashboard
                            .pIndividual.Text = NewIndiCount
                            .LoadIndividual()
                        End With
                    ElseIf NewIndiCount < IndividualCount Then
                        IndividualCount = NewIndiCount
                        With FrmBorrowerDashboard
                            .pIndividual.Text = NewIndiCount
                            .LoadIndividual()
                        End With
                    End If
                    If CorporateCount < NewCorpCount Then
                        If (NewCorpCount - CorporateCount) >= 5 Then
                        Else
                            Dim BorrowerInfo As DataTable = DataSource(String.Format("SELECT TradeName AS 'Name' FROM profile_corporation WHERE `status` = 'ACTIVE' AND IF('{0}' = 0,TRUE,branch_id = '{0}') ORDER BY ID ASC LIMIT {1},{2}", Branch_ID, CorporateCount, NewCorpCount - CorporateCount))
                            For x As Integer = 0 To BorrowerInfo.Rows.Count - 1
                                AlertControl1.Show(FindForm, "Borrower", String.Format("Corporate Borrower {0} is now registered.", BorrowerInfo(x)("Name")))
                            Next
                        End If

                        CorporateCount = NewCorpCount
                        With FrmBorrowerDashboard
                            .pCorporate.Text = NewCorpCount
                            .LoadCorporate()
                        End With
                    ElseIf NewCorpCount < CorporateCount Then
                        CorporateCount = NewCorpCount
                        With FrmBorrowerDashboard
                            .pCorporate.Text = NewCorpCount
                            .LoadCorporate()
                        End With
                    End If
                End If

                If Auto_ROPA Then
                    '***ROPOA
                    Dim NewVehicleCount As Integer = DataObject(String.Format("CALL Main_VehicleCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                    Dim NewVehicleCount_Sold As Integer = DataObject(String.Format("CALL Main_VehicleCountSold('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                    If VehicleCount < NewVehicleCount Then
                        If (NewVehicleCount - VehicleCount) >= 5 Then
                        Else
                            Dim ROPOA_Info As DataTable = DataSource(String.Format("SELECT `Make`, PlateNum FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND sell_status IN ('SELL','SCRAP','RESERVED','SOLD') AND IF('{0}' = 0,TRUE,branch_id = '{0}') GROUP BY PlateNum, Sell_Status, AccountID ORDER BY ID ASC LIMIT {1},{2}", Branch_ID, VehicleCount, NewVehicleCount - VehicleCount))
                            For x As Integer = 0 To ROPOA_Info.Rows.Count - 1
                                AlertControl1.Show(FindForm, "ROPOA Vehicle", String.Format("New ROPOA Vehicle {0} with plate number {1} is now registered.", ROPOA_Info(x)("Make"), ROPOA_Info(x)("PlateNum")))
                            Next
                        End If

                        VehicleCount = NewVehicleCount
                        With FrmAssetDashboard
                            .pVehicleIncome.Text = FormatNumber(VehicleCount_Sold, 0) '& " / " & DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND reserved_status = 'NO' AND SUBSTRING(AssetNumber,1,3) = 'ANV' AND IF('{0}' = 0,TRUE,branch_id = '{0}');", Branch_ID))
                            .LoadVehicle()
                            .LoadBuyer()
                        End With
                    ElseIf NewVehicleCount < VehicleCount Then
                        VehicleCount = NewVehicleCount
                        With FrmAssetDashboard
                            .pVehicleIncome.Text = FormatNumber(VehicleCount_Sold, 0) '& " / " & DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND reserved_status = 'NO' AND SUBSTRING(AssetNumber,1,3) = 'ANV' AND IF('{0}' = 0,TRUE,branch_id = '{0}');", Branch_ID))
                            .LoadVehicle()
                            .LoadBuyer()
                        End With
                    End If
                    If VehicleCount_Sold < NewVehicleCount_Sold Then
                        If (NewVehicleCount_Sold - VehicleCount_Sold) >= 5 Then
                        Else
                            Dim ROPOA_Info As DataTable = DataSource(String.Format("SELECT R.`Make`, R.PlateNum, R.AssetNumber, CONCAT(If(S.Prefix_B = '','',CONCAT(S.Prefix_B, ' ')),IF(S.FirstN_B = '','',CONCAT(S.FirstN_B , ' ')),IF(S.MiddleN_B = '','',CONCAT(S.MiddleN_B , ' ')),IF(S.LastN_B = '','',CONCAT(S.LastN_B , ' ')),S.Suffix_B) AS 'Name' FROM sold_ropoa S LEFT JOIN ropoa_vehicle R ON R.AssetNumber = S.AssetNumber WHERE S.`status` = 'ACTIVE' AND SUBSTRING(R.AssetNumber,1,3) = 'ANV' AND R.sell_status = 'SOLD' AND IF('{0}' = 0,TRUE,S.branch_id = '{0}') ORDER BY S.ID ASC LIMIT {1},{2}", Branch_ID, VehicleCount_Sold, NewVehicleCount_Sold - VehicleCount_Sold))
                            For x As Integer = 0 To ROPOA_Info.Rows.Count - 1
                                AlertControl1.Show(FindForm, "SOLD ROPOA Vehicle", String.Format("ROPOA Vehicle {0} with plate number {1} is SOLD to {2}.", ROPOA_Info(x)("Make"), ROPOA_Info(x)("PlateNum"), ROPOA_Info(x)("Name")))
                                VehicleCount = DataObject(String.Format("CALL Main_VehicleCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                            Next
                        End If

                        VehicleCount_Sold = NewVehicleCount_Sold
                        With FrmAssetDashboard
                            .pVehicleIncome.Text = FormatNumber(VehicleCount_Sold, 0) '& " / " & DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND reserved_status = 'NO' AND SUBSTRING(AssetNumber,1,3) = 'ANV' AND IF('{0}' = 0,TRUE,branch_id = '{0}');", Branch_ID))
                            .LoadVehicle()
                            .LoadBuyer()
                        End With
                    ElseIf NewVehicleCount_Sold < VehicleCount_Sold Then
                        VehicleCount_Sold = NewVehicleCount_Sold
                        With FrmAssetDashboard
                            .pVehicleIncome.Text = FormatNumber(VehicleCount_Sold, 0) '& " / " & DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND reserved_status = 'NO' AND SUBSTRING(AssetNumber,1,3) = 'ANV' AND IF('{0}' = 0,TRUE,branch_id = '{0}');", Branch_ID))
                            .LoadVehicle()
                            .LoadBuyer()
                        End With
                    End If

                    Dim NewRealEstateCount As Integer = DataObject(String.Format("CALL Main_RealEstateCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                    Dim NewRealEstateCount_Sold As Integer = DataObject(String.Format("CALL Main_RealEstateCountSold('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                    If RealEstateCount < NewRealEstateCount Then
                        If (NewRealEstateCount - RealEstateCount) >= 5 Then
                        Else
                            Dim ROPOA_Info As DataTable = DataSource(String.Format("SELECT TCT, Location FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND sell_status IN ('SELL','SCRAP','RESERVED','SOLD') AND IF('{0}' = 0,TRUE,branch_id = '{0}') GROUP BY TCT, Sell_Status, AccountID ORDER BY ID ASC LIMIT {1},{2}", Branch_ID, RealEstateCount, NewRealEstateCount - RealEstateCount))
                            For x As Integer = 0 To ROPOA_Info.Rows.Count - 1
                                AlertControl1.Show(FindForm, "ROPOA Real Estate", String.Format("New ROPOA Real Estate TCT Number {0} located at {1} is now registered.", ROPOA_Info(x)("TCT"), ROPOA_Info(x)("Location")))
                            Next
                        End If

                        RealEstateCount = NewRealEstateCount
                        With FrmAssetDashboard
                            .pRealEstateIncome.Text = FormatNumber(RealEstateCount_Sold, 0) '& " / " & DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND reserved_status = 'NO' AND SUBSTRING(AssetNumber,1,3) = 'ANR' AND IF('{0}' = 0,TRUE,branch_id = '{0}');", Branch_ID))
                            .LoadRealEstate()
                            .LoadBuyer()
                        End With
                    ElseIf NewRealEstateCount < RealEstateCount Then
                        RealEstateCount = NewRealEstateCount
                        With FrmAssetDashboard
                            .pRealEstateIncome.Text = FormatNumber(RealEstateCount_Sold, 0) '& " / " & DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND reserved_status = 'NO' AND SUBSTRING(AssetNumber,1,3) = 'ANR' AND IF('{0}' = 0,TRUE,branch_id = '{0}');", Branch_ID))
                            .LoadRealEstate()
                            .LoadBuyer()
                        End With
                    End If
                    If RealEstateCount_Sold < NewRealEstateCount_Sold Then
                        If (NewRealEstateCount_Sold - RealEstateCount_Sold) >= 5 Then
                        Else
                            Dim ROPOA_Info As DataTable = DataSource(String.Format("SELECT R.TCT, R.Location, R.AssetNumber, CONCAT(If(S.Prefix_B = '','',CONCAT(S.Prefix_B, ' ')),IF(S.FirstN_B = '','',CONCAT(S.FirstN_B , ' ')),IF(S.MiddleN_B = '','',CONCAT(S.MiddleN_B , ' ')),IF(S.LastN_B = '','',CONCAT(S.LastN_B , ' ')),S.Suffix_B) AS 'Name' FROM sold_ropoa S LEFT JOIN ropoa_realestate R ON R.AssetNumber = S.AssetNumber WHERE S.`status` = 'ACTIVE' AND SUBSTRING(R.AssetNumber,1,3) = 'ANR' AND R.sell_status = 'SOLD' AND R.sell_status = 'SOLD' AND IF('{0}' = 0,TRUE,S.branch_id = '{0}') ORDER BY S.ID ASC LIMIT {1},{2}", Branch_ID, RealEstateCount_Sold, NewRealEstateCount_Sold - RealEstateCount_Sold))
                            For x As Integer = 0 To ROPOA_Info.Rows.Count - 1
                                AlertControl1.Show(FindForm, "SOLD ROPOA Real Estate", String.Format("ROPOA Real Estate TCT Number {0} located at {1} is SOLD to {2}.", ROPOA_Info(x)("TCT"), ROPOA_Info(x)("Location"), ROPOA_Info(x)("Name")))
                                RealEstateCount = DataObject(String.Format("CALL Main_RealEstateCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                            Next
                        End If

                        RealEstateCount_Sold = NewRealEstateCount_Sold
                        With FrmAssetDashboard
                            .pRealEstateIncome.Text = FormatNumber(RealEstateCount_Sold, 0) '& " / " & DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND reserved_status = 'NO' AND SUBSTRING(AssetNumber,1,3) = 'ANR' AND IF('{0}' = 0,TRUE,branch_id = '{0}');", Branch_ID))
                            .LoadRealEstate()
                            .LoadBuyer()
                        End With
                    ElseIf NewRealEstateCount_Sold < RealEstateCount_Sold Then
                        RealEstateCount_Sold = NewRealEstateCount_Sold
                        With FrmAssetDashboard
                            .pRealEstateIncome.Text = FormatNumber(RealEstateCount_Sold, 0) '& " / " & DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND reserved_status = 'NO' AND SUBSTRING(AssetNumber,1,3) = 'ANR' AND IF('{0}' = 0,TRUE,branch_id = '{0}');", Branch_ID))
                            .LoadRealEstate()
                            .LoadBuyer()
                        End With
                    End If
                End If

                If Auto_CreditApplication Then
                    '***Credit Application
                    Dim NewCreditApplication As Integer = DataObject(String.Format("CALL Main_CreditApplicationCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                    Dim NewCreditApplication_Approved As Integer = DataObject(String.Format("CALL Main_CreditApplicationApprovedCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                    If CreditApplication < NewCreditApplication Then
                        If (NewCreditApplication - CreditApplication) >= 5 Then
                        Else
                            Dim Credit_Info As DataTable = DataSource(String.Format("SELECT CreditNumber, Product, FORMAT(AmountApplied,2) AS 'AmountApplied', CONCAT(Terms, ' ', TermType) AS 'Terms' FROM credit_application WHERE `status` = 'ACTIVE' AND application_status = 'PENDING' AND IF('{0}' = 0,TRUE,branch_id = '{0}') ORDER BY ID ASC LIMIT {1},{2}", Branch_ID, CreditApplication, NewCreditApplication - CreditApplication))
                            For x As Integer = 0 To Credit_Info.Rows.Count - 1
                                AlertControl1.Show(FindForm, "Credit Application", String.Format("New Credit Application {3} - {0} with Applied Amount {1} for {2}.", Credit_Info(x)("Product"), Credit_Info(x)("AmountApplied"), Credit_Info(x)("Terms"), Credit_Info(x)("CreditNumber")))
                            Next
                        End If

                        CreditApplication = NewCreditApplication
                    ElseIf NewCreditApplication < CreditApplication Then
                        CreditApplication = NewCreditApplication
                    End If
                    If CreditApplication_Approved < NewCreditApplication_Approved Then
                        If (NewCreditApplication_Approved - CreditApplication_Approved) >= 5 Then
                        Else
                            Dim Credit_Info As DataTable = DataSource(String.Format("SELECT CreditNumber, Product, FORMAT(AmountApplied,2) AS 'AmountApplied', CONCAT(Terms, ' ', TermType) AS 'Terms', IF(mortgage_id BETWEEN 1 AND 2,1,0) AS 'Mortgage' FROM credit_application WHERE `status` = 'ACTIVE' AND application_status = 'APPROVED' AND IF('{0}' = 0,TRUE,branch_id = '{0}') ORDER BY ID ASC LIMIT {1},{2}", Branch_ID, CreditApplication_Approved, NewCreditApplication_Approved - CreditApplication_Approved))
                            For x As Integer = 0 To Credit_Info.Rows.Count - 1
                                AlertControl1.Show(FindForm, If(Credit_Info(x)("Mortgage") = 1, "For Credit Investigation", "For Payment Preparation"), String.Format("Credit Application {3} - {0} with Applied Amount {1} for {2}.", Credit_Info(x)("Product"), Credit_Info(x)("AmountApplied"), Credit_Info(x)("Terms"), Credit_Info(x)("CreditNumber")))
                                If x = Credit_Info.Rows.Count - 1 Then
                                    CreditApplication = DataObject(String.Format("SELECT COUNT(DISTINCT ID) FROM credit_application WHERE `status` = 'ACTIVE' AND application_status = 'PENDING' AND IF('{0}' = 0,TRUE,branch_id = '{0}');", Branch_ID))
                                End If
                            Next
                        End If

                        CreditApplication_Approved = NewCreditApplication_Approved
                    ElseIf NewCreditApplication_Approved < CreditApplication_Approved Then
                        CreditApplication_Approved = NewCreditApplication_Approved
                    End If
                End If

                If Auto_CreditInvestigation Then
                    '***Credit Investigation FOR ADMIN / BRANCH MANAGER / OIC Only!
                    If User_Type = "ADMIN" Or ComparePosition({"BRANCH MANAGER", "OPERATIONS MANAGER", "MICROFINANCE LOAN MANAGER", "OFFICER-IN-CHARGE", "OFFICE SUPERVISOR", "ASSISTANT BRANCH MANAGER"}, False) Then
                        Dim NewCI As Integer = DataObject(String.Format("CALL Main_CreditInvestigationCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                        Dim NewCI_Approved As Integer = DataObject(String.Format("CALL Main_CreditInvestigationApprovedCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                        If CI < NewCI Then
                            If (NewCI - CI) >= 5 Then
                            Else
                                Dim CI_Info As DataTable = DataSource(String.Format("SELECT CINumber, CreditNumber, Product, RecommendationFor, Narrative FROM credit_investigation WHERE `status` = 'ACTIVE' AND CI_status = 'PENDING' AND IF('{0}' = 0,TRUE,branch_id = '{0}') ORDER BY ID ASC LIMIT {1},{2}", Branch_ID, CI, NewCI - CI))
                                For x As Integer = 0 To CI_Info.Rows.Count - 1
                                    AlertControl1.Show(FindForm, "Credit Investigation", String.Format("New Credit Investigation {0} with Application Number {1} - {2}. {4}", CI_Info(x)("CINumber"), CI_Info(x)("CreditNumber"), CI_Info(x)("Product"), CI_Info(x)("RecommendationFor"), CI_Info(x)("Narrative")))
                                Next
                            End If
                            CI = NewCI
                        ElseIf NewCI < CI Then
                            CI = NewCI
                        End If
                        If CI_Approved < NewCI_Approved Then
                            If (NewCI_Approved - CI_Approved) >= 5 Then
                            Else
                                Dim CI_Info As DataTable = DataSource(String.Format("SELECT CINumber, CreditNumber, Product, RecommendationFor, Narrative FROM credit_investigation WHERE `status` = 'ACTIVE' AND CI_status = 'APPROVED' AND IF('{0}' = 0,TRUE,branch_id = '{0}') ORDER BY ID ASC LIMIT {1},{2}", Branch_ID, CI_Approved, NewCI_Approved - CI_Approved))
                                For x As Integer = 0 To CI_Info.Rows.Count - 1
                                    AlertControl1.Show(FindForm, "Approved Credit Investigation", String.Format("Credit Investigation {0} with Application Number {1} - {2}. {4}", CI_Info(x)("CINumber"), CI_Info(x)("CreditNumber"), CI_Info(x)("Product"), CI_Info(x)("RecommendationFor"), CI_Info(x)("Narrative")))
                                    If x = CI_Info.Rows.Count - 1 Then
                                        CI = DataObject(String.Format("CALL Main_CreditInvestigationCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
                                    End If
                                Next
                            End If

                            CI_Approved = NewCI_Approved
                        ElseIf NewCI_Approved < CI_Approved Then
                            CI_Approved = NewCI_Approved
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnSkin_Click(sender As Object, e As EventArgs) Handles btnSkin.Click
        Dim Skin As New FrmSkin
        With Skin
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub AlertControl1_AlertClick(sender As Object, e As DevExpress.XtraBars.Alerter.AlertClickEventArgs) Handles AlertControl1.AlertClick
        'MsgBox("To View the Borrower Information, please go to Borrowers List Form.", MsgBoxStyle.Information, "Info")
    End Sub

    'Private Sub NavBarControl1_MouseDown(sender As Object, e As MouseEventArgs)
    '    If e.Button = Windows.Forms.MouseButtons.Left Then
    '        Dim HitInfo As DevExpress.XtraNavBar.NavBarHitInfo
    '        HitInfo = NavBarControl1.CalcHitInfo(New Point(e.X, e.Y))
    '        With HitInfo
    '            If (.InGroupCaption And Not .InGroupButton) Then
    '                .Group.Expanded = Not .Group.Expanded
    '            End If
    '        End With
    '    End If
    'End Sub

    Private Sub LblName_MouseDown(sender As Object, e As MouseEventArgs) Handles lblName.MouseDown
        'If e.Button = Windows.Forms.MouseButtons.Left Then
        '    Dim Change As New FrmChangePassword
        '    With Change
        '        .txtUserName.Text = FrmLogin.txtUserName.Text
        '        .OldP = FrmLogin.txtPassword.Text
        '        .txtUserType.Text = User_Type
        '        .ShowDialog()
        '        .Dispose()
        '    End With
        'ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
        '    Dim Nickname As New FrmNickName
        '    With Nickname
        '        .ShowDialog()
        '        .Dispose()
        '    End With
        'End If
        Dim User As New FrmUserProfile
        With User
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub Timer_Send_Tick(sender As Object, e As EventArgs) Handles Timer_Send.Tick
        If (lblDate.Text.Contains("Disconnected") And Ping_Notification) Or Auto_SMSSend = False Then
            Exit Sub
        End If
        MyBackgroundThread()
    End Sub

    Private Sub CbxPort_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPort.SelectedIndexChanged
        If Auto_SMSSend = False Then
            Exit Sub
        End If

        Try
            SerialPort = objport.OpenPort(cbxPort.Text)
            If SerialPort IsNot Nothing Then
                cbxPort.Visible = True
                MsgBox("Modem is connected at PORT " & cbxPort.Text & ".", MsgBoxStyle.Information, "Info")
                Timer_Send.Start()
                With thread
                    .SetApartmentState(ApartmentState.STA)
                    .Start()
                End With
            Else
                Timer_Send.Stop()
                thread.Abort()
            End If
        Catch ex As Exception
            TriggerBugReport("Main - Port SelectedIndexChanged", ex.Message.ToString)
        End Try
    End Sub

    Private Sub MyBackgroundThread()
        Try
            If cbxPort.Enabled = False And Auto_SMSSend Then
                DT_Outbox = DataSource(String.Format("SELECT ID, PhoneN, Message FROM sms_outbox WHERE `status` = 'ACTIVE' AND send_status = 'PENDING' AND PhoneN != '';"))
                If DT_Outbox.Rows.Count > 0 Then
                    For x As Integer = 0 To DT_Outbox.Rows.Count - 1
                        If objport.SendSMS(SerialPort, "+63" & DT_Outbox(x)("PhoneN"), DT_Outbox(x)("Message")) Then
                            DataObject(String.Format("UPDATE sms_outbox SET send_status = 'SENT' WHERE ID = '{0}';", DT_Outbox(x)("ID")))
                            MsgBox("Message Sent!", MsgBoxStyle.Information, "Info")
                            cbxPort.Enabled = False
                        Else
                            MsgBox("Message Send Failed.", MsgBoxStyle.Information, "Info")
                            cbxPort.Enabled = True
                        End If
                    Next
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnEmail_Click(sender As Object, e As EventArgs) Handles btnEmail.Click
        'Dim Confi As New FrmConfiEmail
        'With Confi
        '    If User_Type = "ADMIN" Then
        '        .ForAdmin = True
        '        .txtEmail.Text = AppEmailAddress
        '        .txtEmail.Tag = AppEmailAddress
        '    Else
        '        .txtEmail.Text = ConfiEmail
        '        .txtEmail.Tag = ConfiEmail
        '    End If
        '    .ShowDialog()
        '    .Dispose()
        'End With
    End Sub

    Public Sub BtnReport_Click(sender As Object, e As EventArgs) Handles btnReport.Click
        Try
            PrintscreenActivate = True
            'Dim TempImage As Image = Clipboard.GetImage()
            'SendKeys.Send("%{PRTSC}")
            Dim Screenshot As Image = CaptureScreen()
            Dim FName As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\System Concern [" & Format(Date.Now, "yyyyMMddHHmmss") & "].jpg"
            Screenshot.Save(FName, Imaging.ImageFormat.Jpeg)
            Dim Report As New FrmReportProblem
            With Report
                .FName = FName
                .pbMain.Image = Screenshot.Clone
                .ShowDialog()
                .Dispose()
            End With
            'If Clipboard.ContainsImage Then
            '    Clipboard.Clear()
            'End If
            'If TempImage IsNot Nothing Then
            '    Clipboard.SetImage(TempImage.Clone)
            '    TempImage.Dispose()
            'End If
            PrintscreenActivate = False
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnMultiAuthentication_Click(sender As Object, e As EventArgs) Handles btnMultiAuthentication.Click
        If MultiAuthentication Then
            If MsgBox("Are you sure you want to DEACTIVATE the Multi Factor Authentication?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                DataObject(String.Format("UPDATE users SET MultiAuthentication = 0 WHERE ID = '{0}';", User_ID))
                MultiAuthentication = False
                btnMultiAuthentication.LookAndFeel.UseDefaultLookAndFeel = True
                MsgBox("Successfully Deactivated", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBox("Are you sure you want to ACTIVATE the Multi Factor Authentication?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
                If Empl_Email = "" And DataObject(String.Format("SELECT Phone FROM employee_setup WHERE ID = '{0}';", Empl_ID)) = "" Then
                    MsgBox("Please setup your Email Address And Phone Number that will be used for authentication. Thank you.", MsgBoxStyle.Information, "Info")
                Else
                    DataObject(String.Format("UPDATE users SET MultiAuthentication = 1 WHERE ID = '{0}';", User_ID))
                    MultiAuthentication = True
                    btnMultiAuthentication.LookAndFeel.UseDefaultLookAndFeel = False
                    MsgBox("Successfully Activated", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Sub BtnCalculator_Click(sender As Object, e As EventArgs) Handles btnCalculator.Click
        Process.Start("Calc")
    End Sub

    Private Sub BtnNote_Click(sender As Object, e As EventArgs) Handles btnNote.Click
        Process.Start("Notepad")
    End Sub

    Private Sub BtnPing_Click(sender As Object, e As EventArgs) Handles btnPing.Click
        If MsgBoxYes("Are you sure you want to check the status of your connection through ping?") = MsgBoxResult.Yes Then
            Dim PW As New FrmPassword
            With PW
                .ShowMessage = False
                .lblNote.Text = "*Please fill your password."
HERE:
                If .ShowDialog = DialogResult.OK Then
                    If FrmLogin.txtPassword.Text = .txtPassword.Text Then
                    Else
                        MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                        .txtPassword.Text = ""
                        GoTo HERE
                    End If
                Else
                    Exit Sub
                End If
                .Dispose()
            End With

            Shell(String.Format("Ping {0} -t", "Google.com"))

            'Dim Message As String = EMessage & "<br><br>"
            'Message &= "Name: " & UpperCaseFirst(Empl_Name) & "<br>"
            'Message &= "Branch: " & UpperCaseFirst(Branch) & "<br>"
            'Message &= "Position: " & UpperCaseFirst(Empl_Position) & "<br>"
            'Message &= "Department: " & UpperCaseFirst(Department) & "<br>"
            'Message &= "Email: " & Empl_Email & "<br>"
            'Message &= "Date: " & Format(Date.Now, "MMMM dd, yyyy") & "<br>"
            'Message &= "Time: " & Format(Date.Now, "hh:mm:ss") & "<br>"
            'Message &= "Computer Username: " & Environment.UserName & "<br>"

            'Dim EToMail As String = ""
            'Dim EToSMS As String = ""
            'Dim DT As New DataTable
            'DT = DataSource(String.Format("SELECT EmailAdd, Phone FROM employee_setup WHERE Department IN ('INFORMATION TECHNOLOGY','FINANCE') AND Branch_ID = 0 AND `status` = 'ACTIVE';"))
            'For x As Integer = 0 To DT.Rows.Count - 1
            '    If DT(x)("EmailAdd") = "" Then
            '    Else
            '        EToMail = EToMail & DT(x)("EmailAdd") & ", "
            '    End If

            '    If DT(x)("Phone") = "" Then
            '    Else
            '        SendSMS(DT(x)("Phone"), Message.Replace("<br>", " "), True)
            '    End If
            'Next

            'If EToMail = "" Then
            'Else
            '    SendEmail(EToMail.Substring(0, EToMail.Length - 2), ESubject, Message, False, False, False, 0, "", "")
            'End If
        End If
    End Sub

    Private Sub Timer_Email_Tick(sender As Object, e As EventArgs) Handles Timer_Email.Tick 'Every 10 Seconds ang Tick
        If Auto_EmailSend = False Then
            Exit Sub
        End If

        Seconds_300 += 1
        If Seconds_300 = SendPendingEmailEvery Then
            If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
                Seconds_300 -= 2
                Exit Sub
            End If
            Dim DT_Email As DataTable = DataSource(String.Format("CALL Login_GetEmail('{0}');", Empl_ID))
            If DT_Email.Rows.Count > 0 Then
                AttachmentFiles = New ArrayList()
                With AttachmentFiles
                    If DT_Email(0)("Attachment_1") <> "" Then
                        .Add(DT_Email(0)("Attachment_1"))
                    End If
                    If DT_Email(0)("Attachment_2") <> "" Then
                        .Add(DT_Email(0)("Attachment_2"))
                    End If
                    If DT_Email(0)("Attachment_3") <> "" Then
                        .Add(DT_Email(0)("Attachment_3"))
                    End If
                    If DT_Email(0)("Attachment_4") <> "" Then
                        .Add(DT_Email(0)("Attachment_4"))
                    End If
                    If DT_Email(0)("Attachment_5") <> "" Then
                        .Add(DT_Email(0)("Attachment_5"))
                    End If
                    If DT_Email(0)("Attachment_6") <> "" Then
                        .Add(DT_Email(0)("Attachment_6"))
                    End If
                    If DT_Email(0)("Attachment_7") <> "" Then
                        .Add(DT_Email(0)("Attachment_7"))
                    End If
                    If DT_Email(0)("Attachment_8") <> "" Then
                        .Add(DT_Email(0)("Attachment_8"))
                    End If
                    If DT_Email(0)("Attachment_9") <> "" Then
                        .Add(DT_Email(0)("Attachment_9"))
                    End If
                    If DT_Email(0)("Attachment_10") <> "" Then
                        .Add(DT_Email(0)("Attachment_10"))
                    End If
                End With
                SendEmail(DT_Email(0)("EmailAdd"), DT_Email(0)("Subject"), DT_Email(0)("Body"), DT_Email(0)("Confidential"), False, True, DT_Email(0)("ID"), DT_Email(0)("DocumentNumber"), DT_Email(0)("CC"))
            End If
            Seconds_300 = 0
        End If

        Seconds_450 += 1
        If Seconds_450 = 450 Then
            If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
                Seconds_450 = 445
                Exit Sub
            End If
            Dim DT_Notify As DataTable = DataSource(String.Format("CALL Login_GetCaseNotify({0});", Branch_ID))
            If DT_Notify.Rows.Count > 0 Then
                Dim BM As DataTable = DataSource(String.Format("SELECT Employee(ID) AS 'Employee', Phone, EmailAdd  FROM employee_setup WHERE `Position` IN ('OFFICER-IN-CHARGE','BRANCH MANAGER','CORPORATE LAWYER') AND `status` = 'ACTIVE' AND Branch_ID = '{0}';", Branch_ID))
                For x As Integer = 0 To BM.Rows.Count - 1
                    Dim Msg As String = String.Format("Good day {0},<br><br>" & vbCrLf, BM(x)("Employee"))
                    Msg &= String.Format("  This is a system generated notification for the upcoming action on {0} for {1}.<br><br>" & vbCrLf, DT_Notify(0)("Action Date"), DT_Notify(0)("Defendant"))
                    Msg &= String.Format("Case Number: {0}<br>" & vbCrLf, DT_Notify(0)("Case Number"))
                    Msg &= String.Format("Account Number: {0}<br>" & vbCrLf, DT_Notify(0)("Account Number"))
                    Msg &= String.Format("Category: {0}<br>" & vbCrLf, DT_Notify(0)("Category"))
                    Msg &= String.Format("SubCategory: {0}<br>" & vbCrLf, DT_Notify(0)("SubCategory"))
                    Msg &= String.Format("Action Plan: {0}<br>" & vbCrLf, DT_Notify(0)("Action Plan"))
                    Msg &= String.Format("Remarks: {0}<br>" & vbCrLf, DT_Notify(0)("Remarks"))
                    Msg &= String.Format("Reason: {0}<br>" & vbCrLf, DT_Notify(0)("Reason"))
                    Msg &= "Thank you!"
                    '******* SEND SMS *********************************************************************************
                    If BM(x)("Phone") = "" Then
                    Else
                        SendSMS(BM(x)("Phone"), Msg, False)
                    End If
                    '******* SEND EMAIL *********************************************************************************
                    If BM(x)("EmailAdd") = "" Then
                    Else
                        Dim Subject As String = String.Format("Reminder for scheduled action on {0} for {1}.", DT_Notify(0)("Action Date"), DT_Notify(0)("Defendant"))
                        SendEmail(BM(x)("EmailAdd"), Subject, Msg, False, False, False, 0, "", "")
                    End If
                Next
                'Note: Notify = 0 (No need of Notification)
                'Note: Notify = 1 (For Notification)
                'Note: Notify = 2 (Notified)
                DataObject(String.Format("UPDATE case_details SET Notify = 2 WHERE ID = '{0}';", DT_Notify(0)("Details_ID")))
            End If
            Seconds_450 = 0
        End If

        Seconds_10 += 1
        If Seconds_10 = 1000000000000000000 Then 'DILI LANG SA GAMITON SINCE NGA DLI PAMAN NEED PARA SA BIR 
            If lblDate.Text.Contains("Disconnected") And Ping_Notification Then
                Seconds_10 = 5
                Exit Sub
            End If
            LoadCompanyMode()
            If Prev_CompanyMode = CompanyMode Then
            Else
                Prev_CompanyMode = CompanyMode
                If CompanyMode = 0 Then
                    With FrmLogin
                        If .txtUserName.Text.Trim.Substring(.txtUserName.Text.Trim.Length - 1, 1) <> "1" Then
                            SessionOut = False
                            If cbxPort.Enabled = False And cbxPort.Visible Then
                                objport.ClosePort(SerialPort)
                                cbxPort.Items.Clear()
                            End If
                            OldUsername = ""
                            .txtUserName.Text = ""
                            .txtPassword.Text = ""
                            .Show()
                            Close()
                        End If
                    End With
                End If
            End If
            Seconds_10 = 0
        End If
    End Sub

    Private Sub BtnUserSettings_Click(sender As Object, e As EventArgs) Handles btnUserSettings.Click
        Dim User As New FrmUserSettings
        With User
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub FrmMain_KeyUp(sender As Object, e As KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = 44 Then
            If PrintscreenActivate = False And AllowPrintScreen = False Then
                If Clipboard.ContainsImage Then
                    Clipboard.GetImage.Dispose()
                End If
            End If
        End If
    End Sub

    Private Sub BtnSystemSettings_Click(sender As Object, e As EventArgs) Handles btnSystemSettings.Click
        If MsgBoxYes("Are you sure you want to open this system settings?") = MsgBoxResult.Yes Then
            Logs("Main", "Open", "System Settings", "", "", "", "")
            Dim System As New FrmSystemSettings
            With System
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        CheckVersion()
    End Sub

End Class