Public Class FrmSoldROPOA

    Public AssetNumber As String
    Public TotalImage As Integer
    Public ROPOA_Ref As String
    Public BankID As Integer
    Public MultipleA As Boolean
    Dim FirstLoad As Boolean
    Public vAgent As Integer
    Public vMarketing As Integer
    Public vDealer As Integer
    Private Sub FrmSoldROPOA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        If CbxPrefix_B.Enabled Then
            With CbxPrefix_B
                .ValueMember = "ID"
                .DisplayMember = "Prefix"
                .DataSource = Prefix.Copy
                .SelectedIndex = -1
            End With

            With cbxSuffix_B
                .DisplayMember = "Suffix"
                .DataSource = Suffix.Copy
                .SelectedIndex = -1
            End With

            With cbxAddressC_B
                .ValueMember = "City ID"
                .DisplayMember = "City"
                .DataSource = City.Copy
                .SelectedIndex = -1
            End With
        End If

        With cbxAgentName
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',LastN)) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_agent WHERE `status` = 'ACTIVE' ORDER BY `Name` DESC;", Branch_ID))
            If cbxAgent.Checked Then
                .SelectedValue = vAgent
                FirstLoad = False
                cbxAgentName_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        With cbxMarketingName
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = DataSource("SELECT ID, emp_code, CONCAT(IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), IF(Last_Name = '','',Last_Name)) AS 'Name', Phone FROM employee_setup WHERE `status` = 'ACTIVE' ORDER BY `Name`;")
            If cbxMarketing.Checked Then
                .SelectedValue = vMarketing
                FirstLoad = False
                cbxMarketingName_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        With cbxDealerName
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',LastN)) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_dealer WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ORDER BY `Name` DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            If cbxDealer.Checked Then
                .SelectedValue = vDealer
                FirstLoad = False
                cbxDealerName_SelectedIndexChanged(sender, e)
                FirstLoad = True
            Else
                .SelectedIndex = -1
            End If
        End With

        dROPOAValue.Value = CDbl(DataObject(String.Format("SELECT Running_Balance('{0}')", AssetNumber)))

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX1, LabelX6, LabelX4, LabelX15, LabelX5, LabelX8, LabelX17, LabelX7})

            GetLabelWithBackgroundFontSettings({LabelX3, LabelX2, LabelX9})

            GetLabelFontSettingsRed({LabelX18})

            GetTextBoxFontSettings({TxtFirstN_B, TxtMiddleN_B, TxtLastN_B, txtNoC_B, txtStreetC_B, txtBarangayC_B, txtPlus63, txtContact_B, txtRemarks, txtAgentContact, txtMarketingContact, txtDealersContact})

            GetCheckBoxFontSettings({cbxAgent, cbxMarketing, cbxDealer})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B, cbxAddressC_B, cbxAgentName, cbxMarketingName, cbxDealerName})

            GetDoubleInputFontSettings({dSoldAmount, dSellingPrice, dROPOAValue})

            GetIntegerInputFontSettings({iDays})

            GetButtonFontSettings({btnSave, btnRefresh, btnCancel, btnAttach, btnCheckRegistry, btnPurchase})
        Catch ex As Exception
            TriggerBugReport("Sold ROPA - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Purchase ROPOA", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmSoldROPOA_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    '***Keydown
    Private Sub CbxPrefix_B_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_B.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_B.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_B.Focus()
        End If
    End Sub

    Private Sub TxtLastN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_B.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoC_B.Focus()
        End If
    End Sub

    Private Sub TxtNoC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetC_B.Focus()
        End If
    End Sub

    Private Sub TxtStreetC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayC_B.Focus()
        End If
    End Sub

    Private Sub TxtBarangayC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressC_B.Focus()
        End If
    End Sub

    Private Sub CbxAddressC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContact_B.Focus()
        End If
    End Sub

    Private Sub TxtContact_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContact_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dSoldAmount.Focus()
        End If
    End Sub

    Private Sub DAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dSoldAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            iDays.Focus()
        End If
    End Sub

    Private Sub IDays_KeyDown(sender As Object, e As KeyEventArgs) Handles iDays.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAgent.Focus()
        End If
    End Sub

    Private Sub CbxAgent_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgent.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAgentName.Focus()
        End If
    End Sub

    Private Sub CbxAgentName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgentName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAgentContact.Focus()
        End If
    End Sub

    Private Sub TxtAgentContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAgentContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMarketing.Focus()
        End If
    End Sub

    Private Sub CbxMarketing_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarketing.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMarketingName.Focus()
        End If
    End Sub

    Private Sub CbxMarketingName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarketingName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMarketingContact.Focus()
        End If
    End Sub

    Private Sub TxtMarketingContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarketingContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDealer.Focus()
        End If
    End Sub

    Private Sub CbxDealer_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDealer.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxDealerName.Focus()
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

    '***Leave
    Private Sub CbxPrefix_B_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_B.Leave
        CbxPrefix_B.Text = ReplaceText(CbxPrefix_B.Text)
    End Sub

    Private Sub TxtFirstN_B_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_B.Leave
        TxtFirstN_B.Text = ReplaceText(TxtFirstN_B.Text)
    End Sub

    Private Sub TxtMiddleN_B_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_B.Leave
        TxtMiddleN_B.Text = ReplaceText(TxtMiddleN_B.Text)
    End Sub

    Private Sub TxtLastN_B_Leave(sender As Object, e As EventArgs) Handles TxtLastN_B.Leave
        TxtLastN_B.Text = ReplaceText(TxtLastN_B.Text)
    End Sub

    Private Sub CbxSuffix_B_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_B.Leave
        cbxSuffix_B.Text = ReplaceText(cbxSuffix_B.Text)
    End Sub

    Private Sub TxtNoC_B_Leave(sender As Object, e As EventArgs) Handles txtNoC_B.Leave
        txtNoC_B.Text = ReplaceText(txtNoC_B.Text)
    End Sub

    Private Sub TxtStreetC_B_Leave(sender As Object, e As EventArgs) Handles txtStreetC_B.Leave
        txtStreetC_B.Text = ReplaceText(txtStreetC_B.Text)
    End Sub

    Private Sub TxtBarangayC_B_Leave(sender As Object, e As EventArgs) Handles txtBarangayC_B.Leave
        txtBarangayC_B.Text = ReplaceText(txtBarangayC_B.Text)
    End Sub

    Private Sub CbxAddressC_B_Leave(sender As Object, e As EventArgs) Handles cbxAddressC_B.Leave
        cbxAddressC_B.Text = ReplaceText(cbxAddressC_B.Text)
    End Sub

    Private Sub TxtContact_B_Leave(sender As Object, e As EventArgs) Handles txtContact_B.Leave
        txtContact_B.Text = ReplaceText(txtContact_B.Text)
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            CbxPrefix_B.SelectedIndex = -1
            TxtFirstN_B.Text = Nothing
            TxtMiddleN_B.Text = Nothing
            TxtLastN_B.Text = Nothing
            cbxSuffix_B.SelectedIndex = -1
            txtNoC_B.Text = Nothing
            txtStreetC_B.Text = Nothing
            txtBarangayC_B.Text = Nothing
            cbxAddressC_B.SelectedIndex = -1
            txtContact_B.Text = ""
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Purchase-" & AssetNumber
            .TotalImage = TotalImage
            .AssetNumber = AssetNumber
            .ID = AssetNumber
            If AssetNumber.Contains("ANV") Then
                .Type = "Purchase VE"
            Else
                .Type = "Purchase RE"
            End If
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If TxtFirstN_B.Text = "" Then
                MsgBox("Please fill Buyer's First Name field.", MsgBoxStyle.Information, "Info")
                TxtFirstN_B.Focus()
                Exit Sub
            End If
            If TxtLastN_B.Text = "" Then
                MsgBox("Please fill Buyer's Last Name field.", MsgBoxStyle.Information, "Info")
                TxtLastN_B.Focus()
                Exit Sub
            End If
            If txtContact_B.Text = "" Or txtContact_B.Text.Trim.Length <> 10 Or IsNumeric(txtContact_B.Text.Trim) = False Or If(txtContact_B.Text.Length > 1, txtContact_B.Text.Substring(0, 1) = 0, 0) Then
                MsgBox("Please fill a correct Buyer's Mobile Number field.", MsgBoxStyle.Information, "Info")
                If txtContact_B.Enabled = False Then
                    txtContact_B.Enabled = True
                End If
                txtContact_B.Focus()
                Exit Sub
            End If
            If dSoldAmount.Enabled Then
                If dSoldAmount.Value = 0 Then
                    MsgBox("Sold Price is Zero, Please check your data.", MsgBoxStyle.Information, "Info")
                    dSoldAmount.Focus()
                    Exit Sub
                End If
                If dROPOAValue.Value > dSoldAmount.Value Then
                    If MsgBoxYes("Book Value for this ROPOA is higher than the Sold Price, would you like to proceed?") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If
            If dSoldAmount.Enabled Then
                If dSoldAmount.Value <> dSellingPrice.Value Then
                    If MsgBoxYes("Entered amount does not match with the ropoa price, would you like to proceed?") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If
            End If

            Dim Referral As String = ""
            Dim Referral_ID As Integer = 0
            If cbxAgent.Checked Then
                Referral = "A"
                Referral_ID = ValidateComboBox(cbxAgentName)
            ElseIf cbxMarketing.Checked Then
                Referral = "M"
                Referral_ID = ValidateComboBox(cbxMarketingName)
            ElseIf cbxDealer.Checked Then
                Referral = "D"
                Referral_ID = ValidateComboBox(cbxDealerName)
            End If

            Dim Buyer As String = If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & cbxSuffix_B.Text.Trim

            If MsgBoxYes("Are you sure you want to save this transaction?") = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                'SOLD ROPOA
                'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************
                Dim SQL As String = String.Format("UPDATE tbl_impairment SET impairment_status = 'CANCELLED' WHERE impairment_status = 'PENDING' AND `status` = 'ACTIVE' AND ReferenceN = '{0}';", ROPOA_Ref)
                'C A N C E L   I M P A I R M E N T   S C H E D U L E **********************************************

                SQL &= "INSERT INTO sold_ropoa SET"
                SQL &= String.Format(" AssetNumber = '{0}', ", AssetNumber)
                SQL &= String.Format(" Prefix_B = '{0}', ", CbxPrefix_B.Text)
                SQL &= String.Format(" FirstN_B = '{0}', ", TxtFirstN_B.Text)
                SQL &= String.Format(" MiddleN_B = '{0}', ", TxtMiddleN_B.Text)
                SQL &= String.Format(" LastN_B = '{0}', ", TxtLastN_B.Text)
                SQL &= String.Format(" Suffix_B = '{0}', ", cbxSuffix_B.Text)
                SQL &= String.Format(" NoC_B = '{0}', ", txtNoC_B.Text)
                SQL &= String.Format(" StreetC_B = '{0}', ", txtStreetC_B.Text)
                SQL &= String.Format(" BarangayC_B = '{0}', ", txtBarangayC_B.Text)
                SQL &= String.Format(" AddressC_B = '{0}', ", cbxAddressC_B.Text)
                SQL &= String.Format(" Contact_N = '{0}', ", txtContact_B.Text)
                SQL &= String.Format(" Amount = '{0}', ", dSoldAmount.Value)
                SQL &= String.Format(" user_id = '{0}', ", User_ID)
                SQL &= String.Format(" reserved_days = '{0}', ", iDays.Value)
                SQL &= String.Format(" reserved_status = '{0}', ", If(iDays.Value > 0, "YES", "NO"))
                SQL &= String.Format(" Remarks = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" Referral = '{0}', ", Referral)
                SQL &= String.Format(" Referral_ID = '{0}', ", Referral_ID)
                SQL &= String.Format(" ReferenceN = '{0}', ", ROPOA_Ref)
                SQL &= String.Format(" BankID = '{0}', ", BankID)
                SQL &= String.Format(" MultipleA = '{0}', ", If(MultipleA = False, 0, 1))
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

                If AssetNumber.Contains("ANV") Then
                    If iDays.Value > 0 Then
                        SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = 'RESERVED', reserve_reason = 'Reserved By {1} up to {2}' WHERE PlateNum = '{0}';", ROPOA_Ref, Buyer, Format(Date.Now.AddDays(iDays.Value), "MM.dd.yyyy"))
                    Else
                        SQL &= String.Format("UPDATE ropoa_vehicle SET sell_status = 'RESERVED' WHERE PlateNum = '{0}';", ROPOA_Ref)
                    End If
                Else
                    If iDays.Value > 0 Then
                        SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = 'RESERVED', reserve_reason = 'Reserved By {1} up to {2}' WHERE TCT = '{0}';", ROPOA_Ref, Buyer, Format(Date.Now.AddDays(iDays.Value), "MM.dd.yyyy"))
                    Else
                        SQL &= String.Format("UPDATE ropoa_realestate SET sell_status = 'RESERVED' WHERE TCT = '{0}';", ROPOA_Ref)
                    End If
                End If
                SQL &= String.Format("UPDATE check_received SET `status` = 'ACTIVE' WHERE AssetNumber = '{0}' AND `status` = 'PENDING';", AssetNumber)
                DataObject(SQL)
                Logs("Purchase ROPOA", "Save", String.Format("Purchase of ROPOA {0}", AssetNumber), "", "", "", "")
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub CbxAgent_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgent.CheckedChanged
        If cbxAgent.Checked And cbxAgent.Enabled Then
            cbxAgentName.Enabled = True
            txtAgentContact.Enabled = True
            cbxMarketing.Checked = False
            cbxDealer.Checked = False
        Else
            cbxAgentName.Enabled = False
            cbxAgentName.Text = ""
            txtAgentContact.Enabled = False
            txtAgentContact.Text = ""
        End If
    End Sub

    Private Sub CbxMarketing_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMarketing.CheckedChanged
        If cbxMarketing.Checked And cbxMarketing.Enabled Then
            cbxMarketingName.Enabled = True
            txtMarketingContact.Enabled = True
            cbxAgent.Checked = False
            cbxDealer.Checked = False
        Else
            cbxMarketingName.Enabled = False
            cbxMarketingName.Text = ""
            txtMarketingContact.Enabled = False
            txtMarketingContact.Text = ""
        End If
    End Sub

    Private Sub CbxDealer_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDealer.CheckedChanged
        If cbxDealer.Checked And cbxDealer.Enabled Then
            cbxDealerName.Enabled = True
            txtDealersContact.Enabled = True
            cbxAgent.Checked = False
            cbxMarketing.Checked = False
        Else
            cbxDealerName.Enabled = False
            cbxDealerName.Text = ""
            txtDealersContact.Enabled = False
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

    Private Sub BtnCheckRegistry_Click(sender As Object, e As EventArgs) Handles btnCheckRegistry.Click
        Dim Sched As New FrmPurchaseSched
        With Sched
            .Buyer = If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & " ") & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & cbxSuffix_B.Text.Trim
            .ContactN = txtContact_B.Text
            .Months = 6
            .xDate = Date.Now
            .Amount = 0
            .AssetNumber = AssetNumber
            .ORNumber = ""
            .TotalPayable = dSoldAmount.Value
            .BankID = BankID
            If .ShowDialog = DialogResult.OK Then

            End If
        End With
    End Sub

    Private Sub FrmSoldROPOA_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim SQL As String = String.Format("UPDATE check_received SET `status` = 'CANCELLED' WHERE AssetNumber = '{0}' AND `status` = 'PENDING';", AssetNumber)
        DataObject(SQL)
    End Sub

    Private Sub BtnPurchase_Click(sender As Object, e As EventArgs) Handles btnPurchase.Click
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
            .From_ROPOA = True
            .AssetNumber = AssetNumber
            .cbxCash.Checked = True
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
            .cbxCAS.Checked = False

            If .ShowDialog = DialogResult.OK Then
                Close()
            End If
        End With
    End Sub
End Class