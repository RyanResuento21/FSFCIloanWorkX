Public Class FrmCreditBusinessCenter

    Public CreditNumber As String
    Dim FirstLoad As Boolean
    Public vBusinessCenter As String
    Private Sub FrmCreditBusinessCenter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FirstLoad = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        With cbxBusinessCenter
            .ValueMember = "ID"
            .DisplayMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter.Copy
            .SelectedValue = vBusinessCenter
            .Tag = .Text
        End With

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelWithBackgroundFontSettings({LabelX110})

            GetButtonFontSettings({btnSave, btnCancel})

            GetComboBoxFontSettings({cbxBusinessCenter})
        Catch ex As Exception
            TriggerBugReport("Credit Business Center - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub FrmROPOA_Referral_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim SQL As String = "UPDATE credit_application SET"
                SQL &= String.Format(" BusinessID = '{0}' ", ValidateComboBox(cbxBusinessCenter))
                SQL &= String.Format(" WHERE CreditNumber = '{0}';", CreditNumber)
                DataObject(SQL)
                Logs("Business Center Update", "Update", String.Format("Update Business Center Information for Credit Number {0}", CreditNumber), Changes(), "", "", "")
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxBusinessCenter.Text = cbxBusinessCenter.Tag Then
            Else
                Change &= String.Format("Change Business Center from {0} to {1}. ", cbxBusinessCenter.Tag, cbxBusinessCenter.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Credit Business Center - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function
End Class