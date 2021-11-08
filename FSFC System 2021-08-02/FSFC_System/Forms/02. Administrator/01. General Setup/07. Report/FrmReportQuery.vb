Public Class FrmReportQuery

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmReportQuery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        LoadData()

        If User_Type = "ADMIN" Then
            tabSetup.Visible = True
            GridColumn3.Visible = True
            GridColumn6.Visible = True
            GridColumn9.Visible = True
            GridColumn2.Width = 400
            GridColumn5.Width = 400
            GridColumn8.Width = 400
        Else
            tabSetup.Visible = False
            GridColumn3.Visible = False
            GridColumn6.Visible = False
            GridColumn9.Visible = False
            GridColumn2.Width = 1148
            GridColumn5.Width = 1148
            GridColumn8.Width = 1148
        End If
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

            GetLabelFontSettings({LabelX155, LabelX2})

            GetLabelFontSettingsRed({LabelX1})

            GetTextBoxFontSettings({txtReportName})

            GetRickTextBoxFontSettings({rQuery})

            GetCheckBoxFontSettings({cbxBorrower, cbxLoans, cbxROPOA})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Report Query - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Report", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        'Borrower
        GridControl1.DataSource = DataSource("SELECT ID, Report AS 'Report Name', `Query` AS 'Report' FROM report_query WHERE `status` = 'ACTIVE' AND `Type` = 'Borrower' ORDER BY Report;")
        GridView1.Columns("Report Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Report Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView1.RowCount > 22 Then
            GridColumn3.Width = 731
        Else
            GridColumn3.Width = 748
        End If

        'Loan
        GridControl2.DataSource = DataSource("SELECT ID, Report AS 'Report Name', `Query` AS 'Report' FROM report_query WHERE `status` = 'ACTIVE' AND `Type` = 'Loan' ORDER BY Report;")
        GridView2.Columns("Report Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("Report Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView2.RowCount > 22 Then
            GridColumn6.Width = 731
        Else
            GridColumn6.Width = 748
        End If

        'ROPOA
        GridControl3.DataSource = DataSource("SELECT ID, Report AS 'Report Name', `Query` AS 'Report' FROM report_query WHERE `status` = 'ACTIVE' AND `Type` = 'ROPOA' ORDER BY Report;")
        GridView3.Columns("Report Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView3.Columns("Report Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView3.RowCount > 22 Then
            GridColumn9.Width = 731
        Else
            GridColumn9.Width = 748
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxBorrower_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBorrower.CheckedChanged
        If cbxBorrower.Checked Then
            cbxLoans.Checked = False
            cbxROPOA.Checked = False
        End If

        If cbxBorrower.Checked = False And cbxLoans.Checked = False And cbxROPOA.Checked = False Then
            cbxBorrower.Checked = True
        End If
    End Sub

    Private Sub CbxLoans_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLoans.CheckedChanged
        If cbxLoans.Checked Then
            cbxBorrower.Checked = False
            cbxROPOA.Checked = False
        End If

        If cbxBorrower.Checked = False And cbxLoans.Checked = False And cbxROPOA.Checked = False Then
            cbxBorrower.Checked = True
        End If
    End Sub

    Private Sub CbxROPOA_CheckedChanged(sender As Object, e As EventArgs) Handles cbxROPOA.CheckedChanged
        If cbxROPOA.Checked Then
            cbxBorrower.Checked = False
            cbxLoans.Checked = False
        End If

        If cbxBorrower.Checked = False And cbxLoans.Checked = False And cbxROPOA.Checked = False Then
            cbxBorrower.Checked = True
        End If
    End Sub

    '***KEYDOWN
    Private Sub TxtReportName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReportName.KeyDown
        If e.KeyCode = Keys.Enter Then
            rQuery.Focus()
        End If
    End Sub

    Private Sub RQuery_KeyDown(sender As Object, e As KeyEventArgs) Handles rQuery.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub

    '***LEAVE
    Private Sub TxtReportName_Leave(sender As Object, e As EventArgs) Handles txtReportName.Leave
        txtReportName.Text = ReplaceText(txtReportName.Text)
    End Sub

    Private Sub RQuery_Leave(sender As Object, e As EventArgs) Handles rQuery.Leave
        rQuery.Text = ReplaceText(rQuery.Text)
    End Sub
    '***LEAVE

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabBorrower
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabLoanApplication
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabROPOA
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 3 Then
            SuperTabControl1.SelectedTab = tabLoanApplication
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabBorrower
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
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
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            'Clear()
            If tabSetup.Visible Then
                btnAdd.Enabled = True
                btnBack.Enabled = True
            Else
                btnAdd.Enabled = False
                btnBack.Enabled = False
            End If
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            'Clear()
            If tabSetup.Visible Then
                btnAdd.Enabled = True
            Else
                btnAdd.Enabled = False
            End If
            btnBack.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            'Clear()
            If tabSetup.Visible Then
                btnAdd.Enabled = True
            Else
                btnAdd.Enabled = False
            End If
            btnBack.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
                Clear(False)
            End If
        Else
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        txtReportName.Text = ""
        rQuery.Text = ""
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtReportName.Text = "" Then
            MsgBox("Please fill Procedure Name field.", MsgBoxStyle.Information, "Info")
            txtReportName.Focus()
            Exit Sub
        End If
        If rQuery.Text = "" Then
            MsgBox("Please fill a correct query.", MsgBoxStyle.Information, "Info")
            rQuery.Focus()
            Exit Sub
        Else
            If rQuery.Text.ToUpper.Contains("DELETE") Or rQuery.Text.ToUpper.Contains("UPDATE") Then
                MsgBox("Query contains a delete/update function which is not allowed in this report. Please check you query.", MsgBoxStyle.Information, "Info")
                rQuery.Focus()
                If User_Type = "ADMIN" Then
                    Dim PW As New FrmPassword
                    With PW
                        .ShowMessage = False
                        .lblNote.Text = "*For IT Password only."
HERE:
                        If .ShowDialog = DialogResult.OK Then
                            If IT_PW = DataObject(String.Format("SELECT MD5(SHA1('{0}'))", ReplaceText(.txtPassword.Text))) Then
                                GoTo Herev2
                            Else
                                MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                                .txtPassword.Text = ""
                                GoTo HERE
                            End If
                        End If
                        .Dispose()
                    End With
                End If
                Exit Sub
            End If
        End If

Herev2:
        Dim Type As String = ""
        If cbxBorrower.Checked Then
            Type = "Borrower"
        ElseIf cbxLoans.Checked Then
            Type = "Loan"
        ElseIf cbxROPOA.Checked Then
            Type = "ROPOA"
        End If
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM report_query WHERE (Report = '{0}' AND `Type` = '{1}') AND `status` = 'ACTIVE'", txtReportName.Text, Type))
                If Exist > 0 Then
                    MsgBox(String.Format("Report {0} on {1} already exist, Please check your procedure name to prevent confusion. Thank you.", txtReportName.Text, Type), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO report_query SET"
                SQL &= String.Format(" Report = '{0}', ", txtReportName.Text)
                SQL &= String.Format(" `Query` = '{0}', ", rQuery.Text)
                SQL &= String.Format(" `Type` = '{0}', ", Type)
                SQL &= String.Format(" user_code = '{0}' ", User_Code)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Report", "Save", String.Format("Add new Report {0} on {1}", txtReportName.Text, Type), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM report_query WHERE (Report = '{0}' AND `Type` = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}'", txtReportName.Text, Type, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Report {0} on {1} already exist, Please check your procedure name to prevent confusion. Thank you.", txtReportName.Text, Type), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE report_query SET"
                SQL &= String.Format(" Report = '{0}', ", txtReportName.Text)
                SQL &= String.Format(" `Query` = '{0}', ", rQuery.Text)
                SQL &= String.Format(" `Type` = '{0}' ", Type)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Report", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtReportName.Text = txtReportName.Tag Then
            Else
                Change &= String.Format("Change Procedure Name from {0} to {1}. ", txtReportName.Tag, txtReportName.Text)
            End If
            If cbxBorrower.Tag <> "Borrower" And cbxBorrower.Checked Then
                Change &= String.Format("Change Procedure Type from {0} to {1}. ", cbxBorrower.Tag, cbxBorrower.Text)
            ElseIf cbxLoans.Tag <> "Loan" And cbxLoans.Checked Then
                Change &= String.Format("Change Procedure Type from {0} to {1}. ", cbxLoans.Tag, cbxLoans.Text)
            ElseIf cbxROPOA.Tag <> "ROPOA" And cbxROPOA.Checked Then
                Change &= String.Format("Change Procedure Types from {0} to {1}. ", cbxROPOA.Tag, cbxROPOA.Text)
            End If
            If rQuery.Text = rQuery.Tag Then
            Else
                Change &= String.Format("Change Query from {0} to {1}. ", rQuery.Tag, rQuery.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Report Query - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE report_query SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Report", "Cancel", Reason, String.Format("Cancel Report {0}", txtReportName.Text), "", "", "")
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

        Try
            Cursor = Cursors.WaitCursor
            If SuperTabControl1.SelectedTabIndex = 1 Then
                If GridView1.RowCount > 0 Then
                    Dim Table As New FrmReportTable
                    With Table
                        .GridView4.Columns.Clear()
                        .GridControl4.DataSource = DataSource(String.Format(GridView1.GetFocusedRowCellValue("Report"), Branch_ID))
                        .Title = GridView1.GetFocusedRowCellValue("Report Name")
                        .ShowDialog()
                        .Dispose()
                    End With
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                If GridView2.RowCount > 0 Then
                    Dim Table As New FrmReportTable
                    With Table
                        .GridView4.Columns.Clear()
                        .GridControl4.DataSource = DataSource(String.Format(GridView2.GetFocusedRowCellValue("Report"), Branch_ID))
                        .Title = GridView2.GetFocusedRowCellValue("Report Name")
                        .ShowDialog()
                        .Dispose()
                    End With
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                If GridView3.RowCount > 0 Then
                    Dim Table As New FrmReportTable
                    With Table
                        .GridView4.Columns.Clear()
                        .GridControl4.DataSource = DataSource(String.Format(GridView3.GetFocusedRowCellValue("Report"), Branch_ID))
                        .Title = GridView3.GetFocusedRowCellValue("Report Name")
                        .ShowDialog()
                        .Dispose()
                    End With
                End If
            End If
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            TriggerBugReport("Report Query - Print", ex.Message.ToString)
            'Exit Sub
        End Try
    End Sub

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
        ElseIf e.Control And e.KeyCode = Keys.O Then
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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        If tabSetup.Visible = False Then
            btnPrint.PerformClick()
            Exit Sub
        End If

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
            txtReportName.Text = .GetFocusedRowCellValue("Report Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Report Name")
            rQuery.Tag = .GetFocusedRowCellValue("Report")
            rQuery.Text = .GetFocusedRowCellValue("Report")
        End With
        cbxBorrower.Checked = True
        cbxBorrower.Tag = "Borrower"
        cbxLoans.Tag = "Borrower"
        cbxROPOA.Tag = "Borrower"

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
        If tabSetup.Visible = False Then
            btnPrint.PerformClick()
            Exit Sub
        End If

        Try
            If GridView2.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        With GridView2
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Report Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Report Name")
            rQuery.Tag = .GetFocusedRowCellValue("Report")
            rQuery.Text = .GetFocusedRowCellValue("Report")
        End With
        cbxLoans.Checked = True
        cbxBorrower.Tag = "Loan"
        cbxLoans.Tag = "Loan"
        cbxROPOA.Tag = "Loan"

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
        If tabSetup.Visible = False Then
            btnPrint.PerformClick()
            Exit Sub
        End If

        Try
            If GridView3.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        With GridView3
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Report Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Report Name")
            rQuery.Tag = .GetFocusedRowCellValue("Report")
            rQuery.Text = .GetFocusedRowCellValue("Report")
        End With
        cbxROPOA.Checked = True
        cbxBorrower.Tag = "ROPOA"
        cbxLoans.Tag = "ROPOA"
        cbxROPOA.Tag = "ROPOA"

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub
End Class