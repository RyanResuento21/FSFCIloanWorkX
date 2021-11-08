Public Class FrmNickName

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX17})

            GetTextBoxFontSettings({txtName})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Nick Name - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtName.Text = "" Then
            MsgBox("Please fill you nick name.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to set you nickname?") = MsgBoxResult.Yes Then
            DataObject(String.Format("UPDATE employee_setup SET Nickname = '{0}' WHERE ID = '{1}'", txtName.Text, Empl_ID))
            Nickname = txtName.Text
            MsgBox("Successfully Changed!", MsgBoxStyle.Information, "Info")
            Close()
        End If
    End Sub

    Private Sub FrmNickName_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        txtName.Text = Nickname
    End Sub

    Private Sub TxtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        txtName.Text = ReplaceText(txtName.Text)
    End Sub

    Private Sub FrmNickName_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.PerformClick()
        End If
    End Sub
End Class