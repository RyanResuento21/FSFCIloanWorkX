Public Class FrmResetBranchHistory

    Private Sub FrmResetBranchHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim SQL As String = "SELECT "
        SQL &= "    Branch (branch_id) AS 'Branch',"
        SQL &= "    IF(reset_borrower = 1,'Yes','No') AS 'Borrower',"
        SQL &= "    IF(reset_accounting = 1,'Yes','No') AS 'Accounting',"
        SQL &= "    IF(reset_non_loans = 1,'Yes','No') AS 'Non Loans',"
        SQL &= "    IF(reset_ropa = 1,'Yes','No') AS 'ROPA',"
        SQL &= "    Remarks,"
        SQL &= "    DATE_FORMAT(`Timestamp`,'%M %d, %Y %H:%m:%s') AS 'Timestamp' "
        SQL &= "  FROM reset_branch_data WHERE `status` = 'ACTIVE'"

        GridControl1.DataSource = DataSource(SQL)
        If GridView1.RowCount > 5 Then
            GridColumn6.Width = 226 - 17
        End If
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({LabelX1})

            GetButtonFontSettings({btnCancel})
        Catch ex As Exception
            TriggerBugReport("Reset Branch History - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub FrmResetBranchHistory_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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