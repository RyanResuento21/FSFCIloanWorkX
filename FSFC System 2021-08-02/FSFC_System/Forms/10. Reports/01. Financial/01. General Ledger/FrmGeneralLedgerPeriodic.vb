Imports DevExpress.XtraReports.UI
Public Class FrmGeneralLedgerPeriodic

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Public Main_ID As Integer
    Private Sub FrmGeneralLedger_Periodic_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        LoadData()

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettingsDefaultSize({lblMonth})

            GetButtonFontSettings({btnCancel, btnPrint})
        Catch ex As Exception
            TriggerBugReport("General Ledger Period - FixUI", ex.Message.ToString)
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
        OpenFormHistory("General Ledger", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    MotherCode AS 'Code',"
        SQL &= "    (SELECT Title FROM account_chart AC WHERE AC.ID = account_chart.Main_ID AND `status` = 'ACTIVE') AS 'Title',"
        SQL &= "    CONCAT(`Code`, ' - ', Title) AS 'Sub Account',"
        SQL &= "    DepartmentCode AS 'Department Code', Type_ID, ContraAccount,"
        SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(account_chart.type_ID,account_chart.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND AccountCode = `Code` AND DATE(ORDate) < DATE('{0}') THEN Amount END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(account_chart.type_ID,account_chart.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND AccountCode = `Code` AND DATE(ORDate) < DATE('{0}') THEN Amount END),0) AS 'Beginning',", Format(FrmGeneralLedger.dtpFrom.Value, "yyyy-MM-01"))
        SQL &= String.Format("    IFNULL(SUM(CASE WHEN EntryType = 'DEBIT' AND AccountCode = `Code` AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN Amount END),0) AS 'Debit',", Format(FrmGeneralLedger.dtpFrom.Value, "yyyy-MM-dd"))
        SQL &= String.Format("    IFNULL(SUM(CASE WHEN EntryType = 'CREDIT' AND AccountCode = `Code` AND MONTH(ORDate) = MONTH('{0}') AND YEAR(ORDate) = YEAR('{0}') THEN Amount END),0) AS 'Credit',", Format(FrmGeneralLedger.dtpFrom.Value, "yyyy-MM-dd"))
        SQL &= String.Format("    IFNULL(SUM(CASE WHEN IF(AccountFormula(account_chart.type_ID,account_chart.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND AccountCode = `Code` AND DATE(ORDate) <= LAST_DAY('{0}') THEN Amount END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(account_chart.type_ID,account_chart.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND AccountCode = `Code` AND DATE(ORDate) <= LAST_DAY('{0}') THEN Amount END),0) AS 'Ending', `Status`", Format(FrmGeneralLedger.dtpFrom.Value, "yyyy-MM-01"))
        SQL &= String.Format("    FROM account_chart LEFT JOIN (SELECT ID, EntryType, AccountCode, Amount, DepartmentCode, ORDate FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF({3} = 1,TRUE,Branch_ID = '{4}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({5} > 0, BankID = '{5}',TRUE) AND IF({6} = True,TRUE,IF('{7}' = 0,Book(BankID) = '{8}',BankID = '{7}'))) A ON A.AccountCode = account_chart.`Code`  WHERE `status` IN ('ACTIVE','DEACTIVATE') AND Main_ID > 0 GROUP BY account_chart.ID, A.DepartmentCode HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY `Code`, `Sub Account`;", Format(FrmGeneralLedger.dtpFrom.Value, "yyyy-MM-dd"), Format(FrmGeneralLedger.dtpTo.Value, "yyyy-MM-dd"), FrmGeneralLedger.cbxAll.Checked, FrmGeneralLedger.cbxAllB.Checked, FrmGeneralLedger.cbxBranch.SelectedValue, DefaultBankID, FrmGeneralLedger.cbxAllBank.Checked, ValidateComboBox(FrmGeneralLedger.cbxBank), ValidateComboBox(FrmGeneralLedger.cbxBook))
        Dim DT As DataTable = DataSource(SQL)
        Dim Beginning As Double
        Dim Debit_Total As Double
        Dim Credit_Total As Double
        Dim Total As Double
        For x As Integer = 0 To DT.Rows.Count - 1
            Beginning += CDbl(DT(x)("Beginning"))
            Debit_Total += CDbl(DT(x)("Debit"))
            Credit_Total += CDbl(DT(x)("Credit"))
            If DT(x)("Type_ID") = 2 Or DT(x)("Type_ID") = 3 Then
                Total -= CDbl(DT(x)("Ending"))
            Else
                Total += CDbl(DT(x)("Ending"))
            End If
        Next
        DT.Rows.Add("", "T O T A L", "", "", 0, 0, Beginning, Debit_Total, Credit_Total, Total)

        GridControl1.DataSource = DT

        If GridView1.RowCount > 17 Then
            GridColumn3.Width = 305 - 17
        Else
            GridColumn3.Width = 305
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Classification As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Code"))
            If Classification = "" Then
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
        Dim Report As New RptGeneralLedgerPeriodic
        With Report
            .Name = lblTitle.Text
            .Name = String.Format("Income Statement of {0} As of {1}", If(FrmGeneralLedger.cbxAllB.Checked, "All Branches", FrmGeneralLedger.cbxBranch.Text), Format(FrmGeneralLedger.dtpTo.Value, "MMMM"))
            .lblAsOf.Text = lblMonth.Text

            .DataSource = GridControl1.DataSource
            .lblCode.DataBindings.Add("Text", GridControl1.DataSource, "Code")
            .lblAccount.DataBindings.Add("Text", GridControl1.DataSource, "Title")
            .lblSubAccount.DataBindings.Add("Text", GridControl1.DataSource, "Sub Account")
            .lblDepartment.DataBindings.Add("Text", GridControl1.DataSource, "Department Code")
            .lblBeginning.DataBindings.Add("Text", GridControl1.DataSource, "Beginning")
            .lblDebit.DataBindings.Add("Text", GridControl1.DataSource, "Debit")
            .lblCredit.DataBindings.Add("Text", GridControl1.DataSource, "Credit")
            .lblEnding.DataBindings.Add("Text", GridControl1.DataSource, "Ending")
            Logs("General Ledger", "Print", "[SENSITIVE] Print General Ledger - Periodic List", "", "", "", "")
            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub
End Class