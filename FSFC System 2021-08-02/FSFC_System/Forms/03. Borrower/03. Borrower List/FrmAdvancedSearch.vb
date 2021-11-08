Public Class FrmAdvancedSearch

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub IFrom_ValueChanged(sender As Object, e As EventArgs) Handles iFrom.ValueChanged
        iTo.MinValue = iFrom.Value
        If iTo.Value < iFrom.Value Then
            iTo.Value = iFrom.Value
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        FrmBorrowerList.LoadData()
        Hide()
    End Sub

    Private Sub TxtKeyword_Leave(sender As Object, e As EventArgs) Handles txtKeyword.Leave
        txtKeyword.Text = ReplaceText(txtKeyword.Text)
    End Sub

    Private Sub TxtKeyword_KeyDown(sender As Object, e As KeyEventArgs) Handles txtKeyword.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub IFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles iFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            iTo.PerformClick()
        End If
    End Sub

    Private Sub ITo_KeyDown(sender As Object, e As KeyEventArgs) Handles iTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub FrmAdvancedSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetLabelFontSettings({LabelX17, lblAge, lblTo, lblGender, lblCivil, lblFirm})

            GetTextBoxFontSettings({txtKeyword})

            GetIntegerInputFontSettings({iFrom, iTo})

            GetButtonFontSettings({btnSearch, btnCancel})

            GetCheckBoxFontSettings({cbxMale_B, cbxFemale_B, cbxSingle_B, cbxMarried_B, cbxSeparated_B, cbxWidowed_B, cbxMicro, cbxSmall, cbxMedium, cbxLarge})
        Catch ex As Exception
            TriggerBugReport("Advance Search - FixUI", ex.Message.ToString)
        End Try
    End Sub
End Class