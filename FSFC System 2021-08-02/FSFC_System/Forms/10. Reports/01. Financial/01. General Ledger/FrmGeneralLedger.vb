Imports DevExpress.XtraReports.UI
Public Class FrmGeneralLedger

    Public vPrint As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmGeneralLedger_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0

        cbxHideCategory.Checked = True
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

        If CompanyMode = 0 Then
            btnPeriodic.Visible = False
        Else
            btnPeriodic.Visible = True
        End If
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

            GetCheckBoxFontSettings({cbxAllB, cbxAllBank, cbxAll, cbxHideCategory})

            GetComboBoxFontSettings({cbxBranch, cbxBusinessCenter, cbxBook, cbxBank, cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint, btnBasic, btnDetailed, btnPeriodic})
        Catch ex As Exception
            TriggerBugReport("General Ledger - FixUI", ex.Message.ToString)
        End Try
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

    Public Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT account_chart.ID,"
        SQL &= "    `Type`,"
        SQL &= "    Classification,"
        SQL &= "    `Group`,"
        SQL &= "    `Code`,"
        SQL &= "    Title,"
        SQL &= "    ContraAccount, Type_ID, (SELECT Formula FROM account_type WHERE ID = type_ID) AS 'Formula', "
        SQL &= "    IF(Description = '' AND Main_ID > 0,(SELECT Description FROM account_chart C WHERE C.ID = account_chart.Main_ID),Description) AS 'Description',"
        SQL &= "    IFNULL(SUM(CASE WHEN EntryType = 'DEBIT' AND AccountCode = `Code` THEN Amount END),0) AS 'Debit',"
        SQL &= "    IFNULL(SUM(CASE WHEN EntryType = 'CREDIT' AND AccountCode = `Code` THEN Amount END),0) AS 'Credit',"
        SQL &= "    (IFNULL(SUM(CASE WHEN IF(AccountFormula(account_chart.type_ID,account_chart.ContraAccount) = 1,EntryType = 'DEBIT',EntryType = 'CREDIT') AND AccountCode = `Code` THEN Amount END),0) - IFNULL(SUM(CASE WHEN IF(AccountFormula(account_chart.type_ID,account_chart.ContraAccount) = 1,EntryType = 'CREDIT',EntryType = 'DEBIT') AND AccountCode = `Code` THEN Amount END),0)) AS 'Total', `Status`"
        If CompanyMode = 0 Then
            SQL &= String.Format("    FROM account_chart LEFT JOIN (SELECT ID, EntryType, MotherCode_Adjunct(accounting_entry.AccountCode) AS 'AccountCode', Amount FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF({2} = 1,TRUE,ORDate BETWEEN '{0}' AND '{1}') AND IF({3} = 1,Branch_ID IN ({7}),Branch_ID = '{4}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({5} > 0, BankID = '{5}',TRUE) AND IF('{6}' = '0',TRUE,BusinessCode = '{6}') AND IF({8} = True,TRUE,IF('{9}' = 0,Book(BankID) = '{10}',BankID = '{9}'))) A ON A.AccountCode = account_chart.`Code`  WHERE `status` IN ('ACTIVE','DEACTIVATE') AND Main_ID = 0 AND AdjunctAccount = 0 GROUP BY account_chart.ID HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY `Code`;", Format(If(cbxDisplay.SelectedIndex = 5, CDate("1/1/1753"), dtpFrom.Value), "yyyy-MM-dd"), Format(If(cbxDisplay.SelectedIndex = 5, dtpFrom.Value, dtpTo.Value), "yyyy-MM-dd"), cbxAll.Checked, cbxAllB.Checked, cbxBranch.SelectedValue, DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        Else
            SQL &= String.Format("    FROM account_chart LEFT JOIN (SELECT ID, EntryType, MotherCode AS 'AccountCode', Amount FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND IF({2} = 1,TRUE,ORDate BETWEEN '{0}' AND '{1}') AND IF({3} = 1,Branch_ID IN ({7}),Branch_ID = '{4}') AND PaidFor NOT IN ('RPPD-A','RPPD-W','Penalty-W') AND IF({5} > 0, BankID = '{5}',TRUE) AND IF('{6}' = '0',TRUE,BusinessCode = '{6}') AND IF({8} = True,TRUE,IF('{9}' = 0,Book(BankID) = '{10}',BankID = '{9}'))) A ON A.AccountCode = account_chart.`Code`  WHERE `status` IN ('ACTIVE','DEACTIVATE') AND Main_ID = 0 GROUP BY account_chart.ID HAVING IF(`status` = 'DEACTIVATE',SUM(Amount) > 0,TRUE) ORDER BY `Code`;", Format(If(cbxDisplay.SelectedIndex = 5, CDate("1/1/1753"), dtpFrom.Value), "yyyy-MM-dd"), Format(If(cbxDisplay.SelectedIndex = 5, dtpFrom.Value, dtpTo.Value), "yyyy-MM-dd"), cbxAll.Checked, cbxAllB.Checked, cbxBranch.SelectedValue, DefaultBankID, ValidateComboBox(cbxBusinessCenter), Multiple_ID, cbxAllBank.Checked, ValidateComboBox(cbxBank), ValidateComboBox(cbxBook))
        End If
        Dim DT As DataTable = DataSource(SQL)
        Dim Debit_Total As Decimal = 0
        Dim Credit_Total As Decimal = 0
        Dim Total As Double
        For x As Integer = 0 To DT.Rows.Count - 1
            Debit_Total += CDec(DT(x)("Debit"))
            Credit_Total += CDec(DT(x)("Credit"))
            If DT(x)("Formula") = 1 Then
                Total += CDec(DT(x)("Total"))
            Else
                Total -= CDec(DT(x)("Total"))
            End If
        Next
        DT.Rows.Add(0, "T O T A L", "", "", "", "", 0, 0, 0, "", Debit_Total, Credit_Total, Total)

        GridControl1.DataSource = DT
        GridView1.Columns("Title").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Title").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        Dim DT_ColumnSettings As DataTable = DataSource(String.Format("SELECT * FROM column_settings WHERE UserID = '{0}' AND FormID = '{1}' AND `status` = 'ACTIVE';", User_ID, Tag & If(cbxHideCategory.Checked, 100, "")))
        If cbxHideCategory.Checked Then
            If DT_ColumnSettings.Rows.Count > 0 Then
                GridControl1.Tag = 1
                GridColumn1.VisibleIndex = DT_ColumnSettings(0)("Column1V")
                GridColumn21.VisibleIndex = DT_ColumnSettings(0)("Column2V")
                GridColumn4.VisibleIndex = DT_ColumnSettings(0)("Column3V")
                GridColumn15.VisibleIndex = DT_ColumnSettings(0)("Column4V")
                GridColumn5.VisibleIndex = DT_ColumnSettings(0)("Column5V")
                GridColumn6.VisibleIndex = DT_ColumnSettings(0)("Column6V")
                GridColumn7.VisibleIndex = DT_ColumnSettings(0)("Column7V")

                GridColumn1.Width = DT_ColumnSettings(0)("Column1W")
                GridColumn21.Width = DT_ColumnSettings(0)("Column2W")
                GridColumn4.Width = DT_ColumnSettings(0)("Column3W")
                GridColumn15.Width = DT_ColumnSettings(0)("Column4W")
                GridColumn5.Width = DT_ColumnSettings(0)("Column5W")
                GridColumn6.Width = DT_ColumnSettings(0)("Column6W")
                GridColumn7.Width = DT_ColumnSettings(0)("Column7W")
            Else
                GridControl1.Tag = 0
            End If
        Else
            If DT_ColumnSettings.Rows.Count > 0 Then
                GridControl1.Tag = 1
                GridColumn1.VisibleIndex = DT_ColumnSettings(0)("Column1V")
                GridColumn2.VisibleIndex = DT_ColumnSettings(0)("Column2V")
                GridColumn3.VisibleIndex = DT_ColumnSettings(0)("Column3V")
                GridColumn21.VisibleIndex = DT_ColumnSettings(0)("Column4V")
                GridColumn4.VisibleIndex = DT_ColumnSettings(0)("Column5V")
                GridColumn15.VisibleIndex = DT_ColumnSettings(0)("Column6V")
                GridColumn5.VisibleIndex = DT_ColumnSettings(0)("Column7V")
                GridColumn6.VisibleIndex = DT_ColumnSettings(0)("Column8V")
                GridColumn7.VisibleIndex = DT_ColumnSettings(0)("Column9V")

                GridColumn1.Width = DT_ColumnSettings(0)("Column1W")
                GridColumn2.Width = DT_ColumnSettings(0)("Column2W")
                GridColumn3.Width = DT_ColumnSettings(0)("Column3W")
                GridColumn21.Width = DT_ColumnSettings(0)("Column4W")
                GridColumn4.Width = DT_ColumnSettings(0)("Column5W")
                GridColumn15.Width = DT_ColumnSettings(0)("Column6W")
                GridColumn5.Width = DT_ColumnSettings(0)("Column7W")
                GridColumn6.Width = DT_ColumnSettings(0)("Column8W")
                GridColumn7.Width = DT_ColumnSettings(0)("Column9W")
            Else
                GridControl1.Tag = 0
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Classification As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Classification"))
            If Classification = "" Then
                e.Appearance.Font = New Font(OfficialFont, CSng(OfficialFontSizeGrid), FontStyle.Bold)
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
        Dim Report As New RptGeneralLedger
        With Report
            .lblTitle.Text = "FIRST STANDARD FINANCE CORPORATION" & If(cbxAllB.Checked, "", " - " & cbxBranch.Text)
            If cbxDisplay.SelectedIndex = 5 Then
                .lblAsOf.Text = "As of " & Format(dtpFrom.Value, "MMMM dd, yyyy")
            Else
                .lblAsOf.Text = If(dtpFrom.Value = dtpTo.Value Or cbxAll.Checked, "", "From " & Format(dtpFrom.Value, "MMMM dd, yyyy") & " to " & Format(dtpTo.Value, "MMMM dd, yyyy"))
            End If
            .Name = "FIRST STANDARD FINANCE CORPORATION" & If(cbxAllB.Checked, "", " - " & cbxBranch.Text) & " (" & .lblAsOf.Text & ")"

            .DataSource = GridControl1.DataSource
            .lblType.DataBindings.Add("Text", GridControl1.DataSource, "Type")
            .lblClassification.DataBindings.Add("Text", GridControl1.DataSource, "Classification")
            .lblGroup.DataBindings.Add("Text", GridControl1.DataSource, "Group")
            .lblAccountCode.DataBindings.Add("Text", GridControl1.DataSource, "Code")
            .lblSubAccount.DataBindings.Add("Text", GridControl1.DataSource, "Title")
            .lblDebit.DataBindings.Add("Text", GridControl1.DataSource, "Debit")
            .lblCredit.DataBindings.Add("Text", GridControl1.DataSource, "Credit")
            .lblTotal.DataBindings.Add("Text", GridControl1.DataSource, "Total")
            Logs("General Ledger", "Print", "[SENSITIVE] Print General Ledger List", "", "", "", "")
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

    Private Sub GridView1_Keydown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        'Save customize column in the table column_settings
        If e.Control And e.KeyCode = Keys.S Then
            If MsgBoxYes("Are you sure you want to save this Table Display") = MsgBoxResult.Yes Then
                Dim SQL As String
                If cbxHideCategory.Checked Then
                    If GridControl1.Tag = 1 Then
                        SQL = "UPDATE column_settings SET"
                    Else
                        SQL = "INSERT INTO column_settings SET"
                    End If
                    SQL &= String.Format(" UserID = '{0}', ", User_ID)
                    SQL &= String.Format(" FormID = '{0}', ", Tag & If(cbxHideCategory.Checked, 100, ""))
                    SQL &= String.Format(" Column1V = '{0}', ", GridColumn1.VisibleIndex)
                    SQL &= String.Format(" Column2V = '{0}', ", GridColumn21.VisibleIndex)
                    SQL &= String.Format(" Column3V = '{0}', ", GridColumn4.VisibleIndex)
                    SQL &= String.Format(" Column4V = '{0}', ", GridColumn15.VisibleIndex)
                    SQL &= String.Format(" Column5V = '{0}', ", GridColumn5.VisibleIndex)
                    SQL &= String.Format(" Column6V = '{0}', ", GridColumn6.VisibleIndex)
                    SQL &= String.Format(" Column7V = '{0}', ", GridColumn7.VisibleIndex)
                    SQL &= String.Format(" Column8V = '{0}', ", -1)
                    SQL &= String.Format(" Column9V = '{0}', ", -1)
                    SQL &= String.Format(" Column1W = '{0}', ", GridColumn1.Width)
                    SQL &= String.Format(" Column2W = '{0}', ", GridColumn21.Width)
                    SQL &= String.Format(" Column3W = '{0}', ", GridColumn4.Width)
                    SQL &= String.Format(" Column4W = '{0}', ", GridColumn15.Width)
                    SQL &= String.Format(" Column5W = '{0}', ", GridColumn5.Width)
                    SQL &= String.Format(" Column6W = '{0}', ", GridColumn6.Width)
                    SQL &= String.Format(" Column7W = '{0}', ", GridColumn7.Width)
                    SQL &= String.Format(" Column8W = '{0}', ", 0)
                    SQL &= String.Format(" Column9W = '{0}' ", 0)
                    If GridControl1.Tag = 1 Then
                        SQL &= String.Format(" WHERE FormID = '{0}' AND `status` = 'ACTIVE';", Tag & If(cbxHideCategory.Checked, 100, ""))
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
                    SQL &= String.Format(" Column2V = '{0}', ", GridColumn2.VisibleIndex)
                    SQL &= String.Format(" Column3V = '{0}', ", GridColumn3.VisibleIndex)
                    SQL &= String.Format(" Column4V = '{0}', ", GridColumn21.VisibleIndex)
                    SQL &= String.Format(" Column5V = '{0}', ", GridColumn4.VisibleIndex)
                    SQL &= String.Format(" Column6V = '{0}', ", GridColumn15.VisibleIndex)
                    SQL &= String.Format(" Column7V = '{0}', ", GridColumn5.VisibleIndex)
                    SQL &= String.Format(" Column8V = '{0}', ", GridColumn6.VisibleIndex)
                    SQL &= String.Format(" Column9V = '{0}', ", GridColumn7.VisibleIndex)
                    SQL &= String.Format(" Column1W = '{0}', ", GridColumn1.Width)
                    SQL &= String.Format(" Column2W = '{0}', ", GridColumn2.Width)
                    SQL &= String.Format(" Column3W = '{0}', ", GridColumn3.Width)
                    SQL &= String.Format(" Column4W = '{0}', ", GridColumn21.Width)
                    SQL &= String.Format(" Column5W = '{0}', ", GridColumn4.Width)
                    SQL &= String.Format(" Column6W = '{0}', ", GridColumn15.Width)
                    SQL &= String.Format(" Column7W = '{0}', ", GridColumn5.Width)
                    SQL &= String.Format(" Column8W = '{0}', ", GridColumn6.Width)
                    SQL &= String.Format(" Column9W = '{0}' ", GridColumn7.Width)
                    If GridControl1.Tag = 1 Then
                        SQL &= String.Format(" WHERE FormID = '{0}' AND `status` = 'ACTIVE';", Tag)
                    End If
                    DataObject(SQL)
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                End If
            End If
        ElseIf e.Control And e.KeyCode = Keys.D Then
            If GridControl1.Tag = 1 Then
                If MsgBoxYes("Are you sure you want to restore the default of this table?") = MsgBoxResult.Yes Then
                    DataObject(String.Format("UPDATE column_settings SET `status` = 'CANCELLED'  WHERE FormID = '{0}' AND `status` = 'ACTIVE';", Tag & If(cbxHideCategory.Checked, 100, "")))
                    MsgBox("Successfully Cancelled!", MsgBoxStyle.Information, "Info")
                End If
            Else
                MsgBox("Table is already using the default setup.", MsgBoxStyle.Information, "Info")
            End If
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
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.GetFocusedRowCellValue("ID") = 0 Or GridView1.RowCount = 0 Or CompanyMode = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Account As New FrmGeneralLedgerAccount
        With Account
            .vPrint = vPrint
            .Main_ID = GridView1.GetFocusedRowCellValue("ID")
            .txtType.Text = GridView1.GetFocusedRowCellValue("Type")
            .txtClassification.Text = GridView1.GetFocusedRowCellValue("Classification")
            .txtGroup.Text = GridView1.GetFocusedRowCellValue("Group")
            .txtAccountNumber.Text = GridView1.GetFocusedRowCellValue("Code")
            .txtAccount.Text = GridView1.GetFocusedRowCellValue("Title")
            .rDescription.Text = GridView1.GetFocusedRowCellValue("Description")
            .ShowDialog()
            .Dispose()
        End With
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
        StandardPrinting("GENERAL LEDGER", GridControl1)
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxHideCategory_CheckedChanged(sender As Object, e As EventArgs) Handles cbxHideCategory.CheckedChanged
        If cbxHideCategory.Checked Then
            GridColumn2.Visible = False
            GridColumn3.Visible = False
            GridColumn21.Visible = False
            GridColumn4.VisibleIndex = 0
            GridColumn15.VisibleIndex = 1
            GridColumn5.VisibleIndex = 2
            GridColumn6.VisibleIndex = 3
            GridColumn7.VisibleIndex = 4

            GridColumn4.Width = 90 + 30
            GridColumn15.Width = 282 + 370
            GridColumn5.Width = 90 + 30
            GridColumn6.Width = 90 + 30
            GridColumn7.Width = 90 + 30
        Else
            GridColumn2.VisibleIndex = 0
            GridColumn3.VisibleIndex = 1
            GridColumn21.VisibleIndex = 2
            GridColumn4.VisibleIndex = 3
            GridColumn15.VisibleIndex = 4
            GridColumn5.VisibleIndex = 5
            GridColumn6.VisibleIndex = 6
            GridColumn7.VisibleIndex = 7

            GridColumn2.Width = 140
            GridColumn3.Width = 165
            GridColumn21.Width = 185
            GridColumn4.Width = 90
            GridColumn15.Width = 282
            GridColumn5.Width = 90
            GridColumn6.Width = 90
            GridColumn7.Width = 90
        End If
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

    Private Sub BtnBasic_Click(sender As Object, e As EventArgs) Handles btnBasic.Click
        Dim Account As New FrmGeneralLedgerBasic
        With Account
            .vPrint = vPrint
            .Tag = Tag & 100
            .vBranch = cbxBranch.SelectedValue
            .vBusinessCenter = cbxBusinessCenter.SelectedValue
            .vBook = cbxBook.SelectedValue
            .vBank = cbxBank.SelectedValue
            .vDisplay = cbxDisplay.SelectedIndex
            .vFrom = dtpFrom.Value
            .vTo = dtpTo.Value
            .vAllB = cbxAllB.Checked
            .vAllBank = cbxAllBank.Checked
            .vAll = cbxAll.Checked
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnDetailed_Click(sender As Object, e As EventArgs) Handles btnDetailed.Click
        Dim Account As New FrmGeneralLedgerDetailed
        With Account
            .vPrint = vPrint
            .Tag = Tag & 101
            .vBranch = cbxBranch.SelectedValue
            .vBusinessCenter = cbxBusinessCenter.SelectedValue
            .vBook = cbxBook.SelectedValue
            .vBank = cbxBank.SelectedValue
            .vDisplay = cbxDisplay.SelectedIndex
            .vFrom = dtpFrom.Value
            .vTo = dtpTo.Value
            .vAllB = cbxAllB.Checked
            .vAllBank = cbxAllBank.Checked
            .vAll = cbxAll.Checked
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnPeriodic_Click(sender As Object, e As EventArgs) Handles btnPeriodic.Click
        'Try
        '    If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
        '        Exit Sub
        '    End If
        'Catch ex As Exception
        '    Exit Sub
        'End Try

        'Cursor = Cursors.WaitCursor
        'Dim Account As New FrmGeneralLedger_Periodic
        'With Account
        '    .vPrint = vPrint
        '    .lblMonth.Text = "For the Month of " & Format(dtpFrom.Value, "MMMM")
        '    .Main_ID = GridView1.GetFocusedRowCellValue("ID")
        '    .ShowDialog()
        '    .Dispose()
        'End With
        'Cursor = Cursors.Default
        Dim Account As New FrmGeneralLedgerPeriodicV2
        With Account
            .vPrint = vPrint
            .Tag = Tag & 102
            .vBranch = cbxBranch.SelectedValue
            .vBusinessCenter = cbxBusinessCenter.SelectedValue
            .vBook = cbxBook.SelectedValue
            .vBank = cbxBank.SelectedValue
            .vDisplay = cbxDisplay.SelectedIndex
            .vFrom = dtpFrom.Value
            .vTo = dtpTo.Value
            .vAllB = cbxAllB.Checked
            .vAllBank = cbxAllBank.Checked
            .vAll = cbxAll.Checked
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class