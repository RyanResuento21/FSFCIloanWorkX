Public Class FrmSystemSettings

    Private Sub FrmSystemSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        txtRoot.Text = RootFolder
        txtRoot.Tag = RootFolder

        txtMainFolder.Text = MainFolder
        txtMainFolder.Tag = MainFolder

        txtReports.Text = ReportFolder
        txtReports.Tag = ReportFolder

        If RootFolder = "\\" & _ServerName Then
            cbxConnected.Checked = True
        End If
        If _DatabaseName.ToUpper = "FSFC_TEST" Or _DatabaseName.ToUpper = "FSFC_MIGRATION" Then
            txtMainFolder.Text = MainFolder.Replace("\Testing", "")
            txtMainFolder.Tag = MainFolder.Replace("\Testing", "")
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelWithBackgroundFontSettings({LabelX6})

            GetLabelFontSettings({LabelX43, LabelX1, LabelX4})

            GetLabelFontSettingsRed({LabelX2, LabelX3})

            GetCheckBoxFontSettings({cbxConnected})

            GetTextBoxFontSettings({txtRoot, txtMainFolder, txtReports})
        Catch ex As Exception
            TriggerBugReport("System Settings - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtMainFolder.Text = "" Then
            MsgBox("Please fill the main folder and publicly shared the folder.", MsgBoxStyle.Information, "Info")
            txtMainFolder.Focus()
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to save this settings?") = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            Dim SQL As String = "UPDATE directory_setup SET"
            SQL &= String.Format(" root_folder = '{0}', ", txtRoot.Text)
            SQL &= String.Format(" main_folder = '{0}', ", txtMainFolder.Text)
            SQL &= String.Format(" report_folder = '{0}' ", txtReports.Text)
            SQL &= " WHERE ID = 1;"

            RootFolder = txtRoot.Text
            If RootFolder = "" Then
                RootFolder = "\\" & _ServerName
            End If
            MainFolder = txtMainFolder.Text
            If _DatabaseName.ToUpper = "FSFC_TEST" Or _DatabaseName.ToUpper = "FSFC_MIGRATION" Then
                MainFolder &= "\Testing"
            End If
            ReportFolder = txtReports.Text

            DataObject(SQL)
            Logs("System Settings", "Update", Reason, Changes(), "", "", "")
            Cursor = Cursors.Default
            MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            Close()
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        If txtRoot.Text = txtRoot.Tag Then
        Else
            Change &= String.Format("Change Root from {0} to {1}. ", txtRoot.Tag, txtRoot.Text)
        End If
        If txtMainFolder.Text = txtMainFolder.Tag Then
        Else
            Change &= String.Format("Change Main Folder from {0} to {1}. ", txtMainFolder.Tag, txtMainFolder.Text)
        End If
        If txtReports.Text = txtReports.Tag Then
        Else
            Change &= String.Format("Change Report Folder from {0} to {1}. ", txtReports.Tag, txtReports.Text)
        End If
        Return Change
    End Function

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("System Settings", lblTitle.Text)
    End Sub

    Private Sub CbxConnected_CheckedChanged(sender As Object, e As EventArgs) Handles cbxConnected.CheckedChanged
        If cbxConnected.Checked Then
            txtRoot.Text = ""
            txtRoot.Enabled = False
        Else
            txtRoot.Enabled = True
        End If
    End Sub

    Private Sub Enter_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRoot.KeyDown, txtMainFolder.KeyDown, txtReports.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtRoot_Leave(sender As Object, e As EventArgs) Handles txtRoot.Leave
        txtRoot.Text = ReplaceText(txtRoot.Text)
    End Sub

    Private Sub TxtMainFolder_Leave(sender As Object, e As EventArgs) Handles txtMainFolder.Leave
        txtMainFolder.Text = ReplaceText(txtMainFolder.Text)
    End Sub

    Private Sub TxtReports_Leave(sender As Object, e As EventArgs) Handles txtReports.Leave
        txtReports.Text = ReplaceText(txtReports.Text)
    End Sub
End Class