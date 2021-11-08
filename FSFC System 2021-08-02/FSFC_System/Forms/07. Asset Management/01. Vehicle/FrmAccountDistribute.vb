Public Class FrmAccountDistribute

    Public DT_Account As DataTable
    Public Amount As Double
    Public TotalAmount As Double
    Public Info As String
    ReadOnly lbl_Total As New DevComponents.DotNetBar.LabelX
    Private Sub FrmAccountDistribute_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        lblAmount.Text = String.Format("Ledger Entry Amount: {0}", FormatNumber(Amount, 2))
        lblAssetN.Text = String.Format("Asset Number: {0}", DT_Account(0)("AssetNumber"))
        lblInfo.Text = Info

        For x As Integer = 0 To DT_Account.Rows.Count - 1
            Dim lbl As New DevComponents.DotNetBar.LabelX
            Dim dInput As New DevComponents.Editors.DoubleInput
            lbl.TextAlignment = StringAlignment.Far
            lbl.Font = New Font(OfficialFont, 16, FontStyle.Bold)
            dInput.Font = New Font(OfficialFont, 16, FontStyle.Regular)
            lbl.Size = New Size(284, 33)
            dInput.Size = New Size(218, 33)
            lbl.Location = New Point(12, 9 + (39 * (x + 3)))
            dInput.Location = New Point(302, 9 + (39 * (x + 3)))
            lbl.Text = DT_Account(x)("AccountNo") & " [" & FormatNumber(CDbl(DataObject(String.Format("SELECT Running_Balance('{0}')", DT_Account(x)("AssetNumber")))), 2) & "] :"
            lbl.ForeColor = LabelX11.ForeColor
            dInput.ForeColor = LabelX11.ForeColor
            dInput.Tag = DT_Account(x)("AccountNo")
            dInput.Value = Amount / DT_Account.Rows.Count
            AddHandler dInput.ValueChanged, AddressOf dAmount_ValueChanged
            PanelEx2.Controls.Add(lbl)
            PanelEx2.Controls.Add(dInput)
        Next

        With lbl_Total
            .TextAlignment = StringAlignment.Far
            .Font = New Font(OfficialFont, 24, FontStyle.Bold)
            .Size = New Size(508, 33)
            .Location = New Point(12, 9 + (39 * (DT_Account.Rows.Count + 3)))
            .Text = FormatNumber(Amount, 2)
            .ForeColor = Color.Maroon
        End With
        PanelEx2.Controls.Add(lbl_Total)
        dAmount_ValueChanged(sender, e)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetLabelFontSettingsDefault({lblAmount, lblAssetN, lblInfo, lblAccount})

            GetDoubleInputFontSettingsDefault({dAmount})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Account Distribute - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub DAmount_ValueChanged(sender As Object, e As EventArgs)
        TotalAmount = 0
        For Each ctrl In PanelEx2.Controls
            If (ctrl.GetType() Is GetType(DevComponents.Editors.DoubleInput)) Then
                Dim dInp As DevComponents.Editors.DoubleInput = CType(ctrl, DevComponents.Editors.DoubleInput)
                TotalAmount += dInp.Value
                For x As Integer = 0 To DT_Account.Rows.Count - 1
                    If dInp.Tag = DT_Account(x)("AccountNo") Then
                        DT_Account(x)("Amount") = dInp.Value
                    End If
                Next
            End If
        Next
        lbl_Total.Text = FormatNumber(TotalAmount, 2)
        If TotalAmount = Amount Then
            btnSave.Enabled = True
        Else
            btnSave.Enabled = False
        End If
    End Sub

    Private Sub FrmAccountList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            If MsgBoxYes("Closing the form would result the distribution of amount for each account to be divided by the number of account. Would you like to continue?") = MsgBoxResult.Yes Then
                Close()
            End If
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If TotalAmount = Amount Then
            Else
                MsgBox(String.Format("Total distributed amount does not match with the Ledger Entry Amount for this ROPOA, please check your data. Total Distributed Amount {0}, Ledger Entry Amount {1}", FormatNumber(TotalAmount, 2), FormatNumber(Amount, 2)), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            btnSave.DialogResult = DialogResult.OK
            btnSave.PerformClick()
        End If
    End Sub
End Class