Public Class FrmAccountsReceivableReport

    Public vPrint As Boolean
    Dim DT_ARSummary As DataTable
    Dim DT_ARAging As DataTable

    Dim FirstLoad As Boolean = True
    Private Sub FrmAccountsReceivable_Report_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetBandedGridApperance({BandedGridView1, BandedGridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpPeriod.Value = Date.Now

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

        DT_ARSummary = DataSource("SELECT '' AS 'ID', '' AS 'Payee', 0.0 AS 'Outstanding', '' AS 'Last Payment', '' AS 'Remarks' LIMIT 0")

        DT_ARAging = DataSource("SELECT '' AS 'ID', '' AS 'Payee', '' AS 'Date', '' AS 'AccountNumber', '' AS 'Reference Number', '' AS 'Particulars', '' AS 'Bank 1', 0.0 AS 'Amount', 0.0 AS 'Current 1-90Days', 0.0 AS 'Over 90Days-1Year', 0.0 AS 'Over 1Year', '' AS 'Last Payment', '' AS 'Remarks' LIMIT 0")

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

            GetLabelFontSettings({LabelX1, LabelX2, LabelX42})

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank})

            GetComboBoxFontSettings({cbxBranch, cbxBook, cbxBank})

            GetDateTimeInputFontSettings({dtpPeriod})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnPrintCustomized})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Accounts Receivable Report - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Accounts Receivable Report", lblTitle.Text)
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
        Else
            cbxBranch.Enabled = True
            cbxBranch.SelectedValue = Branch_ID
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadARSummary()
        LoadARAging()
    End Sub

    Private Sub BandedGridView2_KeyDown(sender As Object, e As KeyEventArgs) Handles BandedGridView2.KeyDown
        If e.KeyCode = Keys.Enter Then
            LabelX1.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT CollectionRemarks FROM accounts_receivable WHERE ID = '{0}';", BandedGridView2.GetFocusedRowCellValue("ID")))
            If BandedGridView2.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks for this accounts receivable from '{1}' to '{0}'?", BandedGridView2.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE accounts_receivable SET CollectionRemarks = '{1}' WHERE ID = '{0}';", BandedGridView2.GetFocusedRowCellValue("ID"), BandedGridView2.GetFocusedRowCellValue("Remarks")))
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Sub BandedGridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles BandedGridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            LabelX1.Focus()
            Dim Old_Remarks As String = DataObject(String.Format("SELECT CollectionRemarks FROM accounts_receivable WHERE ID = '{0}';", BandedGridView1.GetFocusedRowCellValue("ID")))
            If BandedGridView1.GetFocusedRowCellValue("Remarks") <> Old_Remarks Then
                If MsgBoxYes(String.Format("Are you sure you want to update the remarks for this accounts receivable from '{1}' to '{0}'?", BandedGridView1.GetFocusedRowCellValue("Remarks"), Old_Remarks)) = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE accounts_receivable SET CollectionRemarks = '{1}' WHERE ID = '{0}';", BandedGridView1.GetFocusedRowCellValue("ID"), BandedGridView1.GetFocusedRowCellValue("Remarks")))
                    MsgBox("Remarks Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Sub LoadARSummary()
        Cursor = Cursors.WaitCursor
        Dim DT_Temp As DataTable
        Dim SQL As String
        Dim Amount_1 As Double
        Dim Amount_2 As Double
        Dim Amount_3 As Double
        Dim Amount_4 As Double
        Dim Amount_5 As Double
        Dim Amount_6 As Double
        With DT_ARSummary
            .Rows.Clear()
            SQL = "SELECT "
            SQL &= "    ID, Payor_Type, Payor AS 'Payee',"
            SQL &= "    Amount - Paid AS 'Amount',"
            SQL &= "    IF(Payor_Type = 'LA',IFNULL((SELECT `code` FROM product_setup WHERE ID = (SELECT Product_ID FROM credit_application WHERE CreditNumber = PayorID)),''),'') AS 'Product Code',"
            SQL &= "    IFNULL((SELECT DATE_FORMAT(PostingDate, '%m/%d/%Y') FROM acknowledgement_receipt WHERE Payee LIKE CONCAT('%', accounts_receivable.DocumentNumber ,'%') AND `status` = 'ACTIVE' ORDER BY PostingDate DESC LIMIT 1),'') AS 'Last Payment', CollectionRemarks AS 'Remarks'"
            SQL &= String.Format(" FROM accounts_receivable WHERE `status` = 'ACTIVE' AND AR_Status IN ('APPROVED','PENDING','CHECKED','PARTIALLY PAID') AND NotAR = 0  AND MONTH(PostingDate) <= MONTH('{0}') AND YEAR(PostingDate) <= YEAR('{0}') AND IF({1} = 1,Branch_ID IN ({3}),Branch_ID = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'))", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
            DT_Temp = DataSource(SQL)
            .Rows.Add(0, "I. CLIENTS")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "LA" And DT_Temp(x)("Product Code") <> "203-01" Then
                    Amount_1 += If(DT_Temp(x)("Amount").ToString = "", 0, CDbl(DT_Temp(x)("Amount")))
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Amount"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", Amount_1, "")
            .Rows.Add(0)
            .Rows.Add(0, "II. EMPLOYEES")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "LA" And DT_Temp(x)("Product Code") = "203-01" Then
                    Amount_2 += If(DT_Temp(x)("Amount").ToString = "", 0, CDbl(DT_Temp(x)("Amount")))
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Amount"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", Amount_2, "")
            .Rows.Add(0)
            .Rows.Add(0, "III. SISTER COMPANIES")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "SC" Then
                    Amount_3 += If(DT_Temp(x)("Amount").ToString = "", 0, CDbl(DT_Temp(x)("Amount")))
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Amount"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", Amount_3, "")
            .Rows.Add(0)
            .Rows.Add(0, "IV. INTER-BRANCHES")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "B" Then
                    Amount_4 += If(DT_Temp(x)("Amount").ToString = "", 0, CDbl(DT_Temp(x)("Amount")))
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Amount"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", Amount_4, "")
            .Rows.Add(0)
            .Rows.Add(0, "V. ROPOA")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "ROPOA" Then
                    Amount_5 += If(DT_Temp(x)("Amount").ToString = "", 0, CDbl(DT_Temp(x)("Amount")))
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Amount"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", Amount_5, "")
            .Rows.Add(0)
            .Rows.Add(0, "VI. OTHERS")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") <> "B" And DT_Temp(x)("Payor_Type") <> "LA" And DT_Temp(x)("Payor_Type") <> "ROPOA" And DT_Temp(x)("Payor_Type") <> "SC" Then
                    Amount_6 += If(DT_Temp(x)("Amount").ToString = "", 0, CDbl(DT_Temp(x)("Amount")))
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Amount"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", Amount_6, "")
            .Rows.Add(0)
            .Rows.Add(-1, "GRAND TOTAL", Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6, "")
        End With
        GridControl1.DataSource = DT_ARSummary
        Cursor = Cursors.Default
    End Sub

    Private Sub LoadARAging()
        Cursor = Cursors.WaitCursor
        Dim DT_Temp As DataTable
        Dim SQL As String
        Dim Amount_1 As Double
        Dim Current_1 As Double
        Dim Above90_1 As Double
        Dim Above365_1 As Double
        Dim Amount_2 As Double
        Dim Current_2 As Double
        Dim Above90_2 As Double
        Dim Above365_2 As Double
        Dim Amount_3 As Double
        Dim Current_3 As Double
        Dim Above90_3 As Double
        Dim Above365_3 As Double
        Dim Amount_4 As Double
        Dim Current_4 As Double
        Dim Above90_4 As Double
        Dim Above365_4 As Double
        Dim Amount_5 As Double
        Dim Current_5 As Double
        Dim Above90_5 As Double
        Dim Above365_5 As Double
        Dim Amount_6 As Double
        Dim Current_6 As Double
        Dim Above90_6 As Double
        Dim Above365_6 As Double
        With DT_ARAging
            .Rows.Clear()
            SQL = "SELECT "
            SQL &= "    ID, Payor_Type, Payor AS 'Payee',"
            SQL &= "    DATE_FORMAT(PostingDate, '%m/%d/%Y') AS 'Date',"
            SQL &= "    IF(Payor_Type = 'LA',AccountNumber (PayorID),'') AS 'AccountNumber',"
            SQL &= "    IF(Payor_Type = 'LA',IFNULL((SELECT `code` FROM product_setup WHERE ID = (SELECT Product_ID FROM credit_application WHERE CreditNumber = PayorID)),''),'') AS 'Product Code',"
            SQL &= "    ReferenceNumber AS 'Reference Number',"
            SQL &= "    Explanation AS 'Particulars',"
            SQL &= "    '' AS 'Bank 1',"
            SQL &= "    IFNULL(Amount - Paid,0) AS 'Amount',"
            SQL &= "    IF(DATEDIFF(DATE(NOW()), PostingDate) <= 90,IFNULL(Amount - Paid,0),0) AS 'Current 1-90Days',"
            SQL &= "    IF(DATEDIFF(DATE(NOW()), PostingDate) BETWEEN 91 AND 365,IFNULL(Amount - Paid,0),0) AS 'Over 90Days-1Year',"
            SQL &= "    IF(DATEDIFF(DATE(NOW()), PostingDate) > 365,IFNULL(Amount - Paid,0),0) AS 'Over 1Year',"
            SQL &= "    IFNULL((SELECT DATE_FORMAT(PostingDate, '%m/%d/%Y') FROM acknowledgement_receipt WHERE Payee LIKE CONCAT('%', accounts_receivable.DocumentNumber ,'%') AND `status` = 'ACTIVE' ORDER BY PostingDate DESC LIMIT 1),'') AS 'Last Payment',"
            SQL &= "    CollectionRemarks AS 'Remarks'"
            SQL &= String.Format(" FROM accounts_receivable WHERE `status` = 'ACTIVE' AND AR_Status IN ('APPROVED','PENDING','CHECKED','PARTIALLY PAID') AND NotAR = 0  AND MONTH(PostingDate) <= MONTH('{0}') AND YEAR(PostingDate) <= YEAR('{0}') AND IF({1} = 1,Branch_ID IN ({3}),Branch_ID = '{2}') AND IF('{4}' = 'True',TRUE,IF('{5}' = 0,Book(BankID) = '{6}',BankID = '{5}'))", Format(dtpPeriod.Value, "yyyy-MM-dd"), cbxAllB.Checked, cbxBranch.SelectedValue, Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
            DT_Temp = DataSource(SQL)
            .Rows.Add(0, "I. CLIENTS")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "LA" And DT_Temp(x)("Product Code") <> "203-01" Then
                    Amount_1 += DT_Temp(x)("Amount")
                    Current_1 += DT_Temp(x)("Current 1-90Days")
                    Above90_1 += DT_Temp(x)("Over 90Days-1Year")
                    Above365_1 += DT_Temp(x)("Over 1Year")
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Date"), DT_Temp(x)("AccountNumber"), DT_Temp(x)("Reference Number"), DT_Temp(x)("Particulars"), DT_Temp(x)("Bank 1"), DT_Temp(x)("Amount"), DT_Temp(x)("Current 1-90Days"), DT_Temp(x)("Over 90Days-1Year"), DT_Temp(x)("Over 1Year"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", "", "", "", "", "", Amount_1, Current_1, Above90_1, Above365_1, "", "")
            .Rows.Add(0)
            .Rows.Add(0, "II. EMPLOYEES")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "LA" And DT_Temp(x)("Product Code") = "203-01" Then
                    Amount_2 += DT_Temp(x)("Amount")
                    Current_2 += DT_Temp(x)("Current 1-90Days")
                    Above90_2 += DT_Temp(x)("Over 90Days-1Year")
                    Above365_2 += DT_Temp(x)("Over 1Year")
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Date"), DT_Temp(x)("AccountNumber"), DT_Temp(x)("Reference Number"), DT_Temp(x)("Particulars"), DT_Temp(x)("Bank 1"), DT_Temp(x)("Amount"), DT_Temp(x)("Current 1-90Days"), DT_Temp(x)("Over 90Days-1Year"), DT_Temp(x)("Over 1Year"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", "", "", "", "", "", Amount_2, Current_2, Above90_2, Above365_2, "", "")
            .Rows.Add(0)
            .Rows.Add(0, "III. SISTER COMPANIES")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "SC" Then
                    Amount_3 += DT_Temp(x)("Amount")
                    Current_3 += DT_Temp(x)("Current 1-90Days")
                    Above90_3 += DT_Temp(x)("Over 90Days-1Year")
                    Above365_3 += DT_Temp(x)("Over 1Year")
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Date"), DT_Temp(x)("AccountNumber"), DT_Temp(x)("Reference Number"), DT_Temp(x)("Particulars"), DT_Temp(x)("Bank 1"), DT_Temp(x)("Amount"), DT_Temp(x)("Current 1-90Days"), DT_Temp(x)("Over 90Days-1Year"), DT_Temp(x)("Over 1Year"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", "", "", "", "", "", Amount_3, Current_3, Above90_3, Above365_3, "", "")
            .Rows.Add(0)
            .Rows.Add(0, "IV. INTER-BRANCHES")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "B" Then
                    Amount_4 += DT_Temp(x)("Amount")
                    Current_4 += DT_Temp(x)("Current 1-90Days")
                    Above90_4 += DT_Temp(x)("Over 90Days-1Year")
                    Above365_4 += DT_Temp(x)("Over 1Year")
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Date"), DT_Temp(x)("AccountNumber"), DT_Temp(x)("Reference Number"), DT_Temp(x)("Particulars"), DT_Temp(x)("Bank 1"), DT_Temp(x)("Amount"), DT_Temp(x)("Current 1-90Days"), DT_Temp(x)("Over 90Days-1Year"), DT_Temp(x)("Over 1Year"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", "", "", "", "", "", Amount_4, Current_4, Above90_4, Above365_4, "", "")
            .Rows.Add(0)
            .Rows.Add(0, "V. ROPOA")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") = "ROPOA" Then
                    Amount_5 += DT_Temp(x)("Amount")
                    Current_5 += DT_Temp(x)("Current 1-90Days")
                    Above90_5 += DT_Temp(x)("Over 90Days-1Year")
                    Above365_5 += DT_Temp(x)("Over 1Year")
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Date"), DT_Temp(x)("AccountNumber"), DT_Temp(x)("Reference Number"), DT_Temp(x)("Particulars"), DT_Temp(x)("Bank 1"), DT_Temp(x)("Amount"), DT_Temp(x)("Current 1-90Days"), DT_Temp(x)("Over 90Days-1Year"), DT_Temp(x)("Over 1Year"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", "", "", "", "", "", Amount_5, Current_5, Above90_5, Above365_5, "", "")
            .Rows.Add(0)
            .Rows.Add(0, "VI. OTHERS")
            For x As Integer = 0 To DT_Temp.Rows.Count - 1
                If DT_Temp(x)("Payor_Type") <> "B" And DT_Temp(x)("Payor_Type") <> "LA" And DT_Temp(x)("Payor_Type") <> "ROPOA" And DT_Temp(x)("Payor_Type") <> "SC" Then
                    Amount_6 += DT_Temp(x)("Amount")
                    Current_6 += DT_Temp(x)("Current 1-90Days")
                    Above90_6 += +DT_Temp(x)("Over 90Days-1Year")
                    Above365_6 += DT_Temp(x)("Over 1Year")
                    .Rows.Add(DT_Temp(x)("ID"), DT_Temp(x)("Payee"), DT_Temp(x)("Date"), DT_Temp(x)("AccountNumber"), DT_Temp(x)("Reference Number"), DT_Temp(x)("Particulars"), DT_Temp(x)("Bank 1"), DT_Temp(x)("Amount"), DT_Temp(x)("Current 1-90Days"), DT_Temp(x)("Over 90Days-1Year"), DT_Temp(x)("Over 1Year"), DT_Temp(x)("Last Payment"), DT_Temp(x)("Remarks"))
                End If
            Next
            .Rows.Add(0, "", "", "", "", "", "", Amount_6, Current_6, Above90_6, Above365_6, "", "")
            .Rows.Add(0)
            .Rows.Add(-1, "GRAND TOTAL", "", "", "", "", "", Amount_1 + Amount_2 + Amount_3 + Amount_4 + Amount_5 + Amount_6, Current_1 + Current_2 + Current_3 + Current_4 + Current_5 + Current_6, Above90_1 + Above90_2 + Above90_3 + Above90_4 + Above90_5 + Above90_6, Above365_1 + Above365_2 + Above365_3 + Above365_4 + Above365_5 + Above365_6, "", "")
        End With
        GridControl2.DataSource = DT_ARAging
        Cursor = Cursors.Default
    End Sub

    Private Sub BandedGridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridView1.RowCellStyle
        If BandedGridView1.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("ID"))
                If ForBold > 0 Then
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Regular)
                Else
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Bold)
                    If ForBold = -1 Then
                        e.Appearance.ForeColor = OfficialColor2 'Color.Red
                        e.Appearance.BackColor = Color.Yellow
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BandedGridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles BandedGridView2.RowCellStyle
        If BandedGridView2.RowCount > 0 Then
            Try
                Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
                Dim ForBold As Integer = View.GetRowCellValue(e.RowHandle, View.Columns("ID"))
                If ForBold > 0 Then
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Regular)
                Else
                    e.Appearance.Font = New Font(OfficialFont, 6.75, FontStyle.Bold)
                    If ForBold = -1 Then
                        e.Appearance.ForeColor = OfficialColor2 'Color.Red
                        e.Appearance.BackColor = Color.Yellow
                    End If
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub BtnPrintCustomized_Click(sender As Object, e As EventArgs) Handles btnPrintCustomized.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            BandedGridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("AR Summary", GridControl1)
            Logs("Accounts Receivable Report", "Print", "[SENSITIVE] Print AR Summary", "", "", "", "")
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            BandedGridView2.OptionsPrint.UsePrintStyles = False
            StandardPrinting("AR Aging", GridControl2)
            Logs("Accounts Receivable Report", "Print", "[SENSITIVE] Print AR Aging", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub
End Class