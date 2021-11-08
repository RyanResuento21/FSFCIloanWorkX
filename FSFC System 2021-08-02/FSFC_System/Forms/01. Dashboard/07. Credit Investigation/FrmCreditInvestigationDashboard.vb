Imports DevExpress.XtraCharts
Public Class FrmCreditInvestigationDashboard

    Dim FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date = Date.Now
    Public ToDate As Date = Date.Now
    Private TotalInvestigation As Integer
    Private TotalInvestigationAmount As Integer
    Private TotalChattel As Integer
    Private TotalRealEstate As Integer
    Private Sub FrmCreditInvestigationDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        With Chart1
            .Location = New Point(13, 489)
            .Size = New Point(1140, 198)
        End With

        With c1
            .Location = New Point(767, 94)
            .Size = New Point(386, 226)
        End With

        FirstLoad = True

        LoadData()
        PieChart(c1)
        LineChart(Chart1)
        If AutoRefreshData Then
            Timer_Refresh.Interval = AutoRefreshTime * 1000
            Timer_Refresh.Start()
        End If

        FirstLoad = False
    End Sub

    Private Sub Timer_Refresh_Tick(sender As Object, e As EventArgs) Handles Timer_Refresh.Tick
        LoadData()
        PieChart(c1)
        LineChart(Chart1)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX37, LabelX34, LabelX33, lblInvestigator1, lblInvestigatorN1, lblInvestigatorP1, lblInvestigator2, lblInvestigatorN2, lblInvestigatorP2, lblInvestigator3, lblInvestigatorN3, lblInvestigatorP3, lblInvestigator4, lblInvestigatorN4, lblInvestigatorP4, lblInvestigator5, lblInvestigatorN5, lblInvestigatorP5, LabelX21, LabelX49, LabelX48, lblInvestigatorA1, lblInvestigatorAA1, lblInvestigatorAP1, lblInvestigatorA2, lblInvestigatorAA2, lblInvestigatorAP2, lblInvestigatorA3, lblInvestigatorAA3, lblInvestigatorAP3, lblInvestigatorA4, lblInvestigatorAA4, lblInvestigatorAP4, lblInvestigatorA5, lblInvestigatorAA5, lblInvestigatorAP5, LabelX30, LabelX29, lblPendingN, lblPendingP, lblApprovedN, lblApprovedP, lblDisapprovedN, lblDisapprovedP, LabelX9, LabelX8, lblFairN, lblFairP, lblGoodN, lblGoodP, lblPoorN, lblPoorP, LabelX15, LabelX35, LabelX16, lblCollateral1, lblCollateral1MV, lblCollateral1LV, lblCollateral2, lblCollateral2MV, lblCollateral2LV, lblCollateral3, lblCollateral3MV, lblCollateral3LV})

            GetLabelFontSettingsDefault({LabelX155, LabelX61, LabelX62, LabelX26, LabelX32, LabelX31, LabelX3, LabelX11, LabelX10})

            GetLabelFontSettingsDashboardPanel({pCM, pREM, pCI})

            GetGroupControlFontSettings({GroupControl2, GroupControl3, gCivilStatus, GroupControl1, GroupControl4})

            GetChartTitleControlFontSettings({c1, Chart1})
        Catch ex As Exception
            TriggerBugReport("Credit Investigation Dashboard - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        TotalInvestigation = DataObject(String.Format("SELECT COUNT(DISTINCT ID) FROM credit_investigation WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        TotalInvestigationAmount = DataObject(String.Format("SELECT IFNULL(SUM(Loanable),0) FROM credit_investigation WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        TotalChattel = DataObject(String.Format("SELECT COUNT(DISTINCT ID) FROM credit_investigation WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND LoanType = 'CHATTEL MORTGAGE' AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        TotalRealEstate = DataObject(String.Format("SELECT COUNT(DISTINCT ID) FROM credit_investigation WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND LoanType = 'REAL ESTATE MORTGAGE' AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID)))

        pCM.Text = FormatNumber(TotalChattel, 0)
        pREM.Text = FormatNumber(TotalRealEstate, 0)
        pCI.Text = FormatNumber(TotalInvestigation, 0)
        Dim SQL As String = String.Format("SELECT IF(PreparedID = 0,'* No Credit Investigator *',Employee(PreparedID)) AS 'CI', COUNT(DISTINCT ID) AS 'Number' FROM credit_investigation WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1}) GROUP BY PreparedID ORDER BY `Number` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT_TopInvestigationCount As DataTable = DataSource(Sql)
        If DT_TopInvestigationCount.Rows.Count > 0 Then
            lblInvestigator1.Text = "1. " & UpperCaseFirst(DT_TopInvestigationCount(0)("CI"))
            lblInvestigatorN1.Text = FormatNumber(DT_TopInvestigationCount(0)("Number"), 0)
            lblInvestigatorP1.Text = FormatNumber((DT_TopInvestigationCount(0)("Number") / TotalInvestigation) * 100, 2) & " %"

            If DT_TopInvestigationCount.Rows.Count > 2 - 1 Then
                lblInvestigator2.Text = "2. " & UpperCaseFirst(DT_TopInvestigationCount(2 - 1)("CI"))
                lblInvestigatorN2.Text = FormatNumber(DT_TopInvestigationCount(2 - 1)("Number"), 0)
                lblInvestigatorP2.Text = FormatNumber((DT_TopInvestigationCount(2 - 1)("Number") / TotalInvestigation) * 100, 2) & " %"
            Else
                lblInvestigator2.Text = "2. "
                lblInvestigatorN2.Text = "0"
                lblInvestigatorP2.Text = "0.00 %"
            End If

            If DT_TopInvestigationCount.Rows.Count > 3 - 1 Then
                lblInvestigator3.Text = "3. " & UpperCaseFirst(DT_TopInvestigationCount(3 - 1)("CI"))
                lblInvestigatorN3.Text = FormatNumber(DT_TopInvestigationCount(3 - 1)("Number"), 0)
                lblInvestigatorP3.Text = FormatNumber((DT_TopInvestigationCount(3 - 1)("Number") / TotalInvestigation) * 100, 2) & " %"
            Else
                lblInvestigator3.Text = "3. "
                lblInvestigatorN3.Text = "0"
                lblInvestigatorP3.Text = "0.00 %"
            End If

            If DT_TopInvestigationCount.Rows.Count > 4 - 1 Then
                lblInvestigator4.Text = "4. " & UpperCaseFirst(DT_TopInvestigationCount(4 - 1)("CI"))
                lblInvestigatorN4.Text = FormatNumber(DT_TopInvestigationCount(4 - 1)("Number"), 0)
                lblInvestigatorP4.Text = FormatNumber((DT_TopInvestigationCount(4 - 1)("Number") / TotalInvestigation) * 100, 2) & " %"
            Else
                lblInvestigator4.Text = "4. "
                lblInvestigatorN4.Text = "0"
                lblInvestigatorP4.Text = "0.00 %"
            End If

            If DT_TopInvestigationCount.Rows.Count > 5 - 1 Then
                lblInvestigator5.Text = "5. " & UpperCaseFirst(DT_TopInvestigationCount(5 - 1)("CI"))
                lblInvestigatorN5.Text = FormatNumber(DT_TopInvestigationCount(5 - 1)("Number"), 0)
                lblInvestigatorP5.Text = FormatNumber((DT_TopInvestigationCount(5 - 1)("Number") / TotalInvestigation) * 100, 2) & " %"
            Else
                lblInvestigator5.Text = "5. "
                lblInvestigatorN5.Text = "0"
                lblInvestigatorP5.Text = "0.00 %"
            End If
        Else
            lblInvestigator1.Text = "1. "
            lblInvestigatorN1.Text = "0"
            lblInvestigatorP1.Text = "0.00 %"

            lblInvestigator2.Text = "2. "
            lblInvestigatorN2.Text = "0"
            lblInvestigatorP2.Text = "0.00 %"

            lblInvestigator3.Text = "3. "
            lblInvestigatorN3.Text = "0"
            lblInvestigatorP3.Text = "0.00 %"

            lblInvestigator4.Text = "4. "
            lblInvestigatorN4.Text = "0"
            lblInvestigatorP4.Text = "0.00 %"

            lblInvestigator5.Text = "5. "
            lblInvestigatorN5.Text = "0"
            lblInvestigatorP5.Text = "0.00 %"
        End If

        Sql = String.Format("SELECT IF(PreparedID = 0,'* No Credit Investigator *',Employee(PreparedID)) AS 'CI', SUM(Loanable) AS 'Amount' FROM credit_investigation WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1}) GROUP BY PreparedID ORDER BY `Amount` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT_TopInvestigationAmount As DataTable = DataSource(Sql)
        If DT_TopInvestigationAmount.Rows.Count > 0 Then
            lblInvestigatorA1.Text = "1. " & UpperCaseFirst(DT_TopInvestigationAmount(0)("CI"))
            lblInvestigatorAA1.Text = FormatNumber(DT_TopInvestigationAmount(0)("Amount"), 2)
            lblInvestigatorAP1.Text = FormatNumber((DT_TopInvestigationAmount(0)("Amount") / TotalInvestigationAmount) * 100, 2) & " %"

            If DT_TopInvestigationAmount.Rows.Count > 2 - 1 Then
                lblInvestigatorA2.Text = "2. " & UpperCaseFirst(DT_TopInvestigationAmount(2 - 1)("CI"))
                lblInvestigatorAA2.Text = FormatNumber(DT_TopInvestigationAmount(2 - 1)("Amount"), 2)
                lblInvestigatorAP2.Text = FormatNumber((DT_TopInvestigationAmount(2 - 1)("Amount") / TotalInvestigationAmount) * 100, 2) & " %"
            Else
                lblInvestigatorA2.Text = "2. "
                lblInvestigatorAA2.Text = "0.00"
                lblInvestigatorAP2.Text = "0.00 %"
            End If

            If DT_TopInvestigationAmount.Rows.Count > 3 - 1 Then
                lblInvestigatorA3.Text = "3. " & UpperCaseFirst(DT_TopInvestigationAmount(3 - 1)("CI"))
                lblInvestigatorAA3.Text = FormatNumber(DT_TopInvestigationAmount(3 - 1)("Amount"), 2)
                lblInvestigatorAP3.Text = FormatNumber((DT_TopInvestigationAmount(3 - 1)("Amount") / TotalInvestigationAmount) * 100, 2) & " %"
            Else
                lblInvestigatorA3.Text = "3. "
                lblInvestigatorAA3.Text = "0.00"
                lblInvestigatorAP3.Text = "0.00 %"
            End If

            If DT_TopInvestigationAmount.Rows.Count > 4 - 1 Then
                lblInvestigatorA4.Text = "4. " & UpperCaseFirst(DT_TopInvestigationAmount(4 - 1)("CI"))
                lblInvestigatorAA4.Text = FormatNumber(DT_TopInvestigationAmount(4 - 1)("Amount"), 2)
                lblInvestigatorAP4.Text = FormatNumber((DT_TopInvestigationAmount(4 - 1)("Amount") / TotalInvestigationAmount) * 100, 2) & " %"
            Else
                lblInvestigatorA4.Text = "4. "
                lblInvestigatorAA4.Text = "0.00"
                lblInvestigatorAP4.Text = "0.00 %"
            End If

            If DT_TopInvestigationAmount.Rows.Count > 5 - 1 Then
                lblInvestigatorA5.Text = "5. " & UpperCaseFirst(DT_TopInvestigationAmount(5 - 1)("CI"))
                lblInvestigatorAA5.Text = FormatNumber(DT_TopInvestigationAmount(5 - 1)("Amount"), 2)
                lblInvestigatorAP5.Text = FormatNumber((DT_TopInvestigationAmount(5 - 1)("Amount") / TotalInvestigationAmount) * 100, 2) & " %"
            Else
                lblInvestigatorA5.Text = "5. "
                lblInvestigatorAA5.Text = "0.00"
                lblInvestigatorAP5.Text = "0.00 %"
            End If
        Else
            lblInvestigatorA1.Text = "1. "
            lblInvestigatorAA1.Text = "0.00"
            lblInvestigatorAP1.Text = "0.00 %"

            lblInvestigatorA2.Text = "2. "
            lblInvestigatorAA2.Text = "0.00"
            lblInvestigatorAP2.Text = "0.00 %"

            lblInvestigatorA3.Text = "3. "
            lblInvestigatorAA3.Text = "0.00"
            lblInvestigatorAP3.Text = "0.00 %"

            lblInvestigatorA4.Text = "4. "
            lblInvestigatorAA4.Text = "0.00"
            lblInvestigatorAP4.Text = "0.00 %"

            lblInvestigatorA5.Text = "5. "
            lblInvestigatorAA5.Text = "0.00"
            lblInvestigatorAP5.Text = "0.00 %"
        End If

        Sql = String.Format("SELECT Collateral, TotalAppraised, Loanable FROM credit_investigation WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1}) ORDER BY TotalAppraised DESC LIMIT 3;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT_TopMarketValue As DataTable = DataSource(Sql)
        If DT_TopMarketValue.Rows.Count > 0 Then
            lblCollateral1.Text = "1. " & UpperCaseFirst(DT_TopMarketValue(0)("Collateral"))
            lblCollateral1MV.Text = FormatNumber(DT_TopMarketValue(0)("TotalAppraised"), 2)
            lblCollateral1LV.Text = FormatNumber(DT_TopMarketValue(0)("Loanable"), 2)

            If DT_TopMarketValue.Rows.Count > 2 - 1 Then
                lblCollateral2.Text = "2. " & UpperCaseFirst(DT_TopMarketValue(2 - 1)("Collateral"))
                lblCollateral2MV.Text = FormatNumber(DT_TopMarketValue(2 - 1)("TotalAppraised"), 2)
                lblCollateral2LV.Text = FormatNumber(DT_TopMarketValue(2 - 1)("Loanable"), 2)
            Else
                lblCollateral2.Text = "2. "
                lblCollateral2MV.Text = "0.00"
                lblCollateral2LV.Text = "0.00 %"
            End If

            If DT_TopMarketValue.Rows.Count > 3 - 1 Then
                lblCollateral3.Text = "3. " & UpperCaseFirst(DT_TopMarketValue(3 - 1)("Collateral"))
                lblCollateral3MV.Text = FormatNumber(DT_TopMarketValue(3 - 1)("TotalAppraised"), 2)
                lblCollateral3LV.Text = FormatNumber(DT_TopMarketValue(3 - 1)("Loanable"), 2)
            Else
                lblCollateral3.Text = "3. "
                lblCollateral3MV.Text = "0.00"
                lblCollateral3LV.Text = "0.00"
            End If
        Else
            lblCollateral1.Text = "1. "
            lblCollateral1MV.Text = "0.00"
            lblCollateral1LV.Text = "0.00"

            lblCollateral2.Text = "2. "
            lblCollateral2MV.Text = "0.00"
            lblCollateral2LV.Text = "0.00"

            lblCollateral3.Text = "3. "
            lblCollateral3MV.Text = "0.00"
            lblCollateral3LV.Text = "0.00"
        End If

        Sql = "SELECT "
        Sql &= "    FORMAT(COUNT(CASE WHEN CreditRating = 'FAIR' THEN ID END),0) AS 'Fair',"
        Sql &= "    FORMAT(COUNT(CASE WHEN CreditRating = 'GOOD' THEN ID END),0) AS 'Good',"
        Sql &= "    FORMAT(COUNT(CASE WHEN CreditRating = 'POOR' THEN ID END),0) AS 'Poor',"
        Sql &= "    FORMAT(COUNT(CASE WHEN ci_status IN ('PENDING','CHECKED') THEN ID END),0) AS 'Pending',"
        Sql &= "    FORMAT(COUNT(CASE WHEN ci_status = 'APPROVED' THEN ID END),0) AS 'Approved',"
        Sql &= "    FORMAT(COUNT(CASE WHEN ci_status IN ('DISAPPROVED','CANCELLED') THEN ID END),0) AS 'Disapproved'"
        Sql &= String.Format(" FROM credit_investigation WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT_Details As DataTable = DataSource(Sql)
        If DT_Details.Rows.Count > 0 Then
            lblPendingN.Text = FormatNumber(DT_Details(0)("Fair"), 0)
            lblPendingP.Text = FormatNumber((DT_Details(0)("Fair") / TotalInvestigation) * 100, 2) & " %"

            lblApprovedN.Text = FormatNumber(DT_Details(0)("Good"), 0)
            lblApprovedP.Text = FormatNumber((DT_Details(0)("Good") / TotalInvestigation) * 100, 2) & " %"

            lblDisapprovedN.Text = FormatNumber(DT_Details(0)("Poor"), 0)
            lblDisapprovedP.Text = FormatNumber((DT_Details(0)("Poor") / TotalInvestigation) * 100, 2) & " %"

            lblFairN.Text = FormatNumber(DT_Details(0)("Pending"), 0)
            lblFairP.Text = FormatNumber((DT_Details(0)("Pending") / TotalInvestigation) * 100, 2) & " %"

            lblGoodN.Text = FormatNumber(DT_Details(0)("Approved"), 0)
            lblGoodP.Text = FormatNumber((DT_Details(0)("Approved") / TotalInvestigation) * 100, 2) & " %"

            lblPoorN.Text = FormatNumber(DT_Details(0)("Disapproved"), 0)
            lblPoorP.Text = FormatNumber((DT_Details(0)("Disapproved") / TotalInvestigation) * 100, 2) & " %"
        Else
            lblPendingN.Text = "0"
            lblPendingP.Text = "0.00 %"

            lblApprovedN.Text = "0"
            lblApprovedP.Text = "0.00 %"

            lblDisapprovedN.Text = "0"
            lblDisapprovedP.Text = "0.00 %"

            lblFairN.Text = "0"
            lblFairP.Text = "0.00 %"

            lblGoodN.Text = "0"
            lblGoodP.Text = "0.00 %"

            lblPoorN.Text = "0"
            lblPoorP.Text = "0.00 %"
        End If
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Dim SQL As String
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT * FROM ( SELECT 1 AS 'Type',"
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
            SQL &= " FROM credit_investigation"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND ci_status IN ('PENDING','CHECKED') AND Branch_ID IN ({2}) AND YEAR(Trans_Date) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= " UNION"
            SQL &= " SELECT 2 AS 'Type',"
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
            SQL &= " FROM credit_investigation"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND ci_status = 'APPROVED' AND Branch_ID IN ({2}) AND YEAR(Trans_Date) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= " UNION"
            SQL &= " SELECT 3 AS 'Type',"
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
            SQL &= " FROM credit_investigation"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND ci_status IN ('DISAPPROVED','CANCELLED') AND Branch_ID IN ({2}) AND YEAR(Trans_Date) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= " ) A GROUP BY A.`Type` ORDER BY A.`Type`"
        Else
            SQL = "SELECT"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM credit_investigation"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND ci_status IN ('PENDING','CHECKED') AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= " UNION"

            SQL &= " SELECT"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM credit_investigation"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND ci_status = 'APPROVED' AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= " UNION"

            SQL &= " SELECT"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM credit_investigation"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND ci_status IN ('DISAPPROVED','CANCELLED') AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        Dim MonthlyInvestigation As DataTable = DataSource(SQL)

        ' Create a line chart
        With Chart
            .GetSeriesByName("Pending").Points.Clear()
            .GetSeriesByName("Approved").Points.Clear()
            .GetSeriesByName("Disapproved").Points.Clear()
            Try
                For x As Integer = 1 To MonthlyInvestigation.Columns.Count - 1
                    .GetSeriesByName("Pending").Points.Add(New SeriesPoint(MonthlyInvestigation.Columns(x).Caption, MonthlyInvestigation(0)(x)))
                    .GetSeriesByName("Approved").Points.Add(New SeriesPoint(MonthlyInvestigation.Columns(x).Caption, MonthlyInvestigation(1)(x)))
                    .GetSeriesByName("Disapproved").Points.Add(New SeriesPoint(MonthlyInvestigation.Columns(x).Caption, MonthlyInvestigation(2)(x)))
                Next
            Catch ex As Exception
                TriggerBugReport("Credit Investigation Dashboard - LineChart", ex.Message.ToString)
            End Try
        End With
    End Sub

    Private Sub FrmCreditDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmCreditInvestigationDashboard_Load(sender, e)
        ElseIf e.Control And e.KeyCode = Keys.X Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub PieChart(Chart As ChartControl)
        Dim Collateral As New DataTable
        'Additional column for pie
        With Collateral
            .Columns.Add("Mortgage")
            .Columns.Add("Value")
            .Rows.Add("Chattel Mortgage", TotalChattel)
            .Rows.Add("Real Estate Mortgage", TotalRealEstate)
        End With

        Chart.Series.Clear()
        Try
            Dim Series1 As New Series("VL vs RE", ViewType.Pie)

            For x As Integer = 0 To Collateral.Rows.Count - 1
                Series1.Points.Add(New SeriesPoint(Collateral(x)("Mortgage"), Collateral(x)("Value")))
            Next

            Chart.Series.Add(Series1)

            CType(Series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default
            With Series1
                .LegendTextPattern = "{A}"
                .Label.Font = New Font(OfficialFont, CSng(OfficialFontSize), .Label.Font.Style)
            End With

            Dim myView As PieSeriesView = CType(Series1.View, PieSeriesView)
        Catch ex As Exception
            TriggerBugReport("Credit Investigation Dashboard - PieChart", ex.Message.ToString)
        End Try
    End Sub
End Class