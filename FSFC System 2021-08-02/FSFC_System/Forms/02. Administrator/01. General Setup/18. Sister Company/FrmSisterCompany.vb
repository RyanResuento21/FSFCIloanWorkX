Imports System.Drawing.Imaging
Public Class FrmSisterCompany

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    ReadOnly DefaultImage As New DevExpress.XtraEditors.PictureEdit
    Dim FileName As String
    Public picturePath As String = ""
    Private Sub FrmSisterCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_Logo.Size = New Point(461, 284)
        pb_Logo.Location = New Point(691, 16)
        cpb1.Location = New Point(165, 404)
        cpb2.Location = New Point(165, 433)
        DefaultImage.Image = pb_Logo.Image.Clone
        SuperTabControl1.SelectedTab = tabList

        Dim installedFonts As New Text.InstalledFontCollection
        Dim fontFamilies = installedFonts.Families()
        For Each FF As FontFamily In fontFamilies
            cbxFont.Items.Add(FF.Name)
        Next

        With cbxAddress
            .ValueMember = "City ID"
            .DisplayMember = "City_F"
            .DataSource = DataSource("SELECT C.citymunCode AS 'City ID', C.citymunDesc AS 'City', P.provDesc AS 'Province', CN.country AS 'Country', IFNULL(C.zipcode,'') AS 'ZipCode', CONCAT(citymunDesc, ', ', provDesc) AS 'City_F' FROM city_municipality C LEFT JOIN (SELECT provCode, provDesc FROM province WHERE `status` = 'ACTIVE') P ON P.provCode = C.provCode LEFT JOIN (SELECT regCode, regDesc FROM region WHERE `status` = 'ACTIVE') R ON R.regCode = C.regDesc LEFT JOIN (SELECT ID, iso, country FROM country WHERE `status` = 'ACTIVE') CN ON CN.ID = C.countryID WHERE C.status = 'ACTIVE';")
            .SelectedIndex = -1
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

            GetLabelFontSettings({LabelX155, LabelX1, LabelX2, LabelX6, LabelX7, LabelX9, LabelX8, LabelX13, LabelX14, LabelX12, LabelX82, LabelX11, LabelX5, LabelX3, LabelX10, LabelX4})

            GetTextBoxFontSettings({txtCompany, txtCompanyCode, txtNo, txtStreet, txtBarangay, txtTelephone, txtFax, txtEmailAddress, txtWebsite, txtPath, txtSupport, txtCommittee})

            GetComboBoxFontSettings({cbxAddress})

            GetComboBoxWinFormFontSettings({cbxFont})

            GetDoubleInputFontSettings({dFSize, dFSizeGrid})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnBrowse})

            GetTabControlFontSettings({SuperTabControl1})
        Catch ex As Exception
            TriggerBugReport("Sister Company - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Company", lblTitle.Text)
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT ID, "
        SQL &= " Company, "
        SQL &= " Company_code AS 'Company Code', "
        SQL &= " CONCAT(IF(`No` = '','',CONCAT(`No`, ', ')), IF(Street = '','',CONCAT(Street, ', ')), IF(Brgy = '','',CONCAT(Brgy, ', ')), IF(City = '','',CONCAT(City, ', ')), IF(Province = '','',Province), '') AS 'Address', "
        SQL &= " CONCAT(IF(City = '','',CONCAT(City, ', ')), IF(Province = '','',Province), '') AS 'AddressV2', "
        SQL &= " `No`, Street, Brgy, City, Province, Country, ZipCode, Telephone, Fax, Email_Address AS 'Email Address' , Website, ASG_Email, CredCommEmail, OfficialFont, FontSize, FontSizeGrid, Color1, Color2"
        SQL &= String.Format(" FROM company WHERE `status` = 'ACTIVE' AND IF({0},TRUE,ID > 1) ORDER BY Company;", User_Type = "ADMIN")
        GridControl1.DataSource = DataSource(SQL)
        GridView1.Columns("Company").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Company").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"
        Cursor = Cursors.Default
    End Sub

#Region "Keycode"
    Private Sub TxtCompany_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCompany.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCompanyCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCompanyCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtNo_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtStreet_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreet.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtBarangay_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangay.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub CbxAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtTelephone_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephone.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtFax_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFax.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtEmailAddress_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmailAddress.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtWebsite_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWebsite.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtSupport_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSupport.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub TxtCommittee_KeyDown(sender As Object, e As KeyEventArgs) Handles txtCommittee.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DFSize_KeyDown(sender As Object, e As KeyEventArgs) Handles dFSize.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub DFSizeGrid_KeyDown(sender As Object, e As KeyEventArgs) Handles dFSizeGrid.KeyDown
        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub TxtCompany_Leave(sender As Object, e As EventArgs) Handles txtCompany.Leave
        txtCompany.Text = ReplaceText(txtCompany.Text)
    End Sub

    Private Sub TxtCompanyCode_Leave(sender As Object, e As EventArgs) Handles txtCompanyCode.Leave
        txtCompanyCode.Text = ReplaceText(txtCompanyCode.Text)
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

    Private Sub TxtWebsite_Leave(sender As Object, e As EventArgs) Handles txtWebsite.Leave
        txtWebsite.Text = ReplaceText(txtWebsite.Text)
    End Sub

    Private Sub TxtSupport_Leave(sender As Object, e As EventArgs) Handles txtSupport.Leave
        txtSupport.Text = ReplaceText(txtSupport.Text)
    End Sub

    Private Sub TxtCommittee_Leave(sender As Object, e As EventArgs) Handles txtCommittee.Leave
        txtCommittee.Text = ReplaceText(txtCommittee.Text)
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
        txtCompany.Text = ""
        txtCompanyCode.Text = ""
        txtNo.Text = ""
        txtStreet.Text = ""
        txtBarangay.Text = ""
        cbxAddress.Text = ""
        txtTelephone.Text = ""
        txtFax.Text = ""
        txtEmailAddress.Text = ""
        txtWebsite.Text = ""
        txtPath.Text = ""
        pb_Logo.Image = DefaultImage.Image.Clone

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

        If txtCompany.Text = "" Then
            MsgBox("Please fill company field.", MsgBoxStyle.Information, "Info")
            txtCompany.Focus()
            Exit Sub
        End If
        If txtCompanyCode.Text = "" Then
            MsgBox("Please fill company code field.", MsgBoxStyle.Information, "Info")
            txtCompanyCode.Focus()
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
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM company WHERE (company = '{0}' OR company_code = '{1}') AND `status` = 'ACTIVE'", txtCompany.Text, txtCompanyCode.Text))
                If Exist > 0 Then
                    If MsgBoxYes(String.Format("Either company name ({0}) or company code ({1}) already exist, Would you like to proceed? By clicking 'YES' this could result to a duplicate company name or company code.", txtCompany.Text, txtCompanyCode.Text)) = MsgBoxResult.No Then
                        Exit Sub
                    End If
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "INSERT INTO company SET"
                SQL &= String.Format(" company = '{0}', ", txtCompany.Text)
                SQL &= String.Format(" company_code = '{0}', ", txtCompanyCode.Text)
                SQL &= String.Format(" `No` = '{0}', ", txtNo.Text)
                SQL &= String.Format(" street = '{0}', ", txtStreet.Text)
                SQL &= String.Format(" brgy = '{0}', ", txtBarangay.Text)
                SQL &= String.Format(" city = '{0}', ", UpperCaseFirst(drv_A("City")))
                SQL &= String.Format(" province = '{0}', ", UpperCaseFirst(drv_A("Province")))
                SQL &= String.Format(" country = '{0}', ", UpperCaseFirst(drv_A("Country")))
                SQL &= String.Format(" zipcode = '{0}', ", UpperCaseFirst(drv_A("ZipCode")))
                SQL &= String.Format(" telephone = '{0}', ", txtTelephone.Text)
                SQL &= String.Format(" ASG_Email = '{0}', ", txtSupport.Text)
                SQL &= String.Format(" CredCommEmail = '{0}', ", txtCommittee.Text)
                SQL &= String.Format(" OfficialFont = '{0}', ", cbxFont.Text)
                SQL &= String.Format(" FontSize = '{0}', ", dFSize.Value)
                SQL &= String.Format(" FontSizeGrid = '{0}', ", dFSizeGrid.Value)
                SQL &= String.Format(" Color1 = '{0}', ", cpb1.SelectedColor.R & "," & cpb1.SelectedColor.G & "," & cpb1.SelectedColor.B)
                SQL &= String.Format(" Color2 = '{0}', ", cpb2.SelectedColor.R & "," & cpb2.SelectedColor.G & "," & cpb2.SelectedColor.B)
                SQL &= String.Format(" fax = '{0}', ", txtFax.Text)
                SQL &= String.Format(" email_address = '{0}', ", txtEmailAddress.Text)
                SQL &= String.Format(" website = '{0}' ", txtWebsite.Text)
                DataObject(SQL)
                Cursor = Cursors.Default

                SaveImage("Location")
                Logs("Company", "Save", String.Format("Add new company {0}", txtCompany.Text), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM company WHERE (company = '{0}' OR company_code = '{1}') AND `status` = 'ACTIVE' AND ID != '{2}';", txtCompany.Text, txtCompanyCode.Text, ID))
                If Exist > 0 Then
                    If MsgBoxYes(String.Format("Either company name ({0}) or company code ({1}) already exist, Would you like to proceed? By clicking 'YES' this could result to a duplicate company name or company code.", txtCompany.Text, txtCompanyCode.Text)) = MsgBoxResult.No Then
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
                Dim SQL As String = "UPDATE company SET"
                SQL &= String.Format(" company = '{0}', ", txtCompany.Text)
                SQL &= String.Format(" company_code = '{0}', ", txtCompanyCode.Text)
                SQL &= String.Format(" `No` = '{0}', ", txtNo.Text)
                SQL &= String.Format(" street = '{0}', ", txtStreet.Text)
                SQL &= String.Format(" brgy = '{0}', ", txtBarangay.Text)
                SQL &= String.Format(" city = '{0}', ", UpperCaseFirst(drv_A("City")))
                SQL &= String.Format(" province = '{0}', ", UpperCaseFirst(drv_A("Province")))
                SQL &= String.Format(" country = '{0}', ", UpperCaseFirst(drv_A("Country")))
                SQL &= String.Format(" zipcode = '{0}', ", UpperCaseFirst(drv_A("ZipCode")))
                SQL &= String.Format(" telephone = '{0}', ", txtTelephone.Text)
                SQL &= String.Format(" ASG_Email = '{0}', ", txtSupport.Text)
                SQL &= String.Format(" CredCommEmail = '{0}', ", txtCommittee.Text)
                SQL &= String.Format(" OfficialFont = '{0}', ", cbxFont.Text)
                SQL &= String.Format(" FontSize = '{0}', ", dFSize.Value)
                SQL &= String.Format(" FontSizeGrid = '{0}', ", dFSizeGrid.Value)
                SQL &= String.Format(" Color1 = '{0}', ", cpb1.SelectedColor.R & "," & cpb1.SelectedColor.G & "," & cpb1.SelectedColor.B)
                SQL &= String.Format(" Color2 = '{0}', ", cpb2.SelectedColor.R & "," & cpb2.SelectedColor.G & "," & cpb2.SelectedColor.B)
                SQL &= String.Format(" fax = '{0}', ", txtFax.Text)
                SQL &= String.Format(" email_address = '{0}', ", txtEmailAddress.Text)
                SQL &= String.Format(" website = '{0}' ", txtWebsite.Text)
                SQL &= String.Format(" WHERE ID = '{0}';", ID)
                DataObject(SQL)
                Cursor = Cursors.Default

                SaveImage("Location")
                Logs("Company", "Update", Reason, Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtCompany.Text = txtCompany.Tag Then
            Else
                Change &= String.Format("Change Company from {0} to {1}. ", txtCompany.Tag, txtCompany.Text)
            End If
            If txtCompanyCode.Text = txtCompanyCode.Tag Then
            Else
                Change &= String.Format("Change Company Code from {0} to {1}. ", txtCompanyCode.Tag, txtCompanyCode.Text)
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
            If txtWebsite.Text = txtWebsite.Tag Then
            Else
                Change &= String.Format("Change Website from {0} to {1}. ", txtWebsite.Tag, txtWebsite.Text)
            End If
            If txtSupport.Text = txtSupport.Tag Then
            Else
                Change &= String.Format("Change Support Email from {0} to {1}. ", txtSupport.Tag, txtSupport.Text)
            End If
            If txtCommittee.Text = txtCommittee.Tag Then
            Else
                Change &= String.Format("Change Committee Email from {0} to {1}. ", txtCommittee.Tag, txtCommittee.Text)
            End If
            If cbxFont.Text = cbxFont.Tag Then
            Else
                Change &= String.Format("Change Font from {0} to {1}. ", cbxFont.Tag, cbxFont.Text)
            End If
            If dFSize.Text = dFSize.Tag Then
            Else
                Change &= String.Format("Change Font Size from {0} to {1}. ", dFSize.Tag, dFSize.Text)
            End If
            If dFSizeGrid.Text = dFSizeGrid.Tag Then
            Else
                Change &= String.Format("Change Font Size for Grid from {0} to {1}. ", dFSizeGrid.Tag, dFSizeGrid.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Sister Company - Changes", ex.Message.ToString)
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
            If User_Type = "ADMIN" Then
                btnDelete.Enabled = True
            End If

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

            Dim PW As New FrmPassword
            With PW
                .ShowMessage = False
                .lblNote.Text = "*For IT Password only."
                If .ShowDialog = DialogResult.OK Then
                    If IT_PW = DataObject(String.Format("SELECT MD5(SHA1('{0}'))", .txtPassword.Text)) Then
                        Cursor = Cursors.WaitCursor
                        DataObject(String.Format("UPDATE company SET `status` = 'DELETED' WHERE ID = '{0}'", ID))
                        Logs("Company", "Cancel", Reason, String.Format("Cancel Company {0}", txtCompany.Text), "", "", "")
                        Clear(True)
                        Cursor = Cursors.Default
                        MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
                    Else
                        MsgBox("Incorrect Password!", MsgBoxStyle.Information, "Info")
                    End If
                End If
                .Dispose()
            End With
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
        StandardPrinting("COMPANY LIST", GridControl1)
        Logs("Company", "Print", "[SENSITIVE] Print Company List", "", "", "", "")
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    pb_Logo.Image.Dispose()
                    txtPath.Text = OFD.FileName
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(txtPath.Text)
                        ResizeImages(TempPB.Image.Clone, pb_Logo, 650, 500)
                    End Using
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
    End Sub

    Private Sub Pb_Logo_Click(sender As Object, e As MouseEventArgs) Handles pb_Logo.Click
        Try
            If e.Button = Windows.Forms.MouseButtons.Left Then
                btnBrowse.PerformClick()
            End If
        Catch ex As Exception
            TriggerBugReport("Sister Company - Logo Click", ex.Message.ToString)
        End Try
    End Sub

    Public Sub SaveImage(Description As String)
        'Exit Sub
        If UCase(_ServerName) = "LOCALHOST" Then
            FileName = Description & ".jpg"

            '********CREATE FOLDER FSFC System
            If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
            End If
            '********CREATE FOLDER Branch
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, txtCompanyCode.Text.Trim)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, txtCompanyCode.Text.Trim))
            End If
            '********CREATE FOLDER Location
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Logo", RootFolder, MainFolder, txtCompanyCode.Text.Trim)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Logo", RootFolder, MainFolder, txtCompanyCode.Text.Trim))
            End If
            '********CREATE File
            Try
                pb_Logo.Image.Save(String.Format("{0}\{1}\{2}\Logo\{3}", RootFolder, MainFolder, txtCompanyCode.Text.Trim, FileName), ImageFormat.Jpeg)
            Catch
            End Try
        Else
            FileName = Description & ".jpg"
            '********CREATE FOLDER FSFC System
            If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
            End If
            '********CREATE FOLDER Branch
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, txtCompanyCode.Text.Trim)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, txtCompanyCode.Text.Trim))
            End If
            '********CREATE FOLDER Location
            If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Logo", RootFolder, MainFolder, txtCompanyCode.Text.Trim)) Then
                IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Logo", RootFolder, MainFolder, txtCompanyCode.Text.Trim))
            End If
            '********CREATE File
            Try
                pb_Logo.Image.Save(String.Format("{0}\{1}\{2}\Logo\{3}", RootFolder, MainFolder, txtCompanyCode.Text.Trim, FileName), ImageFormat.Jpeg)
            Catch
            End Try
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
            txtCompany.Text = .GetFocusedRowCellValue("Company")
            txtCompany.Tag = .GetFocusedRowCellValue("Company")
            txtCompanyCode.Text = .GetFocusedRowCellValue("Company Code")
            txtCompanyCode.Tag = .GetFocusedRowCellValue("Company Code")
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
            txtWebsite.Text = .GetFocusedRowCellValue("Website")
            txtWebsite.Tag = .GetFocusedRowCellValue("Website")
            txtSupport.Text = .GetFocusedRowCellValue("ASG_Email")
            txtSupport.Tag = .GetFocusedRowCellValue("ASG_Email")
            txtCommittee.Text = .GetFocusedRowCellValue("CredCommEmail")
            txtCommittee.Tag = .GetFocusedRowCellValue("CredCommEmail")
            cbxFont.Text = .GetFocusedRowCellValue("OfficialFont")
            cbxFont.Tag = .GetFocusedRowCellValue("OfficialFont")
            dFSize.Value = .GetFocusedRowCellValue("FontSize")
            dFSize.Tag = .GetFocusedRowCellValue("FontSize")
            dFSizeGrid.Value = .GetFocusedRowCellValue("FontSizeGrid")
            dFSizeGrid.Tag = .GetFocusedRowCellValue("FontSizeGrid")
            Dim RGB As String()
            If .GetFocusedRowCellValue("Color1") <> "" Then
                RGB = .GetFocusedRowCellValue("Color1").ToString.Split(New Char() {","c})
                cpb1.SelectedColor = Color.FromArgb(RGB(0), RGB(1), RGB(2))
            Else
                cpb1.SelectedColor = Color.FromArgb(0, 0, 0)
            End If
            If .GetFocusedRowCellValue("Color2") <> "" Then
                RGB = .GetFocusedRowCellValue("Color2").ToString.Split(New Char() {","c})
                cpb2.SelectedColor = Color.FromArgb(RGB(0), RGB(1), RGB(2))
            Else
                cpb2.SelectedColor = Color.FromArgb(0, 0, 0)
            End If
        End With

        Try
            Dim Path As String = String.Format("{0}\{1}\{2}\Logo\{3}", RootFolder, MainFolder, txtCompanyCode.Text.Trim, FileName)
            If IO.File.Exists(Path) Then
                Using TempPB As New DevExpress.XtraEditors.PictureEdit
                    TempPB.Image = Image.FromFile(Path)
                    ResizeImages(TempPB.Image.Clone, pb_Logo, 850, 700)
                End Using
            Else
                pb_Logo.Image = DefaultImage.Image.Clone
            End If
        Catch ex As Exception
            TriggerBugReport("Sister Company - DoubleClick", ex.Message.ToString)
        End Try

        SuperTabControl1.SelectedTab = tabBranch
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub
End Class