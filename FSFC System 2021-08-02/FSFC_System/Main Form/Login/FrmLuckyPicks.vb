Public Class FrmLuckyPicks

    Dim DT_Results As DataTable
    ReadOnly LuckyRandom As New Random() 'Lucky Random
    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MsgBox("Are you sure you want to save this draw? Goodluck Kevs!", MsgBoxStyle.YesNo, "Info") = MsgBoxResult.Yes Then
            Dim SQL As String = "INSERT INTO lotto_saved SET"
            SQL &= String.Format(" Lucky_1 = '{0}',", lblLucky1.Text)
            SQL &= String.Format(" Lucky_2 = '{0}',", lblLucky2.Text)
            SQL &= String.Format(" Lucky_3 = '{0}',", lblLucky3.Text)
            SQL &= String.Format(" Lucky_4 = '{0}',", lblLucky4.Text)
            SQL &= String.Format(" Lucky_5 = '{0}',", lblLucky5.Text)
            SQL &= String.Format(" Lucky_6 = '{0}'", lblLucky6.Text)
            DataObject(SQL)
            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            Clear()
        End If
    End Sub

    Private Sub BtnDraw_Click(sender As Object, e As EventArgs) Handles btnDraw.Click
        btnDraw.Enabled = False
        cbxBase.Enabled = False
        If cbxBase.Checked Then
            lblLucky1.Text = LuckyRandom.Next(1, 58)
            lblLucky2.Text = LuckyPick(2, lblLucky1.Text, LuckyRandom.Next(1, 58), 0, 0, 0, 0)
            lblLucky3.Text = LuckyPick(3, lblLucky1.Text, lblLucky2.Text, LuckyRandom.Next(1, 58), 0, 0, 0)
            lblLucky4.Text = LuckyPick(4, lblLucky1.Text, lblLucky2.Text, lblLucky3.Text, LuckyRandom.Next(1, 58), 0, 0)
            lblLucky5.Text = LuckyPick(5, lblLucky1.Text, lblLucky2.Text, lblLucky3.Text, lblLucky4.Text, LuckyRandom.Next(1, 58), 0)
            lblLucky6.Text = LuckyPick(6, lblLucky1.Text, lblLucky2.Text, lblLucky3.Text, lblLucky4.Text, lblLucky5.Text, LuckyRandom.Next(1, 58))
        Else
            lblLucky1.Text = DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6)))
            lblLucky2.Text = LuckyResults(2, lblLucky1.Text, DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6))), 0, 0, 0, 0)
            lblLucky3.Text = LuckyResults(3, lblLucky1.Text, lblLucky2.Text, DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6))), 0, 0, 0)
            lblLucky4.Text = LuckyResults(4, lblLucky1.Text, lblLucky2.Text, lblLucky3.Text, DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6))), 0, 0)
            lblLucky5.Text = LuckyResults(5, lblLucky1.Text, lblLucky2.Text, lblLucky3.Text, lblLucky4.Text, DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6))), 0)
            lblLucky6.Text = LuckyResults(6, lblLucky1.Text, lblLucky2.Text, lblLucky3.Text, lblLucky4.Text, lblLucky5.Text, DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6))))
        End If
        btnSave.Enabled = True
    End Sub

    Private Function LuckyPick(Digit As Integer, Lucky1 As Integer, Lucky2 As Integer, Lucky3 As Integer, Lucky4 As Integer, Lucky5 As Integer, Lucky6 As Integer)
        Dim LuckyNumber As Integer
        If Digit = 2 Then
            LuckyNumber = Lucky2
LuckyAgain_2:
            If Lucky1 = Lucky2 Then
                LuckyNumber = LuckyRandom.Next(1, 58)
                Lucky2 = LuckyNumber
                GoTo LuckyAgain_2
            End If
        End If

        If Digit = 3 Then
            LuckyNumber = Lucky3
LuckyAgain_3:
            If Lucky1 = Lucky3 Or Lucky2 = Lucky3 Then
                LuckyNumber = LuckyRandom.Next(1, 58)
                Lucky3 = LuckyNumber
                GoTo LuckyAgain_3
            End If
        End If

        If Digit = 4 Then
            LuckyNumber = Lucky4
LuckyAgain_4:
            If Lucky1 = Lucky4 Or Lucky2 = Lucky4 Or Lucky3 = Lucky4 Then
                LuckyNumber = LuckyRandom.Next(1, 58)
                Lucky4 = LuckyNumber
                GoTo LuckyAgain_4
            End If
        End If

        If Digit = 5 Then
            LuckyNumber = Lucky5
LuckyAgain_5:
            If Lucky1 = Lucky5 Or Lucky2 = Lucky5 Or Lucky3 = Lucky5 Or Lucky4 = Lucky5 Then
                LuckyNumber = LuckyRandom.Next(1, 58)
                Lucky5 = LuckyNumber
                GoTo LuckyAgain_5
            End If
        End If

        If Digit = 6 Then
            LuckyNumber = Lucky6
LuckyAgain_6:
            If Lucky1 = Lucky6 Or Lucky2 = Lucky6 Or Lucky3 = Lucky6 Or Lucky4 = Lucky6 Or Lucky5 = Lucky6 Then
                LuckyNumber = LuckyRandom.Next(1, 58)
                Lucky6 = LuckyNumber
                GoTo LuckyAgain_6
            End If
        End If
        Return LuckyNumber
    End Function

    Private Function LuckyResults(Digit As Integer, Lucky1 As Integer, Lucky2 As Integer, Lucky3 As Integer, Lucky4 As Integer, Lucky5 As Integer, Lucky6 As Integer)
        Dim LuckyNumber As Integer
        If Digit = 2 Then
            LuckyNumber = Lucky2
LuckyAgain_2:
            If Lucky1 = Lucky2 Then
                LuckyNumber = DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6)))
                Lucky2 = LuckyNumber
                GoTo LuckyAgain_2
            End If
        End If

        If Digit = 3 Then
            LuckyNumber = Lucky3
LuckyAgain_3:
            If Lucky1 = Lucky3 Or Lucky2 = Lucky3 Then
                LuckyNumber = DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6)))
                Lucky3 = LuckyNumber
                GoTo LuckyAgain_3
            End If
        End If

        If Digit = 4 Then
            LuckyNumber = Lucky4
LuckyAgain_4:
            If Lucky1 = Lucky4 Or Lucky2 = Lucky4 Or Lucky3 = Lucky4 Then
                LuckyNumber = DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6)))
                Lucky4 = LuckyNumber
                GoTo LuckyAgain_4
            End If
        End If

        If Digit = 5 Then
            LuckyNumber = Lucky5
LuckyAgain_5:
            If Lucky1 = Lucky5 Or Lucky2 = Lucky5 Or Lucky3 = Lucky5 Or Lucky4 = Lucky5 Then
                LuckyNumber = DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6)))
                Lucky5 = LuckyNumber
                GoTo LuckyAgain_5
            End If
        End If

        If Digit = 6 Then
            LuckyNumber = Lucky6
LuckyAgain_6:
            If Lucky1 = Lucky6 Or Lucky2 = Lucky6 Or Lucky3 = Lucky6 Or Lucky4 = Lucky6 Or Lucky5 = Lucky6 Then
                LuckyNumber = DT_Results(LuckyRandom.Next(0, DT_Results.Rows.Count - 1))(String.Format("Result_{0}", LuckyRandom.Next(1, 6)))
                Lucky6 = LuckyNumber
                GoTo LuckyAgain_6
            End If
        End If
        Return LuckyNumber
    End Function

    Private Sub Clear()
        lblLucky1.Text = "-"
        lblLucky2.Text = "-"
        lblLucky3.Text = "-"
        lblLucky4.Text = "-"
        lblLucky5.Text = "-"
        lblLucky6.Text = "-"
        btnDraw.Enabled = True
        btnSave.Enabled = False
        cbxBase.Enabled = True
    End Sub

    Private Sub FrmLottoRandom_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        DT_Results = DataSource("SELECT * FROM lotto_results;")
    End Sub

    Private Sub FrmLottoRandom_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.KeyCode = Keys.Escape Then
            Close()
        End If
    End Sub
End Class