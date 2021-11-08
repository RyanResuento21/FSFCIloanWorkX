Public Class FrmImpairmentManagement

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmImpairmentManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True

        With cbxROPOA
            .DisplayMember = "ROPOA"
            .DataSource = DataSource(String.Format("SELECT CONCAT(AccountN, ' - ', ReferenceN) AS 'ROPOA', AssetNumber, Borrower(IF(SUBSTRING(AssetNumber,1,3) = 'ANV',(SELECT AccountID FROM ropoa_vehicle WHERE ropoa_vehicle.AssetNumber = tbl_impairment.AssetNumber),(SELECT AccountID FROM ropoa_realestate WHERE ropoa_realestate.AssetNumber = tbl_impairment.AssetNumber))) AS 'Account Name' FROM tbl_impairment WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) GROUP BY AssetNumber ORDER BY `ROPOA`;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        End With

        LoadData()

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX155})

            GetCheckBoxFontSettings({cbxAll})

            GetComboBoxFontSettings({cbxROPOA})

            GetButtonFontSettings({btnSearch, btnPrint, btnCancel, btnRefresh, btnPost})
        Catch ex As Exception
            TriggerBugReport("Impairment Management - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Impairment Management", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        If (cbxROPOA.Text = "" Or cbxROPOA.SelectedIndex = -1) And cbxAll.Checked = False Then
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor

        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    AssetNumber       AS 'Asset Number',"
        SQL &= "    ReferenceN        AS 'TCT / Plate Number',"
        SQL &= "    AccountN          AS 'Account Number',"
        SQL &= "    Reference          AS 'Reference Number',"
        SQL &= "    DATE_FORMAT(Months,'%M %d, %Y') AS 'Month',"
        SQL &= "    Amount,"
        SQL &= "    impairment_status, `Type`, IF(posted_date = '','',DATE_FORMAT(posted_date,'%M %d, %Y')) AS 'Posted Date'"
        SQL &= " FROM tbl_impairment"
        SQL &= " WHERE `status` = 'ACTIVE'"
        If cbxAll.Checked Then
        Else
            Dim drv_B As DataRowView = DirectCast(cbxROPOA.SelectedItem, DataRowView)
            SQL &= String.Format(" AND AssetNumber = '{0}'", drv_B("AssetNumber"))
        End If

        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("TCT / Plate Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("TCT / Plate Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 19 Then
            GridColumn3.Width = 207 - 17
        Else
            GridColumn3.Width = 207
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxROPOA_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxROPOA.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxROPOA.Enabled = False
            cbxROPOA.SelectedIndex = -1
        Else
            cbxROPOA.Enabled = True
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        GridView1.OptionsPrint.UsePrintStyles = False
        StandardPrinting("ROPOA IMPAIRMENT MANAGEMENT LIST", GridControl1)
        Logs("Impairment Management", "Print", "[SENSITIVE] Print Impairment Management for " & cbxROPOA.Text, "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSearch.Focus()
            btnSearch.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.btnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadData()
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("impairment_status"))
            If Status = "POSTED" Then
                e.Appearance.BackColor = Color.LightGreen
            End If
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        With cbxROPOA
            .DisplayMember = "ROPOA"
            .DataSource = DataSource(String.Format("SELECT CONCAT(AccountN, ' - ', ReferenceN) AS 'ROPOA', AssetNumber, Borrower(IF(SUBSTRING(AssetNumber,1,3) = 'ANV',(SELECT AccountID FROM ropoa_vehicle WHERE ropoa_vehicle.AssetNumber = tbl_impairment.AssetNumber),(SELECT AccountID FROM ropoa_realestate WHERE ropoa_realestate.AssetNumber = tbl_impairment.AssetNumber))) AS 'Account Name' FROM tbl_impairment WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) GROUP BY AssetNumber ORDER BY `ROPOA`;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
        End With
    End Sub

    Private Sub BtnPost_Click(sender As Object, e As EventArgs) Handles btnPost.Click
        If GridView1.RowCount = 0 Then
            Exit Sub
        End If

        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If GridView1.GetFocusedRowCellValue("impairment_status") = "POSTED" Then
            MsgBox("Schedule is already posted.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If GridView1.GetFocusedRowCellValue("impairment_status") = "CANCELLED" Then
            MsgBox("Schedule is already cancelled.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If
        If CDate(GridView1.GetFocusedRowCellValue("Month")) > Date.Now Then
            MsgBox(String.Format("Schedule is not yet due. Please wait until or after {0} to post the schedule.", GridView1.GetFocusedRowCellValue("Month")), MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes("Are you sure you want to post this schedule or impairment?") = MsgBoxResult.Yes Then
            Dim drv As DataRowView = DirectCast(cbxROPOA.SelectedItem, DataRowView)
            Dim JV As New FrmJournalVoucher
            With JV
                If FrmMain.lblDate.Text.Contains("Disconnected") Then
                    MsgBox(String.Format("Disconnected from the server {0}", _ServerName), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                .Tag = 25
                FormRestriction(.Tag)
                If allow_Access Then
                    .vSave = allow_Save
                    .vUpdate = allow_Update
                    .vDelete = allow_Delete
                    .vPrint = allow_Print
                Else
                    MsgBox(mBox_Access, MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Logs("Impairment Management", "Post", "Journal Voucher", "", "", "", "")

                .From_Impairment = True
                .CheckAmount = GridView1.GetFocusedRowCellValue("Amount")
                .cbxPayee.Tag = drv("Account Name")
                .txtReferenceNumber.Text = GridView1.GetFocusedRowCellValue("Asset Number")
                .txtReferenceNumber.Tag = GridView1.GetFocusedRowCellValue("Asset Number")
                If .ShowDialog = DialogResult.OK Then
                    DataObject(String.Format("UPDATE tbl_impairment SET impairment_status = 'POSTED', Reference = '{1}', posted_date = '{2}' WHERE ID = '{0}'", GridView1.GetFocusedRowCellValue("ID"), .txtDocumentNumber.Text, FormatDatePicker(.dtpPostingDate)))

                    Logs("Impairment Management", "Post", String.Format("Post Schedule of ROPOA for Asset Number {0} schedule {1} with monthly amount {2}", GridView1.GetFocusedRowCellValue("Asset Number"), GridView1.GetFocusedRowCellValue("Month"), GridView1.GetFocusedRowCellValue("Amount")), "", "", "", "")
                    MsgBox("Successfully Posted!", MsgBoxStyle.Information, "Info")
                    LoadData()
                End If
                .Dispose()
            End With
        End If
    End Sub
End Class