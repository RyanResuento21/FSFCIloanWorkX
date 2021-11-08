Public Class FrmCIApproved_BM

    Public BorrowerID As String
    Public CreditNumber As String
    Public CINumber As String
    Public TotalImage As Integer
    Public Corporate As Boolean

    Private Sub FrmCIApproved_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FixPictureEdit(pb_B, 255, 256, 6, 7, False)
        If TotalImage Then
            btnApproved.Enabled = True
            btnDisapproved.Enabled = True
        End If

        If Corporate Then
            LabelX43.Text = "Trade Name :"
            TxtFirstN_B.Size = New Point(739, 23)
            TxtFirstN_B.Location = New Point(406, 7)

            CbxPrefix_B.Visible = False
            TxtMiddleN_B.Visible = False
            TxtLastN_B.Visible = False
            cbxSuffix_B.Visible = False
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetDoubleInputFontSettings({dPrincipal, dPrincipalA, dPrincipalB, dInterestRate, dInterestRateA, dInterestRateB, dTotalDisposable, dTotalExpenses, dNetDisposable, dTMFI, dTMDI})

            GetRickTextBoxFontSettings({rNarrative})

            GetIntegerInputFontSettings({iTerms, iTermsA, iTermsB})

            GetLabelWithBackgroundFontSettings({LabelX6, LabelX11, LabelX4})

            GetLabelFontSettings({LabelX2, lblInterest, LabelX3, LabelX1, LabelX43, LabelX7, LabelX8, LabelX9, LabelX95, LabelX43, LabelX7, LabelX8, LabelX9, LabelX97, LabelX119, LabelX121, LabelX124, LabelX126, LabelX98, LabelX118, LabelX120, LabelX123, LabelX125})

            GetTextBoxFontSettings({TxtFirstN_B, TxtMiddleN_B, TxtLastN_B})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B, cbxTerms, cbxTermsA, cbxTermsB})

            GetButtonFontSettings({btnApproved, btnDisapproved, btnAttach, btnCancel, btnRequirements, TxtCopy})
        Catch ex As Exception
            TriggerBugReport("CI Approved - FixUI", ex.Message.ToString)
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
        OpenFormHistory("CI Approve", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmCIApproved_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.A Then
            btnApproved.Focus()
            btnApproved.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDisapproved.Focus()
            btnDisapproved.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnApproved_Click(sender As Object, e As EventArgs) Handles btnApproved.Click
        If btnApproved.DialogResult = DialogResult.OK Then
            Exit Sub
        End If

        If dPrincipalB.Value = 0 Then
            MsgBox("Please fill BM Amount Applied Recommendation", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If iTermsB.Value = 0 Then
            MsgBox("Please fill BM Terms Recommendation", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If dInterestRateB.Value = 0 Then
            MsgBox("Please fill BM Interest Rate Recommendation", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If MsgBoxYes("Are you sure you want to approve this credit investigation?") = MsgBoxResult.Yes Then
            btnApproved.DialogResult = DialogResult.OK
            btnApproved.PerformClick()
        End If
    End Sub

    Private Sub BtnDisapproved_Click(sender As Object, e As EventArgs) Handles btnDisapproved.Click
        If btnDisapproved.DialogResult = DialogResult.Yes Then
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to disapprove this credit investigation?") = MsgBoxResult.Yes Then
            btnDisapproved.DialogResult = DialogResult.Yes
            btnDisapproved.PerformClick()
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "CI Approval"
            .Type = "CI Approval"
            .TotalImage = TotalImage
            .CINumber = CINumber
            .ID = CINumber
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
                FrmCreditInvestigation.TotalImage_Approval = TotalImage
                FrmCreditInvestigation.GridView5.SetFocusedRowCellValue("Attach_Approval", TotalImage)
            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
                FrmCreditInvestigation.TotalImage_Approval = TotalImage
                FrmCreditInvestigation.GridView5.SetFocusedRowCellValue("Attach_Approval", TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnRequirements_Click(sender As Object, e As EventArgs) Handles btnRequirements.Click
        Dim Requirements As New FrmRequirementsMonitoring
        With Requirements
            .For_Viewing = True
            .CreditNumber = CreditNumber
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub TxtCopy_Click(sender As Object, e As EventArgs) Handles TxtCopy.Click
        dPrincipalB.Value = dPrincipalA.Value
        iTermsB.Value = iTermsA.Value
        dInterestRateB.Value = dInterestRateA.Value
    End Sub
End Class