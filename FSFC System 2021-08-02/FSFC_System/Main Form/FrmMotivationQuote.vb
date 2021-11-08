Public Class FrmMotivationQuote

    Private Sub FrmMotivationQuote_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            Close()
        ElseIf e.KeyCode = Keys.Enter And rExplanation.Focus = False Then
            Dim R As New Random()
            Try
                PictureEdit1.Image = Image.FromFile(String.Format("{1}{2}\Motivational Quotes\{0}.jpg", R.Next(1, MotivationC), RootFolder, MainFolder))
            Catch ex As Exception
                Try
                    PictureEdit1.Image = Image.FromFile(String.Format("{1}{2}\Motivational Quotes\{0}.jpeg", R.Next(1, MotivationC), RootFolder, MainFolder))
                Catch ex1 As Exception
                End Try
            End Try
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub FrmMotivationQuote_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Logs("Main", "Motivational Quotes", "Close", "", "", "", "")
    End Sub

    Private Sub FrmMotivationQuote_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
    End Sub
End Class