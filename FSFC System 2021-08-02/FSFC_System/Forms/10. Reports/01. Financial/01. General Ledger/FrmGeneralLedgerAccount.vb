Imports DevExpress.XtraReports.UI
Public Class FrmGeneralLedgerAccount

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Public Main_ID As Integer
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
    Private Sub FrmGeneralLedger_Account_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True

        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        If From_BalanceSheet Then
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

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX2, LabelX9, LabelX17, LabelX10, LabelX1})

            GetTextBoxFontSettings({txtType, txtClassification, txtGroup, txtAccountNumber, txtAccount})

            GetRickTextBoxFontSettings({rDescription})

            GetButtonFontSettings({btnCancel, btnPrint})
        Catch ex As Exception
            TriggerBugReport("General Ledger Account - FixUI", ex.Message.ToString)
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
        OpenFormHistory("General Ledger - Account", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    `Code`,"
        SQL &= "    Title,"
        SQL &= "    IF(Description = '' AND Main_ID > 0,(SELECT Description FROM account_chart C WHERE C.ID = account_chart.Main_ID),Description) AS 'Description',"
        SQL &= "    DepartmentCode AS 'Department Code', DepartmentCode, Type_ID, ContraAccount,"
        SQL &= "    IFNULL(SUM(CASE WHEN EntryType = 'DEBIT' AND AccountCode = `Code` THEN Amount END),0) AS 'Debit',"
        SQL &= "    IFNULL(SUM(CASE WHEN EntryType = 'CREDIT' AND AccountCode = `Code` THEN Amount END),0) AS 'Credit',"
        SQL &= "    IFNULL(SUM(CASE WHEN IF(AccountFormula(account_chart.type_ID,account_chart.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND AccountCode = `Code` THEN Amount END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(account_chart.type_ID,account_chart.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND AccountCode = `Code` THEN Amount END),0) AS 'Total', `Status`"
        SQL &= String.Format("    FROM account_chart LEFT JOIN (SELECT ID, EntryType, AccountCode, Amount, DepartmentCode FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF({2} = 1,TRUE,ORDate BETWEEN '{0}' AND '{1}') AND IF({3} = 1,Branch_ID IN ({12}),Branch_ID = '{4}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({6} > 0, BankID = '{6}',TRUE) AND IF('{7}' = '0',TRUE,BusinessCode = '{7}') AND IF({8} = True,TRUE,IF('{9}' = 0,Book(BankID) = '{10}',BankID = '{9}'))) A ON A.AccountCode = account_chart.`Code`  WHERE `status` IN ('ACTIVE','DEACTIVATE') AND IF({11} = True,MotherCode = '{5}',Main_ID = '{5}') GROUP BY account_chart.ID, A.DepartmentCode HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY `Code`;", Format(If(cbxDisplay = 5, CDate("1/1/1753"), dtpFrom), "yyyy-MM-dd"), Format(If(cbxDisplay = 5, dtpFrom, dtpTo), "yyyy-MM-dd"), cbxAll, cbxAllB, cbxBranch, Main_ID, DefaultBankID, cbxBusinessCenter, cbxAllBank, cbxBank, cbxBook, From_IncomeStatement, Multiple_ID)
        Dim DT As DataTable = DataSource(SQL)
        For D As Integer = 0 To DT.Rows.Count - 1
            If DT(D)("Code") = "320101" Then
                Dim SQLv2 As String = " SELECT Type_ID AS 'ID',"
                SQLv2 &= "    IFNULL(SUM(CASE WHEN EntryType = 'DEBIT' AND AccountCode = `Code` THEN Amount END),0) AS 'Debit',"
                SQLv2 &= "    IFNULL(SUM(CASE WHEN EntryType = 'CREDIT' AND AccountCode = `Code` THEN Amount END),0) AS 'Credit',"
                SQLv2 &= "    IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND AccountCode = `Code` THEN Amount END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(A.type_ID,A.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND AccountCode = `Code` THEN Amount END),0) AS 'Total'"
                SQLv2 &= " FROM account_chart A"
                SQLv2 &= String.Format(" LEFT JOIN (SELECT ID, EntryType, MotherCode AS 'AccountCode', Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF({2} = 1,TRUE,ORDate BETWEEN '{0}' AND '{1}') AND IF('{4}' = 'True',Branch_ID IN ({7}),Branch_ID = '{3}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({5} > 0, BankID = '{5}',TRUE) AND IF('{6}' = '0',TRUE,BusinessCode = '{6}') AND IF('{8}' = 'True',TRUE,IF('{9}' = 0,Book(BankID) = '{10}',BankID = '{9}'))) A2 ON A2.AccountCode = A.`Code`", Format(If(cbxDisplay = 5, CDate("1/1/1753"), dtpFrom), "yyyy-MM-dd"), Format(If(cbxDisplay = 5, dtpFrom, dtpTo), "yyyy-MM-dd"), cbxAll, cbxBranch, cbxAllB, DefaultBankID, cbxBusinessCenter, Multiple_ID, cbxAllBank, cbxBank, cbxBook)
                SQLv2 &= "    WHERE A.`status` = 'ACTIVE' AND A.Main_ID = 0 AND AdjunctAccount = 0 AND A.Type_ID > 3 GROUP BY A.type_ID ORDER BY A.Code;"
                Dim DT_IncomeStatement As DataTable = DataSource(SQLv2)
                Dim IS_Debit As Double
                Dim IS_Credit As Double
                Dim IS_Total As Double
                For x As Integer = 0 To DT_IncomeStatement.Rows.Count - 1
                    If DT_IncomeStatement(x)("ID") = 5 Then
                        IS_Debit -= CDbl(DT_IncomeStatement(x)("Debit"))
                        IS_Credit -= CDbl(DT_IncomeStatement(x)("Credit"))
                        IS_Total -= CDbl(DT_IncomeStatement(x)("Total"))
                    Else
                        IS_Debit += CDbl(DT_IncomeStatement(x)("Debit"))
                        IS_Credit += CDbl(DT_IncomeStatement(x)("Credit"))
                        IS_Total += CDbl(DT_IncomeStatement(x)("Total"))
                    End If
                Next
                DT(D)("Debit") = DT(D)("Debit") + IS_Debit
                DT(D)("Credit") = DT(D)("Credit") + IS_Credit
                DT(D)("Total") = DT(D)("Total") + IS_Total
            End If
        Next
        Dim Debit_Total As Double
        Dim Credit_Total As Double
        Dim Total As Double
        For x As Integer = 0 To DT.Rows.Count - 1
            Debit_Total += CDbl(DT(x)("Debit"))
            Credit_Total += CDbl(DT(x)("Credit"))
            Total += CDbl(DT(x)("Total"))
        Next
        DT.Rows.Add("T O T A L", "", "", "", "", 0, 0, Debit_Total, Credit_Total, Total)

        GridControl1.DataSource = DT

        If GridView1.RowCount > 17 Then
            GridColumn3.Width = 510 - 17
        Else
            GridColumn3.Width = 510
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Classification As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Code"))
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
        Dim Report As New RptGeneralLedgerAccount
        With Report
            .Name = lblTitle.Text
            .lblAsOf.Text = If(dtpFrom = dtpTo Or cbxAll, "", "From " & Format(dtpFrom, "MMMM dd, yyyy") & " To " & Format(dtpTo, "MMMM dd, yyyy"))

            .lblType.Text = txtType.Text
            .lblClassification.Text = txtClassification.Text
            .lblGroup.Text = txtGroup.Text
            .lblAccountNum.Text = txtAccountNumber.Text
            .lblAccount.Text = txtAccount.Text
            .lblRemarks.Text = rDescription.Text

            .DataSource = GridControl1.DataSource
            .lblCode.DataBindings.Add("Text", GridControl1.DataSource, "Code")
            .lblAccountTitle.DataBindings.Add("Text", GridControl1.DataSource, "Title")
            .lblDepartmentCode.DataBindings.Add("Text", GridControl1.DataSource, "Department Code")
            .lblDebit.DataBindings.Add("Text", GridControl1.DataSource, "Debit")
            .lblCredit.DataBindings.Add("Text", GridControl1.DataSource, "Credit")
            .lblTotal.DataBindings.Add("Text", GridControl1.DataSource, "Total")
            Logs("General Ledger - Account", "Print", "[SENSITIVE] Print General Ledger - Account List", "", "", "", "")
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("Code").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Transaction As New FrmGeneralLedgerAccountDetails
        With Transaction
            .vPrint = vPrint
            .lblTitle.Text = GridView1.GetFocusedRowCellValue("Title")
            .AccountCode = GridView1.GetFocusedRowCellValue("Code")
            .From_BalanceSheet = From_BalanceSheet
            .From_IncomeStatement = From_IncomeStatement
            If GridView1.FocusedColumn.FieldName = "Title" Then
                .DepartmentCode = ""
            Else
                .DepartmentCode = GridView1.GetFocusedRowCellValue("DepartmentCode")
            End If
            If .ShowDialog = DialogResult.OK Then
                .Dispose()
                btnCancel.DialogResult = DialogResult.OK
                btnCancel.PerformClick()
            End If
            .Dispose()
        End With
    End Sub
End Class