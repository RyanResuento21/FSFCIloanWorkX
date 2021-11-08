Imports DevExpress.XtraCharts
Public Class FrmCaseSummaryN

    Public vPrint As Boolean
    Private Sub FrmCaseSummaryN_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4, GridView5})
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        With Line1
            .Location = New Point(585, 8)
            .Size = New Point(10, 549)
        End With
        With Line2
            .Location = New Point(597, 243)
            .Size = New Point(566, 10)
        End With
        With Line3
            .Location = New Point(597, 310)
            .Size = New Point(566, 10)
        End With
        With Line4
            .Location = New Point(597, 350)
            .Size = New Point(566, 10)
        End With
        With Line5
            .Location = New Point(597, 390)
            .Size = New Point(566, 10)
        End With
        With Line6
            .Location = New Point(597, 430)
            .Size = New Point(566, 10)
        End With
        With Line7
            .Location = New Point(597, 470)
            .Size = New Point(566, 10)
        End With
        With Line8
            .Location = New Point(597, 510)
            .Size = New Point(566, 10)
        End With
        With Line9
            .Location = New Point(597, 550)
            .Size = New Point(566, 10)
        End With
        With Chart1
            .Location = New Point(9, 239)
            .Size = New Point(1141, 318)
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

            GetLabelFontSettings({LabelX15, LabelX53, LabelX54, LabelX55, LabelX56, LabelX57, LabelX58, lblOnGoing_A, lblDecided_A, lblExecuted_A, lblDismissed_A, lblArchieved_A, lblTotal_A, lblOnGoing_BV, lblDecided_BV, lblExecuted_BV, lblDismissed_BV, lblArchieved_BV, lblTotal_BV, lblOnGoing_P, lblDecided_P, lblExecuted_P, lblDismissed_P, lblArchieved_P, lblTotal_P, LabelX90, LabelX87, LabelX86, LabelX83, LabelX82, LabelX79, lblOnGoing_C_YTD, lblDecided_C_YTD, lblExecuted_C_YTD, lblDismissed_C_YTD, lblArchieved_C_YTD, lblTotal_C_YTD, lblOnGoing_P_YTD, lblDecided_P_YTD, lblExecuted_P_YTD, lblDismissed_P_YTD, lblArchieved_P_YTD, lblTotal_P_YTD, lblOnGoing_C_CM, lblDecided_C_CM, lblExecuted_C_CM, lblDismissed_C_CM, lblArchieved_C_CM, lblTotal_C_CM, lblOnGoing_P_CM, lblDecided_P_CM, lblExecuted_P_CM, lblDismissed_P_CM, lblArchieved_P_CM, lblTotal_P_CM, lblOnGoing_C_PY, lblDecided_C_PY, lblExecuted_C_PY, lblDismissed_C_PY, lblArchieved_C_PY, lblTotal_C_PY, lblOnGoing_P_PY, lblDecided_P_PY, lblExecuted_P_PY, lblDismissed_P_PY, lblArchieved_P_PY, lblTotal_P_PY})

            GetLabelFontSettingsDefaultSize({LabelX14, LabelX10, LabelX19, LabelX25, LabelX31, LabelX35, LabelX39, LabelX43, LabelX47, LabelX51, LabelX64, LabelX68, LabelX72, LabelX76, LabelX80, LabelX84, LabelX88, LabelX92, LabelX96, LabelX100, LabelX104, LabelX108, LabelX112, LabelX116, LabelX120, LabelX124, LabelX30, LabelX6, LabelX13, LabelX21, LabelX26, LabelX32, LabelX36, LabelX40, LabelX44, LabelX48, LabelX52, LabelX65, LabelX69, LabelX73, LabelX77, LabelX81, LabelX85, LabelX89, LabelX93, LabelX97, LabelX101, LabelX105, LabelX109, LabelX113, LabelX117, LabelX121, lblA1, lblB1, lblC1, lblD1, lblE1, lblF1, lblG1, lblH1, lblI1, lblJ1, lblK1, lblL1, lblM1, lblN1, lblO1, lblP1, lblQ1, lblR1, lblS1, lblT1, lblU1, lblV1, lblW1, lblX1, lblY1, lblZ1, lblA2, lblB2, lblC2, lblD2, lblE2, lblF2, lblG2, lblH2, lblI2, lblJ2, lblK2, lblL2, lblM2, lblN2, lblO2, lblP2, lblQ2, lblR2, lblS2, lblT2, lblU2, lblV2, lblW2, lblX2, lblY2, lblZ2, lblMonth_1, lblBV_1, lblBeginning_1, lblWrittenOff_1, lblFullyPaid_1, lblNew_1, lblEnding_1, lblMonth_2, lblBV_2, lblBeginning_2, lblWrittenOff_2, lblFullyPaid_2, lblNew_2, lblEnding_2, lblMonth_3, lblBV_3, lblBeginning_3, lblWrittenOff_3, lblFullyPaid_3, lblNew_3, lblEnding_3, lblMonth_4, lblBV_4, lblBeginning_4, lblWrittenOff_4, lblFullyPaid_4, lblNew_4, lblEnding_4, lblMonth_5, lblBV_5, lblBeginning_5, lblWrittenOff_5, lblFullyPaid_5, lblNew_5, lblEnding_5, lblMonth_6, lblBV_6, lblBeginning_6, lblWrittenOff_6, lblFullyPaid_6, lblNew_6, lblEnding_6, lblMonth_7, lblBV_7, lblBeginning_7, lblWrittenOff_7, lblFullyPaid_7, lblNew_7, lblEnding_7})

            GetLabelWithBackgroundFontSettings({lblTaxes, LabelX1, LabelX2, LabelX3, LabelX59, LabelX60, lblBV_AsOf, LabelX62, LabelX4, LabelX5, LabelX8, LabelX12, LabelX17, LabelX20, LabelX23, LabelX78, LabelX74, LabelX71, LabelX16, LabelX22, LabelX9, LabelX7})

            GetLabelWithBackgroundFontSettingsNoBorder({lblCurrent, lblCM, lblPY})

            GetDateTimeInputFontSettings({dtpAsOf})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint})

            GetChartTitleControlFontSettings({Chart1})

            GetLineControlFontSettings({Line1, Line2, Line3, Line4, Line5, Line6, Line7, Line8, Line9})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Case Summary N - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Case Summary", lblTitle.Text)
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Cursor = Cursors.WaitCursor
        lblBV_AsOf.Text = "BV as " & Format(dtpAsOf.Value, "MMM, yyyy")
        Dim SQL As String = "SELECT "
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN Category(D.CategoryID) = 'ON GOING CASE' THEN M.ID END)),0),0) AS 'Ongoing Account',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN Category(D.CategoryID) = 'DECIDED CASE' THEN M.ID END)),0),0) AS 'Decided Account', "
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN Category(D.CategoryID) = 'EXECUTED CASE' THEN M.ID END)),0),0) AS 'Executed Account', "
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN Category(D.CategoryID) = 'DISMISSED CASE' THEN M.ID END)),0),0) AS 'Dismissed Account', "
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN Category(D.CategoryID) = 'ARCHIVED CASE' THEN M.ID END)),0),0) AS 'Archived Account',"

        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'ON GOING CASE' THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'Ongoing BV',", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'DECIDED CASE' THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'Decided BV', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'EXECUTED CASE' THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'Executed BV', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'DISMISSED CASE' THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'Dismissed BV', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(D.CategoryID) = 'ARCHIVED CASE' THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'Archived BV' ", FormatDatePicker(dtpAsOf))

        SQL &= String.Format(" FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND BranchID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT As DataTable = DataSource(SQL)
        If DT.Rows.Count > 0 Then
            Dim TotalA As Integer
            TotalA = CInt(DT(0)("Ongoing Account")) + CInt(DT(0)("Decided Account")) + CInt(DT(0)("Executed Account")) + CInt(DT(0)("Dismissed Account")) + CInt(DT(0)("Archived Account"))
            'Count ************************************
            lblOnGoing_A.Text = DT(0)("Ongoing Account")
            lblDecided_A.Text = DT(0)("Decided Account")
            lblExecuted_A.Text = DT(0)("Executed Account")
            lblDismissed_A.Text = DT(0)("Dismissed Account")
            lblArchieved_A.Text = DT(0)("Archived Account")
            lblTotal_A.Text = TotalA
            'Count ************************************

            'Book Value ************************************
            lblOnGoing_BV.Text = DT(0)("Ongoing BV")
            lblDecided_BV.Text = DT(0)("Decided BV")
            lblExecuted_BV.Text = DT(0)("Executed BV")
            lblDismissed_BV.Text = DT(0)("Dismissed BV")
            lblArchieved_BV.Text = DT(0)("Archived BV")
            lblTotal_BV.Text = FormatNumber(CDbl(DT(0)("Ongoing BV")) + CDbl(DT(0)("Decided BV")) + CDbl(DT(0)("Executed BV")) + CDbl(DT(0)("Dismissed BV")) + CDbl(DT(0)("Archived BV")), 2)
            'Book Value ************************************

            'Percentage ************************************
            lblOnGoing_P.Text = FormatNumber((DT(0)("Ongoing Account") / TotalA) * 100, 2) & " %"
            lblDecided_P.Text = FormatNumber((DT(0)("Decided Account") / TotalA) * 100, 2) & " %"
            lblExecuted_P.Text = FormatNumber((DT(0)("Executed Account") / TotalA) * 100, 2) & " %"
            lblDismissed_P.Text = FormatNumber((DT(0)("Dismissed Account") / TotalA) * 100, 2) & " %"
            lblArchieved_P.Text = FormatNumber((DT(0)("Archived Account") / TotalA) * 100, 2) & " %"
            lblTotal_P.Text = FormatNumber((TotalA / TotalA) * 100, 2) & " %"
            'Percentage ************************************
        Else
            'Count ************************************
            lblOnGoing_A.Text = "0"
            lblDecided_A.Text = "0"
            lblExecuted_A.Text = "0"
            lblDismissed_A.Text = "0"
            lblArchieved_A.Text = "0"
            lblTotal_A.Text = "0"
            'Count ************************************

            'Book Value ************************************
            lblOnGoing_BV.Text = "0.00"
            lblDecided_BV.Text = "0.00"
            lblExecuted_BV.Text = "0.00"
            lblDismissed_BV.Text = "0.00"
            lblArchieved_BV.Text = "0.00"
            lblTotal_BV.Text = "0.00"
            'Book Value ************************************

            'Percentage ************************************
            lblOnGoing_P.Text = "0.00 %"
            lblDecided_P.Text = "0.00 %"
            lblExecuted_P.Text = "0.00 %"
            lblDismissed_P.Text = "0.00 %"
            lblArchieved_P.Text = "0.00 %"
            lblTotal_P.Text = "0.00 %"
            'Percentage ************************************
        End If

        SQL = "SELECT "
        SQL &= "     DATE_FORMAT(MovementDate,'%M %Y') AS 'Date',"
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(M.CategoryID) IN ('ON GOING CASE','DECIDED CASE','EXECUTED CASE','DISMISSED CASE','ARCHIVED CASE') THEN Ledger_Balance_II(M.AccountNumber,'{0}',M.MortgageID) END)),0),2) AS 'Book Value',", FormatDatePicker(dtpAsOf))
        'SQL &= "     IFNULL(COUNT((CASE WHEN Category(M.CategoryID) IN ('ON GOING CASE','DECIDED CASE','EXECUTED CASE','DISMISSED CASE','ARCHIVED CASE') AND Subcategory(M.SubCategoryID) != 'NEWLY FILED' THEN M.ID END)),0) AS 'Beginning',"
        SQL &= "     FORMAT(IFNULL((SELECT COUNT(ID) FROM case_main M_2 WHERE (SELECT MovementDate FROM case_details D_2 WHERE M_2.ID = D_2.CaseID AND M_2.CategoryID = D_2.CategoryID AND M_2.SubcategoryID = D_2.SubcategoryID AND D_2.status = 'ACTIVE') < DATE_FORMAT(D.MovementDate,'%Y-%m-01') AND Category(M_2.CategoryID) IN ('ON GOING CASE','DECIDED CASE','EXECUTED CASE','DISMISSED CASE','ARCHIVED CASE')),0),0) AS 'Beginning',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN Category(M.CategoryID) IN ('WRITE OFF') THEN M.ID END)),0),0) AS 'Written Off',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN case_status = 'FULLY PAID' THEN M.ID END)),0),0) AS 'Fully Paid',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN Category(M.CategoryID) IN ('ON GOING CASE','DECIDED CASE','EXECUTED CASE','DISMISSED CASE','ARCHIVED CASE') THEN M.ID END)),0),0) AS 'New',"
        SQL &= "     0 AS 'End'"
        SQL &= " FROM case_main M LEFT JOIN (SELECT ID, CaseID, CategoryID, SubcategoryID, MovementDate FROM case_details WHERE `status` = 'ACTIVE') D ON M.ID = D.CaseID AND M.CategoryID = D.CategoryID AND M.SubcategoryID = D.SubcategoryID "
        SQL &= String.Format(" WHERE `status` = 'ACTIVE'  AND BranchID IN ({0}) AND MovementDate BETWEEN '{1}' AND LAST_DAY('{2}') GROUP BY MONTH(MovementDate), YEAR(MovementDate)", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(dtpAsOf.Value.AddMonths(-6), "yyyy-MM-01"), Format(dtpAsOf.Value, "yyyy-MM-dd"))
        DT = DataSource(SQL)
        Dim DT_Summary As DataTable = DataSource(SQL & " LIMIT 0")
        Dim CurrentPos As Integer = 0
        If DT.Rows.Count > 0 Then
            For x As Integer = 0 To 6
                For y As Integer = 0 To DT.Rows.Count - 1
                    If DT(y + CurrentPos)("Date") = Format(dtpAsOf.Value.AddMonths(-6 + x), "MMMM yyyy") Then
                        DT_Summary.Rows.Add(Format(dtpAsOf.Value.AddMonths(-6 + x), "MMMM yyyy"), DT(y + CurrentPos)("Book Value"), DT(y + CurrentPos)("Beginning"), DT(y + CurrentPos)("Written Off"), DT(y + CurrentPos)("Fully Paid"), DT(y + CurrentPos)("New"), DT(y + CurrentPos)("End"))
                        If CurrentPos = DT.Rows.Count - 1 Then
                        Else
                            CurrentPos += 1
                        End If
                        Exit For
                    Else
                        DT_Summary.Rows.Add(Format(dtpAsOf.Value.AddMonths(-6 + x), "MMMM yyyy"), "0.00", 0, 0, 0, 0, 0)
                        Exit For
                    End If
                Next
            Next
        End If

        For x As Integer = 0 To DT_Summary.Rows.Count - 1
            If x > 0 And CInt(DT_Summary(x)("Beginning")) = 0 Then
                DT_Summary(x)("Beginning") = CInt(DT_Summary(x - 1)("End"))
            End If
            DT_Summary(x)("End") = ((CInt(DT_Summary(x)("Beginning")) - CInt(DT_Summary(x)("Written Off"))) - CInt(DT_Summary(x)("Fully Paid"))) + CInt(DT_Summary(x)("New"))
        Next
        If DT_Summary.Rows.Count = 7 Then
            lblMonth_1.Text = DT_Summary(0)("Date")
            lblBV_1.Text = DT_Summary(0)("Book Value")
            lblBeginning_1.Text = DT_Summary(0)("Beginning")
            lblWrittenOff_1.Text = DT_Summary(0)("Written Off")
            lblFullyPaid_1.Text = DT_Summary(0)("Fully Paid")
            lblNew_1.Text = DT_Summary(0)("New")
            lblEnding_1.Text = DT_Summary(0)("End")

            lblMonth_2.Text = DT_Summary(1)("Date")
            lblBV_2.Text = DT_Summary(1)("Book Value")
            lblBeginning_2.Text = DT_Summary(1)("Beginning")
            lblWrittenOff_2.Text = DT_Summary(1)("Written Off")
            lblFullyPaid_2.Text = DT_Summary(1)("Fully Paid")
            lblNew_2.Text = DT_Summary(1)("New")
            lblEnding_2.Text = DT_Summary(1)("End")

            lblMonth_3.Text = DT_Summary(2)("Date")
            lblBV_3.Text = DT_Summary(2)("Book Value")
            lblBeginning_3.Text = DT_Summary(2)("Beginning")
            lblWrittenOff_3.Text = DT_Summary(2)("Written Off")
            lblFullyPaid_3.Text = DT_Summary(2)("Fully Paid")
            lblNew_3.Text = DT_Summary(2)("New")
            lblEnding_3.Text = DT_Summary(2)("End")

            lblMonth_4.Text = DT_Summary(3)("Date")
            lblBV_4.Text = DT_Summary(3)("Book Value")
            lblBeginning_4.Text = DT_Summary(3)("Beginning")
            lblWrittenOff_4.Text = DT_Summary(3)("Written Off")
            lblFullyPaid_4.Text = DT_Summary(3)("Fully Paid")
            lblNew_4.Text = DT_Summary(3)("New")
            lblEnding_4.Text = DT_Summary(3)("End")

            lblMonth_5.Text = DT_Summary(4)("Date")
            lblBV_5.Text = DT_Summary(4)("Book Value")
            lblBeginning_5.Text = DT_Summary(4)("Beginning")
            lblWrittenOff_5.Text = DT_Summary(4)("Written Off")
            lblFullyPaid_5.Text = DT_Summary(4)("Fully Paid")
            lblNew_5.Text = DT_Summary(4)("New")
            lblEnding_5.Text = DT_Summary(4)("End")

            lblMonth_6.Text = DT_Summary(5)("Date")
            lblBV_6.Text = DT_Summary(5)("Book Value")
            lblBeginning_6.Text = DT_Summary(5)("Beginning")
            lblWrittenOff_6.Text = DT_Summary(5)("Written Off")
            lblFullyPaid_6.Text = DT_Summary(5)("Fully Paid")
            lblNew_6.Text = DT_Summary(5)("New")
            lblEnding_6.Text = DT_Summary(5)("End")

            lblMonth_7.Text = DT_Summary(6)("Date")
            lblBV_7.Text = DT_Summary(6)("Book Value")
            lblBeginning_7.Text = DT_Summary(6)("Beginning")
            lblWrittenOff_7.Text = DT_Summary(6)("Written Off")
            lblFullyPaid_7.Text = DT_Summary(6)("Fully Paid")
            lblNew_7.Text = DT_Summary(6)("New")
            lblEnding_7.Text = DT_Summary(6)("End")
        End If

        SQL = "SELECT "
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 19 THEN M.ID END)),0),0) AS 'A1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 2 THEN M.ID END)),0),0) AS 'B1', "
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 47 THEN M.ID END)),0),0) AS 'C1', "
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 48 THEN M.ID END)),0),0) AS 'D1', "
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 49 THEN M.ID END)),0),0) AS 'E1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 50 THEN M.ID END)),0),0) AS 'F1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 51 THEN M.ID END)),0),0) AS 'G1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 52 THEN M.ID END)),0),0) AS 'H1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 27 THEN M.ID END)),0),0) AS 'I1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 28 THEN M.ID END)),0),0) AS 'J1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 29 THEN M.ID END)),0),0) AS 'K1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 30 THEN M.ID END)),0),0) AS 'L1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 31 THEN M.ID END)),0),0) AS 'M1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 32 THEN M.ID END)),0),0) AS 'N1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 33 THEN M.ID END)),0),0) AS 'O1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 34 THEN M.ID END)),0),0) AS 'P1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 35 THEN M.ID END)),0),0) AS 'Q1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 36 THEN M.ID END)),0),0) AS 'R1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 37 THEN M.ID END)),0),0) AS 'S1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 38 THEN M.ID END)),0),0) AS 'T1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 39 THEN M.ID END)),0),0) AS 'U1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 40 THEN M.ID END)),0),0) AS 'V1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 41 THEN M.ID END)),0),0) AS 'W1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 42 THEN M.ID END)),0),0) AS 'X1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 43 THEN M.ID END)),0),0) AS 'Y1',"
        SQL &= "     FORMAT(IFNULL(COUNT((CASE WHEN D.SubCategoryID = 44 THEN M.ID END)),0),0) AS 'Z1',"

        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 19 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'A2',", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 2 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'B2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 47 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'C2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 48 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'D2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 49 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'E2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 50 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'F2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 51 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'G2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 52 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'H2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 27 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'I2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 28 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'J2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 29 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'K2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 30 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'L2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 31 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'M2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 32 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'N2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 33 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'O2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 34 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'P2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 35 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'Q2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 36 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'R2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 37 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'S2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 38 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'T2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 39 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'U2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 40 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'V2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 41 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'W2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 42 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'X2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 43 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'Y2', ", FormatDatePicker(dtpAsOf))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN D.SubCategoryID = 44 THEN Ledger_Balance_II(M.AccountNumber, '{0}',M.MortgageID) END)),0),2) AS 'Z2' ", FormatDatePicker(dtpAsOf))

        SQL &= String.Format(" FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(MovementDate) AS 'MovementDate' FROM case_details WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{0}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND BranchID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(dtpAsOf.Value, "yyyy-MM-dd"))

        Dim DT_Legend As DataTable = DataSource(SQL)
        If DT_Legend.Rows.Count > 0 Then
            lblA1.Text = DT_Legend(0)("A1")
            lblB1.Text = DT_Legend(0)("B1")
            lblC1.Text = DT_Legend(0)("C1")
            lblD1.Text = DT_Legend(0)("D1")
            lblE1.Text = DT_Legend(0)("E1")
            lblF1.Text = DT_Legend(0)("F1")
            lblG1.Text = DT_Legend(0)("G1")
            lblH1.Text = DT_Legend(0)("H1")
            lblI1.Text = DT_Legend(0)("I1")
            lblJ1.Text = DT_Legend(0)("J1")
            lblK1.Text = DT_Legend(0)("K1")
            lblL1.Text = DT_Legend(0)("L1")
            lblM1.Text = DT_Legend(0)("M1")
            lblN1.Text = DT_Legend(0)("N1")
            lblO1.Text = DT_Legend(0)("O1")
            lblP1.Text = DT_Legend(0)("P1")
            lblQ1.Text = DT_Legend(0)("Q1")
            lblR1.Text = DT_Legend(0)("R1")
            lblS1.Text = DT_Legend(0)("S1")
            lblT1.Text = DT_Legend(0)("T1")
            lblU1.Text = DT_Legend(0)("U1")
            lblV1.Text = DT_Legend(0)("V1")
            lblW1.Text = DT_Legend(0)("W1")
            lblX1.Text = DT_Legend(0)("X1")
            lblY1.Text = DT_Legend(0)("Y1")
            lblZ1.Text = DT_Legend(0)("Z1")

            lblA2.Text = DT_Legend(0)("A2")
            lblB2.Text = DT_Legend(0)("B2")
            lblC2.Text = DT_Legend(0)("C2")
            lblD2.Text = DT_Legend(0)("D2")
            lblE2.Text = DT_Legend(0)("E2")
            lblF2.Text = DT_Legend(0)("F2")
            lblG2.Text = DT_Legend(0)("G2")
            lblH2.Text = DT_Legend(0)("H2")
            lblI2.Text = DT_Legend(0)("I2")
            lblJ2.Text = DT_Legend(0)("J2")
            lblK2.Text = DT_Legend(0)("K2")
            lblL2.Text = DT_Legend(0)("L2")
            lblM2.Text = DT_Legend(0)("M2")
            lblN2.Text = DT_Legend(0)("N2")
            lblO2.Text = DT_Legend(0)("O2")
            lblP2.Text = DT_Legend(0)("P2")
            lblQ2.Text = DT_Legend(0)("Q2")
            lblR2.Text = DT_Legend(0)("R2")
            lblS2.Text = DT_Legend(0)("S2")
            lblT2.Text = DT_Legend(0)("T2")
            lblU2.Text = DT_Legend(0)("U2")
            lblV2.Text = DT_Legend(0)("V2")
            lblW2.Text = DT_Legend(0)("W2")
            lblX2.Text = DT_Legend(0)("X2")
            lblY2.Text = DT_Legend(0)("Y2")
            lblZ2.Text = DT_Legend(0)("Z2")
        End If
        Cursor = Cursors.Default

        LoadOngoing()
        LoadDecided()
        LoadExecuted()
        LoadDismissed()
        LoadArchived()
        LoadCollection()
    End Sub

    Private Sub LoadCollection()
        Cursor = Cursors.WaitCursor
        lblCM.Text = "Current Month (" & Format(dtpAsOf.Value.AddMonths(-1), "MMMM") & ")"
        lblPY.Text = "Previous Year (" & Format(dtpAsOf.Value.AddYears(-1), "yyyy") & ")"
        Dim SQL As String = "SELECT "
        SQL &= "     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'ON GOING CASE' THEN Amount END)),0),2) AS 'Ongoing Account',"
        SQL &= "     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'DECIDED CASE' THEN Amount END)),0),2) AS 'Decided Account', "
        SQL &= "     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'EXECUTED CASE' THEN Amount END)),0),2) AS 'Executed Account', "
        SQL &= "     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'DISMISSED CASE' THEN Amount END)),0),2) AS 'Dismissed Account', "
        SQL &= "     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'ARCHIVED CASE' THEN Amount END)),0),2) AS 'Archived Account',"

        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'ON GOING CASE' AND DATE(Trans_Date) <= LAST_DAY('{0}') THEN Amount END)),0),2) AS 'Ongoing Account CM',", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'DECIDED CASE' AND DATE(Trans_Date) <= LAST_DAY('{0}') THEN Amount END)),0),2) AS 'Decided Account CM', ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'EXECUTED CASE' AND DATE(Trans_Date) <= LAST_DAY('{0}') THEN Amount END)),0),2) AS 'Executed Account CM', ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'DISMISSED CASE' AND DATE(Trans_Date) <= LAST_DAY('{0}') THEN Amount END)),0),2) AS 'Dismissed Account CM', ", Format(dtpAsOf.Value, "yyyy-MM-dd"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'ARCHIVED CASE' AND DATE(Trans_Date) <= LAST_DAY('{0}') THEN Amount END)),0),2) AS 'Archived Account CM',", Format(dtpAsOf.Value, "yyyy-MM-dd"))

        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'ON GOING CASE' AND YEAR(Trans_Date) = YEAR('{0}') THEN Amount END)),0),2) AS 'Ongoing Account PY',", Format(dtpAsOf.Value.AddYears(-1), "yyyy-MM-dd"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'DECIDED CASE' AND YEAR(Trans_Date) = YEAR('{0}') THEN Amount END)),0),2) AS 'Decided Account PY', ", Format(dtpAsOf.Value.AddYears(-1), "yyyy-MM-dd"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'EXECUTED CASE' AND YEAR(Trans_Date) = YEAR('{0}') THEN Amount END)),0),2) AS 'Executed Account PY', ", Format(dtpAsOf.Value.AddYears(-1), "yyyy-MM-dd"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'DISMISSED CASE' AND YEAR(Trans_Date) = YEAR('{0}') THEN Amount END)),0),2) AS 'Dismissed Account PY', ", Format(dtpAsOf.Value.AddYears(-1), "yyyy-MM-dd"))
        SQL &= String.Format("     FORMAT(IFNULL(SUM((CASE WHEN Category(CategoryID) = 'ARCHIVED CASE' AND YEAR(Trans_Date) = YEAR('{0}') THEN Amount END)),0),2) AS 'Archived Account PY'", Format(dtpAsOf.Value.AddYears(-1), "yyyy-MM-dd"))
        SQL &= " FROM case_ledger "
        SQL &= String.Format(" WHERE `status` = 'ACTIVE' AND `Transaction` = 'Payment' AND Branch_ID IN ({0}) AND DATE(Trans_Date) <= LAST_DAY('{1}');", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(dtpAsOf.Value, "yyyy-MM-dd"))
        Dim DT As DataTable = DataSource(SQL)
        If DT.Rows.Count > 0 Then
            Dim TotalA As Integer
            Dim TotalA_CM As Integer
            Dim TotalA_PY As Integer
            TotalA = CInt(DT(0)("Ongoing Account")) + CInt(DT(0)("Decided Account")) + CInt(DT(0)("Executed Account")) + CInt(DT(0)("Dismissed Account")) + CInt(DT(0)("Archived Account"))
            TotalA_CM = CInt(DT(0)("Ongoing Account CM")) + CInt(DT(0)("Decided Account CM")) + CInt(DT(0)("Executed Account CM")) + CInt(DT(0)("Dismissed Account CM")) + CInt(DT(0)("Archived Account CM"))
            TotalA_PY = CInt(DT(0)("Ongoing Account PY")) + CInt(DT(0)("Decided Account PY")) + CInt(DT(0)("Executed Account PY")) + CInt(DT(0)("Dismissed Account PY")) + CInt(DT(0)("Archived Account PY"))

            'Count ************************************
            lblOnGoing_C_YTD.Text = DT(0)("Ongoing Account")
            lblDecided_C_YTD.Text = DT(0)("Decided Account")
            lblExecuted_C_YTD.Text = DT(0)("Executed Account")
            lblDismissed_C_YTD.Text = DT(0)("Dismissed Account")
            lblArchieved_C_YTD.Text = DT(0)("Archived Account")
            lblTotal_C_YTD.Text = FormatNumber(TotalA, 2)

            lblOnGoing_C_CM.Text = DT(0)("Ongoing Account CM")
            lblDecided_C_CM.Text = DT(0)("Decided Account CM")
            lblExecuted_C_CM.Text = DT(0)("Executed Account CM")
            lblDismissed_C_CM.Text = DT(0)("Dismissed Account CM")
            lblArchieved_C_CM.Text = DT(0)("Archived Account CM")
            lblTotal_C_CM.Text = FormatNumber(TotalA_CM, 2)

            lblOnGoing_C_PY.Text = DT(0)("Ongoing Account PY")
            lblDecided_C_PY.Text = DT(0)("Decided Account PY")
            lblExecuted_C_PY.Text = DT(0)("Executed Account PY")
            lblDismissed_C_PY.Text = DT(0)("Dismissed Account PY")
            lblArchieved_C_PY.Text = DT(0)("Archived Account PY")
            lblTotal_C_PY.Text = FormatNumber(TotalA_PY, 2)

            'Percentage ************************************
            lblOnGoing_P_YTD.Text = FormatNumber((DT(0)("Ongoing Account") / TotalA) * 100, 2) & " %"
            lblDecided_P_YTD.Text = FormatNumber((DT(0)("Decided Account") / TotalA) * 100, 2) & " %"
            lblExecuted_P_YTD.Text = FormatNumber((DT(0)("Executed Account") / TotalA) * 100, 2) & " %"
            lblDismissed_P_YTD.Text = FormatNumber((DT(0)("Dismissed Account") / TotalA) * 100, 2) & " %"
            lblArchieved_P_YTD.Text = FormatNumber((DT(0)("Archived Account") / TotalA) * 100, 2) & " %"
            lblTotal_P_YTD.Text = FormatNumber((TotalA / TotalA) * 100, 2) & " %"

            lblOnGoing_P_CM.Text = FormatNumber((DT(0)("Ongoing Account CM") / TotalA_CM) * 100, 2) & " %"
            lblDecided_P_CM.Text = FormatNumber((DT(0)("Decided Account CM") / TotalA_CM) * 100, 2) & " %"
            lblExecuted_P_CM.Text = FormatNumber((DT(0)("Executed Account CM") / TotalA_CM) * 100, 2) & " %"
            lblDismissed_P_CM.Text = FormatNumber((DT(0)("Dismissed Account CM") / TotalA_CM) * 100, 2) & " %"
            lblArchieved_P_CM.Text = FormatNumber((DT(0)("Archived Account CM") / TotalA_CM) * 100, 2) & " %"
            lblTotal_P_CM.Text = FormatNumber((TotalA_CM / TotalA_CM) * 100, 2) & " %"

            lblOnGoing_P_PY.Text = FormatNumber((DT(0)("Ongoing Account PY") / TotalA_PY) * 100, 2) & " %"
            lblDecided_P_PY.Text = FormatNumber((DT(0)("Decided Account PY") / TotalA_PY) * 100, 2) & " %"
            lblExecuted_P_PY.Text = FormatNumber((DT(0)("Executed Account PY") / TotalA_PY) * 100, 2) & " %"
            lblDismissed_P_PY.Text = FormatNumber((DT(0)("Dismissed Account PY") / TotalA_PY) * 100, 2) & " %"
            lblArchieved_P_PY.Text = FormatNumber((DT(0)("Archived Account PY") / TotalA_PY) * 100, 2) & " %"
            lblTotal_P_PY.Text = FormatNumber((TotalA_PY / TotalA_PY) * 100, 2) & " %"
        End If
        Cursor = Cursors.Default

        LineChart(Chart1)
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 1 THEN Amount END),0),2) AS 'Jan',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 2 THEN Amount END),0),2) AS 'Feb',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 3 THEN Amount END),0),2) AS 'Mar',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 4 THEN Amount END),0),2) AS 'Apr',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 5 THEN Amount END),0),2) AS 'May',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 6 THEN Amount END),0),2) AS 'Jun',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 7 THEN Amount END),0),2) AS 'Jul',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 8 THEN Amount END),0),2) AS 'Aug',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 9 THEN Amount END),0),2) AS 'Sep',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 10 THEN Amount END),0),2) AS 'Oct',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 11 THEN Amount END),0),2) AS 'Nov',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 12 THEN Amount END),0),2) AS 'Dec'"
        SQL &= String.Format(" FROM case_ledger WHERE `status` = 'ACTIVE' AND `Transaction` = 'Payment' AND YEAR(Trans_Date) = YEAR('{1}') AND Branch_ID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(dtpAsOf.Value, "yyyy-MM-dd"))

        Dim DT_Cases As DataTable = DataSource(SQL)

        Chart.Series.Clear()
        For x As Integer = 0 To DT_Cases.Columns.Count - 1
            Dim Series1 As New Series(DT_Cases(0)(x), ViewType.Bar)
            Series1.Points.Add(New SeriesPoint(DT_Cases.Columns(x).Caption.ToString, FormatNumber(CDbl(DT_Cases(0)(x)), 2)))
            Chart.Series.Add(Series1)
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadOngoing()
        Cursor = Cursors.WaitCursor
        Dim DT_Result As DataTable
        Dim DT As New DataTable
        With DT
            .Columns.Add("ID")
            .Columns.Add("Branch")
            .Columns.Add("Defendant")
            .Columns.Add("Case Number")
            .Columns.Add("Date Filed")
            .Columns.Add("Book Value")
            .Columns.Add("Counsel")
            .Columns.Add("Address")
            .Columns.Add("Contact Number")
            .Columns.Add("Remarks")
            .Columns.Add("Payments Collected")
            .Columns.Add("Date")
        End With
        Dim SQL As String
        Dim DT_Ongoing As DataTable = DataSource("SELECT ID, SubCategory FROM case_subcategory WHERE `status` = 'ACTIVE' AND CategoryID = 1 ORDER BY `Rank`;")
        For x As Integer = 0 To DT_Ongoing.Rows.Count - 1
            DT.Rows.Add(0, DT_Ongoing(x)("SubCategory"), "", "", "", "", "", "", "", "", "", "")
            SQL = "SELECT "
            SQL &= "  M.ID, D.CategoryID, D.SubCategoryID,"
            SQL &= "  Branch (BranchID) AS 'Branch',"
            SQL &= "  Borrower (BorrowerID) AS 'Defendant',"
            SQL &= "  CaseNumber AS 'Case Number',"
            SQL &= "  DATE_FORMAT(DateFilled, '%M %d, %Y') AS 'Date Filed',"
            SQL &= String.Format("  FORMAT(Ledger_Balance_II (M.AccountNumber, '{0}',M.MortgageID),2) AS 'Book Value',", Format(dtpAsOf.Value, "yyyy-MM-dd"))
            SQL &= "  IFNULL(Employee (CounselID),'') AS 'Counsel',"
            SQL &= "  (SELECT CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Address',"
            SQL &= "  (SELECT Mobile_B FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Contact Number',"
            SQL &= "  D.Remarks AS 'Remarks',"
            SQL &= "  IFNULL((SELECT SUM(Amount) FROM case_ledger WHERE CaseID = M.ID AND `status` = 'ACTIVE' AND `Type` = 'Deduct'),0) AS 'Payments Collected',"
            SQL &= "  DATE_FORMAT(D.MovementDate, '%M %d, %Y') AS 'Date'"
            SQL &= String.Format(" FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate', Remarks FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{1}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE `status` = 'ACTIVE' AND D.CategoryID = 1  AND D.SubCategoryID = {2} AND BranchID IN ({0}) ORDER BY (SELECT `Rank` FROM case_subcategory S WHERE S.ID = M.`SubCategoryID`)", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(dtpAsOf.Value, "yyyy-MM-dd"), DT_Ongoing(x)("ID"))
            DT_Result = DataSource(SQL)
            If DT_Result.Rows.Count > 0 Then
                For y As Integer = 0 To DT_Result.Rows.Count - 1
                    DT.Rows.Add(DT_Result(y)("ID"), DT_Result(y)("Branch"), y + 1 & ". " & DT_Result(y)("Defendant"), DT_Result(y)("Case Number"), DT_Result(y)("Date Filed"), DT_Result(y)("Book Value"), DT_Result(y)("Counsel"), DT_Result(y)("Address"), DT_Result(y)("Contact Number"), DT_Result(y)("Remarks"), DT_Result(y)("Payments Collected"), DT_Result(y)("Date"))
                Next
                If DT_Result.Rows.Count < 5 Then
                    For y As Integer = 1 To 5 - DT_Result.Rows.Count
                        DT.Rows.Add(1, "", DT_Result.Rows.Count + y & ".", "", "", "", "", "", "", "", "", "")
                    Next
                End If
            Else
                With DT
                    .Rows.Add(1, "", "1.", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "2.", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "3.", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "4.", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "5.", "", "", "", "", "", "", "", "", "")
                End With
            End If
        Next
        GridControl1.DataSource = DT

        If GridView1.RowCount > 22 Then
            GridColumn6.Width = 258
        Else
            GridColumn6.Width = 258 + 17
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadDecided()
        Cursor = Cursors.WaitCursor
        Dim DT_Result As DataTable
        Dim DT As New DataTable
        With DT
            .Columns.Add("ID")
            .Columns.Add("Branch")
            .Columns.Add("Defendant")
            .Columns.Add("Case Number")
            .Columns.Add("Date Filed")
            .Columns.Add("Book Value")
            .Columns.Add("Decision Value")
            .Columns.Add("Counsel")
            .Columns.Add("Address")
            .Columns.Add("Contact Number")
            .Columns.Add("Remarks")
            .Columns.Add("Last Payment")
            .Columns.Add("Payments Collected")
            .Columns.Add("Date")
        End With
        Dim SQL As String
        Dim DT_Decided As DataTable = DataSource("SELECT ID, SubCategory FROM case_subcategory WHERE `status` = 'ACTIVE' AND CategoryID = 7 ORDER BY `Rank`;")
        For x As Integer = 0 To DT_Decided.Rows.Count - 1
            DT.Rows.Add(0, DT_Decided(x)("SubCategory"), "", "", "", "", "", "", "", "", "", "", "", "")
            SQL = "SELECT "
            SQL &= "  M.ID, D.CategoryID, D.SubCategoryID,"
            SQL &= "  Branch (BranchID) AS 'Branch',"
            SQL &= "  Borrower (BorrowerID) AS 'Defendant',"
            SQL &= "  CaseNumber AS 'Case Number',"
            SQL &= "  DATE_FORMAT(DateFilled, '%M %d, %Y') AS 'Date Filed',"
            SQL &= String.Format("  FORMAT(Ledger_Balance_II (M.AccountNumber, '{0}',M.MortgageID),2) AS 'Book Value',", Format(dtpAsOf.Value, "yyyy-MM-dd"))
            SQL &= "  FORMAT(DecisionValue,2) AS 'Decision Value',"
            SQL &= "  IFNULL(Employee (CounselID),'') AS 'Counsel',"
            SQL &= "  (SELECT CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Address',"
            SQL &= "  (SELECT Mobile_B FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Contact Number',"
            SQL &= "  D.Remarks AS 'Remarks',"
            SQL &= "  IFNULL((SELECT DATE_FORMAT(MAX(Trans_Date), '%M %d, %Y') FROM case_ledger L WHERE TRANSACTION = 'Payment' AND `status` = 'ACTIVE' AND L.CaseID = M.ID),'') AS 'Last Payment', "
            SQL &= "  IFNULL((SELECT SUM(Amount) FROM case_ledger WHERE CaseID = M.ID AND `status` = 'ACTIVE' AND `Type` = 'Deduct'),0) AS 'Payments Collected',"
            SQL &= "  DATE_FORMAT(D.MovementDate, '%M %d, %Y') AS 'Date'"
            SQL &= String.Format(" FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate', Remarks FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{1}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE `status` = 'ACTIVE' AND D.CategoryID = 7  AND D.SubCategoryID = {2} AND BranchID IN ({0}) ORDER BY (SELECT `Rank` FROM case_subcategory S WHERE S.ID = M.`SubCategoryID`)", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(dtpAsOf.Value, "yyyy-MM-dd"), DT_Decided(x)("ID"))
            DT_Result = DataSource(SQL)
            If DT_Result.Rows.Count > 0 Then
                For y As Integer = 0 To DT_Result.Rows.Count - 1
                    DT.Rows.Add(DT_Result(y)("ID"), DT_Result(y)("Branch"), y + 1 & ". " & DT_Result(y)("Defendant"), DT_Result(y)("Case Number"), DT_Result(y)("Date Filed"), DT_Result(y)("Book Value"), DT_Result(y)("Decision Value"), DT_Result(y)("Counsel"), DT_Result(y)("Address"), DT_Result(y)("Contact Number"), DT_Result(y)("Remarks"), DT_Result(y)("Last Payment"), DT_Result(y)("Payments Collected"), DT_Result(y)("Date"))
                Next
                If DT_Result.Rows.Count < 5 Then
                    For y As Integer = 1 To 5 - DT_Result.Rows.Count
                        DT.Rows.Add(1, "", DT_Result.Rows.Count + y & ".", "", "", "", "", "", "", "", "", "", "", "")
                    Next
                End If
            Else
                With DT
                    .Rows.Add(1, "", "1.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "2.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "3.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "4.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "5.", "", "", "", "", "", "", "", "", "", "", "")
                End With
            End If
        Next
        GridControl2.DataSource = DT

        If GridView2.RowCount > 22 Then
            GridColumn18.Width = 253
        Else
            GridColumn18.Width = 253 + 17
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadExecuted()
        Cursor = Cursors.WaitCursor
        Dim DT_Result As DataTable
        Dim DT As New DataTable
        With DT
            .Columns.Add("ID")
            .Columns.Add("Branch")
            .Columns.Add("Defendant")
            .Columns.Add("Case Number")
            .Columns.Add("Date Filed")
            .Columns.Add("Book Value")
            .Columns.Add("Decision Value")
            .Columns.Add("Counsel")
            .Columns.Add("Address")
            .Columns.Add("Contact Number")
            .Columns.Add("Remarks")
            .Columns.Add("Last Payment")
            .Columns.Add("Payments Collected")
            .Columns.Add("Date")
        End With
        Dim SQL As String
        Dim DT_Executed As DataTable = DataSource("SELECT ID, SubCategory FROM case_subcategory WHERE `status` = 'ACTIVE' AND CategoryID = 8 ORDER BY `Rank`;")
        For x As Integer = 0 To DT_Executed.Rows.Count - 1
            DT.Rows.Add(0, DT_Executed(x)("SubCategory"), "", "", "", "", "", "", "", "", "", "", "", "")
            SQL = "SELECT "
            SQL &= "  M.ID, D.CategoryID, D.SubCategoryID,"
            SQL &= "  Branch (BranchID) AS 'Branch',"
            SQL &= "  Borrower (BorrowerID) AS 'Defendant',"
            SQL &= "  CaseNumber AS 'Case Number',"
            SQL &= "  DATE_FORMAT(DateFilled, '%M %d, %Y') AS 'Date Filed',"
            SQL &= String.Format("  FORMAT(Ledger_Balance_II (M.AccountNumber, '{0}',M.MortgageID),2) AS 'Book Value',", Format(dtpAsOf.Value, "yyyy-MM-dd"))
            SQL &= "  FORMAT(DecisionValue,2) AS 'Decision Value',"
            SQL &= "  IFNULL(Employee (CounselID),'') AS 'Counsel',"
            SQL &= "  (SELECT CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Address',"
            SQL &= "  (SELECT Mobile_B FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Contact Number',"
            SQL &= "  D.Remarks AS 'Remarks',"
            SQL &= "  IFNULL((SELECT DATE_FORMAT(MAX(Trans_Date), '%M %d, %Y') FROM case_ledger L WHERE TRANSACTION = 'Payment' AND `status` = 'ACTIVE' AND L.CaseID = M.ID),'') AS 'Last Payment', "
            SQL &= "  IFNULL((SELECT SUM(Amount) FROM case_ledger WHERE CaseID = M.ID AND `status` = 'ACTIVE' AND `Type` = 'Deduct'),0) AS 'Payments Collected',"
            SQL &= "  DATE_FORMAT(D.MovementDate, '%M %d, %Y') AS 'Date'"
            SQL &= String.Format(" FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate', Remarks FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{1}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE `status` = 'ACTIVE' AND D.CategoryID = 8  AND D.SubCategoryID = {2} AND BranchID IN ({0}) ORDER BY (SELECT `Rank` FROM case_subcategory S WHERE S.ID = M.`SubCategoryID`)", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(dtpAsOf.Value, "yyyy-MM-dd"), DT_Executed(x)("ID"))
            DT_Result = DataSource(SQL)
            If DT_Result.Rows.Count > 0 Then
                For y As Integer = 0 To DT_Result.Rows.Count - 1
                    DT.Rows.Add(DT_Result(y)("ID"), DT_Result(y)("Branch"), y + 1 & ". " & DT_Result(y)("Defendant"), DT_Result(y)("Case Number"), DT_Result(y)("Date Filed"), DT_Result(y)("Book Value"), DT_Result(y)("Decision Value"), DT_Result(y)("Counsel"), DT_Result(y)("Address"), DT_Result(y)("Contact Number"), DT_Result(y)("Remarks"), DT_Result(y)("Last Payment"), DT_Result(y)("Payments Collected"), DT_Result(y)("Date"))
                Next
                If DT_Result.Rows.Count < 5 Then
                    For y As Integer = 1 To 5 - DT_Result.Rows.Count
                        DT.Rows.Add(1, "", DT_Result.Rows.Count + y & ".", "", "", "", "", "", "", "", "", "", "", "")
                    Next
                End If
            Else
                With DT
                    .Rows.Add(1, "", "1.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "2.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "3.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "4.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "5.", "", "", "", "", "", "", "", "", "", "", "")
                End With
            End If
        Next
        GridControl3.DataSource = DT

        If GridView3.RowCount > 22 Then
            GridColumn33.Width = 253
        Else
            GridColumn33.Width = 253 + 17
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadDismissed()
        Cursor = Cursors.WaitCursor
        Dim DT_Result As DataTable
        Dim DT As New DataTable
        With DT
            .Columns.Add("ID")
            .Columns.Add("Branch")
            .Columns.Add("Defendant")
            .Columns.Add("Case Number")
            .Columns.Add("Date Filed")
            .Columns.Add("Book Value")
            .Columns.Add("Decision Value")
            .Columns.Add("Counsel")
            .Columns.Add("Address")
            .Columns.Add("Contact Number")
            .Columns.Add("Remarks")
            .Columns.Add("Last Payment")
            .Columns.Add("Payments Collected")
            .Columns.Add("Date")
        End With
        Dim SQL As String
        Dim DT_Dismissed As DataTable = DataSource("SELECT ID, SubCategory FROM case_subcategory WHERE `status` = 'ACTIVE' AND CategoryID = 9 ORDER BY `Rank`;")
        For x As Integer = 0 To DT_Dismissed.Rows.Count - 1
            DT.Rows.Add(0, DT_Dismissed(x)("SubCategory"), "", "", "", "", "", "", "", "", "", "", "", "")
            SQL = "SELECT "
            SQL &= "  M.ID, D.CategoryID, D.SubCategoryID,"
            SQL &= "  Branch (BranchID) AS 'Branch',"
            SQL &= "  Borrower (BorrowerID) AS 'Defendant',"
            SQL &= "  CaseNumber AS 'Case Number',"
            SQL &= "  DATE_FORMAT(DateFilled, '%M %d, %Y') AS 'Date Filed',"
            SQL &= String.Format("  FORMAT(Ledger_Balance_II (M.AccountNumber, '{0}',M.MortgageID),2) AS 'Book Value',", Format(dtpAsOf.Value, "yyyy-MM-dd"))
            SQL &= "  FORMAT(DecisionValue,2) AS 'Decision Value',"
            SQL &= "  IFNULL(Employee (CounselID),'') AS 'Counsel',"
            SQL &= "  (SELECT CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Address',"
            SQL &= "  (SELECT Mobile_B FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Contact Number',"
            SQL &= "  D.Remarks AS 'Remarks',"
            SQL &= "  IFNULL((SELECT DATE_FORMAT(MAX(Trans_Date), '%M %d, %Y') FROM case_ledger L WHERE TRANSACTION = 'Payment' AND `status` = 'ACTIVE' AND L.CaseID = M.ID),'') AS 'Last Payment', "
            SQL &= "  IFNULL((SELECT SUM(Amount) FROM case_ledger WHERE CaseID = M.ID AND `status` = 'ACTIVE' AND `Type` = 'Deduct'),0) AS 'Payments Collected',"
            SQL &= "  DATE_FORMAT(D.MovementDate, '%M %d, %Y') AS 'Date'"
            SQL &= String.Format(" FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate', Remarks FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{1}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE `status` = 'ACTIVE' AND D.CategoryID = 9  AND D.SubCategoryID = {2} AND BranchID IN ({0}) ORDER BY (SELECT `Rank` FROM case_subcategory S WHERE S.ID = M.`SubCategoryID`)", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(dtpAsOf.Value, "yyyy-MM-dd"), DT_Dismissed(x)("ID"))
            DT_Result = DataSource(SQL)
            If DT_Result.Rows.Count > 0 Then
                For y As Integer = 0 To DT_Result.Rows.Count - 1
                    DT.Rows.Add(DT_Result(y)("ID"), DT_Result(y)("Branch"), y + 1 & ". " & DT_Result(y)("Defendant"), DT_Result(y)("Case Number"), DT_Result(y)("Date Filed"), DT_Result(y)("Book Value"), DT_Result(y)("Decision Value"), DT_Result(y)("Counsel"), DT_Result(y)("Address"), DT_Result(y)("Contact Number"), DT_Result(y)("Remarks"), DT_Result(y)("Last Payment"), DT_Result(y)("Payments Collected"), DT_Result(y)("Date"))
                Next
                If DT_Result.Rows.Count < 5 Then
                    For y As Integer = 1 To 5 - DT_Result.Rows.Count
                        DT.Rows.Add(1, "", DT_Result.Rows.Count + y & ".", "", "", "", "", "", "", "", "", "", "", "")
                    Next
                End If
            Else
                With DT
                    .Rows.Add(1, "", "1.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "2.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "3.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "4.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "5.", "", "", "", "", "", "", "", "", "", "", "")
                End With
            End If
        Next
        GridControl4.DataSource = DT

        If GridView4.RowCount > 22 Then
            GridColumn47.Width = 253
        Else
            GridColumn47.Width = 253 + 17
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadArchived()
        Cursor = Cursors.WaitCursor
        Dim DT_Result As DataTable
        Dim DT As New DataTable
        With DT
            .Columns.Add("ID")
            .Columns.Add("Branch")
            .Columns.Add("Defendant")
            .Columns.Add("Case Number")
            .Columns.Add("Date Filed")
            .Columns.Add("Book Value")
            .Columns.Add("Decision Value")
            .Columns.Add("Counsel")
            .Columns.Add("Address")
            .Columns.Add("Contact Number")
            .Columns.Add("Remarks")
            .Columns.Add("Last Payment")
            .Columns.Add("Payments Collected")
            .Columns.Add("Date")
        End With
        Dim SQL As String
        Dim DT_Archived As DataTable = DataSource("SELECT ID, SubCategory FROM case_subcategory WHERE `status` = 'ACTIVE' AND CategoryID = 10 ORDER BY `Rank`;")
        For x As Integer = 0 To DT_Archived.Rows.Count - 1
            DT.Rows.Add(0, DT_Archived(x)("SubCategory"), "", "", "", "", "", "", "", "", "", "", "", "")
            SQL = "SELECT "
            SQL &= "  M.ID, D.CategoryID, D.SubCategoryID,"
            SQL &= "  Branch (BranchID) AS 'Branch',"
            SQL &= "  Borrower (BorrowerID) AS 'Defendant',"
            SQL &= "  CaseNumber AS 'Case Number',"
            SQL &= "  DATE_FORMAT(DateFilled, '%M %d, %Y') AS 'Date Filed',"
            SQL &= String.Format("  FORMAT(Ledger_Balance_II (M.AccountNumber, '{0}',M.MortgageID),2) AS 'Book Value',", Format(dtpAsOf.Value, "yyyy-MM-dd"))
            SQL &= "  FORMAT(DecisionValue,2) AS 'Decision Value',"
            SQL &= "  IFNULL(Employee (CounselID),'') AS 'Counsel',"
            SQL &= "  (SELECT CONCAT(IF(NoC_B = '','',CONCAT(NoC_B, ', ')), IF(StreetC_B = '','',CONCAT(StreetC_B, ', ')), IF(BarangayC_B = '','',CONCAT(BarangayC_B, ', ')), AddressC_B) FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Address',"
            SQL &= "  (SELECT Mobile_B FROM profile_borrower P WHERE P.BorrowerID = M.BorrowerID) AS 'Contact Number',"
            SQL &= "  D.Remarks AS 'Remarks',"
            SQL &= "  IFNULL((SELECT DATE_FORMAT(MAX(Trans_Date), '%M %d, %Y') FROM case_ledger L WHERE TRANSACTION = 'Payment' AND `status` = 'ACTIVE' AND L.CaseID = M.ID),'') AS 'Last Payment', "
            SQL &= "  IFNULL((SELECT SUM(Amount) FROM case_ledger WHERE CaseID = M.ID AND `status` = 'ACTIVE' AND `Type` = 'Deduct'),0) AS 'Payments Collected',"
            SQL &= "  DATE_FORMAT(D.MovementDate, '%M %d, %Y') AS 'Date'"
            SQL &= String.Format(" FROM case_main M LEFT JOIN (SELECT ID, CaseID, MAX(SubCategoryID) AS 'SubCategoryID', MAX(CategoryID) AS 'CategoryID', MAX(MovementDate) AS 'MovementDate', Remarks FROM case_details D WHERE `status` = 'ACTIVE' AND DATE(MovementDate) <= LAST_DAY('{1}') GROUP BY CaseID ORDER BY MovementDate DESC, (SELECT `Rank` FROM case_category WHERE ID = CategoryID) DESC, (SELECT `Rank` FROM case_subcategory WHERE ID = SubCategoryID) DESC) D ON M.ID = D.CaseID WHERE `status` = 'ACTIVE' AND D.CategoryID = 10  AND D.SubCategoryID = {2} AND BranchID IN ({0}) ORDER BY (SELECT `Rank` FROM case_subcategory S WHERE S.ID = M.`SubCategoryID`)", If(Multiple_ID = "", Branch_ID, Multiple_ID), Format(dtpAsOf.Value, "yyyy-MM-dd"), DT_Archived(x)("ID"))
            DT_Result = DataSource(SQL)
            If DT_Result.Rows.Count > 0 Then
                For y As Integer = 0 To DT_Result.Rows.Count - 1
                    DT.Rows.Add(DT_Result(y)("ID"), DT_Result(y)("Branch"), y + 1 & ". " & DT_Result(y)("Defendant"), DT_Result(y)("Case Number"), DT_Result(y)("Date Filed"), DT_Result(y)("Book Value"), DT_Result(y)("Decision Value"), DT_Result(y)("Counsel"), DT_Result(y)("Address"), DT_Result(y)("Contact Number"), DT_Result(y)("Remarks"), DT_Result(y)("Last Payment"), DT_Result(y)("Payments Collected"), DT_Result(y)("Date"))
                Next
                If DT_Result.Rows.Count < 5 Then
                    For y As Integer = 1 To 5 - DT_Result.Rows.Count
                        DT.Rows.Add(1, "", DT_Result.Rows.Count + y & ".", "", "", "", "", "", "", "", "", "", "", "")
                    Next
                End If
            Else
                With DT
                    .Rows.Add(1, "", "1.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "2.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "3.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "4.", "", "", "", "", "", "", "", "", "", "", "")
                    .Rows.Add(1, "", "5.", "", "", "", "", "", "", "", "", "", "", "")
                End With
            End If
        Next
        GridControl5.DataSource = DT

        If GridView5.RowCount > 22 Then
            GridColumn61.Width = 253
        Else
            GridColumn61.Width = 253 + 17
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim ID As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID"))
            If ID = "0" Then
                With e.Appearance
                    .BackColor = Color.SeaGreen
                    .BackColor2 = Color.SeaGreen
                    .Font = New Font(OfficialFont, CSng(OfficialFontSize), FontStyle.Bold)
                    .ForeColor = Color.White
                End With
            Else
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If GridView2.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim ID As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID"))
            If ID = "0" Then
                With e.Appearance
                    .BackColor = Color.SeaGreen
                    .BackColor2 = Color.SeaGreen
                    .Font = New Font(OfficialFont, CSng(OfficialFontSize), FontStyle.Bold)
                    .ForeColor = Color.White
                End With
            Else
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub GridView3_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView3.RowCellStyle
        If GridView3.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim ID As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID"))
            If ID = "0" Then
                With e.Appearance
                    .BackColor = Color.SeaGreen
                    .BackColor2 = Color.SeaGreen
                    .Font = New Font(OfficialFont, CSng(OfficialFontSize), FontStyle.Bold)
                    .ForeColor = Color.White
                End With
            Else
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub GridView4_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView4.RowCellStyle
        If GridView4.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim ID As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID"))
            If ID = "0" Then
                With e.Appearance
                    .BackColor = Color.SeaGreen
                    .BackColor2 = Color.SeaGreen
                    .Font = New Font(OfficialFont, CSng(OfficialFontSize), FontStyle.Bold)
                    .ForeColor = Color.White
                End With
            Else
                e.Appearance.ForeColor = Color.Black
            End If
        End If
    End Sub

    Private Sub GridView5_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView5.RowCellStyle
        If GridView5.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim ID As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID"))
            If ID = "0" Then
                With e.Appearance
                    .BackColor = Color.SeaGreen
                    .BackColor2 = Color.SeaGreen
                    .Font = New Font(OfficialFont, CSng(OfficialFontSize), FontStyle.Bold)
                    .ForeColor = Color.White
                End With
            Else
                e.Appearance.ForeColor = Color.Black
            End If
        End If
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
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Case Summary - Ongoing", GridControl1)
            Logs("Case Summary", "Print", "[SENSITIVE] Print Case Summary - Ongoing", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            GridView2.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Case Summary - Decided", GridControl2)
            Logs("Case Summary", "Print", "[SENSITIVE] Print Case Summary - Decided", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            GridView3.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Case Summary - Executed", GridControl3)
            Logs("Case Summary", "Print", "[SENSITIVE] Print Case Summary - Executed", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            GridView4.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Case Summary - Dismissed", GridControl4)
            Logs("Case Summary", "Print", "[SENSITIVE] Print Case Summary - Dismissed", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            GridView5.OptionsPrint.UsePrintStyles = False
            StandardPrinting("Case Summary - Archived", GridControl5)
            Logs("Case Summary", "Print", "[SENSITIVE] Print Case Summary - Archived", "", "", "", "")
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
End Class