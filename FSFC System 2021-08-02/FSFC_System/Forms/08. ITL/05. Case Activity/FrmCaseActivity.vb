Imports DevExpress.XtraCharts
Public Class FrmCaseActivity

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean
    Private Sub FrmActivityMonitoring_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        cbxDisplay.SelectedIndex = 0

        With Chart1
            .Location = New Point(570, 150)
            .Size = New Point(582, 225)
        End With

        With ChartControl2
            .Location = New Point(301, 318)
            .Size = New Point(262, 250)
        End With

        With cbxBranch
            .DisplayMember = "Branch"
            .ValueMember = "BranchID"
            .DataSource = DataSource("SELECT BranchID, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY BranchID;")
            .SelectedIndex = -1
        End With

        With cbxCase
            .DisplayMember = "Defendant"
            .ValueMember = "ID"
        End With

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX40, LabelX42, LabelX41, LabelX1, LabelX2, LabelX14, lblLastUpdate_D, LabelX13, lblLastUpdate_DA, LabelX6, LabelX5, lblOngoingD, lblDecidedD, lblExecutedD, lblDismissedD, lblArchivedD, lblWrittenOffD, lblOngoingP, lblDecidedP, lblExecutedP, lblDismissedP, lblArchivedP, lblWrittenOffP, lblActionPlan})

            GetCheckBoxFontSettings({cbxAll})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetComboBoxFontSettings({cbxDisplay, cbxBranch, cbxCase})

            GetGroupControlFontSettings({gLog, GroupControl1, gCivilStatus, GroupControl2})

            GetButtonFontSettings({btnSearch, btnCancel, btnPrint})

            GetChartTitleControlFontSettings({ChartControl2, Chart1})

            GetLabelFontSettingsDashboardTitle({LabelX155, LabelX35, LabelX3})

            GetLabelFontSettingsDashboardPanel({pBookValue, pPayments, pBalance})

            GetLabelFontSettingsDashboardTitleDefault({lblStatus, LabelX16, LabelX54, LabelX9, LabelX15, LabelX19, LabelX22})
        Catch ex As Exception
            TriggerBugReport("Case Activity - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LoadData()
        If cbxCase.SelectedIndex = -1 Or cbxCase.Text = "" Then
            MsgBox("Please Select Case First.", MsgBoxStyle.Information, "Info")
            cbxCase.DroppedDown = True
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim drv As DataRowView = DirectCast(cbxCase.SelectedItem, DataRowView)
        Dim SQL As String = String.Format("SELECT IF(Reason = '',Changes,Reason) AS 'Action', DATE_FORMAT(`Timestamp`, '%M %d, %Y %r') AS 'Date & Time' FROM transaction_logs WHERE Application_No = '{0}' AND IF({3},TRUE,DATE(`timestamp`) BETWEEN '{1}' AND '{2}') ORDER BY `timestamp` DESC;", drv("AccountNumber"), Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"), cbxAll.Checked)
        GridControl1.DataSource = DataSource(SQL)

        lblLastUpdate_D.Text = drv("Last Modified")

        If lblLastUpdate_D.Text = "" Then
            lblLastUpdate_DA.Text = "0"
        Else
            lblLastUpdate_DA.Text = FormatNumber(DateDiff(DateInterval.Day, DateValue(lblLastUpdate_D.Text), Date.Now), 0)
        End If
        pBookValue.Text = drv("Book Value")
        pPayments.Text = drv("Collection")
        pBalance.Text = drv("Balance")
        lblStatus.Text = drv("case_status")
        If lblStatus.Text = "ACTIVE" Then
            lblStatus.BackColor = Color.SeaGreen
        ElseIf lblStatus.Text = "DISMISSED" Then
            lblStatus.BackColor = Color.IndianRed
        ElseIf lblStatus.Text = "ARCHIVED" Then
            lblStatus.BackColor = Color.Orange
        ElseIf lblStatus.Text = "WRITTEN OFF" Then
            lblStatus.BackColor = Color.RoyalBlue
        ElseIf lblStatus.Text = "FULLY PAID" Then
            lblStatus.BackColor = Color.Olive
        End If
        lblActionPlan.Text = "   " & drv("Action Plan")

        SQL = "SELECT MAX(`Ongoing`) AS 'Ongoing', MAX(`Decided`) AS 'Decided', MAX(`Executed`) AS 'Executed', MAX(`Dismissed`) AS 'Dismissed', MAX(`Archived`) AS 'Archived', MAX(`WrittenOff`) AS 'WrittenOff' FROM ("
        SQL &= " SELECT "
        SQL &= String.Format("    FORMAT(IFNULL((CASE WHEN CategoryID = 1 THEN DATEDIFF(IFNULL((SELECT MIN(D.MovementDate) FROM case_details D WHERE D.CategoryID = 7 AND D.`status` = 'ACTIVE' AND D.CaseID = '{0}'),DATE(NOW())),MIN(MovementDate)) END),0),0) AS 'Ongoing',", cbxCase.SelectedValue)
        SQL &= String.Format("    FORMAT(IFNULL((CASE WHEN CategoryID = 7 THEN DATEDIFF(IFNULL((SELECT MIN(D.MovementDate) FROM case_details D WHERE D.CategoryID = 8 AND D.`status` = 'ACTIVE' AND D.CaseID = '{0}'),DATE(NOW())),MIN(MovementDate)) END),0),0) AS 'Decided',", cbxCase.SelectedValue)
        SQL &= String.Format("    FORMAT(IFNULL((CASE WHEN CategoryID = 8 THEN DATEDIFF(IFNULL((SELECT MIN(D.MovementDate) FROM case_details D WHERE D.CategoryID = 9 AND D.`status` = 'ACTIVE' AND D.CaseID = '{0}'),DATE(NOW())),MIN(MovementDate)) END),0),0) AS 'Executed',", cbxCase.SelectedValue)
        SQL &= String.Format("    FORMAT(IFNULL((CASE WHEN CategoryID = 9 THEN DATEDIFF(IFNULL((SELECT MIN(D.MovementDate) FROM case_details D WHERE D.CategoryID = 10 AND D.`status` = 'ACTIVE' AND D.CaseID = '{0}'),DATE(NOW())),MIN(MovementDate)) END),0),0) AS 'Dismissed',", cbxCase.SelectedValue)
        SQL &= String.Format("    FORMAT(IFNULL((CASE WHEN CategoryID = 10 THEN DATEDIFF(IFNULL((SELECT MIN(D.MovementDate) FROM case_details D WHERE D.CategoryID = 11 AND D.`status` = 'ACTIVE' AND D.CaseID = '{0}'),DATE(NOW())),MIN(MovementDate)) END),0),0) AS 'Archived',", cbxCase.SelectedValue)
        SQL &= "    FORMAT(IFNULL((CASE WHEN CategoryID = 11 THEN DATEDIFF(DATE(NOW()),MIN(MovementDate)) END),0),0) AS 'WrittenOff'"
        SQL &= String.Format("  FROM case_details WHERE `status` = 'ACTIVE' AND CaseID = '{0}' GROUP BY CategoryID) A;", cbxCase.SelectedValue)
        Dim DT_Case As DataTable = DataSource(SQL)
        Dim Total As Integer
        If DT_Case.Rows.Count > 0 Then
            Total = CInt(DT_Case(0)("Ongoing")) + CInt(DT_Case(0)("Decided")) + CInt(DT_Case(0)("Executed")) + CInt(DT_Case(0)("Dismissed")) + CInt(DT_Case(0)("Archived")) + CInt(DT_Case(0)("WrittenOff"))
            lblOngoingD.Text = DT_Case(0)("Ongoing")
            lblDecidedD.Text = DT_Case(0)("Decided")
            lblExecutedD.Text = DT_Case(0)("Executed")
            lblDismissedD.Text = DT_Case(0)("Dismissed")
            lblArchivedD.Text = DT_Case(0)("Archived")
            lblWrittenOffD.Text = DT_Case(0)("WrittenOff")

            lblOngoingP.Text = FormatNumber((DT_Case(0)("Ongoing") / Total) * 100, 2) & " %"
            lblDecidedP.Text = FormatNumber((DT_Case(0)("Decided") / Total) * 100, 2) & " %"
            lblExecutedP.Text = FormatNumber((DT_Case(0)("Executed") / Total) * 100, 2) & " %"
            lblDismissedP.Text = FormatNumber((DT_Case(0)("Dismissed") / Total) * 100, 2) & " %"
            lblArchivedP.Text = FormatNumber((DT_Case(0)("Archived") / Total) * 100, 2) & " %"
            lblWrittenOffP.Text = FormatNumber((DT_Case(0)("WrittenOff") / Total) * 100, 2) & " %"
        End If
        Cursor = Cursors.Default

        LineChart(Chart1)
        PieChart(ChartControl2)
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 1 THEN Amount END),0),2) AS 'Jan',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 2 THEN Amount END),0),2) AS 'Feb',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 3 THEN Amount END),0),2) AS 'Mar',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 4 THEN Amount END),0),2) AS 'Apr',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 5 THEN Amount END),0),2) AS 'May',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 6 THEN Amount END),0),2) AS 'Jun',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 7 THEN Amount END),0),2) AS 'Jul',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 8 THEN Amount END),0),2) AS 'Aug',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 9 THEN Amount END),0),2) AS 'Sep',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 10 THEN Amount END),0),2) AS 'Oct',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 11 THEN Amount END),0),2) AS 'Nov',"
        SQL &= "    FORMAT(IFNULL(SUM(CASE WHEN MONTH(Trans_Date) = 12 THEN Amount END),0),2) AS 'Dec'"
        SQL &= String.Format(" FROM case_ledger WHERE `status` = 'ACTIVE' AND YEAR(Trans_Date) = YEAR('{0}') AND CaseID = '{1}' AND `Type` = 'Deduct';", Format(dtpFrom.Value, "yyyy-MM-dd"), cbxCase.SelectedValue)
        Dim DT_Cases As DataTable = DataSource(SQL)

        Chart.Series.Clear()
        For x As Integer = 0 To DT_Cases.Columns.Count - 1
            Dim Series1 As New Series(DT_Cases(0)(x), ViewType.Bar)
            Series1.Points.Add(New SeriesPoint(DT_Cases.Columns(x).Caption.ToString, DT_Cases(0)(x)))
            Chart.Series.Add(Series1)
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub PieChart(Chart As ChartControl)
        Cursor = Cursors.WaitCursor
        Dim Product As New DataTable
        With Product
            .Columns.Add("Caption")
            .Columns.Add("Value")
            .Rows.Add("Ongoing", lblOngoingD.Text)
            .Rows.Add("Decided", lblDecidedD.Text)
            .Rows.Add("Executed", lblExecutedD.Text)
            .Rows.Add("Dismissed", lblDismissedD.Text)
            .Rows.Add("Archived", lblArchivedD.Text)
            .Rows.Add("WrittenOff", lblWrittenOffD.Text)
        End With
        ' Create a pie chart
        Chart.Series.Clear()
        Try
            Dim Series1 As New Series("Days In Category", ViewType.Pie)

            For x As Integer = 0 To Product.Rows.Count - 1
                Series1.Points.Add(New SeriesPoint(Product(x)("Caption"), Product(x)("Value")))
            Next

            ' Add the series to the chart.
            Chart.Series.Add(Series1)

            CType(Series1.Label, PieSeriesLabel).ResolveOverlappingMode = ResolveOverlappingMode.Default

            Dim myView As PieSeriesView = CType(Series1.View, PieSeriesView)
        Catch ex As Exception
            Cursor = Cursors.Default
            TriggerBugReport("Case Activity - PieChart", ex.Message.ToString)
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub Clear()
        lblLastUpdate_D.Text = "-"
        lblLastUpdate_DA.Text = 0

        pBookValue.Text = "0.00"
        pPayments.Text = "0.00"
        pBalance.Text = "0.00"

        lblStatus.Text = "ACTIVE"
        lblStatus.BackColor = Color.SeaGreen

        lblActionPlan.Text = ""

        lblOngoingD.Text = 0
        lblDecidedD.Text = 0
        lblExecutedD.Text = 0
        lblDismissedD.Text = 0
        lblArchivedD.Text = 0
        lblWrittenOffD.Text = 0

        lblOngoingP.Text = "0.00 %"
        lblDecidedP.Text = "0.00 %"
        lblExecutedP.Text = "0.00 %"
        lblDismissedP.Text = "0.00 %"
        lblArchivedP.Text = "0.00 %"
        lblWrittenOffP.Text = "0.00 %"

        GridControl1.DataSource = Nothing
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If FirstLoad Then
            Exit Sub
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

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            cbxCase.DataSource = Nothing
            cbxCase.Text = ""
            Clear()
        Else
            Cursor = Cursors.WaitCursor
            FirstLoad = True
            Dim SQL As String = "SELECT AccountNumber, ID,"
            SQL &= "    CONCAT(Borrower(BorrowerID), '[', CaseNumber, ']') AS 'Defendant',"
            SQL &= "    FORMAT(BookValue,2) AS 'Book Value',"
            SQL &= "    FORMAT(IFNULL((SELECT SUM(Amount) FROM case_ledger WHERE CaseID = C.ID AND `status` = 'ACTIVE' AND `Type` = 'Deduct'),0),2) AS 'Collection',"
            SQL &= "    FORMAT(Ledger_Balance(AccountNumber,MortgageID),2) AS 'Balance',"
            SQL &= "    case_status,"
            SQL &= "    DATE_FORMAT(LastModified, '%M %d, %Y') AS 'Last Modified',"
            SQL &= "    (SELECT ActionPlan FROM case_details D WHERE C.ID = D.CaseID AND C.CategoryID = D.CategoryID AND C.SubCategoryID = D.SubCategoryID) AS 'Action Plan'"
            SQL &= String.Format(" FROM case_main C WHERE `status` = 'ACTIVE' AND BranchID = '{0}';", cbxBranch.SelectedValue)
            cbxCase.DataSource = DataSource(SQL)
            FirstLoad = False
            cbxCase.SelectedIndex = -1
            cbxCase.Text = ""
            If cbxCase.Items.Count = 0 Then
                Clear()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CbxEmployee_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCase.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxCase.SelectedIndex = -1 Or cbxCase.Text = "" Then
            Clear()
        Else
            LoadData()
        End If
    End Sub

    Private Sub FrmITLDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmActivityMonitoring_Load(sender, e)
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.X Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
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

        MsgBox("Print Underconstruction.", MsgBoxStyle.Information, "Info")
    End Sub
End Class