Public Class FrmCreditReferral

    Public CreditNumber As String
    Dim FirstLoad As Boolean
    Public vAgent As String
    Public vAgentV2 As String
    Public vMarketing As String
    Public vWalkIn As String
    Public vDealer As String
    Private Sub FrmCreditReferral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxAgentName
            .ValueMember = "AgentID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT AgentID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',LastN)) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_agent WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' ORDER BY `Name` DESC;", Branch_ID))
            If cbxAgent.Checked Then
                .SelectedValue = vAgent
                .Tag = .Text
                FirstLoad = False
                cbxAgentName_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        With cbxAgentNameV2
            .ValueMember = "AgentID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT AgentID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',LastN)) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_agent WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' ORDER BY `Name` DESC;", Branch_ID))
            If cbxAgent.Checked Then
                .SelectedValue = vAgentV2
                .Tag = .Text
                FirstLoad = False
                cbxAgentNameV2_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        With cbxMarketingName
            .ValueMember = "emp_code"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT ID, emp_code, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), IF(Last_Name = '','',Last_Name)) AS 'Name', Phone FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = 9 AND Branch_ID = '{0}' ORDER BY `Name`;", Branch_ID))
            If cbxMarketing.Checked Then
                .SelectedValue = vMarketing
                .Tag = .Text
                FirstLoad = False
                cbxMarketingName_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        With cbxWalkInType
            .ValueMember = "ID"
            .DisplayMember = "Type"
            .DataSource = DataSource("SELECT ID, `Type` FROM walkin_type WHERE `status` = 'ACTIVE' ORDER BY `Type`;")
            If cbxWalkIn.Checked Then
                .SelectedValue = vWalkIn
                .Tag = .Text
            Else
                .SelectedIndex = -1
            End If
        End With

        With cbxDealerName
            .ValueMember = "DealerID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT DealerID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',LastN)) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_dealer WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ORDER BY `Name` DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            If cbxDealer.Checked Then
                .SelectedValue = vDealer
                .Tag = .Text
                FirstLoad = False
                cbxDealerName_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelWithBackgroundFontSettings({LabelX188})

            GetTextBoxFontSettings({txtAgentContact, txtAgentContactV2, txtMarketingContact, txtWalkInOthers, txtDealersContact})

            GetButtonFontSettings({btnSave, btnCancel})

            GetComboBoxFontSettings({cbxAgentName, cbxAgentNameV2, cbxMarketingName, cbxWalkInType, cbxDealerName})

            GetCheckBoxFontSettings({cbxAgent, cbxAgentV2, cbxMarketing, cbxWalkIn, cbxDealer})
        Catch ex As Exception
            TriggerBugReport("Credit Referral - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub CbxAgent_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgent.CheckedChanged
        If cbxAgent.Checked Then
            cbxAgentName.Enabled = True
            txtAgentContact.Enabled = True

            cbxAgentV2.Enabled = True
        Else
            cbxAgentName.Enabled = False
            cbxAgentName.Text = ""
            txtAgentContact.Enabled = False
            txtAgentContact.Text = ""

            cbxAgentV2.Enabled = False
            cbxAgentV2.Checked = False
        End If
    End Sub

    Private Sub CbxAgentV2_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgentV2.CheckedChanged
        If cbxAgentV2.Checked Then
            cbxAgentNameV2.Enabled = True
            txtAgentContactV2.Enabled = True
        Else
            cbxAgentNameV2.Enabled = False
            cbxAgentNameV2.Text = ""
            txtAgentContactV2.Enabled = False
            txtAgentContactV2.Text = ""
        End If
    End Sub

    Private Sub CbxMarketing_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMarketing.CheckedChanged
        If cbxMarketing.Checked Then
            cbxMarketingName.Enabled = True
            txtMarketingContact.Enabled = True
        Else
            cbxMarketingName.Enabled = False
            cbxMarketingName.Text = ""
            txtMarketingContact.Enabled = False
            txtMarketingContact.Text = ""
        End If
    End Sub

    Private Sub CbxWalkIn_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWalkIn.CheckedChanged
        If cbxWalkIn.Checked Then
            cbxWalkInType.Enabled = True
            txtWalkInOthers.Enabled = True
        Else
            cbxWalkInType.Enabled = False
            cbxWalkInType.Text = ""
            txtWalkInOthers.Enabled = False
            txtWalkInOthers.Text = ""
        End If
    End Sub

    Private Sub CbxDealer_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDealer.CheckedChanged
        If cbxDealer.Checked Then
            cbxDealerName.Enabled = True
            txtDealersContact.Enabled = True
        Else
            cbxDealerName.Enabled = False
            cbxDealerName.Text = ""
            txtDealersContact.Enabled = False
            txtDealersContact.Text = ""
        End If
    End Sub

    Private Sub CbxDealerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDealerName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxDealerName.SelectedIndex = -1 Or cbxDealerName.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxDealerName.SelectedItem, DataRowView)
            txtDealersContact.Text = drv("Contact")
        End If
    End Sub

    Private Sub CbxDealerName_TextChanged(sender As Object, e As EventArgs) Handles cbxDealerName.TextChanged
        If cbxDealerName.Text = "" Then
            txtDealersContact.Text = ""
        End If
    End Sub

    Private Sub CbxAgentName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAgentName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxAgentName.SelectedIndex = -1 Or cbxAgentName.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxAgentName.SelectedItem, DataRowView)
            txtAgentContact.Text = drv("Contact")
        End If
    End Sub

    Private Sub CbxAgentNameV2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAgentNameV2.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxAgentNameV2.SelectedIndex = -1 Or cbxAgentNameV2.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxAgentNameV2.SelectedItem, DataRowView)
            txtAgentContactV2.Text = drv("Contact")
        End If
    End Sub

    Private Sub CbxAgentName_TextChanged(sender As Object, e As EventArgs) Handles cbxAgentName.TextChanged
        If cbxAgentName.Text = "" Then
            txtAgentContact.Text = ""
        End If
    End Sub

    Private Sub CbxAgentNameV2_TextChanged(sender As Object, e As EventArgs) Handles cbxAgentNameV2.TextChanged
        If cbxAgentNameV2.Text = "" Then
            txtAgentContactV2.Text = ""
        End If
    End Sub

    Private Sub CbxMarketingName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxMarketingName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxMarketingName.SelectedIndex = -1 Or cbxMarketingName.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxMarketingName.SelectedItem, DataRowView)
            txtMarketingContact.Text = drv("Phone")
        End If
    End Sub

    Private Sub CbxMarketingName_TextChanged(sender As Object, e As EventArgs) Handles cbxMarketingName.TextChanged
        If cbxMarketingName.Text = "" Then
            txtMarketingContact.Text = ""
        End If
    End Sub

    Private Sub CbxAgent_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgent.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbxAgent.Checked = True Then
                cbxAgentName.Focus()
            Else
                cbxMarketing.Focus()
            End If
        End If
    End Sub

    Private Sub CbxAgentV2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgentV2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbxAgentV2.Checked = True Then
                cbxAgentNameV2.Focus()
            Else
                cbxMarketing.Focus()
            End If
        End If
    End Sub

    Private Sub CbxAgentName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgentName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAgentContact.Focus()
        End If
    End Sub

    Private Sub CbxAgentNameV2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgentNameV2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAgentContactV2.Focus()
        End If
    End Sub

    Private Sub TxtAgentContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAgentContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMarketing.Focus()
        End If
    End Sub

    Private Sub TxtAgentContactV2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAgentContactV2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMarketing.Focus()
        End If
    End Sub

    Private Sub CbxMarketing_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarketing.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbxMarketing.Checked = True Then
                cbxMarketingName.Focus()
            Else
                cbxWalkIn.Focus()
            End If
        End If
    End Sub

    Private Sub CbxMarketingName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarketingName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMarketingContact.Focus()
        End If
    End Sub

    Private Sub TxtMarketingContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarketingContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxWalkIn.Focus()
        End If
    End Sub

    Private Sub CbxWalkIn_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxWalkIn.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbxWalkIn.Checked = True Then
                cbxWalkInType.Focus()
            Else
                cbxDealer.Focus()
            End If
        End If
    End Sub

    Private Sub TxtWalkInOthers_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWalkInOthers.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDealer.Focus()
        End If
    End Sub

    Private Sub CbxDealer_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDealer.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbxDealer.Checked = True Then
                cbxDealerName.Focus()
            End If
        End If
    End Sub

    Private Sub CbxDealerName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDealerName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDealersContact.Focus()
        End If
    End Sub

    Private Sub TxtDealersContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtDealersContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmROPOA_Referral_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            Dim AgentID As String = ""
            Dim Agent As String = ""
            Dim AgentNo As String = ""
            Dim AgentID_2 As String = ""
            Dim Agent_2 As String = ""
            Dim AgentNo_2 As String = ""
            Dim MarketingID As String = ""
            Dim Marketing As String = ""
            Dim MarketingNo As String = ""
            Dim WalkinID As String = ""
            Dim Walkin As String = ""
            Dim Walkin_Specify As String = ""
            Dim DealerID As String = ""
            Dim Dealer As String = ""
            Dim DealerNo As String = ""
            If cbxAgent.Checked Then
                If (cbxAgentName.SelectedIndex = -1 Or cbxAgentName.Text = "") Then
                    MsgBox("Please select agent from the list.", MsgBoxStyle.Information, "Info")
                    cbxAgentName.Focus()
                    cbxAgentName.DroppedDown = True
                    Exit Sub
                Else
                    AgentID = cbxAgentName.SelectedValue
                    Agent = cbxAgentName.Text
                    AgentNo = txtAgentContact.Text
                End If
            End If
            If cbxAgentV2.Checked Then
                If (cbxAgentNameV2.SelectedIndex = -1 Or cbxAgentNameV2.Text = "") Then
                    MsgBox("Please select agent from the list.", MsgBoxStyle.Information, "Info")
                    cbxAgentNameV2.Focus()
                    cbxAgentNameV2.DroppedDown = True
                    Exit Sub
                Else
                    AgentID_2 = cbxAgentNameV2.SelectedValue
                    Agent_2 = cbxAgentNameV2.Text
                    AgentNo_2 = txtAgentContactV2.Text
                End If
            End If
            If cbxAgent.Checked And cbxAgentV2.Checked Then
                If (cbxAgentName.Text = cbxAgentNameV2.Text) Then
                    MsgBox("The same agent is selected, please select another agent.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
            End If
            If cbxMarketing.Checked Then
                If (cbxMarketingName.SelectedIndex = -1 Or cbxMarketingName.Text = "") Then
                    MsgBox("Please select account officer from the list.", MsgBoxStyle.Information, "Info")
                    cbxMarketingName.Focus()
                    cbxMarketingName.DroppedDown = True
                    Exit Sub
                Else
                    MarketingID = cbxMarketingName.SelectedValue
                    Marketing = cbxMarketingName.Text
                    MarketingNo = txtMarketingContact.Text
                End If
            End If
            If cbxWalkIn.Checked Then
                If (cbxWalkInType.SelectedIndex = -1 Or cbxWalkInType.Text = "") Then
                    MsgBox("Please select walk in from the list.", MsgBoxStyle.Information, "Info")
                    cbxWalkInType.Focus()
                    cbxWalkInType.DroppedDown = True
                    Exit Sub
                Else
                    WalkinID = cbxWalkInType.SelectedValue
                    Walkin = cbxWalkInType.Text
                    Walkin_Specify = txtWalkInOthers.Text
                End If
            End If
            If cbxDealer.Checked Then
                If (cbxDealerName.SelectedIndex = -1 Or cbxDealerName.Text = "") Then
                    MsgBox("Please select dealer from the list.", MsgBoxStyle.Information, "Info")
                    cbxDealerName.Focus()
                    cbxDealerName.DroppedDown = True
                    Exit Sub
                Else
                    DealerID = cbxDealerName.SelectedValue
                    Dealer = cbxDealerName.Text
                    DealerNo = txtDealersContact.Text
                End If
            End If

            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim SQL As String = "UPDATE credit_application SET"
                SQL &= String.Format(" `AgentID` = '{0}', ", AgentID)
                SQL &= String.Format(" Agent = '{0}', ", Agent)
                SQL &= String.Format(" AgentNo = '{0}', ", AgentNo)
                SQL &= String.Format(" `AgentID_2` = '{0}', ", AgentID_2)
                SQL &= String.Format(" Agent_2 = '{0}', ", Agent_2)
                SQL &= String.Format(" AgentNo_2 = '{0}', ", AgentNo_2)
                SQL &= String.Format(" `MarketingID` = '{0}', ", MarketingID)
                SQL &= String.Format(" Marketing = '{0}', ", Marketing)
                SQL &= String.Format(" MarketingNo = '{0}', ", MarketingNo)
                SQL &= String.Format(" `WalkinID` = '{0}', ", WalkinID)
                SQL &= String.Format(" WalkIn = '{0}', ", Walkin)
                SQL &= String.Format(" WalkIn_Specify = '{0}', ", Walkin_Specify)
                SQL &= String.Format(" `DealerID` = '{0}', ", DealerID)
                SQL &= String.Format(" Dealer = '{0}', ", Dealer)
                SQL &= String.Format(" DealerNo = '{0}' ", DealerNo)
                SQL &= String.Format(" WHERE CreditNumber = '{0}';", CreditNumber)
                DataObject(SQL)
                Logs("Credit Referral", "Update", String.Format("Update Credit Referral Information for Credit Number {0}", CreditNumber), Changes(), "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxAgentName.Text = cbxAgentName.Tag Then
            Else
                Change &= String.Format("Change Agent from {0} to {1}. ", cbxAgentName.Tag, cbxAgentName.Text)
            End If
            If txtAgentContact.Text = txtAgentContact.Tag Then
            Else
                Change &= String.Format("Change Agent No. from {0} to {1}. ", txtAgentContact.Tag, txtAgentContact.Text)
            End If
            If cbxAgentNameV2.Text = cbxAgentNameV2.Tag Then
            Else
                Change &= String.Format("Change Agent 2 from {0} to {1}. ", cbxAgentNameV2.Tag, cbxAgentNameV2.Text)
            End If
            If txtAgentContactV2.Text = txtAgentContactV2.Tag Then
            Else
                Change &= String.Format("Change Agent 2 No. from {0} to {1}. ", txtAgentContactV2.Tag, txtAgentContactV2.Text)
            End If
            If cbxMarketingName.Text = cbxMarketingName.Tag Then
            Else
                Change &= String.Format("Change Account Officer from {0} to {1}. ", cbxMarketingName.Tag, cbxMarketingName.Text)
            End If
            If txtMarketingContact.Text = txtMarketingContact.Tag Then
            Else
                Change &= String.Format("Change Account Officer No. from {0} to {1}. ", txtMarketingContact.Tag, txtMarketingContact.Text)
            End If
            If cbxWalkInType.Text = cbxWalkInType.Tag Then
            Else
                Change &= String.Format("Change Walkin Type from {0} to {1}. ", cbxWalkInType.Tag, cbxWalkInType.Text)
            End If
            If txtWalkInOthers.Text = txtWalkInOthers.Tag Then
            Else
                Change &= String.Format("Change Walkin Specify from {0} to {1}. ", txtWalkInOthers.Tag, txtWalkInOthers.Text)
            End If
            If cbxDealerName.Text = cbxDealerName.Tag Then
            Else
                Change &= String.Format("Change Dealer from {0} to {1}. ", cbxDealerName.Tag, cbxDealerName.Text)
            End If
            If txtDealersContact.Text = txtDealersContact.Tag Then
            Else
                Change &= String.Format("Change Dealer No. from {0} to {1}. ", txtDealersContact.Tag, txtDealersContact.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Credit Referral - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function
End Class