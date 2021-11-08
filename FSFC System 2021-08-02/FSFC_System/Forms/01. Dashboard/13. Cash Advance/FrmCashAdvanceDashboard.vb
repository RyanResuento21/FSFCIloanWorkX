Imports DevExpress.XtraCharts
Public Class FrmCashAdvanceDashboard
    Dim FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date = Date.Now
    Public ToDate As Date = Date.Now
    Public TotalCashAdvance As Integer

    Dim CashAdvanceCount As Integer
    Dim LiquidateExpenseCount As Integer
    Dim BranchCashAdvanceCount As Integer
    Dim CashVoucherCount As Integer
    Dim HighestCashAdvanceAmount As Double
    Dim Meals As Double
    Dim Transportation As Double
    Dim BIR As Double
    Dim RD As Double
    Dim LTO As Double
    Dim Notarization As Double
    Dim Others As Double

    Private Sub FrmCashAdvanceDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        With CashStatus
            .Size = New Point(392, 312)
            .Location = New Point(767, 14)
        End With
        With CashAdvanceChart1
            .Size = New Point(581, 194)
            .Location = New Point(12, 513)
        End With
        With CheckVoucherChart2
            .Size = New Point(560, 194)
            .Location = New Point(599, 513)
        End With

        FirstLoad = True
        CashAdvanceCount = DataObject(String.Format("CALL CAD_CashAdvanceCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        LiquidateExpenseCount = DataObject(String.Format("CALL CAD_LiquidateExpenseCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        BranchCashAdvanceCount = DataObject(String.Format("CALL CAD_BranchCashAdvanceCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        CashVoucherCount = DataObject(String.Format("CALL CAD_CashVoucherCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        HighestCashAdvanceAmount = DataObject(String.Format("CALL CAD_HighestCashAdvanceAmount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        pTotalCashVoucher.Text = FormatNumber(CashVoucherCount, 0)
        pHighestCashAdvance.Text = FormatNumber(HighestCashAdvanceAmount, 0)
        pTotalCashAdvance.Text = FormatNumber(BranchCashAdvanceCount, 0)

        PieChart(CashStatus)
        LineChart1(CashAdvanceChart1)
        LineChart2(CheckVoucherChart2)
        CashAdvanceData()
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX36, LabelX35, lblDepartment1, lblDepartment1N, lblDepartment1P, lblDepartment2, lblDepartment2N, lblDepartment2P, lblDepartment3, lblDepartment3N, lblDepartment3P, lblDepartment4, lblDepartment4N, lblDepartment4P, lblDepartment5, lblDepartment5N, lblDepartment5P, LabelX10, LabelX9, lblBranch1, lblBranch1N, lblBranch1P, lblBranch2, lblBranch2N, lblBranch2P, lblBranch3, lblBranch3N, lblBranch3P, lblBranch4, lblBranch4N, lblBranch4P, lblBranch5, lblBranch5N, lblBranch5P, LabelX28, LabelX27, lbCashStatusN1, lbCashStatusP1, lbCashStatusN2, lbCashStatusP2, lbCashStatusN3, lbCashStatusP3, LabelX47, LabelX46, lblCheckStatusN1, lblCheckStatusP1, lblCheckStatusN2, lblCheckStatusP2, lblCheckStatusN3, lblCheckStatusP3, LabelX4, LabelX3, LabelX6, lblCorporateN, lblCorporateP, LabelX5, lblBranchesN, lblBranchesP, LabelX12, LabelX11, LabelX14, lblLiquidatedN, lblLiquidatedP, LabelX13, lblNonLiquidatedN, lblNonLiquidatedP})

            GetLabelFontSettingsDefault({LabelX7, LabelX22, LabelX21, LabelX30, LabelX16, LabelX29})

            GetButtonFontSettings({BtnChangeView1, BtnChangeView2})

            GetLabelFontSettingsDashboardTitle({LabelX155, LabelX1, LabelX2})

            GetLabelFontSettingsDashboardPanel({pTotalCashVoucher, pHighestCashAdvance, pTotalCashAdvance})

            GetGroupControlFontSettings({gCashAdvanceBranch, gCashAdvanceStatus, gCashAdvanceDepartment, gCashAdvanceUsers, gCashStatus, gCheckStatus})

            GetChartTitleControlFontSettings({CashStatus, CashAdvanceChart1, CheckVoucherChart2})
        Catch ex As Exception
            TriggerBugReport("Cash Advance Dashboard - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Public Sub CashAdvanceData()
        Dim Non_Liquidation As Integer
        Dim Branch_users As Integer
        TotalCashAdvance = DataObject(String.Format("SELECT COUNT(DISTINCT ID) FROM cash_advance WHERE `status` IN ('ACTIVE', 'CANCELLED')", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID)))

        'Cash Advance Liquidation and Non Liquidation Count
        Dim SQL As String = String.Format("SELECT COUNT(DISTINCT ID) AS 'Number' FROM cash_advance WHERE Liquidated = 'Y' AND `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID IN ({1});", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim CA_Liquidation As DataTable = DataSource(SQL)
        If CA_Liquidation.Rows.Count > 0 Then
            lblLiquidatedN.Text = FormatNumber(CA_Liquidation(0)("Number"), 0)
            lblLiquidatedP.Text = FormatNumber((CA_Liquidation(0)("Number") / TotalCashAdvance) * 100, 2) & " %"
            Non_Liquidation = FormatNumber(TotalCashAdvance - (CA_Liquidation(0)("Number")), 0)
            lblNonLiquidatedN.Text = Non_Liquidation
            lblNonLiquidatedP.Text = FormatNumber((Non_Liquidation / TotalCashAdvance) * 100, 2) & " %"
        Else
            lblLiquidatedN.Text = "0"
            lblLiquidatedP.Text = "0.00 %"
            lblNonLiquidatedN.Text = "0"
            lblNonLiquidatedP.Text = "0.00 %"
        End If

        'Cash Advance Users
        SQL = String.Format("SELECT COUNT(DISTINCT ID) AS 'Number' FROM cash_advance WHERE `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID IN ({1});", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim CA_Users As DataTable = DataSource(SQL)
        If CA_Users.Rows.Count > 0 Then
            lblCorporateN.Text = FormatNumber(CA_Users(0)("Number"), 0)
            lblCorporateP.Text = FormatNumber((CA_Users(0)("Number") / TotalCashAdvance) * 100, 2) & " %"
            Branch_users = FormatNumber(TotalCashAdvance - (CA_Users(0)("Number")), 0)
            lblBranchesN.Text = Branch_users
            lblBranchesP.Text = FormatNumber((Branch_users / TotalCashAdvance) * 100, 2) & " %"
        Else
            lblCorporateN.Text = "0"
            lblCorporateP.Text = "0.00 %"
            lblBranchesN.Text = "0"
            lblBranchesP.Text = "0.00 %"
        End If

        'Cash Advance Status
        SQL = "SELECT "
        SQL &= "    FORMAT(COUNT(CASE WHEN slip_status = 'PENDING' THEN ID END),0) AS 'Pending',"
        SQL &= "    FORMAT(COUNT(CASE WHEN slip_status IN ('APPROVED','RECEIVED', 'APPROVED HEAD') THEN ID END),0) AS 'Approved',"
        SQL &= "    FORMAT(COUNT(CASE WHEN slip_status = 'DISAPPROVED' THEN ID END),0) AS 'Disapproved'"
        SQL &= String.Format(" FROM cash_advance WHERE `status` = 'ACTIVE'")
        Dim CA_Status As DataTable = DataSource(SQL)
        If CA_Status.Rows.Count > 0 Then
            lbCashStatusN1.Text = FormatNumber(CA_Status(0)("Pending"), 0)
            lbCashStatusP1.Text = FormatNumber((CA_Status(0)("Pending") / pTotalCashAdvance.Text) * 100, 2) & " %"

            lbCashStatusN2.Text = FormatNumber(CA_Status(0)("Approved"), 0)
            lbCashStatusP2.Text = FormatNumber((CA_Status(0)("Approved") / pTotalCashAdvance.Text) * 100, 2) & " %"

            lbCashStatusN3.Text = FormatNumber(CA_Status(0)("Disapproved"), 0)
            lbCashStatusP3.Text = FormatNumber((CA_Status(0)("Disapproved") / pTotalCashAdvance.Text) * 100, 2) & " %"
        Else
            lbCashStatusN1.Text = "0"
            lbCashStatusP1.Text = "0.00 %"

            lbCashStatusN2.Text = "0"
            lbCashStatusP2.Text = "0.00 %"

            lbCashStatusN3.Text = "0"
            lbCashStatusP3.Text = "0.00 %"
        End If

        'Check Voucher Status
        SQL = "SELECT "
        SQL &= "    FORMAT(COUNT(CASE WHEN voucher_status = 'PENDING' THEN ID END),0) AS 'Pending',"
        SQL &= "    FORMAT(COUNT(CASE WHEN voucher_status IN ('APPROVED','RECEIVED') THEN ID END),0) AS 'Approved',"
        SQL &= "    FORMAT(COUNT(CASE WHEN voucher_status = 'DISAPPROVED' THEN ID END),0) AS 'Disapproved'"
        SQL &= String.Format(" FROM check_voucher WHERE `status` = 'ACTIVE' AND payee_type IN ('L', 'A')")
        Dim CV_Status As DataTable = DataSource(SQL)
        If CV_Status.Rows.Count > 0 Then
            lblCheckStatusN1.Text = FormatNumber(CV_Status(0)("Pending"), 0)
            lblCheckStatusP1.Text = FormatNumber((CV_Status(0)("Pending") / pTotalCashVoucher.Text) * 100, 2) & " %"

            lblCheckStatusN2.Text = FormatNumber(CV_Status(0)("Approved"), 0)
            lblCheckStatusP2.Text = FormatNumber((CV_Status(0)("Approved") / pTotalCashVoucher.Text) * 100, 2) & " %"

            lblCheckStatusN3.Text = FormatNumber(CV_Status(0)("Disapproved"), 0)
            lblCheckStatusP3.Text = FormatNumber((CV_Status(0)("Disapproved") / pTotalCashVoucher.Text) * 100, 2) & " %"
        Else
            lblCheckStatusN1.Text = "0"
            lblCheckStatusP1.Text = "0.00 %"

            lblCheckStatusN2.Text = "0"
            lblCheckStatusP2.Text = "0.00 %"

            lblCheckStatusN3.Text = "0"
            lblCheckStatusP3.Text = "0.00 %"
        End If

        'Top 5 Branch cash advance user
        SQL = String.Format("SELECT b.`branch` AS 'Branch Name', COUNT(DISTINCT p.`ID`) AS 'Number', SUM(p.`Amount`) AS 'Total Amount' FROM check_voucher p INNER JOIN branch b ON p.`Branch_ID` = b.`branchID` WHERE p.`status` IN ('ACTIVE', 'CANCELLED') GROUP BY p.`Branch_ID` ORDER BY `Total Amount` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim CA_Branch As DataTable = DataSource(SQL)
        If CA_Branch.Rows.Count > 0 Then
            lblBranch1.Text = "1. " & CA_Branch(0)("Branch Name")
            lblBranch1N.Text = FormatNumber(CA_Branch(0)("Number"), 0)
            lblBranch1P.Text = FormatCurrency(CA_Branch(0)("Total Amount"), 0)

            If CA_Branch.Rows.Count > 2 - 1 Then
                lblBranch2.Text = "2. " & CA_Branch(2 - 1)("Branch Name")
                lblBranch2N.Text = FormatNumber(CA_Branch(2 - 1)("Number"), 0)
                lblBranch2P.Text = FormatCurrency(CA_Branch(2 - 1)("Total Amount"), 0)
            Else
                lblBranch2.Text = "2. "
                lblBranch2N.Text = "0"
                lblBranch2P.Text = "0.00 "
            End If

            If CA_Branch.Rows.Count > 3 - 1 Then
                lblBranch3.Text = "3. " & CA_Branch(3 - 1)("Branch Name")
                lblBranch3N.Text = FormatNumber(CA_Branch(3 - 1)("Number"), 0)
                lblBranch3P.Text = FormatCurrency(CA_Branch(3 - 1)("Total Amount"), 0)
            Else
                lblBranch3.Text = "3. "
                lblBranch3N.Text = "0"
                lblBranch3P.Text = "0.00 "
            End If

            If CA_Branch.Rows.Count > 4 - 1 Then
                lblBranch4.Text = "4. " & CA_Branch(4 - 1)("Branch Name")
                lblBranch4N.Text = FormatNumber(CA_Branch(4 - 1)("Number"), 0)
                lblBranch4P.Text = FormatCurrency(CA_Branch(4 - 1)("Total Amount"), 0)
            Else
                lblBranch4.Text = "4. "
                lblBranch4N.Text = "0"
                lblBranch4P.Text = "0.00 "
            End If

            If CA_Branch.Rows.Count > 5 - 1 Then
                lblBranch5.Text = "5. " & CA_Branch(5 - 1)("Branch Name")
                lblBranch5N.Text = FormatNumber(CA_Branch(5 - 1)("Number"), 0)
                lblBranch5P.Text = FormatCurrency(CA_Branch(5 - 1)("Total Amount"), 0)
            Else
                lblBranch5.Text = "5. "
                lblBranch5N.Text = "0"
                lblBranch5P.Text = "0.00 "
            End If
        Else
            lblBranch1.Text = "1. "
            lblBranch1N.Text = "0"
            lblBranch1P.Text = "0.00 "

            lblBranch2.Text = "2. "
            lblBranch2N.Text = "0"
            lblBranch2P.Text = "0.00 "

            lblBranch3.Text = "3. "
            lblBranch3N.Text = "0"
            lblBranch3P.Text = "0.00 "

            lblBranch4.Text = "4. "
            lblBranch4N.Text = "0"
            lblBranch4P.Text = "0.00 "

            lblBranch5.Text = "5. "
            lblBranch5N.Text = "0"
            lblBranch5P.Text = "0.00 "
        End If

        'Top 5 Department cash advance user
        SQL = String.Format("SELECT d.`department` AS 'Department Name', COUNT(DISTINCT p.`ID`) AS 'Number', SUM(p.`Amount`) AS 'Total Amount' FROM cv_details p INNER JOIN department_setup d ON p.`DepartmentCode` = d.`department_code` WHERE p.`status` IN ('ACTIVE', 'CANCELLED') GROUP BY p.`DepartmentCode` ORDER BY `Total Amount` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim CA_Departments As DataTable = DataSource(SQL)
        If CA_Departments.Rows.Count > 0 Then
            lblDepartment1.Text = "1. " & CA_Departments(0)("Department Name")
            lblDepartment1N.Text = FormatNumber(CA_Departments(0)("Number"), 0)
            lblDepartment1P.Text = FormatCurrency(CA_Departments(0)("Total Amount"), 0)

            If CA_Departments.Rows.Count > 2 - 1 Then
                lblDepartment2.Text = "2. " & CA_Departments(2 - 1)("Department Name")
                lblDepartment2N.Text = FormatNumber(CA_Departments(2 - 1)("Number"), 0)
                lblDepartment2P.Text = FormatCurrency(CA_Departments(2 - 1)("Total Amount"), 0)
            Else
                lblDepartment2.Text = "2. "
                lblDepartment2N.Text = "0"
                lblDepartment2P.Text = "0.00 "
            End If

            If CA_Departments.Rows.Count > 3 - 1 Then
                lblDepartment3.Text = "3. " & CA_Departments(3 - 1)("Department Name")
                lblDepartment3N.Text = FormatNumber(CA_Departments(3 - 1)("Number"), 0)
                lblDepartment3P.Text = FormatCurrency(CA_Departments(3 - 1)("Total Amount"), 0)
            Else
                lblDepartment3.Text = "3. "
                lblDepartment3N.Text = "0"
                lblDepartment3P.Text = "0.00 "
            End If

            If CA_Departments.Rows.Count > 4 - 1 Then
                lblDepartment4.Text = "4. " & CA_Departments(4 - 1)("Department Name")
                lblDepartment4N.Text = FormatNumber(CA_Departments(4 - 1)("Number"), 0)
                lblDepartment4P.Text = FormatCurrency(CA_Departments(4 - 1)("Total Amount"), 0)
            Else
                lblDepartment4.Text = "4. "
                lblDepartment4N.Text = "0"
                lblDepartment4P.Text = "0.00 "
            End If

            If CA_Departments.Rows.Count > 5 - 1 Then
                lblDepartment5.Text = "5. " & CA_Departments(5 - 1)("Department Name")
                lblDepartment5N.Text = FormatNumber(CA_Departments(5 - 1)("Number"), 0)
                lblDepartment5P.Text = FormatCurrency(CA_Departments(5 - 1)("Total Amount"), 0)
            Else
                lblDepartment5.Text = "5. "
                lblDepartment5N.Text = "0"
                lblDepartment5P.Text = "0.00 "
            End If
        Else
            lblDepartment1.Text = "1. "
            lblDepartment1N.Text = "0"
            lblDepartment1P.Text = "0.00 "

            lblDepartment2.Text = "2. "
            lblDepartment2N.Text = "0"
            lblDepartment2P.Text = "0.00 "

            lblDepartment3.Text = "3. "
            lblDepartment3N.Text = "0"
            lblDepartment3P.Text = "0.00 "

            lblDepartment4.Text = "4. "
            lblDepartment4N.Text = "0"
            lblDepartment4P.Text = "0.00 "

            lblDepartment5.Text = "5. "
            lblDepartment5N.Text = "0"
            lblDepartment5P.Text = "0.00 "
        End If
    End Sub

    Private Sub PieChart(Chart As ChartControl)
        Dim SQL As String = "SELECT "
        SQL &= "     COALESCE(SUM(CASE WHEN Meals THEN ID END),0) AS 'Meals',"
        SQL &= "     COALESCE(SUM(CASE WHEN Transportation THEN ID END),0) AS 'Transportation',"
        SQL &= "     COALESCE(SUM(CASE WHEN BIR THEN ID END),0) AS 'BIR',"
        SQL &= "     COALESCE(SUM(CASE WHEN RD THEN ID END),0) AS 'RD',"
        SQL &= "     COALESCE(SUM(CASE WHEN LTO THEN ID END),0) AS 'LTO',"
        SQL &= "     COALESCE(SUM(CASE WHEN Notarization THEN ID END),0) AS 'Notarization',"
        SQL &= "     COALESCE(SUM(CASE WHEN Others THEN ID END),0) AS 'Others'"
        SQL &= " FROM cash_advance"
        SQL &= String.Format(" WHERE `status` IN ('ACTIVE', 'CANCELLED');")
        Dim CashAdvanceRequest As DataTable = DataSource(SQL)
        Try
            If CashAdvanceRequest.Rows.Count > 0 Then
                Meals = CashAdvanceRequest(0)("Meals")
                Transportation = CashAdvanceRequest(0)("Transportation")
                BIR = CashAdvanceRequest(0)("BIR")
                RD = CashAdvanceRequest(0)("RD")
                LTO = CashAdvanceRequest(0)("LTO")
                Notarization = CashAdvanceRequest(0)("Notarization")
                Others = CashAdvanceRequest(0)("Others")
            End If
        Catch ex As Exception
            TriggerBugReport("Cash Advance Dashboard - PieChart", ex.Message.ToString)
        End Try

        'Additional column for pie
        Dim CashAdvance As New DataTable
        With CashAdvance
            .Columns.Add("Type")
            .Columns.Add("Value")
            .Rows.Add("Meals", Meals)
            .Rows.Add("Transportation", Transportation)
            .Rows.Add("BIR", BIR)
            .Rows.Add("RD", RD)
            .Rows.Add("LTO", LTO)
            .Rows.Add("Notarization", Notarization)
            .Rows.Add("Others", Others)
        End With

        Chart.Series.Clear()
        Try
            Dim Series1 As New Series("Cash Advance Requested", ViewType.Pie)

            For x As Integer = 0 To CashAdvance.Rows.Count - 1
                Series1.Points.Add(New SeriesPoint(CashAdvance(x)("Type"), CashAdvance(x)("Value")))
            Next

            Chart.Series.Add(Series1)

            CType(Series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default
            With Series1
                .LegendTextPattern = "{A}"
                .Label.Font = New Font(OfficialFont, CSng(OfficialFontSize), .Label.Font.Style)
            End With

            Dim myView As PieSeriesView = CType(Series1.View, PieSeriesView)
        Catch ex As Exception
            TriggerBugReport("Cash Advance Dashboard - PieChart", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LineChart1(Chart As ChartControl)
        Dim SQL As String
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT "
            SQL &= "     1 AS 'ID',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 1 THEN ID END),0) AS 'Jan',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 2 THEN ID END),0) AS 'Feb',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 3 THEN ID END),0) AS 'Mar',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 4 THEN ID END),0) AS 'Apr',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 5 THEN ID END),0) AS 'May',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 6 THEN ID END),0) AS 'Jun',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 7 THEN ID END),0) AS 'Jul',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 8 THEN ID END),0) AS 'Aug',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 9 THEN ID END),0) AS 'Sep',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 10 THEN ID END),0) AS 'Oct',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 11 THEN ID END),0) AS 'Nov',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(Trans_Date) = 12 THEN ID END),0) AS 'Dec'"
            SQL &= " FROM cash_advance"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID NOT IN ({2}) AND YEAR(Trans_Date) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Else
            SQL = "SELECT"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM cash_advance"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID NOT IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        Dim CashAdvanceNumberMonthly As DataTable = DataSource(SQL)

        ' Create a line chart for number of petty cash per month
        With Chart
            .GetSeriesByName("CashAdvanceNumber").Points.Clear()
            Try
                For x As Integer = 1 To CashAdvanceNumberMonthly.Columns.Count - 1
                    .GetSeriesByName("CashAdvanceNumber").Points.Add(New SeriesPoint(CashAdvanceNumberMonthly.Columns(x).Caption, CashAdvanceNumberMonthly(0)(x)))
                Next
            Catch ex As Exception
                TriggerBugReport("Cash Advance Dashboard - LineChart1", ex.Message.ToString)
            End Try
        End With
    End Sub

    Private Sub LineChart2(Chart As ChartControl)
        Dim SQL As String
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT "
            SQL &= "     1 AS 'ID',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 1 THEN ID END),0) AS 'Jan',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 2 THEN ID END),0) AS 'Feb',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 3 THEN ID END),0) AS 'Mar',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 4 THEN ID END),0) AS 'Apr',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 5 THEN ID END),0) AS 'May',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 6 THEN ID END),0) AS 'Jun',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 7 THEN ID END),0) AS 'Jul',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 8 THEN ID END),0) AS 'Aug',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 9 THEN ID END),0) AS 'Sep',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 10 THEN ID END),0) AS 'Oct',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 11 THEN ID END),0) AS 'Nov',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(DocumentDate) = 12 THEN ID END),0) AS 'Dec'"
            SQL &= " FROM check_voucher"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID NOT IN ({2}) AND YEAR(DocumentDate) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Else
            SQL = "SELECT"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    SUM(CASE WHEN DATE(DocumentDate) = DATE('{0}') THEN ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    SUM(CASE WHEN DATE(DocumentDate) = DATE('{0}') THEN ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM check_voucher"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID NOT IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        Dim CheckVoucherAmountMonthly As DataTable = DataSource(SQL)

        ' Create a line chart of amount of petty cash per month
        With Chart
            .GetSeriesByName("CheckVoucherAmount").Points.Clear()
            Try
                For x As Integer = 1 To CheckVoucherAmountMonthly.Columns.Count - 1
                    .GetSeriesByName("CheckVoucherAmount").Points.Add(New SeriesPoint(CheckVoucherAmountMonthly.Columns(x).Caption, CheckVoucherAmountMonthly(0)(x)))
                Next
            Catch ex As Exception
                TriggerBugReport("Cash Advance Dashboard - LineChart2", ex.Message.ToString)
            End Try
        End With
    End Sub

    Private Sub FrmPettyCashDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmCashAdvanceDashboard_Load(sender, e)
        ElseIf e.Control And e.KeyCode = Keys.X Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnChangeView1_Click(sender As Object, e As EventArgs) Handles BtnChangeView1.Click
        Dim Change As New FrmChangeView
        With Change
            If .ShowDialog = DialogResult.OK Then
                Display = .cbxDisplay.Text
                FromDate = .dtpFrom.Value
                ToDate = .dtpTo.Value
                LineChart1(CashAdvanceChart1)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnChangeView2_Click(sender As Object, e As EventArgs) Handles BtnChangeView2.Click
        Dim Change As New FrmChangeView
        With Change
            If .ShowDialog = DialogResult.OK Then
                Display = .cbxDisplay.Text
                FromDate = .dtpFrom.Value
                ToDate = .dtpTo.Value
                LineChart2(CheckVoucherChart2)
            End If
            .Dispose()
        End With
    End Sub
End Class