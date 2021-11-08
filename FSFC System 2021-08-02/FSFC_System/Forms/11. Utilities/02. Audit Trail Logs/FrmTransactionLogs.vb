Public Class FrmTransactionLogs

    Public vPrint As Boolean

    Private Sub FrmTransactionLogs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX155, LabelX10, LabelX1, LabelX6})

            GetTextBoxFontSettings({txtKeyword1})

            GetCheckBoxFontSettings({cbxAll})

            GetComboBoxFontSettings({cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnPrint, btnClose})
        Catch ex As Exception
            TriggerBugReport("Transaction Logs - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Transaction Logs", lblTitle.Text)
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

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    Form,"
        SQL &= "    Button,"
        SQL &= "    Reason,"
        SQL &= "    Changes,"
        SQL &= "    borrower_no AS 'Borrower No',"
        SQL &= "    Borrower,"
        SQL &= "    application_no AS 'Application No',"
        SQL &= "    DATE_FORMAT(DATE(`Timestamp`),'%M %d, %Y') AS 'Date',"
        SQL &= "    TIME_FORMAT(TIME(`Timestamp`),'%r') AS 'Time',"
        SQL &= "    Computer,"
        SQL &= "    ip_address  AS 'IP Address',"
        SQL &= "    Username,"
        SQL &= "    Employee,"
        SQL &= "    Branch"
        SQL &= " FROM transaction_logs"
        SQL &= String.Format("    WHERE Branch_ID IN ({0}) ", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim Key As String
        If cbxAll.Checked = False Then
            SQL &= String.Format(" AND DATE(`Timestamp`) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
        End If
        Dim Words As String() = txtKeyword1.Text.Trim.Split(New Char() {" "c})
        For Each Key In Words
            SQL &= String.Format(" AND (`Form` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Button` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Reason` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Changes` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `borrower_no` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Borrower` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `application_no` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Timestamp` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Computer` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `ip_address` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Username` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Employee` LIKE '%{0}%' OR", Key)
            SQL &= String.Format(" `Branch` LIKE '%{0}%')", Key)
        Next
        SQL &= " ORDER BY `timestamp` DESC"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Changes").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Changes").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn5.Width = 339 - 17
        Else
            GridColumn5.Width = 339
        End If
        Cursor = Cursors.Default
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

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("TRANSACTION LOGS", GridControl1)
        Logs("Transaction Logs", "Print", "[SENSITIVE] Print Transaction Logs", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub FrmTransactionLogs_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnClose.Focus()
            btnClose.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub TxtKeyword1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        End If
    End Sub
End Class