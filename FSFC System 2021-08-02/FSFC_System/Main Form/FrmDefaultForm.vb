Public Class FrmDefaultForm

    Private Sub FrmDefaultForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 6, 1, True)
        With cbxForm
            .DisplayMember = "Form"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, CONCAT('[', module, '] ', IF(`group` = '','',CONCAT('(',`group`,') ')), form) AS 'Form' FROM form_setup WHERE `status` = 'ACTIVE' ORDER BY order_id;")
            .SelectedValue = DefaultForm
            .Tag = .Text
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX1})

            GetComboBoxFontSettings({cbxForm})

            GetButtonFontSettings({btnSelect, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Default Form - Fix UI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If cbxForm.SelectedIndex = -1 Or cbxForm.Text = "" Then
            MsgBox("Please select form.", MsgBoxStyle.Information, "Info")
            cbxForm.DroppedDown = True
            Exit Sub
        End If

        If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
            DefaultForm = cbxForm.SelectedValue
            DataObject(String.Format("UPDATE users SET form_id = '{2}' WHERE user_code = '{1}'", User_ID, User_Code, ValidateComboBox(cbxForm)))
            Logs("Default Form", "Set", "", If(cbxForm.Text <> cbxForm.Tag, String.Format("Change default form {0} to {1}", cbxForm.Tag, cbxForm.Text), ""), "", "", "")
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            FrmMain.btnHome.PerformClick()
            Close()
        End If
    End Sub

    Private Sub CbxForm_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxForm.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSelect.Focus()
            btnSelect.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub
End Class