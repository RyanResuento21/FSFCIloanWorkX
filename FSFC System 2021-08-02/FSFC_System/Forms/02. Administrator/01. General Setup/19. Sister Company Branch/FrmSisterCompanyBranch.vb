Public Class FrmSisterCompanyBranch

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim Firstload As Boolean
    Private Sub FrmSisterCompanyBranch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        Firstload = True
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        SuperTabControl1.SelectedTab = tabList

        With cbxSisterCompany
            .ValueMember = "ID"
            .DisplayMember = "company"
            .DataSource = DataSource("SELECT ID, company_code, company FROM company WHERE `status` = 'ACTIVE' AND ID > 1 ORDER BY Company;")
            .SelectedIndex = -1
        End With

        With cbxAddress
            .ValueMember = "City ID"
            .DisplayMember = "City_F"
            .DataSource = DataSource("SELECT C.citymunCode AS 'City ID', C.citymunDesc AS 'City', P.provDesc AS 'Province', CN.country AS 'Country', IFNULL(C.zipcode,'') AS 'ZipCode', CONCAT(citymunDesc, ', ', provDesc) AS 'City_F' FROM city_municipality C LEFT JOIN (SELECT provCode, provDesc FROM province WHERE `status` = 'ACTIVE') P ON P.provCode = C.provCode LEFT JOIN (SELECT regCode, regDesc FROM region WHERE `status` = 'ACTIVE') R ON R.regCode = C.regDesc LEFT JOIN (SELECT ID, iso, country FROM country WHERE `status` = 'ACTIVE') CN ON CN.ID = C.countryID WHERE C.status = 'ACTIVE';")
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

            GetLabelFontSettings({LabelX3, LabelX155, LabelX1, LabelX2, LabelX6, LabelX7, LabelX9})

            GetTextBoxFontSettings({txtBranch, txtBranchCode, txtNo, txtStreet, txtBarangay, txtTelephone, txtFax, txtEmailAddress})

            GetComboBoxFontSettings({cbxSisterCompany, cbxAddress})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Sister Company Branch - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Sister Company Branch", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID, "
        SQL &= " SisterID, (SELECT Company FROM company WHERE ID = SisterID) AS 'Company', "
        SQL &= " Branch, "
        SQL &= " Branch_code AS 'Branch Code', "
        SQL &= " CONCAT(IF(`No` = '','',CONCAT(`No`, ', ')), IF(Street = '','',CONCAT(Street, ', ')), IF(Brgy = '','',CONCAT(Brgy, ', ')), IF(City = '','',CONCAT(City, ', ')), IF(Province = '','',Province), '') AS 'Address', "
        SQL &= " CONCAT(IF(City = '','',CONCAT(City, ', ')), IF(Province = '','',Province), '') AS 'AddressV2', "
        SQL &= " `No`, Street, Brgy, City, Province, Country, ZipCode, Telephone, Fax, Email_Address AS 'Email Address'"
        SQL &= " FROM sister_company WHERE `status` = 'ACTIVE' ORDER BY `Company`, `Branch`;"
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Company").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Company").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

#Region "Keycode"
    Private Sub CbxSisterCompany_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSisterCompany.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBranch.Focus()
        End If
    End Sub

    Private Sub TxtBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranch.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBranchCode.Focus()
        End If
    End Sub

    Private Sub TxtCompanyCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranchCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNo.Focus()
        End If
    End Sub

    Private Sub TxtNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreet.Focus()
        End If
    End Sub

    Private Sub TxtStreet_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreet.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangay.Focus()
        End If
    End Sub

    Private Sub TxtBarangay_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangay.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddress.Focus()
        End If
    End Sub

    Private Sub CbxAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTelephone.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephone.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFax.Focus()
        End If
    End Sub

    Private Sub TxtFax_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFax.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmailAddress.Focus()
        End If
    End Sub

    Private Sub TxtEmailAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmailAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtCompany_Leave(sender As Object, e As EventArgs) Handles txtBranch.Leave
        txtBranch.Text = ReplaceText(txtBranch.Text)
    End Sub

    Private Sub TxtCompanyCode_Leave(sender As Object, e As EventArgs) Handles txtBranchCode.Leave
        txtBranchCode.Text = ReplaceText(txtBranchCode.Text)
    End Sub

    Private Sub TxtNo_Leave(sender As Object, e As EventArgs) Handles txtNo.Leave
        txtNo.Text = ReplaceText(txtNo.Text)
    End Sub

    Private Sub TxtStreet_Leave(sender As Object, e As EventArgs) Handles txtStreet.Leave
        txtStreet.Text = ReplaceText(txtStreet.Text)
    End Sub

    Private Sub TxtBarangay_Leave(sender As Object, e As EventArgs) Handles txtBarangay.Leave
        txtBarangay.Text = ReplaceText(txtBarangay.Text)
    End Sub

    Private Sub CbxAddress_Leave(sender As Object, e As EventArgs) Handles cbxAddress.Leave
        cbxAddress.Text = ReplaceText(cbxAddress.Text)
    End Sub

    Private Sub TxtTelephone_Leave(sender As Object, e As EventArgs) Handles txtTelephone.Leave
        txtTelephone.Text = ReplaceText(txtTelephone.Text)
    End Sub

    Private Sub TxtFax_Leave(sender As Object, e As EventArgs) Handles txtFax.Leave
        txtFax.Text = ReplaceText(txtFax.Text)
    End Sub

    Private Sub TxtEmailAddress_Leave(sender As Object, e As EventArgs) Handles txtEmailAddress.Leave
        txtEmailAddress.Text = ReplaceText(txtEmailAddress.Text)
    End Sub
#End Region

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
            SuperTabControl1.SelectedTab = tabBranch
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
        btnSave.Text = "&Save"
        btnSave.Enabled = True
        btnModify.Enabled = False
        btnDelete.Enabled = False
        cbxSisterCompany.Enabled = True
        cbxSisterCompany.SelectedIndex = -1
        txtBranch.Text = ""
        txtBranchCode.Text = ""
        txtNo.Text = ""
        txtStreet.Text = ""
        txtBarangay.Text = ""
        cbxAddress.Text = ""
        txtTelephone.Text = ""
        txtFax.Text = ""
        txtEmailAddress.Text = ""

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

        If cbxSisterCompany.Text = "" Or cbxSisterCompany.SelectedIndex = -1 Then
            MsgBox("Please selected sister company.", MsgBoxStyle.Information, "Info")
            cbxSisterCompany.DroppedDown = True
            Exit Sub
        End If
        If txtBranch.Text = "" Then
            MsgBox("Please fill company field.", MsgBoxStyle.Information, "Info")
            txtBranch.Focus()
            Exit Sub
        End If
        If txtBranchCode.Text = "" Then
            MsgBox("Please fill company code field.", MsgBoxStyle.Information, "Info")
            txtBranchCode.Focus()
            Exit Sub
        End If
        If cbxAddress.Text = "" Or cbxAddress.SelectedIndex = -1 Then
            MsgBox("Please select company address.", MsgBoxStyle.Information, "Info")
            cbxAddress.DroppedDown = True
            Exit Sub
        End If

        Dim drv_A As DataRowView = DirectCast(cbxAddress.SelectedItem, DataRowView)
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM sister_company WHERE (branch = '{0}' OR branch_code = '{1}') AND `status` = 'ACTIVE' AND SisterID = '{2}';", txtBranch.Text, txtBranchCode.Text, cbxSisterCompany.SelectedValue))
                If Exist > 0 Then
                    If MsgBoxYes(String.Format("Either branch name ({0}) or branch code ({1}) already exist on company {2}, Would you like to proceed? By clicking 'YES' this could result to a duplicate company name or company code.", txtBranch.Text, txtBranchCode.Text, cbxSisterCompany.Text)) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO sister_company SET"
                SQL &= String.Format(" SisterID = '{0}', ", cbxSisterCompany.SelectedValue)
                SQL &= String.Format(" branch = '{0}', ", txtBranch.Text)
                SQL &= String.Format(" branch_code = '{0}', ", txtBranchCode.Text)
                SQL &= String.Format(" `No` = '{0}', ", txtNo.Text)
                SQL &= String.Format(" street = '{0}', ", txtStreet.Text)
                SQL &= String.Format(" brgy = '{0}', ", txtBarangay.Text)
                SQL &= String.Format(" city = '{0}', ", UpperCaseFirst(drv_A("City")))
                SQL &= String.Format(" province = '{0}', ", UpperCaseFirst(drv_A("Province")))
                SQL &= String.Format(" country = '{0}', ", UpperCaseFirst(drv_A("Country")))
                SQL &= String.Format(" zipcode = '{0}', ", UpperCaseFirst(drv_A("ZipCode")))
                SQL &= String.Format(" telephone = '{0}', ", txtTelephone.Text)
                SQL &= String.Format(" fax = '{0}', ", txtFax.Text)
                SQL &= String.Format(" email_address = '{0}' ", txtEmailAddress.Text)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Sister Company Branch", "Save", String.Format("Add new branch {1} for company {0}", cbxSisterCompany.Text, txtBranch.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM sister_company WHERE (branch = '{0}' OR branch_code = '{1}') AND `status` = 'ACTIVE' AND SisterID = '{2}' AND ID != '{3}';", txtBranch.Text, txtBranchCode.Text, cbxSisterCompany.SelectedValue, ID))
                If Exist > 0 Then
                    If MsgBoxYes(String.Format("Either branch name ({0}) or branch code ({1}) already exist on company {2}, Would you like to proceed? By clicking 'YES' this could result to a duplicate company name or company code.", txtBranch.Text, txtBranchCode.Text, cbxSisterCompany.Text)) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Dim Reason As String 'Reason for change
                If FrmReason.ShowDialog = DialogResult.OK Then
                    Reason = FrmReason.txtReason.Text
                Else
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE sister_company SET"
                SQL &= String.Format(" branch = '{0}', ", txtBranch.Text)
                SQL &= String.Format(" branch_code = '{0}', ", txtBranchCode.Text)
                SQL &= String.Format(" `No` = '{0}', ", txtNo.Text)
                SQL &= String.Format(" street = '{0}', ", txtStreet.Text)
                SQL &= String.Format(" brgy = '{0}', ", txtBarangay.Text)
                SQL &= String.Format(" city = '{0}', ", UpperCaseFirst(drv_A("City")))
                SQL &= String.Format(" province = '{0}', ", UpperCaseFirst(drv_A("Province")))
                SQL &= String.Format(" country = '{0}', ", UpperCaseFirst(drv_A("Country")))
                SQL &= String.Format(" zipcode = '{0}', ", UpperCaseFirst(drv_A("ZipCode")))
                SQL &= String.Format(" telephone = '{0}', ", txtTelephone.Text)
                SQL &= String.Format(" fax = '{0}', ", txtFax.Text)
                SQL &= String.Format(" email_address = '{0}' ", txtEmailAddress.Text)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                Logs("Sister Company Branch", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtBranch.Text = txtBranch.Tag Then
            Else
                Change &= String.Format("Change Company from {0} to {1}. ", txtBranch.Tag, txtBranch.Text)
            End If
            If txtBranchCode.Text = txtBranchCode.Tag Then
            Else
                Change &= String.Format("Change Company Code from {0} to {1}. ", txtBranchCode.Tag, txtBranchCode.Text)
            End If
            If txtNo.Text = txtNo.Tag Then
            Else
                Change &= String.Format("Change Address No from {0} to {1}. ", txtNo.Tag, txtNo.Text)
            End If
            If txtStreet.Text = txtStreet.Tag Then
            Else
                Change &= String.Format("Change Address Street from {0} to {1}. ", txtStreet.Tag, txtStreet.Text)
            End If
            If txtBarangay.Text = txtBarangay.Tag Then
            Else
                Change &= String.Format("Change Address Barangay from {0} to {1}. ", txtBarangay.Tag, txtBarangay.Text)
            End If
            If cbxAddress.Text = cbxAddress.Tag Then
            Else
                Change &= String.Format("Change Address from {0} to {1}. ", cbxAddress.Tag, cbxAddress.Text)
            End If
            If txtTelephone.Text = txtTelephone.Tag Then
            Else
                Change &= String.Format("Change Telephone from {0} to {1}. ", txtTelephone.Tag, txtTelephone.Text)
            End If
            If txtFax.Text = txtFax.Tag Then
            Else
                Change &= String.Format("Change Fax from {0} to {1}. ", txtFax.Tag, txtFax.Text)
            End If
            If txtEmailAddress.Text = txtEmailAddress.Tag Then
            Else
                Change &= String.Format("Change Email from {0} to {1}. ", txtEmailAddress.Tag, txtEmailAddress.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Sister Company Branch - Changes", ex.Message.ToString)
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
            DataObject(String.Format("UPDATE sister_company SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
            Logs("Sister Company Branch", "Cancel", Reason, String.Format("Cancel Sister Company Branch {0} for Company {1}", txtBranch.Text, cbxSisterCompany.Text), "", "", "")
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
        StandardPrinting("SISTER COMPANY BRANCH LIST", GridControl1)
        Logs("Official Receipt", "Print", "[SENSITIVE] Print Official Receipt List", "", "", "", "")
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
        SuperTabControl1.SelectedTab = tabBranch
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
            cbxSisterCompany.Enabled = False
            cbxSisterCompany.SelectedValue = .GetFocusedRowCellValue("SisterID")
            txtBranch.Text = .GetFocusedRowCellValue("Branch")
            txtBranch.Tag = .GetFocusedRowCellValue("Branch")
            txtBranchCode.Text = .GetFocusedRowCellValue("Branch Code")
            txtBranchCode.Tag = .GetFocusedRowCellValue("Branch Code")
            txtNo.Text = .GetFocusedRowCellValue("No")
            txtNo.Tag = .GetFocusedRowCellValue("No")
            txtStreet.Text = .GetFocusedRowCellValue("Street")
            txtStreet.Tag = .GetFocusedRowCellValue("Street")
            txtBarangay.Text = .GetFocusedRowCellValue("Brgy")
            txtBarangay.Tag = .GetFocusedRowCellValue("Brgy")
            cbxAddress.Text = .GetFocusedRowCellValue("AddressV2")
            cbxAddress.Tag = .GetFocusedRowCellValue("AddressV2")
            txtTelephone.Text = .GetFocusedRowCellValue("Telephone")
            txtTelephone.Tag = .GetFocusedRowCellValue("Telephone")
            txtFax.Text = .GetFocusedRowCellValue("Fax")
            txtFax.Tag = .GetFocusedRowCellValue("Fax")
            txtEmailAddress.Text = .GetFocusedRowCellValue("Email Address")
            txtEmailAddress.Tag = .GetFocusedRowCellValue("Email Address")
        End With

        SuperTabControl1.SelectedTab = tabBranch
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub
End Class