Public Class frmProgramHistoryV3

    'Private Sub btnHistory_Click(sender As Object, e As EventArgs) Handles btnHistory.Click
    '    Me.Cursor = Cursors.WaitCursor
    '    If MsgBox("Are you sure you want to open the old version updates? This might take for a while.", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
    '        Dim History As New frmProgramHistoryV4
    '        With History
    '            .ShowDialog()
    '            .Dispose()
    '        End With
    '        Me.Close()
    '    End If
    '    Me.Cursor = Cursors.Default
    'End Sub

    Private Sub frmProgramHistory_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        With frmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        ElseIf e.KeyCode = Keys.F12 Then
            frmMain.btnReport_Click(sender, e)
        End If
    End Sub

    Private Sub frmProgramHistoryV3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
    End Sub
End Class