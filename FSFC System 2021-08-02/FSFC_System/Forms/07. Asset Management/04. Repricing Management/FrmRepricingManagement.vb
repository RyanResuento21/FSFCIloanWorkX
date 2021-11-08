Public Class FrmRepricingManagement

    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Private Sub FrmRepricingManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        FirstLoad = True

        Dim DT_Status As DataTable = DataSource("SELECT 'For Approval' AS 'Status' UNION SELECT 'Approved' UNION SELECT 'Approved' UNION SELECT 'Cancelled'")
        With cbxStatus
            .Location = New Point(553, 6)
            .Size = New Point(183, 26)
            .Properties.LookAndFeel.SkinName = "Blue"
            .Properties.Items.Clear()
            For x As Integer = 0 To DT_Status.Rows.Count - 1
                .Properties.Items.Add(DT_Status(x)("Status"), DT_Status(x)("Status"), If(DT_Status(x)("Status") = "Cancelled", CheckState.Unchecked, CheckState.Checked), True)
            Next
            .Properties.SeparatorChar = ";"
        End With

        cbxDisplay.SelectedIndex = 0
        LoadData()

        FirstLoad = False
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX155, LabelX10, LabelX1, LabelX39})

            GetCheckBoxFontSettings({cbxAll, cbxBatch})

            GetComboBoxFontSettings({cbxDisplay})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetButtonFontSettings({btnSearch, btnPrint, btnCancel, btnDelete, btnAttach, btnRepricing})

            GetTabControlFontSettings({SuperTabControl1})

            GetCheckComboBoxFontSettings({cbxStatus})
        Catch ex As Exception
            TriggerBugReport("Repricing Management - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Repricing Management", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    repricing_code AS 'Repricing Number',"
        SQL &= "    AssetNumber    AS 'Asset Number',"
        SQL &= "    DATE_FORMAT(trans_date,'%M %d, %Y') AS 'Date',"
        SQL &= "    ropoa_value AS 'ROPOA Value',"
        SQL &= "    last_price AS 'Last Price',"
        SQL &= "    price AS 'Suggested Price',"
        SQL &= "    approved_price AS 'Approved Price',"
        SQL &= "    DATE_FORMAT(approved_date,'%M %d, %Y')  AS 'Approved Date',"
        SQL &= "    IF(`status` IN ('CANCELLED','DELETED','DISAPPROVED'),`status`,IF(approved_date = '','FOR APPROVAL','APPROVED')) AS 'Status', attachment"
        SQL &= " FROM tbl_repricing WHERE"
        Dim Draft As Boolean
        Dim Approved As Boolean
        Dim Cancelled As Boolean
        For x As Integer = 0 To cbxStatus.Properties.Items.Count - 1
            If cbxStatus.Properties.Items.Item(x).CheckState = CheckState.Checked Then
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "For Approval" Then
                    Draft = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Approved" Then
                    Approved = True
                End If
                If cbxStatus.Properties.Items.Item(x).Description.ToString = "Cancelled" Then
                    Cancelled = True
                End If
            End If
        Next
        If Cancelled Then
            If Draft = False And Approved = False Then
                If Cancelled Then
                    SQL &= String.Format(" `status` IN ({0})", If(Cancelled, "'CANCELLED','DELETED','DISAPPROVED'", "''"))
                End If
            Else
                SQL &= String.Format(" `status` IN ('ACTIVE',{0}) ", If(Cancelled, "'CANCELLED','DELETED','DISAPPROVED'", "''"))
                If Draft And Approved Then
                Else
                    If Draft Then
                        SQL &= "    AND approved_date = ''"
                    ElseIf Approved Then
                        SQL &= "    AND approved_date != ''"
                    End If
                End If
            End If
        Else
            SQL &= " `status` = 'ACTIVE'"
            If Draft And Approved Then
            Else
                If Draft Then
                    SQL &= "    AND approved_date = ''"
                ElseIf Approved Then
                    SQL &= "    AND approved_date != ''"
                End If
            End If
        End If
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SQL &= "    AND ropoa_type = 'VE'"
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(trans_date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            SQL &= " ORDER BY repricing_code DESC;"
            GridControl1.DataSource = DataSource(SQL)
            GridView1.Columns("Repricing Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView1.Columns("Repricing Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

            If GridView1.RowCount > 0 Then
                btnAttach.Enabled = True
            Else
                btnAttach.Enabled = False
            End If

            If GridView1.RowCount > 19 Then
                GridColumn16.Width = 100 - 19
            Else
                GridColumn16.Width = 100
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SQL &= "    AND ropoa_type = 'RE'"
            If cbxAll.Checked Then
            Else
                SQL &= String.Format("    AND DATE(trans_date) BETWEEN '{0}' AND '{1}'", FormatDatePicker(dtpFrom), FormatDatePicker(dtpTo))
            End If
            SQL &= " ORDER BY repricing_code DESC;"
            GridControl2.DataSource = DataSource(SQL)
            GridView2.Columns("Repricing Number").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
            GridView2.Columns("Repricing Number").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

            If GridView2.RowCount > 0 Then
                btnAttach.Enabled = True
            Else
                btnAttach.Enabled = False
            End If

            If GridView2.RowCount > 19 Then
                GridColumn18.Width = 100 - 19
            Else
                GridColumn18.Width = 100
            End If
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            If Status = "DISAPPROVED" Or Status = "CANCELLED" Or Status = "DELETED" Then
                e.Appearance.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub GridView2_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView2.RowCellStyle
        If GridView2.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            If Status = "DISAPPROVED" Or Status = "CANCELLED" Or Status = "DELETED" Then
                e.Appearance.ForeColor = Color.Red
            End If
        End If
    End Sub

    Private Sub CbxDisplay_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDisplay.SelectedIndexChanged
        If cbxDisplay.SelectedIndex = 0 Then
            dtpFrom.Value = Date.Now
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = Date.Now
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 1 Then
            Dim today As Date = Date.Today
            Dim dayDiff As Integer = today.DayOfWeek - DayOfWeek.Monday
            Dim monday As Date = today.AddDays(-dayDiff)

            dtpFrom.Value = monday
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = monday.AddDays(6)
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 2 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-MM-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, String.Format("yyyy-MM-{0}", Date.DaysInMonth(Format(Date.Now, "yyyy"), Format(Date.Now, "MM")))))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 3 Then
            dtpFrom.Value = DateValue(Format(Date.Now, "yyyy-01-01"))
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Value = DateValue(Format(Date.Now, "yyyy-12-31"))
            dtpTo.Enabled = False
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        ElseIf cbxDisplay.SelectedIndex = 4 Then
            dtpFrom.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"

            dtpTo.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        LoadData()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        If SuperTabControl1.SelectedTabIndex = 0 Then
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ROPOA VL REPRICING LIST", GridControl1)
            Logs("Repricing Management", "Print", "[SENSITIVE] Print VL Repricing List", "", "", "", "")
        Else
            GridView2.OptionsPrint.UsePrintStyles = False
            StandardPrinting("ROPOA RE REPRICING LIST", GridControl2)
            Logs("Repricing Management", "Print", "[SENSITIVE] Print RE Repricing List", "", "", "", "")
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAll.CheckedChanged
        If cbxAll.Checked Then
            cbxDisplay.SelectedIndex = -1
            cbxDisplay.Enabled = False
            dtpFrom.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpTo.Enabled = False
            dtpTo.CustomFormat = ""
        Else
            cbxDisplay.SelectedIndex = 0
            cbxDisplay.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpTo.CustomFormat = "MMMM dd, yyyy"
        End If
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
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAttach.Focus()
            btnAttach.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.R Then
            btnRepricing.Focus()
            btnRepricing.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub DtpFrom_Leave(sender As Object, e As EventArgs) Handles dtpFrom.Leave
        dtpTo.MinDate = dtpFrom.Value
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            If SuperTabControl1.SelectedTabIndex = 0 Then
                .FolderName = GridView1.GetFocusedRowCellValue("Repricing Number")
                .TotalImage = GridView1.GetFocusedRowCellValue("attachment")
                .ID = GridView1.GetFocusedRowCellValue("Repricing Number")
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                .FolderName = GridView2.GetFocusedRowCellValue("Repricing Number")
                .TotalImage = GridView2.GetFocusedRowCellValue("attachment")
                .ID = GridView2.GetFocusedRowCellValue("Repricing Number")
            End If
            .Type = "Repricing"
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
            End If
            .Dispose()
        End With
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnNext.Enabled = True
            If GridView1.RowCount > 0 Then
                btnAttach.Enabled = True
            Else
                btnAttach.Enabled = False
            End If
        Else
            btnBack.Enabled = True
            btnNext.Enabled = False
            If GridView2.RowCount > 0 Then
                btnAttach.Enabled = True
            Else
                btnAttach.Enabled = False
            End If
        End If
    End Sub

    Private Sub CbxDraft_CheckedChanged(sender As Object, e As EventArgs)
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub CbxApproved_CheckedChanged(sender As Object, e As EventArgs)
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub BtnRepricing_Click(sender As Object, e As EventArgs) Handles btnRepricing.Click
        Dim Repricing As New FrmROPOARepricing
        With Repricing
            .Tag = 55
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

            .FromReprice = True
            If cbxBatch.Checked Then
                .Batch = True
            Else
                If SuperTabControl1.SelectedTabIndex = 0 Then
                    If GridView1.GetFocusedRowCellValue("Status") = "Approved" Then
                        MsgBox(String.Format("Repricing for ROPOA {0} is already approved.", GridView1.GetFocusedRowCellValue("Asset Number")), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                    If GridView2.GetFocusedRowCellValue("Status") = "Approved" Then
                        MsgBox(String.Format("Repricing for ROPOA {0} is already approved.", GridView2.GetFocusedRowCellValue("Asset Number")), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If
                End If
            End If
            If SuperTabControl1.SelectedTabIndex = 0 Then
                If GridView1.RowCount = 0 Then
                    Exit Sub
                End If
                .tabRealEstate.Visible = False
                .SuperTabControl1.SelectedTab = .tabVehicle
                .RePricing_Code = GridView1.GetFocusedRowCellValue("Repricing Number")
                .AssetNumber = GridView1.GetFocusedRowCellValue("Asset Number")
            ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
                If GridView2.RowCount = 0 Then
                    Exit Sub
                End If
                .tabVehicle.Visible = False
                .SuperTabControl1.SelectedTab = .tabRealEstate
                .RePricing_Code = GridView2.GetFocusedRowCellValue("Repricing Number")
                .AssetNumber = GridView2.GetFocusedRowCellValue("Asset Number")
            End If
            If .ShowDialog = DialogResult.OK Then
                LoadData()
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If SuperTabControl1.SelectedTabIndex = 0 Then
            If GridView1.RowCount > 0 Then
                If GridView1.GetFocusedRowCellValue("Status") = "APPROVED" Then
                    MsgBox("Repricing is already approved! Deletion is not allowed.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
                    Dim Reason As String 'Reason for change
                    If FrmReason.ShowDialog = DialogResult.OK Then
                        Reason = FrmReason.txtReason.Text
                    Else
                        Exit Sub
                    End If

                    DataObject(String.Format("UPDATE tbl_repricing SET `status` = 'DELETED' WHERE AssetNumber = '{0}' AND repricing_code = '{1}'", GridView1.GetFocusedRowCellValue("Asset Number"), GridView1.GetFocusedRowCellValue("Repricing Number")))
                    Logs("Repricing Management", "Cancel", Reason, String.Format("Cancel ROPOA Vehicle Repricing with Asset Number {0}", GridView1.GetFocusedRowCellValue("Asset Number")), "", "", "")
                    LoadData()
                    MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
                End If
            End If
        Else
            If GridView2.RowCount > 0 Then
                If GridView2.GetFocusedRowCellValue("Status") = "APPROVED" Then
                    MsgBox("Repricing is already approved! Deletion is not allowed.", MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
                    Dim Reason As String 'Reason for change
                    If FrmReason.ShowDialog = DialogResult.OK Then
                        Reason = FrmReason.txtReason.Text
                    Else
                        Exit Sub
                    End If

                    DataObject(String.Format("UPDATE tbl_repricing SET `status` = 'DELETED' WHERE AssetNumber = '{0}' AND repricing_code = '{1}'", GridView2.GetFocusedRowCellValue("Asset Number"), GridView2.GetFocusedRowCellValue("Repricing Number")))
                    Logs("Repricing Management", "Cancel", Reason, String.Format("Cancel ROPOA Real Estate Repricing with Asset Number {0}", GridView2.GetFocusedRowCellValue("Asset Number")), "", "", "")
                    LoadData()
                    MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabRealEstate
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabVehicle
        End If
    End Sub
End Class