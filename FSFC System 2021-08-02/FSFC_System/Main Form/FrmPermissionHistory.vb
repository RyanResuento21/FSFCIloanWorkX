Public Class FrmPermissionHistory

    Private Sub FrmPermissionHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Dim SQL As String = "SELECT "
        SQL &= "  Get_UserEmployeeName(toUserID) AS 'Endorse To',"
        SQL &= "  Days,"
        SQL &= "  IF(`Start` = '','',DATE_FORMAT(`Start`, '%M %d, %Y')) AS 'From',"
        SQL &= "  IF(`Start` = '','',DATE_FORMAT(ADDDATE(`Start`,Days), '%M %d, %Y')) AS 'To',"
        SQL &= "  IF(include_position = 1,'YES','NO') AS 'Position',"
        SQL &= "  `Status`"
        SQL &= String.Format("  FROM endorse_permission WHERE UserID = {0}", User_ID)
        SQL &= " ORDER BY ID DESC ;"

        GridControl1.DataSource = DataSource(SQL)
        If GridView1.RowCount > 5 Then
            GridColumn1.Width = 201 - 17
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
            TriggerBugReport("Permission History - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
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
End Class