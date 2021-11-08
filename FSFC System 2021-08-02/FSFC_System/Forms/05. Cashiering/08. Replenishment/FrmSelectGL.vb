Public Class FrmSelectGL

    Public Account As String
    Public From_Adjunct As Boolean
    Public AdjunctAccount As String
    Public AccountID As Integer
    Private Sub FrmSelectGL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        With cbxAccount
            .DisplayMember = "Account"
            .ValueMember = "Account Code"
            If From_Adjunct Then
                .ValueMember = "ID"
                .DataSource = DataSource(String.Format("SELECT ID, Title AS 'Account', `Code` AS 'Account Code', RequiredRemarks AS 'Remarks' FROM account_chart WHERE `status` = 'ACTIVE' AND Main_ID = 0 AND AdjunctAccount = 0 AND ID != {0} ORDER BY `Code`;", AccountID))
            Else
                If CompanyMode = 0 Then
                    .DataSource = DataSource("SELECT Title AS 'Account', `Code` AS 'Account Code', RequiredRemarks AS 'Remarks' FROM account_chart WHERE `status` = 'ACTIVE' AND Main_ID = 0 AND ID > 1 ORDER BY `Code`;")
                Else
                    .DataSource = DataSource("SELECT Title AS 'Account', `Code` AS 'Account Code', RequiredRemarks AS 'Remarks' FROM account_chart WHERE `status` = 'ACTIVE' AND Main_ID > 1 ORDER BY `Code`;")
                End If
            End If
            .SelectedIndex = -1
            .Focus()
        End With
        btnAdd.DialogResult = DialogResult.None
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX4})

            GetComboBoxFontSettings({cbxAccount})

            GetButtonFontSettings({btnAdd, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Select GL - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.DialogResult = DialogResult.OK Then
        Else
            If cbxAccount.SelectedIndex = -1 Or cbxAccount.Text = "" Then
                MsgBox("Please select Account.", MsgBoxStyle.Information, "Info")
                cbxAccount.DroppedDown = True
                Exit Sub
            End If
            If From_Adjunct Then
                If MsgBoxYes(String.Format("Are you sure you want to set this account as the main account of the adjunct account.", AdjunctAccount)) = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
            End If

            cbxAccount.Focus()
            btnAdd.DialogResult = DialogResult.OK
            btnAdd.PerformClick()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub CbxAccount_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAccount.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        End If
    End Sub
End Class