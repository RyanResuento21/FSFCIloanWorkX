Public Class FrmPosition

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean

    Private Sub FrmPosition_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2})

            GetTextBoxFontSettings({txtPosition, txtPositionCode})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetCheckBoxFontSettings({cbxYes, cbxNo})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Position - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Position", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource("SELECT ID, position_code AS 'Position Code', `Position`, IF(Head = 1,'YES','NO') AS 'Department Head', (SELECT FORMAT(IFNULL(COUNT(ID),0),0) FROM employee_setup WHERE (position_id = position_setup.ID OR secondary_position_id = position_setup.ID) AND `status` = 'ACTIVE') AS 'No. of Employee(s)' FROM position_setup WHERE `status` = 'ACTIVE' ORDER BY `Position`;")
        GridView1.Columns("Position").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Position").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn2.Width = 698 - 17
        Else
            GridColumn2.Width = 698
        End If
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub TxtPosition_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPosition.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPositionCode.Focus()
        End If
    End Sub

    Private Sub TxtPositionCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPositionCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE
    Private Sub TxtPosition_Leave(sender As Object, e As EventArgs) Handles txtPosition.Leave
        txtPosition.Text = ReplaceText(txtPosition.Text.Trim)
    End Sub

    Private Sub TxtPositionCode_Leave(sender As Object, e As EventArgs) Handles txtPositionCode.Leave
        txtPositionCode.Text = ReplaceText(txtPositionCode.Text.Trim)
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
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
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
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            LoadData()
        End If
    End Sub

    Private Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        txtPosition.Text = ""
        txtPositionCode.Text = ""
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

        If txtPosition.Text = "" Then
            MsgBox("Please fill position field.", MsgBoxStyle.Information, "Info")
            txtPosition.Focus()
            Exit Sub
        End If
        If txtPositionCode.Text = "" Then
            MsgBox("Please fill position code field.", MsgBoxStyle.Information, "Info")
            txtPositionCode.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM position_setup WHERE (`position` = '{0}' OR position_code = '{1}') AND `status` = 'ACTIVE'", txtPosition.Text, txtPositionCode.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Either position name ({0}) or position code ({1}) already exist, Please check your data.", txtPosition.Text, txtPositionCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO position_setup SET"
                SQL &= String.Format(" `position` = '{0}', ", txtPosition.Text)
                SQL &= String.Format(" `head` = '{0}', ", If(cbxYes.Checked, 1, 0))
                SQL &= String.Format(" position_code = '{0}'", txtPositionCode.Text)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Position", "Save", String.Format("Add new position {0}", txtPosition.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM position_setup WHERE (`position` = '{0}' OR position_code = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}'", txtPosition.Text, txtPositionCode.Text, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Either position name ({0}) or position code ({1}) already exist, Please check your data.", txtPosition.Text, txtPositionCode.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE position_setup SET"
                SQL &= String.Format(" `position` = '{0}', ", txtPosition.Text)
                SQL &= String.Format(" `head` = '{0}', ", If(cbxYes.Checked, 1, 0))
                SQL &= String.Format(" position_code = '{0}'", txtPositionCode.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Position", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtPosition.Text = txtPosition.Tag Then
            Else
                Change &= String.Format("Change Position from {0} to {1}. ", txtPosition.Tag, txtPosition.Text)
            End If
            If txtPositionCode.Text = txtPositionCode.Tag Then
            Else
                Change &= String.Format("Change Position Code from {0} to {1}. ", txtPositionCode.Tag, txtPositionCode.Text)
            End If
            If If(cbxYes.Checked, 1, 0) = cbxYes.Tag Then
            Else
                Change &= String.Format("Change Head from {0} to {1}. ", cbxYes.Tag, If(cbxYes.Checked, 1, 0))
            End If
        Catch ex As Exception
            TriggerBugReport("Position - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE position_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Position", "Cancel", Reason, String.Format("Cancel position {0}", txtPosition.Text), "", "", "")
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
        StandardPrinting("POSITION LIST", GridControl1)
        Logs("Position", "Print", "Print Position List", "", "", "", "")
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
            txtPosition.Text = .GetFocusedRowCellValue("Position")
            txtPosition.Tag = .GetFocusedRowCellValue("Position")
            txtPositionCode.Text = .GetFocusedRowCellValue("Position Code")
            txtPositionCode.Tag = .GetFocusedRowCellValue("Position Code")
            If .GetFocusedRowCellValue("Department Head") = "YES" Then
                cbxYes.Checked = True
                cbxYes.Tag = 1
            Else
                cbxNo.Checked = True
                cbxYes.Tag = 0
            End If
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

    Private Sub CbxYes_CheckedChanged(sender As Object, e As EventArgs) Handles cbxYes.CheckedChanged
        If cbxYes.Checked Then
            cbxNo.Checked = False
        End If

        If cbxYes.Checked = False And cbxNo.Checked = False Then
            cbxNo.Checked = True
        End If
    End Sub

    Private Sub CbxNo_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNo.CheckedChanged
        If cbxNo.Checked Then
            cbxYes.Checked = False
        End If

        If cbxYes.Checked = False And cbxNo.Checked = False Then
            cbxNo.Checked = True
        End If
    End Sub

    Private Sub IViewEmployees_Click(sender As Object, e As EventArgs) Handles iViewEmployees.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Then
                Exit Sub
            ElseIf GridView1.GetFocusedRowCellValue("No. of Employee(s)") = 0 Then
                MsgBox(String.Format("No employee assigned for {0}", GridView1.GetFocusedRowCellValue("Position")), MsgBoxStyle.Information, "Info")
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Empl As New FrmEmployee
        With Empl
            .From_Position = True
            .DeptID_PosID = GridView1.GetFocusedRowCellValue("ID")
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class