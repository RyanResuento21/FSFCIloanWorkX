Imports DevExpress.XtraReports.UI
Public Class FrmDeliquencyReport

    Public vPrint As Boolean
    Dim FirstLoad As Boolean
    Dim DT_AO As New DataTable
    Dim DT_Result As DataTable
    Dim DT_Print As DataTable

    Private Sub FrmDeliquencyReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxAccountOfficer.Location = New Point(71, 36)
        cbxAccountOfficer.Size = New Point(379, 26)
        cbxDisplay.SelectedIndex = 5

        DT_Result = DataSource("SELECT '' AS 'Credit Number', '' AS 'Borrower', '' AS 'PN Number', '' AS 'Date Granted', '' AS 'Date Maturity', '' AS 'Term/Interest', 0.0 AS 'Loan Amount', 0.0 AS 'Principal PAR', 0.0 AS 'Interest PAR', 0.0 AS 'Total PAR', 0.0 AS 'Principal Amortization', 0.0 AS 'Interest Amortization', 0.0 AS 'Total Amortization', 0 AS 'Missed Amortization', 0 AS 'Days Past Due', '' AS 'Last Transaction' LIMIT 0")
        DT_Print = DataSource("SELECT '' AS 'Marketing',  '' AS 'Borrower', '' AS 'PN Number', '' AS 'Date Granted', '' AS 'Date Maturity', '' AS 'Term/Interest', 0.0 AS 'Loan Amount', 0.0 AS 'Principal PAR', 0.0 AS 'Interest PAR', 0.0 AS 'Total PAR', 0.0 AS 'Principal Amortization', 0.0 AS 'Interest Amortization', 0.0 AS 'Total Amortization', 0 AS 'Missed Amortization', 0 AS 'Days Past Due', '' AS 'Last Transaction' LIMIT 0")

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

        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
        Else
            DT_AO = DataSource(String.Format("SELECT emp_code, CONCAT(IF(prefix = '','',CONCAT(prefix, ' ')), IF(first_name = '','',CONCAT(first_name, ' ')), IF(middle_name = '','',CONCAT(middle_name, ' ')), IF(last_name = '','',CONCAT(last_name, ' ')), suffix) AS 'Name' FROM employee_setup WHERE Branch_ID IN ({0}) AND `status` = 'ACTIVE' AND department_id = 9 ORDER BY `Name`;", If(cbxAllB.Checked, If(Multiple_ID = "", Branch_ID, Multiple_ID), cbxBranch.SelectedValue)))
            With cbxAccountOfficer
                .Properties.LookAndFeel.SkinName = "Blue"
                .Properties.Items.Clear()
                For x As Integer = 0 To DT_AO.Rows.Count - 1
                    .Properties.Items.Add(DT_AO(x)("emp_code"), DT_AO(x)("Name"), CheckState.Unchecked, True)
                Next
                .Properties.SeparatorChar = ";"
                .SetEditValue(Multiple_ID.Replace(",", "; "))
                .Properties.DropDownRows = 10
            End With
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

            GetLabelFontSettings({LabelX1, LabelX4, LabelX40, lblFrom, LabelX41})

            GetCheckBoxFontSettings({cbxAllB, cbxAllAO, cbxAll})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxDisplay})

            GetCheckComboBoxFontSettings({cbxAccountOfficer})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})

            GetContextMenuBarFontSettings({ContextMenuBar3})
        Catch ex As Exception
            TriggerBugReport("Deliquency Report - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Deliquency Report", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String
        Dim DT_Temp As DataTable
        Dim DateCondition_1 As String = ""
        If cbxDisplay.SelectedIndex = 0 Then
            DateCondition_1 = String.Format("DATE(Released) = DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
        ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
            DateCondition_1 = String.Format("DATE(Released) BETWEEN DATE('{0}') AND DATE('{1}')", Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"))
        ElseIf cbxDisplay.SelectedIndex = 5 Then
            DateCondition_1 = String.Format("DATE(Released) <= DATE('{0}')", Format(dtpFrom.Value, "yyyy-MM-dd"))
        End If

        DT_Result.Rows.Clear()
        DT_Print.Rows.Clear()
        If cbxAllAO.Checked Then
            For x As Integer = 0 To DT_AO.Rows.Count - 1
                SQL = "SELECT "
                SQL &= "  CreditNumber AS 'Credit Number',"
                SQL &= "  CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Borrower', "
                SQL &= "  AccountNumber AS 'PN Number',"
                SQL &= "  DATE_FORMAT(Released,'%b %d, %Y') AS 'Date Granted',"
                SQL &= "  DATE_FORMAT(LDD,'%b %d, %Y') AS 'Date Maturity',"
                SQL &= "  CONCAT(Terms,'/',IF(CEIL(interest_rate / 12) = interest_rate / 12,interest_rate / 12,ROUND(interest_rate / 12,2)),'%/',SUBSTRING(TermType,1,1)) AS 'Term/Interest',"
                SQL &= "  AmountApplied AS 'Loan Amount',"
                SQL &= "  Face_Amount, TermType"
                SQL &= String.Format("  FROM credit_application C WHERE `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED') AND MarketingID = '{0}' AND IF('{3}' = 'True',Branch_ID IN ({5}),Branch_ID = '{2}') AND IF('{4}' = '0',TRUE,BusinessID = '{4}') ORDER BY Released, AccountNumber", DT_AO(x)("emp_code"), If(cbxAll.Checked, True, DateCondition_1), cbxBranch.SelectedValue, cbxAllB.Checked, ValidateComboBox(cbxBusinessCenter), Multiple_ID)
                DT_Temp = DataSource(SQL)
                If DT_Temp.Rows.Count > 0 Then
                    If DT_Result.Rows.Count > 1 Then
                        DT_Result.Rows.Add("")
                    End If
                    DT_Result.Rows.Add("", "Account Officer : " & DT_AO(x)("Name"))
                    Dim AmountLoan As Double
                    Dim Principal_PAR As Double
                    Dim Interest_PAR As Double
                    Dim TOTAL_PAR As Double
                    Dim Principal_AD As Double
                    Dim Interest_AD As Double
                    Dim TOTAL_AD As Double
                    For y As Integer = 0 To DT_Temp.Rows.Count - 1
                        Dim Balances As Object = GetBalancePrincipalInterest(DT_Temp(y)("Credit Number"))
                        LoadAmortizationBasic(DT_Temp(y)("Credit Number"), GridControl3)
                        Dim Dues As Object = GetPrincipalInterestDue(DT_Temp(y)("Credit Number"), DT_Temp(y)("Face_Amount"), DT_Temp(y)("TermType"), dtpFrom.Value, GridView3)
                        Dim Unpaid As Object = GetUnpaidTerms(DT_Temp(y)("Credit Number"), dtpFrom.Value)
                        With DT_Result.Rows
                            .Add(DT_Temp(y)("Credit Number"), DT_Temp(y)("Borrower"), DT_Temp(y)("PN Number"), DT_Temp(y)("Date Granted"), DT_Temp(y)("Date Maturity"), DT_Temp(y)("Term/Interest"), CDec(DT_Temp(y)("Loan Amount")), CDec(Balances(0)), CDec(Balances(1)), CDec(Balances(0)) + CDec(Balances(1)), CDec(Dues(0)), CDec(Dues(1)), CDec(Dues(0)) + CDec(Dues(1)), Unpaid(0), Unpaid(1), Format(CDate(Balances(2)), "MMM dd, yyyy"))
                        End With
                        With DT_Print.Rows
                            .Add("Account Officer: " & DT_AO(x)("Name"), DT_Temp(y)("Borrower"), DT_Temp(y)("PN Number"), DT_Temp(y)("Date Granted"), DT_Temp(y)("Date Maturity"), DT_Temp(y)("Term/Interest"), CDec(DT_Temp(y)("Loan Amount")), CDec(Balances(0)), CDec(Balances(1)), CDec(Balances(0)) + CDec(Balances(1)), CDec(Dues(0)), CDec(Dues(1)), CDec(Dues(0)) + CDec(Dues(1)), Unpaid(0), Unpaid(1), Format(CDate(Balances(2)), "MMM dd, yyyy"))
                        End With
                        AmountLoan += CDec(DT_Temp(y)("Loan Amount"))
                        Principal_PAR += CDec(Balances(0))
                        Interest_PAR += CDec(Balances(1))
                        TOTAL_PAR += CDec(Balances(0)) + CDec(Balances(1))
                        Principal_AD += CDec(Dues(0))
                        Interest_AD += CDec(Dues(1))
                        TOTAL_AD += CDec(Dues(0)) + CDec(Dues(1))
                    Next
                    DT_Result.Rows.Add("", "Total " & DT_Temp.Rows.Count, "", "", "", "", AmountLoan, Principal_PAR, Interest_PAR, TOTAL_PAR, Principal_AD, Interest_AD, TOTAL_AD)
                End If
            Next
        Else
            For x As Integer = 0 To cbxAccountOfficer.Properties.Items.Count - 1
                If cbxAccountOfficer.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                    SQL = "SELECT "
                    SQL &= "  CreditNumber AS 'Credit Number',"
                    SQL &= "  CONCAT(IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B), CONCAT(IF(FirstN_A = '','',CONCAT(FirstN_A, ' ')), IF(MiddleN_A = '','',CONCAT(MiddleN_A, ' ')), IF(LastN_A = '','',CONCAT(LastN_A, ' ')), Suffix_A))) AS 'Borrower', "
                    SQL &= "  AccountNumber AS 'PN Number',"
                    SQL &= "  DATE_FORMAT(Released,'%b %d, %Y') AS 'Date Granted',"
                    SQL &= "  DATE_FORMAT(LDD,'%b %d, %Y') AS 'Date Maturity',"
                    SQL &= "  CONCAT(Terms,'/',IF(CEIL(interest_rate / 12) = interest_rate / 12,interest_rate / 12,ROUND(interest_rate / 12,2)),'%/',SUBSTRING(TermType,1,1)) AS 'Term/Interest',"
                    SQL &= "  AmountApplied AS 'Loan Amount',"
                    SQL &= "  Face_Amount, TermType"
                    SQL &= String.Format("  FROM credit_application C WHERE `status` = 'ACTIVE' AND PaymentRequest IN ('RELEASED') AND MarketingID = '{0}' AND IF('{3}' = 'True',Branch_ID IN ({5}),Branch_ID = '{2}') AND IF('{4}' = '0',TRUE,BusinessID = '{4}') ORDER BY Released, AccountNumber", cbxAccountOfficer.Properties.Items.Item(x).Value.ToString, If(cbxAll.Checked, True, DateCondition_1), cbxBranch.SelectedValue, cbxAllB.Checked, ValidateComboBox(cbxBusinessCenter), Multiple_ID)
                    DT_Temp = DataSource(SQL)
                    If DT_Temp.Rows.Count > 0 Then
                        If DT_Result.Rows.Count > 1 Then
                            DT_Result.Rows.Add("")
                        End If
                        DT_Result.Rows.Add("", "Account Officer : " & cbxAccountOfficer.Properties.Items.Item(x).Description.ToString)
                        Dim AmountLoan As Double
                        Dim Principal_PAR As Double
                        Dim Interest_PAR As Double
                        Dim TOTAL_PAR As Double
                        Dim Principal_AD As Double
                        Dim Interest_AD As Double
                        Dim TOTAL_AD As Double
                        For y As Integer = 0 To DT_Temp.Rows.Count - 1
                            Dim Balances As Object = GetBalancePrincipalInterest(DT_Temp(y)("Credit Number"))
                            LoadAmortizationBasic(DT_Temp(y)("Credit Number"), GridControl3)
                            Dim Dues As Object = GetPrincipalInterestDue(DT_Temp(y)("Credit Number"), DT_Temp(y)("Face_Amount"), DT_Temp(y)("TermType"), dtpFrom.Value, GridView3)
                            Dim Unpaid As Object = GetUnpaidTerms(DT_Temp(y)("Credit Number"), dtpFrom.Value)
                            With DT_Result.Rows
                                .Add(DT_Temp(y)("Credit Number"), DT_Temp(y)("Borrower"), DT_Temp(y)("PN Number"), DT_Temp(y)("Date Granted"), DT_Temp(y)("Date Maturity"), DT_Temp(y)("Term/Interest"), CDec(DT_Temp(y)("Loan Amount")), CDec(Balances(0)), CDec(Balances(1)), CDec(Balances(0)) + CDec(Balances(1)), CDec(Dues(0)), CDec(Dues(1)), CDec(Dues(0)) + CDec(Dues(1)), Unpaid(0), Unpaid(1), Format(CDate(Balances(2)), "MMM dd, yyyy"))
                            End With
                            With DT_Print.Rows
                                .Add("Account Officer: " & cbxAccountOfficer.Properties.Items.Item(x).Description.ToString, DT_Temp(y)("Borrower"), DT_Temp(y)("PN Number"), DT_Temp(y)("Date Granted"), DT_Temp(y)("Date Maturity"), DT_Temp(y)("Term/Interest"), CDec(DT_Temp(y)("Loan Amount")), CDec(Balances(0)), CDec(Balances(1)), CDec(Balances(0)) + CDec(Balances(1)), CDec(Dues(0)), CDec(Dues(1)), CDec(Dues(0)) + CDec(Dues(1)), Unpaid(0), Unpaid(1), Format(CDate(Balances(2)), "MMM dd, yyyy"))
                            End With
                            AmountLoan += CDec(DT_Temp(y)("Loan Amount"))
                            Principal_PAR += CDec(Balances(0))
                            Interest_PAR += CDec(Balances(1))
                            TOTAL_PAR += CDec(Balances(0)) + CDec(Balances(1))
                            Principal_AD += CDec(Dues(0))
                            Interest_AD += CDec(Dues(1))
                            TOTAL_AD += CDec(Dues(0)) + CDec(Dues(1))
                        Next
                        DT_Result.Rows.Add("", "Total " & DT_Temp.Rows.Count, "", "", "", "", AmountLoan, Principal_PAR, Interest_PAR, TOTAL_PAR, Principal_AD, Interest_AD, TOTAL_AD)
                    End If
                End If
            Next
        End If
        GridControl1.DataSource = DT_Result
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim CreditNumber As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Credit Number"))
                If CreditNumber = "" Then
                    e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
                Else
                    e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Regular)
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Public Sub LoadAmortizationBasic(CreditNumber As String, Grid As DevExpress.XtraGrid.GridControl)
        Dim Temp_DT As DataTable = DataSource(String.Format("SELECT `No`, IFNULL(DATE_FORMAT(DueDate,'%m.%d.%Y'),'') AS 'Due Date', IF(`No` = '','',FORMAT(Monthly,2)) AS 'Monthly', IF(`No` = '','',FORMAT(InterestIncome,2)) AS 'Interest Income', IF(`No` = '','',FORMAT(RPPD,2)) AS 'RPPD', IF(`No` = '','',FORMAT(PrincipalAllocation,2)) AS 'Principal Allocation', FORMAT(OutstandingPrincipal,2) AS 'Outstanding Principal', FORMAT(Total_RPPD,2) AS 'Total_RPPD', FORMAT(UnearnIncome,2) AS 'Unearn Income', FORMAT(LoansReceivable,2) AS 'Loans Receivable', IF(`No` = '','',FORMAT(Penalty,2)) AS 'Penalty', FORMAT(PenaltyBalance,2) AS 'Penalty Balance' FROM credit_schedule WHERE CreditNumber = '{0}' AND `status` = 'ACTIVE';", CreditNumber))
        Dim T_Monthly As Double
        Dim T_Interest As Double
        Dim T_RPPD As Double
        Dim T_Principal As Double
        Dim T_Penalty As Double
        For x As Integer = 1 To Temp_DT.Rows.Count - 1
            T_Monthly += CDbl(Temp_DT(x)("Monthly"))
            T_Interest += CDbl(Temp_DT(x)("Interest Income"))
            T_RPPD += CDbl(Temp_DT(x)("RPPD"))
            T_Principal += CDbl(Temp_DT(x)("Principal Allocation"))
            T_Penalty += CDbl(Temp_DT(x)("Penalty"))
        Next
        Temp_DT.Rows.Add("", "TOTAL", FormatNumber(T_Monthly, ), FormatNumber(T_Interest, 2), FormatNumber(T_RPPD, 2), FormatNumber(T_Principal, 2), 0, 0, 0, 0, Format(T_Penalty, 2), 0)
        Grid.DataSource = Temp_DT
    End Sub

    Private Sub GridView3_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView3.FocusedRowChanged
        If GridView3.RowCount = 0 Then
            Exit Sub
        End If

        Dim RightRow As Integer = 0
        For x As Integer = 1 To GridView3.RowCount - 1
            If GridView3.GetRowCellValue(x, "Due Date") = "" Or GridView3.GetRowCellValue(x, "Due Date") = "TOTAL" Then
            Else
                If dtpFrom.Value >= CDate(GridView3.GetRowCellValue(x, "Due Date")) Then
                    RightRow = x
                ElseIf x = GridView3.RowCount - 2 And dtpFrom.Value < CDate(GridView3.GetRowCellValue(1, "Due Date")) Then
                    RightRow = 1
                End If
            End If
        Next
        If GridView3.FocusedRowHandle = RightRow Then
        Else
            GridView3.FocusedRowHandle = RightRow
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
        Dim Report As New RptDeliquencyReport
        With Report
            Dim DateFilter As String = ""
            If cbxDisplay.SelectedIndex = 0 Then
                DateFilter = String.Format("For {0}", dtpFrom.Text)
            ElseIf cbxDisplay.SelectedIndex = 1 Or cbxDisplay.SelectedIndex = 2 Or cbxDisplay.SelectedIndex = 3 Or cbxDisplay.SelectedIndex = 4 Then
                DateFilter = String.Format("For {0} - {1}", dtpFrom.Text, dtpTo.Text)
            ElseIf cbxDisplay.SelectedIndex = 5 Then
                DateFilter = String.Format("As of {0}", dtpFrom.Text)
            End If

            .Name = String.Format("Deliquency Report / Portfolio-At-Risk Report of {0} {1}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text), DateFilter)
            .lblBranch.Text = If(cbxAllB.Checked, "ALL BRANCHES", cbxBranch.Text)
            .lblAsOf.Text = DateFilter
            .DataSource = DT_Print
            Dim groupField As New GroupField("Marketing")
            .GroupHeader1.GroupFields.Add(groupField)
            .lblBorrowerH.DataBindings.Add("Text", DT_Print, "Marketing")
            .lblBorrower.DataBindings.Add("Text", DT_Print, "Borrower")
            .lblPN.DataBindings.Add("Text", DT_Print, "PN Number")
            .lblDateGranted.DataBindings.Add("Text", DT_Print, "Date Granted")
            .lblDateMaturity.DataBindings.Add("Text", DT_Print, "Date Maturity")
            .lblInterest.DataBindings.Add("Text", DT_Print, "Term/Interest")
            .lblLoanAmount.DataBindings.Add("Text", DT_Print, "Loan Amount")
            .lblPrincipalPAR.DataBindings.Add("Text", DT_Print, "Principal PAR")
            .lblInterestPAR.DataBindings.Add("Text", DT_Print, "Interest PAR")
            .lblTotaLPAR.DataBindings.Add("Text", DT_Print, "Total PAR")
            .lblPrincipalAD.DataBindings.Add("Text", DT_Print, "Principal Amortization")
            .lblInterestAD.DataBindings.Add("Text", DT_Print, "Interest Amortization")
            .lblTotalAD.DataBindings.Add("Text", DT_Print, "Total Amortization")
            .lblMissedA.DataBindings.Add("Text", DT_Print, "Missed Amortization")
            .lblDaysPastDue.DataBindings.Add("Text", DT_Print, "Days Past Due")
            .lblLastTransaction.DataBindings.Add("Text", DT_Print, "Last Transaction")

            .lblLoanAmountT.DataBindings.Add("Text", DT_Print, "Loan Amount")
            .lblPrincipalPART.DataBindings.Add("Text", DT_Print, "Principal PAR")
            .lblInterestPART.DataBindings.Add("Text", DT_Print, "Interest PAR")
            .lblTotaLPART.DataBindings.Add("Text", DT_Print, "Total PAR")
            .lblPrincipalADT.DataBindings.Add("Text", DT_Print, "Principal Amortization")
            .lblInterestADT.DataBindings.Add("Text", DT_Print, "Interest Amortization")
            .lblTotalADT.DataBindings.Add("Text", DT_Print, "Total Amortization")
            Logs("Deliquency Report", "Print", "[SENSITIVE] Print Deliquency Report", "", "", "", "")

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
        StandardPrinting(lblTitle.Text, GridControl1)
        Logs("Deliquency Report", "Print", "[SENSITIVE] Print Deliquency Report", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        If FirstLoad Or cbxBranch.SelectedIndex = -1 Then
            Exit Sub
        End If

        If MultipleBranch Then
            With cbxBusinessCenter
                .DataSource = DataSource(String.Format("SELECT ID, BusinessCode, BusinessCenter FROM business_center WHERE `status` = 'ACTIVE' AND BranchID = '{0}';", cbxBranch.SelectedValue))
                If .Items.Count > 0 Then
                    .Enabled = True
                Else
                    .Enabled = False
                End If
                .SelectedIndex = -1
            End With

            DT_AO = DataSource(String.Format("SELECT emp_code, CONCAT(IF(prefix = '','',CONCAT(prefix, ' ')), IF(first_name = '','',CONCAT(first_name, ' ')), IF(middle_name = '','',CONCAT(middle_name, ' ')), IF(last_name = '','',CONCAT(last_name, ' ')), suffix) AS 'Name' FROM employee_setup WHERE Branch_ID IN ({0}) AND `status` = 'ACTIVE' AND department_id = 9 ORDER BY `Name`;", If(cbxAllB.Checked, If(Multiple_ID = "", Branch_ID, Multiple_ID), cbxBranch.SelectedValue)))
            With cbxAccountOfficer
                .Properties.LookAndFeel.SkinName = "Blue"
                .Properties.Items.Clear()
                For x As Integer = 0 To DT_AO.Rows.Count - 1
                    .Properties.Items.Add(DT_AO(x)("emp_code"), DT_AO(x)("Name"), CheckState.Unchecked, True)
                Next
                .Properties.SeparatorChar = ";"
                .SetEditValue(Multiple_ID.Replace(",", "; "))
                .Properties.DropDownRows = 10
            End With
        End If
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

    Private Sub CbxAllOA_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAllAO.CheckedChanged
        If cbxAllAO.Checked Then
            cbxAccountOfficer.Enabled = False
            cbxAccountOfficer.Properties.Items.Clear()
        Else
            With cbxAccountOfficer
                .Enabled = True
                .Properties.Items.Clear()
                For x As Integer = 0 To DT_AO.Rows.Count - 1
                    .Properties.Items.Add(DT_AO(x)("emp_code"), DT_AO(x)("Name"), CheckState.Unchecked, True)
                Next
            End With
        End If
    End Sub

    Private Sub ILedger_Click(sender As Object, e As EventArgs) Handles iLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("Credit Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
            .Show()
        End With
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Credit Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Ledger As New FrmAccountLedger
        With Ledger
            .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
            .Show()
        End With
    End Sub

    Private Sub ISOA_Click(sender As Object, e As EventArgs) Handles iSOA.Click
        Try
            If GridView1.GetFocusedRowCellValue("Credit Number") = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim SOA As New FrmSOA
        With SOA
            .From_JV_DTS = True
            .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
            .dtpAsOf.Value = dtpFrom.Value
            .cbxCreditApplication.Enabled = False
            .ShowDialog()
        End With
    End Sub
End Class