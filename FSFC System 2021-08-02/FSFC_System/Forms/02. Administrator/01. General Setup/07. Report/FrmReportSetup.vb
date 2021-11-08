Public Class FrmReportSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    ReadOnly ReportP As String = String.Format("{0}\{1}\{2}\", RootFolder, MainFolder, ReportFolder)
    Dim FileName As String

    Private Sub FrmReportSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2, GridView3})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        LoadData()

        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Classes\Installer\Dependencies\{f65db027-aff3-4070-886a-0d87064aabb1}", "DisplayName", Nothing) Is Nothing Then
            If MsgBoxYes("The system cannot find the Microsoft Visual C++ 2013 Redistributable (x86) - 12.0.30501 in this computer, would you like the system to install the missing drivers?") = MsgBoxResult.Yes Then
                Dim myProcess As Process = Process.Start(String.Format("{0}\ODBC Installer\vcredist_x86", If(UCase(_ServerName) = "LOCALHOST", RootFolder, "\\" & "Acebsvr-ad1\LMS")))
                Do
                    'Allow Process to Finish '
                    myProcess.Refresh()
                Loop While Not myProcess.WaitForExit(1000)
                Dim exitCode As Integer = myProcess.ExitCode
            End If
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\ODBC\ODBCINST.INI\MySQL ODBC 5.3 Unicode Driver", "Setup", Nothing) Is Nothing And My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\ODBC\ODBCINST.INI\MySQL ODBC 5.3 Unicode Driver", "Setup", Nothing) Is Nothing Then
            If MsgBoxYes("The system cannot find the ODBC Connector in this computer, would you like the system to install the missing drivers?") = MsgBoxResult.Yes Then
                Dim myProcess As Process = Process.Start(String.Format("{0}\ODBC Installer\mysql-connector-odbc-5.3.7-win32.msi", If(UCase(_ServerName) = "LOCALHOST", RootFolder, "\\" & "Acebsvr-ad1\LMS")))
                Do
                    'Allow Process to Finish '
                    myProcess.Refresh()
                Loop While Not myProcess.WaitForExit(1000)
                Process.Start(String.Format("{0}\ODBC Installer\Crystal Report.png", If(UCase(_ServerName) = "LOCALHOST", RootFolder, "\\" & "Acebsvr-ad1\LMS")))
                Dim exitCode As Integer = myProcess.ExitCode
            End If
        End If
        If My.Computer.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Business Objects\10.5\Crystal Reports", "CommonFiles", Nothing) Is Nothing Then
            If MsgBoxYes("The system cannot find the Crystal Reports Basic Runtime, would you like the system to install the missing drivers?") = MsgBoxResult.Yes Then
                If cpuID.Contains("64") Then
                    Dim myProcess As Process = Process.Start(String.Format("{0}\Crystal Report Runtime Basic\CRRedist2008_x64.msi", If(UCase(_ServerName) = "LOCALHOST", RootFolder, "\\" & "Acebsvr-ad1\LMS")))
                    Do
                        'Allow Process to Finish '
                        myProcess.Refresh()
                    Loop While Not myProcess.WaitForExit(1000)
                    Dim exitCode As Integer = myProcess.ExitCode
                Else
                    Dim myProcess As Process = Process.Start(String.Format("{0}\Crystal Report Runtime Basic\CRRedist2008_x86.msi", If(UCase(_ServerName) = "LOCALHOST", RootFolder, "\\" & "Acebsvr-ad1\LMS")))
                    Do
                        'Allow Process to Finish '
                        myProcess.Refresh()
                    Loop While Not myProcess.WaitForExit(1000)
                    Dim exitCode As Integer = myProcess.ExitCode
                End If
            End If
        End If

        If User_Type = "ADMIN" Then
            tabSetup.Visible = True
        Else
            tabSetup.Visible = False
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

            GetTextBoxFontSettings({txtReportName, txtSource})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnBrowse})

            GetCheckBoxFontSettings({cbxBorrower, cbxLoans, cbxROPOA})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Report Setup - FixUI", ex.Message.ToString)
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
        GridControl1.DataSource = DataSource("SELECT ID, Report AS 'Report Name' FROM report_setup WHERE `status` = 'ACTIVE' AND `Type` = 'Borrower' ORDER BY Report;")
        GridView1.Columns("Report Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Report Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 1148 - 17
        Else
            GridColumn2.Width = 1148
        End If

        'Loan
        GridControl2.DataSource = DataSource("SELECT ID, Report AS 'Report Name' FROM report_setup WHERE `status` = 'ACTIVE' AND `Type` = 'Loan' ORDER BY Report;")
        GridView2.Columns("Report Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView2.Columns("Report Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView2.RowCount > 22 Then
            GridColumn5.Width = 1148 - 17
        Else
            GridColumn5.Width = 1148
        End If

        'ROPOA
        GridControl3.DataSource = DataSource("SELECT ID, Report AS 'Report Name' FROM report_setup WHERE `status` = 'ACTIVE' AND `Type` = 'ROPOA' ORDER BY Report;")
        GridView3.Columns("Report Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView3.Columns("Report Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        If GridView3.RowCount > 22 Then
            GridColumn8.Width = 1148 - 17
        Else
            GridColumn8.Width = 1148
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
        txtSource.Text = ""
        FileName = ""
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
            MsgBox("Please fill Report Name field.", MsgBoxStyle.Information, "Info")
            txtReportName.Focus()
            Exit Sub
        End If
        If txtSource.Text = "" Then
            MsgBox("Please fill Souce field by browsing your report file.", MsgBoxStyle.Information, "Info")
            txtReportName.Focus()
            Exit Sub
        End If

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
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM report_setup WHERE (Report = '{0}' AND `Type` = '{1}') AND `status` = 'ACTIVE'", txtReportName.Text, Type))
                If Exist > 0 Then
                    MsgBox(String.Format("Report {0} on {1} already exist, Please check your report name to prevent confusion. Thank you.", txtReportName.Text, Type), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO report_setup SET"
                SQL &= String.Format(" Report = '{0}', ", txtReportName.Text)
                SQL &= String.Format(" `Type` = '{0}', ", Type)
                SQL &= String.Format(" user_code = '{0}' ", User_Code)
                DataObject(SQL)
                Cursor = Cursors.Default

                My.Computer.FileSystem.CopyFile(txtSource.Text, ReportP)
                Logs("Report", "Save", String.Format("Add new report {0} on {1}", txtReportName.Text, Type), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM report_setup WHERE (Report = '{0}' AND `Type` = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}'", txtReportName.Text, Type, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Report {0} on {1} already exist, Please check your report name to prevent confusion. Thank you.", txtReportName.Text, Type), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE report_setup SET"
                SQL &= String.Format(" Report = '{0}', ", txtReportName.Text)
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
                Change &= String.Format("Change Report Name from {0} to {1}. ", txtReportName.Tag, txtReportName.Text)
            End If
            If cbxBorrower.Tag <> "Borrower" And cbxBorrower.Checked Then
                Change &= String.Format("Change Report Type from {0} to {1}. ", cbxBorrower.Tag, cbxBorrower.Text)
            ElseIf cbxLoans.Tag <> "Loan" And cbxLoans.Checked Then
                Change &= String.Format("Change Report Type from {0} to {1}. ", cbxLoans.Tag, cbxLoans.Text)
            ElseIf cbxROPOA.Tag <> "ROPOA" And cbxROPOA.Checked Then
                Change &= String.Format("Change Report Types from {0} to {1}. ", cbxROPOA.Tag, cbxROPOA.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Report Setup - Changes", ex.Message.ToString)
        End Try
        Return Change
    End Function

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Report File|*.rpt"
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    txtSource.Text = OFD.FileName
                    FileName = IO.Path.GetFileName(OFD.FileName)
                    If IO.File.Exists(ReportP & FileName) Then
                        MsgBox("Report File Name already exist at directory. Please rename your report to proceed.", MsgBoxStyle.Information, "Info")
                        txtSource.Text = ""
                    End If
                Catch ex As Exception
                    MsgBox("File type not supported. Please select Report File only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
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

            If IO.File.Exists(ReportP & txtReportName.Text) Then
                Try
                    IO.File.Delete(ReportP & txtReportName.Text)
                Catch ex As Exception
                    TriggerBugReport("Report Setup - Click", ex.Message.ToString)
                    Exit Sub
                End Try
            End If
            Cursor = Cursors.WaitCursor
            DataObject(String.Format("UPDATE report_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Report", "Cancel", Reason, String.Format("Cancel report {0}", txtReportName.Text), "", "", "")
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

        Dim Viewer As New FrmCrystalReportViewer
        With Viewer
            Try
                Cursor = Cursors.WaitCursor
                If SuperTabControl1.SelectedTabIndex = 1 Then
                    If GridView1.RowCount > 0 And GridView1.GetFocusedRowCellValue("ID").ToString <> "" Then
                        .WithP = True
                        .BranchID = Branch_ID
                        .Branch = Branch
                        .Path = ReportP & GridView1.GetFocusedRowCellValue("Report Name")
                    End If
                ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                    If GridView2.RowCount > 0 And GridView2.GetFocusedRowCellValue("ID").ToString <> "" Then
                        .WithP = True
                        .BranchID = Branch_ID
                        .Branch = Branch
                        .Path = ReportP & GridView2.GetFocusedRowCellValue("Report Name")
                    End If
                ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                    If GridView3.RowCount > 0 And GridView3.GetFocusedRowCellValue("ID").ToString <> "" Then
                        .WithP = True
                        .BranchID = Branch_ID
                        .Branch = Branch
                        .Path = ReportP & GridView3.GetFocusedRowCellValue("Report Name")
                    End If
                End If
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
                TriggerBugReport("Report Setup - Print", ex.Message.ToString)
                'Exit Sub
            End Try
            .Show()
        End With
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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        If tabSetup.Visible = False Then
            btnPrint.PerformClick()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Report Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Report Name")
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
        Try
            If GridView2.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        If tabSetup.Visible = False Then
            btnPrint.PerformClick()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        With GridView2
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Report Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Report Name")
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
        Try
            If GridView3.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        If tabSetup.Visible = False Then
            btnPrint.PerformClick()
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        With GridView3
            ID = .GetFocusedRowCellValue("ID")
            txtReportName.Text = .GetFocusedRowCellValue("Report Name")
            txtReportName.Tag = .GetFocusedRowCellValue("Report Name")
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