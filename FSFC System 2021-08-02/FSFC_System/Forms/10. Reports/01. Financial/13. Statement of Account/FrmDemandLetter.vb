Public Class FrmDemandLetter

    Private Sub FrmDemandLetter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetCheckBoxFontSettingsDefault({cbx1st, cbx2nd})

            GetButtonFontSettings({btnPrint, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Demand Letter - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click

    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub Cbx1st_CheckedChanged(sender As Object, e As EventArgs) Handles cbx1st.CheckedChanged
        If cbx1st.Checked Then
            cbx2nd.Checked = False
        End If

        If cbx1st.Checked = False And cbx2nd.Checked = False Then
            cbx1st.Checked = True
        End If
    End Sub

    Private Sub Cbx2nd_CheckedChanged(sender As Object, e As EventArgs) Handles cbx2nd.CheckedChanged
        If cbx2nd.Checked Then
            cbx1st.Checked = False
        End If

        If cbx1st.Checked = False And cbx2nd.Checked = False Then
            cbx1st.Checked = True
        End If
    End Sub
End Class