Imports DevExpress.XtraCharts
Public Class FrmDashboard

    Dim Vehicle As Integer
    Dim RealEstate As Integer
    Dim Salary As Integer
    Dim PayDay As Integer
    Dim Total As Integer
    Dim Income As Integer
    Private Sub FrmDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        Vehicle = CInt(pVehicle.Text)
        RealEstate = CInt(pRealEstate.Text)
        Salary = CInt(pSalary.Text)
        PayDay = CInt(pPayDay.Text)
        Total = CInt(pTotal.Text)
        Income = CInt(pIncome.Text.Replace("P", ""))

        Chart2(ChartControl2)
        Timer_Update.Start()
    End Sub

    Private Sub Timer_Update_Tick(sender As Object, e As EventArgs) Handles Timer_Update.Tick
        Try
            Dim R As New Random()
            Vehicle += R.Next(0, 2)
            RealEstate += R.Next(0, 2)
            Salary += R.Next(0, 2)
            PayDay += R.Next(0, 2)
            Total = Vehicle + RealEstate + Salary + PayDay
            Income += R.Next(500000, 700000)
            pVehicle.Text = FormatNumber(Vehicle, 0)
            pRealEstate.Text = FormatNumber(RealEstate, 0)
            pSalary.Text = FormatNumber(Salary, 0)
            pPayDay.Text = FormatNumber(PayDay, 0)
            pTotal.Text = FormatNumber(Total, 0)
            pIncome.Text = "P" & FormatNumber(Income, 0)
            Chart2(ChartControl2)
        Catch ex As Exception
            TriggerBugReport("Dashboard - TimerUpdateTick", ex.Message.ToString)
        End Try
    End Sub

    Public Sub Chart2(Chart As ChartControl)
        Dim Product As New DataTable
        With Product
            .Columns.Add("Product")
            .Columns.Add("Income")
            .Rows.Add("Vehicle", Vehicle)
            .Rows.Add("RealEstate", RealEstate)
            .Rows.Add("Salary", Salary)
            .Rows.Add("PayDay", PayDay)
        End With
        ' Create a pie chart
        Chart.Series.Clear()
        Dim Series1 As New Series("Top Product", ViewType.Pie)

        For x As Integer = 0 To Product.Rows.Count - 1
            Series1.Points.Add(New SeriesPoint(Product(x)("Product"), Product(x)("Income")))
        Next

        Chart.Series.Add(Series1)

        CType(Series1.Label, PieSeriesLabel).ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default

        Dim myView As PieSeriesView = CType(Series1.View, PieSeriesView)
    End Sub

    Private Sub FrmDashboard_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.F Then
            FrmDashboard_Load(sender, e)
        ElseIf e.Control And e.KeyCode = Keys.X Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class