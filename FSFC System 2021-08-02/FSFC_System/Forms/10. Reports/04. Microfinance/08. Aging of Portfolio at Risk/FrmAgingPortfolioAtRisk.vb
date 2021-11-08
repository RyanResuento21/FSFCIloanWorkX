Imports DevExpress.XtraReports.UI
Public Class FrmAgingPortfolioAtRisk

    Public vPrint As Boolean
    Dim FirstLoad As Boolean

    Private Sub FrmAgingPortfolioAtRisk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView4})
        FixUI(AllowStandardUI)
        GetBandedGridApperance({BandedGridView1})
        GetBandedGridApperance({BandedGridView1})
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 5

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource(String.Format("SELECT ID, Branch FROM branch WHERE `status` = 'ACTIVE' AND FIND_IN_SET(ID,'{0}') ORDER BY BranchID;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
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

            GetLabelFontSettings({LabelX1, LabelX40, lblFrom, LabelX41})

            GetCheckBoxFontSettings({cbxAllB, cbxAll})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})

            GetContextMenuBarFontSettings({ContextMenuBar3})
        Catch ex As Exception
            TriggerBugReport("Aging Portfolio at Risk - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Aging Portfolio At Risk", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim DateCondition_1 As String
        Dim DateCondition_2 As String = ""
        If cbxDisplay.SelectedIndex = 0 Then
            DateCondition_1 = String.Format("DATE(PostingDate) = DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_2 = Format(dtpFrom.Value, "yyyy-MM-dd")
        ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
            DateCondition_1 = String.Format("DATE(PostingDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))
            DateCondition_2 = Format(dtpTo.Value, "yyyy-MM-dd")
        ElseIf cbxDisplay.SelectedIndex = 5 Or cbxDisplay.SelectedIndex = -1 Then
            DateCondition_1 = String.Format("DATE(PostingDate) <= DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_2 = Format(dtpFrom.Value, "yyyy-MM-dd")
        End If

        Dim SQL As String = "SELECT MarketingID, CreditNumber, (SELECT CONCAT(IF(prefix = '','',CONCAT(prefix, ' ')), IF(first_name = '','',CONCAT(first_name, ' ')), IF(middle_name = '','',CONCAT(middle_name, ' ')), IF(last_name = '','',CONCAT(last_name, ' ')), suffix) AS 'Name' FROM employee_setup WHERE emp_code = MarketingID LIMIT 1) AS 'Account Officer',"
        SQL &= String.Format("     IFNULL(TIMESTAMPDIFF(DAY,'{0}',LDD),0) AS 'Remaining Months in Days',", DateCondition_2)
        SQL &= "     C.AmountApplied - IFNULL(SUM(CASE WHEN PaidFor IN ('Principal') THEN IF(EntryType = 'CREDIT',Amount,0 - Amount) END),0) AS 'END_Face Amount',"
        SQL &= "     C.AmountApplied AS 'Face Amount', "
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
        SQL &= String.Format(" LEFT JOIN (SELECT CVNum, JVNum, ORNum, ReferenceN, Amount, PaidFor, ORDate, EntryType, Remarks FROM accounting_entry WHERE `status` IN ('ACTIVE') AND PostStatus = 'POSTED' AND PaidFor = 'Principal' AND ORDate <= '{0}') A ON A.ReferenceN = C.CreditNumber", DateCondition_2)
        SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND Released <= '{4}' AND C.PaymentRequest IN ('RELEASED','CLOSED') AND IF(C.`PaymentRequest` = 'CLOSED',(SELECT IFNULL(DATE_FORMAT(MAX(ORDate), '%M %Y'),'') FROM accounting_entry WHERE ReferenceN = C.CreditNumber AND PaidFor = 'Principal' AND `status` = 'ACTIVE') = '{4}',TRUE) AND MarketingID != '' AND IF('{1}' = 'True',Branch_ID IN ({3}),Branch_ID = '{0}') AND IF('{2}' = '0',TRUE,BusinessID = '{2}') GROUP BY C.CreditNumber ORDER BY `Account Officer`", cbxBranch.SelectedValue, cbxAllB.Checked, ValidateComboBox(cbxBusinessCenter), Multiple_ID, DateCondition_2)
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
        Dim DT_Summary As DataTable = DataSource("SELECT '' AS 'MarketingID', '' AS 'CreditNumber', '' AS 'Account Officer', 1 AS 'Current_Client', 0.0 AS 'Current_Amount', 0 AS '1to30_Client', 0.0 AS '1to30_Amount', 0 AS '31to60_Client', 0.0 AS '31to60_Amount', 0 AS '61to90_Client', 0.0 AS '61to90_Amount', 0 AS '91to120_Client', 0.0 AS '91to120_Amount', 0 AS 'Over120_Client', 0.0 AS 'Over120_Amount', 0 AS 'TotalPastDue_Client', 0.0 AS 'TotalPastDue_Amount', 0 AS 'TotalPortfolio_Client', 0.0 AS 'TotalPortfolio_Amount' LIMIT 0")
        For x As Integer = 0 To DT.Rows.Count - 1
            If x = 0 Then
                DT_Summary.Rows.Add(DT(x)("MarketingID"), DT(x)("CreditNumber"), DT(x)("Account Officer"), CDbl(DT(x)("Current_Client")), CDbl(DT(x)("Current_Amount")), CDbl(DT(x)("1to30_Client")), CDbl(DT(x)("1to30_Amount")), CDbl(DT(x)("31to60_Client")), CDbl(DT(x)("31to60_Amount")), CDbl(DT(x)("61to90_Client")), CDbl(DT(x)("61to90_Amount")), CDbl(DT(x)("91to120_Client")), CDbl(DT(x)("91to120_Amount")), CDbl(DT(x)("Over120_Client")), CDbl(DT(x)("Over120_Amount")), CDbl(DT(x)("TotalPastDue_Client")), CDbl(DT(x)("TotalPastDue_Amount")), CDbl(DT(x)("TotalPortfolio_Client")), CDbl(DT(x)("TotalPortfolio_Amount")))
            Else
                If DT_Summary(DT_Summary.Rows.Count - 1)("MarketingID") = DT(x)("MarketingID") Then
                    DT_Summary(DT_Summary.Rows.Count - 1)("Current_Client") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("Current_Client")) + CDbl(DT(x)("Current_Client"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("Current_Amount") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("Current_Amount")) + CDbl(DT(x)("Current_Amount"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("1to30_Client") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("1to30_Client")) + CDbl(DT(x)("1to30_Client"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("1to30_Amount") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("1to30_Amount")) + CDbl(DT(x)("1to30_Amount"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("31to60_Client") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("31to60_Client")) + CDbl(DT(x)("31to60_Client"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("31to60_Amount") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("31to60_Amount")) + CDbl(DT(x)("31to60_Amount"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("61to90_Client") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("61to90_Client")) + CDbl(DT(x)("61to90_Client"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("61to90_Amount") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("61to90_Amount")) + CDbl(DT(x)("61to90_Amount"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("91to120_Client") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("91to120_Client")) + CDbl(DT(x)("91to120_Client"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("91to120_Amount") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("91to120_Amount")) + CDbl(DT(x)("91to120_Amount"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("Over120_Client") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("Over120_Client")) + CDbl(DT(x)("Over120_Client"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("Over120_Amount") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("Over120_Amount")) + CDbl(DT(x)("Over120_Amount"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("TotalPastDue_Client") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("TotalPastDue_Client")) + CDbl(DT(x)("TotalPastDue_Client"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("TotalPastDue_Amount") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("TotalPastDue_Amount")) + CDbl(DT(x)("TotalPastDue_Amount"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("TotalPortfolio_Client") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("TotalPortfolio_Client")) + CDbl(DT(x)("TotalPortfolio_Client"))
                    DT_Summary(DT_Summary.Rows.Count - 1)("TotalPortfolio_Amount") = CDbl(DT_Summary(DT_Summary.Rows.Count - 1)("TotalPortfolio_Amount")) + CDbl(DT(x)("TotalPortfolio_Amount"))
                Else
                    DT_Summary.Rows.Add(DT(x)("MarketingID"), DT(x)("CreditNumber"), DT(x)("Account Officer"), CDbl(DT(x)("Current_Client")), CDbl(DT(x)("Current_Amount")), CDbl(DT(x)("1to30_Client")), CDbl(DT(x)("1to30_Amount")), CDbl(DT(x)("31to60_Client")), CDbl(DT(x)("31to60_Amount")), CDbl(DT(x)("61to90_Client")), CDbl(DT(x)("61to90_Amount")), CDbl(DT(x)("91to120_Client")), CDbl(DT(x)("91to120_Amount")), CDbl(DT(x)("Over120_Client")), CDbl(DT(x)("Over120_Amount")), CDbl(DT(x)("TotalPastDue_Client")), CDbl(DT(x)("TotalPastDue_Amount")), CDbl(DT(x)("TotalPortfolio_Client")), CDbl(DT(x)("TotalPortfolio_Amount")))
                End If
            End If
        Next
        GridControl1.DataSource = DT_Summary
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
        Dim Report As New rptAgingPastDue
        With Report
            Dim DateFilter As String = ""
            If cbxDisplay.SelectedIndex = 0 Then
                DateFilter = String.Format("For {0}", dtpFrom.Text)
            ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
                DateFilter = String.Format("For {0} - {1}", dtpFrom.Text, dtpTo.Text)
            ElseIf cbxDisplay.SelectedIndex = 5 Then
                DateFilter = String.Format("As of {0}", dtpFrom.Text)
            End If

            .Name = String.Format("AGING OF PORTFOLIO AT RISK REPORT of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), DateFilter)
            .lblBranch.Text = If(cbxAllB.Checked, "ALL BRANCHES", cbxBranch.Text)
            .lblTitle.Text = "AGING OF PORTFOLIO AT RISK REPORT"
            .lblAsOf.Text = DateFilter
            .DataSource = GridControl1.DataSource
            .lblAccountOfficer.DataBindings.Add("Text", GridControl1.DataSource, "Account Officer")
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
            Logs("Aging Portfolio At Risk", "Print", "[SENSITIVE] Print Aging Portfolio At Risk", "", "", "", "")

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
        BandedGridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting(lblTitle.Text, GridControl1)
        Logs("Aging Portfolio At Risk", "Print", "[SENSITIVE] Print Aging Portfolio At Risk", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        With cbxBusinessCenter
            .DataSource = DataSource(String.Format("SELECT ID, BusinessCode, BusinessCenter FROM business_center WHERE `status` = 'ACTIVE' AND BranchID = '{0}';", cbxBranch.SelectedValue))
            If .Items.Count > 0 Then
                .Enabled = True
            Else
                .Enabled = False
            End If
            .SelectedIndex = -1
        End With
    End Sub

    Private Sub CbxBranch_TextChanged(sender As Object, e As EventArgs) Handles cbxBranch.TextChanged
        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            cbxBusinessCenter.Text = ""
            cbxBusinessCenter.Enabled = False
        End If
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
        Else
            cbxDisplay.SelectedIndex = 5
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)

            dtpFrom.Value = monday
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = monday.AddDays(6)
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            dtpFrom.Value = Date.Now
            lblFrom.Text = "As Of :"
            LabelX41.Visible = False
            dtpTo.Visible = False
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub IDetails_Click(sender As Object, e As EventArgs) Handles iDetails.Click
        Try
            If BandedGridView1.GetFocusedRowCellValue("MarketingID") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Details As New FrmAgingPastDueDetails
        With Details
            .MarketingID = BandedGridView1.GetFocusedRowCellValue("MarketingID")
            .Marketing = BandedGridView1.GetFocusedRowCellValue("Account Officer").ToString
            .lblTitle.Text = "AGING OF PORTFOLIO AT RISK (PRINCIPAL) REPORT OF " & BandedGridView1.GetFocusedRowCellValue("Account Officer").ToString
            .PAR = True
            .vPrint = vPrint
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class