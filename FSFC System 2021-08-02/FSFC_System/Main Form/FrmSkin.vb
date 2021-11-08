Public Class FrmSkin

    Dim FirstLoad As Boolean = True
    Private Sub FrmSkin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FirstLoad = True
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        cpb1.Location = New Point(138, 105)
        cpb2.Location = New Point(138, 134)
        cbxSkin.Text = Empl_Skin

        Dim installedFonts As New Text.InstalledFontCollection
        Dim fontFamilies = installedFonts.Families()
        For Each FF As FontFamily In fontFamilies
            cbxFont.Items.Add(FF.Name)
        Next

        cbxFont.Text = OfficialFont
        dFSize.Value = OfficialFontSize
        cbxFont.Tag = OfficialFont
        dFSize.Tag = OfficialFontSize
        dFSizeGrid.Value = OfficialFontSizeGrid
        cpb1.SelectedColor = OfficialColor1
        cpb2.SelectedColor = OfficialColor2
        If User_Type = "ADMIN" Then
            btnApply.Visible = True
            btnClear.Visible = True
        Else
            btnApply.Visible = False
            btnClear.Visible = False
            cbxFont.Enabled = False
            dFSize.Enabled = False
            dFSizeGrid.Enabled = False
            cpb1.Enabled = False
            cpb2.Enabled = False
        End If
        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelFontSettings({LabelX1, LabelX82, LabelX2, LabelX5, LabelX6, LabelX17, LabelX3, LabelX4})

            GetComboBoxWinFormFontSettings({cbxFont, cbxSkin})

            GetDoubleInputFontSettings({dFSize, dFSizeGrid})

            GetButtonFontSettings({btnSave, btnCancel, btnApply, btnClear})
        Catch ex As Exception
            TriggerBugReport("Skin - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If MsgBoxYes("Are you sure you want to update your skin?") = MsgBoxResult.Yes Then
            Empl_Skin = cbxSkin.Text
            DataObject(String.Format("UPDATE users SET skin = '{0}', skin_season = '' WHERE user_code = '{1}'", cbxSkin.Text, User_Code))
            If cbxFont.Enabled Then
                DataObject(String.Format("UPDATE company SET OfficialFont = '{1}', FontSize = '{2}', FontSizeGrid = '{3}', Color1 = '{4}', Color2 = '{5}' WHERE ID = '{0}';", Company_ID, cbxFont.Text, dFSize.Value, dFSizeGrid.Value, cpb1.SelectedColor.R & "," & cpb1.SelectedColor.G & "," & cpb1.SelectedColor.B, cpb2.SelectedColor.R & "," & cpb2.SelectedColor.G & "," & cpb2.SelectedColor.B))

                OfficialFont = cbxFont.Text
                OfficialFontSize = dFSize.Value
                cbxFont.Tag = OfficialFont
                dFSize.Tag = OfficialFontSize
                OfficialFontSizeGrid = dFSizeGrid.Value
                OfficialColor1 = cpb1.SelectedColor
                OfficialColor2 = cpb2.SelectedColor
                GetGridFontSettingsAppearance({FrmDepartment.GridView1})
                GetBandedGridFontSettingsAppearance({FrmPerformanceReport.BandedGridView1})
            End If
            Logs("Change Skin", "Set", String.Format("Change Skin from {0} to {1}", Empl_Skin, cbxSkin.Text), "Skin", "", "", "")
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            Close()
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmSkin_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub CbxSkin_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxSkin.SelectedIndexChanged
        DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = cbxSkin.Text
    End Sub

    Private Sub BtnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        If MsgBoxYes("Are you sure you want to apply this skin to everyone?") = MsgBoxResult.Yes Then
            Dim PW As New FrmPassword
            With PW
                .ShowMessage = False
                .lblNote.Text = "*For IT Password only."
HERE:
                If .ShowDialog = DialogResult.OK Then
                    If IT_PW = DataObject(String.Format("SELECT MD5(SHA1('{0}'))", ReplaceText(.txtPassword.Text))) Then
                        Empl_Skin = cbxSkin.Text
                        DataObject(String.Format("UPDATE users SET skin_season = '{0}';", cbxSkin.Text, User_Code))
                        DataObject(String.Format("UPDATE company SET OfficialFont = '{1}', FontSize = '{2}', FontSizeGrid = '{3}', Color1 = '{4}', Color2 = '{5}' WHERE ID = '{0}';", Company_ID, cbxFont.Text, dFSize.Value, dFSizeGrid.Value, cpb1.SelectedColor.R & "," & cpb1.SelectedColor.G & "," & cpb1.SelectedColor.B, cpb2.SelectedColor.R & "," & cpb2.SelectedColor.G & "," & cpb2.SelectedColor.B))

                        OfficialFont = cbxFont.Text
                        OfficialFontSize = dFSize.Value
                        cbxFont.Tag = OfficialFont
                        dFSize.Tag = OfficialFontSize
                        OfficialFontSizeGrid = dFSizeGrid.Value
                        OfficialColor1 = cpb1.SelectedColor
                        OfficialColor2 = cpb2.SelectedColor
                        GetGridFontSettingsAppearance({FrmDepartment.GridView1})
                        GetBandedGridFontSettingsAppearance({FrmPerformanceReport.BandedGridView1})

                        Logs("Change Skin", "Set", String.Format("Change all users skin to {1}", Empl_Skin, cbxSkin.Text), "Skin", "", "", "")
                        MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                        .Dispose()
                        Close()
                    Else
                        MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                        .txtPassword.Text = ""
                        GoTo HERE
                    End If
                End If
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        If MsgBoxYes("Are you sure you want to clear season skin?") = MsgBoxResult.Yes Then
            Empl_Skin = cbxSkin.Text
            DataObject(String.Format("UPDATE users SET skin_season = '';", cbxSkin.Text, User_Code))
            Logs("Clear Skin", "Clear", String.Format("Clear all users skin from {1}", Empl_Skin, cbxSkin.Text), "Skin", "", "", "")
            MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            Close()
        End If
    End Sub

    Private Sub CbxFont_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxFont.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        OfficialFont = cbxFont.Text
        OfficialFontSize = dFSize.Value
        FixUI(AllowStandardUI)
    End Sub

    Private Sub DFSize_ValueChanged(sender As Object, e As EventArgs) Handles dFSize.ValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        OfficialFont = cbxFont.Text
        OfficialFontSize = dFSize.Value
        FixUI(AllowStandardUI)
    End Sub

    Private Sub FrmSkin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        OfficialFont = cbxFont.Tag
        OfficialFontSize = dFSize.Tag
    End Sub
End Class