Public Class FrmRedemptionPeriod

    Public AssetNumber As String
    Public Type As String
    Private Sub FrmRedemptionPeriod_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX2, lblCOS, LabelX36, LabelX3, LabelX4, LabelX6, lblAssetN, LabelX7, lblAccountN, LabelX8, lblTCTN, LabelX9, lblArea})

            GetLabelFontSettingsRed({LabelX5})

            GetTextBoxFontSettings({txtTCT})

            GetIntegerInputFontSettings({iDays})

            GetDateTimeInputFontSettings({dtpReceived, dtpCOS, dtpConsolidation})

            GetButtonFontSettings({btnSave, btnRefresh, btnCancel, btnDelete})
        Catch ex As Exception
            TriggerBugReport("Redemption Period - FixUI", ex.Message.ToString)
        End Try
    End Sub

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
        OpenFormHistory("Redemption", lblTitle.Text)
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
        If e.Control And e.KeyCode = Keys.R Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub DtpReceived_ValueChanged(sender As Object, e As EventArgs) Handles dtpReceived.ValueChanged
        dtpCOS.MinDate = dtpReceived.Value

        iDays.Value = DateDiff(DateInterval.Day, dtpReceived.Value, dtpCOS.Value)
    End Sub

    Private Sub DtpCOS_ValueChanged(sender As Object, e As EventArgs) Handles dtpCOS.ValueChanged
        iDays.Value = DateDiff(DateInterval.Day, dtpReceived.Value, dtpCOS.Value)
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            dtpReceived.Value = Date.Now
            dtpCOS.Value = Date.Now
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If dtpCOS.Value < dtpReceived.Value Then
            MsgBox("Received Received COS Date cannot be ealier than the COS Annotation Date. Please check your data.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If btnSave.Text = "&Redemption" Then
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    btnSave.DialogResult = DialogResult.OK
                    MsgBox("Successfully Redempted!", MsgBoxStyle.Information, "Info")
                    btnSave.PerformClick()
                End If
            ElseIf btnSave.Text = "Consolidate" Then
                If dtpConsolidation.CustomFormat = "" Then
                    MsgBox("Please fill Consolidation Date.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If dtpConsolidation.Value < dtpCOS.Value Then
                    MsgBox("COS Annotation Date cannot be ealier than the Consolidation Date. Please check your data.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If txtTCT.Text.Trim = "" Then
                    MsgBox("Please fill TCT field.", MsgBoxStyle.Information, "Info")
                    txtTCT.Focus()
                    Exit Sub
                End If
                If MsgBoxYes("Are you sure this is the considation date?") = MsgBoxResult.Yes Then
                    If Type = "Real Estate" Then
                        DataObject(String.Format("UPDATE ropoa_realestate SET Consolidation_Date = '{1}', TCT_New = '{2}' WHERE AssetNumber = '{0}'", AssetNumber, Format(dtpConsolidation.Value, "yyyy-MM-dd"), txtTCT.Text))
                        Logs("Redemption", "Consolidate", String.Format("Consolidate Asset Number {0} with date {1}", AssetNumber, dtpConsolidation.Text), "", "", "", "")
                    End If
                    btnSave.DialogResult = DialogResult.OK
                    MsgBox("Successfully Consolidated!", MsgBoxStyle.Information, "Info")
                    btnSave.PerformClick()
                End If
            ElseIf btnSave.Text = "Update" Then ' U P D A T E
                If dtpConsolidation.CustomFormat = "" Then
                Else
                    If dtpConsolidation.Value < dtpCOS.Value Then
                        MsgBox("COS Annotation Date cannot be ealier than the Consolidation Date. Please check your data.", MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If
                If txtTCT.Text.Trim = "" Then
                    MsgBox("Please fill TCT field.", MsgBoxStyle.Information, "Info")
                    txtTCT.Focus()
                    Exit Sub
                End If
                If MsgBoxYes("Are you sure this is the considation date?") = MsgBoxResult.Yes Then
                    If Type = "Real Estate" Then
                        DataObject(String.Format("UPDATE ropoa_realestate SET Consolidation_Date = '{1}', TCT_New = '{2}' WHERE AssetNumber = '{0}'", AssetNumber, If(dtpConsolidation.CustomFormat = "", "", Format(dtpConsolidation.Value, "yyyy-MM-dd")), txtTCT.Text))
                        Logs("Redemption", "Update", String.Format("Update Asset Number {0} with date {1}", AssetNumber, dtpConsolidation.Text), "", "", "", "")
                    End If
                    btnSave.DialogResult = DialogResult.OK
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                    btnSave.PerformClick()
                End If
            End If
        End If
    End Sub

    '#KEYDOWN
    Private Sub DtpReceived_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpReceived.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpCOS.Focus()
        End If
    End Sub

    Private Sub DtpCOS_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpCOS.KeyDown
        If e.KeyCode = Keys.Enter Then
            iDays.Focus()
        End If
    End Sub

    Private Sub IDays_KeyDown(sender As Object, e As KeyEventArgs) Handles iDays.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If btnDelete.DialogResult = DialogResult.No Then
        Else
            If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
                btnDelete.DialogResult = DialogResult.No
                MsgBox("Successfully Cancelled!", MsgBoxStyle.Information, "Info")
                btnDelete.PerformClick()
            End If
        End If
    End Sub

    Private Sub TxtTCT_Leave(sender As Object, e As EventArgs) Handles txtTCT.Leave
        txtTCT.Text = ReplaceText(txtTCT.Text)
    End Sub

    Private Sub TxtTCT_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTCT.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub DtpConsolidation_Click(sender As Object, e As EventArgs) Handles dtpConsolidation.Click
        dtpConsolidation.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpConsolidation_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpConsolidation.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTCT.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpConsolidation.CustomFormat = ""
        End If
    End Sub
End Class