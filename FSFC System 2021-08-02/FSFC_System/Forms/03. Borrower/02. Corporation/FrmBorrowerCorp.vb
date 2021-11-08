Imports System.Drawing.Imaging
Imports DevExpress.XtraReports.UI
Public Class FrmBorrowerCorp

    Dim FirstLoad As Boolean = True
    Public vSave As Boolean
    Public vUpdate As Boolean
    Public vDelete As Boolean
    Public vPrint As Boolean
    Public vCheck As Boolean
    Public vApprove As Boolean
    Dim FileName As String
    Public ID As Integer
    ReadOnly DefaultImage As New DevExpress.XtraEditors.PictureEdit
    Public TotalImage As Integer
    Public TotalImage_R1 As Integer
    Public TotalImage_R2 As Integer
    Public TotalImage_R3 As Integer
    Public TotalImage_R4 As Integer
    Public TotalImage_R5 As Integer

    Public vPrefix_S1 As String
    Public vFirstN_S1 As String
    Public vMiddleN_S1 As String
    Public vLastN_S1 As String
    Public vSuffix_S1 As String
    Public vPrefix_S2 As String
    Public vFirstN_S2 As String
    Public vMiddleN_S2 As String
    Public vLastN_S2 As String
    Public vSuffix_S2 As String

    Public vPrefix_S3 As String
    Public vFirstN_S3 As String
    Public vMiddleN_S3 As String
    Public vLastN_S3 As String
    Public vSuffix_S3 As String
    Public vPrefix_S4 As String
    Public vFirstN_S4 As String
    Public vMiddleN_S4 As String
    Public vLastN_S4 As String
    Public vSuffix_S4 As String
    '*** D A T A   S T O R A G E ***'
    Dim vBranch_1 As String
    Dim vcSA_1 As Boolean
    Dim vcCA_1 As Boolean
    Dim vSA_1 As String
    Dim vAverageBalance_1 As Double
    Dim vPresentBalance_1 As Double
    Dim vBankRemarks_1 As String
    Dim vBank_2 As String
    Dim vBranch_2 As String
    Dim vcSA_2 As Boolean
    Dim vcCA_2 As Boolean
    Dim vSA_2 As String
    Dim vAverageBalance_2 As Double
    Dim vPresentBalance_2 As Double
    Dim vBankRemarks_2 As String

    Dim vMiddleN_R1 As String
    Dim vLastN_R1 As String
    Dim vSuffix_R1 As String
    ReadOnly vBirth_R1 As String
    Dim vTIN_R1 As String
    Dim vSSS_R1 As String
    Dim vGMI_R1 As String
    Dim vNo_R1 As String
    Dim vStreet_R1 As String
    Dim vBarangay_R1 As String
    Dim vAddress_R1 As String
    Dim vPosition_R1 As String
    Dim vContact_R1 As String
    Dim vYears_R1 As String
    Dim vPrefix_R2 As String
    Dim vFirstN_R2 As String
    Dim vMiddleN_R2 As String
    Dim vLastN_R2 As String
    Dim vSuffix_R2 As String
    ReadOnly vBirth_R2 As String
    Dim vTIN_R2 As String
    Dim vSSS_R2 As String
    Dim vGMI_R2 As String
    Dim vNo_R2 As String
    Dim vStreet_R2 As String
    Dim vBarangay_R2 As String
    Dim vAddress_R2 As String
    Dim vPosition_R2 As String
    Dim vContact_R2 As String
    Dim vYears_R2 As String
    Dim vPrefix_R3 As String
    Dim vFirstN_R3 As String
    Dim vMiddleN_R3 As String
    Dim vLastN_R3 As String
    Dim vSuffix_R3 As String
    ReadOnly vBirth_R3 As String
    Dim vTIN_R3 As String
    Dim vSSS_R3 As String
    Dim vGMI_R3 As String
    Dim vNo_R3 As String
    Dim vStreet_R3 As String
    Dim vBarangay_R3 As String
    Dim vAddress_R3 As String
    Dim vPosition_R3 As String
    Dim vContact_R3 As String
    Dim vYears_R3 As String
    Dim vPrefix_R4 As String
    Dim vFirstN_R4 As String
    Dim vMiddleN_R4 As String
    Dim vLastN_R4 As String
    Dim vSuffix_R4 As String
    ReadOnly vBirth_R4 As String
    Dim vTIN_R4 As String
    Dim vSSS_R4 As String
    Dim vGMI_R4 As String
    Dim vNo_R4 As String
    Dim vStreet_R4 As String
    Dim vBarangay_R4 As String
    Dim vAddress_R4 As String
    Dim vPosition_R4 As String
    Dim vContact_R4 As String
    Dim vYears_R4 As String
    Dim vPrefix_R5 As String
    Dim vFirstN_R5 As String
    Dim vMiddleN_R5 As String
    Dim vLastN_R5 As String
    Dim vSuffix_R5 As String
    ReadOnly vBirth_R5 As String
    Dim vTIN_R5 As String
    Dim vSSS_R5 As String
    Dim vGMI_R5 As String
    Dim vNo_R5 As String
    Dim vStreet_R5 As String
    Dim vBarangay_R5 As String
    Dim vAddress_R5 As String
    Dim vPosition_R5 As String
    Dim vContact_R5 As String
    Dim vYears_R5 As String
    Dim ChangeLogo As Boolean
    '*** D A T A   S T O R A G E ***'

    Private Sub FrmBorrowerCorp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Icon = My.Resources.iLoanWorkX_ico
        FixUI(AllowStandardUI)
        Cursor = Cursors.WaitCursor
        FixPictureEdit(PictureEdit1, 263, 64, 9, 1, True)
        pb_Logo.Size = New Point(292, 200)
        pb_Logo.Location = New Point(841, 11)
        FirstLoad = True
        GetBorrower()
        DefaultImage.Image = pb_Logo.Image.Clone

        dtpOpened_1.CustomFormat = ""
        dtpOpened_2.CustomFormat = ""
        DtpBirth_R1.CustomFormat = ""
        DtpBirth_R2.CustomFormat = ""
        DtpBirth_R3.CustomFormat = ""
        DtpBirth_R4.CustomFormat = ""
        DtpBirth_R5.CustomFormat = ""

        'BusinessCenter
        With cbxBusinessCenter
            .ValueMember = "ID"
            .DisplayMember = "BusinessCenter"
            .DataSource = DT_BusinessCenter.Copy
            .SelectedIndex = -1
        End With

        With CbxPrefix_R1
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_R1
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With CbxPrefix_R2
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_R2
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With CbxPrefix_R3
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_R3
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With CbxPrefix_R4
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_R4
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With CbxPrefix_R5
            .ValueMember = "ID"
            .DisplayMember = "Prefix"
            .DataSource = Prefix.Copy
            .SelectedIndex = -1
        End With

        With cbxSuffix_R5
            .DisplayMember = "Suffix"
            .DataSource = Suffix.Copy
            .SelectedIndex = -1
        End With

        With cbxAddress
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxAddress_R1
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxAddress_R2
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxAddress_R3
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxAddress_R4
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        With cbxAddress_R5
            .ValueMember = "City ID"
            .DisplayMember = "City"
            .DataSource = City.Copy
            .SelectedIndex = -1
        End With

        dtpIncorporation.Value = Date.Now
        DtpBirth_R1.Value = Date.Now
        DtpBirth_R2.Value = Date.Now
        DtpBirth_R3.Value = Date.Now
        DtpBirth_R4.Value = Date.Now
        DtpBirth_R5.Value = Date.Now
        dtpOpened_1.Value = Date.Now
        dtpOpened_2.Value = Date.Now

        With cbxAgentName
            .ValueMember = "AgentID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT AgentID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',CONCAT(LastN, ' ')), Suffix) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_agent WHERE `status` = 'ACTIVE' ORDER BY `Name` DESC;", Branch_ID))
            .SelectedIndex = -1
        End With

        With cbxMarketingName
            .ValueMember = "emp_code"
            .DisplayMember = "Name"
            .DataSource = DataSource("SELECT ID, emp_code, CONCAT(IF(Prefix = '','',CONCAT(Prefix, ' ')), IF(First_Name = '','',CONCAT(First_Name, ' ')), IF(Middle_Name = '','',CONCAT(Middle_Name, ' ')), IF(Last_Name = '','',CONCAT(Last_Name, ' ')), Suffix) AS 'Name' FROM employee_setup WHERE `status` = 'ACTIVE' AND department_id = 9 ORDER BY `Name`;")
            .SelectedIndex = -1
        End With

        With cbxWalkInType
            .ValueMember = "ID"
            .DisplayMember = "Type"
            .DataSource = DataSource("SELECT ID, `Type` FROM walkin_type WHERE `status` = 'ACTIVE' ORDER BY `Type`;")
            .SelectedIndex = -1
        End With

        With cbxDealerName
            .ValueMember = "DealerID"
            .DisplayMember = "Name"
            .DataSource = DataSource(String.Format("SELECT DealerID, CONCAT(IF(FirstN = '','',CONCAT(FirstN, ' ')), IF(MiddleN = '','',CONCAT(MiddleN, ' ')), IF(LastN = '','',LastN)) AS 'Name', IF(Telephone = '',Mobile,CONCAT(Telephone,'/',Mobile)) AS 'Contact' FROM profile_dealer WHERE `status` = 'ACTIVE' AND Branch_ID IN ({0}) ORDER BY `Name` DESC;", If(Multiple_ID = "", Branch_ID, Multiple_ID)))
            .SelectedIndex = -1
        End With

        pb_Logo.Properties.ContextMenuStrip = New ContextMenuStrip()
        FirstLoad = False
        Cursor = Cursors.Default
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

            GetLabelFontSettings({LabelX2})

            GetLabelFontSettings({LabelX4, LabelX10, LabelX15, LabelX11, LabelX13, LabelX3, LabelX6, LabelX8, LabelX16, LabelX17, LabelX12, LabelX5, LabelX7, LabelX9})

            GetLabelWithBackgroundFontSettings({LabelX157, LabelX189, LabelX159, LabelX161, LabelX160, LabelX162, LabelX158, LabelX163, LabelX19, LabelX21, LabelX22, LabelX14, LabelX23, LabelX32, LabelX24, LabelX18, LabelX31, LabelX30, LabelX28, LabelX27, LabelX20, LabelX26, LabelX33, LabelX25, LabelX29, LabelX39, LabelX37, LabelX38, LabelX40, LabelX41, LabelX36, LabelX34, LabelX35, LabelX47, LabelX55, LabelX45, LabelX46, LabelX48, LabelX49, LabelX44, LabelX42, LabelX43, LabelX58, LabelX59, LabelX53, LabelX54, LabelX56, LabelX57, LabelX52, LabelX50, LabelX51, LabelX60, LabelX61, LabelX62, LabelX188})

            GetTextBoxFontSettings({txtTradeName, txtBorrowerID, txtNo, txtStreet, txtBarangay, txtTIN, txtSSS, txtTelephone, txtEmail, txtFax, txtWebsite, txtPath, txtBank_1, txtBranch_1, txtBankRemarks_1, txtBank_2, txtBranch_2, txtBankRemarks_2, TxtFirstN_R1, TxtMiddleN_R1, TxtLastN_R1, txtTIN_R1, txtSSS_R1, txtNo_R1, txtStreet_R1, txtBarangay_R1, txtPosition_R1, txtContact_R1, TxtFirstN_R2, TxtMiddleN_R2, TxtLastN_R2, txtTIN_R2, txtSSS_R2, txtNo_R2, txtStreet_R2, txtBarangay_R2, txtPosition_R2, txtContact_R2, TxtFirstN_R3, TxtMiddleN_R3, TxtLastN_R3, txtTIN_R3, txtSSS_R3, txtNo_R3, txtStreet_R3, txtBarangay_R3, txtPosition_R3, txtContact_R3, TxtFirstN_R4, TxtMiddleN_R4, TxtLastN_R4, txtTIN_R4, txtSSS_R4, txtNo_R4, txtStreet_R4, txtBarangay_R4, txtPosition_R4, txtContact_R4, TxtFirstN_R5, TxtMiddleN_R5, TxtLastN_R5, txtTIN_R5, txtSSS_R5, txtNo_R5, txtStreet_R5, txtBarangay_R5, txtPosition_R5, txtContact_R5, txtAgentContact, txtMarketingContact, txtWalkInOthers, txtDealersContact})

            GetComboBoxFontSettings({cbxAddress, CbxPrefix_R1, cbxSuffix_R1, cbxAddress_R1, CbxPrefix_R2, cbxSuffix_R2, cbxAddress_R2, CbxPrefix_R3, cbxSuffix_R3, cbxAddress_R3, CbxPrefix_R4, cbxSuffix_R4, cbxAddress_R4, CbxPrefix_R5, cbxSuffix_R5, cbxAddress_R5, cbxAgentName, cbxMarketingName, cbxWalkInType, cbxDealerName, cbxBusinessCenter})

            GetButtonFontSettings({btnBrowse, btnDefault, btnCA_1, btnCA_2, btnSave, btnRefresh, btnCancel, btnModify, btnDelete, btnPrint, btnAttach})

            GetDateTimeInputFontSettings({dtpIncorporation, dtpOpened_1, dtpOpened_2, DtpBirth_R1, DtpBirth_R2, DtpBirth_R3, DtpBirth_R4, DtpBirth_R5})

            GetDoubleInputFontSettings({dGross, dNet, dAverageBalance_1, dPresentBalance_1, dAverageBalance_2, dPresentBalance_2, dGMI_R1, dGMI_R2, dGMI_R3, dGMI_R4, dGMI_R5, dYears_R1, dYears_R2, dYears_R3, dYears_R4, dYears_R5})

            GetIntegerInputFontSettings({iYears, iEmployees})

            GetCheckBoxFontSettings({cbxMicro, cbxSmall, cbxMedium, cbxLarge, cbxSA_1, cbxCA_1, cbxSA_2, cbxCA_2, cbxAgent, cbxMarketing, cbxWalkIn, cbxDealer})
        Catch ex As Exception
            TriggerBugReport("Borrower Corp - FixUI", ex.Message.ToString)
        End Try
    End Sub

    Private Sub LblTitle_MouseEnter(sender As Object, e As EventArgs) Handles lblTitle.MouseEnter
        lblTitle.ForeColor = OfficialColor1
    End Sub

    Private Sub LblTitle_MouseLeave(sender As Object, e As EventArgs) Handles lblTitle.MouseLeave
        lblTitle.ForeColor = Color.Black
    End Sub

    Private Sub LblTitle_Click(sender As Object, e As EventArgs) Handles lblTitle.Click
        OpenFormHistory("Corporation Borrower", lblTitle.Text)
    End Sub

    Private Sub GetBorrower()
        txtBorrowerID.Text = DataObject(String.Format("SELECT CONCAT(LPAD({0},3,'0'), '-', 'C', LPAD(COUNT(ID) + 1,7,'0')) FROM profile_corporation WHERE branch_id = '{0}';", Branch_ID))
    End Sub

    Private Sub BtnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If MsgBoxYes(mClose) = MsgBoxResult.Yes Then
            Close()
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        btnSaveDraft.PerformClick()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        If MsgBoxYes(mRefresh) = MsgBoxResult.Yes Then
            Clear()
        End If
    End Sub

    Public Sub Clear()
        GetBorrower()
        PanelEx2.Enabled = True
        txtTradeName.Text = ""
        txtNo.Text = ""
        txtStreet.Text = ""
        txtBarangay.Text = ""
        cbxAddress.Text = ""
        txtTIN.Text = ""
        txtSSS.Text = ""
        txtTelephone.Text = ""
        txtEmail.Text = ""
        txtFax.Text = ""
        txtWebsite.Text = ""
        dtpIncorporation.Value = Date.Now
        iYears.Value = 0
        iEmployees.Value = 0
        cbxMicro.Checked = False
        cbxSmall.Checked = False
        cbxMedium.Checked = False
        cbxLarge.Checked = False
        dGross.Value = 0
        dNet.Value = 0
        txtPath.Text = ""
        CbxPrefix_R1.Text = ""
        TxtFirstN_R1.Text = ""
        TxtFirstN_R2.Text = ""
        TxtFirstN_R3.Text = ""
        TxtFirstN_R4.Text = ""
        TxtFirstN_R5.Text = ""
        txtBank_1.Text = ""
        cbxAgent.Checked = False
        cbxMarketing.Checked = False
        cbxWalkIn.Checked = False
        ChangeLogo = False

        pb_Logo.Image = DefaultImage.Image.Clone
        btnModify.Enabled = False
        btnDelete.Enabled = False
        btnSaveDraft.Enabled = True
        btnSave.Enabled = True
        btnAttach.Enabled = False
        btnSaveDraft.Text = "Save Draft"
        btnSave.Text = "&Save"

        TotalImage = 0
        TotalImage_R1 = 0
        TotalImage_R2 = 0
        TotalImage_R3 = 0
        TotalImage_R4 = 0
        TotalImage_R5 = 0

        vPrefix_S1 = ""
        vFirstN_S1 = ""
        vMiddleN_S1 = ""
        vLastN_S1 = ""
        vSuffix_S1 = ""
        vPrefix_S2 = ""
        vFirstN_S2 = ""
        vMiddleN_S2 = ""
        vLastN_S2 = ""
        vSuffix_S2 = ""

        vPrefix_S3 = ""
        vFirstN_S3 = ""
        vMiddleN_S3 = ""
        vLastN_S3 = ""
        vSuffix_S3 = ""
        vPrefix_S4 = ""
        vFirstN_S4 = ""
        vMiddleN_S4 = ""
        vLastN_S4 = ""
        vSuffix_S4 = ""

        btnAttach_R1.Enabled = False
        btnAttach_R2.Enabled = False
        btnAttach_R3.Enabled = False
        btnAttach_R4.Enabled = False
        btnAttach_R5.Enabled = False

        btnAttach_R1B.Visible = False
        btnAttach_R2B.Visible = False
        btnAttach_R3B.Visible = False
        btnAttach_R4B.Visible = False
        btnAttach_R5B.Visible = False
        cbxBusinessCenter.Text = ""
    End Sub

    Private Sub CbxMicro_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMicro.CheckedChanged
        If cbxMicro.Checked = True Then
            cbxSmall.Checked = False
            cbxMedium.Checked = False
            cbxLarge.Checked = False
        End If
    End Sub

    Private Sub CbxSmall_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSmall.CheckedChanged
        If cbxSmall.Checked = True Then
            cbxMicro.Checked = False
            cbxMedium.Checked = False
            cbxLarge.Checked = False
        End If
    End Sub

    Private Sub CbxMedium_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMedium.CheckedChanged
        If cbxMedium.Checked = True Then
            cbxMicro.Checked = False
            cbxSmall.Checked = False
            cbxLarge.Checked = False
        End If
    End Sub

    Private Sub CbxLarge_CheckedChanged(sender As Object, e As EventArgs) Handles cbxLarge.CheckedChanged
        If cbxLarge.Checked = True Then
            cbxMicro.Checked = False
            cbxSmall.Checked = False
            cbxMedium.Checked = False
        End If
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

                    ChangeLogo = True
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
            TriggerBugReport("Borrower Corp - Logo Click", ex.Message.ToString)
        End Try
    End Sub

#Region "Keydown"
    Private Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        With FrmMain
            .Keyboard_Press = True
            .Keyboard_Session = .Timer_Session.Interval
        End With
        If e.Control And e.KeyCode = Keys.S Then
            btnSave.Focus()
            btnSave.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.A Then
            btnSaveDraft.Focus()
            btnSaveDraft.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.P Then
            btnPrint.Focus()
            btnPrint.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.D Then
            btnDelete.Focus()
            btnDelete.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.M Then
            btnModify.Focus()
            btnModify.PerformClick()
        ElseIf e.Control And e.KeyCode = Keys.F Then
            btnRefresh.Focus()
            btnRefresh.PerformClick()
        ElseIf (e.Control And e.KeyCode = Keys.X) Or If(Me.FormBorderStyle = FormBorderStyle.FixedDialog, e.KeyCode = Keys.Escape, 0) Then
            btnCancel.Focus()
            btnCancel.PerformClick()
        ElseIf e.KeyCode = Keys.F12 Then
            FrmMain.BtnReport_Click(sender, e)
        End If
    End Sub

    Private Sub TxtTradeName_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTradeName.KeyDown
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
            txtTIN.Focus()
        End If
    End Sub

    Private Sub TxtTIN_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS.Focus()
        End If
    End Sub

    Private Sub TxtSSS_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTelephone.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTelephone.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtEmail.Focus()
        End If
    End Sub

    Private Sub TxtEmail_KeyDown(sender As Object, e As KeyEventArgs) Handles txtEmail.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtFax.Focus()
        End If
    End Sub

    Private Sub TxtFax_KeyDown(sender As Object, e As KeyEventArgs) Handles txtFax.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWebsite.Focus()
        End If
    End Sub

    Private Sub TxtWebsite_KeyDown(sender As Object, e As KeyEventArgs) Handles txtWebsite.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpIncorporation.Focus()
        End If
    End Sub

    Private Sub DtpIncorporation_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpIncorporation.KeyDown
        If e.KeyCode = Keys.Enter Then
            iYears.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpIncorporation.CustomFormat = ""
        End If
    End Sub

    Private Sub IYears_KeyDown(sender As Object, e As KeyEventArgs) Handles iYears.KeyDown
        If e.KeyCode = Keys.Enter Then
            iEmployees.Focus()
        End If
    End Sub

    Private Sub IEmployees_KeyDown(sender As Object, e As KeyEventArgs) Handles iEmployees.KeyDown
        If e.KeyCode = Keys.Enter Then
            dGross.Focus()
        End If
    End Sub

    Private Sub DGross_KeyDown(sender As Object, e As KeyEventArgs) Handles dGross.KeyDown
        If e.KeyCode = Keys.Enter Then
            dNet.Focus()
        End If
    End Sub

    Private Sub INet_KeyDown(sender As Object, e As KeyEventArgs) Handles dNet.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBank_1.Focus()
        End If
    End Sub

    Private Sub TxtBank_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBank_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBranch_1.Focus()
        End If
    End Sub

    Private Sub TxtBranch_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranch_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSA_1.Focus()
        End If
    End Sub

    Private Sub CbxSA_1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSA_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCA_1.Focus()
        End If
    End Sub

    Private Sub CbxCA_1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCA_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSA_1.Focus()
        End If
    End Sub

    Private Sub TxtSA_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSA_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAverageBalance_1.Focus()
        End If
    End Sub

    Private Sub DAverageBalance_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dAverageBalance_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dPresentBalance_1.Focus()
        End If
    End Sub

    Private Sub DPresentBalance_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dPresentBalance_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpOpened_1.Focus()
        End If
    End Sub

    Private Sub DtpOpened_1_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpOpened_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBankRemarks_1.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpOpened_1.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtBankRemarks_1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBankRemarks_1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBank_2.Focus()
        End If
    End Sub

    Private Sub TxtBank_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBank_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBranch_2.Focus()
        End If
    End Sub

    Private Sub TxtBranch_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBranch_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSA_2.Focus()
        End If
    End Sub

    Private Sub CbxSA_2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSA_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxCA_2.Focus()
        End If
    End Sub

    Private Sub CbxCA_2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxCA_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSA_2.Focus()
        End If
    End Sub

    Private Sub TxtSA_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSA_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dAverageBalance_2.Focus()
        End If
    End Sub

    Private Sub DAverageBalance_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dAverageBalance_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dPresentBalance_2.Focus()
        End If
    End Sub

    Private Sub DPresentBalance_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dPresentBalance_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dtpOpened_2.Focus()
        End If
    End Sub

    Private Sub DtpOpened_2_KeyDown(sender As Object, e As KeyEventArgs) Handles dtpOpened_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBankRemarks_2.Focus()
        ElseIf e.KeyCode = Keys.Delete Or e.KeyCode = Keys.Escape Then
            dtpOpened_2.CustomFormat = ""
        End If
    End Sub

    Private Sub TxtBankRemarks_2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBankRemarks_2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAgent.Focus()
        End If
    End Sub

    Private Sub CbxPrefix_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_R1.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_R1.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_R1.Focus()
        End If
    End Sub

    Private Sub TxtLastN_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_R1.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_R1.Focus()
        End If
    End Sub

    Private Sub DtpBirth_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_R1.Focus()
        End If
    End Sub

    Private Sub TxtTIN_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_R1.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dGMI_R1.Focus()
        End If
    End Sub

    Private Sub DGMI_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles dGMI_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNo_R1.Focus()
        End If
    End Sub

    Private Sub TxtNo_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreet_R1.Focus()
        End If
    End Sub

    Private Sub TxtStreet_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreet_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangay_R1.Focus()
        End If
    End Sub

    Private Sub TxtBarangay_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangay_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddress_R1.Focus()
        End If
    End Sub

    Private Sub CbxAddress_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddress_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPosition_R1.Focus()
        End If
    End Sub

    Private Sub TxtPosition_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPosition_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContact_R1.Focus()
        End If
    End Sub

    Private Sub TxtContact_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContact_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            dYears_R1.Focus()
        End If
    End Sub

    Private Sub DYears_R1_KeyDown(sender As Object, e As KeyEventArgs) Handles dYears_R1.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbxPrefix_R2.Focus()
        End If
    End Sub

    Private Sub CbxPrefix_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_R2.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_R2.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_R2.Focus()
        End If
    End Sub

    Private Sub TxtLastN_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_R2.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_R2.Focus()
        End If
    End Sub

    Private Sub DtpBirth_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_R2.Focus()
        End If
    End Sub

    Private Sub TxtTIN_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_R2.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dGMI_R2.Focus()
        End If
    End Sub

    Private Sub DGMI_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles dGMI_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNo_R2.Focus()
        End If
    End Sub

    Private Sub TxtNo_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreet_R2.Focus()
        End If
    End Sub

    Private Sub TxtStreet_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreet_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangay_R2.Focus()
        End If
    End Sub

    Private Sub TxtBarangay_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangay_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddress_R2.Focus()
        End If
    End Sub

    Private Sub CbxAddress_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddress_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPosition_R2.Focus()
        End If
    End Sub

    Private Sub TxtPosition_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPosition_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContact_R2.Focus()
        End If
    End Sub

    Private Sub TxtContact_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContact_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            dYears_R2.Focus()
        End If
    End Sub

    Private Sub DYears_R2_KeyDown(sender As Object, e As KeyEventArgs) Handles dYears_R2.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbxPrefix_R3.Focus()
        End If
    End Sub

    Private Sub CbxPrefix_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_R3.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_R3.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_R3.Focus()
        End If
    End Sub

    Private Sub TxtLastN_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_R3.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_R3.Focus()
        End If
    End Sub

    Private Sub DtpBirth_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_R3.Focus()
        End If
    End Sub

    Private Sub TxtTIN_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_R3.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dGMI_R3.Focus()
        End If
    End Sub

    Private Sub DGMI_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles dGMI_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNo_R3.Focus()
        End If
    End Sub

    Private Sub TxtNo_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreet_R3.Focus()
        End If
    End Sub

    Private Sub TxtStreet_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreet_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangay_R3.Focus()
        End If
    End Sub

    Private Sub TxtBarangay_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangay_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddress_R3.Focus()
        End If
    End Sub

    Private Sub CbxAddress_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddress_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPosition_R3.Focus()
        End If
    End Sub

    Private Sub TxtPosition_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPosition_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContact_R3.Focus()
        End If
    End Sub

    Private Sub TxtContact_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContact_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            dYears_R3.Focus()
        End If
    End Sub

    Private Sub DYears_R3_KeyDown(sender As Object, e As KeyEventArgs) Handles dYears_R3.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbxPrefix_R4.Focus()
        End If
    End Sub

    Private Sub CbxPrefix_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_R4.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_R4.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_R4.Focus()
        End If
    End Sub

    Private Sub TxtLastN_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_R4.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_R4.Focus()
        End If
    End Sub

    Private Sub DtpBirth_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_R4.Focus()
        End If
    End Sub

    Private Sub TxtTIN_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_R4.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            dGMI_R4.Focus()
        End If
    End Sub

    Private Sub DGMI_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles dGMI_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNo_R4.Focus()
        End If
    End Sub

    Private Sub TxtNo_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreet_R4.Focus()
        End If
    End Sub

    Private Sub TxtStreet_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreet_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangay_R4.Focus()
        End If
    End Sub

    Private Sub TxtBarangay_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangay_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddress_R4.Focus()
        End If
    End Sub

    Private Sub CbxAddress_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddress_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPosition_R4.Focus()
        End If
    End Sub

    Private Sub TxtPosition_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPosition_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContact_R4.Focus()
        End If
    End Sub

    Private Sub TxtContact_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContact_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            dYears_R4.Focus()
        End If
    End Sub

    Private Sub DYears_R4_KeyDown(sender As Object, e As KeyEventArgs) Handles dYears_R4.KeyDown
        If e.KeyCode = Keys.Enter Then
            CbxPrefix_R5.Focus()
        End If
    End Sub

    Private Sub CbxPrefix_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles CbxPrefix_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtFirstN_R5.Focus()
        End If
    End Sub

    Private Sub TxtFirstN_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtFirstN_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtMiddleN_R5.Focus()
        End If
    End Sub

    Private Sub TxtMiddleN_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtMiddleN_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtLastN_R5.Focus()
        End If
    End Sub

    Private Sub TxtLastN_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles TxtLastN_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxSuffix_R5.Focus()
        End If
    End Sub

    Private Sub CbxSuffix_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxSuffix_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            DtpBirth_R5.Focus()
        End If
    End Sub

    Private Sub DtpBirth_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles DtpBirth_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtTIN_R5.Focus()
        End If
    End Sub

    Private Sub TxtTIN_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtTIN_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtSSS_R5.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSSS_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            dGMI_R5.Focus()
        End If
    End Sub

    Private Sub DGMI_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles dGMI_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtNo_R5.Focus()
        End If
    End Sub

    Private Sub TxtNo_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtNo_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtStreet_R5.Focus()
        End If
    End Sub

    Private Sub TxtStreet_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtStreet_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtBarangay_R5.Focus()
        End If
    End Sub

    Private Sub TxtBarangay_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtBarangay_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAddress_R5.Focus()
        End If
    End Sub

    Private Sub CbxAddress_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAddress_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtPosition_R5.Focus()
        End If
    End Sub

    Private Sub TxtPosition_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtPosition_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtContact_R5.Focus()
        End If
    End Sub

    Private Sub TxtContact_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles txtContact_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            dYears_R5.Focus()
        End If
    End Sub

    Private Sub DYears_R5_KeyDown(sender As Object, e As KeyEventArgs) Handles dYears_R5.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxAgent.Focus()
        End If
    End Sub

    Private Sub CbxAgent_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgent.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbxAgent.Checked = True Then
                cbxAgentName.Focus()
            Else
                cbxMarketing.Focus()
            End If
        End If
    End Sub

    Private Sub CbxAgentName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxAgentName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtAgentContact.Focus()
        End If
    End Sub

    Private Sub TxtAgentContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtAgentContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxMarketing.Focus()
        End If
    End Sub

    Private Sub CbxMarketing_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarketing.KeyDown
        If e.KeyCode = Keys.Enter Then
            If cbxMarketing.Checked = True Then
                cbxMarketingName.Focus()
            Else
                cbxWalkIn.Focus()
            End If
        End If
    End Sub

    Private Sub CbxMarketingName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxMarketingName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtMarketingContact.Focus()
        End If
    End Sub

    Private Sub TxtMarketingContact_KeyDown(sender As Object, e As KeyEventArgs) Handles txtMarketingContact.KeyDown
        If e.KeyCode = Keys.Enter Then
            cbxWalkIn.Focus()
        End If
    End Sub

    Private Sub CbxWalkIn_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxWalkIn.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSave.Focus()
        End If
    End Sub
#End Region

#Region "Leaves"
    Private Sub TxtTradeName_Leave(sender As Object, e As EventArgs) Handles txtTradeName.Leave
        txtTradeName.Text = ReplaceText(txtTradeName.Text.Trim)
    End Sub

    Private Sub TxtNo_Leave(sender As Object, e As EventArgs) Handles txtNo.Leave
        txtNo.Text = ReplaceText(txtNo.Text.Trim)
    End Sub

    Private Sub TxtStreet_Leave(sender As Object, e As EventArgs) Handles txtStreet.Leave
        txtStreet.Text = ReplaceText(txtStreet.Text.Trim)
    End Sub

    Private Sub TxtBarangay_Leave(sender As Object, e As EventArgs) Handles txtBarangay.Leave
        txtBarangay.Text = ReplaceText(txtBarangay.Text.Trim)
    End Sub

    Private Sub CbxAddress_Leave(sender As Object, e As EventArgs) Handles cbxAddress.Leave
        cbxAddress.Text = ReplaceText(cbxAddress.Text.Trim)
    End Sub

    Private Sub TxtTIN_Leave(sender As Object, e As EventArgs) Handles txtTIN.Leave
        txtTIN.Text = ReplaceText(txtTIN.Text.Trim)
        If (txtTIN.Text.Length <> 9 And txtTIN.Text.Length > 0) Or (Not IsNumeric(txtTIN.Text) And txtTIN.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN.Focus()
        End If
    End Sub

    Private Sub TxtSSS_Leave(sender As Object, e As EventArgs) Handles txtSSS.Leave
        txtSSS.Text = ReplaceText(txtSSS.Text.Trim)
        If (txtSSS.Text.Length <> 10 And txtSSS.Text.Length > 0) Or (Not IsNumeric(txtSSS.Text) And txtSSS.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS.Focus()
        End If
    End Sub

    Private Sub TxtTelephone_Leave(sender As Object, e As EventArgs) Handles txtTelephone.Leave
        txtTelephone.Text = ReplaceText(txtTelephone.Text.Trim)
    End Sub

    Private Sub TxtEmail_Leave(sender As Object, e As EventArgs) Handles txtEmail.Leave
        txtEmail.Text = ReplaceText(txtEmail.Text.Trim)
    End Sub

    Private Sub TxtFax_Leave(sender As Object, e As EventArgs) Handles txtFax.Leave
        txtFax.Text = ReplaceText(txtFax.Text.Trim)
    End Sub

    Private Sub TxtWebsite_Leave(sender As Object, e As EventArgs) Handles txtWebsite.Leave
        txtWebsite.Text = ReplaceText(txtWebsite.Text.Trim)
    End Sub

    Private Sub CbxPrefix_R1_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_R1.Leave
        CbxPrefix_R1.Text = ReplaceText(CbxPrefix_R1.Text.Trim)
    End Sub

    Private Sub TxtFirstN_R1_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_R1.Leave
        TxtFirstN_R1.Text = ReplaceText(TxtFirstN_R1.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_R1_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_R1.Leave
        TxtMiddleN_R1.Text = ReplaceText(TxtMiddleN_R1.Text.Trim)
    End Sub

    Private Sub TxtLastN_R1_Leave(sender As Object, e As EventArgs) Handles TxtLastN_R1.Leave
        TxtLastN_R1.Text = ReplaceText(TxtLastN_R1.Text.Trim)
    End Sub

    Private Sub CbxSuffix_R1_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_R1.Leave
        cbxSuffix_R1.Text = ReplaceText(cbxSuffix_R1.Text.Trim)
    End Sub

    Private Sub TxtTIN_R1_Leave(sender As Object, e As EventArgs) Handles txtTIN_R1.Leave
        txtTIN_R1.Text = ReplaceText(txtTIN_R1.Text.Trim)
        If (txtTIN_R1.Text.Length <> 9 And txtTIN_R1.Text.Length > 0) Or (Not IsNumeric(txtTIN_R1.Text) And txtTIN_R1.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN_R1.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R1_Leave(sender As Object, e As EventArgs) Handles txtSSS_R1.Leave
        txtSSS_R1.Text = ReplaceText(txtSSS_R1.Text.Trim)
        If (txtSSS_R1.Text.Length <> 10 And txtSSS_R1.Text.Length > 0) Or (Not IsNumeric(txtSSS_R1.Text) And txtSSS_R1.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS_R1.Focus()
        End If
    End Sub

    Private Sub TxtNo_R1_Leave(sender As Object, e As EventArgs) Handles txtNo_R1.Leave
        txtNo_R1.Text = ReplaceText(txtNo_R1.Text.Trim)
    End Sub

    Private Sub TxtStreet_R1_Leave(sender As Object, e As EventArgs) Handles txtStreet_R1.Leave
        txtStreet_R1.Text = ReplaceText(txtStreet_R1.Text.Trim)
    End Sub

    Private Sub TxtBarangay_R1_Leave(sender As Object, e As EventArgs) Handles txtBarangay_R1.Leave
        txtBarangay_R1.Text = ReplaceText(txtBarangay_R1.Text.Trim)
    End Sub

    Private Sub CbxAddress_R1_Leave(sender As Object, e As EventArgs) Handles cbxAddress_R1.Leave
        cbxAddress_R1.Text = ReplaceText(cbxAddress_R1.Text.Trim)
    End Sub

    Private Sub TxtPosition_R1_Leave(sender As Object, e As EventArgs) Handles txtPosition_R1.Leave
        txtPosition_R1.Text = ReplaceText(txtPosition_R1.Text.Trim)
    End Sub

    Private Sub TxtContact_R1_Leave(sender As Object, e As EventArgs) Handles txtContact_R1.Leave
        txtContact_R1.Text = ReplaceText(txtContact_R1.Text.Trim)
    End Sub

    Private Sub CbxPrefix_R2_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_R2.Leave
        CbxPrefix_R2.Text = ReplaceText(CbxPrefix_R2.Text.Trim)
    End Sub

    Private Sub TxtFirstN_R2_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_R2.Leave
        TxtFirstN_R2.Text = ReplaceText(TxtFirstN_R2.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_R2_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_R2.Leave
        TxtMiddleN_R2.Text = ReplaceText(TxtMiddleN_R2.Text.Trim)
    End Sub

    Private Sub TxtLastN_R2_Leave(sender As Object, e As EventArgs) Handles TxtLastN_R2.Leave
        TxtLastN_R2.Text = ReplaceText(TxtLastN_R2.Text.Trim)
    End Sub

    Private Sub CbxSuffix_R2_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_R2.Leave
        cbxSuffix_R2.Text = ReplaceText(cbxSuffix_R2.Text.Trim)
    End Sub

    Private Sub TxtTIN_R2_Leave(sender As Object, e As EventArgs) Handles txtTIN_R2.Leave
        txtTIN_R2.Text = ReplaceText(txtTIN_R2.Text.Trim)
        If (txtTIN_R2.Text.Length <> 9 And txtTIN_R2.Text.Length > 0) Or (Not IsNumeric(txtTIN_R2.Text) And txtTIN_R2.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN_R2.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R2_Leave(sender As Object, e As EventArgs) Handles txtSSS_R2.Leave
        txtSSS_R2.Text = ReplaceText(txtSSS_R2.Text.Trim)
        If (txtSSS_R2.Text.Length <> 10 And txtSSS_R2.Text.Length > 0) Or (Not IsNumeric(txtSSS_R2.Text) And txtSSS_R2.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS_R2.Focus()
        End If
    End Sub

    Private Sub TxtNo_R2_Leave(sender As Object, e As EventArgs) Handles txtNo_R2.Leave
        txtNo_R2.Text = ReplaceText(txtNo_R2.Text.Trim)
    End Sub

    Private Sub TxtStreet_R2_Leave(sender As Object, e As EventArgs) Handles txtStreet_R2.Leave
        txtStreet_R2.Text = ReplaceText(txtStreet_R2.Text.Trim)
    End Sub

    Private Sub TxtBarangay_R2_Leave(sender As Object, e As EventArgs) Handles txtBarangay_R2.Leave
        txtBarangay_R2.Text = ReplaceText(txtBarangay_R2.Text.Trim)
    End Sub

    Private Sub CbxAddress_R2_Leave(sender As Object, e As EventArgs) Handles cbxAddress_R2.Leave
        cbxAddress_R2.Text = ReplaceText(cbxAddress_R2.Text.Trim)
    End Sub

    Private Sub TxtPosition_R2_Leave(sender As Object, e As EventArgs) Handles txtPosition_R2.Leave
        txtPosition_R2.Text = ReplaceText(txtPosition_R2.Text.Trim)
    End Sub

    Private Sub TxtContact_R2_Leave(sender As Object, e As EventArgs) Handles txtContact_R2.Leave
        txtContact_R2.Text = ReplaceText(txtContact_R2.Text.Trim)
    End Sub

    Private Sub CbxPrefix_R3_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_R3.Leave
        CbxPrefix_R3.Text = ReplaceText(CbxPrefix_R3.Text.Trim)
    End Sub

    Private Sub TxtFirstN_R3_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_R3.Leave
        TxtFirstN_R3.Text = ReplaceText(TxtFirstN_R3.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_R3_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_R3.Leave
        TxtMiddleN_R3.Text = ReplaceText(TxtMiddleN_R3.Text.Trim)
    End Sub

    Private Sub TxtLastN_R3_Leave(sender As Object, e As EventArgs) Handles TxtLastN_R3.Leave
        TxtLastN_R3.Text = ReplaceText(TxtLastN_R3.Text.Trim)
    End Sub

    Private Sub CbxSuffix_R3_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_R3.Leave
        cbxSuffix_R3.Text = ReplaceText(cbxSuffix_R3.Text.Trim)
    End Sub

    Private Sub TxtTIN_R3_Leave(sender As Object, e As EventArgs) Handles txtTIN_R3.Leave
        txtTIN_R3.Text = ReplaceText(txtTIN_R3.Text.Trim)
        If (txtTIN_R3.Text.Length <> 9 And txtTIN_R3.Text.Length > 0) Or (Not IsNumeric(txtTIN_R3.Text) And txtTIN_R3.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN_R3.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R3_Leave(sender As Object, e As EventArgs) Handles txtSSS_R3.Leave
        txtSSS_R3.Text = ReplaceText(txtSSS_R3.Text.Trim)
        If (txtSSS_R3.Text.Length <> 10 And txtSSS_R3.Text.Length > 0) Or (Not IsNumeric(txtSSS_R3.Text) And txtSSS_R3.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS_R3.Focus()
        End If
    End Sub

    Private Sub TxtNo_R3_Leave(sender As Object, e As EventArgs) Handles txtNo_R3.Leave
        txtNo_R3.Text = ReplaceText(txtNo_R3.Text.Trim)
    End Sub

    Private Sub TxtStreet_R3_Leave(sender As Object, e As EventArgs) Handles txtStreet_R3.Leave
        txtStreet_R3.Text = ReplaceText(txtStreet_R3.Text.Trim)
    End Sub

    Private Sub TxtBarangay_R3_Leave(sender As Object, e As EventArgs) Handles txtBarangay_R3.Leave
        txtBarangay_R3.Text = ReplaceText(txtBarangay_R3.Text.Trim)
    End Sub

    Private Sub CbxAddress_R3_Leave(sender As Object, e As EventArgs) Handles cbxAddress_R3.Leave
        cbxAddress_R3.Text = ReplaceText(cbxAddress_R3.Text.Trim)
    End Sub

    Private Sub TxtPosition_R3_Leave(sender As Object, e As EventArgs) Handles txtPosition_R3.Leave
        txtPosition_R3.Text = ReplaceText(txtPosition_R3.Text.Trim)
    End Sub

    Private Sub TxtContact_R3_Leave(sender As Object, e As EventArgs) Handles txtContact_R3.Leave
        txtContact_R3.Text = ReplaceText(txtContact_R3.Text.Trim)
    End Sub

    Private Sub CbxPrefix_R4_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_R4.Leave
        CbxPrefix_R4.Text = ReplaceText(CbxPrefix_R4.Text.Trim)
    End Sub

    Private Sub TxtFirstN_R4_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_R4.Leave
        TxtFirstN_R4.Text = ReplaceText(TxtFirstN_R4.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_R4_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_R4.Leave
        TxtMiddleN_R4.Text = ReplaceText(TxtMiddleN_R4.Text.Trim)
    End Sub

    Private Sub TxtLastN_R4_Leave(sender As Object, e As EventArgs) Handles TxtLastN_R4.Leave
        TxtLastN_R4.Text = ReplaceText(TxtLastN_R4.Text.Trim)
    End Sub

    Private Sub CbxSuffix_R4_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_R4.Leave
        cbxSuffix_R4.Text = ReplaceText(cbxSuffix_R4.Text.Trim)
    End Sub

    Private Sub TxtTIN_R4_Leave(sender As Object, e As EventArgs) Handles txtTIN_R4.Leave
        txtTIN_R4.Text = ReplaceText(txtTIN_R4.Text.Trim)
        If (txtTIN_R4.Text.Length <> 9 And txtTIN_R4.Text.Length > 0) Or (Not IsNumeric(txtTIN_R4.Text) And txtTIN_R4.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN_R4.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R4_Leave(sender As Object, e As EventArgs) Handles txtSSS_R4.Leave
        txtSSS_R4.Text = ReplaceText(txtSSS_R4.Text.Trim)
        If (txtSSS_R4.Text.Length <> 10 And txtSSS_R4.Text.Length > 0) Or (Not IsNumeric(txtSSS_R4.Text) And txtSSS_R4.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS_R4.Focus()
        End If
    End Sub

    Private Sub TxtNo_R4_Leave(sender As Object, e As EventArgs) Handles txtNo_R4.Leave
        txtNo_R4.Text = ReplaceText(txtNo_R4.Text.Trim)
    End Sub

    Private Sub TxtStreet_R4_Leave(sender As Object, e As EventArgs) Handles txtStreet_R4.Leave
        txtStreet_R4.Text = ReplaceText(txtStreet_R4.Text.Trim)
    End Sub

    Private Sub TxtBarangay_R4_Leave(sender As Object, e As EventArgs) Handles txtBarangay_R4.Leave
        txtBarangay_R4.Text = ReplaceText(txtBarangay_R4.Text.Trim)
    End Sub

    Private Sub CbxAddress_R4_Leave(sender As Object, e As EventArgs) Handles cbxAddress_R4.Leave
        cbxAddress_R4.Text = ReplaceText(cbxAddress_R4.Text.Trim)
    End Sub

    Private Sub TxtPosition_R4_Leave(sender As Object, e As EventArgs) Handles txtPosition_R4.Leave
        txtPosition_R4.Text = ReplaceText(txtPosition_R4.Text.Trim)
    End Sub

    Private Sub TxtContact_R4_Leave(sender As Object, e As EventArgs) Handles txtContact_R4.Leave
        txtContact_R4.Text = ReplaceText(txtContact_R4.Text.Trim)
    End Sub

    Private Sub CbxPrefix_R5_Leave(sender As Object, e As EventArgs) Handles CbxPrefix_R5.Leave
        CbxPrefix_R5.Text = ReplaceText(CbxPrefix_R5.Text.Trim)
    End Sub

    Private Sub TxtFirstN_R5_Leave(sender As Object, e As EventArgs) Handles TxtFirstN_R5.Leave
        TxtFirstN_R5.Text = ReplaceText(TxtFirstN_R5.Text.Trim)
    End Sub

    Private Sub TxtMiddleN_R5_Leave(sender As Object, e As EventArgs) Handles TxtMiddleN_R5.Leave
        TxtMiddleN_R5.Text = ReplaceText(TxtMiddleN_R5.Text.Trim)
    End Sub

    Private Sub TxtLastN_R5_Leave(sender As Object, e As EventArgs) Handles TxtLastN_R5.Leave
        TxtLastN_R5.Text = ReplaceText(TxtLastN_R5.Text.Trim)
    End Sub

    Private Sub CbxSuffix_R5_Leave(sender As Object, e As EventArgs) Handles cbxSuffix_R5.Leave
        cbxSuffix_R5.Text = ReplaceText(cbxSuffix_R5.Text.Trim)
    End Sub

    Private Sub TxtTIN_R5_Leave(sender As Object, e As EventArgs) Handles txtTIN_R5.Leave
        txtTIN_R5.Text = ReplaceText(txtTIN_R5.Text.Trim)
        If (txtTIN_R5.Text.Length <> 9 And txtTIN_R5.Text.Length > 0) Or (Not IsNumeric(txtTIN_R5.Text) And txtTIN_R5.Text.Length > 0) Then
            MsgBox("Incorrect TIN format, should be 9 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtTIN_R5.Focus()
        End If
    End Sub

    Private Sub TxtSSS_R5_Leave(sender As Object, e As EventArgs) Handles txtSSS_R5.Leave
        txtSSS_R5.Text = ReplaceText(txtSSS_R5.Text.Trim)
        If (txtSSS_R5.Text.Length <> 10 And txtSSS_R5.Text.Length > 0) Or (Not IsNumeric(txtSSS_R5.Text) And txtSSS_R5.Text.Length > 0) Then
            MsgBox("Incorrect SSS format, should be 10 digit with no special characters and space.", MsgBoxStyle.Information, "Info")
            txtSSS_R5.Focus()
        End If
    End Sub

    Private Sub TxtNo_R5_Leave(sender As Object, e As EventArgs) Handles txtNo_R5.Leave
        txtNo_R5.Text = ReplaceText(txtNo_R5.Text.Trim)
    End Sub

    Private Sub TxtStreet_R5_Leave(sender As Object, e As EventArgs) Handles txtStreet_R5.Leave
        txtStreet_R5.Text = ReplaceText(txtStreet_R5.Text.Trim)
    End Sub

    Private Sub TxtBarangay_R5_Leave(sender As Object, e As EventArgs) Handles txtBarangay_R5.Leave
        txtBarangay_R5.Text = ReplaceText(txtBarangay_R5.Text.Trim)
    End Sub

    Private Sub CbxAddress_R5_Leave(sender As Object, e As EventArgs) Handles cbxAddress_R5.Leave
        cbxAddress_R5.Text = ReplaceText(cbxAddress_R5.Text.Trim)
    End Sub

    Private Sub TxtPosition_R5_Leave(sender As Object, e As EventArgs) Handles txtPosition_R5.Leave
        txtPosition_R5.Text = ReplaceText(txtPosition_R5.Text.Trim)
    End Sub

    Private Sub TxtContact_R5_Leave(sender As Object, e As EventArgs) Handles txtContact_R5.Leave
        txtContact_R5.Text = ReplaceText(txtContact_R5.Text.Trim)
    End Sub

    Private Sub TxtBank_1_Leave(sender As Object, e As EventArgs) Handles txtBank_1.Leave
        txtBank_1.Text = ReplaceText(txtBank_1.Text.Trim)
    End Sub

    Private Sub TxtBranch_1_Leave(sender As Object, e As EventArgs) Handles txtBranch_1.Leave
        txtBranch_1.Text = ReplaceText(txtBranch_1.Text.Trim)
    End Sub

    Private Sub TxtSA_1_Leave(sender As Object, e As EventArgs) Handles txtSA_1.Leave
        txtSA_1.Text = ReplaceText(txtSA_1.Text.Trim)
    End Sub

    Private Sub TxtBankRemarks_1_Leave(sender As Object, e As EventArgs) Handles txtBankRemarks_1.Leave
        txtBankRemarks_1.Text = ReplaceText(txtBankRemarks_1.Text.Trim)
    End Sub

    Private Sub TxtBank_2_Leave(sender As Object, e As EventArgs) Handles txtBank_2.Leave
        txtBank_2.Text = ReplaceText(txtBank_2.Text.Trim)
    End Sub

    Private Sub TxtBranch_2_Leave(sender As Object, e As EventArgs) Handles txtBranch_2.Leave
        txtBranch_2.Text = ReplaceText(txtBranch_2.Text.Trim)
    End Sub

    Private Sub TxtSA_2_Leave(sender As Object, e As EventArgs) Handles txtSA_2.Leave
        txtSA_2.Text = ReplaceText(txtSA_2.Text.Trim)
    End Sub

    Private Sub TxtBankRemarks_2_Leave(sender As Object, e As EventArgs) Handles txtBankRemarks_2.Leave
        txtBankRemarks_2.Text = ReplaceText(txtBankRemarks_2.Text.Trim)
    End Sub

    Private Sub CbxAgentName_Leave(sender As Object, e As EventArgs) Handles cbxAgentName.Leave
        cbxAgentName.Text = ReplaceText(cbxAgentName.Text.Trim)
    End Sub

    Private Sub TxtAgentContact_Leave(sender As Object, e As EventArgs) Handles txtAgentContact.Leave
        txtAgentContact.Text = ReplaceText(txtAgentContact.Text.Trim)
    End Sub

    Private Sub CbxMarketingName_Leave(sender As Object, e As EventArgs) Handles cbxMarketingName.Leave
        cbxMarketingName.Text = ReplaceText(cbxMarketingName.Text.Trim)
    End Sub

    Private Sub TxtMarketingContact_Leave(sender As Object, e As EventArgs) Handles txtMarketingContact.Leave
        txtMarketingContact.Text = ReplaceText(txtMarketingContact.Text.Trim)
    End Sub

    Private Sub CbxWalkInType_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxWalkInType.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtWalkInOthers.Focus()
        End If
    End Sub

    Private Sub CbxDealerName_KeyDown(sender As Object, e As KeyEventArgs) Handles cbxDealerName.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDealersContact.Focus()
        End If
    End Sub

    Private Sub CbxWalkInType_Leave(sender As Object, e As EventArgs) Handles cbxWalkInType.Leave
        cbxWalkInType.Text = ReplaceText(cbxWalkInType.Text.Trim)
    End Sub

    Private Sub TxtWalkInOthers_Leave(sender As Object, e As EventArgs) Handles txtWalkInOthers.Leave
        txtWalkInOthers.Text = ReplaceText(txtWalkInOthers.Text.Trim)
    End Sub

    Private Sub CbxDealerName_Leave(sender As Object, e As EventArgs) Handles cbxDealerName.Leave
        cbxDealerName.Text = ReplaceText(cbxDealerName.Text.Trim)
    End Sub

    Private Sub TxtDealersContact_Leave(sender As Object, e As EventArgs) Handles txtDealersContact.Leave
        txtDealersContact.Text = ReplaceText(txtDealersContact.Text.Trim)
    End Sub
#End Region

    '***Text Change - Error prevention
    Private Sub TxtBank_1_TextChanged(sender As Object, e As EventArgs) Handles txtBank_1.TextChanged
        If txtBank_1.Text.Trim = "" Then
            txtBranch_1.Enabled = False
            cbxSA_1.Enabled = False
            cbxCA_1.Enabled = False
            txtSA_1.Enabled = False
            dAverageBalance_1.Enabled = False
            dPresentBalance_1.Enabled = False
            dtpOpened_1.Enabled = False
            dtpOpened_1.CustomFormat = ""
            txtBankRemarks_1.Enabled = False
            txtBank_2.Enabled = False

            txtBranch_2.Enabled = False
            cbxSA_2.Enabled = False
            cbxCA_2.Enabled = False
            txtSA_2.Enabled = False
            dAverageBalance_2.Enabled = False
            dPresentBalance_2.Enabled = False
            dtpOpened_2.Enabled = False
            dtpOpened_2.CustomFormat = ""
            txtBankRemarks_2.Enabled = False

            vBranch_1 = txtBranch_1.Text
            vcSA_1 = cbxSA_1.Checked
            vcCA_1 = cbxCA_1.Checked
            vSA_1 = txtSA_1.Text
            vAverageBalance_1 = dAverageBalance_1.Value
            vPresentBalance_1 = dPresentBalance_1.Value
            vBankRemarks_1 = txtBankRemarks_1.Text

            vBank_2 = txtBank_2.Text

            txtBranch_1.Text = ""
            cbxSA_1.Checked = False
            cbxCA_1.Checked = False
            txtSA_1.Text = ""
            dAverageBalance_1.Value = 0
            dPresentBalance_1.Value = 0
            txtBankRemarks_1.Text = ""

            txtBank_2.Text = ""
        Else
            txtBranch_1.Enabled = True
            cbxSA_1.Enabled = True
            cbxCA_1.Enabled = True
            txtSA_1.Enabled = True
            dAverageBalance_1.Enabled = True
            dPresentBalance_1.Enabled = True
            dtpOpened_1.Enabled = True
            dtpOpened_1.CustomFormat = "MMM. dd, yyyy"
            txtBankRemarks_1.Enabled = True
            txtBank_2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vBranch_1 = "" And vcSA_1 = False And vcCA_1 = False And vSA_1 = "" And vAverageBalance_1 = 0 And vPresentBalance_1 = 0 And vBankRemarks_1 = "" And vBank_2 = "" Then
            Else
                If txtBranch_1.Text = "" Then
                    txtBranch_1.Text = vBranch_1
                End If
                If cbxSA_1.Checked = False Then
                    cbxSA_1.Checked = vcSA_1
                End If
                If cbxCA_1.Checked = False Then
                    cbxCA_1.Checked = vcCA_1
                End If
                If txtSA_1.Text = "" Then
                    txtSA_1.Text = vSA_1
                End If
                If dAverageBalance_1.Value = 0 Then
                    dAverageBalance_1.Value = vAverageBalance_1
                End If
                If dPresentBalance_1.Value = 0 Then
                    dPresentBalance_1.Value = vPresentBalance_1
                End If
                If txtBankRemarks_1.Text = "" Then
                    txtBankRemarks_1.Text = vBankRemarks_1
                End If

                If txtBank_2.Text = "" Then
                    txtBank_2.Text = vBank_2
                End If
            End If
        End If
    End Sub

    Private Sub TxtBank_2_TextChanged(sender As Object, e As EventArgs) Handles txtBank_2.TextChanged
        If txtBank_2.Text.Trim = "" Then
            txtBranch_2.Enabled = False
            cbxSA_2.Enabled = False
            cbxCA_2.Enabled = False
            txtSA_2.Enabled = False
            dAverageBalance_2.Enabled = False
            dPresentBalance_2.Enabled = False
            dtpOpened_2.Enabled = False
            dtpOpened_2.CustomFormat = ""
            txtBankRemarks_2.Enabled = False

            vBranch_2 = txtBranch_2.Text
            vcSA_2 = cbxSA_2.Checked
            vcCA_2 = cbxCA_2.Checked
            vSA_2 = txtSA_2.Text
            vAverageBalance_2 = dAverageBalance_2.Value
            vPresentBalance_2 = dPresentBalance_2.Value
            vBankRemarks_2 = txtBankRemarks_2.Text

            txtBranch_2.Text = ""
            cbxSA_2.Checked = False
            cbxCA_2.Checked = False
            txtSA_2.Text = ""
            dAverageBalance_2.Value = 0
            dPresentBalance_2.Value = 0
            txtBankRemarks_2.Text = ""
        Else
            txtBranch_2.Enabled = True
            cbxSA_2.Enabled = True
            cbxCA_2.Enabled = True
            txtSA_2.Enabled = True
            dAverageBalance_2.Enabled = True
            dPresentBalance_2.Enabled = True
            dtpOpened_2.Enabled = True
            dtpOpened_2.CustomFormat = "MMM. dd, yyyy"
            txtBankRemarks_2.Enabled = True

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vBranch_2 = "" And vcSA_2 = False And vcCA_2 = False And vSA_2 = "" And vAverageBalance_2 = 0 And vPresentBalance_2 = 0 And vBankRemarks_2 = "" Then
            Else
                If txtBranch_2.Text = "" Then
                    txtBranch_2.Text = vBranch_2
                End If
                If cbxSA_2.Checked = False Then
                    cbxSA_2.Checked = vcSA_2
                End If
                If cbxCA_2.Checked = False Then
                    cbxCA_2.Checked = vcCA_2
                End If
                If txtSA_2.Text = "" Then
                    txtSA_2.Text = vSA_2
                End If
                If dAverageBalance_2.Value = 0 Then
                    dAverageBalance_2.Value = vAverageBalance_2
                End If
                If dPresentBalance_2.Value = 0 Then
                    dPresentBalance_2.Value = vPresentBalance_2
                End If
                If txtBankRemarks_2.Text = "" Then
                    txtBankRemarks_2.Text = vBankRemarks_2
                End If
            End If
        End If
    End Sub

    Private Sub DtpIncorporation_Click(sender As Object, e As EventArgs) Handles dtpIncorporation.Click
        dtpIncorporation.CustomFormat = "MMMM dd, yyyy"
    End Sub

    Private Sub DtpOpened_1_Click(sender As Object, e As EventArgs) Handles dtpOpened_1.Click
        dtpOpened_1.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub DtpOpened_2_Click(sender As Object, e As EventArgs) Handles dtpOpened_2.Click
        dtpOpened_2.CustomFormat = "MMM. dd, yyyy"
    End Sub

    Private Sub TxtFirstN_R1_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_R1.TextChanged
        If TxtFirstN_R1.Text.Trim = "" Then
            TxtMiddleN_R1.Enabled = False
            TxtLastN_R1.Enabled = False
            cbxSuffix_R1.Enabled = False
            DtpBirth_R1.Enabled = False
            txtTIN_R1.Enabled = False
            txtSSS_R1.Enabled = False
            dGMI_R1.Enabled = False
            txtNo_R1.Enabled = False
            txtStreet_R1.Enabled = False
            txtBarangay_R1.Enabled = False
            cbxAddress_R1.Enabled = False
            txtPosition_R1.Enabled = False
            txtContact_R1.Enabled = False
            dYears_R1.Enabled = False
            btnAttach_R1.Enabled = False
            CbxPrefix_R2.Enabled = False
            TxtFirstN_R2.Enabled = False
            DtpBirth_R1.CustomFormat = ""

            vMiddleN_R1 = TxtMiddleN_R1.Text
            vLastN_R1 = TxtLastN_R1.Text
            vSuffix_R1 = cbxSuffix_R1.Text
            vTIN_R1 = txtTIN_R1.Text
            vSSS_R1 = txtSSS_R1.Text
            vGMI_R1 = dGMI_R1.Value
            vNo_R1 = txtNo_R1.Text
            vStreet_R1 = txtStreet_R1.Text
            vBarangay_R1 = txtBarangay_R1.Text
            vAddress_R1 = cbxAddress_R1.Text
            vPosition_R1 = txtPosition_R1.Text
            vContact_R1 = txtContact_R1.Text
            vYears_R1 = dYears_R1.Value
            vPrefix_R2 = CbxPrefix_R2.Text
            vFirstN_R2 = TxtFirstN_R2.Text

            TxtMiddleN_R1.Text = ""
            TxtLastN_R1.Text = ""
            cbxSuffix_R1.Text = ""
            txtTIN_R1.Text = ""
            txtSSS_R1.Text = ""
            txtNo_R1.Text = ""
            txtStreet_R1.Text = ""
            txtBarangay_R1.Text = ""
            cbxAddress_R1.Text = ""
            txtPosition_R1.Text = ""
            txtContact_R1.Text = ""
            dGMI_R1.Value = 0
            dYears_R1.Value = 0
            CbxPrefix_R2.Text = ""
            TxtFirstN_R2.Text = ""
        Else
            TxtMiddleN_R1.Enabled = True
            TxtLastN_R1.Enabled = True
            cbxSuffix_R1.Enabled = True
            DtpBirth_R1.Enabled = True
            txtTIN_R1.Enabled = True
            txtSSS_R1.Enabled = True
            txtNo_R1.Enabled = True
            txtStreet_R1.Enabled = True
            txtBarangay_R1.Enabled = True
            cbxAddress_R1.Enabled = True
            txtPosition_R1.Enabled = True
            txtContact_R1.Enabled = True
            CbxPrefix_R2.Enabled = True
            TxtFirstN_R2.Enabled = True
            dGMI_R1.Enabled = True
            dYears_R1.Enabled = True
            btnAttach_R1.Enabled = True
            DtpBirth_R1.CustomFormat = "MMM. dd, yyyy"

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vGMI_R1 = 0 And vYears_R1 = 0 And vMiddleN_R1 = "" And vLastN_R1 = "" And vSuffix_R1 = "" And vTIN_R1 = "" And vSSS_R1 = "" And vNo_R1 = "" And vStreet_R1 = "" And vBarangay_R1 = "" And vAddress_R1 = "" And vPosition_R1 = "" And vContact_R1 = "" And vPrefix_R2 = "" And vFirstN_R2 = "" Then
            Else
                If TxtMiddleN_R1.Text = "" Then
                    TxtMiddleN_R1.Text = vMiddleN_R1
                End If
                If TxtLastN_R1.Text = "" Then
                    TxtLastN_R1.Text = vLastN_R1
                End If
                If cbxSuffix_R1.Text = "" Then
                    cbxSuffix_R1.Text = vSuffix_R1
                End If
                If txtTIN_R1.Text = "" Then
                    txtTIN_R1.Text = vTIN_R1
                End If
                If txtSSS_R1.Text = "" Then
                    txtSSS_R1.Text = vSSS_R1
                End If
                If txtNo_R1.Text = "" Then
                    txtNo_R1.Text = vNo_R1
                End If
                If txtStreet_R1.Text = "" Then
                    txtStreet_R1.Text = vStreet_R1
                End If
                If txtBarangay_R1.Text = "" Then
                    txtBarangay_R1.Text = vBarangay_R1
                End If
                If cbxAddress_R1.Text = "" Then
                    cbxAddress_R1.Text = vAddress_R1
                End If
                If txtPosition_R1.Text = "" Then
                    txtPosition_R1.Text = vPosition_R1
                End If
                If txtContact_R1.Text = "" Then
                    txtContact_R1.Text = vContact_R1
                End If
                If CbxPrefix_R2.Text = "" Then
                    CbxPrefix_R2.Text = vPrefix_R2
                End If
                If TxtFirstN_R2.Text = "" Then
                    TxtFirstN_R2.Text = vFirstN_R2
                End If
                If dGMI_R1.Value = 0 Then
                    dGMI_R1.Text = vGMI_R1
                End If
                If dYears_R1.Value = 0 Then
                    dYears_R1.Text = vYears_R1
                End If
            End If
        End If
    End Sub

    Private Sub TxtFirstN_R2_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_R2.TextChanged
        If TxtFirstN_R2.Text.Trim = "" Then
            TxtMiddleN_R2.Enabled = False
            TxtLastN_R2.Enabled = False
            cbxSuffix_R2.Enabled = False
            DtpBirth_R2.Enabled = False
            txtTIN_R2.Enabled = False
            txtSSS_R2.Enabled = False
            dGMI_R2.Enabled = False
            txtNo_R2.Enabled = False
            txtStreet_R2.Enabled = False
            txtBarangay_R2.Enabled = False
            cbxAddress_R2.Enabled = False
            txtPosition_R2.Enabled = False
            txtContact_R2.Enabled = False
            dYears_R2.Enabled = False
            btnAttach_R2.Enabled = False
            CbxPrefix_R3.Enabled = False
            TxtFirstN_R3.Enabled = False
            DtpBirth_R2.CustomFormat = ""

            vMiddleN_R2 = TxtMiddleN_R2.Text
            vLastN_R2 = TxtLastN_R2.Text
            vSuffix_R2 = cbxSuffix_R2.Text
            vTIN_R2 = txtTIN_R2.Text
            vSSS_R2 = txtSSS_R2.Text
            vNo_R2 = txtNo_R2.Text
            vStreet_R2 = txtStreet_R2.Text
            vBarangay_R2 = txtBarangay_R2.Text
            vAddress_R2 = cbxAddress_R2.Text
            vPosition_R2 = txtPosition_R2.Text
            vContact_R2 = txtContact_R2.Text
            vGMI_R2 = dGMI_R2.Value
            vYears_R2 = dYears_R2.Value
            vPrefix_R3 = CbxPrefix_R3.Text
            vFirstN_R3 = TxtFirstN_R3.Text

            TxtMiddleN_R2.Text = ""
            TxtLastN_R2.Text = ""
            cbxSuffix_R2.Text = ""
            txtTIN_R2.Text = ""
            txtSSS_R2.Text = ""
            txtNo_R2.Text = ""
            txtStreet_R2.Text = ""
            txtBarangay_R2.Text = ""
            cbxAddress_R2.Text = ""
            txtPosition_R2.Text = ""
            txtContact_R2.Text = ""
            dGMI_R2.Value = 0
            dYears_R2.Value = 0
            CbxPrefix_R3.Text = ""
            TxtFirstN_R3.Text = ""
        Else
            TxtMiddleN_R2.Enabled = True
            TxtLastN_R2.Enabled = True
            cbxSuffix_R2.Enabled = True
            DtpBirth_R2.Enabled = True
            txtTIN_R2.Enabled = True
            txtSSS_R2.Enabled = True
            txtNo_R2.Enabled = True
            txtStreet_R2.Enabled = True
            txtBarangay_R2.Enabled = True
            cbxAddress_R2.Enabled = True
            txtPosition_R2.Enabled = True
            txtContact_R2.Enabled = True
            dGMI_R2.Enabled = True
            dYears_R2.Enabled = True
            btnAttach_R2.Enabled = True
            CbxPrefix_R3.Enabled = True
            TxtFirstN_R3.Enabled = True
            DtpBirth_R2.CustomFormat = "MMM. dd, yyyy"

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vGMI_R2 = 0 And vYears_R2 = 0 And vMiddleN_R2 = "" And vLastN_R2 = "" And vSuffix_R2 = "" And vTIN_R2 = "" And vSSS_R2 = "" And vNo_R2 = "" And vStreet_R2 = "" And vBarangay_R2 = "" And vAddress_R2 = "" And vPosition_R2 = "" And vContact_R2 = "" And vPrefix_R3 = "" And vFirstN_R3 = "" Then
            Else
                If TxtMiddleN_R2.Text = "" Then
                    TxtMiddleN_R2.Text = vMiddleN_R2
                End If
                If TxtLastN_R2.Text = "" Then
                    TxtLastN_R2.Text = vLastN_R2
                End If
                If cbxSuffix_R2.Text = "" Then
                    cbxSuffix_R2.Text = vSuffix_R2
                End If
                If txtTIN_R2.Text = "" Then
                    txtTIN_R2.Text = vTIN_R2
                End If
                If txtSSS_R2.Text = "" Then
                    txtSSS_R2.Text = vSSS_R2
                End If
                If txtNo_R2.Text = "" Then
                    txtNo_R2.Text = vNo_R2
                End If
                If txtStreet_R2.Text = "" Then
                    txtStreet_R2.Text = vStreet_R2
                End If
                If txtBarangay_R2.Text = "" Then
                    txtBarangay_R2.Text = vBarangay_R2
                End If
                If cbxAddress_R2.Text = "" Then
                    cbxAddress_R2.Text = vAddress_R2
                End If
                If txtPosition_R2.Text = "" Then
                    txtPosition_R2.Text = vPosition_R2
                End If
                If txtContact_R2.Text = "" Then
                    txtContact_R2.Text = vContact_R2
                End If
                If dGMI_R2.Value = 0 Then
                    dGMI_R2.Text = vGMI_R2
                End If
                If dYears_R2.Value = 0 Then
                    dYears_R2.Text = vYears_R2
                End If
                If CbxPrefix_R3.Text = "" Then
                    CbxPrefix_R3.Text = vPrefix_R3
                End If
                If TxtFirstN_R3.Text = "" Then
                    TxtFirstN_R3.Text = vFirstN_R3
                End If
            End If
        End If
    End Sub

    Private Sub TxtFirstN_R3_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_R3.TextChanged
        If TxtFirstN_R3.Text.Trim = "" Then
            TxtMiddleN_R3.Enabled = False
            TxtLastN_R3.Enabled = False
            cbxSuffix_R3.Enabled = False
            DtpBirth_R3.Enabled = False
            txtTIN_R3.Enabled = False
            txtSSS_R3.Enabled = False
            dGMI_R3.Enabled = False
            txtNo_R3.Enabled = False
            txtStreet_R3.Enabled = False
            txtBarangay_R3.Enabled = False
            cbxAddress_R3.Enabled = False
            txtPosition_R3.Enabled = False
            txtContact_R3.Enabled = False
            dYears_R3.Enabled = False
            btnAttach_R3.Enabled = False
            CbxPrefix_R4.Enabled = False
            TxtFirstN_R4.Enabled = False
            DtpBirth_R3.CustomFormat = ""

            vMiddleN_R3 = TxtMiddleN_R3.Text
            vLastN_R3 = TxtLastN_R3.Text
            vSuffix_R3 = cbxSuffix_R3.Text
            vTIN_R3 = txtTIN_R3.Text
            vSSS_R3 = txtSSS_R3.Text
            vNo_R3 = txtNo_R3.Text
            vStreet_R3 = txtStreet_R3.Text
            vBarangay_R3 = txtBarangay_R3.Text
            vAddress_R3 = cbxAddress_R3.Text
            vPosition_R3 = txtPosition_R3.Text
            vContact_R3 = txtContact_R3.Text
            vGMI_R3 = dGMI_R3.Value
            vYears_R3 = dYears_R3.Value
            vPrefix_R4 = CbxPrefix_R4.Text
            vFirstN_R4 = TxtFirstN_R4.Text

            TxtMiddleN_R3.Text = ""
            TxtLastN_R3.Text = ""
            cbxSuffix_R3.Text = ""
            txtTIN_R3.Text = ""
            txtSSS_R3.Text = ""
            txtNo_R3.Text = ""
            txtStreet_R3.Text = ""
            txtBarangay_R3.Text = ""
            cbxAddress_R3.Text = ""
            txtPosition_R3.Text = ""
            txtContact_R3.Text = ""
            dGMI_R3.Value = 0
            dYears_R3.Value = 0
            CbxPrefix_R4.Text = ""
            TxtFirstN_R4.Text = ""
        Else
            TxtMiddleN_R3.Enabled = True
            TxtLastN_R3.Enabled = True
            cbxSuffix_R3.Enabled = True
            DtpBirth_R3.Enabled = True
            txtTIN_R3.Enabled = True
            txtSSS_R3.Enabled = True
            txtNo_R3.Enabled = True
            txtStreet_R3.Enabled = True
            txtBarangay_R3.Enabled = True
            cbxAddress_R3.Enabled = True
            txtPosition_R3.Enabled = True
            txtContact_R3.Enabled = True
            dGMI_R3.Enabled = True
            dYears_R3.Enabled = True
            btnAttach_R3.Enabled = True
            CbxPrefix_R4.Enabled = True
            TxtFirstN_R4.Enabled = True
            DtpBirth_R3.CustomFormat = "MMM. dd, yyyy"

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vGMI_R3 = 0 And vYears_R3 = 0 And vMiddleN_R3 = "" And vLastN_R3 = "" And vSuffix_R3 = "" And vTIN_R3 = "" And vSSS_R3 = "" And vNo_R3 = "" And vStreet_R3 = "" And vBarangay_R3 = "" And vAddress_R3 = "" And vPosition_R3 = "" And vContact_R3 = "" And vPrefix_R4 = "" And vFirstN_R4 = "" Then
            Else
                If TxtMiddleN_R3.Text = "" Then
                    TxtMiddleN_R3.Text = vMiddleN_R3
                End If
                If TxtLastN_R3.Text = "" Then
                    TxtLastN_R3.Text = vLastN_R3
                End If
                If cbxSuffix_R3.Text = "" Then
                    cbxSuffix_R3.Text = vSuffix_R3
                End If
                If txtTIN_R3.Text = "" Then
                    txtTIN_R3.Text = vTIN_R3
                End If
                If txtSSS_R3.Text = "" Then
                    txtSSS_R3.Text = vSSS_R3
                End If
                If txtNo_R3.Text = "" Then
                    txtNo_R3.Text = vNo_R3
                End If
                If txtStreet_R3.Text = "" Then
                    txtStreet_R3.Text = vStreet_R3
                End If
                If txtBarangay_R3.Text = "" Then
                    txtBarangay_R3.Text = vBarangay_R3
                End If
                If cbxAddress_R3.Text = "" Then
                    cbxAddress_R3.Text = vAddress_R3
                End If
                If txtPosition_R3.Text = "" Then
                    txtPosition_R3.Text = vPosition_R3
                End If
                If txtContact_R3.Text = "" Then
                    txtContact_R3.Text = vContact_R3
                End If
                If dGMI_R3.Value = 0 Then
                    dGMI_R3.Text = vGMI_R3
                End If
                If dYears_R3.Value = 0 Then
                    dYears_R3.Text = vYears_R3
                End If
                If CbxPrefix_R4.Text = "" Then
                    CbxPrefix_R4.Text = vPrefix_R4
                End If
                If TxtFirstN_R4.Text = "" Then
                    TxtFirstN_R4.Text = vFirstN_R4
                End If
            End If
        End If
    End Sub

    Private Sub TxtFirstN_R4_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_R4.TextChanged
        If TxtFirstN_R4.Text.Trim = "" Then
            TxtMiddleN_R4.Enabled = False
            TxtLastN_R4.Enabled = False
            cbxSuffix_R4.Enabled = False
            DtpBirth_R4.Enabled = False
            txtTIN_R4.Enabled = False
            txtSSS_R4.Enabled = False
            dGMI_R4.Enabled = False
            txtNo_R4.Enabled = False
            txtStreet_R4.Enabled = False
            txtBarangay_R4.Enabled = False
            cbxAddress_R4.Enabled = False
            txtPosition_R4.Enabled = False
            txtContact_R4.Enabled = False
            dYears_R4.Enabled = False
            btnAttach_R4.Enabled = False
            CbxPrefix_R5.Enabled = False
            TxtFirstN_R5.Enabled = False
            DtpBirth_R4.CustomFormat = ""

            vMiddleN_R4 = TxtMiddleN_R4.Text
            vLastN_R4 = TxtLastN_R4.Text
            vSuffix_R4 = cbxSuffix_R4.Text
            vTIN_R4 = txtTIN_R4.Text
            vSSS_R4 = txtSSS_R4.Text
            vNo_R4 = txtNo_R4.Text
            vStreet_R4 = txtStreet_R4.Text
            vBarangay_R4 = txtBarangay_R4.Text
            vAddress_R4 = cbxAddress_R4.Text
            vPosition_R4 = txtPosition_R4.Text
            vContact_R4 = txtContact_R4.Text
            vGMI_R4 = dGMI_R4.Value
            vYears_R4 = dYears_R4.Value
            vPrefix_R5 = CbxPrefix_R5.Text
            vFirstN_R5 = TxtFirstN_R5.Text

            TxtMiddleN_R4.Text = ""
            TxtLastN_R4.Text = ""
            cbxSuffix_R4.Text = ""
            txtTIN_R4.Text = ""
            txtSSS_R4.Text = ""
            txtNo_R4.Text = ""
            txtStreet_R4.Text = ""
            txtBarangay_R4.Text = ""
            cbxAddress_R4.Text = ""
            txtPosition_R4.Text = ""
            txtContact_R4.Text = ""
            dGMI_R4.Value = 0
            dYears_R4.Value = 0
            CbxPrefix_R5.Text = ""
            TxtFirstN_R5.Text = ""
        Else
            TxtMiddleN_R4.Enabled = True
            TxtLastN_R4.Enabled = True
            cbxSuffix_R4.Enabled = True
            DtpBirth_R4.Enabled = True
            txtTIN_R4.Enabled = True
            txtSSS_R4.Enabled = True
            txtNo_R4.Enabled = True
            txtStreet_R4.Enabled = True
            txtBarangay_R4.Enabled = True
            cbxAddress_R4.Enabled = True
            txtPosition_R4.Enabled = True
            txtContact_R4.Enabled = True
            dGMI_R4.Enabled = True
            dYears_R4.Enabled = True
            btnAttach_R4.Enabled = True
            CbxPrefix_R5.Enabled = True
            TxtFirstN_R5.Enabled = True
            DtpBirth_R4.CustomFormat = "MMM. dd, yyyy"

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vGMI_R4 = 0 And vYears_R4 = 0 And vMiddleN_R4 = "" And vLastN_R4 = "" And vSuffix_R4 = "" And vTIN_R4 = "" And vSSS_R4 = "" And vNo_R4 = "" And vStreet_R4 = "" And vBarangay_R4 = "" And vAddress_R4 = "" And vPosition_R4 = "" And vContact_R4 = "" And vPrefix_R5 = "" And vFirstN_R5 = "" Then
            Else
                If TxtMiddleN_R4.Text = "" Then
                    TxtMiddleN_R4.Text = vMiddleN_R4
                End If
                If TxtLastN_R4.Text = "" Then
                    TxtLastN_R4.Text = vLastN_R4
                End If
                If cbxSuffix_R4.Text = "" Then
                    cbxSuffix_R4.Text = vSuffix_R4
                End If
                If txtTIN_R4.Text = "" Then
                    txtTIN_R4.Text = vTIN_R4
                End If
                If txtSSS_R4.Text = "" Then
                    txtSSS_R4.Text = vSSS_R4
                End If
                If txtNo_R4.Text = "" Then
                    txtNo_R4.Text = vNo_R4
                End If
                If txtStreet_R4.Text = "" Then
                    txtStreet_R4.Text = vStreet_R4
                End If
                If txtBarangay_R4.Text = "" Then
                    txtBarangay_R4.Text = vBarangay_R4
                End If
                If cbxAddress_R4.Text = "" Then
                    cbxAddress_R4.Text = vAddress_R4
                End If
                If txtPosition_R4.Text = "" Then
                    txtPosition_R4.Text = vPosition_R4
                End If
                If txtContact_R4.Text = "" Then
                    txtContact_R4.Text = vContact_R4
                End If
                If dGMI_R4.Value = 0 Then
                    dGMI_R4.Text = vGMI_R4
                End If
                If dYears_R4.Value = 0 Then
                    dYears_R4.Text = vYears_R4
                End If
                If CbxPrefix_R5.Text = "" Then
                    CbxPrefix_R5.Text = vPrefix_R5
                End If
                If TxtFirstN_R5.Text = "" Then
                    TxtFirstN_R5.Text = vFirstN_R5
                End If
            End If
        End If
    End Sub

    Private Sub TxtFirstN_R5_TextChanged(sender As Object, e As EventArgs) Handles TxtFirstN_R5.TextChanged
        If TxtFirstN_R5.Text.Trim = "" Then
            TxtMiddleN_R5.Enabled = False
            TxtLastN_R5.Enabled = False
            cbxSuffix_R5.Enabled = False
            DtpBirth_R5.Enabled = False
            txtTIN_R5.Enabled = False
            txtSSS_R5.Enabled = False
            dGMI_R5.Enabled = False
            txtNo_R5.Enabled = False
            txtStreet_R5.Enabled = False
            txtBarangay_R5.Enabled = False
            cbxAddress_R5.Enabled = False
            txtPosition_R5.Enabled = False
            txtContact_R5.Enabled = False
            dYears_R5.Enabled = False
            btnAttach_R5.Enabled = False
            DtpBirth_R5.CustomFormat = ""

            vMiddleN_R5 = TxtMiddleN_R5.Text
            vLastN_R5 = TxtLastN_R5.Text
            vSuffix_R5 = cbxSuffix_R5.Text
            vTIN_R5 = txtTIN_R5.Text
            vSSS_R5 = txtSSS_R5.Text
            vNo_R5 = txtNo_R5.Text
            vStreet_R5 = txtStreet_R5.Text
            vBarangay_R5 = txtBarangay_R5.Text
            vAddress_R5 = cbxAddress_R5.Text
            vPosition_R5 = txtPosition_R5.Text
            vContact_R5 = txtContact_R5.Text
            vGMI_R5 = dGMI_R5.Value
            vYears_R5 = dYears_R5.Value

            TxtMiddleN_R5.Text = ""
            TxtLastN_R5.Text = ""
            cbxSuffix_R5.Text = ""
            txtTIN_R5.Text = ""
            txtSSS_R5.Text = ""
            txtNo_R5.Text = ""
            txtStreet_R5.Text = ""
            txtBarangay_R5.Text = ""
            cbxAddress_R5.Text = ""
            txtPosition_R5.Text = ""
            txtContact_R5.Text = ""
            dGMI_R5.Value = 0
            dYears_R5.Value = 0
        Else
            TxtMiddleN_R5.Enabled = True
            TxtLastN_R5.Enabled = True
            cbxSuffix_R5.Enabled = True
            DtpBirth_R5.Enabled = True
            txtTIN_R5.Enabled = True
            txtSSS_R5.Enabled = True
            txtNo_R5.Enabled = True
            txtStreet_R5.Enabled = True
            txtBarangay_R5.Enabled = True
            cbxAddress_R5.Enabled = True
            txtPosition_R5.Enabled = True
            txtContact_R5.Enabled = True
            dGMI_R5.Enabled = True
            dYears_R5.Enabled = True
            btnAttach_R5.Enabled = True
            DtpBirth_R5.CustomFormat = "MMM. dd, yyyy"

            If RetrieveData Then
            Else
                Exit Sub
            End If
            If vGMI_R5 = 0 And vYears_R5 = 0 And vMiddleN_R5 = "" And vLastN_R5 = "" And vSuffix_R5 = "" And vTIN_R5 = "" And vSSS_R5 = "" And vNo_R5 = "" And vStreet_R5 = "" And vBarangay_R5 = "" And vAddress_R5 = "" And vPosition_R5 = "" And vContact_R5 = "" Then
            Else
                If TxtMiddleN_R5.Text = "" Then
                    TxtMiddleN_R5.Text = vMiddleN_R5
                End If
                If TxtLastN_R5.Text = "" Then
                    TxtLastN_R5.Text = vLastN_R5
                End If
                If cbxSuffix_R5.Text = "" Then
                    cbxSuffix_R5.Text = vSuffix_R5
                End If
                If txtTIN_R5.Text = "" Then
                    txtTIN_R5.Text = vTIN_R5
                End If
                If txtSSS_R5.Text = "" Then
                    txtSSS_R5.Text = vSSS_R5
                End If
                If txtNo_R5.Text = "" Then
                    txtNo_R5.Text = vNo_R5
                End If
                If txtStreet_R5.Text = "" Then
                    txtStreet_R5.Text = vStreet_R5
                End If
                If txtBarangay_R5.Text = "" Then
                    txtBarangay_R5.Text = vBarangay_R5
                End If
                If cbxAddress_R5.Text = "" Then
                    cbxAddress_R5.Text = vAddress_R5
                End If
                If txtPosition_R5.Text = "" Then
                    txtPosition_R5.Text = vPosition_R5
                End If
                If txtContact_R5.Text = "" Then
                    txtContact_R5.Text = vContact_R5
                End If
                If dGMI_R5.Value = 0 Then
                    dGMI_R5.Text = vGMI_R5
                End If
                If dYears_R5.Value = 0 Then
                    dYears_R5.Text = vYears_R5
                End If
            End If
        End If
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If vPrint Then
        Else
            MsgBox(mBox_Print, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        Dim Report As New RptBorrowersCorporate
        With Report
            .Name = txtBorrowerID.Text
            .tAmount.Text = ""
            .tTerms.Text = ""
            .tCollateral.Text = ""
            .tPurpose.Text = ""
            .tDate.Text = Format(Date.Now, "MMM. dd, yyyy")
            .p_Borrower.Image = pb_Logo.Image.Clone
            .lblLoanNumber.Text = ""
            .lblBorrowerID.Text = txtBorrowerID.Text
            .lblTradeName.Text = txtTradeName.Text
            .lblAddress.Text = If(txtNo.Text = "", "", txtNo.Text & ", ") & If(txtStreet.Text = "", "", txtStreet.Text & ", ") & If(txtBarangay.Text = "", "", txtBarangay.Text & ", ") & cbxAddress.Text
            .lblTIN.Text = txtTIN.Text
            .lblSSS.Text = txtSSS.Text
            .lblTelephone.Text = txtTelephone.Text
            .lblEmail.Text = txtEmail.Text
            .lblFax.Text = txtFax.Text
            .lblWebsite.Text = txtWebsite.Text
            .lblIncorporation.Text = dtpIncorporation.Text
            .lblYears.Text = iYears.Text
            .lblNoEmployees.Text = iEmployees.Text
            .cbxMicro.Checked = cbxMicro.Checked
            .cbxSmall.Checked = cbxSmall.Checked
            .cbxMedium.Checked = cbxMedium.Checked
            .cbxLarge.Checked = cbxLarge.Checked
            .lblGrossIncome.Text = dGross.Text
            .lblNetIncome.Text = dNet.Text
            .lblRep_1.Text = If(CbxPrefix_R1.Text = "", "", CbxPrefix_R1.Text & " ") & If(TxtFirstN_R1.Text = "", "", TxtFirstN_R1.Text & " ") & If(TxtMiddleN_R1.Text = "", "", TxtMiddleN_R1.Text & " ") & If(TxtLastN_R1.Text = "", "", TxtLastN_R1.Text & " ") & cbxSuffix_R1.Text
            .lblBirthdate_1.Text = DtpBirth_R1.Text
            .lblTIN_1.Text = txtTIN_R1.Text
            .lblSSS_1.Text = txtSSS_R1.Text
            .lblGMI_1.Text = dGMI_R1.Text
            .lblYears_1.Text = dYears_R1.Text
            .lblAddress_1.Text = If(txtNo_R1.Text = "", "", txtNo_R1.Text & ", ") & If(txtStreet_R1.Text = "", "", txtStreet_R1.Text & ", ") & If(txtBarangay_R1.Text = "", "", txtBarangay_R1.Text & ", ") & cbxAddress_R1.Text
            .lblPosition_1.Text = txtPosition_R1.Text
            .lblContact_1.Text = txtContact_R1.Text
            .lblRep_2.Text = If(CbxPrefix_R2.Text = "", "", CbxPrefix_R2.Text & " ") & If(TxtFirstN_R2.Text = "", "", TxtFirstN_R2.Text & " ") & If(TxtMiddleN_R2.Text = "", "", TxtMiddleN_R2.Text & " ") & If(TxtLastN_R2.Text = "", "", TxtLastN_R2.Text & " ") & cbxSuffix_R2.Text
            .lblBirthdate_2.Text = DtpBirth_R2.Text
            .lblTIN_2.Text = txtTIN_R2.Text
            .lblSSS_2.Text = txtSSS_R2.Text
            .lblGMI_2.Text = dGMI_R2.Text
            .lblYears_2.Text = dYears_R2.Text
            .lblAddress_2.Text = If(txtNo_R2.Text = "", "", txtNo_R2.Text & ", ") & If(txtStreet_R2.Text = "", "", txtStreet_R2.Text & ", ") & If(txtBarangay_R2.Text = "", "", txtBarangay_R2.Text & ", ") & cbxAddress_R2.Text
            .lblPosition_2.Text = txtPosition_R2.Text
            .lblContact_2.Text = txtContact_R2.Text
            .lblRep_3.Text = If(CbxPrefix_R3.Text = "", "", CbxPrefix_R3.Text & " ") & If(TxtFirstN_R3.Text = "", "", TxtFirstN_R3.Text & " ") & If(TxtMiddleN_R3.Text = "", "", TxtMiddleN_R3.Text & " ") & If(TxtLastN_R3.Text = "", "", TxtLastN_R3.Text & " ") & cbxSuffix_R3.Text
            .lblBirthdate_3.Text = DtpBirth_R3.Text
            .lblTIN_3.Text = txtTIN_R3.Text
            .lblSSS_3.Text = txtSSS_R3.Text
            .lblGMI_3.Text = dGMI_R3.Text
            .lblYears_3.Text = dYears_R3.Text
            .lblAddress_3.Text = If(txtNo_R3.Text = "", "", txtNo_R3.Text & ", ") & If(txtStreet_R3.Text = "", "", txtStreet_R3.Text & ", ") & If(txtBarangay_R3.Text = "", "", txtBarangay_R3.Text & ", ") & cbxAddress_R3.Text
            .lblPosition_3.Text = txtPosition_R3.Text
            .lblContact_3.Text = txtContact_R3.Text
            .lblRep_4.Text = If(CbxPrefix_R4.Text = "", "", CbxPrefix_R4.Text & " ") & If(TxtFirstN_R4.Text = "", "", TxtFirstN_R4.Text & " ") & If(TxtMiddleN_R4.Text = "", "", TxtMiddleN_R4.Text & " ") & If(TxtLastN_R4.Text = "", "", TxtLastN_R4.Text & " ") & cbxSuffix_R4.Text
            .lblBirthdate_4.Text = DtpBirth_R4.Text
            .lblTIN_4.Text = txtTIN_R4.Text
            .lblSSS_4.Text = txtSSS_R4.Text
            .lblGMI_4.Text = dGMI_R4.Text
            .lblYears_4.Text = dYears_R4.Text
            .lblAddress_4.Text = If(txtNo_R4.Text = "", "", txtNo_R4.Text & ", ") & If(txtStreet_R4.Text = "", "", txtStreet_R4.Text & ", ") & If(txtBarangay_R4.Text = "", "", txtBarangay_R4.Text & ", ") & cbxAddress_R4.Text
            .lblPosition_4.Text = txtPosition_R4.Text
            .lblContact_4.Text = txtContact_R4.Text
            .lblRep_5.Text = If(CbxPrefix_R5.Text = "", "", CbxPrefix_R5.Text & " ") & If(TxtFirstN_R5.Text = "", "", TxtFirstN_R5.Text & " ") & If(TxtMiddleN_R5.Text = "", "", TxtMiddleN_R5.Text & " ") & If(TxtLastN_R5.Text = "", "", TxtLastN_R5.Text & " ") & cbxSuffix_R5.Text
            .lblBirthdate_5.Text = DtpBirth_R5.Text
            .lblTIN_5.Text = txtTIN_R5.Text
            .lblSSS_5.Text = txtSSS_R5.Text
            .lblGMI_5.Text = dGMI_R5.Text
            .lblYears_5.Text = dYears_R5.Text
            .lblAddress_5.Text = If(txtNo_R5.Text = "", "", txtNo_R5.Text & ", ") & If(txtStreet_R5.Text = "", "", txtStreet_R5.Text & ", ") & If(txtBarangay_R5.Text = "", "", txtBarangay_R5.Text & ", ") & cbxAddress_R5.Text
            .lblPosition_5.Text = txtPosition_R5.Text
            .lblContact_5.Text = txtContact_R5.Text
            .lblBank_1.Text = txtBank_1.Text
            .lblBranch_1.Text = txtBranch_1.Text
            .lblSA_1.Text = If(cbxSA_1.Checked, "SA - ", If(cbxCA_1.Checked, "CA - ", "")) & txtSA_1.Text
            .lblAverage_1.Text = dAverageBalance_1.Text
            .lblPresent_1.Text = dPresentBalance_1.Text
            .lblDateOpened_1.Text = dtpOpened_1.Text
            .lblBankRemarks_1.Text = txtBankRemarks_1.Text
            .lblBank_2.Text = txtBank_2.Text
            .lblBranch_2.Text = txtBranch_2.Text
            .lblSA_2.Text = If(cbxSA_2.Checked, "SA - ", If(cbxCA_2.Checked, "CA - ", "")) & txtSA_2.Text
            .lblAverage_2.Text = dAverageBalance_2.Text
            .lblPresent_2.Text = dPresentBalance_2.Text
            .lblDateOpened_2.Text = dtpOpened_2.Text
            .lblBankRemarks_2.Text = txtBankRemarks_2.Text
            .cbxAgent.Checked = cbxAgent.Checked
            .txtAgent.Text = cbxAgentName.Text & " " & If(txtAgentContact.Text = "", "", "(" & txtAgentContact.Text & ")")
            .cbxMarketing.Checked = cbxMarketing.Checked
            .txtMarketing.Text = cbxMarketingName.Text & " " & If(txtMarketingContact.Text = "", "", "(" & txtMarketingContact.Text & ")")
            .cbxWalkIn.Checked = cbxWalkIn.Checked
            .txtWalkIn.Text = cbxWalkInType.Text & " " & If(txtWalkInOthers.Text = "", "", "(" & txtWalkInOthers.Text & ")")
            .cbxDealer.Checked = cbxDealer.Checked
            .txtDealer.Text = cbxDealerName.Text & " " & If(txtDealersContact.Text = "", "", "(" & txtDealersContact.Text & ")")
            .ShowPreview()
            Logs("Corporation Borrower", "Print", String.Format("[SENSITIVE] Print corporation borrower {0}", txtTradeName.Text), "", txtBorrowerID.Text, txtTradeName.Text, "")
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub BtnSaveDraft_Click(sender As Object, e As EventArgs) Handles btnSaveDraft.Click
        If Multiple_ID.Contains(",") Then
            MsgBox("Saving transaction is not allowed because multi branch are selected.", MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If vSave Then
        Else
            MsgBox(mBox_Save, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If txtTradeName.Text = "" Then
            MsgBox("Please fill the borrower's trade name.", MsgBoxStyle.Information, "Info")
            txtTradeName.Focus()
            Exit Sub
        End If
        If cbxBusinessCenter.SelectedIndex = -1 Or cbxBusinessCenter.Text = "" Then
            MsgBox("Please select a business center.", MsgBoxStyle.Information, "Info")
            cbxBusinessCenter.DroppedDown = True
            Exit Sub
        End If

        Dim FirmSize As String = ""
        If cbxMicro.Checked Then
            FirmSize = "Micro"
        ElseIf cbxSmall.Checked Then
            FirmSize = "Small"
        ElseIf cbxMedium.Checked Then
            FirmSize = "Medium"
        ElseIf cbxLarge.Checked Then
            FirmSize = "Large"
        End If
        Dim AccountT_1 As String = ""
        If cbxSA_1.Checked Then
            AccountT_1 = "SA"
        ElseIf cbxCA_1.Checked Then
            AccountT_1 = "CA"
        End If
        Dim AccountT_2 As String = ""
        If cbxSA_2.Checked Then
            AccountT_2 = "SA"
        ElseIf cbxCA_2.Checked Then
            AccountT_2 = "CA"
        End If

        Dim AgentID As String = ""
        Dim Agent As String = ""
        Dim AgentNo As String = ""
        Dim MarketingID As String = ""
        Dim Marketing As String = ""
        Dim MarketingNo As String = ""
        Dim WalkinID As String = ""
        Dim Walkin As String = ""
        Dim Walkin_Specify As String = ""
        Dim DealerID As String = ""
        Dim Dealer As String = ""
        Dim DealerNo As String = ""
        If cbxAgent.Checked Then
            If cbxAgentName.SelectedIndex = -1 Or cbxAgentName.Text = "" Then
            Else
                AgentID = cbxAgentName.SelectedValue
                Agent = cbxAgentName.Text
                AgentNo = txtAgentContact.Text
            End If
        End If
        If cbxMarketing.Checked Then
            If cbxMarketingName.SelectedIndex = -1 Or cbxMarketingName.Text = "" Then
            Else
                MarketingID = cbxMarketingName.SelectedValue
                Marketing = cbxMarketingName.Text
                MarketingNo = txtMarketingContact.Text
            End If
        End If
        If cbxWalkIn.Checked Then
            If cbxWalkInType.SelectedIndex = -1 Or cbxWalkInType.Text = "" Then
            Else
                WalkinID = cbxWalkInType.SelectedValue
                Walkin = cbxWalkInType.Text
                Walkin_Specify = txtWalkInOthers.Text
            End If
        End If
        If cbxDealer.Checked Then
            If cbxDealerName.SelectedIndex = -1 Or cbxDealerName.Text = "" Then
            Else
                DealerID = cbxDealerName.SelectedValue
                Dealer = cbxDealerName.Text
                DealerNo = txtDealersContact.Text
            End If
        End If
        If btnSaveDraft.Text = "Save Draft" Then
            If MsgBoxYes(mSave) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM profile_corporation WHERE TradeName = '{0}' AND `status` = 'ACTIVE'", txtTradeName.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Borrower Corporation {0} already exist, Please check your data.", txtTradeName.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If
                Cursor = Cursors.WaitCursor
                GetBorrower()

                Dim SQL As String = "INSERT INTO profile_corporation SET"
                SQL &= String.Format(" BorrowerID = '{0}', ", txtBorrowerID.Text)
                SQL &= String.Format(" TradeName = '{0}', ", txtTradeName.Text)
                SQL &= String.Format(" `No` = '{0}', ", txtNo.Text)
                SQL &= String.Format(" Street = '{0}', ", txtStreet.Text)
                SQL &= String.Format(" Barangay = '{0}', ", txtBarangay.Text)
                SQL &= String.Format(" `Address-ID` = '{0}', ", ValidateComboBox(cbxAddress))
                SQL &= String.Format(" Address = '{0}', ", cbxAddress.Text)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN.Text)
                SQL &= String.Format(" SSS = '{0}', ", txtSSS.Text)
                SQL &= String.Format(" Telephone = '{0}', ", txtTelephone.Text)
                SQL &= String.Format(" Email = '{0}', ", txtEmail.Text)
                SQL &= String.Format(" Fax = '{0}', ", txtFax.Text)
                SQL &= String.Format(" Website = '{0}', ", txtWebsite.Text)
                SQL &= String.Format(" Incorporation = '{0}', ", FormatDatePicker(dtpIncorporation))
                SQL &= String.Format(" YearsOperation = '{0}', ", iYears.Value)
                SQL &= String.Format(" Employees = '{0}', ", iEmployees.Value)
                SQL &= String.Format(" FirmSize = '{0}', ", FirmSize)
                SQL &= String.Format(" Gross = '{0}', ", dGross.Value)
                SQL &= String.Format(" Net = '{0}', ", dNet.Value)
                SQL &= String.Format(" Prefix_R1 = '{0}', ", CbxPrefix_R1.Text)
                SQL &= String.Format(" FirstN_R1 = '{0}', ", TxtFirstN_R1.Text)
                SQL &= String.Format(" MiddleN_R1 = '{0}', ", TxtMiddleN_R1.Text)
                SQL &= String.Format(" LastN_R1 = '{0}', ", TxtLastN_R1.Text)
                SQL &= String.Format(" Suffix_R1 = '{0}', ", cbxSuffix_R1.Text)
                SQL &= String.Format(" Birthdate_R1 = '{0}', ", FormatDatePicker(DtpBirth_R1))
                SQL &= String.Format(" TIN_R1 = '{0}', ", txtTIN_R1.Text)
                SQL &= String.Format(" SSS_R1 = '{0}', ", txtSSS_R1.Text)
                SQL &= String.Format(" GMI_R1 = '{0}', ", dGMI_R1.Value)
                SQL &= String.Format(" Years_R1 = '{0}', ", dYears_R1.Value)
                SQL &= String.Format(" Attach_R1 = '{0}', ", TotalImage_R1)
                SQL &= String.Format(" No_R1 = '{0}', ", txtNo_R1.Text)
                SQL &= String.Format(" Street_R1 = '{0}', ", txtStreet_R1.Text)
                SQL &= String.Format(" Barangay_R1 = '{0}', ", txtBarangay_R1.Text)
                SQL &= String.Format(" `Address_R1-ID` = '{0}', ", ValidateComboBox(cbxAddress_R1))
                SQL &= String.Format(" Address_R1 = '{0}', ", cbxAddress_R1.Text)
                SQL &= String.Format(" Position_R1 = '{0}', ", txtPosition_R1.Text)
                SQL &= String.Format(" Contact_R1 = '{0}', ", txtContact_R1.Text)
                SQL &= String.Format(" Prefix_R2 = '{0}', ", CbxPrefix_R2.Text)
                SQL &= String.Format(" FirstN_R2 = '{0}', ", TxtFirstN_R2.Text)
                SQL &= String.Format(" MiddleN_R2 = '{0}', ", TxtMiddleN_R2.Text)
                SQL &= String.Format(" LastN_R2 = '{0}', ", TxtLastN_R2.Text)
                SQL &= String.Format(" Suffix_R2 = '{0}', ", cbxSuffix_R2.Text)
                SQL &= String.Format(" Birthdate_R2 = '{0}', ", FormatDatePicker(DtpBirth_R2))
                SQL &= String.Format(" TIN_R2 = '{0}', ", txtTIN_R2.Text)
                SQL &= String.Format(" SSS_R2 = '{0}', ", txtSSS_R2.Text)
                SQL &= String.Format(" GMI_R2 = '{0}', ", dGMI_R2.Value)
                SQL &= String.Format(" Years_R2 = '{0}', ", dYears_R2.Value)
                SQL &= String.Format(" Attach_R2 = '{0}', ", TotalImage_R2)
                SQL &= String.Format(" No_R2 = '{0}', ", txtNo_R2.Text)
                SQL &= String.Format(" Street_R2 = '{0}', ", txtStreet_R2.Text)
                SQL &= String.Format(" Barangay_R2 = '{0}', ", txtBarangay_R2.Text)
                SQL &= String.Format(" `Address_R2-ID` = '{0}', ", ValidateComboBox(cbxAddress_R2))
                SQL &= String.Format(" Address_R2 = '{0}', ", cbxAddress_R2.Text)
                SQL &= String.Format(" Position_R2 = '{0}', ", txtPosition_R2.Text)
                SQL &= String.Format(" Contact_R2 = '{0}', ", txtContact_R2.Text)
                SQL &= String.Format(" Prefix_R3 = '{0}', ", CbxPrefix_R3.Text)
                SQL &= String.Format(" FirstN_R3 = '{0}', ", TxtFirstN_R3.Text)
                SQL &= String.Format(" MiddleN_R3 = '{0}', ", TxtMiddleN_R3.Text)
                SQL &= String.Format(" LastN_R3 = '{0}', ", TxtLastN_R3.Text)
                SQL &= String.Format(" Suffix_R3 = '{0}', ", cbxSuffix_R3.Text)
                SQL &= String.Format(" Birthdate_R3 = '{0}', ", FormatDatePicker(DtpBirth_R3))
                SQL &= String.Format(" TIN_R3 = '{0}', ", txtTIN_R3.Text)
                SQL &= String.Format(" SSS_R3 = '{0}', ", txtSSS_R3.Text)
                SQL &= String.Format(" GMI_R3 = '{0}', ", dGMI_R3.Value)
                SQL &= String.Format(" Years_R3 = '{0}', ", dYears_R3.Value)
                SQL &= String.Format(" No_R3 = '{0}', ", txtNo_R3.Text)
                SQL &= String.Format(" Attach_R3 = '{0}', ", TotalImage_R3)
                SQL &= String.Format(" Street_R3 = '{0}', ", txtStreet_R3.Text)
                SQL &= String.Format(" Barangay_R3 = '{0}', ", txtBarangay_R3.Text)
                SQL &= String.Format(" `Address_R3-ID` = '{0}', ", ValidateComboBox(cbxAddress_R3))
                SQL &= String.Format(" Address_R3 = '{0}', ", cbxAddress_R3.Text)
                SQL &= String.Format(" Position_R3 = '{0}', ", txtPosition_R3.Text)
                SQL &= String.Format(" Contact_R3 = '{0}', ", txtContact_R3.Text)
                SQL &= String.Format(" Prefix_R4 = '{0}', ", CbxPrefix_R4.Text)
                SQL &= String.Format(" FirstN_R4 = '{0}', ", TxtFirstN_R4.Text)
                SQL &= String.Format(" MiddleN_R4 = '{0}', ", TxtMiddleN_R4.Text)
                SQL &= String.Format(" LastN_R4 = '{0}', ", TxtLastN_R4.Text)
                SQL &= String.Format(" Suffix_R4 = '{0}', ", cbxSuffix_R4.Text)
                SQL &= String.Format(" Birthdate_R4 = '{0}', ", FormatDatePicker(DtpBirth_R4))
                SQL &= String.Format(" TIN_R4 = '{0}', ", txtTIN_R4.Text)
                SQL &= String.Format(" SSS_R4 = '{0}', ", txtSSS_R4.Text)
                SQL &= String.Format(" GMI_R4 = '{0}', ", dGMI_R4.Value)
                SQL &= String.Format(" Attach_R4 = '{0}', ", TotalImage_R4)
                SQL &= String.Format(" Years_R4 = '{0}', ", dYears_R4.Value)
                SQL &= String.Format(" No_R4 = '{0}', ", txtNo_R4.Text)
                SQL &= String.Format(" Street_R4 = '{0}', ", txtStreet_R4.Text)
                SQL &= String.Format(" Barangay_R4 = '{0}', ", txtBarangay_R4.Text)
                SQL &= String.Format(" `Address_R4-ID` = '{0}', ", ValidateComboBox(cbxAddress_R4))
                SQL &= String.Format(" Address_R4 = '{0}', ", cbxAddress_R4.Text)
                SQL &= String.Format(" Position_R4 = '{0}', ", txtPosition_R4.Text)
                SQL &= String.Format(" Contact_R4 = '{0}', ", txtContact_R4.Text)
                SQL &= String.Format(" Prefix_R5 = '{0}', ", CbxPrefix_R5.Text)
                SQL &= String.Format(" FirstN_R5 = '{0}', ", TxtFirstN_R5.Text)
                SQL &= String.Format(" MiddleN_R5 = '{0}', ", TxtMiddleN_R5.Text)
                SQL &= String.Format(" LastN_R5 = '{0}', ", TxtLastN_R5.Text)
                SQL &= String.Format(" Suffix_R5 = '{0}', ", cbxSuffix_R5.Text)
                SQL &= String.Format(" Birthdate_R5 = '{0}', ", FormatDatePicker(DtpBirth_R5))
                SQL &= String.Format(" TIN_R5 = '{0}', ", txtTIN_R5.Text)
                SQL &= String.Format(" SSS_R5 = '{0}', ", txtSSS_R5.Text)
                SQL &= String.Format(" GMI_R5 = '{0}', ", dGMI_R5.Value)
                SQL &= String.Format(" Years_R5 = '{0}', ", dYears_R5.Value)
                SQL &= String.Format(" Attach_R5 = '{0}', ", TotalImage_R5)
                SQL &= String.Format(" No_R5 = '{0}', ", txtNo_R5.Text)
                SQL &= String.Format(" Street_R5 = '{0}', ", txtStreet_R5.Text)
                SQL &= String.Format(" Barangay_R5 = '{0}', ", txtBarangay_R5.Text)
                SQL &= String.Format(" `Address_R5-ID` = '{0}', ", ValidateComboBox(cbxAddress_R5))
                SQL &= String.Format(" Address_R5 = '{0}', ", cbxAddress_R5.Text)
                SQL &= String.Format(" Position_R5 = '{0}', ", txtPosition_R5.Text)
                SQL &= String.Format(" Contact_R5 = '{0}', ", txtContact_R5.Text)
                SQL &= String.Format(" Bank_1 = '{0}', ", txtBank_1.Text)
                SQL &= String.Format(" Branch_1 = '{0}', ", txtBranch_1.Text)
                SQL &= String.Format(" AccountT_1 = '{0}', ", AccountT_1)
                SQL &= String.Format(" SA_1 = '{0}', ", txtSA_1.Text)
                SQL &= String.Format(" AverageBalance_1 = '{0}', ", dAverageBalance_1.Value)
                SQL &= String.Format(" PresentBalance_1 = '{0}', ", dPresentBalance_1.Value)
                SQL &= String.Format(" Opened_1 = '{0}', ", FormatDatePicker(dtpOpened_1))
                SQL &= String.Format(" BankRemarks_1 = '{0}', ", txtBankRemarks_1.Text)
                SQL &= String.Format(" Bank_2 = '{0}', ", txtBank_2.Text)
                SQL &= String.Format(" Branch_2 = '{0}', ", txtBranch_2.Text)
                SQL &= String.Format(" AccountT_2 = '{0}', ", AccountT_2)
                SQL &= String.Format(" SA_2 = '{0}', ", txtSA_2.Text)
                SQL &= String.Format(" AverageBalance_2 = '{0}', ", dAverageBalance_2.Value)
                SQL &= String.Format(" PresentBalance_2 = '{0}', ", dPresentBalance_2.Value)
                SQL &= String.Format(" Opened_2 = '{0}', ", FormatDatePicker(dtpOpened_2))
                SQL &= String.Format(" BankRemarks_2 = '{0}', ", txtBankRemarks_2.Text)
                SQL &= String.Format(" `AgentID` = '{0}', ", AgentID)
                SQL &= String.Format(" Agent = '{0}', ", Agent)
                SQL &= String.Format(" AgentNo = '{0}', ", AgentNo)
                SQL &= String.Format(" `MarketingID` = '{0}', ", MarketingID)
                SQL &= String.Format(" Marketing = '{0}', ", Marketing)
                SQL &= String.Format(" MarketingNo = '{0}', ", MarketingNo)
                SQL &= String.Format(" `WalkinID` = '{0}', ", WalkinID)
                SQL &= String.Format(" WalkIn = '{0}', ", Walkin)
                SQL &= String.Format(" WalkIn_Specify = '{0}', ", Walkin_Specify)
                SQL &= String.Format(" `DealerID` = '{0}', ", DealerID)
                SQL &= String.Format(" Dealer = '{0}', ", Dealer)
                SQL &= String.Format(" DealerNo = '{0}', ", DealerNo)
                SQL &= String.Format(" branch_id = '{0}', ", Branch_ID)
                SQL &= String.Format(" BusinessID = '{0}', ", cbxBusinessCenter.SelectedValue)
                SQL &= String.Format(" branch_code = '{0}', ", Branch_Code)
                SQL &= String.Format(" Prefix_S1 = '{0}', ", vPrefix_S1)
                SQL &= String.Format(" FirstN_S1 = '{0}', ", vFirstN_S1)
                SQL &= String.Format(" MiddleN_S1 = '{0}', ", vMiddleN_S1)
                SQL &= String.Format(" LastN_S1 = '{0}', ", vLastN_S1)
                SQL &= String.Format(" Suffix_S1 = '{0}', ", vSuffix_S1)
                SQL &= String.Format(" Prefix_S2 = '{0}', ", vPrefix_S2)
                SQL &= String.Format(" FirstN_S2 = '{0}', ", vFirstN_S2)
                SQL &= String.Format(" MiddleN_S2 = '{0}', ", vMiddleN_S2)
                SQL &= String.Format(" LastN_S2 = '{0}', ", vLastN_S2)
                SQL &= String.Format(" Suffix_S2 = '{0}', ", vSuffix_S2)
                SQL &= String.Format(" Prefix_S3 = '{0}', ", vPrefix_S3)
                SQL &= String.Format(" FirstN_S3 = '{0}', ", vFirstN_S3)
                SQL &= String.Format(" MiddleN_S3 = '{0}', ", vMiddleN_S3)
                SQL &= String.Format(" LastN_S3 = '{0}', ", vLastN_S3)
                SQL &= String.Format(" Suffix_S3 = '{0}', ", vSuffix_S3)
                SQL &= String.Format(" Prefix_S4 = '{0}', ", vPrefix_S4)
                SQL &= String.Format(" FirstN_S4 = '{0}', ", vFirstN_S4)
                SQL &= String.Format(" MiddleN_S4 = '{0}', ", vMiddleN_S4)
                SQL &= String.Format(" LastN_S4 = '{0}', ", vLastN_S4)
                SQL &= String.Format(" Suffix_S4 = '{0}', ", vSuffix_S4)
                SQL &= String.Format(" User_Code = '{0}' ", User_Code)
                DataObject(SQL)
                If txtPath.Text <> "" Then
                    SaveImage(pb_Logo, "Corporation")
                End If

                Cursor = Cursors.Default
                Logs("Corporation Borrower", "Save", String.Format("Add new corporation borrower {0}", txtTradeName.Text), "", txtBorrowerID.Text, txtTradeName.Text, "")
                Clear()
                FrmBorrowerList.LoadData()
                MsgBox("Successfully Saved!", MsgBoxStyle.Information, "Info")
            End If
        Else
            If MsgBoxYes(mUpdate) = MsgBoxResult.Yes Then
                Dim Exist As Integer = DataObject(String.Format("SELECT ID FROM profile_corporation WHERE TradeName = '{0}' AND `status` = 'ACTIVE' AND BorrowerID != '{1}'", txtTradeName.Text, txtBorrowerID.Text))
                If Exist > 0 Then
                    MsgBox(String.Format("Borrower Corporation {0} already exist, Please check your data.", txtTradeName.Text), MsgBoxStyle.Information, "Info")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Dim SQL As String = "UPDATE profile_corporation SET"
                SQL &= String.Format(" TradeName = '{0}', ", txtTradeName.Text)
                SQL &= String.Format(" `No` = '{0}', ", txtNo.Text)
                SQL &= String.Format(" Street = '{0}', ", txtStreet.Text)
                SQL &= String.Format(" Barangay = '{0}', ", txtBarangay.Text)
                SQL &= String.Format(" `Address-ID` = '{0}', ", ValidateComboBox(cbxAddress))
                SQL &= String.Format(" Address = '{0}', ", cbxAddress.Text)
                SQL &= String.Format(" TIN = '{0}', ", txtTIN.Text)
                SQL &= String.Format(" SSS = '{0}', ", txtSSS.Text)
                SQL &= String.Format(" Telephone = '{0}', ", txtTelephone.Text)
                SQL &= String.Format(" Email = '{0}', ", txtEmail.Text)
                SQL &= String.Format(" Fax = '{0}', ", txtFax.Text)
                SQL &= String.Format(" Website = '{0}', ", txtWebsite.Text)
                SQL &= String.Format(" Incorporation = '{0}', ", FormatDatePicker(dtpIncorporation))
                SQL &= String.Format(" YearsOperation = '{0}', ", iYears.Value)
                SQL &= String.Format(" Employees = '{0}', ", iEmployees.Value)
                SQL &= String.Format(" FirmSize = '{0}', ", FirmSize)
                SQL &= String.Format(" Gross = '{0}', ", dGross.Value)
                SQL &= String.Format(" Net = '{0}', ", dNet.Value)
                SQL &= String.Format(" Prefix_R1 = '{0}', ", CbxPrefix_R1.Text)
                SQL &= String.Format(" FirstN_R1 = '{0}', ", TxtFirstN_R1.Text)
                SQL &= String.Format(" MiddleN_R1 = '{0}', ", TxtMiddleN_R1.Text)
                SQL &= String.Format(" LastN_R1 = '{0}', ", TxtLastN_R1.Text)
                SQL &= String.Format(" Suffix_R1 = '{0}', ", cbxSuffix_R1.Text)
                SQL &= String.Format(" Birthdate_R1 = '{0}', ", FormatDatePicker(DtpBirth_R1))
                SQL &= String.Format(" TIN_R1 = '{0}', ", txtTIN_R1.Text)
                SQL &= String.Format(" SSS_R1 = '{0}', ", txtSSS_R1.Text)
                SQL &= String.Format(" GMI_R1 = '{0}', ", dGMI_R1.Value)
                SQL &= String.Format(" Years_R1 = '{0}', ", dYears_R1.Value)
                SQL &= String.Format(" Attach_R1 = '{0}', ", TotalImage_R1)
                SQL &= String.Format(" No_R1 = '{0}', ", txtNo_R1.Text)
                SQL &= String.Format(" Street_R1 = '{0}', ", txtStreet_R1.Text)
                SQL &= String.Format(" Barangay_R1 = '{0}', ", txtBarangay_R1.Text)
                SQL &= String.Format(" `Address_R1-ID` = '{0}', ", ValidateComboBox(cbxAddress_R1))
                SQL &= String.Format(" Address_R1 = '{0}', ", cbxAddress_R1.Text)
                SQL &= String.Format(" Position_R1 = '{0}', ", txtPosition_R1.Text)
                SQL &= String.Format(" Contact_R1 = '{0}', ", txtContact_R1.Text)
                SQL &= String.Format(" Prefix_R2 = '{0}', ", CbxPrefix_R2.Text)
                SQL &= String.Format(" FirstN_R2 = '{0}', ", TxtFirstN_R2.Text)
                SQL &= String.Format(" MiddleN_R2 = '{0}', ", TxtMiddleN_R2.Text)
                SQL &= String.Format(" LastN_R2 = '{0}', ", TxtLastN_R2.Text)
                SQL &= String.Format(" Suffix_R2 = '{0}', ", cbxSuffix_R2.Text)
                SQL &= String.Format(" Birthdate_R2 = '{0}', ", FormatDatePicker(DtpBirth_R2))
                SQL &= String.Format(" TIN_R2 = '{0}', ", txtTIN_R2.Text)
                SQL &= String.Format(" SSS_R2 = '{0}', ", txtSSS_R2.Text)
                SQL &= String.Format(" GMI_R2 = '{0}', ", dGMI_R2.Value)
                SQL &= String.Format(" Years_R2 = '{0}', ", dYears_R2.Value)
                SQL &= String.Format(" Attach_R2 = '{0}', ", TotalImage_R2)
                SQL &= String.Format(" No_R2 = '{0}', ", txtNo_R2.Text)
                SQL &= String.Format(" Street_R2 = '{0}', ", txtStreet_R2.Text)
                SQL &= String.Format(" Barangay_R2 = '{0}', ", txtBarangay_R2.Text)
                SQL &= String.Format(" `Address_R2-ID` = '{0}', ", ValidateComboBox(cbxAddress_R2))
                SQL &= String.Format(" Address_R2 = '{0}', ", cbxAddress_R2.Text)
                SQL &= String.Format(" Position_R2 = '{0}', ", txtPosition_R2.Text)
                SQL &= String.Format(" Contact_R2 = '{0}', ", txtContact_R2.Text)
                SQL &= String.Format(" Prefix_R3 = '{0}', ", CbxPrefix_R3.Text)
                SQL &= String.Format(" FirstN_R3 = '{0}', ", TxtFirstN_R3.Text)
                SQL &= String.Format(" MiddleN_R3 = '{0}', ", TxtMiddleN_R3.Text)
                SQL &= String.Format(" LastN_R3 = '{0}', ", TxtLastN_R3.Text)
                SQL &= String.Format(" Suffix_R3 = '{0}', ", cbxSuffix_R3.Text)
                SQL &= String.Format(" Birthdate_R3 = '{0}', ", FormatDatePicker(DtpBirth_R3))
                SQL &= String.Format(" TIN_R3 = '{0}', ", txtTIN_R3.Text)
                SQL &= String.Format(" SSS_R3 = '{0}', ", txtSSS_R3.Text)
                SQL &= String.Format(" GMI_R3 = '{0}', ", dGMI_R3.Value)
                SQL &= String.Format(" Years_R3 = '{0}', ", dYears_R3.Value)
                SQL &= String.Format(" Attach_R3 = '{0}', ", TotalImage_R3)
                SQL &= String.Format(" No_R3 = '{0}', ", txtNo_R3.Text)
                SQL &= String.Format(" Street_R3 = '{0}', ", txtStreet_R3.Text)
                SQL &= String.Format(" Barangay_R3 = '{0}', ", txtBarangay_R3.Text)
                SQL &= String.Format(" `Address_R3-ID` = '{0}', ", ValidateComboBox(cbxAddress_R3))
                SQL &= String.Format(" Address_R3 = '{0}', ", cbxAddress_R3.Text)
                SQL &= String.Format(" Position_R3 = '{0}', ", txtPosition_R3.Text)
                SQL &= String.Format(" Contact_R3 = '{0}', ", txtContact_R3.Text)
                SQL &= String.Format(" Prefix_R4 = '{0}', ", CbxPrefix_R4.Text)
                SQL &= String.Format(" FirstN_R4 = '{0}', ", TxtFirstN_R4.Text)
                SQL &= String.Format(" MiddleN_R4 = '{0}', ", TxtMiddleN_R4.Text)
                SQL &= String.Format(" LastN_R4 = '{0}', ", TxtLastN_R4.Text)
                SQL &= String.Format(" Suffix_R4 = '{0}', ", cbxSuffix_R4.Text)
                SQL &= String.Format(" Birthdate_R4 = '{0}', ", FormatDatePicker(DtpBirth_R4))
                SQL &= String.Format(" TIN_R4 = '{0}', ", txtTIN_R4.Text)
                SQL &= String.Format(" SSS_R4 = '{0}', ", txtSSS_R4.Text)
                SQL &= String.Format(" GMI_R4 = '{0}', ", dGMI_R4.Value)
                SQL &= String.Format(" Years_R4 = '{0}', ", dYears_R4.Value)
                SQL &= String.Format(" Attach_R4 = '{0}', ", TotalImage_R4)
                SQL &= String.Format(" No_R4 = '{0}', ", txtNo_R4.Text)
                SQL &= String.Format(" Street_R4 = '{0}', ", txtStreet_R4.Text)
                SQL &= String.Format(" Barangay_R4 = '{0}', ", txtBarangay_R4.Text)
                SQL &= String.Format(" `Address_R4-ID` = '{0}', ", ValidateComboBox(cbxAddress_R4))
                SQL &= String.Format(" Address_R4 = '{0}', ", cbxAddress_R4.Text)
                SQL &= String.Format(" Position_R4 = '{0}', ", txtPosition_R4.Text)
                SQL &= String.Format(" Contact_R4 = '{0}', ", txtContact_R4.Text)
                SQL &= String.Format(" Prefix_R5 = '{0}', ", CbxPrefix_R5.Text)
                SQL &= String.Format(" FirstN_R5 = '{0}', ", TxtFirstN_R5.Text)
                SQL &= String.Format(" MiddleN_R5 = '{0}', ", TxtMiddleN_R5.Text)
                SQL &= String.Format(" LastN_R5 = '{0}', ", TxtLastN_R5.Text)
                SQL &= String.Format(" Suffix_R5 = '{0}', ", cbxSuffix_R5.Text)
                SQL &= String.Format(" Birthdate_R5 = '{0}', ", FormatDatePicker(DtpBirth_R5))
                SQL &= String.Format(" TIN_R5 = '{0}', ", txtTIN_R5.Text)
                SQL &= String.Format(" SSS_R5 = '{0}', ", txtSSS_R5.Text)
                SQL &= String.Format(" GMI_R5 = '{0}', ", dGMI_R5.Value)
                SQL &= String.Format(" Years_R5 = '{0}', ", dYears_R5.Value)
                SQL &= String.Format(" Attach_R5 = '{0}', ", TotalImage_R5)
                SQL &= String.Format(" No_R5 = '{0}', ", txtNo_R5.Text)
                SQL &= String.Format(" Street_R5 = '{0}', ", txtStreet_R5.Text)
                SQL &= String.Format(" Barangay_R5 = '{0}', ", txtBarangay_R5.Text)
                SQL &= String.Format(" `Address_R5-ID` = '{0}', ", ValidateComboBox(cbxAddress_R5))
                SQL &= String.Format(" Address_R5 = '{0}', ", cbxAddress_R5.Text)
                SQL &= String.Format(" Position_R5 = '{0}', ", txtPosition_R5.Text)
                SQL &= String.Format(" Contact_R5 = '{0}', ", txtContact_R5.Text)
                SQL &= String.Format(" Bank_1 = '{0}', ", txtBank_1.Text)
                SQL &= String.Format(" Branch_1 = '{0}', ", txtBranch_1.Text)
                SQL &= String.Format(" AccountT_1 = '{0}', ", AccountT_1)
                SQL &= String.Format(" SA_1 = '{0}', ", txtSA_1.Text)
                SQL &= String.Format(" AverageBalance_1 = '{0}', ", dAverageBalance_1.Value)
                SQL &= String.Format(" PresentBalance_1 = '{0}', ", dPresentBalance_1.Value)
                SQL &= String.Format(" Opened_1 = '{0}', ", FormatDatePicker(dtpOpened_1))
                SQL &= String.Format(" BankRemarks_1 = '{0}', ", txtBankRemarks_1.Text)
                SQL &= String.Format(" Bank_2 = '{0}', ", txtBank_2.Text)
                SQL &= String.Format(" Branch_2 = '{0}', ", txtBranch_2.Text)
                SQL &= String.Format(" AccountT_2 = '{0}', ", AccountT_2)
                SQL &= String.Format(" SA_2 = '{0}', ", txtSA_2.Text)
                SQL &= String.Format(" AverageBalance_2 = '{0}', ", dAverageBalance_2.Value)
                SQL &= String.Format(" PresentBalance_2 = '{0}', ", dPresentBalance_2.Value)
                SQL &= String.Format(" Opened_2 = '{0}', ", FormatDatePicker(dtpOpened_2))
                SQL &= String.Format(" BankRemarks_2 = '{0}', ", txtBankRemarks_2.Text)
                SQL &= String.Format(" BusinessID = '{0}', ", cbxBusinessCenter.SelectedValue)
                SQL &= String.Format(" `AgentID` = '{0}', ", AgentID)
                SQL &= String.Format(" Agent = '{0}', ", Agent)
                SQL &= String.Format(" AgentNo = '{0}', ", AgentNo)
                SQL &= String.Format(" `MarketingID` = '{0}', ", MarketingID)
                SQL &= String.Format(" Marketing = '{0}', ", Marketing)
                SQL &= String.Format(" MarketingNo = '{0}', ", MarketingNo)
                SQL &= String.Format(" `WalkinID` = '{0}', ", WalkinID)
                SQL &= String.Format(" WalkIn = '{0}', ", Walkin)
                SQL &= String.Format(" WalkIn_Specify = '{0}', ", Walkin_Specify)
                SQL &= String.Format(" `DealerID` = '{0}', ", DealerID)
                SQL &= String.Format(" Dealer = '{0}', ", Dealer)
                SQL &= String.Format(" DealerNo = '{0}', ", DealerNo)
                SQL &= String.Format(" Prefix_S1 = '{0}', ", vPrefix_S1)
                SQL &= String.Format(" FirstN_S1 = '{0}', ", vFirstN_S1)
                SQL &= String.Format(" MiddleN_S1 = '{0}', ", vMiddleN_S1)
                SQL &= String.Format(" LastN_S1 = '{0}', ", vLastN_S1)
                SQL &= String.Format(" Suffix_S1 = '{0}', ", vSuffix_S1)
                SQL &= String.Format(" Prefix_S2 = '{0}', ", vPrefix_S2)
                SQL &= String.Format(" FirstN_S2 = '{0}', ", vFirstN_S2)
                SQL &= String.Format(" MiddleN_S2 = '{0}', ", vMiddleN_S2)
                SQL &= String.Format(" LastN_S2 = '{0}', ", vLastN_S2)
                SQL &= String.Format(" Suffix_S2 = '{0}', ", vSuffix_S2)
                SQL &= String.Format(" Prefix_S3 = '{0}', ", vPrefix_S3)
                SQL &= String.Format(" FirstN_S3 = '{0}', ", vFirstN_S3)
                SQL &= String.Format(" MiddleN_S3 = '{0}', ", vMiddleN_S3)
                SQL &= String.Format(" LastN_S3 = '{0}', ", vLastN_S3)
                SQL &= String.Format(" Suffix_S3 = '{0}', ", vSuffix_S3)
                SQL &= String.Format(" Prefix_S4 = '{0}', ", vPrefix_S4)
                SQL &= String.Format(" FirstN_S4 = '{0}', ", vFirstN_S4)
                SQL &= String.Format(" MiddleN_S4 = '{0}', ", vMiddleN_S4)
                SQL &= String.Format(" LastN_S4 = '{0}', ", vLastN_S4)
                SQL &= String.Format(" Suffix_S4 = '{0}' ", vSuffix_S4)
                SQL &= String.Format(" WHERE BorrowerID = '{0}';", txtBorrowerID.Text)
                DataObject(SQL)
                If txtPath.Text <> "" Then
                    SaveImage(pb_Logo, "Corporation")
                End If

                Cursor = Cursors.Default
                Logs("Corporation Borrower", "Update", String.Format("Update corporation borrower {0}", txtTradeName.Text), Changes(), txtBorrowerID.Text, txtTradeName.Text, "")
                Clear()
                FrmBorrowerList.LoadData()
                MsgBox("Successfully Update!", MsgBoxStyle.Information, "Info")
            End If
        End If
    End Sub

    Private Function Changes()
        Dim Change As String = ""
        Try
            If txtTradeName.Text = txtTradeName.Tag Then
            Else
                Change &= String.Format("Change Trade Name from {0} to {1}. ", txtTradeName.Tag, txtTradeName.Text)
            End If
            If txtNo.Text = txtNo.Tag Then
            Else
                Change &= String.Format("Change Address No. from {0} to {1}. ", txtNo.Tag, txtNo.Text)
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
            If txtTIN.Text = txtTIN.Tag Then
            Else
                Change &= String.Format("Change TIN from {0} to {1}. ", txtTIN.Tag, txtTIN.Text)
            End If
            If txtSSS.Text = txtSSS.Tag Then
            Else
                Change &= String.Format("Change SSS from {0} to {1}. ", txtSSS.Tag, txtSSS.Text)
            End If
            If txtTelephone.Text = txtTelephone.Tag Then
            Else
                Change &= String.Format("Change Telephone from {0} to {1}. ", txtTelephone.Tag, txtTelephone.Text)
            End If
            If txtEmail.Text = txtEmail.Tag Then
            Else
                Change &= String.Format("Change Email from {0} to {1}. ", txtEmail.Tag, txtEmail.Text)
            End If
            If txtFax.Text = txtFax.Tag Then
            Else
                Change &= String.Format("Change Fax from {0} to {1}. ", txtFax.Tag, txtFax.Text)
            End If
            If txtWebsite.Text = txtWebsite.Tag Then
            Else
                Change &= String.Format("Change Website from {0} to {1}. ", txtWebsite.Tag, txtWebsite.Text)
            End If
            If FormatDatePicker(dtpIncorporation) = dtpIncorporation.Tag Then
            Else
                Change &= String.Format("Change Date Incorporation from {0} to {1}. ", dtpIncorporation.Tag, FormatDatePicker(dtpIncorporation))
            End If
            If iYears.Value = iYears.Tag Then
            Else
                Change &= String.Format("Change No. of Years Operation from {0} to {1}. ", iYears.Tag, iYears.Value)
            End If
            If iEmployees.Value = iEmployees.Tag Then
            Else
                Change &= String.Format("Change No. of Employees from {0} to {1}. ", iEmployees.Tag, iEmployees.Value)
            End If
            If cbxMicro.Tag <> "Micro" And cbxMicro.Checked Then
                Change &= String.Format("Change Firm Size from {0} to {1}. ", cbxMicro.Tag, cbxMicro.Text)
            ElseIf cbxSmall.Tag <> "Small" And cbxSmall.Checked = True Then
                Change &= String.Format("Change Firm Size from {0} to {1}. ", cbxSmall.Tag, cbxSmall.Text)
            ElseIf cbxMedium.Tag <> "Medium" And cbxMedium.Checked = True Then
                Change &= String.Format("Change Firm Size from {0} to {1}. ", cbxMedium.Tag, cbxMedium.Text)
            ElseIf cbxLarge.Tag <> "Large" And cbxLarge.Checked = True Then
                Change &= String.Format("Change Firm Size from {0} to {1}. ", cbxLarge.Tag, cbxLarge.Text)
            End If
            If dGross.Value = dGross.Tag Then
            Else
                Change &= String.Format("Change Gross from {0} to {1}. ", dGross.Tag, dGross.Value)
            End If
            If dNet.Value = dNet.Tag Then
            Else
                Change &= String.Format("Change Net from {0} to {1}. ", dNet.Tag, dNet.Value)
            End If
            If CbxPrefix_R1.Text = CbxPrefix_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Prefix from {0} to {1}. ", CbxPrefix_R1.Tag, CbxPrefix_R1.Text)
            End If
            If TxtFirstN_R1.Text = TxtFirstN_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 First Name from {0} to {1}. ", TxtFirstN_R1.Tag, TxtFirstN_R1.Text)
            End If
            If TxtMiddleN_R1.Text = TxtMiddleN_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Middle Name from {0} to {1}. ", TxtMiddleN_R1.Tag, TxtMiddleN_R1.Text)
            End If
            If TxtLastN_R1.Text = TxtLastN_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Last Name from {0} to {1}. ", TxtLastN_R1.Tag, TxtLastN_R1.Text)
            End If
            If cbxSuffix_R1.Text = cbxSuffix_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Suffix from {0} to {1}. ", cbxSuffix_R1.Tag, cbxSuffix_R1.Text)
            End If
            If FormatDatePicker(DtpBirth_R1) = DtpBirth_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Birthdate from {0} to {1}. ", DtpBirth_R1.Tag, FormatDatePicker(DtpBirth_R1))
            End If
            If txtTIN_R1.Text = txtTIN_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 TIN from {0} to {1}. ", txtTIN_R1.Tag, txtTIN_R1.Text)
            End If
            If txtSSS_R1.Text = txtSSS_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 SSS from {0} to {1}. ", txtSSS_R1.Tag, txtSSS_R1.Text)
            End If
            If dGMI_R1.Value = dGMI_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Gross Monthly Income from {0} to {1}. ", dGMI_R1.Tag, dGMI_R1.Value)
            End If
            If txtNo_R1.Text = txtNo_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Address No from {0} to {1}. ", txtNo_R1.Tag, txtNo_R1.Text)
            End If
            If txtStreet_R1.Text = txtStreet_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Address Street from {0} to {1}. ", txtStreet_R1.Tag, txtStreet_R1.Text)
            End If
            If txtBarangay_R1.Text = txtBarangay_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Address Barangay from {0} to {1}. ", txtBarangay_R1.Tag, txtBarangay_R1.Text)
            End If
            If cbxAddress_R1.Text = cbxAddress_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Address from {0} to {1}. ", cbxAddress_R1.Tag, cbxAddress_R1.Text)
            End If
            If txtPosition_R1.Text = txtPosition_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Position from {0} to {1}. ", txtPosition_R1.Tag, txtPosition_R1.Text)
            End If
            If txtContact_R1.Text = txtContact_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Contact from {0} to {1}. ", txtContact_R1.Tag, txtContact_R1.Text)
            End If
            If dYears_R1.Value = dYears_R1.Tag Then
            Else
                Change &= String.Format("Change Representative 1 Years in Company from {0} to {1}. ", dYears_R1.Tag, dYears_R1.Value)
            End If
            If CbxPrefix_R2.Text = CbxPrefix_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Prefix from {0} to {1}. ", CbxPrefix_R2.Tag, CbxPrefix_R2.Text)
            End If
            If TxtFirstN_R2.Text = TxtFirstN_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 First Name from {0} to {1}. ", TxtFirstN_R2.Tag, TxtFirstN_R2.Text)
            End If
            If TxtMiddleN_R2.Text = TxtMiddleN_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Middle Name from {0} to {1}. ", TxtMiddleN_R2.Tag, TxtMiddleN_R2.Text)
            End If
            If TxtLastN_R2.Text = TxtLastN_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Last Name from {0} to {1}. ", TxtLastN_R2.Tag, TxtLastN_R2.Text)
            End If
            If cbxSuffix_R2.Text = cbxSuffix_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Suffix from {0} to {1}. ", cbxSuffix_R2.Tag, cbxSuffix_R2.Text)
            End If
            If FormatDatePicker(DtpBirth_R2) = DtpBirth_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Birthdate from {0} to {1}. ", DtpBirth_R2.Tag, FormatDatePicker(DtpBirth_R2))
            End If
            If txtTIN_R2.Text = txtTIN_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 TIN from {0} to {1}. ", txtTIN_R2.Tag, txtTIN_R2.Text)
            End If
            If txtSSS_R2.Text = txtSSS_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 SSS from {0} to {1}. ", txtSSS_R2.Tag, txtSSS_R2.Text)
            End If
            If dGMI_R2.Value = dGMI_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Gross Monthly Income from {0} to {1}. ", dGMI_R2.Tag, dGMI_R2.Value)
            End If
            If txtNo_R2.Text = txtNo_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Address No from {0} to {1}. ", txtNo_R2.Tag, txtNo_R2.Text)
            End If
            If txtStreet_R2.Text = txtStreet_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Address Street from {0} to {1}. ", txtStreet_R2.Tag, txtStreet_R2.Text)
            End If
            If txtBarangay_R2.Text = txtBarangay_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Address Barangay from {0} to {1}. ", txtBarangay_R2.Tag, txtBarangay_R2.Text)
            End If
            If cbxAddress_R2.Text = cbxAddress_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Address from {0} to {1}. ", cbxAddress_R2.Tag, cbxAddress_R2.Text)
            End If
            If txtPosition_R2.Text = txtPosition_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Position from {0} to {1}. ", txtPosition_R2.Tag, txtPosition_R2.Text)
            End If
            If txtContact_R2.Text = txtContact_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Contact from {0} to {1}. ", txtContact_R2.Tag, txtContact_R2.Text)
            End If
            If dYears_R2.Value = dYears_R2.Tag Then
            Else
                Change &= String.Format("Change Representative 2 Years in Company from {0} to {1}. ", dYears_R2.Tag, dYears_R2.Value)
            End If
            If CbxPrefix_R3.Text = CbxPrefix_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Prefix from {0} to {1}. ", CbxPrefix_R3.Tag, CbxPrefix_R3.Text)
            End If
            If TxtFirstN_R3.Text = TxtFirstN_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 First Name from {0} to {1}. ", TxtFirstN_R3.Tag, TxtFirstN_R3.Text)
            End If
            If TxtMiddleN_R3.Text = TxtMiddleN_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Middle Name from {0} to {1}. ", TxtMiddleN_R3.Tag, TxtMiddleN_R3.Text)
            End If
            If TxtLastN_R3.Text = TxtLastN_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Last Name from {0} to {1}. ", TxtLastN_R3.Tag, TxtLastN_R3.Text)
            End If
            If cbxSuffix_R3.Text = cbxSuffix_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Suffix from {0} to {1}. ", cbxSuffix_R3.Tag, cbxSuffix_R3.Text)
            End If
            If FormatDatePicker(DtpBirth_R3) = DtpBirth_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Birthdate from {0} to {1}. ", DtpBirth_R3.Tag, FormatDatePicker(DtpBirth_R3))
            End If
            If txtTIN_R3.Text = txtTIN_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 TIN from {0} to {1}. ", txtTIN_R3.Tag, txtTIN_R3.Text)
            End If
            If txtSSS_R3.Text = txtSSS_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 SSS from {0} to {1}. ", txtSSS_R3.Tag, txtSSS_R3.Text)
            End If
            If dGMI_R3.Value = dGMI_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Gross Monthly Income from {0} to {1}. ", dGMI_R3.Tag, dGMI_R3.Value)
            End If
            If txtNo_R3.Text = txtNo_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Address No from {0} to {1}. ", txtNo_R3.Tag, txtNo_R3.Text)
            End If
            If txtStreet_R3.Text = txtStreet_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Address Street from {0} to {1}. ", txtStreet_R3.Tag, txtStreet_R3.Text)
            End If
            If txtBarangay_R3.Text = txtBarangay_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Address Barangay from {0} to {1}. ", txtBarangay_R3.Tag, txtBarangay_R3.Text)
            End If
            If cbxAddress_R3.Text = cbxAddress_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Address from {0} to {1}. ", cbxAddress_R3.Tag, cbxAddress_R3.Text)
            End If
            If txtPosition_R3.Text = txtPosition_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Position from {0} to {1}. ", txtPosition_R3.Tag, txtPosition_R3.Text)
            End If
            If txtContact_R3.Text = txtContact_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Contact from {0} to {1}. ", txtContact_R3.Tag, txtContact_R3.Text)
            End If
            If dYears_R3.Value = dYears_R3.Tag Then
            Else
                Change &= String.Format("Change Representative 3 Years in Company from {0} to {1}. ", dYears_R3.Tag, dYears_R3.Value)
            End If
            If CbxPrefix_R4.Text = CbxPrefix_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Prefix from {0} to {1}. ", CbxPrefix_R4.Tag, CbxPrefix_R4.Text)
            End If
            If TxtFirstN_R4.Text = TxtFirstN_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 First Name from {0} to {1}. ", TxtFirstN_R4.Tag, TxtFirstN_R4.Text)
            End If
            If TxtMiddleN_R4.Text = TxtMiddleN_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Middle Name from {0} to {1}. ", TxtMiddleN_R4.Tag, TxtMiddleN_R4.Text)
            End If
            If TxtLastN_R4.Text = TxtLastN_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Last Name from {0} to {1}. ", TxtLastN_R4.Tag, TxtLastN_R4.Text)
            End If
            If cbxSuffix_R4.Text = cbxSuffix_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Suffix from {0} to {1}. ", cbxSuffix_R4.Tag, cbxSuffix_R4.Text)
            End If
            If FormatDatePicker(DtpBirth_R4) = DtpBirth_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Birthdate from {0} to {1}. ", DtpBirth_R4.Tag, FormatDatePicker(DtpBirth_R4))
            End If
            If txtTIN_R4.Text = txtTIN_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 TIN from {0} to {1}. ", txtTIN_R4.Tag, txtTIN_R4.Text)
            End If
            If txtSSS_R4.Text = txtSSS_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 SSS from {0} to {1}. ", txtSSS_R4.Tag, txtSSS_R4.Text)
            End If
            If dGMI_R4.Value = dGMI_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Gross Monthly Income from {0} to {1}. ", dGMI_R4.Tag, dGMI_R4.Value)
            End If
            If txtNo_R4.Text = txtNo_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Address No from {0} to {1}. ", txtNo_R4.Tag, txtNo_R4.Text)
            End If
            If txtStreet_R4.Text = txtStreet_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Address Street from {0} to {1}. ", txtStreet_R4.Tag, txtStreet_R4.Text)
            End If
            If txtBarangay_R4.Text = txtBarangay_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Address Barangay from {0} to {1}. ", txtBarangay_R4.Tag, txtBarangay_R4.Text)
            End If
            If cbxAddress_R4.Text = cbxAddress_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Address from {0} to {1}. ", cbxAddress_R4.Tag, cbxAddress_R4.Text)
            End If
            If txtPosition_R4.Text = txtPosition_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Position from {0} to {1}. ", txtPosition_R4.Tag, txtPosition_R4.Text)
            End If
            If txtContact_R4.Text = txtContact_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Contact from {0} to {1}. ", txtContact_R4.Tag, txtContact_R4.Text)
            End If
            If dYears_R4.Value = dYears_R4.Tag Then
            Else
                Change &= String.Format("Change Representative 4 Years in Company from {0} to {1}. ", dYears_R4.Tag, dYears_R4.Value)
            End If
            If CbxPrefix_R5.Text = CbxPrefix_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Prefix from {0} to {1}. ", CbxPrefix_R5.Tag, CbxPrefix_R5.Text)
            End If
            If TxtFirstN_R5.Text = TxtFirstN_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 First Name from {0} to {1}. ", TxtFirstN_R5.Tag, TxtFirstN_R5.Text)
            End If
            If TxtMiddleN_R5.Text = TxtMiddleN_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Middle Name from {0} to {1}. ", TxtMiddleN_R5.Tag, TxtMiddleN_R5.Text)
            End If
            If TxtLastN_R5.Text = TxtLastN_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Last Name from {0} to {1}. ", TxtLastN_R5.Tag, TxtLastN_R5.Text)
            End If
            If cbxSuffix_R5.Text = cbxSuffix_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Suffix from {0} to {1}. ", cbxSuffix_R5.Tag, cbxSuffix_R5.Text)
            End If
            If FormatDatePicker(DtpBirth_R5) = DtpBirth_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Birthdate from {0} to {1}. ", DtpBirth_R5.Tag, FormatDatePicker(DtpBirth_R5))
            End If
            If txtTIN_R5.Text = txtTIN_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 TIN from {0} to {1}. ", txtTIN_R5.Tag, txtTIN_R5.Text)
            End If
            If txtSSS_R5.Text = txtSSS_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 SSS from {0} to {1}. ", txtSSS_R5.Tag, txtSSS_R5.Text)
            End If
            If dGMI_R5.Value = dGMI_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Gross Monthly Income from {0} to {1}. ", dGMI_R5.Tag, dGMI_R5.Value)
            End If
            If txtNo_R5.Text = txtNo_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Address No from {0} to {1}. ", txtNo_R5.Tag, txtNo_R5.Text)
            End If
            If txtStreet_R5.Text = txtStreet_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Address Street from {0} to {1}. ", txtStreet_R5.Tag, txtStreet_R5.Text)
            End If
            If txtBarangay_R5.Text = txtBarangay_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Address Barangay from {0} to {1}. ", txtBarangay_R5.Tag, txtBarangay_R5.Text)
            End If
            If cbxAddress_R5.Text = cbxAddress_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Address from {0} to {1}. ", cbxAddress_R5.Tag, cbxAddress_R5.Text)
            End If
            If txtPosition_R5.Text = txtPosition_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Position from {0} to {1}. ", txtPosition_R5.Tag, txtPosition_R5.Text)
            End If
            If txtContact_R5.Text = txtContact_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Contact from {0} to {1}. ", txtContact_R5.Tag, txtContact_R5.Text)
            End If
            If dYears_R5.Value = dYears_R5.Tag Then
            Else
                Change &= String.Format("Change Representative 5 Years in Company from {0} to {1}. ", dYears_R5.Tag, dYears_R5.Value)
            End If
            If txtBank_1.Text = txtBank_1.Tag Then
            Else
                Change &= String.Format("Change Bank 1 from {0} to {1}. ", txtBank_1.Tag, txtBank_1.Text)
            End If
            If txtBranch_1.Text = txtBranch_1.Tag Then
            Else
                Change &= String.Format("Change Branch 1 from {0} to {1}. ", txtBranch_1.Tag, txtBranch_1.Text)
            End If
            If cbxSA_1.Tag <> "SA" And cbxSA_1.Checked Then
                Change &= String.Format("Change Account Type 1 from {0} to {1}. ", cbxSA_1.Tag, "SA")
            ElseIf cbxCA_1.Tag <> "CA" And cbxCA_1.Checked Then
                Change &= String.Format("Change Account Type 1 from {0} to {1}. ", cbxCA_1.Tag, "CA")
            End If
            If txtSA_1.Text = txtSA_1.Tag Then
            Else
                Change &= String.Format("Change SA 1 from {0} to {1}. ", txtSA_1.Tag, txtSA_1.Text)
            End If
            If dAverageBalance_1.Value = dAverageBalance_1.Tag Then
            Else
                Change &= String.Format("Change Average Balance 1 from {0} to {1}. ", dAverageBalance_1.Tag, dAverageBalance_1.Value)
            End If
            If dPresentBalance_1.Value = dPresentBalance_1.Tag Then
            Else
                Change &= String.Format("Change Present Balance 1 from {0} to {1}. ", dPresentBalance_1.Tag, dPresentBalance_1.Value)
            End If
            If FormatDatePicker(dtpOpened_1) = dtpOpened_1.Tag Then
            Else
                Change &= String.Format("Change Date Opened 1 from {0} to {1}. ", dtpOpened_1.Tag, FormatDatePicker(dtpOpened_1))
            End If
            If txtBankRemarks_1.Text = txtBankRemarks_1.Tag Then
            Else
                Change &= String.Format("Change Bank Remarks 1 from {0} to {1}. ", txtBankRemarks_1.Tag, txtBankRemarks_1.Text)
            End If
            If txtBank_2.Text = txtBank_2.Tag Then
            Else
                Change &= String.Format("Change Bank 2 from {0} to {1}. ", txtBank_2.Tag, txtBank_2.Text)
            End If
            If txtBranch_2.Text = txtBranch_2.Tag Then
            Else
                Change &= String.Format("Change Branch 2 from {0} to {1}. ", txtBranch_2.Tag, txtBranch_2.Text)
            End If
            If cbxSA_2.Tag <> "SA" And cbxSA_2.Checked Then
                Change &= String.Format("Change Account Type 2 from {0} to {1}. ", cbxSA_2.Tag, "SA")
            ElseIf cbxCA_2.Tag <> "CA" And cbxCA_2.Checked Then
                Change &= String.Format("Change Account Type 2 from {0} to {1}. ", cbxCA_2.Tag, "CA")
            End If
            If txtSA_2.Text = txtSA_2.Tag Then
            Else
                Change &= String.Format("Change SA 2 from {0} to {1}. ", txtSA_2.Tag, txtSA_2.Text)
            End If
            If dAverageBalance_2.Value = dAverageBalance_2.Tag Then
            Else
                Change &= String.Format("Change Average Balance 2 from {0} to {1}. ", dAverageBalance_2.Tag, dAverageBalance_2.Value)
            End If
            If dPresentBalance_2.Value = dPresentBalance_2.Tag Then
            Else
                Change &= String.Format("Change Present Balance 2 from {0} to {1}. ", dPresentBalance_2.Tag, dPresentBalance_2.Value)
            End If
            If FormatDatePicker(dtpOpened_2) = dtpOpened_2.Tag Then
            Else
                Change &= String.Format("Change Date Opened 2 from {0} to {1}. ", dtpOpened_2.Tag, FormatDatePicker(dtpOpened_2))
            End If
            If txtBankRemarks_2.Text = txtBankRemarks_2.Tag Then
            Else
                Change &= String.Format("Change Bank Remarks 2 from {0} to {1}. ", txtBankRemarks_2.Tag, txtBankRemarks_2.Text)
            End If
            If ChangeLogo Then
                Change &= "Change Logo."
            End If
            If cbxAgentName.Text = cbxAgentName.Tag Then
            Else
                Change &= String.Format("Change Agent from {0} to {1}. ", cbxAgentName.Tag, cbxAgentName.Text)
            End If
            If txtAgentContact.Text = txtAgentContact.Tag Then
            Else
                Change &= String.Format("Change Agent No. from {0} to {1}. ", txtAgentContact.Tag, txtAgentContact.Text)
            End If
            If cbxMarketingName.Text = cbxMarketingName.Tag Then
            Else
                Change &= String.Format("Change Account Officer from {0} to {1}. ", cbxMarketingName.Tag, cbxMarketingName.Text)
            End If
            If txtMarketingContact.Text = txtMarketingContact.Tag Then
            Else
                Change &= String.Format("Change Account Officer No. from {0} to {1}. ", txtMarketingContact.Tag, txtMarketingContact.Text)
            End If
            If cbxWalkInType.Text = cbxWalkInType.Tag Then
            Else
                Change &= String.Format("Change Walkin Type from {0} to {1}. ", cbxWalkInType.Tag, cbxWalkInType.Text)
            End If
            If txtWalkInOthers.Text = txtWalkInOthers.Tag Then
            Else
                Change &= String.Format("Change Walkin Specify from {0} to {1}. ", txtWalkInOthers.Tag, txtWalkInOthers.Text)
            End If
            If cbxDealerName.Text = cbxDealerName.Tag Then
            Else
                Change &= String.Format("Change Dealer from {0} to {1}. ", cbxDealerName.Tag, cbxDealerName.Text)
            End If
            If txtDealersContact.Text = txtDealersContact.Tag Then
            Else
                Change &= String.Format("Change Dealer No. from {0} to {1}. ", txtDealersContact.Tag, txtDealersContact.Text)
            End If
            If cbxBusinessCenter.Text = cbxBusinessCenter.Tag Then
            Else
                Change &= String.Format("Change Business Center from {0} to {1}. ", cbxBusinessCenter.Tag, cbxBusinessCenter.Text)
            End If
        Catch ex As Exception
            TriggerBugReport("Borrower Corp - Changes", ex.Message.ToString)
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
        '********CREATE FOLDER Borrowers
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Borrowers", RootFolder, MainFolder, Branch_Code)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Borrowers", RootFolder, MainFolder, Branch_Code))
        End If
        '********CREATE FOLDER BorrowerID
        If Not IO.Directory.Exists(String.Format("{0}\{1}\{2}\Borrowers\{3}", RootFolder, MainFolder, Branch_Code, txtBorrowerID.Text)) Then
            IO.Directory.CreateDirectory(String.Format("{0}\{1}\{2}\Borrowers\{3}", RootFolder, MainFolder, Branch_Code, txtBorrowerID.Text))
        End If
        '********CREATE File
        Try
            Dim xPath As String = String.Format("{0}\{1}\{2}\Borrowers\{3}\{4}", RootFolder, MainFolder, Branch_Code, txtBorrowerID.Text, FileName)
            If IO.File.Exists(xPath) Then
                IO.File.Delete(xPath)
            End If
            pBox.Image.Save(xPath, ImageFormat.Jpeg)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        If vUpdate Then
        Else
            MsgBox(mBox_Update, MsgBoxStyle.Information, "Info")
            Exit Sub
        End If

        If MsgBoxYes(mModify) = MsgBoxResult.Yes Then
            btnSaveDraft.Text = "Update Draft"
            btnSave.Text = "Update"
            btnSaveDraft.Enabled = True
            btnSave.Enabled = True
            btnModify.Enabled = False
            btnDelete.Enabled = True
            PanelEx2.Enabled = True
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
            Dim CreditApplicationCount As Integer = DataObject(String.Format("SELECT COUNT(ID) FROM credit_application WHERE BorrowerID = '{0}' AND `status` = 'ACTIVE';", txtBorrowerID.Text))
            If CreditApplicationCount > 0 Then
                MsgBox(String.Format("Borrower {0} have existing {1} active credit application accounts, cancellation is not allowed.", txtTradeName.Text, CreditApplicationCount), MsgBoxStyle.Information, "Info")
                Cursor = Cursors.Default
                Exit Sub
            End If
            DataObject(String.Format("UPDATE profile_corporation SET `status` = 'DELETED' WHERE BorrowerID = '{0}'", txtBorrowerID.Text))
            Logs("Corporation Borrower", "Cancel", Reason, String.Format("Cancel corporation borrower {0}", txtTradeName.Text), txtBorrowerID.Text, txtTradeName.Text, "")
            Clear()
            Cursor = Cursors.Default
            FrmBorrowerList.btnSearch.PerformClick()
            MsgBox("Successfully Cancelled", MsgBoxStyle.Information, "Info")
        End If
    End Sub

    Private Sub CbxAgent_CheckedChanged(sender As Object, e As EventArgs) Handles cbxAgent.CheckedChanged
        If cbxAgent.Checked Then
            cbxAgentName.Enabled = True
            txtAgentContact.Enabled = True
        Else
            cbxAgentName.Enabled = False
            cbxAgentName.Text = ""
            txtAgentContact.Enabled = False
            txtAgentContact.Text = ""
        End If
    End Sub

    Private Sub CbxMarketing_CheckedChanged(sender As Object, e As EventArgs) Handles cbxMarketing.CheckedChanged
        If cbxMarketing.Checked Then
            cbxMarketingName.Enabled = True
            txtMarketingContact.Enabled = True
        Else
            cbxMarketingName.Enabled = False
            cbxMarketingName.Text = ""
            txtMarketingContact.Enabled = False
            txtMarketingContact.Text = ""
        End If
    End Sub

    Private Sub CbxWalkIn_CheckedChanged(sender As Object, e As EventArgs) Handles cbxWalkIn.CheckedChanged
        If cbxWalkIn.Checked Then
            cbxWalkInType.Enabled = True
            txtWalkInOthers.Enabled = True
        Else
            cbxWalkInType.Enabled = False
            cbxWalkInType.Text = ""
            txtWalkInOthers.Enabled = False
            txtWalkInOthers.Text = ""
        End If
    End Sub

    Private Sub CbxAgentName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxAgentName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxAgentName.SelectedIndex = -1 Or cbxAgentName.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxAgentName.SelectedItem, DataRowView)
            txtAgentContact.Text = drv("Contact")
        End If
    End Sub

    Private Sub CbxAgentName_TextChanged(sender As Object, e As EventArgs) Handles cbxAgentName.TextChanged
        If cbxAgentName.Text = "" Then
            txtAgentContact.Text = ""
        End If
    End Sub

    Private Sub BtnAttach_Click(sender As Object, e As EventArgs) Handles btnAttach.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment"
            .Type = "Borrower's Attachment C"
            .TotalImage = TotalImage
            .BorrowerNumber = txtBorrowerID.Text
            .ID = txtBorrowerID.Text
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage = .TotalImage
            ElseIf Result = DialogResult.Yes Then
                TotalImage = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub IEmployees_ValueChanged(sender As Object, e As EventArgs) Handles iEmployees.ValueChanged
        If iEmployees.Value < 10 Then
            cbxMicro.Checked = True
        ElseIf iEmployees.Value >= 10 And iEmployees.Value < 100 Then
            cbxSmall.Checked = True
        ElseIf iEmployees.Value >= 100 And iEmployees.Value < 200 Then
            cbxMedium.Checked = True
        ElseIf iEmployees.Value >= 200 Then
            cbxLarge.Checked = True
        End If
    End Sub

    Private Sub CbxSA_1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSA_1.CheckedChanged
        If cbxSA_1.Checked Then
            txtSA_1.Enabled = True
            cbxCA_1.Checked = False
            btnCA_1.Enabled = False
        End If
    End Sub

    Private Sub CbxCA_1_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCA_1.CheckedChanged
        If cbxCA_1.Checked Then
            txtSA_1.Enabled = True
            cbxSA_1.Checked = False
            btnCA_1.Enabled = True

            If FirstLoad Or cbxCA_1.Enabled = False Then
                Exit Sub
            End If
            Dim CA As New FrmCASignatories
            With CA
                .CA_Signatory1 = True
                .CA_Signatory2 = False
                .CbxPrefix_S1.ValueMember = "ID"
                .CbxPrefix_S1.DisplayMember = "Prefix"
                .CbxPrefix_S1.DataSource = Prefix.Copy
                .CbxPrefix_S1.SelectedIndex = -1

                .CbxPrefix_S2.ValueMember = "ID"
                .CbxPrefix_S2.DisplayMember = "Prefix"
                .CbxPrefix_S2.DataSource = Prefix.Copy
                .CbxPrefix_S2.SelectedIndex = -1

                .cbxSuffix_S1.DisplayMember = "Suffix"
                .cbxSuffix_S1.DataSource = Suffix.Copy
                .cbxSuffix_S1.SelectedIndex = -1

                .cbxSuffix_S2.DisplayMember = "Suffix"
                .cbxSuffix_S2.DataSource = Suffix.Copy
                .cbxSuffix_S2.SelectedIndex = -1

                .CbxPrefix_S1.Text = vPrefix_S1
                .TxtFirstN_S1.Text = vFirstN_S1
                .TxtMiddleN_S1.Text = vMiddleN_S1
                .TxtLastN_S1.Text = vLastN_S1
                .cbxSuffix_S1.Text = vSuffix_S1

                .CbxPrefix_S2.Text = vPrefix_S2
                .TxtFirstN_S2.Text = vFirstN_S2
                .TxtMiddleN_S2.Text = vMiddleN_S2
                .TxtLastN_S2.Text = vLastN_S2
                .cbxSuffix_S2.Text = vSuffix_S2
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub CbxSA_2_CheckedChanged(sender As Object, e As EventArgs) Handles cbxSA_2.CheckedChanged
        If cbxSA_2.Checked Then
            txtSA_2.Enabled = True
            cbxCA_2.Checked = False
            btnCA_2.Enabled = False
        End If
    End Sub

    Private Sub CbxCA_2_CheckedChanged(sender As Object, e As EventArgs) Handles cbxCA_2.CheckedChanged
        If cbxCA_2.Checked Then
            txtSA_2.Enabled = True
            cbxSA_2.Checked = False
            btnCA_2.Enabled = True

            If FirstLoad Or cbxCA_2.Enabled = False Then
                Exit Sub
            End If
            Dim CA As New FrmCASignatories
            With CA
                .CA_Signatory1 = False
                .CA_Signatory2 = True
                .CbxPrefix_S1.ValueMember = "ID"
                .CbxPrefix_S1.DisplayMember = "Prefix"
                .CbxPrefix_S1.DataSource = Prefix.Copy
                .CbxPrefix_S1.SelectedIndex = -1

                .CbxPrefix_S2.ValueMember = "ID"
                .CbxPrefix_S2.DisplayMember = "Prefix"
                .CbxPrefix_S2.DataSource = Prefix.Copy
                .CbxPrefix_S2.SelectedIndex = -1

                .cbxSuffix_S1.DisplayMember = "Suffix"
                .cbxSuffix_S1.DataSource = Suffix.Copy
                .cbxSuffix_S1.SelectedIndex = -1

                .cbxSuffix_S2.DisplayMember = "Suffix"
                .cbxSuffix_S2.DataSource = Suffix.Copy
                .cbxSuffix_S2.SelectedIndex = -1

                .CbxPrefix_S1.Text = vPrefix_S3
                .TxtFirstN_S1.Text = vFirstN_S3
                .TxtMiddleN_S1.Text = vMiddleN_S3
                .TxtLastN_S1.Text = vLastN_S3
                .cbxSuffix_S1.Text = vSuffix_S3

                .CbxPrefix_S2.Text = vPrefix_S4
                .TxtFirstN_S2.Text = vFirstN_S4
                .TxtMiddleN_S2.Text = vMiddleN_S4
                .TxtLastN_S2.Text = vLastN_S4
                .cbxSuffix_S2.Text = vSuffix_S4
                .ShowDialog()
                .Dispose()
            End With
        End If
    End Sub

    Private Sub BtnAttach_R1_Click(sender As Object, e As EventArgs) Handles btnAttach_R1.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment R1"
            .Type = "Borrower's Attachment R1"
            .TotalImage = TotalImage_R1
            .BorrowerNumber = txtBorrowerID.Text
            .ID = txtBorrowerID.Text
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage_R1 = .TotalImage
            ElseIf Result = DialogResult.Yes Then
                TotalImage_R1 = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_R2_Click(sender As Object, e As EventArgs) Handles btnAttach_R2.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment R2"
            .Type = "Borrower's Attachment R2"
            .TotalImage = TotalImage_R2
            .BorrowerNumber = txtBorrowerID.Text
            .ID = txtBorrowerID.Text
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage_R2 = .TotalImage
            ElseIf Result = DialogResult.Yes Then
                TotalImage_R2 = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_R3_Click(sender As Object, e As EventArgs) Handles btnAttach_R3.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment R3"
            .Type = "Borrower's Attachment R3"
            .TotalImage = TotalImage_R3
            .BorrowerNumber = txtBorrowerID.Text
            .ID = txtBorrowerID.Text
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage_R3 = .TotalImage
            ElseIf Result = DialogResult.Yes Then
                TotalImage_R3 = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_R4_Click(sender As Object, e As EventArgs) Handles btnAttach_R4.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment R4"
            .Type = "Borrower's Attachment R4"
            .TotalImage = TotalImage_R4
            .BorrowerNumber = txtBorrowerID.Text
            .ID = txtBorrowerID.Text
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage_R4 = .TotalImage
            ElseIf Result = DialogResult.Yes Then
                TotalImage_R4 = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_R5_Click(sender As Object, e As EventArgs) Handles btnAttach_R5.Click
        Dim Attach As New FrmAttachFileV2
        With Attach
            .FolderName = "Attachment R5"
            .Type = "Borrower's Attachment R5"
            .TotalImage = TotalImage_R5
            .BorrowerNumber = txtBorrowerID.Text
            .ID = txtBorrowerID.Text
            Dim Result = .ShowDialog
            If Result = DialogResult.OK Then
                TotalImage_R5 = .TotalImage
            ElseIf Result = DialogResult.Yes Then
                TotalImage_R5 = .TotalImage
            End If
            .Dispose()
        End With
    End Sub

    Private Sub BtnAttach_R1B_Click(sender As Object, e As EventArgs) Handles btnAttach_R1B.Click
        btnAttach_R1.PerformClick()
    End Sub

    Private Sub BtnAttach_R2B_Click(sender As Object, e As EventArgs) Handles btnAttach_R2B.Click
        btnAttach_R2.PerformClick()
    End Sub

    Private Sub BtnAttach_R3B_Click(sender As Object, e As EventArgs) Handles btnAttach_R3B.Click
        btnAttach_R3.PerformClick()
    End Sub

    Private Sub BtnAttach_R4B_Click(sender As Object, e As EventArgs) Handles btnAttach_R4B.Click
        btnAttach_R4.PerformClick()
    End Sub

    Private Sub BtnAttach_R5B_Click(sender As Object, e As EventArgs) Handles btnAttach_R5B.Click
        btnAttach_R5.PerformClick()
    End Sub

    Private Sub CbxDealer_CheckedChanged(sender As Object, e As EventArgs) Handles cbxDealer.CheckedChanged
        If cbxDealer.Checked Then
            cbxDealerName.Enabled = True
            txtDealersContact.Enabled = True
        Else
            cbxDealerName.Enabled = False
            cbxDealerName.Text = ""
            txtDealersContact.Enabled = False
            txtDealersContact.Text = ""
        End If
    End Sub

    Private Sub CbxDealerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbxDealerName.SelectedIndexChanged
        If FirstLoad Then
            Exit Sub
        End If

        If cbxDealerName.SelectedIndex = -1 Or cbxDealerName.Text = "" Then
        Else
            Dim drv As DataRowView = DirectCast(cbxDealerName.SelectedItem, DataRowView)
            txtDealersContact.Text = drv("Contact")
        End If
    End Sub

    Private Sub BtnCA_1_Click(sender As Object, e As EventArgs) Handles btnCA_1.Click
        Dim CA As New FrmCASignatories
        With CA
            .CA_Signatory1 = True
            .CA_Signatory2 = False
            .CbxPrefix_S1.ValueMember = "ID"
            .CbxPrefix_S1.DisplayMember = "Prefix"
            .CbxPrefix_S1.DataSource = Prefix.Copy
            .CbxPrefix_S1.SelectedIndex = -1

            .CbxPrefix_S2.ValueMember = "ID"
            .CbxPrefix_S2.DisplayMember = "Prefix"
            .CbxPrefix_S2.DataSource = Prefix.Copy
            .CbxPrefix_S2.SelectedIndex = -1

            .cbxSuffix_S1.DisplayMember = "Suffix"
            .cbxSuffix_S1.DataSource = Suffix.Copy
            .cbxSuffix_S1.SelectedIndex = -1

            .cbxSuffix_S2.DisplayMember = "Suffix"
            .cbxSuffix_S2.DataSource = Suffix.Copy
            .cbxSuffix_S2.SelectedIndex = -1

            .CbxPrefix_S1.Text = vPrefix_S1
            .TxtFirstN_S1.Text = vFirstN_S1
            .TxtMiddleN_S1.Text = vMiddleN_S1
            .TxtLastN_S1.Text = vLastN_S1
            .cbxSuffix_S1.Text = vSuffix_S1

            .CbxPrefix_S2.Text = vPrefix_S2
            .TxtFirstN_S2.Text = vFirstN_S2
            .TxtMiddleN_S2.Text = vMiddleN_S2
            .TxtLastN_S2.Text = vLastN_S2
            .cbxSuffix_S2.Text = vSuffix_S2
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnCA_2_Click(sender As Object, e As EventArgs) Handles btnCA_2.Click
        Dim CA As New FrmCASignatories
        With CA
            .CA_Signatory1 = False
            .CA_Signatory2 = True
            .CbxPrefix_S1.ValueMember = "ID"
            .CbxPrefix_S1.DisplayMember = "Prefix"
            .CbxPrefix_S1.DataSource = Prefix.Copy
            .CbxPrefix_S1.SelectedIndex = -1

            .CbxPrefix_S2.ValueMember = "ID"
            .CbxPrefix_S2.DisplayMember = "Prefix"
            .CbxPrefix_S2.DataSource = Prefix.Copy
            .CbxPrefix_S2.SelectedIndex = -1

            .cbxSuffix_S1.DisplayMember = "Suffix"
            .cbxSuffix_S1.DataSource = Suffix.Copy
            .cbxSuffix_S1.SelectedIndex = -1

            .cbxSuffix_S2.DisplayMember = "Suffix"
            .cbxSuffix_S2.DataSource = Suffix.Copy
            .cbxSuffix_S2.SelectedIndex = -1

            .CbxPrefix_S1.Text = vPrefix_S3
            .TxtFirstN_S1.Text = vFirstN_S3
            .TxtMiddleN_S1.Text = vMiddleN_S3
            .TxtLastN_S1.Text = vLastN_S3
            .cbxSuffix_S1.Text = vSuffix_S3

            .CbxPrefix_S2.Text = vPrefix_S4
            .TxtFirstN_S2.Text = vFirstN_S4
            .TxtMiddleN_S2.Text = vMiddleN_S4
            .TxtLastN_S2.Text = vLastN_S4
            .cbxSuffix_S2.Text = vSuffix_S4
            .ShowDialog()
            .Dispose()
        End With
    End Sub

    Private Sub BtnDefault_Click(sender As Object, e As EventArgs) Handles btnDefault.Click
        txtPath.Text = " "
        ResizeImages(DefaultImage.Image.Clone, pb_Logo, 650, 500)
    End Sub
End Class