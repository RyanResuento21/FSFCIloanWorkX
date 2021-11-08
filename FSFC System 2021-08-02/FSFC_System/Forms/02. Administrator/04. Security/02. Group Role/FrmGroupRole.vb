Imports DevExpress.XtraReports.UI
Public Class FrmGroupRole

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
    Public ViewMode As Boolean
    Public GroupRole As String

    Private Sub FrmGroupRole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1, GridView2})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        PanelEx2.Enabled = False
        GridControl1.Enabled = False

        FirstLoad = True

        With cbxPosition
            .DisplayMember = "Position"
            .ValueMember = "ID"
            Load_Position()
            .SelectedIndex = -1
        End With

        With cbxCopyUser
            .DisplayMember = "Position"
            .ValueMember = "ID"
            .SelectedIndex = -1
        End With

        FirstLoad = False
        If ViewMode Then
            btnAdd.Enabled = False
            GridControl1.Enabled = True
            cbxPosition.Text = GroupRole
        End If
        btnAdd.PerformClick()
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

            GetLabelFontSettings({LabelX155, LabelX3, lblUsing})

            GetComboBoxFontSettings({cbxPosition, cbxCopyUser})

            GetCheckBoxFontSettings({cbxCopy})

            GetButtonFontSettings({btnAllAcess, btnAllSave, btnAllUpdate, btnAllDelete, btnAllPrint, btnAdd, btnSave, btnRefresh, btnCancel, btnPrint, btnAllApprove, btnAllCheck})
        Catch ex As Exception
            TriggerBugReport("Group Role - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Group Role", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
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
        SQL &= "     IFNULL(IF(F.allow_approve = 1,IF(R.allow_approve = 1,'True','False'),'None'),'False') AS 'Approve'"
        SQL &= " FROM form_setup F"
        SQL &= "    LEFT JOIN (SELECT form_id, "
        SQL &= "        allow_access, "
        SQL &= "        allow_save, "
        SQL &= "        allow_update, "
        SQL &= "        allow_delete, "
        SQL &= "        allow_print,"
        SQL &= "        allow_check,"
        SQL &= "        allow_approve"
        If cbxCopy.Checked Then
            SQL &= String.Format(" FROM grouprole_setup WHERE `status` = 'ACTIVE' AND GroupRoleID = '{0}') R", ValidateComboBox(cbxCopyUser))
        Else
            SQL &= String.Format(" FROM grouprole_setup WHERE `status` = 'ACTIVE' AND GroupRoleID = '{0}') R", ValidateComboBox(cbxPosition))
        End If
        SQL &= "     ON F.id = R.form_id"
        SQL &= "  WHERE F.`status` = 'ACTIVE'"
        SQL &= "     ORDER BY F.order_id;"

        Dim DT As DataTable = DataSource(SQL)
        GridControl1.DataSource = DT
        GridControl2.DataSource = DT.Copy
        Load_Using()
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxPosition_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPosition.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        FrmGroupRole_Load(sender, e)
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

        If cbxPosition.Text = "" Then
            MsgBox("Please select/fill Position or Group Role first.", MsgBoxStyle.Information, "Info")
            cbxPosition.DroppedDown = True
            Exit Sub
        ElseIf cbxPosition.SelectedIndex = -1 Then
            If MsgBoxYes(String.Format("{0} is not yet register as Group Role, would you like to automatically register {0} for Group Role?", cbxPosition.Text)) = MsgBoxResult.Yes Then
                Dim SQL_II As String = "INSERT INTO group_role SET"
                SQL_II &= String.Format(" GroupRole = '{0}'", cbxPosition.Text.Trim.InsertQuote)
                DataObject(SQL_II)
                Dim OldGroupRole As String = cbxPosition.Text
                MsgBox(String.Format("{0} is now registered for Group Role.", cbxPosition.Text), MsgBoxStyle.Information, "Info")
                FirstLoad = True
                Load_Position()
                cbxPosition.Text = OldGroupRole
                FirstLoad = False
            Else
                Exit Sub
            End If
        End If

        'Dim DT As New DataTable
        'DT = DataSource(String.Format("SELECT user_id, user_code FROM restriction_setup WHERE `status` = 'ACTIVE'  AND IF('{0}' = 'P', PositionID = '{1}', GroupRoleID = '{1}') GROUP BY user_id", drv("Type"), ValidateComboBox(cbxPosition)))
        'DataObject(String.Format("UPDATE restriction_setup SET `status` = 'INACTIVE' WHERE `status` = 'ACTIVE'  AND IF('{0}' = 'P', PositionID = '{1}', GroupRoleID = '{1}') ", drv("Type"), ValidateComboBox(cbxPosition)))
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Cursor = Cursors.WaitCursor
                Dim SQL As String
                'SQL = String.Format("DELETE FROM grouprole_setup WHERE `status` = 'ACTIVE' AND IF('{1}' = 'P', Position_ID = '{0}', GroupRoleID = '{0}');", ValidateComboBox(cbxPosition), drv("Type"))
                SQL = String.Format("UPDATE grouprole_setup SET `status` = 'INACTIVE' WHERE `status` = 'ACTIVE' AND GroupRoleID = '{0}';", ValidateComboBox(cbxPosition))
                For x As Integer = 0 To GridView1.RowCount - 1
                    If GridView1.GetRowCellValue(x, "Access").ToString = "True" Or GridView1.GetRowCellValue(x, "Save").ToString = "True" Or GridView1.GetRowCellValue(x, "Update").ToString = "True" Or GridView1.GetRowCellValue(x, "Delete").ToString = "True" Or GridView1.GetRowCellValue(x, "Print").ToString = "True" Or GridView1.GetRowCellValue(x, "Check").ToString = "True" Or GridView1.GetRowCellValue(x, "Approve").ToString = "True" Then
                        SQL &= " INSERT INTO grouprole_setup SET "
                        SQL &= String.Format(" GroupRoleID = '{0}',", ValidateComboBox(cbxPosition))
                        SQL &= String.Format(" form_id = '{0}',", GridView1.GetRowCellValue(x, "ID"))
                        SQL &= String.Format(" allow_access = {0},", CBool(If(GridView1.GetRowCellValue(x, "Access").ToString = "None", False, GridView1.GetRowCellValue(x, "Access"))))
                        SQL &= String.Format(" allow_save = {0},", CBool(If(GridView1.GetRowCellValue(x, "Save").ToString = "None", False, GridView1.GetRowCellValue(x, "Save"))))
                        SQL &= String.Format(" allow_update = {0},", CBool(If(GridView1.GetRowCellValue(x, "Update").ToString = "None", False, GridView1.GetRowCellValue(x, "Update"))))
                        SQL &= String.Format(" allow_delete = {0},", CBool(If(GridView1.GetRowCellValue(x, "Delete").ToString = "None", False, GridView1.GetRowCellValue(x, "Delete"))))
                        SQL &= String.Format(" allow_Print = {0},", CBool(If(GridView1.GetRowCellValue(x, "Print").ToString = "None", False, GridView1.GetRowCellValue(x, "Print"))))
                        SQL &= String.Format(" allow_Check = {0},", CBool(If(GridView1.GetRowCellValue(x, "Check").ToString = "None", False, GridView1.GetRowCellValue(x, "Check"))))
                        SQL &= String.Format(" allow_Approve = {0};", CBool(If(GridView1.GetRowCellValue(x, "Approve").ToString = "None", False, GridView1.GetRowCellValue(x, "Approve"))))

                        'For y As Integer = 0 To DT.Rows.Count - 1
                        '    'UPDATE RESTRICTIONS INSERT *******************************************************************************************
                        '    SQL &= "INSERT INTO restriction_setup SET "
                        '    SQL &= String.Format(" user_id = '{0}',", DT(y)("user_id"))
                        '    SQL &= String.Format(" user_code = '{0}',", DT(y)("user_code"))
                        '    If drv("Type").ToString = "P" Then
                        '        SQL &= String.Format(" PositionID = '{0}',", ValidateComboBox(cbxPosition))
                        '        SQL &= String.Format(" GroupRoleID = '{0}',", 0)
                        '    Else
                        '        SQL &= String.Format(" PositionID = '{0}',", 0)
                        '        SQL &= String.Format(" GroupRoleID = '{0}',", ValidateComboBox(cbxPosition))
                        '    End If
                        '    SQL &= String.Format(" form_id = '{0}',", GridView1.GetRowCellValue(x, "ID"))
                        '    SQL &= String.Format(" allow_access = {0},", CBool(If(GridView1.GetRowCellValue(x, "Access").ToString = "None", False, GridView1.GetRowCellValue(x, "Access"))))
                        '    SQL &= String.Format(" allow_save = {0},", CBool(If(GridView1.GetRowCellValue(x, "Save").ToString = "None", False, GridView1.GetRowCellValue(x, "Save"))))
                        '    SQL &= String.Format(" allow_update = {0},", CBool(If(GridView1.GetRowCellValue(x, "Update").ToString = "None", False, GridView1.GetRowCellValue(x, "Update"))))
                        '    SQL &= String.Format(" allow_delete = {0},", CBool(If(GridView1.GetRowCellValue(x, "Delete").ToString = "None", False, GridView1.GetRowCellValue(x, "Delete"))))
                        '    SQL &= String.Format(" allow_Print = {0},", CBool(If(GridView1.GetRowCellValue(x, "Print").ToString = "None", False, GridView1.GetRowCellValue(x, "Print"))))
                        '    SQL &= String.Format(" allow_Check = {0},", CBool(If(GridView1.GetRowCellValue(x, "Check").ToString = "None", False, GridView1.GetRowCellValue(x, "Check"))))
                        '    SQL &= String.Format(" allow_Approve = {0};", CBool(If(GridView1.GetRowCellValue(x, "Approve").ToString = "None", False, GridView1.GetRowCellValue(x, "Approve"))))
                        '    'UPDATE RESTRICTIONS INSERT *******************************************************************************************
                        'Next
                    End If
                Next

                DataObject(SQL)
                Cursor = Cursors.Default
                Logs("Group Role", "Save", "Authorization for Group Role for " & cbxPosition.Text, Changes, "", "", "")
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
                btnRefresh.PerformClick()
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
            TriggerBugReport("Group Role - Changes", ex.Message.ToString)
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
        Dim Report As New RptGroupRole
        With Report
            .Name = "Group Role of " & cbxPosition.Text
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
            Logs("Group Role", "Print", "[SENSITIVE] Print Group Role List", "", "", "", "")

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

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        PanelEx2.Enabled = True
        GridControl1.Enabled = True
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnRefresh.Enabled = True
        btnPrint.Enabled = True
        LoadData()
    End Sub

    Private Sub CbxPosition_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition.KeyDown
        Try
            If e.KeyCode = Keys.Delete Then
                Dim drv As DataRowView = DirectCast(cbxPosition.SelectedItem, DataRowView)
                If drv("Type") = "G" Then
                    If MsgBoxYes("Are you sure you want to remove this Group Role from the list?") = MsgBoxResult.Yes Then
                        DataObject(String.Format("UPDATE group_role SET `status` = 'DELETED' WHERE ID = '{0}';", cbxPosition.SelectedValue))
                        MsgBox("Successfully Removed!", MsgBoxStyle.Information, "Info")
                        Load_Position()
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Load_Position()
        Dim DT As DataTable = DataSource("SELECT CONCAT('P', ID) AS 'ID', `Position` FROM position_setup WHERE `status` = 'ACTIVE' UNION ALL SELECT CONCAT('G', ID) AS 'ID', GroupRole FROM group_role WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
        cbxPosition.DataSource = DT.Copy
        cbxCopyUser.DataSource = DT.Copy
    End Sub

    Private Sub Load_Using()
        If cbxPosition.Text = "" Or cbxPosition.SelectedIndex = -1 Then
            lblUsing.Text = ""
            Exit Sub
        End If

        lblUsing.Text = DataObject(String.Format("SELECT FORMAT(COUNT(ID),0) FROM users WHERE GroupRoleID = '{0}' AND `status` = 'ACTIVE';", cbxPosition.SelectedValue)) & " employee(s) using this group role"
    End Sub

    Private Sub CbxPosition_TextChanged(sender As Object, e As EventArgs) Handles cbxPosition.TextChanged
        If cbxPosition.Text = "" Or cbxPosition.SelectedIndex = -1 Then
            lblUsing.Text = ""
            Exit Sub
        End If
    End Sub

    Private Sub CbxCopyUser_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxCopyUser.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        LoadData()
    End Sub

    Private Sub CbxCopy_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCopy.CheckedChanged
        If cbxCopy.Checked Then
            cbxCopyUser.Enabled = True
        Else
            cbxCopyUser.Enabled = False
            cbxCopyUser.SelectedIndex = -1
        End If
    End Sub
End Class