Public Class FrmAccountList

    Public AssetNumber As String
    Public DT_Account As DataTable
    Private Sub FrmAccountList_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        For x As Integer = 0 To DT_Account.Rows.Count - 1
            Dim btn As New DevComponents.DotNetBar.ButtonX
            With btn
                .Text = DT_Account(x)("AccountNo")
                .Tag = DT_Account(x)("AssetNumber")
                .Dock = DockStyle.Top
                .Font = New Font(OfficialFont, 16, FontStyle.Bold)
                .Size = New Size(540, 41)
                .DialogResult = DialogResult.OK
            End With
            PanelEx2.Controls.Add(btn)
            AddHandler btn.Click, AddressOf btn_Click
        Next
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX11})

            GetButtonFontSettings({btnCancel, btnAccountN})
        Catch ex As Exception
            TriggerBugReport("Account List - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub Btn_Click(sender As Object, e As EventArgs)
        AssetNumber = CType(sender, DevComponents.DotNetBar.ButtonX).Tag
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub FrmAccountList_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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
End Class