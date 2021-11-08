Public Class FrmSignatorySetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim Firstload As Boolean = True
    Private Sub FrmSignatorySetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        Firstload = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList
        dtpFrom.Value = Date.Now

        Dim Branch_DT As DataTable = DataSource("SELECT ID, branch_code, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY BranchID;")
        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = Branch_DT.Copy
            .SelectedIndex = -1
        End With

        With cbxBranchV2
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = Branch_DT.Copy
            .SelectedIndex = -1
        End With

        With cbxBranchV3
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = Branch_DT.Copy
            .SelectedIndex = -1
        End With

        With cbxPosition
            .DisplayMember = "Position"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, `Position` FROM position_setup WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
            .SelectedIndex = -1
        End With

        With cbxForm
            .ValueMember = "ID"
            .DisplayMember = "Form"
            .DataSource = DataSource("SELECT ID, UPPER(Form) AS 'Form' FROM form_setup WHERE `status` = 'ACTIVE' AND with_signatory = 1 ORDER BY Form;")
            .SelectedIndex = -1
        End With

        With cbxButton
            .ValueMember = "ID"
            .DisplayMember = "Button"
            .DataSource = DataSource("SELECT ID, Button FROM button_setup WHERE `status` = 'ACTIVE' ORDER BY Button;")
            .SelectedIndex = -1
        End With

        Dim Employee_DT As DataTable = DataSource("SELECT ID, Employee(ID) AS 'Name' FROM employee_setup WHERE `status` = 'ACTIVE' AND ((SELECT Head FROM position_setup WHERE ID = position_ID) = 1 OR (SELECT Head FROM position_setup WHERE ID = secondary_position_ID) = 1) ORDER BY `Name`;")

        With cbxApprover1V2
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = Employee_DT.Copy
            .SelectedIndex = -1
        End With

        With cbxApprover2V2
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = Employee_DT.Copy
            .SelectedIndex = -1
        End With

        With cbxApprover3V2
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = Employee_DT.Copy
            .SelectedIndex = -1
        End With

        With cbxApprover1V3
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = Employee_DT.Copy
            .SelectedIndex = -1
        End With

        With cbxApprover2V3
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = Employee_DT.Copy
            .SelectedIndex = -1
        End With

        With cbxApprover3V3
            .ValueMember = "ID"
            .DisplayMember = "Name"
            .DataSource = Employee_DT.Copy
            .SelectedIndex = -1
        End With
        LoadData()
        Firstload = False
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX5, LabelX2, LabelX14, LabelX13, LabelX7, LabelX4, LabelX6, LabelX12, LabelX9, LabelX3, LabelX8, LabelX10, LabelX15})

            GetComboBoxFontSettings({cbxBranch, cbxPosition, cbxForm, cbxButton, cbxBranchV2, cbxApprover1V2, cbxApprover2V2, cbxApprover3V2, cbxBranchV3, cbxApprover1V3, cbxApprover2V3, cbxApprover3V3})

            GetCheckBoxFontSettings({cbxNA})

            GetIntegerInputFontSettings({iDays})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetDateTimeInputFontSettings({dtpFrom, dtpTo})

            GetTabControlFontSettings({SuperTabControl1})

            GetContextMenuBarFontSettings({ContextMenuBar1})
        Catch ex As Exception
            TriggerBugReport("Signatory Setup - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Signatory", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID,"
        SQL &= "    BranchID,"
        SQL &= "    Branch(BranchID) AS 'Branch',"
        SQL &= "    PositionID,"
        SQL &= "    Position (PositionID) AS 'Position',"
        SQL &= "    FormID,"
        SQL &= "    (SELECT UPPER(Form) FROM form_setup WHERE ID = FormID) AS 'Form',"
        SQL &= "    ButtonID,"
        SQL &= "    (SELECT Button FROM button_setup WHERE ID = ButtonID) AS 'Button',"
        SQL &= "    Days,"
        SQL &= "    IF(`Start` = '','',DATE_FORMAT(`Start`,'%M %d, %Y')) AS 'Start'"
        SQL &= "  FROM signatory_setup WHERE `status` = 'ACTIVE' ORDER BY `Branch`, `Position`, `Form`, `Button`;"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Branch").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Branch").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 233
        Else
            GridColumn2.Width = 247
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Copy of details is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        If GridView1.GetFocusedRowCellValue("Branch") = Branch Then
            MsgBox("Selected Branch is the same with Current Branch, copy is not allowed.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBox(String.Format("Are you sure you want to copy the saved signatories of Branch {0} to Branch {1}?", GridView1.GetFocusedRowCellValue("Branch"), Branch), MsgBoxStyle.YesNo, "Info") Then
            Dim SQL As String = ""
            Cursor = Cursors.WaitCursor
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetFocusedRowCellValue("Branch") = GridView1.GetRowCellValue(x, "Branch") Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM signatory_setup WHERE PositionID = '{0}' AND FormID = '{1}' AND ButtonID = '{2}' AND BranchID = '{3}' AND `status` = 'ACTIVE';", GridView1.GetRowCellValue(x, "PositionID"), GridView1.GetRowCellValue(x, "FormID"), GridView1.GetRowCellValue(x, "ButtonID"), Branch_ID))
                    If Exist > 0 Then
                    Else
                        SQL &= "INSERT INTO signatory_setup SET"
                        SQL &= String.Format(" PositionID = '{0}', ", GridView1.GetRowCellValue(x, "PositionID"))
                        SQL &= String.Format(" FormID = '{0}', ", GridView1.GetRowCellValue(x, "FormID"))
                        SQL &= String.Format(" ButtonID = '{0}', ", GridView1.GetRowCellValue(x, "ButtonID"))
                        SQL &= String.Format(" BranchID = '{0}', ", Branch_ID)
                        SQL &= String.Format(" Days = '{0}', ", GridView1.GetRowCellValue(x, "Days"))
                        SQL &= String.Format(" `Start` = '{0}', ", GridView1.GetRowCellValue(x, "Start"))
                        SQL &= String.Format(" User_code = '{0}';", User_Code)
                        Logs("Signatory", "Copy", String.Format("Add new signatory of {0} for form {1} and button {2} in Branch {3}", GridView1.GetRowCellValue(x, "PositionID"), GridView1.GetRowCellValue(x, "FormID"), GridView1.GetRowCellValue(x, "ButtonID"), Branch), "", "", "", "")
                    End If
                End If
            Next
            If SQL = "" Then
                MsgBox("Nothing to copy.", MsgBoxStyle.Information, "Info")
            Else
                DataObject(SQL)
                DT_Signatory = DataSource(String.Format("CALL Login_GetSignatory({0});", Branch_ID))
                MsgBox("Successfully Copied!", MsgBoxStyle.Information, "Info")
                LoadData()
            End If
            Cursor = Cursors.Default
        End If
    End Sub

#Region "Keydown"
    Private Sub CbxBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPosition.Focus()
        End If
    End Sub

    Private Sub CbxPosition_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxForm.Focus()
        End If
    End Sub

    Private Sub CbxForm_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxForm.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxButton.Focus()
        End If
    End Sub

    Private Sub CbxButton_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxButton.KeyDown
        If e.KeyCode = Keys.Enter Then
            iDays.Focus()
        End If
    End Sub

    Private Sub IDays_KeyDown(sender As Object, e As KeyEventArgs) Handles iDays.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpFrom.Focus()
        End If
    End Sub

    Private Sub DtpFrom_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFrom.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpTo.Focus()
        End If
    End Sub

    Private Sub DtpTo_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpTo.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

    '***BUTTON CLICK
    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            SuperTabControl1.SelectedTab = tabList
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabPCV
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabCAS
        End If
    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If SuperTabControl1.SelectedTabIndex = 3 Then
            SuperTabControl1.SelectedTab = tabPCV
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            SuperTabControl1.SelectedTab = tabList
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
        End If
    End Sub

    Private Sub SuperTabControl1_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.SuperTabStripSelectedTabChangedEventArgs) Handles SuperTabControl1.SelectedTabChanged
        If SuperTabControl1.SelectedTabIndex = 0 Or SuperTabControl1.SelectedTabIndex = 2 Or SuperTabControl1.SelectedTabIndex = 3 Then
            If SuperTabControl1.SelectedTabIndex = 0 Then
                btnBack.Enabled = False
            ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
                cbxBranchV2_SelectedIndexChanged(sender, e)
            ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
                cbxBranchV3_SelectedIndexChanged(sender, e)
                btnNext.Enabled = False
            End If
            btnAdd.Enabled = False
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnPrint.Enabled = False
            btnDelete.Enabled = False
            btnNext.Enabled = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
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
        If SuperTabControl1.SelectedTabIndex = 0 Then
            PanelEx10.Enabled = True
            cbxBranch.Enabled = True
            cbxPosition.Enabled = True
            cbxBranch.SelectedIndex = -1
            cbxPosition.SelectedIndex = -1
        End If

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

        If SuperTabControl1.SelectedTabIndex = 0 Then
            If cbxBranch.Text = "" Or cbxBranch.SelectedIndex = -1 Then
                MsgBox("Please select Branch.", MsgBoxStyle.Information, "Info")
                cbxBranch.DroppedDown = True
                Exit Sub
            End If
            If cbxPosition.Text = "" Or cbxPosition.SelectedIndex = -1 Then
                MsgBox("Please select Position.", MsgBoxStyle.Information, "Info")
                cbxPosition.DroppedDown = True
                Exit Sub
            End If
            If cbxForm.Text = "" Or cbxForm.SelectedIndex = -1 Then
                MsgBox("Please select Form.", MsgBoxStyle.Information, "Info")
                cbxForm.DroppedDown = True
                Exit Sub
            End If
            If cbxButton.Text = "" Or cbxButton.SelectedIndex = -1 Then
                MsgBox("Please select Button.", MsgBoxStyle.Information, "Info")
                cbxButton.DroppedDown = True
                Exit Sub
            End If

            If btnSave.Text = "&Save" Then
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM signatory_setup WHERE PositionID = '{0}' AND FormID = '{1}' AND ButtonID = '{2}' AND BranchID = '{3}' AND `status` = 'ACTIVE' AND IF('{6}' = 'True',Days = 0,IF(Days > 0,`Start` BETWEEN '{4}' AND '{5}',TRUE));", cbxPosition.SelectedValue, cbxForm.SelectedValue, cbxButton.SelectedValue, cbxBranch.SelectedValue, Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"), cbxNA.Checked))
                    If Exist > 0 Then
                        MsgBox(String.Format("{0} already have signatory of {2} for form {1} in Branch {3}", cbxPosition.Text, cbxForm.Text, cbxButton.Text, cbxBranch.Text), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = "INSERT INTO signatory_setup SET"
                    SQL &= String.Format(" PositionID = '{0}', ", cbxPosition.SelectedValue)
                    SQL &= String.Format(" FormID = '{0}', ", cbxForm.SelectedValue)
                    SQL &= String.Format(" ButtonID = '{0}', ", cbxButton.SelectedValue)
                    SQL &= String.Format(" BranchID = '{0}', ", cbxBranch.SelectedValue)
                    SQL &= String.Format(" Days = '{0}', ", iDays.Value)
                    SQL &= String.Format(" `Start` = '{0}', ", FormatDatePicker(dtpFrom))
                    SQL &= String.Format(" User_code = '{0}';", User_Code)
                    DataObject(SQL)
                    Cursor = Cursors.Default

                    Logs("Signatory", "Save", String.Format("Add new signatory of {0} for form {1} and button {2} in Branch {3}", cbxPosition.Text, cbxForm.Text, cbxButton.Text, cbxBranch.Text), "", "", "", "")
                    Clear(True)
                    DT_Signatory = DataSource(String.Format("CALL Login_GetSignatory({0});", Branch_ID))
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM signatory_setup WHERE PositionID = '{0}' AND FormID = '{1}' AND ButtonID = '{2}' AND BranchID = '{4}' AND `status` = 'ACTIVE' AND ID != '{3}' AND IF('{7}' = 'TRUE',Days = 0,IF(Days > 0,Start BETWEEN '{5}' AND '{6}',TRUE));;", cbxPosition.SelectedValue, cbxForm.SelectedValue, cbxButton.SelectedValue, ID, cbxBranch.SelectedValue, Format(dtpFrom.Value, "yyyy-MM-dd"), Format(dtpTo.Value, "yyyy-MM-dd"), cbxNA.Checked))
                    If Exist > 0 Then
                        MsgBox(String.Format("{0} already have signatory of {2} for form {1} in Branch {3}", cbxPosition.Text, cbxForm.Text, cbxButton.Text, cbxBranch.Text), MsgBoxStyle.Information, "Info")
                        Exit Sub
                    End If

                    Dim Reason As String 'Reason for change
                    If FrmReason.ShowDialog = DialogResult.OK Then
                        Reason = FrmReason.txtReason.Text
                    Else
                        Exit Sub
                    End If

                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = "UPDATE signatory_setup SET"
                    SQL &= String.Format(" PositionID = '{0}', ", cbxPosition.SelectedValue)
                    SQL &= String.Format(" ButtonID = '{0}', ", cbxButton.SelectedValue)
                    SQL &= String.Format(" Days = '{0}', ", iDays.Value)
                    SQL &= String.Format(" `Start` = '{0}' ", FormatDatePicker(dtpFrom))
                    SQL &= String.Format(" WHERE ID = '{0}';", ID)
                    DataObject(SQL)
                    Cursor = Cursors.Default

                    Logs("Signatory", "Update", Reason, Changes(), "", "", "")
                    Clear(True)
                    DT_Signatory = DataSource(String.Format("CALL Login_GetSignatory({0});", Branch_ID))
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 2 Then
            If cbxBranchV2.Text = "" Or cbxBranchV2.SelectedIndex = -1 Then
                MsgBox("Please select Branch.", MsgBoxStyle.Information, "Info")
                cbxBranchV2.DroppedDown = True
                Exit Sub
            End If
            If cbxApprover1V2.Text = "" Or cbxApprover1V2.SelectedIndex = -1 Then
                MsgBox("Please select Approver.", MsgBoxStyle.Information, "Info")
                cbxApprover1V2.DroppedDown = True
                Exit Sub
            End If

            If btnSave.Text = "&Save" Then
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = "INSERT INTO approver_signatory SET"
                    SQL &= String.Format(" BranchID = '{0}', ", cbxBranchV2.SelectedValue)
                    SQL &= String.Format(" Approver1ID = '{0}', ", ValidateComboBox(cbxApprover1V2))
                    SQL &= String.Format(" Approver2ID = '{0}', ", ValidateComboBox(cbxApprover2V2))
                    SQL &= String.Format(" Approved3ID = '{0}', ", ValidateComboBox(cbxApprover3V2))
                    SQL &= String.Format(" Form = '{0}', ", "PCV")
                    SQL &= String.Format(" EmplID = '{0}';", Empl_ID)
                    DataObject(SQL)
                    Cursor = Cursors.Default

                    Logs("Signatory", "Save", String.Format("Add new approver for Petty Cash Voucher for Branch {0}", cbxBranchV2), "", "", "", "")
                    Clear(True)
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Dim Reason As String 'Reason for change
                    If FrmReason.ShowDialog = DialogResult.OK Then
                        Reason = FrmReason.txtReason.Text
                    Else
                        Exit Sub
                    End If

                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = "UPDATE approver_signatory SET"
                    SQL &= String.Format(" Approver1ID = '{0}', ", ValidateComboBox(cbxApprover1V2))
                    SQL &= String.Format(" Approver2ID = '{0}', ", ValidateComboBox(cbxApprover2V2))
                    SQL &= String.Format(" Approved3ID = '{0}' ", ValidateComboBox(cbxApprover3V2))
                    SQL &= String.Format(" WHERE BranchID = '{0}' AND Form = 'PCV';", cbxBranchV2.SelectedValue)
                    DataObject(SQL)
                    Cursor = Cursors.Default

                    Logs("Signatory", "Update", Reason, "", "", "", "")
                    Clear(True)
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            If cbxBranchV3.Text = "" Or cbxBranchV3.SelectedIndex = -1 Then
                MsgBox("Please select Branch.", MsgBoxStyle.Information, "Info")
                cbxBranchV3.DroppedDown = True
                Exit Sub
            End If
            If cbxApprover1V3.Text = "" Or cbxApprover1V3.SelectedIndex = -1 Then
                MsgBox("Please select Approver.", MsgBoxStyle.Information, "Info")
                cbxApprover1V3.DroppedDown = True
                Exit Sub
            End If

            If btnSave.Text = "&Save" Then
                If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = "INSERT INTO approver_signatory SET"
                    SQL &= String.Format(" BranchID = '{0}', ", cbxBranchV3.SelectedValue)
                    SQL &= String.Format(" Approver1ID = '{0}', ", ValidateComboBox(cbxApprover1V3))
                    SQL &= String.Format(" Approver2ID = '{0}', ", ValidateComboBox(cbxApprover2V3))
                    SQL &= String.Format(" Approved3ID = '{0}', ", ValidateComboBox(cbxApprover3V3))
                    SQL &= String.Format(" Form = '{0}', ", "CAS")
                    SQL &= String.Format(" EmplID = '{0}';", Empl_ID)
                    DataObject(SQL)
                    Cursor = Cursors.Default

                    Logs("Signatory", "Save", String.Format("Add new approver for Cash Advance Slip for Branch {0}", cbxBranchV3), "", "", "", "")
                    Clear(True)
                    MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                End If
            Else
                If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                    Dim Reason As String 'Reason for change
                    If FrmReason.ShowDialog = DialogResult.OK Then
                        Reason = FrmReason.txtReason.Text
                    Else
                        Exit Sub
                    End If

                    Cursor = Cursors.WaitCursor
                    Dim SQL As String = "UPDATE approver_signatory SET"
                    SQL &= String.Format(" Approver1ID = '{0}', ", ValidateComboBox(cbxApprover1V3))
                    SQL &= String.Format(" Approver2ID = '{0}', ", ValidateComboBox(cbxApprover2V3))
                    SQL &= String.Format(" Approved3ID = '{0}' ", ValidateComboBox(cbxApprover3V3))
                    SQL &= String.Format(" WHERE BranchID = '{0}' AND Form = 'CAS';", cbxBranchV3.SelectedValue)
                    DataObject(SQL)
                    Cursor = Cursors.Default

                    Logs("Signatory", "Update", Reason, "", "", "", "")
                    Clear(True)
                    MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
                End If
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If cbxForm.Text = cbxForm.Tag Then
            Else
                Change &= String.Format("Change Form from {0} to {1}. ", cbxForm.Tag, cbxForm.Text)
            End If
            If cbxButton.Text = cbxButton.Tag Then
            Else
                Change &= String.Format("Change Button from {0} to {1}. ", cbxButton.Tag, cbxButton.Text)
            End If
            If iDays.Text = iDays.Tag Then
            Else
                Change &= String.Format("Change Number of Days from {0} to {1}. ", iDays.Tag, iDays.Text)
            End If
            If dtpFrom.Text = dtpFrom.Tag Then
            Else
                Change &= String.Format("Change Start Date from {0} to {1}. ", dtpFrom.Tag, dtpFrom.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Signatory Setup - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE signatory_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Signatory", "Cancel", Reason, String.Format("Cancel signatory of {0} for form {1} and button {2}.", cbxPosition.Text, cbxForm.Text, cbxButton.Text), "", "", "")
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
        If SuperTabControl1.SelectedTabIndex = 1 Or SuperTabControl1.SelectedTabIndex = 0 Then
            StandardPrinting("SIGNATORY LIST", GridControl1)
            Logs("Signatory List", "Print", "[SENSITIVE] Print Signatory List", "", "", "", "")
        End If
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
            cbxBranch.Enabled = False
            cbxBranch.SelectedValue = .GetFocusedRowCellValue("BranchID")
            cbxBranch.Tag = .GetFocusedRowCellValue("Branch")
            cbxPosition.Enabled = False
            cbxPosition.SelectedValue = .GetFocusedRowCellValue("PositionID")
            cbxPosition.Tag = .GetFocusedRowCellValue("Position")
            cbxForm.SelectedValue = .GetFocusedRowCellValue("FormID")
            cbxForm.Tag = .GetFocusedRowCellValue("Form")
            cbxButton.SelectedValue = .GetFocusedRowCellValue("ButtonID")
            cbxButton.Tag = .GetFocusedRowCellValue("Button")
            iDays.Value = .GetFocusedRowCellValue("Days")
            iDays.Tag = .GetFocusedRowCellValue("Days")
            If .GetFocusedRowCellValue("Start") = "" Then
                cbxNA.Checked = True
            Else
                dtpFrom.Value = .GetFocusedRowCellValue("Start")
                dtpFrom.Tag = .GetFocusedRowCellValue("Start")
            End If
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        If SuperTabControl1.SelectedTabIndex = 1 Then
            SuperTabControl1.SelectedTab = tabSetup
        ElseIf SuperTabControl1.SelectedTabIndex = 3 Then
            SuperTabControl1.SelectedTab = tabPCV
        ElseIf SuperTabControl1.SelectedTabIndex = 5 Then
            SuperTabControl1.SelectedTab = tabCAS
        End If
    End Sub

    Private Sub CbxBranchV2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranchV2.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        Dim DT As DataTable = DataSource(String.Format("SELECT ID, Approver1ID, Approver2ID, Approved3ID FROM approver_signatory WHERE Form = 'PCV' AND `status` = 'ACTIVE' AND BranchID = '{0}';", cbxBranchV2.SelectedValue))

        If DT.Rows.Count > 0 Then
            cbxApprover1V2.SelectedValue = DT(0)("Approver1ID")
            cbxApprover2V2.SelectedValue = DT(0)("Approver2ID")
            cbxApprover3V2.SelectedValue = DT(0)("Approved3ID")
            btnSave.Text = "Update"
        Else
            cbxApprover1V2.SelectedIndex = -1
            cbxApprover2V2.SelectedIndex = -1
            cbxApprover3V2.SelectedIndex = -1
            cbxApprover2V2.Enabled = False
            cbxApprover3V2.Enabled = False
            btnSave.Text = "&Save"
        End If
    End Sub

    Private Sub CbxBranchV3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranchV3.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        Dim DT As DataTable = DataSource(String.Format("SELECT ID, Approver1ID, Approver2ID, Approved3ID FROM approver_signatory WHERE Form = 'CAS' AND `status` = 'ACTIVE' AND BranchID = '{0}';", cbxBranchV3.SelectedValue))
        If DT.Rows.Count > 0 Then
            cbxApprover1V3.SelectedValue = DT(0)("Approver1ID")
            cbxApprover2V3.SelectedValue = DT(0)("Approver2ID")
            cbxApprover3V3.SelectedValue = DT(0)("Approved3ID")
            btnSave.Text = "Update"
        Else
            cbxApprover1V3.SelectedIndex = -1
            cbxApprover2V3.SelectedIndex = -1
            cbxApprover3V3.SelectedIndex = -1
            cbxApprover2V3.Enabled = False
            cbxApprover3V3.Enabled = False
            btnSave.Text = "&Save"
        End If
    End Sub

    Private Sub CbxApprover1V2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover1V2.SelectedIndexChanged
        If cbxApprover1V2.Text = "" Or cbxApprover1V2.SelectedIndex = -1 Then
            cbxApprover2V2.Enabled = False
            cbxApprover2V2.SelectedIndex = -1
            cbxApprover2V3.Enabled = False
            cbxApprover2V3.SelectedIndex = -1
        Else
            cbxApprover2V2.Enabled = True
            If cbxApprover1V2.SelectedValue = cbxApprover2V2.SelectedValue And cbxApprover1V2.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 2, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover1V2.SelectedIndex = -1
            ElseIf cbxApprover1V2.SelectedValue = cbxApprover3V2.SelectedValue And cbxApprover1V2.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 3, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover1V2.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub CbxApprover2V2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover2V2.SelectedIndexChanged
        If cbxApprover2V2.Text = "" Or cbxApprover2V2.SelectedIndex = -1 Then
            cbxApprover3V2.Enabled = False
            cbxApprover3V2.SelectedIndex = -1
        Else
            cbxApprover3V2.Enabled = True
            If cbxApprover2V2.SelectedValue = cbxApprover1V2.SelectedValue And cbxApprover2V2.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 1, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover2V2.SelectedIndex = -1
            ElseIf cbxApprover2V2.SelectedValue = cbxApprover3V2.SelectedValue And cbxApprover2V2.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 3, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover2V2.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub CbxApprover1V3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover1V3.SelectedIndexChanged
        If cbxApprover1V3.Text = "" Or cbxApprover1V3.SelectedIndex = -1 Then
            cbxApprover2V3.Enabled = False
            cbxApprover2V3.SelectedIndex = -1
            cbxApprover3V3.Enabled = False
            cbxApprover3V3.SelectedIndex = -1
        Else
            cbxApprover2V3.Enabled = True
            If cbxApprover1V3.SelectedValue = cbxApprover2V3.SelectedValue And cbxApprover1V3.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 2, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover1V3.SelectedIndex = -1
            ElseIf cbxApprover1V3.SelectedValue = cbxApprover3V3.SelectedValue And cbxApprover1V3.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 3, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover1V3.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub CbxApprover2V3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover2V3.SelectedIndexChanged
        If cbxApprover2V3.Text = "" Or cbxApprover2V3.SelectedIndex = -1 Then
            cbxApprover3V3.Enabled = False
            cbxApprover3V3.SelectedIndex = -1
        Else
            cbxApprover3V3.Enabled = True
            If cbxApprover2V3.SelectedValue = cbxApprover1V3.SelectedValue And cbxApprover2V3.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 1, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover2V3.SelectedIndex = -1
            ElseIf cbxApprover2V3.SelectedValue = cbxApprover3V3.SelectedValue And cbxApprover2V3.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 3, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover2V3.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub CbxApprover1V2_TextChanged(sender As Object, e As EventArgs) Handles cbxApprover1V2.TextChanged
        If cbxApprover1V2.Text = "" Or cbxApprover1V2.SelectedIndex = -1 Then
            cbxApprover2V2.Enabled = False
            cbxApprover2V2.SelectedIndex = -1
            cbxApprover3V2.Enabled = False
            cbxApprover3V2.SelectedIndex = -1
        End If
    End Sub

    Private Sub CbxApprover2V2_TextChanged(sender As Object, e As EventArgs) Handles cbxApprover2V2.TextChanged
        If cbxApprover2V2.Text = "" Or cbxApprover2V2.SelectedIndex = -1 Then
            cbxApprover3V2.Enabled = False
            cbxApprover3V2.SelectedIndex = -1
        End If
    End Sub

    Private Sub CbxApprover1V3_TextChanged(sender As Object, e As EventArgs) Handles cbxApprover1V3.TextChanged
        If cbxApprover1V3.Text = "" Or cbxApprover1V3.SelectedIndex = -1 Then
            cbxApprover2V3.Enabled = False
            cbxApprover2V3.SelectedIndex = -1
            cbxApprover3V3.Enabled = False
            cbxApprover3V3.SelectedIndex = -1
        End If
    End Sub

    Private Sub CbxApprover2V3_TextChanged(sender As Object, e As EventArgs) Handles cbxApprover2V3.TextChanged
        If cbxApprover2V3.Text = "" Or cbxApprover2V3.SelectedIndex = -1 Then
            cbxApprover3V3.Enabled = False
            cbxApprover3V3.SelectedIndex = -1
        End If
    End Sub

    Private Sub CbxBranchV2_TextChanged(sender As Object, e As EventArgs) Handles cbxBranchV2.TextChanged
        If cbxBranchV2.Text = "" Or cbxBranchV2.SelectedIndex = -1 Then
            cbxApprover1V2.SelectedIndex = -1
            cbxApprover2V2.SelectedIndex = -1
            cbxApprover3V2.SelectedIndex = -1
            cbxApprover2V2.Enabled = False
            cbxApprover3V2.Enabled = False
            btnSave.Text = "&Save"
        End If
    End Sub

    Private Sub CbxBranchV3_TextChanged(sender As Object, e As EventArgs) Handles cbxBranchV3.TextChanged
        If cbxBranchV3.Text = "" Or cbxBranchV3.SelectedIndex = -1 Then
            cbxApprover1V3.SelectedIndex = -1
            cbxApprover2V3.SelectedIndex = -1
            cbxApprover3V3.SelectedIndex = -1
            cbxApprover2V3.Enabled = False
            cbxApprover3V3.Enabled = False
            btnSave.Text = "&Save"
        End If
    End Sub

    Private Sub CbxApprover3V2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover3V2.SelectedIndexChanged
        If cbxApprover3V2.SelectedIndex = -1 Or cbxApprover3V2.Text = "" Then
        Else
            If cbxApprover3V2.SelectedValue = cbxApprover2V2.SelectedValue And cbxApprover3V2.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 2, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover3V2.SelectedIndex = -1
            ElseIf cbxApprover3V2.SelectedValue = cbxApprover1V2.SelectedValue And cbxApprover3V2.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 1, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover3V2.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub CbxApprover3V3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxApprover3V3.SelectedIndexChanged
        If cbxApprover3V3.SelectedIndex = -1 Or cbxApprover3V3.Text = "" Then
        Else
            If cbxApprover3V3.SelectedValue = cbxApprover2V3.SelectedValue And cbxApprover3V3.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 2, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover3V3.SelectedIndex = -1
            ElseIf cbxApprover3V3.SelectedValue = cbxApprover1V3.SelectedValue And cbxApprover3V3.SelectedIndex > -1 Then
                MsgBox("Selected approver is already selected as approver number 1, please select another.", MsgBoxStyle.Information, "Info")
                cbxApprover3V3.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub CbxNA_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNA.CheckedChanged
        If cbxNA.Checked Then
            iDays.MinValue = 0
            iDays.Value = 0
            iDays.Enabled = False
            dtpFrom.CustomFormat = ""
            dtpFrom.Enabled = False
            dtpTo.CustomFormat = ""
            dtpTo.Enabled = False
        Else
            iDays.MinValue = 1
            iDays.Value = 1
            iDays.Enabled = True
            dtpFrom.CustomFormat = "MMMM dd, yyyy"
            dtpFrom.Enabled = True
            dtpTo.CustomFormat = "MMMM dd, yyyy"
            dtpTo.Enabled = True
        End If
    End Sub

    Private Sub IDays_ValueChanged(sender As Object, e As EventArgs) Handles iDays.ValueChanged
        dtpTo.Value = dtpFrom.Value.AddDays(iDays.Value)
    End Sub

    Private Sub DtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        dtpTo.Value = dtpFrom.Value.AddDays(iDays.Value)
    End Sub

    Private Sub DtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        dtpFrom.Value = dtpTo.Value.AddDays(-iDays.Value)
    End Sub
End Class