Imports System.Drawing.Imaging
Imports DevExpress.XtraReports.UI
Public Class FrmAgentProfile

    Dim ID As Integer
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FirstLoad As Boolean = True
    Dim FileName As String
    Dim ChangeBorrowerPic As Boolean
    ReadOnly DefaultImage As New DevExpress.XtraEditors.PictureEdit
    Dim TotalImage As Integer

    Dim vPosition_1 As String
    Dim vCompany_1 As String
    Dim vPosition_2 As String
    Dim vCompany_2 As String
    Dim vPosition_3 As String
    Dim vCompany_3 As String

    Dim vReferenceAddress_1 As String
    Dim vReferenceContact_1 As String
    Dim vReference_2 As String
    Dim vReferenceAddress_2 As String
    Dim vReferenceContact_2 As String
    Dim vReference_3 As String
    Dim vReferenceAddress_3 As String
    Dim vReferenceContact_3 As String
    Private Sub FrmAgentProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetGridAppearance({GridView1})
        FixUI(AllowStandardUI)
        Icon = My.Resources.iLoanWorkX_ico
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_B.Size = New Point(255, 227)
        pb_B.Location = New Point(892, 6)
        FirstLoad = True
        GetAgent()
        DefaultImage.Image = pb_B.Image.Clone
        DtpBirth_B.Value = Date.Now
        dtpFrom_1.Value = Date.Now
        dtpFrom_1.CustomFormat = ""
        dtpFrom_2.Value = Date.Now
        dtpFrom_3.Value = Date.Now
        dtpTo_1.Value = Date.Now
        dtpTo_2.Value = Date.Now
        dtpTo_3.Value = Date.Now
        'Borrower
        With CbxPrefix_B
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_B
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With cbxAddressC_B
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxPlaceBirth_B
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxCitizenship_B
            .ValueMember = "ID"
            .DisplayMember = "Nationality"
            .DataSource = Nationality.Copy
            .SelectedIndex = -1
        End With

        With cbxPosition_1
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxCompany_1
            .DisplayMember = "Employer"
            .DataSource = DT_Employer.Copy
            .SelectedIndex = -1
        End With

        With cbxPosition_2
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxCompany_2
            .DisplayMember = "Employer"
            .DataSource = DT_Employer.Copy
            .SelectedIndex = -1
        End With

        With cbxPosition_3
            .DisplayMember = "Position"
            .DataSource = DT_Position.Copy
            .SelectedIndex = -1
        End With

        With cbxCompany_3
            .DisplayMember = "Employer"
            .DataSource = DT_Employer.Copy
            .SelectedIndex = -1
        End With

        pb_B.Properties.ContextMenuStrip = New ContextMenuStrip()
        LoadData()
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

            GetLabelFontSettings({LabelX155, LabelX4, LabelX6, LabelX10, LabelX14, LabelX13, LabelX8, LabelX9, LabelX1, LabelX12, LabelX15, LabelX16, LabelX17})

            GetTextBoxFontSettings({txtAgentID, TxtFirstN_B, TxtMiddleN_B, TxtLastN_B, txtNoC_B, txtStreetC_B, txtBarangayC_B, txtTIN_B, txtTelephone_B, txtPlus63, txtMobile_B, txtSSS_B, txtEmail_B, txtPath_B, txtReference_1, txtReferenceAddress_1, txtReferenceContact_1, txtReference_2, txtReferenceAddress_2, txtReferenceContact_2, txtReference_3, txtReferenceAddress_3, txtReferenceContact_3})

            GetComboBoxFontSettings({CbxPrefix_B, cbxSuffix_B, cbxAddressC_B, cbxPlaceBirth_B, cbxCitizenship_B, cbxPosition_1, cbxCompany_1, cbxPosition_2, cbxCompany_2, cbxPosition_3, cbxCompany_3})

            GetButtonFontSettings({btnAdd, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAttach, btnBrowse_B})

            GetDateTimeInputFontSettings({DtpBirth_B, dtpFrom_1, dtpTo_1, dtpFrom_2, dtpTo_2, dtpFrom_3, dtpTo_3})

            GetCheckBoxFontSettings({cbxMale_B, cbxFemale_B, cbxSingle_B, cbxMarried_B, cbxSeparated_B, cbxWidowed_B})

            GetLabelWithBackgroundFontSettings({LabelX3, LabelX5, LabelX162, LabelX2, LabelX7, LabelX18, LabelX184, LabelX181, LabelX182, LabelX183})

            GetTabControlFontSettings({SuperTabControl1})

            GetContextMenuBarFontSettings({ContextMenuBar3})
        Catch ex As Exception
            TriggerBugReport("Agent Profile - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Agent", lblTitle.Text)
    End Sub

    Private Sub GetAgent()
        txtAgentID.Text = DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', 'A', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_agent WHERE branch_id = '{0}';", Branch_ID))
    End Sub

    Private Sub LoadData()
        Cursor = Cursors.WaitCursor
        Dim SQL As String = "SELECT"
        SQL &= "    ID,"
        SQL &= "    AgentID AS 'Agent ID',"
        SQL &= "    Prefix,"
        SQL &= "    FirstN,"
        SQL &= "    MiddleN,"
        SQL &= "    LastN,"
        SQL &= "    Suffix,"
        SQL &= "    CONCAT(IF(Prefix = '','',CONCAT(Prefix, ' ')), IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',CONCAT(LastN, ' ')), Suffix) AS 'Name',"
        SQL &= "    NoC,"
        SQL &= "    StreetC,"
        SQL &= "    BarangayC,"
        SQL &= "    AddressC,"
        SQL &= "    CONCAT(IF(NoC = '','',CONCAT(NoC, ' ')), IF(StreetC = '','',CONCAT(StreetC, ' ')), IF(BarangayC = '','',CONCAT(BarangayC, ' ')), AddressC) AS 'Complete Address',"
        SQL &= "    DATE_FORMAT(Birth,'%m.%d.%y') AS 'Birthdate',"
        SQL &= "    PlaceBirth AS 'Place of Birth',"
        SQL &= "    Gender,"
        SQL &= "    Civil,"
        SQL &= "    Citizenship,"
        SQL &= "    TIN,"
        SQL &= "    Telephone,"
        SQL &= "    SSS,"
        SQL &= "    Mobile,"
        SQL &= "    Email,"
        SQL &= "    From_1,"
        SQL &= "    To_1,"
        SQL &= "    Position_1,"
        SQL &= "    Company_1,"
        SQL &= "    From_2,"
        SQL &= "    To_2,"
        SQL &= "    Position_2,"
        SQL &= "    Company_2,"
        SQL &= "    From_3,"
        SQL &= "    To_3,"
        SQL &= "    Position_3,"
        SQL &= "    Company_3,"
        SQL &= "    Reference_1,"
        SQL &= "    ReferenceAddress_1,"
        SQL &= "    ReferenceContact_1,"
        SQL &= "    Reference_2,"
        SQL &= "    ReferenceAddress_2,"
        SQL &= "    ReferenceContact_2,"
        SQL &= "    Reference_3,"
        SQL &= "    ReferenceAddress_3,"
        SQL &= "    ReferenceContact_3,"
        SQL &= "    branch_code, Attach, Branch(Branch_ID) AS 'Branch'"
        SQL &= String.Format("    FROM profile_agent WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ORDER BY agentID DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID))
        GridControl1.DataSource = DataSource(SQL)
        If Multiple_ID.Contains(",") Then
            GridColumn47.Visible = True
            GridColumn47.VisibleIndex = 13
        End If
        GridView1.Columns("Name").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count
        GridView1.Columns("Name").SummaryItem.DisplayFormat = "Total of {0} record(s) fetched"

        If GridView1.RowCount > 22 Then
            GridColumn13.Width = 323
        Else
            GridColumn13.Width = 340
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub CbxPlaceBirth_B_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxPlaceBirth_B.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        Dim drv As DataRowView = DirectCast(cbxPlaceBirth_B.SelectedItem, DataRowView)
        cbxCitizenship_B.SelectedValue = drv("Country ID")
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
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

    Public Sub Clear(TriggerLoadData As Boolean)
        PanelEx10.Enabled = True
        GetAgent()
        TotalImage = 0
        txtPath_B.Text = ""
        CbxPrefix_B.Text = ""
        TxtFirstN_B.Text = ""
        TxtMiddleN_B.Text = ""
        TxtLastN_B.Text = ""
        cbxSuffix_B.Text = ""
        txtNoC_B.Text = ""
        txtStreetC_B.Text = ""
        txtBarangayC_B.Text = ""
        cbxAddressC_B.Text = ""
        DtpBirth_B.CustomFormat = ""
        cbxPlaceBirth_B.Text = ""
        cbxMale_B.Checked = False
        cbxFemale_B.Checked = False
        cbxSingle_B.Checked = False
        cbxMarried_B.Checked = False
        cbxSeparated_B.Checked = False
        cbxWidowed_B.Checked = False
        cbxCitizenship_B.Text = ""
        txtTIN_B.Text = ""
        txtTelephone_B.Text = ""
        txtSSS_B.Text = ""
        txtMobile_B.Text = ""
        txtEmail_B.Text = ""
        Try
            pb_B.Image = DefaultImage.Image.Clone
        Catch ex As Exception
            pb_B.Image = Nothing
        End Try
        dtpFrom_1.CustomFormat = ""
        txtReference_1.Text = ""
        btnSave.Enabled = True
        btnSave.Text = "&Save"
        btnDelete.Enabled = False
        btnModify.Enabled = False
        btnAttach.Enabled = False
        ChangeBorrowerPic = False

        If TriggerLoadData Then
            LoadData()
        End If
    End Sub

    Private Sub BtnBrowse_B_Click(sender As Object, e As EventArgs) Handles btnBrowse_B.Click
        Using OFD As New OpenFileDialog
            OFD.Filter = "Image File|*.jpg;*.jpeg;*.png"
            If (OFD.ShowDialog() = DialogResult.OK) Then
                Try
                    pb_B.Image.Dispose()
                    txtPath_B.Text = OFD.FileName
                    Using TempPB As New DevExpress.XtraEditors.PictureEdit
                        TempPB.Image = Image.FromFile(txtPath_B.Text)
                        ResizeImages(TempPB.Image.Clone, pb_B, 650, 500)
                    End Using

                    ChangeBorrowerPic = True
                Catch ex As Exception
                    MsgBox("File type not supported. Please select JPG, JPEG and PNG files only.", MsgBoxStyle.Information, "Info")
                End Try
            End If
        End Using
    End Sub

    Private Sub Pb_B_Click(sender As Object, e As MouseEventArgs) Handles pb_B.Click
        Dim Camera As New FrmCamera
        With Camera
            If .ShowDialog = DialogResult.OK Then
                pb_B.Image = .pb_Picture.Image.Clone
                txtPath_B.Text = "From Camera"
            End If
        End With
    End Sub

    Private Sub CbxSingle_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSingle_B.CheckedChanged
        If cbxSingle_B.Checked = True Then
            cbxMarried_B.Checked = False
            cbxSeparated_B.Checked = False
            cbxWidowed_B.Checked = False
        End If
    End Sub

    Private Sub CbxMarried_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMarried_B.CheckedChanged
        If cbxMarried_B.Checked = True Then
            cbxSingle_B.Checked = False
            cbxSeparated_B.Checked = False
            cbxWidowed_B.Checked = False
        End If
    End Sub

    Private Sub CbxSeparated_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSeparated_B.CheckedChanged
        If cbxSeparated_B.Checked = True Then
            cbxSingle_B.Checked = False
            cbxMarried_B.Checked = False
            cbxWidowed_B.Checked = False
        End If
    End Sub

    Private Sub CbxWidowed_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWidowed_B.CheckedChanged
        If cbxWidowed_B.Checked = True Then
            cbxSingle_B.Checked = False
            cbxMarried_B.Checked = False
            cbxSeparated_B.Checked = False
        End If
    End Sub

    Private Sub CbxMale_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMale_B.CheckedChanged
        If cbxMale_B.Checked = True Then
            cbxFemale_B.Checked = False
        End If
    End Sub

    Private Sub CbxFemale_B_CheckedChanged(sender As Object, e As EventArgs) Handles cbxFemale_B.CheckedChanged
        If cbxFemale_B.Checked = True Then
            cbxMale_B.Checked = False
        End If
    End Sub

    Private Sub TxtReference_1_TextChanged(sender As Object, e As EventArgs) Handles txtReference_1.TextChanged
        If txtReference_1.Text.Trim = "" Then
            txtReferenceAddress_1.Enabled = False
            txtReferenceContact_1.Enabled = False
            txtReference_2.Enabled = False

            txtReferenceAddress_2.Enabled = False
            txtReferenceContact_2.Enabled = False
            txtReference_3.Enabled = False
            txtReferenceAddress_3.Enabled = False
            txtReferenceContact_3.Enabled = False

            vReferenceAddress_1 = txtReferenceAddress_1.Text
            vReferenceContact_1 = txtReferenceContact_1.Text
            vReference_2 = txtReference_2.Text

            txtReferenceAddress_1.Text = ""
            txtReferenceContact_1.Text = ""
            txtReference_2.Text = ""
        Else
            txtReferenceAddress_1.Enabled = True
            txtReferenceContact_1.Enabled = True
            txtReference_2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vReferenceAddress_1 = "" And vReferenceContact_1 = "" And vReference_2 = "" Then
            Else
                If txtReferenceAddress_1.Text = "" Then
                    txtReferenceAddress_1.Text = vReferenceAddress_1
                End If
                If txtReferenceContact_1.Text = "" Then
                    txtReferenceContact_1.Text = vReferenceContact_1
                End If
                If txtReference_2.Text = "" Then
                    txtReference_2.Text = vReference_2
                End If
            End If
        End If
    End Sub

    Private Sub TxtReference_2_TextChanged(sender As Object, e As EventArgs) Handles txtReference_2.TextChanged
        If txtReference_2.Text.Trim = "" Then
            txtReferenceAddress_2.Enabled = False
            txtReferenceContact_2.Enabled = False
            txtReference_3.Enabled = False

            txtReferenceAddress_3.Enabled = False
            txtReferenceContact_3.Enabled = False

            vReferenceAddress_2 = txtReferenceAddress_2.Text
            vReferenceContact_2 = txtReferenceContact_2.Text
            vReference_3 = txtReference_3.Text

            txtReferenceAddress_2.Text = ""
            txtReferenceContact_2.Text = ""
            txtReference_3.Text = ""
        Else
            txtReferenceAddress_2.Enabled = True
            txtReferenceContact_2.Enabled = True
            txtReference_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vReferenceAddress_2 = "" And vReferenceContact_2 = "" And vReference_3 = "" Then
            Else
                If txtReferenceAddress_2.Text = "" Then
                    txtReferenceAddress_2.Text = vReferenceAddress_2
                End If
                If txtReferenceContact_2.Text = "" Then
                    txtReferenceContact_2.Text = vReferenceContact_2
                End If
                If txtReference_3.Text = "" Then
                    txtReference_3.Text = vReference_3
                End If
            End If
        End If
    End Sub

    Private Sub TxtReference_3_TextChanged(sender As Object, e As EventArgs) Handles txtReference_3.TextChanged
        If txtReference_3.Text.Trim = "" Then
            txtReferenceAddress_3.Enabled = False
            txtReferenceContact_3.Enabled = False

            vReferenceAddress_3 = txtReferenceAddress_3.Text
            vReferenceContact_3 = txtReferenceContact_3.Text

            txtReferenceAddress_3.Text = ""
            txtReferenceContact_3.Text = ""
        Else
            txtReferenceAddress_3.Enabled = True
            txtReferenceContact_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vReferenceAddress_3 = "" And vReferenceContact_3 = "" Then
            Else
                If txtReferenceAddress_3.Text = "" Then
                    txtReferenceAddress_3.Text = vReferenceAddress_3
                End If
                If txtReferenceContact_3.Text = "" Then
                    txtReferenceContact_3.Text = vReferenceContact_3
                End If
            End If
        End If
    End Sub

#Region "Keydown"
    Private Sub CbxPrefix_B_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_B.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_B.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_B.Focus()
        End If
    End Sub

    Private Sub TxtLastN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_B.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNoC_B.Focus()
        End If
    End Sub

    Private Sub TxtNoC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNoC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreetC_B.Focus()
        End If
    End Sub

    Private Sub TxtStreetC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreetC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangayC_B.Focus()
        End If
    End Sub

    Private Sub TxtBarangayC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangayC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddressC_B.Focus()
        End If
    End Sub

    Private Sub CbxAddressC_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddressC_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_B.Focus()
        End If
    End Sub

    Private Sub DtpBirth_B_Click(sender As Object, e As EventArgs) Handles DtpBirth_B.Click
        DtpBirth_B.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpBirth_B_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxPlaceBirth_B.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            DtpBirth_B.CustomFormat = ""
        End If
    End Sub

    Private Sub CbxPlaceBirth_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPlaceBirth_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMale_B.Focus()
        End If
    End Sub

    Private Sub CbxMale_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMale_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxFemale_B.Focus()
        End If
    End Sub

    Private Sub CbxFemale_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxFemale_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSingle_B.Focus()
        End If
    End Sub

    Private Sub CbxSingle_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSingle_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMarried_B.Focus()
        End If
    End Sub

    Private Sub CbxMarried_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarried_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSeparated_B.Focus()
        End If
    End Sub

    Private Sub CbxSeparated_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSeparated_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxWidowed_B.Focus()
        End If
    End Sub

    Private Sub CbxWidowed_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxWidowed_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCitizenship_B.Focus()
        End If
    End Sub

    Private Sub CbxCitizenship_B_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCitizenship_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_B.Focus()
        End If
    End Sub

    Private Sub TxtTIN_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTelephone_B.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephone_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_B.Focus()
        End If
    End Sub

    Private Sub TxtSSS_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMobile_B.Focus()
        End If
    End Sub

    Private Sub TxtMobile_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMobile_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail_B.Focus()
        End If
    End Sub

    Private Sub TxtEmail_B_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail_B.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpFrom_1.Focus()
            dtpFrom_1.CustomFormat = "MMMM dd, yyyy"
        End If
    End Sub

    Private Sub DtpFrom_1_Click(sender As Object, e As EventArgs) Handles dtpFrom_1.Click
        dtpFrom_1.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpFrom_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFrom_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpFrom_1.CustomFormat = "MMMM dd, yyyy" Then
                dtpTo_1.Focus()
                dtpTo_1.CustomFormat = "MMMM dd, yyyy"
            Else
                txtReference_1.Focus()
            End If
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpFrom_1.CustomFormat = ""
            txtReference_1.Focus()
        End If
    End Sub

    Private Sub DtpTo_1_Click(sender As Object, e As EventArgs) Handles dtpTo_1.Click
        dtpTo_1.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpTo_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpTo_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpTo_1.CustomFormat = "MMMM dd, yyyy" Then
                cbxPosition_1.Focus()
            Else
                txtReference_1.Focus()
            End If
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpTo_1.CustomFormat = ""
            txtReference_1.Focus()
        End If
    End Sub

    Private Sub CbxPosition_1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCompany_1.Focus()
        End If
    End Sub

    Private Sub CbxCompany_1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCompany_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpFrom_2.Enabled = True Then
                dtpFrom_2.Focus()
            Else
                txtReference_1.Focus()
            End If
        End If
    End Sub

    Private Sub DtpFrom_2_Click(sender As Object, e As EventArgs) Handles dtpFrom_2.Click
        dtpFrom_2.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpFrom_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFrom_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpFrom_2.CustomFormat = "MMMM dd, yyyy" Then
                dtpTo_2.Focus()
                dtpTo_2.CustomFormat = "MMMM dd, yyyy"
            Else
                txtReference_1.Focus()
            End If
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpFrom_2.CustomFormat = ""
            txtReference_1.Focus()
        End If
    End Sub

    Private Sub DtpTo_2_Click(sender As Object, e As EventArgs) Handles dtpTo_2.Click
        dtpTo_2.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpTo_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpTo_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpTo_2.CustomFormat = "MMMM dd, yyyy" Then
                cbxPosition_2.Focus()
            Else
                txtReference_1.Focus()
            End If
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpTo_2.CustomFormat = ""
            txtReference_1.Focus()
        End If
    End Sub

    Private Sub CbxPosition_2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCompany_2.Focus()
        End If
    End Sub

    Private Sub CbxCompany_2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCompany_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpFrom_3.Enabled = True Then
                dtpFrom_3.Focus()
            Else
                txtReference_1.Focus()
            End If
        End If
    End Sub

    Private Sub DtpFrom_3_Click(sender As Object, e As EventArgs) Handles dtpFrom_3.Click
        dtpFrom_3.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpFrom_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpFrom_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpFrom_3.CustomFormat = "MMMM dd, yyyy" Then
                dtpTo_3.Focus()
                dtpTo_3.CustomFormat = "MMMM dd, yyyy"
            Else
                txtReference_1.Focus()
            End If
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpFrom_3.CustomFormat = ""
            txtReference_1.Focus()
        End If
    End Sub

    Private Sub DtpTo_3_Click(sender As Object, e As EventArgs) Handles dtpTo_3.Click
        dtpTo_3.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpTo_3_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpTo_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If dtpTo_3.CustomFormat = "MMMM dd, yyyy" Then
                cbxPosition_3.Focus()
            Else
                txtReference_1.Focus()
            End If
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpTo_3.CustomFormat = ""
            txtReference_1.Focus()
        End If
    End Sub

    Private Sub CbxPosition_3_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxPosition_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCompany_3.Focus()
        End If
    End Sub

    Private Sub CbxCompany_3_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCompany_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReference_1.Focus()
        End If
    End Sub

    Private Sub TxtReference_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReference_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtReferenceAddress_1.Enabled = True Then
                txtReferenceAddress_1.Focus()
            Else
                btnSave.Focus()
            End If
        End If
    End Sub

    Private Sub TxtReferenceAddress_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceAddress_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReferenceContact_1.Focus()
        End If
    End Sub

    Private Sub TxtReferenceContact_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceContact_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReference_2.Focus()
        End If
    End Sub

    Private Sub TxtReference_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReference_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtReferenceAddress_2.Enabled = True Then
                txtReferenceAddress_2.Focus()
            Else
                btnSave.Focus()
            End If
        End If
    End Sub

    Private Sub TxtReferenceAddress_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceAddress_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReferenceContact_2.Focus()
        End If
    End Sub

    Private Sub TxtReferenceContact_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceContact_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReference_3.Focus()
        End If
    End Sub

    Private Sub TxtReference_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReference_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtReferenceAddress_3.Enabled Then
                txtReferenceAddress_3.Focus()
            Else
                btnSave.Focus()
            End If
        End If
    End Sub

    Private Sub TxtReferenceAddress_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceAddress_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtReferenceContact_3.Focus()
        End If
    End Sub

    Private Sub TxtReferenceContact_3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtReferenceContact_3.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leave"
    Private Sub CbxPrefix_B_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_B.Leave
        CbxPrefix_B.Text = ReplaceText(CbxPrefix_B.Text.Trim)
    End Sub

    Private Sub TxtFirstN_B_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_B.Leave
        TxtFirstN_B.Text = ReplaceText(TxtFirstN_B.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_B_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_B.Leave
        TxtMiddleN_B.Text = ReplaceText(TxtMiddleN_B.Text.Trim)
    End Sub

    Private Sub TxtLastN_B_Leave(sender As Object, e As EventArgs) Handles TxtLastN_B.Leave
        TxtLastN_B.Text = ReplaceText(TxtLastN_B.Text.Trim)
    End Sub

    Private Sub CbxSuffix_B_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_B.Leave
        cbxSuffix_B.Text = ReplaceText(cbxSuffix_B.Text.Trim)
    End Sub

    Private Sub TxtNoC_B_Leave(sender As Object, e As EventArgs) Handles txtNoC_B.Leave
        txtNoC_B.Text = ReplaceText(txtNoC_B.Text.Trim)
    End Sub

    Private Sub TxtStreetC_B_Leave(sender As Object, e As EventArgs) Handles txtStreetC_B.Leave
        txtStreetC_B.Text = ReplaceText(txtStreetC_B.Text.Trim)
    End Sub

    Private Sub TxtBarangayC_B_Leave(sender As Object, e As EventArgs) Handles txtBarangayC_B.Leave
        txtBarangayC_B.Text = ReplaceText(txtBarangayC_B.Text.Trim)
    End Sub

    Private Sub CbxAddressC_B_Leave(sender As Object, e As EventArgs) Handles cbxAddressC_B.Leave
        cbxAddressC_B.Text = ReplaceText(cbxAddressC_B.Text.Trim)
    End Sub

    Private Sub CbxPlaceBirth_B_Leave(sender As Object, e As EventArgs) Handles cbxPlaceBirth_B.Leave
        cbxPlaceBirth_B.Text = ReplaceText(cbxPlaceBirth_B.Text.Trim)
    End Sub

    Private Sub CbxCitizenship_B_Leave(sender As Object, e As EventArgs) Handles cbxCitizenship_B.Leave
        cbxCitizenship_B.Text = ReplaceText(cbxCitizenship_B.Text.Trim)
    End Sub

    Private Sub TxtTIN_B_Leave(sender As Object, e As EventArgs) Handles txtTIN_B.Leave
        txtTIN_B.Text = ReplaceText(txtTIN_B.Text.Trim)
    End Sub

    Private Sub TxtTelephone_B_Leave(sender As Object, e As EventArgs) Handles txtTelephone_B.Leave
        txtTelephone_B.Text = ReplaceText(txtTelephone_B.Text.Trim)
    End Sub

    Private Sub TxtSSS_B_Leave(sender As Object, e As EventArgs) Handles txtSSS_B.Leave
        txtSSS_B.Text = ReplaceText(txtSSS_B.Text.Trim)
    End Sub

    Private Sub TxtMobile_B_Leave(sender As Object, e As EventArgs) Handles txtMobile_B.Leave
        txtMobile_B.Text = ReplaceText(txtMobile_B.Text.Trim)
    End Sub

    Private Sub TxtEmail_B_Leave(sender As Object, e As EventArgs) Handles txtEmail_B.Leave
        txtEmail_B.Text = ReplaceText(txtEmail_B.Text.Trim)
    End Sub

    Private Sub CbxPosition_1_Leave(sender As Object, e As EventArgs) Handles cbxPosition_1.Leave
        cbxPosition_1.Text = ReplaceText(cbxPosition_1.Text.Trim)
    End Sub

    Private Sub CbxPosition_2_Leave(sender As Object, e As EventArgs) Handles cbxPosition_2.Leave
        cbxPosition_2.Text = ReplaceText(cbxPosition_2.Text.Trim)
    End Sub

    Private Sub CbxPosition_3_Leave(sender As Object, e As EventArgs) Handles cbxPosition_3.Leave
        cbxPosition_3.Text = ReplaceText(cbxPosition_3.Text.Trim)
    End Sub

    Private Sub CbxCompany_1_Leave(sender As Object, e As EventArgs) Handles cbxCompany_1.Leave
        cbxCompany_1.Text = ReplaceText(cbxCompany_1.Text.Trim)
    End Sub

    Private Sub CbxCompany_2_Leave(sender As Object, e As EventArgs) Handles cbxCompany_2.Leave
        cbxCompany_2.Text = ReplaceText(cbxCompany_2.Text.Trim)
    End Sub

    Private Sub CbxCompany_3_Leave(sender As Object, e As EventArgs) Handles cbxCompany_3.Leave
        cbxCompany_3.Text = ReplaceText(cbxCompany_3.Text.Trim)
    End Sub

    Private Sub TxtReference_1_Leave(sender As Object, e As EventArgs) Handles txtReference_1.Leave
        txtReference_1.Text = ReplaceText(txtReference_1.Text.Trim)
    End Sub

    Private Sub TxtReferenceAddress_1_Leave(sender As Object, e As EventArgs) Handles txtReferenceAddress_1.Leave
        txtReferenceAddress_1.Text = ReplaceText(txtReferenceAddress_1.Text.Trim)
    End Sub

    Private Sub TxtReferenceContact_1_Leave(sender As Object, e As EventArgs) Handles txtReferenceContact_1.Leave
        txtReferenceContact_1.Text = ReplaceText(txtReferenceContact_1.Text.Trim)
    End Sub

    Private Sub TxtReference_2_Leave(sender As Object, e As EventArgs) Handles txtReference_2.Leave
        txtReference_2.Text = ReplaceText(txtReference_2.Text.Trim)
    End Sub

    Private Sub TxtReferenceAddress_2_Leave(sender As Object, e As EventArgs) Handles txtReferenceAddress_2.Leave
        txtReferenceAddress_2.Text = ReplaceText(txtReferenceAddress_2.Text.Trim)
    End Sub

    Private Sub TxtReferenceContact_2_Leave(sender As Object, e As EventArgs) Handles txtReferenceContact_2.Leave
        txtReferenceContact_2.Text = ReplaceText(txtReferenceContact_2.Text.Trim)
    End Sub

    Private Sub TxtReference_3_Leave(sender As Object, e As EventArgs) Handles txtReference_3.Leave
        txtReference_3.Text = ReplaceText(txtReference_3.Text.Trim)
    End Sub

    Private Sub TxtReferenceAddress_3_Leave(sender As Object, e As EventArgs) Handles txtReferenceAddress_3.Leave
        txtReferenceAddress_3.Text = ReplaceText(txtReferenceAddress_3.Text.Trim)
    End Sub

    Private Sub TxtReferenceContact_3_Leave(sender As Object, e As EventArgs) Handles txtReferenceContact_3.Leave
        txtReferenceContact_3.Text = ReplaceText(txtReferenceContact_3.Text.Trim)
    End Sub
#End Region

    Private Sub DtpFrom_1_FormatChanged(sender As Object, e As EventArgs) Handles dtpFrom_1.FormatChanged
        If dtpFrom_1.CustomFormat = "" Then
            dtpTo_1.Enabled = False
            dtpTo_1.CustomFormat = ""
            cbxPosition_1.Enabled = False
            cbxCompany_1.Enabled = False
            dtpFrom_2.Enabled = False
            dtpFrom_2.CustomFormat = ""

            dtpTo_2.Enabled = False
            dtpTo_2.CustomFormat = ""
            cbxPosition_2.Enabled = False
            cbxCompany_2.Enabled = False
            dtpFrom_3.Enabled = False
            dtpFrom_3.CustomFormat = ""

            dtpTo_3.Enabled = False
            dtpTo_3.CustomFormat = ""
            cbxPosition_3.Enabled = False
            cbxCompany_3.Enabled = False

            vPosition_1 = cbxPosition_1.Text
            vCompany_1 = cbxCompany_1.Text

            cbxPosition_1.Text = ""
            cbxCompany_1.Text = ""
        Else
            dtpTo_1.Enabled = True
            dtpTo_1.CustomFormat = "MMMM dd, yyyy"
            cbxPosition_1.Enabled = True
            cbxCompany_1.Enabled = True
            dtpFrom_2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vPosition_1 = "" And vCompany_1 = "" Then
            Else
                If cbxPosition_1.Text = "" Then
                    cbxPosition_1.Text = vPosition_1
                End If
                If cbxCompany_1.Text = "" Then
                    cbxCompany_1.Text = vCompany_1
                End If
            End If
        End If
    End Sub

    Private Sub DtpFrom_2_FormatChanged(sender As Object, e As EventArgs) Handles dtpFrom_2.FormatChanged
        If dtpFrom_2.CustomFormat = "" Then
            dtpTo_2.Enabled = False
            dtpTo_2.CustomFormat = ""
            cbxPosition_2.Enabled = False
            cbxCompany_2.Enabled = False
            dtpFrom_3.Enabled = False
            dtpFrom_3.CustomFormat = ""

            dtpTo_3.Enabled = False
            dtpTo_3.CustomFormat = ""
            cbxPosition_3.Enabled = False
            cbxCompany_3.Enabled = False

            vPosition_2 = cbxPosition_2.Text
            vCompany_2 = cbxCompany_2.Text

            cbxPosition_2.Text = ""
            cbxCompany_2.Text = ""
        Else
            dtpTo_2.Enabled = True
            dtpTo_2.CustomFormat = "MMMM dd, yyyy"
            cbxPosition_2.Enabled = True
            cbxCompany_2.Enabled = True
            dtpFrom_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vPosition_2 = "" And vCompany_2 = "" Then
            Else
                If cbxPosition_2.Text = "" Then
                    cbxPosition_2.Text = vPosition_2
                End If
                If cbxCompany_2.Text = "" Then
                    cbxCompany_2.Text = vCompany_2
                End If
            End If
        End If
    End Sub

    Private Sub DtpFrom_3_FormatChanged(sender As Object, e As EventArgs) Handles dtpFrom_3.FormatChanged
        If dtpFrom_3.CustomFormat = "" Then
            dtpTo_3.Enabled = False
            dtpTo_3.CustomFormat = ""
            cbxPosition_3.Enabled = False
            cbxCompany_3.Enabled = False

            vPosition_3 = cbxPosition_3.Text
            vCompany_3 = cbxCompany_3.Text

            cbxPosition_3.Text = ""
            cbxCompany_3.Text = ""
        Else
            dtpTo_3.Enabled = True
            dtpTo_3.CustomFormat = "MMMM dd, yyyy"
            cbxPosition_3.Enabled = True
            cbxCompany_3.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vPosition_3 = "" And vCompany_3 = "" Then
            Else
                If cbxPosition_3.Text = "" Then
                    cbxPosition_3.Text = vPosition_3
                End If
                If cbxCompany_3.Text = "" Then
                    cbxCompany_3.Text = vCompany_3
                End If
            End If
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
            btnPrint.Enabled = True
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
            DataObject(String.Format("UPDATE profile_agent SET `status` = 'DELETED' WHERE AgentID = '{0}'", txtAgentID.Text))
            Logs("Agent", "Cancel", Reason, String.Format("Cancel Agent {0}", If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & cbxSuffix_B.Text), "", "", "")
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
        If SuperTabControl1.SelectedTabIndex = 0 Then
            Dim Report As New RptAgentProfile
            With Report
                .Name = txtAgentID.Text
                .p_Borrower.Image = pb_B.Image.Clone
                .lblBorrowerID.Text = txtAgentID.Text
                .lblBorrower.Text = If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & " ") & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & If(cbxSuffix_B.Text.Trim = "", "", cbxSuffix_B.Text.Trim & " ")
                .lblCompleteAdd.Text = If(txtNoC_B.Text.Trim = "", "", txtNoC_B.Text.Trim & " ") & If(txtStreetC_B.Text.Trim = "", "", txtStreetC_B.Text.Trim & " ") & If(txtBarangayC_B.Text.Trim = "", "", txtBarangayC_B.Text.Trim & " ") & If(cbxAddressC_B.Text.Trim = "", "", cbxAddressC_B.Text.Trim & " ")
                .lblBirthDate.Text = If(DtpBirth_B.CustomFormat = "", "", DtpBirth_B.Text)
                .lblBirthPlace.Text = cbxPlaceBirth_B.Text
                .cbxMale.Checked = cbxMale_B.Checked
                .cbxFemale.Checked = cbxFemale_B.Checked
                .cbxSingle.Checked = cbxSingle_B.Checked
                .cbxMarried.Checked = cbxMarried_B.Checked
                .cbxSeparated.Checked = cbxSeparated_B.Checked
                .cbxWidowed.Checked = cbxWidowed_B.Checked
                .lblCitizenship.Text = cbxCitizenship_B.Text
                .lblTIN.Text = txtTIN_B.Text
                .lblTelephone.Text = txtTelephone_B.Text
                .lblSSS.Text = txtSSS_B.Text
                .lblMobile.Text = txtMobile_B.Text
                .lblEmail.Text = txtEmail_B.Text
                .lblFrom_1.Text = If(dtpFrom_1.CustomFormat = "", "", dtpFrom_1.Text)
                .lblTo_1.Text = If(dtpTo_1.CustomFormat = "", "", dtpTo_1.Text)
                .lblPosition_1.Text = cbxPosition_1.Text
                .lblCompany_1.Text = cbxCompany_1.Text
                .lblFrom_2.Text = If(dtpFrom_2.CustomFormat = "", "", dtpFrom_2.Text)
                .lblTo_2.Text = If(dtpTo_2.CustomFormat = "", "", dtpTo_2.Text)
                .lblPosition_2.Text = cbxPosition_2.Text
                .lblCompany_2.Text = cbxCompany_2.Text
                .lblFrom_3.Text = If(dtpFrom_3.CustomFormat = "", "", dtpFrom_3.Text)
                .lblTo_3.Text = If(dtpTo_3.CustomFormat = "", "", dtpTo_3.Text)
                .lblPosition_3.Text = cbxPosition_3.Text
                .lblCompany_3.Text = cbxCompany_3.Text
                .lblReference_1.Text = txtReference_1.Text
                .lblReferenceAdd_1.Text = txtReferenceAddress_1.Text
                .lblReferenceTel_1.Text = txtReferenceContact_1.Text
                .lblReference_2.Text = txtReference_2.Text
                .lblReferenceAdd_2.Text = txtReferenceAddress_2.Text
                .lblReferenceTel_2.Text = txtReferenceContact_2.Text
                .lblReference_3.Text = txtReference_3.Text
                .lblReferenceAdd_3.Text = txtReferenceAddress_3.Text
                .lblReferenceTel_3.Text = txtReferenceContact_3.Text
                Logs("Agent Profile", "Print", "[SENSITIVE] Print Agent Profile of " & If(CbxPrefix_B.Text.Trim = "", "", CbxPrefix_B.Text.Trim & " ") & If(TxtFirstN_B.Text.Trim = "", "", TxtFirstN_B.Text.Trim & " ") & If(TxtMiddleN_B.Text.Trim = "", "", TxtMiddleN_B.Text.Trim & " ") & If(TxtLastN_B.Text.Trim = "", "", TxtLastN_B.Text.Trim & " ") & If(cbxSuffix_B.Text.Trim = "", "", cbxSuffix_B.Text.Trim & " "), "", "", "", "")
                .ShowPreview()
            End With
        Else
            GridView1.OptionsPrint.UsePrintStyles = False
            StandardPrinting("AGENT LIST", GridControl1)
            Logs("Agent Profile", "Print", "[SENSITIVE] Print Agent Profile", "", "", "", "")
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
        ElseIf e.Control And e.KeyCode = Keys.X Then
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

    Private Sub CbxAddressC_B_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAddressC_B.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        cbxPlaceBirth_B.SelectedValue = cbxAddressC_B.SelectedValue
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If TxtFirstN_B.Text = "" Then
            MsgBox("Please fill agent first name.", MsgBoxStyle.Information, "Info")
            TxtFirstN_B.Focus()
            Exit Sub
        End If
        If TxtLastN_B.Text = "" Then
            MsgBox("Please fill agent last name.", MsgBoxStyle.Information, "Info")
            TxtLastN_B.Focus()
            Exit Sub
        End If

        Dim BorrowerN As String = If(CbxPrefix_B.Text = "", "", CbxPrefix_B.Text & " ") & If(TxtFirstN_B.Text = "", "", TxtFirstN_B.Text & " ") & If(TxtMiddleN_B.Text = "", "", TxtMiddleN_B.Text & " ") & If(TxtLastN_B.Text = "", "", TxtLastN_B.Text & " ") & If(cbxSuffix_B.Text = "", "", cbxSuffix_B.Text)
        Dim Gender_B As String = ""
        If cbxMale_B.Checked Then
            Gender_B = "Male"
        ElseIf cbxFemale_B.Checked Then
            Gender_B = "Female"
        End If
        Dim Civil_B As String = ""
        If cbxSingle_B.Checked Then
            Civil_B = "Single"
        ElseIf cbxMarried_B.Checked Then
            Civil_B = "Married"
        ElseIf cbxSeparated_B.Checked Then
            Civil_B = "Separated"
        ElseIf cbxWidowed_B.Checked Then
            Civil_B = "Widowed"
        End If
        If btnSave.Text = "&Save" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM profile_agent WHERE (FirstN = '{0}' AND LastN = '{1}' AND Suffix = '{2}') AND `status` = 'ACTIVE' AND Branch_ID = '{3}'", TxtFirstN_B.Text, TxtLastN_B.Text, cbxSuffix_B.Text, Branch_ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Agent {0} already exist, Please check your data.", BorrowerN), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Cursor = Cursors.WaitCursor
                GetAgent()

                Dim SQL As String = "INSERT INTO profile_agent SET"
                SQL &= String.Format(" AgentID = '{0}', ", txtAgentID.Text)
                SQL &= String.Format(" Prefix = '{0}', ", CbxPrefix_B.Text)
                SQL &= String.Format(" FirstN = '{0}', ", TxtFirstN_B.Text)
                SQL &= String.Format(" MiddleN = '{0}', ", TxtMiddleN_B.Text)
                SQL &= String.Format(" LastN = '{0}', ", TxtLastN_B.Text)
                SQL &= String.Format(" Suffix = '{0}', ", cbxSuffix_B.Text)
                SQL &= String.Format(" NoC = '{0}', ", txtNoC_B.Text)
                SQL &= String.Format(" StreetC = '{0}', ", txtStreetC_B.Text)
                SQL &= String.Format(" BarangayC = '{0}', ", txtBarangayC_B.Text)
                SQL &= String.Format(" `AddressC-ID` = '{0}', ", ValidateComboBox(cbxAddressC_B))
                SQL &= String.Format(" AddressC = '{0}', ", cbxAddressC_B.Text)
                SQL &= String.Format(" Birth = '{0}', ", FormatDatePicker(DtpBirth_B))
                SQL &= String.Format(" `PlaceBirth-ID` = '{0}', ", ValidateComboBox(cbxPlaceBirth_B))
                SQL &= String.Format(" PlaceBirth = '{0}', ", cbxPlaceBirth_B.Text)
                SQL &= String.Format(" Gender = '{0}', ", Gender_B)
                SQL &= String.Format(" Civil = '{0}', ", Civil_B)
                SQL &= String.Format(" Citizenship = '{0}', ", cbxCitizenship_B.Text)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN_B.Text)
                SQL &= String.Format(" Telephone = '{0}', ", txtTelephone_B.Text)
                SQL &= String.Format(" SSS = '{0}', ", txtSSS_B.Text)
                SQL &= String.Format(" Mobile = '{0}', ", txtMobile_B.Text)
                SQL &= String.Format(" Email = '{0}', ", txtEmail_B.Text)
                SQL &= String.Format(" From_1 = '{0}', ", FormatDatePicker(dtpFrom_1))
                SQL &= String.Format(" To_1 = '{0}', ", FormatDatePicker(dtpTo_1))
                SQL &= String.Format(" Position_1 = '{0}', ", cbxPosition_1.Text)
                SQL &= String.Format(" Company_1 = '{0}', ", cbxCompany_1.Text)
                SQL &= String.Format(" From_2 = '{0}', ", FormatDatePicker(dtpFrom_2))
                SQL &= String.Format(" To_2 = '{0}', ", FormatDatePicker(dtpTo_2))
                SQL &= String.Format(" Position_2 = '{0}', ", cbxPosition_2.Text)
                SQL &= String.Format(" Company_2 = '{0}', ", cbxCompany_2.Text)
                SQL &= String.Format(" From_3 = '{0}', ", FormatDatePicker(dtpFrom_3))
                SQL &= String.Format(" To_3 = '{0}', ", FormatDatePicker(dtpTo_3))
                SQL &= String.Format(" Position_3 = '{0}', ", cbxPosition_3.Text)
                SQL &= String.Format(" Company_3 = '{0}', ", cbxCompany_3.Text)
                SQL &= String.Format(" Reference_1 = '{0}', ", txtReference_1.Text)
                SQL &= String.Format(" ReferenceAddress_1 = '{0}', ", txtReferenceAddress_1.Text)
                SQL &= String.Format(" ReferenceContact_1 = '{0}', ", txtReferenceContact_1.Text)
                SQL &= String.Format(" Reference_2 = '{0}', ", txtReference_2.Text)
                SQL &= String.Format(" ReferenceAddress_2 = '{0}', ", txtReferenceAddress_2.Text)
                SQL &= String.Format(" ReferenceContact_2 = '{0}', ", txtReferenceContact_2.Text)
                SQL &= String.Format(" Reference_3 = '{0}', ", txtReference_3.Text)
                SQL &= String.Format(" ReferenceAddress_3 = '{0}', ", txtReferenceAddress_3.Text)
                SQL &= String.Format(" ReferenceContact_3 = '{0}', ", txtReferenceContact_3.Text)
                SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                SQL &= String.Format(" user_code = '{0}';", User_Code)
                DataObject(SQL)
                If txtPath_B.Text <> "" Then
                    SaveImage(pb_B, "Agent")
                End If
                Cursor = Cursors.Default

                Logs("Agent", "Save", String.Format("Add new Agent {0}", BorrowerN), "", "", "", "")
                Clear(True)
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM profile_agent WHERE (FirstN = '{0}' AND LastN = '{1}' AND Suffix = '{2}') AND `status` = 'ACTIVE' AND AgentID != '{3}' AND Branch_ID = '{4}'", TxtFirstN_B.Text, TxtLastN_B.Text, cbxSuffix_B.Text, txtAgentID.Text, Branch_ID))
                If Exist > 0 Then
                    MsgBox(String.Format("Agent {0} already exist, Please check your data.", BorrowerN), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE profile_agent SET"
                SQL &= String.Format(" Prefix = '{0}', ", CbxPrefix_B.Text)
                SQL &= String.Format(" FirstN = '{0}', ", TxtFirstN_B.Text)
                SQL &= String.Format(" MiddleN = '{0}', ", TxtMiddleN_B.Text)
                SQL &= String.Format(" LastN = '{0}', ", TxtLastN_B.Text)
                SQL &= String.Format(" Suffix = '{0}', ", cbxSuffix_B.Text)
                SQL &= String.Format(" NoC = '{0}', ", txtNoC_B.Text)
                SQL &= String.Format(" StreetC = '{0}', ", txtStreetC_B.Text)
                SQL &= String.Format(" BarangayC = '{0}', ", txtBarangayC_B.Text)
                SQL &= String.Format(" `AddressC-ID` = '{0}', ", ValidateComboBox(cbxAddressC_B))
                SQL &= String.Format(" AddressC = '{0}', ", cbxAddressC_B.Text)
                SQL &= String.Format(" Birth = '{0}', ", FormatDatePicker(DtpBirth_B))
                SQL &= String.Format(" `PlaceBirth-ID` = '{0}', ", ValidateComboBox(cbxPlaceBirth_B))
                SQL &= String.Format(" PlaceBirth = '{0}', ", cbxPlaceBirth_B.Text)
                SQL &= String.Format(" Gender = '{0}', ", Gender_B)
                SQL &= String.Format(" Civil = '{0}', ", Civil_B)
                SQL &= String.Format(" Citizenship = '{0}', ", cbxCitizenship_B.Text)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN_B.Text)
                SQL &= String.Format(" Telephone = '{0}', ", txtTelephone_B.Text)
                SQL &= String.Format(" SSS = '{0}', ", txtSSS_B.Text)
                SQL &= String.Format(" Mobile = '{0}', ", txtMobile_B.Text)
                SQL &= String.Format(" Email = '{0}', ", txtEmail_B.Text)
                SQL &= String.Format(" From_1 = '{0}', ", FormatDatePicker(dtpFrom_1))
                SQL &= String.Format(" To_1 = '{0}', ", FormatDatePicker(dtpTo_1))
                SQL &= String.Format(" Position_1 = '{0}', ", cbxPosition_1.Text)
                SQL &= String.Format(" Company_1 = '{0}', ", cbxCompany_1.Text)
                SQL &= String.Format(" From_2 = '{0}', ", FormatDatePicker(dtpFrom_2))
                SQL &= String.Format(" To_2 = '{0}', ", FormatDatePicker(dtpTo_2))
                SQL &= String.Format(" Position_2 = '{0}', ", cbxPosition_2.Text)
                SQL &= String.Format(" Company_2 = '{0}', ", cbxCompany_2.Text)
                SQL &= String.Format(" From_3 = '{0}', ", FormatDatePicker(dtpFrom_3))
                SQL &= String.Format(" To_3 = '{0}', ", FormatDatePicker(dtpTo_3))
                SQL &= String.Format(" Position_3 = '{0}', ", cbxPosition_3.Text)
                SQL &= String.Format(" Company_3 = '{0}', ", cbxCompany_3.Text)
                SQL &= String.Format(" Reference_1 = '{0}', ", txtReference_1.Text)
                SQL &= String.Format(" ReferenceAddress_1 = '{0}', ", txtReferenceAddress_1.Text)
                SQL &= String.Format(" ReferenceContact_1 = '{0}', ", txtReferenceContact_1.Text)
                SQL &= String.Format(" Reference_2 = '{0}', ", txtReference_2.Text)
                SQL &= String.Format(" ReferenceAddress_2 = '{0}', ", txtReferenceAddress_2.Text)
                SQL &= String.Format(" ReferenceContact_2 = '{0}', ", txtReferenceContact_2.Text)
                SQL &= String.Format(" Reference_3 = '{0}', ", txtReference_3.Text)
                SQL &= String.Format(" ReferenceAddress_3 = '{0}', ", txtReferenceAddress_3.Text)
                SQL &= String.Format(" ReferenceContact_3 = '{0}' ", txtReferenceContact_3.Text)
                SQL &= String.Format(" WHERE AgentID = '{0}';", txtAgentID.Text)
                DataObject(SQL)
                If txtPath_B.Text <> "" Then
                    SaveImage(pb_B, "Agent")
                End If
                Cursor = Cursors.Default

                Logs("Agent", "Update", String.Format("Update agent {0}", BorrowerN), Changes(), "", "", "")
                Clear(True)
                MsgBox("Successfully Updated!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If CbxPrefix_B.Text = CbxPrefix_B.Tag Then
            Else
                Change &= String.Format("Change Prefix from {0} to {1}. ", CbxPrefix_B.Tag, CbxPrefix_B.Text)
            End If
            If TxtFirstN_B.Text = TxtFirstN_B.Tag Then
            Else
                Change &= String.Format("Change First Name from {0} to {1}. ", TxtFirstN_B.Tag, TxtFirstN_B.Text)
            End If
            If TxtMiddleN_B.Text = TxtMiddleN_B.Tag Then
            Else
                Change &= String.Format("Change Middle Name from {0} to {1}. ", TxtMiddleN_B.Tag, TxtMiddleN_B.Text)
            End If
            If TxtLastN_B.Text = TxtLastN_B.Tag Then
            Else
                Change &= String.Format("Change Last Name from {0} to {1}. ", TxtLastN_B.Tag, TxtLastN_B.Text)
            End If
            If cbxSuffix_B.Text = cbxSuffix_B.Tag Then
            Else
                Change &= String.Format("Change Suffix from {0} to {1}. ", cbxSuffix_B.Tag, cbxSuffix_B.Text)
            End If
            If txtNoC_B.Text = txtNoC_B.Tag Then
            Else
                Change &= String.Format("Change Complete Address No from {0} to {1}. ", txtNoC_B.Tag, txtNoC_B.Text)
            End If
            If txtStreetC_B.Text = txtStreetC_B.Tag Then
            Else
                Change &= String.Format("Change Complete Address Street from {0} to {1}. ", txtStreetC_B.Tag, txtStreetC_B.Text)
            End If
            If txtBarangayC_B.Text = txtBarangayC_B.Tag Then
            Else
                Change &= String.Format("Change Complete Address Barangay from {0} to {1}. ", txtBarangayC_B.Tag, txtBarangayC_B.Text)
            End If
            If cbxAddressC_B.Text = cbxAddressC_B.Tag Then
            Else
                Change &= String.Format("Change Complete Address from {0} to {1}. ", cbxAddressC_B.Tag, cbxAddressC_B.Text)
            End If
            If FormatDatePicker(DtpBirth_B) = DtpBirth_B.Tag Then
            Else
                Change &= String.Format("Change Birthdate from {0} to {1}. ", DtpBirth_B.Tag, FormatDatePicker(DtpBirth_B))
            End If
            If cbxPlaceBirth_B.Text = cbxPlaceBirth_B.Tag Then
            Else
                Change &= String.Format("Change Place of Birth from {0} to {1}. ", cbxPlaceBirth_B.Tag, cbxPlaceBirth_B.Text)
            End If
            If cbxMale_B.Tag <> "Male" And cbxMale_B.Checked Then
                Change &= String.Format("Change Gender from {0} to {1}. ", cbxMale_B.Tag, cbxMale_B.Text)
            ElseIf cbxFemale_B.Tag <> "Female" And cbxFemale_B.Checked Then
                Change &= String.Format("Change Gender from {0} to {1}. ", cbxFemale_B.Tag, cbxFemale_B.Text)
            End If
            If cbxSingle_B.Tag <> "Single" And cbxSingle_B.Checked Then
                Change &= String.Format("Change Civil Status from {0} to {1}. ", cbxSingle_B.Tag, cbxSingle_B.Text)
            ElseIf cbxMarried_B.Tag <> "Married" And cbxMarried_B.Checked Then
                Change &= String.Format("Change Civil Status from {0} to {1}. ", cbxMarried_B.Tag, cbxMarried_B.Text)
            ElseIf cbxSeparated_B.Tag <> "Separated" And cbxSeparated_B.Checked Then
                Change &= String.Format("Change Civil Status from {0} to {1}. ", cbxSeparated_B.Tag, cbxSeparated_B.Text)
            ElseIf cbxWidowed_B.Tag <> "Widowed" And cbxWidowed_B.Checked Then
                Change &= String.Format("Change Civil Status from {0} to {1}. ", cbxWidowed_B.Tag, cbxWidowed_B.Text)
            End If
            If cbxCitizenship_B.Text = cbxCitizenship_B.Tag Then
            Else
                Change &= String.Format("Change Citizenship from {0} to {1}. ", cbxCitizenship_B.Tag, cbxCitizenship_B.Text)
            End If
            If txtTIN_B.Text = txtTIN_B.Tag Then
            Else
                Change &= String.Format("Change TIN from {0} to {1}. ", txtTIN_B.Tag, txtTIN_B.Text)
            End If
            If txtTelephone_B.Text = txtTelephone_B.Tag Then
            Else
                Change &= String.Format("Change Telephone from {0} to {1}. ", txtTelephone_B.Tag, txtTelephone_B.Text)
            End If
            If txtSSS_B.Text = txtSSS_B.Tag Then
            Else
                Change &= String.Format("Change SSS from {0} to {1}. ", txtSSS_B.Tag, txtSSS_B.Text)
            End If
            If txtMobile_B.Text = txtMobile_B.Tag Then
            Else
                Change &= String.Format("Change Mobile from {0} to {1}. ", txtMobile_B.Tag, txtMobile_B.Text)
            End If
            If txtEmail_B.Text = txtEmail_B.Tag Then
            Else
                Change &= String.Format("Change Email from {0} to {1}. ", txtEmail_B.Tag, txtEmail_B.Text)
            End If
            If FormatDatePicker(dtpFrom_1) = dtpFrom_1.Tag Then
            Else
                Change &= String.Format("Change Date From 1 from {0} to {1}. ", dtpFrom_1.Tag, FormatDatePicker(dtpFrom_1))
            End If
            If FormatDatePicker(dtpTo_1) = dtpTo_1.Tag Then
            Else
                Change &= String.Format("Change Date To 1 from {0} to {1}. ", dtpTo_1.Tag, FormatDatePicker(dtpTo_1))
            End If
            If cbxPosition_1.Text = cbxPosition_1.Tag Then
            Else
                Change &= String.Format("Change Position 1 from {0} to {1}. ", cbxPosition_1.Tag, cbxPosition_1.Text)
            End If
            If cbxCompany_1.Text = cbxCompany_1.Tag Then
            Else
                Change &= String.Format("Change Company 1 from {0} to {1}. ", cbxCompany_1.Tag, cbxCompany_1.Text)
            End If
            If FormatDatePicker(dtpFrom_2) = dtpFrom_2.Tag Then
            Else
                Change &= String.Format("Change Date From 2 from {0} to {1}. ", dtpFrom_2.Tag, FormatDatePicker(dtpFrom_2))
            End If
            If FormatDatePicker(dtpTo_2) = dtpTo_2.Tag Then
            Else
                Change &= String.Format("Change Date To 2 from {0} to {1}. ", dtpTo_2.Tag, FormatDatePicker(dtpTo_2))
            End If
            If cbxPosition_2.Text = cbxPosition_2.Tag Then
            Else
                Change &= String.Format("Change Position 2 from {0} to {1}. ", cbxPosition_2.Tag, cbxPosition_2.Text)
            End If
            If cbxCompany_2.Text = cbxCompany_2.Tag Then
            Else
                Change &= String.Format("Change Company 2 from {0} to {1}. ", cbxCompany_2.Tag, cbxCompany_2.Text)
            End If
            If FormatDatePicker(dtpFrom_3) = dtpFrom_3.Tag Then
            Else
                Change &= String.Format("Change Date From 3 from {0} to {1}. ", dtpFrom_3.Tag, FormatDatePicker(dtpFrom_3))
            End If
            If FormatDatePicker(dtpTo_3) = dtpTo_3.Tag Then
            Else
                Change &= String.Format("Change Date To 3 from {0} to {1}. ", dtpTo_3.Tag, FormatDatePicker(dtpTo_3))
            End If
            If cbxPosition_3.Text = cbxPosition_3.Tag Then
            Else
                Change &= String.Format("Change Position 3 from {0} to {1}. ", cbxPosition_3.Tag, cbxPosition_3.Text)
            End If
            If cbxCompany_3.Text = cbxCompany_3.Tag Then
            Else
                Change &= String.Format("Change Company 3 from {0} to {1}. ", cbxCompany_3.Tag, cbxCompany_3.Text)
            End If
            If txtReference_1.Text = txtReference_1.Tag Then
            Else
                Change &= String.Format("Change Reference 1 from {0} to {1}. ", txtReference_1.Tag, txtReference_1.Text)
            End If
            If txtReferenceAddress_1.Text = txtReferenceAddress_1.Tag Then
            Else
                Change &= String.Format("Change Reference Address 1 from {0} to {1}. ", txtReferenceAddress_1.Tag, txtReferenceAddress_1.Text)
            End If
            If txtReferenceContact_1.Text = txtReferenceContact_1.Tag Then
            Else
                Change &= String.Format("Change Reference Contact 1 from {0} to {1}. ", txtReferenceContact_1.Tag, txtReferenceContact_1.Text)
            End If
            If txtReference_2.Text = txtReference_2.Tag Then
            Else
                Change &= String.Format("Change Reference 2 from {0} to {1}. ", txtReference_2.Tag, txtReference_2.Text)
            End If
            If txtReferenceAddress_2.Text = txtReferenceAddress_2.Tag Then
            Else
                Change &= String.Format("Change Reference Address 2 from {0} to {1}. ", txtReferenceAddress_2.Tag, txtReferenceAddress_2.Text)
            End If
            If txtReferenceContact_2.Text = txtReferenceContact_2.Tag Then
            Else
                Change &= String.Format("Change Reference Contact 2 from {0} to {1}. ", txtReferenceContact_2.Tag, txtReferenceContact_2.Text)
            End If
            If txtReference_3.Text = txtReference_3.Tag Then
            Else
                Change &= String.Format("Change Reference 3 from {0} to {1}. ", txtReference_3.Tag, txtReference_3.Text)
            End If
            If txtReferenceAddress_3.Text = txtReferenceAddress_3.Tag Then
            Else
                Change &= String.Format("Change Reference Address 3 from {0} to {1}. ", txtReferenceAddress_3.Tag, txtReferenceAddress_3.Text)
            End If
            If txtReferenceContact_3.Text = txtReferenceContact_3.Tag Then
            Else
                Change &= String.Format("Change Reference Contact 3 from {0} to {1}. ", txtReferenceContact_3.Tag, txtReferenceContact_3.Text)
            End If
            If ChangeBorrowerPic Then
                Change &= "Change Agent Picture. "
            End If
        Catch ex As Exception
            TriggerBugReport("Agent Profile - Changes", ex.Message.ToString)
        End Try

        Return Change
    End Function

    Public Sub SaveImage(pBox As DevExpress.XtraEditors.PictureEdit, Description As String)
        FileName = Description & ".jpg"
        '********CREATE FOLDER FSFC System
        If Not IO.Directory.Exists(String.Format("{0}\{1}", RootFolder, MainFolder)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}", RootFolder, MainFolder))
        End If
        '********CREATE FOLDER Branch
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER Agent
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Agents", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Agents", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER Agent
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Agents\{3}", RootFolder, MainFolder, Branch_Code, txtAgentID.Text)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Agents\{3}", RootFolder, MainFolder, Branch_Code, txtAgentID.Text))
        End If
        '********CREATE File
        Try
            Dim xPath As String
            xPath = String.Format("{0}\{1}\{2}\Agents\{3}\{4}", RootFolder, MainFolder, Branch_Code, txtAgentID.Text, FileName)
            If IO.File.Exists(xPath) Then
                IO.File.Delete(xPath)
            End If
            pBox.Image.Save(xPath, ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
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
            txtAgentID.Text = .GetFocusedRowCellValue("Agent ID")
            txtAgentID.Tag = .GetFocusedRowCellValue("Agent ID")
            CbxPrefix_B.Text = .GetFocusedRowCellValue("Prefix")
            CbxPrefix_B.Tag = .GetFocusedRowCellValue("Prefix")
            TxtFirstN_B.Text = .GetFocusedRowCellValue("FirstN")
            TxtFirstN_B.Tag = .GetFocusedRowCellValue("FirstN")
            TxtMiddleN_B.Text = .GetFocusedRowCellValue("MiddleN")
            TxtMiddleN_B.Tag = .GetFocusedRowCellValue("MiddleN")
            TxtLastN_B.Text = .GetFocusedRowCellValue("LastN")
            TxtLastN_B.Tag = .GetFocusedRowCellValue("LastN")
            cbxSuffix_B.Text = .GetFocusedRowCellValue("Suffix")
            cbxSuffix_B.Tag = .GetFocusedRowCellValue("Suffix")
            txtNoC_B.Text = .GetFocusedRowCellValue("NoC")
            txtNoC_B.Tag = .GetFocusedRowCellValue("NoC")
            txtStreetC_B.Text = .GetFocusedRowCellValue("StreetC")
            txtStreetC_B.Tag = .GetFocusedRowCellValue("StreetC")
            txtBarangayC_B.Text = .GetFocusedRowCellValue("BarangayC")
            txtBarangayC_B.Tag = .GetFocusedRowCellValue("BarangayC")
            cbxAddressC_B.Text = .GetFocusedRowCellValue("AddressC")
            cbxAddressC_B.Tag = .GetFocusedRowCellValue("AddressC")
            If .GetFocusedRowCellValue("Birthdate").ToString = "0001-01-01" Or .GetFocusedRowCellValue("Birthdate").ToString = "" Then
                DtpBirth_B.CustomFormat = ""
                DtpBirth_B.Tag = ""
            Else
                DtpBirth_B.CustomFormat = "MMMM dd, yyyy"
                DtpBirth_B.Text = .GetFocusedRowCellValue("Birthdate")
                DtpBirth_B.Tag = .GetFocusedRowCellValue("Birthdate")
            End If
            cbxPlaceBirth_B.Text = .GetFocusedRowCellValue("Place of Birth")
            cbxPlaceBirth_B.Tag = .GetFocusedRowCellValue("Place of Birth")
            If .GetFocusedRowCellValue("Gender") = "Male" Then
                cbxMale_B.Checked = True
            ElseIf .GetFocusedRowCellValue("Gender") = "Female" Then
                cbxFemale_B.Checked = True
            End If
            cbxMale_B.Tag = .GetFocusedRowCellValue("Gender")
            cbxFemale_B.Tag = .GetFocusedRowCellValue("Gender")
            If .GetFocusedRowCellValue("Civil") = "Single" Then
                cbxSingle_B.Checked = True
            ElseIf .GetFocusedRowCellValue("Civil") = "Married" Then
                cbxMarried_B.Checked = True
            ElseIf .GetFocusedRowCellValue("Civil") = "Separated" Then
                cbxSeparated_B.Checked = True
            ElseIf .GetFocusedRowCellValue("Civil") = "Widowed" Then
                cbxWidowed_B.Checked = True
            End If
            cbxSingle_B.Tag = .GetFocusedRowCellValue("Civil")
            cbxMarried_B.Tag = .GetFocusedRowCellValue("Civil")
            cbxSeparated_B.Tag = .GetFocusedRowCellValue("Civil")
            cbxWidowed_B.Tag = .GetFocusedRowCellValue("Civil")
            cbxCitizenship_B.Text = .GetFocusedRowCellValue("Citizenship")
            cbxCitizenship_B.Tag = .GetFocusedRowCellValue("Citizenship")
            txtTIN_B.Text = .GetFocusedRowCellValue("TIN")
            txtTIN_B.Tag = .GetFocusedRowCellValue("TIN")
            txtTelephone_B.Text = .GetFocusedRowCellValue("Telephone")
            txtTelephone_B.Tag = .GetFocusedRowCellValue("Telephone")
            txtSSS_B.Text = .GetFocusedRowCellValue("SSS")
            txtSSS_B.Tag = .GetFocusedRowCellValue("SSS")
            txtMobile_B.Text = .GetFocusedRowCellValue("Mobile")
            txtMobile_B.Tag = .GetFocusedRowCellValue("Mobile")
            txtEmail_B.Text = .GetFocusedRowCellValue("Email")
            txtEmail_B.Tag = .GetFocusedRowCellValue("Email")
            If .GetFocusedRowCellValue("From_1") = "0001-01-01" Or .GetFocusedRowCellValue("From_1") = "" Then
                dtpFrom_1.CustomFormat = ""
                dtpFrom_1.Tag = ""
            Else
                dtpFrom_1.CustomFormat = "MMMM dd, yyyy"
                dtpFrom_1.Text = .GetFocusedRowCellValue("From_1")
                dtpFrom_1.Tag = .GetFocusedRowCellValue("From_1")
            End If
            If .GetFocusedRowCellValue("To_1") = "0001-01-01" Or .GetFocusedRowCellValue("To_1") = "" Then
                dtpTo_1.CustomFormat = ""
                dtpTo_1.Tag = ""
            Else
                dtpTo_1.CustomFormat = "MMMM dd, yyyy"
                dtpTo_1.Text = .GetFocusedRowCellValue("To_1")
                dtpTo_1.Tag = .GetFocusedRowCellValue("To_1")
            End If
            cbxPosition_1.Text = .GetFocusedRowCellValue("Position_1")
            cbxPosition_1.Tag = .GetFocusedRowCellValue("Position_1")
            cbxCompany_1.Text = .GetFocusedRowCellValue("Company_1")
            cbxCompany_1.Tag = .GetFocusedRowCellValue("Company_1")
            If .GetFocusedRowCellValue("From_2") = "0001-01-01" Or .GetFocusedRowCellValue("From_2") = "" Then
                dtpFrom_2.CustomFormat = ""
                dtpFrom_2.Tag = ""
            Else
                dtpFrom_2.CustomFormat = "MMMM dd, yyyy"
                dtpFrom_2.Text = .GetFocusedRowCellValue("From_2")
                dtpFrom_2.Tag = .GetFocusedRowCellValue("From_2")
            End If
            If .GetFocusedRowCellValue("To_2") = "0001-01-01" Or .GetFocusedRowCellValue("To_2") = "" Then
                dtpTo_2.CustomFormat = ""
                dtpTo_2.Tag = ""
            Else
                dtpTo_2.CustomFormat = "MMMM dd, yyyy"
                dtpTo_2.Text = .GetFocusedRowCellValue("To_2")
                dtpTo_2.Tag = .GetFocusedRowCellValue("To_2")
            End If
            cbxPosition_2.Text = .GetFocusedRowCellValue("Position_2")
            cbxPosition_2.Tag = .GetFocusedRowCellValue("Position_2")
            cbxCompany_2.Text = .GetFocusedRowCellValue("Company_2")
            cbxCompany_2.Tag = .GetFocusedRowCellValue("Company_2")
            If .GetFocusedRowCellValue("From_3") = "0001-01-01" Or .GetFocusedRowCellValue("From_3") = "" Then
                dtpFrom_3.CustomFormat = ""
                dtpFrom_3.Tag = ""
            Else
                dtpFrom_3.CustomFormat = "MMMM dd, yyyy"
                dtpFrom_3.Text = .GetFocusedRowCellValue("From_3")
                dtpFrom_3.Tag = .GetFocusedRowCellValue("From_3")
            End If
            If .GetFocusedRowCellValue("To_3") = "0001-01-01" Or .GetFocusedRowCellValue("To_3") = "" Then
                dtpTo_3.CustomFormat = ""
                dtpTo_3.Tag = ""
            Else
                dtpTo_3.CustomFormat = "MMMM dd, yyyy"
                dtpTo_3.Text = .GetFocusedRowCellValue("To_3")
                dtpTo_3.Tag = .GetFocusedRowCellValue("To_3")
            End If
            cbxPosition_3.Text = .GetFocusedRowCellValue("Position_3")
            cbxPosition_3.Tag = .GetFocusedRowCellValue("Position_3")
            cbxCompany_3.Text = .GetFocusedRowCellValue("Company_3")
            cbxCompany_3.Tag = .GetFocusedRowCellValue("Company_3")
            txtReference_1.Text = .GetFocusedRowCellValue("Reference_1")
            txtReference_1.Tag = .GetFocusedRowCellValue("Reference_1")
            txtReferenceAddress_1.Text = .GetFocusedRowCellValue("ReferenceAddress_1")
            txtReferenceAddress_1.Tag = .GetFocusedRowCellValue("ReferenceAddress_1")
            txtReferenceContact_1.Text = .GetFocusedRowCellValue("ReferenceContact_1")
            txtReferenceContact_1.Tag = .GetFocusedRowCellValue("ReferenceContact_1")
            txtReference_2.Text = .GetFocusedRowCellValue("Reference_2")
            txtReference_2.Tag = .GetFocusedRowCellValue("Reference_2")
            txtReferenceAddress_2.Text = .GetFocusedRowCellValue("ReferenceAddress_2")
            txtReferenceAddress_2.Tag = .GetFocusedRowCellValue("ReferenceAddress_2")
            txtReferenceContact_2.Text = .GetFocusedRowCellValue("ReferenceContact_2")
            txtReferenceContact_2.Tag = .GetFocusedRowCellValue("ReferenceContact_2")
            txtReference_3.Text = .GetFocusedRowCellValue("Reference_3")
            txtReference_3.Tag = .GetFocusedRowCellValue("Reference_3")
            txtReferenceAddress_3.Text = .GetFocusedRowCellValue("ReferenceAddress_3")
            txtReferenceAddress_3.Tag = .GetFocusedRowCellValue("ReferenceAddress_3")
            txtReferenceContact_3.Text = .GetFocusedRowCellValue("ReferenceContact_3")
            txtReferenceContact_3.Tag = .GetFocusedRowCellValue("ReferenceContact_3")
            btnAttach.Enabled = True
            TotalImage = .GetFocusedRowCellValue("Attach")
        End With

        Try
            Using TempPB As New DevExpress.XtraEditors.PictureEdit
                TempPB.Image = Image.FromFile(String.Format("{0}\{1}\{2}\Agents\{3}\{4}", RootFolder, MainFolder, GridView1.GetFocusedRowCellValue("branch_code"), GridView1.GetFocusedRowCellValue("Agent ID"), "Agent.jpg"))
                ResizeImages(TempPB.Image.Clone, pb_B, 650, 500)
            End Using
        Catch ex As Exception
        End Try
        SuperTabControl1.SelectedTab = tabSetup
        btnModify.Enabled = True
        btnSave.Enabled = False
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment"
            .Type = "Agent's Attachment"
            .TotalImage = TotalImage
            .AgentNumber = txtAgentID.Text
            .ID = txtAgentID.Text
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
                GridView1.SetFocusedRowCellValue("Attach", TotalImage)
            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
                GridView1.SetFocusedRowCellValue("Attach", TotalImage)
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IReferred_Click(sender As Object, e As EventArgs) Handles iReferred.Click
        Try
            If GridView1.GetFocusedRowCellValue("ID").ToString = "" Or GridView1.RowCount = 0 Then
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim Referred As New FrmReferredBorrowers
        With Referred
            .From_Agent = True
            .Agent = GridView1.GetFocusedRowCellValue("Name")
            .AgentID = GridView1.GetFocusedRowCellValue("Agent ID")
            .ShowDialog()
            .Dispose()
        End With
    End Sub
End Class