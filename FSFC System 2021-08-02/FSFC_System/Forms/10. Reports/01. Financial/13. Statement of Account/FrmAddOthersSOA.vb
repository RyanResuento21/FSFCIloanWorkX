Public Class FrmAddOthersSOA

    Public O1 As String
    Public O2 As String
    Public O3 As String
    Public O4 As String
    Public O5 As String
    Public O6 As String
    Private Sub FrmAddOthers_SOA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim DT_Others As DataTable = DataSource(String.Format("SELECT ID, Others FROM soa_others WHERE `status` = 'ACTIVE' ORDER BY Others;"))

        With cbxOthers
            .DisplayMember = "Others"
            .ValueMember = "ID"
            .DataSource = DT_Others.Copy
            .SelectedIndex = -1
            .Text = O1
        End With

        With cbxOthers_2
            .DisplayMember = "Others"
            .ValueMember = "ID"
            .DataSource = DT_Others.Copy
            .SelectedIndex = -1
            .Text = O2
        End With

        With cbxOthers_3
            .DisplayMember = "Others"
            .ValueMember = "ID"
            .DataSource = DT_Others.Copy
            .SelectedIndex = -1
            .Text = O3
        End With

        With cbxOthers_4
            .DisplayMember = "Others"
            .ValueMember = "ID"
            .DataSource = DT_Others.Copy
            .SelectedIndex = -1
            .Text = O4
        End With

        With cbxOthers_5
            .DisplayMember = "Others"
            .ValueMember = "ID"
            .DataSource = DT_Others.Copy
            .SelectedIndex = -1
            .Text = O5
        End With

        With cbxOthers_6
            .DisplayMember = "Others"
            .ValueMember = "ID"
            .DataSource = DT_Others.Copy
            .SelectedIndex = -1
            .Text = O6
        End With
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettings({LabelX27})

            GetCheckBoxFontSettings({cbxAdd, cbxDeduct, cbxAdd_2, cbxDeduct_2, cbxAdd_3, cbxDeduct_3, cbxAdd_4, cbxDeduct_4, cbxAdd_5, cbxDeduct_5, cbxAdd_6, cbxDeduct_6})

            GetComboBoxFontSettings({cbxOthers, cbxOthers_2, cbxOthers_3, cbxOthers_4, cbxOthers_5, cbxOthers_6})

            GetDoubleInputFontSettings({dOthers, dOthers_2, dOthers_3, dOthers_4, dOthers_5, dOthers_6})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Add Others SOA - FixUI", ex.Message.ToString)
        End Try
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
        ElseIf e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub CbxAdd_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdd.CheckedChanged
        If cbxAdd.Checked Then
            cbxDeduct.Checked = False
        End If

        If cbxAdd.Checked = False And cbxDeduct.Checked = False Then
            cbxAdd.Checked = True
        End If
    End Sub

    Private Sub CbxDeduct_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeduct.CheckedChanged
        If cbxDeduct.Checked Then
            cbxAdd.Checked = False
        End If

        If cbxAdd.Checked = False And cbxDeduct.Checked = False Then
            cbxAdd.Checked = True
        End If
    End Sub

    Private Sub CbxAdd_2_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdd_2.CheckedChanged
        If cbxAdd_2.Checked Then
            cbxDeduct_2.Checked = False
        End If

        If cbxAdd_2.Checked = False And cbxDeduct_2.Checked = False Then
            cbxAdd_2.Checked = True
        End If
    End Sub

    Private Sub CbxDeduct_2_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeduct_2.CheckedChanged
        If cbxDeduct_2.Checked Then
            cbxAdd_2.Checked = False
        End If

        If cbxAdd_2.Checked = False And cbxDeduct_2.Checked = False Then
            cbxAdd_2.Checked = True
        End If
    End Sub

    Private Sub CbxAdd_3_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdd_3.CheckedChanged
        If cbxAdd_3.Checked Then
            cbxDeduct_3.Checked = False
        End If

        If cbxAdd_3.Checked = False And cbxDeduct_3.Checked = False Then
            cbxAdd_3.Checked = True
        End If
    End Sub

    Private Sub CbxDeduct_3_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeduct_3.CheckedChanged
        If cbxDeduct_3.Checked Then
            cbxAdd_3.Checked = False
        End If

        If cbxAdd_3.Checked = False And cbxDeduct_3.Checked = False Then
            cbxAdd_3.Checked = True
        End If
    End Sub

    Private Sub CbxAdd_4_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdd_4.CheckedChanged
        If cbxAdd_4.Checked Then
            cbxDeduct_4.Checked = False
        End If

        If cbxAdd_4.Checked = False And cbxDeduct_4.Checked = False Then
            cbxAdd_4.Checked = True
        End If
    End Sub

    Private Sub CbxDeduct_4_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeduct_4.CheckedChanged
        If cbxDeduct_4.Checked Then
            cbxAdd_4.Checked = False
        End If

        If cbxAdd_4.Checked = False And cbxDeduct_4.Checked = False Then
            cbxAdd_4.Checked = True
        End If
    End Sub

    Private Sub CbxAdd_5_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdd_5.CheckedChanged
        If cbxAdd_5.Checked Then
            cbxDeduct_5.Checked = False
        End If

        If cbxAdd_5.Checked = False And cbxDeduct_5.Checked = False Then
            cbxAdd_5.Checked = True
        End If
    End Sub

    Private Sub CbxDeduct_5_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeduct_5.CheckedChanged
        If cbxDeduct_5.Checked Then
            cbxAdd_5.Checked = False
        End If

        If cbxAdd_5.Checked = False And cbxDeduct_5.Checked = False Then
            cbxAdd_5.Checked = True
        End If
    End Sub

    Private Sub CbxAdd_6_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAdd_6.CheckedChanged
        If cbxAdd_6.Checked Then
            cbxDeduct_6.Checked = False
        End If

        If cbxAdd_6.Checked = False And cbxDeduct_6.Checked = False Then
            cbxAdd_6.Checked = True
        End If
    End Sub

    Private Sub CbxDeduct_6_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDeduct_6.CheckedChanged
        If cbxDeduct_6.Checked Then
            cbxAdd_6.Checked = False
        End If

        If cbxAdd_6.Checked = False And cbxDeduct_6.Checked = False Then
            cbxAdd_6.Checked = True
        End If
    End Sub

    Private Sub CbxOthers_2_TextChanged(sender As Object, e As EventArgs) Handles cbxOthers_2.TextChanged
        If cbxOthers_2.Text = "" Then
            cbxAdd_2.Enabled = False
            cbxDeduct_2.Enabled = False
            dOthers_2.Enabled = False
            cbxOthers_3.Enabled = False
        Else
            cbxAdd_2.Enabled = True
            cbxDeduct_2.Enabled = True
            dOthers_2.Enabled = True
            cbxOthers_3.Enabled = True
        End If
    End Sub

    Private Sub CbxOthers_3_TextChanged(sender As Object, e As EventArgs) Handles cbxOthers_3.TextChanged
        If cbxOthers_3.Text = "" Then
            cbxAdd_3.Enabled = False
            cbxDeduct_3.Enabled = False
            dOthers_3.Enabled = False
            cbxOthers_4.Enabled = False
        Else
            cbxAdd_3.Enabled = True
            cbxDeduct_3.Enabled = True
            dOthers_3.Enabled = True
            cbxOthers_4.Enabled = True
        End If
    End Sub

    Private Sub CbxOthers_4_TextChanged(sender As Object, e As EventArgs) Handles cbxOthers_4.TextChanged
        If cbxOthers_4.Text = "" Then
            cbxAdd_4.Enabled = False
            cbxDeduct_4.Enabled = False
            dOthers_4.Enabled = False
            cbxOthers_5.Enabled = False
        Else
            cbxAdd_4.Enabled = True
            cbxDeduct_4.Enabled = True
            dOthers_4.Enabled = True
            cbxOthers_5.Enabled = True
        End If
    End Sub

    Private Sub CbxOthers_5_TextChanged(sender As Object, e As EventArgs) Handles cbxOthers_5.TextChanged
        If cbxOthers_5.Text = "" Then
            cbxAdd_5.Enabled = False
            cbxDeduct_5.Enabled = False
            dOthers_5.Enabled = False
            cbxOthers_6.Enabled = False
        Else
            cbxAdd_5.Enabled = True
            cbxDeduct_5.Enabled = True
            dOthers_5.Enabled = True
            cbxOthers_6.Enabled = True
        End If
    End Sub

    Private Sub CbxOthers_6_TextChanged(sender As Object, e As EventArgs) Handles cbxOthers_6.TextChanged
        If cbxOthers_6.Text = "" Then
            cbxAdd_6.Enabled = False
            cbxDeduct_6.Enabled = False
            dOthers_6.Enabled = False
        Else
            cbxAdd_6.Enabled = True
            cbxDeduct_6.Enabled = True
            dOthers_6.Enabled = True
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                With FrmSOA
                    .DT_Others.Rows.Clear()
                    If cbxOthers.Text = "" Then
                    Else
                        .DT_Others.Rows.Add(cbxOthers.Text, If(cbxAdd.Checked, 1, 0), dOthers.Value)
                        If cbxOthers_2.Text = "" Then
                        Else
                            .DT_Others.Rows.Add(cbxOthers_2.Text, If(cbxAdd_2.Checked, 1, 0), dOthers_2.Value)
                            If cbxOthers_3.Text = "" Then
                            Else
                                .DT_Others.Rows.Add(cbxOthers_3.Text, If(cbxAdd_3.Checked, 1, 0), dOthers_3.Value)
                                If cbxOthers_4.Text = "" Then
                                Else
                                    .DT_Others.Rows.Add(cbxOthers_4.Text, If(cbxAdd_4.Checked, 1, 0), dOthers_4.Value)
                                    If cbxOthers_5.Text = "" Then
                                    Else
                                        .DT_Others.Rows.Add(cbxOthers_5.Text, If(cbxAdd_5.Checked, 1, 0), dOthers_5.Value)
                                        If cbxOthers_6.Text = "" Then
                                        Else
                                            .DT_Others.Rows.Add(cbxOthers_6.Text, If(cbxAdd_6.Checked, 1, 0), dOthers_6.Value)
                                        End If
                                    End If
                                End If
                            End If
                        End If
                    End If
                    Dim OtherX As String = ""
                    Dim TotalAdd As Double
                    Dim TotalDeduct As Double
                    For x As Integer = 0 To .DT_Others.Rows.Count - 1
                        If .DT_Others(x)("Type") = True Then
                            TotalAdd += .DT_Others(x)("Amount")
                        Else
                            TotalDeduct += .DT_Others(x)("Amount")
                        End If
                        OtherX = OtherX & ", " & .DT_Others(x)("Others")
                    Next
                    .cbxOthers.Text = OtherX.Substring(2)
                    If TotalAdd > TotalDeduct Then
                        .cbxAdd.Checked = True
                        .dOthers.Value = TotalAdd - TotalDeduct
                    ElseIf TotalDeduct > TotalAdd Then
                        .cbxDeduct.Checked = True
                        .dOthers.Value = TotalDeduct - TotalAdd
                    Else
                        .cbxAdd.Checked = True
                        .dOthers.Value = 0
                    End If
                End With
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub
End Class