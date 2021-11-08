Public Class FrmBillingDetails

    Public DT_Billing As DataTable
    Private Sub FrmBillingDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        For x As Integer = 0 To DT_Billing.Rows.Count - 1
            Dim txtBilling_N As New DevComponents.DotNetBar.Controls.TextBoxX

            Dim dtpEffectivity_N As New DevComponents.Editors.DateTimeAdv.DateTimeInput
            Dim dPayableAmount_N As New DevComponents.Editors.DoubleInput
            Dim dAmount_N As New DevComponents.Editors.DoubleInput
            Dim txtRemarks_N As New DevComponents.DotNetBar.Controls.TextBoxX

            txtBilling_N.Enabled = txtBilling.Enabled
            dtpEffectivity_N.Enabled = dtpEffectivity.Enabled
            dPayableAmount_N.Enabled = dPayableAmount.Enabled
            dAmount_N.Enabled = dAmount.Enabled
            txtRemarks_N.Enabled = txtRemarks.Enabled

            txtBilling_N.Border.Class = txtBilling.Border.Class
            dtpEffectivity_N.BackgroundStyle.Class = dtpEffectivity.BackgroundStyle.Class
            dPayableAmount_N.BackgroundStyle.Class = dPayableAmount.BackgroundStyle.Class
            dAmount_N.BackgroundStyle.Class = dAmount.BackgroundStyle.Class
            txtRemarks_N.Border.Class = txtRemarks.Border.Class

            txtBilling_N.Font = txtBilling.Font
            dtpEffectivity_N.Font = dtpEffectivity.Font
            dPayableAmount_N.Font = dPayableAmount.Font
            dAmount_N.Font = dAmount.Font
            txtRemarks_N.Font = txtRemarks.Font

            txtBilling_N.Size = txtBilling.Size
            dtpEffectivity_N.Size = dtpEffectivity.Size
            dPayableAmount_N.Size = dPayableAmount.Size
            dAmount_N.Size = dAmount.Size
            txtRemarks_N.Size = txtRemarks.Size
            dtpEffectivity_N.Visible = dtpEffectivity.Visible

            txtBilling_N.Location = New Point(9, 38 + (31 * x))
            dtpEffectivity_N.Location = New Point(275, 38 + (31 * x))
            dPayableAmount_N.Location = New Point(454, 39 + (31 * x))
            dAmount_N.Location = New Point(597, 39 + (31 * x))
            txtRemarks_N.Location = New Point(740, 37 + (31 * x))

            txtBilling_N.Text = DT_Billing(x)("Billing")
            dtpEffectivity_N.Format = DevComponents.Editors.eDateTimePickerFormat.Custom
            If DT_Billing(x)("EffectivityD") = "" Then
                dtpEffectivity_N.CustomFormat = ""
            Else
                dtpEffectivity_N.CustomFormat = "MMMM dd, yyyy"
                dtpEffectivity_N.Value = DT_Billing(x)("EffectivityD")
            End If
            dPayableAmount_N.Value = DT_Billing(x)("Payable Amount")
            With dAmount_N
                .Value = DT_Billing(x)("Amount")
                .MaxValue = dPayableAmount_N.Value
                .MinValue = 0
                .Tag = DT_Billing(x)("ID")
            End With
            txtRemarks_N.Text = DT_Billing(x)("Remarks")
            With PanelEx2
                .Controls.Add(txtBilling_N)
                .Controls.Add(dtpEffectivity_N)
                .Controls.Add(dPayableAmount_N)
                .Controls.Add(dAmount_N)
                .Controls.Add(txtRemarks_N)
            End With
        Next
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelWithBackgroundFontSettings({LabelX4, LabelX2, LabelX3, LabelX6, LabelX5})

            GetTextBoxFontSettings({txtBilling, txtRemarks})

            GetDoubleInputFontSettings({dPayableAmount, dAmount})

            GetDateTimeInputFontSettings({dtpEffectivity})

            GetButtonFontSettings({btnSave, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Billing Details - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmPaymentEntry_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If btnSave.DialogResult = DialogResult.OK Then
        Else
            If MsgBoxYes("Are you sure you want to save this billing?") = MsgBoxResult.Yes Then
                For x As Integer = 0 To DT_Billing.Rows.Count - 1
                    For Each Ctrl As Control In PanelEx2.Controls
                        If (Ctrl.GetType() Is GetType(DevComponents.Editors.DoubleInput)) Then
                            Dim dInput As DevComponents.Editors.DoubleInput = CType(Ctrl, DevComponents.Editors.DoubleInput)
                            If dInput.Enabled And dInput.Tag = DT_Billing(x)("ID") Then
                                DT_Billing(x)("Amount") = dInput.Value
                            End If
                        End If
                    Next
                Next
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnSave.DialogResult = DialogResult.OK
                btnSave.PerformClick()
            End If
        End If
    End Sub
End Class