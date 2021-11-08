'Imports word = Microsoft.Office.Interop.Word
Public Class FrmBouncedReason

    Public Sold_ID As String
    Public MultipleA As Boolean
    Public ROPOA_Ref As String
    Public ORNum As String
    'For Send SMS Info
    Public BuyerContact As String
    ReadOnly Msg As String
    'For Send Email Info
    Public FullName As String
    Public PrefixN As String
    Public LastN As String
    Public Address As String
    Public From_Credit As Boolean
    Public AccountNumber As String

    Public BounceID As Integer
    Public BounceReason As String

    Private Sub FrmBouncedReason_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetTextBoxFontSettings({txtRemarks})

            GetCheckBoxFontSettings({cbx1, cbx2, cbx3, cbx4, cbx5, cbx6, cbx7, cbx8, cbx9, cbx10, cbx11, cbx12, cbx13, cbx14, cbx15, cbx16, cbx17})

            GetButtonFontSettings({btnBounce, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Bounced Reason - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub Cbx1_CheckedChanged(sender As Object, e As EventArgs) Handles cbx1.CheckedChanged
        If cbx1.Checked Then
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx2_CheckedChanged(sender As Object, e As EventArgs) Handles cbx2.CheckedChanged
        If cbx2.Checked Then
            cbx1.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx3_CheckedChanged(sender As Object, e As EventArgs) Handles cbx3.CheckedChanged
        If cbx3.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx4_CheckedChanged(sender As Object, e As EventArgs) Handles cbx4.CheckedChanged
        If cbx4.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx5_CheckedChanged(sender As Object, e As EventArgs) Handles cbx5.CheckedChanged
        If cbx5.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx6_CheckedChanged(sender As Object, e As EventArgs) Handles cbx6.CheckedChanged
        If cbx6.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx7_CheckedChanged(sender As Object, e As EventArgs) Handles cbx7.CheckedChanged
        If cbx7.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx8_CheckedChanged(sender As Object, e As EventArgs) Handles cbx8.CheckedChanged
        If cbx8.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx9_CheckedChanged(sender As Object, e As EventArgs) Handles cbx9.CheckedChanged
        If cbx9.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx10_CheckedChanged(sender As Object, e As EventArgs) Handles cbx10.CheckedChanged
        If cbx10.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx11_CheckedChanged(sender As Object, e As EventArgs) Handles cbx11.CheckedChanged
        If cbx11.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx12_CheckedChanged(sender As Object, e As EventArgs) Handles cbx12.CheckedChanged
        If cbx12.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx13_CheckedChanged(sender As Object, e As EventArgs) Handles cbx13.CheckedChanged
        If cbx13.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx14_CheckedChanged(sender As Object, e As EventArgs) Handles cbx14.CheckedChanged
        If cbx14.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx15_CheckedChanged(sender As Object, e As EventArgs) Handles cbx15.CheckedChanged
        If cbx15.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx16.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx16_CheckedChanged(sender As Object, e As EventArgs) Handles cbx16.CheckedChanged
        If cbx16.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx17.Checked = False
        End If
    End Sub

    Private Sub Cbx17_CheckedChanged(sender As Object, e As EventArgs) Handles cbx17.CheckedChanged
        If cbx17.Checked Then
            cbx1.Checked = False
            cbx2.Checked = False
            cbx3.Checked = False
            cbx4.Checked = False
            cbx5.Checked = False
            cbx6.Checked = False
            cbx7.Checked = False
            cbx8.Checked = False
            cbx9.Checked = False
            cbx10.Checked = False
            cbx11.Checked = False
            cbx12.Checked = False
            cbx13.Checked = False
            cbx14.Checked = False
            cbx15.Checked = False
            cbx16.Checked = False
        End If
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text)
    End Sub

    Private Sub FrmBouncedReason_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.B Then
            btnBounce.Focus()
            btnBounce.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnBounce_Click(sender As Object, e As EventArgs) Handles btnBounce.Click
        If btnBounce.DialogResult = DialogResult.OK Then
        Else
            If cbx1.Checked = False And cbx2.Checked = False And cbx3.Checked = False And cbx4.Checked = False And cbx5.Checked = False And cbx6.Checked = False And cbx7.Checked = False And cbx8.Checked = False And cbx9.Checked = False And cbx10.Checked = False And cbx11.Checked = False And cbx12.Checked = False And cbx13.Checked = False And cbx14.Checked = False And cbx15.Checked = False And cbx16.Checked = False And cbx17.Checked = False Then
                MsgBox("Please select one reason why this check is BOUNCED", MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
            If cbx1.Checked Then
                BounceID = cbx1.Tag
                BounceReason = cbx1.Text.Replace("1. ", "[") & "]"
            ElseIf cbx2.Checked Then
                BounceID = cbx2.Tag
                BounceReason = cbx2.Text.Replace("2. ", "[") & "]"
            ElseIf cbx3.Checked Then
                BounceID = cbx3.Tag
                BounceReason = cbx3.Text.Replace("3. ", "[") & "]"
            ElseIf cbx4.Checked Then
                BounceID = cbx4.Tag
                BounceReason = cbx4.Text.Replace("4. ", "[") & "]"
            ElseIf cbx5.Checked Then
                BounceID = cbx5.Tag
                BounceReason = cbx5.Text.Replace("5. ", "[") & "]"
            ElseIf cbx6.Checked Then
                BounceID = cbx6.Tag
                BounceReason = cbx6.Text.Replace("6. ", "[") & "]"
            ElseIf cbx7.Checked Then
                BounceID = cbx7.Tag
                BounceReason = cbx7.Text.Replace("7. ", "[") & "]"
            ElseIf cbx8.Checked Then
                BounceID = cbx8.Tag
                BounceReason = cbx8.Text.Replace("8. ", "[") & "]"
            ElseIf cbx9.Checked Then
                BounceID = cbx9.Tag
                BounceReason = cbx9.Text.Replace("9. ", "[") & "]"
            ElseIf cbx10.Checked Then
                BounceID = cbx10.Tag
                BounceReason = cbx10.Text.Replace("10. ", "[") & "]"
            ElseIf cbx11.Checked Then
                BounceID = cbx11.Tag
                BounceReason = cbx11.Text.Replace("11. ", "[") & "]"
            ElseIf cbx12.Checked Then
                BounceID = cbx12.Tag
                BounceReason = cbx12.Text.Replace("12. ", "[") & "]"
            ElseIf cbx13.Checked Then
                BounceID = cbx13.Tag
                BounceReason = cbx13.Text.Replace("13. ", "[") & "]"
            ElseIf cbx14.Checked Then
                BounceID = cbx14.Tag
                BounceReason = cbx14.Text.Replace("14. ", "[") & "]"
            ElseIf cbx15.Checked Then
                BounceID = cbx15.Tag
                BounceReason = cbx15.Text.Replace("15. ", "[") & "]"
            ElseIf cbx16.Checked Then
                BounceID = cbx16.Tag
                BounceReason = cbx16.Text.Replace("16. ", "[") & "]"
            ElseIf cbx17.Checked Then
                BounceID = cbx17.Tag
                BounceReason = cbx17.Text.Replace("17. ", "[") & "]"
            End If

            If MsgBoxYes("Are you sure that this check bounce?") = MsgBoxResult.Yes Then
                btnBounce.DialogResult = DialogResult.OK
                btnBounce.PerformClick()
            Else
                btnBounce.DialogResult = DialogResult.None
            End If
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBounce.Focus()
        End If
    End Sub
End Class