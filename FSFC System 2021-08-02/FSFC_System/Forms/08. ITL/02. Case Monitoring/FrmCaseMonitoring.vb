Imports DevExpress.XtraCharts
Imports DevExpress.XtraReports.UI
Public Class FrmCaseMonitoring

    Public vPrint As Boolean

    Private Sub FrmCaseMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBandedGridApperance({BandedGridView1, BandedGridView2, BandedGridView3, BandedGridView4, BandedGridView5, BandedGridView6})
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        With Chart1
            .Location = New Point(13, 278)
            .Size = New Point(1140, 279)
        End With

        dtpAsOf.Value = Date.Now
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

            GetLabelFontSettings({LabelX15, LabelX53, LabelX54, LabelX55, LabelX56, LabelX57, LabelX58, lblOnGoing_A, lblDecided_A, lblExecuted_A, lblDismissed_A, lblArchieved_A, lblTotal_A, lblOnGoing_BV, lblDecided_BV, lblExecuted_BV, lblDismissed_BV, lblArchieved_BV, lblTotal_BV, lblOnGoing_P, lblDecided_P, lblExecuted_P, lblDismissed_P, lblArchieved_P, lblTotal_P, lblOnGoing_A_L1, lblDecided_A_L1, lblExecuted_A_L1, lblDismissed_A_L1, lblArchieved_A_L1, lblTotal_A_L1, lblOnGoing_BV_L1, lblDecided_BV_L1, lblExecuted_BV_L1, lblDismissed_BV_L1, lblArchieved_BV_L1, lblTotal_BV_L1, lblOnGoing_P_L1, lblDecided_P_L1, lblExecuted_P_L1, lblDismissed_P_L1, lblArchieved_P_L1, lblTotal_P_L1, lblOnGoing_A_L2, lblDecided_A_L2, lblExecuted_A_L2, lblDismissed_A_L2, lblArchieved_A_L2, lblTotal_A_L2, lblOnGoing_BV_L2, lblDecided_BV_L2, lblExecuted_BV_L2, lblDismissed_BV_L2, lblArchieved_BV_L2, lblTotal_BV_L2, lblOnGoing_P_L2, lblDecided_P_L2, lblExecuted_P_L2, lblDismissed_P_L2, lblArchieved_P_L2, lblTotal_P_L2})

            GetLabelWithBackgroundFontSettings({LabelX59, LabelX60, LabelX61, LabelX62, LabelX24, LabelX23, LabelX22, LabelX45, LabelX44, LabelX43})

            GetLabelWithBackgroundFontSettingsNoBorder({lblCurrent, lblLM1, lblLM2})

            GetDateTimeInputFontSettings({dtpAsOf})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint})

            GetChartTitleControlFontSettings({Chart1})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Case Monitoring - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Case Monitoring", lblTitle.Text)
    End Sub

    Private Sub LoadSummary()
        Cursor = Cursors.WaitCursor
        lblCurrent.Text = Format(dtpAsOf.Value, "MMMM, yyyy")
        lblLM1.Text = "Last Month " & Format(dtpAsOf.Value.AddMonths(-1), "MMMM, yyyy")
        lblLM2.Text = "2 Months Ago " & Format(dtpAsOf.Value.AddMonths(-2), "MMMM, yyyy")
        Dim SQL As String = "SELECT "
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'ON GOING CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Ongoing Account',", Format(dtpAsOf.Value, "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'DECIDED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Decided Account', ", Format(dtpAsOf.Value, "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'EXECUTED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Executed Account', ", Format(dtpAsOf.Value, "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'DISMISSED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Dismissed Account', ", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'ARCHIVED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Archived Account',", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))

        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'ON GOING CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Ongoing Account L1',", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'DECIDED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Decided Account L1', ", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'EXECUTED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Executed Account L1', ", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'DISMISSED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Dismissed Account L1', ", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'ARCHIVED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Archived Account L1',", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))

        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'ON GOING CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Ongoing Account L2',", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'DECIDED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Decided Account L2', ", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'EXECUTED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Executed Account L2', ", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'DISMISSED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Dismissed Account L2', ", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(COUNT(DISTINCT(CASE WHEN Category(D.CategoryID) = 'ARCHIVED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN M.ID END)),0),0) AS 'Archived Account L2',", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))

        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'ON GOING CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Ongoing BV',", Format(dtpAsOf.Value, "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'DECIDED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Decided BV', ", Format(dtpAsOf.Value, "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'EXECUTED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Executed BV', ", Format(dtpAsOf.Value, "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'DISMISSED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Dismissed BV', ", Format(dtpAsOf.Value, "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'ARCHIVED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Archived BV', ", Format(dtpAsOf.Value, "yyyy-MM-dd"), Format(dtpAsOf.Value, "yyyy-MM-01"))

        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'ON GOING CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Ongoing BV L1',", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'DECIDED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Decided BV L1', ", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'EXECUTED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Executed BV L1', ", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'DISMISSED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Dismissed BV L1', ", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'ARCHIVED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Archived BV L1', ", Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-1), "yyyy-MM-01"))

        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'ON GOING CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Ongoing BV L2',", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'DECIDED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Decided BV L2', ", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'EXECUTED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Executed BV L2', ", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'DISMISSED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Dismissed BV L2', ", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'ARCHIVED CASE' AND DATE(MovementDate) BETWEEN '{1}' AND LAST_DAY('{0}') THEN Ledger_Balance_II(M.AccountNumber, LAST_DAY('{0}'),M.MortgageID) END)),0),2) AS 'Archived BV L2' ", Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-dd"), Format(dtpAsOf.Value.AddMonths(-2), "yyyy-MM-01"))

        SQL &= String.Format(" FROM case_main M INNER JOIN (SELECT ID, CaseID, MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND BranchID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT As DataTable = DataSource(SQL)
        If DT.Rows.Count > 0 Then
            Dim TotalA As Integer
            Dim TotalA_L1 As Integer
            Dim TotalA_L2 As Integer
            TotalA = CInt(DT(0)("Ongoing Account")) + CInt(DT(0)("Decided Account")) + CInt(DT(0)("Executed Account")) + CInt(DT(0)("Dismissed Account")) + CInt(DT(0)("Archived Account"))
            TotalA_L1 = CInt(DT(0)("Ongoing Account L1")) + CInt(DT(0)("Decided Account L1")) + CInt(DT(0)("Executed Account L1")) + CInt(DT(0)("Dismissed Account L1")) + CInt(DT(0)("Archived Account L1"))
            TotalA_L2 = CInt(DT(0)("Ongoing Account L2")) + CInt(DT(0)("Decided Account L2")) + CInt(DT(0)("Executed Account L2")) + CInt(DT(0)("Dismissed Account L2")) + CInt(DT(0)("Archived Account L2"))
            'Count ************************************
            lblOnGoing_A.Text = DT(0)("Ongoing Account")
            lblDecided_A.Text = DT(0)("Decided Account")
            lblExecuted_A.Text = DT(0)("Executed Account")
            lblDismissed_A.Text = DT(0)("Dismissed Account")
            lblArchieved_A.Text = DT(0)("Archived Account")
            lblTotal_A.Text = TotalA

            lblOnGoing_A_L1.Text = DT(0)("Ongoing Account L1")
            lblDecided_A_L1.Text = DT(0)("Decided Account L1")
            lblExecuted_A_L1.Text = DT(0)("Executed Account L1")
            lblDismissed_A_L1.Text = DT(0)("Dismissed Account L1")
            lblArchieved_A_L1.Text = DT(0)("Archived Account L1")
            lblTotal_A_L1.Text = TotalA_L1

            lblOnGoing_A_L2.Text = DT(0)("Ongoing Account L2")
            lblDecided_A_L2.Text = DT(0)("Decided Account L2")
            lblExecuted_A_L2.Text = DT(0)("Executed Account L2")
            lblDismissed_A_L2.Text = DT(0)("Dismissed Account L2")
            lblArchieved_A_L2.Text = DT(0)("Archived Account L2")
            lblTotal_A_L2.Text = TotalA_L2
            'Count ************************************

            'Book Value ************************************
            lblOnGoing_BV.Text = DT(0)("Ongoing BV")
            lblDecided_BV.Text = DT(0)("Decided BV")
            lblExecuted_BV.Text = DT(0)("Executed BV")
            lblDismissed_BV.Text = DT(0)("Dismissed BV")
            lblArchieved_BV.Text = DT(0)("Archived BV")
            lblTotal_BV.Text = FormatNumber(CDbl(DT(0)("Ongoing BV")) + CDbl(DT(0)("Decided BV")) + CDbl(DT(0)("Executed BV")) + CDbl(DT(0)("Dismissed BV")) + CDbl(DT(0)("Archived BV")), 2)

            lblOnGoing_BV_L1.Text = DT(0)("Ongoing BV L1")
            lblDecided_BV_L1.Text = DT(0)("Decided BV L1")
            lblExecuted_BV_L1.Text = DT(0)("Executed BV L1")
            lblDismissed_BV_L1.Text = DT(0)("Dismissed BV L1")
            lblArchieved_BV_L1.Text = DT(0)("Archived BV L1")
            lblTotal_BV_L1.Text = FormatNumber(CDbl(DT(0)("Ongoing BV L1")) + CDbl(DT(0)("Decided BV L1")) + CDbl(DT(0)("Executed BV L1")) + CDbl(DT(0)("Dismissed BV L1")) + CDbl(DT(0)("Archived BV L1")), 2)

            lblOnGoing_BV_L2.Text = DT(0)("Ongoing BV L2")
            lblDecided_BV_L2.Text = DT(0)("Decided BV L2")
            lblExecuted_BV_L2.Text = DT(0)("Executed BV L2")
            lblDismissed_BV_L2.Text = DT(0)("Dismissed BV L2")
            lblArchieved_BV_L2.Text = DT(0)("Archived BV L2")
            lblTotal_BV_L2.Text = FormatNumber(CDbl(DT(0)("Ongoing BV L2")) + CDbl(DT(0)("Decided BV L2")) + CDbl(DT(0)("Executed BV L2")) + CDbl(DT(0)("Dismissed BV L2")) + CDbl(DT(0)("Archived BV L2")), 2)
            'Book Value ************************************

            'Percentage ************************************
            lblOnGoing_P.Text = FormatNumber((DT(0)("Ongoing Account") / TotalA) * 100, 2) & " %"
            lblDecided_P.Text = FormatNumber((DT(0)("Decided Account") / TotalA) * 100, 2) & " %"
            lblExecuted_P.Text = FormatNumber((DT(0)("Executed Account") / TotalA) * 100, 2) & " %"
            lblDismissed_P.Text = FormatNumber((DT(0)("Dismissed Account") / TotalA) * 100, 2) & " %"
            lblArchieved_P.Text = FormatNumber((DT(0)("Archived Account") / TotalA) * 100, 2) & " %"
            lblTotal_P.Text = FormatNumber((TotalA / TotalA) * 100, 2) & " %"

            lblOnGoing_P_L1.Text = FormatNumber((DT(0)("Ongoing Account L1") / TotalA_L1) * 100, 2) & " %"
            lblDecided_P_L1.Text = FormatNumber((DT(0)("Decided Account L1") / TotalA_L1) * 100, 2) & " %"
            lblExecuted_P_L1.Text = FormatNumber((DT(0)("Executed Account L1") / TotalA_L1) * 100, 2) & " %"
            lblDismissed_P_L1.Text = FormatNumber((DT(0)("Dismissed Account L1") / TotalA_L1) * 100, 2) & " %"
            lblArchieved_P_L1.Text = FormatNumber((DT(0)("Archived Account L1") / TotalA_L1) * 100, 2) & " %"
            lblTotal_P_L1.Text = FormatNumber((TotalA_L1 / TotalA_L1) * 100, 2) & " %"

            lblOnGoing_P_L2.Text = FormatNumber((DT(0)("Ongoing Account L2") / TotalA_L2) * 100, 2) & " %"
            lblDecided_P_L2.Text = FormatNumber((DT(0)("Decided Account L2") / TotalA_L2) * 100, 2) & " %"
            lblExecuted_P_L2.Text = FormatNumber((DT(0)("Executed Account L2") / TotalA_L2) * 100, 2) & " %"
            lblDismissed_P_L2.Text = FormatNumber((DT(0)("Dismissed Account L2") / TotalA_L2) * 100, 2) & " %"
            lblArchieved_P_L2.Text = FormatNumber((DT(0)("Archived Account L2") / TotalA_L2) * 100, 2) & " %"
            lblTotal_P_L2.Text = FormatNumber((TotalA_L2 / TotalA_L2) * 100, 2) & " %"
            'Percentage ************************************
        Else
            'Count ************************************
            lblOnGoing_A.Text = "0"
            lblDecided_A.Text = "0"
            lblExecuted_A.Text = "0"
            lblDismissed_A.Text = "0"
            lblArchieved_A.Text = "0"
            lblTotal_A.Text = "0"

            lblOnGoing_A_L1.Text = "0"
            lblDecided_A_L1.Text = "0"
            lblExecuted_A_L1.Text = "0"
            lblDismissed_A_L1.Text = "0"
            lblArchieved_A_L1.Text = "0"
            lblTotal_A_L1.Text = "0"

            lblOnGoing_A_L2.Text = "0"
            lblDecided_A_L2.Text = "0"
            lblExecuted_A_L2.Text = "0"
            lblDismissed_A_L2.Text = "0"
            lblArchieved_A_L2.Text = "0"
            lblTotal_A_L2.Text = "0"
            'Count ************************************

            'Book Value ************************************
            lblOnGoing_BV.Text = "0.00"
            lblDecided_BV.Text = "0.00"
            lblExecuted_BV.Text = "0.00"
            lblDismissed_BV.Text = "0.00"
            lblArchieved_BV.Text = "0.00"
            lblTotal_BV.Text = "0.00"

            lblOnGoing_BV_L1.Text = "0.00"
            lblDecided_BV_L1.Text = "0.00"
            lblExecuted_BV_L1.Text = "0.00"
            lblDismissed_BV_L1.Text = "0.00"
            lblArchieved_BV_L1.Text = "0.00"
            lblTotal_BV_L1.Text = "0.00"

            lblOnGoing_BV_L2.Text = "0.00"
            lblDecided_BV_L2.Text = "0.00"
            lblExecuted_BV_L2.Text = "0.00"
            lblDismissed_BV_L2.Text = "0.00"
            lblArchieved_BV_L2.Text = "0.00"
            lblTotal_BV_L2.Text = "0.00"
            'Book Value ************************************

            'Percentage ************************************
            lblOnGoing_P.Text = "0.00 %"
            lblDecided_P.Text = "0.00 %"
            lblExecuted_P.Text = "0.00 %"
            lblDismissed_P.Text = "0.00 %"
            lblArchieved_P.Text = "0.00 %"
            lblTotal_P.Text = "0.00 %"

            lblOnGoing_P_L1.Text = "0.00 %"
            lblDecided_P_L1.Text = "0.00 %"
            lblExecuted_P_L1.Text = "0.00 %"
            lblDismissed_P_L1.Text = "0.00 %"
            lblArchieved_P_L1.Text = "0.00 %"
            lblTotal_P_L1.Text = "0.00 %"

            lblOnGoing_P_L2.Text = "0.00 %"
            lblDecided_P_L2.Text = "0.00 %"
            lblExecuted_P_L2.Text = "0.00 %"
            lblDismissed_P_L2.Text = "0.00 %"
            lblArchieved_P_L2.Text = "0.00 %"
            lblTotal_P_L2.Text = "0.00 %"
            'Percentage ************************************
        End If
        Cursor = Cursors.Default

        LineChart(Chart1)
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 1 THEN ID END),0) AS 'Jan',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 2 THEN ID END),0) AS 'Feb',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 3 THEN ID END),0) AS 'Mar',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 4 THEN ID END),0) AS 'Apr',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 5 THEN ID END),0) AS 'May',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 6 THEN ID END),0) AS 'Jun',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 7 THEN ID END),0) AS 'Jul',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 8 THEN ID END),0) AS 'Aug',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 9 THEN ID END),0) AS 'Sep',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 10 THEN ID END),0) AS 'Oct',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 11 THEN ID END),0) AS 'Nov',"
        SQL &= "    FORMAT(COUNT(CASE WHEN MONTH(TransDate) = 12 THEN ID END),0) AS 'Dec'"
        SQL &= String.Format(" FROM case_main WHERE `status` = 'ACTIVE' AND YEAR(TransDate) = YEAR('{0}');", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        Dim DT_Cases As DataTable = DataSource(SQL)

        Chart.Series.Clear()
        For x As Integer = 0 To DT_Cases.Columns.Count - 1
            Dim Series1 As New Series(DT_Cases(0)(x), ViewType.Bar)
            Series1.Points.Add(New SeriesPoint(DT_Cases.Columns(x).Caption.ToString, DT_Cases(0)(x)))
            Chart.Series.Add(Series1)
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadOnGoing()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT * FROM ("
        SQL &= "   SELECT B.ID,"
        SQL &= "   B.Branch,"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'NEWLY FILED' THEN Amount END),0) AS 'A_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'NEWLY FILED' THEN Account END),0) AS 'A_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR RAFFLE' THEN Amount END),0) AS 'B_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR RAFFLE' THEN Account END),0) AS 'B_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF SUMMONS' THEN Amount END),0) AS 'C_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF SUMMONS' THEN Account END),0) AS 'C_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR PMC' THEN Amount END),0) AS 'D_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR PMC' THEN Account END),0) AS 'D_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR JDR' THEN Amount END),0) AS 'E_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR JDR' THEN Account END),0) AS 'E_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'PRE-TRIAL' THEN Amount END),0) AS 'F_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'PRE-TRIAL' THEN Account END),0) AS 'F_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'TRIAL' THEN Amount END),0) AS 'G_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'TRIAL' THEN Account END),0) AS 'G_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'SUBMITTED FOR DECISION' THEN Amount END),0) AS 'H_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'SUBMITTED FOR DECISION' THEN Account END),0) AS 'H_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END),0) AS 'T_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END),0) AS 'T_A2',"

        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'NEWLY FILED' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END)) * 100,0),2),' %') AS 'A_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'NEWLY FILED' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END)) * 100,0),2),' %') AS 'A_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR RAFFLE' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END)) * 100,0),2),' %') AS 'B_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR RAFFLE' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END)) * 100,0),2),' %') AS 'B_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF SUMMONS' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END)) * 100,0),2),' %') AS 'C_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF SUMMONS' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END)) * 100,0),2),' %') AS 'C_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR PMC' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END)) * 100,0),2),' %') AS 'D_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR PMC' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END)) * 100,0),2),' %') AS 'D_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR JDR' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END)) * 100,0),2),' %') AS 'E_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR JDR' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END)) * 100,0),2),' %') AS 'E_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'PRE-TRIAL' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END)) * 100,0),2),' %') AS 'F_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'PRE-TRIAL' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END)) * 100,0),2),' %') AS 'F_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'TRIAL' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END)) * 100,0),2),' %') AS 'G_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'TRIAL' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END)) * 100,0),2),' %') AS 'G_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'SUBMITTED FOR DECISION' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END)) * 100,0),2),' %') AS 'H_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'SUBMITTED FOR DECISION' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END)) * 100,0),2),' %') AS 'H_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END)) * 100,0),2),' %') AS 'T_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END)) * 100,0),2),' %') AS 'T_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 1 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "   ON B.BranchID = C.BranchID"
        SQL &= "   WHERE B.`status` = 'ACTIVE' "
        SQL &= "   GROUP BY B.BranchID"

        SQL &= " UNION ALL "

        SQL &= " SELECT "
        SQL &= "    MAX(B.ID + 1000) AS 'ID',"
        SQL &= "    'T O T A L',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'NEWLY FILED' THEN Amount END),0) AS 'A_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'NEWLY FILED' THEN Account END),0) AS 'A_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR RAFFLE' THEN Amount END),0) AS 'B_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR RAFFLE' THEN Account END),0) AS 'B_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF SUMMONS' THEN Amount END),0) AS 'C_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF SUMMONS' THEN Account END),0) AS 'C_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR PMC' THEN Amount END),0) AS 'D_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR PMC' THEN Account END),0) AS 'D_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR JDR' THEN Amount END),0) AS 'E_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR JDR' THEN Account END),0) AS 'E_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'PRE-TRIAL' THEN Amount END),0) AS 'F_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'PRE-TRIAL' THEN Account END),0) AS 'F_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'TRIAL' THEN Amount END),0) AS 'G_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'TRIAL' THEN Account END),0) AS 'G_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'SUBMITTED FOR DECISION' THEN Amount END),0) AS 'H_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'SUBMITTED FOR DECISION' THEN Account END),0) AS 'H_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Amount END),0) AS 'T_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory IN ('NEWLY FILED','FOR RAFFLE','FOR DELIVERY OF SUMMONS','FOR PMC','FOR JDR','PRE-TRIAL','TRIAL','SUBMITTED FOR DECISION') THEN Account END),0) AS 'T_A2',"

        SQL &= "    '' AS 'A_P1',"
        SQL &= "    '' AS 'A_P2',"
        SQL &= "    '' AS 'B_P1',"
        SQL &= "    '' AS 'B_P2',"
        SQL &= "    '' AS 'C_P1',"
        SQL &= "    '' AS 'C_P2',"
        SQL &= "    '' AS 'D_P1',"
        SQL &= "    '' AS 'D_P2',"
        SQL &= "    '' AS 'E_P1',"
        SQL &= "    '' AS 'E_P2',"
        SQL &= "    '' AS 'F_P1',"
        SQL &= "    '' AS 'F_P2',"
        SQL &= "    '' AS 'G_P1',"
        SQL &= "    '' AS 'G_P2',"
        SQL &= "    '' AS 'H_P1',"
        SQL &= "    '' AS 'H_P2',"
        SQL &= "    '' AS 'T_P1',"
        SQL &= "    '' AS 'T_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 1 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "    ON B.BranchID = C.BranchID"
        SQL &= "    WHERE B.`status` = 'ACTIVE') A ORDER BY `ID`"

        GridControl1.DataSource = DataSource(SQL)
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadDecided()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT * FROM ("
        SQL &= "   SELECT B.ID,"
        SQL &= "   B.Branch,"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'DECIDED AND FOR MONITORING' THEN Amount END),0) AS 'I_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'DECIDED AND FOR MONITORING' THEN Account END),0) AS 'I_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR PREPARATION OF MFE' THEN Amount END),0) AS 'J_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR PREPARATION OF MFE' THEN Account END),0) AS 'J_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF MFE' THEN Amount END),0) AS 'K_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF MFE' THEN Account END),0) AS 'K_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Amount END),0) AS 'L_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Account END),0) AS 'L_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FILED IN COURT' THEN Amount END),0) AS 'M_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FILED IN COURT' THEN Account END),0) AS 'M_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE WAITING FOR DECISION' THEN Amount END),0) AS 'N_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE WAITING FOR DECISION' THEN Account END),0) AS 'N_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'TO PAY WRIT FEE' THEN Amount END),0) AS 'O_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'TO PAY WRIT FEE' THEN Account END),0) AS 'O_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'TO PAY SHERIFF`S BILL' THEN Amount END),0) AS 'P_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'TO PAY SHERIFF`S BILL' THEN Account END),0) AS 'P_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Amount END),0) AS 'Q_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Account END),0) AS 'Q_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END),0) AS 'T_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END),0) AS 'T_A2',"

        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'DECIDED AND FOR MONITORING' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'I_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'DECIDED AND FOR MONITORING' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'I_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR PREPARATION OF MFE' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'J_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR PREPARATION OF MFE' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'J_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF MFE' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'K_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF MFE' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'K_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'MFE DELIVERED' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'L_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'MFE DELIVERED' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'L_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FILED IN COURT' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'M_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FILED IN COURT' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'M_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'MFE WAITING FOR DECISION' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'N_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'MFE WAITING FOR DECISION' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'N_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'TO PAY WRIT FEE' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'O_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'TO PAY WRIT FEE' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'O_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'TO PAY SHERIFF`S BILL' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'P_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'TO PAY SHERIFF`S BILL' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'P_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'Q_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'Q_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END)) * 100,0),2),' %') AS 'T_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END)) * 100,0),2),' %') AS 'T_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 7 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "   ON B.BranchID = C.BranchID"
        SQL &= "   WHERE B.`status` = 'ACTIVE' "
        SQL &= "   GROUP BY B.BranchID"

        SQL &= " UNION ALL "

        SQL &= " SELECT "
        SQL &= "    MAX(B.ID + 1000) AS 'ID',"
        SQL &= "    'T O T A L',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'DECIDED AND FOR MONITORING' THEN Amount END),0) AS 'I_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'DECIDED AND FOR MONITORING' THEN Account END),0) AS 'I_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR PREPARATION OF MFE' THEN Amount END),0) AS 'J_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR PREPARATION OF MFE' THEN Account END),0) AS 'J_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF MFE' THEN Amount END),0) AS 'K_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR DELIVERY OF MFE' THEN Account END),0) AS 'K_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Amount END),0) AS 'L_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Account END),0) AS 'L_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FILED IN COURT' THEN Amount END),0) AS 'M_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FILED IN COURT' THEN Account END),0) AS 'M_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE WAITING FOR DECISION' THEN Amount END),0) AS 'N_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE WAITING FOR DECISION' THEN Account END),0) AS 'N_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'TO PAY WRIT FEE' THEN Amount END),0) AS 'O_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'TO PAY WRIT FEE' THEN Account END),0) AS 'O_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'TO PAY SHERIFF`S BILL' THEN Amount END),0) AS 'P_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'TO PAY SHERIFF`S BILL' THEN Account END),0) AS 'P_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Amount END),0) AS 'Q_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'MFE FOR MONITORING' THEN Account END),0) AS 'Q_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Amount END),0) AS 'T_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory IN ('DECIDED AND FOR MONITORING','FOR PREPARATION OF MFE','FOR DELIVERY OF MFE','MFE DELIVERED','FILED IN COURT','MFE WAITING FOR DECISION','TO PAY WRIT FEE','TO PAY SHERIFF`S BILL','MFE FOR MONITORING') THEN Account END),0) AS 'T_A2',"

        SQL &= "    '' AS 'I_P1',"
        SQL &= "    '' AS 'I_P2',"
        SQL &= "    '' AS 'J_P1',"
        SQL &= "    '' AS 'J_P2',"
        SQL &= "    '' AS 'K_P1',"
        SQL &= "    '' AS 'K_P2',"
        SQL &= "    '' AS 'L_P1',"
        SQL &= "    '' AS 'L_P2',"
        SQL &= "    '' AS 'M_P1',"
        SQL &= "    '' AS 'M_P2',"
        SQL &= "    '' AS 'N_P1',"
        SQL &= "    '' AS 'N_P2',"
        SQL &= "    '' AS 'O_P1',"
        SQL &= "    '' AS 'O_P2',"
        SQL &= "    '' AS 'P_P1',"
        SQL &= "    '' AS 'P_P2',"
        SQL &= "    '' AS 'Q_P1',"
        SQL &= "    '' AS 'Q_P2',"
        SQL &= "    '' AS 'T_P1',"
        SQL &= "    '' AS 'T_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 7 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "    ON B.BranchID = C.BranchID"
        SQL &= "    WHERE B.`status` = 'ACTIVE') A ORDER BY `ID`"

        GridControl2.DataSource = DataSource(SQL)
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadExecuted()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT * FROM ("
        SQL &= "   SELECT B.ID,"
        SQL &= "   B.Branch,"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'SCHEDULED FOR EXECUTION' THEN Amount END),0) AS 'R_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'SCHEDULED FOR EXECUTION' THEN Account END),0) AS 'R_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR FOLLOW UP' THEN Amount END),0) AS 'S_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR FOLLOW UP' THEN Account END),0) AS 'S_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR LEVY/ATTACHMENT OF REAL PROPERTY' THEN Amount END),0) AS 'T_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR LEVY/ATTACHMENT OF REAL PROPERTY' THEN Account END),0) AS 'T_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR GARNISHMENT' THEN Amount END),0) AS 'U_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR GARNISHMENT' THEN Account END),0) AS 'U_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR RECOVERY OF PERSONAL PROPERTY' THEN Amount END),0) AS 'V_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR RECOVERY OF PERSONAL PROPERTY' THEN Account END),0) AS 'V_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Amount END),0) AS 'Total_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Account END),0) AS 'Total_A2',"

        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'SCHEDULED FOR EXECUTION' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Amount END)) * 100,0),2),' %') AS 'R_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'SCHEDULED FOR EXECUTION' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Account END)) * 100,0),2),' %') AS 'R_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR FOLLOW UP' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Amount END)) * 100,0),2),' %') AS 'S_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR FOLLOW UP' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Account END)) * 100,0),2),' %') AS 'S_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR LEVY/ATTACHMENT OF REAL PROPERTY' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Amount END)) * 100,0),2),' %') AS 'T_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR LEVY/ATTACHMENT OF REAL PROPERTY' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Account END)) * 100,0),2),' %') AS 'T_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR GARNISHMENT' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Amount END)) * 100,0),2),' %') AS 'U_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR GARNISHMENT' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Account END)) * 100,0),2),' %') AS 'U_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR RECOVERY OF PERSONAL PROPERTY' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Amount END)) * 100,0),2),' %') AS 'V_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR RECOVERY OF PERSONAL PROPERTY' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Account END)) * 100,0),2),' %') AS 'V_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Amount END)) * 100,0),2),' %') AS 'Total_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Account END)) * 100,0),2),' %') AS 'Total_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 8 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "   ON B.BranchID = C.BranchID"
        SQL &= "   WHERE B.`status` = 'ACTIVE' "
        SQL &= "   GROUP BY B.BranchID"

        SQL &= " UNION ALL "

        SQL &= " SELECT "
        SQL &= "    MAX(B.ID + 1000) AS 'ID',"
        SQL &= "    'T O T A L',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'SCHEDULED FOR EXECUTION' THEN Amount END),0) AS 'R_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'SCHEDULED FOR EXECUTION' THEN Account END),0) AS 'R_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR FOLLOW UP' THEN Amount END),0) AS 'S_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR FOLLOW UP' THEN Account END),0) AS 'S_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR LEVY/ATTACHMENT OF REAL PROPERTY' THEN Amount END),0) AS 'T_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR LEVY/ATTACHMENT OF REAL PROPERTY' THEN Account END),0) AS 'T_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR GARNISHMENT' THEN Amount END),0) AS 'U_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR GARNISHMENT' THEN Account END),0) AS 'U_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR RECOVERY OF PERSONAL PROPERTY' THEN Amount END),0) AS 'V_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR RECOVERY OF PERSONAL PROPERTY' THEN Account END),0) AS 'V_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Amount END),0) AS 'Total_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory IN ('SCHEDULED FOR EXECUTION','FOR FOLLOW UP','FOR LEVY/ATTACHMENT OF REAL PROPERTY','FOR GARNISHMENT','FOR RECOVERY OF PERSONAL PROPERTY') THEN Account END),0) AS 'Total_A2',"

        SQL &= "    '' AS 'R_P1',"
        SQL &= "    '' AS 'R_P2',"
        SQL &= "    '' AS 'S_P1',"
        SQL &= "    '' AS 'S_P2',"
        SQL &= "    '' AS 'T_P1',"
        SQL &= "    '' AS 'T_P2',"
        SQL &= "    '' AS 'U_P1',"
        SQL &= "    '' AS 'U_P2',"
        SQL &= "    '' AS 'V_P1',"
        SQL &= "    '' AS 'V_P2',"
        SQL &= "    '' AS 'Total_P1',"
        SQL &= "    '' AS 'Total_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 8 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "    ON B.BranchID = C.BranchID"
        SQL &= "    WHERE B.`status` = 'ACTIVE') A ORDER BY `ID`"

        GridControl3.DataSource = DataSource(SQL)
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadDismissed()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT * FROM ("
        SQL &= "   SELECT B.ID,"
        SQL &= "   B.Branch,"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'DISMISSED WITH PREJUDICE' THEN Amount END),0) AS 'W_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'DISMISSED WITH PREJUDICE' THEN Account END),0) AS 'W_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'DISMISSED WITHOUT PREJUDICE' THEN Amount END),0) AS 'X_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'DISMISSED WITHOUT PREJUDICE' THEN Account END),0) AS 'X_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR REFILING' THEN Amount END),0) AS 'Y_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR REFILING' THEN Account END),0) AS 'Y_A2',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Amount END),0) AS 'T_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Account END),0) AS 'T_A2',"

        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'DISMISSED WITH PREJUDICE' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Amount END)) * 100,0),2),' %') AS 'W_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'DISMISSED WITH PREJUDICE' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Account END)) * 100,0),2),' %') AS 'W_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'DISMISSED WITHOUT PREJUDICE' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Amount END)) * 100,0),2),' %') AS 'X_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'DISMISSED WITHOUT PREJUDICE' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Account END)) * 100,0),2),' %') AS 'X_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR REFILING' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Amount END)) * 100,0),2),' %') AS 'Y_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'FOR REFILING' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Account END)) * 100,0),2),' %') AS 'Y_P2',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Amount END)) * 100,0),2),' %') AS 'T_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Account END)) * 100,0),2),' %') AS 'T_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 9 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "   ON B.BranchID = C.BranchID"
        SQL &= "   WHERE B.`status` = 'ACTIVE' "
        SQL &= "   GROUP BY B.BranchID"

        SQL &= " UNION ALL "

        SQL &= " SELECT "
        SQL &= "    MAX(B.ID + 1000) AS 'ID',"
        SQL &= "    'T O T A L',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'DISMISSED WITH PREJUDICE' THEN Amount END),0) AS 'W_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'DISMISSED WITH PREJUDICE' THEN Account END),0) AS 'W_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'DISMISSED WITHOUT PREJUDICE' THEN Amount END),0) AS 'X_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'DISMISSED WITHOUT PREJUDICE' THEN Account END),0) AS 'X_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR REFILING' THEN Amount END),0) AS 'Y_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'FOR REFILING' THEN Account END),0) AS 'Y_A2',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Amount END),0) AS 'T_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory IN ('DISMISSED WITH PREJUDICE','DISMISSED WITHOUT PREJUDICE','FOR REFILING') THEN Account END),0) AS 'T_A2',"

        SQL &= "    '' AS 'W_P1',"
        SQL &= "    '' AS 'W_P2',"
        SQL &= "    '' AS 'X_P1',"
        SQL &= "    '' AS 'X_P2',"
        SQL &= "    '' AS 'Y_P1',"
        SQL &= "    '' AS 'Y_P2',"
        SQL &= "    '' AS 'T_P1',"
        SQL &= "    '' AS 'T_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 9 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "    ON B.BranchID = C.BranchID"
        SQL &= "    WHERE B.`status` = 'ACTIVE') A ORDER BY `ID`"

        GridControl4.DataSource = DataSource(SQL)
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadArchived()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT * FROM ("
        SQL &= "   SELECT B.ID,"
        SQL &= "   B.Branch,"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'ARCHIVED' THEN Amount END),0) AS 'Z_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.SubCategory = 'ARCHIVED' THEN Account END),0) AS 'Z_A2',"

        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'ARCHIVED' THEN Amount END) / SUM(CASE WHEN C.SubCategory IN ('ARCHIVED') THEN Amount END)) * 100,0),2),' %') AS 'Z_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.SubCategory = 'ARCHIVED' THEN Account END) / SUM(CASE WHEN C.SubCategory IN ('ARCHIVED') THEN Account END)) * 100,0),2),' %') AS 'Z_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 10 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "   ON B.BranchID = C.BranchID"
        SQL &= "   WHERE B.`status` = 'ACTIVE' "
        SQL &= "   GROUP BY B.BranchID"

        SQL &= " UNION ALL "

        SQL &= " SELECT "
        SQL &= "    MAX(B.ID + 1000) AS 'ID',"
        SQL &= "    'T O T A L',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'ARCHIVED' THEN Amount END),0) AS 'Z_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN C.SubCategory = 'ARCHIVED' THEN Account END),0) AS 'Z_A2',"

        SQL &= "    '' AS 'Z_P1',"
        SQL &= "    '' AS 'Z_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, SubCategory(D.SubCategoryID) AS 'SubCategory', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 10 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "    ON B.BranchID = C.BranchID"
        SQL &= "    WHERE B.`status` = 'ACTIVE') A ORDER BY `ID`"

        GridControl5.DataSource = DataSource(SQL)
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadWrittenOff()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT * FROM ("
        SQL &= "   SELECT B.ID,"
        SQL &= "   B.Branch,"
        SQL &= "   IFNULL(SUM(CASE WHEN C.Category = 'WRITTEN OFF' THEN Amount END),0) AS 'Z_A1',"
        SQL &= "   IFNULL(SUM(CASE WHEN C.Category = 'WRITTEN OFF' THEN Account END),0) AS 'Z_A2',"

        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.Category = 'WRITTEN OFF' THEN Amount END) / SUM(CASE WHEN Category = 'WRITTEN OFF' THEN Amount END)) * 100,0),2),' %') AS 'Z_P1',"
        SQL &= "   CONCAT(FORMAT(IFNULL((SUM(CASE WHEN C.Category = 'WRITTEN OFF' THEN Account END) / SUM(CASE WHEN Category = 'WRITTEN OFF' THEN Account END)) * 100,0),2),' %') AS 'Z_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, Category(D.CategoryID) AS 'Category', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 11 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "   ON B.BranchID = C.BranchID"
        SQL &= "   WHERE B.`status` = 'ACTIVE' "
        SQL &= "   GROUP BY B.BranchID"

        SQL &= " UNION ALL "

        SQL &= " SELECT "
        SQL &= "    MAX(B.ID + 1000) AS 'ID',"
        SQL &= "    'T O T A L',"
        SQL &= "    IFNULL(SUM(CASE WHEN Category = 'WRITTEN OFF' THEN Amount END),0) AS 'Z_A1',"
        SQL &= "    IFNULL(SUM(CASE WHEN Category = 'WRITTEN OFF' THEN Account END),0) AS 'Z_A2',"

        SQL &= "    '' AS 'Z_P1',"
        SQL &= "    '' AS 'Z_P2'"
        SQL &= String.Format(" FROM branch B LEFT JOIN (SELECT COUNT(M.ID) AS 'Account', SUM(Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID)) AS 'Amount', M.BranchID, Category(D.CategoryID) AS 'Category', D.SubCategoryID, D.CategoryID FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE M.`status` = 'ACTIVE' AND D.CategoryID = 11 GROUP BY M.BranchID, D.SubCategoryID) C", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= "    ON B.BranchID = C.BranchID"
        SQL &= "    WHERE B.`status` = 'ACTIVE') A ORDER BY `ID`"

        GridControl6.DataSource = DataSource(SQL)
        Cursor = Cursors.Default
    End Sub

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
        If SuperTabControl1.SelectedTabIndex = 0 Then

        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Dim Report As New RptCaseMonitoringOngoing
            With Report
                .lblAsOf.Text = "As of " & dtpAsOf.Text

                Dim DT As DataTable = GridControl1.DataSource
                Dim DT_Sample As DataTable = DT.Copy
                DT_Sample.Rows.RemoveAt(BandedGridView1.RowCount - 1)
                .DataSource = DT_Sample
                .lblBranch.DataBindings.Add("Text", DT_Sample, "Branch")
                .lblAA1.DataBindings.Add("Text", DT_Sample, "A_A1")
                .lblAP1.DataBindings.Add("Text", DT_Sample, "A_P1")
                .lblAA2.DataBindings.Add("Text", DT_Sample, "A_A2")
                .lblAP2.DataBindings.Add("Text", DT_Sample, "A_P2")
                .lblBA1.DataBindings.Add("Text", DT_Sample, "B_A1")
                .lblBP1.DataBindings.Add("Text", DT_Sample, "B_P1")
                .lblBA2.DataBindings.Add("Text", DT_Sample, "B_A2")
                .lblBP2.DataBindings.Add("Text", DT_Sample, "B_P2")
                .lblCA1.DataBindings.Add("Text", DT_Sample, "C_A1")
                .lblCP1.DataBindings.Add("Text", DT_Sample, "C_P1")
                .lblCA2.DataBindings.Add("Text", DT_Sample, "C_A2")
                .lblCP2.DataBindings.Add("Text", DT_Sample, "C_P2")
                .lblDA1.DataBindings.Add("Text", DT_Sample, "D_A1")
                .lblDP1.DataBindings.Add("Text", DT_Sample, "D_P1")
                .lblDA2.DataBindings.Add("Text", DT_Sample, "D_A2")
                .lblDP2.DataBindings.Add("Text", DT_Sample, "D_P2")
                .lblEA1.DataBindings.Add("Text", DT_Sample, "E_A1")
                .lblEP1.DataBindings.Add("Text", DT_Sample, "E_P1")
                .lblEA2.DataBindings.Add("Text", DT_Sample, "E_A2")
                .lblEP2.DataBindings.Add("Text", DT_Sample, "E_P2")
                .lblFA1.DataBindings.Add("Text", DT_Sample, "F_A1")
                .lblFP1.DataBindings.Add("Text", DT_Sample, "F_P1")
                .lblFA2.DataBindings.Add("Text", DT_Sample, "F_A2")
                .lblFP2.DataBindings.Add("Text", DT_Sample, "F_P2")
                .lblGA1.DataBindings.Add("Text", DT_Sample, "G_A1")
                .lblGP1.DataBindings.Add("Text", DT_Sample, "G_P1")
                .lblGA2.DataBindings.Add("Text", DT_Sample, "G_A2")
                .lblGP2.DataBindings.Add("Text", DT_Sample, "G_P2")
                .lblHA1.DataBindings.Add("Text", DT_Sample, "H_A1")
                .lblHP1.DataBindings.Add("Text", DT_Sample, "H_P1")
                .lblHA2.DataBindings.Add("Text", DT_Sample, "H_A2")
                .lblHP2.DataBindings.Add("Text", DT_Sample, "H_P2")
                .lblTA1.DataBindings.Add("Text", DT_Sample, "T_A1")
                .lblTP1.DataBindings.Add("Text", DT_Sample, "T_P1")
                .lblTA2.DataBindings.Add("Text", DT_Sample, "T_A2")
                .lblTP2.DataBindings.Add("Text", DT_Sample, "T_P2")

                .lblBranchT.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "Branch")
                .lblAA1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "A_A1")
                .lblAP1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "A_P1")
                .lblAA2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "A_A2")
                .lblAP2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "A_P2")
                .lblBA1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "B_A1")
                .lblBP1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "B_P1")
                .lblBA2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "B_A2")
                .lblBP2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "B_P2")
                .lblCA1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "C_A1")
                .lblCP1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "C_P1")
                .lblCA2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "C_A2")
                .lblCP2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "C_P2")
                .lblDA1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "D_A1")
                .lblDP1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "D_P1")
                .lblDA2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "D_A2")
                .lblDP2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "D_P2")
                .lblEA1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "E_A1")
                .lblEP1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "E_P1")
                .lblEA2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "E_A2")
                .lblEP2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "E_P2")
                .lblFA1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "F_A1")
                .lblFP1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "F_P1")
                .lblFA2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "F_A2")
                .lblFP2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "F_P2")
                .lblGA1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "G_A1")
                .lblGP1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "G_P1")
                .lblGA2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "G_A2")
                .lblGP2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "G_P2")
                .lblHA1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "H_A1")
                .lblHP1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "H_P1")
                .lblHA2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "H_A2")
                .lblHP2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "H_P2")
                .lblTA1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "T_A1")
                .lblTP1T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "T_P1")
                .lblTA2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "T_A2")
                .lblTP2T.Text = BandedGridView1.GetRowCellValue(BandedGridView1.RowCount - 1, "T_P2")
                Logs("Case Monitoring", "Print", "[SENSITIVE] Print Case Monitoring Ongoing", "", "", "", "")
                .ShowPreview()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            Dim Report As New RptCaseMonitoringDecided
            With Report
                .lblAsOf.Text = "As of " & dtpAsOf.Text

                Dim DT As DataTable = GridControl2.DataSource
                Dim DT_Sample As DataTable = DT.Copy
                DT_Sample.Rows.RemoveAt(BandedGridView2.RowCount - 1)
                .DataSource = DT_Sample
                .lblBranch.DataBindings.Add("Text", DT_Sample, "Branch")
                .lblAA1.DataBindings.Add("Text", DT_Sample, "I_A1")
                .lblAP1.DataBindings.Add("Text", DT_Sample, "I_P1")
                .lblAA2.DataBindings.Add("Text", DT_Sample, "I_A2")
                .lblAP2.DataBindings.Add("Text", DT_Sample, "I_P2")
                .lblBA1.DataBindings.Add("Text", DT_Sample, "J_A1")
                .lblBP1.DataBindings.Add("Text", DT_Sample, "J_P1")
                .lblBA2.DataBindings.Add("Text", DT_Sample, "J_A2")
                .lblBP2.DataBindings.Add("Text", DT_Sample, "J_P2")
                .lblCA1.DataBindings.Add("Text", DT_Sample, "K_A1")
                .lblCP1.DataBindings.Add("Text", DT_Sample, "K_P1")
                .lblCA2.DataBindings.Add("Text", DT_Sample, "K_A2")
                .lblCP2.DataBindings.Add("Text", DT_Sample, "K_P2")
                .lblDA1.DataBindings.Add("Text", DT_Sample, "L_A1")
                .lblDP1.DataBindings.Add("Text", DT_Sample, "L_P1")
                .lblDA2.DataBindings.Add("Text", DT_Sample, "L_A2")
                .lblDP2.DataBindings.Add("Text", DT_Sample, "L_P2")
                .lblEA1.DataBindings.Add("Text", DT_Sample, "M_A1")
                .lblEP1.DataBindings.Add("Text", DT_Sample, "M_P1")
                .lblEA2.DataBindings.Add("Text", DT_Sample, "M_A2")
                .lblEP2.DataBindings.Add("Text", DT_Sample, "M_P2")
                .lblFA1.DataBindings.Add("Text", DT_Sample, "N_A1")
                .lblFP1.DataBindings.Add("Text", DT_Sample, "N_P1")
                .lblFA2.DataBindings.Add("Text", DT_Sample, "N_A2")
                .lblFP2.DataBindings.Add("Text", DT_Sample, "N_P2")
                .lblGA1.DataBindings.Add("Text", DT_Sample, "O_A1")
                .lblGP1.DataBindings.Add("Text", DT_Sample, "O_P1")
                .lblGA2.DataBindings.Add("Text", DT_Sample, "O_A2")
                .lblGP2.DataBindings.Add("Text", DT_Sample, "O_P2")
                .lblHA1.DataBindings.Add("Text", DT_Sample, "P_A1")
                .lblHP1.DataBindings.Add("Text", DT_Sample, "P_P1")
                .lblHA2.DataBindings.Add("Text", DT_Sample, "P_A2")
                .lblHP2.DataBindings.Add("Text", DT_Sample, "P_P2")
                .lblQA1.DataBindings.Add("Text", DT_Sample, "Q_A1")
                .lblQP1.DataBindings.Add("Text", DT_Sample, "Q_P1")
                .lblQA2.DataBindings.Add("Text", DT_Sample, "Q_A2")
                .lblQP2.DataBindings.Add("Text", DT_Sample, "Q_P2")
                .lblTA1.DataBindings.Add("Text", DT_Sample, "T_A1")
                .lblTP1.DataBindings.Add("Text", DT_Sample, "T_P1")
                .lblTA2.DataBindings.Add("Text", DT_Sample, "T_A2")
                .lblTP2.DataBindings.Add("Text", DT_Sample, "T_P2")

                .lblBranchT.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "Branch")
                .lblAA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "I_A1")
                .lblAP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "I_P1")
                .lblAA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "I_A2")
                .lblAP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "I_P2")
                .lblBA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "J_A1")
                .lblBP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "J_P1")
                .lblBA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "J_A2")
                .lblBP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "J_P2")
                .lblCA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "K_A1")
                .lblCP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "K_P1")
                .lblCA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "K_A2")
                .lblCP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "K_P2")
                .lblDA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "L_A1")
                .lblDP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "L_P1")
                .lblDA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "L_A2")
                .lblDP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "L_P2")
                .lblEA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "M_A1")
                .lblEP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "M_P1")
                .lblEA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "M_A2")
                .lblEP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "M_P2")
                .lblFA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "N_A1")
                .lblFP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "N_P1")
                .lblFA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "N_A2")
                .lblFP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "N_P2")
                .lblGA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "O_A1")
                .lblGP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "O_P1")
                .lblGA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "O_A2")
                .lblGP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "O_P2")
                .lblHA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "P_A1")
                .lblHP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "P_P1")
                .lblHA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "P_A2")
                .lblHP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "P_P2")
                .lblQA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "Q_A1")
                .lblQP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "Q_P1")
                .lblQA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "Q_A2")
                .lblQP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "Q_P2")
                .lblTA1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "T_A1")
                .lblTP1T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "T_P1")
                .lblTA2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "T_A2")
                .lblTP2T.Text = BandedGridView2.GetRowCellValue(BandedGridView2.RowCount - 1, "T_P2")
                Logs("Case Monitoring", "Print", "[SENSITIVE] Print Case Monitoring Decided", "", "", "", "")
                .ShowPreview()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            Dim Report As New RptCaseMonitoringExecuted
            With Report
                .lblAsOf.Text = "As of " & dtpAsOf.Text

                Dim DT As DataTable = GridControl3.DataSource
                Dim DT_Sample As DataTable = DT.Copy
                DT_Sample.Rows.RemoveAt(BandedGridView3.RowCount - 1)
                .DataSource = DT_Sample
                .lblBranch.DataBindings.Add("Text", DT_Sample, "Branch")
                .lblAA1.DataBindings.Add("Text", DT_Sample, "R_A1")
                .lblAP1.DataBindings.Add("Text", DT_Sample, "R_P1")
                .lblAA2.DataBindings.Add("Text", DT_Sample, "R_A2")
                .lblAP2.DataBindings.Add("Text", DT_Sample, "R_P2")
                .lblBA1.DataBindings.Add("Text", DT_Sample, "S_A1")
                .lblBP1.DataBindings.Add("Text", DT_Sample, "S_P1")
                .lblBA2.DataBindings.Add("Text", DT_Sample, "S_A2")
                .lblBP2.DataBindings.Add("Text", DT_Sample, "S_P2")
                .lblCA1.DataBindings.Add("Text", DT_Sample, "T_A1")
                .lblCP1.DataBindings.Add("Text", DT_Sample, "T_P1")
                .lblCA2.DataBindings.Add("Text", DT_Sample, "T_A2")
                .lblCP2.DataBindings.Add("Text", DT_Sample, "T_P2")
                .lblDA1.DataBindings.Add("Text", DT_Sample, "U_A1")
                .lblDP1.DataBindings.Add("Text", DT_Sample, "U_P1")
                .lblDA2.DataBindings.Add("Text", DT_Sample, "U_A2")
                .lblDP2.DataBindings.Add("Text", DT_Sample, "U_P2")
                .lblEA1.DataBindings.Add("Text", DT_Sample, "V_A1")
                .lblEP1.DataBindings.Add("Text", DT_Sample, "V_P1")
                .lblEA2.DataBindings.Add("Text", DT_Sample, "V_A2")
                .lblEP2.DataBindings.Add("Text", DT_Sample, "V_P2")
                .lblTA1.DataBindings.Add("Text", DT_Sample, "Total_A1")
                .lblTP1.DataBindings.Add("Text", DT_Sample, "Total_P1")
                .lblTA2.DataBindings.Add("Text", DT_Sample, "Total_A2")
                .lblTP2.DataBindings.Add("Text", DT_Sample, "Total_P2")

                .lblBranchT.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "Branch")
                .lblAA1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "R_A1")
                .lblAP1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "R_P1")
                .lblAA2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "R_A2")
                .lblAP2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "R_P2")
                .lblBA1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "S_A1")
                .lblBP1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "S_P1")
                .lblBA2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "S_A2")
                .lblBP2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "S_P2")
                .lblCA1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "T_A1")
                .lblCP1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "T_P1")
                .lblCA2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "T_A2")
                .lblCP2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "T_P2")
                .lblDA1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "U_A1")
                .lblDP1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "U_P1")
                .lblDA2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "U_A2")
                .lblDP2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "U_P2")
                .lblEA1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "V_A1")
                .lblEP1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "V_P1")
                .lblEA2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "V_A2")
                .lblEP2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "V_P2")
                .lblTA1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "Total_A1")
                .lblTP1T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "Total_P1")
                .lblTA2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "Total_A2")
                .lblTP2T.Text = BandedGridView3.GetRowCellValue(BandedGridView3.RowCount - 1, "Total_P2")
                Logs("Case Monitoring", "Print", "[SENSITIVE] Print Case Monitoring Executed", "", "", "", "")
                .ShowPreview()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            Dim Report As New RptCaseMonitoringDismissed
            With Report
                .lblAsOf.Text = "As of " & dtpAsOf.Text

                Dim DT As DataTable = GridControl4.DataSource
                Dim DT_Sample As DataTable = DT.Copy
                DT_Sample.Rows.RemoveAt(BandedGridView4.RowCount - 1)
                .DataSource = DT_Sample
                .lblBranch.DataBindings.Add("Text", DT_Sample, "Branch")
                .lblAA1.DataBindings.Add("Text", DT_Sample, "W_A1")
                .lblAP1.DataBindings.Add("Text", DT_Sample, "W_P1")
                .lblAA2.DataBindings.Add("Text", DT_Sample, "W_A2")
                .lblAP2.DataBindings.Add("Text", DT_Sample, "W_P2")
                .lblBA1.DataBindings.Add("Text", DT_Sample, "X_A1")
                .lblBP1.DataBindings.Add("Text", DT_Sample, "X_P1")
                .lblBA2.DataBindings.Add("Text", DT_Sample, "X_A2")
                .lblBP2.DataBindings.Add("Text", DT_Sample, "X_P2")
                .lblCA1.DataBindings.Add("Text", DT_Sample, "Y_A1")
                .lblCP1.DataBindings.Add("Text", DT_Sample, "Y_P1")
                .lblCA2.DataBindings.Add("Text", DT_Sample, "Y_A2")
                .lblCP2.DataBindings.Add("Text", DT_Sample, "Y_P2")
                .lblTA1.DataBindings.Add("Text", DT_Sample, "T_A1")
                .lblTP1.DataBindings.Add("Text", DT_Sample, "T_P1")
                .lblTA2.DataBindings.Add("Text", DT_Sample, "T_A2")
                .lblTP2.DataBindings.Add("Text", DT_Sample, "T_P2")

                .lblBranchT.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "Branch")
                .lblAA1T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "W_A1")
                .lblAP1T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "W_P1")
                .lblAA2T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "W_A2")
                .lblAP2T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "W_P2")
                .lblBA1T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "X_A1")
                .lblBP1T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "X_P1")
                .lblBA2T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "X_A2")
                .lblBP2T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "X_P2")
                .lblCA1T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "Y_A1")
                .lblCP1T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "Y_P1")
                .lblCA2T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "Y_A2")
                .lblCP2T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "Y_P2")
                .lblTA1T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "T_A1")
                .lblTP1T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "T_P1")
                .lblTA2T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "T_A2")
                .lblTP2T.Text = BandedGridView4.GetRowCellValue(BandedGridView4.RowCount - 1, "T_P2")
                Logs("Case Monitoring", "Print", "[SENSITIVE] Print Case Monitoring Dismissed", "", "", "", "")
                .ShowPreview()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            Dim Report As New RptCaseMonitoringArchived
            With Report
                .lblAsOf.Text = "As of " & dtpAsOf.Text

                Dim DT As DataTable = GridControl5.DataSource
                Dim DT_Sample As DataTable = DT.Copy
                DT_Sample.Rows.RemoveAt(BandedGridView5.RowCount - 1)
                .DataSource = DT_Sample
                .lblBranch.DataBindings.Add("Text", DT_Sample, "Branch")
                .lblAA1.DataBindings.Add("Text", DT_Sample, "Z_A1")
                .lblAP1.DataBindings.Add("Text", DT_Sample, "Z_P1")
                .lblAA2.DataBindings.Add("Text", DT_Sample, "Z_A2")
                .lblAP2.DataBindings.Add("Text", DT_Sample, "Z_P2")

                .lblBranchT.Text = BandedGridView5.GetRowCellValue(BandedGridView5.RowCount - 1, "Branch")
                .lblAA1T.Text = BandedGridView5.GetRowCellValue(BandedGridView5.RowCount - 1, "Z_A1")
                .lblAP1T.Text = BandedGridView5.GetRowCellValue(BandedGridView5.RowCount - 1, "Z_P1")
                .lblAA2T.Text = BandedGridView5.GetRowCellValue(BandedGridView5.RowCount - 1, "Z_A2")
                .lblAP2T.Text = BandedGridView5.GetRowCellValue(BandedGridView5.RowCount - 1, "Z_P2")
                Logs("Case Monitoring", "Print", "[SENSITIVE] Print Case Monitoring Archived", "", "", "", "")
                .ShowPreview()
            End With
        ElseIf SuperTabControl1.SelectedTabIndex = 6 Then
            Dim Report As New RptCaseMonitoringWrittenOff
            With Report
                .lblAsOf.Text = "As of " & dtpAsOf.Text

                Dim DT As DataTable = GridControl6.DataSource
                Dim DT_Sample As DataTable = DT.Copy
                DT_Sample.Rows.RemoveAt(BandedGridView6.RowCount - 1)
                .DataSource = DT_Sample
                .lblBranch.DataBindings.Add("Text", DT_Sample, "Branch")
                .lblAA1.DataBindings.Add("Text", DT_Sample, "Z_A1")
                .lblAP1.DataBindings.Add("Text", DT_Sample, "Z_P1")
                .lblAA2.DataBindings.Add("Text", DT_Sample, "Z_A2")
                .lblAP2.DataBindings.Add("Text", DT_Sample, "Z_P2")

                .lblBranchT.Text = BandedGridView6.GetRowCellValue(BandedGridView6.RowCount - 1, "Branch")
                .lblAA1T.Text = BandedGridView6.GetRowCellValue(BandedGridView6.RowCount - 1, "Z_A1")
                .lblAP1T.Text = BandedGridView6.GetRowCellValue(BandedGridView6.RowCount - 1, "Z_P1")
                .lblAA2T.Text = BandedGridView6.GetRowCellValue(BandedGridView6.RowCount - 1, "Z_A2")
                .lblAP2T.Text = BandedGridView6.GetRowCellValue(BandedGridView6.RowCount - 1, "Z_P2")
                Logs("Case Monitoring", "Print", "[SENSITIVE] Print Case Monitoring Wrife Off", "", "", "", "")
                .ShowPreview()
            End With
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Then
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
        LoadSummary()
        LoadOnGoing()
        LoadDecided()
        LoadExecuted()
        LoadDismissed()
        LoadArchived()
        LoadWrittenOff()
    End Sub
End Class