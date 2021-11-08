Public Class FrmRule78

    Dim Loans As Integer = 24
    Private Sub FrmRule78_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        Cursor = Cursors.WaitCursor
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        iTerm.Value = 37
        Loans = iTerm.Value
        For x As Integer = 3 To Loans
            Dim MonthsN As New DevComponents.DotNetBar.LabelX
            Dim LoansN As New DevComponents.DotNetBar.LabelX
            Dim N As Integer = x - 1
            Dim Factor As Integer = 0
            With MonthsN
                .Text = N
                .TextAlignment = StringAlignment.Center
                .Tag = x
                .TabIndex = x
                .BackgroundStyle.Border = lblMonth.BackgroundStyle.Border
                .BackgroundStyle.BorderWidth = lblMonth.BackgroundStyle.BorderWidth
                .BackgroundStyle.BorderColor = lblMonth.BackgroundStyle.BorderColor
                .BackgroundStyle.BorderColor2 = lblMonth.BackgroundStyle.BorderColor2
                .BackColor = lblMonth.BackColor
                .Font = lblMonth.Font
                .ForeColor = lblMonth.ForeColor
                .Size = lblMonth.Size
                .Location = New Point(2, 21 + (19 * (x - 2)))
            End With
            PanelEx2.Controls.Add(MonthsN)

            With LoansN
                If x = Loans Then
                    .Text = ""
                Else
                    .Text = x
                End If
                .TextAlignment = StringAlignment.Center
                .Tag = x
                .TabIndex = x
                .BackgroundStyle.Border = lblLoan2.BackgroundStyle.Border
                .BackgroundStyle.BorderWidth = lblLoan2.BackgroundStyle.BorderWidth
                .BackgroundStyle.BorderColor = lblLoan2.BackgroundStyle.BorderColor
                .BackgroundStyle.BorderColor2 = lblLoan2.BackgroundStyle.BorderColor2
                .BackColor = lblLoan2.BackColor
                .Font = lblLoan2.Font
                .ForeColor = lblLoan2.ForeColor
                .Size = lblLoan2.Size
                .Location = New Point(86 + (42 * (x - 2)), 21 + (19 * (x - 2)))
            End With
            PanelEx2.Controls.Add(LoansN)

            For y As Integer = 1 To x - 1
                Factor = N * (N + 1)
                Dim Result As New DevComponents.DotNetBar.LabelX
                With Result
                    .Text = FormatNumber((((N - y) * ((N - y) + 1)) / Factor) * 100, 2)
                    If CDbl(.Text) = 0 Then
                        .Text = "-"
                    End If
                    .TextAlignment = StringAlignment.Center
                    .Tag = x
                    .TabIndex = x
                    .BackgroundStyle.Border = lbl1_1.BackgroundStyle.Border
                    .BackgroundStyle.BorderWidth = lbl1_1.BackgroundStyle.BorderWidth
                    .BackgroundStyle.BorderColor = lbl1_1.BackgroundStyle.BorderColor
                    .BackgroundStyle.BorderColor2 = lbl1_1.BackgroundStyle.BorderColor2
                    If x Mod 2 = 0 Then
                        .BackColor = lbl1_1.BackColor
                    Else
                        .BackColor = lbl2_1.BackColor
                    End If
                    AddHandler .Click, AddressOf Result_Click
                    .Font = lbl1_1.Font
                    .ForeColor = lbl1_1.ForeColor
                    .Size = lbl1_1.Size
                    .Location = New Point(2 + (42 * y), 21 + (19 * (x - 2)))
                End With
                PanelEx2.Controls.Add(Result)
            Next
        Next
        Cursor = Cursors.Default
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetLabelFontSettings({lblMonth, LabelX16, lblLoan1, LabelX4, lbl1_1, lblLoan2, LabelX3, lbl2_1, lbl2_2, LabelX1, LabelX14, LabelX15, LabelX18, LabelX19, LabelX20, LabelX21, LabelX2})

            GetIntegerInputFontSettings({iTerm})
        Catch ex As Exception
            TriggerBugReport("Rule 78 - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub FrmRule78_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
                Close()
            End If
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub Result_Click(sender As Object, e As MouseEventArgs)
        Dim lbl As DevComponents.DotNetBar.LabelX = CType(sender, DevComponents.DotNetBar.LabelX)
        With lbl
            If e.Button = Windows.Forms.MouseButtons.Left Then
                If .BackColor = OfficialColor2 Then 'Color.Red Then
                Else
                    .Tag = .BackColor.Name.ToString
                End If
                .BackColor = OfficialColor2 'Color.Red
                .ForeColor = Color.White
            ElseIf e.Button = Windows.Forms.MouseButtons.Right Then
                If .BackColor = OfficialColor2 Then 'Color.Red Then
                Else
                    .Tag = .BackColor.Name.ToString
                End If
                .BackColor = Color.FromName(.Tag)
                .ForeColor = Color.Black
            End If
        End With
    End Sub
End Class