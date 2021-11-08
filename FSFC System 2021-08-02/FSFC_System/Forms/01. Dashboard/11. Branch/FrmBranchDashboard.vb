Public Class FrmBranchDashboard

    Dim FirstLoad As Boolean = True
    'Public Display As String = "Selected Year (Per Month)"
    'Public FromDate As Date = Date.Now
    'Public ToDate As Date = Date.Now
    'Private TotalApplication As Integer

    Private Sub FrmCreditDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        With c1
            .Size = New Point(340, 223)
            .Location = New Point(820, 94)
        End With
        With Chart1
            .Size = New Point(573, 129)
            .Location = New Point(8, 558)
        End With
        With Chart2
            .Size = New Point(573, 129)
            .Location = New Point(588, 558)
        End With
        With Chart3
            .Size = New Point(622, 102)
            .Location = New Point(539, 323)
        End With
        'FixUI(AllowStandardUI)

        FirstLoad = True

        'LoadData()
        'LineChart(Chart1)

        FirstLoad = False
    End Sub
End Class