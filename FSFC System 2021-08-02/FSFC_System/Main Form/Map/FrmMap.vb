Public Class FrmMap
    Public Place As String
    Private Sub FrmMap_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        WebBrowser1.Navigate(String.Format("https://www.google.com.ph/maps/place/{0}", Place.Replace(" ", "+").Replace("#", "")))
    End Sub

    Private Sub FrmMap_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.KeyCode = Keys.Escape Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class