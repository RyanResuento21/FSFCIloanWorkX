Imports DevExpress.XtraReports.UI
Public Class FrmAging

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmAging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpAsOf.Value = Date.Now

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

        With cbxBusinessCenter
            .ValueMember = "ID"
            .DisplayMember = "BusinessCenter"
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

            GetLabelFontSettings({LabelX1, LabelX4, LabelX42})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank})

            GetDateTimeInputFontSettings({dtpAsOf})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})

            GetContextMenuBarFontSettings({ContextMenuBar3})
        Catch ex As Exception
            TriggerBugReport("Aging - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Aging", lblTitle.Text)
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            lblTitle.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT AgingRemarks FROM credit_application WHERE CreditNumber = '{0}';", GridView1.GetFocusedRowCellValue("CreditNumber")))
            If GridView1.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks for this aging from {1} to {0}?", GridView1.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE credit_application SET AgingRemarks = '{1}' WHERE CreditNumber = '{0}';", GridView1.GetFocusedRowCellValue("CreditNumber"), GridView1.GetFocusedRowCellValue("Remarks")))
                    Logs("Aging", "Remarks", String.Format("Change remarks for Credit Number {0} from {1} to {2}.", GridView1.GetFocusedRowCellValue("CreditNumber"), Old_Remarks, GridView1.GetFocusedRowCellValue("Remarks")), "", "", "", "")
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        ElseIf e.Control And e.KeyCode = Keys.S Then
            If MsgBoxYes("Are you sure you want to save this Table Display?") = MsgBoxResult.Yes Then
                Dim SQL As String
                If GridControl1.Tag = 1 Then
                    SQL = "UPDATE column_settings SET"
                Else
                    SQL = "INSERT INTO column_settings SET"
                End If
                SQL &= String.Format(" UserID = '{0}', ", User_ID)
                SQL &= String.Format(" FormID = '{0}', ", Tag)
                SQL &= String.Format(" Column1V = '{0}', ", GridColumn1.VisibleIndex)
                SQL &= String.Format(" Column2V = '{0}', ", GridColumn2.VisibleIndex)
                SQL &= String.Format(" Column3V = '{0}', ", GridColumn3.VisibleIndex)
                SQL &= String.Format(" Column4V = '{0}', ", GridColumn4.VisibleIndex)
                SQL &= String.Format(" Column5V = '{0}', ", GridColumn5.VisibleIndex)
                SQL &= String.Format(" Column6V = '{0}', ", GridColumn6.VisibleIndex)
                SQL &= String.Format(" Column7V = '{0}', ", GridColumn7.VisibleIndex)
                SQL &= String.Format(" Column8V = '{0}', ", GridColumn8.VisibleIndex)
                SQL &= String.Format(" Column9V = '{0}', ", GridColumn9.VisibleIndex)
                SQL &= String.Format(" Column10V = '{0}', ", GridColumn10.VisibleIndex)
                SQL &= String.Format(" Column11V = '{0}', ", GridColumn11.VisibleIndex)
                SQL &= String.Format(" Column12V = '{0}', ", GridColumn12.VisibleIndex)
                SQL &= String.Format(" Column13V = '{0}', ", GridColumn13.VisibleIndex)
                SQL &= String.Format(" Column14V = '{0}', ", GridColumn14.VisibleIndex)
                SQL &= String.Format(" Column15V = '{0}', ", GridColumn15.VisibleIndex)
                SQL &= String.Format(" Column16V = '{0}', ", GridColumn16.VisibleIndex)
                SQL &= String.Format(" Column17V = '{0}', ", GridColumn17.VisibleIndex)
                SQL &= String.Format(" Column18V = '{0}', ", GridColumn18.VisibleIndex)
                SQL &= String.Format(" Column19V = '{0}', ", GridColumn19.VisibleIndex)
                SQL &= String.Format(" Column20V = '{0}', ", GridColumn20.VisibleIndex)
                SQL &= String.Format(" Column21V = '{0}', ", GridColumn21.VisibleIndex)
                SQL &= String.Format(" Column22V = '{0}', ", GridColumn22.VisibleIndex)
                SQL &= String.Format(" Column23V = '{0}', ", GridColumn23.VisibleIndex)
                SQL &= String.Format(" Column24V = '{0}', ", GridColumn24.VisibleIndex)
                SQL &= String.Format(" Column25V = '{0}', ", GridColumn25.VisibleIndex)
                SQL &= String.Format(" Column26V = '{0}', ", GridColumn26.VisibleIndex)
                SQL &= String.Format(" Column27V = '{0}', ", GridColumn27.VisibleIndex)
                SQL &= String.Format(" Column28V = '{0}', ", GridColumn28.VisibleIndex)
                SQL &= String.Format(" Column29V = '{0}', ", -1)
                SQL &= String.Format(" Column30V = '{0}', ", -1)
                SQL &= String.Format(" Column1W = '{0}', ", GridColumn1.Width)
                SQL &= String.Format(" Column2W = '{0}', ", GridColumn2.Width)
                SQL &= String.Format(" Column3W = '{0}', ", GridColumn3.Width)
                SQL &= String.Format(" Column4W = '{0}', ", GridColumn4.Width)
                SQL &= String.Format(" Column5W = '{0}', ", GridColumn5.Width)
                SQL &= String.Format(" Column6W = '{0}', ", GridColumn6.Width)
                SQL &= String.Format(" Column7W = '{0}', ", GridColumn7.Width)
                SQL &= String.Format(" Column8W = '{0}', ", GridColumn8.Width)
                SQL &= String.Format(" Column9W = '{0}', ", GridColumn9.Width)
                SQL &= String.Format(" Column10W = '{0}', ", GridColumn10.Width)
                SQL &= String.Format(" Column11W = '{0}', ", GridColumn11.Width)
                SQL &= String.Format(" Column12W = '{0}', ", GridColumn12.Width)
                SQL &= String.Format(" Column13W = '{0}', ", GridColumn13.Width)
                SQL &= String.Format(" Column14W = '{0}', ", GridColumn14.Width)
                SQL &= String.Format(" Column15W = '{0}', ", GridColumn15.Width)
                SQL &= String.Format(" Column16W = '{0}', ", GridColumn16.Width)
                SQL &= String.Format(" Column17W = '{0}', ", GridColumn17.Width)
                SQL &= String.Format(" Column18W = '{0}', ", GridColumn18.Width)
                SQL &= String.Format(" Column19W = '{0}', ", GridColumn19.Width)
                SQL &= String.Format(" Column20W = '{0}', ", GridColumn20.Width)
                SQL &= String.Format(" Column21W = '{0}', ", GridColumn21.Width)
                SQL &= String.Format(" Column22W = '{0}', ", GridColumn22.Width)
                SQL &= String.Format(" Column23W = '{0}', ", GridColumn23.Width)
                SQL &= String.Format(" Column24W = '{0}', ", GridColumn24.Width)
                SQL &= String.Format(" Column25W = '{0}', ", GridColumn25.Width)
                SQL &= String.Format(" Column26W = '{0}', ", GridColumn26.Width)
                SQL &= String.Format(" Column27W = '{0}', ", GridColumn27.Width)
                SQL &= String.Format(" Column28W = '{0}', ", GridColumn28.Width)
                SQL &= String.Format(" Column29W = '{0}', ", 0)
                SQL &= String.Format(" Column30W = '{0}' ", 0)
                If GridControl1.Tag = 1 Then
                    SQL &= String.Format(" WHERE FormID = '{0}' AND `status` = 'ACTIVE';", Tag)
                End If
                DataObject(SQL)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "      C.Product AS 'Product', C.CreditNumber, "
        SQL &= "      AccountNumber AS 'Account Number',"
        SQL &= "      Borrower(C.BorrowerID) AS 'Borrower',  "
        SQL &= "      CI AS 'CI',  "
        SQL &= "      C.Marketing AS 'AO',  "
        SQL &= "      (SELECT GROUP_CONCAT(Collateral) FROM credit_investigation WHERE credit_investigation.CreditNumber = C.CreditNumber AND `status` = 'ACTIVE' LIMIT 1) AS 'Plate Number',  "
        SQL &= "      DATE_FORMAT(Released, '%M %d, %Y') AS 'Date Granted',  "
        SQL &= "      DATE_FORMAT(LDD, '%M %d, %Y') AS 'Due Date',  "
        SQL &= "      DATE_FORMAT(FDD, '%d') AS 'Monthly Due',  "
        SQL &= "      C.Terms AS 'Term',  "
        SQL &= "      C.AmountApplied AS 'Principal',  "
        SQL &= "      C.Face_Amount AS 'Face Amount',  "
        SQL &= "      C.GMA AS 'GMA',  "
        SQL &= "      (SELECT IFNULL(DATE_FORMAT(MAX(IF(DepositDate = '',ORDate,DepositDate)), '%M %d, %Y'),'') FROM official_receipt WHERE Payee_ID = C.CreditNumber AND `status` = 'ACTIVE') AS 'Last Payment Date',  "
        SQL &= String.Format("      TIMESTAMPDIFF(MONTH,FDD,'{0}') + IF(DAY('{0}') < DAY(LDD),1,0) AS 'Months Lapsed',  ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("      IF(TIMESTAMPDIFF(DAY,'{0}',LDD) < 0,0,TIMESTAMPDIFF(DAY,'{0}',LDD)) AS 'Remaining Days',  ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("      IF(TIMESTAMPDIFF(MONTH,'{0}',LDD) + IF(DAY('{0}') > DAY(LDD),1,0) < 0,0,TIMESTAMPDIFF(MONTH,'{0}',LDD) + IF(DAY('{0}') > DAY(LDD),1,0)) AS 'Remaining Months',  ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("      IF(C.Face_Amount - IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W','Principal','UDI') AND ORDate < '{0}' THEN IF(EntryType = 'DEBIT' OR A.Remarks LIKE '%[Reversal]%',0 - Amount,Amount) END),0) < 0,0,C.Face_Amount - IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W','Principal','UDI') AND ORDate < '{0}' THEN IF(EntryType = 'DEBIT' OR A.Remarks LIKE '%[Reversal]%',0 - Amount,Amount) END),0)) AS 'Beginning Balance',  ", Format(dtpAsOf.Value, "yyyy-MM-01"))
        SQL &= String.Format("      IF(C.Face_Amount - IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W','Principal','UDI') AND ORDate <= '{0}' THEN IF(EntryType = 'DEBIT' OR A.Remarks LIKE '%[Reversal]%',0 - Amount,Amount) END),0) < 0,0,C.Face_Amount - IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W','Principal','UDI') AND ORDate <= '{0}' THEN IF(EntryType = 'DEBIT' OR A.Remarks LIKE '%[Reversal]%',0 - Amount,Amount) END),0)) AS 'Ending Balance',  ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("      IF(C.GMA * GREATEST(TIMESTAMPDIFF(MONTH,'{0}',LDD) + IF(DAY('{0}') <= DAY(LDD),1,0),0) >= (C.Face_Amount - IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W','Principal','UDI') AND ORDate <= '{0}' THEN IF(EntryType = 'DEBIT' OR A.Remarks LIKE '%[Reversal]%',0 - Amount,Amount) END),0)),(C.Face_Amount - IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD','RPPD-A','RPPD-W','Principal','UDI') AND ORDate <= '{0}' THEN IF(EntryType = 'DEBIT' OR A.Remarks LIKE '%[Reversal]%',0 - Amount,Amount) END),0)), C.GMA * GREATEST(TIMESTAMPDIFF(MONTH,'{0}',LDD) + IF(DAY('{0}') <= DAY(LDD),1,0),0)) AS 'Current',  ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("      0 AS '1-30 Days',", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("      0 AS '31-60 Days',", Format(dtpAsOf.Value.AddDays(-31), "yyyy-MM-dd"))
        SQL &= String.Format("      0 AS '61-90 Days',", Format(dtpAsOf.Value.AddDays(-61), "yyyy-MM-dd"))
        SQL &= String.Format("      0 AS '91-120 Days',", Format(dtpAsOf.Value.AddDays(-91), "yyyy-MM-dd"))
        SQL &= String.Format("      0 AS 'Over 120 Days',", Format(dtpAsOf.Value.AddDays(-121), "yyyy-MM-dd"))
        SQL &= "      AgingRemarks AS 'Remarks',  "
        SQL &= "      (SELECT cityMunDesc FROM city_municipality WHERE citymunCode = C.`AddressC_B-ID`) AS 'City',  "
        SQL &= "      (SELECT (SELECT ProductType FROM product_type WHERE product_type.ID = product_setup.product_type) FROM product_setup WHERE ID = C.Product_ID) AS 'Product Type'"
        SQL &= " FROM credit_application C"
        SQL &= "      LEFT JOIN (SELECT ReferenceN, Amount, PaidFor, ORDate, EntryType, Remarks FROM accounting_entry WHERE `status` IN ('ACTIVE','PENDING')) A ON A.ReferenceN = C.CreditNumber"
        SQL &= String.Format(" WHERE C.`status` = 'ACTIVE' AND Released <= '{3}' AND C.PaymentRequest IN ('RELEASED','CLOSED') AND IF(C.`PaymentRequest` = 'CLOSED',(SELECT IFNULL(DATE_FORMAT(MAX(ORDate), '%M %Y'),'') FROM accounting_entry WHERE ReferenceN = C.CreditNumber AND PaidFor = 'Principal' AND `status` = 'ACTIVE') = '{2}',TRUE) AND IF({0} = 1,Branch_ID IN ({5}),Branch_ID = '{1}')  AND IF('{4}' = '0',TRUE,BusinessID = '{4}') AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}')) GROUP BY C.CreditNumber;", cbxAllB.Checked, cbxBranch.SelectedValue, Format(dtpAsOf.Value, "MMMM yyyy"), Format(dtpAsOf.Value, "yyyy-MM-dd"), ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        Dim DT As DataTable = DataSource(SQL)
        Dim X13 As Double
        Dim Z13 As Double
        Dim AB13 As Double
        Dim AD13 As Double
        Dim AF13 As Double
        Dim PassDue As Double
        For x As Integer = 0 To DT.Rows.Count - 1
            X13 = CDbl(If(IsNumeric(DT(x)("Ending Balance")), DT(x)("Ending Balance"), 0)) - CDbl(If(IsNumeric(DT(x)("Current")), DT(x)("Current"), 0))
            PassDue = ComputePassDue(DT(x)("CreditNumber"), 1, X13)
            DT(x)("1-30 Days") = If(X13 > CDbl(DT(x)("GMA")), DT(x)("GMA"), X13)
            Z13 = X13 - CDbl(DT(x)("1-30 Days"))
            DT(x)("31-60 Days") = If(Z13 > CDbl(DT(x)("GMA")), DT(x)("GMA"), Z13)
            AB13 = X13 - (CDbl(DT(x)("1-30 Days")) + CDbl(DT(x)("31-60 Days")))
            DT(x)("61-90 Days") = If(AB13 > CDbl(DT(x)("GMA")), DT(x)("GMA"), AB13)
            AD13 = X13 - (CDbl(DT(x)("1-30 Days")) + CDbl(DT(x)("31-60 Days")) + CDbl(DT(x)("61-90 Days")))
            DT(x)("91-120 Days") = If(AD13 > CDbl(DT(x)("GMA")), DT(x)("GMA"), AD13)
            AF13 = X13 - (CDbl(DT(x)("1-30 Days")) + CDbl(DT(x)("31-60 Days")) + CDbl(DT(x)("61-90 Days")) + CDbl(DT(x)("91-120 Days")))
            DT(x)("Over 120 Days") = AF13
        Next

        GridControl1.DataSource = DT
        With GridView1
            .Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .Columns("Principal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Principal").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Face Amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("GMA").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("GMA").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Beginning Balance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Beginning Balance").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Ending Balance").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Ending Balance").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Current").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Current").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("1-30 Days").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("1-30 Days").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("31-60 Days").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("31-60 Days").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("61-90 Days").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("61-90 Days").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("91-120 Days").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("91-120 Days").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Over 120 Days").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Over 120 Days").SummaryItem.DisplayFormat = "{0:n2}"
        End With
        Dim DT_ColumnSettings As DataTable = DataSource(String.Format("SELECT * FROM column_settings WHERE UserID = '{0}' AND FormID = '{1}' AND `status` = 'ACTIVE';", User_ID, Tag))
        If DT_ColumnSettings.Rows.Count > 0 Then
            GridControl1.Tag = 1
            GridColumn1.VisibleIndex = DT_ColumnSettings(0)("Column1V")
            GridColumn2.VisibleIndex = DT_ColumnSettings(0)("Column2V")
            GridColumn3.VisibleIndex = DT_ColumnSettings(0)("Column3V")
            GridColumn4.VisibleIndex = DT_ColumnSettings(0)("Column4V")
            GridColumn5.VisibleIndex = DT_ColumnSettings(0)("Column5V")
            GridColumn6.VisibleIndex = DT_ColumnSettings(0)("Column6V")
            GridColumn7.VisibleIndex = DT_ColumnSettings(0)("Column7V")
            GridColumn8.VisibleIndex = DT_ColumnSettings(0)("Column8V")
            GridColumn9.VisibleIndex = DT_ColumnSettings(0)("Column9V")
            GridColumn10.VisibleIndex = DT_ColumnSettings(0)("Column10V")
            GridColumn11.VisibleIndex = DT_ColumnSettings(0)("Column11V")
            GridColumn12.VisibleIndex = DT_ColumnSettings(0)("Column12V")
            GridColumn13.VisibleIndex = DT_ColumnSettings(0)("Column13V")
            GridColumn14.VisibleIndex = DT_ColumnSettings(0)("Column14V")
            GridColumn15.VisibleIndex = DT_ColumnSettings(0)("Column15V")
            GridColumn16.VisibleIndex = DT_ColumnSettings(0)("Column16V")
            GridColumn17.VisibleIndex = DT_ColumnSettings(0)("Column17V")
            GridColumn18.VisibleIndex = DT_ColumnSettings(0)("Column18V")
            GridColumn19.VisibleIndex = DT_ColumnSettings(0)("Column19V")
            GridColumn20.VisibleIndex = DT_ColumnSettings(0)("Column20V")
            GridColumn21.VisibleIndex = DT_ColumnSettings(0)("Column21V")
            GridColumn22.VisibleIndex = DT_ColumnSettings(0)("Column22V")
            GridColumn23.VisibleIndex = DT_ColumnSettings(0)("Column23V")
            GridColumn24.VisibleIndex = DT_ColumnSettings(0)("Column24V")
            GridColumn25.VisibleIndex = DT_ColumnSettings(0)("Column25V")
            GridColumn26.VisibleIndex = DT_ColumnSettings(0)("Column26V")
            GridColumn27.VisibleIndex = DT_ColumnSettings(0)("Column27V")
            GridColumn28.VisibleIndex = DT_ColumnSettings(0)("Column28V")

            GridColumn1.Width = DT_ColumnSettings(0)("Column1W")
            GridColumn2.Width = DT_ColumnSettings(0)("Column2W")
            GridColumn3.Width = DT_ColumnSettings(0)("Column3W")
            GridColumn4.Width = DT_ColumnSettings(0)("Column4W")
            GridColumn5.Width = DT_ColumnSettings(0)("Column5W")
            GridColumn6.Width = DT_ColumnSettings(0)("Column6W")
            GridColumn7.Width = DT_ColumnSettings(0)("Column7W")
            GridColumn8.Width = DT_ColumnSettings(0)("Column8W")
            GridColumn9.Width = DT_ColumnSettings(0)("Column9W")
            GridColumn10.Width = DT_ColumnSettings(0)("Column10W")
            GridColumn11.Width = DT_ColumnSettings(0)("Column11W")
            GridColumn12.Width = DT_ColumnSettings(0)("Column12W")
            GridColumn13.Width = DT_ColumnSettings(0)("Column13W")
            GridColumn14.Width = DT_ColumnSettings(0)("Column14W")
            GridColumn15.Width = DT_ColumnSettings(0)("Column15W")
            GridColumn16.Width = DT_ColumnSettings(0)("Column16W")
            GridColumn17.Width = DT_ColumnSettings(0)("Column17W")
            GridColumn18.Width = DT_ColumnSettings(0)("Column18W")
            GridColumn19.Width = DT_ColumnSettings(0)("Column19W")
            GridColumn20.Width = DT_ColumnSettings(0)("Column20W")
            GridColumn21.Width = DT_ColumnSettings(0)("Column21W")
            GridColumn22.Width = DT_ColumnSettings(0)("Column22W")
            GridColumn23.Width = DT_ColumnSettings(0)("Column23W")
            GridColumn24.Width = DT_ColumnSettings(0)("Column24W")
            GridColumn25.Width = DT_ColumnSettings(0)("Column25W")
            GridColumn26.Width = DT_ColumnSettings(0)("Column26W")
            GridColumn27.Width = DT_ColumnSettings(0)("Column27W")
            GridColumn28.Width = DT_ColumnSettings(0)("Column28W")
        Else
            GridView1.BestFitColumns()
            GridControl1.Tag = 0
        End If

        If GridView1.RowCount > 21 Then
            GridColumn3.Width = 175 - 17
        Else
            GridColumn3.Width = 175
        End If
        Cursor = Cursors.Default
    End Sub

    Private Function ComputePassDue(CreditNumber As String, Day As Integer, Passdue As Double)
        Dim PassdueX As Double
        Dim DT_Ledger As New DataTable
        Dim SQL_II As String = ""
        With DT_Ledger
            .Columns.Clear()
            .Columns.Add("ID")
            .Columns.Add("Date")
            .Columns.Add("Remarks")
            .Columns.Add("O.R. No.")
            .Columns.Add("Amount Paid")
            .Columns.Add("A.R. P")
            .Columns.Add("Penalties P")
            .Columns.Add("Penalties W")
            .Columns.Add("RPPD P")
            .Columns.Add("RPPD A")
            .Columns.Add("Interest P")
            .Columns.Add("Principal P")
            .Columns.Add("A.R. B")
            .Columns.Add("Penalties B")
            .Columns.Add("RPPD B")
            .Columns.Add("UDI B")
            .Columns.Add("Principal B")
            .Columns.Add("Total")
            .Columns.Add("Status")
            .Columns.Add("BankID")
            .Columns.Add("DocumentDate")
            .Columns.Add("ReferenceN")
            .Columns.Add("Explanation")
            .Columns.Add("Attach")
        End With

        SQL_II = "SELECT "
        SQL_II &= "   MIN(ID) AS 'ID',"
        SQL_II &= "   DATE_FORMAT(IF(ORDate = '',`timestamp`,ORDate), '%m-%d-%Y') AS 'Date',"
        SQL_II &= "   IF(JVNum != '' AND ORNum = '',CONCAT('Reversal for ',IF(ORNum = '',CVNum,ORNum)),IF(JVNum != '',CONCAT('Reversal for ',IF(ORNum = '',CVNum,ORNum)),IF(GROUP_CONCAT(Remarks) LIKE '%Advance%' AND COUNT(ORNum) = 1 AND PaidFor = 'UDI' AND MIN(EntryType) = 'CREDIT','Advance Interest',IF(GROUP_CONCAT(Remarks) LIKE '%Advance%' AND MIN(EntryType) = 'CREDIT','Advance Amortization',IF(P.PaidType = 'CHECK',IF(P.CheckBank = '',P.CheckN,CONCAT('[',P.CheckBank,'] ',P.CheckN)),P.PaidType))))) AS 'Remarks',"
        SQL_II &= "   IF(JVNum != '',JVNum,IF(ORNum = '',CVNumber,ORNum)) AS 'O.R. No.',"
        SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor IN ('Principal','Penalty','Billing','RPPD','UDI','Other Income') THEN Amount END),0) AS 'Amount Paid',"
        SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor IN ('Billing','Other Income') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'A.R. P',"
        SQL_II &= "   CONCAT('(',IFNULL(SUM(CASE WHEN PaidFor = 'Penalty-W' THEN Payable - PenaltyPayable END),0),')') AS 'Penalties W',"
        SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty') THEN PenaltyPayable END),0) AS 'Penalty Balance',"
        SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor IN ('Penalty') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Penalties P',"
        SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor = 'RPPD' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'RPPD P',"
        SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor IN ('RPPD-A','RPPD-W') THEN IF(Remarks LIKE '%[Reversal]%',Amount,0 - Amount) END),0)  AS 'RPPD A',"
        SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor = 'UDI' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Interest P',"
        SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor = 'Accounts Receivable' AND EntryType = 'DEBIT' THEN Amount END),0) AS 'Accounts R',"
        If CompanyMode = 0 Then
            SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor IN ('Principal','RPPD') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Principal P',"
        Else
            SQL_II &= "   IFNULL(SUM(CASE WHEN PaidFor = 'Principal' THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'Principal P',"
        End If
        SQL_II &= "   MIN(PostStatus) AS 'Status',"
        SQL_II &= "   IFNULL(P.BankID,0) AS 'BankID', P.DocumentDate, P.ORNum2, P.Remarksx AS 'Explanation', P.Attach"
        SQL_II &= String.Format(" FROM accounting_entry LEFT JOIN (SELECT BankID, Payee_ID AS 'ReferenceN2', DocumentNumber AS 'ORNum2', DocumentNumber, IF(DocumentDate = '',NOW(),DocumentDate) AS 'DocumentDate', Explanation AS 'Remarksx', Type_Payment AS 'PaidType', CheckNumber AS 'CheckN', Attach, IFNULL((SELECT Bank FROM check_received WHERE ID = CheckID),'') AS 'CheckBank' FROM official_receipt WHERE `status` = 'ACTIVE') P ON P.ReferenceN2 = accounting_entry.ReferenceN AND P.DocumentNumber = accounting_entry.ORNum  WHERE accounting_entry.`status` IN ('ACTIVE','PENDING') AND ReferenceN = '{0}' GROUP BY CVNumber, JVNum ORDER BY DATE(IF(ORDate = '',`timestamp`,ORDate)),`ID`;", CreditNumber)
        Dim DT As DataTable = DataSource(SQL_II)
        For x As Integer = 0 To DT.Rows.Count - 1
            DT_Ledger.Rows.Add(DT(x)("ID"), DT(x)("Date"), DT(x)("Remarks"), DT(x)("O.R. No."), NegativeParenthesisV2(DT(x)("Amount Paid")), NegativeParenthesisV2(DT(x)("A.R. P")), NegativeParenthesisV2(DT(x)("Penalties P")), If(DT(x)("Penalties W").ToString.Contains("-"), DT(x)("Penalties W").ToString.Replace("-", ""), DT(x)("Penalties W")), NegativeParenthesisV2(DT(x)("RPPD P")), NegativeParenthesisV2(DT(x)("RPPD A")), NegativeParenthesisV2(DT(x)("Interest P")), NegativeParenthesisV2(DT(x)("Principal P")), DT(x)("Accounts R").ToString.Replace("-", ""), DT(x)("Penalty Balance").ToString.Replace("-", ""), 0, 0, 0, 0, DT(x)("Status"), DT(x)("BankID"), DT(x)("DocumentDate"), DT(x)("ORNum2"), DT(x)("Explanation"), DT(x)("Attach"))
        Next
        For x As Integer = 1 To DT_Ledger.Rows.Count - 1
            DT_Ledger(x)("A.R. B") = FormatNumber(NegativeNotAllowed((CDbl(DT_Ledger(x - 1)("A.R. B")) + CDbl(DT_Ledger(x)("A.R. B"))) - CDbl(DT_Ledger(x)("A.R. P"))), 2)
            Dim TotalRPPD As Double
            TotalRPPD = If(DT_Ledger(x)("RPPD A").ToString.Contains("("), CDbl(DT_Ledger(x)("RPPD A").ToString.Replace("(", "").Replace(")", "") * -1), CDbl(DT_Ledger(x)("RPPD A"))) + CDbl(DT_Ledger(x)("RPPD P") * -1)
            DT_Ledger(x)("RPPD B") = FormatNumber(CDbl(DT_Ledger(x - 1)("RPPD B")) + TotalRPPD, 2)
            DT_Ledger(x)("UDI B") = FormatNumber(CDbl(DT_Ledger(x - 1)("UDI B")) - CDbl(DT_Ledger(x)("Interest P")), 2)
            DT_Ledger(x)("Principal B") = FormatNumber(NegativeNotAllowed(CDbl(DT_Ledger(x - 1)("Principal B")) - CDbl(DT_Ledger(x)("Principal P"))), 2)
            DT_Ledger(x)("Total") = FormatNumber(NegativeNotAllowed(CDbl(DT_Ledger(x)("RPPD B")) + CDbl(DT_Ledger(x)("UDI B")) + CDbl(DT_Ledger(x)("Principal B"))), 2)
        Next
        If DT_Ledger.Rows.Count > 0 Then
            If CDbl(DT_Ledger(DT_Ledger.Rows.Count - 1)("Principal B")) = 0 And CDbl(DT_Ledger(DT_Ledger.Rows.Count - 1)("Total")) > 0 Then
                DT_Ledger.Rows.Add(0, "", "CLOSED", "", FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), FormatNumber(0, 2), "", 0, "", "", "", 0)
            End If
        End If
        For x As Integer = 0 To DT_Ledger.Rows.Count - 1

        Next

        PassdueX = 0
        Return PassdueX
    End Function

    Private Sub GridView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim Rows As New ArrayList()
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim Total_1 As Double
            Dim Total_2 As Double
            Dim Total_3 As Double
            Dim Total_4 As Double
            Dim Total_5 As Double
            Dim Total_6 As Double
            Dim Total_7 As Double
            Dim Total_8 As Double
            Dim Total_9 As Double
            Dim Total_10 As Double
            Dim Total_11 As Double
            With GridView1
                For x As Integer = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Integer = selectedRowHandles(x)
                    Total_1 += .GetRowCellValue(selectedRowHandle, "Principal")
                    Total_2 += .GetRowCellValue(selectedRowHandle, "Face Amount")
                    Total_3 += .GetRowCellValue(selectedRowHandle, "GMA")
                    Total_4 += .GetRowCellValue(selectedRowHandle, "Beginning Balance")
                    Total_5 += .GetRowCellValue(selectedRowHandle, "Ending Balance")
                    Total_6 += .GetRowCellValue(selectedRowHandle, "Current")
                    Total_7 += .GetRowCellValue(selectedRowHandle, "1-30 Days")
                    Total_8 += .GetRowCellValue(selectedRowHandle, "31-60 Days")
                    Total_9 += .GetRowCellValue(selectedRowHandle, "61-90 Days")
                    Total_10 += .GetRowCellValue(selectedRowHandle, "91-120 Days")
                    Total_11 += .GetRowCellValue(selectedRowHandle, "Over 120 Days")
                Next
                .Columns("Principal").SummaryItem.DisplayFormat = FormatNumber(Total_1, 2)
                .Columns("Face Amount").SummaryItem.DisplayFormat = FormatNumber(Total_2, 2)
                .Columns("GMA").SummaryItem.DisplayFormat = FormatNumber(Total_3, 2)
                .Columns("Beginning Balance").SummaryItem.DisplayFormat = FormatNumber(Total_4, 2)
                .Columns("Ending Balance").SummaryItem.DisplayFormat = FormatNumber(Total_5, 2)
                .Columns("Current").SummaryItem.DisplayFormat = FormatNumber(Total_6, 2)
                .Columns("1-30 Days").SummaryItem.DisplayFormat = FormatNumber(Total_7, 2)
                .Columns("31-60 Days").SummaryItem.DisplayFormat = FormatNumber(Total_8, 2)
                .Columns("61-90 Days").SummaryItem.DisplayFormat = FormatNumber(Total_9, 2)
                .Columns("91-120 Days").SummaryItem.DisplayFormat = FormatNumber(Total_10, 2)
                .Columns("Over 120 Days").SummaryItem.DisplayFormat = FormatNumber(Total_11, 2)
            End With
        Else
            With GridView1
                .Columns("Principal").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("GMA").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Beginning Balance").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Ending Balance").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Current").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("1-30 Days").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("31-60 Days").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("61-90 Days").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("91-120 Days").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Over 120 Days").SummaryItem.DisplayFormat = "{0:n2}"
            End With
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
        Dim Report As New RptAging
        With Report
            .Name = String.Format("Aging of {0} As of {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), dtpAsOf.Text)
            .lblAsOf.Text = "As of " & dtpAsOf.Text

            .XrLabel20.Text = Format(dtpAsOf.Value.AddDays(-1), "MM/01/yyyy")
            .XrLabel23.Text = Format(dtpAsOf.Value, "MM/dd/yyyy")

            .DataSource = GridControl1.DataSource
            .lblProduct.DataBindings.Add("Text", GridControl1.DataSource, "Product Type")
            .lblAccountNumber.DataBindings.Add("Text", GridControl1.DataSource, "Account Number")
            .lblBorrower.DataBindings.Add("Text", GridControl1.DataSource, "Borrower")
            .lblCI.DataBindings.Add("Text", GridControl1.DataSource, "CI")
            .lblAO.DataBindings.Add("Text", GridControl1.DataSource, "AO")
            .lblCollateral.DataBindings.Add("Text", GridControl1.DataSource, "Plate Number")
            .lblDateGranted.DataBindings.Add("Text", GridControl1.DataSource, "Date Granted")
            .lblDueDate.DataBindings.Add("Text", GridControl1.DataSource, "Due Date")
            .lblDue.DataBindings.Add("Text", GridControl1.DataSource, "Monthly Due")
            .lblTerm.DataBindings.Add("Text", GridControl1.DataSource, "Term")
            .lblFA.DataBindings.Add("Text", GridControl1.DataSource, "Face Amount")
            .lblGMA.DataBindings.Add("Text", GridControl1.DataSource, "GMA")
            .lblLastPayment.DataBindings.Add("Text", GridControl1.DataSource, "Last Payment Date")
            .lblMonthsLapsed.DataBindings.Add("Text", GridControl1.DataSource, "Months Lapsed")
            .lblRemainDays.DataBindings.Add("Text", GridControl1.DataSource, "Remaining Days")
            .lblRemainMonths.DataBindings.Add("Text", GridControl1.DataSource, "Remaining Months")
            .lblBeginning.DataBindings.Add("Text", GridControl1.DataSource, "Beginning Balance")
            .lblEnding.DataBindings.Add("Text", GridControl1.DataSource, "Ending Balance")
            .lblCurrent.DataBindings.Add("Text", GridControl1.DataSource, "Current")
            .lbl1_30.DataBindings.Add("Text", GridControl1.DataSource, "1-30 Days")
            .lbl31_60.DataBindings.Add("Text", GridControl1.DataSource, "31-60 Days")
            .lbl61_90.DataBindings.Add("Text", GridControl1.DataSource, "61-90 Days")
            .lbl91_120.DataBindings.Add("Text", GridControl1.DataSource, "91-120 Days")
            .lblOver120.DataBindings.Add("Text", GridControl1.DataSource, "Over 120 Days")
            Logs("Aging", "Print", "[SENSITIVE] Print Aging", "", "", "", "")

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
        End If

        LoadData()
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

    Private Sub BtnPrintCustomized_Click(sender As Object, e As EventArgs) Handles btnPrintCustomized.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("AGING REPORT", GridControl1)
        Logs("Aging", "Print", "[SENSITIVE] Print Aging", "", "", "", "")
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

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = GridView1.GetFocusedRowCellValue("CreditNumber")
            .Show()
        End With
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = GridView1.GetFocusedRowCellValue("CreditNumber")
            .Show()
        End With
    End Sub
End Class