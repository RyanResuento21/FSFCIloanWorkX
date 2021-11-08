Imports DevExpress.XtraCharts
Public Class FrmITLDashboard

    Dim FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date = Date.Now
    Public ToDate As Date = Date.Now
    Private Sub FrmITLDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        Chart1.Location = New Point(12, 326)
        Chart1.Size = New Point(1140, 355)

        FirstLoad = True

        Dim SQL As String = "SELECT "
        SQL &= "    FORMAT(COUNT(ID),0) AS 'Cases',"
        SQL &= "    FORMAT(IFNULL(SUM(Ledger_Balance(AccountNumber,MortgageID)),0),2) AS 'Book Value',"
        SQL &= "    (SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM accounting_entry WHERE PaidFor = 'ITL' AND MotherCode = '112300' AND EntryType = 'CREDIT' AND `status` = 'ACTIVE') AS 'Collected',"

        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'ACTIVE' THEN ID END),0) AS 'Active',"
        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'DISMISSED' THEN ID END),0) AS 'Dismissed',"
        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'ARCHIVED' THEN ID END),0) AS 'Archived',"
        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'WRITTEN OFF' THEN ID END),0) AS 'Written Off',"
        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'FULLY PAID' THEN ID END),0) AS 'Fully Paid'"
        SQL &= String.Format("  FROM case_main WHERE `status` = 'ACTIVE' AND BranchID IN ({0});", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT_Case As DataTable = DataSource(SQL)
        If DT_Case.Rows.Count > 0 Then
            pCases.Text = DT_Case(0)("Cases")
            pBookValue.Text = DT_Case(0)("Book Value")
            pCollected.Text = DT_Case(0)("Collected")

            lblActiveN.Text = DT_Case(0)("Active")
            lblDismissedN.Text = DT_Case(0)("Dismissed")
            lblArchivedN.Text = DT_Case(0)("Archived")
            lblWrittenOffN.Text = DT_Case(0)("Written Off")
            lblFullyPaidN.Text = DT_Case(0)("Fully Paid")

            lblActiveP.Text = FormatNumber((DT_Case(0)("Active") / DT_Case(0)("Cases")) * 100, 2) & " %"
            lblDismissedP.Text = FormatNumber((DT_Case(0)("Dismissed") / DT_Case(0)("Cases")) * 100, 2) & " %"
            lblArchivedP.Text = FormatNumber((DT_Case(0)("Archived") / DT_Case(0)("Cases")) * 100, 2) & " %"
            lblWrittenOffP.Text = FormatNumber((DT_Case(0)("Written Off") / DT_Case(0)("Cases")) * 100, 2) & " %"
            lblFullyPaidP.Text = FormatNumber((DT_Case(0)("Fully Paid") / DT_Case(0)("Cases")) * 100, 2) & " %"
        End If

        SQL = "SELECT "
        SQL &= "    (SELECT Branch_Code FROM branch WHERE ID = case_main.BranchID) AS 'Branch',"
        SQL &= "    COUNT(ID) AS 'Cases'"
        SQL &= String.Format("  FROM case_main WHERE `status` = 'ACTIVE' AND BranchID IN ({0}) GROUP BY BranchID ORDER BY `Cases` DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT_BranchCase As DataTable = DataSource(SQL)
        If DT_BranchCase.Rows.Count > 0 Then
            lblCase1B.Text = "1. " & DT_BranchCase(0)("Branch")
            lblCase1N.Text = DT_BranchCase(0)("Cases")
            lblCase1P.Text = FormatNumber((DT_BranchCase(0)("Cases") / DT_Case(0)("Cases")) * 100, 2) & " %"

            If DT_BranchCase.Rows.Count > 1 Then
                lblCase2B.Text = "2. " & DT_BranchCase(1)("Branch")
                lblCase2N.Text = DT_BranchCase(1)("Cases")
                lblCase2P.Text = FormatNumber((DT_BranchCase(1)("Cases") / DT_Case(0)("Cases")) * 100, 2) & " %"
            End If

            If DT_BranchCase.Rows.Count > 2 Then
                lblCase3B.Text = "3. " & DT_BranchCase(2)("Branch")
                lblCase3N.Text = DT_BranchCase(2)("Cases")
                lblCase3P.Text = FormatNumber((DT_BranchCase(2)("Cases") / DT_Case(0)("Cases")) * 100, 2) & " %"
            End If

            If DT_BranchCase.Rows.Count > 3 Then
                lblCase4B.Text = "4. " & DT_BranchCase(3)("Branch")
                lblCase4N.Text = DT_BranchCase(3)("Cases")
                lblCase4P.Text = FormatNumber((DT_BranchCase(3)("Cases") / DT_Case(0)("Cases")) * 100, 2) & " %"
            End If

            If DT_BranchCase.Rows.Count > 4 Then
                lblCase5B.Text = "5. " & DT_BranchCase(4)("Branch")
                lblCase5N.Text = DT_BranchCase(4)("Cases")
                lblCase5P.Text = FormatNumber((DT_BranchCase(4)("Cases") / DT_Case(0)("Cases")) * 100, 2) & " %"
            End If
        End If

        SQL = "SELECT "
        SQL &= "    (SELECT Branch_Code FROM branch WHERE ID = case_main.BranchID) AS 'Branch',"
        SQL &= "    FORMAT(SUM(Ledger_Balance(AccountNumber,MortgageID)),2) AS 'Book Value'"
        SQL &= String.Format("  FROM case_main WHERE `status` = 'ACTIVE' AND BranchID IN ({0}) GROUP BY BranchID ORDER BY `Book Value` DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT_BranchBV As DataTable = DataSource(SQL)
        If DT_BranchBV.Rows.Count > 0 Then
            lblBV1B.Text = "1. " & DT_BranchBV(0)("Branch")
            lblBV1A.Text = DT_BranchBV(0)("Book Value")
            lblBV1P.Text = FormatNumber((DT_BranchBV(0)("Book Value") / DT_Case(0)("Book Value")) * 100, 2) & " %"

            If DT_BranchBV.Rows.Count > 1 Then
                lblBV2B.Text = "2. " & DT_BranchBV(1)("Branch")
                lblBV2A.Text = DT_BranchBV(1)("Book Value")
                lblBV2P.Text = FormatNumber((DT_BranchBV(1)("Book Value") / DT_Case(0)("Book Value")) * 100, 2) & " %"
            End If

            If DT_BranchBV.Rows.Count > 2 Then
                lblBV3B.Text = "3. " & DT_BranchBV(2)("Branch")
                lblBV3A.Text = DT_BranchBV(2)("Book Value")
                lblBV3P.Text = FormatNumber((DT_BranchBV(2)("Book Value") / DT_Case(0)("Book Value")) * 100, 2) & " %"
            End If

            If DT_BranchBV.Rows.Count > 3 Then
                lblBV4B.Text = "4. " & DT_BranchBV(3)("Branch")
                lblBV4A.Text = DT_BranchBV(3)("Book Value")
                lblBV4P.Text = FormatNumber((DT_BranchBV(3)("Book Value") / DT_Case(0)("Book Value")) * 100, 2) & " %"
            End If

            If DT_BranchBV.Rows.Count > 4 Then
                lblBV5B.Text = "5. " & DT_BranchBV(4)("Branch")
                lblBV5A.Text = DT_BranchBV(4)("Book Value")
                lblBV5P.Text = FormatNumber((DT_BranchBV(4)("Book Value") / DT_Case(0)("Book Value")) * 100, 2) & " %"
            End If
        End If

        SQL = "SELECT "
        SQL &= "    (SELECT Branch_Code FROM branch WHERE ID = case_main.BranchID) AS 'Branch',"
        SQL &= "    (SELECT FORMAT(IFNULL(SUM(Amount),0),2) FROM accounting_entry WHERE `status` = 'ACTIVE' AND PostStatus = 'POSTED' AND EntryType = 'DEBIT' AND MotherCode = '112300' AND Branch_ID = case_main.BranchID) AS 'Collected'"
        SQL &= String.Format("  FROM case_main WHERE `status` = 'ACTIVE' AND BranchID IN ({0}) GROUP BY BranchID ORDER BY `Collected` DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        Dim DT_BranchCollected As DataTable = DataSource(SQL)
        If DT_BranchCollected.Rows.Count > 0 Then
            lblCollected1B.Text = "1. " & DT_BranchCollected(0)("Branch")
            lblCollected1A.Text = DT_BranchCollected(0)("Collected")
            lblCollected1P.Text = FormatNumber((DT_BranchCollected(0)("Collected") / DT_Case(0)("Collected")) * 100, 2) & " %"

            If DT_BranchCollected.Rows.Count > 1 Then
                lblCollected2B.Text = "2. " & DT_BranchCollected(1)("Branch")
                lblCollected2A.Text = DT_BranchCollected(1)("Collected")
                lblCollected2P.Text = FormatNumber((DT_BranchCollected(1)("Collected") / DT_Case(0)("Collected")) * 100, 2) & " %"
            End If

            If DT_BranchCollected.Rows.Count > 2 Then
                lblCollected3B.Text = "3. " & DT_BranchCollected(2)("Branch")
                lblCollected3A.Text = DT_BranchCollected(2)("Collected")
                lblCollected3P.Text = FormatNumber((DT_BranchCollected(2)("Collected") / DT_Case(0)("Collected")) * 100, 2) & " %"
            End If

            If DT_BranchCollected.Rows.Count > 3 Then
                lblCollected4B.Text = "4. " & DT_BranchCollected(3)("Branch")
                lblCollected4A.Text = DT_BranchCollected(3)("Collected")
                lblCollected4P.Text = FormatNumber((DT_BranchCollected(3)("Collected") / DT_Case(0)("Collected")) * 100, 2) & " %"
            End If

            If DT_BranchCollected.Rows.Count > 4 Then
                lblCollected5B.Text = "5. " & DT_BranchCollected(4)("Branch")
                lblCollected5A.Text = DT_BranchCollected(4)("Collected")
                lblCollected5P.Text = FormatNumber((DT_BranchCollected(4)("Collected") / DT_Case(0)("Collected")) * 100, 2) & " %"
            End If
        End If

        LineChart(Chart1)

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX14, LabelX13, lblActiveN, lblActiveP, lblDismissedN, lblDismissedP, lblArchivedN, lblArchivedP, lblWrittenOffN, lblWrittenOffP, lblFullyPaidN, lblFullyPaidP, LabelX37, LabelX34, LabelX33, lblCase1B, lblCase1N, lblCase1P, lblCase2B, lblCase2N, lblCase2P, lblCase3B, lblCase3N, lblCase3P, lblCase4B, lblCase4N, lblCase4P, lblCase5B, lblCase5N, lblCase5P, LabelX21, LabelX49, LabelX48, lblBV1B, lblBV1A, lblBV1P, lblBV2B, lblBV2A, lblBV2P, lblBV3B, lblBV3A, lblBV3P, lblBV4B, lblBV4A, lblBV4P, lblBV5B, lblBV5A, lblBV5P, LabelX1, LabelX17, LabelX12, lblCollected1B, lblCollected1A, lblCollected1P, lblCollected2B, lblCollected2A, lblCollected2P, lblCollected3B, lblCollected3A, lblCollected3P, lblCollected4B, lblCollected4A, lblCollected4P, lblCollected5B, lblCollected5A, lblCollected5P})

            GetLabelFontSettingsDefault({LabelX16, LabelX15, LabelX19, LabelX22, LabelX54})

            GetLabelFontSettingsDashboardTitle({LabelX155, LabelX61, LabelX62})

            GetButtonFontSettings({btnChangeView})

            GetLabelFontSettingsDashboardPanel({pCases, pBookValue, pCollected})

            GetGroupControlFontSettings({gCivilStatus, GroupControl2, GroupControl3, GroupControl1})

            GetChartTitleControlFontSettings({Chart1})
        Catch ex As Exception
            TriggerBugReport("ITL Dashboard - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnChangeView_Click(sender As Object, e As EventArgs) Handles btnChangeView.Click
        Dim Change As New FrmChangeView
        With Change
            If .ShowDialog = DialogResult.OK Then
                Display = .cbxDisplay.Text
                FromDate = .dtpFrom.Value
                ToDate = .dtpTo.Value
                LineChart(Chart1)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Dim SQL As String = "SELECT B.ID,"
        SQL &= "    Branch_Code,"
        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'ACTIVE' THEN C.ID END),0) AS 'Active',"
        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'DISMISSED' THEN C.ID END),0) AS 'Dismissed',"
        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'ARCHIVED' THEN C.ID END),0) AS 'Archived',"
        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'WRITTEN OFF' THEN C.ID END),0) AS 'Written Off',"
        SQL &= "    FORMAT(COUNT(CASE WHEN case_status = 'FULLY PAID' THEN C.ID END),0) AS 'Fully Paid'"
        SQL &= " FROM branch B LEFT JOIN (SELECT ID, case_status, BranchID FROM case_main WHERE `status` = 'ACTIVE') C ON B.BranchID = C.BranchID WHERE `status` = 'ACTIVE' GROUP BY B.BranchID ORDER BY B.BranchID;"
        Dim DT_Cases As DataTable = DataSource(SQL)

        Chart.Series.Clear()
        For x As Integer = 0 To DT_Cases.Rows.Count - 1
            Dim Series1 As New Series(DT_Cases(x)(2), ViewType.Bar)
            Dim Series2 As New Series(DT_Cases(x)(3), ViewType.Bar)
            Dim Series3 As New Series(DT_Cases(x)(4), ViewType.Bar)
            Dim Series4 As New Series(DT_Cases(x)(5), ViewType.Bar)
            Dim Series5 As New Series(DT_Cases(x)(6), ViewType.Bar)
            Series1.Name = "Active"
            Series2.Name = "Dismissed"
            Series3.Name = "Archived"
            Series4.Name = "Written Off"
            Series5.Name = "Fully Paid"
            Series1.Points.Add(New SeriesPoint(DT_Cases(x)(1), DT_Cases(x)(2)))
            Series2.Points.Add(New SeriesPoint(DT_Cases(x)(1), DT_Cases(x)(3)))
            Series3.Points.Add(New SeriesPoint(DT_Cases(x)(1), DT_Cases(x)(4)))
            Series4.Points.Add(New SeriesPoint(DT_Cases(x)(1), DT_Cases(x)(5)))
            Series5.Points.Add(New SeriesPoint(DT_Cases(x)(1), DT_Cases(x)(6)))
            With Chart
                .Series.Add(Series1)
                .Series.Add(Series2)
                .Series.Add(Series3)
                .Series.Add(Series4)
                .Series.Add(Series5)
            End With
        Next
    End Sub

    Private Sub FrmITLDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmITLDashboard_Load(sender, e)
        ElseIf e.Control And e.KeyCode = Keys.X Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.btnReport_Click(sender, e)
        End If
    End Sub
End Class