Public Class FrmHelp

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    ReadOnly ReportP As String = String.Format("{0}\{1}\PROCEDURES\", RootFolder, MainFolder)
    ReadOnly ReportP_2 As String = String.Format("{0}\\{1}\\PROCEDURES\\", If(UCase(_ServerName) = "LOCALHOST", RootFolder, "\\\\" & _ServerName), If(MainFolder.Contains("Testing"), MainFolder.Replace("Testing", "\Testing"), MainFolder))
    Dim FileName As String
    Private Sub FrmHelp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3, GridView4, GridView5})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        txtReportPath.Text = ReportP
        LoadData()

        If User_Type = "ADMIN" Then
            tabSetup.Visible = True
            GridColumn3.Visible = True
            GridColumn6.Visible = True
            GridColumn9.Visible = True
            GridColumn12.Visible = True
            GridColumn15.Visible = True
            GridColumn2.Width = 400
            GridColumn5.Width = 400
            GridColumn8.Width = 400
            GridColumn11.Width = 400
            GridColumn14.Width = 400
        Else
            tabSetup.Visible = False
            GridColumn3.Visible = False
            GridColumn6.Visible = False
            GridColumn9.Visible = False
            GridColumn12.Visible = False
            GridColumn15.Visible = False
            GridColumn2.Width = 1148
            GridColumn5.Width = 1148
            GridColumn8.Width = 1148
            GridColumn11.Width = 1148
            GridColumn14.Width = 1148
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

            GetLabelFontSettings({LabelX155, LabelX2, LabelX1})

            GetTextBoxFontSettings({txtReportName, txtSource, txtReportPath})

            GetCheckBoxFontSettings({cbxBorrower, cbxLoans, cbxROPOA, cbxFinance, cbxNonLoans})

            GetButtonFontSettings({btnBrowse, btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Help - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Help", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        'Borrower
        GridControl1.DataSource = DataSource("SELECT ID, Report AS 'Procedure Name', Path AS 'Procedure' FROM help_setup WHERE `status` = 'ACTIVE' AND `Type` = 'Borrower' ORDER BY Report;")
        GridView1.Columns("Procedure Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Procedure Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView1.RowCount > 22 Then
            GridColumn3.Width = 731
        Else
            GridColumn3.Width = 748
        End If

        'Loan
        GridControl2.DataSource = DataSource("SELECT ID, Report AS 'Procedure Name', Path AS 'Procedure' FROM help_setup WHERE `status` = 'ACTIVE' AND `Type` = 'Loan' ORDER BY Report;")
        GridView2.Columns("Procedure Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("Procedure Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView2.RowCount > 22 Then
            GridColumn6.Width = 731
        Else
            GridColumn6.Width = 748
        End If

        'ROPOA
        GridControl3.DataSource = DataSource("SELECT ID, Report AS 'Procedure Name', Path AS 'Procedure' FROM help_setup WHERE `status` = 'ACTIVE' AND `Type` = 'ROPOA' ORDER BY Report;")
        GridView3.Columns("Procedure Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView3.Columns("Procedure Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView3.RowCount > 22 Then
            GridColumn9.Width = 731
        Else
            GridColumn9.Width = 748
        End If

        'FINANCE
        GridControl4.DataSource = DataSource("SELECT ID, Report AS 'Procedure Name', Path AS 'Procedure' FROM help_setup WHERE `status` = 'ACTIVE' AND `Type` = 'Finance' ORDER BY Report;")
        GridView4.Columns("Procedure Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView4.Columns("Procedure Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView4.RowCount > 22 Then
            GridColumn12.Width = 731
        Else
            GridColumn12.Width = 748
        End If

        'Non Loans
        GridControl5.DataSource = DataSource("SELECT ID, Report AS 'Procedure Name', Path AS 'Procedure' FROM help_setup WHERE `status` = 'ACTIVE' AND `Type` = 'Non Loans' ORDER BY Report;")
        GridView5.Columns("Procedure Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView5.Columns("Procedure Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView5.RowCount > 22 Then
            GridColumn15.Width = 731
        Else
            GridColumn15.Width = 748
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxBorrower_CheckedChanged(sender As Object, e As EventArgs) Handles cbxBorrower.CheckedChanged
        If cbxBorrower.Checked Then
            cbxLoans.Checked = False
            cbxROPOA.Checked = False
            cbxFinance.Checked = False
            cbxNonLoans.Checked = False
        End If

        If cbxBorrower.Checked = False And cbxLoans.Checked = False And cbxROPOA.Checked = False And cbxFinance.Checked = False And cbxNonLoans.Checked = False Then
            cbxBorrower.Checked = True
        End If
    End Sub

    Private Sub CbxLoans_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLoans.CheckedChanged
        If cbxLoans.Checked Then
            cbxBorrower.Checked = False
            cbxROPOA.Checked = False
            cbxFinance.Checked = False
            cbxNonLoans.Checked = False
        End If

        If cbxBorrower.Checked = False And cbxLoans.Checked = False And cbxROPOA.Checked = False And cbxFinance.Checked = False And cbxNonLoans.Checked = False Then
            cbxBorrower.Checked = True
        End If
    End Sub

    Private Sub CbxROPOA_CheckedChanged(sender As Object, e As EventArgs) Handles cbxROPOA.CheckedChanged
        If cbxROPOA.Checked Then
            cbxBorrower.Checked = False
            cbxLoans.Checked = False
            cbxFinance.Checked = False
            cbxNonLoans.Checked = False
        End If

        If cbxBorrower.Checked = False And cbxLoans.Checked = False And cbxROPOA.Checked = False And cbxFinance.Checked = False And cbxNonLoans.Checked = False Then
            cbxBorrower.Checked = True
        End If
    End Sub

    Private Sub CbxFinance_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFinance.CheckedChanged
        If cbxFinance.Checked Then
            cbxBorrower.Checked = False
            cbxLoans.Checked = False
            cbxROPOA.Checked = False
            cbxNonLoans.Checked = False
        End If

        If cbxBorrower.Checked = False And cbxLoans.Checked = False And cbxROPOA.Checked = False And cbxFinance.Checked = False And cbxNonLoans.Checked = False Then
            cbxBorrower.Checked = True
        End If
    End Sub

    Private Sub CbxNonLoans_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNonLoans.CheckedChanged
        If cbxNonLoans.Checked Then
            cbxBorrower.Checked = False
            cbxLoans.Checked = False
            cbxROPOA.Checked = False
            cbxFinance.Checked = False
        End If

        If cbxBorrower.Checked = False And cbxLoans.Checked = False And cbxROPOA.Checked = False And cbxFinance.Checked = False And cbxNonLoans.Checked = False Then
            cbxBorrower.Checked = True
        End If
    End Sub

    '***KEYDOWN
    Private Sub TxtReportName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReportName.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnBrowse.Focus()
        End If
    End Sub

    Private Sub BtnBrowse_KeyDown(sender As Object, e As KeyEventArgs) Handles btnBrowse.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxBorrower.Focus()
        End If
    End Sub

    Private Sub CbxBorrower_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBorrower.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxLoans.Focus()
        End If
    End Sub

    Private Sub CbxLoans_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxLoans.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxROPOA.Focus()
        End If
    End Sub

    Private Sub CbxROPOA_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxROPOA.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtReportName_Leave(sender As Object, e As EventArgs) Handles txtReportName.Leave
        txtReportName.Text = ReplaceText(txtReportName.Text)
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
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            SuperTabControl1.SelectedTab = tabFinance
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            SuperTabControl1.SelectedTab = tabNonLoans
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 5 Then
            SuperTabControl1.SelectedTab = tabFinance
        ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
            SuperTabControl1.SelectedTab = tabROPOA
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
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
            btnRefresh.Enabled = True
            btnModify.Enabled = False
            btnPrint.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Or SuperTabControl1.SelectedTabIndex = 2 Or SuperTabControl1.SelectedTabIndex = 3 Or SuperTabControl1.SelectedTabIndex = 4 Then
            If tabSetup.Visible Then
                btnAdd.Enabled = True
                btnBack.Enabled = True
            Else
                btnAdd.Enabled = False
                btnBack.Enabled = False
            End If
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            'Clear()
            If tabSetup.Visible Then
                btnAdd.Enabled = True
            Else
                btnAdd.Enabled = False
            End If
            btnBack.Enabled = True
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Private Sub Clear()
        PanelEx10.Enabled = True
        txtReportName.Text = ""
        txtSource.Text = ""
        FileName = ""
        txtReportPath.Text = ReportP
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        LoadData()
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
        If txtSource.Text = "" And btnSave.Text = "&Save" Then
            MsgBox("Please fill Souce field by browsing your procedure file.", MsgBoxStyle.Information, "Info")
            txtSource.Focus()
            Exit Sub
        End If

        Dim Type As String = ""
        If cbxBorrower.Checked Then
            Type = "Borrower"
        ElseIf cbxLoans.Checked Then
            Type = "Loan"
        ElseIf cbxROPOA.Checked Then
            Type = "ROPOA"
        ElseIf cbxFinance.Checked Then
            Type = "Finance"
        ElseIf cbxNonLoans.Checked Then
            Type = "Non Loans"
        End If
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = 0
                Exist = DataObject(String.Format("SELECT ID FROM help_setup WHERE (Report = '{0}' AND `Type` = '{1}') AND `status` = 'ACTIVE'", txtReportName.Text, Type))
                If Exist > 0 Then
                    MsgBox(String.Format("Procedure {0} on {1} already exist, Please check your procedure name to prevent confusion. Thank you.", txtReportName.Text, Type), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String
                SQL = "INSERT INTO help_setup SET"
                SQL &= String.Format(" Report = '{0}', ", txtReportName.Text)
                SQL &= String.Format(" Path = '{0}', ", ReportP_2 & FileName)
                SQL &= String.Format(" `Type` = '{0}', ", Type)
                SQL &= String.Format(" user_code = '{0}' ", User_Code)
                DataObject(SQL)

                My.Computer.FileSystem.CopyFile(txtSource.Text, txtReportPath.Text)
                Logs("Help", "Save", String.Format("Add new procedure {0} on {1}", txtReportName.Text, Type), "", "", "", "")
                Clear()
                Cursor = Cursors.Default
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = 0
                Exist = DataObject(String.Format("SELECT ID FROM help_setup WHERE (Report = '{0}' AND `Type` = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}'", txtReportName.Text, Type, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Procedure {0} on {1} already exist, Please check your procedure name to prevent confusion. Thank you.", txtReportName.Text, Type), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE help_setup SET"
                SQL &= String.Format(" Report = '{0}', ", txtReportName.Text)
                SQL &= String.Format(" `Type` = '{0}' ", Type)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)

                Logs("Help", "Update", Reason, Changes(), "", "", "")
                Clear()
                Cursor = Cursors.Default
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
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
        ElseIf cbxFinance.Tag <> "Finance" And cbxFinance.Checked Then
            Change &= String.Format("Change Procedure Types from {0} to {1}. ", cbxFinance.Tag, cbxFinance.Text)
        ElseIf cbxNonLoans.Tag <> "Non Loans" And cbxNonLoans.Checked Then
            Change &= String.Format("Change Procedure Types from {0} to {1}. ", cbxNonLoans.Tag, cbxNonLoans.Text)
        End If
        Return Change
    End Function

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim OFD As New OpenFileDialog
        'OFD.Filter = "PDF File|*.pdf"
        If (OFD.ShowDialog() = DialogResult.OK) Then
            Try
                txtSource.Text = OFD.FileName
                FileName = IO.Path.GetFileName(OFD.FileName)
                txtReportPath.Text = ReportP & FileName
                If IO.File.Exists(txtReportPath.Text) Then
                    MsgBox("Procedure File Name already exist at directory. Please rename your procedure to proceed.", MsgBoxStyle.Information, "Info")
                    txtSource.Text = ""
                    txtReportPath.Text = ReportP
                End If
            Catch ex As Exception
                MsgBox("File type not supported. Please select Procedure File only.", MsgBoxStyle.Information, "Info")
            End Try
        End If
    End Sub

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

            If IO.File.Exists(txtReportPath.Text) Then
                Try
                    IO.File.Delete(txtReportPath.Text)
                Catch ex As Exception
                    TriggerBugReport("Help - Delete", ex.Message.ToString)
                    Exit Sub
                End Try
            End If
            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE help_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Help", "Cancel", Reason, String.Format("Cancel procedure {0}", txtReportName.Text), "", "", "")
            Clear()
            Cursor = Cursors.Default
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Cursor = Cursors.WaitCursor
        Try
            If SuperTabControl1.SelectedTabIndex = 1 Then
                If GridView1.RowCount > 0 Then
                    Dim myProcess As Process = Process.Start(GridView1.GetFocusedRowCellValue("Procedure"))
                    Do
                        'Allow Process to Finish '
                        myProcess.Refresh()
                    Loop While Not myProcess.WaitForExit(1000)
                    Dim exitCode As Integer = myProcess.ExitCode
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                If GridView2.RowCount > 0 Then
                    Dim myProcess As Process = Process.Start(GridView2.GetFocusedRowCellValue("Procedure"))
                    Do
                        'Allow Process to Finish '
                        myProcess.Refresh()
                    Loop While Not myProcess.WaitForExit(1000)
                    Dim exitCode As Integer = myProcess.ExitCode
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                If GridView3.RowCount > 0 Then
                    Dim myProcess As Process = Process.Start(GridView3.GetFocusedRowCellValue("Procedure"))
                    Do
                        'Allow Process to Finish '
                        myProcess.Refresh()
                    Loop While Not myProcess.WaitForExit(1000)
                    Dim exitCode As Integer = myProcess.ExitCode
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 4 Then
                If GridView4.RowCount > 0 Then
                    Dim myProcess As Process = Process.Start(GridView4.GetFocusedRowCellValue("Procedure"))
                    Do
                        'Allow Process to Finish '
                        myProcess.Refresh()
                    Loop While Not myProcess.WaitForExit(1000)
                    Dim exitCode As Integer = myProcess.ExitCode
                End If
            ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
                If GridView5.RowCount > 0 Then
                    Dim myProcess As Process = Process.Start(GridView5.GetFocusedRowCellValue("Procedure"))
                    Do
                        'Allow Process to Finish '
                        myProcess.Refresh()
                    Loop While Not myProcess.WaitForExit(1000)
                    Dim exitCode As Integer = myProcess.ExitCode
                End If
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            TriggerBugReport("Help - Print", ex.Message.ToString)
        End Try
        Cursor = Cursors.Default
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
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear()
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
        PanelEx10.Enabled = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Procedure Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Procedure Name")
            txtReportPath.Text = .GetFocusedRowCellValue("Procedure")
        End With
        cbxBorrower.Checked = True
        cbxBorrower.Tag = "Borrower"
        cbxLoans.Tag = "Borrower"
        cbxROPOA.Tag = "Borrower"
        cbxFinance.Tag = "Borrower"
        cbxNonLoans.Tag = "Borrower"

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
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
        PanelEx10.Enabled = False
        With GridView2
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Procedure Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Procedure Name")
            txtReportPath.Text = .GetFocusedRowCellValue("Procedure")
        End With
        cbxLoans.Checked = True
        cbxBorrower.Tag = "Loan"
        cbxLoans.Tag = "Loan"
        cbxROPOA.Tag = "Loan"
        cbxFinance.Tag = "Loan"
        cbxNonLoans.Tag = "Loan"

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
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
        PanelEx10.Enabled = False
        With GridView3
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Procedure Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Procedure Name")
            txtReportPath.Text = .GetFocusedRowCellValue("Procedure")
        End With
        cbxROPOA.Checked = True
        cbxBorrower.Tag = "ROPOA"
        cbxLoans.Tag = "ROPOA"
        cbxROPOA.Tag = "ROPOA"
        cbxFinance.Tag = "ROPOA"
        cbxNonLoans.Tag = "ROPOA"

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
    End Sub

    Private Sub GridView4_DoubleClick(sender As Object, e As EventArgs) Handles GridView4.DoubleClick
        If tabSetup.Visible = False Then
            btnPrint.PerformClick()
            Exit Sub
        End If

        Try
            If GridView4.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        PanelEx10.Enabled = False
        With GridView4
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Procedure Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Procedure Name")
            txtReportPath.Text = .GetFocusedRowCellValue("Procedure")
        End With
        cbxFinance.Checked = True
        cbxBorrower.Tag = "Finance"
        cbxLoans.Tag = "Finance"
        cbxROPOA.Tag = "Finance"
        cbxFinance.Tag = "Finance"
        cbxNonLoans.Tag = "Finance"

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
    End Sub

    Private Sub GridView5_DoubleClick(sender As Object, e As EventArgs) Handles GridView5.DoubleClick
        If tabSetup.Visible = False Then
            btnPrint.PerformClick()
            Exit Sub
        End If

        Try
            If GridView5.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        PanelEx10.Enabled = False
        With GridView5
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Procedure Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Procedure Name")
            txtReportPath.Text = .GetFocusedRowCellValue("Procedure")
        End With
        cbxNonLoans.Checked = True
        cbxBorrower.Tag = "Non Loans"
        cbxLoans.Tag = "Non Loans"
        cbxROPOA.Tag = "Non Loans"
        cbxFinance.Tag = "Non Loans"
        cbxNonLoans.Tag = "Non Loans"

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
    End Sub
End Class