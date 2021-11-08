Public Class FrmBusinesCenter

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim Firstload As Boolean = True
    Private Sub FrmBusinesCenter_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        Firstload = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With cbxBranch
            .ValueMember = "ID"
            .DisplayMember = "Branch"
            Firstload = False
            .DataSource = DataSource("SELECT ID, Branch, Branch_Code FROM branch WHERE `status` = 'ACTIVE' ORDER BY BranchID;")
        End With
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2, LabelX5, LabelX6, LabelX3, LabelX33})

            GetLabelFontSettingsRed({LabelX34})

            GetDoubleInputFontSettings({dPettyCash})

            GetTextBoxFontSettings({txtBusinessCode, txtBusiness, txtAddress, txtContactN1})

            GetComboBoxFontSettings({cbxBranch})

            GetCheckBoxFontSettings({cbxNA})

            GetDateTimeInputFontSettings({dtpOpened})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnInactive, btnMap})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Business Center - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Business Center", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT "
        SQL &= "    ID, BranchID,"
        SQL &= "    (SELECT Branch FROM Branch WHERE ID = Business_Center.BranchID) AS 'Branch',"
        SQL &= "    BusinessCode AS 'Business Code',"
        SQL &= "    BusinessCenter AS 'Business Center',"
        SQL &= "    Address,"
        SQL &= "    ContactNumber AS 'Contact Number',"
        SQL &= " DATE_FORMAT(start_date,'%M %d, %Y') AS 'Date Opened', `Status`, Petty_Cash"
        SQL &= "    FROM business_center WHERE `status` IN ('ACTIVE','DELETED','INACTIVE') ORDER BY BranchID, BusinessCode;"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Branch").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Branch").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn4.Width = 226 - 17
        Else
            GridColumn4.Width = 226
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub GridView1_RowCellStyle(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles GridView1.RowCellStyle
        If GridView1.RowCount > 0 Then
            Dim View As DevExpress.XtraGrid.Views.Grid.GridView = sender
            Dim Status As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            If Status = "DELETED" Or Status = "INACTIVE" Then
                e.Appearance.ForeColor = OfficialColor2 'Color.Red
            End If
        End If
    End Sub

#Region "Keydown"
    Private Sub CbxCountry_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBusiness.Focus()
        End If
    End Sub

    Private Sub TxtBusiness_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBusiness.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAddress.Focus()
        End If
    End Sub

    Private Sub TxtAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContactN1.Focus()
        End If
    End Sub

    Private Sub TxtContactN1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContactN1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpOpened.Focus()
        End If
    End Sub

    Private Sub DtpOpened_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpOpened.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtRegion_Leave(sender As Object, e As EventArgs) Handles txtBusiness.Leave
        txtBusiness.Text = ReplaceText(txtBusiness.Text.Trim)
    End Sub

    Private Sub TxtAddress_Leave(sender As Object, e As EventArgs) Handles txtAddress.Leave
        txtAddress.Text = ReplaceText(txtAddress.Text.Trim)
    End Sub

    Private Sub TxtContactN1_Leave(sender As Object, e As EventArgs) Handles txtContactN1.Leave
        txtContactN1.Text = ReplaceText(txtContactN1.Text.Trim)
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
            btnInactive.Visible = True
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Clear(False)
            btnBack.Enabled = True
            btnAdd.Enabled = True
            btnSave.Enabled = False
            btnModify.Enabled = False
            btnPrint.Enabled = True
            btnDelete.Enabled = False
            btnNext.Enabled = False
            btnInactive.Enabled = False
            btnInactive.Visible = False
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
        Dim Ind As Integer = cbxBranch.SelectedIndex
        cbxBranch.SelectedIndex = -1
        cbxBranch.SelectedIndex = Ind
        PanelEx10.Enabled = True
        txtBusiness.Text = ""
        txtAddress.Text = ""
        txtContactN1.Text = ""
        dPettyCash.Value = 0
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        cbxBranch.Enabled = True
        btnInactive.Enabled = False

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

        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            MsgBox("Please select Branch.", MsgBoxStyle.Information, "Info")
            cbxBranch.DroppedDown = True
            Exit Sub
        End If
        If txtBusiness.Text = "" Then
            MsgBox("Please fill Region.", MsgBoxStyle.Information, "Info")
            txtBusiness.Focus()
            Exit Sub
        End If

        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM business_center WHERE BusinessCenter = '{0}' AND BranchID = '{1}' AND `status` = 'ACTIVE'", txtBusiness.Text, cbxBranch.SelectedValue))
                If Exist > 0 Then
                    MsgBox(String.Format("Business Center {0} already exist in Branch {1}, Please check your data.", txtBusiness.Text, cbxBranch.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO `business_center` SET"
                SQL &= String.Format(" BranchID = '{0}', ", cbxBranch.SelectedValue)
                SQL &= String.Format(" BusinessCode = '{0}', ", txtBusinessCode.Text)
                SQL &= String.Format(" BusinessCenter = '{0}', ", txtBusiness.Text)
                SQL &= String.Format(" Address = '{0}', ", txtAddress.Text)
                SQL &= String.Format(" start_date = '{0}', ", If(cbxNA.Checked, "", FormatDatePicker(dtpOpened)))
                SQL &= String.Format(" petty_cash = '{0}', ", dPettyCash.Value)
                SQL &= String.Format(" ContactNumber = '{0}';", txtContactN1.Text)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Business Center", "Save", String.Format("Add new Business Center {0} for Branch {1}", txtBusiness.Text, cbxBranch.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM business_center WHERE BusinessCenter = '{0}' AND BranchID = '{1}' AND `status` = 'ACTIVE' AND ID != '{2}'", txtBusiness.Text, cbxBranch.SelectedValue, ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Business Center {0} already exist in Branch {1}, Please check your data.", txtBusiness.Text, cbxBranch.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE business_center SET"
                SQL &= String.Format(" BusinessCenter = '{0}', ", txtBusiness.Text)
                SQL &= String.Format(" Address = '{0}', ", txtAddress.Text)
                SQL &= String.Format(" start_date = '{0}', ", If(cbxNA.Checked, "", FormatDatePicker(dtpOpened)))
                SQL &= String.Format(" petty_cash = '{0}', ", dPettyCash.Value)
                SQL &= String.Format(" ContactNumber = '{0}' ", txtContactN1.Text)
                SQL &= String.Format(" WHERE ID = '{0}'", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Business Center", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtBusiness.Text = txtBusiness.Tag Then
            Else
                Change &= String.Format("Change Business Center from {0} to {1}. ", txtBusiness.Tag, txtBusiness.Text)
            End If
            If txtAddress.Text = txtAddress.Tag Then
            Else
                Change &= String.Format("Change Address Center from {0} to {1}. ", txtAddress.Tag, txtAddress.Text)
            End If
            If txtContactN1.Text = txtContactN1.Tag Then
            Else
                Change &= String.Format("Change Contact Number from {0} to {1}. ", txtContactN1.Tag, txtContactN1.Text)
            End If
            If dtpOpened.Text = dtpOpened.Tag Then
            Else
                Change &= String.Format("Change Date Opened from {0} to {1}. ", dtpOpened.Tag, dtpOpened.Text)
            End If
            If dPettyCash.Value = dPettyCash.Tag Then
            Else
                Change &= String.Format("Change Petty Cash from {0} to {1}. ", dPettyCash.Tag, dPettyCash.Value)
            End If
        Catch ex As Exception
            TriggerBugReport("Business Center - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE business_center SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Business Center", "Cancel", Reason, String.Format("Cancel Business Center {0} for Branch {1}", txtBusiness.Text, cbxBranch.Tag), "", "", "")
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
        StandardPrinting("BUSINESS CENTER LIST", GridControl1)
        Logs("Business Center", "Print", "Print Business Center List", "", "", "", "")
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
            cbxBranch.Text = .GetFocusedRowCellValue("Branch")
            cbxBranch.Tag = .GetFocusedRowCellValue("Branch")
            txtBusinessCode.Text = .GetFocusedRowCellValue("Business Code")
            txtBusiness.Text = .GetFocusedRowCellValue("Business Center")
            txtBusiness.Tag = .GetFocusedRowCellValue("Business Center")
            txtAddress.Text = .GetFocusedRowCellValue("Address")
            txtAddress.Tag = .GetFocusedRowCellValue("Address")
            txtContactN1.Text = .GetFocusedRowCellValue("Contact Number")
            txtContactN1.Tag = .GetFocusedRowCellValue("Contact Number")
            dPettyCash.Text = .GetFocusedRowCellValue("Petty_Cash")
            dPettyCash.Tag = .GetFocusedRowCellValue("Petty_Cash")
            If .GetFocusedRowCellValue("Date Opened").ToString = "" Then
                cbxNA.Checked = True
            Else
                cbxNA.Checked = False
                dtpOpened.Value = .GetFocusedRowCellValue("Date Opened").ToString
            End If
            dtpOpened.Tag = .GetFocusedRowCellValue("Date Opened").ToString
            SuperTabControl1.SelectedTab = tabSetup
            btnModify.Enabled = True
            btnSave.Enabled = False
            If .GetFocusedRowCellValue("Status") = "ACTIVE" Then
                btnInactive.Enabled = True
                btnInactive.Text = "Inactive"
            ElseIf .GetFocusedRowCellValue("Status") = "INACTIVE" Then
                btnInactive.Enabled = True
                btnInactive.Text = "Active"
                btnModify.Enabled = False
            Else
                btnModify.Enabled = False
                btnInactive.Enabled = False
            End If
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Clear(False)
        SuperTabControl1.SelectedTab = tabSetup
    End Sub

    Private Sub CbxBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxBranch.SelectedIndexChanged
        If Firstload Then
            Exit Sub
        End If

        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            txtBusinessCode.Text = ""
        Else
            Dim drv As DataRowView = DirectCast(cbxBranch.SelectedItem, DataRowView)
            txtBusinessCode.Text = drv("Branch_Code") & "-" & CInt(DataObject(String.Format("SELECT COUNT(ID) + 1 FROM business_center WHERE BranchID = '{0}';", cbxBranch.SelectedValue))).ToString("D2")
        End If
    End Sub

    Private Sub CbxBranch_TextChanged(sender As Object, e As EventArgs) Handles cbxBranch.TextChanged
        If cbxBranch.SelectedIndex = -1 Or cbxBranch.Text = "" Then
            txtBusinessCode.Text = ""
        End If
    End Sub

    Private Sub BtnInactive_Click(sender As Object, e As EventArgs) Handles btnInactive.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If btnInactive.Text = "Inactive" Then
            If MsgBoxYes("Are you sure you want to set this Business Center as Inactive?") = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                DataObject(String.Format("UPDATE business_center SET `status` = 'INACTIVE' WHERE ID = '{0}'", ID))
                Logs("Business Center", "Inactive", Reason, String.Format("Inactive Business Center {0} for Branch {1}", txtBusiness.Text, cbxBranch.Tag), "", "", "")
                Clear(True)
                MsgBox("Successfully set as Inactive", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes("Are you sure you want to set this Business Center as Active?") = MsgBoxResult.Yes Then
                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                DataObject(String.Format("UPDATE business_center SET `status` = 'ACTIVE' WHERE ID = '{0}'", ID))
                Logs("Business Center", "Active", Reason, String.Format("Active Business Center {0} for Branch {1}", txtBusiness.Text, cbxBranch.Tag), "", "", "")
                Clear(True)
                MsgBox("Successfully set as Active", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Sub BtnMap_Click(sender As Object, e As EventArgs) Handles btnMap.Click
        If SuperTabControl1.SelectedTabIndex = 0 Then
            Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", txtAddress.Text.Replace(" ", "+").Replace("#", "")))
        ElseIf SuperTabControl1.SelectedTabIndex = 1 Then
            Process.Start(String.Format("https://www.google.com.ph/maps/place/{0}", GridView1.GetFocusedRowCellValue("Address").ToString.Replace(" ", "+").Replace("#", "")))
        End If
    End Sub

    Private Sub CbxNA_CheckedChanged(sender As Object, e As EventArgs) Handles cbxNA.CheckedChanged
        If cbxNA.Checked Then
            dtpOpened.Enabled = False
            dtpOpened.CustomFormat = ""
            dtpOpened.Text = ""
        Else
            dtpOpened.Enabled = True
            dtpOpened.CustomFormat = "MMMM dd, yyyy"
            dtpOpened.Value = Date.Now
        End If
    End Sub
End Class