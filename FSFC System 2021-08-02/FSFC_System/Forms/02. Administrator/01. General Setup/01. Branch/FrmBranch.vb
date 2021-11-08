Imports System.Drawing.Imaging
Public Class FrmBranch

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    ReadOnly DefaultImage As New DevExpress.XtraEditors.PictureEdit
    Dim FileName As String
    Public picturePath As String = ""
    Public Count As Integer = 1
    Public Type As String = "PO"
    Public xName As String = ""
    Dim Firstload As Boolean

    '*** D A T A   S T O R A G E ***'
    Dim vContactN2 As String
    Dim vContactN3 As String
    '*** D A T A   S T O R A G E ***'
    Private Sub FrmBranch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Firstload = True
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_Location.Size = New Point(461, 284)
        pb_Location.Location = New Point(691, 16)
        DefaultImage.Image = pb_Location.Image.Clone
        dtpOpened.Value = Date.Now
        SuperTabControl1.SelectedTab = tabList

        With cbxAddress
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        Dim DT_Branch As DataTable = DataSource("SELECT Branch, BranchID, CityID FROM branch WHERE `status` = 'ACTIVE' AND Microfinance = 0 ORDER BY branchID * 1;")

        With cbxBranchCode
            .ValueMember = "BranchID"
            .DisplayMember = "Branch"
            .DataSource = DT_Branch.Copy
            .SelectedIndex = -1
        End With

        With cbxBankBranch
            .ValueMember = "BranchID"
            .DisplayMember = "Branch"
            .DataSource = DT_Branch.Copy
            .SelectedIndex = -1
        End With

        LoadData()
        Firstload = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX39, LabelX40, LabelX41, LabelX43, LabelX11, LabelX155, LabelX1, LabelX2, LabelX37, LabelX5, LabelX42, LabelX6, LabelX7, LabelX8, LabelX9, LabelX3, LabelX10, LabelX12, LabelX19, LabelX26, LabelX30, LabelX4, LabelX13, LabelX20, LabelX44, LabelX25, LabelX27, LabelX28, LabelX23, LabelX14, LabelX16, LabelX15, LabelX22, LabelX33, LabelX45, LabelX52, LabelX50, LabelX35, LabelX36, LabelX46})

            GetLabelFontSettingsRed({LabelX34, LabelX51, LabelX31, LabelX32, LabelX24, LabelX17, LabelX18, LabelX21, LabelX47, LabelX49, LabelX48})

            GetCheckBoxFontSettingsRed({cbxOther_On, cbxOther_Off, cbxUseOtherBank, cbxMicrofinance, cbxNA, cbxRoundUp, cbxOverstay, cbxDeferred_On, cbxDeferred_Off, cbxAvancePrincipal_On, cbxAvancePrincipal_Off, cbxSMS_On, cbxSMS_Off, cbxEmail_On, cbxEmail_Off, cbxAuto_On, cbxAuto_Off})

            GetLabelWithBackgroundFontSettings({LabelX29, LabelX38})

            GetButtonFontSettings({btnAdd, btnTariff, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnMap, btnReset, btnBrowse})

            GetComboBoxFontSettings({cbxBranchCode, cbxAddress, cbxBankBranch, cbxApprover1, cbxApprover2, cbxApprover3, cbxApprover4})

            GetDateTimeInputFontSettings({dtpOpened})

            GetTextBoxFontSettings({txtBranch, txtBranchCode, txtBranchID, txtTIN, txtAddress, txtContactN1, txtContactN2, txtContactN3, txtEmailAddress, txtPath, txtEmail})

            GetDoubleInputFontSettings({dRPPD, dPenalty, dOIC, dBM, dDM, dRM, dTransactionAmount, dPettyCash, dOIC_CA, dBM_CA, dDM_CA, dRM_CA})

            GetIntegerInputFontSettings({iRPPD_Start, iAvailedRPPD, iAvailedPenalty, iOverstay, iReservation, iRedemption})

            GetTabControlFontSettings({SuperTabControl1, SuperTabControl2})
        Catch ex As Exception
            TriggerBugReport("Branch - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Branch", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        txtBranchID.Text = DataObject(String.Format("SELECT IFNULL(MAX(branchid * 1),0) + 1 FROM branch WHERE Microfinance = {0}", If(cbxMicrofinance.Checked, 1, 0)))
        txtBranchID.Text = CInt(txtBranchID.Text).ToString("D3")
        If cbxMicrofinance.Checked Then
            txtBranch.Text &= "-MF"
            txtBranchCode.Text &= "-MF"
            txtBranchID.Text &= "-MF"
        Else
            txtBranch.Text = txtBranch.Text.Replace("-MF", "")
            txtBranchCode.Text = txtBranchCode.Text.Replace("-MF", "")
            txtBranchID.Text = txtBranchID.Text.Replace("-MF", "")
        End If
        Dim SQL As String = "SELECT ID, "
        SQL &= " Branch, "
        SQL &= " branch_code AS 'Branch Code', "
        SQL &= " IF(Microfinance, LPAD(branchid,6,'0'), LPAD(branchid,3,'0')) AS 'Branch ID', Microfinance, MFBranch,"
        SQL &= " (SELECT GROUP_CONCAT(CONCAT(first_name, ' ', IF(middle_name = '',last_name, CONCAT(middle_name, ' ', last_name)))) AS 'Name' FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id = branch.ID AND UPPER(`position`) = 'BRANCH MANAGER') AS 'Branch Manager', "
        'SQL &= " (SELECT GROUP_CONCAT(CONCAT(first_name, ' ', IF(middle_name = '',last_name, CONCAT(middle_name, ' ', last_name)))) AS 'Name' FROM employee_setup WHERE `status` = 'ACTIVE' AND branch_id = branch.ID AND UPPER(`position`) = 'OFFICER-IN-CHARGE') AS 'Officer In-Charge', "
        'SQL &= " (SELECT GROUP_CONCAT(CONCAT(first_name, ' ', IF(middle_name = '',last_name, CONCAT(middle_name, ' ', last_name)))) AS 'Name' FROM employee_setup WHERE `status` = 'ACTIVE' AND FIND_IN_SET(branch.ID, (SELECT GROUP_CONCAT(UB.branchid)  FROM user_branch UB WHERE UB.status = 'ACTIVE' AND UB.EmplID = employee_setup.ID)) AND UPPER(`position`) = 'DISTRICT MANAGER') AS 'District Manager', "
        'SQL &= " (SELECT GROUP_CONCAT(CONCAT(first_name, ' ', IF(middle_name = '',last_name, CONCAT(middle_name, ' ', last_name)))) AS 'Name' FROM employee_setup WHERE `status` = 'ACTIVE' AND FIND_IN_SET(branch.ID, (SELECT GROUP_CONCAT(UB.branchid)  FROM user_branch UB WHERE UB.status = 'ACTIVE' AND UB.EmplID = employee_setup.ID)) AND UPPER(`position`) = 'REGIONAL MANAGER') AS 'Regional Manager', "
        SQL &= " TIN, Address, IFNULL((SELECT CONCAT(C.citymunDesc, ' (', IFNULL(C.zipcode,'0000'), '), ', R.regDesc, ', ', CN.country) AS 'City' FROM city_municipality C LEFT JOIN (SELECT provCode, provDesc FROM province WHERE `status` = 'ACTIVE') P ON P.provCode = C.provCode LEFT JOIN (SELECT regCode, regDesc FROM region WHERE `status` = 'ACTIVE') R ON R.regCode = C.regDesc LEFT JOIN (SELECT ID, iso, country FROM country WHERE `status` = 'ACTIVE') CN ON CN.ID = C.countryID WHERE citymunCode = Branch.CityID),'') AS 'City/Province/Region', CityID,"
        SQL &= " contactN1 AS 'Contact Num 1', "
        SQL &= " contactN2 AS 'Contact Num 2', "
        SQL &= " contactN3 AS 'Contact Num 3', "
        SQL &= " email_address AS 'Email Address', "
        SQL &= " Approver1, Employee(Approver1) AS 'Approver 1', "
        SQL &= " Approver2, Employee(Approver2) AS 'Approver 2', "
        SQL &= " Approver3, Employee(Approver3) AS 'Approver 3', "
        SQL &= " Approver4, Employee(Approver4) AS 'Approver 4', "
        SQL &= " DATE_FORMAT(start_date,'%M %d, %Y') AS 'Date Opened', PettyCash AS 'Petty Cash', IF(AllowFromOtherBranch = 1,'On','Off') AS 'Allow From Other Branch',"
        SQL &= " RPPD, RPPD_Start AS 'RPPD Start', IF(RoundUp = 1,'YES','NO') AS 'Round Up', Penalty, ConfiEmail AS 'Email', overstayed_months AS 'Overstayed Months', IF(overstayed = 1,'On','Off') AS 'Overstayed', transaction_amount AS 'Transaction Amount', ReservedDays AS 'Reserved Days', RedemptionMonth AS 'Redemption', AvailedRPPD AS 'Availed RPPD', AvailedPenalty AS 'Availed Penalty', OIC AS 'OIC Override', BM AS 'BM Override', DM AS 'DM Override', RM AS 'RM Override', OIC_CA AS 'OIC CA', BM_CA AS 'BM CA', DM_CA AS 'DM CA', RM_CA AS 'RM CA', IF(SMS = 1,'On','Off') AS 'SMS Notification', IF(Email = 1,'On','Off') AS 'Email Notification', IF(Deferred = 1,'On','Off') AS 'Deferred Income', IF(AutoNotification = 1,'On','Off') AS 'Auto Notification', IF(AdvancePrincipal = 1,'On','Off') AS 'Advance on Principal', IF(UseBank = 1,'On','Off') AS 'Use other Bank', UseBankBranchID AS 'Branch Bank' FROM branch WHERE `status` = 'ACTIVE'"
        GridControl1.DataSource = DataSource(SQL & " AND Microfinance = 0 ORDER BY branchID * 1;")
        With GridView1
            .Columns("Branch").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Branch").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .BestFitColumns()
        End With

        GridControl2.DataSource = DataSource(SQL & " AND Microfinance = 1 ORDER BY branchID * 1;")
        With GridView2
            .Columns("Branch").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Branch").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .BestFitColumns()
        End With
        Cursor = Cursors.Default
    End Sub

#Region "Keycode"
    Private Sub TxtBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtBranchCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranchCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtBranchID_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranchID.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtTIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtContactN1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactN1.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtContactN2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactN2.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtContactN3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactN3.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtEmailAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmailAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpOpened_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpOpened.KeyDown
        If e.KeyCode = Keys.Enter Then
            SuperTabControl2.SelectedTab = tabCreditApplication
            dRPPD.Focus()
        End If
    End Sub

    Private Sub DRPPD_KeyDown(sender As Object, e As KeyEventArgs) Handles dRPPD.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub IRPPD_Start_KeyDown(sender As Object, e As KeyEventArgs) Handles iRPPD_Start.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxRoundUp_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRoundUp.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DPenalty_KeyDown(sender As Object, e As KeyEventArgs) Handles dPenalty.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub IAvailedRPPD_KeyDown(sender As Object, e As KeyEventArgs) Handles iAvailedRPPD.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub IAvailedPenalty_KeyDown(sender As Object, e As KeyEventArgs) Handles iAvailedPenalty.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DOIC_KeyDown(sender As Object, e As KeyEventArgs) Handles dOIC.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DBM_KeyDown(sender As Object, e As KeyEventArgs) Handles dBM.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DDM_KeyDown(sender As Object, e As KeyEventArgs) Handles dDM.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DRM_KeyDown(sender As Object, e As KeyEventArgs) Handles dRM.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            SuperTabControl2.SelectedTab = tabROPOA
            iOverstay.Focus()
        End If
    End Sub

    Private Sub IOverstay_KeyDown(sender As Object, e As KeyEventArgs) Handles iOverstay.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxOverstay_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxOverstay.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DTransactionAmount_KeyDown(sender As Object, e As KeyEventArgs) Handles dTransactionAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub IReservation_KeyDown(sender As Object, e As KeyEventArgs) Handles iReservation.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub IRedemption_KeyDown(sender As Object, e As KeyEventArgs) Handles iRedemption.KeyDown
        If e.KeyCode = Keys.Enter Then
            SuperTabControl2.SelectedTab = tabFinancial
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DPettyCash_KeyDown(sender As Object, e As KeyEventArgs) Handles dPettyCash.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DOIC_CA_KeyDown(sender As Object, e As KeyEventArgs) Handles dOIC_CA.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DBM_CA_KeyDown(sender As Object, e As KeyEventArgs) Handles dBM_CA.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DDM_CA_KeyDown(sender As Object, e As KeyEventArgs) Handles dDM_CA.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DRM_CA_KeyDown(sender As Object, e As KeyEventArgs) Handles dRM_CA.KeyDown
        If e.KeyCode = Keys.Enter Then
            SuperTabControl2.SelectedTab = tabSettings
            cbxSMS_On.Focus()
        End If
    End Sub

    Private Sub CbxREType_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtBranch_Leave(sender As Object, e As EventArgs) Handles txtBranch.Leave
        txtBranch.Text = ReplaceText(txtBranch.Text)
    End Sub

    Private Sub TxtBranchCode_Leave(sender As Object, e As EventArgs) Handles txtBranchCode.Leave
        txtBranchCode.Text = ReplaceText(txtBranchCode.Text)
    End Sub

    Private Sub TxtBranchID_Leave(sender As Object, e As EventArgs) Handles txtBranchID.Leave
        txtBranchID.Text = ReplaceText(txtBranchID.Text)
    End Sub

    Private Sub TxtTIN_Leave(sender As Object, e As EventArgs) Handles txtTIN.Leave
        txtTIN.Text = ReplaceText(txtTIN.Text)
    End Sub

    Private Sub TxtAddress_Leave(sender As Object, e As EventArgs) Handles txtAddress.Leave
        txtAddress.Text = ReplaceText(txtAddress.Text)
    End Sub

    Private Sub TxtContactN1_Leave(sender As Object, e As EventArgs) Handles txtContactN1.Leave
        txtContactN1.Text = ReplaceText(txtContactN1.Text)
    End Sub

    Private Sub TxtContactN2_Leave(sender As Object, e As EventArgs) Handles txtContactN2.Leave
        txtContactN2.Text = ReplaceText(txtContactN2.Text)
    End Sub

    Private Sub TxtContactN3_Leave(sender As Object, e As EventArgs) Handles txtContactN3.Leave
        txtContactN3.Text = ReplaceText(txtContactN3.Text)
    End Sub

    Private Sub TxtEmailAddress_Leave(sender As Object, e As EventArgs) Handles txtEmailAddress.Leave
        txtEmailAddress.Text = ReplaceText(txtEmailAddress.Text)
    End Sub

    Private Sub TxtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        txtEmail.Text = ReplaceText(txtEmail.Text)
    End Sub
#End Region

    Private Sub CbxNA_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNA.CheckedChanged
        With dtpOpened
            If cbxNA.Checked Then
                .Enabled = False
                .CustomFormat = ""
                .Text = ""
            Else
                .Enabled = True
                .CustomFormat = "MMMM dd, yyyy"
                .Value = Date.Now
            End If
        End With
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabMicroBranch
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabBranch
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabList
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
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Or SuperTabControl1.SelectedTabIndex = 2 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            If SuperTabControl1.SelectedTabIndex = 2 Then
                btnNext.Enabled = False
            Else
                btnNext.Enabled = True
            End If
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                txtBranchID.Text = DataObject(String.Format("SELECT IFNULL(MAX(branchid * 1),0) + 1 FROM branch WHERE Microfinance = {0}", If(cbxMicrofinance.Checked, 1, 0)))
                txtBranchID.Text = CInt(txtBranchID.Text).ToString("D3")
                If cbxMicrofinance.Checked Then
                    txtBranch.Text &= "-MF"
                    txtBranchCode.Text &= "-MF"
                    txtBranchID.Text &= "-MF"
                Else
                    txtBranch.Text = txtBranch.Text.Replace("-MF", "")
                    txtBranchCode.Text = txtBranchCode.Text.Replace("-MF", "")
                    txtBranchID.Text = txtBranchID.Text.Replace("-MF", "")
                End If
                Clear(False)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Or SuperTabControl1.SelectedTabIndex = 2 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        btnTariff.Visible = False
        btnReset.Visible = False
        PanelEx10.Enabled = True
        cbxUseOtherBank.Checked = False
        SuperTabControlPanel3.Enabled = True
        SuperTabControlPanel4.Enabled = True
        SuperTabControlPanel5.Enabled = True
        SuperTabControlPanel6.Enabled = True
        SuperTabControlPanel8.Enabled = True
        txtBranch.Text = ""
        txtBranchCode.Text = ""
        txtBranchCode.Enabled = True
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        txtTIN.Text = ""
        txtAddress.Text = ""
        cbxAddress.Text = ""
        txtContactN1.Text = ""
        txtContactN2.Text = ""
        txtContactN3.Text = ""
        txtEmailAddress.Text = ""
        dtpOpened.Value = Date.Now
        txtPath.Text = ""
        pb_Location.Image = DefaultImage.Image.Clone
        dRPPD.Value = 0
        iRPPD_Start.Value = 0
        dTransactionAmount.Value = 0
        iOverstay.Value = 18
        cbxOverstay.Checked = True
        iRedemption.Value = 11
        dPettyCash.Value = 10000
        txtEmail.Text = ""
        cbxApprover1.DataSource = Nothing
        cbxApprover2.DataSource = Nothing
        cbxApprover3.DataSource = Nothing
        cbxApprover4.DataSource = Nothing
        dOIC.Value = 0
        dBM.Value = 0
        dDM.Value = 0
        dRM.Value = 0

        dOIC_CA.Value = 0
        dBM_CA.Value = 0
        dDM_CA.Value = 0
        dRM_CA.Value = 0

        If TriggerLoadData Then
            LoadData()
            cbxBranchCode.DataSource = DataSource("SELECT Branch, BranchID, CityID FROM branch WHERE `status` = 'ACTIVE' AND Microfinance = 0 ORDER BY branchID * 1;")
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtBranch.Text = "" Then
            MsgBox("Please fill branch field.", MsgBoxStyle.Information, "Info")
            txtBranch.Focus()
            Exit Sub
        End If
        If cbxMicrofinance.Checked And txtBranchCode.Text.Contains("-MF") = False Then
            MsgBox("Please fill -MF on Branch if this is a Micro Finance.", MsgBoxStyle.Information, "Info")
            txtBranch.Focus()
            Exit Sub
        End If
        If txtBranchCode.Text = "" Then
            MsgBox("Please fill branch code field.", MsgBoxStyle.Information, "Info")
            txtBranchCode.Focus()
            Exit Sub
        End If
        If cbxMicrofinance.Checked And txtBranchCode.Text.Contains("-MF") = False Then
            MsgBox("Please fill -MF on Branch Code if this is a Micro Finance.", MsgBoxStyle.Information, "Info")
            txtBranchCode.Focus()
            Exit Sub
        End If
        If cbxAddress.SelectedIndex = -1 Then
            MsgBox("Please select a City/Provice/Region.", MsgBoxStyle.Information, "Info")
            cbxAddress.DroppedDown = True
            Exit Sub
        End If
        If cbxApprover1.SelectedValue = cbxApprover2.SelectedValue Then
            If MsgBoxYes("Level 1 and Level 2 Approver are the same, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If cbxApprover1.SelectedValue = cbxApprover3.SelectedValue Then
            If MsgBoxYes("Level 1 and Level 3 Approver are the same, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If cbxApprover1.SelectedValue = cbxApprover4.SelectedValue Then
            If MsgBoxYes("Level 1 and Level 4 Approver are the same, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If cbxApprover2.SelectedValue = cbxApprover3.SelectedValue Then
            If MsgBoxYes("Level 2 and Level 3 Approver are the same, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If cbxApprover2.SelectedValue = cbxApprover4.SelectedValue Then
            If MsgBoxYes("Level 2 and Level 4 Approver are the same, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If cbxApprover3.SelectedValue = cbxApprover4.SelectedValue Then
            If MsgBoxYes("Level 3 and Level 4 Approver are the same, would you like to proceed?") = MsgBoxResult.No Then
                Exit Sub
            End If
        End If
        If dOIC.Value > dBM.Value Or dOIC.Value > dDM.Value Or dOIC.Value > dRM.Value Then
            If MsgBox("Are you sure that the Approver 1 is greater than Approver 2 or Approver 3 or Approver 4 range?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Else
                dOIC.Focus()
                Exit Sub
            End If
        End If
        If dBM.Value > dDM.Value Or dBM.Value > dRM.Value Then
            If MsgBox("Are you sure that the Approver 2 is greater than Approver 3 or Approver 4 range?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Else
                dBM.Focus()
                Exit Sub
            End If
        End If
        If dDM.Value > dRM.Value Then
            If MsgBox("Are you sure that the Approver 3 is greater than Approver 4 range?", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Else
                dDM.Focus()
                Exit Sub
            End If
        End If
        If cbxUseOtherBank.Checked And cbxBankBranch.SelectedIndex = -1 Then
            MsgBox("Use of other Branch Bank is enabled and no branch is selected, Please select branch to borrow funds.", MsgBoxStyle.Information, "Info")
            SuperTabControl2.SelectedTab = tabFinancial
            cbxBankBranch.DroppedDown = True
            Exit Sub
        ElseIf cbxUseOtherBank.Checked Then
            If cbxMicrofinance.Checked = False Then
                If CInt(cbxBankBranch.SelectedValue) = CInt(txtBranchID.Text) Then
                    MsgBox("Selected Bank Branch and Current Branch is the same, please check your data.", MsgBoxStyle.Information, "Info")
                    SuperTabControl2.SelectedTab = tabFinancial
                    cbxBankBranch.DroppedDown = True
                    Exit Sub
                End If
            End If
        End If
        If txtEmail.Text <> "" And txtEmail.Text.Contains("@") = False Then
            MsgBox("Please fill a correct email address.", MsgBoxStyle.Information, "Info")
            txtEmail.Focus()
            Exit Sub
        End If

        Dim drv_A As DataRowView = DirectCast(cbxAddress.SelectedItem, DataRowView)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                txtBranchID.Text = DataObject(String.Format("SELECT IFNULL(MAX(branchid * 1),0) + 1 FROM branch WHERE Microfinance = {0}", If(cbxMicrofinance.Checked, 1, 0)))
                txtBranchID.Text = CInt(txtBranchID.Text).ToString("D3")
                If cbxMicrofinance.Checked Then
                    txtBranchID.Text &= "-MF"
                Else
                    txtBranchID.Text = txtBranchID.Text.Replace("-MF", "")
                End If
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM branch WHERE (branch = '{0}' OR branch_code = '{1}') AND `status` = 'ACTIVE' AND Microfinance = {2}", txtBranch.Text, txtBranchCode.Text, If(cbxMicrofinance.Checked, 1, 0)))
                If Exist > 0 Then
                    If MsgBoxYes(String.Format("Either branch name ({0}) or branch code ({1}) already exist, Would you like to proceed? By clicking 'YES' this could result to a duplicate branch name or branch code.", txtBranch.Text, txtBranchCode.Text)) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO branch SET"
                SQL &= String.Format(" branch = '{0}', ", txtBranch.Text)
                SQL &= String.Format(" branch_code = '{0}', ", txtBranchCode.Text)
                SQL &= String.Format(" branchID = '{0}', ", If(cbxMicrofinance.Checked, txtBranchID.Text, txtBranchID.Text * 1))
                SQL &= String.Format(" TIN = '{0}', ", txtTIN.Text)
                SQL &= String.Format(" address = '{0}', ", txtAddress.Text)
                SQL &= String.Format(" CityID = '{0}', ", drv_A("City ID"))
                SQL &= String.Format(" ProvinceID = '{0}', ", drv_A("Province ID"))
                SQL &= String.Format(" RegionID = '{0}', ", drv_A("Region Code"))
                SQL &= String.Format(" contactN1 = '{0}', ", txtContactN1.Text)
                SQL &= String.Format(" contactN2 = '{0}', ", txtContactN2.Text)
                SQL &= String.Format(" contactN3 = '{0}', ", txtContactN3.Text)
                SQL &= String.Format(" email_address = '{0}', ", txtEmailAddress.Text)
                SQL &= String.Format(" path = '{0}', ", String.Format("{1}\\{2}", RootFolder, MainFolder, txtBranchCode.Text))
                SQL &= String.Format(" start_date = '{0}', ", If(cbxNA.Checked, "", FormatDatePicker(dtpOpened)))
                SQL &= String.Format(" RPPD = '{0}', ", dRPPD.Value)
                SQL &= String.Format(" RPPD_Start = '{0}', ", iRPPD_Start.Value)
                SQL &= String.Format(" RoundUp = '{0}', ", If(cbxRoundUp.Checked, 1, 0))
                SQL &= String.Format(" Penalty = '{0}', ", dPenalty.Value)
                SQL &= String.Format(" ReservedDays = '{0}', ", iReservation.Value)
                SQL &= String.Format(" RedemptionMonth = '{0}', ", iRedemption.Value)
                SQL &= String.Format(" AvailedRPPD = '{0}', ", iAvailedRPPD.Value)
                SQL &= String.Format(" AvailedPenalty = '{0}', ", iAvailedPenalty.Value)
                SQL &= String.Format(" Approver1 = '{0}', ", ValidateComboBox(cbxApprover1))
                SQL &= String.Format(" Approver2 = '{0}', ", ValidateComboBox(cbxApprover2))
                SQL &= String.Format(" Approver3 = '{0}', ", ValidateComboBox(cbxApprover3))
                SQL &= String.Format(" Approver4 = '{0}', ", ValidateComboBox(cbxApprover4))
                SQL &= String.Format(" OIC = '{0}', ", dOIC.Value)
                SQL &= String.Format(" BM = '{0}', ", dBM.Value)
                SQL &= String.Format(" DM = '{0}', ", dDM.Value)
                SQL &= String.Format(" RM = '{0}', ", dRM.Value)
                SQL &= String.Format(" OIC_CA = '{0}', ", dOIC_CA.Value)
                SQL &= String.Format(" BM_CA = '{0}', ", dBM_CA.Value)
                SQL &= String.Format(" DM_CA = '{0}', ", dDM_CA.Value)
                SQL &= String.Format(" RM_CA = '{0}', ", dRM_CA.Value)
                SQL &= String.Format(" overstayed_months = '{0}',", iOverstay.Value)
                SQL &= String.Format(" overstayed = '{0}',", If(cbxOverstay.Checked, 1, 0))
                SQL &= String.Format(" ConfiEmail = '{0}', ", txtEmail.Text)
                SQL &= String.Format(" PettyCash = '{0}', ", dPettyCash.Value)
                SQL &= String.Format(" SMS = '{0}', ", If(cbxSMS_On.Checked, 1, 0))
                SQL &= String.Format(" Email = '{0}', ", If(cbxEmail_On.Checked, 1, 0))
                SQL &= String.Format(" Deferred = '{0}', ", If(cbxDeferred_On.Checked, 1, 0))
                SQL &= String.Format(" AutoNotification = '{0}', ", If(cbxAuto_On.Checked, 1, 0))
                SQL &= String.Format(" AdvancePrincipal = '{0}', ", If(cbxAvancePrincipal_On.Checked, 1, 0))
                SQL &= String.Format(" AllowFromOtherBranch = '{0}', ", If(cbxOther_On.Checked, 1, 0))
                SQL &= String.Format(" UseBank = '{0}', ", If(cbxUseOtherBank.Checked, 1, 0))
                SQL &= String.Format(" UseBankBranchID = '{0}', ", ValidateComboBox(cbxBankBranch))
                SQL &= String.Format(" Microfinance = '{0}', ", If(cbxMicrofinance.Checked, 1, 0))
                If cbxMicrofinance.Checked Then
                    SQL &= String.Format(" MFBranch = '{0}', ", If(cbxBranchCode.SelectedIndex = -1, "", cbxBranchCode.SelectedValue))
                End If
                SQL &= String.Format(" transaction_amount = '{0}'; ", dTransactionAmount.Value)
                DataObject(SQL)
                Cursor = Cursors.Default

                SaveImage("Location")
                Logs("Branch", "Save", String.Format("Add new branch {0}", txtBranch.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM branch WHERE (branch = '{0}' OR branch_code = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}' AND Microfinance = {3}", txtBranch.Text, txtBranchCode.Text, ID, If(cbxMicrofinance.Checked, 1, 0)))
                If Exist > 0 Then
                    If MsgBoxYes(String.Format("Either branch name ({0}) or branch code ({1}) already exist, Would you like to proceed? By clicking 'YES' this could result to a duplicate branch name or branch code.", txtBranch.Text, txtBranchCode.Text)) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE branch SET"
                SQL &= String.Format("  branch = '{0}', ", txtBranch.Text)
                SQL &= String.Format("  branch_code = '{0}', ", txtBranchCode.Text)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN.Text)
                SQL &= String.Format(" address = '{0}', ", txtAddress.Text)
                SQL &= String.Format(" CityID = '{0}', ", drv_A("City ID"))
                SQL &= String.Format(" ProvinceID = '{0}', ", drv_A("Province ID"))
                SQL &= String.Format(" RegionID = '{0}', ", drv_A("Region Code"))
                SQL &= String.Format(" contactN1 = '{0}', ", txtContactN1.Text)
                SQL &= String.Format(" contactN2 = '{0}', ", txtContactN2.Text)
                SQL &= String.Format(" contactN3 = '{0}', ", txtContactN3.Text)
                SQL &= String.Format(" email_address = '{0}', ", txtEmailAddress.Text)
                SQL &= String.Format(" path = '{0}', ", String.Format("{1}\\{2}", RootFolder, MainFolder, txtBranchCode.Text))
                SQL &= String.Format("  start_date = '{0}', ", If(cbxNA.Checked, "", FormatDatePicker(dtpOpened)))
                SQL &= String.Format(" RPPD = '{0}', ", dRPPD.Value)
                SQL &= String.Format(" RPPD_Start = '{0}', ", iRPPD_Start.Value)
                SQL &= String.Format(" RoundUp = '{0}', ", If(cbxRoundUp.Checked, 1, 0))
                SQL &= String.Format(" Penalty = '{0}', ", dPenalty.Value)
                SQL &= String.Format(" ReservedDays = '{0}', ", iReservation.Value)
                SQL &= String.Format(" RedemptionMonth = '{0}', ", iRedemption.Value)
                SQL &= String.Format(" AvailedRPPD = '{0}', ", iAvailedRPPD.Value)
                SQL &= String.Format(" AvailedPenalty = '{0}', ", iAvailedPenalty.Value)
                SQL &= String.Format(" Approver1 = '{0}', ", ValidateComboBox(cbxApprover1))
                SQL &= String.Format(" Approver2 = '{0}', ", ValidateComboBox(cbxApprover2))
                SQL &= String.Format(" Approver3 = '{0}', ", ValidateComboBox(cbxApprover3))
                SQL &= String.Format(" Approver4 = '{0}', ", ValidateComboBox(cbxApprover4))
                SQL &= String.Format(" OIC = '{0}', ", dOIC.Value)
                SQL &= String.Format(" BM = '{0}', ", dBM.Value)
                SQL &= String.Format(" DM = '{0}', ", dDM.Value)
                SQL &= String.Format(" RM = '{0}', ", dRM.Value)
                SQL &= String.Format(" OIC_CA = '{0}', ", dOIC_CA.Value)
                SQL &= String.Format(" BM_CA = '{0}', ", dBM_CA.Value)
                SQL &= String.Format(" DM_CA = '{0}', ", dDM_CA.Value)
                SQL &= String.Format(" RM_CA = '{0}', ", dRM_CA.Value)
                SQL &= String.Format(" overstayed_months = '{0}',", iOverstay.Value)
                SQL &= String.Format(" overstayed = '{0}',", If(cbxOverstay.Checked, 1, 0))
                SQL &= String.Format(" ConfiEmail = '{0}', ", txtEmail.Text)
                SQL &= String.Format(" PettyCash = '{0}', ", dPettyCash.Value)
                SQL &= String.Format(" SMS = '{0}', ", If(cbxSMS_On.Checked, 1, 0))
                SQL &= String.Format(" Email = '{0}', ", If(cbxEmail_On.Checked, 1, 0))
                SQL &= String.Format(" Deferred = '{0}', ", If(cbxDeferred_On.Checked, 1, 0))
                SQL &= String.Format(" AutoNotification = '{0}', ", If(cbxAuto_On.Checked, 1, 0))
                SQL &= String.Format(" AdvancePrincipal = '{0}', ", If(cbxAvancePrincipal_On.Checked, 1, 0))
                SQL &= String.Format(" AllowFromOtherBranch = '{0}', ", If(cbxOther_On.Checked, 1, 0))
                SQL &= String.Format(" UseBank = '{0}', ", If(cbxUseOtherBank.Checked, 1, 0))
                SQL &= String.Format(" UseBankBranchID = '{0}', ", ValidateComboBox(cbxBankBranch))
                SQL &= String.Format(" Microfinance = '{0}', ", If(cbxMicrofinance.Checked, 1, 0))
                If cbxMicrofinance.Checked Then
                    SQL &= String.Format(" MFBranch = '{0}', ", If(cbxBranchCode.SelectedIndex = -1, "", cbxBranchCode.SelectedValue))
                End If
                SQL &= String.Format(" transaction_amount = '{0}' ", dTransactionAmount.Value)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                SaveImage("Location")
                Logs("Branch", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtBranch.Text = txtBranch.Tag Then
            Else
                Change &= String.Format("Change Branch from {0} to {1}. ", txtBranch.Tag, txtBranch.Text)
            End If
            If txtBranchCode.Text = txtBranchCode.Tag Then
            Else
                Change &= String.Format("Change Branch Code from {0} to {1}. ", txtBranchCode.Tag, txtBranchCode.Text)
            End If
            If txtTIN.Text = txtTIN.Tag Then
            Else
                Change &= String.Format("Change TIN from {0} to {1}. ", txtTIN.Tag, txtTIN.Text)
            End If
            If txtAddress.Text = txtAddress.Tag Then
            Else
                Change &= String.Format("Change Address from {0} to {1}. ", txtAddress.Tag, txtAddress.Text)
            End If
            If cbxAddress.Text = cbxAddress.Tag Then
            Else
                Change &= String.Format("Change City/Province/Region from {0} to {1}. ", cbxAddress.Tag, cbxAddress.Text)
            End If
            If txtContactN1.Text = txtContactN1.Tag Then
            Else
                Change &= String.Format("Change Contact Number 1 from {0} to {1}. ", txtContactN1.Tag, txtContactN1.Text)
            End If
            If txtContactN2.Text = txtContactN2.Tag Then
            Else
                Change &= String.Format("Change Contact Number 2 from {0} to {1}. ", txtContactN2.Tag, txtContactN2.Text)
            End If
            If txtContactN3.Text = txtContactN3.Tag Then
            Else
                Change &= String.Format("Change Contact Number 3 from {0} to {1}. ", txtContactN3.Tag, txtContactN3.Text)
            End If
            If txtEmailAddress.Text = txtEmailAddress.Tag Then
            Else
                Change &= String.Format("Change Email Address from {0} to {1}. ", txtEmailAddress.Tag, txtEmailAddress.Text)
            End If
            If dtpOpened.Text = dtpOpened.Tag Then
            Else
                Change &= String.Format("Change Date Opened from {0} to {1}. ", dtpOpened.Tag, dtpOpened.Text)
            End If
            If dRPPD.Value = dRPPD.Tag Then
            Else
                Change &= String.Format("Change RPPD Rate from {0} to {1}. ", dRPPD.Tag, dRPPD.Text)
            End If
            If iRPPD_Start.Value = iRPPD_Start.Tag Then
            Else
                Change &= String.Format("Change RPPD Start from {0} to {1}. ", iRPPD_Start.Tag, iRPPD_Start.Text)
            End If
            If If(cbxRoundUp.Checked, "YES", "NO") = cbxRoundUp.Tag Then
            Else
                Change &= String.Format("Change Round Up Decimal 0.50 from {0} to {1}. ", cbxRoundUp.Tag, If(cbxRoundUp.Checked, "YES", "NO"))
            End If
            If dPenalty.Value = dPenalty.Tag Then
            Else
                Change &= String.Format("Change Penalty from {0} to {1}. ", dPenalty.Tag, dPenalty.Text)
            End If
            If txtEmail.Text = txtEmail.Tag Then
            Else
                Change &= String.Format("Change Email Address from {0} to {1}. ", txtEmail.Tag, txtEmail.Text)
            End If
            If iAvailedRPPD.Value = iAvailedRPPD.Tag Then
            Else
                Change &= String.Format("Change Availed RPPD from {0} to {1}. ", iAvailedRPPD.Tag, iAvailedRPPD.Text)
            End If
            If iAvailedPenalty.Value = iAvailedPenalty.Tag Then
            Else
                Change &= String.Format("Change Availed Penalty from {0} to {1}. ", iAvailedPenalty.Tag, iAvailedPenalty.Text)
            End If
            If dOIC.Value = dOIC.Tag Then
            Else
                Change &= String.Format("Change OIC Override from {0} to {1}. ", dOIC.Tag, dOIC.Text)
            End If
            If dBM.Value = dBM.Tag Then
            Else
                Change &= String.Format("Change BM Override from {0} to {1}. ", dBM.Tag, dBM.Text)
            End If
            If dDM.Value = dDM.Tag Then
            Else
                Change &= String.Format("Change DM Override from {0} to {1}. ", dDM.Tag, dDM.Text)
            End If
            If dRM.Value = dRM.Tag Then
            Else
                Change &= String.Format("Change RM Override from {0} to {1}. ", dRM.Tag, dRM.Text)
            End If
            If iOverstay.Value = iOverstay.Tag Then
            Else
                Change &= String.Format("Change Overstay Months from {0} to {1}. ", iOverstay.Tag, iOverstay.Text)
            End If
            If cbxOverstay.Tag <> "On" And cbxOverstay.Checked Then
                Change &= String.Format("Change Overstay from {0} to {1}. ", cbxOverstay.Tag, "On")
            ElseIf cbxOverstay.Tag <> "Off" And cbxOverstay.Checked = False Then
                Change &= String.Format("Change Overstay from {0} to {1}. ", cbxOverstay.Tag, "Off")
            End If
            If dTransactionAmount.Value = dTransactionAmount.Tag Then
            Else
                Change &= String.Format("Change Transaction Amount Limit from {0} to {1}. ", dTransactionAmount.Tag, dTransactionAmount.Text)
            End If
            If iReservation.Value = iReservation.Tag Then
            Else
                Change &= String.Format("Change Reservation Days from {0} to {1}. ", iReservation.Tag, iReservation.Text)
            End If
            If iRedemption.Value = iRedemption.Tag Then
            Else
                Change &= String.Format("Change Redemption Month from {0} to {1}. ", iRedemption.Tag, iRedemption.Text)
            End If
            If dPettyCash.Value = dPettyCash.Tag Then
            Else
                Change &= String.Format("Change Petty Cash Limit from {0} to {1}. ", dPettyCash.Tag, dPettyCash.Text)
            End If
            If dOIC_CA.Value = dOIC_CA.Tag Then
            Else
                Change &= String.Format("Change OIC Cash Advance Approval from {0} to {1}. ", dOIC_CA.Tag, dOIC_CA.Text)
            End If
            If dBM_CA.Value = dBM_CA.Tag Then
            Else
                Change &= String.Format("Change BM Cash Advance Approval from {0} to {1}. ", dBM_CA.Tag, dBM_CA.Text)
            End If
            If dDM_CA.Value = dDM_CA.Tag Then
            Else
                Change &= String.Format("Change DM Cash Advance Approval from {0} to {1}. ", dDM_CA.Tag, dDM_CA.Text)
            End If
            If dRM_CA.Value = dRM_CA.Tag Then
            Else
                Change &= String.Format("Change RM Cash Advance Approval from {0} to {1}. ", dRM_CA.Tag, dRM_CA.Text)
            End If
            If If(cbxSMS_On.Checked, "On", "Off") = cbxSMS_On.Tag Then
            Else
                Change &= String.Format("Change SMS Notification from {0} to {1}. ", cbxSMS_On.Tag, If(cbxSMS_On.Checked, "On", "Off"))
            End If
            If If(cbxEmail_On.Checked, "On", "Off") = cbxEmail_On.Tag Then
            Else
                Change &= String.Format("Change Email Notification from {0} to {1}. ", cbxEmail_On.Tag, If(cbxEmail_On.Checked, "On", "Off"))
            End If
            If If(cbxOther_On.Checked, "On", "Off") = cbxOther_On.Tag Then
            Else
                Change &= String.Format("Change Allow From Other Branch PCV and CAS from {0} to {1}. ", cbxOther_On.Tag, If(cbxOther_On.Checked, "On", "Off"))
            End If
            If If(cbxDeferred_On.Checked, "On", "Off") = cbxDeferred_On.Tag Then
            Else
                Change &= String.Format("Change Deferred Income from {0} to {1}. ", cbxDeferred_On.Tag, If(cbxDeferred_On.Checked, "On", "Off"))
            End If
            If If(cbxAuto_On.Checked, "On", "Off") = cbxAuto_On.Tag Then
            Else
                Change &= String.Format("Change Auto Notification from {0} to {1}. ", cbxAuto_On.Tag, If(cbxAuto_On.Checked, "On", "Off"))
            End If
            If If(cbxAvancePrincipal_On.Checked, "On", "Off") = cbxAvancePrincipal_On.Tag Then
            Else
                Change &= String.Format("Change Advance on Principal from {0} to {1}. ", cbxAvancePrincipal_On.Tag, If(cbxAvancePrincipal_On.Checked, "On", "Off"))
            End If
            If If(cbxUseOtherBank.Checked, "On", "Off") = cbxUseOtherBank.Tag Then
            Else
                Change &= String.Format("Change Use other Bank from {0} to {1}. ", cbxUseOtherBank.Tag, If(cbxUseOtherBank.Checked, "On", "Off"))
            End If
        Catch ex As Exception
            TriggerBugReport("Branch - Changes", ex.Message.ToString)
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
            SuperTabControlPanel3.Enabled = True
            SuperTabControlPanel4.Enabled = True
            SuperTabControlPanel5.Enabled = True
            SuperTabControlPanel6.Enabled = True
            SuperTabControlPanel8.Enabled = True
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
            DataObject(String.Format("UPDATE branch SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Branch", "Cancel", Reason, String.Format("Cancel branch {0}", txtBranch.Text), "", "", "")
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
        If SuperTabControl1.SelectedTabIndex = 1 Then
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("BRANCH LIST", GridControl1)
            Logs("Branch", "Print", "[SENSITIVE] Print Branch List", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            GridView2.OptionsPrint.UsePrintStyles = False
            StandardPrinting("MICROFINANCE BRANCH LIST", GridControl2)
            Logs("Branch", "Print", "[SENSITIVE] Print Microfinance Branch List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim OFD As New OpenFileDialog
        With OFD
            .Filter = "Image File|*.jpg;*.jpeg;*.png"
            '.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
            If (.ShowDialog() = DialogResult.OK) Then
                Try
                    pb_Location.Image.Dispose()
                    txtPath.Text = .FileName
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(txtPath.Text)
                        ResizeImages(TempPB.Image.Clone, pb_Location, 650, 500)
                        TempPB.Dispose()
                    End Using
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End With
    End Sub

    Private Sub Pb_Location_Click(sender As Object, e As MouseEventArgs) Handles pb_Location.Click
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                btnBrowse.PerformClick()
            End If
        Catch ex As Exception
            TriggerBugReport("Branch - Location Click", ex.Message.ToString)
        End Try
    End Sub

    Private Sub TxtContactN1_TextChanged(sender As Object, e As EventArgs) Handles txtContactN1.TextChanged
        If txtContactN1.Text.Trim = "" Then
            txtContactN2.Enabled = False

            vContactN2 = txtContactN2.Text
            txtContactN2.Text = ""
        Else
            txtContactN2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vContactN2 = "" Then
            Else
                If txtContactN2.Text = "" Then
                    txtContactN2.Text = vContactN2
                End If
            End If
        End If
    End Sub

    Private Sub TxtContactN2_TextChanged(sender As Object, e As EventArgs) Handles txtContactN2.TextChanged
        If txtContactN2.Text.Trim = "" Then
            txtContactN3.Enabled = False

            vContactN3 = txtContactN3.Text
            txtContactN3.Text = ""
        Else
            txtContactN3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vContactN3 = "" Then
            Else
                If txtContactN3.Text = "" Then
                    txtContactN3.Text = vContactN3
                End If
            End If
        End If
    End Sub

    Public Sub SaveImage(Description As String)
        'Exit Sub
        If UCase(_ServerName) = "LOCALHOST" Then
            FileName = Description & ".jpg"
            '********CREATE FOLDER FSFC System
            If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
            End If
            '********CREATE FOLDER Branch
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, txtBranchCode.Text.Trim)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, txtBranchCode.Text.Trim))
            End If
            '********CREATE FOLDER Location
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Location", RootFolder, MainFolder, txtBranchCode.Text.Trim)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Location", RootFolder, MainFolder, txtBranchCode.Text.Trim))
            End If
            '********CREATE File
            Try
                pb_Location.Image.Save(String.Format("{0}\{1}\{2}\Location\{3}", RootFolder, MainFolder, txtBranchCode.Text.Trim, FileName), ImageFormat.Jpeg)
            Catch
            End Try
        Else
            FileName = Description & ".jpg"
            '********CREATE FOLDER FSFC System
            If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
            End If
            '********CREATE FOLDER Branch
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, txtBranchCode.Text.Trim)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, txtBranchCode.Text.Trim))
            End If
            '********CREATE FOLDER Location
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Location", RootFolder, MainFolder, txtBranchCode.Text.Trim)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Location", RootFolder, MainFolder, txtBranchCode.Text.Trim))
            End If
            '********CREATE File
            Try
                pb_Location.Image.Save(String.Format("{0}\{1}\{2}\Location\{3}", RootFolder, MainFolder, txtBranchCode.Text.Trim, FileName), ImageFormat.Jpeg)
            Catch
            End Try
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

    Private Sub GridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView2_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        If SuperTabControl1.SelectedTabIndex = 1 Then
            cbxMicrofinance.Checked = False
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            cbxMicrofinance.Checked = True
        End If
        SuperTabControl1.SelectedTab = tabBranch
    End Sub

    Private Sub DoubleClickX(GV As DevExpress.XtraGrid.Views.Grid.GridView)
        Try
            If GV.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        If User_Type = "ADMIN" Then
            btnReset.Visible = True
        End If
        btnTariff.Visible = True
        PanelEx10.Enabled = False
        SuperTabControlPanel3.Enabled = False
        SuperTabControlPanel4.Enabled = False
        SuperTabControlPanel5.Enabled = False
        SuperTabControlPanel6.Enabled = False
        SuperTabControlPanel8.Enabled = False
        With GV
            ID = .GetFocusedRowCellValue("ID")
            Dim DT_Empl As DataTable = DataSource(String.Format("CALL Login_GetEmployees('{0}')", ID))
            With cbxApprover1
                .DisplayMember = "Employee"
                .ValueMember = "ID"
                .DataSource = DT_Empl.Copy
            End With

            With cbxApprover2
                .DisplayMember = "Employee"
                .ValueMember = "ID"
                .DataSource = DT_Empl.Copy
            End With

            With cbxApprover3
                .DisplayMember = "Employee"
                .ValueMember = "ID"
                .DataSource = DT_Empl.Copy
            End With

            With cbxApprover4
                .DisplayMember = "Employee"
                .ValueMember = "ID"
                .DataSource = DT_Empl.Copy
            End With

            txtBranch.Text = .GetFocusedRowCellValue("Branch")
            txtBranch.Tag = .GetFocusedRowCellValue("Branch")
            txtBranchCode.Text = .GetFocusedRowCellValue("Branch Code")
            txtBranchCode.Tag = .GetFocusedRowCellValue("Branch Code")
            txtBranchCode.Enabled = False
            txtBranchID.Text = .GetFocusedRowCellValue("Branch ID")
            txtBranchID.Tag = .GetFocusedRowCellValue("Branch ID")
            cbxMicrofinance.Checked = .GetFocusedRowCellValue("Microfinance")
            If cbxMicrofinance.Checked Then
                cbxBranchCode.Visible = True
                cbxBranchCode.SelectedValue = .GetFocusedRowCellValue("MFBranch")
            Else
                cbxBranchCode.Visible = False
                cbxBranchCode.SelectedIndex = -1
            End If
            txtTIN.Text = .GetFocusedRowCellValue("TIN")
            txtTIN.Tag = .GetFocusedRowCellValue("TIN")
            txtAddress.Text = .GetFocusedRowCellValue("Address")
            txtAddress.Tag = .GetFocusedRowCellValue("Address")
            cbxAddress.Tag = .GetFocusedRowCellValue("City/Province/Region")
            cbxAddress.Text = .GetFocusedRowCellValue("City/Province/Region")
            txtContactN1.Text = .GetFocusedRowCellValue("Contact Num 1")
            txtContactN1.Tag = .GetFocusedRowCellValue("Contact Num 1")
            txtContactN2.Text = .GetFocusedRowCellValue("Contact Num 2")
            txtContactN2.Tag = .GetFocusedRowCellValue("Contact Num 2")
            txtContactN3.Text = .GetFocusedRowCellValue("Contact Num 3")
            txtContactN3.Tag = .GetFocusedRowCellValue("Contact Num 3")
            txtEmailAddress.Text = .GetFocusedRowCellValue("Email Address")
            txtEmailAddress.Tag = .GetFocusedRowCellValue("Email Address")
            If .GetFocusedRowCellValue("Date Opened").ToString = "" Then
                cbxNA.Checked = True
            Else
                cbxNA.Checked = False
                dtpOpened.Value = .GetFocusedRowCellValue("Date Opened").ToString
            End If
            dtpOpened.Tag = .GetFocusedRowCellValue("Date Opened").ToString
            dRPPD.Value = .GetFocusedRowCellValue("RPPD")
            dRPPD.Tag = .GetFocusedRowCellValue("RPPD")
            iRPPD_Start.Value = .GetFocusedRowCellValue("RPPD Start")
            iRPPD_Start.Tag = .GetFocusedRowCellValue("RPPD Start")

            iAvailedRPPD.Value = .GetFocusedRowCellValue("Availed RPPD")
            iAvailedRPPD.Tag = .GetFocusedRowCellValue("Availed RPPD")
            iAvailedPenalty.Value = .GetFocusedRowCellValue("Availed Penalty")
            iAvailedPenalty.Tag = .GetFocusedRowCellValue("Availed Penalty")

            cbxApprover1.Tag = .GetFocusedRowCellValue("Approver 1")
            cbxApprover1.SelectedValue = .GetFocusedRowCellValue("Approver1").ToString
            cbxApprover2.Tag = .GetFocusedRowCellValue("Approver 2")
            cbxApprover2.SelectedValue = .GetFocusedRowCellValue("Approver2").ToString
            cbxApprover3.Tag = .GetFocusedRowCellValue("Approver 3")
            cbxApprover3.SelectedValue = .GetFocusedRowCellValue("Approver3").ToString
            cbxApprover4.Tag = .GetFocusedRowCellValue("Approver 4")
            cbxApprover4.SelectedValue = .GetFocusedRowCellValue("Approver4").ToString

            dOIC.Value = .GetFocusedRowCellValue("OIC Override")
            dOIC.Tag = .GetFocusedRowCellValue("OIC Override")
            dBM.Value = .GetFocusedRowCellValue("BM Override")
            dBM.Tag = .GetFocusedRowCellValue("BM Override")
            dDM.Value = .GetFocusedRowCellValue("DM Override")
            dDM.Tag = .GetFocusedRowCellValue("DM Override")
            dRM.Value = .GetFocusedRowCellValue("RM Override")
            dRM.Tag = .GetFocusedRowCellValue("RM Override")

            iOverstay.Value = .GetFocusedRowCellValue("Overstayed Months")
            iOverstay.Tag = .GetFocusedRowCellValue("Overstayed Months")
            If .GetFocusedRowCellValue("Overstayed") = "On" Then
                cbxOverstay.Checked = True
                cbxOverstay.Tag = .GetFocusedRowCellValue("Overstayed")
            Else
                cbxOverstay.Checked = False
                cbxOverstay.Tag = .GetFocusedRowCellValue("Overstayed")
            End If
            If .GetFocusedRowCellValue("Round Up") = "YES" Then
                cbxRoundUp.Checked = True
            Else
                cbxRoundUp.Checked = False
            End If
            cbxRoundUp.Tag = .GetFocusedRowCellValue("Round Up")
            dTransactionAmount.Value = .GetFocusedRowCellValue("Transaction Amount")
            dTransactionAmount.Tag = .GetFocusedRowCellValue("Transaction Amount")
            dPenalty.Value = .GetFocusedRowCellValue("Penalty")
            dPenalty.Tag = .GetFocusedRowCellValue("Penalty")
            txtEmail.Text = .GetFocusedRowCellValue("Email")
            txtEmail.Tag = .GetFocusedRowCellValue("Email")
            iReservation.Value = .GetFocusedRowCellValue("Reserved Days")
            iReservation.Tag = .GetFocusedRowCellValue("Reserved Days")
            iRedemption.Value = .GetFocusedRowCellValue("Redemption")
            iRedemption.Tag = .GetFocusedRowCellValue("Redemption")
            dPettyCash.Value = .GetFocusedRowCellValue("Petty Cash")
            dPettyCash.Tag = .GetFocusedRowCellValue("Petty Cash")
            dOIC_CA.Value = .GetFocusedRowCellValue("OIC CA")
            dOIC_CA.Tag = .GetFocusedRowCellValue("OIC CA")
            dBM_CA.Value = .GetFocusedRowCellValue("BM CA")
            dBM_CA.Tag = .GetFocusedRowCellValue("BM CA")
            dDM_CA.Value = .GetFocusedRowCellValue("DM CA")
            dDM_CA.Tag = .GetFocusedRowCellValue("DM CA")
            dRM_CA.Value = .GetFocusedRowCellValue("RM CA")
            dRM_CA.Tag = .GetFocusedRowCellValue("RM CA")

            If .GetFocusedRowCellValue("SMS Notification") = "On" Then
                cbxSMS_On.Checked = True
            Else
                cbxSMS_Off.Checked = True
            End If
            cbxSMS_On.Tag = .GetFocusedRowCellValue("SMS Notification")
            If .GetFocusedRowCellValue("Email Notification") = "On" Then
                cbxEmail_On.Checked = True
            Else
                cbxEmail_Off.Checked = True
            End If
            cbxEmail_On.Tag = .GetFocusedRowCellValue("Email Notification")
            If .GetFocusedRowCellValue("Allow From Other Branch") = "On" Then
                cbxOther_On.Checked = True
            Else
                cbxOther_Off.Checked = True
            End If
            cbxOther_On.Tag = .GetFocusedRowCellValue("Allow From Other Branch")
            If .GetFocusedRowCellValue("Deferred Income") = "On" Then
                cbxDeferred_On.Checked = True
            Else
                cbxDeferred_Off.Checked = True
            End If
            cbxDeferred_On.Tag = .GetFocusedRowCellValue("Deferred Income")
            If .GetFocusedRowCellValue("Auto Notification") = "On" Then
                cbxAuto_On.Checked = True
            Else
                cbxAuto_Off.Checked = True
            End If
            cbxAuto_On.Tag = .GetFocusedRowCellValue("Auto Notification")
            If .GetFocusedRowCellValue("Advance on Principal") = "On" Then
                cbxAvancePrincipal_On.Checked = True
            Else
                cbxAvancePrincipal_Off.Checked = True
            End If
            cbxAvancePrincipal_On.Tag = .GetFocusedRowCellValue("Advance on Principal")
            If .GetFocusedRowCellValue("Use other Bank") = "On" Then
                cbxUseOtherBank.Checked = True
            Else
                cbxUseOtherBank.Checked = False
            End If
            cbxUseOtherBank.Tag = .GetFocusedRowCellValue("Use other Bank")
            cbxBankBranch.Tag = .GetFocusedRowCellValue("Branch Bank")
            cbxBankBranch.SelectedValue = .GetFocusedRowCellValue("Branch Bank")
        End With
        Try
            Dim Path As String = String.Format("{0}\{1}\{2}\Location\{3}", RootFolder, MainFolder, txtBranchCode.Text.Trim, FileName)
            If IO.File.Exists(Path) Then
                Using TempPB As New DevExpress.XtraEditors.PictureEdit
                    TempPB.Image = Image.FromFile(Path)
                    ResizeImages(TempPB.Image.Clone, pb_Location, 850, 700)
                End Using
            Else
                pb_Location.Image = DefaultImage.Image.Clone
            End If
        Catch ex As Exception
            TriggerBugReport("Branch - DoubleClickX", ex.Message.ToString)
        End Try

        SuperTabControl1.SelectedTab = tabBranch
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        DoubleClickX(GridView1)
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        DoubleClickX(GridView2)
    End Sub

    Private Sub CbxOverstay_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOverstay.CheckedChanged
        If cbxOverstay.Checked Then
            iOverstay.Enabled = True
        Else
            iOverstay.Enabled = False
        End If
    End Sub

    Private Sub CbxSMS_On_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSMS_On.CheckedChanged
        If cbxSMS_On.Checked Then
            cbxSMS_Off.Checked = False
        End If

        If cbxSMS_On.Checked = False And cbxSMS_Off.Checked = False Then
            cbxSMS_On.Checked = True
        End If
    End Sub

    Private Sub CbxSMS_Off_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSMS_Off.CheckedChanged
        If cbxSMS_Off.Checked Then
            cbxSMS_On.Checked = False
        End If

        If cbxSMS_On.Checked = False And cbxSMS_Off.Checked = False Then
            cbxSMS_On.Checked = True
        End If
    End Sub

    Private Sub CbxEmail_On_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEmail_On.CheckedChanged
        If cbxEmail_On.Checked Then
            cbxEmail_Off.Checked = False
        End If

        If cbxEmail_On.Checked = False And cbxEmail_Off.Checked = False Then
            cbxEmail_On.Checked = True
        End If
    End Sub

    Private Sub CbxEmail_Off_CheckedChanged(sender As Object, e As EventArgs) Handles cbxEmail_Off.CheckedChanged
        If cbxEmail_Off.Checked Then
            cbxEmail_On.Checked = False
        End If

        If cbxEmail_On.Checked = False And cbxEmail_Off.Checked = False Then
            cbxEmail_On.Checked = True
        End If
    End Sub

    Private Sub CbxAuto_On_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAuto_On.CheckedChanged
        If cbxAuto_On.Checked Then
            cbxAuto_Off.Checked = False
        End If

        If cbxAuto_On.Checked = False And cbxAuto_Off.Checked = False Then
            cbxAuto_On.Checked = True
        End If
    End Sub

    Private Sub CbxAuto_Off_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAuto_Off.CheckedChanged
        If cbxAuto_Off.Checked Then
            cbxAuto_On.Checked = False
        End If

        If cbxAuto_On.Checked = False And cbxAuto_Off.Checked = False Then
            cbxAuto_On.Checked = True
        End If
    End Sub

    Private Sub CbxOther_On_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOther_On.CheckedChanged
        If cbxOther_On.Checked Then
            cbxOther_Off.Checked = False
        End If

        If cbxOther_On.Checked = False And cbxOther_Off.Checked = False Then
            cbxOther_On.Checked = True
        End If
    End Sub

    Private Sub CbxOther_Off_CheckedChanged(sender As Object, e As EventArgs) Handles cbxOther_Off.CheckedChanged
        If cbxOther_Off.Checked Then
            cbxOther_On.Checked = False
        End If

        If cbxOther_On.Checked = False And cbxOther_Off.Checked = False Then
            cbxOther_On.Checked = True
        End If
    End Sub

    Private Sub CbxDeferred_On_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeferred_On.CheckedChanged
        If cbxDeferred_On.Checked Then
            cbxDeferred_Off.Checked = False
        End If

        If cbxDeferred_On.Checked = False And cbxDeferred_Off.Checked = False Then
            cbxDeferred_On.Checked = True
        End If
    End Sub

    Private Sub CbxDeferred_Off_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeferred_Off.CheckedChanged
        If cbxDeferred_Off.Checked Then
            cbxDeferred_On.Checked = False
        End If

        If cbxDeferred_On.Checked = False And cbxDeferred_Off.Checked = False Then
            cbxDeferred_On.Checked = True
        End If
    End Sub

    Private Sub CbxAdvancePrincipal_On_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAvancePrincipal_On.CheckedChanged
        If cbxAvancePrincipal_On.Checked Then
            cbxAvancePrincipal_Off.Checked = False
        End If

        If cbxAvancePrincipal_On.Checked = False And cbxAvancePrincipal_Off.Checked = False Then
            cbxAvancePrincipal_On.Checked = True
        End If
    End Sub

    Private Sub CbxAvancePrincipal_Off_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAvancePrincipal_Off.CheckedChanged
        If cbxAvancePrincipal_Off.Checked Then
            cbxAvancePrincipal_On.Checked = False
        End If

        If cbxAvancePrincipal_On.Checked = False And cbxAvancePrincipal_Off.Checked = False Then
            cbxAvancePrincipal_On.Checked = True
        End If
    End Sub

    Private Sub BtnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", txtAddress.Text.Replace(" ", "+").Replace("#", "")))
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", GridView1.GetFocusedRowCellValue("Address").ToString.Replace(" ", "+").Replace("#", "")))
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", GridView2.GetFocusedRowCellValue("Address").ToString.Replace(" ", "+").Replace("#", "")))
        End If
    End Sub

    Private Sub CbxMicrofinance_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMicrofinance.CheckedChanged
        If txtBranch.Enabled = False Then
            Exit Sub
        End If

        txtBranchID.Text = DataObject(String.Format("SELECT IFNULL(MAX(branchid * 1),0) + 1 FROM branch WHERE Microfinance = {0}", If(cbxMicrofinance.Checked, 1, 0)))
        txtBranchID.Text = CInt(txtBranchID.Text).ToString("D3")
        If cbxMicrofinance.Checked Then
            txtBranch.Text &= "-MF"
            txtBranchCode.Text &= "-MF"
            txtBranchID.Text &= "-MF"
            cbxBranchCode.Visible = True
        Else
            txtBranch.Text = txtBranch.Text.Replace("-MF", "")
            txtBranchCode.Text = txtBranchCode.Text.Replace("-MF", "")
            txtBranchID.Text = txtBranchID.Text.Replace("-MF", "")
            cbxBranchCode.Visible = False
        End If
    End Sub

    Private Sub CbxBranchCode_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranchCode.SelectedIndexChanged
        If cbxBranchCode.SelectedIndex = -1 Or cbxBranchCode.Text = "" Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxBranchCode.SelectedItem, DataRowView)
        cbxAddress.SelectedValue = drv("CityID")
    End Sub

    Private Sub BtnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim Reset As New FrmResetBranchData
        With Reset
            .SelectedBranchIDForReset = ID
            .SelectedBranchForReset = txtBranch.Text
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnYard_Click(sender As Object, e As EventArgs) Handles btnYard.Click
        Dim Yard As New FrmYardSetup
        With Yard
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            If txtBranchCode.Enabled = False Then
                .cbxBranch.Enabled = False
                .cbxBranch.Tag = ID
            End If
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub CbxUserBank_CheckedChanged(sender As Object, e As EventArgs) Handles cbxUseOtherBank.CheckedChanged
        If cbxUseOtherBank.Checked Then
            cbxBankBranch.Enabled = True
            If SuperTabControlPanel5.Enabled Then
                cbxBankBranch.DroppedDown = True
            End If
        Else
            cbxBankBranch.Enabled = False
            cbxBankBranch.SelectedIndex = -1
        End If
    End Sub

    Private Sub BtnTariff_Click(sender As Object, e As EventArgs) Handles btnTariff.Click
        Dim Tariff As New FrmTariff
        With Tariff
            .FromBranch = True
            .FromBranchID = ID
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub CbxApprover1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover1.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        If cbxApprover1.SelectedIndex <> -1 Then
            Dim drv As DataRowView = DirectCast(cbxApprover1.SelectedItem, DataRowView)
            LabelX44.Text = drv("Position").ToString
            dOIC.Enabled = True
            dOIC_CA.Enabled = True
        Else
            LabelX44.Text = ""
            dOIC.Enabled = False
            dOIC_CA.Enabled = False
        End If
    End Sub

    Private Sub CbxApprover1_TextChanged(sender As Object, e As EventArgs) Handles cbxApprover1.TextChanged
        If cbxApprover1.Text = "" Then
            LabelX44.Text = ""
            dOIC.Enabled = False
            dOIC_CA.Enabled = False
        End If
    End Sub

    Private Sub CbxApprover2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover2.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        If cbxApprover2.SelectedIndex <> -1 Then
            Dim drv As DataRowView = DirectCast(cbxApprover2.SelectedItem, DataRowView)
            LabelX25.Text = drv("Position").ToString
            dBM.Enabled = True
            dBM_CA.Enabled = True
        Else
            LabelX25.Text = ""
            dBM.Enabled = False
            dBM_CA.Enabled = False
        End If
    End Sub

    Private Sub CbxApprover2_TextChanged(sender As Object, e As EventArgs) Handles cbxApprover2.TextChanged
        If cbxApprover2.Text = "" Then
            LabelX25.Text = ""
            dBM.Enabled = False
            dBM_CA.Enabled = False
        End If
    End Sub

    Private Sub CbxApprover3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover3.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        If cbxApprover3.SelectedIndex <> -1 Then
            Dim drv As DataRowView = DirectCast(cbxApprover3.SelectedItem, DataRowView)
            LabelX27.Text = drv("Position").ToString
            dDM.Enabled = True
            dDM_CA.Enabled = True
        Else
            LabelX27.Text = ""
            dDM.Enabled = False
            dDM_CA.Enabled = False
        End If
    End Sub

    Private Sub CbxApprover3_TextChanged(sender As Object, e As EventArgs) Handles cbxApprover3.TextChanged
        If cbxApprover3.Text = "" Then
            LabelX27.Text = ""
            dDM.Enabled = False
            dDM_CA.Enabled = False
        End If
    End Sub

    Private Sub CbxApprover4_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover4.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        If cbxApprover4.SelectedIndex <> -1 Then
            Dim drv As DataRowView = DirectCast(cbxApprover4.SelectedItem, DataRowView)
            LabelX28.Text = drv("Position").ToString
            dRM.Enabled = True
            dRM_CA.Enabled = True
        Else
            LabelX28.Text = ""
            dRM.Enabled = False
            dRM_CA.Enabled = False
        End If
    End Sub

    Private Sub CbxApprover4_TextChanged(sender As Object, e As EventArgs) Handles cbxApprover4.TextChanged
        If cbxApprover4.Text = "" Then
            LabelX28.Text = ""
            dRM.Enabled = False
            dRM_CA.Enabled = False
        End If
    End Sub
End Class