Public Class FrmReportTable

    Public Title As String
    Public ExistValue As String()
    Private Sub FrmReportTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView4})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetButtonFontSettings({btnCancel, btnPrint})
        Catch ex As Exception
            TriggerBugReport("Report Table - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        GridView4.BestFitColumns()
        GridView4.OptionsPrint.UsePrintStyles = False
        StandardPrinting(Title, GridControl4)
        Logs(Title, "Print", "Print Report Table", "", "", "", "")
    End Sub

    Private Sub FrmReportTable_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
End Class