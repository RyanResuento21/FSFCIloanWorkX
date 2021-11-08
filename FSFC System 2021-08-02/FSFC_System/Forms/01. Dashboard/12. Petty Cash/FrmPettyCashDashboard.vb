Imports DevExpress.XtraCharts
Public Class FrmPettyCashDashboard
    Dim FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date = Date.Now
    Public ToDate As Date = Date.Now
    Public TotalPettyCash As Integer

    Dim SupplierCount As Integer
    Dim EmployeeCount As Integer
    Dim LiquidationCount As Integer
    Dim PettyCashNumberCount As Integer
    Dim PettyCashTotalAmount As Double

    Private Sub FrmPettyCashDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        With c1
            .Size = New Point(371, 328)
            .Location = New Point(781, 14)
        End With
        With PettyChartPerMonth1
            .Size = New Point(565, 134)
            .Location = New Point(11, 567)
        End With
        With PettyChartPerMonth2
            .Size = New Point(565, 134)
            .Location = New Point(587, 567)
        End With

        FirstLoad = True

        SupplierCount = DataObject(String.Format("CALL PCD_SupplierCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        EmployeeCount = DataObject(String.Format("CALL PCD_EmployeeCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        LiquidationCount = DataObject(String.Format("CALL PCD_LiquidationCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        PettyCashNumberCount = DataObject(String.Format("CALL PCD_PettyCashNumberCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        PettyCashTotalAmount = DataObject(String.Format("CALL PCD_PettyCashAmountCount('{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        lblBranch1N.Text = FormatNumber(EmployeeCount, 0)
        lblBranch2N.Text = FormatNumber(SupplierCount, 0)
        lblBranch3N.Text = FormatNumber(LiquidationCount, 0)
        pAveragePerMonth.Text = DataObject(String.Format("SELECT FORMAT(IFNULL(SUM(Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6 + Amount_7 + Amount_8 + Amount_9 + Amount_10 + Amount_11 + Amount_12),0),2) AS 'Amount' FROM petty_cash WHERE `status` = 'ACTIVE' AND FIND_IN_SET(branch_id, '{0}');", If(Multiple_ID = "", Branch_ID, Multiple_ID)))

        PieChart(c1)
        LineChart1(PettyChartPerMonth1)
        LineChart2(PettyChartPerMonth2)
        PettyCashData()
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({lblNonLiquidatedN, lblNonLiquidatedP, lblLiquidatedN, lblLiquidatedP, lblMonth1, lblMonth2, lblMonth3, lblMonth4, lblMonth5, lblMonthN1, lblMonthN2, lblMonthN3, lblMonthN4, lblMonthN5, lblMonthP1, lblMonthP2, lblMonthP3, lblMonthP4, lblMonthP5, LabelX1, LabelX10, lblSupplier5, lblBranch1, lblBranch2, lblSupplier5P, lblSupplier5N, lblSupplier4, lblSupplier4P, lblSupplier3P, lblSupplier4N, LabelX2, lblSupplier3N, lblEmployee5, lblDepartment5P, lblDepartment5N, lblEmployee4, lblDepartment4P, lblDepartment3P, lblDepartment4N, lblDepartment3N, lblEmployee3, LabelX3, lblEmployee2, lblDepartment2P, lblDepartment1P, lblDepartment2N, lblDepartment1N, LabelX35, LabelX36, lblBranch4, lblBranch4P, lblBranch3P, LabelX4, lblBranch4N, lblBranch3N, lblBranch3, lblBranch5, lblBranch5P, lblBranch5N, lblSupplier3, lblSupplier2, lblSupplier2P, lblSupplier1P, lblBranch2P, lblSupplier2N, lblSupplier1N, LabelX52, LabelX53, lblSupplier1, lblEmployee1, lblDepartment5, lblEmployee5P, lblEmployee5N, lblDepartment4, lblBranch1P, lblEmployee4P, LabelX61, LabelX62, lblEmployee3P, lblEmployee4N, lblEmployee3N, lblDepartment3, lblDepartment2, lblEmployee1P, lblEmployee2P, lblBranch2N, lblEmployee2N, lblEmployee1N, LabelX72, LabelX73, lblDepartment1, lblBranch1N, LabelX9})

            GetButtonFontSettings({btnChangeView1, btnChangeView2})

            GetLabelFontSettingsDashboardTitle({LabelX155})

            GetLabelFontSettingsDashboardPanel({pAveragePerMonth})

            GetGroupControlFontSettings({gPettyBranch, gPettyCashStatus, gPettyDepartment, gPettyEmployee, gPettySupplier, gTopPettyMonths})

            GetChartTitleControlFontSettings({c1, PettyChartPerMonth1, PettyChartPerMonth2})
        Catch ex As Exception
            TriggerBugReport("Petty Cash Dashboard - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Public Sub PettyCashData()
        Dim Non_Liquidation As Integer
        TotalPettyCash = DataObject(String.Format("SELECT COUNT(DISTINCT ID) FROM petty_cash WHERE `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        'Top 5 Months with the most Petty Cash
        Dim SQL As String = String.Format("SELECT DATE_FORMAT(Trans_Date,'%M') AS 'Months', COUNT(DISTINCT ID) AS 'Number' FROM petty_cash WHERE `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID IN ({1}) GROUP BY MONTH(Trans_Date) ORDER BY `Number` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim PT_Months As DataTable = DataSource(SQL)
        If PT_Months.Rows.Count > 0 Then
            lblMonth1.Text = "1. " & PT_Months(0)("Months")
            lblMonthN1.Text = FormatNumber(PT_Months(0)("Number"), 0)
            lblMonthP1.Text = FormatNumber((PT_Months(0)("Number") / TotalPettyCash) * 100, 2) & " %"

            If PT_Months.Rows.Count > 2 - 1 Then
                lblMonth2.Text = "2. " & PT_Months(2 - 1)("Months")
                lblMonthN2.Text = FormatNumber(PT_Months(2 - 1)("Number"), 0)
                lblMonthP2.Text = FormatNumber((PT_Months(2 - 1)("Number") / TotalPettyCash) * 100, 2) & " %"
            Else
                lblMonth2.Text = "2. "
                lblMonthN2.Text = "0"
                lblMonthP2.Text = "0.00 %"
            End If

            If PT_Months.Rows.Count > 3 - 1 Then
                lblMonth3.Text = "3. " & PT_Months(3 - 1)("Months")
                lblMonthN3.Text = FormatNumber(PT_Months(3 - 1)("Number"), 0)
                lblMonthP3.Text = FormatNumber((PT_Months(3 - 1)("Number") / TotalPettyCash) * 100, 2) & " %"
            Else
                lblMonth3.Text = "3. "
                lblMonthN3.Text = "0"
                lblMonthP3.Text = "0.00 %"
            End If

            If PT_Months.Rows.Count > 4 - 1 Then
                lblMonth4.Text = "4. " & PT_Months(4 - 1)("Months")
                lblMonthN4.Text = FormatNumber(PT_Months(4 - 1)("Number"), 0)
                lblMonthP4.Text = FormatNumber((PT_Months(4 - 1)("Number") / TotalPettyCash) * 100, 2) & " %"
            Else
                lblMonth4.Text = "4. "
                lblMonthN4.Text = "0"
                lblMonthP4.Text = "0.00 %"
            End If

            If PT_Months.Rows.Count > 5 - 1 Then
                lblMonth5.Text = "5. " & PT_Months(5 - 1)("Months")
                lblMonthN5.Text = FormatNumber(PT_Months(5 - 1)("Number"), 0)
                lblMonthP5.Text = FormatNumber((PT_Months(5 - 1)("Number") / TotalPettyCash) * 100, 2) & " %"
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

        'Petty Cash Liquidation and Non Liquidation Count
        SQL = String.Format("SELECT COUNT(DISTINCT ID) AS 'Number' FROM petty_cash WHERE payee_type = 'C' AND `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID IN ({1});", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim PT_Liquidation As DataTable = DataSource(SQL)
        If PT_Liquidation.Rows.Count > 0 Then
            lblLiquidatedN.Text = FormatNumber(PT_Liquidation(0)("Number"), 0)
            lblLiquidatedP.Text = FormatNumber((PT_Liquidation(0)("Number") / TotalPettyCash) * 100, 2) & " %"
            Non_Liquidation = FormatNumber(TotalPettyCash - (PT_Liquidation(0)("Number")), 0)
            lblNonLiquidatedN.Text = Non_Liquidation
            lblNonLiquidatedP.Text = FormatNumber((Non_Liquidation / TotalPettyCash) * 100, 2) & " %"
        Else
            lblLiquidatedN.Text = "0"
            lblLiquidatedP.Text = "0.00 %"
            lblNonLiquidatedN.Text = "0"
            lblNonLiquidatedP.Text = "0.00 %"
        End If

        'TOP 5 Employee petty cash user
        SQL = String.Format("SELECT payee AS 'Payee Name', COUNT(DISTINCT ID) AS 'Number', SUM(Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6 + Amount_7 + Amount_8 + Amount_9 + Amount_10 + Amount_11 + Amount_12) AS 'Total Amount' FROM petty_cash WHERE payee_type = 'E' AND `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID IN ({1}) GROUP BY payee ORDER BY `Total Amount` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim PT_EmployeeMonths As DataTable = DataSource(SQL)
        If PT_EmployeeMonths.Rows.Count > 0 Then
            lblEmployee1.Text = "1. " & PT_EmployeeMonths(0)("Payee Name")
            lblEmployee1N.Text = FormatNumber(PT_EmployeeMonths(0)("Number"), 0)
            lblEmployee1P.Text = FormatNumber(PT_EmployeeMonths(0)("Total Amount"), 2)

            If PT_EmployeeMonths.Rows.Count > 2 - 1 Then
                lblEmployee2.Text = "2. " & PT_EmployeeMonths(2 - 1)("Payee Name")
                lblEmployee2N.Text = FormatNumber(PT_EmployeeMonths(2 - 1)("Number"), 0)
                lblEmployee2P.Text = FormatNumber(PT_EmployeeMonths(2 - 1)("Total Amount"), 2)
            Else
                lblEmployee2.Text = "2. "
                lblEmployee2N.Text = "0"
                lblEmployee2P.Text = "0.00 "
            End If

            If PT_EmployeeMonths.Rows.Count > 3 - 1 Then
                lblEmployee3.Text = "3. " & PT_EmployeeMonths(3 - 1)("Payee Name")
                lblEmployee3N.Text = FormatNumber(PT_EmployeeMonths(3 - 1)("Number"), 0)
                lblEmployee3P.Text = FormatNumber(PT_EmployeeMonths(3 - 1)("Total Amount"), 2)
            Else
                lblEmployee3.Text = "3. "
                lblEmployee3N.Text = "0"
                lblEmployee3P.Text = "0.00 "
            End If

            If PT_EmployeeMonths.Rows.Count > 4 - 1 Then
                lblEmployee4.Text = "4. " & PT_EmployeeMonths(4 - 1)("Payee Name")
                lblEmployee4N.Text = FormatNumber(PT_EmployeeMonths(4 - 1)("Number"), 0)
                lblEmployee4P.Text = FormatNumber(PT_EmployeeMonths(4 - 1)("Total Amount"), 2)
            Else
                lblEmployee4.Text = "4. "
                lblEmployee4N.Text = "0"
                lblEmployee4P.Text = "0.00 "
            End If

            If PT_EmployeeMonths.Rows.Count > 5 - 1 Then
                lblEmployee5.Text = "5. " & PT_EmployeeMonths(5 - 1)("Payee Name")
                lblEmployee5N.Text = FormatNumber(PT_EmployeeMonths(5 - 1)("Number"), 0)
                lblEmployee5P.Text = FormatNumber(PT_EmployeeMonths(5 - 1)("Total Amount"), 2)
            Else
                lblEmployee5.Text = "5. "
                lblEmployee5N.Text = "0"
                lblEmployee5P.Text = "0.00 "
            End If
        Else
            lblEmployee1.Text = "1. "
            lblEmployee1N.Text = "0"
            lblEmployee1P.Text = "0.00 "

            lblEmployee2.Text = "2. "
            lblEmployee2N.Text = "0"
            lblEmployee2P.Text = "0.00 "

            lblEmployee3.Text = "3. "
            lblEmployee3N.Text = "0"
            lblEmployee3P.Text = "0.00 "

            lblEmployee4.Text = "4. "
            lblEmployee4N.Text = "0"
            lblEmployee4P.Text = "0.00 "

            lblEmployee5.Text = "5. "
            lblEmployee5N.Text = "0"
            lblEmployee5P.Text = "0.00 "
        End If

        'Top 5 Supplier petty cash user
        SQL = String.Format("SELECT payee AS 'Payee Name', COUNT(DISTINCT ID) AS 'Number' , SUM(Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6 + Amount_7 + Amount_8 + Amount_9 + Amount_10 + Amount_11 + Amount_12) AS 'Total Amount' FROM petty_cash WHERE payee_type = 'S' AND `status` IN ('ACTIVE', 'CANCELLED') AND Branch_ID IN ({1}) GROUP BY payee ORDER BY `Total Amount` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim PT_SupplierMonths As DataTable = DataSource(SQL)
        If PT_SupplierMonths.Rows.Count > 0 Then
            lblSupplier1.Text = "1. " & PT_SupplierMonths(0)("Payee Name")
            lblSupplier1N.Text = FormatNumber(PT_SupplierMonths(0)("Number"), 0)
            lblSupplier1P.Text = FormatNumber(PT_SupplierMonths(0)("Total Amount"), 2)

            If PT_SupplierMonths.Rows.Count > 2 - 1 Then
                lblSupplier2.Text = "2. " & PT_SupplierMonths(2 - 1)("Payee Name")
                lblSupplier2N.Text = FormatNumber(PT_SupplierMonths(2 - 1)("Number"), 0)
                lblSupplier2P.Text = FormatNumber(PT_SupplierMonths(2 - 1)("Total Amount"), 2)
            Else
                lblSupplier2.Text = "2. "
                lblSupplier2N.Text = "0"
                lblSupplier2P.Text = "0.00 "
            End If

            If PT_SupplierMonths.Rows.Count > 3 - 1 Then
                lblSupplier3.Text = "3. " & PT_SupplierMonths(3 - 1)("Payee Name")
                lblSupplier3N.Text = FormatNumber(PT_SupplierMonths(3 - 1)("Number"), 0)
                lblSupplier3P.Text = FormatNumber(PT_SupplierMonths(3 - 1)("Total Amount"), 2)
            Else
                lblSupplier3.Text = "3. "
                lblSupplier3N.Text = "0"
                lblSupplier3P.Text = "0.00 "
            End If

            If PT_SupplierMonths.Rows.Count > 4 - 1 Then
                lblSupplier4.Text = "4. " & PT_SupplierMonths(4 - 1)("Payee Name")
                lblSupplier4N.Text = FormatNumber(PT_SupplierMonths(4 - 1)("Number"), 0)
                lblSupplier4P.Text = FormatNumber(PT_SupplierMonths(4 - 1)("Total Amount"), 2)
            Else
                lblSupplier4.Text = "4. "
                lblSupplier4N.Text = "0"
                lblSupplier4P.Text = "0.00 "
            End If

            If PT_SupplierMonths.Rows.Count > 5 - 1 Then
                lblSupplier5.Text = "5. " & PT_SupplierMonths(5 - 1)("Payee Name")
                lblSupplier5N.Text = FormatNumber(PT_SupplierMonths(5 - 1)("Number"), 0)
                lblSupplier5P.Text = FormatNumber(PT_SupplierMonths(5 - 1)("Total Amount"), 2)
            Else
                lblSupplier5.Text = "5. "
                lblSupplier5N.Text = "0"
                lblSupplier5P.Text = "0.00 "
            End If
        Else
            lblSupplier1.Text = "1. "
            lblSupplier1N.Text = "0"
            lblSupplier1P.Text = "0.00 "

            lblSupplier2.Text = "2. "
            lblSupplier2N.Text = "0"
            lblSupplier2P.Text = "0.00 "

            lblSupplier3.Text = "3. "
            lblSupplier3N.Text = "0"
            lblSupplier3P.Text = "0.00 "

            lblSupplier4.Text = "4. "
            lblSupplier4N.Text = "0"
            lblSupplier4P.Text = "0.00 "

            lblSupplier5.Text = "5. "
            lblSupplier5N.Text = "0"
            lblSupplier5P.Text = "0.00 "
        End If

        'Top 5 Branch petty cash user
        SQL = String.Format("SELECT b.`branch` AS 'Branch Name', COUNT(DISTINCT p.`ID`) AS 'Number', SUM(Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6 + Amount_7 + Amount_8 + Amount_9 + Amount_10 + Amount_11 + Amount_12) AS 'Total Amount' FROM petty_cash p INNER JOIN branch b ON p.`Branch_ID` = b.`branchID` WHERE p.`status` IN ('ACTIVE', 'CANCELLED') GROUP BY p.`Branch_ID` ORDER BY `Total Amount` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim PT_BranchMonths As DataTable = DataSource(SQL)
        If PT_BranchMonths.Rows.Count > 0 Then
            lblBranch1.Text = "1. " & PT_BranchMonths(0)("Branch Name")
            lblBranch1N.Text = FormatNumber(PT_BranchMonths(0)("Number"), 0)
            lblBranch1P.Text = FormatNumber(PT_BranchMonths(0)("Total Amount"), 2)

            If PT_BranchMonths.Rows.Count > 2 - 1 Then
                lblBranch2.Text = "2. " & PT_BranchMonths(2 - 1)("Branch Name")
                lblBranch2N.Text = FormatNumber(PT_BranchMonths(2 - 1)("Number"), 0)
                lblBranch2P.Text = FormatNumber(PT_BranchMonths(2 - 1)("Total Amount"), 2)
            Else
                lblBranch2.Text = "2. "
                lblBranch2N.Text = "0"
                lblBranch2P.Text = "0.00 "
            End If

            If PT_BranchMonths.Rows.Count > 3 - 1 Then
                lblBranch3.Text = "3. " & PT_BranchMonths(3 - 1)("Branch Name")
                lblBranch3N.Text = FormatNumber(PT_BranchMonths(3 - 1)("Number"), 0)
                lblBranch3P.Text = FormatNumber(PT_BranchMonths(3 - 1)("Total Amount"), 2)
            Else
                lblBranch3.Text = "3. "
                lblBranch3N.Text = "0"
                lblBranch3P.Text = "0.00 "
            End If

            If PT_BranchMonths.Rows.Count > 4 - 1 Then
                lblBranch4.Text = "4. " & PT_BranchMonths(4 - 1)("Branch Name")
                lblBranch4N.Text = FormatNumber(PT_BranchMonths(4 - 1)("Number"), 0)
                lblBranch4P.Text = FormatNumber(PT_BranchMonths(4 - 1)("Total Amount"), 2)
            Else
                lblBranch4.Text = "4. "
                lblBranch4N.Text = "0"
                lblBranch4P.Text = "0.00 "
            End If

            If PT_BranchMonths.Rows.Count > 5 - 1 Then
                lblBranch5.Text = "5. " & PT_BranchMonths(5 - 1)("Branch Name")
                lblBranch5N.Text = FormatNumber(PT_BranchMonths(5 - 1)("Number"), 0)
                lblBranch5P.Text = FormatNumber(PT_BranchMonths(5 - 1)("Total Amount"), 2)
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

        'Top 5 Department petty cash user
        SQL = String.Format("SELECT d.`department` AS 'Department Name', COUNT(DISTINCT p.`ID`) AS 'Number', SUM(Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6 + Amount_7 + Amount_8 + Amount_9 + Amount_10 + Amount_11 + Amount_12) AS 'Total Amount' FROM petty_cash p INNER JOIN department_setup d ON p.`DepartmentCode_1` = d.`department_code` WHERE p.`status` IN ('ACTIVE', 'CANCELLED') GROUP BY p.`DepartmentCode_1` ORDER BY `Total Amount` DESC;", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim PT_DepartmentMonths As DataTable = DataSource(SQL)
        If PT_DepartmentMonths.Rows.Count > 0 Then
            lblDepartment1.Text = "1. " & PT_DepartmentMonths(0)("Department Name")
            lblDepartment1N.Text = FormatNumber(PT_DepartmentMonths(0)("Number"), 0)
            lblDepartment1P.Text = FormatNumber(PT_DepartmentMonths(0)("Total Amount"), 2)

            If PT_DepartmentMonths.Rows.Count > 2 - 1 Then
                lblDepartment2.Text = "2. " & PT_DepartmentMonths(2 - 1)("Department Name")
                lblDepartment2N.Text = FormatNumber(PT_DepartmentMonths(2 - 1)("Number"), 0)
                lblDepartment2P.Text = FormatNumber(PT_DepartmentMonths(2 - 1)("Total Amount"), 2)
            Else
                lblDepartment2.Text = "2. "
                lblDepartment2N.Text = "0"
                lblDepartment2P.Text = "0.00 "
            End If

            If PT_DepartmentMonths.Rows.Count > 3 - 1 Then
                lblDepartment3.Text = "3. " & PT_DepartmentMonths(3 - 1)("Department Name")
                lblDepartment3N.Text = FormatNumber(PT_DepartmentMonths(3 - 1)("Number"), 0)
                lblDepartment3P.Text = FormatNumber(PT_DepartmentMonths(3 - 1)("Total Amount"), 2)
            Else
                lblDepartment3.Text = "3. "
                lblDepartment3N.Text = "0"
                lblDepartment3P.Text = "0.00 "
            End If

            If PT_DepartmentMonths.Rows.Count > 4 - 1 Then
                lblDepartment4.Text = "4. " & PT_DepartmentMonths(4 - 1)("Department Name")
                lblDepartment4N.Text = FormatNumber(PT_DepartmentMonths(4 - 1)("Number"), 0)
                lblDepartment4P.Text = FormatNumber(PT_DepartmentMonths(4 - 1)("Total Amount"), 2)
            Else
                lblDepartment4.Text = "4. "
                lblDepartment4N.Text = "0"
                lblDepartment4P.Text = "0.00 "
            End If

            If PT_DepartmentMonths.Rows.Count > 5 - 1 Then
                lblDepartment5.Text = "5. " & PT_DepartmentMonths(5 - 1)("Department Name")
                lblDepartment5N.Text = FormatNumber(PT_DepartmentMonths(5 - 1)("Number"), 0)
                lblDepartment5P.Text = FormatNumber(PT_DepartmentMonths(5 - 1)("Total Amount"), 2)
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
        Dim PettyCash As New DataTable
        'Additional column for pie
        With PettyCash
            .Columns.Add("Type")
            .Columns.Add("Value")
            .Rows.Add("Employee", EmployeeCount + LiquidationCount)
            .Rows.Add("Supplier", SupplierCount)
        End With

        Chart.Series.Clear()
        Try
            Dim Series1 As New Series("Payee Type", ViewType.Pie)

            For x As Integer = 0 To PettyCash.Rows.Count - 1
                Series1.Points.Add(New SeriesPoint(PettyCash(x)("Type"), PettyCash(x)("Value")))
            Next

            Chart.Series.Add(Series1)

            CType(Series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default
            With Series1
                .LegendTextPattern = "{A}"
                .Label.Font = New Font(OfficialFont, CSng(OfficialFontSize), .Label.Font.Style)
            End With

            Dim myView As PieSeriesView = CType(Series1.View, PieSeriesView)
        Catch ex As Exception
            TriggerBugReport("Petty Cash Dashboard - PieChart", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LineChart1(Chart As ChartControl)
        Dim SQL As String
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT "
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
            SQL &= " FROM petty_cash"
            SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND Branch_ID IN ({2}) AND YEAR(Trans_Date) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Else
            SQL = "SELECT"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    COUNT(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM petty_cash"
            SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))

        End If
        Dim PettyCashNumberMonthly As DataTable = DataSource(SQL)

        ' Create a line chart for number of petty cash per month
        With Chart
            .GetSeriesByName("PettyCashNumber").Points.Clear()
            Try
                For x As Integer = 1 To PettyCashNumberMonthly.Columns.Count - 1
                    .GetSeriesByName("PettyCashNumber").Points.Add(New SeriesPoint(PettyCashNumberMonthly.Columns(x).Caption, PettyCashNumberMonthly(0)(x)))
                Next
            Catch ex As Exception
                TriggerBugReport("Petty Cash Dashboard - LineChart1", ex.Message.ToString)
            End Try
        End With
    End Sub

    Private Sub LineChart2(Chart As ChartControl)
        Dim SQL As String
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT "
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 1 THEN ID END),0) AS 'Jan',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 2 THEN ID END),0) AS 'Feb',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 3 THEN ID END),0) AS 'Mar',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 4 THEN ID END),0) AS 'Apr',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 5 THEN ID END),0) AS 'May',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 6 THEN ID END),0) AS 'Jun',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 7 THEN ID END),0) AS 'Jul',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 8 THEN ID END),0) AS 'Aug',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 9 THEN ID END),0) AS 'Sep',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 10 THEN ID END),0) AS 'Oct',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 11 THEN ID END),0) AS 'Nov',"
            SQL &= "     COALESCE(SUM(CASE WHEN MONTH(Trans_Date) = 12 THEN ID END),0) AS 'Dec'"
            SQL &= " FROM petty_cash"
            SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND Branch_ID IN ({2}) AND YEAR(Trans_Date) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Else
            SQL = "SELECT"
            For x As Integer = 0 To DateDiff(DateInterval.Day, FromDate, ToDate)
                If x = DateDiff(DateInterval.Day, FromDate, ToDate) Then
                    SQL &= String.Format("    SUM(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}'", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                Else
                    SQL &= String.Format("    SUM(CASE WHEN DATE(Trans_Date) = DATE('{0}') THEN ID END) AS '{1}',", Format(FromDate.AddDays(x), "yyyy-MM-dd"), Format(FromDate.AddDays(x), "dd"))
                End If
            Next
            SQL &= " FROM petty_cash"
            SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        Dim PettyCashAmountMonthly As DataTable = DataSource(SQL)

        ' Create a line chart of amount of petty cash per month
        With Chart
            .GetSeriesByName("PettyCashAmount").Points.Clear()
            Try
                For x As Integer = 1 To PettyCashAmountMonthly.Columns.Count - 1
                    .GetSeriesByName("PettyCashAmount").Points.Add(New SeriesPoint(PettyCashAmountMonthly.Columns(x).Caption, PettyCashAmountMonthly(0)(x)))
                Next
            Catch ex As Exception
                TriggerBugReport("Petty Cash Dashboard - LineChart2", ex.Message.ToString)
            End Try
        End With
    End Sub

    Private Sub FrmPettyCashDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmPettyCashDashboard_Load(sender, e)
        ElseIf e.Control And e.KeyCode = Keys.X Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnChangeView1_Click(sender As Object, e As EventArgs) Handles btnChangeView1.Click
        Dim Change As New FrmChangeView
        With Change
            If .ShowDialog = DialogResult.OK Then
                Display = .cbxDisplay.Text
                FromDate = .dtpFrom.Value
                ToDate = .dtpTo.Value
                LineChart1(PettyChartPerMonth1)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnChangeView2_Click(sender As Object, e As EventArgs) Handles btnChangeView2.Click
        Dim Change As New FrmChangeView
        With Change
            If .ShowDialog = DialogResult.OK Then
                Display = .cbxDisplay.Text
                FromDate = .dtpFrom.Value
                ToDate = .dtpTo.Value
                LineChart2(PettyChartPerMonth2)
            End If
            .Dispose()
        End With
    End Sub
End Class