Imports DevExpress.XtraReports.UI
Public Class FrmCheckDisbursement

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmCheckDisbursement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource(String.Format("SELECT ID, Branch, branch_code FROM branch WHERE `status` = 'ACTIVE' AND ID IN ({0}) ORDER BY BranchID;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
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

            GetLabelFontSettings({LabelX1, LabelX4, LabelX40, LabelX42, LabelX41})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank, cbxAll})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized, btnDownload})
        Catch ex As Exception
            TriggerBugReport("Check Disbrusement - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Cash Disbursement", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        If CompanyMode = 0 Then
            SQL &= "      DATE_FORMAT(M.`PostingDate`, '%M %d, %Y') AS 'Posting Date',"
            SQL &= "      M.Payee,"
            SQL &= "      M.Explanation,"
            SQL &= "      M.DocumentNumber AS 'Document Number',"
            SQL &= "      M.CheckNumber AS 'Check Number',"
            SQL &= "      AccountTitleCode_Rev(D.MotherCode) AS 'Account Code',"
            SQL &= "      D.Debit AS 'Debit',"
            SQL &= "      D.Credit AS 'Credit'"
            SQL &= "    FROM check_voucher M"
            SQL &= "    INNER JOIN (SELECT DocumentNumber, AccountCode, MotherCode, BusinessCode, DepartmentCode, IF(`Type` = 'D', Amount, 0) AS 'Debit', IF(`Type` = 'C', Amount, 0) AS 'Credit', Remarks FROM cv_details WHERE `status` = 'ACTIVE') D "
            SQL &= "        ON M.DocumentNumber = D.DocumentNumber "
            SQL &= "    WHERE M.`status` = 'ACTIVE' "
            If DefaultBankID > 0 Then
                SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
            End If
            SQL &= "    AND M.Voucher_Status IN ('APPROVED','RECEIVED') AND IF(M.Payee_Type = 'C',M.Voucher_Status = 'RECEIVED',TRUE)"
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(PostingDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessCode = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}')) ORDER BY PostingDate;", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
            GridControl1.DataSource = DataSource(SQL)
            With GridView1
                .Columns("Payee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                .Columns("Payee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
                .Columns("Debit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("Debit").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Credit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("Credit").SummaryItem.DisplayFormat = "{0:n2}"
            End With

            If GridView1.RowCount > 21 Then
                GridColumn2.Width = 229 - 17
            Else
                GridColumn2.Width = 229
            End If

            GridColumn1.Width = 110
            GridColumn3.Width = 350 - 29
            GridColumn14.Visible = False
            GridColumn18.Visible = False
            GridColumn13.Visible = False
            GridColumn12.Visible = False
            GridColumn11.Visible = False
            GridColumn10.Visible = False
            GridColumn15.Visible = False
            GridColumn16.Visible = False
            GridColumn17.Visible = False
            GridColumn7.Visible = False

            GridColumn1.VisibleIndex = 0
            GridColumn2.VisibleIndex = 1
            GridColumn4.VisibleIndex = 2
            GridColumn3.VisibleIndex = 3
            GridColumn5.VisibleIndex = 4
            GridColumn6.VisibleIndex = 5
            GridColumn8.VisibleIndex = 6
            GridColumn9.VisibleIndex = 7
        Else
            SQL &= "      IF(M.Voucher_Status = 'APPROVED','POSTED','UNPOSTED') AS 'Entry Status',"
            SQL &= "      M.Voucher_Status AS 'Status',"
            SQL &= "      IF(ClearedDate = '','UNCLEARED','CLEARED') AS 'Clearing Status',"
            SQL &= "      IF(Payee_Type = 'B','Branch',IF(Payee_Type = 'A','Cash Advance',IF(Payee_Type = 'AP' OR Payee_Type = 'APM','Accounts Payable',IF(Payee_Type = 'E','Employee',IF(Payee_Type = 'RO','ROPOA',IF(Payee_Type = 'NL' OR Payee_Type = 'ITL','Non Loans',IF(Payee_Type = 'S','Supplier',IF(Payee_Type = 'C','Loans',IF(Payee_Type = 'RC','Replenishment',''))))))))) AS 'Transaction Type',"
            SQL &= "      DATE_FORMAT(M.DocumentDate, '%M %d, %Y') AS 'Document Date',"
            SQL &= "      IFNULL(DATE_FORMAT(M.ClearedDate, '%M %d, %Y'),'') AS 'Date Cleared',"
            SQL &= "      DATE_FORMAT(M.`PostingDate`, '%M %d, %Y') AS 'Posting Date',"
            SQL &= "      M.Payee,"
            SQL &= "      M.ReferenceNumber AS 'Account Number',"
            SQL &= "      M.Explanation,"
            SQL &= "      M.DocumentNumber AS 'Document Number',"
            SQL &= "      M.CheckNumber AS 'Check Number',"
            SQL &= "      AccountTitleCode_Rev(D.MotherCode) AS 'Mother Account',"
            SQL &= "      AccountTitleCode_Rev(D.`AccountCode`) AS 'Account Code',"
            SQL &= "      Department(D.DepartmentCode) AS 'Department',"
            SQL &= "      D.Debit AS 'Debit',"
            SQL &= "      D.Credit AS 'Credit',"
            SQL &= "      D.Remarks"
            SQL &= "    FROM check_voucher M"
            SQL &= "    INNER JOIN (SELECT DocumentNumber, AccountCode, MotherCode, BusinessCode, DepartmentCode, IF(`Type` = 'D', Amount, 0) AS 'Debit', IF(`Type` = 'C', Amount, 0) AS 'Credit', Remarks FROM cv_details WHERE `status` = 'ACTIVE') D "
            SQL &= "        ON M.DocumentNumber = D.DocumentNumber "
            SQL &= "    WHERE M.`status` = 'ACTIVE' "
            If DefaultBankID > 0 Then
                SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
            End If
            SQL &= "    AND M.Voucher_Status IN ('APPROVED','PENDING','CHECKED','RECEIVED') AND IF(M.Payee_Type = 'C',M.Voucher_Status = 'RECEIVED',TRUE)"
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(PostingDate) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({3}),Branch_ID = '{1}') AND IF('{2}' = '0',TRUE,BusinessCode = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}')) ORDER BY PostingDate;", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
            GridControl1.DataSource = DataSource(SQL)
            With GridView1
                .Columns("Payee").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
                .Columns("Payee").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
                .Columns("Debit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("Debit").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Credit").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("Credit").SummaryItem.DisplayFormat = "{0:n2}"
            End With

            If GridView1.RowCount > 21 Then
                GridColumn2.Width = 275 - 17
            Else
                GridColumn2.Width = 275
            End If

            GridColumn1.Width = 125
            GridColumn3.Width = 350
            GridColumn14.Visible = True
            GridColumn18.Visible = True
            GridColumn13.Visible = True
            GridColumn12.Visible = True
            GridColumn11.Visible = True
            GridColumn10.Visible = True
            GridColumn15.Visible = True
            GridColumn16.Visible = True
            GridColumn17.Visible = True
            GridColumn7.Visible = True

            GridColumn14.VisibleIndex = 0
            GridColumn18.VisibleIndex = 1
            GridColumn13.VisibleIndex = 2
            GridColumn12.VisibleIndex = 3
            GridColumn11.VisibleIndex = 4
            GridColumn10.VisibleIndex = 5
            GridColumn1.VisibleIndex = 6
            GridColumn2.VisibleIndex = 7
            GridColumn15.VisibleIndex = 8
            GridColumn4.VisibleIndex = 9
            GridColumn3.VisibleIndex = 10
            GridColumn5.VisibleIndex = 11
            GridColumn16.VisibleIndex = 12
            GridColumn6.VisibleIndex = 13
            GridColumn7.VisibleIndex = 14
            GridColumn8.VisibleIndex = 15
            GridColumn9.VisibleIndex = 16
            GridColumn17.VisibleIndex = 17
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim Rows As New ArrayList()
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim TotalDebit As Double
            Dim TotalCredit As Double
            For x As Integer = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Integer = selectedRowHandles(x)
                TotalDebit += GridView1.GetRowCellValue(selectedRowHandle, "Debit")
                TotalCredit += GridView1.GetRowCellValue(selectedRowHandle, "Credit")
            Next
            GridView1.Columns("Debit").SummaryItem.DisplayFormat = FormatNumber(TotalDebit, 2)
            GridView1.Columns("Credit").SummaryItem.DisplayFormat = FormatNumber(TotalCredit, 2)
        Else
            GridView1.Columns("Debit").SummaryItem.DisplayFormat = "{0:n2}"
            GridView1.Columns("Credit").SummaryItem.DisplayFormat = "{0:n2}"
        End If
    End Sub

    Private Sub GridView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim Rows As New ArrayList()
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim Total_1 As Double
            Dim Total_2 As Double
            For x As Integer = 0 To selectedRowHandles.Length - 1
                Dim selectedRowHandle As Integer = selectedRowHandles(x)
                Total_1 += GridView1.GetRowCellValue(selectedRowHandle, "Debit")
                Total_2 += GridView1.GetRowCellValue(selectedRowHandle, "Credit")
            Next
            GridView1.Columns("Debit").SummaryItem.DisplayFormat = FormatNumber(Total_1, 2)
            GridView1.Columns("Credit").SummaryItem.DisplayFormat = FormatNumber(Total_2, 2)
        Else
            GridView1.Columns("Debit").SummaryItem.DisplayFormat = "{0:n2}"
            GridView1.Columns("Credit").SummaryItem.DisplayFormat = "{0:n2}"
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
            Dim Report As New RptCashReceiptV2
            With Report
                .Name = String.Format("Check Disbursement of {0}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text))
                .lblTitle.Text = "Check Disbursements"
                .lblAsOf.Text = If(dtpFrom.Value = dtpTo.Value Or cbxAll.Checked, "", "From " & dtpFrom.Text & " To " & dtpTo.Text)

                .XrLabel9.Text = "Check Number"
                .DataSource = GridControl1.DataSource
                .lblPostingDate.DataBindings.Add("Text", GridControl1.DataSource, "Posting Date")
                .lblPayor.DataBindings.Add("Text", GridControl1.DataSource, "Payee")
                .lblDocumentNumber.DataBindings.Add("Text", GridControl1.DataSource, "Document Number")
                .lblPayment.DataBindings.Add("Text", GridControl1.DataSource, "Check Number")
                .lblAccountCode.DataBindings.Add("Text", GridControl1.DataSource, "Account Code")
                .lblDebit.DataBindings.Add("Text", GridControl1.DataSource, "Debit")
                .lblCredit.DataBindings.Add("Text", GridControl1.DataSource, "Credit")
                .lblExplanation.DataBindings.Add("Text", GridControl1.DataSource, "Explanation")

                Dim DebitT As Double
                Dim CreditT As Double
                For x As Integer = 0 To GridView1.RowCount - 1
                    DebitT += GridView1.GetRowCellValue(x, "Debit")
                    CreditT += GridView1.GetRowCellValue(x, "Credit")
                Next
                .lblDebitT.Text = FormatNumber(DebitT, 2)
                .lblCreditT.Text = FormatNumber(CreditT, 2)
                Logs("Cash Disbursement", "Print", "[SENSITIVE] Print Cash Disbursement", "", "", "", "")

                .ShowPreview()
            End With
        Else
            Dim Report As New RptCashReceipt
            With Report
                .Name = String.Format("Check Disbursements of {0}", If(cbxAllB.Checked, "All Branches", cbxBranch.Text))
                .lblTitle.Text = "Check Disbursements"
                .lblAsOf.Text = If(dtpFrom.Value = dtpTo.Value Or cbxAll.Checked, "", "From " & dtpFrom.Text & " To " & dtpTo.Text)

                .XrLabel1.Text = "Clearing Status"
                .XrLabel4.Text = "Date Cleared"
                .XrLabel9.Text = "Check Number"
                .DataSource = GridControl1.DataSource
                .lblEntryStatus.DataBindings.Add("Text", GridControl1.DataSource, "Entry Status")
                .lblDepositStatus.DataBindings.Add("Text", GridControl1.DataSource, "Clearing Status")
                .lblTransactionType.DataBindings.Add("Text", GridControl1.DataSource, "Transaction Type")
                .lblDocumentDate.DataBindings.Add("Text", GridControl1.DataSource, "Document Date")
                .lblDateDeposited.DataBindings.Add("Text", GridControl1.DataSource, "Date Cleared")
                .lblPostingDate.DataBindings.Add("Text", GridControl1.DataSource, "Posting Date")
                .lblPayor.DataBindings.Add("Text", GridControl1.DataSource, "Payee")
                .lblAccountNumber.DataBindings.Add("Text", GridControl1.DataSource, "Account Number")
                .lblDocumentNumber.DataBindings.Add("Text", GridControl1.DataSource, "Document Number")
                .lblPayment.DataBindings.Add("Text", GridControl1.DataSource, "Check Number")
                .lblMotherAccount.DataBindings.Add("Text", GridControl1.DataSource, "Mother Account")
                .lblAccountCode.DataBindings.Add("Text", GridControl1.DataSource, "Account Code")
                .lblDepartment.DataBindings.Add("Text", GridControl1.DataSource, "Department")
                .lblDebit.DataBindings.Add("Text", GridControl1.DataSource, "Debit")
                .lblCredit.DataBindings.Add("Text", GridControl1.DataSource, "Credit")
                .lblRemarks.DataBindings.Add("Text", GridControl1.DataSource, "Remarks")

                Dim DebitT As Double
                Dim CreditT As Double
                For x As Integer = 0 To GridView1.RowCount - 1
                    DebitT += GridView1.GetRowCellValue(x, "Debit")
                    CreditT += GridView1.GetRowCellValue(x, "Credit")
                Next
                .lblDebitT.Text = FormatNumber(DebitT, 2)
                .lblCreditT.Text = FormatNumber(CreditT, 2)
                Logs("Cash Disbursement", "Print", "[SENSITIVE] Print Cash Disbursement", "", "", "", "")

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

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
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
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
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
        StandardPrinting("CHECK DISBURSEMENTS", GridControl1)
        Logs("Cash Disbursement", "Print", "[SENSITIVE] Print Cash Disbursement", "", "", "", "")
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

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView1_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Document Number").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("Document Number").ToString.Contains("CV-") Then
            Dim CV As New FrmCheckVoucher
            With CV
                .Tag = 80
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Logs("Check Disbursement", "Double Click", "Check Voucher", "", "", "", "")
                .From_GeneralLedger = True
                .AccountNumber = GridView1.GetFocusedRowCellValue("Document Number")
                .Skip_FilterLoadData = True
                If .ShowDialog = DialogResult.OK Then
                    LoadData()
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        If cbxAllB.Checked Then
            MsgBox("All branch are selected, please select 1 branch to use for migration.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxAllBank.Checked Then
            MsgBox("All banks are selected, please select 1 bank to use for migration.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            MsgBox("Please select a branch to use to migrate.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If cbxBank.SelectedIndex = -1 Or cbxBank.Text = "" Then
            MsgBox("Please select a bank to use to migrate.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxBranch.SelectedItem, DataRowView)
        'MsgBox(String.Format("Branch {0} and Bank {1} is selected for migration.", cbxBranch.Text, cbxBank.Text), MsgBoxStyle.Information, "Info")
        Dim Import As New FrmBooksCD
        With Import
            .BankID = cbxBank.SelectedValue
            .xBranchID = cbxBranch.SelectedValue
            .xBranchCode = drv("branch_code")
            If .ShowDialog = DialogResult.OK Then
                btnSearch.PerformClick()
            End If
            .Dispose()
        End With
    End Sub
End Class