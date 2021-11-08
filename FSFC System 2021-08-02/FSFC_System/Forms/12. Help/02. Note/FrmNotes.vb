Public Class FrmNotes

    Private Sub FrmNotes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelWithBackgroundFontSettings({LabelX6, LabelX36, LabelX39})

            GetLabelFontSettingsDefault({LabelX2, LabelX8, LabelX10, LabelX12, LabelX14, LabelX16, LabelX18, LabelX20, LabelX3, LabelX22, LabelX24, LabelX5, LabelX26, LabelX28, LabelX40, LabelX34, LabelX32, LabelX37, LabelX30, LabelX42, LabelX44, LabelX46, LabelX48, LabelX50, LabelX52, LabelX54, LabelX56, LabelX58})

            GetLabelFontSettings({LabelX1, LabelX9, LabelX11, LabelX13, LabelX15, LabelX17, LabelX19, LabelX21, LabelX4, LabelX23, LabelX25, LabelX7, LabelX27, LabelX29, LabelX41, LabelX35, LabelX33, LabelX38, LabelX31, LabelX43, LabelX45, LabelX47, LabelX49, LabelX51, LabelX53, LabelX55, LabelX57, LabelX59})

            GetButtonFontSettings({btnCancel})
        Catch ex As Exception
            TriggerBugReport("Notes - FixUI", ex.Message.ToString)
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
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        End If
    End Sub
End Class