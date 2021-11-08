Imports DevExpress.XtraReports.UI
Public Class FrmCreditReferralSlip

    Dim ID As String
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmCreditReferralSlip_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        cbxDisplay.SelectedIndex = 0
        dtpDate.Value = Date.Now
        dtpGranted.Value = Date.Now
        dtpAsOf.Value = Date.Now
        dtpGranted_Insurance.Value = Date.Now
        dtpGranted_Policy.Value = Date.Now

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        With cbxRequested
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedIndex = -1
        End With

        With cbxApplication
            .ValueMember = "BorrowerID"
            .DisplayMember = "Name"
        End With

        With cbxAccountNumber
            .ValueMember = "CreditNumber"
            .DisplayMember = "AccountNumber"
        End With

        LoadApplication()
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

            GetLabelFontSettings({LabelX155, lblPlateNum, LabelX2, LabelX6, LabelX9, LabelX12, LabelX7, LabelX8, LabelX10, LabelX14, LabelX15, LabelX16, LabelX18, LabelX19, LabelX34, LabelX33, LabelX37, LabelX38, LabelX39, LabelX40, LabelX63, LabelX65, LabelX1, LabelX17, LabelX3, LabelX4, LabelX36, LabelX45, LabelX5, LabelX13, LabelX21, LabelX23, LabelX22, LabelX24, LabelX28, LabelX27, LabelX25, LabelX31, LabelX32, LabelX30, LabelX29, LabelX26, LabelX46, LabelX52, LabelX54, LabelX56, LabelX58, LabelX59, LabelX50, LabelX51, LabelX53, LabelX55, LabelX57, LabelX35, LabelX47, LabelX49, LabelX48})

            GetLabelWithBackgroundFontSettings({LabelX20, LabelX41, LabelX42, LabelX43, LabelX44, LabelX60, LabelX61, LabelX62, LabelX64})

            GetTextBoxFontSettings({txtComaker1, txtComaker2, txtComaker3, txtComaker4, txtDocumentNumber, txtCollateral_1, txtCollateral_2, txtCollateral_3, txtCollateral_4, txtCollateral_5, txtCollateral_6, txtCollateral_7, txtInsuranceInCharge, txtInsuranceCompany, txtOR, txtTerms, txtNumberLPC, txtDeliquency, txtPresentStatus, txtRemarks_Score})

            GetCheckBoxFontSettings({cbxDaily, cbxWeekly, cbxBimonthly, cbxMonthly, cbxAll})

            GetComboBoxFontSettings({cbxApplication, cbxAccountNumber, cbxLoanType, cbxPreparedBy, cbxRequested, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo, dtpDate, dtpGranted, dtpAsOf})

            GetDoubleInputFontSettings({dPrincipal, dFaceAmount, dMonthlyAmortization, dOutstanding, dInterestDue, dLPC, dBalance, dRPPD, dUDI, dAmountDue, dAmount_Insurance, dAmount_Policy, dAmount_Renewal, dPrincipalBalance, iTime_Score, iHistory_Score, iRepayment_Score, iSettlement_Score, iCredit_Score, iTotal_Score, dTime_Score, dHistory_Score, dRepayment_Score, dSettlement_Score, dCredit_Score, dTotal_Score})

            GetIntegerInputFontSettings({iDue, iPayments})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Credit Referral Slip - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Credit Referral Slip", lblTitle.Text)
    End Sub

    Private Sub LoadApplication()
        Dim SQL As String = "SELECT BorrowerID, "
        SQL &= "   CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'Name'"
        SQL &= " FROM credit_application C"
        SQL &= String.Format("  WHERE FIND_IN_SET(C.Branch_ID,'{0}') AND C.`status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED','CLOSED') GROUP BY BorrowerID ORDER BY `Name`;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        FirstLoad = True
        cbxApplication.DataSource = DataSource(SQL)
        cbxApplication.SelectedIndex = -1
        FirstLoad = False
    End Sub

    Private Sub LoadAccountNumber()
        cbxAccountNumber.ValueMember = "CreditNumber"
        cbxAccountNumber.DisplayMember = "AccountNumber"
        Dim SQL As String = "SELECT CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)) AS 'AccountNumber', "
        SQL &= "   CONCAT(IF(FirstN_S = '','',CONCAT(FirstN_S, ' ')), IF(MiddleN_S = '','',CONCAT(MiddleN_S, ' ')), IF(LastN_S = '','',CONCAT(LastN_S, ' ')), Suffix_S) AS 'Spouse',"
        SQL &= "   CONCAT(IF(FirstN_C1 = '','',CONCAT(FirstN_C1, ' ')), IF(MiddleN_C1 = '','',CONCAT(MiddleN_C1, ' ')), IF(LastN_C1 = '','',CONCAT(LastN_C1, ' ')), Suffix_C1) AS 'Comaker1',"
        SQL &= "   CONCAT(IF(FirstN_C2 = '','',CONCAT(FirstN_C2, ' ')), IF(MiddleN_C2 = '','',CONCAT(MiddleN_C2, ' ')), IF(LastN_C2 = '','',CONCAT(LastN_C2, ' ')), Suffix_C2) AS 'Comaker2',"
        SQL &= "   CONCAT(IF(FirstN_C3 = '','',CONCAT(FirstN_C3, ' ')), IF(MiddleN_C3 = '','',CONCAT(MiddleN_C3, ' ')), IF(LastN_C3 = '','',CONCAT(LastN_C3, ' ')), Suffix_C3) AS 'Comaker3',"
        SQL &= "   CONCAT(IF(FirstN_C4 = '','',CONCAT(FirstN_C4, ' ')), IF(MiddleN_C4 = '','',CONCAT(MiddleN_C4, ' ')), IF(LastN_C4 = '','',CONCAT(LastN_C4, ' ')), Suffix_C4) AS 'Comaker4',"
        SQL &= "   C.CreditNumber, mortgage_id, DAY(FDD) AS 'Due', PN, AmountApplied, Face_Amount, GMA, TermType"
        SQL &= " FROM credit_application C"
        SQL &= String.Format("  WHERE FIND_IN_SET(C.Branch_ID,'{0}') AND C.`status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED','CLOSED') AND BorrowerID = '{1}' ORDER BY `AccountNumber`;", If(Multiple_ID = "", Branch_ID, Multiple_ID), cbxApplication.SelectedValue)
        FirstLoad = True
        cbxAccountNumber.DataSource = DataSource(SQL)
        cbxAccountNumber.SelectedIndex = -1
        FirstLoad = False
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    DocumentDate AS 'Document Date',"
        SQL &= "    DocumentNumber AS 'Document Number',"
        SQL &= "    BorrowerID,"
        SQL &= "    CreditNumber AS 'Credit Number',"
        SQL &= "    AccountNumber(CreditNumber) AS 'Account Number',"
        SQL &= "    Borrower(BorrowerID) AS 'Borrower',"
        SQL &= "    AsOf,"
        SQL &= "    Outstanding,"
        SQL &= "    InterestDue,"
        SQL &= "    LPC,"
        SQL &= "    Balance,"
        SQL &= "    RPPD,"
        SQL &= "    UDI,"
        SQL &= "    AmountDue,"
        SQL &= "    PrincipalBalance,"
        SQL &= "    Payments,"
        SQL &= "    Terms,"
        SQL &= "    NumberLPC,"
        SQL &= "    Deliquency,"
        SQL &= "    PresentStatus,"
        SQL &= "    AmountInsurance,"
        SQL &= "    DateInsurance,"
        SQL &= "    InsuranceInCharge,"
        SQL &= "    AmountPolicy,"
        SQL &= "    DatePolicy,"
        SQL &= "    AmountRenewal,"
        SQL &= "    InsuranceRenewal,"
        SQL &= "    OR_CR,"
        SQL &= "    TimeScore,"
        SQL &= "    HistoryScore,"
        SQL &= "    RepaymentScore,"
        SQL &= "    SettlementScore,"
        SQL &= "    CreditScore,"
        SQL &= "    TimeScore + HistoryScore + RepaymentScore + SettlementScore + CreditScore AS 'Total Score',"
        SQL &= "    FORMAT(((TimeScore / 100) * 30) + ((HistoryScore / 100) * 25) + ((RepaymentScore / 100) * 20) + ((SettlementScore / 100) * 15) + ((CreditScore / 100) * 10),2) AS 'Score Rate',"
        SQL &= "    RemarksScore,"
        SQL &= "    LoanType,"
        SQL &= "    Remarks,"
        SQL &= "    PreparedID,"
        SQL &= "    RequestedID,"
        SQL &= "    Employee(PreparedID) AS 'Prepared By',"
        SQL &= "    Employee(RequestedID) AS 'Requested By'"
        SQL &= "  FROM credit_referral WHERE `status` = 'ACTIVE'"
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(DocumentDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= String.Format("  AND Branch_ID IN ({0}) ORDER BY DocumentNumber DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn29.Visible = True
            GridColumn29.VisibleIndex = 10
        End If
        GridView1.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn14.Width = 114 - 9
            GridColumn15.Width = 113 - 8
        Else
            GridColumn14.Width = 114
            GridColumn15.Width = 113
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub ITotal_Score_ValueChanged(sender As Object, e As EventArgs) Handles iTime_Score.ValueChanged, iRepayment_Score.ValueChanged, iHistory_Score.ValueChanged, iSettlement_Score.ValueChanged, iCredit_Score.ValueChanged
        iTotal_Score.Value = iTime_Score.Value + iHistory_Score.Value + iRepayment_Score.Value + iSettlement_Score.Value + iCredit_Score.Value
    End Sub

    Private Sub ITime_Score_ValueChanged(sender As Object, e As EventArgs) Handles iTime_Score.ValueChanged
        dTime_Score.Value = (iTime_Score.Value / 100) * 30
    End Sub

    Private Sub IRepayment_Score_ValueChanged(sender As Object, e As EventArgs) Handles iRepayment_Score.ValueChanged
        dRepayment_Score.Value = (iRepayment_Score.Value / 100) * 20
    End Sub

    Private Sub IHistory_Score_ValueChanged(sender As Object, e As EventArgs) Handles iHistory_Score.ValueChanged
        dHistory_Score.Value = (iHistory_Score.Value / 100) * 25
    End Sub

    Private Sub ISettlement_Score_ValueChanged(sender As Object, e As EventArgs) Handles iSettlement_Score.ValueChanged
        dSettlement_Score.Value = (iSettlement_Score.Value / 100) * 15
    End Sub

    Private Sub ICredit_Score_ValueChanged(sender As Object, e As EventArgs) Handles iCredit_Score.ValueChanged
        dCredit_Score.Value = (iCredit_Score.Value / 100) * 10
    End Sub

    Private Sub DTime_Score_ValueChanged(sender As Object, e As EventArgs) Handles dTime_Score.ValueChanged, dHistory_Score.ValueChanged, dRepayment_Score.ValueChanged, dSettlement_Score.ValueChanged, dCredit_Score.ValueChanged
        dTotal_Score.Value = dTime_Score.Value + dHistory_Score.Value + dRepayment_Score.Value + dSettlement_Score.Value + dCredit_Score.Value
    End Sub

    Private Sub CbxDaily_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDaily.CheckedChanged
        If cbxDaily.Checked Then
            cbxWeekly.Checked = False
            cbxBimonthly.Checked = False
            cbxMonthly.Checked = False
        End If
    End Sub

    Private Sub CbxWeekly_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWeekly.CheckedChanged
        If cbxWeekly.Checked Then
            cbxDaily.Checked = False
            cbxBimonthly.Checked = False
            cbxMonthly.Checked = False
        End If
    End Sub

    Private Sub CbxBimonthly_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBimonthly.CheckedChanged
        If cbxBimonthly.Checked Then
            cbxDaily.Checked = False
            cbxWeekly.Checked = False
            cbxMonthly.Checked = False
        End If
    End Sub

    Private Sub CbxMonthly_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMonthly.CheckedChanged
        If cbxMonthly.Checked Then
            cbxDaily.Checked = False
            cbxWeekly.Checked = False
            cbxBimonthly.Checked = False
        End If
    End Sub

#Region "Keydown"
    Private Sub KeyDown_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxApplication.KeyDown, cbxAccountNumber.KeyDown, dtpDate.KeyDown, dtpAsOf.KeyDown, dOutstanding.KeyDown, dInterestDue.KeyDown, dLPC.KeyDown, dBalance.KeyDown, dRPPD.KeyDown, dUDI.KeyDown, dAmountDue.KeyDown, dPrincipalBalance.KeyDown, iPayments.KeyDown, txtTerms.KeyDown, txtNumberLPC.KeyDown, txtDeliquency.KeyDown, txtPresentStatus.KeyDown, dAmount_Insurance.KeyDown, txtInsuranceInCharge.KeyDown, dAmount_Policy.KeyDown, dAmount_Renewal.KeyDown, txtInsuranceCompany.KeyDown, txtOR.KeyDown, txtRemarks_Score.KeyDown, cbxLoanType.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DtpGranted_Insurance_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpGranted_Insurance.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Delete Then
            dtpGranted_Insurance.CustomFormat = ""
        End If
    End Sub

    Private Sub DtpGranted_Policy_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpGranted_Policy.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        ElseIf e.KeyCode = Keys.Delete Then
            dtpGranted_Policy.CustomFormat = ""
        End If
    End Sub
#End Region

    Private Sub TxtInsuranceInCharge_Leave(sender As Object, e As EventArgs) Handles txtInsuranceInCharge.Leave
        txtInsuranceInCharge.Text = ReplaceText(txtInsuranceInCharge.Text)
    End Sub

    Private Sub TxtInsuranceCompany_Leave(sender As Object, e As EventArgs) Handles txtInsuranceCompany.Leave
        txtInsuranceCompany.Text = ReplaceText(txtInsuranceCompany.Text)
    End Sub

    Private Sub TxtOR_Leave(sender As Object, e As EventArgs) Handles txtOR.Leave
        txtOR.Text = ReplaceText(txtOR.Text)
    End Sub

    Private Sub TxtRemarks_Score_Leave(sender As Object, e As EventArgs) Handles txtRemarks_Score.Leave
        txtRemarks_Score.Text = ReplaceText(txtRemarks_Score.Text)
    End Sub

    Private Sub TxtTerms_Leave(sender As Object, e As EventArgs) Handles txtTerms.Leave
        txtTerms.Text = ReplaceText(txtTerms.Text)
    End Sub

    Private Sub TxtNumberLPC_Leave(sender As Object, e As EventArgs) Handles txtNumberLPC.Leave
        txtNumberLPC.Text = ReplaceText(txtNumberLPC.Text)
    End Sub

    Private Sub TxtDeliquency_Leave(sender As Object, e As EventArgs) Handles txtDeliquency.Leave
        txtDeliquency.Text = ReplaceText(txtDeliquency.Text)
    End Sub

    Private Sub TxtPresentStatus_Leave(sender As Object, e As EventArgs) Handles txtPresentStatus.Leave
        txtPresentStatus.Text = ReplaceText(txtPresentStatus.Text)
    End Sub

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
            btnRefresh.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
            If btnSave.Text = "&Save" And btnSave.Enabled Then
                btnPrint.Enabled = False
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            btnModify.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnPrint.Enabled = True
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
        btnSave.Text = "&Save"
        PanelEx10.Enabled = True
        cbxApplication.SelectedIndex = -1

        iDue.Value = 0
        dtpGranted.Value = Date.Now
        dPrincipal.Value = 0
        dFaceAmount.Value = 0
        dMonthlyAmortization.Value = 0

        txtCollateral_1.Text = ""
        txtCollateral_2.Text = ""
        txtCollateral_3.Text = ""
        txtCollateral_4.Text = ""
        txtCollateral_5.Text = ""
        txtCollateral_6.Text = ""
        txtCollateral_7.Text = ""

        cbxAccountNumber.DataSource = Nothing
        dtpAsOf.Value = Date.Now
        dAmount_Insurance.Value = 0
        txtInsuranceInCharge.Text = ""
        dtpGranted_Insurance.Value = Date.Now
        dAmount_Policy.Value = 0
        dAmount_Renewal.Value = 0
        dtpGranted_Policy.Value = Date.Now
        txtInsuranceCompany.Text = ""
        txtOR.Text = ""
        cbxDaily.Checked = False
        cbxWeekly.Checked = False
        cbxBimonthly.Checked = False
        cbxMonthly.Checked = False

        dOutstanding.Value = 0
        dInterestDue.Value = 0
        dLPC.Value = 0
        dBalance.Value = 0
        dRPPD.Value = 0
        dUDI.Value = 0
        dAmountDue.Value = 0

        dPrincipalBalance.Value = 0
        iPayments.Value = 0
        txtTerms.Text = 1 & " Month(s)"
        txtNumberLPC.Text = ""
        txtDeliquency.Text = ""
        txtPresentStatus.Text = "UPDATED"

        iTime_Score.Value = 0
        iHistory_Score.Value = 0
        iRepayment_Score.Value = 0
        iSettlement_Score.Value = 0
        iCredit_Score.Value = 0
        txtRemarks_Score.Text = ""
        cbxLoanType.SelectedIndex = -1
        rExplanation.Text = ""

        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        cbxPreparedBy.SelectedValue = Empl_ID
        cbxRequested.SelectedIndex = -1

        GridControl2.DataSource = Nothing
        GridControl3.DataSource = Nothing

        GetDocumentNumber()

        If TriggerLoadData Then
            LoadData()
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

        If cbxApplication.Text = "" Or cbxApplication.SelectedIndex = -1 Then
            MsgBox("Please select Borrower.", MsgBoxStyle.Information, "Info")
            cbxApplication.DroppedDown = True
            Exit Sub
        End If
        If cbxRequested.Text = "" Or cbxRequested.SelectedIndex = -1 Then
            MsgBox("Please select requested by.", MsgBoxStyle.Information, "Info")
            cbxRequested.DroppedDown = True
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor

                Dim SQL As String = "INSERT INTO credit_referral SET"
                SQL &= String.Format(" DocumentDate = '{0}', ", FormatDatePicker(dtpDate))
                SQL &= String.Format(" DocumentNumber = '{0}',", txtDocumentNumber.Text)
                SQL &= String.Format(" BorrowerID = '{0}',", cbxApplication.SelectedValue)
                SQL &= String.Format(" CreditNumber = '{0}',", ValidateComboBox(cbxAccountNumber))
                SQL &= String.Format(" AsOf = '{0}',", FormatDatePicker(dtpAsOf))
                SQL &= String.Format(" Outstanding = '{0}',", dOutstanding.Value)
                SQL &= String.Format(" InterestDue = '{0}',", dInterestDue.Value)
                SQL &= String.Format(" LPC = '{0}',", dLPC.Value)
                SQL &= String.Format(" Balance = '{0}',", dBalance.Value)
                SQL &= String.Format(" RPPD = '{0}',", dRPPD.Value)
                SQL &= String.Format(" UDI = '{0}',", dUDI.Value)
                SQL &= String.Format(" AmountDue = '{0}',", dAmountDue.Value)
                SQL &= String.Format(" PrincipalBalance = '{0}',", dPrincipalBalance.Value)
                SQL &= String.Format(" Payments = '{0}',", iPayments.Value)
                SQL &= String.Format(" Terms = '{0}',", txtTerms.Text)
                SQL &= String.Format(" NumberLPC = '{0}',", txtNumberLPC.Text)
                SQL &= String.Format(" Deliquency = '{0}',", txtDeliquency.Text)
                SQL &= String.Format(" PresentStatus = '{0}',", txtPresentStatus.Text)
                SQL &= String.Format(" AmountInsurance = '{0}',", dAmount_Insurance.Value)
                SQL &= String.Format(" DateInsurance = '{0}',", FormatDatePicker(dtpGranted_Insurance))
                SQL &= String.Format(" InsuranceInCharge = '{0}',", txtInsuranceInCharge.Text)
                SQL &= String.Format(" AmountPolicy = '{0}',", dAmount_Policy.Value)
                SQL &= String.Format(" DatePolicy = '{0}',", FormatDatePicker(dtpGranted_Policy))
                SQL &= String.Format(" AmountRenewal = '{0}',", dAmount_Renewal.Value)
                SQL &= String.Format(" InsuranceRenewal = '{0}',", txtInsuranceCompany.Text)
                SQL &= String.Format(" OR_CR = '{0}',", txtOR.Text)
                SQL &= String.Format(" TimeScore = '{0}',", iTime_Score.Value)
                SQL &= String.Format(" HistoryScore = '{0}',", iHistory_Score.Value)
                SQL &= String.Format(" RepaymentScore = '{0}',", iRepayment_Score.Value)
                SQL &= String.Format(" SettlementScore = '{0}',", iSettlement_Score.Value)
                SQL &= String.Format(" CreditScore = '{0}',", iCredit_Score.Value)
                SQL &= String.Format(" RemarksScore = '{0}',", txtRemarks_Score.Text)
                SQL &= String.Format(" LoanType = '{0}',", cbxLoanType.Text)
                SQL &= String.Format(" Remarks = '{0}',", rExplanation.Text.InsertQuote)
                SQL &= String.Format(" PreparedID = '{0}',", cbxPreparedBy.SelectedValue)
                SQL &= String.Format(" RequestedID = '{0}',", cbxRequested.SelectedValue)
                SQL &= String.Format(" Branch_ID = '{0}',", Branch_ID)
                SQL &= String.Format(" User_EmplID = '{0}';", Empl_ID)
                DataObject(SQL)

                Logs("Credit Referral Slip", "Save", String.Format("Add new Credit Referral Slip for {0}.", cbxApplication.Text), "", "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor

                Dim SQL As String = "UPDATE credit_referral SET"
                SQL &= String.Format(" AsOf = '{0}',", FormatDatePicker(dtpAsOf))
                SQL &= String.Format(" Outstanding = '{0}',", dOutstanding.Value)
                SQL &= String.Format(" InterestDue = '{0}',", dInterestDue.Value)
                SQL &= String.Format(" LPC = '{0}',", dLPC.Value)
                SQL &= String.Format(" Balance = '{0}',", dBalance.Value)
                SQL &= String.Format(" RPPD = '{0}',", dRPPD.Value)
                SQL &= String.Format(" UDI = '{0}',", dUDI.Value)
                SQL &= String.Format(" AmountDue = '{0}',", dAmountDue.Value)
                SQL &= String.Format(" PrincipalBalance = '{0}',", dPrincipalBalance.Value)
                SQL &= String.Format(" Payments = '{0}',", iPayments.Value)
                SQL &= String.Format(" Terms = '{0}',", txtTerms.Text)
                SQL &= String.Format(" NumberLPC = '{0}',", txtNumberLPC.Text)
                SQL &= String.Format(" Deliquency = '{0}',", txtDeliquency.Text)
                SQL &= String.Format(" PresentStatus = '{0}',", txtPresentStatus.Text)
                SQL &= String.Format(" AmountInsurance = '{0}',", dAmount_Insurance.Value)
                SQL &= String.Format(" DateInsurance = '{0}',", FormatDatePicker(dtpGranted_Insurance))
                SQL &= String.Format(" InsuranceInCharge = '{0}',", txtInsuranceInCharge.Text)
                SQL &= String.Format(" AmountPolicy = '{0}',", dAmount_Policy.Value)
                SQL &= String.Format(" DatePolicy = '{0}',", FormatDatePicker(dtpGranted_Policy))
                SQL &= String.Format(" AmountRenewal = '{0}',", dAmount_Renewal.Value)
                SQL &= String.Format(" InsuranceRenewal = '{0}',", txtInsuranceCompany.Text)
                SQL &= String.Format(" OR_CR = '{0}',", txtOR.Text)
                SQL &= String.Format(" TimeScore = '{0}',", iTime_Score.Value)
                SQL &= String.Format(" HistoryScore = '{0}',", iHistory_Score.Value)
                SQL &= String.Format(" RepaymentScore = '{0}',", iRepayment_Score.Value)
                SQL &= String.Format(" SettlementScore = '{0}',", iSettlement_Score.Value)
                SQL &= String.Format(" CreditScore = '{0}',", iCredit_Score.Value)
                SQL &= String.Format(" RemarksScore = '{0}',", txtRemarks_Score.Text)
                SQL &= String.Format(" LoanType = '{0}',", cbxLoanType.Text)
                SQL &= String.Format(" Remarks = '{0}'", rExplanation.Text.InsertQuote)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)

                Logs("Credit Referral Slip", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If dtpAsOf.Text = dtpAsOf.Tag Then
            Else
                Change &= String.Format("Change As Of Date from {0} to {1}. ", dtpAsOf.Tag, dtpAsOf.Text)
            End If
            If dOutstanding.Text = dOutstanding.Tag Then
            Else
                Change &= String.Format("Change Outstanding from {0} to {1}. ", dOutstanding.Tag, dOutstanding.Text)
            End If
            If dInterestDue.Text = dInterestDue.Tag Then
            Else
                Change &= String.Format("Change Interest Due from {0} to {1}. ", dInterestDue.Tag, dInterestDue.Text)
            End If
            If dLPC.Text = dLPC.Tag Then
            Else
                Change &= String.Format("Change LPC from {0} to {1}. ", dLPC.Tag, dLPC.Text)
            End If
            If dBalance.Text = dBalance.Tag Then
            Else
                Change &= String.Format("Change Balance from {0} to {1}. ", dBalance.Tag, dBalance.Text)
            End If
            If dRPPD.Text = dRPPD.Tag Then
            Else
                Change &= String.Format("Change RPPD from {0} to {1}. ", dRPPD.Tag, dRPPD.Text)
            End If
            If dUDI.Text = dUDI.Tag Then
            Else
                Change &= String.Format("Change UDI from {0} to {1}. ", dUDI.Tag, dUDI.Text)
            End If
            If dAmountDue.Text = dAmountDue.Tag Then
            Else
                Change &= String.Format("Change Amount Due from {0} to {1}. ", dAmountDue.Tag, dAmountDue.Text)
            End If
            If dPrincipalBalance.Text = dPrincipalBalance.Tag Then
            Else
                Change &= String.Format("Change Principal Balance from {0} to {1}. ", dPrincipalBalance.Tag, dPrincipalBalance.Text)
            End If
            If iPayments.Text = iPayments.Tag Then
            Else
                Change &= String.Format("Change Payments Made from {0} to {1}. ", iPayments.Tag, iPayments.Text)
            End If
            If txtTerms.Text = txtTerms.Tag Then
            Else
                Change &= String.Format("Change Terms from {0} to {1}. ", txtTerms.Tag, txtTerms.Text)
            End If
            If txtNumberLPC.Text = txtNumberLPC.Tag Then
            Else
                Change &= String.Format("Change Number LPC from {0} to {1}. ", txtNumberLPC.Tag, txtNumberLPC.Text)
            End If
            If txtDeliquency.Text = txtDeliquency.Tag Then
            Else
                Change &= String.Format("Change Deliquency from {0} to {1}. ", txtDeliquency.Tag, txtDeliquency.Text)
            End If
            If txtPresentStatus.Text = txtPresentStatus.Tag Then
            Else
                Change &= String.Format("Change Present Status from {0} to {1}. ", txtPresentStatus.Tag, txtPresentStatus.Text)
            End If
            If dAmount_Insurance.Text = dAmount_Insurance.Tag Then
            Else
                Change &= String.Format("Change Amount Insurance from {0} to {1}. ", dAmount_Insurance.Tag, dAmount_Insurance.Text)
            End If
            If txtInsuranceInCharge.Text = txtInsuranceInCharge.Tag Then
            Else
                Change &= String.Format("Change Insurance In Charge from {0} to {1}. ", txtInsuranceInCharge.Tag, txtInsuranceInCharge.Text)
            End If
            If dtpGranted_Insurance.Text = dtpGranted_Insurance.Tag Then
            Else
                Change &= String.Format("Change Granted Date of Insurance from {0} to {1}. ", dtpGranted_Insurance.Tag, dtpGranted_Insurance.Text)
            End If
            If dAmount_Policy.Text = dAmount_Policy.Tag Then
            Else
                Change &= String.Format("Change Amount Policy from {0} to {1}. ", dAmount_Policy.Tag, dAmount_Policy.Text)
            End If
            If dtpGranted_Policy.Text = dtpGranted_Policy.Tag Then
            Else
                Change &= String.Format("Change Granted Date of Policy from {0} to {1}. ", dtpGranted_Policy.Tag, dtpGranted_Policy.Text)
            End If
            If dAmount_Renewal.Text = dAmount_Renewal.Tag Then
            Else
                Change &= String.Format("Change Amount Renewal from {0} to {1}. ", dAmount_Renewal.Tag, dAmount_Renewal.Text)
            End If
            If txtInsuranceCompany.Text = txtInsuranceCompany.Tag Then
            Else
                Change &= String.Format("Change Insurance Company from {0} to {1}. ", txtInsuranceCompany.Tag, txtInsuranceCompany.Text)
            End If
            If txtOR.Text = txtOR.Tag Then
            Else
                Change &= String.Format("Change OR/CR from {0} to {1}. ", txtOR.Tag, txtOR.Text)
            End If
            If iTime_Score.Text = iTime_Score.Tag Then
            Else
                Change &= String.Format("Change Time Score from {0} to {1}. ", iTime_Score.Tag, iTime_Score.Text)
            End If
            If iHistory_Score.Text = iHistory_Score.Tag Then
            Else
                Change &= String.Format("Change History Score from {0} to {1}. ", iHistory_Score.Tag, iHistory_Score.Text)
            End If
            If iRepayment_Score.Text = iRepayment_Score.Tag Then
            Else
                Change &= String.Format("Change Repayment Score from {0} to {1}. ", iRepayment_Score.Tag, iRepayment_Score.Text)
            End If
            If iSettlement_Score.Text = iSettlement_Score.Tag Then
            Else
                Change &= String.Format("Change Settlement Score from {0} to {1}. ", iSettlement_Score.Tag, iSettlement_Score.Text)
            End If
            If iCredit_Score.Text = iCredit_Score.Tag Then
            Else
                Change &= String.Format("Change Credit Score from {0} to {1}. ", iCredit_Score.Tag, iCredit_Score.Text)
            End If
            If txtRemarks_Score.Text = txtRemarks_Score.Tag Then
            Else
                Change &= String.Format("Change Summary Remarks from {0} to {1}. ", txtRemarks_Score.Tag, txtRemarks_Score.Text)
            End If
            If cbxLoanType.Text = cbxLoanType.Tag Then
            Else
                Change &= String.Format("Change Loan Type from {0} to {1}. ", cbxLoanType.Tag, cbxLoanType.Text)
            End If
            If rExplanation.Text = rExplanation.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", rExplanation.Tag, rExplanation.Text)
            End If
            If cbxRequested.Text = cbxRequested.Tag Then
            Else
                Change &= String.Format("Change Requested By from {0} to {1}. ", cbxRequested.Tag, cbxRequested.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Credit Referral Slip - Changes", ex.Message.ToString)
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
            btnPrint.Enabled = False
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            DataObject(String.Format("UPDATE credit_referral SET `status` = 'CANCELLED' WHERE ID = '{0}';", ID))
            Logs("Credit Referral Slip", "Cancel", Reason, String.Format("Cancel Credit Referral of {0}.", cbxApplication.Text), "", "", "")
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub DAmount_Insurance_ValueChanged(sender As Object, e As EventArgs) Handles dAmount_Insurance.ValueChanged
        If dAmount_Insurance.Value > 0 Then
            dtpGranted_Insurance.CustomFormat = "MMMM dd, yyyy"
        Else
            dtpGranted_Insurance.CustomFormat = ""
        End If
    End Sub

    Private Sub DAmount_Policy_ValueChanged(sender As Object, e As EventArgs) Handles dAmount_Policy.ValueChanged
        If dAmount_Policy.Value > 0 Then
            dtpGranted_Policy.CustomFormat = "MMMM dd, yyyy"
        Else
            dtpGranted_Policy.CustomFormat = ""
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            GenerateCRS(True, "")
            Logs("Credit Referral", "Print", "[SENSITIVE] Print Credit Referral " & txtDocumentNumber.Text, "", "", "", "")
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("CREDIT REFERRAL LIST", GridControl1)
            Logs("Credit Referral", "Print", "[SENSITIVE] Print Credit Referral List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GenerateCRS(Show As Boolean, FName As String)
        Dim Report As New RptCreditReferralSlip
        With Report
            .Name = "Credit Referral Slip of " & cbxApplication.Text & " [" & txtDocumentNumber.Text & "]"
            .lblBorrower.Text = cbxApplication.Text
            .lblAccountNumber.Text = cbxAccountNumber.Text
            .lblCoMaker1.Text = txtComaker1.Text
            .lblCoMaker2.Text = txtComaker2.Text
            .lblCoMaker3.Text = txtComaker3.Text
            .lblCoMaker4.Text = txtComaker4.Text

            .cbxDaily.Checked = True
            .cbxWeekly.Checked = True
            .cbxBimonthly.Checked = True
            .cbxMonthly.Checked = True

            .lblDocumentDate.Text = dtpDate.Text
            .lblDocumentNumber.Text = txtDocumentNumber.Text
            .lblDue.Text = iDue.Text
            .lblDateGranted.Text = dtpGranted.Text
            .lblPrincipal.Text = dPrincipal.Text
            .lblFaceAmount.Text = dFaceAmount.Text
            .lblMonthlyAmortization.Text = dMonthlyAmortization.Text

            .lblCollateral_1.Text = txtCollateral_1.Text
            .lblCollateral_2.Text = txtCollateral_2.Text
            .lblCollateral_3.Text = txtCollateral_3.Text
            .lblCollateral_4.Text = txtCollateral_4.Text
            .lblCollateral_5.Text = txtCollateral_5.Text
            .lblCollateral_6.Text = txtCollateral_6.Text
            .lblCollateral_7.Text = txtCollateral_7.Text

            .txtAsOf.Text = dtpAsOf.Text
            .lblOutstanding.Text = dOutstanding.Text
            .lblInterestDue.Text = dInterestDue.Text
            .lblLPC.Text = dLPC.Text
            .lblBalance.Text = dBalance.Text
            .lblRPPD.Text = dRPPD.Text
            .lblUDI.Text = dUDI.Text
            .lblTotalAmountDue.Text = dAmountDue.Text
            .lblPrincipalBalance.Text = dPrincipalBalance.Text
            .lblNumberPayments.Text = iPayments.Text
            .lblTerms.Text = txtTerms.Text
            .lblNumberLPC.Text = txtNumberLPC.Text
            .lblDeliquency.Text = txtDeliquency.Text
            .lblPresentStatus.Text = txtPresentStatus.Text
            .lblLoanType.Text = cbxLoanType.Text

            .lblAmount_Insurance.Text = dAmount_Insurance.Text
            .lblDateInsurance.Text = dtpGranted_Insurance.Text
            .lblInsuranceInCharge.Text = txtInsuranceInCharge.Text
            .lblAmountPolicy.Text = dAmount_Policy.Text
            .lblDatePolicy.Text = dtpGranted_Policy.Text
            .lblAmountRenewal.Text = dAmount_Renewal.Text
            .lblInsuranceCompany.Text = txtInsuranceCompany.Text
            .lblOR_CR.Text = txtOR.Text

            .lblTimeScore.Text = iTime_Score.Text
            .lblHistoryScore.Text = iHistory_Score.Text
            .lblPaymentScore.Text = iRepayment_Score.Text
            .lblSettleScore.Text = iSettlement_Score.Text
            .lblCreditScore.Text = iCredit_Score.Text
            .lblTotalScore.Text = iTotal_Score.Text
            .lblTimeScoreT.Text = dTime_Score.Text
            .lblHistoryScoreT.Text = dHistory_Score.Text
            .lblPaymentScoreT.Text = dRepayment_Score.Text
            .lblSettleScoreT.Text = dSettlement_Score.Text
            .lblCreditScoreT.Text = dCredit_Score.Text
            .lblTotalScoreT.Text = dTotal_Score.Text
            .lblRemarksScore.Text = txtRemarks_Score.Text
            .lblRemarks.Text = rExplanation.Text

            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblRequestedBy.Text = cbxRequested.Text

            Dim Active As New SubRptActive With {
                .DataSource = GridControl2.DataSource
            }
            .subRpt_Active.ReportSource = Active
            With Active
                .lblAccountNumber.DataBindings.Add("Text", GridControl2.DataSource, "Account Number")
                .lblPrincipal.DataBindings.Add("Text", GridControl2.DataSource, "Principal")
                .lblFaceAmount.DataBindings.Add("Text", GridControl2.DataSource, "Face Amount")
                .lblOutstanding.DataBindings.Add("Text", GridControl2.DataSource, "Outstanding Bal")
                .lblGMA.DataBindings.Add("Text", GridControl2.DataSource, "GMA")
                .lblDateGranted.DataBindings.Add("Text", GridControl2.DataSource, "Date Granted")
                .lblMaturityDate.DataBindings.Add("Text", GridControl2.DataSource, "Maturity Date")
                .lblRemarks.DataBindings.Add("Text", GridControl2.DataSource, "Remarks")
            End With

            Dim Closed As New SubRptActive With {
                .DataSource = GridControl3.DataSource
            }
            .subRpt_Closed.ReportSource = Closed
            With Closed
                .lblAccountNumber.DataBindings.Add("Text", GridControl3.DataSource, "Account Number")
                .lblPrincipal.DataBindings.Add("Text", GridControl3.DataSource, "Principal")
                .lblFaceAmount.DataBindings.Add("Text", GridControl3.DataSource, "Face Amount")
                .lblOutstanding.DataBindings.Add("Text", GridControl3.DataSource, "Outstanding Bal")
                .lblGMA.DataBindings.Add("Text", GridControl3.DataSource, "GMA")
                .lblDateGranted.DataBindings.Add("Text", GridControl3.DataSource, "Date Granted")
                .lblMaturityDate.DataBindings.Add("Text", GridControl3.DataSource, "Maturity Date")
                .lblRemarks.DataBindings.Add("Text", GridControl3.DataSource, "Remarks")
            End With

            If Show Then
                .ShowPreview()
            Else
                Try
                    .ExportToPdf(FName)
                Catch ex As Exception
                End Try
            End If
        End With
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
        ElseIf (e.Control And e.KeyCode = Keys.X) Then
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

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
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
            cbxApplication.SelectedValue = .GetFocusedRowCellValue("BorrowerID")
            dtpDate.Value = .GetFocusedRowCellValue("Document Date")
            txtDocumentNumber.Text = .GetFocusedRowCellValue("Document Number")
            If .GetFocusedRowCellValue("Credit Number") = "" Then
            Else
                cbxAccountNumber.SelectedValue = .GetFocusedRowCellValue("Credit Number")
            End If

            dtpAsOf.Value = .GetFocusedRowCellValue("AsOf")
            dtpAsOf.Tag = .GetFocusedRowCellValue("AsOf")
            dOutstanding.Value = .GetFocusedRowCellValue("Outstanding")
            dOutstanding.Tag = .GetFocusedRowCellValue("Outstanding")
            dInterestDue.Value = .GetFocusedRowCellValue("InterestDue")
            dInterestDue.Tag = .GetFocusedRowCellValue("InterestDue")
            dLPC.Value = .GetFocusedRowCellValue("LPC")
            dLPC.Tag = .GetFocusedRowCellValue("LPC")
            dBalance.Value = .GetFocusedRowCellValue("Balance")
            dBalance.Tag = .GetFocusedRowCellValue("Balance")
            dRPPD.Value = .GetFocusedRowCellValue("RPPD")
            dRPPD.Tag = .GetFocusedRowCellValue("RPPD")
            dUDI.Value = .GetFocusedRowCellValue("UDI")
            dUDI.Tag = .GetFocusedRowCellValue("UDI")
            dAmountDue.Value = .GetFocusedRowCellValue("AmountDue")
            dAmountDue.Tag = .GetFocusedRowCellValue("AmountDue")
            dPrincipalBalance.Value = .GetFocusedRowCellValue("PrincipalBalance")
            dPrincipalBalance.Tag = .GetFocusedRowCellValue("PrincipalBalance")
            iPayments.Value = .GetFocusedRowCellValue("Payments")
            iPayments.Tag = .GetFocusedRowCellValue("Payments")
            txtTerms.Text = .GetFocusedRowCellValue("Terms")
            txtTerms.Tag = .GetFocusedRowCellValue("Terms")
            txtNumberLPC.Text = .GetFocusedRowCellValue("NumberLPC")
            txtNumberLPC.Tag = .GetFocusedRowCellValue("NumberLPC")
            txtDeliquency.Text = .GetFocusedRowCellValue("Deliquency")
            txtDeliquency.Tag = .GetFocusedRowCellValue("Deliquency")
            txtPresentStatus.Text = .GetFocusedRowCellValue("PresentStatus")
            txtPresentStatus.Tag = .GetFocusedRowCellValue("PresentStatus")

            dAmount_Insurance.Value = .GetFocusedRowCellValue("AmountInsurance")
            dAmount_Insurance.Tag = .GetFocusedRowCellValue("AmountInsurance")
            If .GetFocusedRowCellValue("DateInsurance") = "" Then
            Else
                dtpGranted_Insurance.Value = .GetFocusedRowCellValue("DateInsurance")
            End If
            dtpGranted_Insurance.Tag = .GetFocusedRowCellValue("DateInsurance")
            txtInsuranceInCharge.Text = .GetFocusedRowCellValue("InsuranceInCharge")
            txtInsuranceInCharge.Tag = .GetFocusedRowCellValue("InsuranceInCharge")
            dAmount_Policy.Value = .GetFocusedRowCellValue("AmountPolicy")
            dAmount_Policy.Tag = .GetFocusedRowCellValue("AmountPolicy")
            If .GetFocusedRowCellValue("DatePolicy") = "" Then
            Else
                dtpGranted_Policy.Value = .GetFocusedRowCellValue("DatePolicy")
            End If
            dtpGranted_Policy.Tag = .GetFocusedRowCellValue("DatePolicy")
            dAmount_Renewal.Value = .GetFocusedRowCellValue("AmountRenewal")
            dAmount_Renewal.Tag = .GetFocusedRowCellValue("AmountRenewal")
            txtInsuranceCompany.Text = .GetFocusedRowCellValue("InsuranceRenewal")
            txtInsuranceCompany.Tag = .GetFocusedRowCellValue("InsuranceRenewal")
            txtOR.Text = .GetFocusedRowCellValue("OR_CR")
            txtOR.Tag = .GetFocusedRowCellValue("OR_CR")
            iTime_Score.Value = .GetFocusedRowCellValue("TimeScore")
            iTime_Score.Tag = .GetFocusedRowCellValue("TimeScore")
            iHistory_Score.Value = .GetFocusedRowCellValue("HistoryScore")
            iHistory_Score.Tag = .GetFocusedRowCellValue("HistoryScore")
            iRepayment_Score.Value = .GetFocusedRowCellValue("RepaymentScore")
            iRepayment_Score.Tag = .GetFocusedRowCellValue("RepaymentScore")
            iSettlement_Score.Value = .GetFocusedRowCellValue("SettlementScore")
            iSettlement_Score.Tag = .GetFocusedRowCellValue("SettlementScore")
            iCredit_Score.Value = .GetFocusedRowCellValue("CreditScore")
            iCredit_Score.Tag = .GetFocusedRowCellValue("CreditScore")
            txtRemarks_Score.Text = .GetFocusedRowCellValue("RemarksScore")
            txtRemarks_Score.Tag = .GetFocusedRowCellValue("RemarksScore")
            cbxLoanType.Text = .GetFocusedRowCellValue("LoanType")
            cbxLoanType.Tag = .GetFocusedRowCellValue("LoanType")
            rExplanation.Text = .GetFocusedRowCellValue("Remarks")
            rExplanation.Tag = .GetFocusedRowCellValue("Remarks")
            cbxPreparedBy.SelectedValue = .GetFocusedRowCellValue("PreparedID")
            cbxRequested.SelectedValue = .GetFocusedRowCellValue("RequestedID")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnPrint.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Public Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)

            dtpFrom.Value = monday
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = monday.AddDays(6)
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
        Else
            cbxDisplay.SelectedIndex = 0
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub CbxApplication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApplication.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            Clear(False)
        Else
            Cursor = Cursors.WaitCursor
            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            FirstLoad = True
            LoadAccountNumber()
            LoadAccounts()
            FirstLoad = False

            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub LoadAccounts()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    CreditNumber,"
        SQL &= "    CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)) AS 'Account Number',"
        SQL &= "    FORMAT(AmountApplied,2) AS 'Principal',"
        SQL &= "    FORMAT(Face_Amount,2) AS 'Face Amount',"
        SQL &= "    FORMAT(IF(PaymentRequest = 'CLOSED',0,Face_Amount - IFNULL((SELECT SUM(Amount) FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus IN ('PENDING','POSTED') AND ReferenceN = credit_application.CreditNumber AND EntryType = 'CREDIT' AND PaidFor IN ('RPPD','RPPD-A','RPPD-W','Principal','UDI')),0)),2) AS 'Outstanding Bal',"
        SQL &= "    FORMAT(GMA,2) AS 'GMA',"
        SQL &= "    DATE_FORMAT(Released,'%M %d, %Y') AS 'Date Granted',"
        SQL &= "    DATE_FORMAT(ADDDATE(Released, INTERVAL IF((SELECT payment FROM product_setup WHERE ID = credit_application.product_id) = 'Bimonthly',credit_application.Terms / 2,credit_application.Terms) MONTH),'%M %d, %Y') AS 'Maturity Date',"
        SQL &= "    '' AS 'Remarks'"
        SQL &= " FROM credit_application WHERE `status` = 'ACTIVE' "
        SQL &= String.Format("    AND BorrowerID = '{0}' ", cbxApplication.SelectedValue)
        GridControl2.DataSource = DataSource(SQL & String.Format(" AND PaymentRequest = 'RELEASED' AND Released <= '{0}' ORDER BY DATE(`Date Granted`) DESC;", FormatDatePicker(dtpAsOf)))
        GridControl3.DataSource = DataSource(SQL & String.Format(" AND PaymentRequest = 'CLOSED' AND IF(ClosedDate='',TRUE,ClosedDate <= '{0}') ORDER BY DATE(`Date Granted`) DESC;", FormatDatePicker(dtpAsOf)))
        If GridView2.RowCount > 6 Then
            GridColumn20.Width = 159 - 17
        Else
            GridColumn20.Width = 159
        End If
        If GridView3.RowCount > 6 Then
            GridColumn28.Width = 159 - 17
        Else
            GridColumn28.Width = 159
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxApplication_TextChanged(sender As Object, e As EventArgs) Handles cbxApplication.TextChanged
        If cbxApplication.Text = "" Then
            Clear(False)
        End If
    End Sub

    Private Sub CbxAccountNumber_TextChanged(sender As Object, e As EventArgs) Handles cbxAccountNumber.TextChanged
        If cbxAccountNumber.Text = "" Then
            iDue.Value = 0
            dtpGranted.Value = Date.Now
            dPrincipal.Value = 0
            dFaceAmount.Value = 0
            dMonthlyAmortization.Value = 0

            dtpAsOf.Value = Date.Now
            dAmount_Insurance.Value = 0
            txtInsuranceInCharge.Text = ""
            dtpGranted_Insurance.Value = Date.Now
            dAmount_Policy.Value = 0
            dAmount_Renewal.Value = 0
            dtpGranted_Policy.Value = Date.Now
            txtInsuranceCompany.Text = ""
            txtOR.Text = ""

            iTime_Score.Value = 0
            iHistory_Score.Value = 0
            iRepayment_Score.Value = 0
            iSettlement_Score.Value = 0
            iCredit_Score.Value = 0
            txtRemarks_Score.Text = ""
            cbxLoanType.SelectedIndex = -1
            rExplanation.Text = ""
        End If
    End Sub

    Private Sub CbxAccountNumber_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAccountNumber.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxAccountNumber.SelectedIndex = -1 Or cbxAccountNumber.Text = "" Then
            Clear(False)
        Else
            Cursor = Cursors.WaitCursor
            Dim drv As DataRowView = DirectCast(cbxAccountNumber.SelectedItem, DataRowView)
            txtComaker1.Text = drv("CoMaker1")
            txtComaker2.Text = drv("CoMaker2")
            txtComaker3.Text = drv("CoMaker3")
            txtComaker4.Text = drv("CoMaker4")
            iDue.Value = drv("Due")
            dtpGranted.Value = drv("PN")
            dPrincipal.Value = drv("AmountApplied")
            dFaceAmount.Value = drv("Face_Amount")
            dMonthlyAmortization.Value = drv("GMA")

            Dim DT As New DataTable
            If drv("Mortgage_ID") = 1 Then
                DT = DataSource(String.Format("SELECT CONCAT(TRIM(`Year`), ' ', Make, ' ', `Type`, ' Plate Number ', PlateNum) AS 'Collateral' FROM collateral_ve WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}';", cbxAccountNumber.SelectedValue))
            ElseIf drv("Mortgage_ID") = 2 Then
                DT = DataSource(String.Format("SELECT CONCAT(TCT, ' of the Registry of ', (SELECT registry_deeds FROM appraise_RE WHERE appraise_RE.CollateralNumber = collateral_re.CollateralNumber ORDER BY ID DESC LIMIT 1)) AS 'Collateral' FROM collateral_re WHERE `status` = 'ACTIVE' AND CreditNumber = '{0}';", cbxAccountNumber.SelectedValue))
            End If
            txtCollateral_1.Text = ""
            txtCollateral_2.Text = ""
            txtCollateral_3.Text = ""
            txtCollateral_4.Text = ""
            txtCollateral_5.Text = ""
            txtCollateral_6.Text = ""
            txtCollateral_7.Text = ""
            If DT.Rows.Count > 0 Then
                txtCollateral_1.Text = DT(0)("Collateral")
                If DT.Rows.Count > 1 Then
                    txtCollateral_2.Text = DT(1)("Collateral")
                    If DT.Rows.Count > 2 Then
                        txtCollateral_3.Text = DT(2)("Collateral")
                        If DT.Rows.Count > 3 Then
                            txtCollateral_4.Text = DT(3)("Collateral")
                            If DT.Rows.Count > 4 Then
                                txtCollateral_5.Text = DT(4)("Collateral")
                                If DT.Rows.Count > 5 Then
                                    txtCollateral_6.Text = DT(5)("Collateral")
                                    If DT.Rows.Count > 6 Then
                                        txtCollateral_7.Text = DT(6)("Collateral")
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
            If drv("TermType") = "DAY" Then
                cbxDaily.Checked = True
            ElseIf drv("TermType") = "WEEK" Then
                cbxWeekly.Checked = True
            ElseIf drv("TermType") = "MONTH" Then
                cbxMonthly.Checked = True
            ElseIf drv("TermType") = "YEAR" Then
            Else
                cbxBimonthly.Checked = True
            End If

            dOutstanding.Value = 0
            dInterestDue.Value = 0
            dLPC.Value = 0
            dBalance.Value = 0
            dRPPD.Value = 0
            dUDI.Value = 0
            dAmountDue.Value = 0

            dPrincipalBalance.Value = 0
            iPayments.Value = 0
            txtTerms.Text = 1 & " Month(s)"
            txtNumberLPC.Text = ""
            txtDeliquency.Text = ""
            txtPresentStatus.Text = "UPDATED"
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub DtpDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpDate.ValueChanged
        GetDocumentNumber()
    End Sub

    Private Sub GetDocumentNumber()
        If btnSave.Text = "&Save" Then
            txtDocumentNumber.Text = DataObject(String.Format("SELECT CONCAT('CRS-', '{1}', '{2}', '-', LPAD(COUNT(ID) + 1,4,'0')) FROM credit_referral WHERE branch_id = '{0}' AND YEAR(DocumentDate) = YEAR('{3}');", Branch_ID, Branch_Code, Format(dtpDate.Value, "yy"), Format(dtpDate.Value, "yyyy-MM-dd")))
        End If
    End Sub

    Private Sub DtpAsOf_Leave(sender As Object, e As EventArgs) Handles dtpAsOf.Leave
        LoadAccounts()
    End Sub

    Private Sub BtnLedger_Click(sender As Object, e As EventArgs) Handles BtnLedger.Click
        Try
            If GridView2.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = GridView2.GetFocusedRowCellValue("CreditNumber")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnLedger2_Click(sender As Object, e As EventArgs) Handles BtnLedger2.Click
        Try
            If GridView3.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = GridView3.GetFocusedRowCellValue("CreditNumber")
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class