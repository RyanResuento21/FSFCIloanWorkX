Imports DevExpress.XtraCharts
Public Class FrmCreditDashboard

    Dim FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date = Date.Now
    Public ToDate As Date = Date.Now
    Private TotalApplication As Integer

    Private Sub FrmCreditDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        Chart1.Location = New Point(12, 421)
        Chart1.Size = New Point(1140, 266)

        FirstLoad = True

        LoadData()
        If AutoRefreshData Then
            Timer_Refresh.Interval = AutoRefreshTime * 1000
            Timer_Refresh.Start()
        End If

        FirstLoad = False
    End Sub

    Private Sub Timer_Refresh_Tick(sender As Object, e As EventArgs) Handles Timer_Refresh.Tick
        LoadData()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX1, LabelX34, LabelX12, lblProduct1, lblProduct_N1, lblProduct_P1, lblProduct2, lblProduct_N2, lblProduct_P2, lblProduct3, lblProduct_N3, lblProduct_P3, lblProduct4, lblProduct_N4, lblProduct_P4, lblProduct5, lblProduct_N5, lblProduct_P5, lblProduct6, lblProduct_N6, lblProduct_P6, lblProduct7, lblProduct_N7, lblProduct_P7, lblProduct8, lblProduct_N8, lblProduct_P8, lblProduct9, lblProduct_N9, lblProduct_P9, lblProduct10, lblProduct_N10, lblProduct_P10, lblProduct11, lblProduct_N11, lblProduct_P11, LabelX62, LabelX61, lblMonth1, lblMonthN1, lblMonthP1, lblMonth2, lblMonthN2, lblMonthP2, lblMonth3, lblMonthN3, lblMonthP3, lblMonth4, lblMonthN4, lblMonthP4, lblMonth5, lblMonthN5, lblMonthP5, LabelX37, LabelX21, LabelX33, lblMarketing1, lblMarketingN1, lblMarketingP1, lblMarketing2, lblMarketingN2, lblMarketingP2, lblMarketing3, lblMarketingN3, lblMarketingP3, lblMarketing4, lblMarketingN4, lblMarketingP4, lblMarketing5, lblMarketingN5, lblMarketingP5, LabelX46, LabelX45, lblTerms1, lblTermsN1, lblTermsP1, lblTerms2, lblTermsN2, lblTermsP2, lblTerms3, lblTermsN3, lblTermsP3, LabelX30, LabelX29, lblStatusN1, lblStatusP1, lblStatusN2, lblStatusP2, lblStatusN3, lblStatusP3})

            GetLabelFontSettingsDefault({LabelX26, LabelX32, LabelX31})

            GetLabelFontSettingsDashboardTitle({LabelX87})

            GetButtonFontSettings({btnChangeView})

            GetLabelFontSettingsDashboardPanel({pMonthlyApplications})

            GetGroupControlFontSettings({GroupControl1, GroupControl3, GroupControl4, GroupControl2, gCivilStatus})

            GetChartTitleControlFontSettings({Chart1})
        Catch ex As Exception
            TriggerBugReport("Credit Dashboard - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        Dim DT_Product As DataTable
        Dim DT_Months As DataTable
        Dim DT_Marketing As DataTable
        Dim DT_Details As DataTable
        TotalApplication = DataObject(String.Format("SELECT COUNT(DISTINCT ID) FROM credit_application WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        Dim SQL As String
        SQL = String.Format("SELECT * FROM (SELECT (SELECT Product FROM product_setup WHERE ID = Product_ID) AS 'Product', COUNT(DISTINCT ID) AS 'Number' FROM credit_application WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1}) GROUP BY `Product` ORDER BY `Number` DESC) A GROUP BY `Product`;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))

        DT_Product = DataSource(SQL)
        If DT_Product.Rows.Count > 0 Then
            lblProduct1.Text = "1. " & DT_Product(0)("Product")
            lblProduct_N1.Text = FormatNumber(DT_Product(0)("Number"), 0)
            lblProduct_P1.Text = FormatNumber((DT_Product(0)("Number") / TotalApplication) * 100, 2) & " %"

            If DT_Product.Rows.Count > 2 - 1 Then
                lblProduct2.Text = "2. " & DT_Product(2 - 1)("Product")
                lblProduct_N2.Text = FormatNumber(DT_Product(2 - 1)("Number"), 0)
                lblProduct_P2.Text = FormatNumber((DT_Product(2 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct2.Text = "2. "
                lblProduct_N2.Text = "0"
                lblProduct_P2.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 3 - 1 Then
                lblProduct3.Text = "3. " & DT_Product(3 - 1)("Product")
                lblProduct_N3.Text = FormatNumber(DT_Product(3 - 1)("Number"), 0)
                lblProduct_P3.Text = FormatNumber((DT_Product(3 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct3.Text = "3. "
                lblProduct_N3.Text = "0"
                lblProduct_P3.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 4 - 1 Then
                lblProduct4.Text = "4. " & DT_Product(4 - 1)("Product")
                lblProduct_N4.Text = FormatNumber(DT_Product(4 - 1)("Number"), 0)
                lblProduct_P4.Text = FormatNumber((DT_Product(4 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct4.Text = "4. "
                lblProduct_N4.Text = "0"
                lblProduct_P4.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 5 - 1 Then
                lblProduct5.Text = "5. " & DT_Product(5 - 1)("Product")
                lblProduct_N5.Text = FormatNumber(DT_Product(5 - 1)("Number"), 0)
                lblProduct_P5.Text = FormatNumber((DT_Product(5 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct5.Text = "5. "
                lblProduct_N5.Text = "0"
                lblProduct_P5.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 6 - 1 Then
                lblProduct6.Text = "6. " & DT_Product(6 - 1)("Product")
                lblProduct_N6.Text = FormatNumber(DT_Product(6 - 1)("Number"), 0)
                lblProduct_P6.Text = FormatNumber((DT_Product(6 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct6.Text = "6. "
                lblProduct_N6.Text = "0"
                lblProduct_P6.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 7 - 1 Then
                lblProduct7.Text = "7. " & DT_Product(7 - 1)("Product")
                lblProduct_N7.Text = FormatNumber(DT_Product(7 - 1)("Number"), 0)
                lblProduct_P7.Text = FormatNumber((DT_Product(7 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct7.Text = "7. "
                lblProduct_N7.Text = "0"
                lblProduct_P7.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 8 - 1 Then
                lblProduct8.Text = "8. " & DT_Product(8 - 1)("Product")
                lblProduct_N8.Text = FormatNumber(DT_Product(8 - 1)("Number"), 0)
                lblProduct_P8.Text = FormatNumber((DT_Product(8 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct8.Text = "8. "
                lblProduct_N8.Text = "0"
                lblProduct_P8.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 9 - 1 Then
                lblProduct9.Text = "9. " & DT_Product(9 - 1)("Product")
                lblProduct_N9.Text = FormatNumber(DT_Product(9 - 1)("Number"), 0)
                lblProduct_P9.Text = FormatNumber((DT_Product(9 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct9.Text = "9. "
                lblProduct_N9.Text = "0"
                lblProduct_P9.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 10 - 1 Then
                lblProduct10.Text = "10. " & DT_Product(10 - 1)("Product")
                lblProduct_N10.Text = FormatNumber(DT_Product(10 - 1)("Number"), 0)
                lblProduct_P10.Text = FormatNumber((DT_Product(10 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct10.Text = "10. "
                lblProduct_N10.Text = "0"
                lblProduct_P10.Text = "0.00 %"
            End If

            If DT_Product.Rows.Count > 11 - 1 Then
                lblProduct11.Text = "10. " & DT_Product(11 - 1)("Product")
                lblProduct_N11.Text = FormatNumber(DT_Product(11 - 1)("Number"), 0)
                lblProduct_P11.Text = FormatNumber((DT_Product(11 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblProduct11.Text = "11. "
                lblProduct_N11.Text = "0"
                lblProduct_P11.Text = "0.00 %"
            End If
        Else
            lblProduct1.Text = "1. "
            lblProduct_N1.Text = "0"
            lblProduct_P1.Text = "0.00 %"

            lblProduct2.Text = "2. "
            lblProduct_N2.Text = "0"
            lblProduct_P2.Text = "0.00 %"

            lblProduct3.Text = "3. "
            lblProduct_N3.Text = "0"
            lblProduct_P3.Text = "0.00 %"

            lblProduct4.Text = "4. "
            lblProduct_N4.Text = "0"
            lblProduct_P4.Text = "0.00 %"

            lblProduct5.Text = "5. "
            lblProduct_N5.Text = "0"
            lblProduct_P5.Text = "0.00 %"

            lblProduct6.Text = "6. "
            lblProduct_N6.Text = "0"
            lblProduct_P6.Text = "0.00 %"

            lblProduct7.Text = "7. "
            lblProduct_N7.Text = "0"
            lblProduct_P7.Text = "0.00 %"

            lblProduct8.Text = "8. "
            lblProduct_N8.Text = "0"
            lblProduct_P8.Text = "0.00 %"

            lblProduct9.Text = "9. "
            lblProduct_N9.Text = "0"
            lblProduct_P9.Text = "0.00 %"

            lblProduct10.Text = "10. "
            lblProduct_N10.Text = "0"
            lblProduct_P10.Text = "0.00 %"

            lblProduct11.Text = "11. "
            lblProduct_N11.Text = "0"
            lblProduct_P11.Text = "0.00 %"
        End If

        SQL = String.Format("SELECT DATE_FORMAT(Trans_Date,'%M') AS 'Months', COUNT(DISTINCT ID) AS 'Number' FROM credit_application WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1}) GROUP BY MONTH(Trans_Date) ORDER BY `Number` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        DT_Months = DataSource(SQL)
        If DT_Months.Rows.Count > 0 Then
            lblMonth1.Text = "1. " & DT_Months(0)("Months")
            lblMonthN1.Text = FormatNumber(DT_Months(0)("Number"), 0)
            lblMonthP1.Text = FormatNumber((DT_Months(0)("Number") / TotalApplication) * 100, 2) & " %"

            If DT_Months.Rows.Count > 2 - 1 Then
                lblMonth2.Text = "2. " & DT_Months(2 - 1)("Months")
                lblMonthN2.Text = FormatNumber(DT_Months(2 - 1)("Number"), 0)
                lblMonthP2.Text = FormatNumber((DT_Months(2 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblMonth2.Text = "2. "
                lblMonthN2.Text = "0"
                lblMonthP2.Text = "0.00 %"
            End If

            If DT_Months.Rows.Count > 3 - 1 Then
                lblMonth3.Text = "3. " & DT_Months(3 - 1)("Months")
                lblMonthN3.Text = FormatNumber(DT_Months(3 - 1)("Number"), 0)
                lblMonthP3.Text = FormatNumber((DT_Months(3 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblMonth3.Text = "3. "
                lblMonthN3.Text = "0"
                lblMonthP3.Text = "0.00 %"
            End If

            If DT_Months.Rows.Count > 4 - 1 Then
                lblMonth4.Text = "4. " & DT_Months(4 - 1)("Months")
                lblMonthN4.Text = FormatNumber(DT_Months(4 - 1)("Number"), 0)
                lblMonthP4.Text = FormatNumber((DT_Months(4 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblMonth4.Text = "4. "
                lblMonthN4.Text = "0"
                lblMonthP4.Text = "0.00 %"
            End If

            If DT_Months.Rows.Count > 5 - 1 Then
                lblMonth5.Text = "5. " & DT_Months(5 - 1)("Months")
                lblMonthN5.Text = FormatNumber(DT_Months(5 - 1)("Number"), 0)
                lblMonthP5.Text = FormatNumber((DT_Months(5 - 1)("Number") / TotalApplication) * 100, 2) & " %"
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

        SQL = String.Format("SELECT IF(Marketing = '','* No Marketing *',Marketing) AS 'Marketing', COUNT(DISTINCT ID) AS 'Number' FROM credit_application WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1}) GROUP BY MarketingID ORDER BY `Number` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        DT_Marketing = DataSource(SQL)
        If DT_Marketing.Rows.Count > 0 Then
            lblMarketing1.Text = "1. " & UpperCaseFirst(DT_Marketing(0)("Marketing"))
            lblMarketingN1.Text = FormatNumber(DT_Marketing(0)("Number"), 0)
            lblMarketingP1.Text = FormatNumber((DT_Marketing(0)("Number") / TotalApplication) * 100, 2) & " %"

            If DT_Marketing.Rows.Count > 2 - 1 Then
                lblMarketing2.Text = "2. " & UpperCaseFirst(DT_Marketing(2 - 1)("Marketing"))
                lblMarketingN2.Text = FormatNumber(DT_Marketing(2 - 1)("Number"), 0)
                lblMarketingP2.Text = FormatNumber((DT_Marketing(2 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblMarketing2.Text = "2. "
                lblMarketingN2.Text = "0"
                lblMarketingP2.Text = "0.00 %"
            End If

            If DT_Marketing.Rows.Count > 3 - 1 Then
                lblMarketing3.Text = "3. " & UpperCaseFirst(DT_Marketing(3 - 1)("Marketing"))
                lblMarketingN3.Text = FormatNumber(DT_Marketing(3 - 1)("Number"), 0)
                lblMarketingP3.Text = FormatNumber((DT_Marketing(3 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblMarketing3.Text = "3. "
                lblMarketingN3.Text = "0"
                lblMarketingP3.Text = "0.00 %"
            End If

            If DT_Marketing.Rows.Count > 4 - 1 Then
                lblMarketing4.Text = "4. " & UpperCaseFirst(DT_Marketing(4 - 1)("Marketing"))
                lblMarketingN4.Text = FormatNumber(DT_Marketing(4 - 1)("Number"), 0)
                lblMarketingP4.Text = FormatNumber((DT_Marketing(4 - 1)("Number") / TotalApplication) * 100, 2) & " %"
            Else
                lblMarketing4.Text = "4. "
                lblMarketingN4.Text = "0"
                lblMarketingP4.Text = "0.00 %"
            End If

            If DT_Marketing.Rows.Count > 5 - 1 Then
                lblMarketing5.Text = "5. " & UpperCaseFirst(DT_Marketing(5 - 1)("Marketing"))
                lblMarketingN5.Text = FormatNumber(DT_Marketing(5 - 1)("Number"), 0)
                lblMarketingP5.Text = FormatNumber((DT_Marketing(5 - 1)("Number") / TotalApplication) * 100, 2) & " %"
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
        SQL &= "    FORMAT(COUNT(CASE WHEN application_status = 'PENDING' THEN ID END),0) AS 'Pending',"
        SQL &= "    FORMAT(COUNT(CASE WHEN application_status = 'APPROVED' THEN ID END),0) AS 'Approved',"
        SQL &= "    FORMAT(COUNT(CASE WHEN application_status = 'DISAPPROVED' THEN ID END),0) AS 'Disapproved',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Terms BETWEEN 1 AND 12 THEN ID END),0) AS 'Terms1_12',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Terms BETWEEN 13 AND 24 THEN ID END),0) AS 'Terms13_24',"
        SQL &= "    FORMAT(COUNT(CASE WHEN Terms > 24 THEN ID END),0) AS 'Terms24Up',"
        SQL &= "    IFNULL(PERIOD_DIFF(DATE_FORMAT(NOW(),'%Y%m'),DATE_FORMAT(MIN(Trans_Date),'%Y%m')),0) AS 'Months'"
        SQL &= String.Format(" FROM credit_application WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        DT_Details = DataSource(SQL)
        pMonthlyApplications.Text = FormatNumber((TotalApplication / CInt(DT_Details(0)("Months"))), 0)
        If DT_Details.Rows.Count > 0 Then
            lblTermsN1.Text = FormatNumber(DT_Details(0)("Terms1_12"), 0)
            lblTermsP1.Text = FormatNumber((DT_Details(0)("Terms1_12") / TotalApplication) * 100, 2) & " %"

            lblTermsN2.Text = FormatNumber(DT_Details(0)("Terms13_24"), 0)
            lblTermsP2.Text = FormatNumber((DT_Details(0)("Terms13_24") / TotalApplication) * 100, 2) & " %"

            lblTermsN3.Text = FormatNumber(DT_Details(0)("Terms24Up"), 0)
            lblTermsP3.Text = FormatNumber((DT_Details(0)("Terms24Up") / TotalApplication) * 100, 2) & " %"

            lblStatusN1.Text = FormatNumber(DT_Details(0)("Pending"), 0)
            lblStatusP1.Text = FormatNumber((DT_Details(0)("Pending") / TotalApplication) * 100, 2) & " %"

            lblStatusN2.Text = FormatNumber(DT_Details(0)("Approved"), 0)
            lblStatusP2.Text = FormatNumber((DT_Details(0)("Approved") / TotalApplication) * 100, 2) & " %"

            lblStatusN3.Text = FormatNumber(DT_Details(0)("Disapproved"), 0)
            lblStatusP3.Text = FormatNumber((DT_Details(0)("Disapproved") / TotalApplication) * 100, 2) & " %"
        Else
            lblTermsN1.Text = "0"
            lblTermsP1.Text = "0.00 %"

            lblTermsN2.Text = "0"
            lblTermsP2.Text = "0.00 %"

            lblTermsN3.Text = "0"
            lblTermsP3.Text = "0.00 %"

            lblStatusN1.Text = "0"
            lblStatusN1.Text = "0.00 %"

            lblStatusN2.Text = "0"
            lblStatusN2.Text = "0.00 %"

            lblStatusN3.Text = "0"
            lblStatusN3.Text = "0.00 %"
        End If
        LineChart(Chart1)
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
            SQL &= " FROM credit_application"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND application_status = 'PENDING' AND Branch_ID IN ({2}) AND YEAR(Trans_Date) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
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
            SQL &= " FROM credit_application"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND application_status = 'APPROVED' AND Branch_ID IN ({2}) AND YEAR(Trans_Date) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
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
            SQL &= " FROM credit_application"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND application_status = 'DISAPPROVED' AND Branch_ID IN ({2}) AND YEAR(Trans_Date) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
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
            SQL &= " FROM credit_application"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND application_status = 'PENDING' AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= " UNION"

            SQL &= " SELECT"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM credit_application"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND application_status = 'APPROVED' AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))

            SQL &= " UNION"

            SQL &= " SELECT"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM credit_application"
            SQL &= String.Format(" WHERE `status` IN ('ACTIVE','HOLD','CANCELLED') AND application_status = 'DISAPPROVED' AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        Dim MonthlyApplication As DataTable = DataSource(SQL)

        ' Create a line chart
        With Chart
            .GetSeriesByName("Pending").Points.Clear()
            .GetSeriesByName("Approved").Points.Clear()
            .GetSeriesByName("Disapproved").Points.Clear()
            Try
                For x As Integer = 1 To MonthlyApplication.Columns.Count - 1
                    .GetSeriesByName("Pending").Points.Add(New SeriesPoint(MonthlyApplication.Columns(x).Caption, MonthlyApplication(0)(x)))
                    .GetSeriesByName("Approved").Points.Add(New SeriesPoint(MonthlyApplication.Columns(x).Caption, MonthlyApplication(1)(x)))
                    .GetSeriesByName("Disapproved").Points.Add(New SeriesPoint(MonthlyApplication.Columns(x).Caption, MonthlyApplication(2)(x)))
                Next
            Catch ex As Exception
                TriggerBugReport("Credit Dashboard - LineChart", ex.Message.ToString)
            End Try
        End With
    End Sub

    Private Sub FrmCreditDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmCreditDashboard_Load(sender, e)
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
            If .ShowDialog = DialogResult.OK Then
                Display = .cbxDisplay.Text
                FromDate = .dtpFrom.Value
                ToDate = .dtpTo.Value
                LineChart(Chart1)
            End If
            .Dispose()
        End With
    End Sub
End Class