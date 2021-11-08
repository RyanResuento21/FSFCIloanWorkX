Public Class FrmCaseViewingGraph

    Private Sub FrmCaseViewingGraph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        With Chart1
            .Location = New Point(9, 10)
            .Size = New Point(573, 299)
        End With

        With Chart2
            .Location = New Point(589, 10)
            .Size = New Point(573, 299)
        End With

        With Chart3
            .Location = New Point(10, 315)
            .Size = New Point(1153, 284)
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnCancel, btnPrint})

            GetChartTitleControlFontSettings({Chart1, Chart2, Chart3})
        Catch ex As Exception
            TriggerBugReport("Case Viewing Graph - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        MsgBox("Print Underconstruction.", MsgBoxStyle.Information, "Info")
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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