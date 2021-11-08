Imports DevExpress.XtraCharts
Public Class FrmAssetDashboardV2

    ReadOnly FirstLoad As Boolean = True
    Public Display As String = "Selected Year (Per Month)"
    Public FromDate As Date = Date.Now
    Public ToDate As Date = Date.Now

    Private Sub FrmAssetDashboardII_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        LineChart(c1)
    End Sub

    Private Sub LineChart(Chart As ChartControl)
        Dim SQL As String
        If Display = "Selected Year (Per Month)" Then
            SQL = "SELECT "
            SQL &= "     B.branch_code AS 'Code',"
            SQL &= "     IF(B.overstayed = 1,COUNT(CASE WHEN TIMESTAMPDIFF(MONTH,R.trans_date, NOW()) > 0 THEN R.AssetNumber END),0) AS 'Count'"
            SQL &= " FROM branch B"
            SQL &= " LEFT JOIN (SELECT R.AssetNumber, R.branch_id, R.trans_date FROM ropoa_vehicle R WHERE R.`status` = 'ACTIVE' AND R.sell_status = 'SELL') R"
            SQL &= "     ON R.branch_id = B.branchID"
            SQL &= " WHERE B.`status` = 'ACTIVE'"
            'SQL &= "     AND B.branchID > 0"
            SQL &= " GROUP BY B.branchID ORDER BY B.branchID;"
        Else
            SQL = "SELECT "
            SQL &= "     B.branch_code AS 'Code',"
            SQL &= String.Format("     IF(B.overstayed = 1,COUNT(CASE WHEN TIMESTAMPDIFF(MONTH,R.trans_date,{0}) > 0 THEN R.AssetNumber END),0) AS 'Count'", FromDate)
            SQL &= " FROM branch B"
            SQL &= " LEFT JOIN (SELECT R.AssetNumber, R.branch_id, R.trans_date FROM ropoa_vehicle R WHERE R.`status` = 'ACTIVE' AND R.sell_status = 'SELL' AND) R"
            SQL &= "     ON R.branch_id = B.branchID"
            SQL &= " WHERE B.`status` = 'ACTIVE'"
            'SQL &= "     AND B.branchID > 0"
            SQL &= " GROUP BY B.branchID ORDER BY B.branchID;"
        End If
        Dim MonthlyRopoa As DataTable = DataSource(SQL)

        ' Create a pie chart
        Chart.Series.Clear()
        Try
            For x As Integer = 0 To MonthlyRopoa.Rows.Count - 1
                Dim Series1 As New Series(MonthlyRopoa(x)("Code"), ViewType.Bar)
                Series1.Points.Add(New SeriesPoint(MonthlyRopoa(x)("Code"), MonthlyRopoa(x)("Count")))
                Chart.Series.Add(Series1)
            Next
        Catch ex As Exception
            TriggerBugReport("Asset Dashboard - LineChart", ex.Message.ToString)
        End Try
    End Sub
End Class