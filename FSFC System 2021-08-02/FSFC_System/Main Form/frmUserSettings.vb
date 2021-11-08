Public Class FrmUserSettings

    Dim DT_Permission As New DataTable
    Dim Code As String
    Dim Msg As String = ""
    Private Sub FrmUserSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpFrom.Value = Date.Now
        Code = GenerateOTAC()

        With cbxTo
            .DisplayMember = "empl_name"
            .ValueMember = "ID"
            .DataSource = DataSource(String.Format("SELECT ID, user_code, empl_id, empl_name, email_address FROM users WHERE `status` = 'ACTIVE' AND branch_id = {0} AND empl_id != {1} ORDER BY empl_name;", Branch_ID, Empl_ID))
            .SelectedIndex = -1
        End With

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

        cbxEmail.Checked = Auto_EmailSend
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
        If User_Type = "ADMIN" Then
            cbxUI.Enabled = True
        End If

        cbxEmail.Tag = If(Auto_EmailSend, "On", "Off")
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
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({lblTo, lblDays, lblEffectivity, lblDash})

            GetLabelFontSettingsDefault({LabelX13, LabelX6, LabelX5, LabelX4, LabelX3, LabelX2, LabelX1, LabelX31, LabelX7, LabelX8, LabelX9, LabelX12, LabelX10, LabelX11})

            GetIntegerInputFontSettings({iDays})

            GetCheckBoxFontSettings({cbxEmail, cbxAutoBugReport, cbxSMS, cbxROPA, cbxBorrower, cbxCreditApplication, cbxCreditInvestigation, cbxDepartment, cbxBusinessCenter, cbxProgressBar, cbxAlertNotification, cbxKeyword, cbxDomain, cbxEndorse, cbxPosition, cbxNA, cbxUI})

            GetComboBoxFontSettings({cbxTo})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSave, btnCancel, btnHistory})
        Catch ex As Exception
            TriggerBugReport("User Settings - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cbxEndorse.Checked And cbxTo.SelectedIndex = -1 Then
            MsgBox("Please select someone to endorse who will have your access.", MsgBoxStyle.Information, "Info")
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

        If MsgBoxYes("Are you sure you want to save this settings?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim SQL As String = "UPDATE users SET"
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
            SQL &= String.Format(" AllowUI = {0}, ", If(cbxUI.Checked, 1, 0))
            SQL &= String.Format(" AutoBugReport = {0}, ", If(cbxAutoBugReport.Checked, 1, 0))
            SQL &= String.Format(" AlertNotification = {0} ", If(cbxAlertNotification.Checked, 1, 0))
            SQL &= String.Format(" WHERE ID = {0};", User_ID)

            SQL &= "UPDATE endorse_permission SET"
            SQL &= " `status` = 'DONE' "
            SQL &= String.Format(" WHERE UserID = {0} AND `status` = 'ACTIVE';", User_ID)

            If cbxEndorse.Checked Then
                Dim drv As DataRowView = DirectCast(cbxTo.SelectedItem, DataRowView)
                Dim Msg As String = ""
                Dim Subject As String = String.Format("Endorse Permission of {0}", Empl_Name)
                Msg = String.Format("Good day {0}," & vbCrLf, cbxTo.Text)
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
                Logs("User Settings", "Endorse Permission", Empl_Name & " endorse his/her permissions to " & cbxTo.Text & If(cbxNA.Checked, " without date limit ", " from " & dtpFrom.Text & " to " & dtpTo.Text), Changes(), "", "", "")
            End If

            Auto_EmailSend = cbxEmail.Checked
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

            DataObject(SQL)
            Logs("User Settings", "Update", Reason, Changes(), "", "", "")
            Cursor = Cursors.Default
            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            Close()
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
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
        Return Change
    End Function

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

    Private Sub IDays_ValueChanged(sender As Object, e As EventArgs) Handles iDays.ValueChanged
        dtpTo.Value = dtpFrom.Value.AddDays(iDays.Value)
    End Sub

    Private Sub DtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        dtpTo.Value = dtpFrom.Value.AddDays(iDays.Value)
    End Sub

    Private Sub DtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        dtpFrom.Value = dtpTo.Value.AddDays(-iDays.Value)
    End Sub

    Private Sub BtnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
        Dim History As New FrmPermissionHistory
        With History
            .ShowDialog()
            .Dispose()
        End With
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
        OpenFormHistory("User Settings", lblTitle.Text)
    End Sub
End Class