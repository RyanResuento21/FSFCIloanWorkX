Public Class FrmHolidaySetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmHolidaySetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        dtpDate.Value = Date.Now

        If Branch_ID = 0 Then
        Else
            cbxType.Items.Clear()
            cbxType.Items.Add("Local Holiday")
        End If
        LoadData()
    End Sub

    Private Sub BtnLogs_Click(sender As Object, e As EventArgs) Handles btnLogs.Click
        LblTitle_Click(sender, e)
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX2, LabelX3, LabelX4, LabelX1})

            GetTextBoxFontSettings({txtHoliday, txtRemarks})

            GetComboBoxWinFormFontSettings({cbxType})

            GetDateTimeInputFontSettings({dtpDate})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnCopy})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Holiday Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Holiday Setup", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource(String.Format("SELECT ID, Holiday, DATE_FORMAT(`Date`, '%M %d') AS 'Date', DATE_FORMAT(`Date`,'%Y') AS 'Year', `Type`, Remarks, Branch(BranchID) AS 'Branch' FROM holiday_setup WHERE `status` = 'ACTIVE' AND IF(`Type` = 'Local Holiday',BranchID = '{0}',TRUE) ORDER BY DATE(`Date`) ASC;", Branch_ID))
        If Multiple_ID.Contains(",") Then
            GridColumn8.Visible = True
            GridColumn8.VisibleIndex = 5
        End If
        GridView1.Columns("Holiday").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Holiday").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 21 Then
            GridColumn6.Width = 478 - 17
        Else
            GridColumn6.Width = 478
        End If
        If Multiple_ID.Contains(",") Then
            GridColumn8.Visible = True
            GridColumn8.VisibleIndex = 5
            GridColumn6.Width = GridColumn6.Width - 200
        End If

        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub TxtHoliday_KeyDown(sender As Object, e As KeyEventArgs) Handles txtHoliday.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpDate.Focus()
        End If
    End Sub

    Private Sub DtpDate_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpDate.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxType.Focus()
        End If
    End Sub

    Private Sub CbxType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtRemarks.Focus()
        End If
    End Sub

    Private Sub TxtRemarks_KeyDown(sender As Object, e As KeyEventArgs) Handles txtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtHoliday_Leave(sender As Object, e As EventArgs) Handles txtHoliday.Leave
        txtHoliday.Text = ReplaceText(txtHoliday.Text.Trim)
    End Sub

    Private Sub TxtRemarks_Leave(sender As Object, e As EventArgs) Handles txtRemarks.Leave
        txtRemarks.Text = ReplaceText(txtRemarks.Text.Trim)
    End Sub
    '***LEAVE

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Then
            btnBack.Enabled = False
            btnAdd.Enabled = False
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnPrint.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
            btnCopy.Enabled = False
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
            If Branch_ID = 0 Then
                btnCopy.Enabled = True
            End If
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        txtHoliday.Focus()
        txtHoliday.Text = ""
        dtpDate.Value = Date.Now
        cbxType.SelectedIndex = 0
        txtRemarks.Text = ""
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtHoliday.Text = "" Then
            MsgBox("Please fill holiday name.", MsgBoxStyle.Information, "Info")
            txtHoliday.Focus()
            Exit Sub
        End If
        If cbxType.SelectedIndex = -1 Then
            MsgBox("Please select type of holiday.", MsgBoxStyle.Information, "Info")
            cbxType.DroppedDown = True
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM holiday_setup WHERE `Date` = '{0}' AND `status` = 'ACTIVE' AND IF(`Type` = 'Local Holiday',BranchID = '{1}',TRUE);", Format(dtpDate.Value, "yyyy-MM-dd"), Branch_ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Date {0} already exist, Please check your data.", dtpDate.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO holiday_setup SET"
                SQL &= String.Format(" `Holiday` = '{0}', ", txtHoliday.Text)
                SQL &= String.Format(" `Date` = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" `Type` = '{0}', ", cbxType.Text)
                SQL &= String.Format(" `Remarks` = '{0}', ", txtRemarks.Text)
                SQL &= String.Format(" `BranchID` = '{0}' ", Branch_ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Holiday Setup", "Save", String.Format("Add new Holiday {0} dated {1}", txtHoliday.Text, dtpDate.Text), "", "", "", "")
                DT_Holidays = DataSource(String.Format("SELECT Holiday, `Date` FROM holiday_setup WHERE `status` = 'ACTIVE' AND IF(`Type` = 'Local Holiday',BranchID = '{0}',TRUE);", Branch_ID))
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM holiday_setup WHERE `Date` = '{0}' AND `status` = 'ACTIVE' AND IF(`Type` = 'Local Holiday',BranchID = '{1}',TRUE) AND ID != '{2}';", Format(dtpDate.Value, "yyyy-MM-dd"), Branch_ID, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Date {0} already exist, Please check your data.", dtpDate.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE holiday_setup SET"
                SQL &= String.Format(" `Holiday` = '{0}', ", txtHoliday.Text)
                SQL &= String.Format(" `Date` = '{0}', ", Format(dtpDate.Value, "yyyy-MM-dd"))
                SQL &= String.Format(" `Type` = '{0}', ", cbxType.Text)
                SQL &= String.Format(" `Remarks` = '{0}' ", txtRemarks.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Holiday Setup", "Update", Reason, Changes(), "", "", "")
                DT_Holidays = DataSource(String.Format("SELECT Holiday, `Date` FROM holiday_setup WHERE `status` = 'ACTIVE' AND IF(`Type` = 'Local Holiday',BranchID = '{0}',TRUE);", Branch_ID))
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtHoliday.Text = txtHoliday.Tag Then
            Else
                Change &= String.Format("Change Holiday from {0} to {1}. ", txtHoliday.Tag, txtHoliday.Text)
            End If
            If dtpDate.Text = dtpDate.Tag Then
            Else
                Change &= String.Format("Change Date from {0} to {1}. ", dtpDate.Tag, dtpDate.Text)
            End If
            If cbxType.Text = cbxType.Tag Then
            Else
                Change &= String.Format("Change Type from {0} to {1}. ", cbxType.Tag, cbxType.Text)
            End If
            If txtRemarks.Text = txtRemarks.Tag Then
            Else
                Change &= String.Format("Change Remarks from {0} to {1}. ", txtRemarks.Tag, txtRemarks.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Holiday Setup - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            btnSave.Text = "Update"
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = True
            PanelEx10.Enabled = True
        End If
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If vDelete Then
        Else
            MsgBox(mBox_Delete, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mDelete) = MsgBoxResult.Yes Then
            Dim Reason As String 'Reason for change
            If FrmReason.ShowDialog = DialogResult.OK Then
                Reason = FrmReason.txtReason.Text
            Else
                Exit Sub
            End If

            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE holiday_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Holiday Setup", "Cancel", Reason, String.Format("Cancel Holiday {0} dated {1}", txtHoliday.Text, dtpDate.Text), "", "", "")
            DT_Holidays = DataSource(String.Format("SELECT Holiday, `Date` FROM holiday_setup WHERE `status` = 'ACTIVE' AND IF(`Type` = 'Local Holiday',BranchID = '{0}',TRUE);", Branch_ID))
            Clear(True)
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
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
        StandardPrinting("HOLIDAY LIST", GridControl1)
        Logs("Holiday", "Print", "Print Holiday List", "", "", "", "")
        Cursor = Cursors.Default
    End Sub
    '***BUTTON CLICK

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.B Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.N Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnModify.Focus()
            btnModify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Left) Or (e.Control And e.KeyCode = Keys.Down) Then
            btnBack.Focus()
            btnBack.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.Right) Or (e.Control And e.KeyCode = Keys.Up) Then
            btnNext.Focus()
            btnNext.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub GridView1_KeyDown(sender As Object, e As KeyEventArgs) Handles GridView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            GridView1_DoubleClick(sender, e)
        End If
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            txtHoliday.Text = .GetFocusedRowCellValue("Holiday")
            txtHoliday.Tag = .GetFocusedRowCellValue("Holiday")
            dtpDate.Value = .GetFocusedRowCellValue("Date") & ", " & .GetFocusedRowCellValue("Year")
            dtpDate.Tag = .GetFocusedRowCellValue("Date") & ", " & .GetFocusedRowCellValue("Year")
            cbxType.Text = .GetFocusedRowCellValue("Type")
            cbxType.Tag = .GetFocusedRowCellValue("Type")
            txtRemarks.Text = .GetFocusedRowCellValue("Remarks")
            txtRemarks.Tag = .GetFocusedRowCellValue("Remarks")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        DT_Holidays = DataSource(String.Format("SELECT Holiday, `Date` FROM holiday_setup WHERE `status` = 'ACTIVE' AND IF(`Type` = 'Local Holiday',BranchID = '{0}',TRUE);", Branch_ID))
        If MsgBoxYes(String.Format("Are you sure you want to copy all the regular holidays of year {0} to year {1}.", GridView1.GetFocusedRowCellValue("Year"), CInt(GridView1.GetFocusedRowCellValue("Year")) + 1)) = MsgBoxResult.Yes Then
            Dim DT_PrevHolidays As DataTable = DataSource(String.Format("SELECT Holiday, `Date`, `Type`, Remarks, BranchID FROM holiday_setup WHERE `Type` = 'Regular Holiday' AND `status` = 'ACTIVE' AND YEAR(`Date`) = '{0}'", GridView1.GetFocusedRowCellValue("Year")))
            Dim SQL As String = ""
            For x As Integer = 0 To DT_PrevHolidays.Rows.Count - 1
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM holiday_setup WHERE `Date` = '{0}' AND `status` = 'ACTIVE' AND IF(`Type` = 'Local Holiday',BranchID = '{1}',TRUE);", Format(CDate(DT_PrevHolidays(x)("Date")).AddYears(1), "yyyy-MM-dd"), Branch_ID))
                If Exist > 0 Then
                    GoTo Here
                End If

                SQL &= " INSERT INTO holiday_setup SET"
                SQL &= String.Format(" `Holiday` = '{0}', ", DT_PrevHolidays(x)("Holiday"))
                SQL &= String.Format(" `Date` = '{0}', ", Format(CDate(DT_PrevHolidays(x)("Date")).AddYears(1), "yyyy-MM-dd"))
                SQL &= String.Format(" `Type` = '{0}', ", DT_PrevHolidays(x)("Type"))
                SQL &= String.Format(" `Remarks` = '{0}', ", DT_PrevHolidays(x)("Remarks"))
                SQL &= String.Format(" `BranchID` = '{0}';", Branch_ID)
                Logs("Holiday Setup", "Save", String.Format("Add new Holiday {0} dated {1}", DT_PrevHolidays(x)("Holiday"), CDate(DT_PrevHolidays(x)("Date")).AddYears(1)), "", "", "", "")
Here:
            Next
            If SQL = "" Then
            Else
                DataObject(SQL)
            End If

            DT_Holidays = DataSource(String.Format("SELECT Holiday, `Date` FROM holiday_setup WHERE `status` = 'ACTIVE' AND IF(`Type` = 'Local Holiday',BranchID = '{0}',TRUE);", Branch_ID))
            LoadData()
            MsgBox("Successfully Copied!", MsgBoxStyle.Information, "Info")
        End If
    End Sub
End Class