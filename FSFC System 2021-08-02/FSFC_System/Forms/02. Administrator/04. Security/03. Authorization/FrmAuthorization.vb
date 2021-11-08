Imports DevExpress.XtraReports.UI
Public Class FrmAuthorization

    Dim FirstLoad As Boolean = True
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim AllAccess As Boolean
    Dim AllSave As Boolean
    Dim AllUpdate As Boolean
    Dim AllDelete As Boolean
    Dim AllPrint As Boolean
    Dim AllCheck As Boolean
    Dim AllApprove As Boolean
    Dim GroupRole As Boolean

    Private Sub FrmAuthorization_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        PanelEx2.Enabled = False
        GridControl1.Enabled = False
        FirstLoad = True
        cbxGroupRole.Checked = False
        cbxCopy.Checked = False

        With cbxBranch
            .DisplayMember = "Branch"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, Branch FROM branch WHERE `status` = 'ACTIVE' ORDER BY branchID;")
            .SelectedIndex = -1
        End With

        With cbxPosition
            .DisplayMember = "Position"
            .ValueMember = "ID"
            .DataSource = DataSource("SELECT ID, `Position`, 'P' AS 'Type' FROM position_setup WHERE `status` = 'ACTIVE' UNION ALL SELECT ID, GroupRole, 'G' AS 'Type' FROM group_role WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
            .SelectedIndex = -1
        End With

        With cbxCopyUser
            .DisplayMember = "Username"
            .ValueMember = "user_code"
            .DataSource = DataSource("SELECT ID, user_code, CONCAT('[', empl_name, '] - ', username) AS 'Username' FROM users WHERE `status` = 'ACTIVE' ORDER BY `Username`;")
            .SelectedIndex = -1
        End With

        FirstLoad = False
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2, LabelX3})

            GetComboBoxFontSettings({cbxBranch, cbxUser, cbxPosition, cbxCopyUser})

            GetCheckBoxFontSettings({cbxGroupRole, cbxCopy})

            GetButtonFontSettings({btnAllAcess, btnAllSave, btnAllUpdate, btnAllDelete, btnAllPrint, btnAdd, btnSave, btnRefresh, btnCancel, btnPrint, btnAllApprove, btnAllCheck})
        Catch ex As Exception
            TriggerBugReport("Authorization - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Authorization", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "     F.ID,"
        SQL &= "     CONCAT('[', F.module, '] ', IF(F.`group` = '','',CONCAT('(',F.`group`,') ')), F.form) AS 'Form',"
        SQL &= "     IFNULL(IF(F.allow_access = 1,IF(R.allow_access = 1,'True','False'),'None'),'False') AS 'Access',"
        SQL &= "     IFNULL(IF(F.allow_save = 1,IF(R.allow_save = 1,'True','False'),'None'),'False') AS 'Save',"
        SQL &= "     IFNULL(IF(F.allow_update = 1,IF(R.allow_update = 1,'True','False'),'None'),'False') AS 'Update',"
        SQL &= "     IFNULL(IF(F.allow_delete = 1,IF(R.allow_delete = 1,'True','False'),'None'),'False') AS 'Delete',"
        SQL &= "     IFNULL(IF(F.allow_print = 1,IF(R.allow_print = 1,'True','False'),'None'),'False') AS 'Print',"
        SQL &= "     IFNULL(IF(F.allow_Check = 1,IF(R.allow_Check = 1,'True','False'),'None'),'False') AS 'Check',"
        SQL &= "     IFNULL(IF(F.allow_Approve = 1,IF(R.allow_Approve = 1,'True','False'),'None'),'False') AS 'Approve'"
        SQL &= " FROM form_setup F"
        SQL &= "    LEFT JOIN (SELECT form_id, "
        SQL &= "        allow_access, "
        SQL &= "        allow_save, "
        SQL &= "        allow_update, "
        SQL &= "        allow_delete, "
        SQL &= "        allow_Print,"
        SQL &= "        allow_Check,"
        SQL &= "        allow_Approve"
        If cbxCopy.Checked Then
            SQL &= String.Format(" FROM restriction_setup WHERE `status` = 'ACTIVE' AND user_code = '{0}') R", ValidateComboBox(cbxCopyUser))
        Else
            SQL &= String.Format(" FROM restriction_setup WHERE `status` = 'ACTIVE' AND user_code = '{0}') R", ValidateComboBox(cbxUser))
        End If
        SQL &= "     ON F.id = R.form_id"
        SQL &= "  WHERE F.`status` = 'ACTIVE'"
        SQL &= "     ORDER BY F.order_id;"

        Dim DT As DataTable = DataSource(SQL)
        GridControl1.DataSource = DT
        GridControl2.DataSource = DT.Copy
        Dim GroupRole As DataTable = DataSource(String.Format("SELECT PositionID, GroupRoleID FROM restriction_setup WHERE `status` = 'ACTIVE' AND user_code = '{0}' AND (PositionID > 0 OR GroupRoleID > 0) LIMIT 1;", ValidateComboBox(cbxUser)))
        If GroupRole.Rows.Count > 0 Then
            FirstLoad = True
            cbxGroupRole.Checked = True
            If GroupRole(0)("PositionID") > 0 Then
                cbxPosition.Text = DataObject(String.Format("SELECT `Position` FROM position_setup WHERE ID = '{0}';", GroupRole(0)("PositionID")))
            ElseIf GroupRole(0)("GroupRoleID") > 0 Then
                cbxPosition.Text = DataObject(String.Format("SELECT GroupRole FROM group_role WHERE ID = '{0}';", GroupRole(0)("GroupRoleID")))
            End If

            FirstLoad = False
        Else
            cbxGroupRole.Checked = False
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPosition.SelectedIndexChanged
        If FirstLoad Or cbxPosition.SelectedIndex = -1 Or cbxPosition.Text = "" Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPosition.SelectedItem, DataRowView)
        Dim SQL As String = "SELECT"
        SQL &= "     F.ID,"
        SQL &= "     CONCAT('[', F.module, '] ', IF(F.`group` = '','',CONCAT('(',F.`group`,') ')), F.form) AS 'Form',"
        SQL &= "     IFNULL(IF(F.allow_access = 1,IF(R.allow_access = 1,'True','False'),'None'),'False') AS 'Access',"
        SQL &= "     IFNULL(IF(F.allow_save = 1,IF(R.allow_save = 1,'True','False'),'None'),'False') AS 'Save',"
        SQL &= "     IFNULL(IF(F.allow_update = 1,IF(R.allow_update = 1,'True','False'),'None'),'False') AS 'Update',"
        SQL &= "     IFNULL(IF(F.allow_delete = 1,IF(R.allow_delete = 1,'True','False'),'None'),'False') AS 'Delete',"
        SQL &= "     IFNULL(IF(F.allow_print = 1,IF(R.allow_print = 1,'True','False'),'None'),'False') AS 'Print',"
        SQL &= "     IFNULL(IF(F.allow_check = 1,IF(R.allow_check = 1,'True','False'),'None'),'False') AS 'Check',"
        SQL &= "     IFNULL(IF(F.allow_Approve = 1,IF(R.allow_Approve = 1,'True','False'),'None'),'False') AS 'Approve'"
        SQL &= " FROM form_setup F"
        SQL &= "    LEFT JOIN (SELECT form_id, "
        SQL &= "        allow_access, "
        SQL &= "        allow_save, "
        SQL &= "        allow_update, "
        SQL &= "        allow_delete, "
        SQL &= "        allow_Print,"
        SQL &= "        allow_Check,"
        SQL &= "        allow_Approve"
        SQL &= String.Format(" FROM grouprole_setup WHERE `status` = 'ACTIVE' AND IF('{1}' = '0',TRUE,IF('{1}' = 'P',position_id = '{0}',GroupRoleID = '{0}'))) R", ValidateComboBox(cbxPosition), If(ValidateComboBox(cbxPosition) = 0, "X", drv("Type")))
        SQL &= "     ON F.id = R.form_id"
        SQL &= "  WHERE F.`status` = 'ACTIVE'"
        SQL &= "     ORDER BY F.order_id;"
        FirstLoad = True

        GridControl1.DataSource = DataSource(SQL)
        GroupRole = True

        FirstLoad = False
    End Sub

    Private Sub CbxUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxUser.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        FirstLoad = True
        With cbxUser
            .DisplayMember = "Username"
            .ValueMember = "user_code"
            .DataSource = DataSource(String.Format("SELECT ID, user_code, CONCAT('[', empl_name, '] - ', username) AS 'Username' FROM users WHERE `status` = 'ACTIVE' AND branch_id = '{0}' ORDER BY `Username`;", ValidateComboBox(cbxBranch)))
            .SelectedIndex = -1
        End With
        FirstLoad = False
    End Sub

    Private Sub CbxBranch_TextChanged(sender As Object, e As EventArgs) Handles cbxBranch.TextChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxBranch.Text.Trim = "" Then
            With cbxUser
                .DisplayMember = "Username"
                .ValueMember = "user_code"
                .DataSource = DataSource("SELECT ID, user_code, CONCAT('[', empl_name, '] - ', username) AS 'Username' FROM users WHERE `status` = 'ACTIVE' AND branch_id = 0;")
                .SelectedIndex = -1
            End With
        End If
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        FrmAuthorization_Load(sender, e)
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnRefresh.Enabled = False
        btnPrint.Enabled = False
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If cbxUser.SelectedIndex = -1 Or cbxUser.Text = "" Then
            MsgBox("Please select user first.", MsgBoxStyle.Information, "Info")
            cbxUser.DroppedDown = True
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxUser.SelectedItem, DataRowView)
        Dim drv_P As DataRowView = DirectCast(cbxPosition.SelectedItem, DataRowView)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                DataObject(String.Format("UPDATE restriction_setup SET `status` = 'INACTIVE' WHERE user_code = '{0}'", ValidateComboBox(cbxUser)))
                Dim SQL As String = ""
                For x As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Access").ToString = "True" Or GridView1.GetRowCellValue(x, "Save").ToString = "True" Or GridView1.GetRowCellValue(x, "Update").ToString = "True" Or GridView1.GetRowCellValue(x, "Delete").ToString = "True" Or GridView1.GetRowCellValue(x, "Print").ToString = "True" Or GridView1.GetRowCellValue(x, "Check").ToString = "True" Or GridView1.GetRowCellValue(x, "Approve").ToString = "True" Then
                        SQL &= "INSERT INTO restriction_setup SET "
                        SQL &= String.Format(" user_id = '{0}',", drv("ID"))
                        SQL &= String.Format(" user_code = '{0}',", ValidateComboBox(cbxUser))
                        If GroupRole Then
                            If drv_P("Type") = "P" Then
                                SQL &= String.Format(" PositionID = '{0}',", ValidateComboBox(cbxPosition))
                                SQL &= String.Format(" GroupRoleID = '{0}',", 0)
                            Else
                                SQL &= String.Format(" PositionID = '{0}',", 0)
                                SQL &= String.Format(" GroupRoleID = '{0}',", ValidateComboBox(cbxPosition))
                            End If
                        End If
                        SQL &= String.Format(" form_id = '{0}',", GridView1.GetRowCellValue(x, "ID"))
                        SQL &= String.Format(" allow_access = {0},", CBool(If(GridView1.GetRowCellValue(x, "Access").ToString = "None", False, GridView1.GetRowCellValue(x, "Access"))))
                        SQL &= String.Format(" allow_save = {0},", CBool(If(GridView1.GetRowCellValue(x, "Save").ToString = "None", False, GridView1.GetRowCellValue(x, "Save"))))
                        SQL &= String.Format(" allow_update = {0},", CBool(If(GridView1.GetRowCellValue(x, "Update").ToString = "None", False, GridView1.GetRowCellValue(x, "Update"))))
                        SQL &= String.Format(" allow_delete = {0},", CBool(If(GridView1.GetRowCellValue(x, "Delete").ToString = "None", False, GridView1.GetRowCellValue(x, "Delete"))))
                        SQL &= String.Format(" allow_Print = {0},", CBool(If(GridView1.GetRowCellValue(x, "Print").ToString = "None", False, GridView1.GetRowCellValue(x, "Print"))))
                        SQL &= String.Format(" allow_Check = {0},", CBool(If(GridView1.GetRowCellValue(x, "Check").ToString = "None", False, GridView1.GetRowCellValue(x, "Check"))))
                        SQL &= String.Format(" allow_Approve = {0};", CBool(If(GridView1.GetRowCellValue(x, "Approve").ToString = "None", False, GridView1.GetRowCellValue(x, "Approve"))))
                    End If
                Next
                If SQL = "" Then
                Else
                    DataObject(SQL)
                End If
                Cursor = Cursors.Default
                Logs("Authorization", "Save", "Add Authorization for " & cbxUser.Text, Changes, "", "", "")
                Restriction_DT = DataSource(String.Format("SELECT form_id, allow_access, allow_save, allow_update, allow_delete, allow_print FROM restriction_setup WHERE user_id = '{0}' AND user_code = '{1}' AND `status` = 'ACTIVE';", User_ID, User_Code))
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnRefresh.PerformClick()
                With cbxUser
                    .DisplayMember = "Username"
                    .ValueMember = "user_code"
                    .DataSource = DataSource(String.Format("SELECT ID, user_code, CONCAT('[', empl_name, '] - ', username) AS 'Username' FROM users WHERE `status` = 'ACTIVE' AND branch_id = '{0}';", ValidateComboBox(cbxBranch)))
                    .SelectedIndex = -1
                End With
                LoadData()
                btnAdd.Focus()
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Access") = GridView2.GetRowCellValue(x, "Access") Then
                Else
                    Change &= String.Format("Change View for {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Access"), GridView1.GetRowCellValue(x, "Access"), GridView1.GetRowCellValue(x, "Form"))
                End If
                If GridView1.GetRowCellValue(x, "Save") = GridView2.GetRowCellValue(x, "Save") Then
                Else
                    Change &= String.Format("Change Save for {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Save"), GridView1.GetRowCellValue(x, "Save"), GridView1.GetRowCellValue(x, "Form"))
                End If
                If GridView1.GetRowCellValue(x, "Update") = GridView2.GetRowCellValue(x, "Update") Then
                Else
                    Change &= String.Format("Change Update for {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Update"), GridView1.GetRowCellValue(x, "Update"), GridView1.GetRowCellValue(x, "Form"))
                End If
                If GridView1.GetRowCellValue(x, "Delete") = GridView2.GetRowCellValue(x, "Delete") Then
                Else
                    Change &= String.Format("Change Cancel for {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Delete"), GridView1.GetRowCellValue(x, "Delete"), GridView1.GetRowCellValue(x, "Form"))
                End If
                If GridView1.GetRowCellValue(x, "Print") = GridView2.GetRowCellValue(x, "Print") Then
                Else
                    Change &= String.Format("Change Print for {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Print"), GridView1.GetRowCellValue(x, "Print"), GridView1.GetRowCellValue(x, "Form"))
                End If
                If GridView1.GetRowCellValue(x, "Check") = GridView2.GetRowCellValue(x, "Check") Then
                Else
                    Change &= String.Format("Change Check for {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Check"), GridView1.GetRowCellValue(x, "Check"), GridView1.GetRowCellValue(x, "Form"))
                End If
                If GridView1.GetRowCellValue(x, "Approve") = GridView2.GetRowCellValue(x, "Approve") Then
                Else
                    Change &= String.Format("Change Approve for {2} from {0} to {1}. ", GridView2.GetRowCellValue(x, "Approve"), GridView1.GetRowCellValue(x, "Approve"), GridView1.GetRowCellValue(x, "Form"))
                End If
            Next
        Catch ex As Exception
            TriggerBugReport("Authorization - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or e.KeyCode = Keys.Escape Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnAdd.Focus()
            btnAdd.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptAuthorization
        With Report
            .Name = "Group Role of " & cbxPosition.Text
            .lblBranch.Text = cbxBranch.Text
            .lblUser.Text = cbxUser.Text
            .lblGroupRole.Text = cbxPosition.Text

            Dim DT As DataTable = GridControl1.DataSource
            For x As Integer = 0 To DT.Rows.Count - 1
                DT(x)("Access") = DT(x)("Access").ToString = "True"
                DT(x)("Save") = DT(x)("Save").ToString = "True"
                DT(x)("Update") = DT(x)("Update").ToString = "True"
                DT(x)("Delete") = DT(x)("Delete").ToString = "True"
                DT(x)("Print") = DT(x)("Print").ToString = "True"
                DT(x)("Check") = DT(x)("Check").ToString = "True"
                DT(x)("Approve") = DT(x)("Approve").ToString = "True"
            Next
            .DataSource = DT
            .lblForm.DataBindings.Add("Text", DT, "Form")
            .cbxView.DataBindings.Add("Checked", DT, "Access")
            .cbxSave.DataBindings.Add("Checked", DT, "Save")
            .cbxUpdate.DataBindings.Add("Checked", DT, "Update")
            .cbxDelete.DataBindings.Add("Checked", DT, "Delete")
            .cbxPrint.DataBindings.Add("Checked", DT, "Print")
            .cbxCheck.DataBindings.Add("Checked", DT, "Check")
            .cbxApprove.DataBindings.Add("Checked", DT, "Approve")
            Logs("Authorization", "Print", "[SENSITIVE] Print Authorization of " & cbxUser.Text, "", "", "", "")

            .ShowPreview()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAllAcess_Click(sender As Object, e As EventArgs) Handles btnAllAcess.Click
        If AllAccess = False Then
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Access").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Access", True)
                End If
            Next
            AllAccess = True
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Access").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Access", False)
                End If
            Next
            AllAccess = False
        End If
    End Sub

    Private Sub BtnAllSave_Click(sender As Object, e As EventArgs) Handles btnAllSave.Click
        If AllSave = False Then
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Save").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Save", True)
                End If
            Next
            AllSave = True
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Save").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Save", False)
                End If
            Next
            AllSave = False
        End If
    End Sub

    Private Sub BtnAllUpdate_Click(sender As Object, e As EventArgs) Handles btnAllUpdate.Click
        If AllUpdate = False Then
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Update").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Update", True)
                End If
            Next
            AllUpdate = True
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Update").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Update", False)
                End If
            Next
            AllUpdate = False
        End If
    End Sub

    Private Sub BtnAllDelete_Click(sender As Object, e As EventArgs) Handles btnAllDelete.Click
        If AllDelete = False Then
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Delete").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Delete", True)
                End If
            Next
            AllDelete = True
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Delete").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Delete", False)
                End If
            Next
            AllDelete = False
        End If
    End Sub

    Private Sub BtnAllPrint_Click(sender As Object, e As EventArgs) Handles btnAllPrint.Click
        If AllPrint = False Then
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Print").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Print", True)
                End If
            Next
            AllPrint = True
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Print").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Print", False)
                End If
            Next
            AllPrint = False
        End If
    End Sub

    Private Sub BtnAllCheck_Click(sender As Object, e As EventArgs) Handles btnAllCheck.Click
        If AllCheck = False Then
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Check").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Check", True)
                End If
            Next
            AllCheck = True
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Check").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Check", False)
                End If
            Next
            AllCheck = False
        End If
    End Sub

    Private Sub BtnAllApprove_Click(sender As Object, e As EventArgs) Handles btnAllApprove.Click
        If AllApprove = False Then
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Approve").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Approve", True)
                End If
            Next
            AllApprove = True
        Else
            For x As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(x, "Approve").ToString = "None" Then
                Else
                    GridView1.SetRowCellValue(x, "Approve", False)
                End If
            Next
            AllApprove = False
        End If
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        If FirstLoad Then
            Exit Sub
        End If

        GroupRole = False
    End Sub

    Private Sub CbxGroupRole_CheckedChanged(sender As Object, e As EventArgs) Handles cbxGroupRole.CheckedChanged
        If cbxGroupRole.Checked Then
            cbxPosition.Enabled = True
        Else
            cbxPosition.Enabled = False
            cbxPosition.SelectedIndex = -1
        End If
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        PanelEx2.Enabled = True
        GridControl1.Enabled = True
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnRefresh.Enabled = True
        btnPrint.Enabled = True
    End Sub

    Private Sub CbxCopy_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCopy.CheckedChanged
        If cbxCopy.Checked Then
            cbxCopyUser.Enabled = True
        Else
            cbxCopyUser.Enabled = False
            cbxCopyUser.SelectedIndex = -1
        End If
    End Sub

    Private Sub CbxCopyUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCopyUser.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub
End Class