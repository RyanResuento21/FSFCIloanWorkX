Public Class FrmAddToNotification

    Public From_PettyCash As Boolean
    Public ExcludeID As String
    Private Sub FrmAddToNotification_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView13})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)

        Try
            Dim SQL As String = "SELECT ID, "
            SQL &= "    AssetNumber AS 'Reference Number',"
            SQL &= "    IF(AssetNumber LIKE 'AN%','ROPA','CREDIT') AS 'Check From',"
            SQL &= "    IF(AssetNumber LIKE 'ANV%',(SELECT PlateNum FROM ropoa_vehicle R WHERE R.AssetNumber = check_received.AssetNumber ORDER BY ID LIMIT 1),IF(AssetNumber LIKE 'ANR%', (SELECT TCT FROM ropoa_realestate R WHERE R.AssetNumber = check_received.AssetNumber ORDER BY ID LIMIT 1), (SELECT Product FROM credit_application C WHERE C.CreditNumber = check_received.AssetNumber ORDER BY ID LIMIT 1))) AS 'Details',"
            SQL &= "    Buyer AS 'Payee',"
            SQL &= "    Bank,"
            SQL &= "    Branch,"
            SQL &= "    `Check` AS 'Check Number',"
            SQL &= "    DATE_FORMAT(`Date`,'%b.%d.%Y') AS 'Due Date',"
            SQL &= "    Amount AS 'Check Amount',"
            SQL &= "    Remarks, Branch(branch_id) AS 'Company Branch' "
            SQL &= " FROM check_received"
            SQL &= String.Format("  WHERE `status` = 'ACTIVE' AND Checked = 1 AND `Date` <= DATE(NOW()) AND check_type = 'R' AND Branch_ID IN ({0})", If(Multiple_ID = "", Branch_ID, Multiple_ID))
            GridControl13.DataSource = DataSource(SQL)
            If GridView13.RowCount > 11 Then
                GridColumn126.Width = 260 - 17
            Else
                GridColumn126.Width = 260
            End If
            If GridView13.RowCount > 0 Then
                btnAdd.Enabled = True
            End If
            With GridView13.Columns("Payee").SummaryItem
                .SummaryType = DevExpress.Data.SummaryItemType.Count
                .DisplayFormat = "Total of {0} record(s) fetched"
            End With
        Catch ex As Exception
            TriggerBugReport("Add To Notification - Load", ex.Message.ToString)
        End Try
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetButtonFontSettings({btnAdd, btnCancel})
        Catch ex As Exception
            TriggerBugReport("Add to Notification - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Alert Notification", lblTitle.Text)
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If btnAdd.DialogResult = DialogResult.OK Then
        Else
            If MsgBox("Are you sure you want to add this to notification?", MsgBoxStyle.YesNo, "Info") Then
                DataObject(String.Format("UPDATE check_received SET `Checked` = 0 WHERE ID = '{0}';", GridView13.GetFocusedRowCellValue("ID")))
                Logs("Alert Notification", "Remove Notification", String.Format("Remove From Notification of Check Number {0} from {1}.", GridView13.GetFocusedRowCellValue("Check Number"), GridView13.GetFocusedRowCellValue("Payee")), "", "", "", "")
                btnAdd.DialogResult = DialogResult.OK
                btnAdd.PerformClick()
            End If
        End If
    End Sub

    Private Sub GridView13_DoubleClick(sender As Object, e As EventArgs) Handles GridView13.DoubleClick
        btnAdd.PerformClick()
    End Sub
End Class