Public Class FrmAttachmentList

    Private Sub FrmAttachmentList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        Dim DT As New DataTable
        DT.Columns.Add("File Name")
        For x As Integer = 0 To AttachmentFiles.Count - 1
            DT.Rows.Add(AttachmentFiles(x))
        Next
        GridControl1.DataSource = DT
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetButtonFontSettings({btnOpen, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Attachment List - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub BtnOpen_Click(sender As Object, e As EventArgs) Handles btnOpen.Click
        Try
            Process.Start(GridView1.GetFocusedRowCellValue("File Name"))
        Catch ex As Exception
            MsgBox(ex.Message.ToString(), MsgBoxStyle.Information, "Info")
        End Try
    End Sub

    Private Sub FrmCrecomList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        btnOpen.PerformClick()
    End Sub
End Class