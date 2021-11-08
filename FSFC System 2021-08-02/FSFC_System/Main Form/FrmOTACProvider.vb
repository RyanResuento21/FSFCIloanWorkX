Public Class FrmOTACProvider 

    Public ProviderDept As New DataTable
    Public Provider As New DataTable
    Public FirstLoad As Boolean = True
    Private Sub FrmOTAC_Provider_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FirstLoad = True
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 6, 1, True)
        If cbxAll.Visible Then
            cbxProvider.DataSource = ProviderDept
        End If
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetCheckBoxFontSettings({cbxAll})

            GetLabelFontSettings({LabelX2})

            GetLabelFontSettingsRed({LabelX1})

            GetComboBoxFontSettings({cbxProvider})

            GetButtonFontSettings({btnSelect, btnCancel})
        Catch ex As Exception
            TriggerBugReport("OTAC Provider - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub


    Private Sub FrmOTAC_Provider_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.O Then
            btnSelect.Focus()
            btnSelect.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles btnSelect.Click
        If btnSelect.DialogResult = DialogResult.OK Then
        Else
            If cbxProvider.SelectedIndex = -1 Or cbxProvider.Text = "" Then
                MsgBox("Please select provider.", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If

            MsgBox(String.Format("{0} is selected.", cbxProvider.Text), MsgBoxStyle.Information, "Info")
            btnSelect.DialogResult = DialogResult.OK
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxProvider.DataSource = Provider
        Else
            cbxProvider.DataSource = ProviderDept
        End If
    End Sub
End Class