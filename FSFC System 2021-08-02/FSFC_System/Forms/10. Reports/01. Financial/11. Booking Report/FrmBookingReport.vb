Imports DevExpress.XtraReports.UI
Public Class FrmBookingReport

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT As DataTable
    Private Sub FrmBookingReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource(String.Format("SELECT ID, Branch FROM branch WHERE `status` = 'ACTIVE' AND ID IN ({0}) ORDER BY BranchID;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            .SelectedValue = Branch_ID
            If Branch_ID = 0 And MultipleBranch Then
            Else
                cbxAllB.Visible = False
                .Enabled = False
            End If
        End With

        DT = DataSource("SELECT '' AS 'No', '' AS 'Date', '' AS 'Borrower', '' AS 'Account Number', 0.0 AS 'Principal', 0.0 AS 'UDI', 0.0 AS 'RPPD', 0.0 AS 'Face Amount', '' AS 'Rate (Per Annum)', '' AS 'Terms', 0.0 AS 'Monthly Amortization', 0.0 AS 'Rebate', 0.0 AS 'Processing', 0.0 AS 'Interest', 0.0 AS 'Other Fee', 0.0 AS 'Service Charge', 0.0 AS 'Insurance', 0.0 AS 'Deduct Balance', 0.0 AS 'Advance Amortization', 0.0 AS 'Net Proceeds', '' AS 'Check Number', '' AS 'Collateral', '' AS 'Product Type', '' AS 'Loan Type', '' AS 'CI', '' AS 'AO', '' AS 'CreditNumber', '' AS 'Product' LIMIT 0")

        With cbxBusinessCenter
            .ValueMember = "ID"
            .DisplayMember = "BusinessCenter"
            .SelectedIndex = -1
        End With

        With cbxPreparedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedValue = Empl_ID
        End With

        With cbxVerifiedBy
            .DisplayMember = "Employee"
            .ValueMember = "ID"
            .DataSource = DT_Employees.Copy
            .SelectedIndex = -1
        End With

        With cbxBook
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            FirstLoad = False
            .DataSource = DataSource("SELECT 1 AS 'ID', 'Bank 1' AS 'Bank' UNION ALL SELECT 2 AS 'ID', 'Bank 2' AS 'Bank';")
        End With
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

            GetLabelFontSettings({LabelX1, LabelX4, LabelX40, LabelX42, LabelX41, LabelX5, LabelX3})

            GetLabelFontSettingsWithTopBorder({lblPosition, lblPositionVer})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank, cbxAll, cbxInclude})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank, cbxDisplay, cbxPreparedBy, cbxVerifiedBy})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})
        Catch ex As Exception
            TriggerBugReport("Booking Report - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Booking Report", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String
        If DT.Rows.Count > 0 Then
            DT.Rows.Clear()
        End If

        SQL = "SELECT "
        SQL &= "      DISTINCT(Product) AS 'Product',"
        SQL &= "      Product_ID"
        SQL &= " FROM credit_application C"
        SQL &= "      WHERE `status` = 'ACTIVE' AND Loan_Type IN ('NEW','RELOAN')"
        If cbxAll.Checked Then
        ElseIf cbxDisplay.SelectedIndex = 0 Or cbxDisplay.SelectedIndex = 2 Then
            SQL &= String.Format("    AND DATE(Released) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            SQL &= String.Format("    AND MONTH(DATE(Released)) = MONTH('{0}') AND YEAR(DATE(Released)) = YEAR('{0}')", FormatDatePicker(dtpFrom))
        End If
        SQL &= String.Format("    AND PaymentRequest IN ('RELEASED','CLOSED') AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'))", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        Dim DT_Products As DataTable = DataSource(SQL)

        Dim DT_Temp As DataTable
        For x As Integer = 0 To DT_Products.Rows.Count - 1
            Dim Principal_T As Double
            Dim UDI_T As Double
            Dim RPPD_T As Double
            Dim FaceAmount_T As Double
            Dim MonthlyAmortization_T As Double
            Dim Rebate_T As Double
            Dim Processing_T As Double
            Dim Interest_T As Double
            Dim OtherFee_T As Double
            Dim ServiceCharge_T As Double
            Dim Insurance_T As Double
            Dim DeductBalance_T As Double
            Dim AdvanceAmortization_T As Double
            Dim NetProceeds_T As Double
            DT.Rows.Add("", "", DT_Products(x)("Product"), "", 0, 0, 0, 0, "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, "", "", "", "", "", "")
            SQL = "SELECT "
            SQL &= "      0 AS 'No',"
            SQL &= "      DATE_FORMAT(Released, '%m/%d/%y') AS 'Date', "
            SQL &= "      Borrower(C.BorrowerID) AS 'Borrower', "
            SQL &= "      AccountNumber AS 'Account Number',"
            SQL &= "      C.AmountApplied AS 'Principal',"
            SQL &= "      C.Interest AS 'UDI',"
            SQL &= "      C.RPPD AS 'RPPD',"
            SQL &= "      C.Face_Amount AS 'Face Amount',"
            SQL &= "      CONCAT(C.Interest_Rate,'%') AS 'Rate (Per Annum)',"
            SQL &= "      C.Terms AS 'Terms',"
            SQL &= "      GMA AS 'Monthly Amortization',"
            SQL &= "      Rebate AS 'Rebate',"
            SQL &= "      (SELECT IFNULL(SUM(Amount),0) FROM credit_processing_fee WHERE credit_processing_fee.CreditNumber = C.CreditNumber AND `status` = 'ACTIVE') AS 'Processing',"
            SQL &= "      Miscellaneous_Income AS 'Interest',"
            SQL &= "      Appraisal_Fee + CI_Fee AS 'Other Fee',"
            SQL &= "      Service_Charge AS 'Service Charge',"
            SQL &= "      Insurance AS 'Insurance',"
            SQL &= "      Deduct_Balance AS 'Deduct Balance',"
            SQL &= "      Advance_Payment AS 'Advance Amortization',"
            SQL &= "      Net_Proceeds AS 'Net Proceeds',"
            SQL &= "      (SELECT GROUP_CONCAT(CheckNumber) FROM check_voucher WHERE Payee_ID = C.CreditNumber AND Payee_Type = 'C' AND `status` = 'ACTIVE' AND voucher_status = 'RECEIVED') AS 'Check Number',"
            SQL &= "      (SELECT GROUP_CONCAT(Collateral) FROM credit_investigation WHERE credit_investigation.CreditNumber = C.CreditNumber AND `status` = 'ACTIVE' LIMIT 1) AS 'Collateral',"
            SQL &= "      C.Product AS 'Product Type',"
            SQL &= "      Loan_Type AS 'Loan Type',"
            SQL &= "      CI,"
            SQL &= "      C.Marketing AS 'AO', CreditNumber, Product"
            SQL &= " FROM credit_application C"
            SQL &= "      WHERE `status` = 'ACTIVE' AND Loan_Type IN ('NEW','RELOAN')"
            If cbxAll.Checked Then
            ElseIf cbxDisplay.SelectedIndex = 0 Or cbxDisplay.SelectedIndex = 2 Then
                SQL &= String.Format("    AND DATE(Released) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            ElseIf cbxDisplay.SelectedIndex = 1 Then
                SQL &= String.Format("    AND MONTH(DATE(Released)) = MONTH('{0}') AND YEAR(DATE(Released)) = YEAR('{0}')", FormatDatePicker(dtpFrom))
            End If
            SQL &= String.Format("    AND PaymentRequest IN ('RELEASED','CLOSED') AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') AND Product_ID = '{4}' AND IF('{5}' = 'True',TRUE,IF('{6}' = 0,Book(BankID) = '{7}',BankID = '{6}'))", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, DT_Products(x)("Product_ID"), cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
            DT_Temp = DataSource(SQL)
            For y As Integer = 0 To DT_Temp.Rows.Count - 1
                DT.Rows.Add(DT_Temp(y)("No"), DT_Temp(y)("Date"), DT_Temp(y)("Borrower"), DT_Temp(y)("Account Number"), DT_Temp(y)("Principal"), DT_Temp(y)("UDI"), DT_Temp(y)("RPPD"), DT_Temp(y)("Face Amount"), DT_Temp(y)("Rate (Per Annum)"), DT_Temp(y)("Terms"), DT_Temp(y)("Monthly Amortization"), DT_Temp(y)("Rebate"), DT_Temp(y)("Processing"), DT_Temp(y)("Interest"), DT_Temp(y)("Other Fee"), DT_Temp(y)("Service Charge"), DT_Temp(y)("Insurance"), DT_Temp(y)("Deduct Balance"), DT_Temp(y)("Advance Amortization"), DT_Temp(y)("Net Proceeds"), DT_Temp(y)("Check Number"), DT_Temp(y)("Collateral"), DT_Temp(y)("Product Type"), DT_Temp(y)("Loan Type"), DT_Temp(y)("CI"), DT_Temp(y)("AO"), DT_Temp(y)("CreditNumber"), DT_Temp(y)("Product"))

                Principal_T += DT_Temp(y)("Principal")
                UDI_T += DT_Temp(y)("UDI")
                RPPD_T += DT_Temp(y)("RPPD")
                FaceAmount_T += DT_Temp(y)("Face Amount")
                MonthlyAmortization_T += DT_Temp(y)("Monthly Amortization")
                Rebate_T += DT_Temp(y)("Rebate")
                Processing_T += DT_Temp(y)("Processing")
                Interest_T += DT_Temp(y)("Interest")
                OtherFee_T += DT_Temp(y)("Other Fee")
                ServiceCharge_T += DT_Temp(y)("Service Charge")
                Insurance_T += DT_Temp(y)("Insurance")
                DeductBalance_T += DT_Temp(y)("Deduct Balance")
                AdvanceAmortization_T += DT_Temp(y)("Advance Amortization")
                NetProceeds_T += DT_Temp(y)("Net Proceeds")
            Next
            DT.Rows.Add("", "", "TOTAL " & DT_Products(x)("Product"), "", Principal_T, UDI_T, RPPD_T, FaceAmount_T, "", "", MonthlyAmortization_T, Rebate_T, Processing_T, Interest_T, OtherFee_T, ServiceCharge_T, Insurance_T, DeductBalance_T, AdvanceAmortization_T, NetProceeds_T, "", "", "", "", "", "", "", "")
        Next

        'THIS WEEK TOTAL
        SQL = " SELECT "
        SQL &= "      '' AS 'No',"
        SQL &= "      '' AS 'Date', "
        SQL &= "      '' AS 'Borrower', "
        If cbxAll.Checked Or cbxDisplay.SelectedIndex = 2 Then
            SQL &= "      'Grand Total' AS 'Account Number',"
        ElseIf cbxDisplay.SelectedIndex = 0 Then
            SQL &= "      'Total This Week' AS 'Account Number',"
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            SQL &= "      'Total This Month' AS 'Account Number',"
        End If
        SQL &= "      IFNULL(SUM(C.AmountApplied),0) AS 'Principal',"
        SQL &= "      IFNULL(SUM(C.Interest),0) AS 'UDI',"
        SQL &= "      IFNULL(SUM(C.RPPD),0) AS 'RPPD',"
        SQL &= "      IFNULL(SUM(C.Face_Amount),0) AS 'Face Amount',"
        SQL &= "      '' AS 'Rate (Per Annum)',"
        SQL &= "      '' AS 'Terms',"
        SQL &= "      IFNULL(SUM(GMA),0) AS 'Monthly Amortization',"
        SQL &= "      IFNULL(SUM(Rebate),0) AS 'Rebate',"
        SQL &= "      IFNULL(SUM((SELECT IFNULL(SUM(Amount),0) FROM credit_processing_fee WHERE credit_processing_fee.CreditNumber = C.CreditNumber AND `status` = 'ACTIVE')),0) AS 'Processing',"
        SQL &= "      IFNULL(SUM(Miscellaneous_Income),0) AS 'Interest',"
        SQL &= "      IFNULL(SUM(Appraisal_Fee) + SUM(CI_Fee),0) AS 'Other Fee',"
        SQL &= "      IFNULL(SUM(Service_Charge),0) AS 'Service Charge',"
        SQL &= "      IFNULL(SUM(Insurance),0) AS 'Insurance',"
        SQL &= "      IFNULL(SUM(Deduct_Balance),0) AS 'Deduct Balance',"
        SQL &= "      IFNULL(SUM(Advance_Payment),0) AS 'Advance Amortization',"
        SQL &= "      IFNULL(SUM(Net_Proceeds),0) AS 'Net Proceeds',"
        SQL &= "      '' AS 'Check Number',"
        SQL &= "      '' AS 'Collateral',"
        SQL &= "      '' AS 'Product Type',"
        SQL &= "      '' AS 'Loan Type',"
        SQL &= "      '' AS 'CI',"
        SQL &= "      '' AS 'AO'"
        SQL &= " FROM credit_application C"
        SQL &= "      WHERE `status` = 'ACTIVE'"
        If cbxAll.Checked Then
        ElseIf cbxDisplay.SelectedIndex = 0 Or cbxDisplay.SelectedIndex = 2 Then
            SQL &= String.Format("    AND DATE(Released) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            SQL &= String.Format("    AND MONTH(DATE(Released)) = MONTH('{0}') AND YEAR(DATE(Released)) = YEAR('{0}')", FormatDatePicker(dtpFrom))
        End If
        SQL &= String.Format("    AND PaymentRequest IN ('RELEASED','CLOSED') AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'))", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))

        If cbxInclude.Checked And cbxAll.Checked = False Then
            SQL &= "      UNION ALL"
            'PREVIOUS WEEK TOTAL
            SQL &= " SELECT "
            SQL &= "      '' AS 'No',"
            SQL &= "      '' AS 'Date', "
            SQL &= "      '' AS 'Borrower', "
            If cbxAll.Checked Then
                SQL &= "      '' AS 'Account Number',"
            ElseIf cbxDisplay.SelectedIndex = 0 Then
                SQL &= "      'Previous Week' AS 'Account Number',"
            ElseIf cbxDisplay.SelectedIndex = 1 Then
                SQL &= "      'Previous Month' AS 'Account Number',"
            End If
            SQL &= "      IFNULL(SUM(C.AmountApplied),0) AS 'Principal',"
            SQL &= "      IFNULL(SUM(C.Interest),0) AS 'UDI',"
            SQL &= "      IFNULL(SUM(C.RPPD),0) AS 'RPPD',"
            SQL &= "      IFNULL(SUM(C.Face_Amount),0) AS 'Face Amount',"
            SQL &= "      '' AS 'Rate (Per Annum)',"
            SQL &= "      '' AS 'Terms',"
            SQL &= "      IFNULL(SUM(GMA),0) AS 'Monthly Amortization',"
            SQL &= "      IFNULL(SUM(Rebate),0) AS 'Rebate',"
            SQL &= "      IFNULL(SUM((SELECT IFNULL(SUM(Amount),0) FROM credit_processing_fee WHERE credit_processing_fee.CreditNumber = C.CreditNumber AND `status` = 'ACTIVE')),0) AS 'Processing',"
            SQL &= "      IFNULL(SUM(Miscellaneous_Income),0) AS 'Interest',"
            SQL &= "      IFNULL(SUM(Appraisal_Fee) + SUM(CI_Fee),0) AS 'Other Fee',"
            SQL &= "      IFNULL(SUM(Service_Charge),0) AS 'Service Charge',"
            SQL &= "      IFNULL(SUM(Insurance),0) AS 'Insurance',"
            SQL &= "      IFNULL(SUM(Deduct_Balance),0) AS 'Deduct Balance',"
            SQL &= "      IFNULL(SUM(Advance_Payment),0) AS 'Advance Amortization',"
            SQL &= "      IFNULL(SUM(Net_Proceeds),0) AS 'Net Proceeds',"
            SQL &= "      '' AS 'Check Number',"
            SQL &= "      '' AS 'Collateral',"
            SQL &= "      '' AS 'Product Type',"
            SQL &= "      '' AS 'Loan Type',"
            SQL &= "      '' AS 'CI',"
            SQL &= "      '' AS 'AO'"
            SQL &= " FROM credit_application C"
            SQL &= "      WHERE `status` = 'ACTIVE'"
            If cbxAll.Checked Then
            ElseIf cbxDisplay.SelectedIndex = 0 Then
                SQL &= String.Format("    AND DATE(Released) BETWEEN '{0}' AND '{1}'", Format(dtpFrom.Value.AddDays(-7), "yyyy-MM-dd"), Format(dtpFrom.Value.AddDays(-1), "yyyy-MM-dd"))
            ElseIf cbxDisplay.SelectedIndex = 1 Then
                SQL &= String.Format("    AND MONTH(DATE(Released)) = MONTH('{0}') AND YEAR(DATE(Released)) = YEAR('{0}')", Format(dtpFrom.Value.AddMonths(-1), "yyyy-MM-dd"))
            End If
            SQL &= String.Format("    AND PaymentRequest IN ('RELEASED','CLOSED') AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'))", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))

            SQL &= "      UNION ALL"
            'GRAND TOTAL
            SQL &= " SELECT "
            SQL &= "      '' AS 'No',"
            SQL &= "      '' AS 'Date', "
            SQL &= "      '' AS 'Borrower', "
            SQL &= "      'Grand Total' AS 'Account Number',"
            SQL &= "      IFNULL(SUM(C.AmountApplied),0) AS 'Principal',"
            SQL &= "      IFNULL(SUM(C.Interest),0) AS 'UDI',"
            SQL &= "      IFNULL(SUM(C.RPPD),0) AS 'RPPD',"
            SQL &= "      IFNULL(SUM(C.Face_Amount),0) AS 'Face Amount',"
            SQL &= "      '' AS 'Rate (Per Annum)',"
            SQL &= "      '' AS 'Terms',"
            SQL &= "      IFNULL(SUM(GMA),0) AS 'Monthly Amortization',"
            SQL &= "      IFNULL(SUM(Rebate),0) AS 'Rebate',"
            SQL &= "      IFNULL(SUM((SELECT IFNULL(SUM(Amount),0) FROM credit_processing_fee WHERE credit_processing_fee.CreditNumber = C.CreditNumber AND `status` = 'ACTIVE')),0) AS 'Processing',"
            SQL &= "      IFNULL(SUM(Miscellaneous_Income),0) AS 'Interest',"
            SQL &= "      IFNULL(SUM(Appraisal_Fee) + SUM(CI_Fee),0) AS 'Other Fee',"
            SQL &= "      IFNULL(SUM(Service_Charge),0) AS 'Service Charge',"
            SQL &= "      IFNULL(SUM(Insurance),0) AS 'Insurance',"
            SQL &= "      IFNULL(SUM(Deduct_Balance),0) AS 'Deduct Balance',"
            SQL &= "      IFNULL(SUM(Advance_Payment),0) AS 'Advance Amortization',"
            SQL &= "      IFNULL(SUM(Net_Proceeds),0) AS 'Net Proceeds',"
            SQL &= "      '' AS 'Check Number',"
            SQL &= "      '' AS 'Collateral',"
            SQL &= "      '' AS 'Product Type',"
            SQL &= "      '' AS 'Loan Type',"
            SQL &= "      '' AS 'CI',"
            SQL &= "      '' AS 'AO'"
            SQL &= " FROM credit_application C"
            SQL &= "      WHERE `status` = 'ACTIVE'"
            If cbxAll.Checked Then
            ElseIf cbxDisplay.SelectedIndex = 0 Then
                SQL &= String.Format("    AND DATE(Released) BETWEEN '{0}' AND '{1}'", Format(dtpFrom.Value.AddDays(-7), "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))
            ElseIf cbxDisplay.SelectedIndex = 1 Then
                SQL &= String.Format("    AND DATE(Released) BETWEEN '{0}' AND '{1}'", Format(dtpFrom.Value.AddMonths(-1), "yyyy-MM-01"), Format(dtpFrom.Value, String.Format("yyyy-MM-{0}", DataObject(String.Format("SELECT DAY(LAST_DAY('{0}'))", Format(dtpFrom.Value, String.Format("yyyy-MM-dd")))))))
            End If
            SQL &= String.Format("    AND PaymentRequest IN ('RELEASED','CLOSED') AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'))", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))

        End If
        DT_Temp = DataSource(SQL)
        GridControl2.DataSource = DT.Copy
        For y As Integer = 0 To DT_Temp.Rows.Count - 1
            DT.Rows.Add(DT_Temp(y)("No"), DT_Temp(y)("Date"), DT_Temp(y)("Borrower"), DT_Temp(y)("Account Number"), DT_Temp(y)("Principal"), DT_Temp(y)("UDI"), DT_Temp(y)("RPPD"), DT_Temp(y)("Face Amount"), DT_Temp(y)("Rate (Per Annum)"), DT_Temp(y)("Terms"), DT_Temp(y)("Monthly Amortization"), DT_Temp(y)("Rebate"), DT_Temp(y)("Processing"), DT_Temp(y)("Interest"), DT_Temp(y)("Other Fee"), DT_Temp(y)("Service Charge"), DT_Temp(y)("Insurance"), DT_Temp(y)("Deduct Balance"), DT_Temp(y)("Advance Amortization"), DT_Temp(y)("Net Proceeds"), DT_Temp(y)("Check Number"), DT_Temp(y)("Collateral"), DT_Temp(y)("Product Type"), DT_Temp(y)("Loan Type"), DT_Temp(y)("CI"), DT_Temp(y)("AO"), "", "")
        Next

        GridControl1.DataSource = DT
        Dim i As Integer = 1
        For x As Integer = 1 To GridView2.RowCount
            If GridView2.GetRowCellValue(x - 1, "Account Number") = "" Then
            Else
                GridView2.SetRowCellValue(x - 1, "No", i)
                i += 1
            End If
        Next
        i = 1
        Dim MinusRow As Integer = 2
        If cbxInclude.Checked And cbxAll.Checked = False Then
            MinusRow += 1
        End If
        For x As Integer = 1 To GridView1.RowCount - MinusRow
            If GridView1.GetRowCellValue(x - 1, "Account Number") = "" Then
            Else
                GridView1.SetRowCellValue(x - 1, "No", i)
                i += 1
            End If
        Next
        GridView1.BestFitColumns()
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim Num As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("No"))
                If Num = "" Then
                    e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
                Else
                    e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Regular)
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptBookingReport
        With Report
            .Name = String.Format("Booking Report of {0}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text))
            If cbxAll.Checked Then
                .lblAsOf.Text = ""
            Else
                .lblAsOf.Text = "From " & dtpFrom.Text & " To " & dtpTo.Text
            End If

            .lblPreparedBy.Text = cbxPreparedBy.Text
            .lblPosition.Text = lblPosition.Text
            .lblVerifiedBy.Text = cbxVerifiedBy.Text
            .lblPositionVerified.Text = lblPositionVer.Text

            .DataSource = GridControl2.DataSource
            .lblNo.DataBindings.Add("Text", GridControl2.DataSource, "No")
            .lblDate.DataBindings.Add("Text", GridControl2.DataSource, "Date")
            .lblBorrower.DataBindings.Add("Text", GridControl2.DataSource, "Borrower")
            .lblAccountNumber.DataBindings.Add("Text", GridControl2.DataSource, "Account Number")
            .lblPrincipal.DataBindings.Add("Text", GridControl2.DataSource, "Principal")
            .lblUDI.DataBindings.Add("Text", GridControl2.DataSource, "UDI")
            .lblRPPD.DataBindings.Add("Text", GridControl2.DataSource, "RPPD")
            .lblFaceAmount.DataBindings.Add("Text", GridControl2.DataSource, "Face Amount")
            .lblRate.DataBindings.Add("Text", GridControl2.DataSource, "Rate (Per Annum)")
            .lblTerms.DataBindings.Add("Text", GridControl2.DataSource, "Terms")
            .lblMonthlyAmortization.DataBindings.Add("Text", GridControl2.DataSource, "Monthly Amortization")
            .lblRebate.DataBindings.Add("Text", GridControl2.DataSource, "Rebate")
            .lblProcessingFee.DataBindings.Add("Text", GridControl2.DataSource, "Processing")
            .lblInterest.DataBindings.Add("Text", GridControl2.DataSource, "Interest")
            .lblOtherFee.DataBindings.Add("Text", GridControl2.DataSource, "Other Fee")
            .lblServiceCharge.DataBindings.Add("Text", GridControl2.DataSource, "Service Charge")
            .lblInsurance.DataBindings.Add("Text", GridControl2.DataSource, "Insurance")
            .lblDeductBalance.DataBindings.Add("Text", GridControl2.DataSource, "Deduct Balance")
            .lblAdvanceAmortization.DataBindings.Add("Text", GridControl2.DataSource, "Advance Amortization")
            .lblNetProceeds.DataBindings.Add("Text", GridControl2.DataSource, "Net Proceeds")
            .lblCheckNumber.DataBindings.Add("Text", GridControl2.DataSource, "Check Number")
            .lblCollateral.DataBindings.Add("Text", GridControl2.DataSource, "Collateral")
            .lblProductType.DataBindings.Add("Text", GridControl2.DataSource, "Product Type")
            .lblLoanType.DataBindings.Add("Text", GridControl2.DataSource, "Loan Type")
            .lblCI.DataBindings.Add("Text", GridControl2.DataSource, "CI")
            .lblAO.DataBindings.Add("Text", GridControl2.DataSource, "AO")

            'TOTAL THIS WEEK
            If GridView1.RowCount > 0 Then
                Dim MinusRows As Integer = 1
                If cbxInclude.Checked And cbxAll.Checked = False Then
                    MinusRows += 2
                End If
                .lblAccountNumber_1.Text = GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Account Number")
                .lblPrincipal_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Principal"), 2)
                .lblUDI_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "UDI"), 2)
                .lblRPPD_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "RPPD"), 2)
                .lblFaceAmount_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Face Amount"), 2)
                .lblRate_1.Text = GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Rate (Per Annum)")
                .lblTerms_1.Text = GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Terms")
                .lblMonthlyAmortization_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Monthly Amortization"), 2)
                .lblRebate_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Rebate"), 2)
                .lblProcessingFee_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Processing"), 2)
                .lblInterest_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Interest"), 2)
                .lblOtherFee_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Other Fee"), 2)
                .lblServiceCharge_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Service Charge"), 2)
                .lblInsurance_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Insurance"), 2)
                .lblDeductBalance_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Deduct Balance"), 2)
                .lblAdvanceAmortization_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Advance Amortization"), 2)
                .lblNetProceeds_1.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Net Proceeds"), 2)

                MinusRows -= 1
                If MinusRows = 0 Then
                    GoTo Here
                End If
                'TOTAL PREVIOUS WEEK
                .lblAccountNumber_2.Text = GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Account Number")
                .lblPrincipal_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Principal"), 2)
                .lblUDI_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "UDI"), 2)
                .lblRPPD_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "RPPD"), 2)
                .lblFaceAmount_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Face Amount"), 2)
                .lblRate_2.Text = GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Rate (Per Annum)")
                .lblTerms_2.Text = GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Terms")
                .lblMonthlyAmortization_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Monthly Amortization"), 2)
                .lblRebate_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Rebate"), 2)
                .lblProcessingFee_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Processing"), 2)
                .lblInterest_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Interest"), 2)
                .lblOtherFee_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Other Fee"), 2)
                .lblServiceCharge_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Service Charge"), 2)
                .lblInsurance_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Insurance"), 2)
                .lblDeductBalance_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Deduct Balance"), 2)
                .lblAdvanceAmortization_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Advance Amortization"), 2)
                .lblNetProceeds_2.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Net Proceeds"), 2)

                MinusRows -= 1
                'GRAND TOTAL
                .lblAccountNumber_3.Text = GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Account Number")
                .lblPrincipal_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Principal"), 2)
                .lblUDI_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "UDI"), 2)
                .lblRPPD_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "RPPD"), 2)
                .lblFaceAmount_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Face Amount"), 2)
                .lblRate_3.Text = GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Rate (Per Annum)")
                .lblTerms_3.Text = GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Terms")
                .lblMonthlyAmortization_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Monthly Amortization"), 2)
                .lblRebate_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Rebate"), 2)
                .lblProcessingFee_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Processing"), 2)
                .lblInterest_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Interest"), 2)
                .lblOtherFee_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Other Fee"), 2)
                .lblServiceCharge_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Service Charge"), 2)
                .lblInsurance_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Insurance"), 2)
                .lblDeductBalance_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Deduct Balance"), 2)
                .lblAdvanceAmortization_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Advance Amortization"), 2)
                .lblNetProceeds_3.Text = FormatNumber(GridView1.GetRowCellValue(GridView1.RowCount - MinusRows, "Net Proceeds"), 2)
            End If
Here:
            Logs("Booking Report", "Print", "[SENSITIVE] Print Booking Report", "", "", "", "")
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub
    '***BUTTON CLICK

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
        End If
        If (cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "") And cbxAllB.Checked = False Then
            MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
            Exit Sub
        End If
        If cbxAll.Checked = False And cbxDisplay.SelectedIndex = -1 Then
            MsgBox("Please select a display format.", MsgBoxStyle.Information, "Info")
            cbxDisplay.DroppedDown = True
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        LabelX41.Visible = True
        dtpTo.Visible = True
        cbxInclude.Checked = True
        cbxInclude.Enabled = True
        If cbxDisplay.SelectedIndex = 0 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Saturday
            Dim Saturday As Date
            If today.DayOfWeek - DayOfWeek.Saturday > 0 Then
                Saturday = today.AddDays(-dayDiff)
            Else
                Saturday = today.AddDays(-dayDiff).AddDays(-7)
            End If

            dtpFrom.Value = Saturday
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Saturday.AddDays(6)
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            cbxInclude.Checked = False
            LabelX41.Visible = False
            dtpTo.Visible = False

            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM yyyy"
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            cbxInclude.Checked = False
            cbxInclude.Enabled = False
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
            cbxInclude.Enabled = False
            cbxInclude.Checked = False
        Else
            cbxDisplay.SelectedIndex = 0
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub CbxAllB_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllB.CheckedChanged
        If cbxAllB.Checked Then
            cbxBranch.Enabled = False
            cbxBranch.SelectedIndex = -1
            cbxBusinessCenter.Enabled = False
            cbxBusinessCenter.Text = ""
        Else
            cbxBranch.Enabled = True
            cbxBranch.SelectedValue = Branch_ID
            cbxBusinessCenter.Enabled = True
        End If
    End Sub

    Private Sub CbxPreparedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPreparedBy.SelectedIndexChanged
        If cbxPreparedBy.SelectedIndex = -1 Or cbxPreparedBy.Text = "" Then
            lblPosition.Text = ""
        Else
            Dim drv As DataRowView = DirectCast(cbxPreparedBy.SelectedItem, DataRowView)
            lblPosition.Text = drv("Position")
        End If
    End Sub

    Private Sub CbxVerifiedBy_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxVerifiedBy.SelectedIndexChanged
        If cbxVerifiedBy.SelectedIndex = -1 Or cbxVerifiedBy.Text = "" Then
            lblPositionVer.Text = ""
        Else
            Dim drv As DataRowView = DirectCast(cbxVerifiedBy.SelectedItem, DataRowView)
            lblPositionVer.Text = drv("Position")
        End If
    End Sub

    Private Sub BtnPrintCustomized_Click(sender As Object, e As EventArgs) Handles btnPrintCustomized.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("BOOKING REPORT", GridControl1)
        Logs("Booking Report", "Print", "[SENSITIVE] Print Booking Report", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        cbxBusinessCenter.DataSource = DataSource(String.Format("SELECT ID, BusinessCode, BusinessCenter FROM business_center WHERE `status` = 'ACTIVE' AND BranchID = '{0}';", cbxBranch.SelectedValue))
        If cbxBusinessCenter.Items.Count > 0 Then
            cbxBusinessCenter.Enabled = True
        Else
            cbxBusinessCenter.Enabled = False
        End If
        cbxBusinessCenter.SelectedIndex = -1
    End Sub

    Private Sub CbxBranch_TextChanged(sender As Object, e As EventArgs) Handles cbxBranch.TextChanged
        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            cbxBusinessCenter.Text = ""
            cbxBusinessCenter.Enabled = False
        End If
    End Sub

    Private Sub CbxBook_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBook.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        With cbxBank
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            .DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) AND Book = '{2}' ORDER BY `Code`;", Branch_ID, DefaultBankID, cbxBook.SelectedValue))
        End With
    End Sub

    Private Sub CbxAllBank_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllBank.CheckedChanged
        If cbxAllBank.Checked Then
            cbxBook.Enabled = False
            cbxBook.SelectedIndex = -1
            cbxBank.Enabled = False
            cbxBank.Text = ""
        Else
            cbxBook.Enabled = True
            cbxBook.SelectedIndex = 0
            cbxBank.Enabled = True
        End If
    End Sub

    Private Sub IAccountLedger_Click(sender As Object, e As EventArgs) Handles iAccountLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("CreditNumber").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.RowCount > 0 Then
            Dim Ledger As New FrmAccountLedger
            With Ledger
                .CreditNumber = GridView1.GetFocusedRowCellValue("CreditNumber")
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub ILedgerCard_Click(sender As Object, e As EventArgs) Handles iLedgerCard.Click
        Try
            If GridView1.GetFocusedRowCellValue("CreditNumber").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.RowCount > 0 Then
            Dim Ledger As New FrmLedgerCard
            With Ledger
                .CreditNumber = GridView1.GetFocusedRowCellValue("CreditNumber")
                .AccountNumber = GridView1.GetFocusedRowCellValue("Account Number")
                .Product = GridView1.GetFocusedRowCellValue("Product")
                .Borrower = GridView1.GetFocusedRowCellValue("Borrower")
                .vPrint = vPrint
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub
End Class