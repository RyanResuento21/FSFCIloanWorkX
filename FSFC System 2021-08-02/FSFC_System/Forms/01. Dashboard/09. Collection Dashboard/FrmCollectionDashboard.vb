Imports DevExpress.XtraCharts
Public Class FrmCollectionDashboard

    Dim FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date = Date.Now
    Public ToDate As Date = Date.Now
    Dim TotalUncollected As Integer
    Private Sub FrmCollectionDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        With Chart1
            .Location = New Point(12, 421)
            .Size = New Point(1140, 266)
        End With

        FirstLoad = True

        Cursor = Cursors.WaitCursor
        LoadData()
        LineChart(Chart1)
        Cursor = Cursors.Default

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX1, LabelX34, LabelX12, LabelX29, lblProduct1, lblProduct_N1, lblProduct_PN1, lblProduct_PA1, lblProduct2, lblProduct_N2, lblProduct_PN2, lblProduct_PA2, lblProduct3, lblProduct_N3, lblProduct_PN3, lblProduct_PA3, lblProduct4, lblProduct_N4, lblProduct_PN4, lblProduct_PA4, lblProduct5, lblProduct_N5, lblProduct_PN5, lblProduct_PA5, lblProduct6, lblProduct_N6, lblProduct_PN6, lblProduct_PA6, lblProduct7, lblProduct_N7, lblProduct_PN7, lblProduct_PA7, lblProduct8, lblProduct_N8, lblProduct_PN8, lblProduct_PA8, lblProduct9, lblProduct_N9, lblProduct_PN9, lblProduct_PA9, lblProduct10, lblProduct_N10, lblProduct_PN10, lblProduct_PA10, lblProduct11, lblProduct_N11, lblProduct_PN11, lblProduct_PA11})

            GetLabelWithBackgroundFontSettings({LabelX30})

            GetButtonFontSettings({btnChangeView})

            GetGroupControlFontSettings({GroupControl1})

            GetChartTitleControlFontSettings({Chart1})
        Catch ex As Exception
            TriggerBugReport("Collection Dashboard", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            Dim SQL As String = "SELECT "
            SQL &= "    Product AS 'Product',"
            SQL &= "    COUNT(DISTINCT ID) AS 'Number',"
            If CompanyMode = 0 Then
                SQL &= "    SUM((AmountApplied + Interest) - A.Amount) AS 'Balance'"
            Else
                SQL &= "    SUM((Face_Amount) - A.Amount) AS 'Balance'"
            End If
            SQL &= String.Format(" FROM credit_application LEFT JOIN (SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('Principal', 'UDI') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Amount', ReferenceN FROM accounting_entry WHERE `status` = 'ACTIVE' AND ReferenceN LIKE 'CA%' AND PaidFor IN ('Principal', 'UDI')  GROUP BY ReferenceN) A ON A.ReferenceN = credit_application.CreditNumber WHERE `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED')  AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
            If CompanyMode = 0 Then
                SQL &= " AND IFNULL((SELECT LoansReceivable FROM credit_schedule WHERE CreditNumber = credit_application.CreditNumber AND IF(DueDate = '','2100-01-01',DATE(DueDate)) <= DATE(NOW()) AND `status` = 'ACTIVE' ORDER BY DueDate DESC LIMIT 1),0) > A.Amount GROUP BY Product ORDER BY `Number` DESC;"
            Else
                SQL &= " AND IFNULL((SELECT LoansReceivable FROM credit_schedule WHERE CreditNumber = credit_application.CreditNumber AND IF(DueDate = '','2100-01-01',DATE(DueDate)) <= DATE(NOW()) AND `status` = 'ACTIVE' ORDER BY DueDate DESC LIMIT 1),0) > A.Amount GROUP BY Product ORDER BY `Number` DESC;"
            End If

            Dim DT_Product As DataTable = DataSource(SQL)
            TotalUncollected = 0
            Dim TotalUncollectedAmount As Double
            For x As Integer = 0 To DT_Product.Rows.Count - 1
                TotalUncollected += DT_Product(x)("Number")
                TotalUncollectedAmount += DT_Product(x)("Balance")
            Next
            If DT_Product.Rows.Count > 0 Then
                lblProduct1.Text = "1. " & DT_Product(0)("Product")
                lblProduct_N1.Text = FormatNumber(DT_Product(0)("Number"), 0)
                lblProduct_PN1.Text = FormatNumber((DT_Product(0)("Number") / TotalUncollected) * 100, 2) & " %"
                lblProduct_PA1.Text = FormatNumber((DT_Product(0)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"

                If DT_Product.Rows.Count > 2 - 1 Then
                    lblProduct2.Text = "2. " & DT_Product(2 - 1)("Product")
                    lblProduct_N2.Text = FormatNumber(DT_Product(2 - 1)("Number"), 0)
                    lblProduct_PN2.Text = FormatNumber((DT_Product(2 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA2.Text = FormatNumber((DT_Product(2 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct2.Text = "2. "
                    lblProduct_N2.Text = "0"
                    lblProduct_PN2.Text = "0.00 %"
                    lblProduct_PA2.Text = "0.00 %"
                End If

                If DT_Product.Rows.Count > 3 - 1 Then
                    lblProduct3.Text = "3. " & DT_Product(3 - 1)("Product")
                    lblProduct_N3.Text = FormatNumber(DT_Product(3 - 1)("Number"), 0)
                    lblProduct_PN3.Text = FormatNumber((DT_Product(3 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA3.Text = FormatNumber((DT_Product(3 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct3.Text = "3. "
                    lblProduct_N3.Text = "0"
                    lblProduct_PN3.Text = "0.00 %"
                    lblProduct_PA3.Text = "0.00 %"
                End If

                If DT_Product.Rows.Count > 4 - 1 Then
                    lblProduct4.Text = "4. " & DT_Product(4 - 1)("Product")
                    lblProduct_N4.Text = FormatNumber(DT_Product(4 - 1)("Number"), 0)
                    lblProduct_PN4.Text = FormatNumber((DT_Product(4 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA4.Text = FormatNumber((DT_Product(4 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct4.Text = "4. "
                    lblProduct_N4.Text = "0"
                    lblProduct_PN4.Text = "0.00 %"
                    lblProduct_PA4.Text = "0.00 %"
                End If

                If DT_Product.Rows.Count > 5 - 1 Then
                    lblProduct5.Text = "5. " & DT_Product(5 - 1)("Product")
                    lblProduct_N5.Text = FormatNumber(DT_Product(5 - 1)("Number"), 0)
                    lblProduct_PN5.Text = FormatNumber((DT_Product(5 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA5.Text = FormatNumber((DT_Product(5 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct5.Text = "5. "
                    lblProduct_N5.Text = "0"
                    lblProduct_PN5.Text = "0.00 %"
                    lblProduct_PA5.Text = "0.00 %"
                End If

                If DT_Product.Rows.Count > 6 - 1 Then
                    lblProduct6.Text = "6. " & DT_Product(6 - 1)("Product")
                    lblProduct_N6.Text = FormatNumber(DT_Product(6 - 1)("Number"), 0)
                    lblProduct_PN6.Text = FormatNumber((DT_Product(6 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA6.Text = FormatNumber((DT_Product(6 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct6.Text = "6. "
                    lblProduct_N6.Text = "0"
                    lblProduct_PN6.Text = "0.00 %"
                    lblProduct_PA6.Text = "0.00 %"
                End If

                If DT_Product.Rows.Count > 7 - 1 Then
                    lblProduct7.Text = "7. " & DT_Product(7 - 1)("Product")
                    lblProduct_N7.Text = FormatNumber(DT_Product(7 - 1)("Number"), 0)
                    lblProduct_PN7.Text = FormatNumber((DT_Product(7 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA7.Text = FormatNumber((DT_Product(7 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct7.Text = "7. "
                    lblProduct_N7.Text = "0"
                    lblProduct_PN7.Text = "0.00 %"
                    lblProduct_PA7.Text = "0.00 %"
                End If

                If DT_Product.Rows.Count > 8 - 1 Then
                    lblProduct8.Text = "8. " & DT_Product(8 - 1)("Product")
                    lblProduct_N8.Text = FormatNumber(DT_Product(8 - 1)("Number"), 0)
                    lblProduct_PN8.Text = FormatNumber((DT_Product(8 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA8.Text = FormatNumber((DT_Product(8 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct8.Text = "8. "
                    lblProduct_N8.Text = "0"
                    lblProduct_PN8.Text = "0.00 %"
                    lblProduct_PA8.Text = "0.00 %"
                End If

                If DT_Product.Rows.Count > 9 - 1 Then
                    lblProduct9.Text = "9. " & DT_Product(9 - 1)("Product")
                    lblProduct_N9.Text = FormatNumber(DT_Product(9 - 1)("Number"), 0)
                    lblProduct_PN9.Text = FormatNumber((DT_Product(9 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA9.Text = FormatNumber((DT_Product(9 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct9.Text = "9. "
                    lblProduct_N9.Text = "0"
                    lblProduct_PN9.Text = "0.00 %"
                    lblProduct_PA9.Text = "0.00 %"
                End If

                If DT_Product.Rows.Count > 10 - 1 Then
                    lblProduct10.Text = "10. " & DT_Product(10 - 1)("Product")
                    lblProduct_N10.Text = FormatNumber(DT_Product(10 - 1)("Number"), 0)
                    lblProduct_PN10.Text = FormatNumber((DT_Product(10 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA10.Text = FormatNumber((DT_Product(10 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct10.Text = "10. "
                    lblProduct_N10.Text = "0"
                    lblProduct_PN10.Text = "0.00 %"
                    lblProduct_PA10.Text = "0.00 %"
                End If

                If DT_Product.Rows.Count > 11 - 1 Then
                    lblProduct11.Text = "10. " & DT_Product(11 - 1)("Product")
                    lblProduct_N11.Text = FormatNumber(DT_Product(11 - 1)("Number"), 0)
                    lblProduct_PN11.Text = FormatNumber((DT_Product(11 - 1)("Number") / TotalUncollected) * 100, 2) & " %"
                    lblProduct_PA11.Text = FormatNumber((DT_Product(11 - 1)("Balance") / TotalUncollectedAmount) * 100, 2) & " %"
                Else
                    lblProduct11.Text = "11. "
                    lblProduct_N11.Text = "0"
                    lblProduct_PN11.Text = "0.00 %"
                    lblProduct_PA11.Text = "0.00 %"
                End If
            Else
                lblProduct1.Text = "1. "
                lblProduct_N1.Text = "0"
                lblProduct_PN1.Text = "0.00 %"
                lblProduct_PA1.Text = "0.00 %"

                lblProduct2.Text = "2. "
                lblProduct_N2.Text = "0"
                lblProduct_PN2.Text = "0.00 %"
                lblProduct_PA2.Text = "0.00 %"

                lblProduct3.Text = "3. "
                lblProduct_N3.Text = "0"
                lblProduct_PN3.Text = "0.00 %"
                lblProduct_PA3.Text = "0.00 %"

                lblProduct4.Text = "4. "
                lblProduct_N4.Text = "0"
                lblProduct_PN4.Text = "0.00 %"
                lblProduct_PA4.Text = "0.00 %"

                lblProduct5.Text = "5. "
                lblProduct_N5.Text = "0"
                lblProduct_PN5.Text = "0.00 %"
                lblProduct_PA5.Text = "0.00 %"

                lblProduct6.Text = "6. "
                lblProduct_N6.Text = "0"
                lblProduct_PN6.Text = "0.00 %"
                lblProduct_PA6.Text = "0.00 %"

                lblProduct7.Text = "7. "
                lblProduct_N7.Text = "0"
                lblProduct_PN7.Text = "0.00 %"
                lblProduct_PA7.Text = "0.00 %"

                lblProduct8.Text = "8. "
                lblProduct_N8.Text = "0"
                lblProduct_PN8.Text = "0.00 %"
                lblProduct_PA8.Text = "0.00 %"

                lblProduct9.Text = "9. "
                lblProduct_N9.Text = "0"
                lblProduct_PN9.Text = "0.00 %"
                lblProduct_PA9.Text = "0.00 %"

                lblProduct10.Text = "10. "
                lblProduct_N10.Text = "0"
                lblProduct_PN10.Text = "0.00 %"
                lblProduct_PA10.Text = "0.00 %"

                lblProduct11.Text = "11. "
                lblProduct_N11.Text = "0"
                lblProduct_PN11.Text = "0.00 %"
                lblProduct_PA11.Text = "0.00 %"
            End If

            SQL = "SELECT "
            SQL &= "    ID,"
            SQL &= "    IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)) AS 'Account Name',"
            SQL &= "    CONCAT(IF(CompromiseAgreement > 0,'CA',''),IF(PaymentArrangement > 0,'PA',''), IF(AccountNumber = '',CreditNumber,AccountNumber)) AS 'Account Number',"
            If CompanyMode = 0 Then
                SQL &= "    (AmountApplied + Interest) - A.Amount AS 'Balance To Date',"
            Else
                SQL &= "    (Face_Amount) - A.Amount AS 'Balance To Date',"
            End If
            SQL &= "    iF(LENGTH(Mobile_B) = 10,CONCAT(0,Mobile_B),Mobile_B) AS 'Contact Number' "
            SQL &= String.Format(" FROM credit_application LEFT JOIN (SELECT IFNULL(SUM(CASE WHEN PaidFor IN ('Principal', 'UDI') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Amount', ReferenceN FROM accounting_entry WHERE `status` = 'ACTIVE' GROUP BY ReferenceN) A ON A.ReferenceN = credit_application.CreditNumber WHERE `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED')  AND Branch_ID IN ({1})", Branch_ID, If(Multiple_ID = "", Branch_ID, Multiple_ID))
            If CompanyMode = 0 Then
                SQL &= " AND IFNULL((SELECT LoansReceivable FROM credit_schedule WHERE CreditNumber = credit_application.CreditNumber AND IF(DueDate = '','2100-01-01',DATE(DueDate)) <= DATE(NOW()) AND `status` = 'ACTIVE' ORDER BY DueDate DESC LIMIT 1),0) > A.Amount ORDER BY `Balance To Date` DESC"
            Else
                SQL &= " AND IFNULL((SELECT LoansReceivable FROM credit_schedule WHERE CreditNumber = credit_application.CreditNumber AND IF(DueDate = '','2100-01-01',DATE(DueDate)) <= DATE(NOW()) AND `status` = 'ACTIVE' ORDER BY DueDate DESC LIMIT 1),0) > A.Amount ORDER BY `Balance To Date` DESC"
            End If
            GridControl1.DataSource = DataSource(SQL)
            If GridView1.RowCount > 15 Then
                GridColumn2.Width = 305 - 17
            Else
                GridColumn2.Width = 305
            End If
        Catch ex As Exception
            TriggerBugReport("Collection Dashboard", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Dim SQL As String = ""
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT "
            SQL &= "     FORMAT(100,2) AS 'Jan',"
            SQL &= "     FORMAT(100,2) AS 'Feb',"
            SQL &= "     FORMAT(100,2) AS 'Mar',"
            SQL &= "     FORMAT(100,2) AS 'Apr',"
            SQL &= "     FORMAT(100,2) AS 'May',"
            SQL &= "     FORMAT(100,2) AS 'Jun',"
            SQL &= "     FORMAT(100,2) AS 'Jul',"
            SQL &= "     FORMAT(100,2) AS 'Aug',"
            SQL &= "     FORMAT(100,2) AS 'Sep',"
            SQL &= "     FORMAT(100,2) AS 'Oct',"
            SQL &= "     FORMAT(100,2) AS 'Nov',"
            SQL &= "     FORMAT(100,2) AS 'Dec'"
            SQL &= " UNION"
            SQL &= " SELECT "
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 1 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 1 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Jan',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 2 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 2 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Feb',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 3 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 3 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Mar',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 4 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 4 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Apr',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 5 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 5 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'May',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 6 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 6 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Jun',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 7 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 7 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Jul',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 8 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 8 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Aug',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 9 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 9 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Sep',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 10 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 10 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Oct',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 11 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 11 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Nov',"
            SQL &= "     FORMAT(IFNULL((SUM(CASE WHEN MONTH(PostingDate) = 12 THEN Paid END) / IFNULL((CASE WHEN MONTH(DueDate) = 12 THEN SUM(A.Amount) END),0)) * 100,0),2) AS 'Dec'"
            SQL &= " FROM official_receipt "
            SQL &= String.Format(" LEFT JOIN (SELECT CreditNumber, DueDate, (PrincipalAllocation + InterestIncome) AS 'Amount' FROM credit_schedule WHERE `status` = 'ACTIVE' AND DueDate != '' AND YEAR(DueDate) = YEAR('{1}')) A ON TRUE", Branch_ID, Format(FromDate, "yyyy-MM-dd"))
            SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND Branch_ID IN ({2}) AND YEAR(PostingDate) = YEAR('{1}')", Branch_ID, Format(FromDate, "yyyy-MM-dd"), If(Multiple_ID = "", Branch_ID, Multiple_ID))
        End If
        Dim MonthlyRopoa As DataTable = DataSource(SQL)

        ' Create a line chart
        With Chart
            .GetSeriesByName("Target").Points.Clear()
            .GetSeriesByName("Actual").Points.Clear()
            Try
                For x As Integer = 0 To MonthlyRopoa.Columns.Count - 1
                    .GetSeriesByName("Target").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(0)(x)))
                    .GetSeriesByName("Actual").Points.Add(New SeriesPoint(MonthlyRopoa.Columns(x).Caption, MonthlyRopoa(1)(x)))
                Next
            Catch ex As Exception
                TriggerBugReport("Collection Dashboard - LineChart", ex.Message.ToString)
            End Try
        End With
    End Sub

    Private Sub FrmITLDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmCollectionDashboard_Load(sender, e)
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
            .cbxDisplay.Enabled = False
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