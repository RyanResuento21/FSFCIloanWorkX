Imports DevExpress.XtraReports.UI
Public Class FrmAgingPastDueDetails

    Public MarketingID As String
    Public Marketing As String
    Public vPrint As Boolean
    Public PAR As Boolean
    Private Sub FrmAgingPastDueDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView4})
        FixUI(AllowStandardUI)
        GetBandedGridApperance({BandedGridView1})
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        LoadData()
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

            GetContextMenuBarFontSettings({ContextMenuBar3})

            GetButtonFontSettings({btnCancel, btnPrint})
        Catch ex As Exception
            TriggerBugReport("Aging Past Due Details - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Aging Past Due Details", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim DateCondition_1 As String
        Dim DateCondition_2 As String = ""
        If PAR Then
            If FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 0 Then
                DateCondition_1 = String.Format("DATE(PostingDate) = DATE('{0}')", Format(FrmAgingPortfolioAtRisk.dtpFrom.Value, "yyyy-MM-dd"))
                DateCondition_2 = Format(FrmAgingPortfolioAtRisk.dtpFrom.Value, "yyyy-MM-dd")
            ElseIf FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 1 Or FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 2 Or FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 3 Or FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 4 Then
                DateCondition_1 = String.Format("DATE(PostingDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(FrmAgingPortfolioAtRisk.dtpFrom.Value, "yyyy-MM-dd"), Format(FrmAgingPortfolioAtRisk.dtpTo.Value, "yyyy-MM-dd"))
                DateCondition_2 = Format(FrmAgingPortfolioAtRisk.dtpTo.Value, "yyyy-MM-dd")
            ElseIf FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 5 Or FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = -1 Then
                DateCondition_1 = String.Format("DATE(PostingDate) <= DATE('{0}')", Format(FrmAgingPortfolioAtRisk.dtpFrom.Value, "yyyy-MM-dd"))
                DateCondition_2 = Format(FrmAgingPortfolioAtRisk.dtpFrom.Value, "yyyy-MM-dd")
            End If
        Else
            If FrmAgingPastDue.cbxDisplay.SelectedIndex = 0 Then
                DateCondition_1 = String.Format("DATE(PostingDate) = DATE('{0}')", Format(FrmAgingPastDue.dtpFrom.Value, "yyyy-MM-dd"))
                DateCondition_2 = Format(FrmAgingPastDue.dtpFrom.Value, "yyyy-MM-dd")
            ElseIf FrmAgingPastDue.cbxDisplay.SelectedIndex = 1 Or FrmAgingPastDue.cbxDisplay.SelectedIndex = 2 Or FrmAgingPastDue.cbxDisplay.SelectedIndex = 3 Or FrmAgingPastDue.cbxDisplay.SelectedIndex = 4 Then
                DateCondition_1 = String.Format("DATE(PostingDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(FrmAgingPastDue.dtpFrom.Value, "yyyy-MM-dd"), Format(FrmAgingPastDue.dtpTo.Value, "yyyy-MM-dd"))
                DateCondition_2 = Format(FrmAgingPastDue.dtpTo.Value, "yyyy-MM-dd")
            ElseIf FrmAgingPastDue.cbxDisplay.SelectedIndex = 5 Or FrmAgingPastDue.cbxDisplay.SelectedIndex = -1 Then
                DateCondition_1 = String.Format("DATE(PostingDate) <= DATE('{0}')", Format(FrmAgingPastDue.dtpFrom.Value, "yyyy-MM-dd"))
                DateCondition_2 = Format(FrmAgingPastDue.dtpFrom.Value, "yyyy-MM-dd")
            End If
        End If

        Dim SQL As String = "SELECT MarketingID, CreditNumber, CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A)), '[',AccountNumber,']') AS 'Borrower', Product, AccountNumber,"
        SQL &= String.Format("     IFNULL(TIMESTAMPDIFF(DAY,'{0}',LDD),0) AS 'Remaining Months in Days',", DateCondition_2)
        If PAR Then
            SQL &= "     C.AmountApplied - IFNULL(SUM(CASE WHEN PaidFor IN ('Principal') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'END_Face Amount',"
            SQL &= "     C.AmountApplied AS 'Face Amount', "
        Else
            SQL &= "     C.Face_Amount - IFNULL(SUM(CASE WHEN PaidFor IN ('Principal','UDI','RPPD','RPPD-A','RPPD-W') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'END_Face Amount',"
            SQL &= "     C.Face_Amount AS 'Face Amount', "
        End If
        SQL &= "     1 AS 'Current_Client',"
        SQL &= "     0.0 AS 'Current_Amount',"
        SQL &= "     0 AS '1to30_Client',"
        SQL &= "     0.0 AS '1to30_Amount',"
        SQL &= "     0 AS '31to60_Client',"
        SQL &= "     0.0 AS '31to60_Amount',"
        SQL &= "     0 AS '61to90_Client',"
        SQL &= "     0.0 AS '61to90_Amount',"
        SQL &= "     0 AS '91to120_Client',"
        SQL &= "     0.0 AS '91to120_Amount',"
        SQL &= "     0 AS 'Over120_Client',"
        SQL &= "     0.0 AS 'Over120_Amount',"
        SQL &= "     0 AS 'TotalPastDue_Client',"
        SQL &= "     0.0 AS 'TotalPastDue_Amount',"
        SQL &= "     0 AS 'TotalPortfolio_Client',"
        SQL &= "     0.0 AS 'TotalPortfolio_Amount'"
        SQL &= " FROM credit_application C"
        If PAR Then
            SQL &= String.Format(" LEFT JOIN (SELECT CVNum, JVNum, ORNum, ReferenceN, Amount, PaidFor, ORDate, EntryType, Remarks FROM accounting_entry WHERE `status` IN ('ACTIVE') AND PostStatus = 'POSTED' AND PaidFor = 'Principal' AND ORDate <= '{0}') A ON A.ReferenceN = C.CreditNumber", DateCondition_2)
            SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND Released <= '{4}' AND C.PaymentRequest IN ('RELEASED','CLOSED') AND IF(C.`PaymentRequest` = 'CLOSED',(SELECT IFNULL(DATE_FORMAT(MAX(ORDate), '%M %Y'),'') FROM accounting_entry WHERE ReferenceN = C.CreditNumber AND PaidFor = 'Principal' AND `status` = 'ACTIVE') = '{4}',TRUE) AND MarketingID = '{5}' AND IF('{1}' = 'True',Branch_ID IN ({3}),Branch_ID = '{0}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') GROUP BY C.CreditNumber ORDER BY `Borrower`", FrmAgingPortfolioAtRisk.cbxBranch.SelectedValue, FrmAgingPortfolioAtRisk.cbxAllB.Checked, ValidateComboBox(FrmAgingPortfolioAtRisk.cbxBusinessCenter), Multiple_ID, DateCondition_2, MarketingID)
        Else
            SQL &= String.Format(" LEFT JOIN (SELECT CVNum, JVNum, ORNum, ReferenceN, Amount, PaidFor, ORDate, EntryType, Remarks FROM accounting_entry WHERE `status` IN ('ACTIVE') AND PostStatus = 'POSTED' AND ORDate <= '{0}') A ON A.ReferenceN = C.CreditNumber", DateCondition_2)
            SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND Released <= '{4}' AND C.PaymentRequest IN ('RELEASED','CLOSED') AND IF(C.`PaymentRequest` = 'CLOSED',(SELECT IFNULL(DATE_FORMAT(MAX(ORDate), '%M %Y'),'') FROM accounting_entry WHERE ReferenceN = C.CreditNumber AND PaidFor = 'Principal' AND `status` = 'ACTIVE') = '{4}',TRUE) AND MarketingID = '{5}' AND IF('{1}' = 'True',Branch_ID IN ({3}),Branch_ID = '{0}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') GROUP BY C.CreditNumber ORDER BY `Borrower`", FrmAgingPastDue.cbxBranch.SelectedValue, FrmAgingPastDue.cbxAllB.Checked, ValidateComboBox(FrmAgingPastDue.cbxBusinessCenter), Multiple_ID, DateCondition_2, MarketingID)
        End If
        Dim DT As DataTable = DataSource(SQL)
        For x As Integer = 0 To DT.Rows.Count - 1
            LoadAmortizationBasic(DT(x)("CreditNumber"), GridControl4)
            For y As Integer = 1 To GridView4.RowCount - 1
                If If(GridView4.GetRowCellValue(y, "Due Date").ToString = "TOTAL", 0, CDate(GridView4.GetRowCellValue(y, "Due Date")) <= CDate(DateCondition_2)) And y < GridView4.RowCount - 1 Then
                Else
                    DT(x)("Current_Amount") = If(CDbl(GridView4.GetRowCellValue(y - 1, "Loans Receivable")) > 0, CDbl(GridView4.GetRowCellValue(y - 1, "Loans Receivable")), 0) - If(CDbl(GridView4.GetRowCellValue(y - 1, "Loans Receivable")) > DT(x)("END_Face Amount"), (CDbl(GridView4.GetRowCellValue(y - 1, "Loans Receivable"))) - DT(x)("END_Face Amount"), 0)
                    If DT(x)("FACE AMOUNT") = DT(x)("Current_Amount") Then
                        Exit For
                    End If
                    DT(x)("1to30_Amount") = If(DT(x)("END_Face Amount") - DT(x)("Current_Amount") > 0 And DT(x)("Remaining Months in Days") >= -30, CDbl(MustBeNumeric(GridView4.GetRowCellValue(y - 1, "Monthly"))), 0) - If(DT(x)("Remaining Months in Days") >= -30 And DT(x)("END_Face Amount") - DT(x)("Current_Amount") < CDbl(MustBeNumeric(GridView4.GetRowCellValue(y - 1, "Monthly"))) And DT(x)("END_Face Amount") - DT(x)("Current_Amount") > 0, CDbl(MustBeNumeric(GridView4.GetRowCellValue(y - 1, "Monthly"))) - (DT(x)("END_Face Amount") - DT(x)("Current_Amount")), 0)
                    DT(x)("31to60_Amount") = If((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount") > 0 And DT(x)("Remaining Months in Days") >= -60, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 2 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("1to30_Amount")) > 0, y - 2, y - 1), "Monthly"))), 0) - If(DT(x)("Remaining Months in Days") >= -60 And (DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount") < CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 2 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("1to30_Amount")) > 0, y - 2, y - 1), "Monthly"))) And (DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount") > 0, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 2 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("1to30_Amount")) > 0, y - 2, y - 1), "Monthly"))) - ((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount")), 0)
                    Dim DownSchedule As Integer = 0
                    If CDbl(DT(x)("Current_Amount")) = 0 And CDbl(DT(x)("1to30_Amount")) = 0 Then
                        DownSchedule += 1
                    End If
                    DT(x)("61to90_Amount") = If(((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount")) - DT(x)("31to60_Amount") > 0 And DT(x)("Remaining Months in Days") >= -90, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 3 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("31to60_Amount")) > 0, y - (3 - DownSchedule), y - 1), "Monthly"))), 0) - If(DT(x)("Remaining Months in Days") >= -90 And ((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount")) - DT(x)("31to60_Amount") < CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 3 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("31to60_Amount")) > 0, y - (3 - DownSchedule), y - 1), "Monthly"))) And ((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount")) - DT(x)("31to60_Amount") > 0, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 3 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("31to60_Amount")) > 0, y - (3 - DownSchedule), y - 1), "Monthly"))) - (((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount")) - DT(x)("31to60_Amount")), 0)
                    If CDbl(DT(x)("Current_Amount")) = 0 And CDbl(DT(x)("31to60_Amount")) = 0 Then
                        DownSchedule += 1
                    End If
                    DT(x)("91to120_Amount") = If((((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount")) - DT(x)("31to60_Amount")) - DT(x)("61to90_Amount") > 0 And DT(x)("Remaining Months in Days") >= -120, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 4 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("61to90_Amount")) > 0, y - (4 - DownSchedule), y - 1), "Monthly"))), 0) - If(DT(x)("Remaining Months in Days") >= -120 And (((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount")) - DT(x)("31to60_Amount")) - DT(x)("61to90_Amount") < CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 4 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("61to90_Amount")) > 0, y - (4 - DownSchedule), y - 1), "Monthly"))) And (((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount")) - DT(x)("31to60_Amount")) - DT(x)("61to90_Amount") > 0, CDbl(MustBeNumeric(GridView4.GetRowCellValue(If(y - 4 > 0 And y <= GridView4.RowCount - 1 And CDbl(DT(x)("61to90_Amount")) > 0, y - (4 - DownSchedule), y - 1), "Monthly"))) - (((DT(x)("END_Face Amount") - DT(x)("Current_Amount")) - DT(x)("1to30_Amount")) - DT(x)("31to60_Amount")) - DT(x)("61to90_Amount"), 0)
                    DT(x)("TotalPastDue_Amount") = NegativeNotAllowed(DT(x)("END_Face Amount") - DT(x)("Current_Amount"))
                    DT(x)("Over120_Amount") = NegativeNotAllowed(DT(x)("TotalPastDue_Amount") - (DT(x)("1to30_Amount") + DT(x)("31to60_Amount") + DT(x)("61to90_Amount") + DT(x)("91to120_Amount")))
                    If DT(x)("1to30_Amount") > 0 Then
                        DT(x)("1to30_Client") = 1
                    End If
                    If DT(x)("31to60_Amount") > 0 Then
                        DT(x)("31to60_Client") = 1
                    End If
                    If DT(x)("61to90_Amount") > 0 Then
                        DT(x)("61to90_Client") = 1
                    End If
                    If DT(x)("91to120_Amount") > 0 Then
                        DT(x)("91to120_Client") = 1
                    End If
                    If DT(x)("Over120_Amount") > 0 Then
                        DT(x)("Over120_Client") = 1
                    End If
                    If DT(x)("Over120_Amount") > 0 Or DT(x)("91to120_Amount") > 0 Or DT(x)("61to90_Amount") > 0 Or DT(x)("31to60_Amount") > 0 Or DT(x)("1to30_Amount") > 0 Then
                        DT(x)("TotalPastDue_Client") = 1
                    End If
                    DT(x)("TotalPortfolio_Client") = DT(x)("TotalPastDue_Client") + DT(x)("Current_Client")
                    DT(x)("TotalPortfolio_Amount") = DT(x)("TotalPastDue_Amount") + DT(x)("Current_Amount")
                    Exit For
                End If
            Next
        Next
        GridControl1.DataSource = DT
        Cursor = Cursors.Default
    End Sub

    Public Sub LoadAmortizationBasic(CreditNumber As String, Grid As DevExpress.XtraGrid.GridControl)
        Dim Temp_DT As DataTable = DataSource(String.Format("SELECT IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', FORMAT(LoansReceivable,2) AS 'Loans Receivable' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber))
        'Temp_DT = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', IF(`No` = '','',FORMAT(InterestIncome,2)) AS 'Interest Income', IF(`No` = '','',FORMAT(RPPD,2)) AS 'RPPD', IF(`No` = '','',FORMAT(PrincipalAllocation,2)) AS 'Principal Allocation', FORMAT(OutstandingPrincipal,2) AS 'Outstanding Principal', FORMAT(Total_RPPD,2) AS 'Total_RPPD', FORMAT(UnearnIncome,2) AS 'Unearn Income', FORMAT(LoansReceivable,2) AS 'Loans Receivable', IF(`No` = '','',FORMAT(Penalty,2)) AS 'Penalty', FORMAT(PenaltyBalance,2) AS 'Penalty Balance' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber))
        Dim T_Monthly As Double
        'Dim T_Interest As Double 
        'Dim T_RPPD As Double 
        'Dim T_Principal As Double 
        'Dim T_Penalty As Double 
        For x As Integer = 1 To Temp_DT.Rows.Count - 1
            T_Monthly += CDbl(Temp_DT(x)("Monthly"))
        Next
        'Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, ), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), 0, 0, 0, 0, Format(T_Penalty, 2), 0)
        Temp_DT.Rows.Add("TOTAL", FormatNumber(T_Monthly, 2), 0)
        Grid.DataSource = Temp_DT
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptAgingPastDueDetails
        With Report
            Dim DateFilter As String = ""
            If PAR Then
                If FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 0 Then
                    DateFilter = String.Format("For {0}", FrmAgingPortfolioAtRisk.dtpFrom.Text)
                ElseIf FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 1 Or FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 2 Or FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 3 Or FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 4 Then
                    DateFilter = String.Format("For {0} - {1}", FrmAgingPortfolioAtRisk.dtpFrom.Text, FrmAgingPortfolioAtRisk.dtpTo.Text)
                ElseIf FrmAgingPortfolioAtRisk.cbxDisplay.SelectedIndex = 5 Then
                    DateFilter = String.Format("As of {0}", FrmAgingPortfolioAtRisk.dtpFrom.Text)
                End If
                .Name = String.Format("AGING OF PORTFOLIO AT RISK (PRINCIPAL) REPORT of {0} for {1} {2}", Marketing, If(FrmAgingPortfolioAtRisk.cbxAllB.Checked, "All Branches", FrmAgingPortfolioAtRisk.cbxBranch.Text), DateFilter)
                .lblTitle.Text = String.Format("AGING OF PORTFOLIO AT RISK (PRINCIPAL) REPORT of {0} for {1} {2}", Marketing, If(FrmAgingPortfolioAtRisk.cbxAllB.Checked, "All Branches", FrmAgingPortfolioAtRisk.cbxBranch.Text), DateFilter)
                .lblBranch.Text = If(FrmAgingPortfolioAtRisk.cbxAllB.Checked, "ALL BRANCHES", FrmAgingPortfolioAtRisk.cbxBranch.Text)
            Else
                If FrmAgingPastDue.cbxDisplay.SelectedIndex = 0 Then
                    DateFilter = String.Format("For {0}", FrmAgingPastDue.dtpFrom.Text)
                ElseIf FrmAgingPastDue.cbxDisplay.SelectedIndex = 1 Or FrmAgingPastDue.cbxDisplay.SelectedIndex = 2 Or FrmAgingPastDue.cbxDisplay.SelectedIndex = 3 Or FrmAgingPastDue.cbxDisplay.SelectedIndex = 4 Then
                    DateFilter = String.Format("For {0} - {1}", FrmAgingPastDue.dtpFrom.Text, FrmAgingPastDue.dtpTo.Text)
                ElseIf FrmAgingPastDue.cbxDisplay.SelectedIndex = 5 Then
                    DateFilter = String.Format("As of {0}", FrmAgingPastDue.dtpFrom.Text)
                End If
                .Name = String.Format("AGING OF PAST DUE REPORT of {0} for {1} {2}", Marketing, If(FrmAgingPastDue.cbxAllB.Checked, "All Branches", FrmAgingPastDue.cbxBranch.Text), DateFilter)
                .lblTitle.Text = String.Format("AGING OF PAST DUE REPORT of {0} for {1} {2}", Marketing, If(FrmAgingPastDue.cbxAllB.Checked, "All Branches", FrmAgingPastDue.cbxBranch.Text), DateFilter)
                .lblBranch.Text = If(FrmAgingPastDue.cbxAllB.Checked, "ALL BRANCHES", FrmAgingPastDue.cbxBranch.Text)
            End If
            .lblAsOf.Text = DateFilter
            .DataSource = GridControl1.DataSource
            .lblBorrower.DataBindings.Add("Text", GridControl1.DataSource, "Borrower")
            .lblCurrent_Client.DataBindings.Add("Text", GridControl1.DataSource, "Current_Client")
            .lblCurrent_Amount.DataBindings.Add("Text", GridControl1.DataSource, "Current_Amount")
            .lbl1to30_Client.DataBindings.Add("Text", GridControl1.DataSource, "1to30_Client")
            .lbl1to30_Amount.DataBindings.Add("Text", GridControl1.DataSource, "1to30_Amount")
            .lbl31to60_Client.DataBindings.Add("Text", GridControl1.DataSource, "31to60_Client")
            .lbl31to60_Amount.DataBindings.Add("Text", GridControl1.DataSource, "31to60_Amount")
            .lbl61to90_Client.DataBindings.Add("Text", GridControl1.DataSource, "61to90_Client")
            .lbl61to90_Amount.DataBindings.Add("Text", GridControl1.DataSource, "61to90_Amount")
            .lbl91to120_Client.DataBindings.Add("Text", GridControl1.DataSource, "91to120_Client")
            .lbl91to120_Amount.DataBindings.Add("Text", GridControl1.DataSource, "91to120_Amount")
            .lblOver120_Client.DataBindings.Add("Text", GridControl1.DataSource, "Over120_Client")
            .lblOver120_Amount.DataBindings.Add("Text", GridControl1.DataSource, "Over120_Amount")
            .lblTotalPastDue_Client.DataBindings.Add("Text", GridControl1.DataSource, "TotalPastDue_Client")
            .lblTotalPastDue_Amount.DataBindings.Add("Text", GridControl1.DataSource, "TotalPastDue_Amount")
            .lblTotalPortfolio_Client.DataBindings.Add("Text", GridControl1.DataSource, "TotalPortfolio_Client")
            .lblTotalPortfolio_Amount.DataBindings.Add("Text", GridControl1.DataSource, "TotalPortfolio_Amount")

            .lblCurrent_ClientT.DataBindings.Add("Text", GridControl1.DataSource, "Current_Client")
            .lblCurrent_AmountT.DataBindings.Add("Text", GridControl1.DataSource, "Current_Amount")
            .lbl1to30_ClientT.DataBindings.Add("Text", GridControl1.DataSource, "1to30_Client")
            .lbl1to30_AmountT.DataBindings.Add("Text", GridControl1.DataSource, "1to30_Amount")
            .lbl31to60_ClientT.DataBindings.Add("Text", GridControl1.DataSource, "31to60_Client")
            .lbl31to60_AmountT.DataBindings.Add("Text", GridControl1.DataSource, "31to60_Amount")
            .lbl61to90_ClientT.DataBindings.Add("Text", GridControl1.DataSource, "61to90_Client")
            .lbl61to90_AmountT.DataBindings.Add("Text", GridControl1.DataSource, "61to90_Amount")
            .lbl91to120_ClientT.DataBindings.Add("Text", GridControl1.DataSource, "91to120_Client")
            .lbl91to120_AmountT.DataBindings.Add("Text", GridControl1.DataSource, "91to120_Amount")
            .lblOver120_ClientT.DataBindings.Add("Text", GridControl1.DataSource, "Over120_Client")
            .lblOver120_AmountT.DataBindings.Add("Text", GridControl1.DataSource, "Over120_Amount")
            .lblTotalPastDue_ClientT.DataBindings.Add("Text", GridControl1.DataSource, "TotalPastDue_Client")
            .lblTotalPastDue_AmountT.DataBindings.Add("Text", GridControl1.DataSource, "TotalPastDue_Amount")
            .lblTotalPortfolio_ClientT.DataBindings.Add("Text", GridControl1.DataSource, "TotalPortfolio_Client")
            .lblTotalPortfolio_AmountT.DataBindings.Add("Text", GridControl1.DataSource, "TotalPortfolio_Amount")
            Logs("Aging Past Due Details", "Print", "[SENSITIVE] Print Aging Past Due Details", "", "", "", "")

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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
            .Show()
        End With
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles BandedGridView1.DoubleClick
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
            .Show()
        End With
    End Sub

    Private Sub ISOA_Click(sender As Object, e As EventArgs) Handles iSOA.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim SOA As New FrmSOA
        With SOA
            .From_JV_DTS = True
            .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
            .dtpAsOf.Value = FrmPerformanceReport.dtpFrom.Value
            .cbxCreditApplication.Enabled = False
            .ShowDialog()
        End With
    End Sub

    Private Sub ILedgerCard_Click(sender As Object, e As EventArgs) Handles iLedgerCard.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("CreditNumber").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If BandedGridView1.RowCount > 0 Then
            Dim Ledger As New FrmLedgerCard
            With Ledger
                .CreditNumber = BandedGridView1.GetFocusedRowCellValue("CreditNumber")
                .AccountNumber = BandedGridView1.GetFocusedRowCellValue("AccountNumber")
                .Product = BandedGridView1.GetFocusedRowCellValue("Product")
                .Borrower = BandedGridView1.GetFocusedRowCellValue("Borrower")
                .vPrint = vPrint
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub
End Class