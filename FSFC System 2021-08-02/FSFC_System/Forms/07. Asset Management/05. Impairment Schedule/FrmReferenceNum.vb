Public Class FrmReferenceNum

    Public AssetNumber As String
    Public From_Credit As Boolean
    Private Sub FrmReferenceNum_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        dtpPosted.Value = Date.Now
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetLabelFontSettings({LabelX3, LabelX2})

            GetTextBoxFontSettings({txtReference})

            GetDateTimeInputFontSettings({dtpPosted})

            GetButtonFontSettings({btnPost, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Reference Number - FixUI", ex.Message.ToString)
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
        If e.Control And e.KeyCode = Keys.P Then
            btnPost.Focus()
            btnPost.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtReference_Leave(sender As Object, e As EventArgs) Handles txtReference.Leave
        txtReference.Text = ReplaceText(txtReference.Text)
    End Sub

    Private Sub TxtReference_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReference.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnPost.Focus()
            btnPost.PerformClick()
        End If
    End Sub

    Private Sub BtnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If btnPost.DialogResult = DialogResult.OK Then
        Else
            If txtReference.Text.Trim = "" Then
                If MsgBoxYes("JV Number is empty, would you like to proceed?") = MsgBoxResult.Yes Then
                Else
                    Exit Sub
                End If
            Else
                If From_Credit Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM accounting_entry WHERE `JVNum` = '{0}' AND `status` = 'ACTIVE' AND YEAR(ORNum) = YEAR('{2}');", txtReference.Text, AssetNumber, FormatDatePicker(dtpPosted)))
                    If Exist > 0 Then
                        MsgBox(String.Format("JV number {0} already exist, Please check your data.", txtReference.Text), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                Else
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM ledger_ropoa WHERE `reference_number` = '{0}' AND `status` = 'ACTIVE' AND asset_number = '{1}' AND YEAR(trans_date) = YEAR('{2}');", txtReference.Text, AssetNumber, FormatDatePicker(dtpPosted)))
                    If Exist > 0 Then
                        MsgBox(String.Format("JV number {0} already exist, Please check your data.", txtReference.Text), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If
            End If

            btnPost.DialogResult = DialogResult.OK
            btnPost.PerformClick()
        End If
    End Sub
End Class