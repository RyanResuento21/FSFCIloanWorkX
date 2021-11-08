Imports DevExpress.XtraCharts
Public Class FrmAssetDashboard

    Dim iManualN As Integer
    Dim iAutomaticN As Integer
    Dim iDualN As Integer

    Dim iGasolineN As Integer
    Dim iDieselN As Integer

    ReadOnly iVBelow1M_N As Integer
    ReadOnly iV2M_N As Integer
    ReadOnly iVAbove2M_N As Integer

    ReadOnly iREBelow1M_N As Integer
    ReadOnly iRE2M_N As Integer
    ReadOnly iREAbove2M_N As Integer

    Dim iHouseAndLotN As Integer
    Dim iVacantLotN As Integer

    ReadOnly iMaleN As Integer
    ReadOnly iFemaleN As Integer

    Dim iResidentialN As Integer
    Dim iCommercialN As Integer
    Dim iAgriculturalN As Integer
    Dim iTourismN As Integer
    Dim iIndustrialN As Integer
    Dim iCondomeniumN As Integer
    Dim iOthersN As Integer

    ReadOnly i20BelowN As Integer
    ReadOnly i21_30N As Integer
    ReadOnly i31_40N As Integer
    ReadOnly i41_50N As Integer
    ReadOnly i51AboveN As Integer

    Dim FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date = Date.Now
    Public ToDate As Date = Date.Now
    Public Sub FrmAssetDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        c1.Size = New Point(303, 205)
        c1.Location = New Point(849, 94)
        c2.Size = New Point(303, 205)
        c2.Location = New Point(849, 313)
        c3.Size = New Point(1140, 163)
        c3.Location = New Point(12, 524)

        FirstLoad = True

        With FrmMain
            pVehicleIncome.Text = FormatNumber(.VehicleCount_Sold, 0)
            pRealEstateIncome.Text = FormatNumber(.RealEstateCount_Sold, 0)
            pTotalIncome.Text = FormatNumber(.VehicleCount_Sold + .RealEstateCount_Sold, 0)
        End With

        LoadVehicle()
        LoadRealEstate()
        FirstLoad = False
        LoadBuyer()
        If AutoRefreshData Then
            Timer_Refresh.Interval = AutoRefreshTime * 1000
            Timer_Refresh.Start()
        End If
    End Sub

    Private Sub Timer_Refresh_Tick(sender As Object, e As EventArgs) Handles Timer_Refresh.Tick
        With FrmMain
            pVehicleIncome.Text = FormatNumber(.VehicleCount_Sold, 0)
            pRealEstateIncome.Text = FormatNumber(.RealEstateCount_Sold, 0)
            pTotalIncome.Text = FormatNumber(.VehicleCount_Sold + .RealEstateCount_Sold, 0)
        End With

        LoadVehicle()
        LoadRealEstate()
        LoadBuyer()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX14, LabelX13, LabelX16, lblManualN, lblManualP, LabelX15, lblAutomaticN, lblAutomaticP, LabelX7, lblDualN, lblDualP, LabelX9, LabelX8, LabelX11, lblGasolineN, lblGasolineP, LabelX10, lblDieselN, lblDieselP, LabelX19, LabelX18, LabelX25, lblRunningN, lblRunningP, LabelX21, lblNotRunningN, lblNotRunningP, LabelX24, LabelX23, lblType1, lblType1N, lblType1P, lblType2, lblType2N, lblType2P, lblType3, lblType3N, lblType3P, lblType4, lblType4N, lblType4P, lblType5, lblType5N, lblType5P, lblType6, lblType6N, lblType6P, lblType7, lblType7N, lblType7P, LabelX37, LabelX36, LabelX39, lblResidentialN, lblResidentialP, LabelX38, lblCommercialN, lblCommercialP, LabelX31, lblAgriculturalN, lblAgriculturalP, LabelX22, lblTourismN, lblTourismP, LabelX20, lblIndustrialN, lblIndustrialP, LabelX6, lblCondomiumN, lblCondomiumP, LabelX28, lblOthersN, lblOthersP, LabelX45, LabelX44, LabelX47, lblHouseAndLotN, lblHouseAndLotP, LabelX46, lblVacantLotN, lblVacantLotP, LabelX33, LabelX32, LabelX35, lblPrivateN, lblPrivateP, LabelX34, lblHireN, lblHireP})

            GetLabelFontSettingsDashboardTitle({LabelX3, LabelX2, LabelX1})

            GetButtonFontSettings({btnChangeView})

            GetLabelFontSettingsDashboardPanel({pVehicleAsset, pRealEstateAsset, pTotalAsset})

            GetGroupControlFontSettings({gVehicleTransmission, GroupControl1, gRealEstateClassification, gRealEstateType, GroupControl3, gVehicleFuel, GroupControl2})

            GetChartTitleControlFontSettings({c1, c2, c3})
        Catch ex As Exception
            TriggerBugReport("Asset Dashboard - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Public Sub LoadVehicle()
        With FrmMain
            pTotalIncome.Text = FormatNumber(.VehicleCount_Sold + .RealEstateCount_Sold, 0)
        End With
        Dim SQL As String = "SELECT "
        SQL &= "    FORMAT(COUNT(CASE WHEN Transmission = 'Automatic' THEN R.ID END),0) AS 'Automatic',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Transmission = 'Manual' THEN R.ID END),0) AS 'Manual',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Transmission = 'Dual Transmission' THEN R.ID END),0) AS 'Dual',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Fuel = 'Gasoline' THEN R.ID END),0) AS 'Gasoline',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Fuel = 'Diesel' THEN R.ID END),0) AS 'Diesel',"
        SQL &= "    FORMAT(COUNT(CASE WHEN `Condition` = 'Running' THEN R.ID END),0) AS 'Running',"
        SQL &= "    FORMAT(COUNT(CASE WHEN `Condition` = 'Not Running' THEN R.ID END),0) AS 'Not Running',"
        SQL &= "    FORMAT(COUNT(CASE WHEN `Used` = 'Private' THEN R.ID END),0) AS 'Private',"
        SQL &= "    FORMAT(COUNT(CASE WHEN `Used` = 'Hire' THEN R.ID END),0) AS 'Hire',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Price < 1000000 THEN R.ID END),0) AS 'Below1M',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Price BETWEEN 1000000 AND 2000000 THEN R.ID END),0) AS '1M_2M',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Price > 2000000 THEN R.ID END),0) AS 'Above2M'"
        SQL &= " FROM ropoa_vehicle R WHERE `status` = 'ACTIVE'" ' AND sell_status = 'SOLD'"
        SQL &= String.Format(" AND FIND_IN_SET(R.Branch_ID,'{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim Vehicle_Details As DataTable = DataSource(SQL)

        Try
            If Vehicle_Details.Rows.Count > 0 Then
                '***Vehicle Transmission
                iManualN = Vehicle_Details(0)("Manual")
                iAutomaticN = Vehicle_Details(0)("Automatic")
                iDualN = Vehicle_Details(0)("Automatic")

                lblManualN.Text = FormatNumber(iManualN, 0)
                lblAutomaticN.Text = FormatNumber(iAutomaticN, 0)
                lblDualN.Text = FormatNumber(iDualN, 0)

                With FrmMain
                    lblManualP.Text = FormatNumber((iManualN / .VehicleCount) * 100, 2) & " %"
                    lblAutomaticP.Text = FormatNumber((iAutomaticN / .VehicleCount) * 100, 2) & " %"
                    lblDualP.Text = FormatNumber((iDualN / .VehicleCount) * 100, 2) & " %"
                End With
                '***Vehicle Fuel
                iGasolineN = Vehicle_Details(0)("Gasoline")
                iDieselN = Vehicle_Details(0)("Diesel")

                lblGasolineN.Text = FormatNumber(iGasolineN, 0)
                lblDieselN.Text = FormatNumber(iDieselN, 0)

                With FrmMain
                    lblGasolineP.Text = FormatNumber((iGasolineN / .VehicleCount) * 100, 2) & " %"
                    lblDieselP.Text = FormatNumber((iDieselN / .VehicleCount) * 100, 2) & " %"
                End With
                '***Vehicle Condition
                lblRunningN.Text = FormatNumber(Vehicle_Details(0)("Running"), 0)
                lblNotRunningN.Text = FormatNumber(Vehicle_Details(0)("Not Running"), 0)

                With FrmMain
                    lblRunningP.Text = FormatNumber((Vehicle_Details(0)("Running") / .VehicleCount) * 100, 2) & " %"
                    lblNotRunningP.Text = FormatNumber((Vehicle_Details(0)("Not Running") / .VehicleCount) * 100, 2) & " %"
                End With
                '***Vehicle Used Type
                lblPrivateN.Text = FormatNumber(Vehicle_Details(0)("Private"), 0)
                lblHireN.Text = FormatNumber(Vehicle_Details(0)("Hire"), 0)

                With FrmMain
                    lblPrivateP.Text = FormatNumber((Vehicle_Details(0)("Private") / .VehicleCount) * 100, 2) & " %"
                    lblHireP.Text = FormatNumber((Vehicle_Details(0)("Hire") / .VehicleCount) * 100, 2) & " %"
                End With
            End If

            SQL = String.Format("SELECT  `Type`, COUNT(DISTINCT ID) AS 'Number' FROM ropoa_vehicle R WHERE `status` = 'ACTIVE' AND FIND_IN_SET(R.Branch_ID,'{0}') GROUP BY `Type` ORDER BY `Number` DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
            Dim Vehicle_Types As DataTable = DataSource(SQL)
            If Vehicle_Types.Rows.Count > 0 Then
                lblType1.Text = "1. " & UpperCaseFirst(Vehicle_Types(0)("Type"))
                lblType1N.Text = FormatNumber(Vehicle_Types(0)("Number"), 0)
                lblType1P.Text = FormatNumber((Vehicle_Types(0)("Number") / FrmMain.VehicleCount) * 100, 2) & " %"

                If Vehicle_Types.Rows.Count > 2 - 1 Then
                    lblType2.Text = "2. " & UpperCaseFirst(Vehicle_Types(2 - 1)("Type"))
                    lblType2N.Text = FormatNumber(Vehicle_Types(2 - 1)("Number"), 0)
                    lblType2P.Text = FormatNumber((Vehicle_Types(2 - 1)("Number") / FrmMain.VehicleCount) * 100, 2) & " %"
                Else
                    lblType2.Text = "2. "
                    lblType2N.Text = "0"
                    lblType2P.Text = "0.00 %"
                End If

                If Vehicle_Types.Rows.Count > 3 - 1 Then
                    lblType3.Text = "3. " & UpperCaseFirst(Vehicle_Types(3 - 1)("Type"))
                    lblType3N.Text = FormatNumber(Vehicle_Types(3 - 1)("Number"), 0)
                    lblType3P.Text = FormatNumber((Vehicle_Types(3 - 1)("Number") / FrmMain.VehicleCount) * 100, 2) & " %"
                Else
                    lblType3.Text = "3. "
                    lblType3N.Text = "0"
                    lblType3P.Text = "0.00 %"
                End If

                If Vehicle_Types.Rows.Count > 4 - 1 Then
                    lblType4.Text = "4. " & UpperCaseFirst(Vehicle_Types(4 - 1)("Type"))
                    lblType4N.Text = FormatNumber(Vehicle_Types(4 - 1)("Number"), 0)
                    lblType4P.Text = FormatNumber((Vehicle_Types(4 - 1)("Number") / FrmMain.VehicleCount) * 100, 2) & " %"
                Else
                    lblType4.Text = "4. "
                    lblType4N.Text = "0"
                    lblType4P.Text = "0.00 %"
                End If

                If Vehicle_Types.Rows.Count > 5 - 1 Then
                    lblType5.Text = "5. " & UpperCaseFirst(Vehicle_Types(5 - 1)("Type"))
                    lblType5N.Text = FormatNumber(Vehicle_Types(5 - 1)("Number"), 0)
                    lblType5P.Text = FormatNumber((Vehicle_Types(5 - 1)("Number") / FrmMain.VehicleCount) * 100, 2) & " %"
                Else
                    lblType5.Text = "3. "
                    lblType5N.Text = "0"
                    lblType5P.Text = "0.00 %"
                End If

                If Vehicle_Types.Rows.Count > 6 - 1 Then
                    lblType6.Text = "6. " & UpperCaseFirst(Vehicle_Types(6 - 1)("Type"))
                    lblType6N.Text = FormatNumber(Vehicle_Types(6 - 1)("Number"), 0)
                    lblType6P.Text = FormatNumber((Vehicle_Types(6 - 1)("Number") / FrmMain.VehicleCount) * 100, 2) & " %"
                Else
                    lblType6.Text = "6. "
                    lblType6N.Text = "0"
                    lblType6P.Text = "0.00 %"
                End If

                If Vehicle_Types.Rows.Count > 7 - 1 Then
                    lblType7.Text = "7. " & UpperCaseFirst(Vehicle_Types(7 - 1)("Type"))
                    lblType7N.Text = FormatNumber(Vehicle_Types(7 - 1)("Number"), 0)
                    lblType7P.Text = FormatNumber((Vehicle_Types(7 - 1)("Number") / FrmMain.VehicleCount) * 100, 2) & " %"
                Else
                    lblType7.Text = "7. "
                    lblType7N.Text = "0"
                    lblType7P.Text = "0.00 %"
                End If
            Else
                lblType1.Text = "1. "
                lblType1N.Text = "0"
                lblType1P.Text = "0.00 %"

                lblType2.Text = "2. "
                lblType2N.Text = "0"
                lblType2P.Text = "0.00 %"

                lblType3.Text = "3. "
                lblType3N.Text = "0"
                lblType3P.Text = "0.00 %"

                lblType4.Text = "4. "
                lblType4N.Text = "0"
                lblType4P.Text = "0.00 %"

                lblType5.Text = "5. "
                lblType5N.Text = "0"
                lblType5P.Text = "0.00 %"

                lblType6.Text = "6. "
                lblType6N.Text = "0"
                lblType6P.Text = "0.00 %"

                lblType7.Text = "7. "
                lblType7N.Text = "0"
                lblType7P.Text = "0.00 %"
            End If

        Catch ex As Exception
            TriggerBugReport("Asset Dashboard - LoadVehicle", ex.Message.ToString)
        End Try
    End Sub

    Public Sub LoadRealEstate()
        With FrmMain
            pTotalIncome.Text = FormatNumber(.VehicleCount_Sold + .RealEstateCount_Sold, 0)
        End With
        Dim SQL As String = "SELECT "
        SQL &= "    FORMAT(COUNT(CASE WHEN VacantLot = 'NO' THEN R.ID END),0) AS 'House and Lot',"
        SQL &= "    FORMAT(COUNT(CASE WHEN VacantLot = 'YES' THEN R.ID END),0) AS 'Vacant Lot',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Classification = 'Residential' THEN R.ID END),0) AS 'Residential',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Classification = 'Commercial' THEN R.ID END),0) AS 'Commercial',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Classification = 'Agricultural' THEN R.ID END),0) AS 'Agricultural',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Classification = 'Tourism' THEN R.ID END),0) AS 'Tourism',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Classification = 'Industrial' THEN R.ID END),0) AS 'Industrial',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Classification = 'Condominium' THEN R.ID END),0) AS 'Condominium',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Classification = 'Others' THEN R.ID END),0) AS 'Others',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Price < 1000000 THEN R.ID END),0) AS 'Below1M',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Price BETWEEN 1000000 AND 2000000 THEN R.ID END),0) AS '1M_2M',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Price > 2000000 THEN R.ID END),0) AS 'Above2M'"
        SQL &= " FROM ropoa_realestate R WHERE `status` = 'ACTIVE'" ' AND sell_status = 'SOLD'"
        SQL &= String.Format(" AND FIND_IN_SET(R.Branch_ID,'{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim RE_Details As DataTable = DataSource(SQL)

        Try
            If RE_Details.Rows.Count > 0 Then
                '***RE Type
                iHouseAndLotN = RE_Details(0)("House and Lot")
                iVacantLotN = RE_Details(0)("Vacant Lot")

                lblHouseAndLotN.Text = FormatNumber(iHouseAndLotN, 0)
                lblVacantLotN.Text = FormatNumber(iVacantLotN, 0)

                With FrmMain
                    lblHouseAndLotP.Text = FormatNumber((iHouseAndLotN / .RealEstateCount) * 100, 2) & " %"
                    lblVacantLotP.Text = FormatNumber((iVacantLotN / .RealEstateCount) * 100, 2) & " %"
                End With

                '***RE Classification
                iResidentialN = RE_Details(0)("Residential")
                iCommercialN = RE_Details(0)("Commercial")
                iAgriculturalN = RE_Details(0)("Agricultural")
                iTourismN = RE_Details(0)("Tourism")
                iIndustrialN = RE_Details(0)("Industrial")
                iCondomeniumN = RE_Details(0)("Condominium")
                iOthersN = RE_Details(0)("Others")

                lblResidentialN.Text = FormatNumber(iResidentialN, 0)
                lblCommercialN.Text = FormatNumber(iCommercialN, 0)
                lblAgriculturalN.Text = FormatNumber(iAgriculturalN, 0)
                lblTourismN.Text = FormatNumber(iTourismN, 0)
                lblIndustrialN.Text = FormatNumber(iIndustrialN, 0)
                lblCondomiumN.Text = FormatNumber(iCondomeniumN, 0)
                lblOthersN.Text = FormatNumber(iOthersN, 0)

                With FrmMain
                    lblResidentialP.Text = FormatNumber((iResidentialN / .RealEstateCount) * 100, 2) & " %"
                    lblCommercialP.Text = FormatNumber((iCommercialN / .RealEstateCount) * 100, 2) & " %"
                    lblAgriculturalP.Text = FormatNumber((iAgriculturalN / .RealEstateCount) * 100, 2) & " %"
                    lblTourismP.Text = FormatNumber((iTourismN / .RealEstateCount) * 100, 2) & " %"
                    lblIndustrialP.Text = FormatNumber((iIndustrialN / .RealEstateCount) * 100, 2) & " %"
                    lblCondomiumP.Text = FormatNumber((iCondomeniumN / .RealEstateCount) * 100, 2) & " %"
                    lblOthersP.Text = FormatNumber((iOthersN / .RealEstateCount) * 100, 2) & " %"
                End With
            End If
        Catch ex As Exception
            TriggerBugReport("Asset Dashboard - LoanRealEstate", ex.Message.ToString)
        End Try
    End Sub

    Public Sub LoadBuyer()
        Dim VL As DataTable = DataSource(String.Format("SELECT FORMAT(COUNT(DISTINCT PlateNum),0) AS 'vCount', FORMAT(IFNULL(SUM(IF(account_count > 1,Price/account_count,Price)),0),2) AS 'vIncome' FROM ropoa_vehicle WHERE `status` = 'ACTIVE' AND sell_status IN ('SELL','SCRAP','RESERVED') AND Branch_ID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        Dim RE As DataTable = DataSource(String.Format("SELECT FORMAT(COUNT(DISTINCT TCT),0) AS 'vCount', FORMAT(IFNULL(SUM(IF(account_count > 1,Price/account_count,Price)),0),2) AS 'vIncome' FROM ropoa_realestate WHERE `status` = 'ACTIVE' AND sell_status IN ('SELL','SCRAP','RESERVED') AND Branch_ID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        Dim V_Asset As Double = VL(0)("vIncome")
        Dim RE_Asset As Double = RE(0)("vIncome")
        Dim V_Count As Double = VL(0)("vCount")
        Dim RE_Count As Double = RE(0)("vCount")

        pVehicleAsset.Text = FormatNumber(V_Count, 0)
        pRealEstateAsset.Text = FormatNumber(RE_Count, 0)
        pTotalAsset.Text = FormatNumber(V_Count + RE_Count, 0)

        PieChartSold(c1)
        PieChartIncome(c2)
        LineChart(c3)
    End Sub

    Private Sub PieChartSold(Chart As ChartControl)
        Dim Product As New DataTable
        With Product
            .Columns.Add("Vehicle")
            .Columns.Add("Real Estate")
            .Rows.Add("Vehicle", FrmMain.VehicleCount_Sold)
            .Rows.Add("Real Estate", FrmMain.RealEstateCount_Sold)
        End With
        ' Create a pie chart
        Chart.Series.Clear()
        Try
            Dim Series1 As New Series("Vehicle vs RE Sold", ViewType.Pie)

            For x As Integer = 0 To Product.Rows.Count - 1
                Series1.Points.Add(New SeriesPoint(Product(x)("Vehicle"), Product(x)("Real Estate")))
            Next

            ' Add the series to the chart.
            Chart.Series.Add(Series1)

            CType(Series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

            Dim myView As PieSeriesView = CType(Series1.View, PieSeriesView)
        Catch ex As Exception
            TriggerBugReport("Asset Dashboard - PieChartSold", ex.Message.ToString)
        End Try
    End Sub

    Private Sub PieChartIncome(Chart As ChartControl)
        Dim Product As New DataTable
        Dim V_Asset As Double = DataObject(String.Format("SELECT IFNULL(FORMAT(SUM(Amount),2),0) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANV' AND Branch_ID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        Dim RE_Asset As Double = DataObject(String.Format("SELECT IFNULL(FORMAT(SUM(Amount),2),0) FROM sold_ropoa WHERE `status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANR' AND Branch_ID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID)))

        With Product
            .Columns.Add("Vehicle")
            .Columns.Add("Real Estate")
            .Rows.Add("Vehicle", V_Asset)
            .Rows.Add("Real Estate", RE_Asset)
        End With
        ' Create a pie chart
        Chart.Series.Clear()
        Try
            Dim Series1 As New Series("Vehicle vs RE Income", ViewType.Pie)

            For x As Integer = 0 To Product.Rows.Count - 1
                Series1.Points.Add(New SeriesPoint(Product(x)("Vehicle"), Product(x)("Real Estate")))
            Next

            ' Add the series to the chart.
            Chart.Series.Add(Series1)

            CType(Series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

            Dim myView As PieSeriesView = CType(Series1.View, PieSeriesView)
        Catch ex As Exception
            TriggerBugReport("Asset Dashboard - PieChartIncome", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Dim SQL As String
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT "
            SQL &= "     1 AS 'ID',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 1 THEN S.ID END),0) AS 'Jan',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 2 THEN S.ID END),0) AS 'Feb',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 3 THEN S.ID END),0) AS 'Mar',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 4 THEN S.ID END),0) AS 'Apr',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 5 THEN S.ID END),0) AS 'May',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 6 THEN S.ID END),0) AS 'Jun',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 7 THEN S.ID END),0) AS 'Jul',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 8 THEN S.ID END),0) AS 'Aug',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 9 THEN S.ID END),0) AS 'Sep',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 10 THEN S.ID END),0) AS 'Oct',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 11 THEN S.ID END),0) AS 'Nov',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 12 THEN S.ID END),0) AS 'Dec'"
            SQL &= " FROM sold_ropoa S LEFT JOIN (SELECT MIN(ORDate) AS 'ORDate', ReferenceN FROM accounting_entry WHERE `status` = 'ACTIVE' GROUP BY ReferenceN) A ON A.ReferenceN = S.AssetNumber"
            SQL &= String.Format(" WHERE S.`status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANV' AND FIND_IN_SET(S.Branch_ID,'{2}') AND YEAR(IFNULL(A.ORDate,NOW())) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= " UNION"
            SQL &= " SELECT "
            SQL &= "     2 AS 'ID',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 1 THEN S.ID END),0) AS 'Jan',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 2 THEN S.ID END),0) AS 'Feb',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 3 THEN S.ID END),0) AS 'Mar',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 4 THEN S.ID END),0) AS 'Apr',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 5 THEN S.ID END),0) AS 'May',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 6 THEN S.ID END),0) AS 'Jun',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 7 THEN S.ID END),0) AS 'Jul',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 8 THEN S.ID END),0) AS 'Aug',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 9 THEN S.ID END),0) AS 'Sep',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 10 THEN S.ID END),0) AS 'Oct',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 11 THEN S.ID END),0) AS 'Nov',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 12 THEN S.ID END),0) AS 'Dec'"
            SQL &= " FROM sold_ropoa S LEFT JOIN (SELECT MIN(ORDate) AS 'ORDate', ReferenceN FROM accounting_entry WHERE `status` = 'ACTIVE' GROUP BY ReferenceN) A ON A.ReferenceN = S.AssetNumber"
            SQL &= String.Format(" WHERE S.`status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANR' AND FIND_IN_SET(S.Branch_ID,'{2}') AND YEAR(IFNULL(A.ORDate,NOW())) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= " UNION"
            SQL &= " SELECT "
            SQL &= "     3 AS 'ID',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 1 THEN S.ID END),0) AS 'Jan',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 2 THEN S.ID END),0) AS 'Feb',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 3 THEN S.ID END),0) AS 'Mar',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 4 THEN S.ID END),0) AS 'Apr',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 5 THEN S.ID END),0) AS 'May',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 6 THEN S.ID END),0) AS 'Jun',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 7 THEN S.ID END),0) AS 'Jul',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 8 THEN S.ID END),0) AS 'Aug',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 9 THEN S.ID END),0) AS 'Sep',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 10 THEN S.ID END),0) AS 'Oct',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 11 THEN S.ID END),0) AS 'Nov',"
            SQL &= "     FORMAT(COUNT(CASE WHEN MONTH(IFNULL(A.ORDate,NOW())) = 12 THEN S.ID END),0) AS 'Dec'"
            SQL &= " FROM sold_ropoa S LEFT JOIN (SELECT MIN(ORDate) AS 'ORDate', ReferenceN FROM accounting_entry WHERE `status` = 'ACTIVE' GROUP BY ReferenceN) A ON A.ReferenceN = S.AssetNumber"
            SQL &= String.Format(" WHERE S.`status` = 'ACTIVE' AND FIND_IN_SET(S.Branch_ID,'{2}') AND YEAR(IFNULL(A.ORDate,NOW())) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Else
            SQL = "SELECT"
            SQL &= "    1 AS 'ID',"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(IFNULL(A.ORDate,NOW())) = DATE('{0}') THEN S.ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(IFNULL(A.ORDate,NOW())) = DATE('{0}') THEN S.ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM sold_ropoa S LEFT JOIN (SELECT MIN(ORDate) AS 'ORDate', ReferenceN FROM accounting_entry WHERE `status` = 'ACTIVE' GROUP BY ReferenceN) A ON A.ReferenceN = S.AssetNumber"
            SQL &= String.Format(" WHERE S.`status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANV' AND FIND_IN_SET(S.Branch_ID,'{0}') ", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= " UNION"

            SQL &= " SELECT"
            SQL &= "    2 AS 'ID',"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(IFNULL(A.ORDate,NOW())) = DATE('{0}') THEN S.ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(IFNULL(A.ORDate,NOW())) = DATE('{0}') THEN S.ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM sold_ropoa S LEFT JOIN (SELECT MIN(ORDate) AS 'ORDate', ReferenceN FROM accounting_entry WHERE `status` = 'ACTIVE' GROUP BY ReferenceN) A ON A.ReferenceN = S.AssetNumber"
            SQL &= String.Format(" WHERE S.`status` = 'ACTIVE' AND SUBSTRING(AssetNumber,1,3) = 'ANR' AND FIND_IN_SET(S.Branch_ID,'{0}') ", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= " UNION"

            SQL &= " SELECT"
            SQL &= "    3 AS 'ID',"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(IFNULL(A.ORDate,NOW())) = DATE('{0}') THEN S.ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(IFNULL(A.ORDate,NOW())) = DATE('{0}') THEN S.ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM sold_ropoa S LEFT JOIN (SELECT MIN(ORDate) AS 'ORDate', ReferenceN FROM accounting_entry WHERE `status` = 'ACTIVE' GROUP BY ReferenceN) A ON A.ReferenceN = S.AssetNumber"
            SQL &= String.Format(" WHERE S.`status` = 'ACTIVE' AND FIND_IN_SET(S.Branch_ID,'{0}') ", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        Dim MonthlyRopoa As DataTable = DataSource(SQL)

        ' Create a pie chart
        With Chart
            .GetSeriesByName("Vehicle").Points.Clear()
            .GetSeriesByName("Real Estate").Points.Clear()
            .GetSeriesByName("Total").Points.Clear()
            Try
                For x As Integer = 1 To MonthlyRopoa.Columns.Count - 1
                    If MonthlyRopoa.Rows.Count = 3 Then
                        .GetSeriesByName("Vehicle").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(0)(x)))
                        .GetSeriesByName("Real Estate").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(1)(x)))
                        .GetSeriesByName("Total").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(2)(x)))
                    ElseIf MonthlyRopoa.Rows.Count = 2 Then
                        .GetSeriesByName("Vehicle").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(0)(x)))
                        .GetSeriesByName("Real Estate").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, 0))
                        .GetSeriesByName("Total").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(1)(x)))
                    ElseIf MonthlyRopoa.Rows.Count = 1 Then
                        .GetSeriesByName("Vehicle").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(0)(x)))
                        .GetSeriesByName("Real Estate").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, 0))
                        .GetSeriesByName("Total").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, 0))
                    End If
                Next
            Catch ex As Exception
                TriggerBugReport("Asset Dashboard - LineChart", ex.Message.ToString)
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
                LineChart(c3)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub FrmAssetDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmAssetDashboard_Load(sender, e)
        ElseIf e.Control And e.KeyCode = Keys.X Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class