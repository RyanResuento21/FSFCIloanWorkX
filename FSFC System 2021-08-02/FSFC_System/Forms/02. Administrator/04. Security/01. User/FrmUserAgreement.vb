Public Class FrmUserAgreement

    Dim PassSecs As Integer = 10
    Public AgreeDate As String
    Private Sub FrmUserAgreement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        If AgreeDate = "" Then
            Timer_Date.Start()
        Else
            cbxAgreement.Checked = True
            lblTimer.Visible = False
            btnOK.Visible = False
            btnCancel.Location = btnOK.Location
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({lblAgreement})

            GetLabelFontSettingsRed({lblTimer})

            GetButtonFontSettings({btnOK, btnCancel})

            GetCheckBoxFontSettings({cbxAgreement})
        Catch ex As Exception
            TriggerBugReport("User Agreement - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub Timer_Date_Tick(sender As Object, e As EventArgs) Handles Timer_Date.Tick
        lblTimer.Text = "I Agree will be open in " & PassSecs & " second(s)"
        If PassSecs = 0 Then
            cbxAgreement.Enabled = True
            Timer_Date.Stop()
            lblTimer.Visible = False
        End If
        PassSecs -= 1
    End Sub

    Private Sub CbxAgreement_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgreement.CheckedChanged
        If cbxAgreement.Checked Then
            btnOK.Enabled = True
        Else
            btnOK.Enabled = False
        End If
    End Sub

    Private Sub BtnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        If btnOK.DialogResult = DialogResult.OK Then
        Else
            btnOK.DialogResult = DialogResult.OK
            btnOK.PerformClick()
        End If
    End Sub

    Private Sub FrmUserAgreement_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.Escape Then
            If AgreeDate <> "" Then
                Close()
            End If
        End If
    End Sub
End Class