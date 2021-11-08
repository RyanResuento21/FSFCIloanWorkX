Imports DevExpress.XtraCharts
Public Class FrmBookingDashboard

    Dim FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date
    Public ToDate As Date
    Dim TotalTarget As Double
    Private Sub FrmBookingDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        Chart1.Location = New Point(12, 421)
        Chart1.Size = New Point(1140, 266)
        FromDate = CDate("01-01-" & Date.Now.Year)
        ToDate = CDate("12-31-" & Date.Now.Year)

        FirstLoad = True

        LineChart(Chart1)
        LoadMonth()
        LoadData()
        If AutoRefreshData Then
            Timer_Refresh.Interval = AutoRefreshTime * 1000
            Timer_Refresh.Start()
        End If

        FirstLoad = False
    End Sub

    Private Sub Timer_Refresh_Tick(sender As Object, e As EventArgs) Handles Timer_Refresh.Tick
        LineChart(Chart1)
        LoadMonth()
        LoadData()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX1, LabelX34, LabelX12, lblProduct1, lblProductN1, lblProductP1, lblProduct2, lblProductN2, lblProductP2, lblProduct3, lblProductN3, lblProductP3, lblProduct4, lblProductN4, lblProductP4, lblProduct5, lblProductN5, lblProductP5, lblProduct6, lblProductN6, lblProductP6, lblProduct7, lblProductN7, lblProductP7, lblProduct8, lblProductN8, lblProductP8, lblProduct9, lblProductN9, lblProductP9, lblProduct10, lblProductN10, lblProductP10, lblProduct11, lblProductN11, lblProductP11, LabelX24, LabelX61, lblMonth1, lblMonthN1, lblMonthP1, lblMonth2, lblMonthN2, lblMonthP2, lblMonth3, lblMonthN3, lblMonthP3, lblMonth4, lblMonthN4, lblMonthP4, lblMonth5, lblMonthN5, lblMonthP5, LabelX37, LabelX21, LabelX33, lblMarketing1, lblMarketingN1, lblMarketingP1, lblMarketing2, lblMarketingN2, lblMarketingP2, lblMarketing3, lblMarketingN3, lblMarketingP3, lblMarketing4, lblMarketingN4, lblMarketingP4, lblMarketing5, lblMarketingN5, lblMarketingP5, LabelX30, LabelX29, lblStatusN1, lblStatusP1, lblStatusN2, lblStatusP2, lblStatusN3, lblStatusP3})

            GetLabelFontSettingsDefault({LabelX26, LabelX32, LabelX31})

            GetLabelFontSettingsDashboardTitle({LabelX87, LabelX25, LabelX35, LabelX28})

            GetButtonFontSettings({btnChangeView})

            GetLabelFontSettingsDashboardPanel({pBookings, pBookingsMonth, pRemainingBookings, pEstimateDay})

            GetGroupControlFontSettings({GroupControl1, GroupControl3, GroupControl4, gCivilStatus})

            GetChartTitleControlFontSettings({Chart1})
        Catch ex As Exception
            TriggerBugReport("Booking Dashboard - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadMonth()
        Dim SQL As String = String.Format("SELECT DATE_FORMAT(Trans_Date,'%M') AS 'Months', COUNT(DISTINCT ID) AS 'Number' FROM credit_application WHERE `status` = 'ACTIVE' AND application_status = 'APPROVED' AND PaymentRequest IN ('RELEASED','CLOSED') AND Branch_ID IN ({1}) GROUP BY MONTH(Trans_Date) ORDER BY `Number` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT_Months As DataTable = DataSource(SQL)
        If DT_Months.Rows.Count > 0 Then
            lblMonth1.Text = "1. " & DT_Months(0)("Months")
            lblMonthN1.Text = FormatNumber(DT_Months(0)("Number"), 0)
            lblMonthP1.Text = FormatNumber((DT_Months(0)("Number") / pBookings.Text) * 100, 2) & " %"

            If DT_Months.Rows.Count > 2 - 1 Then
                lblMonth2.Text = "2. " & DT_Months(2 - 1)("Months")
                lblMonthN2.Text = FormatNumber(DT_Months(2 - 1)("Number"), 0)
                lblMonthP2.Text = FormatNumber((DT_Months(2 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblMonth2.Text = "2. "
                lblMonthN2.Text = "0"
                lblMonthP2.Text = "0.00 %"
            End If

            If DT_Months.Rows.Count > 3 - 1 Then
                lblMonth3.Text = "3. " & DT_Months(3 - 1)("Months")
                lblMonthN3.Text = FormatNumber(DT_Months(3 - 1)("Number"), 0)
                lblMonthP3.Text = FormatNumber((DT_Months(3 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblMonth3.Text = "3. "
                lblMonthN3.Text = "0"
                lblMonthP3.Text = "0.00 %"
            End If

            If DT_Months.Rows.Count > 4 - 1 Then
                lblMonth4.Text = "4. " & DT_Months(4 - 1)("Months")
                lblMonthN4.Text = FormatNumber(DT_Months(4 - 1)("Number"), 0)
                lblMonthP4.Text = FormatNumber((DT_Months(4 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblMonth4.Text = "4. "
                lblMonthN4.Text = "0"
                lblMonthP4.Text = "0.00 %"
            End If

            If DT_Months.Rows.Count > 5 - 1 Then
                lblMonth5.Text = "5. " & DT_Months(5 - 1)("Months")
                lblMonthN5.Text = FormatNumber(DT_Months(5 - 1)("Number"), 0)
                lblMonthP5.Text = FormatNumber((DT_Months(5 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblMonth5.Text = "5. "
                lblMonthN5.Text = "0"
                lblMonthP5.Text = "0.00 %"
            End If
        Else
            lblMonth1.Text = "1. "
            lblMonthN1.Text = "0"
            lblMonthP1.Text = "0.00 %"

            lblMonth2.Text = "2. "
            lblMonthN2.Text = "0"
            lblMonthP2.Text = "0.00 %"

            lblMonth3.Text = "3. "
            lblMonthN3.Text = "0"
            lblMonthP3.Text = "0.00 %"

            lblMonth4.Text = "4. "
            lblMonthN4.Text = "0"
            lblMonthP4.Text = "0.00 %"

            lblMonth5.Text = "5. "
            lblMonthN5.Text = "0"
            lblMonthP5.Text = "0.00 %"
        End If
    End Sub

    Private Sub LoadData()
        pBookings.Text = DataObject(String.Format("SELECT FORMAT(COUNT(DISTINCT ID),0) FROM credit_application WHERE `status` = 'ACTIVE' AND application_status = 'APPROVED' AND PaymentRequest IN ('RELEASED','CLOSED') AND Branch_ID IN ({1}) AND Released BETWEEN '{2}' AND '{3}'", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(FromDate, "yyyy-MM-dd"), Format(ToDate, "yyyy-MM-dd")))
        pBookingsMonth.Text = DataObject(String.Format("SELECT FORMAT(COUNT(DISTINCT ID),0) FROM credit_application WHERE `status` = 'ACTIVE' AND application_status = 'APPROVED' AND PaymentRequest IN ('RELEASED','CLOSED') AND Branch_ID IN ({1}) AND Released BETWEEN '{2}' AND '{3}'", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(FromDate.AddYears(-1), "yyyy-MM-dd"), Format(ToDate.AddYears(-1), "yyyy-MM-dd")))
        pRemainingBookings.Text = FormatNumber(pBookings.Text / DateDiff(DateInterval.Day, FromDate, ToDate), 2)
        pEstimateDay.Text = FormatNumber(pBookingsMonth.Text / DateDiff(DateInterval.Day, FromDate.AddYears(-1), ToDate.AddYears(-1)), 2)
        Dim SQL As String = String.Format("SELECT * FROM (SELECT (SELECT Product FROM product_setup WHERE ID = Product_ID) AS 'Product', COUNT(DISTINCT ID) AS 'Number' FROM credit_application WHERE `status` = 'ACTIVE' AND application_status = 'APPROVED' AND PaymentRequest IN ('RELEASED','CLOSED') AND Branch_ID IN ({1}) AND Released BETWEEN '{2}' AND '{3}' GROUP BY `Product` ORDER BY `Number` DESC) A GROUP BY `Product`;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(FromDate, "yyyy-MM-dd"), Format(ToDate, "yyyy-MM-dd"))

        Dim DT_Product As DataTable = DataSource(SQL)
        If DT_Product.Rows.Count > 0 Then
            lblProduct1.Text = "1. " & DT_Product(0)("Product")
            lblProductN1.Text = FormatNumber(DT_Product(0)("Number"), 0)
            lblProductP1.Text = FormatNumber((DT_Product(0)("Number") / pBookings.Text) * 100, 2) & " %"

            If DT_Product.Rows.Count > 2 - 1 Then
                lblProduct2.Text = "2. " & DT_Product(2 - 1)("Product")
                lblProductN2.Text = FormatNumber(DT_Product(2 - 1)("Number"), 0)
                lblProductP2.Text = FormatNumber((DT_Product(2 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct2.Text = "2. "
                lblProductN2.Text = "0"
                lblProductP2.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 3 - 1 Then
                lblProduct3.Text = "3. " & DT_Product(3 - 1)("Product")
                lblProductN3.Text = FormatNumber(DT_Product(3 - 1)("Number"), 0)
                lblProductP3.Text = FormatNumber((DT_Product(3 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct3.Text = "3. "
                lblProductN3.Text = "0"
                lblProductP3.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 4 - 1 Then
                lblProduct4.Text = "4. " & DT_Product(4 - 1)("Product")
                lblProductN4.Text = FormatNumber(DT_Product(4 - 1)("Number"), 0)
                lblProductP4.Text = FormatNumber((DT_Product(4 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct4.Text = "4. "
                lblProductN4.Text = "0"
                lblProductP4.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 5 - 1 Then
                lblProduct5.Text = "5. " & DT_Product(5 - 1)("Product")
                lblProductN5.Text = FormatNumber(DT_Product(5 - 1)("Number"), 0)
                lblProductP5.Text = FormatNumber((DT_Product(5 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct5.Text = "5. "
                lblProductN5.Text = "0"
                lblProductP5.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 6 - 1 Then
                lblProduct6.Text = "6. " & DT_Product(6 - 1)("Product")
                lblProductN6.Text = FormatNumber(DT_Product(6 - 1)("Number"), 0)
                lblProductP6.Text = FormatNumber((DT_Product(6 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct6.Text = "6. "
                lblProductN6.Text = "0"
                lblProductP6.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 7 - 1 Then
                lblProduct7.Text = "7. " & DT_Product(7 - 1)("Product")
                lblProductN7.Text = FormatNumber(DT_Product(7 - 1)("Number"), 0)
                lblProductP7.Text = FormatNumber((DT_Product(7 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct7.Text = "7. "
                lblProductN7.Text = "0"
                lblProductP7.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 8 - 1 Then
                lblProduct8.Text = "8. " & DT_Product(8 - 1)("Product")
                lblProductN8.Text = FormatNumber(DT_Product(8 - 1)("Number"), 0)
                lblProductP8.Text = FormatNumber((DT_Product(8 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct8.Text = "8. "
                lblProductN8.Text = "0"
                lblProductP8.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 9 - 1 Then
                lblProduct9.Text = "9. " & DT_Product(9 - 1)("Product")
                lblProductN9.Text = FormatNumber(DT_Product(9 - 1)("Number"), 0)
                lblProductP9.Text = FormatNumber((DT_Product(9 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct9.Text = "9. "
                lblProductN9.Text = "0"
                lblProductP9.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 10 - 1 Then
                lblProduct10.Text = "10. " & DT_Product(10 - 1)("Product")
                lblProductN10.Text = FormatNumber(DT_Product(10 - 1)("Number"), 0)
                lblProductP10.Text = FormatNumber((DT_Product(10 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct10.Text = "10. "
                lblProductN10.Text = "0"
                lblProductP10.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 11 - 1 Then
                lblProduct11.Text = "10. " & DT_Product(11 - 1)("Product")
                lblProductN11.Text = FormatNumber(DT_Product(11 - 1)("Number"), 0)
                lblProductP11.Text = FormatNumber((DT_Product(11 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblProduct11.Text = "11. "
                lblProductN11.Text = "0"
                lblProductP11.Text = "0.00 %"
            End If
        Else
            lblProduct1.Text = "1. "
            lblProductN1.Text = "0"
            lblProductP1.Text = "0.00 %"

            lblProduct2.Text = "2. "
            lblProductN2.Text = "0"
            lblProductP2.Text = "0.00 %"

            lblProduct3.Text = "3. "
            lblProductN3.Text = "0"
            lblProductP3.Text = "0.00 %"

            lblProduct4.Text = "4. "
            lblProductN4.Text = "0"
            lblProductP4.Text = "0.00 %"

            lblProduct5.Text = "5. "
            lblProductN5.Text = "0"
            lblProductP5.Text = "0.00 %"

            lblProduct6.Text = "6. "
            lblProductN6.Text = "0"
            lblProductP6.Text = "0.00 %"

            lblProduct7.Text = "7. "
            lblProductN7.Text = "0"
            lblProductP7.Text = "0.00 %"

            lblProduct8.Text = "8. "
            lblProductN8.Text = "0"
            lblProductP8.Text = "0.00 %"

            lblProduct9.Text = "9. "
            lblProductN9.Text = "0"
            lblProductP9.Text = "0.00 %"

            lblProduct10.Text = "10. "
            lblProductN10.Text = "0"
            lblProductP10.Text = "0.00 %"

            lblProduct11.Text = "11. "
            lblProductN11.Text = "0"
            lblProductP11.Text = "0.00 %"
        End If

        SQL = String.Format("SELECT IF(Marketing = '','* No Marketing *',Marketing) AS 'Marketing', COUNT(DISTINCT ID) AS 'Number' FROM credit_application WHERE `status` = 'ACTIVE' AND application_status = 'APPROVED' AND PaymentRequest IN ('RELEASED','CLOSED') AND Branch_ID IN ({1}) AND Released BETWEEN '{2}' AND '{3}' GROUP BY MarketingID ORDER BY `Number` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(FromDate, "yyyy-MM-dd"), Format(ToDate, "yyyy-MM-dd"))
        Dim DT_Marketing As DataTable = DataSource(SQL)
        If DT_Marketing.Rows.Count > 0 Then
            lblMarketing1.Text = "1. " & UpperCaseFirst(DT_Marketing(0)("Marketing"))
            lblMarketingN1.Text = FormatNumber(DT_Marketing(0)("Number"), 0)
            lblMarketingP1.Text = FormatNumber((DT_Marketing(0)("Number") / pBookings.Text) * 100, 2) & " %"

            If DT_Marketing.Rows.Count > 2 - 1 Then
                lblMarketing2.Text = "2. " & UpperCaseFirst(DT_Marketing(2 - 1)("Marketing"))
                lblMarketingN2.Text = FormatNumber(DT_Marketing(2 - 1)("Number"), 0)
                lblMarketingP2.Text = FormatNumber((DT_Marketing(2 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblMarketing2.Text = "2. "
                lblMarketingN2.Text = "0"
                lblMarketingP2.Text = "0.00 %"
            End If

            If DT_Marketing.Rows.Count > 3 - 1 Then
                lblMarketing3.Text = "3. " & UpperCaseFirst(DT_Marketing(3 - 1)("Marketing"))
                lblMarketingN3.Text = FormatNumber(DT_Marketing(3 - 1)("Number"), 0)
                lblMarketingP3.Text = FormatNumber((DT_Marketing(3 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblMarketing3.Text = "3. "
                lblMarketingN3.Text = "0"
                lblMarketingP3.Text = "0.00 %"
            End If

            If DT_Marketing.Rows.Count > 4 - 1 Then
                lblMarketing4.Text = "4. " & UpperCaseFirst(DT_Marketing(4 - 1)("Marketing"))
                lblMarketingN4.Text = FormatNumber(DT_Marketing(4 - 1)("Number"), 0)
                lblMarketingP4.Text = FormatNumber((DT_Marketing(4 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblMarketing4.Text = "4. "
                lblMarketingN4.Text = "0"
                lblMarketingP4.Text = "0.00 %"
            End If

            If DT_Marketing.Rows.Count > 5 - 1 Then
                lblMarketing5.Text = "5. " & UpperCaseFirst(DT_Marketing(5 - 1)("Marketing"))
                lblMarketingN5.Text = FormatNumber(DT_Marketing(5 - 1)("Number"), 0)
                lblMarketingP5.Text = FormatNumber((DT_Marketing(5 - 1)("Number") / pBookings.Text) * 100, 2) & " %"
            Else
                lblMarketing5.Text = "5. "
                lblMarketingN5.Text = "0"
                lblMarketingP5.Text = "0.00 %"
            End If
        Else
            lblMarketing1.Text = "1. "
            lblMarketingN1.Text = "0"
            lblMarketingP1.Text = "0.00 %"

            lblMarketing2.Text = "2. "
            lblMarketingN2.Text = "0"
            lblMarketingP2.Text = "0.00 %"

            lblMarketing3.Text = "3. "
            lblMarketingN3.Text = "0"
            lblMarketingP3.Text = "0.00 %"

            lblMarketing4.Text = "4. "
            lblMarketingN4.Text = "0"
            lblMarketingP4.Text = "0.00 %"

            lblMarketing5.Text = "5. "
            lblMarketingN5.Text = "0"
            lblMarketingP5.Text = "0.00 %"
        End If

        SQL = "SELECT "
        SQL &= "    FORMAT(COUNT(CASE WHEN PaymentRequest IN ('REQUEST','REQUESTED','CHECKED REQUEST','APPROVED REQUEST','PENDING') THEN ID END),0) AS 'Pending',"
        SQL &= "    FORMAT(COUNT(CASE WHEN PaymentRequest IN ('RELEASED','CLOSED') THEN ID END),0) AS 'Approved',"
        SQL &= "    FORMAT(COUNT(CASE WHEN CI_Status = 'DISAPPROVED' THEN ID END),0) AS 'Disapproved'"
        SQL &= String.Format(" FROM credit_application WHERE `status` = 'ACTIVE' AND application_status = 'APPROVED' AND Released BETWEEN '{2}' AND '{3}' AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(FromDate, "yyyy-MM-dd"), Format(ToDate, "yyyy-MM-dd"))
        Dim DT_Details As DataTable = DataSource(SQL)

        If DT_Details.Rows.Count > 0 Then
            lblStatusN1.Text = FormatNumber(DT_Details(0)("Pending"), 0)
            lblStatusP1.Text = FormatNumber((DT_Details(0)("Pending") / pBookings.Text) * 100, 2) & " %"

            lblStatusN2.Text = FormatNumber(DT_Details(0)("Approved"), 0)
            lblStatusP2.Text = FormatNumber((DT_Details(0)("Approved") / pBookings.Text) * 100, 2) & " %"

            lblStatusN3.Text = FormatNumber(DT_Details(0)("Disapproved"), 0)
            lblStatusP3.Text = FormatNumber((DT_Details(0)("Disapproved") / pBookings.Text) * 100, 2) & " %"
        Else
            lblStatusN1.Text = "0"
            lblStatusN1.Text = "0.00 %"

            lblStatusN2.Text = "0"
            lblStatusN2.Text = "0.00 %"

            lblStatusN3.Text = "0"
            lblStatusN3.Text = "0.00 %"
        End If
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Dim SQL As String = ""
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT "
            SQL &= "     FORMAT(IFNULL(SUM(A.M01B),0),2) AS 'Jan',"
            SQL &= "     FORMAT(IFNULL(SUM(A.M02B),0),2) AS 'Feb',"
            SQL &= "     FORMAT(IFNULL(SUM(A.M03B),0),2) AS 'Mar',"
            SQL &= "     FORMAT(IFNULL(SUM(A.M04B),0),2) AS 'Apr',"
            SQL &= "     FORMAT(IFNULL(SUM(A.M05B),0),2) AS 'May',"
            SQL &= "     FORMAT(IFNULL(SUM(A.M06B),0),2) AS 'Jun',"
            SQL &= "     FORMAT(IFNULL(SUM(B.M01B),0),2) AS 'Jul',"
            SQL &= "     FORMAT(IFNULL(SUM(B.M02B),0),2) AS 'Aug',"
            SQL &= "     FORMAT(IFNULL(SUM(B.M03B),0),2) AS 'Sep',"
            SQL &= "     FORMAT(IFNULL(SUM(B.M04B),0),2) AS 'Oct',"
            SQL &= "     FORMAT(IFNULL(SUM(B.M05B),0),2) AS 'Nov',"
            SQL &= "     FORMAT(IFNULL(SUM(B.M06B),0),2) AS 'Dec'"
            SQL &= String.Format(" FROM target_booking A LEFT JOIN target_booking B ON A.BranchID = B.BranchID AND A.`Year` = B.`Year` AND A.`ProductID` = B.ProductID AND B.Half = 2 AND B.`status` = 'ACTIVE' AND B.FP_Status = 'APPROVED' AND FIND_IN_SET(B.BranchID,'{2}') AND B.`Year` = YEAR('{1}') WHERE A.`status` = 'ACTIVE' AND A.FP_Status = 'APPROVED' AND A.Half = 1 AND FIND_IN_SET(A.BranchID,'{2}') AND A.`Year` = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= " UNION"
            SQL &= " SELECT "
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 1 THEN AmountApplied END) / IFNULL(A.Jan,1)),0),2) AS 'Jan',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 2 THEN AmountApplied END) / IFNULL(A.Feb,1)),0),2) AS 'Feb',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 3 THEN AmountApplied END) / IFNULL(A.Mar,1)),0),2) AS 'Mar',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 4 THEN AmountApplied END) / IFNULL(A.Apr,1)),0),2) AS 'Apr',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 5 THEN AmountApplied END) / IFNULL(A.May,1)),0),2) AS 'May',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 6 THEN AmountApplied END) / IFNULL(A.Jun,1)),0),2) AS 'Jun',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 7 THEN AmountApplied END) / IFNULL(B.Jul,1)),0),2) AS 'Jul',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 8 THEN AmountApplied END) / IFNULL(B.Aug,1)),0),2) AS 'Aug',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 9 THEN AmountApplied END) / IFNULL(B.Sep,1)),0),2) AS 'Sep',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 10 THEN AmountApplied END) / IFNULL(B.Oct,1)),0),2) AS 'Oct',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 11 THEN AmountApplied END) / IFNULL(B.Nov,1)),0),2) AS 'Nov',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(Released) = 12 THEN AmountApplied END) / IFNULL(B.Dec,1)),0),2) AS 'Dec'"
            SQL &= " FROM credit_application "
            SQL &= String.Format(" LEFT JOIN (SELECT BranchID, SUM(M01B) AS 'Jan', SUM(M02B) AS 'Feb', SUM(M03B) AS 'Mar', SUM(M04B) AS 'Apr', SUM(M05B) AS 'May', SUM(M06B) AS 'Jun' FROM target_booking WHERE `status` = 'ACTIVE' AND FP_Status = 'APPROVED' AND Half = 1 AND BranchID IN ({2}) AND `Year` = YEAR('{1}')) A ON A.BranchID = Branch_ID", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= String.Format(" LEFT JOIN (SELECT BranchID, SUM(M01B) AS 'Jul', SUM(M02B) AS 'Aug', SUM(M03B) AS 'Sep', SUM(M04B) AS 'Oct', SUM(M05B) AS 'Nov', SUM(M06B) AS 'Dec' FROM target_booking WHERE `status` = 'ACTIVE' AND FP_Status = 'APPROVED' AND Half = 2 AND BranchID IN ({2}) AND `Year` = YEAR('{1}')) B ON B.BranchID = Branch_ID", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND application_status = 'APPROVED' AND PaymentRequest IN ('RELEASED','CLOSED') AND Branch_ID IN ({2}) AND YEAR(Released) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        Dim MonthlyRopoa As DataTable = DataSource(SQL)

        ' Create a line chart
        With Chart
            .GetSeriesByName("Target").Points.Clear()
            .GetSeriesByName("Actual").Points.Clear()
        End With
        Try
            If MonthlyRopoa.Rows.Count > 1 Then
                For x As Integer = 0 To MonthlyRopoa.Columns.Count - 1
                    TotalTarget += MonthlyRopoa(0)(x)
                    With Chart
                        .GetSeriesByName("Target").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(0)(x)))
                        .GetSeriesByName("Actual").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(1)(x)))
                    End With
                Next
            End If
        Catch ex As Exception
            TriggerBugReport("Booking Dashboard - LineChart", ex.Message.ToString)
        End Try
    End Sub

    Private Sub FrmITLDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmBookingDashboard_Load(sender, e)
        ElseIf e.Control And e.KeyCode = Keys.X Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnChangeView_Click(sender As Object, e As EventArgs) Handles btnChangeView.Click
        Dim Change As New FrmChangeView
        With Change
            .dtpFrom.Value = FromDate
            .dtpTo.Value = ToDate
            If .ShowDialog = DialogResult.OK Then
                Display = .cbxDisplay.Text
                FromDate = .dtpFrom.Value
                ToDate = .dtpTo.Value
                LineChart(Chart1)
                LoadData()
            End If
            .Dispose()
        End With
    End Sub
End Class