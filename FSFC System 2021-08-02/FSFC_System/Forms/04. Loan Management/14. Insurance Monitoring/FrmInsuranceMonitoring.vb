Public Class FrmInsuranceMonitoring

    Dim ID As Integer
    Dim FirstLoad As Boolean = True
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmInsuranceMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        FirstLoad = True
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpExpiry.Value = Date.Now
        SuperTabControl1.SelectedTab = tabList

        With cbxBorrower
            .DisplayMember = "Borrower"
            .ValueMember = "Credit Number"
            .DataSource = DataSource(String.Format("SELECT C.CreditNumber AS 'Credit Number', mortgage_id, CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)), ' [',CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)),']') AS 'Borrower' FROM credit_application C WHERE C.`status` = 'ACTIVE' AND C.`PaymentRequest` IN ('RELEASED','CLOSED') AND Branch_ID IN ({0}) AND mortgage_ID IN (1,2) ORDER BY `Borrower`", Branch_ID))
        End With

        With cbxProvider
            .DisplayMember = "Insurance"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, InsuranceProvider AS 'Insurance' FROM insurance_provider WHERE `status` = 'ACTIVE' ORDER BY `Insurance`;")
        End With

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

            GetLabelFontSettings({LabelX1, LabelX9, LabelX155, LabelX8, LabelX6, LabelX12, LabelX2, LabelX3, LabelX4, LabelX5, LabelX7, LabelX10})

            GetTextBoxFontSettings({txtPolicy, txtReason})

            GetComboBoxFontSettings({cbxBorrower, cbxCollateral, cbxProvider})

            GetDateTimeInputFontSettings({dtpExpiry})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetDoubleInputFontSettings({dCommissionRate, dPremium, dWitholdingTax, dNetCommission, dCoverage})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnCheckManagement})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Insurance Monitoring - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Insurance Monitoring", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    CreditNumber,"
        SQL &= "    Borrower_Credit(CreditNumber) AS 'Borrower',"
        SQL &= "    CollateralID,"
        SQL &= "    Collateral,"
        SQL &= "    InsuranceID,"
        SQL &= "    Provider,"
        SQL &= "    FORMAT(CommissionRate,2) AS 'Rate',"
        SQL &= "    FORMAT(Premium,2) AS 'Premium',"
        SQL &= "    FORMAT(WitholdingTax,2) AS 'WitholdingTax',"
        SQL &= "    FORMAT(NetCommission,2) AS 'Net Commission',"
        SQL &= "    Reason,"
        SQL &= "    FORMAT(Coverage,2) AS 'Coverage',"
        SQL &= "    DATE_FORMAT(ExpiryDate, '%M %d, %Y') AS 'Expiry Date',"
        SQL &= "    PolicyNumber AS 'Policy Number', Branch(BranchID) AS 'Branch'"
        SQL &= String.Format("  FROM insurance_monitoring WHERE `status` = 'ACTIVE' AND BranchID IN ({0}) ORDER BY Borrower;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn14.Visible = True
            GridColumn14.VisibleIndex = 11
        End If
        GridView1.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If Branch_ID = 0 Or (MultipleBranch And Multiple_ID <> "") Then
            GridColumn14.Visible = True
        Else
            GridColumn14.Visible = False
        End If

        If GridView1.RowCount > 22 Then
            GridColumn4.Width = 250 - 17
        Else
            GridColumn4.Width = 250
        End If
        Cursor = Cursors.Default
    End Sub

#Region "Keydown"
    Private Sub CbxBorrower_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBorrower.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxCollateral_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCollateral.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxProvider_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxProvider.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DCommissionRate_KeyDown(sender As Object, e As KeyEventArgs) Handles dCommissionRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DPremium_KeyDown(sender As Object, e As KeyEventArgs) Handles dPremium.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DWitholdingTax_KeyDown(sender As Object, e As KeyEventArgs) Handles dWitholdingTax.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DNetCommission_KeyDown(sender As Object, e As KeyEventArgs) Handles dNetCommission.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtReason_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReason.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DCoverage_KeyDown(sender As Object, e As KeyEventArgs) Handles dCoverage.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpExpiry_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpExpiry.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtPolicy_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPolicy.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
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
            btnPrint.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
            btnCheckManagement.Enabled = False
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnCheckManagement.Enabled = True
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
        PanelEx10.Enabled = True
        cbxBorrower.SelectedIndex = -1
        cbxBorrower.Enabled = True
        cbxProvider.Text = ""
        dCommissionRate.Value = 0
        dPremium.Value = 0
        dWitholdingTax.Value = 0
        dNetCommission.Value = 0
        txtReason.Text = ""
        dCoverage.Value = 0
        dtpExpiry.Value = Date.Now
        txtPolicy.Text = ""
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

        If cbxBorrower.Text = "" Or cbxBorrower.SelectedIndex = -1 Then
            MsgBox("Please select a borrower.", MsgBoxStyle.Information, "Info")
            cbxBorrower.DroppedDown = True
            Exit Sub
        End If
        If cbxProvider.SelectedIndex = -1 And txtReason.Text.Trim = "" Then
            MsgBox("Please fill the reason if provider is not from the list.", MsgBoxStyle.Information, "Info")
            txtReason.Focus()
            Exit Sub
        End If
        If txtPolicy.Text.Trim = "" Then
            MsgBox("Please fill the policy number.", MsgBoxStyle.Information, "Info")
            txtPolicy.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM insurance_monitoring WHERE CreditNumber = '{0}' AND PolicyNumber = '{1}' AND `status` = 'ACTIVE';", cbxBorrower.SelectedValue, txtPolicy.Text))
                If Exist > 0 Then
                    If MsgBox(String.Format("Insurance for {0} with policy number of {1} already exist, would you like to proceed?", cbxBorrower.Text, txtPolicy.Text), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO insurance_monitoring SET"
                SQL &= String.Format(" CreditNumber = '{0}', ", cbxBorrower.SelectedValue)
                SQL &= String.Format(" CollateralID = '{0}', ", ValidateComboBox(cbxCollateral))
                SQL &= String.Format(" Collateral = '{0}', ", cbxCollateral.Text.InsertQuote)
                SQL &= String.Format(" InsuranceID = '{0}', ", ValidateComboBox(cbxProvider))
                SQL &= String.Format(" Provider = '{0}', ", cbxProvider.Text.InsertQuote)
                SQL &= String.Format(" CommissionRate = '{0}', ", dCommissionRate.Value)
                SQL &= String.Format(" Premium = '{0}', ", dPremium.Value)
                SQL &= String.Format(" WitholdingTax = '{0}', ", dWitholdingTax.Value)
                SQL &= String.Format(" NetCommission = '{0}', ", dNetCommission.Value)
                SQL &= String.Format(" Reason = '{0}', ", txtReason.Text)
                SQL &= String.Format(" Coverage = '{0}', ", dCoverage.Value)
                SQL &= String.Format(" ExpiryDate = '{0}', ", FormatDatePicker(dtpExpiry))
                SQL &= String.Format(" PolicyNumber = '{0}', ", txtPolicy.Text)
                SQL &= String.Format(" BranchID = '{0}';", Branch_ID)
                DataObject(SQL)

                Logs("Insurance Monitoring", "Save", String.Format("Add new insurance for {0} with policy number of {1}", cbxBorrower.Text, txtPolicy.Text), "", "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM insurance_monitoring WHERE CreditNumber = '{0}' AND PolicyNumber = '{1}' AND ID != '{2}';", cbxBorrower.SelectedValue, txtPolicy.Text, ID))
                If Exist > 0 Then
                    If MsgBox(String.Format("Insurance for {0} with policy number of {1} already exist, would you like to proceed?", cbxBorrower.Text, txtPolicy.Text), MsgBoxStyle.YesNo, "Info") = MsgBoxResult.No Then
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
                Dim SQL As String = "UPDATE insurance_monitoring SET"
                SQL &= String.Format(" CollateralID = '{0}', ", ValidateComboBox(cbxCollateral))
                SQL &= String.Format(" Collateral = '{0}', ", cbxCollateral.Text.InsertQuote)
                SQL &= String.Format(" InsuranceID = '{0}', ", ValidateComboBox(cbxProvider))
                SQL &= String.Format(" Provider = '{0}', ", cbxProvider.Text.InsertQuote)
                SQL &= String.Format(" CommissionRate = '{0}', ", dCommissionRate.Value)
                SQL &= String.Format(" Premium = '{0}', ", dPremium.Value)
                SQL &= String.Format(" WitholdingTax = '{0}', ", dWitholdingTax.Value)
                SQL &= String.Format(" NetCommission = '{0}', ", dNetCommission.Value)
                SQL &= String.Format(" Reason = '{0}', ", txtReason.Text)
                SQL &= String.Format(" Coverage = '{0}', ", dCoverage.Value)
                SQL &= String.Format(" ExpiryDate = '{0}', ", FormatDatePicker(dtpExpiry))
                SQL &= String.Format(" PolicyNumber = '{0}' ", txtPolicy.Text)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)

                Logs("Insurance Monitoring", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxCollateral.Text = cbxCollateral.Tag Then
            Else
                Change &= String.Format("Change Collateral from {0} to {1}. ", cbxCollateral.Tag.ToString.Trim.InsertQuote, cbxCollateral.Text.Trim.InsertQuote)
            End If
            If cbxProvider.Text = cbxProvider.Tag Then
            Else
                Change &= String.Format("Change Provider from {0} to {1}. ", cbxProvider.Tag.ToString.Trim.InsertQuote, cbxProvider.Text.Trim.InsertQuote)
            End If
            If txtPolicy.Text = txtPolicy.Tag Then
            Else
                Change &= String.Format("Change Policy Number from {0} to {1}. ", txtPolicy.Tag, txtPolicy.Text)
            End If
            If dCommissionRate.Text = dCommissionRate.Tag Then
            Else
                Change &= String.Format("Change Commission Rate from {0} to {1}. ", dCommissionRate.Tag, dCommissionRate.Text)
            End If
            If dPremium.Text = dPremium.Tag Then
            Else
                Change &= String.Format("Change Premium from {0} to {1}. ", dPremium.Tag, dPremium.Text)
            End If
            If dWitholdingTax.Text = dWitholdingTax.Tag Then
            Else
                Change &= String.Format("Change Witholding Tax from {0} to {1}. ", dWitholdingTax.Tag, dWitholdingTax.Text)
            End If
            If dNetCommission.Text = dNetCommission.Tag Then
            Else
                Change &= String.Format("Change Net Commission from {0} to {1}. ", dNetCommission.Tag, dNetCommission.Text)
            End If
            If txtReason.Text = txtReason.Tag Then
            Else
                Change &= String.Format("Change Reason from {0} to {1}. ", txtReason.Tag, txtReason.Text)
            End If
            If dCoverage.Text = dCoverage.Tag Then
            Else
                Change &= String.Format("Change Coverage from {0} to {1}. ", dCoverage.Tag, dCoverage.Text)
            End If
            If dtpExpiry.Text = dtpExpiry.Tag Then
            Else
                Change &= String.Format("Change Expiry from {0} to {1}. ", dtpExpiry.Tag, dtpExpiry.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Insurance Monitoring - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE insurance_monitoring SET `status` = 'DELETED' WHERE ID = '{0}';", ID))
            Logs("Insurance Monitoring", "Cancel", Reason, String.Format("Cancel borrower {0} insurance with policy number of {1}.", cbxBorrower.Text, txtPolicy.Text), "", "", "")
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
        StandardPrinting("INSURANCE MONITORING LIST", GridControl1)
        Logs("Insurance Monitoring", "Print", "[SENSITIVE] Print Insurance Monitoring List", "", "", "", "")
        Cursor = Cursors.Default
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
            cbxBorrower.Enabled = False
            ID = .GetFocusedRowCellValue("ID")
            cbxBorrower.SelectedValue = .GetFocusedRowCellValue("CreditNumber")
            cbxCollateral.Text = .GetFocusedRowCellValue("Collateral")
            cbxCollateral.Tag = .GetFocusedRowCellValue("Collateral")
            cbxProvider.Text = .GetFocusedRowCellValue("Provider")
            cbxProvider.Tag = .GetFocusedRowCellValue("Provider")
            txtPolicy.Text = .GetFocusedRowCellValue("Policy Number")
            txtPolicy.Tag = .GetFocusedRowCellValue("Policy Number")
            dCommissionRate.Value = .GetFocusedRowCellValue("Rate")
            dCommissionRate.Tag = .GetFocusedRowCellValue("Rate")
            dPremium.Value = .GetFocusedRowCellValue("Premium")
            dPremium.Tag = .GetFocusedRowCellValue("Premium")
            dWitholdingTax.Value = .GetFocusedRowCellValue("WitholdingTax")
            dWitholdingTax.Tag = .GetFocusedRowCellValue("WitholdingTax")
            dNetCommission.Value = .GetFocusedRowCellValue("Net Commission")
            dNetCommission.Tag = .GetFocusedRowCellValue("Net Commission")
            txtReason.Text = .GetFocusedRowCellValue("Reason")
            txtReason.Tag = .GetFocusedRowCellValue("Reason")
            dCoverage.Value = .GetFocusedRowCellValue("Coverage")
            dCoverage.Tag = .GetFocusedRowCellValue("Coverage")
            dtpExpiry.Value = .GetFocusedRowCellValue("Expiry Date")
            dtpExpiry.Tag = .GetFocusedRowCellValue("Expiry Date")
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

    Private Sub TxtPolicy_Leave(sender As Object, e As EventArgs) Handles txtPolicy.Leave
        txtPolicy.Text = ReplaceText(txtPolicy.Text)
    End Sub

    Private Sub TxtReason_Leave(sender As Object, e As EventArgs) Handles txtReason.Leave
        txtReason.Text = ReplaceText(txtReason.Text)
    End Sub

    Private Sub CbxBorrower_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBorrower.SelectedIndexChanged
        If FirstLoad Or cbxBorrower.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxBorrower.SelectedItem, DataRowView)
        With cbxCollateral
            .DisplayMember = "Detail"
            .ValueMember = "ID"
            If drv("mortgage_id") = 1 Then
                .DataSource = DataSource(String.Format("SELECT ID, CONCAT(Make, ' ', Model, ' ', PlateNum) AS 'Detail' FROM collateral_ve WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND CINumber != '';", cbxBorrower.SelectedValue))
            Else
                .DataSource = DataSource(String.Format("SELECT ID, CONCAT(TCT, ' ', Location, ' (',`Area`,') sqm') AS 'Detail' FROM collateral_re WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE' AND CINumber != '';", cbxBorrower.SelectedValue))
            End If
            If .Items.Count = 0 Then
                .Text = ""
            End If
        End With
    End Sub

    Private Sub CbxBorrower_TextChanged(sender As Object, e As EventArgs) Handles cbxBorrower.TextChanged
        If cbxBorrower.Text = "" Or cbxBorrower.SelectedIndex = -1 Then
            cbxCollateral.DataSource = Nothing
        End If
    End Sub

    Private Sub CbxProvider_TextChanged(sender As Object, e As EventArgs) Handles cbxProvider.TextChanged
        If cbxProvider.SelectedIndex = -1 Then
            txtReason.Enabled = True
        Else
            txtReason.Text = ""
            txtReason.Enabled = False
        End If
    End Sub

    Private Sub BtnCheckManagement_Click(sender As Object, e As EventArgs) Handles btnCheckManagement.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim PDC As New FrmPDCManagement
        With PDC
            .SuperTabItem2.Visible = False
            .SuperTabItem3.Visible = False
            .SuperTabItem4.Visible = False
            .SuperTabItem8.Visible = False
            .SuperTabItem5.Visible = False
            .SuperTabItem6.Visible = False
            FormRestriction(22)
            If allow_Access Then
                .vSave = allow_Save
                .vUpdate = allow_Update
                .vDelete = allow_Delete
                .vPrint = allow_Print
            End If
            .FromInsurance = True
            .CreditNumber = GridView1.GetFocusedRowCellValue("CreditNumber").ToString
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub ICheckManagement_Click(sender As Object, e As EventArgs) Handles iCheckManagement.Click
        btnCheckManagement.PerformClick()
    End Sub


End Class