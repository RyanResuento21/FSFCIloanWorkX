Imports DevExpress.XtraReports.UI
Public Class FrmIncomeStatement

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT_Type As DataTable
    Dim DT_Classification As DataTable
    Dim DT_Group As DataTable
    Dim DT_Account As DataTable
    Dim DT_BalanceSheet As DataTable
    Dim DT_Main As DataTable
    Private Sub FrmIncomeStatement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 5

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
            .ValueMember = "BusinessCode"
            .DisplayMember = "BusinessCenter"
            .SelectedIndex = -1
        End With

        DT_Type = DataSource("SELECT ID, UPPER(`Type`) AS 'Type' FROM account_type WHERE `status` = 'ACTIVE' AND ID > 3 ORDER BY `Code`;")
        DT_Classification = DataSource("SELECT ID, Type_ID, UPPER(Classification) AS 'Classification' FROM account_classification WHERE `status` = 'ACTIVE' ORDER BY Type_ID, `Code`;")
        DT_Group = DataSource("SELECT Classification_ID, Group_ID AS 'ID', (SELECT `Group` FROM account_group WHERE ID = Group_ID) AS 'Group', (SELECT `Code` FROM account_classification WHERE ID = Classification_ID) AS 'Classification Code', (SELECT IF(`Code` = 0,`Code` + 9,`Code`) FROM account_group WHERE ID = Group_ID) AS 'Group Code' FROM account_chart WHERE `status` = 'ACTIVE' GROUP BY Classification_ID, Group_ID ORDER BY `Classification Code`, `Group Code`; ")
        DT_Main = DataSource("SELECT ID, `Title`, Type_ID, Classification_ID, Group_ID FROM account_chart WHERE Main_ID = 0 AND `status` = 'ACTIVE';")

        DT_BalanceSheet = DataSource("SELECT 0 AS 'ID', '' AS 'Account Name', 0.0 AS 'AsOf_Plan', 0.0 AS 'AsOf_Actual', 0.0 AS 'AsOf_Actual_1', 0.0 AS 'Difference', 0 AS 'Account Code', 0.0 AS 'Jan', 0.0 AS 'Feb', 0.0 AS 'Mar', 0.0 AS 'Apr', 0.0 AS 'May', 0.0 AS 'Jun', 0.0 AS 'Jul', 0.0 AS 'Aug', 0.0 AS 'Sep', 0.0 AS 'Oct', 0.0 AS 'Nov', 0.0 AS 'Dec' LIMIT 0")

        With cbxBook
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            FirstLoad = False
            .DataSource = DataSource("SELECT 1 AS 'ID', 'Bank 1' AS 'Bank' UNION ALL SELECT 2 AS 'ID', 'Bank 2' AS 'Bank';")
        End With

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

            GetLabelFontSettings({LabelX1, LabelX40, lblFrom, LabelX41, LabelX4})

            GetLabelWithBackgroundFontSettings({LabelX2, LabelX3})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank, cbxAll, cbxWithFinancialPlan, cbxSubAccount, cbxToDate})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})
        Catch ex As Exception
            TriggerBugReport("Income Statement - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Income Statement", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        If CompanyMode = 0 Then
            cbxSubAccount.Checked = False
            cbxSubAccount.Visible = False
        Else
            cbxSubAccount.Visible = True
        End If

        DT_BalanceSheet.Rows.Clear()
        Dim SQL As String
        Dim DateCondition_1 As String = ""
        Dim DateCondition_2 As String = ""
        If cbxDisplay.SelectedIndex = 0 Then
            DateCondition_1 = String.Format("DATE(ORDate) = DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_2 = String.Format("DATE(ORDate) = DATE('{0}')", Format(dtpFrom.Value.AddYears(-1), "yyyy-MM-dd"))
        ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
            DateCondition_1 = String.Format("DATE(ORDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))
            DateCondition_2 = String.Format("DATE(ORDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value.AddYears(-1), "yyyy-MM-dd"), Format(dtpTo.Value.AddYears(-1), "yyyy-MM-dd"))
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            DateCondition_1 = String.Format("DATE(ORDate) <= DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
            DateCondition_2 = String.Format("DATE(ORDate) <= DATE('{0}')", Format(dtpFrom.Value.AddYears(-1), "yyyy-MM-dd"))
        End If
        SQL = " SELECT "
        SQL &= "    A.ID,"
        SQL &= "    A.Code AS 'Account Code', A.`Title` AS 'Account Name', A.Type_ID, A.Classification_ID, A.Group_ID, A.Main_ID, "
        If cbxToDate.Checked Then
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Jan',", Format(dtpFrom.Value, "yyyy-01-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Feb',", Format(dtpFrom.Value, "yyyy-02-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Mar',", Format(dtpFrom.Value, "yyyy-03-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Apr',", Format(dtpFrom.Value, "yyyy-04-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'May',", Format(dtpFrom.Value, "yyyy-05-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Jun',", Format(dtpFrom.Value, "yyyy-06-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Jul',", Format(dtpFrom.Value, "yyyy-07-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Aug',", Format(dtpFrom.Value, "yyyy-08-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Sep',", Format(dtpFrom.Value, "yyyy-09-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Oct',", Format(dtpFrom.Value, "yyyy-10-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Nov',", Format(dtpFrom.Value, "yyyy-11-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'Dec',", Format(dtpFrom.Value, "yyyy-12-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'AsOf_Actual',", Format(dtpFrom.Value, "yyyy-01-01"))
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND YEAR(ORDate) = YEAR('{0}') THEN ABS(Amount) END),0) AS 'AsOf_Actual_1', `Status`", Format(dtpFrom.Value.AddYears(-1), "yyyy-01-01"))
            SQL &= " FROM account_chart A"
            If cbxSubAccount.Checked Then
                SQL &= String.Format(" LEFT JOIN (SELECT ID, EntryType, accounting_entry.AccountCode, Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND YEAR(ORDate) <= YEAR('{2}') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{4}' = '0',TRUE,BusinessCode = '{4}')) A2 ON A2.AccountCode = A.`Code`", cbxBranch.SelectedValue, cbxAllB.Checked, Format(dtpFrom.Value, "yyyy-MM-dd"), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID)
                SQL &= "    WHERE A.`status` IN ('ACTIVE','DEACTIVATE') AND A.Main_ID > 0 AND A.Type_ID > 3 GROUP BY A.ID HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY A.Code ;"
            Else
                SQL &= String.Format(" LEFT JOIN (SELECT ID, EntryType, MotherCode AS 'AccountCode', Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND YEAR(ORDate) <= YEAR('{2}') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{4}' = '0',TRUE,BusinessCode = '{4}')) A2 ON A2.AccountCode = A.`Code`", cbxBranch.SelectedValue, cbxAllB.Checked, Format(dtpFrom.Value, "yyyy-MM-dd"), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID)
                SQL &= "    WHERE A.`status` IN ('ACTIVE','DEACTIVATE') AND A.Main_ID = 0 AND AdjunctAccount = 0 AND A.Type_ID > 3 GROUP BY A.ID HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY A.Code ;"
            End If
            DT_Account = DataSource(SQL)

            Dim Difference As String
            Dim Total_TJan As Double
            Dim Total_TFeb As Double
            Dim Total_TMar As Double
            Dim Total_TApr As Double
            Dim Total_TMay As Double
            Dim Total_TJun As Double
            Dim Total_TJul As Double
            Dim Total_TAug As Double
            Dim Total_TSep As Double
            Dim Total_TOct As Double
            Dim Total_TNov As Double
            Dim Total_TDec As Double
            Dim Total_T1 As Double
            Dim Total_T2 As Double
            Dim Total_TDifference As Double
            For A As Integer = 0 To DT_Type.Rows.Count - 1
                'ADD
                DT_BalanceSheet.Rows.Add(1, DT_Type(A)("Type"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                For B As Integer = 0 To DT_Classification.Rows.Count - 1
                    Dim Total_Jan As Double
                    Dim Total_Feb As Double
                    Dim Total_Mar As Double
                    Dim Total_Apr As Double
                    Dim Total_May As Double
                    Dim Total_Jun As Double
                    Dim Total_Jul As Double
                    Dim Total_Aug As Double
                    Dim Total_Sep As Double
                    Dim Total_Oct As Double
                    Dim Total_Nov As Double
                    Dim Total_Dec As Double
                    Dim Total_1 As Double
                    Dim Total_2 As Double
                    Dim Total_Difference As Double
                    If DT_Type(A)("ID") = DT_Classification(B)("Type_ID") Then
                        'ADD
                        DT_BalanceSheet.Rows.Add(2, "   " & DT_Classification(B)("Classification"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                        For C As Integer = 0 To DT_Group.Rows.Count - 1
                            If DT_Classification(B)("ID") = DT_Group(C)("Classification_ID") Then
                                'ADD
                                DT_BalanceSheet.Rows.Add(3, "       " & DT_Group(C)("Group"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                                If cbxSubAccount.Checked Then
                                    ' ADD MOTHER ACCOUNTS *******************************************************************************
                                    For E As Integer = 0 To DT_Main.Rows.Count - 1
                                        Dim Total_JanM As Double
                                        Dim Total_FebM As Double
                                        Dim Total_MarM As Double
                                        Dim Total_AprM As Double
                                        Dim Total_MayM As Double
                                        Dim Total_JunM As Double
                                        Dim Total_JulM As Double
                                        Dim Total_AugM As Double
                                        Dim Total_SepM As Double
                                        Dim Total_OctM As Double
                                        Dim Total_NovM As Double
                                        Dim Total_DecM As Double
                                        Dim Total_M1 As Double
                                        Dim Total_M2 As Double
                                        Dim Total_MDifference As Double
                                        If DT_Main(E)("Group_ID") = DT_Group(C)("ID") And DT_Main(E)("Type_ID") = DT_Type(A)("ID") And DT_Main(E)("Classification_ID") = DT_Classification(B)("ID") Then
                                            DT_BalanceSheet.Rows.Add(3, "           " & DT_Main(E)("Title"), 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                                            For D As Integer = 0 To DT_Account.Rows.Count - 1
                                                If DT_Account(D)("Main_ID") = DT_Main(E)("ID") Then
                                                    'ADD
                                                    Difference = CDbl(DT_Account(D)("AsOf_Actual")) - CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                    DT_BalanceSheet.Rows.Add(4, "               " & DT_Account(D)("Account Name"), 0, CDec(DT_Account(D)("AsOf_Actual")), CDec(DT_Account(D)("AsOf_Actual_1")), CDec(Difference), DT_Account(D)("Account Code"), CDec(DT_Account(D)("Jan")), CDec(DT_Account(D)("Feb")), CDec(DT_Account(D)("Mar")), CDec(DT_Account(D)("Apr")), CDec(DT_Account(D)("May")), CDec(DT_Account(D)("Jun")), CDec(DT_Account(D)("Jul")), CDec(DT_Account(D)("Aug")), CDec(DT_Account(D)("Sep")), CDec(DT_Account(D)("Oct")), CDec(DT_Account(D)("Nov")), CDec(DT_Account(D)("Dec")))

                                                    Total_M1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                                    Total_M2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                    Total_MDifference += Difference
                                                    Total_JanM += CDbl(DT_Account(D)("Jan"))
                                                    Total_FebM += CDbl(DT_Account(D)("Feb"))
                                                    Total_MarM += CDbl(DT_Account(D)("Mar"))
                                                    Total_AprM += CDbl(DT_Account(D)("Apr"))
                                                    Total_MayM += CDbl(DT_Account(D)("May"))
                                                    Total_JunM += CDbl(DT_Account(D)("Jun"))
                                                    Total_JulM += CDbl(DT_Account(D)("Jul"))
                                                    Total_AugM += CDbl(DT_Account(D)("Aug"))
                                                    Total_SepM += CDbl(DT_Account(D)("Sep"))
                                                    Total_OctM += CDbl(DT_Account(D)("Oct"))
                                                    Total_NovM += CDbl(DT_Account(D)("Nov"))
                                                    Total_DecM += CDbl(DT_Account(D)("Dec"))

                                                    Total_1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                                    Total_2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                    Total_Difference += Difference
                                                    Total_Jan += CDbl(DT_Account(D)("Jan"))
                                                    Total_Feb += CDbl(DT_Account(D)("Feb"))
                                                    Total_Mar += CDbl(DT_Account(D)("Mar"))
                                                    Total_Apr += CDbl(DT_Account(D)("Apr"))
                                                    Total_May += CDbl(DT_Account(D)("May"))
                                                    Total_Jun += CDbl(DT_Account(D)("Jun"))
                                                    Total_Jul += CDbl(DT_Account(D)("Jul"))
                                                    Total_Aug += CDbl(DT_Account(D)("Aug"))
                                                    Total_Sep += CDbl(DT_Account(D)("Sep"))
                                                    Total_Oct += CDbl(DT_Account(D)("Oct"))
                                                    Total_Nov += CDbl(DT_Account(D)("Nov"))
                                                    Total_Dec += CDbl(DT_Account(D)("Dec"))

                                                    If DT_Type(A)("ID") = 5 Then
                                                        Total_T1 -= CDbl(DT_Account(D)("AsOf_Actual"))
                                                        Total_T2 -= CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                        Total_TDifference -= Difference
                                                        Total_TJan -= CDbl(DT_Account(D)("Jan"))
                                                        Total_TFeb -= CDbl(DT_Account(D)("Feb"))
                                                        Total_TMar -= CDbl(DT_Account(D)("Mar"))
                                                        Total_TApr -= CDbl(DT_Account(D)("Apr"))
                                                        Total_TMay -= CDbl(DT_Account(D)("May"))
                                                        Total_TJun -= CDbl(DT_Account(D)("Jun"))
                                                        Total_TJul -= CDbl(DT_Account(D)("Jul"))
                                                        Total_TAug -= CDbl(DT_Account(D)("Aug"))
                                                        Total_TSep -= CDbl(DT_Account(D)("Sep"))
                                                        Total_TOct -= CDbl(DT_Account(D)("Oct"))
                                                        Total_TNov -= CDbl(DT_Account(D)("Nov"))
                                                        Total_TDec -= CDbl(DT_Account(D)("Dec"))
                                                    Else
                                                        Total_T1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                                        Total_T2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                        Total_TDifference += Difference
                                                        Total_TJan += CDbl(DT_Account(D)("Jan"))
                                                        Total_TFeb += CDbl(DT_Account(D)("Feb"))
                                                        Total_TMar += CDbl(DT_Account(D)("Mar"))
                                                        Total_TApr += CDbl(DT_Account(D)("Apr"))
                                                        Total_TMay += CDbl(DT_Account(D)("May"))
                                                        Total_TJun += CDbl(DT_Account(D)("Jun"))
                                                        Total_TJul += CDbl(DT_Account(D)("Jul"))
                                                        Total_TAug += CDbl(DT_Account(D)("Aug"))
                                                        Total_TSep += CDbl(DT_Account(D)("Sep"))
                                                        Total_TOct += CDbl(DT_Account(D)("Oct"))
                                                        Total_TNov += CDbl(DT_Account(D)("Nov"))
                                                        Total_TDec += CDbl(DT_Account(D)("Dec"))
                                                    End If
                                                End If
                                                If D = DT_Account.Rows.Count - 1 Then
                                                    DT_BalanceSheet.Rows.Add(3, "           Total " & DT_Main(E)("Title"), 0, CDec(Total_M1), CDec(Total_M2), CDec(Total_MDifference), 0, CDec(Total_JanM), CDec(Total_FebM), CDec(Total_MarM), CDec(Total_AprM), CDec(Total_MayM), CDec(Total_JunM), CDec(Total_JulM), CDec(Total_AugM), CDec(Total_SepM), CDec(Total_OctM), CDec(Total_NovM), CDec(Total_DecM))
                                                End If
                                            Next
                                        End If
                                    Next
                                    ' ADD MOTHER ACCOUNTS *******************************************************************************
                                Else
                                    For D As Integer = 0 To DT_Account.Rows.Count - 1
                                        If DT_Account(D)("Group_ID") = DT_Group(C)("ID") And DT_Account(D)("Type_ID") = DT_Type(A)("ID") And DT_Account(D)("Classification_ID") = DT_Classification(B)("ID") Then
                                            'ADD
                                            Difference = CDbl(DT_Account(D)("AsOf_Actual")) - CDbl(DT_Account(D)("AsOf_Actual_1"))
                                            DT_BalanceSheet.Rows.Add(4, "               " & DT_Account(D)("Account Name"), 0, CDec(DT_Account(D)("AsOf_Actual")), CDec(DT_Account(D)("AsOf_Actual_1")), CDec(Difference), DT_Account(D)("Account Code"), CDec(DT_Account(D)("Jan")), CDec(DT_Account(D)("Feb")), CDec(DT_Account(D)("Mar")), CDec(DT_Account(D)("Apr")), CDec(DT_Account(D)("May")), CDec(DT_Account(D)("Jun")), CDec(DT_Account(D)("Jul")), CDec(DT_Account(D)("Aug")), CDec(DT_Account(D)("Sep")), CDec(DT_Account(D)("Oct")), CDec(DT_Account(D)("Nov")), CDec(DT_Account(D)("Dec")))

                                            Total_1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                            Total_2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                            Total_Difference += Difference
                                            Total_Jan += CDbl(DT_Account(D)("Jan"))
                                            Total_Feb += CDbl(DT_Account(D)("Feb"))
                                            Total_Mar += CDbl(DT_Account(D)("Mar"))
                                            Total_Apr += CDbl(DT_Account(D)("Apr"))
                                            Total_May += CDbl(DT_Account(D)("May"))
                                            Total_Jun += CDbl(DT_Account(D)("Jun"))
                                            Total_Jul += CDbl(DT_Account(D)("Jul"))
                                            Total_Aug += CDbl(DT_Account(D)("Aug"))
                                            Total_Sep += CDbl(DT_Account(D)("Sep"))
                                            Total_Oct += CDbl(DT_Account(D)("Oct"))
                                            Total_Nov += CDbl(DT_Account(D)("Nov"))
                                            Total_Dec += CDbl(DT_Account(D)("Dec"))

                                            If DT_Type(A)("ID") = 5 Then
                                                Total_T1 -= CDbl(DT_Account(D)("AsOf_Actual"))
                                                Total_T2 -= CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                Total_TDifference -= Difference
                                                Total_TJan -= CDbl(DT_Account(D)("Jan"))
                                                Total_TFeb -= CDbl(DT_Account(D)("Feb"))
                                                Total_TMar -= CDbl(DT_Account(D)("Mar"))
                                                Total_TApr -= CDbl(DT_Account(D)("Apr"))
                                                Total_TMay -= CDbl(DT_Account(D)("May"))
                                                Total_TJun -= CDbl(DT_Account(D)("Jun"))
                                                Total_TJul -= CDbl(DT_Account(D)("Jul"))
                                                Total_TAug -= CDbl(DT_Account(D)("Aug"))
                                                Total_TSep -= CDbl(DT_Account(D)("Sep"))
                                                Total_TOct -= CDbl(DT_Account(D)("Oct"))
                                                Total_TNov -= CDbl(DT_Account(D)("Nov"))
                                                Total_TDec -= CDbl(DT_Account(D)("Dec"))
                                            Else
                                                Total_T1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                                Total_T2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                Total_TDifference += Difference
                                                Total_TJan += CDbl(DT_Account(D)("Jan"))
                                                Total_TFeb += CDbl(DT_Account(D)("Feb"))
                                                Total_TMar += CDbl(DT_Account(D)("Mar"))
                                                Total_TApr += CDbl(DT_Account(D)("Apr"))
                                                Total_TMay += CDbl(DT_Account(D)("May"))
                                                Total_TJun += CDbl(DT_Account(D)("Jun"))
                                                Total_TJul += CDbl(DT_Account(D)("Jul"))
                                                Total_TAug += CDbl(DT_Account(D)("Aug"))
                                                Total_TSep += CDbl(DT_Account(D)("Sep"))
                                                Total_TOct += CDbl(DT_Account(D)("Oct"))
                                                Total_TNov += CDbl(DT_Account(D)("Nov"))
                                                Total_TDec += CDbl(DT_Account(D)("Dec"))
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                            If C = DT_Group.Rows.Count - 1 Then
                                DT_BalanceSheet.Rows.Add(1, "   " & "TOTAL " & DT_Classification(B)("Classification"), 0, CDec(Total_1), CDec(Total_2), CDec(Total_Difference), 0, CDec(Total_Jan), CDec(Total_Feb), CDec(Total_Mar), CDec(Total_Apr), CDec(Total_May), CDec(Total_Jun), CDec(Total_Jul), CDec(Total_Aug), CDec(Total_Sep), CDec(Total_Oct), CDec(Total_Nov), CDec(Total_Dec))
                            End If
                        Next
                    End If
                Next
                If A = DT_Type.Rows.Count - 1 Then
                    With DT_BalanceSheet
                        .Rows.Add(2, "       " & "NET INCOME BEFORE TAX", 0, CDec(Total_T1), CDec(Total_T2), CDec(Total_TDifference), 0, CDec(Total_TJan), CDec(Total_TFeb), CDec(Total_TMar), CDec(Total_TApr), CDec(Total_TMay), CDec(Total_TJun), CDec(Total_TJul), CDec(Total_TAug), CDec(Total_TSep), CDec(Total_TOct), CDec(Total_TNov), CDec(Total_TDec))
                        .Rows.Add(0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                        .Rows.Add(2, "       " & "Less: Income Tax Expense", 0, CDec(Total_T1) * 0, CDec(Total_T2) * 0, CDec(Total_TDifference) * 0, 0, CDec(Total_TJan) * 0, CDec(Total_TFeb) * 0, CDec(Total_TMar) * 0, CDec(Total_TApr) * 0, CDec(Total_TMay) * 0, CDec(Total_TJun) * 0, CDec(Total_TJul) * 0, CDec(Total_TAug) * 0, CDec(Total_TSep) * 0, CDec(Total_TOct) * 0, CDec(Total_TNov) * 0, CDec(Total_TDec) * 0)
                        .Rows.Add(0, "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
                        .Rows.Add(2, "       " & "NET INCOME FOR THE PERIOD", 0, CDec(Total_T1) * 1, CDec(Total_T2) * 1, CDec(Total_TDifference) * 1, 0, CDec(Total_TJan) * 1, CDec(Total_TFeb) * 1, CDec(Total_TMar) * 1, CDec(Total_TApr) * 1, CDec(Total_TMay) * 1, CDec(Total_TJun) * 1, CDec(Total_TJul) * 1, CDec(Total_TAug) * 1, CDec(Total_TSep) * 1, CDec(Total_TOct) * 1, CDec(Total_TNov) * 1, CDec(Total_TDec) * 1)
                    End With
                End If
            Next

            GridControl1.DataSource = DT_BalanceSheet
            If GridView1.RowCount > 23 Then
                GridColumn3.Width = 400 - 17
                LabelX3.Location = New Point(766 - 25, 42)
            Else
                GridColumn3.Width = 400
                LabelX3.Location = New Point(766 - 7, 42)
            End If

            GridColumn5.Caption = "Total To Date"
            GridColumn6.Caption = "Total To Date " & Format(dtpFrom.Value.AddYears(-1), "yyyy")

            GridColumn2.Visible = True
            GridColumn4.Visible = True
            GridColumn8.Visible = True
            GridColumn9.Visible = True
            GridColumn10.Visible = True
            GridColumn11.Visible = True
            GridColumn12.Visible = True
            GridColumn13.Visible = True
            GridColumn14.Visible = True
            GridColumn15.Visible = True
            GridColumn16.Visible = True
            GridColumn17.Visible = True
            GridColumn18.Visible = False

            GridColumn2.VisibleIndex = 1
            GridColumn4.VisibleIndex = 2
            GridColumn8.VisibleIndex = 3
            GridColumn9.VisibleIndex = 4
            GridColumn10.VisibleIndex = 5
            GridColumn11.VisibleIndex = 6
            GridColumn12.VisibleIndex = 7
            GridColumn13.VisibleIndex = 8
            GridColumn14.VisibleIndex = 9
            GridColumn15.VisibleIndex = 10
            GridColumn16.VisibleIndex = 11
            GridColumn17.VisibleIndex = 12
            GridColumn5.VisibleIndex = 13
            GridColumn6.VisibleIndex = 14
            GridColumn7.VisibleIndex = 15
            LabelX3.Visible = False
            LabelX2.Visible = False
        Else
            If cbxSubAccount.Checked Then
                SQL &= String.Format("    (SELECT IFNULL(SUM(F.M{0}),0) FROM financial_plan F WHERE F.AccountCode = A.`Code` AND F.`Year` = YEAR('{1}') AND IF('{3}' = 1,TRUE,BranchID = '{2}') AND F.`status` = 'ACTIVE' AND F.`FP_Status` = 'APPROVED' AND F.Half = IF(MONTH('{1}') BETWEEN 1 AND 6,1,2)) AS 'AsOf_Plan',", If(Format(dtpFrom.Value, "MM") > 6, Format(dtpFrom.Value.AddMonths(-6), "MM"), Format(dtpFrom.Value, "MM")), Format(dtpFrom.Value, "yyyy-MM-dd"), cbxBranch.SelectedValue, cbxAllB.Checked)
                SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual',", If(cbxAll.Checked, True, DateCondition_1))
                SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual_1', `Status`", If(cbxAll.Checked, True, DateCondition_2))
                SQL &= " FROM account_chart A"
                SQL &= String.Format(" LEFT JOIN (SELECT ID, EntryType, accounting_entry.AccountCode, Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{4}' = '0',TRUE,BusinessCode = '{4}') AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}'))) A2 ON A2.AccountCode = A.`Code`", cbxBranch.SelectedValue, cbxAllB.Checked, If(cbxAll.Checked, True, DateCondition_1), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
                SQL &= "    WHERE A.`status` IN ('ACTIVE','DEACTIVATE') AND A.Main_ID > 0 AND A.Type_ID > 3 GROUP BY A.ID HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY A.Code ;"
            Else
                If CompanyMode = 0 Then
                    SQL &= "    0 AS 'AsOf_Plan',"
                Else
                    SQL &= String.Format("    (SELECT IFNULL(SUM(F.M{0}),0) FROM financial_plan F WHERE F.MotherCode = A.Code AND F.`Year` = YEAR('{1}') AND IF('{3}' = 1,TRUE,BranchID = '{2}') AND F.`status` = 'ACTIVE' AND F.`FP_Status` = 'APPROVED' AND F.Half = IF(MONTH('{1}') BETWEEN 1 AND 6,1,2)) AS 'AsOf_Plan',", If(Format(dtpFrom.Value, "MM") > 6, Format(dtpFrom.Value.AddMonths(-6), "MM"), Format(dtpFrom.Value, "MM")), Format(dtpFrom.Value, "yyyy-MM-dd"), cbxBranch.SelectedValue, cbxAllB.Checked)
                End If
                SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual',", If(cbxAll.Checked, True, DateCondition_1))
                SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual_1', `Status`", If(cbxAll.Checked, True, DateCondition_2))
                SQL &= " FROM account_chart A"
                SQL &= String.Format(" LEFT JOIN (SELECT ID, EntryType, MotherCode AS 'AccountCode', Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{4}' = '0',TRUE,BusinessCode = '{4}') AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}'))) A2 ON A2.AccountCode = A.`Code`", cbxBranch.SelectedValue, cbxAllB.Checked, If(cbxAll.Checked, True, DateCondition_1), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
                SQL &= "    WHERE A.`status` IN ('ACTIVE','DEACTIVATE') AND A.Main_ID = 0 AND AdjunctAccount = 0 AND A.Type_ID > 3 GROUP BY A.ID HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY A.Code ;"
            End If
            DT_Account = DataSource(SQL)

            Dim Difference As String
            Dim Total_TF As Double
            Dim Total_T1 As Double
            Dim Total_T2 As Double
            Dim Total_TDifference As Double
            For A As Integer = 0 To DT_Type.Rows.Count - 1
                Dim Total_CF As Double
                Dim Total_C1 As Double
                Dim Total_C2 As Double
                Dim Total_CDifference As Double
                'ADD
                DT_BalanceSheet.Rows.Add(1, DT_Type(A)("Type"), 0, 0, 0, 0, 0)
                For B As Integer = 0 To DT_Classification.Rows.Count - 1
                    Dim Total_F As Double
                    Dim Total_1 As Double
                    Dim Total_2 As Double
                    Dim Total_Difference As Double
                    If DT_Type(A)("ID") = DT_Classification(B)("Type_ID") Then
                        'ADD
                        DT_BalanceSheet.Rows.Add(2, "   " & DT_Classification(B)("Classification"), 0, 0, 0, 0, 0)
                        For C As Integer = 0 To DT_Group.Rows.Count - 1
                            If DT_Classification(B)("ID") = DT_Group(C)("Classification_ID") Then
                                'ADD
                                DT_BalanceSheet.Rows.Add(3, "       " & DT_Group(C)("Group"), 0, 0, 0, 0, 0)

                                If cbxSubAccount.Checked Then
                                    ' ADD MOTHER ACCOUNTS *******************************************************************************
                                    For E As Integer = 0 To DT_Main.Rows.Count - 1
                                        Dim Total_MF As Double
                                        Dim Total_M1 As Double
                                        Dim Total_M2 As Double
                                        Dim Total_MDifference As Double
                                        If DT_Main(E)("Group_ID") = DT_Group(C)("ID") And DT_Main(E)("Type_ID") = DT_Type(A)("ID") And DT_Main(E)("Classification_ID") = DT_Classification(B)("ID") Then
                                            DT_BalanceSheet.Rows.Add(3, "       " & DT_Main(E)("Title"), 0, 0, 0, 0, 0)
                                            For D As Integer = 0 To DT_Account.Rows.Count - 1
                                                If DT_Account(D)("Main_ID") = DT_Main(E)("ID") Then
                                                    'ADD
                                                    Difference = CDbl(DT_Account(D)("AsOf_Actual")) - CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                    DT_BalanceSheet.Rows.Add(4, "           " & DT_Account(D)("Account Name"), CDec(DT_Account(D)("AsOf_Plan")), CDec(DT_Account(D)("AsOf_Actual")), CDec(DT_Account(D)("AsOf_Actual_1")), CDec(Difference), DT_Account(D)("Account Code"))

                                                    Total_CF += CDbl(DT_Account(D)("AsOf_Plan"))
                                                    Total_C1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                                    Total_C2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                    Total_CDifference += Difference

                                                    Total_F += CDbl(DT_Account(D)("AsOf_Plan"))
                                                    Total_1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                                    Total_2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                    Total_Difference += Difference

                                                    Total_MF += CDbl(DT_Account(D)("AsOf_Plan"))
                                                    Total_M1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                                    Total_M2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                    Total_MDifference += Difference

                                                    If DT_Type(A)("ID") = 5 Then
                                                        Total_TF -= CDbl(DT_Account(D)("AsOf_Plan"))
                                                        Total_T1 -= CDbl(DT_Account(D)("AsOf_Actual"))
                                                        Total_T2 -= CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                        Total_TDifference -= Difference
                                                    Else
                                                        Total_TF += CDbl(DT_Account(D)("AsOf_Plan"))
                                                        Total_T1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                                        Total_T2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                        Total_TDifference += Difference
                                                    End If
                                                End If
                                                If D = DT_Account.Rows.Count - 1 Then
                                                    DT_BalanceSheet.Rows.Add(3, "       Total " & DT_Main(E)("Title"), CDec(Total_MF), CDec(Total_M1), CDec(Total_M2), CDec(Total_MDifference), 0)
                                                End If
                                            Next
                                        End If
                                    Next
                                    ' ADD MOTHER ACCOUNTS *******************************************************************************
                                Else
                                    For D As Integer = 0 To DT_Account.Rows.Count - 1
                                        If DT_Account(D)("Group_ID") = DT_Group(C)("ID") And DT_Account(D)("Type_ID") = DT_Type(A)("ID") And DT_Account(D)("Classification_ID") = DT_Classification(B)("ID") Then
                                            'ADD
                                            Difference = CDbl(DT_Account(D)("AsOf_Actual")) - CDbl(DT_Account(D)("AsOf_Actual_1"))
                                            DT_BalanceSheet.Rows.Add(4, "           " & DT_Account(D)("Account Name"), CDec(DT_Account(D)("AsOf_Plan")), CDec(DT_Account(D)("AsOf_Actual")), CDec(DT_Account(D)("AsOf_Actual_1")), CDec(Difference), DT_Account(D)("Account Code"))

                                            Total_CF += CDbl(DT_Account(D)("AsOf_Plan"))
                                            Total_C1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                            Total_C2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                            Total_CDifference += Difference

                                            Total_F += CDbl(DT_Account(D)("AsOf_Plan"))
                                            Total_1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                            Total_2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                            Total_Difference += Difference

                                            If DT_Type(A)("ID") = 5 Then
                                                Total_TF -= CDbl(DT_Account(D)("AsOf_Plan"))
                                                Total_T1 -= CDbl(DT_Account(D)("AsOf_Actual"))
                                                Total_T2 -= CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                Total_TDifference -= Difference
                                            Else
                                                Total_TF += CDbl(DT_Account(D)("AsOf_Plan"))
                                                Total_T1 += CDbl(DT_Account(D)("AsOf_Actual"))
                                                Total_T2 += CDbl(DT_Account(D)("AsOf_Actual_1"))
                                                Total_TDifference += Difference
                                            End If
                                        End If
                                    Next
                                End If
                            End If
                            If C = DT_Group.Rows.Count - 1 Then
                                DT_BalanceSheet.Rows.Add(1, "   " & "TOTAL " & DT_Classification(B)("Classification"), CDec(Total_F), CDec(Total_1), CDec(Total_2), CDec(Total_Difference), 0)
                            End If
                        Next
                    End If
                Next
                If A = DT_Type.Rows.Count - 1 Then
                    With DT_BalanceSheet
                        .Rows.Add(2, "       " & "NET INCOME BEFORE TAX", CDec(Total_TF), CDec(Total_T1), CDec(Total_T2), CDec(Total_TDifference), 0)
                        .Rows.Add(0, "", 0, 0, 0, 0, 0)
                        .Rows.Add(2, "       " & "Less: Income Tax Expense", CDec(Total_TF) * 0, CDec(Total_T1) * 0, CDec(Total_T2) * 0, CDec(Total_TDifference) * 0, 0)
                        .Rows.Add(0, "", 0, 0, 0, 0, 0)
                        .Rows.Add(2, "       " & "NET INCOME FOR THE PERIOD", CDec(Total_TF) * 1, CDec(Total_T1) * 1, CDec(Total_T2) * 1, CDec(Total_TDifference) * 1, 0)
                    End With
                End If
            Next

            GridControl1.DataSource = DT_BalanceSheet
            If CompanyMode = 0 Then
                If GridView1.RowCount > 23 Then
                    GridColumn3.Width = 609 + 135 - 17
                    LabelX3.Location = New Point(766 - 25, 106)
                Else
                    GridColumn3.Width = 609 + 135
                    LabelX3.Location = New Point(766 - 7, 106)
                End If
                LabelX2.Visible = False
                GridColumn2.Visible = False
                GridColumn18.Visible = False
            Else
                If GridView1.RowCount > 23 Then
                    GridColumn3.Width = 609 - 17
                    LabelX3.Location = New Point(766 - 25, 106)
                    LabelX2.Location = New Point(629 - 22, 106)
                Else
                    GridColumn3.Width = 609
                    LabelX3.Location = New Point(766 - 7, 106)
                    LabelX2.Location = New Point(629, 106)
                End If
                LabelX2.Visible = True
                GridColumn2.Visible = True
                GridColumn18.Visible = True
            End If

            If cbxAll.Checked Then
                GridColumn18.Caption = ""
                GridColumn5.Caption = ""
                GridColumn6.Caption = ""
            ElseIf cbxDisplay.SelectedIndex = 0 Then
                GridColumn18.Caption = dtpFrom.Text
                GridColumn5.Caption = dtpFrom.Text
                GridColumn6.Caption = Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
            ElseIf cbxDisplay.SelectedIndex = 5 Then
                GridColumn18.Caption = dtpFrom.Text
                GridColumn5.Caption = dtpFrom.Text
                GridColumn6.Caption = Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
            ElseIf cbxDisplay.SelectedIndex = 4 Or cbxDisplay.SelectedIndex = 1 Then
                GridColumn18.Caption = Format(dtpFrom.Value, "MM-dd - ") & Format(dtpTo.Value, "MM dd-yyyy")
                GridColumn5.Caption = Format(dtpFrom.Value.AddYears(-1), "MM-dd - ") & Format(dtpTo.Value.AddYears(-1), "MM-dd-yyyy")
                GridColumn6.Caption = Format(dtpFrom.Value.AddYears(-2), "MM-dd - ") & Format(dtpTo.Value.AddYears(-2), "MM-dd-yyyy")
            ElseIf cbxDisplay.SelectedIndex = 3 Then
                GridColumn18.Caption = Format(dtpFrom.Value, "yyyy")
                GridColumn5.Caption = Format(dtpFrom.Value.AddYears(-1), "yyyy")
                GridColumn6.Caption = Format(dtpFrom.Value.AddYears(-2), "yyyy")
            ElseIf cbxDisplay.SelectedIndex = 2 Then
                GridColumn18.Caption = Format(dtpFrom.Value, "MMMM yyyy")
                GridColumn5.Caption = Format(dtpFrom.Value.AddYears(-1), "MMMM yyyy")
                GridColumn6.Caption = Format(dtpFrom.Value.AddYears(-2), "MMMM yyyy")
            End If

            GridColumn2.Visible = False
            GridColumn4.Visible = False
            GridColumn8.Visible = False
            GridColumn9.Visible = False
            GridColumn10.Visible = False
            GridColumn11.Visible = False
            GridColumn12.Visible = False
            GridColumn13.Visible = False
            GridColumn14.Visible = False
            GridColumn15.Visible = False
            GridColumn16.Visible = False
            GridColumn17.Visible = False
            LabelX3.Visible = True
        End If

        Dim DT_ColumnSettings As DataTable = DataSource(String.Format("SELECT * FROM column_settings WHERE UserID = '{0}' AND FormID = '{1}' AND `status` = 'ACTIVE';", User_ID, Tag & If(cbxToDate.Checked, 100, "")))
        If cbxToDate.Checked Then
            If DT_ColumnSettings.Rows.Count > 0 Then
                GridControl1.Tag = 1
                GridColumn1.VisibleIndex = DT_ColumnSettings(0)("Column1V")
                GridColumn2.VisibleIndex = DT_ColumnSettings(0)("Column2V")
                GridColumn4.VisibleIndex = DT_ColumnSettings(0)("Column3V")
                GridColumn8.VisibleIndex = DT_ColumnSettings(0)("Column4V")
                GridColumn9.VisibleIndex = DT_ColumnSettings(0)("Column5V")
                GridColumn10.VisibleIndex = DT_ColumnSettings(0)("Column6V")
                GridColumn11.VisibleIndex = DT_ColumnSettings(0)("Column7V")
                GridColumn12.VisibleIndex = DT_ColumnSettings(0)("Column8V")
                GridColumn13.VisibleIndex = DT_ColumnSettings(0)("Column9V")
                GridColumn14.VisibleIndex = DT_ColumnSettings(0)("Column10V")
                GridColumn15.VisibleIndex = DT_ColumnSettings(0)("Column11V")
                GridColumn16.VisibleIndex = DT_ColumnSettings(0)("Column12V")
                GridColumn17.VisibleIndex = DT_ColumnSettings(0)("Column13V")
                GridColumn5.VisibleIndex = DT_ColumnSettings(0)("Column14V")
                GridColumn6.VisibleIndex = DT_ColumnSettings(0)("Column15V")
                GridColumn7.VisibleIndex = DT_ColumnSettings(0)("Column16V")

                GridColumn1.Width = DT_ColumnSettings(0)("Column1W")
                GridColumn2.Width = DT_ColumnSettings(0)("Column2W")
                GridColumn4.Width = DT_ColumnSettings(0)("Column3W")
                GridColumn8.Width = DT_ColumnSettings(0)("Column4W")
                GridColumn9.Width = DT_ColumnSettings(0)("Column5W")
                GridColumn10.Width = DT_ColumnSettings(0)("Column6W")
                GridColumn11.Width = DT_ColumnSettings(0)("Column7W")
                GridColumn12.Width = DT_ColumnSettings(0)("Column8W")
                GridColumn13.Width = DT_ColumnSettings(0)("Column9W")
                GridColumn14.Width = DT_ColumnSettings(0)("Column10W")
                GridColumn15.Width = DT_ColumnSettings(0)("Column11W")
                GridColumn16.Width = DT_ColumnSettings(0)("Column12W")
                GridColumn17.Width = DT_ColumnSettings(0)("Column13W")
                GridColumn5.Width = DT_ColumnSettings(0)("Column14W")
                GridColumn6.Width = DT_ColumnSettings(0)("Column15W")
                GridColumn7.Width = DT_ColumnSettings(0)("Column16W")
            Else
                'GridView1.BestFitColumns()
                GridControl1.Tag = 0
            End If
        Else
            If DT_ColumnSettings.Rows.Count > 0 Then
                GridControl1.Tag = 1
                GridColumn1.VisibleIndex = DT_ColumnSettings(0)("Column1V")
                GridColumn3.VisibleIndex = DT_ColumnSettings(0)("Column2V")
                GridColumn18.VisibleIndex = DT_ColumnSettings(0)("Column3V")
                GridColumn5.VisibleIndex = DT_ColumnSettings(0)("Column4V")
                GridColumn6.VisibleIndex = DT_ColumnSettings(0)("Column5V")
                GridColumn7.VisibleIndex = DT_ColumnSettings(0)("Column6V")

                GridColumn1.Width = DT_ColumnSettings(0)("Column1W")
                GridColumn3.Width = DT_ColumnSettings(0)("Column2W")
                GridColumn18.Width = DT_ColumnSettings(0)("Column3W")
                GridColumn5.Width = DT_ColumnSettings(0)("Column4W")
                GridColumn6.Width = DT_ColumnSettings(0)("Column5W")
                GridColumn7.Width = DT_ColumnSettings(0)("Column6W")
            Else
                'GridView1.BestFitColumns()
                GridControl1.Tag = 0
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_Keydown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        'Save customize column in the table column_settings
        If e.Control And e.KeyCode = Keys.S Then
            If MsgBoxYes("Are you sure you want to save this Table Display") = MsgBoxResult.Yes Then
                Dim SQL As String
                If cbxToDate.Checked Then
                    If GridControl1.Tag = 1 Then
                        SQL = "UPDATE column_settings SET"
                    Else
                        SQL = "INSERT INTO column_settings SET"
                    End If
                    SQL &= String.Format(" UserID = '{0}', ", User_ID)
                    SQL &= String.Format(" FormID = '{0}', ", Tag & If(cbxToDate.Checked, 100, ""))
                    SQL &= String.Format(" Column1V = '{0}', ", GridColumn1.VisibleIndex)
                    SQL &= String.Format(" Column2V = '{0}', ", GridColumn2.VisibleIndex)
                    SQL &= String.Format(" Column3V = '{0}', ", GridColumn4.VisibleIndex)
                    SQL &= String.Format(" Column4V = '{0}', ", GridColumn8.VisibleIndex)
                    SQL &= String.Format(" Column5V = '{0}', ", GridColumn9.VisibleIndex)
                    SQL &= String.Format(" Column6V = '{0}', ", GridColumn10.VisibleIndex)
                    SQL &= String.Format(" Column7V = '{0}', ", GridColumn11.VisibleIndex)
                    SQL &= String.Format(" Column8V = '{0}', ", GridColumn12.VisibleIndex)
                    SQL &= String.Format(" Column9V = '{0}', ", GridColumn13.VisibleIndex)
                    SQL &= String.Format(" Column10V = '{0}', ", GridColumn14.VisibleIndex)
                    SQL &= String.Format(" Column11V = '{0}', ", GridColumn15.VisibleIndex)
                    SQL &= String.Format(" Column12V = '{0}', ", GridColumn16.VisibleIndex)
                    SQL &= String.Format(" Column13V = '{0}', ", GridColumn17.VisibleIndex)
                    SQL &= String.Format(" Column14V = '{0}', ", GridColumn5.VisibleIndex)
                    SQL &= String.Format(" Column15V = '{0}', ", GridColumn6.VisibleIndex)
                    SQL &= String.Format(" Column16V = '{0}', ", GridColumn7.VisibleIndex)
                    SQL &= String.Format(" Column1W = '{0}', ", GridColumn1.Width)
                    SQL &= String.Format(" Column2W = '{0}', ", GridColumn2.Width)
                    SQL &= String.Format(" Column3W = '{0}', ", GridColumn4.Width)
                    SQL &= String.Format(" Column4W = '{0}', ", GridColumn8.Width)
                    SQL &= String.Format(" Column5W = '{0}', ", GridColumn9.Width)
                    SQL &= String.Format(" Column6W = '{0}', ", GridColumn10.Width)
                    SQL &= String.Format(" Column7W = '{0}', ", GridColumn11.Width)
                    SQL &= String.Format(" Column8W = '{0}', ", GridColumn12.Width)
                    SQL &= String.Format(" Column9W = '{0}', ", GridColumn13.Width)
                    SQL &= String.Format(" Column10W = '{0}', ", GridColumn14.Width)
                    SQL &= String.Format(" Column11W = '{0}', ", GridColumn15.Width)
                    SQL &= String.Format(" Column12W = '{0}', ", GridColumn16.Width)
                    SQL &= String.Format(" Column13W = '{0}', ", GridColumn17.Width)
                    SQL &= String.Format(" Column14W = '{0}', ", GridColumn5.Width)
                    SQL &= String.Format(" Column15W = '{0}', ", GridColumn6.Width)
                    SQL &= String.Format(" Column16W = '{0}' ", GridColumn7.Width)
                    If GridControl1.Tag = 1 Then
                        SQL &= String.Format(" WHERE FormID = '{0}' AND `status` = 'ACTIVE';", Tag & If(cbxToDate.Checked, 100, ""))
                    End If
                    DataObject(SQL)
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                Else
                    If GridControl1.Tag = 1 Then
                        SQL = "UPDATE column_settings SET"
                    Else
                        SQL = "INSERT INTO column_settings SET"
                    End If
                    SQL &= String.Format(" UserID = '{0}', ", User_ID)
                    SQL &= String.Format(" FormID = '{0}', ", Tag)
                    SQL &= String.Format(" Column1V = '{0}', ", GridColumn1.VisibleIndex)
                    SQL &= String.Format(" Column2V = '{0}', ", GridColumn3.VisibleIndex)
                    SQL &= String.Format(" Column3V = '{0}', ", GridColumn18.VisibleIndex)
                    SQL &= String.Format(" Column4V = '{0}', ", GridColumn5.VisibleIndex)
                    SQL &= String.Format(" Column5V = '{0}', ", GridColumn6.VisibleIndex)
                    SQL &= String.Format(" Column6V = '{0}', ", GridColumn7.VisibleIndex)
                    SQL &= String.Format(" Column7V = '{0}', ", -1)
                    SQL &= String.Format(" Column8V = '{0}', ", -1)
                    SQL &= String.Format(" Column9V = '{0}', ", -1)
                    SQL &= String.Format(" Column10V = '{0}', ", -1)
                    SQL &= String.Format(" Column11V = '{0}', ", -1)
                    SQL &= String.Format(" Column12V = '{0}', ", -1)
                    SQL &= String.Format(" Column13V = '{0}', ", -1)
                    SQL &= String.Format(" Column14V = '{0}', ", -1)
                    SQL &= String.Format(" Column15V = '{0}', ", -1)
                    SQL &= String.Format(" Column16V = '{0}', ", -1)
                    SQL &= String.Format(" Column1W = '{0}', ", GridColumn1.Width)
                    SQL &= String.Format(" Column2W = '{0}', ", GridColumn18.Width)
                    SQL &= String.Format(" Column3W = '{0}', ", GridColumn2.Width)
                    SQL &= String.Format(" Column4W = '{0}', ", GridColumn5.Width)
                    SQL &= String.Format(" Column5W = '{0}', ", GridColumn6.Width)
                    SQL &= String.Format(" Column6W = '{0}', ", GridColumn7.Width)
                    SQL &= String.Format(" Column7W = '{0}', ", 0)
                    SQL &= String.Format(" Column8W = '{0}', ", 0)
                    SQL &= String.Format(" Column9W = '{0}', ", 0)
                    SQL &= String.Format(" Column10W = '{0}', ", 0)
                    SQL &= String.Format(" Column11W = '{0}', ", 0)
                    SQL &= String.Format(" Column12W = '{0}', ", 0)
                    SQL &= String.Format(" Column13W = '{0}', ", 0)
                    SQL &= String.Format(" Column14W = '{0}', ", 0)
                    SQL &= String.Format(" Column15W = '{0}', ", 0)
                    SQL &= String.Format(" Column16W = '{0}' ", 0)
                    If GridControl1.Tag = 1 Then
                        SQL &= String.Format(" WHERE FormID = '{0}' AND `status` = 'ACTIVE';", Tag)
                    End If
                    DataObject(SQL)
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("ID"))
                If ForBold < "4" Then
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
        Dim DateFilter As String = ""
        If cbxDisplay.SelectedIndex = 0 Then
            DateFilter = String.Format("For {0}", dtpFrom.Text)
        ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
            DateFilter = String.Format("For {0} - {1}", dtpFrom.Text, dtpTo.Text)
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            DateFilter = String.Format("As of {0}", dtpFrom.Text)
        End If
        If cbxToDate.Checked Then
            Dim Report As New RptIncomeStatement
            With Report
                .Name = String.Format("Income Statement of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), DateFilter)
                .lblAsOf.Text = DateFilter
                .lblTitle.Text = "Income Statement"

                .XrLabel4.Text = "Total To Date"
                .XrLabel5.Text = "Total To Date " & Format(dtpFrom.Value.AddYears(-1), "yyyy")
                .XrLabel1.Text = "Jan " & Format(dtpFrom.Value, "yyyy")
                .XrLabel2.Text = "Feb " & Format(dtpFrom.Value, "yyyy")
                .XrLabel3.Text = "Mar " & Format(dtpFrom.Value, "yyyy")
                .XrLabel7.Text = "Apr " & Format(dtpFrom.Value, "yyyy")
                .XrLabel9.Text = "May " & Format(dtpFrom.Value, "yyyy")
                .XrLabel10.Text = "Jun " & Format(dtpFrom.Value, "yyyy")
                .XrLabel11.Text = "Jul " & Format(dtpFrom.Value, "yyyy")
                .XrLabel12.Text = "Aug " & Format(dtpFrom.Value, "yyyy")
                .XrLabel13.Text = "Sep " & Format(dtpFrom.Value, "yyyy")
                .XrLabel14.Text = "Oct " & Format(dtpFrom.Value, "yyyy")
                .XrLabel15.Text = "Nov " & Format(dtpFrom.Value, "yyyy")
                .XrLabel16.Text = "Dec " & Format(dtpFrom.Value, "yyyy")

                .DataSource = GridControl1.DataSource
                .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Account Name")
                .lblJan.DataBindings.Add("Text", GridControl1.DataSource, "Jan")
                .lblFeb.DataBindings.Add("Text", GridControl1.DataSource, "Feb")
                .lblMar.DataBindings.Add("Text", GridControl1.DataSource, "Mar")
                .lblApr.DataBindings.Add("Text", GridControl1.DataSource, "Apr")
                .lblMay.DataBindings.Add("Text", GridControl1.DataSource, "May")
                .lblJun.DataBindings.Add("Text", GridControl1.DataSource, "Jun")
                .lblJul.DataBindings.Add("Text", GridControl1.DataSource, "Jul")
                .lblAug.DataBindings.Add("Text", GridControl1.DataSource, "Aug")
                .lblSep.DataBindings.Add("Text", GridControl1.DataSource, "Sep")
                .lblOct.DataBindings.Add("Text", GridControl1.DataSource, "Oct")
                .lblNov.DataBindings.Add("Text", GridControl1.DataSource, "Nov")
                .lblDec.DataBindings.Add("Text", GridControl1.DataSource, "Dec")
                .lblTotal.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual")
                .lblTotalPrev.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_1")
                .lblDifference.DataBindings.Add("Text", GridControl1.DataSource, "Difference")
                Logs("Income Statement", "Print", "[SENSITIVE] Print Income Statement", "", "", "", "")

                .ShowPreview()
            End With
        Else
            Dim Report As New RptBalanceSheet
            With Report
                .Name = String.Format("Income Statement of {0} As of {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), DateFilter)
                .lblTitle.Text = "Income Statement"
                .lblAsOf.Text = DateFilter

                If cbxAll.Checked Then
                    .lblFinancialH.Text = ""
                    .XrLabel4.Text = ""
                    .XrLabel5.Text = ""
                ElseIf cbxDisplay.SelectedIndex = 0 Then
                    .lblFinancialH.Text = dtpFrom.Text
                    .XrLabel4.Text = dtpFrom.Text
                    .XrLabel5.Text = Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
                ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
                    DateFilter = String.Format("For {0} - {1}", dtpFrom.Text, dtpTo.Text)
                    .lblFinancialH.Text = dtpFrom.Text & " - " & dtpTo.Text
                    .XrLabel4.Text = dtpFrom.Text & " - " & dtpTo.Text
                    .XrLabel5.Text = Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy") & " - " & Format(dtpTo.Value.AddYears(-1), "MMMM dd, yyyy")
                ElseIf cbxDisplay.SelectedIndex = 5 Then
                    .lblFinancialH.Text = dtpFrom.Text
                    .XrLabel4.Text = dtpFrom.Text
                    .XrLabel5.Text = Format(dtpFrom.Value.AddYears(-1), "MMMM dd, yyyy")
                End If

                If cbxWithFinancialPlan.Checked = False Then
                    .lblFinancialH2.Visible = False
                    .lblFinancialH.Visible = False
                    .lblFinancial.Visible = False
                    .lblAccountH.SizeF = New Size(400 + 100, 35)
                    .lblAccount.SizeF = New Size(400 + 100, 20)
                End If

                .DataSource = GridControl1.DataSource
                .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Account Name")
                .lblFinancial.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Plan")
                .lblActual_1.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual")
                .lblActual_2.DataBindings.Add("Text", GridControl1.DataSource, "AsOf_Actual_1")
                .lblDifference.DataBindings.Add("Text", GridControl1.DataSource, "Difference")
                If CompanyMode = 0 Then
                    .lblFinancialH2.Visible = False
                    .lblFinancialH.Visible = False
                    .lblFinancial.Visible = False

                    .lblAccountH.WidthF = 500
                    .lblAccount.WidthF = 500
                End If
                Logs("Income Statement", "Print", "[SENSITIVE] Print Income Statement", "", "", "", "")

                .ShowPreview()
            End With
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

    Private Sub CbxToDate_CheckedChanged(sender As Object, e As EventArgs) Handles cbxToDate.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If
        If (cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "") And cbxAllB.Checked = False Then
            MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
        End If

        If cbxToDate.Checked Then
            cbxWithFinancialPlan.Visible = False
            cbxWithFinancialPlan.Checked = False
        Else
            cbxWithFinancialPlan.Visible = True
            cbxWithFinancialPlan.Checked = True
        End If

        LoadData()
    End Sub

    Private Sub CbxSubAccount_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSubAccount.CheckedChanged
        If FirstLoad Then
            Exit Sub
        End If
        If (cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "") And cbxAllB.Checked = False Then
            MsgBox("Please select a branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
        End If

        LoadData()
    End Sub

    Private Sub BtnPrintCustomized_Click(sender As Object, e As EventArgs) Handles btnPrintCustomized.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("INCOME STATEMENT", GridControl1)
        Logs("Income Statement", "Print", "[SENSITIVE] Print Income Statement", "", "", "", "")
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

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
            cbxToDate.Checked = False
            cbxToDate.Enabled = False
        Else
            cbxDisplay.SelectedIndex = 5
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
            cbxToDate.Enabled = True
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
            cbxToDate.Enabled = False
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
            cbxToDate.Enabled = False
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
            cbxToDate.Enabled = False
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
            cbxToDate.Enabled = False
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            lblFrom.Text = "From :"
            LabelX41.Visible = True
            dtpTo.Visible = True
            cbxToDate.Enabled = False
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"

            dtpFrom.Value = Date.Now
            lblFrom.Text = "As Of :"
            LabelX41.Visible = False
            dtpTo.Visible = False
            cbxToDate.Enabled = True
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Account Code").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Transaction As New FrmGeneralLedgerAccount
        With Transaction
            .vPrint = vPrint
            .lblTitle.Text = GridView1.GetFocusedRowCellValue("Account Name")
            .Main_ID = GridView1.GetFocusedRowCellValue("Account Code")
            .From_IncomeStatement = True
            Dim Account_Details As DataTable = DataSource(String.Format("SELECT `Type`, Classification, `Group`, `Code`, Title, Description FROM account_chart WHERE `Code` = '{0}';", GridView1.GetFocusedRowCellValue("Account Code")))
            If Account_Details.Rows.Count = 0 Then
                Exit Sub
            End If
            .txtType.Text = Account_Details(0)("Type")
            .txtClassification.Text = Account_Details(0)("Classification")
            .txtGroup.Text = Account_Details(0)("Group")
            .txtAccountNumber.Text = Account_Details(0)("Code")
            .txtAccount.Text = Account_Details(0)("Title")
            .rDescription.Text = Account_Details(0)("Description")
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub CbxWithFinancialPlan_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWithFinancialPlan.CheckedChanged
        If CompanyMode = 0 Or cbxWithFinancialPlan.Checked = False Then
            If GridView1.RowCount > 23 Then
                GridColumn3.Width = 609 + 135 - 17
                LabelX3.Location = New Point(766 - 25, 106)
            Else
                GridColumn3.Width = 609 + 135
                LabelX3.Location = New Point(766 - 7, 106)
            End If
            LabelX2.Visible = False
            GridColumn18.Visible = False
        Else
            If GridView1.RowCount > 23 Then
                GridColumn3.Width = 609 - 17
                LabelX3.Location = New Point(766 - 25, 106)
                LabelX2.Location = New Point(624 - 17, 106)
            Else
                GridColumn3.Width = 609
                LabelX3.Location = New Point(766 - 7, 106)
                LabelX2.Location = New Point(624, 106)
            End If
            LabelX2.Visible = True
            GridColumn18.Visible = True
        End If
    End Sub
End Class