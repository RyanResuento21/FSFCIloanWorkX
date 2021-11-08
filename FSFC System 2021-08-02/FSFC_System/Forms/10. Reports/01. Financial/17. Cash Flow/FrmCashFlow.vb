Imports DevExpress.XtraReports.UI
Public Class FrmCashFlow

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Dim DT_BalanceSheet As DataTable
    Dim DT_Account As DataTable

    Private Sub FrmCashFlow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        DT_BalanceSheet = DataSource("SELECT 0 AS 'ID', '' AS 'Account Name', 0.0 AS 'Amount' LIMIT 0")

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

            GetLabelFontSettings({LabelX1, LabelX40, lblFrom, LabelX41, LabelX4})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank, cbxAll, cbxSubAccount})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})
        Catch ex As Exception
            TriggerBugReport("Cash Flow - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Cash Flow", lblTitle.Text)
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
        DT_BalanceSheet.Rows.Add(1, "Cash flow from operating activities", 0.0)
        Dim SQL As String
        Dim DateCondition_1 As String = ""
        If cbxDisplay.SelectedIndex = 0 Then
            DateCondition_1 = String.Format("DATE(ORDate) = DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
        ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
            DateCondition_1 = String.Format("DATE(ORDate) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            DateCondition_1 = String.Format("DATE(ORDate) <= DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
        End If

        SQL = " SELECT "
        SQL &= "    A.ID,"
        SQL &= "    A.Code AS 'Account Code', A.`Title` AS 'Account Name', A.Type_ID, A.Classification_ID, A.Group_ID, A.Main_ID, A.`Status`,"
        If cbxSubAccount.Checked Then
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual'", If(cbxAll.Checked, True, DateCondition_1))
            SQL &= " FROM account_chart A"
            SQL &= String.Format(" LEFT JOIN (SELECT ID, EntryType, accounting_entry.AccountCode, Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{4}' = '0',TRUE,BusinessCode = '{4}') AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}'))) A2 ON A2.AccountCode = A.`Code`", cbxBranch.SelectedValue, cbxAllB.Checked, If(cbxAll.Checked, True, DateCondition_1), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
            SQL &= "    WHERE A.`status` IN ('ACTIVE','DEACTIVATE') AND A.Main_ID > 0 GROUP BY A.ID HAVING IF(A.`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY A.Code ;"
        Else
            SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND {0} THEN ABS(Amount) END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND {0} THEN ABS(Amount) END),0) AS 'AsOf_Actual'", If(cbxAll.Checked, True, DateCondition_1))
            SQL &= " FROM account_chart A"
            SQL &= String.Format(" LEFT JOIN (SELECT ID, EntryType, MotherCode AS 'AccountCode', Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF('{1}' = 'True',Branch_ID IN ({5}),Branch_ID = '{0}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({3} > 0, BankID = '{3}',TRUE) AND IF('{4}' = '0',TRUE,BusinessCode = '{4}') AND IF('{6}' = 'True',TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}'))) A2 ON A2.AccountCode = A.`Code`", cbxBranch.SelectedValue, cbxAllB.Checked, If(cbxAll.Checked, True, DateCondition_1), DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
            SQL &= "    WHERE A.`status` IN ('ACTIVE','DEACTIVATE') AND A.Main_ID = 0 AND AdjunctAccount = 0 GROUP BY A.ID HAVING IF(A.`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY A.Code ;"
        End If
        DT_Account = DataSource(SQL)
        Dim TotalIncome As Double
        Dim TotalIncomeWithAdjustment As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            If DT_Account(x)("Type_ID") = 5 Then
                TotalIncome -= CDbl(DT_Account(x)("AsOf_Actual"))
            Else
                TotalIncome += CDbl(DT_Account(x)("AsOf_Actual"))
            End If
        Next
        DT_BalanceSheet.Rows.Add(5, "   Net Income", TotalIncome)
        DT_BalanceSheet.Rows.Add(5, "       Adjustment For:", 0.0)
        TotalIncomeWithAdjustment += TotalIncome
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            If cbxSubAccount.Checked Then
                If DT_Account(x)("Main_ID") = 363 Or DT_Account(x)("Main_ID") = 486 Or DT_Account(x)("Main_ID") = 401 Or DT_Account(x)("Main_ID") = 413 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("Main_ID"), "            " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalIncomeWithAdjustment += DT_Account(x)("AsOf_Actual")
                End If
            Else
                If DT_Account(x)("ID") = 363 Or DT_Account(x)("ID") = 486 Or DT_Account(x)("ID") = 401 Or DT_Account(x)("ID") = 413 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("ID"), "             " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalIncomeWithAdjustment += DT_Account(x)("AsOf_Actual")
                End If
            End If
        Next
        '*******************************BAD DEBT
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            If cbxSubAccount.Checked Then
                If DT_Account(x)("Main_ID") = 327 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("Main_ID"), "            " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalIncomeWithAdjustment += DT_Account(x)("AsOf_Actual")
                End If
            Else
                If DT_Account(x)("ID") = 327 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("ID"), "             " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalIncomeWithAdjustment += DT_Account(x)("AsOf_Actual")
                End If
            End If
        Next

        DT_BalanceSheet.Rows.Add(1, "       Operating Income (Loss) Before Working Capital Changes", TotalIncomeWithAdjustment)

        Dim TotalOperatingActivities As Double
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            If cbxSubAccount.Checked Then
                If DT_Account(x)("Main_ID") = 11 Or DT_Account(x)("Main_ID") = 21 Or DT_Account(x)("Main_ID") = 58 Or DT_Account(x)("Main_ID") = 62 Or DT_Account(x)("Main_ID") = 136 Or DT_Account(x)("Main_ID") = 170 Or DT_Account(x)("Main_ID") = 177 Or DT_Account(x)("Main_ID") = 422 Or DT_Account(x)("Main_ID") = 183 Or DT_Account(x)("Main_ID") = 192 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("Main_ID"), "       Decrease (Increase) " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalOperatingActivities += DT_Account(x)("AsOf_Actual")
                End If
            Else
                If DT_Account(x)("ID") = 11 Or DT_Account(x)("ID") = 21 Or DT_Account(x)("ID") = 58 Or DT_Account(x)("ID") = 62 Or DT_Account(x)("ID") = 136 Or DT_Account(x)("ID") = 170 Or DT_Account(x)("ID") = 177 Or DT_Account(x)("ID") = 422 Or DT_Account(x)("ID") = 183 Or DT_Account(x)("ID") = 192 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("ID"), "       Decrease (Increase) " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalOperatingActivities += DT_Account(x)("AsOf_Actual")
                End If
            End If
        Next
        DT_BalanceSheet.Rows.Add(1, "       Net cash provided by operating activities", TotalOperatingActivities)

        Dim TotalInvestingActivities As Double
        DT_BalanceSheet.Rows.Add(5, "", 0.0)
        DT_BalanceSheet.Rows.Add(1, "Cash flow from investing activities", 0.0)
        'Property and Equipment
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            If cbxSubAccount.Checked Then
                If DT_Account(x)("Main_ID") = 114 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("Main_ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalInvestingActivities += DT_Account(x)("AsOf_Actual")
                End If
            Else
                If DT_Account(x)("ID") = 114 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalInvestingActivities += DT_Account(x)("AsOf_Actual")
                End If
            End If
        Next
        DT_BalanceSheet.Rows.Add(5, "       Transfer to ROPA Account-VL", 0.0)
        DT_BalanceSheet.Rows.Add(1, "       Net cash used in investing activities", TotalInvestingActivities)

        Dim TotalFinancingActivities As Double
        DT_BalanceSheet.Rows.Add(5, "", 0.0)
        DT_BalanceSheet.Rows.Add(1, "Cash flow from financing activities", 0.0)
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            If cbxSubAccount.Checked Then
                If DT_Account(x)("Main_ID") = 205 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("Main_ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalFinancingActivities += DT_Account(x)("AsOf_Actual")
                End If
            Else
                If DT_Account(x)("ID") = 205 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalFinancingActivities += DT_Account(x)("AsOf_Actual")
                End If
            End If
        Next
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            If cbxSubAccount.Checked Then
                If DT_Account(x)("Main_ID") = 138 Or DT_Account(x)("Main_ID") = 189 Or DT_Account(x)("Main_ID") = 142 Or DT_Account(x)("Main_ID") = 169 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("Main_ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalFinancingActivities += DT_Account(x)("AsOf_Actual")
                End If
            Else
                If DT_Account(x)("ID") = 138 Or DT_Account(x)("ID") = 189 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalFinancingActivities += DT_Account(x)("AsOf_Actual")
                End If
            End If
        Next
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            If cbxSubAccount.Checked Then
                If DT_Account(x)("Main_ID") = 66 Or DT_Account(x)("Main_ID") = 94 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("Main_ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalFinancingActivities += DT_Account(x)("AsOf_Actual")
                End If
            Else
                If DT_Account(x)("ID") = 66 Or DT_Account(x)("ID") = 94 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalFinancingActivities += DT_Account(x)("AsOf_Actual")
                End If
            End If
        Next
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            If cbxSubAccount.Checked Then
                If DT_Account(x)("Main_ID") = 142 Or DT_Account(x)("Main_ID") = 169 Or DT_Account(x)("Main_ID") = 196 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("Main_ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalFinancingActivities += DT_Account(x)("AsOf_Actual")
                End If
            Else
                If DT_Account(x)("ID") = 142 Or DT_Account(x)("ID") = 169 Or DT_Account(x)("ID") = 196 Then
                    DT_BalanceSheet.Rows.Add(DT_Account(x)("ID"), "       " & DT_Account(x)("Account Name"), DT_Account(x)("AsOf_Actual"))
                    TotalFinancingActivities += DT_Account(x)("AsOf_Actual")
                End If
            End If
        Next
        DT_BalanceSheet.Rows.Add(1, "       Net cash used in financing activities", TotalFinancingActivities)

        DT_BalanceSheet.Rows.Add(5, "", 0.0)
        DT_BalanceSheet.Rows.Add(1, "INCREASE (DECREASE) OF CASH", TotalOperatingActivities + TotalInvestingActivities + TotalFinancingActivities)
        DT_BalanceSheet.Rows.Add(5, "Cash balance, " & Format(dtpFrom.Value.AddMonths(-1), "MMM dd, yyyy"), 0.0)
        DT_BalanceSheet.Rows.Add(5, "Cash balance, " & Format(dtpFrom.Value, "MMM dd, yyyy"), TotalOperatingActivities + TotalInvestingActivities + TotalFinancingActivities)

        GridControl1.DataSource = DT_BalanceSheet
        Cursor = Cursors.Default
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
        Dim Report As New RptCashFlow
        With Report
            Dim DateFilter As String = ""
            If cbxDisplay.SelectedIndex = 0 Then
                DateFilter = String.Format("For {0}", dtpFrom.Text)
            ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
                DateFilter = String.Format("For {0} - {1}", dtpFrom.Text, dtpTo.Text)
            ElseIf cbxDisplay.SelectedIndex = 5 Then
                DateFilter = String.Format("As of {0}", dtpFrom.Text)
            End If

            .Name = String.Format("Cash Flow of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), DateFilter)
            .lblBranch.Text = If(cbxAllB.Checked, "All Branch", cbxBranch.Text)
            .lblAsOf.Text = DateFilter

            .DataSource = GridControl1.DataSource
            .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Account Name")
            .lblAmount.DataBindings.Add("Text", GridControl1.DataSource, "Amount")
            Logs("Cash Flow", "Print", "[SENSITIVE] Print Cash Flow", "", "", "", "")

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
        StandardPrinting("CASH FLOW", GridControl1)
        Logs("Cash Flow", "Print", "[SENSITIVE] Print Cash Flow", "", "", "", "")
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

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ID As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("ID"))
                If ID < 4 Then
                    e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
                Else
                    If ID = 327 Then
                        e.Appearance.BackColor = Color.Yellow
                    End If
                    e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Regular)
                End If
            Catch ex As Exception
            End Try
        End If
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
End Class