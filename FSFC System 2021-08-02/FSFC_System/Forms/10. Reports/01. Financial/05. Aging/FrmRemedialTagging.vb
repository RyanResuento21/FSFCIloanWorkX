Public Class FrmRemedialTagging

    Public Remedial As Integer = 0
    Private Sub FrmRemedialTagging_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FixUI(AllowStandardUI)

        With cbxRemedial
            .ValueMember = "ID"
            .DisplayMember = "Remedial"
            .DataSource = DataSource(String.Format("SELECT ID, Remedial FROM remedial_setup WHERE `status` = 'ACTIVE' ORDER BY RemedialCode;", Branch_ID))
            .SelectedValue = Remedial
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({lblDeposit})

            GetComboBoxFontSettings({cbxRemedial})

            GetButtonFontSettings({btnTag, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Remedial Tagging - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnTag_Click(sender As Object, e As EventArgs) Handles btnTag.Click
        If btnTag.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure about this Remedial?") = MsgBoxResult.Yes Then
                btnTag.DialogResult = DialogResult.OK
                btnTag.PerformClick()
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub CbxRemedial_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxRemedial.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnTag.Focus()
            btnTag.PerformClick()
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class