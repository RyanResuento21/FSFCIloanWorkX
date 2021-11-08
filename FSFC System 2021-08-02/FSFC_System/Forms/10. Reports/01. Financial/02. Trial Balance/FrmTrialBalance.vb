Imports DevExpress.XtraReports.UI
Public Class FrmTrialBalance

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmTrialBalance_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
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

        With cbxBook
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            FirstLoad = False
            .DataSource = DataSource("SELECT 1 AS 'ID', 'Bank 1' AS 'Bank' UNION ALL SELECT 2 AS 'ID', 'Bank 2' AS 'Bank';")
        End With

        With cbxBusinessCenter
            .ValueMember = "BusinessCode"
            .DisplayMember = "BusinessCenter"
            .SelectedIndex = -1
        End With

        'LoadData()
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

            GetLabelFontSettings({LabelX1, LabelX2, LabelX40, lblFrom, LabelX41})

            GetLabelWithBackgroundFontSettings({lblYear1, lblYear2, lblYear3, lblTotal})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank, cbxAll, cbxWithFinancialPlan, cbxCurrentOnly})

            GetTextBoxFontSettingsDefault({txtTotal_1, txtTotal_2, txtTotal_3, txtTotal_4, txtTotal_5, txtTotal_6, txtTotal_7, txtTotal_8, txtTotal_9})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})
        Catch ex As Exception
            TriggerBugReport("Trial Balance - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Trial Balance", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String
        Dim DateCondition_1 As String = ""
        Dim DateCondition_2 As String = ""
        Dim DateCondition_3 As String = ""
        If cbxDisplay.SelectedIndex = 0 Then
            DateCondition_1 = String.Format("DATE(ORDate) = DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_2 = String.Format("DATE(ORDate) = DATE('{0}')", Format(dtpFrom.Value.AddYears(-1), "yyyy-MM-dd"))
            DateCondition_3 = String.Format("DATE(ORDate) = DATE('{0}')", Format(dtpFrom.Value.AddYears(-2), "yyyy-MM-dd"))
        ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
            DateCondition_1 = String.Format("DATE(ORDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))
            DateCondition_2 = String.Format("DATE(ORDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value.AddYears(-1), "yyyy-MM-dd"), Format(dtpTo.Value.AddYears(-1), "yyyy-MM-dd"))
            DateCondition_3 = String.Format("DATE(ORDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value.AddYears(-2), "yyyy-MM-dd"), Format(dtpTo.Value.AddYears(-2), "yyyy-MM-dd"))
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            DateCondition_1 = String.Format("DATE(ORDate) <= DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_2 = String.Format("DATE(ORDate) <= DATE('{0}')", Format(dtpFrom.Value.AddYears(-1), "yyyy-MM-dd"))
            DateCondition_3 = String.Format("DATE(ORDate) <= DATE('{0}')", Format(dtpFrom.Value.AddYears(-2), "yyyy-MM-dd"))
        End If
        If CompanyMode = 0 Then
            SQL = " SELECT "
            SQL &= "    A.ID,"
            SQL &= "    A.Code AS 'Account Code', A.`Title` AS 'Account Name', A.Type_ID, A.ContraAccount, (SELECT Formula FROM account_type WHERE ID = A.Type_ID) AS 'Formula', "
            SQL &= String.Format("    (SELECT IFNULL(SUM(F.M{0}),0) FROM financial_plan F WHERE MotherCode(F.AccountCode) = A.`Code` AND F.`Year` = YEAR('{1}') AND IF('{3}' = 1,TRUE,BranchID = '{2}') AND F.`status` = 'ACTIVE' AND F.`FP_Status` = 'APPROVED' AND F.Half = IF(MONTH('{1}') BETWEEN 1 AND 6,1,2)) AS 'AsOf_Plan',", If(Format(dtpFrom.Value, "MM") > 6, Format(dtpFrom.Value.AddMonths(-6), "MM"), Format(dtpFrom.Value, "MM")), Format(dtpFrom.Value, "yyyy-MM-dd"), cbxBranch.SelectedValue, cbxAllB.Checked)
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual',", If(cbxAll.Checked, True, DateCondition_1))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual_1',", If(cbxAll.Checked, True, DateCondition_2))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual_2',", If(cbxAll.Checked, True, DateCondition_3))
            SQL &= "    0 AS 'Difference',"
            SQL &= "    0 AS 'Difference_1',"
            SQL &= "    0 AS 'Difference_2', `Status`"
            SQL &= " FROM account_chart A"
            SQL &= String.Format(" LEFT JOIN (SELECT ID, EntryType, MotherCode_Adjunct(accounting_entry.AccountCode) AS 'AccountCode', Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{4}' = '0',TRUE,BusinessCode = '{4}') AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}'))) A2 ON A2.AccountCode = A.`Code`", cbxBranch.SelectedValue, cbxAllB.Checked, Format(dtpFrom.Value, "yyyy-MM-dd"), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
            SQL &= "    WHERE A.`status` IN ('ACTIVE','DEACTIVATE') AND A.Code = '218202' AND A.Main_ID = 0 AND A.AdjunctAccount = 0 GROUP BY A.ID HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY A.Code ;"
        Else
            SQL = " SELECT "
            SQL &= "    A.ID,"
            SQL &= "    A.Code AS 'Account Code', A.`Title` AS 'Account Name', A.Type_ID, A.ContraAccount, (SELECT Formula FROM account_type WHERE ID = A.Type_ID) AS 'Formula', "
            If cbxDisplay.SelectedIndex = 3 Then
                SQL &= String.Format("    (SELECT IFNULL(SUM(F.M01) + SUM(F.M02) + SUM(F.M03) + SUM(F.M04) + SUM(F.M05) + SUM(F.M06),0) FROM financial_plan F WHERE F.AccountCode = A.`Code` AND F.`Year` = YEAR('{1}') AND IF('{3}' = 1,TRUE,BranchID = '{2}') AND F.`status` = 'ACTIVE' AND F.`FP_Status` = 'APPROVED') AS 'AsOf_Plan',", If(Format(dtpFrom.Value, "MM") > 6, Format(dtpFrom.Value.AddMonths(-6), "MM"), Format(dtpFrom.Value, "MM")), Format(dtpFrom.Value, "yyyy-MM-dd"), cbxBranch.SelectedValue, cbxAllB.Checked)
                SQL &= String.Format("    (SELECT IFNULL(SUM(F.M01) + SUM(F.M02) + SUM(F.M03) + SUM(F.M04) + SUM(F.M05) + SUM(F.M06),0) FROM financial_plan F WHERE F.AccountCode = A.`Code` AND F.`Year` = YEAR('{1}') AND IF('{3}' = 1,TRUE,BranchID = '{2}') AND F.`status` = 'ACTIVE' AND F.`FP_Status` = 'APPROVED') AS 'AsOf_Plan_1',", If(Format(dtpFrom.Value, "MM") > 6, Format(dtpFrom.Value.AddMonths(-6), "MM"), Format(dtpFrom.Value, "MM")), Format(dtpFrom.Value.AddYears(-1), "yyyy-MM-dd"), cbxBranch.SelectedValue, cbxAllB.Checked)
                SQL &= String.Format("    (SELECT IFNULL(SUM(F.M01) + SUM(F.M02) + SUM(F.M03) + SUM(F.M04) + SUM(F.M05) + SUM(F.M06),0) FROM financial_plan F WHERE F.AccountCode = A.`Code` AND F.`Year` = YEAR('{1}') AND IF('{3}' = 1,TRUE,BranchID = '{2}') AND F.`status` = 'ACTIVE' AND F.`FP_Status` = 'APPROVED') AS 'AsOf_Plan_2',", If(Format(dtpFrom.Value, "MM") > 6, Format(dtpFrom.Value.AddMonths(-6), "MM"), Format(dtpFrom.Value, "MM")), Format(dtpFrom.Value.AddYears(-2), "yyyy-MM-dd"), cbxBranch.SelectedValue, cbxAllB.Checked)
            Else
                SQL &= String.Format("    (SELECT IFNULL(SUM(F.M{0}),0) FROM financial_plan F WHERE F.AccountCode = A.`Code` AND F.`Year` = YEAR('{1}') AND IF('{3}' = 1,TRUE,BranchID = '{2}') AND F.`status` = 'ACTIVE' AND F.`FP_Status` = 'APPROVED' AND F.Half = IF(MONTH('{1}') BETWEEN 1 AND 6,1,2)) AS 'AsOf_Plan',", If(Format(dtpFrom.Value, "MM") > 6, Format(dtpFrom.Value.AddMonths(-6), "MM"), Format(dtpFrom.Value, "MM")), Format(dtpFrom.Value, "yyyy-MM-dd"), cbxBranch.SelectedValue, cbxAllB.Checked)
                SQL &= String.Format("    (SELECT IFNULL(SUM(F.M{0}),0) FROM financial_plan F WHERE F.AccountCode = A.`Code` AND F.`Year` = YEAR('{1}') AND IF('{3}' = 1,TRUE,BranchID = '{2}') AND F.`status` = 'ACTIVE' AND F.`FP_Status` = 'APPROVED' AND F.Half = IF(MONTH('{1}') BETWEEN 1 AND 6,1,2)) AS 'AsOf_Plan_1',", If(Format(dtpFrom.Value, "MM") > 6, Format(dtpFrom.Value.AddMonths(-6), "MM"), Format(dtpFrom.Value, "MM")), Format(dtpFrom.Value.AddYears(-1), "yyyy-MM-dd"), cbxBranch.SelectedValue, cbxAllB.Checked)
                SQL &= String.Format("    (SELECT IFNULL(SUM(F.M{0}),0) FROM financial_plan F WHERE F.AccountCode = A.`Code` AND F.`Year` = YEAR('{1}') AND IF('{3}' = 1,TRUE,BranchID = '{2}') AND F.`status` = 'ACTIVE' AND F.`FP_Status` = 'APPROVED' AND F.Half = IF(MONTH('{1}') BETWEEN 1 AND 6,1,2)) AS 'AsOf_Plan_2',", If(Format(dtpFrom.Value, "MM") > 6, Format(dtpFrom.Value.AddMonths(-6), "MM"), Format(dtpFrom.Value, "MM")), Format(dtpFrom.Value.AddYears(-2), "yyyy-MM-dd"), cbxBranch.SelectedValue, cbxAllB.Checked)
            End If
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual',", If(cbxAll.Checked, True, DateCondition_1))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual_1',", If(cbxAll.Checked, True, DateCondition_2))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual_2',", If(cbxAll.Checked, True, DateCondition_3))
            SQL &= "    0 AS 'Difference',"
            SQL &= "    0 AS 'Difference_1',"
            SQL &= "    0 AS 'Difference_2', `Status`"
            SQL &= " FROM account_chart A"
            SQL &= String.Format(" LEFT JOIN (SELECT ID, EntryType, AccountCode, Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{4}' = '0',TRUE,BusinessCode = '{4}') AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}'))) A2 ON A2.AccountCode = A.`Code`", cbxBranch.SelectedValue, cbxAllB.Checked, Format(dtpFrom.Value, "yyyy-MM-dd"), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
            SQL &= "    WHERE A.`status` IN ('ACTIVE','DEACTIVATE') AND A.Main_ID > 0 GROUP BY A.ID HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY A.Code ;"
        End If
        GridControl1.DataSource = DataSource(SQL)

        If CompanyMode = 0 Then
            If GridView1.RowCount > 19 Then
                GridColumn3.Width = 396 + 225 - 17

                lblTotal.Width = 482 + 225 - 17
                lblYear1.Location = New Point(486 + 225 - 17, 106)
                lblYear2.Location = New Point(710 + 150 - 17, 106)
                lblYear3.Location = New Point(935 + 76 - 17, 106)
                txtTotal_2.Location = New Point(486 + 225 - 17, 6)
                txtTotal_5.Location = New Point(710 + 150 - 17, 6)
                txtTotal_8.Location = New Point(935 + 76 - 17, 6)
            Else
                GridColumn3.Width = 396 + 225

                lblTotal.Width = 482 + 225
                lblYear1.Location = New Point(486 + 225, 106)
                lblYear2.Location = New Point(710 + 150, 106)
                lblYear3.Location = New Point(935 + 76, 106)
                txtTotal_2.Location = New Point(486 + 225, 6)
                txtTotal_5.Location = New Point(710 + 150, 6)
                txtTotal_8.Location = New Point(935 + 76, 6)
            End If
            lblYear1.Visible = False
            lblYear2.Visible = False
            lblYear3.Visible = False

            lblYear1.Size = New Point(150, 23)
            lblYear2.Size = New Point(152, 23)
            lblYear3.Size = New Point(150, 23)
            txtTotal_2.Size = New Point(75 + 75, 23)
            txtTotal_5.Size = New Point(75 + 77, 23)
            txtTotal_8.Size = New Point(75 + 75, 23)
            GridColumn5.Width = 150
            GridColumn8.Width = 150
            GridColumn11.Width = 150
            GridColumn4.Visible = False
            GridColumn6.Visible = False
            GridColumn7.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn12.Visible = False

            txtTotal_1.Visible = False
            txtTotal_3.Visible = False
            txtTotal_4.Visible = False
            txtTotal_6.Visible = False
            txtTotal_7.Visible = False
            txtTotal_9.Visible = False
        Else
            If GridView1.RowCount > 19 Then
                GridColumn3.Width = 396 - 17

                lblTotal.Width = 482 - 17
                lblYear1.Location = New Point(486 - 17, 106)
                lblYear2.Location = New Point(710 - 17, 106)
                lblYear3.Location = New Point(935 - 17, 106)
                txtTotal_1.Location = New Point(486 - 17, 6)
                txtTotal_2.Location = New Point(561 - 17, 6)
                txtTotal_3.Location = New Point(636 - 17, 6)
                txtTotal_4.Location = New Point(711 - 17, 6)
                txtTotal_5.Location = New Point(786 - 17, 6)
                txtTotal_6.Location = New Point(861 - 17, 6)
                txtTotal_7.Location = New Point(936 - 17, 6)
                txtTotal_8.Location = New Point(1011 - 17, 6)
                txtTotal_9.Location = New Point(1086 - 17, 6)
            Else
                GridColumn3.Width = 396

                lblTotal.Width = 482
                lblYear1.Location = New Point(486, 106)
                lblYear2.Location = New Point(710, 106)
                lblYear3.Location = New Point(935, 106)
                txtTotal_1.Location = New Point(486, 6)
                txtTotal_2.Location = New Point(561, 6)
                txtTotal_3.Location = New Point(636, 6)
                txtTotal_4.Location = New Point(711, 6)
                txtTotal_5.Location = New Point(786, 6)
                txtTotal_6.Location = New Point(861, 6)
                txtTotal_7.Location = New Point(936, 6)
                txtTotal_8.Location = New Point(1011, 6)
                txtTotal_9.Location = New Point(1086, 6)
            End If
            lblYear1.Visible = True
            lblYear2.Visible = True
            lblYear3.Visible = True

            lblYear1.Size = New Point(225, 23)
            lblYear2.Size = New Point(226, 23)
            lblYear3.Size = New Point(225, 23)
            txtTotal_2.Size = New Point(76, 23)
            txtTotal_5.Size = New Point(76, 23)
            txtTotal_8.Size = New Point(76, 23)
            GridColumn5.Width = 75
            GridColumn8.Width = 75
            GridColumn11.Width = 75
            GridColumn4.Visible = True
            GridColumn6.Visible = True
            GridColumn7.Visible = True
            GridColumn9.Visible = True
            GridColumn10.Visible = True
            GridColumn12.Visible = True

            txtTotal_1.Visible = True
            txtTotal_3.Visible = True
            txtTotal_4.Visible = True
            txtTotal_6.Visible = True
            txtTotal_7.Visible = True
            txtTotal_9.Visible = True

            GridColumn2.VisibleIndex = 1
            GridColumn3.VisibleIndex = 2
            GridColumn4.VisibleIndex = 3
            GridColumn5.VisibleIndex = 4
            GridColumn6.VisibleIndex = 5
            GridColumn7.VisibleIndex = 6
            GridColumn8.VisibleIndex = 7
            GridColumn9.VisibleIndex = 8
            GridColumn10.VisibleIndex = 9
            GridColumn11.VisibleIndex = 10
            GridColumn12.VisibleIndex = 11
        End If

        If cbxWithFinancialPlan.Checked = False Then
            GridColumn4.Visible = False
            GridColumn6.Visible = False
            GridColumn7.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn12.Visible = False
            lblYear1.Visible = False
            lblYear2.Visible = False
            lblYear3.Visible = False

            GridColumn5.Width = 75 * 3
            GridColumn8.Width = 75 * 3
            GridColumn11.Width = 75 * 3

            txtTotal_1.Visible = False
            txtTotal_3.Visible = False
            txtTotal_4.Visible = False
            txtTotal_6.Visible = False
            txtTotal_7.Visible = False
            txtTotal_9.Visible = False

            txtTotal_2.Size = New Point(75 * 3, 19)
            txtTotal_5.Size = New Point(75 * 3, 19)
            txtTotal_8.Size = New Point(75 * 3, 19)

            If GridView1.RowCount > 19 Then
                txtTotal_2.Location = New Point(486 - 17, 6)
                txtTotal_5.Location = New Point(711 - 17, 6)
                txtTotal_8.Location = New Point(936 - 17, 6)
            Else
                txtTotal_2.Location = New Point(486, 6)
                txtTotal_5.Location = New Point(711, 6)
                txtTotal_8.Location = New Point(936, 6)
            End If
        End If

        If cbxCurrentOnly.Checked Then
            GridColumn7.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn12.Visible = False
            'lblYear2.Visible = False
            'lblYear3.Visible = False

            GridColumn8.Width = 75 * 3
            GridColumn11.Width = 75 * 3

            txtTotal_4.Visible = False
            txtTotal_6.Visible = False
            txtTotal_7.Visible = False
            txtTotal_9.Visible = False

            txtTotal_5.Size = New Point(75 * 3, 19)
            txtTotal_8.Size = New Point(75 * 3, 19)

            If GridView1.RowCount > 19 Then
                txtTotal_5.Location = New Point(711 - 17, 6)
                txtTotal_8.Location = New Point(936 - 17, 6)
            Else
                txtTotal_5.Location = New Point(711, 6)
                txtTotal_8.Location = New Point(936, 6)
            End If
        End If

        Dim Total_1 As Double
        Dim Total_2 As Double
        Dim Total_3 As Double
        Dim Total_4 As Double
        Dim Total_5 As Double
        Dim Total_6 As Double
        Dim Total_7 As Double
        Dim Total_8 As Double
        Dim Total_9 As Double
        For x As Integer = 0 To GridView1.RowCount - 1
            If CompanyMode = 0 Then
            Else
                GridView1.SetRowCellValue(x, "Difference", CDbl(GridView1.GetRowCellValue(x, "AsOf_Plan")) - CDbl(GridView1.GetRowCellValue(x, "AsOf_Actual")))
                GridView1.SetRowCellValue(x, "Difference_1", CDbl(GridView1.GetRowCellValue(x, "AsOf_Plan_1")) - CDbl(GridView1.GetRowCellValue(x, "AsOf_Actual_1")))
                GridView1.SetRowCellValue(x, "Difference_2", CDbl(GridView1.GetRowCellValue(x, "AsOf_Plan_2")) - CDbl(GridView1.GetRowCellValue(x, "AsOf_Actual_2")))
                If GridView1.GetRowCellValue(x, "Formula") = 2 Then
                    Total_6 -= If(GridView1.GetRowCellValue(x, "ContraAccount") = 1, CDbl(GridView1.GetRowCellValue(x, "Difference_1")) * -1, CDbl(GridView1.GetRowCellValue(x, "Difference_1")))
                    Total_3 -= If(GridView1.GetRowCellValue(x, "ContraAccount") = 1, CDbl(GridView1.GetRowCellValue(x, "Difference")) * -1, CDbl(GridView1.GetRowCellValue(x, "Difference")))
                    Total_9 -= If(GridView1.GetRowCellValue(x, "ContraAccount") = 1, CDbl(GridView1.GetRowCellValue(x, "Difference_2")) * -1, CDbl(GridView1.GetRowCellValue(x, "Difference_2")))
                Else
                    Total_6 += If(GridView1.GetRowCellValue(x, "ContraAccount") = 1, CDbl(GridView1.GetRowCellValue(x, "Difference_1")) * -1, CDbl(GridView1.GetRowCellValue(x, "Difference_1")))
                    Total_3 += If(GridView1.GetRowCellValue(x, "ContraAccount") = 1, CDbl(GridView1.GetRowCellValue(x, "Difference")) * -1, CDbl(GridView1.GetRowCellValue(x, "Difference")))
                    Total_9 += If(GridView1.GetRowCellValue(x, "ContraAccount") = 1, CDbl(GridView1.GetRowCellValue(x, "Difference_2")) * -1, CDbl(GridView1.GetRowCellValue(x, "Difference_2")))
                End If
            End If
            Total_1 += GridView1.GetRowCellValue(x, "AsOf_Plan")
            Total_4 += GridView1.GetRowCellValue(x, "AsOf_Plan_1")
            Total_7 += GridView1.GetRowCellValue(x, "AsOf_Plan_2")
            If GridView1.GetRowCellValue(x, "Formula") = 2 Then
                Total_2 -= CDbl(GridView1.GetRowCellValue(x, "AsOf_Actual"))
                Total_5 -= CDbl(GridView1.GetRowCellValue(x, "AsOf_Actual_1"))
                Total_8 -= CDbl(GridView1.GetRowCellValue(x, "AsOf_Actual_2"))
            Else
                Total_2 += CDbl(GridView1.GetRowCellValue(x, "AsOf_Actual"))
                Total_5 += CDbl(GridView1.GetRowCellValue(x, "AsOf_Actual_1"))
                Total_8 += CDbl(GridView1.GetRowCellValue(x, "AsOf_Actual_2"))
            End If
        Next
        txtTotal_1.Text = FormatNumber(Total_1, 2)
        txtTotal_2.Text = FormatNumber(Total_2, 2)
        txtTotal_3.Text = FormatNumber(Total_3, 2)
        txtTotal_4.Text = FormatNumber(Total_4, 2)
        txtTotal_5.Text = FormatNumber(Total_5, 2)
        txtTotal_6.Text = FormatNumber(Total_6, 2)
        txtTotal_7.Text = FormatNumber(Total_7, 2)
        txtTotal_8.Text = FormatNumber(Total_8, 2)
        txtTotal_9.Text = FormatNumber(Total_9, 2)

        If cbxWithFinancialPlan.Checked = False Then
            If cbxDisplay.SelectedIndex = 0 Then
                GridColumn5.Caption = Format(dtpFrom.Value, "MMMM dd, yyyy")
                GridColumn8.Caption = Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
                GridColumn11.Caption = Format(dtpFrom.Value.AddYears(-2), "MMMM dd, yyyy")
            ElseIf cbxDisplay.SelectedIndex = 5 Then
                GridColumn5.Caption = "As of " & Format(dtpFrom.Value, "MMMM dd, yyyy")
                GridColumn8.Caption = "As of " & Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
                GridColumn11.Caption = "As of " & Format(dtpFrom.Value.AddYears(-2), "MMMM dd, yyyy")
            ElseIf cbxDisplay.SelectedIndex = 4 Or cbxDisplay.SelectedIndex = 1 Then
                GridColumn5.Caption = Format(dtpFrom.Value, "MMM dd - ") & Format(dtpTo.Value, "MMM dd, yyyy")
                GridColumn8.Caption = Format(dtpFrom.Value.AddYears(-1), "MMM dd - ") & Format(dtpTo.Value.AddYears(-1), "MMM dd, yyyy")
                GridColumn11.Caption = Format(dtpFrom.Value.AddYears(-2), "MMM dd - ") & Format(dtpTo.Value.AddYears(-2), "MMM dd, yyyy")
            ElseIf cbxDisplay.SelectedIndex = 3 Then
                GridColumn5.Caption = Format(dtpFrom.Value, "yyyy")
                GridColumn8.Caption = Format(dtpFrom.Value.AddYears(-1), "yyyy")
                GridColumn11.Caption = Format(dtpFrom.Value.AddYears(-2), "yyyy")
            ElseIf cbxDisplay.SelectedIndex = 2 Then
                GridColumn5.Caption = Format(dtpFrom.Value, "MMMM yyyy")
                GridColumn8.Caption = Format(dtpFrom.Value.AddYears(-1), "MMMM yyyy")
                GridColumn11.Caption = Format(dtpFrom.Value.AddYears(-2), "MMMM yyyy")
            End If
        Else
            If CompanyMode = 0 Then
                GridColumn5.Caption = Format(dtpFrom.Value, "MMMM dd, yyyy")
                GridColumn8.Caption = Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
                GridColumn11.Caption = Format(dtpFrom.Value.AddYears(-2), "MMMM dd, yyyy")
            Else
                GridColumn5.Caption = "Actual"
                GridColumn8.Caption = "Actual"
                GridColumn11.Caption = "Actual"
            End If
        End If

        If cbxAll.Checked Then
            lblYear1.Text = ""
            lblYear2.Text = ""
            lblYear3.Text = ""
        ElseIf cbxDisplay.SelectedIndex = 0 Then
            lblYear1.Text = Format(dtpFrom.Value, "MMMM dd, yyyy")
            lblYear2.Text = Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
            lblYear3.Text = Format(dtpFrom.Value.AddYears(-2), "MMMM dd, yyyy")
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            lblYear1.Text = "As of " & Format(dtpFrom.Value, "MMMM dd, yyyy")
            lblYear2.Text = "As of " & Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
            lblYear3.Text = "As of " & Format(dtpFrom.Value.AddYears(-2), "MMMM dd, yyyy")
        ElseIf cbxDisplay.SelectedIndex = 4 Or cbxDisplay.SelectedIndex = 1 Then
            lblYear1.Text = Format(dtpFrom.Value, "MMM dd - ") & Format(dtpTo.Value, "MMM dd, yyyy")
            lblYear2.Text = Format(dtpFrom.Value.AddYears(-1), "MMM dd - ") & Format(dtpTo.Value.AddYears(-1), "MMM dd, yyyy")
            lblYear3.Text = Format(dtpFrom.Value.AddYears(-2), "MMM dd - ") & Format(dtpTo.Value.AddYears(-2), "MMM dd, yyyy")
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            lblYear1.Text = Format(dtpFrom.Value, "yyyy")
            lblYear2.Text = Format(dtpFrom.Value.AddYears(-1), "yyyy")
            lblYear3.Text = Format(dtpFrom.Value.AddYears(-2), "yyyy")
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            lblYear1.Text = Format(dtpFrom.Value, "MMMM yyyy")
            lblYear2.Text = Format(dtpFrom.Value.AddYears(-1), "MMMM yyyy")
            lblYear3.Text = Format(dtpFrom.Value.AddYears(-2), "MMMM yyyy")
        End If

        Dim DT_ColumnSettings As DataTable = DataSource(String.Format("SELECT * FROM column_settings WHERE UserID = '{0}' AND FormID = '{1}' AND `status` = 'ACTIVE';", User_ID, Tag & If(cbxWithFinancialPlan.Checked, 100, "")))
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
        Else
            'GridView1.BestFitColumns()
            GridControl1.Tag = 0
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_Keydown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        'Save customize column in the table column_settings
        If e.Control And e.KeyCode = Keys.S Then
            If MsgBoxYes("Are you sure you want to save this Table Display") = MsgBoxResult.Yes Then
                Dim SQL As String
                If GridControl1.Tag = 1 Then
                    SQL = "UPDATE column_settings SET"
                Else
                    SQL = "INSERT INTO column_settings SET"
                End If
                SQL &= String.Format(" UserID = '{0}', ", User_ID)
                SQL &= String.Format(" FormID = '{0}', ", Tag & If(cbxWithFinancialPlan.Checked, 100, ""))
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
                SQL &= String.Format(" Column12W = '{0}' ", GridColumn12.Width)
                If GridControl1.Tag = 1 Then
                    SQL &= String.Format(" WHERE FormID = '{0}' AND `status` = 'ACTIVE';", Tag & If(cbxWithFinancialPlan.Checked, 100, ""))
                End If
                DataObject(SQL)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
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
        If CompanyMode = 0 Then
            Dim Report As New RptTrialBalance
            With Report
                If cbxDisplay.SelectedIndex = 5 Then
                    .lblAsOf.Text = "As of " & dtpFrom.Text
                ElseIf cbxDisplay.SelectedIndex = 3 Then
                    .lblAsOf.Text = "For the Year of " & Format(dtpFrom.Value, "yyyy")
                ElseIf cbxDisplay.SelectedIndex = 2 Then
                    .lblAsOf.Text = "For the Month of " & Format(dtpFrom.Value, "MMMM yyyy")
                ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 4 Then
                    .lblAsOf.Text = String.Format("For {0} to {1}", Format(dtpFrom.Value, "MMMM dd, yyyy"), Format(dtpTo.Value, "MMMM dd, yyyy"))
                ElseIf cbxDisplay.SelectedIndex = 0 Then
                    .lblAsOf.Text = "For " & Format(dtpFrom.Value, "MMMM dd, yyyy")
                End If
                .Name = String.Format("Trial Balance of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), .lblAsOf.Text)

                .lblFinancialH.Text = dtpFrom.Text
                .XrLabel4.Text = dtpFrom.Text
                .XrLabel5.Text = Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
                .XrLabel6.Text = Format(dtpFrom.Value.AddYears(-2), "MMMM dd, yyyy")

                If CompanyMode = 0 Then
                    .lblFinancialH2.Visible = False
                    .lblFinancialH.Visible = False
                    .lblFinancial.Visible = False
                    .lblFinancialT.Visible = False
                    .XrLabel1.Visible = False
                    .lblDifference.Visible = False
                    .lblDifference_T.Visible = False

                    .lblAccountH.SizeF = New Size(340 + 160, 35)
                    .lblAccount.SizeF = New Size(340 + 160, 20)
                    .lblTotalH.SizeF = New Size(400 + 160, 20)

                    .XrLabel8.LocationF = New Point(480 + 80, 40)
                    .XrLabel4.LocationF = New Point(480 + 80, 60)
                    .XrLabel5.LocationF = New Point(560 + 80, 60)
                    .XrLabel6.LocationF = New Point(640 + 80, 60)
                    .XrLabel6.Borders = DevExpress.XtraPrinting.BorderSide.All

                    .lblActual_1.LocationF = New Point(480 + 80, 0)
                    .lblActual_2.LocationF = New Point(560 + 80, 0)
                    .lblActual_3.LocationF = New Point(640 + 80, 0)
                    .lblActual_3.Borders = DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Right

                    .lblActual_1T.LocationF = New Point(480 + 80, 0)
                    .lblActual_2T.LocationF = New Point(560 + 80, 0)
                    .lblActual_3T.LocationF = New Point(640 + 80, 0)
                    .lblActual_3T.Borders = DevExpress.XtraPrinting.BorderSide.Left + DevExpress.XtraPrinting.BorderSide.Bottom + DevExpress.XtraPrinting.BorderSide.Right
                End If
                .DataSource = GridControl1.DataSource
                .lblCode.DataBindings.Add("Text", GridControl1.DataSource, "Account Code")
                .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Account Name")
                .lblFinancial.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Plan")
                .lblActual_1.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual")
                .lblActual_2.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_1")
                .lblActual_3.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_2")
                .lblDifference.DataBindings.Add("Text", GridControl1.DataSource, "Difference")
                .lblFinancialT.Text = txtTotal_1.Text
                .lblActual_1T.Text = txtTotal_2.Text
                .lblActual_2T.Text = txtTotal_3.Text
                .lblActual_3T.Text = txtTotal_4.Text
                .lblDifference_T.Text = txtTotal_5.Text
                Logs("Trial Balance", "Print", "[SENSITIVE] Print Trial Balance", "", "", "", "")
                .ShowPreview()
            End With
        Else
            If cbxCurrentOnly.Checked Then
                Dim Report As New RptTrialBalanceV3
                With Report
                    If cbxDisplay.SelectedIndex = 5 Then
                        .lblAsOf.Text = "As of " & dtpFrom.Text
                    ElseIf cbxDisplay.SelectedIndex = 3 Then
                        .lblAsOf.Text = "For the Year of " & Format(dtpFrom.Value, "yyyy")
                    ElseIf cbxDisplay.SelectedIndex = 2 Then
                        .lblAsOf.Text = "For the Month of " & Format(dtpFrom.Value, "MMMM yyyy")
                    ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 4 Then
                        .lblAsOf.Text = String.Format("For {0} to {1}", Format(dtpFrom.Value, "MMMM dd, yyyy"), Format(dtpTo.Value, "MMMM dd, yyyy"))
                    ElseIf cbxDisplay.SelectedIndex = 0 Then
                        .lblAsOf.Text = "For " & Format(dtpFrom.Value, "MMMM dd, yyyy")
                    End If
                    .Name = String.Format("Trial Balance of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), .lblAsOf.Text)

                    .lblFinancialH.Text = lblYear1.Text
                    .XrLabel4.Text = lblYear1.Text
                    .XrLabel5.Text = lblYear2.Text
                    .XrLabel6.Text = lblYear3.Text

                    .DataSource = GridControl1.DataSource
                    .lblCode.DataBindings.Add("Text", GridControl1.DataSource, "Account Code")
                    .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Account Name")
                    .lblFinancial.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Plan")
                    .lblActual_1.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual")
                    .lblActual_2.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_1")
                    .lblActual_3.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_2")

                    .lblFinancialT.Text = txtTotal_1.Text
                    .lblActual_1T.Text = txtTotal_2.Text
                    .lblActual_2T.Text = txtTotal_5.Text
                    .lblActual_3T.Text = txtTotal_8.Text
                    Logs("Trial Balance", "Print", "[SENSITIVE] Print Trial Balance", "", "", "", "")

                    .ShowPreview()
                End With
            ElseIf cbxWithFinancialPlan.Checked Then
                Dim Report As New RptTrialBalanceV2
                With Report
                    If cbxDisplay.SelectedIndex = 5 Then
                        .lblAsOf.Text = "As of " & dtpFrom.Text
                    ElseIf cbxDisplay.SelectedIndex = 3 Then
                        .lblAsOf.Text = "For the Year of " & Format(dtpFrom.Value, "yyyy")
                    ElseIf cbxDisplay.SelectedIndex = 2 Then
                        .lblAsOf.Text = "For the Month of " & Format(dtpFrom.Value, "MMMM yyyy")
                    ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 4 Then
                        .lblAsOf.Text = String.Format("For {0} to {1}", Format(dtpFrom.Value, "MMMM dd, yyyy"), Format(dtpTo.Value, "MMMM dd, yyyy"))
                    ElseIf cbxDisplay.SelectedIndex = 0 Then
                        .lblAsOf.Text = "For " & Format(dtpFrom.Value, "MMMM dd, yyyy")
                    End If
                    .Name = String.Format("Trial Balance of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), .lblAsOf.Text)

                    .lblYear1.Text = lblYear1.Text
                    .lblYear2.Text = lblYear2.Text
                    .lblYear3.Text = lblYear3.Text

                    .DataSource = GridControl1.DataSource
                    .lblCode.DataBindings.Add("Text", GridControl1.DataSource, "Account Code")
                    .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Account Name")
                    .lblFP1.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Plan")
                    .lblActual1.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual")
                    .lblVariance1.DataBindings.Add("Text", GridControl1.DataSource, "Difference")
                    .lblFP2.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Plan_1")
                    .lblActual2.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_1")
                    .lblVariance2.DataBindings.Add("Text", GridControl1.DataSource, "Difference_1")
                    .lblFP3.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Plan_2")
                    .lblActual3.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_2")
                    .lblVariance3.DataBindings.Add("Text", GridControl1.DataSource, "Difference_2")

                    .lblFP1T.Text = txtTotal_1.Text
                    .lblActual1T.Text = txtTotal_2.Text
                    .lblVariance1T.Text = txtTotal_3.Text
                    .lblFP2T.Text = txtTotal_4.Text
                    .lblActual2T.Text = txtTotal_5.Text
                    .lblVariance2T.Text = txtTotal_6.Text
                    .lblFP3T.Text = txtTotal_7.Text
                    .lblActual3T.Text = txtTotal_8.Text
                    .lblVariance3T.Text = txtTotal_9.Text
                    Logs("Trial Balance", "Print", "[SENSITIVE] Print Trial Balance", "", "", "", "")

                    .ShowPreview()
                End With
            Else
                Dim Report As New RptTrialBalanceWithoutFP
                With Report
                    If cbxDisplay.SelectedIndex = 5 Then
                        .lblAsOf.Text = "As of " & dtpFrom.Text
                    ElseIf cbxDisplay.SelectedIndex = 3 Then
                        .lblAsOf.Text = "For the Year of " & Format(dtpFrom.Value, "yyyy")
                    ElseIf cbxDisplay.SelectedIndex = 2 Then
                        .lblAsOf.Text = "For the Month of " & Format(dtpFrom.Value, "MMMM yyyy")
                    ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 4 Then
                        .lblAsOf.Text = String.Format("For {0} to {1}", Format(dtpFrom.Value, "MMMM dd, yyyy"), Format(dtpTo.Value, "MMMM dd, yyyy"))
                    ElseIf cbxDisplay.SelectedIndex = 0 Then
                        .lblAsOf.Text = "For " & Format(dtpFrom.Value, "MMMM dd, yyyy")
                    End If
                    .Name = String.Format("Trial Balance of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), .lblAsOf.Text)

                    .lblCaption1.Text = GridColumn5.Caption
                    .lblCaption2.Text = GridColumn8.Caption
                    .lblCaption3.Text = GridColumn11.Caption
                    .DataSource = GridControl1.DataSource
                    .lblCode.DataBindings.Add("Text", GridControl1.DataSource, "Account Code")
                    .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Account Name")
                    .lblActual1.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual")
                    .lblActual2.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_1")
                    .lblActual3.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_2")

                    .lblActual1T.Text = txtTotal_2.Text
                    .lblActual2T.Text = txtTotal_5.Text
                    .lblActual3T.Text = txtTotal_8.Text
                    Logs("Trial Balance", "Print", "[SENSITIVE] Print Trial Balance", "", "", "", "")

                    .ShowPreview()
                End With
            End If
        End If
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

    Private Sub BtnPrintCustomized_Click(sender As Object, e As EventArgs) Handles btnPrintCustomized.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("TRIAL BALANCE", GridControl1)
        Logs("Trial Balance", "Print", "[SENSITIVE] Print Trial Balance List", "", "", "", "")
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

        cbxBank.ValueMember = "ID"
        cbxBank.DisplayMember = "Bank"
        cbxBank.DataSource = DataSource(String.Format("SELECT ID, CONCAT('Bank ', `Code`, ' [', IF(AccountNumber = '',CheckingAccount,AccountNumber), '] ', (SELECT B.short_name FROM bank_setup B WHERE B.ID = BankID)) AS 'Bank', (SELECT B.bank FROM bank_setup B WHERE B.ID = BankID) AS 'Bank_1', Branch FROM branch_bank WHERE `status` = 'ACTIVE' AND Branch_ID = '{0}' AND IF({1} > 0,ID = {1},TRUE) AND Book = '{2}' ORDER BY `Code`;", Branch_ID, DefaultBankID, cbxBook.SelectedValue))
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

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
        Else
            cbxDisplay.SelectedIndex = 0
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Account Code").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Transaction As New FrmGeneralLedgerAccountDetails
        With Transaction
            .vPrint = vPrint
            .lblTitle.Text = GridView1.GetFocusedRowCellValue("Account Name")
            .AccountCode = GridView1.GetFocusedRowCellValue("Account Code")
            .DepartmentCode = ""
            .From_TrialBalance = True
            If .ShowDialog = DialogResult.OK Then
                .Dispose()
                btnCancel.DialogResult = DialogResult.OK
                btnCancel.PerformClick()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub CbxWithFinancialPlan_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWithFinancialPlan.CheckedChanged
        'If FirstLoad Then
        '    Exit Sub
        'End If
        'If (cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "") And cbxAllB.Checked = False Then
        '    MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
        '    cbxBranch.DroppedDown = True
        'End If

        'If cbxWithFinancialPlan.Checked Then
        '    cbxCurrentOnly.Visible = True
        'Else
        '    cbxCurrentOnly.Visible = False
        'End If

        'LoadData()

        If CompanyMode = 0 Then
            If GridView1.RowCount > 19 Then
                GridColumn3.Width = 396 + 225 - 17

                lblTotal.Width = 482 + 225 - 17
                lblYear1.Location = New Point(486 + 225 - 17, 106)
                lblYear2.Location = New Point(710 + 150 - 17, 106)
                lblYear3.Location = New Point(935 + 76 - 17, 106)
                txtTotal_2.Location = New Point(486 + 225 - 17, 6)
                txtTotal_5.Location = New Point(710 + 150 - 17, 6)
                txtTotal_8.Location = New Point(935 + 76 - 17, 6)
            Else
                GridColumn3.Width = 396 + 225

                lblTotal.Width = 482 + 225
                lblYear1.Location = New Point(486 + 225, 106)
                lblYear2.Location = New Point(710 + 150, 106)
                lblYear3.Location = New Point(935 + 76, 106)
                txtTotal_2.Location = New Point(486 + 225, 6)
                txtTotal_5.Location = New Point(710 + 150, 6)
                txtTotal_8.Location = New Point(935 + 76, 6)
            End If
            lblYear1.Visible = False
            lblYear2.Visible = False
            lblYear3.Visible = False

            lblYear1.Size = New Point(150, 23)
            lblYear2.Size = New Point(152, 23)
            lblYear3.Size = New Point(150, 23)
            txtTotal_2.Size = New Point(75 + 75, 23)
            txtTotal_5.Size = New Point(75 + 77, 23)
            txtTotal_8.Size = New Point(75 + 75, 23)
            GridColumn5.Width = 150
            GridColumn8.Width = 150
            GridColumn11.Width = 150
            GridColumn4.Visible = False
            GridColumn6.Visible = False
            GridColumn7.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn12.Visible = False

            txtTotal_1.Visible = False
            txtTotal_3.Visible = False
            txtTotal_4.Visible = False
            txtTotal_6.Visible = False
            txtTotal_7.Visible = False
            txtTotal_9.Visible = False
        Else
            If GridView1.RowCount > 19 Then
                GridColumn3.Width = 396 - 17

                lblTotal.Width = 482 - 17
                lblYear1.Location = New Point(486 - 17, 106)
                lblYear2.Location = New Point(710 - 17, 106)
                lblYear3.Location = New Point(935 - 17, 106)
                txtTotal_1.Location = New Point(486 - 17, 6)
                txtTotal_2.Location = New Point(561 - 17, 6)
                txtTotal_3.Location = New Point(636 - 17, 6)
                txtTotal_4.Location = New Point(711 - 17, 6)
                txtTotal_5.Location = New Point(786 - 17, 6)
                txtTotal_6.Location = New Point(861 - 17, 6)
                txtTotal_7.Location = New Point(936 - 17, 6)
                txtTotal_8.Location = New Point(1011 - 17, 6)
                txtTotal_9.Location = New Point(1086 - 17, 6)
            Else
                GridColumn3.Width = 396

                lblTotal.Width = 482
                lblYear1.Location = New Point(486, 106)
                lblYear2.Location = New Point(710, 106)
                lblYear3.Location = New Point(935, 106)
                txtTotal_1.Location = New Point(486, 6)
                txtTotal_2.Location = New Point(561, 6)
                txtTotal_3.Location = New Point(636, 6)
                txtTotal_4.Location = New Point(711, 6)
                txtTotal_5.Location = New Point(786, 6)
                txtTotal_6.Location = New Point(861, 6)
                txtTotal_7.Location = New Point(936, 6)
                txtTotal_8.Location = New Point(1011, 6)
                txtTotal_9.Location = New Point(1086, 6)
            End If
            lblYear1.Visible = True
            lblYear2.Visible = True
            lblYear3.Visible = True

            lblYear1.Size = New Point(225, 23)
            lblYear2.Size = New Point(226, 23)
            lblYear3.Size = New Point(225, 23)
            txtTotal_2.Size = New Point(76, 23)
            txtTotal_5.Size = New Point(76, 23)
            txtTotal_8.Size = New Point(76, 23)
            GridColumn5.Width = 75
            GridColumn8.Width = 75
            GridColumn11.Width = 75
            GridColumn4.Visible = True
            GridColumn6.Visible = True
            GridColumn7.Visible = True
            GridColumn9.Visible = True
            GridColumn10.Visible = True
            GridColumn12.Visible = True

            txtTotal_1.Visible = True
            txtTotal_3.Visible = True
            txtTotal_4.Visible = True
            txtTotal_6.Visible = True
            txtTotal_7.Visible = True
            txtTotal_9.Visible = True

            GridColumn2.VisibleIndex = 1
            GridColumn3.VisibleIndex = 2
            GridColumn4.VisibleIndex = 3
            GridColumn5.VisibleIndex = 4
            GridColumn6.VisibleIndex = 5
            GridColumn7.VisibleIndex = 6
            GridColumn8.VisibleIndex = 7
            GridColumn9.VisibleIndex = 8
            GridColumn10.VisibleIndex = 9
            GridColumn11.VisibleIndex = 10
            GridColumn12.VisibleIndex = 11
        End If

        If cbxWithFinancialPlan.Checked = False Then
            GridColumn4.Visible = False
            GridColumn6.Visible = False
            GridColumn7.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn12.Visible = False
            lblYear1.Visible = False
            lblYear2.Visible = False
            lblYear3.Visible = False

            GridColumn5.Width = 75 * 3
            GridColumn8.Width = 75 * 3
            GridColumn11.Width = 75 * 3

            txtTotal_1.Visible = False
            txtTotal_3.Visible = False
            txtTotal_4.Visible = False
            txtTotal_6.Visible = False
            txtTotal_7.Visible = False
            txtTotal_9.Visible = False

            txtTotal_2.Size = New Point(75 * 3, 19)
            txtTotal_5.Size = New Point(75 * 3, 19)
            txtTotal_8.Size = New Point(75 * 3, 19)

            If GridView1.RowCount > 19 Then
                txtTotal_2.Location = New Point(486 - 17, 6)
                txtTotal_5.Location = New Point(711 - 17, 6)
                txtTotal_8.Location = New Point(936 - 17, 6)
            Else
                txtTotal_2.Location = New Point(486, 6)
                txtTotal_5.Location = New Point(711, 6)
                txtTotal_8.Location = New Point(936, 6)
            End If
        End If

        If cbxCurrentOnly.Checked Then
            GridColumn7.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn12.Visible = False
            'lblYear2.Visible = False
            'lblYear3.Visible = False

            GridColumn8.Width = 75 * 3
            GridColumn11.Width = 75 * 3

            txtTotal_4.Visible = False
            txtTotal_6.Visible = False
            txtTotal_7.Visible = False
            txtTotal_9.Visible = False

            txtTotal_5.Size = New Point(75 * 3, 19)
            txtTotal_8.Size = New Point(75 * 3, 19)

            If GridView1.RowCount > 19 Then
                txtTotal_5.Location = New Point(711 - 17, 6)
                txtTotal_8.Location = New Point(936 - 17, 6)
            Else
                txtTotal_5.Location = New Point(711, 6)
                txtTotal_8.Location = New Point(936, 6)
            End If
        End If
    End Sub

    Private Sub CbxCurrentOnly_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCurrentOnly.CheckedChanged

        If CompanyMode = 0 Then
            If GridView1.RowCount > 19 Then
                GridColumn3.Width = 396 + 225 - 17

                lblTotal.Width = 482 + 225 - 17
                lblYear1.Location = New Point(486 + 225 - 17, 106)
                lblYear2.Location = New Point(710 + 150 - 17, 106)
                lblYear3.Location = New Point(935 + 76 - 17, 106)
                txtTotal_2.Location = New Point(486 + 225 - 17, 6)
                txtTotal_5.Location = New Point(710 + 150 - 17, 6)
                txtTotal_8.Location = New Point(935 + 76 - 17, 6)
            Else
                GridColumn3.Width = 396 + 225

                lblTotal.Width = 482 + 225
                lblYear1.Location = New Point(486 + 225, 106)
                lblYear2.Location = New Point(710 + 150, 106)
                lblYear3.Location = New Point(935 + 76, 106)
                txtTotal_2.Location = New Point(486 + 225, 6)
                txtTotal_5.Location = New Point(710 + 150, 6)
                txtTotal_8.Location = New Point(935 + 76, 6)
            End If
            lblYear1.Visible = False
            lblYear2.Visible = False
            lblYear3.Visible = False

            lblYear1.Size = New Point(150, 23)
            lblYear2.Size = New Point(152, 23)
            lblYear3.Size = New Point(150, 23)
            txtTotal_2.Size = New Point(75 + 75, 23)
            txtTotal_5.Size = New Point(75 + 77, 23)
            txtTotal_8.Size = New Point(75 + 75, 23)
            GridColumn5.Width = 150
            GridColumn8.Width = 150
            GridColumn11.Width = 150
            GridColumn4.Visible = False
            GridColumn6.Visible = False
            GridColumn7.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn12.Visible = False

            txtTotal_1.Visible = False
            txtTotal_3.Visible = False
            txtTotal_4.Visible = False
            txtTotal_6.Visible = False
            txtTotal_7.Visible = False
            txtTotal_9.Visible = False
        Else
            If GridView1.RowCount > 19 Then
                GridColumn3.Width = 396 - 17

                lblTotal.Width = 482 - 17
                lblYear1.Location = New Point(486 - 17, 106)
                lblYear2.Location = New Point(710 - 17, 106)
                lblYear3.Location = New Point(935 - 17, 106)
                txtTotal_1.Location = New Point(486 - 17, 6)
                txtTotal_2.Location = New Point(561 - 17, 6)
                txtTotal_3.Location = New Point(636 - 17, 6)
                txtTotal_4.Location = New Point(711 - 17, 6)
                txtTotal_5.Location = New Point(786 - 17, 6)
                txtTotal_6.Location = New Point(861 - 17, 6)
                txtTotal_7.Location = New Point(936 - 17, 6)
                txtTotal_8.Location = New Point(1011 - 17, 6)
                txtTotal_9.Location = New Point(1086 - 17, 6)
            Else
                GridColumn3.Width = 396

                lblTotal.Width = 482
                lblYear1.Location = New Point(486, 106)
                lblYear2.Location = New Point(710, 106)
                lblYear3.Location = New Point(935, 106)
                txtTotal_1.Location = New Point(486, 6)
                txtTotal_2.Location = New Point(561, 6)
                txtTotal_3.Location = New Point(636, 6)
                txtTotal_4.Location = New Point(711, 6)
                txtTotal_5.Location = New Point(786, 6)
                txtTotal_6.Location = New Point(861, 6)
                txtTotal_7.Location = New Point(936, 6)
                txtTotal_8.Location = New Point(1011, 6)
                txtTotal_9.Location = New Point(1086, 6)
            End If
            lblYear1.Visible = True
            lblYear2.Visible = True
            lblYear3.Visible = True

            lblYear1.Size = New Point(225, 23)
            lblYear2.Size = New Point(226, 23)
            lblYear3.Size = New Point(225, 23)
            txtTotal_2.Size = New Point(76, 23)
            txtTotal_5.Size = New Point(76, 23)
            txtTotal_8.Size = New Point(76, 23)
            GridColumn5.Width = 75
            GridColumn8.Width = 75
            GridColumn11.Width = 75
            GridColumn4.Visible = True
            GridColumn6.Visible = True
            GridColumn7.Visible = True
            GridColumn9.Visible = True
            GridColumn10.Visible = True
            GridColumn12.Visible = True

            txtTotal_1.Visible = True
            txtTotal_3.Visible = True
            txtTotal_4.Visible = True
            txtTotal_6.Visible = True
            txtTotal_7.Visible = True
            txtTotal_9.Visible = True

            GridColumn2.VisibleIndex = 1
            GridColumn3.VisibleIndex = 2
            GridColumn4.VisibleIndex = 3
            GridColumn5.VisibleIndex = 4
            GridColumn6.VisibleIndex = 5
            GridColumn7.VisibleIndex = 6
            GridColumn8.VisibleIndex = 7
            GridColumn9.VisibleIndex = 8
            GridColumn10.VisibleIndex = 9
            GridColumn11.VisibleIndex = 10
            GridColumn12.VisibleIndex = 11
        End If

        If cbxWithFinancialPlan.Checked = False Then
            GridColumn4.Visible = False
            GridColumn6.Visible = False
            GridColumn7.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn12.Visible = False
            lblYear1.Visible = False
            lblYear2.Visible = False
            lblYear3.Visible = False

            GridColumn5.Width = 75 * 3
            GridColumn8.Width = 75 * 3
            GridColumn11.Width = 75 * 3

            txtTotal_1.Visible = False
            txtTotal_3.Visible = False
            txtTotal_4.Visible = False
            txtTotal_6.Visible = False
            txtTotal_7.Visible = False
            txtTotal_9.Visible = False

            txtTotal_2.Size = New Point(75 * 3, 19)
            txtTotal_5.Size = New Point(75 * 3, 19)
            txtTotal_8.Size = New Point(75 * 3, 19)

            If GridView1.RowCount > 19 Then
                txtTotal_2.Location = New Point(486 - 17, 6)
                txtTotal_5.Location = New Point(711 - 17, 6)
                txtTotal_8.Location = New Point(936 - 17, 6)
            Else
                txtTotal_2.Location = New Point(486, 6)
                txtTotal_5.Location = New Point(711, 6)
                txtTotal_8.Location = New Point(936, 6)
            End If
        End If

        If cbxCurrentOnly.Checked Then
            GridColumn7.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn12.Visible = False
            'lblYear2.Visible = False
            'lblYear3.Visible = False

            GridColumn8.Width = 75 * 3
            GridColumn11.Width = 75 * 3

            txtTotal_4.Visible = False
            txtTotal_6.Visible = False
            txtTotal_7.Visible = False
            txtTotal_9.Visible = False

            txtTotal_5.Size = New Point(75 * 3, 19)
            txtTotal_8.Size = New Point(75 * 3, 19)

            If GridView1.RowCount > 19 Then
                txtTotal_5.Location = New Point(711 - 17, 6)
                txtTotal_8.Location = New Point(936 - 17, 6)
            Else
                txtTotal_5.Location = New Point(711, 6)
                txtTotal_8.Location = New Point(936, 6)
            End If
        End If
    End Sub
End Class