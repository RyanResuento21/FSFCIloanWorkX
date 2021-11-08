Imports DevExpress.XtraCharts
Public Class FrmBorrowerDashboard

    Dim iSingleN As Integer
    Dim iMarriedN As Integer
    Dim iSeparatedN As Integer
    Dim iWidowedN As Integer

    Dim i0DependentN As Integer
    Dim i1DependentN As Integer
    Dim i2DependentN As Integer
    Dim i3DependentN As Integer
    Dim i4DependentN As Integer

    Dim iMaleN As Integer
    Dim iFemaleN As Integer

    Dim iFilipinoN As Integer
    Dim iForeignerN As Integer

    Dim i20BelowN As Integer
    Dim i21_30N As Integer
    Dim i31_40N As Integer
    Dim i41_50N As Integer
    Dim i51AboveN As Integer

    Dim iOwnedN As Integer
    Dim iFreeN As Integer
    Dim iRentedN As Integer

    Dim iMicro As Integer
    Dim iSmall As Integer
    Dim iMedium As Integer
    Dim iLarge As Integer

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date = Date.Now
    Public ToDate As Date = Date.Now

    Private Sub FrmBorrowerDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        With c1
            .Size = New Point(303, 260)
            .Location = New Point(849, 94)
        End With
        With c2
            .Size = New Point(582, 325)
            .Location = New Point(570, 359)
        End With

        FirstLoad = True
        With FrmMain
            pIndividual.Text = FormatNumber(.IndividualCount, 0)
            pCorporate.Text = FormatNumber(.CorporateCount, 0)
            pTotal.Text = FormatNumber(.IndividualCount + .CorporateCount, 0)
        End With

        LoadIndividual()
        FirstLoad = False
        LoadCorporate()
        If AutoRefreshData Then
            Timer_Refresh.Interval = AutoRefreshTime * 1000
            Timer_Refresh.Start()
        End If
    End Sub

    Private Sub Timer_Refresh_Tick(sender As Object, e As EventArgs) Handles Timer_Refresh.Tick

    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX14, LabelX99, LabelX98, LabelX13, LabelX16, lblSingleN, lblSingleP, LabelX15, lblMarriedN, lblMarriedP, LabelX19, lblSeparatedN, lblSeparatedP, LabelX22, lblWidowedN, lblWidowedP, LabelX101, lblMicroN, lblMicroP, LabelX100, lblSmallN, lblSmallP, LabelX93, lblMediumN, lblMediumP, LabelX90, lblLargeN, lblLargeP, LabelX2, LabelX3, LabelX4, lblMaleN, lblMaleP, LabelX1, lblFemaleN, lblFemaleP, LabelX45, LabelX44, LabelX47, lblFilipinoN, lblFilipinoP, LabelX46, lblForeignerN, lblForeignerP, LabelX34, LabelX33, LabelX36, lbl20BelowN, lbl20BelowP, LabelX35, lbl21_30N, lbl21_30P, LabelX28, lbl31_40N, lbl31_40P, LabelX25, lbl41_50N, lbl41_50P, LabelX37, lbl51AboveN, lbl51AboveP, LabelX62, LabelX61, LabelX64, lbl0DependentN, lbl0DependentP, LabelX63, lbl1DependentN, lbl1DependentP, LabelX56, lbl2DependentN, lbl2DependentP, LabelX53, lbl3DependentN, lbl3DependentP, LabelX50, lbl4DependentN, lbl4DependentP, LabelX76, LabelX75, LabelX78, lblOwnedN, lblOwnedP, LabelX77, lblFreeN, lblFreeP, LabelX70, lblRentedN, lblRentedP})

            GetLabelFontSettingsDashboardTitle({LabelX155, LabelX87, LabelX102})

            GetButtonFontSettings({btnChangeView})

            GetLabelFontSettingsDashboardPanel({pIndividual, pCorporate, pTotal})

            GetGroupControlFontSettings({gCivilStatus, gFirmSize, gGender, gCitizenship, gDependents, gAge, gHouseOwnership})

            GetChartTitleControlFontSettings({c1, c2})
        Catch ex As Exception
            TriggerBugReport("Borrower Dashboard - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Public Sub LoadIndividual()
        With FrmMain
            pTotal.Text = FormatNumber(.IndividualCount + .CorporateCount, 0)
        End With
        Dim SQL As String = "SELECT "
        SQL &= "    FORMAT(COUNT(CASE WHEN Civil_B = 'Single' THEN B.ID END),0) AS 'Single',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Civil_B = 'Married' THEN B.ID END),0) AS 'Married',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Civil_B = 'Separated' THEN B.ID END),0) AS 'Separated',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Civil_B = 'Widowed' THEN B.ID END),0) AS 'Widowed',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Gender_B = 'Male' THEN B.ID END),0) AS 'Male',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Gender_B = 'Female' THEN B.ID END),0) AS 'Female',"
        SQL &= "    FORMAT(COUNT(CASE WHEN House_B = 'Owned' THEN B.ID END),0) AS 'Owned',"
        SQL &= "    FORMAT(COUNT(CASE WHEN House_B = 'Free' THEN B.ID END),0) AS 'Free',"
        SQL &= "    FORMAT(COUNT(CASE WHEN House_B = 'Rented' THEN B.ID END),0) AS 'Rented',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Citizenship_B = 'Filipino' THEN B.ID END),0) AS 'Filipino',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Citizenship_B != 'Filipino' AND Citizenship_B != '' THEN B.ID END),0) AS 'Foreigner',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Birth_B != '0001-01-01' AND IF(Birth_B = '',NULL,Age(Birth_B)) < 21 THEN ID END),0) AS '20BelowN',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Birth_B != '0001-01-01' AND IF(Birth_B = '',NULL,Age(Birth_B)) BETWEEN 21 AND 30 THEN B.ID END),0) AS '21_30N',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Birth_B != '0001-01-01' AND IF(Birth_B = '',NULL,Age(Birth_B)) BETWEEN 31 AND 40 THEN B.ID END),0) AS '31_40N',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Birth_B != '0001-01-01' AND IF(Birth_B = '',NULL,Age(Birth_B)) BETWEEN 41 AND 50 THEN B.ID END),0) AS '41_50N',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Birth_B != '0001-01-01' AND IF(Birth_B = '',NULL,Age(Birth_B)) > 50 THEN B.ID END),0) AS '51AboveN',"
        SQL &= "    FORMAT(COUNT(CASE WHEN D.Dependents IS NULL THEN B.ID END),0) AS '0DependentN',"
        SQL &= "    FORMAT(COUNT(CASE WHEN D.Dependents = 1 THEN B.ID END),0) AS '1DependentN',"
        SQL &= "    FORMAT(COUNT(CASE WHEN D.Dependents = 2 THEN B.ID END),0) AS '2DependentN',"
        SQL &= "    FORMAT(COUNT(CASE WHEN D.Dependents = 3 THEN B.ID END),0) AS '3DependentN',"
        SQL &= "    FORMAT(COUNT(CASE WHEN D.Dependents = 4 THEN B.ID END),0) AS '4DependentN'"
        SQL &= " FROM profile_borrower B"
        SQL &= String.Format(" LEFT JOIN (SELECT BorrowerID, COUNT(ID) AS 'Dependents' FROM profile_dependent WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) GROUP BY BorrowerID) D", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        SQL &= " ON B.BorrowerID = D.BorrowerID"
        SQL &= " WHERE B.`status` = 'ACTIVE'"
        SQL &= String.Format("    AND Branch_ID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim IndiDetails As DataTable = DataSource(SQL)

        Try
            If IndiDetails.Rows.Count > 0 Then
                '*****Civil Status
                iSingleN = IndiDetails(0)("Single")
                iMarriedN = IndiDetails(0)("Married")
                iSeparatedN = IndiDetails(0)("Separated")
                iWidowedN = IndiDetails(0)("Widowed")

                lblSingleN.Text = FormatNumber(iSingleN, 0)
                lblMarriedN.Text = FormatNumber(iMarriedN, 0)
                lblSeparatedN.Text = FormatNumber(iSeparatedN, 0)
                lblWidowedN.Text = FormatNumber(iWidowedN, 0)

                With FrmMain
                    lblSingleP.Text = FormatNumber((iSingleN / .IndividualCount) * 100, 2) & " %"
                    lblMarriedP.Text = FormatNumber((iMarriedN / .IndividualCount) * 100, 2) & " %"
                    lblSeparatedP.Text = FormatNumber((iSeparatedN / .IndividualCount) * 100, 2) & " %"
                    lblWidowedP.Text = FormatNumber((iWidowedN / .IndividualCount) * 100, 2) & " %"
                End With

                '*****Dependents
                i0DependentN = IndiDetails(0)("0DependentN")
                i1DependentN = IndiDetails(0)("1DependentN")
                i2DependentN = IndiDetails(0)("2DependentN")
                i3DependentN = IndiDetails(0)("3DependentN")
                i4DependentN = IndiDetails(0)("4DependentN")

                lbl0DependentN.Text = FormatNumber(i0DependentN, 0)
                lbl1DependentN.Text = FormatNumber(i1DependentN, 0)
                lbl2DependentN.Text = FormatNumber(i2DependentN, 0)
                lbl3DependentN.Text = FormatNumber(i3DependentN, 0)
                lbl4DependentN.Text = FormatNumber(i4DependentN, 0)

                With FrmMain
                    lbl0DependentP.Text = FormatNumber((i0DependentN / .IndividualCount) * 100, 2) & " %"
                    lbl1DependentP.Text = FormatNumber((i1DependentN / .IndividualCount) * 100, 2) & " %"
                    lbl2DependentP.Text = FormatNumber((i2DependentN / .IndividualCount) * 100, 2) & " %"
                    lbl3DependentP.Text = FormatNumber((i3DependentN / .IndividualCount) * 100, 2) & " %"
                    lbl4DependentP.Text = FormatNumber((i4DependentN / .IndividualCount) * 100, 2) & " %"
                End With

                '*****Gender
                iMaleN = IndiDetails(0)("Male")
                iFemaleN = IndiDetails(0)("Female")

                lblMaleN.Text = FormatNumber(iMaleN, 0)
                lblFemaleN.Text = FormatNumber(iFemaleN, 0)

                With FrmMain
                    lblMaleP.Text = FormatNumber((iMaleN / .IndividualCount) * 100, 2) & " %"
                    lblFemaleP.Text = FormatNumber((iFemaleN / .IndividualCount) * 100, 2) & " %"
                End With

                '*****Citizenship
                iFilipinoN = IndiDetails(0)("Filipino")
                iForeignerN = IndiDetails(0)("Foreigner")

                lblFilipinoN.Text = FormatNumber(iFilipinoN, 0)
                lblForeignerN.Text = FormatNumber(iForeignerN, 0)

                With FrmMain
                    lblFilipinoP.Text = FormatNumber((iFilipinoN / .IndividualCount) * 100, 2) & " %"
                    lblForeignerP.Text = FormatNumber((iForeignerN / .IndividualCount) * 100, 2) & " %"
                End With

                '*****Age
                i20BelowN = IndiDetails(0)("20BelowN")
                i21_30N = IndiDetails(0)("21_30N")
                i31_40N = IndiDetails(0)("31_40N")
                i41_50N = IndiDetails(0)("41_50N")
                i51AboveN = IndiDetails(0)("51AboveN")

                lbl20BelowN.Text = FormatNumber(i20BelowN, 0)
                lbl21_30N.Text = FormatNumber(i21_30N, 0)
                lbl31_40N.Text = FormatNumber(i31_40N, 0)
                lbl41_50N.Text = FormatNumber(i41_50N, 0)
                lbl51AboveN.Text = FormatNumber(i51AboveN, 0)

                With FrmMain
                    lbl20BelowP.Text = FormatNumber((i20BelowN / .IndividualCount) * 100, 2) & " %"
                    lbl21_30P.Text = FormatNumber((i21_30N / .IndividualCount) * 100, 2) & " %"
                    lbl31_40P.Text = FormatNumber((i31_40N / .IndividualCount) * 100, 2) & " %"
                    lbl41_50P.Text = FormatNumber((i41_50N / .IndividualCount) * 100, 2) & " %"
                    lbl51AboveP.Text = FormatNumber((i51AboveN / .IndividualCount) * 100, 2) & " %"
                End With

                '*****House Ownership
                iOwnedN = IndiDetails(0)("Owned")
                iFreeN = IndiDetails(0)("Free")
                iRentedN = IndiDetails(0)("Rented")

                lblOwnedN.Text = FormatNumber(iOwnedN, 0)
                lblFreeN.Text = FormatNumber(iFreeN, 0)
                lblRentedN.Text = FormatNumber(iRentedN, 0)

                With FrmMain
                    lblOwnedP.Text = FormatNumber((iOwnedN / .IndividualCount) * 100, 2) & " %"
                    lblFreeP.Text = FormatNumber((iFreeN / .IndividualCount) * 100, 2) & " %"
                    lblRentedP.Text = FormatNumber((iRentedN / .IndividualCount) * 100, 2) & " %"
                End With

                SQL = String.Format("SELECT (SELECT Industry FROM tbl_industry WHERE ID = Industry_ID) AS 'Industry', COUNT(DISTINCT ID) AS 'Number', '' AS 'Percent' FROM profile_borrower_industry WHERE `status` = 'ACTIVE' AND SUBSTRING(BorrowerID,1,3) * 1 IN ({0}) GROUP BY Industry_ID ORDER BY `Number` DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
                GridControl1.DataSource = DataSource(SQL)
                Dim MaxC As Integer = 0
                For x As Integer = 0 To GridView1.RowCount - 1
                    MaxC += GridView1.GetRowCellValue(x, "Number")
                Next
                For x As Integer = 0 To GridView1.RowCount - 1
                    GridView1.SetRowCellValue(x, "Percent", FormatNumber((GridView1.GetRowCellValue(x, "Number") / MaxC) * 100, 0) & " %")
                Next

                If FirstLoad Then
                    Exit Sub
                End If
                PieChart(c1)
                LineChart(c2)
            End If
        Catch ex As Exception
            TriggerBugReport("Borrower Dashboard - Load Individual", ex.Message.ToString)
        End Try
    End Sub

    Public Sub LoadCorporate()
        With FrmMain
            pTotal.Text = FormatNumber(.IndividualCount + .CorporateCount, 0)
        End With
        Dim SQL As String = "SELECT "
        SQL &= "    FORMAT(COUNT(CASE WHEN FirmSize = 'Micro' THEN ID END),0) AS 'Micro',"
        SQL &= "    FORMAT(COUNT(CASE WHEN FirmSize = 'Small' THEN ID END),0) AS 'Small',"
        SQL &= "    FORMAT(COUNT(CASE WHEN FirmSize = 'Medium' THEN ID END),0) AS 'Medium',"
        SQL &= "    FORMAT(COUNT(CASE WHEN FirmSize = 'Large' THEN ID END),0) AS 'Large'"
        SQL &= " FROM profile_corporation"
        SQL &= " WHERE `status` = 'ACTIVE'"
        SQL &= String.Format(" AND Branch_ID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim CorpDetails As DataTable = DataSource(SQL)

        Try
            If CorpDetails.Rows.Count > 0 Then
                iMicro = CorpDetails(0)("Micro")
                iSmall = CorpDetails(0)("Small")
                iMedium = CorpDetails(0)("Medium")
                iLarge = CorpDetails(0)("Large")

                lblMicroN.Text = FormatNumber(iMicro, 0)
                lblSmallN.Text = FormatNumber(iSmall, 0)
                lblMediumN.Text = FormatNumber(iMedium, 0)
                lblLargeN.Text = FormatNumber(iLarge, 0)

                With FrmMain
                    lblMicroP.Text = FormatNumber((iMicro / .CorporateCount) * 100, 2) & " %"
                    lblSmallP.Text = FormatNumber((iSmall / .CorporateCount) * 100, 2) & " %"
                    lblMediumP.Text = FormatNumber((iMedium / .CorporateCount) * 100, 2) & " %"
                    lblLargeP.Text = FormatNumber((iLarge / .CorporateCount) * 100, 2) & " %"
                End With

                If FirstLoad Then
                    Exit Sub
                End If
                PieChart(c1)
                LineChart(c2)
            End If
        Catch ex As Exception
            TriggerBugReport("Borrower Dashboard - Load Corporate", ex.Message.ToString)
        End Try
    End Sub

    Private Sub PieChart(Chart As ChartControl)
        Dim Product As New DataTable
        With Product
            .Columns.Add("Individual")
            .Columns.Add("Corporate")
            .Rows.Add("Individual", FrmMain.IndividualCount)
            .Rows.Add("Corporate", FrmMain.CorporateCount)
        End With
        ' Create a pie chart
        Chart.Series.Clear()
        Try
            Dim Series1 As New Series("Individual vs Corporate", ViewType.Pie)

            For x As Integer = 0 To Product.Rows.Count - 1
                Series1.Points.Add(New SeriesPoint(Product(x)("Individual"), Product(x)("Corporate")))
            Next

            ' Add the series to the chart.
            Chart.Series.Add(Series1)

            CType(Series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

            Dim myView As PieSeriesView = CType(Series1.View, PieSeriesView)
        Catch ex As Exception
            TriggerBugReport("Borrower Dashboard - PieChart", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Dim SQL As String
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT "
            SQL &= "     1 AS 'ID',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 1 THEN B.ID END),0) AS 'Jan',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 2 THEN B.ID END),0) AS 'Feb',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 3 THEN B.ID END),0) AS 'Mar',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 4 THEN B.ID END),0) AS 'Apr',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 5 THEN B.ID END),0) AS 'May',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 6 THEN B.ID END),0) AS 'Jun',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 7 THEN B.ID END),0) AS 'Jul',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 8 THEN B.ID END),0) AS 'Aug',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 9 THEN B.ID END),0) AS 'Sep',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 10 THEN B.ID END),0) AS 'Oct',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 11 THEN B.ID END),0) AS 'Nov',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(B.`timestamp`) = 12 THEN B.ID END),0) AS 'Dec'"
            SQL &= " FROM profile_borrower B"
            SQL &= String.Format(" WHERE B.`status` = 'ACTIVE' AND FIND_IN_SET(B.Branch_ID,'{0}') AND YEAR(B.`timestamp`) = YEAR('{1}')", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(FromDate, "yyyy-MM-dd"))
            SQL &= " UNION"
            SQL &= " SELECT "
            SQL &= "     2 AS 'ID',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 1 THEN C.ID END),0) AS 'Jan',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 2 THEN C.ID END),0) AS 'Feb',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 3 THEN C.ID END),0) AS 'Mar',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 4 THEN C.ID END),0) AS 'Apr',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 5 THEN C.ID END),0) AS 'May',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 6 THEN C.ID END),0) AS 'Jun',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 7 THEN C.ID END),0) AS 'Jul',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 8 THEN C.ID END),0) AS 'Aug',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 9 THEN C.ID END),0) AS 'Sep',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 10 THEN C.ID END),0) AS 'Oct',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 11 THEN C.ID END),0) AS 'Nov',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(C.`timestamp`) = 12 THEN C.ID END),0) AS 'Dec'"
            SQL &= " FROM profile_corporation C"
            SQL &= String.Format(" WHERE C.`status` = 'ACTIVE' AND FIND_IN_SET(C.Branch_ID,'{2}') AND YEAR(C.`timestamp`) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= " UNION"
            SQL &= " SELECT "
            SQL &= "     3 AS 'ID',"
            SQL &= "     FORMAT(SUM(`Jan`),0) AS 'Jan',"
            SQL &= "     FORMAT(SUM(`Feb`),0) AS 'Feb',"
            SQL &= "     FORMAT(SUM(`Mar`),0) AS 'Mar',"
            SQL &= "     FORMAT(SUM(`Apr`),0) AS 'Apr',"
            SQL &= "     FORMAT(SUM(`May`),0) AS 'May',"
            SQL &= "     FORMAT(SUM(`Jun`),0) AS 'Jun',"
            SQL &= "     FORMAT(SUM(`Jul`),0) AS 'Jul',"
            SQL &= "     FORMAT(SUM(`Aug`),0) AS 'Aug',"
            SQL &= "     FORMAT(SUM(`Sep`),0) AS 'Sep',"
            SQL &= "     FORMAT(SUM(`Oct`),0) AS 'Oct',"
            SQL &= "     FORMAT(SUM(`Nov`),0) AS 'Nov',"
            SQL &= "     FORMAT(SUM(`Dec`),0) AS 'Dec'	"
            SQL &= "     FROM ("
            SQL &= "         SELECT "
            SQL &= "             4 AS 'ID',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 1 THEN B.ID END) AS 'Jan',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 2 THEN B.ID END) AS 'Feb',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 3 THEN B.ID END) AS 'Mar',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 4 THEN B.ID END) AS 'Apr',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 5 THEN B.ID END) AS 'May',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 6 THEN B.ID END) AS 'Jun',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 7 THEN B.ID END) AS 'Jul',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 8 THEN B.ID END) AS 'Aug',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 9 THEN B.ID END) AS 'Sep',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 10 THEN B.ID END) AS 'Oct',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 11 THEN B.ID END) AS 'Nov',"
            SQL &= "             COUNT(CASE WHEN MONTH(B.`timestamp`) = 12 THEN B.ID END) AS 'Dec'"
            SQL &= "         FROM profile_borrower B"
            SQL &= String.Format("         WHERE B.`status` = 'ACTIVE' AND FIND_IN_SET(B.Branch_ID,'{2}') AND YEAR(B.`timestamp`) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= "         UNION"
            SQL &= "         SELECT "
            SQL &= "             5 AS 'ID',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 1 THEN C.ID END) AS 'Jan',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 2 THEN C.ID END) AS 'Feb',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 3 THEN C.ID END) AS 'Mar',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 4 THEN C.ID END) AS 'Apr',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 5 THEN C.ID END) AS 'May',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 6 THEN C.ID END) AS 'Jun',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 7 THEN C.ID END) AS 'Jul',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 8 THEN C.ID END) AS 'Aug',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 9 THEN C.ID END) AS 'Sep',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 10 THEN C.ID END) AS 'Oct',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 11 THEN C.ID END) AS 'Nov',"
            SQL &= "             COUNT(CASE WHEN MONTH(C.`timestamp`) = 12 THEN C.ID END) AS 'Dec'"
            SQL &= "         FROM profile_corporation C"
            SQL &= String.Format("         WHERE C.`status` = 'ACTIVE' AND FIND_IN_SET(C.Branch_ID,'{2}') AND YEAR(C.`timestamp`) = YEAR('{1}')) T;", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Else
            SQL = "SELECT"
            SQL &= "    1 AS 'ID',"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(B.`timestamp`) = DATE('{0}') THEN B.ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(B.`timestamp`) = DATE('{0}') THEN B.ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM profile_borrower B "
            SQL &= String.Format(" WHERE B.`status` = 'ACTIVE' AND FIND_IN_SET(B.Branch_ID,'{0}') ", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= " UNION"

            SQL &= " SELECT"
            SQL &= "    2 AS 'ID',"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(C.`timestamp`) = DATE('{0}') THEN C.ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(C.`timestamp`) = DATE('{0}') THEN C.ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM profile_corporation C "
            SQL &= String.Format(" WHERE C.`status` = 'ACTIVE' AND FIND_IN_SET(C.Branch_ID,'{0}') ", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= " UNION"

            SQL &= " SELECT"
            SQL &= "    3 AS 'ID',"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    SUM(`{0}`) AS '{0}'", Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    SUM(`{0}`) AS '{0}',", Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= "    FROM ("
            SQL &= "    SELECT"
            SQL &= "        4 AS 'ID',"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("      COUNT(CASE WHEN DATE(B.`timestamp`) = DATE('{0}') THEN B.ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("      COUNT(CASE WHEN DATE(B.`timestamp`) = DATE('{0}') THEN B.ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= "    FROM profile_borrower B"
            SQL &= String.Format("    WHERE B.`status` = 'ACTIVE' AND FIND_IN_SET(B.Branch_ID,'{0}')", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= "    UNION"

            SQL &= "    SELECT"
            SQL &= "        5 AS 'ID',"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("      COUNT(CASE WHEN DATE(C.`timestamp`) = DATE('{0}') THEN C.ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("      COUNT(CASE WHEN DATE(C.`timestamp`) = DATE('{0}') THEN C.ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= "    FROM profile_corporation C         "
            SQL &= String.Format("    WHERE C.`status` = 'ACTIVE' AND FIND_IN_SET(C.Branch_ID,'{0}')) T;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        Dim MonthlyBorrower As DataTable = DataSource(SQL)

        ' Create a pie chart
        'Chart.Series.Clear()
        With Chart
            .GetSeriesByName("Individual").Points.Clear()
            .GetSeriesByName("Corporate").Points.Clear()
            .GetSeriesByName("Total").Points.Clear()
            Try
                For x As Integer = 1 To MonthlyBorrower.Columns.Count - 1
                    If MonthlyBorrower.Rows.Count = 3 Then
                        .GetSeriesByName("Individual").Points.Add(New SeriesPoint(MonthlyBorrower.Columns(x).Caption, MonthlyBorrower(0)(x)))
                        .GetSeriesByName("Corporate").Points.Add(New SeriesPoint(MonthlyBorrower.Columns(x).Caption, MonthlyBorrower(1)(x)))
                        .GetSeriesByName("Total").Points.Add(New SeriesPoint(MonthlyBorrower.Columns(x).Caption, MonthlyBorrower(2)(x)))
                    ElseIf MonthlyBorrower.Rows.Count = 2 Then
                        .GetSeriesByName("Individual").Points.Add(New SeriesPoint(MonthlyBorrower.Columns(x).Caption, MonthlyBorrower(0)(x)))
                        .GetSeriesByName("Corporate").Points.Add(New SeriesPoint(MonthlyBorrower.Columns(x).Caption, 0))
                        .GetSeriesByName("Total").Points.Add(New SeriesPoint(MonthlyBorrower.Columns(x).Caption, MonthlyBorrower(1)(x)))
                    ElseIf MonthlyBorrower.Rows.Count = 1 Then
                        .GetSeriesByName("Individual").Points.Add(New SeriesPoint(MonthlyBorrower.Columns(x).Caption, MonthlyBorrower(0)(x)))
                        .GetSeriesByName("Corporate").Points.Add(New SeriesPoint(MonthlyBorrower.Columns(x).Caption, 0))
                        .GetSeriesByName("Total").Points.Add(New SeriesPoint(MonthlyBorrower.Columns(x).Caption, 0))
                    End If
                Next
                .Titles(0).Text = "Registered Borrower"
            Catch ex As Exception
                TriggerBugReport("Borrower Dashboard - Line Chart", ex.Message.ToString)
            End Try
        End With
    End Sub

    Private Sub BtnChangeView_Click(sender As Object, e As EventArgs) Handles btnChangeView.Click
        Dim Change As New FrmChangeView
        With Change
            If .ShowDialog = DialogResult.OK Then
                Display = .cbxDisplay.Text
                FromDate = .dtpFrom.Value
                ToDate = .dtpTo.Value
                LineChart(c2)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub FrmBorrowerDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmBorrowerDashboard_Load(sender, e)
        ElseIf e.Control And e.KeyCode = Keys.X Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class