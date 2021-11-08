Public Class FrmCASignatories 

    Public CA_Signatory1 As Boolean
    Public CA_Signatory2 As Boolean
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            FixUI(AllowStandardUI)
            Close()
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettings({LabelX8, LabelX2})

            GetLabelFontSettingsRed({LabelX3})

            GetTextBoxFontSettings({TxtFirstN_S1, TxtMiddleN_S1, TxtLastN_S1, TxtFirstN_S2, TxtMiddleN_S2, TxtLastN_S2})

            GetComboBoxFontSettings({CbxPrefix_S1, cbxSuffix_S1, CbxPrefix_S2, cbxSuffix_S2})

            GetButtonFontSettings({btnSave, btnRefresh, btnCancel})
        Catch ex As Exception
            TriggerBugReport("CA Signatories - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
            With FrmBorrowerCorp
                If CA_Signatory1 Then
                    .vPrefix_S1 = CbxPrefix_S1.Text
                    .vFirstN_S1 = TxtFirstN_S1.Text
                    .vMiddleN_S1 = TxtMiddleN_S1.Text
                    .vLastN_S1 = TxtLastN_S1.Text
                    .vSuffix_S1 = cbxSuffix_S1.Text
                    .vPrefix_S2 = CbxPrefix_S2.Text
                    .vFirstN_S2 = TxtFirstN_S2.Text
                    .vMiddleN_S2 = TxtMiddleN_S2.Text
                    .vLastN_S2 = TxtLastN_S2.Text
                    .vSuffix_S2 = cbxSuffix_S2.Text
                ElseIf CA_Signatory2 Then
                    .vPrefix_S3 = CbxPrefix_S1.Text
                    .vFirstN_S3 = TxtFirstN_S1.Text
                    .vMiddleN_S3 = TxtMiddleN_S1.Text
                    .vLastN_S3 = TxtLastN_S1.Text
                    .vSuffix_S3 = cbxSuffix_S1.Text
                    .vPrefix_S4 = CbxPrefix_S2.Text
                    .vFirstN_S4 = TxtFirstN_S2.Text
                    .vMiddleN_S4 = TxtMiddleN_S2.Text
                    .vLastN_S4 = TxtLastN_S2.Text
                    .vSuffix_S4 = cbxSuffix_S2.Text
                End If
            End With
            Close()
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            CbxPrefix_S1.Text = ""
            TxtFirstN_S1.Text = ""
            TxtMiddleN_S1.Text = ""
            TxtLastN_S1.Text = ""
            cbxSuffix_S1.Text = ""

            CbxPrefix_S2.Text = ""
            TxtFirstN_S2.Text = ""
            TxtMiddleN_S2.Text = ""
            TxtLastN_S2.Text = ""
            cbxSuffix_S2.Text = ""
        End If
    End Sub

    '**** LEAVE
    Private Sub CbxPrefix_S1_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_S1.Leave
        CbxPrefix_S1.Text = ReplaceText(CbxPrefix_S1.Text)
    End Sub

    Private Sub TxtFirstN_S1_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_S1.Leave
        TxtFirstN_S1.Text = ReplaceText(TxtFirstN_S1.Text)
    End Sub

    Private Sub TxtMiddleN_S1_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_S1.Leave
        TxtMiddleN_S1.Text = ReplaceText(TxtMiddleN_S1.Text)
    End Sub

    Private Sub TxtLastN_S1_Leave(sender As Object, e As EventArgs) Handles TxtLastN_S1.Leave
        TxtLastN_S1.Text = ReplaceText(TxtLastN_S1.Text)
    End Sub

    Private Sub CbxSuffix_S1_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_S1.Leave
        cbxSuffix_S1.Text = ReplaceText(cbxSuffix_S1.Text)
    End Sub

    Private Sub CbxPrefix_S2_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_S2.Leave
        CbxPrefix_S2.Text = ReplaceText(CbxPrefix_S2.Text)
    End Sub

    Private Sub TxtFirstN_S2_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_S2.Leave
        TxtFirstN_S2.Text = ReplaceText(TxtFirstN_S2.Text)
    End Sub

    Private Sub TxtMiddleN_S2_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_S2.Leave
        TxtMiddleN_S2.Text = ReplaceText(TxtMiddleN_S2.Text)
    End Sub

    Private Sub TxtLastN_S2_Leave(sender As Object, e As EventArgs) Handles TxtLastN_S2.Leave
        TxtLastN_S2.Text = ReplaceText(TxtLastN_S2.Text)
    End Sub

    Private Sub CbxSuffix_S2_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_S2.Leave
        cbxSuffix_S2.Text = ReplaceText(cbxSuffix_S2.Text)
    End Sub
    '**** LEAVE

    '**** KEYDOWN
    Private Sub CbxPrefix_S1_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_S1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_S1.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_S1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_S1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_S1.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_S1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_S1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_S1.Focus()
        End If
    End Sub

    Private Sub TxtLastN_S1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_S1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_S1.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_S1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_S1.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbxPrefix_S2.Focus()
        End If
    End Sub

    Private Sub CbxPrefix_S2_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_S2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_S2.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_S2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_S2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_S2.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_S2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_S2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_S2.Focus()
        End If
    End Sub

    Private Sub TxtLastN_S2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_S2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_S2.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_S2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_S2.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '**** KEYDOWN

    Private Sub FrmCA_Signatories_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Icon = My.Resources.iLoanWorkX_ico
    End Sub
End Class