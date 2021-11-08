Public Class FrmYardSetup

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Private Sub FrmYardSetup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            .DataSource = DataSource(String.Format("SELECT ID, Branch FROM branch WHERE `status` = 'ACTIVE' AND (FIND_IN_SET(ID,'{0}') OR ID = '{1}') ORDER BY BranchID * 1;", If(Multiple_ID = "", Branch_ID, Multiple_ID), cbxBranch.Tag))
            If cbxBranch.Enabled = False Then
                .SelectedValue = cbxBranch.Tag
            Else
                .SelectedValue = Branch_ID
            End If
        End With

        LoadData()
    End Sub

    Private Sub FixUI(ApplyUI As Boolean)
        Try
            If ApplyUI = False Then
                Exit Sub
            End If
            GetLabelHeaderFontSettings({lblTitle})

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2, LabelX3})

            GetTextBoxFontSettings({txtAddress, txtCode, txtContactNumber})

            GetCheckBoxFontSettings({cbxDefault})

            GetComboBoxFontSettings({cbxBranch})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Yard Setup - FixUI", ex.Message.ToString)
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
        OpenFormHistory("Yard", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        GridControl1.DataSource = DataSource("SELECT ID, BranchID, Branch(BranchID) AS 'Branch', Address, IF(`Default`,CONCAT(Address, ' [DEFAULT]'),Address) AS 'AddressDisplay', `Default`, YardCode, ContactNumber FROM yard_setup WHERE `status` = 'ACTIVE' ORDER BY BranchID, YardCode;")
        GridView1.Columns("Branch").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Branch").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

    '***KEYDOWN
    Private Sub CbxBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtContactNumber_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactNumber.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
    '***KEYDOWN

    '***LEAVE

    Private Sub TxtAddress_Leave(sender As Object, e As EventArgs) Handles txtAddress.Leave, cbxBranch.Leave
        txtAddress.Text = ReplaceText(txtAddress.Text.Trim)
    End Sub

    Private Sub TxtCode_Leave(sender As Object, e As EventArgs) Handles txtCode.Leave
        txtCode.Text = ReplaceText(txtCode.Text.Trim)
    End Sub

    Private Sub TxtContactNumber_Leave(sender As Object, e As EventArgs) Handles txtContactNumber.Leave
        txtContactNumber.Text = ReplaceText(txtContactNumber.Text.Trim)
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
        If cbxBranch.Tag = Nothing Then
            cbxBranch.Enabled = True
        End If
        txtAddress.Text = ""
        cbxDefault.Checked = False
        txtCode.Text = ""
        txtContactNumber.Text = ""
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

        If cbxBranch.Text.Trim = "" Or cbxBranch.SelectedIndex = -1 Then
            MsgBox("Please select branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
            Exit Sub
        End If
        If txtAddress.Text.Trim = "" Then
            MsgBox("Please fill address field.", MsgBoxStyle.Information, "Info")
            txtAddress.Focus()
            Exit Sub
        End If
        If txtCode.Text.Trim = "" Then
            MsgBox("Please fill yard code field.", MsgBoxStyle.Information, "Info")
            txtCode.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM yard_setup WHERE BranchID = '{2}' AND (address = '{0}' OR YardCode = '{1}') AND `status` = 'ACTIVE'", txtAddress.Text, txtCode.Text, cbxBranch.SelectedValue))
                If Exist > 0 Then
                    MsgBox(String.Format("Either address ({0}) or yard code ({1}) already exist in Branch {2}, Please check your data.", txtAddress.Text, txtCode.Text, cbxBranch.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = ""
                If cbxDefault.Checked Then
                    SQL &= String.Format("UPDATE yard_setup SET `Default` = 0 WHERE BranchID = '{0}' AND `status` = 'ACTIVE';", cbxBranch.SelectedValue)
                End If
                SQL &= "INSERT INTO yard_setup SET"
                SQL &= String.Format(" BranchID = '{0}', ", cbxBranch.SelectedValue)
                SQL &= String.Format(" address = '{0}', ", txtAddress.Text)
                SQL &= String.Format(" `Default` = {0}, ", If(cbxDefault.Checked, 1, 0))
                SQL &= String.Format(" YardCode = '{0}',", txtCode.Text)
                SQL &= String.Format(" ContactNumber = '{0}',", txtContactNumber.Text)
                SQL &= String.Format(" user_id = '{0}'", User_ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Yard", "Save", String.Format("Add new yard for branch {1} located at {0}", txtAddress.Text, cbxBranch.Text), "", "", "", "")
                Clear(True)
                txtAddress.Focus()
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM yard_setup WHERE BranchID = '{2}' AND (address = '{0}' OR YardCode = '{1}') AND `status` = 'ACTIVE' AND ID != '{3}'", txtAddress.Text, txtCode.Text, cbxBranch.SelectedValue, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Either address ({0}) or yard code ({1}) already exist in Branch {2}, Please check your data.", txtAddress.Text, txtCode.Text, cbxBranch.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = ""
                If cbxDefault.Checked Then
                    SQL &= String.Format("UPDATE yard_setup SET `Default` = 0 WHERE BranchID = '{0}' AND `status` = 'ACTIVE';", cbxBranch.SelectedValue)
                End If
                SQL &= "UPDATE yard_setup SET"
                SQL &= String.Format(" address = '{0}', ", txtAddress.Text)
                SQL &= String.Format(" `Default` = {0}, ", If(cbxDefault.Checked, 1, 0))
                SQL &= String.Format(" YardCode = '{0}',", txtCode.Text)
                SQL &= String.Format(" ContactNumber = '{0}'", txtContactNumber.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Yard", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                txtAddress.Focus()
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtAddress.Text = txtAddress.Tag Then
            Else
                Change &= String.Format("Change Address from {0} to {1}. ", txtAddress.Tag, txtAddress.Text)
            End If
            If If(cbxDefault.Checked, "YES", "NO") = cbxDefault.Tag Then
            Else
                Change &= String.Format("Change Default from {0} to {1}. ", cbxDefault.Tag, If(cbxDefault.Checked, "YES", "NO"))
            End If
            If txtCode.Text = txtCode.Tag Then
            Else
                Change &= String.Format("Change Yard Code from {0} to {1}. ", txtCode.Tag, txtCode.Text)
            End If
            If txtContactNumber.Text = txtContactNumber.Tag Then
            Else
                Change &= String.Format("Change Contact Number from {0} to {1}. ", txtContactNumber.Tag, txtContactNumber.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Yard Setup - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE yard_setup SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Yard", "Cancel", Reason, String.Format("Cancel yard {0} located at {1}", cbxBranch.Text, txtAddress.Text), "", "", "")
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
        StandardPrinting("YARD LIST", GridControl1)
        Logs("Yard", "Print", "Print Yard List", "", "", "", "")
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
        Cursor = Cursors.WaitCursor
        PanelEx10.Enabled = False
        cbxBranch.Enabled = False
        With GridView1
            ID = .GetFocusedRowCellValue("ID")
            cbxBranch.SelectedValue = .GetFocusedRowCellValue("BranchID")
            txtAddress.Text = .GetFocusedRowCellValue("Address")
            txtAddress.Tag = .GetFocusedRowCellValue("Address")
            txtCode.Text = .GetFocusedRowCellValue("YardCode")
            txtCode.Tag = .GetFocusedRowCellValue("YardCode")
            txtContactNumber.Text = .GetFocusedRowCellValue("ContactNumber")
            txtContactNumber.Tag = .GetFocusedRowCellValue("ContactNumber")

            If .GetFocusedRowCellValue("Default") Then
                cbxDefault.Checked = True
            Else
                cbxDefault.Checked = False
            End If
            cbxDefault.Tag = If(.GetFocusedRowCellValue("Default"), "YES", "NO")
        End With

        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub
End Class