Imports DevExpress.XtraReports.UI
Public Class FrmROPOASchedule

    Public vPrint As Boolean
    Dim FirstLoad As Boolean
    Dim Bank_1 As DataTable
    Dim Bank_1_Uncosolidated As DataTable
    Dim Bank_2 As DataTable
    Dim Bank_2_Uncosolidated As DataTable
    Private Sub FrmROPOA_Schedule_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4, GridView5, GridView6})
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True

        dtpTo.Value = Date.Now
        LoadData()

        If DefaultBankID > 0 Then
            Dim BankCode As Integer = DataObject(String.Format("SELECT `Code` FROM branch_bank WHERE ID = {0};", DefaultBankID))
            If BankCode = 1 Then
                SuperTabItem1.Visible = False
                SuperTabItem4.Visible = False
            ElseIf BankCode = 2 Then
                SuperTabItem2.Visible = False
                SuperTabItem3.Visible = False
            End If
        Else
            SuperTabItem2.Visible = True
            SuperTabItem1.Visible = True
            SuperTabItem3.Visible = True
            SuperTabItem4.Visible = True
        End If

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

            GetLabelFontSettings({LabelX155})

            GetDateTimeInputFontSettings({dtpTo})

            GetButtonFontSettings({btnSearch, btnPrint, btnPrint_II, btnCancel})

            GetTabControlFontSettings({SuperTabControl1, SuperTabControl2, SuperTabControl3})
        Catch ex As Exception
            TriggerBugReport("ROPOA Schedule - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("ROPA Schedule", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String

        If SuperTabControl1.SelectedTabIndex = 0 Or SuperTabControl1.SelectedTabIndex = 1 Then
            SQL = "SELECT"
            SQL &= "    '' AS 'No',"
            SQL &= "    DATE_FORMAT(R.trans_date,'%b.%d.%Y') AS 'Date',"
            SQL &= "    R.Nature,"
            SQL &= "    IF(R.AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = R.AccountID LIMIT 1),(SELECT CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',LastN_B)) AS 'Borrower' FROM profile_borrower WHERE BorrowerID = R.AccountID LIMIT 1)) AS 'Account Name',"
            SQL &= "    R.AccountNo AS 'Account No',"
            SQL &= "    R.PlateNum AS 'Plate No',"
            SQL &= "    CONCAT(TRIM(R.`Year`), ' ', R.Make, ' ', R.Model, ' ', R.`Type`) AS 'Collateral Description',"
            SQL &= "    IFNULL(L.Running,0) AS 'Book Value 2', 0.0 AS 'Book Value',"
            SQL &= String.Format("    IFNULL((SELECT SUM(amount) FROM ledger_ropoa WHERE approve_status = 'APPROVED' AND `status` = 'ACTIVE' AND asset_number = R.AssetNumber AND trans_id = 2 AND DATE(R.trans_date) <= DATE('{0}')),0) AS 'Impairment Loss',", Format(dtpTo.Value, "yyyy-MM-dd"))
            SQL &= "    IFNULL(S.TotalP,0) AS 'Total Payment',"
            SQL &= "    IFNULL(L.Running,0) AS 'Net Book Value',"
            SQL &= "    IFNULL(IF(DATEDIFF(DATE(NOW()),R.trans_date) BETWEEN 1 AND 90, L.Running, 0),0) AS '1-90 days',"
            SQL &= "    IFNULL(IF(DATEDIFF(DATE(NOW()),R.trans_date) BETWEEN 91 AND 365, L.Running, 0),0) AS '91 days-1 year',"
            SQL &= "    IFNULL(IF(DATEDIFF(DATE(NOW()),R.trans_date) BETWEEN 366 AND 1095, L.Running, 0),0) AS 'Over 1 year - 3 years',"
            SQL &= "    IFNULL(IF(DATEDIFF(DATE(NOW()),R.trans_date) > 1095, L.Running, 0),0) AS 'Over 3 years', "
            SQL &= "    IFNULL(IFNULL(S.Amount,R.Price),0) AS 'Current Selling',"
            SQL &= "    IFNULL((SELECT DATE_FORMAT(appraise_date,'%b.%d.%Y') FROM appraise_ve WHERE (SELECT PlateNum FROM ropoa_vehicle WHERE ropoa_vehicle.AssetNumber = appraise_ve.asset_number LIMIT 1) = R.PlateNum AND `status` = 'ACTIVE' ORDER BY appraise_date DESC LIMIT 1),'') AS 'Last Inspection',"
            SQL &= "    IF(R.sell_status = 'SELL','Available For Sale',IF(R.sell_status = 'SOLD','Sold',IF(R.sell_status = 'RESERVED','Reserved',IF(R.sell_status = 'SCRAP','Scrap',IF(R.sell_status = 'RECLASSIFIED','Reclassified',''))))) AS 'Classification',  "
            SQL &= "    CONCAT(R.`Condition`, ' ', R.ConditionReason) AS 'Observation',"
            SQL &= "    R.Remarks, Bank"
            SQL &= "  FROM ropoa_vehicle R "
            SQL &= "  LEFT JOIN (SELECT GREATEST(IFNULL(SUM(CASE WHEN `Type` = 'Add' THEN Amount END),0) - IFNULL(SUM(CASE WHEN `Type` = 'Deduct' THEN Amount END),0),0) AS 'Running', ReferenceN FROM (SELECT IF(EntryType = 'DEBIT',IF(AccountTitleCode (AccountCode) REGEXP  'GAIN ON SALE |LOSS ON SALE |LAND |TRANSPORTATION |IMPAIRMENT |ACCOUNTS PAYABLE |ACCOUNTS RECEIVABLE |UNREALIZED' OR PostStatus = 'PENDING','','Add'),IF(AccountTitleCode (AccountCode) REGEXP 'GAIN ON SALE |LOSS ON SALE |LAND |TRANSPORTATION |ACCOUNTS PAYABLE |ACCOUNTS RECEIVABLE |UNREALIZED' OR PostStatus = 'PENDING','','Deduct')) AS 'Type', Amount, ReferenceN FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND MotherCode != '111000' GROUP BY ReferenceN) A GROUP BY ReferenceN) L ON L.ReferenceN = R.AssetNumber"
            SQL &= "  LEFT JOIN (SELECT S.AssetNumber, S.Amount, SUM(P.Amount) AS 'TotalP', IF(GREATEST(S.Amount - SUM(P.Amount),0) > 0,'Balance','Sold') AS 'Sold Type' FROM sold_ropoa S "
            SQL &= "  LEFT JOIN accounting_entry P "
            SQL &= "            ON P.ReferenceN = S.AssetNumber "
            SQL &= "            AND P.`status` = 'ACTIVE' "
            SQL &= "            AND P.MotherCode = '126000' AND P.PostStatus = 'POSTED' WHERE S.`status` = 'ACTIVE' GROUP BY S.AssetNumber) S"
            SQL &= "    ON S.AssetNumber = R.AssetNumber"
            SQL &= "  WHERE R.`status` = 'ACTIVE' AND (R.sell_status = 'SELL' OR S.`Sold Type` = 'Balance') "
            SQL &= String.Format("    AND DATE(R.trans_date) <= DATE('{0}') AND Branch_ID IN ({1}) ", FormatDatePicker(dtpTo), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            Dim DT As DataTable = DataSource(SQL & " ORDER BY R.trans_date ASC;")
            Bank_1 = DT.Copy
Here:
            For x As Integer = 0 To Bank_1.Rows.Count - 1
                If Bank_1(x)("Bank") <> 1 Then
                    Bank_1.Rows.RemoveAt(x)
                    GoTo Here
                Else
                    Bank_1(x)("No") = x + 1
                    Bank_1(x)("Book Value") = If(IsNumeric(Bank_1(x)("Book Value 2")), CDbl(Bank_1(x)("Book Value 2")), 0) + CDbl(If(IsNumeric(Bank_1(x)("Impairment Loss")), Bank_1(x)("Impairment Loss"), 0)) + CDbl(If(IsNumeric(Bank_1(x)("Total Payment")), Bank_1(x)("Total Payment"), 0))
                End If
            Next

            Bank_2 = DT.Copy
Here_2:
            For x As Integer = 0 To Bank_2.Rows.Count - 1
                If Bank_2(x)("Bank") <> 2 Then
                    Bank_2.Rows.RemoveAt(x)
                    GoTo Here_2
                Else
                    Bank_2(x)("No") = x + 1
                    Bank_2(x)("Book Value") = If(IsNumeric(Bank_2(x)("Book Value 2")), CDbl(Bank_2(x)("Book Value 2")), 0) + CDbl(If(IsNumeric(Bank_2(x)("Impairment Loss")), Bank_2(x)("Impairment Loss"), 0)) + CDbl(If(IsNumeric(Bank_2(x)("Total Payment")), Bank_2(x)("Total Payment"), 0))
                End If
            Next

            GridControl1.DataSource = Bank_1
            GridView1.Columns("Collateral Description").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView1.Columns("Collateral Description").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            If GridView1.RowCount > 20 Then
                GridColumn7.Width = 274 - 17
            Else
                GridColumn7.Width = 274
            End If

            GridControl2.DataSource = Bank_2
            GridView2.Columns("Collateral Description").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView2.Columns("Collateral Description").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            If GridView2.RowCount > 20 Then
                GridColumn21.Width = 274 - 17
            Else
                GridColumn21.Width = 274
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Or SuperTabControl1.SelectedTabIndex = 3 Then
            SQL = "SELECT"
            SQL &= "    '' AS 'No',"
            SQL &= "    DATE_FORMAT(R.trans_date,'%b.%d.%Y') AS 'Date',"
            SQL &= "    R.Nature,"
            SQL &= "    IF(R.AccountID LIKE '%C%',(SELECT TradeName FROM profile_corporation WHERE BorrowerID = R.AccountID LIMIT 1),(SELECT CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',LastN_B)) AS 'Borrower' FROM profile_borrower WHERE BorrowerID = R.AccountID LIMIT 1)) AS 'Account Name',"
            SQL &= "    R.AccountNo AS 'Account No',"
            SQL &= "    R.TCT,"
            SQL &= "    R.Location AS 'Location',"
            SQL &= "    R.Area AS 'Area (SQ.M.)', "
            SQL &= "    IFNULL(L.Running,0) AS 'Book Value 2', 0.0 AS 'Book Value',"
            SQL &= "    IFNULL(IF(DATEDIFF(DATE(NOW()),R.trans_date) <= 365, L.Running, 0),0) AS '1Year and below',"
            SQL &= "    IFNULL(IF(DATEDIFF(DATE(NOW()),R.trans_date) > 365, L.Running, 0),0) AS 'Over 1Year',"
            SQL &= String.Format("    IFNULL((SELECT SUM(amount) FROM ledger_ropoa WHERE approve_status = 'APPROVED' AND `status` = 'ACTIVE' AND asset_number = R.AssetNumber AND trans_id = 5 AND DATE(R.trans_date) <= DATE('{0}')),0) AS 'Expenses',", Format(dtpTo.Value, "yyyy-MM-dd"))
            SQL &= "    IFNULL(L.Running,0) AS 'Net Book Value',"
            SQL &= "    IFNULL(IFNULL(S.Amount,R.Price),0) AS 'Current Selling',"
            SQL &= "    IF(COS_Annotation != '',DATE_FORMAT(ADDDATE(COS_Annotation,365),'%b.%d.%Y'),'') AS 'Redemption Period Exp', "
            SQL &= "    IFNULL((SELECT DATE_FORMAT(appraise_date,'%b.%d.%Y') FROM appraise_re WHERE (SELECT TCT FROM ropoa_realestate WHERE ropoa_realestate.AssetNumber = appraise_re.asset_number LIMIT 1) = R.TCT AND `status` = 'ACTIVE' ORDER BY appraise_date DESC LIMIT 1),'') AS 'Last Inspection',"
            SQL &= "    IF(R.sell_status = 'SELL','Available For Sale',IF(R.sell_status = 'SOLD','Sold',IF(R.sell_status = 'RESERVED','Reserved',IF(R.sell_status = 'RECLASSIFIED','Reclassified','')))) AS 'Classification',  "
            SQL &= "    R.Remarks, Bank, Consolidation_Date, COS_Annotation"
            SQL &= "  FROM ropoa_realestate R "
            SQL &= "  LEFT JOIN (SELECT GREATEST(IFNULL(SUM(CASE WHEN `Type` = 'Add' THEN Amount END),0) - IFNULL(SUM(CASE WHEN `Type` = 'Deduct' THEN Amount END),0),0) AS 'Running', ReferenceN FROM (SELECT IF(EntryType = 'DEBIT',IF(AccountTitleCode (AccountCode) REGEXP  'GAIN ON SALE |LOSS ON SALE |LAND |TRANSPORTATION |IMPAIRMENT |ACCOUNTS PAYABLE |ACCOUNTS RECEIVABLE |UNREALIZED' OR PostStatus = 'PENDING','','Add'),IF(AccountTitleCode (AccountCode) REGEXP 'GAIN ON SALE |LOSS ON SALE |LAND |TRANSPORTATION |ACCOUNTS PAYABLE |ACCOUNTS RECEIVABLE |UNREALIZED' OR PostStatus = 'PENDING','','Deduct')) AS 'Type', Amount, ReferenceN FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING') AND MotherCode != '111000' GROUP BY ReferenceN) A GROUP BY ReferenceN) L ON L.ReferenceN = R.AssetNumber"
            SQL &= "  LEFT JOIN (SELECT S.AssetNumber, S.Amount, SUM(P.Amount) AS 'TotalP', IF(GREATEST(S.Amount - SUM(P.Amount),0) > 0,'Balance','Sold') AS 'Sold Type' FROM sold_ropoa S "
            SQL &= "    LEFT JOIN accounting_entry P "
            SQL &= "            ON P.ReferenceN = S.AssetNumber "
            SQL &= "            AND P.`status` = 'ACTIVE' "
            SQL &= "            AND P.MotherCode = '126000' AND P.PostStatus = 'POSTED' WHERE S.`status` = 'ACTIVE' GROUP BY S.AssetNumber) S"
            SQL &= "    ON S.AssetNumber = R.AssetNumber"
            SQL &= "  WHERE R.`status` = 'ACTIVE' AND (R.sell_status = 'SELL' OR S.`Sold Type` = 'Balance') "
            SQL &= String.Format("    AND DATE(R.trans_date) <= DATE('{0}') AND Branch_ID IN ({1}) ", FormatDatePicker(dtpTo), If(Multiple_ID = "", Branch_ID, Multiple_ID))
            Dim DT As DataTable = DataSource(SQL & " ORDER BY R.trans_date ASC;")

            Bank_1 = DT.Copy
Here_RE:
            For x As Integer = 0 To Bank_1.Rows.Count - 1
                If Bank_1(x)("Bank") = 1 And If(Bank_1(x)("COS_Annotation") <> "", If(Bank_1(x)("Consolidation_Date") <> "", True, CDate(Bank_1(x)("COS_Annotation")).AddYears(1) > Date.Now), True) Then
                    Bank_1(x)("No") = x + 1
                    Bank_1(x)("Book Value") = If(IsNumeric(Bank_1(x)("Book Value 2")), CDbl(Bank_1(x)("Book Value 2")), 0) + CDbl(If(IsNumeric(Bank_1(x)("Expenses")), Bank_1(x)("Expenses"), 0))
                Else
                    Bank_1.Rows.RemoveAt(x)
                    GoTo Here_RE
                End If
            Next
            GridControl3.DataSource = Bank_1
            GridView3.Columns("Location").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView3.Columns("Location").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            If GridView3.RowCount > 20 Then
                GridColumn35.Width = 274 - 17
            Else
                GridColumn35.Width = 274
            End If

            Bank_1_Uncosolidated = DT.Copy
Here_REV2:
            For x As Integer = 0 To Bank_1_Uncosolidated.Rows.Count - 1
                If Bank_1_Uncosolidated(x)("Bank") = 1 And If(Bank_1_Uncosolidated(x)("COS_Annotation") <> "" And Bank_1_Uncosolidated(x)("Consolidation_Date") = "", CDate(Bank_1_Uncosolidated(x)("COS_Annotation")).AddYears(1) < Date.Now, False) Then
                    Bank_1_Uncosolidated(x)("No") = x + 1
                    Bank_1_Uncosolidated(x)("Book Value") = If(IsNumeric(Bank_1_Uncosolidated(x)("Book Value 2")), CDbl(Bank_1_Uncosolidated(x)("Book Value 2")), 0) + CDbl(If(IsNumeric(Bank_1_Uncosolidated(x)("Expenses")), Bank_1_Uncosolidated(x)("Expenses"), 0))
                Else
                    Bank_1_Uncosolidated.Rows.RemoveAt(x)
                    GoTo Here_REV2
                End If
            Next
            GridControl5.DataSource = Bank_1_Uncosolidated
            GridView5.Columns("Location").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView5.Columns("Location").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            If GridView5.RowCount > 20 Then
                GridColumn83.Width = 274 - 17
            Else
                GridColumn83.Width = 274
            End If

            Bank_2 = DT.Copy
Here_REV3:
            For x As Integer = 0 To Bank_2.Rows.Count - 1
                If Bank_2(x)("Bank") = 2 And If(Bank_2(x)("COS_Annotation") <> "", If(Bank_2(x)("Consolidation_Date") <> "", True, CDate(Bank_2(x)("COS_Annotation")).AddYears(1) > Date.Now), True) Then
                    Bank_2(x)("No") = x + 1
                    Bank_2(x)("Book Value") = If(IsNumeric(Bank_2(x)("Book Value 2")), CDbl(Bank_2(x)("Book Value 2")), 0) + CDbl(If(IsNumeric(Bank_2(x)("Expenses")), Bank_2(x)("Expenses"), 0))
                Else
                    Bank_2.Rows.RemoveAt(x)
                    GoTo Here_REV3
                End If
            Next
            GridControl4.DataSource = Bank_2
            GridView4.Columns("Location").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView4.Columns("Location").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            If GridView4.RowCount > 20 Then
                GridColumn48.Width = 274 - 17
            Else
                GridColumn48.Width = 274
            End If

            Bank_2_Uncosolidated = DT.Copy
Here_REV4:
            For x As Integer = 0 To Bank_2_Uncosolidated.Rows.Count - 1
                If Bank_2_Uncosolidated(x)("Bank") = 2 And If(Bank_2_Uncosolidated(x)("COS_Annotation") <> "" And Bank_2_Uncosolidated(x)("Consolidation_Date") = "", CDate(Bank_2_Uncosolidated(x)("COS_Annotation")).AddYears(1) < Date.Now, False) Then
                    Bank_2_Uncosolidated(x)("No") = x + 1
                    Bank_2_Uncosolidated(x)("Book Value") = If(IsNumeric(Bank_2_Uncosolidated(x)("Book Value 2")), CDbl(Bank_2_Uncosolidated(x)("Book Value 2")), 0) + CDbl(If(IsNumeric(Bank_2_Uncosolidated(x)("Expenses")), Bank_2_Uncosolidated(x)("Expenses"), 0))
                Else
                    Bank_2_Uncosolidated.Rows.RemoveAt(x)
                    GoTo Here_REV4
                End If
            Next
            GridControl6.DataSource = Bank_2_Uncosolidated
            GridView6.Columns("Location").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView6.Columns("Location").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            If GridView6.RowCount > 20 Then
                GridColumn101.Width = 274 - 17
            Else
                GridColumn101.Width = 274
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadData()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Schedule of VL ROPA - Bank 1", GridControl1)
            Logs("ROPA Schedule", "Print", "[SENSITIVE] Print Schedule of VL ROPA - Bank 1", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            GridView2.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Schedule of VL ROPA - Bank 2", GridControl2)
            Logs("ROPA Schedule", "Print", "[SENSITIVE] Print Schedule of VL ROPA - Bank 2", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If SuperTabControl2.SelectedTabIndex = 0 Then
                GridView3.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Schedule of RE ROPA (Consolidated) - Bank 1", GridControl3)
                Logs("ROPA Schedule", "Print", "[SENSITIVE] Print Schedule of RE ROPA (Consolidated) - Bank 1", "", "", "", "")
            ElseIf SuperTabControl2.SelectedTabIndex = 1 Then
                GridView5.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Schedule of RE ROPA (Unconsolidated)- Bank 1", GridControl5)
                Logs("ROPA Schedule", "Print", "[SENSITIVE] Print Schedule of RE ROPA (Unconsolidated)- Bank 1", "", "", "", "")
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            If SuperTabControl2.SelectedTabIndex = 0 Then
                GridView4.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Schedule of RE ROPA (Consolidated) - Bank 2", GridControl4)
                Logs("ROPA Schedule", "Print", "[SENSITIVE] Print Schedule of RE ROPA (Consolidated) - Bank 2", "", "", "", "")
            ElseIf SuperTabControl2.SelectedTabIndex = 1 Then
                GridView6.OptionsPrint.UsePrintStyles = False
                StandardPrinting("Schedule of RE ROPA (Unconsolidated) - Bank 2", GridControl6)
                Logs("ROPA Schedule", "Print", "[SENSITIVE] Print Schedule of RE ROPA (Unconsolidated) - Bank 2", "", "", "", "")
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.btnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnPrint_II_Click(sender As Object, e As EventArgs) Handles btnPrint_II.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Or SuperTabControl1.SelectedTabIndex = 1 Then
            Dim Report As New RptScheduleVL
            With Report
                .Name = "Schedule of ROPA VL"
                .lblAsOf.Text = "As of " & dtpTo.Text

                'Sub Report - Bank 1
                Dim SubRpt As New RptSubScheduleVL With {
                    .DataSource = GridControl1.DataSource
                }
                .subRpt_Bank.ReportSource = SubRpt
                With SubRpt
                    .lblNo.DataBindings.Add("Text", GridControl1.DataSource, "No")
                    .lblDate.DataBindings.Add("Text", GridControl1.DataSource, "Date")
                    .lblNature.DataBindings.Add("Text", GridControl1.DataSource, "Nature")
                    .lblAccountName.DataBindings.Add("Text", GridControl1.DataSource, "Account Name")
                    .lblAccountNo.DataBindings.Add("Text", GridControl1.DataSource, "Account No")
                    .lblPlateNum.DataBindings.Add("Text", GridControl1.DataSource, "Plate No")
                    .lblDescription.DataBindings.Add("Text", GridControl1.DataSource, "Collateral Description")
                    .lblBookValue.DataBindings.Add("Text", GridControl1.DataSource, "Book Value")
                    .lblImpairment.DataBindings.Add("Text", GridControl1.DataSource, "Impairment Loss")
                    .lbl1_90Days.DataBindings.Add("Text", GridControl1.DataSource, "1-90 days")
                    .lbl90Days_1Year.DataBindings.Add("Text", GridControl1.DataSource, "91 days-1 year")
                    .lbl1Year_3Years.DataBindings.Add("Text", GridControl1.DataSource, "Over 1 year - 3 years")
                    .lblOver3Years.DataBindings.Add("Text", GridControl1.DataSource, "Over 3 years")
                    .lblNetBook.DataBindings.Add("Text", GridControl1.DataSource, "Net Book Value")
                    .lblSelling.DataBindings.Add("Text", GridControl1.DataSource, "Current Selling")
                    .lblInspection.DataBindings.Add("Text", GridControl1.DataSource, "Last Inspection")
                    .lblClassification.DataBindings.Add("Text", GridControl1.DataSource, "Classification")
                    .lblObservation.DataBindings.Add("Text", GridControl1.DataSource, "Observation")
                End With
                Dim BookValue As Double
                Dim ImpairmentLoss As Double
                Dim TotalPayment As Double
                Dim NetBook As Double
                Dim Aging1 As Double
                Dim Aging2 As Double
                Dim Aging3 As Double
                Dim Aging4 As Double
                Dim SellingPrice As Double
                With GridView1
                    For x As Integer = 0 To .RowCount - 1
                        BookValue += CDbl(.GetRowCellValue(x, "Book Value"))
                        ImpairmentLoss += CDbl(.GetRowCellValue(x, "Impairment Loss"))
                        TotalPayment += CDbl(.GetRowCellValue(x, "Total Payment"))
                        NetBook += CDbl(.GetRowCellValue(x, "Net Book Value"))
                        Aging1 += CDbl(.GetRowCellValue(x, "1-90 days"))
                        Aging2 += CDbl(.GetRowCellValue(x, "91 days-1 year"))
                        Aging3 += CDbl(.GetRowCellValue(x, "Over 1 year - 3 years"))
                        Aging4 += CDbl(.GetRowCellValue(x, "Over 3 years"))
                        SellingPrice += CDbl(.GetRowCellValue(x, "Current Selling"))
                    Next
                End With
                .lblBookValue.Text = BookValue
                .lblImpairment.Text = ImpairmentLoss
                .lblNetBook.Text = NetBook
                .lbl1_90Days.Text = Aging1
                .lbl90Days_1Year.Text = Aging2
                .lbl1Year_3Years.Text = Aging3
                .lblOver3Years.Text = Aging4
                .lblSellingPrice.Text = SellingPrice

                'Sub Report - Bank 2
                Dim SubRpt_II As New RptSubScheduleVL With {
                    .DataSource = GridControl2.DataSource
                }
                .subRpt_BankII.ReportSource = SubRpt_II
                With SubRpt_II
                    .lblNo.DataBindings.Add("Text", GridControl2.DataSource, "No")
                    .lblDate.DataBindings.Add("Text", GridControl2.DataSource, "Date")
                    .lblNature.DataBindings.Add("Text", GridControl2.DataSource, "Nature")
                    .lblAccountName.DataBindings.Add("Text", GridControl2.DataSource, "Account Name")
                    .lblAccountNo.DataBindings.Add("Text", GridControl2.DataSource, "Account No")
                    .lblPlateNum.DataBindings.Add("Text", GridControl2.DataSource, "Plate No")
                    .lblDescription.DataBindings.Add("Text", GridControl2.DataSource, "Collateral Description")
                    .lblBookValue.DataBindings.Add("Text", GridControl2.DataSource, "Book Value")
                    .lblImpairment.DataBindings.Add("Text", GridControl2.DataSource, "Impairment Loss")
                    .lbl1_90Days.DataBindings.Add("Text", GridControl2.DataSource, "1-90 days")
                    .lbl90Days_1Year.DataBindings.Add("Text", GridControl2.DataSource, "91 days-1 year")
                    .lbl1Year_3Years.DataBindings.Add("Text", GridControl2.DataSource, "Over 1 year - 3 years")
                    .lblOver3Years.DataBindings.Add("Text", GridControl2.DataSource, "Over 3 years")
                    .lblNetBook.DataBindings.Add("Text", GridControl2.DataSource, "Net Book Value")
                    .lblSelling.DataBindings.Add("Text", GridControl2.DataSource, "Current Selling")
                    .lblInspection.DataBindings.Add("Text", GridControl2.DataSource, "Last Inspection")
                    .lblClassification.DataBindings.Add("Text", GridControl2.DataSource, "Classification")
                    .lblObservation.DataBindings.Add("Text", GridControl2.DataSource, "Observation")
                End With
                Dim BookValue_2 As Double
                Dim ImpairmentLoss_2 As Double
                Dim TotalPayment_2 As Double
                Dim NetBook_2 As Double
                Dim Aging1_2 As Double
                Dim Aging2_2 As Double
                Dim Aging3_2 As Double
                Dim Aging4_2 As Double
                Dim SellingPrice_2 As Double
                With GridView2
                    For x As Integer = 0 To .RowCount - 1
                        BookValue_2 += CDbl(.GetRowCellValue(x, "Book Value"))
                        ImpairmentLoss_2 += CDbl(.GetRowCellValue(x, "Impairment Loss"))
                        TotalPayment_2 += CDbl(.GetRowCellValue(x, "Total Payment"))
                        NetBook_2 += CDbl(.GetRowCellValue(x, "Net Book Value"))
                        Aging1_2 += CDbl(.GetRowCellValue(x, "1-90 days"))
                        Aging2_2 += CDbl(.GetRowCellValue(x, "91 days-1 year"))
                        Aging3_2 += CDbl(.GetRowCellValue(x, "Over 1 year - 3 years"))
                        Aging4_2 += CDbl(.GetRowCellValue(x, "Over 3 years"))
                        SellingPrice_2 += CDbl(.GetRowCellValue(x, "Current Selling"))
                    Next
                End With
                .lblBookValue_2.Text = BookValue_2
                .lblImpairment_2.Text = ImpairmentLoss_2
                .lblNetBook_2.Text = NetBook_2
                .lbl1_90Days_2.Text = Aging1_2
                .lbl90Days_1Year_2.Text = Aging2_2
                .lbl1Year_3Years_2.Text = Aging3_2
                .lblOver3Years_2.Text = Aging4_2
                .lblSellingPrice_2.Text = SellingPrice_2
                'TOTAL
                .lblBookValue_3.Text = BookValue_2 + BookValue
                .lblImpairment_3.Text = ImpairmentLoss_2 + ImpairmentLoss
                .lblNetBook_3.Text = NetBook_2 + NetBook
                .lbl1_90Days_3.Text = Aging1_2 + Aging1
                .lbl90Days_1Year_3.Text = Aging2_2 + Aging2
                .lbl1Year_3Years_3.Text = Aging3_2 + Aging3
                .lblOver3Years_3.Text = Aging4_2 + Aging4
                .lblSellingPrice_3.Text = SellingPrice_2 + SellingPrice
                Logs("ROPA Schedule", "Print", "[SENSITIVE] Print ROPA Schedule VL", "", "", "", "")

                .ShowPreview()
            End With
        Else
            Dim Report As New RptScheduleRE
            With Report
                .Name = "Schedule of ROPA RE"
                .lblAsOf.Text = "As of " & dtpTo.Text

                'Sub Report - Bank 1
                Dim SubRpt As New RptSubScheduleRE With {
                    .DataSource = GridControl3.DataSource
                }
                .subRpt_Bank.ReportSource = SubRpt
                With SubRpt
                    .lblNo.DataBindings.Add("Text", GridControl3.DataSource, "No")
                    .lblDate.DataBindings.Add("Text", GridControl3.DataSource, "Date")
                    .lblNature.DataBindings.Add("Text", GridControl3.DataSource, "Nature")
                    .lblAccountName.DataBindings.Add("Text", GridControl3.DataSource, "Account Name")
                    .lblAccountNo.DataBindings.Add("Text", GridControl3.DataSource, "Account No")
                    .lblTCT.DataBindings.Add("Text", GridControl3.DataSource, "TCT")
                    .lblLocation.DataBindings.Add("Text", GridControl3.DataSource, "Location")
                    .lblArea.DataBindings.Add("Text", GridControl3.DataSource, "Area (SQ.M.)")
                    .lblBookValue.DataBindings.Add("Text", GridControl3.DataSource, "Book Value")
                    .lbl1Year.DataBindings.Add("Text", GridControl3.DataSource, "1Year and below")
                    .lblOver1Year.DataBindings.Add("Text", GridControl3.DataSource, "Over 1Year")
                    .lblSelling.DataBindings.Add("Text", GridControl3.DataSource, "Current Selling")
                    .lblRedemption.DataBindings.Add("Text", GridControl3.DataSource, "Redemption Period Exp")
                    .lblInspection.DataBindings.Add("Text", GridControl3.DataSource, "Last Inspection")
                    .lblClassification.DataBindings.Add("Text", GridControl3.DataSource, "Classification")
                    .lblRemarks.DataBindings.Add("Text", GridControl3.DataSource, "Remarks")
                End With
                Dim BookValue As Double
                Dim Aging1 As Double
                Dim Aging2 As Double
                Dim CurrentSelling As Double
                With GridView3
                    For x As Integer = 0 To .RowCount - 1
                        BookValue += CDbl(.GetRowCellValue(x, "Book Value"))
                        Aging1 += CDbl(.GetRowCellValue(x, "1Year and below"))
                        Aging2 += CDbl(.GetRowCellValue(x, "Over 1Year"))
                        CurrentSelling += CDbl(.GetRowCellValue(x, "Current Selling"))
                    Next
                End With
                .lblBookValue.Text = BookValue
                .lbl1Year.Text = Aging1
                .lblOver1Year.Text = Aging2
                .lblSelling.Text = CurrentSelling

                'Sub Report - Bank 2
                Dim SubRpt_II As New RptSubScheduleRE With {
                    .DataSource = GridControl4.DataSource
                }
                .subRpt_BankII.ReportSource = SubRpt_II
                With SubRpt_II
                    .lblNo.DataBindings.Add("Text", GridControl4.DataSource, "No")
                    .lblDate.DataBindings.Add("Text", GridControl4.DataSource, "Date")
                    .lblNature.DataBindings.Add("Text", GridControl4.DataSource, "Nature")
                    .lblAccountName.DataBindings.Add("Text", GridControl4.DataSource, "Account Name")
                    .lblAccountNo.DataBindings.Add("Text", GridControl4.DataSource, "Account No")
                    .lblTCT.DataBindings.Add("Text", GridControl4.DataSource, "TCT")
                    .lblLocation.DataBindings.Add("Text", GridControl4.DataSource, "Location")
                    .lblArea.DataBindings.Add("Text", GridControl4.DataSource, "Area (SQ.M.)")
                    .lblBookValue.DataBindings.Add("Text", GridControl4.DataSource, "Book Value")
                    .lbl1Year.DataBindings.Add("Text", GridControl4.DataSource, "1Year and below")
                    .lblOver1Year.DataBindings.Add("Text", GridControl4.DataSource, "Over 1Year")
                    .lblSelling.DataBindings.Add("Text", GridControl4.DataSource, "Current Selling")
                    .lblRedemption.DataBindings.Add("Text", GridControl4.DataSource, "Redemption Period Exp")
                    .lblInspection.DataBindings.Add("Text", GridControl4.DataSource, "Last Inspection")
                    .lblClassification.DataBindings.Add("Text", GridControl4.DataSource, "Classification")
                    .lblRemarks.DataBindings.Add("Text", GridControl4.DataSource, "Remarks")
                End With
                Dim BookValue_2 As Double
                Dim Aging1_2 As Double
                Dim Aging2_2 As Double
                Dim CurrentSelling_2 As Double
                With GridView4
                    For x As Integer = 0 To .RowCount - 1
                        BookValue_2 += CDbl(.GetRowCellValue(x, "Book Value"))
                        Aging1_2 += CDbl(.GetRowCellValue(x, "1Year and below"))
                        Aging2_2 += CDbl(.GetRowCellValue(x, "Over 1Year"))
                        CurrentSelling_2 += CDbl(.GetRowCellValue(x, "Current Selling"))
                    Next
                End With
                .lblBookValue_2.Text = BookValue_2
                .lbl1Year_2.Text = Aging1_2
                .lblOver1Year_2.Text = Aging2_2
                .lblSelling_2.Text = CurrentSelling_2
                'TOTAL CONSOLIDATED
                .lblBookValue_3.Text = BookValue_2 + BookValue
                .lbl1Year_3.Text = Aging1_2 + Aging1
                .lblOver1Year_3.Text = Aging2_2 + Aging2
                .lblSelling_3.Text = CurrentSelling_2 + CurrentSelling

                'Sub Report - Bank 1 - Unconsolidated
                Dim SubRpt_III As New RptSubScheduleRE With {
                    .DataSource = GridControl5.DataSource
                }
                .subRpt_BankIII.ReportSource = SubRpt_III
                With SubRpt_III
                    .lblNo.DataBindings.Add("Text", GridControl5.DataSource, "No")
                    .lblDate.DataBindings.Add("Text", GridControl5.DataSource, "Date")
                    .lblNature.DataBindings.Add("Text", GridControl5.DataSource, "Nature")
                    .lblAccountName.DataBindings.Add("Text", GridControl5.DataSource, "Account Name")
                    .lblAccountNo.DataBindings.Add("Text", GridControl5.DataSource, "Account No")
                    .lblTCT.DataBindings.Add("Text", GridControl5.DataSource, "TCT")
                    .lblLocation.DataBindings.Add("Text", GridControl5.DataSource, "Location")
                    .lblArea.DataBindings.Add("Text", GridControl5.DataSource, "Area (SQ.M.)")
                    .lblBookValue.DataBindings.Add("Text", GridControl5.DataSource, "Book Value")
                    .lbl1Year.DataBindings.Add("Text", GridControl5.DataSource, "1Year and below")
                    .lblOver1Year.DataBindings.Add("Text", GridControl5.DataSource, "Over 1Year")
                    .lblSelling.DataBindings.Add("Text", GridControl5.DataSource, "Current Selling")
                    .lblRedemption.DataBindings.Add("Text", GridControl5.DataSource, "Redemption Period Exp")
                    .lblInspection.DataBindings.Add("Text", GridControl5.DataSource, "Last Inspection")
                    .lblClassification.DataBindings.Add("Text", GridControl5.DataSource, "Classification")
                    .lblRemarks.DataBindings.Add("Text", GridControl5.DataSource, "Remarks")
                End With
                Dim BookValue_4 As Double
                Dim Aging1_4 As Double
                Dim Aging2_4 As Double
                Dim CurrentSelling_4 As Double
                With GridView5
                    For x As Integer = 0 To .RowCount - 1
                        BookValue_4 += CDbl(.GetRowCellValue(x, "Book Value"))
                        Aging1_4 += CDbl(If(IsNumeric(.GetRowCellValue(x, "1Year and below")), .GetRowCellValue(x, "1Year and below"), 0))
                        Aging2_4 += CDbl(If(IsNumeric(.GetRowCellValue(x, "Over 1Year")), .GetRowCellValue(x, "Over 1Year"), 0))
                        CurrentSelling_4 += CDbl(.GetRowCellValue(x, "Current Selling"))
                    Next
                End With
                .lblBookValue_4.Text = BookValue_4
                .lbl1Year_4.Text = Aging1_4
                .lblOver1Year_4.Text = Aging2_4
                .lblSelling_4.Text = CurrentSelling_4

                'Sub Report - Bank 2 - Unconsolidated
                Dim SubRpt_IV As New RptSubScheduleRE With {
                    .DataSource = GridControl6.DataSource
                }
                .subRpt_BankIV.ReportSource = SubRpt_IV
                With SubRpt_IV
                    .lblNo.DataBindings.Add("Text", GridControl6.DataSource, "No")
                    .lblDate.DataBindings.Add("Text", GridControl6.DataSource, "Date")
                    .lblNature.DataBindings.Add("Text", GridControl6.DataSource, "Nature")
                    .lblAccountName.DataBindings.Add("Text", GridControl6.DataSource, "Account Name")
                    .lblAccountNo.DataBindings.Add("Text", GridControl6.DataSource, "Account No")
                    .lblTCT.DataBindings.Add("Text", GridControl6.DataSource, "TCT")
                    .lblLocation.DataBindings.Add("Text", GridControl6.DataSource, "Location")
                    .lblArea.DataBindings.Add("Text", GridControl6.DataSource, "Area (SQ.M.)")
                    .lblBookValue.DataBindings.Add("Text", GridControl6.DataSource, "Book Value")
                    .lbl1Year.DataBindings.Add("Text", GridControl6.DataSource, "1Year and below")
                    .lblOver1Year.DataBindings.Add("Text", GridControl6.DataSource, "Over 1Year")
                    .lblSelling.DataBindings.Add("Text", GridControl6.DataSource, "Current Selling")
                    .lblRedemption.DataBindings.Add("Text", GridControl6.DataSource, "Redemption Period Exp")
                    .lblInspection.DataBindings.Add("Text", GridControl6.DataSource, "Last Inspection")
                    .lblClassification.DataBindings.Add("Text", GridControl6.DataSource, "Classification")
                    .lblRemarks.DataBindings.Add("Text", GridControl6.DataSource, "Remarks")
                End With
                Dim BookValue_5 As Double
                Dim Aging1_5 As Double
                Dim Aging2_5 As Double
                Dim CurrentSelling_5 As Double
                With GridView6
                    For x As Integer = 0 To .RowCount - 1
                        BookValue_5 += CDbl(.GetRowCellValue(x, "Book Value"))
                        Aging1_5 += CDbl(If(IsNumeric(.GetRowCellValue(x, "1Year and below")), .GetRowCellValue(x, "1Year and below"), 0))
                        Aging2_5 += CDbl(If(IsNumeric(.GetRowCellValue(x, "Over 1Year")), .GetRowCellValue(x, "Over 1Year"), 0))
                        CurrentSelling_5 += CDbl(.GetRowCellValue(x, "Current Selling"))
                    Next
                End With
                .lblBookValue_5.Text = BookValue_5
                .lbl1Year_5.Text = Aging1_5
                .lblOver1Year_5.Text = Aging2_5
                .lblSelling_5.Text = CurrentSelling_5
                'TOTAL UNCONSOLIDATED
                .lblBookValue_6.Text = BookValue_4 + BookValue_5
                .lbl1Year_6.Text = Aging1_4 + Aging1_5
                .lblOver1Year_6.Text = Aging2_4 + Aging2_5
                .lblSelling_6.Text = CurrentSelling_4 + CurrentSelling_5
                'TOTAL
                .lblBookValue_7.Text = BookValue_2 + BookValue + BookValue_4 + BookValue_5
                .lbl1Year_7.Text = Aging1_2 + Aging1 + Aging1_4 + Aging1_5
                .lblOver1Year_7.Text = Aging2_2 + Aging2 + Aging2_4 + Aging2_5
                .lblSelling_7.Text = CurrentSelling_2 + CurrentSelling + CurrentSelling_4 + CurrentSelling_5
                Logs("ROPA Schedule", "Print", "[SENSITIVE] Print ROPA Schedule RE", "", "", "", "")

                .ShowPreview()
            End With
        End If
        Cursor = Cursors.Default
    End Sub
End Class