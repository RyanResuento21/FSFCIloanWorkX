Public Class FrmReinstatement

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmReinstatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        LoadCompanyMode()

        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        cbxDisplay.SelectedIndex = 0

        dtpBirthdate_B.Value = Date.Now
        dtpApprovedD.Value = Date.Now

        cbxApplication.ValueMember = "CreditNumber"
        cbxApplication.DisplayMember = "Name"
        LoadApplication()

        LoadData()
        Timer_Date.Start()
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

            GetLabelFontSettings({LabelX33, LabelX17, LabelX7, LabelX2, LabelX6, LabelX9, LabelX12, LabelX16, LabelX19, LabelX21, LabelX37, LabelX41, LabelX45, LabelX32, LabelX1, LabelX30, LabelX4, LabelX5, LabelX8, LabelX10, lblPlateNum, LabelX15, LabelX18, LabelX22, LabelX20, LabelX35, LabelX40, LabelX44, lblMonthsMD, LabelX31, LabelX39, LabelX47, LabelX49, LabelX48})

            GetLabelFontSettingsRed({LabelX155, LabelX13, LabelX36})

            GetLabelFontSettingsRedDefault({LabelX3, LabelX14})

            GetTextBoxFontSettings({txtSpouse, txtAddress, txtComaker1, txtComaker2, txtComaker3, txtComaker4, txtCollateral, txtMotorNum, txtORNumber, txtTCT, txtEmail, txtPlus63, TextBoxX3, TextBoxX5, TextBoxX8, TextBoxX11, txtMobile, txtMobileC1, txtMobileC2, txtMobileC3, txtMobileC4, txtPlateNum, txtChassisNum, txtColor, txtLocation, txtArea, txtCI, txtReferred})

            GetCheckBoxFontSettings({cbxAll})

            GetComboBoxFontSettings({cbxApplication, cbxDisplay})

            GetDateTimeInputFontSettings({dtpBirthdate_B, dtpFrom, dtpTo})

            GetDateTimeInputFontSettingsDefault({dtpApprovedD})

            GetIntegerInputFontSettingsDefault({iDays})

            GetIntegerInputFontSettings({iTerms})

            GetDoubleInputFontSettings({dPrincipal, dUDI, dRPPD, dFaceAmount, dRate, dGMA, dMR, dNMA})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnPrint, btnSearch})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Reinstatement - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Reinstatement", lblTitle.Text)
    End Sub

    Private Sub LoadApplication()
        Dim SQL As String = "SELECT C.CreditNumber, C.Product, BorrowerID, CI_ApproveDDate, "
        SQL &= "   CONCAT('[ ', C.CreditNumber, ' ] - ', IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Name',"
        SQL &= "   CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B) AS 'FullN',"
        SQL &= "   CONCAT(IF(FirstN_S = '','',CONCAT(FirstN_S, ' ')), IF(MiddleN_S = '','',CONCAT(MiddleN_S, ' ')), IF(LastN_S = '','',CONCAT(LastN_S, ' ')), Suffix_S) AS 'Spouse',"
        SQL &= "   CONCAT(IF(FirstN_C1 = '','',CONCAT(FirstN_C1, ' ')), IF(MiddleN_C1 = '','',CONCAT(MiddleN_C1, ' ')), IF(LastN_C1 = '','',CONCAT(LastN_C1, ' ')), Suffix_C1) AS 'Comaker1',"
        SQL &= "   CONCAT(IF(FirstN_C2 = '','',CONCAT(FirstN_C2, ' ')), IF(MiddleN_C2 = '','',CONCAT(MiddleN_C2, ' ')), IF(LastN_C2 = '','',CONCAT(LastN_C2, ' ')), Suffix_C2) AS 'Comaker2',"
        SQL &= "   CONCAT(IF(FirstN_C3 = '','',CONCAT(FirstN_C3, ' ')), IF(MiddleN_C3 = '','',CONCAT(MiddleN_C3, ' ')), IF(LastN_C3 = '','',CONCAT(LastN_C3, ' ')), Suffix_C3) AS 'Comaker3',"
        SQL &= "   CONCAT(IF(FirstN_C4 = '','',CONCAT(FirstN_C4, ' ')), IF(MiddleN_C4 = '','',CONCAT(MiddleN_C4, ' ')), IF(LastN_C4 = '','',CONCAT(LastN_C4, ' ')), Suffix_C4) AS 'Comaker4',"
        SQL &= "   CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) AS 'Address',"
        SQL &= "   IF(FirstN_C1 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 1),'')) AS 'Mobile_C1',"
        SQL &= "   IF(FirstN_C2 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 2),'')) AS 'Mobile_C2',"
        SQL &= "   IF(FirstN_C3 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 3),'')) AS 'Mobile_C3',"
        SQL &= "   IF(FirstN_C4 = '','', IFNULL((SELECT Mobile_C FROM credit_application_comaker CM WHERE `status` = 'ACTIVE' AND CM.CreditNumber = C.CreditNumber AND `Rank` = 4),'')) AS 'Mobile_C4',"
        SQL &= "   CI.Collateral AS 'Collateral',VE.PlateNum, VE.MotorNum, VE.ChassisNum, VE.ORNum, VE.BodyColor ,RE.TCT, RE.Location, RE.Area, (SELECT `code` FROM product_setup WHERE ID = C.product_id) AS 'Product_Code',"
        SQL &= "   (SELECT LEFT(Employee(empl_id),LOCATE(' ',Employee(empl_id)) - 1) FROM users U WHERE U.user_code = CI.user_code) AS 'CI', (SELECT payment FROM product_setup WHERE product_setup.ID = C.product_id) AS 'Payment Type',"
        SQL &= "   loan_type, Birth_B, Email_B, Mobile_B, AmountApplied, Terms, Interest, RPPD, Face_Amount, Interest_Rate, RPPD_Rate, GMA, Rebate, LastN_B, Insurance, IFNULL((SELECT IF(CVDate = '',DATE(NOW()),CVDate) FROM check_received WHERE AssetNumber = C.CreditNumber AND check_type = 'P' AND `status`  IN ('PENDING','ACTIVE') ORDER BY ID DESC LIMIT 1),DATE(NOW())) AS 'CVDate', IFNULL((SELECT GROUP_CONCAT(CVNumber) FROM check_received WHERE AssetNumber = C.CreditNumber AND check_type = 'P' AND `status` IN ('PENDING','ACTIVE')),'') AS 'CVNumber', (SELECT COUNT(ID) FROM check_voucher WHERE `status` = 'ACTIVE' AND ApprovedID = 0 AND Payee_ID = C.CreditNumber) AS 'CV Count',"
        SQL &= "   CONCAT(IF(Agent = '','', CONCAT(Agent, IF(Marketing = '' AND Dealer = '','',' / '))), IF(Marketing = '','', CONCAT(Marketing, IF(Dealer = '','',' / '))), Dealer) AS 'Referred', Interest_N, RPPD_N, Principal_N, trans_date, (SELECT Last_Principal FROM product_setup WHERE product_setup.ID = C.Product_ID ) AS 'Last Principal', Release_OTAC"
        SQL &= " FROM credit_application C"
        SQL &= String.Format("    LEFT JOIN (SELECT CreditNumber, CINumber, user_code, Collateral FROM credit_investigation WHERE `status` = 'ACTIVE' AND ci_status = 'APPROVED' AND Branch_ID IN ({0})) CI ON CI.CreditNumber = C.CreditNumber", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        SQL &= "    LEFT JOIN (SELECT GROUP_CONCAT(PlateNum) AS 'PlateNum', GROUP_CONCAT(EngineNum) AS 'MotorNum', GROUP_CONCAT(ChassisNum) AS 'ChassisNum', GROUP_CONCAT(ORNum) AS 'ORNum', GROUP_CONCAT(BodyColor) AS 'BodyColor', CINumber FROM collateral_ve WHERE `status` = 'ACTIVE' GROUP BY CINumber) VE ON CI.CINumber = VE.CINumber"
        SQL &= "    LEFT JOIN (SELECT GROUP_CONCAT(TCT) AS 'TCT', GROUP_CONCAT(Location) AS 'Location', GROUP_CONCAT(CONCAT(AREA,' SQM')) AS 'Area', CINumber FROM collateral_re WHERE `status` = 'ACTIVE' GROUP BY CINumber) RE ON CI.CINumber = RE.CINumber"
        SQL &= String.Format("  WHERE IFNULL((SELECT ID FROM check_voucher WHERE Payee_ID = C.CreditNumber AND `status` = 'ACTIVE' AND Voucher_Status = 'RECEIVED' LIMIT 1),0) = 0 AND FIND_IN_SET(C.Branch_ID,'{0}') AND C.`status` = 'ACTIVE' AND PaymentRequest NOT IN ('RELEASED','CLOSED') AND C.application_status = 'APPROVED' AND C.CI_Status = 'APPROVED' ORDER BY C.CreditNumber;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        FirstLoad = True
        cbxApplication.DataSource = DataSource(SQL)
        cbxApplication.SelectedIndex = -1
        FirstLoad = False
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "    R.ID,"
        SQL &= "    R.CreditNumber AS 'Credit Number',"
        SQL &= "    IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'Borrower',"
        SQL &= "    DATE_FORMAT(ApprovedDate,'%b %d, %Y') AS 'Approved Date',"
        SQL &= "    DDiff AS 'Days Ago', Branch(Branch_ID) AS 'Branch'"
        SQL &= "  FROM reinstate_application R "
        SQL &= "  LEFT JOIN (SELECT CreditNumber, AssumptionCredit, FirstN_B, MiddleN_B, LastN_B, Suffix_B, FirstN_A, MiddleN_A, LastN_A, Suffix_A FROM credit_application) C ON C.CreditNumber = R.CreditNumber"
        SQL &= String.Format("  WHERE Branch_ID IN ({0}) AND `status` = 'ACTIVE'", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(timestamp) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        SQL &= "  ORDER BY timestamp DESC;"

        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn5.Width = 675
        Else
            GridColumn5.Width = 675 + 17
        End If
        If Multiple_ID.Contains(",") Then
            GridColumn9.Visible = True
            GridColumn9.VisibleIndex = 4
            GridColumn5.Width = GridColumn5.Width - 200
        End If
        Cursor = Cursors.Default
    End Sub

    '**** LEAVE *****
    Private Sub TxtCollateral_Leave(sender As Object, e As EventArgs) Handles txtCollateral.Leave
        txtCollateral.Text = ReplaceText(txtCollateral.Text)
    End Sub
    Private Sub TxtCI_Leave(sender As Object, e As EventArgs) Handles txtCI.Leave
        txtCI.Text = ReplaceText(txtCI.Text)
    End Sub
    Private Sub TxtReferred_Leave(sender As Object, e As EventArgs) Handles txtReferred.Leave
        txtReferred.Text = ReplaceText(txtReferred.Text)
    End Sub
    '**** LEAVE *****

    '***** KEYDOWN *****
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

    '***** KEYDOWN *****
    Private Sub CbxApplication_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxApplication.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCI.Focus()
        End If
    End Sub

    Private Sub TxtCI_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCI.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReferred.Focus()
        End If
    End Sub

    Private Sub TxtReferred_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferred.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***** KEYDOWN *****

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

    Private Function NA(xTring As String)
        Return If(xTring = "", "N/A", xTring)
    End Function

    Private Sub CbxApplication_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApplication.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            Clear()
        Else
            Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
            If drv("BorrowerID").ToString.Contains("C") Then
                LabelX17.Text = "Representative 1 :"
                LabelX2.Text = "Representative 2 :"
                LabelX6.Text = "Representative 3 :"
                LabelX9.Text = "Representative 4 :"
                LabelX12.Text = "Representative 5 :"

                LabelX17.Location = New Point(3, 63)
                txtSpouse.Location = New Point(146, 64)
                LabelX7.Location = New Point(3, 34)
                txtAddress.Location = New Point(146, 35)
            Else
                LabelX17.Text = "Spouse Name :"
                LabelX2.Text = "Co-Maker I :"
                LabelX6.Text = "Co-Maker II :"
                LabelX9.Text = "Co-Maker III :"
                LabelX12.Text = "Co-Maker IV :"

                LabelX17.Location = New Point(3, 34)
                txtSpouse.Location = New Point(146, 35)
                LabelX7.Location = New Point(3, 63)
                txtAddress.Location = New Point(146, 64)
            End If
            txtEmail.Text = drv("Email_B")
            txtSpouse.Text = drv("Spouse")
            dtpBirthdate_B.Value = If(drv("Birth_B") = "", Date.Now, drv("Birth_B"))
            dtpApprovedD.Value = If(drv("CI_ApprovedDate") = "", Date.Now, drv("CI_ApprovedDate"))
            iDays.Value = DateDiff(DateInterval.Day, dtpApprovedD.Value, Date.Now)
            txtAddress.Text = drv("Address")
            txtMobile.Text = drv("Mobile_B")
            txtComaker1.Text = drv("CoMaker1")
            txtMobileC1.Text = drv("Mobile_C1")
            txtComaker2.Text = drv("CoMaker2")
            txtMobileC2.Text = drv("Mobile_C2")
            txtComaker3.Text = drv("CoMaker3")
            txtMobileC3.Text = drv("Mobile_C3")
            txtComaker4.Text = drv("CoMaker4")
            txtMobileC4.Text = drv("Mobile_C4")
            txtCollateral.Text = drv("Collateral")
            txtPlateNum.Text = NA(drv("PlateNum").ToString)
            txtMotorNum.Text = NA(drv("MotorNum").ToString)
            txtChassisNum.Text = NA(drv("ChassisNum").ToString)
            txtORNumber.Text = NA(drv("ORNum").ToString)
            txtColor.Text = NA(drv("BodyColor").ToString)
            txtTCT.Text = NA(drv("TCT").ToString)
            txtLocation.Text = NA(drv("Location").ToString)
            txtArea.Text = NA(drv("Area").ToString)
            dPrincipal.Value = drv("AmountApplied")
            dUDI.Value = drv("Interest")
            dRPPD.Value = drv("RPPD")
            dRPPD.Tag = drv("RPPD_Rate")
            dRate.Value = drv("Interest_Rate")
            dMR.Value = drv("Rebate")
            iTerms.Value = drv("Terms")
            txtCI.Text = drv("CI")
            txtReferred.Text = drv("Referred")
            LoadAmortization(drv("Product"))
            If CompanyMode = 0 Then
                dFaceAmount.Value = dPrincipal.Value + dUDI.Value
                dGMA.Value = CDbl(drv("GMA")) - dMR.Value
            Else
                dFaceAmount.Value = drv("Face_Amount")
                dGMA.Value = drv("GMA")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadAmortization(Product As String)
        Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',Monthly) AS 'Monthly', IF(`No` = '','',InterestIncome) AS 'Interest Income', IF(`No` = '','',RPPD) AS 'RPPD', IF(`No` = '','',PrincipalAllocation) AS 'Principal Allocation', OutstandingPrincipal AS 'Outstanding Principal', Total_RPPD AS 'Total_RPPD', UnearnIncome AS 'Unearn Income', LoansReceivable AS 'Loans Receivable' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", cbxApplication.SelectedValue))
        Dim T_Monthly As Double
        Dim T_Interest As Double
        Dim T_RPPD As Double
        Dim T_Principal As Double
        For x As Integer = 1 To Temp_DT.Rows.Count - 1
            T_Monthly += CDbl(Temp_DT(x)("Monthly"))
            T_Interest += CDbl(Temp_DT(x)("Interest Income"))
            T_RPPD += CDbl(Temp_DT(x)("RPPD"))
            T_Principal += CDbl(Temp_DT(x)("Principal Allocation"))
        Next
        Temp_DT.Rows.Add("", "TOTAL", T_Monthly, T_Interest, T_RPPD, T_Principal, 0, 0, 0, 0)
        GridControl2.DataSource = Temp_DT
        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        If CDbl(drv("Interest_N")) + CDbl(drv("RPPD_N")) + CDbl(drv("Principal_N")) > 0 Then
            Dim TotalInterest As Double
            Dim TotalRPPD As Double
            Dim TotalPrincipal As Double

            Dim Adjustment_Interest As Double
            Dim Adjustment_RPPD As Double
            Dim Adjustment_Principal As Double
            With GridView2
                For x As Integer = 1 To .RowCount
                    If x = .RowCount - 1 Then 'Adjustment
                        Adjustment_Interest = CDbl(.GetRowCellValue(0, "Unearn Income")) - TotalInterest
                        Adjustment_RPPD = CDbl(.GetRowCellValue(0, "Total_RPPD")) - TotalRPPD
                        Adjustment_Principal = CDbl(.GetRowCellValue(0, "Outstanding Principal")) - TotalPrincipal

                        .SetRowCellValue(x, "Outstanding Principal", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Outstanding Principal")) - Adjustment_Principal, 2))
                        .SetRowCellValue(x, "Unearn Income", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Unearn Income")) - Adjustment_Interest, 2))
                        .SetRowCellValue(x, "Total_RPPD", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Total_RPPD")) - Adjustment_RPPD, 2))
                        .SetRowCellValue(x, "Loans Receivable", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Loans Receivable")) - (Adjustment_Principal + Adjustment_Interest + Adjustment_RPPD), 2))
                    Else
                        TotalInterest += CDbl(drv("Interest_N"))
                        TotalRPPD += CDbl(drv("RPPD_N"))
                        TotalPrincipal += CDbl(drv("Principal_N"))

                        .SetRowCellValue(x, "Outstanding Principal", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Outstanding Principal")) - CDbl(drv("Principal_N")), 2))
                        .SetRowCellValue(x, "Unearn Income", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Unearn Income")) - CDbl(drv("Interest_N")), 2))
                        .SetRowCellValue(x, "Total_RPPD", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Total_RPPD")) - CDbl(drv("RPPD_N")), 2))
                        .SetRowCellValue(x, "Loans Receivable", FormatNumber(CDbl(.GetRowCellValue(x - 1, "Loans Receivable")) - (CDbl(drv("Principal_N")) + CDbl(drv("Interest_N")) + CDbl(drv("RPPD_N"))), 2))
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub DMR_ValueChanged(sender As Object, e As EventArgs) Handles dMR.ValueChanged
        If FirstLoad Or cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        If drv("Last Principal") = "Yes" Then
            dNMA.Value = dPrincipal.Value + dMR.Value
        Else
            dNMA.Value = CDbl(drv("GMA")) - dMR.Value
        End If
    End Sub

    Private Sub DGMA_ValueChanged(sender As Object, e As EventArgs) Handles dGMA.ValueChanged
        If FirstLoad Or cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        If drv("Last Principal") = "Yes" Then
            dNMA.Value = dPrincipal.Value + dMR.Value
        Else
            dNMA.Value = CDbl(drv("GMA")) - dMR.Value
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnAdd.Enabled = False
            btnSave.Enabled = True
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            If SuperTabControl1.SelectedTabIndex = 0 Then
                Clear()

                LoadApplication()
            Else
                LoadData()
            End If
        End If
    End Sub

    Private Sub Clear()
        cbxApplication.Enabled = True
        PanelEx10.Enabled = True
        btnSave.Text = "Rein&state"
        btnSave.Enabled = True

        cbxApplication.Text = ""
        txtEmail.Text = ""
        txtSpouse.Text = ""
        txtAddress.Text = ""
        txtMobile.Text = ""
        txtComaker1.Text = ""
        txtMobileC1.Text = ""
        txtComaker2.Text = ""
        txtMobileC2.Text = ""
        txtComaker3.Text = ""
        txtMobileC3.Text = ""
        txtComaker4.Text = ""
        txtMobileC4.Text = ""
        txtCollateral.Text = ""
        txtPlateNum.Text = ""
        txtMotorNum.Text = ""
        txtChassisNum.Text = ""
        txtORNumber.Text = ""
        txtColor.Text = ""
        txtTCT.Text = ""
        txtLocation.Text = ""
        txtArea.Text = ""
        dPrincipal.Value = 0
        dUDI.Value = 0
        dRPPD.Value = 0
        dFaceAmount.Value = 0
        dRate.Value = 0
        dGMA.Value = 0
        dMR.Value = 0
        iTerms.Value = 0
        txtCI.Text = ""
        txtReferred.Text = ""

        dtpBirthdate_B.Value = Date.Now
        dtpApprovedD.Value = Date.Now
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear()
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub CbxApplication_TextChanged(sender As Object, e As EventArgs) Handles cbxApplication.TextChanged
        If cbxApplication.Text = "" Then
            GridControl2.DataSource = Nothing
            Clear()
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
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("RE INSTATEMENT LIST", GridControl1)
            Logs("Reinstatement", "Print", "[SENSITIVE] Print Reinstatement List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxApplication.Text = "" Or cbxApplication.SelectedIndex = -1 Then
            MsgBox("Please select an application to release.", MsgBoxStyle.Information, "Info")
            cbxApplication.DroppedDown = True
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to ReInstate this data?") = MsgBoxResult.Yes Then
            Cursor = Cursors.WaitCursor
            Dim SQL As String = "INSERT INTO reinstate_application SET"
            SQL &= String.Format(" CreditNumber = '{0}', ", cbxApplication.SelectedValue)
            SQL &= String.Format(" ApprovedDate = '{0}', ", Format(dtpApprovedD.Value, "yyyy-MM-dd"))
            SQL &= String.Format(" DDiff = '{0}', ", iDays.Value)
            SQL &= String.Format(" user_code = '{0}', ", User_Code)
            SQL &= String.Format(" branch_id = '{0}';", Branch_ID)

            SQL &= String.Format("UPDATE credit_application SET PaymentRequest = 'PENDING', ci_status = 'CHECKED' WHERE CI_Status = 'APPROVED' AND CreditNumber = '{0}';", cbxApplication.SelectedValue)
            SQL &= String.Format("UPDATE credit_investigation SET ci_status = 'CHECKED' WHERE CI_Status = 'APPROVED' AND CreditNumber = '{0}';", cbxApplication.SelectedValue)
            'UPDATE CHECK VOUCHER
            SQL &= String.Format(" UPDATE check_voucher SET `status` = 'CANCELLED' WHERE Payee_ID = '{0}';", cbxApplication.SelectedValue)
            'UPDATE CHECK RECEIVED
            SQL &= String.Format(" UPDATE check_received SET `status` = 'CANCELLED' WHERE AssetNumber = '{0}' AND check_type = 'P'", cbxApplication.SelectedValue)
            DataObject(SQL)

            Logs("Reinstatement", "Reinstate", String.Format("Reinstatement application with credit number {0}.", cbxApplication.SelectedValue), "", "", "", cbxApplication.SelectedValue)
            Clear()
            LoadData()
            LoadApplication()
            Cursor = Cursors.Default
            MsgBox("Successfully For Reinstatement, Please send an approval to Credit Committee again.", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
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

    Private Sub DtpApprovedD_ValueChanged(sender As Object, e As EventArgs) Handles dtpApprovedD.ValueChanged
        iDays.Value = DateDiff(DateInterval.Day, dtpApprovedD.Value, Date.Now)
    End Sub

    Private Sub LoadCompanyMode()
        Dim drv As DataRowView = DirectCast(cbxApplication.SelectedItem, DataRowView)
        If Prev_CompanyMode = CompanyMode Then
            Exit Sub
        Else
            Prev_CompanyMode = CompanyMode
        End If
        If CompanyMode = 0 Then
            LabelX37.Text = "Interest :"
            GridColumn12.Caption = "Interest"
            LabelX41.Visible = False
            dRPPD.Visible = False
            LabelX40.Visible = False
            dMR.Visible = False

            GridColumn11.Visible = False
            If GridView2.RowCount > 19 Then
                GridColumn6.Width = 26 + (4 - 1)
                GridColumn10.Width = 57 + (15 - 4)
                GridColumn12.Width = 66 + (15 - 4)
                GridColumn7.Width = 66 + (15 - 4)
                GridColumn8.Width = 66 + (17 - 4)
            Else
                GridColumn6.Width = 26 + 4
                GridColumn10.Width = 57 + 15
                GridColumn12.Width = 66 + 15
                GridColumn7.Width = 66 + 15
                GridColumn8.Width = 66 + 17
            End If

            If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
                dGMA.Value = dMR.Value
                dFaceAmount.Value = dPrincipal.Value + dUDI.Value
            Else
                LoadAmortization(drv("Product"))
                dFaceAmount.Value = FormatNumber(CDbl(drv("AmountApplied")) + CDbl(drv("Interest")), 2)
                dGMA.Value = FormatNumber(drv("GMA") - drv("Rebate"), 2)
            End If
        Else
            LabelX37.Text = "UDI :"
            GridColumn12.Caption = "UDI"
            LabelX41.Visible = True
            dRPPD.Visible = True
            LabelX40.Visible = True
            dMR.Visible = True

            GridColumn11.Visible = True
            If GridView2.RowCount > 19 Then
                GridColumn6.Width = 26 - 2
                GridColumn10.Width = 57 - 3
                GridColumn11.Width = 66 - 3
                GridColumn12.Width = 66 - 3
                GridColumn7.Width = 66 - 3
                GridColumn8.Width = 66 - 3
            Else
                GridColumn6.Width = 26
                GridColumn10.Width = 57
                GridColumn11.Width = 66
                GridColumn12.Width = 66
                GridColumn7.Width = 66
                GridColumn8.Width = 66
            End If

            If cbxApplication.SelectedIndex = -1 Or cbxApplication.Text = "" Then
                dGMA.Value = dMR.Value
                dFaceAmount.Value = dPrincipal.Value + dUDI.Value
            Else
                LoadAmortization(drv("Product"))
                dFaceAmount.Value = FormatNumber(drv("Face_Amount"), 2)
                dGMA.Value = FormatNumber(drv("GMA"), 2)
            End If
        End If
    End Sub

    Private Sub Timer_Date_Tick(sender As Object, e As EventArgs) Handles Timer_Date.Tick
        LoadCompanyMode()
    End Sub
End Class