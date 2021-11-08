Public Class FrmChangeView

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)

            With dtpFrom
                .Value = monday
                .CustomFormat = "MMMM dd, yyyy"
            End With

            With dtpTo
                .Value = monday.AddDays(6)
                .Enabled = False
                .CustomFormat = "MMMM dd, yyyy"
            End With
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            With dtpFrom
                .Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
                .CustomFormat = "MMMM dd, yyyy"
            End With

            With dtpTo
                .Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
                .Enabled = False
                .CustomFormat = "MMMM dd, yyyy"
            End With
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            With dtpFrom
                .Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
                .CustomFormat = "MMMM dd, yyyy"
            End With

            With dtpTo
                .Value = DateValue(Format(Date.Now, "yyyy-MM-15"))
                .Enabled = False
                .CustomFormat = "MMMM dd, yyyy"
            End With
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            With dtpFrom
                .Value = DateValue(Format(Date.Now, "yyyy-MM-16"))
                .CustomFormat = "MMMM dd, yyyy"
            End With

            With dtpTo
                .Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
                .Enabled = False
                .CustomFormat = "MMMM dd, yyyy"
            End With
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            With dtpFrom
                .Value = DateValue(Format(Date.Now, "yyyy-01-01"))
                .CustomFormat = "MMMM dd, yyyy"
            End With

            With dtpTo
                .Value = DateValue(Format(Date.Now, "yyyy-12-31"))
                .Enabled = False
                .CustomFormat = "MMMM dd, yyyy"
            End With
        End If
    End Sub

    Private Sub FrmChangeView_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSelect.Focus()
            btnSelect.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.C) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub DtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpTo.Value = dtpFrom.Value.AddDays(6)
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            dtpTo.Value = DateValue(Format(dtpFrom.Value, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(dtpFrom.Value, "yyyy"), Format(dtpFrom.Value, "MM")))))
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpTo.Value = DateValue(Format(dtpFrom.Value, "yyyy-MM-15"))
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpTo.Value = DateValue(Format(dtpFrom.Value, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(dtpFrom.Value, "yyyy"), Format(dtpFrom.Value, "MM")))))
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpTo.Value = DateValue(Format(dtpFrom.Value, "yyyy-12-31"))
        End If
    End Sub

    Private Sub FrmChangeView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cbxDisplay.SelectedIndex = 4
        FixUI(AllowStandardUI)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX155, LabelX10, LabelX1})

            GetComboBoxFontSettings({cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSelect, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Change View - FixUI", ex.Message.ToString)
        End Try
    End Sub
End Class