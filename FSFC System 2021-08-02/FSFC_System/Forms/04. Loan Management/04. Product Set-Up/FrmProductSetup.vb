Public Class FrmProductSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmProductSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With cbxCollateral
            .DisplayMember = "Collateral"
            .ValueMember = "ID"
            .DataSource = Collateral.Copy
            .SelectedIndex = -1
        End With

        With cbxMortgage
            .DisplayMember = "Mortgage"
            .ValueMember = "ID"
            .DataSource = Mortgage.Copy
            .SelectedIndex = -1
        End With

        With cbxProductType
            .DisplayMember = "ProductType"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, ProductType FROM product_type WHERE `status` = 'ACTIVE';")
            .SelectedIndex = -1
        End With

        If User_Type = "ADMIN" Then
            btnAddCollateral.Enabled = True
            btnAddMortgage.Enabled = True
        Else
            btnAddCollateral.Enabled = False
            btnAddMortgage.Enabled = False
        End If
        LoadData()
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

            GetLabelFontSettings({LabelX155, LabelX2, LabelX15, LabelX3, LabelX4, LabelX1, LabelX5, LabelX6, LabelX7, LabelX13, LabelX18, LabelX20})

            GetTextBoxFontSettings({txtProduct, txtProductCode, txtCode})

            GetLabelFontSettingsRed({LabelX16, LabelX10, LabelX9, LabelX12, LabelX8, LabelX14, LabelX17, LabelX19})

            GetComboBoxFontSettings({cbxProductType, cbxCollateral, cbxMortgage})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetDoubleInputFontSettings({dInterestRate})

            GetIntegerInputFontSettings({iMaxTerms})

            GetCheckBoxFontSettings({cbxWithCollateral, cbxMonthly, cbxBimonthly, cbxWeekly, cbxDaily, cbxYesUDI, cbxNoUDI, cbxYesPrincipal, cbxNoPrincipal, cbxYesAdvance, cbxNoAdvance, cbxYesCI, cbxNoCI, cbxGraceYes, cbxGraceNo})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Product Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Product", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        txtCode.Text = DataObject(String.Format("SELECT IFNULL(COUNT(ID),0) + 1 FROM product_setup WHERE branch_id = '{0}';", Branch_ID))
        txtCode.Text = CInt(Branch_ID).ToString("D3") & "-" & CInt(txtCode.Text).ToString("D3")
        GridControl1.DataSource = DataSource(String.Format("SELECT ID, product AS 'Product Name',`Code` AS 'Product Code', (SELECT ProductType FROM product_type WHERE ID = product_setup.product_type) AS 'Product Type', product_code AS 'Code', Collateral, Interest, max_terms AS 'Max Term', Mortgage, Payment, UDI, last_principal AS 'Last Month Principal', advance_payment AS 'Advance Payment', CI, GracePeriod AS 'Grace Period', Branch(Branch_ID) AS 'Branch' FROM product_setup WHERE `status` = 'ACTIVE' AND branch_id = '{0}';", Branch_ID))
        If Multiple_ID.Contains(",") Then
            GridColumn16.Visible = True
            GridColumn16.VisibleIndex = 13
        End If
        GridView1.Columns("Product Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Product Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 230 - 17
        Else
            GridColumn2.Width = 230
        End If
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub TxtProduct_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProduct.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtProductCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtProductCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxProductType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxProductType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxCollateral_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCollateral.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DInterestRate_KeyDown(sender As Object, e As KeyEventArgs) Handles dInterestRate.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub IMaxTerms_KeyDown(sender As Object, e As KeyEventArgs) Handles iMaxTerms.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxMortgage_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMortgage.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxMonthly_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMonthly.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxBimonthly_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBimonthly.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxDaily_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDaily.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxYesUDI_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxYesUDI.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxNoUDI_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNoUDI.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxYesPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxYesPrincipal.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxNoPrincipal_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNoPrincipal.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxYesAdvance_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxYesAdvance.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxNoAdvance_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNoAdvance.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxYesCI_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxYesCI.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxNoCI_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxNoCI.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxGraceYes_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxGraceYes.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxGraceNo_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxGraceNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtProduct_Leave(sender As Object, e As EventArgs) Handles txtProduct.Leave
        txtProduct.Text = ReplaceText(txtProduct.Text.Trim)
    End Sub

    Private Sub TxtProductCode_Leave(sender As Object, e As EventArgs) Handles txtProductCode.Leave
        txtProductCode.Text = ReplaceText(txtProductCode.Text.Trim)
    End Sub

    Private Sub TxtCode_Leave(sender As Object, e As EventArgs) Handles txtCode.Leave
        txtCode.Text = ReplaceText(txtCode.Text.Trim)
    End Sub

    Private Sub CbxCollateral_Leave(sender As Object, e As EventArgs) Handles cbxCollateral.Leave
        cbxCollateral.Text = ReplaceText(cbxCollateral.Text.Trim)
    End Sub

    Private Sub CbxMortgage_Leave(sender As Object, e As EventArgs) Handles cbxMortgage.Leave
        cbxMortgage.Text = ReplaceText(cbxMortgage.Text.Trim)
    End Sub
    '***LEAVE

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
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True

        txtProduct.Text = ""
        txtCode.Text = ""
        txtProductCode.Text = ""
        cbxWithCollateral.Checked = False
        dInterestRate.Value = 0
        iMaxTerms.Value = 0
        cbxMortgage.Text = ""
        cbxProductType.SelectedIndex = -1
        cbxCollateral.SelectedIndex = -1
        cbxMortgage.SelectedIndex = -1
        cbxMonthly.Checked = True
        cbxYesUDI.Checked = True
        cbxNoPrincipal.Checked = True
        cbxNoAdvance.Checked = True

        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub CbxWithCollateral_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWithCollateral.CheckedChanged
        If cbxWithCollateral.Checked Then
            cbxCollateral.Enabled = True
        Else
            cbxCollateral.Enabled = False
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtProduct.Text = "" Then
            MsgBox("Please fill product name field.", MsgBoxStyle.Information, "Info")
            txtProduct.Focus()
            Exit Sub
        End If

        If txtProductCode.Text = "" Then
            MsgBox("Please fill product code field.", MsgBoxStyle.Information, "Info")
            txtProductCode.Focus()
            Exit Sub
        End If

        Dim CollateralID As Integer
        Dim Coll As String = ""
        If cbxCollateral.SelectedIndex = -1 Or cbxCollateral.Text = "" Then
        Else
            Coll = cbxCollateral.Text
            CollateralID = cbxCollateral.SelectedValue
        End If
        Dim MortgageID As Integer
        Dim Mort As String = ""
        If cbxMortgage.SelectedIndex = -1 Or cbxMortgage.Text = "" Then
        Else
            Mort = cbxMortgage.Text
            MortgageID = cbxMortgage.SelectedValue
        End If
        Dim Payment As String = "Monthly"
        If cbxMonthly.Checked Then
            Payment = "Monthly"
        ElseIf cbxBimonthly.Checked Then
            Payment = "Bimonthly"
        ElseIf cbxWeekly.Checked Then
            Payment = "Weekly"
        ElseIf cbxDaily.Checked Then
            Payment = "Daily"
        End If
        Dim UDI As String = "Yes"
        If cbxYesUDI.Checked Then
            UDI = "Yes"
        ElseIf cbxNoUDI.Checked Then
            UDI = "No"
        End If
        Dim LastPrincipal As String = "No"
        If cbxYesPrincipal.Checked Then
            LastPrincipal = "Yes"
        ElseIf cbxNoPrincipal.Checked Then
            LastPrincipal = "No"
        End If
        Dim AdvancePayment As String = "No"
        If cbxYesAdvance.Checked Then
            AdvancePayment = "Yes"
        ElseIf cbxNoAdvance.Checked Then
            AdvancePayment = "No"
        End If
        Dim CI As String = "No"
        If cbxYesCI.Checked Then
            CI = "Yes"
        ElseIf cbxNoCI.Checked Then
            CI = "No"
        End If
        Dim Grace As String = "No"
        If cbxGraceYes.Checked Then
            Grace = "Yes"
        ElseIf cbxNoCI.Checked Then
            Grace = "No"
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM product_setup WHERE (`product` = '{0}' OR `Code` = '{2}') AND `status` = 'ACTIVE' AND branch_id = '{1}'", txtProduct.Text, Branch_ID, txtProductCode.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Product ({0}) or Code ({1}) already exist, Please check your data.", txtProduct.Text, txtProductCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                txtCode.Text = DataObject(String.Format("SELECT IFNULL(COUNT(ID),0) + 1 FROM product_setup WHERE branch_id = '{0}';", Branch_ID))
                txtCode.Text = CInt(Branch_ID).ToString("D3") & "-" & CInt(txtCode.Text).ToString("D3")

                Dim SQL As String = "INSERT INTO product_setup SET"
                SQL &= String.Format(" product_code = '{0}', ", txtCode.Text)
                SQL &= String.Format(" product = '{0}', ", txtProduct.Text)
                SQL &= String.Format(" `code` = '{0}', ", txtProductCode.Text)
                SQL &= String.Format(" product_type = '{0}', ", ValidateComboBox(cbxProductType))
                SQL &= String.Format(" with_collateral = '{0}', ", If(cbxWithCollateral.Checked, "YES", "NO"))
                SQL &= String.Format(" collateral_id = '{0}', ", CollateralID)
                SQL &= String.Format(" collateral = '{0}', ", Coll)
                SQL &= String.Format(" interest = '{0}', ", dInterestRate.Value)
                SQL &= String.Format(" max_terms = '{0}', ", iMaxTerms.Value)
                SQL &= String.Format(" mortgage_id = '{0}', ", MortgageID)
                SQL &= String.Format(" mortgage = '{0}', ", Mort)
                SQL &= String.Format(" payment = '{0}', ", Payment)
                SQL &= String.Format(" UDI = '{0}', ", UDI)
                SQL &= String.Format(" last_principal = '{0}', ", LastPrincipal)
                SQL &= String.Format(" advance_payment = '{0}', ", AdvancePayment)
                SQL &= String.Format(" CI = '{0}', ", CI)
                SQL &= String.Format(" GracePeriod = '{0}', ", Grace)
                SQL &= String.Format(" branch_id = '{0}';", Branch_ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Product", "Save", String.Format("Add new Product {0}", txtProduct.Text), "", "", "", "")
                Products = DataSource(String.Format("SELECT ID, product, `code`, with_collateral, collateral_id, interest, max_terms, term, payment, UDI, last_principal, advance_payment, mortgage_id, CI FROM product_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}';", Branch_ID))
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM product_setup WHERE (`product` = '{0}' OR `Code` = '{3}') AND `status` = 'ACTIVE' AND ID != '{1}' AND Branch_ID = '{2}'", txtProduct.Text, ID, Branch_ID, txtProductCode.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Product ({0}) or Code ({1}) already exist, Please check your data.", txtProduct.Text, txtProductCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE product_setup SET"
                SQL &= String.Format(" product = '{0}', ", txtProduct.Text)
                SQL &= String.Format(" `code` = '{0}', ", txtProductCode.Text)
                SQL &= String.Format(" product_type = '{0}', ", ValidateComboBox(cbxProductType))
                SQL &= String.Format(" with_collateral = '{0}', ", If(cbxWithCollateral.Checked, "YES", "NO"))
                SQL &= String.Format(" collateral_id = '{0}', ", CollateralID)
                SQL &= String.Format(" collateral = '{0}', ", Coll)
                SQL &= String.Format(" interest = '{0}', ", dInterestRate.Value)
                SQL &= String.Format(" max_terms = '{0}', ", iMaxTerms.Value)
                SQL &= String.Format(" mortgage_id = '{0}', ", MortgageID)
                SQL &= String.Format(" mortgage = '{0}', ", Mort)
                SQL &= String.Format(" payment = '{0}', ", Payment)
                SQL &= String.Format(" UDI = '{0}', ", UDI)
                SQL &= String.Format(" last_principal = '{0}', ", LastPrincipal)
                SQL &= String.Format(" CI = '{0}', ", CI)
                SQL &= String.Format(" GracePeriod = '{0}', ", Grace)
                SQL &= String.Format(" advance_payment = '{0}'", AdvancePayment)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Product", "Update", Reason, Changes(), "", "", "")
                Products = DataSource(String.Format("SELECT ID, product, `code`, with_collateral, collateral_id, interest, max_terms, term, payment, UDI, last_principal, advance_payment, mortgage_id, CI FROM product_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}';", Branch_ID))
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtProduct.Text = txtProduct.Tag Then
            Else
                Change &= String.Format("Change Product Name from {0} to {1}. ", txtProduct.Tag, txtProduct.Text)
            End If
            If txtProductCode.Text = txtProductCode.Tag Then
            Else
                Change &= String.Format("Change Product Code from {0} to {1}. ", txtProductCode.Tag, txtProductCode.Text)
            End If
            If cbxProductType.Text = cbxProductType.Tag Then
            Else
                Change &= String.Format("Change Product Type from {0} to {1}. ", cbxProductType.Tag, cbxProductType.Text)
            End If
            If cbxCollateral.Text = cbxCollateral.Tag Then
            Else
                Change &= String.Format("Change Collateral from {0} to {1}. ", cbxCollateral.Tag, cbxCollateral.Text)
            End If
            If dInterestRate.Value = dInterestRate.Tag Then
            Else
                Change &= String.Format("Change Interest from {0} to {1}. ", dInterestRate.Tag, dInterestRate.Text)
            End If
            If iMaxTerms.Value = iMaxTerms.Tag Then
            Else
                Change &= String.Format("Change Max Term from {0} to {1}. ", iMaxTerms.Tag, iMaxTerms.Text)
            End If
            If cbxMortgage.Text = cbxMortgage.Tag Then
            Else
                Change &= String.Format("Change Mortgage from {0} to {1}. ", cbxMortgage.Tag, cbxMortgage.Text)
            End If
            If cbxMonthly.Tag <> "Monthly" And cbxMonthly.Checked Then
                Change &= String.Format("Change payment from {0} to {1}. ", cbxMonthly.Tag, cbxMonthly.Text)
            ElseIf cbxBimonthly.Tag <> "Bimonthly" And cbxBimonthly.Checked = True Then
                Change &= String.Format("Change payment from {0} to {1}. ", cbxBimonthly.Tag, cbxBimonthly.Text)
            ElseIf cbxWeekly.Tag <> "Bimonthly" And cbxWeekly.Checked = True Then
                Change &= String.Format("Change payment from {0} to {1}. ", cbxWeekly.Tag, cbxWeekly.Text)
            ElseIf cbxDaily.Tag <> "Daily" And cbxDaily.Checked = True Then
                Change &= String.Format("Change payment from {0} to {1}. ", cbxDaily.Tag, cbxDaily.Text)
            End If
            If cbxYesUDI.Tag <> "Yes" And cbxYesUDI.Checked Then
                Change &= String.Format("Change UDI from {0} to {1}. ", cbxYesUDI.Tag, cbxYesUDI.Text)
            ElseIf cbxNoUDI.Tag <> "No" And cbxNoUDI.Checked = True Then
                Change &= String.Format("Change UDI from {0} to {1}. ", cbxNoUDI.Tag, cbxNoUDI.Text)
            End If
            If cbxYesPrincipal.Tag <> "Yes" And cbxYesPrincipal.Checked Then
                Change &= String.Format("Change Last Principal from {0} to {1}. ", cbxYesPrincipal.Tag, cbxYesPrincipal.Text)
            ElseIf cbxNoPrincipal.Tag <> "No" And cbxNoPrincipal.Checked = True Then
                Change &= String.Format("Change Last Principal from {0} to {1}. ", cbxNoPrincipal.Tag, cbxNoPrincipal.Text)
            End If
            If cbxYesAdvance.Tag <> "Yes" And cbxYesAdvance.Checked Then
                Change &= String.Format("Change Advance Payment from {0} to {1}. ", cbxYesAdvance.Tag, cbxYesAdvance.Text)
            ElseIf cbxNoAdvance.Tag <> "No" And cbxNoAdvance.Checked = True Then
                Change &= String.Format("Change Advance Payment from {0} to {1}. ", cbxNoAdvance.Tag, cbxNoAdvance.Text)
            End If
            If cbxYesCI.Tag <> "Yes" And cbxYesCI.Checked Then
                Change &= String.Format("Change CI from {0} to {1}. ", cbxYesCI.Tag, cbxYesCI.Text)
            ElseIf cbxNoCI.Tag <> "No" And cbxNoCI.Checked = True Then
                Change &= String.Format("Change CI from {0} to {1}. ", cbxNoCI.Tag, cbxNoCI.Text)
            End If
            If cbxGraceYes.Tag <> "Yes" And cbxGraceYes.Checked Then
                Change &= String.Format("Change Grace Period from {0} to {1}. ", cbxGraceYes.Tag, cbxGraceYes.Text)
            ElseIf cbxGraceNo.Tag <> "No" And cbxGraceNo.Checked = True Then
                Change &= String.Format("Change Grace Period from {0} to {1}. ", cbxGraceNo.Tag, cbxGraceNo.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Product Setup - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE product_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Product", "Cancel", Reason, String.Format("Cancel Product {0}", txtProduct.Text), "", "", "")
            Products = DataSource(String.Format("SELECT ID, product, `code`, with_collateral, collateral_id, interest, max_terms, term, payment, UDI, last_principal, advance_payment, mortgage_id, CI FROM product_setup WHERE `status` = 'ACTIVE' AND branch_id LIKE '{0}';", Branch_ID))
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
        StandardPrinting("PRODUCT LIST", GridControl1)
        Logs("Product", "Print", "[SENSITIVE] Print Product List", "", "", "", "")
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
            txtProduct.Text = .GetFocusedRowCellValue("Product Name")
            txtProduct.Tag = .GetFocusedRowCellValue("Product Name")
            txtProductCode.Text = .GetFocusedRowCellValue("Product Code")
            txtProductCode.Tag = .GetFocusedRowCellValue("Product Code")
            txtCode.Text = .GetFocusedRowCellValue("Code")
            txtCode.Tag = .GetFocusedRowCellValue("Code")
            cbxProductType.Text = .GetFocusedRowCellValue("Product Type").ToString
            cbxProductType.Tag = .GetFocusedRowCellValue("Product Type").ToString
            If .GetFocusedRowCellValue("Collateral") = "" Then
                cbxWithCollateral.Checked = False
            Else
                cbxWithCollateral.Checked = True
                cbxCollateral.Text = .GetFocusedRowCellValue("Collateral")
                cbxCollateral.Tag = .GetFocusedRowCellValue("Collateral")
            End If
            dInterestRate.Value = .GetFocusedRowCellValue("Interest")
            dInterestRate.Tag = .GetFocusedRowCellValue("Interest")
            iMaxTerms.Value = .GetFocusedRowCellValue("Max Term")
            iMaxTerms.Tag = .GetFocusedRowCellValue("Max Term")
            cbxMortgage.Text = .GetFocusedRowCellValue("Mortgage")
            cbxMortgage.Tag = .GetFocusedRowCellValue("Mortgage")

            If .GetFocusedRowCellValue("Payment") = "Monthly" Then
                cbxMonthly.Checked = True
            ElseIf .GetFocusedRowCellValue("Payment") = "Bimonthly" Then
                cbxBimonthly.Checked = True
            ElseIf .GetFocusedRowCellValue("Payment") = "Weekly" Then
                cbxWeekly.Checked = True
            ElseIf .GetFocusedRowCellValue("Payment") = "Daily" Then
                cbxDaily.Checked = True
            End If
            cbxMonthly.Tag = .GetFocusedRowCellValue("Payment")
            cbxBimonthly.Tag = .GetFocusedRowCellValue("Payment")
            cbxWeekly.Tag = .GetFocusedRowCellValue("Payment")
            cbxDaily.Tag = .GetFocusedRowCellValue("Payment")

            If .GetFocusedRowCellValue("UDI") = "Yes" Then
                cbxYesUDI.Checked = True
            ElseIf .GetFocusedRowCellValue("UDI") = "No" Then
                cbxNoUDI.Checked = True
            End If
            cbxYesUDI.Tag = .GetFocusedRowCellValue("UDI")
            cbxNoUDI.Tag = .GetFocusedRowCellValue("UDI")

            If .GetFocusedRowCellValue("Last Month Principal") = "Yes" Then
                cbxYesPrincipal.Checked = True
            ElseIf .GetFocusedRowCellValue("Last Month Principal") = "No" Then
                cbxNoPrincipal.Checked = True
            End If
            cbxYesPrincipal.Tag = .GetFocusedRowCellValue("Last Month Principal")
            cbxNoPrincipal.Tag = .GetFocusedRowCellValue("Last Month Principal")

            If .GetFocusedRowCellValue("Advance Payment") = "Yes" Then
                cbxYesAdvance.Checked = True
            ElseIf .GetFocusedRowCellValue("Advance Payment") = "No" Then
                cbxNoAdvance.Checked = True
            End If
            cbxYesAdvance.Tag = .GetFocusedRowCellValue("Advance Payment")
            cbxNoAdvance.Tag = .GetFocusedRowCellValue("Advance Payment")

            If .GetFocusedRowCellValue("CI") = "Yes" Then
                cbxYesCI.Checked = True
            ElseIf .GetFocusedRowCellValue("CI") = "No" Then
                cbxNoCI.Checked = True
            End If
            cbxYesCI.Tag = .GetFocusedRowCellValue("CI")
            cbxNoCI.Tag = .GetFocusedRowCellValue("CI")

            If .GetFocusedRowCellValue("Grace Period") = "Yes" Then
                cbxGraceYes.Checked = True
            ElseIf .GetFocusedRowCellValue("Grace Period") = "No" Then
                cbxGraceNo.Checked = True
            End If
            cbxGraceYes.Tag = .GetFocusedRowCellValue("Grace Period")
            cbxGraceNo.Tag = .GetFocusedRowCellValue("Grace Period")
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

    Private Sub BtnAddCollateral_Click(sender As Object, e As EventArgs) Handles btnAddCollateral.Click
        Dim FCollateral As New FrmCollateralSetup
        With FCollateral
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .ShowDialog()
            .Dispose()
        End With
        cbxCollateral.DataSource = Collateral.Copy
        cbxCollateral.SelectedIndex = -1
    End Sub

    Private Sub BtnAddMortgage_Click(sender As Object, e As EventArgs) Handles btnAddMortgage.Click
        Dim FMortgage As New FrmMortgageSetup
        With FMortgage
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .ShowDialog()
            .Dispose()
        End With
        cbxMortgage.DataSource = Mortgage.Copy
        cbxMortgage.SelectedIndex = -1
    End Sub

    Private Sub CbxMonthly_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMonthly.CheckedChanged
        If cbxMonthly.Checked Then
            cbxBimonthly.Checked = False
            cbxWeekly.Checked = False
            cbxDaily.Checked = False
        ElseIf cbxMonthly.Checked = False And cbxBimonthly.Checked = False And cbxWeekly.Checked = False And cbxDaily.Checked = False Then
            cbxMonthly.Checked = True
        End If
    End Sub

    Private Sub CbxBimonthly_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBimonthly.CheckedChanged
        If cbxBimonthly.Checked Then
            cbxMonthly.Checked = False
            cbxWeekly.Checked = False
            cbxDaily.Checked = False
        ElseIf cbxMonthly.Checked = False And cbxBimonthly.Checked = False And cbxWeekly.Checked = False And cbxDaily.Checked = False Then
            cbxMonthly.Checked = True
        End If
    End Sub

    Private Sub CbxWeekly_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWeekly.CheckedChanged
        If cbxWeekly.Checked Then
            cbxMonthly.Checked = False
            cbxBimonthly.Checked = False
            cbxDaily.Checked = False
        ElseIf cbxMonthly.Checked = False And cbxBimonthly.Checked = False And cbxWeekly.Checked = False And cbxDaily.Checked = False Then
            cbxMonthly.Checked = True
        End If
    End Sub

    Private Sub CbxDaily_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDaily.CheckedChanged
        If cbxDaily.Checked Then
            cbxMonthly.Checked = False
            cbxBimonthly.Checked = False
            cbxWeekly.Checked = False
        ElseIf cbxMonthly.Checked = False And cbxBimonthly.Checked = False And cbxWeekly.Checked = False And cbxDaily.Checked = False Then
            cbxMonthly.Checked = True
        End If
    End Sub

    Private Sub CbxYesUDI_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYesUDI.CheckedChanged
        If cbxYesUDI.Checked Then
            cbxNoUDI.Checked = False
        ElseIf cbxYesUDI.Checked = False And cbxNoUDI.Checked = False Then
            cbxYesUDI.Checked = True
        End If
    End Sub

    Private Sub CbxNoUDI_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNoUDI.CheckedChanged
        If cbxNoUDI.Checked Then
            cbxYesUDI.Checked = False
        ElseIf cbxYesUDI.Checked = False And cbxNoUDI.Checked = False Then
            cbxYesUDI.Checked = True
        End If
    End Sub

    Private Sub CbxYesPrincipal_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYesPrincipal.CheckedChanged
        If cbxYesPrincipal.Checked Then
            cbxNoPrincipal.Checked = False
        ElseIf cbxYesPrincipal.Checked = False And cbxNoPrincipal.Checked = False Then
            cbxNoPrincipal.Checked = True
        End If
    End Sub

    Private Sub CbxNoPrincipal_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNoPrincipal.CheckedChanged
        If cbxNoPrincipal.Checked Then
            cbxYesPrincipal.Checked = False
        ElseIf cbxYesPrincipal.Checked = False And cbxNoPrincipal.Checked = False Then
            cbxNoPrincipal.Checked = True
        End If
    End Sub

    Private Sub CbxYesAdvance_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYesAdvance.CheckedChanged
        If cbxYesAdvance.Checked Then
            cbxNoAdvance.Checked = False
        ElseIf cbxYesAdvance.Checked = False And cbxNoAdvance.Checked = False Then
            cbxNoAdvance.Checked = True
        End If
    End Sub

    Private Sub CbxNoAdvance_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNoAdvance.CheckedChanged
        If cbxNoAdvance.Checked Then
            cbxYesAdvance.Checked = False
        ElseIf cbxYesAdvance.Checked = False And cbxNoAdvance.Checked = False Then
            cbxNoAdvance.Checked = True
        End If
    End Sub

    Private Sub BtnProductType_Click(sender As Object, e As EventArgs) Handles btnProductType.Click
        Dim Type As New FrmProductType
        With Type
            .vSave = vSave
            .vUpdate = vUpdate
            .vDelete = vDelete
            .vPrint = vPrint
            .ShowDialog()
            .Dispose()
        End With
        cbxProductType.DataSource = DataSource("SELECT ID, ProductType FROM product_type WHERE `status` = 'ACTIVE';")
        cbxProductType.SelectedIndex = -1
    End Sub

    Private Sub CbxYesCI_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYesCI.CheckedChanged
        If cbxYesCI.Checked Then
            cbxNoCI.Checked = False
        ElseIf cbxYesCI.Checked = False And cbxNoCI.Checked = False Then
            cbxNoCI.Checked = True
        End If
    End Sub

    Private Sub CbxNoCI_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNoCI.CheckedChanged
        If cbxNoCI.Checked Then
            cbxYesCI.Checked = False
        ElseIf cbxYesCI.Checked = False And cbxNoCI.Checked = False Then
            cbxNoCI.Checked = True
        End If
    End Sub

    Private Sub CbxGraceYes_CheckedChanged(sender As Object, e As EventArgs) Handles cbxGraceYes.CheckedChanged
        If cbxGraceYes.Checked Then
            cbxGraceNo.Checked = False
        ElseIf cbxGraceYes.Checked = False And cbxGraceNo.Checked = False Then
            cbxGraceYes.Checked = True
        End If
    End Sub

    Private Sub CbxGraceNo_CheckedChanged(sender As Object, e As EventArgs) Handles cbxGraceNo.CheckedChanged
        If cbxGraceNo.Checked Then
            cbxGraceYes.Checked = False
        ElseIf cbxGraceYes.Checked = False And cbxGraceNo.Checked = False Then
            cbxGraceYes.Checked = True
        End If
    End Sub
End Class