Imports DevExpress.XtraReports.UI
Public Class FrmGeneralLedgerAccountDetails

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Public AccountCode As String
    Public DepartmentCode As String
    Public From_TrialBalance As Boolean
    Public From_BalanceSheet As Boolean
    Public From_IncomeStatement As Boolean
    Dim cbxBranch As Integer
    Dim cbxBusinessCenter As String
    Dim cbxAllB As Boolean
    Dim cbxBook As Integer
    Dim cbxBank As Integer
    Dim cbxAllBank As Boolean
    Dim cbxDisplay As Integer
    Dim cbxAll As Boolean
    Dim dtpFrom As Date
    Dim dtpTo As Date

    Private Sub FrmGeneralLedger_Account_Details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        If From_TrialBalance Then
            With FrmTrialBalance
                cbxBranch = .cbxBranch.SelectedValue
                cbxBusinessCenter = ValidateComboBox(.cbxBusinessCenter)
                cbxAllB = .cbxAllB.Checked
                cbxBook = ValidateComboBox(.cbxBook)
                cbxBank = ValidateComboBox(.cbxBank)
                cbxAllBank = .cbxAllBank.Checked
                cbxDisplay = .cbxDisplay.SelectedIndex
                cbxAll = .cbxAll.Checked
                dtpFrom = .dtpFrom.Value
                dtpTo = .dtpTo.Value
            End With
        ElseIf From_BalanceSheet Then
            With FrmBalanceSheet
                cbxBranch = .cbxBranch.SelectedValue
                cbxBusinessCenter = ValidateComboBox(.cbxBusinessCenter)
                cbxAllB = .cbxAllB.Checked
                cbxBook = ValidateComboBox(.cbxBook)
                cbxBank = ValidateComboBox(.cbxBank)
                cbxAllBank = .cbxAllBank.Checked
                cbxDisplay = .cbxDisplay.SelectedIndex
                cbxAll = .cbxAll.Checked
                dtpFrom = .dtpFrom.Value
                dtpTo = .dtpTo.Value
            End With
        ElseIf From_IncomeStatement Then
            With FrmIncomeStatement
                cbxBranch = .cbxBranch.SelectedValue
                cbxBusinessCenter = ValidateComboBox(.cbxBusinessCenter)
                cbxAllB = .cbxAllB.Checked
                cbxBook = ValidateComboBox(.cbxBook)
                cbxBank = ValidateComboBox(.cbxBank)
                cbxAllBank = .cbxAllBank.Checked
                cbxDisplay = .cbxDisplay.SelectedIndex
                cbxAll = .cbxAll.Checked
                dtpFrom = .dtpFrom.Value
                dtpTo = .dtpTo.Value
            End With
        Else
            With FrmGeneralLedger
                cbxBranch = .cbxBranch.SelectedValue
                cbxBusinessCenter = ValidateComboBox(.cbxBusinessCenter)
                cbxAllB = .cbxAllB.Checked
                cbxBook = ValidateComboBox(.cbxBook)
                cbxBank = ValidateComboBox(.cbxBank)
                cbxAllBank = .cbxAllBank.Checked
                cbxDisplay = .cbxDisplay.SelectedIndex
                cbxAll = .cbxAll.Checked
                dtpFrom = .dtpFrom.Value
                dtpTo = .dtpTo.Value
            End With
        End If
        LoadData()

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

            GetButtonFontSettings({btnCancel, btnPrint})
        Catch ex As Exception
            TriggerBugReport("General Ledger Account Details - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("General Ledger - Account Details", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    DATE_FORMAT(ORDate, '%M %d, %Y') AS 'Posting Date',"
        SQL &= "    IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) AS 'Document Number',"
        SQL &= "    IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'JV',(SELECT Payee FROM journal_voucher WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'CV',(SELECT Payee FROM check_voucher WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'OR',(SELECT Payee FROM official_receipt WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,3) = 'ACR',(SELECT Payee FROM acknowledgement_receipt WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'AP',(SELECT Payee FROM accounts_Payable WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'AR',(SELECT Payor FROM accounts_receivable WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'DF',(SELECT Payor FROM due_from WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'DT',(SELECT Payee FROM due_to WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), '')))))))) AS 'Payee',"
        SQL &= "    IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'JV',(SELECT Explanation FROM journal_voucher WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'CV',(SELECT Explanation FROM check_voucher WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'OR',(SELECT Explanation FROM official_receipt WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,3) = 'ACR',(SELECT Explanation FROM acknowledgement_receipt WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'AP',(SELECT Explanation FROM accounts_Payable WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'AR',(SELECT Explanation FROM accounts_receivable WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'DF',(SELECT Explanation FROM due_from WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), IF(SUBSTRING(IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber),1,2) = 'DT',(SELECT Explanation FROM due_to WHERE DocumentNumber = IF(CVNumber = '',IF(ORNum = '', JVNum, ORNum),CVNumber) LIMIT 1), '')))))))) AS 'Explanation',"
        SQL &= "    Department (DepartmentCode) AS 'Department', Type_ID, ContraAccount,"
        SQL &= "    IF(EntryType = 'DEBIT', Amount, 0) AS 'Debit',"
        SQL &= "    IF(EntryType = 'CREDIT', Amount, 0) AS 'Credit',"
        SQL &= "    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND AccountCode = `Code` THEN Amount END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND AccountCode = `Code` THEN Amount END),0) AS 'Total',"
        SQL &= "    IF(Explanation(accounting_entry.ID) = '',Remarks,CONCAT(Explanation(accounting_entry.ID), IF(Remarks = '','',CONCAT(' | ' , Remarks)))) AS 'Remarks'"
        SQL &= " FROM accounting_entry INNER JOIN (SELECT `Code`, Type_ID, ContraAccount FROM account_chart) A ON A.Code = accounting_entry.AccountCode WHERE `status` = 'ACTIVE' "
        SQL &= "    AND PostStatus = 'POSTED' "
        SQL &= "    AND PaidFor NOT IN ('RPPD-A','Penalty-W','RPPD-W')"
        If DefaultBankID > 0 Then
            SQL &= String.Format(" AND BankID = '{0}'", DefaultBankID)
        End If
        SQL &= String.Format("    AND AccountCode = '{0}' ", AccountCode)
        If DepartmentCode = "" Then
        Else
            SQL &= String.Format("    AND DepartmentCode = '{0}' ", DepartmentCode)
        End If
        SQL &= String.Format("    AND IF({0} = 0,TRUE,BusinessCode = '{0}') ", cbxBusinessCenter)
        SQL &= String.Format("    AND IF({0} = 1,Branch_ID IN ({2}),Branch_ID = '{1}')", cbxAllB, cbxBranch, Multiple_ID)
        SQL &= String.Format("    AND IF({0} = True,TRUE,IF('{1}' = 0,Book(BankID) = '{2}',BankID = '{1}'))", cbxAllBank, cbxBank, cbxBook)
        SQL &= String.Format("    AND IF({2} = 1,TRUE,ORDate BETWEEN '{0}' AND '{1}') GROUP BY accounting_entry.ID ;", Format(If(cbxDisplay = 5, CDate("1/1/1753"), dtpFrom), "yyyy-MM-dd"), Format(If(cbxDisplay = 5, dtpFrom, dtpTo), "yyyy-MM-dd"), cbxAll)

        Dim DT As DataTable = DataSource(SQL)
        Dim Debit_Total As Double
        Dim Credit_Total As Double
        Dim Total As Double
        For x As Integer = 0 To DT.Rows.Count - 1
            Debit_Total += CDbl(DT(x)("Debit"))
            Credit_Total += CDbl(DT(x)("Credit"))
            Total += CDbl(DT(x)("Total"))
        Next
        DT.Rows.Add("T O T A L", "", "", "", "", 0, 0, Debit_Total, Credit_Total, Total, "")

        GridControl1.DataSource = DT
        If GridView1.RowCount > 11 Then
            GridColumn7.Width = 150 - 17
        Else
            GridColumn7.Width = 150
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Classification As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Posting Date"))
            If Classification = "T O T A L" Then
                e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
            End If
        End If
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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptGeneralLedgerAccountDetails
        With Report
            .Name = lblTitle.Text
            .lblAsOf.Text = If(dtpFrom = dtpTo Or cbxAll, "", "From " & Format(dtpFrom, "MMMM dd, yyyy") & " To " & Format(dtpTo, "MMMM dd, yyyy"))

            .DataSource = GridControl1.DataSource
            .lblDocument.DataBindings.Add("Text", GridControl1.DataSource, "Document Number")
            .lblPosting.DataBindings.Add("Text", GridControl1.DataSource, "Posting Date")
            .lblDepartment.DataBindings.Add("Text", GridControl1.DataSource, "Department")
            .lblDebit.DataBindings.Add("Text", GridControl1.DataSource, "Debit")
            .lblCredit.DataBindings.Add("Text", GridControl1.DataSource, "Credit")
            .lblRemarks.DataBindings.Add("Text", GridControl1.DataSource, "Remarks")
            Logs("General Ledger - Account Details", "Print", "[SENSITIVE] Print General Ledger - Account Details List", "", "", "", "")
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Document Number").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Transaction As New FrmGeneralLedgerTransaction
        With Transaction
            .vPrint = vPrint
            .lblDocumentNumber.Text = GridView1.GetFocusedRowCellValue("Document Number")
            .lblPostingDate.Text = GridView1.GetFocusedRowCellValue("Posting Date")
            .From_TrialBalance = From_TrialBalance
            .From_BalanceSheet = From_BalanceSheet
            .From_IncomeStatement = From_IncomeStatement
            .rRemarks.Text = GridView1.GetFocusedRowCellValue("Remarks")
            If .ShowDialog = DialogResult.OK Then
                .Dispose()
                btnCancel.DialogResult = DialogResult.OK
                btnCancel.PerformClick()
            End If
            .Dispose()
        End With
    End Sub
End Class