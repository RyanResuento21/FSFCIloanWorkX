Public Class FrmSubsidiaryLedger

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Dim Code As String
    Dim Old_Code As String
    Private Sub FrmSubsidiaryLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0

        If User_Type = "ADMIN" Then
            btnDelete.Visible = True
        End If

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

        With cbxBook
            .ValueMember = "ID"
            .DisplayMember = "Bank"
            FirstLoad = False
            .DataSource = DataSource("SELECT 1 AS 'ID', 'Bank 1' AS 'Bank' UNION ALL SELECT 2 AS 'ID', 'Bank 2' AS 'Bank';")
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX1, LabelX4, LabelX47, LabelX49, LabelX48})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank, cbxAll})

            GetCheckBoxFontSettingsDefaultColor({cbxForValidation, cbxClosed})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnLedger, btnLedgerCard, btnCancel, btnPrint, btnDelete})

            GetContextMenuBarFontSettings({ContextMenuBar3})
        Catch ex As Exception
            TriggerBugReport("Subsidiary Ledger - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Subsidiary Ledger", lblTitle.Text)
    End Sub

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "  C.ID,"
        SQL &= "  C.CreditNumber AS 'Credit Number',"
        SQL &= "  AccountNumber AS 'Account Number',"
        SQL &= "  DATE_FORMAT(PN,'%b %d, %Y') AS 'PN Date',"
        SQL &= "  IF(AssumptionCredit = '',CONCAT(IF(FirstN_B = '','',CONCAT(FirstN_B, ' ')), IF(MiddleN_B = '','',CONCAT(MiddleN_B, ' ')), IF(LastN_B = '','',CONCAT(LastN_B, ' ')), Suffix_B),(SELECT CONCAT(IF(C.FirstN_B = '','',CONCAT(C.FirstN_B, ' ')), IF(C.MiddleN_B = '','',CONCAT(C.MiddleN_B, ' ')), IF(C.LastN_B = '','',CONCAT(C.LastN_B, ' ')), C.Suffix_B ,' Assumed By ',IF(B.FirstN_B = '','',CONCAT(B.FirstN_B, ' ')), IF(B.MiddleN_B = '','',CONCAT(B.MiddleN_B, ' ')), IF(B.LastN_B = '','',CONCAT(B.LastN_B, ' ')), B.Suffix_B) FROM credit_application B WHERE B.CreditNumber = C.AssumptionCredit)) AS 'Borrower',"
        SQL &= "  C.Product AS 'Product',"
        SQL &= "  C.AmountApplied AS 'Principal',"
        SQL &= "  C.Terms AS 'Terms',"
        SQL &= "  DAY(FDD) AS 'Due',"
        If CompanyMode = 0 Then
            SQL &= "  interest + AmountApplied AS 'Face Amount', "
        Else
            SQL &= "  C.Face_Amount AS 'Face Amount', "
        End If
        SQL &= "  GREATEST(IFNULL(A.Amount,0),0) AS 'Interest Income - Past Due',"
        SQL &= "  C.Attach, IFNULL((SELECT MIN(BankID) FROM check_received WHERE check_type = 'P' AND `status` = 'ACTIVE' AND check_received.AssetNumber = C.CreditNumber),0) AS 'BankID',"
        SQL &= "  C.branch_id, IF((Loan_Type = 'MIGRATED' OR Loan_Type = 'RESTRUCTURE') AND MigratedValidation = 0,'FOR VALIDATION',C.PaymentRequest) AS 'PaymentRequest', PromiseDate, PromiseAmount, PromiseRemarks, PromiseStatus"
        SQL &= "  FROM credit_application C "
        If CompanyMode = 0 Then
            SQL &= "  LEFT JOIN (SELECT IFNULL(SUM(IF(EntryType = 'CREDIT',Amount,0 - Amount)),0) AS 'Amount', ReferenceN FROM accounting_entry WHERE PaidFor IN ('RPPD') AND `status` = 'ACTIVE' GROUP BY ReferenceN) A ON A.ReferenceN = C.CreditNumber"
        Else
            SQL &= "  LEFT JOIN (SELECT IFNULL(SUM(IF(EntryType = 'CREDIT',Amount,0 - Amount)),0) AS 'Amount', ReferenceN FROM accounting_entry WHERE PaidFor IN ('RPPD', 'Penalty') AND `status` = 'ACTIVE' GROUP BY ReferenceN) A ON A.ReferenceN = C.CreditNumber"
        End If
        SQL &= String.Format("  WHERE C.`status` = 'ACTIVE' AND C.`PaymentRequest` IN ('REQUESTED','CHECKED REQUEST','APPROVED REQUEST','RELEASED','CLOSED') AND IF({0} = 1,Branch_ID IN ({3}) OR IF(Product LIKE '%FSFC%' AND Employer_B_ID = '{1}',TRUE,FALSE),Branch_ID = '{1}' OR IF(Product LIKE '%FSFC%' AND Employer_B_ID = '{1}',TRUE,FALSE)) AND IF('{2}' = '0',TRUE,BusinessCenterCode(BusinessID) = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'))", cbxAllB.Checked, cbxBranch.SelectedValue, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        If cbxAll.Checked Then
        Else
            SQL &= String.Format("    AND DATE(PN) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        If cbxClosed.Checked Then
        Else
            SQL &= " AND C.PaymentRequest != 'CLOSED'"
        End If
        If cbxForValidation.Checked Then
        Else
            SQL &= " AND IF(Loan_Type = 'MIGRATED' OR Loan_Type = 'RESTRUCTURE', MigratedValidation = 1,TRUE)"
        End If
        SQL &= "  ORDER BY AccountNumber DESC;"

        GridControl1.DataSource = DataSource(SQL)
        With GridView1
            .Columns("Borrower").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            .Columns("Borrower").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
            .Columns("Principal").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Principal").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Interest Income - Past Due").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Interest Income - Past Due").SummaryItem.DisplayFormat = "{0:n2}"
            .Columns("Face Amount").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            .Columns("Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
        End With

        If GridView1.RowCount > 20 Then
            GridColumn5.Width = 291 - 17
        Else
            GridColumn5.Width = 291
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView_SelectionChanged(sender As Object, e As DevExpress.Data.SelectionChangedEventArgs) Handles GridView1.SelectionChanged
        Dim Rows As New ArrayList()
        Dim selectedRowHandles As Integer() = GridView1.GetSelectedRows()
        If selectedRowHandles.Length > 1 Then
            Dim Total_1 As Double
            Dim Total_2 As Double
            Dim Total_3 As Double
            With GridView1
                For x As Integer = 0 To selectedRowHandles.Length - 1
                    Dim selectedRowHandle As Integer = selectedRowHandles(x)
                    Total_1 += .GetRowCellValue(selectedRowHandle, "Principal")
                    Total_2 += .GetRowCellValue(selectedRowHandle, "Interest Income - Past Due")
                    Total_3 += .GetRowCellValue(selectedRowHandle, "Face Amount")
                Next
                .Columns("Principal").SummaryItem.DisplayFormat = FormatNumber(Total_1, 2)
                .Columns("Interest Income - Past Due").SummaryItem.DisplayFormat = FormatNumber(Total_2, 2)
                .Columns("Face Amount").SummaryItem.DisplayFormat = FormatNumber(Total_3, 2)
            End With
        Else
            With GridView1
                .Columns("Principal").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Interest Income - Past Due").SummaryItem.DisplayFormat = "{0:n2}"
                .Columns("Face Amount").SummaryItem.DisplayFormat = "{0:n2}"
            End With
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

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
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
        GridView1.OptionsPrint.UsePrintStyles = False

        StandardPrinting("SUBSIDIARY LEDGER LIST", GridControl1)
        Logs("Subsidiary Ledger", "Print", "[SENSITIVE] Print Subsidiary Ledger List", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

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

    Private Sub BtnPayment_Click(sender As Object, e As EventArgs) Handles btnLedger.Click
        Try
            If GridView1.GetFocusedRowCellValue("Credit Number").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.RowCount > 0 Then
            Dim Ledger As New FrmAccountLedger
            With Ledger
                .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Public Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnLedger.PerformClick()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("PaymentRequest"))
            If Status = "" Then
            Else
                Try
                    If Status = "CLOSED" Then
                        e.Appearance.ForeColor = Color.SeaGreen
                    ElseIf Status = "FOR VALIDATION" Then
                        e.Appearance.ForeColor = Color.IndianRed
                    End If
                Catch ex As Exception
                    TriggerBugReport("Subsidiary Ledger - GridView1 RowCellStyle", ex.Message.ToString)
                End Try
            End If
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Try
            If GridView1.GetFocusedRowCellValue("Credit Number").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("PaymentRequest") = "CLOSED" Then
            MsgBox("Account is already closed. Transactions cannot be deleted.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        Dim Msg As String = "Are you sure you want to DELETE the transactions within this account? This will send an Email or SMS to authorized personnel and please wait for their code."
        If Code = Old_Code Then
            Msg = "Would you like to enter the code now?"
        ElseIf Old_Code = "" Then
            Msg = "Are you sure you want to DELETE the transactions within this account? This will send an Email or SMS to authorized personnel and please wait for their code."
        Else
            Msg = "Are you sure you want to DELETE the transactions within this account? This will send a NEW Email or SMS to authorized personnel and please wait for their code."
        End If
        If MsgBoxYes(Msg) = MsgBoxResult.Yes Then

            If Code = "" Then
                Code = GenerateOTAC()
            End If
            If Code = Old_Code Then
            Else
                Code = GenerateOTAC()
                Old_Code = Code

                Cursor = Cursors.WaitCursor

                Dim Subject As String = "One Time Authorization Code " & Code
                Dim Body As String = String.Format("Good day {0}," & vbCrLf, UpperCaseFirst(Empl_Name))
                Body &= String.Format(" One Time Authorization Code is <b>{0}</b> for deleting the transactions of credit number {1}.", Code, GridView1.GetFocusedRowCellValue("Credit Number"))
                SendEmail(Empl_Email, Subject, Body, False, False, False, 0, "", "")

                Cursor = Cursors.Default
            End If

            Timer1.Start()
            Dim OTP As New FrmOneTimePassword
            With OTP
                .OTP = Code
                If .ShowDialog = DialogResult.OK Then
                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = String.Format("UPDATE check_received SET `status` = 'ACTIVE', Remarks = '' WHERE AssetNumber = '{0}' AND `status` IN ('CLEARED','PAID','PARTIAL','BOUNCED');", GridView1.GetFocusedRowCellValue("Credit Number"))
                    'Accounting Entry
                    SQL &= String.Format("UPDATE accounting_entry SET `status` = 'DELETED' WHERE ReferenceN = '{0}';", GridView1.GetFocusedRowCellValue("Credit Number"))

                    DataObject(SQL)
                    Cursor = Cursors.Default
                    MsgBox("Successfully Cancelled!", MsgBoxStyle.Information, "Info")
                    Logs("Credit Payment", "Cancel", String.Format("Cancel all the transactions with Credit Number {0}.", GridView1.GetFocusedRowCellValue("Credit Number")), "", "", "", GridView1.GetFocusedRowCellValue("Credit Number"))
                End If
            End With
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Generate Code **************

        Code = GenerateOTAC()
        Timer1.Stop()
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

    Private Sub IPromise_Click(sender As Object, e As EventArgs) Handles iPromise.Click
        Dim Promise As New FrmPromiseToPay
        With Promise
            .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
            .BorrowerName = GridView1.GetFocusedRowCellValue("Borrower")
            If GridView1.GetFocusedRowCellValue("PromiseStatus") = "PENDING" Then
                .DatePromise = GridView1.GetFocusedRowCellValue("PromiseDate")
                .dAmount.Value = GridView1.GetFocusedRowCellValue("PromiseAmount")
                .rPromise.Text = GridView1.GetFocusedRowCellValue("PromiseRemarks")
            End If
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnLedger.PerformClick()
        End If
    End Sub

    Private Sub IAccountLedger_Click(sender As Object, e As EventArgs) Handles iAccountLedger.Click
        btnLedger.PerformClick()
    End Sub

    Private Sub ILedgerCard_Click(sender As Object, e As EventArgs) Handles iLedgerCard.Click
        btnLedgerCard.PerformClick()
    End Sub

    Private Sub BtnLedgerCard_Click(sender As Object, e As EventArgs) Handles btnLedgerCard.Click
        Try
            If GridView1.GetFocusedRowCellValue("Credit Number").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.RowCount > 0 Then
            Dim Ledger As New FrmLedgerCard
            With Ledger
                .CreditNumber = GridView1.GetFocusedRowCellValue("Credit Number")
                .AccountNumber = GridView1.GetFocusedRowCellValue("Account Number")
                .Product = GridView1.GetFocusedRowCellValue("Product")
                .Borrower = GridView1.GetFocusedRowCellValue("Borrower")
                .vPrint = vPrint
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub
End Class